"""Pin Unity 2018.3 same-spawn Rusher avoidance with a nine-frame stagger."""

import hashlib
import json
import math
import sys
from pathlib import Path

CONTENT = Path(__file__).resolve().parents[1] / "content"
INPUT = CONTENT / "navmesh-motion" / "park-staggered-input.json"
RESULT = CONTENT / "navmesh-motion" / "park-staggered-result.json"
MANIFEST = CONTENT / "recovered-navmesh-staggered.json"
IDS = ("3443-3567", "3443-3177")


def load(path):
    return json.loads(path.read_text(encoding="utf-8"),
                      parse_constant=lambda value: (_ for _ in ()).throw(ValueError(value)))


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def gap(a, b):
    return math.hypot(a["x"] - b["x"], a["z"] - b["z"])


def validate():
    source = load(CONTENT / "recovered-navmesh-path-manifest.json")
    park = next(row for row in source["maps"] if row["scene"] ==
                "Assets/Scenes/Park_Multiplayer.unity")
    paths = load(CONTENT / "navmesh-path-results" / park["file"])
    input_data = load(INPUT)
    result = load(RESULT)
    if (input_data["version"], input_data["scene"], input_data["asset"]) != \
            (1, park["scene"], "Assets/NavMeshData/NavMesh_6.asset") or \
            (result["version"], result["scene"], result["asset"]) != \
            (1, input_data["scene"], input_data["asset"]) or \
            [row["id"] for row in input_data["cases"]] != list(IDS) or \
            [row["id"] for row in result["cases"]] != list(IDS) or \
            [row["delayFrames"] for row in input_data["cases"]] != [0, 9]:
        raise ValueError("staggered crowd identities or delay differ")
    for case, observed in zip(input_data["cases"], result["cases"]):
        route = next(row for row in paths["cases"] if row["id"] == case["id"])
        if case["speed"] != .9 or route["status"] != "PathComplete" or \
                case["start"] != route["sampledStart"] or \
                case["end"] != route["sampledEnd"] or \
                observed["sampledStart"] != route["sampledStart"] or \
                observed["sampledEnd"] != route["sampledEnd"] or \
                observed["status"] != "Arrived":
            raise ValueError("staggered route has no source proof")
        samples = observed["samples"]
        if not 100 <= len(samples) <= 1000 or \
                observed["spawnFrame"] != samples[0]["frame"]:
            raise ValueError("staggered sample count or spawn marker differs")
        prior_frame = -1
        prior_time = -1
        for sample in samples:
            if set(sample) != {"frame", "time", "position", "velocity"} or \
                    type(sample["frame"]) is not int or sample["frame"] <= prior_frame or \
                    not isinstance(sample["time"], (int, float)) or \
                    not math.isfinite(sample["time"]) or \
                    sample["time"] <= prior_time or sample["time"] > 30 or \
                    any(set(sample[key]) != {"x", "y", "z"} or
                        not all(isinstance(v, (int, float)) and math.isfinite(v)
                                for v in sample[key].values())
                        for key in ("position", "velocity")):
                raise ValueError("invalid ordered staggered Unity sample")
            prior_frame = sample["frame"]
            prior_time = sample["time"]
        if gap(samples[-1]["position"], observed["sampledEnd"]) >= .04:
            raise ValueError("staggered Unity agent missed arrival")
    a, b = (row["samples"] for row in result["cases"])
    if result["cases"][1]["spawnFrame"] - result["cases"][0]["spawnFrame"] != 9:
        raise ValueError("Unity agent spawn stagger is not nine frames")
    by_frame = {row["frame"]: row for row in a}
    paired = [(by_frame[row["frame"]], row) for row in b if row["frame"] in by_frame]
    initial = gap(paired[0][0]["position"], paired[0][1]["position"])
    mature = min(gap(x["position"], y["position"]) for x, y in paired
                 if x["frame"] >= result["cases"][1]["spawnFrame"] + 4)
    if not 0 < initial < .34 or not .34 < mature < 1:
        raise ValueError("Unity staggered trace does not exercise separation recovery")
    return {
        "version": 1,
        "unityVersion": "2018.3.0f2",
        "pathManifestSha256": digest(CONTENT / "recovered-navmesh-path-manifest.json"),
        "navMeshSha256": park["navMeshSha256"],
        "inputSha256": digest(INPUT),
        "resultSha256": digest(RESULT),
        "cases": list(IDS),
        "spawnDelayFrames": 9,
        "initialPlanarSeparation": initial,
        "minimumPostFourFrameSeparation": mature,
        "sampleCounts": [len(a), len(b)],
    }


def main():
    if len(sys.argv) != 2 or sys.argv[1] not in ("--check", "--write"):
        raise ValueError("usage: package_navmesh_staggered.py --check|--write")
    expected = json.dumps(validate(), indent=2) + "\n"
    if sys.argv[1] == "--write":
        MANIFEST.write_text(expected, encoding="utf-8")
    elif MANIFEST.read_text(encoding="utf-8") != expected:
        raise ValueError("NavMesh staggered manifest is stale")
    print("2 same-spawn Unity agents, 9-frame stagger")


if __name__ == "__main__":
    main()
