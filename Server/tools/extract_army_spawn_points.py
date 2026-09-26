"""Pin multiplayer MapDefinition spawn collections and their source transform chains."""

import hashlib
import json
import math
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SOURCE = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-army-spawn-points.json"
MAP_GUID = "f8e8488fbe21f6c02c9eef456d27a3b9"
COLLECTION_GUID = "5d5dd785fff4ab397c02e56ac5b28692"
COLLECTIONS = ("spawnPointsCollection", "spawnPointsCollectionDrones",
               "spawnPointsCollectionAssaultHelis", "spawnPointsCollectionCars",
               "spawnPointsCollectionHelicopters")


def field(block, name):
    match = re.search(r"^  " + re.escape(name) + r": (.+)$", block, re.M)
    if not match:
        raise ValueError(f"missing {name}")
    return match.group(1)


def ref(block, name):
    return int(re.search(r"\{fileID: (\d+)\}", field(block, name)).group(1))


def vec(value):
    parts = re.findall(r"([xyzw]): (-?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?)", value)
    return [float(v) for _, v in parts]


def mul(a, b):
    x, y, z, w = a
    X, Y, Z, W = b
    return [w*X+x*W+y*Z-z*Y, w*Y-x*Z+y*W+z*X,
            w*Z+x*Y-y*X+z*W, w*W-x*X-y*Y-z*Z]


def rotate(q, p):
    result = mul(mul(q, [*p, 0]), [-q[0], -q[1], -q[2], q[3]])
    return result[:3]


def transform_chain(blocks, transform_id):
    chain = []
    current = transform_id
    while current:
        transform = blocks[current][1]
        chain.append({"fileId": current, "position": vec(field(transform, "m_LocalPosition")),
                      "rotation": vec(field(transform, "m_LocalRotation")),
                      "scale": vec(field(transform, "m_LocalScale"))})
        current = ref(transform, "m_Father")
        if len(chain) > 32:
            raise ValueError("cyclic transform")
    position = [0.0, 0.0, 0.0]
    rotation = [0.0, 0.0, 0.0, 1.0]
    scale = [1.0, 1.0, 1.0]
    for transform in reversed(chain):
        local = [a*b for a, b in zip(transform["position"], scale)]
        offset = rotate(rotation, local)
        position = [a+b for a, b in zip(position, offset)]
        rotation = mul(rotation, transform["rotation"])
        scale = [a*b for a, b in zip(scale, transform["scale"])]
    if not all(math.isfinite(x) and abs(x) < 10000 for x in position):
        raise ValueError("invalid world position")
    return chain, position


