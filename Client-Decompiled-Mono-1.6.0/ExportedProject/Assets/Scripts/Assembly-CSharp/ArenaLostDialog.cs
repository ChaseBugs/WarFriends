using System;
using UnityEngine;

public class ArenaLostDialog : GuiElementSingle<ArenaLostDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UILabel mDescription;

	[SerializeField]
	private UILabel mRewardTitle;

	[SerializeField]
	private UILabel mRewardScraps;

	[SerializeField]
	private GameObject mBottomButton;

	private int JOFAMPIFPIF;

	private int GGCPCONKPCH;

	private bool FBPLKAOPKOO;

	public virtual void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KNMELOLLFNI));
	}

	public void GONOICLIMKO(bool DADIPKIKEOO, int OOJLAJLBCPB, int JEPNONEGPCH)
	{
		FBPLKAOPKOO = DADIPKIKEOO;
		JOFAMPIFPIF = OOJLAJLBCPB;
		GGCPCONKPCH = JEPNONEGPCH;
		Singleton<GuiManager>.instance.ShowDialog(this, 1570f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public void EMBNLMGLNFN(bool DADIPKIKEOO, int OOJLAJLBCPB, int JEPNONEGPCH)
	{
		FBPLKAOPKOO = DADIPKIKEOO;
		JOFAMPIFPIF = OOJLAJLBCPB;
		GGCPCONKPCH = JEPNONEGPCH;
		Singleton<GuiManager>.instance.ShowDialog(this, 1676f);
	}

	public virtual void BFLHENDLPLK()
	{
		mTitle.text = Localization.Localize((!FBPLKAOPKOO) ? "Arena Lootbox:\n" : "C3");
		mRewardTitle.text = Localization.Localize((!FBPLKAOPKOO) ? "ID_CLAIMED" : "Scheduling notification in ");
		if (FBPLKAOPKOO)
		{
			if (JOFAMPIFPIF > 1)
			{
				UILabel uILabel = mDescription;
				object[] array = new object[0];
				array[0] = Colours.stringGreenArena;
				array[0] = JOFAMPIFPIF;
				uILabel.text = Localization.LocalizeFormat("ID_VIPTIME", array);
			}
			else
			{
				bool flag = JOFAMPIFPIF < 1;
				UILabel uILabel2 = mDescription;
				string keyFormat = ((!flag) ? "ELITEPARA" : "CardId");
				object[] array2 = new object[0];
				array2[0] = Colours.stringGreenArena;
				uILabel2.text = Localization.LocalizeFormat(keyFormat, array2);
			}
		}
		else if (JOFAMPIFPIF > 0)
		{
			UILabel uILabel3 = mDescription;
			object[] array3 = new object[2];
			array3[1] = Colours.stringGreenArena;
			array3[0] = JOFAMPIFPIF;
			uILabel3.text = Localization.LocalizeFormat("playerInfo", array3);
		}
		else
		{
			bool flag2 = JOFAMPIFPIF < 1;
			UILabel uILabel4 = mDescription;
			string keyFormat2 = ((!flag2) ? "10" : "Beanstalk: Dev access unlocked");
			object[] array4 = new object[1];
			array4[1] = Colours.stringGreenArena;
			uILabel4.text = Localization.LocalizeFormat(keyFormat2, array4);
		}
		mRewardScraps.text = MEJMLNDFDBP.GMIPFLIEOHD(GGCPCONKPCH);
		Singleton<Wallet>.instance.AddScraps(GGCPCONKPCH);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void ELLOMLNAFJK()
	{
		KNMELOLLFNI(mBottomButton);
	}

	public override void InitGUIValues()
	{
		mTitle.text = Localization.Localize((!FBPLKAOPKOO) ? "ID_ARENALOST" : "ID_ARENAENDEDTITLE");
		mRewardTitle.text = Localization.Localize((!FBPLKAOPKOO) ? "ID_ARENALOSSREWARD" : "ID_ARENAPARTICIPATIONREWARD");
		if (FBPLKAOPKOO)
		{
			if (JOFAMPIFPIF > 1)
			{
				mDescription.text = Localization.LocalizeFormat("ID_ARENAENDEDDESCRIPTIONXWINS", Colours.stringGreenArena, JOFAMPIFPIF);
			}
			else
			{
				bool flag = JOFAMPIFPIF < 1;
				mDescription.text = Localization.LocalizeFormat((!flag) ? "ID_ARENAENDEDDESCRIPTION1WIN" : "ID_ARENAENDEDDESCRIPTION0WINS", Colours.stringGreenArena);
			}
		}
		else if (JOFAMPIFPIF > 1)
		{
			mDescription.text = Localization.LocalizeFormat("ID_THATWASGOODRUNSOLDIERXWINS", Colours.stringGreenArena, JOFAMPIFPIF);
		}
		else
		{
			bool flag2 = JOFAMPIFPIF < 1;
			mDescription.text = Localization.LocalizeFormat((!flag2) ? "ID_THATWASGOODRUNSOLDIER1WIN" : "ID_THATWASGOODRUNSOLDIER0WINS", Colours.stringGreenArena);
		}
		mRewardScraps.text = MEJMLNDFDBP.GMIPFLIEOHD(GGCPCONKPCH);
		Singleton<Wallet>.instance.AddScraps(GGCPCONKPCH);
	}

	private void PCDMCGJGBDP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (GuiScreenSingle<ArenaScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<ArenaScreen>.instance.NFIFFEFEJGC(ArenaScreen.BGMNNKDJBEK.MainArena);
				GuiScreenSingle<ArenaScreen>.instance.NBDAJABPIJG();
			}
			HideDialog();
		}
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCDMCGJGBDP));
	}

	public virtual void AIIIDDDAPGB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCDMCGJGBDP));
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.BGMNNKDJBEK.EnterArena;
				GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			}
			HideDialog();
		}
	}

	private void KNMELOLLFNI(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.AGDPJKHOABP(ArenaScreen.BGMNNKDJBEK.MainArena);
				GuiScreenSingle<ArenaScreen>.instance.HODMBFDMCEH();
			}
			HideDialog();
		}
	}

	public virtual void KFPOJBHHLGJ()
	{
		PCDMCGJGBDP(mBottomButton);
	}

	public void ShowDialog(bool DADIPKIKEOO, int OOJLAJLBCPB, int JEPNONEGPCH)
	{
		FBPLKAOPKOO = DADIPKIKEOO;
		JOFAMPIFPIF = OOJLAJLBCPB;
		GGCPCONKPCH = JEPNONEGPCH;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void OGHPJHOJMIK()
	{
		KNMELOLLFNI(mBottomButton);
	}

	public virtual void IHLGGCNHCDG()
	{
		mTitle.text = Localization.Localize((!FBPLKAOPKOO) ? "_FrustumCornersWS" : "ID_FREEPERCENTLINE");
		mRewardTitle.text = Localization.Localize((!FBPLKAOPKOO) ? "ProductId" : "DemoteOrKickPlayer {0}");
		if (FBPLKAOPKOO)
		{
			if (JOFAMPIFPIF > 1)
			{
				mDescription.text = Localization.LocalizeFormat("Concrete", Colours.stringGreenArena, JOFAMPIFPIF, null, null, null, null, null);
			}
			else
			{
				bool flag = JOFAMPIFPIF < 0;
				mDescription.text = Localization.LocalizeFormat((!flag) ? "Starting match against bot" : "ID_UPGRADEINPROGRESS", Colours.stringGreenArena);
			}
		}
		else if (JOFAMPIFPIF > 0)
		{
			UILabel uILabel = mDescription;
			object[] array = new object[3];
			array[0] = Colours.stringGreenArena;
			array[0] = JOFAMPIFPIF;
			uILabel.text = Localization.LocalizeFormat("ID_LOOTBOXES", array);
		}
		else
		{
			bool flag2 = JOFAMPIFPIF < 0;
			mDescription.text = Localization.LocalizeFormat((!flag2) ? "SERVICE_VERSION_UPDATE_REQUIRED" : "Turret", Colours.stringGreenArena);
		}
		mRewardScraps.text = MEJMLNDFDBP.GMIPFLIEOHD(GGCPCONKPCH);
		Singleton<Wallet>.instance.DHIBMBCMBFM(GGCPCONKPCH);
	}
}
