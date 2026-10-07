"""Extract mission rules from the recovered 1.4.0 MainScene.

The Google2u Missions component stores the rules used by MissionsManager.
This intentionally does not invent completion logic or trust client rewards.
"""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
OUTPUT = ROOT / "Server/content/recovered-mission-catalog.json"
SCRIPT_GUID = "0d5786f466603d141908ebb295fba2ce"
RULE_FIELDS = {
    "MAP_STAGE": "mapStage",
    "MISSIONTYPE": "missionType",
    "OBJECTIVE": "objective",
    "TIME": "timeSeconds",
    "SCORE1": "scoreOneStar",
    "SCORE2": "scoreTwoStars",
    "SCORE3": "scoreThreeStars",
    "MAX_UNITS_AT_ONCE": "maxUnitsAtOnce",
    "REWARD_WARBUCKS": "rewardWarbucks",
    "REWARD_GOLD": "rewardGold",
    "REWARD_XP": "rewardXp",
}


def component_lines(scene_lines):
    script_line = next(
        index for index, line in enumerate(scene_lines)
        if SCRIPT_GUID in line and "m_Script:" in line
    )
    start = next(
        index for index in range(script_line, len(scene_lines))
        if scene_lines[index] == "  Rows:"
    )
    end = next(
        index for index in range(start + 1, len(scene_lines))
        if scene_lines[index].startswith("--- !u!")
    )
    return scene_lines[start + 1:end]


def parse_rows(lines):
    rows = []
    for line in lines:
        if line.startswith("  - LEVEL:"):
            rows.append({"level": int(line.split(":", 1)[1].strip())})
        elif rows:
            match = re.fullmatch(r"    ([A-Z0-9_]+): (.*)", line)
            if match:
                rows[-1][match.group(1)] = match.group(2)
    if len(rows) != 75:
        raise ValueError(f"Expected 75 source missions, found {len(rows)}")

    result = []
    for index, row in enumerate(rows):
        if row["level"] != index + 1 or not RULE_FIELDS.keys() <= row.keys():
            raise ValueError(f"Incomplete or unordered mission at index {index}")
        mission = {"index": index, "level": row["level"]}
        for source_name, output_name in RULE_FIELDS.items():
            value = row[source_name]
            if source_name == "MISSIONTYPE":
                mission[output_name] = value
            elif source_name == "OBJECTIVE" and value == "' '":
                mission[output_name] = None
            else:
                mission[output_name] = int(value)
        source_data = row.get("DATA", "")
        if source_data.startswith("'") and source_data.endswith("'"):
            scene_data = source_data[1:-1].replace("''", "'")
        elif source_data.startswith('"') and source_data.endswith('"'):
            scene_data = json.loads(source_data)
        else:
            raise ValueError(f"Missing scene data for mission {index}")
        json.loads(scene_data)
        mission["sceneDataSha256"] = hashlib.sha256(
            scene_data.encode("utf-8")
        ).hexdigest()
        result.append(mission)
    return result


def main():
    scene_bytes = SCENE.read_bytes()
    scene_lines = scene_bytes.decode("utf-8-sig").splitlines()
    missions = parse_rows(component_lines(scene_lines))
    document = {
        "source": "Clients/ExportedProject/Assets/Scenes/MainScene.unity",
        "sourceSha256": hashlib.sha256(scene_bytes).hexdigest(),
        "missions": missions,
    }
    expected_text = json.dumps(document, indent=2) + "\n"
    if "--check" in sys.argv:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != expected_text:
            raise ValueError("Mission catalog differs from recovered MainScene")
        print(f"Verified {len(missions)} missions against recovered MainScene")
    else:
        OUTPUT.write_text(expected_text, encoding="utf-8")
        print(f"Extracted {len(missions)} missions to {OUTPUT}")


if __name__ == "__main__":
    main()
