"""Reject unexplained scene changes even when reported hashes are updated."""
import copy
import json
import tempfile
import unittest
from pathlib import Path
from unittest.mock import patch

import audit_main_scene_provenance as audit


class MainSceneProvenanceTests(unittest.TestCase):
    def setUp(self):
        fields = {"levelExperience": 0, "experience": 0, "levels": []}
        for name, count in audit.COUNTS.items():
            fields[name] = [{"m_FileID": 0, "m_PathID": index + 1} for index in range(count)]
        self.binding = {"fields": fields, "target": {
            "scene": audit.SCENE, "componentFileId": audit.COMPONENT}}
        self.before = (
            b"%YAML 1.1\n--- !u!114 &45847\nMonoBehaviour:\n"
            b"  m_Script: {fileID: 11500000, guid: 780c78d4af376959b095359d8460246f, type: 3}\n"
            b"  m_EditorClassIdentifier:\n--- !u!1 &9\nGameObject:\n  m_Name: unchanged\n")
        self.after = self.before.replace(
            b"  m_EditorClassIdentifier:\n",
            b"  m_EditorClassIdentifier:\n" + audit.restored_payload(self.binding) + b"\n")

    def verify(self, before, after):
        binding = copy.deepcopy(self.binding)
        binding["target"]["beforeSha256"] = audit.digest(before)
        binding["target"]["afterSha256"] = audit.digest(after)
        return audit.verify_transition(before, after, binding)

    def test_exact_restoration_is_explained(self):
        self.assertEqual(2, self.verify(self.before, self.after))

    def test_unrelated_object_change_is_rejected(self):
        changed = self.after.replace(b"m_Name: unchanged", b"m_Name: changed")
        with self.assertRaisesRegex(ValueError, "beyond"):
            self.verify(self.before, changed)

    def test_preamble_change_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "exact restored"):
            self.verify(self.before, self.after.replace(b"%YAML 1.1", b"%YAML 1.2"))

    def test_extra_component_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "membership"):
            self.verify(self.before, self.after + b"--- !u!1 &10\nGameObject:\n")

    def test_duplicate_component_is_rejected(self):
        with self.assertRaisesRegex(ValueError, "Duplicate"):
            self.verify(self.before, self.after + b"--- !u!1 &9\nGameObject:\n")

    def test_changed_restored_pointer_is_rejected(self):
        changed = self.after.replace(b"  - {fileID: 1}", b"  - {fileID: 99}", 1)
        with self.assertRaisesRegex(ValueError, "exact restored"):
            self.verify(self.before, changed)

    def test_duplicate_record_pointer_is_rejected(self):
        self.binding["fields"]["behaviours"][1] = self.binding["fields"]["behaviours"][0]
        with self.assertRaisesRegex(ValueError, "uniqueness"):
            self.verify(self.before, self.after)

    def test_transitive_artifact_dependencies_are_reported(self):
        old_hash = "a" * 64
        with tempfile.TemporaryDirectory(prefix="war-provenance-") as directory:
            root = Path(directory)
            content = root / "Server/content"
            content.mkdir(parents=True)
            source = json.dumps({"scene": old_hash}).encode()
            parent = json.dumps({"source": audit.digest(source)}).encode()
            (content / "source.json").write_bytes(source)
            (content / "parent.json").write_bytes(parent)
            (content / "package.json").write_text(json.dumps({"parent": audit.digest(parent)}))
            (content / "other.json").write_text("{}")
            with patch.object(audit, "ROOT", root):
                result = audit.inventory_artifacts(old_hash, "b" * 64)
        self.assertEqual(3, len(result))
        self.assertEqual(["Server/content/parent.json"], result[0]["affectedDependencies"])
        self.assertTrue(result[2]["oldSceneReference"])


if __name__ == "__main__":
    unittest.main()
