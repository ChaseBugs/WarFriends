# Army HUD lifecycle repair

## Observed failures and changes

The passing normal pair at `.local/client-boot-5c9559a5c2f9492ebc4e653e18fe89fa` still
records two exceptions after its report. `Crane.OnDestroy` resolves `Singleton<GameController>`
after shutdown has made that getter return null. Army unbinding clears its offers and raises
`ArmyChanged`; the fixed HUD then dereferences that same retired controller in `isActive`.

Crane now unsubscribes from its cached event owner without resolving a replacement singleton.
Both classic and fixed HUD activity checks return false during shutdown and require an existing
controller with an active mode controller before reading spawning type. GUIDs and serialized
fields remain intact.

Separately, `DeathMatchUnitsGuiElement.Update` increments the animation index before indexing
its current offer list, then stops only at index two. An offer-list clear or shrink during an
animation can therefore index outside the list. `ShowNextCard` now uses the smaller of current
offer and card-slot counts, stops before an invalid access and ends after the last available
card. Explicit hiding cancels an outstanding animation. Initial and progress presentation also
respect both list sizes. Ordinary three-card ordering and animation delay remain unchanged.

## Verification boundary

`Server/tools/UnityArmyHudLifecycleAudit.cs` exercises actual recovered HUD components with a
recording card subclass: ordinary three-card progression, repeated completion, offer clearing
and absent card slots. It also checks shutdown activity for both HUD modes and invokes Crane
teardown without singleton lookup. Run only in a disposable Unity project; no assets are saved.

Unity 2018.3.0f2 passed **9 checks** and exited zero at
`.local/army-hud-lifecycle-audit-final.log`. The Crane target is required from the actual
City multiplayer scene, so an empty target set cannot produce a passing teardown check.
The recording card tests animation scheduling rather than full NGUI rendering.

## Normal pair revalidation

`.local/client-boot-4f6bbe8273924dc7b3938bd562a1f17f` passes with terminal exit code zero.
Both normal controllers observe match `m910a75396f8e476682aaa699a875ebb7`, HUD selection,
pending/completed reload and live reconnect. The initiator rebuilds once; its peer retains its
connection. Both report zero exceptions, and both completed Editor logs also contain zero
exception headers, including after report publication. Existing error-level diagnostics remain
142/141. This confirms the previously observed shutdown exceptions did not recur in this run.

`NormalUnityPairSmoke.ps1` now checks completed logs after waiting for each owned Unity process.
A success report cannot hide a later exception. The detector finds both shutdown exception
headers in the previous first-participant log, and finds none in this new pair. PowerShell
syntax validation passes. Logs retain unrelated diagnostics; this gate does not claim clean
rendering from absence of exceptions.

This run uses diagnostic thirty-second admission and prepared sniper input. The harness exits
after reconnect rather than exercising battle results and normal rematch. Terminal card animation,
result screens, rematch, default admission timing, Android and original Unity 5.2 remain separate
acceptance gates. The focused list-clear checks prove bounds handling, not all terminal callbacks.
