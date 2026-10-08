"""Pin the recovered co-op Assaulter's primary rifle and cadence sources."""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_rusher_weapon_bindings import relative, yaml


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCENE = ASSETS / "Scenes/MainScene.unity"
PREFAB = ASSETS / "GameObject/AssaultRifleEnemy.prefab"
SOLDIER = ASSETS / "Scripts/Assembly-CSharp/SoldierBehaviour.cs"
GUN = ASSETS / "Scripts/Assembly-CSharp/Gun.cs"
BULLET = ASSETS / "GameObject/BulletSlow.prefab"
BASE_BULLET = ASSETS / "Scripts/Assembly-CSharp/BulletBase.cs"
BULLET_SETUP = ASSETS / "Scripts/Assembly-CSharp/BulletSetup.cs"
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

    _, prefab_blocks, prefab_names, prefab_transforms = yaml(PREFAB)
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
    if "fastBullet: 0" not in rifle or spawn not in prefab_transforms:
        raise ValueError("Assaulter rifle firing geometry changed")
    shot_offset = require(
        r"^  shotOffset: \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}$",
        rifle, "rifle shot offset")
    shot_offset_values = [float(value) for value in shot_offset.groups()]
    if shot_offset_values != [0.0, 0.0, 0.0]:
        raise ValueError("Assaulter rifle shot offset changed")
    muzzle = relative(spawn, prefab_transforms, prefab_names, True)
    setup = prefab_blocks[11496012]
    if "m_GameObject: {fileID: 147589}" not in setup:
        raise ValueError("Assaulter BulletSetup lost the rifle owner")
    def setup_number(name):
        return float(require(rf"^  {name}: ([0-9.]+)$", setup,
                             name).group(1))
    real_speed = setup_number("speed")
    check_distance = setup_number("checkDistance")
    fake_factor = setup_number("fakeSpeedFactor")
    if (real_speed, check_distance, fake_factor) != (5.0, 0.35, 1.5):
        raise ValueError("Assaulter BulletSetup flight values changed")
    bullet_meta = BULLET.with_suffix(BULLET.suffix + ".meta").read_text()
    if "guid: " + bullet.group(2) not in bullet_meta:
        raise ValueError("Assaulter bullet GUID no longer resolves")
    _, bullet_blocks, _, _ = yaml(BULLET)
    if "fast: 0" not in bullet_blocks[int(bullet.group(1))]:
        raise ValueError("Assaulter projectile changed from BulletSlow")
    if ".cadence = 0.35f;" not in SOLDIER.read_text(encoding="utf-8-sig"):
        raise ValueError("Assaulter setup no longer fixes rifle cadence")
    if ("TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)cadence"
            not in GUN.read_text(encoding="utf-8-sig")):
        raise ValueError("Gun cadence comparison changed")
    if "spawnPoint.transform.position + shotOffset" not in GUN.read_text(
            encoding="utf-8-sig"):
        raise ValueError("Gun launch origin changed")
    bullet_source = BASE_BULLET.read_text(encoding="utf-8-sig")
    if ("speed = bulletSetup.bulletSpeed;" not in bullet_source or
            "distanceToCheck = bulletSetup.checkDistance;" not in bullet_source or
            "mBulletSetup.fakeSpeed" not in bullet_source):
        raise ValueError("BulletBase setup override changed")
    if ("public float fakeSpeed => speed * fakeSpeedFactor;" not in
            BULLET_SETUP.read_text(encoding="utf-8-sig")):
        raise ValueError("BulletSetup fake-speed rule changed")

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
        "muzzle": muzzle,
        "shotOffset": shot_offset_values,
        "bulletPrefabGuid": bullet.group(2),
        "bulletComponentFileId": int(bullet.group(1)),
        "bulletPrefabSha256": digest(BULLET),
        "bulletSetupComponentFileId": 11496012,
        "realBulletSpeed": real_speed,
        "fakeBulletSpeed": real_speed * fake_factor,
        "collisionCheckDistance": check_distance,
        "cadenceSeconds": cadence,
        "infiniteAmmo": True,
        "reloadableWeapon": False,
        "soldierSourceSha256": digest(SOLDIER),
        "gunSourceSha256": digest(GUN),
        "bulletBaseSourceSha256": digest(BASE_BULLET),
        "bulletSetupSourceSha256": digest(BULLET_SETUP),
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
