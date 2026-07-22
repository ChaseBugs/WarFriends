using System.Collections.Generic;

namespace Google2u
{
	public class AugmentationConstants : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			maxLevel_0,
			maxLevel_1,
			maxLevel_2,
			maxLevel_3,
			maxLimitOfAugGUI,
			maxLimitOfAugServer,
			slot4UnlockLevel,
			slot5UnlockLevel,
			winBattleAugPoints,
			loseBattleAugPoints,
			cooldownAugCrateHours,
			fusionCoef,
			xpValueMultiplier,
			weaponAugsMaxLevel,
			weaponMaterialsToXP,
			weaponAugFuseCoef,
			weaponAugDismantleCoef,
			materialDismantlePrice,
			weaponAugXPValueMultiplier,
			dismantleWeaponCooldown,
			maxLevelTrigger_0,
			maxLevelTrigger_1,
			maxLevelTrigger_2,
			maxLevelTrigger_3
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<AugmentationConstantsRow> Rows;

		public override bool haveDictionary => false;

		public override int getColumnCount => 0;

		public override int GetRowIndex(string rowID)
		{
			return 0;
		}

		public override void AddRowGeneric(List<string> input)
		{
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			return 0;
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			return 0;
		}

		public override void CheckRows(List<string> rowIds)
		{
		}

		public override void Clear()
		{
		}

		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			return null;
		}

		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			return null;
		}

		public AugmentationConstantsRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public AugmentationConstantsRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
