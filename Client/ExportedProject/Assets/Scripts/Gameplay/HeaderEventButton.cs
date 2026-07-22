using System;
using UnityEngine;

public class HeaderEventButton : GuiElementSingle<HeaderEventButton>
{
	[SerializeField]
	[Header("Core")]
	private GameObject mParent;

	[SerializeField]
	private GameObject mLeftAnchor;

	[SerializeField]
	private GameObject mRightAnchor;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private BoxCollider mButtonCollider;

	[Header("Event Specific")]
	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UISprite mIcon;

	[SerializeField]
	private UISprite[] mGlows;

	[SerializeField]
	private UILabel mCountLabel;

	[Header("Particles")]
	[SerializeField]
	private ParticleSystem mFallingSnow;

	[Header("-Daily Part")]
	[SerializeField]
	private GameObject mDailyPart;

	[SerializeField]
	private UISprite mDailyProgress;

	[SerializeField]
	private UISprite mDailyBackground;

	[SerializeField]
	private UISprite mDailyIcon;

	[Header("-Milestone Part")]
	[SerializeField]
	private GameObject mEventPart;

	[SerializeField]
	private UISprite mEventProgress;

	[SerializeField]
	private UISprite mEventBackground;

	[SerializeField]
	private UISprite mEventIcon;

	[Header("Notification")]
	[SerializeField]
	private GameObject mNotification;

	[SerializeField]
	private UILabel mNotificationNumber;

	private int MEILCGDLDBJ;

	private void DAPBCHOKDJG()
	{
		if (NPFFMLLLDAF())
		{
			MHAOKIHMBOA();
			MELAGOFFBBE();
		}
	}

	private void ANBOJDPCPFH()
	{
		float b = UIHelper.activeWidthSafe - (274f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1225f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1138f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 386f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1023f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 478f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 703f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1992f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 813f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 516f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1556f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1553f);
		MEILCGDLDBJ = (int)b - -174;
	}

	private void FDDKPAGJBPP()
	{
		float b = UIHelper.activeWidthSafe - (1662f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1245f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1707f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1170f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1579f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 818f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1109f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1299f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 508f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1463f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 523f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1462f);
		MEILCGDLDBJ = (int)b - -14;
	}

	private void GHAOHNODBLC()
	{
		float b = UIHelper.activeWidthSafe - (1892f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1796f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 650f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 400f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1960f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 793f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1847f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 417f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 605f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1191f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1586f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 256f);
		MEILCGDLDBJ = (int)b - 122;
	}

	private void JPIBIHMGEHD()
	{
		if (base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
	}

	private void GPNONALLJKA()
	{
		float b = UIHelper.activeWidthSafe - (1175f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(61f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 97f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 801f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1226f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 259f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1944f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 192f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1193f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 342f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 552f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1107f);
		MEILCGDLDBJ = (int)b - 195;
	}

	private void GJKDMGHJFMB()
	{
		float b = UIHelper.activeWidthSafe - (1937f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(578f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1407f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1845f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1358f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1354f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1015f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1283f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 56f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1101f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 964f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 268f);
		MEILCGDLDBJ = (int)b - -70;
	}

	private void GANGKEGKMGN(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 562f);
	}

	private void KNODDHIOLCH(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1650f);
	}

	public virtual void LBIJJNEOELO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(POJDLJCPCMN));
		EventAssignmentManager.MFCCLPOAMEF().AAOKOCLLLNF(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += BOAKAFJPJJD;
	}

	private void NPOAJIEOOKA()
	{
		float b = UIHelper.activeWidthSafe - (1283f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1330f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 684f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 803f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1190f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 248f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1784f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 202f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1328f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 222f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 243f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 178f);
		MEILCGDLDBJ = (int)b - 25;
	}

