"""Extract observed absolute/accumulated-clock poses without inventing an animation phase."""

import gzip
import hashlib
import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
REFERENCE = ROOT / "Server/content/mortar-accumulated-unity-reference.json.gz"
OUTPUT = ROOT / "Server/content/recovered-mortar-prepared-pose.json"
REVISION = "98346fe6745e76eed3dd1016c6fdab810941cebcefe8b5f65d62ecd505c7cd14"


def extract():
    compressed = REFERENCE.read_bytes()
    if hashlib.sha256(compressed).hexdigest() != REVISION:
        raise ValueError("Native Mortar preparation reference changed without review")
    report = json.loads(gzip.decompress(compressed))
    if report["captureRate"] != 30 or report["timeScale"] != 1:
        raise ValueError("Native Mortar preparation clock changed")
    observations = []
    for scenario in report["scenarios"]:
        frames = scenario["frames"]
        for build in (frame for frame in frames if frame["phase"] == "build-called"):
            prepared = next(frame for frame in frames if frame["phase"] == "before-fire"
                            and frame["tick"] > build["tick"])
            returned = next(frame for frame in frames if frame["phase"] == "hand-return-callback"
                            and frame["tick"] > prepared["tick"])
            observations.append({
                "scenario": scenario["scenario"], "buildTick": build["tick"],
                "preparedTick": prepared["tick"], "handReturnTick": returned["tick"],
                "localPosition": prepared["localPosition"], "localRotation": prepared["localRotation"],
                "scale": prepared["snapScale"], "rootPosition": prepared["rootPosition"],
                "rootRotation": prepared["rootRotation"], "worldPosition": prepared["snapPosition"],
                "worldRotation": prepared["snapRotation"],
            })
    if len(observations) != 8:
        raise ValueError("Native Mortar preparation cases are incomplete")
    return {"version": 1, "sourceReferenceSha256": REVISION, "buildSeconds": 2.0,
            "sources": report["sources"], "observations": observations}


def main():
    content = json.dumps(extract(), indent=2) + "\n"
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_text(encoding="utf-8") != content:
            raise ValueError("Mortar prepared-pose artifact differs from the native observation")
    elif not sys.argv[1:]:
        OUTPUT.write_text(content, encoding="utf-8", newline="\n")
    else:
        raise ValueError("usage: extract_mortar_prepared_pose.py [--check]")
    print("Verified native Mortar prepared snap-point poses in both controller orders")


if __name__ == "__main__":
    main()
