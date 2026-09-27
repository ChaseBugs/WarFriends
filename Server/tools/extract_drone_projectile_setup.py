"""Extract the source Drone BulletSetup, before runtime stat overrides."""
import hashlib,json,re,sys
from extract_ground_vehicle_weapons import ROOT,ASSETS,direct,number
OUTPUT=ROOT/'Server/content/recovered-drone-projectile-setup.json'
def extract():
 path=ASSETS/'GameObject/dronePrototype.prefab';data=path.read_bytes()
 blocks=[(int(m[1]),m[2]) for m in re.finditer(r'^--- !u!114 &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',data.decode('utf-8-sig'),re.M|re.S)]
 matches=[(i,b) for i,b in blocks if 'guid: 4ceecd6f3ff0e22dc65ce39c3a1fce86' in b]
 if len(matches)!=1:raise ValueError('Drone BulletSetup identity changed')
 i,b=matches[0]
 def obscured(name):
  m=re.search(r'^  '+name+r':\r?\n(?:^    .*\r?\n)*?^    fakeValue: ([^\r\n]+)$',b,re.M)
  if not m:raise ValueError('Missing setup '+name)
  return float(m[1])
 return {'version':1,'source':'Assets/GameObject/dronePrototype.prefab','sha256':hashlib.sha256(data).hexdigest(),
  'componentFileId':i,'speed':number(b,'speed'),'checkDistance':number(b,'checkDistance'),
  'fakeSpeedFactor':number(b,'fakeSpeedFactor'),'speedMultiplayer':number(b,'speedMultiplayer'),
  'criticalProbability':obscured('criticalProbability'),'criticalAmount':obscured('criticalAmount'),
  'serializedDamage':obscured('damageAmount'),'poisonTime':number(b,'poisonTime'),'poisonRatio':number(b,'poisonRatio')}
def main():
 text=json.dumps(extract(),indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if OUTPUT.read_text()!=text:raise ValueError('Stale Drone projectile setup')
 elif not sys.argv[1:]:OUTPUT.write_text(text)
 else:raise ValueError('usage: extract_drone_projectile_setup.py [--check]')
 print('PASS: source Drone BulletSetup')
if __name__=='__main__':main()
