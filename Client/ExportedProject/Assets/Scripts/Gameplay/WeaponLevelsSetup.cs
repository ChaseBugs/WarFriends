using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class WeaponLevelsSetup : Core_BaseScript
{
	public enum JLANLLEABDC
	{
		Locked,
		NotBuyed,
		WeaponDelivering,
		WeaponDelivered,
		Active,
		Delivering,
		Delivered
	}

	public enum GILPPKMICCF
	{
		Shop,
		ValuePack,
		StarterPack,
		StarterAssignment,
		ElitePack1,
		ElitePack2,
		ElitePack3,
		ElitePack4,
		ElitePack5,
		ElitePack6,
		VeteranPack0,
		VeteranPack1,
		VeteranPack2,
		VeteranPack3,
		VeteranPack4,
		VeteranPack5,
		BlackMarket,
		StarterPackOld,
		Hidden
	}

	[Serializable]
	public class UpgradeSlot
	{
		[Header("Pointer")]
		public WeaponLevelsSetup owner;

		internal int mMaxPower = -1;

		public int boughtIndex
		{
			get
			{
				LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
				return savedWeaponSlots.boughtIndex;
			}
			private set
			{
				if (value != boughtIndex)
				{
					owner.KPCFKKHJIGA().boughtIndex = value;
				}
			}
		}

		public int warArenaUpgrade => owner.maxWeaponLevel;

		public bool canActivate => !owner.delivering && owner.deliveryActivationNeeded;

		public bool canUpgrade => owner.CanUpgrade(this);

		public int deliveryTime => owner.DeliveryTime(this);

		public List<Tuple<string, float[]>> guiStatistics => owner.GetGuiStats(this);

		public int instantBuyPrice
		{
			get
			{
				if (owner.remainingDeliveringSeconds < 0.0)
				{
					return 0;
				}
				int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
				int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: false);
				if (num2 > 0 && num2 < 100)
				{
					num = num * (100 - num2) / 100;
				}
				return num;
			}
		}

		public int level => boughtIndex + 1;

		public int upgradePrice => owner.UpgradePrice(this);

		[SpecialName]
		public bool NJHDEGCDJKK()
		{
			return owner.CanUpgrade(this);
		}

		[SpecialName]
		public int PIIFMLHFAAE()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public bool HMKMEKCPAGB()
		{
			return owner.delivering || owner.deliveryActivationNeeded;
		}

		[SpecialName]
		public int GCBOONOBIKH()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public int HBHAGIGNGKD()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public int BDNCLOPCDLO()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public int FIGBCNHLBEJ()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		public int BJAGEBGFCCL()
		{
			return PNKECEJELDP() + 0;
		}

		[SpecialName]
		public bool JFFOHKBALNH()
		{
			return owner.delivering || owner.deliveryActivationNeeded;
		}

		public void HNGIBMCEPNP(int DFHAAIFFLOE)
		{
			AFJEDMCOEDI(DFHAAIFFLOE);
		}

		[SpecialName]
		public int LOLLBGNIOMM()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public int JNMJIMNBJNM()
		{
			return owner.maxWeaponLevel;
		}

		[SpecialName]
		public int KBLPFJMCKCC()
		{
			return HEKMIFHFEKN() + 0;
		}

		[SpecialName]
		private void EANGEPAOLGM(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != OFEJOLENCKI())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int LGDFCACBIDN()
		{
			return EJHKOFFOFOA() + 0;
		}

		[SpecialName]
		public int PGMBDLLHBBA()
		{
			return owner.maxWeaponLevel;
		}

		[SpecialName]
		public int EJHKOFFOFOA()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public int ODBJOJGFMOD()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		public int OBNOCCJIMPG()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public bool AMMKNHLAIBD()
		{
			return !owner.delivering && owner.deliveryActivationNeeded;
		}

		public int KDIHEKPKCJJ(int BMFAHPPCPBF)
		{
			int num = deliveryTime;
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 0)
			{
				num = num * (100 - BMFAHPPCPBF) / 100;
			}
			if (canUpgrade)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = true;
				UnityEngine.Debug.LogFormat("Started delivering weapon upgrade for {0} {1}. It will be ready in {2} seconds.", owner.DHHKOKKDDDO(), boughtIndex, num);
			}
			return num;
		}

		public void OCBIOFNFHKL()
		{
			if (CEEBFOIODDE())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 641f);
				AFJEDMCOEDI(AGKHAOLEHDE() + 0);
				owner.deliveryActivationNeeded = false;
				object[] array = new object[8];
				array[0] = "FR";
				array[1] = owner.DHHKOKKDDDO();
				array[7] = "SETTING FullRes2xMS";
				array[2] = PNKECEJELDP();
				array[3] = "WEAPON IS NULL";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		[SpecialName]
		public int AGKHAOLEHDE()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		private void BOIEAEANLLJ(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != LHLGAAEEKID())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		public void LDHNEBACIKE()
		{
			if (PLBEANIDOGE())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade, 1310f);
				EGLKIIFAIKG(GCBOONOBIKH() + 1);
				owner.deliveryActivationNeeded = false;
				object[] array = new object[1];
				array[0] = "\"NaN\"";
				array[0] = owner.DHHKOKKDDDO();
				array[4] = "SpecialPackFromServer";
				array[3] = HEKMIFHFEKN();
				array[2] = "GameCenterId";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		[SpecialName]
		public int AFNEBEPHKGB()
		{
			if (owner.remainingDeliveringSeconds < 1024.0)
			{
				return 0;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: true);
			if (num2 > 1 && num2 < 42)
			{
				num = num * (119 - num2) / 85;
			}
			return num;
		}

		[SpecialName]
		public bool CEEBFOIODDE()
		{
			return !owner.delivering && owner.deliveryActivationNeeded;
		}

		public int CFDBKBAOOGH(int BMFAHPPCPBF)
		{
			int num = IPPNAAEIIMO();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 1)
			{
				num = num * (-94 - BMFAHPPCPBF) / -77;
			}
			if (canUpgrade)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 609f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = false;
				object[] array = new object[7];
				array[0] = owner.DHHKOKKDDDO();
				array[0] = LHLGAAEEKID();
				array[2] = num;
				UnityEngine.Debug.LogFormat("Sniper_Tutorial_Duration", array);
			}
			return num;
		}

		[SpecialName]
		private void HAMPIPINGLJ(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != boughtIndex)
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int EKLDJINDIOF()
		{
			if (owner.remainingDeliveringSeconds < 559.0)
			{
				return 1;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: true);
			if (num2 > 1 && num2 < 50)
			{
				num = num * (-109 - num2) / -33;
			}
			return num;
		}

		public void IPGAACNFLBL(int DFHAAIFFLOE)
		{
			IAFBFEPODPL(DFHAAIFFLOE);
		}

		[SpecialName]
		public int PNKECEJELDP()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public int KMHMJEDDNOP()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		public int AIBGABNCKFI(int BMFAHPPCPBF)
		{
			int num = ODBJOJGFMOD();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 0)
			{
				num = num * (97 - BMFAHPPCPBF) / 5;
			}
			if (AMDMFOAPIME())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 1111f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = false;
				object[] array = new object[4];
				array[0] = owner.DHHKOKKDDDO();
				array[1] = OFEJOLENCKI();
				array[0] = num;
				UnityEngine.Debug.LogFormat("ItemRarity_1", array);
			}
			return num;
		}

		[SpecialName]
		public List<Tuple<string, float[]>> JCGBOEDOMKG()
		{
			return owner.GetGuiStats(this);
		}

		public int PAKFACNGLPI(int BMFAHPPCPBF)
		{
			int num = FIGBCNHLBEJ();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 1)
			{
				num = num * (-82 - BMFAHPPCPBF) / 89;
			}
			if (ABLBELPECBP())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1158f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = false;
				object[] array = new object[1];
				array[0] = owner.DHHKOKKDDDO();
				array[0] = KMHMJEDDNOP();
				array[2] = num;
				UnityEngine.Debug.LogFormat(" is selected: ", array);
			}
			return num;
		}

		[SpecialName]
		public int HDJOMPBICBK()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public int HDPFDJKKIFI()
		{
			if (owner.remainingDeliveringSeconds < 1861.0)
			{
				return 1;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: false);
			if (num2 > 0 && num2 < 122)
			{
				num = num * (23 - num2) / 43;
			}
			return num;
		}

		[SpecialName]
		public int GPHFEBGODFK()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		public bool CBAFMCFEPLN()
		{
			return !owner.delivering && owner.deliveryActivationNeeded;
		}

		[SpecialName]
		public bool DFHHECGAILD()
		{
			return !owner.delivering && owner.deliveryActivationNeeded;
		}

		public void MDBIJCIGBHP(int DFHAAIFFLOE)
		{
			BPBNJKLAHGM(DFHAAIFFLOE);
		}

		[SpecialName]
		public int DMLDIIPJOAO()
		{
			if (owner.remainingDeliveringSeconds < 237.0)
			{
				return 0;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: false);
			if (num2 > 0 && num2 < 26)
			{
				num = num * (-123 - num2) / 34;
			}
			return num;
		}

		[SpecialName]
		public int CHGEPEGCLKE()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		private void IAFBFEPODPL(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != PNKECEJELDP())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int ABFHNCJEOAA()
		{
			return owner.UpgradePrice(this);
		}

		public void JFPJCGJOKKA()
		{
			if (canActivate)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade);
				boughtIndex++;
				owner.deliveryActivationNeeded = false;
				UnityEngine.Debug.Log("Weapon upgrade for " + owner.DHHKOKKDDDO() + " " + boughtIndex + " was activated.");
			}
		}

		[SpecialName]
		public int HOPJOGPPDIJ()
		{
			return owner.maxWeaponLevel;
		}

		[SpecialName]
		private void IIDMCPLBLLH(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != boughtIndex)
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		private void AFJEDMCOEDI(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != PNKECEJELDP())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int OKMBMLKHHNE()
		{
			return OBNOCCJIMPG() + 1;
		}

		[SpecialName]
		private void OHHDBFMOEBN(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != PNKECEJELDP())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int IMCENIMADBD()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public List<Tuple<string, float[]>> LNOHKLNBCGM()
		{
			return owner.GetGuiStats(this);
		}

		[SpecialName]
		public int KGINNNIDOIN()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		public int HHNMDNLNPHH()
		{
			return owner.maxWeaponLevel;
		}

		public void JKAJMHOJAGK()
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 586f);
			OHHPBPJCLKM(OBNOCCJIMPG() + 0);
			owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			owner.deliveryActivationNeeded = true;
			object[] array = new object[0];
			array[0] = "Total_Sessions";
			array[0] = owner.DHHKOKKDDDO();
			array[1] = "Battle_End_Dialog";
			array[0] = MPKFMIPMCMP();
			array[1] = "AMMOBOX";
			UnityEngine.Debug.Log(string.Concat(array));
		}

		[SpecialName]
		public bool GEDLFJAJJBN()
		{
			return owner.CanUpgrade(this);
		}

		[SpecialName]
		public int HEKMIFHFEKN()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		public int CHBLIODIDAL(int BMFAHPPCPBF)
		{
			int num = IDFMGEDFNLG();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 0)
			{
				num = num * (104 - BMFAHPPCPBF) / 25;
			}
			if (GEDLFJAJJBN())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 5f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = true;
				object[] array = new object[3];
				array[0] = owner.DHHKOKKDDDO();
				array[1] = boughtIndex;
				array[8] = num;
				UnityEngine.Debug.LogFormat("exception message", array);
			}
			return num;
		}

		[SpecialName]
		public int CGMKKNIHHMN()
		{
			return owner.maxWeaponLevel;
		}

		public void DKOLKANENIM()
		{
			if (IGPKNAHPOIP())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 1138f);
				HAMPIPINGLJ(LHLGAAEEKID() + 1);
				owner.deliveryActivationNeeded = true;
				object[] array = new object[8];
				array[0] = "{0} {1}";
				array[0] = owner.DHHKOKKDDDO();
				array[4] = "Wrong_Weapon";
				array[3] = OBNOCCJIMPG();
				array[2] = "CardCraft_Start";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		public int IPHBJHMJGHF(int BMFAHPPCPBF)
		{
			int num = GPHFEBGODFK();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 0)
			{
				num = num * (-15 - BMFAHPPCPBF) / -97;
			}
			if (GPCKEMCNGAA())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 1606f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = false;
				object[] array = new object[2];
				array[0] = owner.DHHKOKKDDDO();
				array[0] = EJHKOFFOFOA();
				array[5] = num;
				UnityEngine.Debug.LogFormat("ID_ARENARULES_BUDDYWARCARDS", array);
			}
			return num;
		}

		[SpecialName]
		public bool AMDMFOAPIME()
		{
			return owner.CanUpgrade(this);
		}

		public void AHMKHLKGLKC()
		{
			if (JFFOHKBALNH())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 201f);
				BPBNJKLAHGM(boughtIndex + 0);
				owner.deliveryActivationNeeded = true;
				object[] array = new object[3];
				array[1] = "Beanstalk: Resending ";
				array[1] = owner.DHHKOKKDDDO();
				array[3] = "Device slept at {0}, RealTime: {1} waked up at {2} RealTime: {3} and slept for {4}";
				array[8] = boughtIndex;
				array[2] = "Experience";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		[SpecialName]
		public bool JOEBBGBIODC()
		{
			return owner.delivering || owner.deliveryActivationNeeded;
		}

		[SpecialName]
		private void ELGNPHFBFPM(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != LHLGAAEEKID())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int BKNCIECHIKB()
		{
			return owner.maxWeaponLevel;
		}

		[SpecialName]
		public int PCAMHGKJOKM()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public int IDFMGEDFNLG()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		private void OHHPBPJCLKM(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != EJHKOFFOFOA())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public bool PBHKCIEMNAA()
		{
			return owner.delivering || owner.deliveryActivationNeeded;
		}

		[SpecialName]
		public int FJHDDFCAICH()
		{
			if (owner.remainingDeliveringSeconds < 1938.0)
			{
				return 0;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: true);
			if (num2 > 1 && num2 < -90)
			{
				num = num * (71 - num2) / -61;
			}
			return num;
		}

		[SpecialName]
		public int DMNHLHOBANG()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public List<Tuple<string, float[]>> DHEEPGEEIEN()
		{
			return owner.GetGuiStats(this);
		}

		[SpecialName]
		public int ONIDMIEOLHA()
		{
			if (owner.remainingDeliveringSeconds < 700.0)
			{
				return 1;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: false);
			if (num2 > 0 && num2 < 28)
			{
				num = num * (83 - num2) / 105;
			}
			return num;
		}

		public void FEAIJMNKFNL(int DFHAAIFFLOE)
		{
			boughtIndex = DFHAAIFFLOE;
		}

		[SpecialName]
		public bool MHGFNAIMCCA()
		{
			return owner.CanUpgrade(this);
		}

		[SpecialName]
		public List<Tuple<string, float[]>> NKGNPLBFFAC()
		{
			return owner.GetGuiStats(this);
		}

		[SpecialName]
		private void NECPIMHDLCM(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != boughtIndex)
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		public int ILKBGNLIADJ(int BMFAHPPCPBF)
		{
			int num = IDFMGEDFNLG();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 1)
			{
				num = num * (-90 - BMFAHPPCPBF) / 109;
			}
			if (HLONFLMCGIK())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 471f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = false;
				object[] array = new object[1];
				array[1] = owner.DHHKOKKDDDO();
				array[0] = boughtIndex;
				array[2] = num;
				UnityEngine.Debug.LogFormat("-----BEGIN CERTIFICATE-----MIIDwDCCAqgCCQCAhUcHjX7uoDANBgkqhkiG9w0BAQUFADCBoTELMAkGA1UEBhMCQ1oxDzANBgNVBAgMBlByYWd1ZTEPMA0GA1UEBwwGUHJhZ3VlMRIwEAYDVQQKDAlBYm91dCBGdW4xCzAJBgNVBAsMAklUMSswKQYDVQQDDCJ3YXJmcmllbmRzLWV1LmVsYXN0aWNiZWFuc3RhbGsuY29tMSIwIAY", array);
			}
			return num;
		}

		[SpecialName]
		public int LHLGAAEEKID()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		public void HKPFAPDEFOJ(int DFHAAIFFLOE)
		{
			NECPIMHDLCM(DFHAAIFFLOE);
		}

		[SpecialName]
		public int OBMKGNPMLHB()
		{
			if (owner.remainingDeliveringSeconds < 575.0)
			{
				return 1;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: false);
			if (num2 > 0 && num2 < -71)
			{
				num = num * (43 - num2) / -14;
			}
			return num;
		}

		[SpecialName]
		public int NIGDGGIBLHA()
		{
			return owner.maxWeaponLevel;
		}

		[SpecialName]
		private void EGLKIIFAIKG(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != EJHKOFFOFOA())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public bool ABLBELPECBP()
		{
			return owner.CanUpgrade(this);
		}

		[SpecialName]
		public int MPKFMIPMCMP()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public bool IGPKNAHPOIP()
		{
			return !owner.delivering && owner.deliveryActivationNeeded;
		}

		public void AKBJNNHHDGL()
		{
			if (HMKMEKCPAGB())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 1944f);
				NECPIMHDLCM(AGKHAOLEHDE() + 1);
				owner.deliveryActivationNeeded = true;
				object[] array = new object[0];
				array[1] = "com/google/android/gms/common/ConnectionResult";
				array[1] = owner.DHHKOKKDDDO();
				array[5] = "can't find price for: ";
				array[7] = OFEJOLENCKI();
				array[0] = "Application paused";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		public void JCDBPPBDHBC()
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade);
			boughtIndex++;
			owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			owner.deliveryActivationNeeded = false;
			UnityEngine.Debug.Log("Weapon upgrade for " + owner.DHHKOKKDDDO() + " " + boughtIndex + " was activated (through fast activation).");
		}

		[SpecialName]
		public int MOPFKOCLODG()
		{
			if (owner.remainingDeliveringSeconds < 1030.0)
			{
				return 1;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: true);
			if (num2 > 0 && num2 < -119)
			{
				num = num * (17 - num2) / 127;
			}
			return num;
		}

		public void LFDAIFFEPLE(int DFHAAIFFLOE)
		{
			NECPIMHDLCM(DFHAAIFFLOE);
		}

		[SpecialName]
		public int OFEJOLENCKI()
		{
			LevelManager.SavedWeaponSlots savedWeaponSlots = owner.KPCFKKHJIGA();
			return savedWeaponSlots.boughtIndex;
		}

		[SpecialName]
		public int NFIMIDOMEAG()
		{
			return owner.UpgradePrice(this);
		}

		[SpecialName]
		public bool HLONFLMCGIK()
		{
			return owner.CanUpgrade(this);
		}

		public void OOCJMJLELJB()
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1132f);
			NECPIMHDLCM(LHLGAAEEKID() + 0);
			owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			owner.deliveryActivationNeeded = true;
			object[] array = new object[5];
			array[0] = "JoinRoomFailedAfterReconnect: {0} GameIsRunning: {1}";
			array[0] = owner.DHHKOKKDDDO();
			array[8] = "GameReward";
			array[6] = LHLGAAEEKID();
			array[3] = "*.prefab";
			UnityEngine.Debug.Log(string.Concat(array));
		}

		public int MBBKOLENFPO(int BMFAHPPCPBF)
		{
			int num = ODBJOJGFMOD();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 0)
			{
				num = num * (-87 - BMFAHPPCPBF) / -15;
			}
			if (GEDLFJAJJBN())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1714f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = true;
				object[] array = new object[4];
				array[0] = owner.DHHKOKKDDDO();
				array[1] = LHLGAAEEKID();
				array[7] = num;
				UnityEngine.Debug.LogFormat("On Debug Add Scraps Request: ", array);
			}
			return num;
		}

		public int NACFEBFOONF(int BMFAHPPCPBF)
		{
			int num = EDKFHFKMGBO();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 0)
			{
				num = num * (99 - BMFAHPPCPBF) / -103;
			}
			if (canUpgrade)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits, 1041f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = true;
				object[] array = new object[6];
				array[1] = owner.DHHKOKKDDDO();
				array[1] = OBNOCCJIMPG();
				array[6] = num;
				UnityEngine.Debug.LogFormat("AssignmentData", array);
			}
			return num;
		}

		[SpecialName]
		public List<Tuple<string, float[]>> NKNOPGAOFKA()
		{
			return owner.GetGuiStats(this);
		}

		[SpecialName]
		public bool PLBEANIDOGE()
		{
			return owner.delivering || owner.deliveryActivationNeeded;
		}

		[SpecialName]
		public bool GPCKEMCNGAA()
		{
			return owner.CanUpgrade(this);
		}

		public int CGBAKKGAHOO(int BMFAHPPCPBF)
		{
			int num = FGMPELBKKDF();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 1)
			{
				num = num * (77 - BMFAHPPCPBF) / -110;
			}
			if (NJHDEGCDJKK())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 1615f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = true;
				object[] array = new object[7];
				array[1] = owner.DHHKOKKDDDO();
				array[0] = KMHMJEDDNOP();
				array[1] = num;
				UnityEngine.Debug.LogFormat("buggy_idle", array);
			}
			return num;
		}

		[SpecialName]
		public List<Tuple<string, float[]>> ECAINKOHNLI()
		{
			return owner.GetGuiStats(this);
		}

		public void CDKNLOPFGFJ()
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 278f);
			EANGEPAOLGM(OFEJOLENCKI() + 0);
			owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			owner.deliveryActivationNeeded = true;
			object[] array = new object[1];
			array[1] = "{0} {1} {2}/ {3}[-]";
			array[0] = owner.DHHKOKKDDDO();
			array[2] = "URL";
			array[7] = MPKFMIPMCMP();
			array[0] = "《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。";
			UnityEngine.Debug.Log(string.Concat(array));
		}

		[SpecialName]
		public int IPPNAAEIIMO()
		{
			return owner.DeliveryTime(this);
		}

		public void LGDGHACPMAC()
		{
			if (JOEBBGBIODC())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 1325f);
				IAFBFEPODPL(HEKMIFHFEKN() + 1);
				owner.deliveryActivationNeeded = false;
				object[] array = new object[6];
				array[1] = "VipReward2";
				array[0] = owner.DHHKOKKDDDO();
				array[1] = "Scraps";
				array[4] = PNKECEJELDP();
				array[2] = "[CFX_SpawnSystem.GetNextPoolObject()] Object hasn't been preloaded: ";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		public void PFJKBAPPPNF(int DFHAAIFFLOE)
		{
			IAFBFEPODPL(DFHAAIFFLOE);
		}

		public void KJJKHMKGPGP()
		{
			if (canActivate)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 733f);
				IIDMCPLBLLH(LHLGAAEEKID() + 1);
				owner.deliveryActivationNeeded = false;
				object[] array = new object[7];
				array[1] = "SquadEmblem";
				array[0] = owner.DHHKOKKDDDO();
				array[5] = "}";
				array[2] = BDNCLOPCDLO();
				array[0] = "canSendLogs";
				UnityEngine.Debug.Log(string.Concat(array));
			}
		}

		[SpecialName]
		public int FGMPELBKKDF()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		public int EDKFHFKMGBO()
		{
			return owner.DeliveryTime(this);
		}

		[SpecialName]
		public List<Tuple<string, float[]>> EKKFCKDPMNI()
		{
			return owner.GetGuiStats(this);
		}

		[SpecialName]
		private void BPBNJKLAHGM(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != LHLGAAEEKID())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		[SpecialName]
		public int JFCGLGCOIHL()
		{
			if (owner.remainingDeliveringSeconds < 354.0)
			{
				return 1;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(owner.remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(owner.BHCEOOLEHHG, owner, NJMAGCAMDFM: false);
			if (num2 > 0 && num2 < -33)
			{
				num = num * (-58 - num2) / -22;
			}
			return num;
		}

		public int HLECIKNGJAA(int BMFAHPPCPBF)
		{
			int num = KGINNNIDOIN();
			if (SubscriptionManager.instance.isSubscribed)
			{
				num = Mathf.CeilToInt((float)num * SubscriptionManager.instance.upgradesMultiplier);
			}
			if (BMFAHPPCPBF > 1)
			{
				num = num * (-120 - BMFAHPPCPBF) / 43;
			}
			if (NJHDEGCDJKK())
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1161f);
				owner.startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				owner.endDeliveryTime = owner.startDeliveryTime + num;
				owner.deliveryActivationNeeded = false;
				object[] array = new object[0];
				array[1] = owner.DHHKOKKDDDO();
				array[1] = AGKHAOLEHDE();
				array[2] = num;
				UnityEngine.Debug.LogFormat("ID_ARENARULES", array);
			}
			return num;
		}

		[SpecialName]
		private void IIDJBMNCMHP(int IDEBKDPMPGM)
		{
			if (IDEBKDPMPGM != EJHKOFFOFOA())
			{
				owner.KPCFKKHJIGA().boughtIndex = IDEBKDPMPGM;
			}
		}

		public void GCNGEFNCNND()
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1602f);
			NECPIMHDLCM(BDNCLOPCDLO() + 0);
			owner.endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			owner.deliveryActivationNeeded = true;
			object[] array = new object[4];
			array[0] = "DeployHeli";
			array[1] = owner.DHHKOKKDDDO();
			array[0] = "level";
			array[3] = OBNOCCJIMPG();
			array[6] = "to ";
			UnityEngine.Debug.Log(string.Concat(array));
		}
	}

	[Header("Name + Description")]
	[FormerlySerializedAs("FCJOMEAMOIM")]
	public string KAJHANBHNKK;

	[Header("Weapon Screen")]
	[FormerlySerializedAs("KPLGCBBCCPF")]
	public int PJNBNCCKFLP = 1;

	[FormerlySerializedAs("CBPLLMBIFGM")]
	public Vector3 DFDLEGCJLBG;

	[FormerlySerializedAs("CCEBJEKMAGP")]
	public Vector2 NIGBPGFLMMC;

	[Header("Weapon Settings")]
	[FormerlySerializedAs("JPFGCEHMFJK")]
	public string CKNHABFHJIP;

	[FormerlySerializedAs("LMBBOKMEPGI")]
	public string IMMNMGDBOOD;

	[FormerlySerializedAs("FCNJEGHDPKH")]
	public WeaponCategory BHCEOOLEHHG;

	[FormerlySerializedAs("CAPDONFMIPF")]
	public bool FICHPKKDGBK;

	[FormerlySerializedAs("FIBJOPOJBMC")]
	public int LKFMMBMFFNB;

	[FormerlySerializedAs("BJBNDCJEHBJ")]
	public WeaponLevelsSetup JMFBJIJINKN;

	[FormerlySerializedAs("HEBMDHGPGGF")]
	[Header("List of Slots")]
	public UpgradeSlot MGAGEKAAJOL;

	[FormerlySerializedAs("OIMBFLDOJHN")]
	[Header("Unit weapon equivalent")]
	public Weapon EKGGBJBCKJP;

	[FormerlySerializedAs("FENDMDEKFNJ")]
	public int DECPPJGOPHA;

	public Weapon.IGGFMJAKLGO BEACDIILBEG;

	protected Google2uComponentBase LIEFNEPEIJO;

	private WeaponInventory OOMPHMNINGJ;

	private const int GDMPGLEOABF = 1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WeaponFeature _003CLCJCIFAGFMD_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WeaponUpgradesRow _003CMBPICLNEJDP_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CAAFCFKGBMOE_003Ek__BackingField;

	private string DEBAMAJABPP;

	public string weaponName => Localization.LocalizeFormat(KAJHANBHNKK, weaponFeature.weaponPrefix);

	public WeaponFeature weaponFeature
	{
		[CompilerGenerated]
		get
		{
			return _003CLCJCIFAGFMD_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CLCJCIFAGFMD_003Ek__BackingField = value;
		}
	}

	public WeaponUpgradesRow HCICPDLJNCK
	{
		[CompilerGenerated]
		protected get
		{
			return _003CMBPICLNEJDP_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CMBPICLNEJDP_003Ek__BackingField = value;
		}
	}

	public int indexInLevelManager
	{
		[CompilerGenerated]
		get
		{
			return _003CAAFCFKGBMOE_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAAFCFKGBMOE_003Ek__BackingField = value;
		}
	}

	public bool tryOutWeapon
	{
		get
		{
			return KPCFKKHJIGA().borrowed;
		}
		set
		{
			KPCFKKHJIGA().borrowed = value;
		}
	}

	public string purchasableValue => HCICPDLJNCK.PURCHASABLE;

	public GILPPKMICCF purchasable
	{
		get
		{
			if (purchasableValue == "shop")
			{
				return GILPPKMICCF.Shop;
			}
			if (purchasableValue == "value")
			{
				return GILPPKMICCF.ValuePack;
			}
			if (purchasableValue == "starter2")
			{
				return GILPPKMICCF.StarterPack;
			}
			if (purchasableValue == "starter")
			{
				return GILPPKMICCF.StarterPackOld;
			}
			if (purchasableValue == "assignment")
			{
				return GILPPKMICCF.StarterAssignment;
			}
			if (purchasableValue == "blackmarket")
			{
				return GILPPKMICCF.BlackMarket;
			}
			if (purchasableValue.StartsWith("elitepack"))
			{
				if (purchasableValue == "elitepack1")
				{
					return GILPPKMICCF.ElitePack1;
				}
				if (purchasableValue == "elitepack2")
				{
					return GILPPKMICCF.ElitePack2;
				}
				if (purchasableValue == "elitepack3")
				{
					return GILPPKMICCF.ElitePack3;
				}
				if (purchasableValue == "elitepack4")
				{
					return GILPPKMICCF.ElitePack4;
				}
				if (purchasableValue == "elitepack5")
				{
					return GILPPKMICCF.ElitePack5;
				}
				if (purchasableValue == "elitepack6")
				{
					return GILPPKMICCF.ElitePack6;
				}
			}
			if (purchasableValue.StartsWith("veteranpack"))
			{
				if (purchasableValue == "veteranpack0")
				{
					return GILPPKMICCF.VeteranPack0;
				}
				if (purchasableValue == "veteranpack1")
				{
					return GILPPKMICCF.VeteranPack1;
				}
				if (purchasableValue == "veteranpack2")
				{
					return GILPPKMICCF.VeteranPack2;
				}
				if (purchasableValue == "veteranpack3")
				{
					return GILPPKMICCF.VeteranPack3;
				}
				if (purchasableValue == "veteranpack4")
				{
					return GILPPKMICCF.VeteranPack4;
				}
				if (purchasableValue == "veteranpack5")
				{
					return GILPPKMICCF.VeteranPack5;
				}
			}
			return GILPPKMICCF.Hidden;
		}
	}

	public bool purchasableInShop => purchasable == GILPPKMICCF.Shop;

	public bool purchasableInBlackmarket => purchasable == GILPPKMICCF.BlackMarket;

	public bool canBeShownInScreen
	{
		get
		{
			if (bought || purchasableInShop || (purchasable == GILPPKMICCF.StarterPack && PlayerAnalytics.instance.showStarterPack))
			{
				return true;
			}
			if (purchasableInBlackmarket && BlackMarketManager.instance.isOfferActive && BlackMarketManager.instance.IsWeaponInOffer(DHHKOKKDDDO()))
			{
				return true;
			}
			if (purchasable == GILPPKMICCF.StarterPack || purchasable == GILPPKMICCF.ValuePack || purchasable == GILPPKMICCF.StarterAssignment)
			{
				return false;
			}
			return PlayerAnalytics.instance.ShowPack(purchasableValue);
		}
	}

	public Color weaponBackground
	{
		get
		{
			if (purchasableInBlackmarket)
			{
				return Colours.azureBlackmarket;
			}
			if (!purchasableInShop)
			{
				return Color.yellow;
			}
			return Color.white;
		}
	}

	public bool canBeBought => LevelManager.instance.currentLevel.index >= HCICPDLJNCK.CANBEBOUGHT - 1;

	public bool bought
	{
		get
		{
			if (FICHPKKDGBK)
			{
				if (Singleton<GameController>.instance.isTutorial)
				{
					return KPCFKKHJIGA().bought;
				}
				return true;
			}
			return (purchasableInShop && unlockLevelIndex == 0 && price == 0 && priceGold == 0) || (KPCFKKHJIGA().bought && canBeBought) || tryOutWeapon;
		}
		set
		{
			if (value != bought)
			{
				KPCFKKHJIGA().bought = value;
			}
		}
	}

	public int specialFeature
	{
		get
		{
			return KPCFKKHJIGA().specialFeature;
		}
		set
		{
			if (value != specialFeature)
			{
				KPCFKKHJIGA().specialFeature = value;
			}
		}
	}

	public bool boughtDeliveringInProgress
	{
		get
		{
			KPCFKKHJIGA();
			return deliveryActivationNeeded && delivering;
		}
	}

	public virtual int burstSize => 1;

	public float burstLockTime => HCICPDLJNCK.BURSTLOCKTIME * weaponFeature.rateOfFireCoef;

	public float baseAccuracy => HCICPDLJNCK.ACCURACY;

	public float accuracy => Mathf.Round((float)HCICPDLJNCK.ACCURACY * weaponFeature.accuracyCoef * 1000f) / 1000f;

	public float baseCritical => HCICPDLJNCK.CRITICAL;

	public float critical => Mathf.Round((float)HCICPDLJNCK.CRITICAL * weaponFeature.criticalCoef * 1000f) / 1000f;

	public float shotVelocity => (float)HCICPDLJNCK.SPEED * weaponFeature.shotVelocityCoef;

	public float rateOfFire => (float)HCICPDLJNCK.RATEOFFIRE * weaponFeature.rateOfFireCoef;

	public int price => HCICPDLJNCK.PRICE;

	public int priceGold => HCICPDLJNCK.PRICEGOLD;

	public int weaponDeliveryTime => HCICPDLJNCK.DELIVERTIME;

	public float damageToPlayerRatio => HCICPDLJNCK.DAMAGETOPLAYER;

	public float damageToPlayerRatioOvertime => HCICPDLJNCK.DAMAGETOPLAYEROVERTIME;

	public float damageToPlayerBehindShieldRatio => HCICPDLJNCK.DAMAGETOPLAYERBEHINDSHIELD;

	public float damageToShield => HCICPDLJNCK.DAMAGETOSHIELD;

	public int blackmarketPrice => LIEFNEPEIJO.HasColumn("weaponprice") ? ((int)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "weaponprice")) : 0;

	public float reloadGUI => (!LIEFNEPEIJO.HasColumn("reloadTime")) ? 0f : ((float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "reloadTime") * weaponFeature.reloadCoef);

	public int magazineGUI => LIEFNEPEIJO.HasColumn("clipSize") ? ((int)((float)(int)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "clipSize") * weaponFeature.clipSizeCoef)) : 0;

	public int unlockLevelIndex => HCICPDLJNCK.UNLOCKLEVEL - 1;

	public bool delivering
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return currentTimestampDouble < (double)endDeliveryTime;
		}
	}

	public bool deliveryActivationNeeded
	{
		get
		{
			LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
			return DHHKOKKDDDO() == weaponDelivery.itemId && weaponDelivery.activationNeeded;
		}
		set
		{
			if (value != deliveryActivationNeeded)
			{
				LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
				weaponDelivery.itemId = DHHKOKKDDDO();
				weaponDelivery.activationNeeded = value;
			}
		}
	}

	public long endDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
			return (!(DHHKOKKDDDO() != weaponDelivery.itemId)) ? weaponDelivery.end : 0;
		}
		set
		{
			if (value != endDeliveryTime)
			{
				LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
				weaponDelivery.itemId = DHHKOKKDDDO();
				weaponDelivery.end = value;
			}
		}
	}

	public int instantWeaponDeliveryPrice
	{
		get
		{
			if (remainingDeliveringSeconds < 0.0)
			{
				return 0;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(BHCEOOLEHHG, this, NJMAGCAMDFM: false);
			if (num2 > 0 && num2 < 100)
			{
				num = num * (100 - num2) / 100;
			}
			return num;
		}
	}

	public int fullPrizeOfUpgradeDeliveryGold
	{
		get
		{
			if (!canBeUpgraded)
			{
				return 0;
			}
			return MEJMLNDFDBP.BCEGIAODLCL(MGAGEKAAJOL.deliveryTime);
		}
	}

	public virtual int maxWeaponLevel => LIEFNEPEIJO.RowsGeneric.Count - 1;

	public PlayerWeapon playerWeapon => weaponInventory.KCGKDDDNONB[LKFMMBMFFNB];

	public float progressDelivering
	{
		get
		{
			if (weaponState != JLANLLEABDC.Delivering && weaponState != JLANLLEABDC.WeaponDelivering)
			{
				return 0f;
			}
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			double num = (currentTimestampDouble - (double)startDeliveryTime) / (double)(endDeliveryTime - startDeliveryTime);
			return Mathf.Clamp01((float)num);
		}
	}

	public virtual float rateOfFirePerMinute => 60f / rateOfFire;

	public double remainingDeliveringSeconds
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return (double)endDeliveryTime - currentTimestampDouble;
		}
	}

	public bool showed
	{
		get
		{
			return KPCFKKHJIGA().showed;
		}
		set
		{
			KPCFKKHJIGA().showed = true;
		}
	}

	public long startDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
			return (!(DHHKOKKDDDO() != weaponDelivery.itemId)) ? weaponDelivery.start : 0;
		}
		set
		{
			if (value != startDeliveryTime)
			{
				LevelManager.ItemDelivery weaponDelivery = LevelManager.instance.data.weaponDelivery;
				weaponDelivery.itemId = DHHKOKKDDDO();
				weaponDelivery.start = value;
			}
		}
	}

	public bool unlocked => unlockLevelIndex <= LevelManager.instance.currentLevel.index || bought;

	public virtual bool canBeUpgraded => weaponLevel < maxWeaponLevel;

	public LevelManager.GameLevel unlockLevel => LevelManager.instance.GetLevelDefinition(unlockLevelIndex);

	public float upgradesProgress => (float)weaponLevel / (float)maxWeaponLevel;

	public Weapon weapon => weaponInventory.KCGKDDDNONB[LKFMMBMFFNB].weapon;

	public WeaponInventory weaponInventory
	{
		get
		{
			if (OOMPHMNINGJ == null)
			{
				OOMPHMNINGJ = PlayerController.OGMBJPKOPCB.weaponInventory;
			}
			return OOMPHMNINGJ;
		}
		set
		{
			OOMPHMNINGJ = value;
		}
	}

	public virtual int weaponLevel => (bought || purchasableInBlackmarket) ? MGAGEKAAJOL.level : 0;

	public float weaponPower => LBDJFGDNKLA((MGAGEKAAJOL != null) ? MGAGEKAAJOL.boughtIndex : KPCFKKHJIGA().boughtIndex);

	public int weaponPowerX10 => GetWeaponPowerX10(MGAGEKAAJOL.boughtIndex, weaponFeature);

	public int weaponPowerX10Next => GetWeaponPowerX10(MGAGEKAAJOL.boughtIndex + 1, weaponFeature);

	public int weaponPowerX10Max => GetWeaponPowerX10(FindLastRowForSlot(MGAGEKAAJOL), weaponFeature);

	public JLANLLEABDC weaponState
	{
		get
		{
			if (!unlocked)
			{
				return JLANLLEABDC.Locked;
			}
			if (bought && delivering)
			{
				return JLANLLEABDC.Delivering;
			}
			if (bought && deliveryActivationNeeded)
			{
				return JLANLLEABDC.Delivered;
			}
			if (!bought && delivering)
			{
				return JLANLLEABDC.WeaponDelivering;
			}
			if (!bought && deliveryActivationNeeded)
			{
				return JLANLLEABDC.WeaponDelivered;
			}
			if (!bought)
			{
				return JLANLLEABDC.NotBuyed;
			}
			return JLANLLEABDC.Active;
		}
	}

	public virtual float shotDamage => 0f;

	public int totalAmmo
	{
		get
		{
			if (LIEFNEPEIJO.HasColumn("ammo"))
			{
				return (int)((float)(int)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "ammo") * weaponFeature.ammoCoef);
			}
			return 0;
		}
	}

	public void LoadDefinition(byte? NDPMDKGJAFH = null, int BCCDDJMPBLL = 0)
	{
		SetWeaponparameters(weapon, NDPMDKGJAFH);
	}

	protected float ANFDAHOPDLO(byte? NDPMDKGJAFH, string IDEBKDPMPGM)
	{
		int rowIndex = (NDPMDKGJAFH.HasValue ? NDPMDKGJAFH.Value : MGAGEKAAJOL.boughtIndex);
		object value = LIEFNEPEIJO.GetValue(rowIndex, IDEBKDPMPGM);
		if (value is int)
		{
			return (int)value;
		}
		return (float)value;
	}

	public virtual void SetWeaponparameters(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		JMMJHCOKCGG.JMDLKIAKOIE = rateOfFire;
		if (LIEFNEPEIJO.HasColumn("clipSize"))
		{
			JMMJHCOKCGG.FIMMGPLLLCL = (int)(ANFDAHOPDLO(NDPMDKGJAFH, "clipSize") * weaponFeature.clipSizeCoef);
			JMMJHCOKCGG.ammoLeftInClip = JMMJHCOKCGG.FIMMGPLLLCL;
		}
		JMMJHCOKCGG.ammoLeft = (int)(ANFDAHOPDLO(NDPMDKGJAFH, "ammo") * weaponFeature.ammoCoef);
		JMMJHCOKCGG.LCKNGBAEFCL = JMMJHCOKCGG.ammoLeft;
		if (LIEFNEPEIJO.HasColumn("reloadTime"))
		{
			JMMJHCOKCGG.AMGFJFPKOED = ANFDAHOPDLO(NDPMDKGJAFH, "reloadTime") * weaponFeature.reloadCoef;
		}
		AmmoSetup ammoSetup = JMMJHCOKCGG.ammoSetup;
		if (ammoSetup != null)
		{
			ammoSetup.NFKPBDGGDEA = critical;
			if (LIEFNEPEIJO.HasColumn("damage"))
			{
				ammoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "damage") * weaponFeature.damageCoef;
			}
			if (JMMJHCOKCGG.playerWeapon != null)
			{
				ammoSetup.NLCFDPBLBIG = JMMJHCOKCGG.playerWeapon.weaponLevelSetup.damageToPlayerRatio;
				ammoSetup.ADKJBFFFCEH = JMMJHCOKCGG.playerWeapon.weaponLevelSetup.damageToPlayerRatioOvertime;
			}
		}
	}

	protected Tuple<string, float[]> MMPLMBONDIJ(UpgradeSlot ACHJJKCIBCN, string DAMANLFFOPH, string MHPNDNJDPGE, float BIHHPLAFAKG, bool CLFOOLKGCEO = false)
	{
		Tuple<string, float[]> tuple = new Tuple<string, float[]>();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num3 += Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, DAMANLFFOPH));
		num += ((ACHJJKCIBCN.boughtIndex >= maxWeaponLevel - 1) ? 0f : Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex + 1, DAMANLFFOPH)));
		int rowIndex = FindLastRowForSlot(MGAGEKAAJOL);
		num2 += Convert.ToSingle(LIEFNEPEIJO.GetValue(rowIndex, DAMANLFFOPH));
		tuple.Value1 = MHPNDNJDPGE;
		tuple.Value2 = (CLFOOLKGCEO ? new float[3]
		{
			(int)(num3 * BIHHPLAFAKG),
			(int)(num2 * BIHHPLAFAKG),
			(int)(num * BIHHPLAFAKG)
		} : new float[3]
		{
			num3 * BIHHPLAFAKG,
			num2 * BIHHPLAFAKG,
			num * BIHHPLAFAKG
		});
		return tuple;
	}

	public int GetLevel(bool KNBNNLOEBIH, int JMEGHFOKLBF)
	{
		return KNBNNLOEBIH ? (JMEGHFOKLBF + 1) : 0;
	}

	public void ActivateWeapon()
	{
		bought = true;
		if (priceGold == 0)
		{
			deliveryActivationNeeded = false;
		}
	}

	public void Buy()
	{
		if (priceGold > 0)
		{
			bought = true;
			return;
		}
		bought = false;
		startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		endDeliveryTime = startDeliveryTime + weaponDeliveryTime;
		deliveryActivationNeeded = true;
		UnityEngine.Debug.Log("Started delivering |" + DHHKOKKDDDO() + "| time: " + weaponDeliveryTime + "s");
	}

	public bool CanUpgrade(UpgradeSlot ACHJJKCIBCN)
	{
		return maxWeaponLevel > ACHJJKCIBCN.boughtIndex + 1;
	}

	public int DeliveryTime(UpgradeSlot ACHJJKCIBCN)
	{
		return (int)(float)LIEFNEPEIJO.GetValue(ACHJJKCIBCN.boughtIndex, "DeliveryTime");
	}

	public int FindLastRowForSlot(UpgradeSlot ACHJJKCIBCN)
	{
		return maxWeaponLevel - 1;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "attack", "ID_SLOTUPGRADE_DAMAGE", weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "clipSize", "ID_SLOTUPGRADE_CLIP_SIZE", weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "reloadTime", "ID_SLOTUPGRADE_ROF", weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ammo", "ID_SLOTUPGRADE_AMMO", weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	private float LBDJFGDNKLA(int DFHAAIFFLOE, WeaponFeature NHJABEOIPKH = null)
	{
		float num = ((NHJABEOIPKH != null) ? ((float)NHJABEOIPKH.dpsCoef) : 1f);
		DFHAAIFFLOE = Mathf.Clamp(DFHAAIFFLOE, 0, maxWeaponLevel - 1);
		return (float)LIEFNEPEIJO.GetValue(DFHAAIFFLOE, "DPS") * num;
	}

	public float GetWeaponPower(int DFHAAIFFLOE, WeaponFeature NHJABEOIPKH)
	{
		return LBDJFGDNKLA(DFHAAIFFLOE, NHJABEOIPKH);
	}

	public int GetWeaponPowerX10(int DFHAAIFFLOE, WeaponFeature NHJABEOIPKH)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(10f * LBDJFGDNKLA(DFHAAIFFLOE, NHJABEOIPKH));
	}

	public void Init()
	{
		MGAGEKAAJOL.owner = this;
		MGAGEKAAJOL.mMaxPower = -1;
	}

	public void InstantBuyWeapon()
	{
		bought = true;
		endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		deliveryActivationNeeded = false;
	}

	public virtual int UpgradePrice(UpgradeSlot ACHJJKCIBCN)
	{
		return (int)LIEFNEPEIJO.GetValue(ACHJJKCIBCN.boughtIndex, "NextUpgradePrice");
	}

	internal string DHHKOKKDDDO()
	{
		if (string.IsNullOrEmpty(DEBAMAJABPP))
		{
			DEBAMAJABPP = LIEFNEPEIJO.GetType().ToString();
		}
		return DEBAMAJABPP;
	}

	protected override void Awake()
	{
		base.Awake();
		LIEFNEPEIJO = GetComponent<Google2uComponentBase>();
	}

	private LevelManager.SavedWeaponSlots KPCFKKHJIGA()
	{
		string key = DHHKOKKDDDO();
		if (LevelManager.instance.data.savedWeapons.TryGetValue(key, out var value))
		{
			return value;
		}
		LevelManager.SavedWeaponSlots savedWeaponSlots = new LevelManager.SavedWeaponSlots();
		savedWeaponSlots.bought = false;
		savedWeaponSlots.showed = unlockLevelIndex == 0;
		savedWeaponSlots.boughtIndex = 0;
		value = savedWeaponSlots;
		LevelManager.instance.data.savedWeapons[key] = value;
		return value;
	}
}
