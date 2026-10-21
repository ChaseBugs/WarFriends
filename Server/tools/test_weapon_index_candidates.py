"""Check candidate identity binding without substituting synthetic observations for Client proof."""
import json
import unittest

import build_player_weapon_index_map as indexes


class WeaponIndexCandidateTests(unittest.TestCase):
    def setUp(self):
        self.observation = indexes.OBSERVATION.read_bytes()
        self.bindings = json.loads(indexes.BINDINGS.read_bytes())
        self.bindings["sha256"] = indexes.EXPECTED_SCENE_HASH

    def test_candidate_binds_exact_bytes_and_preserves_all_mappings(self):
        payload = json.dumps(self.bindings).encode()
        candidate = indexes.build_document(self.observation, payload)
        previous = indexes.build_document(self.observation)
        self.assertEqual(candidate["mappings"], previous["mappings"])
        self.assertEqual(len(candidate["mappings"]), 66)
        self.assertEqual(candidate["combatBindingsSha256"], indexes.hashlib.sha256(payload).hexdigest())
        self.assertNotEqual(candidate["combatBindingsSha256"], previous["combatBindingsSha256"])

    def test_changed_index_is_rejected(self):
        self.bindings["weapons"][0]["inventoryIndex"] = 999
        self.assert_rejected("values changed")

    def test_missing_weapon_is_rejected(self):
        self.bindings["weapons"].pop()
        self.assert_rejected("values changed")

    def test_wrong_scene_is_rejected(self):
        self.bindings["sha256"] = "0" * 64
        self.assert_rejected("different observed scene")

    def test_changed_weapon_metadata_is_rejected(self):
        self.bindings["weapons"][0]["unreviewed"] = True
        self.assert_rejected("values changed")

    def assert_rejected(self, message):
        with self.assertRaisesRegex(ValueError, message):
            indexes.build_document(self.observation, json.dumps(self.bindings).encode())


if __name__ == "__main__":
    unittest.main()
