using System;
using UnityEngine;

public class ArenaWonDialog : GuiElementSingle<ArenaWonDialog>, PAIIOKBBHBC
{
	[Header("Core")]
	[SerializeField]
	private UILabel mMiddleText;

	[SerializeField]
	private GameObject mBottomButton;

	private bool PJBONGKMOCK;

	private int JOFAMPIFPIF;

	public virtual void OFCCACPEBHD()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "9 VIP REMINDER\tIs vip {0}" : "RematchRPC");
		object[] array = new object[0];
		array[0] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void IGNIFKBCDKK()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "{0}\t\tPivot: {1}\n" : "Squad");
		object[] array = new object[1];
		array[1] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public void KANMLANBLBL(bool KIPFDADMMHL, int OOJLAJLBCPB)
	{
		PJBONGKMOCK = KIPFDADMMHL;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 562f);
	}

	public virtual void LMNNNHJKMFP()
	{
		mMiddleText.text = Localization.LocalizeFormat((!PJBONGKMOCK) ? "ID_OFFLINE" : "_MatCap", JOFAMPIFPIF);
	}

	public virtual void MHIFDHGPDCK()
	{
		mMiddleText.text = Localization.LocalizeFormat((!PJBONGKMOCK) ? "^\\D*" : "126 MENU BATTLE SCREEN SHOWN", JOFAMPIFPIF);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void CKJCFLGKPOA(bool KIPFDADMMHL, int OOJLAJLBCPB)
	{
		PJBONGKMOCK = KIPFDADMMHL;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this, 1910f);
	}

	public virtual void OKMMGFMKJGG()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "ID_PENDING" : "ID_OK");
		object[] array = new object[0];
		array[0] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	private void DENOGDBNCAE(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			if (GuiScreenSingle<ArenaScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<ArenaScreen>.instance.AGDPJKHOABP(ArenaScreen.BGMNNKDJBEK.MainArena);
				GuiScreenSingle<ArenaScreen>.instance.FAHNGBDJEBF();
			}
			HideDialog();
		}
	}

	public void ShowDialog(bool KIPFDADMMHL, int OOJLAJLBCPB)
	{
		PJBONGKMOCK = KIPFDADMMHL;
		JOFAMPIFPIF = OOJLAJLBCPB;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void PAHEFBCOENP()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "facebookMedals" : "PA: gold spent ");
		object[] array = new object[0];
		array[0] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void JCGDALOBGHO()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "Button \"{0}\" has no assigned box collider." : "VIPMemeberShipAlmostEnded");
		object[] array = new object[1];
		array[1] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	private void KMMLKPGACNA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.NFIFFEFEJGC(ArenaScreen.BGMNNKDJBEK.EnterArena);
				GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			}
			HideDialog();
		}
	}

	public virtual void OBNCKIBJOGJ()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "S" : "Beanstalk: Internet Offline while checking connection: ");
		object[] array = new object[0];
		array[1] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mBottomButton);
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FCEDMOAEKOB));
	}

	private void LKDAOKDEDPN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			if (GuiScreenSingle<ArenaScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<ArenaScreen>.instance.NDDMBLOFHFG(ArenaScreen.BGMNNKDJBEK.MainArena);
				GuiScreenSingle<ArenaScreen>.instance.NBDAJABPIJG();
			}
			HideDialog();
		}
	}

	private void FCEDMOAEKOB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.AGDPJKHOABP(ArenaScreen.BGMNNKDJBEK.MainArena);
				GuiScreenSingle<ArenaScreen>.instance.NBDAJABPIJG();
			}
			HideDialog();
		}
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KMMLKPGACNA));
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
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

	private void CFKMKONHEHE(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
			{
				GuiScreenSingle<ArenaScreen>.instance.AILAMGFKBNL(ArenaScreen.BGMNNKDJBEK.EnterArena);
				GuiScreenSingle<ArenaScreen>.instance.IICLLKGJJDE();
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		mMiddleText.text = Localization.LocalizeFormat((!PJBONGKMOCK) ? "ID_ARENAWONXWINSTEXT" : "ID_ARENAWONFLAWLESSLYTEXT", JOFAMPIFPIF);
	}

	public virtual void NINGMLNMLLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mBottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FCEDMOAEKOB));
	}

	public GuiElement LFCHFGHMIGD()
	{
		return this;
	}

	public GuiElement DDMIEFJMHJN()
	{
		return this;
	}

	public virtual void BFLHENDLPLK()
	{
		UILabel uILabel = mMiddleText;
		string keyFormat = ((!PJBONGKMOCK) ? "ID_BRONZEPACK" : "country-netherlands");
		object[] array = new object[0];
		array[1] = JOFAMPIFPIF;
		uILabel.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}
}
