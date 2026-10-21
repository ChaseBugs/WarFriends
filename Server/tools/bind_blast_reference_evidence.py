"""Bind native blast observations to the exact candidate weapon graph and current Client inputs."""
import json

import recapture_blast_references as references
from test_artifacts import checked_run, has_links, read_manifest

digest = references.capture.digest
FILES = {"blast-reference-results.json": "results.json", "blast-reference-inventory.json": "source-inventory.json",
         "blast-reference-bindings.json": "bindings.json"}
FILES.update({"blast-reference-" + name: name for name in references.OUTPUTS.values()})
FILES.update({"blast-reference-" + name: name for name in (*references.EXPORTERS.values(), "BlastReferenceBatch.cs")})


def validate_evidence(evidence, scene, bindings):
    report = json.loads(evidence["blast-reference-results.json"])
    if (report.get("nativeExportVerified") is not True or report["sourceSceneSha256"] != digest(scene)
            or set(report["outputs"]) != set(references.OUTPUTS.values())):
        raise ValueError("Native blast reference report is incomplete or stale")
    if evidence["blast-reference-bindings.json"] != bindings or report["bindingsSha256"] != digest(bindings):
        raise ValueError("Native blast reference weapon dependency differs")
    count = references.capture.verify_source_inventory(json.loads(evidence["blast-reference-inventory.json"]))
    if count != report["unchangedSourceFiles"]:
        raise ValueError("Native blast reference inventory count differs")
    exporters = references.prepared_exporters()
    if report["exporterHashes"] != {name: digest(payload) for name, payload in exporters.items()}:
        raise ValueError("Native blast reference exporter preparation differs")
    for name, payload in exporters.items():
        if evidence["blast-reference-" + name] != payload:
            raise ValueError("Native blast reference exporter changed: " + name)
    candidates = {}
    for name in references.OUTPUTS.values():
        payload = evidence["blast-reference-" + name]
        if references.validate(payload, scene, bindings, name) != report["outputs"][name]:
            raise ValueError("Native blast reference output changed: " + name)
        candidates[name] = payload
    return candidates


def bind_run(run, scene, bindings):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"blast-reference-recapture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Blast reference evidence requires a completed capture or stage")
    if has_links(run):
        raise ValueError("Blast reference evidence cannot contain links")
    previous = None
    if manifest["suite"] == "blast-reference-recapture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("blastReferenceEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Stage has no blast reference evidence")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained blast reference evidence changed")
    candidates = validate_evidence(evidence, scene, bindings)
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "releaseVerified": False,
             "evidenceHashes": {name: digest(payload) for name, payload in evidence.items()},
             "candidateHashes": {name: digest(payload) for name, payload in candidates.items()}}
    return candidates, proof, evidence
