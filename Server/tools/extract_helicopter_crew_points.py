"""Extract ordered Helicopter enemy attachment slots from the recovered prefab."""
import hashlib
import json
import re
import sys
from pathlib import Path

from extract_ground_vehicle_weapons import ASSETS, ROOT, ref, world_transform

SOURCE = ASSETS / 'GameObject/Helicopter.prefab'
OUTPUT = ROOT / 'Server/content/recovered-helicopter-crew-points.json'


def extract():
    raw = SOURCE.read_bytes()
    text = raw.decode('utf-8-sig')
    blocks = {int(match[2]): (int(match[1]), match[3]) for match in re.finditer(
        r'^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)', text, re.M | re.S)}
    helicopter = blocks[11475216][1]
    section = re.search(r'^  enemyPoints:\r?\n((?:  - \{fileID: \d+\}\r?\n)+)', helicopter, re.M)
    if not section:
        raise ValueError('Helicopter crew list is absent')
    ordered = [int(value) for value in re.findall(r'fileID: (\d+)', section[1])]
    if len(ordered) != 6 or len(set(ordered)) != 6:
        raise ValueError('Expected six unique ordered Helicopter crew points')
    transforms = {ref(block, 'm_GameObject'): file_id for file_id, (kind, block) in blocks.items() if kind == 4}
    slots = []
    for index, component_id in enumerate(ordered):
        kind, block = blocks[component_id]
        if kind != 114 or ref(block, 'helicopter') != 11475216:
            raise ValueError('Crew point is not owned by source Helicopter')
        game_object = ref(block, 'm_GameObject')
        transform_id = transforms[game_object]
        rope_id = ref(block, 'ropePosition')
        if rope_id not in blocks or blocks[rope_id][0] != 4:
            raise ValueError('Crew point rope position is unresolved')
        position, rotation, _ = world_transform(blocks, transform_id)
        rope_position, _, _ = world_transform(blocks, rope_id)
        slots.append({'index': index, 'componentFileId': component_id,
                      'transformFileId': transform_id, 'ropeTransformFileId': rope_id,
                      'restPosition': position, 'restRotation': rotation,
                      'ropeRestPosition': rope_position})
    turret = ref(helicopter, 'enemyPointVehicle')
    if turret not in blocks or blocks[turret][0] != 114:
        raise ValueError('Helicopter turret point is unresolved')
    turret_transform = transforms[ref(blocks[turret][1], 'm_GameObject')]
    turret_weapon = ref(helicopter, 'turret')
    batched_weapon = ref(blocks[turret_weapon][1], 'batchedWeapon')
    weapon = ref(blocks[batched_weapon][1], 'weapon')
    muzzle_transform = ref(blocks[weapon][1], 'spawnPoint')
    if blocks[turret_weapon][0] != 114 or blocks[batched_weapon][0] != 114 or \
       blocks[weapon][0] != 114 or blocks[muzzle_transform][0] != 4:
        raise ValueError('Helicopter turret weapon chain is unresolved')
    turret_position, turret_rotation, _ = world_transform(blocks, turret_transform)
    muzzle_position, muzzle_rotation, _ = world_transform(blocks, muzzle_transform)
    return {'version': 1, 'client': '1.4.0', 'source': 'Assets/GameObject/Helicopter.prefab',
            'sha256': hashlib.sha256(raw).hexdigest(), 'helicopterComponentFileId': 11475216,
            'slots': slots, 'turretPointComponentFileId': turret,
            'turretPointTransformFileId': turret_transform, 'turretPointRestPosition': turret_position,
            'turretPointRestRotation': turret_rotation,
            'turretWeaponComponentFileId': turret_weapon,
            'turretBatchedWeaponComponentFileId': batched_weapon,
            'turretGunComponentFileId': weapon, 'turretMuzzleTransformFileId': muzzle_transform,
            'turretMuzzleRestPosition': muzzle_position, 'turretMuzzleRestRotation': muzzle_rotation}


def main():
    serialized = json.dumps(extract(), indent=2) + '\n'
    encoded = serialized.encode('utf-8')
    if sys.argv[1:] == ['--check']:
        if not OUTPUT.exists() or OUTPUT.read_bytes() != encoded:
            raise ValueError('Helicopter crew point artifact is stale')
    elif not sys.argv[1:]:
        OUTPUT.write_bytes(encoded)
    else:
        raise ValueError('usage: extract_helicopter_crew_points.py [--check]')
    print('PASS: six ordered source Helicopter crew points')


if __name__ == '__main__':
    main()
