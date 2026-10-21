"""Check that the small producer disposition guard cannot silently omit familiar C# bodies."""

import tempfile
import unittest
from pathlib import Path

from legacy_buffer_producer_inventory import planner_result_sets


class ProducerInventoryTests(unittest.TestCase):
    def scan(self, code, actions=None, relative_path="Fixture.cs"):
        with tempfile.TemporaryDirectory(prefix="warfriends-producer-inventory-") as directory:
            repository = Path(directory)
            folder = repository / "Server/src/War.Backend/Legacy/Buffering"
            folder.mkdir(parents=True)
            target = folder / relative_path
            target.parent.mkdir(parents=True, exist_ok=True)
            target.write_text(code, encoding="utf-8")
            return planner_result_sets(repository, actions or ["Buy"])

    def test_block_body_and_helper_dispositions(self):
        code = """
        private static (DatabaseResult, JsonObject) Buy(BufferedRequest request) {
            if (request == null) return Fail(request, DatabaseResult.WrongPlayerData);
            return Ok(request);
        }
        private static (DatabaseResult, JsonObject) Ok(BufferedRequest request) =>
            (DatabaseResult.Success, Result(request));
        """
        self.assertEqual(self.scan(code), {"Buy": ["Success", "WrongPlayerData"]})

    def test_expression_body_does_not_capture_next_block(self):
        code = """
        private static (DatabaseResult, JsonObject) Buy(BufferedRequest request) =>
            (DatabaseResult.Success, Result(request));
        private static (DatabaseResult, JsonObject) Other(BufferedRequest request) {
            return Fail(request, DatabaseResult.NotEnoughGold);
        }
        """
        self.assertEqual(self.scan(code), {"Buy": ["Success"]})

    def test_comments_strings_and_nested_blocks_do_not_add_dispositions(self):
        code = """
        private static (DatabaseResult, JsonObject) Buy(BufferedRequest request) {
            // DatabaseResult.NotEnoughGold and an unmatched brace: }
            Log("DatabaseResult.WrongPlayerData { }");
            if (request != null) { return Ok(request); }
            return (DatabaseResult.Success, null);
        }
        private static (DatabaseResult, JsonObject) Ok(BufferedRequest request) =>
            (DatabaseResult.Success, null);
        """
        self.assertEqual(self.scan(code), {"Buy": ["Success"]})

    def test_duplicate_method_refuses_incomplete_inventory(self):
        method = "private static (DatabaseResult, JsonObject) Buy() { return (DatabaseResult.Success, null); }"
        with self.assertRaisesRegex(ValueError, "Duplicate"):
            self.scan(method + method)

    def test_missing_owned_method_does_not_pass_as_empty(self):
        with self.assertRaises(KeyError):
            self.scan("private static (DatabaseResult, JsonObject) Other() => (DatabaseResult.Success, null);")

    def test_unknown_literal_syntax_requires_review(self):
        with self.assertRaisesRegex(ValueError, "literal syntax"):
            self.scan('private static (DatabaseResult, JsonObject) Buy() { Log(@"value"); }')

    def test_relocated_internal_producer_keeps_transitive_result_inventory(self):
        code = """
        internal static (DatabaseResult, JsonObject) Buy() {
            return Rollback(DatabaseResult.NotEnoughGold);
        }
        private static (DatabaseResult, JsonObject) Rollback(DatabaseResult code) {
            return (DatabaseResult.Success, null);
        }
        """
        self.assertEqual(self.scan(code, relative_path="Features/Inventory/Weapons.cs"),
                         {"Buy": ["NotEnoughGold", "Success"]})

    def test_duplicate_producer_in_different_owner_file_is_rejected(self):
        with tempfile.TemporaryDirectory(prefix="warfriends-producer-duplicate-") as directory:
            repository = Path(directory)
            folder = repository / "Server/src/War.Backend/Legacy/Buffering"
            nested = folder / "Features/Inventory"
            nested.mkdir(parents=True)
            code = "internal static (DatabaseResult, JsonObject) Buy() => (DatabaseResult.Success, null);"
            (folder / "Original.cs").write_text(code, encoding="utf-8")
            (nested / "Moved.cs").write_text(code, encoding="utf-8")
            with self.assertRaisesRegex(ValueError, "Duplicate"):
                planner_result_sets(repository, ["Buy"])

    def test_empty_source_tree_is_rejected(self):
        with tempfile.TemporaryDirectory(prefix="warfriends-producer-absent-") as directory:
            with self.assertRaisesRegex(ValueError, "missing"):
                planner_result_sets(Path(directory), ["Buy"])


if __name__ == "__main__":
    unittest.main()
