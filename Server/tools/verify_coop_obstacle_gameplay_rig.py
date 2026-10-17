"""Verify the pinned gameplay-phase obstacle capture without claiming fresh-actor replay."""

import gzip
import hashlib
import json
import math
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CAPTURE = ROOT / "Server/content/coop-obstacle-gameplay-rig-reference.json.gz"
CAPTURE_HASH = "38d11bb529825a7337eddabae5913fc4c2c1ddef7c138cf0a96b0d61ccea1781"


def require(condition, message):
    if not condition:
        raise ValueError(message)


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def verify():
    require(digest(CAPTURE) == CAPTURE_HASH, "The reviewed capture bytes changed.")
    capture = json.loads(gzip.decompress(CAPTURE.read_bytes()))
    require(capture["unity"] == "2018.3.0f2" and capture["captureRate"] == 30 and
            capture["wholeRig"] is True and capture["physicsFrozen"] is True and
            capture["proceduralLookEnabled"] is False and capture["roundInvocations"] == 2 and
            capture["observedReturnToCrawl"] is True, "Unsupported capture scope.")
    bindings = {
        "prefabSha256": "Clients/ExportedProject/Assets/GameObject/enemy.prefab",
        "controllerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs",
        "exporterSha256": "Server/tools/UnityCoopObstacleVolleyPoseExport.cs",
        "rigReplaySha256": "Server/tools/UnityCoopObstacleRigReplayProbe.cs",
        "samplerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs",
        "planSha256": "Server/content/coop-obstacle-volley-source-plan.json",
    }
    for field, name in bindings.items():
        require(capture[field] == digest(ROOT / name), "Source binding differs: " + field)
    for clip in capture["clips"]:
        path = ROOT / "Clients/ExportedProject/Assets/AnimationClip" / (clip["name"] + ".anim")
        require(clip["sha256"] == digest(path), "Source clip differs.")
    samples = capture["samples"]
    require(len(samples) == 82, "Incomplete observation sequence.")
    for index, frame in enumerate(samples):
        require(frame["tick"] == index - 1, "Observation ticks are not contiguous.")
        verify_frame(frame)
    require(abs(samples[1]["replay"]["totalWeight"] - 1 / 3) < 0.000001 and
            abs(samples[2]["replay"]["totalWeight"] - 2 / 3) < 0.000001,
            "The initial partial-weight observations are missing.")
    print("PASS: 82 gameplay-phase obstacle frames; 59 transforms; primed replay within existing tolerances")
    print("Unverified: fresh-actor and skipped-snapshot replay; no SDK weight policy change")


def verify_frame(frame):
    rig = frame["rig"]
    transforms = rig["transforms"]
    require(len(transforms) == 59 and len({row["path"] for row in transforms}) == 59,
            "The complete source hierarchy is required.")
    for row in transforms:
        for field, count in (("position", 3), ("rotation", 4), ("scale", 3)):
            require(len(row[field]) == count and all(math.isfinite(value) for value in row[field]),
                    "Malformed source transform.")
    replay = frame["replay"]
    require(replay["transforms"] == len(transforms), "Replay hierarchy differs.")
    for field, limit in (("maximumPositionError", 0.00001), ("maximumRotationError", 0.000001),
                         ("maximumScaleError", 0.00001)):
        value = replay[field]
        require(math.isfinite(value) and 0 <= value <= limit, "Replay tolerance exceeded: " + field)
    total = sum(state["weight"] for state in rig["states"])
    require(math.isfinite(total) and total > 0 and abs(total - replay["totalWeight"]) < 0.000001,
            "Replay does not bind the observed mixer weights.")


if __name__ == "__main__":
    verify()
