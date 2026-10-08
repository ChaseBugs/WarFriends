"""Pin PlayerPoint.rusherPoints in the five recovered co-op scenes."""

import hashlib
import json
import re
import sys
from pathlib import Path

from extract_army_spawn_points import field
from extract_coop_enemy_points import blocks_in
from extract_coop_spawn_points import (
    SCENES, PLAYER_POINT_GUID, game_object_transform,
)


ROOT = Path(__file__).resolve().parents[2]
SPAWNS = ROOT / "Server/content/recovered-coop-spawn-points.json"
OUTPUT = ROOT / "Server/content/recovered-coop-rusher-points.json"
RUSHER_META = (ROOT / "Clients/ExportedProject/Assets/Scripts/"
               "Assembly-CSharp/EnemyPointRusher.cs.meta")


def references_after(block, name):
    lines = block.split(f"  {name}:\n", 1)[1].splitlines()
    result = []
    for line in lines:
        match = re.fullmatch(r"  - \{fileID: (\d+)\}", line)
        if not match:
            break
        result.append(int(match.group(1)))
    return result


def main():
    maps = json.loads(SPAWNS.read_text(encoding="utf-8"))["maps"]
    guid = re.search(r"^guid: ([0-9a-f]{32})$",
                     RUSHER_META.read_text(encoding="utf-8-sig"), re.M)
    if not guid:
        raise ValueError("EnemyPointRusher source script GUID is missing")
    output_maps = []
    all_ids = 0
    for map_row in maps:
        source = (SCENES / (map_row["scene"] + ".unity")).read_bytes()
        digest = hashlib.sha256(source).hexdigest()
        if digest != map_row["sceneSha256"]:
            raise ValueError("co-op rusher scene differs from the spawn catalog")
        blocks = blocks_in(source.decode("utf-8-sig"))
        player_rows = []
        used = set()
        for player in map_row["playerPositions"]:
            player_id = player["componentFileId"]
            component = blocks[player_id][1]
            if PLAYER_POINT_GUID not in component:
                raise ValueError("source player point type changed")
            ids = references_after(component, "rusherPoints")
            if len(ids) != 4 or len(set(ids)) != 4:
                raise ValueError("player shield needs four ordered rusher points")
            points = []
            for order, point_id in enumerate(ids):
                if point_id in used:
                    raise ValueError("rusher point belongs to two player shields")
                used.add(point_id)
                kind, point = blocks[point_id]
                if (kind != 114 or f"guid: {guid.group(1)}" not in point or
                        int(field(point, "mFraction")) != 1):
                    raise ValueError("unresolved enemy-fraction rusher point")
                game_object, transform, position, rotation = \
                    game_object_transform(blocks, point)
                points.append({
                    "order": order,
                    "componentFileId": point_id,
                    "sourceIndex": int(field(point, "index")),
                    "gameObjectFileId": game_object,
                    "transformFileId": transform,
                    "worldPosition": position,
                    "worldRotation": rotation,
                })
            player_rows.append({
                "playerPositionIndex": player["index"],
                "playerPointComponentFileId": player_id,
                "points": points,
            })
        if len(used) != 16:
            raise ValueError("co-op rusher point inventory changed")
        all_ids += len(used)
        output_maps.append({
            "stage": map_row["stage"],
            "scene": map_row["scene"],
            "sceneSha256": digest,
            "playerPoints": player_rows,
        })
    content = json.dumps({"version": 1, "maps": output_maps}, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("co-op rusher artifact differs from source scenes")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8")
    else:
        raise ValueError("usage: extract_coop_rusher_points.py [--check]")
    print(f"{len(output_maps)} maps, {all_ids} shield-linked rusher points")


if __name__ == "__main__":
    main()
