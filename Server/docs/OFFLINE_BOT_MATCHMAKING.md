# Offline bot matchmaking and account synchronization

## Owner decision (2026-10-22)

Offline progression is uploaded and merged at the next successful Backend login.
This supersedes the earlier choice to keep it permanently separate.

## Client contract and behavior

`GameControllerDeathMatch.StartRandomMatchMaking` restores the recovered beginner,
measured high-ping, slow-device and repeated-loss bot selection. A disconnected
cached account also selects a bot. The original `RANKED PvP BATTLE` button is used.
Human matchmaking uses the self-hosted queue; its timed fallback awaits confirmed
queue cancellation before starting the local bot. Tutorial selection is unchanged.
`GameControllerDeathMatchOffline`, `BotManager` and `PlayerBot` run local combat.
No BattleServer or Photon Cloud is required for this bot simulation.

`BeanstalkServerManager` preserves the normal asynchronous response callbacks.
`OfflineBotProgress` answers local bot start/end requests and commits the outcome
before publishing the wallet/result callback. `ServerResponseHandler` remains the
consumer of the recovered result response fields. Cached boot uses the normal
configuration, login and player-data parsers, including primitive serialization
of protected integers in `DatabaseSerializedObject.CaptureOfflineSnapshot`.

## Persistence and reconciliation

A successful initial Backend login is required to cache account/configuration data.
Each account and Backend endpoint has a separate file in Unity persistentDataPath.
Writes replace the file atomically and retain a backup. Passwords and access tokens
are not added to this cache. Unsupported offline purchases/actions fail explicitly.

Bot outcomes have a persistent stream ID and monotonically increasing sequence.
GetPlayerData uploads pending outcomes; the Backend atomically commits rewards,
rank progression and the stream high-water mark in one player-document CAS update.
Only an acknowledged prefix is removed locally. Concurrent/repeated requests and
overlapped batches cannot grant that prefix again. A stale local wallet never
replaces the online wallet. Gaps and malformed amounts are rejected.

Supported imports: battle XP, rank advancement, policy-defined base WarBucks,
source-table level-up rewards, and bounded local crate/ribbon Gold/WarBucks.
Rank thresholds and base rewards come from Backend policy/catalog. Local results
are **device assertions**, explicitly accepted for this owner-requested offline
import; they are not Worker-verified combat. Ranked medals, leagues, squad scores,
missions, achievements and inventory/card changes are not imported by this journal.

Explicit reconstruction limits: 100 pending outcomes, 16 persistent device streams
per account, 100,000 XP, 1,000 extra Gold and 100,000 extra WarBucks per outcome.
Base fallback policy is 800 WarBucks for wins and 400 for losses, matching the
Backend default; these are not recovered production prices. The latest server
policy is cached for offline presentation. Server policy at import is authoritative.

## Verification and remaining boundaries

Native Unity 2018.3 run `client-boot-04c1016023334da2928d9637eb86b4f3` passed:
normal beginner matchmaking -> local bot running -> forfeit -> visible result;
Backend stopped -> cached account boot retaining the pending outcome;
Backend restarted -> normal login -> pending outcome acknowledged and removed.
The gameplay audit reported no errors/exceptions. Editor Visual Studio integration
exceptions are counted separately because they do not originate in game code.

`OfflineBotSyncTests` exercises concurrent uploads, replay, overlapping suffixes,
sequence gaps, invalid outcomes and isolation from ranked competition using MongoDB.
`ClientBootSmoke.ps1 -VerifyStarterBot` repeats the native flow using a disposable
project. `VerifyStarterQueue` remains a parameter alias for compatibility.
Normal-queue auditing checks admission before fallback, not indefinite waiting.

Not established by this proof: native timed fallback under cancellation races,
a second battle while fully disconnected, win/rematch UI, first-ever serverless
registration, Android file replacement, or complete offline inventory/mission
synchronization. Do not describe the bot proof as two-human online gameplay proof.

Final server verification: Debug solution build (0 warnings/errors), 1,365 protocol
checks, concurrent MongoDB offline-import tests, native smoke run
`smoke-c529b047525b41e492a3be2129e5641c` and 561 legacy assertions in
`legacy-42971a241c884ea3a9f6d876898218e2` passed. Small native Unity reports are
retained under `validation/offline-bot-20261022`; disposable Mongo data is cleaned
by the test runner. The Unity source snapshot is verified before removing the
owned disposable project; the owner's active Client Library is untouched.

Cleanup limitation: automatic approval review rejected recursive removal of the
owned disposable Unity project (`Server/.local/offline-bot-check/data/project`).
It remains on disk; no alternate deletion method was attempted. Test Mongo data
cleanup completed normally. The native source snapshot verified 15,609 inputs.
