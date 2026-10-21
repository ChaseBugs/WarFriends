using Newtonsoft.Json.Linq;

namespace War.LegacyContract.Tests.Recovered;

internal sealed class LevelManager
{
    public static LevelManager instance { get; } = new();

    public LevelState data { get; } = new();
    public RecoveredRankGateOracle.DisplayRank currentLevel { get; } = new();
    public void UpdateWeapon(string name, JToken? token)
    {
        OracleTrace.Items["weapon:" + name] = OracleTrace.Decode((string?)token, "Weapon");
    }

    public void UpdateUnit(string name, JToken? token)
    {
        OracleTrace.Items["unit:" + name] = OracleTrace.Decode((string?)token, "Unit");
    }
    public void UpdateWeaponDelivery(JToken token) => OracleTrace.Decode((string?)token, "weaponDelivery");

    public void UpdateUnitDelivery(JToken token) => OracleTrace.Decode((string?)token, "unitDelivery");
    public void SetWeaponDeliveryTime(JToken token)
    {
        OracleTrace.WeaponDeliverySeconds = StringParser.ParseIntToken(token);
        OracleTrace.Calls.Add("weapon-timer");
    }

    public void SetUnitDeliveryTime(JToken token)
    {
        OracleTrace.UnitDeliverySeconds = StringParser.ParseIntToken(token);
        OracleTrace.Calls.Add("unit-timer");
    }
    public WeaponLevelsSetup Weapon(string name) => new();

    internal sealed class LevelState
    {
        public Dictionary<string, BorrowedState> savedArmies { get; } = [];
        public Dictionary<string, BorrowedState> savedWeapons { get; } = [];
    }

    internal sealed class BorrowedState
    {
        public bool borrowed { get; set; }
    }
}
