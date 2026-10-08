"""Extract air paths linked to the five recovered co-op mission scenes."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path

from extract_army_spawn_points import field, ref, transform_chain


ROOT = Path(__file__).resolve().parents[2]
SCENES = ROOT / "Clients/ExportedProject/Assets/Scenes"
SPAWNS = ROOT / "Server/content/recovered-coop-spawn-points.json"
OUTPUT = ROOT / "Server/content/recovered-coop-air-waypoint-routes.json"
AIR_COLLECTIONS = (
    "spawnPointsCollectionDrones",
    "spawnPointsCollectionAssaultHelis",
    "spawnPointsCollectionHelicopters",
)
PATH_SCRIPT_GUID = "a604c2e26b5732c5b35329d042a09950"
WAYPOINT_SCRIPT_GUID = "65351fae930a5df16f470909621c2f6f"


def scene_blocks(path):
    source = path.read_bytes()
    blocks = {int(match.group(2)): (int(match.group(1)), match.group(3))
              for match in re.finditer(
                  r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",
                  source.decode("utf-8-sig"), re.M | re.S)}
    return source, blocks


def source_waypoints(blocks, path_id, transforms):
    kind, path = blocks[path_id]
    if kind != 114 or PATH_SCRIPT_GUID not in field(path, "m_Script"):
        raise ValueError("co-op air route is not a source WayPath")
    match = re.search(r"^  wayPoints:\r?\n(.*?)(?=^  \w|\Z)",
                      path, re.M | re.S)
    if match is None:
        raise ValueError("co-op air route has no waypoint list")
    waypoint_ids = [int(value) for value in re.findall(
        r"fileID: (\d+)", match.group(1))]
    if not waypoint_ids or len(waypoint_ids) != len(set(waypoint_ids)):
        raise ValueError("co-op air route has repeated waypoints")
    radius = float(field(path, "Radius"))
    if not math.isfinite(radius) or radius <= 0:
        raise ValueError("co-op air route radius is invalid")

    waypoints = []
    for index, waypoint_id in enumerate(waypoint_ids):
        kind, point = blocks[waypoint_id]
        if kind != 114 or WAYPOINT_SCRIPT_GUID not in field(
                point, "m_Script") or ref(point, "path") != path_id:
            raise ValueError("co-op waypoint has the wrong path owner")
        if int(field(point, "index")) != index:
            raise ValueError("co-op waypoint order differs from path")
        stay = float(field(point, "stayTime"))
        if not math.isfinite(stay) or stay < 0:
            raise ValueError("co-op waypoint stay time is invalid")
        transform_id = transforms[ref(point, "m_GameObject")]
        chain, position = transform_chain(blocks, transform_id)
        waypoints.append({
            "componentFileId": waypoint_id,
            "transformFileId": transform_id,
            "index": index,
            "stayTime": stay,
            "worldPosition": position,
            "transformChain": chain,
        })
    return waypoint_ids, radius, waypoints


def extract_map(map_source):
    path = SCENES / (map_source["scene"] + ".unity")
    raw, blocks = scene_blocks(path)
    if hashlib.sha256(raw).hexdigest() != map_source["sceneSha256"]:
        raise ValueError(f"co-op source scene changed: {path}")
    transforms = {ref(block, "m_GameObject"): component_id
                  for component_id, (kind, block) in blocks.items()
                  if kind == 4}
    routes = []
    for spawn in map_source["spawnPoints"]:
        collection = spawn["collection"]
        if collection not in AIR_COLLECTIONS:
            continue
        component_id = spawn["componentFileId"]
        kind, component = blocks[component_id]
        if kind != 114 or int(field(component, "mFraction")) != \
                spawn["fraction"]:
            raise ValueError("co-op air spawn identity changed")
        join_field = "wayPointToJoin" if collection == \
            "spawnPointsCollectionHelicopters" else "pointToJoin"
        join_id = ref(component, join_field)
        path_id = ref(blocks[join_id][1], "path")
        # Multiple source anchors may join the same path. Drone.Spawn checks
        # path.usedByEntity, so the host must reserve the path, not the anchor.
        waypoint_ids, radius, waypoints = source_waypoints(
            blocks, path_id, transforms)
        if join_id not in waypoint_ids:
            raise ValueError("co-op air join point is outside its path")
        stop_id = 0
        if collection == "spawnPointsCollectionHelicopters":
            stop_id = ref(component, "wayPointToStop")
            if stop_id not in waypoint_ids or stop_id == join_id:
                raise ValueError("co-op transport stop point is invalid")
        routes.append({
            "spawnComponentFileId": component_id,
            "collection": collection,
            "fraction": spawn["fraction"],
            "pathComponentFileId": path_id,
            "joinWaypointFileId": join_id,
            "joinIndex": waypoint_ids.index(join_id),
            "stopWaypointFileId": stop_id,
            "stopIndex": waypoint_ids.index(stop_id) if stop_id else -1,
            "radius": radius,
            "waypoints": waypoints,
        })
    return {"scene": map_source["scene"],
            "sceneSha256": map_source["sceneSha256"],
            "routes": routes}


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: extract_coop_air_waypoint_routes.py [--check]")
    source = SPAWNS.read_bytes()
    spawn_catalog = json.loads(source)
    maps = [extract_map(row) for row in spawn_catalog["maps"]]
    counts = [len(row["routes"]) for row in maps]
    if counts != [5, 4, 4, 5, 5]:
        raise ValueError(f"co-op air route count changed: {counts}")
    artifact = {"version": 1,
                "spawnSourceSha256": hashlib.sha256(source).hexdigest(),
                "maps": maps}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode("utf-8")
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("co-op air routes differ from source scenes")
    else:
        OUTPUT.write_bytes(encoded)
    print(f"{len(maps)} co-op maps, {sum(counts)} air routes")


if __name__ == "__main__":
    main()
