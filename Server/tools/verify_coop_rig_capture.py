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


def validate_scenario(scenario, require_mixer_parity=False):
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
        replay = frame["replay"]
        require(replay["transforms"] == len(rows), "Replay did not compare the complete hierarchy.")
        for field, tolerance in (("positionError", 0.00001), ("rotationError", 0.000001),
                                 ("relativeScaleError", 0.00001)):
            value = replay[field]
            require(type(value) in (int, float) and math.isfinite(value) and value >= 0,
                    "Invalid independent mixer measurement: " + field)
            if require_mixer_parity:
                require(value <= tolerance, "Independent mixer replay exceeds tolerance: " + field)
        manual_replay = frame.get("manualSampleReplay")
        if manual_replay is not None:
            require(frame is frames[-1], "Manual source resampling must occur only after the final observation.")
            require(manual_replay["transforms"] == len(rows), "Incomplete manual source comparison.")
            for field in ("positionError", "rotationError", "relativeScaleError"):
                value = manual_replay[field]
                require(type(value) in (int, float) and math.isfinite(value) and value >= 0,
                        "Invalid manual source measurement.")
        for state in frame["rig"]["states"]:
            for field in ("time", "normalizedTime", "weight", "speed"):
                value = state[field]
                require(type(value) in (int, float) and math.isfinite(value), "Invalid mixer scalar.")
            require(0 <= state["weight"] <= 1.0001, "Invalid mixer weight.")
            has_fire |= state["name"].startswith(scenario["fireClip"]) and state["weight"] > 0
    require(has_pose_change and has_fire, "The capture did not reach a moving firing pose.")
    return len(frames), len(expected_paths)


def validate_queue_control(scenario):
    has_ordinary_queue_mismatch = False
    for frame in scenario["frames"]:
        control = frame["ordinaryQueueControl"]
        base_control = frame["ordinaryBaseControl"]
        require(control["transforms"] == len(frame["rig"]["transforms"]), "Incomplete ordinary-queue control.")
        require(base_control["transforms"] == len(frame["rig"]["transforms"]), "Incomplete original-name control.")
        require(frame["replay"]["clipIdentitiesMatch"] is True and base_control["clipIdentitiesMatch"] is True,
                "Accepted replay must preserve the actual source clip objects.")
        for field, tolerance in (("positionError", 0.00001), ("rotationError", 0.000001),
                                 ("relativeScaleError", 0.00001)):
            value = base_control[field]
            require(type(value) in (int, float) and math.isfinite(value) and 0 <= value <= tolerance,
                    "Original-name ordinary state failed mixer equivalence.")
        for field in ("positionError", "rotationError", "relativeScaleError"):
            value = control[field]
            require(type(value) in (int, float) and math.isfinite(value) and value >= 0,
                    "Invalid ordinary-queue control measurement.")
        has_queued_state = any(state["name"].endswith(" - Queued Clone") for state in frame["rig"]["states"])
        if has_queued_state:
            require(control["clipIdentitiesMatch"] is False, "The renamed-alias control did not create a distinct clip.")
        has_ordinary_queue_mismatch |= has_queued_state and control["rotationError"] > 0.000001
    require(has_ordinary_queue_mismatch, "The negative control did not distinguish native queued-state evaluation.")


def validate_bindings(scenario):
    clips = scenario.get("sourceBindings")
    if clips is None:
        return
    require([clip["name"] for clip in clips] ==
            [scenario["priorClip"], scenario["startClip"], scenario["fireClip"]], "Binding clip order changed.")
    rotation_properties = {"m_LocalRotation." + axis for axis in "xyzw"}
    for clip in clips:
        bindings = clip["bindings"]
        identities = [(row["path"], row["property"], row["type"]) for row in bindings]
        require(len(identities) == len(set(identities)) and len(identities) > 0, "Ambiguous curve bindings.")
        for bone in ("cartoon_guyLLegAnkle", "cartoon_guyLArm2", "cartoon_guyRArmPalm"):
            properties = {row["property"] for row in bindings if row["path"].endswith("/" + bone)}
            require(rotation_properties <= properties, "The diagnosed bone lacks a complete quaternion binding.")


