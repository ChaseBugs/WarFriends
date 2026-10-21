"""Build reviewed unit availability and lane bounds from recovered Client evidence."""
import argparse
import hashlib
import json

from build_player_weapon_index_map import REPOSITORY, OBSERVATION, read_observation

CONTENT = REPOSITORY / "Server/content/recovered-battle-content.json"
CONTENT_SHA256 = "28b94d12a9ba78a8a46287cd40bf51d454afa75c036b1368561d22979e47d39a"
TARGET = REPOSITORY / "Server/content/recovered-battle-unit-rules.json"
UNIT_COUNT = 24


def build_unit(unit, sheets):
    rows = sheets[unit["sourceId"]]
    lanes = [[index for index, row in enumerate(rows) if row["TIER"] >= 0 and row["TIER"] // 10 == lane]
             for lane in range(3)]
    offsets = [0, unit["specialStartIndex"], unit["eliteStartIndex"]]
    for lane, indexes in enumerate(lanes):
        # Disabled Elite definitions can retain unused sheet rows; they never authorize Elite access.
        if offsets[lane] < 0:
            continue
        if not indexes or indexes != list(range(offsets[lane], offsets[lane] + len(indexes))):
            raise ValueError("A unit lane is missing or differs from its source offset.")
    keys = ["sourceId", "minimumPurchaseRankIndex", "startingTier", "isTutorialUnit",
            "specialStartIndex", "eliteStartIndex"]
    result = {key: unit[key] for key in keys}
    result["hasFreeAccess"] = unit["unlockRankIndex"] == 0 and unit["price"] == 0 and unit["goldPrice"] == 0
    result["laneCounts"] = [len(lane) for lane in lanes]
    return result


def build_document(content_bytes, observation_bytes=None):
    if observation_bytes is None:
        observation_bytes = OBSERVATION.read_bytes()
    observed = read_observation(observation_bytes)
    sheets = {sheet["type"]: sheet["rows"] for sheet in json.loads(content_bytes)["sheets"]}
    units = [build_unit(unit, sheets) for unit in observed["units"]]
    if len(units) != UNIT_COUNT or len({unit["sourceId"] for unit in units}) != UNIT_COUNT:
        raise ValueError("The complete unique source unit set is required.")
    result = {"schemaVersion": 1, "observationSha256": hashlib.sha256(observation_bytes).hexdigest(),
              "sheetArtifactSha256": hashlib.sha256(content_bytes).hexdigest(), "units": units}
    return result


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--write", action="store_true")
    options = parser.parse_args()
    content_bytes = CONTENT.read_bytes()
    if hashlib.sha256(content_bytes).hexdigest() != CONTENT_SHA256:
        raise ValueError("The reviewed source sheets changed.")
    result = build_document(content_bytes)
    expected = (json.dumps(result, indent=2) + "\n").encode("utf-8")
    if options.write:
        TARGET.write_bytes(expected)
    elif not TARGET.exists() or TARGET.read_bytes() != expected:
        raise ValueError("The unit rules differ; review the evidence before regenerating.")
    print("PASS: 24 source unit ownership rules and contiguous lane bounds")
    print("Unit rules SHA-256:", hashlib.sha256(expected).hexdigest())


if __name__ == "__main__":
    main()
