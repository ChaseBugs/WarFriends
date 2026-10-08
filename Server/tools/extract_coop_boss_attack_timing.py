"""Resolve each BotMission's recovered PlayerBot shooting timing rows."""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
BOTS = ROOT / "Server/content/recovered-coop-bot-rules.json"
OUTPUT = ROOT / "Server/content/recovered-coop-boss-attack-timing.json"
DIFFICULTIES_GUID = "69c6c060d95bf43fab0adddf0d5c048a"
PLAYER_BOTS_GUID = "f1c229012209e4fa5fdede24308207a1"


def source_rows(scene, guid):
    blocks = [block for block in re.split(r"(?=^--- !u!)", scene, flags=re.M)
              if f"guid: {guid}" in block and "  m_Script:" in block]
    if len(blocks) != 1:
        raise ValueError(f"MainScene needs one {guid} source component")
    rows = []
    for line in blocks[0].splitlines():
        if line.startswith("  - NUMBER: "):
            rows.append({"NUMBER": int(line.split(": ", 1)[1])})
        elif rows:
            match = re.fullmatch(r"    ([A-Z0-9_]+): (.*)", line)
            if match:
                rows[-1][match.group(1)] = match.group(2)
    return rows


def finite_decimal(row, field):
    raw = row[field]
    if not re.fullmatch(r"(?:0|[1-9]\d*)(?:\.\d+)?", raw):
        raise ValueError(f"invalid source {field}: {raw}")
    return float(raw)


def weapon_category(row, field, accepted):
    raw = row[field]
    # MainScene quotes AssaultRifle because its source value has a trailing
    # space. Enum.Parse accepts that space; keep the original bytes here.
    if raw.startswith("'") and raw.endswith("'"):
        value = raw[1:-1].replace("''", "'")
    else:
        value = raw
    has_unexpected_space = value != value.strip() and value != "AssaultRifle "
    if value.strip() not in accepted or has_unexpected_space:
        raise ValueError(f"unexpected boss {field} category: {value!r}")
    return value


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_boss_attack_timing.py [--check]")
    scene_bytes = SCENE.read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    difficulties = source_rows(scene, DIFFICULTIES_GUID)
    player_bots = source_rows(scene, PLAYER_BOTS_GUID)
    if [row["NUMBER"] for row in difficulties] != list(range(32)) or \
            [row["NUMBER"] for row in player_bots] != list(range(64)):
        raise ValueError("Bot timing or selection rows are incomplete")

    bot_bytes = BOTS.read_bytes()
    bots = json.loads(bot_bytes)
    if bots["missionSourceSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("Bot missions differ from the timing scene")

    mission_rows = []
    for entry in bots["bots"]:
        mission_index = entry["missionIndex"]
        source_difficulty = entry["bot"]["difficulty"]
        selected = next((row for row in player_bots
                         if row["NUMBER"] == source_difficulty), player_bots[0])
        config_index = int(selected["DIFFICULTY"])
        if not 0 <= config_index < len(difficulties):
            raise ValueError(f"mission {mission_index} has no shooting configuration")
        config = difficulties[config_index]
        minimum_frequency = finite_decimal(config, "SHOOTFREQUENCYMIN")
        maximum_frequency = finite_decimal(config, "SHOOTFREQUENCYMAX")
        minimum_length = finite_decimal(config, "SHOOTINGLENGTHMIN")
        maximum_length = finite_decimal(config, "SHOOTINGLENGTHMAX")
        accuracy = finite_decimal(config, "SHOOTACCURACY")
        explosive_switch = finite_decimal(config,
            "SWITCHGRENADEBAZOOKAPROBABILITY")
        opponent_shot = finite_decimal(config,
            "PICKOPPONENTSHOTPROBABILITY")
        opponent_without_shield = finite_decimal(config,
            "PICKOPPONENTSHOTPROBABILITYNOSHIELD")
        walking_opponent = finite_decimal(config,
            "PICKWALKINGOPPONENTSHOTPROBABILITY")
        headshot = finite_decimal(config, "HEADSHOTPROBABILITY")
        offense = finite_decimal(config, "OPPONENTOFFENSE")
        reaction = finite_decimal(config, "OPPONENTOFFENCEREACTIONTIME")
        if (minimum_frequency > maximum_frequency
                or minimum_length > maximum_length
                or not 0 <= accuracy <= 1
                or not 0 <= explosive_switch <= 1
                or not 0 <= opponent_shot <= 1
                or not 0 <= opponent_without_shield <= 1
                or not 0 <= walking_opponent <= 1
                or not 0 <= headshot <= 1
                or not 0 <= offense <= 1):
            raise ValueError(f"mission {mission_index} has invalid shooting bounds")
        mission_rows.append({
            "missionIndex": mission_index,
            "sourceDifficulty": source_difficulty,
            "playerBotsRow": selected["NUMBER"],
            "configIndex": config_index,
            "primaryCategory": weapon_category(selected, "PRIMARY",
                {"AssaultRifle", "SMG", "LMG"}),
            "secondaryCategory": weapon_category(selected, "SECONDARY",
                {"SniperRifle", "Shotgun"}),
            "explosiveCategory": weapon_category(selected, "EXPLOSIVES",
                {"Grenade", "RocketLauncher"}),
            "pistolCategory": "Pistol",
            "shootFrequencyMinSeconds": minimum_frequency,
            "shootFrequencyMaxSeconds": maximum_frequency,
            "shootingLengthMinSeconds": minimum_length,
            "shootingLengthMaxSeconds": maximum_length,
            "shootAccuracy": accuracy,
            "explosiveSwitchProbability": explosive_switch,
            "opponentShotProbability": opponent_shot,
            "opponentWithoutShieldProbability": opponent_without_shield,
            "walkingOpponentShotProbability": walking_opponent,
            "headshotProbability": headshot,
            "opponentOffense": offense,
            "opponentOffenseReactionSeconds": reaction,
        })
    if len(mission_rows) != 15:
        raise ValueError("expected fifteen boss attack rows")

    artifact = {
        "version": 1,
        "sceneSha256": hashlib.sha256(scene_bytes).hexdigest(),
        "botRulesSha256": hashlib.sha256(bot_bytes).hexdigest(),
        "difficultyComponentFileId": 46608,
        "playerBotsComponentFileId": 46610,
        "missions": mission_rows,
    }
    encoded = (json.dumps(artifact, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("boss attack timing differs from recovered MainScene")
    else:
        OUTPUT.write_bytes(encoded)
    print("15 boss attack timing rows resolved from two source sheets")


if __name__ == "__main__":
    main()
