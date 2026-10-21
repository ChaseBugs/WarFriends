"""Guard reviewed additions without treating arbitrary new-node samples as authoritative."""
import copy
import hashlib
import json
import unittest
from unittest.mock import patch

import audit_rig_reference_extension as extension
import recapture_player_references as references


class RigReferenceExtensionTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        previous = json.loads((extension.CONTENT / "recovered-rig-blend-reference.json").read_bytes())
        poses = json.loads((extension.CONTENT / "recovered-player-poses.json").read_bytes())
        cls.fixture = copy.deepcopy(previous)
        cls.fixture["nodes"] = poses["rigNodes"]
        old_indices = {node["path"]: index for index, node in enumerate(previous["nodes"])}
        for case in cls.fixture["cases"]:
            for field in ("a", "b", "c", "world", "local"):
                if case[field] is not None:
                    samples = case[field]
                    # Synthetic values test admission guards, not Unity equivalence.
                    case[field] = [copy.deepcopy(samples[old_indices.get(node["path"], 0)])
                                   for node in cls.fixture["nodes"]]
        values = dict(cls.fixture)
        values.pop("sha256")
        encoded = json.dumps(values, sort_keys=True, allow_nan=False, separators=(",", ":")).encode()
        cls.fixture_hash = hashlib.sha256(encoded).hexdigest()

    def review(self, document):
        with patch.object(extension, "REVIEWED_VALUES_SHA256", self.fixture_hash):
            return extension.review(json.dumps(document).encode())

    def test_review_preserves_all_nodes(self):
        result = self.review(self.fixture)
        self.assertEqual(2, result["addedNodes"])
        self.assertTrue(result["existingSamplesEqual"])
        self.assertFalse(result["candidateTrimmed"])

    def test_recapture_records_extension_instead_of_claiming_equal_values(self):
        scene = b"fixture scene"
        document = copy.deepcopy(self.fixture)
        document["sha256"] = references.capture.digest(scene)
        with patch.object(extension, "REVIEWED_VALUES_SHA256", self.fixture_hash):
            result = references.validate(json.dumps(document).encode(), scene, "recovered-rig-blend-reference.json")
        self.assertFalse(result["valuesEqual"])
        self.assertEqual(2, result["reviewedExtension"]["addedNodes"])

    def test_synthetic_samples_do_not_pass_production_fingerprint(self):
        with self.assertRaisesRegex(ValueError, "Extended rig samples differ"):
            extension.review(json.dumps(self.fixture).encode())

    def test_changed_parent_is_rejected(self):
        document = copy.deepcopy(self.fixture)
        document["nodes"][-1]["parent"] = -1
        with self.assertRaisesRegex(ValueError, "rig nodes differ"):
            self.review(document)

    def test_changed_existing_sample_is_rejected(self):
        document = copy.deepcopy(self.fixture)
        document["cases"][0]["a"][0]["position"][0] += 1
        with self.assertRaisesRegex(ValueError, "Previously reviewed"):
            self.review(document)

    def test_changed_added_sample_is_rejected(self):
        document = copy.deepcopy(self.fixture)
        index = next(index for index, node in enumerate(document["nodes"])
                     if node["path"] == extension.HEAD_ROOT + "/shotTargetHead")
        document["cases"][0]["a"][index]["position"][0] += 1
        with self.assertRaisesRegex(ValueError, "Extended rig samples differ"):
            self.review(document)

    def test_incomplete_samples_are_rejected(self):
        document = copy.deepcopy(self.fixture)
        document["cases"][0]["local"].pop()
        with self.assertRaisesRegex(ValueError, "samples are incomplete"):
            self.review(document)

    def test_extra_fields_are_rejected(self):
        document = copy.deepcopy(self.fixture)
        document["unreviewed"] = True
        with self.assertRaisesRegex(ValueError, "Previously reviewed"):
            self.review(document)


if __name__ == "__main__":
    unittest.main()
