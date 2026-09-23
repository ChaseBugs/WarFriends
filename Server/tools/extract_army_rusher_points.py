"""Pin each multiplayer PlayerPoint's four EnemyPointRusher references."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path
from extract_army_spawn_points import field, ref, vec, mul, rotate

ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-army-rusher-points.json"
MAP_GUID = "f8e8488fbe21f6c02c9eef456d27a3b9"
PLAYER_POINT_GUID = "8e9e336d4e9d43c6305ae38d9233296d"
RUSHER_GUID = "94f02b0133f1f0d2e85a6d490fd93f95"


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
    map_block = blocks[map_id][1]
    point_ids = [int(v) for v in re.findall(r"^  - point: \{fileID: (\d+)\}$", map_block, re.M)]
    if len(point_ids) != 8:
        raise ValueError("expected eight defend positions")
    covers = []
    seen = set()
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
                raise ValueError("cyclic point transform")
        position = [0.0, 0.0, 0.0]
        rotation = [0.0, 0.0, 0.0, 1.0]
        scale = [1.0, 1.0, 1.0]
        for transform in reversed(chain):
            local = [a*b for a, b in zip(transform["position"], scale)]
            offset = rotate(rotation, local)
            position = [a+b for a, b in zip(position, offset)]
            rotation = mul(rotation, transform["rotation"])
            scale = [a*b for a, b in zip(scale, transform["scale"])]
        if not all(math.isfinite(x) and abs(x)<10000 for x in position):
            raise ValueError("invalid point world position")
        return transform_id, position
    for index, point_id in enumerate(point_ids):
        kind, point = blocks[point_id]
        if kind != 114 or f"guid: {PLAYER_POINT_GUID}" not in point:
            raise ValueError("defend position does not reference a PlayerPoint")
        _, player_point_position = world_position(point)
        match = re.search(r"^  rusherPoints:\r?\n((?:  - \{fileID: \d+\}\r?\n)+)", point, re.M)
        if match is None:
            raise ValueError("PlayerPoint has no serialized rusher list")
        rusher_ids = [int(v) for v in re.findall(r"fileID: (\d+)", match.group(1))]
        if len(rusher_ids) != 4:
            raise ValueError("expected four Rusher slots per defend position")
        rusher_rows = []
        for rusher_id in rusher_ids:
            kind, rusher = blocks[rusher_id]
            if kind != 114 or f"guid: {RUSHER_GUID}" not in rusher or rusher_id in seen:
                raise ValueError("wrong, duplicated or shared EnemyPointRusher")
            seen.add(rusher_id)
            rusher_index = int(field(rusher, "index"))
            transform_id, position = world_position(rusher)
            rusher_rows.append({"componentFileId": rusher_id, "index": rusher_index,
                                "transformFileId": transform_id, "worldPosition": position})
        covers.append({"sourceIndex": index, "playerPointFileId": point_id,
                       "playerPointWorldPosition": player_point_position,
                       "rusherPoints": rusher_rows})
    return {"source": source_map["source"], "sha256": digest,
            "mapDefinitionFileId": map_id, "covers": covers}


def main():
    source = json.loads(SOURCE.read_text(encoding="utf-8"))
    maps = [extract(m) for m in source["maps"]]
    output = json.dumps({"version": 1, "maps": maps}, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != output:
            raise ValueError("army rusher point artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(output, encoding="utf-8")
    else:
        raise ValueError("usage: extract_army_rusher_points.py [--check]")
    print(f"{len(maps)} maps, {sum(len(c['rusherPoints']) for m in maps for c in m['covers'])} Rusher slots")


if __name__ == "__main__":
    main()
