"""Compare the 1.4.0 MainScene card rows with the reviewed server identities.

This is an inventory, not a claim that a card has a working battle command.
Run with --check to ensure the checked-in report still matches the Client.
"""

import re
import json
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


def check_single_shield_source():
    source = (ASSETS / "Scripts/Assembly-CSharp/CardShieldDestroyer.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "if (item.fraction != callerFraction)",
        "UnityEngine.Random.Range(0f, mPlayerPoints.Count - 1)",
        "(int)Math.Round(num, 0)",
        "mPlayerPoints[index].shield.DestroyShield();",
    ]
    target_selector = behavior.split("private void DestroyRandomShield", 1)[1]
    target_selector = target_selector.split("public override void UseCard", 1)[0]
    if (any(rule not in behavior for rule in expected) or
        "item.point.shield.health > 0f" in target_selector):
        raise ValueError("Single-shield card targeting source changed")


def check_instant_medkit_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    if values.get("SmallMedKitCoef") != .1 or values.get("MedKitCoef") != .2:
        raise ValueError("Instant medkit source coefficients changed")
    scene = SCENE.read_text(encoding="utf-8-sig")
    for card_id in ("SMALLMEDKIT", "MEDKIT"):
        block = next((row for row in re.split(r"(?m)^--- ", scene)
                      if re.search(rf"(?m)^  id: {card_id}$", row)), None)
        if block is None or "  instatnt: 1\n" not in block:
            raise ValueError(f"Instant medkit scene state changed: {card_id}")
    small = (ASSETS / "Scripts/Assembly-CSharp/CardHealMeNowSmall.cs")
    base = (ASSETS / "Scripts/Assembly-CSharp/CardHealMeNow.cs")
    if ("CardConstants.rowIds.SmallMedKitCoef" not in small.read_text(encoding="utf-8-sig") or
        "CardConstants.rowIds.MedKitCoef" not in base.read_text(encoding="utf-8-sig")):
        raise ValueError("Instant medkit behavior source changed")


def check_big_medkit_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    if (values.get("BigMedKitCoefMin") != .25 or
        values.get("BigMedKitCoefMax") != .35 or
        values.get("BigMedKitTime") != 15):
        raise ValueError("BIGMEDKIT source timing or coefficients changed")
    scene = SCENE.read_text(encoding="utf-8-sig")
    block = next((row for row in re.split(r"(?m)^--- ", scene)
                  if re.search(r"(?m)^  id: BIGMEDKIT$", row)), None)
    source = (ASSETS / "Scripts/Assembly-CSharp/CardHealMeNowBig.cs")
    base = (ASSETS / "Scripts/Assembly-CSharp/CardHealMeNow.cs")
    if (block is None or "  instatnt: 0\n" not in block or
        "BigMedKitCoefMin" not in source.read_text(encoding="utf-8-sig") or
        "BigMedKitCoefMax" not in source.read_text(encoding="utf-8-sig") or
        "BigMedKitTime" not in source.read_text(encoding="utf-8-sig") or
        "mLastUpdate != (int)Time.time" not in base.read_text(encoding="utf-8-sig")):
        raise ValueError("BIGMEDKIT scene or periodic heal source changed")


def check_max_health_source():
    scene = SCENE.read_text(encoding="utf-8-sig")
    block = next((row for row in re.split(r"(?m)^--- ", scene)
                  if re.search(r"(?m)^  id: MAXHEALTHINC$", row)), None)
    source = (ASSETS / "Scripts/Assembly-CSharp/CardHealthierMyself.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    if (block is None or "  multiplierMaxHealth: 1.1\n" not in block or
        "maxHealth *= multiplierMaxHealth" not in behavior or
        "Heal(healAmount, isNetworkCopy: false)" not in behavior):
        raise ValueError("MAXHEALTHINC scene or healing source changed")


def check_empty_mag_source():
    source = (ASSETS / "Scripts/Assembly-CSharp/CardEmptyMag.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "PlayerController.GetEnemyOf(fraction)",
        "weaponInventory.usedWeapons[0].weapon.ammoLeftInClip = 0",
        "weaponInventory.usedWeapons[0].weapon.Reload()",
    ]
    if any(rule not in behavior for rule in expected):
        raise ValueError("EMPTYMAG first-weapon source behavior changed")


def check_bullet_sponge_source():
    source = (ASSETS / "Scripts/Assembly-CSharp/CardBulletSponge.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "private const float timeInSeconds = 60f",
        "private const float noDamageChance = 0.05f",
        "SetNoDamageChance(0.05f)",
        "mRemainingTime = 60f",
        "SetNoDamageChance(0f)",
    ]
    if any(rule not in behavior for rule in expected):
        raise ValueError("BULLETHARMLESS duration or dodge source changed")


def check_immortal_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    source = (ASSETS / "Scripts/Assembly-CSharp/CardSwiftImmortality.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    if (values.get("SwiftImmortalityTime") != 8 or
        "CardConstants.rowIds.SwiftImmortalityTime" not in behavior or
        "mPlayer.isImmortal = true" not in behavior or
        "mPlayer.isImmortal = false" not in behavior):
        raise ValueError("IMMORTAL duration or player authority source changed")


def check_slow_move_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    source = (ASSETS / "Scripts/Assembly-CSharp/CardBelovedEnemy.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "CardConstants.rowIds.BelovedEnemyTime",
        "CardConstants.rowIds.BelovedEnemySpeed",
        "mSavedSpeed = mPlayer.speed",
        "mPlayer.speed = mSlowedSpeed",
        "mPlayer.speed = mSavedSpeed",
    ]
    if (values.get("BelovedEnemyTime") != 10 or
        values.get("BelovedEnemySpeed") != .5 or
        any(rule not in behavior for rule in expected)):
        raise ValueError("SLOWMOVE absolute speed or timing source changed")


