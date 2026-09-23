"""Inspect triangle edge connectivity in the Unity-exported navigation geometry."""

import collections
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
PACKAGE = ROOT / "Server/content/navmesh-triangulation"


def audit(path):
    data = json.loads(path.read_text())
    vertices, indices = data["vertices"], data["indices"]
    count = len(indices) // 3
    exact = collections.defaultdict(list)
    for triangle in range(count):
        for edge in range(3):
            a = indices[3 * triangle + edge]
            b = indices[3 * triangle + (edge + 1) % 3]
            exact[tuple(sorted((a, b)))].append(triangle)
    welded = collections.defaultdict(list)
    keys = [tuple(round(v[c], 4) for c in ("x", "y", "z")) for v in vertices]
    for triangle in range(count):
        for edge in range(3):
            a = keys[indices[3 * triangle + edge]]
            b = keys[indices[3 * triangle + (edge + 1) % 3]]
            welded[tuple(sorted((a, b)))].append(triangle)

    def components(edges):
        parent = list(range(count))

        def root(x):
            while parent[x] != x:
                parent[x] = parent[parent[x]]
                x = parent[x]
            return x

        for triangles in edges.values():
            for other in triangles[1:]:
                parent[root(other)] = root(triangles[0])
        return collections.Counter(root(i) for i in range(count))

    raw = components(exact)
    joined = components(welded)
    print(path.name, "triangles", count, "raw components", len(raw),
          "largest", max(raw.values()), "welded components", len(joined),
          "largest", max(joined.values()), "nonmanifold edges",
          sum(len(v) > 2 for v in welded.values()))


for file in sorted(PACKAGE.glob("*.json")):
    audit(file)
