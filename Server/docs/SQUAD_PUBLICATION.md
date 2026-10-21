# Squad publication

Thirteen direct 1.4.0 actions now use the `War.Backend/Legacy/Squads` feature: create, join, leave,
invite, request, approve, decline, promote, demote, transfer leadership, kick, update settings and
update emblem. Parsing and pure transition rules are separate from HTTP projection and Mongo writes.
`LegacySquadStore` retains read/index operations; its obsolete standalone mutation methods were
removed so normal Backend actions use one transactional publication path.

## Recovered rules

The source of these rules is the active `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp`:

| Evidence | Server behavior |
| --- | --- |
| `SquadRank` and `MiscTools.CompareSquadRanks` | Wire values Member=0, Veteran=1, Leader=2, Coleader=3; authority order Member < Veteran < Coleader < Leader |
| `MemberRecord.SetFunction` and promotion callback | Explicit 0 -> 1 -> 3 promotion and 3 -> 1 -> 0 demotion; only leadership transfer assigns 2 |
| `MemberRecord` rank comparisons | Veterans can act on lower members; Coleaders can demote/kick peers; no subordinate may kick the Leader |
| `SquadMemberContent.canBePromotedToColeader` | At most three Coleaders; this does not establish a general member capacity |
| `SquadInformationContent`, `SquadEmblemRecord` | Only the Leader changes settings/emblem; a larger numeric Coleader value is not more authority |
| `SquadRecord.JoinClick`, `JoiningSquadDialog` | A non-Leader can join/request another squad without a separate LeaveSquad request; move between rosters atomically on join/approval |
| `SquadRecord` medals check | Use persisted player Skill and destination SkillRequirement for admission; no client-provided skill authority or invented invite waiver |
| `SquadScreen.InviteToSquadClick` | Any member may invite to a public squad; a private squad requires Veteran-or-higher authority |
| `SquadScreen.LeaveSquadClick` | Transfer leadership before leaving a non-empty squad; the last member's delete confirmation removes the empty squad |
| `PlayerAnalytics.createSquadWarBucksPrice` | Capture the source per-creation price, then checked `(stored count + 1) * price`; validate the Client Int32 domain before charging |
| `DatabaseSquad` and `SquadCreateScreen.CheckSkill` | Name/message limits 15/100, medals requirement 0-5000; creation forwards UI-validated integer text |

`OldSquadRank` is an assertion against the current target rank, never permission to assign a rank.
A stale retry cannot advance a second step. Names/IDs and settings are validated again at the reusable
rules boundary. Creation accepts the UI's invariant integer text, including leading zero/sign/space
forms accepted by the source `int.TryParse`; rank assertions and UpdateSquad's integer `RequiredMedals`
must match their canonical `ToString()` form. `IsPublic` is exactly `0` or `1`. No malformed value is
clamped into an authorized transition. Create uses `SkillRequirement`; update uses `RequiredMedals`.

Creation policy is immutable per endpoint instance. Missing catalog closes priced creation; a malformed
configured price fails startup. Counters, funds, revisions, account membership, reverse roster membership,
unique roster identities/ranks, exactly one Leader, the three-Coleader limit, pending identities and
creation time are checked before mutation. The historical squadless rank zero remains an explicit
read compatibility case; new leave/kick results publish rank -1. Corrupt mirrors are not silently repaired.

## Transaction boundary

One snapshot/primary/majority Mongo transaction reads the authenticated actor, optional target,
destination/current squad, and an optional previous squad. Indexed reverse-membership queries select
at most two squad IDs per affected account: zero/one proves membership, while two is already invalid.
The operation does not load an unbounded account or squad history.

The rules build copied documents and explicit account changes. Publication writes the selected squad,
then the optional previous squad, then at most two affected accounts. Every write checks the revision
read in that transaction and advances it. Creation inserts the name claim, account membership, debit
and creation counter together. Cross-squad admission removes the previous roster entry and changes
the destination and account pointer together. Founder transfer updates both ranks and the roster
together. Leave/kick never leave one mirror behind; last-member leave deletes the squad in that same
transaction. A roster write also conflicts with the card-pool membership fence from C03.

Transient conflicts re-read and recalculate using one captured application second. Duplicate name
claims receive at most four additional transaction attempts; the operation has a linked 30-second
deadline. Malformed request assertions return WrongPlayerData. Invalid durable squad authority
aborts the transaction, logs actor/action metadata without credentials, and returns ServerMaintenance
through the ordinary Client-readable JSON contract.

Concurrent distinct joins/approvals may both succeed in a valid serial order: the first admits the
non-Leader and the second moves that same player. Correctness means one final roster and a matching
account pointer, not arbitrarily suppressing a legitimate second move. A Leader must explicitly transfer
leadership first. If the source Client's separately dispatched founder/leave requests arrive in reverse
order, leave refuses while the actor is still Leader; the server does not invent a successor or rewrite
the Client's call order.

## Response and retry boundary

Create always includes `SquadId`, `PlayerRank` and Dynamo-shaped `Squad`; `squadCreationsCnt` reflects
the committed counter. Join always includes `SquadId`/`PlayerRank`. Approve, promote, demote, founder
transfer and kick reuse the existing Player projection under `joinedPlayer`, `PromotedPlayer`,
`DemotedPlayer` or `Player`. Other success handlers require only Result. Failures carry Result and
do not project an invented successful transition.

The source builders provide no per-intent nonce. Repeated create while still a member refuses without
charging again; same-squad join refuses without adding membership; stale OldSquadRank refuses without
another promotion. These are state safeguards, not permanent replay receipts. Delayed unkeyed requests
after another legitimate move/leave remain indistinguishable from new intent. C03's deliberate Client
operation-identity migration must include direct squad mutations for stronger replay semantics.

No general squad-capacity formula, first-join reward receipt, delivered inbox/notification transport,
or Squad War lifecycle was invented here. Those existing reconstruction boundaries remain explicit;
this increment does not prove full Unity gameplay, live competitions or complete shared player-state
validation (C13).

## Verification

- `--legacy-squad-only`: six source-rank, authority, admission, creation, damaged-state and form-parser
  scenarios, including overflow, stale rank assertions, private invitations and medals requirements.
- `--legacy-squad-transactions-only <replica-set-uri>`: five forced competing-read scenarios (two
  creates, same-name claim, two joins, two approvals, founder versus peer kick) and thirteen injected
  publication failures. Mongo validators fail the first/second account write or previous-roster write;
  complete before/after account and squad snapshots must match after rollback.
- `--legacy-squad-http-only <uri> <database> <base-url>`: 45 real authenticated HTTP assertions cover
  all thirteen mutation actions, mandatory callback fields, rank ordering, stale/invalid requests,
  invalid-mirror refusal, cross-squad join/approval, price escalation, former-Leader permissions and
  deletion on final leave. Trusted disposable accounts supply source-priced funds; normal account
  creation remains independently covered by the existing legacy smoke.

`LegacySmoke.ps1` runs the pure/transaction checks before starting its Backend, then runs the HTTP
fixture after the original 338 assertions. It reuses the same owned isolated replica set and existing
test-run directory; temporary fixture records are scoped to generated IDs and cleaned up. No extra
Mongo process, database directory, Unity copy or complete combat-suite rerun is needed for this gate.
