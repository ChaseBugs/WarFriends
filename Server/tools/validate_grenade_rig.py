"""Validate observed grenade transforms against the existing Client evidence before publication."""
import argparse
import hashlib
import json
import math
from pathlib import Path

REPOSITORY = Path(__file__).resolve().parents[2]
CONTENT = REPOSITORY / "Server/content"
CLIENT = REPOSITORY / "Clients/ExportedProject"
SCENE_HASH = "5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff"
TARGET_HASH = "f5ca429dd4d044f7ad7eea528bffcae806ce3243e5398b9b7d4ad85578b5be9d"
BINDING_HASH = "2b8e0b531a6bf46bac199218bc74440938f8d535000565eb197a2384aae7daaa"
TRANSFORM_TOLERANCE = 0.0001


def require(condition, message):
    if not condition:
        raise ValueError(message)


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def read_json(path):
    return json.loads(path.read_text(encoding="utf-8"))


def validate_transform(transform):
    require(set(transform) == {"position", "rotation", "matrix"}, "Unexpected transform fields.")
    for name, size in (("position", 3), ("rotation", 4), ("matrix", 16)):
        values = transform[name]
        require(isinstance(values, list) and len(values) == size, "Invalid transform dimensions.")
        require(all(type(value) in (int, float) and math.isfinite(value) for value in values),
                "Non-finite transform component.")
    rotation = transform["rotation"]
    require(abs(sum(value * value for value in rotation) - 1) < TRANSFORM_TOLERANCE,
            "Rotation is not a unit quaternion.")
    matrix = transform["matrix"]
    require(matrix[12:] == [0, 0, 0, 1], "Invalid affine matrix row.")
    require(all(abs(matrix[index * 4 + 3] - value) < TRANSFORM_TOLERANCE
                for index, value in enumerate(transform["position"])), "Matrix translation differs from position.")


def validate_clip(observed, previous):
    require(set(observed) == set(previous), "Clip fields changed.")
    for field in ("name", "source", "guid", "fileId", "sha256", "length"):
        require(observed[field] == previous[field], "Clip metadata changed: " + field)
    require(digest(CLIENT / observed["source"]) == observed["sha256"], "Client animation changed.")
    require(len(observed["frames"]) == len(previous["frames"]), "Frame count changed.")
    for frame, old_frame in zip(observed["frames"], previous["frames"]):
        require(set(frame) == {"seconds", "root", "weapons", "targets"}, "Unexpected frame fields.")
        require(frame["seconds"] == old_frame["seconds"], "Sample time changed.")
        require(len(frame["weapons"]) == 66 and len(frame["targets"]) == 5, "Incomplete frame.")
        for transform in [frame["root"], *frame["weapons"], *frame["targets"]]:
            validate_transform(transform)
        require([target["position"] for target in frame["targets"]] == old_frame["positions"],
                "An observed target position differs from the reviewed grenade samples.")


def validate(path):
    targets_path = CONTENT / "recovered-grenade-shot-targets.json"
    bindings_path = CONTENT / "recovered-all-weapon-bindings.json"
    require(digest(targets_path) == TARGET_HASH, "Target evidence changed.")
    require(digest(bindings_path) == BINDING_HASH, "Binding evidence changed.")
    previous = read_json(targets_path)
    bindings = read_json(bindings_path)
    observed = read_json(path)
    require(observed["schemaVersion"] == 1 and observed["clientVersion"] == "1.4.0", "Wrong schema or Client.")
    require(observed["unityVersion"] == "2018.3.0f2", "Unexpected observation Editor.")
    require(observed["sceneSha256"] == SCENE_HASH == digest(CLIENT / observed["source"]), "Scene changed.")
    require(observed["bindingArtifactSha256"] == BINDING_HASH, "Binding provenance changed.")
    require(observed["bindingSceneSha256"] == bindings["sha256"] == previous["sha256"],
            "Historical scene provenance changed.")
    require(observed["sampleRate"] == previous["sampleRate"] == 30, "Sample rate changed.")
    require(observed["matrixLayout"] == "unity-row-major", "Unexpected matrix layout.")
    require(observed["playerPath"] == previous["playerPath"], "Player path changed.")
    require(observed["targets"] == previous["targets"], "Target identities changed.")
    moving = observed["movingTargetIndex"]
    require(type(moving) is int and 0 <= moving < 5 and observed["targets"][moving]["type"] == 16,
            "Moving target identity changed.")
    rows = observed["weapons"]
    require(len(rows) == 66 and len({row["sourceId"] for row in rows}) == 66, "Incomplete weapon identities.")
    expected = {row["id"]: row for row in bindings["weapons"]}
    for index, row in enumerate(rows):
        binding = expected[row["sourceId"]]
        require(row["levelManagerIndex"] == index and row["inventoryIndex"] == binding["inventoryIndex"]
                and row["path"] == binding["weaponPath"], "Weapon binding changed.")
    require(len(observed["clips"]) == len(previous["clips"]) == 12, "Incomplete clip set.")
    for clip, old_clip in zip(observed["clips"], previous["clips"]):
        validate_clip(clip, old_clip)
    frames = sum(len(clip["frames"]) for clip in observed["clips"])
    print(f"GRENADE_RIG_VALIDATED clips=12 frames={frames} weapons=66 targets=5 sha256={digest(path)}")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("artifact", type=Path)
    validate(parser.parse_args().artifact)
