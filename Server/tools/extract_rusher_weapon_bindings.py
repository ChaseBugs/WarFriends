"""Pin serialized EnemyBasicInventory weapon object references for Rusher families."""
import hashlib,json,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[2]
SCENE=ROOT/"Clients/ExportedProject/Assets/Scenes/MainScene.unity"
DEPLOY=ROOT/"Server/content/recovered-army-deployment.json"
OUT=ROOT/"Server/content/recovered-rusher-weapon-bindings.json"

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
            prefab=asset.read_text(encoding="utf-8-sig",errors="ignore")
            types=re.findall(r"^  weaponType: (\d+)$",prefab,re.M)
            ref["weaponType"]=int(types[0]) if types else None
            if ref["weaponType"] is None: raise ValueError(f"weapon type missing: {asset}")
            flight=re.search(r"^  speed: ([0-9.]+)\r?\n  checkDistance: ([0-9.]+)$",prefab,re.M)
            ref["projectile"]=(
                {"speed":float(flight.group(1)),"checkDistance":float(flight.group(2))}
                if flight else None)
        rows.append({"unitId":family["unitId"],"behaviorType":family["behaviorType"],
                     "behaviorFileId":family["behaviorFileId"],"inventory":inventories[0]})
    if len(rows)!=6: raise ValueError("expected six Rusher weapon bindings")
    artifact={"version":1,"sceneSha256":hashlib.sha256(raw).hexdigest(),
              "provenance":"serialized EnemyBasicInventory weapon object references; runtime weapon IDs remain unresolved",
              "families":rows}
    encoded=(json.dumps(artifact,indent=2)+"\n").encode()
    if __import__("sys").argv[1:]==["--check"]:
        if OUT.read_bytes()!=encoded: raise ValueError("Rusher weapon artifact is stale")
    else: OUT.write_bytes(encoded)
    print("six Rusher serialized weapon bindings pinned")
if __name__=="__main__": main()
