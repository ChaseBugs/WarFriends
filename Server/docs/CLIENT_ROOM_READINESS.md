# Local room readiness ownership

The SDK's Waiting/Countdown observer previously advanced the local room from
Loading to Ready when any participant was ready. This blocked normal asymmetric
loading: if the peer finished first and the local client polled, its own
`MarkReadyAsync` rejected the later scene-ready notification because the room was
no longer Loading. The host still had that participant marked not ready.

## Behavior

`MatchConnection.LocalPlayerId` exposes the participant identity from its owned
grant copy. `SelfHostedRoomLifecycle` now examines only that participant when
projecting Waiting/Countdown readiness. The local row must be both admitted and
ready. A missing row keeps Loading; duplicate local rows are rejected before
changing the phase. A peer's readiness does not complete local scene loading.

Ready still reaches the server as the existing authenticated command. This change
does not grant client authority over the match start: authoritative Running and
terminal snapshots retain their existing lifecycle handling.

## Evidence

The actual UDP SDK fixture reproduced the peer-first failure before the fix.
It now connects both room lifecycles, sends the first player's Ready, lets the
other client observe that snapshot through Poll, checks that it remains Loading,
then sends its own Ready and observes the source mission becoming Running.
The same setup covers partial-return and completed-return pose delivery, including
negotiated/clip-only peers and frozen chunk reassembly.

Core tests additionally check duplicate phase notification suppression,
peer-only readiness, an unadmitted local ready row and the admitted local row.
Duplicate local rows must reject without publishing a phase change.
This is SDK/lifecycle proof. It does not verify two normal Unity scenes loading,
the recovered loading UI, Android or the complete Worker/Unity boot path.

## Projectile regression check

The full battle suite exposed an independent timing assumption in its live
Shotgunner test: it compared an earlier live snapshot with a later projectile
scan and required all five rows to fit in one datagram. A scan freezes its own
tick and can contain multiple pages. The test now fetches and replays every
page of the same scan, requiring identical protobuf bytes, ordered unique IDs
and conserved row counts. It compares live IDs only when both observations
share a tick and the live snapshot is complete. Both UDP peers must still
observe the burst, and a complete scan must still contain one real pellet and
four harmless pellets. This changes test expectations, not combat behavior.

## Installed SDK checks

The rebuilt portable SDK is installed in the active Client with its SHA-256
manifest. Windows verification passes the 1,144 protocol checks and the native
MongoDB/HTTP/protobuf/UDP smoke, including 74 live checks and result-outbox
restart recovery. The first isolated Mongo startup exceeded the bootstrap's
30-second timeout; a fresh unchanged rerun passed.

In the disposable Unity 2018.3 project, the installed SDK passes the match-scope
component audit and all 24 walking/pose presenter checks. Asset reference audits
still report zero missing scripts and broken references; the existing 17 NGUI
sprite mismatches are unchanged. These component and static checks do not prove
normal scene loading, rendered gameplay, Unity 5.2, Android or Linux runtime.

One complete battle-suite run passed 143,201 assertions. A later run, including
the additional duplicate-local-row checks, passed this readiness regression but
failed the separate live RPG bonus-box collection fixture
(`LivePvpBonusUdpTests.RunBazooka`). That checkpoint therefore had a failing
latest full-suite run. The earlier pass could not establish a reliable release
gate while the intermittent collection result remained unexplained.
The ordinary bonus UDP fixture and the RPG fixture both passed their subsequent
isolated reruns without code changes. That does not resolve the full-run failure.

The subsequent [RPG occlusion investigation](PVP_RPG_CRATE_OCCLUSION.md) reproduces
that failure against the exact City tires geometry and original Unity Physics.
The UDP fixture now uses normal cover movement before retrying the shot. See
that checkpoint for the current verification scope and subsequent full-suite pass.
