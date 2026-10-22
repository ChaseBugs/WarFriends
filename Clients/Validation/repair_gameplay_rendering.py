"""Repair recovered gameplay batching and keep model-swapping shields dynamic.

All changes are preflighted before publication. Mesh/texture bytes and existing
object identities/transforms are preserved. --apply writes the reviewed changes.
"""
import argparse
import hashlib
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / 'Clients/ExportedProject/Assets'
BLOCK = re.compile(r'--- !u!(\d+) &(-?\d+)\n(.*?)(?=\n--- !u!|\Z)', re.S)
EXPECTED = {
    'Aztec_Multiplayer': (216, 8), 'Aztec_Single': (192, 4),
    'City_Multiplayer': (266, 8), 'City_Single': (254, 4),
    'Desert_Multiplayer': (231, 8), 'Desert_New': (193, 4),
    'Park_Multiplayer': (315, 8), 'Park_Single': (272, 4),
    'Snow_Multiplayer': (214, 8), 'Snow_Single': (195, 4),
}
BATCH_OBJECT = '900000000'
BATCH_TRANSFORM = '900000001'
STATIC_SHIELD_FLAGS = 1 | 4  # LightmapStatic and BatchingStatic cannot own a model-swapping shield.


def guid_of(path):
    return re.search(r'^guid: (\w+)', path.read_text(), re.M)[1]


def owner_of(body):
    return re.search(r'm_GameObject: \{fileID: (\d+)', body)[1]


def batch_fields(first, count):
    return f'  m_StaticBatchInfo:\n    firstSubMesh: {first}\n    subMeshCount: {count}'


def set_batch(body, first, count, root):
    existing = re.search(r'  m_StaticBatchInfo:\n    firstSubMesh: \d+\n    subMeshCount: \d+', body)
    fields = batch_fields(first, count)
    if existing:
        body = body[:existing.start()] + fields + body[existing.end():]
    else:
        selector = re.search(r'^  m_SubsetIndices:[^\n]*', body, re.M)
        body = body[:selector.end()] + '\n' + fields + body[selector.end():]
    return re.sub(r'm_StaticBatchRoot: \{fileID: \d+\}', f'm_StaticBatchRoot: {{fileID: {root}}}', body)


def create_identity_child(parent_id, parent_body):
    def vector(field):
        text = re.search(rf'{field}: \{{([^}}]+)\}}', parent_body)[1]
        return [float(value) for value in re.findall(r': ([^,}]+)', text)]
    if vector('m_LocalRotation') != [0, 0, 0, 1] or vector('m_LocalScale') != [1, 1, 1]:
        raise ValueError('A rotated/scaled level root needs separate coordinate review')
    x, y, z = vector('m_LocalPosition')
    if [x, y, z] == [0, 0, 0]:
        return parent_id, parent_body, ''
    if BATCH_TRANSFORM not in re.findall(r'fileID: (\d+)', parent_body.split('m_Children:')[1].split('m_Father:')[0]):
        parent_body = parent_body.replace('  m_Father:', f'  - {{fileID: {BATCH_TRANSFORM}}}\n  m_Father:', 1)
    child_index = len(re.findall(r'fileID: (\d+)', parent_body.split('m_Children:')[1].split('m_Father:')[0])) - 1
    extra = f'''\n--- !u!1 &{BATCH_OBJECT}
GameObject:
  serializedVersion: 4
  m_ObjectHideFlags: 0
  m_PrefabParentObject: {{fileID: 0}}
  m_PrefabInternal: {{fileID: 0}}
  m_Component:
  - 4: {{fileID: {BATCH_TRANSFORM}}}
  m_Layer: 0
  m_Name: RecoveredStaticBatchRoot
  m_TagString: Untagged
  m_Icon: {{fileID: 0}}
  m_NavMeshLayer: 0
  m_StaticEditorFlags: 0
  m_IsActive: 1
--- !u!4 &{BATCH_TRANSFORM}
Transform:
  m_ObjectHideFlags: 0
  m_PrefabParentObject: {{fileID: 0}}
  m_PrefabInternal: {{fileID: 0}}
  m_GameObject: {{fileID: {BATCH_OBJECT}}}
  m_LocalRotation: {{x: 0, y: 0, z: 0, w: 1}}
  m_LocalPosition: {{x: {-x:.9g}, y: {-y:.9g}, z: {-z:.9g}}}
  m_LocalScale: {{x: 1, y: 1, z: 1}}
  m_Children: []
  m_Father: {{fileID: {parent_id}}}
  m_RootOrder: {child_index}
'''
    return BATCH_TRANSFORM, parent_body, extra


