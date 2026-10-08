"""Pin native collider components in the five recovered co-op scenes.

This records source identities and transforms. Mesh triangles and prefab-owned
colliders require a separate Unity geometry export before host raycasts open.
"""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_army_spawn_points import field, ref, transform_chain, vec
from extract_coop_spawn_points import world_rotation


ROOT = Path(__file__).resolve().parents[2]
SCENES = ROOT / "Clients/ExportedProject/Assets/Scenes"
MISSIONS = ROOT / "Server/content/recovered-mission-catalog.json"
OUTPUT = ROOT / "Server/content/recovered-coop-scene-colliders.json"
KINDS = {64: "MeshCollider", 65: "BoxCollider", 136: "CapsuleCollider"}
EXPECTED_COUNTS = [(82, 24, 0), (158, 41, 2), (191, 28, 0),
                   (84, 23, 0), (139, 23, 0)]


def game_object_transform(blocks, component):
    game_object_id = ref(component, "m_GameObject")
    game_object = blocks[game_object_id][1]
    transform_ids = [int(value) for value in re.findall(
        r"^  - 4: \{fileID: (\d+)\}$", game_object, re.M)]
    if len(transform_ids) != 1:
        raise ValueError("collider has no unique source Transform")
    transform_id = transform_ids[0]
    chain, position = transform_chain(blocks, transform_id)
    return game_object_id, game_object, transform_id, chain, position


def collider_properties(kind, component):
    if kind == 64:
        mesh = field(component, "m_Mesh")
        if mesh == "{fileID: 0}":
            return {"meshFileId": 0, "meshGuid": "",
                    "convex": field(component, "m_Convex") == "1"}
        match = re.fullmatch(
            r"\{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}", mesh)
        if not match or int(match.group(1)) <= 0:
            raise ValueError(f"unresolved co-op MeshCollider asset: {mesh}")
        return {"meshFileId": int(match.group(1)),
                "meshGuid": match.group(2),
                "convex": field(component, "m_Convex") == "1"}
    if kind == 65:
        return {"size": vec(field(component, "m_Size")),
                "center": vec(field(component, "m_Center"))}
    return {"radius": float(field(component, "m_Radius")),
            "height": float(field(component, "m_Height")),
            "direction": int(field(component, "m_Direction")),
            "center": vec(field(component, "m_Center"))}


def extract_map(source, expected_counts):
    path = SCENES / f"{source['scene']}.unity"
    raw = path.read_bytes()
    digest = hashlib.sha256(raw).hexdigest()
    if digest != source["sceneSha256"]:
        raise ValueError(f"co-op scene changed: {path}")
    scene = raw.decode("utf-8-sig")
    blocks = {int(match.group(2)): (int(match.group(1)), match.group(3))
              for match in re.finditer(
                  r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
                  scene, re.M | re.S)}

    colliders = []
    counts = {kind: 0 for kind in KINDS}
    for component_id, (kind, component) in blocks.items():
        if kind not in KINDS:
            continue
        counts[kind] += 1
        game_object_id, game_object, transform_id, chain, position = \
            game_object_transform(blocks, component)
        layer = int(field(game_object, "m_Layer"))
        if layer < 0 or layer > 31:
            raise ValueError("invalid source collider layer")
        if field(component, "m_IsTrigger") not in ("0", "1") or \
                field(component, "m_Enabled") not in ("0", "1") or \
                field(game_object, "m_IsActive") not in ("0", "1"):
            raise ValueError("invalid source collider flags")
        colliders.append({
            "componentFileId": component_id,
            "componentType": KINDS[kind],
            "gameObjectFileId": game_object_id,
            "transformFileId": transform_id,
            "gameObjectName": field(game_object, "m_Name"),
            "layer": layer,
            "active": field(game_object, "m_IsActive") == "1",
            "enabled": field(component, "m_Enabled") == "1",
            "trigger": field(component, "m_IsTrigger") == "1",
            "transformChain": chain,
            "worldPosition": position,
            "worldRotation": world_rotation(chain),
            "shape": collider_properties(kind, component),
        })
    if tuple(counts[kind] for kind in KINDS) != expected_counts:
        raise ValueError(f"co-op collider count changed: {source['scene']}")
    colliders.sort(key=lambda row: row["componentFileId"])
    return {"stage": source["stage"], "scene": source["scene"],
            "sceneSha256": digest, "colliders": colliders}


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_scene_colliders.py [--check]")
    missions = json.loads(MISSIONS.read_text(encoding="utf-8"))
    if len(missions["maps"]) != 5:
        raise ValueError("co-op mission maps are incomplete")
    maps = [extract_map(source, expected) for source, expected in
            zip(missions["maps"], EXPECTED_COUNTS)]
    artifact = {"version": 1, "maps": maps}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode("utf-8")
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("co-op colliders differ from the source scenes")
    else:
        OUTPUT.write_bytes(encoded)
    print(f"{len(maps)} maps, {sum(len(m['colliders']) for m in maps)} native colliders")


if __name__ == "__main__":
    main()
