"""Explain the MainScene snapshot transition without approving or rewriting content.

The report proves the recorded restoration delta and inventories dependent artifacts.
It is not a replacement for source extraction, native recapture or release validation.
"""
import argparse
import hashlib
import json
import re
import subprocess
from pathlib import Path

import extract_mission_catalog as missions

ROOT = Path(__file__).resolve().parents[2]
RESTORATION = "f9f63d037d3a62466e224559bd3154b325ec312c"
SCENE = "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
REPORT = ROOT / "Server/docs/main-scene-provenance-audit.json"
COMPONENT = 45847
COUNTS = {"weaponLevelsSetups": 66, "behaviours": 24, "additionalBehaviours": 3}
BLOCK = re.compile(rb"^--- !u!(\d+) &(-?\d+)\r?$", re.M)


def digest(payload):
    return hashlib.sha256(payload).hexdigest()


def components(payload):
    headers = list(BLOCK.finditer(payload))
    result = {}
    for index, header in enumerate(headers):
        key = (int(header[1]), int(header[2]))
        if key in result:
            raise ValueError("Duplicate scene object identity")
        end = headers[index + 1].start() if index + 1 < len(headers) else len(payload)
        result[key] = payload[header.start():end]
    return result


def restored_payload(binding):
    fields = binding["fields"]
    lines = []
    for name, count in COUNTS.items():
        pointers = fields[name]
        if len(pointers) != count or len({item["m_PathID"] for item in pointers}) != count:
            raise ValueError("Restoration pointer count or uniqueness differs")
        lines.append("  " + name + ":")
        for pointer in pointers:
            if pointer["m_FileID"] != 0 or pointer["m_PathID"] <= 0:
                raise ValueError("Restoration pointer is not a local component")
            lines.append("  - {fileID: " + str(pointer["m_PathID"]) + "}")
    if fields["levelExperience"] != 0 or fields["experience"] != 0 or fields["levels"] != []:
        raise ValueError("Restoration progression fields differ")
    lines.extend(["  levelExperience: 0", "  experience: 0", "  levels: []"])
    return ("\n".join(lines) + "\n").encode()


def verify_transition(before, after, binding):
    target = binding["target"]
    if target["scene"] != SCENE or target["componentFileId"] != COMPONENT:
        raise ValueError("Restoration target differs")
    if digest(before) != target["beforeSha256"] or digest(after) != target["afterSha256"]:
        raise ValueError("Scene bytes differ from the recorded restoration")
    old_blocks = components(before)
    new_blocks = components(after)
    if old_blocks.keys() != new_blocks.keys():
        raise ValueError("Scene object membership changed")
    changed = [key for key in old_blocks if old_blocks[key] != new_blocks[key]]
    if changed != [(114, COMPONENT)]:
        raise ValueError("Changes extend beyond the restored LevelManager")
    old = old_blocks[(114, COMPONENT)]
    new = new_blocks[(114, COMPONENT)]
    marker = b"  m_EditorClassIdentifier:\n"
    if old.count(marker) != 1 or b"guid: 780c78d4af376959b095359d8460246f," not in old:
        raise ValueError("LevelManager header identity differs")
    if old.split(marker)[1].strip():
        raise ValueError("Historical component already contains custom fields")
    # The restoration tool preserves a blank separator before the next Unity object.
    expected = old.replace(marker, marker + restored_payload(binding) + b"\n")
    if new != expected or after != before.replace(old, expected, 1):
        raise ValueError("Scene delta differs from the exact restored payload")
    return len(old_blocks)


def string_values(value):
    if isinstance(value, dict):
        for item in value.values():
            yield from string_values(item)
    elif isinstance(value, list):
        for item in value:
            yield from string_values(item)
    elif isinstance(value, str):
        yield value


def inventory_artifacts(old_hash, new_hash):
    artifacts = []
    for path in sorted((ROOT / "Server/content").glob("*.json")):
        payload = path.read_bytes()
        values = set(string_values(json.loads(payload)))
        artifacts.append({
            "path": path.relative_to(ROOT).as_posix(),
            "sha256": digest(payload),
            "oldSceneReference": old_hash in values,
            "currentSceneReference": new_hash in values,
            "references": {value for value in values if re.fullmatch(r"[0-9a-f]{64}", value)},
        })
    affected = {row["sha256"] for row in artifacts if row["oldSceneReference"]}
    while True:
        expanded = affected | {row["sha256"] for row in artifacts if row["references"] & affected}
        if expanded == affected:
            break
        affected = expanded
    names = {}
    for row in artifacts:
        names.setdefault(row["sha256"], []).append(row["path"])
    result = []
    for row in artifacts:
        if row["sha256"] not in affected:
            continue
        references = row.pop("references")
        row["affectedDependencies"] = sorted(
            path for value in references & affected for path in names[value])
        result.append(row)
    return result


def verify_mission_values(scene):
    lines = scene.decode("utf-8-sig").splitlines()
    maps, bosses = missions.parse_maps(lines)
    current = {"maps": maps, "bossMaps": bosses,
               "missions": missions.parse_rows(missions.component_lines(lines))}
    stored = json.loads(missions.OUTPUT.read_bytes())
    for name, value in current.items():
        if stored[name] != value:
            raise ValueError("Mission semantic content changed: " + name)
    return {name: len(value) for name, value in current.items()}


def create_report():
    binding_path = ROOT / "Server/docs/level-manager-bindings.json"
    binding_bytes = binding_path.read_bytes()
    binding = json.loads(binding_bytes)
    before = subprocess.check_output(["git", "show", RESTORATION + "^:" + SCENE], cwd=ROOT)
    committed = subprocess.check_output(["git", "show", RESTORATION + ":" + SCENE], cwd=ROOT)
    after = (ROOT / SCENE).read_bytes()
    if committed != after:
        raise ValueError("Current scene differs from the restoration commit; review the new delta")
    component_count = verify_transition(before, after, binding)
    return {
        "schemaVersion": 1,
        "restorationCommit": RESTORATION,
        "restorationRecordSha256": digest(binding_bytes),
        "scene": SCENE,
        "beforeSha256": digest(before),
        "afterSha256": digest(after),
        "serializedObjectCount": component_count,
        "changedComponentFileIds": [COMPONENT],
        "restoredPointerCounts": COUNTS,
        "unchangedMissionValues": verify_mission_values(after),
        "releaseVerified": False,
        "remainingGate": "Re-extract or independently validate every affected artifact and dependent package.",
        "affectedArtifacts": inventory_artifacts(digest(before), digest(after)),
    }


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true", help="Compare the report; never rewrite content.")
    args = parser.parse_args()
    report = json.dumps(create_report(), indent=2) + "\n"
    if args.check:
        if REPORT.read_text(encoding="utf-8") != report:
            raise ValueError("Provenance audit report differs from current evidence")
        print("PASS: historical scene transition explained; content release remains unverified")
    else:
        print(report, end="")


if __name__ == "__main__":
    main()
