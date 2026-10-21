"""Stage reviewed source-sheet corrections without publishing or recertifying native geometry."""
import argparse
import copy
import hashlib
import json
import os
import sys
from pathlib import Path

from audit_battle_sheet_values import CONTENT, ROOT, SCENE, component_index, create_report
from audit_battle_sheet_values import compare_sheet, read_cell, read_sheet_source
from audit_bot_name_source import create_report as bot_name_report
from prepare_bot_name_import import prepare_scene
from stage_sheet_dependents import PRODUCERS, build_candidates as build_dependents
from bind_native_battle_evidence import bind_native_run
import stage_mission_content as mission_stage
from bind_boss_path_evidence import bind_run as bind_boss_paths
from bind_weapon_evidence import bind_run as bind_weapons
from bind_weapon_family_evidence import bind_run as bind_weapon_families
import stage_weapon_manifests as weapon_manifests
from bind_pose_evidence import bind_run as bind_poses
from bind_grenade_target_evidence import bind_run as bind_grenade_targets
import build_player_weapon_index_map as weapon_indexes
from bind_player_reference_evidence import bind_run as bind_player_references
from bind_blast_reference_evidence import bind_run as bind_blast_references
import stage_combat_manifest as combat_manifest

sys.path.insert(0, str(ROOT / "Server/scripts"))
from test_artifacts import DEFAULT_ROOT, finish_run, prune_runs, start_run


def sha256(data):
    return hashlib.sha256(data).hexdigest()


def encode(value):
    return (json.dumps(value, indent=2, ensure_ascii=True, allow_nan=False) + "\n").encode("utf-8")


