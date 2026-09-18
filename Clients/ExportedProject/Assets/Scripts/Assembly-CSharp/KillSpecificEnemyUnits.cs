using System;
using System.Collections.Generic;
using System.Globalization;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
internal class KillSpecificEnemyUnits : Assignment
{
	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			Type value = Mission.behavioursDictionary[(string)data[1]].Value1;
			LevelBehaviour behaviour = LevelManager.instance.GetBehaviour(value);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num), behaviour.unitName);
		}
	}

	private bool isVehicle
	{
		get
		{
			if (data == null || data.Length < 2)
			{
				return false;
			}
			string key = Convert.ToString(data[1]);
			if (!Mission.behavioursDictionary.ContainsKey(key))
			{
				return false;
			}
			Type value = Mission.behavioursDictionary[key].Value1;
			return value.IsAssignableFrom(typeof(VehicleBehaviour));
		}
	}

	public override string assignmentPicture => (!isVehicle) ? "menu-assignments-type-kill" : "menu-assignments-type-destroy";

	public override bool hasHint => LevelManager.instance.currentLevel.displayNumber >= LevelManager.instance.warpathUnlockLevel;

	public override string hintText => Localization.Localize("ID_ASSIGNMENTHINTWARPATH");

	public KillSpecificEnemyUnits(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress, string secondParameter = "")
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Kill Specific Enemy Units");
		data = new object[2];
		float playerLevelProgress = LevelManager.instance.GetPlayerLevelProgress();
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 4);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = dbAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken unit = GetUnit(row, playerLevelProgress, secondParameter);
		if (unit != null)
		{
			data[0] = dbAssignment.target * StringParser.ParseIntToken(unit["SPAWNCOUNT"]);
			string text = unit["NAME"].ToObject<string>();
			data[1] = text;
		}
	}

	private JToken GetUnit(TaskDefinitionsRow definition, float playerLevelProgress, string param)
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
		int num = Assignment.InterpolateValue(definition.SECONDTARGETMIN, definition.SECONDTARGETMAX, playerLevelProgress);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			int num2 = StringParser.ParseInt(item.Key);
			if (num2 <= num)
			{
				list.Add(item.Key);
			}
		}
		System.Random random = new System.Random();
		int index = random.Next(0, list.Count - 1);
		return (JToken)dictionary[list[index]];
	}

	public override float Update()
	{
		string unitName = Convert.ToString(data[1]);
		int unitKilledCount = Singleton<ScoreManager>.instance.GetUnitKilledCount(unitName);
		base.completeFract = CompareIntAndInt(unitKilledCount, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
