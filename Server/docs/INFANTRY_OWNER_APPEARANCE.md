# Owner-bound infantry weapon appearance

The PvP scene bridge now binds the admitted two-player equipment snapshot before subscribing the
infantry presenter to roster events. Ordinary Assaulter creation resolves its weapon through that
actor's owner and recovered upgrade selector instead of displaying a weapon-less body.

## Recovered contract

`BattlePlayerView.units` contains source sheet identity, normal upgrade index, special index,
Elite index and tier. `PlayerProperties.CreateFromBattleView` maps these into `UnitUpgrades`:
special/Elite flags are true exactly when the corresponding index is nonnegative. The sheet name
comes from `family.upgradeSlots.GetSheetName()`; it is not the actor's `ID_UNIT-*` identity.
`UpgradeSlotsBaseSoldier.GetVisuals` selects normal or Elite weapon lanes using the normal index.

`SelfHostedInfantryUpgradeSelection` copies the admission messages, rejects duplicate player/unit
identities and malformed upgrade indexes, and binds owner ID plus fraction before returning that
tuple. Missing equipment is an error, not permission to select level zero. Caller mutations cannot
change its stored equipment. This selection does not authorize damage, purchases or progression.

`SelfHostedInfantryPresenter.BindPlayerAppearances` is called by the production PvP bridge before
roster subscription. The presenter then uses `ResolveOrdinary` and the shared script-free factory
for normal Assaulter actors. Geometry-only consumers can still construct source bodies without
binding a PvP admission context; the production bridge always supplies it.

## Native validation

`UnityInfantryOwnerAppearanceAudit.Run` uses MainScene's actual Assaulter family and model records.
The refreshed disposable native run passes seventeen checks and exits zero. It now also binds the
local appearance perspective, verifies production body textures and checks material disposal.
The existing sixteen-family
presenter regression and Gunslinger's four selections/twelve attachment comparisons/four decoded
presenter checks also pass after this change; the Gunslinger source-hash fixture is refreshed.
It compares two opposing owners with different normal/Elite upgrade tuples, exercises the production
presenter's creation/removal path, and rejects an unknown owner, wrong fraction, card actor,
missing equipment, duplicate sheet and malformed index. It checks snapshot isolation and verifies
that a rejected actor leaves no partly created visual. The inspected endpoint selections can use
the same source weapon mesh; tuple assertions distinguish ownership without fabricating different artwork.

This is a Unity 2018.3.0f2 component audit. It does not execute the complete PvP scene bridge or
normal two-client match entry. [Ordinary team skins](INFANTRY_TEAM_SKINS.md) now cover body/helmet
textures and attachments in a separate source matrix. Other infantry weapon lanes,
card weapons, detached shield death effects and original Unity 5.2.5 parity remain open. The subsequent
[card-skin integration](CARD_INFANTRY_SKINS.md) handles fixed body/helmet lanes without ordinary
equipment. The existing source-constant Gunslinger
weapon and its draw/holster binding remain separate. See the
[feature checklist](BATTLE_SERVER_FEATURES.md).
