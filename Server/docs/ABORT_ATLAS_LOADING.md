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
without assigning the texture. The completed-bundle gate below now covers this
late path with a retained external lease; the pending-reference gate alone did
not prove it.

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

These pending-reference gates do not alone prove completed native bundle
publication. Bundle failure/retry behavior, every upgrade/card child loader,
full resource cleanup, the complete menu, two Unity peers, Unity 5.2 and Android
remain separate work. Existing account/menu prerequisites remain in ABORT_MENU_DEPENDENCIES.md.

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

## Real native completion and lease conservation

UnityNativeAtlasBundleBuilder builds a 512x512 Texture2D and its real native
manifest in an empty disposable Unity 2018.3 project. It uses an explicit Windows
bundle target and no recovered game scripts. An initial attempt to build the
fixture inside the recovered project hit its existing Windows-player Handheld
compile boundary; no production Vibration or platform code was changed to bypass
that unrelated problem. This is not a Windows game-build proof.

Set WAR_NATIVE_ATLAS_BUNDLE to the builder's CompletedAtlasBundle directory and
run UnityCompletedAtlasAudit.RunAsync in the disposable recovered audit project.
The fixture loads both native files locally, binds the original inactive bundle
manager and invokes its real Update pump. It retains one explicit external
bundle lease, then the original game-atlas loader acquires a second lease and
issues an actual AssetBundleRequest. The request must still be pending when
cancellation is applied.

After native completion, the cancelled scope must keep the restored texture and
pixel-size sentinel unchanged, return a real non-null native texture from the
source operation and leave exactly the external lease. A fresh game scope then
loads and publishes that actual texture normally, sets the source pixel size to
one and again releases exactly its own lease. Finally the original unload method
must remove the last lease row and unload the native AssetBundle object.

UnityCompletedAtlasFixture supplies only test assets and initialized source
lookup/manifest state; it does not replace the source operation, material
publication or unload methods. Manager account Awake remains inactive and the
original Update pump is explicitly driven. This covers local already-loaded
bundles and the shared-lease handoff, not WWW download/cache failures, dependency
bundle graphs, sole-owner acquisition through downloads or full account boot.
No screenshot or original-game artwork fidelity claim follows from this texture
fixture. Linux, Android and source Unity 5.2 remain separate gates.

The empty-project build passed in `Server/.local/unity-native-atlas-build.log`.
The final recovered-project run passed with no C# compiler errors in
`Server/.local/unity-abort-native-bundle-final.log`. It also reran the existing
pending-reference, message startup, queue handoff and two original modal cycles.
This checkpoint changes only verification tools and documentation; the runtime
late-completion guard and unload behavior were already implemented.
