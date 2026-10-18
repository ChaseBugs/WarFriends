"""Verify native coroutine evidence and bind its source caller without claiming controller/render execution."""

import argparse
import hashlib
import json
import math
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/grenadier-weapon-return-unity-reference.json"
NATIVE_SOURCES = {
    "coroutineSha256": CLIENT / "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
    "probeSha256": ROOT / "Server/tools/UnityGrenadierWeaponReturnProbe.cs",
    "exporterSha256": ROOT / "Server/tools/UnityGrenadierWeaponReturnExport.cs",
}
CALLER_SOURCES = {
    "behaviourSha256": CLIENT / "Assets/Scripts/Assembly-CSharp/SoldierBehaviour.cs",
    "grenadierSha256": CLIENT / "Assets/Scripts/Assembly-CSharp/SoldierBehaviourGrennader.cs",
    "inventorySha256": CLIENT / "Assets/Scripts/Assembly-CSharp/EnemyBasicInventory.cs",
}


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def verify(data):
    if data["version"] != 1 or data["unity"] != "2018.3.0f2" or \
            data["captureRate"] != 30 or data["timeScale"] != 1:
        raise ValueError("Native weapon-return observation clock changed")
    for key, path in NATIVE_SOURCES.items():
        if data[key] != digest(path):
            raise ValueError(f"Native weapon-return input changed: {path}")
    if [row["scheduledTick"] for row in data["observations"]] != [1, 324, 340]:
        raise ValueError("Native weapon-return scenarios are incomplete")
    for row in data["observations"]:
        if row["callbackTick"] != row["scheduledTick"] + 15 or \
                not all(math.isfinite(row[key]) for key in ["scheduledTime", "callbackTime"]) or \
                abs(row["callbackTime"] - row["scheduledTime"] - 0.5) > 0.00001:
            raise ValueError("Native half-second coroutine timing changed")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--publish", type=Path)
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args()
    if args.publish and args.check:
        parser.error("choose --publish or --check")
    data = json.loads((args.publish or OUTPUT).read_text(encoding="utf-8-sig"))
    verify(data)
    expected_callers = {key: digest(path) for key, path in CALLER_SOURCES.items()}
    if args.publish:
        data["callerSourceBindings"] = expected_callers
        OUTPUT.write_text(json.dumps(data, indent=2) + "\n", encoding="utf-8", newline="\n")
    elif data.get("callerSourceBindings") != expected_callers:
        raise ValueError("Recovered weapon-return caller or attachment source changed")
    print("3 native half-second callbacks verified; caller/inventory sources bound separately")
    print("SHA-256:", digest(OUTPUT))


if __name__ == "__main__":
    main()
