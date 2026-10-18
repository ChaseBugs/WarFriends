using System.Text.Json;
using War.BattleServer;

/// <summary>Checks ordinary grenade composition against source rows without card interpolation.</summary>
internal static class OrdinaryGrenadierCompositionTests
{
    private const int LastNormalIndex = 100;
    private const int FirstSpecialIndex = 101;
    private const int LastSpecialIndex = 126;
    private const int FirstEliteIndex = 127;
    private const float DefaultFuseSeconds = 3f;

    internal static int Run(ArmyDeploymentCatalog catalog, string directory)
    {
        using JsonDocument source = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "recovered-battle-content.json")));
        JsonElement rows = source.RootElement.GetProperty("sheets").EnumerateArray()
            .Single(sheet => sheet.GetProperty("type").GetString() == "Google2u.DBUpgradeSlotsGrennader")
            .GetProperty("rows");
        int checks = 0;
        foreach (int normal in new[] { 0, 39, LastNormalIndex })
        {
            checks += CheckSelection(catalog, rows, (normal, null, null));
            checks += CheckSelection(catalog, rows, (normal, FirstSpecialIndex, null));
            checks += CheckSelection(catalog, rows, (normal, LastSpecialIndex, FirstEliteIndex));
        }

        foreach (float scale in new[] { float.NaN, float.PositiveInfinity, 0f, -1f, 101f })
        {
            checks += Reject(() => catalog.ComposeOrdinaryGrenadier(0, null, null, scale));
        }

        checks += Reject(() => catalog.ComposeOrdinaryGrenadier(0, 0, null, 1f));
        checks += Reject(() => catalog.ComposeOrdinaryGrenadier(0, null, FirstSpecialIndex, 1f));
        checks += Reject(() => catalog.ComposeOrdinaryGrenadier(FirstSpecialIndex, null, null, 1f));
        return checks;
    }

    private static int CheckSelection(ArmyDeploymentCatalog catalog, JsonElement rows,
        (int Normal, int? Special, int? Elite) selection)
    {
        (int normal, int? special, int? elite) = selection;
        const float damageScale = 1.5f;
        float minimum = rows[normal].GetProperty("GRENADEMINDAMAGE").GetSingle();
        float explosion = rows[normal].GetProperty("GRENADEEXPLODEDAMAGE").GetSingle();
        float specialValue = rows[normal].GetProperty("SPECIAL").GetSingle();
        foreach (int? index in new[] { special, elite })
        {
            if (!index.HasValue)
            {
                continue;
            }

            minimum += rows[index.Value].GetProperty("GRENADEMINDAMAGE").GetSingle();
            explosion += rows[index.Value].GetProperty("GRENADEEXPLODEDAMAGE").GetSingle();
            specialValue += rows[index.Value].GetProperty("SPECIAL").GetSingle();
        }

        var actual = catalog.ComposeOrdinaryGrenadier(normal, special, elite, damageScale);
        float expectedFuse = special.HasValue
            ? DefaultFuseSeconds - DefaultFuseSeconds * specialValue
            : DefaultFuseSeconds;
        if (actual.Damage.Minimum != minimum * damageScale ||
            actual.Damage.Explosion != explosion * damageScale || actual.FuseSeconds != expectedFuse)
        {
            throw new InvalidOperationException("Ordinary grenade composition differs from recovered lane addition.");
        }

        return 1;
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidDataException or ArgumentOutOfRangeException)
        {
            return 1;
        }

        throw new InvalidOperationException("Invalid ordinary Grenadier authority was accepted.");
    }
}
