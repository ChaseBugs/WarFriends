# Aborted game-atlas loading

## Source ownership

GameController.LoadAndStartNewMap awaits AtlasPreparer.ClearMenuLoadGameCoroutine
on the AtlasPreparer component. That method starts LoadGameCoroutine on the same
component, which starts individual LoadTextureForAtlasCoroutine iterators. Root
GameController.StopAllCoroutines does not cancel independently hosted children.
A pending bundle wait can therefore survive the original abort entry and later
publish a game texture after menu restoration.

The native baseline exercised that actual loader with a missing bundle reference,
stopped root coroutines, then made the bundle-reference provider unavailable.
The old child continued into AssetBundleManager.GetReference and threw; see
`Server/.local/unity-abort-atlas-baseline-wait.log`. The deliberately unavailable
provider exposes continued execution. It is not a reproduction of ordinary
production provider corruption or of a completed texture overwriting a menu.

## Explicit game-load scope

AtlasPreparer now captures an object identity when LoadGameCoroutine starts.
GameController's confirmed abort entry replaces that identity before resource
release. Game loaders check their captured identity before resource loads,
through missing/cold bundle waits, before starting native asset loading and
before publishing its returned texture. A cancelled loader exits without using
the next phase's providers or changing the menu atlas. A later game loader takes
the new identity and is not permanently disabled by an earlier abort.

The public unscoped texture loader remains available to menu/common loading.
Cancellation does not call StopAllCoroutines on AtlasPreparer or AssetBundleManager.
An already issued native asset operation is allowed to finish. If its game scope
is then stale, it releases the acquired bundle using the original unload path
without assigning the texture. That late-completion/refcount path still needs a
real completed-bundle test; the pending-reference gate does not prove it.

## Native evidence and limits

AbortAtlasPreparerProbe overrides only unrelated startup Awake. The actual
LoadGameCoroutine and its child texture loader run on that component in Play
Mode, using a recovered atlas and the original inactive AssetBundleManager's
reference lookup. No network request or fake asset-loader implementation is used.
The fixture temporarily replaces only the in-memory reference dictionary and
provider bindings and restores them afterwards in the disposable project.

UnityAbortAtlasLoadingAudit starts two successive pending scopes. Each must stay
pending before cancellation and finish after cancellation without reading the
now unavailable lookup. Runtime exceptions fail the enclosing modal audit.
UnityAbortRecoveryRoutingAudit also requires the actual confirmed-abort entry to
replace the scope for all four source GameState values.

These are cancellation/ownership gates. They do not prove completed native bundle
publication, bundle failure/retry behavior, every upgrade/card child loader,
full resource cleanup, the complete menu, two Unity peers, Unity 5.2 or Android.
Existing account/menu prerequisites remain in ABORT_MENU_DEPENDENCIES.md.

## Verified checkpoint

Both native gates passed in the disposable Unity 2018.3 project:
`Server/.local/UnityAbortNoticeAudit.RunRenderedAsync-atlas-scope.log` and
`Server/.local/UnityAbortRecoveryRoutingAudit.RunAsync-atlas-scope.log`.
The first includes actual pending atlas cancellation, original notice rendering,
message startup and dialog/queue handoff. The second stops before resource/menu
work and proves confirmed-abort scope invalidation plus the existing ownership
and reuse guards. Protocol regression checks passed 1,334 cases; the asset audit
retained zero missing scripts and zero broken references. No active scene,
prefab, serialized GUID or asset identity changed.
