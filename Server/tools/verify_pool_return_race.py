"""Validate a rendered same-frame source return/allocation race and bind its executed sources."""

import argparse
import hashlib
import json
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SOURCES = (
    "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/WaitForRealSeconds.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/CoroutineReturn.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/RadicalRoutine.cs",
    "Assets/Scripts/Assembly-CSharp/ObjectPool.cs",
    "Assets/Scripts/Assembly-CSharp/PoolableObject.cs",
)


def digest(path):
    return hashlib.sha256(path.read_text(encoding="utf-8-sig").encode("utf-8")).hexdigest()


def verify_capture(capture):
    observation = capture["observation"]
    if capture["unityVersion"] != "2018.3.0f2" or capture["graphicsDevice"] == "Null":
        raise ValueError("The source race requires the reviewed rendering-enabled runtime")
    if observation["batchMode"] is not False or any(
        observation[key] is not True for key in ("sameFrame", "reusedBody", "aligned")
    ):
        raise ValueError("A rendered same-frame source return and reuse were not observed")
    if observation["captureRate"] != 1 or observation["alignmentMilliseconds"] != 350:
        raise ValueError("The reviewed alignment conditions changed")
    events = observation["events"]
    if [event["transition"] for event in events] != [
        "hide-callback", "deadline-aligned", "return-callback", "spawn-continuation", "allocation-finished"
    ]:
        raise ValueError("Source return/allocation order changed")
    hidden, aligned, returned, spawn, allocated = events
    if len({event["frame"] for event in events[1:]}) != 1:
        raise ValueError("The two callbacks did not compete on the same frame")
    if hidden["gameTime"] != 2 or any(event["gameTime"] != 3 for event in events[1:]):
        raise ValueError("The source scaled 2+1-second waits changed")
    if aligned["free"] != [] or returned["free"] != [0] or spawn["free"] != [0] or allocated["free"] != []:
        raise ValueError("The actual source pool did not return then consume its single index")
    if returned["afterCurrentLateUpdate"] is not False or spawn["afterCurrentLateUpdate"] is not True:
        raise ValueError("The original body and end-of-frame continuation phases changed")
    if spawn["realElapsed"] <= 0.3 or spawn["returned"] is not True:
        raise ValueError("Allocation did not follow both source readiness and the body return")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--project", type=Path, required=True)
    parser.add_argument("--log", type=Path, required=True)
    parser.add_argument("--output", type=Path, required=True)
    arguments = parser.parse_args()
    log = arguments.log.read_text(encoding="utf-8-sig", errors="replace")
    if "UNITY_POOL_RETURN_RACE_OBSERVED" not in log or "Exception:" in log or "error CS" in log:
        raise ValueError("Native source race did not complete cleanly")
    capture = json.loads((arguments.project / "pool-return-race-reference.json").read_text(encoding="utf-8"))
    verify_capture(capture)
    bindings = [(ROOT / "Clients/ExportedProject" / path, path) for path in SOURCES]
    bindings.extend((ROOT / "Server/tools" / name, relative) for name, relative in (
        ("UnityPoolReturnRaceProbe.cs", "Assets/UnityPoolReturnRaceProbe.cs"),
        ("UnityPoolReturnRaceExport.cs", "Assets/Editor/UnityPoolReturnRaceExport.cs"),
    ))
    sources = []
    for active, relative in bindings:
        source_digest = digest(active)
        if digest(arguments.project / relative) != source_digest:
            raise ValueError("Active and executed source differ: " + str(active))
        sources.append({"source": active.relative_to(ROOT).as_posix(), "normalizedUtf8LfSha256": source_digest})
    capture["sources"] = sources
    arguments.output.write_text(json.dumps(capture, indent=2) + "\n", encoding="utf-8", newline="\n")
    print("PASS: original same-frame return-before-allocation, reused source slot and eight source bindings")


if __name__ == "__main__":
    main()
