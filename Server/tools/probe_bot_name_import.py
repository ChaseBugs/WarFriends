"""Observe plain versus escaped Unicode YAML in one tiny owned Unity project."""
import argparse
import base64
import json
import os
import shutil
import subprocess
import sys
from pathlib import Path

import yaml

from audit_battle_sheet_values import UniqueScalarLoader
from audit_bot_name_source import SCENE, create_report, file_hash
from prepare_bot_name_import import prepare_scene

ROOT = Path(__file__).resolve().parents[2]
sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, prune_runs, start_run

FIXTURE_GUID = "ac742769ba084b1e9f05ae56d4b61720"
PREFAB = """%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!1 &6369
GameObject:
  m_ObjectHideFlags: 0
  m_Component:
  - component: {fileID: 1}
  - component: {fileID: 46609}
  m_Layer: 0
  m_Name: BotNames
  m_TagString: Untagged
  m_IsActive: 1
--- !u!4 &1
Transform:
  m_ObjectHideFlags: 0
  m_GameObject: {fileID: 6369}
  m_LocalRotation: {x: 0, y: 0, z: 0, w: 1}
  m_LocalPosition: {x: 0, y: 0, z: 0}
  m_LocalScale: {x: 1, y: 1, z: 1}
  m_Children: []
  m_Father: {fileID: 0}
--- !u!114 &46609
MonoBehaviour:
  m_ObjectHideFlags: 0
  m_GameObject: {fileID: 6369}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 11500000, guid: GUID, type: 3}
  m_Name:
  m_EditorClassIdentifier:
  Rows:
"""


def prepare_project(run):
    blocks = [block for block in SCENE.read_text(encoding="utf-8-sig").split("--- !u!")
              if block.startswith("114 &46609\n")]
    if len(blocks) != 1:
        raise ValueError("Missing source component")
    rows = yaml.load(blocks[0].split("\n", 1)[1], Loader=UniqueScalarLoader)["MonoBehaviour"]["Rows"]
    names = [row["NAME"] for row in rows]
    project = run / "data/project"
    editor = project / "Assets/Editor"
    editor.mkdir(parents=True)
    source = ROOT / "Server/tools/Unity/BotNamesImport"
    shutil.copyfile(source / "BotNamesImportAudit.cs", editor / "BotNamesImportAudit.cs")
    fixture = project / "Assets/BotNamesImportFixture.cs"
    shutil.copyfile(source / fixture.name, fixture)
    fixture.with_suffix(".cs.meta").write_text("fileFormatVersion: 2\nguid: " + FIXTURE_GUID + "\n")
    prefix = PREFAB.replace("GUID", FIXTURE_GUID)
    # Keep the exact source scalar spelling for the plain fixture.
    source_rows = blocks[0].split("  Rows:\n", 1)[1].rstrip() + "\n"
    (project / "Assets/Plain.prefab").write_text(prefix + source_rows, encoding="utf-8", newline="\n")
    prepared, changes = prepare_scene(SCENE.read_bytes())
    if len(changes) != 4:
        raise ValueError("Source Unicode import inventory changed")
    prepared_block = prepared.decode("utf-8-sig").split("--- !u!114 &46609\n", 1)[1].split("--- !u!", 1)[0]
    quoted = prepared_block.split("  Rows:\n", 1)[1].rstrip() + "\n"
    (project / "Assets/Quoted.prefab").write_text(prefix + quoted, encoding="utf-8", newline="\n")
    (project / "Packages").mkdir()
    (project / "Packages/manifest.json").write_text('{"dependencies": {}}\n')
    (project / "ProjectSettings").mkdir()
    (project / "ProjectSettings/ProjectVersion.txt").write_text("m_EditorVersion: 2018.3.0f2\n")
    return project, names


def capture(editor, project, run):
    environment = os.environ.copy()
    environment["WAR_BOT_NAMES_OUTPUT"] = str(run)
    command = [str(editor), "-batchmode", "-nographics", "-quit", "-projectPath", str(project),
               "-executeMethod", "BotNamesImportAudit.Run", "-logFile", str(run / "unity.log")]
    with (run / "process.log").open("wb") as log:
        process = subprocess.Popen(command, env=environment, stdout=log, stderr=subprocess.STDOUT)
        try:
            if process.wait(timeout=180) != 0:
                raise ValueError("Unity import probe failed; inspect the owned log")
        except subprocess.TimeoutExpired:
            if process.poll() is None:
                subprocess.run(["taskkill", "/PID", str(process.pid), "/T", "/F"], capture_output=True, check=True)
                process.wait(timeout=30)
            raise


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--unity", type=Path, required=True)
    args = parser.parse_args()
    run = start_run(DEFAULT_ROOT, "bot-name-import", os.getpid())
    try:
        source_audit = create_report()
        project, names = prepare_project(run)
        capture(args.unity.resolve(), project, run)
        observed = {}
        for variant in ["Plain", "Quoted"]:
            values = [base64.b64decode(line, validate=True).decode("utf-8")
                      for line in (run / (variant + ".txt")).read_text().splitlines()]
            if len(values) != len(names):
                raise ValueError("Imported fixture row count differs")
            observed[variant] = [{"rowIndex": index, "source": source, "imported": value}
                                 for index, (source, value) in enumerate(zip(names, values)) if source != value]
        expected = [{"rowIndex": row["rowIndex"], "source": row["original"], "imported": row["exported"]}
                    for row in source_audit["differences"]]
        if observed["Plain"] != expected or observed["Quoted"]:
            raise ValueError("Native import no longer reproduces the audited defect and lossless escaped fixture")
        sources = [Path(__file__), ROOT / "Server/tools/prepare_bot_name_import.py",
                   ROOT / "Server/tools/Unity/BotNamesImport/BotNamesImportAudit.cs",
                   ROOT / "Server/tools/Unity/BotNamesImport/BotNamesImportFixture.cs"]
        report = {"rowCount": len(names), "differences": observed, "productionFilesWritten": False,
                  "releaseVerified": False, "sceneSha256": source_audit["sceneSha256"],
                  "original": source_audit["original"], "editorSha256": file_hash(args.unity),
                  "probeHashes": {str(path.relative_to(ROOT)): file_hash(path) for path in sources}}
        (run / "results.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    except BaseException:
        finish_run(DEFAULT_ROOT, run, "failed", False)
        raise
    finish_run(DEFAULT_ROOT, run, "passed", False)
    prune_runs(DEFAULT_ROOT, apply=True)
    print("Captured native YAML import: " + str(run / "results.json"))


if __name__ == "__main__":
    main()
