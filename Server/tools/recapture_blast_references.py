"""Capture grenade rig and native player overlap evidence using one owned Editor import."""
import argparse
import json
import os
from pathlib import Path

import recapture_battle_content as capture
from bind_weapon_evidence import bind_run as bind_weapons

OUTPUTS = {"WAR_GRENADE_RIG_OUTPUT": "recovered-grenade-rig.json",
           "WAR_PLAYER_EXPLOSION_OUTPUT": "unity-player-explosion-overlap-reference.json"}
EXPORTERS = {"UnityGrenadeRigExport.cs": "UnityGrenadeRigExport.cs",
             "UnityPlayerExplosionOverlapAudit.cs": "WarPlayerExplosionOverlapAudit.cs"}
WRAPPER = (b"public static class BlastReferenceBatch\n{\n    public static void Run()\n    {\n"
           b"        UnityGrenadeRigExport.Run();\n        WarPlayerExplosionOverlapAudit.Run();\n    }\n}\n")


def prepared_exporters():
    result = {}
    for source, target in EXPORTERS.items():
        payload = (capture.ROOT / "Server/tools" / source).read_bytes()
        expected_exits = 1 if source == "UnityGrenadeRigExport.cs" else 0
        if payload.count(b"EditorApplication.Exit(0);") != expected_exits:
            raise ValueError("Unexpected native exporter exit shape: " + source)
        result[target] = payload.replace(b"EditorApplication.Exit(0);", b"/* Batch owns successful exit. */")
    result["BlastReferenceBatch.cs"] = WRAPPER
    return result


def validate(payload, scene, bindings, name):
    current = json.loads(payload)
    previous = json.loads((capture.ROOT / "Server/content" / name).read_bytes())
    if name == "recovered-grenade-rig.json":
        expected = {"sceneSha256": capture.digest(scene), "bindingSceneSha256": capture.digest(scene),
                    "bindingArtifactSha256": capture.digest(bindings)}
    else:
        expected = {"sha256": capture.digest(scene)}
    for field, value in expected.items():
        if current.get(field) != value:
            raise ValueError("Native blast reference dependency differs: " + field)
        previous[field] = value
    if json.dumps(current, sort_keys=True, allow_nan=False) != json.dumps(previous, sort_keys=True, allow_nan=False):
        raise ValueError("Native blast reference values changed: " + name)
    return {"sha256": capture.digest(payload), "valuesEqual": True}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    parser.add_argument("--weapon-run", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    scene = (capture.ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity").read_bytes()
    bindings, proof, _ = bind_weapons(args.weapon_run, scene)
    capture.prune_runs(capture.DEFAULT_ROOT, apply=True)
    run = capture.start_run(capture.DEFAULT_ROOT, "blast-reference-recapture", os.getpid())
    print("Owned blast reference recapture: " + str(run), flush=True)
    try:
        project, copied_scene, _, _ = capture.prepare_project(run, prepare_strings=False)
        if copied_scene != scene:
            raise ValueError("Client scene changed before capture")
        exporters = prepared_exporters()
        for name, payload in exporters.items():
            (project / "Assets/Editor" / name).write_bytes(payload)
            (run / name).write_bytes(payload)
        (run / "bindings.json").write_bytes(bindings)
        report = {"releaseVerified": False, "productionFilesWritten": False, "weaponEvidence": proof,
                  "sourceSceneSha256": capture.digest(scene), "bindingsSha256": capture.digest(bindings),
                  "exporterHashes": {name: capture.digest(payload) for name, payload in exporters.items()},
                  "runnerSha256": capture.digest(Path(__file__).read_bytes()),
                  "editorSha256": capture.digest(args.unity.read_bytes())}
        capture.write_report(run / "results.json", report)
        environment = {variable: run / name for variable, name in OUTPUTS.items()}
        environment.update({"WAR_GRENADE_RIG_RUN": run, "WAR_GRENADE_RIG_BINDINGS": run / "bindings.json"})
        capture.execute_editor(args.unity.resolve(), project, run,
                               method="BlastReferenceBatch.Run", outputs=environment)
        report["unchangedSourceFiles"] = capture.verify_source_snapshot(run)
        report["outputs"] = {name: validate((run / name).read_bytes(), scene, bindings, name)
                             for name in OUTPUTS.values()}
        report["nativeExportVerified"] = True
        capture.write_report(run / "results.json", report)
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed", False)
    print("Native blast references verified: " + str(run), flush=True)


if __name__ == "__main__":
    main()
