"""Exercise evidence integrity; synthetic fixtures are not native animation proof."""
import json
import unittest
from unittest.mock import patch

import bind_grenade_target_evidence as binding


class GrenadeTargetEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"fixture scene"
        self.document = json.loads((binding.targets.capture.ROOT / "Server/content" / binding.targets.OUTPUT).read_bytes())
        self.document["sha256"] = binding.digest(self.scene)
        payload = json.dumps(self.document).encode()
        exporter = (binding.targets.capture.ROOT / "Server/tools" / binding.targets.EXPORTER).read_bytes()
        self.report = {"nativeExportVerified": True, "sourceSceneSha256": binding.digest(self.scene),
                       "exporterSha256": binding.digest(exporter), "unchangedSourceFiles": 1,
                       "output": {"sha256": binding.digest(payload), "valuesEqual": True}}
        self.evidence = {"grenade-target-results.json": json.dumps(self.report).encode(),
                         "grenade-target-exporter.cs": exporter, "grenade-target-inventory.json": b"{}",
                         "grenade-target-native.json": payload}
        inventory = patch.object(binding.targets.capture, "verify_source_inventory", return_value=1)
        inventory.start()
        self.addCleanup(inventory.stop)

    def test_complete_evidence_preserves_native_bytes(self):
        self.assertEqual(binding.validate_evidence(self.evidence, self.scene),
                         self.evidence["grenade-target-native.json"])

    def test_other_scene_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "stale"):
            binding.validate_evidence(self.evidence, b"other scene")

    def test_changed_exporter_is_rejected(self):
        self.evidence["grenade-target-exporter.cs"] += b"changed"
        with self.assertRaisesRegex(ValueError, "exporter changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_changed_bytes_are_rejected(self):
        self.evidence["grenade-target-native.json"] += b"\n"
        with self.assertRaisesRegex(ValueError, "output changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_recomputed_hash_cannot_authorize_different_positions(self):
        self.document["clips"][0]["frames"][0]["positions"][0][0] = 999
        payload = json.dumps(self.document).encode()
        self.evidence["grenade-target-native.json"] = payload
        self.report["output"]["sha256"] = binding.digest(payload)
        self.evidence["grenade-target-results.json"] = json.dumps(self.report).encode()
        with self.assertRaisesRegex(ValueError, "values changed"):
            binding.validate_evidence(self.evidence, self.scene)


if __name__ == "__main__":
    unittest.main()
