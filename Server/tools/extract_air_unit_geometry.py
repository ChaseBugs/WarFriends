"""Inventory recovered army air geometry; runtime pose/damage integration remains separate."""
import hashlib,json,re,sys,math
from pathlib import Path
from extract_ground_vehicle_weapons import ASSETS,ROOT,direct,ref,vector,world_transform,rotate

OUTPUT=ROOT/'Server/content/recovered-air-unit-geometry.json'
UNITS=[('ID_UNIT-HELICOPTER','Helicopter'),('ID_UNIT-ASSAULTHELI','assaultHelicopter'),('ID_UNIT-DRONE','dronePrototype')]

def extract(unit,name):
 path=ASSETS/'GameObject'/f'{name}.prefab';raw=path.read_bytes();text=raw.decode('utf-8-sig')
 blocks={int(m[2]):(int(m[1]),m[3]) for m in re.finditer(r'^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',text,re.M|re.S)}
 transforms={ref(b,'m_GameObject'):i for i,(kind,b) in blocks.items() if kind==4}
 roots=[i for i,(kind,b) in blocks.items() if kind==4 and ref(b,'m_Father')==0]
 if len(roots)!=1:raise ValueError('air prefab needs one root')
 components=[]
 for i,(kind,b) in blocks.items():
  if kind!=114:continue
  match=re.search(r'guid: ([0-9a-f]{32})',b)
  if not match:raise ValueError('air MonoBehaviour has no script identity')
  component={'componentFileId':i,'gameObjectFileId':ref(b,'m_GameObject'),'scriptGuid':match[1]}
  for field in ('weight','ownerDestroyableObject'):
   if re.search(r'^  '+field+r':',b,re.M):component[field]=ref(b,field) if field=='ownerDestroyableObject' else float(direct(b,field))
  components.append(component)
 shootables=[]
 for component in components:
  if component['scriptGuid']!='3cf4d7761af3ce98d7a08bebfe4e8861':continue
  b=blocks[component['componentFileId']][1]
  targets=[(int(t),int(mask)) for t,mask in re.findall(r'^  - transform: \{fileID: (\d+)\}\r?\n    type: (\d+)$',b,re.M)]
  if not targets:
   legacy=re.search(r'^  shootTargets:\r?\n(.*?)(?=^  targets:)',b,re.M|re.S)
   if legacy:targets=[(int(t),1) for t in re.findall(r'fileID: (\d+)',legacy[1])]
  if not targets:raise ValueError('air shootable has no source targets')
  shootables.append({**component,'visible':direct(b,'visible')=='1','targets':[
   {'transformFileId':t,'type':mask,'restPosition':world_transform(blocks,t)[0]} for t,mask in targets]})
 colliders=[]
 for cid,(kind,b) in blocks.items():
  if kind not in (64,65,135,136):continue
  go=ref(b,'m_GameObject');tid=transforms[go];position,rotation,scale=world_transform(blocks,tid)
  local=[0.,0.,0.] if kind==64 else vector(direct(b,'m_Center'))
  center=[a+c for a,c in zip(position,rotate(rotation,[a*c for a,c in zip(local,scale)]))]
  chain=[];cursor=tid
  while cursor:
   chain.append(cursor);cursor=ref(blocks[cursor][1],'m_Father')
  row={'colliderFileId':cid,'gameObjectFileId':go,'transformFileId':tid,'type':{64:'Mesh',65:'Box',135:'Sphere',136:'Capsule'}[kind],
   'enabled':direct(b,'m_Enabled')=='1','trigger':direct(b,'m_IsTrigger')=='1','serializedLayer':int(direct(blocks[go][1],'m_Layer')),
   'ancestorTransformFileIds':chain,'activeAncestors':all(direct(blocks[ref(blocks[t][1],'m_GameObject')][1],'m_IsActive')=='1' for t in chain),
   'restCenter':center,'restRotation':rotation,'scale':scale,'localCenter':local}
  if kind==64:
   row.update(convex=direct(b,'m_Convex')=='1',meshReference=direct(b,'m_Mesh'))
   row['hasSerializedMesh']=direct(b,'m_Mesh')!='{fileID: 0}'
  elif kind==65:row['localSize']=vector(direct(b,'m_Size'))
  else:
   row['localRadius']=float(direct(b,'m_Radius'))
   if kind==136:row.update(localHeight=float(direct(b,'m_Height')),direction=int(direct(b,'m_Direction')))
  colliders.append(row)
 if not shootables or not colliders:raise ValueError('incomplete air geometry')
 hierarchy=[]
 for go,tid in transforms.items():
  b=blocks[tid][1]
  hierarchy.append({'transformFileId':tid,'gameObjectFileId':go,'parentTransformFileId':ref(b,'m_Father'),
   'name':direct(blocks[go][1],'m_Name'),'active':direct(blocks[go][1],'m_IsActive')=='1',
   'localPosition':vector(direct(b,'m_LocalPosition')),'localScale':vector(direct(b,'m_LocalScale')),
   'localRotation':[float(v) for v in re.findall(r'[xyzw]: ([^,}]+)',direct(b,'m_LocalRotation'))]})
 return {'unitId':unit,'source':f'Assets/GameObject/{name}.prefab','sha256':hashlib.sha256(raw).hexdigest(),
  'rootTransformFileId':roots[0],'components':components,'hierarchy':hierarchy,'shootables':shootables,'colliders':colliders}