def build_candidate(scene, content, audit, names):
    if sha256(scene) != audit["sceneSha256"] or sha256(content) != audit["contentSha256"]:
        raise ValueError("Sheet audit does not describe the candidate inputs")
    if names["sceneSha256"] != audit["sceneSha256"] or names["contentSha256"] != audit["contentSha256"]:
        raise ValueError("Original name proof does not describe the candidate inputs")
    if names["allSceneStringsMatchOriginal"] is not True:
        raise ValueError("Missing original string proof")
    allowed_names = {(row["rowIndex"], row["original"], row["exported"]) for row in names["differences"]}
    for row in audit["differences"]:
        float_loss = row["kind"] == "ObscuredFloat" and row["classification"] == "matches-seven-significant-digit-format"
        name_loss = (row["sheet"] == "Google2u.BotNames" and row["kind"] == "string" and
                     row["field"] == "NAME" and
                     (row["rowIndex"], row["source"], row["exported"]) in allowed_names)
        if not float_loss and not name_loss:
            raise ValueError("Unreviewed gameplay difference cannot enter this candidate")
    document = json.loads(content)
    candidate = copy.deepcopy(document)
    blocks = component_index(scene.decode("utf-8-sig"))
    changes = []
    for sheet in candidate["sheets"]:
        differences, _, _ = compare_sheet(sheet, blocks)
        changes.extend(differences)
        rows, fields, _ = read_sheet_source(sheet, blocks)
        sheet["rows"] = [{field: read_cell(row[field], kind) for field, kind in fields.items()} for row in rows]
        remaining, _, _ = compare_sheet(sheet, blocks)
        if remaining:
            raise ValueError("Candidate does not preserve every source scalar")
    if changes != audit["differences"] or len(changes) != audit["differenceCount"]:
        raise ValueError("Candidate difference set disagrees with the reviewed audit")
    candidate["mainSceneSha256"] = sha256(scene)
    # Geometry, native observations, source paths, sheet identities/order and metadata stay untouched.
    previous = copy.deepcopy(document)
    unchanged = copy.deepcopy(candidate)
    previous.pop("mainSceneSha256")
    unchanged.pop("mainSceneSha256")
    for package in (previous, unchanged):
        for sheet in package["sheets"]:
            sheet.pop("rows")
    if encode(previous) != encode(unchanged):
        raise ValueError("Sheet extraction changed an unrelated native-content field")
    return encode(candidate)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--native-run", type=Path, help="Completed native recapture or stage retaining native evidence")
    parser.add_argument("--starter-observation", type=Path, help="Reviewed current Client starter export")
    parser.add_argument("--boss-path-run", type=Path, help="Completed boss capture or stage retaining its evidence")
    parser.add_argument("--weapon-run", type=Path, help="Completed weapon capture or stage retaining its evidence")
    parser.add_argument("--weapon-family-run", type=Path, help="Completed family capture or retained stage")
    parser.add_argument("--pose-run", type=Path, help="Completed native pose capture or retained stage")
    parser.add_argument("--grenade-target-run", type=Path, help="Completed grenade target capture or retained stage")
    parser.add_argument("--player-reference-run", type=Path, help="Completed player reference capture or retained stage")
    parser.add_argument("--blast-reference-run", type=Path, help="Completed blast reference capture or retained stage")
    args = parser.parse_args()
    run = start_run(DEFAULT_ROOT, "sheet-candidates", os.getpid())
    try:
        audit = create_report()
        recorded = json.loads((ROOT / "Server/docs/battle-sheet-value-audit.json").read_bytes())
        if audit != recorded:
            raise ValueError("Refresh and review source differences before staging")
        names = bot_name_report()
        source = SCENE.read_bytes()
        content = CONTENT.read_bytes()
        prepared, changes = prepare_scene(source)
        candidate = build_candidate(source, content, audit, names)
        observation = args.starter_observation.read_bytes() if args.starter_observation else None
        dependents = build_dependents(source, candidate, names, observation)
        mission_candidates, mission_report = mission_stage.prepare_stage(source)
        if dependents.keys() & mission_candidates.keys():
            raise ValueError("Duplicate candidate ownership across sheet and mission producers")
        dependents.update(mission_candidates)
        producers = {**PRODUCERS, **mission_stage.PRODUCERS}
        native_proof, evidence = (None, {})
        if args.native_run:
            native_proof, evidence = bind_native_run(args.native_run, source, prepared, candidate)
        weapon_proof = None
        if args.weapon_run:
            payload, weapon_proof, weapon_evidence = bind_weapons(args.weapon_run, source)
            dependents["recovered-all-weapon-bindings.json"] = payload
            producers["recovered-all-weapon-bindings.json"] = "recapture_weapon_bindings.py"
            evidence.update(weapon_evidence)
            if observation is not None:
                index_name = "recovered-player-weapon-indexes.json"
                dependents[index_name] = encode(weapon_indexes.build_document(observation, payload))
                producers[index_name] = "build_player_weapon_index_map.py"
        family_proof = None
        if args.weapon_family_run:
            family_candidates, family_proof, family_evidence = bind_weapon_families(args.weapon_family_run, source)
            if dependents.keys() & family_candidates.keys():
                raise ValueError("Duplicate weapon family candidate ownership")
            dependents.update(family_candidates)
            producers.update({name: "bind_weapon_family_evidence.py" for name in family_candidates})
            evidence.update(family_evidence)
            manifests = weapon_manifests.build_candidates(source, candidate, family_candidates)
            dependents.update(manifests)
            producers.update({name: "stage_weapon_manifests.py" for name in manifests})
        pose_proof = None
        if args.pose_run:
            pose_candidates, pose_proof, pose_evidence = bind_poses(args.pose_run, source)
            if dependents.keys() & pose_candidates.keys():
                raise ValueError("Duplicate pose candidate ownership")
            dependents.update(pose_candidates)
            producers.update({name: "bind_pose_evidence.py" for name in pose_candidates})
            evidence.update(pose_evidence)
            if args.weapon_family_run:
                dependents["grenade-content-manifest.json"] = weapon_manifests.build_grenade(source, candidate, dependents)
                producers["grenade-content-manifest.json"] = "stage_weapon_manifests.py"
        grenade_target_proof = None
        player_reference_proof = None
        if args.player_reference_run:
            reference_candidates, player_reference_proof, reference_evidence = bind_player_references(
                args.player_reference_run, source)
            if dependents.keys() & reference_candidates.keys():
                raise ValueError("Duplicate player reference candidate ownership")
            dependents.update(reference_candidates)
            producers.update({name: "bind_player_reference_evidence.py" for name in reference_candidates})
            evidence.update(reference_evidence)
        if args.grenade_target_run:
            payload, grenade_target_proof, target_evidence = bind_grenade_targets(args.grenade_target_run, source)
            dependents["recovered-grenade-shot-targets.json"] = payload
            producers["recovered-grenade-shot-targets.json"] = "bind_grenade_target_evidence.py"
            evidence.update(target_evidence)
        blast_proof = None
        if args.blast_reference_run:
            if not args.weapon_run:
                raise ValueError("Blast reference staging requires native candidate weapon evidence")
            blast_candidates, blast_proof, blast_evidence = bind_blast_references(
                args.blast_reference_run, source, dependents["recovered-all-weapon-bindings.json"])
            if dependents.keys() & blast_candidates.keys():
                raise ValueError("Duplicate blast reference candidate ownership")
            dependents.update(blast_candidates)
            producers.update({name: "bind_blast_reference_evidence.py" for name in blast_candidates})
            evidence.update(blast_evidence)
        boss_proof = None
        if args.boss_path_run:
            payload, boss_proof, boss_evidence = bind_boss_paths(
                args.boss_path_run, dependents["recovered-coop-boss-anchors.json"])
            dependents["recovered-coop-boss-paths.json"] = payload
            producers["recovered-coop-boss-paths.json"] = "package_coop_boss_paths.py"
            evidence.update(boss_evidence)
        if observation is not None:
            evidence["starter-loadout-observation.json"] = observation
        if args.weapon_run and args.weapon_family_run and args.pose_run:
            package_inputs = {CONTENT.name: candidate, **dependents}
            combat_candidates = combat_manifest.build_candidates(source, package_inputs)
            dependents.update(combat_candidates)
            producers.update({name: "stage_combat_manifest.py" for name in combat_candidates})
        output = run / "candidates"
        output.mkdir()
        (output / CONTENT.name).write_bytes(candidate)
        for name, payload in dependents.items():
            (output / name).write_bytes(payload)
        if evidence:
            evidence_root = run / "evidence"
            evidence_root.mkdir()
            for name, payload in evidence.items():
                (evidence_root / name).write_bytes(payload)
        # Prepared scene belongs to temporary data; retain hashes, not another full scene copy.
        (run / "data/MainScene.unity").write_bytes(prepared)
        report = {"schemaVersion": 1, "releaseVerified": False, "productionFilesWritten": False,
                  "nativeGeometryRecaptured": native_proof is not None, "nativeEvidence": native_proof,
                  "sourceSceneSha256": sha256(source),
                  "preparedSceneSha256": sha256(prepared), "preparedStringRows": changes,
                  "previousContentSha256": sha256(content), "candidateSha256": sha256(candidate),
                  "candidateBytes": len(candidate), "sheetCount": audit["sheetCount"],
                  "differenceCount": audit["differenceCount"], "scalarCounts": audit["scalarCounts"],
                  "sourceSchemaHashes": audit["schemaHashes"], "originalNames": names["original"],
                  "starterObservationSha256": sha256(observation) if observation is not None else None,
                  "missionEvidence": mission_report,
                  "bossPathEvidence": boss_proof,
                  "weaponEvidence": weapon_proof,
                  "weaponFamilyEvidence": family_proof,
                  "poseEvidence": pose_proof,
                  "grenadeTargetEvidence": grenade_target_proof,
                  "playerReferenceEvidence": player_reference_proof,
                  "blastReferenceEvidence": blast_proof,
                  "producerSha256": sha256(Path(__file__).read_bytes()),
                  "dependents": {name: {"candidateSha256": sha256(payload), "candidateBytes": len(payload),
                                        "previousSha256": sha256((ROOT / "Server/content" / name).read_bytes()),
                                        "producerSha256": sha256((ROOT / "Server/tools" / producers[name]).read_bytes())}
                                 for name, payload in dependents.items()},
                  "toolHashes": {name: sha256((ROOT / "Server/tools" / name).read_bytes()) for name in
                                 ["audit_battle_sheet_values.py", "audit_bot_name_source.py",
                                  "prepare_bot_name_import.py", "stage_sheet_dependents.py",
                                  "bind_native_battle_evidence.py", "recapture_battle_content.py",
                                  "stage_mission_content.py", "audit_main_scene_provenance.py",
                                  "bind_boss_path_evidence.py", "package_coop_boss_paths.py",
                                  "bind_weapon_evidence.py", "bind_weapon_family_evidence.py",
                                  "compose_minigun_binding.py"]},
                  "pending": ["Full native content recapture", "Dependent numeric behavior review",
                              "Refresh unit observation: WeaponInventory.cs differs from recorded proof",
                              "Coordinated dependent artifact publication"]}
        if native_proof:
            report["pending"].remove("Full native content recapture")
        if observation is not None:
            report["pending"].remove("Refresh unit observation: WeaponInventory.cs differs from recorded proof")
        (run / "results.json").write_bytes(encode(report))
    except BaseException:
        finish_run(DEFAULT_ROOT, run, "failed", False)
        raise
    finish_run(DEFAULT_ROOT, run, "passed", False)
    prune_runs(DEFAULT_ROOT, apply=True)
    print("Staged source sheets; release remains unverified: " + str(run / "results.json"))


if __name__ == "__main__":
    main()
