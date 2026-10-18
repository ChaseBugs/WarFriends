"""Retain native evidence that deployment readiness and corpse waits use different Unity clocks."""

import argparse
import hashlib
import json
import math
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SOURCES = (
    "Assets/Plugins/Assembly-CSharp-firstpass/WaitForRealSeconds.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/CoroutineReturn.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/RadicalRoutine.cs",
    "Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs",
)
FRAME_SECONDS = 1 / 30
FLOAT_TOLERANCE = 0.00001


def digest(path):
    return hashlib.sha256(path.read_text(encoding="utf-8-sig").encode("utf-8")).hexdigest()


def verify_capture(capture):
    observation = capture["observation"]
    if capture["unityVersion"] != "2018.3.0f2" or observation["hasPassed"] is not True:
        raise ValueError("Unexpected or unsuccessful native runtime observation")
    if observation["failureReason"] is not None:
        raise ValueError("The native watchdog or an assertion failed")
    events = observation["events"]
    if [event["transition"] for event in events] != [
        "scheduled-paused", "real-wait-ready-while-paused", "hide-callback", "return-callback"
    ]:
        raise ValueError("The native clock-domain callback sequence changed")
    for event in events:
        if not all(math.isfinite(event[key]) and event[key] >= 0 for key in ("gameElapsed", "realElapsed")):
            raise ValueError("Malformed native elapsed time")
    paused = events[1]
    if paused["gameElapsed"] != 0 or paused["deltaTime"] != 0 or paused["timeScale"] != 0:
        raise ValueError("The body wait was not observed under a complete game-time pause")
    if paused["realElapsed"] <= 0.3 or paused["realWaitFinished"] is not True:
        raise ValueError("Recovered real-time readiness did not complete while paused")
    if paused["hasHidden"] is not False or paused["hasReturned"] is not False:
        raise ValueError("A scaled callback ran during pause")
    hidden, returned = events[2:]
    hide_seconds = hidden["gameElapsed"]
    return_seconds = returned["gameElapsed"] - hide_seconds
    if not 2 - FLOAT_TOLERANCE <= hide_seconds <= 2 + FRAME_SECONDS + FLOAT_TOLERANCE:
        raise ValueError("Hide did not retain its source scaled-time delay")
    if not 1 - FLOAT_TOLERANCE <= return_seconds <= 1 + FRAME_SECONDS + FLOAT_TOLERANCE:
        raise ValueError("Return did not retain its separate source scaled-time delay")
    if hidden["hasHidden"] is not True or hidden["hasReturned"] is not False:
        raise ValueError("Hide and final return were combined")
    if returned["hasHidden"] is not True or returned["hasReturned"] is not True:
        raise ValueError("The final source return did not complete")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--project", type=Path, required=True)
    parser.add_argument("--log", type=Path, required=True)
    parser.add_argument("--output", type=Path, required=True)
    arguments = parser.parse_args()
    log = arguments.log.read_text(encoding="utf-8-sig", errors="replace")
    if "UNITY_DEPLOYMENT_CLOCK_DOMAINS_PASSED" not in log or "Exception:" in log or "error CS" in log:
        raise ValueError("Native clock-domain run did not complete cleanly")
    capture = json.loads((arguments.project / "deployment-clock-domain-reference.json").read_text())
    verify_capture(capture)
    bindings = [(ROOT / "Clients/ExportedProject" / name, name) for name in SOURCES]
    bindings.extend((ROOT / "Server/tools" / name, relative) for name, relative in (
        ("UnityDeploymentClockDomainProbe.cs", "Assets/UnityDeploymentClockDomainProbe.cs"),
        ("UnityDeploymentClockDomainExport.cs", "Assets/Editor/UnityDeploymentClockDomainExport.cs"),
    ))
    sources = []
    for active, relative in bindings:
        source_digest = digest(active)
        if digest(arguments.project / relative) != source_digest:
            raise ValueError("Active and executed source differ: " + str(active))
        sources.append({"source": active.relative_to(ROOT).as_posix(), "normalizedUtf8LfSha256": source_digest})
    capture["sources"] = sources
    arguments.output.write_text(json.dumps(capture, indent=2) + "\n", encoding="utf-8", newline="\n")
    print("PASS: native real-time readiness during scaled pause, separate body waits, and seven source bindings")


if __name__ == "__main__":
    main()
