"""Bind Unity overlap/bounds inputs and separately inspected explosion rules, without claiming damage dispatch."""

import argparse
import hashlib
import json
import math
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/grenadier-explosion-overlap-unity-reference.json"


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def verify(observed):
    if observed["version"] != 1 or observed["unity"] != "2018.3.0f2" or \
            observed["center"] != [0.8, 0.0, 0.8] or observed["size"] != [2.0, 0.1, 0.1] or \
            observed["rotationY"] != 45 or observed["hurtRadius"] != 1.2 or \
            observed["playerRadiusRatio"] != 0.7 or observed["outsideGate"] != [0.0, 0.0, 1.65]:
        raise ValueError("Native overlap boundary inputs changed")
    bindings = {
        "inspectedExplosionSha256": CLIENT / "Assets/Scripts/Assembly-CSharp/Explosion.cs",
        "exporterSha256": ROOT / "Server/tools/UnityGrenadierExplosionOverlapAudit.cs",
    }
    for key, path in bindings.items():
        if observed[key] != digest(path):
            raise ValueError(f"Overlap source evidence changed: {path}")
    if observed["fullOverlap"] is not True or observed["reducedOverlap"] is not False or \
            observed["outsideFullOverlap"] is not True or \
            not math.isfinite(observed["boundsDistance"]) or \
            abs(observed["boundsDistance"] - 0.0813709) > 0.00001 or \
            not math.isfinite(observed["outsideBoundsDistance"]) or \
            abs(observed["outsideBoundsDistance"] - 0.9075378) > 0.00001:
        raise ValueError("Native overlap/bounds observations changed")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--publish", type=Path)
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args()
    if args.publish and args.check:
        parser.error("choose --publish or --check")
    observed = json.loads((args.publish or OUTPUT).read_text(encoding="utf-8-sig"))
    verify(observed)
    if args.publish:
        OUTPUT.write_text(json.dumps(observed, indent=2) + "\n", encoding="utf-8", newline="\n")
    print("2 native overlap/bounds cases verified; original explosion source is inspected, not dispatched")
    print("SHA-256:", digest(OUTPUT))


if __name__ == "__main__":
    main()
