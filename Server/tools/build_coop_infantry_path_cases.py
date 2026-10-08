"""Build source-backed Assaulter spawn-to-point cases for Unity NavMesh probes."""

from __future__ import annotations

import argparse
import json
import math
from pathlib import Path


CONTENT = Path(__file__).resolve().parents[1] / "content"
OUTPUT = CONTENT / "coop-infantry-normal-spawn-path-input.json"


def read(name: str) -> dict:
    return json.loads((CONTENT / name).read_text(encoding="utf-8"))


def vector(value: list[float]) -> dict[str, float]:
    return dict(zip(("x", "y", "z"), value, strict=True))


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true")
    arguments = parser.parse_args()

    missions = read("recovered-mission-catalog.json")["missions"]
    spawn_maps = read("recovered-coop-spawn-points.json")["maps"]
    point_maps = read("recovered-coop-enemy-points.json")["maps"]
    nav_maps = read("recovered-coop-navmesh-sources.json")["maps"]
    masks = read("recovered-coop-enemy-point-masks.json")["soldiers"]
    assaulter = next(row for row in masks if row["behaviorType"] ==
                     "SoldierBehaviourAssaulter")
    if assaulter["enemyPointMask"] != 14:
        raise ValueError("Recovered Assaulter point mask changed")

    cases = []
    for stage in range(1, 6):
        spawns = spawn_maps[stage - 1]
        points = point_maps[stage - 1]
        nav = nav_maps[stage - 1]
        if (spawns["stage"] != stage or points["stage"] != stage or
                nav["stage"] != stage or
                spawns["sceneSha256"] != points["sceneSha256"] or
                spawns["sceneSha256"] != nav["sceneSha256"]):
            raise ValueError("Co-op source maps disagree")
        mission = next(row for row in missions if row["mapStage"] == stage and
                       row["missionType"] != "KillOpponent" and
                       any(unit["name"] == "Assaulter" for unit in
                           row["behaviours"]))
        accepted = [point for point in points["points"] if point["fraction"] == 1
                    and point["componentType"] in
                    ("EnemyPointCorner", "EnemyPointObstacle")]
        for spawn in spawns["spawnPoints"]:
            if spawn["fraction"] != 1 or spawn["componentType"] != "SpawnPoint":
                continue
            point = min(accepted, key=lambda candidate: math.dist(
                spawn["worldPosition"], candidate["worldPosition"]))
            fractions = (0.0, 0.5, 1.0) if point["positionKind"] == "segment" \
                else (0.0,)
            for fraction in fractions:
                if point["positionKind"] == "segment":
                    start = point["segment"]["start"]
                    end = point["segment"]["end"]
                    destination = [a + (b - a) * fraction for a, b in
                                   zip(start, end, strict=True)]
                else:
                    destination = point["worldPosition"]
                cases.append({
                    "stage": stage,
                    "missionIndex": mission["index"],
                    "scene": spawns["scene"],
                    "asset": nav["sourceAsset"],
                    "spawnComponentFileId": spawn["componentFileId"],
                    "pointComponentFileId": point["componentFileId"],
                    "pointPositionKind": point["positionKind"],
                    "pointFraction": fraction,
                    "start": vector(spawn["worldPosition"]),
                    "end": vector(destination),
                })

    if len(cases) != 36:
        raise ValueError(f"Expected 36 source spawn/point cases, got {len(cases)}")
    result = json.dumps({"version": 2, "cases": cases}, indent=2,
                        ensure_ascii=False).encode("utf-8") + b"\n"
    if arguments.check:
        if not OUTPUT.exists() or OUTPUT.read_bytes() != result:
            raise ValueError("Committed co-op infantry path cases differ")
        print(f"verified {len(cases)} co-op Assaulter path cases")
    else:
        OUTPUT.write_bytes(result)
        print(f"wrote {len(cases)} co-op Assaulter path cases")


if __name__ == "__main__":
    main()
