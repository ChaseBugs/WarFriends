"""Preserve the recovered missile's render data while removing its two gameplay scripts."""
import argparse
import hashlib
import json
from pathlib import Path
import re

ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "Clients/ExportedProject/Assets/GameObject/Missile.prefab"
VISUAL = ROOT / "Clients/ExportedProject/Assets/Resources/SelfHostedPlayerMissileVisual.prefab"
REPORT = ROOT / "Server/content/player-missile-visual-reference.json"
SOURCE_SHA256 = "ea6028a7d482ee2c44589d8f0bb129bfb5bbcdb7d9459f4f7367b910482f4655"
SCRIPT_IDS = {11431434, 11470521}


def build_visual():
    source_bytes = SOURCE.read_bytes()
    if hashlib.sha256(source_bytes).hexdigest() != SOURCE_SHA256:
        raise ValueError("The original missile prefab differs from the reviewed 1.4.0 source.")

    sections = re.split(r"(?=^--- !u!)", source_bytes.decode("utf-8"), flags=re.MULTILINE)
    preserved = []
    removed = set()
    for section in sections:
        script = re.match(r"--- !u!114 &(\d+)", section)
        if script:
            removed.add(int(script.group(1)))
        else:
            preserved.append(section)
    if removed != SCRIPT_IDS:
        raise ValueError("The source gameplay component set changed.")

    visual = "".join(preserved)
    for component_id in sorted(SCRIPT_IDS):
        pattern = rf"^  - 114: \{{fileID: {component_id}\}}\r?\n"
        visual, count = re.subn(pattern, "", visual, flags=re.MULTILINE)
        if count != 1 or f"fileID: {component_id}" in visual:
            raise ValueError("A removed script has unexpected remaining references.")

    visual_bytes = visual.encode("utf-8")
    report = {
        "sourcePath": SOURCE.relative_to(ROOT).as_posix(),
        "sourceSha256": SOURCE_SHA256,
        "removedComponentIds": sorted(SCRIPT_IDS),
        "visualPath": VISUAL.relative_to(ROOT).as_posix(),
        "visualSha256": hashlib.sha256(visual_bytes).hexdigest(),
    }
    return visual_bytes, (json.dumps(report, indent=2) + "\n").encode("utf-8")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--verify", action="store_true")
    options = parser.parse_args()
    visual_bytes, report_bytes = build_visual()
    if options.verify:
        if VISUAL.read_bytes() != visual_bytes or REPORT.read_bytes() != report_bytes:
            raise ValueError("The generated visual or provenance report differs from the reviewed source.")
    else:
        VISUAL.write_bytes(visual_bytes)
        REPORT.write_bytes(report_bytes)
    print("PASS: original missile render data preserved; only the two gameplay scripts removed")


if __name__ == "__main__":
    main()
