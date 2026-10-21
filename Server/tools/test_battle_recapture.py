"""Native result validation must bind the actual input and reject even one wrong source cell."""
import json
import tempfile
import unittest
from pathlib import Path

from audit_battle_sheet_values import CONTENT, ROOT, SCENE
from prepare_bot_name_import import prepare_scene
from recapture_battle_content import digest, validate_export
from stage_battle_sheet_content import build_candidate


class NativeResultTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.scene = SCENE.read_bytes()
        cls.prepared, _ = prepare_scene(cls.scene)
        audit = json.loads((ROOT / "Server/docs/battle-sheet-value-audit.json").read_bytes())
        names = json.loads((ROOT / "Server/docs/bot-name-source-audit.json").read_bytes())
        cls.document = json.loads(build_candidate(cls.scene, CONTENT.read_bytes(), audit, names))
        cls.document["mainSceneSha256"] = digest(cls.prepared)

    def validate(self, document):
        with tempfile.TemporaryDirectory(prefix="war-native-result-") as directory:
            root = Path(directory)
            (root / "native-battle-content.json").write_text(json.dumps(document), encoding="utf-8")
            return validate_export(root, self.scene, self.prepared)

    def test_exact_typed_candidate_is_accepted(self):
        self.assertEqual(len(self.validate(self.document)), 64)

    def test_original_hash_cannot_masquerade_as_prepared_input(self):
        document = dict(self.document, mainSceneSha256=digest(self.scene))
        with self.assertRaisesRegex(ValueError, "actual prepared input"):
            self.validate(document)

    def test_one_truncated_name_rejects_entire_native_result(self):
        document = json.loads(json.dumps(self.document))
        sheet = next(row for row in document["sheets"] if row["type"] == "Google2u.BotNames")
        sheet["rows"][182]["NAME"] = "truncated"
        with self.assertRaisesRegex(ValueError, "typed original sheet values"):
            self.validate(document)


if __name__ == "__main__":
    unittest.main()
