"""Pin serialized EnemyBasicInventory weapon object references for Rusher families."""
import hashlib,json,math,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
SCENE=ROOT/"Clients/ExportedProject/Assets/Scenes/MainScene.unity"
DEPLOY=ROOT/"Server/content/recovered-army-deployment.json"
OUT=ROOT/"Server/content/recovered-rusher-weapon-bindings.json"
ENEMY=ROOT/"Clients/ExportedProject/Assets/GameObject/enemy.prefab"
CLIPS=ROOT/"Clients/ExportedProject/Assets/AnimationClip"
SCRIPTS=ROOT/"Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
BATTLE_CONTENT=ROOT/"Server/content/recovered-battle-content.json"

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

def attack_windup(weapon_type):
    # EnemyController.PrepareToShoot: Rusher/RusherSpare uses no delay for a
    # flamethrower, the complete shield-unhide clip for SWAT weapons, and 30%
    # of SoldierAnimationController.StandShootLength for the ordinary branch.
    if weapon_type==12: return {"seconds":0.0,"rule":"flamethrower-zero","clip":None}
    name="shield_unhide" if weapon_type in (3,4) else {
        7:"shotgunner_shot_loop", 8:"shotgunner_shot_loop",
        14:"commando_shooting", 16:"colt_shooting_loop",
    }.get(weapon_type,"rifle_shot_loop")
    path=CLIPS/(name+".anim"); data=path.read_bytes(); text=data.decode("utf-8-sig")
    stop=re.search(r"^    m_StopTime: ([0-9.]+)$",text,re.M)
    if not stop or "  m_Legacy: 1" not in text: raise ValueError(f"invalid legacy attack clip: {path}")
    length=float(stop.group(1)); factor=1.0 if weapon_type in (3,4) else .3
    return {"seconds":length*factor,"rule":"swat-shield-unhide" if factor==1 else "stand-shoot-30-percent",
            "clip":{"asset":path.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
                    "sha256":hashlib.sha256(data).hexdigest(),"length":length}}

def attack_cadence(behavior_type):
    overrides={"SoldierBehaviourCommando":.2,"SoldierBehaviourWarper":.2,
               "SoldierBehaviourParachuter":.25}
    seconds=overrides.get(behavior_type,.35)
    source=SCRIPTS/((behavior_type if behavior_type in overrides else "SoldierBehaviour")+".cs")
    data=source.read_bytes(); text=data.decode("utf-8-sig")
    if not re.search(r"\.cadence\s*=\s*"+str(seconds).rstrip('0')+r"f",text):
        raise ValueError(f"missing source cadence {seconds}: {source}")
    return {"seconds":seconds,"strictTicks":math.floor(seconds*30)+1,
            "rule":"subclass-override" if behavior_type in overrides else "base-soldier",
            "source":source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
            "sha256":hashlib.sha256(data).hexdigest()}

