# Recovered battle evidence

`recovered-battle-content.json` is exported from the active WarFriends 1.4.0 recovered Client by `SelfHostedBattleExport.Run`. It contains five multiplayer scenes, world-space covers and navigation paths, collider geometry, reference Physics rays and MainScene Google2u rows. Source scene paths and SHA-256 digests are embedded.

The exporter runs in Unity and does not save scenes. Set `WAR_BATTLE_CONTENT_OUTPUT` to an absolute output filename. Use a disposable project; do not export from scenes with unsaved edits. The current export was produced with Unity 2018.3.0f2, the repaired workspace environment, not the original APK build environment.

The server validates map geometry before use. Source sheet rows are not yet a validated combat catalog and must not authorize purchases or rewards. Serialized shield health is a base value. Movement speed, player health, loadout upgrades and damage coefficients must be bound from their complete source contracts before scored combat is enabled.

Map identity is the source scene filename and digest: several scenes share the serialized `MapDefinition.levelName` value. Do not merge them on that value. Paths retain the source cover indices; they are not freely traversable player coordinates. Static raycasts ignore triggers and inactive/disabled colliders and do not yet simulate destructible-state changes.

Run `dotnet run --project Server/tests/War.Battle.Tests` to validate the five maps and compare 200 exported Physics rays. See [Battle Server status](../docs/BATTLE_SERVER.md) for the remaining implementation work.
