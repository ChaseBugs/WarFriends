"""Exercise candidate extraction and reject semantic changes or mismatched dependency authority."""
import json
import subprocess
import sys
import unittest
import tempfile
from pathlib import Path
from unittest.mock import patch

import stage_mission_content as stage


class MissionContentCandidateTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.scene = stage.missions.SCENE.read_bytes()
        cls.candidates = stage.build_candidates(cls.scene)

    def test_all_candidates_preserve_gameplay_values(self):
        for name, candidate in self.candidates.items():
            with self.subTest(name=name):
                original = (stage.ROOT / "Server/content" / name).read_bytes()
                report = stage.compare_candidate(name, original, candidate)
                self.assertTrue(report["gameplayValuesEqual"])
                self.assertNotEqual(report["previousSha256"], report["candidateSha256"])

    def test_health_binds_the_staged_bot_bytes(self):
        document = json.loads(self.candidates["recovered-coop-bot-health.json"])
        expected = stage.provenance.digest(self.candidates["recovered-coop-bot-rules.json"])
        self.assertEqual(expected, document["botRulesSha256"])
        self.assertEqual(44, len(document["playerHealthByLevel"]))
        self.assertEqual(15, len(document["bossHealth"]))

    def test_native_navigation_references_bind_the_candidate_source(self):
        navigation = self.candidates["recovered-coop-navmesh-sources.json"]
        for name in ("recovered-coop-navmesh-paths.json", "recovered-coop-navmesh-triangulation.json"):
            document = json.loads(self.candidates[name])
            previous = json.loads((stage.ROOT / "Server/content" / name).read_bytes())
            self.assertEqual(document["navigationSourceSha256"], stage.provenance.digest(navigation))
            self.assertEqual(document["maps"], previous["maps"])

    def test_changed_navigation_geometry_requires_native_recapture(self):
        document = json.loads(self.candidates["recovered-coop-navmesh-sources.json"])
        document["maps"][0]["sha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "native recapture required"):
            stage.navigation_references.build_candidates(stage.encode(document))

    def test_changed_navigation_map_order_requires_native_recapture(self):
        document = json.loads(self.candidates["recovered-coop-navmesh-sources.json"])
        document["maps"].reverse()
        with self.assertRaisesRegex(ValueError, "native recapture required"):
            stage.navigation_references.build_candidates(stage.encode(document))

    def test_changed_navigation_mesh_bytes_are_rejected(self):
        real_read = Path.read_bytes

        def altered_read(path):
            payload = real_read(path)
            return payload + b" " if path.parent.name == "coop-navmesh-triangulation" else payload

        with patch.object(Path, "read_bytes", altered_read):
            with self.assertRaisesRegex(ValueError, "no longer matches"):
                stage.navigation_references.build_candidates(
                    self.candidates["recovered-coop-navmesh-sources.json"])

    def test_prefab_geometry_changes_cannot_hide_in_provenance(self):
        name = "recovered-coop-prefab-colliders.json"
        document = json.loads(self.candidates[name])
        self.assertEqual(len(document["prefabs"]), 32)
        self.assertEqual(sum(len(row["colliders"]) for row in document["prefabs"]), 128)
        collider = document["prefabs"][0]["colliders"][0]
        collider["enabled"] = not collider["enabled"]
        original = (stage.ROOT / "Server/content" / name).read_bytes()
        with self.assertRaisesRegex(ValueError, "reviewed provenance"):
            stage.compare_candidate(name, original, stage.encode(document))

    def test_prefab_meshes_bind_colliders_and_reject_changed_shapes(self):
        collider_bytes = self.candidates["recovered-coop-prefab-colliders.json"]
        geometry = json.loads(self.candidates["recovered-coop-prefab-mesh-geometry.json"])
        self.assertEqual(geometry["colliderSourceSha256"], stage.provenance.digest(collider_bytes))
        self.assertEqual(stage.prefab_meshes.validate(collider_bytes, geometry), (6, 176, 284))
        document = json.loads(collider_bytes)
        document["prefabs"][0]["colliders"][0]["shape"]["unreviewed"] = 1
        with self.assertRaisesRegex(ValueError, "native recapture required"):
            stage.prefab_meshes.build_document(stage.encode(document))

    def test_prefab_meshes_reject_boolean_vertices_and_invalid_triangles(self):
        name = "recovered-coop-prefab-mesh-geometry.json"
        collider_bytes = self.candidates["recovered-coop-prefab-colliders.json"]
        geometry = json.loads(self.candidates[name])
        geometry["meshes"][0]["vertices"][0][0] = True
        with self.assertRaisesRegex(ValueError, "vertex is invalid"):
            stage.prefab_meshes.validate(collider_bytes, geometry)
        geometry = json.loads(self.candidates[name])
        geometry["meshes"][0]["triangles"][0] = len(geometry["meshes"][0]["vertices"])
        with self.assertRaisesRegex(ValueError, "triangle is invalid"):
            stage.prefab_meshes.validate(collider_bytes, geometry)

    def test_combined_stage_rejects_another_scene_before_building_candidates(self):
        audit = json.loads(stage.provenance.REPORT.read_bytes())
        with patch.object(stage.provenance, "create_report", return_value=audit):
            with patch.object(stage, "build_candidates") as build:
                with self.assertRaisesRegex(ValueError, "same scene bytes"):
                    stage.prepare_stage(self.scene + b"\n")
                build.assert_not_called()

    def test_combined_stage_retains_full_provenance_and_exact_payloads(self):
        candidates, report = stage.prepare_stage(self.scene)
        self.assertEqual(candidates, self.candidates)
        self.assertEqual(report["sceneSha256"], stage.provenance.digest(self.scene))
        expected_digest = stage.provenance.digest(stage.provenance.REPORT.read_bytes())
        self.assertEqual(report["provenanceReportSha256"], expected_digest)
        self.assertEqual(len(report["artifacts"]), 14)
        self.assertFalse(report["releaseVerified"])
        self.assertFalse(report["productionFilesWritten"])

    def test_historical_scene_reproduces_existing_documents(self):
        revision = stage.provenance.RESTORATION + "^:" + stage.provenance.SCENE
        scene = subprocess.check_output(["git", "show", revision], cwd=stage.ROOT)
        candidates = stage.build_candidates(scene)
        for name, candidate in candidates.items():
            with self.subTest(name=name):
                previous = json.loads((stage.ROOT / "Server/content" / name).read_bytes())
                self.assertEqual(stage.encode(previous), candidate)

    def test_player_targets_keep_roles_and_ordered_source_types(self):
        name = "recovered-player-shot-targets.json"
        document = json.loads(self.candidates[name])
        self.assertEqual([row["role"] for row in document["players"]], ["gameplay", "rendering"])
        for player in document["players"]:
            self.assertEqual([target["type"] for target in player["targets"]], [1, 1, 2, 16, 8])
        document["players"][0]["targets"][0]["referencePosition"][0] += 1
        previous = (stage.ROOT / "Server/content" / name).read_bytes()
        with self.assertRaisesRegex(ValueError, "reviewed provenance"):
            stage.compare_candidate(name, previous, stage.encode(document))

    def test_mismatched_mission_snapshot_is_rejected(self):
        document = json.loads(self.candidates["recovered-mission-catalog.json"])
        document["sourceSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "mission source changed"):
            stage.bots.build_document(self.scene, document)

    def test_mismatched_bot_snapshot_is_rejected(self):
        document = json.loads(self.candidates["recovered-coop-bot-rules.json"])
        document["missionSourceSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "differ from the balance-table"):
            stage.health.build_document(self.scene, stage.encode(document))

    def test_boss_dependencies_bind_exact_candidate_bytes(self):
        attacks = json.loads(self.candidates["recovered-coop-boss-attack-timing.json"])
        loadouts = json.loads(self.candidates["recovered-coop-boss-loadouts.json"])
        self.assertEqual(attacks["botRulesSha256"],
                         stage.provenance.digest(self.candidates["recovered-coop-bot-rules.json"]))
        self.assertEqual(loadouts["attackSourceSha256"],
                         stage.provenance.digest(self.candidates["recovered-coop-boss-attack-timing.json"]))
        self.assertEqual(len(loadouts["weapons"]), 66)
        self.assertEqual(len(loadouts["missions"]), 15)
        self.assertTrue(all(len(row["slots"]) == 4 for row in loadouts["missions"]))

    def test_boss_loadout_rejects_same_scene_but_different_bot_bytes(self):
        bots = self.candidates["recovered-coop-bot-rules.json"] + b"\n"
        attacks = self.candidates["recovered-coop-boss-attack-timing.json"]
        with self.assertRaisesRegex(ValueError, "exact bot rules"):
            stage.loadouts.build_document(self.scene, bots, attacks)

    def test_timing_rejects_decimal_overflow_instead_of_emitting_infinity(self):
        with self.assertRaisesRegex(ValueError, "non-finite"):
            stage.attacks.finite_decimal({"REACTION": "9" * 400}, "REACTION")

    def test_boss_anchors_preserve_all_forty_positions(self):
        document = json.loads(self.candidates["recovered-coop-boss-anchors.json"])
        previous = json.loads(stage.anchors.OUTPUT.read_bytes())
        self.assertEqual(document["maps"], previous["maps"])
        self.assertEqual(len(document["maps"]), 5)
        self.assertTrue(all(len(row["playerPositions"]) == 8 for row in document["maps"]))
        self.assertEqual(document["missionSourceSha256"], stage.provenance.digest(self.scene))

    def test_boss_anchors_reject_duplicate_maps_and_stale_map_bytes(self):
        mission = json.loads(self.candidates["recovered-mission-catalog.json"])
        mission["bossMaps"][1] = mission["bossMaps"][0]
        with self.assertRaisesRegex(ValueError, "five distinct"):
            stage.anchors.build_document(stage.encode(mission))
        mission = json.loads(self.candidates["recovered-mission-catalog.json"])
        mission["bossMaps"][0]["sceneSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "scene changed"):
            stage.anchors.build_document(stage.encode(mission))

    def test_all_mission_shield_values_and_defaults_are_preserved(self):
        candidate = json.loads(self.candidates["recovered-coop-shield-states.json"])
        previous = json.loads(stage.shields.OUTPUT.read_bytes())
        self.assertEqual(candidate["missions"], previous["missions"])
        self.assertEqual(len(candidate["missions"]), 75)
        self.assertEqual(stage.shields.shield_states({}, "playerShieldStates"), [])
        self.assertEqual(stage.shields.shield_states({"playerShieldStates": [{}]}, "playerShieldStates"),
                         [{"healthRatio": 1, "maxHealthRatio": 1, "regenerate": True, "autoRepair": True}])

    def test_navigation_preserves_five_native_assets_and_rejects_changed_package(self):
        candidate = json.loads(self.candidates["recovered-coop-navmesh-sources.json"])
        previous = json.loads(stage.navigation.OUTPUT.read_bytes())
        self.assertEqual(candidate["maps"], previous["maps"])
        self.assertEqual(len(candidate["maps"]), 5)
        stage.navigation.verify_packaged_assets(candidate)
        with tempfile.TemporaryDirectory() as temporary:
            package = Path(temporary)
            (package / candidate["maps"][0]["packagedAsset"]).write_bytes(b"invalid fixture")
            with patch.object(stage.navigation, "PACKAGE", package):
                with self.assertRaisesRegex(ValueError, "packaged co-op NavMesh differs"):
                    stage.navigation.verify_packaged_assets(candidate)

    def test_navigation_rejects_changed_scene_and_reordered_stages(self):
        mission = json.loads(self.candidates["recovered-mission-catalog.json"])
        mission["maps"][0]["sceneSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "co-op scene changed"):
            stage.navigation.build_document(stage.encode(mission))
        mission["maps"].reverse()
        with self.assertRaisesRegex(ValueError, "stages are not ordered"):
            stage.navigation.build_document(stage.encode(mission))

    def test_detail_candidate_preserves_every_map_and_binds_staged_source(self):
        detail = json.loads(self.candidates["recovered-coop-navmesh-detail.json"])
        previous = json.loads(stage.navigation_detail.MANIFEST.read_bytes())
        self.assertEqual(detail["maps"], previous["maps"])
        self.assertEqual(sum(row["tiles"] for row in detail["maps"]), 655)
        self.assertEqual(detail["sourceManifestSha256"],
                         stage.provenance.digest(self.candidates["recovered-coop-navmesh-sources.json"]))

    def test_detail_checks_last_tile_and_complete_inventory_for_binary_and_yaml(self):
        for name in ("NavMesh_7", "NavMesh"):
            with self.subTest(asset=name):
                root = stage.navigation_detail.CONTENT
                asset = (root / "coop-navmesh" / (name + ".asset")).read_bytes()
                data = (root / "coop-navmesh-detail" / (name + ".json")).read_bytes()
                document = json.loads(data)
                document["tiles"][-1]["sha256"] = "0" * 64
                with self.assertRaisesRegex(ValueError, "complete source decoding"):
                    stage.navigation_detail.validate_tiles(asset, document)
                document = json.loads(data)
                document["tiles"].pop()
                with self.assertRaisesRegex(ValueError, "complete source"):
                    stage.navigation_detail.validate_tiles(asset, document)
    def test_shields_reject_changed_data_hash_and_incomplete_catalog(self):
        mission = json.loads(self.candidates["recovered-mission-catalog.json"])
        mission["missions"][0]["sceneDataSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "DATA differs"):
            stage.shields.build_document(self.scene, stage.encode(mission))
        mission["missions"].pop()
        with self.assertRaisesRegex(ValueError, "complete 75-mission"):
            stage.shields.build_document(self.scene, stage.encode(mission))

    def test_shields_reject_nonfinite_ratios_and_numeric_booleans(self):
        for field, value in (("healthRatio", float("nan")), ("maxHealthRatio", float("inf")),
                             ("healthRatio", True), ("regenerate", 1), ("autoRepair", 0)):
            with self.subTest(field=field, value=value):
                with self.assertRaisesRegex(ValueError, "Invalid mission shield state value"):
                    stage.shields.shield_states({"playerShieldStates": [{field: value}]}, "playerShieldStates")

    def test_changed_reward_is_not_hidden_as_provenance(self):
        name = "recovered-mission-catalog.json"
        document = json.loads(self.candidates[name])
        document["missions"][0]["rewardGold"] += 1
        original = (stage.ROOT / "Server/content" / name).read_bytes()
        with self.assertRaisesRegex(ValueError, "reviewed provenance"):
            stage.compare_candidate(name, original, stage.encode(document))

    def test_changed_schema_is_rejected(self):
        name = "recovered-coop-bot-rules.json"
        document = json.loads(self.candidates[name])
        document["extra"] = True
        original = (stage.ROOT / "Server/content" / name).read_bytes()
        with self.assertRaisesRegex(ValueError, "schema differs"):
            stage.compare_candidate(name, original, stage.encode(document))

    def test_boolean_cannot_compare_equal_to_a_numeric_reward(self):
        name = "recovered-mission-catalog.json"
        document = json.loads(self.candidates[name])
        document["missions"][0]["rewardGold"] = False
        original = json.loads((stage.ROOT / "Server/content" / name).read_bytes())
        original["missions"][0]["rewardGold"] = 0
        with self.assertRaisesRegex(ValueError, "reviewed provenance"):
            stage.compare_candidate(name, stage.encode(original), stage.encode(document))

    def test_unchanged_old_output_is_not_a_fresh_candidate(self):
        name = "recovered-coop-bot-rules.json"
        original = (stage.ROOT / "Server/content" / name).read_bytes()
        with self.assertRaisesRegex(ValueError, "reviewed provenance"):
            stage.compare_candidate(name, original, original)

    def test_unknown_arguments_refuse_before_extraction(self):
        scripts = {"stage_mission_content.py": 2}
        scripts.update({name: 1 for name in stage.PRODUCERS.values()})
        scripts["extract_coop_shield_states.py"] = 2
        scripts["stage_navmesh_detail.py"] = 2
        scripts["stage_coop_navigation_references.py"] = 2
        scripts["verify_coop_prefab_mesh_geometry.py"] = 2
        for name, exit_code in scripts.items():
            with self.subTest(script=name):
                command = [sys.executable, str(stage.ROOT / "Server/tools" / name), "--unknown"]
                result = subprocess.run(command, capture_output=True)
                self.assertEqual(exit_code, result.returncode)
                self.assertEqual(b"", result.stdout)


if __name__ == "__main__":
    unittest.main()
