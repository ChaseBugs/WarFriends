"""Exercise family output integrity independently of Unity execution."""
import copy
import json
import unittest
from unittest.mock import patch

import bind_weapon_family_evidence as binding


class FamilyEvidenceTests(unittest.TestCase):
    def setUp(self):
        self.scene = b"fixture scene"
        root = binding.families.capture.ROOT
        identities = json.loads((root / "Server/content/recovered-all-weapon-bindings.json").read_bytes())
        identities["sha256"] = binding.digest(self.scene)
        self.evidence = {"family-identities.json": binding.encode(identities),
                         "family-inventory.json": b"{}", "family-batch.cs": b"wrapper fixture"}
        results = {}
        for family, _, _, _ in binding.families.FAMILIES:
            name = binding.families.output_name(family)
            document = json.loads((root / "Server/content" / name).read_bytes())
            document["sha256"] = binding.digest(self.scene)
            if family == "minigun":
                native = copy.deepcopy(document)
                for field in ("setupType", "ammoSetupType", "weaponComponents"):
                    del native["weapon"][field]
                native["weapon"].update(muzzlePosition=[0, 0, 0], muzzleRotation=[0, 0, 0, 1],
                                        motorPath=native["playerPath"] + "/motor")
                raw = binding.encode(native)
                payload = binding.encode(binding.families.minigun.build_document(
                    raw, self.evidence["family-identities.json"]))
                self.evidence["family-minigun-composed.json"] = payload
            else:
                raw = payload = binding.encode(document)
            self.evidence["family-" + family + ".json"] = raw
            results[family] = binding.families.validate(payload, self.scene, family)
        edits = {}
        for _, exporter, _, _ in (("all", "AllWeapon", "ALL_WEAPON", 1),) + binding.families.FAMILIES:
            relative = "Assets/Editor/SelfHosted" + exporter + "Export.cs"
            source = (root / "Clients/ExportedProject" / relative).read_bytes()
            modified = source.replace(b"EditorApplication.Exit(0);", b"/* Batch runner owns successful exit. */")
            edits[relative] = {"originalSha256": binding.digest(source), "batchSha256": binding.digest(modified)}
        report = {"nativeExportVerified": True, "sourceSceneSha256": binding.digest(self.scene),
                  "differences": [], "families": results, "unchangedSourceFiles": 1, "batchEdits": edits,
                  "wrapperSha256": binding.digest(self.evidence["family-batch.cs"]),
                  "allWeaponSha256": binding.digest(self.evidence["family-identities.json"])}
        self.evidence["family-results.json"] = binding.encode(report)
        patcher = patch.object(binding.families.capture, "verify_source_inventory", return_value=1)
        self.inventory = patcher.start()
        self.addCleanup(patcher.stop)

    def test_all_nine_candidates_revalidate(self):
        self.assertEqual(len(binding.validate_evidence(self.evidence, self.scene)), 9)
        self.inventory.assert_called_once_with({})

    def test_changed_raw_family_bytes_are_rejected(self):
        self.evidence["family-rifle.json"] += b"\n"
        with self.assertRaisesRegex(ValueError, "output changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_changed_minigun_composition_is_rejected(self):
        self.evidence["family-minigun-composed.json"] += b"\n"
        with self.assertRaisesRegex(ValueError, "composition changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_changed_wrapper_is_rejected(self):
        self.evidence["family-batch.cs"] += b"changed"
        with self.assertRaisesRegex(ValueError, "wrapper changed"):
            binding.validate_evidence(self.evidence, self.scene)

    def test_source_failure_is_propagated(self):
        self.inventory.side_effect = ValueError("source changed")
        with self.assertRaisesRegex(ValueError, "source changed"):
            binding.validate_evidence(self.evidence, self.scene)


if __name__ == "__main__":
    unittest.main()
