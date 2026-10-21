namespace War.LegacyContract.Tests.Recovered;

internal sealed class CamosManager
{
    public static CamosManager instance { get; } = new();

    public DecalState data { get; } = new();
    public void LoadData(string json) => OracleTrace.Decode(json, "DecalManagerData");

    public PlayerVisual GetVisual(string name) => new();
    public PlayerVisual GetPowerBand(string name) => new();

    internal sealed class DecalState
    {
        public Dictionary<string, VisualState> visuals { get; } = [];
    }

    internal sealed class VisualState
    {
        public int expiresOn { get; set; }
        public bool borrowed { get; set; }
    }
}
