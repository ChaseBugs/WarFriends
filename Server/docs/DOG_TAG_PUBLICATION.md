# Dog-tag authority and publication

Actions 70 (RefillDogtags), 129 (PayOneDogTag) and 195 (OnVIPExpired) follow the active recovered
1.4.0 DogTagManager, VipManager, request builders, callbacks and live callers. Source bodies remain
unchanged in Clients. Seven additional reviewed source sections join the headless Client oracle.

## Recovered rules and corrected behavior

| Rule | Authoritative behavior |
| --- | --- |
| Base capacity | DogTagCap 5 times DogTagRefillTime 900 = 4500 seconds |
| VIP bonus | Two tags = 1800 seconds while Vip is strictly later than request time |
| Regeneration | Base seconds plus elapsed time; cap the base at its maximum using Int64 intermediates |
| Display/price | Add active VIP bonus, then clamp to zero through base-plus-bonus maximum |
| Refill price | 35 - 2 times the complete currently available tags; already full costs nothing |
| Penalty | Subtract one 900-second period from capped base seconds, preserving negative debt |

The old server floored penalty debt at zero, omitted VIP from price/fullness and used Int32 addition
before clamping. For an empty pool at the same second, PayOneDogTag must retain -900 base seconds;
display remains zero until regeneration repays that debt. An empty base pool with active VIP has two
available tags and a 31-Gold refill, not 35. VIP bonus is never stored in the base pool or applied twice.
The Client's local optimistic-use counter is presentation; it does not authorize server consumption.

Policy resolves once from the immutable catalog. A configured starter capacity must agree with the
source product. Fractional/missing/negative policy, arithmetic overflow and capacities that permit
negative refill prices fail before traffic. Without a source catalog, mutation actions refuse with
maintenance rather than guessing a period from the player's mutable capacity. Boot can still project
a valid base tuple in explicit catalog-free compatibility mode.

## Storage and clocks

`Legacy/DogTags` separates source policy, pure calculation and direct callback projection.
`War.Persistence/Legacy/DogTags` validates the reusable durable tuple and publishes the complete
seconds/cursor/wallet successor in one Mongo FindOneAndUpdate. Its filter binds account revision and
the authenticated session. Each attempt re-reads current authority; a definite CAS conflict recalculates
from that successor. Eight attempts bound contention. Insufficient funds and already-full outcomes
are read-only. Session rotation refuses an obsolete caller rather than copying its state back.

Each mutation captures one DateTimeOffset and derives one exact nonnegative signed-Int32 Unix second.
The same captured instant owns session validation, regeneration, VIP selection and the committed
cursor. A concurrent later cursor causes an older request to fail closed, not rewind time or recapture
a new time silently. Driver retryable writes retain their normal acknowledgement semantics; the
application does not retry an uncertain write as a fresh mutation.

Negative base debt is valid. Invalid capacity, above-cap stored base seconds, negative/future cursor,
negative wallet/VIP authority and debt underflow are refused before writing. Overflow is never repaired
into a free/full pool. Historical corrupted or capacity-mismatched state requires explicit migration;
this feature does not normalize it into new authority.

`Legacy/Progression/LegacyPlayerDataEndpoint` applies pending buffers before projecting their committed
account. Boot then captures one validated clock for response Time, rebased dog-tag seconds/cursor
and UTC midnight. Rebasing is read-only and preserves debt while avoiding old Int32 overflow in the
Client. `Legacy/Time/LegacyClientTime` owns the recovered wire time bounds. This is not a claim that
every subsystem's durable state or all nested buffer clocks are validated under C13.

Refill success carries Gold. Penalty success carries LastUpdate and Seconds. These are unguarded
callback reads. VIP expiry returns both guarded resynchronization fields, without deleting debt or
persisting a synthetic VIP reward. BuyVip/provider verification remains outside this change.

The original direct requests contain no stable per-intent nonce. Concurrent refills of the same empty
pool debit once; every distinct penalty request consumes one period. A replay after intervening state
changes cannot be distinguished from a new intent. No per-intent exactly-once claim is made here;
that requires a deliberate Client/server protocol change, as with the other anonymous direct mutations.

## Verification and footprint

- The headless oracle compares 144 debt/elapsed/active-expired-VIP combinations with unchanged Client
  getters and the original PayOneDogTag body, plus invalid-authority and policy groups (146 scenarios).
- Real Mongo tests force refill/refill, penalty/penalty and mixed races from the same initial revision,
  wallet/session/clock changes, corrupted authority and a server-rejected atomic write (eight groups).
- Live HTTP checks cover mandatory callback fields, VIP price, negative debt, one boot clock,
  read-only expiry projection and future-cursor refusal across all four action/boot paths.

The existing oracle runs in fast/runtime/full checkpoints. `LegacySmoke.ps1` reuses its one owned
replica for dog-tag store/HTTP tests, without extra Mongo directories or password derivation for
noncredential fixtures. Pure tests use memory and existing source files; no Unity copy/export is made.
See [TESTING.md](TESTING.md) for report retention and runtime verification boundaries.
