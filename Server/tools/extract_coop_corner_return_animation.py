"""Extract source-method return mixer samples; check reproducibility unless --write is supplied."""

import argparse
import gzip
import hashlib
import json
from pathlib import Path

from verify_coop_rig_capture import validate_corner_volley, validate_queue_control, validate_scenario

ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
SOURCE = CONTENT / "coop-corner-volley-rig-reference.json.gz"
OUTPUT = CONTENT / "coop-corner-return-animation-reference.json"
RETURN_EPOCH = 59
LAST_OFFSET = 31


def extract():
    source_bytes = SOURCE.read_bytes()
    capture = json.loads(gzip.decompress(source_bytes))
    if (capture["unity"] != "2018.3.0f2" or capture["captureRate"] != 30 or
            capture["physicsFrozen"] is not True or capture["cornerVolleyFixture"] is not True):
        raise ValueError("Unsupported source-method capture.")
    for scenario in capture["scenarios"]:
        validate_scenario(scenario, True)
        validate_queue_control(scenario)
    scenarios = []
    for scenario in capture["scenarios"][1:]:
        validate_corner_volley(scenario)
        side = "right" if scenario["startClip"] == "player_look_right3" else "left"
        cover_clip = f"player_{side}_coverBack3"
        frames = []
        for offset in range(1, LAST_OFFSET + 1):
            observed = scenario["frames"][RETURN_EPOCH + offset]
            clips = [dict(clipName=state["clipName"], timeSeconds=state["time"],
                          weight=state["weight"], wrap=state["wrapMode"])
                     for state in observed["rig"]["states"]]
            if any(clip["clipName"] not in (cover_clip, "idle") for clip in clips):
                raise ValueError("Source return contains an unexpected clip.")
            frames.append(dict(offset=offset, clips=clips))
        scenarios.append(dict(coverClip=cover_clip, frames=frames))
    return dict(version=1, client="1.4.0", unity=capture["unity"], captureRate=30,
                sourceSha256=hashlib.sha256(source_bytes).hexdigest(),
                enemySha256=capture["enemySha256"], controllerSha256=capture["animationControllerSha256"],
                sourceReturnEpoch=RETURN_EPOCH, scenarios=scenarios)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--write", action="store_true")
    arguments = parser.parse_args()
    expected = (json.dumps(extract(), indent=2) + "\n").encode("utf-8")
    if arguments.write:
        OUTPUT.write_bytes(expected)
    if not OUTPUT.exists() or OUTPUT.read_bytes() != expected:
        raise ValueError("The corner return artifact is not reproducible from the source capture.")
    print("PASS: 62 source-method corner return frames reproduce exactly")
    print("Artifact SHA-256:", hashlib.sha256(expected).hexdigest())


if __name__ == "__main__":
    main()
