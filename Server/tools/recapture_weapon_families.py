"""Run nine original weapon exporters in one disposable import and retain separate evidence."""
import argparse
import json
import os
from pathlib import Path

import recapture_battle_content as capture
import recapture_weapon_bindings as identities
import compose_minigun_binding as minigun
import prepare_editor_batch as batch

FAMILIES = (
    ("rifle", "Weapon", "WEAPON", 0), ("shotgun", "Shotgun", "SHOTGUN", 0),
    ("sniper", "Sniper", "SNIPER", 1), ("smg", "Smg", "SMG", 1),
    ("pistol", "Pistol", "PISTOL", 1), ("lmg", "Lmg", "LMG", 1),
    ("minigun", "Minigun", "MINIGUN", 1), ("grenade", "Grenade", "GRENADE", 1),
    ("bazooka", "Bazooka", "BAZOOKA", 1),
)


def output_name(family):
    suffix = "binding" if family == "minigun" else "bindings"
    return "recovered-" + family + "-" + suffix + ".json"


def prepare_batch(project):
    exporters = [("AllWeapon", 1)] + [(exporter, count) for _, exporter, _, count in FAMILIES]
    return batch.prepare(project, exporters, "WeaponFamilyBatch")


def validate(payload, scene, family):
    current = json.loads(payload)
    previous = json.loads((capture.ROOT / "Server/content" / output_name(family)).read_bytes())
    if current.get("sha256") != capture.digest(scene):
        raise ValueError("Native family export has a different scene: " + family)
    previous["sha256"] = current["sha256"]
    if json.dumps(current, sort_keys=True, allow_nan=False) != json.dumps(previous, sort_keys=True, allow_nan=False):
        raise ValueError("Native family values changed; review retained output: " + family)
    return {"sha256": capture.digest(payload), "valuesEqual": True}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    capture.prune_runs(capture.DEFAULT_ROOT, apply=True)
    run = capture.start_run(capture.DEFAULT_ROOT, "weapon-family-recapture", os.getpid())
    print("Owned family recapture: " + str(run), flush=True)
    try:
        project, scene, _, _ = capture.prepare_project(run, prepare_strings=False)
        edits, wrapper = prepare_batch(project)
        (run / "WeaponFamilyBatch.cs").write_bytes(wrapper)
        report = {"releaseVerified": False, "productionFilesWritten": False,
                  "sourceSceneSha256": capture.digest(scene), "batchEdits": edits,
                  "wrapperSha256": capture.digest(wrapper),
                  "runnerSha256": capture.digest(Path(__file__).read_bytes()),
                  "editorSha256": capture.digest(args.unity.read_bytes())}
        capture.write_report(run / "results.json", report)
        outputs = {"WAR_" + variable + "_OUTPUT": run / output_name(family)
                   for family, _, variable, _ in FAMILIES}
        outputs["WAR_ALL_WEAPON_OUTPUT"] = run / "native-all-weapon-bindings.json"
        capture.execute_editor(args.unity.resolve(), project, run, method="WeaponFamilyBatch.Run", outputs=outputs)
        report["unchangedSourceFiles"] = capture.verify_source_snapshot(run)
        identity_bytes = (run / "native-all-weapon-bindings.json").read_bytes()
        report["allWeaponSha256"] = identities.validate(identity_bytes, scene)
        results = {}
        errors = []
        for family, _, _, _ in FAMILIES:
            try:
                payload = (run / output_name(family)).read_bytes()
                if family == "minigun":
                    document = minigun.build_document(payload, identity_bytes)
                    payload = (json.dumps(document, indent=2, allow_nan=False) + "\n").encode()
                    (run / "composed-minigun-binding.json").write_bytes(payload)
                results[family] = validate(payload, scene, family)
            except ValueError as error:
                errors.append(str(error))
        report.update({"families": results, "differences": errors, "nativeExportVerified": not errors})
        capture.write_report(run / "results.json", report)
        if errors:
            raise ValueError("Family validation requires review: " + "; ".join(errors))
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed", False)
    print("Native family exports verified: " + str(run), flush=True)


if __name__ == "__main__":
    main()