def repair_scene(path, metas):
    original = path.read_text()
    docs = {key: (kind, body) for kind, key, body in BLOCK.findall(original)}
    updated = {key: body for key, (kind, body) in docs.items()}
    shields = {owner_of(body): body for kind, body in docs.values()
               if kind == '114' and 'guid: ' + metas['Shield'] in body}
    renderers = {owner_of(body): (key, body) for key, (kind, body) in docs.items() if kind == '23'}
    filters = {owner_of(body): (key, body) for key, (kind, body) in docs.items() if kind == '33'}
    transforms = {key: body for key, (kind, body) in docs.items() if kind == '4'}
    go_transforms = {owner_of(body): key for key, body in transforms.items()}
    level_roots = [(key, body) for key, body in transforms.items() if 'm_Father: {fileID: 0}' in body
                   and re.search(r'm_Name: LevelRoot', docs[owner_of(body)][1])]
    if len(level_roots) != 1:
        raise ValueError('Expected one level root in ' + path.name)
    root_id, root_body = level_roots[0]
    batch_id, root_body, extra = create_identity_child(root_id, root_body)
    if BATCH_TRANSFORM in docs:
        expected_body = BLOCK.findall(extra)[1][2]
        current_body = docs[BATCH_TRANSFORM][1]
        expected_position = re.search(r'  m_LocalPosition: [^\n]+', expected_body)[0]
        normalized = re.sub(r'  m_LocalPosition: [^\n]+', expected_position, current_body)
        if normalized != expected_body:
            raise ValueError('Generated batch root changed unexpectedly')
        updated[BATCH_TRANSFORM] = expected_body
        extra = ''
    elif BATCH_OBJECT in docs:
        raise ValueError('Batch identity collision')
    updated[root_id] = root_body
    mesh_counts = {}
    manifest = []
    for owner, (key, body) in renderers.items():
        if owner in shields:
            renderer = set_batch(body, 0, 0, '0')
            updated[key] = re.sub(r'm_SubsetIndices:[^\n]*', 'm_SubsetIndices:', renderer)
            flags = int(re.search(r'm_StaticEditorFlags: (\d+)', docs[owner][1])[1])
            updated[owner] = re.sub(r'm_StaticEditorFlags: \d+',
                                    f'm_StaticEditorFlags: {flags & ~STATIC_SHIELD_FLAGS}', docs[owner][1])
            model = re.search(r'shiedModels:\s*- \{fileID: \d+, guid: (\w+)', shields[owner])[1]
            prefab = metas[model].read_text()
            mesh = re.search(r'm_Mesh: (\{[^\n]+\})', prefab)[1]
            filter_id, filter_body = filters[owner]
            updated[filter_id] = re.sub(r'm_Mesh: \{[^\n]+\}', 'm_Mesh: ' + mesh, filter_body)
            continue
        selector = re.search(r'm_SubsetIndices:([^\n]*)', body)
        if not selector or not selector[1].strip():
            continue
        packed = bytes.fromhex(selector[1].strip())
        if len(packed) % 4:
            raise ValueError('Malformed submesh selectors')
        indices = [int.from_bytes(packed[i:i + 4], 'little') for i in range(0, len(packed), 4)]
        if indices != list(range(indices[0], indices[0] + len(indices))):
            raise ValueError('Noncontiguous submesh selectors')
        mesh_guid = re.search(r'm_Mesh: .*guid: (\w+)', filters[owner][1])[1]
        if mesh_guid not in mesh_counts:
            section = metas[mesh_guid].read_text().split('  m_SubMeshes:\n', 1)[1]
            section = re.split(r'\n  m_\w+:', section, maxsplit=1)[0]
            mesh_counts[mesh_guid] = len(re.findall(r'^  - serializedVersion:', section, re.M))
        materials = body.split('  m_Materials:\n', 1)[1].split('  m_', 1)[0]
        if max(indices) >= mesh_counts[mesh_guid] or len(re.findall('fileID:', materials)) != len(indices):
            raise ValueError('Submesh/material authority mismatch')
        updated[key] = set_batch(body, indices[0], len(indices), batch_id)
        manifest.append({'RendererId': key, 'Subsets': indices, 'TransformId': go_transforms[owner]})
    expected_static, expected_shields = EXPECTED[path.stem]
    if len(manifest) != expected_static - expected_shields or len(shields) != expected_shields:
        raise ValueError('Reviewed scene inventory changed: ' + path.name)
    def object_path(transform_id):
        body = transforms[transform_id]
        parent = re.search(r'm_Father: \{fileID: (\d+)', body)[1]
        name = re.search(r'm_Name: (.*)', docs[owner_of(body)][1])[1]
        if parent == '0':
            return name
        siblings = re.findall(r'fileID: (\d+)', transforms[parent].split('m_Children:')[1].split('m_Father:')[0])
        return object_path(parent) + '/' + name + '[' + str(siblings.index(transform_id)) + ']'
    for row in manifest:
        row['Path'] = object_path(row.pop('TransformId'))
    repaired = BLOCK.sub(lambda m: f'--- !u!{m[1]} &{m[2]}\n' + updated[m[2]], original) + extra
    return repaired, {'scene': path.stem, 'batchRootId': batch_id, 'staticRenderers': manifest,
                      'shields': len(shields), 'shieldRendererIds': [key for owner, (key, body) in renderers.items() if owner in shields], 'sourceSha256': hashlib.sha256(path.read_bytes()).hexdigest()}


