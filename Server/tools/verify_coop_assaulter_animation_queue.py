"""Verify the Unity Play Mode Assaulter queue trace against recovered assets."""

import hashlib
import json
import math
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
TRACE = ROOT / "Server/content/coop-assaulter-animation-queue-reference.json"
SCENARIOS = (
    ("stand_up_begin", "rifle_shot_loop", 0.05, 7, 11),
    ("player_look_right3", "player_fire_right3", 0.02, 15, 18),
    ("player_look_left3", "player_fire_left3", 0.02, 15, 18),
)


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def queued_state(frame, clip):
    matches = [state for state in frame["states"]
               if state["name"] == clip + " - Queued Clone" and state["enabled"]]
    assert len(matches) <= 1
    return matches[0] if matches else None


def main():
    trace = json.loads(TRACE.read_text())
    assert trace["version"] == 1
    assert trace["unity"] == "2018.3.0f2"
    assert trace["captureRate"] == 30
    assert trace["enemySha256"] == digest(ASSETS / "GameObject/enemy.prefab")
    assert trace["weaponSha256"] == digest(
        ASSETS / "GameObject/AssaultRifleEnemy.prefab")
    assert len(trace["scenarios"]) == len(SCENARIOS)

    samples = 0
    for scenario, (start, fire, fade, queued_frame, first_round_frame) in zip(
            trace["scenarios"], SCENARIOS):
        assert scenario["startClip"] == start
        assert scenario["fireClip"] == fire
        assert scenario["fadeSeconds"] == fade
        assert scenario["startClipSha256"] == digest(
            ASSETS / "AnimationClip" / (start + ".anim"))
        assert scenario["fireClipSha256"] == digest(
            ASSETS / "AnimationClip" / (fire + ".anim"))
        frames = scenario["frames"]
        assert len(frames) == 40
        first_queued = next(index for index, frame in enumerate(frames)
                            if queued_state(frame, fire) is not None)
        assert first_queued == queued_frame, (start, first_queued)
        assert queued_state(frames[first_round_frame], fire) is not None
        assert abs(queued_state(frames[first_round_frame], fire)["time"] -
                   (first_round_frame - queued_frame) / 30) < 0.00001

        for index, frame in enumerate(frames):
            assert abs(frame["seconds"] - index / 30) < 0.00001
            assert len(frame["position"]) == 3
            assert len(frame["rotation"]) == 4
            assert all(math.isfinite(value) and abs(value) < 5
                       for value in frame["position"])
            assert all(math.isfinite(value) for value in frame["rotation"])
            assert abs(sum(value * value for value in frame["rotation"]) - 1) < 0.001
            for state in frame["states"]:
                assert math.isfinite(state["time"])
                assert math.isfinite(state["weight"])
                assert 0 <= state["weight"] <= 1.001
            samples += 1

    print(f"PASS: {len(SCENARIOS)} source-bound Play Mode queues, "
          f"{samples} 30 Hz muzzle/state frames")


if __name__ == "__main__":
    main()
