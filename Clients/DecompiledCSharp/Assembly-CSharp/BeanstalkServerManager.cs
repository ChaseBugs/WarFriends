using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Sockets;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using BestHTTP;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class BeanstalkServerManager : Singleton<BeanstalkServerManager>
{
	private const int mNRetries = 5;

	private const float mMinBackoff = 2f;

	private const float mMaxBackoff = 15f;

	private const float mRetryMultiplier = 2f;

	public bool disableErrorrs;

	private bool mInitialized;

	private BeanstalkUrlCreator mUrlCreator;

	private string mServerUrl;

	private ServerResponseHandler mResponseHandler;

	public IInAppHandler inAppHandler;

	public InAppDataManager inAppDataManager;

	private ServerTime mServerTime;

	private static string mCert;

	private bool mGetAllMessagesRoutineStatus;

	private bool mIsSending;

	public bool waitForInput;

	private string mPackLocation;

	private bool mDevAccess;

	private Packs mPackDefinition;

	private StringBuilder mSaveBuffer;

	private float mNextGetAllMessagesTime;

	private readonly HashSet<int> mAccountManagementActions = new HashSet<int> { 118, 146, 30 };

	private List<Func<IEnumerator>> mPlayerDataLoadedRoutines3 = new List<Func<IEnumerator>>();

	private bool mIsgettingAllMessages;

	public int dataDownloaded { get; private set; }

	public string postParameters { get; private set; }

	public bool isPlayerDataLoaded { get; private set; }

	public bool loadingPlayerData { get; private set; }

	private static string myCert
	{
		get
		{
			if (string.IsNullOrEmpty(mCert))
			{
				mCert = test() + ServerResponseHandler.test() + ServerErrorHandler.test();
			}
			return mCert;
		}
	}

	public int lastUpdate
	{
		get
		{
			if (mServerTime == null)
			{
				return 0;
			}
			return mServerTime.GetLastUpdateFromServer();
		}
	}

	public int lastUpdateDebug
	{
		get
		{
			if (mServerTime == null)
			{
				return 0;
			}
			return mServerTime.GetLastUpdateFromServerDebug();
		}
	}

	public bool isSending => mIsSending;

	public DateTime currentDateTime => MiscTools.GetDateTime(currentTimestamp);

	public int currentTimestamp => mServerTime.GetCurrentTimestamp();

	public int timestampPlayerDataLoaded => mServerTime.GetPlayerDataLoadedTimestamp();

	public int midnight => mServerTime.midnight;

	public double currentTimestampDouble => mServerTime.GetCurrentTimestampDouble();

	public Packs packDefinition => mPackDefinition ?? (mPackDefinition = GetComponent<Packs>());

	public DatabaseEnvironment environment => BeanstalkUrlCreator.environment;

	public string environmentName => environment switch
	{
		DatabaseEnvironment.DevelopmentSvk => "DevelopmentSvk", 
		DatabaseEnvironment.Staging => "Staging", 
		DatabaseEnvironment.Production => "Production", 
		DatabaseEnvironment.QA => "QA", 
		_ => string.Empty, 
	};

	public string appLink => mUrlCreator.CreateAppLink();

	public bool shouldGetMessages => Singleton<GameController>.instance.gameState == GameController.GameState.Menu && GameLoginManager.instance.data.isDeviceRegistered && !Singleton<GameController>.instance.isTutorial && isPlayerDataLoaded;

	public event Action<DatabaseAction> DataLoaded;

	public event Action PlayerDataLoaded;

	public event Action AfterPlayerDataLoaded;

	public event Action<DatabaseAction> ErrorReceived;

	public event Action<bool> MatchMakingGameCreated;

	public event Action UserWasLoggetOut;

	public event Action<DatabaseSquad> SquadUpdateReceived;

	public event Action<DatabaseAction, int, ActionStage> ActionUpdated;

	public void ErrorWasReceived(DatabaseAction action)
	{
		if (this.ErrorReceived != null)
		{
			this.ErrorReceived(action);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Init();
	}

	private void Init()
	{
		if (!mInitialized)
		{
			mServerTime = new ServerTime();
			mUrlCreator = new BeanstalkUrlCreator();
			mResponseHandler = new ServerResponseHandler(mServerTime);
			inAppHandler = new InAppHandlerAndroid();
			mServerUrl = mUrlCreator.CreateUrl();
			GameLoginManager.instance.FriendsLoaded += GetFriendsInfo;
			inAppHandler.InAppBought += OnInAppBought;
			inAppHandler.InAppFailed += OnInAppFailed;
			Singleton<Logs>.instance.SendLogsAction = SendLogs;
			mInitialized = true;
		}
	}

	private void Update()
	{
		if (shouldGetMessages && !mIsgettingAllMessages && Time.realtimeSinceStartup > mNextGetAllMessagesTime)
		{
			if (mIsSending)
			{
				mNextGetAllMessagesTime = Time.realtimeSinceStartup + 1f;
				return;
			}
			mNextGetAllMessagesTime = Time.realtimeSinceStartup + (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GetAllMessagesTimer).FLOATVALUE;
			StartCoroutine(GetAllMessagesCoroutine());
		}
	}

	public void CancelAllRequests()
	{
		StopAllCoroutines();
		mIsgettingAllMessages = false;
	}

	private IEnumerator GetAllMessagesCoroutine()
	{
		mIsgettingAllMessages = true;
		List<Tuple<string, string>> parameters = new List<Tuple<string, string>>
		{
			new Tuple<string, string>("MessagesCount", (Singleton<MessageManager>.instance.unignoredMessages + 100).ToString())
		};
		yield return StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetAllMessages, parameters)));
		mIsgettingAllMessages = false;
	}

	internal void GetAllMessages()
	{
		mNextGetAllMessagesTime = Time.realtimeSinceStartup + 1f;
	}

	private void SendLogs()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Logs.LogEntry log in Singleton<Logs>.instance.logs)
		{
			string text = "color=\"#DC143C\"";
			switch (log.type)
			{
			case LogType.Log:
				text = "color=\"#333333\"";
				break;
			case LogType.Warning:
				text = "color=\"#FFD700\"";
				break;
			}
			stringBuilder.AppendLine("<font " + text + " >");
			stringBuilder.AppendLine(SecurityElement.Escape(log.type.ToString()));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(log.output));
			stringBuilder.AppendLine();
			stringBuilder.AppendLine(SecurityElement.Escape(log.stack));
			stringBuilder.AppendLine("\n</font>");
		}
		SendLogs(stringBuilder);
	}

	private void OnInAppFailed(DatabaseAction action, string reason, InAppError inAppError)
	{
		WaitingDialog.Hide();
		if (inAppError == InAppError.Canceled)
		{
			return;
		}
		if (action == DatabaseAction.BuyPack && inAppError == InAppError.Validation)
		{
			WarningDialog.ShowChoice(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_INAPP_VALIDATION"), Localization.Localize("ID_CONFIRM_RESTORE"), Localization.Localize("ID_CANCEL"), delegate(bool firstClicked)
			{
				if (firstClicked && !GuiElementSingle<SettingsDialog>.instance.isShowed)
				{
					DialogManager.instance.HideAllDialogs();
					GuiElementSingle<SettingsDialog>.instance.ShowGeneral();
				}
			});
		}
		else
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_INAPP_FAILED"), Localization.Localize("ID_CONFIRM_PURCHASEFAILED"), GuiElementSingle<WaitingDialog>.instance.fadeInTime, null, string.Empty);
		}
		SendErrorMessage(new Exception(reason), action, reason, string.Empty);
		ErrorWasReceived(action);
	}

	protected override void Start()
	{
		base.Start();
		inAppHandler.Start();
		inAppDataManager = GetComponent<InAppDataManager>();
	}

	private void EraseData()
	{
		isPlayerDataLoaded = false;
	}

	public void UserLoggedOut()
	{
		EraseData();
		if (this.UserWasLoggetOut != null)
		{
			this.UserWasLoggetOut();
		}
	}

	public void ResetSending()
	{
		mIsSending = false;
	}

	private IEnumerator CreateServerRequest(DatabaseAction databaseAction, List<Tuple<string, string>> postData)
	{
		int counter = 0;
		while (mIsSending || waitForInput)
		{
			counter++;
			yield return null;
		}
		postParameters = JsonConvert.SerializeObject(postData);
		if (counter > 0)
		{
		}
		DatabaseResult result = DatabaseResult.Success;
		int retryCount = GetRetryCount(databaseAction);
		try
		{
			mIsSending = true;
			string errorMessage = string.Empty;
			float waitingTime = 2f;
			int errorCode = 0;
			for (int i = 0; i < retryCount; i++)
			{
				errorMessage = string.Empty;
				errorCode = 0;
				if (this.ActionUpdated != null)
				{
					this.ActionUpdated(databaseAction, i, ActionStage.SendingToServer);
				}
				HTTPRequest download = GetServerRequest(databaseAction, i, postData);
				if (CachedApplicationInternetReachability.internetReachability != NetworkReachability.NotReachable)
				{
					download.Send();
					while (download.State <= HTTPRequestStates.Processing)
					{
						yield return null;
					}
					if (download.Response == null || string.IsNullOrEmpty(download.Response.DataAsText))
					{
						download.Exception = new SocketException(10014);
						Debug.Log("Beanstalk: Error - empty response from server");
					}
					if (download.Exception != null)
					{
						errorMessage = download.Exception.Message;
						if (download.Exception is SocketException { ErrorCode: var errorCode2, SocketErrorCode: SocketError.HostNotFound })
						{
							Debug.Log("Beanstalk: Internet Offline");
						}
						Debug.Log("Beanstalk Error (try = " + (i + 1) + "): " + errorMessage + ", action = " + databaseAction);
						if (i + 1 < 5)
						{
							yield return new WaitForRealSeconds(waitingTime);
						}
						waitingTime *= 2f;
						if (waitingTime > 15f)
						{
							waitingTime = 15f;
						}
						continue;
					}
					string text = download.Response.DataAsText;
					dataDownloaded += download.Downloaded;
					if (this.ActionUpdated != null)
					{
						this.ActionUpdated(databaseAction, i, ActionStage.ProcessingOnClient);
					}
					result = mResponseHandler.ServerRequestFinished(databaseAction, text, postData);
					if (this.ActionUpdated != null)
					{
						this.ActionUpdated(databaseAction, i, ActionStage.Done);
					}
					break;
				}
				Debug.LogError("Beanstalk: Application not reachable!");
				errorMessage = "No connection.";
				break;
			}
			if (string.IsNullOrEmpty(errorMessage) || (Singleton<GameController>.instance.isTutorial && databaseAction != DatabaseAction.TutorialEnded))
			{
				yield break;
			}
			Debug.Log("Beanstalk Error: " + errorMessage + ", action = " + databaseAction);
			if (this.ErrorReceived != null)
			{
				this.ErrorReceived(databaseAction);
			}
			if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu && databaseAction != DatabaseAction.TutorialEnded)
			{
				ServerErrorHandler.Retry();
			}
			if (databaseAction == DatabaseAction.GameEnded || databaseAction == DatabaseAction.TutorialEnded)
			{
				DatabaseAction databaseAction2 = default(DatabaseAction);
				List<Tuple<string, string>> postData2 = default(List<Tuple<string, string>>);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, delegate
				{
					ResendAction(databaseAction2, postData2);
				}, Localization.Localize("ID_RETRY"));
			}
			if (Singleton<GameController>.instance.gameState == GameController.GameState.WaitingForResponse)
			{
				mResponseHandler.ErrorReceived(DatabaseResult.ServerDidntRespondBeforeGame, databaseAction, postData);
			}
		}
		finally
		{
			mIsSending = false;
		}
	}

	private int GetRetryCount(DatabaseAction databaseAction)
	{
		if (mAccountManagementActions.Contains((int)databaseAction) || databaseAction == DatabaseAction.SetPlayerStatus || databaseAction == DatabaseAction.GetPlayerData || databaseAction == DatabaseAction.GameEnded)
		{
			return 3;
		}
		return 5;
	}

	private HTTPRequest GetServerRequest(DatabaseAction databaseAction, int i, IEnumerable<Tuple<string, string>> postData)
	{
		Init();
		int timeout = GetTimeout(i, databaseAction);
		HTTPRequest hTTPRequest = new HTTPRequest(new Uri(mServerUrl), HTTPMethods.Post, OnRequestSend);
		hTTPRequest.Timeout = TimeSpan.FromSeconds(timeout);
		hTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(timeout);
		hTTPRequest.DisableRetry = true;
		hTTPRequest.DisableCache = true;
		HTTPRequest hTTPRequest2 = hTTPRequest;
		hTTPRequest2.AddField("SheetConfig", (!string.IsNullOrEmpty(GameConfigurationManager.instance.data.sheetConfiguration)) ? GameConfigurationManager.instance.data.sheetConfiguration : "0");
		hTTPRequest2.CustomCertificationValidator += OnCertificationValidation;
		hTTPRequest2.AddHeader("App-Version", Singleton<CurrentBundleVersion>.instance.shortVersion);
		int num = (int)databaseAction;
		hTTPRequest2.AddField("requestId", num.ToString());
		hTTPRequest2.AddField("Version", Singleton<CurrentBundleVersion>.instance.version);
		hTTPRequest2.AddField("Os", "android");
		if (DebugSettings.debugEnabled && DebugSettings.isOurDevice)
		{
			hTTPRequest2.AddField("DebugEnabled", "1");
		}
		if (mDevAccess)
		{
			hTTPRequest2.AddField("DevAccess", "true");
		}
		if (!mAccountManagementActions.Contains((int)databaseAction))
		{
			string accessToken = GameLoginManager.instance.accessToken;
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			hTTPRequest2.AddField("Token", (!string.IsNullOrEmpty(accessToken)) ? accessToken : "null");
			hTTPRequest2.AddField("PlayerId", (currentPlayer != null) ? currentPlayer.id : "null");
			if (Singleton<AntiCheatDetector>.instance.playerCheated)
			{
				hTTPRequest2.AddField("Cheat", Convert.ToString((int)Singleton<AntiCheatDetector>.instance.cheatType));
				Singleton<AntiCheatDetector>.instance.Clear();
			}
		}
		if (postData != null)
		{
			foreach (Tuple<string, string> postDatum in postData)
			{
				string value = ((!string.IsNullOrEmpty(postDatum.Value2)) ? postDatum.Value2 : "null");
				hTTPRequest2.AddField(postDatum.Value1, value);
			}
		}
		return hTTPRequest2;
	}

	private int GetTimeout(int currentRetry, DatabaseAction action)
	{
		if ((mAccountManagementActions.Contains((int)action) || action == DatabaseAction.SetPlayerStatus || action == DatabaseAction.GetPlayerData) && currentRetry == 0)
		{
			return 10;
		}
		return 20;
	}

	internal void RemoveFacebook()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("isGameCenter", (!Singleton<GameCenterProvider>.instance.isAuthenticated) ? "0" : "1"));
		list.Add(new Tuple<string, string>("gameCenterId", Singleton<GameCenterProvider>.instance.gcId));
		list.Add(new Tuple<string, string>("gameCenterPassword", GameLoginManager.instance.data.playerAccount.passwordGC));
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.RemoveFacebook, list)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	internal void RemoveGooglePlay()
	{
		Debug.Log("BS: Remove Google Play");
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.RemoveGooglePlay, postData)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	internal int GetNextLeagueEvaluationTimestamp()
	{
		return mServerTime.GetNextLeagueEvaluation();
	}

	internal void GetConfigurations(string sheetConfiguration, string abtestVariant)
	{
		Debug.Log("Beanstalk: Get Configuration called. Current Sheet Configuration = " + sheetConfiguration + ", Client Verison = " + Singleton<CurrentBundleVersion>.instance.shortVersion);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("abTestVariant", abtestVariant));
		list.Add(new Tuple<string, string>("SheetConfiguraton", sheetConfiguration));
		list.Add(new Tuple<string, string>("Language", Localization.instance.nextLanguage));
		List<Tuple<string, string>> list2 = list;
		if (DebugSettings.debugEnabled && DebugSettings.isOurDevice && !string.IsNullOrEmpty(DebugSettings.instance.data.configVersion))
		{
			Debug.LogError("FORCE DEBUG CONFIG VERSION " + DebugSettings.instance.data.configVersion);
			list2.Add(new Tuple<string, string>("DebugVersion", DebugSettings.instance.data.configVersion));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetConfigurations, list2)));
	}

	internal void RefundedInapps(List<Dictionary<string, string>> refundedInapps)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Packs", JsonConvert.SerializeObject(refundedInapps)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.RefundPack, postData)));
	}

	internal void RestorePacks(List<Dictionary<string, string>> packsToRestore)
	{
		Debug.LogError("Beanstalk: RESTORE PACKS");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Packs", JsonConvert.SerializeObject(packsToRestore)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.RestorePacks, postData)));
		if (DebugSettings.debugEnabled)
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_ANDROIDRESTOREPURCHASES"));
		}
	}

	private bool OnCertificationValidation(HTTPRequest request, X509Certificate certificate, X509Chain arg3)
	{
		try
		{
			Debug.Log("Custom Verification");
			X509Certificate x509Certificate = new X509Certificate();
			x509Certificate.Import(Encoding.UTF8.GetBytes(myCert));
			return x509Certificate.Equals(certificate);
		}
		catch (Exception)
		{
			return false;
		}
	}

	private void OnRequestSend(HTTPRequest request, HTTPResponse response)
	{
		switch (request.State)
		{
		case HTTPRequestStates.Finished:
			break;
		case HTTPRequestStates.Error:
			Debug.LogError("Request Finished with Error! " + ((request.Exception == null) ? "No Exception" : (request.Exception.Message + "\n" + request.Exception.StackTrace)));
			break;
		case HTTPRequestStates.Aborted:
			Debug.LogWarning("Request Aborted!");
			break;
		case HTTPRequestStates.ConnectionTimedOut:
			Debug.LogError("Connection Timed Out!");
			break;
		case HTTPRequestStates.TimedOut:
			Debug.LogError("Processing the request Timed Out!");
			break;
		}
	}

	public void SendErrorMessage(Exception exception, DatabaseAction databaseAction, string response, string postParams)
	{
		Debug.LogError("Error message sent to server, database action: " + databaseAction);
		Debug.LogError("Server response: " + response);
		if (response.Length > 500)
		{
			response = response.Substring(0, 498);
		}
		Debug.LogError("Exception message: " + exception.Message);
		Debug.LogError("Exception stacktrace: " + exception.StackTrace);
		if (postParams.Length > 500)
		{
			postParams = postParams.Substring(0, 498);
		}
		Debug.LogError("Post Parameters: " + postParams);
		if (databaseAction == DatabaseAction.ErrorMessage)
		{
			Debug.Log("Not sending error about error message to database.");
			return;
		}
		if (mUrlCreator.isLocalhost)
		{
			Debug.Log("Not sending error to database!!");
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string val = ((currentPlayer == null) ? "null" : currentPlayer.name);
		Crittercism.LogHandledException(exception);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerName", val));
		list.Add(new Tuple<string, string>("ExceptionMessage", exception.Message));
		list.Add(new Tuple<string, string>("ExceptionStacktrace", exception.StackTrace));
		list.Add(new Tuple<string, string>("DbAction", string.Concat(databaseAction, " ", mServerUrl)));
		list.Add(new Tuple<string, string>("ServerResponse", "response= " + response));
		list.Add(new Tuple<string, string>("PostParameters", postParams));
		list.Add(new Tuple<string, string>("ClientVersion", Singleton<CurrentBundleVersion>.instance.version));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ErrorMessage, postData)));
	}

	internal void DepositCards(string addedCards, string removedCards, List<Card> addedCardsList)
	{
		Debug.Log("Beanstalk: Deposit these cards = " + addedCards + ", remove these cards = " + removedCards);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("AddedCards", addedCards));
		list.Add(new Tuple<string, string>("RemovedCards", removedCards));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.DepositCards, postData)));
		int[] rarityCounts = CardManager.instance.GetRarityCounts();
		foreach (Card addedCards2 in addedCardsList)
		{
			string cardId = ((!addedCards2.isBuddyCard) ? addedCards2.id : "BuddyCard");
			Singleton<EventTrackingManager>.instance.RegisterDepositCard(cardId, rarityCounts);
		}
	}

	internal void ResendAction(DatabaseAction action, List<Tuple<string, string>> parameters)
	{
		Debug.LogError("Beanstalk: Resending " + action);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(action, parameters)));
	}

	internal void LeagueLeaderboardsShown()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.leagueLeaderboardsShown = true;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.LeagueLeaderboardShown, postData)));
	}

	internal void UpdateAnalytics()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerAnalytics", JsonConvert.SerializeObject(PlayerAnalytics.instance.GetUpdates())));
		List<Tuple<string, string>> postData = list;
		Debug.LogError("Beanstalk: Update analytics");
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateAnalytics, postData)));
	}

	internal void NotifyPlayerToDeposit(string id)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadMemberId", id));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.NotifyPlayerToDeposit, postData)));
	}

	internal void SendFuseboxConfigurations(string configs)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("fuseData", configs));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SaveFuseConfigs, postData)));
	}

	public void SendErrorMessage(Exception exception, object messageToParse, string stacktrace)
	{
		if (!disableErrorrs)
		{
			Debug.LogError("Server message to parse: " + messageToParse);
			Debug.LogError("Exception message: " + exception.Message);
			Debug.LogError("Exception stacktrace: " + stacktrace);
			if (mUrlCreator.isLocalhost)
			{
				Debug.Log("Not sending error to database!!");
			}
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("PlayerName", (currentPlayer == null) ? "null" : currentPlayer.name));
			list.Add(new Tuple<string, string>("ExceptionMessage", exception.Message));
			list.Add(new Tuple<string, string>("ExceptionStacktrace", exception.StackTrace));
			list.Add(new Tuple<string, string>("MessageToParse", "message= " + messageToParse));
			list.Add(new Tuple<string, string>("ClientVersion", Singleton<CurrentBundleVersion>.instance.version));
			List<Tuple<string, string>> postData = list;
			StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ErrorMessage, postData)));
		}
	}

	internal void TestMethod()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		Debug.Log("Beanstalk: Test");
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.Test, postData)));
	}

	public void SendLogs(StringBuilder logs)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerName", (currentPlayer == null) ? "null" : currentPlayer.name));
		list.Add(new Tuple<string, string>("PlayerId", (currentPlayer == null) ? "nullId" : currentPlayer.id));
		list.Add(new Tuple<string, string>("Logs", logs.ToString()));
		list.Add(new Tuple<string, string>("ClientVersion", Singleton<CurrentBundleVersion>.instance.version));
		List<Tuple<string, string>> postData = list;
		Debug.Log("Beanstalk: Send Log. Wait for Response with Log Id....");
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SendLog, postData)));
	}

	internal void UpdateGC(string gcId)
	{
		string val = "0";
		string text = string.Empty;
		if (!string.IsNullOrEmpty(gcId))
		{
			text = MiscTools.Md5(gcId + "banana");
			val = "1";
		}
		Debug.Log("updating GC to: " + gcId + " pass: " + text);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("haveGcId", val));
		list.Add(new Tuple<string, string>("GameCenterId", gcId));
		list.Add(new Tuple<string, string>("GameCenterPassword", text));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.RemoveOrUpdateGC, postData)));
	}

	internal void GetPlayerData()
	{
		Debug.Log("Beanstalk: Get Player " + GameLoginManager.currentPlayer.id);
		Debug.Log("Current Language = " + Localization.instance.nextLanguage);
		Debug.Log("Current Locale unity = " + Application.systemLanguage);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Buffers", RequestBufferManager.instance.GetJsonData()));
		list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("width", Screen.width.ToString()));
		list.Add(new Tuple<string, string>("height", Screen.height.ToString()));
		list.Add(new Tuple<string, string>("KochavaDeviceID", KochavaManager.GetKochavaDeviceId()));
		list.Add(new Tuple<string, string>("IDFA", KochavaManager.GetIDFA()));
		list.Add(new Tuple<string, string>("IDFV", KochavaManager.GetIDFV()));
		list.Add(new Tuple<string, string>("AndroidID", KochavaManager.GetAndroidID()));
		list.Add(new Tuple<string, string>("AndroidAdvertisingID", KochavaManager.GetAndroidAdvertisingID()));
		list.Add(new Tuple<string, string>("LocalPersistenceHandle", LocalPersistenceManager.GetLocalFileHandle()));
		List<Tuple<string, string>> list2 = list;
		if (BattleRewardsManager.instance.isSomeUnsentRewards)
		{
			Debug.LogError("Beanstalk: Get Player Data - unset rewards set!");
			list2.Add(new Tuple<string, string>("UnsentRewards", JsonConvert.SerializeObject(BattleRewardsManager.instance.data)));
		}
		string fuseboxxConfigValue = Singleton<EventTrackingManager>.instance.fuseboxxService.GetFuseboxxConfigValue();
		if (fuseboxxConfigValue != null)
		{
			Debug.LogError("Fuseboxx Config Value = " + fuseboxxConfigValue);
			list2.Add(new Tuple<string, string>("FuseboxxConfigValue", fuseboxxConfigValue));
		}
		else
		{
			Debug.LogError("NO Fuseboxx Config Value during GETPLAYERDATA!");
		}
		LoadingDialog.ShowLoading(Localization.Localize("ID_DOWNLOADINGDATA"), showCancelButton: false, hideBackgroundElements: true);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetPlayerData, list2)));
	}

	internal void UnLockDevAccess()
	{
		Debug.Log("Beanstalk: Dev access unlocked");
		mDevAccess = true;
	}

	internal void CreateSquad(string squadName, string squadMessage, bool isPrivate, string skillRequirement, string squadEmblem)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadName));
		list.Add(new Tuple<string, string>("IsPublic", (!isPrivate) ? "1" : "0"));
		list.Add(new Tuple<string, string>("Icon", squadEmblem));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(squadMessage))
		{
			list2.Add(new Tuple<string, string>("Message", squadMessage));
		}
		list2.Add(new Tuple<string, string>("SkillRequirement", skillRequirement));
		StartCoroutine(CreateServerRequest(DatabaseAction.CreateSquad, list2));
	}

	public void Challenge(DatabasePlayer otherPlayer, string mapName, string missionNumber = "", string missionData = "", string roomName = "default", bool isHeroic = false)
	{
		Singleton<MapManager>.instance.SelectCurrentMap(mapName);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ChallengedPlayerId", otherPlayer.id));
		list.Add(new Tuple<string, string>("MapName", mapName));
		list.Add(new Tuple<string, string>("GameType", ((int)Singleton<GameController>.instance.gameType).ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Region", ((int)PhotonConnectionManager.GetBestRegion(PhotonConnectionManager.bestRegions, otherPlayer.bestRegions, out var _)).ToString()));
		list.Add(new Tuple<string, string>("roomName", roomName));
		list.Add(new Tuple<string, string>("clientVersion", Singleton<CurrentBundleVersion>.instance.photonVersion));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(missionNumber))
		{
			list2.Add(new Tuple<string, string>("MissionNumber", missionNumber));
		}
		if (!string.IsNullOrEmpty(missionData))
		{
			list2.Add(new Tuple<string, string>("MissionData", missionData));
		}
		if (isHeroic)
		{
			Debug.LogError("IS HEROIC");
			list2.Add(new Tuple<string, string>("IsHeroic", "1"));
		}
		else
		{
			Debug.LogError("IS NOT HEROIC!");
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.MessageSent, list2)));
	}

	internal void JoinSquad(string newSquadId, string messageId = "")
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("NewSquadId", newSquadId));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(messageId))
		{
			list2.Add(new Tuple<string, string>("MessageId", messageId));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.JoinSquad, list2)));
		WaitingDialog.ShowDialog();
	}

	public void JoinSquadRequest(string squadId)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.JoinSquadRequest, postData)));
	}

	public void GameStartedClient()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("IsHitList", "0"));
		list.Add(new Tuple<string, string>("IsMatchMaking", (!Singleton<GameController>.instance.isRandomMatchMaking) ? "0" : "1"));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("IsWarArenaBattle", (!Singleton<GameController>.instance.isWarArena) ? "0" : "1"));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameStartedClient, postData)));
	}

	internal int GetNextWarEvaluationTimestamp()
	{
		return mServerTime.GetNextWarsEvaluation();
	}

	public void GameStartedMaster(int botConfigId = -1)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("IsMatchMaking", (!Singleton<GameController>.instance.isRandomMatchMaking) ? "0" : "1"));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("IsWarArenaBattle", (!Singleton<GameController>.instance.isWarArena) ? "0" : "1"));
		List<Tuple<string, string>> list2 = list;
		if (botConfigId != -1)
		{
			list2.Add(new Tuple<string, string>("BotId", botConfigId.ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.isRandomMatchMaking && Singleton<GameController>.instance.isDeathMatchOffline)
		{
			list2.Add(new Tuple<string, string>("BotName", Singleton<GameController>.instance.opponent.playerProperties.name));
			list2.Add(new Tuple<string, string>("BotLevel", (Singleton<GameController>.instance.opponent.playerProperties.level - 1).ToString()));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameStartedMaster, list2)));
	}

	internal void UpdateArmyPower(int armyPower)
	{
		Debug.Log("BS: Update Army Power");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ArmyPower", armyPower.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateArmyPower, postData)));
	}

	public void CreateAccount()
	{
		double utcOffset = ServerTime.GetUtcOffset();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("UtcOffset", utcOffset.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
		List<Tuple<string, string>> list2 = list;
		Dictionary<string, object> startingCurrency = Singleton<EventTrackingManager>.instance.fuseboxxService.GetStartingCurrency();
		if (startingCurrency != null && startingCurrency.ContainsKey("gold"))
		{
			Debug.Log("Found starting gold currency = " + startingCurrency["gold"]);
			list2.Add(new Tuple<string, string>("StartingGold", startingCurrency["gold"].ToString()));
		}
		if (startingCurrency != null && startingCurrency.ContainsKey("warbucks"))
		{
			Debug.Log("Found starting warbucks currency = " + startingCurrency["warbucks"]);
			list2.Add(new Tuple<string, string>("StartingWarbucks", startingCurrency["warbucks"].ToString()));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CreateAccount, list2)));
	}

	public void CreateGcAccount(string gcId)
	{
		string text = MiscTools.Md5(gcId + "banana");
		Debug.Log("CreateGcAccount with " + gcId + ", pass = " + text);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GameCenterId", gcId));
		list.Add(new Tuple<string, string>("GameCenterPassword", text));
		list.Add(new Tuple<string, string>("UtcOffset", ServerTime.GetUtcOffset().ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
		List<Tuple<string, string>> list2 = list;
		Dictionary<string, object> startingCurrency = Singleton<EventTrackingManager>.instance.fuseboxxService.GetStartingCurrency();
		if (startingCurrency != null && startingCurrency.ContainsKey("gold"))
		{
			Debug.Log("Found starting gold currency = " + startingCurrency["gold"]);
			list2.Add(new Tuple<string, string>("StartingGold", startingCurrency["gold"].ToString()));
		}
		if (startingCurrency != null && startingCurrency.ContainsKey("warbucks"))
		{
			Debug.Log("Found starting warbucks currency = " + startingCurrency["warbucks"]);
			list2.Add(new Tuple<string, string>("StartingWarbucks", startingCurrency["warbucks"].ToString()));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CreateGcAccount, list2)));
	}

	internal void AddGameCenter(string gcId, bool removeOld = false)
	{
		string text = MiscTools.Md5(gcId + "banana");
		Debug.Log("AddGameCenter with " + gcId + ", pass = " + text + ", remove older account = " + removeOld);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GameCenterId", gcId));
		list.Add(new Tuple<string, string>("GameCenterPassword", text));
		List<Tuple<string, string>> list2 = list;
		if (removeOld)
		{
			list2.Add(new Tuple<string, string>("RemoveOld", "1"));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AddGameCenter, list2)));
	}

	internal void GameStartedCampaign()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameStartedCampaign, postData)));
	}

	internal void GameCoopStartedMaster()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameStartedCoopMaster, postData)));
	}

	internal void GetPlayerInfo(string playerId)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerInfoId", playerId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetPlayerInfo, postData)));
	}

	internal void GameCoopStartedClient()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameStartedCoopClient, postData)));
	}

	internal void WithdrawCard(string playerId, string cardId)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("IdOfPlayer", playerId));
		list.Add(new Tuple<string, string>("CardId", cardId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.WithdrawCard, postData)));
	}

	public void RestartTutorial()
	{
		if (this.MatchMakingGameCreated != null)
		{
			this.MatchMakingGameCreated(obj: true);
		}
	}

	public void GameEnded(GameController.GameEndReason endReason)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.ServerResponse.None;
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && endReason >= GameController.GameEndReason.WinByForfeit)
		{
			CardManager.instance.obtainedCards.Clear();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			Singleton<GameController>.instance.gameEndServerResponse = GameController.ServerResponse.Success;
			return;
		}
		int score = Singleton<ScoreManager>.instance.score;
		StatsManager.instance.RecomputeStatistics(endReason);
		StarterAssignmentsManager.instance.Evaluate();
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.Evaluation.AfterGame);
		string val = JsonConvert.SerializeObject(AssignmentsManager.instance.GetAssignmentsUpdate());
		string val2 = CardManager.instance.GetObtainedCards();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning && endReason != GameController.GameEndReason.Forfeit)
		{
			Singleton<GameController>.instance.gameControllerTutorial.AddWarcardsForFinishingPlayWarcardsTutorial();
			val2 = Singleton<GameController>.instance.gameControllerTutorial.SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial();
		}
		Debug.Log("Battle id = " + Singleton<GameController>.instance.battleId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		int num = (int)endReason;
		list.Add(new Tuple<string, string>("EndReason", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Experience", score.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("IsMaster", Singleton<PhotonConnectionManager>.instance.isClient ? "0" : "1"));
		list.Add(new Tuple<string, string>("ObtainedCards", val2));
		list.Add(new Tuple<string, string>("UsedCards", CardManager.instance.GetUsedCards()));
		list.Add(new Tuple<string, string>("GoldBoxes", Singleton<ScoreManager>.instance.gotGoldBoxes.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarBucksBoxes", Singleton<ScoreManager>.instance.gotWarbucksBoxes.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarBucksRibbons", Singleton<RibbonManager>.instance.GetWarBucksFromRibbons().ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("AssignmentsUpdate", val));
		list.Add(new Tuple<string, string>("Stats", JsonConvert.SerializeObject(StatsManager.instance.matchStats)));
		list.Add(new Tuple<string, string>("LevelReward", LevelManager.instance.currentLevel.golds.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("GoldBonusCount", PlayerAnalytics.instance.data.goldBonuses.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("LostGameInRow", StatsManager.instance.battlesLostInRow.ToString()));
		List<Tuple<string, string>> list2 = list;
		if (Singleton<GameController>.instance.isPVP)
		{
			list2.Add(new Tuple<string, string>("BattleAnalytics", JsonConvert.SerializeObject(BattleAnalyticsManager.instance.battleData)));
		}
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			Debug.Log("Beanstalk Server Manager: IS TUTORIAL TO PLAY WARCARDS RUNNING!");
			list2.Add(new Tuple<string, string>("TutorialWarcards", "1"));
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
		Tuple<string, string> userDeviceData = UserDeviceManager.instance.GetUserDeviceData();
		if (userDeviceData != null)
		{
			list2.Add(new Tuple<string, string>("FpsDevice", userDeviceData.Value1));
			list2.Add(new Tuple<string, string>("FpsData", userDeviceData.Value2));
		}
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			list2.Add(new Tuple<string, string>("SquadId", squadName));
			DatabaseSquadEventProgress squadEventProgress = Singleton<ServerResultsCache>.instance.squadEventProgress;
			if (squadEventProgress != null)
			{
				float[] onGameEndedUpdates = squadEventProgress.GetOnGameEndedUpdates(Singleton<ServerResultsCache>.instance.squadEventDefinition);
				if (onGameEndedUpdates != null && squadEventProgress.squadId == squadName)
				{
					list2.Add(new Tuple<string, string>("SquadEventUpdate", JsonConvert.SerializeObject(onGameEndedUpdates)));
					list2.Add(new Tuple<string, string>("SquadEventActiveTier", squadEventProgress.activeTier.ToString(CultureInfo.InvariantCulture)));
				}
			}
		}
		if (endReason == GameController.GameEndReason.MissionSuccess || endReason == GameController.GameEndReason.Win || endReason == GameController.GameEndReason.WinByForfeit)
		{
			list2.Add(new Tuple<string, string>("TimeBonus", Mathf.Clamp(Singleton<GameController>.instance.time, 0f, 999f).ToString(CultureInfo.InvariantCulture)));
		}
		if (Singleton<GameController>.instance.isMission)
		{
			Debug.Log("Beanstalk Server Manager: Adding mission information to server request");
			MissionsManager.MissionData missionData = MissionsManager.instance.GetMissionData();
			Mission currentMission = MissionsManager.instance.currentMission;
			int index = currentMission.index;
			if (endReason == GameController.GameEndReason.MissionSuccess)
			{
				if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
				{
					int partnerLevel = 0;
					if (Singleton<GameController>.instance.friend != null)
					{
						partnerLevel = Singleton<GameController>.instance.friend.playerProperties.level;
					}
					Singleton<EventTrackingManager>.instance.RegisterCampaignCoopCompleted(currentMission, missionData, partnerLevel);
				}
				else
				{
					Singleton<EventTrackingManager>.instance.RegisterCampaignCompleted(currentMission, missionData);
				}
			}
			else
			{
				Debug.Log("Beanstalk Server Manager: " + endReason);
			}
			if (currentMission.playingInHeroicMode)
			{
				list2.Add(new Tuple<string, string>("IsHeroic", "1"));
			}
			list2.Add(new Tuple<string, string>("MissionIndex", index.ToString(CultureInfo.InvariantCulture)));
			list2.Add(new Tuple<string, string>("MissionData", JsonConvert.SerializeObject(missionData)));
			list2.Add(new Tuple<string, string>("MissionBot", (!Singleton<GameController>.instance.isCampaignBot) ? "0" : "1"));
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			list2.Add(new Tuple<string, string>("IsWarArena", "1"));
		}
		Dictionary<string, object> battleWarbucksRewards = Singleton<EventTrackingManager>.instance.fuseboxxService.GetBattleWarbucksRewards();
		if (battleWarbucksRewards != null && battleWarbucksRewards.ContainsKey("Win") && battleWarbucksRewards.ContainsKey("Loss"))
		{
			Debug.Log("Beanstalk Server Manager: Found fuseboxx battle rewards = " + battleWarbucksRewards["Win"]);
			list2.Add(new Tuple<string, string>("WarbuckRewardWin", battleWarbucksRewards["Win"].ToString()));
			list2.Add(new Tuple<string, string>("WarbuckRewardLoss", battleWarbucksRewards["Loss"].ToString()));
		}
		string playerProgressRate = Singleton<EventTrackingManager>.instance.fuseboxxService.GetPlayerProgressRate();
		if (playerProgressRate != null)
		{
			Debug.Log("Beanstalk Server Manager: Found Player Progress = " + playerProgressRate);
			list2.Add(new Tuple<string, string>("PlayerProgressRate", playerProgressRate));
		}
		string starterPackDays = Singleton<EventTrackingManager>.instance.fuseboxxService.GetStarterPackDays();
		if (!string.IsNullOrEmpty(starterPackDays))
		{
			Debug.Log("Beanstalk Server Manager: Sending starter pack days = " + starterPackDays);
			list2.Add(new Tuple<string, string>("StarterPackDays", starterPackDays));
		}
		else
		{
			Debug.Log("Beanstalk Server Manager: NOT SENDING STARTER PACK DAYS");
		}
		BattleRewardsManager.instance.ClearAllRewards();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameEnded, list2)));
	}

	public void TutorialEnded()
	{
		GameController.GameEndReason gameEndReason = GameController.GameEndReason.Win;
		int score = Singleton<ScoreManager>.instance.score;
		GameLoginManager.instance.SetPlayerDataAfterBootcamps();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BattleId", Singleton<GameController>.instance.battleId));
		int num = (int)gameEndReason;
		list.Add(new Tuple<string, string>("EndReason", num.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Experience", score.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("GoldBoxes", Singleton<ScoreManager>.instance.gotGoldBoxes.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("WarBucksBoxes", ((int)Singleton<ScoreManager>.instance.gotWarbucksBoxes + Singleton<RibbonManager>.instance.GetWarBucksFromRibbons()).ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("ObtainedCards", CardManager.instance.GetObtainedCards()));
		list.Add(new Tuple<string, string>("UsedCards", "[]"));
		list.Add(new Tuple<string, string>("Warbucks", Singleton<Wallet>.instance.warBucks.ToString()));
		list.Add(new Tuple<string, string>("Gold", Singleton<Wallet>.instance.gold.ToString()));
		list.Add(new Tuple<string, string>("ArmyPower", LevelManager.instance.armyPower.ToString()));
		List<Tuple<string, string>> postData = list;
		Debug.LogError("ARMY POWER = " + LevelManager.instance.armyPower);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.TutorialEnded, postData)));
	}

	internal void LeaveSquad()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.LeaveSquad, postData)));
		WaitingDialog.ShowDialog("ID_LEAVINGSQUAD");
	}

	internal void ClaimCraftedCard()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ClaimCraftedCard, postData)));
	}

	internal void GetNewAssignments()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetNewAssignments, postData)));
	}

	internal void CompleteStarterAssignments(List<string> finishedAssigments)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("AssignmentsIds", JsonConvert.SerializeObject(finishedAssigments)));
		List<Tuple<string, string>> postData = list;
		Debug.Log("#VOJTA# SENDING COMPLETE STARTER ASSIGNMENSTS!!!");
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CompleteStarterAssignments, postData)));
	}

	internal void OnVipExpired()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.OnVIPExpired, postData)));
	}

	internal void ChangePlayerCountry(string newCountryCode)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("NewCountryCode", newCountryCode));
		List<Tuple<string, string>> postData = list;
		Debug.LogError("changing country to " + newCountryCode);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ChangePlayerCountry, postData)));
	}

	internal void ExistFacebookAccount(long facebookId, string facebookPassword)
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.LogError($"AddFacebookToCustomAccount ID: {facebookId} PSWD: {facebookPassword}");
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("FacebookId", facebookId.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("FacebookPassword", facebookPassword));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ExistFBAccount, postData)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	internal void AddFacebookToCustomAccount(long facebookId, string playerName, string facebookPassword)
	{
		if (DebugSettings.debugEnabled)
		{
			Debug.LogError($"AddFacebookToCustomAccount ID: {facebookId} Name: {playerName} PSWD: {facebookPassword}");
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", playerName));
		list.Add(new Tuple<string, string>("FacebookId", facebookId.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("FacebookPassword", facebookPassword));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AddFacebook, postData)));
		Singleton<EventTrackingManager>.instance.LoginToFacebook();
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	internal void AddGooglePlay(string googleId, string googleName, string password)
	{
		Debug.LogError("ADD GOOGLE PLAY ACCOUNT WITH " + googleId + ", name = " + googleName + ", password = " + password);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", googleName));
		list.Add(new Tuple<string, string>("GooglePlayId", googleId));
		list.Add(new Tuple<string, string>("GooglePlayPassword", password));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AddGooglePlay, postData)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
	}

	internal void PromotePlayer(DatabasePlayer playerToPromote)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToPromoteId", playerToPromote.id));
		int squadRank = (int)playerToPromote.squadRank;
		list.Add(new Tuple<string, string>("OldSquadRank", squadRank.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.PromotePlayer, postData)));
	}

	internal void InformSquadLeaderAboutEvent()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("SquadId", squadName));
			List<Tuple<string, string>> postData = list;
			StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.InformSquadLeaderAboutEvent, postData)));
		}
	}

	public static void LoadSquadMembers(IDictionary<string, object> result)
	{
		if (!result.ContainsKey("SquadMembers"))
		{
			return;
		}
		JArray jArray = (JArray)result["SquadMembers"];
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		foreach (JToken item in jArray)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item);
			list.Add(databasePlayer);
			if (databasePlayer.id == GameLoginManager.currentPlayer.id)
			{
				GameLoginManager.instance.UpdatePlayerSquadRank(databasePlayer.squadRank);
			}
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("squadMembers" + currentPlayer.squadName, list, DateTime.Now.AddMinutes(2.0), DatabaseAction.GetAllSquadMembers);
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
	}

	public void GetFriendsInfo()
	{
		List<DatabasePlayer> friends = Singleton<ServerResultsCache>.instance.GetFriends();
		if (friends != null)
		{
			DataWasLoaded(DatabaseAction.GetFriendsInfo);
			return;
		}
		List<FacebookService.Friend> facebookFriends = GameLoginManager.instance.facebookFriends;
		Debug.Log("Beanstalk: Get Friends Info, count = " + facebookFriends.Count);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = 0;
		for (int i = 0; i < facebookFriends.Count; i++)
		{
			Debug.Log("Beanstalk: Hashed id of fb friend " + facebookFriends[i].hashedId);
			Debug.Log("Beanstalk: Name of FB friend " + facebookFriends[i].name);
			num++;
			list.Add(new Tuple<string, string>("Friend" + i, facebookFriends[i].hashedId.ToString(CultureInfo.InvariantCulture)));
		}
		list.Add(new Tuple<string, string>("Count", num.ToString(CultureInfo.InvariantCulture)));
		if (GameLoginManager.currentPlayer != null)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName))
			{
				list.Add(new Tuple<string, string>("SquadId", squadName));
			}
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetFriendsInfo, list)));
	}

	internal void GetMissionLeaderboards()
	{
		List<DatabasePlayerMissionLeaderboard> missionLeaderboards = Singleton<ServerResultsCache>.instance.GetMissionLeaderboards();
		if (missionLeaderboards != null)
		{
			DataWasLoaded(DatabaseAction.GetMissionLeaderboards);
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		List<FacebookService.Friend> facebookFriends = GameLoginManager.instance.facebookFriends;
		if (facebookFriends != null && facebookFriends.Count > 0)
		{
			long[] array = new long[facebookFriends.Count];
			for (int i = 0; i < facebookFriends.Count; i++)
			{
				array[i] = facebookFriends[i].hashedId;
			}
			list.Add(new Tuple<string, string>("Friends", JsonConvert.SerializeObject(array)));
		}
		if (GameLoginManager.currentPlayer != null)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName))
			{
				list.Add(new Tuple<string, string>("SquadId", squadName));
			}
		}
		if (list.Count > 0)
		{
			StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetMissionLeaderboards, list)));
		}
		else
		{
			GuiElementSingle<MissionDialog>.instance.ShowMissionLeaderboards(null);
		}
	}

	internal void PromotePlayerToFounder(DatabasePlayer newFounder)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToPromoteId", newFounder.id));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.PromotePlayerToFounder, postData)));
	}

	internal void AddOneTimeReward(string rewardId, string parameter = null)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("RewardId", rewardId));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(parameter))
		{
			list2.Add(new Tuple<string, string>("Parameter", parameter));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AddOneTimeReward, list2)));
	}

	internal void DemotePlayer(DatabasePlayer playerToDemote)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToDemoteId", playerToDemote.id));
		int squadRank = (int)playerToDemote.squadRank;
		list.Add(new Tuple<string, string>("OldSquadRank", squadRank.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.DemotePlayer, postData)));
	}

	internal void KickPlayer(string playerId)
	{
		Debug.Log("Beanstalk: Kick Player Called!");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToKickId", playerId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.KickPlayer, postData)));
	}

	internal void CraftCard(string cards)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Cards", cards));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CraftCard, postData)));
	}

	internal void AddVideoReward(RewardType reward)
	{
		Singleton<EventTrackingManager>.instance.SetSendingAdrewardGainedToServer();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)reward;
		list.Add(new Tuple<string, string>("Reward", num.ToString()));
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AddVideoReward, postData)));
	}

	internal void ChangeLanguage(string newLanguage)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Locale", newLanguage));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ChangeLanguage, postData)));
		WaitingDialog.ShowDialog("ID_CHANGINGLANGUAGE");
	}

	internal void InvitePlayerToSquad(DatabasePlayer playerToInvite)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerToInviteId", playerToInvite.id));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.InvitePlayerToSquad, postData)));
	}

	internal void RefillDogtags()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.RefillDogtags, postData)));
	}

	public void BuyInApp(string inAppId)
	{
		WaitingDialog.ShowDialog("ID_PURCHASINGINAPP");
		inAppHandler.PurchaseProduct(inAppId);
	}

	private void OnInAppBought(DatabaseAction action, string inAppId, bool isRestore, List<Tuple<string, string>> paymentInfo)
	{
		GuiElementSingle<InappScreen>.instance.converted = true;
		Debug.Log("BS: On In App Bought " + inAppId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		foreach (Tuple<string, string> item in paymentInfo)
		{
			Debug.Log("Adding payment info = " + item.Value1 + ", " + item.Value2);
			list.Add(item);
		}
		switch (action)
		{
		case DatabaseAction.BuyInApp:
			list.Add(new Tuple<string, string>("Id", inAppId));
			list.Add(new Tuple<string, string>("GoldBase", GuiElementSingle<InappScreen>.instance.goldPart.goldPrefix));
			list.Add(new Tuple<string, string>("WarbucksBase", GuiElementSingle<InappScreen>.instance.warbucksPart.warbucksPrefix));
			break;
		case DatabaseAction.BuyPack:
		{
			list.Add(new Tuple<string, string>("Id", inAppId));
			Tuple<float, string> itemPrice = inAppHandler.GetItemPrice(inAppId);
			float value = itemPrice.Value1;
			if (isRestore)
			{
				list.Add(new Tuple<string, string>("IsRestore", "1"));
				value = 0f;
			}
			break;
		}
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(action, list)));
	}

	public string GetBuyOfferEventLocation()
	{
		string result = mPackLocation;
		mPackLocation = null;
		return result;
	}

	internal void GetLastWeeksPlayerLeague()
	{
		List<DatabasePlayer> lastWeekPlayerLeague = Singleton<ServerResultsCache>.instance.GetLastWeekPlayerLeague();
		if (lastWeekPlayerLeague != null)
		{
			DataWasLoaded(DatabaseAction.GetLastWeeksPlayerLeague);
			return;
		}
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetLastWeeksPlayerLeague, postData)));
	}

	internal void ChatShown()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.chatShown = true;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ChatShownFirstTime, postData)));
	}

	internal void WarpathShown()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.warpathShown = true;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.WarpathShownFirstTime, postData)));
	}

	internal void CustomizationShown()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.customizationShown = true;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CustomizationShown, postData)));
	}

	internal void CardpoolShown()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.cardpoolShown = true;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CardpoolShown, postData)));
	}

	internal void CraftingShown()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		PlayerAnalytics.instance.data.craftingShown = true;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CraftingShown, postData)));
	}

	internal void ExpandHitList()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ExpandHitList, postData)));
	}

	internal void ProvokePlayer(string deviceToken)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DeviceToken", deviceToken));
		list.Add(new Tuple<string, string>("PlayerName", GameLoginManager.currentPlayer.name));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ProvokePlayer, postData)));
	}

	internal void ClaimReward(DatabaseMessage message)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MessageId", message.messageId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ClaimReward, postData)));
	}

	internal void ClaimAssignmentMegaReward()
	{
		RequestBufferManager.instance.ForceSendClaimAssignment();
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ClaimAssignmentMegaReward, postData)));
	}

	internal void SendRequestBuffer(string requestBufferId, IDictionary<int, Request> requests, int requestCount)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("BufferId", requestBufferId));
		list.Add(new Tuple<string, string>("Count", requestCount.ToString(CultureInfo.InvariantCulture)));
		list.Add(new Tuple<string, string>("Requests", JsonConvert.SerializeObject(requests)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SendRequestBuffer, postData)));
	}

	internal void SendPlayerReport(string playerId, string message, int reportType)
	{
		if (string.IsNullOrEmpty(playerId))
		{
			Debug.LogError("SEND PLAYER REPORT ERROR - NO PLAYER ID");
			return;
		}
		if (string.IsNullOrEmpty(message))
		{
			Debug.LogError("SEND PLAYER REPORT ERROR - NO MESSAGE");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ReportedPlayerId", playerId));
		list.Add(new Tuple<string, string>("Message", message));
		list.Add(new Tuple<string, string>("ReportType", reportType.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SendPlayerReport, postData)));
	}

	internal void SendCheaterReport(string playerId, int reportType, int myArmyPower, int myRank, int opponentRank, int opponentArmyPower, float timeOfMatch)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ReportedPlayerId", playerId));
		list.Add(new Tuple<string, string>("ReportType", reportType.ToString()));
		list.Add(new Tuple<string, string>("MyArmyPower", MiscTools.FormatBigNumber(myArmyPower)));
		list.Add(new Tuple<string, string>("MyRank", myRank.ToString()));
		list.Add(new Tuple<string, string>("OpponentArmyPower", MiscTools.FormatBigNumber(opponentArmyPower)));
		list.Add(new Tuple<string, string>("OpponentRank", opponentRank.ToString()));
		list.Add(new Tuple<string, string>("TimeOfMatch", MiscTools.PrintableTimeDigits(timeOfMatch)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ReportCheater, postData)));
	}

	internal void GetSquadDetails(string squadName, bool checkCache = true)
	{
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadName);
		if (squad != null && checkCache)
		{
			DataWasLoaded(DatabaseAction.GetSquadDetails);
			return;
		}
		Debug.Log("Beanstalk: Get Squad Details");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadName));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetSquadDetails, postData)));
	}

	internal void GetFullSquadInfo(string squadName)
	{
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadName);
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(squadName);
		if (squad != null && squadMembers != null)
		{
			Debug.LogError("Beanstalk: Squad Details is cached, returning ...");
			DataWasLoaded(DatabaseAction.GetFullSquadInfo);
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadName));
		List<Tuple<string, string>> postData = list;
		Debug.Log("Get full squad id = " + squadName);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetFullSquadInfo, postData)));
	}

	internal void JoinSquadEvent()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.JoinSquadEvent, postData)));
	}

	internal void BuyVip(int goldAmount, string id, int discount = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Id", id));
		list.Add(new Tuple<string, string>("discount", discount.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.BuyVip, postData)));
	}

	internal void BuyLootboxes(string id, int goldPrice, int discount = 0)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Id", id));
		list.Add(new Tuple<string, string>("discount", discount.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.BuyLootboxes, postData)));
	}

	internal void DeclineSquadJoinRequest(string messageId, string playerId)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MessageId", messageId));
		list.Add(new Tuple<string, string>("Id", playerId));
		List<Tuple<string, string>> postData = list;
		Debug.Log("Decline Squad Join Request = " + messageId);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.DeclineSquadJoinRequest, postData)));
	}

	internal void AcceptSquadJoinRequest(string playerToJoinId, string squadId)
	{
		Debug.Log("SquadId = " + squadId);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadId));
		list.Add(new Tuple<string, string>("PlayerToJoin", playerToJoinId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AcceptSquadJoinRequest, postData)));
	}

	internal void UpdateDeviceToken(string deviceToken)
	{
		Debug.Log("DeviceTokenUpdate, playerid = " + GameLoginManager.instance.playerId + ", token = " + deviceToken);
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.LogWarning("Current Language = " + Localization.instance.nextLanguage);
			Debug.LogWarning("Current Locale unity = " + Application.systemLanguage);
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			list.Add(new Tuple<string, string>("DeviceToken", deviceToken));
			list.Add(new Tuple<string, string>("Locale", Localization.instance.nextLanguage));
			List<Tuple<string, string>> postData = list;
			StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateDeviceToken, postData)));
		}
	}

	internal void GetAllSquadMembers(string squadName, bool forceUpdate = false)
	{
		Debug.Log($"GetAllSquadMembers - squad {squadName} - force {forceUpdate}");
		DatabaseAction databaseAction = DatabaseAction.GetAllSquadMembers;
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(squadName);
		if (squadMembers != null && !forceUpdate)
		{
			DataWasLoaded(databaseAction);
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IsWaitingFor(databaseAction))
		{
			Debug.Log(string.Concat("Beanstalk: Skipping ", databaseAction, ", action already scheduled"));
			return;
		}
		Debug.Log("Beanstalk: Get All Squad Members");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadName));
		List<Tuple<string, string>> list2 = list;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = MiscTools.CompareSquadRanks(currentPlayer.squadRank, SquadRank.Veteran) >= 0;
		bool flag2 = !string.IsNullOrEmpty(currentPlayer.squadName) && flag;
		list2.Add(new Tuple<string, string>("CheckMessages", (!flag2) ? "0" : "1"));
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(databaseAction, list2)));
	}

	internal void CheckUniqueSquadName(string squadName)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadId", squadName));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CheckUniqueSquadName, postData)));
	}

	internal void GetPlayersFromLeague(string playerLeague)
	{
		List<DatabasePlayer> playersFromLeague = Singleton<ServerResultsCache>.instance.GetPlayersFromLeague(playerLeague);
		if (playersFromLeague != null)
		{
			DataWasLoaded(DatabaseAction.GetPlayerLeaguesDivision);
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("LeagueId", playerLeague));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetPlayerLeaguesDivision, postData)));
	}

	internal void GetSquads(string squadNameStart, bool isGlobal)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("SquadNameStart", squadNameStart));
		List<Tuple<string, string>> list2 = list;
		if (isGlobal)
		{
			list2.Add(new Tuple<string, string>("IsGlobal", "1"));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetSquads, list2)));
	}

	internal void UpdateSettings(string settingsJson)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Settings", settingsJson));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateSettings, postData)));
	}

	internal void FindSuggestedSquads(bool isGlobal)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		int skill = currentPlayer.skill;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Skill", skill.ToString()));
		List<Tuple<string, string>> list2 = list;
		if (isGlobal)
		{
			list2.Add(new Tuple<string, string>("IsGlobal", "1"));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.FindSuggestedSquads, list2)));
	}

	internal void GetSquadsByExperience()
	{
		List<DatabaseSquad> globalSquadLeaderboard = Singleton<ServerResultsCache>.instance.GetGlobalSquadLeaderboard();
		if (globalSquadLeaderboard != null)
		{
			DataWasLoaded(DatabaseAction.GetSquadsByExperience);
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			list.Add(new Tuple<string, string>("SquadId", GameLoginManager.currentPlayer.squadName));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetSquadsByExperience, list)));
	}

	internal void SearchPlayers(string playerNameStart)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("PlayerName", playerNameStart));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SearchPlayers, postData)));
	}

	internal void UpdateEmblem(string emblemName)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Icon", emblemName));
		List<Tuple<string, string>> postData = list;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
		if (squad != null)
		{
			squad.icon = emblemName;
			Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + currentPlayer.squadName, squad, DateTime.Now.AddMinutes(2.0));
			DataWasLoaded(DatabaseAction.GetSquadDetails);
		}
		Debug.Log("BS: Sending emblem = " + emblemName);
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateSquadEmblem, postData)));
	}

	internal void AcceptChallenge(ChallengeMessage message)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("MessageId", message.messageId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AcceptChallenge, postData)));
	}

	internal void SetPlayerStatus(PlayerStatus playerStatus)
	{
		PushNotificationManager.instance.ScheduleLapsedPlayerNotifications();
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		int num = (int)playerStatus;
		list.Add(new Tuple<string, string>("PlayerStatus", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SetPlayerStatus, postData)));
	}

	internal void Login(string playerId, string password, AccountType accountType)
	{
		Debug.Log("Login: id = " + playerId + ", password = " + password + ", account type = " + accountType);
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Id", playerId));
		list.Add(new Tuple<string, string>("Password", password));
		int num = (int)accountType;
		list.Add(new Tuple<string, string>("AccountType", num.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.LoginToCustomAccount, postData)));
	}

	internal void GetPlayersByExperience()
	{
		List<DatabasePlayerData> globalPlayerLeaderboard = Singleton<ServerResultsCache>.instance.GetGlobalPlayerLeaderboard();
		if (globalPlayerLeaderboard != null)
		{
			DataWasLoaded(DatabaseAction.GetPlayersByExperience);
			return;
		}
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetPlayersByExperience, postData)));
	}

	internal void GameStartedTutorial()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", GameLoginManager.currentPlayer.name));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GameStartedTutorial, postData)));
	}

	internal void ChangeNameAndPassword(string playerName, string password)
	{
		Debug.Log("Beanstalk: Change Name and Password");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", playerName));
		list.Add(new Tuple<string, string>("Password", password));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ChangeNameAndPassword, postData)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_UPDATINGACCOUNT"));
	}

	internal string GetEnvironmentName()
	{
		string result = "UNKNOWN";
		switch (environment)
		{
		case DatabaseEnvironment.DevelopmentSvk:
			result = "DEV SVK";
			break;
		case DatabaseEnvironment.Staging:
			result = "STAG";
			break;
		case DatabaseEnvironment.Production:
			result = "PROD";
			break;
		case DatabaseEnvironment.QA:
			result = "QA";
			break;
		}
		return result;
	}

	internal void GetSquadsFromRound(string roundId)
	{
		List<DatabaseSquad> squadsFromLeague = Singleton<ServerResultsCache>.instance.GetSquadsFromLeague(roundId);
		if (squadsFromLeague != null)
		{
			DataWasLoaded(DatabaseAction.GetSquadWarsDivision);
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("RoundId", roundId));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetSquadWarsDivision, postData)));
	}

	public void RegisterPlayerDataLoadedRoutine(Func<IEnumerator> afterDataLoadedRoutine)
	{
		mPlayerDataLoadedRoutines3.Add(afterDataLoadedRoutine);
	}

	public void DataWasLoaded(DatabaseAction databaseAction)
	{
		if (this.DataLoaded != null)
		{
			this.DataLoaded(databaseAction);
		}
	}

	public void PlayerDataWasLoaded(bool executeRoutines)
	{
		if (executeRoutines)
		{
			StartCoroutine(ExecuteDataLoadedRoutines());
		}
		else
		{
			FirePlayerDataLoadedEvents();
		}
	}

	private void FirePlayerDataLoadedEvents()
	{
		if (this.PlayerDataLoaded != null)
		{
			Delegate[] invocationList = this.PlayerDataLoaded.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				Delegate obj = invocationList[i];
				obj.Method.Invoke(obj.Target, new object[0]);
				if (i % 8 == 0)
				{
					GC.Collect();
				}
			}
		}
		isPlayerDataLoaded = true;
		if (this.AfterPlayerDataLoaded == null)
		{
			return;
		}
		Delegate[] invocationList2 = this.AfterPlayerDataLoaded.GetInvocationList();
		for (int j = 0; j < invocationList2.Length; j++)
		{
			Delegate obj2 = invocationList2[j];
			obj2.Method.Invoke(obj2.Target, new object[0]);
			if (j % 8 == 0)
			{
				GC.Collect();
			}
		}
	}

	private IEnumerator ExecuteDataLoadedRoutines()
	{
		loadingPlayerData = true;
		foreach (Func<IEnumerator> playerDataLoadedRoutine in mPlayerDataLoadedRoutines3)
		{
			yield return StartCoroutine(playerDataLoadedRoutine());
		}
		Singleton<EventTrackingManager>.instance.fuseboxxService.OverrideConfigurations();
		Debug.Log("hiding dialog............");
		LoadingDialog.Hide();
		FirePlayerDataLoadedEvents();
		loadingPlayerData = false;
	}

	public void SquadUpdateWasReceived(DatabaseSquad squad)
	{
		if (this.SquadUpdateReceived != null)
		{
			this.SquadUpdateReceived(squad);
		}
	}

	public void MatchMakingGameWasCreated(bool result)
	{
		if (this.MatchMakingGameCreated != null)
		{
			this.MatchMakingGameCreated(result);
		}
	}

	public static string test()
	{
		return "-----BEGIN CERTIFICATE-----MIIDwDCCAqgCCQCAhUcHjX7uoDANBgkqhkiG9w0BAQUFADCBoTELMAkGA1UEBhMCQ1oxDzANBgNVBAgMBlByYWd1ZTEPMA0GA1UEBwwGUHJhZ3VlMRIwEAYDVQQKDAlBYm91dCBGdW4xCzAJBgNVBAsMAklUMSswKQYDVQQDDCJ3YXJmcmllbmRzLWV1LmVsYXN0aWNiZWFuc3RhbGsuY29tMSIwIAY";
	}

	public void PayOneDogtag()
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("DogTagRefillTime", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE).ToString()));
		list.Add(new Tuple<string, string>("DogTagCap", ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE).ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.PayOneDogTag, postData)));
	}

	public void BuyPack(string packId, string location = null)
	{
		WaitingDialog.ShowDialog("ID_PURCHASINGPACK");
		mPackLocation = location;
		inAppHandler.PurchaseProduct(packId);
	}

	public void UpdateSquadInfo(string message, bool isPublic, int medalsRequirement)
	{
		Debug.Log("Squad message = " + message);
		Debug.Log("Is Public = " + ((!isPublic) ? "0" : "1"));
		Debug.Log("Medals requirement = " + medalsRequirement);
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(currentPlayer.squadName, ommitTime: true);
		if (squad != null)
		{
			squad.message = message;
			squad.isPublic = isPublic;
			squad.skillRequirement = medalsRequirement;
			Singleton<ServerResultsCache>.instance.Insert<DatabaseSquad>("squad" + currentPlayer.squadName, squad, DateTime.Now.AddMinutes(2.0));
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("IsPublic", (!isPublic) ? "0" : "1"));
		list.Add(new Tuple<string, string>("RequiredMedals", medalsRequirement.ToString(CultureInfo.InvariantCulture)));
		List<Tuple<string, string>> list2 = list;
		if (!string.IsNullOrEmpty(message))
		{
			list2.Add(new Tuple<string, string>("Message", message));
		}
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateSquad, list2)));
	}

	public void SendSpecialOfferShowed(OneOffer[] showedOffers)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		List<string> list2 = new List<string>();
		for (int i = 0; i < showedOffers.Length; i++)
		{
			list2.Add(showedOffers[i].id);
		}
		list.Add(new Tuple<string, string>("showedOffers", JToken.FromObject(list2).ToString()));
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.SpecialOfferShowed, list)));
	}

	public void SendServerRequest(DatabaseAction databaseAction, List<Tuple<string, string>> parameters)
	{
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(databaseAction, parameters)));
	}

	public void GenerateSpecialOffer(long end, int discount, string dbKey, string saleName, bool force = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("finish", end.ToString()));
		list.Add(new Tuple<string, string>("discount", discount.ToString()));
		list.Add(new Tuple<string, string>("dbKey", dbKey));
		list.Add(new Tuple<string, string>("offerName", saleName));
		list.Add(new Tuple<string, string>("lang", Localization.instance.currentLanguage));
		list.Add(new Tuple<string, string>("width", Screen.width.ToString()));
		list.Add(new Tuple<string, string>("height", Screen.height.ToString()));
		List<Tuple<string, string>> list2 = list;
		if (force)
		{
			list2.Add(new Tuple<string, string>("forceReplace", "1"));
		}
		Debug.Log($"try generate special offer: {dbKey}\n end {end} (duration {end - currentTimestamp})\ndiscount {discount}");
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GenerateSpecialOffer, list2)));
	}

	public void AcceptSpecialOffer()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AcceptSpecialOffer, postData)));
	}

	public void claimDailyReward(int index)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("claimRweard", index.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ClaimDailyReward, postData)));
	}

	public void checkDaylyRewards()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.CheckDailyReward, postData)));
	}

	public void AcceptRentalOffer(bool buyDiscounted)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("buyRentalDiscounted", buyDiscounted.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.AcceptRentalOffer, postData)));
	}

	public void GetScrapsReward(bool showDialog = false)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("HeartDialogShown", showDialog.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.GetScrapsReward, postData)));
	}

	public void TakeArenaLife()
	{
		Debug.Log("Take player life!");
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.TakeArenaLife, postData)));
	}

	public void BuyArenaHearth()
	{
		Debug.Log("New hearth bought!");
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("hearthPrice", WarArena.instance.extraLiveCost.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.BuyArenaHearth, postData)));
	}

	public void FinishPlayerLeague()
	{
		Debug.Log("BEANSTALK: FINISH PLAYER LEAGUE IN MENU SENT!!!!");
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.FinishPlayerLeague, postData)));
	}

	public void ChangePlayerName(string playerName, bool payForRename = false)
	{
		if (playerName == GameLoginManager.currentPlayer.name)
		{
			Debug.Log("Same name, not sending");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Name", playerName));
		list.Add(new Tuple<string, string>("PayForRename", (!payForRename) ? "0" : "1"));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ChangePlayerName, postData)));
		LoadingDialog.ShowLoading(Localization.Localize("ID_UPDATINGACCOUNT"));
	}

	public void UpdateRegionPings(Dictionary<CloudRegionCode, int> regions, InternetConnection connection)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("Regions", JsonConvert.SerializeObject(regions)));
		list.Add(new Tuple<string, string>("Connection", connection.ToString()));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.UpdateRegionPings, postData)));
	}

	public void PhotonIsFull()
	{
		List<Tuple<string, string>> postData = new List<Tuple<string, string>>();
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.PhotonIsFull, postData)));
	}

	public void RestoreTransactions()
	{
		inAppHandler.RestoreTransactions();
	}

	public void CheckIfExistGcAccount(string gcID)
	{
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("GameCenterId", gcID));
		List<Tuple<string, string>> postData = list;
		StartCoroutine(RadicalRoutine.Run(CreateServerRequest(DatabaseAction.ExistGCAccount, postData)));
	}

	public void CheckIsOnline(Action succesContinue)
	{
		Debug.Log("checking connection");
		StartCoroutine(RadicalRoutine.Run(ConnectionCheck(succesContinue)));
	}

	private HTTPRequest GetCheckRequest(int i)
	{
		int timeout = GetTimeout(i, DatabaseAction.CreateAccount);
		int num = mServerUrl.LastIndexOf('/');
		string uriString = mServerUrl.Substring(0, num + 1) + "check.php";
		HTTPRequest hTTPRequest = new HTTPRequest(new Uri(uriString), HTTPMethods.Post, OnRequestSend);
		hTTPRequest.Timeout = TimeSpan.FromSeconds(timeout);
		hTTPRequest.ConnectTimeout = TimeSpan.FromSeconds(timeout);
		hTTPRequest.DisableRetry = true;
		hTTPRequest.DisableCache = true;
		HTTPRequest hTTPRequest2 = hTTPRequest;
		hTTPRequest2.CustomCertificationValidator += OnCertificationValidation;
		return hTTPRequest2;
	}

	private IEnumerator ConnectionCheck(Action succesContinue)
	{
		int counter = 0;
		while (mIsSending || waitForInput)
		{
			counter++;
			yield return null;
		}
		if (counter > 0)
		{
		}
		try
		{
			mIsSending = true;
			string errorMessage = string.Empty;
			float waitingTime = 2f;
			for (int i = 0; i < 5; i++)
			{
				errorMessage = string.Empty;
				HTTPRequest download = GetCheckRequest(i);
				if (CachedApplicationInternetReachability.internetReachability != NetworkReachability.NotReachable)
				{
					download.Send();
					while (download.State <= HTTPRequestStates.Processing)
					{
						yield return null;
					}
					if (download.Response == null || string.IsNullOrEmpty(download.Response.DataAsText))
					{
						download.Exception = new SocketException(11001);
					}
					if (download.Exception != null)
					{
						errorMessage = download.Exception.Message;
						if (download.Exception is SocketException { SocketErrorCode: SocketError.HostNotFound })
						{
							Debug.Log("Beanstalk: Internet Offline while checking connection: " + download.CurrentUri);
							if (i < 2)
							{
								i = 2;
							}
						}
						Debug.Log("Beanstalk Error (try = " + (i + 1) + "): " + errorMessage + ", action = connection check");
						if (i + 1 < 5)
						{
							yield return new WaitForRealSeconds(waitingTime);
						}
						waitingTime *= 2f;
						if (waitingTime > 15f)
						{
							waitingTime = 15f;
						}
						continue;
					}
					string text = download.Response.DataAsText;
					Debug.Log("response: " + text);
					dataDownloaded += download.Downloaded;
					if (text == "ok")
					{
						succesContinue();
					}
					else
					{
						errorMessage = text;
					}
					break;
				}
				Debug.LogError("Beanstalk check: Application not reachable!");
				errorMessage = "No connection.";
				break;
			}
			if (!string.IsNullOrEmpty(errorMessage) && !Singleton<GameController>.instance.isTutorial)
			{
				Debug.Log("Beanstalk Error: " + errorMessage + ", action = check connection");
				if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
				{
					ServerErrorHandler.Retry();
				}
			}
		}
		finally
		{
			mIsSending = false;
		}
	}
}
