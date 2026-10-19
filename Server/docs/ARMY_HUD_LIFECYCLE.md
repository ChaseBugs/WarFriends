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

The focused audit does not establish a clean normal match shutdown or terminal/rematch flow.
Those require a new normal two-Unity run after these changes. Android and original Unity 5.2
compatibility remain separate gates.
