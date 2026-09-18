# Unity client compilation verification

**Latest asset status:** [OBB_RECOVERY.md](OBB_RECOVERY.md) records the subsequent
APK+OBB field restoration and passing static asset-reference checks. The compile
and startup successes below predate that restoration. Current Unity validation
is blocked by the owner's concurrent library updates; it has not passed again.

On 2026-09-18, Unity 2018.3.0f2 completed batch compilation with exit code 0
and zero C# compiler errors. See `unity-2018.3-compile.log`.

The validation project at `E:/Temp/WarFriends-compile` uses an Assets junction
to this repository's `Clients/ExportedProject/Assets` and a separate Library
cache, with copied project settings. Both Assembly-CSharp-firstpass.dll and
Assembly-CSharp.dll were generated. The original open editor was not closed.

Compiler warnings remain. This verifies editor compilation, not Android build,
Play Mode, gameplay correctness, scene completeness, or live service access.
The APK originally used Unity 5.2; the verified recovery target is the installed
Unity 2018.3 editor used for the reported errors.

Matching dependency DLLs were extracted from the APK. No substitute dependency
download was necessary. Superseded partial dependencies and unreferenced exported
Unity framework copies are retained under `Clients/QuarantinedRecoveredSources`.

Startup null-reference verification (2026-09-18): `startup-readiness.log`
records Unity 2018.3 compilation and `StartupReadinessAudit.Run`, exit 0.
The audit opens SplashScene and MainScene, checks missing scripts, and directly
invokes the affected update methods on MainScene components in Edit Mode:
InputController, War Arena, Co-op, Deathmatch (including the online base update),
SessionManager, VipManager, BeanstalkServerManager, and WeaponPreviewCamera.
All eight checks and the absent ConfirmDialog lookup pass without exceptions.

Input and server-clock helpers now exist before Awake. Session, message polling,
VIP expiry, and online/reconnect updates defer until their required state exists.
GUI lookup returns null when the exported root/dialog is absent; preview rotation
waits for its target. The preview target was still unassigned in the incomplete
export at the time of that check. The later OBB restoration has now restored
the original preview target binding. Full Play Mode,
loaded-player transitions, and weapon-preview rendering remain unverified.
The audit also caught edit-mode tk2d mesh cleanup using Destroy; it now uses
DestroyImmediate outside Play Mode for its generated meshes.
