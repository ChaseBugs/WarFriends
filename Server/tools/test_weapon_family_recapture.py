"""Check batching edits and exact family comparison without claiming Unity execution."""
import json
from pathlib import Path
import tempfile
import unittest

import recapture_weapon_families as families


class WeaponFamilyRecaptureTests(unittest.TestCase):
    def test_all_nine_existing_documents_accept_only_scene_provenance_change(self):
        scene = b"fixture"
        for family, _, _, _ in families.FAMILIES:
            with self.subTest(family=family):
                path = families.capture.ROOT / "Server/content" / families.output_name(family)
                document = json.loads(path.read_bytes())
                document["sha256"] = families.capture.digest(scene)
                payload = json.dumps(document).encode()
                self.assertTrue(families.validate(payload, scene, family)["valuesEqual"])
                document["unexpected"] = True
                with self.assertRaisesRegex(ValueError, "values changed"):
                    families.validate(json.dumps(document).encode(), scene, family)

    def test_batch_removes_only_known_success_exit_and_preserves_exporter_bytes(self):
        with tempfile.TemporaryDirectory() as temporary:
            project = Path(temporary)
            editor = project / "Assets/Editor"
            editor.mkdir(parents=True)
            for _, exporter, _, count in (("all", "AllWeapon", "ALL_WEAPON", 1),) + families.FAMILIES:
                source = b"export();" + b"EditorApplication.Exit(0);" * count
                (editor / ("SelfHosted" + exporter + "Export.cs")).write_bytes(source)
            edits, wrapper = families.prepare_batch(project)
            self.assertEqual(len(edits), 10)
            self.assertEqual(wrapper.count(b"Export.Run();"), 10)
            for path in edits:
                self.assertNotIn(b"EditorApplication.Exit(0);", (project / path).read_bytes())
                self.assertTrue((project / path).read_bytes().startswith(b"export();"))

    def test_unexpected_exit_shape_is_rejected(self):
        with tempfile.TemporaryDirectory() as temporary:
            project = Path(temporary)
            editor = project / "Assets/Editor"
            editor.mkdir(parents=True)
            (editor / "SelfHostedAllWeaponExport.cs").write_bytes(b"EditorApplication.Exit(0);")
            (editor / "SelfHostedWeaponExport.cs").write_bytes(b"EditorApplication.Exit(0);")
            with self.assertRaisesRegex(ValueError, "exit shape"):
                families.prepare_batch(project)


if __name__ == "__main__":
    unittest.main()
