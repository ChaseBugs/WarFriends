using System.Collections.Generic;

namespace Google2u
{
	public class ArmyUpgrades : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ID_1,
			ID_2,
			ID_3,
			ID_4,
			ID_5,
			ID_6,
			ID_7,
			ID_8,
			ID_9,
			ID_10,
			ID_11,
			ID_12,
			ID_13,
			ID_14,
			ID_15,
			ID_16,
			ID_17,
			ID_18,
			ID_19,
			ID_20,
			ID_21,
			ID_22,
			ID_23,
			ID_24,
			ID_25,
			ID_26,
			ID_27,
			ID_28,
			ID_29,
			ID_30,
			ID_31,
			ID_32,
			ID_33,
			ID_34,
			ID_35,
			ID_36,
			ID_37,
			ID_38,
			ID_39,
			ID_40,
			ID_41,
			ID_42,
			ID_43,
			ID_44,
			ID_45
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<ArmyUpgradesRow> Rows;

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

		public ArmyUpgradesRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public ArmyUpgradesRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
