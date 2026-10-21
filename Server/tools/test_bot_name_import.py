"""Guard source identity and byte preservation for disposable import preparation."""
import unittest

from audit_bot_name_source import SCENE
from prepare_bot_name_import import COMPONENT_HEADER, prepare_scene


class ImportPreparationTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.source = SCENE.read_bytes()

    def test_changes_only_four_scalar_lines(self):
        prepared, changes = prepare_scene(self.source)
        self.assertEqual([row["rowIndex"] for row in changes], [182, 205, 231, 240])
        before = self.source.splitlines(keepends=True)
        after = prepared.splitlines(keepends=True)
        self.assertEqual(len(before), len(after))
        differences = [(left, right) for left, right in zip(before, after) if left != right]
        self.assertEqual(len(differences), 4)
        for left, right in differences:
            self.assertTrue(left.startswith(b"  - NAME: "))
            self.assertTrue(right.startswith(b'  - NAME: "'))
            self.assertTrue(right.isascii())

    def test_second_preparation_is_unchanged(self):
        prepared, _ = prepare_scene(self.source)
        repeated, changes = prepare_scene(prepared)
        self.assertEqual(prepared, repeated)
        self.assertEqual(changes, [])

    def test_bom_is_preserved(self):
        source = b"\xef\xbb\xbf" + self.source.removeprefix(b"\xef\xbb\xbf")
        prepared, _ = prepare_scene(source)
        self.assertTrue(prepared.startswith(b"\xef\xbb\xbf"))

    def test_ambiguous_component_is_rejected(self):
        for source in [self.source.replace(COMPONENT_HEADER.encode(), b"", 1),
                       self.source + COMPONENT_HEADER.encode()]:
            with self.assertRaises(ValueError):
                prepare_scene(source)


if __name__ == "__main__":
    unittest.main()
