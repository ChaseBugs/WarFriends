"""Pin a two-agent Unity 2018.3 NavMesh trace against source route artifacts."""

import hashlib
import json
import math
import sys
from pathlib import Path

CONTENT = Path(__file__).resolve().parents[1] / "content"
INPUT = CONTENT / "navmesh-motion" / "park-crowd-input.json"
RESULT = CONTENT / "navmesh-motion" / "park-crowd-result.json"
MANIFEST = CONTENT / "recovered-navmesh-crowd.json"
IDS = ("3251-3551", "3443-3429")


def load(path):
    return json.loads(path.read_text(encoding="utf-8"),
                      parse_constant=lambda value: (_ for _ in ()).throw(ValueError(value)))


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def planar(a, b):
    return math.hypot(a["x"] - b["x"], a["z"] - b["z"])


def validate():
    source = load(CONTENT / "recovered-navmesh-path-manifest.json")
    map_pin = next(row for row in source["maps"] if row["scene"] ==
                   "Assets/Scenes/Park_Multiplayer.unity")
    paths = load(CONTENT / "navmesh-path-results" / map_pin["file"])
    settings = load(CONTENT / "recovered-army-deployment.json")
    config = load(INPUT)
    trace = load(RESULT)
    if (config["version"], config["scene"], config["asset"]) != \
            (1, map_pin["scene"], "Assets/NavMeshData/NavMesh_6.asset") or \
            (trace["version"], trace["scene"], trace["asset"]) != \
            (1, config["scene"], config["asset"]) or \
            [row["id"] for row in config["cases"]] != list(IDS) or \
            [row["id"] for row in trace["cases"]] != list(IDS):
        raise ValueError("crowd trace identity differs from pinned Park cases")
    if set(row["movementSpeed"] for row in settings["families"]
           if row["isSoldier"] and not row["isAir"]) != {.8, .9, 1.0}:
        raise ValueError("source infantry speed set changed")
    for intended, observed in zip(config["cases"], trace["cases"]):
        route = next(row for row in paths["cases"] if row["id"] == intended["id"])
        if intended["speed"] != .9 or route["status"] != "PathComplete" or \
                intended["start"] != route["sampledStart"] or \
                intended["end"] != route["sampledEnd"] or \
                observed["sampledStart"] != route["sampledStart"] or \
                observed["sampledEnd"] != route["sampledEnd"] or \
                observed["status"] != "Arrived":
            raise ValueError("crowd agent is not bound to a complete source route")
        samples = observed["samples"]
        if not 100 <= len(samples) <= 1000 or samples[0]["time"] != 0:
            raise ValueError("crowd trace sample count or origin is invalid")
        prior_frame = -1
        prior_time = -1
        for sample in samples:
            if set(sample) != {"frame", "time", "position", "velocity"} or \
                    type(sample["frame"]) is not int or sample["frame"] <= prior_frame or \
                    not isinstance(sample["time"], (int, float)) or \
                    not math.isfinite(sample["time"]) or \
                    not prior_time < sample["time"] <= 30 or \
                    any(set(sample[key]) != {"x", "y", "z"} or
                        not all(isinstance(v, (int, float)) and math.isfinite(v)
                                for v in sample[key].values())
                        for key in ("position", "velocity")):
                raise ValueError("invalid ordered crowd sample")
            prior_frame = sample["frame"]
            prior_time = sample["time"]
        if planar(samples[-1]["position"], observed["sampledEnd"]) >= .04:
            raise ValueError("Unity crowd agent missed the Rusher arrival gate")
    a, b = (row["samples"] for row in trace["cases"])
    if len(a) != len(b) or any(x["frame"] != y["frame"] or x["time"] != y["time"]
                               for x, y in zip(a, b)):
        raise ValueError("crowd agents lack common simulation frames")
    separation = min(planar(x["position"], y["position"]) for x, y in zip(a, b))
    if not .34 < separation < 1:
        raise ValueError("crowd trace does not exercise safe close approach")
    return {
        "version": 1,
        "unityVersion": "2018.3.0f2",
        "pathManifestSha256": digest(CONTENT / "recovered-navmesh-path-manifest.json"),
        "navMeshSha256": map_pin["navMeshSha256"],
        "infantryPrefabSha256": settings["infantryAgent"]["prefabSha256"],
        "inputSha256": digest(INPUT),
        "resultSha256": digest(RESULT),
        "cases": list(IDS),
        "sampleCountPerAgent": len(a),
        "minimumPlanarSeparation": separation,
    }


def main():
    if len(sys.argv) != 2 or sys.argv[1] not in ("--check", "--write"):
        raise ValueError("usage: package_navmesh_crowd.py --check|--write")
    expected = json.dumps(validate(), indent=2) + "\n"
    if sys.argv[1] == "--write":
        MANIFEST.write_text(expected, encoding="utf-8")
    elif MANIFEST.read_text(encoding="utf-8") != expected:
        raise ValueError("NavMesh crowd manifest is stale")
    print("2 Unity crowd agents, 479 shared frames")


if __name__ == "__main__":
    main()