def validate_corner_volley(scenario):
    frames = scenario["frames"]
    require(len(frames) == 91, "Corner volley fixture duration changed.")
    notifications = []
    for tick, frame in enumerate(frames):
        commands = frame["commandsAfterObservation"]
        require(commands["tick"] == tick, "Corner command clock changed.")
        notifications.extend(commands["events"])
    require(notifications == [dict(kind="source-shot-notification", scheduledTick=tick, observedTick=tick)
                              for tick in (18, 24, 43)], "Corner round notification history changed.")
    side = "right" if scenario["startClip"] == "player_look_right3" else "left"
    expected = ((19, scenario["fireClip"]), (25, scenario["fireClip"]),
                (41, f"player_{side}_coverBack3"), (44, scenario["startClip"]),
                (60, f"player_{side}_coverBack3"), (90, "idle - Queued Clone"))
    for tick, name in expected:
        states = frames[tick]["rig"]["states"]
        require(any(state["name"] == name and state["weight"] > 0 for state in states),
                f"Missing corner transition at tick {tick}: {name}")
    for tick in (19, 25):
        state = next(row for row in frames[tick]["rig"]["states"] if row["name"] == scenario["fireClip"])
        require(abs(state["time"] - 1 / 30) < 0.0001, "Per-round fire restart did not take effect.")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("capture", type=Path)
    parser.add_argument("--project", type=Path, required=True)
    parser.add_argument("--require-mixer-parity", action="store_true",
                        help="Also require strict independent Animation.Sample replay equivalence.")
    arguments = parser.parse_args()
    capture_bytes = arguments.capture.read_bytes()
    if arguments.capture.suffix == ".gz":
        capture_bytes = gzip.decompress(capture_bytes)
    capture = json.loads(capture_bytes.decode("utf-8-sig"))
    require(capture["unity"] == "2018.3.0f2" and capture["captureRate"] == 30, "Unsupported probe.")
    require(capture.get("physicsFrozen") is True, "Physics must be frozen for mixer pose observations.")
    for field, relative in (("enemySha256", "Assets/GameObject/enemy.prefab"),
                            ("weaponSha256", "Assets/GameObject/AssaultRifleEnemy.prefab")):
        digest = hashlib.sha256((arguments.project / relative).read_bytes()).hexdigest()
        require(capture[field] == digest, "Source prefab digest changed.")
    scenarios = capture["scenarios"]
    require([row["startClip"] for row in scenarios] ==
            ["stand_up_begin", "player_look_right3", "player_look_left3"], "Scenario order changed.")
    if capture.get("cornerVolleyFixture") is True:
        source = arguments.project / "Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"
        require(hashlib.sha256(source.read_bytes()).hexdigest() == capture["animationControllerSha256"],
                "Recovered animation controller source changed.")
    for scenario in scenarios:
        validate_bindings(scenario)
        validate_queue_control(scenario)
        for field in ("priorClip", "startClip", "fireClip"):
            clip_path = arguments.project / "Assets/AnimationClip" / (scenario[field] + ".anim")
            require(hashlib.sha256(clip_path.read_bytes()).hexdigest() == scenario[field + "Sha256"],
                    "Source animation clip changed.")
        frames, transforms = validate_scenario(scenario, arguments.require_mixer_parity)
        if capture.get("cornerVolleyFixture") is True and scenario["startClip"] != "stand_up_begin":
            validate_corner_volley(scenario)
        print(f"PASS: {scenario['startClip']}: {frames} frames, {transforms} transforms per frame")
        maximum_rotation_error = max(frame["replay"]["rotationError"] for frame in scenario["frames"])
        print(f"Measured normalized quaternion error: {maximum_rotation_error:.9g}; parity is a separate gate")
        if arguments.require_mixer_parity:
            print("PASS: strict independent mixer parity")


if __name__ == "__main__":
    main()
