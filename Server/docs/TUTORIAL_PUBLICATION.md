# Tutorial identity publication

This implements C22 for the active recovered 1.4.0 tutorial handshake. It is an unrewarded tutorial
acknowledgement, not authoritative combat settlement. Gold, WarBucks, XP, ranks, cards, achievements
and combat results are not granted from the client's report. Ordinary host-derived GameEnded remains C18.

## Recovered contract

Action 119 GameStartedTutorial sends a diagnostic Name. Its OnTutorialStarted callback directly
indexes BattleId, assigns a nonempty value, then continues the local tutorial. Name cannot replace
the authenticated player's identity. The server returns a canonical lower-case 32-character N GUID.

Action 120 TutorialEnded sends BattleId and several assertions: EndReason, Experience, GoldBoxes,
WarBucksBoxes, ObtainedCards, UsedCards, Warbucks, Gold and ArmyPower. The builder chooses Win locally;
none of those asserted outcomes or amounts becomes server authority. BattleId must occur exactly
once and match the current durable tutorial identity. Missing, padded, uppercase, repeated, malformed
or unrelated IDs return the existing GameDidntExist result without changing state.

OnGameEnded chooses the classic branch when IsWarArena is absent. OnClassicGameEnded indexes
LevelExperience before checking TutorialData presence; both keys are required for the successful
tutorial path. The minimal response is Result, current server LevelExperience and TutorialData=true.
No GameReward, Level, Skill, Arena or other reward-bearing tuple is fabricated. The wrong-battle
error branch requires no response fields beyond its result code.

## Structure and schema

Backend/Legacy/Tutorial owns canonical request parsing and callback projection.
Persistence/Legacy/Tutorial owns versioned identity, mirror validation and atomic publication.
The router no longer has separate unconditional start/end methods. General LegacyPlayerStore.Update
was removed after its final production callers migrated; four trusted test perturbations now use
LegacyTestAccounts.UpdateForTestAsync, which is unavailable to the production application.
The fixture-era SetSerialized API was also removed after migrating its nine card-inventory writes
to LegacyTestAccounts.SetCardsForTestAsync. Settings/analytics tests assert that the generic production
API stays absent; trusted setup no longer requires an unrestricted production write method.

New TutorialState is one exact BSON document:

| Field | Required representation | Meaning |
| --- | --- | --- |
| Version | Exact client-width integer 1 | This schema version |
| BattleId | Exact BSON string, canonical N GUID | One account's issued tutorial identity |
| Completed | Exact BSON Boolean | Pending versus terminal acknowledgement |

The existing mirrors remain for boot compatibility. Pending means TutorialCompleted=false and
PendingTutorialBattleId equal to BattleId. Terminal means TutorialCompleted=true and no pending ID.
Mirrors must agree exactly with the versioned document. Unsupported versions, missing known members,
unknown document members, coercive BSON types and inconsistent mirrors are refused.

An absent TutorialState is a legacy schema input. A present BSON null/container of another type is
damage, never an empty new state. TutorialCompleted itself is now a required exact BSON Boolean;
the pending ID permits source-null but no number/symbol conversion. Shared account/auth reads, boot,
buffer planning and buffered current-player checks validate the identity/mirrors before authority use.

## Transition and replay rules

One supported application time owns the session check. Up to eight compare-and-set attempts are
allowed, with one proposed new GUID retained across conflicts. Publication requires current Revision,
same SessionHash, live session deadline and the exact old tutorial mirrors/document. It sets the
new versioned state and both mirrors with one revision increment in one single-document write.
No additional Mongo process or multi-document transaction is needed.

| Current state | Start | End with matching ID |
| --- | --- | --- |
| Unstarted legacy account | Issue one versioned pending ID | Refuse: no matching identity |
| Legacy pending ID | Adopt that same ID into version 1 | Publish terminal version 1 using that same ID |
| Versioned pending | Return its ID without writing | Atomically publish terminal marker and clear pending mirror |
| Versioned terminal | Return the same ID without reopening | Return a read-only identity-bound replay |
| Legacy completed without ID | Refuse mutation pending trusted migration evidence | Refuse to bind a new request as historical proof |

Two simultaneous starts converge on one ID. Two ends publish one terminal transition. If old end A
loses its compare-and-set to a new valid pending B, the retry revalidates identity and returns
GameDidntExist; it cannot clear or complete B. Session replacement/expiry refuses both start and end.
A failed database write leaves all mirrors, identity, wallet and metadata unchanged.

With unchanged account progress, duplicate end responses are exactly equal. LevelExperience is a
current authoritative projection, not a cached historical value: a delayed old tutorial acknowledgement
must not reset later progression in the original callback. Repeating a bound ID consumes no revision.
Assertions ignored on the first request remain ignored on replay; a different BattleId is not a replay.

## Explicit legacy migration boundary

No new ID, timestamp, reward or completion history is inferred for an old completed Boolean whose
pending ID was already cleared by the old writer. That record remains readable and its existing boot
TutorialData marker is conserved. Start/end return maintenance instead of blessing request data as
terminal evidence. Normal boot does not reopen onboarding or reset this marker.

Only unambiguous unstarted/pending records migrate automatically inside the same compare-and-set.
An operator migration for unbound old completion requires a trusted historical account/battle binding
and a reviewed preimage/revision plan; without it the terminal record remains read-only. No such
evidence is invented or silently repaired. Broader schema migration tooling remains C13.

## Verification

Seven reviewed sections bring the source inventory from 64 to 71 without changing prior hashes:
both builders, start callback, dispatch, complete classic callback, its tutorial completion excerpt
and wrong-battle error branch. The actual start callback, dispatch, contiguous XP/tutorial excerpt
and error branch execute unchanged with instrumented controller, progression and restore boundaries.
The entire classic method is hash-reviewed and its optional reward paths were inspected; they are
not executable gameplay coverage. Local restore calls are recorded, not sent to a retired provider.

Four pure groups cover legacy/canonical shapes, required BSON fields/types, exact IDs and original
mandatory callback reads. Eight Mongo groups force initial reads before competing starts/ends,
old-A/new-B replacement, rotated/expired sessions, legacy migration/refusal, corrupted state and
server-rejected start/end writes. Twenty HTTP checks cover replay, minimal callbacks, assertions
ignored without rewards, current XP, boot markers, legacy read-only state and malformed authority.
The tests reuse the owned legacy replica and trusted fixtures without password derivation or Unity copies.

Run IDs and integrated results are in TESTING.md. C22 closes the stated identity/race boundary;
it does not close C13, ordinary combat/reward authority, actual Unity gameplay, Android, production
Linux or source provenance V07.
