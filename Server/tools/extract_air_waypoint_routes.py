"""Pin ordered source air waypoints/radius/stay times; runtime binding is separate."""
import hashlib,json,re,sys,math
from extract_army_spawn_points import ROOT,field,ref,transform_chain

OUTPUT=ROOT/'Server/content/recovered-air-waypoint-routes.json'
SPAWNS=ROOT/'Server/content/recovered-army-spawn-points.json'

def extract():
 raw=SPAWNS.read_bytes();source=json.loads(raw);maps=[]
 for entry in source['maps']:
  data=(ROOT/'Clients/ExportedProject'/entry['source']).read_bytes()
  if hashlib.sha256(data).hexdigest()!=entry['sha256']:raise ValueError('air route scene changed')
  blocks={int(m[2]):(int(m[1]),m[3]) for m in re.finditer(r'^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',data.decode('utf-8-sig'),re.M|re.S)}
  transforms={ref(b,'m_GameObject'):i for i,(k,b) in blocks.items() if k==4}
  routes=[]
  for spawn in entry['points']:
   if spawn['collection'] not in ('spawnPointsCollectionDrones','spawnPointsCollectionAssaultHelis','spawnPointsCollectionHelicopters'):continue
   pathid=spawn['reservationFileId'];path=blocks[pathid][1]
   if 'guid: a604c2e26b5732c5b35329d042a09950' not in path:raise ValueError('wrong path type')
   match=re.search(r'^  wayPoints:\r?\n(.*?)(?=^  \w|\Z)',path,re.M|re.S)
   ids=[int(v) for v in re.findall(r'fileID: (\d+)',match[1])]
   if not ids or len(ids)!=len(set(ids)) or spawn['joinWaypointFileId'] not in ids:raise ValueError('invalid ordered path')
   radius=float(field(path,'Radius'))
   if not math.isfinite(radius) or radius<=0:raise ValueError('invalid path radius')
   points=[]
   for index,wid in enumerate(ids):
    point=blocks[wid][1]
    if 'guid: 65351fae930a5df16f470909621c2f6f' not in point or ref(point,'path')!=pathid:raise ValueError('invalid waypoint owner')
    stay=float(field(point,'stayTime'))
    if not math.isfinite(stay) or stay<0:raise ValueError('invalid waypoint stay')
    tid=transforms[ref(point,'m_GameObject')];chain,position=transform_chain(blocks,tid)
    points.append({'componentFileId':wid,'transformFileId':tid,'index':index,'stayTime':stay,'worldPosition':position,'transformChain':chain})
   routes.append({'spawnComponentFileId':spawn['componentFileId'],'collection':spawn['collection'],
    'fraction':spawn['fraction'],'pathComponentFileId':pathid,'joinWaypointFileId':spawn['joinWaypointFileId'],
    'joinIndex':ids.index(spawn['joinWaypointFileId']),'radius':radius,'waypoints':points})
  maps.append({'source':entry['source'],'sha256':entry['sha256'],'routes':routes})
 return {'version':1,'spawnSourceSha256':hashlib.sha256(raw).hexdigest(),'maps':maps}

def main():
 artifact=extract();text=json.dumps(artifact,indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if not OUTPUT.exists() or OUTPUT.read_text()!=text:raise ValueError('air waypoint artifact stale')
 elif not sys.argv[1:]:OUTPUT.write_text(text)
 else:raise ValueError('usage: extract_air_waypoint_routes.py [--check]')
 print(f"{len(artifact['maps'])} maps, {sum(len(m['routes']) for m in artifact['maps'])} air spawn routes")
if __name__=='__main__':main()
