using System.Collections.Generic;

namespace Google2u
{
	public class WeaponAugValues : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			ID_0_param1,
			ID_1_param1,
			ID_2_param1,
			ID_3_param1,
			ID_4_param1,
			ID_5_param1,
			ID_5_param2,
			ID_5_duration,
			ID_6_param1,
			ID_6_param2,
			ID_6_duration
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<WeaponAugValuesRow> Rows;

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

		public WeaponAugValuesRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public WeaponAugValuesRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
