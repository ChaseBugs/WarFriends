"""Build/install only portable networking DLLs and their pinned runtime dependencies."""
from pathlib import Path
import hashlib
import json
import shutil
import subprocess

root = Path(__file__).resolve().parents[2]
subprocess.run(['dotnet', 'build', str(root/'Server/src/War.Client/War.Client.csproj'), '-c', 'Release', '--nologo', '-v', 'minimal'], check=True)
destination = root/'Clients/ExportedProject/Assets/Plugins/WarFriends.Networking'
destination.mkdir(exist_ok=True)
files = [root/f'Server/src/{name}/bin/Release/netstandard2.0/{name}.dll' for name in ['War.Client', 'War.Shared']]
assets = json.loads((root/'Server/src/War.Shared/obj/project.assets.json').read_text())
packages = ['Google.Protobuf', 'System.Memory', 'System.Buffers', 'System.Runtime.CompilerServices.Unsafe', 'System.Numerics.Vectors']
target = next(v for k,v in assets['targets'].items() if '/' not in k)
for package in packages:
    name, info = next((n,v) for n,v in target.items() if n.split('/')[0] == package)
    runtime = next(k for k in info['runtime'] if k.endswith('.dll'))
    candidates = [Path(folder)/name.lower()/runtime for folder in assets['packageFolders']]
    files.append(next(p for p in candidates if p.is_file()))
manifest = {}
for source in files:
    dest = destination/source.name
    shutil.copyfile(source, dest)
    manifest[source.name] = hashlib.sha256(dest.read_bytes()).hexdigest()
(destination/'sdk-manifest.json').write_text(json.dumps(manifest, indent=2)+'\n')
(destination/'.gitignore').write_text('!*.dll\n')
print('Installed portable Unity SDK:', ', '.join(manifest))
