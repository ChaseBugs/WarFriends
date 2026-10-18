# Delayed rifle kills during grenade selection

`MixedGrenadeLongShotTests` exercises the actual mixed-combat `MatchEngine`: admit both players,
ready, deploy a source Shotgunner, fire the recovered AK47, wait for a round to leave the weapon,
then select the recovered FRAG slot while that round remains in flight. The target must still be
alive at selection. Subsequent host ticks perform collision, damage, death, and score publication.
The test never injects damage, a collision result, or a skillshot receipt.

## Client rule

`Clients/ExportedProject/Assets/Scripts/Assembly-CSharp/SkillShotController.cs`, in
`GameEntityOnKilled`, grants LongShot only for a Shot death with a non-null weapon whose **current**
transform is strictly farther than `longShotKillDistance` from the victim root. The recovered scene
distance is six units. A grenade explosion is not equivalent evidence, and the launch position is
not the rule's weapon transform.

The existing player-bullet death path in `MatchEngine` retains the projectile's weapon source ID
and queries that weapon in the owner's current common combat pose. The observed grenade rig
integration supplies that root after the active slot changes to FRAG. No production damage or
score rule was changed for this test checkpoint.

## Verified cases

- Park: fraction-two shooter, fraction-one infantry owner; delayed lethal contact at tick 640
  credits one LongShot while the shooter holds FRAG.
- City: fraction-one shooter, fraction-two infantry owner; delayed lethal contact at tick 537
  credits no LongShot while the shooter holds FRAG.
- Both cases credit exactly one Kill, OneHitKill, and confirmed enemy hit.
- Forfeit closes each fixture; private terminal skillshot evidence retains the expected LongShot
  count, and public snapshots do not expose those private settlement counters.

The fixture starts from source starter weapon slots but deliberately equips one Shotgunner family
to isolate a single target. Trusted health factors are 0.01 each, so a full-health source target can
die to one hit. Park uses a test-authored speed factor of 0.1 to keep the target distant during
flight; City uses 1.0. These values are fixture authority, not a claim about starter account perks,
production balancing, or automatic Backend allocation. Source unit stages and weapon stages remain
zero, with special and Elite lanes inactive. Infantry choice is deterministic.

## Verification

```powershell
dotnet build Server/tests/War.Battle.Tests/War.Battle.Tests.csproj -c Release --no-restore
dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --mixed-grenade-longshot-only
```

Release build passed with zero warnings and errors; the focused executable passed 16 checks.
The test is also registered in `--grenade-only` and the default native suite. The complete native
suite was not rerun for this test-only checkpoint.

This proves two actual native host scenarios. It does not prove every map, weapon, animation
transition, rendered Unity gameplay, two running Unity Clients, or durable Backend settlement.
