"""Recapture native boss paths with five small NavMesh assets, without copying the Client."""
import argparse
import hashlib
import json
import os
from pathlib import Path
import shutil
import subprocess
import sys

import extract_coop_boss_anchors as anchors
import extract_mission_catalog as missions
import package_coop_boss_paths as package

ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
SCRIPT = ROOT / "Server/tools/Unity/BossPaths/BossPathCapture.cs"
sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, prune_runs, start_run


def encode(value):
    return (json.dumps(value, indent=2, allow_nan=False) + "\n").encode()


def digest(value):
    return hashlib.sha256(value).hexdigest()


def prepare(run):
    scene = missions.SCENE.read_bytes()
    mission = missions.build_document(scene)
    anchor_bytes = encode(anchors.build_document(encode(mission)))
    navigation_bytes = package.NAVIGATION.read_bytes()
    navigation = json.loads(navigation_bytes)
    by_scene = {Path(row["scene"]).stem: row for row in navigation["maps"]}
    project = run / "data/project"
    (project / "Assets/Editor").mkdir(parents=True)
    shutil.copyfile(SCRIPT, project / "Assets/Editor/BossPathCapture.cs")
    inputs = []
    sources = {missions.SCENE: digest(scene), package.NAVIGATION: digest(navigation_bytes),
               SCRIPT: digest(SCRIPT.read_bytes())}
    copied_bytes = 0
    for row in json.loads(anchor_bytes)["maps"]:
        nav = by_scene[row["scene"]]
        if nav["sceneSha256"] != row["sceneSha256"]:
            raise ValueError("Navigation and anchor scenes differ")
        scene_path = CLIENT / nav["scene"]
        sources[scene_path] = row["sceneSha256"]
        relative = Path(nav["navMeshAsset"])
        if relative.is_absolute() or ".." in relative.parts or relative.parts[:2] != ("Assets", "NavMeshData"):
            raise ValueError("Unsafe navigation asset path")
        for suffix in ("", ".meta"):
            source = Path(str(CLIENT / relative) + suffix)
            payload = source.read_bytes()
            if not suffix and digest(payload) != nav["navMeshSha256"]:
                raise ValueError("Native navigation asset differs from reviewed input")
            sources[source] = digest(payload)
            target = Path(str(project / relative) + suffix)
            target.parent.mkdir(parents=True, exist_ok=True)
            target.write_bytes(payload)
            copied_bytes += len(payload)
        points = [dict(zip("xyz", point["worldPosition"])) for point in row["playerPositions"]]
        inputs.append({"scene": row["scene"], "asset": nav["navMeshAsset"], "points": points})
    for directory in ("Packages", "ProjectSettings"):
        (project / directory).mkdir()
    (project / "Packages/manifest.json").write_text('{"dependencies": {}}\n')
    (project / "ProjectSettings/ProjectVersion.txt").write_text("m_EditorVersion: 2018.3.0f2\n")
    (run / "input.json").write_bytes(encode({"maps": inputs}))
    (run / "anchors.json").write_bytes(anchor_bytes)
    (run / "navigation.json").write_bytes(navigation_bytes)
    return project, sources, copied_bytes


def capture(editor, project, run):
    environment = os.environ.copy()
    environment["WAR_BOSS_PATH_RUN"] = str(run)
    command = [str(editor), "-batchmode", "-nographics", "-noUpm", "-quit", "-projectPath", str(project),
               "-executeMethod", "BossPathCapture.Run", "-logFile", str(run / "unity.log")]
    with (run / "process.log").open("wb") as log:
        process = subprocess.Popen(command, env=environment, stdout=log, stderr=subprocess.STDOUT)
        try:
            if process.wait(timeout=180) != 0:
                raise ValueError("Native path capture failed; inspect the owned Unity log")
        except subprocess.TimeoutExpired:
            if process.poll() is None:
                subprocess.run(["taskkill", "/PID", str(process.pid), "/T", "/F"], capture_output=True, check=True)
                process.wait(timeout=30)
            raise


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", required=True, type=Path)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    run = start_run(DEFAULT_ROOT, "boss-path-capture", os.getpid())
    try:
        project, sources, copied_bytes = prepare(run)
        capture(args.unity.resolve(), project, run)
        for path, expected in sources.items():
            if digest(path.read_bytes()) != expected:
                raise ValueError("Source changed during native capture: " + str(path))
        native = (run / "native-paths.json").read_bytes()
        candidate = package.build_document((run / "anchors.json").read_bytes(),
                                           (run / "navigation.json").read_bytes(), native)
        previous = json.loads(package.OUTPUT.read_bytes())
        if encode(previous["maps"]) != encode(candidate["maps"]):
            raise ValueError("Native paths differ from previous routes; review raw capture before publication")
        (run / "candidate.json").write_bytes(encode(candidate))
        report = {"nativeSha256": digest(native), "candidateSha256": digest(encode(candidate)),
                  "editorSha256": digest(args.unity.read_bytes()), "copiedAssetBytes": copied_bytes,
                  "routeCount": sum(len(row["routes"]) for row in candidate["maps"]),
                  "productionFilesWritten": False, "releaseVerified": False,
                  "sources": {str(path.relative_to(ROOT)): value for path, value in sources.items()}}
        (run / "results.json").write_bytes(encode(report))
    except BaseException:
        finish_run(DEFAULT_ROOT, run, "failed", False)
        raise
    finish_run(DEFAULT_ROOT, run, "passed", False)
    prune_runs(DEFAULT_ROOT, apply=True)
    print("Native boss paths captured: " + str(run / "results.json"))


if __name__ == "__main__":
    main()