def shotgun_falloff(behavior_type,inventory):
    if behavior_type not in ("SoldierBehaviourShotgunner","SoldierBehaviourWarper"): return None
    if len(inventory)!=1: raise ValueError("shotgun Rusher inventory changed")
    path=ROOT/"Clients/ExportedProject/Assets"/inventory[0]["asset"]
    text=path.read_text(encoding="utf-8-sig")
    def scalar(name):
        match=re.search(rf"^  {name}: ([0-9.]+)$",text,re.M)
        if not match: raise ValueError(f"missing shotgun {name}: {path}")
        return float(match.group(1))
    flat=int(scalar("flatY"));main=int(scalar("shotOnlyMainBullet"))
    source=SCRIPTS/(behavior_type+".cs");source_text=source.read_text(encoding="utf-8-sig")
    if "minDamage = (float)base.soldierBehaviourDefinititon.damage * 0.1f" not in source_text or \
       "maxDamage = base.soldierBehaviourDefinititon.damage" not in source_text:
        raise ValueError(f"shotgun runtime damage override changed: {source}")
    return {"radius":scalar("radius"),"shotHalfAngle":scalar("shotHalfAngle"),
            "shotHalfAngleNear":scalar("shotHalfAngleNear"),
            "minimumDamageRatio":0.1,"flatY":bool(flat),
            "shotOnlyMainBullet":bool(main),
            "rule":"min-plus-max-minus-min-times-one-minus-clamped-distance-over-radius",
            "source":source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
            "sha256":hashlib.sha256(source.read_bytes()).hexdigest()}

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
            normal=re.search(r"^  weapons:\r?\n(.*?)^  shield:",value,re.M|re.S)
            refs=[] if not normal else [{"fileId":int(file_id),"weaponFileId":int(fid),"guid":guid,
                "weaponType":int(runtime_type),"leftHand":bool(int(left))}
                for fid,guid,runtime_type,left in re.findall(
                    r"- weapon: \{fileID: (\d+), guid: ([0-9a-f]{32}), type: 2\}\r?\n"
                    r"    type: (\d+)\r?\n    leftHand: ([01])",normal.group(1))]
            if refs: inventories.append(refs)
        if len(inventories)!=1: raise ValueError(f"inventory binding changed: {family['unitId']}")
        for ref in inventories[0]:
            asset=meta.get(ref["guid"])
            if asset is None: raise ValueError(f"unresolved weapon GUID: {ref['guid']}")
            ref["asset"]=asset.relative_to(ROOT/"Clients/ExportedProject/Assets").as_posix()
            prefab,prefab_blocks,prefab_names,prefab_transforms=yaml(asset)
            types=re.findall(r"^  weaponType: (\d+)$",prefab,re.M)
            ref["prefabWeaponType"]=int(types[0]) if types else None
            if ref["prefabWeaponType"] is None: raise ValueError(f"prefab weapon type missing: {asset}")
            flight=re.search(r"^  speed: ([0-9.]+)\r?\n  checkDistance: ([0-9.]+)$",prefab,re.M)
            ref["projectile"]=(
                {"speed":float(flight.group(1)),"checkDistance":float(flight.group(2))}
                if flight else None)
            weapon_block=prefab_blocks[ref["weaponFileId"]]
            spawn_id=int(re.search(r"^  spawnPoint: \{fileID: (\d+)\}$",weapon_block,re.M).group(1))
            ref["spawnPoint"]=relative(spawn_id,prefab_transforms,prefab_names,True)
        rows.append({"unitId":family["unitId"],"behaviorType":family["behaviorType"],
                     "behaviorFileId":family["behaviorFileId"],
                     "attackWindup":attack_windup(inventories[0][0]["weaponType"]),
                     "attackCadence":attack_cadence(family["behaviorType"]),
                     "shotgunFalloff":shotgun_falloff(family["behaviorType"],inventories[0]),
                     "inventory":inventories[0]})
    if len(rows)!=6: raise ValueError("expected six Rusher weapon bindings")
    enemy_text,enemy_blocks,enemy_names,enemy_transforms=yaml(ENEMY)
    soldier_parts=next(block for block in enemy_blocks.values() if "gunSnapPointNotScaled:" in block)
    gun_snap=int(re.search(r"gunSnapPointNotScaled: \{fileID: (\d+)\}",soldier_parts).group(1))
    left_gun_snap=int(re.search(r"gunSnapPointNotScaledLeft: \{fileID: (\d+)\}",soldier_parts).group(1))
    content=json.loads(BATTLE_CONTENT.read_text())
    constants=next(s for s in content["sheets"] if s["type"]=="Google2u.UnitsContants")
    poison_time=float(constants["rows"][2]["FLOATVALUE"])
    commando_source=SCRIPTS/"SoldierBehaviourCommando.cs"
    poison_source=SCRIPTS/"BulletPoison.cs"
    commando_text=commando_source.read_text(encoding="utf-8-sig")
    poison_text=poison_source.read_text(encoding="utf-8-sig")
    if poison_time!=5 or "poisonTime = Singleton<GameVariables>.instance.unitsConstants.GetRow(UnitsContants.rowIds.PoisonShotTime).FLOATVALUE" not in commando_text or \
       "poisonRatio = base.soldierBehaviourDefinititon.special" not in commando_text or \
       "mHitDestroyableObject.Poison(ammoDamageAmount / mTime * mDamageRatio" not in poison_text or \
       "yield return new WaitForSeconds(1f)" not in poison_text:
        raise ValueError("Commando poison source contract changed")
    commando_poison={"durationSeconds":poison_time,"pulseIntervalSeconds":1.0,
                     "pulseCount":int(poison_time),
                     "rule":"immediate-then-wait-one-second-while-before-duration",
                     "constantsSheet":"Google2u.UnitsContants","constantsRow":2,
                     "behaviorSource":commando_source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
                     "behaviorSha256":hashlib.sha256(commando_source.read_bytes()).hexdigest(),
                     "bulletSource":poison_source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
                     "bulletSha256":hashlib.sha256(poison_source.read_bytes()).hexdigest()}
    swat_source=SCRIPTS/"SoldierBehaviourSwat.cs";swat_text=swat_source.read_text(encoding="utf-8-sig")
    if "speed * (1f + base.soldierBehaviourDefinititon.special)" not in swat_text or \
       "(!controller.hasSpecial) ?" not in swat_text:
        raise ValueError("SWAT special speed source contract changed")
    swat_special={"rule":"selected-special-multiplies-runtime-speed-by-one-plus-composed-special",
                  "source":swat_source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
                  "sha256":hashlib.sha256(swat_source.read_bytes()).hexdigest()}
    parachuter_source=SCRIPTS/"SoldierBehaviourParachuter.cs"
    kevlar_source=SCRIPTS/"Kevlar.cs"
    parachuter_text=parachuter_source.read_text(encoding="utf-8-sig")
    kevlar_text=kevlar_source.read_text(encoding="utf-8-sig")
    if "controller.SetUpKevlar(base.soldierBehaviourDefinititon.special)" not in parachuter_text or \
       "kevlarDestroyableObject.maxHealth = kevlarStrength * destroyableObject.maxHealth" not in kevlar_text or \
       "Mathf.Min(damageInfo.originalDamage, kevlarDestroyableObject.health)" not in kevlar_text:
        raise ValueError("Paratrooper kevlar source contract changed")
    parachuter_kevlar={"rule":"selected-special-times-unit-max-health-absorbs-original-damage-before-health",
                       "behaviorSource":parachuter_source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
                       "behaviorSha256":hashlib.sha256(parachuter_source.read_bytes()).hexdigest(),
                       "kevlarSource":kevlar_source.relative_to(ROOT/"Clients/ExportedProject").as_posix(),
                       "kevlarSha256":hashlib.sha256(kevlar_source.read_bytes()).hexdigest()}
    artifact={"version":9,"sceneSha256":hashlib.sha256(raw).hexdigest(),
              "enemyPrefabSha256":hashlib.sha256(ENEMY.read_bytes()).hexdigest(),
              "gunSnap":relative(gun_snap,enemy_transforms,enemy_names),
              "leftGunSnap":relative(left_gun_snap,enemy_transforms,enemy_names),
              "provenance":"serialized EnemyBasicInventory weapon references plus enemy rig and weapon spawn-point transform chains; runtime weapon IDs remain unresolved",
              "commandoPoison":commando_poison,
              "swatSpecialSpeed":swat_special,
              "paratrooperKevlar":parachuter_kevlar,
              "families":rows}
    encoded=(json.dumps(artifact,indent=2)+"\n").encode()
    if __import__("sys").argv[1:]==["--check"]:
        if OUT.read_bytes()!=encoded: raise ValueError("Rusher weapon artifact is stale")
    else: OUT.write_bytes(encoded)
    print("six Rusher weapon bindings, timing, falloff, poison, SWAT speed, and Paratrooper kevlar pinned")
if __name__=="__main__": main()
