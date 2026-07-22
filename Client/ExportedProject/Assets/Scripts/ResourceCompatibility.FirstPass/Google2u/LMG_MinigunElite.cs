using System.Collections.Generic;

namespace Google2u
{
	public class LMG_MinigunElite : Google2uComponentBase, IGoogle2uDB
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
			WARARENA
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<LMG_MinigunEliteRow> Rows;

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

		public LMG_MinigunEliteRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public LMG_MinigunEliteRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
