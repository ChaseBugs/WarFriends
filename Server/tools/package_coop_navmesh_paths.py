"""Validate and pin Unity 2018 routes between all co-op defend positions."""

import hashlib
import json
import math
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
UNITY_RESULT = ROOT / "Server/.local/coop-path-output.json"
OUTPUT = CONTENT / "recovered-coop-navmesh-paths.json"


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def vector(value):
    if set(value) != {"x", "y", "z"}:
        raise ValueError("Unity route vector fields differ")
    result = [value[axis] for axis in "xyz"]
    if any(not isinstance(number, (float, int)) or
           not math.isfinite(number) or abs(number) > 10000 for number in result):
        raise ValueError("Unity route vector is not finite and bounded")
    return result


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: package_coop_navmesh_paths.py [--check]")
    source_path = CONTENT / "recovered-coop-spawn-points.json"
    navigation_path = CONTENT / "recovered-coop-navmesh-sources.json"
    source = json.loads(source_path.read_bytes())
    navigation = json.loads(navigation_path.read_bytes())
    unity = json.loads(UNITY_RESULT.read_bytes())
    if len(source["maps"]) != 5 or len(navigation["maps"]) != 5:
        raise ValueError("Co-op source maps are incomplete")
    if set(unity) != {"version", "maps"} or unity["version"] != 1 or \
            len(unity["maps"]) != 5:
        raise ValueError("Unity co-op route export is incomplete")

    maps = []
    for source_map, nav_map, unity_map in zip(
            source["maps"], navigation["maps"], unity["maps"]):
        if set(unity_map) != {"scene", "asset", "routes"} or \
                unity_map["scene"] != source_map["scene"] or \
                unity_map["scene"] != nav_map["scene"] or \
                source_map["stage"] != nav_map["stage"] or \
                source_map["sceneSha256"] != nav_map["sceneSha256"] or \
                unity_map["asset"] != nav_map["sourceAsset"] or \
                len(unity_map["routes"]) != 12:
            raise ValueError("Unity route map differs from the Client scene")
        routes = []
        ordered_pairs = [(start, end) for start in range(4)
                         for end in range(4) if start != end]
        for (start, end), route in zip(ordered_pairs, unity_map["routes"]):
            if set(route) != {"from", "to", "startSampled", "endSampled",
                              "sampledStart", "sampledEnd", "status", "corners"} or \
                    route["from"] != start or route["to"] != end or \
                    route["startSampled"] is not True or \
                    route["endSampled"] is not True or \
                    route["status"] != "PathComplete" or \
                    not 2 <= len(route["corners"]) <= 16:
                raise ValueError("Unity route is absent or incomplete")
            sampled_start = vector(route["sampledStart"])
            sampled_end = vector(route["sampledEnd"])
            corners = [vector(corner) for corner in route["corners"]]
            points = source_map["playerPositions"]
            if math.dist(sampled_start, points[start]["worldPosition"]) > 0.25 or \
                    math.dist(sampled_end, points[end]["worldPosition"]) > 0.25 or \
                    math.dist(corners[0], sampled_start) > 0.01 or \
                    math.dist(corners[-1], sampled_end) > 0.01:
                raise ValueError("Unity route endpoints differ from source anchors")
            routes.append({"from": start, "to": end, "corners": corners})
        maps.append({"stage": source_map["stage"], "scene": source_map["scene"],
                     "sceneSha256": source_map["sceneSha256"],
                     "navMeshSha256": nav_map["sha256"], "routes": routes})

    artifact = {"version": 1, "spawnSourceSha256": digest(source_path),
                "navigationSourceSha256": digest(navigation_path), "maps": maps}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("packaged co-op routes differ from Unity export")
    else:
        OUTPUT.write_bytes(encoded)
    print("60 complete source defend-position routes pinned across five maps")


if __name__ == "__main__":
    main()
