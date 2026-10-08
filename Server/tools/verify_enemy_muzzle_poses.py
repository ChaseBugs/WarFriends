"""Compare Unity muzzle samples with the recovered gun attachment chain."""

import hashlib
import json
import math
from pathlib import Path

from extract_rusher_weapon_bindings import yaml


ROOT = Path(__file__).resolve().parents[2]
CONTENT = ROOT / "Server/content"
RIFLE = ROOT / "Clients/ExportedProject/Assets/GameObject/AssaultRifleEnemy.prefab"


def multiply(left, right):
    x, y, z, w = left
    a, b, c, d = right
    return (w*a+x*d+y*c-z*b, w*b-x*c+y*d+z*a,
            w*c+x*b-y*a+z*d, w*d-x*a-y*b-z*c)


def rotate(rotation, vector):
    x, y, z = vector
    turned = multiply(multiply(rotation, (x, y, z, 0)),
                      (-rotation[0], -rotation[1], -rotation[2], rotation[3]))
    return turned[:3]


def close(first, second, tolerance=0.0002):
    return math.dist(first, second) <= tolerance


def main():
    muzzle = json.loads((CONTENT / "recovered-enemy-muzzle-poses.json").read_text())
    gun = json.loads((CONTENT / "recovered-enemy-gun-poses.json").read_text())
    weapon = json.loads((CONTENT / "recovered-coop-assaulter-weapon.json").read_text())
    _, blocks, _, _ = yaml(RIFLE)
    import re
    root = blocks[431434]
    numbers = re.search(
        r"m_LocalRotation: \{x: ([^,]+), y: ([^,]+), z: ([^,]+), w: ([^}]+)\}",
        root)
    assert numbers is not None
    rifle_rotation = tuple(float(value) for value in numbers.groups())
    assert close((sum(value * value for value in rifle_rotation),), (1,), 0.0002)

    assert muzzle["version"] == 1 and muzzle["client"] == "1.4.0"
    assert muzzle["source"] == gun["source"]
    assert muzzle["sha256"] == gun["sha256"]
    assert muzzle["sampleRate"] == gun["sampleRate"] == 30
    assert muzzle["attachmentPath"] == gun["attachmentPath"]
    assert muzzle["weapon"] == weapon["weaponPrefab"]
    assert muzzle["weaponSha256"] == weapon["weaponPrefabSha256"]
    assert hashlib.sha256(RIFLE.read_bytes()).hexdigest() == muzzle["weaponSha256"]
    assert muzzle["muzzlePath"].endswith(weapon["muzzle"]["path"])
    assert len(muzzle["clips"]) == len(gun["clips"]) == 133

    offset = weapon["muzzle"]["position"]
    muzzle_rotation = weapon["muzzle"]["rotation"]
    samples = 0
    largest_position_difference = 0.0
    for result, attachment in zip(muzzle["clips"], gun["clips"]):
        for key in ("name", "source", "guid", "fileId", "sha256", "length", "wrap"):
            assert result[key] == attachment[key]
        assert len(result["frames"]) == len(attachment["frames"])
        for frame, source in zip(result["frames"], attachment["frames"]):
            assert frame["seconds"] == source["seconds"]
            # The weapon artifact's relative() walk already includes the
            # prefab root rotation, so its offset is attachment-relative.
            rotation = source["rotation"]
            position_offset = rotate(rotation, offset)
            expected_position = [a + b for a, b in zip(source["position"], position_offset)]
            expected_rotation = multiply(rotation, muzzle_rotation)
            position_difference = math.dist(frame["position"], expected_position)
            largest_position_difference = max(largest_position_difference,
                                              position_difference)
            # Some non-Assaulter clips scale the inherited rig. The direct
            # Unity world pose remains the source for those frames.
            assert position_difference < 0.005, result["name"]
            if result["name"] in ("idle_1", "run_0", "rifle_shot", "rifle_shot_loop"):
                assert position_difference < 0.0002, result["name"]
            assert min(math.dist(frame["rotation"], expected_rotation),
                       math.dist(frame["rotation"], [-value for value in expected_rotation])) < 0.0002
            samples += 1

    print(f"PASS: {len(muzzle['clips'])} clips, {samples} Unity muzzle samples; "
          f"largest rigid-composition difference {largest_position_difference:.6f} m")


if __name__ == "__main__":
    main()
