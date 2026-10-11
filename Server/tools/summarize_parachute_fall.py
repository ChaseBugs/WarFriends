"""Summarize disposable Unity 2018 parachute traces for host comparison.

The first impulse is inferred from a change in Rigidbody linear velocity.
Edit-mode Physics.Simulate does not deliver the prefab's OnCollisionEnter
callback, so this is contact evidence rather than a callback-time oracle.
"""

import hashlib
import json
import math
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SPAWNS = ROOT / "Server/content/recovered-army-spawn-points.json"
PREFAB = ROOT / "Clients/ExportedProject/Assets/GameObject/parachute.prefab"
PHYSICS = ROOT / "Server/content/recovered-unity-physics-settings.json"
OUTPUT = ROOT / "Server/content/recovered-parachute-fall-reference.json"
STEP = 0.02
DRAG_FACTOR = 0.8
FORWARD_FORCE = 23.0
GRAVITY = -9.81


def digest(path):
    return hashlib.sha256(Path(path).read_bytes()).hexdigest()


def rounded(values):
    return [round(float(value), 6) for value in values]


def prefab_physics(path):
    text = Path(path).read_text(encoding="utf-8-sig")
    fields = ("parachuteDrag", "speed", "m_Mass", "m_Drag",
              "m_AngularDrag", "m_UseGravity", "m_IsKinematic",
              "m_CollisionDetection")
    result = {}
    for field in fields:
        values = re.findall(r"^  " + field + r": ([^\n]+)$", text, re.M)
        if len(values) != 1:
            raise ValueError("Parachute prefab has an ambiguous physics field")
        result[field] = float(values[0])
    for field in ("m_Size", "m_Center"):
        values = re.findall(r"^  " + field +
                            r": \{x: ([^,]+), y: ([^,]+), z: ([^}]+)\}$",
                            text, re.M)
        if len(values) != 2:
            raise ValueError("Parachute prefab has an ambiguous collider shape")
        result[field] = sorted(tuple(float(part) for part in row)
                               for row in values)
    return result


def physics_matches(source, imported):
    if source.keys() != imported.keys():
        return False
    for key, value in source.items():
        observed = imported[key]
        if isinstance(value, list):
            if len(value) != len(observed):
                return False
            for expected_row, observed_row in zip(sorted(value), sorted(observed)):
                if math.dist(expected_row, observed_row) > 0.000001:
                    return False
        elif abs(value - observed) > 0.000001:
            return False
    return True


def first_impulse(frames, forward):
    for previous, current in zip(frames, frames[1:]):
        expected = [
            (previous["velocity"][axis] +
             (FORWARD_FORCE * forward[axis] if axis != 1 else GRAVITY)
             * STEP) * DRAG_FACTOR
            for axis in range(3)
        ]
        residual = math.dist(expected, current["velocity"])
        if residual > 0.01:
            return previous, current, residual
    raise ValueError("Unity trace contains no collision impulse")


