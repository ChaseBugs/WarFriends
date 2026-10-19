"""Export the captured stationary rope fixture into the native research probe's text input."""

import argparse
import hashlib
import json
import math
from pathlib import Path

REFERENCE_DIGEST = "e87743347ee3fa3d7cb75ced89ab8e4d756e853b86e9751c77e3ec421ac4fc11"
EXPECTED_CASES = 3
EXPECTED_BODIES = 4


def vector(values: list, size: int) -> str:
    if len(values) != size or any(type(value) not in (int, float) or not math.isfinite(value) for value in values):
        raise ValueError("The pinned native fixture contains an invalid vector.")
    return " ".join(str(value) for value in values)


def export(reference_path: Path) -> str:
    contents = reference_path.read_bytes().replace(b"\r\n", b"\n")
    if hashlib.sha256(contents).hexdigest() != REFERENCE_DIGEST:
        raise ValueError("The native probe requires the reviewed creation-time rest-frame fixture.")
    scenarios = json.loads(contents)["initial"]
    if len(scenarios) != EXPECTED_CASES:
        raise ValueError("The native fixture must contain all three source scenarios.")
    lines = [str(len(scenarios))]
    for scenario in scenarios:
        attachment = scenario["attachment"]
        lines.append(vector(attachment["connectedPosition"], 3) + " " +
                     vector(attachment["connectedRotation"], 4))
        lines.append(vector(scenario["attachmentConnectedRestRotation"], 4))
        lines.append(vector(attachment["connectedAnchor"], 3))
        if len(scenario["joints"]) != EXPECTED_BODIES:
            raise ValueError("The native fixture must contain four generated rope bodies.")
        for body in scenario["joints"]:
            lines.append(vector(body["position"], 3) + " " + vector(body["rotation"], 4))
    return "\n".join(lines) + "\n"


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("reference", type=Path)
    parser.add_argument("output", type=Path)
    arguments = parser.parse_args()
    arguments.output.write_text(export(arguments.reference), encoding="utf-8", newline="\n")


if __name__ == "__main__":
    main()
