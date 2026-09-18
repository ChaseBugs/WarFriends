using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class PlayerLeagueFinished : DatabaseMessage
{
	private League newLeague;

	public League fromLeague;

	public int position;

	public int endMedals;

	public long goldReward;

	public bool enoughPlayersInLeague;

	public string formerFullLeagueId;

	public PlayerLeagueFinished(JToken dict)
		: base(dict)
	{
		string value = dict["LeagueId"]["N"].ToObject<string>();
		int num = Convert.ToInt32(value);
		newLeague = (League)num;
		if (dict["BeforeLeagueId"] != null)
		{
			fromLeague = (League)StringParser.ParseIntToken(dict["BeforeLeagueId"]["N"]);
		}
		else
		{
			fromLeague = League.NoLeague;
		}
		if (dict["Medals"] != null)
		{
			endMedals = StringParser.ParseIntToken(dict["Medals"]["N"]);
		}
		else
		{
			endMedals = 0;
		}
		if (dict["FormerFullLeagueId"] != null)
		{
			formerFullLeagueId = StringParser.ParseString("FormerFullLeagueId", "S", dict, string.Empty);
			Debug.Log("GOT FORMER FULL LEAGUE ID = " + formerFullLeagueId);
		}
		if (dict["RewardGold"] != null)
		{
			goldReward = StringParser.ParseLongToken(dict["RewardGold"]["N"], 0L);
		}
		if (dict["Position"] != null)
		{
			position = StringParser.ParseIntToken(dict["Position"]["N"]);
		}
		else
		{
			position = -1;
		}
		enoughPlayersInLeague = dict["NotEnoughPlayers"] == null;
		Debug.LogFormat("PlayerLeagueFinished - Player joined {0}, leave {1}, finish on position {2}, with medals {3}", newLeague, fromLeague, position, endMedals);
	}

	public override void Show()
	{
		base.Show();
		if (position > 100)
		{
			Debug.LogFormat("PlayerLeagueFinished - Wrong position from server after league end for current player id:{0} position:{1}", GameLoginManager.currentPlayer.id, position);
			position = 100;
		}
		if (position > 0)
		{
			Debug.Log("PlayerLeagueFinished - SHOWING LEAGUE RESULTS DIALOG!");
			GuiElementSingle<LeagueResultDialog>.instance.ShowDialog(fromLeague, newLeague, position);
			Singleton<EventTrackingManager>.instance.FinishLeague(fromLeague, newLeague, position);
		}
		else
		{
			Debug.Log("PlayerLeagueFinished - POSITION WAS ZERO! Not SHOWING LEAGUE RESULT DIALOG!");
		}
		Debug.Log("PlayerLeagueFinished - FORMER LEAGUE ID = " + formerFullLeagueId + ", current = " + GameLoginManager.currentPlayer.leagueId);
		if (GameLoginManager.currentPlayer.leagueId.Equals(formerFullLeagueId))
		{
			Debug.Log("PlayerLeagueFinished- YES - removing player from league");
			GameLoginManager.instance.RemovePlayerFromLeague(newLeague);
		}
		else
		{
			Debug.Log("PlayerLeagueFinished - NO - player is already in new league");
		}
		if (goldReward == 0L)
		{
			Ignore();
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.ClaimReward(this);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, goldReward));
		}
		Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = false;
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.RemoveFromLeague);
	}
}
