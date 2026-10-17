"""Validate isolated full-rig observations without promoting them to combat authority."""

import argparse
import gzip
import hashlib
import json
import math
from pathlib import Path


def require(condition, message):
    if not condition:
        raise ValueError(message)


def finite_vector(values, length):
    return isinstance(values, list) and len(values) == length and all(
        type(value) in (int, float) and math.isfinite(value) for value in values
    )


def validate_scenario(scenario):
    frames = scenario["frames"]
    require(len(frames) >= 30, "The capture needs at least one second of observations.")
    expected_paths = None
    first_pose = None
    has_pose_change = False
    has_fire = False
    prior_frame = -1
    prior_seconds = -1
    for frame in frames:
        observation = frame["observation"]
        frame_number = observation["frame"]
        seconds = observation["seconds"]
        require(type(frame_number) is int and frame_number > prior_frame, "Frame order changed.")
        require(type(seconds) in (int, float) and math.isfinite(seconds), "Invalid observation clock.")
        require(seconds > prior_seconds, "Observation time did not advance.")
        if prior_frame >= 0:
            require(frame_number == prior_frame + 1, "Capture skipped an animation evaluation.")
            require(abs(seconds - prior_seconds - 1 / 30) < 0.0001, "Capture rate changed.")
        prior_frame, prior_seconds = frame_number, seconds
        rows = frame["rig"]["transforms"]
        paths = [row["path"] for row in rows]
        require(len(paths) > 20 and len(set(paths)) == len(paths), "Incomplete or ambiguous rig.")
        if expected_paths is None:
            expected_paths = paths
            first_pose = rows
        require(paths == expected_paths, "Rig hierarchy changed during playback.")
        for row in rows:
            require(finite_vector(row["position"], 3), "Invalid local position.")
            require(finite_vector(row["scale"], 3), "Invalid local scale.")
            require(finite_vector(row["rotation"], 4), "Invalid local rotation.")
            require(abs(sum(value * value for value in row["rotation"]) - 1) < 0.001,
                    "Local rotation is not normalized.")
        has_pose_change |= rows != first_pose
        for state in frame["rig"]["states"]:
            for field in ("time", "normalizedTime", "weight", "speed"):
                value = state[field]
                require(type(value) in (int, float) and math.isfinite(value), "Invalid mixer scalar.")
            require(0 <= state["weight"] <= 1.0001, "Invalid mixer weight.")
            has_fire |= state["name"].startswith(scenario["fireClip"]) and state["weight"] > 0
    require(has_pose_change and has_fire, "The capture did not reach a moving firing pose.")
    return len(frames), len(expected_paths)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("capture", type=Path)
    parser.add_argument("--project", type=Path, required=True)
    arguments = parser.parse_args()
    capture_bytes = arguments.capture.read_bytes()
    if arguments.capture.suffix == ".gz":
        capture_bytes = gzip.decompress(capture_bytes)
    capture = json.loads(capture_bytes.decode("utf-8-sig"))
    require(capture["unity"] == "2018.3.0f2" and capture["captureRate"] == 30, "Unsupported probe.")
    for field, relative in (("enemySha256", "Assets/GameObject/enemy.prefab"),
                            ("weaponSha256", "Assets/GameObject/AssaultRifleEnemy.prefab")):
        digest = hashlib.sha256((arguments.project / relative).read_bytes()).hexdigest()
        require(capture[field] == digest, "Source prefab digest changed.")
    scenarios = capture["scenarios"]
    require([row["startClip"] for row in scenarios] ==
            ["stand_up_begin", "player_look_right3", "player_look_left3"], "Scenario order changed.")
    for scenario in scenarios:
        for field in ("priorClip", "startClip", "fireClip"):
            clip_path = arguments.project / "Assets/AnimationClip" / (scenario[field] + ".anim")
            require(hashlib.sha256(clip_path.read_bytes()).hexdigest() == scenario[field + "Sha256"],
                    "Source animation clip changed.")
        frames, transforms = validate_scenario(scenario)
        print(f"PASS: {scenario['startClip']}: {frames} frames, {transforms} transforms per frame")


if __name__ == "__main__":
    main()
