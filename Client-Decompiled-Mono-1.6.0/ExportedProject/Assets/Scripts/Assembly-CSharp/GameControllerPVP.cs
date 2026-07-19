using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public abstract class GameControllerPVP : GameControllerOnline
{
	private sealed class NCEKIFIDMCF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameControllerPVP BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.HAAIJJBEPPN("Omitting object: ");
				BJGCPDNMHDH.time = (float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE + 1816f;
				UnityEngine.Debug.Log("Repair" + BJGCPDNMHDH.time);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.FDHJCAGOFKN(BJGCPDNMHDH.CHEDFKIPJFF);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("Gold_In_Flow", PhotonTargets.Others, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForRealSeconds(670f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			case 3u:
				GameControllerOnline.HMAIEJHCHDE.CMBKMOHOAGD(BJGCPDNMHDH.DBJEFMGAMLF);
				GameControllerOnline.HMAIEJHCHDE.FFEDMMENHFA(BJGCPDNMHDH.DBJEFMGAMLF);
				BJGCPDNMHDH.GEKJOEMHHBA = false;
				ALJKAAMHHLB.ALPPDLMMCIH("N");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.FLLHBKEFGHB("Decline_Rental");
				BJGCPDNMHDH.time = (float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE + 1411f;
				UnityEngine.Debug.Log("SMG_run" + BJGCPDNMHDH.time);
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.FDHJCAGOFKN(BJGCPDNMHDH.CHEDFKIPJFF);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("ID_DAYS", PhotonTargets.Others, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForRealSeconds(1848f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			case 3u:
				GameControllerOnline.HMAIEJHCHDE.DIOEINBFJBG(BJGCPDNMHDH.DBJEFMGAMLF);
				GameControllerOnline.HMAIEJHCHDE.FDHJCAGOFKN(BJGCPDNMHDH.DBJEFMGAMLF);
				BJGCPDNMHDH.GEKJOEMHHBA = true;
				ALJKAAMHHLB.CIILNLBGGHM("\"");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.POPONJAMPDF("GameControllerPVP.StartGame START");
				BJGCPDNMHDH.time = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE + 1f;
				UnityEngine.Debug.Log("Set time to: " + BJGCPDNMHDH.time);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				BJGCPDNMHDH.FEHCCGEGPLH.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForRealSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GameControllerOnline.HMAIEJHCHDE.Killed -= BJGCPDNMHDH.DBJEFMGAMLF;
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.DBJEFMGAMLF;
				BJGCPDNMHDH.GEKJOEMHHBA = false;
				ALJKAAMHHLB.POPONJAMPDF("GameControllerPVP.StartGame DONE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DLAEBOBJKBL("-ABILITY");
				BJGCPDNMHDH.time = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE + 1484f;
				UnityEngine.Debug.Log("ID_CONFIRM_ERROR" + BJGCPDNMHDH.time);
				BJGCPDNMHDH.AAIEPHNDCJP.CMBKMOHOAGD(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("GUI/", PhotonTargets.All, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForRealSeconds(1382f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			}
			case 3u:
				GameControllerOnline.HMAIEJHCHDE.CMBKMOHOAGD(BJGCPDNMHDH.DBJEFMGAMLF);
				GameControllerOnline.HMAIEJHCHDE.FFEDMMENHFA(BJGCPDNMHDH.DBJEFMGAMLF);
				BJGCPDNMHDH.GEKJOEMHHBA = false;
				ALJKAAMHHLB.BCPKGMMMOPH("ID_ANDROIDRESTOREPURCHASES");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public NCEKIFIDMCF()
		{
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.CCDJDGFFCHC("SendUnitRPC");
				BJGCPDNMHDH.time = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio).FLOATVALUE + 646f;
				UnityEngine.Debug.Log("#DANIEL# No Achievements found." + BJGCPDNMHDH.time);
				BJGCPDNMHDH.AAIEPHNDCJP.CMBKMOHOAGD(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.JGDIFKHNHGE());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("Sessions", PhotonTargets.All, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForRealSeconds(62f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			}
			case 3u:
				GameControllerOnline.HMAIEJHCHDE.DIOEINBFJBG(BJGCPDNMHDH.DBJEFMGAMLF);
				GameControllerOnline.HMAIEJHCHDE.FFEDMMENHFA(BJGCPDNMHDH.DBJEFMGAMLF);
				BJGCPDNMHDH.GEKJOEMHHBA = false;
				ALJKAAMHHLB.PIEBOOFPHPC("Hearts");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	protected bool GEKJOEMHHBA;

	protected bool OMDNHHFCMFN;

	private bool MLAJIPACEDO
	{
		get
		{
			return this == Singleton<GameController>.instance.mainController;
		}
	}

	protected virtual string AMNDDFPPMGI
	{
		get
		{
			return Localization.Localize("ID_WAITINGFOROPPONENTCARDS");
		}
	}

	protected override void BEGOFBBPOLA()
	{
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Singleton<BeanstalkServerManager>.instance.GameStartedMaster();
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.GameStartedClient();
		}
		base.BEGOFBBPOLA();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DialogCompareUnits>.instance);
	}

	[DebuggerHidden]
	public override IEnumerator StartGame()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	private void DBJEFMGAMLF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GameControllerOnline.HMAIEJHCHDE.Killed -= DBJEFMGAMLF;
		if (MLAJIPACEDO)
		{
			Singleton<GameCamera>.instance.FocusPlayer((PlayerController)MAIPDGCABNL, OHJPPHFEAFI.HNFNINFCBEJ is PlayerController);
			Singleton<MatchManager>.instance.SetHitBy(OHJPPHFEAFI);
			base.mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
			FinishGame();
		}
	}

	private void CHEDFKIPJFF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		base.AAIEPHNDCJP.Killed -= CHEDFKIPJFF;
		if (MLAJIPACEDO)
		{
			Singleton<MatchManager>.instance.SetHitBy(OHJPPHFEAFI);
			base.mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Killed;
			FinishGame();
		}
	}

	protected override GHPGNELIDBM GPONIACGBDN(PhotonPlayer KHLGDCHJJPB)
	{
		GHPGNELIDBM gHPGNELIDBM = ((!KHLGDCHJJPB.IsMasterClient) ? GHPGNELIDBM.Enemies : GHPGNELIDBM.Allies);
		UnityEngine.Debug.Log(string.Format("Getting fraction for {0} with result {1}", KHLGDCHJJPB, gHPGNELIDBM));
		return gHPGNELIDBM;
	}

	public override void FinishChoosingCards()
	{
		LoadingDialog.SetLook(true);
		base.FinishChoosingCards();
	}

	protected override void HKGOKPMIEEI()
	{
		if (!DEGCDEAANEL)
		{
			base.HKGOKPMIEEI();
			MatchManager.matchState = GLFPILGCAPM.BothPlayersConnected;
			if (DKPCCABKHLE)
			{
				FEHCCGEGPLH.RPC("FinishChoosingCardsRPC", PhotonTargets.AllBufferedViaServer, JsonConvert.SerializeObject(GetUnitsUpgrades()), PhotonNetwork.player.ID);
				LoadingDialog.ShowLoading(AMNDDFPPMGI);
			}
		}
		else
		{
			UnityEngine.Debug.LogError("All players already connected");
		}
	}

	public override void GetTimeProgressText(StringBuilder HOLNKOFHDNK)
	{
		HOLNKOFHDNK.Append((!DebugSettings.debugEnabled) ? string.Empty : ((!PhotonNetwork.isMasterClient) ? "CLIENT" : "MASTER"));
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			HOLNKOFHDNK.Append(Localization.Localize("ID_OVERTIME"));
		}
		else if (Singleton<GameController>.instance.time > 0f)
		{
			MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, Singleton<GameController>.instance.time);
		}
	}

	public override void PauseGame(bool IEFGEFFDHOK)
	{
		if (!gameIsRunning && IEFGEFFDHOK && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			if (base.isInMatch)
			{
				if (!DEGCDEAANEL)
				{
					PhotonConnectionManager.Disconnect();
					Reset();
				}
				OMDNHHFCMFN = true;
			}
		}
		else
		{
			base.PauseGame(IEFGEFFDHOK);
		}
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private IEnumerator IABAJLPCCEL()
	{
		return base.StartGame();
	}
}
