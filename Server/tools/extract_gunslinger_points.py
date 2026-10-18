"""Extract ordinary Gunslinger destinations from the five pinned multiplayer scenes."""

import hashlib
import json
import sys

from extract_army_spawn_points import field
from extract_coop_enemy_points import blocks_in
from extract_multiplayer_card_enemy_points import ROOT, SOURCE, extract_map, script_types_by_guid


OUTPUT = ROOT / "Server/content/recovered-gunslinger-points.json"
BEHAVIOR_FILE_ID = 36243
POINT_MASK = 2048


def extract():
    scene_path = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
    scene = scene_path.read_bytes()
    kind, behavior = blocks_in(scene.decode("utf-8-sig"))[BEHAVIOR_FILE_ID]
    if kind != 114 or field(behavior, "unitDictionaryId") != "ID_UNIT-GUNSLINGER":
        raise ValueError("Gunslinger source identity changed")
    if int(field(behavior, "enemyPointType")) != POINT_MASK:
        raise ValueError("Gunslinger accepts an unreviewed point mask")

    source_maps = json.loads(SOURCE.read_text(encoding="utf-8"))["maps"]
    script_types = script_types_by_guid()
    maps = [extract_map(source_map, script_types, {"EnemyPointGunslinger"})
            for source_map in source_maps]
    for map_row in maps:
        counts = [sum(point["fraction"] == fraction for point in map_row["points"])
                  for fraction in (1, 2)]
        if counts != [3, 3]:
            raise ValueError(f"Gunslinger point inventory changed: {map_row['source']}")

    return {
        "version": 1,
        "unitSource": {
            "source": "Assets/Scenes/MainScene.unity",
            "sha256": hashlib.sha256(scene).hexdigest(),
            "behaviorFileId": BEHAVIOR_FILE_ID,
            "enemyPointMask": POINT_MASK,
        },
        "maps": maps,
    }


def main():
    content = json.dumps(extract(), indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("Gunslinger points differ from recovered source")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8", newline="\n")
    else:
        raise ValueError("usage: extract_gunslinger_points.py [--check]")
    print("5 maps, 30 source Gunslinger points; original order and faction retained")


if __name__ == "__main__":
    main()
