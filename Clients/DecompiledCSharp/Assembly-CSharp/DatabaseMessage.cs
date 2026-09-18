using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DatabaseMessage
{
	public enum Type
	{
		ChallengeIgnored = 15,
		VipCards = 50,
		DailyReward = 51,
		EnablePushNotificationMessage = 52,
		RateAppMessage = 52,
		RewardMessage = 53,
		DailyRental = 54,
		BannedFromChat = 17,
		UnitReadyForPromotion = 18,
		WelcomBackSoldierMessage = 19,
		Challenge = 0,
		CheatWarning = 12,
		LeagueEntered = 7,
		SquadDemotion = 3,
		SquadEventEntered = 18,
		SquadEventTierReward = 11,
		SquadEventEnded = 19,
		SquadInvitation = 1,
		SquadJoined = 14,
		SquadJoinRequest = 13,
		SquadLevelUp = 10,
		SquadPromotion = 4,
		SquadWarEnd = 9,
		NonExistingSquadWarsEnd = 16,
		BeAdvisedConnectFacebook = 70,
		BeAdvisedJoinOrCreateSquad = 71,
		BeAdvisedPurchaseVIP = 72,
		SystemMessage = 20,
		VIPMemeberShipAlmostEnded = 73,
		VIPMembershipExpired = 74,
		UpgradeWeaponReminder = 75,
		UpgradeUnitReminder = 76,
		PowerBandBuyAfterLose = 77,
		BuyCardsReminder = 78,
		LikeUsOnFacebook = 79,
		TweetAboutWarfriends = 80,
		FollowUsOnTwitter = 81,
		InformSquadLeaderAboutEvent = 21,
		HitlistLogedIn = 33,
		SquadLeft = 34,
		NameChangeReminder = 35,
		TimeLimitedOffer = 36,
		NewSquadJoinRequest = 22,
		PlayerLeagueFinished = 23,
		WeaponTutorialDialogMessage = 24,
		SquadMemberGameEnded = 25,
		SquadDepositedCardsChanged = 26,
		SpecialOfferMessage = 90,
		UnitCategoriesReminder = 91,
		InGameMessage = 27,
		DepositWarcards = 28,
		StarterPackTimeLimitedOffer = 29,
		ChatTutorialMessage = 30,
		CardpoolTutorialMessage = 31,
		CustomizationTutorialMessage = 32,
		StarterAssignmentsReward = 33,
		DailyAssignmentsReminder = 34,
		DailyGoldBooster = 35,
		ArenaUnlockedMessage = 36,
		BuyHearthMessage = 37,
		ArenaLostMessage = 38,
		ArenaVisualMessage = 39,
		ArenaShieldsMessage = 40,
		ArenaOpenedMessage = 41,
		ArenaWonMessage = 42,
		InstantBattleUnlockedMessage = 43,
		ArenaGoldenShieldMessage = 44,
		ElitePerkTutorialMessage = 45
	}

	public string messageId;

	public Type messageType;

	public int messageTime;

	public string playerId;

	private bool mServerMessage;

	private bool mMessageShown;

	public bool wasIgnored;

	private bool mShown;

	public bool messageShown
	{
		get
		{
			return mMessageShown;
		}
		set
		{
			if (value && !mMessageShown && mServerMessage)
			{
				Singleton<MessageManager>.instance.SentDatabaseMessageWasShown(messageId, playerId);
			}
			mMessageShown = value;
		}
	}

	public virtual bool actionLeavesLobby => false;

	public virtual bool canBeClickedInLobby => true;

	public virtual bool processNextMessage => false;

	public virtual bool canSquadTypeMessageBeRemovedWhenLeftSquad => true;

	public DatabaseMessage(JToken dict)
	{
		if (dict.First != null)
		{
			if (dict["MessageId"] != null)
			{
				messageId = dict["MessageId"]["S"].ToObject<string>();
				messageTime = Convert.ToInt32(Regex.Replace(messageId, "^.*-", string.Empty));
			}
			if (dict["PlayerId"] != null)
			{
				playerId = dict["PlayerId"]["S"].ToObject<string>();
			}
			if (dict["MessageType"] != null)
			{
				messageType = (Type)dict["MessageType"]["N"].ToObject<int>();
			}
			if (dict["WasShown"] != null)
			{
				mMessageShown = true;
			}
			mServerMessage = true;
		}
	}

	public DatabaseMessage(string id, Type typ)
	{
		messageId = id + DateTime.Now.Day;
		playerId = GameLoginManager.currentPlayer.id;
		messageType = typ;
		messageTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public void Ignore()
	{
		Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(messageId);
		wasIgnored = true;
	}

	public static DatabaseMessage CreateFromDatabase(JToken dict, Type messageType)
	{
		switch (messageType)
		{
		case Type.NonExistingSquadWarsEnd:
		{
			Debug.LogError("DatabaseMessage - No long existing database message came from server!");
			DatabaseMessage databaseMessage = new DatabaseMessage(dict);
			databaseMessage.Ignore();
			return databaseMessage;
		}
		case Type.Challenge:
			return new ChallengeMessage(dict);
		case Type.SquadInvitation:
			return new SquadInviteMessage(dict);
		case Type.SquadDemotion:
			return new SquadDemoteMessage(dict);
		case Type.SquadJoinRequest:
			return new SquadJoinRequest(dict);
		case Type.SquadPromotion:
			return new SquadPromoteMessage(dict);
		case Type.LeagueEntered:
			return new LeagueEnterMessage(dict);
		case Type.SquadWarEnd:
			return new SquadWarsEndedMessage(dict);
		case Type.SquadLevelUp:
			return new SquadLevelUpMessage(dict);
		case Type.UnitReadyForPromotion:
			return new SquadEventEnteredMessage(dict);
		case Type.SquadEventTierReward:
			return new SquadEventTierRewardMessage(dict);
		case Type.WelcomBackSoldierMessage:
			return new SquadEventEndedMessage(dict);
		case Type.CheatWarning:
			return new CheatWarningMessage(dict);
		case Type.SquadJoined:
			return new SquadJoinedMessage(dict);
		case Type.ChallengeIgnored:
			return new ChallengeIgnored(dict);
		case Type.SystemMessage:
			return new SystemMessage(dict);
		case Type.BannedFromChat:
			return new BanMessage(dict);
		case Type.InformSquadLeaderAboutEvent:
			return new InformSquadLeaderAboutEvent(dict);
		case Type.SquadLeft:
			return new SquadLeftMessage(dict);
		case Type.NewSquadJoinRequest:
			return new NewSquadJoinRequest(dict);
		case Type.PlayerLeagueFinished:
			return new PlayerLeagueFinished(dict);
		case Type.SquadMemberGameEnded:
			return new SquadMemberGameEnded(dict);
		case Type.SquadDepositedCardsChanged:
			return new WithdrewWarcard(dict);
		case Type.InGameMessage:
			return new InGameMessage(dict);
		case Type.DepositWarcards:
			return new DepositWarcards(dict);
		default:
			return new DatabaseMessage(dict);
		}
	}

	internal static DatabaseMessage CreateFromDatabase(JToken dict, string messageId)
	{
		try
		{
			Type type = (Type)Convert.ToInt32(Regex.Replace(messageId, "-.*$", string.Empty));
			string text = "{ \"S\": \"" + messageId + "\"}";
			Debug.Log("JSON = " + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("MessageId", content);
			if (dict.First != null)
			{
				Debug.LogError("Adding MessageId after first");
				dict.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError("Adding MessageId instead of empty Jtoken");
				dict = new JObject(content2);
			}
			Debug.Log("Before CreateFromDatabase");
			DatabaseMessage databaseMessage = CreateFromDatabase(dict, type);
			Debug.Log("AFTER CreateFromDatabase");
			databaseMessage.playerId = GameLoginManager.instance.playerId;
			databaseMessage.messageType = type;
			databaseMessage.messageTime = Convert.ToInt32(Regex.Replace(messageId, "^.*-", string.Empty));
			Debug.Log("Message Id = " + databaseMessage.messageId);
			return databaseMessage;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("Database Message: Error parsing message!! Auto Ignore! " + ex.Message);
			return null;
		}
	}

	internal static DatabaseMessage CreateFromDatabase(JToken dict)
	{
		try
		{
			Type type = (Type)dict["MessageType"]["N"].ToObject<int>();
			return CreateFromDatabase(dict, type);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("Database Message: Error parsing message!! Auto Ignore! " + ex.Message);
			if (dict["MessageId"] != null)
			{
				string text = dict["MessageId"]["S"].ToObject<string>();
				Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(text);
			}
			else
			{
				Debug.LogError("Database Message does not contain id or type:\n" + dict.ToString());
			}
			return null;
		}
	}

	public virtual void OnAdd()
	{
	}

	public virtual bool CanShow()
	{
		return !DialogManager.instance.isSomeDialogShowed;
	}

	public virtual void Show()
	{
		mShown = true;
	}

	public bool WasShown()
	{
		return mShown;
	}

	public virtual void Confirm()
	{
		throw new NotImplementedException();
	}

	internal virtual Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		throw new NotImplementedException();
	}

	public virtual void UpdatePlayer(DatabasePlayerInfo player)
	{
		throw new NotImplementedException();
	}
}
