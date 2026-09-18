using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ServerErrorHandler
{
	public static string test()
	{
		return "21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----";
	}

	public static void Retry()
	{
		Singleton<GameController>.instance.TryStopLoading();
		Singleton<GameController>.instance.Quit();
		Singleton<BeanstalkServerManager>.instance.waitForInput = true;
		WarningDialog.ShowError(Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, delegate
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.Log("RETRY");
			GameLoginManager.Relog();
			LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
			Singleton<BeanstalkServerManager>.instance.waitForInput = false;
		}, Localization.Localize("ID_RETRY"), useDialogBackground: true);
	}

	internal void HandleException(Exception exception, DatabaseAction databaseAction, List<Tuple<string, string>> postData)
	{
		DialogManager.instance.HideAllDialogs();
		switch (databaseAction)
		{
		case DatabaseAction.GetPlayerData:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		case DatabaseAction.GameStartedMaster:
		case DatabaseAction.GameStartedClient:
		case DatabaseAction.GameStartedCampaign:
		case DatabaseAction.GameStartedCoopMaster:
		case DatabaseAction.GameStartedCoopClient:
		case DatabaseAction.GameStartedTutorial:
			ServerErrorReceived(DatabaseResult.CouldNotStartGame, null, databaseAction, postData);
			break;
		case DatabaseAction.GameEnded:
			ServerErrorReceived(DatabaseResult.ServerRespondedWithError, null, databaseAction, postData);
			break;
		default:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		}
	}

	internal void ServerErrorReceived(DatabaseResult resultCode, Dictionary<string, object> response, DatabaseAction action, List<Tuple<string, string>> postData)
	{
		DialogManager.instance.HideAllDialogs();
		if (resultCode != DatabaseResult.ServerMaintenance)
		{
			LoadingDialog.Hide();
		}
		if (action == DatabaseAction.GameEnded && Singleton<GameController>.instance.gameState == GameController.GameState.Playing && resultCode != DatabaseResult.ThroughputExceededException)
		{
			Singleton<GameController>.instance.errorReason = resultCode;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.ServerResponse.Error;
			return;
		}
		switch (action)
		{
		case DatabaseAction.EnterArena:
			EnterArenaRequest.OnError(resultCode, response);
			break;
		case DatabaseAction.WarArenaEnded:
			WarArenaEndedRequest.OnError(resultCode, response);
			break;
		}
		switch (resultCode)
		{
		case DatabaseResult.ServerMaintenance:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_MAINTENANCE_TEXT"), Localization.Localize("ID_WARNING_MAINTENANCE"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, Localization.Localize("ID_RETRY"), useDialogBackground: true);
			break;
		case DatabaseResult.SquadnameTaken:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADNAMETAKEN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.CardNotFound:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			if (response.ContainsKey("DepositedCards"))
			{
				Dictionary<string, string> depositedCards = JsonConvert.DeserializeObject<Dictionary<string, string>>(StringParser.ParseString(response["DepositedCards"], string.Empty));
				GameLoginManager.instance.SetDepositedCards(depositedCards);
			}
			CardCraftingManager.instance.waitingForServerResponse = false;
			CardManager.instance.LoadData(StringParser.ParseString(response["CardManagerData"], string.Empty));
			break;
		case DatabaseResult.AlreadyCrafting:
			Debug.LogError("Error: Player is already crafting -> loading craft data from server");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ALREADYCRAFTING"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			CardCraftingManager.instance.LoadData(StringParser.ParseString(response["CraftData"], string.Empty));
			break;
		case DatabaseResult.BuddyCardNotReady:
		{
			Debug.LogError("Error: Buddy card not ready! " + StringParser.ParseString(response["CardManagerData"], string.Empty));
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_BUDDYCARDNOTREADY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			Dictionary<string, object> depositedCards3 = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringParser.ParseString(response["DepositedCards"], string.Empty));
			GameLoginManager.instance.SetDepositedCards(depositedCards3);
			CardManager.instance.LoadData(StringParser.ParseString(response["CardManagerData"], string.Empty));
			break;
		}
		case DatabaseResult.SquadWarProcessing:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_SQUADWARPROCESSING"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case DatabaseResult.CraftedCardNotReady:
			Debug.LogError("Error: Crafted card not ready!");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CRAFTINGCLAIMNOTREADY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			CardCraftingManager.instance.LoadData(StringParser.ParseString(response["CraftData"], string.Empty));
			break;
		case DatabaseResult.NotEnoughGoldForHeart:
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHGOLDHEARTH"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			int num3 = StringParser.ParseInt(response["MyGolds"]);
			Singleton<Wallet>.instance.InitGold(num3);
			int num4 = StringParser.ParseInt(response["TicketsCount"]);
			Singleton<Wallet>.instance.InitTickets(num4);
			break;
		}
		case DatabaseResult.NotEnoughTicketsForHeart:
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTICKETSHEARTH"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			int num = StringParser.ParseInt(response["MyTickets"]);
			Singleton<Wallet>.instance.InitTickets(num);
			break;
		}
		case DatabaseResult.CardAlreadyWithdrawn:
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_WARCARDNOTAVAILABLE"), Localization.Localize("ID_CONFIRM_SELECTEDWARCARDWASALREADY"), 0f);
			Dictionary<string, object> depositedCards2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringParser.ParseString(response["DepositedCards"], string.Empty));
			GameLoginManager.instance.SetDepositedCards(depositedCards2);
			CardManager.instance.LoadData(StringParser.ParseString(response["CardManagerData"], string.Empty));
			break;
		}
		case DatabaseResult.WithdrawNotYetAvailable:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			CardManager.instance.nextWithdraw = StringParser.ParseInt(response["NextWithdraw"]);
			break;
		case DatabaseResult.WrongWarArenaHeartPrice:
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGPRICEFORHEART"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			int num13 = StringParser.ParseInt(response["ClientPrice"]);
			int num14 = StringParser.ParseInt(response["ServerPrice"]);
			bool flag = StringParser.ParseBool(response["PayWithTickets"]);
			Debug.LogError(string.Format("Server price {0} != client price {1} ({2}) ", num14, num13, (!flag) ? "golds" : "tickets"));
			break;
		}
		case DatabaseResult.SquadAlreadyExists:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADALREADYEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.CouldNotStartGame:
			Debug.Log("Error: Could not start game " + action);
			Singleton<BeanstalkServerManager>.instance.MatchMakingGameWasCreated(result: false);
			break;
		case DatabaseResult.IncorrectAssignments:
			Debug.LogError("Error: Incorrect assignments " + action);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTASSIGNMENTS_TEXT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			AssignmentsManager.instance.LoadData(StringParser.ParseString(response["AssignmentData"], string.Empty));
			break;
		case DatabaseResult.SquadIsNotPublic:
			LoadingDialog.Hide();
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC"), Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT"), 0f);
			break;
		case DatabaseResult.SquadJoinRequestNotExists:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADJOINREQUESTNOTEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			if (response.ContainsKey("PlayerId"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(response["PlayerId"].ToString(), updateGUI: true);
			}
			break;
		case DatabaseResult.PlayerAlreadyInSquad:
		{
			string text3 = ((!response.ContainsKey("Name")) ? string.Empty : response["Name"].ToString());
			WarningDialog.ShowError(Localization.Localize("ID_PLAYERCANTJOINSQUAD"), Localization.LocalizeFormat("ID_ISALREADYMEMBEROFANOTHERSQUAD", text3), 0f, null, string.Empty);
			if (response.ContainsKey("PlayerId"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(response["PlayerId"].ToString(), updateGUI: true);
			}
			break;
		}
		case DatabaseResult.PlayerAlreadyInSquadCantJoin:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		case DatabaseResult.NotEnoughSkill:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.NotForGuestAccount:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTFORQUESTACCOUNTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.GameCenterAlreadyCreated:
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			DatabasePlayerData databasePlayerData = DatabasePlayerData.CreateFromDatabase((JToken)response["PlayerData"]);
			string gcId = StringParser.ParseString(response["GameCenterId"], string.Empty);
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.GameCenter, delegate(bool result)
			{
				if (result)
				{
					Debug.Log("Error Handler: Player si vybral zruseni GC uctu a pridani udaju k tomuto uctu");
					LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
					GameLoginManager.instance.acountDataDownloadingInProgress = true;
					Singleton<BeanstalkServerManager>.instance.AddGameCenter(gcId, removeOld: true);
				}
				else
				{
					Debug.Log("Error Handler: Player si vybral starsi account!");
					DialogManager.instance.HideAllDialogs();
					Singleton<MessageManager>.instance.ClearAllMessages();
					StatsManager.instance.dailyRewardData = null;
					LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
					GameLoginManager.instance.acountDataDownloadingInProgress = true;
					Singleton<GameController>.instance.InteruptStartingTutorial();
					Singleton<BeanstalkServerManager>.instance.CreateGcAccount(gcId);
				}
			}, databasePlayerData.accountName, databasePlayerData.level, databasePlayerData.skill, string.Empty);
			break;
		}
		case DatabaseResult.NoOffers:
			Debug.Log("No Offer Available (has all already)");
			break;
		case DatabaseResult.SquadIsFull:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADISFULL"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.SquadNoLongerExists:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTEXISTINGSQUAD"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.JoiningSameSquad:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_JOININGSAMESQUAD"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case DatabaseResult.SquadNotEmpty:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADNOTEMPTY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.SquadLeaveError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADLEAVEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.PlayerNameTaken:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PLAYERNAMETAKEN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.PlayerAlreadyExists:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PLAYERALREADYEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.PromotePlayerError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			BeanstalkServerManager.LoadSquadMembers(response);
			break;
		case DatabaseResult.DemotePlayerError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			BeanstalkServerManager.LoadSquadMembers(response);
			break;
		case DatabaseResult.AccountAlreadyCreatedOnDifferentPlatform:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ACCOUNTALREADYCREATED"), Localization.Localize("ID_WARNING_LOGINERROR"), 0f, null, string.Empty);
			GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
			if (response.ContainsKey("Os"))
			{
				Debug.LogError("Account is in platform: " + response["Os"]);
			}
			break;
		case DatabaseResult.PromoteToFounderError:
		case DatabaseResult.KickPlayerError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.OnlyLeaderCanSendInvites:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ONLYLEADERSCANINVITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.NoSuchPackExists:
		case DatabaseResult.InvalidInapp:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOSUCHPACK"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case DatabaseResult.ServerDidntRespondBeforeGame:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SERVERDIDNOTRESPOND"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
			}
			break;
		case DatabaseResult.GameAlreadyEnded:
		case DatabaseResult.GameDidntExist:
		case DatabaseResult.ServerDidntRespondAfterGame:
			Singleton<GameController>.instance.errorReason = resultCode;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.ServerResponse.Error;
			break;
		case DatabaseResult.NotEnoughDogtags:
		case DatabaseResult.BattleAlreadyExists:
		case DatabaseResult.NoSkirmishAvailable:
			Debug.LogError("ERROR FROM SERVER " + resultCode);
			if (!Singleton<GameController>.instance.isInMenuOrWait)
			{
				break;
			}
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<GameController>.instance.TryStopLoading();
			Singleton<GameController>.instance.Quit();
			if (resultCode == DatabaseResult.NoSkirmishAvailable)
			{
				WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOSKIRMISHAVAILABLE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTENOUGHDOGTAGS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
			}
			break;
		case DatabaseResult.NotEnoughGoldForSkirmish:
		{
			int number2 = StringParser.ParseInt(response["SkirmishCost"]);
			PlayerAnalytics.instance.data.paidInstantBattles = StringParser.ParseInt(response["PaidBattles"]);
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(number2, Localization.Localize("ID_INSTANTBATTLE"));
			Singleton<Wallet>.instance.InitGold(StringParser.ParseLong(response["PlayerGold"], 0L));
			break;
		}
		case DatabaseResult.NotEnoughGoldForDogtags:
		{
			int number = StringParser.ParseInt(response["DogtagPrice"]);
			long initGold = StringParser.ParseLong(response["PlayerGold"], 0L);
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(number, Localization.Localize("ID_DOGTAGSREFILL"));
			Singleton<Wallet>.instance.InitGold(initGold);
			break;
		}
		case DatabaseResult.NotEnoughGoldForChangeName:
		{
			int num11 = StringParser.ParseInt(response["RenameCount"]);
			long num12 = StringParser.ParseLong(response["PlayerGold"], 0L);
			Debug.LogError("ServerErrorHandler: renameCount = " + num11 + ", playerGold1 = " + num12);
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("ID_CHANGENAMENOTENOUGHT"));
			Singleton<Wallet>.instance.InitGold(num12);
			break;
		}
		case DatabaseResult.NotEnoughWarBucksForCreateSquad:
		{
			int num9 = StringParser.ParseInt(response["squadCreationsCnt"]);
			long num10 = StringParser.ParseLong(response["PlayerWB"], 0L);
			Debug.LogError("ServerErrorHandler: squadCreationsCount = " + num9 + ", playerWB = " + num10);
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(PlayerAnalytics.instance.createSquadWarBucksPrice, Localization.Localize("ID_CREATESQUADNOTENOUGH"));
			Singleton<Wallet>.instance.InitWarBucks(num10);
			break;
		}
		case DatabaseResult.NotEnoughGoldForVip:
		{
			string text7 = StringParser.ParseString(response["vipId"], string.Empty);
			int num7 = StringParser.ParseInt(response["VIPCost"]);
			long num8 = StringParser.ParseLong(response["PlayerGold"], 0L);
			Debug.LogError($"VIPCost = {num7}, playerGold2 = {num8}, id = {text7}");
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num7, Localization.Localize("ID_VIPSTATUS"));
			Singleton<PurchaseProtection>.instance.VIPResponseCame(text7);
			Singleton<Wallet>.instance.InitGold(num8);
			break;
		}
		case DatabaseResult.NotEnoughGoldForLootboxes:
		{
			string text6 = StringParser.ParseString(response["lootboxId"], string.Empty);
			int num5 = StringParser.ParseInt(response["LootboxesCost"]);
			long num6 = StringParser.ParseLong(response["PlayerGold"], 0L);
			Debug.LogError($"lootboxesCost = {num5}, playerGold = {num6}, id= {text6}");
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num5, Localization.Localize("ID_LOOTBOXES"));
			Singleton<PurchaseProtection>.instance.LootboxResponseCame(text6);
			Singleton<Wallet>.instance.InitGold(num6);
			break;
		}
		case DatabaseResult.NotEnoughLevelForPromote:
		{
			string text4 = StringParser.ParseString(response["playerLevel"], string.Empty);
			string text5 = StringParser.ParseString(response["requiredLevel"], string.Empty);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTLEVEL"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		}
		case DatabaseResult.NoRewardToClaim:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD_TEXT"), Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD"), 0f, null, string.Empty);
			break;
		case DatabaseResult.NotLeaderOfSquad:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD"), Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT"), 0f);
			break;
		case DatabaseResult.NotEnoughSquadLevel:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL"), Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT"), 0f);
			break;
		case DatabaseResult.NotEnoughWarbucksForSkip:
			Singleton<Wallet>.instance.InitWarBucks(StringParser.ParseLong(response["WarBucks"], 0L));
			break;
		case DatabaseResult.WrongPlayerData:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			ConfirmDialog.ShowAlert(delegate
			{
				Debug.Log("Player was removed from db!");
				GameLoginManager.Relog();
			}, Localization.Localize("ID_CONFIRM_JOINSQUADEVENT"), Localization.Localize("ID_CONFIRM_WRONGPLAYERDATA"));
			break;
		case DatabaseResult.NoActiveEvent:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_JOINSQUADEVENT"), Localization.Localize("ID_CONFIRM_NOTACTIVEEVENT"), 0f);
			break;
		case DatabaseResult.LoginFailure:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			ConfirmDialog.ShowAlert(delegate
			{
				Debug.Log("Delete QuickPlay Data");
				GameLoginManager.instance.DeletePlayerAccount();
				GameLoginManager.Relog();
			}, Localization.Localize("ID_CONFIRM_LOGINFAILURE"), Localization.Localize("ID_CONFIRM_LOGINFAILURE_TEXT"));
			break;
		case DatabaseResult.AccountBanned:
		{
			string text = "null";
			string text2 = "null";
			if (response.ContainsKey("accountId"))
			{
				text = response["accountId"].ToString();
			}
			if (response.ContainsKey("accountName"))
			{
				text2 = response["accountName"].ToString();
			}
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			string empty = string.Empty;
			if (response.ContainsKey("seconds"))
			{
				int num2 = StringParser.ParseInt(response["seconds"]);
				empty = Localization.LocalizeFormat("ID_CONFIRM_TEMPORARBAN", text, text2, MiscTools.PrintableTimeLongForm(num2));
			}
			else
			{
				empty = Localization.LocalizeFormat("ID_CONFIRM_PERMANENTBAN", text, text2);
			}
			WarningDialog.ShowError(empty, Localization.Localize("ID_CONFIRM_ACCOUNTBANNED"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, Localization.Localize("ID_RETRY"), useDialogBackground: true, response.ContainsKey("canSendLogs"));
			break;
		}
		case DatabaseResult.InvalidToken:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				if (response.ContainsKey("Token"))
				{
					Debug.LogError("Beanstalk: Invalid Token - " + response["Token"]);
				}
				else
				{
					Debug.LogError("Beanstlak: Invalid Token -> unknown");
				}
				ConfirmDialog.ShowAlert(delegate
				{
					GameLoginManager.Relog();
				}, Localization.Localize("ID_CONFIRM_LOGGEDOUT"), Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT"));
			}
			break;
		case DatabaseResult.OldToken:
		case DatabaseResult.UnAuthorizedAction:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Debug.LogError("Beanstalk: OLD TOKEN!!");
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				GameLoginManager.Relog();
			}
			break;
		case DatabaseResult.OldClientVersion:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.waitForInput = true;
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<NewVersionDialog>.instance, 0f);
			Singleton<BeanstalkServerManager>.instance.waitForInput = false;
			break;
		case DatabaseResult.PlayerNotExists:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			ConfirmDialog.ShowAlert(delegate
			{
				Debug.Log("Player was removed from db!");
				GameLoginManager.instance.DeletePlayerAccount();
				GameLoginManager.Relog();
			}, Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS"), Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS_TEXT"));
			break;
		case DatabaseResult.RewardWasAlreadyAdded:
			PlayerAnalytics.instance.AddOneTimeReward(StringParser.ParseString(response["RewardId"], string.Empty));
			Debug.LogError("Reward Was Already Added!!");
			break;
		case DatabaseResult.NoDiscountFound:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
			if (response.ContainsKey("SpecialOffers"))
			{
				Singleton<OfferManager>.instance.UpdateFromServer((JToken)response["SpecialOffers"]);
			}
			else
			{
				Singleton<OfferManager>.instance.UpdateFromServer(null);
			}
			if (response.ContainsKey("Id"))
			{
				string id = StringParser.ParseString(response["Id"], string.Empty);
				switch (action)
				{
				case DatabaseAction.BuyLootboxes:
					Singleton<PurchaseProtection>.instance.LootboxResponseCame(id);
					break;
				case DatabaseAction.BuyVip:
					Singleton<PurchaseProtection>.instance.VIPResponseCame(id);
					break;
				}
			}
			Debug.LogError("NO DISCOUNT FOUND!!! " + action);
			break;
		}
	}
}
