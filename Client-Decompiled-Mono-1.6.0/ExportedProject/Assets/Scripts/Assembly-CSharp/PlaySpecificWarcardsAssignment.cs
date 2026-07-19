using System;
using System.Collections.Generic;
using System.Globalization;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class PlaySpecificWarcardsAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-cards";
		}
	}

	private string cardRarity
	{
		get
		{
			return Localization.Localize(GameVariables.HPMPBIEHOGH[(CardManager.CardType)base.mData[1]]);
		}
	}

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ), cardRarity);
		}
	}

	public PlaySpecificWarcardsAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, float levelProgress, string secondParameter)
		: base(databaseAssignment, levelProgress)
	{
		Debug.Log("Assignment: PlaySpecificWarcards assignment");
		base.mData = Assignment.GetAloneObjectFor(15, 3, databaseAssignment.target);
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 15);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = databaseAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken jToken = GetCardRarity(row, secondParameter);
		string rarity = jToken["NAME"].ToObject<string>();
		base.mData[1] = GetCardRarity(rarity);
	}

	private int GetCardRarity(string rarity)
	{
		switch (rarity)
		{
		case "Gold":
			return 3;
		case "Silver":
			return 2;
		case "Bronze":
			return 1;
		default:
			return 1;
		}
	}

	private JToken GetCardRarity(TaskDefinitionsRow definition, string param)
	{
		Debug.Log("Assignment Second parameter" + definition.SECONDTARGETPARAMETER);
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(definition.SECONDTARGETPARAMETER);
		if (!string.IsNullOrEmpty(param))
		{
			return (JToken)dictionary[param];
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			list.Add(item.Key);
		}
		System.Random random = new System.Random();
		int index = random.Next(0, dictionary.Count - 1);
		return (JToken)dictionary[list[index]];
	}

	public override float Update()
	{
		List<Card> cardUsedByMe = CardManager.instance.cardUsedByMe;
		int num = Convert.ToInt32(base.mData[1]);
		int num2 = 0;
		foreach (Card item in cardUsedByMe)
		{
			if (item.rarityNumber == num)
			{
				num2++;
			}
		}
		Debug.Log(string.Format("Used {0} cards od rarity {1}", num2, num));
		base.mCompleteFract = CompareIntAndInt(num2, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
