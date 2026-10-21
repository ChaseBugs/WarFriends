"""Synthetic integrity checks; the independent native-value validator is not replaced in production."""
import json
import unittest
from unittest.mock import patch

import bind_blast_reference_evidence as binding


class BlastReferenceEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"scene"
        self.bindings = b"bindings"
        exporters = binding.references.prepared_exporters()
        self.evidence = {"blast-reference-inventory.json": b"{}",
                         "blast-reference-bindings.json": self.bindings}
        self.evidence.update({"blast-reference-" + name: payload for name, payload in exporters.items()})
        outputs = {}
        for name in binding.references.OUTPUTS.values():
            self.evidence["blast-reference-" + name] = b"{}"
            outputs[name] = {"sha256": binding.digest(b"{}"), "valuesEqual": True}
        self.report = {"nativeExportVerified": True, "sourceSceneSha256": binding.digest(self.scene),
                       "bindingsSha256": binding.digest(self.bindings), "unchangedSourceFiles": 1,
                       "outputs": outputs,
                       "exporterHashes": {name: binding.digest(payload) for name, payload in exporters.items()}}
        for target, name, arguments in (
                (binding.references.capture, "verify_source_inventory", {"return_value": 1}),
                (binding.references, "validate", {"side_effect": lambda payload, *_:
                    {"sha256": binding.digest(payload), "valuesEqual": True}})):
            patcher = patch.object(target, name, **arguments)
            patcher.start()
            self.addCleanup(patcher.stop)

    def validate(self):
        self.evidence["blast-reference-results.json"] = json.dumps(self.report).encode()
        return binding.validate_evidence(self.evidence, self.scene, self.bindings)

    def test_complete_evidence_returns_exact_native_bytes(self):
        candidates = self.validate()
        self.assertEqual(2, len(candidates))
        self.assertTrue(all(payload == b"{}" for payload in candidates.values()))

    def test_different_candidate_bindings_are_rejected(self):
        self.bindings = b"other graph"
        with self.assertRaisesRegex(ValueError, "weapon dependency differs"):
            self.validate()

    def test_changed_wrapper_is_rejected(self):
        self.evidence["blast-reference-BlastReferenceBatch.cs"] += b"changed"
        with self.assertRaisesRegex(ValueError, "exporter changed"):
            self.validate()

    def test_changed_output_bytes_are_rejected(self):
        self.evidence["blast-reference-recovered-grenade-rig.json"] += b"\n"
        with self.assertRaisesRegex(ValueError, "output changed"):
            self.validate()

    def test_missing_output_is_rejected(self):
        self.report["outputs"].pop("recovered-grenade-rig.json")
        with self.assertRaisesRegex(ValueError, "incomplete or stale"):
            self.validate()

    def test_failed_capture_is_rejected(self):
        self.report["nativeExportVerified"] = False
        with self.assertRaisesRegex(ValueError, "incomplete or stale"):
            self.validate()


if __name__ == "__main__":
    unittest.main()
