"""Compare the 1.4.0 MainScene card rows with the reviewed server identities.

This is an inventory, not a claim that a card has a working battle command.
Run with --check to ensure the checked-in report still matches the Client.
"""

import re
import sys
from pathlib import Path


ROOT = Path(__file__).resolve().parents[2]
SCENE = ROOT / "Clients/ExportedProject/Assets/Scenes/MainScene.unity"
ASSETS = ROOT / "Clients/ExportedProject/Assets"
IDENTITIES = ROOT / "Server/src/War.BattleServer/WarCardSourceIdentityCatalog.cs"
CARD_MANAGER = ROOT / "Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/CardManager.cs"
OUTPUT = ROOT / "Server/docs/BATTLE_CARD_SOURCE_INVENTORY.md"


def source_rows():
    scene = SCENE.read_text(encoding="utf-8-sig")
    pattern = (r"(?m)^  - NAME: ([A-Z0-9_]+)\n"
               r"    RARITY: (\d+)\n"
               r"    FROMMISSION: (\d+)\n"
               r"    IMPLEMENTED: ([01])")
    rows = re.findall(pattern, scene)
    ids = [row[0] for row in rows]
    if len(rows) != 67 or len(ids) != len(set(ids)):
        raise ValueError("MainScene card definition count or identity changed")
    return rows


def reviewed_classes():
    source = IDENTITIES.read_text(encoding="utf-8-sig")
    pattern = r'\["(Card[A-Za-z]+)"\]\s*=\s*\[([^\]]+)\]'
    result = {}
    for class_name, value in re.findall(pattern, source):
        for source_id in re.findall(r'"([A-Z0-9_]+)"', value):
            if source_id in result:
                raise ValueError(f"Duplicate reviewed card identity: {source_id}")
            result[source_id] = class_name
    return result


def scene_classes(source_ids):
    guid_to_class = {}
    for meta in (ASSETS / "Scripts/Assembly-CSharp").glob("Card*.cs.meta"):
        match = re.search(r"(?m)^guid: ([0-9a-f]{32})$",
                          meta.read_text(encoding="utf-8-sig"))
        if match:
            guid_to_class[match.group(1)] = meta.name.removesuffix(".cs.meta")

    result = {}
    for block in re.split(r"(?m)^--- ", SCENE.read_text(encoding="utf-8-sig")):
        card_id = re.search(r"(?m)^  id: ([A-Z0-9_]+)$", block)
        script = re.search(r"m_Script: .*guid: ([0-9a-f]{32})", block)
        if not card_id or not script or card_id.group(1) not in source_ids:
            continue
        class_name = guid_to_class.get(script.group(1))
        if class_name is None or card_id.group(1) in result:
            raise ValueError(f"Unresolved or duplicate scene card: {card_id.group(1)}")
        result[card_id.group(1)] = class_name
    return result


def check_apocalypse_source():
    scene = SCENE.read_text(encoding="utf-8-sig")
    card_block = next((block for block in re.split(r"(?m)^--- ", scene)
                       if re.search(r"(?m)^  id: APOCALYPSE$", block)), None)
    source = (ASSETS / "Scripts/Assembly-CSharp/CardMassShieldDestroyer.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    if (card_block is None or "  shieldCount: 3\n" not in card_block or
        "item.point.shield.health > 0f" not in behavior or
        "mPlayerPoints.RemoveAt(index);" not in behavior or
        "shield.DestroyShield();" not in behavior):
        raise ValueError("Apocalypse shield targeting source changed")


def direct_client_routes():
    source = CARD_MANAGER.read_text(encoding="utf-8-sig")
    body = source.split("private async void UseSelfHostedCard", 1)[1]
    body = body.split("private static bool IsAcceptedSelfHostedCardReply", 1)[0]
    names = set(re.findall(r"card is (Card[A-Za-z]+)", body))
    names.update(re.findall(r"typeof\((Card[A-Za-z]+)\)", body))
    if len(names) != 14:
        raise ValueError("Normal Client self-hosted card route count changed")
    return names


