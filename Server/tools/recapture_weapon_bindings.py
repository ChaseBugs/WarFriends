"""Recapture all 66 weapon identities in an owned Unity project without publishing content."""
import argparse
import json
import os
from pathlib import Path

import recapture_battle_content as capture


def validate(payload, scene):
    document = json.loads(payload)
    previous = json.loads((capture.ROOT / "Server/content/recovered-all-weapon-bindings.json").read_bytes())
    if document.get("sha256") != capture.digest(scene):
        raise ValueError("Native weapon export did not bind the exact scene")
    previous["sha256"] = document["sha256"]
    # Typed JSON comparison preserves every native field, identity, ordering and numerical value.
    if json.dumps(document, sort_keys=True, allow_nan=False) != json.dumps(previous, sort_keys=True, allow_nan=False):
        raise ValueError("Native weapon bindings changed; review the retained export")
    return capture.digest(payload)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    capture.prune_runs(capture.DEFAULT_ROOT, apply=True)
    run = capture.start_run(capture.DEFAULT_ROOT, "weapon-recapture", os.getpid())
    print("Owned weapon recapture: " + str(run), flush=True)
    try:
        project, scene, prepared, changes = capture.prepare_project(run, prepare_strings=False)
        report = {"releaseVerified": False, "productionFilesWritten": False,
                  "sourceSceneSha256": capture.digest(scene),
                  "runnerSha256": capture.digest(Path(__file__).read_bytes()),
                  "captureToolSha256": capture.digest(Path(capture.__file__).read_bytes()),
                  "editorSha256": capture.digest(args.unity.read_bytes())}
        capture.write_report(run / "results.json", report)
        output = run / "native-all-weapon-bindings.json"
        capture.execute_editor(args.unity.resolve(), project, run,
                               method="SelfHostedAllWeaponExport.Run",
                               outputs={"WAR_ALL_WEAPON_OUTPUT": output})
        report["nativeOutputSha256"] = validate(output.read_bytes(), scene)
        report["unchangedSourceFiles"] = capture.verify_source_snapshot(run)
        report["weaponCount"] = 66
        report["nativeExportVerified"] = True
        capture.write_report(run / "results.json", report)
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed", False)
    print("Native weapon identities verified: " + str(run), flush=True)


if __name__ == "__main__":
    main()
