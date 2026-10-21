"""Revalidate retained native boss routes before adding them to a release candidate."""
import hashlib
import json
from pathlib import Path
import sys

import package_coop_boss_paths as package

ROOT = Path(__file__).resolve().parents[2]
sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import checked_run, has_links, read_manifest

FILES = {"boss-native-paths.json": "native-paths.json", "boss-anchors.json": "anchors.json",
         "boss-navigation.json": "navigation.json", "boss-native-results.json": "results.json"}


def digest(value):
    return hashlib.sha256(value).hexdigest()


def encode(value):
    return (json.dumps(value, indent=2, allow_nan=False) + "\n").encode()


def verify_sources(report, navigation):
    required = {"Clients/ExportedProject/Assets/Scenes/MainScene.unity",
                "Server/content/recovered-army-navmesh-sources.json",
                "Server/tools/Unity/BossPaths/BossPathCapture.cs"}
    for row in navigation["maps"]:
        for name in (row["scene"], row["navMeshAsset"], row["navMeshAsset"] + ".meta"):
            required.add("Clients/ExportedProject/" + name)
    sources = report["sources"]
    canonical = {Path(name).as_posix(): value for name, value in sources.items()}
    if len(canonical) != len(sources) or set(canonical) != required:
        raise ValueError("Native boss source inventory is incomplete or unexpected")
    for name, expected in canonical.items():
        path = ROOT / name
        if not path.resolve().is_relative_to(ROOT.resolve()) or path.is_symlink():
            raise ValueError("Unsafe native boss source path")
        if digest(path.read_bytes()) != expected:
            raise ValueError("Native boss source changed: " + name)


def bind_run(run, anchor_bytes):
    run = run.resolve()
    checked_run(run.parent, run)
    manifest = read_manifest(run)
    if manifest["suite"] not in {"boss-path-capture", "sheet-candidates"} or manifest["status"] != "passed":
        raise ValueError("Boss evidence requires a completed capture or retained stage")
    if has_links(run):
        raise ValueError("Boss evidence cannot contain links")
    previous = None
    if manifest["suite"] == "boss-path-capture":
        evidence = {name: (run / original).read_bytes() for name, original in FILES.items()}
    else:
        previous = json.loads((run / "results.json").read_bytes()).get("bossPathEvidence")
        if not isinstance(previous, dict):
            raise ValueError("Staged run has no native boss-path proof")
        evidence = {name: (run / "evidence" / name).read_bytes() for name in FILES}
        if previous["evidenceHashes"] != {name: digest(payload) for name, payload in evidence.items()}:
            raise ValueError("Retained boss evidence changed after staging")
    report = json.loads(evidence["boss-native-results.json"])
    native = evidence["boss-native-paths.json"]
    navigation = evidence["boss-navigation.json"]
    if evidence["boss-anchors.json"] != anchor_bytes or navigation != package.NAVIGATION.read_bytes():
        raise ValueError("Native boss capture does not bind current candidate anchors/navigation")
    if report["nativeSha256"] != digest(native) or report["routeCount"] != 120:
        raise ValueError("Native boss output identity differs")
    verify_sources(report, json.loads(navigation))
    candidate = package.build_document(anchor_bytes, navigation, native)
    payload = encode(candidate)
    if report["candidateSha256"] != digest(payload):
        raise ValueError("Native boss candidate differs from capture")
    original = json.loads(package.OUTPUT.read_bytes())
    changed = {key for key in original if encode(original[key]) != encode(candidate[key])}
    if original.keys() != candidate.keys() or changed != {"anchorSourceSha256"}:
        raise ValueError("Unreviewed boss route or schema changes")
    proof = {"nativeRunId": previous["nativeRunId"] if previous else run.name,
             "evidenceInputRunId": run.name, "candidateSha256": digest(payload), "routeCount": 120,
             "evidenceHashes": {name: digest(value) for name, value in evidence.items()},
             "releaseVerified": False}
    return payload, proof, evidence
