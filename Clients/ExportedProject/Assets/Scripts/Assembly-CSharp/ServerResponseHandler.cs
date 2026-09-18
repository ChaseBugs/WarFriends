using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ServerResponseHandler
{
	private ServerErrorHandler mErrorHandler = new ServerErrorHandler();

	private Dictionary<string, object> mResponse;

	private ServerTime mServerTime;

	private bool mTutorialAlreadyInProgress;

	public ServerResponseHandler(ServerTime serverTime)
	{
		mServerTime = serverTime;
	}

	public static string test()
	{
		return "JKoZIhvcNAQkBFhN2b2p0YXNpdnJAZ";
	}

	public void ErrorReceived(DatabaseResult result, DatabaseAction databaseAction, List<Tuple<string, string>> postData)
	{
		mErrorHandler.ServerErrorReceived(result, null, databaseAction, postData);
	}

	public DatabaseResult ServerRequestFinished(DatabaseAction databaseAction, string response, List<Tuple<string, string>> postData)
	{
		try
		{
			float num = (float)(response.Length * 2) / 1024f;
			if (num > 85f)
			{
				Debug.LogWarning($"Too big response from server, Action: {databaseAction} Size: {num}kB");
			}
			if (databaseAction == DatabaseAction.GetConfigurations)
			{
				GameConfigurationManager.instance.UpdateConfigurationsNew(response);
				Singleton<BeanstalkServerManager>.instance.DataWasLoaded(databaseAction);
				mResponse = null;
				return DatabaseResult.Success;
			}
			mResponse = (Dictionary<string, object>)JsonConvert.DeserializeObject(response, typeof(Dictionary<string, object>));
			int num2 = Convert.ToInt32(mResponse["Result"]);
			if (num2 > 10)
			{
				Debug.Log(string.Concat("Beanstalk: ", databaseAction, " failure. Server response = ", response));
				try
				{
					DatabaseResult databaseResult = (DatabaseResult)num2;
					if (databaseResult == DatabaseResult.ThroughputExceededException)
					{
						WarningDialog.ShowError(Localization.Localize("ID_WARNING_CLICKOKTORESEND"), Localization.Localize("ID_WARNING_SERVERTIMEDOUT"), 0f, delegate
						{
							Singleton<BeanstalkServerManager>.instance.ResendAction(databaseAction, postData);
						}, string.Empty);
					}
					else
					{
						mErrorHandler.ServerErrorReceived((DatabaseResult)num2, mResponse, databaseAction, postData);
						Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("Client threw exception while trying to react to error response from the server.");
					Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception, databaseAction, response, Singleton<BeanstalkServerManager>.instance.postParameters);
				}
				return (DatabaseResult)num2;
			}
			try
			{
				switch (databaseAction)
				{
				case DatabaseAction.MessageSent:
					OnMessageSent();
					break;
				case DatabaseAction.GetPlayerData:
					OnGetPlayerData();
					break;
				case DatabaseAction.SendCrashReport:
					OnSendCrashReport();
					break;
				case DatabaseAction.CreateSquad:
					OnCreateSquad();
					break;
				case DatabaseAction.JoinSquad:
					OnJoinSquad();
					break;
				case DatabaseAction.LeaveSquad:
					OnLeaveSquad();
					break;
				case DatabaseAction.AddGooglePlay:
					OnAddServiceProvider((DatabaseResult)num2, Constants.rowIds.GooglePlayLoginReward, AccountType.GooglePlay, "GooglePlay");
					break;
				case DatabaseAction.AddFacebook:
					OnAddServiceProvider((DatabaseResult)num2, Constants.rowIds.FacebookLoginReward, AccountType.Facebook, "Facebook");
					break;
				case DatabaseAction.ExistFBAccount:
					OnCheckExistFbAccount((DatabaseResult)num2);
					break;
				case DatabaseAction.Test:
					Debug.Log("On Test = " + mResponse["Test"]);
					break;
				case DatabaseAction.UpdateAnalytics:
				case DatabaseAction.CompleteStarterAssignments:
					Debug.Log("Action Finished: " + databaseAction);
					break;
				case DatabaseAction.PromotePlayer:
					OnPromotePlayer();
					break;
				case DatabaseAction.DemotePlayer:
					OnDemotePlayer();
					break;
				case DatabaseAction.PromotePlayerToFounder:
					OnPromotePlayerToFounder();
					break;
				case DatabaseAction.GetFriendsInfo:
					OnGetFriendsInfo();
					break;
				case DatabaseAction.DebugChangeArenaLives:
				case DatabaseAction.DebugChangeArenaWins:
					Debug.LogError("ON DEBUG ARENA!");
					WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(StringParser.ParseString(mResponse["WarArenaData"], string.Empty));
					break;
				case DatabaseAction.InvitePlayerToSquad:
					OnInvitePlayerToSquad();
					break;
				case DatabaseAction.InstantBattle:
					OnInstantBattleEnded();
					break;
				case DatabaseAction.GameEnded:
				case DatabaseAction.TutorialEnded:
					OnGameEnded(databaseAction);
					break;
				case DatabaseAction.BuyArenaHearth:
					OnBuyArenaHeart();
					break;
				case DatabaseAction.TakeArenaLife:
					OnTakeArenaHearth();
					break;
				case DatabaseAction.GetScrapsReward:
					OnArenaEnded();
					break;
				case DatabaseAction.GameStartedMaster:
				case DatabaseAction.GameStartedClient:
				case DatabaseAction.GameStartedCampaign:
				case DatabaseAction.GameStartedCoopMaster:
				case DatabaseAction.GameStartedCoopClient:
					OnGameStarted(databaseAction);
					break;
				case DatabaseAction.BuyInApp:
					OnBuyInApp(postData);
					break;
				case DatabaseAction.RefillDogtags:
					OnRefillDogtags();
					break;
				case DatabaseAction.AcceptSpecialOffer:
				case DatabaseAction.AcceptRentalOffer:
					OnAcceptSpecialOffer();
					break;
				case DatabaseAction.ProvokePlayer:
					OnProvokePlayer();
					break;
				case DatabaseAction.ClaimReward:
					OnClaimReward();
					break;
				case DatabaseAction.ClaimAssignmentMegaReward:
					OnClaimAssignmentMegaReward();
					break;
				case DatabaseAction.DebugChangeLevel:
					OnDebugMaxAll();
					break;
				case DatabaseAction.DebugAddLevel:
					OnDebugAddLevel();
					break;
				case DatabaseAction.SendRequestBuffer:
					OnSendRequestBuffer();
					break;
				case DatabaseAction.GetSquadDetails:
					OnGetSquadDetails();
					break;
				case DatabaseAction.GetMissionLeaderboards:
					OnGetMissionLeaderboards();
					break;
				case DatabaseAction.SkipAssignment:
					OnSkipAssignment();
					break;
				case DatabaseAction.JoinSquadEvent:
					OnJoinSquadEvent();
					break;
				case DatabaseAction.BuyVip:
					OnBuyVip();
					break;
				case DatabaseAction.DeclineSquadJoinRequest:
					OnDeclineSquadJoinRequest(postData);
					break;
				case DatabaseAction.IgnoreMessage:
					OnIgnoreMessage();
					break;
				case DatabaseAction.GetAllMessages:
					OnGetAllMessages();
					break;
				case DatabaseAction.UpdateDeviceToken:
					OnUpdateDeviceToken();
					break;
				case DatabaseAction.GetAllSquadMembers:
					OnGetAllSquadMembers();
					break;
				case DatabaseAction.CheckUniqueSquadName:
					OnCheckUniqueSquadName();
					break;
				case DatabaseAction.GetPlayerLeaguesDivision:
					OnGetPlayerLeaguesDivision();
					break;
				case DatabaseAction.GetSquads:
				case DatabaseAction.FindSuggestedSquads:
					OnGetSquads();
					break;
				case DatabaseAction.GetSquadWarsDivision:
					OnGetSquadWarsDivision();
					break;
				case DatabaseAction.GetSquadsByExperience:
					OnGetSquadsByExperience();
					break;
				case DatabaseAction.SearchPlayers:
					OnSearchPlayers();
					break;
				case DatabaseAction.BuyPack:
					OnBuyPack(postData);
					break;
				case DatabaseAction.BuyLootboxes:
					OnBuyLootboxes();
					break;
				case DatabaseAction.UpdateSquadEmblem:
					OnUpdateSquadEmblem();
					break;
				case DatabaseAction.AcceptChallenge:
					OnAcceptChallenge();
					break;
				case DatabaseAction.SetPlayerStatus:
					OnSetPlayerStatus();
					break;
				case DatabaseAction.OnVIPExpired:
					OnVipExpired();
					break;
				case DatabaseAction.LoginToCustomAccount:
					OnLoginToCustomAccount();
					break;
				case DatabaseAction.GetPlayersByExperience:
					OnGetPlayersByExperience();
					break;
				case DatabaseAction.UpdateRegionPings:
					OnUpdateRegionPings();
					break;
				case DatabaseAction.KickPlayer:
					OnKickPlayer();
					break;
				case DatabaseAction.DepositCards:
					OnDepositCards();
					break;
				case DatabaseAction.CreateAccount:
				case DatabaseAction.CreateGcAccount:
					OnCreateAccount();
					break;
				case DatabaseAction.RemoveOrUpdateGC:
					OnGCUpdated();
					break;
				case DatabaseAction.GameStartedTutorial:
					OnTutorialStarted();
					break;
				case DatabaseAction.PayOneDogTag:
					OnPayOneDogTag();
					break;
				case DatabaseAction.ReadMessage:
					Debug.Log("Beanstalk: Message read");
					break;
				case DatabaseAction.PhotonIsFull:
					OnPhotonIsFull();
					break;
				case DatabaseAction.UpdateSquad:
					OnUpdateSquad();
					break;
				case DatabaseAction.JoinSquadRequest:
					OnJoinSquadRequest();
					break;
				case DatabaseAction.DebugAddSquadLevel:
					DebugAddSquadLevel();
					break;
				case DatabaseAction.ChangePlayerName:
					OnChangePlayerName();
					break;
				case DatabaseAction.GenerateSpecialOffer:
					OnGenerateSpecialOffer();
					break;
				case DatabaseAction.SpecialOfferShowed:
					Singleton<OfferManager>.instance.ShowedSavedOnServer();
					break;
				case DatabaseAction.AddDebugGoodies:
					OnDebugAddGoodies();
					break;
				case DatabaseAction.NotifyPlayerToDeposit:
				case DatabaseAction.UpdateArmyPower:
					Debug.Log("Action Success: " + databaseAction);
					break;
				case DatabaseAction.GetPlayerInfo:
					OnGetPlayerInfo();
					break;
				case DatabaseAction.MaxAll:
					OnDebugMaxAll();
					break;
				case DatabaseAction.SendPlayerReport:
					OnSendPlayerReport();
					break;
				case DatabaseAction.DebugChangeAnticheat:
					OnChangeAnticheatStatus();
					break;
				case DatabaseAction.ReportCheater:
					OnReportCheater();
					break;
				case DatabaseAction.RestorePacks:
					OnRestorePacks();
					break;
				case DatabaseAction.ClaimCraftedCard:
					OnClaimCraftedCard();
					break;
				case DatabaseAction.GetNewAssignments:
					OnGetNewAssignments();
					break;
				case DatabaseAction.ChangeLanguage:
					OnChangeLanguage();
					break;
				case DatabaseAction.GetFullSquadInfo:
					OnGetFullSquadInfo();
					break;
				case DatabaseAction.InformSquadLeaderAboutEvent:
					OnInformSquadLeaderAboutEvent();
					break;
				case DatabaseAction.AcceptSquadJoinRequest:
					OnAcceptSquadJoinRequest();
					break;
				case DatabaseAction.GetLastWeeksPlayerLeague:
					OnGetLastWeeksPlayerLeague();
					break;
				case DatabaseAction.AddVideoReward:
					OnAddReward(isMegaReward: false);
					break;
				case DatabaseAction.FinishPlayerLeague:
					OnFinishPlayerLeague();
					break;
				case DatabaseAction.WithdrawCard:
					OnWithdrawCard();
					break;
				case DatabaseAction.AddGameCenter:
					OnAddGameCenter();
					break;
				case DatabaseAction.AddOneTimeReward:
					OnAddOneTimeReward();
					break;
				case DatabaseAction.DebugChangeMedals:
					OnDebugChangeMedals();
					break;
				case DatabaseAction.DebugChangeLeague:
					OnDebugChangeLeague();
					break;
				case DatabaseAction.DebugChangeDivision:
					OnDebugChangeDivision();
					break;
				case DatabaseAction.ElitesFeatureShown:
					ElitesFeatureShownRequest.OnSuccess(mResponse);
					break;
				case DatabaseAction.ChatShownFirstTime:
					OnChatShownFirstTime();
					break;
				case DatabaseAction.WarArenaShown:
					WarArenaShownRequest.OnSuccess(mResponse);
					break;
				case DatabaseAction.RemoveFacebook:
				case DatabaseAction.RemoveGooglePlay:
					OnRemoveLogin();
					break;
				case DatabaseAction.UpdateSettings:
					OnSendSettings();
					break;
				case DatabaseAction.CustomizationShown:
					OnCustomizationShown();
					break;
				case DatabaseAction.WarpathShownFirstTime:
					OnWarpathShown();
					break;
				case DatabaseAction.GetArenaLeaderboards:
					GetArenaLeaderboardsRequest.OnSuccess(mResponse);
					break;
				case DatabaseAction.EnterArena:
					EnterArenaRequest.OnSuccess(mResponse);
					break;
				case DatabaseAction.WarArenaEnded:
					WarArenaEndedRequest.OnSuccess(mResponse);
					break;
				case DatabaseAction.DebugAddScraps:
					DebugAddScrapsRequest.OnSuccess(mResponse);
					break;
				case DatabaseAction.CardpoolShown:
					OnCardpoolShown();
					break;
				case DatabaseAction.CraftingShown:
					OnCraftingShown();
					break;
				case DatabaseAction.SendLog:
					OnSendLog();
					break;
				case DatabaseAction.CraftCard:
					OnCraftCards();
					break;
				case DatabaseAction.ExistGCAccount:
					OnCheckExistGcAccount();
					break;
				case DatabaseAction.CheckDailyReward:
					Debug.Log("daily reward chacked");
					if (mResponse.ContainsKey("dailyRewardData") && StatsManager.instance.DailyRewardDataLoaded((JToken)mResponse["dailyRewardData"]) && !GuiScreenSingle<DailyRewardMonthScreen>.instance.isShowed)
					{
						Singleton<MessageManager>.instance.AddMessage(new DailyRewardMessage(StatsManager.instance.dailyRewardData.toClaim + StatsManager.instance.dailyRewardData.month * 100));
					}
					break;
				case DatabaseAction.ClaimDailyReward:
					Debug.Log("daily reward claimed");
					StatsManager.instance.DailyRewardDataLoaded((JToken)mResponse["dailyRewardData"]);
					break;
				case DatabaseAction.DebugRenewRental:
					Debug.Log("rental data deleted, new rental after restart game (still need finished tutorial and level >= 4!!!!)");
					break;
				case DatabaseAction.SaveFuseConfigs:
					LogResponse(databaseAction);
					break;
				}
			}
			catch (Exception exception2)
			{
				Debug.LogError("Exception while Parsing");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception2, databaseAction, response, Singleton<BeanstalkServerManager>.instance.postParameters);
				if (databaseAction == DatabaseAction.GetPlayerData)
				{
					mErrorHandler.HandleException(exception2, databaseAction, postData);
					return DatabaseResult.JsonFailure;
				}
			}
			try
			{
				Singleton<BeanstalkServerManager>.instance.DataWasLoaded(databaseAction);
			}
			catch (Exception exception3)
			{
				Debug.LogError("Error when client tried to work with server response!");
				Debug.Log("Player is allowed to continue.");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception3, databaseAction, response, Singleton<BeanstalkServerManager>.instance.postParameters);
			}
			mResponse = null;
			return (DatabaseResult)num2;
		}
		catch (Exception exception4)
		{
			mResponse = null;
			Debug.Log(string.Concat("Beanstalk: ", databaseAction, " JSON failure."));
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(exception4, databaseAction, response, Singleton<BeanstalkServerManager>.instance.postParameters);
			mErrorHandler.HandleException(exception4, databaseAction, postData);
			return DatabaseResult.JsonFailure;
		}
	}

	private void LogResponse(DatabaseAction action)
	{
		Debug.LogFormat("response for {0}", action);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, object> item in mResponse)
		{
			stringBuilder.AppendFormat("{0}: {1}\n", item.Key, item.Value);
		}
		Debug.Log(stringBuilder.ToString());
	}

	private void OnVipExpired()
	{
		if (mResponse.ContainsKey("DogTagSeconds") && mResponse.ContainsKey("DogTagLastUpdate"))
		{
			int dtSeconds = StringParser.ParseInt(mResponse["DogTagSeconds"]);
			int dtLastUpdate = StringParser.ParseInt(mResponse["DogTagLastUpdate"]);
			Singleton<DogTagManager>.instance.UpdateDogtags(dtSeconds, dtLastUpdate);
		}
	}

	private void OnRestorePacks()
	{
		Debug.LogError("BEANSTALK: ON RESTORE PACKS");
		if (!Singleton<GameController>.instance.isTutorialInProgressOrPlaned)
		{
			Debug.LogError("HIDIING");
			LoadingDialog.Hide();
		}
		else
		{
			Debug.LogError("NOT HIDING");
		}
		LoadPlayerData((JToken)mResponse["PlayerData"], executePlayerDataRoutines: false);
		if (mResponse.ContainsKey("RestoredPacks"))
		{
			Debug.LogError("RESTORE PACKS = " + mResponse["RestoredPacks"]);
		}
	}

	private void OnClaimCraftedCard()
	{
		string text = StringParser.ParseString(mResponse["CardId"], string.Empty);
		Debug.Log("Crafted warcard id from server: " + text);
		int timeSinceDelivery = Singleton<BeanstalkServerManager>.instance.currentTimestamp - CardCraftingManager.instance.data.end;
		Singleton<EventTrackingManager>.instance.RegisterClaimCraftedCard(text, timeSinceDelivery);
		CardCraftingManager.instance.ClaimWarcard(text);
	}

	private void OnCraftCards()
	{
		Debug.Log("On Craft Cards");
		int num = StringParser.ParseInt(mResponse["End"]);
		CardCraftingManager.instance.endCraftingTime = num;
		PushNotificationManager.instance.ScheduleCraftingFinishedNotification(num, CardCraftingManager.instance.isGoldCrafting);
		int[] rarityCounts = CardManager.instance.GetRarityCounts();
		List<string> cards = CardCraftingManager.instance.data.cards;
		foreach (string item in cards)
		{
			Singleton<EventTrackingManager>.instance.RegisterCardCraftingStarted(item, rarityCounts);
		}
	}

	private void OnWithdrawCard()
	{
		Debug.Log("Card withdrawn");
		int nextWithdraw = StringParser.ParseInt(mResponse["NextWithdraw"]);
		CardManager.instance.nextWithdraw = nextWithdraw;
		PushNotificationManager.instance.ScheduleNextWithdrawNotification(nextWithdraw);
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
		Singleton<NotificationManager>.instance.UpdateCardpoolNotifications();
	}

	private void OnDepositCards()
	{
		Debug.Log("Cards Deposited");
		if (mResponse.ContainsKey("NextBuddyDeposit"))
		{
			CardManager.instance.nextBuddyDeposit = StringParser.ParseInt(mResponse["NextBuddyDeposit"]);
		}
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
		Singleton<NotificationManager>.instance.UpdateCardpoolNotifications();
	}

	private void OnClaimAssignmentMegaReward()
	{
		Debug.Log("BS: On Claim Assignment MegaReward");
		AssignmentsManager.instance.completedDaysAssignments = 0;
		OnAddReward(isMegaReward: true);
	}

	private void OnGetPlayerInfo()
	{
		Debug.Log("On Get PLayer Info");
		if (mResponse["PlayerInfo"] == null)
		{
			Debug.LogError("From server came null PlayerInfo!");
			return;
		}
		DatabasePlayer databasePlayer = DatabasePlayerInfo.CreateFromDatabase((JToken)mResponse["PlayerInfo"]);
		if (mResponse.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.squadWarsId = StringParser.ParseString(mResponse["SquadWarsId"], string.Empty);
		}
		Singleton<ServerResultsCache>.instance.Insert<DatabasePlayerInfo>("playerInfo" + databasePlayer.id, databasePlayer, DateTime.Now.AddMinutes(1.0));
	}

	private void OnWarpathShown()
	{
		PlayerAnalytics.instance.data.warpathShown = true;
	}

	private void OnSendLog()
	{
		Singleton<Logs>.instance.logsSent = true;
		Singleton<Logs>.instance.logId = mResponse["LogId"].ToString();
		Debug.Log("Beanstalk: Log Sent, Id = " + mResponse["LogId"]);
	}

	private void OnSendSettings()
	{
		Debug.Log("Beanstalk: On Send Settings");
	}

	private void OnRemoveLogin()
	{
		LoadingDialog.Hide();
		Debug.Log("Beanstalk: On Remove Login");
		AccountType accountType = (AccountType)StringParser.ParseInt(mResponse["AccountType"]);
		string playerName = StringParser.ParseString(mResponse["Name"], string.Empty);
		string newGuestPassword = string.Empty;
		string newGuestId = string.Empty;
		if (accountType == AccountType.Guest)
		{
			newGuestPassword = StringParser.ParseString(mResponse["guestPassword"], string.Empty);
			newGuestId = StringParser.ParseString(mResponse["guestId"], string.Empty);
		}
		GameLoginManager.instance.RemoveLoginData(accountType, playerName, newGuestPassword, newGuestId);
	}

	private void OnCardpoolShown()
	{
		Debug.Log("Card pool shown!!");
		PlayerAnalytics.instance.data.cardpoolShown = true;
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
	}

	private void OnCraftingShown()
	{
		Debug.Log("New Feature - Crafting shown!!");
		PlayerAnalytics.instance.data.craftingShown = true;
	}

	private void OnChatShownFirstTime()
	{
		PlayerAnalytics.instance.data.chatShown = true;
	}

	private void OnCustomizationShown()
	{
		PlayerAnalytics.instance.data.customizationShown = true;
	}

	private void OnDebugChangeMedals()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(currentPlayer.beginnersLeague, currentPlayer.leagueId, StringParser.ParseInt(mResponse["Medals"]), StringParser.ParseInt(mResponse["MedalsBalance"]), currentPlayer.remainingMatches);
	}

	private void OnDebugChangeDivision()
	{
		Debug.LogError("division changed!!!");
		if (mResponse.ContainsKey("Squad"))
		{
			OnGetSquadDetails();
		}
	}

	private void OnDebugChangeLeague()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string league = ((!mResponse.ContainsKey("leagueId")) ? currentPlayer.leagueId : StringParser.ParseString(mResponse["leagueId"], string.Empty));
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(0, league, currentPlayer.skill, 0, 0);
	}

	private void OnAddOneTimeReward()
	{
		Debug.Log("Beanstalk: On Add One Time Reward");
		if (!mResponse.ContainsKey("RewardId"))
		{
			return;
		}
		string text = StringParser.ParseString(mResponse["RewardId"], string.Empty);
		PlayerAnalytics.instance.AddOneTimeReward(text);
		bool flag = text == "WeaponTutorial";
		bool flag2 = text == "UnitTutorial";
		bool flag3 = flag || flag2;
		bool flag4 = mResponse.ContainsKey("WasAdded");
		Debug.Log("One Time Reward: " + ((!flag4) ? "not added, called already!!" : "was added"));
		Debug.Log(string.Concat("ADDED GOLD ", mResponse["Gold"], " for ", text));
		long num = StringParser.ParseLong(mResponse["Gold"], 0L);
		long num2 = 0L;
		if (flag4)
		{
			Singleton<Wallet>.instance.AddGoldReward(num, !flag3);
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY;
			if (!flag3 && num > 0 && text != dBKEY)
			{
				Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, num));
			}
		}
		if (mResponse.ContainsKey("WarBucks"))
		{
			Debug.Log(string.Concat("ADDED WB ", mResponse["WarBucks"], " for ", text));
			num2 = StringParser.ParseLong(mResponse["WarBucks"], 0L);
			if (flag4)
			{
				Singleton<Wallet>.instance.AddWarBucksReward(num2, !flag3);
			}
		}
		if (flag)
		{
			TutorialManagerStage4.instance.RewardCame((int)num2, (int)num);
		}
		if (flag2)
		{
			TutorialManagerStage5.instance.RewardCame((int)num2, (int)num);
		}
	}

	private void OnInformSquadLeaderAboutEvent()
	{
		Debug.Log("BS: Squad Leader was informed about event!");
	}

	private void OnAddReward(bool isMegaReward)
	{
		Debug.Log("BS: On add video reward success!");
		if (mResponse.ContainsKey("CardsInCardPack"))
		{
			Debug.Log("REWARD CARDPACK: " + mResponse["CardsInCardPack"]);
			JArray jArray = (JArray)mResponse["CardsInCardPack"];
			CardPack cardPack = ((!mResponse.ContainsKey("IsGold")) ? CardPack.Silver : CardPack.Gold);
			Card[] array = new Card[jArray.Count];
			int num = 0;
			foreach (JToken item in jArray)
			{
				string cardId = item.ToObject<string>();
				array[num] = CardManager.instance.GetCardInstance(cardId);
				num++;
				CardManager.instance.AddCard(cardId);
			}
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.CardPack, cardPack, array));
		}
		if (mResponse.ContainsKey("AddedCards"))
		{
			Debug.Log("REWARD CARD: " + mResponse["AddedCards"]);
			JArray jArray2 = (JArray)mResponse["AddedCards"];
			JToken card = null;
			foreach (JToken item2 in jArray2)
			{
				card = item2;
				CardManager.instance.AddCard(item2.ToObject<string>());
			}
			GuiScreenSingle<CardMenuScreen>.instance.UpdateHeaderAndCards();
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.WarCard, card));
		}
		if (mResponse.ContainsKey("DogTagSeconds") && mResponse.ContainsKey("DogTagLastUpdate"))
		{
			int dtSeconds = StringParser.ParseInt(mResponse["DogTagSeconds"]);
			int dtLastUpdate = StringParser.ParseInt(mResponse["DogTagLastUpdate"]);
			Singleton<DogTagManager>.instance.UpdateDogtags(dtSeconds, dtLastUpdate);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Dogtag));
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.WatchAdDogTag);
		}
		if (mResponse.ContainsKey("Tickets"))
		{
			long num2 = StringParser.ParseLong(mResponse["Tickets"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Tickets, num2));
			Singleton<EventTrackingManager>.instance.TicketsGained((!isMegaReward) ? "GoldenSuitcase" : "MegaReward", (int)num2);
			Singleton<Wallet>.instance.AddTickets(num2);
		}
		if (mResponse.ContainsKey("Scraps"))
		{
			long num3 = StringParser.ParseLong(mResponse["Scraps"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Scraps, num3));
			Singleton<EventTrackingManager>.instance.ScrapsGained((!isMegaReward) ? "GoldenSuitcase" : "MegaReward", (int)num3);
			Singleton<Wallet>.instance.AddScraps(num3);
		}
		if (mResponse.ContainsKey("WarBucks"))
		{
			long amount = StringParser.ParseLong(mResponse["WarBucks"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Warbucks, amount));
			Singleton<Wallet>.instance.AddWarBucksReward(amount);
		}
		if (mResponse.ContainsKey("Gold"))
		{
			long num4 = StringParser.ParseLong(mResponse["Gold"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, num4));
			Singleton<Wallet>.instance.AddGoldReward(num4);
		}
		if (mResponse.ContainsKey("addedVIP"))
		{
			long amount2 = StringParser.ParseLong(mResponse["addedVIP"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.VIP, amount2));
			Singleton<VipManager>.instance.vipExpiration = StringParser.ParseInt(mResponse["Vip"]);
			Singleton<VipManager>.instance.vipStart = StringParser.ParseInt(mResponse["VipStart"]);
			if (mResponse.ContainsKey("VipReward1"))
			{
				Debug.Log("response contain VipReward");
				string text = StringParser.ParseString(mResponse["VipReward1"], string.Empty);
				string text2 = StringParser.ParseString(mResponse["VipReward2"], string.Empty);
				string dayString = "a";
				if (mResponse.ContainsKey("VipRewardForDay"))
				{
					dayString = StringParser.ParseString(mResponse["VipRewardForDay"], string.Empty);
				}
				Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(text, text2, dayString));
				CardManager.instance.AddCard(text);
				CardManager.instance.AddCard(text2);
			}
		}
		if (mResponse.ContainsKey("addPowerbandTime"))
		{
			long time = StringParser.ParseLong(mResponse["addPowerbandTime"], 0L);
			string text3 = StringParser.ParseString(mResponse["Id"], string.Empty);
			int expiresOn = StringParser.ParseInt(mResponse["ExpiresOn"]);
			PlayerVisual powerBand = CamosManager.instance.GetPowerBand(text3);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.PowerBand, powerBand, time));
			powerBand.Buy();
			CamosManager.instance.data.visuals[text3].expiresOn = expiresOn;
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(powerBand);
		}
		if (mResponse.ContainsKey("NewVisuals"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(StringParser.ParseString(mResponse["NewVisuals"], string.Empty));
			if (dictionary != null)
			{
				if (GuiScreenSingle<EndScreen>.instance.isShowed && GuiScreenSingle<EndScreen>.instance.isEndScreenLootboxAnimations)
				{
					GuiScreenSingle<EndScreen>.instance.videoRewardLootbox = LootboxContent.getLootboxes(dictionary);
					if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
					{
						WaitingDialog.Hide();
					}
				}
				else
				{
					Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Lootboxes, LootboxContent.getLootboxes(dictionary)));
				}
			}
			Debug.Log("Video ad reward - lootbox visuals List =  " + mResponse["NewVisuals"]);
		}
		if (mResponse.ContainsKey("videoAdRewardTimes"))
		{
			Singleton<EventTrackingManager>.instance.getAdlimits((JToken)mResponse["videoAdRewardTimes"]);
		}
	}

	private void OnAcceptSquadJoinRequest()
	{
		Debug.Log("BS: player succesfully accepted to squad");
		if (mResponse.ContainsKey("joinedPlayer"))
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)mResponse["joinedPlayer"]);
			Singleton<ServerResultsCache>.instance.AddPlayerAfterAcceptJoin(databasePlayer);
			Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(databasePlayer.id, updateGUI: false);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(currentPlayer.squadName, forceUpdate: true);
	}

	private void OnGetFullSquadInfo()
	{
		Debug.Log("BS: On Get Full Squad Info");
		if (mResponse.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.squadWarsId = StringParser.ParseString(mResponse["SquadWarsId"], string.Empty);
		}
		OnGetSquadDetails();
		OnGetAllSquadMembers();
	}

	private void OnChangeLanguage()
	{
		Debug.Log("BS: On change language.");
		WaitingDialog.Hide();
		if (DebugSettings.debugEnabled)
		{
			Application.Quit();
		}
	}

	private void OnSendPlayerReport()
	{
		Debug.Log("BS: Player report sent!" + mResponse["Reported"]);
	}

	private void OnReportCheater()
	{
		Debug.LogError("BS: Cheater report sent! PlayerID = " + mResponse["PlayerID"]);
	}

	private void OnPhotonIsFull()
	{
		Debug.Log("Beanstalk: Photon Is Full sent");
	}

	private void OnSendCrashReport()
	{
		Debug.Log("Beanstalk: Crash Report Succesfully Sent");
	}

	private void OnUpdateRegionPings()
	{
	}

	private void OnChangePlayerName()
	{
		LoadingDialog.Hide();
		Debug.Log("Beanstalk: On Change Name");
		if (StringParser.ParseInt(mResponse["PayForRename"]) == 1)
		{
			Singleton<Wallet>.instance.GoldSpent(PlayerAnalytics.instance.renameGoldPrice);
		}
		PlayerAnalytics.instance.data.renameCount = StringParser.ParseInt(mResponse["RenameCount"]);
		GameLoginManager.instance.SavePlayerName(StringParser.ParseString(mResponse["Name"], string.Empty));
	}

	private void OnAcceptSpecialOffer()
	{
		Debug.LogError("On Accept Special Offer");
		JArray jArray = JsonConvert.DeserializeObject<JArray>(StringParser.ParseString(mResponse["RequestsResults"], string.Empty));
		string text = string.Empty;
		int num = jArray.Count - 1;
		for (int i = 0; i < jArray.Count; i++)
		{
			JToken requestResult = jArray[i];
			text = ProcessBuffer(requestResult, text, i == num);
		}
		if (!string.IsNullOrEmpty(text))
		{
			WarningDialog.ShowError(string.Format("{0} {1}", Localization.Localize("ID_CONFIRM_SERVERCOULDNOTCOMPLETED"), text), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
		}
	}

	private void OnGenerateSpecialOffer()
	{
		Singleton<OfferManager>.instance.UpdateFromServer((!mResponse.ContainsKey("offers")) ? null : ((JToken)mResponse["offers"]));
	}

	private void DebugAddSquadLevel()
	{
		Debug.Log("On Level Squad Up");
		DatabaseSquad databaseSquad = DatabaseSquad.CreateFromDatabase((JToken)mResponse["Squad"]);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(databaseSquad);
		Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + databaseSquad.name, databaseSquad, DateTime.Now.AddMinutes(2.0));
	}

	private void OnJoinSquadRequest()
	{
		Debug.Log("Squad Request Sent!");
		GuiElementSingle<JoiningSquadDialog>.instance.requestSend = true;
	}

	private void OnUpdateSquad()
	{
		Debug.Log("Beanstalk: Update squad finished");
	}

	private void LoadPlayerData(JToken dictionary, bool executePlayerDataRoutines = true)
	{
		List<Card> list = null;
		Dictionary<string, CardManager.CardData> dictionary2 = null;
		if (Singleton<GameController>.instance.isTutorial)
		{
			list = new List<Card>(CardManager.instance.obtainedCards);
			Debug.Log("saved obtained cards: " + list.Count);
			Debug.Log("Cards on saved data: " + CardManager.instance.data.cardData.Count);
			dictionary2 = new Dictionary<string, CardManager.CardData>(CardManager.instance.data.cardData);
		}
		DatabaseSerializedObject.LoadObjects(dictionary);
		if (dictionary["Midnight"] != null)
		{
			int midnight = StringParser.ParseInt("Midnight", "N", dictionary);
			mServerTime.midnight = midnight;
		}
		int dtSeconds = StringParser.ParseInt("DogTagSeconds", "N", dictionary);
		int dtLastUpdate = StringParser.ParseInt("DogTagLastUpdate", "N", dictionary);
		int dtMax = StringParser.ParseInt("DogTagMax", "N", dictionary);
		Singleton<DogTagManager>.instance.UpdateDogtags(dtSeconds, dtLastUpdate, dtMax);
		if (dictionary["TutorialData"] != null)
		{
			PlayerAnalytics.instance.tutorialFinished = true;
			if (Singleton<GameController>.instance.isTutorial)
			{
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				Singleton<GameController>.instance.StopAllTutorials();
			}
			if (GuiElementSingle<TutorialDialog>.instance.isShowed)
			{
				GuiElementSingle<TutorialDialog>.instance.HideDialog();
			}
		}
		mTutorialAlreadyInProgress = Singleton<GameController>.instance.isTutorial;
		if (mTutorialAlreadyInProgress)
		{
			Debug.Log("adding cards: " + list.Count);
			if (list != null)
			{
				CardManager.instance.obtainedCards.AddRange(list);
			}
			if (dictionary2 != null)
			{
				CardManager.instance.data.cardData = new Dictionary<string, CardManager.CardData>(dictionary2);
			}
			Debug.Log("Cards on saved data: " + CardManager.instance.data.cardData.Count);
			TutorialManagerStage1.instance.CheckAfterDownload();
			TutorialManagerStage2.instance.CheckAfterDownload();
			return;
		}
		long initGold = StringParser.ParseLong("Gold", "N", dictionary);
		long initWarBucks = StringParser.ParseLong("WarBucks", "N", dictionary);
		int level = StringParser.ParseInt("Level", "N", dictionary);
		int loadedLevelExperience = StringParser.ParseInt("LevelExperience", "N", dictionary);
		long loadedExperience = StringParser.ParseLong("Experience", "N", dictionary);
		int loadedArmyPower = StringParser.ParseInt("ArmyPower", "N", dictionary);
		Singleton<VipManager>.instance.vipExpiration = ((dictionary["Vip"] != null) ? StringParser.ParseInt("Vip", "N", dictionary) : 0);
		Singleton<VipManager>.instance.vipStart = ((dictionary["VipStart"] != null) ? StringParser.ParseInt("VipStart", "N", dictionary) : 0);
		Singleton<VipManager>.instance.LoadNewPlayer();
		LevelManager.instance.LoadData(level, loadedLevelExperience, loadedExperience, loadedArmyPower);
		Singleton<Wallet>.instance.Init(initGold, initWarBucks);
		if (dictionary["Tickets"] != null)
		{
			long newTickets = StringParser.ParseLong("Tickets", "N", dictionary);
			Singleton<Wallet>.instance.InitTickets(newTickets);
		}
		if (dictionary["Scraps"] != null)
		{
			long newScraps = StringParser.ParseLong("Scraps", "N", dictionary);
			Singleton<Wallet>.instance.InitScraps(newScraps);
		}
		if (PlayerAnalytics.instance.data.squadCreationsCount > 0)
		{
			PlayerAnalytics.instance.data.squadCreationsCount--;
		}
		if (PlayerAnalytics.instance.data.matchesToNextLootboxes == 0)
		{
			PlayerAnalytics.instance.data.matchesToNextLootboxes = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
		}
		Debug.Log($"Loaded values during loading data from PlayerAnalytics : lastSeenSquadChatTimeStampDB = {PlayerAnalytics.instance.data.lastSeenSquadChatTimeStampDB}, squadCreationsCount = {PlayerAnalytics.instance.data.squadCreationsCount}, matchesToNextLootboxes = {PlayerAnalytics.instance.data.matchesToNextLootboxes}");
		if (dictionary["SendLogs"] != null)
		{
			GameLoginManager.currentPlayer.sendLogsValue = StringParser.ParseInt("SendLogs", "N", dictionary);
		}
		if (dictionary["Position"] != null)
		{
			PlayerAnalytics.instance.globalPositon = StringParser.ParseInt("Position", "N", dictionary);
		}
		if (dictionary["battlesLostInRow"] != null)
		{
			StatsManager.instance.battlesLostInRow = StringParser.ParseInt("battlesLostInRow", "N", dictionary);
		}
		if (dictionary["videoAdRewardTimes"] != null)
		{
			JToken item = (JToken)JsonConvert.DeserializeObject(StringParser.ParseString(dictionary["videoAdRewardTimes"]["S"], string.Empty), typeof(JToken));
			Singleton<EventTrackingManager>.instance.getAdlimits(item);
		}
		Singleton<BeanstalkServerManager>.instance.PlayerDataWasLoaded(executePlayerDataRoutines);
		if (dictionary["FacebookName"] != null)
		{
			GameLoginManager.instance.facebookName = dictionary["FacebookName"]["S"].ToString();
		}
	}

	private void OnAcceptChallenge()
	{
		Debug.Log("On Accept Challenge");
	}

	private void OnAddGameCenter()
	{
		Debug.Log("Beanstalk: On Add GameCenter");
		string gameCenterId = StringParser.ParseString(mResponse["GameCenterId"], string.Empty);
		GameLoginManager.instance.SaveGameCenterData(gameCenterId);
	}

	private void OnCheckExistFbAccount(DatabaseResult result)
	{
		switch (result)
		{
		case DatabaseResult.Success:
			Debug.Log("no account in DB, ask to create new one");
			ConfirmDialog.ShowChoice(Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TITLE"), Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT1"), delegate(ConfirmDialog c, bool b)
			{
				if (b)
				{
					Debug.Log("create new account and add FB");
					DialogManager.instance.HideAllDialogs();
					StatsManager.instance.dailyRewardData = null;
					GameLoginManager.instance.DeletePlayerAccount();
					GameLoginManager.instance.CreateNewAccount(gamecenter: false);
				}
				else
				{
					Debug.Log("logout from FB");
					GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
					LoadingDialog.Hide();
				}
			}, Localization.Localize("ID_CREATE"), Localization.Localize("ID_LOGOUT"));
			break;
		case DatabaseResult.AccountAlreadyCreated:
		{
			string facebookId = StringParser.ParseString(mResponse["FacebookId"], string.Empty);
			string userName = StringParser.ParseString(mResponse["FacebookName"], string.Empty);
			string facebookPassword = StringParser.ParseString(mResponse["FacebookPassword"], string.Empty);
			int userLevel = StringParser.ParseInt(mResponse["facebookLevel"]);
			int userMedals = StringParser.ParseInt(mResponse["facebookMedals"]);
			LoadingDialog.Hide();
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.Facebook, delegate(bool flag)
			{
				if (flag)
				{
					GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
				}
				else
				{
					DialogManager.instance.HideAllDialogs();
					StatsManager.instance.dailyRewardData = null;
					Singleton<MessageManager>.instance.ClearAllMessages();
					GameLoginManager.instance.acountDataDownloadingInProgress = true;
					GameLoginManager.instance.DeletePlayerAccount();
					Singleton<BeanstalkServerManager>.instance.Login(facebookId, facebookPassword, AccountType.Facebook);
				}
			}, userName, userLevel, userMedals, Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT2"));
			break;
		}
		case (DatabaseResult)2:
		case DatabaseResult.SameFacebookAlreadyCreated:
			break;
		}
	}

	private void OnAddServiceProvider(DatabaseResult result, Constants.rowIds loginReward, AccountType accountType, string prefix)
	{
		LoadingDialog.Hide();
		switch (result)
		{
		case DatabaseResult.Success:
			Debug.Log("Beanstalk: Add Service Provider Success");
			if (mResponse.ContainsKey("Gold"))
			{
				long num = StringParser.ParseLong(mResponse["Gold"], 0L);
				Singleton<Wallet>.instance.AddGoldReward(num);
				Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, num));
				string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(loginReward).DBKEY;
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
			GameLoginManager.instance.SaveLoginData(StringParser.ParseString(mResponse[prefix + "Id"], string.Empty), StringParser.ParseString(mResponse[prefix + "Name"], string.Empty), StringParser.ParseString(mResponse[prefix + "Password"], string.Empty), accountType);
			Singleton<GuiManager>.instance.ShowMainScreen();
			if (mResponse.ContainsKey("Vip") && mResponse.ContainsKey("VipStart"))
			{
				Singleton<VipManager>.instance.vipExpiration = StringParser.ParseInt(mResponse["Vip"]);
				Singleton<VipManager>.instance.vipStart = StringParser.ParseInt(mResponse["VipStart"]);
			}
			if (mResponse.ContainsKey("VipReward1"))
			{
				Debug.Log("response contain VipReward");
				string text = StringParser.ParseString(mResponse["VipReward1"], string.Empty);
				string text2 = StringParser.ParseString(mResponse["VipReward2"], string.Empty);
				string dayString = "a";
				if (mResponse.ContainsKey("VipRewardForDay"))
				{
					dayString = StringParser.ParseString(mResponse["VipRewardForDay"], string.Empty);
				}
				Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(text, text2, dayString));
				CardManager.instance.AddCard(text);
				CardManager.instance.AddCard(text2);
			}
			break;
		case DatabaseResult.AccountAlreadyCreated:
		{
			Debug.Log("Beanstalk: That account already exists! Player will choose how to proceed, provider = " + prefix);
			string id = StringParser.ParseString(mResponse[prefix + "Id"], string.Empty);
			string userName = StringParser.ParseString(mResponse[prefix + "Name"], string.Empty);
			string password = StringParser.ParseString(mResponse[prefix + "Password"], string.Empty);
			int userLevel = StringParser.ParseInt(mResponse[prefix + "Level"]);
			int userMedals = StringParser.ParseInt(mResponse[prefix + "Medals"]);
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(accountType, delegate(bool dialogResult)
			{
				if (dialogResult)
				{
					Debug.Log("Player chose to stay on his account");
					switch (accountType)
					{
					case AccountType.Facebook:
						GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
						break;
					case AccountType.GooglePlay:
						GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
						break;
					case AccountType.GameCenter:
						break;
					}
				}
				else
				{
					Debug.Log("Player chose to switch accounts");
					DialogManager.instance.HideAllDialogs();
					StatsManager.instance.dailyRewardData = null;
					Singleton<MessageManager>.instance.ClearAllMessages();
					GameLoginManager.instance.acountDataDownloadingInProgress = true;
					Singleton<BeanstalkServerManager>.instance.Login(id, password, accountType);
				}
			}, userName, userLevel, userMedals, string.Empty);
			break;
		}
		case (DatabaseResult)2:
		case DatabaseResult.SameFacebookAlreadyCreated:
			break;
		}
	}

	private static string GetTransactionId(List<Tuple<string, string>> postData)
	{
		for (int i = 0; i < postData.Count; i++)
		{
			if (postData[i].Value1 == "OrderId" || postData[i].Value1 == "IosTransactionId")
			{
				return postData[i].Value2;
			}
		}
		return null;
	}

	private void OnBuyInApp(List<Tuple<string, string>> postData)
	{
		Debug.Log("In App Delivered");
		WaitingDialog.Hide();
		string text = StringParser.ParseString(mResponse["Id"], string.Empty);
		string type = "Warbucks";
		if (mResponse.ContainsKey("Gold"))
		{
			long num = StringParser.ParseLong(mResponse["Gold"], 0L);
			Singleton<Wallet>.instance.AddGoldBought(num);
			type = "Gold";
			if (mResponse.ContainsKey("IsDaily"))
			{
				Singleton<BeanstalkServerManager>.instance.inAppDataManager.AddDailyGoldBooster();
				string id = text + mServerTime.GetCurrentTimestamp();
				Singleton<MessageManager>.instance.AddMessage(new DailyGoldBoosterMessage(num, 0, id));
			}
			Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, (int)num);
		}
		if (mResponse.ContainsKey("Warbucks"))
		{
			long num2 = StringParser.ParseLong(mResponse["Warbucks"], 0L);
			Singleton<Wallet>.instance.AddWarbucksBought(num2);
			Singleton<EventTrackingManager>.instance.RegisterWBIn(text, (int)num2);
		}
		Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(text);
		bool isFirstTime = PlayerAnalytics.instance.data.GetInappCount() == 0;
		Singleton<EventTrackingManager>.instance.RegisterInapp(text, isFirstTime, type);
		string itemCurrencyCode = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemCurrencyCode(text);
		Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, itemPrice.Value1, type, itemCurrencyCode);
		Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, itemPrice.Value1, type, itemCurrencyCode);
		PlayerAnalytics.instance.AddTransaction(142, text, 0, 0, itemPrice.Value1);
		Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, itemPrice.Value1, itemPrice.Value2, GetTransactionId(postData), itemCurrencyCode);
		Singleton<EventTrackingManager>.instance.RegisterInApp(text, itemPrice.Value1, itemPrice.Value2, GetTransactionId(postData), itemCurrencyCode);
		ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_THANKYOU"), Localization.Localize("ID_CONFIRM_THANKYOUPURCHASE"), 0f);
		DialogManager.instance.ShowRateAppDialog(showAfterBattle: false);
	}

	private void OnBuyPack(List<Tuple<string, string>> postData)
	{
		LoadingDialog.Hide();
		WaitingDialog.Hide();
		LoadPlayerData((JToken)mResponse["PlayerData"], executePlayerDataRoutines: false);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.CoinPurchase);
		if (mResponse.ContainsKey("PackId"))
		{
			string text = (string)mResponse["PackId"];
			Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(text);
			PlayerAnalytics.instance.AddTransaction(130, text, 0, 0, itemPrice.Value1);
			if (!mResponse.ContainsKey("IsRestore"))
			{
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_THANKYOU"), Localization.Localize("ID_CONFIRM_THANKYOUPURCHASE"), 0f);
				string itemCurrencyCode = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemCurrencyCode(text);
				Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, itemPrice.Value1, "Pack", itemCurrencyCode);
				Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, itemPrice.Value1, "Pack", itemCurrencyCode);
				Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, itemPrice.Value1, itemPrice.Value2, GetTransactionId(postData), itemCurrencyCode);
				Singleton<EventTrackingManager>.instance.RegisterInApp(text, itemPrice.Value1, itemPrice.Value2, GetTransactionId(postData), itemCurrencyCode);
				Singleton<EventTrackingManager>.instance.RegisterBuyPackEvent(text);
				string buyOfferEventLocation = Singleton<BeanstalkServerManager>.instance.GetBuyOfferEventLocation();
				if (!string.IsNullOrEmpty(buyOfferEventLocation))
				{
					Singleton<EventTrackingManager>.instance.RegisterBuyOfferEventLocation(buyOfferEventLocation, text);
				}
				int packGold = Singleton<GameVariables>.instance.GetPackGold(text);
				int packWarbucks = Singleton<GameVariables>.instance.GetPackWarbucks(text);
				if (packGold > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, packGold);
				}
				if (packWarbucks > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterWBIn(text, packWarbucks);
				}
				DialogManager.instance.ShowRateAppDialog(showAfterBattle: false);
			}
			if (text == Singleton<GameVariables>.instance.PackId(CardPack.Starter))
			{
				Singleton<MessageManager>.instance.AddMessage(new WeaponTutorialDialogMessage(LevelManager.instance.Minigun()));
			}
		}
		if (mResponse.ContainsKey("VipReward1"))
		{
			Debug.Log("response contain VipReward");
			string text2 = StringParser.ParseString(mResponse["VipReward1"], string.Empty);
			string text3 = StringParser.ParseString(mResponse["VipReward2"], string.Empty);
			string dayString = "a";
			if (mResponse.ContainsKey("VipRewardForDay"))
			{
				dayString = StringParser.ParseString(mResponse["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(text2, text3, dayString));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
	}

	private void OnBuyLootboxes()
	{
		List<LootboxContent> lootboxes = new List<LootboxContent>();
		if (mResponse.ContainsKey("NewVisuals"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(StringParser.ParseString(mResponse["NewVisuals"], string.Empty));
			if (dictionary != null)
			{
				lootboxes = LootboxContent.getLootboxes(dictionary);
				GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(lootboxes, showVideoButton: false);
			}
		}
		string text = ((!mResponse.ContainsKey("Id")) ? string.Empty : StringParser.ParseString(mResponse["Id"], string.Empty));
		long num = ((!mResponse.ContainsKey("LootboxCost")) ? 0 : StringParser.ParseLong(mResponse["LootboxCost"], 0L));
		Debug.Log($"Lootbox id /{text}/ bought for /{num}/ gold");
		Singleton<EventTrackingManager>.instance.RegisterBuyLootboxes(text, lootboxes);
		Singleton<PurchaseProtection>.instance.LootboxResponseCame(text);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_Lootboxes", (int)num);
		Singleton<Wallet>.instance.GoldSpent(num);
	}

	private void OnDebugMaxAll()
	{
		LoadingDialog.Hide();
		LoadPlayerData((JToken)mResponse["PlayerData"], executePlayerDataRoutines: false);
		GuiScreenSingle<ArmyScreen>.instance.UpdateArmy();
		GuiScreenSingle<ArmyScreen>.instance.SendEquippedUnits();
	}

	private void OnDebugAddGoodies()
	{
		Debug.Log("On Debug add Goodies");
		LoadingDialog.Hide();
		LoadPlayerData((JToken)mResponse["PlayerData"], executePlayerDataRoutines: false);
		GuiScreenSingle<ArmyScreen>.instance.UpdateArmy();
	}

	private void OnBuyVip()
	{
		Debug.Log("VIP bought");
		Singleton<VipManager>.instance.vipExpiration = StringParser.ParseInt(mResponse["Vip"]);
		Singleton<VipManager>.instance.vipStart = StringParser.ParseInt(mResponse["VipStart"]);
		long num = StringParser.ParseLong(mResponse["Gold"], 0L);
		string text = StringParser.ParseString(mResponse["Id"], string.Empty);
		Singleton<EventTrackingManager>.instance.RegisterBuyVipEvent(text, (int)num);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_VIP", (int)num);
		Singleton<PurchaseProtection>.instance.VIPResponseCame(text);
		Singleton<Wallet>.instance.GoldSpent(num);
		if (mResponse.ContainsKey("VipReward1"))
		{
			Debug.Log("response contain VipReward");
			string text2 = StringParser.ParseString(mResponse["VipReward1"], string.Empty);
			string text3 = StringParser.ParseString(mResponse["VipReward2"], string.Empty);
			string dayString = "a";
			if (mResponse.ContainsKey("VipRewardForDay"))
			{
				dayString = StringParser.ParseString(mResponse["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(text2, text3, dayString));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		PlayerAnalytics.instance.AddTransaction(114, Singleton<VipManager>.instance.vipExpiration.ToString(CultureInfo.InvariantCulture), (int)num, 0, 0f);
	}

	private void OnCheckUniqueSquadName()
	{
		bool flag = StringParser.ParseBool(mResponse["IsUnique"]);
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded((!flag) ? DatabaseAction.UniqueSquadNameFailure : DatabaseAction.UniqueSquadNameSuccess);
	}

	private void OnClaimReward()
	{
		long num = StringParser.ParseLong(mResponse["Gold"], 0L);
		long num2 = StringParser.ParseLong(mResponse["Warbucks"], 0L);
		Singleton<Wallet>.instance.AddMoneyReward(num, num2);
		if (num > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", (int)num);
		}
		if (num2 > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterWBIn("Claim_Reward", (int)num2);
		}
		if (!mResponse.ContainsKey("Rewards"))
		{
			return;
		}
		Debug.LogError("GOT REWARDS!!");
		foreach (JToken item in (JArray)mResponse["Rewards"])
		{
			StatsManager.instance.ParseReward(item);
		}
	}

	private void OnCheckExistGcAccount()
	{
		Debug.Log("GC account checked and have response!");
		StringBuilder stringBuilder = new StringBuilder("response\n");
		foreach (KeyValuePair<string, object> item in mResponse)
		{
			stringBuilder.AppendFormat("{0} - {1}\n", item.Key, item.Value);
		}
		Debug.Log(stringBuilder.ToString());
		if (mResponse.ContainsKey("resultMessage"))
		{
			string text = mResponse["resultMessage"].ToString();
			Debug.Log("OnCheckExistGcAccount - " + text);
			if (text == "OK")
			{
				Debug.Log("GC account exist");
				if (mResponse.ContainsKey("GameCenterId"))
				{
					GameLoginManager.instance.OnGamecenterUserExistDuringTutorial(mResponse["GameCenterId"].ToString());
				}
			}
		}
		else
		{
			Debug.LogError("Check if gc account exist result NOT contain result message");
		}
	}

	private void OnGCUpdated()
	{
		AccountType accountType = AccountType.Guest;
		if (mResponse.ContainsKey("AccountType"))
		{
			accountType = (AccountType)StringParser.ParseInt(mResponse["AccountType"]);
		}
		bool flag = false;
		if (mResponse.ContainsKey("Added") && mResponse.ContainsKey("gcID") && mResponse.ContainsKey("gcPassword"))
		{
			flag = StringParser.ParseBool(mResponse["Added"]);
		}
		if (flag)
		{
			string id = StringParser.ParseString(mResponse["gcID"], string.Empty);
			string password = StringParser.ParseString(mResponse["gcPassword"], string.Empty);
			GameLoginManager.instance.UpdatePlayerByGC(id, password, accountType);
		}
		else
		{
			if (accountType == AccountType.GameCenter)
			{
				Debug.LogError("after update GC still GC account, but no added or missing gcID or gcPassword");
			}
			GameLoginManager.instance.UpdatePlayerByGC(string.Empty, string.Empty, accountType);
		}
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
	}

	private void OnCreateAccount()
	{
		DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)mResponse["Player"]);
		AccountType accountType = AccountType.Guest;
		if (mResponse.ContainsKey("AccountType"))
		{
			accountType = (AccountType)StringParser.ParseInt(mResponse["AccountType"]);
		}
		string id = databasePlayer.id;
		switch (accountType)
		{
		case AccountType.Facebook:
			id = databasePlayer.facebookId.ToString();
			break;
		case AccountType.GameCenter:
			id = databasePlayer.gameCenterId;
			break;
		}
		GameLoginManager.instance.SavePlayer(databasePlayer, id, StringParser.ParseString(mResponse["Token"], string.Empty), StringParser.ParseString(mResponse["Password"], string.Empty), accountType);
		LoadPlayerData((JToken)mResponse["PlayerData"]);
		if (mResponse.ContainsKey("UseOnGetPlayerData"))
		{
			OnGetPlayerData();
			return;
		}
		if (mResponse.ContainsKey("WarArenaConfig"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)mResponse["WarArenaConfig"]);
			Debug.LogError("WAR ARENA CONFIG RECEIVED! Id = " + WarArena.instance.warArenaConfig.id);
			if (mResponse.ContainsKey("ShowArenaDialog"))
			{
				string id2 = WarArena.instance.warArenaConfig.id;
				bool isOpened = WarArena.instance.isOpened;
				Singleton<MessageManager>.instance.AddMessage(new ArenaOpenedMessage(id2, isOpened));
			}
		}
		else
		{
			Debug.LogError("NO WAR ARENA CONFIG!!!");
		}
		mServerTime.Init(StringParser.ParseInt(mResponse["Time"]));
		if (mResponse.ContainsKey("LeagueEvaluation"))
		{
			mServerTime.InitNextLeagueEvaluation(StringParser.ParseInt(mResponse["LeagueEvaluation"]));
			LeagueArcManager.instance.SetLeagueTimer(mServerTime.nextLeagueEvaluation);
			GuiScreenSingle<MainScreen>.instance.bottomLeaguePlayers.leagueEnding.SetLeagueEnd(mServerTime.nextLeagueEvaluation);
		}
		Singleton<BeanstalkServerManager>.instance.GetAllMessages();
		if (mResponse.ContainsKey("MaintenanceMessage"))
		{
			Debug.LogError("GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT");
			DatabaseMessage databaseMessage = DatabaseMessage.CreateFromDatabase((JToken)mResponse["MaintenanceMessage"]);
			if (databaseMessage != null)
			{
				Singleton<MessageManager>.instance.AddMessage(databaseMessage);
			}
		}
		if (mResponse.ContainsKey("BattleId") && !mTutorialAlreadyInProgress)
		{
			DialogManager.instance.HideAllDialogs();
			Debug.Log("GameController: Starting tutorial");
			Singleton<GameController>.instance.battleId = StringParser.ParseString(mResponse["BattleId"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		else
		{
			Debug.Log("Show Loadout After Create Account");
			Debug.LogWarning("Get player data: I WILL TRY TO SEND PN DEVICE TOKEN");
			if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
			{
				Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
				PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
			}
		}
		mTutorialAlreadyInProgress = false;
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
	}

	private void OnBuyArenaHeart()
	{
		Debug.LogError("OnBuyArenaHeart!");
		int num = 0;
		int num2 = 0;
		if (mResponse.ContainsKey("ArenaLives"))
		{
			WarArena.instance.UpdateLives(StringParser.ParseInt(mResponse["ArenaLives"]));
		}
		if (mResponse.ContainsKey("ticketsSpent"))
		{
			num = StringParser.ParseInt(mResponse["ticketsSpent"]);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (mResponse.ContainsKey("goldSpent"))
		{
			num2 = StringParser.ParseInt(mResponse["goldSpent"]);
			Singleton<Wallet>.instance.GoldSpent(num2);
		}
		Singleton<EventTrackingManager>.instance.BuyHeart(num, num2, WarArena.instance.data.wins);
	}

	private void OnTakeArenaHearth()
	{
		Debug.LogError("Take arena life!");
		if (mResponse.ContainsKey("ArenaLives"))
		{
			WarArena.instance.UpdateLives(StringParser.ParseInt(mResponse["ArenaLives"]));
			if ((int)WarArena.instance.data.lives <= 0)
			{
				OnArenaEnded();
			}
		}
	}

	private void OnCreateSquad()
	{
		GameLoginManager.instance.AddPlayerToSquad(StringParser.ParseString(mResponse["SquadId"], string.Empty), (SquadRank)StringParser.ParseInt(mResponse["PlayerRank"]));
		DatabaseSquad databaseSquad = DatabaseSquad.CreateFromDatabase((JToken)mResponse["Squad"]);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(databaseSquad);
		Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + databaseSquad.name, databaseSquad, DateTime.Now.AddMinutes(2.0));
		if (mResponse.ContainsKey("squadCreationsCnt"))
		{
			PlayerAnalytics.instance.data.squadCreationsCount = StringParser.ParseInt(mResponse["squadCreationsCnt"]);
			Debug.LogError("PlayerAnalytics.instance.data.squadCreationsCount = " + PlayerAnalytics.instance.data.squadCreationsCount);
		}
		if (mResponse.ContainsKey("WarsEvaluation"))
		{
			mServerTime.InitNextWarsEvaluation(StringParser.ParseInt(mResponse["WarsEvaluation"]));
			Debug.Log("SHOWING WARS EVALUATION " + mServerTime.nextWarsEvaluation);
			GuiScreenSingle<LeaguesScreen>.instance.squadWars.ShowSquadWarEndTime(mServerTime.nextWarsEvaluation);
			GuiScreenSingle<MainScreen>.instance.bottomLeaguePlayers.leagueEnding.SetSquadWarsEnd(mServerTime.nextWarsEvaluation);
		}
		if (mResponse.ContainsKey("EventDefinition"))
		{
			Singleton<ServerResultsCache>.instance.squadEventDefinition = DatabaseSquadEventDefinition.CreateFromDatabase((JToken)mResponse["EventDefinition"]);
		}
	}

	private void OnDebugAddLevel()
	{
		Debug.Log("On Debug Add Level");
		LevelManager.instance.LoadData(StringParser.ParseInt(mResponse["Level"]), 0);
		LevelManager.instance.isLevelUp = true;
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.UpdateLevel();
		GuiElementSingle<MenuHeader>.instance.UpdateProgress();
	}

	private void OnDemotePlayer()
	{
		if (mResponse.ContainsKey("DemotedPlayer"))
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)mResponse["DemotedPlayer"]);
			Singleton<ServerResultsCache>.instance.UpdateSquadPlayer(databasePlayer);
			GuiScreenSingle<SquadScreen>.instance.memberContent.ServerResponseCame(DatabaseAction.DemotePlayer, databasePlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
	}

	private void OnKickPlayer()
	{
		if (mResponse.ContainsKey("Player"))
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)mResponse["Player"]);
			Singleton<ServerResultsCache>.instance.UpdateSquadPlayer(new DatabasePlayer
			{
				id = databasePlayer.id,
				squadRank = SquadRank.None
			});
			GuiScreenSingle<SquadScreen>.instance.memberContent.ServerResponseCame(DatabaseAction.KickPlayer, databasePlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
	}

	private void OnGameEnded(DatabaseAction databaseAction)
	{
		Debug.Log("can user send logs? " + GameLoginManager.currentPlayer.canPlayerSendLogs);
		Singleton<GameController>.instance.gameEndServerResponse = GameController.ServerResponse.Success;
		if (mResponse.ContainsKey("IsWarArena"))
		{
			OnArenaEnded();
		}
		else
		{
			OnClassicGameEnded(databaseAction);
		}
	}

	private void OnArenaEnded()
	{
		int flawless = WarArena.instance.data.flawless;
		int battles = WarArena.instance.warArenaConfig.battles;
		bool flag = false;
		StatsManager.instance.arenaBattles++;
		if (mResponse.ContainsKey("GameReward"))
		{
			Singleton<ServerResultsCache>.instance.lastGameReward = new DatabaseGameReward((JToken)mResponse["GameReward"]);
			LevelManager.instance.experience += Singleton<ServerResultsCache>.instance.lastGameReward.GetXpTotal();
		}
		if (mResponse.ContainsKey("ArenaLives"))
		{
			WarArena.instance.data.lives = StringParser.ParseInt(mResponse["ArenaLives"]);
		}
		if (mResponse.ContainsKey("ArenaWins"))
		{
			WarArena.instance.data.wins = StringParser.ParseInt(mResponse["ArenaWins"]);
		}
		if (mResponse.ContainsKey("TopRun"))
		{
			WarArena.instance.data.topRun = StringParser.ParseInt(mResponse["TopRun"]);
			Debug.LogError("NEW TOP RUN = " + WarArena.instance.data.topRun);
		}
		if (mResponse.ContainsKey("Flawless"))
		{
			WarArena.instance.data.flawless = StringParser.ParseInt(mResponse["Flawless"]);
			Debug.LogError("NEW FLAWLESS = " + WarArena.instance.data.flawless);
		}
		if (mResponse.ContainsKey("HeartDialog"))
		{
			Singleton<MessageManager>.instance.AddMessage(new BuyHearthArenaMessage(WarArena.instance.warArenaConfig.id));
		}
		if (mResponse.ContainsKey("Lootbox"))
		{
			Debug.LogError("RECEIVED LOOTBOX");
			WarArena.instance.lastLootboxReward = new WararenaLootboxReward((JToken)mResponse["Lootbox"]);
			Singleton<EventTrackingManager>.instance.ArenaLootbox(WarArena.instance.data.wins, WarArena.instance.lastLootboxReward);
			StatsManager.instance.arenaLootboxes++;
		}
		else
		{
			WarArena.instance.lastLootboxReward = null;
		}
		if (mResponse.ContainsKey("Scraps"))
		{
			int num = StringParser.ParseInt(mResponse["Scraps"]);
			Debug.Log("Arena Lost - Scraps received = " + num);
			Singleton<MessageManager>.instance.AddMessage(new ArenaLostMessage(num, arenaExpired: false));
			if ((int)WarArena.instance.data.lives == 0)
			{
				Singleton<EventTrackingManager>.instance.ArenaFinished(WarArena.instance.data.wins, WarArena.instance.data.runs);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			}
			Debug.LogFormat("Arena Lost - you gain scraps. You have {0} lives.", WarArena.instance.data.lives);
		}
		if ((int)WarArena.instance.data.wins == WarArena.instance.warArenaConfig.nodes.Count)
		{
			bool flag2 = mResponse.ContainsKey("Shields");
			if (flag2)
			{
				StatsManager.instance.arenaFlawless++;
			}
			Singleton<EventTrackingManager>.instance.ArenaFinished((!flag2) ? ((int)WarArena.instance.data.wins) : 999, WarArena.instance.data.runs);
		}
		if (mResponse.ContainsKey("VisualType") && mResponse.ContainsKey("VisualTimestamp"))
		{
			string visualType = StringParser.ParseString(mResponse["VisualType"], string.Empty);
			int visualTimestamp = StringParser.ParseInt(mResponse["VisualTimestamp"]);
			WarArena.instance.data.visualType = visualType;
			WarArena.instance.data.visualTimestamp = visualTimestamp;
			GameLoginManager.currentPlayer.visualType = visualType;
			GameLoginManager.currentPlayer.visualTimestamp = visualTimestamp;
		}
		if (mResponse.ContainsKey("Shields"))
		{
			int shields = StringParser.ParseInt(mResponse["Shields"]);
			if (WarArena.instance.data.shields == 0)
			{
				Singleton<MessageManager>.instance.AddMessage(new ArenaShieldsMessage());
			}
			WarArena.instance.data.shields = shields;
		}
		if (mResponse.ContainsKey("DecalId") && mResponse.ContainsKey("DecalExpiresOn"))
		{
			string text = StringParser.ParseString(mResponse["DecalId"], string.Empty);
			int expiresOn = StringParser.ParseInt(mResponse["DecalExpiresOn"]);
			PlayerVisual visual = CamosManager.instance.GetVisual(text);
			if (visual == null)
			{
				Debug.LogErrorFormat("Visual id \"{0}\" is not present on client", text);
			}
			else
			{
				bool flag3 = !visual.isBought;
				visual.setExpiresOn(expiresOn);
				if (flag3)
				{
					flag = true;
					Singleton<MessageManager>.instance.AddMessage(new ArenaVisualMessage(visual, WarArena.instance.data.wins));
				}
			}
		}
		if (flawless != WarArena.instance.data.flawless)
		{
			if (flawless == 0)
			{
				int remainingSeconds = WarArena.instance.data.shields - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				Singleton<MessageManager>.instance.AddMessage(new ArenaGoldenShieldMessage(remainingSeconds, battles));
			}
			else
			{
				Singleton<MessageManager>.instance.AddMessage(new ArenaWonMessage(battles, isFlawless: true));
			}
		}
		else if ((int)WarArena.instance.data.wins == battles && !flag)
		{
			Singleton<MessageManager>.instance.AddMessage(new ArenaWonMessage(battles, isFlawless: false));
		}
	}

	private void OnClassicGameEnded(DatabaseAction databaseAction)
	{
		if (mResponse.ContainsKey("GameReward"))
		{
			Singleton<ServerResultsCache>.instance.lastGameReward = new DatabaseGameReward((JToken)mResponse["GameReward"]);
			LevelManager.instance.experience += Singleton<ServerResultsCache>.instance.lastGameReward.GetXpTotal();
			Singleton<EventTrackingManager>.instance.RegisterBattleEndedEvent(Singleton<GameController>.instance.isDeathMatchOffline, Singleton<MatchManager>.instance.isOverTime, CardManager.instance.data.GetCardAmount(), CardManager.instance.cardsForGame.Count + CardManager.instance.GetUsedCardsCount(), CardManager.instance.GetUsedCardsCount());
		}
		if (mResponse.ContainsKey("WinCount"))
		{
			int wc = StringParser.ParseInt(mResponse["WinCount"]);
			int ts = StringParser.ParseInt(mResponse["TimeStamp"]);
			StatsManager.instance.winStreak = new WinStreakManager.WinStreak(ts, wc);
			Debug.Log($"WINSTREAK FROM SERVER COUNT: {StatsManager.instance.winStreak.WinCount} TIMESTAMP: {StatsManager.instance.winStreak.TimeStamp} REMAININGTIME: {StatsManager.instance.winStreak.remainingTime}");
		}
		else if (mResponse.ContainsKey("Skill"))
		{
			StatsManager.instance.winStreak = new WinStreakManager.WinStreak(0, 0);
		}
		bool flag = mResponse.ContainsKey("Skill");
		if (Singleton<GameController>.instance.isRandomMatchMaking && !flag)
		{
			Debug.LogError("WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!");
			Debug.LogError("Server Response:\n" + mResponse);
		}
		if (flag)
		{
			bool flag2 = mResponse.ContainsKey("EnteredLeague");
			bool flag3 = mResponse.ContainsKey("BeginnersLeague");
			string text = ((!flag2) ? string.Empty : StringParser.ParseString(mResponse["EnteredLeague"], string.Empty));
			int num = (flag3 ? StringParser.ParseInt(mResponse["BeginnersLeague"]) : 0);
			int num2 = StringParser.ParseInt(mResponse["PlacementMatchesRequired"]);
			int num3 = StringParser.ParseInt(mResponse["MedalsBalance"]);
			int num4 = StringParser.ParseInt(mResponse["Skill"]);
			bool enteredNormalLeague = mResponse.ContainsKey("EnteredNormalLeague");
			Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = mResponse.ContainsKey("PlayerLeagueProcessing");
			Debug.Log("GameEnded: Player League Processing: " + Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing);
			Singleton<ServerResultsCache>.instance.lastGameReward.AddMedalsInformations(num4, num3, num2);
			if (flag2 && flag3)
			{
				Debug.LogFormat("Player entered normal league: {0} and beginners league: {1}", text, num);
				if (num > 0)
				{
					flag2 = false;
				}
				else
				{
					flag3 = false;
				}
			}
			if (flag2)
			{
				GameLoginManager.instance.UpdatePlayerLeagueAndMedalsEnteredNormalLeague(text, num, num4, num3, num2, enteredNormalLeague);
				StatsManager.instance.UpdatePlayerLeague();
			}
			else if (flag3)
			{
				GameLoginManager.instance.UpdatePlayerLeagueAndMedalsEnteredBeginnersLeague(num, num4, num3, num2);
			}
			else
			{
				GameLoginManager.instance.UpdatePlayerMedals(num4, num3, num2);
			}
			StatsManager.instance.UpdatePlayerMedals();
		}
		if (mResponse.ContainsKey("MissionManagerData"))
		{
			MissionsManager.instance.LoadData(StringParser.ParseString(mResponse["MissionManagerData"], string.Empty));
		}
		if (mResponse.ContainsKey("VipReward1"))
		{
			Debug.LogError("VIP REWARDS!!!!");
			string text2 = StringParser.ParseString(mResponse["VipReward1"], string.Empty);
			string text3 = StringParser.ParseString(mResponse["VipReward2"], string.Empty);
			Debug.LogError("ABOUT TO SHOW REWARDS = " + text2 + text3);
			string dayString = "a";
			if (mResponse.ContainsKey("VipRewardForDay"))
			{
				dayString = StringParser.ParseString(mResponse["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(text2, text3, dayString));
		}
		if (mResponse.ContainsKey("squadPoints"))
		{
			int num5 = StringParser.ParseInt(mResponse["squadPoints"]);
			if (num5 > 0)
			{
				Singleton<ServerResultsCache>.instance.lastGameReward.AddSquadPoints(num5);
			}
		}
		else
		{
			Debug.Log("No squad points gained from server");
		}
		if (mResponse.ContainsKey("Time"))
		{
			mServerTime.Init(StringParser.ParseInt(mResponse["Time"]));
		}
		if (mResponse.ContainsKey("StarterPackDeadline"))
		{
			PlayerAnalytics.instance.data.starterPackDeadline = StringParser.ParseInt(mResponse["StarterPackDeadline"]);
			Debug.Log("GameEnded: Starter Pack Deadline = " + PlayerAnalytics.instance.data.starterPackDeadline);
			if (PlayerAnalytics.instance.showStarterPack)
			{
				Singleton<MessageManager>.instance.AddMessage(new StarterPackTimeLimitedOffer());
			}
		}
		if (mResponse.ContainsKey("MoneyPackDeadline"))
		{
			PlayerAnalytics.instance.data.moneyPackDeadline = StringParser.ParseInt(mResponse["MoneyPackDeadline"]);
			Debug.Log("GameEnded: Money Pack Deadline = " + PlayerAnalytics.instance.data.moneyPackDeadline);
			Singleton<MessageManager>.instance.AddMessage(new TimeLimitedOffer(), canBeRepeated: true);
		}
		if (mResponse.ContainsKey("ElitePackId") && mResponse.ContainsKey("ElitePackDeadline"))
		{
			string text4 = StringParser.ParseString(mResponse["ElitePackId"], string.Empty);
			int packDeadline = StringParser.ParseInt(mResponse["ElitePackDeadline"]);
			PlayerAnalytics.instance.data.SetPackDeadline(text4, packDeadline);
			Singleton<MessageManager>.instance.AddMessage(new ElitePackTimeLimitedOffer(text4));
		}
		if (mResponse.ContainsKey("MatchesToNextLootboxes"))
		{
			PlayerAnalytics.instance.data.matchesToNextLootboxes = StringParser.ParseInt(mResponse["MatchesToNextLootboxes"]);
		}
		if (mResponse.ContainsKey("DogtagsRefillRankUp"))
		{
			Singleton<DogTagManager>.instance.RefillAllDogtags();
		}
		Debug.Log($"Next Lootbox in {PlayerAnalytics.instance.data.matchesToNextLootboxes} games !");
		if (mResponse.ContainsKey("Rental"))
		{
			Debug.Log("RENTAL OFFER");
			JToken jToken = (JToken)mResponse["Rental"];
			string text5 = jToken["Id"].ToString();
			string text6 = jToken["Amount"].ToString();
			GameItem gameItem = jToken["Type"].ToObject<GameItem>();
			bool isOnSale = true;
			OfferState offerState = jToken["accepted"].ToObject<OfferState>();
			string nextRentalTimeString = jToken["nextGenerate"].ToString();
			Debug.LogError($"RentalId: {text5}, rentalDiscount: {text6}, state {offerState}");
			Singleton<MessageManager>.instance.AddMessage(new DailyRentalMessage(text5, text6, gameItem, isOnSale, nextRentalTimeString));
			switch (gameItem)
			{
			case GameItem.ArmyUnit:
			{
				Debug.Log("set unit not borrowed");
				if (LevelManager.instance.data.savedArmies.TryGetValue(text5, out var value2))
				{
					value2.borrowed = false;
				}
				else
				{
					Debug.LogError($"rental for unexist unit: {text5}");
				}
				break;
			}
			case GameItem.Weapon:
			{
				Debug.Log("set weapon not borrowed");
				if (LevelManager.instance.data.savedWeapons.TryGetValue(text5, out var value))
				{
					value.borrowed = false;
				}
				else
				{
					Debug.LogError($"rental for unexist weapon: {text5}");
				}
				break;
			}
			case GameItem.PlayerVisual:
				Debug.Log("set visual not borrowed");
				if (CamosManager.instance.data.visuals.ContainsKey(text5))
				{
					CamosManager.instance.data.visuals[text5].borrowed = false;
				}
				else
				{
					Debug.LogError($"rental for unexist visual: {text5}");
				}
				break;
			}
		}
		if (mResponse.ContainsKey("Squad"))
		{
			DatabaseSquad databaseSquad = DatabaseSquad.CreateFromDatabase((JToken)mResponse["Squad"]);
			Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(databaseSquad);
			Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + databaseSquad.name, databaseSquad, DateTime.Now.AddMinutes(2.0));
		}
		int num6 = StringParser.ParseInt(mResponse["LevelExperience"]);
		if (Singleton<ServerResultsCache>.instance.lastGameReward != null)
		{
			Debug.Log(Singleton<ServerResultsCache>.instance.lastGameReward.debugGameRewards);
			Debug.Log($"Update of experience\t\t{LevelManager.instance.levelExperience} -> {num6}\t\t diff {num6 - LevelManager.instance.levelExperience}, game rewards XP total {Singleton<ServerResultsCache>.instance.lastGameReward.GetXpTotal()}");
		}
		if (mResponse.ContainsKey("Level"))
		{
			if (mResponse.ContainsKey("GameReward"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(isLevelUp: true);
			}
			LevelManager.instance.LoadData(StringParser.ParseInt(mResponse["Level"]), num6);
			LevelManager.instance.isLevelUp = true;
		}
		else
		{
			if (mResponse.ContainsKey("GameReward"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(isLevelUp: false);
			}
			LevelManager.instance.levelExperience = num6;
		}
		if (mResponse.ContainsKey("SquadEventProgress"))
		{
			Singleton<ServerResultsCache>.instance.squadEventProgress = DatabaseSquadEventProgress.CreateFromDatabase((JToken)mResponse["SquadEventProgress"]);
		}
		if (mResponse.ContainsKey("AssignmentData"))
		{
			Debug.LogError("Loading assignment data after GAME!!");
			AssignmentsManager.instance.LoadData(StringParser.ParseString(mResponse["AssignmentData"], string.Empty));
			List<AssignmentsManager.DatabaseAssignment> assignments = AssignmentsManager.instance.data.assignments;
			foreach (AssignmentsManager.DatabaseAssignment item in assignments)
			{
				Singleton<EventTrackingManager>.instance.RegisterAssignmentIssued(item, AssignmentsManager.instance.data.issued);
			}
		}
		if (mResponse.ContainsKey("TutorialData"))
		{
			PlayerAnalytics.instance.tutorialFinished = true;
			Singleton<BeanstalkServerManager>.instance.PlayerDataWasLoaded(executeRoutines: true);
			Singleton<BeanstalkServerManager>.instance.inAppHandler.HandleRestore();
		}
		else if (databaseAction == DatabaseAction.GameEnded)
		{
			bool flag4 = false;
			if (!LevelManager.instance.isLevelUp && !GuiScreenSingle<EndScreen>.instance.isEnteredBeginnersLeague)
			{
				flag4 = TutorialManagerStage4.instance.TryToStartWeaponUpgradeTutorial();
				if (!flag4)
				{
					flag4 = TutorialManagerStage5.instance.TryToStartUnitUpgradeTutorial();
				}
			}
			DialogManager.instance.InitializeDebugMessageForRateApp();
			DialogManager.instance.ShowRateAppDialog();
			DialogManager.instance.PrintDebugMessage();
			DialogManager.instance.InitializeDebugMessage();
			DialogManager.instance.CheckEveryTimeAfterGameEnd();
			if (!LevelManager.instance.isLevelUp && !GuiScreenSingle<EndScreen>.instance.isEnteredBeginnersLeague && !flag4)
			{
				DialogManager.instance.ShowClientSideNotifications();
			}
			DialogManager.instance.PrintDebugMessage();
		}
		if (mResponse.ContainsKey("SpecialPackFromServer"))
		{
			Singleton<OfferManager>.instance.UpdateSpecialPackFromServer((JToken)mResponse["SpecialPackFromServer"], now: true);
		}
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.Evaluation.AfterGameOnServerResponse);
	}

	private void OnInstantBattleEnded()
	{
		if (mResponse.ContainsKey("MoneyPackDeadline"))
		{
			PlayerAnalytics.instance.data.moneyPackDeadline = StringParser.ParseInt(mResponse["MoneyPackDeadline"]);
			Debug.Log("InstantBattleEnded: Money Pack Deadline = " + PlayerAnalytics.instance.data.moneyPackDeadline);
			Singleton<MessageManager>.instance.AddMessage(new TimeLimitedOffer(), canBeRepeated: true);
		}
		if (mResponse.ContainsKey("PaidInstantBattles"))
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_InstantBattle", InstantBattleManager.instance.goldCost);
			PlayerAnalytics.instance.data.paidInstantBattles = StringParser.ParseInt(mResponse["PaidInstantBattles"]);
			Singleton<EventTrackingManager>.instance.RefreshInstantBattle(InstantBattleManager.instance.goldCost, PlayerAnalytics.instance.data.paidInstantBattles);
			Debug.Log("InstantBattleEnded: Paid Instant Battles = " + PlayerAnalytics.instance.data.paidInstantBattles);
			InstantBattleManager.instance.goldCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
		if (mResponse.ContainsKey("InstantBattleTime"))
		{
			PlayerAnalytics.instance.data.instantBattlesTime = StringParser.ParseInt(mResponse["InstantBattleTime"]);
			Debug.Log("InstantBattleEnded: Instant Battle Time " + PlayerAnalytics.instance.data.instantBattlesTime);
			PushNotificationManager.instance.SheduleLocalSkirmishNotification(PlayerAnalytics.instance.data.GetTimestampOfFullInstantBattles());
		}
		if (mResponse.ContainsKey("ExperienceGained"))
		{
			int num = StringParser.ParseInt(mResponse["ExperienceGained"]);
			Debug.Log("InstantBattleEnded: REWARD EXPERIENCE: " + num);
			InstantBattleManager.instance.mXpAmmount = num;
		}
		int num2 = StringParser.ParseInt(mResponse["LevelExperience"]);
		if (mResponse.ContainsKey("Level"))
		{
			int num3 = StringParser.ParseInt(mResponse["Level"]);
			Debug.Log("InstantBattleEnded: LEVEL UP " + num3);
			LevelManager.instance.LoadData(num3, num2);
			LevelManager.instance.isLevelUp = true;
		}
		else
		{
			LevelManager.instance.levelExperience = num2;
		}
		if (mResponse.ContainsKey("WarBucks"))
		{
			int num4 = StringParser.ParseInt(mResponse["WarBucks"]);
			Debug.Log("InstantBattleEnded: REWARD WARBUCKS: " + num4);
			InstantBattleManager.instance.mWbAmmount = num4;
			Singleton<Wallet>.instance.AddWarBucksReward(InstantBattleManager.instance.mWbAmmount, animate: false);
		}
		InstantBattleManager.instance.mThirdRewardType = InstantBattleRewardType.None;
		if (mResponse.ContainsKey("ExtraWarBucks"))
		{
			InstantBattleManager.instance.mThirdRewardType = InstantBattleRewardType.Warbucks;
			int num5 = StringParser.ParseInt(mResponse["ExtraWarBucks"]);
			Debug.Log("InstantBattleEnded: 3RD REWARD WARBUCKS: " + num5);
			InstantBattleManager.instance.mExtraWarbucks = num5;
			if (InstantBattleManager.instance.mExtraWarbucks == 0)
			{
				InstantBattleManager.instance.mThirdRewardType = InstantBattleRewardType.None;
			}
			else
			{
				Singleton<Wallet>.instance.AddWarBucksReward(InstantBattleManager.instance.mExtraWarbucks, animate: false);
			}
		}
		if (mResponse.ContainsKey("BattleCount"))
		{
			InstantBattleManager.instance.mNumberOfBattles = StringParser.ParseInt(mResponse["BattleCount"]);
			Debug.Log("InstantBattleEnded: NUMBER OF BATTLES = " + InstantBattleManager.instance.mNumberOfBattles);
		}
		if (mResponse.ContainsKey("Gold"))
		{
			InstantBattleManager.instance.mThirdRewardType = InstantBattleRewardType.Gold;
			int num6 = StringParser.ParseInt(mResponse["Gold"]);
			Debug.Log("InstantBattleEnded: 3RD REWARD GOLD: " + num6);
			InstantBattleManager.instance.mGdAmmount = num6;
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Skirmish", num6);
			if (InstantBattleManager.instance.mGdAmmount == 0)
			{
				InstantBattleManager.instance.mThirdRewardType = InstantBattleRewardType.None;
			}
			else
			{
				Singleton<Wallet>.instance.AddGoldReward(InstantBattleManager.instance.mGdAmmount);
			}
		}
		if (mResponse.ContainsKey("AddedCards"))
		{
			InstantBattleManager.instance.mThirdRewardType = InstantBattleRewardType.WarCard;
			Debug.Log("InstantBattleEnded: 3RD REWARD WARCARDS: " + mResponse["AddedCards"]);
			JArray jArray = (JArray)mResponse["AddedCards"];
			InstantBattleManager.instance.mWarcards = new List<Card>();
			foreach (JToken item2 in jArray)
			{
				Card item = CardManager.instance.AddCard(item2.ToObject<string>());
				InstantBattleManager.instance.mWarcards.Add(item);
			}
			InstantBattleManager.instance.mWarcards.Sort((Card x, Card y) => x.rarityNumber.CompareTo(y.rarityNumber));
		}
		Singleton<EventTrackingManager>.instance.RegisterInstatntBattle(InstantBattleManager.instance.mWbAmmount + InstantBattleManager.instance.mExtraWarbucks, InstantBattleManager.instance.mGdAmmount, InstantBattleManager.instance.mXpAmmount, InstantBattleManager.instance.mWarcards, InstantBattleManager.instance.mNumberOfBattles);
		Singleton<EventTrackingManager>.instance.RegisterWBIn("Skirmish", InstantBattleManager.instance.mWbAmmount + InstantBattleManager.instance.mExtraWarbucks);
		InstantBattleManager.instance.responseArrive = true;
	}

	private void OnGameStarted(DatabaseAction databaseAction)
	{
		Singleton<BeanstalkServerManager>.instance.MatchMakingGameWasCreated(result: true);
		mServerTime.Init(StringParser.ParseInt(mResponse["Time"]));
		if (mResponse.ContainsKey("BattleId"))
		{
			Singleton<GameController>.instance.battleId = StringParser.ParseString(mResponse["BattleId"], string.Empty);
		}
		if (mResponse.ContainsKey("Seconds"))
		{
			Singleton<DogTagManager>.instance.UpdateDogtags(StringParser.ParseInt(mResponse["Seconds"]), StringParser.ParseInt(mResponse["LastUpdate"]));
		}
		if (databaseAction == DatabaseAction.GameStartedCampaign || databaseAction == DatabaseAction.GameStartedCoopMaster || databaseAction == DatabaseAction.GameStartedCoopClient)
		{
			Singleton<EventTrackingManager>.instance.CampaignLevelAttempt(MissionsManager.instance.currentMission, databaseAction != DatabaseAction.GameStartedCampaign);
		}
		if (Singleton<DogTagManager>.instance.currentDogtags < 1)
		{
			Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.RunOutOfDogtags);
		}
	}

	private void OnGetAllMessages()
	{
		JArray jArray = (JArray)mResponse["Items"];
		if (jArray.Count > 1000)
		{
			Debug.LogError($"Recieved {jArray.Count} messages:");
		}
		for (int i = 0; i < jArray.Count; i++)
		{
			JToken dict = jArray[i];
			DatabaseMessage databaseMessage = DatabaseMessage.CreateFromDatabase(dict);
			if (databaseMessage != null)
			{
				Singleton<MessageManager>.instance.AddMessage(databaseMessage);
			}
		}
		jArray = null;
	}

	private void OnChangeAnticheatStatus()
	{
		Debug.LogError("anticheat changed");
		if (mResponse.ContainsKey("Anticheat"))
		{
			PlayerAnalytics.instance.data.anticheatStatus = bool.Parse(mResponse["Anticheat"].ToString());
		}
	}

	private void OnGetAllSquadMembers()
	{
		if (mResponse.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.squadWarsId = StringParser.ParseString(mResponse["SquadWarsId"], string.Empty);
		}
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		JArray jArray = (JArray)mResponse["SquadMembers"];
		string text = StringParser.ParseString(mResponse["SquadId"], string.Empty);
		bool flag = false;
		foreach (JToken item in jArray)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item);
			if (databasePlayer.id == GameLoginManager.instance.playerId)
			{
				GameLoginManager.instance.UpdatePlayerSquadRank(databasePlayer.squadRank);
				flag = true;
			}
			list.Add(databasePlayer);
		}
		if (!flag && text == GameLoginManager.currentPlayer.squadName)
		{
			GameLoginManager.instance.RemovePlayerFromSquad();
		}
		if (mResponse.ContainsKey("SquadMessages"))
		{
			JArray jArray2 = (JArray)mResponse["SquadMessages"];
			if (jArray2.Count > 0)
			{
				Debug.Log("I Got New Squad Messages");
			}
			string text2 = "These players came from server as awaiting to squad:\n";
			foreach (JToken item2 in jArray2)
			{
				DatabaseMessage databaseMessage = DatabaseMessage.CreateFromDatabase(item2);
				if (databaseMessage is SquadJoinRequest squadJoinRequest)
				{
					Debug.Log("Awaiting Squad Member = " + squadJoinRequest.player.name);
					squadJoinRequest.player.awaitingSquadMember = true;
					Singleton<AwaitingSquadMembersManager>.instance.AddAwaitingMember(squadJoinRequest.player);
					Singleton<AwaitingSquadMembersManager>.instance.AddToMC(squadJoinRequest);
					text2 += $"Player name:{squadJoinRequest.player.name} Player id:{squadJoinRequest.player.id}\n";
				}
			}
			Debug.Log(text2);
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("squadMembers" + text, list, DateTime.Now.AddMinutes(1.0), DatabaseAction.GetAllSquadMembers);
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(text, ommitTime: true);
		if (squad != null)
		{
			squad.size = list.Count;
			Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + text, squad, DateTime.Now.AddMinutes(1.0));
		}
	}

	private void OnGetFriendsInfo()
	{
		Debug.Log("Beanstalk: On Get Friends");
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		List<DatabasePlayer> list2 = new List<DatabasePlayer>();
		List<DatabasePlayer> list3 = new List<DatabasePlayer>();
		if (mResponse.ContainsKey("Friends"))
		{
			JArray jArray = (JArray)mResponse["Friends"];
			Debug.Log("Received FB Friends from server: " + jArray.Count);
			foreach (JToken item2 in jArray)
			{
				DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item2);
				Debug.Log("New FB friend, name = " + databasePlayer.name);
				list.Add(databasePlayer);
				list3.Add(databasePlayer);
			}
		}
		if (mResponse.ContainsKey("SquadMates"))
		{
			JArray jArray2 = (JArray)mResponse["SquadMates"];
			foreach (JToken item3 in jArray2)
			{
				DatabasePlayer item = DatabasePlayer.CreateFromDatabase(item3);
				list2.Add(item);
				list3.Add(item);
			}
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("facebookFriends", list, DateTime.Now.AddSeconds(30.0));
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("squadMembers" + currentPlayer.squadName, list2, DateTime.Now.AddSeconds(30.0));
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("players", list3, DateTime.Now.AddSeconds(30.0));
	}

	private void OnGetMissionLeaderboards()
	{
		List<DatabasePlayerMissionLeaderboard> list = new List<DatabasePlayerMissionLeaderboard>();
		if (mResponse.ContainsKey("Friends"))
		{
			JArray jArray = (JArray)mResponse["Friends"];
			foreach (JToken item in jArray)
			{
				list.Add(DatabasePlayerMissionLeaderboard.CreateFromDatabase(item));
			}
		}
		if (mResponse.ContainsKey("SquadMates"))
		{
			JArray jArray2 = (JArray)mResponse["SquadMates"];
			foreach (JToken item2 in jArray2)
			{
				list.Add(DatabasePlayerMissionLeaderboard.CreateFromDatabase(item2));
			}
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayerMissionLeaderboard>>("missionLeaderboards", list, DateTime.Now.AddMinutes(2.0));
	}

	private void OnGetPlayerData()
	{
		RequestBufferManager.instance.Clear();
		Singleton<MessageManager>.instance.ClearAllMessages();
		Singleton<BeanstalkServerManager>.instance.GetAllMessages();
		if (mResponse.ContainsKey("Squad"))
		{
			DatabaseSquad databaseSquad = DatabaseSquad.CreateFromDatabase((JToken)mResponse["Squad"]);
			GameLoginManager.instance.OnPlayerDataLoadedSquadNameCheck(databaseSquad.name);
			OnGetSquadDetails();
		}
		else
		{
			GameLoginManager.instance.RemovePlayerFromSquad();
		}
		if (mResponse.ContainsKey("RemoveRewards"))
		{
			Debug.LogError("Used warcards and rewards from last match wre removed");
			BattleRewardsManager.instance.ClearAllRewards();
		}
		if (mResponse.ContainsKey("MaintenanceMessage"))
		{
			DatabaseMessage databaseMessage = DatabaseMessage.CreateFromDatabase((JToken)mResponse["MaintenanceMessage"]);
			if (databaseMessage != null)
			{
				Singleton<MessageManager>.instance.AddMessage(databaseMessage);
			}
		}
		int beginnersLeague = (mResponse.ContainsKey("BeginnersLeague") ? GameLoginManager.currentPlayer.beginnersLeague : 0);
		string league = ((!mResponse.ContainsKey("LeagueId")) ? GameLoginManager.currentPlayer.leagueId : StringParser.ParseString(mResponse["LeagueId"], string.Empty));
		int globalMedals = ((!mResponse.ContainsKey("Skill")) ? GameLoginManager.currentPlayer.skill : StringParser.ParseInt(mResponse["Skill"]));
		int leagueMedals = ((!mResponse.ContainsKey("MedalsBalance")) ? GameLoginManager.currentPlayer.medalsBalance : StringParser.ParseInt(mResponse["MedalsBalance"]));
		int remainingMatches = ((!mResponse.ContainsKey("PlacementMatchesRequired")) ? ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE) : StringParser.ParseInt(mResponse["PlacementMatchesRequired"]));
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(beginnersLeague, league, globalMedals, leagueMedals, remainingMatches);
		Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = mResponse.ContainsKey("SquadWarsProcessing");
		Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = mResponse.ContainsKey("PlayerLeagueProcessing");
		if (mResponse.ContainsKey("DeviceToken"))
		{
			string text = StringParser.ParseString(mResponse["DeviceToken"], string.Empty);
			if (text != PushNotificationManager.instance.data.deviceToken)
			{
				Debug.LogWarning("Get player data: I SHOULD SEND PN DEVICET TOKEN");
				if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
				{
					Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
					PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
				}
			}
			else
			{
				Debug.LogWarning("Get player data: NOT SENDING PN DEVICE TOKEN");
			}
		}
		else if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
		{
			Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
			PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
		}
		if (mResponse.ContainsKey("LeagueEvaluation"))
		{
			mServerTime.InitNextLeagueEvaluation(StringParser.ParseInt(mResponse["LeagueEvaluation"]));
			LeagueArcManager.instance.SetLeagueTimer(mServerTime.nextLeagueEvaluation);
			GuiScreenSingle<MainScreen>.instance.bottomLeaguePlayers.leagueEnding.SetLeagueEnd(mServerTime.nextLeagueEvaluation);
		}
		mServerTime.Init(StringParser.ParseInt(mResponse["Time"]));
		LoadPlayerData((JToken)mResponse["PlayerData"]);
		if (mResponse.ContainsKey("dailyRewardData"))
		{
			string text2 = mResponse["dailyRewardData"].ToString();
			if (StatsManager.instance.DailyRewardDataLoaded((JToken)mResponse["dailyRewardData"]) && !GuiScreenSingle<DailyRewardMonthScreen>.instance.isShowed)
			{
				Singleton<MessageManager>.instance.AddMessage(new DailyRewardMessage(StatsManager.instance.dailyRewardData.toClaim + StatsManager.instance.dailyRewardData.month * 100));
			}
		}
		if (mResponse.ContainsKey("WarArenaConfig"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)mResponse["WarArenaConfig"]);
			Debug.Log("WAR ARENA CONFIG RECEIVED! Id = " + WarArena.instance.warArenaConfig.id);
		}
		else
		{
			Debug.LogError("NO WAR ARENA CONFIG!!!");
		}
		if (mResponse.ContainsKey("Scraps"))
		{
			int num = StringParser.ParseInt(mResponse["Scraps"]);
			Debug.Log("Arena Lost - Scraps received = " + num);
			Singleton<MessageManager>.instance.AddMessage(new ArenaLostMessage(num, arenaExpired: true));
			Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			Debug.LogFormat("Arena Expired - you gain scraps. You have {0} lives.", WarArena.instance.data.lives);
		}
		if (mResponse.ContainsKey("HeartDialog"))
		{
			Debug.Log("Heart dialog should be shown in arena screen now");
			Singleton<MessageManager>.instance.AddMessage(new BuyHearthArenaMessage(WarArena.instance.warArenaConfig.id));
		}
		if (mResponse.ContainsKey("ShowArenaDialog"))
		{
			Debug.Log("SHOW WAR ARENA DIALOG!!");
			string id = WarArena.instance.warArenaConfig.id;
			bool isOpened = WarArena.instance.isOpened;
			Singleton<MessageManager>.instance.AddMessage(new ArenaOpenedMessage(id, isOpened));
		}
		if (mResponse.ContainsKey("DailyGold"))
		{
			int num2 = StringParser.ParseInt(mResponse["DailyGold"]);
			string nAME = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold7daily1).NAME;
			int day = StringParser.ParseInt(mResponse["DailyGoldDay"]);
			Singleton<MessageManager>.instance.AddMessage(new DailyGoldBoosterMessage(num2, day, nAME));
		}
		if (mResponse.ContainsKey("NewAssignments"))
		{
			Debug.Log("New Assignments!");
			List<AssignmentsManager.DatabaseAssignment> assignments = AssignmentsManager.instance.data.assignments;
			foreach (AssignmentsManager.DatabaseAssignment item in assignments)
			{
				Singleton<EventTrackingManager>.instance.RegisterAssignmentIssued(item, AssignmentsManager.instance.data.issued);
			}
			Singleton<EventTrackingManager>.instance.RegisterDailyVisit();
		}
		if (mResponse.ContainsKey("VipReward1"))
		{
			string id2 = StringParser.ParseString(mResponse["VipReward1"], string.Empty);
			string id3 = StringParser.ParseString(mResponse["VipReward2"], string.Empty);
			string dayString = "a";
			if (mResponse.ContainsKey("VipRewardForDay"))
			{
				dayString = StringParser.ParseString(mResponse["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new VipCardMessage(id2, id3, dayString));
		}
		if (mResponse.ContainsKey("LapsedPlayerRewardId"))
		{
			string packId = StringParser.ParseString(mResponse["LapsedPlayerRewardId"], string.Empty);
			Singleton<MessageManager>.instance.AddMessage(new WelcomeBackSoldierMessage(packId));
		}
		if (mResponse.ContainsKey("Rental"))
		{
			JToken jToken = (JToken)mResponse["Rental"];
			string text3 = StringParser.ParseString(jToken["Id"], string.Empty);
			string text4 = StringParser.ParseString(jToken["Amount"], string.Empty);
			GameItem gameItem = (GameItem)StringParser.ParseIntToken(jToken["Type"]);
			bool isOnSale = false;
			string nextRentalTimeString = jToken["nextGenerate"].ToString();
			Debug.LogError("NEW RENTAL " + text3 + ", " + text4 + ", " + gameItem);
			Singleton<MessageManager>.instance.AddMessage(new DailyRentalMessage(text3, text4, gameItem, isOnSale, nextRentalTimeString));
		}
		if (mResponse.ContainsKey("BattleId") && !mTutorialAlreadyInProgress)
		{
			Debug.LogError("START PLAYING TUTORIAL");
			Singleton<GameController>.instance.battleId = StringParser.ParseString(mResponse["BattleId"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		mTutorialAlreadyInProgress = false;
		if (mResponse.ContainsKey("fuseData"))
		{
			Singleton<EventTrackingManager>.instance.fuseboxxService.DeserializeSavedConfig(mResponse["fuseData"] as string);
		}
		if (mResponse.ContainsKey("SpecialPackFromServer"))
		{
			Singleton<OfferManager>.instance.UpdateSpecialPackFromServer((JToken)mResponse["SpecialPackFromServer"], now: false);
		}
		Singleton<OfferManager>.instance.UpdateFromServer((!mResponse.ContainsKey("specialOffers")) ? null : ((JToken)mResponse["specialOffers"]));
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
	}

	private void OnGetPlayersByExperience()
	{
		Dictionary<string, DatabasePlayerData> dictionary = new Dictionary<string, DatabasePlayerData>();
		List<DatabasePlayerData> list = new List<DatabasePlayerData>();
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			DatabasePlayerData databasePlayerData = DatabasePlayerData.CreateFromDatabase(jArray[i]);
			dictionary.Add(databasePlayerData.id, databasePlayerData);
		}
		JArray jArray2 = (JArray)mResponse["Local"];
		for (int j = 0; j < jArray2.Count; j++)
		{
			DatabasePlayerData databasePlayerData2 = DatabasePlayerData.CreateFromDatabase(jArray2[j]);
			if (!string.IsNullOrEmpty(databasePlayerData2.id))
			{
				list.Add(databasePlayerData2);
			}
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayerData>>("localPlayerLeaderboard", list, DateTime.Now.AddMinutes(2.0));
		Singleton<ServerResultsCache>.instance.Insert<Dictionary<string, DatabasePlayerData>>("globalPlayerLeaderboard", dictionary, DateTime.Now.AddMinutes(2.0));
	}

	private void OnGetLastWeeksPlayerLeague()
	{
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			DatabasePlayer item = DatabasePlayer.CreateFromDatabase(jArray[i]);
			list.Add(item);
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("lastWeeksPlayerLeague", list, DateTime.Now.AddMinutes(60.0));
	}

	private void OnFinishPlayerLeague()
	{
		string text = ((!mResponse.ContainsKey("Finished")) ? "not finished" : "finished");
		Debug.Log("ON FINISH PLAYER LEAGUE, RESULT =" + text);
	}

	private void OnGetPlayerLeaguesDivision()
	{
		if (mResponse.ContainsKey("PlayerLeaguesId"))
		{
			Singleton<ServerResultsCache>.instance.playerLeaguesId = StringParser.ParseString(mResponse["PlayerLeaguesId"], string.Empty);
		}
		Dictionary<string, DatabasePlayer> dictionary = new Dictionary<string, DatabasePlayer>();
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(jArray[i]);
			dictionary.Add(databasePlayer.id, databasePlayer);
		}
		string key = "leagueMembers" + StringParser.ParseString(mResponse["LeagueId"], string.Empty);
		if (mResponse.ContainsKey("LeagueEvaluation"))
		{
			int num = StringParser.ParseInt(mResponse["LeagueEvaluation"]);
			Debug.Log("PLayerLeagueEvaluation = " + num);
			mServerTime.InitNextLeagueEvaluation(num);
			LeagueArcManager.instance.SetLeagueTimer(mServerTime.nextLeagueEvaluation);
			GuiScreenSingle<MainScreen>.instance.bottomLeaguePlayers.leagueEnding.SetLeagueEnd(mServerTime.nextLeagueEvaluation);
		}
		Singleton<ServerResultsCache>.instance.Insert<Dictionary<string, DatabasePlayer>>(key, dictionary, DateTime.Now.AddMinutes(2.0));
	}

	private void OnGetSquadDetails()
	{
		if (mResponse.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.squadWarsId = StringParser.ParseString(mResponse["SquadWarsId"], string.Empty);
		}
		DatabaseSquad databaseSquad = DatabaseSquad.CreateFromDatabase((JToken)mResponse["Squad"]);
		if (mResponse.ContainsKey("SquadId"))
		{
			string name = StringParser.ParseString(mResponse["SquadId"], string.Empty);
			if (string.IsNullOrEmpty(databaseSquad.name))
			{
				databaseSquad.name = name;
			}
		}
		if (mResponse.ContainsKey("SquadWarsPosition"))
		{
			int num = StringParser.ParseInt(mResponse["SquadWarsPosition"]);
			Debug.LogWarning("Squad Position = " + num);
			databaseSquad.warsPosition = num;
		}
		if (mResponse.ContainsKey("WarsEvaluation"))
		{
			mServerTime.InitNextWarsEvaluation(StringParser.ParseInt(mResponse["WarsEvaluation"]));
			GuiScreenSingle<LeaguesScreen>.instance.squadWars.ShowSquadWarEndTime(mServerTime.nextWarsEvaluation);
			GuiScreenSingle<MainScreen>.instance.bottomLeaguePlayers.leagueEnding.SetSquadWarsEnd(mServerTime.nextWarsEvaluation);
		}
		Singleton<ServerResultsCache>.instance.squadEventDefinition = ((!mResponse.ContainsKey("EventDefinition")) ? null : DatabaseSquadEventDefinition.CreateFromDatabase((JToken)mResponse["EventDefinition"]));
		Singleton<ServerResultsCache>.instance.squadEventProgress = ((!mResponse.ContainsKey("SquadEventProgress")) ? null : DatabaseSquadEventProgress.CreateFromDatabase((JToken)mResponse["SquadEventProgress"]));
		Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + databaseSquad.name, databaseSquad, DateTime.Now.AddMinutes(2.0));
		Debug.Log("Squad updated , key=squad" + databaseSquad.name);
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetSquadDetails);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(databaseSquad);
	}

	private void OnGetSquads()
	{
		Singleton<ServerResultsCache>.instance.squadSearchResult = new List<DatabaseSquad>();
		Singleton<ServerResultsCache>.instance.squadSearchIsLocal = mResponse.ContainsKey("IsLocal") && StringParser.ParseBool(mResponse["IsLocal"]);
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			Singleton<ServerResultsCache>.instance.squadSearchResult.Add(DatabaseSquad.CreateFromDatabase(jArray[i]));
		}
	}

	private void OnGetSquadsByExperience()
	{
		List<DatabaseSquad> list = new List<DatabaseSquad>();
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			list.Add(DatabaseSquad.CreateFromDatabase(jArray[i]));
		}
		if (mResponse.ContainsKey("Local"))
		{
			JArray jArray2 = (JArray)mResponse["Local"];
			List<DatabaseSquad> list2 = new List<DatabaseSquad>();
			for (int j = 0; j < jArray2.Count; j++)
			{
				list2.Add(DatabaseSquad.CreateFromDatabase(jArray2[j]));
			}
			Singleton<ServerResultsCache>.instance.Insert<List<DatabaseSquad>>("localSquadLeaderboard", list2, DateTime.Now.AddMinutes(2.0));
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabaseSquad>>("globalSquadLeaderboard", list, DateTime.Now.AddMinutes(2.0));
	}

	private void OnGetSquadWarsDivision()
	{
		List<DatabaseSquad> list = new List<DatabaseSquad>();
		if (mResponse.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.squadWarsId = StringParser.ParseString(mResponse["SquadWarsId"], string.Empty);
		}
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			list.Add(DatabaseSquad.CreateFromDatabase(jArray[i]));
		}
		string key = "squadsFromLeague" + StringParser.ParseString(mResponse["LeagueId"], string.Empty);
		Singleton<ServerResultsCache>.instance.Insert<List<DatabaseSquad>>(key, list, DateTime.Now.AddMinutes(20.0));
	}

	private void OnDeclineSquadJoinRequest(List<Tuple<string, string>> postData)
	{
		foreach (Tuple<string, string> postDatum in postData)
		{
			if (postDatum.Value1 == "MessageId")
			{
				Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(postDatum.Value2, updateGUI: true);
				return;
			}
		}
		Debug.LogError("no player Id found");
	}

	private void OnIgnoreMessage()
	{
		Debug.Log("Message ignored!");
	}

	private void OnInvitePlayerToSquad()
	{
		WaitingDialog.Hide();
	}

	private void OnJoinSquad()
	{
		string text = StringParser.ParseString(mResponse["SquadId"], string.Empty);
		GameLoginManager.instance.AddPlayerToSquad(text, (SquadRank)StringParser.ParseInt(mResponse["PlayerRank"]));
		if (mResponse.ContainsKey("Gold"))
		{
			long num = StringParser.ParseLong(mResponse["Gold"], 0L);
			Singleton<Wallet>.instance.AddGoldReward(num);
			Singleton<MessageManager>.instance.AddMessage(new RewardMessage(RewardDialogType.Gold, num));
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).DBKEY;
			PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		}
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.UserAddedToSquadSuccess);
		Singleton<BeanstalkServerManager>.instance.GetSquadDetails(text);
	}

	private void OnJoinSquadEvent()
	{
		Debug.Log("Joined Squad Event");
		Singleton<ServerResultsCache>.instance.squadEventProgress = DatabaseSquadEventProgress.CreateFromDatabase((JToken)mResponse["SquadEventProgress"]);
		if (GuiScreenSingle<SquadScreen>.instance.isShowed)
		{
			GuiScreenSingle<SquadScreen>.instance.eventContent.OnJoinedSquadEvent();
		}
	}

	private void OnLeaveSquad()
	{
		WaitingDialog.Hide();
		GameLoginManager.instance.RemovePlayerFromSquad();
		if (!mResponse.ContainsKey("DepositedCards"))
		{
			return;
		}
		Debug.Log("Got player deposited Cards => adding cards to CardManagerData");
		List<string> list = JsonConvert.DeserializeObject<List<string>>(StringParser.ParseString(mResponse["DepositedCards"], string.Empty));
		foreach (string item in list)
		{
			Debug.Log("Adding card " + item + " from deposited cards to normal cards");
			CardManager.instance.AddCard(item);
		}
	}

	private void OnLoginToCustomAccount()
	{
		Debug.Log("On Login to Custom playerAccount");
		DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)mResponse["Player"]);
		AccountType accountType = (AccountType)StringParser.ParseInt(mResponse["AccountType"]);
		string id = databasePlayer.id;
		switch (accountType)
		{
		case AccountType.Facebook:
			Debug.Log("USPECH POKUSU O LOGIN NA FB!!!");
			id = databasePlayer.facebookId.ToString(CultureInfo.InvariantCulture);
			GameLoginManager.instance.UpdateGCId(databasePlayer.gameCenterId);
			break;
		case AccountType.GameCenter:
			Debug.Log("USPECH POKUSU O LOGIN NA GC!!!");
			id = databasePlayer.gameCenterId;
			break;
		case AccountType.GooglePlay:
			Debug.Log("USPECH POKUSU O LOGIN NA GP!!!");
			id = databasePlayer.googlePlayId;
			break;
		}
		if (mResponse.ContainsKey("MaintenanceMessage"))
		{
			Debug.LogError("GOT MAINTENANCE MESSAGE IN LOGIN TO ACCOUNT");
			DatabaseMessage databaseMessage = DatabaseMessage.CreateFromDatabase((JToken)mResponse["MaintenanceMessage"]);
			if (databaseMessage != null)
			{
				Singleton<MessageManager>.instance.AddMessage(databaseMessage);
			}
		}
		GameLoginManager.instance.SavePlayer(databasePlayer, id, StringParser.ParseString(mResponse["Token"], string.Empty), StringParser.ParseString(mResponse["Password"], string.Empty), accountType);
	}

	private void OnMessageSent()
	{
		Debug.Log("Beanstalk: New Message sent succesfully");
	}

	private void OnPayOneDogTag()
	{
		int num = StringParser.ParseInt(mResponse["LastUpdate"]);
		mServerTime.Init(num);
		Singleton<DogTagManager>.instance.UpdateDogtags(StringParser.ParseInt(mResponse["Seconds"]), num);
	}

	private void OnPromotePlayer()
	{
		if (mResponse.ContainsKey("PromotedPlayer"))
		{
			JToken jToken = (JToken)mResponse["PromotedPlayer"];
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(jToken);
			if (jToken["PromotedPlayerId"] != null)
			{
				databasePlayer.id = StringParser.ParseString("PromotedPlayerId", "S", jToken, string.Empty);
			}
			Singleton<ServerResultsCache>.instance.UpdateSquadPlayer(databasePlayer);
			GuiScreenSingle<SquadScreen>.instance.memberContent.ServerResponseCame(DatabaseAction.PromotePlayer, databasePlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
	}

	private void OnPromotePlayerToFounder()
	{
		GameLoginManager.instance.UpdatePlayerSquadRank(SquadRank.Veteran);
		if (mResponse.ContainsKey("PromotedPlayer"))
		{
			JToken jToken = (JToken)mResponse["PromotedPlayer"];
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(jToken);
			if (jToken["PromotedPlayerId"] != null)
			{
				databasePlayer.id = StringParser.ParseString("PromotedPlayerId", "S", jToken, string.Empty);
			}
			Singleton<ServerResultsCache>.instance.UpdateSquadPlayer(databasePlayer);
			GuiScreenSingle<SquadScreen>.instance.memberContent.ServerResponseCame(DatabaseAction.PromotePlayerToFounder, databasePlayer.id);
			GuiScreenSingle<SquadScreen>.instance.memberContent.ServerResponseCame(DatabaseAction.PromotePlayerToFounder, GameLoginManager.currentPlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
	}

	private void OnProvokePlayer()
	{
	}

	private void OnRefillDogtags()
	{
		long num = StringParser.ParseLong(mResponse["Gold"], 0L);
		Singleton<DogTagManager>.instance.RefillAllDogtags();
		Singleton<Wallet>.instance.GoldSpent(num);
		Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Buy_Dogtags_With_Gold", (int)num);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_DogTags", (int)num);
		Singleton<EventTrackingManager>.instance.RegisterFuseboxxCustomEvent(WarfriendsCustomEvent.RefillDogTags);
	}

	private void OnSearchPlayers()
	{
		Singleton<ServerResultsCache>.instance.playerSearchResult = new List<DatabasePlayer>();
		JArray jArray = (JArray)mResponse["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			Singleton<ServerResultsCache>.instance.playerSearchResult.Add(DatabasePlayer.CreateFromDatabase(jArray[i]));
		}
	}

	private void OnSendRequestBuffer()
	{
		JArray jArray = JsonConvert.DeserializeObject<JArray>(StringParser.ParseString(mResponse["RequestsResults"], string.Empty));
		string text = string.Empty;
		int num = jArray.Count - 1;
		for (int i = 0; i < jArray.Count; i++)
		{
			JToken requestResult = jArray[i];
			text = ProcessBuffer(requestResult, text, i == num);
		}
		if (!string.IsNullOrEmpty(text))
		{
			WarningDialog.ShowError(string.Format("{0} {1}", Localization.Localize("ID_CONFIRM_SERVERCOULDNOTCOMPLETED"), text), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
		}
		RequestBufferManager.instance.RemoveRequestBuffer(StringParser.ParseString(mResponse["BufferId"], string.Empty));
	}

	private static string ProcessBuffer(JToken requestResult, string errorMessage, bool isLast)
	{
		DatabaseAction databaseAction = (DatabaseAction)StringParser.ParseIntToken(requestResult["ActionId"]);
		DatabaseResult databaseResult = (DatabaseResult)StringParser.ParseIntToken(requestResult["Result"]);
		switch (databaseAction)
		{
		case DatabaseAction.ClaimAssignment:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log("Claim Assignment success!");
				break;
			case DatabaseResult.AssignmentNotFound:
			case DatabaseResult.AssignmentIncorrectReward:
				Debug.LogError("ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), 0f, null, string.Empty, useDialogBackground: true);
				AssignmentsManager.instance.LoadData(StringParser.ParseString(requestResult["AssignmentData"], string.Empty));
				Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				break;
			}
			break;
		case DatabaseAction.ClaimStarterAssignment:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log("Claim Starter Assignment success!");
				if (requestResult["Cards"] != null)
				{
					JArray jArray = (JArray)requestResult["Cards"];
					Card[] array = new Card[jArray.Count];
					int num = 0;
					foreach (JToken item in jArray)
					{
						string cardId = StringParser.ParseString(item, string.Empty);
						array[num] = CardManager.instance.GetCardInstance(cardId);
						num++;
						CardManager.instance.AddCard(cardId);
					}
					Singleton<MessageManager>.instance.AddMessage(new StarterAssignmentsReward(array));
				}
				if (requestResult["Warbucks"] != null)
				{
					Singleton<Wallet>.instance.AddWarBucksReward(StringParser.ParseLongToken(requestResult["Warbucks"], 0L));
				}
				if (requestResult["Visual"] != null)
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(StringParser.ParseString(requestResult["Visual"], string.Empty));
					if (visual != null)
					{
						Debug.Log("ADDING VISUAL ON CLIENT " + requestResult["Visual"]);
						visual.Buy();
					}
					else
					{
						Debug.LogError("VISUAL = NULL");
					}
				}
				if (requestResult["PowerBandId"] != null && requestResult["PowerBandExpiresOn"] != null)
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(StringParser.ParseString(requestResult["PowerBandId"], string.Empty));
					if (powerBand != null)
					{
						Debug.Log("ADDING POWERBAND ON CLIENT " + requestResult["PowerBandId"]);
						powerBand.Buy();
						powerBand.setExpiresOn(StringParser.ParseIntToken(requestResult["PowerBandExpiresOn"]));
						powerBand.Equip();
					}
					else
					{
						Debug.LogError("POWER BAND = NULL");
					}
				}
				if (requestResult["Weapon"] != null)
				{
					WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(StringParser.ParseString(requestResult["Weapon"], string.Empty));
					if (weaponLevelsSetup != null)
					{
						Debug.Log("ADDING WEAPON ON CLIENT" + requestResult["Weapon"]);
						weaponLevelsSetup.bought = true;
					}
					else
					{
						Debug.LogError("ADDED WEAPON = NULL");
					}
				}
				if (requestResult["AssignmentData"] != null)
				{
					AssignmentsManager.instance.LoadData(StringParser.ParseString(requestResult["AssignmentData"], string.Empty));
					Debug.Log("Yay! New daily assignments!");
				}
				break;
			case DatabaseResult.IncorrentStarterAssignments:
			case DatabaseResult.IncorrectStarterAssignmentReward:
				Debug.LogError("ERROR CLAIM STARTER ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED " + databaseResult);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), 0f, null, string.Empty, useDialogBackground: true);
				StarterAssignmentsManager.instance.LoadData(StringParser.ParseString(requestResult["StarterAssignmentsData"], string.Empty));
				Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				break;
			}
			break;
		case DatabaseAction.BuyCardPack:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case DatabaseResult.NotEnoughWarbucks:
			case DatabaseResult.CardPackNotFound:
				CardManager.instance.LoadData(requestResult["CardManagerData"]);
				Singleton<Wallet>.instance.Init(StringParser.ParseLongToken(requestResult["Gold"], 0L), StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!"));
				errorMessage = string.Concat(errorMessage, databaseAction, " (not enough warbucks), ");
				break;
			case DatabaseResult.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				CardManager.instance.LoadData(requestResult["CardManagerData"]);
				Singleton<Wallet>.instance.Init(StringParser.ParseLongToken(requestResult["Gold"], 0L), StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				Singleton<OfferManager>.instance.UpdateFromServer(requestResult["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			break;
		case DatabaseAction.BuyWeaponUpgrade:
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.WeaponWasShown:
		case DatabaseAction.InstantBuyWeapon:
		case DatabaseAction.ActivateWeapon:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				if (requestResult["DeliveryTime"] != null && isLast)
				{
					Debug.Log("Setting weapon delivery");
					LevelManager.instance.SetWeaponDeliveryTime(requestResult["DeliveryTime"]);
				}
				break;
			case DatabaseResult.NotEnoughWarbucks:
			case DatabaseResult.NotEnoughLevel:
			case DatabaseResult.AlreadyMaximumUpgrade:
			case DatabaseResult.NotEnoughGold:
			case DatabaseResult.WrongIndexToActivate:
			case DatabaseResult.AlreadyUpgrading:
			case DatabaseResult.TooSoonToActivate:
			case DatabaseResult.WeaponNotBought:
			case DatabaseResult.PriceNotFound:
			case DatabaseResult.PriceDidntCorrespond:
			case DatabaseResult.NegativePriceFromClient:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (", databaseResult, "), ");
				if (requestResult["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				}
				if (requestResult["Gold"] != null)
				{
					Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				}
				if (requestResult["weaponDelivery"] != null)
				{
					LevelManager.instance.UpdateWeaponDelivery(requestResult["weaponDelivery"]);
				}
				LevelManager.instance.UpdateWeapon(StringParser.ParseString(requestResult["LevelName"], string.Empty), requestResult["Weapon"]);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			case DatabaseResult.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				if (requestResult["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				}
				if (requestResult["Gold"] != null)
				{
					Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				}
				if (requestResult["weaponDelivery"] != null)
				{
					LevelManager.instance.UpdateWeaponDelivery(requestResult["weaponDelivery"]);
				}
				LevelManager.instance.UpdateWeapon(StringParser.ParseString(requestResult["LevelName"], string.Empty), requestResult["Weapon"]);
				Singleton<OfferManager>.instance.UpdateFromServer(requestResult["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			Singleton<NotificationManager>.instance.UpdateWeaponDelivery();
			break;
		case DatabaseAction.BuyUnitUpgrade:
		case DatabaseAction.InstantUnitUpgrade:
		case DatabaseAction.ActivateUnitUpgrade:
		case DatabaseAction.BuyUnit:
		case DatabaseAction.ArmyUnitWasShown:
		case DatabaseAction.InstantBuyUnit:
		case DatabaseAction.ActivateUnit:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				if (requestResult["DeliveryTime"] != null && isLast)
				{
					Debug.Log("Setting unit delivery");
					LevelManager.instance.SetUnitDeliveryTime(requestResult["DeliveryTime"]);
				}
				break;
			case DatabaseResult.NotEnoughWarbucks:
			case DatabaseResult.NotEnoughLevel:
			case DatabaseResult.AlreadyMaximumUpgrade:
			case DatabaseResult.NotEnoughGold:
			case DatabaseResult.WrongIndexToActivate:
			case DatabaseResult.AlreadyUpgrading:
			case DatabaseResult.TooSoonToActivate:
			case DatabaseResult.PriceNotFound:
			case DatabaseResult.PriceDidntCorrespond:
			case DatabaseResult.NegativePriceFromClient:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", databaseResult, "), ");
				if (requestResult["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				}
				if (requestResult["Gold"] != null)
				{
					Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				}
				if (requestResult["unitDelivery"] != null)
				{
					LevelManager.instance.UpdateUnitDelivery(requestResult["unitDelivery"]);
				}
				LevelManager.instance.UpdateUnit(StringParser.ParseString(requestResult["LevelName"], string.Empty), requestResult["Unit"]);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			case DatabaseResult.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				if (requestResult["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				}
				if (requestResult["Gold"] != null)
				{
					Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				}
				if (requestResult["unitDelivery"] != null)
				{
					LevelManager.instance.UpdateUnitDelivery(requestResult["unitDelivery"]);
				}
				LevelManager.instance.UpdateUnit(StringParser.ParseString(requestResult["LevelName"], string.Empty), requestResult["Unit"]);
				Singleton<OfferManager>.instance.UpdateFromServer(requestResult["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			Singleton<NotificationManager>.instance.UpdateUnitDelivery();
			break;
		case DatabaseAction.BuyDecal:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				CamosManager.instance.data.visuals[StringParser.ParseString(requestResult["DecalId"], string.Empty)].expiresOn = StringParser.ParseIntToken(requestResult["ExpiresOn"]);
				break;
			case DatabaseResult.NotEnoughWarbucks:
			case DatabaseResult.NotEnoughLevel:
			case DatabaseResult.NotEnoughGold:
			case DatabaseResult.DecalOnlyForVip:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", databaseResult, "), ");
				if (requestResult["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				}
				if (requestResult["Gold"] != null)
				{
					Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				}
				CamosManager.instance.LoadData(StringParser.ParseString(requestResult["DecalManagerData"], string.Empty));
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			case DatabaseResult.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				if (requestResult["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLongToken(requestResult["WarBucks"], 0L));
				}
				if (requestResult["Gold"] != null)
				{
					Singleton<Wallet>.instance.InitGold(StringParser.ParseLongToken(requestResult["Gold"], 0L));
				}
				CamosManager.instance.LoadData(StringParser.ParseString(requestResult["DecalManagerData"], string.Empty));
				Singleton<OfferManager>.instance.UpdateFromServer(requestResult["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			break;
		case DatabaseAction.VisualWasShown:
		{
			DatabaseResult databaseResult2 = databaseResult;
			if (databaseResult2 == DatabaseResult.Success)
			{
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
			}
			break;
		}
		case DatabaseAction.DecalWasShown:
		case DatabaseAction.EquipDecal:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				if (requestResult["DecalManagerData"] != null)
				{
					CamosManager.instance.LoadData(StringParser.ParseString(requestResult["DecalManagerData"], string.Empty));
				}
				break;
			case DatabaseResult.DecalNotBought:
			case DatabaseResult.DecalCategoryNotFound:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", databaseResult, "), ");
				CamosManager.instance.LoadData(StringParser.ParseString(requestResult["DecalManagerData"], string.Empty));
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			}
			break;
		case DatabaseAction.UpgradeEliteSlot:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case DatabaseResult.WrongIndexToActivate:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGINDEXTOACTIVATEELITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case DatabaseResult.NotEnoughWarbucks:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHWARBUCKSFORELITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case DatabaseResult.NotEnoughParts:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTAMOUNTOFELITEPARTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case DatabaseResult.IncorrectValuesOnClient:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTVALUESONCLIENT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			}
			break;
		case DatabaseAction.ConvertPartsToScraps:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case DatabaseResult.EliteSlotLocked:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ELITESLOTLOCKED"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case DatabaseResult.IncorrectPartsAmount:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTELITEPARTSAMOUNT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			}
			break;
		case DatabaseAction.ConvertScrapsToParts:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case DatabaseResult.NotEnoughScraps:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHSCRAPS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			}
			break;
		case DatabaseAction.EquipWeapon:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case DatabaseResult.WeaponNotBought:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				LevelManager.instance.UpdateWeapon(StringParser.ParseString(requestResult["LevelName"], string.Empty), requestResult["Weapon"]);
				PlayerInventory.instance.LoadData(StringParser.ParseString(requestResult["InventoryData"], string.Empty));
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			}
			break;
		case DatabaseAction.AcceptRentalOffer:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				JToken jToken = requestResult["Rental"];
				string text2 = jToken["Id"].ToString();
				switch (jToken["Type"].ToObject<GameItem>())
				{
				case GameItem.ArmyUnit:
				{
					if (LevelManager.instance.data.savedArmies.TryGetValue(text2, out var value2))
					{
						value2.borrowed = true;
					}
					else
					{
						Debug.LogError($"rental for unexist unit: {text2}");
					}
					break;
				}
				case GameItem.Weapon:
				{
					if (LevelManager.instance.data.savedWeapons.TryGetValue(text2, out var value))
					{
						value.borrowed = true;
					}
					else
					{
						Debug.LogError($"rental for unexist weapon: {text2}");
					}
					break;
				}
				case GameItem.PlayerVisual:
					if (CamosManager.instance.data.visuals.ContainsKey(text2))
					{
						CamosManager.instance.data.visuals[text2].borrowed = true;
					}
					else
					{
						Debug.LogError($"rental for unexist visual: {text2}");
					}
					break;
				}
				break;
			}
			case DatabaseResult.NoRentalFound:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", databaseResult));
				string text = errorMessage;
				errorMessage = string.Concat(text, databaseAction, " (#", (int)databaseResult, "), ");
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			}
			return errorMessage;
		case DatabaseAction.UpdateEquippedUnits:
			switch (databaseResult)
			{
			case DatabaseResult.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				GuiElementSingle<ChatGuiElement>.instance.activeUnitsContent.DatabaseResult(dbSuccess: true);
				GuiScreenSingle<ArmyScreen>.instance.EquippedUnitsUpdate();
				break;
			case DatabaseResult.CantEquipUnit:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK! Load army data from DB"));
				Dictionary<string, object> dictionary = ((requestResult["data"] == null) ? null : JsonConvert.DeserializeObject<Dictionary<string, object>>(StringParser.ParseString(requestResult["data"], string.Empty)));
				if (dictionary != null)
				{
					foreach (KeyValuePair<string, object> item2 in dictionary)
					{
						string key = item2.Key;
						LevelManager.instance.UpdateUnit(key, item2.Value.ToString());
						Debug.Log($"data saved in DB for unit {key} : {item2.Value.ToString()}");
					}
				}
				GuiElementSingle<ChatGuiElement>.instance.activeUnitsContent.DatabaseResult(dbSuccess: false);
				GuiScreenSingle<ArmyScreen>.instance.EquippedUnitsUpdate();
				break;
			}
			}
			break;
		}
		if (databaseResult == DatabaseResult.Success)
		{
			PushNotificationManager.instance.ScheduleLocalNotifications(databaseAction);
		}
		else
		{
			PushNotificationManager.instance.RescheduleLocalNotificationsAfterError(databaseAction);
		}
		return errorMessage;
	}

	private void OnSetPlayerStatus()
	{
		if (!mResponse.ContainsKey("IsOffline"))
		{
			mServerTime.Init(StringParser.ParseInt(mResponse["Time"]));
		}
	}

	private void OnSkipAssignment()
	{
		LoadingDialog.Hide();
		Debug.Log("Skip assignment success");
		AssignmentsManager.instance.LoadData(StringParser.ParseString(mResponse["AssignmentData"], string.Empty));
		Singleton<Wallet>.instance.WarBucksSpent(StringParser.ParseInt(mResponse["WarBucksSkipPrice"]));
	}

	private void OnGetNewAssignments()
	{
		Debug.Log("BS: On Get New Assignemnts");
		AssignmentsManager.instance.LoadData(StringParser.ParseString(mResponse["AssignmentData"], string.Empty));
	}

	private void OnTutorialStarted()
	{
		string text = StringParser.ParseString(mResponse["BattleId"], string.Empty);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<GameController>.instance.battleId = text;
		}
		Singleton<GameController>.instance.ContinueTutorialImmediately();
	}

	private void OnUpdateDeviceToken()
	{
		Debug.Log("Beanstalk: On Update device token");
	}

	private void OnUpdateSquadEmblem()
	{
		Debug.Log("Emblem updated!");
	}
}
