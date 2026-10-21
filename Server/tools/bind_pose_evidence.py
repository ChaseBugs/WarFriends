"""Revalidate retained native pose samples before adding them to a content candidate."""
import json

import recapture_pose_content as poses
from test_artifacts import checked_run, has_links, read_manifest

digest = poses.capture.digest
FILES = {"pose-results.json": "results.json", "pose-inventory.json": "source-inventory.json",
         "pose-batch.cs": "PoseContentBatch.cs"}
FILES.update({"pose-" + name: name for name in poses.OUTPUTS.values()})


def validate_evidence(evidence, scene):
    report = json.loads(evidence["pose-results.json"])
    if (report.get("nativeExportVerified") is not True or report["sourceSceneSha256"] != digest(scene)
            or report["differences"] != [] or set(report["outputs"]) != set(poses.OUTPUTS.values())):
        raise ValueError("Native pose report is incomplete or stale")
    count = poses.capture.verify_source_inventory(json.loads(evidence["pose-inventory.json"]))
    if count != report["unchangedSourceFiles"]:
        raise ValueError("Native pose inventory count differs")
    if digest(evidence["pose-batch.cs"]) != report["wrapperSha256"]:
        raise ValueError("Native pose wrapper changed")
    expected_edits = {}
    for exporter, exit_count in poses.EXPORTS:
        relative = "Assets/Editor/SelfHosted" + exporter + "Export.cs"
        source = (poses.capture.ROOT / "Clients/ExportedProject" / relative).read_bytes()
        if source.count(b"EditorApplication.Exit(0);") != exit_count:
            raise ValueError("Native pose exporter exit shape changed")
        modified = source.replace(b"EditorApplication.Exit(0);", b"/* Batch runner owns successful exit. */")
        expected_edits[relative] = {"originalSha256": digest(source), "batchSha256": digest(modified)}
    if report["batchEdits"] != expected_edits:
        raise ValueError("Native pose preparation differs")
    candidates = {}
    for name in poses.OUTPUTS.values():
        payload = evidence["pose-" + name]
        if poses.validate(payload, scene, name) != report["outputs"][name]:
            raise ValueError("Native pose output changed: " + name)
        # Native player poses are intentionally compact to fit the runtime's bounded loader.
        candidates[name] = payload
    return candidates


def bind_run(run, scene):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"pose-recapture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Pose evidence requires a completed capture or stage")
    if has_links(run):
        raise ValueError("Pose evidence cannot contain links")
    previous = None
    if manifest["suite"] == "pose-recapture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("poseEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Stage has no pose evidence")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained pose evidence changed")
    candidates = validate_evidence(evidence, scene)
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "releaseVerified": False,
             "evidenceHashes": {name: digest(payload) for name, payload in evidence.items()},
             "candidateHashes": {name: digest(payload) for name, payload in candidates.items()}}
    return candidates, proof, evidence
