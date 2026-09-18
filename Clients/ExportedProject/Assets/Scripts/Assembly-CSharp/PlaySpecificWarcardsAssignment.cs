using System;
using System.Collections.Generic;
using System.Globalization;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
internal class PlaySpecificWarcardsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-cards";

	private string cardRarity => Localization.Localize(GameVariables.warcardName[(CardManager.CardType)(int)data[1]]);

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num), cardRarity);
		}
	}

	public PlaySpecificWarcardsAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, float levelProgress, string secondParameter)
		: base(databaseAssignment, levelProgress)
	{
		Debug.Log("Assignment: PlaySpecificWarcards assignment");
		data = Assignment.GetAloneObjectFor(15, 3, databaseAssignment.target);
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
		data[1] = GetCardRarity(rarity);
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
		int num = Convert.ToInt32(data[1]);
		int num2 = 0;
		foreach (Card item in cardUsedByMe)
		{
			if (item.rarityNumber == num)
			{
				num2++;
			}
		}
		Debug.Log($"Used {num2} cards od rarity {num}");
		base.completeFract = CompareIntAndInt(num2, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
