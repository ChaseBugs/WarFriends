"""Check Unity aim samples against source targets and existing collision sampling."""
import json,math
from extract_enemy_shot_targets import ROOT,extract

def main():
 content=ROOT/'Server/content'
 targets=json.loads((content/'recovered-enemy-target-poses.json').read_text())
 poses=json.loads((content/'recovered-enemy-poses.json').read_text())
 inventory=extract()
 assert targets['version']==1 and targets['client']=='1.4.0' and targets['sampleRate']==30
 assert targets['source']==inventory['source'] and targets['sha256']==inventory['sha256']==poses['sha256']
 assert len(targets['clips'])==len(poses['clips']) and len(targets['clips'])>100
 samples=0
 for target,pose in zip(targets['clips'],poses['clips']):
  for key in ('name','source','guid','fileId','sha256','length','wrap'):
   assert target[key]==pose[key],(target['name'],key)
  assert len(target['frames'])==len(pose['frames'])
  for frame,reference in zip(target['frames'],pose['frames']):
   assert frame['seconds']==reference['seconds']
   assert len(frame['targets'])==3
   for row,source in zip(frame['targets'],inventory['targets']):
    assert row['path']==source['path'] and row['type']==source['type']
    assert len(row['position'])==3 and all(isinstance(v,(int,float)) and math.isfinite(v) and abs(v)<100 for v in row['position'])
    samples+=1
 print(f'PASS: {len(targets["clips"])} source-bound clips, {samples} animated aim-target positions')

if __name__=='__main__':main()
