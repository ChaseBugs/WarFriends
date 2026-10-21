"""A complete manifest cannot silently retain affected dependencies or mix source snapshots."""
import json
import unittest

import stage_combat_manifest as stage


class CombatManifestTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"scene"
        content = stage.ROOT / "Server/content"
        self.production = {path.name: path.read_bytes() for path in content.glob("*.json")}
        self.candidates = {"recovered-battle-content.json": json.dumps(
            {"mainSceneSha256": stage.digest(self.scene)}).encode()}
        manifest = json.loads(self.production["combat-content-manifest.json"])
        self.candidates["recovered-mortar-weapon-pool.json"] = json.dumps({"deployment": {
            "sceneRevision": stage.digest(self.scene), "revision": manifest["ArmyDeploymentRevision"]}}).encode()
        self.candidates["recovered-coop-assaulter-weapon.json"] = json.dumps({"sceneSha256": stage.digest(self.scene)}).encode()

    def test_exact_candidate_stats_and_pinned_unchanged_dependencies(self):
        package = stage.build_package(self.scene, self.candidates, self.production, set())
        manifest = json.loads(package.pop("combat-content-manifest.json"))
        self.assertEqual(manifest["StatsRevision"], stage.digest(self.candidates["recovered-battle-content.json"]))
        self.assertEqual(manifest["SceneRevision"], stage.digest(self.scene))
        self.assertEqual(manifest["Version"], 14)
        self.assertEqual(manifest["MortarWeaponPoolRevision"],
                         stage.digest(self.candidates["recovered-mortar-weapon-pool.json"]))
        for name, payload in package.items():
            self.assertEqual(payload, self.production[name])

    def test_affected_dependency_requires_explicit_candidate(self):
        with self.assertRaisesRegex(ValueError, "requires a candidate"):
            stage.build_package(self.scene, self.candidates, self.production, {"recovered-player-poses.json"})

    def test_changed_pinned_dependency_is_rejected(self):
        self.production["recovered-player-poses.json"] += b"\n"
        with self.assertRaisesRegex(ValueError, "missing or ambiguous"):
            stage.build_package(self.scene, self.candidates, self.production, set())

    def test_mixed_scene_stats_are_rejected(self):
        with self.assertRaisesRegex(ValueError, "different scene"):
            stage.build_package(b"other", self.candidates, self.production, set())

    def test_mortar_pool_must_bind_candidate_army(self):
        pool = json.loads(self.candidates["recovered-mortar-weapon-pool.json"])
        pool["deployment"]["revision"] = "0" * 64
        self.candidates["recovered-mortar-weapon-pool.json"] = json.dumps(pool).encode()
        with self.assertRaisesRegex(ValueError, "does not bind"):
            stage.build_package(self.scene, self.candidates, self.production, set())

    def test_assaulter_candidate_cannot_be_omitted(self):
        self.candidates.pop("recovered-coop-assaulter-weapon.json")
        with self.assertRaisesRegex(ValueError, "Assaulter candidate"):
            stage.build_package(self.scene, self.candidates, self.production, set())


if __name__ == "__main__":
    unittest.main()
