namespace War.BattleServer;

/// <summary>
/// Four stage-zero weapons selected by BotManager.PrepareBotForMission.
/// This owns ammunition only; a validated host projectile must confirm a shot.
/// </summary>
internal sealed class CoopBossArsenal
{
    private sealed class SlotState
    {
        public WeaponManifest Definition { get; }
        public bool Reloadable { get; }
        public int Clip;
        public int Reserve;
        public ulong ReloadEndTick;
        public ulong NextFireTick;

        public SlotState(WeaponManifest definition, bool reloadable)
        {
            Definition = definition;
            Reloadable = reloadable;
            Clip = definition.ClipSize;
            Reserve = definition.ReserveAmmo;
        }
    }

    private readonly SlotState[] slots;
    public ulong CurrentTick { get; private set; }

    public CoopBossArsenal(CoopBossLoadout loadout,
        BattleCombatContent content, ulong startTick)
    {
        ArgumentNullException.ThrowIfNull(loadout);
        ArgumentNullException.ThrowIfNull(content);
        if (loadout.Slots.Count != 4)
            throw new InvalidDataException("Boss arsenal needs four source slots.");

        slots = new SlotState[4];
        for (int index = 0; index < slots.Length; index++)
        {
            CoopBossWeaponSlot selected = loadout.Slots[index];
            WeaponManifest weapon = ManifestFor(selected, content);
            bool reloadable = index != (int)CoopBossWeaponSlotKind.Explosive;
            if (weapon.SourceId != selected.SheetName ||
                weapon.ClipSize <= 0 || weapon.ReserveAmmo < 0 ||
                !double.IsFinite(weapon.ReloadSeconds) ||
                weapon.ReloadSeconds <= 0)
                throw new InvalidDataException("Boss weapon stage zero is invalid.");
            slots[index] = new SlotState(weapon, reloadable);
        }
        CurrentTick = startTick;
    }

    public WeaponManifest Definition(CoopBossWeaponSlotKind slot) =>
        State(slot).Definition;

    public CoopBossWeaponReadiness Readiness(
        CoopBossWeaponSlotKind slot, ulong tick)
    {
        Advance(tick);
        SlotState weapon = State(slot);
        if (weapon.Reloadable && weapon.Clip == 0 && weapon.Reserve > 0 &&
            weapon.ReloadEndTick == 0)
            StartReload(weapon, tick);

        bool reloading = weapon.ReloadEndTick != 0;
        bool outOfAmmo = weapon.Reloadable
            ? weapon.Clip == 0 && weapon.Reserve == 0
            : weapon.Clip == 0;
        bool willShoot = weapon.Clip > 0 && !reloading;
        int ammoLeft = weapon.Reloadable ? weapon.Reserve : weapon.Clip;
        return new CoopBossWeaponReadiness(
            outOfAmmo, reloading, willShoot, ammoLeft);
    }

    /// <summary>Call only after the host has created a real source weapon shot.</summary>
    public bool ConfirmShot(CoopBossWeaponSlotKind slot, ulong tick)
    {
        CoopBossWeaponReadiness readiness = Readiness(slot, tick);
        SlotState weapon = State(slot);
        if (!readiness.WillShoot || tick < weapon.NextFireTick)
            return false;
        weapon.Clip--;
        ulong cadence = checked((ulong)Math.Ceiling(
            weapon.Definition.CadenceSeconds * MatchManifest.TickRate));
        weapon.NextFireTick = checked(tick + Math.Max(1UL, cadence));
        if (weapon.Reloadable && weapon.Clip == 0 && weapon.Reserve > 0)
            StartReload(weapon, tick);
        return true;
    }

    public void Advance(ulong nextTick)
    {
        if (nextTick < CurrentTick)
            throw new InvalidOperationException("Boss arsenal tick moved backward.");
        foreach (SlotState weapon in slots)
        {
            if (weapon.ReloadEndTick == 0 || nextTick < weapon.ReloadEndTick)
                continue;
            int missing = weapon.Definition.ClipSize - weapon.Clip;
            int transfer = Math.Min(missing, weapon.Reserve);
            weapon.Clip += transfer;
            if (weapon.Reserve != int.MaxValue)
                weapon.Reserve -= transfer;
            weapon.ReloadEndTick = 0;
        }
        CurrentTick = nextTick;
    }

    private static WeaponManifest ManifestFor(CoopBossWeaponSlot slot,
        BattleCombatContent content) => slot.SourceCategory.Trim() switch
    {
        "AssaultRifle" => content.Stats.CreateManifest(slot.SheetName, 0),
        "SniperRifle" => (content.Snipers ?? throw Missing("sniper"))
            .CreateManifest(slot.SheetName, 0),
        "Shotgun" => (content.Shotguns ?? throw Missing("shotgun"))
            .CreateManifest(slot.SheetName, 0),
        "RocketLauncher" => (content.Bazookas ?? throw Missing("bazooka"))
            .CreateManifest(slot.SheetName, 0),
        "Grenade" => (content.Grenades ?? throw Missing("grenade"))
            .CreateManifest(slot.SheetName, 0),
        "Pistol" => (content.Pistols ?? throw Missing("pistol"))
            .CreateManifest(slot.SheetName, 0),
        _ => throw new InvalidDataException("Unsupported boss weapon category.")
    };

    private static InvalidDataException Missing(string family) =>
        new($"Boss {family} content is unavailable.");

    private SlotState State(CoopBossWeaponSlotKind slot)
    {
        if ((int)slot is < 0 or > 3)
            throw new ArgumentOutOfRangeException(nameof(slot));
        return slots[(int)slot];
    }

    private static void StartReload(SlotState weapon, ulong tick)
    {
        ulong duration = checked((ulong)Math.Ceiling(
            weapon.Definition.ReloadSeconds * MatchManifest.TickRate));
        weapon.ReloadEndTick = checked(tick + Math.Max(1UL, duration));
    }
}
