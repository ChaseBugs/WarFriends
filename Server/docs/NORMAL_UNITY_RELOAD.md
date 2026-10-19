# Host-owned reload in the normal Unity battle

Recovered `InventoryItem.OnClick` reloads an already selected weapon by calling `Weapon.Reload`.
That method previously started a local timer, and `FinishReload` transferred reserve ammunition
into the clip. The existing self-hosted bridge only sent automatic reload when its snapshot clip
was empty. A manual HUD click therefore did not request host reload authority.

## Runtime boundary

Player-weapon reload callbacks in an owned self-hosted session now route through the retained
adapter and the DeathMatch scene input bridge. The bridge requires a connected, non-reconnecting
session, running/unfrozen gameplay, no pending command, the exact local active weapon and a
reloadable weapon not already reloading. It shares the normal input command observer and timeout
recovery path. Remote and inactive weapon callbacks cannot request a local reload or start a local
ammunition transfer. A mode without the DeathMatch bridge remains fail-closed; this checkpoint
does not implement the corresponding normal co-op/manual reload integration.

The selected player weapon receives the snapshot simulation tick and `ReloadEndTick`. Pending
state and remaining seconds come from that exact tick difference at 30 Hz, so a paused host also
pauses this display. Progress uses the loaded weapon reload duration and is a bounded presentation
fraction; per-effect timing/animation parity is not established here. Local getters and completion
callbacks cannot replenish ammunition while this projection is owned. Only snapshot application
updates clip/reserve counts. Non-reloadable weapon cooldown behavior retains its original path.

A host-confirmed selection change releases the previous weapon's reload display, and destroying
the battle scene bridge releases both players' projections. This avoids retaining host-only flags
when an ordinary local weapon is reused. The existing local reload arithmetic remains available
after release. Full inactive-slot reload progress requires additional wire/presentation evidence;
the current player snapshot exposes only the active slot's reload deadline.

## Focused actual-component verification

`UnityAuthoritativeReloadAudit` opens only a disposable MainScene and exercises an actual recovered
`AutomaticRifle`. Ten checks pass in `.local/authoritative-reload-finite-audit.log` with Editor exit
zero: pending/countdown projection, bounded progress, blocked local ammunition completion, invalid
duration rejection without partial display publication, host completion display without a local
grant, and restored legacy transfer after release. Unity compilation succeeded.

The first attempt, `.local/authoritative-reload-audit.log`, selected a Pistol whose source getter
always returns `int.MaxValue` and ignores writes. Its finite-reserve assertion failed. The helper
now explicitly chooses an ordinary `AutomaticRifle`; the original Pistol behavior was preserved.

## Normal two-peer gate

After [normal HUD selection](NORMAL_UNITY_WEAPON_SELECTION.md), both peers first capture the same
loaded weapon state. The initiating audit prepares a real host-owned one-round clip deficit.
Ordinary firing uses `SelfHostedBattleClient.Fire`; a recovered `PlayerZoomOnTouchWeapon` instead
requires SniperAim press, host-confirmed scope readiness and release. The diagnostic aims above the
opposing player so it does not require damage or a lethal outcome. It does not write ammunition
into either scene. This is diagnostic
adapter input, not proof of a mouse/touch firing path. The existing selected HUD item's recovered
`OnClick` then requests reload. Both peers must observe pending host reload and weapon presentation,
unchanged pre-completion ammunition, the completed host clip/reserve transfer, and the same local
weapon counts before the existing reconnect gate may start. Infinite Pistol reserve follows the
already implemented source `int.MaxValue` rule.

Results appear under `normalBattle.reload`. The thirty-second admission override remains diagnostic;
one prepared shot and selected weapon do not complete firing input, reload animations, all weapon
families, co-op, results, clean rendering or Android acceptance. Record actual terminal evidence
before declaring the normal reload gate passed.

The preliminary normal run `.local/client-boot-87ebbfd20a0b41aba01e076e2a7b9e78` failed before
reload: its selected fixture has a five-round clip and twelve reserve rounds, and the helper used
generic Fire instead of the recovered sniper aim/release flow. The completed request did not
produce the required one-round deficit, so no HUD reload or reconnect was counted. The helper now
reports request completion separately from observed ammunition consumption and uses the weapon's
recovered input class. The first report also records an `ArgumentOutOfRangeException` at
`DeathMatchUnitsGuiElement.Update:129` after the stalled run continued to terminal handling.
That unchecked card-animation indexing remains a separate unresolved UI/lifecycle defect; this
checkpoint does not establish its root cause or claim it fixed.

## Earlier failed combined run

`.local/client-boot-e9df0198f6864093bbe806f9a326c74e` uses the corrected sniper input sequence.
The initiating report records the completed request separately from observed one-round consumption,
the actual HUD reload callback, pending reload and completed reload, all with no reload failure.
Both peers publish pending/completed markers for the same target player. This establishes the
manual reload observations inside a failed combined run, not a pass of the entire gate.

Subsequent reconnect fails with `Invalid authoritative infantry visual state` in
`SelfHostedInfantryPresenter.Validate`, called by army roster restoration. The initiating report
has zero exceptions, 144 error-level diagnostics, one rebuild attempt and no resumed-tick completion.
The peer log records one `ArgumentOutOfRangeException` during later terminal handling. The test
exits nonzero. The normal reload and reconnect feature must remain partial.

The presenter now identifies the rejected field group while preserving every original validation
condition. `.local/client-boot-6ca6d473848b4c209c2d51c8f6d2d16d` compiled that diagnostic change and
completed ordinary boots, but its second paired Editor stalled at startup. The first report has
`hasStartedSearch=false`, `hasReachedRunning=false` and zero exceptions. It exits nonzero without
reproducing the infantry rejection; no particular field group is established by that attempt.

## Passing combined checkpoint

The missing normal army factor projection is now implemented; see
[army perk projection](ARMY_PERK_PROJECTION.md). The failed run above did not identify its exact
rejected field, so it remains failure provenance rather than a retroactively diagnosed pass.

`.local/client-boot-5c9559a5c2f9492ebc4e653e18fe89fa` exits zero. Both normal controllers
reach Running in match `m887230cf0e54448d8748de9132be5ed5`. The initiator observes sniper
one-round consumption, the real HUD reload callback, pending reload and completion. Its peer
also observes pending/completed reload. Reconnect performs one rebuild and resumes from tick
928 to 933, then satisfies the ninety-tick continuation requirement without recovery failure.
Report-time exception counts are zero, with 142/141 error-level diagnostics.

Both logs subsequently record shutdown NullReferenceExceptions in `Crane.OnDestroy` and
`DeathMatchUnitsGuiElementFixed.get_isActive`, after `UNITY_NORMAL_BOOT_OBSERVED`. Therefore
zero report exceptions is not a clean whole-process lifecycle result. The earlier terminal
card-animation indexing defect also remains open. This uses the diagnostic thirty-second
admission window and prepared sniper input; default admission, pointer firing, all families,
terminal/rematch gameplay, Android and external-network isolation remain separate gates.
