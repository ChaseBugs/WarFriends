"""Bind retained native weapon identities to the current candidate scene without publishing."""
import json

import recapture_weapon_bindings as weapons
from test_artifacts import checked_run, has_links, read_manifest

digest = weapons.capture.digest
FILES = {"weapon-native.json": "native-all-weapon-bindings.json",
         "weapon-inventory.json": "source-inventory.json", "weapon-results.json": "results.json"}


def bind_run(run, scene):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"weapon-recapture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Weapon evidence requires a completed capture or stage")
    if has_links(run):
        raise ValueError("Weapon evidence cannot contain links")
    previous = None
    if manifest["suite"] == "weapon-recapture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("weaponEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Stage has no native weapon evidence")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained weapon evidence changed")
    report = json.loads(evidence["weapon-results.json"])
    native = evidence["weapon-native.json"]
    if (report.get("nativeExportVerified") is not True or report.get("weaponCount") != 66
            or report["sourceSceneSha256"] != digest(scene) or report["nativeOutputSha256"] != digest(native)):
        raise ValueError("Native weapon output identity differs")
    inventory = json.loads(evidence["weapon-inventory.json"])
    count = weapons.capture.verify_source_inventory(inventory)
    if count != report["unchangedSourceFiles"]:
        raise ValueError("Native weapon inventory count differs")
    weapons.validate(native, scene)
    candidate = (json.dumps(json.loads(native), indent=2, allow_nan=False) + "\n").encode("utf-8")
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "candidateSha256": digest(candidate), "weaponCount": 66,
             "evidenceHashes": {name: digest(payload) for name, payload in evidence.items()},
             "releaseVerified": False}
    return candidate, proof, evidence
