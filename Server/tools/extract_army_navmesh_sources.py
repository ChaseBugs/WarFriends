"""Pin the binary Unity NavMesh asset referenced by each multiplayer scene."""

import hashlib
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
MAPS = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-army-navmesh-sources.json"
PACKAGE = ROOT / "Server/content/navmesh"


def digest(data):
    return hashlib.sha256(data).hexdigest()


def extract():
    sources = json.loads(MAPS.read_text(encoding="utf-8"))["maps"]
    if len(sources) != 5:
        raise ValueError("expected five multiplayer scenes")
    by_guid = {}
    for meta in (CLIENT / "Assets/NavMeshData").glob("*.asset.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$", meta.read_text(encoding="utf-8-sig"), re.M)
        if not match or match.group(1) in by_guid:
            raise ValueError(f"invalid NavMesh metadata: {meta}")
        by_guid[match.group(1)] = meta.with_suffix("")
    rows = []
    used = set()
    for source in sources:
        scene_path = CLIENT / source["source"]
        scene_bytes = scene_path.read_bytes()
        if digest(scene_bytes) != source["sha256"]:
            raise ValueError(f"scene changed: {scene_path}")
        scene = scene_bytes.decode("utf-8-sig")
        refs = re.findall(
            r"^  m_NavMeshData: \{fileID: 23800000, guid: ([0-9a-f]{32}), type: 2\}$",
            scene, re.M)
        if len(refs) != 1 or refs[0] not in by_guid or refs[0] in used:
            raise ValueError(f"scene has no unique baked NavMesh: {scene_path}")
        used.add(refs[0])
        asset_path = by_guid[refs[0]]
        asset_bytes = asset_path.read_bytes()
        if not 10000 <= len(asset_bytes) <= 1000000 or b"2018.3.0f2" not in asset_bytes[:80]:
            raise ValueError(f"unexpected Unity NavMesh binary: {asset_path}")
        rows.append({
            "scene": source["source"],
            "sceneSha256": source["sha256"],
            "navMeshGuid": refs[0],
            "navMeshAsset": asset_path.relative_to(CLIENT).as_posix(),
            "navMeshBytes": len(asset_bytes),
            "navMeshSha256": digest(asset_bytes),
        })
    return {"version": 1, "unityVersion": "2018.3.0f2", "maps": rows}


def main():
    encoded = (json.dumps(extract(), indent=2) + "\n").encode("utf-8")
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("NavMesh source artifact differs from extracted Client")
        for row in extract()["maps"]:
            source = CLIENT / row["navMeshAsset"]
            if (PACKAGE / source.name).read_bytes() != source.read_bytes():
                raise ValueError(f"packaged NavMesh differs from Client: {source}")
    elif sys.argv[1:]:
        raise ValueError("usage: extract_army_navmesh_sources.py [--check]")
    else:
        OUTPUT.write_bytes(encoded)
        PACKAGE.mkdir(parents=True, exist_ok=True)
        for row in extract()["maps"]:
            source = CLIENT / row["navMeshAsset"]
            (PACKAGE / source.name).write_bytes(source.read_bytes())
    print("five multiplayer scenes bound to five Unity NavMesh binaries")


if __name__ == "__main__":
    main()
