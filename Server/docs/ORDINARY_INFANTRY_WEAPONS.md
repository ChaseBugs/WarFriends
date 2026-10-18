# Ordinary infantry weapon appearance

The admitted owner equipment snapshot now selects startup weapon appearance for all sixteen
combat infantry families. The presenter uses ordinary `weapons`, never `cardWeapons`, and resolves
normal/Elite visuals through the recovered `GetVisuals` selector. Gunslinger retains its existing
source-constant model and hand/holster binding rather than receiving a duplicate weapon.

## Source rules

The shared builder preserves inventory order, source hand sockets, model meshes/materials,
root pose and swapper setup. Missing combat inventory fails construction. Grenadier selects
levels `[0, selectedModel]`, Commando selects `[selectedModel, selectedModel]`, and other families
select one model. Static weapons without a leveled model retain their original geometry.

Commando's recovered `Restart` enables both weapons. Other ordinary families start with index
zero visible; Grenadier's grenade remains hidden. Owner selection uses the frozen admitted
normal/Elite upgrades rather than the local player's equipment or a guessed zero upgrade.

## Verification

`UnityOrdinaryInfantryWeaponsAudit.Run` passes 530 checks in disposable Unity 2018.3.0f2.
The matrix covers sixteen source families, normal/Elite lanes and upgrade indexes zero and 39:
64 source constructions and 72 weapon copies. Another 32 production presenter actors exercise
opposing owners, source sockets, visibility and removal. Ordinary Grenadier now also verifies
decoded primary/secondary updates and creation while already holding the secondary weapon. The audit also rejects missing
inventory and verifies that visual copies contain no gameplay scripts or physics components.
These component fixtures supply equipment views directly; they do not prove full Backend admission.

Card weapon, card appearance, shield, owner, sixteen-family and Gunslinger native regressions
also pass. The Gunslinger source-bound fixture was refreshed for the modified presentation sources.

## Remaining work

Protobuf field 46 now projects ordinary Grenadier selection through the host, portable SDK and
retained presenter weapon sets. Other ordinary families retain field zero and source startup
visibility, including both Commando weapons. Card switching continues through its host projection.
Firing effects, detached shield death effects, complete death/ragdoll presentation, every upgrade
threshold, normal two-Unity-client matches, Android, Linux and original Unity 5.2.5 runtime parity
remain unverified or incomplete. See [weapon authority](INFANTRY_WEAPON_AUTHORITY.md).
