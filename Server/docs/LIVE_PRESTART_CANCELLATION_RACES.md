# Actual HTTP and UDP prestart cancellation

The real Backend/Mongo/Worker queue fixture now opens three independent scoped
pairs with two portable SDK UDP connections each:

1. First participant is ready; authenticated HTTP cancellation completes before
   the other participant sends its fresh UDP Ready. That late command must return
   the aborted snapshot without a false command-consumption error.
2. The last UDP Ready and HTTP cancellation are dispatched without awaiting either
   first. Either legitimate ordering is accepted: cancellation stores an aborted,
   winner-free result, or Running wins and cancellation is refused. In the latter
   case an explicit UDP forfeit performs cleanup through normal authority.
3. Both participants reach the actual host Running phase before HTTP cancellation.
   Cancellation must be refused, no terminal result may be fabricated and the
   pair must remain allocated. A later explicit forfeit must retain its distinct
   completed-match winner and end reason.

Every case waits for Backend terminal acceptance and both players' pair release.
The stored protobuf payload is validated against its digest and the original
signed grant's manifest hash. These tests use actual network/process boundaries,
not the test-only Unity allocator facade. The concurrent case exercises live
scheduling; it does not force or exhaust all possible packet arrival timings.

## Reproduced SDK defect and fix

Before the fix, case 1 failed with `Battle host did not consume the pending
command`. The host correctly returned `match-terminal` without consuming a late
command, preserving its frozen terminal evidence. The SDK incorrectly required
that response to advance the command cursor as though the action had executed.

`MatchCommandAcknowledgement.TerminalCursor` now requires the exact terminal
refusal code, pending command identity, terminal phase, frozen end/server tick,
positive state revision, nonempty reason and the local participant's exact
consumed-or-previous cursor. It returns that proven host cursor. `MatchConnection`
clears the rejected pending intent without inventing consumption. Nonterminal
responses still require the original strict consumed-command acknowledgement;
invalid terminal metadata cannot discard unresolved work. This transport rule
does not validate settlement or grant a reward: Backend terminal acceptance
continues to own outcome authority.

The acknowledgement gate now has 22 assertions, including wrong cursor, phase,
tick, request ID, revision and reason rejection, plus aborted and completed
terminal responses. The standard Windows/Linux smoke scripts include it.

The actual HTTP/UDP fixture passes after the SDK fix, including the existing
three Backend restart and unattended Worker-outage recovery scenarios. Updated
Unity SDK binaries preserve asset identities and their digest manifest. The
native Unity matchmaking-to-Worker Play Mode regression passes with automatic
presentation; that facade remains preallocated and is not a two-Unity-client or
full recovered UI proof. Static asset checks retain zero missing scripts/broken
references and the same 17 preexisting sprite mismatches.

Deterministically paused registration/grant-publication races, broader network
fault schedules, full recovered UI, two actual Unity clients, Android and Linux
runtime still require work. B31/B36 and overall BattleServer completion remain
partial.
