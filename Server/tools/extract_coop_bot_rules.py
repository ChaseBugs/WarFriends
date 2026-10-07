"""Pin the fifteen source BotMission definitions from recovered MainScene."""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_mission_catalog import SCENE, component_lines


ROOT = Path(__file__).resolve().parents[2]
MISSION_CATALOG = ROOT / "Server/content/recovered-mission-catalog.json"
OUTPUT = ROOT / "Server/content/recovered-coop-bot-rules.json"


def source_rows():
    rows = []
    lines = SCENE.read_bytes().decode("utf-8-sig").splitlines()
    for line in component_lines(lines):
        if line.startswith("  - LEVEL:"):
            rows.append({})
        elif rows:
            match = re.fullmatch(r"    ([A-Z0-9_]+): (.*)", line)
            if match:
                rows[-1][match.group(1)] = match.group(2)
    if len(rows) != 75:
        raise ValueError("recovered mission source needs 75 rows")
    return rows


def scene_data(row):
    raw = row["DATA"]
    if raw.startswith("'") and raw.endswith("'"):
        text = raw[1:-1].replace("''", "'")
    elif raw.startswith('"') and raw.endswith('"'):
        text = json.loads(raw)
    else:
        raise ValueError("mission scene data is missing")
    return text, json.loads(text)


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_bot_rules.py [--check]")
    missions = json.loads(MISSION_CATALOG.read_bytes())
    if missions["sourceSha256"] != hashlib.sha256(SCENE.read_bytes()).hexdigest():
        raise ValueError("mission source changed")
    bots = []
    for index, row in enumerate(source_rows()):
        if row["MISSIONTYPE"] != "KillOpponent":
            continue
        text, data = scene_data(row)
        mission = missions["missions"][index]
        if mission["missionType"] != "KillOpponent" or \
                mission["sceneDataSha256"] != hashlib.sha256(text.encode()).hexdigest():
            raise ValueError("boss row differs from the mission catalog")
        bot = data["bot"]
        if set(bot) != {"name", "difficulty", "level", "hpReduction",
                        "camo", "headAccesory", "helmet", "powerBand",
                        "useDefinedCards", "cards"}:
            raise ValueError("unexpected recovered bot fields")
        bots.append({"missionIndex": index,
                     "sceneDataSha256": mission["sceneDataSha256"],
                     "bot": bot})
    if len(bots) != 15:
        raise ValueError("expected fifteen source boss missions")
    output = {"version": 1, "missionSourceSha256": missions["sourceSha256"],
              "bots": bots}
    encoded = (json.dumps(output, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("co-op bot rules differ from recovered MainScene")
    else:
        OUTPUT.write_bytes(encoded)
    print("fifteen source boss rows pinned; six have zero HP reduction")


if __name__ == "__main__":
    main()
