using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LeagueEnterMessage : DatabaseMessage
{
	public bool isLocalMessage;

	public bool isFinishedBeginners;

	public bool isNormalLeague;

	public League placedInLeague;

	public int placedInBeginnersLeague;

	public bool firstTime;

	public override bool actionLeavesLobby => true;

	public LeagueEnterMessage(League league, bool firstTimeInLeagues)
		: base("LeagueEntered", Type.LeagueEntered)
	{
		isLocalMessage = true;
		isNormalLeague = true;
		if (firstTimeInLeagues)
		{
			messageId += $"{league}-firstTime-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		}
		else
		{
			messageId += $"{league}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		}
		placedInLeague = league;
		firstTime = firstTimeInLeagues;
	}

	public LeagueEnterMessage(int beginnersLeague)
		: base("BeginnersLeagueEntered", Type.LeagueEntered)
	{
		isLocalMessage = true;
		messageId += $"{beginnersLeague}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		placedInBeginnersLeague = beginnersLeague;
	}

	public LeagueEnterMessage(League league)
		: base("FinishedBeginnersLeague", Type.LeagueEntered)
	{
		isLocalMessage = true;
		isFinishedBeginners = true;
		messageId = messageId + "-" + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		placedInLeague = league;
	}

	public LeagueEnterMessage(JToken dict)
		: base(dict)
	{
		isLocalMessage = false;
		isNormalLeague = true;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string text = dict["LeagueId"]["S"].ToObject<string>();
		int num = Convert.ToInt32(Regex.Replace(text, "-[0-9]*$", string.Empty));
		int num2 = Convert.ToInt32(Regex.Replace(text, "^[0-9]*-", string.Empty));
		Debug.LogFormat("Player Entered League:{0}  tier:{1}  division:{2}", text, num, num2);
		if (currentPlayer.leagueId != text)
		{
			Debug.LogFormat("Different actual league Id \"{0}\" and database message - league entered - league id \"{1}\"", currentPlayer.leagueId, text);
			GameLoginManager.instance.UpdatePlayerLeagueAndMedals(currentPlayer.beginnersLeague, text, currentPlayer.skill, currentPlayer.medalsBalance, currentPlayer.remainingMatches);
		}
		placedInLeague = (League)num;
	}

	public override void Show()
	{
		base.Show();
		if (isFinishedBeginners)
		{
			GuiElementSingle<LeagueDialog>.instance.ShowFinishedBeginnersLeague(placedInLeague);
		}
		else if (isNormalLeague)
		{
			GuiElementSingle<LeagueDialog>.instance.ShowEnterToNormalLeague(placedInLeague, firstTime);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.ShowEnterToBeginnersLeague(placedInBeginnersLeague);
		}
		if (!isLocalMessage)
		{
			Ignore();
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_LeagueEntered(messageType, messageTime, placedInLeague);
		return delegate
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		};
	}
}