def main():
 artifact={'version':1,'client':'1.4.0','units':[extract(*u) for u in UNITS]}
 deployment_path=ROOT/'Server/content/recovered-army-deployment.json'
 deployment=json.loads(deployment_path.read_text())
 air_families=[f for f in deployment['families'] if f['isAir']]
 if {f['unitId'] for f in air_families}!={u[0] for u in UNITS}:raise ValueError('air deployment family set changed')
 artifact['deploymentSource']={'source':'Server/content/recovered-army-deployment.json','sha256':hashlib.sha256(deployment_path.read_bytes()).hexdigest(),
  'families':[{k:f[k] for k in ('unitId','behaviorFileId','behaviorType','unitType')} for f in air_families]}
 script_names={}
 for meta in [p for folder in ('Scripts','Plugins') for p in (ASSETS/folder).rglob('*.cs.meta')]:
  match=re.search(r'^guid: ([0-9a-f]{32})$',meta.read_text(encoding='utf-8-sig'),re.M)
  if match:script_names[match[1]]=meta.name[:-8]
 mesh_sources={}
 needed={re.search(r'guid: ([0-9a-f]{32})',c['meshReference'])[1] for u in artifact['units'] for c in u['colliders'] if c['type']=='Mesh' and c['hasSerializedMesh']}
 for meta in (ASSETS/'Mesh').rglob('*.meta'):
  match=re.search(r'^guid: ([0-9a-f]{32})$',meta.read_text(encoding='utf-8-sig'),re.M)
  if match and match[1] in needed:
   source=Path(str(meta)[:-5]);mesh_sources[match[1]]={'source':'Assets/'+source.relative_to(ASSETS).as_posix(),'sha256':hashlib.sha256(source.read_bytes()).hexdigest()}
 if set(mesh_sources)!=needed:raise ValueError('unresolved air collision mesh')
 artifact['meshSources']=mesh_sources
 for unit in artifact['units']:
  for component in unit['components']:
   if component['scriptGuid'] not in script_names:raise ValueError('unresolved air script '+component['scriptGuid'])
   component['scriptType']=script_names[component['scriptGuid']]
 def validate(value):
  if isinstance(value,float) and not math.isfinite(value):raise ValueError('nonfinite source geometry')
  if isinstance(value,dict):
   for v in value.values():validate(v)
  if isinstance(value,list):
   for v in value:validate(v)
 validate(artifact)
 serialized=json.dumps(artifact,indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if not OUTPUT.exists() or OUTPUT.read_text()!=serialized:raise ValueError('air geometry inventory is stale')
 elif not sys.argv[1:]:OUTPUT.write_text(serialized)
 else:raise ValueError('usage: extract_air_unit_geometry.py [--check]')
 for u in artifact['units']:print(u['unitId'],len(u['hierarchy']),'transforms',len(u['colliders']),'colliders',len(u['shootables']),'shootables')
if __name__=='__main__':main()
