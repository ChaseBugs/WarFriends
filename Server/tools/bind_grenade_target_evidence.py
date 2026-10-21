"""Bind native grenade target evidence without trusting a report or revision alone."""
import json

import recapture_grenade_targets as targets
from test_artifacts import checked_run, has_links, read_manifest

digest = targets.capture.digest
FILES = {"grenade-target-results.json": "results.json",
         "grenade-target-inventory.json": "source-inventory.json",
         "grenade-target-exporter.cs": targets.EXPORTER,
         "grenade-target-native.json": targets.OUTPUT}


def validate_evidence(evidence, scene):
    report = json.loads(evidence["grenade-target-results.json"])
    if report.get("nativeExportVerified") is not True or report["sourceSceneSha256"] != digest(scene):
        raise ValueError("Native grenade target report is incomplete or stale")
    exporter = (targets.capture.ROOT / "Server/tools" / targets.EXPORTER).read_bytes()
    if (evidence["grenade-target-exporter.cs"] != exporter
            or digest(exporter) != report["exporterSha256"]):
        raise ValueError("Grenade target exporter changed")
    count = targets.capture.verify_source_inventory(json.loads(evidence["grenade-target-inventory.json"]))
    if count != report["unchangedSourceFiles"]:
        raise ValueError("Grenade target source inventory count differs")
    payload = evidence["grenade-target-native.json"]
    if targets.validate(payload, scene, targets.OUTPUT) != report["output"]:
        raise ValueError("Grenade target native output changed")
    return payload


def bind_run(run, scene):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"grenade-target-recapture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Grenade targets require a completed capture or stage")
    if has_links(run):
        raise ValueError("Grenade target evidence cannot contain links")
    previous = None
    if manifest["suite"] == "grenade-target-recapture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("grenadeTargetEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Stage has no grenade target evidence")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained grenade target evidence changed")
    payload = validate_evidence(evidence, scene)
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "releaseVerified": False,
             "evidenceHashes": {name: digest(value) for name, value in evidence.items()},
             "candidateSha256": digest(payload)}
    return payload, proof, evidence
