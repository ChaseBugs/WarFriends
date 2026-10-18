"""Bind native weapon selection, attachment and presenter evidence to current source bytes."""

import argparse
import hashlib
import json
import math
import shutil
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
CLIENT = ROOT / "Clients/ExportedProject"
OUTPUT = ROOT / "Server/content/gunslinger-weapon-presenter-unity-reference.json"
IMAGES = ROOT / "Server/docs/images"
TOOLS = {
    "Assets/Editor/UnityGunslingerWeaponAttachmentAudit.cs": ROOT / "Server/tools/UnityGunslingerWeaponAttachmentAudit.cs",
    "Assets/UnityGunslingerReferenceSwapper.cs": ROOT / "Server/tools/UnityGunslingerReferenceSwapper.cs",
}
SOURCES = {
    "Assets/Scripts/Assembly-CSharp/" + name + ".cs"
    for name in [
        "SelfHostedGunslingerWeaponAttachment", "SelfHostedInfantryWeaponAppearance", "SelfHostedVisualHierarchy",
        "SelfHostedInfantryVisualFactory", "SelfHostedInfantryVisual", "SelfHostedInfantryPresenter",
        "SelfHostedRiflePoseRenderer", "SelfHostedInfantryUpgradeSelection", "FakeRigidBodySwapper",
        "SelfHostedInfantrySkinAppearance",
        "SelfHostedInfantryShieldAppearance",
        "SoldierBehaviour", "UpgradeSlotsBaseSoldier",
        "UpgradeSlotsGunslicer", "SoldierParts", "SpawningManager",
    ]
} | {
    "Assets/Plugins/Assembly-CSharp-firstpass/SkinnedMeshTools.cs",
    "Assets/Plugins/WarFriends.Networking/War.Shared.dll", "Assets/Plugins/WarFriends.Networking/War.Client.dll",
    "Assets/GameObject/enemy.prefab", "Assets/GameObject/AssaultRifleEnemy.prefab", "Assets/Scenes/MainScene.unity",
} | set(TOOLS)
IMAGE_NAMES = ["gunslinger-hand.png", "gunslinger-holstered.png"]


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def asset_path(value):
    if not isinstance(value, str) or not value.startswith("Assets/") or ".." in Path(value).parts:
        raise ValueError("Unexpected native asset path")
    path = (CLIENT / value).resolve()
    if not path.is_relative_to(CLIENT.resolve()):
        raise ValueError("Native asset path escaped the active Client")
    return path


def verify(data):
    if data["version"] != 1 or data["unity"] != "2018.3.0f2" or \
            data["normalCases"] != 2 or data["eliteCases"] != 2 or data["presenterChecks"] != 4:
        raise ValueError("Unexpected native presenter evidence boundary")
    if set(data["sourceHashes"]) != SOURCES:
        raise ValueError("Native presenter source set changed")
    for name, expected in data["sourceHashes"].items():
        if digest(TOOLS[name] if name in TOOLS else asset_path(name)) != expected:
            raise ValueError(f"Native presenter input changed: {name}")
    cases = data["cases"]
    if [(row["IsElite"], row["Level"]) for row in cases] != [(False, 0), (False, 1), (True, 0), (True, 1)]:
        raise ValueError("Native source threshold coverage changed")
    for row in cases:
        if row["ModelNumber"] != 25 or row["ResourcePath"] != "Weapons/Pistol_Gunslinger/gunslinger":
            raise ValueError("Source constant Gunslinger appearance changed")
        for key in ["modelPrefab", "mesh", "material"]:
            if digest(asset_path(row[key])) != row[key + "Sha256"]:
                raise ValueError(f"Native source {key} changed")
        if any(len(row[key]) != 3 or not all(math.isfinite(value) for value in row[key])
               for key in ["hand", "holster"]) or math.dist(row["hand"], row["holster"]) <= 0.00001:
            raise ValueError("Native attachment positions are not finite and distinct")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--publish", type=Path)
    parser.add_argument("--check", action="store_true")
    args = parser.parse_args()
    if args.publish and args.check:
        parser.error("choose --publish or --check")
    data = json.loads((args.publish or OUTPUT).read_text(encoding="utf-8-sig"))
    verify(data)
    if args.publish:
        IMAGES.mkdir(exist_ok=True)
        for name in IMAGE_NAMES:
            shutil.copyfile(args.publish.parent / name, IMAGES / name)
        data["previewImages"] = {name: digest(IMAGES / name) for name in IMAGE_NAMES}
        OUTPUT.write_text(json.dumps(data, indent=2) + "\n", encoding="utf-8", newline="\n")
    if data.get("previewImages") != {name: digest(IMAGES / name) for name in IMAGE_NAMES}:
        raise ValueError("Native preview images changed")
    print("4 source model selections, 12 source attachment comparisons and 4 decoded presenter checks verified")
    print("SHA-256:", digest(OUTPUT))


if __name__ == "__main__":
    main()
