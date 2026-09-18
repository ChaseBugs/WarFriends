using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArenaRuleGeneric<T> : WarArenaRule where T : RuleData
{
	[SerializeField]
	protected T data;

	public override RuleData GetData()
	{
		return data;
	}

	public override string Serialize()
	{
		return JsonConvert.SerializeObject(data);
	}

	public override void DeSerialize(JToken value)
	{
		data = value.ToObject<T>();
	}
}
