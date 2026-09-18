public class SoldierProperties
{
	public string[] visuals = new string[4];

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo { get; set; }

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet { get; set; }

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory { get; set; }

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand { get; set; }
}
