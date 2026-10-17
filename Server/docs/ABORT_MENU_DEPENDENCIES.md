# Main-menu recovery dependencies

The active 1.4.0 MainScreen is a player-state view, not an isolated animation.
Showing its original prefab successfully requires the following source paths.
This inventory records prerequisites; it does not declare them implemented.

## Source-owned initialization

- `MainScreen.InitGUIValues` calls golden suitcase, daily reward, deals,
  assignments, social, Google Play appearance, squad and league initialization
  in that order. It also updates menu notifications after player data is loaded.
- `LeftGoldenSuitcase.GetActualState` reads LevelManager unlock/rank state. When
  unlocked, it reads EventTrackingManager video availability and server time.
  A missing provider cannot be replaced with an invented reward-ready state.
- `MainScreen.UpdateDailyrewadButton` reads tutorial state and
  StatsManager.dailyRewardData. LevelManager.isDailyRewardsLocked is always
  false in this client. An absent calendar starts action 1001; merely hiding
  unrelated popup branches does not eliminate this request.
- `IntroductionDeals.InitGuiValues` initializes every serialized deal item.
  Their data and eligibility must be inspected per concrete item, not replaced
  with an empty deals list to obtain a passing menu animation.
- `MainScreenAssignments.InitGuiValues` selects starter versus daily assignment
  data and reads notification counts. Its daily path reads AssignmentData and
  its starter path reads StarterAssignmentsData, completion order and deadline.
- `MainScreenSocial.InitGUIValues` reads current-player provider flags,
  PlayerAnalytics one-time reward history and GameVariables reward constants.
  This view does not by itself authorize live social-provider integration.
- `MainScreen.GPGSLook` reads the current account's Google Play flag even when
  nobody clicks a social button. Local display metadata and live provider
  initialization are different dependencies.
- `IntroductionSquadButton.InitGuiValues` reads player-data readiness, squad
  identity and ServerResultsCache. A missing cache entry for an existing squad
  requests its details; an account outside a squad must retain that identity.
- `MainScreenLeaguePlayers.InitGuiValues` reads player-data readiness, tutorial
  unlocks and beginner/normal league membership. Depending on the branch it also
  uses FakePlayersManager, ServerResultsCache, LeagueArc and league-ending views.

## Current Backend boundary

`War.Backend/Legacy/LegacyEndpoints.GetPlayerData` currently emits Time,
PlayerData, Skill, MedalsBalance and PlacementMatchesRequired, plus present
league identities. It does not emit dailyRewardData. No CheckDailyReward action
handler exists in that dispatch switch at this checkpoint. Serialized-key support
for AssignmentData or StarterAssignmentsData alone is not evidence of a complete
validated lifecycle or of populated client managers.

These are Backend/profile prerequisites for a full menu integration run. The
BattleServer must preserve their recovered contracts and cannot synthesize
calendar rewards, assignments, league placement or account state just to make a
recovery test pass. Backend gameplay implementation remains separate work.

## Synchronous offer entry

GuiScreen.DoAfterShowUp starts MessageManager before its AfterShowUp callbacks.
MessageManager.StartMessageCoroutine originally called OfferManager.CheckOffer
before creating the cancellable message loop. With canCheckOffer enabled, an
expired offer and an eligible last-check time, that method accesses
EventTrackingManager.fuseboxxService. A guard inside the message iterator is too
late to prevent this synchronous dependency.

Abort recovery now skips that legacy offer check while retaining normal message
routine startup and cancellation. It does not fabricate an offer result or
consume the last-check timestamp. Normal non-recovery offer behavior is unchanged;
this targeted change does not prove complete retirement of Fuse across boot,
video rewards, deal widgets or other source callers.

## Remaining full-graph gate

Normal transitions still need a separate offline-service audit:
`GameController.LoadAndStartNewMap` calls `Chat.Disconnect`, and ordinary `Free`
later calls `Chat.Connect`. The abort release reason skips the latter call only.
The existing Chat component constructs a Photon ChatClient in Awake and its
Update services that client and may reconnect from menu state. Disconnect alone
does not prove that this background component cannot reach Photon. The controlled
loading-abort fixture omits normal account boot, so its real HTTP/UDP result does
not verify this normal-transition chat boundary or full retirement of Photon.

Use a real initialized profile and original manager initialization/callback order
for the full MainScreen run, then execute the entire abort resource coroutine.
Preserve serialized widget references, loaded inventory and actual asset pools.
Prove menu transition, retained message handling, cancellation notice and fresh
match admission together. Existing modal, dispatcher and entry-point probes
provide component evidence only. Unity 5.2, Android, Linux deployment and two real
Unity clients still require their own applicable verification.
