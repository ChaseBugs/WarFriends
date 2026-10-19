"""Decode bounded Unity VAND v16 tile geometry exported by UnityNavMeshTileExport."""

import argparse
import hashlib
import json
import math
import struct
from pathlib import Path


CONTENT = Path(__file__).resolve().parents[1] / "content"
TILE_HEADER_BYTES = 72
POLYGON_BYTES = 32
DETAIL_MESH_BYTES = 12
DETAIL_TRIANGLE_BYTES = 8
BOUNDING_NODE_BYTES = 16


def digest(payload):
    return hashlib.sha256(payload).hexdigest()


def decode_tile(payload):
    if len(payload) < TILE_HEADER_BYTES or payload[:4] != b"VAND":
        raise ValueError("missing Unity navigation tile header")
    version, tile_x, tile_z, layer = struct.unpack_from("<4i", payload, 4)
    if version != 16 or layer < 0:
        raise ValueError("unsupported Unity navigation tile identity")
    polygon_count, vertex_count, mesh_count, detail_count, triangle_count, node_count = struct.unpack_from(
        "<6i", payload, 20)
    counts = (polygon_count, vertex_count, mesh_count, detail_count, triangle_count, node_count)
    if any(count < 0 or count > 1_000_000 for count in counts) or mesh_count != polygon_count:
        raise ValueError("invalid Unity navigation tile counts")
    expected_size = (TILE_HEADER_BYTES + vertex_count * 12 + polygon_count * POLYGON_BYTES
                     + mesh_count * DETAIL_MESH_BYTES + detail_count * 12
                     + triangle_count * DETAIL_TRIANGLE_BYTES + node_count * BOUNDING_NODE_BYTES)
    if expected_size != len(payload):
        raise ValueError("Unity navigation tile layout does not conserve byte count")
    bounds = struct.unpack_from("<6f", payload, 44)
    quantization = struct.unpack_from("<f", payload, 68)[0]
    if any(not math.isfinite(value) for value in (*bounds, quantization)) or quantization <= 0:
        raise ValueError("invalid tile bounds or quantization")
    offset = TILE_HEADER_BYTES

    def read_rows(format_text, count, width):
        nonlocal offset
        rows = [list(struct.unpack_from(format_text, payload, offset + index * width)) for index in range(count)]
        offset += count * width
        return rows

    vertices = read_rows("<3f", vertex_count, 12)
    polygons = read_rows("<12H2I", polygon_count, POLYGON_BYTES)
    meshes = read_rows("<2I2H", mesh_count, DETAIL_MESH_BYTES)
    details = read_rows("<3f", detail_count, 12)
    triangles = read_rows("<4H", triangle_count, DETAIL_TRIANGLE_BYTES)
    nodes = read_rows("<6Hi", node_count, BOUNDING_NODE_BYTES)
    for point in vertices + details:
        if any(not math.isfinite(value) or abs(value) > 10000 for value in point):
            raise ValueError("non-finite or unbounded navigation vertex")
    for polygon, mesh in zip(polygons, meshes):
        vertex_total = polygon[-1]
        if not 3 <= vertex_total <= 6 or any(index >= vertex_count for index in polygon[:vertex_total]):
            raise ValueError("invalid polygon vertex range")
        vertex_base, triangle_base, detail_total, triangle_total = mesh
        if vertex_base + detail_total > detail_count or triangle_base + triangle_total > triangle_count:
            raise ValueError("detail mesh exceeds tile arrays")
        for triangle in triangles[triangle_base:triangle_base + triangle_total]:
            if any(index >= vertex_total + detail_total for index in triangle[:3]):
                raise ValueError("detail triangle exceeds polygon and detail vertex ranges")
    return {"tile": [tile_x, tile_z, layer], "bounds": list(bounds), "quantization": quantization,
            "vertices": vertices, "polygons": polygons, "detailMeshes": meshes,
            "detailVertices": details, "detailTriangles": triangles, "boundingNodes": nodes}


def extract(directory, check):
    sources = json.loads((CONTENT / "recovered-coop-navmesh-sources.json").read_text())
    output = CONTENT / "coop-navmesh-detail"
    if not check:
        output.mkdir(exist_ok=True)
    total_tiles = 0
    entries = []
    for source in sources["maps"]:
        filename = source["packagedAsset"]
        asset = (CONTENT / "coop-navmesh" / filename).read_bytes()
        if digest(asset) != source["sha256"]:
            raise ValueError("packaged navigation asset differs from pinned source")
        serialized = json.loads((directory / (Path(filename).stem + ".json")).read_text())["NavMeshData"]
        tiles = []
        for row in serialized["m_NavMeshTiles"]:
            payload = bytes(row["m_MeshData"])
            source_encoding = "hex" if asset.startswith(b"%YAML") else "binary"
            source_payload = payload.hex().encode() if source_encoding == "hex" else payload
            position = asset.find(source_payload)
            if position < 0:
                raise ValueError("exported tile bytes do not exist in original navigation asset")
            tile = decode_tile(payload)
            tile.update({"sourceOffset": position, "sourceEncoding": source_encoding,
                         "bytes": len(payload), "sha256": digest(payload)})
            tiles.append(tile)
        if not tiles or len({tuple(tile["tile"]) for tile in tiles}) != len(tiles):
            raise ValueError("missing or duplicate navigation tile identity")
        result = {"version": 1, "tileVersion": 16, "source": filename,
                  "sourceSha256": digest(asset), "buildSettings": serialized["m_NavMeshBuildSettings"],
                  "tiles": tiles}
        encoded = (json.dumps(result, separators=(",", ":"), allow_nan=False) + "\n").encode()
        target = output / (Path(filename).stem + ".json")
        if check:
            if target.read_bytes() != encoded:
                raise ValueError("decoded navigation detail artifact differs from original tiles")
        else:
            target.write_bytes(encoded)
        total_tiles += len(tiles)
        entries.append({"file": target.name, "sha256": digest(encoded), "sourceSha256": digest(asset),
                        "tiles": len(tiles), "polygons": sum(len(tile["polygons"]) for tile in tiles),
                        "detailTriangles": sum(len(tile["detailTriangles"]) for tile in tiles)})
        print(f"{filename}: {len(tiles)} source-bound tiles, artifact {digest(encoded)}")
    manifest = {"version": 1, "tileVersion": 16,
                "sourceManifestSha256": digest((CONTENT / "recovered-coop-navmesh-sources.json").read_bytes()),
                "maps": entries}
    encoded_manifest = (json.dumps(manifest, indent=2) + "\n").encode()
    manifest_path = CONTENT / "recovered-coop-navmesh-detail.json"
    if check:
        if manifest_path.read_bytes() != encoded_manifest:
            raise ValueError("navigation detail manifest differs from complete source set")
    else:
        manifest_path.write_bytes(encoded_manifest)
    print(f"Verified {total_tiles} tiles across {len(sources['maps'])} recovered maps.")


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("serialized_directory", type=Path)
    parser.add_argument("--check", action="store_true")
    arguments = parser.parse_args()
    extract(arguments.serialized_directory, arguments.check)
