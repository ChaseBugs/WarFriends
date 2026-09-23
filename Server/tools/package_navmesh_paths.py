"""Pin Unity 2018 path results for source infantry spawns and opposing Rusher slots."""

import hashlib
import json
import math
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
INPUT = ROOT / "Server/.local/navmesh-path-input.json"
RESULTS = ROOT / "Server/.local/navmesh-path-output"
CASES = CONTENT / "recovered-navmesh-path-cases.json"
PACKAGE = CONTENT / "navmesh-path-results"
MANIFEST = CONTENT / "recovered-navmesh-path-manifest.json"


def digest(data):
    return hashlib.sha256(data).hexdigest()


def position(value):
    return (value["x"], value["y"], value["z"])


def valid_point(value):
    return (set(value) == {"x", "y", "z"} and
            all(isinstance(v, (int, float)) and math.isfinite(v) and abs(v) <= 10000
                for v in value.values()))


def main():
    check = sys.argv[1:] == ["--check"]
    if sys.argv[1:] and not check:
        raise ValueError("usage: package_navmesh_paths.py [--check]")
    input_bytes = INPUT.read_bytes()
    source = json.loads(input_bytes)
    navmeshes = json.loads((CONTENT / "recovered-army-navmesh-sources.json").read_bytes())["maps"]
    triangles = json.loads((CONTENT / "recovered-navmesh-triangulation.json").read_bytes())["meshes"]
    if source["version"] != 1 or len(source["maps"]) != 5:
        raise ValueError("incomplete source route probes")
    if not check:
        CASES.write_bytes(input_bytes)
        PACKAGE.mkdir(parents=True, exist_ok=True)
    elif CASES.read_bytes() != input_bytes:
        raise ValueError("packaged route cases differ from source")
    rows = []
    all_complete = all_partial = 0
    for map_input, nav, tri in zip(source["maps"], navmeshes, triangles):
        if map_input["scene"] != nav["scene"] or map_input["asset"] != nav["navMeshAsset"] \
                or tri["scene"] != nav["scene"]:
            raise ValueError("route source map binding changed")
        file = Path(nav["navMeshAsset"]).stem + ".json"
        data = (RESULTS / file).read_bytes()
        result = json.loads(data)
        if set(result) != {"scene", "asset", "cases"} or result["scene"] != nav["scene"] \
                or result["asset"] != nav["navMeshAsset"] \
                or len(result["cases"]) != len(map_input["cases"]):
            raise ValueError("Unity route result differs from source cases")
        complete = partial = 0
        for expected, actual in zip(map_input["cases"], result["cases"]):
            if set(actual) != {"id", "spawnFileId", "rusherFileId", "startSampled",
                               "endSampled", "sampledStart", "sampledEnd", "status", "corners"}:
                raise ValueError("wrong Unity route fields")
            if (actual["id"] != expected["id"] or
                    actual["spawnFileId"] != expected["spawnFileId"] or
                    actual["rusherFileId"] != expected["rusherFileId"] or
                    actual["startSampled"] is not True or actual["endSampled"] is not True or
                    actual["status"] not in ("PathComplete", "PathPartial") or
                    not 2 <= len(actual["corners"]) <= 32 or
                    not all(valid_point(p) for p in (actual["sampledStart"],
                                                     actual["sampledEnd"], *actual["corners"])) or
                    math.dist(position(expected["start"]), position(actual["sampledStart"])) > 3.01 or
                    math.dist(position(expected["end"]), position(actual["sampledEnd"])) > 3.01):
                raise ValueError("invalid Unity route result")
            if actual["status"] == "PathComplete":
                complete += 1
            else:
                partial += 1
        if check:
            if (PACKAGE / file).read_bytes() != data:
                raise ValueError("packaged Unity path results differ")
        else:
            (PACKAGE / file).write_bytes(data)
        all_complete += complete
        all_partial += partial
        rows.append({"scene": nav["scene"], "navMeshSha256": nav["navMeshSha256"],
                     "triangulationSha256": tri["sha256"], "file": file,
                     "sha256": digest(data), "cases": len(result["cases"]),
                     "complete": complete, "partial": partial})
    if all_complete != 416 or all_partial != 16:
        raise ValueError("Unity route completion evidence changed")
    encoded = (json.dumps({"version": 1, "unityVersion": "2018.3.0f2",
                           "casesSha256": digest(input_bytes), "maps": rows}, indent=2) + "\n").encode()
    if check:
        if MANIFEST.read_bytes() != encoded:
            raise ValueError("Unity route manifest differs from export")
    else:
        MANIFEST.write_bytes(encoded)
    print("packaged", all_complete, "complete and", all_partial, "partial Unity paths")


if __name__ == "__main__":
    main()
