using System;
using UnityEngine;

namespace Google2u
{
	[Serializable]
	public class CratesRow : IGoogle2uRow
	{
		public float PROBABILITY;

		public float PROBABILITYARENA;

		public float Get_PROBABILITY
		{
			get
			{
				return PROBABILITY;
			}
			set
			{
				PROBABILITY = value;
			}
		}

		public float Get_PROBABILITYARENA
		{
			get
			{
				return PROBABILITYARENA;
			}
			set
			{
				PROBABILITYARENA = value;
			}
		}

		public int Length
		{
			get
			{
				return 2;
			}
		}

		public string this[int i]
		{
			get
			{
				return GetStringDataByIndex(i);
			}
		}

		public CratesRow()
		{
		}

		public CratesRow(string _NAME, string _PROBABILITY, string _PROBABILITYARENA)
		{
			float result;
			if (float.TryParse(_PROBABILITY, out result))
			{
				PROBABILITY = result;
			}
			else
			{
				Debug.LogError("Failed To Convert PROBABILITY string: " + _PROBABILITY + " to float");
			}
			float result2;
			if (float.TryParse(_PROBABILITYARENA, out result2))
			{
				PROBABILITYARENA = result2;
			}
			else
			{
				Debug.LogError("Failed To Convert PROBABILITYARENA string: " + _PROBABILITYARENA + " to float");
			}
		}

		public string GetStringDataByIndex(int index)
		{
			string result = string.Empty;
			switch (index)
			{
			case 0:
				result = PROBABILITY.ToString();
				break;
			case 1:
				result = PROBABILITYARENA.ToString();
				break;
			}
			return result;
		}

		public string GetStringData(string colID)
		{
			string result = string.Empty;
			switch (colID)
			{
			case "PROBABILITY":
				result = PROBABILITY.ToString();
				break;
			case "PROBABILITYARENA":
				result = PROBABILITYARENA.ToString();
				break;
			}
			return result;
		}

		public override string ToString()
		{
			string empty = string.Empty;
			empty = empty + "{PROBABILITY : " + PROBABILITY + "} ";
			return empty + "{PROBABILITYARENA : " + PROBABILITYARENA + "} ";
		}
	}
}
