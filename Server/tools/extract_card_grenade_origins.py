"""Extract CardGrenadesBurst fire origins from each PvP scene.

CardGrenadesBurst reads PlayerPoint.shield.hudIndicator.snapTransform.
The nearby Shield.shotPosition is a different serialized reference.
"""

import hashlib
import json
import math
import re
from pathlib import Path

from extract_army_spawn_points import MAP_GUID, field, ref, transform_chain
from extract_coop_spawn_points import game_object_transform


ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-card-grenade-origins.json"


def blocks_in(scene):
    return {
        int(match.group(2)): (int(match.group(1)), match.group(3))
        for match in re.finditer(
            r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
            scene, re.M | re.S)
    }


def extract(source_map):
    scene_path = ROOT / "Clients/ExportedProject" / source_map["source"]
    source_bytes = scene_path.read_bytes()
    scene_digest = hashlib.sha256(source_bytes).hexdigest()
    if scene_digest != source_map["sha256"]:
        raise ValueError(f"multiplayer scene changed: {scene_path}")
    blocks = blocks_in(source_bytes.decode("utf-8-sig"))
    map_ids = [file_id for file_id, (kind, body) in blocks.items()
               if kind == 114 and f"guid: {MAP_GUID}" in body]
    if len(map_ids) != 1:
        raise ValueError("expected one multiplayer MapDefinition")
    definition = blocks[map_ids[0]][1]
    positions = definition.split("  playersPositions:\n", 1)[1].split(
        "  spawnAreas:", 1)[0]
    player_ids = [int(value) for value in re.findall(
        r"^  - point: \{fileID: (\d+)\}$", positions, re.M)]
    if len(player_ids) != 8 or len(set(player_ids)) != 8:
        raise ValueError("expected eight ordered PvP PlayerPoints")

    origins = []
    shields = [(file_id, body) for file_id, (kind, body) in blocks.items()
               if kind == 114 and "  hudIndicator:" in body and
               "  shotPosition:" in body]
    if len(shields) != 8:
        raise ValueError("expected eight multiplayer shields")
    for index, player_id in enumerate(player_ids):
        player = blocks[player_id][1]
        _, player_transform, _, _ = game_object_transform(blocks, player)
        descendants = []
        for shield_id, shield in shields:
            _, shield_transform, _, _ = game_object_transform(blocks, shield)
            chain, _ = transform_chain(blocks, shield_transform)
            if any(transform["fileId"] == player_transform for transform in chain):
                descendants.append((shield_id, shield))
        if len(descendants) != 1:
            raise ValueError("PlayerPoint has no unique child shield")
        shield_id, shield = descendants[0]
        indicator_id = ref(shield, "hudIndicator")
        indicator = blocks[indicator_id][1]
        snap_id = ref(indicator, "snapTransform")
        shot_id = ref(shield, "shotPosition")
        if any(blocks[component][0] != 114 for component in
               (player_id, shield_id, indicator_id)):
            raise ValueError("invalid card grenade component chain")
        if blocks[snap_id][0] != 4 or blocks[shot_id][0] != 4:
            raise ValueError("card grenade anchors are not transforms")
        _, origin = transform_chain(blocks, snap_id)
        _, shot_position = transform_chain(blocks, shot_id)
        expected = source_map["points"][index]
        if math.dist(shot_position, expected["shotPosition"]) > 0.0001:
            raise ValueError("source shield shot position differs from battle map")
        if not all(math.isfinite(value) and abs(value) <= 10000
                   for value in origin):
            raise ValueError("invalid card grenade origin")
        origins.append({
            "sourceIndex": index,
            "playerPointFileId": player_id,
            "shieldFileId": shield_id,
            "hudIndicatorFileId": indicator_id,
            "snapTransformFileId": snap_id,
            "shotPositionFileId": shot_id,
            "position": origin,
        })
    return {"source": source_map["source"], "sha256": scene_digest,
            "origins": origins}


def main():
    maps = json.loads(SOURCE.read_text(encoding="utf-8"))["maps"]
    extracted = [extract(source_map) for source_map in maps]
    result = {"client": "1.4.0", "maps": extracted}
    OUTPUT.write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8")
    for original, source_map in zip(maps, extracted):
        distances = [math.dist(origin["position"],
                               original["points"][origin["sourceIndex"]]["shotPosition"])
                     for origin in source_map["origins"]]
        print(Path(source_map["source"]).stem,
              "max snap-to-shot distance", max(distances))


if __name__ == "__main__":
    main()
