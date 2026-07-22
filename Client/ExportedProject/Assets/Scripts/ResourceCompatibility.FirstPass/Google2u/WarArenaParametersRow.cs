using System;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Google2u
{
	[Serializable]
	public class WarArenaParametersRow : IGoogle2uRow
	{
		public ObscuredFloat FLOATVALUE;

		public string STRINGVALUE;

		public ObscuredFloat Get_FLOATVALUE
		{
			get
			{
				return default(ObscuredFloat);
			}
			set
			{
			}
		}

		public string Get_STRINGVALUE
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Length => 0;

		public string Item => null;

		public WarArenaParametersRow()
		{
		}

		public WarArenaParametersRow(string _NAME, string _FLOATVALUE, string _STRINGVALUE)
		{
		}

		public string GetStringDataByIndex(int index)
		{
			return null;
		}

		public string GetStringData(string colID)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
