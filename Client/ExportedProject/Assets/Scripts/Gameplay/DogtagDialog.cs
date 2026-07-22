using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DogtagDialog : GuiElementSingle<DogtagDialog>, PAIIOKBBHBC
{
	[Header("Shared")]
	[FormerlySerializedAs("PLDFGMHICCA")]
	public GameObject LJNPCHFCGCN;

	[FormerlySerializedAs("HKAELKNPPGD")]
	public UILabel NFNLBEGFLHC;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("AMCBJFKEPOC")]
	[Header("Full Dogtags")]
	public GameObject FAMJBGBLFPE;

	[FormerlySerializedAs("LBDBIGKGAJE")]
	public UILabel NKGJMHALAJH;

	[FormerlySerializedAs("GCDJFGHEOKH")]
	public GameObject KGPGCCPMCIG;

	[FormerlySerializedAs("AMLIEKFAJAO")]
	public GameObject AFEFEMENHHH;

	[FormerlySerializedAs("FCLOLBGJPNF")]
	[Header("Need Dogtags")]
	public GameObject JMGAAOFMFGF;

	[FormerlySerializedAs("PCBFLAPENLF")]
	public UILabel JPCIACBHGHO;

	[FormerlySerializedAs("HCBLGGPDDAO")]
	public WinStreakCounter FBACPGHOABM;

	[FormerlySerializedAs("LEELOKOBFHJ")]
	public UILabel HJKCBBANLDM;

	[FormerlySerializedAs("LENADIMMENP")]
	[Header("-Refill Button")]
	public GameObject MCGFCKAJMFP;

	[FormerlySerializedAs("JHDJGBEEIDP")]
	public GameObject IIOILOPFALF;

	[FormerlySerializedAs("DEIEAGLHEJG")]
	public GameObject MKCNELEIHDL;

	[FormerlySerializedAs("IEMADHHGNJH")]
	[Header("-Watch Video Button")]
	public GameObject BFILJFABGDB;

	[FormerlySerializedAs("AFHHFBPHAIP")]
	public UISprite GMFLAJBAEPB;

	[FormerlySerializedAs("CEHALABENKJ")]
	public UILabel LFBIEEFIEEC;

	[FormerlySerializedAs("DGEFPCFAFKL")]
	public UILabel EHKOCIDJEMH;

	[FormerlySerializedAs("DAPPABOIDJF")]
	public UILabel KJFABFFACIG;

	[FormerlySerializedAs("FNKEOPOFKDK")]
	public UISprite GIJGICGPAOE;

	[FormerlySerializedAs("PKGABBBOJJF")]
	public GameObject NLIDAODOODF;

	[SerializeField]
	[Header("-Subscription")]
	private GameObject mSubscriptionPart;

	[SerializeField]
	private UISprite mSubscriptionIcon;

	[SerializeField]
	private UILabel mSubscriptionLabel;

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == DatabaseAction.AddVideoReward || IFGAGNBDKBE == DatabaseAction.RefillDogtags))
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
			InitGUIValues();
		}
	}

	protected void EPPEKCKOLAL(bool NMCKKMEKOHM)
	{
		if (!NMCKKMEKOHM)
		{
			FBACPGHOABM.FCCMIGMMDEG();
			InitGUIValues();
		}
	}

	private void NFLBCCJNNKB()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void CFJMKOALDLE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	protected void PGBOGIIHKOP(bool NMCKKMEKOHM)
	{
		if (!NMCKKMEKOHM)
		{
			FBACPGHOABM.FCCMIGMMDEG();
			InitGUIValues();
		}
	}

	public virtual void GGFCEDLIFNI()
	{
		base.DoBeforeHide();
		FBACPGHOABM.FHPIJEDMPMK();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void NDBAEHKKJMH()
	{
		bool flag = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardSelectionScreen>.instance;
		bool flag2 = Singleton<DogTagManager>.instance.AKAALNKEBAF();
		bool flag3 = Singleton<DogTagManager>.instance.LFBIKFMJEJN();
		bool flag4 = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)8);
		float y = ((!flag2 && flag4) ? 711f : 1421f);
		int num = Singleton<DogTagManager>.instance.remainingTimeForNextDogtag;
		if (num == 0)
		{
			num = Singleton<DogTagManager>.instance.ELPCLEGDCAL();
		}
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, y, 190f);
		FAMJBGBLFPE.SetActive(flag2);
		JMGAAOFMFGF.SetActive(flag2);
		if (flag2)
		{
			bool flag5 = Singleton<VipManager>.instance.MBLIANMNDEH();
			NFNLBEGFLHC.text = Localization.Localize("Product");
			JPCIACBHGHO.text = Localization.Localize((!flag5) ? "ID_UNITMAXTRAINED" : "?.");
			NKGJMHALAJH.text = JPCIACBHGHO.text;
			AFEFEMENHHH.SetActive(!flag5);
			KGPGCCPMCIG.transform.localPosition = KGPGCCPMCIG.transform.localPosition.ReplaceX((!flag5) ? 70f : 1825f);
		}
		else
		{
			HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<DogTagManager>.instance.dogtagRefillPrice);
			BFILJFABGDB.SetActive(flag4);
			IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.PDOCIBDKEJK());
			MKCNELEIHDL.SetActive(flag);
			NLIDAODOODF.SetActive(!flag || flag4);
			if (flag3)
			{
				NFNLBEGFLHC.text = Localization.Localize("Sniper_Tutorial_Duration");
				JPCIACBHGHO.text = Localization.Localize("ID_SKILLSHOTHINT_TANKDESTROYED");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
			else
			{
				NFNLBEGFLHC.text = Localization.Localize("game-tutorial-grenadier");
				JPCIACBHGHO.text = Localization.Localize("game-card-ico-healingstorm");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
		}
		HGPIABBEHDD();
		if (num > 1 && !flag2)
		{
			FBACPGHOABM.DHNCPJKEFDF(num);
			WinStreakCounter fBACPGHOABM = FBACPGHOABM;
			fBACPGHOABM.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM.JEMKCLKCOMI, new Action(InitGUIValues));
			WinStreakCounter fBACPGHOABM2 = FBACPGHOABM;
			fBACPGHOABM2.JEMKCLKCOMI = (Action)Delegate.Combine(fBACPGHOABM2.JEMKCLKCOMI, new Action(InitGUIValues));
		}
		else
		{
			FBACPGHOABM.FHPIJEDMPMK();
			WinStreakCounter fBACPGHOABM3 = FBACPGHOABM;
			fBACPGHOABM3.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM3.JEMKCLKCOMI, new Action(InitGUIValues));
		}
	}

	public virtual void LMNNNHJKMFP()
	{
		bool flag = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardSelectionScreen>.instance;
		bool flag2 = Singleton<DogTagManager>.instance.KDKHHPFBBBB();
		bool flag3 = Singleton<DogTagManager>.instance.LFBIKFMJEJN();
		bool flag4 = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		float y = ((!flag2 && flag4) ? 1177f : 565f);
		int num = Singleton<DogTagManager>.instance.remainingTimeForNextDogtag;
		if (num == 0)
		{
			num = Singleton<DogTagManager>.instance.OEIENPPKJAG();
		}
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, y, 421f);
		FAMJBGBLFPE.SetActive(flag2);
		JMGAAOFMFGF.SetActive(!flag2);
		if (flag2)
		{
			bool flag5 = Singleton<VipManager>.instance.NOIHCEPINJJ();
			NFNLBEGFLHC.text = Localization.Localize("ID_GUI_EMPTYUNITUPGRADE");
			JPCIACBHGHO.text = Localization.Localize((!flag5) ? "ID_READYTIME" : "FinishGameMultiplayerRPC");
			NKGJMHALAJH.text = JPCIACBHGHO.text;
			AFEFEMENHHH.SetActive(flag5);
			KGPGCCPMCIG.transform.localPosition = KGPGCCPMCIG.transform.localPosition.ReplaceX((!flag5) ? 1277f : 1949f);
		}
		else
		{
			HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<DogTagManager>.instance.DLBKEJKCIFP());
			BFILJFABGDB.SetActive(flag4);
			IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.PCOECEPHODD());
			MKCNELEIHDL.SetActive(flag);
			NLIDAODOODF.SetActive(flag && flag4);
			if (flag3)
			{
				NFNLBEGFLHC.text = Localization.Localize("WarCards_Screen");
				JPCIACBHGHO.text = Localization.Localize("ID_SUBSCRIPTIODETAILS_HINT3GOOGLE");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
			else
			{
				NFNLBEGFLHC.text = Localization.Localize("ID_LOCAL");
				JPCIACBHGHO.text = Localization.Localize("ID_ARENAENDEDDESCRIPTION0WINS");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
		}
		CCHLDMJLNHF();
		if (num > 1 && !flag2)
		{
			FBACPGHOABM.JOEBIBMJEAF(num);
			WinStreakCounter fBACPGHOABM = FBACPGHOABM;
			fBACPGHOABM.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM.JEMKCLKCOMI, new Action(InitGUIValues));
			WinStreakCounter fBACPGHOABM2 = FBACPGHOABM;
			fBACPGHOABM2.JEMKCLKCOMI = (Action)Delegate.Combine(fBACPGHOABM2.JEMKCLKCOMI, new Action(InitGUIValues));
		}
		else
		{
			FBACPGHOABM.FHPIJEDMPMK();
			WinStreakCounter fBACPGHOABM3 = FBACPGHOABM;
			fBACPGHOABM3.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM3.JEMKCLKCOMI, new Action(InitGUIValues));
		}
	}

	public virtual void PGJDLKDMCHN()
	{
		bool flag = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardSelectionScreen>.instance;
		bool flag2 = Singleton<DogTagManager>.instance.AKAALNKEBAF();
		bool isEmpty = Singleton<DogTagManager>.instance.isEmpty;
		bool flag3 = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		float y = ((!flag2 && flag3) ? 1969f : 1389f);
		int num = Singleton<DogTagManager>.instance.ACHMONENAIH();
		if (num == 0)
		{
			num = Singleton<DogTagManager>.instance.FMHEFMJEGGB();
		}
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, y, 964f);
		FAMJBGBLFPE.SetActive(flag2);
		JMGAAOFMFGF.SetActive(!flag2);
		if (flag2)
		{
			bool flag4 = Singleton<VipManager>.instance.MBLIANMNDEH();
			NFNLBEGFLHC.text = Localization.Localize("Selected ");
			JPCIACBHGHO.text = Localization.Localize((!flag4) ? "Total_Gold_Earned" : "Level");
			NKGJMHALAJH.text = JPCIACBHGHO.text;
			AFEFEMENHHH.SetActive(!flag4);
			KGPGCCPMCIG.transform.localPosition = KGPGCCPMCIG.transform.localPosition.ReplaceX((!flag4) ? 1755f : 1234f);
		}
		else
		{
			HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<DogTagManager>.instance.dogtagRefillPrice);
			BFILJFABGDB.SetActive(flag3);
			IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.GKHDDNIDMFD());
			MKCNELEIHDL.SetActive(flag);
			NLIDAODOODF.SetActive(!flag || flag3);
			if (isEmpty)
			{
				NFNLBEGFLHC.text = Localization.Localize("ID_SUGGESTEDGLOBALSQUADS");
				JPCIACBHGHO.text = Localization.Localize("ID_LOADING");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
			else
			{
				NFNLBEGFLHC.text = Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_6");
				JPCIACBHGHO.text = Localization.Localize("ID_TUTORIAL_OVERTIME");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
		}
		JEBHEECINDJ();
		if (num > 0 && !flag2)
		{
			FBACPGHOABM.NLLOFLEJHHD(num);
			WinStreakCounter fBACPGHOABM = FBACPGHOABM;
			fBACPGHOABM.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM.JEMKCLKCOMI, new Action(InitGUIValues));
			WinStreakCounter fBACPGHOABM2 = FBACPGHOABM;
			fBACPGHOABM2.JEMKCLKCOMI = (Action)Delegate.Combine(fBACPGHOABM2.JEMKCLKCOMI, new Action(InitGUIValues));
		}
		else
		{
			FBACPGHOABM.FCCMIGMMDEG();
			WinStreakCounter fBACPGHOABM3 = FBACPGHOABM;
			fBACPGHOABM3.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM3.JEMKCLKCOMI, new Action(InitGUIValues));
		}
	}

	public GuiElement FKCNDEANKNA()
	{
		return this;
	}

	private void JEBHEECINDJ()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionLabel.text = JPCIACBHGHO.text;
			float b = mSubscriptionLabel.relativeSize.x * JPCIACBHGHO.transform.localScale.x;
			mSubscriptionLabel.text = Localization.LocalizeFormat("ID_DOGTAGSREFILLINGFASTERSUBSCRIPTION", SubscriptionManager.instance.dogtagsPercent);
			float num = mSubscriptionLabel.relativeSize.x * mSubscriptionLabel.transform.localScale.x;
			float num2 = Mathf.Max(num, b) / 2f + 6f + mSubscriptionIcon.transform.localScale.x / 2f;
			mSubscriptionLabel.transform.localPosition = mSubscriptionLabel.transform.localPosition.ReplaceX((0f - num) / 2f);
			mSubscriptionIcon.transform.localPosition = mSubscriptionIcon.transform.localPosition.ReplaceX(0f - num2);
		}
	}

	public virtual void AEADDDNBLEE()
	{
		FJHIPNPNGAG(LJNPCHFCGCN);
	}

	public override void InitGUIValues()
	{
		bool flag = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardSelectionScreen>.instance;
		bool isFull = Singleton<DogTagManager>.instance.isFull;
		bool isEmpty = Singleton<DogTagManager>.instance.isEmpty;
		bool flag2 = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag);
		float y = ((!isFull && flag2) ? 960f : 820f);
		int num = Singleton<DogTagManager>.instance.remainingTimeForNextDogtag;
		if (num == 0)
		{
			num = Singleton<DogTagManager>.instance.timeToGetDogtag;
		}
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, y, 1f);
		FAMJBGBLFPE.SetActive(isFull);
		JMGAAOFMFGF.SetActive(!isFull);
		if (isFull)
		{
			bool flag3 = Singleton<VipManager>.instance.NOGEIPHFNPK();
			NFNLBEGFLHC.text = Localization.Localize("ID_DOGTAGSFULL");
			JPCIACBHGHO.text = Localization.Localize((!flag3) ? "ID_YOURDOGTAGSAREFULLNOTVIP" : "ID_YOURDOGTAGSAREFULLMOVEALONG");
			NKGJMHALAJH.text = JPCIACBHGHO.text;
			AFEFEMENHHH.SetActive(!flag3);
			KGPGCCPMCIG.transform.localPosition = KGPGCCPMCIG.transform.localPosition.ReplaceX((!flag3) ? (-347f) : 0f);
		}
		else
		{
			HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<DogTagManager>.instance.dogtagRefillPrice);
			BFILJFABGDB.SetActive(flag2);
			IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.dogtagRefillInProgress);
			MKCNELEIHDL.SetActive(flag);
			NLIDAODOODF.SetActive(flag && flag2);
			if (isEmpty)
			{
				NFNLBEGFLHC.text = Localization.Localize("ID_DOGTAGSREQUIRED");
				JPCIACBHGHO.text = Localization.Localize("ID_YOUNEEDATLEASTONEDOGTAGTOPLAY");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
			else
			{
				NFNLBEGFLHC.text = Localization.Localize("ID_DOGTAGS");
				JPCIACBHGHO.text = Localization.Localize("ID_WAITFORDOGTAGTOREFILL");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
		}
		JEBHEECINDJ();
		if (num > 0 && !isFull)
		{
			FBACPGHOABM.EEJODEKFIOP(num);
			WinStreakCounter fBACPGHOABM = FBACPGHOABM;
			fBACPGHOABM.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM.JEMKCLKCOMI, new Action(InitGUIValues));
			WinStreakCounter fBACPGHOABM2 = FBACPGHOABM;
			fBACPGHOABM2.JEMKCLKCOMI = (Action)Delegate.Combine(fBACPGHOABM2.JEMKCLKCOMI, new Action(InitGUIValues));
		}
		else
		{
			FBACPGHOABM.FHPIJEDMPMK();
			WinStreakCounter fBACPGHOABM3 = FBACPGHOABM;
			fBACPGHOABM3.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM3.JEMKCLKCOMI, new Action(InitGUIValues));
		}
	}

	public virtual void DDHFFMIJMJG()
	{
		base.DoBeforeHide();
		FBACPGHOABM.IOKMGDJGLMK();
		UIDraggablePanel.panelDisabled = true;
	}

	private void MPDENCCNMIJ(bool JGNKIAHGDCO)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MCGFCKAJMFP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AGGCPJNHHGI));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFILJFABGDB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MPNMGDNNJEE));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GLJGKJCMAKB));
		UIEventListener uIEventListener4 = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GLJGKJCMAKB));
		UIEventListener uIEventListener5 = UIEventListener.Get(AFEFEMENHHH);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(COHKEFFLIDH));
		KFCNKPGDBIF();
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += NFLBCCJNNKB;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += NFLBCCJNNKB;
		Singleton<VipManager>.instance.VipStatusChanged += FFPDEGJNDOE;
		DogTagManager dogTagManager = Singleton<DogTagManager>.instance;
		dogTagManager.KNCCBMHGCNI = (Action)Delegate.Combine(dogTagManager.KNCCBMHGCNI, new Action(MEMJOJDOANH));
	}

	private void AGGCPJNHHGI(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (Singleton<DogTagManager>.instance.isFull)
			{
				HideDialog();
				ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("WarBucks"), Localization.Localize("C3"), HECFOEMLJCD);
			}
			else if (Singleton<Wallet>.instance.CanBuyGold(Singleton<DogTagManager>.instance.dogtagRefillPrice))
			{
				Singleton<PurchaseProtection>.instance.RefillingDogtags();
				IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.dogtagRefillInProgress);
				Singleton<BeanstalkServerManager>.instance.PFGOADODBJF();
			}
			else
			{
				HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(Singleton<DogTagManager>.instance.DLBKEJKCIFP(), Localization.Localize("_TranslucencyColor"));
				GuiElementSingle<InappScreen>.instance.EAMKLECMCNE("Player promoted - database informations:\nName:{0} Level:{1} SquadId:{2} SquadRank:{3}");
			}
		}
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MCGFCKAJMFP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AGGCPJNHHGI));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFILJFABGDB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AAMCEDDMGKH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
		UIEventListener uIEventListener4 = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(CFJMKOALDLE));
		UIEventListener uIEventListener5 = UIEventListener.Get(AFEFEMENHHH);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OOAFMBCMGMJ));
		KFCNKPGDBIF();
	}

	private void CCHLDMJLNHF()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionLabel.text = JPCIACBHGHO.text;
			float b = mSubscriptionLabel.relativeSize.x * JPCIACBHGHO.transform.localScale.x;
			UILabel uILabel = mSubscriptionLabel;
			object[] array = new object[0];
			array[1] = SubscriptionManager.instance.dogtagsPercent;
			uILabel.text = Localization.LocalizeFormat("grenadelauncher_idle", array);
			float num = mSubscriptionLabel.relativeSize.x * mSubscriptionLabel.transform.localScale.x;
			float num2 = Mathf.Max(num, b) / 1800f + 1931f + mSubscriptionIcon.transform.localScale.x / 779f;
			mSubscriptionLabel.transform.localPosition = mSubscriptionLabel.transform.localPosition.ReplaceX((0f - num) / 1997f);
			mSubscriptionIcon.transform.localPosition = mSubscriptionIcon.transform.localPosition.ReplaceX(0f - num2);
		}
	}

	public virtual void IMEOAPEABLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MCGFCKAJMFP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ALFHPHJBGCJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFILJFABGDB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AAMCEDDMGKH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GLJGKJCMAKB));
		UIEventListener uIEventListener4 = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener5 = UIEventListener.Get(AFEFEMENHHH);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HIIGJIMBFAN));
		KFCNKPGDBIF();
	}

	private void KFCNKPGDBIF()
	{
		GMFLAJBAEPB.transform.localScale = new Vector3(LFBIEEFIEEC.relativeSize.x * LFBIEEFIEEC.transform.localScale.x + 2f, 48f, 1f);
		EHKOCIDJEMH.transform.localPosition = new Vector3(-434f + GMFLAJBAEPB.transform.localScale.x, 6f, EHKOCIDJEMH.transform.localPosition.z);
		KJFABFFACIG.text = Localization.Localize("ID_WATCHVIDEO");
		MEJMLNDFDBP.COCBCFKJOJE(KJFABFFACIG, 42f, 20f, 340);
		GIJGICGPAOE.transform.localScale = new Vector3(KJFABFFACIG.relativeSize.x * KJFABFFACIG.transform.localScale.x + 30f, 82f, 1f);
	}

	public GuiElement FEJMHFBCGDO()
	{
		return this;
	}

	private void CPNCDECGEGG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void POELPDMKKNE()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void HIIGJIMBFAN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.EBLLBOAGGPJ();
		}
	}

	public virtual void LNGCPPINMJJ()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(NJAGFAPEMJL);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += NLBBEMNHCJM;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += NLBBEMNHCJM;
		Singleton<VipManager>.instance.HCPJKBMBCMB(FFPDEGJNDOE);
		DogTagManager dogTagManager = Singleton<DogTagManager>.instance;
		dogTagManager.KNCCBMHGCNI = (Action)Delegate.Combine(dogTagManager.KNCCBMHGCNI, new Action(OHCCLBGKEAL));
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void FJHIPNPNGAG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == DatabaseAction.AddVideoReward || IFGAGNBDKBE == DatabaseAction.RefillDogtags))
		{
			InitGUIValues();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		FBACPGHOABM.FHPIJEDMPMK();
		UIDraggablePanel.panelDisabled = false;
	}

	private void KPHHBHIMPLH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void OOAFMBCMGMJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	private void KGCCDBKBOJB()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void HGPIABBEHDD()
	{
		bool isSubscribed = SubscriptionManager.instance.isSubscribed;
		mSubscriptionPart.SetActive(isSubscribed);
		if (isSubscribed)
		{
			mSubscriptionLabel.text = JPCIACBHGHO.text;
			float b = mSubscriptionLabel.relativeSize.x * JPCIACBHGHO.transform.localScale.x;
			UILabel uILabel = mSubscriptionLabel;
			object[] array = new object[0];
			array[0] = SubscriptionManager.instance.dogtagsPercent;
			uILabel.text = Localization.LocalizeFormat("IsWarArena", array);
			float num = mSubscriptionLabel.relativeSize.x * mSubscriptionLabel.transform.localScale.x;
			float num2 = Mathf.Max(num, b) / 1904f + 741f + mSubscriptionIcon.transform.localScale.x / 424f;
			mSubscriptionLabel.transform.localPosition = mSubscriptionLabel.transform.localPosition.ReplaceX((0f - num) / 306f);
			mSubscriptionIcon.transform.localPosition = mSubscriptionIcon.transform.localPosition.ReplaceX(0f - num2);
		}
	}

	private void JMOKLHAMAIF(bool JGNKIAHGDCO)
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	protected void OnApplicationPause(bool NMCKKMEKOHM)
	{
		if (!NMCKKMEKOHM)
		{
			FBACPGHOABM.FHPIJEDMPMK();
			InitGUIValues();
		}
	}

	private void MEMJOJDOANH()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void ALFHPHJBGCJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (Singleton<DogTagManager>.instance.isFull)
			{
				HideDialog();
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL"), Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL_TEXT"), HECFOEMLJCD);
			}
			else if (Singleton<Wallet>.instance.CanBuyGold(Singleton<DogTagManager>.instance.dogtagRefillPrice))
			{
				Singleton<PurchaseProtection>.instance.RefillingDogtags();
				IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.dogtagRefillInProgress);
				Singleton<BeanstalkServerManager>.instance.PFGOADODBJF();
			}
			else
			{
				HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(Singleton<DogTagManager>.instance.dogtagRefillPrice, Localization.Localize("ID_DOGTAGSREFILL"));
				GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "DogTags";
			}
		}
	}

	public virtual void DGALBBFCFKE()
	{
		base.DALAPEANFLB();
		UIDraggablePanel.panelDisabled = false;
		TweenAlpha.Begin(IIOILOPFALF, 257f, 1796f, 95f);
	}

	public GuiElement GFLIHAFEKBK()
	{
		return this;
	}

	private void NLBBEMNHCJM()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	public virtual void KPMLFMMINEP()
	{
		bool flag = Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardSelectionScreen>.instance;
		bool flag2 = Singleton<DogTagManager>.instance.KDKHHPFBBBB();
		bool isEmpty = Singleton<DogTagManager>.instance.isEmpty;
		bool flag3 = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		float y = ((!flag2 && flag3) ? 1847f : 826f);
		int num = Singleton<DogTagManager>.instance.IICKLIAPFNA();
		if (num == 0)
		{
			num = Singleton<DogTagManager>.instance.PBEKNDPFIHG();
		}
		KMFGCJEGJJK.transform.localScale = new Vector3(KMFGCJEGJJK.transform.localScale.x, y, 268f);
		FAMJBGBLFPE.SetActive(flag2);
		JMGAAOFMFGF.SetActive(flag2);
		if (flag2)
		{
			bool flag4 = Singleton<VipManager>.instance.FAKAOBDANNA();
			NFNLBEGFLHC.text = Localization.Localize("Player not in squad! - WTF");
			JPCIACBHGHO.text = Localization.Localize((!flag4) ? "PlayerName" : "WarBucks");
			NKGJMHALAJH.text = JPCIACBHGHO.text;
			AFEFEMENHHH.SetActive(flag4);
			KGPGCCPMCIG.transform.localPosition = KGPGCCPMCIG.transform.localPosition.ReplaceX((!flag4) ? 831f : 222f);
		}
		else
		{
			HJKCBBANLDM.text = MEJMLNDFDBP.GMIPFLIEOHD(Singleton<DogTagManager>.instance.DLBKEJKCIFP());
			BFILJFABGDB.SetActive(flag3);
			IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.HEFBPLMKIIO());
			MKCNELEIHDL.SetActive(flag);
			NLIDAODOODF.SetActive(flag && flag3);
			if (isEmpty)
			{
				NFNLBEGFLHC.text = Localization.Localize("ProductId");
				JPCIACBHGHO.text = Localization.Localize("Play_Card_Tutorial_Duration");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
			else
			{
				NFNLBEGFLHC.text = Localization.Localize("SquadId");
				JPCIACBHGHO.text = Localization.Localize("BotCards");
				NKGJMHALAJH.text = JPCIACBHGHO.text;
			}
		}
		CCHLDMJLNHF();
		if (num > 0 && !flag2)
		{
			FBACPGHOABM.GCMANNCPADK(num);
			WinStreakCounter fBACPGHOABM = FBACPGHOABM;
			fBACPGHOABM.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM.JEMKCLKCOMI, new Action(InitGUIValues));
			WinStreakCounter fBACPGHOABM2 = FBACPGHOABM;
			fBACPGHOABM2.JEMKCLKCOMI = (Action)Delegate.Combine(fBACPGHOABM2.JEMKCLKCOMI, new Action(InitGUIValues));
		}
		else
		{
			FBACPGHOABM.IOKMGDJGLMK();
			WinStreakCounter fBACPGHOABM3 = FBACPGHOABM;
			fBACPGHOABM3.JEMKCLKCOMI = (Action)Delegate.Remove(fBACPGHOABM3.JEMKCLKCOMI, new Action(InitGUIValues));
		}
	}

	private void HPGGKHNHBAO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	public virtual void BBKJGLONJEI()
	{
		base.DoBeforeHide();
		FBACPGHOABM.IOKMGDJGLMK();
		UIDraggablePanel.panelDisabled = true;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIDraggablePanel.panelDisabled = true;
		TweenAlpha.Begin(IIOILOPFALF, 0.1f, 1f, 1f);
	}

	private void AAMCEDDMGKH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.Dogtag);
			HideDialog();
		}
	}

	private void FFPDEGJNDOE(bool JGNKIAHGDCO)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void IIGAKKOCEKP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (Singleton<DogTagManager>.instance.KDKHHPFBBBB())
			{
				HideDialog();
				ConfirmDialog.KDAEFLFPBMN(Localization.Localize("LowLevelSilverRarity"), Localization.Localize("ID_CONFIRM_ERROR"), HECFOEMLJCD);
			}
			else if (Singleton<Wallet>.instance.CanBuyGold(Singleton<DogTagManager>.instance.DLBKEJKCIFP()))
			{
				Singleton<PurchaseProtection>.instance.RefillingDogtags();
				IIOILOPFALF.SetActive(Singleton<PurchaseProtection>.instance.PCOECEPHODD());
				Singleton<BeanstalkServerManager>.instance.PFGOADODBJF();
			}
			else
			{
				HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(Singleton<DogTagManager>.instance.DLBKEJKCIFP(), Localization.Localize("PackLocation"));
				GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("OtherPlayer");
			}
		}
	}

	protected void PPOODJMDCGJ(bool NMCKKMEKOHM)
	{
		if (!NMCKKMEKOHM)
		{
			FBACPGHOABM.FCCMIGMMDEG();
			InitGUIValues();
		}
	}

	public virtual void MGBLKIEGMBG()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += NJAGFAPEMJL;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += POELPDMKKNE;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += NLBBEMNHCJM;
		Singleton<VipManager>.instance.HCPJKBMBCMB(JMOKLHAMAIF);
		DogTagManager dogTagManager = Singleton<DogTagManager>.instance;
		dogTagManager.KNCCBMHGCNI = (Action)Delegate.Combine(dogTagManager.KNCCBMHGCNI, new Action(OHCCLBGKEAL));
	}

	public GuiElement LLMDPKEJJHI()
	{
		return this;
	}

	private void DGNLNAEBGIF()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void NPJGJBCEFCA(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void HKENNEJCGFE()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(NJAGFAPEMJL);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += NLBBEMNHCJM;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += POELPDMKKNE;
		Singleton<VipManager>.instance.VipStatusChanged += MPDENCCNMIJ;
		DogTagManager dogTagManager = Singleton<DogTagManager>.instance;
		dogTagManager.KNCCBMHGCNI = (Action)Delegate.Combine(dogTagManager.KNCCBMHGCNI, new Action(OHCCLBGKEAL));
	}

	public virtual void PBKJDKFPILH()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(NJAGFAPEMJL);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<EventTrackingManager>.instance.RewardVideoPreloaded += NLBBEMNHCJM;
		Singleton<EventTrackingManager>.instance.AdLimitsChanged += NFLBCCJNNKB;
		Singleton<VipManager>.instance.JEPFBKHJPMA(CKLLFPFHGCF);
		DogTagManager dogTagManager = Singleton<DogTagManager>.instance;
		dogTagManager.KNCCBMHGCNI = (Action)Delegate.Combine(dogTagManager.KNCCBMHGCNI, new Action(MEMJOJDOANH));
	}

	public virtual void GMDAPGAECEI()
	{
		GLJGKJCMAKB(LJNPCHFCGCN);
	}

	private void COHKEFFLIDH(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.BFLBFOKFDIM();
		}
	}

	private void GLJGKJCMAKB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	protected void GBBGAMHEGBH(bool NMCKKMEKOHM)
	{
		if (!NMCKKMEKOHM)
		{
			FBACPGHOABM.IOKMGDJGLMK();
			InitGUIValues();
		}
	}

	public virtual void EIPCLGCNKGO()
	{
		GLJGKJCMAKB(LJNPCHFCGCN);
	}

	private void MPNMGDNNJEE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH((MHNMOFPPKBN)8);
			HideDialog();
		}
	}

	private void CKLLFPFHGCF(bool JGNKIAHGDCO)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void NJAGFAPEMJL(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && (IFGAGNBDKBE == (DatabaseAction)(-188) || IFGAGNBDKBE == (DatabaseAction)(-87)))
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 977f);
			InitGUIValues();
		}
	}

	public GuiElement HGBADFIMKOK()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MCGFCKAJMFP);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ALFHPHJBGCJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFILJFABGDB);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AAMCEDDMGKH));
		UIEventListener uIEventListener3 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener4 = UIEventListener.Get(KGPGCCPMCIG);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener5 = UIEventListener.Get(AFEFEMENHHH);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OOAFMBCMGMJ));
		KFCNKPGDBIF();
	}

	private void OHCCLBGKEAL()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	public virtual void CGIFPCLNPBO()
	{
		base.NEEAKMELPBJ();
		FBACPGHOABM.FHPIJEDMPMK();
		UIDraggablePanel.panelDisabled = true;
	}
}
