using System;
using System.Collections.Generic;
using System.Globalization;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class DeployUnitsFromCategoryAssignment : Assignment
{
	private static Dictionary<string, LevelBehaviour.UnitType> mStringToType = new Dictionary<string, LevelBehaviour.UnitType>
	{
		{
			"Defenders",
			LevelBehaviour.UnitType.Defender
		},
		{
			"Explosives",
			LevelBehaviour.UnitType.AttackerExplosive
		},
		{
			"Shooters",
			LevelBehaviour.UnitType.AttackerShooter
		},
		{
			"Rushers",
			LevelBehaviour.UnitType.AttackerRusher
		}
	};

	public override string assignmentPicture => "menu-assignments-type-deploy";

	private string unitCategory => Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)base.mData[1]].Value1);

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ), unitCategory);
		}
	}

	public DeployUnitsFromCategoryAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, float levelProgress, string secondParameter)
		: base(databaseAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(13, 3, databaseAssignment.target);
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 13);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = databaseAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken category = GetCategory(row, secondParameter);
		if (category != null)
		{
			string name = category["NAME"].ToObject<string>();
			base.mData[1] = (int)GetTypeFromString(name);
		}
	}

	private LevelBehaviour.UnitType GetTypeFromString(string name)
	{
		return (!mStringToType.ContainsKey(name)) ? LevelBehaviour.UnitType.AttackerExplosive : mStringToType[name];
	}

	private JToken GetCategory(TaskDefinitionsRow definition, string param)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(definition.SECONDTARGETPARAMETER);
		if (dictionary == null)
		{
			return null;
		}
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
		LevelBehaviour.UnitType key = (LevelBehaviour.UnitType)Convert.ToInt32(base.mData[1]);
		int gained = StatsManager.instance.matchStats.unitsSpawnedByType[key];
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
