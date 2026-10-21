"""Refresh starter observation through real Client boot in one owned, pre-imported source copy."""
import argparse
import hashlib
import json
import os
import subprocess
import sys
from pathlib import Path

from recapture_battle_content import ROOT, prepare_project, verify_source_snapshot

sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, prepare_test_environment, prune_runs, start_run


def execute(command, environment, log, timeout):
    with log.open("wb") as output:
        process = subprocess.Popen(command, env=environment, stdout=output, stderr=subprocess.STDOUT)
        try:
            code = process.wait(timeout=timeout)
        except subprocess.TimeoutExpired:
            if process.poll() is None:
                subprocess.run(["taskkill", "/PID", str(process.pid), "/T", "/F"], check=True, capture_output=True)
                process.wait(timeout=30)
            raise
    if code != 0:
        raise ValueError("Owned command failed; inspect " + str(log))


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    parser.add_argument("--mongo", type=Path, required=True)
    args = parser.parse_args()
    for path in (args.unity, args.mongo):
        if not path.is_file():
            parser.error("Executable not found: " + str(path))
    # Existing normal Client tools require their disposable project within this boundary.
    project_root = ROOT / "Server/.local/test-runs"
    prune_runs(project_root, apply=True)
    run = start_run(project_root, "starter-observation", os.getpid())
    print("Owned source project: " + str(run), flush=True)
    try:
        project, scene, _, _ = prepare_project(run, prepare_strings=False)
        environment = prepare_test_environment(project_root, run)
        environment["WAR_TEST_RUN_ROOT"] = str(DEFAULT_ROOT)
        prewarm = [str(args.unity.resolve()), "-batchmode", "-nographics", "-noUpm", "-quit",
                   "-projectPath", str(project), "-logFile", str(run / "import.log")]
        print("Importing current source before the bounded gameplay boot observation", flush=True)
        execute(prewarm, environment, run / "import-process.log", 600)
        command = ["pwsh", "-NoProfile", "-File", str(ROOT / "Server/scripts/ClientBootSmoke.ps1"),
                   "-UnityExecutable", str(args.unity.resolve()), "-UnityProject", str(project),
                   "-MongoExecutable", str(args.mongo.resolve()), "-ExportStarterLoadout"]
        print("Starting actual fresh-account Backend/Mongo/Unity observation", flush=True)
        execute(command, environment, run / "boot-process.log", 600)
        count = verify_source_snapshot(run)
        report = {"sourceSceneSha256": hashlib.sha256(scene).hexdigest(), "unchangedSourceFiles": count,
                  "bootSucceeded": True, "productionFilesWritten": False,
                  "runnerSha256": hashlib.sha256(Path(__file__).read_bytes()).hexdigest(),
                  "observationRoot": str(DEFAULT_ROOT)}
        (run / "results.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    except BaseException as error:
        (run / "failure.json").write_text(json.dumps({"type": type(error).__name__, "message": str(error)},
                                                    indent=2) + "\n", encoding="utf-8")
        finish_run(project_root, run, "failed", False)
        raise
    finish_run(project_root, run, "passed", False)
    print("Actual starter observation completed; source copy removed: " + str(run), flush=True)


if __name__ == "__main__":
    main()
