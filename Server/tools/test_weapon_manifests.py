"""Manifest hashes must bind exact candidate bytes and a single scene snapshot."""
import json
import unittest

import stage_weapon_manifests as manifests


class WeaponManifestTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"fixture scene"
        self.content = json.dumps({"client": "1.4.0", "mainSceneSha256": manifests.digest(self.scene)}).encode()
        self.bindings = {}
        for family in manifests.FAMILIES:
            suffix = "binding" if family == "minigun" else "bindings"
            name = "recovered-" + family + "-" + suffix + ".json"
            self.bindings[name] = json.dumps({"client": "1.4.0", "source": "Assets/Scenes/MainScene.unity",
                                              "sha256": manifests.digest(self.scene)}).encode()

    def test_seven_manifests_bind_exact_bytes(self):
        candidates = manifests.build_candidates(self.scene, self.content, self.bindings)
        self.assertEqual(len(candidates), 7)
        for family in manifests.FAMILIES:
            document = json.loads(candidates[family + "-content-manifest.json"])
            suffix = "binding" if family == "minigun" else "bindings"
            binding = self.bindings["recovered-" + family + "-" + suffix + ".json"]
            self.assertEqual(document["BindingsRevision"], manifests.digest(binding))
            self.assertEqual(document["StatsRevision"], manifests.digest(self.content))

    def test_missing_candidate_does_not_fall_back_to_production(self):
        self.bindings.pop("recovered-shotgun-bindings.json")
        with self.assertRaisesRegex(ValueError, "requires candidate"):
            manifests.build_candidates(self.scene, self.content, self.bindings)

    def test_grenade_manifest_binds_poses_and_rejects_mixed_scene(self):
        binding = self.bindings["recovered-shotgun-bindings.json"]
        candidates = {"recovered-grenade-bindings.json": binding, "recovered-grenade-poses.json": binding}
        document = json.loads(manifests.build_grenade(self.scene, self.content, candidates))
        self.assertEqual(document["PosesRevision"], manifests.digest(binding))
        pose = json.loads(binding)
        pose["sha256"] = "0" * 64
        candidates["recovered-grenade-poses.json"] = json.dumps(pose).encode()
        with self.assertRaisesRegex(ValueError, "different scene/client"):
            manifests.build_grenade(self.scene, self.content, candidates)

    def test_mixed_scene_stats_are_rejected(self):
        with self.assertRaisesRegex(ValueError, "stats use a different"):
            manifests.build_candidates(b"different", self.content, self.bindings)

    def test_mixed_scene_binding_is_rejected(self):
        document = json.loads(self.bindings["recovered-shotgun-bindings.json"])
        document["sha256"] = "0" * 64
        self.bindings["recovered-shotgun-bindings.json"] = json.dumps(document).encode()
        with self.assertRaisesRegex(ValueError, "binding uses a different"):
            manifests.build_candidates(self.scene, self.content, self.bindings)


if __name__ == "__main__":
    unittest.main()
