"""Package Unity 2018.3 triangulation from the disposable NavMesh export."""

import hashlib
import json
import math
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
SOURCES = ROOT / "Server/content/recovered-army-navmesh-sources.json"
UNITY_OUTPUT = ROOT / "Server/.local/navmesh-export-output"
PACKAGE = ROOT / "Server/content/navmesh-triangulation"
MANIFEST = ROOT / "Server/content/recovered-navmesh-triangulation.json"


def digest(data):
    return hashlib.sha256(data).hexdigest()


def validate(data, asset):
    row = json.loads(data)
    if set(row) != {"asset", "vertices", "indices", "areas"} or row["asset"] != asset:
        raise ValueError(f"wrong Unity triangulation identity: {asset}")
    vertices, indices, areas = row["vertices"], row["indices"], row["areas"]
    if not 100 <= len(vertices) <= 20000 or not 300 <= len(indices) <= 60000 or len(indices) % 3:
        raise ValueError(f"incomplete triangulation: {asset}")
    if len(areas) != len(indices) // 3 or any(a != 0 for a in areas):
        raise ValueError(f"unexpected NavMesh area: {asset}")
    if any(type(i) is not int or i < 0 or i >= len(vertices) for i in indices):
        raise ValueError(f"bad triangle index: {asset}")
    for point in vertices:
        if set(point) != {"x", "y", "z"} or any(
            not isinstance(point[c], (int, float)) or not math.isfinite(point[c])
            or abs(point[c]) > 10000 for c in ("x", "y", "z")
        ):
            raise ValueError(f"invalid Unity vertex: {asset}")
    return len(vertices), len(indices) // 3


def main():
    check = sys.argv[1:] == ["--check"]
    if sys.argv[1:] and not check:
        raise ValueError("usage: package_navmesh_triangulation.py [--check]")
    source = json.loads(SOURCES.read_text(encoding="utf-8"))
    if source["version"] != 1 or source["unityVersion"] != "2018.3.0f2" or len(source["maps"]) != 5:
        raise ValueError("wrong source NavMesh package")
    rows = []
    if not check:
        PACKAGE.mkdir(parents=True, exist_ok=True)
    for map_row in source["maps"]:
        name = Path(map_row["navMeshAsset"]).stem + ".json"
        data = (UNITY_OUTPUT / name).read_bytes()
        vertices, triangles = validate(data, map_row["navMeshAsset"])
        packaged = PACKAGE / name
        if check:
            if packaged.read_bytes() != data:
                raise ValueError(f"packaged triangulation differs from Unity: {name}")
        else:
            packaged.write_bytes(data)
        rows.append({
            "scene": map_row["scene"],
            "navMeshSha256": map_row["navMeshSha256"],
            "file": name,
            "sha256": digest(data),
            "vertices": vertices,
            "triangles": triangles,
        })
    output = (json.dumps({"version": 1, "unityVersion": "2018.3.0f2", "meshes": rows},
                         indent=2) + "\n").encode("utf-8")
    if check:
        if MANIFEST.read_bytes() != output:
            raise ValueError("Unity triangulation manifest differs from export")
    else:
        MANIFEST.write_bytes(output)
    print("packaged five Unity triangulations,", sum(r["triangles"] for r in rows), "triangles")


if __name__ == "__main__":
    main()
