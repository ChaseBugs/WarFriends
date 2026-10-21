"""Exercise retained evidence guards using synthetic completed runs, not native Unity."""
import json
import os
from pathlib import Path
import tempfile
import unittest
from unittest.mock import patch

import bind_weapon_evidence as binding
from test_artifacts import start_run, finish_run


def encode(value):
    return (json.dumps(value, indent=2) + "\n").encode()


class WeaponEvidenceTests(unittest.TestCase):
    def setUp(self):
        temporary = tempfile.TemporaryDirectory()
        self.addCleanup(temporary.cleanup)
        self.root = Path(temporary.name)
        self.scene = b"scene fixture"
        source = binding.weapons.capture.ROOT / "Server/content/recovered-all-weapon-bindings.json"
        document = json.loads(source.read_bytes())
        document["sha256"] = binding.digest(self.scene)
        native = encode(document)
        self.run = start_run(self.root, "weapon-recapture", os.getpid())
        report = {"nativeExportVerified": True, "weaponCount": 66, "unchangedSourceFiles": 1,
                  "sourceSceneSha256": binding.digest(self.scene), "nativeOutputSha256": binding.digest(native)}
        for name, payload in (("native-all-weapon-bindings.json", native),
                              ("source-inventory.json", b"{}"), ("results.json", encode(report))):
            (self.run / name).write_bytes(payload)
        finish_run(self.root, self.run, "passed", False)
        patcher = patch.object(binding.weapons.capture, "verify_source_inventory", return_value=1)
        self.verify_inventory = patcher.start()
        self.addCleanup(patcher.stop)

    def test_capture_and_retained_stage_reproduce_exact_candidate(self):
        candidate, proof, evidence = binding.bind_run(self.run, self.scene)
        self.verify_inventory.assert_called_once_with({})
        stage = start_run(self.root, "sheet-candidates", os.getpid())
        (stage / "evidence").mkdir()
        for name, payload in evidence.items():
            (stage / "evidence" / name).write_bytes(payload)
        (stage / "results.json").write_bytes(encode({"weaponEvidence": proof}))
        finish_run(self.root, stage, "passed", False)
        self.assertEqual(binding.bind_run(stage, self.scene)[0], candidate)
        (stage / "evidence/weapon-results.json").write_bytes(b"{}")
        with self.assertRaisesRegex(ValueError, "Retained weapon evidence changed"):
            binding.bind_run(stage, self.scene)

    def test_altered_native_output_is_rejected(self):
        with (self.run / "native-all-weapon-bindings.json").open("ab") as stream:
            stream.write(b"\n")
        with self.assertRaisesRegex(ValueError, "output identity"):
            binding.bind_run(self.run, self.scene)

    def test_stale_scene_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "output identity"):
            binding.bind_run(self.run, b"different scene")

    def test_active_run_is_rejected(self):
        active = start_run(self.root, "weapon-recapture", os.getpid())
        with self.assertRaisesRegex(ValueError, "completed capture"):
            binding.bind_run(active, self.scene)
        finish_run(self.root, active, "failed", False)

    def test_source_inventory_failure_is_not_ignored(self):
        self.verify_inventory.side_effect = ValueError("source changed")
        with self.assertRaisesRegex(ValueError, "source changed"):
            binding.bind_run(self.run, self.scene)


if __name__ == "__main__":
    unittest.main()
