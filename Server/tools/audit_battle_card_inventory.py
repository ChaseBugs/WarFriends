"""Compare the 1.4.0 MainScene card rows with the reviewed server identities.

This is an inventory, not a claim that a card has a working battle command.
Run with --check to ensure the checked-in report still matches the Client.
"""

import re
import json
import sys
import hashlib
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


def check_grenadier_card_setup():
    soldier = (ASSETS / "Scripts/Assembly-CSharp/SoldierBehaviourGrennader.cs")
    behavior = soldier.read_text(encoding="utf-8-sig")
    required = [
        "UnityEngine.Random.value < base.soldierBehaviourDefinititon.switchToSecondaryProb",
        "!mUseExternalWeapon",
        "grenadeAmmoSetup.damageAmount = base.mBehaviourDef.grenadeMinDamage;",
        "grenadeAmmoSetup.explodeDamageAmount = base.mBehaviourDef.grenadeExplodeDamage;",
        "grenadeAmmoSetup.playerBehindShieldRatio = upgradeSlots.playerBehindShieldDamageRatio;",
        "grenadeAmmoSetup.explodeAfterTime = 3f;",
    ]
    if any(line not in behavior for line in required):
        raise ValueError("Grenadier card grenade behavior changed")
    soldier_definition = (ASSETS /
        "Scripts/Assembly-CSharp/SoldierBehaviourDefinititon.cs")
    interpolation = soldier_definition.read_text(encoding="utf-8-sig").split(
        "public override BehaviourDefinititon Interpolate", 1)[1].split(
        "public override void ScaleByPerk", 1)[0]
    if ("(SoldierBehaviourDefinititon)d1.Copy()" not in interpolation or
        "switchToSecondaryProb =" in interpolation or
        "useSecondaryWeapon =" in interpolation):
        raise ValueError("Grenadier card secondary chance is no longer copied")
    soldier_runtime = (ASSETS / "Scripts/Assembly-CSharp/SoldierBehaviour.cs")
    runtime = soldier_runtime.read_text(encoding="utf-8-sig")
    if ("mFireBatchSize = UnityEngine.Random.Range(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon.fireBatchSizeMax);" not in runtime or
        "mFireBatchSize = 1;" not in runtime or
        "Shoot(targetPosition, isFake: false);" not in runtime):
        raise ValueError("Grenadier one-shot secondary sequence changed")
    enemy = (ASSETS / "Scripts/Assembly-CSharp/EnemyController.cs")
    enemy_source = enemy.read_text(encoding="utf-8-sig")
    if ("ShootFromCover(!mCoverShotRight, 0.7f);" not in enemy_source or
        "mNextEnemyChangeTime = mTime + (float)UnityEngine.Random.Range(10, 20);" not in enemy_source or
        "mNextEnemyChangeTime += 10f;" not in enemy_source):
        raise ValueError("Grenadier Corner timing changed")
    spawning = (ASSETS / "Scripts/Assembly-CSharp/SpawningManager.cs")
    next_point = spawning.read_text(encoding="utf-8-sig").split(
        "public EnemyPoint GetNextFreeEnemyPoint", 1)[1].split(
        "public List<EnemyPoint> GetFreeEnemyPoints", 1)[0]
    if ("soldierBehaviour.AcceptsPoint(enemyPoint2)" not in next_point or
        "enemyPoint2.isFree" not in next_point or
        "enemyPoint2 != enemyPoint" not in next_point or
        "Random.Range(0, mAllPosiblePointsForEnemy.Count)" not in next_point):
        raise ValueError("Grenadier Corner change selection changed")

    scene = SCENE.read_text(encoding="utf-8-sig")
    grenadier = scene.split("--- !u!114 &49788\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    if ("  enemyPointType: 14\n" not in grenadier or
        "    useSecondaryWeapon: 1\n" not in grenadier or
        "    switchToSecondaryProb: 0.4\n" not in grenadier):
        raise ValueError("Grenadier card enemy-point mask changed")
    inventory = scene.split("--- !u!114 &41066\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    if ("cardWeapons:\n  - weapon: {fileID: 11431434, guid: 16439357c0b8cbc4a91424818b10119d, type: 2}" not in inventory or
        "  - weapon: {fileID: 11419550, guid: bd74fc4b54938454a92a050c5517d60b, type: 2}" not in inventory):
        raise ValueError("Grenadier card secondary weapon binding changed")

    grenade = (ASSETS / "GameObject/GrenadeEnemy.prefab").read_text(
        encoding="utf-8-sig")
    for field in ("  angle: 45\n", "  throwDistance: 0\n",
                  "  deadRadius: 0.9\n", "  hurtRadius: 1.2\n"):
        if field not in grenade:
            raise ValueError("Grenadier card throw or blast prefab changed")
    grenade_weapon = grenade.split("--- !u!114 &11419550\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    grenade_root = grenade.split("--- !u!4 &454010\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    soldier_parts = (ASSETS / "Scripts/Assembly-CSharp/SoldierParts.cs").read_text(
        encoding="utf-8-sig")
    gun = (ASSETS / "Scripts/Assembly-CSharp/Gun.cs").read_text(
        encoding="utf-8-sig")
    if ("  spawnPoint: {fileID: 454010}\n" not in grenade_weapon or
        "  shootOffset: {x: 0, y: 0, z: 0}\n" not in grenade_weapon or
        "  m_Father: {fileID: 0}\n" not in grenade_root or
        "weapon.transform.parent = ((!weaponPrefab.leftHand) ? gunSnapPointNotScaled.transform" not in soldier_parts or
        "weapon.transform.localPosition = Vector3.zero;" not in soldier_parts or
        "ammo.Fire(spawnPoint.transform.position + shotOffset, position);" not in gun):
        raise ValueError("Grenadier card muzzle attachment source changed")
    rigidbody = grenade.split("--- !u!54 &5469143\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    collider = grenade.split("--- !u!136 &13659786\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    child = grenade.split("--- !u!4 &491323\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    ammo = (ASSETS / "Scripts/Assembly-CSharp/GrenadeAmmoBase.cs").read_text(
        encoding="utf-8-sig")
    if ("  m_UseGravity: 1\n" not in rigidbody or
        "  m_Radius: 0.05486127\n" not in collider or
        "  m_Material: {fileID: 0}\n" not in collider or
        "  m_LocalScale: {x: 2, y: 2, z: 2}\n" not in child or
        "mRigidBody.drag = 0.2f;" not in ammo or
        "mRigidBody.drag = 6f;" not in ammo or
        "mCollider.enabled = true;" not in ammo):
        raise ValueError("Grenadier card collision or drag source changed")
    grenade_ammo = (ASSETS / "Scripts/Assembly-CSharp/GrenadeAmmo.cs").read_text(
        encoding="utf-8-sig")
    explosion = (ASSETS / "Scripts/Assembly-CSharp/Explosion.cs").read_text(
        encoding="utf-8-sig")
    if ("explosionInfo.playerRadiusCoef = 0.7f;" not in grenade_ammo or
        "num6 = i.playerRadiusCoef;" not in explosion or
        "num5 *= i.playerBehindShieldRatio;" not in explosion or
        "if (num4 < i.deadRadius * num6)" not in explosion or
        "Mathf.Lerp(i.damageAmount, i.explodeDamage, num8 * num8)" not in explosion):
        raise ValueError("Grenadier card explosion damage source changed")
    pistol = (ASSETS / "GameObject/PistolEnemy.prefab").read_text(
        encoding="utf-8-sig")
    pistol_setup = pistol.split("--- !u!114 &11470521\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    aiming = (ASSETS / "Scripts/Assembly-CSharp/AimingHelper.cs").read_text(
        encoding="utf-8-sig")
    if ("  speed: 5\n" not in pistol_setup or
        "return num / bulletSetup.bulletSpeed + 0.1f;" not in gun or
        "float num = weapon.ComputeFlyTimeToTarget(position) + extraTIme;" not in aiming or
        "PredictPosition(currentWeapon, mShotTarget.transform.position, gameShootableEntity.velocity, 0.1f)" not in runtime):
        raise ValueError("Grenadier card moving-target prediction changed")


def check_rocket_card_setup():
    soldier = (ASSETS / "Scripts/Assembly-CSharp/SoldierBehaviourBazooka.cs")
    behavior = soldier.read_text(encoding="utf-8-sig")
    required = [
        "base.ApplyWeaponsSetup();",
        "missileSetup.damageAmount = (float)base.mBehaviourDef.damage * 0.1f;",
        "missileSetup.explodeDamageAmount = base.mBehaviourDef.damage;",
        "missileSetup.playerBehindShieldRatio = upgradeSlots.playerBehindShieldDamageRatio;",
        "missileSetup.speed = ((!controller.hasSpecial) ? 3f :",
    ]
    card_spawn = (ASSETS / "Scripts/Assembly-CSharp/AIObject.cs")
    upgrade = (ASSETS / "Scripts/Assembly-CSharp/UpgradeSlots.cs")
    player_targets = (ASSETS /
        "Scripts/Assembly-CSharp/GameShootableEntityPlayer.cs")
    player_controller = (ASSETS / "Scripts/Assembly-CSharp/PlayerController.cs")
    spawning = (ASSETS / "Scripts/Assembly-CSharp/SpawningManager.cs")
    enemy_controller = (ASSETS / "Scripts/Assembly-CSharp/EnemyController.cs")
    weapon_prefab = (ASSETS / "GameObject/BazookaEnemy.prefab")
    missile_source = (ASSETS / "Scripts/Assembly-CSharp/Missile.cs")
    scene = SCENE.read_text(encoding="utf-8-sig")
    rocket_component = scene.split("--- !u!114 &42012\n", 1)[1].split(
        "\n--- !u!", 1)[0]
    bazooka_weapon = weapon_prefab.read_text(encoding="utf-8-sig").split(
        "--- !u!114 &11431434\n", 1)[1].split("\n--- !u!", 1)[0]
    bazooka_cadence = bazooka_weapon.split("  cadence:\n", 1)[1].split(
        "  clipSize:", 1)[0]
    bazooka_ammo = weapon_prefab.read_text(encoding="utf-8-sig").split(
        "--- !u!114 &11477035\n", 1)[1].split("\n--- !u!", 1)[0]
    bazooka_prefab_text = weapon_prefab.read_text(encoding="utf-8-sig")
    bazooka_spawn = bazooka_prefab_text.split(
        "--- !u!4 &496729\n", 1)[1].split("\n--- !u!", 1)[0]
    bazooka_launcher = bazooka_prefab_text.split(
        "--- !u!4 &472700\n", 1)[1].split("\n--- !u!", 1)[0]
    bazooka_root = bazooka_prefab_text.split(
        "--- !u!4 &443158\n", 1)[1].split("\n--- !u!", 1)[0]
    missile_behavior = missile_source.read_text(encoding="utf-8-sig")
    if (any(line not in behavior for line in required) or
        "unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);" not in
            card_spawn.read_text(encoding="utf-8-sig") or
        "playerBehindShieldDamageRatio => armyUpgradesRow.PLAYERBEHINDSHIELDDMGRATIO;" not in
            upgrade.read_text(encoding="utf-8-sig") or
        "type &= ~ShotTargetType.Shield;" not in
            player_targets.read_text(encoding="utf-8-sig") or
        "list.AddRange(base.GetShotTargets(type));" not in
            player_targets.read_text(encoding="utf-8-sig") or
        "currentPlayerPoint = mGoToPosition;" not in
            player_controller.read_text(encoding="utf-8-sig") or
        "unitDictionaryId: ID_UNIT-ROCKETSOLDIER" not in rocket_component or
        "enemyPointType: 6" not in rocket_component or
        "GetPoint(SoldierBehaviour behaviour, float minDistance = 0f" not in
            spawning.read_text(encoding="utf-8-sig") or
        "fakeValue: 2" not in bazooka_cadence or
        "infiniteAmmo: 1" not in bazooka_weapon or
        "friendKill: 0" not in bazooka_weapon or
        "mWeapons[0].cadence = 0.35f;" not in
            (ASSETS / "Scripts/Assembly-CSharp/SoldierBehaviour.cs")
            .read_text(encoding="utf-8-sig") or
        "stopTime: 0" not in bazooka_ammo or
        "curvedTrajectory: 0" not in bazooka_ammo or
        "hurtRadius: 1.2" not in bazooka_ammo or
        "deadRadius: 0.8" not in bazooka_ammo or
        hashlib.sha256(weapon_prefab.read_bytes()).hexdigest() !=
            "70ced837878580b64c2f5a2665fbf47cde846c4503dba1cda625135b9c667d47" or
        "m_LocalPosition: {x: -0.047, y: -0.0015, z: 0.0344}" not in
            bazooka_spawn or
        "m_LocalScale: {x: 1.4, y: 1.4, z: 1.4}" not in
            bazooka_launcher or
        "m_LocalRotation: {x: 0, y: 0, z: -0.7071068, w: 0.7071068}" not in
            bazooka_launcher or
        "m_LocalRotation: {x: 3.0908623E-08, y: -0.7071068, z: -0.7071068, w: -3.0908623E-08}" not in
            bazooka_root or
        "if (Vector3.Distance(from, to) > 50f)" not in missile_behavior or
        "else if (Vector3.Distance(mFrom, mTransform.position) > 0.5f)" not in
            missile_behavior or
        "if (progress > ((!mSetup.curvedTrajectory) ? 3f : 1.5f))" not in
            missile_behavior or
        "ShootFromBazookaFromCover(mCoverShotRight);\n\t\t\t\tShoot(0.7f);" not in
            enemy_controller.read_text(encoding="utf-8-sig") or
        "weapon.transform.localScale = Vector3.one;" not in
            (ASSETS / "Scripts/Assembly-CSharp/SoldierParts.cs").read_text(
                encoding="utf-8-sig") or
        "mAnimation.Play(\"bazooka_shoot_right\");" not in
            (ASSETS / "Scripts/Assembly-CSharp/SoldierAnimationController.cs")
            .read_text(encoding="utf-8-sig")):
        raise ValueError("Rocket card setup, aim, point or shot timing differs from recovered Client")


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


def check_random_kevlar_source():
    card = (ASSETS / "Scripts/Assembly-CSharp/CardRandomKevlar.cs").read_text(
        encoding="utf-8-sig")
    enemy = (ASSETS / "Scripts/Assembly-CSharp/EnemyController.cs").read_text(
        encoding="utf-8-sig")
    kevlar = (ASSETS / "Scripts/Assembly-CSharp/Kevlar.cs").read_text(
        encoding="utf-8-sig")
    if ("enemyController.fraction == fraction && enemyController.destroyableObject.health > 0f && enemyController.canBeFreezed" not in card or
        "Mathf.Min(3, list.Count)" not in card or
        "list[num].SetUpKevlar()" not in card or
        "public void SetUpKevlar(float hpPercents = 0.2f)" not in enemy or
        "kevlarDestroyableObject.maxHealth = kevlarStrength * destroyableObject.maxHealth" not in kevlar):
        raise ValueError("RANDOMKEVLAR soldier count or armor source changed")


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
    names.discard("CardSpawnUnit")
    unit_card_helper = source.split(
        "private static bool IsSupportedSelfHostedUnitCard", 1)[1]
    unit_card_helper = unit_card_helper.split(
        "private async void UseSelfHostedCard", 1)[0]
    unit_card_ids = set(re.findall(r'card\.id == "([A-Z0-9_]+)"',
                               unit_card_helper))
    if (unit_card_ids != {"ELITEMINIGUN", "ELITESWAT",
                          "ELITESNIPER", "ELITEPARA", "HEAVYDRONE",
                          "BIGROCKET"} or
        "IsSupportedSelfHostedUnitCard(card)" not in use_card or
        "UseUnitCardResult(card.id)" not in body):
        raise ValueError("Normal Client unit-card route changed")
    if (len(names) != 28 or
        "if (selfHosted != null && selfHosted.IsConnected)" not in use_card or
        "Self-hosted card is not supported yet" not in use_card or
        use_card.index("Self-hosted card is not supported yet") >
            use_card.index('mPhotonView.RPC("PlayCardRPC"')):
        raise ValueError("Normal Client self-hosted card route count changed")
    return names, unit_card_ids


def render():
    rows = source_rows()
    check_apocalypse_source()
    check_single_shield_source()
    check_instant_medkit_source()
    check_grenadier_card_setup()
    check_rocket_card_setup()
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
    check_random_kevlar_source()
    classes = reviewed_classes()
    scene = scene_classes({row[0] for row in rows})
    routes, unit_card_ids = direct_client_routes()
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
        f"The dispatcher currently has {len(routes)} card classes and",
        f"{len(unit_card_ids)} source-specific unit-card IDs. While connected to",
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
                     f"{'yes' if scene_class in routes or source_id in unit_card_ids else 'no'} |")
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
