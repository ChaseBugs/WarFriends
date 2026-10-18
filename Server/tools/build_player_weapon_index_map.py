"""Build the reviewed 1.4.0 weapon index bridge without publishing starter economy."""
import argparse
import hashlib
import json
from pathlib import Path

REPOSITORY = Path(__file__).resolve().parents[2]
EXPECTED_WEAPON_COUNT = 66
EXPECTED_SCENE_HASH = "5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff"
EXPECTED_BINDING_HASH = "2b8e0b531a6bf46bac199218bc74440938f8d535000565eb197a2384aae7daaa"
EXPECTED_RULE_SOURCES = {
    "LevelManager.cs", "PlayerInventory.cs", "WeaponLevelsSetup.cs", "UpgradeSlots.cs",
    "ActiveUnitsManager.cs", "CamosManager.cs", "DatabaseSerializedObjectGeneric.cs", "GameController.cs",
    "UpgradeSlot.cs", "UpgradeSlotSpecial.cs", "UpgradeSlotElite.cs", "PlayerProperties.cs", "WeaponInventory.cs",
}
OBSERVATION = REPOSITORY / "Server/docs/client-starter-loadout-observation.json"
BINDINGS = REPOSITORY / "Server/content/recovered-all-weapon-bindings.json"
TARGET = REPOSITORY / "Server/content/recovered-player-weapon-indexes.json"


def digest(path):
    return hashlib.sha256(path.read_bytes()).hexdigest()


def read_observation():
    observed = json.loads(OBSERVATION.read_text(encoding="utf-8"))
    if (observed["schemaVersion"] != 1 or observed["hasMetadataSideEffects"] is not False
            or type(observed["weaponIndexChecks"]) is not int
            or set(observed["source"]["ruleSha256"]) != EXPECTED_RULE_SOURCES
            or observed["weaponIndexChecks"] != 2 * EXPECTED_WEAPON_COUNT + 1
            or observed["source"]["mainSceneSha256"] != EXPECTED_SCENE_HASH):
        raise ValueError("The observed Client index proof is missing or unsupported.")
    scene = REPOSITORY / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
    if digest(scene) != EXPECTED_SCENE_HASH:
        raise ValueError("The active scene differs from the observed source.")
    for name, expected in observed["source"]["ruleSha256"].items():
        if Path(name).name != name:
            raise ValueError("Rule provenance must name one source file.")
        source = REPOSITORY / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp" / name
        if digest(source) != expected:
            raise ValueError(f"The active rule source differs from the observation: {name}")
    return observed


def create_mappings(observed):
    if digest(BINDINGS) != EXPECTED_BINDING_HASH:
        raise ValueError("The reviewed combat binding graph changed.")
    graph = json.loads(BINDINGS.read_text(encoding="utf-8"))
    expected = {row["id"]: row["inventoryIndex"] for row in graph["weapons"]}
    rows = observed["weapons"]
    if (len(rows) != EXPECTED_WEAPON_COUNT or len(expected) != EXPECTED_WEAPON_COUNT
            or {row["sourceId"] for row in rows} != set(expected)):
        raise ValueError("The complete reviewed weapon identity set is required.")
    result = []
    for order, row in enumerate(rows):
        if (type(row["sourceOrder"]) is not int or row["sourceOrder"] != order
                or type(row["inventoryIndex"]) is not int
                or row["inventoryIndex"] != expected[row["sourceId"]]):
            raise ValueError("A source identity/index pair differs from the actual combat graph.")
        result.append({"sourceId": row["sourceId"], "levelManagerIndex": order,
                       "inventoryIndex": row["inventoryIndex"]})
    return result


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--write", action="store_true", help="Write the reviewed identity-only artifact.")
    options = parser.parse_args()
    observed = read_observation()
    result = {"schemaVersion": 1, "clientVersion": "1.4.0", "observationSha256": digest(OBSERVATION),
              "mainSceneSha256": EXPECTED_SCENE_HASH, "combatBindingsSha256": EXPECTED_BINDING_HASH,
              "mappings": create_mappings(observed)}
    expected = (json.dumps(result, indent=2) + "\n").encode("utf-8")
    if options.write:
        TARGET.write_bytes(expected)
    elif not TARGET.exists() or TARGET.read_bytes() != expected:
        raise ValueError("The identity artifact differs; review a fresh observation before using --write.")
    print("PASS: complete source-ordered weapon identity bridge agrees with the reviewed combat graph")
    print("Observation SHA-256:", digest(OBSERVATION))
    print("Identity map SHA-256:", hashlib.sha256(expected).hexdigest())


if __name__ == "__main__":
    main()
