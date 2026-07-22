using System.Collections.Generic;

namespace Google2u
{
	public class PiggyBank : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			T1,
			T2,
			T3,
			T4,
			T5
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<PiggyBankRow> Rows;

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

		public PiggyBankRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public PiggyBankRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
