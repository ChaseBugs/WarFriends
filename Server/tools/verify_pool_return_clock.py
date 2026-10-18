"""Validate native pool/wait observations and retain the exact reviewed source provenance."""

import argparse
import hashlib
import json
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SOURCE_PATHS = (
    "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
    "Assets/Scripts/Assembly-CSharp/ObjectPool.cs",
    "Assets/Scripts/Assembly-CSharp/PoolableObject.cs",
)
EXPECTED = {
    (2.0, False, 0): [("scheduled", 0), ("hide-callback", 120), ("delayed-return", 150), ("finished", 300)],
    (3.0, False, 0): [("scheduled", 0), ("hide-callback", 150), ("delayed-return", 180), ("finished", 300)],
    (2.0, True, 20): [("scheduled", 0), ("forced-return", 20), ("successor-allocated", 20), ("finished", 300)],
    (2.0, True, 140): [
        ("scheduled", 0), ("hide-callback", 120), ("forced-return", 140),
        ("successor-allocated", 140), ("finished", 300),
    ],
}


def normalized_digest(path):
    source = path.read_text(encoding="utf-8-sig")
    return hashlib.sha256(source.encode("utf-8")).hexdigest()


def verify_capture(capture):
    if capture["unityVersion"] != "2018.3.0f2" or len(capture["scenarios"]) != len(EXPECTED):
        raise ValueError("Unexpected native runtime or scenario count")
    seen = set()
    for scenario in capture["scenarios"]:
        identity = (scenario["delay"], scenario["forcedReturn"], scenario["forcedReturnTick"])
        events = scenario["events"]
        if identity in seen or identity not in EXPECTED:
            raise ValueError("Duplicate or unreviewed scenario")
        seen.add(identity)
        if [(row["transition"], row["tick"]) for row in events] != EXPECTED[identity]:
            raise ValueError("Native wait/cancellation frame boundaries changed")
        if not all(row["sameObject"] is True for row in events):
            raise ValueError("The observed slot was replaced rather than reused")
        forced = scenario["forcedReturn"]
        if events[-1]["instantiated"] is not forced or events[-1]["free"] != ([] if forced else [0]):
            raise ValueError("Terminal pool ownership differs from the callback history")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--project", type=Path, required=True)
    parser.add_argument("--log", type=Path, required=True)
    parser.add_argument("--output", type=Path, required=True)
    arguments = parser.parse_args()
    log = arguments.log.read_text(encoding="utf-8-sig", errors="replace")
    if "UNITY_POOL_RETURN_CLOCK_PASSED" not in log or "Exception:" in log or "error CS" in log:
        raise ValueError("Native run did not complete cleanly")
    capture_path = arguments.project / "pool-return-clock-reference.json"
    capture = json.loads(capture_path.read_text(encoding="utf-8-sig"))
    verify_capture(capture)
    sources = []
    for relative in SOURCE_PATHS:
        active = ROOT / "Clients/ExportedProject" / relative
        digest = normalized_digest(active)
        if normalized_digest(arguments.project / relative) != digest:
            raise ValueError("Disposable source differs from the active Client: " + relative)
        sources.append({"source": relative, "normalizedUtf8LfSha256": digest})
    for name, relative in (
        ("UnityPoolReturnClockProbe.cs", "Assets/UnityPoolReturnClockProbe.cs"),
        ("UnityPoolReturnClockExport.cs", "Assets/Editor/UnityPoolReturnClockExport.cs"),
    ):
        source = ROOT / "Server/tools" / name
        digest = normalized_digest(source)
        if normalized_digest(arguments.project / relative) != digest:
            raise ValueError("The executed probe differs from its reviewed source")
        sources.append({"source": "Server/tools/" + name, "normalizedUtf8LfSha256": digest})
    capture["sources"] = sources
    arguments.output.write_text(json.dumps(capture, indent=2) + "\n", encoding="utf-8", newline="\n")
    print("PASS: four native wait/return/reuse scenarios with matching active source provenance")


if __name__ == "__main__":
    main()
