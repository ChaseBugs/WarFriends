"""Check exact comparison boundaries independently from native sampling."""
import json
import unittest

import recapture_player_references as references


class PlayerReferenceRecaptureTests(unittest.TestCase):
    def test_only_scene_provenance_may_change(self):
        scene = b"fixture scene"
        for name in references.OUTPUTS.values():
            with self.subTest(artifact=name):
                document = json.loads((references.capture.ROOT / "Server/content" / name).read_bytes())
                document["sha256"] = references.capture.digest(scene)
                payload = json.dumps(document).encode()
                self.assertTrue(references.validate(payload, scene, name)["valuesEqual"])
                with self.assertRaisesRegex(ValueError, "different scene"):
                    references.validate(payload, b"other scene", name)

    def test_unreviewed_fields_are_rejected(self):
        scene = b"fixture scene"
        for name in references.OUTPUTS.values():
            with self.subTest(artifact=name):
                document = json.loads((references.capture.ROOT / "Server/content" / name).read_bytes())
                document["sha256"] = references.capture.digest(scene)
                document["unreviewed"] = True
                with self.assertRaisesRegex(ValueError, "values changed"):
                    references.validate(json.dumps(document).encode(), scene, name)

    def test_changed_geometry_or_sample_weight_is_rejected(self):
        scene = b"fixture scene"
        for name in references.OUTPUTS.values():
            with self.subTest(artifact=name):
                document = json.loads((references.capture.ROOT / "Server/content" / name).read_bytes())
                document["sha256"] = references.capture.digest(scene)
                if "models" in document:
                    document["models"][0]["position"][0] = 999
                else:
                    document["cases"][0]["weight"] = 999
                with self.assertRaisesRegex(ValueError, "values changed"):
                    references.validate(json.dumps(document).encode(), scene, name)


if __name__ == "__main__":
    unittest.main()