def summarize(path):
    trace = json.loads(Path(path).read_text(encoding="utf-8"))
    spawn_maps = json.loads(SPAWNS.read_text(encoding="utf-8"))["maps"]
    physics = json.loads(PHYSICS.read_text(encoding="utf-8"))
    parachute_mask = physics["layers"][15]["collisionMask"]
    if (trace["version"] != 1 or trace["unityVersion"] != "2018.3.0f2" or
            physics["layers"][15]["name"] != "CollideOnlyEnviroment" or
            parachute_mask != "000020c9" or
            not physics_matches(prefab_physics(PREFAB),
                                trace["prefabPhysics"]) or
            trace["fixedTimestep"] != STEP or
            trace["gravity"] != [0.0, GRAVITY, 0.0] or
            len(trace["maps"]) != 5 or len(spawn_maps) != 5):
        raise ValueError("Parachute trace provenance changed")

    accepted_maps = []
    for map_row, source_map in zip(trace["maps"], spawn_maps):
        expected = [point for point in source_map["points"]
                    if point["collection"] == "spawnPointsCollection" and
                    point["componentType"] == "SpawnPointParachute"]
        if (map_row["source"] != source_map["source"] or
                map_row["sha256"] != source_map["sha256"] or
                len(expected) != 2 or len(map_row["falls"]) != 2):
            raise ValueError("Parachute trace does not bind its map spawns")

        rows = []
        for fall, spawn in zip(map_row["falls"], expected):
            frames = fall["frames"]
            forward = fall["forward"]
            if (fall["componentFileId"] != spawn["componentFileId"] or
                    fall["fraction"] != spawn["fraction"] or
                    math.dist(fall["origin"], spawn["worldPosition"]) > 0.0001 or
                    len(frames) != 601 or
                    len(forward) != 3 or
                    abs(forward[0] - (1 if fall["fraction"] == 1 else -1)) > 0.001 or
                    abs(forward[1]) > 0.001 or abs(forward[2]) > 0.001):
                raise ValueError("Parachute trace has an invalid spawn or orientation")
            previous, impact, residual = first_impulse(frames, forward)
            if (impact["frame"] <= 300 or impact["frame"] >= 550 or
                    not 0.01 < residual < 10):
                raise ValueError("Parachute first impulse is outside source bounds")
            if impact["frame"] != fall["firstImpulseFrame"]:
                raise ValueError("Unity impulse frame disagrees with its trace")
            collision_candidates = []
            for collider in fall["nearbyAtFirstImpulse"]:
                layer = collider["layer"]
                distance = collider["distance"]
                if not 0 <= layer <= 31 or not math.isfinite(distance):
                    raise ValueError("Invalid Unity impact collider")
                if 0x20C9 & (1 << layer):
                    collision_candidates.append({
                        "path": collider["path"],
                        "type": collider["type"],
                        "layer": layer,
                        "boundsDistance": round(distance, 6),
                    })
            if not collision_candidates:
                raise ValueError("No source-collision-layer collider near impact")
            collision_candidates = collision_candidates[:5]
            rows.append({
                "spawnComponentFileId": fall["componentFileId"],
                "fraction": fall["fraction"],
                "origin": rounded(fall["origin"]),
                "forward": rounded(forward),
                "firstImpulseFrame": impact["frame"],
                "firstImpulsePosition": rounded(impact["position"]),
                "firstImpulseRotation": rounded(impact["rotation"]),
                "previousPosition": rounded(previous["position"]),
                "previousRotation": rounded(previous["rotation"]),
                "collisionCandidates": collision_candidates,
                "previousVelocity": rounded(previous["velocity"]),
                "impulseVelocity": rounded(impact["velocity"]),
                "preContactVelocitySamples": [
                    {"frame": frame,
                     "position": rounded(frames[frame]["position"]),
                     "velocity": rounded(frames[frame]["velocity"])}
                    for frame in (1, 50, 100, 200, 300)
                ],
            })
        accepted_maps.append({
            "source": map_row["source"],
            "sha256": map_row["sha256"],
            "falls": rows,
        })

    return {
        "version": 1,
        "unityVersion": trace["unityVersion"],
        "scenario": trace["scenario"],
        "rawTraceSha256": digest(path),
        "sourcePrefabSha256": digest(PREFAB),
        "physicsSettingsSha256": digest(PHYSICS),
        "parachuteCollisionMask": parachute_mask,
        "unityImportedPrefabSha256": trace["prefabSha256"],
        "prefabPhysics": prefab_physics(PREFAB),
        "fixedTimestep": STEP,
        "gravity": [0.0, GRAVITY, 0.0],
        "dragFactor": DRAG_FACTOR,
        "forwardForce": FORWARD_FORCE,
        "maps": accepted_maps,
    }


def main():
    if len(sys.argv) != 2:
        raise ValueError("usage: summarize_parachute_fall.py unity-export.json")
    summary = summarize(sys.argv[1])
    OUTPUT.write_text(json.dumps(summary, indent=2) + "\n", encoding="utf-8")
    print("Pinned", sum(len(row["falls"]) for row in summary["maps"]),
          "parachute falls")


if __name__ == "__main__":
    main()
