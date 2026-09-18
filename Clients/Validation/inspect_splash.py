import json
import zipfile
from pathlib import Path
import UnityPy
from UnityPy.helpers.TypeTreeGenerator import TypeTreeGenerator

root = Path(__file__).resolve().parents[2]
z = zipfile.ZipFile(root / 'WarFriends 1.4.0.apk')
env = UnityPy.Environment()
env.load_file(z.read('assets/bin/Data/mainData'), name='mainData')
env.load_file(b''.join(z.read('assets/bin/Data/sharedassets0.assets.split' + str(i)) for i in range(13)), name='sharedassets0.assets')
generator = TypeTreeGenerator('5.2.5f1')
for dll in (root / 'Clients/AuxiliaryFiles/GameAssemblies').glob('*.dll'):
    if dll.name != 'P31RestKit 1.dll':
        generator.load_dll(dll.read_bytes())
env.typetree_generator = generator

if __name__ == '__main__':
    output = {}
    for obj in env.objects:
        if obj.type.name == 'MonoBehaviour' and (obj.assets_file.name == 'mainData' or obj.path_id == 2914):
            try:
                data = obj.read_typetree()
                output[f'{obj.assets_file.name}:{obj.path_id}'] = data
            except Exception as error:
                output[f'{obj.assets_file.name}:{obj.path_id}'] = {'error': str(error)}
    (root / 'Clients/Validation/splash-original-fields.json').write_text(json.dumps(output, indent=2), encoding='utf-8')
    print('Decoded', len(output), 'components')
