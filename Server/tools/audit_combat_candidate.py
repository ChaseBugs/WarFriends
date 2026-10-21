"""Load a diagnostic content overlay without modifying production or claiming release readiness."""
import argparse
import json
import os
from pathlib import Path
import shutil
import subprocess

import recapture_battle_content as capture
import audit_main_scene_provenance as provenance
from test_artifacts import checked_run, has_links, read_manifest


def validate_stage(stage):
    checked_run(stage.parent, stage)
    manifest = read_manifest(stage)
    if manifest["suite"] != "sheet-candidates" or manifest["status"] != "passed" or has_links(stage):
        raise ValueError("Combat audit requires a completed unlinked candidate stage")
    report = json.loads((stage / "results.json").read_bytes())
    expected = {name: row["candidateSha256"] for name, row in report["dependents"].items()}
    expected["recovered-battle-content.json"] = report["candidateSha256"]
    paths = list((stage / "candidates").glob("*.json"))
    if {path.name for path in paths} != set(expected):
        raise ValueError("Candidate inventory differs from stage report")
    for path in paths:
        if capture.digest(path.read_bytes()) != expected[path.name]:
            raise ValueError("Candidate changed after staging: " + path.name)
    return expected


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--stage", type=Path, required=True)
    parser.add_argument("--assembly", type=Path, required=True)
    parser.add_argument("--scope", choices=("combat", "coop-navigation", "player-reference", "blast-reference"),
                        default="combat")
    args = parser.parse_args()
    stage = args.stage.resolve()
    candidates = validate_stage(stage)
    if not args.assembly.is_file():
        parser.error("Battle test assembly does not exist")
    source = capture.ROOT / "Server/content"
    if has_links(source):
        raise ValueError("Content source cannot contain links")
    run = capture.start_run(capture.DEFAULT_ROOT, "combat-candidate-audit", os.getpid())
    print("Owned combat audit: " + str(run), flush=True)
    try:
        target = run / "data/content"
        shutil.copytree(source, target)
        inventory = {path.relative_to(source).as_posix(): capture.digest(path.read_bytes())
                     for path in source.rglob("*") if path.is_file()}
        for name in candidates:
            shutil.copyfile(stage / "candidates" / name, target / name)
        capture.write_report(run / "base-inventory.json", inventory)
        capture.write_report(run / "candidate-inventory.json", candidates)
        with (run / "loader.log").open("wb") as log:
            result = subprocess.run(["dotnet", str(args.assembly.resolve()), "--" + args.scope + "-candidate-path", str(target)],
                                    stdout=log, stderr=subprocess.STDOUT, timeout=120)
        current = {path.relative_to(source).as_posix(): capture.digest(path.read_bytes())
                   for path in source.rglob("*") if path.is_file()}
        if current != inventory:
            raise ValueError("Production content changed during diagnostic audit")
        source_report = provenance.create_report()
        unstaged = sorted(row["path"] for row in source_report["affectedArtifacts"]
                          if Path(row["path"]).name not in candidates)
        capture.write_report(run / "source-closure.json", {
            "affectedArtifactCount": len(source_report["affectedArtifacts"]),
            "unstagedAffectedArtifacts": unstaged,
            "scope": "Candidate coverage, not proof of every dependent runtime rule"})
        capture.write_report(run / "results.json", {"stageRunId": stage.name, "releaseVerified": False,
                             "diagnosticOverlay": True, "productionFilesWritten": False,
                             "loaderExitCode": result.returncode,
                             "loaderScope": args.scope,
                             "testAssemblySha256": capture.digest(args.assembly.read_bytes()),
                             "candidateCount": len(candidates), "baseFileCount": len(inventory),
                             "unstagedAffectedArtifacts": unstaged})
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed" if result.returncode == 0 else "failed", False)
    print((run / "loader.log").read_text(encoding="utf-8", errors="replace"))
    print("Affected artifacts absent from candidate: " + str(len(unstaged)))
    capture.prune_runs(capture.DEFAULT_ROOT, apply=True)
    raise SystemExit(0 if result.returncode == 0 else 1)


if __name__ == "__main__":
    main()
