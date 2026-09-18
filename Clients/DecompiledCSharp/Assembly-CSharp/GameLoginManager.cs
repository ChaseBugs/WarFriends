using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class GameLoginManager : InGameSerializedObjectGeneric<GameLoginManager.LoginData>
{
	[Skip]
	public class LoginData
	{
		public Dictionary<DatabaseEnvironment, EnvironmentData> mLoginData;

		private EnvironmentData currentEnvironment
		{
			get
			{
				if (mLoginData == null)
				{
					mLoginData = new Dictionary<DatabaseEnvironment, EnvironmentData>();
				}
				if (!mLoginData.ContainsKey(BeanstalkUrlCreator.environment))
				{
					mLoginData[BeanstalkUrlCreator.environment] = new EnvironmentData();
				}
				return mLoginData[BeanstalkUrlCreator.environment];
			}
		}

		[JsonIgnore]
		public DatabasePlayer currentPlayer
		{
			get
			{
				return currentEnvironment.currentPlayer;
			}
			set
			{
				currentEnvironment.currentPlayer = value;
			}
		}

		[JsonIgnore]
		public bool isDeviceRegistered
		{
			get
			{
				return currentEnvironment.isDeviceRegistered;
			}
			set
			{
				currentEnvironment.isDeviceRegistered = value;
			}
		}

		[JsonIgnore]
		public PlayerAccount playerAccount
		{
			get
			{
				return currentEnvironment.playerAccount;
			}
			set
			{
				currentEnvironment.playerAccount = value;
			}
		}
	}

	[Skip]
	public class EnvironmentData
	{
		public DatabasePlayer currentPlayer;

		public bool isDeviceRegistered;

		public PlayerAccount playerAccount;
	}

	[Skip]
	public class PlayerAccount
	{
		public string id;

		public string hashKey;

		public string password;

		public string hashKeyFB;

		public string passwordFB;

		public string hashKeyGP;

		public string passwordGP;

		public string hashKeyGC;

		public string passwordGC;

		public string hashKeyGuest;

		public string passwordGuest;

		public AccountType accountType;

		public string hashKeyByAccount => accountType switch
		{
			AccountType.Facebook => hashKeyFB, 
			AccountType.GameCenter => hashKeyGC, 
			AccountType.GooglePlay => hashKeyGP, 
			_ => hashKeyGuest, 
		};

		public string passwordByAccount => accountType switch
		{
			AccountType.Facebook => passwordFB, 
			AccountType.GameCenter => passwordGC, 
			AccountType.GooglePlay => passwordGP, 
			_ => passwordGuest, 
		};

		public bool UpdateByAccount()
		{
			if (!string.IsNullOrEmpty(hashKey) && !string.IsNullOrEmpty(password))
			{
				switch (accountType)
				{
				case AccountType.Facebook:
					hashKeyFB = hashKey;
					passwordFB = password;
					break;
				case AccountType.GameCenter:
					hashKeyGC = hashKey;
					passwordGC = password;
					break;
				default:
					hashKeyGuest = hashKey;
					passwordGuest = password;
					break;
				}
				hashKey = string.Empty;
				password = string.Empty;
				return true;
			}
			return false;
		}
	}

	private static GameLoginManager mInstance;

	private bool startingCurrencyPreset;

	private bool needGCchange;

	private string loginAccessToken = string.Empty;

	public string playerId;

	public bool changeGCAfterTutorialInProgress;

	public bool mAcountDataDownloadingInProgress;

	private string cachedGcId;

	private string askGcId;

	public string facebookName;

	private FacebookService mFacebookService;

	private ICloudService mICloudService;

	public static GameLoginManager instance
	{
		get
		{
			mInstance = mInstance ?? ((GameLoginManager)UnityEngine.Object.FindObjectsOfType(typeof(GameLoginManager))[0]);
			return mInstance;
		}
	}

	public string accessToken => loginAccessToken;

	public bool acountDataDownloadingInProgress
	{
		get
		{
			return mAcountDataDownloadingInProgress;
		}
		set
		{
			Debug.Log("GameLoginManager: Setting AccountDataDownloadingProgress = " + value);
			mAcountDataDownloadingInProgress = value;
			if (mAcountDataDownloadingInProgress && Singleton<EventTrackingManager>.instance.fuseboxxService != null)
			{
				Singleton<EventTrackingManager>.instance.fuseboxxService.StartLoginProcces();
			}
		}
	}

	public List<FacebookService.Friend> facebookFriends => mFacebookService.facebookFriends;

	public Dictionary<long, FacebookService.Friend> facebookFriendsDict => mFacebookService.friendsDictionary;

	public long facebookId => (data.currentPlayer == null) ? (-1) : data.currentPlayer.facebookId;

	public int medals => (data.currentPlayer == null) ? (-1) : data.currentPlayer.skill;

	public bool canSendLogs => data.currentPlayer != null && data.currentPlayer.canPlayerSendLogs;

	public static DatabasePlayer currentPlayer => instance.data.currentPlayer;

	public static DatabasePlayer generatedCurrentPlayer
	{
		get
		{
			DatabasePlayer databasePlayer = instance.data.currentPlayer;
			if (databasePlayer != null)
			{
				databasePlayer.armyPower = LevelManager.instance.armyPower;
				databasePlayer.playerVisuals = CamosManager.instance.data.slots;
				databasePlayer.experience = LevelManager.instance.experience;
				databasePlayer.level = LevelManager.instance.currentLevel.index;
				databasePlayer.statisticsData = StatsManager.instance.data;
				databasePlayer.status = PlayerStatus.Online;
			}
			else
			{
				Debug.LogError("Brutal fatal error - no current player");
			}
			return databasePlayer;
		}
	}

	public string squadIconName
	{
		get
		{
			if (string.IsNullOrEmpty(data.currentPlayer.squadName))
			{
				return string.Empty;
			}
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(data.currentPlayer.squadName, ommitTime: true);
			return (squad != null) ? squad.icon : string.Empty;
		}
	}

	public string squadMessage
	{
		get
		{
			if (string.IsNullOrEmpty(data.currentPlayer.squadName))
			{
				return string.Empty;
			}
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(data.currentPlayer.squadName, ommitTime: true);
			return (squad != null) ? squad.message : string.Empty;
		}
	}

	public bool IsLoggedToFacebook => mFacebookService.IsLoggedToFacebook();

	public event Action DeviceRegistered;

	public event Action<string> PlayerJoinedSquad;

	public event Action PlayerLeftSquad;

	public event Action PlayerLogOut;

	public event Action FriendsLoaded;

	public void OnDestroy()
	{
		mInstance = null;
	}

	internal void AddOneTimeCallbackToShowGcChangeNameDialog()
	{
		FacebookService.FacebookLoginFailedAfterTutorial += delegate
		{
			ShowGcChangeNameDialog();
		};
	}

	public void ShowGcChangeNameDialog()
	{
		Debug.LogError("Tutorial state of current player account type: FB connect: " + data.currentPlayer.isFacebookConnected + " GC connect: " + data.currentPlayer.isGameCenterConnected);
		if (data.currentPlayer.isFacebookConnected || !data.currentPlayer.isGameCenterConnected)
		{
			return;
		}
		Debug.Log("About to show GC Change Name Dialog");
		if (instance.HasGcName())
		{
			Debug.Log("Has Gc Name!");
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_GAMECENTER"), Localization.Localize("ID_CONFIRM_GAMECENTERNAMETEXT"), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					instance.ChangeToGcName();
				}
			}, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}
		else
		{
			Debug.LogError("GC Name Is Missing, not showing dialog to change the name!");
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mFacebookService = new FacebookService();
		mICloudService = new ICloudService();
		Singleton<GooglePlayGameService>.instance.LoggedIn += GoogleLoggedIn;
		Singleton<GooglePlayGameService>.instance.LoggedOutExternaly += GoogleLoggedOutExternaly;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
	}

	internal void UpdateReputation(int reputation)
	{
		Debug.Log("Updating reputation for current player = " + reputation);
		data.currentPlayer.reputation = reputation;
		Save();
	}

	private void GoogleLoggedIn(bool success)
	{
		Debug.LogError("Game Login Manager: Google logged in " + ((!success) ? "ERROR!" : "succesfully"));
		if (success && (!data.currentPlayer.isGooglePlayConnected || data.currentPlayer.GetOriginalGooglePlayId() != Social.localUser.id))
		{
			Singleton<BeanstalkServerManager>.instance.AddGooglePlay(Social.localUser.id, data.currentPlayer.name, MiscTools.Md5(Social.localUser.id));
		}
	}

	private void GoogleLoggedOutExternaly()
	{
		Singleton<BeanstalkServerManager>.instance.RemoveGooglePlay();
	}

	protected override void Start()
	{
		base.Start();
		if (data.isDeviceRegistered)
		{
			playerId = data.currentPlayer.id;
		}
	}

	internal bool HasGcName()
	{
		return !string.IsNullOrEmpty(Singleton<GameCenterProvider>.instance.gcName);
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.LoginToCustomAccount:
		case DatabaseAction.SwitchToFacebook:
		case DatabaseAction.AddGameCenter:
			Debug.Log("GameLoginManager: Login successful, getting player data");
			data.isDeviceRegistered = true;
			Save();
			acountDataDownloadingInProgress = true;
			Singleton<BeanstalkServerManager>.instance.GetPlayerData();
			if (this.DeviceRegistered != null)
			{
				this.DeviceRegistered();
			}
			break;
		case DatabaseAction.GetConfigurations:
			Debug.Log("GLM: OnDataLoaded - configurations.  is tutorial? " + Singleton<GameController>.instance.isTutorial);
			if (!Singleton<GameController>.instance.isTutorial && needGCchange)
			{
				needGCchange = false;
				if (Singleton<GameCenterProvider>.instance.isAuthenticated && !data.currentPlayer.isFacebookConnected)
				{
					Singleton<BeanstalkServerManager>.instance.AddGameCenter(Singleton<GameCenterProvider>.instance.gcId);
				}
			}
			break;
		case DatabaseAction.AddGooglePlay:
			if (!(Social.localUser.userName != data.currentPlayer.name) || !data.currentPlayer.isGooglePlayConnected)
			{
				break;
			}
			ConfirmDialog.ShowChoice(Localization.Localize("ID_CONFIRM_CONNECTTOGOOGLENAME"), Localization.Localize("ID_CONFIRM_CONNECTTOGOOGLENAMETEXT"), delegate(ConfirmDialog dialog, bool result)
			{
				if (result)
				{
					Singleton<BeanstalkServerManager>.instance.ChangePlayerName(Social.localUser.userName);
				}
			}, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
			break;
		}
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (!Singleton<GameController>.instance.isTutorial && mFacebookService != null)
		{
			mFacebookService.InitLibrary();
		}
	}

	internal void ChangeToGcName()
	{
		Singleton<BeanstalkServerManager>.instance.ChangePlayerName(Singleton<GameCenterProvider>.instance.gcName);
	}

	public void LoginToFacebook()
	{
		GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool result)
		{
			if (result)
			{
				mFacebookService.LoginToFacebook();
			}
		});
	}

	public void SpecialLoginToFacebookInMissionDialog()
	{
		mFacebookService.LoginToFacebook();
	}

	public void LoginToGoogle()
	{
		Singleton<GooglePlayGameService>.instance.LogIn();
	}

	public void AfterTutorialLoginToFacebook()
	{
		mFacebookService.LoginToFacebook();
	}

	public void AfterTutorialGCcheck()
	{
		Debug.Log("GLM: After tutorial GC check");
		changeGCAfterTutorialInProgress = false;
		needGCchange = false;
		if (data.currentPlayer.isFacebookConnected)
		{
			return;
		}
		if (Singleton<GameCenterProvider>.instance.isAuthenticated)
		{
			if (!data.currentPlayer.isGameCenterConnected || data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.gcId)
			{
				Debug.Log("GLM: After tutorial GC check -> ADD GC");
				changeGCAfterTutorialInProgress = true;
				Singleton<BeanstalkServerManager>.instance.AddGameCenter(Singleton<GameCenterProvider>.instance.gcId);
			}
		}
		else if (data.currentPlayer.isGameCenterConnected)
		{
			changeGCAfterTutorialInProgress = true;
			Debug.Log("GLM: After tutorial GC check -> REMOVE GC");
			Singleton<BeanstalkServerManager>.instance.UpdateGC(string.Empty);
		}
	}

	internal void SetDepositedCards(Dictionary<string, string> mDepositedCards)
	{
		Debug.LogWarning("SetDepositedCards " + (mDepositedCards?.Count ?? (-1)));
		if (mDepositedCards == null)
		{
			Debug.LogError("CURRENT PLAYER - SET DEPOSITED CARDS - deposited cards is null");
			return;
		}
		data.currentPlayer.depositedCardsDic = mDepositedCards;
		Save();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log("#PETER# UPDATING CURRENT PLAYER DEPOSITED WARCARDS IN GAMELOGINMANAGER:\n" + data.currentPlayer.debugDepositedWarcards);
		}
	}

	public void RemoveCardFromDeposited(string cardId)
	{
		Debug.LogWarning("RemoveCardFromDeposited " + cardId);
		if (string.IsNullOrEmpty(cardId))
		{
			Debug.LogError("CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null");
			return;
		}
		Debug.Log($"REMOVING WARCARD: \"{cardId}\" FROM DEPOSITED WARCARDS");
		Dictionary<string, string> depositedCardsDic = data.currentPlayer.depositedCardsDic;
		if (depositedCardsDic != null)
		{
			if (depositedCardsDic.ContainsKey(cardId))
			{
				depositedCardsDic.Remove(cardId);
			}
			data.currentPlayer.depositedCardsDic = depositedCardsDic;
			Save();
		}
		else
		{
			Debug.LogError("CURRENT PLAYER - depositedCardsDic is null");
		}
	}

	internal void SetDepositedCards(Dictionary<string, object> depositedCards)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		foreach (KeyValuePair<string, object> depositedCard in depositedCards)
		{
			dictionary[depositedCard.Key] = depositedCard.Value.ToString();
		}
		SetDepositedCards(dictionary);
	}

	public bool CheckFacebookAfterTutorial()
	{
		return mFacebookService.CheckFacebookAfterTutorial();
	}

	public void LogoutFromGooglePlay(bool clientOnly)
	{
		Debug.LogError("Remove Google Play " + ((!clientOnly) ? "On server" : "ClientOnly"));
		Singleton<GooglePlayGameService>.instance.LogOut();
		if (clientOnly)
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.ShowGooglePlayLogoutDialog(delegate(bool result)
		{
			if (result)
			{
				Singleton<BeanstalkServerManager>.instance.RemoveGooglePlay();
			}
		});
	}

	public void LogoutFromFacebook(bool clientOnly)
	{
		if (clientOnly)
		{
			Debug.Log("GameLoginManager: Logout from facebook");
			mFacebookService.LogoutFromFacebook(clientOnly);
			return;
		}
		bool newAccount = false;
		if (data.currentPlayer.isGameCenterConnected)
		{
			if (Singleton<GameCenterProvider>.instance.isAuthenticated)
			{
				if (data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.gcId)
				{
					newAccount = true;
				}
			}
			else
			{
				newAccount = true;
			}
		}
		GuiElementSingle<FacebookDialog>.instance.ShowLogoutDialog(newAccount, delegate(bool result)
		{
			if (result)
			{
				Debug.Log("GameLoginManager: Logout from facebook");
				mFacebookService.LogoutFromFacebook(clientOnly);
			}
		});
	}

	public void RelogToFacebook()
	{
		ConfirmDialog.ShowAlert(delegate
		{
			LoginToFacebook();
		}, Localization.Localize("ID_RELOG_TO_FB_DIALOG_TITLE"), Localization.LocalizeFormat("ID_RELOG_TO_FB_DIALOG_TEXT", facebookName));
	}

	public void OnPlayerDataLoadedSquadNameCheck(string squadName)
	{
		if (string.IsNullOrEmpty(data.currentPlayer.squadName))
		{
			Debug.LogError("Player not in squad and should be in squad " + squadName + ". Correcting...");
		}
		else if (data.currentPlayer.squadName != squadName)
		{
			Debug.LogError("Player is in squad " + data.currentPlayer.squadName + " and should be in squad " + squadName + ". Correcting...");
		}
		if (squadName != data.currentPlayer.squadName)
		{
			data.currentPlayer.squadName = squadName;
			Save();
			Debug.Log("Corrected squad name for current player");
		}
	}

	internal void AddPlayerToSquad(string squadId, SquadRank squadRank)
	{
		data.currentPlayer.squadName = Regex.Replace(squadId, "-[0-9]*$", string.Empty);
		data.currentPlayer.squadRank = squadRank;
		if (this.PlayerJoinedSquad != null)
		{
			this.PlayerJoinedSquad(squadId);
		}
		Save();
	}

	internal void RemovePlayerFromSquad(List<string> cardList = null)
	{
		string text = ((cardList != null) ? $"ADDING {cardList.Count} WARCARD/-S FROM CARDPOOL" : "NONE WARCARDS TO ADD FROM CARDPOOL");
		Debug.LogWarning("REMOVING CURRENT PLAYER FROM SQUAD " + text);
		data.currentPlayer.squadName = null;
		data.currentPlayer.squadRank = SquadRank.None;
		if (data.currentPlayer.depositedCardsDic != null)
		{
			data.currentPlayer.depositedCardsDic.Clear();
		}
		if (cardList != null)
		{
			text = "Adding warcards from cardpool:\n";
			foreach (string card in cardList)
			{
				text = text + card + "\n";
				CardManager.instance.AddCard(card);
			}
			Debug.Log(text);
		}
		Singleton<ServerResultsCache>.instance.squadEventProgress = null;
		if (this.PlayerLeftSquad != null)
		{
			this.PlayerLeftSquad();
		}
		Save();
	}

	public static void Relog(bool showScreen = true)
	{
		Debug.Log("GameLoginManager: Reloging...");
		if (instance.PlayerLogOut != null)
		{
			instance.PlayerLogOut();
		}
		if (showScreen && (Singleton<GameController>.instance.gameState == GameController.GameState.Menu || Singleton<GameController>.instance.gameState == GameController.GameState.WaitingForResponse))
		{
			instance.InvokeAfterFrame(delegate
			{
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				instance.data.isDeviceRegistered = false;
				instance.Save();
				Singleton<BeanstalkServerManager>.instance.waitForInput = false;
				Singleton<BeanstalkServerManager>.instance.ResetSending();
				instance.RegisterOrLogin();
			});
		}
	}

	internal void UpdatePlayerByGC(string id, string password, AccountType accountType)
	{
		data.playerAccount.hashKeyGC = id;
		data.playerAccount.passwordGC = password;
		data.playerAccount.accountType = accountType;
		DatabasePlayer databasePlayer = data.currentPlayer;
		databasePlayer.gameCenterId = id;
		mICloudService.SavePlayer(data.playerAccount);
		Debug.Log("Saving GC Player Account change!");
		Save();
		if (GuiElementSingle<LoadingDialog>.instance.loadingTitle.text == Localization.Localize("ID_LOADING"))
		{
			LoadingDialog.Hide();
		}
	}

	internal void UpdateGCId(string gcId)
	{
		if (data.playerAccount == null)
		{
			data.playerAccount = new PlayerAccount();
		}
		data.playerAccount.hashKeyGC = gcId;
		if (!string.IsNullOrEmpty(gcId))
		{
			data.playerAccount.passwordGC = MiscTools.Md5(gcId + "banana");
		}
		else
		{
			data.playerAccount.passwordGC = string.Empty;
		}
	}

	internal void SavePlayer(DatabasePlayer databasePlayer, string id, string accessToken, string password, AccountType accountType)
	{
		data.currentPlayer = databasePlayer;
		playerId = databasePlayer.id;
		loginAccessToken = accessToken;
		Debug.Log("set acces token: " + loginAccessToken);
		data.isDeviceRegistered = true;
		if (this.DeviceRegistered != null)
		{
			this.DeviceRegistered();
		}
		KochavaManager.LinkPlayer(playerId);
		if (data.playerAccount == null)
		{
			data.playerAccount = new PlayerAccount();
		}
		data.playerAccount.id = databasePlayer.id;
		switch (accountType)
		{
		case AccountType.Facebook:
			data.playerAccount.hashKeyFB = id;
			data.playerAccount.passwordFB = password;
			break;
		case AccountType.GameCenter:
			data.playerAccount.hashKeyGC = id;
			data.playerAccount.passwordGC = password;
			break;
		case AccountType.Guest:
			data.playerAccount.hashKeyGuest = id;
			data.playerAccount.passwordGuest = password;
			break;
		case AccountType.GooglePlay:
			data.playerAccount.hashKeyGP = id;
			data.playerAccount.passwordGP = password;
			break;
		default:
			Debug.LogError("wrong account type: " + accountType);
			break;
		}
		data.playerAccount.accountType = accountType;
		mICloudService.SavePlayer(data.playerAccount);
		Debug.Log("Saving Player Account with PlayerId = " + databasePlayer.id);
		Save();
	}

	internal void FacebookLogout()
	{
		Debug.LogWarningFormat("FB: FacebookLogout called ..");
		if (data.currentPlayer.isGameCenterConnected)
		{
			Debug.LogWarningFormat("FB: FacebookLogout GC connected");
			if (Singleton<GameCenterProvider>.instance.isAuthenticated)
			{
				if (data.playerAccount.hashKeyGC == Singleton<GameCenterProvider>.instance.gcId)
				{
					Debug.LogWarningFormat("FB: FacebookLogout - RemoveFacebook - 1");
					Singleton<BeanstalkServerManager>.instance.RemoveFacebook();
				}
				else
				{
					Debug.LogWarningFormat("FB: FacebookLogout - DeletePlayerAccount - 1");
					DeletePlayerAccount();
					Relog();
				}
			}
			else
			{
				Debug.LogWarningFormat("FB: FacebookLogout - DeletePlayerAccount - 2");
				DeletePlayerAccount();
				Relog();
			}
		}
		else
		{
			Debug.LogWarningFormat("FB: FacebookLogout - RemoveFacebook - 2");
			Singleton<BeanstalkServerManager>.instance.RemoveFacebook();
		}
		Debug.LogWarningFormat("FB: FacebookLogout finished ..");
	}

	internal void RemoveLoginData(AccountType accountType, string playerName, string newGuestPassword, string newGuestId)
	{
		Debug.Log("Game Login Manager: Remove Login Data");
		if (accountType != AccountType.Facebook)
		{
			data.currentPlayer.facebookId = -1L;
			Debug.Log("Remove Facebook Data");
		}
		if (accountType != AccountType.GooglePlay)
		{
			data.currentPlayer.googlePlayId = null;
			Debug.Log("Remove Google Play Data");
		}
		data.currentPlayer.accountName = playerName;
		data.currentPlayer.accountType = accountType;
		data.playerAccount.accountType = accountType;
		if (!string.IsNullOrEmpty(newGuestPassword) && !string.IsNullOrEmpty(newGuestId))
		{
			data.playerAccount.passwordGuest = newGuestPassword;
			data.playerAccount.hashKeyGuest = newGuestId;
		}
		mICloudService.SavePlayer(data.playerAccount);
		Save();
		if (Singleton<GameCenterProvider>.instance.isAuthenticated && (!data.currentPlayer.isGameCenterConnected || data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.gcId))
		{
			Singleton<BeanstalkServerManager>.instance.AddGameCenter(Singleton<GameCenterProvider>.instance.gcId);
		}
	}

	public void SaveLoginData(string id, string playerName, string password, AccountType accountType)
	{
		Debug.Log("Save Login Data " + id + ", name = " + playerName + ", password = " + password + ", accountType = " + accountType);
		data.currentPlayer.accountName = playerName;
		data.currentPlayer.accountType = accountType;
		switch (accountType)
		{
		case AccountType.Facebook:
			data.currentPlayer.facebookId = StringParser.ParseLong(id, 0L);
			data.playerAccount.hashKeyFB = id;
			data.playerAccount.passwordFB = password;
			break;
		case AccountType.GooglePlay:
			data.currentPlayer.googlePlayId = id;
			data.playerAccount.hashKeyGP = id;
			data.playerAccount.passwordGP = password;
			break;
		}
		if (accountType != AccountType.Facebook)
		{
			data.playerAccount.accountType = accountType;
		}
		mICloudService.SavePlayer(data.playerAccount);
		Save();
	}

	internal void UpdatePlayerSquadRank(SquadRank squadRank)
	{
		Debug.Log(string.Concat("Squad rank updated from server, on client = ", data.currentPlayer.squadRank, ", on server = ", squadRank));
		data.currentPlayer.squadRank = squadRank;
		Save();
	}

	public void CreateNewAccount(bool gamecenter)
	{
		Debug.Log("GLM: CreateNewAccount - GC: " + gamecenter);
		acountDataDownloadingInProgress = true;
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		Singleton<MessageManager>.instance.ClearAllMessages();
		GameControllerTutorial.ResetTutorialProgress();
		loginAccessToken = string.Empty;
		if (gamecenter)
		{
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(Singleton<GameCenterProvider>.instance.gcId);
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.CreateAccount();
		}
	}

	public void AccountChange()
	{
		if (Singleton<GameCenterProvider>.instance.isAuthenticated && cachedGcId == Singleton<GameCenterProvider>.instance.gcId)
		{
			Debug.Log("Switching to GC account");
			string password = MiscTools.Md5(cachedGcId + "banana");
			acountDataDownloadingInProgress = true;
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
			Singleton<MessageManager>.instance.ClearAllMessages();
			TutorialManagerStage1.instance.FinishTutorial();
			TutorialManagerStage2.instance.FinishTutorial();
			TutorialManagerStage3.instance.FinishTutorial();
			GameControllerTutorial.ResetTutorialProgress();
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
			GuiElementSingle<TutorialFade>.instance.Hide();
			Singleton<TutorialProgressShower>.instance.Disable();
			GuiElementSingle<InventoryGuiElement>.instance.Show();
			GuiElementSingle<LevelUpDialog>.instance.HideDialog();
			if (Singleton<GuiManager>.instance.currentScreen != null)
			{
				Singleton<GuiManager>.instance.HideGui(Singleton<GuiManager>.instance.currentScreen);
				Singleton<GuiManager>.instance.currentScreen = null;
			}
			Singleton<BeanstalkServerManager>.instance.Login(cachedGcId, password, AccountType.GameCenter);
			cachedGcId = string.Empty;
			askGcId = string.Empty;
		}
		else
		{
			RegisterOrLogin();
		}
	}

	private IEnumerator WaitToLoadingFinish(bool ask)
	{
		Debug.Log("start waiting to be in menu or in game");
		while (Singleton<GameController>.instance.gameState != GameController.GameState.Menu && Singleton<GameController>.instance.gameState != GameController.GameState.Playing)
		{
			yield return null;
		}
		yield return null;
		yield return null;
		Debug.Log("no is in menu or in game");
		if (ask)
		{
			OnGamecenterUserExistDuringTutorial(cachedGcId);
		}
		else
		{
			ChangeAccountDialogCallback(null, b: true);
		}
	}

	private void ChangeAccountDialogCallback(ConfirmDialog c, bool b)
	{
		if (Singleton<GameController>.instance.gameState != GameController.GameState.Menu && Singleton<GameController>.instance.gameState != GameController.GameState.Playing)
		{
			StartCoroutine(WaitToLoadingFinish(ask: false));
		}
		else if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
		{
			AccountChange();
		}
		else
		{
			Singleton<GameController>.instance.ChangeAccountDuringTutorial();
		}
	}

	public void OnGamecenterUserExistDuringTutorial(string gcId)
	{
		if (acountDataDownloadingInProgress)
		{
			Singleton<SessionManager>.instance.ScheduleGCCheck();
		}
		else if (Singleton<GameCenterProvider>.instance.isAuthenticated && gcId == Singleton<GameCenterProvider>.instance.gcId)
		{
			cachedGcId = gcId;
			if (Singleton<GameController>.instance.gameState != GameController.GameState.Menu && Singleton<GameController>.instance.gameState != GameController.GameState.Playing)
			{
				StartCoroutine(WaitToLoadingFinish(ask: true));
				return;
			}
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
			ConfirmDialog.ShowAlert(ChangeAccountDialogCallback, Localization.Localize("ID_GC_LOGIN_TUTORIAL_TITLE"), Localization.Localize("ID_GC_LOGIN_TUTORIAL_TEXT"));
		}
	}

	public void GamecenterChangeDuringTutorial()
	{
		Debug.Log("possibly change GC during tutorial");
		if (data.playerAccount != null && data.isDeviceRegistered && !data.currentPlayer.isFacebookConnected && askGcId != Singleton<GameCenterProvider>.instance.gcId && !mFacebookService.IsLoggedToFacebook())
		{
			if (Singleton<GameCenterProvider>.instance.isAuthenticated)
			{
				if (!data.currentPlayer.isGameCenterConnected || data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.gcId)
				{
					Debug.Log("GamecenterChangeDuringTutorial - Check current GC on server");
					askGcId = Singleton<GameCenterProvider>.instance.gcId;
					Singleton<BeanstalkServerManager>.instance.CheckIfExistGcAccount(Singleton<GameCenterProvider>.instance.gcId);
				}
				else
				{
					Debug.Log("GamecenterChangeDuringTutorial - ALL OK - loged to GC connectet to this account");
				}
			}
			else
			{
				Debug.Log("GamecenterChangeDuringTutorial - NOT connect -> ignore for this moment");
			}
		}
		else
		{
			Debug.Log("GamecenterChangeDuringTutorial - wrong situation -> do nothing");
		}
	}

	internal void RegisterOrLogin(SessionManager.SessionUpdate sessionUpdate = SessionManager.SessionUpdate.Full)
	{
		if (data.playerAccount == null)
		{
			data.playerAccount = mICloudService.GetPlayer();
			Save();
		}
		if (data.playerAccount != null && data.playerAccount.UpdateByAccount())
		{
			mICloudService.SavePlayer(data.playerAccount);
			Save();
		}
		if (data.playerAccount == null)
		{
			Debug.Log("GLM: RegisterOrLogin -  playerAccount == NULL");
			CreateNewAccount(Singleton<GameCenterProvider>.instance.isAuthenticated);
			return;
		}
		if (data.isDeviceRegistered && !string.IsNullOrEmpty(loginAccessToken))
		{
			if (data.currentPlayer.isFacebookConnected)
			{
				Debug.Log("GLM: RegisterOrLogin -  1");
				GetPlayerData(sessionUpdate, changeGC: false);
			}
			else if (Singleton<GameCenterProvider>.instance.isAuthenticated)
			{
				if (data.currentPlayer.isGameCenterConnected)
				{
					if (data.playerAccount.hashKeyGC == Singleton<GameCenterProvider>.instance.gcId)
					{
						Debug.Log("GLM: RegisterOrLogin -  4");
						GetPlayerData(sessionUpdate, changeGC: false);
					}
					else
					{
						Debug.Log("GLM: RegisterOrLogin -  5");
						CreateNewAccount(gamecenter: true);
					}
				}
				else if (Singleton<GameController>.instance.isTutorial)
				{
					Debug.Log("GLM: RegisterOrLogin -  2");
					GetPlayerData(sessionUpdate, changeGC: true);
				}
				else
				{
					Debug.Log("GLM: RegisterOrLogin -  3");
					acountDataDownloadingInProgress = true;
					Singleton<BeanstalkServerManager>.instance.AddGameCenter(Singleton<GameCenterProvider>.instance.gcId);
				}
			}
			else if (data.currentPlayer.isGameCenterConnected)
			{
				if (!Singleton<GameCenterProvider>.instance.hasResponse)
				{
					Debug.Log("GLM: RegisterOrLogin - 6.5: no GC response, use stored values");
					GetPlayerData(sessionUpdate, changeGC: false);
					return;
				}
				Debug.Log("GLM: RegisterOrLogin -  6");
				acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.CheckIsOnline(delegate
				{
					ConfirmDialog.ShowAlert(delegate
					{
						CreateNewAccount(gamecenter: false);
					}, Localization.Localize("ID_GC_LOGOUT_TITLE"), Localization.Localize("ID_GC_LOGOUT_TEXT"));
				});
			}
			else
			{
				Debug.Log("GLM: RegisterOrLogin -  7");
				GetPlayerData(sessionUpdate, changeGC: false);
			}
			return;
		}
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		bool flag = false;
		if (data.currentPlayer != null && !data.currentPlayer.isFacebookConnected)
		{
			if (Singleton<GameCenterProvider>.instance.isAuthenticated)
			{
				if (data.currentPlayer.isGameCenterConnected)
				{
					if (data.playerAccount.hashKeyGC != Singleton<GameCenterProvider>.instance.gcId)
					{
						flag = true;
						Debug.Log("GLM: RegisterOrLogin -  9");
						CreateNewAccount(gamecenter: true);
					}
				}
				else if (!Singleton<GameController>.instance.isTutorial)
				{
					needGCchange = true;
					Debug.Log("GLM: RegisterOrLogin - need add GC");
				}
			}
			else if (data.currentPlayer.isGameCenterConnected)
			{
				Debug.LogError($"hasResponse: {Singleton<GameCenterProvider>.instance.hasResponse}; hashKeyGC : {data.playerAccount.hashKeyGC} ; gcID : {Singleton<GameCenterProvider>.instance.gcId}");
				if (!Singleton<GameCenterProvider>.instance.hasResponse)
				{
					Debug.Log("GLM: RegisterOrLogin - NOT GameCenterProvider.instance.hasResponse!!!, use saved!");
				}
				else
				{
					Debug.Log("GLM: RegisterOrLogin -  10");
					flag = true;
					acountDataDownloadingInProgress = true;
					Singleton<BeanstalkServerManager>.instance.CheckIsOnline(delegate
					{
						ConfirmDialog.ShowAlert(delegate
						{
							CreateNewAccount(gamecenter: false);
						}, Localization.Localize("ID_GC_LOGOUT_TITLE"), Localization.Localize("ID_GC_LOGOUT_TEXT"));
					});
				}
			}
		}
		if (!flag)
		{
			Debug.Log("GLM: RegisterOrLogin -  8: " + data.playerAccount.accountType);
			acountDataDownloadingInProgress = true;
			Singleton<BeanstalkServerManager>.instance.Login(data.playerAccount.hashKeyByAccount, data.playerAccount.passwordByAccount, data.playerAccount.accountType);
		}
	}

	internal void DeletePlayerAccount()
	{
		data.playerAccount = null;
		Save();
		loginAccessToken = string.Empty;
		mICloudService.DeletePlayer();
	}

	internal void GetPlayerData(SessionManager.SessionUpdate sessionUpdate, bool changeGC)
	{
		if (sessionUpdate != SessionManager.SessionUpdate.Full && sessionUpdate == SessionManager.SessionUpdate.Light)
		{
			Singleton<BeanstalkServerManager>.instance.SetPlayerStatus((!Singleton<GameController>.instance.gameIsRunning) ? PlayerStatus.Online : PlayerStatus.InGame);
			if (changeGC)
			{
				needGCchange = true;
			}
			return;
		}
		if (changeGC)
		{
			needGCchange = true;
		}
		acountDataDownloadingInProgress = true;
		Singleton<BeanstalkServerManager>.instance.GetPlayerData();
	}

	public void UpdatePlayerLeagueAndMedals(int beginnersLeague, string league, int globalMedals, int leagueMedals, int remainingMatches)
	{
		string[] array = league.Split('-');
		League normalLeague = (League)Convert.ToInt32(array[0]);
		string leagueDivision = array[array.Length - 1];
		data.currentPlayer.leagueId = league;
		data.currentPlayer.leagueDivision = leagueDivision;
		UpdatePlayerLeagueAndMedals(beginnersLeague, normalLeague, globalMedals, leagueMedals, remainingMatches);
	}

	private void UpdatePlayerLeagueAndMedals(int beginnersLeague, League normalLeague, int globalMedals, int leagueMedals, int remainingMatches)
	{
		data.currentPlayer.beginnersLeague = beginnersLeague;
		data.currentPlayer.leagueTier = normalLeague;
		data.currentPlayer.skill = globalMedals;
		data.currentPlayer.medalsBalance = leagueMedals;
		data.currentPlayer.remainingMatches = remainingMatches;
		Debug.LogFormat("Updated Player League And Medals to BeginnersLeague:{0} NormalLeague:{1} GlobalMedals:{2} LeagueMedals:{3} RemainingMatches:{4}", beginnersLeague, normalLeague, globalMedals, leagueMedals, remainingMatches);
		Save();
	}

	public void UpdatePlayerLeagueAndMedalsEnteredNormalLeague(string league, int beginnersLeague, int globalMedals, int leagueMedals, int remainingMatches, bool enteredNormalLeague)
	{
		bool flag = data.currentPlayer.beginnersLeague > 0 && beginnersLeague == 0;
		UpdatePlayerLeagueAndMedals(beginnersLeague, league, globalMedals, leagueMedals, remainingMatches);
		if (flag)
		{
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(data.currentPlayer.leagueTier));
		}
		if (enteredNormalLeague)
		{
			bool flag2 = StatsManager.instance.bestLeague == League.NoLeague;
			if (flag2)
			{
				Debug.Log("!!!!! Player entered normal leagues FIRST TIME!!!!");
			}
			Debug.Log("GameLoginManager - Player Entered Normal League - " + data.currentPlayer.leagueTier);
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(data.currentPlayer.leagueTier, flag2));
		}
	}

	public void UpdatePlayerLeagueAndMedalsEnteredBeginnersLeague(int beginnersLeague, int globalMedals, int leagueMedals, int remainingMatches)
	{
		bool flag = data.currentPlayer.beginnersLeague != beginnersLeague;
		UpdatePlayerLeagueAndMedals(beginnersLeague, data.currentPlayer.leagueTier, globalMedals, leagueMedals, remainingMatches);
		if (flag)
		{
			Debug.Log("GameLoginManager - Player Entered Beginners League - " + data.currentPlayer.beginnersLeague);
			Singleton<MessageManager>.instance.AddMessage(new LeagueEnterMessage(data.currentPlayer.beginnersLeague));
			GuiScreenSingle<EndScreen>.instance.isEnteredBeginnersLeague = true;
		}
	}

	public void UpdatePlayerMedals(int globalMedals, int leagueMedals, int remainingMatches)
	{
		int skill = data.currentPlayer.skill;
		UpdatePlayerLeagueAndMedals(data.currentPlayer.beginnersLeague, data.currentPlayer.leagueTier, globalMedals, leagueMedals, remainingMatches);
		Debug.Log("GameLoginManager - Global Medals update: " + skill + " -> " + globalMedals);
		Singleton<EventTrackingManager>.instance.fuseboxxService.RegisterCurrency(FuseboxxService.Currency.Medals, globalMedals);
	}

	public void RemovePlayerFromLeague(League newLeague)
	{
		Singleton<ServerResultsCache>.instance.RemovePlayerLeagueLeaderboard(data.currentPlayer.leagueId);
		int beginnersLeague = data.currentPlayer.beginnersLeague;
		int num = (int)newLeague;
		string league = num + "-placement";
		int skill = data.currentPlayer.skill;
		int leagueMedals = 0;
		int remainingMatches = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE;
		UpdatePlayerLeagueAndMedals(beginnersLeague, league, skill, leagueMedals, remainingMatches);
	}

	public void SavePlayerName(string playerName)
	{
		data.currentPlayer.accountName = playerName;
		Save();
	}

	public void RefreshFriends()
	{
		mFacebookService.RefreshFriends();
	}

	public void OnFriendsLoaded()
	{
		if (this.FriendsLoaded != null)
		{
			this.FriendsLoaded();
		}
	}

	public void InviteFacebookFriends()
	{
		Debug.Log("GameLoginManager: Invite Facebook Friends");
		mFacebookService.inviteFriends();
	}

	internal void SaveGameCenterData(string gameCenterId)
	{
		data.currentPlayer.gameCenterId = gameCenterId;
		data.playerAccount.hashKeyGC = gameCenterId;
		if (data.currentPlayer.accountType == AccountType.Guest)
		{
			data.currentPlayer.accountType = AccountType.GameCenter;
		}
		mICloudService.SavePlayer(data.playerAccount);
		Save();
	}

	public void ResetStartingCurrencyPreset()
	{
		startingCurrencyPreset = false;
	}

	public void TryPresetStartingCurrency()
	{
		if (!startingCurrencyPreset)
		{
			Dictionary<string, object> startingCurrency = Singleton<EventTrackingManager>.instance.fuseboxxService.GetStartingCurrency();
			long result = Singleton<Wallet>.instance.gold;
			long result2 = Singleton<Wallet>.instance.warBucks;
			if (startingCurrency != null && startingCurrency.ContainsKey("gold") && startingCurrency["gold"] is string && long.TryParse(startingCurrency["gold"] as string, out result))
			{
				Debug.Log("Found starting gold currency = " + startingCurrency["gold"]);
				Singleton<Wallet>.instance.InitGold(result);
			}
			if (startingCurrency != null && startingCurrency.ContainsKey("warbucks") && startingCurrency["warbucks"] is string && long.TryParse(startingCurrency["warbucks"] as string, out result2))
			{
				Debug.Log("Found starting warbucks currency = " + startingCurrency["warbucks"]);
				Singleton<Wallet>.instance.InitWarBucks(result2);
			}
			startingCurrencyPreset = true;
		}
	}

	public void SetPlayerDataAfterBootcamps()
	{
		data.currentPlayer.remainingMatches = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE;
		Save();
	}
}
