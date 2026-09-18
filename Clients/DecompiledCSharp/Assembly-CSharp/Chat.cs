using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using EeekSoft.Text;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Chat;
using Google2u;
using UnityEngine;

public class Chat : Singleton<Chat>, IChatClientListener
{
	public enum ChatMessageType
	{
		Message,
		Timer,
		SquadAction,
		Null
	}

	public enum SquadActionType
	{
		Demotion,
		Kick,
		Promotion,
		JoinedSquad,
		Left
	}

	public struct ChatRecordData
	{
		public ChatMessageType chatType;

		public string playerId;

		public string name;

		public int level;

		public string squadName;

		public string squadIcon;

		public bool isBeginnersLeague;

		public int beginnersLeague;

		public League league;

		public string message;

		public bool squadMessage;

		public SquadRank squadRank;

		public int time;

		public string databaseMessageId;

		public DatabaseMessage databaseMessage;

		public SquadActionType squadActionType;

		public int newSquadRank;

		public DatabasePlayer byPlayer;

		public WarArenaCrown warArenaCrown;

		private float mChatRecordHeight;

		public float chatRecordHeight
		{
			get
			{
				return mChatRecordHeight;
			}
			set
			{
				mChatRecordHeight = value;
			}
		}

		public void SetHeight(float height)
		{
			mChatRecordHeight = height;
		}

		public static ChatRecordData CreateNull()
		{
			return new ChatRecordData
			{
				chatType = ChatMessageType.Null
			};
		}

		public static ChatRecordData CreateTime(int time)
		{
			return new ChatRecordData
			{
				chatType = ChatMessageType.Timer,
				time = time,
				playerId = string.Empty,
				name = string.Empty,
				level = -1,
				squadName = string.Empty,
				squadIcon = string.Empty,
				isBeginnersLeague = false,
				beginnersLeague = 1,
				league = League.NoLeague,
				message = string.Empty,
				squadMessage = false,
				squadRank = SquadRank.None,
				databaseMessageId = string.Empty,
				squadActionType = SquadActionType.Promotion,
				newSquadRank = -1,
				chatRecordHeight = -1f
			};
		}

