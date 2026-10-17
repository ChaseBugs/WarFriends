"""Restore two recovered PCM container lengths without changing sample bytes or GUIDs."""

import argparse
import hashlib
from pathlib import Path
import struct


ROOT = Path(__file__).resolve().parents[2]
AUDIO_ROOT = ROOT / "Clients/ExportedProject/Assets/Resources/sounds/sfx/game/new"
SOURCE_DIGESTS = {
    "EXPLOSION_MEDIUM": "9f4607932f030fc81a5e0b614cd4b9775f426283ca15ddc3692b0a6fee423087",
    "EXPLOSION_SMALL": "89b4964e4ce1829dce88f29954b0b54d34afe8d0294af9aaf98bba53734a5b55",
}
RIFF_LENGTH_OFFSET = 4
DATA_LENGTH_OFFSET = 42
SAMPLE_OFFSET = 46


def restore_header(original: bytes) -> bytes:
    """Require the recovered mono PCM layout before restoring its two lengths."""
    if original[:4] != b"RIFF" or original[8:16] != b"WAVEfmt ":
        raise ValueError("Unexpected recovered WAVE container.")
    if struct.unpack_from("<I", original, 16)[0] != 18 or original[38:42] != b"data":
        raise ValueError("Unexpected recovered chunk layout.")
    if struct.unpack_from("<HH", original, 20) != (1, 1):
        raise ValueError("Expected recovered mono PCM samples.")
    if struct.unpack_from("<HH", original, 32) != (2, 16):
        raise ValueError("Expected two-byte, 16-bit source samples.")
    sample_length = len(original) - SAMPLE_OFFSET
    if sample_length <= 0 or sample_length % 2:
        raise ValueError("Incomplete recovered PCM samples.")

    restored = bytearray(original)
    struct.pack_into("<I", restored, RIFF_LENGTH_OFFSET, len(original) - 8)
    struct.pack_into("<I", restored, DATA_LENGTH_OFFSET, sample_length)
    return bytes(restored)


def main() -> None:
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--verify", action="store_true")
    arguments = parser.parse_args()
    for name, source_digest in SOURCE_DIGESTS.items():
        path = AUDIO_ROOT / (name + ".wav")
        current = path.read_bytes()
        # The zero-length reconstruction recovers the pinned extraction identity.
        original = bytearray(current)
        struct.pack_into("<I", original, RIFF_LENGTH_OFFSET, 0)
        struct.pack_into("<I", original, DATA_LENGTH_OFFSET, 0)
        if hashlib.sha256(original).hexdigest() != source_digest:
            raise ValueError("Recovered source bytes changed: " + name)
        restored = restore_header(bytes(original))
        if arguments.verify:
            if current != restored:
                raise ValueError("WAVE header still needs restoration: " + name)
        elif current != restored:
            path.write_bytes(restored)
        print(name, "verified", hashlib.sha256(restored).hexdigest())


if __name__ == "__main__":
    main()
