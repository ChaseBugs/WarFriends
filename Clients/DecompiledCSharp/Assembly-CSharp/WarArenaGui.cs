using System.Collections.Generic;

public static class WarArenaGui
{
	public static List<WarArenaRule.WarArenaRuleGui> currentArenaGuiRules
	{
		get
		{
			List<WarArenaRule.WarArenaRuleGui> list = new List<WarArenaRule.WarArenaRuleGui>();
			if (WarArena.instance.warArenaConfig == null)
			{
				return list;
			}
			foreach (WarArenaRule currenArenaRule in WarArena.instance.currenArenaRules)
			{
				WarArenaRule.WarArenaRuleGui guiRule = currenArenaRule.guiRule;
				if (guiRule != null && (currenArenaRule.GetData().showRule || guiRule.type == WarArenaRule.RuleType.FulFill || guiRule.type == WarArenaRule.RuleType.DoesNotMeet))
				{
					list.Add(guiRule);
				}
			}
			string showText = Localization.LocalizeFormat("ID_ARENARULES_BATTLES", Colours.stringGreenArena, WarArena.instance.warArenaConfig.battles);
			list.Add(new WarArenaRule.WarArenaRuleGui(showText, WarArenaRule.RuleType.InfoText));
			int lifeCount = WarArena.instance.warArenaConfig.lifeCount;
			string showText2 = ((lifeCount <= 1) ? Localization.LocalizeFormat("ID_ARENARULES_LIVE", Colours.stringGreenArena) : Localization.LocalizeFormat("ID_ARENARULES_LIVES", Colours.stringGreenArena, lifeCount));
			list.Add(new WarArenaRule.WarArenaRuleGui(showText2, WarArenaRule.RuleType.InfoText));
			string showText3 = Localization.LocalizeFormat("ID_ARENARULES_NORMALIZATION", Colours.stringGreenArena);
			list.Add(new WarArenaRule.WarArenaRuleGui(showText3, WarArenaRule.RuleType.InfoText));
			list.StableSort((WarArenaRule.WarArenaRuleGui data1, WarArenaRule.WarArenaRuleGui data2) => (data1.type != data2.type) ? data1.type.CompareTo(data2.type) : 0);
			return list;
		}
	}

	public static List<WarArenaRule.WarArenaRuleGui> failSetupRules
	{
		get
		{
			List<WarArenaRule.WarArenaRuleGui> list = new List<WarArenaRule.WarArenaRuleGui>();
			foreach (WarArenaRule currenArenaRule in WarArena.instance.currenArenaRules)
			{
				WarArenaRule.WarArenaRuleGui guiRule = currenArenaRule.guiRule;
				if (guiRule != null && guiRule.type == WarArenaRule.RuleType.DoesNotMeet)
				{
					list.Add(guiRule);
				}
			}
			return list;
		}
	}

	public static string CreateArenaTimeTextWithColour(string colourString)
	{
		if (WarArena.instance.warArenaConfig == null)
		{
			return string.Empty;
		}
		if (WarArena.instance.warArenaConfig.isBeforeArenaStart)
		{
			return Localization.LocalizeFormat("ID_ARENASHORTCUTEVENTSTART", colourString, MiscTools.PrintableTime(WarArena.instance.warArenaConfig.remainingTimeTillStart, "ID_READYTIME", string.Empty));
		}
		if (WarArena.instance.warArenaConfig.isAfterArenaEnd)
		{
			return string.Empty;
		}
		WarArenaConfig.PlayWindow currentWindow = WarArena.instance.warArenaConfig.currentWindow;
		WarArenaConfig.PlayWindow nextWindow = WarArena.instance.warArenaConfig.nextWindow;
		bool flag = nextWindow == null;
		if (currentWindow != null)
		{
			if (currentWindow.isActive)
			{
				string keyFormat = ((!flag) ? "ID_ARENASHORTCUTPHASEEND" : "ID_ARENASHORTCUTEVENTEND");
				return Localization.LocalizeFormat(keyFormat, colourString, MiscTools.PrintableTime(currentWindow.remainingTimeTillWindowEnd, "ID_READYTIME", string.Empty));
			}
			if (!flag)
			{
				return Localization.LocalizeFormat("ID_ARENASHORTCUTPHASESTART", colourString, MiscTools.PrintableTime(nextWindow.remainingTimeTillWindowStart, "ID_READYTIME", string.Empty));
			}
		}
		return string.Empty;
	}

