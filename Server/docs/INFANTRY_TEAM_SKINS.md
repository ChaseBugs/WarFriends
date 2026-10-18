# Ordinary infantry team skins and upgrade attachments

The PvP bridge now supplies the admitted local player identity and the recovered scene's
`MatCapTextures.GetMatCap()` result to the infantry presenter. For ordinary actors, the presenter
uses the owning player's frozen upgrade tuple to call the source family's `GetVisuals` selector.
The later [card-skin integration](CARD_INFANTRY_SKINS.md) supplies fixed card lanes through the same
material helper; the ordinary matrix described here does not itself prove those card cases.

## Recovered behavior

`SoldierMeshChanger.SetSoldierVisual` hides the player powerband, assigns the first body material's
blue or red texture, and applies the selected body attachments. It then updates both helmet forms
and their attachments. Opponent attachments prefer `partRed` when available, otherwise `part`.
Missing attachment slots are ignored, and a repeated slot replaces its earlier selection.
`ModelAttachments.AttachObject` resets local position/rotation/scale, applies the slot object's
layer and enables root light probes. Attachment materials remain source-owned shared materials.

`SelfHostedInfantrySkinAppearance` follows those rules without copying recovered scripts or physics.
Only body/helmet first materials are cloned. Their textures use the exact source loading paths,
and a missing nonempty resource path fails construction instead of selecting invented artwork.
Roster removal and failed construction release the cloned materials; source assets remain intact.
The presenter creates one skin selection per actor rather than allocating materials every frame.

The visual factory now retains its original source-to-copy Transform map. Socket lookup uses that
map because adding a weapon or attachment legitimately changes child counts and invalidates a
strict pre-mutation hierarchy walk. The animation subtree is not assumed to be the whole rig.

## Verification boundary

Disposable Unity 2018.3.0f2 verification passes:

- 1,223 assertions over 128 source actors: sixteen combat families, normal/Elite lanes, local/opponent
  perspectives and upgrade indexes zero and 39. Checks cover body and both helmet textures, MatCap,
  source attachments/reset poses, hidden powerbands, script-free copies, unchanged source material
  values and disposal of cloned materials.
- Seventeen production owner/presenter checks, including body texture selection from each admitted
  owner's upgrades and material release when the roster removes those actors.
- Existing sixteen-family infantry regression, 197 factory assertions over 23 styles, and the
  Gunslinger weapon/holster audit. Its source-hash fixture is refreshed after the shared changes.
- Static asset checks retain zero missing scripts and zero broken references. The seventeen known
  unmatched NGUI sprite selections are unchanged.

The matrix does not enumerate every upgrade threshold or render a normal two-client battle.
Full active Client compilation/Play Mode, runtime shader/pixel parity, original Unity 5.2.5,
Android and Linux runtime remain unverified here. Card weapons/shields, Buddy camos, other infantry weapon
model lanes and complete normal battle presentation remain separate work. No server combat or
protocol authority changed in this checkpoint. See the [feature checklist](BATTLE_SERVER_FEATURES.md).
