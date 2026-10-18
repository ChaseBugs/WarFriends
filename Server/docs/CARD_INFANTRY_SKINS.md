# Card infantry skins and attachments

The PvP infantry presenter now applies the fixed source card appearance lane to the six supported
infantry cards: BIGROCKET, ELITEMINIGUN, ELITEPARA, ELITESNIPER, ELITESWAT and GREATGRENADIER.
This checkpoint covers body/helmet team textures, MatCap and upgrade attachments, not card weapons
or shields. The subsequent [held-shield integration](INFANTRY_HELD_SHIELDS.md) adds source SWAT
shield selection and material sharing separately.

## Recovered contract

`SoldierBehaviour.UpdateVisual` selects `cardSoldierVisuals` and copies `upgradeSlots.cardVisuals`
directly for `spawnedByCard`. It does not select an ordinary or Elite lane from the owner's
equipped-unit upgrades. A player can deploy a card without having that ordinary unit equipped.
The team's blue/red choice still depends on the admitted perspective.

`SelfHostedInfantryUpgradeSelection.ResolveVisuals` validates the actor's owner, fraction, family
and shared source card/unit identity before copying the fixed card lane. Ordinary actors still
require their owner's admitted equipment; card support does not introduce a level-zero fallback
for ordinary units. `Resolve` continues to reject card actors as ordinary upgrade requests.

`SelfHostedInfantryPresenter` applies the existing skin/material lifetime helper to this selection.
No new protocol fields or gameplay commands are needed, and no local damage or progression
authority is activated.

## Native validation

`UnityCardInfantryAppearanceAudit.Run` passes 192 checks over twenty-four source actors in
disposable Unity 2018.3.0f2. All six identities are created through the production presenter with
both owners and both local perspectives. Neither admission view contains an ordinary equipped
unit. The audit checks exact fixed-lane selection, body and both helmet textures, MatCap,
attachment mesh/material/socket identities, absence of recovered scripts and material release.
It rejects a conflicting owner fraction, unknown card, mismatched known card/unit identity and
an ordinary-unit request without equipment.

The existing seventeen owner/presenter checks, 1,223 ordinary skin assertions over 128 actors,
sixteen-family presenter regression and Gunslinger weapon/holster checks also pass. The latter's
source-hash fixture is refreshed after these shared runtime changes.

This component audit does not establish normal two-client battle entry, complete shader/pixel
parity, original Unity 5.2.5, Android or Linux runtime. Card weapons remain
separate: `EnemyBasicInventory` selects `cardWeapons`, and the recovered Grenadier
and Commando weapon selectors can return multiple levels. Do not reuse the existing single-weapon
Assaulter resolver for those layouts. See the [feature checklist](BATTLE_SERVER_FEATURES.md).

The later [card weapon-set builder](CARD_WEAPON_SETS.md) now preserves those ordered layouts and
passes native geometry/selection checks. Its authoritative host visibility and normal presenter
integration remain pending; the card-skin proof above does not close those gates.
