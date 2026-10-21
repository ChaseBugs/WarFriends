"""Bind the Mortar weapon pool capacity to the recovered scene and reviewed allocation sources."""

import argparse
import hashlib
import json
import re
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/recovered-mortar-weapon-pool.json"
SCENE = "Assets/Scenes/MainScene.unity"
WEAPON = "Assets/GameObject/MortarEnemy.prefab"
NETWORK_POOL = "Assets/Scripts/Assembly-CSharp/NetworkObjectPool.cs"
SOURCES = (
    SCENE, WEAPON, NETWORK_POOL,
    "Assets/Scripts/Assembly-CSharp/ObjectPool.cs",
    "Assets/Scripts/Assembly-CSharp/SoldierParts.cs",
    "Assets/Scripts/Assembly-CSharp/EnemyBasicInventory.cs",
    "Assets/Scripts/Assembly-CSharp/SoldierBehaviour.cs",
    "Assets/Scripts/Assembly-CSharp/Mortar.cs",
    "Assets/Scripts/Assembly-CSharp/EnemyController.cs",
    "Assets/Scripts/Assembly-CSharp/AIObject.cs",
    "Assets/Scripts/Assembly-CSharp/MainGameEntity.cs",
    "Assets/Scripts/Assembly-CSharp/PoolableObject.cs",
    "Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
)


def read(path):
    return (CLIENT / path).read_text(encoding="utf-8-sig")


def guid(path):
    matches = re.findall(r"(?m)^guid: ([0-9a-f]{32})$", read(path + ".meta"))
    if len(matches) != 1:
        raise ValueError("Expected one source GUID: " + path)
    return matches[0]


def build_document(scene_bytes, army_bytes):
    scene_text = scene_bytes.decode("utf-8-sig").replace("\r\n", "\n")
    pool_guid = guid(NETWORK_POOL)
    weapon_guid = guid(WEAPON)
    candidates = []
    for block in re.finditer(r"(?ms)^--- !u!114 &(\d+)\n(.*?)(?=^--- !u!|\Z)", scene_text):
        payload = block.group(2)
        if "guid: " + pool_guid not in payload:
            continue
        entries = re.findall(r"(?ms)^  - Name: MortarEnemy\n(.*?)(?=^  - Name:|\Z)", payload)
        for entry in entries:
            reference = re.search(r"Prefab: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}", entry)
            count = re.search(r"(?m)^    Count: (\d+)$", entry)
            owner = re.search(r"m_GameObject: \{fileID: (\d+)\}", payload)
            if reference is None or count is None or owner is None or reference.group(2) != weapon_guid:
                raise ValueError("Mortar pool entry lost its source prefab/count identity")
            candidates.append((int(block.group(1)), int(owner.group(1)), int(reference.group(1)), int(count.group(1))))
    if len(candidates) != 1:
        raise ValueError("Expected one MainScene network Mortar pool entry")
    component, game_object, weapon_component, capacity = candidates[0]
    if not 1 <= capacity <= 256:
        raise ValueError("Mortar pool capacity exceeds the recovered byte-index domain")
    army = json.loads(army_bytes)
    if army["sceneSha256"] != hashlib.sha256(scene_bytes).hexdigest():
        raise ValueError("Mortar pool and deployment refer to different scenes")
    families = [row for row in army["families"] if row["unitId"] == "ID_UNIT-MORTAR"]
    if (len(families) != 1 or type(families[0]["maxGeneratedCount"]) is not int
            or families[0]["maxGeneratedCount"] * 2 != capacity):
        raise ValueError("Mortar deployment limits no longer conserve the shared two-player weapon pool")
    return {
        "schemaVersion": 2,
        "scene": SCENE,
        "poolComponentFileId": component,
        "poolGameObjectFileId": game_object,
        "poolScriptGuid": pool_guid,
        "weaponPrefab": WEAPON,
        "weaponPrefabGuid": weapon_guid,
        "weaponComponentFileId": weapon_component,
        "capacity": capacity,
        "deployment": {
            "revision": hashlib.sha256(army_bytes).hexdigest(),
            "sceneRevision": army["sceneSha256"],
            "behaviorFileId": families[0]["behaviorFileId"],
            "maxPerOwner": families[0]["maxGeneratedCount"],
        },
        "reviewedAllocation": {
            "initialOrder": "ascending",
            "master": "first-free",
            "peer": "last-free",
            "releasedSlot": "add-first",
        },
        "reviewedReturn": {
            "deathReturnsWeapon": False,
            "hideDelayMinimumSeconds": 2.0,
            "hideDelayMaximumSeconds": 3.0,
            "destroyDelayAfterHideSeconds": 1.0,
            "returnHook": (
                "EnemyController.DestroyPooled/"
                "SoldierBehaviour.DestroyBehaviour/EnemyBasicInventory.DestroyWeapons"
            ),
        },
        "sources": [
            {"source": path, "normalizedUtf8LfSha256": hashlib.sha256(
                (scene_text if path == SCENE else read(path)).encode("utf-8")).hexdigest()}
            for path in SOURCES
        ],
    }


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    arguments = parser.parse_args()
    document = build_document((CLIENT / SCENE).read_bytes(),
                              (ROOT / "Server/content/recovered-army-deployment.json").read_bytes())
    text = json.dumps(document, indent=2, allow_nan=False) + "\n"
    if arguments.check:
        if OUTPUT.read_text(encoding="utf-8") != text:
            raise ValueError("Recovered Mortar weapon pool changed; regenerate and review its source evidence")
        print("Mortar weapon pool source evidence matches.")
    else:
        OUTPUT.write_text(text, encoding="utf-8", newline="\n")
        print("Wrote " + str(OUTPUT.relative_to(ROOT)))


if __name__ == "__main__":
    main()
