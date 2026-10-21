"""Stage source-reextracted mission candidates in a bounded managed run, never production content."""
import argparse
import json
import os
import sys
from pathlib import Path

import audit_main_scene_provenance as provenance
import extract_coop_bot_health as health
import extract_coop_bot_rules as bots
import extract_mission_catalog as missions
import extract_coop_boss_attack_timing as attacks
import extract_coop_boss_loadouts as loadouts
import extract_coop_boss_anchors as anchors
import extract_coop_shield_states as shields
import extract_coop_navmesh_sources as navigation
import stage_navmesh_detail as navigation_detail
import extract_coop_prefab_colliders as prefab_colliders
import verify_coop_prefab_mesh_geometry as prefab_meshes
import extract_player_shot_targets as player_targets
import stage_coop_navigation_references as navigation_references

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, prune_runs, start_run

ROOT = Path(__file__).resolve().parents[2]
POLICIES = {
    "recovered-coop-navmesh-paths.json": {"navigationSourceSha256"},
    "recovered-coop-navmesh-triangulation.json": {"navigationSourceSha256"},
    "recovered-player-shot-targets.json": {"sceneSha256"},
    "recovered-coop-prefab-mesh-geometry.json": {"colliderSourceSha256"},
    "recovered-coop-prefab-colliders.json": {"mainSceneSha256"},
    "recovered-coop-navmesh-detail.json": {"sourceManifestSha256"},
    "recovered-coop-navmesh-sources.json": {"missionSourceSha256"},
    "recovered-coop-shield-states.json": {"sourceSha256"},
    "recovered-coop-boss-anchors.json": {"missionSourceSha256"},
    "recovered-coop-boss-attack-timing.json": {"sceneSha256", "botRulesSha256"},
    "recovered-coop-boss-loadouts.json": {"sceneSha256", "attackSourceSha256"},
    "recovered-mission-catalog.json": {"sourceSha256"},
    "recovered-coop-bot-rules.json": {"missionSourceSha256"},
    "recovered-coop-bot-health.json": {"sceneSha256", "botRulesSha256"},
}
PRODUCERS = {
    "recovered-coop-navmesh-paths.json": "stage_coop_navigation_references.py",
    "recovered-coop-navmesh-triangulation.json": "stage_coop_navigation_references.py",
    "recovered-player-shot-targets.json": "extract_player_shot_targets.py",
    "recovered-coop-prefab-mesh-geometry.json": "verify_coop_prefab_mesh_geometry.py",
    "recovered-coop-prefab-colliders.json": "extract_coop_prefab_colliders.py",
    "recovered-coop-navmesh-detail.json": "stage_navmesh_detail.py",
    "recovered-coop-navmesh-sources.json": "extract_coop_navmesh_sources.py",
    "recovered-coop-shield-states.json": "extract_coop_shield_states.py",
    "recovered-coop-boss-anchors.json": "extract_coop_boss_anchors.py",
    "recovered-coop-boss-attack-timing.json": "extract_coop_boss_attack_timing.py",
    "recovered-coop-boss-loadouts.json": "extract_coop_boss_loadouts.py",
    "recovered-mission-catalog.json": "extract_mission_catalog.py",
    "recovered-coop-bot-rules.json": "extract_coop_bot_rules.py",
    "recovered-coop-bot-health.json": "extract_coop_bot_health.py",
}


def encode(document):
    return (json.dumps(document, indent=2, allow_nan=False) + "\n").encode("utf-8")


def compare_candidate(name, previous_bytes, candidate_bytes):
    previous = json.loads(previous_bytes)
    candidate = json.loads(candidate_bytes)
    if previous.keys() != candidate.keys():
        raise ValueError("Candidate schema differs: " + name)
    changed = {key for key in previous if encode(previous[key]) != encode(candidate[key])}
    if changed != POLICIES[name]:
        raise ValueError("Candidate changes more or less than the reviewed provenance fields: " + name)
    return {
        "path": "Server/content/" + name,
        "previousSha256": provenance.digest(previous_bytes),
        "candidateSha256": provenance.digest(candidate_bytes),
        "changedFields": sorted(changed),
        "candidateBytes": len(candidate_bytes),
        "gameplayValuesEqual": True,
    }


