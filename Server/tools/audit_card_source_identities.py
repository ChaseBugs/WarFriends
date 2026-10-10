"""Check the Worker card ID map against recovered 1.4.0 MainScene components."""

from pathlib import Path
import hashlib
import json
import re


ROOT = Path(__file__).resolve().parents[2]
ASSETS = ROOT / "Clients/ExportedProject/Assets"
SCRIPTS = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
CATALOG = ROOT / "Server/src/War.BattleServer/WarCardSourceIdentityCatalog.cs"
EFFECTS = ROOT / "Server/src/War.BattleServer/WarCardEffectCatalog.cs"
UNIT_CARDS = ROOT / "Server/src/War.BattleServer/CardSpawnUnitSourceCatalog.cs"
CONTENT = ROOT / "Server/content/recovered-battle-content.json"

source = CATALOG.read_text(encoding="utf-8")
declared = {
    (card_class, card_id)
    for card_class, values in re.findall(r'\["(Card\w+)"\]\s*=\s*\[([^\]]+)\]', source)
    for card_id in re.findall(r'"([A-Z0-9_]+)"', values)
}
classes = {card_class for card_class, _ in declared}
supported = set(re.findall(r'\["(Card\w+)"\]\s*=\s*new\(', EFFECTS.read_text(encoding="utf-8")))
assert classes == supported, ("Worker card classes differ", classes ^ supported)

guid_to_class = {}
for card_class in classes:
    script = (SCRIPTS / f"{card_class}.cs").read_text(encoding="utf-8")
    assert re.search(rf"class {card_class}\s*:\s*Card\b", script), card_class
    assert "override CardManager.CardType rarity" not in script, card_class
    meta = (SCRIPTS / f"{card_class}.cs.meta").read_text(encoding="utf-8")
    guid_to_class[re.search(r"^guid: ([0-9a-f]{32})$", meta, re.M).group(1)] = card_class

scene = SCENE.read_text(encoding="utf-8", errors="replace")
content = json.loads(CONTENT.read_text(encoding="utf-8"))
assert content["mainSceneSha256"] == hashlib.sha256(SCENE.read_bytes()).hexdigest()
content_sheets = {sheet["type"].removeprefix("Google2u."): sheet
                  for sheet in content["sheets"]}
rarity = {
    name: int(value)
    for name, value in re.findall(r"^  - NAME: ([A-Z0-9_]+)\r?\n    RARITY: (-?\d+)", scene, re.M)
}
observed = set()
for block in scene.split("--- !u!"):
    script = re.search(r"m_Script: \{fileID: 11500000, guid: ([0-9a-f]{32})", block)
    if script and script.group(1) in guid_to_class:
        identity = re.search(r"^  id: ([A-Z0-9_]+)$", block, re.M)
        if identity:
            card_id = identity.group(1)
            assert rarity.get(card_id) in (1, 2, 3), (card_id, rarity.get(card_id))
            observed.add((guid_to_class[script.group(1)], card_id))

assert observed == declared, ("Worker card source IDs differ", observed - declared, declared - observed)

# CardSpawnUnit uses a different LevelBehaviour and timing for each source ID.
# Match the catalog to the actual scene components, including each behaviour's
# card ID and script type. Ordinary army option counts are not card counts.
unit_by_behaviour = {
    "SoldierBehaviourBazooka": "ID_UNIT-ROCKETSOLDIER",
    "SoldierBehaviourMinigunner": "ID_UNIT-MINIGUNNER",
    "SoldierBehaviourParachuter": "ID_UNIT-PARATROOPER",
    "SoldierBehaviourSniper": "ID_UNIT-SNIPER",
    "SoldierBehaviourSwat": "ID_UNIT-SWAT",
    "SoldierBehaviourGrennader": "ID_UNIT-GRENADIER",
    "DroneBehaviour": "ID_UNIT-DRONE",
}
slot_class_by_unit = {
    "ID_UNIT-ROCKETSOLDIER": "UpgradeSlotsBazooka",
    "ID_UNIT-MINIGUNNER": "UpgradeSlotsMinigunner",
    "ID_UNIT-PARATROOPER": "UpgradeSlotsParachuter",
    "ID_UNIT-SNIPER": "UpgradeSlotsSniper",
    "ID_UNIT-SWAT": "UpgradeSlotsSwat",
    "ID_UNIT-GRENADIER": "UpgradeSlotsGrennader",
    "ID_UNIT-DRONE": "UpgradeSlotsDrone",
}
behaviour_guid_to_unit = {}
for class_name, unit_id in unit_by_behaviour.items():
    meta = (SCRIPTS / f"{class_name}.cs.meta").read_text(encoding="utf-8")
    guid = re.search(r"^guid: ([0-9a-f]{32})$", meta, re.M).group(1)
    behaviour_guid_to_unit[guid] = unit_id
slot_guid_by_unit = {}
for unit_id, class_name in slot_class_by_unit.items():
    meta = (SCRIPTS / f"{class_name}.cs.meta").read_text(encoding="utf-8")
    slot_guid_by_unit[unit_id] = re.search(r"^guid: ([0-9a-f]{32})$", meta, re.M).group(1)
