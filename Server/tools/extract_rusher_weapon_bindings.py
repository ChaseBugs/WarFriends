"""Pin serialized EnemyBasicInventory weapon object references for Rusher families."""
import hashlib,json,math,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
SCENE=ROOT/"Clients/ExportedProject/Assets/Scenes/MainScene.unity"
DEPLOY=ROOT/"Server/content/recovered-army-deployment.json"
OUT=ROOT/"Server/content/recovered-rusher-weapon-bindings.json"
ENEMY=ROOT/"Clients/ExportedProject/Assets/GameObject/enemy.prefab"

def yaml(path):
    text=path.read_text(encoding="utf-8-sig",errors="ignore")
    blocks={int(m.group(1)):m.group(2) for m in re.finditer(
        r"^--- !u!\d+ &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",text,re.M|re.S)}
    names={int(m.group(1)):m.group(2) for m in re.finditer(
        r"^--- !u!1 &(\d+)\r?\n.*?^  m_Name: (.*?)\r?$",text,re.M|re.S)}
    transforms={}
    for fid,block in blocks.items():
        if not block.startswith("Transform:"): continue
        def values(label,keys):
            row=re.search(rf"^  {label}: \{{(.*?)\}}$",block,re.M).group(1)
            found={k:float(v) for k,v in re.findall(r"([xyzw]): ([^,}]+)",row)}
            return [found[k] for k in keys]
        transforms[fid]={"gameObject":int(re.search(r"m_GameObject: \{fileID: (\d+)\}",block).group(1)),
            "parent":int(re.search(r"m_Father: \{fileID: (\d+)\}",block).group(1)),
            "position":values("m_LocalPosition","xyz"),"rotation":values("m_LocalRotation","xyzw"),
            "scale":values("m_LocalScale","xyz")}
    return text,blocks,names,transforms

def qmul(a,b):
    ax,ay,az,aw=a;bx,by,bz,bw=b
    return [aw*bx+ax*bw+ay*bz-az*by,aw*by-ax*bz+ay*bw+az*bx,
            aw*bz+ax*by-ay*bx+az*bw,aw*bw-ax*bx-ay*by-az*bz]

def qrotate(q,v):
    x,y,z,w=q;vx,vy,vz=v
    tx=2*(y*vz-z*vy);ty=2*(z*vx-x*vz);tz=2*(x*vy-y*vx)
    return [vx+w*tx+(y*tz-z*ty),vy+w*ty+(z*tx-x*tz),vz+w*tz+(x*ty-y*tx)]

def matmul(a,b):
    return [[sum(a[r][k]*b[k][c] for k in range(4)) for c in range(4)] for r in range(4)]

def trs(position,rotation,scale):
    x,y,z,w=rotation;sx,sy,sz=scale
    return [[(1-2*y*y-2*z*z)*sx,(2*x*y-2*z*w)*sy,(2*x*z+2*y*w)*sz,position[0]],
            [(2*x*y+2*z*w)*sx,(1-2*x*x-2*z*z)*sy,(2*y*z-2*x*w)*sz,position[1]],
            [(2*x*z-2*y*w)*sx,(2*y*z+2*x*w)*sy,(1-2*x*x-2*y*y)*sz,position[2]],
            [0.,0.,0.,1.]]

def rotation_from_matrix(m):
    cols=[[m[r][c] for r in range(3)] for c in range(3)]
    for c in range(3):
        length=math.sqrt(sum(v*v for v in cols[c]));cols[c]=[v/length for v in cols[c]]
    r=[[cols[c][row] for c in range(3)] for row in range(3)];trace=r[0][0]+r[1][1]+r[2][2]
    if trace>0:
        s=math.sqrt(trace+1)*2;return [(r[2][1]-r[1][2])/s,(r[0][2]-r[2][0])/s,(r[1][0]-r[0][1])/s,.25*s]
    i=max(range(3),key=lambda n:r[n][n]);j=(i+1)%3;k=(i+2)%3
    s=math.sqrt(1+r[i][i]-r[j][j]-r[k][k])*2;q=[0.,0.,0.,0.]
    q[i]=.25*s;q[3]=(r[k][j]-r[j][k])/s;q[j]=(r[j][i]+r[i][j])/s;q[k]=(r[k][i]+r[i][k])/s
    return q

