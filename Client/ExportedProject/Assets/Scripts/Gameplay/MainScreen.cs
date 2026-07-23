using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class MainScreen : GuiScreenSingle<MainScreen>
{
	[Header("Left")]
	[FormerlySerializedAs("DKNFGIGDGLM")]
	public LeftGoldenSuitcase MNJLIJGDDPM;

	[FormerlySerializedAs("LCFFGADAPLB")]
	public GameObject JFCNBCDIEBL;

	[FormerlySerializedAs("PLCNNIAHHAF")]
	public GameObject GALEKBNIHHD;

	[FormerlySerializedAs("JGAKDPOPHGP")]
	public IntroductionDeals HIPDGKKHODB;

	[Header("Top")]
	[FormerlySerializedAs("DNHHBAFLNCE")]
	public MainScreenAssignments DHNNCMHLOEM;

	[FormerlySerializedAs("KCBGOPMLCHL")]
	[Header("Center")]
	public MainScreenBlackMarketOffer IFEEGCIBFII;

	[Header("Right")]
	[FormerlySerializedAs("ODCFGJKDEDN")]
	public MainScreenSocial HKDNDFJANDG;

	[FormerlySerializedAs("KNEILFKLNDG")]
	public GameObject IKHHOCDLIAA;

	[FormerlySerializedAs("KKAJOKKMFBH")]
	public UILabel OAPBGKMPAFB;

	[FormerlySerializedAs("OKEIFKGLBMM")]
	public VideoFeedButton HGBBAABGMLG;

	[FormerlySerializedAs("GIOBECHOAAE")]
	[Header("Bottom Left")]
	public IntroductionSquadButton KDABKEGLDEE;

	[FormerlySerializedAs("IGNCDDNCGLH")]
	[Header("Bottom")]
	public MainScreenLeaguePlayers BEPFJDAJBJO;

	[FormerlySerializedAs("IBAPPBBFNNG")]
	[Header("Bottom Right")]
	public UIButton AMHDJLIKNBH;

	[FormerlySerializedAs("CACPJJLPNJJ")]
	public GameObject OOKJABHGPOM;

	[FormerlySerializedAs("GGAKEFHMBIM")]
	public UILabel KJDGCMJGNAK;

	[FormerlySerializedAs("CENOGHHGCAP")]
	public GameObject IJPJDKALPDP;

	[FormerlySerializedAs("HIMFMPMAAOC")]
	public GameObject OMDKNOFNFBB;

	private bool FFILANCOOKD;

	// The recovered local runtime has no supported social-provider or real-money store backend.
	// Keep those panels out of the Main screen instead of showing incomplete overlapping offers.
	private void ApplyRecoveredFeatureVisibility()
	{
		Transform[] childTransforms = GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform childTransform in childTransforms)
		{
			if (childTransform != null && childTransform != transform && childTransform.name == "Transition Button")
			{
				childTransform.gameObject.SetActive(value: false);
			}
		}
		UITexture[] componentsInChildren = GetComponentsInChildren<UITexture>(includeInactive: true);
		foreach (UITexture uITexture in componentsInChildren)
		{
			if (uITexture != null && uITexture.gameObject.name.IndexOf("Glow", StringComparison.OrdinalIgnoreCase) >= 0 && (uITexture.mainTexture == null || uITexture.mainTexture.name == "whiteRectangle"))
			{
				uITexture.gameObject.SetActive(value: false);
			}
		}
		if (HIPDGKKHODB != null)
		{
			HIPDGKKHODB.gameObject.SetActive(value: false);
		}
		if (HKDNDFJANDG != null)
		{
			HKDNDFJANDG.gameObject.SetActive(value: false);
		}
		if (IKHHOCDLIAA != null)
		{
			IKHHOCDLIAA.SetActive(value: false);
		}
		if (HGBBAABGMLG != null)
		{
			HGBBAABGMLG.gameObject.SetActive(value: false);
		}
	}

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> LGJCBPOPCPA;

	public virtual void KOJLOBAIPFP()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		MNJLIJGDDPM.HBGBFKJBLBO();
		HIPDGKKHODB.NNGDAMJFDBG();
		HKDNDFJANDG.HAOFBOPJBEI();
		KDABKEGLDEE.FFOEIHKGGPL();
		BEPFJDAJBJO.LANJLCBMFHJ();
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		CEMOIHDAEIE();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		BEPFJDAJBJO.DoAfterHide();
		MNJLIJGDDPM.DoAfterHide();
		IFEEGCIBFII.DoAfterHide();
		KDABKEGLDEE.DoAfterHide();
		HGBBAABGMLG.DoAfterHide();
	}

	protected virtual void KNOKOJKOCEB()
	{
		MNJLIJGDDPM.BMMNJICILHJ();
		HIPDGKKHODB.InitControls();
		DHNNCMHLOEM.InitControls();
		HKDNDFJANDG.CEOBPADJPIA();
		IFEEGCIBFII.KHGEHFNELDI();
		KDABKEGLDEE.LHDAGAGDKOM();
		BEPFJDAJBJO.InitControls();
		HGBBAABGMLG.PLAKLPJEAHM();
		UIEventListener uIEventListener = UIEventListener.Get(AMHDJLIKNBH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KLGBJJGCDAG));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNBCDIEBL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JFEBFMNJLBJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IKHHOCDLIAA);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DKOGFLOOJCN));
		Singleton<GooglePlayGameService>.instance.IPKHNKGMDML(IHGGHGKHJII);
		Singleton<GooglePlayGameService>.instance.FDAHLOLGLKM(delegate
		{
			CEMOIHDAEIE();
		});
		Singleton<GooglePlayGameService>.instance.AGOKFLJLDMP(delegate
		{
			CEMOIHDAEIE();
		});
		Singleton<NotificationManager>.instance.UnitDelivered += KAKGALGJJAC;
		Singleton<NotificationManager>.instance.WeaponDelivered += KAKGALGJJAC;
	}

	private void PHGFBJFFFPH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void AILKEIFIGKN()
	{
		CEMOIHDAEIE();
	}

	public void OnApplicationFocus()
	{
		CEMOIHDAEIE();
	}

	protected virtual void FHINGMFHKLG()
	{
		MNJLIJGDDPM.InitControls();
		HIPDGKKHODB.OILPJONILBG();
		DHNNCMHLOEM.AFMPBPGLFMJ();
		HKDNDFJANDG.CBOBIADFILJ();
		IFEEGCIBFII.MNHAOCEONAK();
		KDABKEGLDEE.InitControls();
		BEPFJDAJBJO.KFLBEIPPMBF();
		HGBBAABGMLG.PLAOCDOMCPP();
		UIEventListener uIEventListener = UIEventListener.Get(AMHDJLIKNBH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PGGPCAACBOI));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNBCDIEBL);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JFEBFMNJLBJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(IKHHOCDLIAA);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DKOGFLOOJCN));
		Singleton<GooglePlayGameService>.instance.KLLEOBDKNDJ(OnGooglePlayGameServiceLoggedIn);
		Singleton<GooglePlayGameService>.instance.ANGOCHJEFMK(delegate
		{
			CEMOIHDAEIE();
		});
		Singleton<GooglePlayGameService>.instance.AGOKFLJLDMP(delegate
		{
			CEMOIHDAEIE();
		});
		Singleton<NotificationManager>.instance.UnitDelivered += KAKGALGJJAC;
		Singleton<NotificationManager>.instance.WeaponDelivered += KAKGALGJJAC;
	}

	public void IHGGHGKHJII(bool NOCIMJBMOCB)
	{
		CEMOIHDAEIE();
		if (FFILANCOOKD)
		{
			FFILANCOOKD = false;
			if (NOCIMJBMOCB)
			{
				Singleton<GooglePlayGameService>.instance.OEDCJJPNCIK();
			}
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		ApplyRecoveredFeatureVisibility();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		MNJLIJGDDPM.InitEvents();
		KDABKEGLDEE.InitEvents();
		BEPFJDAJBJO.InitEvents();
	}

	public virtual void MINDPCICJEH()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += JCCHNLDPPCH;
		MNJLIJGDDPM.HBGBFKJBLBO();
		HIPDGKKHODB.PLDAPLOGJPA();
		HKDNDFJANDG.LGHOOJOAKFI();
		KDABKEGLDEE.FFOEIHKGGPL();
		BEPFJDAJBJO.LANJLCBMFHJ();
	}

	protected override void AGIKPOLCGNF()
	{
		ApplyRecoveredFeatureVisibility();
		MNJLIJGDDPM.InitControls();
		DHNNCMHLOEM.InitControls();
		IFEEGCIBFII.InitControls();
		KDABKEGLDEE.InitControls();
		BEPFJDAJBJO.InitControls();
		HGBBAABGMLG.InitControls();
		UIEventListener uIEventListener = UIEventListener.Get(AMHDJLIKNBH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PGGPCAACBOI));
		if (JFCNBCDIEBL != null && JFCNBCDIEBL.activeSelf)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(JFCNBCDIEBL);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JFEBFMNJLBJ));
		}
		Singleton<NotificationManager>.instance.UnitDelivered += KAKGALGJJAC;
		Singleton<NotificationManager>.instance.WeaponDelivered += KAKGALGJJAC;
	}

	private void KLGBJJGCDAG(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void JCCHNLDPPCH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void KAKGALGJJAC()
	{
		if (isShowed)
		{
			JFDLOOFBBEF();
		}
	}

	public virtual void OCPGBJFIIDG()
	{
		base.DoBeforeHide();
		HIPDGKKHODB.NFNDGHPDMDN();
	}

	private void CEMOIHDAEIE()
	{
		bool isGooglePlayConnected = GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		OAPBGKMPAFB.text = Localization.Localize((!isGooglePlayConnected) ? "ID_CONNECTTOGOOGLEPLAY" : "ID_GOOGLEPLAYACHIEVEMENTS");
	}

	public override void InitGUIValues()
	{
		ApplyRecoveredFeatureVisibility();
		MNJLIJGDDPM.InitGuiValues();
		BODKDINCDJD();
		DHNNCMHLOEM.InitGuiValues();
		IFEEGCIBFII.InitGuiValues();
		KDABKEGLDEE.InitGuiValues();
		BEPFJDAJBJO.InitGuiValues();
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			JFDLOOFBBEF();
		}
		FFILANCOOKD = false;
	}

	private void JFDLOOFBBEF()
	{
		int numberOfMenuNotifications = Singleton<NotificationManager>.instance.GetNumberOfMenuNotifications();
		KJDGCMJGNAK.text = MEJMLNDFDBP.GMIPFLIEOHD(numberOfMenuNotifications);
		OOKJABHGPOM.SetActive(numberOfMenuNotifications > 0);
	}

	public override void OnBack()
	{
		ConfirmDialog.IGCMBKLNIDB(Localization.Localize("ID_CONFIRM_EXIT"), Localization.Localize("ID_CONFIRM_EXITWARFRIENDS"), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Application.Quit();
			}
		}, Localization.Localize("ID_YES"), Localization.Localize("ID_NO"));
	}

	private void BLEBNIHAAHK(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<DailyRewardMonthScreen>.instance.KKHPKKGGMPO = false;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyRewardMonthScreen>.instance);
	}

	private void DKOGFLOOJCN(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			Singleton<GooglePlayGameService>.instance.HGFEPLBIKDF();
		}
		else if (GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected)
		{
			FFILANCOOKD = true;
			GameLoginManager.instance.LoginToGoogle();
		}
		else
		{
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		ApplyRecoveredFeatureVisibility();
		base.AnimateShow(JODEPBNLLAO);
		BEPFJDAJBJO.AnimateShow();
	}

	public virtual void MGBLKIEGMBG()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(JCCHNLDPPCH);
		MNJLIJGDDPM.HBGBFKJBLBO();
		HIPDGKKHODB.PLDAPLOGJPA();
		HKDNDFJANDG.PBKJDKFPILH();
		KDABKEGLDEE.FFOEIHKGGPL();
		BEPFJDAJBJO.KNBGAHKNBNN();
	}

	private void BODKDINCDJD()
	{
		if (UnityEngine.Object.FindObjectOfType<DailyRewardMonthScreen>() == null)
		{
			if (JFCNBCDIEBL != null)
			{
				JFCNBCDIEBL.SetActive(value: false);
			}
			return;
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			JFCNBCDIEBL.SetActive(value: false);
		}
		else if (LevelManager.instance.isDailyRewardsLocked)
		{
			JFCNBCDIEBL.SetActive(value: false);
		}
		else if (Singleton<DailyRewardManager>.instance.LNAIDLKGCFN == null)
		{
			JFCNBCDIEBL.SetActive(value: false);
			Singleton<BeanstalkServerManager>.instance.checkDaylyRewards();
		}
		else
		{
			JFCNBCDIEBL.SetActive(value: true);
			GALEKBNIHHD.SetActive(Singleton<DailyRewardManager>.instance.LNAIDLKGCFN.LFGNIDNMDMA);
		}
	}

	public void OnGooglePlayGameServiceLoggedIn(bool NOCIMJBMOCB)
	{
		CEMOIHDAEIE();
		if (FFILANCOOKD)
		{
			FFILANCOOKD = false;
			if (NOCIMJBMOCB)
			{
				Singleton<GooglePlayGameService>.instance.ShowAchievementsUI();
			}
		}
	}

	private void PGGPCAACBOI(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.CheckDailyReward:
		case DatabaseAction.ClaimDailyReward:
			if (Singleton<DailyRewardManager>.instance.LNAIDLKGCFN != null)
			{
				BODKDINCDJD();
			}
			break;
		case DatabaseAction.LoginToCustomAccount:
		case DatabaseAction.AddFacebook:
		case DatabaseAction.CreateGcAccount:
		case DatabaseAction.RemoveFacebook:
		case DatabaseAction.AddGooglePlay:
		case DatabaseAction.RemoveGooglePlay:
			BODKDINCDJD();
			CEMOIHDAEIE();
			break;
		}
	}

	[CompilerGenerated]
	private static void LFDNBFDFFME(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Application.Quit();
		}
	}

	public void CNOGHKMMPAB()
	{
		CEMOIHDAEIE();
	}

	private void JFEBFMNJLBJ(GameObject KHAHPAKDIKE)
	{
		DailyRewardMonthScreen dailyRewardMonthScreen = UnityEngine.Object.FindObjectOfType<DailyRewardMonthScreen>();
		if (dailyRewardMonthScreen != null)
		{
			dailyRewardMonthScreen.KKHPKKGGMPO = false;
			Singleton<GuiManager>.instance.ShowGui(dailyRewardMonthScreen);
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(bool NOCIMJBMOCB)
	{
		CEMOIHDAEIE();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			Singleton<GooglePlayGameService>.instance.ShowAchievementsUI();
		}
		else if (GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected)
		{
			FFILANCOOKD = true;
			GameLoginManager.instance.LoginToGoogle();
		}
		else
		{
			GameLoginManager.instance.LoginToGoogle();
		}
	}
}
