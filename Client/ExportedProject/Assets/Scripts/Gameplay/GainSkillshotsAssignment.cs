using System;
using System.Collections.Generic;
using System.Globalization;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class GainSkillshotsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-skillshot";

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ), base.mData[1]);
		}
	}

	public override bool hasHint => true;

	public override string hintText
	{
		get
		{
			if (base.mData == null)
			{
				return string.Empty;
			}
			SkillShot.SkillShotType key = (SkillShot.SkillShotType)Convert.ToInt32(base.mData[2]);
			return Localization.Localize(GameVariables.CNGEGEHJPKF[key]);
		}
	}

	public GainSkillshotsAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, float levelProgress, string secondParameter)
		: base(databaseAssignment, levelProgress)
	{
		base.mData = Assignment.GetAloneObjectFor(10, 3, databaseAssignment.target);
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 10);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = databaseAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken skillShot = GetSkillShot(row, secondParameter);
		SkillShot.SkillShotType skillshot = Singleton<SkillShotManager>.instance.GetSkillshot(skillShot["NAME"].ToObject<string>());
		base.mData[0] = Convert.ToInt32(base.mData[0]) * skillShot["COUNT"].ToObject<int>();
		base.mData[1] = Singleton<SkillShotManager>.instance.GetSkillshotDefinition(skillshot).menuName;
		base.mData[2] = (int)skillshot;
	}

	private JToken GetSkillShot(TaskDefinitionsRow definition, string param)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(definition.SECONDTARGETPARAMETER);
		if (!string.IsNullOrEmpty(param))
		{
			dictionary.TryGetValue(param, out var value);
			if (value == null)
			{
				using (Dictionary<string, object>.Enumerator enumerator = dictionary.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, object> current = enumerator.Current;
						value = current;
					}
				}
			}
			return (JToken)value;
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
		SkillShot.SkillShotType key = (SkillShot.SkillShotType)Convert.ToInt32(base.mData[2]);
		int gained = 0;
		if (Singleton<ScoreManager>.instance.OONJGPCEJMJ.ContainsKey(key))
		{
			gained = Singleton<ScoreManager>.instance.OONJGPCEJMJ[key];
		}
		else
		{
			Debug.LogError("Assignment error: Skillshots not defined");
		}
		base.mCompleteFract = CompareIntAndInt(gained, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
