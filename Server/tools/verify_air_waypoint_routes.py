"""Compare source extraction against independently loaded Unity scene transforms."""
import json,math,hashlib
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
content=ROOT/'Server/content'
expected=json.loads((content/'recovered-air-waypoint-routes.json').read_text())
actual=json.loads((content/'recovered-air-waypoint-unity.json').read_text())
assert len(expected['maps'])==len(actual['maps'])==5,'map count'
assert expected['spawnSourceSha256']==hashlib.sha256((content/'recovered-army-spawn-points.json').read_bytes()).hexdigest(),'spawn provenance'
count=points=0;maximum=0
for source,unity in zip(expected['maps'],actual['maps']):
 assert source['source']==unity['source'],'map order'
 assert source['sha256']==hashlib.sha256((ROOT/'Clients/ExportedProject'/source['source']).read_bytes()).hexdigest(),'scene provenance'
 assert len(source['routes'])==len(unity['routes']),'route count'
 for route,probe in zip(source['routes'],unity['routes']):
  for field in ('spawnComponentFileId','pathComponentFileId','joinWaypointFileId','joinIndex','radius'):
   assert route[field]==probe[field],f'route {field}'
  assert len(route['waypoints'])==len(probe['waypoints']),'waypoint count'
  for point,observed in zip(route['waypoints'],probe['waypoints']):
   for field in ('componentFileId','transformFileId','index','stayTime'):assert point[field]==observed[field],f'waypoint {field}'
   assert len(observed['worldPosition'])==3 and all(math.isfinite(v) for v in observed['worldPosition']),'finite world point'
   error=math.dist(point['worldPosition'],observed['worldPosition']);maximum=max(maximum,error)
   assert error<.0002,f'Unity world coordinate mismatch {error}'
   points+=1
  count+=1
print(f'PASS: {count} air routes, {points} waypoint samples; maximum Unity position error {maximum:.8f}')
