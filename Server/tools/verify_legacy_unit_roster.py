#!/usr/bin/env python3
"""Check current 1.4.0 player/helper scene bindings without claiming whole-scene export agreement."""

import hashlib
import json
import re
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"


def read_guid(path):
    return re.search(r"^guid: ([0-9a-f]{32})$", path.read_text(encoding="utf-8-sig"), re.M)[1]


def field_reference(block, name):
    match = re.search(r"^  " + re.escape(name) + r": \{fileID: (\d+)\}", block, re.M)
    if not match:
        raise ValueError(f"Missing unique scene pointer: {name}")
    return int(match[1])


def list_references(block, name):
    match = re.search(r"^  " + re.escape(name) + r":\n((?:  - .*\n)*)", block, re.M)
    if not match:
        raise ValueError(f"Missing scene reference list: {name}")
    identities = [int(value) for value in re.findall(r"fileID: (\d+)", match[1])]
    if len(set(identities)) != len(identities):
        raise ValueError("Duplicated role reference in " + name)
    return identities


def unit_sheet(behavior, blocks, schema_types):
    slots = blocks[field_reference(behavior, "upgradeSlots")]
    game_object = blocks[field_reference(slots, "m_GameObject")]
    found = []
    for identity in re.findall(r"- 114: \{fileID: (\d+)\}", game_object):
        match = re.search(r"^  m_Script:.*guid: ([0-9a-f]{32})", blocks[int(identity)], re.M)
        if match and schema_types.get(match[1], "").startswith("DBUpgradeSlots"):
            found.append("Google2u." + schema_types[match[1]])
    if len(found) != 1:
        raise ValueError("Unit must own exactly one attached Google2u upgrade component.")
    return found[0]


def inspect_roster():
    source = (ASSETS / "Scenes/MainScene.unity").read_bytes()
    scene = source.decode("utf-8-sig").replace("\r\n", "\n")
    blocks = {}
    for match in re.finditer(r"^--- !u!\d+ &(\d+)\n(.*?)(?=^--- !u!|\Z)", scene, re.M | re.S):
        if int(match[1]) in blocks:
            raise ValueError("Duplicated Unity file identity.")
        blocks[int(match[1])] = match[2]
    guid = read_guid(ASSETS / "Scripts/Assembly-CSharp/LevelManager.cs.meta")
    managers = [block for block in blocks.values() if re.search(r"m_Script:.*" + guid, block)]
    if len(managers) != 1:
        raise ValueError("LevelManager source binding must be unique.")
    schema_types = {read_guid(path): path.name.removesuffix(".cs.meta")
                    for path in (ASSETS / "Plugins/Assembly-CSharp-firstpass/Google2u").glob("*.cs.meta")}
    roles = {}
    for field in ("behaviours", "additionalBehaviours"):
        roles[field] = [unit_sheet(blocks[identity], blocks, schema_types)
                        for identity in list_references(managers[0], field)]
        if len(set(roles[field])) != len(roles[field]):
            raise ValueError("Multiple behaviors claimed the same unit sheet.")
    return roles, hashlib.sha256(source).hexdigest()


def main():
    roles, scene_digest = inspect_roster()
    package = json.loads((ROOT / "Server/content/recovered-battle-content.json").read_text(encoding="utf-8-sig"))
    rows = next(sheet["rows"] for sheet in package["sheets"] if sheet["type"] == "Google2u.ArmyUpgrades")
    players = {row["NAME"] for row in rows if 1 <= row["STARTINGTIER"] <= 6}
    helpers = {row["NAME"] for row in rows if row["STARTINGTIER"] == 0}
    if (len(rows) != 27 or len(players) != 24 or len(helpers) != 3 or players & helpers or
            set(roles["behaviours"]) != players or set(roles["additionalBehaviours"]) != helpers):
        raise ValueError("Current Client scene roles disagree with the catalog's player/helper classification.")
    print("PASS: current Client binds 24 player and 3 helper unit identities to the reviewed catalog roles")
    print("Scope: attached component identities only; complete table/provenance validation remains separate.")
    if scene_digest != package["mainSceneSha256"]:
        print("Known V07 whole-scene digest mismatch remains; no source digest was rewritten.")


if __name__ == "__main__":
    main()
