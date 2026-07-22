using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class GameControllerDeathMatch : GameControllerPVP
{
	private bool MOOCFIAPDJL;

	private bool IIALHOMNMOP;

	private float APAKBJIGJPO = 20f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CIJOGKJFKEDE_003Ek__BackingField;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action CCNLMGEJBIB;

	public bool isRandomMatchMaking
	{
		[CompilerGenerated]
		get
		{
			return _003CIJOGKJFKEDE_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIJOGKJFKEDE_003Ek__BackingField = value;
		}
	}

	public override string loadingWaiting => Localization.Localize((!isRandomMatchMaking) ? "ID_STATE_WAITINGFOROPPONENT" : "ID_STATE_SEARCHINGFOROPPONENT");

	protected override string AMNDDFPPMGI => Localization.Localize((!isRandomMatchMaking) ? "ID_WAITINGFORFRIENDCARDS" : "ID_WAITINGFOROPPONENTCARDS");

	protected override bool JPADCGODJBO => false;

	public override string quitText => Localization.Localize((!isRandomMatchMaking) ? "ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT" : "ID_CONFIRM_EXITINGMATCH_TEXT");

	protected virtual void CKPKIKIIMGI(object[] CJLLLNBEDHO)
	{
		if (isRandomMatchMaking)
		{
			UnityEngine.Debug.LogError(string.Format("ID_ARENABOXDESCRIPTION_SCRAPS", CJLLLNBEDHO[0], CJLLLNBEDHO[0]));
			if (MatchManager.HHEAOEEBICE())
			{
				PHEKHJHJODD(Convert.ToInt32(CJLLLNBEDHO[1]));
			}
			else
			{
				GBHJCGLJAMK(GJAIOLKDDAH: false);
			}
		}
		else
		{
			base.OnPhotonJoinRoomFailed(CJLLLNBEDHO);
		}
	}

	public override void Quit()
	{
		base.Quit();
		if (TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			TutorialManagerPlayWarcards.instance.FinishTutorial();
		}
	}

	protected void FJDACAACLLI()
	{
		float fLOATVALUE = Singleton<GameVariables>.instance.matchMakingConstants.GetRow(MatchMakingConstants.rowIds.MatchmakingInRoomTime).FLOATVALUE;
		float num = Time.realtimeSinceStartup - MANDOBCIHGE;
		if (num + fLOATVALUE < APAKBJIGJPO)
		{
			APAKBJIGJPO = num + fLOATVALUE;
		}
		if (isRandomMatchMaking)
		{
			Singleton<EventTrackingManager>.instance.MDMNFIABCHN(num);
		}
		UnityEngine.Debug.Log($"Matchmaking took {num}, assigning bot in 10 secs");
	}

	protected override void EGMEJKOEAIH()
	{
		UnityEngine.Debug.Log("Loading - cancel clicked, will to try call disconnect");
		if (DKPCCABKHLE)
		{
			UnityEngine.Debug.Log("Cancel - Disconnect, clicked in dialog !!!");
			PhotonConnectionManager.Disconnect();
			StopAllCoroutines();
			Reset();
			GBHJCGLJAMK();
		}
	}

	protected virtual void DIOAOBFDPMH()
	{
		if (Time.realtimeSinceStartup > MANDOBCIHGE + APAKBJIGJPO && MANDOBCIHGE != 1214f && isRandomMatchMaking && !DEGCDEAANEL && !MOOCFIAPDJL && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			if (!PhotonNetwork.connected || PhotonNetwork.room == null)
			{
				Singleton<EventTrackingManager>.instance.MDMNFIABCHN(380f);
			}
			PhotonConnectionManager.Disconnect();
			PhotonNetwork.offlineMode = true;
			StopAllCoroutines();
			MOOCFIAPDJL = true;
			Singleton<BeanstalkServerManager>.instance.MEBMHIOJAHC();
			MatchManager.KBHGDEPHPIO(GLFPILGCAPM.WaitingForOpponent);
			NJIOHEOKIGD = APAKBJIGJPO + UnityEngine.Random.Range(1539f, 1613f);
			Singleton<GameController>.instance.opponent = null;
			FKBBEIFCHMN = APAKBJIGJPO + UnityEngine.Random.Range(1616f, (!DebugSettings.debugEnabled) ? 124f : 155f);
			UnityEngine.Debug.Log("+{0}%");
		}
		if (MOOCFIAPDJL)
		{
			if (Time.realtimeSinceStartup > MANDOBCIHGE + NJIOHEOKIGD && MANDOBCIHGE != 174f && MatchManager.LEDPCHAHPPL() == GLFPILGCAPM.ConnectingToPhoton && isRandomMatchMaking)
			{
				DEGCDEAANEL = true;
				Singleton<GameController>.instance.NOPKOCCCFIM.JILMAJGLHHK();
				int num = LevelManager.instance.currentLevel.ABCCINJGPGD();
				if (Singleton<GameController>.instance.FHABFFKPODN != null && Singleton<GameController>.instance.FHABFFKPODN.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.FHABFFKPODN.EHHHBEMKGOE.OEJKKJJFDFL());
				}
				if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BPNPPKPCFGN());
				}
				MatchManager.JKLPOGEGDNH((GLFPILGCAPM)7);
				MatchManager.IJNECELOAPA = Time.realtimeSinceStartup + (float)GameVariables.GetMatchStartTime(num);
				Singleton<GameController>.instance.opponent.LMIHBNGHEHM.ILOHAHFIOKM();
				Singleton<GameController>.instance.opponent.LMIHBNGHEHM.PPDNINOMMKK(CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton);
				if (DKPCCABKHLE)
				{
					string oKMNFHNBMFA = ((!isRandomMatchMaking) ? Localization.Localize("country-australia") : Localization.Localize("0"));
					LoadingDialog.ShowLoading(oKMNFHNBMFA);
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance, 1839f);
				}
			}
			if (Singleton<GameController>.instance.opponent != null)
			{
				PlayerController opponent = Singleton<GameController>.instance.opponent;
				if (Time.realtimeSinceStartup > MANDOBCIHGE + FKBBEIFCHMN && MANDOBCIHGE != 546f && MatchManager.matchState == GLFPILGCAPM.BothPlayersConnected && opponent.LMIHBNGHEHM.CJJLIKCIBLO() == CKDIHNEIHKL.GLFPILGCAPM.Connected)
				{
					opponent.LMIHBNGHEHM.PPDNINOMMKK(CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton);
				}
				CKDIHNEIHKL.GLFPILGCAPM gLFPILGCAPM = opponent.LMIHBNGHEHM.KNLMGECDHFL();
				if (MANDOBCIHGE != 1252f && DKPCCABKHLE && gLFPILGCAPM == (CKDIHNEIHKL.GLFPILGCAPM)8)
				{
					MANDOBCIHGE = 1285f;
					base.isInMatch = false;
					Singleton<GameController>.instance.SwitchToDeatchMatchOffline();
					Singleton<GameController>.instance.NOKJMDOPFHL();
					Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.NOPGGANHAFN().name);
				}
			}
		}
		if (Time.realtimeSinceStartup > MatchManager.IJNECELOAPA && DEGCDEAANEL && !DKPCCABKHLE && (PhotonNetwork.inRoom || MOOCFIAPDJL) && !IIALHOMNMOP)
		{
			FinishChoosingCards();
		}
		if (gameIsRunning && !TimeManager.instance.EEHBPNDBNKC)
		{
			time -= Time.deltaTime;
		}
		if (time <= 532f && gameIsRunning && !Singleton<PhotonConnectionManager>.instance.KKLAPJPNLIJ() && !GEKJOEMHHBA)
		{
			GEKJOEMHHBA = true;
			Singleton<MatchManager>.instance.StartOverTime(base.AAIEPHNDCJP, GameControllerOnline.HMAIEJHCHDE);
		}
		base.Update();
	}

	public virtual void AKGLHPAGGGI(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		isRandomMatchMaking = false;
		LoadingDialog.FEHDJPIKOJD(EDHDMJLHLFA: true);
		base.StartMultiplayerGame(JLBLNDGIINB, GJBFKKOAMPA);
	}

	[CompilerGenerated]
	private void FHKCOPNGIOE()
	{
		GBHJCGLJAMK(GJAIOLKDDAH: false);
	}

	public void BLCGPLNDMIL()
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		Screen.sleepTimeout = -1;
		PlayerController.JFGDAKMCJAM.Clear();
		BLBNJHMPGNK();
		Reset();
		isRandomMatchMaking = false;
		MANDOBCIHGE = Time.realtimeSinceStartup;
		MatchManager.KBHGDEPHPIO(GLFPILGCAPM.WaitingForOpponent);
		InvokeAfter(delegate
		{
			MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
		}, 1649f);
		GuiScreenSingle<CardSelectionScreen>.instance.FOOOELGKOMF();
		NJIOHEOKIGD = 1563f;
		FKBBEIFCHMN = 606f;
		MOOCFIAPDJL = true;
		IIALHOMNMOP = true;
	}

	private void AIIPDNJALKO(bool GJAIOLKDDAH = true)
	{
		LoadingDialog.NJHOCHGJICN(EDHDMJLHLFA: true);
		float mANDOBCIHGE = MANDOBCIHGE;
		Reset();
		PlayerController.JFGDAKMCJAM.Clear();
		MANDOBCIHGE = ((!GJAIOLKDDAH) ? mANDOBCIHGE : Time.realtimeSinceStartup);
		isRandomMatchMaking = false;
		BLBNJHMPGNK();
		Singleton<PhotonConnectionManager>.instance.OAJIIMFNJDN(PhotonConnectionManager.bestRegionsSorted[0].Value1, 1550f);
	}

	public void StartRandomMatchMaking(float EKLFHJBOLGJ = 1.5f)
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		Screen.sleepTimeout = -1;
		PlayerController.JFGDAKMCJAM.Clear();
		BLBNJHMPGNK();
		Tuple<CloudRegionCode, int> tuple = PhotonConnectionManager.bestRegionsSorted[0];
		bool flag = (float)tuple.Value2 > (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
		APAKBJIGJPO = Singleton<GameVariables>.instance.maxMatchmakingTime;
		if (flag || BotManager.useEasyBot || UserDeviceManager.instance.IsSlowDevice() || StatsManager.instance.deathMatchLossesInRow >= 3f)
		{
			Reset();
			isRandomMatchMaking = true;
			MANDOBCIHGE = Time.realtimeSinceStartup;
			MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
			InvokeAfter(delegate
			{
				MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
			}, 1f);
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			NJIOHEOKIGD = ((!BotManager.useEasyBot) ? UnityEngine.Random.Range(11f, 12f) : 2f);
			FKBBEIFCHMN = ((!BotManager.useEasyBot) ? UnityEngine.Random.Range(16f, 20f) : 4f);
			MOOCFIAPDJL = true;
			PCIJPCBAOID();
		}
		else
		{
			Reset();
			isRandomMatchMaking = true;
			MANDOBCIHGE = Time.realtimeSinceStartup;
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			Singleton<PhotonConnectionManager>.instance.ConnnectToRandomRoom(PhotonConnectionManager.bestRegionsSorted[0].Value1, EKLFHJBOLGJ);
			PCIJPCBAOID();
		}
	}

	private void GBHJCGLJAMK(bool GJAIOLKDDAH = true)
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		float mANDOBCIHGE = MANDOBCIHGE;
		Reset();
		PlayerController.JFGDAKMCJAM.Clear();
		MANDOBCIHGE = ((!GJAIOLKDDAH) ? mANDOBCIHGE : Time.realtimeSinceStartup);
		isRandomMatchMaking = true;
		BLBNJHMPGNK();
		Singleton<PhotonConnectionManager>.instance.ConnnectToRandomRoom(PhotonConnectionManager.bestRegionsSorted[0].Value1, 0f);
	}

	protected override void OnPhotonJoinRoomFailed(object[] CJLLLNBEDHO)
	{
		if (isRandomMatchMaking)
		{
			UnityEngine.Debug.LogError($"OnPhotonJoinRoomFailed: {CJLLLNBEDHO[0]}, message {CJLLLNBEDHO[1]}");
			if (MatchManager.isReconnect)
			{
				PHEKHJHJODD(Convert.ToInt32(CJLLLNBEDHO[0]));
			}
			else
			{
				GBHJCGLJAMK();
			}
		}
		else
		{
			base.OnPhotonJoinRoomFailed(CJLLLNBEDHO);
		}
	}

	public override void UnPauseGame()
	{
		if (!gameIsRunning && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && isRandomMatchMaking)
		{
			if (base.isInMatch && !DEGCDEAANEL)
			{
				GBHJCGLJAMK();
				OMDNHHFCMFN = false;
			}
		}
		else
		{
			base.UnPauseGame();
		}
	}

	protected virtual void BLKOOGCJGJG(byte MNMLNIMFMJP)
	{
		bool isReconnect = MatchManager.isReconnect;
		base.FinishGameMultiplayerRPC(MNMLNIMFMJP);
		if (isRandomMatchMaking || isReconnect)
		{
			Disconnect();
		}
	}

	protected virtual void PLOOODMNHKH()
	{
		if (isRandomMatchMaking)
		{
			Singleton<DogTagManager>.instance.PILBFGCKGFB();
		}
	}

	[CompilerGenerated]
	private void GEKCHLBONIO()
	{
		GBHJCGLJAMK();
	}

	protected override void OnConnectionFail(DisconnectCause FAODDFIDOAC)
	{
		if (isRandomMatchMaking)
		{
			UnityEngine.Debug.LogError("OnConnectionFailed: " + FAODDFIDOAC);
			UnityEngine.Debug.LogError(DebugSettings.GetNetworkStatsText());
			FLAGMPEFCDM(FAODDFIDOAC);
			if (DEGCDEAANEL && NNEPKHKGCAA(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen))
			{
				NABOEHCIIPD();
			}
			else if (DEGCDEAANEL && (OMDNHHFCMFN || Application.internetReachability == NetworkReachability.NotReachable))
			{
				if (Singleton<DogTagManager>.instance.CanUseDogtags(1))
				{
					PCIJPCBAOID();
					MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
					InvokeAfter(delegate
					{
						GBHJCGLJAMK(GJAIOLKDDAH: false);
					}, 1f);
					UnityEngine.Debug.LogError("OnConnectionFailed: restarting minus dogtag");
				}
				else
				{
					UnityEngine.Debug.LogError("OnConnectionFailed: no dogtags");
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance);
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
					Quit();
				}
			}
			else
			{
				UnityEngine.Debug.LogError("OnConnectionFailed: restarting");
				LoadingDialog.Hide();
				MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
				InvokeAfter(delegate
				{
					GBHJCGLJAMK(GJAIOLKDDAH: false);
				}, 1f);
			}
		}
		else
		{
			base.OnConnectionFail(FAODDFIDOAC);
		}
	}

	protected override void PCIJPCBAOID()
	{
		if (isRandomMatchMaking)
		{
			Singleton<DogTagManager>.instance.PayOneDogTag();
		}
	}

	protected virtual void HGCGCDPBIGP()
	{
		if (!DEGCDEAANEL)
		{
			if (!isRandomMatchMaking)
			{
				MatchManager.invitationState = (OOJDIACPBED)5;
			}
			base.HKGOKPMIEEI();
		}
	}

	public override void StartMultiplayerGame(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		isRandomMatchMaking = false;
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		base.StartMultiplayerGame(JLBLNDGIINB, GJBFKKOAMPA);
	}

	public void NCILIMJOJEC(float EKLFHJBOLGJ = 1.5f)
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		Screen.sleepTimeout = -1;
		PlayerController.JFGDAKMCJAM.Clear();
		BLBNJHMPGNK();
		Tuple<CloudRegionCode, int> tuple = PhotonConnectionManager.BKGDJLGJEHH()[0];
		bool flag = (float)tuple.Value2 > (float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalSaleMin).FLOATVALUE;
		APAKBJIGJPO = Singleton<GameVariables>.instance.maxMatchmakingTime;
		if (flag || BotManager.KOHHPPDDMPL() || UserDeviceManager.instance.IsSlowDevice() || StatsManager.instance.deathMatchLossesInRow >= 758f)
		{
			Reset();
			isRandomMatchMaking = true;
			MANDOBCIHGE = Time.realtimeSinceStartup;
			MatchManager.KBHGDEPHPIO(GLFPILGCAPM.ConnectingToPhoton);
			InvokeAfter(delegate
			{
				MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
			}, 1265f);
			GuiScreenSingle<CardSelectionScreen>.instance.FOOOELGKOMF();
			NJIOHEOKIGD = ((!BotManager.useEasyBot) ? UnityEngine.Random.Range(731f, 1361f) : 1719f);
			FKBBEIFCHMN = ((!BotManager.KOHHPPDDMPL()) ? UnityEngine.Random.Range(568f, 1615f) : 1792f);
			MOOCFIAPDJL = true;
			PCIJPCBAOID();
		}
		else
		{
			Reset();
			isRandomMatchMaking = true;
			MANDOBCIHGE = Time.realtimeSinceStartup;
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			Singleton<PhotonConnectionManager>.instance.OAJIIMFNJDN(PhotonConnectionManager.BKGDJLGJEHH()[0].Value1, EKLFHJBOLGJ);
			PCIJPCBAOID();
		}
	}

	protected virtual void AOKEHEDCPFB()
	{
		if (Time.realtimeSinceStartup > MANDOBCIHGE + APAKBJIGJPO && MANDOBCIHGE != 724f && isRandomMatchMaking && !DEGCDEAANEL && !MOOCFIAPDJL && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			if (!PhotonNetwork.connected || PhotonNetwork.room == null)
			{
				Singleton<EventTrackingManager>.instance.MDMNFIABCHN(1828f);
			}
			PhotonConnectionManager.Disconnect();
			PhotonNetwork.offlineMode = true;
			StopAllCoroutines();
			MOOCFIAPDJL = true;
			Singleton<BeanstalkServerManager>.instance.MEBMHIOJAHC();
			MatchManager.GODMIAKEFOA(GLFPILGCAPM.ConnectingToPhoton);
			NJIOHEOKIGD = APAKBJIGJPO + UnityEngine.Random.Range(1566f, 586f);
			Singleton<GameController>.instance.opponent = null;
			FKBBEIFCHMN = APAKBJIGJPO + UnityEngine.Random.Range(1247f, (!DebugSettings.debugEnabled) ? 1529f : 1409f);
			UnityEngine.Debug.Log("Play_Card_Tutorial");
		}
		if (MOOCFIAPDJL)
		{
			if (Time.realtimeSinceStartup > MANDOBCIHGE + NJIOHEOKIGD && MANDOBCIHGE != 1727f && MatchManager.matchState == GLFPILGCAPM.ConnectingToPhoton && isRandomMatchMaking)
			{
				DEGCDEAANEL = true;
				Singleton<GameController>.instance.NOPKOCCCFIM.JILMAJGLHHK();
				int num = LevelManager.instance.currentLevel.NPOEMAMPNEP();
				if (Singleton<GameController>.instance.FHABFFKPODN != null && Singleton<GameController>.instance.FHABFFKPODN.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.FHABFFKPODN.EHHHBEMKGOE.ALJJMKANFNO());
				}
				if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL);
				}
				MatchManager.JKLPOGEGDNH((GLFPILGCAPM)7);
				MatchManager.IJNECELOAPA = Time.realtimeSinceStartup + (float)GameVariables.GetMatchStartTime(num);
				Singleton<GameController>.instance.opponent.LMIHBNGHEHM.ILOHAHFIOKM();
				Singleton<GameController>.instance.opponent.LMIHBNGHEHM.PPDNINOMMKK(CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton);
				if (DKPCCABKHLE)
				{
					string oKMNFHNBMFA = ((!isRandomMatchMaking) ? Localization.Localize("[Singleton] An instance of ") : Localization.Localize("ID_GUI_BEADVISED_PURCHASEVIP"));
					LoadingDialog.PGFBMJFLHPC(oKMNFHNBMFA, DMDICGADGCG: true);
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance, 244f);
				}
			}
			if (Singleton<GameController>.instance.opponent != null)
			{
				PlayerController opponent = Singleton<GameController>.instance.opponent;
				if (Time.realtimeSinceStartup > MANDOBCIHGE + FKBBEIFCHMN && MANDOBCIHGE != 634f && MatchManager.matchState == GLFPILGCAPM.GameFinished && opponent.LMIHBNGHEHM.BGGBBINFCJO() == CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton)
				{
					opponent.LMIHBNGHEHM.JNKGDHDGBNM(CKDIHNEIHKL.GLFPILGCAPM.GameFinished);
				}
				CKDIHNEIHKL.GLFPILGCAPM gLFPILGCAPM = opponent.LMIHBNGHEHM.KNLMGECDHFL();
				if (MANDOBCIHGE != 762f && DKPCCABKHLE && gLFPILGCAPM == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
				{
					MANDOBCIHGE = 1952f;
					base.isInMatch = false;
					Singleton<GameController>.instance.SwitchToDeatchMatchOffline();
					Singleton<GameController>.instance.NOKJMDOPFHL();
					Singleton<GameController>.instance.NMHKLCLAFGN(Singleton<MapManager>.instance.NMMDOMPAAEF().name);
				}
			}
		}
		if (Time.realtimeSinceStartup > MatchManager.IJNECELOAPA && DEGCDEAANEL && !DKPCCABKHLE && (PhotonNetwork.inRoom || MOOCFIAPDJL) && !IIALHOMNMOP)
		{
			FinishChoosingCards();
		}
		if (gameIsRunning && !TimeManager.instance.EEHBPNDBNKC)
		{
			time -= Time.deltaTime;
		}
		if (time <= 485f && gameIsRunning && !Singleton<PhotonConnectionManager>.instance.KKLAPJPNLIJ() && !GEKJOEMHHBA)
		{
			GEKJOEMHHBA = true;
			Singleton<MatchManager>.instance.StartOverTime(base.AAIEPHNDCJP, GameControllerOnline.HMAIEJHCHDE);
		}
		base.Update();
	}

	private void HKABBKHOBCP()
	{
		AIIPDNJALKO(GJAIOLKDDAH: false);
	}

	protected override void HKGOKPMIEEI()
	{
		if (!DEGCDEAANEL)
		{
			if (!isRandomMatchMaking)
			{
				MatchManager.invitationState = OOJDIACPBED.Accepted;
			}
			base.HKGOKPMIEEI();
		}
	}

	[CompilerGenerated]
	private static void AGIFONLDEEE()
	{
		MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
	}

	public virtual void MIEPNFNIEOL()
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		if (isRandomMatchMaking)
		{
			NCILIMJOJEC(1851f);
		}
		else
		{
			base.Rematch();
		}
		GuiScreenSingle<CardSelectionScreen>.instance.FOOOELGKOMF();
	}

	public virtual void COENHPMMCNN()
	{
		bool flag = MatchManager.HHEAOEEBICE();
		base.FinishGame();
		if (isRandomMatchMaking && Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.None)
		{
			CardManager.AddCardForWinner();
		}
		if (isRandomMatchMaking || flag)
		{
			Disconnect();
		}
	}

	public virtual void ALBHJNCBKCN(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		isRandomMatchMaking = true;
		LoadingDialog.NJHOCHGJICN(EDHDMJLHLFA: false);
		base.StartMultiplayerGame(JLBLNDGIINB, GJBFKKOAMPA);
	}

	protected virtual void HCBNPIJGFFJ()
	{
		base.BLBNJHMPGNK();
		Singleton<GameController>.instance.opponent = null;
		OMDNHHFCMFN = false;
	}

	public void StartTutorialMatch()
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		Screen.sleepTimeout = -1;
		PlayerController.JFGDAKMCJAM.Clear();
		BLBNJHMPGNK();
		Reset();
		isRandomMatchMaking = true;
		MANDOBCIHGE = Time.realtimeSinceStartup;
		MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
		InvokeAfter(delegate
		{
			MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
		}, 0.2f);
		GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
		NJIOHEOKIGD = 0.2f;
		FKBBEIFCHMN = 1f;
		MOOCFIAPDJL = true;
		IIALHOMNMOP = true;
	}

	private void ILCNJBGPOFO()
	{
		AIIPDNJALKO();
	}

	[CompilerGenerated]
	private void KHPJCCDGPIB()
	{
		GBHJCGLJAMK(GJAIOLKDDAH: false);
	}

	private void DKMGCMDDODP()
	{
		AIIPDNJALKO();
	}

	public override void Rematch()
	{
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		if (isRandomMatchMaking)
		{
			StartRandomMatchMaking();
		}
		else
		{
			base.Rematch();
		}
		GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
	}

	public virtual void GAELBEHFHBA(DatabasePlayer NCFFGKHPJLH, out string JLBLNDGIINB, out bool MKDDIBOHCIA)
	{
		isRandomMatchMaking = false;
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		base.StartMultiplayerGame(NCFFGKHPJLH, out JLBLNDGIINB, out MKDDIBOHCIA);
	}

	protected void IFNKNFMAMCE()
	{
		DEGCDEAANEL = false;
		if (DKPCCABKHLE)
		{
			UnityEngine.Debug.LogError("NULL");
			WarningDialog.JACKIDKHKAI(Localization.Localize("DecalManagerData"), Localization.Localize("AccountType"), 995f, null, string.Empty);
			LoadingDialog.Hide();
		}
		if (MatchManager.MDHEFDEPBJB())
		{
			UnityEngine.Debug.LogError("LeagueEvaluation");
			PhotonConnectionManager.Disconnect();
			Reset();
			MANDOBCIHGE = Time.realtimeSinceStartup;
			MatchManager.KBHGDEPHPIO(GLFPILGCAPM.GameFinished);
			InvokeAfter(delegate
			{
				GBHJCGLJAMK();
			}, 677f);
		}
	}

	private void KDECDHMDNIG()
	{
		GBHJCGLJAMK();
	}

	protected void ODDEHKAJCNN()
	{
		DEGCDEAANEL = false;
		if (DKPCCABKHLE)
		{
			UnityEngine.Debug.LogError("Player disconected 0001");
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED"), Localization.Localize("ID_WARNING_OPPONENTDISCONNECTED"), 0f, null, string.Empty);
			LoadingDialog.Hide();
		}
		if (MatchManager.beforeMatch)
		{
			UnityEngine.Debug.LogError("Player disconected 0002");
			PhotonConnectionManager.Disconnect();
			Reset();
			MANDOBCIHGE = Time.realtimeSinceStartup;
			MatchManager.matchState = GLFPILGCAPM.GameCancelled;
			InvokeAfter(delegate
			{
				GBHJCGLJAMK();
			}, 0.5f);
		}
	}

	public virtual void IGGFOEOOLLM()
	{
		if (!gameIsRunning && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && isRandomMatchMaking)
		{
			if (base.isInMatch && !DEGCDEAANEL)
			{
				GBHJCGLJAMK();
				OMDNHHFCMFN = false;
			}
		}
		else
		{
			base.UnPauseGame();
		}
	}

	private void JAHBINGNDAC()
	{
		GBHJCGLJAMK();
	}

	protected override void CLLOIJABJPC(PhotonPlayer NCFFGKHPJLH)
	{
		if (isRandomMatchMaking)
		{
			ODDEHKAJCNN();
		}
		else
		{
			base.CLLOIJABJPC(NCFFGKHPJLH);
		}
	}

	protected virtual void FBAOBHBINFK()
	{
		UnityEngine.Debug.Log("Medals requirement = ");
		if (DKPCCABKHLE)
		{
			UnityEngine.Debug.Log("ID_FEATURE_RATE");
			PhotonConnectionManager.Disconnect();
			StopAllCoroutines();
			Reset();
			GBHJCGLJAMK(GJAIOLKDDAH: false);
		}
	}

	protected virtual void GCBGLKBICHO()
	{
		if (isRandomMatchMaking)
		{
			Singleton<DogTagManager>.instance.PayOneDogTag();
		}
	}

	protected override void BLBNJHMPGNK()
	{
		base.BLBNJHMPGNK();
		Singleton<GameController>.instance.opponent = null;
		OMDNHHFCMFN = false;
	}

	public virtual void MNKCNKOLPIK(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		isRandomMatchMaking = false;
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		base.StartMultiplayerGame(JLBLNDGIINB, GJBFKKOAMPA);
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte MNMLNIMFMJP)
	{
		bool isReconnect = MatchManager.isReconnect;
		base.FinishGameMultiplayerRPC(MNMLNIMFMJP);
		if (isRandomMatchMaking || isReconnect)
		{
			Disconnect();
		}
	}

	public virtual void DCBDDBKEIAJ(DatabasePlayer NCFFGKHPJLH, out string JLBLNDGIINB, out bool MKDDIBOHCIA)
	{
		isRandomMatchMaking = false;
		LoadingDialog.FEHDJPIKOJD(EDHDMJLHLFA: false);
		base.StartMultiplayerGame(NCFFGKHPJLH, out JLBLNDGIINB, out MKDDIBOHCIA);
	}

	protected override void Reset()
	{
		base.Reset();
		DKPCCABKHLE = false;
		MANDOBCIHGE = 0f;
		MOOCFIAPDJL = false;
		IIALHOMNMOP = false;
	}

	public virtual void MOGECPPAJAJ()
	{
		LoadingDialog.FEHDJPIKOJD(EDHDMJLHLFA: true);
		if (isRandomMatchMaking)
		{
			StartRandomMatchMaking(235f);
		}
		else
		{
			base.Rematch();
		}
		GuiScreenSingle<CardSelectionScreen>.instance.FOOOELGKOMF();
	}

	public override void FinishGame()
	{
		bool isReconnect = MatchManager.isReconnect;
		base.FinishGame();
		if (isRandomMatchMaking && Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.Win)
		{
			CardManager.AddCardForWinner();
		}
		if (isRandomMatchMaking || isReconnect)
		{
			Disconnect();
		}
	}

	[CompilerGenerated]
	private static void KONOBALCPFO()
	{
		MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
	}

	public virtual void KPCBJOFKEBL()
	{
		bool isReconnect = MatchManager.isReconnect;
		base.FinishGame();
		if (isRandomMatchMaking && Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.Killed)
		{
			CardManager.AddCardForWinner();
		}
		if (isRandomMatchMaking || isReconnect)
		{
			Disconnect();
		}
	}

	public override void StartMultiplayerGame(DatabasePlayer NCFFGKHPJLH, out string JLBLNDGIINB, out bool MKDDIBOHCIA)
	{
		isRandomMatchMaking = false;
		LoadingDialog.SetLook(EDHDMJLHLFA: true);
		base.StartMultiplayerGame(NCFFGKHPJLH, out JLBLNDGIINB, out MKDDIBOHCIA);
	}

	protected override void CBOFFKGBDJB()
	{
		if (isRandomMatchMaking)
		{
			Singleton<DogTagManager>.instance.UseDogTagLocaly();
		}
	}

	protected override void Update()
	{
		if (Time.realtimeSinceStartup > MANDOBCIHGE + APAKBJIGJPO && MANDOBCIHGE != 0f && isRandomMatchMaking && !DEGCDEAANEL && !MOOCFIAPDJL && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (!PhotonNetwork.connected || PhotonNetwork.room == null)
			{
				Singleton<EventTrackingManager>.instance.MDMNFIABCHN(40f);
			}
			PhotonConnectionManager.Disconnect();
			PhotonNetwork.offlineMode = true;
			StopAllCoroutines();
			MOOCFIAPDJL = true;
			Singleton<BeanstalkServerManager>.instance.MEBMHIOJAHC();
			MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
			NJIOHEOKIGD = APAKBJIGJPO + UnityEngine.Random.Range(1f, 1f);
			Singleton<GameController>.instance.opponent = null;
			FKBBEIFCHMN = APAKBJIGJPO + UnityEngine.Random.Range(1f, (!DebugSettings.debugEnabled) ? 10f : 2f);
			UnityEngine.Debug.Log("Starting match against bot");
		}
		if (MOOCFIAPDJL)
		{
			if (Time.realtimeSinceStartup > MANDOBCIHGE + NJIOHEOKIGD && MANDOBCIHGE != 0f && MatchManager.matchState == GLFPILGCAPM.WaitingForOpponent && isRandomMatchMaking)
			{
				DEGCDEAANEL = true;
				Singleton<GameController>.instance.NOPKOCCCFIM.PrepareBot();
				int num = LevelManager.instance.currentLevel.displayNumber;
				if (Singleton<GameController>.instance.FHABFFKPODN != null && Singleton<GameController>.instance.FHABFFKPODN.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.FHABFFKPODN.EHHHBEMKGOE.BCCDDJMPBLL);
				}
				if (Singleton<GameController>.instance.opponent != null && Singleton<GameController>.instance.opponent.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, Singleton<GameController>.instance.opponent.EHHHBEMKGOE.BCCDDJMPBLL);
				}
				MatchManager.matchState = GLFPILGCAPM.BothPlayersConnected;
				MatchManager.IJNECELOAPA = Time.realtimeSinceStartup + (float)GameVariables.GetMatchStartTime(num);
				Singleton<GameController>.instance.opponent.LMIHBNGHEHM.ILOHAHFIOKM();
				Singleton<GameController>.instance.opponent.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.Connected;
				if (DKPCCABKHLE)
				{
					string oKMNFHNBMFA = ((!isRandomMatchMaking) ? Localization.Localize("ID_WAITINGFORFRIENDCARDS") : Localization.Localize("ID_WAITINGFOROPPONENTCARDS"));
					LoadingDialog.ShowLoading(oKMNFHNBMFA);
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance);
				}
			}
			if (Singleton<GameController>.instance.opponent != null)
			{
				PlayerController opponent = Singleton<GameController>.instance.opponent;
				if (Time.realtimeSinceStartup > MANDOBCIHGE + FKBBEIFCHMN && MANDOBCIHGE != 0f && MatchManager.matchState == GLFPILGCAPM.BothPlayersConnected && opponent.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Connected)
				{
					opponent.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.CardsChosen;
				}
				CKDIHNEIHKL.GLFPILGCAPM gLFPILGCAPM = opponent.LMIHBNGHEHM.EHFIJJBPEEG;
				if (MANDOBCIHGE != 0f && DKPCCABKHLE && gLFPILGCAPM == CKDIHNEIHKL.GLFPILGCAPM.CardsChosen)
				{
					MANDOBCIHGE = 0f;
					base.isInMatch = false;
					Singleton<GameController>.instance.SwitchToDeatchMatchOffline();
					Singleton<GameController>.instance.TryStopLoading();
					Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
				}
			}
		}
		if (Time.realtimeSinceStartup > MatchManager.IJNECELOAPA && DEGCDEAANEL && !DKPCCABKHLE && (PhotonNetwork.inRoom || MOOCFIAPDJL) && !IIALHOMNMOP)
		{
			FinishChoosingCards();
		}
		if (gameIsRunning && !TimeManager.instance.EEHBPNDBNKC)
		{
			time -= Time.deltaTime;
		}
		if (time <= 0f && gameIsRunning && !Singleton<PhotonConnectionManager>.instance.isClient && !GEKJOEMHHBA)
		{
			GEKJOEMHHBA = true;
			Singleton<MatchManager>.instance.StartOverTime(base.AAIEPHNDCJP, GameControllerOnline.HMAIEJHCHDE);
		}
		base.Update();
	}

	protected virtual void DFBMJOJBLEH(PhotonPlayer NCFFGKHPJLH)
	{
		if (isRandomMatchMaking)
		{
			ODDEHKAJCNN();
		}
		else
		{
			base.CLLOIJABJPC(NCFFGKHPJLH);
		}
	}
}
