"""Reproduce exported float loss in Unity's Mono without launching the Editor or copying Assets."""
import argparse
import hashlib
import json
import os
import shutil
import struct
import subprocess
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, prune_runs, start_run


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def bits(value):
    return struct.pack("<f", value)[::-1].hex()


def compile_exporter(editor_data, run):
    mono = editor_data / "MonoBleedingEdge/bin/mono.exe"
    compiler = editor_data / "MonoBleedingEdge/lib/mono/4.5/mcs.exe"
    exporter = ROOT / "Clients/ExportedProject/Assets/Editor/SelfHostedBattleExport.cs"
    assemblies = ROOT / "Clients/AuxiliaryFiles/GameAssemblies"
    references = sorted((editor_data / "Managed/UnityEngine").glob("*.dll"))
    references.append(editor_data / "Managed/UnityEditor.dll")
    references.extend(assemblies / name for name in
                      ["Assembly-CSharp.dll", "Assembly-CSharp-firstpass.dll", "Newtonsoft.Json.dll"])
    command = [str(mono), str(compiler), "-target:library", "-out:" + str(run / "data/Exporter.dll")]
    command.extend("-r:" + str(path) for path in references)
    command.append(str(exporter))
    result = subprocess.run(command, capture_output=True, timeout=60)
    (run / "exporter-compile.log").write_bytes(result.stdout + result.stderr)
    result.check_returncode()
    return digest(exporter)


def execute_probe(editor_data, run):
    mono = editor_data / "MonoBleedingEdge/bin/mono.exe"
    compiler = editor_data / "MonoBleedingEdge/lib/mono/4.5/mcs.exe"
    source = ROOT / "Server/tools/MonoFloatExportProbe.cs"
    audit_path = ROOT / "Server/docs/battle-sheet-value-audit.json"
    audit = json.loads(audit_path.read_bytes())
    samples = [row for row in audit["differences"] if row["kind"] == "ObscuredFloat"]
    if not samples:
        raise ValueError("No reviewed float differences to reproduce")
    output = run / "data"
    output.mkdir(exist_ok=True)
    executable = output / "FloatProbe.exe"
    command = [str(mono), str(compiler), "-out:" + str(executable), str(source)]
    assemblies = ROOT / "Clients/AuxiliaryFiles/GameAssemblies"
    references = [assemblies / name for name in
                  ["Assembly-CSharp-firstpass.dll", "UnityEngine.dll", "Newtonsoft.Json.dll"]]
    command.extend("-r:" + str(path) for path in references)
    # Do not put the original assembly directory on MONO_PATH: it also contains an older mscorlib.
    for reference in references:
        shutil.copyfile(reference, output / reference.name)
    compiled = subprocess.run(command, capture_output=True, timeout=60)
    (run / "compile.log").write_bytes(compiled.stdout + compiled.stderr)
    compiled.check_returncode()
    inputs = "".join(bits(row["source"]) + "\n" for row in samples).encode()
    environment = os.environ.copy()
    environment["MONO_PATH"] = str(output)
    result = subprocess.run([str(mono), str(executable)], input=inputs,
                            capture_output=True, timeout=60, env=environment)
    (run / "probe.tsv").write_bytes(result.stdout)
    (run / "probe-error.log").write_bytes(result.stderr)
    result.check_returncode()
    observed = result.stdout.decode("utf-8-sig").splitlines()
    if len(observed) != len(samples):
        raise ValueError("Mono probe returned a different sample count")
    for row, line in zip(samples, observed):
        source_bits, formatted, exported_bits, corrected_bits, serialized_bits = line.split("|")
        if source_bits != bits(row["source"]) or exported_bits != bits(row["exported"]):
            raise ValueError("Mono formatting does not explain the reviewed export difference")
        if corrected_bits != source_bits or serialized_bits != source_bits:
            raise ValueError("Direct conversion or JSON round trip loses source bits")
    exporter_hash = compile_exporter(editor_data, run)
    return {"sampleCount": len(samples), "monoSha256": digest(mono), "compilerSha256": digest(compiler),
            "probeSourceSha256": digest(source), "auditSha256": digest(audit_path),
            "exporterSourceSha256": exporter_hash, "exporterCompiled": True,
            "referenceAssemblies": {path.name: digest(path) for path in references},
            "allLegacyRoundTripsReproduced": True, "allCorrectedRoundTripsExact": True,
            "unitySceneExecuted": False}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--editor-data", type=Path, required=True)
    args = parser.parse_args()
    run = start_run(DEFAULT_ROOT, "float-export", os.getpid())
    try:
        report = execute_probe(args.editor_data.resolve(), run)
        (run / "results.json").write_text(json.dumps(report, indent=2) + "\n", encoding="utf-8")
    except BaseException:
        finish_run(DEFAULT_ROOT, run, "failed", False)
        raise
    finish_run(DEFAULT_ROOT, run, "passed", False)
    prune_runs(DEFAULT_ROOT, apply=True)
    print("PASS: Mono reproduces " + str(report["sampleCount"]) + " lossy float exports")
    print("Report: " + str(run / "results.json"))


if __name__ == "__main__":
    main()
