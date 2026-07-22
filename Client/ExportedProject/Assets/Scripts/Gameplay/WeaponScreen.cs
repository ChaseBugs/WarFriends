using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponScreen : GuiScreenSingle<WeaponScreen>
{
	public enum ABDDBOABKOK
	{
		WeaponScreen,
		Rental,
		BlackMarket,
		OtherUpgrade,
		Server,
		OneTimeOffer
	}

	private sealed class OGPCPMGOAMA
	{
		internal WeaponLevelsSetup JMMJHCOKCGG;

		internal bool BMCMDMKGHHO(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.OFABMGFOFPI() == JMMJHCOKCGG;
		}

		internal bool NNFHNIMCBLH(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.ADOICOAEIFA() == JMMJHCOKCGG;
		}

		internal bool MMEEJDGGAID(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.ADOICOAEIFA() == JMMJHCOKCGG;
		}

		internal bool CFJHDIHLIML(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.NGOGADPALJO() == JMMJHCOKCGG;
		}

		internal bool CIFEDFPPPOK(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.ADOICOAEIFA() == JMMJHCOKCGG;
		}

		internal bool INFLOOLPOBK(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.OFABMGFOFPI() == JMMJHCOKCGG;
		}

		internal bool MPHECHCFCAN(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.ADOICOAEIFA() == JMMJHCOKCGG;
		}

		internal bool OKNCFDMEFGJ(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.CJAIGEJNDOH() == JMMJHCOKCGG;
		}

		internal bool PHGDBIEENCB(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.PMIIPNOJFLF() == JMMJHCOKCGG;
		}

		internal bool KNJBDOADLDO(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.EAJJDMMGMKK() == JMMJHCOKCGG;
		}

		internal bool HHNEBNHCGMO(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.weaponSetup == JMMJHCOKCGG;
		}

		internal bool ILNPANOCHIH(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.CJAIGEJNDOH() == JMMJHCOKCGG;
		}

		internal bool GMFJFMHNDMC(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.GMEFFFKMDCE() == JMMJHCOKCGG;
		}

		internal bool LJCDGJKCNEC(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.weaponSetup == JMMJHCOKCGG;
		}

		internal bool ECPMEMNKMCB(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.OFABMGFOFPI() == JMMJHCOKCGG;
		}

		internal bool BDCAFHOHEGM(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.GMEFFFKMDCE() == JMMJHCOKCGG;
		}

		internal bool FIBGJHCGHJH(WeaponGuiRecord DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.GMEFFFKMDCE() == JMMJHCOKCGG;
		}
	}

	[Header("Left")]
	[FormerlySerializedAs("KAFNAPMCAMC")]
	public WeaponLeftContent EMHGMNAABDN;

	[FormerlySerializedAs("CGAIJMEEDMB")]
	[Header("Center")]
	public CircleProgress FHFIPPFJIAH;

	[FormerlySerializedAs("KHJHPJJNMMJ")]
	public UISprite GCDLCFADJFO;

	public UISprite CGEFJFEJPOA;

	[FormerlySerializedAs("HMKEBFPNOEF")]
	public ParticleSystem DCNNBHOHCNI;

	[FormerlySerializedAs("ICMHMLGBJJE")]
	[Header("Right")]
	public WeaponRightContent BKLPGLKGCLG;

	[Header("Bottom Weapon List")]
	[FormerlySerializedAs("CMDHFJCDEGG")]
	public WeaponGuiRecord PIENENKELMH;

	[FormerlySerializedAs("MCBFNICDOMF")]
	public NameGuiRecord DFMCOJFCAHL;

	[FormerlySerializedAs("ICKPAEEPOBH")]
	public UIDraggablePanel NFLPPGKCOBL;

	public UITable IEIKMKFHDOJ;

	[Header("Buttons")]
	[FormerlySerializedAs("HMOPJGNIDDG")]
	public UIGridStretchWidth GDHKEABNBGJ;

	[FormerlySerializedAs("NEMJNEIEHFM")]
	public WeaponEquipSlotButton JKFDKLDIFMJ;

	[FormerlySerializedAs("ALHHCIKLONL")]
	[Header("Back Button Tutorial")]
	public UIButton FNOFLJEOHGJ;

	[FormerlySerializedAs("CFMICOPJMKM")]
	[Header("Animation")]
	public ArmyPowerAnimation GHGJLMAJJGG;

	[FormerlySerializedAs("PMNPPFHKNMP")]
	public float MFAFIELBJGF = 0.05f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WeaponGuiRecord _003CCGPAPPCGMGP_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<WeaponGuiRecord> _003CIHNBDMGDKJM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<WeaponEquipSlotButton> _003CNGGDMBLIOOD_003Ek__BackingField;

	private List<NameGuiRecord> LLIKJCHOOIE;

	private ObjectPool IHFILHIAGLG;

	private bool FIDNMMDEDEH;

	private bool JFLKDFPEDNO;

	private float ADDICBANAAB;

	private WeaponLevelsSetup.JLANLLEABDC EMECGGIPPNB;

	private Dictionary<WeaponCategory, string> FOIDJEDBFDN = new Dictionary<WeaponCategory, string>
	{
		{
			WeaponCategory.AssaultRifle,
			"01"
		},
		{
			WeaponCategory.SMG,
			"02"
		},
		{
			WeaponCategory.LMG,
			"03"
		},
		{
			WeaponCategory.Minigun,
			"04"
		},
		{
			WeaponCategory.SniperRifle,
			"05"
		},
		{
			WeaponCategory.Shotgun,
			"06"
		},
		{
			WeaponCategory.Grenade,
			"07"
		},
		{
			WeaponCategory.GrenadeLauncher,
			"08"
		},
		{
			WeaponCategory.RocketLauncher,
			"09"
		},
		{
			WeaponCategory.Pistol,
			"10"
		}
	};

	public WeaponGuiRecord selectedIcon
	{
		[CompilerGenerated]
		get
		{
			return _003CCGPAPPCGMGP_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCGPAPPCGMGP_003Ek__BackingField = value;
		}
	}

	public List<WeaponGuiRecord> weaponIcons
	{
		[CompilerGenerated]
		get
		{
			return _003CIHNBDMGDKJM_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIHNBDMGDKJM_003Ek__BackingField = value;
		}
	}

	public List<WeaponEquipSlotButton> weaponCategoryButtons
	{
		[CompilerGenerated]
		get
		{
			return _003CNGGDMBLIOOD_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CNGGDMBLIOOD_003Ek__BackingField = value;
		}
	}

	public WeaponCategory selectedCategory
	{
		get
		{
			if (selectedIcon == null)
			{
				return WeaponCategory.Primary;
			}
			return selectedIcon.weaponSetup.BHCEOOLEHHG;
		}
	}

	private void IHNMNOOEHGM()
	{
		IEIKMKFHDOJ.onReposition = null;
		IEIKMKFHDOJ.repositionNow = true;
		CEFHLCDGICG(NABOFKMBMKH: false);
		Vector3 zero = Vector3.zero;
		Transform parent = selectedIcon.transform;
		for (int i = 1; i < 5; i++)
		{
			zero += parent.localPosition;
			parent = parent.parent;
		}
		NFLPPGKCOBL.AlignToCenter(zero, instant: true, null, 728f);
	}

	private void AHDPLLLMFJB(WeaponLevelsSetup JMMJHCOKCGG)
	{
		OGPCPMGOAMA oGPCPMGOAMA = new OGPCPMGOAMA();
		oGPCPMGOAMA.JMMJHCOKCGG = JMMJHCOKCGG;
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(NCFKLBGOEEF: false);
		}
		WeaponCategory hJFKNAOICJO = PlayerInventory.instance.GetSlotForCategory(oGPCPMGOAMA.JMMJHCOKCGG.BHCEOOLEHHG)?.category ?? oGPCPMGOAMA.JMMJHCOKCGG.BHCEOOLEHHG;
		OAOEKBFGBBP(hJFKNAOICJO);
		int num = weaponIcons.FindIndex(oGPCPMGOAMA.LJCDGJKCNEC);
		if (num == -1)
		{
			selectedIcon = weaponIcons[0];
		}
		else
		{
			selectedIcon = weaponIcons[num];
		}
		selectedIcon.SetHighlight(NCFKLBGOEEF: true);
		HBBEDANBMOI();
		ELOHOAPJIMK();
	}

	internal void POBJHPANODJ(WeaponLevelsSetup MBNLFKHLDBH, int DBOLKNNJGMH = 0)
	{
		int num = Singleton<OfferManager>.instance.ReduceWeaponDeliveryTime(MBNLFKHLDBH.BHCEOOLEHHG, MBNLFKHLDBH, NJMAGCAMDFM: true);
		int num2 = MBNLFKHLDBH.MGAGEKAAJOL.PAKFACNGLPI(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)23, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"setGender",
				MBNLFKHLDBH.DHHKOKKDDDO()
			},
			{
				"RenameCount",
				MBNLFKHLDBH.MGAGEKAAJOL.MPKFMIPMCMP()
			},
			{
				"WENEEDTO",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{ "menu-assignments-type-score", DBOLKNNJGMH },
			{ "com/google/android/gms/common/ConnectionResult", num2 },
			{ "DogTagCap", num }
		}), MBNLFKHLDBH.MGAGEKAAJOL.DMNHLHOBANG() * (-63 - DBOLKNNJGMH) / 89, 0, MBNLFKHLDBH.DHHKOKKDDDO());
	}

	public void FKEJAMIBKMN()
	{
		GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO().NOBCMNHEKKM();
	}

	private void OEEGBKAPGEG(UITweener MKAPOHKFIJH)
	{
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1413f, new Vector3(239f, 1582f, 631f));
	}

	private void FBHHHEMAJNF()
	{
		if (EMECGGIPPNB == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			BKLPGLKGCLG.UpdateDeliveringTime((float)FMFHOPFBMOO().NGOGADPALJO().remainingDeliveringSeconds, PAAMHOJOFFP().weaponSetup.progressDelivering);
		}
		if (EMECGGIPPNB == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
		{
			EMHGMNAABDN.UpdateDeliveringTime((float)selectedIcon.weaponSetup.remainingDeliveringSeconds, PAAMHOJOFFP().NGOGADPALJO().progressDelivering);
		}
	}

	public virtual void BCACBNHFMDA()
	{
		base.DoBeforeShowUp();
		FIDNMMDEDEH = false;
	}

	public void KGLOKAGJHBM()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.HLKHEDDLBAA();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		FIDNMMDEDEH = true;
		PAPCGBIKPLG();
	}

	private void GLALLPMAIFB()
	{
		if (isShowed)
		{
			CNDIGGJNJLI();
			ShowWeapon(selectedIcon.EAJJDMMGMKK());
		}
	}

	public void MIIMDHKCINK()
	{
		ShowWeapon(selectedIcon.ADOICOAEIFA());
		UpdateNotificationsInCategories();
		OPNBMFDJKAP();
	}

	public void EEOODFKEJIG()
	{
	}

	[SpecialName]
	public List<WeaponEquipSlotButton> AKKJBKJAFCB()
	{
		return _003CNGGDMBLIOOD_003Ek__BackingField;
	}

	public void OPNBMFDJKAP()
	{
		foreach (WeaponEquipSlotButton item in DGMADFPFHHE())
		{
			item.IEEAKDJHHBH();
		}
		foreach (NameGuiRecord item2 in LLIKJCHOOIE)
		{
			item2.Sale();
		}
	}

	public void WasShown(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.WeaponWasShown, LFGKDBIHLGI, 0, 0, string.Empty);
	}

	public void CMEDBDMKKMG()
	{
		foreach (WeaponEquipSlotButton item in AKKJBKJAFCB())
		{
			item.OHMIGANDELN();
		}
	}

	private void PLABPHODOOJ()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.SetEquiped(KGGCJPEKIAD: false);
		}
	}

	public void IPGFLFDGCEO()
	{
		foreach (WeaponEquipSlotButton item in AKKJBKJAFCB())
		{
			item.Sale();
		}
		foreach (NameGuiRecord item2 in LLIKJCHOOIE)
		{
			item2.OBOJPONJBLK();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		IHFILHIAGLG.FreeObjectsWithPrefab(PIENENKELMH);
		IHFILHIAGLG.FreeObjectsWithPrefab(DFMCOJFCAHL);
		EMHGMNAABDN.DoAfterHide();
		BKLPGLKGCLG.DoAfterHide();
	}

	[CompilerGenerated]
	private void IPBLKLKMCMG(UITweener CKOINALCMFJ)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
	}

	private void PNHPNABNMON()
	{
		if (isShowed)
		{
			GGPADKNLEPN();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		FIDNMMDEDEH = false;
	}

	internal void IEFLIEHLBNA(WeaponLevelsSetup MBNLFKHLDBH, int DBOLKNNJGMH = 0)
	{
		int num = Singleton<OfferManager>.instance.ReduceWeaponDeliveryTime(MBNLFKHLDBH.BHCEOOLEHHG, MBNLFKHLDBH, NJMAGCAMDFM: false);
		int num2 = MBNLFKHLDBH.MGAGEKAAJOL.KDIHEKPKCJJ(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.BuyWeaponUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				MBNLFKHLDBH.DHHKOKKDDDO()
			},
			{
				"BoughtIndex",
				MBNLFKHLDBH.MGAGEKAAJOL.boughtIndex
			},
			{
				"StartTime",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{ "discount", DBOLKNNJGMH },
			{ "DeliveryTime", num2 },
			{ "deliveryReduce", num }
		}), MBNLFKHLDBH.MGAGEKAAJOL.upgradePrice * (100 - DBOLKNNJGMH) / 100, 0, MBNLFKHLDBH.DHHKOKKDDDO());
	}

	private void BJBLDCHGEGO()
	{
		WeaponCategory bHCEOOLEHHG = FMFHOPFBMOO().OFABMGFOFPI().BHCEOOLEHHG;
		foreach (WeaponEquipSlotButton item in DGMADFPFHHE())
		{
			item.IIGOGILLPCJ(bHCEOOLEHHG);
		}
	}

	public override void InitGUIValues()
	{
		WeaponLevelsSetup weaponLevelsSetup = KMEGKMFLDPI();
		SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
		AHDPLLLMFJB(weaponLevelsSetup);
		Select();
	}

	public void EBKKEOEAKML()
	{
		DCNNBHOHCNI.Play();
		Singleton<WeaponPreviewCamera>.instance.StartFastRotation();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 1828f, 1739f, 1257f);
		tweenAlpha.NumOfRepetitions = 8;
		tweenAlpha.style = UITweener.Style.Loop;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 631f, 1130f, 1287f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
			};
		};
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1953f, new Vector3(224f, 1482f, 348f), new Vector3(1115f, 298f, 1516f)).onFinished = delegate
		{
			TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 406f, Vector3.zero, Vector3.zero).onFinished = ABNMOHMKOFK;
	}

	public void ShowWeapon(WeaponLevelsSetup JMMJHCOKCGG)
	{
		if (!JMMJHCOKCGG.showed && JMMJHCOKCGG.unlocked && !JMMJHCOKCGG.tryOutWeapon)
		{
			WasShown(JMMJHCOKCGG.DHHKOKKDDDO());
		}
		JMMJHCOKCGG.showed = true;
		SavingLastSelected.instance.SaveLastWeapon(JMMJHCOKCGG);
		PAPCGBIKPLG();
		BKLPGLKGCLG.SelectWeapon(JMMJHCOKCGG);
		EMHGMNAABDN.SelectWeapon(JMMJHCOKCGG);
		UpdateGui(JMMJHCOKCGG);
		EMECGGIPPNB = JMMJHCOKCGG.weaponState;
	}

	internal void APGDCFFDPOF(WeaponLevelsSetup MBNLFKHLDBH, bool CDMKCIKHIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		int instantBuyPrice = MBNLFKHLDBH.MGAGEKAAJOL.instantBuyPrice;
		int boughtIndex = MBNLFKHLDBH.MGAGEKAAJOL.boughtIndex;
		Singleton<EventTrackingManager>.instance.RegisterGameItemDeliverEvent("Deliver_Upgrade_For_Weapon", "Weapon_ID", MBNLFKHLDBH.DHHKOKKDDDO() + " " + MBNLFKHLDBH.MGAGEKAAJOL.boughtIndex, MBNLFKHLDBH.MGAGEKAAJOL.instantBuyPrice, MBNLFKHLDBH.remainingDeliveringSeconds);
		MBNLFKHLDBH.MGAGEKAAJOL.JCDBPPBDHBC();
		float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
		float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		int num3 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(MBNLFKHLDBH.BHCEOOLEHHG, MBNLFKHLDBH, NJMAGCAMDFM: false);
		requestBuffer.AddRequest(DatabaseAction.InstantWeaponUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				MBNLFKHLDBH.DHHKOKKDDDO()
			},
			{ "BoughtIndex", boughtIndex },
			{ "ExpectedPrice", instantBuyPrice },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			},
			{ "GoldCoefficient", num },
			{ "GoldExpCoefficient", num2 },
			{ "discount", num3 }
		}), 0, instantBuyPrice, MBNLFKHLDBH.DHHKOKKDDDO());
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterWeaponUpgrade);
	}

	internal void ENIOOHGANFE(WeaponLevelsSetup MBNLFKHLDBH, ABDDBOABKOK ILOAGGPDJCD)
	{
		if (!MBNLFKHLDBH.FICHPKKDGBK)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)(-110), JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"cn",
				MBNLFKHLDBH.DHHKOKKDDDO()
			} }), 1, 0, string.Empty, additionalParameter: true);
		}
		MBNLFKHLDBH.ActivateWeapon();
		AFCNHKNBDIH(MBNLFKHLDBH, ILOAGGPDJCD);
	}

	private void COPMJOAJKFI(WeaponCategory FABOAIMLLOI, string PGJNIAIHKDB)
	{
		List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
		foreach (WeaponLevelsSetup weaponLevelsSetup3 in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup3.BHCEOOLEHHG == FABOAIMLLOI && weaponLevelsSetup3.canBeShownInScreen)
			{
				list.Add(weaponLevelsSetup3);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(FABOAIMLLOI);
		NameGuiRecord nameGuiRecord = IHFILHIAGLG.OHDNLPIOAHG(DFMCOJFCAHL, Vector3.zero, Quaternion.identity, IEIKMKFHDOJ.gameObject) as NameGuiRecord;
		if (nameGuiRecord != null)
		{
			nameGuiRecord.name = string.Format("discount", PGJNIAIHKDB, FABOAIMLLOI.ToString());
			nameGuiRecord.MBFHMAANAKL(FABOAIMLLOI);
			LLIKJCHOOIE.Add(nameGuiRecord);
		}
		for (int i = 0; i < list.Count; i++)
		{
			WeaponLevelsSetup weaponLevelsSetup2 = list[i];
			WeaponGuiRecord weaponGuiRecord = IHFILHIAGLG.EPCCOJLHDLH(PIENENKELMH, Vector3.zero, Quaternion.identity, IEIKMKFHDOJ.gameObject) as WeaponGuiRecord;
			if (!(weaponGuiRecord == null))
			{
				object[] array = new object[1];
				array[1] = PGJNIAIHKDB;
				array[0] = weaponLevelsSetup2.PJNBNCCKFLP.ToString(" ");
				array[8] = (0 + weaponLevelsSetup2.unlockLevelIndex).ToString("ID_WARNING_CANTSENDINVITE");
				array[6] = weaponLevelsSetup2.weaponName;
				weaponGuiRecord.name = string.Format("ID_ERROR_SQUADNAMENOTUNIQUE", array);
				weaponGuiRecord.DPHCDKHOODJ(weaponLevelsSetup2);
				if (weaponLevelsSetup2 == slotForCategory.JCPKCKIHFBI())
				{
					weaponGuiRecord.MDBADNAJFBN(KGGCJPEKIAD: false);
				}
				if (weaponLevelsSetup == null && weaponLevelsSetup2.unlockLevelIndex == 0)
				{
					SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup2);
					weaponLevelsSetup = weaponLevelsSetup2;
				}
				weaponIcons.Add(weaponGuiRecord);
			}
		}
	}

	public void SelectWeapon(WeaponLevelsSetup JMMJHCOKCGG)
	{
		JFLKDFPEDNO = true;
		SavingLastSelected.instance.SaveLastWeapon(JMMJHCOKCGG);
	}

	protected override void AGIKPOLCGNF()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		weaponCategoryButtons = new List<WeaponEquipSlotButton>();
		int count = PlayerInventory.instance.inventorySlots.Count;
		for (int i = 0; i < count; i++)
		{
			WeaponEquipSlotButton weaponEquipSlotButton = UnityEngine.Object.Instantiate(JKFDKLDIFMJ);
			weaponEquipSlotButton.gameObject.name = $"{i} {PlayerInventory.instance.inventorySlots[i].category} Button";
			weaponEquipSlotButton.transform.parent = GDHKEABNBGJ.transform;
			weaponEquipSlotButton.transform.localScale = Vector3.one;
			weaponEquipSlotButton.transform.localPosition = new Vector3(weaponEquipSlotButton.transform.localPosition.x, weaponEquipSlotButton.transform.localPosition.y, 0f);
			weaponEquipSlotButton.Initialize(PlayerInventory.instance.inventorySlots[i], count);
			weaponCategoryButtons.Add(weaponEquipSlotButton);
		}
		GDHKEABNBGJ.DNNLLMFLJND = count;
		GDHKEABNBGJ.Reposition();
		GameLoginManager.instance.PlayerLogOut += PLABPHODOOJ;
		LevelManager.LevelUp += AFBHOJNGDAC;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<NotificationManager>.instance.WeaponDelivered += delegate
		{
			if (isShowed)
			{
				UpdateNotificationsInCategories();
			}
		};
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				UpdateSalesInCategories();
				foreach (WeaponGuiRecord weaponIcon in weaponIcons)
				{
					weaponIcon.SetSale();
				}
				EMHGMNAABDN.SetSaleAndPrize();
				BKLPGLKGCLG.SetSaleAndPrize();
			}
		};
		BlackMarketManager.instance.LoadedOffer += delegate
		{
			if (isShowed)
			{
				InitGUIValues();
			}
		};
		BKLPGLKGCLG.InitControls();
		EMHGMNAABDN.InitControls();
	}

	[SpecialName]
	public List<WeaponEquipSlotButton> ILDCKDKKHJC()
	{
		return _003CNGGDMBLIOOD_003Ek__BackingField;
	}

	[SpecialName]
	public WeaponGuiRecord FMFHOPFBMOO()
	{
		return _003CCGPAPPCGMGP_003Ek__BackingField;
	}

	private void ELOHOAPJIMK()
	{
		FLCDOLDNLHG(NABOFKMBMKH: false);
		IEIKMKFHDOJ.repositionNow = true;
		IEIKMKFHDOJ.onReposition = delegate
		{
			IEIKMKFHDOJ.onReposition = null;
			IEIKMKFHDOJ.repositionNow = false;
			FLCDOLDNLHG(NABOFKMBMKH: true);
			Vector3 zero = Vector3.zero;
			Transform parent = selectedIcon.transform;
			for (int i = 0; i < 2; i++)
			{
				zero += parent.localPosition;
				parent = parent.parent;
			}
			NFLPPGKCOBL.AlignToCenter(zero, instant: true);
		};
	}

	internal void HDBDPLBHNKD(WeaponLevelsSetup MBNLFKHLDBH, ABDDBOABKOK ILOAGGPDJCD)
	{
		if (!MBNLFKHLDBH.FICHPKKDGBK)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
			requestBuffer.AddRequest(DatabaseAction.InstantBuyWeapon, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"LevelName",
					MBNLFKHLDBH.DHHKOKKDDDO()
				},
				{ "ExpectedPrice", MBNLFKHLDBH.instantWeaponDeliveryPrice },
				{ "GoldCoefficient", num },
				{ "GoldExpCoefficient", num2 }
			}), 0, MBNLFKHLDBH.instantWeaponDeliveryPrice, MBNLFKHLDBH.DHHKOKKDDDO());
		}
		MBNLFKHLDBH.InstantBuyWeapon();
		AfterWeaponIsBought(MBNLFKHLDBH, ILOAGGPDJCD);
	}

	public virtual void MOCIFAAJDAA()
	{
		base.DoAfterHide();
		IHFILHIAGLG.EMLIBBBMNLN(PIENENKELMH);
		IHFILHIAGLG.EMLIBBBMNLN(DFMCOJFCAHL);
		EMHGMNAABDN.DoAfterHide();
		BKLPGLKGCLG.NEKOOIGPALB();
	}

	[CompilerGenerated]
	private void LFIOIJHBPGJ(UITweener MGDJMGHCAAI)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
		};
	}

	public void EOOIBDMOAFJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		JFLKDFPEDNO = true;
		SavingLastSelected.instance.SaveLastWeapon(JMMJHCOKCGG);
	}

	public void BDODGNOMDMF(WeaponLevelsSetup JMMJHCOKCGG, bool LGIIPHPACIC = true)
	{
		EEOODFKEJIG();
		BKLPGLKGCLG.UpdateRightContent(LGIIPHPACIC);
		EMHGMNAABDN.PJBGBJAIJDJ(LGIIPHPACIC);
		GGPADKNLEPN();
		OPNBMFDJKAP();
		FKEJAMIBKMN();
		if (JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
		{
			FHFIPPFJIAH.deliveringAnimation = false;
		}
		else
		{
			FHFIPPFJIAH.NMMFJMPLPIM(JMMJHCOKCGG.upgradesProgress);
		}
	}

	private WeaponLevelsSetup IILKJHANLBD()
	{
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		if (weaponLevelsSetup == null)
		{
			UnityEngine.Debug.Log("FJDACAACLLI");
			weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[0];
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return weaponLevelsSetup;
		}
		WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup2 != null)
		{
			return weaponLevelsSetup2;
		}
		WeaponLevelsSetup unlockedWeaponWithNotification = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
		if (unlockedWeaponWithNotification != null)
		{
			return unlockedWeaponWithNotification;
		}
		return weaponLevelsSetup;
	}

	private void GBIPGAPJDMO()
	{
		if (EMECGGIPPNB == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			BKLPGLKGCLG.UpdateDeliveringTime((float)selectedIcon.weaponSetup.remainingDeliveringSeconds, selectedIcon.weaponSetup.progressDelivering);
		}
		if (EMECGGIPPNB == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			EMHGMNAABDN.UpdateDeliveringTime((float)selectedIcon.weaponSetup.remainingDeliveringSeconds, selectedIcon.weaponSetup.progressDelivering);
		}
	}

	public void CNDIGGJNJLI()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.UpdateGraphics();
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<WeaponPreviewCamera>.instance.Hide();
		selectedIcon.SetHighlight(NCFKLBGOEEF: false);
	}

	private void OAOEKBFGBBP(WeaponCategory HJFKNAOICJO)
	{
		if (weaponIcons == null)
		{
			weaponIcons = new List<WeaponGuiRecord>();
		}
		else
		{
			weaponIcons.Clear();
		}
		if (LLIKJCHOOIE == null)
		{
			LLIKJCHOOIE = new List<NameGuiRecord>();
		}
		else
		{
			LLIKJCHOOIE.Clear();
		}
		IHFILHIAGLG.FreeObjectsWithPrefab(PIENENKELMH);
		IHFILHIAGLG.FreeObjectsWithPrefab(DFMCOJFCAHL);
		if (MEJMLNDFDBP.DAPNEDOBEEK((int)HJFKNAOICJO))
		{
			FPHAGAEIDBF(HJFKNAOICJO, FOIDJEDBFDN[HJFKNAOICJO]);
			return;
		}
		foreach (WeaponCategory value in Enum.GetValues(typeof(WeaponCategory)))
		{
			if (FOIDJEDBFDN.ContainsKey(value) && MEJMLNDFDBP.DAPNEDOBEEK((int)value) && (value & HJFKNAOICJO) == value)
			{
				FPHAGAEIDBF(value, FOIDJEDBFDN[value]);
			}
		}
	}

	public void CMMGDOIBBOH()
	{
		DCNNBHOHCNI.Play();
		Singleton<WeaponPreviewCamera>.instance.StartFastRotation();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 242f, 1325f, 1464f);
		tweenAlpha.NumOfRepetitions = 5;
		tweenAlpha.style = UITweener.Style.PingPong;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1518f, 720f, 5f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
			};
		};
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1329f, new Vector3(207f, 1607f, 436f), new Vector3(1845f, 3f, 1217f)).onFinished = delegate
		{
			TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 742f, Vector3.zero, Vector3.zero, useLocal: false).onFinished = delegate
		{
			Singleton<WeaponPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	public void CJFDLJMLNNB(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.DecalWasShown, LFGKDBIHLGI, 1, 1, string.Empty);
	}

	private void PAPCGBIKPLG()
	{
		if (FIDNMMDEDEH)
		{
			if (selectedIcon == null)
			{
				UnityEngine.Debug.LogError("Choose icon in bottom before calling Display model.");
				return;
			}
			WeaponLevelsSetup weaponSetup = selectedIcon.weaponSetup;
			Singleton<WeaponPreviewCamera>.instance.DisplayeWeapon(weaponSetup.CKNHABFHJIP, weaponSetup.IMMNMGDBOOD, weaponSetup.NIGBPGFLMMC, weaponSetup.DFDLEGCJLBG);
		}
	}

	public void GGPADKNLEPN()
	{
		foreach (WeaponEquipSlotButton item in DGMADFPFHHE())
		{
			item.OHMIGANDELN();
		}
	}

	public void UpdateSalesInCategories()
	{
		foreach (WeaponEquipSlotButton weaponCategoryButton in weaponCategoryButtons)
		{
			weaponCategoryButton.Sale();
		}
		foreach (NameGuiRecord item in LLIKJCHOOIE)
		{
			item.Sale();
		}
	}

	public void NKPKFLCOPEF()
	{
	}

	[CompilerGenerated]
	private void IEMCGOIEIHN(UITweener GCNILAHBDMJ)
	{
		Singleton<WeaponPreviewCamera>.instance.DefaultRotation();
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
	}

	private void DBMOFCJBHFA()
	{
		if (NPFFMLLLDAF())
		{
			UpdateNotificationsInCategories();
		}
	}

	public void UpdateNotificationsInCategories()
	{
		foreach (WeaponEquipSlotButton weaponCategoryButton in weaponCategoryButtons)
		{
			weaponCategoryButton.Notification();
		}
	}

	private WeaponLevelsSetup KMEGKMFLDPI()
	{
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		if (weaponLevelsSetup == null)
		{
			UnityEngine.Debug.Log("Last weapon not choosen!!!!!");
			weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[0];
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return weaponLevelsSetup;
		}
		WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup2 != null)
		{
			return weaponLevelsSetup2;
		}
		WeaponLevelsSetup unlockedWeaponWithNotification = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
		if (unlockedWeaponWithNotification != null)
		{
			return unlockedWeaponWithNotification;
		}
		return weaponLevelsSetup;
	}

	private void OHMLGALJLBA()
	{
		FLCDOLDNLHG(NABOFKMBMKH: false);
		IEIKMKFHDOJ.repositionNow = false;
		IEIKMKFHDOJ.onReposition = IHNMNOOEHGM;
	}

	public void NLJELHPBLEI()
	{
	}

	public void UpdateGui(WeaponLevelsSetup JMMJHCOKCGG, bool LGIIPHPACIC = true)
	{
		Refresh();
		BKLPGLKGCLG.UpdateRightContent(LGIIPHPACIC);
		EMHGMNAABDN.UpdateLeftContent(LGIIPHPACIC);
		UpdateNotificationsInCategories();
		UpdateSalesInCategories();
		UpdateBottomIcon();
		if (JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			FHFIPPFJIAH.deliveringAnimation = true;
		}
		else
		{
			FHFIPPFJIAH.FillCircle(JMMJHCOKCGG.upgradesProgress);
		}
	}

	public override void MEPKGFFNPAD()
	{
		base.DoAfterShowUp();
		FIDNMMDEDEH = true;
		PAPCGBIKPLG();
	}

	private void FPHAGAEIDBF(WeaponCategory FABOAIMLLOI, string PGJNIAIHKDB)
	{
		List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
		foreach (WeaponLevelsSetup weaponLevelsSetup3 in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup3.BHCEOOLEHHG == FABOAIMLLOI && weaponLevelsSetup3.canBeShownInScreen)
			{
				list.Add(weaponLevelsSetup3);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(FABOAIMLLOI);
		NameGuiRecord nameGuiRecord = IHFILHIAGLG.InstantiateAsChild(DFMCOJFCAHL, Vector3.zero, Quaternion.identity, IEIKMKFHDOJ.gameObject) as NameGuiRecord;
		if (nameGuiRecord != null)
		{
			nameGuiRecord.name = $"{PGJNIAIHKDB} 00 {FABOAIMLLOI.ToString()}";
			nameGuiRecord.InitializeName(FABOAIMLLOI);
			LLIKJCHOOIE.Add(nameGuiRecord);
		}
		for (int i = 0; i < list.Count; i++)
		{
			WeaponLevelsSetup weaponLevelsSetup2 = list[i];
			WeaponGuiRecord weaponGuiRecord = IHFILHIAGLG.InstantiateAsChild(PIENENKELMH, Vector3.zero, Quaternion.identity, IEIKMKFHDOJ.gameObject) as WeaponGuiRecord;
			if (!(weaponGuiRecord == null))
			{
				weaponGuiRecord.name = string.Format("{0} {1} {2}lvl {3}", PGJNIAIHKDB, weaponLevelsSetup2.PJNBNCCKFLP.ToString("D2"), (1 + weaponLevelsSetup2.unlockLevelIndex).ToString("D2"), weaponLevelsSetup2.weaponName);
				weaponGuiRecord.InitializeWeapon(weaponLevelsSetup2);
				if (weaponLevelsSetup2 == slotForCategory.weaponLevelsSetup)
				{
					weaponGuiRecord.SetEquiped(KGGCJPEKIAD: true);
				}
				if (weaponLevelsSetup == null && weaponLevelsSetup2.unlockLevelIndex == 0)
				{
					SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup2);
					weaponLevelsSetup = weaponLevelsSetup2;
				}
				weaponIcons.Add(weaponGuiRecord);
			}
		}
	}

	internal void GFDDLFMLJMJ(WeaponLevelsSetup MBNLFKHLDBH, ABDDBOABKOK ILOAGGPDJCD)
	{
		if (!MBNLFKHLDBH.FICHPKKDGBK)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ActivateWeapon, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"LevelName",
				MBNLFKHLDBH.DHHKOKKDDDO()
			} }), 0, 0, string.Empty);
		}
		MBNLFKHLDBH.ActivateWeapon();
		AfterWeaponIsBought(MBNLFKHLDBH, ILOAGGPDJCD);
	}

	private void AFBHOJNGDAC()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			ShowWeapon(selectedIcon.weaponSetup);
		}
	}

	public void SetSelectedIcon(WeaponGuiRecord HDEGOGFCNAC)
	{
		selectedIcon = HDEGOGFCNAC;
	}

	public virtual void NEOLLOMIKPK()
	{
		WeaponLevelsSetup weaponLevelsSetup = PBGABLEIDEM();
		SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
		DKCHELDAACD(weaponLevelsSetup);
		BNENDKELEPK();
	}

	public virtual void JDNNJCHMFHF()
	{
		base.DoAfterHide();
		IHFILHIAGLG.EMLIBBBMNLN(PIENENKELMH);
		IHFILHIAGLG.NDPKMHDALCM(DFMCOJFCAHL);
		EMHGMNAABDN.MLAEGNJBKIM();
		BKLPGLKGCLG.NMMEDNEGDNI();
	}

	public void BNENDKELEPK()
	{
		DDOOMMACBAJ(selectedIcon.ADOICOAEIFA());
		GGPADKNLEPN();
		IPGFLFDGCEO();
	}

	public virtual void EHIAJIMBLCD()
	{
		base.DoBeforeHide();
		Singleton<WeaponPreviewCamera>.instance.JIMPCGDILNF();
		FMFHOPFBMOO().LPGHPNDKMLN(NCFKLBGOEEF: false);
	}

	public void GHNCEHINLPI()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.PDLMIBCLICE();
		}
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.BuyWeaponUpgrade:
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.InstantBuyWeapon:
		case DatabaseAction.ActivateWeapon:
			UpdateGui(selectedIcon.weaponSetup);
			break;
		}
	}

	public void EquipWeapon(WeaponLevelsSetup MBNLFKHLDBH, int INNPEACFFHD, ABDDBOABKOK ILOAGGPDJCD)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		PlayerInventory.instance.inventorySlots[INNPEACFFHD].weaponIndex = MBNLFKHLDBH.indexInLevelManager;
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.GGKGGMNIDMI = PlayerInventory.instance.equippedWeapons;
		if (!Singleton<GameController>.instance.isTutorial)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.EquipWeapon, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"Index",
					MBNLFKHLDBH.indexInLevelManager.ToString()
				},
				{
					"Name",
					MBNLFKHLDBH.DHHKOKKDDDO()
				},
				{ "SlotIndex", INNPEACFFHD },
				{
					"ArmyPower",
					LevelManager.instance.armyPower
				},
				{ "SpecialFeature", MBNLFKHLDBH.specialFeature }
			}), 0, 0, string.Empty);
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.EquipWeapon);
		if (ILOAGGPDJCD == ABDDBOABKOK.WeaponScreen && isShowed)
		{
			BKLPGLKGCLG.ShowEquipAnimation();
			EMHGMNAABDN.UpdateContentAfterEquip();
			if (!Singleton<GameController>.instance.isTutorial)
			{
				int armyPowerX2 = LevelManager.instance.armyPowerX10;
				int hONEKCJDJDN = armyPowerX2 - armyPowerX;
				GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX2, 0.05f);
			}
			{
				foreach (WeaponGuiRecord weaponIcon in GuiScreenSingle<WeaponScreen>.instance.weaponIcons)
				{
					weaponIcon.SetEquiped(MBNLFKHLDBH == weaponIcon.weaponSetup);
				}
				return;
			}
		}
		if (ILOAGGPDJCD == ABDDBOABKOK.Rental && GuiElementSingle<RentalDialog>.instance.isShowed)
		{
			int armyPowerX3 = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN2 = armyPowerX3 - armyPowerX;
			GuiElementSingle<RentalDialog>.instance.GHGJLMAJJGG.StartAnimation(hONEKCJDJDN2, armyPowerX3, 0.05f);
		}
	}

	[SpecialName]
	private void AHGOPPAEGBA(WeaponGuiRecord IDEBKDPMPGM)
	{
		_003CCGPAPPCGMGP_003Ek__BackingField = IDEBKDPMPGM;
	}

	internal void BJBCNPHMEBI(WeaponLevelsSetup MBNLFKHLDBH, int DBOLKNNJGMH, ABDDBOABKOK ILOAGGPDJCD)
	{
		if (!MBNLFKHLDBH.FICHPKKDGBK)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			int num = ((ILOAGGPDJCD != ABDDBOABKOK.BlackMarket) ? MBNLFKHLDBH.priceGold : MBNLFKHLDBH.blackmarketPrice);
			int num2 = ((ILOAGGPDJCD != ABDDBOABKOK.BlackMarket) ? MBNLFKHLDBH.price : 0);
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Name", MBNLFKHLDBH.DHHKOKKDDDO());
			dictionary.Add("Warbucks", num2);
			dictionary.Add("Gold", num);
			dictionary.Add("UnlockLevel", MBNLFKHLDBH.unlockLevel.displayNumber);
			dictionary.Add("StartTime", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			dictionary.Add("discount", DBOLKNNJGMH);
			string objData = JsonConvert.SerializeObject(dictionary);
			requestBuffer.AddRequest(DatabaseAction.BuyWeapon, objData, MBNLFKHLDBH.price * (100 - DBOLKNNJGMH) / 100, MBNLFKHLDBH.priceGold * (100 - DBOLKNNJGMH) / 100, MBNLFKHLDBH.DHHKOKKDDDO());
		}
		MBNLFKHLDBH.Buy();
		if (MBNLFKHLDBH.weaponDeliveryTime == 0)
		{
			GFDDLFMLJMJ(MBNLFKHLDBH, ILOAGGPDJCD);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
		}
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterWeaponBought);
	}

	public void WeaponCategoryButtonClick(WeaponCategory FABOAIMLLOI)
	{
		UnityEngine.Debug.Log("Clicked on category " + FABOAIMLLOI);
		int num = 0;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & FABOAIMLLOI) == FABOAIMLLOI)
			{
				num = i;
			}
		}
		WeaponEquipSlotButton weaponEquipSlotButton = weaponCategoryButtons[num];
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeaponForIndex(num);
		if (weaponLevelsSetup == null || weaponLevelsSetup.BHCEOOLEHHG != (weaponLevelsSetup.BHCEOOLEHHG & weaponEquipSlotButton.weaponCategory))
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup2 in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup2.BHCEOOLEHHG == (weaponLevelsSetup2.BHCEOOLEHHG & weaponEquipSlotButton.weaponCategory) && weaponLevelsSetup2.unlockLevelIndex == 0)
				{
					weaponLevelsSetup = weaponLevelsSetup2;
					SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
					break;
				}
			}
			if (weaponLevelsSetup == null)
			{
				foreach (WeaponLevelsSetup weaponLevelsSetup3 in LevelManager.instance.weaponLevelsSetups)
				{
					if (weaponLevelsSetup3.BHCEOOLEHHG == (weaponLevelsSetup3.BHCEOOLEHHG & weaponEquipSlotButton.weaponCategory))
					{
						weaponLevelsSetup = weaponLevelsSetup3;
						SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
						break;
					}
				}
			}
		}
		AHDPLLLMFJB(weaponLevelsSetup);
		Select();
	}

	private void APOOIEKEBIC(UITweener GCNILAHBDMJ)
	{
		Singleton<WeaponPreviewCamera>.instance.KNFKCALMEDM();
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 665f, new Vector3(1587f, 1789f, 845f), useLocal: false);
	}

	[CompilerGenerated]
	private void PDNAICBMBOF()
	{
		IEIKMKFHDOJ.onReposition = null;
		IEIKMKFHDOJ.repositionNow = false;
		FLCDOLDNLHG(NABOFKMBMKH: true);
		Vector3 zero = Vector3.zero;
		Transform parent = selectedIcon.transform;
		for (int i = 0; i < 2; i++)
		{
			zero += parent.localPosition;
			parent = parent.parent;
		}
		NFLPPGKCOBL.AlignToCenter(zero, instant: true);
	}

	public void UpdateBottomGraphics()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.UpdateGraphics();
		}
	}

	public void CFBDODAIILB(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.BuyCardPack, LFGKDBIHLGI, 1, 1, string.Empty);
	}

	public void UpdateBottomIcon()
	{
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.UpdateGraphics();
	}

	private void KGGIGGPKCJF(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-56):
		case (DatabaseAction)(-54):
		case DatabaseAction.GameStartedTutorial:
		case DatabaseAction.TutorialEnded:
		case DatabaseAction.ChangeNameAndPassword:
		case DatabaseAction.CreateFullAccount:
			UpdateGui(PAAMHOJOFFP().GMEFFFKMDCE(), LGIIPHPACIC: false);
			break;
		}
	}

	private void ABNMOHMKOFK(UITweener GCNILAHBDMJ)
	{
		Singleton<WeaponPreviewCamera>.instance.DefaultRotation();
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1106f, new Vector3(1001f, 836f, 518f));
	}

	internal void MBKJEPDJFKJ(WeaponLevelsSetup MBNLFKHLDBH, bool CDMKCIKHIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		int boughtIndex = MBNLFKHLDBH.MGAGEKAAJOL.boughtIndex;
		MBNLFKHLDBH.MGAGEKAAJOL.JFPJCGJOKKA();
		requestBuffer.AddRequest(DatabaseAction.ActivateWeaponUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				MBNLFKHLDBH.DHHKOKKDDDO()
			},
			{ "BoughtIndex", boughtIndex },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			}
		}), 0, 0, string.Empty);
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterWeaponUpgrade);
	}

	[CompilerGenerated]
	private void NDHJAOKFIFD(UITweener MKAPOHKFIJH)
	{
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
	}

	public void DDOOMMACBAJ(WeaponLevelsSetup JMMJHCOKCGG)
	{
		if (!JMMJHCOKCGG.showed && JMMJHCOKCGG.unlocked && !JMMJHCOKCGG.tryOutWeapon)
		{
			WasShown(JMMJHCOKCGG.DHHKOKKDDDO());
		}
		JMMJHCOKCGG.showed = true;
		SavingLastSelected.instance.SaveLastWeapon(JMMJHCOKCGG);
		PAPCGBIKPLG();
		BKLPGLKGCLG.BGNGJAMOPAG(JMMJHCOKCGG);
		EMHGMNAABDN.NBOPNJMNPKL(JMMJHCOKCGG);
		BDODGNOMDMF(JMMJHCOKCGG, LGIIPHPACIC: false);
		EMECGGIPPNB = JMMJHCOKCGG.weaponState;
	}

	private void ENMPOCFPLOA(bool NABOFKMBMKH)
	{
		if (selectedIcon != null)
		{
			FMFHOPFBMOO().JLDBLKLBCEG(NABOFKMBMKH);
		}
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.EFMLEKOHOEC(NABOFKMBMKH);
		}
		foreach (NameGuiRecord item in LLIKJCHOOIE)
		{
			item.HKOCMCGBKHD(NABOFKMBMKH);
		}
	}

	[SpecialName]
	private void JNPHAIHMHEP(List<WeaponEquipSlotButton> IDEBKDPMPGM)
	{
		_003CNGGDMBLIOOD_003Ek__BackingField = IDEBKDPMPGM;
	}

	internal void NHAPEPLDGBB(WeaponLevelsSetup MBNLFKHLDBH, bool CDMKCIKHIMM)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		int instantBuyPrice = MBNLFKHLDBH.MGAGEKAAJOL.instantBuyPrice;
		int num = MBNLFKHLDBH.MGAGEKAAJOL.BDNCLOPCDLO();
		Singleton<EventTrackingManager>.instance.RegisterGameItemDeliverEvent("VIPMemeberShipAlmostEnded", "_pistol", MBNLFKHLDBH.DHHKOKKDDDO() + "ID_ARENARULES_MORECRATES" + MBNLFKHLDBH.MGAGEKAAJOL.LHLGAAEEKID(), MBNLFKHLDBH.MGAGEKAAJOL.EKLDJINDIOF(), MBNLFKHLDBH.remainingDeliveringSeconds);
		MBNLFKHLDBH.MGAGEKAAJOL.OOCJMJLELJB();
		float num2 = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-28)).FLOATVALUE;
		float num3 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelProbability).FLOATVALUE;
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponDeliveryCost(MBNLFKHLDBH.BHCEOOLEHHG, MBNLFKHLDBH, NJMAGCAMDFM: true);
		requestBuffer.AddRequest((DatabaseAction)(-86), JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"ID_GUI_EQUIPPED",
				MBNLFKHLDBH.DHHKOKKDDDO()
			},
			{ "BestSkill", num },
			{ "bazooka_idle", instantBuyPrice },
			{
				"CONFIRM",
				LevelManager.instance.armyPower
			},
			{ "Days_Since_Install", num2 },
			{ "ID_CONTINUE", num3 },
			{ "\":\n", num4 }
		}), 1, instantBuyPrice, MBNLFKHLDBH.DHHKOKKDDDO());
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterGameOnServerResponse);
	}

	public virtual void LMDGEMBENHG()
	{
		base.DoBeforeShowUp();
		FIDNMMDEDEH = true;
	}

	private void OBLCAELGDNH()
	{
		if (!isShowed)
		{
			return;
		}
		IPGFLFDGCEO();
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.EIDJLBFGNDO();
		}
		EMHGMNAABDN.NIFNIFGLAHA();
		BKLPGLKGCLG.FDMKDNPPOGF();
	}

	internal void CIFCNODFLML(WeaponLevelsSetup MBNLFKHLDBH, ABDDBOABKOK ILOAGGPDJCD)
	{
		if (!MBNLFKHLDBH.FICHPKKDGBK)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			float num = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-124)).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward7).FLOATVALUE;
			requestBuffer.AddRequest((DatabaseAction)(-18), JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"FR",
					MBNLFKHLDBH.DHHKOKKDDDO()
				},
				{ "PlayerName", MBNLFKHLDBH.instantWeaponDeliveryPrice },
				{ "Aquiire map id ", num },
				{ "NewCountryCode", num2 }
			}), 1, MBNLFKHLDBH.instantWeaponDeliveryPrice, MBNLFKHLDBH.DHHKOKKDDDO());
		}
		MBNLFKHLDBH.InstantBuyWeapon();
		AfterWeaponIsBought(MBNLFKHLDBH, ILOAGGPDJCD);
	}

	[SpecialName]
	public WeaponGuiRecord PAAMHOJOFFP()
	{
		return _003CCGPAPPCGMGP_003Ek__BackingField;
	}

	public void NMJPGMLMCAD(WeaponCategory FABOAIMLLOI)
	{
		UnityEngine.Debug.Log("Warbucks" + FABOAIMLLOI);
		int num = 1;
		for (int i = 1; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & FABOAIMLLOI) == FABOAIMLLOI)
			{
				num = i;
			}
		}
		WeaponEquipSlotButton weaponEquipSlotButton = weaponCategoryButtons[num];
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeaponForIndex(num);
		if (weaponLevelsSetup == null || weaponLevelsSetup.BHCEOOLEHHG != (weaponLevelsSetup.BHCEOOLEHHG & weaponEquipSlotButton.CKNGDFJPKIA()))
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup2 in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup2.BHCEOOLEHHG == (weaponLevelsSetup2.BHCEOOLEHHG & weaponEquipSlotButton.HHKICCEJBJI()) && weaponLevelsSetup2.unlockLevelIndex == 0)
				{
					weaponLevelsSetup = weaponLevelsSetup2;
					SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
					break;
				}
			}
			if (weaponLevelsSetup == null)
			{
				foreach (WeaponLevelsSetup weaponLevelsSetup3 in LevelManager.instance.weaponLevelsSetups)
				{
					if (weaponLevelsSetup3.BHCEOOLEHHG == (weaponLevelsSetup3.BHCEOOLEHHG & weaponEquipSlotButton.weaponCategory))
					{
						weaponLevelsSetup = weaponLevelsSetup3;
						SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
						break;
					}
				}
			}
		}
		AHDPLLLMFJB(weaponLevelsSetup);
		MIIMDHKCINK();
	}

	[SpecialName]
	public List<WeaponEquipSlotButton> DGMADFPFHHE()
	{
		return _003CNGGDMBLIOOD_003Ek__BackingField;
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		if (!isShowed)
		{
			return;
		}
		UpdateSalesInCategories();
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.SetSale();
		}
		EMHGMNAABDN.SetSaleAndPrize();
		BKLPGLKGCLG.SetSaleAndPrize();
	}

	private void GFKMDLNPNHP(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.FacebookLoginOk:
		case DatabaseAction.PromotePlayer:
		case DatabaseAction.GetSquads:
		case DatabaseAction.PromotePlayerToFounder:
		case DatabaseAction.CreateFullAccount:
		case DatabaseAction.GetSquadWarsDivision:
			BDODGNOMDMF(selectedIcon.EAJJDMMGMKK(), LGIIPHPACIC: false);
			break;
		}
	}

	public void AFCNHKNBDIH(WeaponLevelsSetup MBNLFKHLDBH, ABDDBOABKOK ILOAGGPDJCD)
	{
		int iNNPEACFFHD = -1;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & MBNLFKHLDBH.BHCEOOLEHHG) == MBNLFKHLDBH.BHCEOOLEHHG)
			{
				iNNPEACFFHD = i;
			}
		}
		EquipWeapon(MBNLFKHLDBH, iNNPEACFFHD, ILOAGGPDJCD);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1905f);
		if (MBNLFKHLDBH.BHCEOOLEHHG == ~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade))
		{
			int num = LevelManager.instance.NumberOfBought(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher);
			if (num == 1)
			{
				Singleton<MessageManager>.instance.AddMessage(new FNGCABFGGLA(MBNLFKHLDBH), LJMMJDNNIFH: true);
			}
		}
	}

	public void Refresh()
	{
	}

	private void HBBEDANBMOI()
	{
		WeaponCategory bHCEOOLEHHG = selectedIcon.weaponSetup.BHCEOOLEHHG;
		foreach (WeaponEquipSlotButton weaponCategoryButton in weaponCategoryButtons)
		{
			weaponCategoryButton.Highlight(bHCEOOLEHHG);
		}
	}

	public void AfterWeaponIsBought(WeaponLevelsSetup MBNLFKHLDBH, ABDDBOABKOK ILOAGGPDJCD)
	{
		int iNNPEACFFHD = -1;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & MBNLFKHLDBH.BHCEOOLEHHG) == MBNLFKHLDBH.BHCEOOLEHHG)
			{
				iNNPEACFFHD = i;
			}
		}
		EquipWeapon(MBNLFKHLDBH, iNNPEACFFHD, ILOAGGPDJCD);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
		if (MBNLFKHLDBH.BHCEOOLEHHG == WeaponCategory.RocketLauncher)
		{
			int num = LevelManager.instance.NumberOfBought(WeaponCategory.RocketLauncher);
			if (num == 1)
			{
				Singleton<MessageManager>.instance.AddMessage(new FNGCABFGGLA(MBNLFKHLDBH));
			}
		}
	}

	private void KMNCPCBDMJN()
	{
		if (EMECGGIPPNB == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			BKLPGLKGCLG.UpdateDeliveringTime((float)FMFHOPFBMOO().OFABMGFOFPI().remainingDeliveringSeconds, selectedIcon.OFABMGFOFPI().progressDelivering);
		}
		if (EMECGGIPPNB == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
		{
			EMHGMNAABDN.UpdateDeliveringTime((float)PAAMHOJOFFP().EAJJDMMGMKK().remainingDeliveringSeconds, FMFHOPFBMOO().GMEFFFKMDCE().progressDelivering);
		}
	}

	public void AnimateUpgrade()
	{
		DCNNBHOHCNI.Play();
		Singleton<WeaponPreviewCamera>.instance.StartFastRotation();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 3.5f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1f, 0f, 0.3f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
			};
		};
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 2f, new Vector3(48f, 56f, 1f), new Vector3(288f, 336f, 1f)).onFinished = delegate
		{
			TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, Vector3.zero, Vector3.zero).onFinished = delegate
		{
			Singleton<WeaponPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	private void PFLJKJCHCIF()
	{
		if (NPFFMLLLDAF())
		{
			GGPADKNLEPN();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		if (isShowed)
		{
			UpdateNotificationsInCategories();
		}
	}

	private WeaponLevelsSetup PBGABLEIDEM()
	{
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		if (weaponLevelsSetup == null)
		{
			UnityEngine.Debug.Log("day {0} data:\n");
			weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[0];
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = true;
			return weaponLevelsSetup;
		}
		WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup2 != null)
		{
			return weaponLevelsSetup2;
		}
		WeaponLevelsSetup unlockedWeaponWithNotification = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
		if (unlockedWeaponWithNotification != null)
		{
			return unlockedWeaponWithNotification;
		}
		return weaponLevelsSetup;
	}

	private void FLCDOLDNLHG(bool NABOFKMBMKH)
	{
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(NABOFKMBMKH);
		}
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.GUIForReposition(NABOFKMBMKH);
		}
		foreach (NameGuiRecord item in LLIKJCHOOIE)
		{
			item.GUIForReposition(NABOFKMBMKH);
		}
	}

	public void Select()
	{
		ShowWeapon(selectedIcon.weaponSetup);
		UpdateNotificationsInCategories();
		UpdateSalesInCategories();
	}

	private void DKCHELDAACD(WeaponLevelsSetup JMMJHCOKCGG)
	{
		OGPCPMGOAMA oGPCPMGOAMA = new OGPCPMGOAMA();
		oGPCPMGOAMA.JMMJHCOKCGG = JMMJHCOKCGG;
		if (selectedIcon != null)
		{
			FMFHOPFBMOO().LINPOIDDFGA(NCFKLBGOEEF: false);
		}
		WeaponCategory hJFKNAOICJO = PlayerInventory.instance.GetSlotForCategory(oGPCPMGOAMA.JMMJHCOKCGG.BHCEOOLEHHG)?.category ?? oGPCPMGOAMA.JMMJHCOKCGG.BHCEOOLEHHG;
		OAOEKBFGBBP(hJFKNAOICJO);
		int num = weaponIcons.FindIndex(oGPCPMGOAMA.BMCMDMKGHHO);
		if (num == -1)
		{
			AHGOPPAEGBA(weaponIcons[1]);
		}
		else
		{
			AHGOPPAEGBA(weaponIcons[num]);
		}
		selectedIcon.PJEEJBPFNFA(NCFKLBGOEEF: false);
		HBBEDANBMOI();
		OHMLGALJLBA();
	}

	private void JNNEJFPMEHM(UITweener CKOINALCMFJ)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 266f, 1645f);
	}

	private void CEFHLCDGICG(bool NABOFKMBMKH)
	{
		if (PAAMHOJOFFP() != null)
		{
			selectedIcon.APHECPIPBPK(NABOFKMBMKH);
		}
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.CNIMGBOHGCF(NABOFKMBMKH);
		}
		foreach (NameGuiRecord item in LLIKJCHOOIE)
		{
			item.AJBCKOLDKAB(NABOFKMBMKH);
		}
	}

	protected override void Update()
	{
		base.Update();
		if (selectedIcon != null && selectedIcon.weaponSetup != null)
		{
			if (EMECGGIPPNB != selectedIcon.weaponSetup.weaponState)
			{
				UnityEngine.Debug.Log($"Weapon state changed from \"{EMECGGIPPNB.ToString().ToUpper()}\" to \"{selectedIcon.weaponSetup.weaponState.ToString().ToUpper()}\"");
				EMECGGIPPNB = selectedIcon.weaponSetup.weaponState;
				UpdateGui(selectedIcon.weaponSetup, LGIIPHPACIC: false);
			}
			ADDICBANAAB += Time.deltaTime;
			if (ADDICBANAAB >= 0.333f)
			{
				ADDICBANAAB -= 0.333f;
				GBIPGAPJDMO();
			}
		}
	}

	public virtual void MMLOAKGDDGF()
	{
		base.DoAfterHide();
		IHFILHIAGLG.EMLIBBBMNLN(PIENENKELMH);
		IHFILHIAGLG.NDPKMHDALCM(DFMCOJFCAHL);
		EMHGMNAABDN.DoAfterHide();
		BKLPGLKGCLG.DoAfterHide();
	}

	private void JLHCKLBGOFA(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.UniqueSquadNameFailure:
		case DatabaseAction.UniqueSquadNameSuccess:
		case DatabaseAction.CheckUniqueSquadName:
		case DatabaseAction.RemoveUserFromSquad:
		case (DatabaseAction)123:
		case DatabaseAction.InstantBuyUnit:
			BDODGNOMDMF(FMFHOPFBMOO().ADOICOAEIFA(), LGIIPHPACIC: false);
			break;
		}
	}

	public void MCFPJFKFJPH(WeaponGuiRecord HDEGOGFCNAC)
	{
		selectedIcon = HDEGOGFCNAC;
	}

	[SpecialName]
	private void ABJNDPCAIIC(List<WeaponEquipSlotButton> IDEBKDPMPGM)
	{
		_003CNGGDMBLIOOD_003Ek__BackingField = IDEBKDPMPGM;
	}
}
