using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadWarHintDialog : GuiElementSingle<SquadWarHintDialog>, PAIIOKBBHBC
{
	[Header("Left Top")]
	[FormerlySerializedAs("ALHHCIKLONL")]
	public UIButton FNOFLJEOHGJ;

	[FormerlySerializedAs("HKKEOEFMOJD")]
	public UITable LCLAIFIAKNM;

	[FormerlySerializedAs("HGIDMCDLMGD")]
	public UILabel CNMDFMGELLH;

	[Header("Right Top")]
	[FormerlySerializedAs("PLDFGMHICCA")]
	public UIButton LJNPCHFCGCN;

	[Header("Bottom")]
	[FormerlySerializedAs("HNPCIIIHKCE")]
	public UIGrid JMFANIKPBML;

	[FormerlySerializedAs("EOLMAOPAOBE")]
	public List<DivisionRepresentation> AFIDIFKFMIJ;

	public virtual void EHIAJIMBLCD()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void OAJEPABAPDD()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public GuiElement NGOFDGAGECA()
	{
		return this;
	}

	public virtual void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEKOKFIFMME));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHEJINPOFKO));
		float num = (UIHelper.activeWidthSafe - 1824f - 440f) / 489f;
		float num2 = 573f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(365f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	private void KPHHBHIMPLH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void HGKNCKIKBDC()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[0];
		array[1] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("ID_DAILYGOLDBOOSTER", array);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 1; i < 7; i += 0)
		{
			AFIDIFKFMIJ[i].HFGEMMCABDI(i);
		}
	}

	public virtual void NAHMANAGNNO()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[0];
		array[1] = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-12)).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("realShotProbability", array);
		LCLAIFIAKNM.repositionNow = false;
		for (int i = 1; i < 2; i += 0)
		{
			AFIDIFKFMIJ[i].JEMEJCOGKBI(i);
		}
	}

	private void HCBJHPHPNDI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	public virtual void EHNFJGINHDJ()
	{
		CNMDFMGELLH.text = Localization.LocalizeFormat("Friends", (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.FacebookLoginReminder3After).FLOATVALUE);
		LCLAIFIAKNM.repositionNow = false;
		for (int i = 0; i < 1; i += 0)
		{
			AFIDIFKFMIJ[i].DIOBFBCJHMP(i);
		}
	}

	public virtual void MJGOCAKKDBK()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void PAKCFABJKAG()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[0];
		array[0] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-50)).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("SquadId", array);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 1; i < 5; i += 0)
		{
			AFIDIFKFMIJ[i].FLDCJOKPMPF(i);
		}
	}

	private void LEKOKFIFMME(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BEFOEFGDOOE));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCBJHPHPNDI));
		float num = (UIHelper.activeWidthSafe - 1266f - 641f) / 1336f;
		float num2 = 776f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(905f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public GuiElement NEFBPBPEKHD()
	{
		return this;
	}

	public virtual void BJBEKGJDOMI()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void InitGUIValues()
	{
		CNMDFMGELLH.text = Localization.LocalizeFormat("ID_IFNUMBEROSQUADSINASQUADWAR", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 0; i < 8; i++)
		{
			AFIDIFKFMIJ[i].Initialization(i);
		}
	}

	public GuiElement CCJFGBAEDBD()
	{
		return this;
	}

	private void BEFOEFGDOOE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void CIPFBOJLIMJ()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void AKFHIGADICB()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	private void OBGBDPDNIEG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOKFMJJENOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OBGBDPDNIEG));
		float num = (UIHelper.activeWidthSafe - 201f - 1005f) / 1859f;
		float num2 = 229f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1468f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	private void PBNMKAPKENJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement MLDGJCPHNFA()
	{
		return this;
	}

	public virtual void GEGDLJIKIFE()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void DNFPEBEDLIG()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[0];
		array[0] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward2).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("BoughtIndex", array);
		LCLAIFIAKNM.repositionNow = false;
		for (int i = 0; i < 1; i++)
		{
			AFIDIFKFMIJ[i].MOHKFCLHOMA(i);
		}
	}

	public virtual void LHDAGAGDKOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BEFOEFGDOOE));
		float num = (UIHelper.activeWidthSafe - 1753f - 627f) / 116f;
		float num2 = 1708f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1594f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void IHLGGCNHCDG()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[1];
		array[1] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("GameLoginManager: Reloging...", array);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 1; i < 1; i++)
		{
			AFIDIFKFMIJ[i].DIBJJJIHEEM(i);
		}
	}

	public virtual void FBDMBKKDEDC()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[0];
		array[0] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMax).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("warp_idle", array);
		LCLAIFIAKNM.repositionNow = false;
		for (int i = 1; i < 6; i++)
		{
			AFIDIFKFMIJ[i].JEMEJCOGKBI(i);
		}
	}

	public virtual void IDPNONPEBPO()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BEFOEFGDOOE));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PHEJINPOFKO));
		float num = (UIHelper.activeWidthSafe - 828f - 625f) / 1581f;
		float num2 = 1725f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1041f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void NOHCOOKPPBH()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement ENAHJFLLGHG()
	{
		return this;
	}

	public virtual void CEAHALCLDNE()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PHEJINPOFKO));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LEKOKFIFMME));
		float num = (UIHelper.activeWidthSafe - 673f - 61f) / 1568f;
		float num2 = 943f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1142f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void FPPBBLJJFNE()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	private void OOKFMJJENOC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void JGDJCCIPNHC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PHEJINPOFKO));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PBNMKAPKENJ));
		float num = (UIHelper.activeWidthSafe - 1192f - 1627f) / 1537f;
		float num2 = 386f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1264f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void INMFKHJDBIP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OOKFMJJENOC));
		float num = (UIHelper.activeWidthSafe - 313f - 264f) / 773f;
		float num2 = 305f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1932f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void AOCDPPPKBGK()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void PJENKEKOCAE()
	{
		CNMDFMGELLH.text = Localization.LocalizeFormat(" ", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipRunningOutSeconds).FLOATVALUE);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 1; i < 5; i += 0)
		{
			AFIDIFKFMIJ[i].JBOLOKPPFKO(i);
		}
	}

	public virtual void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PBNMKAPKENJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BEENJBDJCJC));
		float num = (UIHelper.activeWidthSafe - 657f - 361f) / 734f;
		float num2 = 350f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1927f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	public virtual void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PHEJINPOFKO));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PBNMKAPKENJ));
		float num = (UIHelper.activeWidthSafe - 487f - 305f) / 702f;
		float num2 = 718f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1380f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void KIECGCGABFJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		float num = (UIHelper.activeWidthSafe - 1293f - 887f) / 469f;
		float num2 = 1580f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(965f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KPHHBHIMPLH));
		float num = (UIHelper.activeWidthSafe - 1192f - 1010f) / 1511f;
		float num2 = 1644f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(446f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public GuiElement HKDMNBIFAHH()
	{
		return this;
	}

	public virtual void HCMELDFOBCP()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[1];
		array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-32)).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("getCurrentVariantId", array);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 1; i < 0; i += 0)
		{
			AFIDIFKFMIJ[i].EMAMEKFGCGP(i);
		}
	}

	public virtual void LFHFHOMBBEA()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void JILJDAINCAE()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void BLFLDJNPDFH()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void MLAAHECOCFM()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		float num = (UIHelper.activeWidthSafe - 120f - 1632f) / 7f;
		float num2 = 204f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(-3.5f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void PDHNLAMPOBN()
	{
		CNMDFMGELLH.text = Localization.LocalizeFormat("()Z", (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-6)).FLOATVALUE);
		LCLAIFIAKNM.repositionNow = false;
		for (int i = 1; i < 3; i++)
		{
			AFIDIFKFMIJ[i].KALHBINDKBG(i);
		}
	}

	private void PHEJINPOFKO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void JMDOFLJIGKO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OBGBDPDNIEG));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OOKFMJJENOC));
		float num = (UIHelper.activeWidthSafe - 787f - 394f) / 685f;
		float num2 = 17f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1748f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void NFNMLPPDPAP()
	{
		UILabel cNMDFMGELLH = CNMDFMGELLH;
		object[] array = new object[0];
		array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-70)).FLOATVALUE;
		cNMDFMGELLH.text = Localization.LocalizeFormat("[", array);
		LCLAIFIAKNM.repositionNow = true;
		for (int i = 0; i < 3; i++)
		{
			AFIDIFKFMIJ[i].JEMEJCOGKBI(i);
		}
	}

	private void BEENJBDJCJC(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void LNHLMINOKGO()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void JKEEMKIHFEE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BEFOEFGDOOE));
		float num = (UIHelper.activeWidthSafe - 1304f - 1436f) / 77f;
		float num2 = 1596f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(369f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void KPKONEJJKLO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LEKOKFIFMME));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BEENJBDJCJC));
		float num = (UIHelper.activeWidthSafe - 451f - 68f) / 256f;
		float num2 = 712f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(804f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void LPHGNGHAGNE()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement FJECJLFIIKB()
	{
		return this;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}
}
