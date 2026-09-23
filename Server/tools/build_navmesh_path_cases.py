"""Build Unity path probes from pinned normal infantry spawns to opposing Rusher slots."""

import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
OUTPUT = ROOT / "Server/.local/navmesh-path-input.json"


def read(name):
    return json.loads((CONTENT / name).read_text(encoding="utf-8"))["maps"]


def vector(values):
    if len(values) != 3:
        raise ValueError("wrong source world position")
    return dict(zip(("x", "y", "z"), values))


def main():
    maps = read("recovered-battle-content.json")
    spawns = read("recovered-army-spawn-points.json")
    rushers = read("recovered-army-rusher-points.json")
    navmeshes = read("recovered-army-navmesh-sources.json")
    if not len(maps) == len(spawns) == len(rushers) == len(navmeshes) == 5:
        raise ValueError("incomplete multiplayer source maps")
    result = []
    for scene, spawn_map, rusher_map, navmesh in zip(maps, spawns, rushers, navmeshes):
        source = scene["source"]
        if (spawn_map["source"] != source or rusher_map["source"] != source
                or navmesh["scene"] != source):
            raise ValueError("map source order changed")
        cases = []
        normal = [p for p in spawn_map["points"] if p["componentType"] == "SpawnPoint"]
        if not 4 <= len(normal) <= 6 or len(rusher_map["covers"]) != 8:
            raise ValueError("incomplete normal spawn or Rusher points")
        for spawn in normal:
            for cover, slots in zip(scene["points"], rusher_map["covers"]):
                if cover["sourceIndex"] != slots["sourceIndex"]:
                    raise ValueError("Rusher slot cover mismatch")
                if cover["fraction"] == spawn["fraction"]:
                    continue
                for target in slots["rusherPoints"]:
                    cases.append({
                        "id": f"{spawn['componentFileId']}-{target['componentFileId']}",
                        "spawnFileId": spawn["componentFileId"],
                        "rusherFileId": target["componentFileId"],
                        "start": vector(spawn["worldPosition"]),
                        "end": vector(target["worldPosition"]),
                    })
        if not 64 <= len(cases) <= 96 or len({c["id"] for c in cases}) != len(cases):
            raise ValueError("wrong route-case count or duplicate identity")
        result.append({"scene": source, "asset": navmesh["navMeshAsset"], "cases": cases})
    encoded = (json.dumps({"version": 1, "maps": result}, separators=(",", ":")) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("Unity path input differs from pinned source")
    elif sys.argv[1:]:
        raise ValueError("usage: build_navmesh_path_cases.py [--check]")
    else:
        OUTPUT.parent.mkdir(parents=True, exist_ok=True)
        OUTPUT.write_bytes(encoded)
    print("built", sum(len(m["cases"]) for m in result), "spawn-to-Rusher path probes")


if __name__ == "__main__":
    main()
