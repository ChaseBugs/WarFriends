"""Build source-exact initial subsystem state without granting purchases or wallet rewards."""
import argparse
import hashlib
import json
from pathlib import Path
from build_player_weapon_index_map import REPOSITORY, OBSERVATION, read_observation, create_mappings

EXPECTED_UNIT_COUNT = 24
EXPECTED_VISUAL_COUNT = 86
TARGET = REPOSITORY / "Server/content/recovered-initial-client-state.json"


def create_levels(observed):
    weapons = {row["sourceId"]: {"bought": False, "boughtIndex": 0,
               "showed": row["unlockRankIndex"] == 0, "borrowed": False} for row in observed["weapons"]}
    units = {}
    equipped_types = set()
    for row in observed["units"]:
        equipped = row["hasImplicitFreeOwnership"] or row["isTutorialUnit"]
        if equipped:
            if row["unitType"] in equipped_types:
                raise ValueError("Initial unit selection requires review for multiple owned units in one category.")
            equipped_types.add(row["unitType"])
        units[row["sourceId"]] = {"bought": False, "boughtIndex": 0, "specialSlot": 0,
            "showed": row["unlockRankIndex"] == 0, "tier": row["startingTier"], "borrowed": False,
            "wasEquipped": equipped, "equipped": equipped, "eliteSlot": 0, "parts": 0}
    if len(units) != EXPECTED_UNIT_COUNT or equipped_types != {0, 1, 2, 3}:
        raise ValueError("The complete four-category initial unit state is required.")
    delivery = {"activationNeeded": False, "boughtIndex": 0, "end": 0,
                "itemId": None, "slotId": 0, "start": 0}
    return {"savedArmies": units, "savedWeapons": weapons,
            "unitDelivery": delivery.copy(), "weaponDelivery": delivery.copy()}


def create_inventory(observed):
    slots = {}
    for order, slot in enumerate(observed["inventorySlots"]):
        if slot["sourceOrder"] != order or slot["slotIndex"] != order:
            raise ValueError("Initial inventory slot order is not canonical.")
        candidates = [row for row in observed["weapons"] if row["category"] & slot["category"] == row["category"]]
        selected = min(candidates, key=lambda row: (row["unlockRankIndex"], row["sourceOrder"]))
        slots[str(order)] = {"name": selected["sourceId"], "weaponIndex": selected["sourceOrder"]}
    if len(slots) != 4:
        raise ValueError("All four initial weapon slots are required.")
    return {"slots": slots}


def create_decals(observed):
    names = observed["serialized"]["DecalManagerData"]["visuals"]
    if len(names) != EXPECTED_VISUAL_COUNT:
        raise ValueError("The complete initial visual identity set is required.")
    visuals = {name: {"bought": False, "showed": False, "expiresOn": 0, "borrowed": False,
                     "parts": 0, "notificate": False} for name in names}
    defaults = ["CAMOS_DEFAULT", "HELMETS_EMPTY", "HEAD_EMPTY", "BANDS_EMPTY"]
    return {"visuals": visuals, "slots": {str(i): {"equippedID": name} for i, name in enumerate(defaults)},
            "previousHeadDecal": ""}


def build_document(observation_bytes):
    observed = read_observation(observation_bytes)
    create_mappings(observed)
    if observed["context"]["isTutorial"] is not False:
        raise ValueError("Initial lobby state requires the observed non-tutorial context.")
    serialized = {"InventoryData": create_inventory(observed), "LevelManagerData": create_levels(observed),
                  "DecalManagerData": create_decals(observed)}
    if serialized != observed["serialized"]:
        raise ValueError("Source-derived initialization differs from the actual Client observation.")
    result = {"schemaVersion": 1, "clientVersion": "1.4.0",
              "observationSha256": hashlib.sha256(observation_bytes).hexdigest(),
              "mainSceneSha256": observed["source"]["mainSceneSha256"], "serialized": serialized}
    return result


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument("--write", action="store_true", help="Write the reviewed initial subsystem state.")
    options = parser.parse_args()
    result = build_document(OBSERVATION.read_bytes())
    expected = (json.dumps(result, indent=2) + "\n").encode("utf-8")
    if options.write:
        TARGET.write_bytes(expected)
    elif not TARGET.exists() or TARGET.read_bytes() != expected:
        raise ValueError("Initial state differs; review the source rules before using --write.")
    print("PASS: source-derived initial state exactly matches the observed Client, without purchase/reward grants")
    print("Initial state SHA-256:", hashlib.sha256(expected).hexdigest())


if __name__ == "__main__":
    main()
