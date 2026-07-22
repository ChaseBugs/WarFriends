using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NotEnoughDialog : GuiElementSingle<NotEnoughDialog>, PAIIOKBBHBC
{
	public enum NKHJBLBAAEB
	{
		BUY,
		UPGRADE,
		TRAIN,
		DELIVER,
		UPGRADESPECIAL,
		TRAINSPECIAL,
		DELIVERSPECIAL,
		TRAINELITE,
		UPGRADEELITE
	}

	[Header("Content")]
	[FormerlySerializedAs("HKAELKNPPGD")]
	public UILabel NFNLBEGFLHC;

	[FormerlySerializedAs("PCBFLAPENLF")]
	public UILabel JPCIACBHGHO;

	[FormerlySerializedAs("CIFLIEOJKDC")]
	public GameObject FPMJEDOCJKE;

	[FormerlySerializedAs("PHCJGGDIPIN")]
	public GameObject HAFMGCFMCPC;

	[Header("Buttons")]
	[FormerlySerializedAs("NMJCMEPOLON")]
	public UILabel GMBJHOCENGD;

	[FormerlySerializedAs("KFDGCCABNPH")]
	public UIButton ECHEJLCMOBL;

	[FormerlySerializedAs("JGGBNHLGBNA")]
	public UIButton ELOEEKANPJN;

	private bool GBKLFKHMFCP;

	private int HEMNGHAAOCC;

	private string ICPIMPHAELG;

	private NKHJBLBAAEB MBCCLBJKAOJ;

	private static Dictionary<NKHJBLBAAEB, string> NGPEHFDMMOE = new Dictionary<NKHJBLBAAEB, string>
	{
		{
			NKHJBLBAAEB.BUY,
			"ID_YOUNEEDMONEYTOBUY"
		},
		{
			NKHJBLBAAEB.UPGRADE,
			"ID_YOUNEEDMONEYTOUPGRADE"
		},
		{
			NKHJBLBAAEB.TRAIN,
			"ID_YOUNEEDMONEYTOTRAIN"
		},
		{
			NKHJBLBAAEB.DELIVER,
			"ID_YOUNEEDMONEYTODELIVER"
		},
		{
			NKHJBLBAAEB.UPGRADESPECIAL,
			"ID_YOUNEEDMONEYTOUPGRADESPECIAL"
		},
		{
			NKHJBLBAAEB.TRAINSPECIAL,
			"ID_YOUNEEDMONEYTOTRAINSPECIAL"
		},
		{
			NKHJBLBAAEB.DELIVERSPECIAL,
			"ID_YOUNEEDMONEYTODELIVERSPECIAL"
		},
		{
			NKHJBLBAAEB.TRAINELITE,
			"ID_YOUNEEDMONEYTOTRAINELITE"
		},
		{
			NKHJBLBAAEB.UPGRADEELITE,
			"ID_YOUNEEDMONEYTOUPGRADEELITE"
		}
	};

	public void FMGBDPKKKOO(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = false;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1684f);
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEKOKFIFMME));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOPMADNKCGP));
	}

	private void AOIINFHNCAB(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiElementSingle<InappScreen>.instance.EAMKLECMCNE(string.Empty);
			HideDialog();
		}
	}

	public virtual void CNOLAKPOBIF()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = string.Empty;
			HideDialog();
		}
	}

	public virtual void CEAHALCLDNE()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
	}

	public virtual void EJNKFOFOJFL()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
	}

	public virtual void OELJPIDHHPA()
	{
		base.MOJBHFPBAPP();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
	}

	public override void InitGUIValues()
	{
		FPMJEDOCJKE.SetActive(GBKLFKHMFCP);
		HAFMGCFMCPC.SetActive(!GBKLFKHMFCP);
		NFNLBEGFLHC.text = Localization.Localize((!GBKLFKHMFCP) ? "ID_NOTENOUGHGOLD" : "ID_NOTENOUGHWARBUCKS");
		MEJMLNDFDBP.COCBCFKJOJE(NFNLBEGFLHC, 74f, 50f, 1180);
		GMBJHOCENGD.text = Localization.Localize((!GBKLFKHMFCP) ? "ID_GETSOMEGOLD" : "ID_GETSOMEWARBUCKS");
		JPCIACBHGHO.text = Localization.LocalizeFormat(NGPEHFDMMOE[MBCCLBJKAOJ], (!GBKLFKHMFCP) ? Colours.stringGoldOld : Colours.stringGreenWarbucks, MEJMLNDFDBP.GMIPFLIEOHD(HEMNGHAAOCC), Localization.Localize((!GBKLFKHMFCP) ? "ID_GOLD" : "ID_WARBUCKS").ToUpperInvariant(), Colours.stringWhite, Colours.stringBlue, ICPIMPHAELG);
	}

	public void ShowWarbucks(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = true;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void CCIIBAIKMFK()
	{
		base.JNBMCODJHBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KBOAHNAEGED));
	}

	private void AOPMADNKCGP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (GBKLFKHMFCP)
			{
				GuiElementSingle<InappScreen>.instance.HALPNIBGNDJ();
			}
			else
			{
				GuiElementSingle<InappScreen>.instance.DICJBHOKGCF();
			}
		}
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	public virtual void HPEGGHAIPDI()
	{
		FPMJEDOCJKE.SetActive(GBKLFKHMFCP);
		HAFMGCFMCPC.SetActive(!GBKLFKHMFCP);
		NFNLBEGFLHC.text = Localization.Localize((!GBKLFKHMFCP) ? "engineer_repair" : "ID_INTIME");
		MEJMLNDFDBP.COCBCFKJOJE(NFNLBEGFLHC, 1132f, 1089f, 135);
		GMBJHOCENGD.text = Localization.Localize((!GBKLFKHMFCP) ? "ID_CONFIRM_ERROR" : "ID_STAT_MOSTWARCARDSPLAYED");
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		string keyFormat = NGPEHFDMMOE[MBCCLBJKAOJ];
		object[] array = new object[6];
		array[1] = ((!GBKLFKHMFCP) ? Colours.stringGoldOld : Colours.stringGreenWarbucks);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(HEMNGHAAOCC);
		array[8] = Localization.Localize((!GBKLFKHMFCP) ? "N" : "menu-close").ToUpperInvariant();
		array[5] = Colours.stringWhite;
		array[2] = Colours.stringBlue;
		array[3] = ICPIMPHAELG;
		jPCIACBHGHO.text = Localization.LocalizeFormat(keyFormat, array);
	}

	private void LFJIEIJBJCB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (GBKLFKHMFCP)
			{
				GuiElementSingle<InappScreen>.instance.ShowWarshopWarbucks();
			}
			else
			{
				GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
			}
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void EIPCLGCNKGO()
	{
		KPHHBHIMPLH(ECHEJLCMOBL.gameObject);
	}

	public GuiElement JMNCLNNCGGF()
	{
		return this;
	}

	private void KPHHBHIMPLH(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC(string.Empty);
			HideDialog();
		}
	}

	public virtual void GEKFHJKIAMF()
	{
		AOIINFHNCAB(ECHEJLCMOBL.gameObject);
	}

	public virtual void ILCKGHGDDJA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOIINFHNCAB));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFJIEIJBJCB));
	}

	public GuiElement HDGJKEDKNDL()
	{
		return this;
	}

	public void BJGHHINCCKL(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = true;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1290f);
	}

	public virtual void AOHECFLIJGP()
	{
		base.NEEAKMELPBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEKOKFIFMME));
	}

	public override void AIKPJGLHLLO()
	{
		KBOAHNAEGED(ECHEJLCMOBL.gameObject);
	}

	public virtual void CKGGNJACIGL()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	public virtual void BNPDALDLFFM()
	{
		FPMJEDOCJKE.SetActive(GBKLFKHMFCP);
		HAFMGCFMCPC.SetActive(GBKLFKHMFCP);
		NFNLBEGFLHC.text = Localization.Localize((!GBKLFKHMFCP) ? "TW" : "Concrete");
		MEJMLNDFDBP.COCBCFKJOJE(NFNLBEGFLHC, 1634f, 1860f, 186);
		GMBJHOCENGD.text = Localization.Localize((!GBKLFKHMFCP) ? "error in count of army" : "LootboxType");
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		string keyFormat = NGPEHFDMMOE[MBCCLBJKAOJ];
		object[] array = new object[2];
		array[0] = ((!GBKLFKHMFCP) ? Colours.stringGoldOld : Colours.stringGreenWarbucks);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(HEMNGHAAOCC);
		array[2] = Localization.Localize((!GBKLFKHMFCP) ? "special" : "Position").ToUpperInvariant();
		array[4] = Colours.stringWhite;
		array[6] = Colours.stringBlue;
		array[0] = ICPIMPHAELG;
		jPCIACBHGHO.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void FNNHJPMKDOM()
	{
		AOIINFHNCAB(ECHEJLCMOBL.gameObject);
	}

	public void IHMAHMMJGBH(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = true;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 432f);
	}

	private void KBOAHNAEGED(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = string.Empty;
			HideDialog();
		}
	}

	public GuiElement JPJGHDKECMA()
	{
		return this;
	}

	public virtual void GLNGJDCCDCB()
	{
		base.NEEAKMELPBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
	}

	public virtual void KIBFFDMMIJB()
	{
		base.JNBMCODJHBJ();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEKOKFIFMME));
	}

	public virtual void HEEANEFGCCJ()
	{
		FPMJEDOCJKE.SetActive(GBKLFKHMFCP);
		HAFMGCFMCPC.SetActive(GBKLFKHMFCP);
		NFNLBEGFLHC.text = Localization.Localize((!GBKLFKHMFCP) ? "LeagueEvaluation" : "CARDS_MIN");
		MEJMLNDFDBP.COCBCFKJOJE(NFNLBEGFLHC, 712f, 1594f, -56);
		GMBJHOCENGD.text = Localization.Localize((!GBKLFKHMFCP) ? "Received old game invite ( > {0} seconds). Not showing dialog. Opponent = {1}" : "ROTATED!!! ");
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		string keyFormat = NGPEHFDMMOE[MBCCLBJKAOJ];
		object[] array = new object[3];
		array[1] = ((!GBKLFKHMFCP) ? Colours.stringGoldOld : Colours.stringGreenWarbucks);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(HEMNGHAAOCC);
		array[1] = Localization.Localize((!GBKLFKHMFCP) ? "NotificationsEnabled" : "ID_WARNING_WRONGARENAID").ToUpperInvariant();
		array[2] = Colours.stringWhite;
		array[5] = Colours.stringBlue;
		array[8] = ICPIMPHAELG;
		jPCIACBHGHO.text = Localization.LocalizeFormat(keyFormat, array);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public void PNIGDOEPLHN(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = true;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 478f);
	}

	public virtual void NHJIGGFEEPP()
	{
		base.MEPKGFFNPAD();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KBOAHNAEGED));
	}

	public virtual void ILHPNHECBJG()
	{
		LEKOKFIFMME(ECHEJLCMOBL.gameObject);
	}

	public virtual void EGNPMLEJLMJ()
	{
		LEKOKFIFMME(ECHEJLCMOBL.gameObject);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JLLNGOIGGAO));
	}

	private void JLLNGOIGGAO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			if (GBKLFKHMFCP)
			{
				GuiElementSingle<InappScreen>.instance.ShowWarshopWarbucks();
			}
			else
			{
				GuiElementSingle<InappScreen>.instance.GNNKBAAGCCL();
			}
		}
	}

	public GuiElement ONHLKGMPKHL()
	{
		return this;
	}

	private void OPIKLCDMJEI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (GBKLFKHMFCP)
			{
				GuiElementSingle<InappScreen>.instance.OPDKKKKLMIB();
			}
			else
			{
				GuiElementSingle<InappScreen>.instance.HBOKBFHOKMP();
			}
		}
	}

	private void KEEKAOKCKMF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (GBKLFKHMFCP)
			{
				GuiElementSingle<InappScreen>.instance.IPINPFLLPKA();
			}
			else
			{
				GuiElementSingle<InappScreen>.instance.GNNKBAAGCCL();
			}
		}
	}

	public virtual void FDGFEMOEMMH()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KBOAHNAEGED));
	}

	private void EAPJHCJLBIA(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = string.Empty;
			HideDialog();
		}
	}

	public GuiElement LHIPJNFMBHL()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ECHEJLCMOBL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFJIEIJBJCB));
	}

	private void LEKOKFIFMME(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH(string.Empty);
			HideDialog();
		}
	}

	public void LOLEHDIPPIF(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = true;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 498f);
	}

	public virtual void EHIAJIMBLCD()
	{
		base.MOOACPIOELI();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
	}

	public GuiElement GFLIHAFEKBK()
	{
		return this;
	}

	public virtual void FNJKJEGAMKB()
	{
		KBOAHNAEGED(ECHEJLCMOBL.gameObject);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(ECHEJLCMOBL.gameObject);
	}

	public void ShowGold(int IDLMJLCFMJG, string LFPFCHIJLML, NKHJBLBAAEB FJLBLLLEELD = NKHJBLBAAEB.BUY)
	{
		GBKLFKHMFCP = false;
		HEMNGHAAOCC = IDLMJLCFMJG;
		ICPIMPHAELG = LFPFCHIJLML;
		MBCCLBJKAOJ = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}
}
