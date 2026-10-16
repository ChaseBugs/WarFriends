# Co-op departure receipt recovery

Recovered `FinishGameCoopClient -> DisalblePlayerAndResumeGame` removes the
non-master peer's active participation while its master continues. The host
must preserve that peer's original command receipt even though new gameplay
and a replacement admission are no longer allowed.

## Reconnect eligibility

`MatchEndpoint.CanReconnect` previously checked only terminal/expiry state,
known generations and an existing transport session. A departed co-op peer
retains its old session for receipt replay, so those checks could authorize a
replacement grant even though `CoopMatchRuntime.Resume` later rejected it.

`IMatchRuntime.CanResume` now exposes a read-only eligibility check. Co-op
requires an admitted, non-departed participant in a nonterminal mission. PvP
keeps its existing admitted/nonterminal rule. The endpoint consults this check
before the router can issue a replacement grant. It does not call mutating
PvP `Resume`, which refreshes presence and clears reconnect state. Old co-op
sessions still recover original receipts through the normal command path.

## Real UDP and SDK fixture

`CoopDepartureUdpTests` starts two portable `MatchConnection` clients against
a loopback UDP host containing the actual authenticated `MatchEndpoint` and
source-backed `CoopMatchRuntime`. Signed capabilities, packet authentication,
real datagrams and SDK pending-command recovery are used throughout.

The host consumes the peer's Forfeit but suppresses every automatic response
to that command until the SDK times out. The master then polls and sees its
mission still running with only itself active. Reconnect authorization rejects
the departed peer and retains the master without changing the runtime snapshot.
Once responses are enabled, `RetryPendingAsync` recovers the byte-identical
original reply and command cursor. A new departed-peer movement is rejected
without advancing that cursor; the SDK deliberately rejects an unconsumed
mutation. The master can acquire the released cover, then close the mission
with its own Forfeit.

The fixture uses a bounded local socket pump, host-owned elapsed ticks and a
30-second cancellation budget. It does not run the normal `NetworkWorker`
co-op admission path or prove HTTP grant issuance, normal Unity response-loss
presentation, durable per-player settlement or two-Client gameplay. Those
boundaries remain in [the peer presentation report](COOP_PEER_PRESENTATION.md).

Windows verification: the focused combat-content executable passes 26,368
counted assertions plus the new UDP fixture. The complete Battle executable
passes 143,264 counted assertions, including existing PvP reconnect and Worker
flows; that total can vary with timed UDP poll rounds. Sequential native Mongo
smoke builds without warnings/errors, passes 1,051 protocol checks and 74 live
MongoDB/HTTP/protobuf/UDP checks, and preserves evidence across Worker restarts.
This checkpoint does not establish a new Linux or Unity gameplay result.