sheet_guids = {}
for meta_path in (ASSETS / "Plugins/Assembly-CSharp-firstpass/Google2u").glob("DBUpgradeSlots*.cs.meta"):
    meta = meta_path.read_text(encoding="utf-8")
    sheet_guid = re.search(r"^guid: ([0-9a-f]{32})$", meta, re.M).group(1)
    sheet_guids[sheet_guid] = meta_path.name.removesuffix(".cs.meta")

blocks = {}
for block in scene.split("--- !u!"):
    component = re.match(r"\d+ &(\d+)", block)
    if component:
        blocks[int(component.group(1))] = block

spawn_guid = next(guid for guid, name in guid_to_class.items() if name == "CardSpawnUnit")
scene_unit_cards = set()
for component_id, block in blocks.items():
    if f"guid: {spawn_guid}" not in block:
        continue
    card_id = re.search(r"^  id: ([A-Z0-9_]+)$", block, re.M).group(1)
    behaviour_id = int(re.search(r"^  behaviour: \{fileID: (\d+)\}$", block, re.M).group(1))
    count = int(re.search(r"^  count: (\d+)$", block, re.M).group(1))
    delay = float(re.search(r"^  spawnDelay: ([0-9.]+)$", block, re.M).group(1))
    behaviour = blocks[behaviour_id]
    assert re.search(rf"^  cardId: {card_id}$", behaviour, re.M), card_id
    behaviour_guid = re.search(r"m_Script: \{fileID: 11500000, guid: ([0-9a-f]{32})", behaviour).group(1)
    unit_id = behaviour_guid_to_unit[behaviour_guid]
    slot_id = int(re.search(r"^  upgradeSlots: \{fileID: (\d+)\}$", behaviour, re.M).group(1))
    slot = blocks[slot_id]
    assert f"guid: {slot_guid_by_unit[unit_id]}" in slot, (card_id, slot_id)
    slot_game_object = int(re.search(r"^  m_GameObject: \{fileID: (\d+)\}$", slot, re.M).group(1))
    sibling_ids = [int(value) for value in re.findall(
        r"- 114: \{fileID: (\d+)\}", blocks[slot_game_object])]
    sheet_ids = [sibling for sibling in sibling_ids if re.search(
        r"m_Script: \{fileID: 11500000, guid: ([0-9a-f]{32})", blocks[sibling]).group(1)
        in sheet_guids]
    assert len(sheet_ids) == 1, (card_id, sheet_ids)
    sheet_id = sheet_ids[0]
    sheet_guid = re.search(r"m_Script: \{fileID: 11500000, guid: ([0-9a-f]{32})",
                           blocks[sheet_id]).group(1)
    sheet_type = sheet_guids[sheet_guid]
    names_text = re.search(r"^  rowNames:\n(.*?)^  Rows:", blocks[sheet_id], re.M | re.S).group(1)
    row_names = re.findall(r"^  - ([A-Z0-9_]+)$", names_text, re.M)
    sheet_rows = content_sheets[sheet_type]["rows"]
    assert len(row_names) == len(sheet_rows), (card_id, sheet_type)
    if "CARDS_MIN" in row_names and "CARDS_MAX" in row_names:
        min_row = row_names.index("CARDS_MIN")
        max_row = row_names.index("CARDS_MAX")
        assert max_row == min_row + 1
    else:
        assert card_id == "ELITESNIPER" and "VEHICLE_MIN" in row_names and \
            "VEHICLE_MAX" in row_names, card_id
        # UpgradeSlots.LoadDataForCard logs the missing rows and uses zero.
        min_row = max_row = 0
    for row in (sheet_rows[min_row], sheet_rows[max_row]):
        assert 0 < row["HP"] <= 10_000_000 and 0 < row["DAMAGE"] <= 10_000_000, card_id
    assert sheet_rows[min_row]["HP"] <= sheet_rows[max_row]["HP"], card_id
    scene_unit_cards.add((card_id, component_id, behaviour_id, slot_id,
                          sheet_id, min_row, max_row, unit_id, count, delay))

catalog_text = UNIT_CARDS.read_text(encoding="utf-8")
catalog_unit_cards = {
    (card_id, int(component), int(behaviour), int(slot), int(sheet),
     int(minimum), int(maximum), unit_id, int(count), float(delay))
    for card_id, component, behaviour, slot, sheet, minimum, maximum, unit_id, count, delay in re.findall(
        r'new\("([A-Z0-9_]+)",\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+),\s*(\d+),\s*'
        r'"(ID_UNIT-[A-Z0-9]+)",\s*(\d+),\s*([0-9.]+)f?\)',
        catalog_text)
}
assert len(scene_unit_cards) == len(catalog_unit_cards) == 7
assert scene_unit_cards == catalog_unit_cards, (
    "Worker unit-card scene bindings differ", scene_unit_cards - catalog_unit_cards,
    catalog_unit_cards - scene_unit_cards)

buddy = (SCRIPTS / "CardBuddy.cs").read_text(encoding="utf-8")
assert "override CardManager.CardType rarity => CardManager.CardType.Buddy" in buddy
print(f"PASS: {len(observed)} recovered non-buddy card identities across {len(classes)} Worker classes; "
      f"{len(scene_unit_cards)} unit-card scene bindings")
