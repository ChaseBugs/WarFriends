using System.Collections.Generic;

namespace Google2u
{
	public class Grenade_Doombringer : Google2uComponentBase, IGoogle2uDB
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
			ROW_52,
			ROW_53,
			ROW_54,
			ROW_55,
			ROW_56,
			ROW_57,
			ROW_58,
			ROW_59,
			ROW_60,
			ROW_61,
			ROW_62,
			ROW_63,
			ROW_64,
			ROW_65,
			ROW_66,
			ROW_67,
			ROW_68,
			ROW_69,
			ROW_70,
			ROW_71,
			ROW_72,
			ROW_73,
			ROW_74,
			ROW_75,
			ROW_76,
			ROW_77,
			ROW_78,
			ROW_79,
			ROW_80,
			ROW_81,
			ROW_82,
			ROW_83,
			ROW_84,
			ROW_85,
			ROW_86,
			ROW_87,
			ROW_88,
			ROW_89,
			ROW_90,
			ROW_91,
			ROW_92,
			ROW_93,
			ROW_94,
			ROW_95,
			ROW_96,
			ROW_97,
			ROW_98,
			ROW_99,
			ROW_100,
			WARARENA
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<Grenade_DoombringerRow> Rows;

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

		public Grenade_DoombringerRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public Grenade_DoombringerRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
