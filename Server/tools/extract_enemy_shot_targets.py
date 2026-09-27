"""Record source shot-target identities; rest poses are not animated authority."""
import hashlib,json,re,sys
from extract_ground_vehicle_weapons import ROOT,ASSETS,direct,ref,world_transform
OUTPUT=ROOT/'Server/content/recovered-enemy-shot-targets.json'

def extract():
 path=ASSETS/'GameObject/enemy.prefab';data=path.read_bytes()
 blocks={int(m[2]):(int(m[1]),m[3]) for m in re.finditer(
  r'^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',data.decode('utf-8-sig'),re.M|re.S)}
 components=[(i,b) for i,(kind,b) in blocks.items() if kind==114 and
  'guid: 3cf4d7761af3ce98d7a08bebfe4e8861' in b]
 if len(components)!=1:raise ValueError('Enemy shootable identity is ambiguous')
 cid,body=components[0]
 rows=re.findall(r'^  - transform: \{fileID: (\d+)\}\r?\n    type: (\d+)$',body,re.M)
 if [(int(a),int(b)) for a,b in rows]!=[(454546,8),(436299,1),(496281,4)]:
  raise ValueError('Enemy ordered target inventory changed')
 targets=[]
 for tid,kind in rows:
  tid=int(tid);chain=[];cursor=tid;seen=set()
  while cursor:
   if cursor in seen:raise ValueError('Target hierarchy cycle')
   seen.add(cursor);tag,b=blocks[cursor]
   if tag!=4:raise ValueError('Target does not resolve to Transform')
   go=ref(b,'m_GameObject');go_kind,go_body=blocks[go]
   if go_kind!=1:raise ValueError('Target GameObject identity invalid')
   chain.append({'transformFileId':cursor,'gameObjectFileId':go,'name':direct(go_body,'m_Name')})
   cursor=ref(b,'m_Father')
  pos,rotation,scale=world_transform(blocks,tid)
  targets.append({'transformFileId':tid,'type':int(kind),'path':'/'.join(x['name'] for x in reversed(chain)),
   'hierarchy':list(reversed(chain)),'restPosition':pos,'restRotation':rotation,'restScale':scale})
 return {'version':1,'source':'Assets/GameObject/enemy.prefab','sha256':hashlib.sha256(data).hexdigest(),
  'componentFileId':cid,'targets':targets}

def main():
 text=json.dumps(extract(),indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if OUTPUT.read_text()!=text:raise ValueError('Stale enemy shot-target inventory')
 elif not sys.argv[1:]:OUTPUT.write_text(text)
 else:raise ValueError('usage: extract_enemy_shot_targets.py [--check]')
 print('PASS: three ordered source enemy shot targets')
if __name__=='__main__':main()
