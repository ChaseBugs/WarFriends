# Grenadier primary fire gap

The current Card Grenadier attack state can choose its primary pistol, but
`LaunchCardGrenadierShotIntents` skips every intent whose `ThrowGrenade` is false.
This is missing combat behavior, not a harmless presentation-only omission.
Do not claim complete Grenadier combat or complete Sickness weapon integration.

## Recovered evidence

- `SoldierBehaviourGrennader.PickTarget` chooses the secondary weapon before choosing a target.
  `ArmyCardGrenadierRuntime.SecondaryWeaponProbability` is currently source-backed at 0.4.
  The other branch needs primary fire; a fixed grenade-only fixture cannot prove that branch.
- MainScene Grenadier inventory component 41066 has matching `weapons` and `cardWeapons` arrays.
  Both use primary component 11431434, GUID `16439357c0b8cbc4a91424818b10119d`, runtime type 0,
  right hand; this resolves to `Assets/GameObject/PistolEnemy.prefab`.
- The secondary component is 11419550, GUID `bd74fc4b54938454a92a050c5517d60b`, runtime type 1.
- The pistol's Gun component points to spawn transform 434467 and BulletSlow component 11409266,
  GUID `855689762fa6e774aaee190652b08c6f`. `Weapon.ammoSetup` gets the AmmoSetup on the weapon's
  own GameObject. Follow that exact component and transform chain; the prefab contains other
  speed fields that must not be confused with the selected weapon's setup.
- `SoldierBehaviour.ApplyWeaponsSetup` assigns primary damage from the composed soldier definition,
  player damage coefficients from upgrade slots and cadence 0.35 seconds. The Grenadier override
  uses BulletSlow and separately configures the secondary grenade's minimum/explosion fields.
- The pinned `recovered-rusher-weapon-bindings.json` currently contains eight other families,
  excluding `ID_UNIT-GRENADIER`. `InfantryProjectileSpeed` also excludes its behavior.

## Required implementation and verification

1. Export and validate the normal/card inventory match, selected AmmoSetup, weapon spawn transform,
   rig attachment and runtime BulletSlow setup with source digests. Keep the existing eight-family
   contract intact or explicitly version its expansion.
2. Bind current primary damage separately from immutable card provenance; apply Sickness to that
   `damageAmount` as well as the already bound secondary minimum. Preserve separate explosion damage.
3. Launch primary real/fake rounds from the actual pistol muzzle through host collision authority,
   using source cadence, batch and damage policy. Keep actual grenade selection and launch separate.
4. Verify a forced primary choice produces a real host projectile and damage, friendly exclusions,
   fake-shot behavior, Sickness-modified launch damage, immutable airborne authority and death cleanup.
5. Add authenticated UDP and Client presentation proof before treating the complete unit behavior
   as finished. These are separate from the existing grenade-only native fixture.

The current Sickness callback can update Grenadier secondary damage and current health. Its primary
weapon firing and primary damage binding remain incomplete; no substitute weapon or hit assertion
has been introduced to conceal the missing path.
