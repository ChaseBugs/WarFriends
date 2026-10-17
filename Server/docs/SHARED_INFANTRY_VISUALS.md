# Shared script-free infantry geometry

## Recovered construction rules

`SoldierMeshChanger.SetSoldierStyle` chooses from a local style list, replaces
the body skin, then calls `FakeRigidBodySwapper.SetMesh` for both helmet forms.
The style index is a private local value; this inspection does not establish a
required server appearance field. The new builder accepts an already selected
style and does not change selection policy or choose a default animation.

The source registry contains sixteen combat infantry families and the BUDDY
helper. Buddy overrides `UpdateVisual` and applies saved player camos through
`ChangeCamo`, so its inherited style placeholder is not a generic infantry
appearance. Similarly, Commando's unused card placeholder is not a missing
required visual. The reviewed mission catalog selects seven infantry card
families, which are checked independently from ordinary appearances.

## Shared builder

`SelfHostedVisualHierarchy.CopyRoot` copies transforms and static mesh
renderers/filters. It preserves the root scale, child local poses, visibility,
mesh/material references and renderer enable flags. It never instantiates the
source prefab or copies its gameplay components.

`SelfHostedInfantryVisualFactory.Create` builds an inactive root for an explicit
source `SoldierStyle`. It binds the selected body mesh/materials to the copied
source skeleton, remaps every bone and root bone, restores both helmet forms,
and returns the source animation hierarchy for later explicit clip sampling.
If construction fails, the partial root is destroyed. The caller owns the
successful root and must supply placement/animation before activation.

The existing self-hosted infantry presenter now uses this same factory while
retaining its previous style choice and activation flow. Its canopy paths use
the shared transform/mesh copier. No scene/prefab or serialized identity changes.

One source mismatch is corrected: the previous presenter skipped helmet
replacement when `helmetMesh` was null, leaving the template helmet behind.
The source `SetMesh(null)` clears both meshes and resets to attached-visible,
detached-hidden state. The builder now reproduces that behavior, including the
detached form's reset scale, without adding rigid bodies or the source swapper.

## Verification boundary

`UnityInfantryVisualFactoryAudit.Run` reads the actual MainScene registry and
mission catalog. It checks all sixteen ordinary and seven mission-card styles:
inactive construction, exact source body mesh/materials, remapped bone ownership,
absence of scripts/physics/autonomous animation, and both helmet forms. A
separate no-helmet fixture verifies template meshes are cleared. It also checks
the distinct Buddy route and requires all twenty-three active styles to be
built; an unavailable required style fails rather than selecting a substitute.

Copy the tool into Assets/Editor of the disposable project and copy the reviewed
mission catalog to its root as `coop-visual-mission-catalog.json`. The result is
written as `infantry-visual-factory-audit.json`. The existing
`SelfHostedInfantryRenderAudit.Run` separately checks presenter regression over
sixteen normal families, five special-card visuals, host motion/removal and
post-death/reconnect canopy handling.

This prepares reusable geometry for co-op presentation. It does not yet bind
the common co-op enemy event to actors, implement their source animation state,
render pixels, reconstruct full weapon/upgrade appearance or open Worker co-op
admission. Buddy camos and specialized vehicle/air visuals remain separate.
No local AI or combat authority is re-enabled.

Windows verification: the final factory audit passes 128 assertions over all
23 source-required styles; the source registry still contains 17 families,
with 16 style-driven combat families and the separate Buddy helper. The
existing infantry presenter audit passes all sixteen normal families, five
special-card variants, motion/removal and canopy scenarios. Both native
processes finish shutdown. The protocol executable remains at 1,110 checks;
static asset audits retain zero missing scripts/broken references and the
seventeen known unmatched NGUI selections. Server runtime and SDK binaries are
unchanged, so no new Worker smoke, Linux or Android proof is claimed here.
