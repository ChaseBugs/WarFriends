"""Build/check the source-bound fixed-step obstacle pose catalog; it is not a runtime admission gate."""

import argparse
import gzip
import hashlib
import json

from verify_coop_obstacle_fixed_steps import CONTENT, OBSERVATIONS, PHASES, REPLAY_HASH, SOURCE_HASH, read_verified
from verify_coop_obstacle_gameplay_rig import require

OUTPUT = CONTENT / "coop-obstacle-fixed-step-pose-catalog.json.gz"


def canonical(value):
    return json.dumps(value, sort_keys=True, separators=(",", ":")).encode("utf-8")


def build():
    source, replay = read_verified()
    skeleton = [{"index": index, "path": row["path"], "name": row["name"]}
                for index, row in enumerate(source["samples"][0]["rig"]["transforms"]) if index != 0]
    samples = []
    for frame, result in zip(source["samples"], replay["cases"]):
        overrides = []
        for index, (original, basis) in enumerate(zip(frame["rig"]["transforms"], result["basis"]["transforms"])):
            if index == 0:
                continue
            require(original["path"] == skeleton[index - 1]["path"] and
                    original["name"] == skeleton[index - 1]["name"], "Source skeleton identity changed.")
            if original["position"] != basis["position"] or original["scale"] != basis["scale"]:
                overrides.append({"index": index, "position": original["position"], "scale": original["scale"]})
        clips = []
        for state in frame["rig"]["states"]:
            require(state["layer"] == 0 and state["blendMode"] == "Blend", "Unreviewed animation layer.")
            clips.append({"clipName": state["clipName"], "timeSeconds": state["time"],
                          "weight": state["weight"], "wrap": state["wrapMode"]})
        phase, tick = frame["priorReturnTicks"], frame["observationTick"]
        samples.append({"id": 1 + phase * OBSERVATIONS + tick, "priorReturnTicks": phase,
                        "observationTick": tick, "clips": clips, "overrides": overrides})
    samples.sort(key=lambda sample: sample["id"])
    require([sample["id"] for sample in samples] == list(range(1, len(samples) + 1)),
            "Catalog sample identities must be contiguous and unique.")
    catalog = {"version": 1, "client": "1.4.0", "unity": source["unity"], "captureRate": source["captureRate"],
               "sourceSha256": SOURCE_HASH, "replaySha256": REPLAY_HASH, "prefabSha256": source["prefabSha256"],
               "clipSha256": source["clipSha256"], "priorReturnPhaseCount": PHASES,
               "observationCount": OBSERVATIONS, "sampleCount": len(samples),
               "skeletonSha256": hashlib.sha256(canonical(skeleton)).hexdigest(),
               "skeleton": skeleton, "samples": samples}
    catalog["revision"] = hashlib.sha256(canonical(catalog)).hexdigest()
    return catalog


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--write", action="store_true")
    arguments = parser.parse_args()
    catalog = build()
    expected = gzip.compress(canonical(catalog), mtime=0)
    if arguments.write:
        OUTPUT.write_bytes(expected)
    require(OUTPUT.exists() and OUTPUT.read_bytes() == expected, "Regenerate the source-bound catalog with --write.")
    print("PASS: 221 deterministic pose sample identities and source-observed override rows reproduce exactly")
    print("Catalog revision:", catalog["revision"])
    print("Runtime loader/SDK/host selection remain unimplemented.")


if __name__ == "__main__":
    main()