def extract(source_map, script_guid):
    path = ROOT / "Clients/ExportedProject" / source_map["source"]
    data = path.read_bytes()
    digest = hashlib.sha256(data).hexdigest()
    if digest != source_map["sha256"]:
        raise ValueError(f"map changed: {path}")
    scene = data.decode("utf-8-sig")
    blocks = {int(m.group(2)): (int(m.group(1)), m.group(3)) for m in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", scene, re.M | re.S)}
    map_ids = [i for i, (kind, block) in blocks.items()
               if kind == 114 and f"guid: {MAP_GUID}" in block]
    if len(map_ids) != 1:
        raise ValueError("expected one MapDefinition")
    map_block = blocks[map_ids[0]][1]
    points = []
    for category in COLLECTIONS:
        collection_id = ref(map_block, category)
        collection = blocks[collection_id][1]
        if f"guid: {COLLECTION_GUID}" not in collection:
            raise ValueError(f"wrong collection type {category}")
        refs = [int(v) for v in re.findall(r"^  - \{fileID: (\d+)\}$",
                                                collection.split("  spawnPoints:\n", 1)[1], re.M)]
        if not refs:
            raise ValueError(f"empty source spawn collection {category}")
        for order, point_id in enumerate(refs):
            point = blocks[point_id][1]
            guid = re.search(r"guid: ([0-9a-f]{32})", field(point, "m_Script")).group(1)
            if guid not in script_guid:
                raise ValueError("unresolved spawn component")
            unit_type = script_guid[guid]
            if not unit_type.startswith("SpawnPoint"):
                raise ValueError("unexpected spawn component")
            join_waypoint = 0
            reservation = 0
            if category in ("spawnPointsCollectionDrones", "spawnPointsCollectionAssaultHelis",
                            "spawnPointsCollectionHelicopters"):
                join_field = "wayPointToJoin" if category == "spawnPointsCollectionHelicopters" else "pointToJoin"
                join_waypoint = ref(point, join_field)
                if join_waypoint <= 0 or join_waypoint not in blocks:
                    raise ValueError("missing aerial join waypoint")
                waypoint = blocks[join_waypoint][1]
                if "guid: 65351fae930a5df16f470909621c2f6f" not in waypoint:
                    raise ValueError("wrong aerial join component")
                reservation = ref(waypoint, "path")
                if reservation <= 0 or reservation not in blocks:
                    raise ValueError("missing aerial path reservation")
                if "guid: a604c2e26b5732c5b35329d042a09950" not in blocks[reservation][1]:
                    raise ValueError("wrong aerial path component")
            elif category == "spawnPointsCollectionCars":
                reservation = point_id  # SpawnPointVehicle.usedByEntity
            game_object_id = ref(point, "m_GameObject")
            game_object = blocks[game_object_id][1]
            transform_id = int(re.search(r"^  - 4: \{fileID: (\d+)\}$", game_object, re.M).group(1))
            chain, position = transform_chain(blocks, transform_id)
            fraction = int(field(point, "mFraction"))
            if fraction not in (1, 2):
                raise ValueError("invalid spawn fraction")
            vehicle_route = None
            if category == "spawnPointsCollectionCars":
                circuit_id = ref(point, "waypointCircuit")
                target_id = ref(point, "target")
                if circuit_id <= 0 or circuit_id not in blocks or target_id <= 0 or target_id not in blocks:
                    raise ValueError("missing vehicle circuit or target")
                circuit = blocks[circuit_id][1]
                if "guid: abb157dd164c78c5a39f7e62ba27a963" not in circuit:
                    raise ValueError("wrong vehicle circuit component")
                items_text = circuit.split("    items:\n", 1)[1].split("  smoothRoute:", 1)[0]
                waypoint_ids = [int(v) for v in re.findall(r"^    - \{fileID: (\d+)\}$", items_text, re.M)]
                if len(waypoint_ids) < 2 or target_id != waypoint_ids[-1]:
                    raise ValueError("invalid vehicle waypoint target")
                waypoint_positions = []
                for waypoint_id in waypoint_ids:
                    if waypoint_id not in blocks or blocks[waypoint_id][0] != 4:
                        raise ValueError("vehicle waypoint is not a transform")
                    _, waypoint_position = transform_chain(blocks, waypoint_id)
                    waypoint_positions.append(waypoint_position)
                vehicle_route = {"circuitFileId": circuit_id, "targetTransformFileId": target_id,
                                 "smoothRoute": bool(int(field(circuit, "smoothRoute"))),
                                 "isLoop": bool(int(field(circuit, "isLoop"))),
                                 "waypointTransformFileIds": waypoint_ids,
                                 "worldPositions": waypoint_positions}
            points.append({"collection": category, "order": order, "componentFileId": point_id,
                           "gameObjectFileId": game_object_id, "transformFileId": transform_id,
                           "componentType": unit_type, "fraction": fraction,
                           "joinWaypointFileId": join_waypoint, "reservationFileId": reservation,
                           "worldPosition": position, "transformChain": chain,
                           "vehicleRoute": vehicle_route})
    if len({p["componentFileId"] for p in points}) != len(points):
        raise ValueError("duplicate source spawn component")
    return {"source": source_map["source"], "sha256": digest, "mapDefinitionFileId": map_ids[0],
            "points": points}


def main():
    source = json.loads(SOURCE.read_text(encoding="utf-8"))
    script_guid = {}
    for meta in (ASSETS / "Scripts").rglob("SpawnPoint*.cs.meta"):
        guid = re.search(r"^guid: ([0-9a-f]{32})$", meta.read_text(encoding="utf-8-sig"), re.M)
        if guid:
            script_guid[guid.group(1)] = meta.name.removesuffix(".cs.meta")
    maps = [extract(m, script_guid) for m in source["maps"]]
    artifact = {"version": 2, "maps": maps}
    serialized = json.dumps(artifact, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != serialized:
            raise ValueError("army spawn point artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(serialized, encoding="utf-8")
    else:
        raise ValueError("usage: extract_army_spawn_points.py [--check]")
    print(f"{len(maps)} maps, {sum(len(m['points']) for m in maps)} spawn points")


if __name__ == "__main__":
    main()
