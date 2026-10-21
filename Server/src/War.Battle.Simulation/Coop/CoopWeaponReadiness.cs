namespace War.BattleServer;

public sealed record CoopWeaponReadiness(
    int Slot, int Clip, int Reserve, ulong ReloadEndTick,
    ulong NextFireTick, ulong ShotsFired);
