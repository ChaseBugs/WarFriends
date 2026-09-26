"""Pin recovered CardHeavyTurret placement, progression rows and prefab weapon graph."""

import hashlib, json, math, re, sys
from pathlib import Path

ROOT=Path(__file__).resolve().parents[2]
ASSETS=ROOT/"Clients/ExportedProject/Assets"
CONTENT=ROOT/"Server/content/recovered-battle-content.json"
OUTPUT=ROOT/"Server/content/recovered-heavy-turret-source.json"
MAP_GUID="f8e8488fbe21f6c02c9eef456d27a3b9"
POSITION_GUID="61d832db3eebf585fb0a1ffe7e76ee26"
HEAVY_GUID="21c7cfdd6453e9d44c8010b3fd8c8f15"
TURRET_GUID="71b516e3f1c29506c1c10fb8054e06b4"

def blocks(text):
    return {int(m.group(2)):(int(m.group(1)),m.group(3)) for m in re.finditer(
        r"^--- !u!(\d+) &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)",text,re.M|re.S)}
def field(block,name):
    m=re.search(r"^  "+re.escape(name)+r": (.+)$",block,re.M)
    if not m: raise ValueError("missing "+name)
    return m.group(1)
def ref(block,name): return int(re.search(r"\{fileID: (\d+)",field(block,name)).group(1))
def vec(value): return [float(v) for _,v in re.findall(r"([xyzw]): (-?(?:\d+(?:\.\d*)?|\.\d+)(?:[eE][+-]?\d+)?)",value)]
def mul(a,b):
    x,y,z,w=a;X,Y,Z,W=b
    return [w*X+x*W+y*Z-z*Y,w*Y-x*Z+y*W+z*X,w*Z+x*Y-y*X+z*W,w*W-x*X-y*Y-z*Z]
def rotate(q,p): return mul(mul(q,[*p,0]),[-q[0],-q[1],-q[2],q[3]])[:3]
def world(source,transform_id):
    chain=[]
    while transform_id:
        b=source[transform_id][1];chain.append((vec(field(b,"m_LocalPosition")),vec(field(b,"m_LocalRotation")),vec(field(b,"m_LocalScale"))))
        transform_id=ref(b,"m_Father")
        if len(chain)>32: raise ValueError("cyclic transform")
    p=[0.,0.,0.];q=[0.,0.,0.,1.];s=[1.,1.,1.]
    for lp,lq,ls in reversed(chain):
        p=[a+b for a,b in zip(p,rotate(q,[a*b for a,b in zip(lp,s)]))];q=mul(q,lq);s=[a*b for a,b in zip(s,ls)]
    if not all(math.isfinite(x) and abs(x)<10000 for x in p): raise ValueError("invalid position")
    return p
def digest(path): return hashlib.sha256(path.read_bytes()).hexdigest()
def game_object_transform(source,go):
    m=re.search(r"^  - 4: \{fileID: (\d+)\}$",source[go][1],re.M)
    if not m: raise ValueError("missing transform")
    return int(m.group(1))
def section_refs(block,name,next_name):
    body=block.split("  "+name+":\n",1)[1].split("  "+next_name+":",1)[0]
    return [int(x) for x in re.findall(r"^  - \{fileID: (\d+)\}$",body,re.M)]

def extract_map(row):
    path=ROOT/"Clients/ExportedProject"/row["source"]
    if digest(path)!=row["sha256"]: raise ValueError("map changed")
    source=blocks(path.read_text(encoding="utf-8-sig"))
    maps=[(i,b) for i,(k,b) in source.items() if k==114 and f"guid: {MAP_GUID}" in b]
    if len(maps)!=1: raise ValueError("expected MapDefinition")
    map_id,map_block=maps[0]
    body=map_block.split("  playersPositions:\n",1)[1]
    entries=re.findall(r"  - point: \{fileID: (\d+)\}\r?\n    fraction: (\d+)\r?\n    cameraPath: \{fileID: \d+\}\r?\n    mainPosition: (\d+)\r?\n    index: \d+",body)
    if len(entries)!=8: raise ValueError("expected eight defend positions")
    covers=[]
    for order,(point_id,fraction,main) in enumerate(entries):
        point_id=int(point_id);fraction=int(fraction);point=source[point_id][1]
        refs=section_refs(point,"turretPositions","rusherPoints")
        if len(refs)!=2: raise ValueError("expected two turret positions")
        slots=[]
        for slot_order,component_id in enumerate(refs):
            component=source[component_id][1]
            if f"guid: {POSITION_GUID}" not in component or int(field(component,"used"))!=0: raise ValueError("invalid TurretPosition")
            go=ref(component,"m_GameObject");transform=game_object_transform(source,go)
            slots.append({"order":slot_order,"componentFileId":component_id,"gameObjectFileId":go,
                          "transformFileId":transform,"sourcePosition":world(source,transform)})
        covers.append({"order":order,"pointComponentFileId":point_id,"fraction":fraction,
                       "main":bool(int(main)),"slots":slots})
    return {"source":row["source"],"sha256":row["sha256"],"mapDefinitionFileId":map_id,"covers":covers}

