"""Bind combat manifest dependencies to reviewed candidates or unchanged pinned bytes."""
import hashlib
import json
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]


def digest(payload):
    return hashlib.sha256(payload).hexdigest()


def build_package(scene, candidates, production, affected):
    manifest = json.loads(production["combat-content-manifest.json"])
    if type(manifest.get("Version")) is not int or manifest["Version"] != 13 or len(manifest) != 28:
        raise ValueError("Unexpected combat manifest schema/version")
    hashes = {}
    for name, payload in production.items():
        hashes.setdefault(digest(payload), []).append(name)
    result = dict(manifest)
    result["SceneRevision"] = digest(scene)
    retained = {}
    for field, revision in manifest.items():
        if field in ("Version", "SceneRevision"):
            continue
        matches = hashes.get(revision, [])
        if len(matches) != 1:
            raise ValueError("Combat dependency is missing or ambiguous: " + field)
        name = matches[0]
        if name in candidates:
            payload = candidates[name]
        else:
            if name in affected:
                raise ValueError("Combat dependency still requires a candidate: " + name)
            payload = production[name]
            retained[name] = payload
        result[field] = digest(payload)
    if "recovered-battle-content.json" not in candidates:
        raise ValueError("Combat manifest requires candidate stats")
    stats = json.loads(candidates["recovered-battle-content.json"])
    if stats.get("mainSceneSha256") != result["SceneRevision"]:
        raise ValueError("Combat candidate stats use a different scene")
    pool_name = "recovered-mortar-weapon-pool.json"
    if pool_name not in candidates:
        raise ValueError("Combat manifest requires candidate Mortar pool")
    pool = json.loads(candidates[pool_name])["deployment"]
    if pool["sceneRevision"] != result["SceneRevision"] or pool["revision"] != result["ArmyDeploymentRevision"]:
        raise ValueError("Combat Mortar pool does not bind candidate army/scene")
    result["Version"] = 14
    result["MortarWeaponPoolRevision"] = digest(candidates[pool_name])
    assaulter_name = "recovered-coop-assaulter-weapon.json"
    if assaulter_name not in candidates or json.loads(candidates[assaulter_name])["sceneSha256"] != result["SceneRevision"]:
        raise ValueError("Combat manifest requires same-scene Assaulter candidate")
    result["CoopAssaulterWeaponRevision"] = digest(candidates[assaulter_name])
    retained["combat-content-manifest.json"] = (json.dumps(result, indent=2) + "\n").encode()
    return retained


def build_candidates(scene, candidates):
    root = ROOT / "Server/content"
    production = {path.name: path.read_bytes() for path in root.glob("*.json")}
    audit = json.loads((ROOT / "Server/docs/main-scene-provenance-audit.json").read_bytes())
    if audit["afterSha256"] != digest(scene):
        raise ValueError("Combat manifest source audit differs")
    affected = {Path(row["path"]).name for row in audit["affectedArtifacts"]}
    return build_package(scene, candidates, production, affected)
