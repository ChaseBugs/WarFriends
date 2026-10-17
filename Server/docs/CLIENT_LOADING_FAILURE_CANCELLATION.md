# Client loading failure cancellation

Status: loading credential retention and owner-bound failure dispatch implemented;
complete gameplay and failure recovery remain unverified.

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

`BattleResourceLoadScope.FirstFailure` retains setup, execution, start or cleanup
failure for deferred observation. `GameController.StartGame` captures the exact
online controller's admitted Client owner. Its LateUpdate dispatches the first
failure once for that scope, only while the same controller and active Client
still own it. Dispatch happens after the failed iterator unwinds.

`CancelFailedLoadingAsync` sends the retained attempt's cancellation without
closing UDP. Polling can therefore receive the actual terminal snapshot through
the existing owner-bound abort callback. Readiness is blocked after dispatch,
and another map cannot replace the failed scope while its Client still owns the
match. No local exception manufactures a terminal snapshot or reward.

Failed HTTP cancellation is logged and ownership remains blocked. The same
internal cancellation method retains retry capability, but automatic retry and
user-facing retry presentation are not implemented. Direct trusted-grant
admission has no queue token and does not acquire this automatic cancellation
path.

Remaining proof includes actual queued Unity admission followed by loading
failure, expired tokens through this Unity path, stale-owner isolation under a
replacement admission, retry presentation and Running-first races. Cleanup
failures remain retained by the resource scope; a confirmed server abort does
not prove successful menu recovery after damaged resource disposal.

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

The extended routing audit also passes deferred loading-failure dispatch in all
four controller states. It injects a retained admission credential, uses the real
BackendClient with a controlled HTTP handler and checks the exact bearer/token,
one request per scope, different-controller rejection, retained transport,
blocked readiness and blocked replacement maps. It then exercises the existing
confirmed-abort entry. Log:
`Server/.local/unity-loading-failure-dispatch-final.log`. This is not an actual
Backend/Worker cancellation or a complete menu recovery test.

The source-backed resource suite passes first-failure identity checks for setup,
MoveNext/Current and cleanup, plus the existing real texture-bundle, turret,
cross-host visual and cancellation-modal gates. Log:
`Server/.local/unity-loading-failure-scope-final.log`. Managed execution faults
use the actual wrapper under controlled advancement; this does not prove Unity's
complete engine exception dispatch or every resource variant.
