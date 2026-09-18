using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ChallengeMessage : DatabaseMessage
{
	public string opponentId;

	public string mapName;

	public int misssionNumber;

	public MissionsManager.MissionData missionData;

	public GameController.GameType gameType;

	public bool isCoop;

	public bool isHeroic;

	public bool expired;

	public CloudRegionCode region;

	public DatabasePlayer otherPlayer;

	private bool mProcessInShow;

	public string clientVersion;

	public string roomName;

	public override bool canBeClickedInLobby => false;

	public ChallengeMessage(bool fakeFight, bool isHeroicCoop)
		: base(string.Empty, Type.Challenge)
	{
		mapName = "Desert";
		gameType = ((!fakeFight) ? GameController.GameType.Coop : GameController.GameType.DeathMatch);
		misssionNumber = (fakeFight ? 1 : 8);
		missionData = MissionsManager.instance.data.missionData[7];
		opponentId = GameLoginManager.currentPlayer.id;
		region = CloudRegionCode.eu;
		isCoop = !fakeFight;
		isHeroic = isHeroicCoop;
		otherPlayer = GameLoginManager.currentPlayer;
		roomName = "unset";
		clientVersion = "0.0.0";
	}

	public ChallengeMessage(JToken dict)
		: base(dict)
	{
		mapName = dict["MapName"]["S"].ToObject<string>();
		gameType = (GameController.GameType)dict["GameType"]["N"].ToObject<int>();
		misssionNumber = ((dict["MissionNumber"] != null) ? dict["MissionNumber"]["S"].ToObject<int>() : 0);
		missionData = ((dict["MissionData"] != null && !string.IsNullOrEmpty(dict["MissionData"]["S"].ToObject<string>())) ? JsonConvert.DeserializeObject<MissionsManager.MissionData>(dict["MissionData"]["S"].ToObject<string>()) : null);
		if (dict["MessageId"] != null)
		{
			opponentId = Regex.Replace(dict["MessageId"]["S"].ToObject<string>(), "-[0-9]*$", string.Empty);
		}
		else
		{
			opponentId = dict["OpponentId"]["S"].ToObject<string>();
		}
		region = ((dict["Region"] != null) ? dict["Region"]["N"].ToObject<CloudRegionCode>() : CloudRegionCode.eu);
		isCoop = gameType == GameController.GameType.Coop;
		isHeroic = dict["IsHeroic"] != null;
		JToken item = JsonConvert.DeserializeObject<JToken>(dict["OtherPlayer"]["S"].ToString());
		otherPlayer = DatabasePlayer.CreateFromDatabase(item);
		if (dict["roomName"] != null && dict["roomName"]["S"] != null)
		{
			roomName = StringParser.ParseString(dict["roomName"]["S"], string.Empty);
		}
		else
		{
			roomName = "unset";
		}
		if (dict["clientVersion"] != null && dict["clientVersion"]["S"] != null)
		{
			clientVersion = StringParser.ParseString(dict["clientVersion"]["S"], string.Empty);
		}
		else
		{
			clientVersion = "0.0.0";
		}
		Debug.LogFormat("Creating challenge message:\nclient version: {0} and room name: {1}", clientVersion, roomName);
	}

	public override void OnAdd()
	{
		mProcessInShow = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.gameState != GameController.GameState.Menu || Singleton<GuiManager>.instance.currentScreen is EndScreen;
		if (mProcessInShow)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - messageTime > 120)
		{
			Ignore();
			return;
		}
		GuiScreen currentScreen = Singleton<GuiManager>.instance.currentScreen;
		if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu && currentScreen != null && currentScreen.showDialogs && !DialogManager.instance.isSomeDialogShowed && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("Show {0} invitation dialog id: {1}", (!isCoop) ? "Battle" : "Coop", messageId));
			FightDialog.ShowFightDialog(this);
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessage(this);
		}
	}

	public override bool CanShow()
	{
		if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.currentScreen as EndScreen;
			return endScreen == null && base.CanShow();
		}
		return base.CanShow();
	}

	public override void Show()
	{
		base.Show();
		if (mProcessInShow)
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - messageTime > 120)
			{
				Ignore();
			}
			else
			{
				FightDialog.ShowFightDialog(this);
			}
		}
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_Challenge(messageType, messageTime, otherPlayer, isHitlist: false, isCoop, this);
		return delegate
		{
			if (expired)
			{
				Ignore();
			}
			else
			{
				FightDialog.ShowFightDialog(this);
				record.counter.StopMessageCenterCounter();
			}
		};
	}

	public override void UpdatePlayer(DatabasePlayerInfo player)
	{
		if (opponentId == player.id)
		{
			otherPlayer.skill = player.skill;
			otherPlayer.armyPower = player.armyPower;
		}
	}
}
