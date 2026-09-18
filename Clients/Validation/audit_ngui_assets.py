"""Check recovered NGUI sprite names against their serialized atlas definitions."""
import json
import re
from pathlib import Path
import yaml

ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT/'Clients/ExportedProject/Assets'
GUID = re.compile(r'^guid: (\w+)',re.M)
BLOCK = re.compile(r'^--- !u!114 &(-?\d+)\n(.*?)(?=^--- !u!|\Z)',re.M|re.S)
metas = {GUID.search(p.read_text(encoding='utf-8-sig'))[1]:Path(str(p)[:-5]) for p in ASSETS.rglob('*.meta') if GUID.search(p.read_text(encoding='utf-8-sig'))}
atlas_guid = next(g for g,p in metas.items() if p.name == 'UIAtlas.cs')
sprite_guid = next(g for g,p in metas.items() if p.name == 'UISprite.cs')
atlases = {}
sprites = []
for p in ASSETS.rglob('*'):
    if p.suffix not in {'.unity','.prefab','.asset'}:continue
    raw = p.read_bytes()
    if not raw.startswith(b'%YAML'):continue
    for match in BLOCK.finditer(raw.decode('utf-8-sig')):
        script = re.search(r'  m_Script: .*guid: (\w+)',match[2])
        if not script or script[1] not in {atlas_guid,sprite_guid}:continue
        data = yaml.load(match[2],Loader=yaml.CSafeLoader)['MonoBehaviour']
        key = (p,int(match[1]))
        if script[1] == atlas_guid:atlases[key] = data
        else:sprites.append((key,data))

def resolve(path,pointer):
    return (metas[pointer['guid']] if pointer.get('guid') else path,pointer['fileID'])

def names(key,seen=None):
    seen = set() if seen is None else seen
    if key in seen:raise ValueError('Atlas replacement cycle '+str(key))
    seen.add(key)
    atlas = atlases[key]
    replacement = atlas.get('mReplacement',{})
    if replacement.get('fileID',0):return names(resolve(key[0],replacement),seen)
    return {s['name'] for s in atlas.get('sprites',[])}

missing = []
unassigned = 0
checked = 0
for (path,pid),sprite in sprites:
    atlas = sprite.get('mAtlas',{})
    name = sprite.get('mSpriteName')
    if not atlas.get('fileID',0) or not name:
        unassigned += 1
        continue
    checked += 1
    if name not in names(resolve(path,atlas)):
        missing.append(dict(path=str(path.relative_to(ASSETS)),fileID=pid,spriteName=name))
report = dict(atlases=len(atlases),sprites=len(sprites),checked=checked,unassignedOrDynamic=unassigned,missing=missing)
(ROOT/'Clients/Validation/ngui-asset-audit.json').write_text(json.dumps(report,indent=2),encoding='utf-8')
print(json.dumps(report,indent=2))
