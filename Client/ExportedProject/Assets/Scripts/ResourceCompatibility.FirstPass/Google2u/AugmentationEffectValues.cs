using System.Collections.Generic;

namespace Google2u
{
	public class AugmentationEffectValues : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ID_25_param1,
			ID_25_duration,
			ID_18_param1,
			ID_31_param1,
			ID_22_param1,
			ID_33_param1,
			ID_23_param1,
			ID_14_param1,
			ID_34_param1,
			ID_24_AssaultRifle,
			ID_24_SMG,
			ID_24_LMG,
			ID_24_Minigun,
			ID_24_duration_AssaultRifle,
			ID_24_duration_SMG,
			ID_24_duration_LMG,
			ID_24_duration_Minigun,
			ID_35_SniperRifle,
			ID_35_Shotgun,
			ID_35_PulseRifle,
			ID_35_duration_SniperRifle,
			ID_35_duration_Shotgun,
			ID_35_duration_PulseRifle,
			ID_5_duration,
			ID_7_duration,
			ID_9_duration,
			ID_11_duration,
			ID_4_param1,
			ID_6_param1,
			ID_8_param1,
			ID_10_param1,
			ID_4_duration,
			ID_6_duration,
			ID_8_duration,
			ID_10_duration,
			ID_29_param1,
			ID_30_param1,
			ID_28_param1,
			ID_29_duration,
			ID_30_duration,
			ID_28_duration,
			ID_1_param1,
			ID_2_param1,
			ID_0_param1,
			ID_1_duration,
			ID_2_duration,
			ID_0_duration,
			ID_37_param1,
			ID_37_duration,
			ID_17_duration,
			ID_36_param1,
			ID_36_duration,
			ID_3_param1,
			ID_3_duration,
			ID_27_param1,
			ID_27_duration,
			ID_21_param1,
			ID_32_param1,
			ID_13_param1,
			ID_19_AssaultRifle,
			ID_19_SMG,
			ID_19_LMG,
			ID_19_Minigun,
			ID_26_SniperRifle,
			ID_26_Shotgun,
			ID_26_PulseRifle,
			ID_12_Grenade,
			ID_12_RocketLauncher,
			ID_12_GrenadeLauncher,
			ID_20_param1,
			ID_16_param1,
			ID_15_param1,
			ID_15_duration,
			ID_38_duration,
			ID_39_duration,
			ID_40_duration,
			ID_41_param1,
			ID_41_duration
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<AugmentationEffectValuesRow> Rows;

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

		public AugmentationEffectValuesRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public AugmentationEffectValuesRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
