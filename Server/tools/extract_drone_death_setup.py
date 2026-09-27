"""Capture recovered Drone death body and code evidence, without inventing fall physics."""
import hashlib,json,re,sys
from extract_ground_vehicle_weapons import ROOT,ASSETS,direct,number,ref,vector
OUTPUT=ROOT/'Server/content/recovered-drone-death-setup.json'

def extract():
 path=ASSETS/'GameObject/dronePrototype.prefab';data=path.read_bytes()
 blocks=[(int(m[1]),m[2]) for m in re.finditer(r'^--- !u!54 &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)',data.decode('utf-8-sig'),re.M|re.S)]
 rows=[(i,b) for i,b in blocks if ref(b,'m_GameObject')==147589]
 if len(rows)!=1:raise ValueError('Drone root Rigidbody identity is ambiguous')
 cid,body=rows[0]
 code_path=ASSETS/'Scripts/Assembly-CSharp/Drone.cs';code=code_path.read_bytes()
 text=code.decode('utf-8-sig')
 def literal(pattern):
  matches=re.findall(pattern,text)
  if len(matches)!=1:raise ValueError('Ambiguous Drone death code constant')
  return float(matches[0])
 constants={
  'explosionDamageHealthRatio':literal(r'explosionInfo\.explodeDamage = destroyableObj\.maxHealth \* ([\d.]+)f;'),
  'splashDamageHealthRatio':literal(r'explosionInfo\.damageAmount = destroyableObj\.maxHealth \* ([\d.]+)f;'),
  'deadRadius':literal(r'explosionInfo\.deadRadius = ([\d.]+)f;'),
  'hurtRadius':literal(r'explosionInfo\.hurtRadius = ([\d.]+)f;'),
  'destructionDelay':literal(r'DestroyEntity\(([\d.]+)f\);')}
 settings=[]
 for name in ('TimeManager.asset','DynamicsManager.asset'):
  p=ASSETS.parent/'ProjectSettings'/name;b=p.read_bytes()
  settings.append({'source':'ProjectSettings/'+name,'sha256':hashlib.sha256(b).hexdigest()})
 time=(ASSETS.parent/'ProjectSettings/TimeManager.asset').read_text()
 physics=(ASSETS.parent/'ProjectSettings/DynamicsManager.asset').read_text()
 steering_path=ASSETS/'Scripts/Assembly-CSharp/DroneSteering.cs';steering_bytes=steering_path.read_bytes()
 steering=steering_bytes.decode('utf-8-sig')
 fall=re.search(r'public void FallDown\(\)\s*\{([^}]+)\}',steering)
 if not fall or re.sub(r'\s+','',fall[1])!='mRigidBody.isKinematic=false;enabled=false;':
  raise ValueError('Drone fall transition changed; re-audit velocity and force authority')
 matrix=direct(physics,'m_LayerCollisionMatrix')
 matrix_valid=bool(re.fullmatch(r'[0-9a-fA-F]{256}',matrix))
 return {'version':1,'source':'Assets/GameObject/dronePrototype.prefab','sha256':hashlib.sha256(data).hexdigest(),
  'componentFileId':cid,'mass':number(body,'m_Mass'),'drag':number(body,'m_Drag'),
  'angularDrag':number(body,'m_AngularDrag'),'useGravity':direct(body,'m_UseGravity')=='1',
  'initialKinematic':direct(body,'m_IsKinematic')=='1','interpolation':int(direct(body,'m_Interpolate')),
  'constraints':int(direct(body,'m_Constraints')),'collisionDetection':int(direct(body,'m_CollisionDetection')),
  'deathCodeSource':'Assets/Scripts/Assembly-CSharp/Drone.cs','deathCodeSha256':hashlib.sha256(code).hexdigest(),
  'explosion':constants,'settingsEvidence':settings,'observedFixedTimestep':number(time,'Fixed Timestep'),
  'observedGravity':vector(direct(physics,'m_Gravity')),
  'steeringCodeSource':'Assets/Scripts/Assembly-CSharp/DroneSteering.cs',
  'steeringCodeSha256':hashlib.sha256(steering_bytes).hexdigest(),
  'fallTransition':{'kinematic':False,'steeringEnabled':False,'explicitVelocityAssignment':False},
  'observedLayerCollisionMatrix':matrix,'layerCollisionMatrixCanonicalHex':matrix_valid}

def main():
 text=json.dumps(extract(),indent=2)+'\n'
 if sys.argv[1:]==['--check']:
  if OUTPUT.read_text()!=text:raise ValueError('Stale Drone death evidence')
 elif not sys.argv[1:]:OUTPUT.write_text(text)
 else:raise ValueError('usage: extract_drone_death_setup.py [--check]')
 print('PASS: recovered Drone death body and explosion evidence')
if __name__=='__main__':main()
