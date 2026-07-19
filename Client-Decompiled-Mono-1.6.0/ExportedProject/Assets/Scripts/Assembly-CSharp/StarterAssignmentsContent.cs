using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StarterAssignmentsContent : Core_BaseScript
{
	private sealed class ODGOMJNMKCJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool MCCIMJCBOMK;

		internal StarterAssignmentsContent BJGCPDNMHDH;

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

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("equals");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("game-card-ico-mineyourstep-full");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("ShootStand");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Special pack content: type: {0} amount: {1}{2}");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("ID_ARENARULES_BATTLES", MEJMLNDFDBP.CJCFPDLDMEK(num, "isUserInSegmentId", string.Empty), Colours.stringWhite, Localization.Localize("NULL WARCARD"));
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("getSessionId", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_JOININGSQUAD", string.Empty, false));
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(231f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("()Lcom/google/android/gms/common/api/Status;");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("InstantBattleUnlockedMessage");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 1);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("+{0}");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("Different number of guiOrder {0} and items in pack {1}", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CATEGORY_LOW_SG_SNIPER", string.Empty), Colours.stringWhite, Localization.Localize("Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}."));
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_UNIT2UPGRADE_UNIT1UPGRADE", MEJMLNDFDBP.CJCFPDLDMEK(num, "N", string.Empty));
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1924f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHFEOEIHFDC()
		{
			return PHDOCKCBJOF;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("GLM: OnDataLoaded - configurations.  is tutorial? ");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Card_2_Played");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("S");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("ReportedPlayerId", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CATEGORY_LOW_SG_LMG", string.Empty, false), Colours.stringWhite, Localization.Localize("{0} {1}"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, " MAX COUNT: ", string.Empty, false);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_CARDS", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(308f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("Area");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("percent");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 1);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("Loading - cancel clicked, will to try call disconnect");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Squad");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("unregisterConnectionCallbacks", MEJMLNDFDBP.CJCFPDLDMEK(num, "GB", string.Empty, false), Colours.stringWhite, Localization.Localize("View_Completed"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "shield_shot", string.Empty, false);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("SpecialOfferDiscountAdd", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(345f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("NO any UIRoot - failed ");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("HEAVYTURRET");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("ArmyPower");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("#AccoutCheck# Switching to GC account");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("ID_TUTORIAL_UPGRADEWEAPON_8", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_SQUADREWARDGET", string.Empty, false), Colours.stringWhite, Localization.Localize("Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} rotatedLookVector: {5}"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "PromotedPlayer", string.Empty);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("[.,']*", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(229f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_READYTIME");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("{0} {1}");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("{0} {1}");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("ID_SALEPERCENTLINE", MEJMLNDFDBP.CJCFPDLDMEK(num, "clipSize", string.Empty), Colours.stringWhite, Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT2"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "SquadMessages", string.Empty);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_CONFIRM_SQUADLEAVEERROR", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1915f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("bot-");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("VipReward1");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("DogTagRefillTime");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("{0}:\t{1} = {2}\tfiles: {3}\n");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("AddedCards", MEJMLNDFDBP.CJCFPDLDMEK(num, "trial", string.Empty), Colours.stringWhite, Localization.Localize("squadPointsOffer"));
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("Metal", MEJMLNDFDBP.CJCFPDLDMEK(num, "DogtagRefill", string.Empty));
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1123f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGMPMBFDAAC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("Player_Avoided_Grenade_On_First_Try");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("pass");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 1);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("\"{0}\"\t");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("+");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("PayWithTickets", MEJMLNDFDBP.CJCFPDLDMEK(num, "game-card-ico-crateblocker", string.Empty, false), Colours.stringWhite, Localization.Localize("1"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[1];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "Shots_Hits", string.Empty, false);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("menu-arena-winico", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1055f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("Sniper_Tutorial_Duration");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("JoinNowSquadMessage-{0}");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 1);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("false");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("special");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("#AccoutCheck# start waiting to be in menu or in game", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CONFIRM_PURCHASEFAILED", string.Empty, false), Colours.stringWhite, Localization.Localize("ID_STAT_MOSTBATTLESPLAYED"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[1];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "GameGold", string.Empty);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden.", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(955f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_CATEGORY_SHOTGUN");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("JoinMatch_ServerConnect");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("Error Handler: Player si vybral zruseni GC uctu a pridani udaju k tomuto uctu");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("setPluginName");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("ID_UNLOCKEDATRANK", MEJMLNDFDBP.CJCFPDLDMEK(num, "response= ", string.Empty, false), Colours.stringWhite, Localization.Localize("com/google/android/gms/games/Games"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "Manual_Unit_Spawn", string.Empty);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("Turret", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1160f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
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

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("_TranslucencyColor");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ChillingoSdkManager");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("menu-hub-multiplayer-vipico");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Regions");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("Password", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_WARSHOP_MEMBERSHIP", string.Empty), Colours.stringWhite, Localization.Localize("ID_FEATURE_MAGAZINE"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "MissionType", string.Empty);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat(" OK!", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1902f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGDBAJJAHNO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFCIACEHFHE()
		{
			return PHDOCKCBJOF;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("Password");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Lcom/google/android/gms/games/Players;");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 1);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("ID_NOTINLEAGUEMOREMATCHESTEXT");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("0");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("There is no definition for card {0}", MEJMLNDFDBP.CJCFPDLDMEK(num, "Card_3_Played", string.Empty), Colours.stringWhite, Localization.Localize("ID_SECONDS"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[1];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "data saved in DB for unit {0} : {1}", string.Empty, false);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("elite", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1496f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_YOURREWARDS");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("ID_EXPIRED");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("{0} {1}{2}", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_COMPLETEALLTENSTARTERASSIGNMENTS", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty));
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("http://");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("This notification record cannot be click while in Lobby screen");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("Arena Lost - Scraps received = ");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_WARNING_CANNOTINVITE");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("bronze", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_STATE_SEARCHINGFOROPPONENT", string.Empty), Colours.stringWhite, Localization.Localize("Is Title Text Font Bold"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_EXTRAWARCARDSLOT", string.Empty, false);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_YOUNEEDMONEYTODELIVERSPECIAL", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(499f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("\n");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("WarFriends nécessite la permission d’accéder à ton espace de stockage afin de télécharger des données de jeu critiques.Accepte la permission suivante, nous n’utiliserons jamais cette permission pour autre chose.");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("percent");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("tc");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("SEND LOGS", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_JUSTXMORERANKUPS", string.Empty, false), Colours.stringWhite, Localization.Localize("ID_GUI_EMBLEMUNLOCKED"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_REMINDER_VIPALMOSTEXPIRED", string.Empty);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("ArenaId", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1912f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize(", diff = ");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Buy_Weapon_At_Rank");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("Army_Unit_ID");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize(" AND ");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("ID_ZEROSECONDS", MEJMLNDFDBP.CJCFPDLDMEK(num, "49a0434f", string.Empty), Colours.stringWhite, Localization.Localize("Show Waiting Dialog "));
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("about", MEJMLNDFDBP.CJCFPDLDMEK(num, "ArenaFinished", string.Empty));
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(402f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("Helicopter");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("GrenadeExplodeDamage");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("ID_YOUNEEDTOEQUIPWEAPON");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_SECONDS");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("medals", MEJMLNDFDBP.CJCFPDLDMEK(num, "IsLocal", string.Empty, false), Colours.stringWhite, Localization.Localize("onPowerHooksChanged"));
						UILabel mRewardsTimeToEndLabel = BJGCPDNMHDH.mRewardsTimeToEndLabel;
						object[] array = new object[0];
						array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "sniper", string.Empty, false);
						mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("_MatCap", array);
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.isShowed && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(897f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			case 1u:
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					BJGCPDNMHDH.mTimeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_CATEGORY_LOW_SG_PRIMARY");
					BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT");
				}
				else
				{
					int num = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
					if (num == 0)
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = Localization.Localize("{0} {1}");
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.Localize("Army_Unit_ID");
					}
					else
					{
						BJGCPDNMHDH.mTimeToCompleteLabel.text = string.Format("resultMessage", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_PROLONGYOURVIP", string.Empty, false), Colours.stringWhite, Localization.Localize("getGameData"));
						BJGCPDNMHDH.mRewardsTimeToEndLabel.text = Localization.LocalizeFormat("offerMult", MEJMLNDFDBP.CJCFPDLDMEK(num, "Directory \"{0}\" does not exists", string.Empty));
					}
				}
				MCCIMJCBOMK = StarterAssignmentsManager.instance.isActive;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_017c:
				if (GuiElementSingle<AssignmentsDialog>.instance.NPFFMLLLDAF() && MCCIMJCBOMK)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(845f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public ODGOMJNMKCJ()
		{
		}
	}

	[SerializeField]
	[Header("Completition")]
	private UILabel mTimeToCompleteLabel;

	[SerializeField]
	private StarterAssignmentComplete[] mCompletedAssignments;

	[Header("Current Assignment")]
	[SerializeField]
	private StarterAssignmentRecord mCurrentAssignmentRecord;

	[Header("Rewards")]
	[SerializeField]
	private UILabel mRewardsTimeToEndLabel;

	[SerializeField]
	private UITexture mRewardsWeaponTexture;

	[SerializeField]
	[Header("Bottom")]
	private GameObject mOkButton;

	private RadicalRoutine CABPOBJLLFD;

	private void KOLIIIADNOK()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	private void EJDOPCGEIMC()
	{
		mRewardsWeaponTexture.transform.localScale = Vector3.one;
		mRewardsWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GAIGOIIFIIP();
		resourceLoaderTexture2D.FreeAsset("+0");
	}

	private void EHIHJEGNNEG()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	public void DFMCKHMFNHO()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < mCompletedAssignments.Length; i += 0)
		{
			if (i < num)
			{
				mCompletedAssignments[i].NDOGEMKFGPA();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].PAHAGJBMPAG();
			}
			else
			{
				mCompletedAssignments[i].SetDefault();
			}
		}
		mCurrentAssignmentRecord.Initialize(currentAssignment);
		AOGNNJLPLON();
		JAIGBLOCNON();
	}

	private void NKACHLHLHLH()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D texture2D = weapons.LoadAsset("menu-weapon-mp5-elite");
		if (texture2D != null)
		{
			mRewardsWeaponTexture.gameObject.SetActive(true);
			mRewardsWeaponTexture.mainTexture = texture2D;
			mRewardsWeaponTexture.MakePixelPerfect();
			mRewardsWeaponTexture.transform.localScale = mRewardsWeaponTexture.transform.localScale.MultiplyXY(0.617f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			mRewardsWeaponTexture.transform.localScale = Vector3.one;
			mRewardsWeaponTexture.gameObject.SetActive(false);
		}
	}

	private void OAFHEJCMCBC()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("09");
		if (texture2D != null)
		{
			mRewardsWeaponTexture.gameObject.SetActive(true);
			mRewardsWeaponTexture.mainTexture = texture2D;
			mRewardsWeaponTexture.MakePixelPerfect();
			mRewardsWeaponTexture.transform.localScale = mRewardsWeaponTexture.transform.localScale.MultiplyXY(730f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
		}
		else
		{
			mRewardsWeaponTexture.transform.localScale = Vector3.one;
			mRewardsWeaponTexture.gameObject.SetActive(true);
		}
	}

	private void CPFHEAHGDKL()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		mCompletedAssignments[num - 0].AnimateFinish();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			mCompletedAssignments[num].CKDEAHJFAKI();
		}
	}

	private void ADLGKBKMGLO()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_FEATURE_MAGAZINE-DESCRIPTION");
		if (texture2D != null)
		{
			mRewardsWeaponTexture.gameObject.SetActive(true);
			mRewardsWeaponTexture.mainTexture = texture2D;
			mRewardsWeaponTexture.MakePixelPerfect();
			mRewardsWeaponTexture.transform.localScale = mRewardsWeaponTexture.transform.localScale.MultiplyXY(1863f * Singleton<GuiTexureAssets>.instance.CBCEFDMDNMK());
		}
		else
		{
			mRewardsWeaponTexture.transform.localScale = Vector3.one;
			mRewardsWeaponTexture.gameObject.SetActive(false);
		}
	}

	private void HADMMGGFBBL()
	{
		NCHFKNKMIMP();
		CABPOBJLLFD = RadicalRoutine.Create(AGAKCKPGHPO());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	public void MOKAPOJLCPJ()
	{
		JFKFEAIHOJG();
		EJDOPCGEIMC();
	}

	private void LJLMMBMEOKN()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		mCompletedAssignments[num - 0].CEMGOIJFABJ();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			mCompletedAssignments[num].AANJFCIHNHF();
		}
	}

	public void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.GHANNHGHEIP));
		mCurrentAssignmentRecord.KNOKOJKOCEB(1325f);
		StarterAssignmentsManager.instance.AssignmentClaimed += LJLMMBMEOKN;
	}

	private void NJBLKEHGKJF()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	public void DoAfterHide()
	{
		NCHFKNKMIMP();
		NMIADNEAAFB();
	}

	private void JFKFEAIHOJG()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	private void IMFBAIKEPBA()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		mCompletedAssignments[num - 0].CEMGOIJFABJ();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			mCompletedAssignments[num].CEGBPBCEGNF();
		}
	}

	private void NMIADNEAAFB()
	{
		mRewardsWeaponTexture.transform.localScale = Vector3.one;
		mRewardsWeaponTexture.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset("menu-weapon-mp5-elite");
	}

	public void KPMLFMMINEP()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < mCompletedAssignments.Length; i += 0)
		{
			if (i < num)
			{
				mCompletedAssignments[i].IMNJFBLKCHA();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].JKHMLLFNLLF();
			}
			else
			{
				mCompletedAssignments[i].JCLODKAJIGK();
			}
		}
		mCurrentAssignmentRecord.HBDEPMJNLEK(currentAssignment);
		NKACHLHLHLH();
		JBNABMBBBLC();
	}

	private IEnumerator AIFIJFAABIL()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}

	public void LFJGHLNJPHL()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < mCompletedAssignments.Length; i++)
		{
			if (i < num)
			{
				mCompletedAssignments[i].CDCFJDCDFEI();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].MOJLGBAOPEE();
			}
			else
			{
				mCompletedAssignments[i].KILICFGAKGA();
			}
		}
		mCurrentAssignmentRecord.Initialize(currentAssignment);
		NKACHLHLHLH();
		JBNABMBBBLC();
	}

	public void JCGPELEDCJL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.LMINDENMDEH));
		mCurrentAssignmentRecord.KNOKOJKOCEB(1257f);
		StarterAssignmentsManager.instance.AssignmentClaimed += MIKABHDEDFP;
	}

	private void FAGNLFCHHEL()
	{
		BDDEBKGNDEH();
		CABPOBJLLFD = RadicalRoutine.Create(AIFIJFAABIL());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	private void JAIGBLOCNON()
	{
		EHIHJEGNNEG();
		CABPOBJLLFD = RadicalRoutine.Create(BPNBNBBOFPM());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	private IEnumerator JBBPIMEOCPC()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}

	public void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.KEAAAMPGPGD));
		mCurrentAssignmentRecord.InitControls(432f);
		StarterAssignmentsManager.instance.AssignmentClaimed += IMFBAIKEPBA;
	}

	private void NCHFKNKMIMP()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	public void InitGUIValues()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < mCompletedAssignments.Length; i++)
		{
			if (i < num)
			{
				mCompletedAssignments[i].SetCompleted();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].SetCurrent();
			}
			else
			{
				mCompletedAssignments[i].SetDefault();
			}
		}
		mCurrentAssignmentRecord.Initialize(currentAssignment);
		NKACHLHLHLH();
		HADMMGGFBBL();
	}

	public void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.GHANNHGHEIP));
		mCurrentAssignmentRecord.KNOKOJKOCEB(1723f);
		StarterAssignmentsManager.instance.AssignmentClaimed += GKDPPGMNNEM;
	}

	private void FLLPLHKCDMP()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		mCompletedAssignments[num - 1].CEMGOIJFABJ();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			mCompletedAssignments[num].JIFIFBJANHO();
		}
	}

	public void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.DJOCGHINNJA));
		mCurrentAssignmentRecord.InitControls(636f);
		StarterAssignmentsManager.instance.AssignmentClaimed += CPFHEAHGDKL;
	}

	private void KDPCPNAGPEN()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_ARENASHORTCUTPHASESTART");
		if (texture2D != null)
		{
			mRewardsWeaponTexture.gameObject.SetActive(false);
			mRewardsWeaponTexture.mainTexture = texture2D;
			mRewardsWeaponTexture.MakePixelPerfect();
			mRewardsWeaponTexture.transform.localScale = mRewardsWeaponTexture.transform.localScale.MultiplyXY(1531f * Singleton<GuiTexureAssets>.instance.NNOEPDDIFBA());
		}
		else
		{
			mRewardsWeaponTexture.transform.localScale = Vector3.one;
			mRewardsWeaponTexture.gameObject.SetActive(true);
		}
	}

	private void AOGNNJLPLON()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("registerCustomProfileNumber");
		if (texture2D != null)
		{
			mRewardsWeaponTexture.gameObject.SetActive(false);
			mRewardsWeaponTexture.mainTexture = texture2D;
			mRewardsWeaponTexture.MakePixelPerfect();
			mRewardsWeaponTexture.transform.localScale = mRewardsWeaponTexture.transform.localScale.MultiplyXY(524f * Singleton<GuiTexureAssets>.instance.MMPHJJIMJPI());
		}
		else
		{
			mRewardsWeaponTexture.transform.localScale = Vector3.one;
			mRewardsWeaponTexture.gameObject.SetActive(true);
		}
	}

	private void BDDEBKGNDEH()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	private void PNBDOHHFBEA()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("NO");
		if (texture2D != null)
		{
			mRewardsWeaponTexture.gameObject.SetActive(false);
			mRewardsWeaponTexture.mainTexture = texture2D;
			mRewardsWeaponTexture.MakePixelPerfect();
			mRewardsWeaponTexture.transform.localScale = mRewardsWeaponTexture.transform.localScale.MultiplyXY(1458f * Singleton<GuiTexureAssets>.instance.MMPHJJIMJPI());
		}
		else
		{
			mRewardsWeaponTexture.transform.localScale = Vector3.one;
			mRewardsWeaponTexture.gameObject.SetActive(true);
		}
	}

	public void LMNNNHJKMFP()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < mCompletedAssignments.Length; i++)
		{
			if (i < num)
			{
				mCompletedAssignments[i].DPILIMGLILA();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].JKHMLLFNLLF();
			}
			else
			{
				mCompletedAssignments[i].LGEEEMLFPDG();
			}
		}
		mCurrentAssignmentRecord.HBDEPMJNLEK(currentAssignment);
		ADLGKBKMGLO();
		HADMMGGFBBL();
	}

	private void JBNABMBBBLC()
	{
		NCHFKNKMIMP();
		CABPOBJLLFD = RadicalRoutine.Create(AGAKCKPGHPO());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	public void ACFDANMKHNG()
	{
		JFKFEAIHOJG();
		EJDOPCGEIMC();
	}

	public void MOPAOJFCOGP()
	{
		JFKFEAIHOJG();
		EJDOPCGEIMC();
	}

	private void MIKABHDEDFP()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		mCompletedAssignments[num - 1].AnimateFinish();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			mCompletedAssignments[num].IFOBOBCBAKA();
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.OkClick));
		mCurrentAssignmentRecord.InitControls(1868f);
		StarterAssignmentsManager.instance.AssignmentClaimed += GKDPPGMNNEM;
	}

	[DebuggerHidden]
	private IEnumerator AGAKCKPGHPO()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}

	public void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.GHANNHGHEIP));
		mCurrentAssignmentRecord.InitControls(841f);
		StarterAssignmentsManager.instance.AssignmentClaimed += FLLPLHKCDMP;
	}

	private void GKDPPGMNNEM()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		mCompletedAssignments[num - 1].AnimateFinish();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			mCompletedAssignments[num].AnimateProgress();
		}
	}

	public void BKNJHLKMFKE()
	{
		JFKFEAIHOJG();
		EJDOPCGEIMC();
	}

	public void AMBDHDEBPJJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mOkButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GuiElementSingle<AssignmentsDialog>.instance.HIDMHMCLEOP));
		mCurrentAssignmentRecord.KNOKOJKOCEB(953f);
		StarterAssignmentsManager.instance.AssignmentClaimed += MIKABHDEDFP;
	}

	public void NAHMANAGNNO()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 1; i < mCompletedAssignments.Length; i += 0)
		{
			if (i < num)
			{
				mCompletedAssignments[i].MOCGNLIPGKL();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].MOJLGBAOPEE();
			}
			else
			{
				mCompletedAssignments[i].CHCPBJOHPDE();
			}
		}
		mCurrentAssignmentRecord.Initialize(currentAssignment);
		ADLGKBKMGLO();
		JAIGBLOCNON();
	}

	public void PAHEFBCOENP()
	{
		StarterAssignmentsManager.instance.Evaluate();
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < mCompletedAssignments.Length; i++)
		{
			if (i < num)
			{
				mCompletedAssignments[i].SetCompleted();
			}
			else if (i == num)
			{
				mCompletedAssignments[i].PAHAGJBMPAG();
			}
			else
			{
				mCompletedAssignments[i].OFGIFCNMMCL();
			}
		}
		mCurrentAssignmentRecord.Initialize(currentAssignment);
		NKACHLHLHLH();
		JAIGBLOCNON();
	}

	private IEnumerator GLHFAMMCGCD()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}

	public void CHAGJLIDGAH()
	{
		NCHFKNKMIMP();
		NMIADNEAAFB();
	}

	private IEnumerator BPNBNBBOFPM()
	{
		ODGOMJNMKCJ oDGOMJNMKCJ = new ODGOMJNMKCJ();
		oDGOMJNMKCJ.BJGCPDNMHDH = this;
		return oDGOMJNMKCJ;
	}
}
