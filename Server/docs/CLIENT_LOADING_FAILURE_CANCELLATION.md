# Client loading failure cancellation

Status: loading credential retention implemented; automatic failure dispatch is not implemented.

## Existing authority

`SelfHostedBattleClient.MatchmakeAndConnect` retains the successful attempt after
connection. Its finally block completes the search without disposing that loading
owner. `IsMatchmaking` is false while the admitted match retains the credential;
the existing owned connection still blocks another admission.

`CancelMatchmaking` now waits for the server acknowledgement before closing an
admitted loading connection. HTTP failure or Running-first refusal retains the
connection and the same attempt for retry. Normal close of a Running, Ended or
Aborted match disposes the retained credential without issuing prestart
cancellation. Shutdown of a waiting match still attempts scoped cancellation.

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

Connect managed loading failures to this exact owner before releasing transport
or attempting menu recovery. Cancellation must await server confirmation;
neither a local exception nor HTTP failure authorizes Forfeit, rewards, or an
Aborted result. Test successful admission followed by loading failure, expired
tokens, old-owner/new-pair isolation, cancellation retry and Running-first races.

This inventory does not establish that the full Client loading or menu path has
been verified.

## Verification

The portable protocol executable links the actual Unity
`SelfHostedMatchmakingAttempt` source. Its 22 lifecycle checks include successful
search completion retaining the HTTP owner, refusal followed by same-token retry,
repeated completion, and terminal local disposal without another cancellation.
The full executable passes 1,340 checks. These controlled HTTP replies do not
prove an actual two-Unity-client loading failure or server cancellation race.

The disposable Unity 2018.3 validation project compiled both changed Client
sources and passed `UnityAbortRecoveryRoutingAudit.RunAsync` (four normal states
and four injected cleanup failures). Log:
`Server/.local/unity-loading-attempt-retention.log`. This existing fixture checks
abort ownership regressions, not the newly retained HTTP owner on a real queued
Unity admission. Unity 5.2, Android and complete gameplay remain unverified.
