"""Validate interruption evidence; --require-parity fails while the recorded mismatch remains."""

import argparse
import gzip
import json
import math

from verify_coop_obstacle_gameplay_rig import ROOT, digest, require

CONTENT = ROOT / "Server/content"
CAPTURE = CONTENT / "coop-obstacle-interruption-rig-reference.json.gz"
FRESH = CONTENT / "coop-obstacle-interruption-fresh-reference.json.gz"
CAPTURE_HASH = "9a42a29e46adb448c7a5651a0887c0cca278ba5caac72b042d899b4856580990"
FRESH_HASH = "bd6de771c21fb37b34e8aa132429f0b7bcaf6c85d178d11e69efe4d117d5c7e3"
FRACTIONS = (0, 0.25, 0.5, 0.75, 1, 2)
FIRST_FIRE = (2, 2, 3, 5, 7, 7)
EXPECTED_MISMATCHES = {14, 15, 28, 41, 54, 67}
LIMITS = {"maximumPositionError": 0.00001, "maximumRotationError": 0.000001, "maximumScaleError": 0.00001}


def verify(require_parity):
    require(digest(CAPTURE) == CAPTURE_HASH and digest(FRESH) == FRESH_HASH, "Reviewed evidence bytes changed.")
    capture = json.loads(gzip.decompress(CAPTURE.read_bytes()))
    fresh = json.loads(gzip.decompress(FRESH.read_bytes()))
    require(capture["unity"] == fresh["unity"] == "2018.3.0f2" and capture["captureRate"] == 30 and
            capture["controllerUpdateInvoked"] is False, "Unsupported observation phase.")
    require(fresh["referenceSha256"] == CAPTURE_HASH, "Fresh replay used another source capture.")
    bindings = {
        "prefabSha256": "Clients/ExportedProject/Assets/GameObject/enemy.prefab",
        "controllerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs",
        "exporterSha256": "Server/tools/UnityCoopObstacleInterruptionExport.cs",
    }
    for field, path in bindings.items():
        require(capture[field] == digest(ROOT / path), "Source binding changed: " + field)
    require(fresh["auditSha256"] == digest(ROOT / "Server/tools/UnityCoopObstacleFreshReplayAudit.cs"),
            "Independent replay implementation changed.")
    require(fresh["samplerSha256"] == digest(ROOT /
            "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs"),
            "Production sampler changed.")
    samples = capture["samples"]
    require(len(samples) == len(fresh["frames"]) == 78, "Incomplete interruption fixture.")
    for index, fraction in enumerate(FRACTIONS):
        rows = samples[index * 13:(index + 1) * 13]
        require(all(row["scenario"] == index and row["returnFraction"] == fraction and
                    row["observationTick"] == tick for tick, row in enumerate(rows)), "Scenario order changed.")
        begin = next(state for state in rows[0]["rig"]["states"] if state["clipName"] == "stand_up_begin")
        expected = (1 - min(1, fraction)) * begin["clipLength"]
        require(abs(begin["time"] - expected) < 0.000001, "Source clamped reversal changed.")
        first = next(tick for tick, row in enumerate(rows) if any(
            state["clipName"] == "rifle_shot_loop" for state in row["rig"]["states"]))
        require(first == FIRST_FIRE[index], "Source queued-fire transition changed.")
    mismatches = set()
    for index, frame in enumerate(fresh["frames"]):
        require(frame["tick"] == index and frame["transforms"] == 59, "Replay hierarchy or order changed.")
        for field, limit in LIMITS.items():
            require(math.isfinite(frame[field]) and frame[field] >= 0, "Malformed error measurement.")
            if frame[field] > limit:
                mismatches.add(index)
    require(mismatches == EXPECTED_MISMATCHES, "The known counterexample changed; re-review source evidence.")
    print("PASS: 78 interruption observations, six reversed phases and independent replay provenance")
    print("NOT PARITY: six frames exceed unchanged tolerances:", sorted(mismatches))
    require(not require_parity or not mismatches, "Interruption presentation is not ready for promotion.")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--require-parity", action="store_true")
    verify(parser.parse_args().require_parity)
