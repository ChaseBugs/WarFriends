using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using FuseMisc;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class OfferManager : Singleton<OfferManager>
{
	public long HAMCICHNEDB = 300L;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action EACENMMIEIM;

	private int DBKFAPEIBEC;

	private bool LKELFGNDHDH;

	private Dictionary<string, JGBBPCGNCPC> DGGJJHJBFHL = new Dictionary<string, JGBBPCGNCPC>();

	private Dictionary<string, string> GAJBEEJIPAN = new Dictionary<string, string>();

	private Dictionary<string, string> HONGNEGCKGI = new Dictionary<string, string>();

	private int CGAKMJBHKKG;

	private JToken EPBNMOJACNM;

	public string FLELEOEKFLI = string.Empty;

	public int CENJLHLBBDM;

	private List<JPMLOCNCEGO> PMOKDDENPLE = new List<JPMLOCNCEGO>();

	private JPMLOCNCEGO[] GKLLBAFMBLF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<string> OPBFFCEONFD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<string> IEMKMFFAOOM;

	public int numberOfSpecialPacks
	{
		get
		{
			return DGGJJHJBFHL.Count;
		}
	}

	public Dictionary<string, JGBBPCGNCPC>.ValueCollection specialPacks
	{
		get
		{
			return DGGJJHJBFHL.Values;
		}
	}

	public JPMLOCNCEGO[] currentOffers
	{
		get
		{
			if (DebugSettings.debugEnabled && GKLLBAFMBLF != null && GKLLBAFMBLF.Length > 0)
			{
				return GKLLBAFMBLF;
			}
			return PMOKDDENPLE.ToArray();
		}
	}

	public event Action SalesChanged
	{
		add
		{
			Action action = EACENMMIEIM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EACENMMIEIM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = EACENMMIEIM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EACENMMIEIM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<string> OfferSmallTextureReadyToLoad
	{
		add
		{
			Action<string> action = OPBFFCEONFD;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref OPBFFCEONFD, (Action<string>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string> action = OPBFFCEONFD;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref OPBFFCEONFD, (Action<string>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<string> OfferBigTextureReadyToLoad
	{
		add
		{
			Action<string> action = IEMKMFFAOOM;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref IEMKMFFAOOM, (Action<string>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string> action = IEMKMFFAOOM;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref IEMKMFFAOOM, (Action<string>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public bool IsTextureDownloaded(bool BFPPALFKOAF, string HKODIHDPOGE, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.offerBigTextures : Singleton<GuiTexureAssets>.instance.offerSmallTextures);
		return webTextureLoader.IsDownloaded(HKODIHDPOGE, GDIAEJILINE);
	}

	public void AMEICODKKGH(bool BFPPALFKOAF, string HKODIHDPOGE, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.LOHPIHDLAPC() : Singleton<GuiTexureAssets>.instance.NHOEEHPJIGB());
		webTextureLoader.IFDGJIPNBKM(HKODIHDPOGE, GDIAEJILINE);
	}

	public int OLJPHBAFGGF(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 1;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-59))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.BattleRewardSquadpoints)
			{
				int num2 = 1 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)(-96));
				int result = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public void DebugThreeOffers()
	{
		GKLLBAFMBLF = new JPMLOCNCEGO[3];
		GKLLBAFMBLF[0] = JPMLOCNCEGO.JNHIECOHDFL();
		GKLLBAFMBLF[1] = JPMLOCNCEGO.JNHIECOHDFL(1);
		GKLLBAFMBLF[2] = JPMLOCNCEGO.JNHIECOHDFL(2);
		if (EACENMMIEIM != null)
		{
			EACENMMIEIM();
		}
	}

	public int EPEFENGEOOI(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)116)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)74)
			{
				int num2 = 1 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)10);
				int result = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-93) && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int IBDHFMGAFKD(WeaponLevelsSetup JMMJHCOKCGG, AKDLEDNDIEO FJLBLLLEELD)
	{
		return DiscountedWeaponCategory(JMMJHCOKCGG.BHCEOOLEHHG, FJLBLLLEELD, JMMJHCOKCGG);
	}

	public bool JIAFPJNFOBC(NGNPIOOAHEH NMOHBENEBLC)
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne && PMOKDDENPLE[i].NCKBCFBJNBA == Singleton<GameVariables>.instance.OIEMOKJDBJE(NMOHBENEBLC).NAME)
			{
				return false;
			}
		}
		return false;
	}

	public string getPackName(string PPDHFFJADAJ)
	{
		if (GAJBEEJIPAN.ContainsKey(PPDHFFJADAJ))
		{
			return GAJBEEJIPAN[PPDHFFJADAJ];
		}
		UnityEngine.Debug.LogError("no pack name");
		return PPDHFFJADAJ;
	}

	public void OMJPDABIAPE()
	{
		GKLLBAFMBLF = new JPMLOCNCEGO[6];
		GKLLBAFMBLF[1] = JPMLOCNCEGO.GDKBNJELNKA(1);
		GKLLBAFMBLF[1] = JPMLOCNCEGO.JNHIECOHDFL(1);
		GKLLBAFMBLF[1] = JPMLOCNCEGO.GDKBNJELNKA(6);
		if (EACENMMIEIM != null)
		{
			EACENMMIEIM();
		}
	}

	public int GAAFNCKGHHL(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 1;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-52))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)127)
			{
				int num2 = 0 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)22);
				int result = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 1)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-20) && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public bool DiscountedCardpackOffer(NGNPIOOAHEH NMOHBENEBLC)
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne && PMOKDDENPLE[i].NCKBCFBJNBA == Singleton<GameVariables>.instance.GetCardPackRow(NMOHBENEBLC).NAME)
			{
				return true;
			}
		}
		return false;
	}

	public Texture2D HFPBCCPKEIK(bool BFPPALFKOAF, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.BJJHDDHDFDB() : Singleton<GuiTexureAssets>.instance.HAKBLCKNKGL());
		return webTextureLoader.MKNIGGCHJMF(GDIAEJILINE);
	}

	private void AIBPAALJHJD()
	{
		if (EPBNMOJACNM != null)
		{
			FLBMLNGMBFC(EPBNMOJACNM);
		}
		EPBNMOJACNM = null;
	}

	[SpecialName]
	public void BCLJKLIONLA(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = IEMKMFFAOOM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IEMKMFFAOOM, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int DiscountedUnityDeliveryCostDeadline(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostType)
			{
				int num2 = 1 << (int)NAKDNAEPGOF;
				int result2 = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (result2 & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostOne && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	private void LBAEJPIGILB(JToken NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH is JArray)
		{
			foreach (JToken item in (IEnumerable<JToken>)NDPMDKGJAFH)
			{
				if (item["ID_CONTAINSXWARCARDS"] != null && item["********************************************"] != null)
				{
					string text = KHJJFPPACBP.BKFCLMMJNHK(item["menu-everyplay-ico"], string.Empty);
					int mGJIPPFKDOE = KHJJFPPACBP.HNMDPGKPLNK(item["ID_TUTORIAL_TAPON"], -1);
					if (DGGJJHJBFHL.ContainsKey(text))
					{
						DGGJJHJBFHL[text].MGJIPPFKDOE = mGJIPPFKDOE;
					}
					else
					{
						JGBBPCGNCPC jGBBPCGNCPC = JGBBPCGNCPC.KLPJEGPJCKM(text);
						if (jGBBPCGNCPC != null)
						{
							jGBBPCGNCPC.MGJIPPFKDOE = mGJIPPFKDOE;
							AddSpecialPack(jGBBPCGNCPC);
						}
					}
				}
			}
			return;
		}
		UnityEngine.Debug.LogWarning("facebook get me data, but still is logged in, logout manualy" + NDPMDKGJAFH.ToString());
	}

	[SpecialName]
	public int BGIPCNIPNGA()
	{
		return DGGJJHJBFHL.Count;
	}

	public void RequestTexture(bool BFPPALFKOAF, string HKODIHDPOGE, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.offerBigTextures : Singleton<GuiTexureAssets>.instance.offerSmallTextures);
		webTextureLoader.RequestAsset(HKODIHDPOGE, GDIAEJILINE);
	}

	[SpecialName]
	public void AGFPMHLOIBG(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = IEMKMFFAOOM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IEMKMFFAOOM, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int ADBBKEABFHM(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 0;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-113))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-105) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-72))
			{
				int result2 = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)FABOAIMLLOI) > 1)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-90) && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return result;
	}

	public int MIEGELBEBGF(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-72))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)106)
			{
				int num2 = 1 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)30);
				int result = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)73 && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	private void MMEKFOHGAKK()
	{
		if (EPBNMOJACNM != null)
		{
			FLBMLNGMBFC(EPBNMOJACNM);
		}
		EPBNMOJACNM = null;
	}

	private void DAMDGLAIKLD(JToken NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH is JArray)
		{
			foreach (JToken item in (IEnumerable<JToken>)NDPMDKGJAFH)
			{
				if (item["Scraps"] != null && item["getCustomProfileGeolocation"] != null)
				{
					string text = KHJJFPPACBP.BKFCLMMJNHK(item["SERVICE_MISSING"], string.Empty);
					int mGJIPPFKDOE = KHJJFPPACBP.HNMDPGKPLNK(item["Play_Card_Tutorial_Duration"], -1);
					if (DGGJJHJBFHL.ContainsKey(text))
					{
						DGGJJHJBFHL[text].MGJIPPFKDOE = mGJIPPFKDOE;
					}
					else
					{
						JGBBPCGNCPC jGBBPCGNCPC = JGBBPCGNCPC.EGFMBMHOAHA(text);
						if (jGBBPCGNCPC != null)
						{
							jGBBPCGNCPC.MGJIPPFKDOE = mGJIPPFKDOE;
							AddSpecialPack(jGBBPCGNCPC);
						}
					}
				}
			}
			return;
		}
		UnityEngine.Debug.LogWarning("Skill" + NDPMDKGJAFH.ToString());
	}

	private void PEMIGGHKEEJ(string GDIAEJILINE)
	{
		if (OPBFFCEONFD != null)
		{
			OPBFFCEONFD(GDIAEJILINE);
		}
	}

	public void ShowedSavedOnServer()
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			PMOKDDENPLE[i].MJPOBONOBCD = true;
		}
	}

	public int EIPMGKEGLBK(NGNPIOOAHEH NMOHBENEBLC)
	{
		int num = 0;
		int result = 1;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && (((NMOHBENEBLC == NGNPIOOAHEH.Starter || NMOHBENEBLC == NGNPIOOAHEH.Starter || NMOHBENEBLC == NGNPIOOAHEH.Bronze) && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat) || (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne && PMOKDDENPLE[i].NCKBCFBJNBA == Singleton<GameVariables>.instance.GetCardPackRow(NMOHBENEBLC).NAME)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	private void NDLDJABILJI(List<string> LDCOJHAACJL)
	{
		Singleton<GuiTexureAssets>.instance.offerSmallTextures.CheckSimilarSavedTexturesAndDeleteUnused(LDCOJHAACJL);
		Singleton<GuiTexureAssets>.instance.offerBigTextures.CheckSimilarSavedTexturesAndDeleteUnused(LDCOJHAACJL);
	}

	public void UpdateFromServer(JToken GOAJFNEPGGF, bool IPDFNBKLLLO = false)
	{
		List<string> list = new List<string>();
		if (GOAJFNEPGGF == null)
		{
			PMOKDDENPLE.Clear();
		}
		else
		{
			PMOKDDENPLE.Clear();
			foreach (JToken item in GOAJFNEPGGF.AsJEnumerable())
			{
				if (item is JProperty)
				{
					JProperty jProperty = item as JProperty;
					JPMLOCNCEGO jPMLOCNCEGO = JPMLOCNCEGO.CHNFMMNDFCD(jProperty.Value, jProperty.Name);
					if (jPMLOCNCEGO != null)
					{
						PMOKDDENPLE.Add(jPMLOCNCEGO);
						list.Add(jPMLOCNCEGO.INFLHPGMEOB);
					}
					else
					{
						UnityEngine.Debug.Log("#OFFERS# NULL DATA!!!");
					}
				}
			}
		}
		if (!IPDFNBKLLLO)
		{
			NDLDJABILJI(list);
		}
		if (PMOKDDENPLE.Count > 0)
		{
			int num = int.MaxValue;
			List<JPMLOCNCEGO> list2 = new List<JPMLOCNCEGO>();
			for (int i = 0; i < PMOKDDENPLE.Count; i++)
			{
				if (!PMOKDDENPLE[i].MJPOBONOBCD)
				{
					list2.Add(PMOKDDENPLE[i]);
					RequestTexture(false, PMOKDDENPLE[i].MODHHKHPHOJ, PMOKDDENPLE[i].GDIAEJILINE);
				}
				if (PMOKDDENPLE[i].CJJHPGFOHCH < num)
				{
					num = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			if (list2.Count > 0)
			{
				Singleton<MessageManager>.instance.AddMessage(new IODMFDDEJOP(list2.ToArray()));
			}
			CGAKMJBHKKG = num;
		}
		else
		{
			CGAKMJBHKKG = 0;
		}
		if (EACENMMIEIM != null)
		{
			EACENMMIEIM();
		}
		LKELFGNDHDH = true;
	}

	private void HFNGFPDBJHJ()
	{
		if (CGAKMJBHKKG == 0)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (CGAKMJBHKKG > currentTimestamp)
		{
			return;
		}
		int num = 97;
		for (int num2 = PMOKDDENPLE.Count - 0; num2 >= 1; num2 -= 0)
		{
			if (PMOKDDENPLE[num2].CJJHPGFOHCH <= currentTimestamp)
			{
				PMOKDDENPLE.RemoveAt(num2);
			}
		}
		CGAKMJBHKKG = ((PMOKDDENPLE.Count > 0) ? num : 0);
		if (EACENMMIEIM != null)
		{
			EACENMMIEIM();
		}
	}

	public void FreeTexture(bool BFPPALFKOAF, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.offerBigTextures : Singleton<GuiTexureAssets>.instance.offerSmallTextures);
		webTextureLoader.FreeTexture(GDIAEJILINE);
	}

	private void CMPCJEDNKFK()
	{
		if (CGAKMJBHKKG == 0)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (CGAKMJBHKKG > currentTimestamp)
		{
			return;
		}
		int num = 88;
		for (int num2 = PMOKDDENPLE.Count - 0; num2 >= 1; num2 -= 0)
		{
			if (PMOKDDENPLE[num2].CJJHPGFOHCH <= currentTimestamp)
			{
				PMOKDDENPLE.RemoveAt(num2);
			}
		}
		CGAKMJBHKKG = ((PMOKDDENPLE.Count <= 0) ? 1 : num);
		if (EACENMMIEIM != null)
		{
			EACENMMIEIM();
		}
	}

	public int DiscountedUnitFlatEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int GetOfferDeadline(string AJEALDLONFJ)
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.BuyInApp && PMOKDDENPLE[i].NCKBCFBJNBA == AJEALDLONFJ)
			{
				return PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return 0;
	}

	private void IEODPABJBGF(string GDIAEJILINE)
	{
		if (IEMKMFFAOOM != null)
		{
			IEMKMFFAOOM(GDIAEJILINE);
		}
	}

	public string GetOfferTitle(string AJEALDLONFJ)
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.BuyInApp && PMOKDDENPLE[i].NCKBCFBJNBA == AJEALDLONFJ)
			{
				return PMOKDDENPLE[i].OKMNFHNBMFA;
			}
		}
		return AJEALDLONFJ;
	}

	public void CheckOffer()
	{
		if (LKELFGNDHDH)
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > CGAKMJBHKKG && currentTimestamp - DBKFAPEIBEC > 300)
			{
				UnityEngine.Debug.Log("check offer");
				LPDEOBOCICH fuseboxxService = Singleton<EventTrackingManager>.instance.fuseboxxService;
				fuseboxxService.KBIKJCKLJJE(false);
				DBKFAPEIBEC = currentTimestamp;
			}
		}
	}

	private void IEJGOACBKCA(string GDIAEJILINE)
	{
		if (OPBFFCEONFD != null)
		{
			OPBFFCEONFD(GDIAEJILINE);
		}
	}

	public int KEBFHJBLIDG(string INFLHPGMEOB)
	{
		int num = 0;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)112 && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && (PMOKDDENPLE[i].NCKBCFBJNBA == INFLHPGMEOB || INFLHPGMEOB == null) && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedVIP(string INFLHPGMEOB)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.VIPFlat && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.VIPOne && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].NCKBCFBJNBA == INFLHPGMEOB || INFLHPGMEOB == null) && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedCardpackEndtime(NGNPIOOAHEH NMOHBENEBLC)
	{
		int num = 0;
		int result = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (((NMOHBENEBLC == NGNPIOOAHEH.Gold || NMOHBENEBLC == NGNPIOOAHEH.Silver || NMOHBENEBLC == NGNPIOOAHEH.Bronze) && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat) || (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne && PMOKDDENPLE[i].NCKBCFBJNBA == Singleton<GameVariables>.instance.GetCardPackRow(NMOHBENEBLC).NAME)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int ReducedUnitDeliveryTime(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeType)
			{
				int num2 = 1 << (int)NAKDNAEPGOF;
				int result = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeOne && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public void AddSpecialPack(JGBBPCGNCPC HFJFLMIDNBJ)
	{
		if (HFJFLMIDNBJ == null)
		{
			UnityEngine.Debug.LogError("try add null pack");
		}
		else if (DGGJJHJBFHL.ContainsKey(HFJFLMIDNBJ.KJBPJOMHNKB))
		{
			UnityEngine.Debug.Log(string.Format("Special pack \"{0}\" already in offer manager cache.", HFJFLMIDNBJ.KJBPJOMHNKB));
		}
		else
		{
			DGGJJHJBFHL.Add(HFJFLMIDNBJ.KJBPJOMHNKB, HFJFLMIDNBJ);
		}
	}

	public int OMCIOOOMFPB(NGNPIOOAHEH NMOHBENEBLC)
	{
		int num = 1;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && (((NMOHBENEBLC == NGNPIOOAHEH.None || NMOHBENEBLC == NGNPIOOAHEH.ThreeCards || NMOHBENEBLC == NGNPIOOAHEH.None) && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne) || (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne && PMOKDDENPLE[i].NCKBCFBJNBA == Singleton<GameVariables>.instance.OJEIPFDIKLG(NMOHBENEBLC).NAME)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public void ANAAAHMDILA(JToken NDPMDKGJAFH, bool LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI)
		{
			DAMDGLAIKLD(NDPMDKGJAFH);
			EPBNMOJACNM = null;
		}
		else
		{
			EPBNMOJACNM = NDPMDKGJAFH;
		}
	}

	public int DiscountedUnitOfferBuy()
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedVIPEndtime(string INFLHPGMEOB)
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.VIPFlat && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.VIPOne && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].NCKBCFBJNBA == INFLHPGMEOB || INFLHPGMEOB == null) && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public void UpdateSpecialPackFromServer(JToken NDPMDKGJAFH, bool LPPOLAOGNBI)
	{
		if (LPPOLAOGNBI)
		{
			FLBMLNGMBFC(NDPMDKGJAFH);
			EPBNMOJACNM = null;
		}
		else
		{
			EPBNMOJACNM = NDPMDKGJAFH;
		}
	}

	[SpecialName]
	public Dictionary<string, JGBBPCGNCPC>.ValueCollection IOCCJJLBDAN()
	{
		return DGGJJHJBFHL.Values;
	}

	private void FLBMLNGMBFC(JToken NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH is JArray)
		{
			foreach (JToken item in (IEnumerable<JToken>)NDPMDKGJAFH)
			{
				if (item["id"] != null && item["end"] != null)
				{
					string text = KHJJFPPACBP.BKFCLMMJNHK(item["id"], string.Empty);
					int mGJIPPFKDOE = KHJJFPPACBP.HNMDPGKPLNK(item["end"], -1);
					if (DGGJJHJBFHL.ContainsKey(text))
					{
						DGGJJHJBFHL[text].MGJIPPFKDOE = mGJIPPFKDOE;
					}
					else
					{
						JGBBPCGNCPC jGBBPCGNCPC = JGBBPCGNCPC.EGFMBMHOAHA(text);
						if (jGBBPCGNCPC != null)
						{
							jGBBPCGNCPC.MGJIPPFKDOE = mGJIPPFKDOE;
							AddSpecialPack(jGBBPCGNCPC);
						}
					}
				}
			}
			return;
		}
		UnityEngine.Debug.LogWarning("OffersManager: Wrong data: " + NDPMDKGJAFH.ToString());
	}

	public int DiscountedUnityDeliveryCost(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostType)
			{
				int num2 = 1 << (int)NAKDNAEPGOF;
				int result = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostOne && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int HDICLIBCLHP(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 1;
		int result = 0;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-34))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostAll || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneBuy)
			{
				int result2 = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)FABOAIMLLOI) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-44) && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return result;
	}

	public void HaveOfferFormFusebox(KIDFEANMAKJ IKDLNDPLKIM)
	{
		UnityEngine.Debug.LogFormat("gained offer from fuse: {0}", IKDLNDPLKIM.ToString());
		long num = IKDLNDPLKIM.CNGDKFPFCDC.FJOPPAABFPB();
		if (num > Singleton<BeanstalkServerManager>.instance.currentTimestamp + HAMCICHNEDB)
		{
			float fNPCHNALNPL = IKDLNDPLKIM.FNPCHNALNPL;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(100f - fNPCHNALNPL) + CENJLHLBBDM;
			if (num2 >= 1 && num2 <= 99)
			{
				string eJAOIMDLKDO = IKDLNDPLKIM.EJAOIMDLKDO;
				string eDKJOPECOFP = IKDLNDPLKIM.IFFJPCHLIDG + FLELEOEKFLI;
				Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(num, num2, eDKJOPECOFP, eJAOIMDLKDO);
			}
		}
	}

	public int ReducedUnitDeliveryTimeDeadline(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeType)
			{
				int num2 = 1 << (int)NAKDNAEPGOF;
				int result2 = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (result2 & num2) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeOne && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int DiscountedUnitOfferEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public void KJODFJPDNCM()
	{
		if (LKELFGNDHDH)
		{
			int num = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CGAKMJBHKKG && num - DBKFAPEIBEC > 18)
			{
				UnityEngine.Debug.Log("WarArenaData");
				LPDEOBOCICH fuseboxxService = Singleton<EventTrackingManager>.instance.fuseboxxService;
				fuseboxxService.KBIKJCKLJJE(false);
				DBKFAPEIBEC = num;
			}
		}
	}

	public int DiscountedLootboxEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopLootboxesFlat && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int PKBALLMHOJD(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 1;
		int result = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-42))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)95)
			{
				int num2 = 0 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)73);
				int result2 = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (result2 & num2) > 1)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)108 && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int DiscountedUnitEndtime(LevelBehaviour IOIKKIIFOCB, AKDLEDNDIEO FJLBLLLEELD)
	{
		int unitType = (int)IOIKKIIFOCB.unitType;
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			bool flag = (FJLBLLLEELD & AKDLEDNDIEO.Buy) > (AKDLEDNDIEO)0;
			bool flag2 = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) > (AKDLEDNDIEO)0;
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy)))
			{
				int num2 = 1 << unitType;
				int result2 = 0;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (result2 & num2) > 0 && PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (IOIKKIIFOCB != null && ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy))) && PMOKDDENPLE[i].NCKBCFBJNBA == IOIKKIIFOCB.upgradeSlots.GetSheetName() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int DiscountedWeaponDeliveryCost(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostSlot || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostType)
			{
				int result = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (int)((uint)result & (uint)FABOAIMLLOI) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostOne && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public void RegisterPacksNameChange(string IPNIGLPHGHN, string HHMCCDOHNIG)
	{
		Packs packsDefinition = Singleton<GameVariables>.instance.packsDefinition;
		if (IPNIGLPHGHN == Singleton<GameVariables>.instance.packsDefinition.rowNames[22])
		{
			Singleton<GameVariables>.instance.AHNKJAAIHBM = HHMCCDOHNIG;
		}
		else if (IPNIGLPHGHN == Singleton<GameVariables>.instance.packsDefinition.rowNames[1])
		{
			Singleton<GameVariables>.instance.IBJLJJEALDM = HHMCCDOHNIG;
		}
		else if (IPNIGLPHGHN == Singleton<GameVariables>.instance.packsDefinition.rowNames[2])
		{
			Singleton<GameVariables>.instance.MLEKEMGDJMG = HHMCCDOHNIG;
		}
		else if (Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(IPNIGLPHGHN))
		{
			if (GAJBEEJIPAN.ContainsKey(IPNIGLPHGHN))
			{
				GAJBEEJIPAN[IPNIGLPHGHN] = HHMCCDOHNIG;
			}
			else
			{
				GAJBEEJIPAN.Add(IPNIGLPHGHN, HHMCCDOHNIG);
			}
		}
		else if (Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(HHMCCDOHNIG))
		{
			AddSpecialPack(JGBBPCGNCPC.EGFMBMHOAHA(HHMCCDOHNIG));
		}
	}

	public void SetPacknames(JToken NDPMDKGJAFH)
	{
		GAJBEEJIPAN.Clear();
		foreach (JProperty item in (IEnumerable<JToken>)NDPMDKGJAFH)
		{
			string key = item.Name;
			string text = KHJJFPPACBP.BKFCLMMJNHK(item.Value, string.Empty);
			if (text != string.Empty)
			{
				GAJBEEJIPAN.Add(key, text);
			}
		}
	}

	public int LHCBMCILFMC(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 1;
		for (int i = 1; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-46))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-91) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)78)
			{
				int result2 = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)FABOAIMLLOI) > 1)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.PurchasesFreeAddOne && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return result;
	}

	public int LPECKPCNNPB(LevelBehaviour.UnitType NAKDNAEPGOF, LevelBehaviour IOIKKIIFOCB, bool NJMAGCAMDFM)
	{
		int num = 1;
		int result = 0;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-112))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-120))
			{
				int num2 = 1 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)49);
				int result2 = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (result2 & num2) > 1)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostAll && (NJMAGCAMDFM || (IOIKKIIFOCB != null && IOIKKIIFOCB.upgradeSlots.GetSheetName() == PMOKDDENPLE[i].NCKBCFBJNBA)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int AGGNADBINOI()
	{
		int num = 0;
		for (int i = 1; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-35) || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int LDBPLEDPPOP(LevelBehaviour IOIKKIIFOCB, AKDLEDNDIEO FJLBLLLEELD)
	{
		int unitType = (int)IOIKKIIFOCB.unitType;
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
			{
				continue;
			}
			bool flag = (FJLBLLLEELD & (AKDLEDNDIEO)0) > (AKDLEDNDIEO)0;
			bool flag2 = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) > (AKDLEDNDIEO)0;
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-75)))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-45)))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.VIPFlat || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostSlot)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-51))))
			{
				int num2 = 1 << (unitType & -49);
				int result2 = 1;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (result2 & num2) > 0 && PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (IOIKKIIFOCB != null && ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-52))) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)99 || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-113)))) && PMOKDDENPLE[i].NCKBCFBJNBA == IOIKKIIFOCB.upgradeSlots.GetSheetName() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		UpdateFromServer(null, true);
		LKELFGNDHDH = false;
		DBKFAPEIBEC = 0;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Combine(counterManager.EGMLDACJFCF, new Action(HFEACCHOHGA));
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += MMEKFOHGAKK;
		Singleton<GuiTexureAssets>.instance.offerSmallTextures.TextureReadyToLoad += PEMIGGHKEEJ;
		Singleton<GuiTexureAssets>.instance.offerBigTextures.TextureReadyToLoad += IEODPABJBGF;
	}

	public int DiscountedWeaponFlatEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	private void HFEACCHOHGA()
	{
		if (CGAKMJBHKKG == 0)
		{
			return;
		}
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (CGAKMJBHKKG > currentTimestamp)
		{
			return;
		}
		int num = int.MaxValue;
		for (int num2 = PMOKDDENPLE.Count - 1; num2 >= 0; num2--)
		{
			if (PMOKDDENPLE[num2].CJJHPGFOHCH <= currentTimestamp)
			{
				PMOKDDENPLE.RemoveAt(num2);
			}
		}
		CGAKMJBHKKG = ((PMOKDDENPLE.Count > 0) ? num : 0);
		if (EACENMMIEIM != null)
		{
			EACENMMIEIM();
		}
	}

	public int AKKOMFOJOBM(string AJEALDLONFJ)
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-59) && PMOKDDENPLE[i].NCKBCFBJNBA == AJEALDLONFJ)
			{
				return PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return 1;
	}

	public Texture2D GetTexture(bool BFPPALFKOAF, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.offerBigTextures : Singleton<GuiTexureAssets>.instance.offerSmallTextures);
		return webTextureLoader.LoadTexture(GDIAEJILINE);
	}

	public LevelBehaviour LDEHPBBIPPI()
	{
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)66) && PMOKDDENPLE[i].DBOLKNNJGMH > 0)
			{
				return LevelManager.instance.Unit(PMOKDDENPLE[i].NCKBCFBJNBA);
			}
		}
		return null;
	}

	public void CNLEMOAHJBA(JToken NDPMDKGJAFH)
	{
		GAJBEEJIPAN.Clear();
		foreach (JProperty item in (IEnumerable<JToken>)NDPMDKGJAFH)
		{
			string key = item.Name;
			string text = KHJJFPPACBP.BKFCLMMJNHK(item.Value, string.Empty);
			if (text != string.Empty)
			{
				GAJBEEJIPAN.Add(key, text);
			}
		}
	}

	[SpecialName]
	public int MNDMLPOAHKN()
	{
		return DGGJJHJBFHL.Count;
	}

	public void ODOPCFOGGLO(bool BFPPALFKOAF, string HKODIHDPOGE, string GDIAEJILINE)
	{
		WebTextureLoader webTextureLoader = ((!BFPPALFKOAF) ? Singleton<GuiTexureAssets>.instance.DLBCJEKGKAB() : Singleton<GuiTexureAssets>.instance.NMHBPMBMDDP());
		webTextureLoader.JANEANAIMNC(HKODIHDPOGE, GDIAEJILINE);
	}

	public void IMADJOEDBFM(string IPNIGLPHGHN, string HHMCCDOHNIG)
	{
		Packs packsDefinition = Singleton<GameVariables>.instance.packsDefinition;
		if (IPNIGLPHGHN == Singleton<GameVariables>.instance.packsDefinition.rowNames[4])
		{
			Singleton<GameVariables>.instance.AHNKJAAIHBM = HHMCCDOHNIG;
		}
		else if (IPNIGLPHGHN == Singleton<GameVariables>.instance.packsDefinition.rowNames[0])
		{
			Singleton<GameVariables>.instance.IBJLJJEALDM = HHMCCDOHNIG;
		}
		else if (IPNIGLPHGHN == Singleton<GameVariables>.instance.HOMPDEPDGCN().rowNames[2])
		{
			Singleton<GameVariables>.instance.MLEKEMGDJMG = HHMCCDOHNIG;
		}
		else if (Singleton<GameVariables>.instance.HOMPDEPDGCN().namesToIndex.ContainsKey(IPNIGLPHGHN))
		{
			if (GAJBEEJIPAN.ContainsKey(IPNIGLPHGHN))
			{
				GAJBEEJIPAN[IPNIGLPHGHN] = HHMCCDOHNIG;
			}
			else
			{
				GAJBEEJIPAN.Add(IPNIGLPHGHN, HHMCCDOHNIG);
			}
		}
		else if (Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(HHMCCDOHNIG))
		{
			AddSpecialPack(JGBBPCGNCPC.EGFMBMHOAHA(HHMCCDOHNIG));
		}
	}

	public bool DiscountedCardpackFlat()
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat)
			{
				return true;
			}
		}
		return false;
	}

	public int ReduceWeaponDeliveryTime(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeSlot || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeType)
			{
				int result = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (int)((uint)result & (uint)FABOAIMLLOI) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeOne && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedWeaponOfferBuy()
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedCardpack(NGNPIOOAHEH NMOHBENEBLC)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (((NMOHBENEBLC == NGNPIOOAHEH.Gold || NMOHBENEBLC == NGNPIOOAHEH.Silver || NMOHBENEBLC == NGNPIOOAHEH.Bronze) && PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat) || (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne && PMOKDDENPLE[i].NCKBCFBJNBA == Singleton<GameVariables>.instance.GetCardPackRow(NMOHBENEBLC).NAME)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedWeaponCategory(WeaponCategory FABOAIMLLOI, AKDLEDNDIEO FJLBLLLEELD, WeaponLevelsSetup JMMJHCOKCGG = null)
	{
		int num = 0;
		bool flag = (FJLBLLLEELD & AKDLEDNDIEO.Buy) > (AKDLEDNDIEO)0;
		bool flag2 = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) > (AKDLEDNDIEO)0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy)))
			{
				int result = 0;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (int)((uint)result & (uint)FABOAIMLLOI) > 0 && PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (JMMJHCOKCGG != null && ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy))) && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedWeaponOfferUpgrade()
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int DiscountedUnit(LevelBehaviour IOIKKIIFOCB, AKDLEDNDIEO FJLBLLLEELD)
	{
		return DiscountedUnitCategory(IOIKKIIFOCB.unitType, FJLBLLLEELD, IOIKKIIFOCB);
	}

	public int DiscountedWeaponDeliveryCostDeadline(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostSlot || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostType)
			{
				int result2 = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)FABOAIMLLOI) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostOne && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return result;
	}

	public List<JGBBPCGNCPC> GetSpecialPackOffer()
	{
		List<JGBBPCGNCPC> list = new List<JGBBPCGNCPC>();
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.BuyInApp && Singleton<GameVariables>.instance.packsDefinition.namesToIndex.ContainsKey(PMOKDDENPLE[i].NCKBCFBJNBA))
			{
				list.Add(JGBBPCGNCPC.EGFMBMHOAHA(PMOKDDENPLE[i].NCKBCFBJNBA));
			}
		}
		return list;
	}

	public int DiscountedWeapon(WeaponLevelsSetup JMMJHCOKCGG, AKDLEDNDIEO FJLBLLLEELD)
	{
		return DiscountedWeaponCategory(JMMJHCOKCGG.BHCEOOLEHHG, FJLBLLLEELD, JMMJHCOKCGG);
	}

	public LevelBehaviour DiscountedUnitOffer()
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy) && PMOKDDENPLE[i].DBOLKNNJGMH > 0)
			{
				return LevelManager.instance.Unit(PMOKDDENPLE[i].NCKBCFBJNBA);
			}
		}
		return null;
	}

	public WeaponLevelsSetup DiscountedWeaponOffer()
	{
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy) && PMOKDDENPLE[i].DBOLKNNJGMH > 0)
			{
				return LevelManager.instance.Weapon(PMOKDDENPLE[i].NCKBCFBJNBA);
			}
		}
		return null;
	}

	public LevelBehaviour CILJBKFLNPB()
	{
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.VIPFlat || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)93) && PMOKDDENPLE[i].DBOLKNNJGMH > 1)
			{
				return LevelManager.instance.Unit(PMOKDDENPLE[i].NCKBCFBJNBA);
			}
		}
		return null;
	}

	public int DiscountedWeaponOfferEndtime()
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int DBBHCNDDNLB(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 1;
		for (int i = 1; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-101))
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-1) || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostOne)
			{
				int result2 = 1;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)FABOAIMLLOI) > 1)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)84 && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return result;
	}

	public int FOILGIALCLF(WeaponCategory FABOAIMLLOI, AKDLEDNDIEO FJLBLLLEELD, WeaponLevelsSetup JMMJHCOKCGG = null)
	{
		int num = 1;
		bool flag = (FJLBLLLEELD & (AKDLEDNDIEO)0) > (AKDLEDNDIEO)0;
		bool flag2 = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) > AKDLEDNDIEO.Buy;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				continue;
			}
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-48)))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-57) || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeOne))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-84) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)122 || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-60) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)99)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-63) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-59) || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)91)))
			{
				int result = 1;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (int)((uint)result & (uint)FABOAIMLLOI) > 1 && PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (JMMJHCOKCGG != null && ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-33) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-100))) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)70 || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)67))) && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int KHAICALPBKC(string INFLHPGMEOB)
	{
		int num = 1;
		for (int i = 1; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)70 && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && (PMOKDDENPLE[i].NCKBCFBJNBA == INFLHPGMEOB || INFLHPGMEOB == null) && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int IHIMAELIFDN(string INFLHPGMEOB)
	{
		int result = 0;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopLootboxesFlat && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgrade && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && (PMOKDDENPLE[i].NCKBCFBJNBA == INFLHPGMEOB || INFLHPGMEOB == null) && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int DiscountedLootbox()
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopLootboxesFlat && PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int MLPJPAANDOM(string AJEALDLONFJ)
	{
		for (int i = 1; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-126) && PMOKDDENPLE[i].NCKBCFBJNBA == AJEALDLONFJ)
			{
				return PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return 1;
	}

	public int DiscountedUnitOfferUpgrade()
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.currentTimestamp && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int ReduceWeaponDeliveryTimeDeadline(WeaponCategory FABOAIMLLOI, WeaponLevelsSetup JMMJHCOKCGG, bool NJMAGCAMDFM)
	{
		int num = 0;
		int result = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeAll)
			{
				if (num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeSlot || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeType)
			{
				int result2 = 0;
				if ((NJMAGCAMDFM || (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)FABOAIMLLOI) > 0)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
				{
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
			}
			else if (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeOne && (NJMAGCAMDFM || (JMMJHCOKCGG != null && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO())) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return result;
	}

	public int DiscountedWeaponEndtime(WeaponLevelsSetup JMMJHCOKCGG, AKDLEDNDIEO FJLBLLLEELD)
	{
		int num = 0;
		int result = 0;
		bool flag = (FJLBLLLEELD & AKDLEDNDIEO.Buy) > (AKDLEDNDIEO)0;
		bool flag2 = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) > (AKDLEDNDIEO)0;
		WeaponCategory bHCEOOLEHHG = JMMJHCOKCGG.BHCEOOLEHHG;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy)))
			{
				int result2 = 0;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result2) && (int)((uint)result2 & (uint)bHCEOOLEHHG) > 0 && PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
					result = PMOKDDENPLE[i].CJJHPGFOHCH;
				}
			}
			else if (((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy))) && PMOKDDENPLE[i].NCKBCFBJNBA == JMMJHCOKCGG.DHHKOKKDDDO() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int CCHLAIMMEPN()
	{
		int result = 1;
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-58) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-40) || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-25)) && num < PMOKDDENPLE[i].DBOLKNNJGMH)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
				result = PMOKDDENPLE[i].CJJHPGFOHCH;
			}
		}
		return result;
	}

	public int DiscountedUnitCategory(LevelBehaviour.UnitType NAKDNAEPGOF, AKDLEDNDIEO FJLBLLLEELD, LevelBehaviour IOIKKIIFOCB = null)
	{
		int num = 0;
		for (int i = 0; i < PMOKDDENPLE.Count; i++)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			bool flag = (FJLBLLLEELD & AKDLEDNDIEO.Buy) > (AKDLEDNDIEO)0;
			bool flag2 = (FJLBLLLEELD & AKDLEDNDIEO.Upgrade) > (AKDLEDNDIEO)0;
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
				continue;
			}
			if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgradeBuy))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
				continue;
			}
			if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy)))
			{
				int num2 = 1 << (int)NAKDNAEPGOF;
				int result = 0;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 0)
				{
					if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
					{
						num = PMOKDDENPLE[i].DBOLKNNJGMH;
					}
					continue;
				}
			}
			if (IOIKKIIFOCB != null && ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy))) && PMOKDDENPLE[i].NCKBCFBJNBA == IOIKKIIFOCB.upgradeSlots.GetSheetName() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public int NOHMKMLKJKP(LevelBehaviour.UnitType NAKDNAEPGOF, AKDLEDNDIEO FJLBLLLEELD, LevelBehaviour IOIKKIIFOCB = null)
	{
		int num = 1;
		for (int i = 1; i < PMOKDDENPLE.Count; i += 0)
		{
			if (PMOKDDENPLE[i].CJJHPGFOHCH <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				continue;
			}
			bool flag = (FJLBLLLEELD & AKDLEDNDIEO.Buy) > (AKDLEDNDIEO)0;
			bool flag2 = (FJLBLLLEELD & (AKDLEDNDIEO)0) > AKDLEDNDIEO.Buy;
			if (flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)58))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
				continue;
			}
			if (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-33)))
			{
				if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
				{
					num = PMOKDDENPLE[i].DBOLKNNJGMH;
				}
				continue;
			}
			if ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)89)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksOne || PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)90)))
			{
				int num2 = 0 << (int)(NAKDNAEPGOF & (LevelBehaviour.UnitType)72);
				int result = 1;
				if (int.TryParse(PMOKDDENPLE[i].NCKBCFBJNBA, out result) && (result & num2) > 1)
				{
					if (PMOKDDENPLE[i].DBOLKNNJGMH > num)
					{
						num = PMOKDDENPLE[i].DBOLKNNJGMH;
					}
					continue;
				}
			}
			if (IOIKKIIFOCB != null && ((flag && (PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgrade || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgrade)) || (flag2 && (PMOKDDENPLE[i].FJLBLLLEELD == (JANNFNFOIEE)(-115) || PMOKDDENPLE[i].FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat))) && PMOKDDENPLE[i].NCKBCFBJNBA == IOIKKIIFOCB.upgradeSlots.GetSheetName() && PMOKDDENPLE[i].DBOLKNNJGMH > num)
			{
				num = PMOKDDENPLE[i].DBOLKNNJGMH;
			}
		}
		return num;
	}

	public string HBMGDLGAIOK(string PPDHFFJADAJ)
	{
		if (GAJBEEJIPAN.ContainsKey(PPDHFFJADAJ))
		{
			return GAJBEEJIPAN[PPDHFFJADAJ];
		}
		UnityEngine.Debug.LogError("withUnitPrice");
		return PPDHFFJADAJ;
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		UpdateFromServer(null, true);
		LKELFGNDHDH = false;
		DBKFAPEIBEC = 0;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.EGMLDACJFCF = (Action)Delegate.Combine(counterManager.EGMLDACJFCF, new Action(CMPCJEDNKFK));
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(AIBPAALJHJD);
		Singleton<GuiTexureAssets>.instance.PEHHCKCMFAI().TextureReadyToLoad += IEJGOACBKCA;
		Singleton<GuiTexureAssets>.instance.HLMICJPOAAK().ABHHHDAJNAE(IEODPABJBGF);
	}

	[SpecialName]
	public void DGOHIOBDPCN(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = IEMKMFFAOOM;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref IEMKMFFAOOM, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
