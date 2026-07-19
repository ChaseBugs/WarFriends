using System;
using System.Collections.Generic;
using System.Globalization;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class KillEnemiesUsingSpecificWeaponAssignment : Assignment
{
	public override string assignmentPicture
	{
		get
		{
			return "menu-assignments-type-kill";
		}
	}

	private string weaponCategoryName
	{
		get
		{
			return Singleton<GameVariables>.instance.GetWeaponCategory((WeaponCategory)base.mData[1], JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
		}
	}

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ), weaponCategoryName);
		}
	}

	public override bool hasHint
	{
		get
		{
			return LevelManager.instance.currentLevel.displayNumber >= LevelManager.instance.dailyMissionUnlockLevel;
		}
	}

	public override string hintText
	{
		get
		{
			return Localization.Localize("ID_ASSIGNMENTHINTWARPATH");
		}
	}

	public KillEnemiesUsingSpecificWeaponAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, float levelProgress, string secondParameter)
		: base(databaseAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(16, 3, databaseAssignment.target);
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 16);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = databaseAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken weaponCategory = GetWeaponCategory(row, secondParameter);
		if (weaponCategory != null)
		{
			string value = weaponCategory["NAME"].ToObject<string>();
			WeaponCategory weaponCategory2 = (WeaponCategory)Enum.Parse(typeof(WeaponCategory), value);
			base.mData[1] = (int)weaponCategory2;
		}
	}

	private JToken GetWeaponCategory(TaskDefinitionsRow definition, string param)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(definition.SECONDTARGETPARAMETER);
		if (!string.IsNullOrEmpty(param))
		{
			return (JToken)dictionary[param];
		}
		List<string> list = new List<string>();
		if (dictionary == null)
		{
			return null;
		}
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
		WeaponCategory key = (WeaponCategory)Convert.ToInt32(base.mData[1]);
		int gained = StatsManager.instance.matchStats.weaponTypeKills[key];
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
