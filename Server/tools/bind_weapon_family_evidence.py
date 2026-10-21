"""Revalidate native family exports and reproduce packages without publishing content."""
import json

import recapture_weapon_families as families
from test_artifacts import checked_run, has_links, read_manifest

digest = families.capture.digest
FILES = {"family-results.json": "results.json", "family-inventory.json": "source-inventory.json",
         "family-identities.json": "native-all-weapon-bindings.json", "family-batch.cs": "WeaponFamilyBatch.cs",
         "family-minigun-composed.json": "composed-minigun-binding.json"}
FILES.update({"family-" + family + ".json": families.output_name(family)
              for family, _, _, _ in families.FAMILIES})


def encode(value):
    return (json.dumps(value, indent=2, allow_nan=False) + "\n").encode()


def validate_evidence(evidence, scene):
    report = json.loads(evidence["family-results.json"])
    expected_families = {family for family, _, _, _ in families.FAMILIES}
    if (report.get("nativeExportVerified") is not True or report["sourceSceneSha256"] != digest(scene)
            or report["differences"] != [] or set(report["families"]) != expected_families):
        raise ValueError("Native family report is incomplete or stale")
    count = families.capture.verify_source_inventory(json.loads(evidence["family-inventory.json"]))
    if count != report["unchangedSourceFiles"]:
        raise ValueError("Native family inventory count differs")
    if digest(evidence["family-batch.cs"]) != report["wrapperSha256"]:
        raise ValueError("Native family wrapper changed")
    expected_edits = {}
    for _, exporter, _, exit_count in (("all", "AllWeapon", "ALL_WEAPON", 1),) + families.FAMILIES:
        relative = "Assets/Editor/SelfHosted" + exporter + "Export.cs"
        source = (families.capture.ROOT / "Clients/ExportedProject" / relative).read_bytes()
        if source.count(b"EditorApplication.Exit(0);") != exit_count:
            raise ValueError("Native family exporter exit shape changed")
        modified = source.replace(b"EditorApplication.Exit(0);", b"/* Batch runner owns successful exit. */")
        expected_edits[relative] = {"originalSha256": digest(source), "batchSha256": digest(modified)}
    if report["batchEdits"] != expected_edits:
        raise ValueError("Native family preparation differs")
    identities = evidence["family-identities.json"]
    if families.identities.validate(identities, scene) != report["allWeaponSha256"]:
        raise ValueError("Native family identities changed")
    candidates = {}
    for family, _, _, _ in families.FAMILIES:
        payload = evidence["family-" + family + ".json"]
        if family == "minigun":
            payload = encode(families.minigun.build_document(payload, identities))
            if payload != evidence["family-minigun-composed.json"]:
                raise ValueError("Native Minigun composition changed")
        if families.validate(payload, scene, family) != report["families"][family]:
            raise ValueError("Native family output changed: " + family)
        candidates[families.output_name(family)] = encode(json.loads(payload))
    return candidates


def bind_run(run, scene):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"weapon-family-recapture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Family evidence requires a completed capture or stage")
    if has_links(run):
        raise ValueError("Family evidence cannot contain links")
    previous = None
    if manifest["suite"] == "weapon-family-recapture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("weaponFamilyEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Stage has no weapon family evidence")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained weapon family evidence changed")
    candidates = validate_evidence(evidence, scene)
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "familyCount": len(candidates), "releaseVerified": False,
             "evidenceHashes": {name: digest(payload) for name, payload in evidence.items()},
             "candidateHashes": {name: digest(payload) for name, payload in candidates.items()}}
    return candidates, proof, evidence
