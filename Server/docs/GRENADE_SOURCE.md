# Recovered grenade authority

This slice is derived from the recovered WarFriends 1.4.0 `MainScene`, `PlayerSwipeWeapon`, `GrenadeAmmoBase`, grenade subclasses, and the Google2u upgrade sheets. It is deployment evidence for self-hosted combat, not client-supplied authority.

`SelfHostedGrenadeExport.Run` writes `content/recovered-grenade-bindings.json` without saving the Unity scene. `SelfHostedGrenadePoseExport.Run` separately samples the grenade-specific animation families so adding the left arm does not rewrite rifle evidence. `grenade-content-manifest.json` pins both artifacts, the scene digest, and `recovered-battle-content.json`. `GrenadeCatalog` rejects a partial or altered package before it can authorize a match.

The package contains eight families and 398 stages:

| Family | Stages | Input |
|---|---:|---|
| `Google2u.GrenadeLauncher_M320` | 36 | click target |
| `Google2u.Grenade_FLASH` | 36 | upward swipe |
| `Google2u.Grenade_FRAG` | 26 | upward swipe |
| `Google2u.Grenade_M84` | 76 | upward swipe |
| `Google2u.Grenade_Molotov` | 66 | upward swipe |
| `Google2u.Grenade_POISON` | 46 | upward swipe |
| `Google2u.Grenade_SMOKE` | 56 | upward swipe |
| `Google2u.Grenade_SMOKEElite` | 56 | upward swipe |

The server recomputes swipe strength from world-plane start/end points and held time. It applies the recovered distance threshold, time and distance clamps, `throwfactor`, and one-to-ten-unit output bounds. Client-provided target strength will not become authority. `GrenadeFlight` applies the recovered target elevation adjustment, launch angle, gravity, drag `0.2`, throw-distance cap, and enables collision only after vertical velocity becomes negative.

The stage tables own finite non-reloadable ammo, cadence, explosion damage, minimum damage, dead/hurt radii, player damage, overtime damage, and behind-shield coefficients. M320 supplies per-stage `DEADRADIUS`; the other families use the level-definition radii 1.0 and 1.7 rather than the idle component's pre-setup values.

The recovered scene serializes every projectile through `GrenadeAmmoSetup`. Only Molotov selects enum value 4. FLASH, POISON, SMOKE, SMOKEElite, M84, FRAG, and M320 all select the ordinary Frag explosion branch in this version. Their names do not justify inventing flash, poison, or smoke gameplay effects.

The pose package contains 12 exact source clips and 289 samples at 30 Hz: left/right grenade throws, grenade run/idle, both launcher cover chains, and launcher run/idle. Every frame contains both active player hit parts, the shared left-hand spawn, and all eight right-hand weapon spawns. The typed protobuf transport carries separate launcher and raw-swipe input shapes, and the portable Unity SDK exposes both calls.

The Worker updates the grenade pose from the same authoritative cover route and player position as the match snapshot on every tick. During movement it samples `grenade_run` or `run_grenadelauncher`, turns toward the actual route displacement, and places the collision and shot-target transforms at the moving position. Arrival restores the source cover rotation and idle clip before another throw can start. Focused tests check a moving M320 collider, run-to-idle transition, and the real MatchEngine cover route; this closes the stale starting-cover pose discrepancy, but does not establish normal Unity movement rendering.

Current verified boundary: package load, scene/stage/muzzle/pose binding, typed transport, swipe planning, delayed animated launch, finite ammunition/cooldown, ballistic flight, MatchEngine collision, and radial player/dynamic/shield/barrel explosion paths pass focused and real-UDP tests. Grenade flight now includes the Worker-owned moving unit hitboxes in its collision world; a focused trace proves the dynamic target identity reaches the M320 path. The disposable Unity export `recovered-grenade-shot-targets.json` pins all five serialized gameplay targets across the same 12 clips and 289 frames; the Worker now uses those posed targets for Helicopter acquisition in grenade-only matches. A Park source deployment fires an authenticated M320 at a legal elevated aim point: the falling grenade strikes the gunner, and both UDP clients observe lower gunner health and replay the same impact event ID. The source Enemies/Allies bullet masks now follow fraction 1/2 exactly, as the rifle path already did. One two-peer UDP match launches both a FRAG swipe and the distinct M320 click path and observes their finite ammunition and live projectile projection. Grenade mode is admitted only with the exact grenade package revision. The normal Unity bridge sends raw swipe-plane evidence or the M320 target through their distinct typed calls. Authoritative grenade poses use stable protocol clip IDs 60-71. Active host projectile transforms and velocities cross the snapshot boundary; the Client copies only the recovered equipped projectile mesh, applies those transforms without gameplay scripts, removes it at authoritative impact, and plays the recovered medium or Molotov impact effect. `SelfHostedGrenadeRenderAudit` replayed every one of the 289 source samples through the recovered rig and matched 867 collider/muzzle positions, including the left-hand origin, then created the recovered grenade mesh from an authoritative projectile snapshot for 868 checks total. Unity 2018.3 compilation passes.

Regenerate that disposable render fixture with `dotnet run --project Server/tests/War.Battle.Tests -- --write-grenade-render-fixture <absolute-output>` and run Unity with `WAR_GRENADE_RENDER_FIXTURE` plus `-executeMethod SelfHostedGrenadeRenderAudit.Run`. Remaining work is a real two-process Worker-to-Unity grenade session, Android/two-device validation, impact-effect runtime capture, and presentation cleanup.
