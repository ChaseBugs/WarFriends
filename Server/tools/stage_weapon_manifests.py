"""Build simple weapon manifests from verified candidate bytes, never mixed production inputs."""
import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
FAMILIES = ("shotgun", "smg", "pistol", "lmg", "minigun", "sniper", "bazooka")


def digest(payload):
    return hashlib.sha256(payload).hexdigest()


def build_candidates(scene, content, bindings):
    scene_hash = digest(scene)
    stats = json.loads(content)
    if stats.get("client") != "1.4.0" or stats.get("mainSceneSha256") != scene_hash:
        raise ValueError("Weapon manifest stats use a different scene/client")
    candidates = {}
    for family in FAMILIES:
        suffix = "binding" if family == "minigun" else "bindings"
        binding_name = "recovered-" + family + "-" + suffix + ".json"
        if binding_name not in bindings:
            raise ValueError("Weapon manifest requires candidate binding: " + family)
        binding_bytes = bindings[binding_name]
        binding = json.loads(binding_bytes)
        if (binding.get("client") != "1.4.0" or binding.get("source") != "Assets/Scenes/MainScene.unity"
                or binding.get("sha256") != scene_hash):
            raise ValueError("Weapon manifest binding uses a different scene/client: " + family)
        name = family + "-content-manifest.json"
        previous = json.loads((ROOT / "Server/content" / name).read_bytes())
        if set(previous) != {"Version", "SceneRevision", "StatsRevision", "BindingsRevision"}:
            raise ValueError("Unexpected weapon manifest schema: " + family)
        if type(previous["Version"]) is not int or previous["Version"] != 1:
            raise ValueError("Unsupported weapon manifest version: " + family)
        document = {"Version": 1, "SceneRevision": scene_hash, "StatsRevision": digest(content),
                    "BindingsRevision": digest(binding_bytes)}
        candidates[name] = (json.dumps(document, indent=2) + "\n").encode()
    return candidates


def build_grenade(scene, content, candidates):
    scene_hash = digest(scene)
    inputs = {"StatsRevision": (content, "mainSceneSha256"),
              "BindingsRevision": (candidates["recovered-grenade-bindings.json"], "sha256"),
              "PosesRevision": (candidates["recovered-grenade-poses.json"], "sha256")}
    document = {"Version": 2, "SceneRevision": scene_hash}
    for field, (payload, scene_field) in inputs.items():
        source = json.loads(payload)
        if source.get("client") != "1.4.0" or source.get(scene_field) != scene_hash:
            raise ValueError("Grenade manifest input uses a different scene/client: " + field)
        document[field] = digest(payload)
    previous = json.loads((ROOT / "Server/content/grenade-content-manifest.json").read_bytes())
    if set(previous) != set(document) or type(previous["Version"]) is not int or previous["Version"] != 2:
        raise ValueError("Unexpected grenade manifest schema/version")
    return (json.dumps(document, indent=2) + "\n").encode()
