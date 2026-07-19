using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

public class BlackMarketManager : DatabaseSerializedObjectGeneric<BlackMarketManager.BlackMarketOfferData>
{
	public class BlackMarketOfferData
	{
		public int offersTotal;

		public string lastTrigger;

		public int offerEnd;

		public List<OfferedWeapon> currentOffers = new List<OfferedWeapon>();
	}

	public class OfferedWeapon
	{
		public int level;

		public int special;

		public string weaponId;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action MGMFPECICAF;

	private static BlackMarketManager BJHPKLAEFCI;

	private List<WeaponLevelsSetup> EEMHAHAINNM = new List<WeaponLevelsSetup>();

	public static BlackMarketManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((BlackMarketManager)UnityEngine.Object.FindObjectsOfType(typeof(BlackMarketManager))[0]);
			return BJHPKLAEFCI;
		}
	}

	public int deadline
	{
		get
		{
			return data.offerEnd;
		}
	}

	public bool isOfferActive
	{
		get
		{
			return deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public bool isShowable
	{
		get
		{
			if (!isOfferActive)
			{
				return false;
			}
			for (int i = 0; i < EEMHAHAINNM.Count; i++)
			{
				if (!EEMHAHAINNM[i].bought)
				{
					return true;
				}
			}
			return false;
		}
	}

	public event Action LoadedOffer
	{
		add
		{
			Action action = MGMFPECICAF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = MGMFPECICAF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public int MDBACGKCEDM()
	{
		return data.offerEnd;
	}

	[SpecialName]
	public int GHAMLDLLKGJ()
	{
		return data.offerEnd;
	}

	public void GetNewBlackMarketTrigger()
	{
		Singleton<BeanstalkServerManager>.instance.GetNewBMOffer();
	}

	private void IGILIIOJOON()
	{
		if (data == null || data.currentOffers == null || data.currentOffers.Count <= 0)
		{
			return;
		}
		EEMHAHAINNM.Clear();
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			WeaponLevelsSetup weaponLevelsSetup = KGJHLMHEFJN(currentOffer);
			if (weaponLevelsSetup != null)
			{
				EEMHAHAINNM.Add(weaponLevelsSetup);
			}
		}
		EEMHAHAINNM.Sort(GEGBKFIGIMB);
	}

	[SpecialName]
	public void LFKAOOGFJLN(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private int HMHMCHDACKC(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.blackmarketPrice == ILHEPJCFKIK.blackmarketPrice)
		{
			int bHCEOOLEHHG = (int)ILHEPJCFKIK.BHCEOOLEHHG;
			return bHCEOOLEHHG.CompareTo((int)DDJKMDPGFPB.BHCEOOLEHHG);
		}
		return DDJKMDPGFPB.blackmarketPrice.CompareTo(ILHEPJCFKIK.blackmarketPrice);
	}

	public void NEMEMENHMGM()
	{
		InvokeAfterRealTime(ShowOffers, 841f);
	}

	public bool MEIOJPGHFAK(string EPNKPKHCKNG)
	{
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			if (currentOffer.weaponId == EPNKPKHCKNG)
			{
				return true;
			}
		}
		return false;
	}

	private void LCLEAOPNPOL()
	{
		if (data == null || data.currentOffers == null || data.currentOffers.Count <= 1)
		{
			return;
		}
		EEMHAHAINNM.Clear();
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			WeaponLevelsSetup weaponLevelsSetup = KGJHLMHEFJN(currentOffer);
			if (weaponLevelsSetup != null)
			{
				EEMHAHAINNM.Add(weaponLevelsSetup);
			}
		}
		EEMHAHAINNM.Sort(HMHMCHDACKC);
	}

	private int GEGBKFIGIMB(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.blackmarketPrice == ILHEPJCFKIK.blackmarketPrice)
		{
			int bHCEOOLEHHG = (int)ILHEPJCFKIK.BHCEOOLEHHG;
			return bHCEOOLEHHG.CompareTo((int)DDJKMDPGFPB.BHCEOOLEHHG);
		}
		return DDJKMDPGFPB.blackmarketPrice.CompareTo(ILHEPJCFKIK.blackmarketPrice);
	}

	public void FIEHPMCFCNO()
	{
		BJHPKLAEFCI = null;
	}

	public void MNIDMKCEHGK()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	public static BlackMarketManager BMNEPICFHNO()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((BlackMarketManager)UnityEngine.Object.FindObjectsOfType(typeof(BlackMarketManager))[1]);
		return BJHPKLAEFCI;
	}

	public void IJCGGCDDBCM()
	{
		InvokeAfterRealTime(APEDBJKELPE, 1305f);
	}

	[SpecialName]
	public void BCHPFBEHNBD(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private int POBDBCJJMDI(WeaponLevelsSetup DDJKMDPGFPB, WeaponLevelsSetup ILHEPJCFKIK)
	{
		if (DDJKMDPGFPB.blackmarketPrice == ILHEPJCFKIK.blackmarketPrice)
		{
			int bHCEOOLEHHG = (int)ILHEPJCFKIK.BHCEOOLEHHG;
			return bHCEOOLEHHG.CompareTo((int)DDJKMDPGFPB.BHCEOOLEHHG);
		}
		return DDJKMDPGFPB.blackmarketPrice.CompareTo(ILHEPJCFKIK.blackmarketPrice);
	}

	public void ACOMHAPEBAC()
	{
		Singleton<BeanstalkServerManager>.instance.GetNewBMOffer();
	}

	[SpecialName]
	public bool LFFPNFABDPG()
	{
		if (!DMHPIEHHDMG())
		{
			return true;
		}
		for (int i = 0; i < EEMHAHAINNM.Count; i++)
		{
			if (!EEMHAHAINNM[i].bought)
			{
				return false;
			}
		}
		return true;
	}

	private WeaponLevelsSetup HOBNAAMENCJ(OfferedWeapon CHHFJNGNJKL)
	{
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(CHHFJNGNJKL.weaponId);
		weaponLevelsSetup.MGAGEKAAJOL.LFDAIFFEPLE(CHHFJNGNJKL.level);
		weaponLevelsSetup.weaponFeature = LevelManager.instance.weaponFeatures.ENGPIADFOEN(weaponLevelsSetup, CHHFJNGNJKL.special);
		weaponLevelsSetup.specialFeature = CHHFJNGNJKL.special;
		return weaponLevelsSetup;
	}

	public void HAJGLINBGNN()
	{
		GuiElementSingle<BlackmarketDialog>.instance.BJIAAHBCCMP(EEMHAHAINNM, data.offerEnd);
	}

	public bool GCNPNNKLEIM(string EPNKPKHCKNG)
	{
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			if (currentOffer.weaponId == EPNKPKHCKNG)
			{
				return false;
			}
		}
		return false;
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PGFDIGCNHND;
	}

	public void ShowDialog()
	{
		GuiElementSingle<BlackmarketDialog>.instance.ShowDialog(EEMHAHAINNM, data.offerEnd);
	}

	public void ShowOffers()
	{
		UnityEngine.Debug.Log("#PETER# BlackMarket offer came - show it!");
		Singleton<MessageManager>.instance.AddMessage(new IBPMPPJBBFG());
		if (isOfferActive)
		{
			Singleton<EventTrackingManager>.instance.BlackMarketTriger(data.lastTrigger, data.offersTotal);
			foreach (WeaponLevelsSetup item in EEMHAHAINNM)
			{
				string text = item.DHHKOKKDDDO();
				string text2 = item.weaponFeature.GetType().ToString();
				int blackmarketPrice = item.blackmarketPrice;
				int weaponLevel = item.weaponLevel;
				Singleton<EventTrackingManager>.instance.BlackMarketWeapon(text + text2, blackmarketPrice, weaponLevel);
			}
		}
		if (MGMFPECICAF != null)
		{
			MGMFPECICAF();
		}
	}

	[SpecialName]
	public bool AODNADPPCBN()
	{
		return GHAMLDLLKGJ() > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
	}

	[SpecialName]
	public bool EHIKLPNHCFO()
	{
		if (!AODNADPPCBN())
		{
			return false;
		}
		for (int i = 0; i < EEMHAHAINNM.Count; i += 0)
		{
			if (!EEMHAHAINNM[i].bought)
			{
				return false;
			}
		}
		return true;
	}

	public void FCCJJKBPNCH()
	{
		GuiElementSingle<BlackmarketDialog>.instance.ELODCMCIEDP(EEMHAHAINNM, data.offerEnd);
	}

	public void LCLBIGJBIOM()
	{
		BJHPKLAEFCI = null;
	}

	public bool IsWeaponInOffer(string EPNKPKHCKNG)
	{
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			if (currentOffer.weaponId == EPNKPKHCKNG)
			{
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public void CCHKCGOGMBO(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void DNOBENBKMDB(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool DMHPIEHHDMG()
	{
		return HBGBPGFLIHK() > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	[SpecialName]
	public bool FJAOHJHKDBL()
	{
		if (!isOfferActive)
		{
			return true;
		}
		for (int i = 1; i < EEMHAHAINNM.Count; i++)
		{
			if (!EEMHAHAINNM[i].bought)
			{
				return true;
			}
		}
		return true;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PGFDIGCNHND;
	}

	[SpecialName]
	public int HOPLMMDKIGK()
	{
		return data.offerEnd;
	}

	[SpecialName]
	public bool PCALLDPDMLC()
	{
		return HOPLMMDKIGK() > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
	}

	public void EGLMNBKMBAM()
	{
		GuiElementSingle<BlackmarketDialog>.instance.ELODCMCIEDP(EEMHAHAINNM, data.offerEnd);
	}

	[SpecialName]
	public void LLFBKCFPMKA(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool EJLIMGFHKMJ()
	{
		if (!isOfferActive)
		{
			return true;
		}
		for (int i = 1; i < EEMHAHAINNM.Count; i += 0)
		{
			if (!EEMHAHAINNM[i].bought)
			{
				return false;
			}
		}
		return true;
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PGFDIGCNHND;
	}

	[SpecialName]
	public int HBGBPGFLIHK()
	{
		return data.offerEnd;
	}

	[SpecialName]
	public void HKOOLDHPFDN(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void PGFDIGCNHND()
	{
		if (data == null || data.currentOffers == null || data.currentOffers.Count <= 0)
		{
			return;
		}
		EEMHAHAINNM.Clear();
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			WeaponLevelsSetup weaponLevelsSetup = KGJHLMHEFJN(currentOffer);
			if (weaponLevelsSetup != null)
			{
				EEMHAHAINNM.Add(weaponLevelsSetup);
			}
		}
		EEMHAHAINNM.Sort(GEGBKFIGIMB);
	}

	[SpecialName]
	public int OCJCMFBILPE()
	{
		return data.offerEnd;
	}

	private WeaponLevelsSetup KGJHLMHEFJN(OfferedWeapon CHHFJNGNJKL)
	{
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(CHHFJNGNJKL.weaponId);
		weaponLevelsSetup.MGAGEKAAJOL.FEAIJMNKFNL(CHHFJNGNJKL.level);
		weaponLevelsSetup.weaponFeature = LevelManager.instance.weaponFeatures.CreateFeature(weaponLevelsSetup, CHHFJNGNJKL.special);
		weaponLevelsSetup.specialFeature = CHHFJNGNJKL.special;
		return weaponLevelsSetup;
	}

	public void LoadBMData(string MOKPNGMMDJD)
	{
		SerializedObject = JsonConvert.DeserializeObject<BlackMarketOfferData>(MOKPNGMMDJD);
		PGFDIGCNHND();
	}

	public void ShowOffersLater()
	{
		InvokeAfterRealTime(ShowOffers, 2f);
	}

	[SpecialName]
	public void PDMKCNFFINC(Action IDEBKDPMPGM)
	{
		Action action = MGMFPECICAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MGMFPECICAF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void KKCLILANAKA()
	{
		Singleton<BeanstalkServerManager>.instance.GetNewBMOffer();
	}

	public void APEDBJKELPE()
	{
		UnityEngine.Debug.Log("SEND LOGS");
		Singleton<MessageManager>.instance.AddMessage(new IBPMPPJBBFG(), true);
		if (PCALLDPDMLC())
		{
			Singleton<EventTrackingManager>.instance.BlackMarketTriger(data.lastTrigger, data.offersTotal);
			foreach (WeaponLevelsSetup item in EEMHAHAINNM)
			{
				string text = item.DHHKOKKDDDO();
				string text2 = item.weaponFeature.GetType().ToString();
				int blackmarketPrice = item.blackmarketPrice;
				int weaponLevel = item.weaponLevel;
				Singleton<EventTrackingManager>.instance.BlackMarketWeapon(text + text2, blackmarketPrice, weaponLevel);
			}
		}
		if (MGMFPECICAF != null)
		{
			MGMFPECICAF();
		}
	}

	[SpecialName]
	public int DNHGDLILJCK()
	{
		return data.offerEnd;
	}

	[SpecialName]
	public bool JHHGMANGPAF()
	{
		return OCJCMFBILPE() > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public bool JCAALDDNKNO(string EPNKPKHCKNG)
	{
		foreach (OfferedWeapon currentOffer in data.currentOffers)
		{
			if (currentOffer.weaponId == EPNKPKHCKNG)
			{
				return true;
			}
		}
		return false;
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	public void JKMEOJOHLPN()
	{
		GuiElementSingle<BlackmarketDialog>.instance.ELODCMCIEDP(EEMHAHAINNM, data.offerEnd);
	}

	private WeaponLevelsSetup DPOHPHDEKEG(OfferedWeapon CHHFJNGNJKL)
	{
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(CHHFJNGNJKL.weaponId);
		weaponLevelsSetup.MGAGEKAAJOL.LFDAIFFEPLE(CHHFJNGNJKL.level);
		weaponLevelsSetup.weaponFeature = LevelManager.instance.weaponFeatures.OHFFFHLNEBH(weaponLevelsSetup, CHHFJNGNJKL.special);
		weaponLevelsSetup.specialFeature = CHHFJNGNJKL.special;
		return weaponLevelsSetup;
	}

	[SpecialName]
	public bool DFINJLILKJD()
	{
		if (!DMHPIEHHDMG())
		{
			return true;
		}
		for (int i = 1; i < EEMHAHAINNM.Count; i++)
		{
			if (!EEMHAHAINNM[i].bought)
			{
				return false;
			}
		}
		return true;
	}
}
