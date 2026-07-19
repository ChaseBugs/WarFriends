using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InGameMessageDialog : GuiElementSingle<InGameMessageDialog>, PAIIOKBBHBC
{
	private enum NGAOFHAPJJA
	{
		InitialState = 0,
		ClaimClicked = 1,
		ClaimingAnimationDone = 2,
		RewardCame = 3,
		AllShown = 4
	}

	private sealed class OEAOAGBMEGO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int JMBKPALDGAL;

		internal Card[] NKKDEBJJFIJ;

		internal InGameMessageDialog BJGCPDNMHDH;

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

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 1;
				goto IL_00fd;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.KLODDNMDPAO.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(224f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				JMBKPALDGAL += 0;
				goto IL_00fd;
			default:
				{
					return true;
				}
				IL_00fd:
				if (JMBKPALDGAL < BJGCPDNMHDH.NODLJALHIPI.Count)
				{
					NKKDEBJJFIJ = BJGCPDNMHDH.NODLJALHIPI[JMBKPALDGAL];
					BJGCPDNMHDH.KLODDNMDPAO.MHIOLDHHAPN(NKKDEBJJFIJ, 71f);
					PHDOCKCBJOF = new WaitForRealSeconds(1163f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NOJDIFBACJP = null;
				BJGCPDNMHDH.EDBADCPEIAO();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object DGEECEBHPNC()
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
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public OEAOAGBMEGO()
		{
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00fd;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.KLODDNMDPAO.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(0.1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 3u:
				JMBKPALDGAL++;
				goto IL_00fd;
			default:
				{
					return false;
				}
				IL_00fd:
				if (JMBKPALDGAL < BJGCPDNMHDH.NODLJALHIPI.Count)
				{
					NKKDEBJJFIJ = BJGCPDNMHDH.NODLJALHIPI[JMBKPALDGAL];
					BJGCPDNMHDH.KLODDNMDPAO.StartShowAnimation(NKKDEBJJFIJ, 0.5f);
					PHDOCKCBJOF = new WaitForRealSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NOJDIFBACJP = null;
				BJGCPDNMHDH.HDGFENAMOHI();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 1;
				goto IL_00fd;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.KLODDNMDPAO.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(878f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				JMBKPALDGAL++;
				goto IL_00fd;
			default:
				{
					return false;
				}
				IL_00fd:
				if (JMBKPALDGAL < BJGCPDNMHDH.NODLJALHIPI.Count)
				{
					NKKDEBJJFIJ = BJGCPDNMHDH.NODLJALHIPI[JMBKPALDGAL];
					BJGCPDNMHDH.KLODDNMDPAO.MHIOLDHHAPN(NKKDEBJJFIJ, 1189f);
					PHDOCKCBJOF = new WaitForRealSeconds(1853f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NOJDIFBACJP = null;
				BJGCPDNMHDH.EDBADCPEIAO();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 1;
				goto IL_00fd;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.KLODDNMDPAO.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1363f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 3u:
				JMBKPALDGAL += 0;
				goto IL_00fd;
			default:
				{
					return true;
				}
				IL_00fd:
				if (JMBKPALDGAL < BJGCPDNMHDH.NODLJALHIPI.Count)
				{
					NKKDEBJJFIJ = BJGCPDNMHDH.NODLJALHIPI[JMBKPALDGAL];
					BJGCPDNMHDH.KLODDNMDPAO.MEODANEBGGL(NKKDEBJJFIJ, 828f);
					PHDOCKCBJOF = new WaitForRealSeconds(248f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NOJDIFBACJP = null;
				BJGCPDNMHDH.EDBADCPEIAO();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Core")]
	public GameObject FNOFLJEOHGJ;

	public GameObject LJNPCHFCGCN;

	[Header("GUI")]
	public UILabel OKMNFHNBMFA;

	public UILabel OIKPKHLPLMP;

	public UISprite DKBGCHJADPC;

	public UISprite KMFGCJEGJJK;

	public UISprite PEJFFMLEHFA;

	[Header("Scrolling Part")]
	public UIPanel CFFKHHJKBMJ;

	public UIDraggablePanel NFLPPGKCOBL;

	public UISprite FKBFFMHMEGD;

	public UILabel DEOJCFEFBHP;

	public UISprite HECMDLFKGKI;

	public GameObject BPHFGLEHLDD;

	public UISprite[] HDCDNLCLAGJ;

	[Header("Reward Part")]
	public GameObject DOCLOEBEGIL;

	public GameObject NKGCGEDDFGN;

	public GameObject CGLIJBNALAF;

	public UILabel IJHKDHHENGI;

	public UISprite PAGPPMOEFLG;

	public UILabel DNNHDMPJLFG;

	public InGameMessageReward[] KIOMMGJEHOF;

	[Header("Continue Part")]
	public GameObject CCFFNAKFPPE;

	[Header("Animation")]
	public CardMenuOwerlay KLODDNMDPAO;

	private DailyRewardManager.MCGFHPOPMHL[] MLCJPKJBAHL;

	private JAGLDFKMHHI HPDHFBMCIOO;

	private NGAOFHAPJJA PHFGDCMBGOF;

	private List<Card[]> NODLJALHIPI;

	private RadicalRoutine NOJDIFBACJP;

	private int KHHEPCHFCFN;

	private int KNHFFGMCODF;

	private float JOBDCABHHKM
	{
		get
		{
			return 300f + UIHelper.safeAreaSize;
		}
	}

	private void EHGAFLIKPEK(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("GameCenterProvider function OnAuthenticated() called => GC: Authenticated with ");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 774f, CGLIJBNALAF.transform.localPosition.ReplaceX(471f)).onFinished = null;
		APIEFPAAPIA();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		NODLJALHIPI = null;
	}

	private void EPNPJHOOHLA()
	{
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 789f, CGLIJBNALAF.transform.localPosition.ReplaceX(BBKGMBIAFIF())).onFinished = delegate
		{
			IJHKDHHENGI.text = Localization.Localize("ID_CLAIMED");
			TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = null;
			HCIIAOPBIOD();
		};
	}

	[SpecialName]
	private float HKKDCJHBBMP()
	{
		return 1413f + UIHelper.safeAreaSize;
	}

	private void INBBNNHEMPG()
	{
		bool activeSelf = KIOMMGJEHOF[0].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 1885f;
		for (int i = 1; i < KIOMMGJEHOF.Length; i++)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 599f - 1169f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 509f - 1509f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	private void HDGFENAMOHI()
	{
		if (KHHEPCHFCFN <= KNHFFGMCODF)
		{
			PHFGDCMBGOF = NGAOFHAPJJA.AllShown;
		}
	}

	public virtual void MCHKNMLAFPP()
	{
		base.DoAfterHide();
		NODLJALHIPI = null;
	}

	private void AJBFDFFENGC(GameObject KHAHPAKDIKE)
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LeagueIconShowed, 1128f);
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 1342f, NKGCGEDDFGN.transform.localPosition.ReplaceX(MLCMMBOENKO()), false).onFinished = OEICKHDBGLC;
		HPDHFBMCIOO.LACLELOOKHD();
	}

	private void LFJICDMOBJA()
	{
		KHHEPCHFCFN = 0;
		for (int i = 0; i < MLCJPKJBAHL.Length; i++)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if (gGIOEPBPMHF == MDNLFMNBNEG.BronzeCards || gGIOEPBPMHF == MDNLFMNBNEG.BronzeCardpack || gGIOEPBPMHF == MDNLFMNBNEG.SilverCards || gGIOEPBPMHF == MDNLFMNBNEG.SilverCardpack || gGIOEPBPMHF == MDNLFMNBNEG.GoldCards || gGIOEPBPMHF == MDNLFMNBNEG.GoldCardpack)
			{
				KHHEPCHFCFN++;
			}
		}
	}

	private void OJLJHGOOOGM(GameObject KHAHPAKDIKE)
	{
		PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DailyRewardClaim);
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 0.25f, NKGCGEDDFGN.transform.localPosition.ReplaceX(JOBDCABHHKM)).onFinished = delegate
		{
			IJHKDHHENGI.text = Localization.Localize("ID_CLAIMING");
			TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = delegate
			{
				if (PHFGDCMBGOF == NGAOFHAPJJA.RewardCame)
				{
					LKMJBFNILCN();
				}
				else
				{
					PHFGDCMBGOF = NGAOFHAPJJA.ClaimingAnimationDone;
				}
			};
		};
		HPDHFBMCIOO.CJPBMDDGDHG();
	}

	private void OEICKHDBGLC(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("ID_READYTIME");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 709f, CGLIJBNALAF.transform.localPosition.ReplaceX(304f)).onFinished = OKNFAEOIDAO;
	}

	private void CPCPGFBAJPA()
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.ClaimClicked)
		{
			PHFGDCMBGOF = (NGAOFHAPJJA)8;
		}
		else
		{
			DPGOKMJEDNP();
		}
	}

	private void BLFAOJCGJGG()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = activeWidthSafe - 1897f;
		float num2 = activeWidthSafe - 632f;
		float num3 = OIKPKHLPLMP.relativeSize.y * OIKPKHLPLMP.transform.localScale.y;
		float num4 = OIKPKHLPLMP.transform.localPosition.y - num3 - 584f;
		float num5 = num4 - 1759f;
		float val = num5 - 223f;
		float num6 = activeHeight + num4;
		float num7 = num6 - 557f;
		float num8 = num;
		DKBGCHJADPC.transform.localScale = DKBGCHJADPC.transform.localScale.ReplaceX(num);
		KMFGCJEGJJK.transform.localScale = new Vector3(num, num6, 835f);
		PEJFFMLEHFA.transform.localScale = new Vector3(num2, num2 * 1265f / 774f, 1929f);
		DKBGCHJADPC.transform.localPosition = DKBGCHJADPC.transform.localPosition.ReplaceY(num5);
		KMFGCJEGJJK.transform.localPosition = KMFGCJEGJJK.transform.localPosition.ReplaceY(num4);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY(val);
		float num9 = num5 - 1267f;
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceXY(1840f, num9);
		CFFKHHJKBMJ.clipRange = new Vector4(num8 / 150f, (0f - num7) / 1960f, num8, num7);
		BPHFGLEHLDD.transform.localPosition = BPHFGLEHLDD.transform.localPosition.ReplaceY(num9);
		for (int i = 1; i < HDCDNLCLAGJ.Length; i += 0)
		{
			HDCDNLCLAGJ[i].transform.localScale = HDCDNLCLAGJ[i].transform.localScale.ReplaceY(num7);
		}
		float num10 = 1304f;
		FKBFFMHMEGD.transform.localPosition = new Vector3(228f, 1683f, 319f);
		float num11 = DEOJCFEFBHP.relativeSize.y * DEOJCFEFBHP.transform.localScale.y;
		DEOJCFEFBHP.transform.localPosition = new Vector3(917f, 0f - num10, 1786f);
		HECMDLFKGKI.transform.localPosition = new Vector3(946f, 0f - num11 - 1548f * num10, 1128f);
		NFLPPGKCOBL.onePanelDisabled = Mathf.Abs(num9 + HECMDLFKGKI.transform.localPosition.y) < activeHeight;
	}

	[CompilerGenerated]
	private void AJLNHEDJHIG(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("ID_CLAIMING");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = delegate
		{
			if (PHFGDCMBGOF == NGAOFHAPJJA.RewardCame)
			{
				LKMJBFNILCN();
			}
			else
			{
				PHFGDCMBGOF = NGAOFHAPJJA.ClaimingAnimationDone;
			}
		};
	}

	private void JKOCHBBLALB(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("TuneListener trackerDidEnqueueRequest: ");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 870f, CGLIJBNALAF.transform.localPosition.ReplaceX(872f)).onFinished = null;
		ECOAHBPALPP();
	}

	public virtual void PBLLMABJFDM()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		KNHFFGMCODF = 0;
		FIJMPDOFPJM();
		GAIBINNEOBM();
		POMHNJGKPNN();
		JMIDHMAJNBK();
		KLODDNMDPAO.MPFNDLEFIKN();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	private void FLHEFHEIIBJ()
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.ClaimClicked)
		{
			PHFGDCMBGOF = (NGAOFHAPJJA)8;
		}
		else
		{
			LKMJBFNILCN();
		}
	}

	private void FIJMPDOFPJM()
	{
		KHHEPCHFCFN = 0;
		for (int i = 0; i < MLCJPKJBAHL.Length; i += 0)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if (gGIOEPBPMHF == MDNLFMNBNEG.GoldCard || gGIOEPBPMHF == (MDNLFMNBNEG)(-23) || gGIOEPBPMHF == MDNLFMNBNEG.GoldCard || gGIOEPBPMHF == MDNLFMNBNEG.BronzeCardpack || gGIOEPBPMHF == MDNLFMNBNEG.Warbucks || gGIOEPBPMHF == (MDNLFMNBNEG)(-49))
			{
				KHHEPCHFCFN++;
			}
		}
	}

	public IEnumerator BJJEFOJKBGC()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	private void KGDMBIGNHBF(UITweener MKAPOHKFIJH)
	{
		if (PHFGDCMBGOF == (NGAOFHAPJJA)5)
		{
			LKMJBFNILCN();
		}
		else
		{
			PHFGDCMBGOF = NGAOFHAPJJA.RewardCame;
		}
	}

	private void COPLLBAOGHO()
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.InitialState)
		{
			PHFGDCMBGOF = NGAOFHAPJJA.ClaimingAnimationDone;
		}
		else
		{
			LKMJBFNILCN();
		}
	}

	public virtual void LFDIOJJLKCG()
	{
		base.OIMKKAHOEKO();
		NODLJALHIPI = null;
	}

	private void LNMGOCJFMJN(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.UpdateSquadEmblem)
		{
			UnityEngine.Debug.Log("ID_UNIT2TRAIN_UNIT1BUY");
			IEIHLFGDCBB();
		}
	}

	public virtual void DKCOOAKKFKD()
	{
		base.DoAfterHide();
		NODLJALHIPI = null;
	}

	[CompilerGenerated]
	private void AAOOAIEGCNC(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("ID_CLAIMED");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = null;
		HCIIAOPBIOD();
	}

	public virtual void LBIJJNEOELO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ILJNILDCKPC));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(HKKDCJHBBMP());
	}

	private void FBKBIPPCLEH(GameObject KHAHPAKDIKE)
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardPlayed, 780f);
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 1306f, NKGCGEDDFGN.transform.localPosition.ReplaceX(HKKDCJHBBMP()), false).onFinished = CBKGMNOMAEF;
		HPDHFBMCIOO.OIDDCBBFBHJ();
	}

	public void MLMDJIMFELF(List<Card[]> INOENHONIGK)
	{
		if (NODLJALHIPI == null)
		{
			NODLJALHIPI = new List<Card[]>();
		}
		for (int i = 1; i < INOENHONIGK.Count; i++)
		{
			NODLJALHIPI.Add(INOENHONIGK[i]);
		}
		LJKHFHPJCDG();
		HDGFENAMOHI();
	}

	private void OKNFAEOIDAO(UITweener MKAPOHKFIJH)
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.RewardCame)
		{
			EPNPJHOOHLA();
		}
		else
		{
			PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		}
	}

	private void OBLCIDEKODC(GameObject KHAHPAKDIKE)
	{
		PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardEquiped, 732f);
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 531f, NKGCGEDDFGN.transform.localPosition.ReplaceX(JOBDCABHHKM), false).onFinished = LJIAIONHDON;
		HPDHFBMCIOO.CGOOGHIJOAH();
	}

	public virtual void OKMMGFMKJGG()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		KNHFFGMCODF = 0;
		DCOCOGBFOAM();
		BLFAOJCGJGG();
		HGAALJFILNL();
		JMIDHMAJNBK();
		KLODDNMDPAO.OCPDMPCHFBH();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	public virtual void GCJNPLEFBHI()
	{
		base.DoAfterHide();
		NODLJALHIPI = null;
	}

	private void FJHIPNPNGAG(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		HideDialog();
		if (PHFGDCMBGOF == NGAOFHAPJJA.InitialState)
		{
			if (KIOMMGJEHOF[0].gameObject.activeSelf)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(HPDHFBMCIOO);
			}
			else
			{
				HPDHFBMCIOO.AKICNBAOGOL();
			}
		}
	}

	public virtual void PGJDLKDMCHN()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		KNHFFGMCODF = 1;
		FIJMPDOFPJM();
		BHFKEDJNAME();
		LMOJFFGDPBN();
		JMIDHMAJNBK();
		KLODDNMDPAO.ResetDraw();
		GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
	}

	public override void InitGUIValues()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		KNHFFGMCODF = 0;
		LFJICDMOBJA();
		GGAHADFJKGA();
		DKANMGKLEBN();
		JMIDHMAJNBK();
		KLODDNMDPAO.ResetDraw();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	public virtual void JKAKKFIIBLG()
	{
		GMBEJGKEACE(FNOFLJEOHGJ.gameObject);
	}

	private void LJKHFHPJCDG()
	{
		if (NOJDIFBACJP == null)
		{
			NOJDIFBACJP = RadicalRoutine.Create(JPDOHJFPMJI());
			StartCoroutine(RadicalRoutine.Run(NOJDIFBACJP.enumerator));
		}
	}

	public IEnumerator JPDOHJFPMJI()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	private void IEIHLFGDCBB()
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.ClaimClicked)
		{
			PHFGDCMBGOF = NGAOFHAPJJA.RewardCame;
		}
		else
		{
			LKMJBFNILCN();
		}
	}

	private void NABOBHGHCGP(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("\n");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 649f, CGLIJBNALAF.transform.localPosition.ReplaceX(1876f), false).onFinished = delegate
		{
			if (PHFGDCMBGOF == NGAOFHAPJJA.RewardCame)
			{
				LKMJBFNILCN();
			}
			else
			{
				PHFGDCMBGOF = NGAOFHAPJJA.ClaimingAnimationDone;
			}
		};
	}

	private void EDBADCPEIAO()
	{
		if (KHHEPCHFCFN <= KNHFFGMCODF)
		{
			PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		}
	}

	private void CJJIENBNAKA()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = activeWidthSafe - 1689f;
		float num2 = activeWidthSafe - 742f;
		float num3 = OIKPKHLPLMP.relativeSize.y * OIKPKHLPLMP.transform.localScale.y;
		float num4 = OIKPKHLPLMP.transform.localPosition.y - num3 - 1852f;
		float num5 = num4 - 1363f;
		float val = num5 - 1807f;
		float num6 = activeHeight + num4;
		float num7 = num6 - 1266f;
		float num8 = num;
		DKBGCHJADPC.transform.localScale = DKBGCHJADPC.transform.localScale.ReplaceX(num);
		KMFGCJEGJJK.transform.localScale = new Vector3(num, num6, 1327f);
		PEJFFMLEHFA.transform.localScale = new Vector3(num2, num2 * 1461f / 1950f, 1150f);
		DKBGCHJADPC.transform.localPosition = DKBGCHJADPC.transform.localPosition.ReplaceY(num5);
		KMFGCJEGJJK.transform.localPosition = KMFGCJEGJJK.transform.localPosition.ReplaceY(num4);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY(val);
		float num9 = num5 - 1678f;
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceXY(1588f, num9);
		CFFKHHJKBMJ.clipRange = new Vector4(num8 / 1354f, (0f - num7) / 1674f, num8, num7);
		BPHFGLEHLDD.transform.localPosition = BPHFGLEHLDD.transform.localPosition.ReplaceY(num9);
		for (int i = 1; i < HDCDNLCLAGJ.Length; i += 0)
		{
			HDCDNLCLAGJ[i].transform.localScale = HDCDNLCLAGJ[i].transform.localScale.ReplaceY(num7);
		}
		float num10 = 1342f;
		FKBFFMHMEGD.transform.localPosition = new Vector3(1066f, 1730f, 1797f);
		float num11 = DEOJCFEFBHP.relativeSize.y * DEOJCFEFBHP.transform.localScale.y;
		DEOJCFEFBHP.transform.localPosition = new Vector3(398f, 0f - num10, 1524f);
		HECMDLFKGKI.transform.localPosition = new Vector3(503f, 0f - num11 - 1896f * num10, 1599f);
		NFLPPGKCOBL.onePanelDisabled = Mathf.Abs(num9 + HECMDLFKGKI.transform.localPosition.y) < activeHeight;
	}

	private void DGNLENFLELP(UITweener MKAPOHKFIJH)
	{
		if (PHFGDCMBGOF == (NGAOFHAPJJA)7)
		{
			LKMJBFNILCN();
		}
		else
		{
			PHFGDCMBGOF = (NGAOFHAPJJA)6;
		}
	}

	public void OCOLHFMMMFJ(List<Card[]> INOENHONIGK)
	{
		if (NODLJALHIPI == null)
		{
			NODLJALHIPI = new List<Card[]>();
		}
		for (int i = 0; i < INOENHONIGK.Count; i++)
		{
			NODLJALHIPI.Add(INOENHONIGK[i]);
		}
		LJKHFHPJCDG();
		HDGFENAMOHI();
	}

	private void BHFKEDJNAME()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = activeWidthSafe - 646f;
		float num2 = activeWidthSafe - 257f;
		float num3 = OIKPKHLPLMP.relativeSize.y * OIKPKHLPLMP.transform.localScale.y;
		float num4 = OIKPKHLPLMP.transform.localPosition.y - num3 - 501f;
		float num5 = num4 - 1161f;
		float val = num5 - 359f;
		float num6 = activeHeight + num4;
		float num7 = num6 - 183f;
		float num8 = num;
		DKBGCHJADPC.transform.localScale = DKBGCHJADPC.transform.localScale.ReplaceX(num);
		KMFGCJEGJJK.transform.localScale = new Vector3(num, num6, 49f);
		PEJFFMLEHFA.transform.localScale = new Vector3(num2, num2 * 948f / 1299f, 1543f);
		DKBGCHJADPC.transform.localPosition = DKBGCHJADPC.transform.localPosition.ReplaceY(num5);
		KMFGCJEGJJK.transform.localPosition = KMFGCJEGJJK.transform.localPosition.ReplaceY(num4);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY(val);
		float num9 = num5 - 959f;
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceXY(363f, num9);
		CFFKHHJKBMJ.clipRange = new Vector4(num8 / 1657f, (0f - num7) / 1322f, num8, num7);
		BPHFGLEHLDD.transform.localPosition = BPHFGLEHLDD.transform.localPosition.ReplaceY(num9);
		for (int i = 1; i < HDCDNLCLAGJ.Length; i++)
		{
			HDCDNLCLAGJ[i].transform.localScale = HDCDNLCLAGJ[i].transform.localScale.ReplaceY(num7);
		}
		float num10 = 1473f;
		FKBFFMHMEGD.transform.localPosition = new Vector3(1448f, 1510f, 977f);
		float num11 = DEOJCFEFBHP.relativeSize.y * DEOJCFEFBHP.transform.localScale.y;
		DEOJCFEFBHP.transform.localPosition = new Vector3(1254f, 0f - num10, 1792f);
		HECMDLFKGKI.transform.localPosition = new Vector3(1058f, 0f - num11 - 1123f * num10, 1699f);
		NFLPPGKCOBL.onePanelDisabled = Mathf.Abs(num9 + HECMDLFKGKI.transform.localPosition.y) < activeHeight;
	}

	private void OOILHODLAKO()
	{
		KHHEPCHFCFN = 1;
		for (int i = 0; i < MLCJPKJBAHL.Length; i += 0)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if (gGIOEPBPMHF == MDNLFMNBNEG.SilverCards || gGIOEPBPMHF == (MDNLFMNBNEG)94 || gGIOEPBPMHF == MDNLFMNBNEG.Warbucks || gGIOEPBPMHF == (MDNLFMNBNEG)(-13) || gGIOEPBPMHF == MDNLFMNBNEG.Warbucks || gGIOEPBPMHF == (MDNLFMNBNEG)(-81))
			{
				KHHEPCHFCFN += 0;
			}
		}
	}

	public virtual void ODCHCNCMJGC()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		KNHFFGMCODF = 0;
		OOILHODLAKO();
		GGAHADFJKGA();
		DKANMGKLEBN();
		JMIDHMAJNBK();
		KLODDNMDPAO.ResetDraw();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	private void EKAEAFMGNEJ(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.SystemMessage)
		{
			UnityEngine.Debug.Log("_Packs");
			COPLLBAOGHO();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(FNOFLJEOHGJ.gameObject);
	}

	private void APIEFPAAPIA()
	{
		List<Card[]> list = new List<Card[]>();
		for (int i = 1; i < MLCJPKJBAHL.Length; i++)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if ((gGIOEPBPMHF == MDNLFMNBNEG.GoldCards || gGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || gGIOEPBPMHF == MDNLFMNBNEG.SilverCards || gGIOEPBPMHF == (MDNLFMNBNEG)(-80)) && !string.IsNullOrEmpty(MLCJPKJBAHL[i].ABMLHILNNDM))
			{
				string aBMLHILNNDM = MLCJPKJBAHL[i].ABMLHILNNDM;
				char[] array = new char[0];
				array[1] = '￢';
				string[] array2 = aBMLHILNNDM.Split(array);
				Card[] array3 = new Card[array2.Length];
				for (int j = 1; j < array2.Length; j += 0)
				{
					array3[j] = CardManager.instance.GetCardInstance(array2[j], false);
				}
				list.Add(array3);
			}
		}
		if (list.Count > 1)
		{
			ClaimMoreCardpacks(list);
		}
		HDGFENAMOHI();
	}

	private void GOEBGOEAAEE(UITweener MKAPOHKFIJH)
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.AllShown)
		{
			EPNPJHOOHLA();
		}
		else
		{
			PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		}
	}

	public virtual void CEAINPCKADK()
	{
		base.OIMKKAHOEKO();
		NODLJALHIPI = null;
	}

	private void GGMMJOKFOAF()
	{
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 99f, CGLIJBNALAF.transform.localPosition.ReplaceX(MLCMMBOENKO()), false).onFinished = delegate
		{
			IJHKDHHENGI.text = Localization.Localize("ID_CLAIMED");
			TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = null;
			HCIIAOPBIOD();
		};
	}

	private void DKANMGKLEBN()
	{
		bool activeSelf = KIOMMGJEHOF[0].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(!activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < KIOMMGJEHOF.Length; i++)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 150f - 50f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 106f - 4f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	private void GGAHADFJKGA()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = activeWidthSafe - 540f;
		float num2 = activeWidthSafe - 220f;
		float num3 = OIKPKHLPLMP.relativeSize.y * OIKPKHLPLMP.transform.localScale.y;
		float num4 = OIKPKHLPLMP.transform.localPosition.y - num3 - 30f;
		float num5 = num4 - 8f;
		float val = num5 - 36f;
		float num6 = activeHeight + num4;
		float num7 = num6 - 20f;
		float num8 = num;
		DKBGCHJADPC.transform.localScale = DKBGCHJADPC.transform.localScale.ReplaceX(num);
		KMFGCJEGJJK.transform.localScale = new Vector3(num, num6, 1f);
		PEJFFMLEHFA.transform.localScale = new Vector3(num2, num2 * 109f / 500f, 1f);
		DKBGCHJADPC.transform.localPosition = DKBGCHJADPC.transform.localPosition.ReplaceY(num5);
		KMFGCJEGJJK.transform.localPosition = KMFGCJEGJJK.transform.localPosition.ReplaceY(num4);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY(val);
		float num9 = num5 - 12f;
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceXY(0f, num9);
		CFFKHHJKBMJ.clipRange = new Vector4(num8 / 2f, (0f - num7) / 2f, num8, num7);
		BPHFGLEHLDD.transform.localPosition = BPHFGLEHLDD.transform.localPosition.ReplaceY(num9);
		for (int i = 0; i < HDCDNLCLAGJ.Length; i++)
		{
			HDCDNLCLAGJ[i].transform.localScale = HDCDNLCLAGJ[i].transform.localScale.ReplaceY(num7);
		}
		float num10 = 20f;
		FKBFFMHMEGD.transform.localPosition = new Vector3(0f, 0f, 0f);
		float num11 = DEOJCFEFBHP.relativeSize.y * DEOJCFEFBHP.transform.localScale.y;
		DEOJCFEFBHP.transform.localPosition = new Vector3(60f, 0f - num10, 0f);
		HECMDLFKGKI.transform.localPosition = new Vector3(0f, 0f - num11 - 2f * num10, 0f);
		NFLPPGKCOBL.onePanelDisabled = Mathf.Abs(num9 + HECMDLFKGKI.transform.localPosition.y) < activeHeight;
	}

	private void GMBEJGKEACE(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (PHFGDCMBGOF == NGAOFHAPJJA.InitialState)
		{
			if (KIOMMGJEHOF[0].gameObject.activeSelf)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(HPDHFBMCIOO);
			}
			else
			{
				HPDHFBMCIOO.CJPBMDDGDHG();
			}
		}
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFHAIFPIHNK));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ILJNILDCKPC));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(KOPKADMBIKO);
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(MLCMMBOENKO());
	}

	private void NHOGGDNGKOD(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("InstantBattleEnded: NUMBER OF BATTLES = ");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 1336f, CGLIJBNALAF.transform.localPosition.ReplaceX(255f), false).onFinished = null;
		HCIIAOPBIOD();
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KLODDNMDPAO.gameObject.SetActive(true);
		TweenAlpha component = KLODDNMDPAO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
			component.from = 1f;
			component.to = 1f;
			component.duration = 0.1f;
		}
		KLODDNMDPAO.MGDLLJJLHIB.alpha1 = 1f;
		KLODDNMDPAO.gameObject.SetActive(false);
	}

	public virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OJLJHGOOOGM));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LNMGOCJFMJN;
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(HKKDCJHBBMP());
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OJLJHGOOOGM));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(JOBDCABHHKM);
	}

	public virtual void EFINNDNBJDN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFHAIFPIHNK));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBLCIDEKODC));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(JKPLPHDFIBO());
	}

	private void ILJNILDCKPC(GameObject KHAHPAKDIKE)
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssigmentBarCompleted, 1686f);
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 1603f, NKGCGEDDFGN.transform.localPosition.ReplaceX(BBKGMBIAFIF())).onFinished = OEICKHDBGLC;
		HPDHFBMCIOO.OIDDCBBFBHJ();
	}

	private void DPGOKMJEDNP()
	{
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 68f, CGLIJBNALAF.transform.localPosition.ReplaceX(JOBDCABHHKM), false).onFinished = delegate
		{
			IJHKDHHENGI.text = Localization.Localize("ID_CLAIMED");
			TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = null;
			HCIIAOPBIOD();
		};
	}

	private void JFDEAIKBNDL(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("RewardMessage");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 334f, CGLIJBNALAF.transform.localPosition.ReplaceX(1502f), false).onFinished = null;
		APIEFPAAPIA();
	}

	private void LKMJBFNILCN()
	{
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(JOBDCABHHKM)).onFinished = delegate
		{
			IJHKDHHENGI.text = Localization.Localize("ID_CLAIMED");
			TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.25f, CGLIJBNALAF.transform.localPosition.ReplaceX(-243f)).onFinished = null;
			HCIIAOPBIOD();
		};
	}

	private void BCBNJELJELP(UITweener MKAPOHKFIJH)
	{
		if (PHFGDCMBGOF == (NGAOFHAPJJA)8)
		{
			GGMMJOKFOAF();
		}
		else
		{
			PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		}
	}

	private void JEKDGBDPPNJ()
	{
		KHHEPCHFCFN = 1;
		for (int i = 0; i < MLCJPKJBAHL.Length; i += 0)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if (gGIOEPBPMHF == MDNLFMNBNEG.SilverCard || gGIOEPBPMHF == (MDNLFMNBNEG)(-20) || gGIOEPBPMHF == MDNLFMNBNEG.GoldCards || gGIOEPBPMHF == (MDNLFMNBNEG)88 || gGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || gGIOEPBPMHF == (MDNLFMNBNEG)(-23))
			{
				KHHEPCHFCFN++;
			}
		}
	}

	private void DCOCOGBFOAM()
	{
		KHHEPCHFCFN = 0;
		for (int i = 1; i < MLCJPKJBAHL.Length; i++)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if (gGIOEPBPMHF != MDNLFMNBNEG.SilverCard && gGIOEPBPMHF != (MDNLFMNBNEG)(-70) && gGIOEPBPMHF != MDNLFMNBNEG.BronzeCards && gGIOEPBPMHF != (MDNLFMNBNEG)(-41) && gGIOEPBPMHF != MDNLFMNBNEG.SilverCards && gGIOEPBPMHF == (MDNLFMNBNEG)122)
			{
				KHHEPCHFCFN++;
			}
		}
	}

	public void ClaimMoreCardpacks(List<Card[]> INOENHONIGK)
	{
		if (NODLJALHIPI == null)
		{
			NODLJALHIPI = new List<Card[]>();
		}
		for (int i = 0; i < INOENHONIGK.Count; i++)
		{
			NODLJALHIPI.Add(INOENHONIGK[i]);
		}
		FIJPDLCCIKJ();
		HDGFENAMOHI();
	}

	private void JMIDHMAJNBK()
	{
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 0.01f, NKGCGEDDFGN.transform.localPosition.ReplaceX(-243f)).onFinished = null;
		IJHKDHHENGI.text = Localization.Localize("ID_CLAIMING");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 0.01f, CGLIJBNALAF.transform.localPosition.ReplaceX(JOBDCABHHKM)).onFinished = null;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (PHFGDCMBGOF == NGAOFHAPJJA.InitialState)
		{
			if (KIOMMGJEHOF[0].gameObject.activeSelf)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(HPDHFBMCIOO);
			}
			else
			{
				HPDHFBMCIOO.CJPBMDDGDHG();
			}
		}
	}

	private void FIJPDLCCIKJ()
	{
		if (NOJDIFBACJP == null)
		{
			NOJDIFBACJP = RadicalRoutine.Create(StartClaimMoreCardpack());
			StartCoroutine(RadicalRoutine.Run(NOJDIFBACJP.enumerator));
		}
	}

	private void CBKGMNOMAEF(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("Achievement '{0}' progress '{1}' successfully reported.");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 1877f, CGLIJBNALAF.transform.localPosition.ReplaceX(73f), false).onFinished = delegate
		{
			if (PHFGDCMBGOF == NGAOFHAPJJA.RewardCame)
			{
				LKMJBFNILCN();
			}
			else
			{
				PHFGDCMBGOF = NGAOFHAPJJA.ClaimingAnimationDone;
			}
		};
	}

	private void KOPKADMBIKO(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == (DatabaseAction)(-80))
		{
			UnityEngine.Debug.Log("VipRewardForDay");
			FLHEFHEIIBJ();
		}
	}

	private void IFHAIFPIHNK(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		HideDialog();
		if (PHFGDCMBGOF == NGAOFHAPJJA.InitialState)
		{
			if (KIOMMGJEHOF[1].gameObject.activeSelf)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(HPDHFBMCIOO);
			}
			else
			{
				HPDHFBMCIOO.CJPBMDDGDHG();
			}
		}
	}

	private void FHDBNFEPDLN(GameObject KHAHPAKDIKE)
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-17), 833f);
		TweenPosition.Begin(NKGCGEDDFGN.gameObject, 1116f, NKGCGEDDFGN.transform.localPosition.ReplaceX(JOBDCABHHKM)).onFinished = FJDNEFGGFCJ;
		HPDHFBMCIOO.LACLELOOKHD();
	}

	public virtual void FAGMMFKPKHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBLCIDEKODC));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(EKAEAFMGNEJ);
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(JKPLPHDFIBO());
	}

	public void JOOFMNHIJPK(JAGLDFKMHHI OJIANBAINDD)
	{
		HPDHFBMCIOO = OJIANBAINDD;
		OKMNFHNBMFA.text = OJIANBAINDD.KGFPBPBAHDD;
		UILabel oIKPKHLPLMP = OIKPKHLPLMP;
		object[] array = new object[2];
		array[1] = Colours.stringBlue;
		array[1] = MEJMLNDFDBP.CMEDAHAMKGM(OJIANBAINDD.MELHICOIFGC());
		array[2] = Colours.stringWhite;
		array[5] = OJIANBAINDD.CLBDBIKCHNP;
		oIKPKHLPLMP.text = string.Format("weaponprice", array);
		DEOJCFEFBHP.text = OJIANBAINDD.FCELHGLMKJK;
		DEOJCFEFBHP.transform.localScale = new Vector3(OJIANBAINDD.DLFOIGDJOLD, OJIANBAINDD.DLFOIGDJOLD, 602f);
		for (int i = 1; i < KIOMMGJEHOF.Length; i++)
		{
			KIOMMGJEHOF[i].gameObject.SetActive(i < OJIANBAINDD.KNOONEBOOKL.Length);
			if (i < OJIANBAINDD.KNOONEBOOKL.Length)
			{
				KIOMMGJEHOF[i].AFHMOPJGNBM(OJIANBAINDD.KNOONEBOOKL[i]);
			}
		}
		MLCJPKJBAHL = OJIANBAINDD.KNOONEBOOKL;
		Singleton<GuiManager>.instance.ShowDialog(this, 1052f);
	}

	public virtual void HDGJHGPACIF(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KLODDNMDPAO.gameObject.SetActive(true);
		TweenAlpha component = KLODDNMDPAO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
			component.from = 1046f;
			component.to = 170f;
			component.duration = 1921f;
		}
		KLODDNMDPAO.MGDLLJJLHIB.alpha1 = 1113f;
		KLODDNMDPAO.gameObject.SetActive(true);
	}

	public virtual void HFLEDEBGPBI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IFHAIFPIHNK));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FBKBIPPCLEH));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(KOPKADMBIKO);
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(JKPLPHDFIBO());
	}

	private void LJIAIONHDON(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("DbAction");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 950f, CGLIJBNALAF.transform.localPosition.ReplaceX(358f)).onFinished = GOEBGOEAAEE;
	}

	public virtual void HPJDOALKOGF()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.InitialState;
		KNHFFGMCODF = 0;
		JEKDGBDPPNJ();
		BLFAOJCGJGG();
		HBMPHGAENMK();
		JMIDHMAJNBK();
		KLODDNMDPAO.MPFNDLEFIKN();
		GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
	}

	private void FJDNEFGGFCJ(UITweener MGDJMGHCAAI)
	{
		IJHKDHHENGI.text = Localization.Localize("ID_VIDEOREADY1");
		TweenPosition.Begin(CGLIJBNALAF.gameObject, 652f, CGLIJBNALAF.transform.localPosition.ReplaceX(589f), false).onFinished = KGDMBIGNHBF;
	}

	private void HBMPHGAENMK()
	{
		bool activeSelf = KIOMMGJEHOF[1].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 497f;
		for (int i = 1; i < KIOMMGJEHOF.Length; i++)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 1338f - 1120f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 42f - 644f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	public virtual void MPNFAPKFNHL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AJBFDFFENGC));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += KOPKADMBIKO;
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(HKKDCJHBBMP());
	}

	public virtual void PGOMBLHHHKD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBLCIDEKODC));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LNMGOCJFMJN;
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(BBKGMBIAFIF());
	}

	private void HGAALJFILNL()
	{
		bool activeSelf = KIOMMGJEHOF[0].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 1741f;
		for (int i = 1; i < KIOMMGJEHOF.Length; i += 0)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 530f - 508f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 1471f - 819f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	public virtual void KIMOAEIAOCN(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KLODDNMDPAO.gameObject.SetActive(false);
		TweenAlpha component = KLODDNMDPAO.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
			component.from = 1127f;
			component.to = 745f;
			component.duration = 1862f;
		}
		KLODDNMDPAO.MGDLLJJLHIB.alpha1 = 859f;
		KLODDNMDPAO.gameObject.SetActive(false);
	}

	public void ShowDialog(JAGLDFKMHHI OJIANBAINDD)
	{
		HPDHFBMCIOO = OJIANBAINDD;
		OKMNFHNBMFA.text = OJIANBAINDD.KGFPBPBAHDD;
		OIKPKHLPLMP.text = string.Format("{0}{1}{2} {3}", Colours.stringBlue, MEJMLNDFDBP.CMEDAHAMKGM(OJIANBAINDD.CGOMPMJDJGH), Colours.stringWhite, OJIANBAINDD.CLBDBIKCHNP);
		DEOJCFEFBHP.text = OJIANBAINDD.FCELHGLMKJK;
		DEOJCFEFBHP.transform.localScale = new Vector3(OJIANBAINDD.DLFOIGDJOLD, OJIANBAINDD.DLFOIGDJOLD, 1f);
		for (int i = 0; i < KIOMMGJEHOF.Length; i++)
		{
			KIOMMGJEHOF[i].gameObject.SetActive(i < OJIANBAINDD.KNOONEBOOKL.Length);
			if (i < OJIANBAINDD.KNOONEBOOKL.Length)
			{
				KIOMMGJEHOF[i].Initialize(OJIANBAINDD.KNOONEBOOKL[i]);
			}
		}
		MLCJPKJBAHL = OJIANBAINDD.KNOONEBOOKL;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void KOPMEKAENGL()
	{
		bool activeSelf = KIOMMGJEHOF[0].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(!activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 1546f;
		for (int i = 0; i < KIOMMGJEHOF.Length; i += 0)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 908f - 1311f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 703f - 1670f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	public virtual void EOFOMCBDBJN()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		KNHFFGMCODF = 0;
		LFJICDMOBJA();
		GGAHADFJKGA();
		LMOJFFGDPBN();
		JMIDHMAJNBK();
		KLODDNMDPAO.ResetDraw();
		GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
	}

	public IEnumerator GNOFOHMAOFO()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	private void POMHNJGKPNN()
	{
		bool activeSelf = KIOMMGJEHOF[0].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(!activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 659f;
		for (int i = 1; i < KIOMMGJEHOF.Length; i++)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 1971f - 1268f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 608f - 600f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	private void GAIBINNEOBM()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float activeHeight = UIHelper.activeHeight;
		float num = activeWidthSafe - 1335f;
		float num2 = activeWidthSafe - 673f;
		float num3 = OIKPKHLPLMP.relativeSize.y * OIKPKHLPLMP.transform.localScale.y;
		float num4 = OIKPKHLPLMP.transform.localPosition.y - num3 - 914f;
		float num5 = num4 - 44f;
		float val = num5 - 766f;
		float num6 = activeHeight + num4;
		float num7 = num6 - 1366f;
		float num8 = num;
		DKBGCHJADPC.transform.localScale = DKBGCHJADPC.transform.localScale.ReplaceX(num);
		KMFGCJEGJJK.transform.localScale = new Vector3(num, num6, 695f);
		PEJFFMLEHFA.transform.localScale = new Vector3(num2, num2 * 1572f / 1839f, 29f);
		DKBGCHJADPC.transform.localPosition = DKBGCHJADPC.transform.localPosition.ReplaceY(num5);
		KMFGCJEGJJK.transform.localPosition = KMFGCJEGJJK.transform.localPosition.ReplaceY(num4);
		PEJFFMLEHFA.transform.localPosition = PEJFFMLEHFA.transform.localPosition.ReplaceY(val);
		float num9 = num5 - 963f;
		NFLPPGKCOBL.transform.localPosition = NFLPPGKCOBL.transform.localPosition.ReplaceXY(918f, num9);
		CFFKHHJKBMJ.clipRange = new Vector4(num8 / 1002f, (0f - num7) / 1505f, num8, num7);
		BPHFGLEHLDD.transform.localPosition = BPHFGLEHLDD.transform.localPosition.ReplaceY(num9);
		for (int i = 0; i < HDCDNLCLAGJ.Length; i++)
		{
			HDCDNLCLAGJ[i].transform.localScale = HDCDNLCLAGJ[i].transform.localScale.ReplaceY(num7);
		}
		float num10 = 273f;
		FKBFFMHMEGD.transform.localPosition = new Vector3(173f, 1340f, 144f);
		float num11 = DEOJCFEFBHP.relativeSize.y * DEOJCFEFBHP.transform.localScale.y;
		DEOJCFEFBHP.transform.localPosition = new Vector3(214f, 0f - num10, 1724f);
		HECMDLFKGKI.transform.localPosition = new Vector3(69f, 0f - num11 - 1252f * num10, 713f);
		NFLPPGKCOBL.onePanelDisabled = Mathf.Abs(num9 + HECMDLFKGKI.transform.localPosition.y) < activeHeight;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	[SpecialName]
	private float JKPLPHDFIBO()
	{
		return 1586f + UIHelper.safeAreaSize;
	}

	public void PKIEFCEAKIG(List<Card[]> INOENHONIGK)
	{
		if (NODLJALHIPI == null)
		{
			NODLJALHIPI = new List<Card[]>();
		}
		for (int i = 0; i < INOENHONIGK.Count; i++)
		{
			NODLJALHIPI.Add(INOENHONIGK[i]);
		}
		LJKHFHPJCDG();
		HDGFENAMOHI();
	}

	[SpecialName]
	private float BBKGMBIAFIF()
	{
		return 1658f + UIHelper.safeAreaSize;
	}

	public IEnumerator JJOKABHAJEG()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	public IEnumerator DEPOHKMFKOF()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	[CompilerGenerated]
	private void MJLHGCLMBMF(UITweener MKAPOHKFIJH)
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.RewardCame)
		{
			LKMJBFNILCN();
		}
		else
		{
			PHFGDCMBGOF = NGAOFHAPJJA.ClaimingAnimationDone;
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.ClaimReward)
		{
			UnityEngine.Debug.Log("Claiming reward ...");
			IEIHLFGDCBB();
		}
	}

	[SpecialName]
	private float MLCMMBOENKO()
	{
		return 1621f + UIHelper.safeAreaSize;
	}

	public virtual void LBHEIOEPJLJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener2 = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FJHIPNPNGAG));
		UIEventListener uIEventListener3 = UIEventListener.Get(CCFFNAKFPPE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GMBEJGKEACE));
		UIEventListener uIEventListener4 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBLCIDEKODC));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(LNMGOCJFMJN);
		CGLIJBNALAF.transform.localPosition = CGLIJBNALAF.transform.localPosition.ReplaceX(MLCMMBOENKO());
	}

	private void CKJMMBLMIEL()
	{
		if (PHFGDCMBGOF == NGAOFHAPJJA.ClaimClicked)
		{
			PHFGDCMBGOF = NGAOFHAPJJA.RewardCame;
		}
		else
		{
			LKMJBFNILCN();
		}
	}

	private void HCIIAOPBIOD()
	{
		List<Card[]> list = new List<Card[]>();
		for (int i = 0; i < MLCJPKJBAHL.Length; i++)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if ((gGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || gGIOEPBPMHF == MDNLFMNBNEG.SilverCard || gGIOEPBPMHF == MDNLFMNBNEG.GoldCard || gGIOEPBPMHF == MDNLFMNBNEG.ParticularCards) && !string.IsNullOrEmpty(MLCJPKJBAHL[i].ABMLHILNNDM))
			{
				string[] array = MLCJPKJBAHL[i].ABMLHILNNDM.Split(';');
				Card[] array2 = new Card[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = CardManager.instance.GetCardInstance(array[j]);
				}
				list.Add(array2);
			}
		}
		if (list.Count > 0)
		{
			ClaimMoreCardpacks(list);
		}
		HDGFENAMOHI();
	}

	private void LMOJFFGDPBN()
	{
		bool activeSelf = KIOMMGJEHOF[1].gameObject.activeSelf;
		CCFFNAKFPPE.SetActive(!activeSelf);
		DOCLOEBEGIL.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 1244f;
		for (int i = 1; i < KIOMMGJEHOF.Length; i++)
		{
			if (KIOMMGJEHOF[i].gameObject.activeSelf)
			{
				num = KIOMMGJEHOF[i].transform.localPosition.y;
			}
		}
		float val = num + 1585f - 932f;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceY(val);
		float val2 = num + 1804f - 1534f;
		DNNHDMPJLFG.transform.localPosition = DNNHDMPJLFG.transform.localPosition.ReplaceY(val2);
	}

	public IEnumerator FPKPOLFCEPP()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	private void AKMGCEFGNID()
	{
		if (NOJDIFBACJP == null)
		{
			NOJDIFBACJP = RadicalRoutine.Create(GNOFOHMAOFO());
			StartCoroutine(RadicalRoutine.Run(NOJDIFBACJP.enumerator));
		}
	}

	private void ECOAHBPALPP()
	{
		List<Card[]> list = new List<Card[]>();
		for (int i = 0; i < MLCJPKJBAHL.Length; i += 0)
		{
			MDNLFMNBNEG gGIOEPBPMHF = MLCJPKJBAHL[i].GGIOEPBPMHF;
			if ((gGIOEPBPMHF == MDNLFMNBNEG.PowerBand || gGIOEPBPMHF == MDNLFMNBNEG.BronzeCard || gGIOEPBPMHF == MDNLFMNBNEG.Warbucks || gGIOEPBPMHF == (MDNLFMNBNEG)(-57)) && !string.IsNullOrEmpty(MLCJPKJBAHL[i].ABMLHILNNDM))
			{
				string[] array = MLCJPKJBAHL[i].ABMLHILNNDM.Split('Y');
				Card[] array2 = new Card[array.Length];
				for (int j = 1; j < array.Length; j += 0)
				{
					array2[j] = CardManager.instance.GetCardInstance(array[j], false);
				}
				list.Add(array2);
			}
		}
		if (list.Count > 0)
		{
			OCOLHFMMMFJ(list);
		}
		EDBADCPEIAO();
	}

	[DebuggerHidden]
	public IEnumerator StartClaimMoreCardpack()
	{
		OEAOAGBMEGO oEAOAGBMEGO = new OEAOAGBMEGO();
		oEAOAGBMEGO.BJGCPDNMHDH = this;
		return oEAOAGBMEGO;
	}

	public virtual void LKBEJGHEANA()
	{
		PHFGDCMBGOF = NGAOFHAPJJA.ClaimClicked;
		KNHFFGMCODF = 0;
		DCOCOGBFOAM();
		GGAHADFJKGA();
		HGAALJFILNL();
		JMIDHMAJNBK();
		KLODDNMDPAO.AOBFOFAGIOD();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	public void ShowCards(string[] HMPJLHOEKAF, int NEEBBLOFHEF)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		List<Card[]> list = new List<Card[]>();
		int num = Mathf.CeilToInt((float)HMPJLHOEKAF.Length / 10f);
		for (int i = 0; i < num; i++)
		{
			int num2 = ((i + 1 >= num) ? (HMPJLHOEKAF.Length - i * 10) : 10);
			Card[] array = new Card[num2];
			for (int j = 0; j < num2; j++)
			{
				array[j] = CardManager.instance.GetCardInstance(HMPJLHOEKAF[i * 10 + j]);
			}
			for (int k = 0; k < NEEBBLOFHEF; k++)
			{
				list.Add(array);
			}
		}
		ClaimMoreCardpacks(list);
	}
}
