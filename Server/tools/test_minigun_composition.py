"""Test explicit native schema composition; fixtures are not native execution evidence."""
import json
from pathlib import Path
import unittest

import compose_minigun_binding as composition

ROOT = Path(__file__).resolve().parents[2] / "Server/content"


class MinigunCompositionTests(unittest.TestCase):
    def setUp(self):
        self.expected = json.loads((ROOT / "recovered-minigun-binding.json").read_bytes())
        self.family = json.loads(json.dumps(self.expected))
        self.identities = json.loads((ROOT / "recovered-all-weapon-bindings.json").read_bytes())
        for field in ("setupType", "ammoSetupType", "weaponComponents"):
            del self.family["weapon"][field]
        self.family["weapon"].update(muzzlePosition=[0, 0, 0], muzzleRotation=[0, 0, 0, 1],
                                      motorPath=self.family["playerPath"] + "/motor")

    def build(self):
        return composition.build_document(json.dumps(self.family).encode(), json.dumps(self.identities).encode())

    def test_explicit_native_composition_reproduces_package_schema(self):
        self.assertEqual(composition.exact(self.build()), composition.exact(self.expected))

    def test_different_source_cannot_fill_identity_fields(self):
        self.identities["sha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "source identities differ"):
            self.build()

    def test_overlapping_runtime_value_must_match(self):
        self.family["weapon"]["inventoryIndex"] += 1
        with self.assertRaisesRegex(ValueError, "overlap differs"):
            self.build()

    def test_duplicate_identity_is_rejected(self):
        row = next(row for row in self.identities["weapons"] if row["id"] == "Google2u.LMG_Minigun")
        self.identities["weapons"].append(row)
        with self.assertRaisesRegex(ValueError, "exactly one"):
            self.build()

    def test_boolean_pose_is_rejected_even_when_not_in_runtime_package(self):
        self.family["weapon"]["muzzlePosition"][0] = False
        with self.assertRaisesRegex(ValueError, "native Minigun pose"):
            self.build()


if __name__ == "__main__":
    unittest.main()