def render():
    rows = source_rows()
    check_apocalypse_source()
    classes = reviewed_classes()
    scene = scene_classes({row[0] for row in rows})
    routes = direct_client_routes()
    unknown = sorted(set(classes) - {row[0] for row in rows})
    if unknown:
        raise ValueError(f"Reviewed card identity absent from MainScene: {unknown}")
    for source_id, class_name in classes.items():
        if scene.get(source_id) != class_name:
            raise ValueError(f"Reviewed card class disagrees with scene: {source_id}")
    available = [row for row in rows if row[3] == "1"]
    disabled = [row for row in rows if row[3] == "0"]
    mistakenly_reviewed = sorted(source_id for source_id, _, _, _ in disabled
                                if source_id in classes)
    if mistakenly_reviewed:
        raise ValueError(f"Source-disabled cards entered server authority: {mistakenly_reviewed}")
    lines = [
        "# Recovered 1.4.0 battle-card source inventory",
        "",
        "Source: `Clients/ExportedProject/Assets/Scenes/MainScene.unity`",
        "`CardDefinitions.Rows`, cross-checked against",
        "`Server/src/War.BattleServer/WarCardSourceIdentityCatalog.cs` and",
        "the normal Client `CardManager.UseSelfHostedCard` dispatcher.",
        "The scene contains 67 unique rows: 57 marked `IMPLEMENTED: 1` and",
        "10 marked `IMPLEMENTED: 0`. A scene flag does not prove that the",
        "self-hosted Worker or normal Unity battle path can activate the card.",
        "Every source-enabled row has a scene Card component; its class is",
        "resolved through the component's MonoScript GUID and `.cs.meta`.",
        "A dash in the reviewed column means the server catalog has not",
        "pinned that class/ID pair. Disabled rows may lack a scene component.",
        "A direct Client route is only a dispatch path, not end-to-end proof.",
        "The dispatcher currently has 14 card classes, and its fallback for",
        "other cards still calls Photon; those cards need a host path before",
        "offline play can admit them.",
        "",
        "## Source-enabled rows",
        "",
        "| Source ID | Rarity | Scene class | Reviewed | Direct host route |",
        "|---|---:|---|---|---|",
    ]
    for source_id, rarity, mission, _ in available:
        scene_class = scene.get(source_id)
        if scene_class is None:
            raise ValueError(f"Source-enabled card lacks a scene component: {source_id}")
        lines.append(f"| `{source_id}` | {rarity} | `{scene_class}` | "
                     f"{'yes' if source_id in classes else 'no'} | "
                     f"{'yes' if scene_class in routes else 'no'} |")
    lines += ["", "## Source-disabled rows", "",
              "| Source ID | Rarity | Scene class | Reviewed |",
              "|---|---:|---|---|"]
    for source_id, rarity, mission, _ in disabled:
        class_name = scene.get(source_id)
        lines.append(f"| `{source_id}` | {rarity} | "
                     f"{('`' + class_name + '`') if class_name else '—'} | "
                     f"{'yes' if source_id in classes else 'no'} |")
    lines += ["", "`PARALYZE` has a `CardParalyzeThese` class and artwork, but",
              "its MainScene row is source-disabled. Do not enable it as a",
              "playable 1.4.0 War Card without new source evidence.", ""]
    if len(available) != 57 or len(disabled) != 10:
        raise ValueError("Unexpected MainScene card availability")
    return "\n".join(lines)


def main():
    result = render()
    if sys.argv[1:] == ["--check"]:
        if OUTPUT.read_text(encoding="utf-8") != result:
            raise ValueError("Battle card inventory is stale")
    elif sys.argv[1:]:
        raise ValueError("Only --check is supported")
    else:
        OUTPUT.write_text(result, encoding="utf-8")
    print("67 MainScene card rows audited: 57 enabled, 10 source-disabled")


if __name__ == "__main__":
    main()
