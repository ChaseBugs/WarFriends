# Card-pack inventory and wallet publication

`BuyCardPack` previously saved card stock before separately applying the wallet delta. This could
grant without charging after a failure, overspend competing buffers, or overwrite a battle debit
with inventory calculated from an earlier account read.

`LegacyPlayerStore.TryPurchaseCardPackAsync` now writes post-purchase stock, Gold and WarBucks
in one conditional MongoDB update. It compares the exact original card blob, both balances and
player level, including whether the blob was absent. The level participates because source rarity
selection depends on it. The replacement balances cannot create currency or become negative.

When another purchase or battle debit changes those inputs, the rejected plan writes nothing.
The buffer processor reloads the account and recalculates that same claimed request. A newly
unaffordable request returns the existing source-compatible rollback response. An affordable one
can commit against its fresh state. Intermediate reward draws are never published; client reward
assertions still do not select the server's result.

Reward quantities are grouped and checked against Int32 capacity before spending. Invalid durable
counts fail without mutation; an unrepresentable pack uses the existing `CardPackNotFound`
rollback branch. Failed pack receipt replay now includes authoritative card/wallet rollback fields
instead of replaying only the numeric result. Successful receipt replay grants and charges nothing.

The concurrency test exposed the incomplete 45-ID inventory validator. The separate
[complete identity correction](ORDINARY_CARD_IDENTITIES.md) preserves all 67 ordinary definitions
and the Client's 57 eligible pack identities. Source pack contents were not narrowed to match the
current host effect implementation.

## Verification

- Release build: zero warnings/errors.
- Two different buffers holding the same one-pack account snapshot: one purchase, one refusal,
  exactly three cards, and one wallet debit.
- Two affordable competing buffers: both purchases complete with six cards and two debits.
- Successful replay changes nothing; failed replay retains Client-required rollback fields.
- Full Int32 stock refuses an overflowing award without changing stock or the wallet.
- A pack write prepared before an actual host battle debit is rejected afterward.
- Real Mongo single/batch inventory reads and account projection cover all 67 definitions.
- Existing terminal/grant race and atomic card-consumption checks pass.
- `LegacySmoke.ps1` passes 248 HTTP assertions.

The native checks run through `--allocation-inventory-mongo` and `--atomic-terminal-only`.
Transaction artifacts: `.local/pack-battle-cas-2939490a8c694f2f856a0b8e4ac58cc0`.
HTTP artifacts: `.local/legacy-0493a8dfd0d744ecabb40015ae600fa5`.

## Remaining work

The buffer receipt claim/completion and account write are still separate publications. A crash
between the account commit and receipt completion retains the existing unknown-outcome refusal;
this change does not claim transactional crash recovery for buffered purchases. Card deposit and
withdrawal writers still need coordinated updates. Automatic allocation, admission reservations,
Buddy behavior, the remaining active card effects, and normal Unity battle proof remain open.
