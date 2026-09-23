"""Validate and pin Unity 2018 infantry NavMeshAgent traces."""

import hashlib
import json
import math
import sys
from pathlib import Path

CONTENT = Path(__file__).resolve().parents[1] / "content"
MANIFEST = CONTENT / "recovered-navmesh-motion.json"
FIXTURES = ((0, "aztec", "2675-2698", 1.0),
            (1, "city", "2950-2826", 1.0),
            (1, "city", "3296-3089", 1.0),
            (2, "desert", "2499-2833", 1.0),
            (3, "park", "3251-3429", 1.0),
            (3, "park-08", "3251-3429", .8),
            (3, "park-09", "3251-3429", .9),
            (4, "snow", "2680-2949", 1.0))


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def load(path):
    return json.loads(path.read_text(encoding="utf-8"),
                      parse_constant=lambda value: (_ for _ in ()).throw(ValueError(value)))


def validate():
    route_manifest = load(CONTENT / "recovered-navmesh-path-manifest.json")
    nav = load(CONTENT / "recovered-army-navmesh-sources.json")
    deployment = load(CONTENT / "recovered-army-deployment.json")
    infantry_speeds = {row["movementSpeed"] for row in deployment["families"]
                       if row["isSoldier"] and not row["isAir"]}
    if infantry_speeds != {.8, .9, 1.0}:
        raise ValueError("unexpected source infantry speed set")
    if route_manifest["unityVersion"] != "2018.3.0f2" or len(route_manifest["maps"]) != 5:
        raise ValueError("unexpected Unity path export")
    fixtures = []
    for map_index, name, case_id, speed in FIXTURES:
        if speed not in infantry_speeds:
            raise ValueError("motion speed has no source infantry family")
        map_pin = route_manifest["maps"][map_index]
        scene = map_pin["scene"]
        if name.split("-")[0] not in scene.lower() or map_pin["navMeshSha256"] != next(
                row["navMeshSha256"] for row in nav["maps"] if row["scene"] == scene):
            raise ValueError("NavMesh source binding differs")
        path_results = load(CONTENT / "navmesh-path-results" / map_pin["file"])
        expected = next(row for row in path_results["cases"] if row["id"] == case_id)
        asset = f"Assets/NavMeshData/{Path(map_pin['file']).stem}.asset"
        relative = f"navmesh-motion/{name}-{case_id}.json"
        fixture = CONTENT / relative
        observed = load(fixture)
        if abs(observed.get("runtimeSpeed", 1.0) - speed) > 1e-6:
            raise ValueError(f"{relative}: observed runtime speed differs")
        if (observed["scene"], observed["asset"], observed["caseId"], observed["status"]) != \
                (scene, asset, case_id, "Arrived") or expected["status"] != "PathComplete":
            raise ValueError(f"{relative}: motion identity or source completion differs")
        if observed["sampledStart"] != expected["sampledStart"] or \
           observed["sampledEnd"] != expected["sampledEnd"]:
            raise ValueError(f"{relative}: route endpoints differ")
        samples = observed["samples"]
        if not 100 <= len(samples) <= 1000 or samples[0]["time"] != 0:
            raise ValueError(f"{relative}: incomplete motion trace")
        previous_time = -1
        previous_frame = -1
        for sample in samples:
            if set(sample) != {"frame", "time", "position", "velocity", "remainingDistance"} or \
               type(sample["frame"]) is not int or sample["frame"] <= previous_frame or \
               not isinstance(sample["time"], (int, float)) or \
               not math.isfinite(sample["time"]) or \
               not 0 <= sample["time"] <= 30 or sample["time"] <= previous_time or \
               any(set(sample[key]) != {"x", "y", "z"} or not all(
                   isinstance(value, (int, float)) and math.isfinite(value)
                   for value in sample[key].values()) for key in ("position", "velocity")) or \
               not isinstance(sample["remainingDistance"], (int, float)) or \
               not math.isfinite(sample["remainingDistance"]):
                raise ValueError(f"{relative}: invalid ordered Unity motion sample")
            previous_time = sample["time"]
            previous_frame = sample["frame"]
        final = samples[-1]["position"]
        end = observed["sampledEnd"]
        if math.hypot(final["x"] - end["x"], final["z"] - end["z"]) >= .04:
            raise ValueError(f"{relative}: Unity agent did not reach source arrival gate")
        fixtures.append({
            "scene": scene,
            "caseId": case_id,
            "navMeshAsset": asset,
            "navMeshSha256": map_pin["navMeshSha256"],
            "runtimeSpeed": speed,
            "perkSpeedCoefficient": 1.0,
            "sampleCount": len(samples),
            "durationSeconds": samples[-1]["time"],
            "file": relative,
            "sha256": digest(fixture),
        })
    return {
        "version": 2,
        "unityVersion": "2018.3.0f2",
        "pathManifestSha256": digest(CONTENT / "recovered-navmesh-path-manifest.json"),
        "infantryPrefabSha256": deployment["infantryAgent"]["prefabSha256"],
        "fixtures": fixtures,
    }


def main():
    if len(sys.argv) != 2 or sys.argv[1] not in ("--check", "--write"):
        raise ValueError("usage: package_navmesh_motion.py --check|--write")
    result = validate()
    expected = json.dumps(result, indent=2) + "\n"
    if sys.argv[1] == "--check":
        if MANIFEST.read_text(encoding="utf-8") != expected:
            raise ValueError("NavMesh motion manifest is stale")
    else:
        MANIFEST.write_text(expected, encoding="utf-8")
    print(f"{len(result['fixtures'])} Unity motion fixtures, "
          f"{sum(fixture['sampleCount'] for fixture in result['fixtures'])} samples")


if __name__ == "__main__":
    main()
