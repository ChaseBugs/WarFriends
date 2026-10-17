"""Validate diagnostic controls without promoting manual samples to automatic-pose parity."""

import gzip
import json
import math

from verify_coop_obstacle_gameplay_rig import ROOT, digest, require
from verify_coop_obstacle_interruption import CAPTURE_HASH, EXPECTED_MISMATCHES, LIMITS, verify

REPORT = ROOT / "Server/content/coop-obstacle-interruption-controls.json.gz"
REPORT_HASH = "11037fece327e10a88f0bee545eaf480a77f2e7db1000b222b076642d1f4201b"


def exceeds(error):
    for field, limit in LIMITS.items():
        require(math.isfinite(error[field]) and error[field] >= 0, "Malformed diagnostic error.")
    return any(error[field] > limit for field, limit in LIMITS.items())


def validate_bindings(capture):
    bindings = {
        "prefabSha256": "Clients/ExportedProject/Assets/GameObject/enemy.prefab",
        "controllerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs",
        "exporterSha256": "Server/tools/UnityCoopObstacleCleanInterruptionExport.cs",
        "probeSha256": "Server/tools/UnityCoopObstacleOnlyProbe.cs",
    }
    for field, path in bindings.items():
        require(capture[field] == digest(ROOT / path), "Clean control binding changed: " + field)
    require(capture["controllerUpdateInvoked"] is False and capture["unity"] == "2018.3.0f2",
            "The isolated source lifecycle changed.")


def validate_manual(capture, final_tick):
    validate_bindings(capture)
    require(capture["samplesSourceManually"] is True and capture["manualFinalTick"] == final_tick and
            len(capture["samples"]) == final_tick + 1, "Manual evaluation must terminate the observation.")
    affected = 0
    for sample in capture["samples"]:
        for scenario in sample["scenarios"]:
            if sample["tick"] != final_tick:
                require(scenario["manualRig"] is None and scenario["manualReplay"] is None,
                        "Manual evaluation contaminated an earlier source frame.")
                continue
            require(scenario["rig"]["states"] == scenario["manualRig"]["states"],
                    "The manual control changed visible clocks or mixer state.")
            require(not exceeds(scenario["manualReplay"]), "Manual source/replay still disagree.")
            if exceeds(scenario["replay"]):
                affected += 1
                require(scenario["rig"]["transforms"] != scenario["manualRig"]["transforms"],
                        "The failing automatic pose did not change under source Sample.")
    return affected


def main():
    verify(False)
    require(digest(REPORT) == REPORT_HASH, "Reviewed controls changed.")
    controls = json.loads(gzip.decompress(REPORT.read_bytes()))
    times = controls["timeReplay"]
    require(times["referenceSha256"] == CAPTURE_HASH, "Time controls used another fixture.")
    require(times["auditSha256"] == digest(ROOT / "Server/tools/UnityCoopObstacleTimeReplayAudit.cs"),
            "Time control implementation changed.")
    modes = [result["mode"] for result in times["results"]]
    require(modes == ["recorded-time", "normalized-product", "ulp-down", "ulp-up"], "Missing time control.")
    for result in times["results"]:
        require(len(result["frames"]) == 78, "Incomplete time comparison.")
        require({frame["tick"] for frame in result["frames"] if exceeds(frame)} == EXPECTED_MISMATCHES,
                "A time control changed the counterexample; re-review the evidence.")
    clean = controls["clean"]
    validate_bindings(clean)
    require(clean["samplesSourceManually"] is False and len(clean["samples"]) == 13,
            "Clean automatic source capture is incomplete.")
    failures = {(scenario_index * 13 + sample["tick"]) for sample in clean["samples"]
                for scenario_index, scenario in enumerate(sample["scenarios"]) if exceeds(scenario["replay"])}
    require(failures == EXPECTED_MISMATCHES, "Removing prior corner initialization changed the result.")
    require(validate_manual(controls["manualAt1"], 1) + validate_manual(controls["manualAt2"], 2) == 6,
            "Manual controls must cover all six failing automatic observations.")
    print("PASS: four time controls and obstacle-only initialization retain the counterexample")
    print("PASS: twelve final source Sample controls preserve mixer state and agree with manual replay")
    print("NOT PARITY: the six automatic observations remain the promotion target")


if __name__ == "__main__":
    main()
