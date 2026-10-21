"""Synthetic integrity fixtures; native sampled-value comparison has separate coverage."""
import json
import unittest
from unittest.mock import patch

import bind_pose_evidence as binding


def encode(value):
    return json.dumps(value).encode()


class PoseEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"fixture"
        self.evidence = {"pose-inventory.json": b"{}", "pose-batch.cs": b"wrapper"}
        outputs = {}
        for name in binding.poses.OUTPUTS.values():
            payload = b'{"fixture": true}'
            self.evidence["pose-" + name] = payload
            outputs[name] = {"sha256": binding.digest(payload), "valuesEqual": True}
        edits = {}
        for exporter, _ in binding.poses.EXPORTS:
            relative = "Assets/Editor/SelfHosted" + exporter + "Export.cs"
            source = (binding.poses.capture.ROOT / "Clients/ExportedProject" / relative).read_bytes()
            modified = source.replace(b"EditorApplication.Exit(0);", b"/* Batch runner owns successful exit. */")
            edits[relative] = {"originalSha256": binding.digest(source), "batchSha256": binding.digest(modified)}
        self.report = {"nativeExportVerified": True, "sourceSceneSha256": binding.digest(self.scene),
                       "differences": [], "outputs": outputs, "unchangedSourceFiles": 1,
                       "wrapperSha256": binding.digest(b"wrapper"), "batchEdits": edits}
        self.evidence["pose-results.json"] = encode(self.report)
        for target, name, arguments in (
                (binding.poses.capture, "verify_source_inventory", {"return_value": 1}),
                (binding.poses, "validate", {"side_effect": lambda payload, *_:
                    {"sha256": binding.digest(payload), "valuesEqual": True}})):
            patcher = patch.object(target, name, **arguments)
            patcher.start()
            self.addCleanup(patcher.stop)

    def test_complete_evidence_returns_two_candidates(self):
        candidates = binding.validate_evidence(self.evidence, self.scene)
        self.assertEqual(len(candidates), 2)
        for name, payload in candidates.items():
            self.assertEqual(payload, self.evidence["pose-" + name])

    def test_changed_output_hash_is_rejected(self):
        self.evidence["pose-recovered-grenade-poses.json"] += b"\n"
        with self.assertRaisesRegex(ValueError, "output changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_changed_wrapper_is_rejected(self):
        self.evidence["pose-batch.cs"] += b"changed"
        with self.assertRaisesRegex(ValueError, "wrapper changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_incomplete_output_inventory_is_rejected(self):
        self.report["outputs"].pop("recovered-player-poses.json")
        self.evidence["pose-results.json"] = encode(self.report)
        with self.assertRaisesRegex(ValueError, "incomplete or stale"):
            binding.validate_evidence(self.evidence, self.scene)


if __name__ == "__main__":
    unittest.main()
