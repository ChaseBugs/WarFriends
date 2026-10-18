"""Verify executed grenade contact/countdown evidence without claiming Photon dispatch or full-flight parity."""

import argparse
import hashlib
import json
import math
import struct
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/grenadier-fuse-unity-reference.json"
SOURCES = {
    "grenadeSha256": CLIENT / "Assets/Scripts/Assembly-CSharp/GrenadeAmmoBase.cs",
    "timeManagerSha256": CLIENT / "Assets/Scripts/Assembly-CSharp/TimeManager.cs",
    "probeSha256": ROOT / "Server/tools/UnityGrenadierFuseProbe.cs",
    "exporterSha256": ROOT / "Server/tools/UnityGrenadierFuseExport.cs",
}


def single(value):
    return struct.unpack("f", struct.pack("f", value))[0]


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def verify(observed):
    if observed["version"] != 1 or observed["unity"] != "2018.3.0f2" or \
            observed["captureRate"] != 30 or observed["timeScale"] != 1 or \
            abs(observed["fixedDeltaTime"] - 1 / 30) > 0.000001:
        raise ValueError("Native contact/countdown clock changed")
    for key, path in SOURCES.items():
        if observed[key] != digest(path):
            raise ValueError(f"Executed source binding changed: {path}")
    rows = observed["observations"]
    if len(rows) != 6:
        raise ValueError("Expected three source fuses with and without recontact")
    fuses = [single(3), single(2.4), single(single(3) - single(single(3) * single(0.7)))]
    for index, row in enumerate(rows):
        contacts = row["contacts"]
        expected_ticks = [7] if index < 3 else [7, 16]
        if row["recontact"] != (index >= 3) or single(row["fuseSeconds"]) != fuses[index % 3] or \
                [contact["tick"] for contact in contacts] != expected_ticks or \
                row["lastContactTick"] != expected_ticks[-1] or \
                row["expiryTick"] != expected_ticks[-1] + [90, 72, 26][index % 3]:
            raise ValueError("Native source fuse/reset observations changed")
        if any(not math.isfinite(contact["remaining"]) or
               single(contact["remaining"]) != fuses[index % 3] for contact in contacts):
            raise ValueError("A physical recontact did not reset the original countdown field")


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
    print("6 executed contact/countdown observations verified; Photon dispatch and full flight are outside this fixture")
    print("SHA-256:", digest(OUTPUT))


if __name__ == "__main__":
    main()
