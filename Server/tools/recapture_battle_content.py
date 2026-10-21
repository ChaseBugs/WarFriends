"""Run the real Editor exporter in one owned source copy, without copying an imported Library."""
import argparse
import hashlib
import json
import os
import shutil
import subprocess
import sys
from pathlib import Path

from audit_battle_sheet_values import CONTENT, ROOT, compare_sheet, component_index
from prepare_bot_name_import import prepare_scene

sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, has_links, prepare_test_environment, prune_runs, start_run


def digest(data):
    return hashlib.sha256(data).hexdigest()


def write_report(path, value):
    path.write_text(json.dumps(value, indent=2, allow_nan=False) + "\n", encoding="utf-8")


def prepare_project(run, *, prepare_strings=True):
    source = ROOT / "Clients/ExportedProject"
    project = run / "data/project"
    inventory = {}
    for directory in ("Assets", "Packages", "ProjectSettings"):
        original = source / directory
        if has_links(original):
            raise ValueError("Linked source trees require explicit review")
        for path in sorted(original.rglob("*")):
            if not path.is_file():
                continue
            relative = path.relative_to(source)
            payload = path.read_bytes()
            target = project / relative
            target.parent.mkdir(parents=True, exist_ok=True)
            target.write_bytes(payload)
            inventory[relative.as_posix()] = {"sha256": digest(payload), "bytes": len(payload)}
    scene = (project / "Assets/Scenes/MainScene.unity").read_bytes()
    prepared, changes = prepare_scene(scene) if prepare_strings else (scene, [])
    (project / "Assets/Scenes/MainScene.unity").write_bytes(prepared)
    # These are package source dependencies, not a copied asset database or compiled game cache.
    packages = source / "Library/PackageCache"
    if packages.exists():
        if has_links(packages):
            raise ValueError("Linked package cache is not a reproducible input")
        shutil.copytree(packages, project / "Library/PackageCache", copy_function=shutil.copyfile)
        for path in sorted(packages.rglob("*")):
            if path.is_file():
                payload = path.read_bytes()
                inventory[path.relative_to(source).as_posix()] = {"sha256": digest(payload), "bytes": len(payload)}
    write_report(run / "source-inventory.json", inventory)
    return project, scene, prepared, changes


def execute_editor(editor, project, run, *, method="SelfHostedBattleExport.Run", outputs=None):
    environment = prepare_test_environment(DEFAULT_ROOT, run)
    if outputs is None:
        outputs = {"WAR_BATTLE_CONTENT_OUTPUT": run / "native-battle-content.json"}
    environment.update({name: str(path) for name, path in outputs.items()})
    command = [str(editor), "-batchmode", "-nographics", "-noUpm", "-quit", "-projectPath", str(project),
               "-executeMethod", method, "-logFile", str(run / "unity.log")]
    with (run / "process.log").open("wb") as output:
        process = subprocess.Popen(command, env=environment, stdout=output, stderr=subprocess.STDOUT)
        try:
            code = process.wait(timeout=600)
        except subprocess.TimeoutExpired:
            if process.poll() is None:
                subprocess.run(["taskkill", "/PID", str(process.pid), "/T", "/F"], check=True, capture_output=True)
                process.wait(timeout=30)
            raise
    if code != 0:
        raise ValueError("Native Editor export failed with exit " + str(code) + "; inspect unity.log")


def validate_export(run, scene, prepared, record_differences=True):
    payload = (run / "native-battle-content.json").read_bytes()
    document = json.loads(payload)
    if document["mainSceneSha256"] != digest(prepared):
        raise ValueError("Native exporter did not bind its actual prepared input")
    sheets = document["sheets"]
    if len(sheets) != 132 or len({sheet["type"] for sheet in sheets}) != 132:
        raise ValueError("Native sheet inventory differs")
    blocks = component_index(scene.decode("utf-8-sig"))
    differences = []
    for sheet in sheets:
        changes, _, _ = compare_sheet(sheet, blocks)
        differences.extend(changes)
    if record_differences:
        write_report(run / "sheet-differences.json", differences)
    if differences:
        raise ValueError("Native export differs from typed original sheet values")
    previous = json.loads(CONTENT.read_bytes())
    if document["maps"] != previous["maps"] or document["meshes"] != previous["meshes"]:
        raise ValueError("Native geometry changed and requires separate source review")
    identities = lambda rows: [(row["type"], row["path"]) for row in rows]
    if identities(sheets) != identities(previous["sheets"]):
        raise ValueError("Native sheet identity/order changed")
    return digest(payload)


def verify_source_snapshot(run):
    inventory = json.loads((run / "source-inventory.json").read_bytes())
    return verify_source_inventory(inventory)


def verify_source_inventory(inventory):
    source = ROOT / "Clients/ExportedProject"
    folders = ["Assets", "Packages", "ProjectSettings"]
    if any(name.startswith("Library/") for name in inventory):
        folders.append("Library/PackageCache")
    expected_paths = {path.relative_to(source).as_posix()
                      for folder in folders for path in (source / folder).rglob("*") if path.is_file()}
    if set(inventory) != expected_paths:
        raise ValueError("Native source inventory is incomplete or has changed")
    for relative, expected in inventory.items():
        path = source / relative
        if digest(path.read_bytes()) != expected["sha256"]:
            raise ValueError("Source changed during native recapture: " + relative)
    return len(inventory)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    if not args.unity.is_file():
        parser.error("Unity executable does not exist")
    prune_runs(DEFAULT_ROOT, apply=True)
    run = start_run(DEFAULT_ROOT, "battle-recapture", os.getpid())
    print("Owned native recapture: " + str(run), flush=True)
    try:
        project, scene, prepared, changes = prepare_project(run)
        report = {"releaseVerified": False, "productionFilesWritten": False,
                  "sourceSceneSha256": digest(scene), "preparedSceneSha256": digest(prepared),
                  "preparedRows": changes, "runnerSha256": digest(Path(__file__).read_bytes()),
                  "editorSha256": digest(args.unity.read_bytes()),
                  "preparerSha256": digest((ROOT / "Server/tools/prepare_bot_name_import.py").read_bytes())}
        write_report(run / "results.json", report)
        print("Source copy prepared; importing and executing actual exporter", flush=True)
        execute_editor(args.unity.resolve(), project, run)
        report["nativeContentSha256"] = validate_export(run, scene, prepared)
        report["unchangedSourceFiles"] = verify_source_snapshot(run)
        report["nativeGeometryMatchesPrevious"] = True
        report["nativeExportVerified"] = True
        write_report(run / "results.json", report)
    except BaseException as error:
        write_report(run / "failure.json", {"type": type(error).__name__, "message": str(error)})
        finish_run(DEFAULT_ROOT, run, "failed", False)
        raise
    finish_run(DEFAULT_ROOT, run, "passed", False)
    print("Native candidate captured: " + str(run), flush=True)


if __name__ == "__main__":
    main()
