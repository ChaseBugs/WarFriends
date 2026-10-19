"""Extract the actual QuickRope root/end, distinct from the crew's rope-alignment marker."""

import hashlib
import json
import re
import sys

from extract_helicopter_crew_points import SOURCE, ROOT
from extract_ground_vehicle_weapons import ref, world_transform


OUTPUT = ROOT / "Server/content/recovered-helicopter-rope-definition.json"


def extract():
    raw = SOURCE.read_bytes()
    blocks = {int(match[2]): (int(match[1]), match[3]) for match in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", raw.decode("utf-8-sig"), re.M | re.S)}
    helicopter = blocks[11475216][1]
    rope_component = ref(helicopter, "rope")
    rope = blocks[rope_component][1]
    transforms = {ref(block, "m_GameObject"): identity for identity, (kind, block) in blocks.items() if kind == 4}
    root_transform = transforms[ref(rope, "m_GameObject")]
    end_transform = transforms[ref(rope, "ropeEnd")]
    root_position, root_rotation, root_scale = world_transform(blocks, root_transform)
    end_position, end_rotation, end_scale = world_transform(blocks, end_transform)
    if root_scale != [1, 1, 1] or end_scale != [1, 1, 1] or "  controlPoints: []" not in rope:
        raise ValueError("unsupported source rope scale or spline controls")
    spacing = re.search(r"^  jointSpacing: ([0-9.]+)$", rope, re.M)
    if not spacing or float(spacing[1]) != 0.35 or rope_component != 11471338 or root_transform != 436455:
        raise ValueError("source rope identity or spacing changed")
    return {"version": 1, "source": "Assets/GameObject/Helicopter.prefab",
            "sourceSha256": hashlib.sha256(raw).hexdigest(), "helicopterComponent": 11475216,
            "ropeComponent": rope_component, "rootTransform": root_transform, "endTransform": end_transform,
            "rootPosition": root_position, "rootRotation": root_rotation,
            "endPosition": end_position, "endRotation": end_rotation, "jointSpacing": float(spacing[1])}


if __name__ == "__main__":
    encoded = (json.dumps(extract(), indent=2) + "\n").encode()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_bytes() != encoded:
            raise ValueError("rope definition differs from recovered prefab")
    elif not sys.argv[1:]:
        OUTPUT.write_bytes(encoded)
    else:
        raise SystemExit("usage: extract_helicopter_rope.py [--check]")
