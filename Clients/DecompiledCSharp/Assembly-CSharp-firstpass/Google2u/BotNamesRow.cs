using System;

namespace Google2u;

[Serializable]
public class BotNamesRow : IGoogle2uRow
{
	public string NAME;

	public string Get_NAME
	{
		get
		{
			return NAME;
		}
		set
		{
			NAME = value;
		}
	}

	public int Length => 1;

	public string this[int i] => GetStringDataByIndex(i);

	public BotNamesRow()
	{
	}

	public BotNamesRow(string _ID, string _NAME)
	{
		NAME = _NAME.Trim();
	}

	public string GetStringDataByIndex(int index)
	{
		string result = string.Empty;
		if (index == 0)
		{
			result = NAME.ToString();
		}
		return result;
	}

	public string GetStringData(string colID)
	{
		string result = string.Empty;
		switch (colID)
		{
		case "NAME":
			result = NAME.ToString();
			break;
		}
		return result;
	}

	public override string ToString()
	{
		string empty = string.Empty;
		return empty + "{NAME : " + NAME.ToString() + "} ";
	}
}
