"""Check strict pose comparison without treating fixtures as native animation evidence."""
import json
import unittest

import recapture_pose_content as poses


class PoseRecaptureTests(unittest.TestCase):
    def test_existing_pose_documents_accept_only_scene_provenance_change(self):
        scene = b"fixture scene"
        for name in poses.OUTPUTS.values():
            with self.subTest(name=name):
                document = json.loads((poses.capture.ROOT / "Server/content" / name).read_bytes())
                document["sha256"] = poses.capture.digest(scene)
                payload = json.dumps(document).encode()
                self.assertTrue(poses.validate(payload, scene, name)["valuesEqual"])
                with self.assertRaisesRegex(ValueError, "different scene"):
                    poses.validate(payload, b"other", name)

    def test_changed_pose_frame_cannot_hide_as_provenance(self):
        name = "recovered-grenade-poses.json"
        scene = b"fixture scene"
        document = json.loads((poses.capture.ROOT / "Server/content" / name).read_bytes())
        document["sha256"] = poses.capture.digest(scene)
        document["clips"][0]["frames"][0]["seconds"] = 99
        with self.assertRaisesRegex(ValueError, "pose values changed"):
            poses.validate(json.dumps(document).encode(), scene, name)


if __name__ == "__main__":
    unittest.main()
