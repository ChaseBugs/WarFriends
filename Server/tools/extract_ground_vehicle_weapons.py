"""Pin recovered ground-vehicle turret topology, cadence, projectiles and rest muzzles."""
import hashlib,json,math,re,sys
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
ASSETS=ROOT/'Clients/ExportedProject/Assets'
OUTPUT=ROOT/'Server/content/recovered-ground-vehicle-weapons.json'
VEHICLES=[
 ('ID_UNIT-HUMVEE','Humvee.prefab','AICar',(('primary','turret'),('cannon','cannon')),
  (('gunner','enemyPointVehicle'),)),
 ('ID_UNIT-TANK','Tank.prefab','Tank',(('primary','turret'),('cannon','cannon')),
  (('turret','enemyPointTurret'),('cannon','enemyPointCannon'))),
 ('ID_UNIT-BUGGY','Buggy.prefab','AICarBuggy',(('primary','turret'),('cannon','cannon')),
  (('driver','driverPoint'),('co-driver','coDriverPoint'))),
 ('ID_UNIT-TRANSPORTER','Transporter.prefab','AICarTransporter',(('primary','turret'),),
  (('co-driver','coDriverPoint'),)),
]

def direct(block,name):
 m=re.search(r'^  '+re.escape(name)+r': ?([^\r\n]*)$',block,re.M)
 if not m: raise ValueError(f'missing {name}')
 return m.group(1)
def ref(block,name):
 m=re.search(r'\{fileID: (\d+)\}',direct(block,name))
 return int(m.group(1)) if m else 0
def number(block,name): return float(direct(block,name))
def mul(a,b):
 x,y,z,w=a;X,Y,Z,W=b
 return [w*X+x*W+y*Z-z*Y,w*Y-x*Z+y*W+z*X,w*Z+x*Y-y*X+z*W,w*W-x*X-y*Y-z*Z]
def rotate(q,p): return mul(mul(q,[*p,0]),[-q[0],-q[1],-q[2],q[3]])[:3]
def vector(value):
 d={k:float(v) for k,v in re.findall(r'([xyz]): (-?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?)',value)}
 return [d[k] for k in 'xyz']
def vector2(value):
 d={k:float(v) for k,v in re.findall(r'([xy]): (-?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?)',value)}
 return [d[k] for k in 'xy']
def world(blocks,tid):
 chain=[]
 while tid:
  kind,b=blocks[tid]
  if kind!=4: raise ValueError('muzzle reference is not Transform')
  chain.append((vector(direct(b,'m_LocalPosition')),vector(direct(b,'m_LocalRotation').replace('w:','z:')) if False else None,b))
  tid=ref(b,'m_Father')
 pos=[0.,0.,0.];rot=[0.,0.,0.,1.];scale=[1.,1.,1.]
 # Object.Instantiate(prefab, position, rotation) replaces the serialized root
 # pose.  Weapon coordinates therefore have to be relative to that root, not
 # prefab-stage world coordinates.  Retain every child transform while
 # deliberately dropping the top-level Transform's local pose.
 relative_chain=list(reversed(chain))
 if not relative_chain or ref(relative_chain[0][2],'m_Father')!=0:
  raise ValueError('muzzle chain has no prefab root')
 root=relative_chain[0][2]
 if vector(direct(root,'m_LocalScale'))!=[1.,1.,1.] or direct(root,'m_LocalRotation')!='{x: 0, y: 0, z: 0, w: 1}':
  raise ValueError('unsupported prefab root scale or rotation')
 for local,_,b in relative_chain[1:]:
  qd={k:float(v) for k,v in re.findall(r'([xyzw]): (-?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?)',direct(b,'m_LocalRotation'))}
  q=[qd[k] for k in 'xyzw'];sc=vector(direct(b,'m_LocalScale'))
  off=rotate(rot,[a*c for a,c in zip(local,scale)]);pos=[a+b for a,b in zip(pos,off)]
  rot=mul(rot,q);scale=[a*b for a,b in zip(scale,sc)]
 return pos,rot

