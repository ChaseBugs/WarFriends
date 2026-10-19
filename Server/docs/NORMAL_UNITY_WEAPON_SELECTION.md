# Normal Unity HUD weapon selection

The recovered `InventoryItem.OnClick` checks the local player's weapon-input flag, icon visibility,
selection, ammunition and enabled state before assigning `WeaponInventory.currentWeapon`. The
self-hosted path must translate that request into the matching slot from the authoritative roster.
The host reply owns the selection; `SelfHostedDeathMatchBridge.Apply` maps the returned slot to the
local inventory index and updates weapon/ammunition presentation through `PlayerController`.

## Retained connection boundary

The setter previously searched the scene for a connected `SelfHostedBattleClient`. During reconnect
the adapter intentionally reports `IsConnected = false`, so the setter could instead execute its
recovered local mutation and Photon RPC. It now uses
`PhotonConnectionManager.GetOwnedSelfHostedClient`, which retains ownership during replacement.
An owned session always consumes the self-hosted branch, including when the request must be
ignored. Selection requests require a connected non-reconnecting owner and the current local
player's exact inventory. Remote inventories and unavailable/replaced connections cannot request
a local player's switch or fall through to Photon. Existing fields, GUIDs and source selection
locks remain unchanged. `ApplySelfHostedSelection` remains the host-driven presentation path.

## Normal two-Unity gate

`UnityNormalWeaponSelectionAudit` extends the existing
[normal entry and reconnect gate](NORMAL_UNITY_RECONNECT.md). After both controllers start:

1. The first participant resolves the actual alternate starter weapon and its visible HUD item.
2. It invokes that item's recovered `OnClick` callback using Unity `SendMessage`. It does not
   call the SDK weapon-switch command or assign authoritative state directly.
3. Both peers must observe the bound player/slot in the host snapshot, matching inventory index,
   active weapon object and ammunition. The initiating HUD must display its selected border.
4. Match-bound markers make both peers acknowledge selection before reconnect begins.
5. While the real reconnect request is pending, assigning the original weapon must leave the
   selected local inventory unchanged. The selection lock must be clear for this assertion.
6. Both peers must continue observing the selected host slot and presentation after reconnect,
   alongside the existing snapshot-rebuild and ninety-resumed-tick requirements.

This covers a real recovered HUD callback, transport command, host reply and two-peer presentation.
It does not synthesize an operating-system mouse/touch event or prove UI hit-testing. One alternate
starter weapon does not establish all weapon types, firing, reloading, effects, damage or results.
The admission window remains the separate thirty-second diagnostic override; original Unity 5.2,
Android, denied-external-network operation and the ten-second fixture are not proven by this gate.

The helper records bounded observations and failure types in `normalBattle.weaponSelection`.
Implementation is not acceptance evidence; record the terminal run result before marking this
checkpoint passed.

## Verified checkpoint

`.local/client-boot-5f3ef3401bb846e98c5ee1cdda591327` exited zero with both normal participants in
match `mb53e154ce9244a7c815a7f057c22df45`. The initiator reports an actual recovered HUD callback,
observed inventory index/slot 1 and a successful reconnect-time selection-block check. The peer
reports the same observed index/slot without initiating a click or reconnect. Neither reports a
weapon-selection or reconnect failure. Both retain host Running after the replacement, and the
initiator records exactly one snapshot rebuild, tick 674 before replacement, restored tick 689
and completion of the ninety-tick resumed progress condition. Both have zero exceptions, with
142/143 existing error-level diagnostics. This remains one alternate starter weapon, not full
combat or clean rendering acceptance.

The strengthened initial-selection precondition was synchronized into the first disposable
project after its account boot exited and before its paired launch. The second paired launch
copied the same current helper. Both paired logs have no C# compiler errors. The Release build
has zero warnings/errors. Both package manifest SHA-256 values remain
`7212bb6d4ae5db21b4fe5d10a4a0666d1f2c63618d8277b692254dd1c2c815a3`.
Reports are `Unity-first-battle.json` and `Unity-second-battle.json` under that run directory.
