using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BattlePreparationUnitButton : Core_BaseScript
{
	private sealed class ONJIDIHGCOD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal BattlePreparationUnitButton BJGCPDNMHDH;

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
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public ONJIDIHGCOD()
		{
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.remainingDeliveringSeconds > 0.0)
				{
					BJGCPDNMHDH.NIGPNJJFFBE.fillAmount = BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.progressDelivering;
					BJGCPDNMHDH.NIGPNJJFFBE.color = Colours.cyan;
					BJGCPDNMHDH.JLFECPABDFE((int)BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NIGPNJJFFBE.fillAmount = 1f;
				BJGCPDNMHDH.NIGPNJJFFBE.color = Colours.blue;
				BJGCPDNMHDH.HGJJFHLADJL.text = ((BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivered) ? Localization.Localize((!BJGCPDNMHDH.HADEKFGCDFA.isSoldier) ? "ID_UPGRADED" : "ID_TRAINED") : Localization.Localize("ID_PURCHASED"));
				BJGCPDNMHDH.HGJJFHLADJL.alpha = 1f;
				TweenAlpha.Begin(BJGCPDNMHDH.HGJJFHLADJL.gameObject, 0.01f, 1f);
				BJGCPDNMHDH.ICLDIMHHEJB(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
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

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.remainingDeliveringSeconds > 1544.0)
				{
					BJGCPDNMHDH.NIGPNJJFFBE.fillAmount = BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.progressDelivering;
					BJGCPDNMHDH.NIGPNJJFFBE.color = Colours.cyan;
					BJGCPDNMHDH.JCCOPBLMNLI((int)BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(357f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NIGPNJJFFBE.fillAmount = 687f;
				BJGCPDNMHDH.NIGPNJJFFBE.color = Colours.blue;
				BJGCPDNMHDH.HGJJFHLADJL.text = ((BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering) ? Localization.Localize((!BJGCPDNMHDH.HADEKFGCDFA.isSoldier) ? "cn" : "kr") : Localization.Localize(";"));
				BJGCPDNMHDH.HGJJFHLADJL.alpha = 1412f;
				TweenAlpha.Begin(BJGCPDNMHDH.HGJJFHLADJL.gameObject, 797f, 1831f);
				BJGCPDNMHDH.MCKLIMELCMO(Singleton<NotificationManager>.instance.DFHMKDCOLLB());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.remainingDeliveringSeconds > 422.0)
				{
					BJGCPDNMHDH.NIGPNJJFFBE.fillAmount = BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.progressDelivering;
					BJGCPDNMHDH.NIGPNJJFFBE.color = Colours.cyan;
					BJGCPDNMHDH.BNMBMFDBNHB((int)BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1064f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NIGPNJJFFBE.fillAmount = 220f;
				BJGCPDNMHDH.NIGPNJJFFBE.color = Colours.blue;
				BJGCPDNMHDH.HGJJFHLADJL.text = ((BJGCPDNMHDH.HADEKFGCDFA.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)8) ? Localization.Localize((!BJGCPDNMHDH.HADEKFGCDFA.isSoldier) ? "PA: number of sessions" : "Mission_Type") : Localization.Localize("FireNetworkRPC"));
				BJGCPDNMHDH.HGJJFHLADJL.alpha = 121f;
				TweenAlpha.Begin(BJGCPDNMHDH.HGJJFHLADJL.gameObject, 1530f, 438f);
				BJGCPDNMHDH.LPBECLGCHLE(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Core")]
	[FormerlySerializedAs("JKIOBKKKHOP")]
	public GameObject JANFGHJMGBI;

	[FormerlySerializedAs("GHACCDKBOBF")]
	public UISprite NACGOGCPIAH;

	[Header("-Sale Part")]
	[FormerlySerializedAs("DOAGPPICKPL")]
	public GameObject CODKHFGLFOB;

	[FormerlySerializedAs("LIDBJCJLGMJ")]
	public UILabel EFHDAKGAEBO;

	[FormerlySerializedAs("FNLFNHMMCFJ")]
	public UISprite BPNDNBJEPDE;

	[FormerlySerializedAs("BLLLKJHOFBP")]
	public WinStreakCounter PHOIGIBILNH;

	[FormerlySerializedAs("NPGBIACPNEP")]
	[Header("-New Unlock")]
	public GameObject NHAJIPFPKEH;

	[FormerlySerializedAs("CPAFCPLNBHA")]
	public UITable MJKBDGIILHI;

	[FormerlySerializedAs("INBDGDBBFEO")]
	public UILabel MCGOMCDNABF;

	[FormerlySerializedAs("HIFPMMMMKFH")]
	public UISprite EOEEJONJAIM;

	[FormerlySerializedAs("BFDAHNDFCKO")]
	public UILabel EGGAAGOFBHD;

	[FormerlySerializedAs("OAAPDEEAIMA")]
	[Header("-Delivering Part")]
	public GameObject KOEOHMJILHJ;

	[FormerlySerializedAs("mFirstProgressUnit")]
	public UISprite NIGPNJJFFBE;

	[FormerlySerializedAs("mFirstProgressLabel")]
	public UILabel HGJJFHLADJL;

	[FormerlySerializedAs("mSecondProgressLabel")]
	[Header("-Notification")]
	public UILabel BCLNCPMAOFI;

	[FormerlySerializedAs("mSuperChargedPart")]
	public GameObject BFHHLAFEPOB;

	private RadicalRoutine OCPKACMOHMO;

	private int HIKOOOPJEJC;

	private LevelBehaviour HADEKFGCDFA;

	private bool OIKEDCIECLC;

	private bool OAMFKBINMFE;

	private bool HLIMAKAKFPL;

	private bool PFMCHDDLKEO;

	private bool DGKJFGMHFBN;

	private bool HJPBFGEGGIC;

	private bool CNEALPMNPGM;

	private bool CGIMFGLJIPA;

	[CompilerGenerated]
	private static UIEventListener.VoidDelegate LGJCBPOPCPA;

	private void JNFFJFDBGBB()
	{
		OIKEDCIECLC = true;
		OAMFKBINMFE = true;
		HLIMAKAKFPL = true;
		PFMCHDDLKEO = false;
		DGKJFGMHFBN = false;
		HJPBFGEGGIC = true;
		CNEALPMNPGM = true;
		CGIMFGLJIPA = false;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				OAMFKBINMFE |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				PFMCHDDLKEO |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				HJPBFGEGGIC |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				CGIMFGLJIPA |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	public void LNLFJOIENED()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.CILJBKFLNPB();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)7);
		int num5 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)4, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)4, (AKDLEDNDIEO)7);
		int num7 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)5, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)6, (AKDLEDNDIEO)4);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Both);
		bool flag = num > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
		bool flag2 = num2 > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		NCNEMOHLAON();
		bool flag3 = num3 > 1 && OIKEDCIECLC;
		bool flag4 = num4 <= 0 || OAMFKBINMFE;
		bool flag5 = num5 > 0 && HLIMAKAKFPL;
		bool flag6 = num6 <= 1 || PFMCHDDLKEO;
		bool flag7 = num7 <= 0 || DGKJFGMHFBN;
		bool flag8 = num8 <= 0 || HJPBFGEGGIC;
		bool flag9 = num9 <= 1 || CNEALPMNPGM;
		bool flag10 = num10 <= 0 || CGIMFGLJIPA;
		bool flag11 = num3 > 0 && num5 > 1 && num7 > 1 && num9 > 1;
		bool flag12 = num4 <= 0 || num6 <= 0 || num8 <= 0 || num10 > 1;
		bool flag13 = !flag11 || OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM;
		bool flag14 = !flag12 || (!OAMFKBINMFE && !PFMCHDDLKEO && !HJPBFGEGGIC && CGIMFGLJIPA);
		bool flag15 = !flag13 && (flag3 || flag5 || flag7 || flag9);
		bool flag16 = !flag14 && !flag4 && !flag6 && !flag8 && flag10;
		CODKHFGLFOB.SetActive(flag || flag2 || flag13 || flag14 || flag15 || flag16);
		if (flag13 || flag14)
		{
			UILabel eFHDAKGAEBO = EFHDAKGAEBO;
			object[] array = new object[0];
			array[0] = ((!flag13) ? num4 : num3);
			eFHDAKGAEBO.text = Localization.LocalizeFormat("ID_RECRUITUNITTOARMYTOPROMOTE", array);
			PHOIGIBILNH.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(SaleUnits));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(620f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.JCMHGOGNMFO();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(LOOEOBHHLLO));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[0];
				array2[0] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("Buy_Unit", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag5 || flag6)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[0];
				array3[0] = ((!flag5) ? num6 : num5);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
				object[] array4 = new object[0];
				array4[1] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO4.text = Localization.LocalizeFormat("LastAction", array4);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)4].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1248f);
					return;
				}
				UILabel eFHDAKGAEBO5 = EFHDAKGAEBO;
				object[] array5 = new object[1];
				array5[1] = ((!flag9) ? num10 : num9);
				eFHDAKGAEBO5.text = Localization.LocalizeFormat("Assignment error: Skillshots not defined", array5);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 212f);
		}
		else if (flag || flag2)
		{
			UILabel eFHDAKGAEBO6 = EFHDAKGAEBO;
			object[] array6 = new object[0];
			array6[1] = ((!flag) ? num2 : num);
			eFHDAKGAEBO6.text = Localization.LocalizeFormat("Yes_Clicked", array6);
			PHOIGIBILNH.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(SaleUnits));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(186f);
		}
		else
		{
			PHOIGIBILNH.LOINIDOGNCO();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(BPJBPPEKBKF));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1402f);
		}
	}

	public void LOOEOBHHLLO()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.DiscountedUnitOffer();
		int num3 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)0);
		int num4 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)5);
		int num5 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)4, (AKDLEDNDIEO)6);
		int num7 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)6);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Both);
		bool flag = num <= 1 || !(levelBehaviour != null) || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 <= 1 || !(levelBehaviour != null) || !levelBehaviour.upgradeSlots.bought || levelBehaviour.upgradeSlots.canBeUpgraded;
		DIEANEHCMMB();
		bool flag3 = num3 <= 1 || OIKEDCIECLC;
		bool flag4 = num4 > 1 && OAMFKBINMFE;
		bool flag5 = num5 <= 0 || HLIMAKAKFPL;
		bool flag6 = num6 <= 0 || PFMCHDDLKEO;
		bool flag7 = num7 > 0 && DGKJFGMHFBN;
		bool flag8 = num8 <= 1 || HJPBFGEGGIC;
		bool flag9 = num9 <= 0 || CNEALPMNPGM;
		bool flag10 = num10 > 0 && CGIMFGLJIPA;
		bool flag11 = num3 > 0 && num5 > 0 && num7 > 1 && num9 > 0;
		bool flag12 = num4 <= 0 || num6 <= 1 || num8 <= 1 || num10 > 0;
		bool flag13 = !flag11 || (!OIKEDCIECLC && !HLIMAKAKFPL && !DGKJFGMHFBN && CNEALPMNPGM);
		bool flag14 = !flag12 || (!OAMFKBINMFE && !PFMCHDDLKEO && !HJPBFGEGGIC && CGIMFGLJIPA);
		bool flag15 = !flag13 && !flag3 && !flag5 && !flag7 && flag9;
		bool flag16 = !flag14 && !flag4 && !flag6 && !flag8 && flag10;
		CODKHFGLFOB.SetActive(!flag && !flag2 && !flag13 && !flag14 && !flag15 && flag16);
		if (flag13 || flag14)
		{
			UILabel eFHDAKGAEBO = EFHDAKGAEBO;
			object[] array = new object[1];
			array[1] = ((!flag13) ? num4 : num3);
			eFHDAKGAEBO.text = Localization.LocalizeFormat("Vip", array);
			PHOIGIBILNH.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(JKCDFAAHLDE));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1732f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.LOINIDOGNCO();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(PEJGINIFLND));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[0];
				array2[0] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("ID_GUI_ALLCARDS", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			else if (flag5 || flag6)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("-", (!flag5) ? num6 : num5);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)6].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[0];
				array3[1] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat(" mSpriteName:", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)7].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1087f);
					return;
				}
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SQUADWAREND", (!flag9) ? num10 : num9);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 1428f);
		}
		else if (flag || flag2)
		{
			UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
			object[] array4 = new object[1];
			array4[1] = ((!flag) ? num2 : num);
			eFHDAKGAEBO4.text = Localization.LocalizeFormat("WALLET - initialization WB {0}", array4);
			PHOIGIBILNH.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(MIICHIJNFKJ));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(DMIGHFGKEMO));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1927f);
		}
		else
		{
			PHOIGIBILNH.GGKCMHOGFPF();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(971f);
		}
	}

	private void NCNEMOHLAON()
	{
		OIKEDCIECLC = true;
		OAMFKBINMFE = false;
		HLIMAKAKFPL = true;
		PFMCHDDLKEO = true;
		DGKJFGMHFBN = true;
		HJPBFGEGGIC = true;
		CNEALPMNPGM = true;
		CGIMFGLJIPA = true;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				OAMFKBINMFE |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				PFMCHDDLKEO |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				HJPBFGEGGIC |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				CGIMFGLJIPA |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	public void BNFANHCCPHO()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.CILJBKFLNPB();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Upgrade);
		int num5 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)7, (AKDLEDNDIEO)6);
		int num7 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)8, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerRusher, (AKDLEDNDIEO)0);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)6);
		bool flag = num <= 1 || !(levelBehaviour != null) || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
		bool flag2 = num2 > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		LJPABKAGJAF();
		bool flag3 = num3 <= 0 || OIKEDCIECLC;
		bool flag4 = num4 <= 0 || OAMFKBINMFE;
		bool flag5 = num5 <= 1 || HLIMAKAKFPL;
		bool flag6 = num6 > 1 && PFMCHDDLKEO;
		bool flag7 = num7 <= 1 || DGKJFGMHFBN;
		bool flag8 = num8 > 0 && HJPBFGEGGIC;
		bool flag9 = num9 <= 0 || CNEALPMNPGM;
		bool flag10 = num10 <= 0 || CGIMFGLJIPA;
		bool flag11 = num3 <= 0 || num5 <= 1 || num7 <= 0 || num9 > 0;
		bool flag12 = num4 > 1 && num6 > 0 && num8 > 1 && num10 > 1;
		bool flag13 = flag11 && (OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM);
		bool flag14 = !flag12 || OAMFKBINMFE || PFMCHDDLKEO || HJPBFGEGGIC || CGIMFGLJIPA;
		bool flag15 = !flag13 && !flag3 && !flag5 && !flag7 && flag9;
		bool flag16 = flag14 || (!flag4 && !flag6 && !flag8 && flag10);
		CODKHFGLFOB.SetActive(flag || flag2 || flag13 || flag14 || flag15 || flag16);
		if (flag13 || flag14)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("beginnersLeague", (!flag13) ? num4 : num3);
			PHOIGIBILNH.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(JKCDFAAHLDE));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(BPJBPPEKBKF));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1743f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.PEHBGMEHFEM();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(LOOEOBHHLLO));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO = EFHDAKGAEBO;
				object[] array = new object[0];
				array[0] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO.text = Localization.LocalizeFormat("UpdateEngineerBuildingIndicator", array);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag5 || flag6)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SKILLSHOTHINT_REVENGEKILL", (!flag5) ? num6 : num5);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerShooter].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[0];
				array2[1] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("getIAPOfferInfoForZoneID", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)7].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1532f);
					return;
				}
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[1];
				array3[1] = ((!flag9) ? num10 : num9);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("ID_ENDED", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 1344f);
		}
		else if (flag || flag2)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("WarBucks", (!flag) ? num2 : num);
			PHOIGIBILNH.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(LOOEOBHHLLO));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1556f);
		}
		else
		{
			PHOIGIBILNH.FCGPLOBEHDL();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(BPJBPPEKBKF));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(742f);
		}
	}

	public void KDDJHIMDKBN()
	{
		NFKJIGIOOLO();
		ICLDIMHHEJB(Singleton<NotificationManager>.instance.DFHMKDCOLLB());
	}

	public void EGGGBCANMJB()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: false);
		MICLDOPLAPN(1);
	}

	public void OPEIFLGEBFI()
	{
		JDEJMFKEICM();
		LPBECLGCHLE(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
	}

	private static void MDMDKBDCKOJ(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
	}

	public void JAIAMFJHDLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		});
		MJKBDGIILHI.onReposition = NDPCBACFLDH;
	}

	private IEnumerator CAJMJDLEMLK()
	{
		ONJIDIHGCOD oNJIDIHGCOD = new ONJIDIHGCOD();
		oNJIDIHGCOD.BJGCPDNMHDH = this;
		return oNJIDIHGCOD;
	}

	private void FKNEELOPFAF()
	{
		AGAPLFPNCDN();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: true);
			KOEOHMJILHJ.SetActive(value: true);
			GGPBPONCMLD(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				HIKOOOPJEJC = 0;
				NIGPNJJFFBE.fillAmount = 506f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering) ? Localization.Localize((!levelBehaviour.isSoldier) ? "{0}{1}" : "QUIT") : Localization.Localize("Medals/"));
				HGJJFHLADJL.alpha = 1043f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 967f, 193f);
			}
			else
			{
				HIKOOOPJEJC = 198;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				BNDEDBKKAKH((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				HADEKFGCDFA = levelBehaviour;
				FKIFBBPBLKA();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.IJKKPMNLNNJ();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				GGPBPONCMLD(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 980f, 127f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 34);
				float val = 1587f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: false);
				LMJEOCDNBGF(levelBehaviour);
			}
		}
	}

	public void MLAEGNJBKIM()
	{
		CIFGFKBFJEG();
	}

	private void GGENBIPPPBO()
	{
		MFCFOFKLOON();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: true);
			KOEOHMJILHJ.SetActive(value: false);
			OFCKBMPOCNL(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
			{
				HIKOOOPJEJC = 0;
				NIGPNJJFFBE.fillAmount = 880f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.NotBuyed) ? Localization.Localize((!levelBehaviour.isSoldier) ? "{0} {1}" : "country-argentinia") : Localization.Localize("DogTagLastUpdate"));
				HGJJFHLADJL.alpha = 294f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 954f, 599f);
			}
			else
			{
				HIKOOOPJEJC = 125;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				BNMBMFDBNHB((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds);
				HADEKFGCDFA = levelBehaviour;
				BKDHFIAMICO();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.FALLMNNHFCE();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: true);
				LMJEOCDNBGF(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 1644f, 984f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - -111);
				float val = 1562f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: true);
				SetUpUnitLook(levelBehaviour);
			}
		}
	}

	private void MNCLJOLFCPJ()
	{
		CIFGFKBFJEG();
		OCPKACMOHMO = RadicalRoutine.Create(GPGLDAGBGAF());
		StartCoroutine(RadicalRoutine.Run(OCPKACMOHMO.enumerator));
	}

	public void LKOPOIMAOCD()
	{
		NHAJIPFPKEH.SetActive(value: true);
		KOEOHMJILHJ.SetActive(value: true);
		LPBECLGCHLE(0);
	}

	[CompilerGenerated]
	private static void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
	}

	private void MDDKDHCDLDJ(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (HIKOOOPJEJC > EJEDANLAMBI)
		{
			HIKOOOPJEJC = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.CFJGOIAIKGB(EJEDANLAMBI, ref HGJJFHLADJL, PDPDGCNHCFN);
		}
	}

	private IEnumerator GPGLDAGBGAF()
	{
		ONJIDIHGCOD oNJIDIHGCOD = new ONJIDIHGCOD();
		oNJIDIHGCOD.BJGCPDNMHDH = this;
		return oNJIDIHGCOD;
	}

	public void LMJEOCDNBGF(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1435f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	private void FEOFEPCHMMD()
	{
		OIKEDCIECLC = true;
		OAMFKBINMFE = false;
		HLIMAKAKFPL = true;
		PFMCHDDLKEO = true;
		DGKJFGMHFBN = true;
		HJPBFGEGGIC = true;
		CNEALPMNPGM = true;
		CGIMFGLJIPA = true;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				OAMFKBINMFE |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				PFMCHDDLKEO |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				HJPBFGEGGIC |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				CGIMFGLJIPA |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	private void OBDIFAIELID(int IDLMJLCFMJG)
	{
		BFHHLAFEPOB.SetActive(IDLMJLCFMJG > 1);
		BCLNCPMAOFI.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void GGPBPONCMLD(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1398f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	private void IBCFLDBAKAK()
	{
		OIKEDCIECLC = true;
		OAMFKBINMFE = false;
		HLIMAKAKFPL = false;
		PFMCHDDLKEO = false;
		DGKJFGMHFBN = true;
		HJPBFGEGGIC = true;
		CNEALPMNPGM = false;
		CGIMFGLJIPA = false;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				OAMFKBINMFE |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				PFMCHDDLKEO |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				HJPBFGEGGIC |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				CGIMFGLJIPA |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	private void ICLDIMHHEJB(int IDLMJLCFMJG)
	{
		BFHHLAFEPOB.SetActive(IDLMJLCFMJG > 0);
		BCLNCPMAOFI.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 2f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	private void BJNIGJDEMGD()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 480f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	private void MCKLIMELCMO(int IDLMJLCFMJG)
	{
		BFHHLAFEPOB.SetActive(IDLMJLCFMJG > 1);
		BCLNCPMAOFI.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void InitGUIValues()
	{
		HDAOAKDNNGA();
		ICLDIMHHEJB(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
	}

	public void CCDGDEANNKA()
	{
		MFCFOFKLOON();
	}

	private void HMILJDPDHDG()
	{
		AGAPLFPNCDN();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: true);
			SetUpUnitLook(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 344f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering) ? Localization.Localize((!levelBehaviour.isSoldier) ? "AdminPlayerId" : "Swipe Raycasts End FAILED!") : Localization.Localize("ID_GUI_YAISN_HEADER"));
				HGJJFHLADJL.alpha = 1067f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 996f, 1210f);
			}
			else
			{
				HIKOOOPJEJC = 90;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				BNMBMFDBNHB((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds);
				HADEKFGCDFA = levelBehaviour;
				BKDHFIAMICO();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.FALLMNNHFCE();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				LMJEOCDNBGF(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 646f, 482f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 38);
				float val = 534f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: true);
				SetUpUnitLook(levelBehaviour);
			}
		}
	}

	private void BNDEDBKKAKH(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (HIKOOOPJEJC > EJEDANLAMBI)
		{
			HIKOOOPJEJC = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref HGJJFHLADJL, PDPDGCNHCFN);
		}
	}

	private void EEBLDNHFCNF()
	{
		AGAPLFPNCDN();
		OCPKACMOHMO = RadicalRoutine.Create(FJFCLAOAJLI());
		StartCoroutine(RadicalRoutine.Run(OCPKACMOHMO.enumerator));
	}

	private void CIFGFKBFJEG()
	{
		if (OCPKACMOHMO != null)
		{
			OCPKACMOHMO.Cancel();
			OCPKACMOHMO = null;
		}
	}

	private void LJPABKAGJAF()
	{
		OIKEDCIECLC = false;
		OAMFKBINMFE = false;
		HLIMAKAKFPL = false;
		PFMCHDDLKEO = false;
		DGKJFGMHFBN = true;
		HJPBFGEGGIC = true;
		CNEALPMNPGM = true;
		CGIMFGLJIPA = true;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				OAMFKBINMFE |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				PFMCHDDLKEO |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				HJPBFGEGGIC |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				CGIMFGLJIPA |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	private void MICLDOPLAPN(int IDLMJLCFMJG)
	{
		BFHHLAFEPOB.SetActive(IDLMJLCFMJG > 1);
		BCLNCPMAOFI.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void BPADNOGBBPG()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 1386f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	public void BPJBPPEKBKF()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.LDEHPBBIPPI();
		int num3 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)8);
		int num5 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)7, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)5, (AKDLEDNDIEO)4);
		int num7 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)8, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)8, (AKDLEDNDIEO)8);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)6);
		bool flag = num > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
		bool flag2 = num2 > 1 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		JHOLOGHIJMN();
		bool flag3 = num3 > 0 && OIKEDCIECLC;
		bool flag4 = num4 <= 1 || OAMFKBINMFE;
		bool flag5 = num5 <= 0 || HLIMAKAKFPL;
		bool flag6 = num6 <= 1 || PFMCHDDLKEO;
		bool flag7 = num7 > 1 && DGKJFGMHFBN;
		bool flag8 = num8 <= 0 || HJPBFGEGGIC;
		bool flag9 = num9 <= 0 || CNEALPMNPGM;
		bool flag10 = num10 > 0 && CGIMFGLJIPA;
		bool flag11 = num3 <= 1 || num5 <= 1 || num7 <= 1 || num9 > 1;
		bool flag12 = num4 > 0 && num6 > 1 && num8 > 0 && num10 > 0;
		bool flag13 = !flag11 || OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM;
		bool flag14 = flag12 && (OAMFKBINMFE || PFMCHDDLKEO || HJPBFGEGGIC || CGIMFGLJIPA);
		bool flag15 = flag13 || flag3 || flag5 || flag7 || flag9;
		bool flag16 = !flag14 && !flag4 && !flag6 && !flag8 && flag10;
		CODKHFGLFOB.SetActive(flag || flag2 || flag13 || flag14 || flag15 || flag16);
		if (flag13 || flag14)
		{
			UILabel eFHDAKGAEBO = EFHDAKGAEBO;
			object[] array = new object[0];
			array[0] = ((!flag13) ? num4 : num3);
			eFHDAKGAEBO.text = Localization.LocalizeFormat("Wrong_Weapon", array);
			PHOIGIBILNH.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(MIICHIJNFKJ));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1158f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.LOINIDOGNCO();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(LNLFJOIENED));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[1];
				array2[1] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("Locale", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag5 || flag6)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[0];
				array3[1] = ((!flag5) ? num6 : num5);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("bazooka_shoot_left", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			else if (flag7 || flag8)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat(" DEPOSIT {0}\n", (!flag7) ? num8 : num7);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerShooter].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(520f);
					return;
				}
				UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
				object[] array4 = new object[1];
				array4[1] = ((!flag9) ? num10 : num9);
				eFHDAKGAEBO4.text = Localization.LocalizeFormat("Scraps", array4);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 1349f);
		}
		else if (flag || flag2)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("bronze3", (!flag) ? num2 : num);
			PHOIGIBILNH.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(MIICHIJNFKJ));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(BNFANHCCPHO));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(41f);
		}
		else
		{
			PHOIGIBILNH.LOINIDOGNCO();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1168f);
		}
	}

	private void BKDHFIAMICO()
	{
		CIFGFKBFJEG();
		OCPKACMOHMO = RadicalRoutine.Create(EGDHOCIBGLB());
		StartCoroutine(RadicalRoutine.Run(OCPKACMOHMO.enumerator));
	}

	private IEnumerator EGDHOCIBGLB()
	{
		ONJIDIHGCOD oNJIDIHGCOD = new ONJIDIHGCOD();
		oNJIDIHGCOD.BJGCPDNMHDH = this;
		return oNJIDIHGCOD;
	}

	private void GHMINFINIPM()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 307f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	public void SaleUnits()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.DiscountedUnitOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Upgrade);
		int num5 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerRusher, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerRusher, AKDLEDNDIEO.Upgrade);
		int num7 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerShooter, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerShooter, AKDLEDNDIEO.Upgrade);
		int num9 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Upgrade);
		bool flag = num > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 > 0 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		DIEANEHCMMB();
		bool flag3 = num3 > 0 && OIKEDCIECLC;
		bool flag4 = num4 > 0 && OAMFKBINMFE;
		bool flag5 = num5 > 0 && HLIMAKAKFPL;
		bool flag6 = num6 > 0 && PFMCHDDLKEO;
		bool flag7 = num7 > 0 && DGKJFGMHFBN;
		bool flag8 = num8 > 0 && HJPBFGEGGIC;
		bool flag9 = num9 > 0 && CNEALPMNPGM;
		bool flag10 = num10 > 0 && CGIMFGLJIPA;
		bool flag11 = num3 > 0 && num5 > 0 && num7 > 0 && num9 > 0;
		bool flag12 = num4 > 0 && num6 > 0 && num8 > 0 && num10 > 0;
		bool flag13 = flag11 && (OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM);
		bool flag14 = flag12 && (OAMFKBINMFE || PFMCHDDLKEO || HJPBFGEGGIC || CGIMFGLJIPA);
		bool flag15 = !flag13 && (flag3 || flag5 || flag7 || flag9);
		bool flag16 = !flag14 && (flag4 || flag6 || flag8 || flag10);
		CODKHFGLFOB.SetActive(flag || flag2 || flag13 || flag14 || flag15 || flag16);
		if (flag13 || flag14)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag13) ? num4 : num3);
			PHOIGIBILNH.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(SaleUnits));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(130f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.JCMHGOGNMFO();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(SaleUnits));
			if (flag3 || flag4)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag3) ? num4 : num3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			else if (flag5 || flag6)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag5) ? num6 : num5);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerRusher].Value1);
			}
			else if (flag7 || flag8)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag7) ? num8 : num7);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerShooter].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(130f);
					return;
				}
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag9) ? num10 : num9);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 40f);
		}
		else if (flag || flag2)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag) ? num2 : num);
			PHOIGIBILNH.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(SaleUnits));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(130f);
		}
		else
		{
			PHOIGIBILNH.JCMHGOGNMFO();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(130f);
		}
	}

	private void JLFECPABDFE(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (HIKOOOPJEJC > EJEDANLAMBI)
		{
			HIKOOOPJEJC = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref HGJJFHLADJL, PDPDGCNHCFN);
		}
	}

	private void PMDKHAEODLL()
	{
		if (OCPKACMOHMO != null)
		{
			OCPKACMOHMO.Cancel();
			OCPKACMOHMO = null;
		}
	}

	public void SetUpUnitLook(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1.25f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	private void NFKJIGIOOLO()
	{
		PMDKHAEODLL();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: true);
			KOEOHMJILHJ.SetActive(value: false);
			SetUpUnitLook(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 1059f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.NotBuyed) ? Localization.Localize((!levelBehaviour.isSoldier) ? "Scraps:   {0}\n" : "Managers") : Localization.Localize("'fakeOffername'0"));
				HGJJFHLADJL.alpha = 1032f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 1472f, 503f);
			}
			else
			{
				HIKOOOPJEJC = 88;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				JCCOPBLMNLI((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				HADEKFGCDFA = levelBehaviour;
				EEBLDNHFCNF();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.CEMJLIPJOOJ();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: false);
				GNENMFGIKBE(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 1399f, 634f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 121);
				float val = 620f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = false;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				SetUpUnitLook(levelBehaviour);
			}
		}
	}

	private void BHEDBMGGPHM()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 683f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	private void FKIFBBPBLKA()
	{
		AGAPLFPNCDN();
		OCPKACMOHMO = RadicalRoutine.Create(CAJMJDLEMLK());
		StartCoroutine(RadicalRoutine.Run(OCPKACMOHMO.enumerator));
	}

	public void InitBlank()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: false);
		ICLDIMHHEJB(0);
	}

	private void MGGGPNBHFCJ()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 1871f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	public void IBFADEMOCML()
	{
		NHAJIPFPKEH.SetActive(value: true);
		KOEOHMJILHJ.SetActive(value: true);
		OBDIFAIELID(0);
	}

	private void JDEJMFKEICM()
	{
		CIFGFKBFJEG();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: false);
			GGPBPONCMLD(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8 || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 983f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.NotBuyed) ? Localization.Localize((!levelBehaviour.isSoldier) ? "id" : "Prefab not found in pool") : Localization.Localize("_Color"));
				HGJJFHLADJL.alpha = 418f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 1611f, 1251f);
			}
			else
			{
				HIKOOOPJEJC = -113;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				APHAKJCLMKN((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				HADEKFGCDFA = levelBehaviour;
				EEBLDNHFCNF();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: false);
				OLHKAMAPJFM(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 1692f, 1000f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 58);
				float val = 1699f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: false);
				SetUpUnitLook(levelBehaviour);
			}
		}
	}

	private void EDPEIPJPOPJ()
	{
		AGAPLFPNCDN();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: true);
			LMJEOCDNBGF(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 1863f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering) ? Localization.Localize((!levelBehaviour.isSoldier) ? "Squad Member record does not have DatabasePlayer" : "x0") : Localization.Localize("-"));
				HGJJFHLADJL.alpha = 631f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 432f, 1914f);
			}
			else
			{
				HIKOOOPJEJC = -75;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				JLFECPABDFE((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds);
				HADEKFGCDFA = levelBehaviour;
				MNCLJOLFCPJ();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: false);
				LMJEOCDNBGF(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 1831f, 1228f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - -105);
				float val = 1746f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: false);
				LMJEOCDNBGF(levelBehaviour);
			}
		}
	}

	public void DMIGHFGKEMO()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.LDEHPBBIPPI();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)7);
		int num5 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)8, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)6, (AKDLEDNDIEO)8);
		int num7 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)5, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerRusher, AKDLEDNDIEO.Upgrade);
		int num9 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)0);
		int num10 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)4);
		bool flag = num <= 0 || !(levelBehaviour != null) || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 <= 0 || !(levelBehaviour != null) || !levelBehaviour.upgradeSlots.bought || levelBehaviour.upgradeSlots.canBeUpgraded;
		LJPABKAGJAF();
		bool flag3 = num3 <= 0 || OIKEDCIECLC;
		bool flag4 = num4 > 0 && OAMFKBINMFE;
		bool flag5 = num5 > 0 && HLIMAKAKFPL;
		bool flag6 = num6 <= 0 || PFMCHDDLKEO;
		bool flag7 = num7 <= 0 || DGKJFGMHFBN;
		bool flag8 = num8 <= 1 || HJPBFGEGGIC;
		bool flag9 = num9 > 0 && CNEALPMNPGM;
		bool flag10 = num10 <= 0 || CGIMFGLJIPA;
		bool flag11 = num3 > 1 && num5 > 0 && num7 > 1 && num9 > 1;
		bool flag12 = num4 > 1 && num6 > 0 && num8 > 0 && num10 > 0;
		bool flag13 = flag11 && (OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM);
		bool flag14 = !flag12 || OAMFKBINMFE || PFMCHDDLKEO || HJPBFGEGGIC || CGIMFGLJIPA;
		bool flag15 = !flag13 && !flag3 && !flag5 && !flag7 && flag9;
		bool flag16 = !flag14 && !flag4 && !flag6 && !flag8 && flag10;
		CODKHFGLFOB.SetActive(!flag && !flag2 && !flag13 && !flag14 && !flag15 && flag16);
		if (flag13 || flag14)
		{
			UILabel eFHDAKGAEBO = EFHDAKGAEBO;
			object[] array = new object[0];
			array[1] = ((!flag13) ? num4 : num3);
			eFHDAKGAEBO.text = Localization.LocalizeFormat("bazooka_shot_barrier", array);
			PHOIGIBILNH.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(SaleUnits));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1264f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.PEHBGMEHFEM();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(JKCDFAAHLDE));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[1];
				array2[1] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("ID_GUI_INVITETOCOOP", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag5 || flag6)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[0];
				array3[0] = ((!flag5) ? num6 : num5);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("WarBucks", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)6].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
				object[] array4 = new object[0];
				array4[0] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO4.text = Localization.LocalizeFormat("{0} {1}", array4);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)4].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(593f);
					return;
				}
				EFHDAKGAEBO.text = Localization.LocalizeFormat("PlayerId", (!flag9) ? num10 : num9);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 1177f);
		}
		else if (flag || flag2)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("Medals/", (!flag) ? num2 : num);
			PHOIGIBILNH.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(PEJGINIFLND));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(LOOEOBHHLLO));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1932f);
		}
		else
		{
			PHOIGIBILNH.KEIIENDMKLN();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(LOOEOBHHLLO));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1253f);
		}
	}

	private static void JFFMACDNNAB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
	}

	[DebuggerHidden]
	private IEnumerator FJFCLAOAJLI()
	{
		ONJIDIHGCOD oNJIDIHGCOD = new ONJIDIHGCOD();
		oNJIDIHGCOD.BJGCPDNMHDH = this;
		return oNJIDIHGCOD;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
		});
		MJKBDGIILHI.onReposition = delegate
		{
			float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 2f;
			MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
		};
	}

	private void PIAKEMJGFPP()
	{
		PMDKHAEODLL();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: false);
			OFCKBMPOCNL(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 1886f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivered) ? Localization.Localize((!levelBehaviour.isSoldier) ? "Critical" : "UsedCards") : Localization.Localize("Beanstalk: Get All Squad Members"));
				HGJJFHLADJL.alpha = 592f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 470f, 1116f);
			}
			else
			{
				HIKOOOPJEJC = -21;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				APHAKJCLMKN((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				HADEKFGCDFA = levelBehaviour;
				BKDHFIAMICO();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: true);
				LMJEOCDNBGF(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 931f, 1313f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 13);
				float val = 1903f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: false);
				GGPBPONCMLD(levelBehaviour);
			}
		}
	}

	private static void FCEHHFOBJNB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
	}

	public void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOAOLAAEFFL));
		MJKBDGIILHI.onReposition = GHMINFINIPM;
	}

	private void DIEANEHCMMB()
	{
		OIKEDCIECLC = false;
		OAMFKBINMFE = false;
		HLIMAKAKFPL = false;
		PFMCHDDLKEO = false;
		DGKJFGMHFBN = false;
		HJPBFGEGGIC = false;
		CNEALPMNPGM = false;
		CGIMFGLJIPA = false;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				OAMFKBINMFE |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				PFMCHDDLKEO |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				HJPBFGEGGIC |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				CGIMFGLJIPA |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	private void PLKGGNLCMFL()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 1079f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	public void OFCKBMPOCNL(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(391f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	public void DoAfterHide()
	{
		PMDKHAEODLL();
	}

	public void MNHAOCEONAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDMDKBDCKOJ));
		MJKBDGIILHI.onReposition = NDPCBACFLDH;
	}

	public void NHEPIJEBNFL()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: false);
		LPBECLGCHLE(1);
	}

	private void JDFFDIMFLEH(int IDLMJLCFMJG)
	{
		BFHHLAFEPOB.SetActive(IDLMJLCFMJG > 1);
		BCLNCPMAOFI.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private static void OOAOLAAEFFL(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
	}

	public void JPIEGHAOIPL()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: true);
		MCKLIMELCMO(1);
	}

	private void AGAPLFPNCDN()
	{
		if (OCPKACMOHMO != null)
		{
			OCPKACMOHMO.Cancel();
			OCPKACMOHMO = null;
		}
	}

	private void IEMMJLFMMBM()
	{
		CIFGFKBFJEG();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: true);
			LMJEOCDNBGF(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 366f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivered) ? Localization.Localize((!levelBehaviour.isSoldier) ? "\\D*" : "HeroicMissionsCompletionRewardTickets") : Localization.Localize("ID_INVITEDYOUTOFIGHT"));
				HGJJFHLADJL.alpha = 156f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 202f, 1614f);
			}
			else
			{
				HIKOOOPJEJC = 45;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				APHAKJCLMKN((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds);
				HADEKFGCDFA = levelBehaviour;
				ENHGOLJICDJ();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.FALLMNNHFCE();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				GNENMFGIKBE(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 1496f, 1101f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - -17);
				float val = 23f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: true);
				LMJEOCDNBGF(levelBehaviour);
			}
		}
	}

	public void OJKCMCPJPGO()
	{
		HDAOAKDNNGA();
		OBDIFAIELID(Singleton<NotificationManager>.instance.GetNumberOfArmyNotifications());
	}

	private void APHAKJCLMKN(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (HIKOOOPJEJC > EJEDANLAMBI)
		{
			HIKOOOPJEJC = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref HGJJFHLADJL, PDPDGCNHCFN);
		}
	}

	private void ABHJICMIIFI()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 1060f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	public void EGBPOAIPKCF()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: true);
		MICLDOPLAPN(0);
	}

	private void POOBBABOPDL()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 294f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	private void HDAOAKDNNGA()
	{
		PMDKHAEODLL();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: true);
			SetUpUnitLook(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				HIKOOOPJEJC = 0;
				NIGPNJJFFBE.fillAmount = 1f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivered) ? Localization.Localize((!levelBehaviour.isSoldier) ? "ID_UPGRADED" : "ID_TRAINED") : Localization.Localize("ID_PURCHASED"));
				HGJJFHLADJL.alpha = 1f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 0.01f, 1f);
			}
			else
			{
				HIKOOOPJEJC = int.MaxValue;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				JLFECPABDFE((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				HADEKFGCDFA = levelBehaviour;
				NPJBMJOLFAC();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: false);
				SetUpUnitLook(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 88);
				float val = 16f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: false);
				SetUpUnitLook(levelBehaviour);
			}
		}
	}

	public void OHBJJPECDJJ()
	{
		NHAJIPFPKEH.SetActive(value: true);
		KOEOHMJILHJ.SetActive(value: true);
		LPBECLGCHLE(1);
	}

	private void NPJBMJOLFAC()
	{
		PMDKHAEODLL();
		OCPKACMOHMO = RadicalRoutine.Create(FJFCLAOAJLI());
		StartCoroutine(RadicalRoutine.Run(OCPKACMOHMO.enumerator));
	}

	private void MFCFOFKLOON()
	{
		if (OCPKACMOHMO != null)
		{
			OCPKACMOHMO.Cancel();
			OCPKACMOHMO = null;
		}
	}

	public void OLHKAMAPJFM(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(1324f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	public void MGNKBLKNOJM()
	{
		NHAJIPFPKEH.SetActive(value: true);
		KOEOHMJILHJ.SetActive(value: false);
		JDFFDIMFLEH(1);
	}

	private void ENHGOLJICDJ()
	{
		CIFGFKBFJEG();
		OCPKACMOHMO = RadicalRoutine.Create(CAJMJDLEMLK());
		StartCoroutine(RadicalRoutine.Run(OCPKACMOHMO.enumerator));
	}

	public void JKCDFAAHLDE()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.LDEHPBBIPPI();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)0);
		int num4 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)6);
		int num5 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerRusher, (AKDLEDNDIEO)5);
		int num7 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerRusher, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)6);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Both);
		bool flag = num <= 0 || !(levelBehaviour != null) || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
		bool flag2 = num2 > 1 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		JHOLOGHIJMN();
		bool flag3 = num3 <= 1 || OIKEDCIECLC;
		bool flag4 = num4 > 0 && OAMFKBINMFE;
		bool flag5 = num5 <= 0 || HLIMAKAKFPL;
		bool flag6 = num6 <= 0 || PFMCHDDLKEO;
		bool flag7 = num7 <= 1 || DGKJFGMHFBN;
		bool flag8 = num8 <= 0 || HJPBFGEGGIC;
		bool flag9 = num9 > 1 && CNEALPMNPGM;
		bool flag10 = num10 > 0 && CGIMFGLJIPA;
		bool flag11 = num3 > 0 && num5 > 1 && num7 > 1 && num9 > 1;
		bool flag12 = num4 > 1 && num6 > 0 && num8 > 1 && num10 > 0;
		bool flag13 = !flag11 || (!OIKEDCIECLC && !HLIMAKAKFPL && !DGKJFGMHFBN && CNEALPMNPGM);
		bool flag14 = !flag12 || OAMFKBINMFE || PFMCHDDLKEO || HJPBFGEGGIC || CGIMFGLJIPA;
		bool flag15 = flag13 || (!flag3 && !flag5 && !flag7 && flag9);
		bool flag16 = !flag14 && !flag4 && !flag6 && !flag8 && flag10;
		CODKHFGLFOB.SetActive(!flag && !flag2 && !flag13 && !flag14 && !flag15 && flag16);
		if (flag13 || flag14)
		{
			UILabel eFHDAKGAEBO = EFHDAKGAEBO;
			object[] array = new object[0];
			array[0] = ((!flag13) ? num4 : num3);
			eFHDAKGAEBO.text = Localization.LocalizeFormat("Rank", array);
			PHOIGIBILNH.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(LNLFJOIENED));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1643f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.PEHBGMEHFEM();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(SaleUnits));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[1];
				array2[1] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("Get Custom Profile Variables", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag5 || flag6)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("Fuseboxx: Add Did Show networkId: {0} mediaType: {1}", (!flag5) ? num6 : num5);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerRusher].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[0];
				array3[0] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("IT WAS FORFEIT IN TUTORIAL", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)8].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(148f);
					return;
				}
				EFHDAKGAEBO.text = Localization.LocalizeFormat("Id", (!flag9) ? num10 : num9);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 869f);
		}
		else if (flag || flag2)
		{
			UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
			object[] array4 = new object[1];
			array4[1] = ((!flag) ? num2 : num);
			eFHDAKGAEBO4.text = Localization.LocalizeFormat("BurstSize", array4);
			PHOIGIBILNH.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(BNFANHCCPHO));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(960f);
		}
		else
		{
			PHOIGIBILNH.JCMHGOGNMFO();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(DMIGHFGKEMO));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1852f);
		}
	}

	public void GNENMFGIKBE(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(941f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	public void IMEOAPEABLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDMDKBDCKOJ));
		MJKBDGIILHI.onReposition = GHMINFINIPM;
	}

	public void HLHANONIBIN()
	{
		MFCFOFKLOON();
	}

	public void PEJGINIFLND()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.DiscountedUnitOffer();
		int num3 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)7);
		int num5 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.DiscountedUnitCategory((LevelBehaviour.UnitType)7, (AKDLEDNDIEO)8);
		int num7 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)8, AKDLEDNDIEO.Upgrade);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Upgrade);
		bool flag = num <= 1 || !(levelBehaviour != null) || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
		bool flag2 = num2 > 1 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		LJPABKAGJAF();
		bool flag3 = num3 > 0 && OIKEDCIECLC;
		bool flag4 = num4 > 0 && OAMFKBINMFE;
		bool flag5 = num5 <= 1 || HLIMAKAKFPL;
		bool flag6 = num6 <= 1 || PFMCHDDLKEO;
		bool flag7 = num7 > 0 && DGKJFGMHFBN;
		bool flag8 = num8 > 1 && HJPBFGEGGIC;
		bool flag9 = num9 > 0 && CNEALPMNPGM;
		bool flag10 = num10 <= 0 || CGIMFGLJIPA;
		bool flag11 = num3 > 1 && num5 > 1 && num7 > 0 && num9 > 0;
		bool flag12 = num4 <= 1 || num6 <= 0 || num8 <= 0 || num10 > 1;
		bool flag13 = !flag11 || OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM;
		bool flag14 = flag12 && !OAMFKBINMFE && !PFMCHDDLKEO && !HJPBFGEGGIC && CGIMFGLJIPA;
		bool flag15 = flag13 || (!flag3 && !flag5 && !flag7 && flag9);
		bool flag16 = !flag14 && (flag4 || flag6 || flag8 || flag10);
		CODKHFGLFOB.SetActive(!flag && !flag2 && !flag13 && !flag14 && !flag15 && flag16);
		if (flag13 || flag14)
		{
			UILabel eFHDAKGAEBO = EFHDAKGAEBO;
			object[] array = new object[0];
			array[0] = ((!flag13) ? num4 : num3);
			eFHDAKGAEBO.text = Localization.LocalizeFormat("ID_CONFIRM_INFO", array);
			PHOIGIBILNH.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(BPJBPPEKBKF));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(SaleUnits));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1784f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.PEHBGMEHFEM();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(MIICHIJNFKJ));
			if (flag3 || flag4)
			{
				EFHDAKGAEBO.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag3) ? num4 : num3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			else if (flag5 || flag6)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[1];
				array2[1] = ((!flag5) ? num6 : num5);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("{0} / 8", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[1];
				array3[1] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("ok", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[(LevelBehaviour.UnitType)8].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(269f);
					return;
				}
				UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
				object[] array4 = new object[0];
				array4[0] = ((!flag9) ? num10 : num9);
				eFHDAKGAEBO4.text = Localization.LocalizeFormat("ArenaLootbox", array4);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 97f);
		}
		else if (flag || flag2)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("vip", (!flag) ? num2 : num);
			PHOIGIBILNH.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(DMIGHFGKEMO));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(BPJBPPEKBKF));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1258f);
		}
		else
		{
			PHOIGIBILNH.BGHNMCPLIPE();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(PEJGINIFLND));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(955f);
		}
	}

	public void IFLHOKBNJPH()
	{
		MFCFOFKLOON();
	}

	private void JCCOPBLMNLI(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (HIKOOOPJEJC > EJEDANLAMBI)
		{
			HIKOOOPJEJC = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref HGJJFHLADJL, PDPDGCNHCFN);
		}
	}

	private void LPBECLGCHLE(int IDLMJLCFMJG)
	{
		BFHHLAFEPOB.SetActive(IDLMJLCFMJG > 1);
		BCLNCPMAOFI.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void NMHBLMIMFAI()
	{
		NHAJIPFPKEH.SetActive(value: true);
		KOEOHMJILHJ.SetActive(value: true);
		MICLDOPLAPN(0);
	}

	public void OCFOEGJBNCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FCEHHFOBJNB));
		MJKBDGIILHI.onReposition = POOBBABOPDL;
	}

	private void JHOLOGHIJMN()
	{
		OIKEDCIECLC = true;
		OAMFKBINMFE = true;
		HLIMAKAKFPL = true;
		PFMCHDDLKEO = true;
		DGKJFGMHFBN = true;
		HJPBFGEGGIC = false;
		CNEALPMNPGM = false;
		CGIMFGLJIPA = true;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			switch (behaviour.unitType)
			{
			case LevelBehaviour.UnitType.Defender:
				OIKEDCIECLC |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				OAMFKBINMFE |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerRusher:
				HLIMAKAKFPL |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				PFMCHDDLKEO |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerShooter:
				DGKJFGMHFBN |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked;
				HJPBFGEGGIC |= !behaviour.upgradeSlots.bought || behaviour.upgradeSlots.canBeUpgraded;
				break;
			case LevelBehaviour.UnitType.AttackerExplosive:
				CNEALPMNPGM |= behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
				CGIMFGLJIPA |= behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded;
				break;
			}
		}
	}

	private void NMCEFOLAFKO()
	{
		MFCFOFKLOON();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: false);
			KOEOHMJILHJ.SetActive(value: true);
			OLHKAMAPJFM(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7 || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				HIKOOOPJEJC = 1;
				NIGPNJJFFBE.fillAmount = 1553f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)8) ? Localization.Localize((!levelBehaviour.isSoldier) ? "Prefabs Full Path: \"{0}\"\n" : "Pack") : Localization.Localize("com/google/android/gms/common/ConnectionResult"));
				HGJJFHLADJL.alpha = 258f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 1141f, 1134f);
			}
			else
			{
				HIKOOOPJEJC = 94;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				APHAKJCLMKN((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds);
				HADEKFGCDFA = levelBehaviour;
				ENHGOLJICDJ();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				GNENMFGIKBE(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 1300f, 1936f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 64);
				float val = 456f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = true;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				GGPBPONCMLD(levelBehaviour);
			}
		}
	}

	public void MIICHIJNFKJ()
	{
		int num = Singleton<OfferManager>.instance.DiscountedUnitOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedUnitOfferUpgrade();
		LevelBehaviour levelBehaviour = Singleton<OfferManager>.instance.CILJBKFLNPB();
		int num3 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)0);
		int num4 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)5);
		int num5 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)4, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerRusher, (AKDLEDNDIEO)6);
		int num7 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)5, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.NOHMKMLKJKP((LevelBehaviour.UnitType)8, (AKDLEDNDIEO)4);
		int num9 = Singleton<OfferManager>.instance.NOHMKMLKJKP(LevelBehaviour.UnitType.AttackerExplosive, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.DiscountedUnitCategory(LevelBehaviour.UnitType.Defender, (AKDLEDNDIEO)0);
		bool flag = num > 1 && levelBehaviour != null && levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 > 1 && levelBehaviour != null && levelBehaviour.upgradeSlots.bought && levelBehaviour.upgradeSlots.canBeUpgraded;
		LJPABKAGJAF();
		bool flag3 = num3 <= 0 || OIKEDCIECLC;
		bool flag4 = num4 <= 1 || OAMFKBINMFE;
		bool flag5 = num5 <= 0 || HLIMAKAKFPL;
		bool flag6 = num6 <= 1 || PFMCHDDLKEO;
		bool flag7 = num7 > 1 && DGKJFGMHFBN;
		bool flag8 = num8 <= 1 || HJPBFGEGGIC;
		bool flag9 = num9 > 0 && CNEALPMNPGM;
		bool flag10 = num10 > 0 && CGIMFGLJIPA;
		bool flag11 = num3 > 0 && num5 > 0 && num7 > 1 && num9 > 1;
		bool flag12 = num4 > 0 && num6 > 1 && num8 > 0 && num10 > 1;
		bool flag13 = flag11 && (OIKEDCIECLC || HLIMAKAKFPL || DGKJFGMHFBN || CNEALPMNPGM);
		bool flag14 = flag12 && (OAMFKBINMFE || PFMCHDDLKEO || HJPBFGEGGIC || CGIMFGLJIPA);
		bool flag15 = flag13 || flag3 || flag5 || flag7 || flag9;
		bool flag16 = flag14 || (!flag4 && !flag6 && !flag8 && flag10);
		CODKHFGLFOB.SetActive(!flag && !flag2 && !flag13 && !flag14 && !flag15 && flag16);
		if (flag13 || flag14)
		{
			EFHDAKGAEBO.text = Localization.LocalizeFormat("KEYBOARD DONNNEEEE, was canceled: ", (!flag13) ? num4 : num3);
			PHOIGIBILNH.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedUnitFlatEndtime());
			WinStreakCounter pHOIGIBILNH = PHOIGIBILNH;
			pHOIGIBILNH.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH.JEMKCLKCOMI, new Action(SaleUnits));
			WinStreakCounter pHOIGIBILNH2 = PHOIGIBILNH;
			pHOIGIBILNH2.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH2.JEMKCLKCOMI, new Action(LOOEOBHHLLO));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(545f);
		}
		else if (flag15 || flag16)
		{
			PHOIGIBILNH.KEIIENDMKLN();
			WinStreakCounter pHOIGIBILNH3 = PHOIGIBILNH;
			pHOIGIBILNH3.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH3.JEMKCLKCOMI, new Action(LNLFJOIENED));
			if (flag3 || flag4)
			{
				UILabel eFHDAKGAEBO = EFHDAKGAEBO;
				object[] array = new object[1];
				array[1] = ((!flag3) ? num4 : num3);
				eFHDAKGAEBO.text = Localization.LocalizeFormat("D5", array);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerExplosive].Value1);
			}
			else if (flag5 || flag6)
			{
				UILabel eFHDAKGAEBO2 = EFHDAKGAEBO;
				object[] array2 = new object[1];
				array2[1] = ((!flag5) ? num6 : num5);
				eFHDAKGAEBO2.text = Localization.LocalizeFormat("was:{0} is:{1} removed:{2}", array2);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.AttackerShooter].Value1);
			}
			else if (flag7 || flag8)
			{
				UILabel eFHDAKGAEBO3 = EFHDAKGAEBO;
				object[] array3 = new object[1];
				array3[1] = ((!flag7) ? num8 : num7);
				eFHDAKGAEBO3.text = Localization.LocalizeFormat("Dictionary filled and contains {0} ids", array3);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			else
			{
				if (!flag9 && !flag10)
				{
					EFHDAKGAEBO.text = string.Empty;
					PHOIGIBILNH.KGNGFHMBHMJ.text = string.Empty;
					BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(691f);
					return;
				}
				UILabel eFHDAKGAEBO4 = EFHDAKGAEBO;
				object[] array4 = new object[0];
				array4[1] = ((!flag9) ? num10 : num9);
				eFHDAKGAEBO4.text = Localization.LocalizeFormat("ID_YOUHAVENOWARCARDSAVAILABLE", array4);
				PHOIGIBILNH.KGNGFHMBHMJ.text = Localization.Localize(GameVariables.NAKDNAEPGOF[LevelBehaviour.UnitType.Defender].Value1);
			}
			float num11 = PHOIGIBILNH.KGNGFHMBHMJ.relativeSize.x * PHOIGIBILNH.KGNGFHMBHMJ.transform.localScale.x;
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(num11 + 1267f);
		}
		else if (flag || flag2)
		{
			UILabel eFHDAKGAEBO5 = EFHDAKGAEBO;
			object[] array5 = new object[0];
			array5[0] = ((!flag) ? num2 : num);
			eFHDAKGAEBO5.text = Localization.LocalizeFormat("Tickets", array5);
			PHOIGIBILNH.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedUnitOfferEndtime());
			WinStreakCounter pHOIGIBILNH4 = PHOIGIBILNH;
			pHOIGIBILNH4.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH4.JEMKCLKCOMI, new Action(DMIGHFGKEMO));
			WinStreakCounter pHOIGIBILNH5 = PHOIGIBILNH;
			pHOIGIBILNH5.JEMKCLKCOMI = (Action)Delegate.Combine(pHOIGIBILNH5.JEMKCLKCOMI, new Action(LNLFJOIENED));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1299f);
		}
		else
		{
			PHOIGIBILNH.LOINIDOGNCO();
			WinStreakCounter pHOIGIBILNH6 = PHOIGIBILNH;
			pHOIGIBILNH6.JEMKCLKCOMI = (Action)Delegate.Remove(pHOIGIBILNH6.JEMKCLKCOMI, new Action(BPJBPPEKBKF));
			BPNDNBJEPDE.transform.localScale = BPNDNBJEPDE.transform.localScale.ReplaceX(1099f);
		}
	}

	private static void PBEOCNBNNMB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
	}

	public void ONIADPHJMFO(LevelBehaviour IOIKKIIFOCB)
	{
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(527f);
		Vector3 localPosition = NACGOGCPIAH.transform.localPosition;
		localPosition.y = IOIKKIIFOCB.prepareForBattleIconPositionY;
		NACGOGCPIAH.transform.localPosition = localPosition;
	}

	private void KFFPFBEHPBC()
	{
		CIFGFKBFJEG();
		LevelBehaviour levelBehaviour = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour != null)
		{
			NHAJIPFPKEH.SetActive(value: true);
			KOEOHMJILHJ.SetActive(value: true);
			SetUpUnitLook(levelBehaviour);
			if (levelBehaviour.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7 || levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
			{
				HIKOOOPJEJC = 0;
				NIGPNJJFFBE.fillAmount = 779f;
				NIGPNJJFFBE.color = Colours.blue;
				HGJJFHLADJL.text = ((levelBehaviour.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)8) ? Localization.Localize((!levelBehaviour.isSoldier) ? "Visual {0}, no overcount" : "\n") : Localization.Localize("Token"));
				HGJJFHLADJL.alpha = 1411f;
				TweenAlpha.Begin(HGJJFHLADJL.gameObject, 1526f, 1194f);
			}
			else
			{
				HIKOOOPJEJC = -94;
				NIGPNJJFFBE.fillAmount = levelBehaviour.upgradeSlots.progressDelivering;
				NIGPNJJFFBE.color = Colours.cyan;
				MDDKDHCDLDJ((int)levelBehaviour.upgradeSlots.remainingDeliveringSeconds);
				HADEKFGCDFA = levelBehaviour;
				NPJBMJOLFAC();
			}
		}
		else
		{
			levelBehaviour = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
			if (levelBehaviour != null)
			{
				NHAJIPFPKEH.SetActive(value: false);
				KOEOHMJILHJ.SetActive(value: true);
				OFCKBMPOCNL(levelBehaviour);
				EGGAAGOFBHD.text = levelBehaviour.unitName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(EGGAAGOFBHD, 587f, 825f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 83);
				float val = 794f + MCGOMCDNABF.relativeSize.x * MCGOMCDNABF.transform.localScale.x;
				EOEEJONJAIM.transform.localScale = EOEEJONJAIM.transform.localScale.ReplaceX(val);
				MJKBDGIILHI.repositionNow = false;
			}
			else
			{
				levelBehaviour = LevelManager.instance.GetBoughtUnitWithBiggestUnlockLevel();
				NHAJIPFPKEH.SetActive(value: true);
				KOEOHMJILHJ.SetActive(value: true);
				ONIADPHJMFO(levelBehaviour);
			}
		}
	}

	private void NDPCBACFLDH()
	{
		float val = 0f - MJKBDGIILHI.padding.x - (EGGAAGOFBHD.transform.parent.localPosition.x - MJKBDGIILHI.padding.x) / 275f;
		MJKBDGIILHI.transform.localPosition = MJKBDGIILHI.transform.localPosition.ReplaceX(val);
	}

	private void BNMBMFDBNHB(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (HIKOOOPJEJC > EJEDANLAMBI)
		{
			HIKOOOPJEJC = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.CFJGOIAIKGB(EJEDANLAMBI, ref HGJJFHLADJL, PDPDGCNHCFN);
		}
	}

	public void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JANFGHJMGBI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOAOLAAEFFL));
		MJKBDGIILHI.onReposition = NDPCBACFLDH;
	}

	public void EBHFGEOLOFA()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: true);
		LPBECLGCHLE(0);
	}

	public void PLDBDGJLOFP()
	{
		IEMMJLFMMBM();
		MCKLIMELCMO(Singleton<NotificationManager>.instance.DFHMKDCOLLB());
	}

	public void GILNOADNGCK()
	{
		NHAJIPFPKEH.SetActive(value: false);
		KOEOHMJILHJ.SetActive(value: true);
		LPBECLGCHLE(1);
	}
}
