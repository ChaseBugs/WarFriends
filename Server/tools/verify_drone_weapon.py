"""Compare extracted Drone weapon contract with Unity's independent prefab API probe."""
import json,math,hashlib
from extract_ground_vehicle_weapons import ROOT,rotate
content=ROOT/'Server/content'
source=json.loads((content/'recovered-drone-weapon.json').read_text())
unity=json.loads((content/'unity-drone-weapon-reference.json').read_text())
for field in source:
 if field=='unitId':continue
 if field in ('restSpawnPosition','restSpawnScale','shotOffset'):
  assert math.dist(source[field],unity[field])<.0002,field
 elif field=='restSpawnRotation':
  assert abs(sum(a*b for a,b in zip(source[field],unity[field])))>.9999,field
 elif field=='cadence':assert abs(source[field]-unity[field])<1e-6,field
 else:assert source[field]==unity[field],field
for prefix in ('','projectile'):
 path=source['source' if not prefix else 'projectileSource']
 digest=source['sha256' if not prefix else 'projectileSha256']
 assert hashlib.sha256((ROOT/'Clients/ExportedProject'/path).read_bytes()).hexdigest()==digest,'current source digest'
assert len(unity['probes'])==4,'complete pose probes'
maximum=0
for probe in unity['probes']:
 predicted=[a+b+c for a,b,c in zip(probe['position'],rotate(probe['rotation'],source['restSpawnPosition']),source['shotOffset'])]
 error=math.dist(predicted,probe['muzzle']);maximum=max(maximum,error)
 assert math.isfinite(error) and error<.0002,'rotated muzzle'
print(f'PASS: Drone weapon identities/flags, 4 rotated muzzle probes; maximum error {maximum:.8f}')
