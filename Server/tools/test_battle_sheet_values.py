"""Guard source cell decoding and exact scalar authority in the sheet audit."""
import struct
import unittest

import yaml

import audit_battle_sheet_values as audit


class BattleSheetValueTests(unittest.TestCase):
    def test_obscured_float_keeps_original_binary32_bits(self):
        value = {"currentCryptoKey": "230887", "hiddenValue": "2a496f40",
                 "fakeValue": "0", "inited": "1"}
        self.assertEqual(struct.pack("<f", 3.7), struct.pack("<f", audit.read_cell(value, "ObscuredFloat")))

    def test_obscured_integer_decodes_clip_capacity(self):
        value = {"currentCryptoKey": "444444", "hiddenValue": "444416",
                 "fakeValue": "0", "inited": "1"}
        self.assertEqual(28, audit.read_cell(value, "ObscuredInt"))

    def test_unreviewed_obscured_states_fail(self):
        value = {"currentCryptoKey": "444444", "hiddenValue": "444416",
                 "fakeValue": "0", "inited": "1"}
        for field, replacement in [("inited", "0"), ("fakeValue", "28"), ("currentCryptoKey", "0")]:
            with self.subTest(field=field), self.assertRaises(ValueError):
                audit.read_cell(dict(value, **{field: replacement}), "ObscuredInt")

    def test_duplicate_yaml_keys_fail(self):
        with self.assertRaisesRegex(ValueError, "Duplicate"):
            yaml.load("Rows:\n- NAME: first\n  NAME: second\n", Loader=audit.UniqueScalarLoader)

    def test_yaml_strings_keep_their_spelling(self):
        result = yaml.load("NAME: 001\nOTHER: false\n", Loader=audit.UniqueScalarLoader)
        self.assertEqual({"NAME": "001", "OTHER": "false"}, result)

    def test_numeric_boolean_export_is_rejected(self):
        for value, kind in [(True, "int"), (True, "float"), (1, "bool"), (1, "string")]:
            with self.subTest(kind=kind), self.assertRaises(ValueError):
                audit.normalize_export(value, kind)

    def test_nonfinite_float_is_rejected(self):
        for value in [float("nan"), float("inf"), -float("inf")]:
            with self.subTest(value=value), self.assertRaises(ValueError):
                audit.normalize_export(value, "float")

    def test_integer_width_is_enforced(self):
        for kind, maximum in [("int", 2**31 - 1), ("long", 2**63 - 1)]:
            self.assertEqual(maximum, audit.read_cell(str(maximum), kind))
            with self.assertRaises(ValueError):
                audit.read_cell(str(maximum + 1), kind)


if __name__ == "__main__":
    unittest.main()
