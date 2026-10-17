# Local solo pool commands

The active Client uses NetworkObjectPool.InstantiateNetwork for BotMission's
player, Transporter repair drones, Decoy cards and enemy parachutes. The source
also exposes two ReInstantiateNetwork overloads. Their recovered implementation
sends an Others RPC before applying the same local pool operation. A solo room
has no remote recipient.

## Preserved local behavior

All four commands now select the original local Instantiate/ReInstantiate path
when PhotonConnectionManager.IsLocalSoloRoom is true. The local Instantiate
override consumes the first free slot, as the recovered offline master did,
without querying Photon master identity. Explicit reuse retains the selected
pooled object/index. The existing initialization, activation, pose, free-list
removal and OnInstancied callbacks still run in their original methods.

The guard excludes a retained self-hosted match. It does not turn a client pool
request into authority to create an online combat entity. Online entities still
require committed Worker identity/state and their reviewed projection path.
Legacy non-solo network methods are not replaced by this change.

## Native proof and limits

UnityLocalPoolAudit.Run uses the actual serialized NetworkObjectPool from the
recovered MainScene, with all scene roots inactive and controlled plain pooled
objects. It seeds the local model without an SDK room, leaves the pool's RPC
PhotonView unbound, and invokes all four real commands. It checks the original
first-slot identity, activation, pose/rotation and free-list consumption.

The source baseline fails inside InstantiateNetwork's RPC path in
`Server/.local/unity-solo-pool-scene-baseline.log`. The initial fixture logs
`unity-solo-pool-baseline.log` and `unity-solo-pool-fixed.log` are not evidence of
that behavior: creating a new pool failed because its recovered RequireComponent
names abstract PhotonNetwork. The scene fixture avoids changing that attribute
or inventing a replacement component.
The corrected four-command fixture passes in
`Server/.local/unity-solo-pool-scene-fixed.log`, with no unexpected runtime errors.

This is controlled method-level Play Mode proof, not full pool initialization,
campaign boot or combat rendering. Init still assigns/registers PhotonViews;
AllocateMyNetworkId and other legacy network paths still read SDK identity.
Removing those dependencies and migrating authoritative online pooling remain
open before the SDK can be removed. No scene, prefab or script identity changes
are required for this slice.
