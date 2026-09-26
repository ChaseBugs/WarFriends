"""Pin the recovered Decoy prefab, health constants, and multiplayer obstacle slots."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-decoy-source.json"
MAP_GUID = "f8e8488fbe21f6c02c9eef456d27a3b9"
COLLECTION_GUID = "d9d8bf95b76e06b83a10740c1390212a"
OBSTACLE_GUID = "16b7423177a72a3f59048b96d341591a"
SHOOTABLE_GUID = "3cf4d7761af3ce98d7a08bebfe4e8861"


def blocks(text):
    return {int(m.group(2)): (int(m.group(1)), m.group(3)) for m in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", text, re.M | re.S)}


def field(block, name):
    match = re.search(r"^  " + re.escape(name) + r": (.+)$", block, re.M)
    if not match:
        raise ValueError(f"missing {name}")
    return match.group(1)


def ref(block, name):
    return int(re.search(r"\{fileID: (\d+)\}", field(block, name)).group(1))


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
            raise ValueError("invalid obstacle fraction")
        start_id = ref(component, "obstacleStart"); end_id = ref(component, "obstacleEnd")
        start = world(source, start_id); end = world(source, end_id)
        midpoint = [(a+b)/2 for a, b in zip(start, end)]
        slots.append({"order": order, "componentFileId": component_id,
                      "gameObjectFileId": ref(component, "m_GameObject"), "fraction": fraction,
                      "startTransformFileId": start_id, "endTransformFileId": end_id,
                      "start": start, "end": end, "initialMidpoint": midpoint})
    if not slots or len({x["componentFileId"] for x in slots}) != len(slots):
        raise ValueError("missing or duplicate obstacle slots")
    return {"source": row["source"], "sha256": row["sha256"],
            "mapDefinitionFileId": map_ids[0], "enemyPointsCollectionFileId": collection_id,
            "slots": slots}


def extract_prefab():
    path = ASSETS / "GameObject/Decoy.prefab"
    source = blocks(path.read_text(encoding="utf-8-sig"))
    roots = [i for i, (kind, block) in source.items() if kind == 4 and ref(block, "m_Father") == 0]
    shootables = [(i, block) for i, (kind, block) in source.items()
                  if kind == 114 and f"guid: {SHOOTABLE_GUID}" in block]
    colliders = [(i, block) for i, (kind, block) in source.items() if kind == 65]
    if len(roots) != 1 or len(shootables) != 1 or len(colliders) != 1:
        raise ValueError("Decoy prefab graph changed")
    target_text = shootables[0][1].split("  targets:\n", 1)[1].split("  visible:", 1)[0]
    targets = [{"transformFileId": int(transform), "type": int(kind),
                "localPosition": world(source, int(transform))}
               for transform, kind in re.findall(
                   r"  - transform: \{fileID: (\d+)\}\r?\n    type: (\d+)", target_text)]
    collider_id, collider = colliders[0]
    return {"source": "Assets/GameObject/Decoy.prefab", "sha256": digest(path),
            "rootTransformFileId": roots[0], "shootableComponentFileId": shootables[0][0],
            "targets": targets, "collider": {"componentFileId": collider_id,
                "enabled": bool(int(field(collider, "m_Enabled"))),
                "trigger": bool(int(field(collider, "m_IsTrigger"))),
                "center": vec(field(collider, "m_Center")), "size": vec(field(collider, "m_Size"))}}


def main():
    content = json.loads(CONTENT.read_text(encoding="utf-8"))
    constants = {}
    for sheet in content["sheets"]:
        for row in sheet["rows"]:
            if row.get("DBKEY") in ("DecoyHpMin", "DecoyHpMax"):
                constants[row["DBKEY"]] = row["FLOATVALUE"]
    if constants.keys() != {"DecoyHpMin", "DecoyHpMax"}:
        raise ValueError("missing Decoy health constants")
    artifact = {"version": 1, "client": "1.4.0", "spawnCount": 3,
                "health": {"minimum": constants["DecoyHpMin"], "maximum": constants["DecoyHpMax"]},
                "prefab": extract_prefab(), "maps": [extract_map(row) for row in content["maps"]]}
    serialized = json.dumps(artifact, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != serialized:
            raise ValueError("Decoy source artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(serialized, encoding="utf-8")
    else:
        raise ValueError("usage: extract_decoy_source.py [--check]")
    print(f"{len(artifact['maps'])} maps, {sum(len(x['slots']) for x in artifact['maps'])} Decoy slots")


if __name__ == "__main__":
    main()
