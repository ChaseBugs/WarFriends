"""Pin the ordinary Mortar prefab before sharing the straight missile collision/explosion path."""

import hashlib
import json
import re
import struct
import sys
from pathlib import Path

from extract_rusher_weapon_bindings import yaml

ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/recovered-mortar-weapon.json"


def scalar(block, name):
    return float(re.search(rf"^  {name}: ([-0-9.]+)$", block, re.M)[1])


def obscured(block, name):
    value = re.search(rf"^  {name}:\n((?:    .*\n)+)", block, re.M)[1]
    key = int(re.search(r"currentCryptoKey: (\d+)", value)[1])
    hidden = bytes.fromhex(re.search(r"hiddenValue: ([0-9a-f]+)", value)[1])
    decoded = struct.unpack("<f", struct.pack("<I", struct.unpack("<I", hidden)[0] ^ key))[0]
    if decoded != float(re.search(r"fakeValue: ([-0-9.]+)", value)[1]):
        raise ValueError("Mortar obscured field disagrees with its restored mirror")
    return decoded


def extract():
    path = CLIENT / "Assets/GameObject/MortarEnemy.prefab"
    _, blocks, _, _ = yaml(path)
    weapon = blocks[11496012]
    setup = blocks[11469566]
    if "guid: 9cdb9d73ab5c07e53add3ece16e9f208" not in weapon:
        raise ValueError("Mortar weapon script changed")
    if "guid: f03796e42ada0b04d780e337084293fc" not in setup:
        raise ValueError("Mortar missile setup script changed")
    owner = lambda block: re.search(r"^  m_GameObject: \{fileID: (\d+)\}$", block, re.M)[1]
    if owner(weapon) != owner(setup):
        raise ValueError("Mortar GetComponent setup is no longer on its weapon object")
    if "bulletPrefab: {fileID: 11431434, guid: 60be7eeb14f5a354c99c9ce23dbc5554, type: 2}" not in weapon:
        raise ValueError("Mortar physical missile prefab identity changed")
    if scalar(weapon, "weaponType") != 17 or scalar(weapon, "friendKill") != 0:
        raise ValueError("Mortar weapon kind or friendly-fire rule changed")
    policy = {
        "cadenceSeconds": obscured(weapon, "cadence"),
        "deadRadius": scalar(setup, "deadRadius"),
        "hurtRadius": scalar(setup, "hurtRadius"),
        "criticalProbability": obscured(setup, "criticalProbability"),
        "curvedTrajectory": bool(scalar(setup, "curvedTrajectory")),
        "friendKill": bool(scalar(weapon, "friendKill")),
        "missileType": int(scalar(setup, "missileType")),
        "shootOffset": [float(value) for value in re.search(
            r"^  shootOffset: \{x: ([-0-9.]+), y: ([-0-9.]+), z: ([-0-9.]+)\}$", weapon, re.M).groups()],
    }
    expected = {"cadenceSeconds": 2.0, "deadRadius": 0.8, "hurtRadius": 1.2,
                "criticalProbability": 0.0, "curvedTrajectory": False, "friendKill": False,
                "missileType": 2, "shootOffset": [0.0, 0.0, 0.0]}
    if policy != expected:
        raise ValueError("Mortar cannot use the reviewed straight missile blast policy")
    sources = []
    for relative in ["Assets/GameObject/MortarEnemy.prefab", "Assets/GameObject/Missile.prefab",
                     "Assets/Scripts/Assembly-CSharp/Mortar.cs",
                     "Assets/Scripts/Assembly-CSharp/SoldierBehaviourMortar.cs"]:
        sources.append({"source": relative, "sha256": hashlib.sha256((CLIENT / relative).read_bytes()).hexdigest()})
    return {"version": 1, "sources": sources, "weaponFileId": 11496012,
            "setupFileId": 11469566, "policy": policy}


def main():
    content = json.dumps(extract(), indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("Mortar weapon artifact differs from the recovered source")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8", newline="\n")
    else:
        raise ValueError("usage: extract_mortar_weapon.py [--check]")
    print("Verified ordinary Mortar cadence, straight flight, friendly-fire and explosion source")


if __name__ == "__main__":
    main()
