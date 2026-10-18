"""Bind executed corner-contact observations without claiming full map trajectory parity."""

import argparse
import json
from pathlib import Path

from verify_grenadier_fuse import ROOT, SOURCES, digest, single

OUTPUT = ROOT / "Server/content/grenadier-corner-contact-unity-reference.json"
CORNER_SOURCES = dict(SOURCES)
CORNER_SOURCES["exporterSha256"] = ROOT / "Server/tools/UnityGrenadierCornerContactExport.cs"


def verify(observed):
    if observed["version"] != 1 or observed["unity"] != "2018.3.0f2" or \
            observed["captureRate"] != 30 or observed["timeScale"] != 1 or \
            abs(observed["fixedDeltaTime"] - 1 / 30) > 0.000001:
        raise ValueError("Native corner observation clock changed")
    for key, path in CORNER_SOURCES.items():
        if observed[key] != digest(path):
            raise ValueError(f"Executed corner source changed: {path}")
    rows = observed["observations"]
    if len(rows) != 2:
        raise ValueError("Expected ordinary three-second and short-special corner probes")
    for row, fuse, expiry in zip(rows, [single(3), single(3 - single(single(3) * single(0.7)))], [101, 37]):
        if single(row["fuseSeconds"]) != fuse or row["recontact"] or row["expiryTick"] != expiry or \
                row["lastContactTick"] != 11 or row["exits"] or \
                row["activeSources"] != ["CornerFloor", "CornerWall"] or \
                [(contact["tick"], contact["source"]) for contact in row["contacts"]] != \
                [(1, "CornerWall"), (11, "CornerFloor")] or \
                any(single(contact["remaining"]) != fuse for contact in row["contacts"]):
            raise ValueError("Native simultaneous floor/wall contact evidence changed")


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
    print("2 executed floor/wall countdowns verified; both contacts remain active with no exit callback")
    print("SHA-256:", digest(OUTPUT))


if __name__ == "__main__":
    main()
