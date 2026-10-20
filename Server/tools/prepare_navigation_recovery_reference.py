"""Compile the recovered recovery expression in a disposable Unity project, without rewriting it by hand."""

import argparse
import hashlib
import json
import math
from pathlib import Path
import re
import struct


def float32(value):
    return struct.unpack("<f", struct.pack("<f", value))[0]


def from_bits(value):
    return struct.unpack("<f", struct.pack("<I", value))[0]


def balanced(source, start, opening, closing):
    depth = 1
    index = start
    while depth:
        character = source[index]
        depth += (character == opening) - (character == closing)
        index += 1
    return source[start:index - 1], index


def cases():
    rows = []

    def add(identity, **changes):
        row = dict(_id=identity, _stopped=False, _status=0, _pending=False,
                   _pathEnd=dict(x=0, y=0, z=0), _destination=dict(x=1, y=0, z=0),
                   _velocity=dict(x=0, y=0, z=0))
        row.update(changes)
        rows.append(row)

    add("stuck")
    add("wrapper-stopped", _stopped=True)
    add("partial-path", _status=1)
    add("invalid-path", _status=2)
    add("path-pending", _pending=True)
    add("same-endpoint", _destination=dict(x=0, y=0, z=0))
    for offset, label in [(-1, "below"), (0, "float-equal"), (1, "above")]:
        add("distance-" + label, _destination=dict(x=from_bits(0x3DCCCCCD + offset), y=0, z=0))
    add("vertical-distance", _destination=dict(x=0, y=0.11, z=0))
    add("short-diagonal", _destination=dict(x=0.05, y=0.05, z=0.05))
    add("moving", _velocity=dict(x=1, y=0, z=0))
    add("two-component-velocity", _velocity=dict(x=0.1, y=0.2, z=0))
    speed_bits = struct.unpack("<I", struct.pack("<f", math.sqrt(0.05)))[0]
    add("velocity-below", _velocity=dict(x=from_bits(speed_bits - 1), y=0, z=0))
    add("velocity-above", _velocity=dict(x=from_bits(speed_bits + 1), y=0, z=0))
    center = struct.unpack("<I", struct.pack("<f", math.sqrt(0.05 - 0.03125)))[0]
    for offset in range(-16, 17):
        final = from_bits(center + offset)
        if float32(float32(0.03125) + float32(final * final)) == float32(0.05):
            add("velocity-exact-squared-threshold", _velocity=dict(x=0.125, y=0.125, z=final))
            break
    else:
        raise ValueError("Could not construct the exact raw-velocity boundary.")
    return rows


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("project", type=Path)
    arguments = parser.parse_args()
    root = Path(__file__).resolve().parents[2]
    project = arguments.project.resolve()
    if not project.is_relative_to((root / "Server/.local").resolve()):
        raise ValueError("Reference export requires a disposable Server/.local project.")
    source_path = root / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/NavigationAgent.cs"
    raw = source_path.read_bytes()
    source = raw.decode("utf-8-sig")
    method = source.index("protected void Updatenavigation()")
    start = source.index("if (mAgent.pathStatus", method) + len("if (")
    expression, end = balanced(source, start, "(", ")")
    block_start = source.index("{", end) + 1
    block, _ = balanced(source, block_start, "{", "}")
    operations = re.findall(r"mAgent\.(Stop|ResetPath|SetDestination|Resume)\([^;]*\);", block)
    if operations != ["Stop", "ResetPath", "SetDestination", "Resume"]:
        raise ValueError("Recovered recovery operation order changed.")
    if "(double)Vector3.Distance" not in expression or "velocity.sqrMagnitude < 0.05f" not in expression:
        raise ValueError("Recovered recovery expression changed.")
    formatted = expression.replace(" && ", "\n                && ")
    evaluator = '''using UnityEngine;
using UnityEngine.AI;

internal static class SourceNavigationRecoveryExpression
{
    internal const string SourceSha256 = "%s";
    internal const string ExpressionSha256 = "%s";

    internal static bool Evaluate(bool isStopped, AgentInput mAgent)
    {
        if (isStopped)
        {
            return false;
        }
        return %s;
    }

    internal static string[] Operations
    {
        get { return new[] { "Stop", "ResetPath", "SetDestination", "Resume" }; }
    }

    internal sealed class AgentInput
    {
        internal NavMeshPathStatus pathStatus { get; set; }
        internal Vector3 pathEndPosition { get; set; }
        internal Vector3 destination { get; set; }
        internal Vector3 velocity { get; set; }
        internal bool pathPending { get; set; }
    }
}
''' % (hashlib.sha256(raw).hexdigest(), hashlib.sha256(expression.encode()).hexdigest(), formatted)
    editor = project / "Assets/Editor"
    editor.mkdir(exist_ok=True)
    (editor / "SourceNavigationRecoveryExpression.cs").write_text(evaluator, encoding="utf-8", newline="\n")
    input_path = root / "Server/.local/navigation-recovery-input.json"
    input_path.write_text(json.dumps(dict(_cases=cases()), indent=2) + "\n", encoding="utf-8")
    print("Prepared extracted source expression and", len(cases()), "Unity math cases.")


if __name__ == "__main__":
    main()
