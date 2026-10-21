"""Revalidate every decoded co-op tile against unchanged native assets before rebinding provenance."""
import argparse
import json
import re
from pathlib import Path

import UnityPy
from extract_navmesh_detail import CONTENT, decode_tile, digest

SOURCE = CONTENT / "recovered-coop-navmesh-sources.json"
MANIFEST = CONTENT / "recovered-coop-navmesh-detail.json"


def encode(value):
    return json.dumps(value, separators=(",", ":"), allow_nan=False).encode()


def source_tiles(asset):
    if asset.startswith(b"%YAML"):
        text = asset.decode("utf-8-sig")
        rows = re.findall(r"^  - m_MeshData: ([0-9a-f]+)$", text, re.M)
        if not rows or text.count("m_MeshData:") != len(rows):
            raise ValueError("Incomplete source YAML tile inventory")
        return [bytes.fromhex(row) for row in rows], "hex"
    environment = UnityPy.load(asset)
    objects = [obj for obj in environment.objects if obj.type.name == "NavMeshData"]
    if len(objects) != 1:
        raise ValueError("Expected exactly one native NavMeshData object")
    tree = objects[0].read_typetree()
    return [bytes(row["m_MeshData"]) for row in tree["m_NavMeshTiles"]], "binary"


def validate_tiles(asset, document):
    payloads, encoding = source_tiles(asset)
    if not payloads or len(payloads) != len(document["tiles"]):
        raise ValueError("Decoded tile inventory differs from complete source")
    identities = set()
    for payload, recorded in zip(payloads, document["tiles"]):
        raw = payload.hex().encode() if encoding == "hex" else payload
        offset = asset.find(raw)
        if offset < 0:
            raise ValueError("Tile bytes are absent from original asset")
        expected = decode_tile(payload)
        expected.update({"sourceOffset": offset, "sourceEncoding": encoding,
                         "bytes": len(payload), "sha256": digest(payload)})
        if encode(recorded) != encode(expected):
            raise ValueError("Stored tile differs from complete source decoding")
        identity = tuple(expected["tile"])
        if identity in identities:
            raise ValueError("Duplicate native tile identity")
        identities.add(identity)


def build_document(source_bytes):
    previous_bytes = SOURCE.read_bytes()
    previous = json.loads(previous_bytes)
    candidate = json.loads(source_bytes)
    manifest = json.loads(MANIFEST.read_bytes())
    if manifest["sourceManifestSha256"] != digest(previous_bytes):
        raise ValueError("Detail manifest does not bind previous source bytes")
    if encode(previous["maps"]) != encode(candidate["maps"]):
        raise ValueError("Detail provenance refresh cannot change native assets")
    if len(candidate["maps"]) != 5 or len(manifest["maps"]) != 5:
        raise ValueError("Incomplete detail map inventory")
    for source, entry in zip(candidate["maps"], manifest["maps"]):
        filename = Path(source["packagedAsset"]).stem + ".json"
        if entry["file"] != filename or entry["sourceSha256"] != source["sha256"]:
            raise ValueError("Detail map identity differs from source")
        data = (CONTENT / "coop-navmesh-detail" / filename).read_bytes()
        asset = (CONTENT / "coop-navmesh" / source["packagedAsset"]).read_bytes()
        if digest(data) != entry["sha256"] or digest(asset) != source["sha256"]:
            raise ValueError("Detail or native asset bytes changed")
        document = json.loads(data)
        if document["source"] != source["packagedAsset"] or document["sourceSha256"] != source["sha256"]:
            raise ValueError("Decoded detail source identity changed")
        validate_tiles(asset, document)
        counts = {"tiles": len(document["tiles"]),
                  "polygons": sum(len(tile["polygons"]) for tile in document["tiles"]),
                  "detailTriangles": sum(len(tile["detailTriangles"]) for tile in document["tiles"])}
        if any(entry[key] != value for key, value in counts.items()):
            raise ValueError("Detail manifest counts do not conserve decoded geometry")
    return {**manifest, "sourceManifestSha256": digest(source_bytes)}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--check", action="store_true", help="Validate existing detail data without writes")
    parser.parse_args()
    manifest = build_document(SOURCE.read_bytes())
    print(f"Verified {sum(row['tiles'] for row in manifest['maps'])} complete source tiles; no files written")


if __name__ == "__main__":
    main()
