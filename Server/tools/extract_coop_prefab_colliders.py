"""Inventory colliders on battle prefabs referenced by MainScene.

These are prefab-local shapes, not placed or animated world hitboxes. The
Client's ObjectPoolDatabase and NetworkObjectPool supply the prefab identities
that co-op can instantiate. This inventory cannot authorize a projectile hit.
"""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_coop_scene_colliders import (
    KINDS, collider_properties, game_object_transform,
)
from extract_army_spawn_points import field, ref, vec
from extract_coop_spawn_points import world_rotation


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
MAIN_SCENE = ASSETS / "Scenes/MainScene.unity"
OUTPUT = ROOT / "Server/content/recovered-coop-prefab-colliders.json"
MAIN_SCENE_SHA256 = (
    "d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43"
)
POOL_COMPONENT_ID = 42820
POOL_SCRIPT_GUID = "bcf5e36ab10fbce9d15bf2e7996900a0"
NETWORK_COMPONENT_ID = 49549
NETWORK_SCRIPT_GUID = "edeb0caaa8af89e2e298e1f4b64245cc"
FIELDS = (
    "enemy", "drone", "humvee", "buggy", "transporter", "helicopter",
    "tank", "turret", "turretRockets", "mech", "heavyTurret",
    "assaultHelicopter", "decoy", "miniDrone", "player", "shootableBox",
    "parachute",
)
NETWORK_NAMES = (
    "enemy", "dronePrototype", "GrenadeAmmoEnemy", "Humvee", "PlayerPrefab",
    "MineAmmo", "KillStreakBonusBox", "Turret", "parachute", "Helicopter",
    "Missile", "AssaultRifleEnemy", "BazookaEnemy", "ShotgunEnemy",
    "SniperRifleEnemy", "SwatPistolEnemy", "GrenadeEnemy", "Tank",
    "MiniGun", "assaultHelicopter", "PistolEnemy", "GrenadeLauncherEnemy",
    "Buggy", "Transporter", "TurretRockets", "HeavyTurret", "Decoy",
    "miniDrone", "MortarEnemy", "FlamethrowerEnemy", "Mech",
)
PREFAB_KINDS = {**KINDS, 135: "SphereCollider"}
EXPECTED_SHAPES = (8, 78, 31, 11)  # mesh, box, capsule, sphere


def blocks_in(path):
    source = path.read_bytes()
    blocks = {int(match.group(2)): (int(match.group(1)), match.group(3))
              for match in re.finditer(
                  r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
                  source.decode("utf-8-sig"), re.M | re.S)}
    return source, blocks


def prefab_paths():
    paths = {}
    for meta in (ASSETS / "GameObject").glob("*.prefab.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$",
                          meta.read_text(encoding="utf-8-sig"), re.M)
        if not match or match.group(1) in paths:
            raise ValueError(f"invalid prefab GUID: {meta}")
        paths[match.group(1)] = meta.with_suffix("")
    return paths


def pool_references(blocks):
    kind, component = blocks[POOL_COMPONENT_ID]
    if kind != 114 or POOL_SCRIPT_GUID not in field(component, "m_Script"):
        raise ValueError("MainScene battle prefab pool changed")
    references = []
    for name in FIELDS:
        value = field(component, name)
        match = re.fullmatch(
            r"\{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}", value)
        if not match:
            raise ValueError(f"unresolved battle prefab {name}")
        references.append((name, int(match.group(1)), match.group(2)))
    return references


def network_references(blocks):
    kind, component = blocks[NETWORK_COMPONENT_ID]
    if kind != 114 or NETWORK_SCRIPT_GUID not in field(component, "m_Script"):
        raise ValueError("MainScene network object pool changed")
    matches = re.findall(
        r"^  - Name: ([^\r\n]+)\r?\n"
        r"    Prefab: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}",
        component, re.M)
    if tuple(name for name, _, _ in matches) != NETWORK_NAMES:
        raise ValueError("MainScene network prefab order changed")
    return [(name, int(component_id), guid)
            for name, component_id, guid in matches]


