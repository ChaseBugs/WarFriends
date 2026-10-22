# Daily reward calendar — active 1.4.0 contract

Implemented on 2026-10-22 for missing.md BE07.

## Recovered evidence and explicit policy

`BeanstalkServerManager.claimDailyReward` emits action 1002 and `claimRweard`.
`DailyRewardMonthScreen.DailyRewardSerwerData.UpdateFromData` requires year,
month, canClaim, claimReward, nextDay and ordered DayN config entries. Each entry
requires Type, Double, Count and Param. `StatsManager.DailyRewardDataLoaded` reads
ok, addedType and added on a successful claim and applies the currency delta.

The retired production reward schedule is absent. The offline deployment policy
is explicitly Gold-only: 5 Gold per attendance credit, 25 on each seventh credit.
Configure `Legacy:DailyRewards:OrdinaryGold` and `Legacy:DailyRewards:WeeklyGold`
(environment equivalents `Legacy__DailyRewards__OrdinaryGold` / `WeeklyGold`).
Startup accepts only canonical nonnegative integers, with weekly at least ordinary
and both within the safe integer domain. Values are immutable per process and
copied into the first calendar opened each UTC month. Restart/config changes do
not rewrite an already-open calendar. No VIP/social doubling is advertised.

One visited UTC day earns one credit; missed days are not backfilled. First visit
on the 22nd opens credit 1, not 22 credits. Claims are ordered and bounded by earned
credits. The client timezone offset is never calendar authority. Expired calendars
carry no authority forward; invalid coordinates and future calendars are rejected.

## Ownership and replay

The legacy endpoint handles canonical parsing and exact response projection.
Persistence owns the calendar, attendance transition, checked currency addition,
authenticated revision CAS and claim cursor in the same player document. Shared
account validation rejects corrupt current calendars, and exact BSON integer
serializers reject floating/string counters. No BattleServer write is involved.

A claim additionally carries `CalendarId` in yyyy-MM form, derived from the displayed
calendar. This deliberate Client/server extension binds retries to their original
month. The original claimRweard spelling is preserved; claimReward is accepted only
when it is the sole day field. Old clients lacking CalendarId cannot claim safely
and must update with the server. The lookup action remains compatible.

Repeated claims return zero added Gold and the current calendar. The small
DailyRewardWallet response extension reconciles the Client wallet after its original
parser, so both lost responses and repeated callbacks converge on server balances.
Concurrent claims cannot grant twice, and an overflow does not advance the cursor.

## Verification

`--daily-reward-store-only <owned Mongo URI>` checks concurrent claims, restart
replay, altered policy, canonical parsing, wrong session, stale calendar identity,
leap-month bounds, rollover, future/corrupt state and reward overflow.
`LegacySmoke.ps1` exercises the HTTP lookup, required parser fields, claim and replay.
`ClientBootSmoke.ps1 -VerifyStarterBot` now first calls the real Client claim method
twice and asserts one Gold increase before continuing the bot/offline/login test.
Native run `client-boot-ad956583ec574a26a717574ee8903913` passed this flow; reports are
under `validation/daily-reward-20261022`.

This implements the configured Gold calendar, not unrecovered production card,
VIP, customization or Arena-ticket calendars. It does not complete other mission,
achievement, Arena or league work packages in missing.md.

Final verification for this increment: Debug solution build passed without warnings
or errors; daily reward Mongo tests and 13 dispatch groups passed. Native smoke
`smoke-258d4aadd2b44739a843277894ba1de1` passed 74 live checks plus 1,365 protocol
checks. Legacy HTTP run `legacy-9361d25e126044baa3c978915ac1ae88` passed 562 assertions.
Client source inventory verified 15,609 inputs after the native run.