	public static string CreateArenaWindowTimeText(bool encoding = false, bool moreLines = false)
	{
		if (WarArena.instance.warArenaConfig == null || WarArena.instance.warArenaConfig.isBeforeArenaStart || WarArena.instance.warArenaConfig.isAfterArenaEnd)
		{
			return string.Empty;
		}
		WarArenaConfig.PlayWindow currentWindow = WarArena.instance.warArenaConfig.currentWindow;
		if (currentWindow != null)
		{
			if (currentWindow.isActive)
			{
				return Localization.LocalizeFormat((!moreLines) ? "ID_ARENAENDSTIMER" : "ID_ARENAENDSENTERTIMER", (!encoding) ? Colours.stringGreenArena : "[-]", MiscTools.PrintableTime(currentWindow.remainingTimeTillWindowEnd, "ID_READYTIME", string.Empty));
			}
			WarArenaConfig.PlayWindow nextWindow = WarArena.instance.warArenaConfig.nextWindow;
			if (nextWindow != null)
			{
				return Localization.LocalizeFormat((!moreLines) ? "ID_ARENASTARTSTIMER" : "ID_ARENASTARTSENTERTIMER", (!encoding) ? Colours.stringGreenArena : "[-]", MiscTools.PrintableTime(nextWindow.remainingTimeTillWindowStart, "ID_READYTIME", string.Empty));
			}
		}
		return string.Empty;
	}

	public static string CreateArenaButtonTimeText()
	{
		if (WarArena.instance.warArenaConfig == null || WarArena.instance.warArenaConfig.isAfterArenaEnd)
		{
			return string.Empty;
		}
		if (WarArena.instance.warArenaConfig.isBeforeArenaStart)
		{
			return Localization.LocalizeFormat("ID_ARENASTARTSTIMER", "[-]", MiscTools.PrintableTime(WarArena.instance.remainigTimeTillStart, "ID_READYTIME", string.Empty));
		}
		WarArenaConfig.PlayWindow currentWindow = WarArena.instance.warArenaConfig.currentWindow;
		if (currentWindow != null)
		{
			if (currentWindow.isActive)
			{
				return string.Empty;
			}
			WarArenaConfig.PlayWindow nextWindow = WarArena.instance.warArenaConfig.nextWindow;
			if (nextWindow != null)
			{
				return Localization.LocalizeFormat("ID_ARENASTARTSTIMER", Colours.stringBlack, MiscTools.PrintableTime(nextWindow.remainingTimeTillWindowStart, "ID_READYTIME", string.Empty));
			}
		}
		return string.Empty;
	}

	public static bool ShouldArenaBattleButtonUpdate()
	{
		return WarArena.instance.warArenaConfig != null && WarArena.instance.warArenaConfig.currentWindow != null && !WarArena.instance.warArenaConfig.currentWindow.isActive;
	}

	public static bool ShouldArenaEnterButtonUpdate()
	{
		return WarArena.instance.warArenaConfig != null && WarArena.instance.warArenaConfig.isBeforeArenaStart;
	}

	public static string CreateArenaEventTimeText()
	{
		if (WarArena.instance.warArenaConfig == null || WarArena.instance.warArenaConfig.isAfterArenaEnd)
		{
			return string.Empty;
		}
		if (WarArena.instance.warArenaConfig.isBeforeArenaStart)
		{
			return Localization.LocalizeFormat("ID_ARENAEVENTSTARTSIN", MiscTools.PrintableTime(WarArena.instance.remainigTimeTillStart, "ID_READYTIME", string.Empty));
		}
		return Localization.LocalizeFormat("ID_ARENAEVENTENDSIN", MiscTools.PrintableTime(WarArena.instance.remainigTimeTillEnd, "ID_READYTIME", string.Empty));
	}

	public static bool ShouldArenaEventTimerPulsate()
	{
		return WarArena.instance.warArenaConfig != null && WarArena.instance.isOpened && WarArena.instance.warArenaConfig.end - Singleton<BeanstalkServerManager>.instance.currentTimestamp < 10800;
	}

	public static string CreateArenaEventTimeTextLowerCase()
	{
		if (WarArena.instance.warArenaConfig == null || WarArena.instance.warArenaConfig.isAfterArenaEnd)
		{
			return string.Empty;
		}
		if (WarArena.instance.warArenaConfig.isBeforeArenaStart)
		{
			return Localization.LocalizeFormat("ID_EVENTSTARTSINSMALL", Colours.stringGreenArena, MiscTools.PrintableTime(WarArena.instance.remainigTimeTillStart, "ID_READYTIME", string.Empty));
		}
		return Localization.LocalizeFormat("ID_EVENTENDSINSMALL", Colours.stringGreenArena, MiscTools.PrintableTime(WarArena.instance.remainigTimeTillEnd, "ID_READYTIME", string.Empty));
	}

	public static string CreateArenaButtonTitle()
	{
		if (WarArena.instance.warArenaConfig != null && WarArena.instance.isOpened)
		{
			WarArenaConfig.PlayWindow currentWindow = WarArena.instance.warArenaConfig.currentWindow;
			if (currentWindow != null && !currentWindow.isActive)
			{
				WarArenaConfig.PlayWindow nextWindow = WarArena.instance.warArenaConfig.nextWindow;
				if (nextWindow != null)
				{
					return Localization.LocalizeFormat("ID_STARTSINX", MiscTools.PrintableTime(nextWindow.remainingTimeTillWindowStart, "ID_READYTIME", string.Empty));
				}
			}
			return Localization.Localize("ID_BATTLEINARENA");
		}
		return Localization.Localize("ID_ARENACLOSED");
	}
}
