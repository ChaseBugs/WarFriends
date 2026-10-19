"""Report native SDK/Unity motion differences without treating diagnostic tolerances as gameplay acceptance."""

import argparse
import csv
import hashlib
import json
import math
from pathlib import Path


def compare(reference_path: Path, probe_path: Path) -> dict:
    reference_bytes = reference_path.read_bytes().replace(b"\r\n", b"\n")
    reference = json.loads(reference_bytes)
    expected = {
        (frame["step"], scenario, body): state
        for frame in reference["frames"]
        for scenario, rope in enumerate(frame["ropes"])
        for body, state in enumerate(rope["joints"])
    }
    maxima = {}
    seen = set()
    with probe_path.open(newline="", encoding="utf-8-sig") as stream:
        for row in csv.reader(stream):
            if len(row) != 16:
                raise ValueError("A native rope row must contain its three indexes and thirteen float values.")
            identity = tuple(map(int, row[:3]))
            if identity not in expected or identity in seen:
                raise ValueError(f"Unknown or duplicate native body step: {identity}")
            seen.add(identity)
            values = list(map(float, row[3:]))
            if not all(math.isfinite(value) for value in values):
                raise ValueError(f"Non-finite native body step: {identity}")
            state = expected[identity]
            rotation = state["rotation"]
            differences = {
                "position": math.dist(values[:3], state["position"]),
                "velocity": math.dist(values[7:10], state["velocity"]),
                "rotation": min(math.dist(values[3:7], rotation),
                                math.dist(values[3:7], [-value for value in rotation])),
                "angularVelocity": math.dist(values[10:13], state["angularVelocity"]),
            }
            maximum = maxima.setdefault(str(identity[1]), dict.fromkeys(differences, 0.0))
            for name, difference in differences.items():
                maximum[name] = max(maximum[name], difference)
    if seen != expected.keys():
        raise ValueError("The native probe did not return every expected body step.")
    return {"referenceSha256": hashlib.sha256(reference_bytes).hexdigest(),
            "bodySteps": len(seen), "maximumDifferences": maxima,
            "scope": "Motion diagnostics only; no live gameplay or cross-platform parity claim."}


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("reference", type=Path)
    parser.add_argument("probe", type=Path)
    parser.add_argument("--output", type=Path)
    arguments = parser.parse_args()
    report = json.dumps(compare(arguments.reference, arguments.probe), indent=2) + "\n"
    if arguments.output:
        arguments.output.write_text(report, encoding="utf-8")
    print(report, end="")


if __name__ == "__main__":
    main()
