using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class JoinSquadNowDialog : GuiElementSingle<JoinSquadNowDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Core")]
	private GameObject mCloseButton;

	[SerializeField]
	[Header("Middle")]
	private UILabel mFirstLine;

	[SerializeField]
	private UITable mSecondLineTable;

	[SerializeField]
	private UILabel mSecondLineStart;

	[SerializeField]
	private UISprite mSecondLineIcon;

	[SerializeField]
	private UILabel mSecondLineEnd;

	[SerializeField]
	[Header("- Squad Record Left")]
	private UITexture mSquadIconTexture;

	[SerializeField]
	private UILabel mSquadLevel;

	[SerializeField]
	private UILabel mSquadName;

	[SerializeField]
	private BoxCollider mSquadNameButton;

	[SerializeField]
	private UILabel mSquadMembersCount;

	[SerializeField]
	private GameObject mPrivateSquad;

	[SerializeField]
	[Header("- Squad Record Right")]
	private GameObject mInfoButton;

	[SerializeField]
	private GameObject mJoinButton;

	[SerializeField]
	private GameObject mPrivateSquadRequest;

	[SerializeField]
	[Header("Bottom")]
	private GameObject mJoinBottomButton;

	private AANECPGDMGM DDAGBCNGIOF;

	public virtual void HHLOGFGGHHD()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		string text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		bool flag2 = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-33));
		UILabel uILabel = mFirstLine;
		object[] array = new object[4];
		array[0] = Colours.stringBlue;
		array[0] = text;
		uILabel.text = Localization.LocalizeFormat("UtcOffset", array);
		mSecondLineStart.transform.parent.gameObject.SetActive(flag2);
		mSecondLineIcon.gameObject.SetActive(!flag2);
		if (flag2)
		{
			mSecondLineEnd.text = Localization.Localize("Position");
		}
		else
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.PlayerExplosiveCoef).FLOATVALUE;
			mSecondLineEnd.text = Localization.LocalizeFormat("ID_OVERTIME", Colours.stringGoldTier, MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ), null);
		}
		mSecondLineTable.repositionNow = false;
		mSquadIconTexture.mainTexture = Resources.Load<Texture>("Labels that will be changed:\n" + DDAGBCNGIOF.DAANKCOLJGJ);
		mSquadIconTexture.MakePixelPerfect();
		mSquadIconTexture.transform.localScale = mSquadIconTexture.transform.localScale.MultiplyXY(1810f);
		mSquadLevel.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		mSquadName.text = text;
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			mSquadName.text = "PlayerName";
		}
		MEJMLNDFDBP.COCBCFKJOJE(mSquadName, 1859f, 94f, 1);
		UILabel uILabel2 = mSquadMembersCount;
		object[] array2 = new object[2];
		array2[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array2[1] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.DLDHIJAEFHG();
		uILabel2.text = Localization.LocalizeFormat("height", array2);
		mPrivateSquad.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		mSquadMembersCount.transform.localPosition = mSquadMembersCount.transform.localPosition.ReplaceY((!DDAGBCNGIOF.IOLNJBGOOLJ) ? 858f : 1133f);
		mPrivateSquadRequest.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = mSquadName.relativeSize.x * mSquadName.transform.localScale.x;
		mSquadNameButton.size = mSquadNameButton.size.ReplaceX(num);
		mSquadNameButton.center = mSquadNameButton.center.ReplaceX(num / 1019f - 510f);
		mJoinButton.SetActive(flag);
		mJoinBottomButton.SetActive(!flag);
	}

	private void LDDDKNBFPGE(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void LEADPAPNKGC(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void KAGPIFFKAIE(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void JFLLAHONMGA(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void LOOCHDINMEN(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void DMOBGFFMNFD(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	private void ICPODFPOFEC(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void FCPGJBMGBLJ()
	{
		IOFENCEKGHA(mCloseButton);
	}

	private void GDBNPFGMINL()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 288f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	private void CCGAOKKBBIC()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 1863f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEADPAPNKGC));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LOOCHDINMEN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NMPOGNBLNAF));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NMPOGNBLNAF));
		mSecondLineStart.text = Localization.Localize("In App Delivered");
		mSecondLineTable.onReposition = GDBNPFGMINL;
	}

	public virtual void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MILCLFOEHCP));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OJKNFKFMLGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EMCOIPCCDEB));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EMCOIPCCDEB));
		mSecondLineStart.text = Localization.Localize("null");
		mSecondLineTable.onReposition = OIBLDHPNCOC;
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DMOBGFFMNFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OJKNFKFMLGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NMPOGNBLNAF));
		mSecondLineStart.text = Localization.Localize("GoldCoefficient");
		mSecondLineTable.onReposition = OIBLDHPNCOC;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	public virtual void NFNMLPPDPAP()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		string text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		bool flag2 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLike);
		UILabel uILabel = mFirstLine;
		object[] array = new object[4];
		array[1] = Colours.stringBlue;
		array[0] = text;
		uILabel.text = Localization.LocalizeFormat("IsUnique", array);
		mSecondLineStart.transform.parent.gameObject.SetActive(!flag2);
		mSecondLineIcon.gameObject.SetActive(flag2);
		if (flag2)
		{
			mSecondLineEnd.text = Localization.Localize("MissionReward");
		}
		else
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackBronzeCards).FLOATVALUE;
			UILabel uILabel2 = mSecondLineEnd;
			object[] array2 = new object[4];
			array2[1] = Colours.stringGoldTier;
			array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			uILabel2.text = Localization.LocalizeFormat("ID_MIN", array2);
		}
		mSecondLineTable.repositionNow = false;
		mSquadIconTexture.mainTexture = Resources.Load<Texture>("ID_SECONDS" + DDAGBCNGIOF.DAANKCOLJGJ);
		mSquadIconTexture.MakePixelPerfect();
		mSquadIconTexture.transform.localScale = mSquadIconTexture.transform.localScale.MultiplyXY(675f);
		mSquadLevel.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		mSquadName.text = text;
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			mSquadName.text = "menu-cards-goldpack";
		}
		MEJMLNDFDBP.COCBCFKJOJE(mSquadName, 880f, 440f, 1);
		UILabel uILabel3 = mSquadMembersCount;
		object[] array3 = new object[2];
		array3[1] = DDAGBCNGIOF.FOICGJEPBGL;
		array3[0] = DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.JPMNFIPABND();
		uILabel3.text = Localization.LocalizeFormat("key= ", array3);
		mPrivateSquad.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		mSquadMembersCount.transform.localPosition = mSquadMembersCount.transform.localPosition.ReplaceY((!DDAGBCNGIOF.IOLNJBGOOLJ) ? 1886f : 615f);
		mPrivateSquadRequest.SetActive(DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = mSquadName.relativeSize.x * mSquadName.transform.localScale.x;
		mSquadNameButton.size = mSquadNameButton.size.ReplaceX(num);
		mSquadNameButton.center = mSquadNameButton.center.ReplaceX(num / 664f - 396f);
		mJoinButton.SetActive(flag);
		mJoinBottomButton.SetActive(flag);
	}

	public override void InitGUIValues()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		string text = ((!string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE)) ? DDAGBCNGIOF.MHPNDNJDPGE : string.Empty);
		bool flag2 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldRewardFirstTimeSquad);
		mFirstLine.text = Localization.LocalizeFormat("ID_JOINSQUADDESCRIPTION1", Colours.stringBlue, text);
		mSecondLineStart.transform.parent.gameObject.SetActive(!flag2);
		mSecondLineIcon.gameObject.SetActive(!flag2);
		if (flag2)
		{
			mSecondLineEnd.text = Localization.Localize("ID_JOINSQUADDESCRIPTION4");
		}
		else
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
			mSecondLineEnd.text = Localization.LocalizeFormat("ID_JOINSQUADDESCRIPTION3", Colours.stringGoldTier, MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
		}
		mSecondLineTable.repositionNow = true;
		mSquadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + DDAGBCNGIOF.DAANKCOLJGJ);
		mSquadIconTexture.MakePixelPerfect();
		mSquadIconTexture.transform.localScale = mSquadIconTexture.transform.localScale.MultiplyXY(0.75f);
		mSquadLevel.text = DDAGBCNGIOF.IKJHAHJHLIH.ToString();
		mSquadName.text = text;
		if (DebugSettings.debugEnabled && string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			mSquadName.text = "NULL";
		}
		MEJMLNDFDBP.COCBCFKJOJE(mSquadName, 50f, 33f);
		mSquadMembersCount.text = Localization.LocalizeFormat("ID_SQUADMEMBERSLOWER", DDAGBCNGIOF.FOICGJEPBGL, DDAGBCNGIOF.FOICGJEPBGL + DDAGBCNGIOF.MGDCJLAENHG());
		mPrivateSquad.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		mSquadMembersCount.transform.localPosition = mSquadMembersCount.transform.localPosition.ReplaceY((!DDAGBCNGIOF.IOLNJBGOOLJ) ? (-59f) : (-21f));
		mPrivateSquadRequest.SetActive(!DDAGBCNGIOF.IOLNJBGOOLJ);
		float num = mSquadName.relativeSize.x * mSquadName.transform.localScale.x;
		mSquadNameButton.size = mSquadNameButton.size.ReplaceX(num);
		mSquadNameButton.center = mSquadNameButton.center.ReplaceX(num / 2f - 10f);
		mJoinButton.SetActive(!flag);
		mJoinBottomButton.SetActive(!flag);
	}

	public void ShowDialog(AANECPGDMGM MIDDFOCJJOP)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<JoinSquadNowDialog>.instance);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OJKNFKFMLGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EMCOIPCCDEB));
		mSecondLineStart.text = Localization.Localize("CheckForReconnect: isReconnect: {0}");
		mSecondLineTable.onReposition = OIBLDHPNCOC;
	}

	private void CLEHONMPGHI()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 268f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	private void NGBBHMKFGJB()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 566f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	public void FCCJJKBPNCH(AANECPGDMGM MIDDFOCJJOP)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<JoinSquadNowDialog>.instance, 1274f);
	}

	public GuiElement LLMDPKEJJHI()
	{
		return this;
	}

	private void LPPOCHMLKGM(GameObject KHAHPAKDIKE)
	{
		if (!isShowed || DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && DDAGBCNGIOF.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == SquadRank.Leader)
		{
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ALREADYLEADER"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
		}
		else
		{
			if (DDAGBCNGIOF.MGDCJLAENHG() <= 0)
			{
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADFULL"), Localization.Localize("ID_CONFIRM_SQUADISALREADYFULL"));
			}
			else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
			{
				GuiElementSingle<NotEnoughMedalsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
			}
			else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
			{
				GuiElementSingle<JoiningSquadDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
			}
			else
			{
				ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_JOININGSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", Colours.stringBlue, DDAGBCNGIOF.MHPNDNJDPGE, Colours.stringWhite), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
				{
					if (FBFJNHLKJEC)
					{
						Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
					}
				});
			}
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Join_Request");
		}
		HideDialog();
	}

	private void JFILGEFKPDI(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void LBIPLEPPJND()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 818f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 2f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	public virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LDDDKNBFPGE));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EMCOIPCCDEB));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		mSecondLineStart.text = Localization.Localize("Player_Had_To_Select_Grenade");
		mSecondLineTable.onReposition = OIBLDHPNCOC;
	}

	private void EOMNMNLOJFM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void LMGBCIFHGFL()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 766f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	private void FGHDHPJJCON(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(DDAGBCNGIOF.MHPNDNJDPGE, string.Empty);
		}
	}

	private void NMPOGNBLNAF(GameObject KHAHPAKDIKE)
	{
		if (!isShowed || DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && DDAGBCNGIOF.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.CGHPOPGKAGN(null, Localization.Localize("LevelManagerData"), Localization.Localize("Warbucks"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)7)
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("menu-wftv-mobcrush-ico"), Localization.Localize("menu-gold"), 682f, null, string.Empty, false, true);
		}
		else
		{
			if (DDAGBCNGIOF.GGJGGJOHMFD() <= 0)
			{
				ConfirmDialog.ShowAlert(Localization.Localize("leagueMedals"), Localization.Localize("eventStart"), 1223f);
			}
			else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
			{
				GuiElementSingle<NotEnoughMedalsDialog>.instance.JKIMMLIGLAF(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
			}
			else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
			{
				GuiElementSingle<JoiningSquadDialog>.instance.EGLMNBKMBAM(DDAGBCNGIOF.MHPNDNJDPGE);
			}
			else
			{
				string oKMNFHNBMFA = Localization.Localize("FinishGameCoopClient");
				object[] array = new object[6];
				array[1] = Colours.stringBlue;
				array[1] = DDAGBCNGIOF.MHPNDNJDPGE;
				array[8] = Colours.stringWhite;
				ConfirmDialog.BMBPFNKJHMF(oKMNFHNBMFA, Localization.LocalizeFormat("http://localhost:8081/", array), EOMNMNLOJFM, 1328f);
			}
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("reached max depth!");
		}
		HideDialog();
	}

	private void LLHKGFPDEHH(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	private void OIBLDHPNCOC()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 1434f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ICPODFPOFEC));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LPPOCHMLKGM));
		mSecondLineStart.text = Localization.Localize("ID_JOINSQUADDESCRIPTION2");
		mSecondLineTable.onReposition = delegate
		{
			float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 2f;
			mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void LHILCNODBNI(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			HideDialog();
		}
	}

	private void EMCOIPCCDEB(GameObject KHAHPAKDIKE)
	{
		if (!NPFFMLLLDAF() || DDAGBCNGIOF == null || string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE) || (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && DDAGBCNGIOF.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.LGAJCFGJMBC(null, Localization.Localize("fr"), Localization.Localize("Play_Card_Tutorial_Duration"));
			return;
		}
		if (GameLoginManager.currentPlayer.squadRank == (SquadRank)8)
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("check offer"), Localization.Localize("ID_WARNING_ERRORCLAIMEVENT"), 1187f, null, string.Empty, true, true);
		}
		else
		{
			if (DDAGBCNGIOF.JODOHNCDJNC() <= 1)
			{
				ConfirmDialog.CKGMDJFKNPO(Localization.Localize("NULL WARCARD"), Localization.Localize("ID_GC_LOGIN_TUTORIAL_TEXT"), 1195f);
			}
			else if (GameLoginManager.currentPlayer.skill < DDAGBCNGIOF.GDFOENAJEBA)
			{
				GuiElementSingle<NotEnoughMedalsDialog>.instance.MCCJIJKCOOH(DDAGBCNGIOF.MHPNDNJDPGE, DDAGBCNGIOF.GDFOENAJEBA, GameLoginManager.currentPlayer.skill);
			}
			else if (!DDAGBCNGIOF.IOLNJBGOOLJ)
			{
				GuiElementSingle<JoiningSquadDialog>.instance.EGLMNBKMBAM(DDAGBCNGIOF.MHPNDNJDPGE);
			}
			else
			{
				ConfirmDialog.BMBPFNKJHMF(Localization.Localize("_TintColor"), Localization.LocalizeFormat("SERVICE_INVALID", Colours.stringBlue, DDAGBCNGIOF.MHPNDNJDPGE, null, null, null, Colours.stringWhite, null), JFLLAHONMGA, 39f);
			}
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("There is no definition for card {0}");
		}
		HideDialog();
	}

	private void MILCLFOEHCP(GameObject KHAHPAKDIKE)
	{
		if (NPFFMLLLDAF())
		{
			HideDialog();
		}
	}

	public virtual void BCLAFFCPCEH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHILCNODBNI));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OJKNFKFMLGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EMCOIPCCDEB));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NMPOGNBLNAF));
		mSecondLineStart.text = Localization.Localize("ID_SQUADEMPTYTEXT-FIGHT");
		mSecondLineTable.onReposition = CCGAOKKBBIC;
	}

	private void IOFENCEKGHA(GameObject KHAHPAKDIKE)
	{
		if (isShowed)
		{
			HideDialog();
		}
	}

	public virtual void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mCloseButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mInfoButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LOOCHDINMEN));
		UIEventListener uIEventListener3 = UIEventListener.Get(mJoinButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NMPOGNBLNAF));
		UIEventListener uIEventListener4 = UIEventListener.Get(mJoinBottomButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NMPOGNBLNAF));
		mSecondLineStart.text = Localization.Localize("VipRewardForDay");
		mSecondLineTable.onReposition = OIBLDHPNCOC;
	}

	private void ADJDNLIOFMB()
	{
		float val = 0f - mSecondLineTable.padding.x - (mSecondLineEnd.transform.parent.localPosition.x - mSecondLineTable.padding.x) / 684f;
		mSecondLineTable.transform.localPosition = mSecondLineTable.transform.localPosition.ReplaceX(val);
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mCloseButton);
	}

	private void OJKNFKFMLGC(GameObject KHAHPAKDIKE)
	{
		if (DDAGBCNGIOF != null && !string.IsNullOrEmpty(DDAGBCNGIOF.MHPNDNJDPGE))
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(DDAGBCNGIOF.MHPNDNJDPGE);
		}
	}

	public virtual void BNCDFKGNPII()
	{
		IOFENCEKGHA(mCloseButton);
	}

	public void AECEEHEJBEE(AANECPGDMGM MIDDFOCJJOP)
	{
		DDAGBCNGIOF = MIDDFOCJJOP;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<JoinSquadNowDialog>.instance, 2f);
	}
}