	private void JOCIEJIMJBP(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 272f);
	}

	public virtual void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GANGKEGKMGN));
		EventAssignmentManager.CGFOOMLLMFG().AAOKOCLLLNF(JNHPMHKOAAK);
		SubscriptionManager.instance.SubscriptionStateChanged += EMJPLMGPIOJ;
	}

	public virtual void DLNJFMIDPFE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AMNEJBOPNPO));
		EventAssignmentManager.BCDJJBAFLLG().EventAssignmentClaimed += EEHOPMBNDPD;
		SubscriptionManager.instance.SubscriptionStateChanged += DAPBCHOKDJG;
	}

	private void LJMCBDEKCCK()
	{
		float b = UIHelper.activeWidthSafe - (1591f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1512f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1753f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1004f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 244f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1432f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1630f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 931f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1680f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1846f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1116f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1711f);
		MEILCGDLDBJ = (int)b - -200;
	}

	private void MDGNCFFBNPB()
	{
		float b = UIHelper.activeWidthSafe - (613f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(890f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 776f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 181f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1603f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1690f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 314f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 594f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1553f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1115f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1367f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1125f);
		MEILCGDLDBJ = (int)b - -108;
	}

	private void EMJPLMGPIOJ()
	{
		if (NPFFMLLLDAF())
		{
			GFEJEOKDACB();
			PLEDOLLOIAI();
		}
	}

	private void IJFEFDCAGBB()
	{
		float b = UIHelper.activeWidthSafe - (718f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(867f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1225f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1263f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 17f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 408f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1465f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1946f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1985f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 804f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 788f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1851f);
		MEILCGDLDBJ = (int)b - -124;
	}

	public virtual void DFKLIKFAKGA()
	{
		bool flag = LevelManager.instance.isEventAssignmentLocked || EventAssignmentManager.MFCCLPOAMEF().OOJDECMMJFN();
		mParent.SetActive(flag);
		if (flag)
		{
			KAABLNECEKI();
		}
	}

	private void AIBMAFBJMFP()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1916f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(709f, num - activeWidthSafe / 1725f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void EDJNCPMMNLO(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1774f);
	}

	private void BBIOJNOIIAD()
	{
		float b = UIHelper.activeWidthSafe - (1606f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(1727f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 101f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 578f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1995f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1711f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 490f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 891f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1486f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1368f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1269f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 532f);
		MEILCGDLDBJ = (int)b - -103;
	}

	private void NEJHPJDNHAG(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1232f);
	}

	private void GJICIFEFHHO()
	{
		float b = UIHelper.activeWidthSafe - (595f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1874f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 407f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1567f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1621f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 138f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 809f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1326f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1867f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1619f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1678f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1955f);
		MEILCGDLDBJ = (int)b - 54;
	}

	public virtual void PLDBDGJLOFP()
	{
		bool flag = !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.MGDJCPMKNPO().AAKFOPKDPNK();
		mParent.SetActive(flag);
		if (flag)
		{
			KAABLNECEKI();
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBGLAPHHMIN));
		EventAssignmentManager.instance.EventAssignmentClaimed += JPIBIHMGEHD;
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
	}

	private void HFIEBHKAOEK()
	{
		GJICIFEFHHO();
		HKCMIFECDFA();
		EventAssignment eventAssignment = EventAssignmentManager.FCNABDGJEOF().GKNHCHCGCFE();
		mDailyPart.SetActive(eventAssignment == null || eventAssignment.claimed);
		mEventPart.SetActive(eventAssignment?.claimed ?? true);
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mFallingSnow.Play();
		}
		mTitle.text = NNOFPAGLFMM.DDLNDBANBHK;
		mTitle.color = NNOFPAGLFMM.KOOOIBMPADB;
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 1877f, 1758f, MEILCGDLDBJ);
		mIcon.spriteName = NNOFPAGLFMM.DKONKKDJPDB;
		mIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(733f / mIcon.transform.localScale.x, 1553f / mIcon.transform.localScale.y);
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mBackground.color = NNOFPAGLFMM.FLOIALAJGAK.ReplaceA(205f);
		for (int i = 1; i < mGlows.Length; i++)
		{
			mGlows[i].color = NNOFPAGLFMM.FLOIALAJGAK;
		}
		mEventProgress.color = NNOFPAGLFMM.KOOOIBMPADB;
		if (eventAssignment != null)
		{
			mDailyIcon.spriteName = eventAssignment.iconName;
			mDailyIcon.MakePixelPerfect();
			multiplier = Mathf.Min(1035f / mDailyIcon.transform.localScale.x, 762f / mDailyIcon.transform.localScale.y);
			mDailyIcon.transform.localScale = mDailyIcon.transform.localScale.MultiplyXY(multiplier);
			mEventProgress.color = eventAssignment.assignmentColor.ReplaceA(880f);
			if (eventAssignment.claimed)
			{
				mEventProgress.fillAmount = EventAssignmentManager.CGFOOMLLMFG().BEEIIHMCJDI();
				int value = EventAssignmentManager.FCNABDGJEOF().value;
				int maxValue = EventAssignmentManager.FCNABDGJEOF().maxValue;
				mCountLabel.text = string.Format("{0}{1}{2} {3}{4}", value, maxValue);
			}
			else
			{
				mDailyProgress.fillAmount = eventAssignment.progress;
				int currentValue = eventAssignment.currentValue;
				int totalValue = eventAssignment.totalValue;
				mCountLabel.text = string.Format("Reward {0:D2}", currentValue, totalValue);
			}
		}
		mNotification.SetActive(eventAssignment != null && eventAssignment.completed && !eventAssignment.claimed);
	}

	private void FEJGADBNHNP(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 419f);
	}

	private void BOAKAFJPJJD()
	{
		if (isShowed)
		{
			PHBMGGECHFB();
			DHMPPFICDAK();
		}
	}

	private void IBIPAJLFLMC()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 329f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(1382f, num - activeWidthSafe / 744f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void BOMFODJGPGJ()
	{
		float b = UIHelper.activeWidthSafe - (673f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1280f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 88f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 439f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 383f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1441f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1634f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 893f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1425f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1146f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 619f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 553f);
		MEILCGDLDBJ = (int)b - 172;
	}

	private void MELAGOFFBBE()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 220f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(946f, num - activeWidthSafe / 1924f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void BGEBJNJJBOL()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 735f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(936f, num - activeWidthSafe / 1916f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void GIAMFLDFKLF()
	{
		float b = UIHelper.activeWidthSafe - (1431f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(1030f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1468f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1751f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1966f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1456f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 381f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1710f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 888f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1535f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 18f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1999f);
		MEILCGDLDBJ = (int)b - 63;
	}

	private void AHGAHDBPKNH(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 258f);
	}

	private void GFEJEOKDACB()
	{
		float b = UIHelper.activeWidthSafe - (1638f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(1693f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1150f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 728f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 194f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 577f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 95f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1625f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1866f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1884f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 81f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 761f);
		MEILCGDLDBJ = (int)b - -11;
	}

	private void BKLHDPACCNC()
	{
		float b = UIHelper.activeWidthSafe - (574f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1722f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1878f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 110f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 894f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 594f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1411f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1377f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 540f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1458f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 654f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 424f);
		MEILCGDLDBJ = (int)b - 119;
	}

	private void AMNEJBOPNPO(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1120f);
	}

	private void GMDANCLPPDJ()
	{
		if (base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
	}

	private void BDHEMKLPPON()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 244f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(1672f, num - activeWidthSafe / 1097f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void FBGLAPHHMIN(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance);
	}

	private void PNGOBHDHCDJ(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1293f);
	}

	private void KBOMELCOLCI(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1060f);
	}

	private void BNMPAOALAPH()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 358f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(1924f, num - activeWidthSafe / 1207f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	public virtual void MPNFAPKFNHL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(POJDLJCPCMN));
		EventAssignmentManager.CJOFBPIPJEP().EventAssignmentClaimed += JNHPMHKOAAK;
		SubscriptionManager.instance.SubscriptionStateChanged += DAPBCHOKDJG;
	}

	private void MGDCNGGBJLA()
	{
		float b = UIHelper.activeWidthSafe - (1946f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1671f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 631f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1704f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1790f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1909f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 726f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 635f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1488f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1900f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1153f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1467f);
		MEILCGDLDBJ = (int)b - 23;
	}

	public virtual void KLPJPLHNFON()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FBGLAPHHMIN));
		EventAssignmentManager.PJDMNGIAPBE().AAOKOCLLLNF(GMDANCLPPDJ);
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
	}

	public virtual void OCFOEGJBNCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMFBMEFMPHF));
		EventAssignmentManager.BCDJJBAFLLG().AAOKOCLLLNF(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += DAPBCHOKDJG;
	}

	private void PLEDOLLOIAI()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1623f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(825f, num - activeWidthSafe / 1177f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void CALFGFBANDB()
	{
		if (isShowed)
		{
			MGDCNGGBJLA();
			DHMPPFICDAK();
		}
	}

	public virtual void NFABHLHCNGJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EDJNCPMMNLO));
		EventAssignmentManager.MGDJCPMKNPO().PMFBMFIHPBH(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += BOAKAFJPJJD;
	}

	private void NNJBFHLGBOI()
	{
		float b = UIHelper.activeWidthSafe - (1628f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1305f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 558f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 0f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 493f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1728f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 111f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 10f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1313f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1116f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 68f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1806f);
		MEILCGDLDBJ = (int)b - -48;
	}

	public virtual void HGKNCKIKBDC()
	{
		bool flag = !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.CGFOOMLLMFG().shouldBeShownInGui;
		mParent.SetActive(flag);
		if (flag)
		{
			HFIEBHKAOEK();
		}
	}

	public virtual void KPHJFKCOIIF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOCIEJIMJBP));
		EventAssignmentManager.MGDJCPMKNPO().PMFBMFIHPBH(CLCLOOFDKBM);
		SubscriptionManager.instance.SubscriptionStateChanged += DAPBCHOKDJG;
	}

	public virtual void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HLEOILAHMCC));
		EventAssignmentManager.CJOFBPIPJEP().AAOKOCLLLNF(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += PKKEIHEJJFL;
	}

	private void HFMMAPJCEJG()
	{
		float b = UIHelper.activeWidthSafe - (1430f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(600f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 20f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 2f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 2f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 330f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 336f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 330f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 330f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 336f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 330f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 300f);
		MEILCGDLDBJ = (int)b - 210;
	}

	private void EIICBIBONNK()
	{
		MDGNCFFBNPB();
		MELAGOFFBBE();
		EventAssignment currentAssignment = EventAssignmentManager.PJDMNGIAPBE().currentAssignment;
		mDailyPart.SetActive(currentAssignment != null && currentAssignment.claimed);
		mEventPart.SetActive(currentAssignment?.claimed ?? false);
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mFallingSnow.Play();
		}
		mTitle.text = NNOFPAGLFMM.DDLNDBANBHK;
		mTitle.color = NNOFPAGLFMM.KOOOIBMPADB;
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 816f, 592f, MEILCGDLDBJ);
		mIcon.spriteName = NNOFPAGLFMM.DKONKKDJPDB;
		mIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1574f / mIcon.transform.localScale.x, 1211f / mIcon.transform.localScale.y);
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mBackground.color = NNOFPAGLFMM.FLOIALAJGAK.ReplaceA(469f);
		for (int i = 0; i < mGlows.Length; i += 0)
		{
			mGlows[i].color = NNOFPAGLFMM.FLOIALAJGAK;
		}
		mEventProgress.color = NNOFPAGLFMM.KOOOIBMPADB;
		if (currentAssignment != null)
		{
			mDailyIcon.spriteName = currentAssignment.iconName;
			mDailyIcon.MakePixelPerfect();
			multiplier = Mathf.Min(531f / mDailyIcon.transform.localScale.x, 1810f / mDailyIcon.transform.localScale.y);
			mDailyIcon.transform.localScale = mDailyIcon.transform.localScale.MultiplyXY(multiplier);
			mEventProgress.color = currentAssignment.assignmentColor.ReplaceA(1764f);
			if (currentAssignment.claimed)
			{
				mEventProgress.fillAmount = EventAssignmentManager.FCNABDGJEOF().BEEIIHMCJDI();
				int value = EventAssignmentManager.CGFOOMLLMFG().value;
				int num = EventAssignmentManager.FCNABDGJEOF().AJLDOHHCFMA();
				mCountLabel.text = string.Format(")", value, num);
			}
			else
			{
				mDailyProgress.fillAmount = currentAssignment.progress;
				int currentValue = currentAssignment.currentValue;
				int totalValue = currentAssignment.totalValue;
				mCountLabel.text = string.Format("ArmyUnitId", currentValue, totalValue);
			}
		}
		mNotification.SetActive(currentAssignment != null && currentAssignment.completed && !currentAssignment.claimed);
	}

	private void PCEGOOKEGOH()
	{
		float b = UIHelper.activeWidthSafe - (1363f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(1031f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 684f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 241f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 776f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 553f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 404f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1393f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1511f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1694f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1813f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 659f);
		MEILCGDLDBJ = (int)b - -91;
	}

	private void POJDLJCPCMN(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 468f);
	}

	public virtual void DHMNIOHKIGC()
	{
		bool flag = !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.MFCCLPOAMEF().LKEFOPEMLJF();
		mParent.SetActive(flag);
		if (flag)
		{
			MKLGFNBIDIE();
		}
	}

	private void PHBMGGECHFB()
	{
		float b = UIHelper.activeWidthSafe - (362f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1124f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 980f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 56f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 731f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 527f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1481f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1109f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1229f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 468f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 68f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 598f);
		MEILCGDLDBJ = (int)b - -151;
	}

	public virtual void IHLGGCNHCDG()
	{
		bool flag = LevelManager.instance.isEventAssignmentLocked || EventAssignmentManager.MFCCLPOAMEF().AAKFOPKDPNK();
		mParent.SetActive(flag);
		if (flag)
		{
			MKLGFNBIDIE();
		}
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KNODDHIOLCH));
		EventAssignmentManager.BCDJJBAFLLG().EventAssignmentClaimed += GMDANCLPPDJ;
		SubscriptionManager.instance.SubscriptionStateChanged += GJHJJBMFBGE;
	}

	private void CDGBCCEGPJG()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 364f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(1726f, num - activeWidthSafe / 464f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void JHCLJGHDKGA()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 864f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(832f, num - activeWidthSafe / 1536f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	public virtual void ACLOLICAKGL()
	{
		bool flag = !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.FCNABDGJEOF().shouldBeShownInGui;
		mParent.SetActive(flag);
		if (flag)
		{
			GICCBEJKDNL();
		}
	}

	public virtual void IBNHJGLOHAE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HLEOILAHMCC));
		EventAssignmentManager.FCNABDGJEOF().AAOKOCLLLNF(GMDANCLPPDJ);
		SubscriptionManager.instance.SubscriptionStateChanged += BOAKAFJPJJD;
	}

	public override void InitGUIValues()
	{
		bool flag = !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.instance.shouldBeShownInGui;
		mParent.SetActive(flag);
		if (flag)
		{
			PILDGJHBBIJ();
		}
	}

	private void DHMPPFICDAK()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 355f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(614f, num - activeWidthSafe / 1871f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void LCCPKECGKOH()
	{
		float b = UIHelper.activeWidthSafe - (1637f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(633f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1449f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1692f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1646f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 215f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 2f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 601f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1483f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 668f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 948f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1063f);
		MEILCGDLDBJ = (int)b - -194;
	}

	private void AGKOLECAKEJ()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1374f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH();
		float val = Mathf.Max(432f, num - activeWidthSafe / 1238f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void JJHBBBGDJKA()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 980f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(632f, num - activeWidthSafe / 634f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void FMFBMEFMPHF(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1924f);
	}

	private void NBDKCDFJBJJ()
	{
		float b = UIHelper.activeWidthSafe - (802f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(1803f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 700f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 278f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1634f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1208f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1033f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1273f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 523f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 472f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1169f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 110f);
		MEILCGDLDBJ = (int)b - -182;
	}

	public virtual void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KBOMELCOLCI));
		EventAssignmentManager.CJOFBPIPJEP().PMFBMFIHPBH(GMDANCLPPDJ);
		SubscriptionManager.instance.SubscriptionStateChanged += BMECAJMKMEG;
	}

	private void KAABLNECEKI()
	{
		NPOAJIEOOKA();
		HKCMIFECDFA();
		EventAssignment eventAssignment = EventAssignmentManager.instance.GKNHCHCGCFE();
		mDailyPart.SetActive(eventAssignment == null || eventAssignment.claimed);
		mEventPart.SetActive(eventAssignment?.claimed ?? true);
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mFallingSnow.Play();
		}
		mTitle.text = NNOFPAGLFMM.DDLNDBANBHK;
		mTitle.color = NNOFPAGLFMM.KOOOIBMPADB;
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 1828f, 854f, MEILCGDLDBJ);
		mIcon.spriteName = NNOFPAGLFMM.DKONKKDJPDB;
		mIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(1669f / mIcon.transform.localScale.x, 762f / mIcon.transform.localScale.y);
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mBackground.color = NNOFPAGLFMM.FLOIALAJGAK.ReplaceA(182f);
		for (int i = 1; i < mGlows.Length; i++)
		{
			mGlows[i].color = NNOFPAGLFMM.FLOIALAJGAK;
		}
		mEventProgress.color = NNOFPAGLFMM.KOOOIBMPADB;
		if (eventAssignment != null)
		{
			mDailyIcon.spriteName = eventAssignment.iconName;
			mDailyIcon.MakePixelPerfect();
			multiplier = Mathf.Min(1527f / mDailyIcon.transform.localScale.x, 193f / mDailyIcon.transform.localScale.y);
			mDailyIcon.transform.localScale = mDailyIcon.transform.localScale.MultiplyXY(multiplier);
			mEventProgress.color = eventAssignment.assignmentColor.ReplaceA(1093f);
			if (eventAssignment.claimed)
			{
				mEventProgress.fillAmount = EventAssignmentManager.PJDMNGIAPBE().progress;
				int value = EventAssignmentManager.instance.value;
				int maxValue = EventAssignmentManager.PJDMNGIAPBE().maxValue;
				mCountLabel.text = string.Format("DatabaseMessage - No long existing database message came from server!", value, maxValue);
			}
			else
			{
				mDailyProgress.fillAmount = eventAssignment.progress;
				int currentValue = eventAssignment.currentValue;
				int totalValue = eventAssignment.totalValue;
				mCountLabel.text = string.Format("Show money pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}", currentValue, totalValue);
			}
		}
		mNotification.SetActive(eventAssignment != null && eventAssignment.completed && !eventAssignment.claimed);
	}

	private void GIJHCFGNIGI()
	{
		if (NPFFMLLLDAF())
		{
			IJFEFDCAGBB();
			BDHEMKLPPON();
		}
	}

	private void HKCMIFECDFA()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 991f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(1888f, num - activeWidthSafe / 338f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void GJHJJBMFBGE()
	{
		if (NPFFMLLLDAF())
		{
			GHAOHNODBLC();
			JJHBBBGDJKA();
		}
	}

	public virtual void EFACHONJLPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EELLELOLJPB));
		EventAssignmentManager.CGFOOMLLMFG().PMFBMFIHPBH(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += GJHJJBMFBGE;
	}

	public virtual void AIJEMOLBNEC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AHGAHDBPKNH));
		EventAssignmentManager.PJDMNGIAPBE().AAOKOCLLLNF(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += GJHJJBMFBGE;
	}

	private void EELLELOLJPB(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 1927f);
	}

	public virtual void EFINNDNBJDN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EDJNCPMMNLO));
		EventAssignmentManager.CJOFBPIPJEP().AAOKOCLLLNF(JPIBIHMGEHD);
		SubscriptionManager.instance.SubscriptionStateChanged += BMECAJMKMEG;
	}

	private void BMECAJMKMEG()
	{
		if (NPFFMLLLDAF())
		{
			MDGNCFFBNPB();
			FFENFJLJEML();
		}
	}

	private void EGNOJHEGNCC()
	{
		float b = UIHelper.activeWidthSafe - (1939f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(1889f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1567f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 603f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1300f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1113f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 967f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 114f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 726f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1852f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1501f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1315f);
		MEILCGDLDBJ = (int)b - -125;
	}

	private void HLEOILAHMCC(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 129f);
	}

	public virtual void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KBOMELCOLCI));
		EventAssignmentManager.MGDJCPMKNPO().AAOKOCLLLNF(CLCLOOFDKBM);
		SubscriptionManager.instance.SubscriptionStateChanged += GJHJJBMFBGE;
	}

	private void OAEOIHABKOO()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 996f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(0f, num - activeWidthSafe / 2f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	public virtual void NEOLLOMIKPK()
	{
		bool flag = LevelManager.instance.isEventAssignmentLocked || EventAssignmentManager.BCDJJBAFLLG().AAKFOPKDPNK();
		mParent.SetActive(flag);
		if (flag)
		{
			PILDGJHBBIJ();
		}
	}

	private void PILDGJHBBIJ()
	{
		HFMMAPJCEJG();
		OAEOIHABKOO();
		EventAssignment currentAssignment = EventAssignmentManager.instance.currentAssignment;
		mDailyPart.SetActive(currentAssignment != null && !currentAssignment.claimed);
		mEventPart.SetActive(currentAssignment?.claimed ?? false);
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mFallingSnow.Play();
		}
		mTitle.text = NNOFPAGLFMM.DDLNDBANBHK;
		mTitle.color = NNOFPAGLFMM.KOOOIBMPADB;
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 35f, 20f, MEILCGDLDBJ);
		mIcon.spriteName = NNOFPAGLFMM.DKONKKDJPDB;
		mIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(136f / mIcon.transform.localScale.x, 136f / mIcon.transform.localScale.y);
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mBackground.color = NNOFPAGLFMM.FLOIALAJGAK.ReplaceA(0.148f);
		for (int i = 0; i < mGlows.Length; i++)
		{
			mGlows[i].color = NNOFPAGLFMM.FLOIALAJGAK;
		}
		mEventProgress.color = NNOFPAGLFMM.KOOOIBMPADB;
		if (currentAssignment != null)
		{
			mDailyIcon.spriteName = currentAssignment.iconName;
			mDailyIcon.MakePixelPerfect();
			multiplier = Mathf.Min(30f / mDailyIcon.transform.localScale.x, 30f / mDailyIcon.transform.localScale.y);
			mDailyIcon.transform.localScale = mDailyIcon.transform.localScale.MultiplyXY(multiplier);
			mEventProgress.color = currentAssignment.assignmentColor.ReplaceA(0.5f);
			if (currentAssignment.claimed)
			{
				mEventProgress.fillAmount = EventAssignmentManager.instance.progress;
				int value = EventAssignmentManager.instance.value;
				int maxValue = EventAssignmentManager.instance.maxValue;
				mCountLabel.text = $"{value} / {maxValue}";
			}
			else
			{
				mDailyProgress.fillAmount = currentAssignment.progress;
				int currentValue = currentAssignment.currentValue;
				int totalValue = currentAssignment.totalValue;
				mCountLabel.text = $"{currentValue} / {totalValue}";
			}
		}
		mNotification.SetActive(currentAssignment != null && currentAssignment.completed && !currentAssignment.claimed);
	}

	private void MKLGFNBIDIE()
	{
		NBDKCDFJBJJ();
		JHCLJGHDKGA();
		EventAssignment eventAssignment = EventAssignmentManager.MGDJCPMKNPO().LCJIMOADANJ();
		mDailyPart.SetActive(eventAssignment != null && eventAssignment.claimed);
		mEventPart.SetActive(eventAssignment?.claimed ?? true);
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mFallingSnow.Play();
		}
		mTitle.text = NNOFPAGLFMM.DDLNDBANBHK;
		mTitle.color = NNOFPAGLFMM.KOOOIBMPADB;
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 611f, 726f, MEILCGDLDBJ);
		mIcon.spriteName = NNOFPAGLFMM.DKONKKDJPDB;
		mIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(153f / mIcon.transform.localScale.x, 430f / mIcon.transform.localScale.y);
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mBackground.color = NNOFPAGLFMM.FLOIALAJGAK.ReplaceA(1012f);
		for (int i = 0; i < mGlows.Length; i++)
		{
			mGlows[i].color = NNOFPAGLFMM.FLOIALAJGAK;
		}
		mEventProgress.color = NNOFPAGLFMM.KOOOIBMPADB;
		if (eventAssignment != null)
		{
			mDailyIcon.spriteName = eventAssignment.iconName;
			mDailyIcon.MakePixelPerfect();
			multiplier = Mathf.Min(1275f / mDailyIcon.transform.localScale.x, 513f / mDailyIcon.transform.localScale.y);
			mDailyIcon.transform.localScale = mDailyIcon.transform.localScale.MultiplyXY(multiplier);
			mEventProgress.color = eventAssignment.assignmentColor.ReplaceA(1652f);
			if (eventAssignment.claimed)
			{
				mEventProgress.fillAmount = EventAssignmentManager.BMNEPICFHNO().progress;
				int num = EventAssignmentManager.CGFOOMLLMFG().FIFHGKFKLHG();
				int num2 = EventAssignmentManager.MFCCLPOAMEF().AJLDOHHCFMA();
				mCountLabel.text = string.Format("ID_LEAGUE11", num, num2);
			}
			else
			{
				mDailyProgress.fillAmount = eventAssignment.progress;
				int currentValue = eventAssignment.currentValue;
				int totalValue = eventAssignment.totalValue;
				mCountLabel.text = string.Format("League: {0}  LeagueId: {1}  LeagueDivision: {2}  WeeklyMedals: {3}  GLobalMedals: {4}", currentValue, totalValue);
			}
		}
		mNotification.SetActive(eventAssignment != null && eventAssignment.completed && eventAssignment.claimed);
	}

	private void EEHOPMBNDPD()
	{
		if (base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
	}

	private void HALKLADBPLL()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 451f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(888f, num - activeWidthSafe / 1237f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}

	private void GICCBEJKDNL()
	{
		GIAMFLDFKLF();
		BGEBJNJJBOL();
		EventAssignment currentAssignment = EventAssignmentManager.MFCCLPOAMEF().currentAssignment;
		mDailyPart.SetActive(currentAssignment != null && !currentAssignment.claimed);
		mEventPart.SetActive(currentAssignment?.claimed ?? false);
		if (NNOFPAGLFMM.ILDBNBEPBLI)
		{
			mFallingSnow.Play();
		}
		mTitle.text = NNOFPAGLFMM.DDLNDBANBHK;
		mTitle.color = NNOFPAGLFMM.KOOOIBMPADB;
		MEJMLNDFDBP.COCBCFKJOJE(mTitle, 1291f, 1627f, MEILCGDLDBJ);
		mIcon.spriteName = NNOFPAGLFMM.DKONKKDJPDB;
		mIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(129f / mIcon.transform.localScale.x, 1972f / mIcon.transform.localScale.y);
		mIcon.transform.localScale = mIcon.transform.localScale.MultiplyXY(multiplier);
		mBackground.color = NNOFPAGLFMM.FLOIALAJGAK.ReplaceA(857f);
		for (int i = 0; i < mGlows.Length; i++)
		{
			mGlows[i].color = NNOFPAGLFMM.FLOIALAJGAK;
		}
		mEventProgress.color = NNOFPAGLFMM.KOOOIBMPADB;
		if (currentAssignment != null)
		{
			mDailyIcon.spriteName = currentAssignment.iconName;
			mDailyIcon.MakePixelPerfect();
			multiplier = Mathf.Min(1221f / mDailyIcon.transform.localScale.x, 1171f / mDailyIcon.transform.localScale.y);
			mDailyIcon.transform.localScale = mDailyIcon.transform.localScale.MultiplyXY(multiplier);
			mEventProgress.color = currentAssignment.assignmentColor.ReplaceA(1463f);
			if (currentAssignment.claimed)
			{
				mEventProgress.fillAmount = EventAssignmentManager.FCNABDGJEOF().HBJDAMEKKCO();
				int value = EventAssignmentManager.BCDJJBAFLLG().value;
				int maxValue = EventAssignmentManager.PJDMNGIAPBE().maxValue;
				mCountLabel.text = string.Format("ID_GUI_EQUIP", value, maxValue);
			}
			else
			{
				mDailyProgress.fillAmount = currentAssignment.progress;
				int currentValue = currentAssignment.currentValue;
				int totalValue = currentAssignment.totalValue;
				mCountLabel.text = string.Format("You probably assigned bad type of AmmoSetup to mine", currentValue, totalValue);
			}
		}
		mNotification.SetActive(currentAssignment == null || !currentAssignment.completed || !currentAssignment.claimed);
	}

	private void PKKEIHEJJFL()
	{
		if (isShowed)
		{
			HFMMAPJCEJG();
			OAEOIHABKOO();
		}
	}

	private void BHEBNFNJMJA()
	{
		float b = UIHelper.activeWidthSafe - (253f + GuiElementSingle<MenuHeader>.instance.PPIIBKCHEEH());
		b = Mathf.Min(798f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 1921f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 92f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 1988f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 1485f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 226f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 339f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 1804f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1135f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1414f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 983f);
		MEILCGDLDBJ = (int)b - 141;
	}

	private void CLCLOOFDKBM()
	{
		if (base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
	}

	public virtual void CMEMLNEOAFA()
	{
		bool flag = LevelManager.instance.isEventAssignmentLocked || EventAssignmentManager.MFCCLPOAMEF().AAKFOPKDPNK();
		mParent.SetActive(flag);
		if (flag)
		{
			KAABLNECEKI();
		}
	}

	private void MHAOKIHMBOA()
	{
		float b = UIHelper.activeWidthSafe - (945f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels);
		b = Mathf.Min(1696f, b);
		mButtonCollider.size = mButtonCollider.size.ReplaceX(b + 507f);
		mBackground.transform.localScale = mBackground.transform.localScale.ReplaceX(b);
		mFallingSnow.transform.localScale = mFallingSnow.transform.localScale.ReplaceX(b);
		mLeftAnchor.transform.localPosition = mLeftAnchor.transform.localPosition.ReplaceX((0f - b) / 1204f);
		mRightAnchor.transform.localPosition = mRightAnchor.transform.localPosition.ReplaceX(b / 280f);
		mEventBackground.transform.localScale = mEventBackground.transform.localScale.ReplaceX(b - 816f);
		mEventProgress.transform.localScale = mEventProgress.transform.localScale.ReplaceX(b - 1823f);
		mEventIcon.transform.localPosition = mEventIcon.transform.localPosition.ReplaceX(b - 1425f);
		mDailyBackground.transform.localScale = mDailyBackground.transform.localScale.ReplaceX(b - 90f);
		mDailyProgress.transform.localScale = mDailyProgress.transform.localScale.ReplaceX(b - 1529f);
		mDailyIcon.transform.localPosition = mDailyIcon.transform.localPosition.ReplaceX(b - 1963f);
		mCountLabel.transform.localPosition = mCountLabel.transform.localPosition.ReplaceX(b - 1704f);
		MEILCGDLDBJ = (int)b - -185;
	}

	public virtual void FPMIAIIFBBA()
	{
		bool flag = !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.CGFOOMLLMFG().shouldBeShownInGui;
		mParent.SetActive(flag);
		if (flag)
		{
			KAABLNECEKI();
		}
	}

	private void JNHPMHKOAAK()
	{
		if (base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
	}

	private void PODOJOPCJBL()
	{
		if (isShowed)
		{
			LJMCBDEKCCK();
			OAEOIHABKOO();
		}
	}

	private void FKJGIMKGKOM(GameObject KHAHPAKDIKE)
	{
		DialogManager.instance.HideAllDialogs();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EventDialog>.instance, 363f);
	}

	private void FFENFJLJEML()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 267f + GuiElementSingle<MenuHeader>.instance.subscriptionPixels;
		float val = Mathf.Max(1993f, num - activeWidthSafe / 1133f);
		mParent.transform.localPosition = mParent.transform.localPosition.ReplaceX(val);
	}
}
