"""Compare welded triangle components with Unity's 432 path statuses."""

import collections
import json
import math
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
GEOMETRY = ROOT / "Server/content/navmesh-triangulation"
RESULTS = ROOT / "Server/content/navmesh-path-results"


def components(mesh):
    vertices, indices = mesh["vertices"], mesh["indices"]
    triangles = len(indices) // 3
    parent = list(range(triangles))

    def root(x):
        while parent[x] != x:
            parent[x] = parent[parent[x]]
            x = parent[x]
        return x

    keys = [tuple(round(v[c], 4) for c in ("x", "y", "z")) for v in vertices]
    edges = collections.defaultdict(list)
    for t in range(triangles):
        for e in range(3):
            a = keys[indices[3 * t + e]]
            b = keys[indices[3 * t + (e + 1) % 3]]
            edges[tuple(sorted((a, b)))].append(t)
    for linked in edges.values():
        for other in linked[1:]:
            parent[root(other)] = root(linked[0])
    return [root(t) for t in range(triangles)]


def triangle_at(point, mesh):
    x, y, z = (point[c] for c in ("x", "y", "z"))
    vertices, indices = mesh["vertices"], mesh["indices"]
    best = None
    for t in range(len(indices) // 3):
        a, b, c = (vertices[indices[3 * t + i]] for i in range(3))
        den = (b["z"] - c["z"]) * (a["x"] - c["x"]) + (c["x"] - b["x"]) * (a["z"] - c["z"])
        if abs(den) < 1e-8:
            continue
        u = ((b["z"] - c["z"]) * (x - c["x"]) + (c["x"] - b["x"]) * (z - c["z"])) / den
        v = ((c["z"] - a["z"]) * (x - c["x"]) + (a["x"] - c["x"]) * (z - c["z"])) / den
        w = 1 - u - v
        if min(u, v, w) < -0.0005:
            continue
        height = abs(y - (u * a["y"] + v * b["y"] + w * c["y"]))
        if best is None or height < best[0]:
            best = (height, t)
    return best


for file in sorted(RESULTS.glob("*.json")):
    mesh = json.loads((GEOMETRY / file.name).read_text())
    routes = json.loads(file.read_text())["cases"]
    groups = components(mesh)
    cache = {}
    mismatches = []
    missing = 0
    for case in routes:
        located = []
        for point in (case["sampledStart"], case["sampledEnd"]):
            key = tuple(point.values())
            if key not in cache:
                cache[key] = triangle_at(point, mesh)
            located.append(cache[key])
        if any(item is None for item in located):
            missing += 1
            continue
        linked = groups[located[0][1]] == groups[located[1][1]]
        if linked != (case["status"] == "PathComplete"):
            mismatches.append((case["id"], case["status"], linked, located))
    print(file.name, "routes", len(routes), "unlocated", missing,
          "component/status mismatches", len(mismatches), mismatches[:2])
