"""Bind a staged content candidate to a completed, independently checked native export."""
import hashlib
import json
from pathlib import Path

from recapture_battle_content import validate_export, verify_source_snapshot
from audit_battle_sheet_values import compare_sheet, component_index
from test_artifacts import checked_run, has_links, read_manifest


def digest(payload):
    return hashlib.sha256(payload).hexdigest()


def bind_native_run(run, scene, prepared, candidate):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"battle-recapture", "sheet-candidates"} or manifest["status"] != "passed" or has_links(run):
        raise ValueError("Native evidence must be one completed unlinked recapture run")
    evidence_root = run
    report_path = run / "results.json"
    previous_proof = None
    if manifest["suite"] == "sheet-candidates":
        previous_proof = json.loads(report_path.read_bytes()).get("nativeEvidence")
        if not isinstance(previous_proof, dict) or previous_proof.get("nativeGeometryRecaptured") is not True:
            raise ValueError("Staged run does not retain verified native evidence")
        evidence_root = run / "evidence"
        report_path = evidence_root / "native-results.json"
    report_bytes = report_path.read_bytes()
    report = json.loads(report_bytes)
    if (report.get("nativeExportVerified") is not True or report["sourceSceneSha256"] != digest(scene)
            or report["preparedSceneSha256"] != digest(prepared)):
        raise ValueError("Native evidence does not bind these original/prepared scene inputs")
    inventory_bytes = (evidence_root / "source-inventory.json").read_bytes()
    if previous_proof and (previous_proof["nativeReportSha256"] != digest(report_bytes)
                           or previous_proof["sourceInventorySha256"] != digest(inventory_bytes)):
        raise ValueError("Retained native evidence changed after staging")
    inventory = json.loads(inventory_bytes)
    for name in inventory:
        path = Path(name)
        if (path.is_absolute() or ".." in path.parts or "\\" in name or not path.parts
                or path.parts[0] not in {"Assets", "Packages", "ProjectSettings", "Library"}
                or (path.parts[0] == "Library" and path.parts[:2] != ("Library", "PackageCache"))):
            raise ValueError("Invalid native input inventory path")
    required = {"Assets/Scenes/MainScene.unity", "Assets/Editor/SelfHostedBattleExport.cs",
                "Packages/manifest.json", "ProjectSettings/ProjectVersion.txt"}
    if not required.issubset(inventory):
        raise ValueError("Incomplete native input inventory")
    source_count = verify_source_snapshot(evidence_root)
    native_hash = validate_export(evidence_root, scene, prepared, record_differences=False)
    if native_hash != report["nativeContentSha256"]:
        raise ValueError("Native output changed after verification")
    if previous_proof and previous_proof["nativeContentSha256"] != native_hash:
        raise ValueError("Retained native output differs from staged proof")
    native_bytes = (evidence_root / "native-battle-content.json").read_bytes()
    native = json.loads(native_bytes)
    staged = json.loads(candidate)
    if staged["mainSceneSha256"] != digest(scene):
        raise ValueError("Candidate source identity differs")
    identities = lambda rows: [(row["type"], row["path"]) for row in rows]
    if identities(staged["sheets"]) != identities(native["sheets"]):
        raise ValueError("Candidate sheet identity/order differs from native export")
    blocks = component_index(scene.decode("utf-8-sig"))
    for sheet in staged["sheets"]:
        differences, _, _ = compare_sheet(sheet, blocks)
        if differences:
            raise ValueError("Candidate sheet values differ from native-proven source")
    for document in (native, staged):
        document.pop("mainSceneSha256")
        document.pop("sheets")
    if native != staged:
        raise ValueError("Candidate changed native non-sheet observations")
    proof = {"schemaVersion": 1, "sourceSceneSha256": digest(scene),
             "preparedSceneSha256": digest(prepared), "nativeContentSha256": native_hash,
             "candidateSha256": digest(candidate),
             "nativeRunId": previous_proof["nativeRunId"] if previous_proof else run.name,
             "evidenceInputRunId": run.name,
             "nativeReportSha256": digest(report_bytes), "sourceInventorySha256": digest(inventory_bytes),
             "unchangedSourceFiles": source_count, "nativeGeometryRecaptured": True,
             "releaseVerified": False}
    evidence = {"native-battle-content.json": native_bytes, "source-inventory.json": inventory_bytes,
                "native-results.json": report_bytes}
    return proof, evidence