def component_position(blocks,cid):
 component=blocks[cid][1];game_object=ref(component,'m_GameObject')
 transforms=[i for i,(kind,b) in blocks.items() if kind==4 and ref(b,'m_GameObject')==game_object]
 if len(transforms)!=1: raise ValueError('passenger point has no unique transform')
 return transforms[0],world(blocks,transforms[0])[0]

def main():
 guid_to_name={}
 for meta in (ASSETS/'Scripts').rglob('*.cs.meta'):
  m=re.search(r'^guid: ([0-9a-f]{32})$',meta.read_text(encoding='utf-8-sig'),re.M)
  if m: guid_to_name[m.group(1)]=meta.name[:-8]
 out=[]
 for unit,prefab_name,root_type,roles,passenger_fields in VEHICLES:
  path=ASSETS/'GameObject'/prefab_name;raw=path.read_bytes();text=raw.decode('utf-8-sig')
  blocks={int(m.group(2)):(int(m.group(1)),m.group(3)) for m in re.finditer(r'^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',text,re.M|re.S)}
  scripts={i:guid_to_name.get(re.search(r'guid: ([0-9a-f]{32})',b).group(1),'') for i,(k,b) in blocks.items() if k==114 and 'guid:' in b}
  roots=[i for i,n in scripts.items() if n==root_type]
  if len(roots)!=1: raise ValueError(f'{prefab_name} root mismatch')
  root=blocks[roots[0]][1];role_rows=[]
  for role,field_name in roles:
   turret_id=ref(root,field_name);turret=blocks[turret_id][1];turret_type=scripts[turret_id]
   primary=ref(turret,'batchedWeapon')
   batch_ids=[primary]
   delay=0.;fake_every=0
   if turret_type=='TurretWeaponMultipleWeapons':
    tail=turret.split('  secondaryBatchedWeapons:\n',1)[1].split('  delay:',1)[0]
    batch_ids += [int(x) for x in re.findall(r'^  - \{fileID: (\d+)\}$',tail,re.M)]
    delay=number(turret,'delay');fake_every=int(number(turret,'fakeShotEvery'))
   elif turret_type=='TransporterTurret':
    tail=turret.split('  weapons:\n',1)[1]
    batch_ids=[int(x) for x in re.findall(r'^  - \{fileID: (\d+)\}$',tail,re.M)]
   elif turret_type!='TurretWeaponBasic': raise ValueError(f'unknown turret {turret_type}')
   weapons=[]
   for index,batch_id in enumerate(batch_ids):
    batch=blocks[batch_id][1]
    if scripts[batch_id]!='BatchedWeapon': raise ValueError('wrong batched weapon')
    weapon_id=ref(batch,'weapon');weapon=blocks[weapon_id][1];weapon_type=scripts[weapon_id]
    cadence_match=re.search(r'^  cadence:\r?\n(?:^    .*\r?\n)*?^    fakeValue: ([^\r\n]+)$',weapon,re.M)
    if not cadence_match: raise ValueError('missing weapon cadence')
    cadence=float(cadence_match.group(1));spawn=ref(weapon,'spawnPoint');pos,rotation=world(blocks,spawn)
    shot_offset=vector(direct(weapon,'shotOffset')) if weapon_type in ('Gun','AutomaticRifle') else [0.,0.,0.]
    offset=rotate(rotation,shot_offset);muzzle=[a+b for a,b in zip(pos,offset)]
    projectile=re.search(r'^  bulletPrefab: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}$',weapon,re.M)
    if not projectile: raise ValueError('missing vehicle projectile')
    missile=None
    if weapon_type=='Bazooka':
     game_object=ref(weapon,'m_GameObject')
     setup_ids=[i for i,(kind,candidate) in blocks.items() if kind==114 and ref(candidate,'m_GameObject')==game_object and scripts.get(i)=='MissileSetup']
     if len(setup_ids)!=1: raise ValueError('missing vehicle missile setup')
     setup=blocks[setup_ids[0]][1]
     curve_block=setup.split('  rotationProfile:\n',1)[1].split('  baseRotationMagnitude:',1)[0]
     curves=[{'time':float(t),'value':float(v),'inTangent':float(i),'outTangent':float(o)}
      for t,v,i,o in re.findall(r'    - time: ([^\r\n]+)\r?\n      value: ([^\r\n]+)\r?\n      inSlope: ([^\r\n]+)\r?\n      outSlope: ([^\r\n]+)',curve_block)]
     if not curves: raise ValueError('missing vehicle missile curve')
     damage_match=re.search(r'^  damageAmount:\r?\n(?:^    .*\r?\n)*?^    fakeValue: ([^\r\n]+)$',setup,re.M)
     if not damage_match: raise ValueError('missing vehicle missile minimum damage')
     missile={'setupComponentFileId':setup_ids[0],'speed':number(setup,'speed'),
      'minimumDamage':float(damage_match.group(1)),
      'hurtRadius':number(setup,'hurtRadius'),'deadRadius':number(setup,'deadRadius'),
      'explosionCoefficient':vector(direct(setup,'exposionCoef')),
      'additionalUpForce':number(setup,'additionalUpForce'),'stopTime':number(setup,'stopTime'),
      'missileType':int(number(setup,'missileType')),
      'curvedTrajectory':direct(setup,'curvedTrajectory')=='1',
      'rotationRange':vector2(direct(setup,'minMaxRotations')),
      'rotationProfile':curves,
      'baseRotationMagnitude':number(setup,'baseRotationMagnitude')}
    weapons.append({'batchedComponentFileId':batch_id,'weaponComponentFileId':weapon_id,
      'weaponType':weapon_type,'cadence':cadence,'spawnTransformFileId':spawn,
      'muzzlePosition':muzzle,'shotOffset':shot_offset,'projectileFileId':int(projectile.group(1)),
      'projectileGuid':projectile.group(2),'forcedFake':fake_every>0 and index>0 and index%fake_every==0,
      'missile':missile})
   role_rows.append({'role':role,'turretComponentFileId':turret_id,'turretType':turret_type,
    'aimTime':number(turret,'aimTime'),'maxShotRotation':number(turret,'maxShotRotation'),
    'useUnitTarget':direct(turret,'useUnitTarget')=='1','primaryTargetOnly':direct(turret,'primaryTargetOnly')=='1',
    'needToSeePrimaryTarget':direct(turret,'needToSeePrimaryTarget')=='1',
    'needToSeeSecondaryTarget':direct(turret,'needToSeeSecondaryTarget')=='1',
    'predictPosition':direct(turret,'predictPosition')=='1','primaryTarget':int(number(turret,'primaryTarget')),
    'serializedTargetMask':int(number(turret,'primTarget')),'secondaryDelay':delay,
    'fakeShotEvery':fake_every,'weapons':weapons})
  passengers=[]
  for role,field_name in passenger_fields:
   point_id=ref(root,field_name)
   if point_id<=0 or scripts.get(point_id)!='EnemyPointVehicle': raise ValueError('missing vehicle passenger point')
   transform_id,position=component_position(blocks,point_id)
   passengers.append({'role':role,'pointComponentFileId':point_id,
    'transformFileId':transform_id,'position':position})
  out.append({'unitId':unit,'prefab':'Assets/GameObject/'+prefab_name,
   'sha256':hashlib.sha256(raw).hexdigest(),'behaviorType':root_type,'roles':role_rows,
   'passengers':passengers})
 artifact={'version':4,'vehicles':out};serialized=json.dumps(artifact,indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if not OUTPUT.exists() or OUTPUT.read_text()!=serialized: raise ValueError('ground vehicle weapon artifact is stale')
 elif not sys.argv[1:]: OUTPUT.write_text(serialized)
 else: raise ValueError('usage: extract_ground_vehicle_weapons.py [--check]')
 print(f'{len(out)} vehicles, {sum(len(v["roles"]) for v in out)} turrets, {sum(len(r["weapons"]) for v in out for r in v["roles"])} weapons')
if __name__=='__main__':main()