def relative(transform_id,transforms,names,zero_root_position=False):
    chain=[];current=transform_id
    while current:
        row=transforms[current];chain.append((current,row));current=row["parent"]
    chain.reverse();matrix=[[1.,0.,0.,0.],[0.,1.,0.,0.],[0.,0.,1.,0.],[0.,0.,0.,1.]];path=[]
    for index,(fid,row) in enumerate(chain):
        path.append(names[row["gameObject"]])
        if index==0 and not zero_root_position: continue
        local=[0.,0.,0.] if zero_root_position and index==0 else row["position"]
        scale=[1.,1.,1.] if zero_root_position and index==0 else row["scale"]
        matrix=matmul(matrix,trs(local,row["rotation"],scale))
    return {"path":"/".join(path),"position":[matrix[0][3],matrix[1][3],matrix[2][3]],
            "rotation":rotation_from_matrix(matrix)}

def main():
    raw=SCENE.read_bytes(); text=raw.decode("utf-8-sig")
    blocks={int(m.group(1)):m.group(2) for m in re.finditer(
        r"^--- !u!\d+ &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",text,re.M|re.S)}
    families=json.loads(DEPLOY.read_text())["families"]; rows=[]
    meta={}
    for path in (ROOT/"Clients/ExportedProject/Assets").rglob("*.meta"):
        m=re.search(r"^guid: ([0-9a-f]{32})$",path.read_text(encoding="utf-8-sig",errors="ignore"),re.M)
        if m: meta[m.group(1)]=path.with_suffix("")
    for family in families:
        if "baseShot" not in family: continue
        block=blocks[family["behaviorFileId"]]
        game_object=re.search(r"^  m_GameObject: \{fileID: (\d+)\}",block,re.M).group(1)
        inventories=[]
        for file_id,value in blocks.items():
            if f"m_GameObject: {{fileID: {game_object}}}" not in value or "weapons:" not in value: continue
            refs=[{"fileId":int(file_id),"weaponFileId":int(fid),"guid":guid}
                  for fid,guid in re.findall(
                      r"weapon: \{fileID: (\d+), guid: ([0-9a-f]{32})",value)]
            if refs: inventories.append(refs)
        if len(inventories)!=1: raise ValueError(f"inventory binding changed: {family['unitId']}")
        for ref in inventories[0]:
            asset=meta.get(ref["guid"])
            if asset is None: raise ValueError(f"unresolved weapon GUID: {ref['guid']}")
            ref["asset"]=asset.relative_to(ROOT/"Clients/ExportedProject/Assets").as_posix()
            prefab,prefab_blocks,prefab_names,prefab_transforms=yaml(asset)
            types=re.findall(r"^  weaponType: (\d+)$",prefab,re.M)
            ref["weaponType"]=int(types[0]) if types else None
            if ref["weaponType"] is None: raise ValueError(f"weapon type missing: {asset}")
            flight=re.search(r"^  speed: ([0-9.]+)\r?\n  checkDistance: ([0-9.]+)$",prefab,re.M)
            ref["projectile"]=(
                {"speed":float(flight.group(1)),"checkDistance":float(flight.group(2))}
                if flight else None)
            weapon_block=prefab_blocks[ref["weaponFileId"]]
            spawn_id=int(re.search(r"^  spawnPoint: \{fileID: (\d+)\}$",weapon_block,re.M).group(1))
            ref["spawnPoint"]=relative(spawn_id,prefab_transforms,prefab_names,True)
        rows.append({"unitId":family["unitId"],"behaviorType":family["behaviorType"],
                     "behaviorFileId":family["behaviorFileId"],"inventory":inventories[0]})
    if len(rows)!=6: raise ValueError("expected six Rusher weapon bindings")
    enemy_text,enemy_blocks,enemy_names,enemy_transforms=yaml(ENEMY)
    soldier_parts=next(block for block in enemy_blocks.values() if "gunSnapPointNotScaled:" in block)
    gun_snap=int(re.search(r"gunSnapPointNotScaled: \{fileID: (\d+)\}",soldier_parts).group(1))
    artifact={"version":2,"sceneSha256":hashlib.sha256(raw).hexdigest(),
              "enemyPrefabSha256":hashlib.sha256(ENEMY.read_bytes()).hexdigest(),
              "gunSnap":relative(gun_snap,enemy_transforms,enemy_names),
              "provenance":"serialized EnemyBasicInventory weapon references plus enemy rig and weapon spawn-point transform chains; runtime weapon IDs remain unresolved",
              "families":rows}
    encoded=(json.dumps(artifact,indent=2)+"\n").encode()
    if __import__("sys").argv[1:]==["--check"]:
        if OUT.read_bytes()!=encoded: raise ValueError("Rusher weapon artifact is stale")
    else: OUT.write_bytes(encoded)
    print("six Rusher serialized weapon bindings pinned")
if __name__=="__main__": main()
