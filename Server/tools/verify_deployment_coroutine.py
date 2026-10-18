"""Verify rendered native source coroutine phases and the exact executed source bindings."""

import argparse
import hashlib
import json
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
FLOAT_TOLERANCE = 0.00001
FRAME_SECONDS = 1 / 30
SOURCE_BINDINGS = {
    "Assets/Plugins/Assembly-CSharp-firstpass/WaitForRealSeconds.cs":
        "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/WaitForRealSeconds.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/CoroutineReturn.cs":
        "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/CoroutineReturn.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/RadicalRoutine.cs":
        "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/RadicalRoutine.cs",
    "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs":
        "Clients/ExportedProject/Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
    "Assets/UnityDeploymentCoroutineProbe.cs": "Server/tools/UnityDeploymentCoroutineProbe.cs",
    "Assets/Editor/UnityDeploymentCoroutineExport.cs": "Server/tools/UnityDeploymentCoroutineExport.cs",
}


def digest(path):
    return hashlib.sha256(path.read_text(encoding="utf-8-sig").encode("utf-8")).hexdigest()


def verify_capture(capture):
    observation = capture["observation"]
    if capture["unityVersion"] != "2018.3.0f2" or capture["graphicsDevice"] == "Null":
        raise ValueError("This phase proof requires the reviewed rendering-enabled Unity runtime")
    if observation["batchMode"] is not False or observation["coroutineResumed"] is not True:
        raise ValueError("A headless observation or readiness alone cannot prove a resumed source coroutine")
    if observation["bodyReturned"] is not True or observation["realWaitFinished"] is not True:
        raise ValueError("Both original source paths must complete")
    events = observation["events"]
    if [event["transition"] for event in events] != [
        "before-source-wait", "after-source-wait", "hide-callback", "return-callback", "observation-ended"
    ]:
        raise ValueError("The observed source callback sequence changed")
    resumed, hidden, returned = events[1:4]
    if resumed["realElapsed"] <= 0.3 or resumed["gameTime"] != 0 or resumed["timeScale"] != 0:
        raise ValueError("The original real-time coroutine did not resume during game-time pause")
    if resumed["afterCurrentUpdate"] is not True or resumed["afterCurrentLateUpdate"] is not True:
        raise ValueError("The source end-of-frame callback did not follow LateUpdate")
    for event in (hidden, returned):
        if event["afterCurrentUpdate"] is not True or event["afterCurrentLateUpdate"] is not False:
            raise ValueError("The scaled body callback did not run between Update and LateUpdate")
        if event["timeScale"] != 1:
            raise ValueError("The scaled body callback was not observed after resume")
    if not 2 - FLOAT_TOLERANCE <= hidden["gameTime"] <= 2 + FRAME_SECONDS + FLOAT_TOLERANCE:
        raise ValueError("The first scaled wait lost its source duration")
    duration = returned["gameTime"] - hidden["gameTime"]
    if not 1 - FLOAT_TOLERANCE <= duration <= 1 + FRAME_SECONDS + FLOAT_TOLERANCE:
        raise ValueError("The second scaled wait lost its independent source duration")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--project", type=Path, required=True)
    parser.add_argument("--log", type=Path, required=True)
    parser.add_argument("--output", type=Path, required=True)
    arguments = parser.parse_args()
    log = arguments.log.read_text(encoding="utf-8-sig", errors="replace")
    if "UNITY_DEPLOYMENT_COROUTINE_OBSERVED" not in log or "Exception:" in log or "error CS" in log:
        raise ValueError("Native coroutine observation did not complete cleanly")
    capture = json.loads((arguments.project / "deployment-coroutine-reference.json").read_text(encoding="utf-8"))
    verify_capture(capture)
    sources = capture["sources"]
    if len(sources) != len(SOURCE_BINDINGS) or {row["source"] for row in sources} != set(SOURCE_BINDINGS):
        raise ValueError("The complete executed source binding set changed")
    for row in sources:
        source = row["source"]
        expected = row["normalizedUtf8LfSha256"]
        if digest(arguments.project / source) != expected or digest(ROOT / SOURCE_BINDINGS[source]) != expected:
            raise ValueError("Executed and active source revisions differ: " + source)
    arguments.output.write_text(json.dumps(capture, indent=2) + "\n", encoding="utf-8", newline="\n")
    print("PASS: original rendered coroutine/body phases and six matching source revisions")


if __name__ == "__main__":
    main()
