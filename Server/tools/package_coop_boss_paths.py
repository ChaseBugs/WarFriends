"""Pin Unity paths among the eight multiplayer BotMission defend points."""

import hashlib
import json
import math
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
ANCHORS = CONTENT / "recovered-coop-boss-anchors.json"
NAVIGATION = CONTENT / "recovered-army-navmesh-sources.json"
UNITY_RESULT = ROOT / "Server/.local/coop-boss-path-output.json"
OUTPUT = CONTENT / "recovered-coop-boss-paths.json"


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def vector(value):
    if set(value) != {"x", "y", "z"}:
        raise ValueError("Unity boss route vector fields differ")
    result = [value[axis] for axis in "xyz"]
    if any(not isinstance(number, (float, int)) or
           not math.isfinite(number) or abs(number) > 10000
           for number in result):
        raise ValueError("Unity boss route vector is invalid")
    return result


def main():
    if sys.argv[1:] not in ([], ["--check"]):
        raise SystemExit("usage: package_coop_boss_paths.py [--check]")
    anchors = json.loads(ANCHORS.read_bytes())
    navigation = json.loads(NAVIGATION.read_bytes())
    unity = json.loads(UNITY_RESULT.read_bytes())
    if unity.get("version") != 1 or len(unity.get("maps", [])) != 5 or \
            len(anchors["maps"]) != 5 or len(navigation["maps"]) != 5:
        raise ValueError("boss route source maps are incomplete")
    nav_by_scene = {row["scene"].split("/")[-1].removesuffix(".unity"): row
                    for row in navigation["maps"]}

    maps = []
    for anchor_map, unity_map in zip(anchors["maps"], unity["maps"]):
        nav = nav_by_scene[anchor_map["scene"]]
        if set(unity_map) != {"scene", "asset", "routes"} or \
                unity_map["scene"] != anchor_map["scene"] or \
                unity_map["asset"] != nav["navMeshAsset"] or \
                anchor_map["sceneSha256"] != nav["sceneSha256"] or \
                len(unity_map["routes"]) != 24:
            raise ValueError("boss route map differs from source anchors")
        pairs = [(start, end) for start in range(8) for end in range(8)
                 if start != end and (start < 4) == (end < 4)]
        routes = []
        for (start, end), route in zip(pairs, unity_map["routes"]):
            if set(route) != {"from", "to", "startSampled", "endSampled",
                              "sampledStart", "sampledEnd", "status", "corners"} or \
                    route["from"] != start or route["to"] != end or \
                    route["startSampled"] is not True or \
                    route["endSampled"] is not True or \
                    route["status"] != "PathComplete" or \
                    not 2 <= len(route["corners"]) <= 16:
                raise ValueError("boss route is missing or incomplete")
            sampled_start = vector(route["sampledStart"])
            sampled_end = vector(route["sampledEnd"])
            corners = [vector(corner) for corner in route["corners"]]
            points = anchor_map["playerPositions"]
            if math.dist(sampled_start, points[start]["worldPosition"]) > 0.25 or \
                    math.dist(sampled_end, points[end]["worldPosition"]) > 0.25 or \
                    math.dist(corners[0], sampled_start) > 0.01 or \
                    math.dist(corners[-1], sampled_end) > 0.01:
                raise ValueError("boss route endpoints differ from source shields")
            routes.append({"from": start, "to": end, "corners": corners})
        maps.append({"stage": anchor_map["stage"],
                     "scene": anchor_map["scene"],
                     "sceneSha256": anchor_map["sceneSha256"],
                     "navMeshSha256": nav["navMeshSha256"],
                     "routes": routes})

    artifact = {"version": 1, "anchorSourceSha256": digest(ANCHORS),
                "navigationSourceSha256": digest(NAVIGATION), "maps": maps}
    encoded = (json.dumps(artifact, indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("packaged boss routes differ from Unity export")
    else:
        OUTPUT.write_bytes(encoded)
    print("120 complete multiplayer boss defend-position routes pinned")


if __name__ == "__main__":
    main()
