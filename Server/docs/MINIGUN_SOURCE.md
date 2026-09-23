# Recovered minigun authority

`Google2u.LMG_Minigun` is a dedicated firing class. It must not use the two-round `PlayerBurstWeapon` LMG scheduler.

The pinned package is `content/minigun-content-manifest.json`. It binds the 36-row `Google2u.LMG_Minigun` lane to MainScene inventory index 25, `MinigunLevelsSetup`, `PlayerMinigunWeapon`, `LightMachinegun`, animation family 4, the non-reloadable finite-ammunition flags, muzzle path, bullet prefab digest, collision masks and projectile constants. `MinigunCatalog` rejects a partial lane, changed provenance, altered binding, invalid numeric data and a package hash mismatch.

The source level setup maps each row's `AMMO` to `Weapon.ammoLeft`, `DAMAGE` to `BulletSetup.damageAmount`, and `HEATTIME` to `PlayerMinigunWeapon.coolDown`. `WeaponLevelDefinition.Zero()` leaves clip size zero. The host therefore projects `AMMO` into its one active ammunition pool, keeps reserve at zero, and never permits a reload. This is an adapter for the host's existing clip/reserve wire fields; it does not claim that the Unity minigun uses a magazine.

MainScene overrides the C# defaults: `waitTime=0.1`, `coolDown=5`, `lockTimeAfterBurst=0.3`, and `firstShotWaitTime=0.1`. Once an upgrade is applied, the row's `HEATTIME` replaces the serialized cooldown. The recovered firing loop requires held input, waits strictly beyond `pressedTime + waitTime`, and after each shot sets an extra lock of `clamp01(0.3 - elapsed/HEATTIME * 0.3)`. `Gun.willShoot` independently enforces the 0.1-second source cadence. `MinigunFireState` reproduces those continuous-time comparisons at the 30 Hz host tick and stops immediately on release.

The protobuf `MinigunHoldCommand` and portable SDK method are appended transport contracts for press, target update and release. `MatchEngine` accepts that command only for the dedicated minigun class, rejects ordinary click-fire, starts family-4 uncovering during spin-up, automatically emits due shots from host time, decrements the finite pool, and stops on release, movement, weapon selection loss, or terminal state. `BattlePlayerState.minigun_held` drives both local and remote motor presentation.

The Unity pose export now includes the six `_minigun` cover clips plus `minigun_run` and `minigun_idle`. Their wire IDs are appended as 38–45; earlier IDs remain unchanged. The live mixed-weapon Editor audit selects inventory index 25 after rifle, SMG, pistol, and burst-LMG stages, observes family-4 poses, server-owned ammunition loss, the held-state motor request, and no later shots after release. This establishes the recovered normal bridge path in one Editor process; Android and two-device proof remain part of B36.

Focused validation: `dotnet run --project Server/tests/War.Battle.Tests -- --lmg-only` covers 19 dedicated package/projectile/hold/MatchEngine assertions and five real UDP assertions in addition to the burst-LMG assertions.
