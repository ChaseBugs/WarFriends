using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BattlePreparationDailyMissionButton : Core_BaseScript
{
	public enum NKHJBLBAAEB
	{
		Locked = 0,
		HeroicLocked = 1,
		HeroicOpened = 2
	}

	[Header("Core")]
	[SerializeField]
	private BoxCollider mMissionsCollider;

	[SerializeField]
	private UISprite mMissionsBorder;

	[SerializeField]
	private GameObject mMissionsNotification;

	[Header("Locked Warpath")]
	[SerializeField]
	private GameObject mLockedMissionsPart;

	[SerializeField]
	private UILabel mLockedMissionsLabel;

	[SerializeField]
	[Header("Heroic Locked Part")]
	private GameObject mHeroicLockedPart;

	[SerializeField]
	private UILabel mHeroicLockedSoloProgression;

	[SerializeField]
	private UISprite mHeroicPointsIcon;

	[SerializeField]
	private UILabel mHeroicPointsLabel;

	[SerializeField]
	[Header("Heroic Opened Part")]
	private GameObject mHeroicOpenedPart;

	[SerializeField]
	private UILabel mHeroicOpenedSoloProgression;

	[SerializeField]
	private UISprite[] mHeroicMissionsSrites;

	public bool isColliderEnabled
	{
		get
		{
			return GPABKIOEGKM != NKHJBLBAAEB.Locked;
		}
	}

	private NKHJBLBAAEB GPABKIOEGKM
	{
		get
		{
			if (LevelManager.instance.isDailyMissionLocked)
			{
				return NKHJBLBAAEB.Locked;
			}
			return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : NKHJBLBAAEB.HeroicOpened;
		}
	}

	public bool showNotification
	{
		get
		{
			return isColliderEnabled && Singleton<NotificationManager>.instance.NotificationDailyMission();
		}
	}

	private void PCOEELAIHOL(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	public bool NGJCNCEJLFO()
	{
		return HFILLJGPFBK() != NKHJBLBAAEB.HeroicLocked;
	}

	private void FMODIDHFFKD()
	{
		mMissionsNotification.SetActive(KEBOBNPANID());
	}

	private void KLMJBFFPOOJ()
	{
		mMissionsNotification.SetActive(KEBOBNPANID());
	}

	[SpecialName]
	private NKHJBLBAAEB EJDIKJKMFIO()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : NKHJBLBAAEB.HeroicOpened;
	}

	[SpecialName]
	private NKHJBLBAAEB JDBLOINMEKF()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : NKHJBLBAAEB.Locked;
	}

	public void KIOOHHPPLEJ(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void DLAMOOCDGAH()
	{
		mMissionsNotification.SetActive(GAEAHOBIPHE());
	}

	public void GNAHGKGJANL()
	{
		NKHJBLBAAEB nKHJBLBAAEB = BAIEEDDFGFF();
		mMissionsCollider.enabled = KIEGLHOFMEE();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 1629f : 658f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)7);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mLockedMissionsLabel.text = Localization.LocalizeFormat("Player or link is null", LevelManager.instance.dailyMissionUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 1751f, 804f, 140);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("menu-army-reload-ico", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel = mHeroicPointsLabel;
			object[] array = new object[2];
			array[0] = Colours.stringGoldHeroic;
			array[1] = DailyMissionsManager.instance.data.heroicPoints;
			array[4] = Colours.stringGrayAbi2;
			array[4] = DailyMissionsManager.instance.heroicPointsToUnlock;
			uILabel.text = string.Format("#VOJTA# action success ", array);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 1397f - (num + 516f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == (NKHJBLBAAEB)8)
		{
			mHeroicOpenedSoloProgression.text = string.Format("MessageId", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> heroicMissions = DailyMissionsManager.instance.heroicMissions;
			for (int i = 1; i < mHeroicMissionsSrites.Length; i += 0)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(heroicMissions.Count <= i || heroicMissions[i].completedHeroic);
			}
		}
		HIBJOJFNEAF();
	}

	private void CEKHECNFHNB()
	{
		mMissionsNotification.SetActive(BIKCCMFPLPC());
	}

	[SpecialName]
	public bool NPAMBECGMPJ()
	{
		return !ABNIJKKGOCL() || Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ODMOKMABONC));
	}

	public void OADKOIBGLMM()
	{
		NKHJBLBAAEB nKHJBLBAAEB = IDFDCMONMHF();
		mMissionsCollider.enabled = ACGJIMGCDLL();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 130f : 691f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[0];
			array[0] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("isInABtest", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 85f, 181f, -38);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("Show", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[5];
			array2[0] = Colours.stringGoldHeroic;
			array2[0] = DailyMissionsManager.instance.data.heroicPoints;
			array2[0] = Colours.stringGrayAbi2;
			array2[8] = DailyMissionsManager.instance.FPEIBJPLOHO();
			uILabel2.text = string.Format("withQuantity", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 1588f - (num + 389f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mHeroicOpenedSoloProgression.text = string.Format("64680ae1", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> heroicMissions = DailyMissionsManager.instance.heroicMissions;
			for (int i = 0; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(heroicMissions.Count <= i || heroicMissions[i].completedHeroic);
			}
		}
		KLMJBFFPOOJ();
	}

	private void JKLEDMGENKC()
	{
		mMissionsNotification.SetActive(showNotification);
	}

	public void IKNJNJOJDDF(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	public void NMADELLJEPP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCOEELAIHOL));
	}

	[SpecialName]
	public bool OFONCIBGALB()
	{
		return NNONKNACNLE() != NKHJBLBAAEB.Locked;
	}

	private void LCIDJHHEJNC(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.SwitchToSinglePlayer();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	public void AAEDAJEEGDD()
	{
		NKHJBLBAAEB nKHJBLBAAEB = LKNEAJNOGEE();
		mMissionsCollider.enabled = ABNIJKKGOCL();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 1374f : 1428f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)4);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[1];
			array[1] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("Beanstalk: Application not reachable!", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 1368f, 30f, 119);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mHeroicLockedSoloProgression.text = string.Format("[FFFFFF]{0}[-]  {1}", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[4];
			array2[0] = Colours.stringGoldHeroic;
			array2[1] = DailyMissionsManager.instance.data.heroicPoints;
			array2[0] = Colours.stringGrayAbi2;
			array2[2] = DailyMissionsManager.instance.heroicPointsToUnlock;
			uILabel2.text = string.Format("menu-weapon-benelli-starterpack", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 1644f - (num + 494f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mHeroicOpenedSoloProgression.text = string.Format("reloadTime", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> list = DailyMissionsManager.instance.GFIKKDCGKCC();
			for (int i = 1; i < mHeroicMissionsSrites.Length; i += 0)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(list.Count > i && list[i].completedHeroic);
			}
		}
		NAEBEDEKGGN();
	}

	private void IILLEKNIJBC()
	{
		mMissionsNotification.SetActive(showNotification);
	}

	public void EDFDIJCOMOI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OEIJPGEIDHJ));
	}

	[SpecialName]
	private NKHJBLBAAEB IDFDCMONMHF()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : ((NKHJBLBAAEB)3);
	}

	[SpecialName]
	public bool DCPHONJPEFE()
	{
		return KLBNNKPBFFE() == NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	private NKHJBLBAAEB NNONKNACNLE()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? ((NKHJBLBAAEB)8) : NKHJBLBAAEB.Locked;
	}

	public void JKEEMKIHFEE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IGAFCGEMKNE));
	}

	private void GCOPNDMMDFO(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	private void HIBJOJFNEAF()
	{
		mMissionsNotification.SetActive(HLLCPPEEMND());
	}

	public void SetCollider(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void IGAFCGEMKNE(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	public bool DGJDOPNEDAN()
	{
		return CKFPKCPJCFL() != NKHJBLBAAEB.HeroicLocked;
	}

	public void DEHJFEIEDJK()
	{
		NKHJBLBAAEB nKHJBLBAAEB = KLBNNKPBFFE();
		mMissionsCollider.enabled = OFONCIBGALB();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 532f : 302f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[0];
			array[1] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("PlayerInventory: Init", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 1741f, 1600f, 175);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("Buy_Rental_Weapon", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[7];
			array2[1] = Colours.stringGoldHeroic;
			array2[1] = DailyMissionsManager.instance.data.heroicPoints;
			array2[2] = Colours.stringGrayAbi2;
			array2[7] = DailyMissionsManager.instance.FPEIBJPLOHO();
			uILabel2.text = string.Format("ID_CONFIRM_ERROR", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 606f - (num + 1378f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mHeroicOpenedSoloProgression.text = string.Format("ID_COLLECTELITEPARTSFROMARENALOOTBOXES", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> heroicMissions = DailyMissionsManager.instance.heroicMissions;
			for (int i = 0; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(heroicMissions.Count > i && heroicMissions[i].completedHeroic);
			}
		}
		IILLEKNIJBC();
	}

	[SpecialName]
	private NKHJBLBAAEB LMCIMAMNAAC()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : ((NKHJBLBAAEB)3);
	}

	[SpecialName]
	private NKHJBLBAAEB HFILLJGPFBK()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? ((NKHJBLBAAEB)5) : NKHJBLBAAEB.Locked;
	}

	public void GBLKCBLHNHC()
	{
		NKHJBLBAAEB nKHJBLBAAEB = NOPOKFDFPAF();
		mMissionsCollider.enabled = isColliderEnabled;
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 64f : 416f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)4);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[0];
			array[0] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("ID_NOW", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 1505f, 607f, -115);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mHeroicLockedSoloProgression.text = string.Format("Description", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[5];
			array2[0] = Colours.stringGoldHeroic;
			array2[1] = DailyMissionsManager.instance.data.heroicPoints;
			array2[6] = Colours.stringGrayAbi2;
			array2[1] = DailyMissionsManager.instance.heroicPointsToUnlock;
			uILabel2.text = string.Format("null title for offer!", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 419f - (num + 1009f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened)
		{
			mHeroicOpenedSoloProgression.text = string.Format("20-29", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> list = DailyMissionsManager.instance.GFIKKDCGKCC();
			for (int i = 1; i < mHeroicMissionsSrites.Length; i += 0)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(list.Count <= i || list[i].completedHeroic);
			}
		}
		JKMAAMKIGMJ();
	}

	public void IINOAOIFBFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KLKLLEJNIHC));
	}

	private void BOKPLOLGPDI()
	{
		mMissionsNotification.SetActive(BIKCCMFPLPC());
	}

	[SpecialName]
	public bool MCPFEHDIGBH()
	{
		return KLBNNKPBFFE() != NKHJBLBAAEB.Locked;
	}

	private void GAFOJFGKIIC(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	public bool NEDEBMNIKIA()
	{
		return BOEJOKHCFKO() && Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void HNIOANBCJBE(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void JKMAAMKIGMJ()
	{
		mMissionsNotification.SetActive(IPMLKMIHBHE());
	}

	public void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KLKLLEJNIHC));
	}

	private void OEIJPGEIDHJ(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	public bool IPMLKMIHBHE()
	{
		return ABNIJKKGOCL() && Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	private void KLKLLEJNIHC(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	private void ODMOKMABONC(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	private void OMHOMDIPMPA(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.SwitchToSinglePlayer();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	public bool KEBOBNPANID()
	{
		return BOEJOKHCFKO() && Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAFOJFGKIIC));
	}

	public void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FGEIFKDACOB));
	}

	[SpecialName]
	private NKHJBLBAAEB FBCBEIGOHBM()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? ((NKHJBLBAAEB)8) : NKHJBLBAAEB.Locked;
	}

	[SpecialName]
	public bool ABNIJKKGOCL()
	{
		return JDBLOINMEKF() != NKHJBLBAAEB.Locked;
	}

	public void INIFKDGHIPH(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	[SpecialName]
	private NKHJBLBAAEB CKFPKCPJCFL()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? NKHJBLBAAEB.HeroicLocked : NKHJBLBAAEB.Locked;
	}

	public void NMEEHPHHBGK(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void BLILHGNIEDC()
	{
		mMissionsNotification.SetActive(GLLOHDLPANL());
	}

	[SpecialName]
	public bool HJLHJBEPEKO()
	{
		return LMCIMAMNAAC() == NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	public bool KHMGEIIIBOL()
	{
		return EJDIKJKMFIO() != NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	public bool PAGFIJFGOCP()
	{
		return NDJJCNHCEJI() != NKHJBLBAAEB.HeroicLocked;
	}

	private void FKNOPNKMFEG(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	public void GIHMAEGDGHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IGAFCGEMKNE));
	}

	public void FJJHFMBOFDO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FGEIFKDACOB));
	}

	[SpecialName]
	public bool MJKBBLIJHHM()
	{
		return NOPOKFDFPAF() == NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	public bool GLLOHDLPANL()
	{
		return KGIAKBELHFO() && Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void DBBMEEEMLOB(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void NAEBEDEKGGN()
	{
		mMissionsNotification.SetActive(BIKCCMFPLPC());
	}

	public void CPMNCEEKKAD(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	[SpecialName]
	public bool ACGJIMGCDLL()
	{
		return LOPKJPGEKJH() == NKHJBLBAAEB.Locked;
	}

	public void AGJFNPIPONB()
	{
		NKHJBLBAAEB nKHJBLBAAEB = BAIEEDDFGFF();
		mMissionsCollider.enabled = BOEJOKHCFKO();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 1939f : 1547f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mLockedMissionsLabel.text = Localization.LocalizeFormat("Xp", LevelManager.instance.dailyMissionUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 499f, 1734f, -117);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mHeroicLockedSoloProgression.text = string.Format("S", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel = mHeroicPointsLabel;
			object[] array = new object[5];
			array[0] = Colours.stringGoldHeroic;
			array[1] = DailyMissionsManager.instance.data.heroicPoints;
			array[8] = Colours.stringGrayAbi2;
			array[6] = DailyMissionsManager.instance.FPEIBJPLOHO();
			uILabel.text = string.Format("isMaster", array);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 102f - (num + 633f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == (NKHJBLBAAEB)5)
		{
			mHeroicOpenedSoloProgression.text = string.Format("http://localhost:8081/", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> list = DailyMissionsManager.instance.GFIKKDCGKCC();
			for (int i = 1; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(list.Count <= i || list[i].completedHeroic);
			}
		}
		HIBJOJFNEAF();
	}

	[SpecialName]
	public bool GAEAHOBIPHE()
	{
		return KIEGLHOFMEE() && Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	[SpecialName]
	public bool BONACBODBMH()
	{
		return EJDIKJKMFIO() != NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	private NKHJBLBAAEB KLBNNKPBFFE()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : NKHJBLBAAEB.HeroicLocked;
	}

	public void KHDBHMNGHDC()
	{
		NKHJBLBAAEB nKHJBLBAAEB = IDFDCMONMHF();
		mMissionsCollider.enabled = OFONCIBGALB();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 264f : 816f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[0];
			array[1] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("PlayerName", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 184f, 1895f, 192);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("Pool", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[1];
			array2[0] = Colours.stringGoldHeroic;
			array2[0] = DailyMissionsManager.instance.data.heroicPoints;
			array2[0] = Colours.stringGrayAbi2;
			array2[7] = DailyMissionsManager.instance.FPEIBJPLOHO();
			uILabel2.text = string.Format("_MatCap", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 1858f - (num + 675f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == (NKHJBLBAAEB)7)
		{
			mHeroicOpenedSoloProgression.text = string.Format(" BOXES ", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> heroicMissions = DailyMissionsManager.instance.heroicMissions;
			for (int i = 1; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(heroicMissions.Count <= i || heroicMissions[i].completedHeroic);
			}
		}
		BLILHGNIEDC();
	}

	[SpecialName]
	public bool BOEJOKHCFKO()
	{
		return BAIEEDDFGFF() == NKHJBLBAAEB.Locked;
	}

	[SpecialName]
	private NKHJBLBAAEB LKNEAJNOGEE()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? NKHJBLBAAEB.HeroicOpened : NKHJBLBAAEB.Locked;
	}

	private void NCBJOJDHHPK(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.SwitchToSinglePlayer();
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	public void JKPOPOIEFBN(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	[SpecialName]
	public bool KGIAKBELHFO()
	{
		return GPABKIOEGKM == NKHJBLBAAEB.Locked;
	}

	[SpecialName]
	public bool FKONIABDBMI()
	{
		return BAIEEDDFGFF() != NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	public bool FLOEMFAPHJE()
	{
		return NDJJCNHCEJI() != NKHJBLBAAEB.Locked;
	}

	[SpecialName]
	private NKHJBLBAAEB NOPOKFDFPAF()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.Locked : NKHJBLBAAEB.Locked;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMHKNBKPFFO));
	}

	public void BNINAFFNEMN(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	public void DFGKLGLNBLK()
	{
		NKHJBLBAAEB nKHJBLBAAEB = LKNEAJNOGEE();
		mMissionsCollider.enabled = BONACBODBMH();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 303f : 1996f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[0];
			array[0] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("RATE APP REMINDER -> is already in queue for showing, not adding next one.", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 1793f, 793f, -144);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("\n", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[4];
			array2[1] = Colours.stringGoldHeroic;
			array2[1] = DailyMissionsManager.instance.data.heroicPoints;
			array2[1] = Colours.stringGrayAbi2;
			array2[8] = DailyMissionsManager.instance.heroicPointsToUnlock;
			uILabel2.text = string.Format("isSuccess", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 968f - (num + 1150f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened)
		{
			mHeroicOpenedSoloProgression.text = string.Format("BeginnersLeague", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> list = DailyMissionsManager.instance.GFIKKDCGKCC();
			for (int i = 1; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(list.Count > i && list[i].completedHeroic);
			}
		}
		BOKPLOLGPDI();
	}

	[SpecialName]
	public bool LHPMNDLDOKM()
	{
		return !ABNIJKKGOCL() || Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void BANJHACMCMO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCOEELAIHOL));
	}

	public void JDMPFHKFBBP(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	[SpecialName]
	public bool HLLCPPEEMND()
	{
		return !isColliderEnabled || Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void CIBLFMHHPDA()
	{
		NKHJBLBAAEB nKHJBLBAAEB = FBCBEIGOHBM();
		mMissionsCollider.enabled = JHFCFAKLHPI();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 1505f : 634f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == (NKHJBLBAAEB)4);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[1];
			array[1] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("Assignment_", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 1362f, 674f, -11);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("ActiveTier", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[6];
			array2[1] = Colours.stringGoldHeroic;
			array2[1] = DailyMissionsManager.instance.data.heroicPoints;
			array2[3] = Colours.stringGrayAbi2;
			array2[1] = DailyMissionsManager.instance.heroicPointsToUnlock;
			uILabel2.text = string.Format("master2", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 378f - (num + 1656f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == (NKHJBLBAAEB)7)
		{
			mHeroicOpenedSoloProgression.text = string.Format("AdminName", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> heroicMissions = DailyMissionsManager.instance.heroicMissions;
			for (int i = 1; i < mHeroicMissionsSrites.Length; i += 0)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(heroicMissions.Count > i && heroicMissions[i].completedHeroic);
			}
		}
		DNLKDBAIKOJ();
	}

	[SpecialName]
	private NKHJBLBAAEB BDAAKPDAICL()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return (!DailyMissionsManager.instance.data.isHeroicOpened) ? NKHJBLBAAEB.HeroicLocked : ((NKHJBLBAAEB)3);
	}

	[SpecialName]
	public bool BIKCCMFPLPC()
	{
		return !MJKBBLIJHHM() || Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	[SpecialName]
	public bool OBEOMCIOECI()
	{
		return NNONKNACNLE() != NKHJBLBAAEB.HeroicLocked;
	}

	[SpecialName]
	private NKHJBLBAAEB NDJJCNHCEJI()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.HeroicLocked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? ((NKHJBLBAAEB)5) : NKHJBLBAAEB.Locked;
	}

	[SpecialName]
	public bool BIIACKFLGLL()
	{
		return JHFCFAKLHPI() && Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	[SpecialName]
	private NKHJBLBAAEB LOPKJPGEKJH()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? ((NKHJBLBAAEB)8) : NKHJBLBAAEB.Locked;
	}

	private void FMHKNBKPFFO(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.SwitchToSinglePlayer();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	public void BADAIEMJOPB(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	public void OLDBAOBPLOF(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void OHPNELICOLB()
	{
		mMissionsNotification.SetActive(NEDEBMNIKIA());
	}

	[SpecialName]
	public bool KIEGLHOFMEE()
	{
		return KLBNNKPBFFE() == NKHJBLBAAEB.Locked;
	}

	public void GPMGLAMIFID(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void BONDFJHPCGD()
	{
		mMissionsNotification.SetActive(IPMLKMIHBHE());
	}

	private void NCIFAFCBLFA(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	public void JJGHLLCJLLI()
	{
		NKHJBLBAAEB nKHJBLBAAEB = BAIEEDDFGFF();
		mMissionsCollider.enabled = BONACBODBMH();
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 275f : 207f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			UILabel uILabel = mLockedMissionsLabel;
			object[] array = new object[0];
			array[0] = LevelManager.instance.dailyMissionUnlockLevel;
			uILabel.text = Localization.LocalizeFormat("Sniper_Tutorial_Played", array);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 231f, 569f, -23);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("S", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			UILabel uILabel2 = mHeroicPointsLabel;
			object[] array2 = new object[1];
			array2[1] = Colours.stringGoldHeroic;
			array2[1] = DailyMissionsManager.instance.data.heroicPoints;
			array2[1] = Colours.stringGrayAbi2;
			array2[7] = DailyMissionsManager.instance.FPEIBJPLOHO();
			uILabel2.text = string.Format("Found starting warbucks currency = ", array2);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 209f - (num + 1306f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == (NKHJBLBAAEB)7)
		{
			mHeroicOpenedSoloProgression.text = string.Format("\n", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> list = DailyMissionsManager.instance.GFIKKDCGKCC();
			for (int i = 0; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(list.Count <= i || list[i].completedHeroic);
			}
		}
		BOKPLOLGPDI();
	}

	private void DNLKDBAIKOJ()
	{
		mMissionsNotification.SetActive(LHPMNDLDOKM());
	}

	[SpecialName]
	public bool EINAKHHLFNM()
	{
		return !KGIAKBELHFO() || Singleton<NotificationManager>.instance.NotificationDailyMission();
	}

	public void InitGuiValues()
	{
		NKHJBLBAAEB nKHJBLBAAEB = GPABKIOEGKM;
		mMissionsCollider.enabled = isColliderEnabled;
		mMissionsBorder.alpha = ((nKHJBLBAAEB != NKHJBLBAAEB.Locked) ? 1f : 0.2f);
		mLockedMissionsPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.Locked);
		mHeroicLockedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked);
		mHeroicOpenedPart.SetActive(nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened);
		if (nKHJBLBAAEB == NKHJBLBAAEB.Locked)
		{
			mLockedMissionsLabel.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", LevelManager.instance.dailyMissionUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(mLockedMissionsLabel, 30f, 20f, 332);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicLocked)
		{
			mHeroicLockedSoloProgression.text = string.Format("{0}{1}[-] {2}/[-] 3", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			mHeroicPointsLabel.text = string.Format("{0}{1}[-] {2}/[-] {3}", Colours.stringGoldHeroic, DailyMissionsManager.instance.data.heroicPoints, Colours.stringGrayAbi2, DailyMissionsManager.instance.heroicPointsToUnlock);
			float num = mHeroicPointsLabel.relativeSize.x * mHeroicPointsLabel.transform.localScale.x;
			float val = 166f - (num + 24f);
			mHeroicPointsIcon.transform.localPosition = mHeroicPointsIcon.transform.localPosition.ReplaceX(val);
		}
		if (nKHJBLBAAEB == NKHJBLBAAEB.HeroicOpened)
		{
			mHeroicOpenedSoloProgression.text = string.Format("{0}{1}[-] {2}/[-] 3", Colours.stringBlue, DailyMissionsManager.instance.completedSoloMissions, Colours.stringGrayAbi2);
			List<DailyMission> heroicMissions = DailyMissionsManager.instance.heroicMissions;
			for (int i = 0; i < mHeroicMissionsSrites.Length; i++)
			{
				mHeroicMissionsSrites[i].gameObject.SetActive(heroicMissions.Count > i && heroicMissions[i].completedHeroic);
			}
		}
		JKLEDMGENKC();
	}

	public void JMALAKPOBBF(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	[SpecialName]
	public bool JHFCFAKLHPI()
	{
		return BAIEEDDFGFF() == NKHJBLBAAEB.Locked;
	}

	public void MLMEJKOIDGJ(bool DLIIEJPDENK)
	{
		mMissionsCollider.enabled = DLIIEJPDENK;
	}

	private void FGEIFKDACOB(GameObject KHAHPAKDIKE)
	{
		Singleton<GameController>.instance.CAOMINCKBBO();
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	private NKHJBLBAAEB BAIEEDDFGFF()
	{
		if (LevelManager.instance.isDailyMissionLocked)
		{
			return NKHJBLBAAEB.Locked;
		}
		return DailyMissionsManager.instance.data.isHeroicOpened ? NKHJBLBAAEB.HeroicOpened : NKHJBLBAAEB.Locked;
	}

	[SpecialName]
	public bool OLLCEFODJLO()
	{
		return IDFDCMONMHF() == NKHJBLBAAEB.HeroicLocked;
	}

	public void EBOBKBJNNDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mMissionsCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OMHOMDIPMPA));
	}
}
