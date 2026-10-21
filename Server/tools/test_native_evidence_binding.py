"""Reject stale, incomplete or unsafe native evidence before staging release candidates."""
import json
import os
import tempfile
import unittest
from pathlib import Path

from bind_native_battle_evidence import bind_native_run, digest
from test_artifacts import finish_run, start_run


class NativeEvidenceBoundaryTests(unittest.TestCase):
    def setUp(self):
        self.temporary = tempfile.TemporaryDirectory(prefix="war-native-binding-")
        self.addCleanup(self.temporary.cleanup)
        self.root = Path(self.temporary.name)
        self.run = start_run(self.root, "battle-recapture", os.getpid())
        self.scene = b"original fixture"
        self.prepared = b"prepared fixture"
        self.report = {"nativeExportVerified": True, "sourceSceneSha256": digest(self.scene),
                       "preparedSceneSha256": digest(self.prepared)}

    def write_report(self):
        (self.run / "results.json").write_text(json.dumps(self.report), encoding="utf-8")

    def bind(self):
        return bind_native_run(self.run, self.scene, self.prepared, b"{}")

    def test_running_result_cannot_authorize_staging(self):
        with self.assertRaisesRegex(ValueError, "completed unlinked"):
            self.bind()

    def test_stale_original_scene_is_rejected(self):
        finish_run(self.root, self.run, "passed", False)
        self.report["sourceSceneSha256"] = "0" * 64
        self.write_report()
        with self.assertRaisesRegex(ValueError, "original/prepared"):
            self.bind()

    def test_inventory_path_cannot_escape_client_source(self):
        finish_run(self.root, self.run, "passed", False)
        self.write_report()
        (self.run / "source-inventory.json").write_text('{"../outside": {}}', encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "inventory path"):
            self.bind()

    def test_omitted_sources_cannot_pass_as_full_snapshot(self):
        finish_run(self.root, self.run, "passed", False)
        self.write_report()
        names = ["Assets/Scenes/MainScene.unity", "Assets/Editor/SelfHostedBattleExport.cs",
                 "Packages/manifest.json", "ProjectSettings/ProjectVersion.txt"]
        (self.run / "source-inventory.json").write_text(json.dumps(dict.fromkeys(names, {})), encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "inventory is incomplete"):
            self.bind()

    def test_retained_evidence_report_cannot_change_after_staging(self):
        self.run = start_run(self.root, "sheet-candidates", os.getpid())
        finish_run(self.root, self.run, "passed", False)
        evidence = self.run / "evidence"
        evidence.mkdir()
        (evidence / "native-results.json").write_text(json.dumps(self.report), encoding="utf-8")
        (evidence / "source-inventory.json").write_text("{}", encoding="utf-8")
        proof = {"nativeGeometryRecaptured": True, "nativeReportSha256": "0" * 64,
                 "sourceInventorySha256": digest(b"{}")}
        (self.run / "results.json").write_text(json.dumps({"nativeEvidence": proof}), encoding="utf-8")
        with self.assertRaisesRegex(ValueError, "changed after staging"):
            self.bind()


if __name__ == "__main__":
    unittest.main()
