"""Test explicit observation plumbing; synthetic fixtures are not replacement runtime evidence."""
import copy
import hashlib
import json
import unittest

from build_battle_unit_rules import CONTENT, TARGET, build_document
from build_player_weapon_index_map import OBSERVATION, REPOSITORY


class UnitObservationInputTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.original = OBSERVATION.read_bytes()
        cls.fixture = json.loads(cls.original)
        # Only a local synthetic input for testing source validation and byte-input binding.
        for name in cls.fixture["source"]["ruleSha256"]:
            path = REPOSITORY / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp" / name
            cls.fixture["source"]["ruleSha256"][name] = hashlib.sha256(path.read_bytes()).hexdigest()
        cls.content = CONTENT.read_bytes()

    def test_explicit_observation_bytes_own_the_derived_hash(self):
        payload = json.dumps(self.fixture, indent=3).encode("utf-8")
        result = build_document(self.content, payload)
        self.assertEqual(result["observationSha256"], hashlib.sha256(payload).hexdigest())
        self.assertEqual(result["units"], json.loads(TARGET.read_bytes())["units"])
        self.assertEqual(OBSERVATION.read_bytes(), self.original)

    def test_stale_rule_cannot_enter_unit_candidate(self):
        fixture = copy.deepcopy(self.fixture)
        fixture["source"]["ruleSha256"]["WeaponInventory.cs"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "WeaponInventory.cs"):
            build_document(self.content, json.dumps(fixture).encode())

    def test_incomplete_unit_observation_is_rejected(self):
        fixture = copy.deepcopy(self.fixture)
        fixture["units"].pop()
        with self.assertRaisesRegex(ValueError, "complete unique source unit set"):
            build_document(self.content, json.dumps(fixture).encode())


if __name__ == "__main__":
    unittest.main()
