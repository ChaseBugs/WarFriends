using System.Collections.Generic;

namespace Google2u
{
	public class InApps : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			afgold1,
			afgold2,
			afgold3,
			afgold4,
			afgold5,
			afgold6,
			warbucks1,
			warbucks2,
			warbucks3,
			warbucks4,
			warbucks5,
			warbucks6,
			valuepackaf,
			afstarterpack,
			moneypack1,
			valuepackafB,
			moneypack1B,
			starterpackB,
			testpack001,
			bgold1,
			bgold2,
			bgold3,
			bgold4,
			bgold5,
			bgold6,
			bwarbucks1,
			bwarbucks2,
			bwarbucks3,
			bwarbucks4,
			bwarbucks5,
			bwarbucks6,
			afgold7daily1,
			bafgold7daily1,
			afgold14daily1,
			bafgold14daily1,
			afgold21daily1,
			bafgold21daily1,
			afgold30daily1,
			bafgold30daily1,
			elitepack1,
			elitepack2,
			elitepack3,
			elitepack4,
			elitepack5,
			elitepack6,
			veteranpack1,
			veteranpack2,
			veteranpack3,
			veteranpack4,
			veteranpack5,
			starterpack2,
			starterpack2B,
			subscription1,
			veteranpack0,
			starterpack3,
			starterpack3B,
			starterpack4,
			starterpack4B,
			elitepack7,
			elitepack8,
			elitepack9,
			elitepack10,
			piggybank1,
			piggybank2,
			piggybank3,
			piggybank4,
			piggybank5,
			elitefinisher1,
			elitefinisher2,
			elitefinisher3,
			elitefinisher4,
			elitefinisher5,
			elitefinisher6,
			specialofferpackgold1,
			specialofferpack1,
			specialofferpack2,
			specialofferpack3,
			customizablepack1,
			customizablepack2,
			customizablepack3,
			customizablepack5,
			customizablepack10,
			customizablepack15,
			customizablepack20,
			customizablepack25,
			customizablepack30,
			customizablepack35,
			customizablepack40,
			customizablepack45,
			customizablepack50,
			customizablepack60,
			customizablepack70,
			customizablepack75,
			customizablepack80,
			customizablepack90,
			customizablepack100,
			valuepackafc,
			customizablepack200
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<InAppsRow> Rows;

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

		public InAppsRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public InAppsRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
