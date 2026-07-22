using System.Collections.Generic;

namespace Google2u
{
	public class Packs : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			starterpack,
			valuepackaf,
			moneypack1,
			lapsed_player_1,
			lapsed_player_2,
			lapsed_player_3,
			valuepackafB,
			moneypack1B,
			starterpackB,
			testpack001,
			elitepack1,
			elitepack2,
			elitepack3,
			elitepack4,
			elitepack5,
			elitepack6,
			custompack1,
			veteranpack1,
			veteranpack2,
			veteranpack3,
			veteranpack4,
			veteranpack5,
			starterpack2,
			starterpack2B,
			veteranpack0,
			starterpack3,
			starterpack3B,
			starterpack4,
			starterpack4B,
			elitepack7,
			elitepack8,
			elitepack9,
			elitepack10,
			specialofferpackgold1,
			specialofferpack1,
			specialofferpack2,
			specialofferpack3,
			valuepackafc,
			transfer1,
			transfer2
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<PacksRow> Rows;

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

		public PacksRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public PacksRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
