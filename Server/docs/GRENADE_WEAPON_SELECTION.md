# Grenade weapon selection prerequisite

The recovered WeaponInventory switches the active weapon, and Grenade.Shoot uses
that weapon's setup and muzzle. A scheduled throw must therefore bind the
currently selected source identity and upgrade, rather than the participant's
initial manifest weapon.

GrenadeMatchSimulation now stores the active binding and upgrade separately from
the immutable participant identity. SelectWeapon validates the complete source
weapon manifest and current host tick before publishing any change. It resets
the source idle clip and pose for swipe grenades versus launchers. Moving actors
and pending throw windups reject selection.

Begin and Muzzle use the selected source identity and upgrade. MatchEngine's
grenade-only slot switch now invokes this selection before changing ActiveSlot.
A launched projectile already retains its own source binding and stage, while
the player's ammunition remains owned by the ordinary per-slot inventory.

## Verification boundary

GrenadeWeaponSwitchTests starts a real grenade-mode MatchEngine with FRAG in
slot zero and an upgraded M320 in slot one. It selects the launcher, accepts its
non-swipe target gesture, rejects switching during windup, advances every host
tick through launch, consumes exactly one launcher round and returns to FRAG
with its original ammunition. Invalid weapon assertions leave the pose unchanged,
and a future-tick selection is rejected. The focused command is:

```powershell
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll `
  --grenade-switch-only
```

These checks also run in --grenade-only and the default native suite. This is a
dependency for mixed gameplay, not proof of it. Mixed mode still needs a shared
active-class coordinator, source-correct collision/target poses across different
weapon classes, grenade launch scheduling alongside rifle simulation, snapshots,
and transitions to and from rifle/sniper/pistol slots. Normal Unity, Android and
automatic account allocation remain unverified here.

The Release solution builds with zero warnings/errors. The focused selection
test passes 12 checks. The combined grenade suite passes 279 checks, including
existing grenade-mode UDP and Tank impacts. Mixed allocator verification also
passes its existing weapon checks and 14 starter army checks. None of these
closes the still-open mixed grenade gameplay requirement.

The [common combat view](GRENADE_COMMON_COMBAT_VIEW.md) now supplies grenade
collision and target positions to shared army queries. It preserves sampled
launch-frame identity and explicitly leaves uncaptured rotations/rigs unavailable.
This is another mixed-mode prerequisite, not a completed class coordinator.
