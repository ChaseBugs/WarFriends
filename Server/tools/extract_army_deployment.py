"""Extract 1.4.0 deathmatch army options from the scene and runtime sheet."""

import hashlib
import json
import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCENE = ASSETS / "Scenes/MainScene.unity"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"
OUTPUT = ROOT / "Server/content/recovered-army-deployment.json"
INFANTRY_PREFAB = ASSETS / "GameObject/enemy.prefab"
RUSHER_TYPES = {
    "SoldierBehaviourCommando", "SoldierBehaviourFlamethrower",
    "SoldierBehaviourParachuter", "SoldierBehaviourShotgunner",
    "SoldierBehaviourSwat", "SoldierBehaviourWarper",
}


def field(block, name):
    match = re.search(r"^  " + re.escape(name) + r": (.+)$", block, re.M)
    if not match:
        raise ValueError(f"missing scene field {name}")
    return match.group(1)


def main():
    source = SCENE.read_bytes()
    scene = source.decode("utf-8-sig")
    digest = hashlib.sha256(source).hexdigest()
    content = json.loads(CONTENT.read_text(encoding="utf-8"))
    if digest != content["mainSceneSha256"]:
        raise ValueError("MainScene differs from recovered battle content")
    sheet = next(x for x in content["sheets"] if x["type"] == "Google2u.ArmyUpgrades")
    rows = {x["NAME"]: x for x in sheet["rows"]}
    blocks = {int(m.group(1)): m.group(2) for m in re.finditer(
        r"^--- !u!\d+ &(\d+)\r?\n(.*?)(?=^--- !u!|\Z)", scene, re.M | re.S)}
    manager = blocks[46740]
    if "guid: 433abe88ac22c67e9443ddb8be94375b" not in manager:
        raise ValueError("deathmatch spawning component changed")
    meta = {}
    for path in (ASSETS / "Scripts").rglob("*.cs.meta"):
        match = re.search(r"^guid: ([0-9a-f]{32})$", path.read_text(encoding="utf-8-sig"), re.M)
        if match:
            meta[match.group(1)] = path.with_suffix("")
    families = []
    start = manager.index("  armyDefinitions:\n")
    end = manager.find("\n  baseCoolDown:", start)
    if end < 0:
        raise ValueError("deathmatch army definition boundary changed")
    entries = re.split(r"(?=^  - behaviour: \{fileID: )", manager[start:end], flags=re.M)
    option_id = 0
    for entry in entries:
        if not entry.startswith("  - behaviour:"):
            continue
        behavior_id = int(re.search(r"behaviour: \{fileID: (\d+)\}", entry).group(1))
        behavior = blocks[behavior_id]
        behavior_guid = re.search(r"guid: ([0-9a-f]{32})", field(behavior, "m_Script")).group(1)
        behavior_type = meta[behavior_guid].stem
        slots_id = int(re.search(r"\{fileID: (\d+)\}", field(behavior, "upgradeSlots")).group(1))
        slots = blocks[slots_id]
        guid = re.search(r"guid: ([0-9a-f]{32})", field(slots, "m_Script")).group(1)
        script = meta[guid]
        script_text = script.read_text(encoding="utf-8-sig")
        slot_type = re.search(r"UpgradeSlots\w*<\s*(DBUpgradeSlots\w+)\s*>", script_text)
        if not slot_type:
            raise ValueError(f"unknown upgrade slot type {script}")
        row_name = "Google2u." + slot_type.group(1)
        row = rows[row_name]
        mask = re.search(r"^  spawnPointType: (\d+)$", behavior, re.M)
        base_speed = re.search(r"^  base(?:Definition|VehicleDefinititon):\r?\n(?:^    .*\r?\n)*?^    speed: ([0-9]+(?:\.[0-9]+)?)$", behavior, re.M)
        if not base_speed:
            raise ValueError(f"missing base movement speed for {behavior_type}")
        speed = float(base_speed.group(1))
        if not 0 < speed <= 20:
            raise ValueError(f"invalid base movement speed for {behavior_type}")
        shot_fields = None
        if behavior_type in RUSHER_TYPES:
            if not re.search(r"class " + behavior_type + r"\s*:\s*SoldierBehaviourRusher<",
                             script_text := meta[behavior_guid].read_text(encoding="utf-8-sig")):
                raise ValueError(f"Rusher inheritance changed for {behavior_type}")
            shot_fields = {}
            for name in ("probabilityOfRealShot", "fireBatchSizeMin", "fireBatchSizeMax",
                         "minShootTime", "maxShootTime"):
                match = re.search(r"^    " + name + r": ([^\r\n]+)$", behavior, re.M)
                if not match and name=="crew":
                    vehicle_shot[name]=0
                    continue
                if not match:
                    raise ValueError(f"missing base shot field {name} for {behavior_type}")
                shot_fields[name] = (int(match.group(1)) if name.startswith("fireBatch")
                                     else float(match.group(1)))
            if (not 0 <= shot_fields["probabilityOfRealShot"] <= 1 or
                not 1 <= shot_fields["fireBatchSizeMin"] <= shot_fields["fireBatchSizeMax"] <= 14 or
                not 0 <= shot_fields["minShootTime"] <= shot_fields["maxShootTime"] <= 60):
                raise ValueError(f"invalid base shot values for {behavior_type}")
        vehicle_shot = None
        if not int(field(behavior, "isSoldier")) and behavior_type != "MechBehaviour":
            vehicle_shot={}
            for name in ("shotSpeed", "probabilityOfRealShot", "fireBatchSizeMin",
                         "fireBatchSizeMax", "minShootTime", "maxShootTime", "crew"):
                match = re.search(r"^    " + name + r": ([^\r\n]+)$", behavior, re.M)
                if not match and name == "crew":
                    vehicle_shot[name]=0
                    continue
                if not match:
                    raise ValueError(f"missing vehicle combat field {name} for {behavior_type}")
                vehicle_shot[name] = int(match.group(1)) if name.startswith("fireBatch") else float(match.group(1))
            if (vehicle_shot["shotSpeed"]<=0 or vehicle_shot["crew"]<0 or
                not 0<=vehicle_shot["probabilityOfRealShot"]<=1 or
                vehicle_shot["fireBatchSizeMin"]<0 or vehicle_shot["fireBatchSizeMax"]>14 or
                vehicle_shot["fireBatchSizeMin"]>vehicle_shot["fireBatchSizeMax"] or
                vehicle_shot["minShootTime"]<0 or vehicle_shot["maxShootTime"]<vehicle_shot["minShootTime"]):
                raise ValueError(f"invalid vehicle combat fields for {behavior_type}")
        counts = [int(x) for x in row["SPAWNS"].split(" ")]
        if not counts or any(x <= 0 for x in counts):
            raise ValueError(f"invalid runtime spawns {row_name}")
        options = [{"index": option_id + i, "count": count,
                    "power": count * row["TOTALPOWER"],
                    "cooldown": count * row["COOLDOWN"]}
                   for i, count in enumerate(counts)]
        option_id += len(options)
        families.append({"behaviorFileId": behavior_id, "behaviorType": behavior_type,
                         "upgradeSlotsFileId": slots_id,
                         "unitId": field(behavior, "unitDictionaryId"),
                         "sheetRow": row_name, "unitType": int(field(behavior, "unitType")),
                         "spawnPointMask": int(mask.group(1)) if mask else 0,
                         "maxGeneratedCount": int(field(behavior, "maxGeneratedCount")),
                         "baseSpeed": speed,
                         **({"baseShot": shot_fields} if shot_fields is not None else {}),
                         **({"vehicleShot": vehicle_shot} if vehicle_shot is not None else {}),
                         "movementSpeed": float(row["MOVEMENTSPEED"]),
                         "isSoldier": field(behavior, "isSoldier") == "1",
                         "isAir": field(behavior, "isAir") == "1", "options": options})
    if len(families) != 24 or len({x["unitId"] for x in families}) != 24:
        raise ValueError("expected 24 unique scene army families")
    constants = next(x for x in content["sheets"] if x["type"] == "Google2u.Constants")
    values = {x["DBKEY"]: x["FLOATVALUE"] for x in constants["rows"]}
    prefab_bytes = INFANTRY_PREFAB.read_bytes()
    prefab = prefab_bytes.decode("utf-8-sig")
    agents = re.findall(r"^NavMeshAgent:\r?\n(.*?)(?=^--- !u!|\Z)", prefab, re.M | re.S)
    if len(agents) != 1:
        raise ValueError("expected one common infantry NavMeshAgent")
    agent = agents[0]
    def agent_field(name):
        match = re.search(r"^  " + re.escape(name) + r": ([^\r\n]+)$", agent, re.M)
        if not match:
            raise ValueError(f"missing infantry agent {name}")
        return match.group(1)
    infantry_agent = {
        "prefabSha256": hashlib.sha256(prefab_bytes).hexdigest(),
        "radius": float(agent_field("m_Radius")),
        "acceleration": float(agent_field("m_Acceleration")),
        "angularSpeed": float(agent_field("m_AngularSpeed")),
        "height": float(agent_field("m_Height")),
        "stoppingDistance": float(agent_field("m_StoppingDistance")),
        "autoBraking": agent_field("m_AutoBraking") == "1",
        "autoRepath": agent_field("m_AutoRepath") == "1",
        "obstacleAvoidanceType": int(agent_field("m_ObstacleAvoidanceType")),
    }
    artifact = {"version": 1, "sceneSha256": digest,
                "runtimeRule": "SpawningManagerDeathMatch.InstanceOnPlayerDataLoaded replaces serialized unitsCounts with ArmyUpgrades.SPAWNS and reindexes all options",
                "maxEnergy": values["MaxEnergy"],
                "sendUnitsBaseCooldown": values["SendUnitsCoolDown"],
                "infantryAgent": infantry_agent,
                "families": families}
    serialized = json.dumps(artifact, indent=2, ensure_ascii=False) + "\n"
    if sys.argv[1:] == ["--check"]:
        if not OUTPUT.exists() or OUTPUT.read_text(encoding="utf-8") != serialized:
            raise ValueError("army deployment artifact is stale")
    elif not sys.argv[1:]:
        OUTPUT.write_text(serialized, encoding="utf-8")
    else:
        raise ValueError("usage: extract_army_deployment.py [--check]")
    print(f"{len(families)} families, {option_id} runtime options; {OUTPUT}")


if __name__ == "__main__":
    main()
