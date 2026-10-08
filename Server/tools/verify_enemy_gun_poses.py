"""Check the animated gun attachment against recovered enemy-pose samples."""

import json
import math
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server" / "content"


def main() -> None:
    gun = json.loads((CONTENT / "recovered-enemy-gun-poses.json").read_text())
    reference = json.loads((CONTENT / "recovered-enemy-poses.json").read_text())

    assert gun["version"] == 1
    assert gun["client"] == reference["client"] == "1.4.0"
    assert gun["source"] == reference["source"]
    assert gun["sha256"] == reference["sha256"]
    assert gun["sampleRate"] == reference["sampleRate"] == 30
    assert gun["attachmentPath"].endswith("/GunPivot/gunSnapPoint")
    assert len(gun["clips"]) == len(reference["clips"]) > 100

    samples = 0
    for clip, original in zip(gun["clips"], reference["clips"]):
        for key in ("name", "source", "guid", "fileId", "sha256", "length", "wrap"):
            assert clip[key] == original[key], (clip["name"], key)
        assert len(clip["frames"]) == len(original["frames"])

        for frame, original_frame in zip(clip["frames"], original["frames"]):
            assert frame["seconds"] == original_frame["seconds"]
            position = frame["position"]
            rotation = frame["rotation"]
            assert len(position) == 3 and len(rotation) == 4
            assert all(math.isfinite(value) and abs(value) < 100 for value in position)
            assert all(math.isfinite(value) for value in rotation)
            assert abs(sum(value * value for value in rotation) - 1) < 0.001
            samples += 1

    print(f"PASS: {len(gun['clips'])} source-bound clips, {samples} animated gun poses")


if __name__ == "__main__":
    main()