def repair_shield_lighting(path, renderer_ids):
    """Drop only paired bake records that override a mutable shield's vertex stream.

    Unity 5 stored a uvMesh built against the combined static mesh. Applying it to
    SwitchModel's intact/broken mesh hides the shield, even with an unlit shader.
    Keep every environment bake record and every referenced asset unchanged.
    """
    original = path.read_text()
    prefix, remaining = original.split('  m_LightmappedRendererData:\n', 1)
    data, remaining = remaining.split('  m_LightmappedRendererDataIDs:\n', 1)
    identities, suffix = remaining.split('  m_', 1)
    rows = re.findall(r'  - uvMesh:.*?(?=  - uvMesh:|\Z)', data, re.S)
    ids = re.findall(r'  - targetObject:.*?(?=  - targetObject:|\Z)', identities, re.S)
    if len(rows) != len(ids) or ''.join(rows) != data or ''.join(ids) != identities:
        raise ValueError('Lighting bake records are not one exact paired snapshot: ' + str(path))
    targets = [re.search(r'targetObject: (\d+)', identity)[1] for identity in ids]
    if len(targets) != len(set(targets)):
        raise ValueError('Duplicate lighting bake target')
    keep = [(row, identity) for row, identity, target in zip(rows, ids, targets)
            if target not in renderer_ids]
    repaired = (prefix + '  m_LightmappedRendererData:\n' + ''.join(row for row, identity in keep)
                + '  m_LightmappedRendererDataIDs:\n' + ''.join(identity for row, identity in keep)
                + '  m_' + suffix)
    return repaired, len(rows) - len(keep)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--apply', action='store_true')
    parser.add_argument('--scene', choices=list(EXPECTED))
    parser.add_argument('--manifest', type=Path)
    args = parser.parse_args()
    metas = {}
    for folder in ('Mesh', 'GameObject', 'Material'):
        for meta in (ASSETS / folder).glob('*.meta'):
            metas[guid_of(meta)] = Path(str(meta)[:-5])
    metas['Shield'] = guid_of(ASSETS / 'Scripts/Assembly-CSharp/Shield.cs.meta')
    changes = []
    reports = []
    for scene in ([args.scene] if args.scene else EXPECTED):
        path = ASSETS / 'Scenes' / (scene + '.unity')
        repaired, report = repair_scene(path, metas)
        changes.append((path, repaired, repaired != path.read_text()))
        lighting_path = ASSETS / 'Scenes' / scene / 'LightingData.asset'
        lighting, removed = repair_shield_lighting(lighting_path, report['shieldRendererIds'])
        changes.append((lighting_path, lighting, lighting != lighting_path.read_text()))
        report['removedStaleShieldBakeRecords'] = removed
        reports.append(report)
    if args.apply:
        for path, repaired, changed in changes:
            if changed:
                path.write_text(repaired, encoding='utf-8', newline='\n')
    if args.manifest:
        args.manifest.parent.mkdir(parents=True, exist_ok=True)
        args.manifest.write_text(json.dumps(reports, indent=2) + '\n')
    print(json.dumps({'scenes': len(reports), 'staticRenderers': sum(len(r['staticRenderers']) for r in reports),
                      'dynamicShields': sum(r['shields'] for r in reports),
                      'changedScenes': sum(changed for path, text, changed in changes if path.suffix == '.unity'),
                      'changedLightingAssets': sum(changed for path, text, changed in changes if path.suffix == '.asset'), 'applied': args.apply}))
    if any(c[2] for c in changes) and not args.apply:
        raise SystemExit(1)


if __name__ == '__main__':
    main()
