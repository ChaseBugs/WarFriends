"""Bind recovered multiplayer barrel colliders to their Unity scene file IDs.

Run from the repository root. The output is deterministic and refuses ambiguous
positions, missing source components, or a changed scene digest.
"""
import hashlib
import json
import math
import pathlib
import re

ROOT = pathlib.Path(__file__).resolve().parents[1]
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-barrel-scene-bindings.json"
BARREL_GUID = "4574a1f55bb5e4374a0ca0812e8b012d"
DESTROYABLE_GUID = "a503568e23092a0b9255b6fcb6b62be2"
PHOTON_VIEW_GUID = "f19ea4a15c3ca43dcc180d756f7a82b3"
HEADER = re.compile(r"(?m)^--- !u!(\d+) &(\d+)\s*$")
VEC = re.compile(r"\{x: ([^,]+), y: ([^,]+), z: ([^,}]+)(?:, w: ([^}]+))?\}")


def field(body, name):
    match = re.search(r"(?m)^  " + re.escape(name) + r": (.+)$", body)
    if not match:
        raise ValueError(f"missing {name}")
    return match.group(1)


def file_id(text):
    match = re.search(r"\{fileID: (\d+)\}", text)
    if not match:
        raise ValueError(f"missing fileID in {text}")
    return int(match.group(1))


def vector(text):
    match = VEC.fullmatch(text)
    if not match:
        raise ValueError(f"invalid Unity vector: {text}")
    return tuple(float(v) for v in match.groups() if v is not None)


def multiply(a, b):
    ax, ay, az, aw = a
    bx, by, bz, bw = b
    return (aw*bx + ax*bw + ay*bz - az*by,
            aw*by - ax*bz + ay*bw + az*bx,
            aw*bz + ax*by - ay*bx + az*bw,
            aw*bw - ax*bx - ay*by - az*bz)


def rotate(q, v):
    x, y, z, w = q
    uv = (y*v[2]-z*v[1], z*v[0]-x*v[2], x*v[1]-y*v[0])
    uuv = (y*uv[2]-z*uv[1], z*uv[0]-x*uv[2], x*uv[1]-y*uv[0])
    return tuple(v[i]+2*(w*uv[i]+uuv[i]) for i in range(3))


def sections(source):
    headers = list(HEADER.finditer(source))
    return [(int(h.group(1)), int(h.group(2)), source[h.end():headers[i+1].start() if i+1<len(headers) else len(source)])
            for i, h in enumerate(headers)]