def extract_prefab():
    path=ASSETS/"GameObject/HeavyTurret.prefab";source=blocks(path.read_text(encoding="utf-8-sig"))
    heavy=[(i,b) for i,(k,b) in source.items() if k==114 and f"guid: {HEAVY_GUID}" in b]
    turret=[(i,b) for i,(k,b) in source.items() if k==114 and f"guid: {TURRET_GUID}" in b]
    roots=[i for i,(k,b) in source.items() if k==4 and ref(b,"m_Father")==0]
    meshes=[(i,b) for i,(k,b) in source.items() if k==33 and "fileID: 4300000" in field(b,"m_Mesh")]
    colliders=[(i,b) for i,(k,b) in source.items() if k in (65,136)]
    if len(heavy)!=1 or len(turret)!=1 or len(roots)!=1 or not meshes or not colliders: raise ValueError("HeavyTurret graph changed")
    heavy_id,h=heavy[0];turret_id,t=turret[0]
    if ref(h,"turretWeapon")!=turret_id: raise ValueError("HeavyTurret weapon binding changed")
    return {"source":"Assets/GameObject/HeavyTurret.prefab","sha256":digest(path),"rootTransformFileId":roots[0],
            "heavyTurretComponentFileId":heavy_id,"turretWeaponComponentFileId":turret_id,
            "turret":{"aimTime":float(field(t,"aimTime")),"batchSizeMin":int(field(t,"batchSizeMin")),
                      "batchSizeMax":int(field(t,"batchSizeMax")),"minShootTime":float(field(t,"minShootTime")),
                      "maxShootTime":float(field(t,"maxShootTime")),"maxShotRotation":float(field(t,"maxShotRotation")),
                      "predictPosition":bool(int(field(t,"predictPosition"))),"primaryTarget":int(field(t,"primaryTarget")),
                      "useUnitTarget":bool(int(field(t,"useUnitTarget")),),"batchedWeaponComponentFileId":ref(t,"batchedWeapon")},
            "meshComponentFileIds":[i for i,_ in meshes],"colliderComponentFileIds":[i for i,_ in colliders]}

def main():
    content=json.loads(CONTENT.read_text(encoding="utf-8"))
    rows=next(s["rows"] for s in content["sheets"] if s["type"]=="Google2u.DBUpgradeSlotsHeavyTurret")
    if len(rows)!=2: raise ValueError("HeavyTurret stat endpoints changed")
    artifact={"version":1,"client":"1.4.0","spawnCount":1,"navMeshSampleRadius":10.0,"navMeshAreaMask":1,
              "maxDisplayLevel":44,"stats":rows,"prefab":extract_prefab(),"maps":[extract_map(x) for x in content["maps"]]}
    serialized=json.dumps(artifact,indent=2,ensure_ascii=False)+"\n"
    if sys.argv[1:]==["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8")!=serialized: raise ValueError("Heavy Turret artifact is stale")
    elif not sys.argv[1:]: OUTPUT.write_text(serialized,encoding="utf-8")
    else: raise ValueError("usage: extract_heavy_turret_source.py [--check]")
    print(f"{len(artifact['maps'])} maps, {sum(len(c['slots']) for m in artifact['maps'] for c in m['covers'])} Heavy Turret slots")
if __name__=="__main__": main()
