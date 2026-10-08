"""Verify the Unity-exported co-op mesh triangles against recovered assets."""

import hashlib
import json
import math
import re
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
COLLIDERS = ROOT / "Server/content/recovered-coop-scene-colliders.json"
GEOMETRY = ROOT / "Server/content/recovered-coop-mesh-geometry.json"


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def source_meshes():
    index = {}
    for meta in (ASSETS / "Mesh").glob("*.asset.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$",
                          meta.read_text(encoding="utf-8-sig"), re.M)
        if not match or match.group(1) in index:
            raise ValueError(f"invalid mesh metadata: {meta}")
        index[match.group(1)] = meta.with_suffix("")
    return index


def verify():
    colliders = json.loads(COLLIDERS.read_bytes())
    geometry = json.loads(GEOMETRY.read_bytes())
    if set(geometry) != {"version", "client", "unity",
                         "colliderSourceSha256", "meshes"} or \
            geometry["version"] != 1 or geometry["client"] != "1.4.0" or \
            geometry["unity"] != "2018.3.0f2" or \
            geometry["colliderSourceSha256"] != digest(COLLIDERS):
        raise ValueError("co-op mesh export has different source provenance")

    expected = {row["shape"]["meshGuid"]
                for scene in colliders["maps"] for row in scene["colliders"]
                if row["componentType"] == "MeshCollider" and
                row["shape"]["meshFileId"] == 4300000}
    meshes = geometry["meshes"]
    if len(expected) != 147 or len(meshes) != 147 or \
            [row["guid"] for row in meshes] != sorted(expected):
        raise ValueError("co-op mesh identities are incomplete or unordered")

    assets = source_meshes()
    vertex_count = triangle_count = 0
    for row in meshes:
        if set(row) != {"guid", "fileId", "source", "sourceSha256",
                        "vertices", "triangles"} or row["fileId"] != 4300000:
            raise ValueError("unknown co-op mesh fields or local file ID")
        path = assets.get(row["guid"])
        if path is None or path.relative_to(ASSETS).as_posix() != \
                row["source"].removeprefix("Assets/") or \
                digest(path) != row["sourceSha256"]:
            raise ValueError(f"co-op mesh asset changed: {row['guid']}")
        vertices = row["vertices"]
        triangles = row["triangles"]
        if not 3 <= len(vertices) <= 100_000 or \
                not 3 <= len(triangles) <= 300_000 or len(triangles) % 3:
            raise ValueError("co-op mesh geometry has an invalid size")
        for vertex in vertices:
            if len(vertex) != 3 or any(
                    not isinstance(value, (int, float)) or
                    not math.isfinite(value) or abs(value) >= 10_000
                    for value in vertex):
                raise ValueError("co-op mesh has an invalid vertex")
        if any(not isinstance(index, int) or isinstance(index, bool) or
               index < 0 or index >= len(vertices) for index in triangles):
            raise ValueError("co-op mesh has an invalid triangle")
        vertex_count += len(vertices)
        triangle_count += len(triangles) // 3
    if vertex_count != 14_885 or triangle_count != 13_781:
        raise ValueError("co-op mesh vertex or triangle count changed")
    print(f"{len(meshes)} source meshes, {vertex_count} vertices, "
          f"{triangle_count} triangles")


if __name__ == "__main__":
    verify()
