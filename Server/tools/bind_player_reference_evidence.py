"""Revalidate retained native player reference samples before adding them to a content candidate."""
import json

import recapture_player_references as references
from test_artifacts import checked_run, has_links, read_manifest

digest = references.capture.digest
FILES = {"player-reference-results.json": "results.json", "player-reference-inventory.json": "source-inventory.json",
         "player-reference-batch.cs": "PlayerReferenceBatch.cs"}
FILES.update({"player-reference-" + name: name for name in references.OUTPUTS.values()})


def validate_evidence(evidence, scene):
    report = json.loads(evidence["player-reference-results.json"])
    if (report.get("nativeExportVerified") is not True or report["sourceSceneSha256"] != digest(scene)
            or report["differences"] != [] or set(report["outputs"]) != set(references.OUTPUTS.values())):
        raise ValueError("Native player reference report is incomplete or stale")
    count = references.capture.verify_source_inventory(json.loads(evidence["player-reference-inventory.json"]))
    if count != report["unchangedSourceFiles"]:
        raise ValueError("Native player reference inventory count differs")
    if digest(evidence["player-reference-batch.cs"]) != report["wrapperSha256"]:
        raise ValueError("Native player reference wrapper changed")
    expected_edits = {}
    for exporter, exit_count in references.EXPORTS:
        relative = "Assets/Editor/SelfHosted" + exporter + "Export.cs"
        source = (references.capture.ROOT / "Clients/ExportedProject" / relative).read_bytes()
        if source.count(b"EditorApplication.Exit(0);") != exit_count:
            raise ValueError("Native player reference exporter exit shape changed")
        modified = source.replace(b"EditorApplication.Exit(0);", b"/* Batch runner owns successful exit. */")
        expected_edits[relative] = {"originalSha256": digest(source), "batchSha256": digest(modified)}
    if report["batchEdits"] != expected_edits:
        raise ValueError("Native player reference preparation differs")
    candidates = {}
    for name in references.OUTPUTS.values():
        payload = evidence["player-reference-" + name]
        if references.validate(payload, scene, name) != report["outputs"][name]:
            raise ValueError("Native player reference output changed: " + name)
        # Preserve the actual native byte stream and its recorded digest.
        candidates[name] = payload
    return candidates


def bind_run(run, scene):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"player-reference-recapture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Player reference evidence requires a completed capture or stage")
    if has_links(run):
        raise ValueError("Player reference evidence cannot contain links")
    previous = None
    if manifest["suite"] == "player-reference-recapture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("playerReferenceEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Stage has no player reference evidence")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained player reference evidence changed")
    candidates = validate_evidence(evidence, scene)
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "releaseVerified": False,
             "evidenceHashes": {name: digest(payload) for name, payload in evidence.items()},
             "candidateHashes": {name: digest(payload) for name, payload in candidates.items()}}
    return candidates, proof, evidence
