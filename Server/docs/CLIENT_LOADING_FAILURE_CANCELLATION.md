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

The scope also captures the exact `SelfHostedMatchmakingAttempt` object. Both
initial dispatch and manual retry compare that identity, so reusing the same
MonoBehaviour for another admission cannot transfer the old failure to its new
queue attempt.

Loading cancellation shares one retry operation per attempt: at most three
requests with 500 ms between temporary failures. The SDK classifies transport
errors, request timeout and HTTP 408/500/502/503/504 as transient; authentication,
validation and protocol refusals do not retry. Before each request the captured
Client, connection and attempt must still own a Waiting/Countdown match.
Terminal recovery, replacement ownership or disposal stops further retries.
Exhaustion is logged and ownership remains blocked. `GameController` offers an
owner-bound `BattleLoadingRetryNotice` while that exact scope and connection
still own a Waiting/Countdown match. It uses the recovered localized confirmation
dialog and `ID_RETRY`, waits for unrelated dialogs, and retries the same bounded
operation on acknowledgement. A stale or superseded dialog callback cannot
retry. Closing an old notice cannot clear or hide another notice's callback;
an interrupted pending notice may resume after that other popup closes.
The failed-loading spinner is hidden when the retry notice actually opens.
Confirmed abort quiesces gameplay/transport before closing the owned retry UI.
Direct trusted-grant
admission has no queue token and does not acquire this automatic cancellation
path.

Remaining proof includes actual queued Unity admission followed by loading
failure, expired tokens through this Unity path, stale-owner isolation under a
replacement admission, full retry presentation integration and Running-first races. Cleanup
failures remain retained by the resource scope; a confirmed server abort does
not prove successful menu recovery after damaged resource disposal.
Execution-only errors now permit confirmed-abort resource cleanup; actual
StopCoroutine/disposal failures still block it. Ordinary cancellation retains
the original failure history and still blocks a fresh load. The controller clears
the old scope only after successful menu/notice handoff and owner release.

This inventory does not establish that the full Client loading or menu path has
been verified.

## Verification

The portable protocol executable links the actual Unity
`SelfHostedMatchmakingAttempt` source. Its 28 lifecycle checks include successful
search completion retaining the HTTP owner, refusal followed by same-token retry,
repeated completion, and terminal local disposal without another cancellation.
The full executable passes 1,346 checks. Additional controls cover shared retry
tasks, temporary HTTP failure recovery, owner replacement, no retry for HTTP
400/401 and the exact three-request exhaustion bound. These controlled replies do not
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

`LiveLoadingCancellationChecks` links the same Unity attempt source into the
native live executable. With real authenticated Backend routes, Worker UDP and
MongoDB it completes two searches, admits both peers, retains the successful
loading owner and calls completion before cancellation. Both open UDP transports
must receive `cancelled-before-start` with no winner or reward eligibility;
accepted manifest-bound terminal evidence must release both pair members.
A second match reaches Running first: the attempt must reject cancellation,
leave the pair without a terminal result and keep UDP usable. Only the test's
separate explicit Forfeit ends that running match.

These checks run inside `--queue-live <replica-set-uri>`. They prove the actual
plain C# attempt lifetime across real services; they do not execute the Unity
MonoBehaviour, resource iterator, UI or two Unity processes together.

The Release build completed with zero warnings/errors. The complete native queue
suite passed against its own MongoDB replica set, including Backend restarts,
delayed registration publication, cancellation races and unattended Worker-outage
recovery. Run log:
`Server/.local/loading-cancellation-live-61f5e56c0b554c0f9c0449d8a9a4281d/queue-live.log`.

The retry extension also passes the native Unity routing audit using the final
installed SDK. In each of the four controller states its controlled HTTP handler
returns 503 once, then accepts the same scoped retry. Duplicate failure polling
cannot start another operation, UDP remains owned, and Ready/replacement maps
remain blocked. The audit also retains the four cleanup-failure controls. Log:
`Server/.local/unity-loading-cancellation-retry-sdk-final.log`. All seven installed
SDK hashes match their manifest. The earlier retry audit exposed a fixture that
left an Aborted snapshot from a stale-callback control; the loading control now
explicitly establishes Waiting, rather than weakening the terminal phase guard.

The original modal audit now passes the localized Retry label, original NGUI
button callback/tweens, duplicate-click rejection, stale-owner rejection,
preservation of an unrelated/replacement popup, and resumption after a temporary
popup closes. Log:
`Server/.local/unity-loading-retry-notice-resume-final.log`.
The routing audit additionally rejects another captured attempt on the same
adapter and retains its four normal/four cleanup-failure recovery controls. Log:
`Server/.local/unity-loading-retry-attempt-owner-final.log`.
Static asset checks still report zero broken references/missing scripts; the
17 existing atlas sprite mismatches remain unchanged. These are separate modal
and routing gates, not one real-service retry-to-menu gameplay session.

## Real Unity and service integration

`--queue-live-unity <mongo-replica-set-uri> <unity-executable> <disposable-project>`
extends the native queue suite with an actual Unity Editor process and an SDK
peer. Both use real authenticated scoped queue/grant routes and enter the same
Worker over UDP. The Unity process uses the recovered controller methods with
controlled local manager initialization; it does not run account boot or
construct a full combat scene.

After both participants are admitted, a Unity-hosted tracked iterator yields
once and throws. The audit requires exactly that engine exception and rejects
other runtime errors. The real scope closes, the original root dispatches its
captured attempt's HTTP cancellation, normal UDP polling receives Aborted, and
the original controller enters suspended, unscored recovery with no pending
loaders. The SDK peer must independently receive the terminal state, and MongoDB
must contain the matching accepted manifest evidence with both pair members
released. Credentials pass through the owned child process environment rather
than command-line arguments or checked-in files.

The audit stops the recovery coroutine after its initial yield and before the
profile-dependent resource/menu path. It therefore proves the combined engine
fault/service/controller-entry boundary, not a full menu recovery, a normal
battle bootstrap, Android, Unity 5.2 or two Unity clients. Existing backend/menu
prerequisites remain recorded in [the dependency inventory](ABORT_MENU_DEPENDENCIES.md).

The real integration passed in
`Server/.local/queue-live-ca33b3c8e3ef49ae914b576a303903cc/UnityLoadingAbort.log`
with the `UNITY_LIVE_LOADING_ABORT_PASSED` marker. The injected engine exception
is intentional; the marker also requires no other runtime errors.

The complete extended queue suite also passed Backend restarts, delayed grant
publication, prestart races and unattended Worker-outage recovery. Suite log:
`Server/.local/unity-loading-abort-live-30e4b80dff84498d8463ca12e703cc98/queue-live-unity.log`.
The Release solution build passed with zero warnings/errors. The owned native
processes and isolated MongoDB were stopped by their fixture cleanup.
