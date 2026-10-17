"""Verify observed position/scale preservation as a candidate, not implemented host interruption support."""

import gzip
import json

from verify_coop_obstacle_gameplay_rig import ROOT, digest, require
from verify_coop_obstacle_interruption_controls import REPORT_HASH as CONTROLS_HASH, exceeds, main as verify_controls

REPORT = ROOT / "Server/content/coop-obstacle-pose-override-reference.json.gz"
REPORT_HASH = "1c3e4e10e41f0b371aa504051dbe18331f9530ed1a2e72900b7cfb450c3db9d8"
POSITION_AND_SCALE_FLOAT_COUNT = 6
FLOAT_BYTES = 4
EXPECTED_COUNTS = [19, 20, 0, 0, 0, 0, 21, 21, 21, 21, 21, 21]


def verify():
    verify_controls()
    require(digest(REPORT) == REPORT_HASH, "Reviewed override evidence changed.")
    report = json.loads(gzip.decompress(REPORT.read_bytes()))
    require(report["unity"] == "2018.3.0f2" and report["referenceSha256"] == CONTROLS_HASH,
            "Override replay used another calibration fixture.")
    require(report["auditSha256"] == digest(ROOT / "Server/tools/UnityCoopObstaclePoseOverrideAudit.cs"),
            "Override audit implementation changed.")
    require(report["samplerSha256"] == digest(ROOT /
            "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs"),
            "Production sampler changed.")
    controls = json.loads(gzip.decompress((ROOT /
        "Server/content/coop-obstacle-interruption-controls.json.gz").read_bytes()))
    first, second = controls["manualAt2"]["samples"][-1]["scenarios"][:2]
    require(first["rig"]["states"] == second["rig"]["states"] and
            first["rig"]["transforms"] != second["rig"]["transforms"],
            "The fixture must retain the same-state, different-history counterexample.")
    require(len(report["cases"]) == 12, "Incomplete independent override comparisons.")
    before_failures = 0
    for index, case in enumerate(report["cases"]):
        require(case["overrideCount"] == EXPECTED_COUNTS[index] and
                case["floatPayloadBytes"] == case["overrideCount"] * POSITION_AND_SCALE_FLOAT_COUNT * FLOAT_BYTES,
                "Observed override shape or raw float budget changed.")
        require(case["before"]["transforms"] == case["after"]["transforms"] == 59,
                "Override comparison lost part of the hierarchy.")
        before_failures += int(exceeds(case["before"]))
        require(not exceeds(case["after"]) and case["after"] == case["replay"],
                "Observed pose preservation exceeds unchanged tolerances or is not replay-stable.")
    require(before_failures == 6, "The candidate must cover the same six failing automatic observations.")
    print("PASS: twelve independent source-observed position/scale overrides; maximum 504 raw float bytes")
    print("UNIMPLEMENTED: complete phase catalog, host selection, SDK/transport integration and gameplay proof")


if __name__ == "__main__":
    verify()
