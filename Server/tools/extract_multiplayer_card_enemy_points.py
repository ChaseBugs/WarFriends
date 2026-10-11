"""Pin the multiplayer enemy points used by card-spawned Rusher soldiers.

Paratrooper.GetInitPoint accepts Corner or Hiding points when spawned by a
card; Swat.GetInitPoint accepts Swat points. Ordinary Rusher points are a
different, shield-linked collection and cannot substitute for these rows.
"""

import hashlib
import json
import math
import re
import sys
from collections import Counter
from pathlib import Path

from extract_army_spawn_points import field, ref
from extract_coop_enemy_points import blocks_in
from extract_coop_spawn_points import METAS, game_object_transform


ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-multiplayer-card-enemy-points.json"
MAP_GUID = "f8e8488fbe21f6c02c9eef456d27a3b9"
COLLECTION_GUID = "d9d8bf95b76e06b83a10740c1390212a"
CARD_POINT_TYPES = {"EnemyPointCorner", "EnemyPointHiding", "EnemyPointSwat"}
EXPECTED_COUNTS = {
    "Aztec": {"EnemyPointCorner": (1, 1), "EnemyPointSwat": (2, 2)},
    "City": {"EnemyPointCorner": (1, 2), "EnemyPointSwat": (2, 2)},
    "Desert": {"EnemyPointCorner": (2, 2), "EnemyPointSwat": (2, 2)},
    "Park": {"EnemyPointCorner": (2, 2), "EnemyPointSwat": (2, 2)},
    "Snow": {"EnemyPointSwat": (2, 2)},
}


def script_types_by_guid():
    result = {}
    for meta in METAS.rglob("EnemyPoint*.cs.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$",
                          meta.read_text(encoding="utf-8-sig"), re.M)
        if match:
            result[match.group(1)] = meta.name.removesuffix(".cs.meta")
    return result


def extract_map(source_map, script_types):
    path = ROOT / "Clients/ExportedProject" / source_map["source"]
    source = path.read_bytes()
    digest = hashlib.sha256(source).hexdigest()
    if digest != source_map["sha256"]:
        raise ValueError(f"multiplayer scene changed: {path}")

    blocks = blocks_in(source.decode("utf-8-sig"))
    definitions = [
        (file_id, block) for file_id, (kind, block) in blocks.items()
        if kind == 114 and f"guid: {MAP_GUID}" in block
    ]
    if len(definitions) != 1:
        raise ValueError("expected one multiplayer MapDefinition")
    definition_id, definition = definitions[0]
    collection_id = ref(definition, "enemyPointsCollection")
    collection_kind, collection = blocks[collection_id]
    if collection_kind != 114 or f"guid: {COLLECTION_GUID}" not in collection:
        raise ValueError("wrong multiplayer EnemyPointsCollection")
    point_ids = [int(value) for value in re.findall(
        r"^  - \{fileID: (\d+)\}$",
        collection.split("  enemyPoints:\n", 1)[1], re.M,
    )]
    if not point_ids or 0 in point_ids or len(point_ids) != len(set(point_ids)):
        raise ValueError("empty, missing, or duplicate multiplayer enemy point")

    points = []
    for order, component_id in enumerate(point_ids):
        kind, component = blocks[component_id]
        match = re.search(r"guid: ([0-9a-f]{32})", field(component, "m_Script"))
        point_type = script_types.get(match.group(1)) if match else None
        if kind != 114 or point_type is None:
            raise ValueError("unresolved multiplayer EnemyPoint component")
        if point_type not in CARD_POINT_TYPES:
            continue
        game_object_id, transform_id, position, rotation = \
            game_object_transform(blocks, component)
        fraction = int(field(component, "mFraction"))
        if fraction not in (1, 2):
            raise ValueError("card enemy point has an invalid faction")
        row = {
            "order": order,
            "componentFileId": component_id,
            "componentType": point_type,
            "gameObjectFileId": game_object_id,
            "transformFileId": transform_id,
            "fraction": fraction,
            "worldPosition": position,
            "worldRotation": rotation,
        }
        if point_type == "EnemyPointCorner":
            coordinates = [float(value) for value in re.findall(
                r"[xyz]: (-?[0-9.]+)", field(component, "direction"),
            )]
            right_side = int(field(component, "rightSide"))
            if (len(coordinates) != 3 or
                    not all(math.isfinite(value) for value in coordinates) or
                    math.dist(coordinates, [0.0, 0.0, 0.0]) < 0.01 or
                    right_side not in (0, 1)):
                raise ValueError("invalid multiplayer Corner direction or side")
            row["cornerDirection"] = coordinates
            row["cornerRightSide"] = bool(right_side)
        points.append(row)

    return {
        "source": source_map["source"],
        "sha256": digest,
        "mapDefinitionFileId": definition_id,
        "collectionComponentFileId": collection_id,
        "points": points,
    }


def main():
    source_maps = json.loads(SOURCE.read_text(encoding="utf-8"))["maps"]
    script_types = script_types_by_guid()
    maps = [extract_map(source_map, script_types) for source_map in source_maps]
    counts = Counter(point["componentType"] for map_row in maps
                     for point in map_row["points"])
    if len(maps) != 5 or counts != Counter({
            "EnemyPointCorner": 13, "EnemyPointSwat": 20}):
        raise ValueError("card enemy point inventory is incomplete")
    for map_row in maps:
        name = Path(map_row["source"]).stem.split("_", 1)[0]
        expected = EXPECTED_COUNTS.get(name)
        actual = {
            point_type: tuple(sum(point["componentType"] == point_type and
                                  point["fraction"] == fraction
                                  for point in map_row["points"])
                              for fraction in (1, 2))
            for point_type in CARD_POINT_TYPES
            if any(point["componentType"] == point_type
                   for point in map_row["points"])
        }
        if actual != expected:
            raise ValueError(f"{name} card enemy point counts changed: {actual}")

    content = json.dumps({"version": 2, "maps": maps}, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("card enemy points differ from source scenes")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8")
    else:
        raise ValueError("usage: extract_multiplayer_card_enemy_points.py [--check]")
    print(f"{len(maps)} maps, {sum(counts.values())} card enemy points: {dict(counts)}")


if __name__ == "__main__":
    main()
