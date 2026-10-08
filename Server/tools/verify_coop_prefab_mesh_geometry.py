"""Verify the six Unity-exported co-op prefab meshes against source assets."""

import json
import math
from pathlib import Path

from verify_coop_mesh_geometry import digest, source_meshes


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
COLLIDERS = ROOT / "Server/content/recovered-coop-prefab-colliders.json"
GEOMETRY = ROOT / "Server/content/recovered-coop-prefab-mesh-geometry.json"


def verify():
    colliders = json.loads(COLLIDERS.read_bytes())
    geometry = json.loads(GEOMETRY.read_bytes())
    if set(geometry) != {"version", "client", "unity",
                         "colliderSourceSha256", "meshes"} or \
            geometry["version"] != 1 or geometry["client"] != "1.4.0" or \
            geometry["unity"] != "2018.3.0f2" or \
            geometry["colliderSourceSha256"] != digest(COLLIDERS):
        raise ValueError("co-op prefab mesh provenance changed")

    expected = {row["shape"]["meshGuid"]
                for prefab in colliders["prefabs"]
                for row in prefab["colliders"]
                if row["componentType"] == "MeshCollider" and
                row["shape"]["meshFileId"] == 4300000}
    meshes = geometry["meshes"]
    if len(expected) != 6 or len(meshes) != 6 or \
            [mesh["guid"] for mesh in meshes] != sorted(expected):
        raise ValueError("co-op prefab mesh identities changed")

    assets = source_meshes()
    vertex_count = triangle_count = 0
    for mesh in meshes:
        if set(mesh) != {"guid", "fileId", "source", "sourceSha256",
                         "vertices", "triangles"} or mesh["fileId"] != 4300000:
            raise ValueError("co-op prefab mesh has unexpected fields")
        path = assets.get(mesh["guid"])
        if path is None or \
                path.relative_to(ASSETS).as_posix() != \
                mesh["source"].removeprefix("Assets/") or \
                digest(path) != mesh["sourceSha256"]:
            raise ValueError(f"co-op prefab source mesh changed: {mesh['guid']}")
        vertices = mesh["vertices"]
        triangles = mesh["triangles"]
        if not 3 <= len(vertices) <= 100_000 or \
                not 3 <= len(triangles) <= 300_000 or len(triangles) % 3:
            raise ValueError("co-op prefab mesh geometry size changed")
        for vertex in vertices:
            if len(vertex) != 3 or any(
                    not isinstance(value, (int, float)) or
                    not math.isfinite(value) or abs(value) >= 10_000
                    for value in vertex):
                raise ValueError("co-op prefab mesh vertex is invalid")
        if any(not isinstance(index, int) or isinstance(index, bool) or
               index < 0 or index >= len(vertices) for index in triangles):
            raise ValueError("co-op prefab mesh triangle is invalid")
        vertex_count += len(vertices)
        triangle_count += len(triangles) // 3
    if vertex_count != 176 or triangle_count != 284:
        raise ValueError("co-op prefab mesh geometry count changed")
    print(f"{len(meshes)} prefab meshes, {vertex_count} vertices, "
          f"{triangle_count} triangles")


if __name__ == "__main__":
    verify()
