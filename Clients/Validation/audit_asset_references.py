"""Audit local IDs, GUID targets, and MonoScript files without running gameplay."""
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / 'Clients/ExportedProject/Assets'
guid_re = re.compile(r'^guid: ([a-f0-9]{32})', re.M)
id_re = re.compile(r'^--- !u!\d+ &(-?\d+)', re.M)
ref_re = re.compile(r'\{fileID: (-?\d+)(?:, guid: ([a-f0-9]{32}), type: (\d+))?\}')
block_re = re.compile(r'^--- !u!114 &(-?\d+)\n(.*?)(?=^--- !u!|\Z)', re.M | re.S)

def main():
    guids = {}
    for meta in ASSETS.rglob('*.meta'):
        match = guid_re.search(meta.read_text(encoding='utf-8-sig'))
        asset = Path(str(meta)[:-5])
        if match and asset.exists(): guids[match[1]] = asset
    documents = {}
    for path in ASSETS.rglob('*'):
        if path.suffix in {'.unity','.prefab','.asset','.mat','.anim','.controller'}:
            raw = path.read_bytes()
            if not raw.startswith(b'%YAML'): continue
            text = raw.decode('utf-8-sig')
            documents[path] = (text, set(id_re.findall(text)))
    missing = []
    broken = set()
    scripts = set()
    components = 0
    references = 0
    for path,(text,ids) in documents.items():
        relative = str(path.relative_to(ASSETS))
        for match in ref_re.finditer(text):
            pid,guid,kind = match.groups()
            if pid == '0': continue
            references += 1
            if guid:
                if guid.startswith('0000000000000000'):continue
                target = guids.get(guid)
                if target is None:
                    broken.add((relative,'missing-guid',guid,pid))
                elif target in documents and pid not in documents[target][1]:
                    broken.add((relative,'missing-external-fileID',str(target.relative_to(ASSETS)),pid))
            elif pid not in ids:
                broken.add((relative,'missing-local-fileID','',pid))
        for block in block_re.finditer(text):
            components += 1
            script = re.search(r'  m_Script: (\{[^\n]+\})',block[2])
            if script and script[1] == '{fileID: 0}':
                missing.append({'path':relative,'fileID':block[1], 'empty':block[2].split('  m_EditorClassIdentifier:')[-1].strip()==''})
            elif script:
                match = ref_re.search(script[1])
                target = guids.get(match[2]) if match else None
                if target: scripts.add(str(target.relative_to(ASSETS)))
    report = {'documents':len(documents),'components':components,'references':references,'scriptFiles':len(scripts),
              'missingScripts':missing,'brokenReferences':sorted(broken)}
    (ROOT/'Clients/Validation/asset-reference-audit.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
    print(json.dumps({k:v for k,v in report.items() if k not in {'missingScripts','brokenReferences'}},indent=2))
    print('Missing scripts:',len(missing),'Broken references:',len(broken))
    for row in sorted(broken)[:30]: print(row)

if __name__ == '__main__': main()
