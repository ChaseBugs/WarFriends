using War.Persistence;

namespace War.Backend;

/// <summary>Keeps generated manifest bytes with the exact account revisions used for their projection.</summary>
public sealed record PreparedBattleManifest(byte[] Manifest, IReadOnlyList<BattleAccountRevision> AccountRevisions);
