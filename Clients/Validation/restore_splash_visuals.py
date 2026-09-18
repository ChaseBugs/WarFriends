"""Restore splash rendering fields decoded from the matching APK, retaining export GUIDs."""
import json
import re
from pathlib import Path
import yaml

root = Path(__file__).resolve().parents[2]
assets = root / 'Clients/ExportedProject/Assets'
data = json.loads((root / 'Clients/Validation/splash-original-fields.json').read_text())
atlas = assets / 'GameObject/GuiAtlasSplash.prefab'
material = assets / 'Material/GuiAtlasSplash.mat'

def guid(path):
    return re.search(r'^guid: (\w+)', Path(str(path)+'.meta').read_text(), re.M)[1]

atlas_id = int(re.search(r'--- !u!114 &(\d+)', atlas.read_text())[1])

def convert(value, local=False):
    if isinstance(value, dict):
        if set(value) == {'x', 'y', 'width', 'height'}:
            return dict(serializedVersion=2, **value)
        if set(value) == {'m_FileID', 'm_PathID'}:
            file, path = value['m_FileID'], value['m_PathID']
            if path == 0:
                return {'fileID': 0}
            if file == 0 and not local:
                return {'fileID': path}
            if path == 4:
                return {'fileID': 2100000, 'guid': guid(material), 'type': 2}
            if path == 2914:
                return {'fileID': atlas_id, 'guid': guid(atlas), 'type': 2}
            if path == 7:
                return {'fileID': 2800000, 'guid': guid(assets / 'Texture2D/GuiAtlasSplashSmall.png'), 'type': 3}
            raise ValueError(('Unresolved reference', value))
        return {k: convert(v, local) for k,v in value.items()}
    if isinstance(value, list):
        return [convert(v, local) for v in value]
    return value

def restore(path, fields):
    source = path.read_text()
    for object_id, values in fields.items():
        # Keep the export's standard component header and script GUID.
        pattern = rf'(--- !u!114 &{object_id}\n.*?  m_EditorClassIdentifier:[^\n]*\n).*?(?=--- !u!|\Z)'
        payload = yaml.safe_dump(values, sort_keys=False, allow_unicode=True)
        payload = ''.join('  '+line+'\n' for line in payload.splitlines())
        source, count = re.subn(pattern, lambda m: m[1]+payload, source, flags=re.S)
        assert count == 1, (path, object_id)
    path.write_text(source, encoding='utf-8')

skip = {'m_GameObject', 'm_Enabled', 'm_Script', 'm_Name'}
ids = [105, 106, 108, 112, 123, 125, 137, 139]
fields = {i: convert({k:v for k,v in data[f'mainData:{i}'].items() if k not in skip}) for i in ids}
launcher = data['mainData:127']
fields[127] = convert({k:launcher[k] for k in ['chillingoLogo','ourLogo','splashes','downloadAssetsDialog','logo','splashCamera','scales']})
restore(assets / 'Scenes/SplashScene.unity', fields)
restore(atlas, {atlas_id: convert({k:v for k,v in data['sharedassets0.assets:2914'].items() if k not in skip}, True)})
print('Restored 9 scene components and the splash atlas from APK field data.')
