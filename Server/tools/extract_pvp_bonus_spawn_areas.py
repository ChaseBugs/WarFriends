"""Extract the two KillStreakManager box spawn colliders in each PvP map."""

import hashlib
import itertools
import json
import math
import re
import sys
from pathlib import Path

from extract_army_spawn_points import MAP_GUID, field, ref, rotate, transform_chain, vec


ROOT = Path(__file__).resolve().parents[2]
SOURCE = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-pvp-bonus-spawn-areas.json"


def world_point(local, chain):
    point = local
    for transform in chain:
        scaled = [a * b for a, b in zip(point, transform["scale"])]
        rotated = rotate(transform["rotation"], scaled)
        point = [a + b for a, b in zip(transform["position"], rotated)]
    return point


def extract(source_map):
    path = ROOT / "Clients/ExportedProject" / source_map["source"]
    data = path.read_bytes()
    digest = hashlib.sha256(data).hexdigest()
    if digest != source_map["sha256"]:
        raise ValueError(f"PvP map changed: {path}")
    blocks = {int(match.group(2)): (int(match.group(1)), match.group(3))
              for match in re.finditer(
                  r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
                  data.decode("utf-8-sig"), re.M | re.S)}
    map_ids = [file_id for file_id, (kind, block) in blocks.items()
               if kind == 114 and f"guid: {MAP_GUID}" in block]
    if len(map_ids) != 1:
        raise ValueError("Expected one MapDefinition in the PvP scene")
    map_block = blocks[map_ids[0]][1]
    area_text = map_block.split("  spawnAreas:\n", 1)[1].split("  fieldArea:", 1)[0]
    area_ids = [int(value) for value in re.findall(
        r"^  - \{fileID: (\d+)\}$", area_text, re.M)]
    if len(area_ids) != 2 or len(set(area_ids)) != 2:
        raise ValueError("Expected two ordered source bonus spawn areas")
    areas = []
    for order, file_id in enumerate(area_ids):
        kind, collider = blocks[file_id]
        if kind != 65:
            raise ValueError("Bonus spawn area must be a BoxCollider")
        if field(collider, "m_Enabled") != "1" or field(collider, "m_IsTrigger") != "1":
            raise ValueError("Bonus spawn area must be an enabled trigger")
        center = vec(field(collider, "m_Center"))
        size = vec(field(collider, "m_Size"))
        if any(not math.isfinite(value) for value in center + size) or any(value <= 0 for value in size):
            raise ValueError("Invalid source bonus BoxCollider")
        game_object_id = ref(collider, "m_GameObject")
        if field(blocks[game_object_id][1], "m_IsActive") != "1":
            raise ValueError("Bonus spawn area GameObject must be active")
        transform_match = re.search(r"^  - 4: \{fileID: (\d+)\}$",
                                    blocks[game_object_id][1], re.M)
        if not transform_match:
            raise ValueError("Bonus spawn collider has no transform")
        transform_id = int(transform_match.group(1))
        chain, _ = transform_chain(blocks, transform_id)
        corners = [world_point([center[axis] + sign[axis] * size[axis] / 2
                                for axis in range(3)], chain)
                   for sign in itertools.product((-1, 1), repeat=3)]
        minimum = [min(corner[axis] for corner in corners) for axis in range(3)]
        maximum = [max(corner[axis] for corner in corners) for axis in range(3)]
        if any(not math.isfinite(value) or abs(value) > 10000 for value in minimum + maximum):
            raise ValueError("Invalid world bonus spawn bounds")
        areas.append({"order": order, "colliderFileId": file_id,
                      "gameObjectFileId": game_object_id,
                      "transformFileId": transform_id, "localCenter": center,
                      "localSize": size, "transformChain": chain,
                      "boundsMin": minimum, "boundsMax": maximum})
    return {"source": source_map["source"], "sha256": digest,
            "mapDefinitionFileId": map_ids[0], "areas": areas}


def main():
    source = json.loads(SOURCE.read_text(encoding="utf-8"))
    maps = [extract(source_map) for source_map in source["maps"]]
    scripts = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
    manager = (scripts / "KillStreakManager.cs").read_bytes()
    definition = (scripts / "MapDefinition.cs").read_bytes()
    for expression in ("currentMapDef.spawnAreas[Random.Range(0,",
                       "Random.Range(bounds.min.x, bounds.max.x)",
                       "Random.Range(bounds.min.y, bounds.max.y)",
                       "Random.Range(bounds.min.z, bounds.max.z)"):
        if expression not in manager.decode("utf-8-sig"):
            raise ValueError("Source box spawn sampling changed")
    if "public List<BoxCollider> spawnAreas;" not in definition.decode("utf-8-sig"):
        raise ValueError("Source map spawn binding changed")
    artifact = {"version": 1,
                "killStreakManagerSha256": hashlib.sha256(manager).hexdigest(),
                "mapDefinitionSha256": hashlib.sha256(definition).hexdigest(),
                "maps": maps}
    serialized = json.dumps(artifact, indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != serialized:
            raise ValueError("PvP bonus spawn area artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(serialized, encoding="utf-8", newline="\n")
    else:
        raise ValueError("usage: extract_pvp_bonus_spawn_areas.py [--check]")
    print(f"{len(maps)} PvP maps, {sum(len(item['areas']) for item in maps)} bonus spawn areas")


if __name__ == "__main__":
    main()
