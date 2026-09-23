"""Pin an opposing two-agent Unity 2018.3 Rusher crossing trace."""

import hashlib
import json
import math
import sys
from pathlib import Path

CONTENT = Path(__file__).resolve().parents[1] / "content"
INPUT = CONTENT / "navmesh-motion" / "park-crossing-input.json"
RESULT = CONTENT / "navmesh-motion" / "park-crossing-result.json"
MANIFEST = CONTENT / "recovered-navmesh-crossing.json"
IDS = ("3251-3551", "3547-3497")


def load(path):
    return json.loads(path.read_text(encoding="utf-8"),
                      parse_constant=lambda value: (_ for _ in ()).throw(ValueError(value)))


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def planar(a, b):
    return math.hypot(a["x"] - b["x"], a["z"] - b["z"])


def validate():
    source = load(CONTENT / "recovered-navmesh-path-manifest.json")
    park = next(row for row in source["maps"] if row["scene"] ==
                "Assets/Scenes/Park_Multiplayer.unity")
    routes = load(CONTENT / "navmesh-path-results" / park["file"])
    config = load(INPUT)
    trace = load(RESULT)
    if (config["version"], config["scene"], config["asset"]) != \
            (1, park["scene"], "Assets/NavMeshData/NavMesh_6.asset") or \
            (trace["version"], trace["scene"], trace["asset"]) != \
            (1, config["scene"], config["asset"]) or \
            [row["id"] for row in config["cases"]] != list(IDS) or \
            [row["id"] for row in trace["cases"]] != list(IDS):
        raise ValueError("opposing crossing identities differ from source")
    for expected, observed in zip(config["cases"], trace["cases"]):
        route = next(row for row in routes["cases"] if row["id"] == expected["id"])
        if expected["speed"] != .9 or expected["delayFrames"] != 0 or \
                route["status"] != "PathComplete" or \
                expected["start"] != route["sampledStart"] or \
                expected["end"] != route["sampledEnd"] or \
                observed["sampledStart"] != route["sampledStart"] or \
                observed["sampledEnd"] != route["sampledEnd"] or \
                observed["status"] != "Arrived":
            raise ValueError("crossing route or observed endpoint differs")
        samples = observed["samples"]
        if not 100 <= len(samples) <= 1000 or \
                observed["spawnFrame"] != samples[0]["frame"]:
            raise ValueError("crossing frame count or spawn marker differs")
        previous_frame = -1
        previous_time = -1
        for sample in samples:
            if set(sample) != {"frame", "time", "position", "velocity"} or \
                    type(sample["frame"]) is not int or sample["frame"] <= previous_frame or \
                    not isinstance(sample["time"], (int, float)) or \
                    not math.isfinite(sample["time"]) or \
                    not previous_time < sample["time"] <= 30 or \
                    any(set(sample[key]) != {"x", "y", "z"} or
                        not all(isinstance(v, (int, float)) and math.isfinite(v)
                                for v in sample[key].values())
                        for key in ("position", "velocity")):
                raise ValueError("invalid ordered Unity crossing sample")
            previous_frame = sample["frame"]
            previous_time = sample["time"]
        if planar(samples[-1]["position"], observed["sampledEnd"]) >= .04:
            raise ValueError("Unity crossing agent missed arrival")
    a, b = (row["samples"] for row in trace["cases"])
    if len(a) != len(b) or any(x["frame"] != y["frame"] or x["time"] != y["time"]
                               for x, y in zip(a, b)):
        raise ValueError("crossing agents lack shared simulation frames")
    closest = min(planar(x["position"], y["position"]) for x, y in zip(a, b))
    if not .34 < closest < .6:
        raise ValueError("source crossing lacks a radius-bound near encounter")
    return {
        "version": 1,
        "unityVersion": "2018.3.0f2",
        "pathManifestSha256": digest(CONTENT / "recovered-navmesh-path-manifest.json"),
        "navMeshSha256": park["navMeshSha256"],
        "inputSha256": digest(INPUT),
        "resultSha256": digest(RESULT),
        "cases": list(IDS),
        "sampleCountPerAgent": len(a),
        "minimumPlanarSeparation": closest,
    }


def main():
    if len(sys.argv) != 2 or sys.argv[1] not in ("--check", "--write"):
        raise ValueError("usage: package_navmesh_crossing.py --check|--write")
    expected = json.dumps(validate(), indent=2) + "\n"
    if sys.argv[1] == "--write":
        MANIFEST.write_text(expected, encoding="utf-8")
    elif MANIFEST.read_text(encoding="utf-8") != expected:
        raise ValueError("NavMesh crossing manifest is stale")
    print("2 opposing Unity agents, crossing trace pinned")


if __name__ == "__main__":
    main()
