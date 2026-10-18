"""Validate native stand observations and their source inputs; publish canonical LF JSON when requested."""

import argparse
import hashlib
import json
import re
from pathlib import Path

from extract_army_spawn_points import field
from extract_coop_enemy_points import blocks_in


ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/gunslinger-stand-unity-reference.json"
SOURCE_FILES = {
    "controllerSha256": CLIENT / "Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs",
    "prefabSha256": CLIENT / "Assets/GameObject/enemy.prefab",
    "weaponSha256": CLIENT / "Assets/GameObject/AssaultRifleEnemy.prefab",
    "coroutineSha256": CLIENT / "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
    "probeSha256": ROOT / "Server/tools/UnityGunslingerStandProbe.cs",
    "beforeProbeSha256": ROOT / "Server/tools/UnityGunslingerBeforeControllerProbe.cs",
    "exporterSha256": ROOT / "Server/tools/UnityGunslingerStandExport.cs",
}


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def unit_source():
    scene = CLIENT / "Assets/Scenes/MainScene.unity"
    blocks = blocks_in(scene.read_text(encoding="utf-8-sig"))
    _, behavior = blocks[36243]
    _, inventory = blocks[36478]
    if field(behavior, "unitDictionaryId") != "ID_UNIT-GUNSLINGER" or \
            field(behavior, "m_GameObject") != field(inventory, "m_GameObject"):
        raise ValueError("Gunslinger ordinary inventory source identity changed")
    weapons = inventory.split("  weapons:\n", 1)[1].split("  shield:", 1)[0]
    expected = r"weapon: \{fileID: 11470521, guid: d03f97fa25701ab42ab60f1fa86421ce, type: 2\}\s+type: 16\s+leftHand: 0"
    if len(re.findall(r"- weapon:", weapons)) != 1 or not re.search(expected, weapons):
        raise ValueError("Gunslinger no longer uses the observed right-hand reference rifle as runtime Colt")
    return {
        "sceneSha256": digest(scene),
        "behaviorFileId": 36243,
        "inventoryFileId": 36478,
        "weaponFileId": 11470521,
        "runtimeWeaponType": 16,
        "behaviorSha256": digest(CLIENT / "Assets/Scripts/Assembly-CSharp/SoldierBehaviourGunslinger.cs"),
        "enemyControllerSha256": digest(CLIENT / "Assets/Scripts/Assembly-CSharp/EnemyController.cs"),
    }


def verify(data):
    if data["version"] != 2 or data["unity"] != "2018.3.0f2" or \
            data["captureRate"] != 30 or data["timeScale"] != 1:
        raise ValueError("Native stand observation uses an unreviewed clock or Unity version")
    for key, path in SOURCE_FILES.items():
        if data[key] != digest(path):
            raise ValueError(f"Native stand input changed: {path}")
    if {row["name"] for row in data["clips"]} != {
            "colt_idle01", "colt_shooting_start", "colt_shooting_loop", "colt_shooting_stop"}:
        raise ValueError("Native stand clip set changed")
    for clip in data["clips"]:
        if clip["sha256"] != digest(CLIENT / "Assets/AnimationClip" / (clip["name"] + ".anim")):
            raise ValueError("Native stand clip source changed")
    if [row["scenario"] for row in data["scenarios"]] != ["AfterController", "BeforeController"]:
        raise ValueError("Both controlled source update orders are required")
    for scenario in data["scenarios"]:
        if any(len(scenario[key]) != 4 for key in ["preparations", "callbacks", "shots"]) or \
                len(scenario["frames"]) != 302:
            raise ValueError("Native stand observation is incomplete")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--publish", type=Path)
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args()
    if args.publish and args.check:
        parser.error("choose --publish or --check")
    data = json.loads((args.publish or OUTPUT).read_text(encoding="utf-8-sig"))
    verify(data)
    expected_unit = unit_source()
    if args.publish:
        data["unitSource"] = expected_unit
        OUTPUT.write_text(json.dumps(data, indent=2) + "\n", encoding="utf-8", newline="\n")
    elif data.get("unitSource") != expected_unit:
        raise ValueError("Gunslinger unit/weapon source differs from the native evidence")
    print("2 native update orders, 8 real callbacks/polls and 604 observed phase rows verified")
    print("SHA-256:", digest(OUTPUT))


if __name__ == "__main__":
    main()
