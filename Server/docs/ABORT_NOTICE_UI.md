# Aborted recovery: original cancellation notice

`GuiManager.ShowMainScreen` starts the original screen animation and returns
before `GuiScreen.DoAfterShowUp`. Recovery previously released its connection
owner immediately after that call. It could therefore finish before the menu or
notice had completed their transitions.

The recovery coroutine now retains the owner while waiting for the original
MainScreen AfterShowUp event, or an already fully shown destination. A changed
destination or an inactive completed menu is rejected. The temporary event
subscription is removed when the wait exits. Recovery then shows the original
localized ConfirmDialog and waits for visibility or acknowledgement before
finishing the adapter's retained ownership and releasing the admission guard.

Acknowledgement is a separate completion proof: the original OK callback runs
only after the dialog is fully shown. A user can press OK and begin hiding the
dialog before the recovery coroutine resumes. Waiting only for `isFullyShowed`
would miss that transition and hang; the captured acknowledgement handles it
without repeating an outcome or touching a later match.

## Original widget fixture

`UnityAbortMenuGraphAudit` records the recovered MainScene UI ancestors and
component types. `UnityAbortNoticeFixture` moves the original UIRoot into a
disposable scene and retains its actual ConfirmDialog, labels, buttons, panels,
fonts, atlas references, camera and overlay objects. It does not replace the
dialog with a test implementation or change its serialized appearance.

GuiManager's global Start is disabled so unrelated screens do not initialize
account state. The other screen branches remain inactive. The source game
controller is bound while inactive for the original dialog's GameEnded event;
an inactive debug provider supports the original FPS overlays. The original
English Resources table is parsed with ByteReader and bound without changing
PlayerPrefs. Normal GUI pool initialization and the actual dialog Awake,
OnEnable, tweens and OK delegate still execute. This isolates a real widget;
it does not constitute normal account/menu boot.

## Verified behavior

`UnityAbortNoticeAudit` checks two complete show/acknowledge/hide cycles in Play
Mode. Both translated source labels and the OK-only controls must be active,
the original panel alpha tween must complete, the original button delegate must
acknowledge, and closing must release the NGUI dragging lock. The original
enabled collider and UICamera raycaster must select OK at its projected screen
position; that selected target is passed to the original click delegate. The production
notice wait is exercised before visibility, after visibility and after immediate
acknowledgement. Runtime UI errors fail the audit. Account, Backend and Chat
service components must not become active in the isolated fixture.

`RunRenderedAsync` also uses the original GUI camera with a graphics-enabled
Editor and saves `Server/.local/abort-notice-recovered.png`. The inspected 640x480
capture shows the original INFO / BATTLE CANCELED / OK modal with readable text
and its original panel/button graphics. No raster replacement or image editing
is involved. Undersized and nearly solid captures are rejected; this is an output
sanity check, not automated proof of text or full UI fidelity. The screenshot is
a GUI-camera capture of the modal, not the complete game's
camera stack, phone aspect ratio, physical touch handling or an Android frame.

The whole menu/resource recovery coroutine, its full player/account cache,
message-queue interactions and recovery from arbitrary UI callback failures
remain separate work. In particular, modal rendering does not close the full
MainScreen or two-client release gate. Source Unity 5.2 and Android remain
unverified; the native audit uses a disposable Unity 2018.3 project.

## Native checkpoint

The final graphics-enabled run completed successfully in Unity 2018.3:
`Server/.local/unity-abort-notice-style-final.log`. It exercises both notice-wait
orders, the original collider/raycaster, two modal cycles and the camera capture.
The preceding routing and cancellation audits also passed; they establish entry
ownership and adapter reuse, not full MainScreen initialization. The protocol
executable independently passed 1,334 checks after this change.
