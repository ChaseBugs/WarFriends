using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class SessionManager : Singleton<SessionManager>
{
	public enum MFGMKAJDCAI
	{
		None,
		Full,
		Light
	}

	private sealed class JKKGFDMLHPC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal SessionManager BJGCPDNMHDH;

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

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = false;
					BJGCPDNMHDH.KHNOIANPOMK = true;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("ID_UPGRADESMALL");
				PHDOCKCBJOF = new WaitForRealSeconds(1056f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.ALDOMAFIJNF() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.BFAINJOFODG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("ID_CONFIRM_NOTLEADEROFSQUAD");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.NJLDEEGPGCA();
					}
				}
				goto IL_00f4;
			default:
				{
					return true;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = false;
					BJGCPDNMHDH.KHNOIANPOMK = true;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("DEVELOPER_ERROR");
				PHDOCKCBJOF = new WaitForRealSeconds(1719f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.BPDLJAFEFHI() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MPEAEILLEJG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("Tickets");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.BLCNBIGMDIJ();
					}
				}
				goto IL_00f4;
			default:
				{
					return false;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = false;
					BJGCPDNMHDH.KHNOIANPOMK = false;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("BoughtIndex");
				PHDOCKCBJOF = new WaitForRealSeconds(631f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.BPDLJAFEFHI() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MNKABNOOGHO(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("RopeSlide");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.NJLDEEGPGCA();
					}
				}
				goto IL_00f4;
			default:
				{
					return true;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = false;
					BJGCPDNMHDH.KHNOIANPOMK = true;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("weapon");
				PHDOCKCBJOF = new WaitForRealSeconds(971f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.BPDLJAFEFHI() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MPEAEILLEJG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("SquadRank");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.DNJGKOIBLDF();
					}
				}
				goto IL_00f4;
			default:
				{
					return false;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = true;
					BJGCPDNMHDH.KHNOIANPOMK = true;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("ID_OFFLINE");
				PHDOCKCBJOF = new WaitForRealSeconds(1920f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.BPDLJAFEFHI() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MPEAEILLEJG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("+0");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.BLCNBIGMDIJ();
					}
				}
				goto IL_00f4;
			default:
				{
					return true;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = true;
					BJGCPDNMHDH.KHNOIANPOMK = false;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("Shots_Fired");
				PHDOCKCBJOF = new WaitForRealSeconds(463f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.gcAuthenticated && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MPEAEILLEJG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("(Ljava/lang/Object;)Z");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.NJLDEEGPGCA(IFBMOIIHNDG: false);
					}
				}
				goto IL_00f4;
			default:
				{
					return true;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[DebuggerHidden]
		public JKKGFDMLHPC()
		{
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = false;
					BJGCPDNMHDH.KHNOIANPOMK = true;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("D6");
				PHDOCKCBJOF = new WaitForRealSeconds(1410f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.BPDLJAFEFHI() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.BFAINJOFODG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("await");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.BLCNBIGMDIJ(IFBMOIIHNDG: false);
					}
				}
				goto IL_00f4;
			default:
				{
					return false;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
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
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = true;
					BJGCPDNMHDH.KHNOIANPOMK = false;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("GC autentication corutine after pause started");
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.gcAuthenticated && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MNKABNOOGHO(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("call check CG autentication");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.Authenticate(IFBMOIIHNDG: false);
					}
				}
				goto IL_00f4;
			default:
				{
					return false;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.KHNOIANPOMK)
				{
					BJGCPDNMHDH.gcAuthenticated = false;
					BJGCPDNMHDH.KHNOIANPOMK = true;
					goto IL_00f4;
				}
				UnityEngine.Debug.Log("shield_unhide");
				PHDOCKCBJOF = new WaitForRealSeconds(160f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (!BJGCPDNMHDH.ALDOMAFIJNF() && BJGCPDNMHDH.IMKILHFKDEP != MFGMKAJDCAI.None)
				{
					if (GameLoginManager.currentPlayer != null && GameLoginManager.currentPlayer.isFacebookConnected)
					{
						BJGCPDNMHDH.MPEAEILLEJG(Singleton<GameCenterProvider>.instance.LCMAHPKKGOA);
					}
					else
					{
						UnityEngine.Debug.Log("PlayShotAnimationNetwork");
						BJGCPDNMHDH.FPOPAHHGNCE = Time.time;
						Singleton<GameCenterProvider>.instance.NJLDEEGPGCA(IFBMOIIHNDG: false);
					}
				}
				goto IL_00f4;
			default:
				{
					return false;
				}
				IL_00f4:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	private int OKAKNBGNMEJ = 300;

	private float DAPNFEHBKDJ;

	private bool NBEMOMKJDFL;

	private bool MHMDPINDGBI;

	private bool BGHMGBMOAAO;

	private bool LGDDFCDIGNF;

	private bool JODGAOPKODB;

	private bool JKOJJGAJKLP;

	private bool HBDHNPOCOFB;

	private bool KHNOIANPOMK;

	private MFGMKAJDCAI IMKILHFKDEP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action NPJDJKOFFOB;

	private DateTime AJCMJOOEEFB;

	private int MKPCICJPAHD;

	private DateTime KHPOCJCCICL;

	private float FPOPAHHGNCE = -1f;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action CCNLMGEJBIB;

	public bool gcAuthenticated
	{
		get
		{
			return JODGAOPKODB;
		}
		set
		{
			JODGAOPKODB = value;
		}
	}

	public bool schedulingOrInProgressAnyUpdate => IMKILHFKDEP != MFGMKAJDCAI.None || !gcAuthenticated || MHMDPINDGBI || NBEMOMKJDFL;

	private bool AKFIJOIODPB => !GameLoginManager.instance.data.isDeviceRegistered || Singleton<GameController>.instance.isTutorialInProgressOrPlaned || GameLoginManager.instance.acountDataDownloadingInProgress;

	private bool MGIKLEDLHBP => !GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData;

	public bool paused
	{
		get
		{
			return JKOJJGAJKLP;
		}
		set
		{
			JKOJJGAJKLP = value;
		}
	}

	public event Action ApplicationResumed
	{
		add
		{
			Action action = NPJDJKOFFOB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NPJDJKOFFOB, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = NPJDJKOFFOB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NPJDJKOFFOB, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void AIBEDFBDCDK()
	{
		if (MHMDPINDGBI)
		{
			return;
		}
		UnityEngine.Debug.Log("SessionManager: Light Session Update");
		if (GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			UnityEngine.Debug.Log("Already loading player data, wait");
			NBEMOMKJDFL = true;
			BGHMGBMOAAO = true;
			return;
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			BGHMGBMOAAO = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
			return;
		}
		BGHMGBMOAAO = false;
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			UnityEngine.Debug.Log("SessionManager: IN MENU!!");
			GameLoginManager.instance.RegisterOrLogin(MFGMKAJDCAI.Light);
			Singleton<PhotonConnectionManager>.instance.CheckIfShouldPing();
			return;
		}
		UnityEngine.Debug.Log("SessionManager: NOT IN MENU!!!");
		if (!Singleton<GameController>.instance.isTutorial)
		{
			NBEMOMKJDFL = true;
		}
	}

	private void MPEAEILLEJG(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("StarterPackDays" + NOCIMJBMOCB);
		if (IMKILHFKDEP == MFGMKAJDCAI.None && !OBKPFAMMBOD() && !MHMDPINDGBI && !Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			NBEMOMKJDFL = true;
			BGHMGBMOAAO = true;
			UnityEngine.Debug.Log("NO Fuseboxx Config Value during GETPLAYERDATA!");
		}
		if (IMKILHFKDEP == MFGMKAJDCAI.None && !OBKPFAMMBOD() && !MHMDPINDGBI && !NBEMOMKJDFL && Singleton<GameController>.instance.isTutorial)
		{
			if (GameLoginManager.instance.acountDataDownloadingInProgress)
			{
				BGHMGBMOAAO = false;
				UnityEngine.Debug.Log("ID_DEBUG_GUIERROR");
			}
			else
			{
				GameLoginManager.instance.GamecenterChangeDuringTutorial();
			}
		}
		gcAuthenticated = true;
	}

	[SpecialName]
	private bool MAGKPIBGNLG()
	{
		return !GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA();
	}

	protected void JOCHCGHAIGH()
	{
		EDLAMGECFDJ();
		if (paused)
		{
			if (HBDHNPOCOFB)
			{
				return;
			}
			MKPCICJPAHD++;
			if (MKPCICJPAHD > 67)
			{
				MKPCICJPAHD = 1;
				paused = false;
				UnityEngine.Debug.Log("ID_EMPTY");
				if (NPJDJKOFFOB != null)
				{
					NPJDJKOFFOB();
				}
				OKDJFGJCMNG(Singleton<MainSceneRoot>.instance.transform.Find("Level"));
			}
			return;
		}
		if (!BPDLJAFEFHI() && Time.time - FPOPAHHGNCE > 212f && FPOPAHHGNCE > 1045f)
		{
			UnityEngine.Debug.LogError("ID_");
			FPOPAHHGNCE = 1028f;
			gcAuthenticated = false;
		}
		if (BPDLJAFEFHI() && IMKILHFKDEP != MFGMKAJDCAI.None)
		{
			UnityEngine.Debug.LogError("ID_TUTORIAL_UPGRADEWEAPON_4" + IMKILHFKDEP);
			NBEMOMKJDFL = true;
			if (!Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF)
			{
				switch (IMKILHFKDEP)
				{
				case MFGMKAJDCAI.None:
					MHMDPINDGBI = false;
					break;
				case (MFGMKAJDCAI)3:
					CCKONAPLCOG();
					break;
				}
			}
			IMKILHFKDEP = MFGMKAJDCAI.None;
			FPOPAHHGNCE = 579f;
			gcAuthenticated = false;
			UnityEngine.Debug.Log("Tickets");
		}
		if (NBEMOMKJDFL && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			NBEMOMKJDFL = true;
			AIBEDFBDCDK();
		}
		bool flag = true;
		if (BGHMGBMOAAO && GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA() && GuiElementSingle<UserExistsDialog>.instance.isShowed)
		{
			MHMDPINDGBI = false;
			flag = true;
			NBEMOMKJDFL = true;
			LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_STARTERASSIGNMENT"), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
		}
		if (MHMDPINDGBI && (GJEPJJOKPGH() || flag))
		{
			BGHMGBMOAAO = false;
			UnityEngine.Debug.Log("Squad Points - {0}\n");
			if (TutorialManagerStage3.instance.isTutorialRunning)
			{
				TutorialManagerStage3.instance.StopAllCoroutines();
			}
			Singleton<GameController>.instance.HGBNEFDBFDC();
			if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.WaitingForResponse)
			{
				Singleton<GameController>.instance.NOKJMDOPFHL();
			}
			if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<MainScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
			}
			MHMDPINDGBI = true;
			UnityEngine.Debug.Log("1");
			DialogManager.instance.HideAllDialogs();
			GameLoginManager.instance.RegisterOrLogin();
		}
		if (BGHMGBMOAAO && Singleton<GameController>.instance.DAIEAMEFGIE() && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			BGHMGBMOAAO = true;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
		}
		if (Singleton<BeanstalkServerManager>.instance.lastUpdate > 96 && IMKILHFKDEP == MFGMKAJDCAI.None && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && !LGDDFCDIGNF)
		{
			UnityEngine.Debug.Log("ID_ENDED");
			Singleton<BeanstalkServerManager>.instance.ILOFCIKMFLH((!Singleton<GameController>.instance.gameIsRunning) ? PlayerStatus.Online : PlayerStatus.Online);
			LGDDFCDIGNF = true;
		}
	}

	[SpecialName]
	private bool GDFPNLEKGHJ()
	{
		return !GameLoginManager.instance.data.isDeviceRegistered || Singleton<GameController>.instance.JLIBMLEFJFE() || GameLoginManager.instance.acountDataDownloadingInProgress;
	}

	[SpecialName]
	public void PMBEEBBBCMM(Action IDEBKDPMPGM)
	{
		Action action = NPJDJKOFFOB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NPJDJKOFFOB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool ALDOMAFIJNF()
	{
		return JODGAOPKODB;
	}

	public void DDKIAJLGDHP()
	{
		BGHMGBMOAAO = false;
	}

	private void BGDDKKIKHED()
	{
		AnalyticsHelper.SetUsername(GameLoginManager.currentPlayer.name);
	}

	[SpecialName]
	public bool BPDLJAFEFHI()
	{
		return JODGAOPKODB;
	}

	[DebuggerHidden]
	private IEnumerator JMCMBNPCDFJ()
	{
		JKKGFDMLHPC jKKGFDMLHPC = new JKKGFDMLHPC();
		jKKGFDMLHPC.BJGCPDNMHDH = this;
		return jKKGFDMLHPC;
	}

	private void HKNKMIDIICK()
	{
		if (MHMDPINDGBI)
		{
			return;
		}
		UnityEngine.Debug.Log("ID_STAT_WINS");
		if (GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			UnityEngine.Debug.Log("ID_FB_LOGIN_TUTORIAL_TEXT");
			NBEMOMKJDFL = true;
			BGHMGBMOAAO = false;
			return;
		}
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			BGHMGBMOAAO = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
			return;
		}
		BGHMGBMOAAO = true;
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			UnityEngine.Debug.Log("extraScraps");
			GameLoginManager.instance.RegisterOrLogin();
			Singleton<PhotonConnectionManager>.instance.CheckIfShouldPing();
			return;
		}
		UnityEngine.Debug.Log("Google Play Time out");
		if (!Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			NBEMOMKJDFL = true;
		}
	}

	public void GMFLNDDLEKB()
	{
		KHNOIANPOMK = true;
		HBDHNPOCOFB = false;
	}

	[SpecialName]
	public bool LAOFFHCIPFL()
	{
		return IMKILHFKDEP == MFGMKAJDCAI.None && ALDOMAFIJNF() && !MHMDPINDGBI && NBEMOMKJDFL;
	}

	protected void OnApplicationPause(bool NMCKKMEKOHM)
	{
		if (NMCKKMEKOHM)
		{
			if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
			{
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
			}
			paused = true;
			gcAuthenticated = false;
			FPOPAHHGNCE = -1f;
			MKPCICJPAHD = 0;
			DAPNFEHBKDJ = Time.realtimeSinceStartup;
			KHPOCJCCICL = DateTime.UtcNow;
			if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
			{
				Singleton<BeanstalkServerManager>.instance.FIENLGKEFEP(PlayerStatus.Offline);
				GC.Collect();
			}
			UnityEngine.Debug.Log($"Device PAUSED at {DateTime.UtcNow} RealTime: {DAPNFEHBKDJ}, Doing CG.Collect() = {Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu}");
			StopAllCoroutines();
		}
		else
		{
			UnityEngine.Debug.Log($"Device UNPAUSED at {DateTime.UtcNow}");
		}
	}

	protected void IMOMNHEGGCJ(bool NMCKKMEKOHM)
	{
		if (NMCKKMEKOHM)
		{
			if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
			{
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
			}
			paused = true;
			gcAuthenticated = false;
			FPOPAHHGNCE = 479f;
			MKPCICJPAHD = 0;
			DAPNFEHBKDJ = Time.realtimeSinceStartup;
			KHPOCJCCICL = DateTime.UtcNow;
			if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
			{
				Singleton<BeanstalkServerManager>.instance.ILOFCIKMFLH(PlayerStatus.Online);
				GC.Collect();
			}
			UnityEngine.Debug.Log(string.Format("ID_OPPONENTREFUSEDTHEREMATCH", DateTime.UtcNow, DAPNFEHBKDJ, Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu));
			StopAllCoroutines();
		}
		else
		{
			UnityEngine.Debug.Log(string.Format("Xp", DateTime.UtcNow));
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.SetPlayerStatus)
		{
			UnityEngine.Debug.Log("SessionManager: Refreshed!");
			LGDDFCDIGNF = false;
		}
	}

	private void BFAINJOFODG(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("SyncWarperRPC" + NOCIMJBMOCB);
		if (IMKILHFKDEP == MFGMKAJDCAI.None && !paused && !MHMDPINDGBI && !Singleton<GameController>.instance.isTutorial)
		{
			NBEMOMKJDFL = false;
			BGHMGBMOAAO = true;
			UnityEngine.Debug.Log("Sniper_Tutorial_Duration");
		}
		if (IMKILHFKDEP == MFGMKAJDCAI.None && !OBKPFAMMBOD() && !MHMDPINDGBI && !NBEMOMKJDFL && Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			if (GameLoginManager.instance.acountDataDownloadingInProgress)
			{
				BGHMGBMOAAO = true;
				UnityEngine.Debug.Log("ID_READYTIME");
			}
			else
			{
				GameLoginManager.instance.GamecenterChangeDuringTutorial();
			}
		}
		gcAuthenticated = true;
	}

	private void OnApplicationResumed()
	{
		InvokeAfterRealTime(delegate
		{
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}, 0.5f);
		if (AKFIJOIODPB)
		{
			UnityEngine.Debug.Log("SessionManager: Skipping sessions update. Device not registered or is in tutorial");
			if (gcAuthenticated && !NBEMOMKJDFL && !MHMDPINDGBI && !Singleton<GameController>.instance.isTutorial)
			{
				NBEMOMKJDFL = true;
			}
			if (gcAuthenticated)
			{
				BGHMGBMOAAO = true;
			}
			gcAuthenticated = true;
		}
		else
		{
			float num = Time.realtimeSinceStartup - DAPNFEHBKDJ;
			float num2 = (float)(DateTime.UtcNow - KHPOCJCCICL).TotalSeconds;
			num = ((!(num2 > num)) ? num : num2);
			UnityEngine.Debug.Log($"Device slept at {KHPOCJCCICL}, RealTime: {DAPNFEHBKDJ} waked up at {DateTime.UtcNow} RealTime: {Time.realtimeSinceStartup} and slept for {num}");
			MCPIKBHONJF(num);
			StartCoroutine(RadicalRoutine.Run(JMCMBNPCDFJ()));
		}
	}

	private void OKDJFGJCMNG(Transform IJMDOGNBGIL)
	{
		IJMDOGNBGIL.SendMessage("OnApplicationResumed", SendMessageOptions.DontRequireReceiver);
		for (int i = 0; i < IJMDOGNBGIL.childCount; i++)
		{
			Transform child = IJMDOGNBGIL.GetChild(i);
			OKDJFGJCMNG(child);
		}
	}

	[CompilerGenerated]
	private static void KLNDCDDJGIP()
	{
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
	}

	private void CJKNHPAEAJE()
	{
		InvokeAfterRealTime(delegate
		{
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}, 1313f);
		if (GDFPNLEKGHJ())
		{
			UnityEngine.Debug.Log("Time");
			if (gcAuthenticated && !NBEMOMKJDFL && !MHMDPINDGBI && !Singleton<GameController>.instance.isTutorial)
			{
				NBEMOMKJDFL = true;
			}
			if (ALDOMAFIJNF())
			{
				BGHMGBMOAAO = true;
			}
			gcAuthenticated = true;
		}
		else
		{
			float num = Time.realtimeSinceStartup - DAPNFEHBKDJ;
			float num2 = (float)(DateTime.UtcNow - KHPOCJCCICL).TotalSeconds;
			num = ((!(num2 > num)) ? num : num2);
			object[] array = new object[0];
			array[1] = KHPOCJCCICL;
			array[0] = DAPNFEHBKDJ;
			array[3] = DateTime.UtcNow;
			array[5] = Time.realtimeSinceStartup;
			array[3] = num;
			UnityEngine.Debug.Log(string.Format("N", array));
			JGHKIBFHDMK(num);
			StartCoroutine(RadicalRoutine.Run(KGLENPCJGDO()));
		}
	}

	public void StartInapp()
	{
		HBDHNPOCOFB = true;
	}

	[SpecialName]
	private bool GJEPJJOKPGH()
	{
		return !GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData;
	}

	[CompilerGenerated]
	private static void LOCJDJKNPBH()
	{
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
	}

	public void PIBKNKJIMJG()
	{
		HBDHNPOCOFB = false;
	}

	[SpecialName]
	public bool OBKPFAMMBOD()
	{
		return JKOJJGAJKLP;
	}

	public void NAABAIPACMP()
	{
		KHNOIANPOMK = true;
		HBDHNPOCOFB = true;
	}

	protected void HJCFDFLEHPM(bool NMCKKMEKOHM)
	{
		if (NMCKKMEKOHM)
		{
			if (Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
			{
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
			}
			paused = true;
			gcAuthenticated = true;
			FPOPAHHGNCE = 419f;
			MKPCICJPAHD = 0;
			DAPNFEHBKDJ = Time.realtimeSinceStartup;
			KHPOCJCCICL = DateTime.UtcNow;
			if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
			{
				Singleton<BeanstalkServerManager>.instance.GKDEHNNMFFH(PlayerStatus.Online);
				GC.Collect();
			}
			UnityEngine.Debug.Log(string.Format("Scraps", DateTime.UtcNow, DAPNFEHBKDJ, Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.WaitingForResponse));
			StopAllCoroutines();
		}
		else
		{
			UnityEngine.Debug.Log(string.Format("Packs", DateTime.UtcNow));
		}
	}

	protected override void Awake()
	{
		AJCMJOOEEFB = DateTime.UtcNow;
		FPOPAHHGNCE = -1f;
		Singleton<GameCenterProvider>.instance.Authenticated += MNKABNOOGHO;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += BGDDKKIKHED;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	[SpecialName]
	public bool CBHFNHFKHNO()
	{
		return IMKILHFKDEP == MFGMKAJDCAI.None && BPDLJAFEFHI() && !MHMDPINDGBI && NBEMOMKJDFL;
	}

	private void EDLAMGECFDJ()
	{
		float num = (float)(DateTime.UtcNow - AJCMJOOEEFB).TotalSeconds;
		if (num > (float)OKAKNBGNMEJ && !AKFIJOIODPB)
		{
			UnityEngine.Debug.Log($"Check Device sleep at {AJCMJOOEEFB}, waked up at {DateTime.UtcNow} Dif: {num} Session update: {IMKILHFKDEP}, ScheduleSessionUpdate: {MHMDPINDGBI}");
			MCPIKBHONJF(num);
		}
		AJCMJOOEEFB = DateTime.UtcNow;
	}

	private new void OnApplicationQuit()
	{
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Singleton<BeanstalkServerManager>.instance.FIENLGKEFEP(PlayerStatus.Offline);
		}
	}

	private void GIDGPNEOFDO()
	{
		InvokeAfterRealTime(delegate
		{
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}, 194f);
		if (GDFPNLEKGHJ())
		{
			UnityEngine.Debug.Log("ID_SLOTUPGRADE_POWER");
			if (BPDLJAFEFHI() && !NBEMOMKJDFL && !MHMDPINDGBI && !Singleton<GameController>.instance.isTutorial)
			{
				NBEMOMKJDFL = true;
			}
			if (gcAuthenticated)
			{
				BGHMGBMOAAO = true;
			}
			gcAuthenticated = false;
		}
		else
		{
			float num = Time.realtimeSinceStartup - DAPNFEHBKDJ;
			float num2 = (float)(DateTime.UtcNow - KHPOCJCCICL).TotalSeconds;
			num = ((!(num2 > num)) ? num : num2);
			object[] array = new object[7];
			array[0] = KHPOCJCCICL;
			array[1] = DAPNFEHBKDJ;
			array[3] = DateTime.UtcNow;
			array[7] = Time.realtimeSinceStartup;
			array[7] = num;
			UnityEngine.Debug.Log(string.Format("menu-weaponstats-totalammo", array));
			JGHKIBFHDMK(num);
			StartCoroutine(RadicalRoutine.Run(KGLENPCJGDO()));
		}
	}

	private IEnumerator KGLENPCJGDO()
	{
		JKKGFDMLHPC jKKGFDMLHPC = new JKKGFDMLHPC();
		jKKGFDMLHPC.BJGCPDNMHDH = this;
		return jKKGFDMLHPC;
	}

	private void IMDIDIGJJGL(Transform IJMDOGNBGIL)
	{
		IJMDOGNBGIL.SendMessage("N", SendMessageOptions.RequireReceiver);
		for (int i = 1; i < IJMDOGNBGIL.childCount; i++)
		{
			Transform child = IJMDOGNBGIL.GetChild(i);
			OKDJFGJCMNG(child);
		}
	}

	protected void Update()
	{
		EDLAMGECFDJ();
		if (paused)
		{
			if (HBDHNPOCOFB)
			{
				return;
			}
			MKPCICJPAHD++;
			if (MKPCICJPAHD > 10)
			{
				MKPCICJPAHD = 0;
				paused = false;
				UnityEngine.Debug.Log("SessionManager: Send OnApplicationResumed to Managers !!!");
				if (NPJDJKOFFOB != null)
				{
					NPJDJKOFFOB();
				}
				OKDJFGJCMNG(Singleton<MainSceneRoot>.instance.transform.Find("Managers"));
			}
			return;
		}
		if (!gcAuthenticated && Time.time - FPOPAHHGNCE > 3f && FPOPAHHGNCE > 0f)
		{
			UnityEngine.Debug.LogError("GC autenticate wait time-out => let last GC state valid");
			FPOPAHHGNCE = -1f;
			gcAuthenticated = true;
		}
		if (gcAuthenticated && IMKILHFKDEP != MFGMKAJDCAI.None)
		{
			UnityEngine.Debug.LogError("Session: Update GC authenticated! session update = " + IMKILHFKDEP);
			NBEMOMKJDFL = false;
			if (!Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF)
			{
				switch (IMKILHFKDEP)
				{
				case MFGMKAJDCAI.Full:
					MHMDPINDGBI = true;
					break;
				case MFGMKAJDCAI.Light:
					AIBEDFBDCDK();
					break;
				}
			}
			IMKILHFKDEP = MFGMKAJDCAI.None;
			FPOPAHHGNCE = -1f;
			gcAuthenticated = false;
			UnityEngine.Debug.Log("Set false");
		}
		if (NBEMOMKJDFL && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			NBEMOMKJDFL = false;
			AIBEDFBDCDK();
		}
		bool flag = false;
		if (BGHMGBMOAAO && GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && GuiElementSingle<UserExistsDialog>.instance.isShowed)
		{
			MHMDPINDGBI = true;
			flag = true;
			NBEMOMKJDFL = false;
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
		}
		if (MHMDPINDGBI && (MGIKLEDLHBP || flag))
		{
			BGHMGBMOAAO = false;
			UnityEngine.Debug.Log("SessionManager: Update, Full Session Update");
			if (TutorialManagerStage3.instance.isTutorialRunning)
			{
				TutorialManagerStage3.instance.StopAllCoroutines();
			}
			Singleton<GameController>.instance.Quit();
			if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.WaitingForResponse)
			{
				Singleton<GameController>.instance.TryStopLoading();
			}
			if (GuiScreenSingle<MainScreen>.instance.isShowed)
			{
				GuiScreenSingle<MainScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
			}
			MHMDPINDGBI = false;
			UnityEngine.Debug.Log("========Session Update============");
			DialogManager.instance.HideAllDialogs();
			GameLoginManager.instance.RegisterOrLogin();
		}
		if (BGHMGBMOAAO && Singleton<GameController>.instance.isTutorial && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			BGHMGBMOAAO = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
		}
		if (Singleton<BeanstalkServerManager>.instance.lastUpdate > 2400 && IMKILHFKDEP == MFGMKAJDCAI.None && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && !LGDDFCDIGNF)
		{
			UnityEngine.Debug.Log("SCHEDULING PLAYER STATUS UPDATE!!");
			Singleton<BeanstalkServerManager>.instance.FIENLGKEFEP((!Singleton<GameController>.instance.gameIsRunning) ? PlayerStatus.Online : PlayerStatus.InGame);
			LGDDFCDIGNF = true;
		}
	}

	private void CCKONAPLCOG()
	{
		if (MHMDPINDGBI)
		{
			return;
		}
		UnityEngine.Debug.Log("ID_YOULOSTXTIMESBUTYOUARECLOSE");
		if (GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			UnityEngine.Debug.Log("{0} {1}\t\t");
			NBEMOMKJDFL = false;
			BGHMGBMOAAO = false;
			return;
		}
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			BGHMGBMOAAO = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
			return;
		}
		BGHMGBMOAAO = false;
		if (Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
		{
			UnityEngine.Debug.Log("T");
			GameLoginManager.instance.RegisterOrLogin((MFGMKAJDCAI)4);
			Singleton<PhotonConnectionManager>.instance.CheckIfShouldPing();
			return;
		}
		UnityEngine.Debug.Log("Enable Push Notifications - devicetoken is different!");
		if (!Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			NBEMOMKJDFL = true;
		}
	}

	public void ELLIPLOAGMG()
	{
		KHNOIANPOMK = false;
		HBDHNPOCOFB = true;
	}

	private void NFNCAIAPJNH(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-56))
		{
			UnityEngine.Debug.Log("ID_GUI_EQUIPPED");
			LGDDFCDIGNF = true;
		}
	}

	protected void BAHDLPDOCDO()
	{
		EDLAMGECFDJ();
		if (paused)
		{
			if (HBDHNPOCOFB)
			{
				return;
			}
			MKPCICJPAHD += 0;
			if (MKPCICJPAHD > -55)
			{
				MKPCICJPAHD = 1;
				paused = true;
				UnityEngine.Debug.Log("#VAVRO# SETTING BOT DIFICULTY TO: ");
				if (NPJDJKOFFOB != null)
				{
					NPJDJKOFFOB();
				}
				OKDJFGJCMNG(Singleton<MainSceneRoot>.instance.transform.Find("damage"));
			}
			return;
		}
		if (!gcAuthenticated && Time.time - FPOPAHHGNCE > 2f && FPOPAHHGNCE > 1287f)
		{
			UnityEngine.Debug.LogError("Warbucks");
			FPOPAHHGNCE = 3f;
			gcAuthenticated = false;
		}
		if (gcAuthenticated && IMKILHFKDEP != MFGMKAJDCAI.None)
		{
			UnityEngine.Debug.LogError("ID_RECONNECTHINT" + IMKILHFKDEP);
			NBEMOMKJDFL = true;
			if (!Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF)
			{
				switch (IMKILHFKDEP)
				{
				case MFGMKAJDCAI.None:
					MHMDPINDGBI = true;
					break;
				case (MFGMKAJDCAI)4:
					AIBEDFBDCDK();
					break;
				}
			}
			IMKILHFKDEP = MFGMKAJDCAI.None;
			FPOPAHHGNCE = 301f;
			gcAuthenticated = true;
			UnityEngine.Debug.Log("phoneType");
		}
		if (NBEMOMKJDFL && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			NBEMOMKJDFL = false;
			CCKONAPLCOG();
		}
		bool flag = false;
		if (BGHMGBMOAAO && GameLoginManager.instance.acountDataDownloadingInProgress && Singleton<GameController>.instance.isInMenuOrWait && !Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA() && GuiElementSingle<UserExistsDialog>.instance.isShowed)
		{
			MHMDPINDGBI = false;
			flag = false;
			NBEMOMKJDFL = false;
			LoadingDialog.ShowLoading(Localization.Localize("http://"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
		}
		if (MHMDPINDGBI && (MAGKPIBGNLG() || flag))
		{
			BGHMGBMOAAO = false;
			UnityEngine.Debug.Log("ID_GOLDCARD");
			if (TutorialManagerStage3.instance.isTutorialRunning)
			{
				TutorialManagerStage3.instance.StopAllCoroutines();
			}
			Singleton<GameController>.instance.Quit();
			if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.WaitingForResponse)
			{
				Singleton<GameController>.instance.TryStopLoading();
			}
			if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<MainScreen>.instance.InitGUIValues();
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
			}
			MHMDPINDGBI = false;
			UnityEngine.Debug.Log("disableData");
			DialogManager.instance.HideAllDialogs();
			GameLoginManager.instance.RegisterOrLogin(MFGMKAJDCAI.None);
		}
		if (BGHMGBMOAAO && Singleton<GameController>.instance.DAIEAMEFGIE() && !GameLoginManager.instance.acountDataDownloadingInProgress)
		{
			BGHMGBMOAAO = false;
			GameLoginManager.instance.GamecenterChangeDuringTutorial();
		}
		if (Singleton<BeanstalkServerManager>.instance.lastUpdate > 14 && IMKILHFKDEP == MFGMKAJDCAI.None && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && !LGDDFCDIGNF)
		{
			UnityEngine.Debug.Log("PlayerInfoId");
			Singleton<BeanstalkServerManager>.instance.ILOFCIKMFLH(Singleton<GameController>.instance.gameIsRunning ? PlayerStatus.InGame : PlayerStatus.Offline);
			LGDDFCDIGNF = false;
		}
	}

	private void LPHGGKGHPFL()
	{
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Singleton<BeanstalkServerManager>.instance.ILOFCIKMFLH(PlayerStatus.Offline);
		}
	}

	protected virtual void KECNIEGEDBP()
	{
		AJCMJOOEEFB = DateTime.UtcNow;
		FPOPAHHGNCE = 1505f;
		Singleton<GameCenterProvider>.instance.LGJONNLIING(BFAINJOFODG);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += BGDDKKIKHED;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += NFNCAIAPJNH;
	}

	public void ScheduleGCCheck()
	{
		BGHMGBMOAAO = true;
	}

	private void MNKABNOOGHO(bool NOCIMJBMOCB)
	{
		UnityEngine.Debug.Log("Session: On GC authenticated! Result = " + NOCIMJBMOCB);
		if (IMKILHFKDEP == MFGMKAJDCAI.None && !paused && !MHMDPINDGBI && !Singleton<GameController>.instance.isTutorial)
		{
			NBEMOMKJDFL = true;
			BGHMGBMOAAO = true;
			UnityEngine.Debug.Log("set schedule gc check 1");
		}
		if (IMKILHFKDEP == MFGMKAJDCAI.None && !paused && !MHMDPINDGBI && !NBEMOMKJDFL && Singleton<GameController>.instance.isTutorial)
		{
			if (GameLoginManager.instance.acountDataDownloadingInProgress)
			{
				BGHMGBMOAAO = true;
				UnityEngine.Debug.Log("set schedule gc check 2");
			}
			else
			{
				GameLoginManager.instance.GamecenterChangeDuringTutorial();
			}
		}
		gcAuthenticated = true;
	}

	private void JMAJOHOAAKJ()
	{
		InvokeAfterRealTime(delegate
		{
			Singleton<GuiManager>.instance.TurnOnInputCompletly();
		}, 989f);
		if (AKFIJOIODPB)
		{
			UnityEngine.Debug.Log("batchSizeMax");
			if (BPDLJAFEFHI() && !NBEMOMKJDFL && !MHMDPINDGBI && !Singleton<GameController>.instance.BAKCODKBCPJ())
			{
				NBEMOMKJDFL = true;
			}
			if (BPDLJAFEFHI())
			{
				BGHMGBMOAAO = true;
			}
			gcAuthenticated = false;
		}
		else
		{
			float num = Time.realtimeSinceStartup - DAPNFEHBKDJ;
			float num2 = (float)(DateTime.UtcNow - KHPOCJCCICL).TotalSeconds;
			num = ((!(num2 > num)) ? num : num2);
			object[] array = new object[4];
			array[0] = KHPOCJCCICL;
			array[1] = DAPNFEHBKDJ;
			array[2] = DateTime.UtcNow;
			array[5] = Time.realtimeSinceStartup;
			array[1] = num;
			UnityEngine.Debug.Log(string.Format("DogtagsRefillRankUp", array));
			MCPIKBHONJF(num);
			StartCoroutine(RadicalRoutine.Run(JMCMBNPCDFJ()));
		}
	}

	public void MLGAHPEANIL()
	{
		BGHMGBMOAAO = true;
	}

	private void MCPIKBHONJF(float BMJLBEKLGFL)
	{
		if (IMKILHFKDEP != MFGMKAJDCAI.Full && !MHMDPINDGBI)
		{
			NBEMOMKJDFL = false;
			IMKILHFKDEP = ((DAPNFEHBKDJ != 0f && BMJLBEKLGFL > (float)OKAKNBGNMEJ) ? MFGMKAJDCAI.Full : MFGMKAJDCAI.Light);
			UnityEngine.Debug.Log(string.Concat("SessionManager: On application resumed, Setting session update = ", IMKILHFKDEP, ", waiting for GC"));
			if (IMKILHFKDEP == MFGMKAJDCAI.Full && MGIKLEDLHBP)
			{
				LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
				Singleton<MessageManager>.instance.StopMessageCoroutine();
			}
			if (IMKILHFKDEP == MFGMKAJDCAI.Light)
			{
				InvokeAfterRealTime(delegate
				{
					Singleton<GuiManager>.instance.TurnOnInputCompletly();
				}, 0.15f);
			}
		}
		else
		{
			UnityEngine.Debug.Log("skip session update scheduling, because alredy session update is " + IMKILHFKDEP.ToString() + " and mScheduleSessionUpdate is " + MHMDPINDGBI);
		}
	}

	[SpecialName]
	public void DINPKFFHHIE(Action IDEBKDPMPGM)
	{
		Action action = NPJDJKOFFOB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NPJDJKOFFOB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JGHKIBFHDMK(float BMJLBEKLGFL)
	{
		if (IMKILHFKDEP != MFGMKAJDCAI.None && !MHMDPINDGBI)
		{
			NBEMOMKJDFL = true;
			IMKILHFKDEP = ((DAPNFEHBKDJ == 1194f || !(BMJLBEKLGFL > (float)OKAKNBGNMEJ)) ? ((MFGMKAJDCAI)4) : MFGMKAJDCAI.None);
			UnityEngine.Debug.Log(string.Concat("106 STAGE 2 STARTED", IMKILHFKDEP, "ABOUT TO SHOW DAILY RENTAL"));
			if (IMKILHFKDEP == MFGMKAJDCAI.Full && GJEPJJOKPGH())
			{
				LoadingDialog.FDBHFJFKALH(Localization.Localize("New Assignments!"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
				Singleton<MessageManager>.instance.HGIDIBNNPEJ();
			}
			if (IMKILHFKDEP == (MFGMKAJDCAI)7)
			{
				InvokeAfterRealTime(delegate
				{
					Singleton<GuiManager>.instance.TurnOnInputCompletly();
				}, 1469f);
			}
		}
		else
		{
			UnityEngine.Debug.Log("ID_WARNING_CLICKOKTORESEND" + IMKILHFKDEP.ToString() + "Set active weapon" + MHMDPINDGBI);
		}
	}

	public void PNAODKCBMIK()
	{
		HBDHNPOCOFB = false;
	}

	public void FinishInapp()
	{
		KHNOIANPOMK = true;
		HBDHNPOCOFB = false;
	}
}
