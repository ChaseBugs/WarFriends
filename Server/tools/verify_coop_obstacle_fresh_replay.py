"""Validate independent per-frame obstacle replay without changing SDK admission policy."""

import json
import math

from verify_coop_obstacle_gameplay_rig import CAPTURE_HASH, ROOT, digest, require, verify

REPORT = ROOT / "Server/content/coop-obstacle-fresh-replay-reference.json"
REPORT_HASH = "ec0ced57a03a743f29d112e14decb9c9689b3764fd2f34d30801234278e58f89"


def verify_fresh():
    verify()
    require(digest(REPORT) == REPORT_HASH, "The reviewed fresh replay changed.")
    report = json.loads(REPORT.read_text(encoding="utf-8"))
    require(report["unity"] == "2018.3.0f2" and report["referenceSha256"] == CAPTURE_HASH,
            "Fresh replay does not bind the source capture.")
    bindings = {
        "prefabSha256": "Clients/ExportedProject/Assets/GameObject/enemy.prefab",
        "samplerSha256": "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs",
        "auditSha256": "Server/tools/UnityCoopObstacleFreshReplayAudit.cs",
    }
    for field, name in bindings.items():
        require(report[field] == digest(ROOT / name), "Fresh replay source differs: " + field)
    require(len(report["frames"]) == 82, "Fresh replay is incomplete.")
    for index, frame in enumerate(report["frames"]):
        require(frame["tick"] == index - 1 and frame["transforms"] == 59, "Fresh hierarchy differs.")
        for field, limit in (("maximumPositionError", 0.00001), ("maximumRotationError", 0.000001),
                             ("maximumScaleError", 0.00001)):
            require(math.isfinite(frame[field]) and 0 <= frame[field] <= limit,
                    "Fresh replay exceeds existing tolerance: " + field)
    print("PASS: 82 independent prefab replays including partial-weight frames; no prior animation required")


if __name__ == "__main__":
    verify_fresh()
