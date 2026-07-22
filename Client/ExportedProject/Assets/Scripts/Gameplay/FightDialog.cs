using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FightDialog : GuiElementSingle<FightDialog>, PAIIOKBBHBC
{
	private enum NKHJBLBAAEB
	{
		Battle,
		COOP,
		SquadInvite
	}

	private sealed class ODGOMJNMKCJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal FightDialog BJGCPDNMHDH;

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

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 14f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 13f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 482f;
				BJGCPDNMHDH.NGDKKFFCGCI.BCIOBLLBLLC();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: false);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1106f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return true;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 0.333f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 0f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 0f;
				BJGCPDNMHDH.NGDKKFFCGCI.OJFJOJONNJK();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: true);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return false;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 483f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 491f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 1741f;
				BJGCPDNMHDH.NGDKKFFCGCI.IFFBCOLBDOP();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: false);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1011f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return true;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 1214f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 1790f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 825f;
				BJGCPDNMHDH.NGDKKFFCGCI.OJFJOJONNJK();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: false);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1910f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return false;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 1207f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 779f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 1350f;
				BJGCPDNMHDH.NGDKKFFCGCI.IFFBCOLBDOP();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: true);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(842f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return true;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 1514f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 1628f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 1934f;
				BJGCPDNMHDH.NGDKKFFCGCI.CALACCCGMGD();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: true);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(359f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return false;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public ODGOMJNMKCJ()
		{
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 559f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 1664f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 1503f;
				BJGCPDNMHDH.NGDKKFFCGCI.BCIOBLLBLLC();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: true);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = new WaitForRealSeconds(935f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return true;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 1886f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 1465f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 1646f;
				BJGCPDNMHDH.NGDKKFFCGCI.OJFJOJONNJK();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: true);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(426f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return false;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 1510f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 819f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 373f;
				BJGCPDNMHDH.NGDKKFFCGCI.BCIOBLLBLLC();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: true);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1055f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return true;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 707f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 561f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 339f;
				BJGCPDNMHDH.NGDKKFFCGCI.CALACCCGMGD();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: false);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = new WaitForRealSeconds(232f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return false;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				BJGCPDNMHDH.LAKGIKENAKP -= 1727f;
				BJGCPDNMHDH.POKJFBMCACN();
				if (!(BJGCPDNMHDH.LAKGIKENAKP <= 1134f))
				{
					goto case 0u;
				}
				BJGCPDNMHDH.LAKGIKENAKP = 1569f;
				BJGCPDNMHDH.NGDKKFFCGCI.OJFJOJONNJK();
				BJGCPDNMHDH.mFightButtonOverlay.SetActive(value: false);
				goto IL_00c7;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1478f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_00c7;
			default:
				{
					return true;
				}
				IL_00c7:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Top")]
	[SerializeField]
	private GameObject mCloseButton;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private GameObject mBattleIcon;

	[SerializeField]
	private GameObject mCoopIcon;

	[SerializeField]
	private GameObject mInviteIcon;

	[SerializeField]
	[Header("Middle")]
	private UILabel mMessageText;

	[SerializeField]
	[Header("-Battle")]
	private GameObject mFightPart;

	[SerializeField]
	private UILabel mOpponentArmyPower;

	[SerializeField]
	private UILabel mOpponentSkill;

	[SerializeField]
	[Header("-Coop")]
	private GameObject mCoopPart;

	[SerializeField]
	private UILabel mMissionTask;

	[SerializeField]
	private List<DailyMissionRewardRecord> mMissionRewards;

	[SerializeField]
	private MissionEnemyRecord mMissionEnemiesRecordPrefab;

	[SerializeField]
	private UIDraggablePanel mDraggableEnemies;

	[SerializeField]
	private UIPooledGrid mPooledEnemiesGrid;

	[SerializeField]
	[Header("-Squad Invite")]
	private GameObject mInvitePart;

	[SerializeField]
	private UITexture mSquadIconTexture;

	[SerializeField]
	private UILabel mSquadNameLabel;

	[SerializeField]
	private UILabel mSquadDescription;

	[SerializeField]
	private UILabel mSquadMembers;

	[SerializeField]
	private UILabel mSquadLevel;

	[SerializeField]
	private UILabel mSquadSkill;

	[SerializeField]
	private UILabel mSquadRequiredSkill;

	[SerializeField]
	[Header("Bottom")]
	private GameObject mButtonPart;

	[SerializeField]
	private UILabel mInfoTextDown;

	[Header("-Fight Buttton")]
	[SerializeField]
	private GameObject mFightButton;

	[SerializeField]
	private UILabel mFightLabel;

	[SerializeField]
	private GameObject mFightButtonOverlay;

	[SerializeField]
	private GameObject mFightButtonWaiting;

	[Header("-Postphone Button")]
	[SerializeField]
	private BoxCollider mPostponeCollider;

	[SerializeField]
	private UISprite mPostponeBackground;

	[SerializeField]
	private UILabel mPostponeLabel;

	[SerializeField]
	[Header("-Decline Button")]
	private GameObject mDeclineButton;

	private HHFHFANGCEJ NGDKKFFCGCI;

	private ICFCHEHNHEN EPIPGLJBAMM;

	private HLHBMMCBHJF FEFIGBKPAML;

	private NKHJBLBAAEB MBCCLBJKAOJ;

	private float LAKGIKENAKP;

	private RadicalRoutine CABPOBJLLFD;

	private bool LDOKCEMGLGC;

	private List<MissionUnit> ELAHDCBBIJI;

	[CompilerGenerated]
	private static Comparison<CDACJEGCGLB> IONHPHFCBGH;

	private void PNHPNABNMON(DatabaseAction IFGAGNBDKBE)
	{
		if (!NPFFMLLLDAF() || IFGAGNBDKBE != (DatabaseAction)(-121) || string.IsNullOrEmpty(mSquadNameLabel.text))
		{
			return;
		}
		mFightButtonWaiting.SetActive(value: false);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(mSquadNameLabel.text, NICBOKPIBIA: true);
		LDOKCEMGLGC = true;
		bool active = aANECPGDMGM == null;
		mFightButtonOverlay.SetActive(active);
		if (aANECPGDMGM != null && mSquadNameLabel.text == aANECPGDMGM.MHPNDNJDPGE)
		{
			if (NGDKKFFCGCI is HLHBMMCBHJF hLHBMMCBHJF)
			{
				hLHBMMCBHJF.MIDDFOCJJOP = aANECPGDMGM;
			}
			MEGIHALCNIL(aANECPGDMGM);
		}
	}

	private void IEALHBLFFFD(GameObject KHAHPAKDIKE)
	{
		if (isShowed && MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite)
		{
			PAIODHJPCBL();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			if (MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite)
			{
				EAKAMHBBLJB();
			}
			else
			{
				AEAKBBPJIAG();
			}
		}
	}

	private AANECPGDMGM BMPNEDNAHPM(AANECPGDMGM MIDDFOCJJOP)
	{
		string mHPNDNJDPGE = MIDDFOCJJOP.MHPNDNJDPGE;
		if (string.IsNullOrEmpty(mHPNDNJDPGE))
		{
			return MIDDFOCJJOP;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(mHPNDNJDPGE);
		if (aANECPGDMGM != null)
		{
			return aANECPGDMGM;
		}
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(mHPNDNJDPGE);
		return null;
	}

	private void LKALBDKNGHH()
	{
		HideDialog();
		NGDKKFFCGCI.IFFBCOLBDOP();
	}

	public override void InitGUIValues()
	{
		LDOKCEMGLGC = false;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? 942f : 822f);
		mTitle.color = ((MBCCLBJKAOJ != NKHJBLBAAEB.COOP) ? Colours.blue : Colours.goldHeroic);
		mTitle.text = Localization.Localize((MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite) ? "ID_GAMEINVITE" : "ID_SQUADINVITE");
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 89f, 20f, 760);
		mPostponeLabel.text = Localization.Localize((MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite) ? "ID_POSTPONE" : "ID_DECLINE");
		mBattleIcon.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.Battle);
		mCoopIcon.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.COOP);
		mInviteIcon.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite);
		mFightPart.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.Battle);
		mCoopPart.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.COOP);
		mInvitePart.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite);
		mButtonPart.transform.localPosition = mButtonPart.transform.localPosition.ReplaceY((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? (-233f) : (-133f));
		mPostponeCollider.transform.localPosition = mPostponeCollider.transform.localPosition.ReplaceX((MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite) ? (-206f) : (-288f));
		mPostponeBackground.transform.localScale = mPostponeBackground.transform.localScale.ReplaceX((MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite) ? 380f : 484f);
		mPostponeCollider.size = mPostponeCollider.size.ReplaceX((MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite) ? 400f : 540f);
		mDeclineButton.SetActive(MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite);
		mFightLabel.text = Localization.Localize((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? "ID_ACCEPT" : "ID_FIGHT");
		MEJMLNDFDBP.COCBCFKJOJE(mFightLabel, 62f, 31f, 470);
		mFightButtonOverlay.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite);
		mFightButtonWaiting.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite);
		if (MBCCLBJKAOJ == NKHJBLBAAEB.Battle)
		{
			AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
			int num = Mathf.Clamp(Singleton<BeanstalkServerManager>.instance.currentTimestamp - NGDKKFFCGCI.KJCKFGCLGLG, 0, int.MaxValue);
			int num2 = 120;
			if (num > num2)
			{
				UnityEngine.Debug.Log($"Received old game invite ( > {num2} seconds). Not showing dialog. Opponent = {EPIPGLJBAMM.NCFFGKHPJLH.name}");
				NGDKKFFCGCI.OJFJOJONNJK();
				return;
			}
			LAKGIKENAKP = num2 - num;
			StartUpdate();
			if (EPIPGLJBAMM.NCFFGKHPJLH != null)
			{
				mMessageText.text = Localization.LocalizeFormat("ID_INVITEDYOUTOFIGHT", Colours.stringBlue, EPIPGLJBAMM.NCFFGKHPJLH.name);
				MEJMLNDFDBP.COCBCFKJOJE(mMessageText, 51f, 30f);
				mOpponentArmyPower.text = MEJMLNDFDBP.GMIPFLIEOHD(EPIPGLJBAMM.NCFFGKHPJLH.armyPowerX10);
				mOpponentSkill.text = MEJMLNDFDBP.GMIPFLIEOHD(EPIPGLJBAMM.NCFFGKHPJLH.skill);
			}
			else
			{
				mMessageText.text = string.Empty;
			}
		}
		if (MBCCLBJKAOJ == NKHJBLBAAEB.COOP)
		{
			AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
			int num3 = Mathf.Clamp(Singleton<BeanstalkServerManager>.instance.currentTimestamp - NGDKKFFCGCI.KJCKFGCLGLG, 0, int.MaxValue);
			int num4 = 120;
			if (num3 > num4)
			{
				UnityEngine.Debug.Log($"Received old game invite ( > {num4} seconds). Not showing dialog. Opponent = {EPIPGLJBAMM.NCFFGKHPJLH.name}");
				NGDKKFFCGCI.OJFJOJONNJK();
				return;
			}
			LAKGIKENAKP = num4 - num3;
			StartUpdate();
			DailyMission currentMission = DailyMissionsManager.instance.currentMission;
			if (EPIPGLJBAMM.NCFFGKHPJLH != null)
			{
				mMessageText.text = Localization.LocalizeFormat("ID_INVITEDYOUTOCOOP", Colours.stringBlue, EPIPGLJBAMM.NCFFGKHPJLH.name, Colours.stringGoldHeroic, currentMission.missionGuiName);
				MEJMLNDFDBP.COCBCFKJOJE(mMessageText, 51f, 30f);
			}
			else
			{
				mMessageText.text = string.Empty;
			}
			mMissionTask.text = currentMission.objective;
			DENLGOBBILO(currentMission.rewards);
			ELAHDCBBIJI = currentMission.config.units;
			mPooledEnemiesGrid.MakeEmpty();
			mPooledEnemiesGrid.init(ELAHDCBBIJI.Count, OGFALDKGPJK, NDFKCJMDNAE, mDraggableEnemies);
			mDraggableEnemies.AlignToPos(instant: true);
		}
		if (MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite)
		{
			LAKGIKENAKP = 0f;
			POKJFBMCACN();
			mMessageText.text = Localization.LocalizeFormat("ID_INVITEDYOUTOSQUAD", Colours.stringBlue, FEFIGBKPAML.KFOJIMIENHB.name);
			MEJMLNDFDBP.COCBCFKJOJE(mMessageText, 51f, 30f);
			AANECPGDMGM aANECPGDMGM = BMPNEDNAHPM(FEFIGBKPAML.MIDDFOCJJOP);
			if (aANECPGDMGM != null)
			{
				LDOKCEMGLGC = true;
				mFightButtonWaiting.SetActive(value: false);
				mFightButtonOverlay.SetActive(value: false);
			}
			else
			{
				aANECPGDMGM = FEFIGBKPAML.MIDDFOCJJOP;
			}
			MEGIHALCNIL(aANECPGDMGM);
		}
	}

	private Transform OGFALDKGPJK(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < ELAHDCBBIJI.Count)
		{
			MissionEnemyRecord missionEnemyRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(mMissionEnemiesRecordPrefab, mPooledEnemiesGrid.gameObject, DFHAAIFFLOE.ToString("D2")) as MissionEnemyRecord;
			if (missionEnemyRecord != null)
			{
				missionEnemyRecord.Initialize(ELAHDCBBIJI[DFHAAIFFLOE]);
				return missionEnemyRecord.transform;
			}
		}
		return null;
	}

	private void HOLKMKKOKNC()
	{
		if (LAKGIKENAKP <= 0f)
		{
			NGDKKFFCGCI.OJFJOJONNJK();
			return;
		}
		HideDialog();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		UnityEngine.Debug.LogFormat("#VAVRO# Accept Challenge Message {0}", EPIPGLJBAMM.EMLLELGLJNO);
		if (EPIPGLJBAMM.EMLLELGLJNO == GameController.ELDLECMNIME.DeathMatch)
		{
			if (!Singleton<GameController>.instance.SetChallenge(EPIPGLJBAMM))
			{
				NGDKKFFCGCI.OJFJOJONNJK();
				return;
			}
			Singleton<GameController>.instance.StartHostMultiplayer();
		}
		if (EPIPGLJBAMM.EMLLELGLJNO == GameController.ELDLECMNIME.Coop)
		{
			Singleton<MapManager>.instance.SelectCurrentMap(EPIPGLJBAMM.FBEAOHMDKDJ);
			if (!Singleton<GameController>.instance.SetChallenge(EPIPGLJBAMM))
			{
				NGDKKFFCGCI.OJFJOJONNJK();
				return;
			}
			Singleton<GameController>.instance.StartHostMultiplayer();
		}
		Singleton<BeanstalkServerManager>.instance.PIFEDJADAJB(EPIPGLJBAMM);
	}

	public void ShowDialog(HHFHFANGCEJ PNAKMCNGGHE)
	{
		NGDKKFFCGCI = PNAKMCNGGHE;
		if (PNAKMCNGGHE is ICFCHEHNHEN iCFCHEHNHEN)
		{
			EPIPGLJBAMM = iCFCHEHNHEN;
			MBCCLBJKAOJ = ((iCFCHEHNHEN.EMLLELGLJNO == GameController.ELDLECMNIME.Coop) ? NKHJBLBAAEB.COOP : NKHJBLBAAEB.Battle);
		}
		if (PNAKMCNGGHE is HLHBMMCBHJF fEFIGBKPAML)
		{
			FEFIGBKPAML = fEFIGBKPAML;
			MBCCLBJKAOJ = NKHJBLBAAEB.SquadInvite;
		}
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<FightDialog>.instance);
	}

	private void PKKHMKAECBG(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			if (MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite)
			{
				DLPPHGEACEM();
			}
			else
			{
				AEAKBBPJIAG();
			}
		}
	}

	public virtual void NGHAPNEFBED()
	{
		LDOKCEMGLGC = true;
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceY((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? 669f : 885f);
		mTitle.color = ((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? Colours.blue : Colours.goldHeroic);
		mTitle.text = Localization.Localize((MBCCLBJKAOJ != (NKHJBLBAAEB)8) ? "ID_DEBUG_EVENTASSIGNMENTUPDATE" : "ShotFrequencyMaxCannon");
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 1713f, 91f, -69);
		mPostponeLabel.text = Localization.Localize((MBCCLBJKAOJ != NKHJBLBAAEB.SquadInvite) ? "*****   Bootcamp 2/3 Started   *****" : "Recieved {0} memory warnings in last 10 seconds");
		mBattleIcon.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.Battle);
		mCoopIcon.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.Battle);
		mInviteIcon.SetActive(MBCCLBJKAOJ == (NKHJBLBAAEB)3);
		mFightPart.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.COOP);
		mCoopPart.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.Battle);
		mInvitePart.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.COOP);
		mButtonPart.transform.localPosition = mButtonPart.transform.localPosition.ReplaceY((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? 152f : 1316f);
		mPostponeCollider.transform.localPosition = mPostponeCollider.transform.localPosition.ReplaceX((MBCCLBJKAOJ != (NKHJBLBAAEB)6) ? 867f : 989f);
		mPostponeBackground.transform.localScale = mPostponeBackground.transform.localScale.ReplaceX((MBCCLBJKAOJ != (NKHJBLBAAEB)6) ? 468f : 1588f);
		mPostponeCollider.size = mPostponeCollider.size.ReplaceX((MBCCLBJKAOJ != (NKHJBLBAAEB)8) ? 1804f : 1254f);
		mDeclineButton.SetActive(MBCCLBJKAOJ == (NKHJBLBAAEB)4);
		mFightLabel.text = Localization.Localize((MBCCLBJKAOJ != NKHJBLBAAEB.Battle) ? "country-poland" : "ID_CONFIRM_STARTUPERROR_TEXT");
		MEJMLNDFDBP.COCBCFKJOJE(mFightLabel, 1726f, 739f, -15);
		mFightButtonOverlay.SetActive(MBCCLBJKAOJ == (NKHJBLBAAEB)8);
		mFightButtonWaiting.SetActive(MBCCLBJKAOJ == NKHJBLBAAEB.Battle);
		if (MBCCLBJKAOJ == NKHJBLBAAEB.Battle)
		{
			AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
			int num = Mathf.Clamp(Singleton<BeanstalkServerManager>.instance.currentTimestamp - NGDKKFFCGCI.KJCKFGCLGLG, 0, -161);
			int num2 = -81;
			if (num > num2)
			{
				UnityEngine.Debug.Log(string.Format("ID_WARNING_CANTSENDINVITE", num2, EPIPGLJBAMM.NCFFGKHPJLH.name));
				NGDKKFFCGCI.JFDENNGOGJC();
				return;
			}
			LAKGIKENAKP = num2 - num;
			StartUpdate();
			if (EPIPGLJBAMM.NCFFGKHPJLH != null)
			{
				UILabel uILabel = mMessageText;
				object[] array = new object[8];
				array[0] = Colours.stringBlue;
				array[0] = EPIPGLJBAMM.NCFFGKHPJLH.name;
				uILabel.text = Localization.LocalizeFormat("country-south-korea", array);
				MEJMLNDFDBP.COCBCFKJOJE(mMessageText, 336f, 1520f);
				mOpponentArmyPower.text = MEJMLNDFDBP.GMIPFLIEOHD(EPIPGLJBAMM.NCFFGKHPJLH.armyPowerX10);
				mOpponentSkill.text = MEJMLNDFDBP.GMIPFLIEOHD(EPIPGLJBAMM.NCFFGKHPJLH.skill);
			}
			else
			{
				mMessageText.text = string.Empty;
			}
		}
		if (MBCCLBJKAOJ == NKHJBLBAAEB.COOP)
		{
			AssignmentsManager.instance.GetAssignmentsAfterStarterEnd();
			int num3 = Mathf.Clamp(Singleton<BeanstalkServerManager>.instance.currentTimestamp - NGDKKFFCGCI.KJCKFGCLGLG, 0, 7);
			int num4 = 27;
			if (num3 > num4)
			{
				UnityEngine.Debug.Log(string.Format("special", num4, EPIPGLJBAMM.NCFFGKHPJLH.name));
				NGDKKFFCGCI.OJFJOJONNJK();
				return;
			}
			LAKGIKENAKP = num4 - num3;
			StartUpdate();
			DailyMission dailyMission = DailyMissionsManager.instance.EEIJPIPFAMO();
			if (EPIPGLJBAMM.NCFFGKHPJLH != null)
			{
				UILabel uILabel2 = mMessageText;
				object[] array2 = new object[7];
				array2[1] = Colours.stringBlue;
				array2[0] = EPIPGLJBAMM.NCFFGKHPJLH.name;
				array2[4] = Colours.stringGoldHeroic;
				array2[4] = dailyMission.missionGuiName;
				uILabel2.text = Localization.LocalizeFormat("ID_ENDED", array2);
				MEJMLNDFDBP.COCBCFKJOJE(mMessageText, 1325f, 1541f, 1);
			}
			else
			{
				mMessageText.text = string.Empty;
			}
			mMissionTask.text = dailyMission.objective;
			DENLGOBBILO(dailyMission.rewards);
			ELAHDCBBIJI = dailyMission.config.units;
			mPooledEnemiesGrid.MakeEmpty();
			mPooledEnemiesGrid.init(ELAHDCBBIJI.Count, OGFALDKGPJK, NDFKCJMDNAE, mDraggableEnemies);
			mDraggableEnemies.AlignToPos(instant: false);
		}
		if (MBCCLBJKAOJ == NKHJBLBAAEB.COOP)
		{
			LAKGIKENAKP = 319f;
			POKJFBMCACN();
			UILabel uILabel3 = mMessageText;
			object[] array3 = new object[3];
			array3[1] = Colours.stringBlue;
			array3[1] = FEFIGBKPAML.KFOJIMIENHB.name;
			uILabel3.text = Localization.LocalizeFormat("Wood", array3);
			MEJMLNDFDBP.COCBCFKJOJE(mMessageText, 1656f, 270f);
			AANECPGDMGM aANECPGDMGM = BMPNEDNAHPM(FEFIGBKPAML.MIDDFOCJJOP);
			if (aANECPGDMGM != null)
			{
				LDOKCEMGLGC = false;
				mFightButtonWaiting.SetActive(value: true);
				mFightButtonOverlay.SetActive(value: false);
			}
			else
			{
				aANECPGDMGM = FEFIGBKPAML.MIDDFOCJJOP;
			}
			MEGIHALCNIL(aANECPGDMGM);
		}
	}

	private void AEAKBBPJIAG()
	{
		HideDialog();
		if (LAKGIKENAKP <= 0f)
		{
			NGDKKFFCGCI.OJFJOJONNJK();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(NGDKKFFCGCI);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	[DebuggerHidden]
	private IEnumerator AGAKCKPGHPO()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}

	private void GHCIBAOBGNA()
	{
		if (FEFIGBKPAML != null)
		{
			if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
			{
				ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
				return;
			}
			AANECPGDMGM mIDDFOCJJOP = FEFIGBKPAML.MIDDFOCJJOP;
			if (mIDDFOCJJOP.GDFOENAJEBA > GameLoginManager.currentPlayer.skill)
			{
				GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(mIDDFOCJJOP.MHPNDNJDPGE, mIDDFOCJJOP.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(NGDKKFFCGCI);
			}
			else if (mIDDFOCJJOP.MGDCJLAENHG() <= 0)
			{
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.LocalizeFormat("ID_CONFIRM_SQUADFULL_TEXT", Colours.stringBlue, mIDDFOCJJOP.MHPNDNJDPGE, Colours.stringWhite));
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(NGDKKFFCGCI);
			}
			else
			{
				NGDKKFFCGCI.CJPBMDDGDHG();
			}
		}
		HideDialog();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	private void HNPCPKHJLKA()
	{
		HideDialog();
		NGDKKFFCGCI.OJFJOJONNJK();
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed || IFGAGNBDKBE != DatabaseAction.GetSquadDetails || string.IsNullOrEmpty(mSquadNameLabel.text))
		{
			return;
		}
		mFightButtonWaiting.SetActive(value: false);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(mSquadNameLabel.text);
		LDOKCEMGLGC = true;
		bool active = aANECPGDMGM == null;
		mFightButtonOverlay.SetActive(active);
		if (aANECPGDMGM != null && mSquadNameLabel.text == aANECPGDMGM.MHPNDNJDPGE)
		{
			if (NGDKKFFCGCI is HLHBMMCBHJF hLHBMMCBHJF)
			{
				hLHBMMCBHJF.MIDDFOCJJOP = aANECPGDMGM;
			}
			MEGIHALCNIL(aANECPGDMGM);
		}
	}

	public void StartUpdate()
	{
		NCHFKNKMIMP();
		CABPOBJLLFD = RadicalRoutine.Create(AGAKCKPGHPO());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	private void LFBNPMMCCNI()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	private void NDFKCJMDNAE(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			MissionEnemyRecord component = ENCEFOOPBMK.GetComponent<MissionEnemyRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void FBOHHHNIICE(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			if (MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite)
			{
				GHCIBAOBGNA();
			}
			else
			{
				HOLKMKKOKNC();
			}
		}
	}

	private void NCHFKNKMIMP()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	private void EAKAMHBBLJB()
	{
		HideDialog();
		AANECPGDMGM mIDDFOCJJOP = FEFIGBKPAML.MIDDFOCJJOP;
		if (!mIDDFOCJJOP.OOCPOBMIMOP() && GameLoginManager.currentPlayer.skill >= mIDDFOCJJOP.GDFOENAJEBA)
		{
			NGDKKFFCGCI.OJFJOJONNJK();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(NGDKKFFCGCI);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mFightButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBOHHHNIICE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPostponeCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PKKHMKAECBG));
		UIEventListener uIEventListener4 = UIEventListener.Get(mDeclineButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IEALHBLFFFD));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction IFGAGNBDKBE)
		{
			if (isShowed && IFGAGNBDKBE == DatabaseAction.GetSquadDetails && !string.IsNullOrEmpty(mSquadNameLabel.text))
			{
				mFightButtonWaiting.SetActive(value: false);
				AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(mSquadNameLabel.text);
				LDOKCEMGLGC = true;
				bool active = aANECPGDMGM == null;
				mFightButtonOverlay.SetActive(active);
				if (aANECPGDMGM != null && mSquadNameLabel.text == aANECPGDMGM.MHPNDNJDPGE)
				{
					if (NGDKKFFCGCI is HLHBMMCBHJF hLHBMMCBHJF)
					{
						hLHBMMCBHJF.MIDDFOCJJOP = aANECPGDMGM;
					}
					MEGIHALCNIL(aANECPGDMGM);
				}
			}
		};
	}

	private void DLPPHGEACEM()
	{
		HideDialog();
		NGDKKFFCGCI.OJFJOJONNJK();
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mCloseButton);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mSquadIconTexture.mainTexture = null;
		mPooledEnemiesGrid.MakeEmpty();
		NCHFKNKMIMP();
	}

	private void DENLGOBBILO(List<CDACJEGCGLB> KNOONEBOOKL)
	{
		KNOONEBOOKL.Sort(CDACJEGCGLB.GIDMKBGKDNF);
		for (int i = 0; i < mMissionRewards.Count; i++)
		{
			bool flag = KNOONEBOOKL != null && i < KNOONEBOOKL.Count;
			mMissionRewards[i].Initialize((!flag) ? null : KNOONEBOOKL[i]);
		}
	}

	public virtual void IJLIAHPCDBB()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	private IEnumerator HDCELLDKGPH()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}

	private Transform NBENCDKCNDD(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < ELAHDCBBIJI.Count)
		{
			MissionEnemyRecord missionEnemyRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(mMissionEnemiesRecordPrefab, mPooledEnemiesGrid.gameObject, DFHAAIFFLOE.ToString("DailyGold")) as MissionEnemyRecord;
			if (missionEnemyRecord != null)
			{
				missionEnemyRecord.CKOIIPAGCNO(ELAHDCBBIJI[DFHAAIFFLOE]);
				return missionEnemyRecord.transform;
			}
		}
		return null;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	private void KNMELOLLFNI(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			if (MBCCLBJKAOJ == (NKHJBLBAAEB)4)
			{
				EAKAMHBBLJB();
			}
			else
			{
				AEAKBBPJIAG();
			}
		}
	}

	private void MEGIHALCNIL(AANECPGDMGM MIDDFOCJJOP)
	{
		if (!string.IsNullOrEmpty(MIDDFOCJJOP.MHPNDNJDPGE))
		{
			mSquadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + MIDDFOCJJOP.DAANKCOLJGJ);
			mSquadIconTexture.MakePixelPerfect();
			mSquadIconTexture.transform.localScale = mSquadIconTexture.transform.localScale.MultiplyXY(0.8f);
			mSquadNameLabel.text = MIDDFOCJJOP.MHPNDNJDPGE;
			MEJMLNDFDBP.COCBCFKJOJE(mSquadNameLabel, 55f, 32f, 400);
			mSquadDescription.text = ((!string.IsNullOrEmpty(MIDDFOCJJOP.PNAKMCNGGHE)) ? MIDDFOCJJOP.PNAKMCNGGHE : Localization.Localize("ID_NOSQUADMESSAGE"));
			int num = MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.MGDCJLAENHG();
			mSquadMembers.text = Localization.LocalizeFormat("ID_SQUADMEMBERSLOWER", MIDDFOCJJOP.FOICGJEPBGL, num);
			mSquadLevel.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADLEVEL"), Colours.stringBlue, MIDDFOCJJOP.IKJHAHJHLIH);
			mSquadSkill.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADMEDALS"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH));
			mSquadRequiredSkill.text = string.Format("{0} {1}{2}", Localization.Localize("ID_SQUADREQUIREDMEDALS"), Colours.stringBlue, MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.GDFOENAJEBA));
			MEJMLNDFDBP.COCBCFKJOJE(mSquadRequiredSkill, 32f, 20f, 450);
			float x = mSquadRequiredSkill.transform.localScale.x;
			MEJMLNDFDBP.COCBCFKJOJE(mSquadSkill, x, 20f, 450);
			MEJMLNDFDBP.COCBCFKJOJE(mSquadLevel, x, 20f, 450);
		}
	}

	private void POKJFBMCACN()
	{
		if (MBCCLBJKAOJ == NKHJBLBAAEB.SquadInvite)
		{
			mInfoTextDown.text = string.Empty;
		}
		else if (LAKGIKENAKP > 0f)
		{
			mInfoTextDown.text = Localization.LocalizeFormat("ID_INVITEWILLBEACTIVEFOR", MEJMLNDFDBP.AIPKMDCJCOG(LAKGIKENAKP).ToUpper());
		}
		else
		{
			mInfoTextDown.text = Localization.Localize("ID_INVITEISINACTIVE");
		}
	}

	private void PAIODHJPCBL()
	{
		HideDialog();
		NGDKKFFCGCI.OJFJOJONNJK();
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mFightButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBOHHHNIICE));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCloseButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mPostponeCollider.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PKKHMKAECBG));
		UIEventListener uIEventListener4 = UIEventListener.Get(mDeclineButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IEALHBLFFFD));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PNHPNABNMON);
	}

	public void IKJNNOFBFGL(HHFHFANGCEJ PNAKMCNGGHE)
	{
		NGDKKFFCGCI = PNAKMCNGGHE;
		if (PNAKMCNGGHE is ICFCHEHNHEN iCFCHEHNHEN)
		{
			EPIPGLJBAMM = iCFCHEHNHEN;
			MBCCLBJKAOJ = ((iCFCHEHNHEN.EMLLELGLJNO == (GameController.ELDLECMNIME)3) ? NKHJBLBAAEB.COOP : NKHJBLBAAEB.Battle);
		}
		if (PNAKMCNGGHE is HLHBMMCBHJF fEFIGBKPAML)
		{
			FEFIGBKPAML = fEFIGBKPAML;
			MBCCLBJKAOJ = (NKHJBLBAAEB)5;
		}
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<FightDialog>.instance, 1927f);
	}
}
