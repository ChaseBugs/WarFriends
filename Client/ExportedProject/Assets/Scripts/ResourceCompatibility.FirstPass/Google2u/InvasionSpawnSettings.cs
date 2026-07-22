using System.Collections.Generic;

namespace Google2u
{
	public class InvasionSpawnSettings : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			DBUpgradeSlotsAssaulter,
			DBUpgradeSlotsShotgunner,
			DBUpgradeSlotsSniper,
			DBUpgradeSlotsMachineGunner,
			DBUpgradeSlotsSwat,
			DBUpgradeSlotsBazooka,
			DBUpgradeSlotsParachuter,
			DBUpgradeSlotsGrennader,
			DBUpgradeSlotsMinigunner,
			DBUpgradeSlotsEngineer,
			DBUpgradeSlotsDrone,
			DBUpgradeSlotsHelicopter,
			DBUpgradeSlotsCar,
			DBUpgradeSlotsTank,
			DBUpgradeSlotsSciFi,
			DBUpgradeSlotsCarBuggy,
			DBUpgradeSlotsAssaultHeli,
			DBUpgradeSlotsTransporter,
			DBUpgradeSlotsFlamethrower,
			DBUpgradeSlotsCommando,
			DBUpgradeSlotsGunslinger,
			DBUpgradeSlotsMortar,
			DBUpgradeSlotsWarper,
			DBUpgradeSlotsMech,
			DBUpgradeSlotsExoMech,
			DBUpgradeSlotsExoPilot,
			DBUpgradeSlotsSilverstrike,
			DBUpgradeSlotsRenegade,
			DBUpgradeSlotsVTOL,
			DBUpgradeSlotsChemical,
			DBUpgradeSlotsCrossbowSniper,
			DBUpgradeSlotsSpiderBot,
			DBUpgradeSlotsBackbone,
			DBUpgradeSlotsHavoc,
			DBUpgradeSlotsInstinct,
			DBUpgradeSlotsBreach,
			DBUpgradeSlotsBunker,
			DBUpgradeSlotsRiko,
			DBUpgradeSlotsSurge,
			DBUpgradeSlotsOverseer,
			DBUpgradeSlotsSpecter
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<InvasionSpawnSettingsRow> Rows;

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

		public InvasionSpawnSettingsRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public InvasionSpawnSettingsRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
