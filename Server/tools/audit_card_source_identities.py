"""Check the Worker card ID map against recovered 1.4.0 MainScene components."""

from pathlib import Path
import re


ROOT = Path(__file__).resolve().parents[2]
SCRIPTS = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp"
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
CATALOG = ROOT / "Server/src/War.BattleServer/WarCardSourceIdentityCatalog.cs"
EFFECTS = ROOT / "Server/src/War.BattleServer/WarCardEffectCatalog.cs"

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
buddy = (SCRIPTS / "CardBuddy.cs").read_text(encoding="utf-8")
assert "override CardManager.CardType rarity => CardManager.CardType.Buddy" in buddy
print(f"PASS: {len(observed)} recovered non-buddy card identities across {len(classes)} Worker classes")
