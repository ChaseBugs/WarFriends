"""Check decoded detail surfaces against Unity samples; this does not validate surface selection."""

import json
import struct

from extract_navmesh_detail import CONTENT, decode_tile, digest


HEIGHT_TOLERANCE = 0.0001
EDGE_TOLERANCE = 0.00001


def read_triangles(name):
    decoded = json.loads((CONTENT / "coop-navmesh-detail" / f"{name}.json").read_text())
    triangles = []
    for tile in decoded["tiles"]:
        for polygon, mesh in zip(tile["polygons"], tile["detailMeshes"]):
            count = polygon[-1]
            vertex_base, triangle_base, detail_count, triangle_count = mesh
            vertices = [tile["vertices"][index] for index in polygon[:count]]
            vertices += tile["detailVertices"][vertex_base:vertex_base + detail_count]
            for triangle in tile["detailTriangles"][triangle_base:triangle_base + triangle_count]:
                triangles.append([vertices[index] for index in triangle[:3]])
    return triangles


def vertical_error(point, triangle):
    first, second, third = triangle
    horizontal_a, depth_a = second[0] - first[0], second[2] - first[2]
    horizontal_b, depth_b = third[0] - first[0], third[2] - first[2]
    horizontal_point, depth_point = point[0] - first[0], point[2] - first[2]
    denominator = horizontal_a * depth_b - depth_a * horizontal_b
    if abs(denominator) < 1e-12:
        return float("inf")
    weight_b = (horizontal_point * depth_b - depth_point * horizontal_b) / denominator
    weight_c = (horizontal_a * depth_point - depth_a * horizontal_point) / denominator
    if weight_b < -EDGE_TOLERANCE or weight_c < -EDGE_TOLERANCE or weight_b + weight_c > 1 + EDGE_TOLERANCE:
        return float("inf")
    height = first[1] + weight_b * (second[1] - first[1]) + weight_c * (third[1] - first[1])
    return abs(point[1] - height)


def validate():
    capture = json.loads((CONTENT / "recovered-helicopter-landing-offset-unity-reference.json").read_text())
    graphs = {}
    maximum_error = 0
    checked = 0
    for row in capture["rows"]:
        if not row["found"]:
            continue
        name = row["map"]
        if name not in graphs:
            graphs[name] = read_triangles(name)
        error = min(vertical_error(row["position"], triangle) for triangle in graphs[name])
        if error > HEIGHT_TOLERANCE:
            raise ValueError(f"Unity sample is absent from detail surfaces: {name}, error {error}")
        maximum_error = max(maximum_error, error)
        checked += 1
    if checked != 275:
        raise ValueError("Unity detail-surface coverage changed")
    print(f"{checked} Unity sample positions lie on decoded detail triangles; maximum height error {maximum_error:.9f}.")


def validate_decoder_guards():
    checked = 0
    for artifact in sorted((CONTENT / "coop-navmesh-detail").glob("*.json")):
        decoded = json.loads(artifact.read_text())
        tile = decoded["tiles"][0]
        asset = (CONTENT / "coop-navmesh" / decoded["source"]).read_bytes()
        start = tile["sourceOffset"]
        if tile["sourceEncoding"] == "hex":
            payload = bytes.fromhex(asset[start:start + tile["bytes"] * 2].decode())
        else:
            payload = asset[start:start + tile["bytes"]]
        if digest(payload) != tile["sha256"]:
            raise ValueError("source tile identity changed")
        reparsed = decode_tile(payload)
        if any(tile[key] != value for key, value in reparsed.items()):
            raise ValueError("stored tile fields differ from direct binary decoding")
        unknown_version = bytearray(payload)
        struct.pack_into("<i", unknown_version, 4, 17)
        invalid_count = bytearray(payload)
        struct.pack_into("<i", invalid_count, 24, -1)
        for damaged in (payload[:20], payload[:-1], unknown_version, invalid_count):
            try:
                decode_tile(damaged)
            except ValueError:
                checked += 1
                continue
            raise ValueError("malformed navigation tile was accepted")
    if checked != 20:
        raise ValueError("decoder guard coverage changed")
    print(f"{checked} malformed tile rejection checks passed across binary and YAML sources.")


if __name__ == "__main__":
    validate_decoder_guards()
    validate()