def extract(map_row):
    scene = ROOT / "Clients/ExportedProject" / map_row["source"]
    raw = scene.read_bytes()
    if hashlib.sha256(raw).hexdigest() != map_row["sha256"]:
        raise ValueError(f"scene digest changed: {scene}")
    scene_sections = sections(raw.decode("utf-8-sig"))
    objects = {sid: body for kind, sid, body in scene_sections if kind == 1}
    transforms = {}
    components = {}
    behaviours = {}
    for kind, sid, body in scene_sections:
        if kind == 4:
            transforms[sid] = (file_id(field(body, "m_GameObject")),
                               vector(field(body, "m_LocalPosition")),
                               vector(field(body, "m_LocalRotation")),
                               vector(field(body, "m_LocalScale")),
                               file_id(field(body, "m_Father")))
        elif kind in (64, 65, 135, 136):
            components.setdefault(file_id(field(body, "m_GameObject")), []).append((kind, sid, None))
        elif kind == 114:
            guid = re.search(r"guid: ([0-9a-f]{32})", field(body, "m_Script"))
            behaviours[sid] = body
            components.setdefault(file_id(field(body, "m_GameObject")), []).append((kind, sid, guid.group(1) if guid else None))
    transform_by_object = {row[0]: sid for sid, row in transforms.items()}
    cache = {}
    def world(tid):
        if tid in cache:
            return cache[tid]
        _, pos, rot, scale, parent = transforms[tid]
        if parent:
            ppos, prot, pscale = world(parent)
            moved = rotate(prot, tuple(pos[i]*pscale[i] for i in range(3)))
            pos = tuple(ppos[i]+moved[i] for i in range(3))
            rot = multiply(prot, rot)
            scale = tuple(pscale[i]*scale[i] for i in range(3))
        cache[tid] = pos, rot, scale
        return cache[tid]
    candidates = []
    for oid, parts in components.items():
        kinds = {guid for kind, _, guid in parts if kind == 114}
        if BARREL_GUID not in kinds:
            continue
        if DESTROYABLE_GUID not in kinds or oid not in objects:
            raise ValueError(f"Barrel without DestroyableObject: {scene}:{oid}")
        photon_views=[sid for kind,sid,guid in parts if kind==114 and guid==PHOTON_VIEW_GUID]
        if len(photon_views)!=1 or field(behaviours[photon_views[0]],"ownerId")!="0":
            raise ValueError(f"Barrel is not an unowned scene PhotonView: {scene}:{oid}")
        colliders = [(kind, sid) for kind, sid, _ in parts if kind in (64, 65, 135, 136)]
        if len(colliders) != 1:
            raise ValueError(f"Barrel requires one source collider: {scene}:{oid}")
        position, _, _ = world(transform_by_object[oid])
        barrel_id = next(sid for kind,sid,guid in parts if kind==114 and guid==BARREL_GUID)
        destroyable_id = next(sid for kind,sid,guid in parts if kind==114 and guid==DESTROYABLE_GUID)
        coefficient=float(field(behaviours[destroyable_id],"shotCoeficient"))
        if not math.isfinite(coefficient) or coefficient <= 0 or coefficient > 100:
            raise ValueError(f"invalid barrel shot coefficient: {scene}:{oid}")
        candidates.append((oid, colliders[0][1], barrel_id, destroyable_id,
                           coefficient, field(objects[oid], "m_Name"), position))
    rows = []
    for index, collider in enumerate(map_row["colliders"]):
        owner = collider["dynamicOwner"]
        if not owner or not owner.split("/")[-1].lower().startswith("barrel"):
            continue
        if not collider["enabled"] or not collider["active"] or collider["trigger"]:
            raise ValueError(f"inactive exported barrel: {scene}:{index}")
        position = collider["matrix"][12:15]
        matches = [(oid, cid, bid, did, coefficient) for oid, cid, bid, did, coefficient, name, candidate in candidates
                   if name == owner.split("/")[-1] and math.dist(position, candidate) < 0.001]
        if len(matches) != 1:
            raise ValueError(f"ambiguous barrel transform: {scene}:{index} {position} {matches} "
                             f"candidates={matches}")
        oid, cid, bid, did, coefficient = matches[0]
        rows.append({"colliderIndex": index, "gameObjectFileId": oid,
                     "colliderFileId": cid, "barrelFileId": bid,
                     "destroyableFileId": did, "shotCoefficient": coefficient,
                     "sourcePath": owner})
    if len(rows) != len(candidates) or len({r["gameObjectFileId"] for r in rows}) != len(rows):
        raise ValueError(f"truncated/duplicate barrel binding: {scene}")
    return {"source": map_row["source"], "sha256": map_row["sha256"], "barrels": rows}


def main():
    maps = json.loads(CONTENT.read_text(encoding="utf-8"))["maps"]
    result = {"client": "1.4.0", "maps": [extract(row) for row in maps]}
    if sum(len(m["barrels"]) for m in result["maps"]) != 29:
        raise ValueError("expected 29 source scene barrels")
    OUTPUT.write_text(json.dumps(result, indent=2) + "\n", encoding="utf-8")
    print(f"Wrote {OUTPUT}: 29 exact scene object/collider bindings")


if __name__ == "__main__":
    main()
