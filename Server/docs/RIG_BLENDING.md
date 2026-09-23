# Local-space rig blending

`RigLocalPose` blends local position/scale linearly and local rotation with shortest-path normalized quaternion interpolation, then composes the parent hierarchy. It uses scale/rotation/translation matrices for world positions and parent/local quaternion multiplication for world orientation. Local transforms and parent indexes are validated; cycles, forward references, missing roots, invalid quaternions, nonpositive scales and invalid weights are rejected. Negative-scale rigs are not supported by this implementation.

`SelfHostedRigBlendExport.Run` exports a minimal connected MainScene gameplay hierarchy containing all weapon muzzle and player hit-part ancestors: 142 transforms. Nine actual Unity Animation samples cover idle-to-uncover, hide-to-idle and left-fire-to-right-uncover, each at weights 0.25, 0.5 and 0.75. Each case records separately sampled source local transforms, Unity's blended local transforms and the resulting world positions/rotations. Tests compare all five quantities (local position/rotation/scale and world position/rotation), rather than asserting that world-space interpolation equals animation blending.

The separate reference artifact is `content/recovered-rig-blend-reference.json`. Set `WAR_RIG_BLEND_OUTPUT` and run the exporter in the disposable Unity project. It restores the scene setup and saves no scene or prefab. The data is regression evidence, not a live selectable weapon catalog.

`SelfHostedPlayerPoseExport` includes ordered `rigNodes` and per-frame `rigLocals` in `recovered-player-poses.json`. `PlayerPoseCatalog` now loads the complete 142-node hierarchy and every local frame. Before publishing the catalog, it reconstructs and compares both collision parts and all eleven muzzles against every exported world-space snapshot. Parent/path mismatches, cycles, truncated frames or disagreement with exported geometry fail loading.

`SampleBlended` samples two host-selected clip frames, blends their local transforms, optionally replaces body/upper-body local rotations, and composes the hierarchy. Collision centers, box sizes and sphere radii are rebuilt from local primitive bindings and composed scales; muzzles come from those same bone matrices. Its `PlayerAimPose` keeps collision/muzzle outputs together for placement and projectile use, with `local-rig-blend` provenance. The Client cannot submit this state as a damage claim.

The nine Unity blend references now use exact exported frame times. Tests verify runtime blended collider centers/rotations and all eleven muzzle positions against the actual Unity blended hierarchy, as well as all local/world transform comparisons. Same-clip blends with procedural overrides also match the independently tested aimed-pose path.

Remaining work: integrate queue/interruption weights and playback clocks into the live animation state, then bind poses to Worker collision and firing. Additive and layered clips, missing-curve behavior across further clip pairs, time scaling and the full set of weapon stances still require coverage. Frame selection currently holds the last exported 30 Hz sample; this is not arbitrary-time curve reconstruction.

Weighted playback checkpoint: `SampleLayers` consumes bounded playback layers directly, with normalized weighted quaternion blending in a common hemisphere. The Unity reference now includes three additional three-clip combinations (12 cases total), and their runtime collider/muzzle results match the server. An isolated playback-to-projectile-to-health test also passes using the recovered AK47 and a blending victim. The live UDP match flow is not yet wired to this composition.

Validation: both Unity exports completed successfully. Battle suite passed 18,135 assertions, including nine rig blend cases and 1,749 per-frame muzzle reconstructions. This is actual Unity Editor sampling, not rendered multiplayer gameplay or Android verification.

Runtime integration checkpoint: regenerated Unity blend export passed; Battle suite passed 18,282 assertions including runtime collider/muzzle parity and corrupt hierarchy rejection. This connects the pose catalog, not the live Worker gameplay flow.

Latest validation: 12-case Unity export passed, solution build zero warnings/errors, Battle suite 20,473 assertions. Earlier counts remain historical checkpoints.
