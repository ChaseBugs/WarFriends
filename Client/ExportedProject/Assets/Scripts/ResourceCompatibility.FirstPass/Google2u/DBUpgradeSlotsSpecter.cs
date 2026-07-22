using System.Collections.Generic;

namespace Google2u
{
	public class DBUpgradeSlotsSpecter : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ROW_1,
			ROW_2,
			ROW_3,
			ROW_4,
			ROW_5,
			ROW_6,
			ROW_7,
			ROW_8,
			ROW_9,
			ROW_10,
			ROW_11,
			ROW_12,
			ROW_13,
			ROW_14,
			ROW_15,
			ROW_16,
			ROW_17,
			ROW_18,
			ROW_19,
			ROW_20,
			ROW_21,
			ROW_22,
			ROW_23,
			ROW_24,
			ROW_25,
			ROW_26,
			ROW_27,
			ROW_28,
			ROW_29,
			ROW_30,
			ROW_31,
			ROW_32,
			ROW_33,
			ROW_34,
			ROW_35,
			ROW_36,
			ROW_37,
			ROW_38,
			ROW_39,
			ROW_40,
			ROW_41,
			ROW_42,
			ROW_43,
			ROW_44,
			ROW_45,
			ROW_46,
			ROW_47,
			ROW_48,
			ROW_49,
			ROW_50,
			ROW_51,
			SPECIAL_0,
			SPECIAL_1,
			SPECIAL_2,
			SPECIAL_3,
			SPECIAL_4,
			SPECIAL_5,
			ELITE_0,
			ELITE_1,
			ELITE_2,
			ELITE_3,
			ELITE_4,
			ELITE_5,
			ELITE_6,
			ELITE_7,
			ELITE_8,
			WARARENA,
			INVADER_MIN,
			INVADER_MAX
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<DBUpgradeSlotsSpecterRow> Rows;

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

		public DBUpgradeSlotsSpecterRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public DBUpgradeSlotsSpecterRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
