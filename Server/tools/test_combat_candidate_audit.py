"""Reject incomplete or modified candidate directories before building diagnostic overlays."""
import json
import os
from pathlib import Path
import tempfile
import unittest

import audit_combat_candidate as audit
from test_artifacts import start_run, finish_run


class CombatCandidateAuditTests(unittest.TestCase):
    def setUp(self):
        temporary = tempfile.TemporaryDirectory()
        self.addCleanup(temporary.cleanup)
        root = Path(temporary.name)
        self.run = start_run(root, "sheet-candidates", os.getpid())
        (self.run / "candidates").mkdir()
        payload = b"{}"
        (self.run / "candidates/recovered-battle-content.json").write_bytes(payload)
        report = {"dependents": {}, "candidateSha256": audit.capture.digest(payload)}
        (self.run / "results.json").write_text(json.dumps(report), encoding="utf-8")
        finish_run(root, self.run, "passed", False)

    def test_completed_exact_inventory_is_accepted(self):
        self.assertEqual(len(audit.validate_stage(self.run)), 1)

    def test_tampered_candidate_is_rejected(self):
        (self.run / "candidates/recovered-battle-content.json").write_bytes(b"changed")
        with self.assertRaisesRegex(ValueError, "changed after staging"):
            audit.validate_stage(self.run)

    def test_extra_candidate_is_rejected(self):
        (self.run / "candidates/extra.json").write_bytes(b"{}")
        with self.assertRaisesRegex(ValueError, "inventory differs"):
            audit.validate_stage(self.run)


if __name__ == "__main__":
    unittest.main()
