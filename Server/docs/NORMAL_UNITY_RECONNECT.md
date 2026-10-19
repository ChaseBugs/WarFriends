# Normal Unity battle reconnect acceptance

This gate extends the two independent normal Client boots, recovered returning-player login,
DeathMatch search, card submission, assigned scene load and camera startup. It does not construct
an SDK-only scene or replace player data. The reference for its lifecycle separation is
[Ice MOBA integration research](ICE_MOBA_CLIENT_INTEGRATION.md); recovered WarFriends contracts
and the existing authenticated host remain authoritative.

`UnityNormalBattleReconnectAudit` runs after both peers have reached host Running and local
`gameIsRunning`. The first participant calls the actual `ReconnectWithRecoveredSession` method:
it requests a replacement grant using its recovered Backend session, replaces the UDP connection,
restores snapshot/entity/offer state and resumes event delivery through the existing presenters.
The other participant keeps its scene alive until a match-bound completion marker is observed.

The current paired gate first requires a recovered HUD weapon click and both peers' confirmation
of its authoritative selection, then rejects a selection during reconnect and verifies the chosen
weapon remains presented afterward. See [HUD selection evidence](NORMAL_UNITY_WEAPON_SELECTION.md).
The original checkpoint below predates those additional assertions; the linked document records
the later combined run rather than retroactively attributing them to the older result.

The gate requires the same adapter, match, local player object and opponent object, two retained
players, a nondecreasing simulation tick and processed-event cursor, exactly one full snapshot
rebuild, and at least ninety simulation ticks after restoration. A failed task or violated invariant
retains a bounded failure type and prevents the audit from passing. Tokens, grants and keys are
not written into the audit report. Test marker files live only in the isolated unique run directory.

Run with two disposable Unity projects under `Server/.local`:

```powershell
Server/scripts/ClientBootSmoke.ps1 `
  -UnityExecutable '<installed Unity executable>' `
  -UnityProject 'Server/.local/coop-geometry-project' `
  -SecondUnityProject 'Server/.local/normal-pvp-second-project' `
  -MongoExecutable '<installed mongod executable>' `
  -PairAdmissionSeconds 30
```

The thirty-second admission window remains diagnostic policy, not recovered production policy.
The current repository starter fixture still uses ten seconds. A real UDP socket selects the
test UDP port, and paired gameplay runs in a normal rendered Editor because the recovered
`RadicalRoutine` depends on `WaitForEndOfFrame`.

This is an intentional live transport replacement using the real Backend and Worker. It does
not inject packet loss, kill a network interface, test a reconnect timeout or expired account
session, prove every weapon/entity presenter, or verify Android. Those remain separate gates.
It does not force missing combat events or an unresolved command during replacement, so it does
not prove nonempty event-tail replay or pending-command deduplication in normal Unity gameplay.
Implementation alone is not a passing result; record the actual terminal run and reports below.

## Verified checkpoint

`.local/client-boot-e3cdda396a1441f78bcea76a05c34e14` exited zero. Both reports retain match
`m77e51e730f0c4b2cb21093d661d9621a`, Running, two players and successful reconnect completion.
The initiator records a pre-replacement simulation tick of 657, restored tick 671, one snapshot
rebuild and successful completion of the additional ninety-tick progress requirement. The peer
records no initiated replacement or local snapshot rebuild and confirms the same completion marker.
Neither reports a reconnect failure or an exception. Error-level diagnostics remain 142/143;
this is not a clean rendered gameplay run. Reports are `Unity-first-battle.json` and
`Unity-second-battle.json` in that directory. Both package manifest SHA-256 values remain
`7212bb6d4ae5db21b4fe5d10a4a0666d1f2c63618d8277b692254dd1c2c815a3`.

The Release build passed with zero warnings/errors. The earlier attempt
`.local/client-boot-ae0e6ebbcd0045258585c81b4e11596c` failed Unity compilation because a retained
AWS binary also defines `InvalidDataException`. The audit now uses `FormatException` for malformed
test markers; no dependency binary or recovered runtime source was changed for this checkpoint.
