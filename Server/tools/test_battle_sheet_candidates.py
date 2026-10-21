"""Candidate corrections must stay tied to reviewed evidence and preserve native content."""
import copy
import json
import unittest

from audit_battle_sheet_values import CONTENT, ROOT, SCENE
from stage_battle_sheet_content import build_candidate


class SheetCandidateTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.scene = SCENE.read_bytes()
        cls.content = CONTENT.read_bytes()
        cls.audit = json.loads((ROOT / "Server/docs/battle-sheet-value-audit.json").read_bytes())
        cls.names = json.loads((ROOT / "Server/docs/bot-name-source-audit.json").read_bytes())

    def test_all_reviewed_changes_and_native_geometry_preservation(self):
        candidate = json.loads(build_candidate(self.scene, self.content, self.audit, self.names))
        original = json.loads(self.content)
        self.assertEqual(candidate["maps"], original["maps"])
        self.assertEqual(candidate["meshes"], original["meshes"])
        self.assertEqual(len(candidate["sheets"]), 132)
        by_name = {sheet["type"]: sheet for sheet in candidate["sheets"]}
        for change in self.audit["differences"]:
            value = by_name[change["sheet"]]["rows"][change["rowIndex"]][change["field"]]
            self.assertEqual(value, change["source"])
        self.assertEqual(CONTENT.read_bytes(), self.content)

    def test_changed_input_cannot_reuse_audit(self):
        with self.assertRaisesRegex(ValueError, "candidate inputs"):
            build_candidate(self.scene + b"\n", self.content, self.audit, self.names)

    def test_unexplained_value_change_is_rejected(self):
        audit = copy.deepcopy(self.audit)
        change = next(row for row in audit["differences"] if row["kind"] == "ObscuredFloat")
        change["classification"] = "unexplained-value-difference"
        with self.assertRaisesRegex(ValueError, "Unreviewed gameplay difference"):
            build_candidate(self.scene, self.content, audit, self.names)

    def test_missing_original_string_proof_is_rejected(self):
        names = copy.deepcopy(self.names)
        names["allSceneStringsMatchOriginal"] = False
        with self.assertRaisesRegex(ValueError, "original string proof"):
            build_candidate(self.scene, self.content, self.audit, names)

    def test_incomplete_reviewed_difference_set_is_rejected(self):
        audit = copy.deepcopy(self.audit)
        audit["differences"].pop()
        audit["differenceCount"] -= 1
        with self.assertRaisesRegex(ValueError, "difference set"):
            build_candidate(self.scene, self.content, audit, self.names)


if __name__ == "__main__":
    unittest.main()
