namespace War.Backend;

/// <summary>Server-selected gameplay mode and durable zero-based rank used for ownership evaluation.</summary>
public sealed record WeaponOwnershipContext(int RankIndex, bool IsTutorial);