		public static ChatRecordData ParsePhotonChatMessage(string nameID, string[] messageContent, bool squadMessage)
		{
			ChatRecordData result = new ChatRecordData
			{
				chatType = ChatMessageType.Message,
				playerId = nameID,
				name = messageContent[0]
			};
			if (!int.TryParse(messageContent[1], out result.level))
			{
				result.level = 1;
			}
			result.squadName = messageContent[2];
			result.squadIcon = messageContent[3];
			int result2 = 0;
			int.TryParse(messageContent[4], out result2);
			result.isBeginnersLeague = result2 < 0;
			result.league = (League)(result.beginnersLeague = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(messageContent[5], out result3);
			result.squadRank = (SquadRank)result3;
			result.message = messageContent[6];
			result.squadMessage = squadMessage;
			if (!int.TryParse(messageContent[7], out result.time))
			{
				result.time = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
			if (messageContent.Length == 8)
			{
				result.warArenaCrown = WarArenaCrown.None;
			}
			else if (messageContent.Length == 9)
			{
				int result4 = 0;
				int.TryParse(messageContent[8], out result4);
				result.warArenaCrown = (WarArenaCrown)result4;
			}
			result.databaseMessageId = string.Empty;
			result.squadActionType = SquadActionType.Promotion;
			result.newSquadRank = -1;
			result.chatRecordHeight = -1f;
			return result;
		}

		public static ChatRecordData CreateSquadAction(DatabaseMessage databaseMessage)
		{
			ChatRecordData result = new ChatRecordData
			{
				chatType = ChatMessageType.SquadAction,
				databaseMessage = databaseMessage
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			SquadPromoteMessage squadPromoteMessage = databaseMessage as SquadPromoteMessage;
			SquadDemoteMessage squadDemoteMessage = databaseMessage as SquadDemoteMessage;
			SquadJoinedMessage squadJoinedMessage = databaseMessage as SquadJoinedMessage;
			SquadLeftMessage squadLeftMessage = databaseMessage as SquadLeftMessage;
			if (squadPromoteMessage != null)
			{
				databasePlayer = squadPromoteMessage.promotedPlayer;
				if (squadPromoteMessage.adminPlayer != null)
				{
					result.byPlayer = squadPromoteMessage.adminPlayer;
				}
				result.squadActionType = SquadActionType.Promotion;
				result.newSquadRank = squadPromoteMessage.newRank;
			}
			if (squadDemoteMessage != null)
			{
				databasePlayer = squadDemoteMessage.demotedPlayer;
				if (squadDemoteMessage.adminPlayer != null)
				{
					result.byPlayer = squadDemoteMessage.adminPlayer;
				}
				result.newSquadRank = squadDemoteMessage.newRank;
				if (result.newSquadRank == -1)
				{
					result.squadActionType = SquadActionType.Kick;
				}
				else
				{
					result.squadActionType = SquadActionType.Demotion;
				}
			}
			if (squadJoinedMessage != null)
			{
				databasePlayer = squadJoinedMessage.newMember;
				result.squadActionType = SquadActionType.JoinedSquad;
				result.newSquadRank = -1;
			}
			if (squadLeftMessage != null)
			{
				databasePlayer = squadLeftMessage.playerThatLeft;
				result.squadActionType = SquadActionType.Left;
				result.newSquadRank = -1;
			}
			result.playerId = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.name = databasePlayer.name;
			result.level = databasePlayer.level;
			result.warArenaCrown = databasePlayer.warArenaCrown;
			result.time = databaseMessage.messageTime;
			result.databaseMessageId = databaseMessage.messageId;
			result.squadName = string.Empty;
			result.squadIcon = string.Empty;
			result.isBeginnersLeague = false;
			result.beginnersLeague = 1;
			result.league = League.NoLeague;
			result.message = string.Empty;
			result.squadMessage = true;
			result.squadRank = SquadRank.Member;
			result.chatRecordHeight = -1f;
			return result;
		}

		public bool Equals(ChatRecordData otherData)
		{
			if (chatType == ChatMessageType.Timer)
			{
				return otherData.chatType == ChatMessageType.Timer && time == otherData.time;
			}
			if (chatType == ChatMessageType.SquadAction)
			{
				return otherData.chatType == ChatMessageType.SquadAction && squadActionType == otherData.squadActionType && time == otherData.time && playerId != null && playerId.Equals(otherData.playerId);
			}
			return otherData.chatType == ChatMessageType.Message && time == otherData.time && playerId != null && playerId.Equals(otherData.playerId) && message != null && message.Equals(otherData.message);
		}

		public static bool operator ==(ChatRecordData data1, ChatRecordData data2)
		{
			return data1.Equals(data2);
		}

		public static bool operator !=(ChatRecordData data1, ChatRecordData data2)
		{
			return !data1.Equals(data2);
		}
	}

	public static string separator = "\t";

	public ChatClient chatClient;

	[HideInInspector]
	public TextAsset badWords;

	private ChatChannel mSelectedChannel;

	private string mSelectedChannelName;

	private StringSearch mTextSearch;

	private string mAppId = "8b004c04-6921-4613-9815-e63b42db4a7c";

	private string mChatVersion = "1.0";

	private string mSquadChatName = string.Empty;

	private bool mDisconnected;

	private float mNextReconnectTime;

	private Dictionary<string, int> mCacheOfSendMessages = new Dictionary<string, int>();

	private Regex beginRegex = new Regex("([-_:]|\\s)");

	private Regex endRegex = new Regex("([,.!\\?-_:;]|\\s)");

	private bool isLegacy13Chat => 1 == (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChatTempLegacyVersion13).FLOATVALUE;

	public string[] chatPublicChannels
	{
		get
		{
			if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			{
				return new string[0];
			}
			return string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) ? new string[1] { "global" } : new string[2]
			{
				"global",
				GameLoginManager.currentPlayer.squadName
			};
		}
	}

	public bool connectingPhotonChat => chatClient.State == ChatState.ConnectedToNameServer || chatClient.State == ChatState.Authenticated;

	public bool connectedToPhotonChat => chatClient.State == ChatState.ConnectedToFrontEnd;

	public bool shouldChat
	{
		get
		{
			if (Singleton<GameController>.instance.isTutorial || !Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			{
				return false;
			}
			return GameLoginManager.currentPlayer.isFacebookConnected || GameLoginManager.currentPlayer.isGameCenterConnected || GameLoginManager.currentPlayer.isGooglePlayConnected || DebugSettings.debugEnabled;
		}
	}

	public bool checkChatConnection
	{
		get
		{
			if (!connectedToPhotonChat)
			{
				string text = Localization.Localize("ID_CHATCANNOTSENDMESSAGES");
				if (DebugSettings.debugEnabled)
				{
					text = text + "\n\nDEBUG STATE: " + chatClient.State;
				}
				GuiElementSingle<ChatGuiElement>.instance.chatContent.ShowError(text);
				return false;
			}
			GuiElementSingle<ChatGuiElement>.instance.chatContent.HideError();
			return true;
		}
	}

	public event Action<string, ChatRecordData[]> newArrivedMessages;

	public bool IsSquadChannel(string channel)
	{
		return !string.IsNullOrEmpty(channel) && chatPublicChannels.Length > 0 && channel != chatPublicChannels[0] && chatPublicChannels.Length > 1 && channel == chatPublicChannels[1];
	}

	public bool IsCorrectChannel(string channel, int index)
	{
		if (index < 0 || index >= chatPublicChannels.Length)
		{
			return false;
		}
		return channel == chatPublicChannels[index];
	}

	protected override void Awake()
	{
		base.Awake();
		if (Singleton<BeanstalkServerManager>.instance.environment != DatabaseEnvironment.Production)
		{
			mAppId = "55a90af8-a7bb-4152-a5e4-639d7488b0fb";
		}
		chatClient = new ChatClient(this);
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		GameLoginManager.instance.PlayerJoinedSquad += OnPlayerJoinedSquad;
		GameLoginManager.instance.PlayerLeftSquad += OnPlayerLeftSquad;
		DebugSettings.instance.Changed += OnDebugChanged;
		string text = badWords.text;
		string[] keywords = text.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
		mTextSearch = new StringSearch(keywords);
		Singleton<BeanstalkServerManager>.instance.UserWasLoggetOut += OnUserWasLoggetOut;
	}

	private void OnDataLoaded(DatabaseAction databaseAction)
	{
		if (databaseAction == DatabaseAction.AddFacebook)
		{
			OnPlayerDataLoaded();
		}
	}

	private void OnUserWasLoggetOut()
	{
		Disconnect();
	}

	private void OnDebugChanged()
	{
		if (shouldChat)
		{
			Connect();
		}
	}

	public void Connect()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			if (!shouldChat)
			{
				Debug.LogWarning("Chat: Connect - Cannot connect because player should not chat");
				mDisconnected = false;
			}
			else if (!connectingPhotonChat && !connectedToPhotonChat && !Singleton.applicationIsQuitting)
			{
				DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
				mSquadChatName = generatedCurrentPlayer.squadName;
				mCacheOfSendMessages.Clear();
				chatClient.Connect(mAppId, mChatVersion + Singleton<BeanstalkServerManager>.instance.environmentName, new ExitGames.Client.Photon.Chat.AuthenticationValues
				{
					UserId = GameLoginManager.currentPlayer.id
				});
			}
		}
	}

