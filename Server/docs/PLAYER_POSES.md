# Initialized player animation poses

`PlayerPoseCatalog` contains 61 ordered source clips, 1,065 initialized collider snapshots sampled at 30 Hz, 6,390 Unity `Collider.Raycast` comparisons, and 11,715 weapon muzzle samples (eleven per frame). The added families include minigun and sniper cover/run/idle sets plus bazooka uncover/shoot/run/idle clips. `SelfHostedPlayerPoseExport.Run` exports the MainScene gameplay rig only. The preview rig remains excluded.

## Initialization and recovered aliases

`PlayerController.InitPlayer` disables ragdoll colliders, then enables the colliders on both `DestroyableObjectpart` components. The exporter reproduces those collider changes without invoking account, camera or weapon-inventory singletons. It resets through `T_pose` before sampling each frame to prevent a partial clip from inheriting the preceding sample's bone transforms.

The attached MainScene animation clips use `idle_1` and `run_0`, while `SoldierAnimationController` requests `idle` and `run`. Its initialization now adds a canonical alias only when the canonical clip is absent and exactly one attached numeric-suffixed candidate exists. Existing bindings are retained; ambiguous candidates are not guessed. No clip asset or scene is renamed or saved. The same helper is used in the exporter and covered by the Unity audit.

Unity 2018 creates runtime clip instances for `Animation.AddClip` aliases. Export provenance therefore captures the attached asset before aliasing and records its original name, asset path, GUID, file ID and SHA-256 separately from the runtime animation name.

## Server representation

`content/recovered-player-poses.json` contains `T_pose`, `idle`, `run`, `rifle_shot_loop`, the six left/right look/fire/coverBack clips for each of the default, QBZ, QBZ2 and shotgun-style rifle families, plus the three additional family-specific run clips. Samples retain root transforms, ordered body-part identities, sizes, centers, rotations, weights and initialized active/enabled flags. The exact source MainScene hash must agree with the caller's expected hash before loading.

The importer requires all 61 clips in source order, complete ordered frame timelines, valid clip identities, bounded finite geometry, normalized rotations, and the same two enabled body parts throughout. Accepted frames are immutable. A placed frame retains the `initialized-single-clip-samples` provenance instead of becoming a serialized-reference pose.

The full artifact SHA-256 is exposed as `Revision`, separately from MainScene provenance, for future match-content binding. Animation samples cannot change a part's base damage weight. Neither revision nor source provenance makes this catalog a complete animation state machine.

`Sample(name, seconds, loop)` accepts a bounded server-owned clock and explicit playback policy. It holds the last 30 Hz sample inside a tick; it does not interpolate world-space colliders and claim that this reproduces Unity bone interpolation. Endpoint holding and looping are explicit and tested. The runtime state machine must select clips and playback times; the Client cannot submit collider transforms.

## Rifle muzzle sampling

Each frame includes the exact eleven assault-rifle identities, inventory-resolved muzzle hierarchy paths, world positions and rotations. The importer rejects missing/duplicate/unknown identities, changes of hierarchy between frames and invalid transforms. Supplying `RifleBindingCatalog` additionally requires every path and scene digest to match the weapon binding. `SampleMuzzle` uses the same frame selection as the collider sample. The shot factory separately adds the source Gun's world-space shot offset; that offset must not rotate with the player root.

`RifleMuzzlePose.Place` applies a rigid root relocation. The exporter also moves the actual Unity player root to `(3,0,4)` at 90 degrees yaw, captures all muzzle positions and restores the root without saving. Tests compare all 5,390 relocated positions to those independent Unity hierarchy results within 0.0001 world units. Procedural bone overrides have separate [aimed-pose composition](PLAYER_AIM.md) and Unity comparisons. The rifle mode composes its source cover cross-fades and samples run clips along server cover paths; walking-fire integration and move transition blends remain incomplete.

The `shootAdditive` clip uses legacy `Blend` mode over the `upperBody` hierarchy. `SampleWalkingShot` applies that mask to each of the four rifle run families. A Unity Editor reference export covers 20 run/weight cases, and `WalkingShotTests` compares 520 collider and muzzle position/rotation values. Live walking fire now uses this sampled pose and its own masked protobuf field; full move transitions and normal game-controller ownership remain open.

## Remaining integration

This catalog supplies initialized animated geometry, but normal network firing is still not connected to player damage. The source animation controller also uses cross-fades, additive upper-body clips, procedural aiming rotation, reverse cover transitions and weapon-specific animation behavior. Those are not implemented merely by importing single-clip samples. The projectile scheduler and rifle preparation exist as tested kernels; live stance/aim selection, fraction masks, host shot randomness and reliable impact presentation still need integration.

The exporter samples a disposable Unity project and saves no scene/prefab. Run it with an absolute `WAR_PLAYER_POSE_OUTPUT` and `-executeMethod SelfHostedPlayerPoseExport.Run`. The source-derived regression suite compares all 954 animated collider rays and rejects malformed times, mismatched provenance and truncated timelines. This is not a rendered two-client or Android combat certification.

Validation on 2026-09-19: 1,822 Battle assertions passed in the final run (polling can vary the total), including all 954 animated collider rays. The actual Unity Mono adapter/alias audit passed. All 12 Unity scenes opened with zero missing scripts and their core reference checks passed. The solution build, 1,017 protocol checks and 44 native Mongo/HTTP/UDP checks passed. Existing unmatched NGUI sprite selections remain outside this change.

Muzzle extension validation: Unity batch export exited successfully; solution build passed with zero warnings/errors; Battle suite passed 5,612 assertions, including all muzzle-frame and relocated-position comparisons. The earlier adapter/scene/Android boundaries are unchanged; this pass is not a new Play Mode or Android verification.

Aimed hierarchy extension: Unity export completed successfully; solution build had zero warnings/errors; Battle suite passed 9,837 assertions and protocol suite passed 1,017. The additional comparisons cover positions and rotations of both hit parts and all eleven muzzles at every sampled frame after combined body/upper overrides. Nonuniform parent scales and changed bone identities are rejected. This is still Editor hierarchy validation, not complete battle gameplay.
