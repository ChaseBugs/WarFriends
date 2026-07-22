public interface AFIKFLMIBBA
{
	SoldierMeshChanger meshChanger { get; }

	string[] playerVisuals { get; set; }

	PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo { get; set; }

	PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet { get; set; }

	PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory { get; set; }

	PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand { get; set; }
}
