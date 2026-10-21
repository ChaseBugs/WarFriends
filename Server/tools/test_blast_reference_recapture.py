"""Reject value and dependency changes independently from native capture execution."""
import json
import unittest

import recapture_blast_references as references


class BlastReferenceRecaptureTests(unittest.TestCase):
    def document(self, name):
        document = json.loads((references.capture.ROOT / "Server/content" / name).read_bytes())
        if name == "recovered-grenade-rig.json":
            document.update(sceneSha256=references.capture.digest(b"scene"),
                            bindingSceneSha256=references.capture.digest(b"scene"),
                            bindingArtifactSha256=references.capture.digest(b"bindings"))
        else:
            document["sha256"] = references.capture.digest(b"scene")
        return document

    def validate(self, name, document):
        return references.validate(json.dumps(document).encode(), b"scene", b"bindings", name)

    def test_only_bound_provenance_can_change(self):
        for name in references.OUTPUTS.values():
            with self.subTest(artifact=name):
                self.assertTrue(self.validate(name, self.document(name))["valuesEqual"])

    def test_changed_bindings_are_rejected(self):
        name = "recovered-grenade-rig.json"
        document = self.document(name)
        document["bindingArtifactSha256"] = "0" * 64
        with self.assertRaisesRegex(ValueError, "dependency differs"):
            self.validate(name, document)

    def test_changed_scene_is_rejected(self):
        for name in references.OUTPUTS.values():
            with self.subTest(artifact=name):
                document = self.document(name)
                document["sceneSha256" if "sceneSha256" in document else "sha256"] = "0" * 64
                with self.assertRaisesRegex(ValueError, "dependency differs"):
                    self.validate(name, document)

    def test_changed_native_samples_are_rejected(self):
        for name in references.OUTPUTS.values():
            with self.subTest(artifact=name):
                document = self.document(name)
                if "clips" in document:
                    document["clips"][0]["frames"][0]["root"]["position"][0] += 1
                else:
                    document["poses"][0]["probes"][0]["hits"] = [999]
                with self.assertRaisesRegex(ValueError, "values changed"):
                    self.validate(name, document)


if __name__ == "__main__":
    unittest.main()
