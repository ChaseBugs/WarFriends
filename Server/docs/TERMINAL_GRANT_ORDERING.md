# Terminal result and grant publication ordering

Normal backend-allocated terminal acceptance and grant publication both write
the same durable pair. Result acceptance inserts the terminal evidence and
deletes that pair in one snapshot/majority transaction. Grant publication touches
the pair and inserts its grants in another snapshot/majority transaction.
An overlapping write must retry against current allocation authority.

The allowed outcomes are:

| Committed order | Grant publication | Durable state after terminal acceptance |
| --- | --- | --- |
| Grant first | `published` | Exact result, no pair, earlier grant retained as history |
| Terminal first | `cancelled` | Exact result, no pair, no new grant |
| Concurrent dispatch | Either outcome above | No grant committed after its terminal result |

The retained earlier grant is not permission to re-enter a completed battle.
Normal queue delivery requires an active pair, and the Worker owns terminal
admission refusal. This storage gate does not replace those separate checks.

## Executable gate

`TerminalGrantRaceTests` runs inside `--atomic-terminal-only <MongoUri>`, already
included in both native smoke scripts. It checks one grant-first case, one
terminal-first case and twelve overlapping asynchronous dispatches. Every case
uses an isolated newly allocated pair and a frozen manifest. `MatchEngine`
admits both participants, advances Ready/countdown to Running and produces a
real forfeit terminal snapshot.

The database change stream observes committed writes. A retained grant's
`clusterTime` must be strictly earlier than its result insert, using MongoDB
logical timestamps rather than application wall time. The test also checks
publication status, final grant presence and removal of the exact pair. The
existing atomic gate independently requires result insert and pair deletion
to share their session ID and transaction number, then checks concurrent replay.

The participants, weapon values, views and opaque ticket strings are storage
fixtures. They are not Worker-signed admission, recovered combat balancing,
normal Client queue requests or a playable Client setup. Concurrent dispatch
exercises real independent Mongo sessions but does not force every internal
read/write scheduling point. Full HTTP/UDP scheduling, two actual Unity clients,
Android/Linux runtime and overall BattleServer completion remain separate gates.

## Checkpoint evidence

Windows run `Server/.local/smoke-a6b06703e2414cc5aaf7ecf102b05ed2` passed all
fourteen ordering cases, the atomic transaction/replay gate, 1,322 protocol checks
and 74 live Mongo/HTTP/protobuf/UDP checks. The solution built without warnings
or errors. This does not change the separately documented full `--queue-live`
timeout or certify every internal database scheduling order.
