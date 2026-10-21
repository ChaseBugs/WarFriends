# Recovered 1.4.0 buffered response contracts

The machine-readable review is [legacy-buffer-contracts.json](legacy-buffer-contracts.json).
It covers all 25 actions in `LegacyBufferProcessor.Implemented`, grouped by the actual callback
branches in the active Client's `ServerResponseHandler.ProcessBuffer`. This inventory is a response
contract, not a claim that every Client result code is reachable from every server action.

## Executable evidence

`War.LegacyContract.Tests` compiles the unchanged callback body, complete `StringParser`, and Client
action/result/item enums into a private test namespace. The generator checks reviewed SHA-256 values
before compilation. It reads Client files in place and writes only one generated file under `obj`.
The same provenance check runs separately before the no-build fast gate.

The test uses the original Client's Newtonsoft.Json binary. Its Unity value converters also require
the original managed `UnityEngine` assembly for type metadata. Both dependencies have reviewed hashes
and remain test-only references. No Editor, native engine, Unity project clone, asset import, Library
copy, Mongo instance, or retired online service is used by this test.

The actual callback and value conversions execute. Manager/UI boundaries are instrumented substitutes:
they decode JSON strings, track calls and retain dialog callbacks. They do not execute full inventory
selection, rendering, scene state, Unity notifications, or gameplay. Full Client/runtime proof remains
a separate integration gate. Their source-compatible method signatures and member names intentionally
match the recovered call sites.

Six additional reviewed source properties compile into the rank oracle: `GameLevel.displayNumber`,
weapon/unit `canBeBought`, visual `unlockLevelIndex`/`isUnlocked`, and the promotion lock predicate.
These predicates execute unchanged against simple rank/row boundaries; they do not load gameplay.

Ten more reviewed getters/methods from WeaponLevelsSetup, UpgradeSlot and UpgradeSlotElite compile
unchanged into the upgrade oracle. With the dog-tag, Settings and root source sections below,
provenance contains 71 source entries plus the
original binary hashes. All 66 weapons and 24 player-unit tracks are compared at normal, tier and
Elite boundaries. These getters execute against sheet/owner boundaries without native Unity.

The same small executable also compiles unchanged DogTagManager getters and PayOneDogTag against
instrumented clock/VIP/UI boundaries. It compares 144 source debt/elapsed/VIP combinations and runs
two invalid-authority/policy groups. Builders and callbacks join the source-hash review; direct wire
and persistence checks run in the owned legacy Mongo/HTTP suite. See
[DOG_TAG_PUBLICATION.md](DOG_TAG_PUBLICATION.md). No additional Client DLL or project copy is needed.

Four Settings sections add the actual POCO/default-initialization body and builder/callback review.
The executable distinguishes absent Client defaults from explicit all-false flags, then checks exact
six-Boolean requests, durable metadata and malformed state. Five shared stored-state groups also
exercise strict scalar reading, absent/present-null distinction, metadata conservation and resource
limits. See [STORED_STATE_VALIDATION.md](STORED_STATE_VALIDATION.md); broader state semantics remain C13.

Three root sections add the unchanged Army Power scaling getter and League enum, plus the reviewed
beginner-name mapping. Five in-memory root groups prove exact BSON integer/presence constraints,
wallet/rank/tier domains, the Client multiplication overflow boundary and source placement policy.
Global and division medal counts remain independent. The actual Mongo/HTTP refusal and rollback
checks reuse the same owned legacy smoke instance; this adds no Unity copy or separate database.

Twelve profile sections add five builders, four callbacks, the rename getter/status enum and the
insufficient-funds error branch.
The getter/callbacks/enum execute unchanged with instrumented clock/wallet/dialog/name boundaries.
Four profile groups verify price and exact callback/input contracts; forced Mongo and live HTTP
tests are described in [PROFILE_PUBLICATION.md](PROFILE_PUBLICATION.md). No native UI or gameplay
verification is inferred from these headless source checks.

