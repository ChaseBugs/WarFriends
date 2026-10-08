"""Pin the recovered co-op Assaulter's primary rifle and cadence sources."""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_rusher_weapon_bindings import yaml


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCENE = ASSETS / "Scenes/MainScene.unity"
PREFAB = ASSETS / "GameObject/AssaultRifleEnemy.prefab"
SOLDIER = ASSETS / "Scripts/Assembly-CSharp/SoldierBehaviour.cs"
GUN = ASSETS / "Scripts/Assembly-CSharp/Gun.cs"
OUTPUT = ROOT / "Server/content/recovered-coop-assaulter-weapon.json"


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def require(pattern, source, description):
    match = re.search(pattern, source, re.M)
    if match is None:
        raise ValueError(f"missing recovered {description}")
    return match


def main():
    _, scene_blocks, _, _ = yaml(SCENE)
    behaviour = scene_blocks[35664]
    inventory = scene_blocks[42740]
    if ("m_GameObject: {fileID: 4849}" not in behaviour or
            "unitDictionaryId: ID_UNIT-ASSAULT" not in behaviour or
            "m_GameObject: {fileID: 4849}" not in inventory):
        raise ValueError("Assaulter behavior and inventory lost their source owner")
    weapon = require(
        r"^  weapons:\n  - weapon: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}"
        r"\n    type: (\d+)\n    leftHand: ([01])$",
        inventory, "Assaulter inventory weapon")
    card = require(
        r"^  cardWeapons:\n  - weapon: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}"
        r"\n    type: (\d+)\n    leftHand: ([01])$",
        inventory, "Assaulter card weapon")
    if weapon.groups() != card.groups() or weapon.groups() != (
            "11470521", "d03f97fa25701ab42ab60f1fa86421ce", "0", "0"):
        raise ValueError("Assaulter primary/card rifle identity changed")
    prefab_meta = PREFAB.with_suffix(PREFAB.suffix + ".meta").read_text()
    if "guid: " + weapon.group(2) not in prefab_meta:
        raise ValueError("Assaulter rifle GUID no longer resolves")

    _, prefab_blocks, _, _ = yaml(PREFAB)
    rifle = prefab_blocks[int(weapon.group(1))]
    if ("weaponType: 0" not in rifle or
            "infiniteAmmo: 1" not in rifle or
            "reloadableWeapon: 0" not in rifle):
        raise ValueError("Assaulter rifle firing mode changed")
    cadence = float(require(
        r"^  cadence:\n(?:    .*\n)*?    fakeValue: ([0-9.]+)$",
        rifle, "rifle cadence").group(1))
    if cadence != 0.35:
        raise ValueError("Assaulter rifle cadence changed")
    spawn = int(require(r"^  spawnPoint: \{fileID: (\d+)\}$",
                        rifle, "rifle muzzle").group(1))
    bullet = require(
        r"^  bulletPrefab: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}$",
        rifle, "rifle projectile")
    if (spawn != 455190 or
            bullet.groups() != ("11409266", "855689762fa6e774aaee190652b08c6f")):
        raise ValueError("Assaulter rifle muzzle or projectile changed")
    if ".cadence = 0.35f;" not in SOLDIER.read_text(encoding="utf-8-sig"):
        raise ValueError("Assaulter setup no longer fixes rifle cadence")
    if ("TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)cadence"
            not in GUN.read_text(encoding="utf-8-sig")):
        raise ValueError("Gun cadence comparison changed")

    artifact = {
        "version": 1,
        "unitId": "ID_UNIT-ASSAULT",
        "sceneSha256": digest(SCENE),
        "behaviourComponentFileId": 35664,
        "inventoryComponentFileId": 42740,
        "weaponPrefab": "Assets/GameObject/AssaultRifleEnemy.prefab",
        "weaponPrefabSha256": digest(PREFAB),
        "weaponPrefabGuid": weapon.group(2),
        "weaponComponentFileId": int(weapon.group(1)),
        "weaponType": 0,
        "muzzleTransformFileId": spawn,
        "bulletPrefabGuid": bullet.group(2),
        "bulletComponentFileId": int(bullet.group(1)),
        "cadenceSeconds": cadence,
        "infiniteAmmo": True,
        "reloadableWeapon": False,
        "soldierSourceSha256": digest(SOLDIER),
        "gunSourceSha256": digest(GUN),
    }
    content = json.dumps(artifact, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("co-op Assaulter weapon artifact differs from sources")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8")
    else:
        raise ValueError("usage: extract_coop_assaulter_weapon.py [--check]")
    print("co-op Assaulter primary/card rifle binding pinned")


if __name__ == "__main__":
    main()