	public void Disconnect()
	{
		if (chatClient != null)
		{
			chatClient.Disconnect();
			Debug.LogWarning("Chat: Disconnect");
		}
	}

	private void OnPlayerDataLoaded()
	{
		if (connectedToPhotonChat)
		{
			Disconnect();
		}
		Connect();
		bool flag = GuiElementSingle<ChatGuiElement>.instance.chatContent.isSelectedSquadChat && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		SelectPublicChannel(flag ? 1 : 0);
	}

	private void OnPlayerJoinedSquad(string squadName)
	{
		Debug.Log("Chat: Player Joined Squad //" + squadName + "//");
		mSquadChatName = squadName;
		OnPlayerDataLoaded();
	}

	private void OnPlayerLeftSquad()
	{
		mSquadChatName = string.Empty;
		OnPlayerDataLoaded();
	}

	public void OnApplicationQuit()
	{
		Disconnect();
	}

	protected void Update()
	{
		if (chatClient != null)
		{
			chatClient.Service();
		}
		if (Singleton<GameController>.instance.gameState == GameController.GameState.Menu && mDisconnected && mNextReconnectTime < Time.time)
		{
			mNextReconnectTime = Time.time + 2f;
			if (CachedApplicationInternetReachability.internetReachability != NetworkReachability.NotReachable && chatClient.State == ChatState.Disconnected)
			{
				Connect();
			}
		}
	}

	public void SelectPublicChannel(int index)
	{
		if (chatPublicChannels.Length == 0)
		{
			mSelectedChannelName = "global";
			Debug.LogWarning("Chat: Trying to change public channel, but player data are not loaded yet.");
		}
		else
		{
			mSelectedChannelName = chatPublicChannels[index];
		}
	}

	public void SelectPrivateChannel(string channelName)
	{
	}

	public bool ContainsBadWord(string message)
	{
		StringSearchResult[] array = mTextSearch.FindAll(message.ToLower());
		StringSearchResult[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && IsWholeWord(message.ToLower(), stringSearchResult.Keyword))
			{
				return true;
			}
		}
		return false;
	}