def prefab_colliders(name, component_id, guid, path):
    raw, blocks = blocks_in(path)
    if component_id not in blocks or blocks[component_id][0] != 114:
        raise ValueError(f"missing pooled component: {name}")
    rows = []
    for collider_id, (kind, component) in blocks.items():
        if kind not in PREFAB_KINDS:
            continue
        game_object_id, game_object, transform_id, chain, position = \
            game_object_transform(blocks, component)
        active = field(game_object, "m_IsActive")
        enabled = field(component, "m_Enabled")
        trigger = field(component, "m_IsTrigger")
        if active not in ("0", "1") or enabled not in ("0", "1") or \
                trigger not in ("0", "1"):
            raise ValueError(f"invalid collider flags: {name}/{collider_id}")
        layer = int(field(game_object, "m_Layer"))
        if layer < 0 or layer > 31:
            raise ValueError(f"invalid collider layer: {name}/{collider_id}")
        active_in_hierarchy = all(
            field(blocks[ref(blocks[item["fileId"]][1],
                             "m_GameObject")][1], "m_IsActive") == "1"
            for item in chain)
        rows.append({
            "componentFileId": collider_id,
            "componentType": PREFAB_KINDS[kind],
            "gameObjectFileId": game_object_id,
            "transformFileId": transform_id,
            "gameObjectName": field(game_object, "m_Name"),
            "layer": layer,
            "active": active == "1",
            "activeInHierarchy": active_in_hierarchy,
            "enabled": enabled == "1",
            "trigger": trigger == "1",
            "transformChain": chain,
            "worldPosition": position,
            "worldRotation": world_rotation(chain),
            "shape": {"radius": float(field(component, "m_Radius")),
                      "center": vec(field(component, "m_Center"))}
            if kind == 135 else collider_properties(kind, component),
        })
    rows.sort(key=lambda row: row["componentFileId"])
    wheel_count = sum(kind == 146 for kind, _ in blocks.values())
    return {
        "poolField": name,
        "guid": guid,
        "pooledComponentFileId": component_id,
        "source": path.relative_to(ROOT / "Clients/ExportedProject").as_posix(),
        "sourceSha256": hashlib.sha256(raw).hexdigest(),
        "colliders": rows,
        "wheelColliderCount": wheel_count,
    }


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_prefab_colliders.py [--check]")
    scene, blocks = blocks_in(MAIN_SCENE)
    if hashlib.sha256(scene).hexdigest() != MAIN_SCENE_SHA256:
        raise ValueError("MainScene changed")
    paths = prefab_paths()
    prefabs = []
    selected_guids = set()
    for name, component_id, guid in pool_references(blocks):
        path = paths.get(guid)
        if path is None:
            raise ValueError(f"missing battle prefab {name}/{guid}")
        prefabs.append(prefab_colliders(name, component_id, guid, path))
        selected_guids.add(guid)
    network_entries = []
    for name, component_id, guid in network_references(blocks):
        path = paths.get(guid)
        if path is None:
            raise ValueError(f"missing network prefab {name}/{guid}")
        if guid not in selected_guids:
            prefabs.append(prefab_colliders(
                "network:" + name, component_id, guid, path))
            selected_guids.add(guid)
        selected = next(prefab for prefab in prefabs
                        if prefab["guid"] == guid)
        if selected["pooledComponentFileId"] != component_id:
            raise ValueError(f"pooled component differs: {name}")
        network_entries.append({"name": name, "guid": guid,
                                "pooledComponentFileId": component_id,
                                "prefabField": selected["poolField"]})
    counts = tuple(sum(row["componentType"] == PREFAB_KINDS[kind]
                       for prefab in prefabs for row in prefab["colliders"])
                   for kind in PREFAB_KINDS)
    wheel_count = sum(prefab["wheelColliderCount"] for prefab in prefabs)
    if len(prefabs) != 32 or counts != EXPECTED_SHAPES or wheel_count != 14:
        raise ValueError(f"battle prefab collider set changed: {counts}")
    artifact = {"version": 1, "mainSceneSha256": MAIN_SCENE_SHA256,
                "prefabs": prefabs, "networkEntries": network_entries}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode("utf-8")
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("battle prefab colliders differ from source")
    else:
        OUTPUT.write_bytes(encoded)
    print(f"{len(prefabs)} prefabs, {sum(counts)} colliders "
          f"(mesh={counts[0]}, box={counts[1]}, capsule={counts[2]}, "
          f"sphere={counts[3]}); {wheel_count} vehicle WheelColliders")


if __name__ == "__main__":
    main()
