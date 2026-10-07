"""Pin the baked NavMesh assets used by all five co-op mission scenes."""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
MISSIONS = ROOT / "Server/content/recovered-mission-catalog.json"
OUTPUT = ROOT / "Server/content/recovered-coop-navmesh-sources.json"
PACKAGE = ROOT / "Server/content/coop-navmesh"


def digest(data):
    return hashlib.sha256(data).hexdigest()


def extract():
    missions = json.loads(MISSIONS.read_text(encoding="utf-8"))
    maps = missions["maps"]
    if len(maps) != 5:
        raise ValueError("expected five recovered co-op scenes")
    by_guid = {}
    for meta in (CLIENT / "Assets/NavMeshData").glob("*.asset.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$",
                          meta.read_text(encoding="utf-8-sig"), re.M)
        if not match or match.group(1) in by_guid:
            raise ValueError(f"invalid NavMesh metadata: {meta}")
        by_guid[match.group(1)] = meta.with_suffix("")

    rows = []
    used = set()
    for stage, source in enumerate(maps, start=1):
        if source["stage"] != stage:
            raise ValueError("co-op scene stages are not ordered")
        scene_path = CLIENT / "Assets/Scenes" / (source["scene"] + ".unity")
        scene_bytes = scene_path.read_bytes()
        if digest(scene_bytes) != source["sceneSha256"]:
            raise ValueError(f"co-op scene changed: {scene_path}")
        references = re.findall(
            r"^  m_NavMeshData: \{fileID: 23800000, guid: ([0-9a-f]{32}), type: 2\}$",
            scene_bytes.decode("utf-8-sig"), re.M)
        if len(references) != 1 or references[0] not in by_guid or references[0] in used:
            raise ValueError(f"co-op scene has no unique baked NavMesh: {scene_path}")
        used.add(references[0])
        asset_path = by_guid[references[0]]
        asset_bytes = asset_path.read_bytes()
        if not 10000 <= len(asset_bytes) <= 1000000:
            raise ValueError(f"unexpected Unity NavMesh asset size: {asset_path}")
        if asset_bytes.startswith(b"%YAML 1.1"):
            if b"NavMeshData:\n" not in asset_bytes[:100] or \
                    b"  m_NavMeshTiles:\n" not in asset_bytes or \
                    b"  m_NavMeshParams:\n" not in asset_bytes:
                raise ValueError(f"incomplete YAML NavMesh tiles: {asset_path}")
            asset_format = "unity-yaml-navmesh-tiles"
        elif b"2018.3.0f2" in asset_bytes[:80]:
            asset_format = "unity-binary-2018"
        else:
            raise ValueError(f"unknown Unity NavMesh format: {asset_path}")
        rows.append({
            "stage": stage,
            "scene": source["scene"],
            "sceneSha256": source["sceneSha256"],
            "navMeshGuid": references[0],
            "sourceAsset": asset_path.relative_to(CLIENT).as_posix(),
            "packagedAsset": asset_path.name,
            "format": asset_format,
            "bytes": len(asset_bytes),
            "sha256": digest(asset_bytes),
        })
    return {
        "version": 1,
        "missionSourceSha256": missions["sourceSha256"],
        "maps": rows,
    }


def main():
    manifest = extract()
    encoded = (json.dumps(manifest, indent=2) + "\n").encode("utf-8")
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("co-op NavMesh manifest differs from the Client")
        for row in manifest["maps"]:
            source = CLIENT / row["sourceAsset"]
            if (PACKAGE / row["packagedAsset"]).read_bytes() != source.read_bytes():
                raise ValueError(f"packaged co-op NavMesh differs: {source}")
    elif not sys.argv[1:]:
        OUTPUT.write_bytes(encoded)
        PACKAGE.mkdir(parents=True, exist_ok=True)
        for row in manifest["maps"]:
            source = CLIENT / row["sourceAsset"]
            (PACKAGE / row["packagedAsset"]).write_bytes(source.read_bytes())
    else:
        raise SystemExit("usage: extract_coop_navmesh_sources.py [--check]")
    print("five co-op scenes bound to five baked Unity NavMesh assets")


if __name__ == "__main__":
    main()
