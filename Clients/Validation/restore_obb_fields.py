"""Merge corrected APK+OBB MonoBehaviour payloads while retaining export identities.

The comparison export must use the matching assemblies, excluding duplicate
P31RestKit 1.dll. Native asset data and existing code are not replaced.
Run without --apply for a complete reference-checked dry run.
"""
import argparse
import hashlib
import json
import re
import zipfile
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / 'Clients/ExportedProject/Assets'
GUID = re.compile(r'guid: ([0-9a-f]{32})')
BLOCK = re.compile(r'--- !u!114 &(-?\d+)\n.*?(?=--- !u!|\Z)', re.S)
HEADER = '  m_EditorClassIdentifier:'

def main():
    parser = argparse.ArgumentParser(__doc__)
    parser.add_argument('--source', type=Path, default=Path('E:/Temp/WarFriends-obb-recovery/corrected-export/ExportedProject/Assets'))
    parser.add_argument('--apply', action='store_true')
    args = parser.parse_args()
    existing = {}
    for meta in ASSETS.rglob('*.meta'):
        match = GUID.search(meta.read_text(encoding='utf-8-sig'))
        if match:
            existing[match[1]] = meta
    remap = {}
    for meta in args.source.rglob('*.meta'):
        target = ASSETS / meta.relative_to(args.source)
        match = GUID.search(meta.read_text(encoding='utf-8-sig'))
        if target.exists() and match:
            remap[match[1]] = GUID.search(target.read_text(encoding='utf-8-sig'))[1]
        elif match and match[1] in existing:
            remap[match[1]] = match[1]
    updates = []
    count = 0
    unresolved = set()
    for source in args.source.rglob('*'):
        if source.suffix not in {'.unity', '.prefab', '.asset'}:
            continue
        target = ASSETS / source.relative_to(args.source)
        if not target.exists():
            raise ValueError('Missing target: ' + str(target))
        recovered = {m[1]: m[0] for m in BLOCK.finditer(source.read_text(encoding='utf-8-sig'))}
        if not recovered:
            continue
        original = target.read_text(encoding='utf-8-sig')
        changes = [0]
        def replace(match):
            body = recovered.get(match[1])
            if body is None:
                raise ValueError('Missing original object: '+str(target)+':'+match[1])
            if HEADER not in body or HEADER not in match[0]:
                return match[0]
            # Keep the active script GUID, object identity, and enabled state.
            old_header = match[0][:match[0].index('\n',match[0].index(HEADER))+1]
            payload = body[body.index('\n',body.index(HEADER))+1:]
            def guid_replace(g):
                mapped = remap.get(g[1], g[1])
                if mapped not in existing and not mapped.startswith('0000000000000000'):
                    unresolved.add((str(target.relative_to(ASSETS)),match[1],g[1]))
                return 'guid: ' + mapped
            payload = GUID.sub(guid_replace, payload)
            # The recovered project packages expanded scenes locally.
            if target.name == 'SplashScene.unity' and match[1] == '127':
                payload = payload.replace('  downloadOBB: 1\n','  downloadOBB: 0\n')
            merged = old_header + payload
            if merged != match[0]:
                changes[0] += 1
            return merged
        result = BLOCK.sub(replace, original)
        if result != original:
            updates.append((target, result, changes[0]))
            count += changes[0]
    if unresolved:
        raise ValueError('Unresolved recovered GUIDs: '+repr(sorted(unresolved)[:50]))
    report = {'files':len(updates), 'components':count, 'unresolvedGuids':0,
              'obbSha256':hashlib.sha256((ROOT/'main.14008.com.chillingo.warfriends.android.gplay.obb').read_bytes()).hexdigest(),
              'changes':[{ 'path':str(p.relative_to(ROOT)), 'components':n} for p,_,n in updates]}
    print(json.dumps({k:v for k,v in report.items() if k!='changes'},indent=2))
    if args.apply:
        backup = ROOT / 'Clients/Validation/before-obb-fields.zip'
        if backup.exists():
            raise ValueError('Backup already exists; do not overwrite recovery evidence')
        with zipfile.ZipFile(backup,'w',zipfile.ZIP_DEFLATED) as z:
            for path,_,_ in updates:
                z.write(path,str(path.relative_to(ROOT)))
        for path,content,_ in updates:
            path.write_text(content,encoding='utf-8',newline='\n')
        (ROOT/'Clients/Validation/obb-field-restoration.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
        print('Applied; original files archived at',backup)

if __name__ == '__main__':
    main()
