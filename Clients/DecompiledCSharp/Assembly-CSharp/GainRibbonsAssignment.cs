using System;
using System.Collections.Generic;
using System.Globalization;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Skip]
internal class GainRibbonsAssignment : Assignment
{
	public override string assignmentPicture => "menu-assignments-type-ribbon";

	protected override string basicDescription
	{
		get
		{
			int num = Convert.ToInt32(data[0]);
			return Localization.LocalizeFormat(base.translationId, MiscTools.FormatAssignmentNumber(num), data[1]);
		}
	}

	public override bool hasHint => true;

	public override string hintText
	{
		get
		{
			if (data == null)
			{
				return string.Empty;
			}
			RibbonManager.RibbonItemDefinition ribbonItemDefinition = Singleton<RibbonManager>.instance.ribbons[Convert.ToInt32(data[2])];
			return Localization.LocalizeFormat("ID_RIBBONHINT", Colours.stringBlue, ribbonItemDefinition.amountOfSkillshots, GameVariables.skillshotNames[ribbonItemDefinition.skillShotType].Value1, Colours.stringWhite, GameVariables.skillshotNames[ribbonItemDefinition.skillShotType].Value2, GameVariables.skillshotNames[ribbonItemDefinition.skillShotType].Value3);
		}
	}

	public GainRibbonsAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, float levelProgress, string secondParameter)
		: base(databaseAssignment, levelProgress)
	{
		Debug.Log("Assignment: GainRibbons Constructor");
		data = Assignment.GetAloneObjectFor(11, 3, databaseAssignment.target);
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 11);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = databaseAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken ribbon = GetRibbon(row, secondParameter);
		int ribbonIndex = Singleton<RibbonManager>.instance.GetRibbonIndex(ribbon["NAME"].ToObject<string>());
		data[0] = Convert.ToInt32(data[0]) * ribbon["COUNT"].ToObject<int>();
		data[1] = Singleton<RibbonManager>.instance.ribbons[ribbonIndex].name;
		data[2] = ribbonIndex;
	}

	private JToken GetRibbon(TaskDefinitionsRow definition, string param)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(definition.SECONDTARGETPARAMETER);
		if (!string.IsNullOrEmpty(param))
		{
			dictionary.TryGetValue(param, out var value);
			if (value == null)
			{
				using Dictionary<string, object>.Enumerator enumerator = dictionary.GetEnumerator();
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, object> current = enumerator.Current;
					value = current;
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
		int counter = Singleton<RibbonManager>.instance.ribbons[Convert.ToInt32(data[2])].counter;
		base.completeFract = CompareIntAndInt(counter, Convert.ToInt32(data[0]));
		return base.completeFract;
	}
}
