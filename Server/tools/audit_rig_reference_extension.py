"""Review the added head-target nodes without deleting them from the native candidate."""
import argparse
import copy
import hashlib
import json
from pathlib import Path

CONTENT = Path(__file__).resolve().parents[1] / "content"
# Native 144-node capture, checked against all 142 previous nodes and the C# blend/composition oracle.
REVIEWED_VALUES_SHA256 = "6a51171c2171a7a86e80f364d507cab2f3638850f73a355538d2065cd3e2d8c9"
HEAD_ROOT = ("MainSceneRootNew/Player/character_assault_1/global_move/cartoon_guyHub001/"
             "cartoon_guySpineCATRigSpine1/cartoon_guySpine2/cartoon_guyHub002/"
             "cartoon_guySpine/cartoon_guyHub003")


def review(payload):
    previous = json.loads((CONTENT / "recovered-rig-blend-reference.json").read_bytes())
    current = json.loads(payload)
    poses = json.loads((CONTENT / "recovered-player-poses.json").read_bytes())
    if current["nodes"] != poses["rigNodes"]:
        raise ValueError("Native rig nodes differ from independently sampled player poses")
    old_paths = [node["path"] for node in previous["nodes"]]
    new_paths = [node["path"] for node in current["nodes"]]
    if (len(old_paths) != 142 or len(new_paths) != 144 or len(set(new_paths)) != 144
            or set(new_paths) - set(old_paths) != {HEAD_ROOT, HEAD_ROOT + "/shotTargetHead"}
            or set(old_paths) - set(new_paths)):
        raise ValueError("Rig extension differs from the reviewed head-target addition")
    indices = [new_paths.index(path) for path in old_paths]
    for old_node, index in zip(previous["nodes"], indices):
        old_parent = old_node["parent"]
        new_parent = current["nodes"][index]["parent"]
        if (None if old_parent == -1 else old_paths[old_parent]) != (
                None if new_parent == -1 else new_paths[new_parent]):
            raise ValueError("Existing rig parent changed")
    comparison = copy.deepcopy(current)
    comparison["sha256"] = previous["sha256"]
    comparison["nodes"] = previous["nodes"]
    for case in comparison["cases"]:
        for field in ("a", "b", "c", "world", "local"):
            if case[field] is not None:
                if len(case[field]) != 144:
                    raise ValueError("Native rig samples are incomplete")
                case[field] = [case[field][index] for index in indices]
    if json.dumps(comparison, sort_keys=True, allow_nan=False) != json.dumps(previous, sort_keys=True, allow_nan=False):
        raise ValueError("Previously reviewed rig samples changed")
    values = dict(current)
    values.pop("sha256")
    encoded = json.dumps(values, sort_keys=True, allow_nan=False, separators=(",", ":")).encode()
    if hashlib.sha256(encoded).hexdigest() != REVIEWED_VALUES_SHA256:
        raise ValueError("Extended rig samples differ from the reviewed native observation")
    return {"nativeSha256": hashlib.sha256(payload).hexdigest(), "existingNodes": 142, "addedNodes": 2,
            "cases": len(current["cases"]), "existingSamplesEqual": True,
            "candidateTrimmed": False, "releaseVerified": False}


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("artifact", type=Path)
    arguments = parser.parse_args()
    print(json.dumps(review(arguments.artifact.read_bytes()), indent=2))
