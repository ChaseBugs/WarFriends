"""Compare independent YAML and Unity rest geometry, without claiming runtime pose equivalence."""
import json,math,hashlib,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
ASSETS=ROOT/'Clients/ExportedProject'
CONTENT=ROOT/'Server/content'
def require(value,message):
 if not value:raise ValueError(message)
def point(a,b):
 require(len(a)==len(b)==3 and all(math.isfinite(v) for v in a+b),'invalid vector')
 require(math.dist(a,b)<.0002,'Unity/YAML air geometry differs: '+str((a,b)))
def main():
 source=json.loads((CONTENT/'recovered-air-unit-geometry.json').read_text())
 unity=json.loads((CONTENT/'recovered-air-unit-unity-geometry.json').read_text())
 require(source['version']==1 and source['client']==unity['client']=='1.4.0','air version mismatch')
 require(len(source['units'])==len(unity['units'])==3,'air source unit set changed')
 units={u['source']:u for u in unity['units']};require(len(units)==3,'duplicate Unity unit')
 total=0
 for u in source['units']:
  actual=units[u['source']]
  require(u['sha256']==actual['sha256']==hashlib.sha256((ASSETS/u['source']).read_bytes()).hexdigest(),'air prefab digest mismatch')
  colliders={c['componentFileId']:c for c in actual['colliders']}
  require(len(colliders)==len(actual['colliders'])==len(u['colliders']),'air collider cardinality mismatch')
  for c in u['colliders']:
   a=colliders[c['colliderFileId']];total+=1
   require(a['type']==c['type']+'Collider' and a['enabled']==c['enabled'] and a['trigger']==c['trigger'],'air collider identity/flags mismatch')
   point(c['restCenter'],a['center']);point(c['scale'],a['scale'])
   q=c['restRotation'];Q=a['rotation']
   require(len(q)==len(Q)==4 and all(math.isfinite(v) for v in q+Q),'invalid rotation')
   require(abs(sum(x*x for x in Q)-1)<.0002 and 1-abs(sum(x*y for x,y in zip(q,Q)))<.00002,'air collider rotation differs')
   if c['type']=='Mesh':
    require(a['convex']==c['convex'] and (a['meshId'] is not None)==c['hasSerializedMesh'],'air mesh binding mismatch')
    if c['hasSerializedMesh']:
     guid=re.search(r'guid: ([0-9a-f]{32})',c['meshReference'])[1]
     file_id=re.search(r'fileID: (\d+)',c['meshReference'])[1]
     require(a['meshId']==guid+':'+file_id and guid in source['meshSources'],'Unity collider collision mesh identity differs')
  shootables={s['componentFileId']:s for s in actual['shootables']}
  require(len(shootables)==len(u['shootables']),'air shootable cardinality mismatch')
  for s in u['shootables']:
   targets=shootables[s['componentFileId']]['targets']
   require(len(targets)==len(s['targets']),'air target cardinality mismatch')
   for a,b in zip(s['targets'],targets):
    require(a['transformFileId']==b['transformFileId'] and a['type']==b['type'],'air target identity/mask mismatch')
    point(a['restPosition'],b['position'])
 require(len(unity['meshes'])==len(source['meshSources'])==6,'air mesh cardinality mismatch')
 for key,mesh in unity['meshes'].items():
  binding=source['meshSources'][key.split(':')[0]]
  require(mesh['source']==binding['source'] and mesh['sha256']==binding['sha256']==hashlib.sha256((ASSETS/mesh['source']).read_bytes()).hexdigest(),'collision mesh digest mismatch')
  vertices=mesh['vertices'];triangles=mesh['triangles']
  require(len(vertices)>=3 and len(triangles)>=3 and len(triangles)%3==0,'empty air collision mesh')
  require(all(len(v)==3 and all(math.isfinite(x) for x in v) for v in vertices),'invalid mesh vertex')
  require(all(type(i)==int and 0<=i<len(vertices) for i in triangles),'invalid mesh triangle index')
 print('PASS: independent air geometry: 3 prefabs,',total,'colliders, 6 collision meshes, all shot targets')
if __name__=='__main__':main()
