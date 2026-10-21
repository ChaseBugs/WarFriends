"""Reject unreviewed weapon identity changes and stale native scene provenance."""
import json
import unittest

import recapture_weapon_bindings as weapons


class WeaponRecaptureTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"scene fixture"
        path = weapons.capture.ROOT / "Server/content/recovered-all-weapon-bindings.json"
        self.document = json.loads(path.read_bytes())
        self.document["sha256"] = weapons.capture.digest(self.scene)

    def payload(self):
        return json.dumps(self.document).encode("utf-8")

    def test_exact_identity_snapshot_accepts_only_new_scene_binding(self):
        payload = self.payload()
        self.assertEqual(weapons.validate(payload, self.scene), weapons.capture.digest(payload))

    def test_stale_scene_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "exact scene"):
            weapons.validate(self.payload(), b"another scene")

    def test_changed_inventory_index_is_rejected(self):
        self.document["weapons"][0]["inventoryIndex"] += 1
        with self.assertRaisesRegex(ValueError, "bindings changed"):
            weapons.validate(self.payload(), self.scene)

    def test_boolean_cannot_replace_zero_enum(self):
        self.document["weapons"][0]["shotType"] = False
        with self.assertRaisesRegex(ValueError, "bindings changed"):
            weapons.validate(self.payload(), self.scene)

    def test_missing_weapon_is_rejected(self):
        self.document["weapons"].pop()
        with self.assertRaisesRegex(ValueError, "bindings changed"):
            weapons.validate(self.payload(), self.scene)


if __name__ == "__main__":
    unittest.main()