def build_candidates(scene):
    mission_document = missions.build_document(scene)
    bot_document = bots.build_document(scene, mission_document)
    bot_bytes = encode(bot_document)
    attack_bytes = encode(attacks.build_document(scene, bot_bytes))
    navigation_document = navigation.build_document(encode(mission_document))
    navigation.verify_packaged_assets(navigation_document)
    collider_bytes = encode(prefab_colliders.build_document(scene))
    return {
        **{name: encode(document) for name, document in
           navigation_references.build_candidates(encode(navigation_document)).items()},
        "recovered-player-shot-targets.json": encode(player_targets.build_document(scene)),
        "recovered-coop-prefab-mesh-geometry.json": encode(prefab_meshes.build_document(collider_bytes)),
        "recovered-coop-prefab-colliders.json": collider_bytes,
        "recovered-coop-navmesh-detail.json": encode(navigation_detail.build_document(encode(navigation_document))),
        "recovered-coop-navmesh-sources.json": encode(navigation_document),
        "recovered-coop-shield-states.json": encode(shields.build_document(scene, encode(mission_document))),
        "recovered-coop-boss-anchors.json": encode(anchors.build_document(encode(mission_document))),
        "recovered-coop-boss-attack-timing.json": attack_bytes,
        "recovered-coop-boss-loadouts.json": encode(loadouts.build_document(scene, bot_bytes, attack_bytes)),
        "recovered-mission-catalog.json": encode(mission_document),
        "recovered-coop-bot-rules.json": bot_bytes,
        "recovered-coop-bot-health.json": encode(health.build_document(scene, bot_bytes)),
    }


def prepare_stage(expected_scene=None):
    audit_bytes = provenance.REPORT.read_bytes()
    audit = json.loads(audit_bytes)
    if audit != provenance.create_report():
        raise ValueError("Provenance audit is stale; review before staging")
    scene = missions.SCENE.read_bytes()
    if expected_scene is not None and scene != expected_scene:
        raise ValueError("Mission candidates must use the same scene bytes as the enclosing release")
    if provenance.digest(scene) != audit["afterSha256"]:
        raise ValueError("Scene changed after the provenance audit")
    candidates = build_candidates(scene)
    expected = {row["path"]: row["sha256"] for row in audit["affectedArtifacts"]}
    results = []
    for name, payload in candidates.items():
        original = (ROOT / "Server/content" / name).read_bytes()
        if provenance.digest(original) != expected["Server/content/" + name]:
            raise ValueError("Production content changed after the provenance audit")
        result = compare_candidate(name, original, payload)
        producer = ROOT / "Server/tools" / PRODUCERS[name]
        result["producerPath"] = producer.relative_to(ROOT).as_posix()
        result["producerSha256"] = provenance.digest(producer.read_bytes())
        results.append(result)
    if missions.SCENE.read_bytes() != scene:
        raise ValueError("Scene changed during candidate extraction")
    report = {
        "schemaVersion": 1,
        "sceneSha256": provenance.digest(scene),
        "provenanceReportSha256": provenance.digest(audit_bytes),
        "stagingToolSha256": provenance.digest(Path(__file__).read_bytes()),
        "releaseVerified": False,
        "productionFilesWritten": False,
        "artifacts": results,
    }
    return candidates, report


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.parse_args()
    run = start_run(DEFAULT_ROOT, "mission-candidates", os.getpid())
    try:
        candidates, report = prepare_stage()
        output = run / "candidates"
        output.mkdir()
        for name, payload in candidates.items():
            (output / name).write_bytes(payload)
        (run / "results.json").write_bytes(encode(report))
    except BaseException:
        finish_run(DEFAULT_ROOT, run, "failed", False)
        raise
    finish_run(DEFAULT_ROOT, run, "passed", False)
    prune_runs(DEFAULT_ROOT, apply=True)
    print(f"PASS: {len(candidates)} source-reextracted candidates; gameplay values equal; release remains unverified")
    print("Report: " + str(run / "results.json"))


if __name__ == "__main__":
    main()