def check_disarmed_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    source = ASSETS / "Scripts/Assembly-CSharp/CardDisarmedAndLocked.cs"
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "CardConstants.rowIds.DisarmedTime",
        "mPlayer.weaponInventory.currentWeapon = mPlayer.weaponInventory.pistol",
        "mPlayer.weaponInventory.cannotChange = true",
        "mPlayer.weaponInventory.cannotChange = false",
    ]
    if values.get("DisarmedTime") != 5 or any(rule not in behavior for rule in expected):
        raise ValueError("DISARMED pistol selection or timing source changed")


def check_shield_reflection_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    source = ASSETS / "Scripts/Assembly-CSharp/CardShiedlsRefection.cs"
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "CardConstants.rowIds.ShiedlsRefectionTime",
        "if (item.fraction == fraction)",
        "shield.isImmortal = true",
        "mShields[j].isImmortal = false",
    ]
    if values.get("ShiedlsRefectionTime") != 15 or any(rule not in behavior for rule in expected):
        raise ValueError("REFLECTION allied shield immunity source changed")


def check_kevlar_up_source():
    content = ROOT / "Server/content/recovered-battle-content.json"
    sheets = json.loads(content.read_text(encoding="utf-8"))["sheets"]
    constants = next(sheet["rows"] for sheet in sheets
                     if sheet["type"] == "Google2u.CardConstants")
    values = {row["DBKEY"]: row["FLOATVALUE"] for row in constants}
    card = (ASSETS / "Scripts/Assembly-CSharp/CardKevlarUp.cs").read_text(encoding="utf-8-sig")
    armor = (ASSETS / "Scripts/Assembly-CSharp/Kevlar.cs").read_text(encoding="utf-8-sig")
    expected_card = ["CardConstants.rowIds.KevlarUpCoef", "playerOld.SetUpKevlar(kevlarStrength)"]
    expected_armor = [
        "kevlarDestroyableObject.maxHealth = kevlarStrength * destroyableObject.maxHealth",
        "Mathf.Min(damageInfo.originalDamage, kevlarDestroyableObject.health)",
        "Mathf.Max(0f, damageInfo.originalDamage)",
    ]
    if (values.get("KevlarUpCoef") != .2 or
        any(rule not in card for rule in expected_card) or
        any(rule not in armor for rule in expected_armor)):
        raise ValueError("KEVLARUP armor amount or damage source changed")


def check_shield_spawner_source():
    source = (ASSETS / "Scripts/Assembly-CSharp/CardShieldsSpawner.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    scene = (ASSETS / "Scenes/MainScene.unity").read_text(encoding="utf-8-sig")
    expected = [
        "public float multiplierRespawnRate = 0.7f",
        "list[0].shield.refreshTime * multiplierRespawnRate",
        "item2.shield.refreshTime = refreshTime",
    ]
    if (any(rule not in behavior for rule in expected) or
        "multiplierRespawnRate: 0.7" not in scene):
        raise ValueError("SHIELDSPAWNER repair multiplier source changed")


def check_backstab_source():
    source = (ASSETS / "Scripts/Assembly-CSharp/CardBackstab.cs")
    behavior = source.read_text(encoding="utf-8-sig")
    expected = [
        "enemyController.destroyableObject.health > 0f && enemyController.canBeFreezed",
        "UnityEngine.Random.Range(0f, list.Count - 1)",
        "(int)Math.Round(num, 0)",
        "damageAmount = list[index].destroyableObject.maxHealth",
    ]
    if any(rule not in behavior for rule in expected):
        raise ValueError("BACKSTAB soldier or damage source changed")


def direct_client_routes():
    source = CARD_MANAGER.read_text(encoding="utf-8-sig")
    use_card = source.split("public void UseCard(Card card)", 1)[1]
    use_card = use_card.split("private static bool IsSelfHostedMedkit", 1)[0]
    body = source.split("private async void UseSelfHostedCard", 1)[1]
    body = body.split("private static bool IsAcceptedSelfHostedCardReply", 1)[0]
    names = set(re.findall(r"card is (Card[A-Za-z]+)", body))
    names.update(re.findall(r"typeof\((Card[A-Za-z]+)\)", body))
    medkit_helper = source.split("private static bool IsSelfHostedMedkit", 1)[1]
    medkit_helper = medkit_helper.split("private async void UseSelfHostedCard", 1)[0]
    names.update(re.findall(r"card is (Card[A-Za-z]+)", medkit_helper))
    names.update(re.findall(r"typeof\((Card[A-Za-z]+)\)", medkit_helper))
    if (len(names) != 27 or
        "if (selfHosted != null && selfHosted.IsConnected)" not in use_card or
        "Self-hosted card is not supported yet" not in use_card or
        use_card.index("Self-hosted card is not supported yet") >
            use_card.index('mPhotonView.RPC("PlayCardRPC"')):
        raise ValueError("Normal Client self-hosted card route count changed")
    return names


def render():
    rows = source_rows()
    check_apocalypse_source()
    check_single_shield_source()
    check_instant_medkit_source()
    check_big_medkit_source()
    check_max_health_source()
    check_empty_mag_source()
    check_bullet_sponge_source()
    check_immortal_source()
    check_slow_move_source()
    check_disarmed_source()
    check_shield_reflection_source()
    check_kevlar_up_source()
    check_shield_spawner_source()
    check_backstab_source()
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
        f"The dispatcher currently has {len(routes)} card classes. While connected to",
        "the self-hosted match, unsupported cards are rejected before the",
        "recovered Photon fallback; they need host commands before admission.",
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