	private bool IsWholeWord(string wholeText, string phrase)
	{
		if (wholeText.StartsWith(phrase))
		{
			int length = phrase.Length;
			return wholeText.Length == length || endRegex.IsMatch(wholeText[length].ToString());
		}
		if (wholeText.EndsWith(phrase))
		{
			int index = wholeText.Length - phrase.Length - 1;
			return beginRegex.IsMatch(wholeText[index].ToString());
		}
		int num = wholeText.IndexOf(phrase, 1) - 1;
		int num2 = num + phrase.Length + 1;
		if (num < 0 || num2 >= wholeText.Length)
		{
			return false;
		}
		return beginRegex.IsMatch(wholeText[num].ToString()) && endRegex.IsMatch(wholeText[num2].ToString());
	}

	public string CreateChatMessage(string text)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		string text2 = generatedCurrentPlayer.name;
		string text3 = generatedCurrentPlayer.level.ToString();
		string text4 = string.Empty;
		string text5 = string.Empty;
		int num = 0;
		if (generatedCurrentPlayer.isInBeginnersLeague)
		{
			num = -1 * generatedCurrentPlayer.beginnersLeague;
		}
		else if (generatedCurrentPlayer.isInLeague)
		{
			num = (int)generatedCurrentPlayer.leagueTier;
		}
		string text6 = num.ToString();
		int squadRank = (int)generatedCurrentPlayer.squadRank;
		string text7 = squadRank.ToString();
		string text8 = ((int)generatedCurrentPlayer.warArenaCrown).ToString();
		string text9 = Singleton<BeanstalkServerManager>.instance.currentTimestamp.ToString();
		if (!string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			text4 = generatedCurrentPlayer.squadName;
			text5 = GameLoginManager.instance.squadIconName;
		}
		if (isLegacy13Chat)
		{
			return text2.Replace(separator, "-") + separator + text3 + separator + text4.Replace(separator, "-") + separator + text5 + separator + text6 + separator + text7 + separator + CheckBadWords(text.Replace(separator, string.Empty)) + separator + text9;
		}
		return text2.Replace(separator, "-") + separator + text3 + separator + text4.Replace(separator, "-") + separator + text5 + separator + text6 + separator + text7 + separator + CheckBadWords(text.Replace(separator, string.Empty)) + separator + text9 + separator + text8;
	}

	public string CheckBadWords(string message)
	{
		StringSearchResult[] array = mTextSearch.FindAll(message.ToLower());
		StringBuilder stringBuilder = new StringBuilder(message);
		StringSearchResult[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && IsWholeWord(message.ToLower(), stringSearchResult.Keyword))
			{
				int num = stringSearchResult.Index + stringSearchResult.Keyword.Length;
				for (int j = stringSearchResult.Index; j < num; j++)
				{
					stringBuilder[j] = '*';
				}
				Regex regex = new Regex("([,.!\\?-_:;]|\\s)");
				for (int k = num - 1; k < message.Length && !regex.IsMatch(stringBuilder[k].ToString()); k++)
				{
					stringBuilder[k] = '*';
				}
			}
		}
		return stringBuilder.ToString();
	}

	public void SendChatMessage(string message)
	{
		if (!string.IsNullOrEmpty(message) && checkChatConnection)
		{
			message = CreateChatMessage(message);
			chatClient.PublishMessage(mSelectedChannelName, message);
			mCacheOfSendMessages.Add(message, 1);
			ChatRecordData chatRecordData = ParseChatMessage(GameLoginManager.currentPlayer.id, message, IsSquadChannel(mSelectedChannelName));
			if (chatRecordData.chatType != ChatMessageType.Null && this.newArrivedMessages != null)
			{
				this.newArrivedMessages(mSelectedChannelName, new ChatRecordData[1] { chatRecordData });
			}
		}
	}

	public void PublishLocalyDebugMessage(ChatRecordData data)
	{
		if (data.chatType != ChatMessageType.Null && this.newArrivedMessages != null)
		{
			this.newArrivedMessages(mSelectedChannelName, new ChatRecordData[1] { data });
		}
	}

	public void DebugReturn(DebugLevel level, string message)
	{
		Debug.Log("ChatClient: " + message);
	}

	public void OnDisconnected()
	{
		if (!mDisconnected)
		{
			Debug.Log("Chat: Disconected: " + chatClient.DisconnectedCause);
			mDisconnected = true;
			string text = Localization.Localize("ID_CHATCANNOTSENDMESSAGESRECONNECTING");
			if (DebugSettings.debugEnabled)
			{
				text = text + "\n\nDEBUG STATE: " + chatClient.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.chatContent.ShowError(text);
		}
	}

	public void OnConnected()
	{
		mDisconnected = false;
		GuiElementSingle<ChatGuiElement>.instance.chatContent.HideError();
		string text = string.Empty;
		string[] array = chatPublicChannels;
		foreach (string text2 in array)
		{
			text = text + text2 + " ";
		}
		Debug.Log("Chat: Connected - Subscribe to: " + text);
		chatClient.Subscribe(chatPublicChannels, (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChatMessagesLimit).FLOATVALUE);
		chatClient.SetOnlineStatus(2);
		GuiElementSingle<ChatGuiElement>.instance.chatContent.ChatConnected();
	}

	public void OnChatStateChange(ChatState state)
	{
	}

	public ChatRecordData ParseChatMessage(string nameID, object message, bool isSquadTabMessage)
	{
		string[] array = message.ToString().Split(separator[0]);
		if (array.Length == 4)
		{
			return ChatRecordData.CreateNull();
		}
		if (array.Length > 9 || array.Length < 8)
		{
			Debug.Log("Chat: Old Chat Message Incommed:\t\tfromID: " + nameID + "\t\tcontent: " + message.ToString());
			string[] array2 = new string[8];
			int num = Mathf.Min(array.Length, 8);
			for (int i = 0; i < num; i++)
			{
				array2[i] = array[i];
			}
			for (int j = num; j < 8; j++)
			{
				array2[j] = string.Empty;
			}
			array = array2;
		}
		return ChatRecordData.ParsePhotonChatMessage(nameID, array, isSquadTabMessage);
	}

	public bool IsPublicChannelSubscribed(string channel)
	{
		bool flag = false;
		string[] array = chatPublicChannels;
		foreach (string text in array)
		{
			if (channel == text)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			Debug.LogWarning("Chat: Got message from channel \"" + channel + "\" which is not subscribed");
		}
		return flag;
	}

	public void OnGetMessages(string channelName, string[] senders, object[] messages)
	{
		if (!IsPublicChannelSubscribed(channelName))
		{
			return;
		}
		List<ChatRecordData> list = new List<ChatRecordData>();
		bool isSquadTabMessage = IsSquadChannel(channelName);
		for (int i = 0; i < messages.Length; i++)
		{
			if (!mCacheOfSendMessages.ContainsKey(messages[i].ToString()))
			{
				ChatRecordData item = ParseChatMessage(senders[i], messages[i], isSquadTabMessage);
				if (item.chatType != ChatMessageType.Null)
				{
					list.Add(item);
				}
			}
			else
			{
				mCacheOfSendMessages.Remove(messages[i].ToString());
			}
		}
		if (list.Count > 0 && this.newArrivedMessages != null)
		{
			this.newArrivedMessages(channelName, list.ToArray());
		}
	}

	private List<ChatRecordData> GetChatMessages(string channelName, List<string> senders, List<object> messages)
	{
		List<ChatRecordData> list = new List<ChatRecordData>();
		bool isSquadTabMessage = IsSquadChannel(channelName);
		for (int i = 0; i < messages.Count; i++)
		{
			ChatRecordData item = ParseChatMessage(senders[i], messages[i], isSquadTabMessage);
			if (item.chatType != ChatMessageType.Null)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public void GetMessages(out List<ChatRecordData> messages)
	{
		if (chatClient != null)
		{
			if (!string.IsNullOrEmpty(mSelectedChannelName))
			{
				if (chatClient.TryGetChannel(mSelectedChannelName, isPrivate: false, out mSelectedChannel))
				{
					messages = GetChatMessages(mSelectedChannelName, mSelectedChannel.Senders, mSelectedChannel.Messages);
					return;
				}
			}
			else
			{
				Debug.LogWarning("Chat: Trying to get messages from null or empty channelName");
			}
		}
		messages = new List<ChatRecordData>();
	}

	public void OnPrivateMessage(string sender, object message, string channelName)
	{
	}

	public void OnSubscribed(string[] channels, bool[] results)
	{
	}

	public void OnUnsubscribed(string[] channels)
	{
		string text = string.Empty;
		foreach (string text2 in channels)
		{
			text = text + text2 + " ";
		}
		Debug.Log("Chat: Channels " + text + "unsubscribed.");
	}

	public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
	{
		mSelectedChannel?.Add("info", $"{user} is {status}. Msg:{message}");
	}

	protected void OnApplicationPause(bool pause)
	{
	}

	protected void OnApplicationResumed()
	{
	}
}
