using System;
using System.Collections.Generic;

public class WarArenaRuleCardsFilter : WarArenaRuleGeneric<WarArenaRuleCardsFilter.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public CardManager.CardFilter filter;
	}

	private static Dictionary<CardManager.CardFilter, string> mTexts = new Dictionary<CardManager.CardFilter, string>
	{
		{
			CardManager.CardFilter.None,
			"ID_ARENARULES_NOWARCARDS"
		},
		{
			CardManager.CardFilter.Bronze,
			"ID_ARENARULES_BRONZEWARCARDS"
		},
		{
			CardManager.CardFilter.Silver,
			"ID_ARENARULES_SILVERWARCARDS"
		},
		{
			CardManager.CardFilter.Gold,
			"ID_ARENARULES_GOLDWARCARDS"
		},
		{
			CardManager.CardFilter.Buddy,
			"ID_ARENARULES_BUDDYWARCARDS"
		}
	};

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.filter != CardManager.CardFilter.All)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize(mTexts[data.filter]));
		}
		return base.GetGenericRule();
	}

	public override bool SetupRule()
	{
		base.SetupRule();
		Singleton<GameController>.instance.gameControllerWarArena.SetCardsFilter(data.filter);
		return true;
	}
}
