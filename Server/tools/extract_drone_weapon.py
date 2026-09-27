"""Pin source Drone gun/muzzle/projectile bindings before live combat integration."""
import hashlib,json,re,sys
from extract_ground_vehicle_weapons import ROOT,ASSETS,direct,ref,number,vector,world_transform
OUTPUT=ROOT/'Server/content/recovered-drone-weapon.json'
def extract():
 path=ASSETS/'GameObject/dronePrototype.prefab';data=path.read_bytes()
 blocks={int(m[2]):(int(m[1]),m[3]) for m in re.finditer(r'^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',data.decode('utf-8-sig'),re.M|re.S)}
 droneIds=[i for i,(kind,b) in blocks.items() if kind==114 and re.search(r'^  eliteDrone:',b,re.M)]
 if len(droneIds)!=1:raise ValueError('Drone root identity changed')
 source=blocks[droneIds[0]][1];batchId=ref(source,'weapon');batch=blocks[batchId][1]
 if 'guid: a7637fba3d3838c87126404c48361b7e' not in batch:raise ValueError('Drone batch type changed')
 weaponId=ref(batch,'weapon');weapon=blocks[weaponId][1]
 if 'guid: 1cb9d4e3bc85c63a43096be5a40016e7' not in weapon:raise ValueError('Drone AutomaticRifle type changed')
 spawn=ref(weapon,'spawnPoint');position,rotation,scale=world_transform(blocks,spawn)
 projectile=re.search(r'^  bulletPrefab: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}$',weapon,re.M)
 if not projectile:raise ValueError('Drone projectile absent')
 metas=[p for p in (ASSETS/'GameObject').glob('*.prefab.meta') if f'guid: {projectile[2]}' in p.read_text()]
 if len(metas)!=1:raise ValueError('Drone projectile unresolved')
 projectilePath=metas[0].with_suffix('');cadence=re.search(r'^  cadence:\r?\n(?:^    .*\r?\n)*?^    fakeValue: ([^\r\n]+)$',weapon,re.M)
 if not cadence:raise ValueError('Drone cadence absent')
 return {'version':1,'unitId':'ID_UNIT-DRONE','source':'Assets/GameObject/dronePrototype.prefab',
  'sha256':hashlib.sha256(data).hexdigest(),'droneComponentFileId':droneIds[0],
  'batchedComponentFileId':batchId,'weaponComponentFileId':weaponId,'weaponType':'AutomaticRifle',
  'cadence':float(cadence[1]),'fakeShotDispersion':number(batch,'fakeShotDispersion'),
  'spawnTransformFileId':spawn,'restSpawnPosition':position,'restSpawnRotation':rotation,'restSpawnScale':scale,
  'shotOffset':vector(direct(weapon,'shotOffset')),'infiniteAmmo':direct(weapon,'infiniteAmmo')=='1',
  'reloadableWeapon':direct(weapon,'reloadableWeapon')=='1','friendKill':direct(weapon,'friendKill')=='1',
  'fastBullet':direct(weapon,'fastBullet')=='1','ignoreLayersMask':int(direct(weapon,'ignoreLayersMask')),
  'projectileFileId':int(projectile[1]),'projectileGuid':projectile[2],
  'projectileSource':'Assets/'+projectilePath.relative_to(ASSETS).as_posix(),
  'projectileSha256':hashlib.sha256(projectilePath.read_bytes()).hexdigest()}
def main():
 artifact=extract();text=json.dumps(artifact,indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if not OUTPUT.exists() or OUTPUT.read_text()!=text:raise ValueError('Drone weapon artifact stale')
 elif not sys.argv[1:]:OUTPUT.write_text(text)
 else:raise ValueError('usage: extract_drone_weapon.py [--check]')
 print(f"Drone {artifact['weaponType']}, cadence {artifact['cadence']}, projectile {artifact['projectileSource']}")
if __name__=='__main__':main()
