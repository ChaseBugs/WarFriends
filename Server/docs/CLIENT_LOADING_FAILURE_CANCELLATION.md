# Client loading failure cancellation

Status: investigated; end-to-end Client wiring is not implemented.

## Existing authority

`SelfHostedBattleClient.MatchmakeAndConnect` always calls
`CompleteMatchmakingAsync` in its finally block. On successful connection,
`SelfHostedMatchmakingAttempt.CompleteAsync` disposes the attempt and the adapter
clears its reference. A later loading failure therefore cannot use
`CancelMatchmaking` to cancel that admitted pair.

The existing scoped cancellation contract is sufficient to identify the pair
without introducing an account-wide cancellation or another protocol message:

- `BattleQueueAttemptTokens.ValidateForCancellation` accepts an expired, correctly
  signed token belonging to the authenticated player. Expiry closes new joins;
  it does not transfer cancellation authority to another attempt.
- `BattleMatchQueueStore.CancelAttemptCoreAsync` checks the pair's attempt
  identity. An old attempt cannot cancel a newer pair. After token expiry,
  cancellation still works against a matching durable pair even if its temporary
  attempt receipt has expired.
- `BattlePairedCancellation` requires the exact frozen manifest and ordered
  participants, and accepts only the Worker's unscored prestart cancellation
  evidence. A Running-first race remains a refusal, not a fabricated abort.

## Remaining implementation boundary

Retain ownership of the successful attempt through loading, while separately
tracking whether the search is still active. Do not make an active battle appear
to be an unfinished queue search. Release the retained owner on definitive
terminal completion or owner shutdown, and retain failed cleanup for retry.

Connect managed loading failures to this exact owner before releasing transport
or attempting menu recovery. Cancellation must await server confirmation;
neither a local exception nor HTTP failure authorizes Forfeit, rewards, or an
Aborted result. Test successful admission followed by loading failure, expired
tokens, old-owner/new-pair isolation, cancellation retry and Running-first races.

This inventory does not establish that the full Client loading or menu path has
been verified.
