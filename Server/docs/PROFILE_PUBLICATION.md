# Legacy profile publication

This increment implements the active 1.4.0 profile builders/callbacks without modifying Client code,
scenes or assets. It closes stale-session and unconditional-write paths for these five mutations.
It does not establish complete progression validation, moderation policy or per-intent replay.

## Contracts and ownership

| Action | Canonical request | Success callback | Publication |
| --- | --- | --- | --- |
| 29 SetPlayerStatus | PlayerStatus: exact 0, 1 or 2 | Time is mandatory unless IsOffline is present | Status and non-regressing LastAction together |
| 13 UpdateDeviceToken | DeviceToken and Locale | No response fields | Complete opaque token/locale tuple plus LastAction |
| 150 ChangeLanguage | Locale | No response fields | Exact validated locale |
| 196 ChangePlayerCountry | NewCountryCode | No case in the recovered response switch | Validated two-letter country, existing uppercase behavior |
| 139 ChangePlayerName | Name and PayForRename: exact 0 or 1 | Success: Name/RenameCount/PayForRename; insufficient funds: RenameCount/PlayerGold | Name/count/server-priced Gold debit together |

`War.Backend/Legacy/Profile` owns form parsing, canonical/diagnostic field agreement and result
projection. `War.Persistence/Legacy/Profile` owns immutable changes, reusable field checks, source
price arithmetic and Mongo publication. The large legacy router now delegates these actions.
The old general TryUpdate API had no remaining callers and was removed.

Every canonical field must occur exactly once. Duplicate values are ambiguous even when equal.
Diagnostic Status, CountryCode/Country and PlayerName may accompany their relevant canonical field
only with exactly equal raw text. An alias never supplies an absent canonical field. Agreement is
checked before country uppercase conversion, so an alias cannot select a different identity.

Locale uses the existing locale validator. DeviceToken retains the account-registration opaque
string rules and 4,096-character limit, including preservation of leading/trailing spaces and valid
UTF-16 pairs. Empty/control-bearing/malformed tokens are refused. Rename retains the existing
15-character server name policy, rejects malformed UTF-16 and preserves accepted name bytes without
trimming. This name policy does not replace the separate provider-display-name contract.

Malformed heartbeat requests retain Success plus Time for the unchanged Client callback, but perform
no write. Invalid other forms return WrongPlayerData without refreshing LastAction or Revision.
Settings remains owned by the complete six-Boolean Preferences path; all profile writers also
validate a present stored Settings snapshot before publication.

## Concurrency and authority

The four non-economic replacements read the current document, validate its root/session/profile
authority and publish a field-specific update with Revision and SessionHash predicates plus a live
session deadline. At most eight compare-and-set attempts are allowed. A same-session revision
conflict rebases against the new document; session replacement or expiry refuses the request.
Independent locale/country changes therefore survive each other, and device registration never
publishes half its tuple. Unrelated serialized blobs and exact Int64 metadata are not rewritten.

One validated application time owns status/device publication. LastAction is the larger of that
request time and the current valid client-width counter, because a newer heartbeat may commit while
an earlier request waits. This is not a complete future-timestamp audit or a protocol ordering proof.
The source supplies no durable sequence number for two delayed status changes.

Status and LastAction now join the mandatory exact BSON integer fields: twenty root numeric fields
require explicit Int32/Int64 presence, with fifteen client-Int32 widths. Shared root reads reject
Status outside 0-2 and negative LastAction. Strings, doubles, null and missing fields cannot silently
become presence counters. Historical missing/corrupt records require reviewed migration.

Rename freezes SecondRenameGoldCost from the immutable catalog when routes are composed. The first
rename is free; paid renames require a source price, explicit payment consent, a nonnegative wallet
and a checked Client-Int32 price. The formula doubles the base for each subsequent rename. The
Backend compatibility pricing helper delegates to this single arithmetic owner.

Rename does not rebase a stale price/count. It reads current authority, requires the authenticated
Revision, then commits Name, RenameCount, Gold and Revision in one FindOneAndUpdate with current
session/expiry, count and affordability predicates. The response comes from the committed document.
Two concurrent free or paid requests can therefore publish only one count/debit from that revision.
A single-document atomic write needs no extra transaction or replica process. Database refusal
leaves the old document intact; no receipt is consumed by these direct actions.

The recovered ServerErrorHandler also indexes RenameCount and PlayerGold on
NotEnoughGoldForChangeName. The previous bare Result response could throw before wallet recovery.
True insufficient funds now include both authoritative fields. A stale revision is WrongPlayerData,
not a fabricated funds error; its source handler requests a fresh login without reading rollback
fields. A failed compare-and-set re-reads authority to distinguish session revocation/expiry as
InvalidToken. No failure is projected through the successful-name callback.

## Replay and remaining work

The recovered builders send no operation nonce or expected rename count. A paid rename replay after
later successful operations cannot be distinguished from a new intent. Full profile replacements
can likewise be delayed past later user choices. Do not describe these compare-and-set protections
as per-intent idempotency; C03 requires a deliberately reviewed Client/server identity contract.
Do not lower password derivation work or add a retired online service to solve that boundary.

Profile mutation checks do not prove the whole account schema. Missing nonnumeric fields can still
select preexisting model defaults on other read paths; complete schema migrations, all subsystem
semantics and shared successor validation remain C13. Tutorial and analytics now have dedicated
boundaries. Generic TryUpdate, Update and SetSerialized APIs were removed; trusted fixture-only
card changes now use LegacyTestAccounts.SetCardsForTestAsync in the test assembly. No unconditional
generic account/blob writer remains exposed by LegacyPlayerStore. Other successor semantics remain open.

## Verification

Twelve reviewed profile sections brought the inventory to 47 while preserving the prior 35 hashes.
The later analytics/tutorial increments bring the current total to 71.
The unchanged rename getter and four callbacks execute in the existing small headless executable;
their clock, wallet, dialog and player-name boundaries are instrumented substitutes. The original
status enum is compiled too. Five builders are hash-reviewed. The country callback's absence is
checked explicitly, so a later source case requires a contract review. This is not Unity gameplay.
The unchanged insufficient-funds error branch also executes with instrumented wallet/dialog boundaries;
tests remove each mandatory field to prove its direct read and verify authoritative wallet recovery.

Four pure groups cover immutable inputs, source prices, mandatory callback keys and malformed stored
profiles. Ten real-Mongo groups force same-revision reads before writes, independent field races,
newer metadata/presence, session rotation/expiry, free/paid rename races, price/consent/funds refusal,
damaged profile/Settings refusal and server-rejected writes. They reuse the owned smoke replica and
trusted credential-free fixtures. Actual authentication tests elsewhere retain the real KDF.

Thirty-seven HTTP assertions cover canonical fields, diagnostic agreement, duplicates, callback-safe
malformed heartbeats, exact padded device tokens, atomic locale tuples, free/paid rename callbacks,
ignored client price assertions, insufficient-funds rollback keys and metadata conservation.
Root HTTP checks expand to 122 with the
new BSON presence cases. Run identifiers and integrated results are recorded in TESTING.md.
