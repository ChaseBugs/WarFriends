# Recovered sniper authority

The recovered Client has eight `PlayerZoomOnTouchWeapon` families and 428 total stages:

| Source family | Inventory index | Stages |
|---|---:|---:|
| AWM-F | 21 | 46 |
| Dragunov | 14 | 36 |
| M110 | 10 | 56 |
| M110 Elite | 64 | 56 |
| M24 | 2 | 26 |
| M90 | 32 | 66 |
| M90 Elite | 46 | 66 |
| MSR | 59 | 76 |

`SelfHostedSniperExport.Run` reads MainScene and pins each setup, controller, `OneShotRifle`, family-10 animation identity, muzzle, shot offset, scope settings, finite reloadable ammunition flags, and `BulletSlow` identity. `SniperCatalog` binds that export to the recovered sheets and validates all stages before creating a host manifest or projectile.

All definitions use a 2.0-second cadence, 0.08 critical probability, speed 80, player coefficient 0.387 and overtime coefficient 0.33. Stage rows provide clip, reserve, reload and damage. The scene overrides the C# zoom defaults with movement threshold 750 and zoom delay 0.2 seconds. Scope visibility is separately hard-coded at a strict 0.17-second hold.

The source gesture starts aiming on press, continuously changes the aim/cover side while held, displays the scope after strictly more than 0.17 seconds, and fires only on release when the touch was not classified as a swipe and the weapon is ready. Zoom animation after 0.2 seconds and low pointer movement is presentation; it is not the firing gate. `SniperAimState` pins the server-owned press/update/release/cancel clock, including the source behavior where a press during cooldown becomes armed only when the weapon is ready.

`SniperAimCommand` is the typed protobuf press/update/release transport. `MatchEngine` rejects ordinary click-fire for this class, publishes aiming and scope-visible state, and creates one slow projectile only after a valid release. The normal DeathMatch bridge forwards the recovered touch/swipe gesture and drives the existing `SniperScope` from authoritative visibility. Family-10 left/right cover, fire, hide, run and idle clips use wire IDs 46-53.

Focused validation: `dotnet run --project Server/tests/War.Battle.Tests -- --sniper-only` passes 39 package, binding, stage, gesture, match-engine, projectile and live-UDP assertions. The mixed Worker/Unity Editor audit switches the recovered inventory to M24 and proves family-10 presentation, the authoritative scope gate, exactly one release shot, clip projection and scope closure. Android/two-device proof remains open.
