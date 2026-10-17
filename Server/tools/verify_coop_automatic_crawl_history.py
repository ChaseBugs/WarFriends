"""Compare automatic return history with the nominal pose catalog without erasing its zero-phase counterexample."""

import gzip
import json
import math

from verify_coop_obstacle_fixed_steps import read_verified
from verify_coop_obstacle_gameplay_rig import ROOT, digest, require

ARTIFACT = ROOT / "Server/content/coop-automatic-crawl-history-reference.json.gz"
ARTIFACT_SHA256 = "f1486690b3f588a8fa4d574f82498978dea44a9a60e60413726f497ee256478e"
PHASE_COUNT = 17
OBSERVATION_COUNT = 13
POSITION_TOLERANCE = 1e-5
ROTATION_TOLERANCE = 1e-6
SCALE_TOLERANCE = 1e-5


def verify():
    nominal, _ = read_verified()
    require(digest(ARTIFACT) == ARTIFACT_SHA256, "Automatic return evidence bytes changed.")
    captured = json.loads(gzip.decompress(ARTIFACT.read_bytes()))
    verify_provenance(captured, nominal)
    expected = {(row["priorReturnTicks"], row["observationTick"]): row for row in nominal["samples"]}
    observed = {(row["priorReturnTicks"], row["observationTick"]): row for row in captured["samples"]}
    require(len(captured["samples"]) == len(observed) == PHASE_COUNT * OBSERVATION_COUNT,
            "Automatic history must contain every phase/observation exactly once.")
    require(observed.keys() == expected.keys(), "Automatic and nominal phase domains differ.")
    failures = {}
    matched_maximum = [0.0, 0.0, 0.0]
    for identity, row in observed.items():
        errors = compare_rigs(row["rig"], expected[identity]["rig"])
        if exceeds(errors):
            failures[identity] = errors
        else:
            matched_maximum = [max(left, right) for left, right in zip(matched_maximum, errors)]
    require(set(failures) == {(0, 0)}, "The automatic return counterexample domain changed.")
    require(failures[(0, 0)][0] > 0.03 and failures[(0, 0)][1] > 0.07,
            "The retained-fire zero-phase counterexample must remain a material pose difference.")
    print("PASS: 220 automatic-history poses match nominal source; phase 0 observation 0 remains unsupported")
    print(f"Matched maximum position/rotation/relative-scale errors: {matched_maximum}")
    print(f"Zero-phase retained-fire errors: {failures[(0, 0)]}")


def verify_provenance(captured, nominal):
    require(captured["unity"] == nominal["unity"] == "2018.3.0f2" and captured["captureRate"] == 30,
            "Automatic return observations use an unsupported runtime or clock.")
    require(captured["manuallySamplesSource"] is False and captured["seeksCrawlTime"] is False and
            captured["controllerUpdateInvoked"] is False and captured["fireWarmupFrames"] == 30 and
            captured["observedFireWarmupFrames"] == 30, "Automatic return phase semantics changed.")
    for key in ("prefabSha256", "clipSha256", "builderSha256", "probeSha256", "controllerSha256"):
        require(captured[key] == nominal[key], f"Automatic return source binding differs: {key}.")
    for key, path in {
        "exporterSha256": "Server/tools/UnityAutomaticCrawlHistoryExport.cs",
        "captureSha256": "Server/tools/UnityCoopRigFrameCapture.cs",
    }.items():
        require(captured[key] == digest(ROOT / path), f"Automatic capture helper changed: {path}.")
    require([row["priorReturnTicks"] for row in captured["origins"]] == list(range(PHASE_COUNT)),
            "Automatic crawl origins must be ordered and complete.")
    for phase, origin in enumerate(captured["origins"]):
        states = origin["rig"]["states"]
        require(len(states) == 1 and states[0]["clipName"] == "stand_up_crawl" and states[0]["weight"] == 1 and
                abs(states[0]["time"] - phase / 30) < 1e-6, "Automatic origin clock or active source clip differs.")


def compare_rigs(actual, expected):
    require(len(actual["transforms"]) == len(expected["transforms"]) == 59, "Incomplete source body/rifle rig.")
    require(len(actual["states"]) == len(expected["states"]), "Source mixer state count differs.")
    for left, right in zip(actual["states"], expected["states"]):
        require((left["clipName"], left["wrapMode"], left["layer"], left["blendMode"]) ==
                (right["clipName"], right["wrapMode"], right["layer"], right["blendMode"]),
                "Automatic history changed source mixer identities.")
        require(abs(left["time"] - right["time"]) < 1e-6 and abs(left["weight"] - right["weight"]) < 1e-6,
                "Automatic history changed source clip clocks or weights beyond float evaluation noise.")
    maximum = [0.0, 0.0, 0.0]
    for left, right in zip(actual["transforms"][1:], expected["transforms"][1:]):
        require((left["path"], left["name"]) == (right["path"], right["name"]), "Source topology changed.")
        position = math.dist(left["position"], right["position"])
        rotation = rotation_error(left["rotation"], right["rotation"])
        scale = max(abs(a - b) / max(abs(b), 1e-12) for a, b in zip(left["scale"], right["scale"]))
        maximum = [max(maximum[0], position), max(maximum[1], rotation), max(maximum[2], scale)]
    return maximum


def rotation_error(actual, expected):
    norm = math.sqrt(sum(value * value for value in actual) * sum(value * value for value in expected))
    require(math.isfinite(norm) and norm > 0, "Invalid source rotation.")
    return max(0.0, 1 - abs(sum(a * b for a, b in zip(actual, expected)) / norm))


def exceeds(errors):
    require(all(math.isfinite(value) for value in errors), "Non-finite source pose comparison.")
    return any(value > limit for value, limit in zip(errors,
               (POSITION_TOLERANCE, ROTATION_TOLERANCE, SCALE_TOLERANCE)))


if __name__ == "__main__":
    verify()