Seventeen analytics sections add original field/transaction declarations, constructor body, six
builders, five callbacks, the Elite request and the monotonic chat property. Four executable groups
check source flags, all 33 field shapes/aliases, exact metadata and actual planner chat output.
The known schema is shared by direct and buffered writers; see
[ANALYTICS_PUBLICATION.md](ANALYTICS_PUBLICATION.md) for authority and non-gameplay proof boundaries.

Seven tutorial sections add both builders, start/dispatch callbacks, the complete classic method,
its contiguous XP/tutorial excerpt and the wrong-battle error branch. The actual excerpts execute
unchanged against instrumented boundaries, while full classic reward/gameplay execution remains
outside the oracle. Four tutorial groups prove required fields, BSON/state/migration shapes and
identity parsing. See [TUTORIAL_PUBLICATION.md](TUTORIAL_PUBLICATION.md).

The current test executes 1,188 checks across 25 successes and 180 action/failure combinations:

- Complete responses must parse without exceptions or a `StringParser` fallback.
- Removing each mandatory field must fail or trigger the original parser's fallback diagnostic.
- Removing guarded fields must remain callback-safe.
- Delivery countdowns apply only to the last response.
- Delivery/push notification order is preserved.
- Elite/parts/scraps error dialogs relog only after confirmation.
- Missing `SpecialOffers` remains valid because the original callee explicitly accepts null.
- Action/result identities must agree with the server enums; the matrix must equal the allowlist.

An additional 50 scenarios feed real planner/projector output to the same callback. These include
malformed input for every supported action, missing-price/discount/delivery/ownership failures,
changed-wallet replay, owned cosmetic success, and permanent purchase after an expired promotion.

Another 151 scenarios use two small, explicitly synthetic catalog fixtures to execute every one of
the current server's 126 literal action/result dispositions, including all 25 successful actions.
They also distinguish repeated guards such as an absent versus stale delivery, wrong parts versus
wrong currency assertions, absent prices versus unknown pack composition, stock overflow, and
already-owned no-ops. Fixture prices/identities are test inputs, never recovered production policy.
The two JSON files total 20,290 bytes; they are read in place from test output and create no temporary
database, export, or project directory.

Each catalog scenario verifies that planning leaves its input snapshot unchanged and that a failed
action plans no mutation. The committed response is passed to the actual callback once, then again
after changing authoritative wallet, item ownership/state, deliveries, inventory, cards and cosmetics.
Both the wire response and the values decoded by instrumented Client boundaries must match current
authority. The failed outcome and its original receipt stay fixed. Timed successes must carry only
remaining seconds for the same delivery and must omit the countdown for a successor delivery.

The matrix's `serverResults` section is checked against current planner method bodies and tuple
helpers before compilation and in the fast gate. The scanner is a deliberately bounded disposition
inventory, not a C# coverage collector or a proof of all gameplay policy. Six focused guard tests
cover block/expression bodies, helper results, comments/strings, duplicate/missing methods and syntax
that requires manual review. New or changed dispositions require updating reviewed fixtures; merely
adding an expected result to JSON cannot pass because that result must execute with successful
first-delivery and current-authority assertions. General state/catalog validation remains C12/C13;
the complete direct-action builder/caller inventory remains V01.

## Rank authority and displayed unlock requirements

Stored `Level` is a zero-based index in the recovered 43-rank table; `GameLevel.displayNumber`
is `index + 1`. Weapon/unit purchase predicates compare index with `CANBEBOUGHT - 1`, visual
unlock compares index with `UNLOCKLEVEL - 1`, and promotion compares displayed rank with the raw
`UNLOCKTIER` requirement. The server previously compared the index directly with each raw value.
That delayed eligibility by one rank and made a tier requirement of 43 unreachable at valid index 42.

`LegacyRankGate` now owns the shared comparison for all four paths. It validates the rank domain,
rejects negative gate authority, and compares `index + 1` with the required display level. Zero
purchase gates remain open at the first rank; the tier-max sentinel 999 remains closed. Initial
account rank policy and stored/wire rank identity are unchanged.

