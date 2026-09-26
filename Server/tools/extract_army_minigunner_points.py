"""Pin multiplayer EnemyPointMinigunner identities in SpawningManager list order."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path
from extract_army_spawn_points import field, ref, vec, mul, rotate

ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-army-minigunner-points.json"
MAP_GUID = "f8e8488fbe21f6c02c9eef456d27a3b9"
COLLECTION_GUID = "d9d8bf95b76e06b83a10740c1390212a"
MINIGUNNER_GUID = "1df87ce72e28356e404e85651544fcdf"


def extract(source_map):
    path = ROOT / "Clients/ExportedProject" / source_map["source"]
    data = path.read_bytes()
    digest = hashlib.sha256(data).hexdigest()
    if digest != source_map["sha256"]:
        raise ValueError(f"map changed: {path}")
    scene = data.decode("utf-8-sig")
    blocks = {int(m.group(2)): (int(m.group(1)), m.group(3)) for m in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", scene, re.M | re.S)}
    map_ids = [i for i, (kind, block) in blocks.items()
               if kind == 114 and f"guid: {MAP_GUID}" in block]
    if len(map_ids) != 1:
        raise ValueError("expected one MapDefinition")
    map_id = map_ids[0]
    collection_id = ref(blocks[map_id][1], "enemyPointsCollection")
    kind, collection = blocks[collection_id]
    if kind != 114 or f"guid: {COLLECTION_GUID}" not in collection:
        raise ValueError("MapDefinition has the wrong EnemyPointsCollection")
    match = re.search(r"^  enemyPoints:\r?\n((?:  - \{fileID: \d+\}\r?\n)+)", collection, re.M)
    if match is None:
        raise ValueError("enemy point list is missing")
    point_ids = [int(v) for v in re.findall(r"fileID: (\d+)", match.group(1))]
    if not 1 <= len(point_ids) <= 512 or 0 in point_ids or len(set(point_ids)) != len(point_ids):
        raise ValueError("invalid enemy point list")

    def world_position(component):
        game_object = blocks[ref(component, "m_GameObject")][1]
        transform_id = int(re.search(r"^  - 4: \{fileID: (\d+)\}$", game_object, re.M).group(1))
        chain = []
        current = transform_id
        while current:
            transform = blocks[current][1]
            chain.append({"position": vec(field(transform, "m_LocalPosition")),
                          "rotation": vec(field(transform, "m_LocalRotation")),
                          "scale": vec(field(transform, "m_LocalScale"))})
            current = ref(transform, "m_Father")
            if len(chain) > 32:
                raise ValueError("cyclic Minigunner point transform")
        position = [0.0, 0.0, 0.0]
        rotation = [0.0, 0.0, 0.0, 1.0]
        scale = [1.0, 1.0, 1.0]
        for transform in reversed(chain):
            local = [a*b for a, b in zip(transform["position"], scale)]
            position = [a+b for a, b in zip(position, rotate(rotation, local))]
            rotation = mul(rotation, transform["rotation"])
            scale = [a*b for a, b in zip(scale, transform["scale"])]
        if not all(math.isfinite(x) and abs(x) < 10000 for x in position):
            raise ValueError("invalid Minigunner point world position")
        return transform_id, position

    rows = []
    for order, point_id in enumerate(point_ids):
        kind, point = blocks[point_id]
        if kind != 114 or f"guid: {MINIGUNNER_GUID}" not in point:
            continue
        fraction = int(field(point, "mFraction"))
        if fraction not in (1, 2):
            raise ValueError("invalid Minigunner point faction")
        transform_id, position = world_position(point)
        rows.append({"order": order, "componentFileId": point_id,
                     "transformFileId": transform_id, "fraction": fraction,
                     "worldPosition": position})
    if len(rows) < 2 or {r["fraction"] for r in rows} != {1, 2}:
        raise ValueError("incomplete Minigunner point set")
    return {"source": source_map["source"], "sha256": digest,
            "mapDefinitionFileId": map_id, "enemyPointsCollectionFileId": collection_id,
            "points": rows}


def main():
    source = json.loads(SOURCE.read_text(encoding="utf-8"))
    maps = [extract(m) for m in source["maps"]]
    output = json.dumps({"version": 1, "maps": maps}, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != output:
            raise ValueError("army Minigunner point artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(output, encoding="utf-8")
    else:
        raise ValueError("usage: extract_army_minigunner_points.py [--check]")
    print(f"{len(maps)} maps, {sum(len(m['points']) for m in maps)} Minigunner points")


if __name__ == "__main__":
    main()
