"""Verify every discrete return phase and independent source-observed pose reconstruction."""

import gzip
import json
import math

from verify_coop_obstacle_gameplay_rig import ROOT, digest, require
from verify_coop_obstacle_interruption_controls import exceeds

CONTENT = ROOT / "Server/content"
SOURCE = CONTENT / "coop-obstacle-fixed-step-reference.json.gz"
REPLAY = CONTENT / "coop-obstacle-fixed-step-replay-reference.json.gz"
SOURCE_HASH = "f1f062324d04c7a3e816984ad6edc4fa26f44a568fb3351b3418b575b181ce47"
REPLAY_HASH = "82e78ac8ab0b1aa6de152f524e844d8838c3ea9052355cbb8b2cfb6509b8258e"
PHASES = 17
OBSERVATIONS = 13
FIRST_FIRE = (2, 2, 2, 2, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 7)


def read_verified():
    require(digest(SOURCE) == SOURCE_HASH and digest(REPLAY) == REPLAY_HASH, "Fixed-step evidence bytes changed.")
    source = json.loads(gzip.decompress(SOURCE.read_bytes()))
    replay = json.loads(gzip.decompress(REPLAY.read_bytes()))
    validate_bindings(source, replay)
    require(len(source["samples"]) == len(replay["cases"]) == PHASES * OBSERVATIONS, "Incomplete phase matrix.")
    failures = set()
    for index, (frame, result) in enumerate(zip(source["samples"], replay["cases"])):
        phase, step = index % PHASES, index // PHASES
        require((frame["priorReturnTicks"], frame["observationTick"]) == (phase, step) and
                (result["priorReturnTicks"], result["observationTick"]) == (phase, step), "Phase order differs.")
        validate_frame(frame, result)
        reconstruction = result["reconstruction"]
        if exceeds(reconstruction["before"]):
            failures.add((phase, step))
        require(not exceeds(reconstruction["after"]) and reconstruction["after"] == reconstruction["replay"],
                "Observed pose reconstruction exceeds limits or changes on replay.")
    expected = {(phase, 1) for phase in (2, 3, 4)} | {(phase, 2) for phase in range(2, PHASES)}
    require(failures == expected, "The complete clip-only counterexample changed.")
    for phase, first in enumerate(FIRST_FIRE):
        rows = [row for row in source["samples"] if row["priorReturnTicks"] == phase]
        observed = next(row["observationTick"] for row in rows if any(
            state["clipName"] == "rifle_shot_loop" for state in row["rig"]["states"]))
        require(observed == first, "Queued-fire transition changed.")
    print("PASS: 221 source/reconstruction pairs; all 17 fixed-step return phases; 18 clip-only failures retained")
    return source, replay


def validate_bindings(source, replay):
    require(source["unity"] == replay["unity"] == "2018.3.0f2" and source["captureRate"] == 30 and
            source["controllerUpdateInvoked"] is False and replay["referenceSha256"] == SOURCE_HASH,
            "Unsupported phase, clock or replay reference.")
    source_paths = {
        "prefabSha256": "Clients/ExportedProject/Assets/GameObject/enemy.prefab",
        "controllerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs",
        "exporterSha256": "Server/tools/UnityCoopObstacleFixedStepExport.cs",
        "builderSha256": "Server/tools/UnityCoopObstacleCleanInterruptionExport.cs",
        "probeSha256": "Server/tools/UnityCoopObstacleOnlyProbe.cs",
    }
    replay_paths = {
        "auditSha256": "Server/tools/UnityCoopObstacleFixedStepReplayAudit.cs",
        "freshAuditSha256": "Server/tools/UnityCoopObstacleFreshReplayAudit.cs",
        "overrideAuditSha256": "Server/tools/UnityCoopObstaclePoseOverrideAudit.cs",
        "samplerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs",
    }
    require(set(source["clipSha256"]) == {"stand_up_crawl", "stand_up_begin", "rifle_shot_loop"},
            "Incomplete animation clip binding.")
    for clip, expected in source["clipSha256"].items():
        require(expected == digest(ROOT / "Clients/ExportedProject/Assets/AnimationClip" / (clip + ".anim")),
                "A recovered animation clip changed.")
    for report, paths in ((source, source_paths), (replay, replay_paths)):
        for field, path in paths.items():
            require(report[field] == digest(ROOT / path), "Fixed-step source binding changed: " + field)


def validate_frame(frame, result):
    expected = frame["rig"]["transforms"]
    basis = result["basis"]["transforms"]
    require(len(expected) == len(basis) == 59 and len({row["path"] for row in expected}) == 59,
            "The complete source hierarchy is required.")
    changed = 0
    for original, sampled in zip(expected, basis):
        require(original["path"] == sampled["path"], "Independent basis hierarchy differs.")
        for field, length in (("position", 3), ("rotation", 4), ("scale", 3)):
            require(len(original[field]) == len(sampled[field]) == length and
                    all(math.isfinite(value) for value in original[field] + sampled[field]),
                    "Malformed transform channel.")
        changed += int(original["path"] != "root" and
                       (original["position"] != sampled["position"] or original["scale"] != sampled["scale"]))
    reconstruction = result["reconstruction"]
    require(changed == reconstruction["overrideCount"] <= 21 and
            reconstruction["floatPayloadBytes"] == changed * 24 and
            reconstruction["before"]["transforms"] == reconstruction["after"]["transforms"] == 59,
            "Source override selection or byte accounting differs.")


if __name__ == "__main__":
    read_verified()
