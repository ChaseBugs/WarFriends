"""Decode MainScene PLAYERHP rows exactly as recovered ObscuredFloat does."""

import hashlib
import json
import math
import re
import struct
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
BOTS = ROOT / "Server/content/recovered-coop-bot-rules.json"
OUTPUT = ROOT / "Server/content/recovered-coop-bot-health.json"
BALANCE_GUID = "a18ba310bac702fc1509b91e7be7137c"


def binary32(value):
    return struct.unpack("<f", struct.pack("<f", value))[0]


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_bot_health.py [--check]")
    scene_bytes = SCENE.read_bytes()
    scene = scene_bytes.decode("utf-8-sig")
    blocks = [block for block in re.split(r"(?=^--- !u!)", scene, flags=re.M)
              if f"guid: {BALANCE_GUID}" in block and "  m_Script:" in block]
    if len(blocks) != 1:
        raise ValueError("MainScene needs one balance-table component")
    block = blocks[0]
    names = re.findall(r"^  - ROW_(\d+)$", block, re.M)
    encrypted = re.findall(
        r"^  - PLAYERHP:\n      currentCryptoKey: (\d+)\n"
        r"      hiddenValue: ([0-9a-f]{8})\n"
        r"      fakeValue: ([^\n]+)\n      inited: (\d+)$",
        block, re.M)
    if names != [str(index) for index in range(44)] or len(encrypted) != 44:
        raise ValueError("MainScene balance table is incomplete or unordered")

    health = []
    for index, (key, hidden, fake, inited) in enumerate(encrypted):
        if fake != "0" or inited != "1":
            raise ValueError(f"balance row {index} has an unexpected ObscuredFloat")
        # Recovered ObscuredFloat.InternalDecrypt XORs the little-endian
        # hidden integer with the per-value crypto key, then reads binary32.
        bits = int.from_bytes(bytes.fromhex(hidden), "little") ^ int(key)
        value = struct.unpack("<f", bits.to_bytes(4, "little"))[0]
        if not math.isfinite(value) or not 0 < value < 100_000:
            raise ValueError(f"balance row {index} has invalid player health")
        health.append(value)

    bots_bytes = BOTS.read_bytes()
    bots = json.loads(bots_bytes)
    if bots["missionSourceSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("boss rows differ from the balance-table scene")
    boss_health = []
    for row in bots["bots"]:
        level = row["bot"]["level"]
        multiplier = binary32(row["bot"]["hpReduction"])
        if not 0 <= level < len(health) or not math.isfinite(multiplier):
            raise ValueError("boss level or multiplier is invalid")
        boss_health.append({"missionIndex": row["missionIndex"],
                            "level": level,
                            "baseHealth": health[level],
                            "healthMultiplier": multiplier,
                            "maximumHealth": binary32(health[level] * multiplier)})

    artifact = {"version": 1,
                "sceneSha256": hashlib.sha256(scene_bytes).hexdigest(),
                "botRulesSha256": hashlib.sha256(bots_bytes).hexdigest(),
                "playerHealthByLevel": health,
                "bossHealth": boss_health}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("co-op boss health differs from recovered MainScene")
    else:
        OUTPUT.write_bytes(encoded)
    print("44 PLAYERHP rows and 15 boss health values pinned")


if __name__ == "__main__":
    main()
