"""Compare native Unity collider queries with transforms observed in the same Update."""

import argparse
import json
import math
from pathlib import Path


DISTANCE_TOLERANCE = 0.00002
BODY_PATH = "/character_assault_1/global_move/cartoon_guyHub001"
HEAD_PATH = BODY_PATH + "/cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/cartoon_guySpine/cartoon_guyHub003"


def subtract(left, right):
    return [a - b for a, b in zip(left, right)]


def dot(left, right):
    return sum(a * b for a, b in zip(left, right))


def cross(left, right):
    return [
        left[1] * right[2] - left[2] * right[1],
        left[2] * right[0] - left[0] * right[2],
        left[0] * right[1] - left[1] * right[0],
    ]


def inverse_rotate(vector, rotation):
    imaginary = [-value for value in rotation[:3]]
    first = cross(imaginary, vector)
    second = cross(imaginary, first)
    return [vector[index] + 2 * (rotation[3] * first[index] + second[index]) for index in range(3)]


def sphere_distance(query, direction):
    offset = subtract(query["origin"], query["center"])
    radius = query["radius"] * max(abs(value) for value in query["scale"])
    projection = dot(offset, direction)
    discriminant = projection * projection - dot(offset, offset) + radius * radius
    if discriminant < 0:
        return None
    distance = -projection - math.sqrt(discriminant)
    return distance if distance >= 0 else None


def box_distance(query, direction):
    origin = inverse_rotate(subtract(query["origin"], query["center"]), query["rotation"])
    local_direction = inverse_rotate(direction, query["rotation"])
    near = 0.0
    far = math.inf
    for coordinate, velocity, size, scale in zip(origin, local_direction, query["size"], query["scale"]):
        extent = size * abs(scale) / 2
        if abs(velocity) < 1e-10:
            if abs(coordinate) > extent:
                return None
            continue
        first = (-extent - coordinate) / velocity
        second = (extent - coordinate) / velocity
        near = max(near, min(first, second))
        far = min(far, max(first, second))
        if near > far:
            return None
    return near


def analyze(observation, combat_only=False):
    comparisons = 0
    hit_mismatches = 0
    distance_mismatches = 0
    maximum_error = 0.0
    for sample in observation["samples"]:
        for query in sample["queries"]:
            if combat_only and query["path"] not in (BODY_PATH, HEAD_PATH):
                continue
            if not query["enabled"] or not query["active"]:
                continue
            comparisons += 1
            calculate = box_distance if query["kind"] == "box" else sphere_distance
            expected = calculate(query, observation["rayDirection"])
            expected_hit = expected is not None and expected <= observation["rayDistance"]
            if expected_hit != query["hasHit"]:
                hit_mismatches += 1
            elif expected_hit:
                error = abs(expected - query["distance"])
                maximum_error = max(maximum_error, error)
                distance_mismatches += error > DISTANCE_TOLERANCE
    return {
        "frames": len(observation["samples"]),
        "queries": comparisons,
        "hitMismatches": hit_mismatches,
        "distanceMismatches": distance_mismatches,
        "maximumDistanceError": maximum_error,
        "tolerance": DISTANCE_TOLERANCE,
    }


def compare_phases(observation, post_observation, frame_lag=0):
    post_frames = {sample["unityFrame"] + frame_lag: sample for sample in post_observation["samples"]}
    comparisons = 0
    changed = 0
    maximum_error = 0.0
    for sample in observation["samples"]:
        post_frame = post_frames.get(sample["unityFrame"])
        if post_frame is None:
            continue
        for query in sample["queries"]:
            for part in post_frame["parts"]:
                if "enemy" + query["path"] != part["path"] or query["kind"] != part["kind"]:
                    continue
                comparisons += 1
                error = max(abs(value) for value in subtract(query["rootLocalCenter"], part["center"]))
                maximum_error = max(maximum_error, error)
                changed += error > DISTANCE_TOLERANCE
    return {"comparisons": comparisons, "changedCenters": changed, "maximumCenterError": maximum_error}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("observation", type=Path)
    parser.add_argument("--post-observation", type=Path)
    arguments = parser.parse_args()
    observation = json.loads(arguments.observation.read_text(encoding="utf-8-sig"))
    if observation["version"] not in (1, 2) or not 1 <= len(observation["samples"]) <= 240:
        raise ValueError("Unsupported or empty query observation.")
    result = {"allColliders": analyze(observation), "combatParts": analyze(observation, combat_only=True)}
    if arguments.post_observation:
        post_observation = json.loads(arguments.post_observation.read_text(encoding="utf-8-sig"))
        result["phaseComparison"] = compare_phases(observation, post_observation)
        result["previousPostFrameComparison"] = compare_phases(observation, post_observation, frame_lag=1)
    print(json.dumps(result, indent=2))


if __name__ == "__main__":
    main()
