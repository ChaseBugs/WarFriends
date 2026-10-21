"""Observe grenade targets in an owned Client copy; never publish content implicitly."""
import argparse
import os
from pathlib import Path

import recapture_battle_content as capture
from recapture_pose_content import validate

OUTPUT = "recovered-grenade-shot-targets.json"
EXPORTER = "UnityGrenadeShotTargetExport.cs"


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    capture.prune_runs(capture.DEFAULT_ROOT, apply=True)
    run = capture.start_run(capture.DEFAULT_ROOT, "grenade-target-recapture", os.getpid())
    print("Owned grenade target recapture: " + str(run), flush=True)
    try:
        project, scene, _, _ = capture.prepare_project(run, prepare_strings=False)
        exporter = (capture.ROOT / "Server/tools" / EXPORTER).read_bytes()
        (project / "Assets/Editor" / EXPORTER).write_bytes(exporter)
        (run / EXPORTER).write_bytes(exporter)
        report = {"releaseVerified": False, "productionFilesWritten": False,
                  "sourceSceneSha256": capture.digest(scene),
                  "exporterSha256": capture.digest(exporter),
                  "runnerSha256": capture.digest(Path(__file__).read_bytes()),
                  "editorSha256": capture.digest(args.unity.read_bytes())}
        capture.write_report(run / "results.json", report)
        capture.execute_editor(args.unity.resolve(), project, run,
                               method="UnityGrenadeShotTargetExport.Run",
                               outputs={"WAR_GRENADE_TARGET_OUTPUT": run / OUTPUT})
        report["unchangedSourceFiles"] = capture.verify_source_snapshot(run)
        report["output"] = validate((run / OUTPUT).read_bytes(), scene, OUTPUT)
        report["nativeExportVerified"] = True
        capture.write_report(run / "results.json", report)
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed", False)
    print("Native grenade targets verified: " + str(run), flush=True)


if __name__ == "__main__":
    main()
