using Newtonsoft.Json.Linq;
using UnityEngine;

public class WarArenaRule : ScriptableObject
{
	public enum RuleType
	{
		FulFill,
		DoesNotMeet,
		InfoRule,
		InfoText
	}

	public class WarArenaRuleGui
	{
		public RuleType type;

		public string text;

		public string alternativeText;

		public string hint;

		public string debugString => $"[{type.ToString().ToUpper()}] {text}";

		public WarArenaRuleGui()
		{
			type = RuleType.InfoRule;
			text = string.Empty;
		}

		public WarArenaRuleGui(string showText, RuleType showType = RuleType.InfoRule)
		{
			type = showType;
			text = showText;
		}

		public WarArenaRuleGui(string showText, string hintText, string showAlternativeText, RuleType showType)
		{
			type = showType;
			hint = hintText;
			text = showText;
			alternativeText = showAlternativeText;
		}
	}

	public WarArenaRuleGui guiRule
	{
		get
		{
			WarArenaRuleGui genericRule = GetGenericRule();
			if (genericRule == null)
			{
				return null;
			}
			WarArenaConfig warArenaConfig = WarArena.instance.warArenaConfig;
			if (warArenaConfig.rulesTexts.TryGetValue(GetType().ToString(), out var value))
			{
				genericRule.text = value.Value1;
				genericRule.hint = value.Value2;
			}
			return genericRule;
		}
	}

	public virtual string Serialize()
	{
		return string.Empty;
	}

	public virtual RuleData GetData()
	{
		return null;
	}

	public virtual void DeSerialize(JToken value)
	{
	}

	public virtual void ApplyRule()
	{
	}

	public virtual bool SetupRule()
	{
		return true;
	}

	protected virtual WarArenaRuleGui GetGenericRule()
	{
		return new WarArenaRuleGui();
	}
}
