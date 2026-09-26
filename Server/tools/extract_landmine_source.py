"""Pin recovered CardLandmine placement, damage, setup and prefab geometry."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-landmine-source.json"
MAP_GUID = "f8e8488fbe21f6c02c9eef456d27a3b9"
COLLECTION_GUID = "d9d8bf95b76e06b83a10740c1390212a"
OBSTACLE_GUID = "16b7423177a72a3f59048b96d341591a"
MINE_GUID = "bc63942edc4d8fb6eceee580f78d8393"
SETUP_GUID = "592c913164fe3881621d6359f20bf5d0"
MINE_AMMO_GUID = "0fb516b487dca711c841df6b4e3aa402"


def blocks(text):
    return {int(m.group(2)): (int(m.group(1)), m.group(3)) for m in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", text, re.M | re.S)}


def field(block, name):
    match = re.search(r"^  " + re.escape(name) + r": (.+)$", block, re.M)
    if not match:
        raise ValueError(f"missing {name}")
    return match.group(1)


def ref(block, name):
    return int(re.search(r"\{fileID: (\d+)", field(block, name)).group(1))


def vec(value):
    return [float(v) for _, v in re.findall(
        r"([xyzw]): (-?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?)", value)]


def mul(a, b):
    x, y, z, w = a; X, Y, Z, W = b
    return [w*X+x*W+y*Z-z*Y, w*Y-x*Z+y*W+z*X,
            w*Z+x*Y-y*X+z*W, w*W-x*X-y*Y-z*Z]


def rotate(q, p):
    return mul(mul(q, [*p, 0]), [-q[0], -q[1], -q[2], q[3]])[:3]


def world(source, transform_id):
    chain = []
    while transform_id:
        transform = source[transform_id][1]
        chain.append((vec(field(transform, "m_LocalPosition")),
                      vec(field(transform, "m_LocalRotation")),
                      vec(field(transform, "m_LocalScale"))))
        transform_id = ref(transform, "m_Father")
        if len(chain) > 32:
            raise ValueError("cyclic transform")
    position = [0.0, 0.0, 0.0]; rotation = [0.0, 0.0, 0.0, 1.0]; scale = [1.0, 1.0, 1.0]
    for local_position, local_rotation, local_scale in reversed(chain):
        offset = rotate(rotation, [a*b for a, b in zip(local_position, scale)])
        position = [a+b for a, b in zip(position, offset)]
        rotation = mul(rotation, local_rotation)
        scale = [a*b for a, b in zip(scale, local_scale)]
    if not all(math.isfinite(x) and abs(x) < 10000 for x in position):
        raise ValueError("invalid world position")
    return position


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def game_object_transform(source, game_object_id):
    game_object = source[game_object_id][1]
    match = re.search(r"^  - 4: \{fileID: (\d+)\}$", game_object, re.M)
    if not match:
        raise ValueError("missing GameObject transform")
    return int(match.group(1))


def extract_map(row):
    path = ROOT / "Clients/ExportedProject" / row["source"]
    if digest(path) != row["sha256"]:
        raise ValueError(f"map changed: {path}")
    source = blocks(path.read_text(encoding="utf-8-sig"))
    map_ids = [i for i, (kind, block) in source.items()
               if kind == 114 and f"guid: {MAP_GUID}" in block]
    if len(map_ids) != 1:
        raise ValueError("expected one MapDefinition")
    collection_id = ref(source[map_ids[0]][1], "enemyPointsCollection")
    collection = source[collection_id][1]
    if f"guid: {COLLECTION_GUID}" not in collection:
        raise ValueError("wrong EnemyPointsCollection")
    refs = [int(v) for v in re.findall(r"^  - \{fileID: (\d+)\}$",
        collection.split("  enemyPoints:\n", 1)[1], re.M)]
    slots = []
    for order, component_id in enumerate(refs):
        component = source[component_id][1]
        if f"guid: {OBSTACLE_GUID}" not in component:
            continue
        fraction = int(field(component, "mFraction"))
        if fraction not in (1, 2):
            raise ValueError("invalid hiding fraction")
        game_object_id = ref(component, "m_GameObject")
        transform_id = game_object_transform(source, game_object_id)
        slots.append({"order": order, "componentFileId": component_id,
                      "gameObjectFileId": game_object_id, "transformFileId": transform_id,
                      "fraction": fraction, "sourcePosition": world(source, transform_id)})
    if not slots or len({x["componentFileId"] for x in slots}) != len(slots):
        raise ValueError("missing or duplicate hiding slots")
    return {"source": row["source"], "sha256": row["sha256"],
            "mapDefinitionFileId": map_ids[0], "enemyPointsCollectionFileId": collection_id,
            "slots": slots}


def setup_number(block, name):
    value = field(block, name)
    if value.startswith("{"):
        raise ValueError(f"expected scalar {name}")
    result = float(value)
    if not math.isfinite(result):
        raise ValueError(f"invalid {name}")
    return result


def extract_main_scene(expected_digest):
    path = ASSETS / "Scenes/MainScene.unity"
    if digest(path) != expected_digest:
        raise ValueError("MainScene changed")
    source = blocks(path.read_text(encoding="utf-8-sig"))
    mines = [(i, block) for i, (kind, block) in source.items()
             if kind == 114 and f"guid: {MINE_GUID}" in block]
    if len(mines) != 2:
        raise ValueError("expected two player Mine weapons")
    rows = []
    for mine_id, mine in mines:
        game_object_id = ref(mine, "m_GameObject")
        setups = [(i, block) for i, (kind, block) in source.items()
                  if kind == 114 and ref(block, "m_GameObject") == game_object_id and f"guid: {SETUP_GUID}" in block]
        if len(setups) != 1 or "guid: d03fef98011553c4caa7125e1bba22a3" not in field(mine, "bulletPrefab"):
            raise ValueError("invalid Mine weapon graph")
        setup_id, setup = setups[0]
        rows.append({"weaponComponentFileId": mine_id, "setupComponentFileId": setup_id,
                     "gameObjectFileId": game_object_id, "radius": setup_number(setup, "radius"),
                     "hurtRadius": setup_number(setup, "hurtRadius"), "deadRadius": setup_number(setup, "deadRadius"),
                     "explosionCoefficient": vec(field(setup, "exposionCoef")),
                     "additionalUpForce": setup_number(setup, "additionalUpForce"),
                     "explodeAfterTime": setup_number(setup, "explodeAfterTime")})
    comparable = [{k: v for k, v in row.items() if not k.endswith("FileId")} for row in rows]
    if comparable[0] != comparable[1]:
        raise ValueError("player Mine setups disagree")
    return {"source": "Assets/Scenes/MainScene.unity", "sha256": expected_digest,
            "playerWeapons": rows}


def extract_prefab():
    path = ASSETS / "GameObject/MineAmmo.prefab"
    source = blocks(path.read_text(encoding="utf-8-sig"))
    roots = [i for i, (kind, block) in source.items() if kind == 4 and ref(block, "m_Father") == 0]
    ammo = [(i, block) for i, (kind, block) in source.items()
            if kind == 114 and f"guid: {MINE_AMMO_GUID}" in block]
    triggers = [(i, block) for i, (kind, block) in source.items()
                if kind == 65 and bool(int(field(block, "m_IsTrigger")))]
    meshes = [(i, block) for i, (kind, block) in source.items() if kind == 33]
    if len(roots) != 1 or len(ammo) != 1 or len(triggers) != 1 or len(meshes) != 1:
        raise ValueError("MineAmmo prefab graph changed")
    trigger_id, trigger = triggers[0]; mesh_id, mesh = meshes[0]
    mesh_go = ref(mesh, "m_GameObject"); mesh_transform = game_object_transform(source, mesh_go)
    return {"source": "Assets/GameObject/MineAmmo.prefab", "sha256": digest(path),
            "rootTransformFileId": roots[0], "ammoComponentFileId": ammo[0][0],
            "trigger": {"componentFileId": trigger_id, "center": vec(field(trigger, "m_Center")),
                        "size": vec(field(trigger, "m_Size"))},
            "mesh": {"componentFileId": mesh_id, "transformFileId": mesh_transform,
                     "localPosition": world(source, mesh_transform), "asset": field(mesh, "m_Mesh")}}


def main():
    content = json.loads(CONTENT.read_text(encoding="utf-8"))
    constants = {}
    for sheet in content["sheets"]:
        for row in sheet["rows"]:
            if row.get("DBKEY") in ("LandMineDamageMin", "LandMineDamageMax"):
                constants[row["DBKEY"]] = row["FLOATVALUE"]
    if constants.keys() != {"LandMineDamageMin", "LandMineDamageMax"}:
        raise ValueError("missing Land Mine damage constants")
    artifact = {"version": 1, "client": "1.4.0", "spawnLimit": 3,
                "navMeshSampleRadius": 10.0, "navMeshAreaMask": 1,
                "damage": {"minimum": constants["LandMineDamageMin"],
                           "maximum": constants["LandMineDamageMax"], "cardScale": 0.1,
                           "playerRadiusCoefficient": 0.9},
                "mainScene": extract_main_scene(content["mainSceneSha256"]),
                "prefab": extract_prefab(), "maps": [extract_map(row) for row in content["maps"]]}
    serialized = json.dumps(artifact, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != serialized:
            raise ValueError("Land Mine source artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(serialized, encoding="utf-8")
    else:
        raise ValueError("usage: extract_landmine_source.py [--check]")
    print(f"{len(artifact['maps'])} maps, {sum(len(x['slots']) for x in artifact['maps'])} Land Mine hiding slots")


if __name__ == "__main__":
    main()
