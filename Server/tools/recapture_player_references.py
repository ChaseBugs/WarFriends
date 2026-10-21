"""Recapture collision, rig blending and moving-fire references in one owned Editor import."""
import argparse
import json
import os
from pathlib import Path

import recapture_battle_content as capture
import prepare_editor_batch as batch
import audit_rig_reference_extension as rig_extension

EXPORTS = (("PlayerCollision", 0), ("RigBlend", 0), ("WalkingShot", 0))
OUTPUTS = {"WAR_PLAYER_COLLISION_OUTPUT": "recovered-player-collision.json",
           "WAR_RIG_BLEND_OUTPUT": "recovered-rig-blend-reference.json",
           "WAR_WALKING_SHOT_OUTPUT": "recovered-walking-shot-reference.json"}


def validate(payload, scene, name):
    current = json.loads(payload)
    previous = json.loads((capture.ROOT / "Server/content" / name).read_bytes())
    if current.get("sha256") != capture.digest(scene):
        raise ValueError("Native player reference export has a different scene: " + name)
    previous["sha256"] = current["sha256"]
    if json.dumps(current, sort_keys=True, allow_nan=False) != json.dumps(previous, sort_keys=True, allow_nan=False):
        if name == "recovered-rig-blend-reference.json" and len(current.get("nodes", [])) == 144:
            review = rig_extension.review(payload)
            return {"sha256": capture.digest(payload), "valuesEqual": False, "reviewedExtension": review}
        raise ValueError("Native player reference values changed; review retained output: " + name)
    return {"sha256": capture.digest(payload), "valuesEqual": True}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    capture.prune_runs(capture.DEFAULT_ROOT, apply=True)
    run = capture.start_run(capture.DEFAULT_ROOT, "player-reference-recapture", os.getpid())
    print("Owned player reference recapture: " + str(run), flush=True)
    try:
        project, scene, _, _ = capture.prepare_project(run, prepare_strings=False)
        edits, wrapper = batch.prepare(project, EXPORTS, "PlayerReferenceBatch")
        (run / "PlayerReferenceBatch.cs").write_bytes(wrapper)
        report = {"releaseVerified": False, "productionFilesWritten": False,
                  "sourceSceneSha256": capture.digest(scene), "batchEdits": edits,
                  "wrapperSha256": capture.digest(wrapper),
                  "runnerSha256": capture.digest(Path(__file__).read_bytes()),
                  "batchToolSha256": capture.digest(Path(batch.__file__).read_bytes()),
                  "editorSha256": capture.digest(args.unity.read_bytes())}
        capture.write_report(run / "results.json", report)
        capture.execute_editor(args.unity.resolve(), project, run, method="PlayerReferenceBatch.Run",
                               outputs={variable: run / name for variable, name in OUTPUTS.items()})
        report["unchangedSourceFiles"] = capture.verify_source_snapshot(run)
        results, errors = {}, []
        for name in OUTPUTS.values():
            try:
                results[name] = validate((run / name).read_bytes(), scene, name)
            except ValueError as error:
                errors.append(str(error))
        report.update({"outputs": results, "differences": errors, "nativeExportVerified": not errors})
        capture.write_report(run / "results.json", report)
        if errors:
            raise ValueError("Player reference validation requires review: " + "; ".join(errors))
    except BaseException as error:
        capture.write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        capture.finish_run(capture.DEFAULT_ROOT, run, "failed", False)
        raise
    capture.finish_run(capture.DEFAULT_ROOT, run, "passed", False)
    print("Native player reference exports verified: " + str(run), flush=True)


if __name__ == "__main__":
    main()
