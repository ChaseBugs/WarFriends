"""Validate Unity's co-op NavMesh triangulation and pin its source artifacts."""

import hashlib
import json
import math
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
SOURCE = CONTENT / "recovered-coop-navmesh-sources.json"
UNITY_OUTPUT = ROOT / "Server/.local/coop-navmesh-triangulation-output"
PACKAGE = CONTENT / "coop-navmesh-triangulation"
MANIFEST = CONTENT / "recovered-coop-navmesh-triangulation.json"


def digest(data):
    return hashlib.sha256(data).hexdigest()


def validate(data, asset):
    row = json.loads(data)
    if set(row) != {"asset", "vertices", "indices", "areas"} or \
            row["asset"] != asset:
        raise ValueError(f"co-op Unity mesh has wrong identity: {asset}")
    vertices = row["vertices"]
    indices = row["indices"]
    areas = row["areas"]
    if not (100 <= len(vertices) <= 30000 and
            300 <= len(indices) <= 100000 and len(indices) % 3 == 0 and
            len(areas) == len(indices) // 3):
        raise ValueError(f"co-op Unity mesh is incomplete: {asset}")
    if any(type(index) is not int or index < 0 or index >= len(vertices)
           for index in indices):
        raise ValueError(f"co-op Unity triangle index is invalid: {asset}")
    if any(type(area) is not int or area != 0 for area in areas):
        raise ValueError(f"co-op Unity mesh has an unexpected walk area: {asset}")
    for vertex in vertices:
        if set(vertex) != {"x", "y", "z"} or any(
                not isinstance(vertex[axis], (float, int)) or
                not math.isfinite(vertex[axis]) or
                abs(vertex[axis]) > 10000 for axis in "xyz"):
            raise ValueError(f"co-op Unity vertex is invalid: {asset}")
    return len(vertices), len(indices) // 3


def main():
    check = sys.argv[1:] == ["--check"]
    if sys.argv[1:] and not check:
        raise ValueError("usage: package_coop_navmesh_triangulation.py [--check]")
    source_bytes = SOURCE.read_bytes()
    source = json.loads(source_bytes)
    if source["version"] != 1 or len(source["maps"]) != 5:
        raise ValueError("co-op NavMesh source manifest is incomplete")
    if not check:
        PACKAGE.mkdir(parents=True, exist_ok=True)

    rows = []
    for map_source in source["maps"]:
        name = Path(map_source["packagedAsset"]).stem + ".json"
        packaged = PACKAGE / name
        unity_file = UNITY_OUTPUT / name
        data = packaged.read_bytes() if check else unity_file.read_bytes()
        asset = map_source["sourceAsset"]
        vertices, triangles = validate(data, asset)
        if check:
            if unity_file.exists() and unity_file.read_bytes() != data:
                raise ValueError(f"packaged co-op mesh differs from Unity: {name}")
        else:
            packaged.write_bytes(data)
        rows.append({
            "stage": map_source["stage"],
            "scene": map_source["scene"],
            "sceneSha256": map_source["sceneSha256"],
            "navMeshSha256": map_source["sha256"],
            "file": name,
            "sha256": digest(data),
            "vertices": vertices,
            "triangles": triangles,
        })

    manifest = {
        "version": 1,
        "unityVersion": "2018.3.0f2",
        "navigationSourceSha256": digest(source_bytes),
        "maps": rows,
    }
    encoded = (json.dumps(manifest, indent=2) + "\n").encode()
    if check:
        if MANIFEST.read_bytes() != encoded:
            raise ValueError("co-op triangulation manifest differs from package")
    else:
        MANIFEST.write_bytes(encoded)
    print(f"five co-op Unity meshes, {sum(row['triangles'] for row in rows)} triangles")


if __name__ == "__main__":
    main()
