namespace War.BattleServer;

/// <summary>Owns one signed slot's magazine, reserve and reload/fire deadlines.</summary>
internal sealed class PvpWeaponSlotState
{
    private const float AmmoBoxFraction = 0.25f;

    internal PvpWeaponSlotState(WeaponSlotManifest definition)
    {
        Definition = definition;
        Clip = definition.Weapon.ClipSize;
        Reserve = definition.Weapon.ReserveAmmo;
    }

    internal WeaponSlotManifest Definition { get; }
    internal int Clip { get; private set; }
    internal int Reserve { get; private set; }
    internal ulong ReloadEnd { get; private set; }
    internal ulong NextFire { get; private set; }

    internal bool CanReload => ReloadEnd == 0 && Reserve != 0 && Clip != Definition.Weapon.ClipSize;

    internal void BeginReload(ulong tick)
    {
        ReloadEnd = tick + Ticks(Definition.Weapon.ReloadSeconds);
    }

    internal bool CompleteReload(ulong tick)
    {
        if (ReloadEnd == 0 || tick < ReloadEnd)
        {
            return false;
        }
        int transfer = Math.Min(Definition.Weapon.ClipSize - Clip, Reserve);
        Clip += transfer;
        // Pistol.ammoLeft is int.MaxValue with an empty setter. Keep that reserve unchanged.
        if (Reserve != int.MaxValue)
        {
            Reserve -= transfer;
        }
        ReloadEnd = 0;
        return true;
    }

    internal void ConsumeRound()
    {
        // Keep this separate from fire scheduling: accepted-shot effects occur between them.
        Clip--;
    }

    internal void ScheduleNextFire(ulong tick)
    {
        NextFire = tick + Ticks(Definition.Weapon.CadenceSeconds);
    }

    internal void CancelReload()
    {
        ReloadEnd = 0;
    }

    internal void EmptyMagazine(ulong tick)
    {
        // CardEmptyMag invokes the clip setter (which cancels reload), then Weapon.Reload.
        Clip = 0;
        CancelReload();
        if (Reserve > 0)
        {
            BeginReload(tick);
        }
    }

    internal bool TryPlanAmmoBoxGrant(out int amount)
    {
        amount = 0;
        int startingAmmo = Definition.Weapon.ReserveAmmo;
        double sourceGrant = Math.Ceiling((float)startingAmmo * AmmoBoxFraction);
        if (startingAmmo < 0 || Reserve < 0 || !double.IsFinite(sourceGrant) ||
            sourceGrant > int.MaxValue || sourceGrant > int.MaxValue - Reserve)
        {
            return false;
        }
        // Source CardAmmoBox: ceil(startingAmmmoCount * AmmoBoxCoef), not current reserve * coefficient.
        amount = (int)sourceGrant;
        return true;
    }

    internal void AddPlannedReserve(int amount)
    {
        // The caller validates every affected slot before committing its card/effect authority.
        Reserve += amount;
    }

    internal void ApplyAmmoTheftLoss(AmmoThiefTransfer transfer)
    {
        Reserve -= transfer.ReserveTaken;
        if (transfer.ClipAccessed)
        {
            Clip -= transfer.ClipTaken;
            // Merely accessing the recovered clip setter cancels reload, even for a zero clip debit.
            CancelReload();
        }
    }

    internal void ApplyCappedAmmoGrant(int amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount);
        int maximum = Definition.Weapon.ReserveAmmo;
        if (Reserve >= maximum)
        {
            // CardAmmoBox can legitimately exceed the starting amount. A later capped grant
            // must not consume that reserve; the immutable Pistol sentinel also stays unchanged.
            return;
        }
        // Widen before adding so an otherwise valid grant saturates at the cap without overflowing.
        Reserve = (int)Math.Min(maximum, (long)Reserve + amount);
    }

    internal void ApplyPlannedBonusReserve(int reserve)
    {
        Reserve = reserve;
    }

    private static ulong Ticks(double seconds)
    {
        return checked((ulong)Math.Ceiling(seconds * MatchManifest.TickRate));
    }
}
