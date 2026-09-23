"""Pin a Unity 2018.3 Park crowd probe from the host seed-2 stall snapshot."""

import hashlib
import json
import math
import sys
from pathlib import Path

CONTENT = Path(__file__).resolve().parents[1] / "content"
INPUT = CONTENT / "navmesh-motion/park-retarget-crowd-input.json"
RESULT = CONTENT / "navmesh-motion/park-retarget-crowd-result.json"
MANIFEST = CONTENT / "recovered-navmesh-retarget-crowd.json"
IDS = ("retarget-seed-2", "occupied-rusher-point-a", "occupied-rusher-point-b")


def load(path):
    return json.loads(path.read_text(encoding="utf-8"),
                      parse_constant=lambda value: (_ for _ in ()).throw(ValueError(value)))


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def planar(a, b):
    return math.hypot(a["x"] - b["x"], a["z"] - b["z"])


def validate():
    paths = load(CONTENT / "recovered-navmesh-path-manifest.json")
    park = next(row for row in paths["maps"] if row["scene"] ==
                "Assets/Scenes/Park_Multiplayer.unity")
    config, trace = load(INPUT), load(RESULT)
    if (config["version"], config["scene"], config["asset"]) != \
            (1, park["scene"], "Assets/NavMeshData/NavMesh_6.asset") or \
            (trace["version"], trace["scene"], trace["asset"]) != \
            (1, config["scene"], config["asset"]) or \
            tuple(row["id"] for row in config["cases"]) != IDS or \
            tuple(row["id"] for row in trace["cases"]) != IDS:
        raise ValueError("retarget crowd identity differs from Park source")
    if [row["stationary"] for row in config["cases"]] != [False, True, True] or \
            any(row["speed"] != .9 or row["delayFrames"] != 0
                for row in config["cases"]):
        raise ValueError("retarget crowd agent settings differ")
    for expected, observed in zip(config["cases"], trace["cases"]):
        if observed["status"] != ("Stationary" if expected["stationary"] else "Arrived") or \
                planar(observed["sampledStart"], expected["start"]) > .002 or \
                planar(observed["sampledEnd"], expected["end"]) > .002:
            raise ValueError("Unity retarget crowd endpoint or status differs")
        samples = observed["samples"]
        if len(samples) < 60 or len(samples) > 900 or \
                observed["spawnFrame"] != samples[0]["frame"]:
            raise ValueError("Unity retarget crowd samples are incomplete")
        frame, time = -1, -1.0
        for sample in samples:
            if set(sample) != {"frame", "time", "position", "velocity"} or \
                    type(sample["frame"]) is not int or sample["frame"] <= frame or \
                    not isinstance(sample["time"], (float, int)) or \
                    not math.isfinite(sample["time"]) or not time < sample["time"] <= 30 or \
                    any(set(sample[key]) != {"x", "y", "z"} or
                        not all(isinstance(v, (float, int)) and math.isfinite(v)
                                for v in sample[key].values())
                        for key in ("position", "velocity")):
                raise ValueError("Invalid ordered Unity retarget crowd sample")
            frame, time = sample["frame"], sample["time"]
    samples = [row["samples"] for row in trace["cases"]]
    if len({len(rows) for rows in samples}) != 1 or any(
            len({rows[i]["frame"] for rows in samples}) != 1 or
            len({rows[i]["time"] for rows in samples}) != 1
            for i in range(len(samples[0]))):
        raise ValueError("Unity retarget agents lack shared simulation frames")
    if planar(samples[0][-1]["position"], trace["cases"][0]["sampledEnd"]) >= .04:
        raise ValueError("Unity retarget agent did not arrive")
    gaps = [min(planar(a["position"], b["position"])
                for a, b in zip(samples[0], rows)) for rows in samples[1:]]
    if any(not .335 < gap < .5 for gap in gaps):
        raise ValueError("Unity retarget probe lost its radius-bound encounter")
    return {
        "version": 1,
        "unityVersion": "2018.3.0f2",
        "provenance": "host-seed-2-stall-snapshot-not-original-client-route",
        "pathManifestSha256": digest(CONTENT / "recovered-navmesh-path-manifest.json"),
        "navMeshSha256": park["navMeshSha256"],
        "inputSha256": digest(INPUT),
        "resultSha256": digest(RESULT),
        "cases": list(IDS),
        "sampleCountPerAgent": len(samples[0]),
        "movingArrivalSeconds": samples[0][-1]["time"],
        "minimumPlanarSeparations": gaps,
        "movingMinX": min(row["position"]["x"] for row in samples[0]),
    }


def main():
    if len(sys.argv) != 2 or sys.argv[1] not in ("--write", "--check"):
        raise ValueError("usage: package_navmesh_retarget_crowd.py --write|--check")
    expected = json.dumps(validate(), indent=2) + "\n"
    if sys.argv[1] == "--write":
        MANIFEST.write_text(expected, encoding="utf-8")
    elif MANIFEST.read_text(encoding="utf-8") != expected:
        raise ValueError("NavMesh retarget crowd manifest is stale")
    print("3 Unity Park crowd agents, host retarget snapshot pinned")


if __name__ == "__main__":
    main()
