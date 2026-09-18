using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class MatchManager : Singleton<MatchManager>
{
	private static Dictionary<MatchState, Tuple<string, string>> mMatchStateIds = new Dictionary<MatchState, Tuple<string, string>>
	{
		{
			MatchState.ConnectingToPhoton,
			new Tuple<string, string>("ID_STATE_CONNECTINGTOSERVER", "ID_STATE_CONNECTINGTOSERVER")
		},
		{
			MatchState.WaitingForOpponent,
			new Tuple<string, string>("ID_STATE_SELECTINGWARCARDS", "ID_STATE_WAITINGFOROPPONENT")
		},
		{
			MatchState.BothPlayersConnected,
			new Tuple<string, string>("ID_STATE_SELECTINGWARCARDS", "ID_STATE_SELECTINGWARCARDS")
		},
		{
			MatchState.GameCancelled,
			new Tuple<string, string>("ID_STATE_CONNECTINGTOSERVER", "ID_STATE_OPPONENTDISCONECTED")
		},
		{
			MatchState.GameLoading,
			new Tuple<string, string>(string.Empty, string.Empty)
		},
		{
			MatchState.GameFinished,
			new Tuple<string, string>(string.Empty, string.Empty)
		}
	};

	private static Dictionary<MatchState, string> mMatchLoadingStateIds = new Dictionary<MatchState, string>
	{
		{
			MatchState.ConnectingToPhoton,
			"ID_STATE_WAITINGFOROPPONENT"
		},
		{
			MatchState.WaitingForOpponent,
			"ID_STATE_WAITINGFOROPPONENT"
		},
		{
			MatchState.BothPlayersConnected,
			"ID_STATE_OPPONENTSELECTINGWARCARDS"
		},
		{
			MatchState.GameCancelled,
			"ID_STATE_OPPONENTDISCONECTED"
		},
		{
			MatchState.GameLoading,
			"ID_STATE_GAMELOADING"
		},
		{
			MatchState.GameFinished,
			string.Empty
		}
	};

	private static Dictionary<PlayerNetworkStatus.MatchState, string> mPlayerState = new Dictionary<PlayerNetworkStatus.MatchState, string>
	{
		{
			PlayerNetworkStatus.MatchState.ConnectingToPhoton,
			"ID_STATE_CONNECTINGTOSERVER"
		},
		{
			PlayerNetworkStatus.MatchState.Connected,
			"ID_STATE_SELECTINGWARCARDS"
		},
		{
			PlayerNetworkStatus.MatchState.CardsChosen,
			"ID_STATE_READYFORBATTLE"
		},
		{
			PlayerNetworkStatus.MatchState.GameLoading,
			string.Empty
		},
		{
			PlayerNetworkStatus.MatchState.LoadingFinished,
			string.Empty
		},
		{
			PlayerNetworkStatus.MatchState.Playing,
			string.Empty
		},
		{
			PlayerNetworkStatus.MatchState.GameFinished,
			string.Empty
		},
		{
			PlayerNetworkStatus.MatchState.Rematch,
			string.Empty
		}
	};

	public static float reconnectTime;

	private static InvitationState mInvitationState;

	public static float invitationExpireTime;

	private static MatchState mMatchState;

	public static float matchStartTime;

	public static float rematchExpireTime;

	private float mDamageAmount;

	private PlayerController mOpponent;

	private PhotonView mPhotonView;

	private PlayerController mPlayer;

	private float mMatchTime;

	private static float[] mReconnectTimes = new float[3] { 30f, 20f, 10f };

	public static string matchStatusPlayer => (!string.IsNullOrEmpty(mMatchStateIds[matchState].Value1)) ? Localization.Localize(mMatchStateIds[matchState].Value1) : string.Empty;

	public static string matchStatusOpponent
	{
		get
		{
			if (Singleton<GameController>.instance.opponent != null)
			{
				string text = mPlayerState[Singleton<GameController>.instance.opponent.networkStatus.matchState];
				return (!string.IsNullOrEmpty(text)) ? Localization.Localize(text) : string.Empty;
			}
			if (matchState == MatchState.WaitingForOpponent)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
			}
			if (matchState == MatchState.BothPlayersConnected)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
			}
			return (!string.IsNullOrEmpty(mMatchStateIds[matchState].Value2)) ? Localization.Localize(mMatchStateIds[matchState].Value2) : string.Empty;
		}
	}

	public static string matchStatusFriend
	{
		get
		{
			if (Singleton<GameController>.instance.friend != null)
			{
				string text = mPlayerState[Singleton<GameController>.instance.friend.networkStatus.matchState];
				return (!string.IsNullOrEmpty(text)) ? Localization.Localize(text) : string.Empty;
			}
			if (matchState == MatchState.WaitingForOpponent)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
			}
			if (matchState == MatchState.BothPlayersConnected)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
			}
			return (!string.IsNullOrEmpty(mMatchStateIds[matchState].Value2)) ? Localization.Localize(mMatchStateIds[matchState].Value2) : string.Empty;
		}
	}

	public static string matchStatusLoading
	{
		get
		{
			if (matchState == MatchState.WaitingForOpponent || matchState == MatchState.ConnectingToPhoton)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
			}
			if (matchState == MatchState.BothPlayersConnected)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
			}
			return (!string.IsNullOrEmpty(mMatchLoadingStateIds[matchState])) ? Localization.Localize(mMatchLoadingStateIds[matchState]) : string.Empty;
		}
	}

	public static string matchStatusAfterMatch
	{
		get
		{
			if (reconnectState == ReconnectState.Me)
			{
				return Localization.Localize("ID_STATE_DISCONNECTED");
			}
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				string text = MatchStatusAfterMatch(Singleton<GameController>.instance.friend, isFriend: true);
				if (text != null)
				{
					return text;
				}
			}
			else
			{
				string text2 = MatchStatusAfterMatch(Singleton<GameController>.instance.opponent);
				if (text2 != null)
				{
					return text2;
				}
			}
			return string.Empty;
		}
	}

	public static float invitationTimeRemaining => invitationExpireTime - Time.realtimeSinceStartup;

	public static string matchTimeStatus
	{
		get
		{
			float seconds = matchStartTime - Time.realtimeSinceStartup;
			float seconds2 = rematchExpireTime - Time.realtimeSinceStartup;
			float seconds3 = invitationTimeRemaining;
			string empty = string.Empty;
			if (Singleton<GameController>.instance.isCampaignBot)
			{
				return string.Empty;
			}
			if (reconnectState == ReconnectState.Me)
			{
				return string.Empty;
			}
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				string text = MatchTimeStatusForOtherPlayer(Singleton<GameController>.instance.friend);
				if (text != null)
				{
					return text;
				}
			}
			else
			{
				string text2 = MatchTimeStatusForOtherPlayer(Singleton<GameController>.instance.opponent);
				if (text2 != null)
				{
					return text2;
				}
			}
			if (PlayerController.currentPlayer != null)
			{
				PlayerNetworkStatus networkStatus = PlayerController.currentPlayer.networkStatus;
				if (networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
				{
					return Localization.LocalizeFormat("ID_REMATCH_VALID_FOR", MiscTools.PrintableTimeTwoDigits(seconds2));
				}
			}
			switch (mMatchState)
			{
			case MatchState.ConnectingToPhoton:
			case MatchState.WaitingForOpponent:
				if (invitationState == InvitationState.Waiting)
				{
					return Localization.LocalizeFormat("ID_INVITATION_VALID_FOR", MiscTools.PrintableTimeTwoDigits(seconds3));
				}
				return string.Empty;
			case MatchState.GameCancelled:
			case MatchState.GameFinished:
				return string.Empty;
			default:
				return Localization.LocalizeFormat("ID_MATCH_STARTS_IN", MiscTools.PrintableTimeTwoDigits(seconds));
			}
		}
	}

	public static float timeLeft
	{
		get
		{
			float result = float.MaxValue;
			if (!Singleton<GameController>.instance.isCampaignBot && reconnectState != ReconnectState.Me)
			{
				float num = matchStartTime - Time.realtimeSinceStartup;
				float result2 = rematchExpireTime - Time.realtimeSinceStartup;
				float num2 = invitationTimeRemaining;
				if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
				{
					float? num3 = TimeLeftForOtherPlayer(Singleton<GameController>.instance.friend);
					if (num3.HasValue)
					{
						return num3.Value;
					}
				}
				else
				{
					float? num4 = TimeLeftForOtherPlayer(Singleton<GameController>.instance.opponent);
					if (num4.HasValue)
					{
						return num4.Value;
					}
				}
				if (PlayerController.currentPlayer != null)
				{
					PlayerNetworkStatus networkStatus = PlayerController.currentPlayer.networkStatus;
					if (networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
					{
						return result2;
					}
				}
				switch (mMatchState)
				{
				case MatchState.ConnectingToPhoton:
				case MatchState.WaitingForOpponent:
					if (invitationState == InvitationState.Waiting)
					{
						result = num2;
					}
					break;
				default:
					result = num;
					break;
				case MatchState.GameCancelled:
				case MatchState.GameFinished:
					break;
				}
			}
			return result;
		}
	}

	public bool isOverTime { get; private set; }

	public static bool isReconnect => reconnectState != ReconnectState.None && Singleton<GameController>.instance.isLoadingOrPlaying;

	public static bool allPlayersFinishetStartAnimation
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				if (!player.Value.networkStatus.startAnimationFinished)
				{
					return false;
				}
			}
			return Singleton<GameController>.instance.isLoadingOrPlaying;
		}
	}

	public float matchTime
	{
		get
		{
			return mMatchTime;
		}
		set
		{
			Debug.Log($"MATCH MANAGER - MATCH TIME - SAVING {value} SECONDS");
			mMatchTime = value;
			StatsManager.instance.matchStats.secondsPlayed = (int)mMatchTime;
		}
	}

	public static bool canFight
	{
		get
		{
			bool flag = matchState != MatchState.ConnectingToPhoton && matchState != MatchState.GameCancelled;
			flag &= !isReconnect;
			if (Singleton<GameController>.instance.isDeathMatch)
			{
				if (Singleton<GameController>.instance.isRandomMatchMaking)
				{
					return flag;
				}
				return flag && matchState != MatchState.WaitingForOpponent;
			}
			return flag && matchState != MatchState.WaitingForOpponent;
		}
	}

	public static bool canRematch
	{
		get
		{
			if (Singleton<GameController>.instance.isRandomMatchMaking)
			{
				return true;
			}
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCoopBot)
			{
				PlayerController friend = Singleton<GameController>.instance.friend;
				return friend != null && friend.networkStatus.canRematch && PlayerController.currentPlayer.networkStatus.canRematch;
			}
			PlayerController opponent = Singleton<GameController>.instance.opponent;
			return opponent != null && opponent.networkStatus.canRematch && PlayerController.currentPlayer.networkStatus.canRematch;
		}
	}

	public static bool beforeMatch
	{
		get
		{
			switch (mMatchState)
			{
			case MatchState.ConnectingToPhoton:
			case MatchState.WaitingForOpponent:
			case MatchState.BothPlayersConnected:
				return true;
			default:
				return false;
			}
		}
	}

	public static bool afterMatch => mMatchState >= MatchState.GameFinished;

	public static MatchState matchState
	{
		get
		{
			return mMatchState;
		}
		set
		{
			if (mMatchState != value)
			{
				mMatchState = value;
				Debug.Log("Set match state: " + matchState);
				if (MatchManager.MatchStateChanged != null)
				{
					MatchManager.MatchStateChanged(value);
				}
			}
		}
	}

	public static InvitationState invitationState
	{
		get
		{
			return mInvitationState;
		}
		set
		{
			mInvitationState = value;
		}
	}

	public static ReconnectState reconnectState
	{
		get
		{
			if (PlayerController.currentPlayer.networkStatus.disconected)
			{
				return ReconnectState.Me;
			}
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				if (player.Value.networkStatus.disconected && player.Value.networkStatus.active)
				{
					return ReconnectState.Other;
				}
			}
			return ReconnectState.None;
		}
	}

	public static float reconnectLength
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				if (player.Value.networkStatus.disconected && player.Value.networkStatus.active)
				{
					int num = Mathf.Clamp(player.Value.networkStatus.reconnectsCount - 1, 0, 2);
					return mReconnectTimes[num];
				}
			}
			return 15f;
		}
	}

	public static event Action<MatchState> MatchStateChanged;

	public event Action OverTimeStarted;

	private static string MatchStatusAfterMatch(PlayerController player, bool isFriend = false)
	{
		float num = rematchExpireTime - Time.realtimeSinceStartup;
		if ((bool)player)
		{
			PlayerNetworkStatus networkStatus = player.networkStatus;
			if (networkStatus.connectionState == PlayerNetworkStatus.ConnectionState.Disconnected)
			{
				return Localization.Localize((!isFriend) ? "ID_STATE_OPPONENTDOESNTWANTREMATCH" : "ID_STATE_FRIENDDOESNTWANTREMATCH");
			}
			if (networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
			{
				return Localization.Localize((!isFriend) ? "ID_STATE_OPPONENTISREADYTOBATTLE" : "ID_STATE_FRIENDISREADYTOBATTLE");
			}
			if (networkStatus.matchState == PlayerNetworkStatus.MatchState.GameFinished)
			{
				return Localization.Localize("ID_STATE_GAMEFINISHED");
			}
		}
		return null;
	}

	private static string MatchTimeStatusForOtherPlayer(PlayerController player)
	{
		float seconds = rematchExpireTime - Time.realtimeSinceStartup;
		if ((bool)player)
		{
			PlayerNetworkStatus networkStatus = player.networkStatus;
			if (networkStatus.connectionState == PlayerNetworkStatus.ConnectionState.Disconnected)
			{
				return string.Empty;
			}
			if (networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
			{
				return Localization.LocalizeFormat("ID_ACCEPT_REMATCH_IN", MiscTools.PrintableTimeTwoDigits(seconds));
			}
		}
		return null;
	}

	private static float? TimeLeftForOtherPlayer(PlayerController player)
	{
		if (player != null)
		{
			float value = rematchExpireTime - Time.realtimeSinceStartup;
			PlayerNetworkStatus networkStatus = Singleton<GameController>.instance.opponent.networkStatus;
			if (networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch)
			{
				return value;
			}
		}
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
	}

	private void InstanceOnGameStarted()
	{
		isOverTime = false;
	}

	public void StartOverTime(PlayerController player, PlayerController opponent)
	{
		mPlayer = player;
		mOpponent = opponent;
		StartCoroutine(RadicalRoutine.Run(Overtime()));
		isOverTime = true;
		if (this.OverTimeStarted != null)
		{
			this.OverTimeStarted();
		}
		mPhotonView.RPC("StartOverTime_RPC", PhotonTargets.Others);
		float num = Mathf.Max(player.destroyableParts.maxHealth, opponent.destroyableParts.maxHealth);
		mDamageAmount = num / 30f * 2f;
	}

	[PunRPC]
	public void StartOverTime_RPC()
	{
		Debug.Log("Start overtime RPC");
		isOverTime = true;
		if (this.OverTimeStarted != null)
		{
			this.OverTimeStarted();
		}
	}

	private IEnumerator Overtime()
	{
		Debug.Log("Start overtime");
		Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateHeavy);
		foreach (MapDefinition.DefendPosition point in Singleton<MapManager>.instance.currentMapDef.playersPositions)
		{
			point.point.shield.autoRepair = false;
			if ((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DestroyShieldsInOverTime).FLOATVALUE > 0f)
			{
				point.point.shield.DestroyShield();
			}
		}
		yield return null;
	}

	public void SetHitBy(DestroyableObject.DamageInfo arg)
	{
		try
		{
			PlayerController playerController = arg.owner as PlayerController;
			AIObject aIObject = arg.owner as AIObject;
			if (playerController != null)
			{
				SetHitByPlayer(playerController);
			}
			else if (aIObject != null)
			{
				if (aIObject.spawnedByCard)
				{
					Card cardInstanceAll = CardManager.instance.GetCardInstanceAll(aIObject.cardId);
					if (cardInstanceAll == null)
					{
						SetHitByUnit(aIObject.preparedBehaviour.unitDictionaryId, aIObject.spawnedCardLevel, aIObject.preparedBehaviour.upgradeSlots.iconName);
					}
					else
					{
						SetHitByUnit(cardInstanceAll.id, 0, cardInstanceAll.iconName, isCard: true);
					}
				}
				else if (aIObject.preparedBehaviour != null && aIObject.preparedBehaviour.upgradeSlots != null)
				{
					LevelBehaviour preparedBehaviour = aIObject.preparedBehaviour;
					SetHitByUnit(preparedBehaviour.unitDictionaryId, preparedBehaviour.upgradeSlots.GetActualLevelForIndex(aIObject.unitUpgrades.slotUpgradeindex), preparedBehaviour.upgradeSlots.iconName);
				}
			}
			else
			{
				SetHitByEnviroment();
			}
		}
		catch (Exception e)
		{
			Crittercism.LogHandledException(e);
		}
	}

	private void SetHitByPlayer(PlayerController playerControler)
	{
		GuiScreenSingle<GameOverScreen>.instance.PlayerHit(playerControler);
		if (playerControler.playerProperties.photonPlayer != null)
		{
			mPhotonView.RPC("SetHitByPlayerRPC", PhotonTargets.Others, playerControler.playerProperties.photonPlayer.ID);
		}
	}

	[PunRPC]
	private void SetHitByPlayerRPC(int playerID)
	{
		Debug.Log("SetHitByPlayerRPC " + playerID);
		PlayerController playerControler = PlayerController.players[playerID];
		GuiScreenSingle<GameOverScreen>.instance.PlayerHit(playerControler);
	}

	private void SetHitByUnit(string unitN, int unitL, string unitSprite, bool isCard = false)
	{
		Debug.Log("SetHitByUnit , " + unitN + ", " + unitL + ", " + unitSprite + ", " + isCard);
		GuiScreenSingle<GameOverScreen>.instance.UnitHit(unitN, unitL, unitSprite, isCard);
		mPhotonView.RPC("SetHitByUnitRPC", PhotonTargets.Others, unitN, unitL, unitSprite, isCard);
	}

	[PunRPC]
	private void SetHitByUnitRPC(string unitN, int unitL, string unitSprite, bool isCard)
	{
		GuiScreenSingle<GameOverScreen>.instance.UnitHit(unitN, unitL, unitSprite, isCard);
	}

	private void SetHitByEnviroment()
	{
		GuiScreenSingle<GameOverScreen>.instance.EnviromentalHit();
		mPhotonView.RPC("EnviromentalHitRPC", PhotonTargets.Others);
	}

	[PunRPC]
	private void EnviromentalHitRPC()
	{
		GuiScreenSingle<GameOverScreen>.instance.EnviromentalHit();
	}
}
