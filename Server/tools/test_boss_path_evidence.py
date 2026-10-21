"""Synthetic completed-run fixtures exercise evidence binding, not native Unity behavior."""
import json
import os
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

import bind_boss_path_evidence as binding
from test_boss_path_candidates import fixture, encode
from test_artifacts import finish_run, start_run


class BossPathEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.temporary = tempfile.TemporaryDirectory()
        self.addCleanup(self.temporary.cleanup)
        self.root = Path(self.temporary.name)
        anchors, navigation, native = fixture()
        self.anchors = encode(anchors)
        self.navigation = self.root / "navigation.json"
        self.navigation.write_bytes(encode(navigation))
        candidate = binding.package.build_document(self.anchors, encode(navigation), encode(native))
        report = {"nativeSha256": binding.digest(encode(native)), "routeCount": 120,
                  "candidateSha256": binding.digest(binding.encode(candidate)), "sources": {}}
        self.run = start_run(self.root, "boss-path-capture", os.getpid())
        for name, data in (("anchors.json", self.anchors), ("navigation.json", encode(navigation)),
                           ("native-paths.json", encode(native)), ("results.json", encode(report))):
            (self.run / name).write_bytes(data)
        finish_run(self.root, self.run, "passed", False)
        candidate["anchorSourceSha256"] = "previous"
        self.production = self.root / "production.json"
        self.production.write_bytes(encode(candidate))
        for target, value in (("NAVIGATION", self.navigation), ("OUTPUT", self.production)):
            patcher = patch.object(binding.package, target, value)
            patcher.start()
            self.addCleanup(patcher.stop)
        patcher = patch.object(binding, "verify_sources")
        self.verify_sources = patcher.start()
        self.addCleanup(patcher.stop)

    def test_completed_capture_repackages_and_calls_source_validation(self):
        payload, proof, evidence = binding.bind_run(self.run, self.anchors)
        self.assertEqual(proof["routeCount"], 120)
        self.assertEqual(proof["candidateSha256"], binding.digest(payload))
        self.assertEqual(len(evidence), 4)
        self.verify_sources.assert_called_once()

    def test_altered_raw_output_is_rejected(self):
        with (self.run / "native-paths.json").open("ab") as stream:
            stream.write(b"\n")
        with self.assertRaisesRegex(ValueError, "output identity"):
            binding.bind_run(self.run, self.anchors)

    def test_different_candidate_anchors_are_rejected(self):
        with self.assertRaisesRegex(ValueError, "candidate anchors"):
            binding.bind_run(self.run, self.anchors + b"\n")

    def test_active_capture_is_rejected(self):
        active = start_run(self.root, "boss-path-capture", os.getpid())
        try:
            with self.assertRaisesRegex(ValueError, "completed"):
                binding.bind_run(active, self.anchors)
        finally:
            finish_run(self.root, active, "failed", False)

    def test_retained_evidence_can_be_rebound_and_detects_tampering(self):
        payload, proof, evidence = binding.bind_run(self.run, self.anchors)
        stage = start_run(self.root, "sheet-candidates", os.getpid())
        (stage / "evidence").mkdir()
        for name, data in evidence.items():
            (stage / "evidence" / name).write_bytes(data)
        (stage / "results.json").write_bytes(encode({"bossPathEvidence": proof}))
        finish_run(self.root, stage, "passed", False)
        self.assertEqual(binding.bind_run(stage, self.anchors)[0], payload)
        (stage / "evidence/boss-native-results.json").write_bytes(b"{}")
        with self.assertRaisesRegex(ValueError, "changed after staging"):
            binding.bind_run(stage, self.anchors)


class BossSourceInventoryTests(unittest.TestCase):
    def test_omitted_source_inventory_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "inventory is incomplete"):
            binding.verify_sources({"sources": {}}, {"maps": []})


if __name__ == "__main__":
    unittest.main()
