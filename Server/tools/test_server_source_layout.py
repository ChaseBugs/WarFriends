"""Keep project extraction checks strict when source files split across assemblies."""

import copy
import tempfile
import unittest
from pathlib import Path

import verify_server_source_layout as layout


class ProjectExtractionTests(unittest.TestCase):
    def setUp(self):
        temporary = tempfile.TemporaryDirectory(prefix="war-layout-tests-")
        self.addCleanup(temporary.cleanup)
        self.root = Path(temporary.name)
        self.origin = "Server/src/War.BattleServer/Matches/Before.cs"
        self.targets = ["Server/src/War.Battle.Domain/Matches/Before.cs",
                        "Server/src/War.Battle.Domain/Matches/After.cs"]
        for name in self.targets:
            path = self.root / name
            path.parent.mkdir(parents=True, exist_ok=True)
            path.write_text("// fixture\n", encoding="utf-8")
        self.manifest = {"schemaVersion": 1, "description": "fixture", "extractions": [
            {"from": self.origin, "to": self.targets, "sourceRemains": False, "originalSha256": "a" * 64}]}

    def failures(self, manifest=None):
        return layout.validate_extractions(self.root, self.manifest if manifest is None else manifest, (1, 2))[1]

    def test_complete_one_to_many_extraction_is_valid(self):
        self.assertEqual([], self.failures())

    def test_partial_split_requires_the_remaining_source(self):
        self.manifest["extractions"][0]["sourceRemains"] = True
        self.assertTrue(self.failures())
        path = self.root / self.origin
        path.parent.mkdir(parents=True)
        path.write_text("// retained runtime\n", encoding="utf-8")
        self.assertEqual([], self.failures())
        self.manifest["extractions"][0]["sourceRemains"] = False
        self.assertTrue(self.failures())

    def test_missing_or_duplicate_targets_are_refused(self):
        (self.root / self.targets[1]).unlink()
        self.assertTrue(self.failures())
        self.manifest["extractions"][0]["to"] = [self.targets[0], self.targets[0]]
        self.assertTrue(self.failures())

    def test_duplicate_or_omitted_origins_do_not_reduce_the_inventory(self):
        self.manifest["extractions"].append(copy.deepcopy(self.manifest["extractions"][0]))
        self.assertTrue(self.failures())
        self.manifest["extractions"] = []
        self.assertTrue(self.failures())

    def test_source_and_target_projects_cannot_escape_the_boundary(self):
        for name in ("../outside.cs", "Server/src/War.Backend/Features/Before.cs",
                     "Server/src/War.BattleServer/Matches/../Before.cs"):
            with self.subTest(name=name):
                damaged = copy.deepcopy(self.manifest)
                damaged["extractions"][0]["from"] = name
                self.assertTrue(self.failures(damaged))
        for name in ("Server/src/War.Battle.Domain/Before.cs", "Server/src/War.Backend/Features/After.cs"):
            damaged = copy.deepcopy(self.manifest)
            damaged["extractions"][0]["to"][1] = name
            self.assertTrue(self.failures(damaged))

    def test_coercive_flags_versions_and_invalid_hashes_are_refused(self):
        for field, value in (("sourceRemains", 0), ("sourceRemains", "false"),
                             ("originalSha256", "A" * 64), ("originalSha256", None)):
            damaged = copy.deepcopy(self.manifest)
            damaged["extractions"][0][field] = value
            self.assertTrue(self.failures(damaged))
        damaged = copy.deepcopy(self.manifest)
        damaged["schemaVersion"] = True
        self.assertTrue(self.failures(damaged))

    def test_server_identity_can_leave_the_infrastructure_root(self):
        self.manifest["extractions"][0]["from"] = "Server/src/War.Infrastructure/QueueIdentity.cs"
        self.assertEqual([], self.failures())

    def test_key_policy_can_move_to_an_infrastructure_feature_folder(self):
        target = "Server/src/War.Infrastructure/Configuration/Before.cs"
        path = self.root / target
        path.parent.mkdir(parents=True)
        path.write_text("// server-only key policy\n", encoding="utf-8")
        self.manifest["extractions"][0]["to"][0] = target
        self.assertEqual([], self.failures())
        self.manifest["extractions"][0]["to"][0] = "Server/src/War.Infrastructure/Before.cs"
        self.assertTrue(self.failures())


if __name__ == "__main__":
    unittest.main()
