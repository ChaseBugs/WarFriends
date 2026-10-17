# Session reads without Photon fallback

The recovered room helper now reads the canonical `SelfHostedBattleClient.Active`
owner rather than searching only active scene objects. An inactive GameObject
does not release an admitted/recovering connection. GetOrCreate also returns that
owned adapter before discovering a free one, preventing a second adapter from
silently replacing it.

## Read contract

| State | Clock | Player count | Battle ID | Room flag |
| --- | --- | --- | --- | --- |
| Owned self-hosted connection, no snapshot | 0 (unknown) | 0 (unknown) | Empty | Owned, as before |
| Owned connection with snapshot | ServerTick / 30 | Snapshot roster count | Snapshot match ID | Owned |
| Local solo model | Recovered local clock | Model count | Empty | Model membership |
| No owner/local room | Recovered local clock | 0 | Empty | False |

The zero clock/count before the first snapshot are not proof of admission or
elapsed server time. Reads never borrow a stale Photon room or use a local clock
as self-hosted authority. Inactive owned snapshots keep the same behavior as
active owned snapshots.

The recovered Photon offline clock defaults to Environment.TickCount, converted
through unsigned 32-bit milliseconds and divided by 1,000. The wrapper preserves
that epoch, fractional seconds and rollover without reading PhotonNetwork.time.
The recovered precise-timer flag is private and initialized false in the package
source. This is a local presentation clock, not server UTC/economy authority.

## Verification and remaining work

`UnitySessionReadAudit` checks idle reads inside the actual local clock interval,
direct local-model join/disconnect reads, an inactive owned adapter before its
snapshot, a controlled 75-tick/two-player snapshot and owner reuse. It closes its
own SDK connection and restores local state. These are controlled metadata/model
checks; there is no actual Worker admission in this fixture.

The combined native source Chat/region/session/retry/cancellation suite passes
in `Server/.local/unity-session-read-boundary.log`. This does not migrate the
existing local solo Photon room creation/callback path, global boot, direct
Photon callers elsewhere, ownership/serialization or ordinary full gameplay.
Those remain separate requirements. Unity 5.2, Android and two Unity clients are
not proved by the disposable Unity 2018 gate.

## Inactive owner disconnection

The actual Disconnect command now prefers the same canonical retained owner.
Only when there is no canonical owner does it search active scene adapters,
preserving the existing pre-admission matchmaking path. Disabling the owned
GameObject must not route disconnection through legacy singleton/Photon cleanup.
The original LeaveMatch recovery-suspension and queue-cancellation guards remain
in force; this change does not assert that a local close cancels a server battle.

The native baseline in `Server/.local/unity-inactive-disconnect-baseline.log`
reproduced the actual command leaving the inactive connection owned and entering
unrelated legacy initialization. The session audit now calls that command instead
of directly calling LeaveMatch and requires ownership release followed by idle
reads. Its controlled connection has no live Worker or matchmaking attempt.
The fixed command and the existing combined NGUI/component regression pass in
`Server/.local/unity-inactive-disconnect-final.log`, with no unexpected runtime
errors. The same fixture still does not prove live-server cancellation or full
menu boot.

The existing four-state controller recovery and four injected cleanup-failure
controls also pass with the canonical owner lookup:
`Server/.local/unity-session-read-abort-routing.log`. Static asset checks still
report zero missing scripts/broken references across 288,165 nonzero references;
the 17 existing sprite mismatches remain unchanged. No SDK binary, scene/prefab
or script GUID changed.