Thirteen real producer scenarios test immediately below/at purchase and promotion thresholds,
first-rank purchases, and the final tier requirement at index 42. Four malformed rank/gate cases
must fail before selecting eligibility. Reviewed first/middle/final rank and gate combinations are
also compared against the unchanged compiled Client predicates, independently of the server helper.
Catalog identity/sentinel validation and the full durable-state boundary remain C12/C13.

## Upgrade admission and terminal indexes

Another 63 planner/callback scenarios check normal/tier/Elite caps, wrong kinds, active delivery
proofs and helper admission. Weapon maximum is rows minus two; normal-unit maximum is the eligible
current-tier count minus one; Elite maximum is its lane count minus one. Completion must bind an
owned current index to an active normal delivery before charging instant Gold or incrementing.
Negative, terminal, oversized and stale indexes, wrong SlotId, inactive proof and lost ownership
must plan no mutation. Success at the final legal boundary advances once and clears the delivery.
Three real starting-tier-zero helper units are refused as purchases, promotions, activations and
equipped player units. Full durable-state validation remains C13.

## Required response families

| Family | Required fields | Guarded or conditional fields |
| --- | --- | --- |
| Weapon purchase/upgrade/marker failure | `LevelName`, JSON-string `Weapon` | `Gold`, `WarBucks`, JSON-string `weaponDelivery` |
| Unit purchase/upgrade/marker failure | `LevelName`, JSON-string `Unit` | `Gold`, `WarBucks`, JSON-string `unitDelivery` |
| Card-pack failure | JSON-string `CardManagerData`, `Gold`, `WarBucks` | Null-safe `SpecialOffers` for discount failure |
| BuyDecal success | `DecalId`, signed-int `ExpiresOn` | None |
| BuyDecal handled failure | JSON-string `DecalManagerData` | `Gold`, `WarBucks` |
| EquipDecal handled failure | JSON-string `DecalManagerData` | Success optionally reloads the same blob |
| EquipWeapon ownership failure | `LevelName`, JSON-string `Weapon`, JSON-string `InventoryData` | None |
| UpdateEquippedUnits failure | None | JSON-string `data`, whose dictionary values are JSON strings |
| Elite/parts/scraps handled failure | None | Confirmation dialog requests a relog |
| Visual marker, promotion, chat cursor | No dedicated rollback fields | Generic push callback only |

The exact result-code lists are in the JSON review. Generic maintenance/input/JSON/conflict results
do not enter an action-specific rollback branch. For example, the Client has no `PriceNotFound`
branch for BuyDecal. Extra fields on that response cannot force the Client to reload its cosmetic
state. Do not invent a different result merely to trigger an unrelated branch; retain this limitation
until a deliberate compatibility change is reviewed.

## BuyDecal success and historical replay

The original success callback indexes `visuals[DecalId]` and assigns `ExpiresOn` unconditionally.
An already-owned no-op formerly returned only ActionId/Result. It now includes both mandatory fields
and preserves the authoritative current expiry instead of resetting it to zero.

A historical complete, payload-bound receipt with this bare success is projected using the exact
request whose action/payload digest the store verified. The cosmetic must still be owned; a missing
or conflicting identity, missing ownership, or negative expiry is refused. An older unbound receipt
is never upgraded into trusted success. Projection leaves canonical receipt JSON unchanged and uses
current expiry so an old reply does not overwrite a later promotion deadline. New permanent purchases
still commit and return zero expiry, including a prior expired promotion. General cosmetic
policy/state validation remains part of C12/C13.

## Running and maintaining the gate

```powershell
dotnet build Server/WarFriendsServer.sln
python Server/tools/generate_legacy_buffer_oracle.py
dotnet run --project Server/tests/War.LegacyContract.Tests --no-build
```

Both fast checkpoints and `LegacySmoke.ps1` run the oracle. Legacy smoke then reuses its single owned
Mongo replica for storage/HTTP suites; successful disposable data is reclaimed as documented in
[TESTING.md](TESTING.md). Changing reviewed source or dependencies requires inspecting builders,
callback branches, decoding callees and optimistic callers before updating the matrix/hashes.
Do not update the review just to suppress a source mismatch.
