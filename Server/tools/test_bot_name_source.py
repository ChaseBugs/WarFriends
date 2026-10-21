"""Reject malformed original string evidence before it can justify a catalog change."""
import struct
import unittest

from audit_bot_name_source import ROW_COUNT, decode_payload, read_array


def encode_array(values):
    result = bytearray(struct.pack("<i", len(values)))
    for value in values:
        encoded = value.encode("utf-8")
        result.extend(struct.pack("<i", len(encoded)))
        result.extend(encoded)
        result.extend(bytes((-len(result)) % 4))
    return bytes(result)


def payload():
    header = struct.pack("<iqB3xiqI", 0, 6369, 1, 1, 570, 0)
    rows = encode_array(["ID_" + str(index + 1) for index in range(ROW_COUNT)])
    names = ["brown(‿ˠ‿)mailr"] * ROW_COUNT
    return header + rows + encode_array(names), names


class OriginalBotNameTests(unittest.TestCase):
    def test_unicode_uses_byte_lengths_and_preserves_suffixes(self):
        raw, expected = payload()
        rows, names = decode_payload(raw)
        self.assertEqual(rows[-1], "ID_269")
        self.assertEqual(names, expected)

    def test_header_and_trailing_bytes_are_rejected(self):
        raw, _ = payload()
        for invalid in [b"x" + raw[1:], raw + b"\0", raw[:31]]:
            with self.subTest(length=len(invalid)), self.assertRaises(ValueError):
                decode_payload(invalid)

    def test_counts_and_lengths_are_bounded(self):
        for invalid in [b"", struct.pack("<i", 268), struct.pack("<ii", ROW_COUNT, -1),
                        struct.pack("<ii", ROW_COUNT, 1025), struct.pack("<ii", ROW_COUNT, 8)]:
            with self.subTest(raw=invalid), self.assertRaises(ValueError):
                read_array(invalid, 0)

    def test_invalid_utf8_is_rejected(self):
        with self.assertRaises(UnicodeDecodeError):
            read_array(struct.pack("<ii", ROW_COUNT, 1) + b"\xff\0\0\0", 0)

    def test_alignment_must_be_complete_and_zero(self):
        for suffix in [b"a", b"a\0\0x"]:
            with self.subTest(suffix=suffix), self.assertRaises(ValueError):
                read_array(struct.pack("<ii", ROW_COUNT, 1) + suffix, 0)

    def test_row_order_is_authority(self):
        raw, _ = payload()
        with self.assertRaises(ValueError):
            decode_payload(raw.replace(b"ID_1", b"ID_9", 1))


if __name__ == "__main__":
    unittest.main()
