"""Export the selected Grenadier pistol setup without merging unrelated prefab components."""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_rusher_weapon_bindings import qrotate, relative, yaml

ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/recovered-grenadier-primary-weapon.json"


def scalar(block, name):
    matches = re.findall(rf"^  {name}: ([-0-9.]+)$", block, re.M)
    if len(matches) != 1:
        raise ValueError(f"Expected one {name} in the selected component")
    return float(matches[0])


def export():
    scene_path = CLIENT / "Assets/Scenes/MainScene.unity"
    _, scene, _, _ = yaml(scene_path)
    inventory = scene[41066]
    behavior_meta = CLIENT / "Assets/Scripts/Assembly-CSharp/SoldierBehaviourGrennader.cs.meta"
    behavior_guid = re.search(r"^guid: ([0-9a-f]{32})$", behavior_meta.read_text(), re.M)[1]
    behaviors = [block for block in scene.values()
                 if f"m_Script: {{fileID: 11500000, guid: {behavior_guid}, type: 3}}" in block]
    inventory_owner = re.search(r"^  m_GameObject: \{fileID: (\d+)\}$", inventory, re.M)[1]
    if len(behaviors) != 1 or f"m_GameObject: {{fileID: {inventory_owner}}}" not in behaviors[0]:
        raise ValueError("Inventory is no longer attached to the source Grenadier behavior")
    inventories = []
    for name in ("weapons", "cardWeapons"):
        block = re.search(rf"^  {name}:\r?\n(.*?)(?=^  [a-zA-Z]|\Z)", inventory, re.M | re.S)
        if block is None:
            raise ValueError(f"Grenadier {name} is absent")
        inventories.append(re.findall(
            r"- weapon: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}\r?\n"
            r"    type: (\d+)\r?\n    leftHand: ([01])", block[1]))
    expected = [
        ("11431434", "16439357c0b8cbc4a91424818b10119d", "0", "0"),
        ("11419550", "bd74fc4b54938454a92a050c5517d60b", "1", "0"),
    ]
    if inventories != [expected, expected]:
        raise ValueError("Normal/card Grenadier weapon identities changed")

    pistol_path = CLIENT / "Assets/GameObject/PistolEnemy.prefab"
    _, pistol, names, transforms = yaml(pistol_path)
    gun = pistol[11431434]
    game_object = re.search(r"^  m_GameObject: \{fileID: (\d+)\}$", gun, re.M)[1]
    # Weapon.ammoSetup uses GetComponent, so nested visual/alternate setups are excluded.
    setups = [block for block in pistol.values()
              if f"  m_GameObject: {{fileID: {game_object}}}\n" in block
              and "  fakeSpeedFactor:" in block]
    if len(setups) != 1:
        raise ValueError("The primary weapon needs one same-GameObject BulletSetup")
    ammo = setups[0]
    spawn = int(re.search(r"^  spawnPoint: \{fileID: (\d+)\}$", gun, re.M)[1])
    if spawn != 434467 or scalar(gun, "fastBullet") != 0:
        raise ValueError("Primary spawn point or slow-bullet mode changed")
    if "  shotOffset: {x: 0, y: 0, z: 0}" not in gun:
        raise ValueError("Primary world-space shot offset changed")
    if "bulletPrefab: {fileID: 11409266, guid: 855689762fa6e774aaee190652b08c6f, type: 2}" not in gun:
        raise ValueError("Primary BulletSlow identity changed")
    weapon_spawn = relative(spawn, transforms, names, True)

    enemy_path = CLIENT / "Assets/GameObject/enemy.prefab"
    _, enemy, enemy_names, enemy_transforms = yaml(enemy_path)
    parts = next(block for block in enemy.values() if "gunSnapPointNotScaled:" in block)
    snap_id = int(re.search(r"gunSnapPointNotScaled: \{fileID: (\d+)\}", parts)[1])
    attachment = relative(snap_id, enemy_transforms, enemy_names)
    offset = qrotate(attachment["rotation"], weapon_spawn["position"])
    muzzle = [left + right for left, right in zip(attachment["position"], offset)]

    scripts = CLIENT / "Assets/Scripts/Assembly-CSharp"
    requirements = {
        "Weapon.cs": "mAmmoSetup = GetComponent<AmmoSetup>()",
        "Gun.cs": "ammo.LoadAmmoSetup(base.ammoSetup);",
        "BulletBase.cs": "speed = bulletSetup.bulletSpeed;",
        "BulletSlow.cs": "AnimateShot(from, to, checkCollision: false);",
        "BulletSetup.cs": "return speed * speedMultiplayer;",
        "SoldierBehaviour.cs": "mWeapons[0].cadence = 0.35f;",
        "SoldierBehaviourGrennader.cs": "mWeapons[0].bulletPrefab = Singleton<ObjectPoolDatabase>.instance.bulletSlow;",
    }
    for name, required in requirements.items():
        if required not in (scripts / name).read_text(encoding="utf-8-sig"):
            raise ValueError(f"Recovered runtime rule changed: {name}")
    bullet_path = CLIENT / "Assets/GameObject/BulletSlow.prefab"
    sources = [scene_path, pistol_path, enemy_path, bullet_path]
    sources.append(behavior_meta)
    for asset, expected_guid in [(pistol_path, expected[0][1]),
                                 (bullet_path, "855689762fa6e774aaee190652b08c6f")]:
        metadata = Path(str(asset) + ".meta")
        if re.search(r"^guid: ([0-9a-f]{32})$", metadata.read_text(), re.M)[1] != expected_guid:
            raise ValueError(f"Selected asset GUID changed: {asset.name}")
        sources.append(metadata)
    sources += [scripts / name for name in requirements]
    provenance = [{"path": path.relative_to(CLIENT).as_posix(),
                   "sha256": hashlib.sha256(path.read_bytes()).hexdigest()}
                  for path in sorted(sources)]
    return {
        "version": 1,
        "unitId": "ID_UNIT-GRENADIER",
        "inventoryComponent": 41066,
        "primaryWeaponComponent": 11431434,
        "primaryWeaponGuid": expected[0][1],
        "normalAndCardInventoryMatch": True,
        "sources": provenance,
        "gunAttachment": attachment,
        "weaponSpawn": weapon_spawn,
        "restMuzzlePosition": muzzle,
        "runtimeSpeed": scalar(ammo, "speed") * scalar(ammo, "speedMultiplayer"),
        "collisionCheckDistance": scalar(ammo, "checkDistance"),
        "fakeSpeed": scalar(ammo, "speed") * scalar(ammo, "fakeSpeedFactor"),
        "cadenceSeconds": 0.35,
        "poseScope": "resting right-hand rig; animated hand poses require separate Unity observation",
    }


def main():
    encoded = (json.dumps(export(), indent=2) + "\n").encode("utf-8")
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("Grenadier primary weapon artifact is stale")
    elif sys.argv[1:]:
        raise ValueError("Only --check is supported")
    else:
        OUTPUT.write_bytes(encoded)
    print(f"Grenadier primary weapon verified: {hashlib.sha256(encoded).hexdigest()}")


if __name__ == "__main__":
    main()
