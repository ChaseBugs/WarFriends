"""Compare source-cover-primed and default-pose Unity firing queues."""

import hashlib
import json
import math
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
CONTENT = ROOT / "Server/content"
EXPECTED = (
    ("stand_up_crawl", 1.0, 7, 11),
    ("idle_1", 0.5, 15, 18),
    ("idle_1", 0.5, 15, 18),
)


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def active_fire_state(frame, fire_clip):
    matches = [state for state in frame["states"]
               if state["name"] == fire_clip + " - Queued Clone"
               and state["enabled"]]
    assert len(matches) <= 1
    return matches[0] if matches else None


def main():
    original = json.loads((CONTENT /
        "coop-assaulter-animation-queue-reference.json").read_text())
    primed = json.loads((CONTENT /
        "coop-assaulter-primed-animation-queue-reference.json").read_text())
    assert primed["version"] == original["version"] == 1
    assert primed["unity"] == original["unity"] == "2018.3.0f2"
    assert primed["captureRate"] == original["captureRate"] == 30
    assert primed["enemySha256"] == original["enemySha256"] == digest(
        ASSETS / "GameObject/enemy.prefab")
    assert primed["weaponSha256"] == original["weaponSha256"] == digest(
        ASSETS / "GameObject/AssaultRifleEnemy.prefab")
    assert len(primed["scenarios"]) == len(original["scenarios"]) == 3

    largest_prior_difference = 0.0
    compared_fire_frames = 0
    for changed, baseline, (prior, normalized_time, first_fire, first_round) in zip(
            primed["scenarios"], original["scenarios"], EXPECTED):
        assert changed["priorClip"] == prior
        assert changed["priorClipSha256"] == digest(
            ASSETS / "AnimationClip" / (prior + ".anim"))
        assert changed["priorNormalizedTime"] == normalized_time
        for key in ("startClip", "fireClip", "fadeSeconds"):
            assert changed[key] == baseline[key]
        assert len(changed["frames"]) == len(baseline["frames"]) == 40
        assert next(index for index, frame in enumerate(changed["frames"])
                    if active_fire_state(frame, changed["fireClip"])) == first_fire

        for index, (frame, reference) in enumerate(zip(
                changed["frames"], baseline["frames"])):
            assert abs(frame["seconds"] - index / 30) < 0.00001
            assert abs(frame["seconds"] - reference["seconds"]) < 0.00001
            assert len(frame["position"]) == 3 and len(frame["rotation"]) == 4
            assert all(math.isfinite(value) for value in
                       frame["position"] + frame["rotation"])
            assert abs(sum(value * value for value in frame["rotation"]) - 1) < 0.001

            difference = math.dist(frame["position"], reference["position"])
            if index < first_fire:
                largest_prior_difference = max(largest_prior_difference,
                                               difference)
            else:
                assert difference < 0.00001, (changed["startClip"], index)
                fire_state = active_fire_state(frame, changed["fireClip"])
                original_state = active_fire_state(reference, baseline["fireClip"])
                assert (fire_state is None) == (original_state is None)
                if fire_state is not None:
                    assert abs(fire_state["time"] - original_state["time"]) < 0.00001
                    compared_fire_frames += 1
            if index == first_round:
                assert active_fire_state(frame, changed["fireClip"]) is not None

    assert largest_prior_difference > 0.5
    print(f"PASS: 3 prior cover poses, {compared_fire_frames} "
          f"matching queued-fire frames; largest prior difference "
          f"{largest_prior_difference:.6f} m")


if __name__ == "__main__":
    main()
