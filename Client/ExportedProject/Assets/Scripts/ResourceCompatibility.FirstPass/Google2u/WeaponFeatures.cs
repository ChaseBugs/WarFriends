using System.Collections.Generic;

namespace Google2u
{
	public class WeaponFeatures : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ValueAssaultRifle,
			ValueSMG,
			ValueLMG,
			ValueSniperRifle,
			ValueRocketLauncher,
			ValueShotgun,
			ValueGrenade,
			ValuePistol,
			ValueMinigun,
			ValueGrenadeLauncher,
			ValuePulseRifle,
			DpsCoefAssaultRifle,
			DpsCoefSMG,
			DpsCoefLMG,
			DpsCoefSniperRifle,
			DpsCoefRocketLauncher,
			DpsCoefShotgun,
			DpsCoefGrenade,
			DpsCoefPistol,
			DpsCoefMinigun,
			DpsCoefGrenadeLauncher,
			DpsCoefPulseRifle,
			AttackCoefAssaultRifle,
			AttackCoefSMG,
			AttackCoefLMG,
			AttackCoefSniperRifle,
			AttackCoefRocketLauncher,
			AttackCoefShotgun,
			AttackCoefGrenade,
			AttackCoefPistol,
			AttackCoefMinigun,
			AttackCoefGrenadeLauncher,
			AttackCoefPulseRifle
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<WeaponFeaturesRow> Rows;

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

		public WeaponFeaturesRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public WeaponFeaturesRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
