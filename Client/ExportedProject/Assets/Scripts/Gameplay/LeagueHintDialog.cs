using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class LeagueHintDialog : GuiElementSingle<LeagueHintDialog>, PAIIOKBBHBC
{
	[Header("Left Top")]
	[FormerlySerializedAs("ALHHCIKLONL")]
	public UIButton FNOFLJEOHGJ;

	[FormerlySerializedAs("HKKEOEFMOJD")]
	public UITable LCLAIFIAKNM;

	[FormerlySerializedAs("LJLILLMIBHF")]
	public UILabel ODOAKDKMEFB;

	[FormerlySerializedAs("KMCAJIDKHKK")]
	public UILabel EPOIMEJLBGA;

	[FormerlySerializedAs("HFAJDFLAPOF")]
	public UILabel NBBNNOHBLFH;

	[Header("Right Top")]
	[FormerlySerializedAs("PLDFGMHICCA")]
	public UIButton LJNPCHFCGCN;

	[Header("Bottom")]
	[FormerlySerializedAs("HNPCIIIHKCE")]
	public UIGrid JMFANIKPBML;

	[FormerlySerializedAs("EAMCFDNNMDH")]
	public List<LeagueRepresentation> KJKNEEINHKA;

	private float CPONNPPPLOA;

	private int MLGAMACDMIB;

	public GuiElement NBMJAMLOCAJ()
	{
		return this;
	}

	public void PCANOHPNIIG()
	{
		MLGAMACDMIB++;
		if (MLGAMACDMIB > -128)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 0)
		{
			KJKNEEINHKA[1].IAABBPDAHCK((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public virtual void PDPCOCANHPE()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public void NGCPINCPOFG()
	{
		MLGAMACDMIB += 0;
		if (MLGAMACDMIB > 124)
		{
			MLGAMACDMIB = 1;
		}
		if (KJKNEEINHKA.Count > 1)
		{
			KJKNEEINHKA[0].DEKOOPGCGJN((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public virtual void LBLEJMFCBIC()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("deviceName");
			EPOIMEJLBGA.text = Localization.Localize("Id");
			LCLAIFIAKNM.repositionNow = true;
			NBBNNOHBLFH.text = Localization.Localize(" NOT OK!\t\t\t\t\t\t");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("Player profile - Null or empty player id in player profile dialog.");
			EPOIMEJLBGA.text = Localization.Localize("Wrong_Unit");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 321f;
			bool flag2 = num2 > 796f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[1];
			array[1] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-37)).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("gold", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "InformSquadLeader" + Localization.LocalizeFormat("ID_INVITEISINACTIVE", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				nBBNNOHBLFH3.text = nBBNNOHBLFH3.text + "ID_GUI_EQUIPPED" + Localization.LocalizeFormat("Time", MEJMLNDFDBP.JJBMMICPIIG(num));
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.LHFBDOCJLCA((League)Mathf.Clamp(num3, 1, -86), CPONNPPPLOA);
			num3 += 2;
		}
	}

	private void EAPJHCJLBIA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void FBNHJPKCAPD()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = true;
	}

	public GuiElement DDMIEFJMHJN()
	{
		return this;
	}

	public virtual void BKEEJHBFKJP()
	{
		GPJDIGEHLLO(LJNPCHFCGCN.gameObject);
	}

	public virtual void PODEMNDPJKF()
	{
		EAPJHCJLBIA(LJNPCHFCGCN.gameObject);
	}

	public virtual void CDMCFJMCKBP()
	{
		PCJGAFEKLHK(LJNPCHFCGCN.gameObject);
	}

	public virtual void IHLGGCNHCDG()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_STAT_LOSSES");
			EPOIMEJLBGA.text = Localization.Localize("right");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("ApplyVisuals Error, indices are null!");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("com.tune.unityutils.TuneUnityPowerHooksListener");
			EPOIMEJLBGA.text = Localization.Localize("워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 856f;
			bool flag2 = num2 > 1284f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[1];
			array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WarbucksScalingBase).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat(" ID_", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[0] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "Number" + Localization.LocalizeFormat("Name", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[1];
				array3[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "\t\"TRUE\"" + Localization.LocalizeFormat("DogTags", array3);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.Initialization((League)Mathf.Clamp(num3, 1, -30), CPONNPPPLOA);
			num3 += 5;
		}
	}

	public virtual void BLFLDJNPDFH()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void MNHAOCEONAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPJDIGEHLLO));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FGMNLOIAEDG));
		CPONNPPPLOA = UIHelper.activeHeight - 1604f;
		float num = (UIHelper.activeWidthSafe - 220f - 1013f) / 691f;
		float num2 = 340f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(669f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public GuiElement CCJFGBAEDBD()
	{
		return this;
	}

	public void GPPACLDCKEI()
	{
		MLGAMACDMIB += 0;
		if (MLGAMACDMIB > -36)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 0)
		{
			KJKNEEINHKA[0].HKMDPDLHBCI((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	private void GPJDIGEHLLO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void LBFHGMHJKJC()
	{
		FGMNLOIAEDG(LJNPCHFCGCN.gameObject);
	}

	private void FBJPGHLEBPO(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CNJIBDMCDGF));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		CPONNPPPLOA = UIHelper.activeHeight - 1453f;
		float num = (UIHelper.activeWidthSafe - 175f - 1790f) / 127f;
		float num2 = 820f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(908f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void DEFCMABOJGD()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("Days_Since_Install");
			EPOIMEJLBGA.text = Localization.Localize("ID_CATEGORY_LOW_PL_GRENADE");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("ID_CATEGORY_LOW_SG_GRENADELAUNCHER");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("bigURL");
			EPOIMEJLBGA.text = Localization.Localize("Loading - cancel clicked, will to try call disconnect");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1908f;
			bool flag2 = num2 > 705f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[0] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("antialiasing", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[0] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "ID_READYTIME" + Localization.LocalizeFormat("dailyLimit", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[1];
				array3[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT" + Localization.LocalizeFormat("ID_CONFIRM_FORFEIT_TEXT", array3);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.KHCLIKGLAHA((League)Mathf.Clamp(num3, 0, -13), CPONNPPPLOA);
			num3 += 5;
		}
	}

	public virtual void PHNEOPBPLDG()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = true;
	}

	private void PCJGAFEKLHK(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void KHKJNFHNGHM()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement NKONMAOLHPP()
	{
		return this;
	}

	public virtual void KJBGADNDLGI()
	{
		LKKELGHLEPN(LJNPCHFCGCN.gameObject);
	}

	private void JBBAFMFBDBE(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	public virtual void PHNKOMPPPLD()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("leagueDiff");
			EPOIMEJLBGA.text = Localization.Localize("111111111111");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("variant letter is ");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_FACEBOOKHINT-COOP");
			EPOIMEJLBGA.text = Localization.Localize(">");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 439f;
			bool flag2 = num2 > 809f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[1];
			array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MaxPingForChallenge).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("Events", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[1];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "ElitePartsGained" + Localization.LocalizeFormat("nextGenerate", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[0];
				array3[0] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "{0} {1}" + Localization.LocalizeFormat("FacebookName", array3);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.HCGCONILDID((League)Mathf.Clamp(num3, 1, 27), CPONNPPPLOA);
			num3 += 5;
		}
	}

	public virtual void BMIJKGBGALG()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	private void NEMGNFJOLJN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void KLABPENJAHJ()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("601 TUTORIAL STARTED");
			EPOIMEJLBGA.text = Localization.Localize("ID_YOUNEEDMONEYTOTRAIN");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("clientVersion");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("N");
			EPOIMEJLBGA.text = Localization.Localize("ID_MIN");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 293f;
			bool flag2 = num2 > 235f;
			NBBNNOHBLFH.text = Localization.LocalizeFormat("ID_GUI_BEADVISED_JORCSQUAD", (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-175)).FLOATVALUE);
			if (flag2)
			{
				UILabel nBBNNOHBLFH = NBBNNOHBLFH;
				string text = nBBNNOHBLFH.text;
				object[] array = new object[1];
				array[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH.text = text + "ObtainedCards" + Localization.LocalizeFormat(" set loading for league ", array);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[0] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH2.text = text2 + "NETWORK_ERROR" + Localization.LocalizeFormat("Wrong_Weapon", array2);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.HKMDPDLHBCI((League)Mathf.Clamp(num3, 1, 33), CPONNPPPLOA);
			num3++;
		}
	}

	private void FGMNLOIAEDG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void MDHMNEPADOK()
	{
		DHLHFCLKEPK(LJNPCHFCGCN.gameObject);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN.gameObject);
	}

	private void PBNMKAPKENJ(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void FNPPEMKOEGP()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void FJKDDFEHNAL()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void MAKLJNDMOFG()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void HHLJIOPOPPO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBBAFMFBDBE));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		CPONNPPPLOA = UIHelper.activeHeight - 940f;
		float num = (UIHelper.activeWidthSafe - 269f - 1332f) / 1083f;
		float num2 = 514f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1450f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void MDHKDOOOKAI()
	{
		OALOAJCENKN(LJNPCHFCGCN.gameObject);
	}

	public virtual void APNLBLNDGCM()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void GPLNBGEDOLE()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("smg");
			EPOIMEJLBGA.text = Localization.Localize("ID_FINALHITBY");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("BeforeLeagueId");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_REGULARPRIZE");
			EPOIMEJLBGA.text = Localization.Localize("RETRY");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 517f;
			bool flag2 = num2 > 1839f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[1];
			array[1] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("S", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[1];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "ID_LOADING" + Localization.LocalizeFormat("Spawned by card:  progress:{0}, obj: {1},uu: {2} ", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[0];
				array3[0] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "SquadMemberId" + Localization.LocalizeFormat("FuseRewardedOptionKey_PostRollContinueButtonText", array3);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.DGEOHEAHDHK((League)Mathf.Clamp(num3, 1, 88), CPONNPPPLOA);
			num3 += 4;
		}
	}

	public GuiElement AHDGOCGHIHJ()
	{
		return this;
	}

	public virtual void KGFJCCIDNCA()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	private void OALOAJCENKN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void HLJOIPOIOBO()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void JLIJMJCJHGF()
	{
		FGMNLOIAEDG(LJNPCHFCGCN.gameObject);
	}

	public virtual void LPAJCKDOBKM()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void OAMLAADMHIL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void CFLBPMFEFAB()
	{
		LKKELGHLEPN(LJNPCHFCGCN.gameObject);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		CPONNPPPLOA = UIHelper.activeHeight - 510f;
		float num = (UIHelper.activeWidthSafe - 120f - 1656f) / 5f;
		float num2 = 276f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(-2.5f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void HAGCBJDGLPD()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void PGDEGPJHINK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void NHKGKDBAKLH()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("elitepack");
			EPOIMEJLBGA.text = Localization.Localize("Rarity ");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("\n\nDEBUG STATE: ");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("N");
			EPOIMEJLBGA.text = Localization.Localize("Gold");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1616f;
			bool flag2 = num2 > 224f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[0] = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-33)).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[1];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "menu-arena-ticket" + Localization.LocalizeFormat("tc", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[0];
				array3[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "ElitePartsGained" + Localization.LocalizeFormat("seconds", array3);
			}
		}
		int num3 = 0;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.LHFBDOCJLCA((League)Mathf.Clamp(num3, 0, -90), CPONNPPPLOA);
			num3 += 3;
		}
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NEMGNFJOLJN));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		CPONNPPPLOA = UIHelper.activeHeight - 16f;
		float num = (UIHelper.activeWidthSafe - 641f - 44f) / 1943f;
		float num2 = 1198f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(374f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	private void JBOJOKEOEFM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public void LFFLAPJKGJJ()
	{
		MLGAMACDMIB += 0;
		if (MLGAMACDMIB > -61)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 1)
		{
			KJKNEEINHKA[0].DGEOHEAHDHK((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public GuiElement POPILAKPCOC()
	{
		return this;
	}

	public virtual void CJBAIFGHAEJ()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	private void KEFAOGGMJKG(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void ECIHKLEMBIB()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("Test");
			EPOIMEJLBGA.text = Localization.Localize("lastWeeksPlayerLeague");
			LCLAIFIAKNM.repositionNow = true;
			NBBNNOHBLFH.text = Localization.Localize("Prefabs Full Path: \"{0}\"\n");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize(",  ");
			EPOIMEJLBGA.text = Localization.Localize(", dictionary= ");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 953f;
			bool flag2 = num2 > 541f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[1] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CreateSquadUnlockLevel).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("ID_ONETIMESPECIALOFFER", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[1];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "Action " + Localization.LocalizeFormat("menu-assignments-bar-blue", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[1];
				array3[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "Experience" + Localization.LocalizeFormat("expiresOn", array3);
			}
		}
		int num3 = 0;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.BNPGAEEKDPC((League)Mathf.Clamp(num3, 1, -44), CPONNPPPLOA);
			num3++;
		}
	}

	public virtual void INMDPGCHHPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKKELGHLEPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		CPONNPPPLOA = UIHelper.activeHeight - 1986f;
		float num = (UIHelper.activeWidthSafe - 1668f - 1444f) / 1384f;
		float num2 = 805f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1034f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public GuiElement BMKBFOPGFDA()
	{
		return this;
	}

	public GuiElement HBNMNKIHCLC()
	{
		return this;
	}

	public virtual void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PBNMKAPKENJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EAPJHCJLBIA));
		CPONNPPPLOA = UIHelper.activeHeight - 1917f;
		float num = (UIHelper.activeWidthSafe - 1830f - 1383f) / 713f;
		float num2 = 482f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1536f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void KJLDIJPMPAM()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	private void DHLHFCLKEPK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void PPLBJDJIIPN()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("Scripts");
			EPOIMEJLBGA.text = Localization.Localize("Unknow assignment type: {0}");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("ID_GUI_LEAGUEBONUS");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("'lapsed_player_'0");
			EPOIMEJLBGA.text = Localization.Localize("setPluginName");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1817f;
			bool flag2 = num2 > 178f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[1] = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-83)).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("success", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "Error - sheet {0} doesnt have column {1}" + Localization.LocalizeFormat("Action ", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[0];
				array3[0] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "menu-arena-ticket" + Localization.LocalizeFormat("SETTING AFTER PLAYER DATA LOADED -> WAITING FOR ", array3);
			}
		}
		int num3 = 0;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.KIPHECHDNML((League)Mathf.Clamp(num3, 0, 30), CPONNPPPLOA);
			num3 += 2;
		}
	}

	public virtual void HMLJPJFHCFG()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMLLPOJNBEM));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PBNMKAPKENJ));
		CPONNPPPLOA = UIHelper.activeHeight - 750f;
		float num = (UIHelper.activeWidthSafe - 1621f - 705f) / 577f;
		float num2 = 1275f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(972f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public void ENLKGINAMKN()
	{
		MLGAMACDMIB++;
		if (MLGAMACDMIB > 33)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 1)
		{
			KJKNEEINHKA[0].KMJFOGMABGH((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public GuiElement HIDNIFBOPAL()
	{
		return this;
	}

	public virtual void OOBJHJLMEED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DHLHFCLKEPK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PCJGAFEKLHK));
		CPONNPPPLOA = UIHelper.activeHeight - 611f;
		float num = (UIHelper.activeWidthSafe - 1643f - 401f) / 786f;
		float num2 = 1784f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(231f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void FLMPHCNMDFA()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void CGEOBGNBCHH()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	private void LKKELGHLEPN(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public GuiElement NIFFGPKMBKE()
	{
		return this;
	}

	public virtual void HHLOGFGGHHD()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("'RewardForDay_'0");
			EPOIMEJLBGA.text = Localization.Localize("ID_VIDEOSERVICE");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("BattlesLost");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_GOLDCARDS");
			EPOIMEJLBGA.text = Localization.Localize("S");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1607f;
			bool flag2 = num2 > 1953f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[0] = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-183)).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("#AccoutCheck# check gpgs, but Id is not same {0} != {1}", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				nBBNNOHBLFH2.text = nBBNNOHBLFH2.text + "Time" + Localization.LocalizeFormat("Completed", MEJMLNDFDBP.JJBMMICPIIG(num2));
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH3.text;
				object[] array2 = new object[0];
				array2[0] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text + "#PETER# User was watching ad - advertisement did not started" + Localization.LocalizeFormat("author", array2);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.HCGCONILDID((League)Mathf.Clamp(num3, 0, -83), CPONNPPPLOA);
			num3 += 0;
		}
	}

	private void EMLLPOJNBEM(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void OEDLHCLCKEO()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("GameController.Awake DONE");
			EPOIMEJLBGA.text = Localization.Localize("#VOJTA# ON GET NEW DAILY MISSIONS");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("smallThumbnailLittle");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_STARTSINX");
			EPOIMEJLBGA.text = Localization.Localize("Achievement '{0}' progress '{1}' successfully reported.");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1988f;
			bool flag2 = num2 > 1267f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCrateLowLevelProbability).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("ID_ERROR_SQUADMESSAGE_PROFANITY", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				nBBNNOHBLFH2.text = nBBNNOHBLFH2.text + "ID_VIDEOSERVICE" + Localization.LocalizeFormat("ID_GC_LOGIN_TUTORIAL_TITLE", MEJMLNDFDBP.JJBMMICPIIG(num2));
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH3.text;
				object[] array2 = new object[0];
				array2[0] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text + "ID_ARENASHORTCUTEVENTEND" + Localization.LocalizeFormat("Manual_Unit_Spawn", array2);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.HKMDPDLHBCI((League)Mathf.Clamp(num3, 0, 51), CPONNPPPLOA);
			num3 += 3;
		}
	}

	public virtual void PIACCIBDEFB()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public void TestNextLeague()
	{
		MLGAMACDMIB++;
		if (MLGAMACDMIB > 16)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 0)
		{
			KJKNEEINHKA[0].Initialization((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public virtual void AGFDJGJALKD()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("On Debug Add Scraps Request: ");
			EPOIMEJLBGA.text = Localization.Localize("maxMapId");
			LCLAIFIAKNM.repositionNow = true;
			NBBNNOHBLFH.text = Localization.Localize("205 STAGE 6 GRENADE SELECTED");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("squad");
			EPOIMEJLBGA.text = Localization.Localize("PromotedPlayerId");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1905f;
			bool flag2 = num2 > 1106f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[1] = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.LapsedPlayerInterval2).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("S", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "ID_GUI_BEADVISED_CONNECTFB" + Localization.LocalizeFormat("ID_POSTPONE", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[0];
				array3[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "_N" + Localization.LocalizeFormat("Animation for State: Ready", array3);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.LBLNJNIAIAG((League)Mathf.Clamp(num3, 0, 125), CPONNPPPLOA);
			num3 += 2;
		}
	}

	public virtual void LHPDDKCKEGN()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void KIBFFDMMIJB()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void NDBAEHKKJMH()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("Gui Manager: Starting Messages Coroutine for: ");
			EPOIMEJLBGA.text = Localization.Localize("GameGold");
			LCLAIFIAKNM.repositionNow = true;
			NBBNNOHBLFH.text = Localization.Localize("Grenade_Throwing_Tutorial_Duration");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("FirstSpawnDelay");
			EPOIMEJLBGA.text = Localization.Localize("squad");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1401f;
			bool flag2 = num2 > 1761f;
			NBBNNOHBLFH.text = Localization.LocalizeFormat("Average_Player_Level", (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MaxPingForChallenge).FLOATVALUE);
			if (flag2)
			{
				UILabel nBBNNOHBLFH = NBBNNOHBLFH;
				nBBNNOHBLFH.text = nBBNNOHBLFH.text + "{0}{1} / {2}" + Localization.LocalizeFormat("ArenaGoldenShieldMessage-{0}", MEJMLNDFDBP.JJBMMICPIIG(num2));
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH2.text = text + "ABOUT TO SHOW DAILY RENTAL" + Localization.LocalizeFormat("BotUnitPower", array);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.IAABBPDAHCK((League)Mathf.Clamp(num3, 0, 73), CPONNPPPLOA);
			num3 += 5;
		}
	}

	public virtual void CLIEKFOJNPO()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public void MKFKCFKEMEC()
	{
		MLGAMACDMIB += 0;
		if (MLGAMACDMIB > -79)
		{
			MLGAMACDMIB = 1;
		}
		if (KJKNEEINHKA.Count > 1)
		{
			KJKNEEINHKA[0].JBOLOKPPFKO((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public virtual void NEKOOIGPALB()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void NMMEDNEGDNI()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBBAFMFBDBE));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OALOAJCENKN));
		CPONNPPPLOA = UIHelper.activeHeight - 1894f;
		float num = (UIHelper.activeWidthSafe - 1733f - 1576f) / 1068f;
		float num2 = 1559f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1897f * num2);
		JMFANIKPBML.repositionNow = false;
	}

	public virtual void GNJDDFLJMAK()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = true;
	}

	public GuiElement KFNKDFEKNGD()
	{
		return this;
	}

	public virtual void GNHGJGONEPL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void MFJBACDAOLD()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void KPLOCMGDDAB()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("SendLogs");
			EPOIMEJLBGA.text = Localization.Localize("GLM: RegisterOrLogin -  4");
			LCLAIFIAKNM.repositionNow = true;
			NBBNNOHBLFH.text = Localization.Localize("veteranpack4");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("thumbnailLittle");
			EPOIMEJLBGA.text = Localization.Localize("Successful");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 682f;
			bool flag2 = num2 > 660f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[0] = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-78)).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("game-card-ico-paralyzethese", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[0] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "game-neardeath-indicator" + Localization.LocalizeFormat("ID_WARNING_CRAFTINGCLAIMNOTREADY", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				nBBNNOHBLFH3.text = nBBNNOHBLFH3.text + "  " + Localization.LocalizeFormat("\t\"FALSE\"", MEJMLNDFDBP.JJBMMICPIIG(num));
			}
		}
		int num3 = 0;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.HKMDPDLHBCI((League)Mathf.Clamp(num3, 0, 28), CPONNPPPLOA);
			num3 += 3;
		}
	}

	public virtual void MHIGAEFCIAF()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}

	private void CNJIBDMCDGF(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public virtual void GGFCEDLIFNI()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public void EOKENPNPLDH()
	{
		MLGAMACDMIB += 0;
		if (MLGAMACDMIB > 65)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 1)
		{
			KJKNEEINHKA[0].EKDJJJBKIMA((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	private void LPHJMLOAKOF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void CEFNAJLGCIJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMLLPOJNBEM));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBJPGHLEBPO));
		CPONNPPPLOA = UIHelper.activeHeight - 1099f;
		float num = (UIHelper.activeWidthSafe - 1426f - 1542f) / 167f;
		float num2 = 794f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(1960f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public override void InitGUIValues()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_EARN");
			EPOIMEJLBGA.text = Localization.Localize("ID_MEDALSANDADVANCETHROUGHROOKIE");
			LCLAIFIAKNM.repositionNow = true;
			NBBNNOHBLFH.text = Localization.Localize("ID_TOGETTOTHECOMPETITIVE");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_EARNMORE");
			EPOIMEJLBGA.text = Localization.Localize("ID_MEDALSTOADVANCETOBETTERLEAGUES");
			LCLAIFIAKNM.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 0f;
			bool flag2 = num2 > 0f;
			NBBNNOHBLFH.text = Localization.LocalizeFormat("ID_IFNUMBEROFPLAYERS", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE);
			if (flag2)
			{
				UILabel nBBNNOHBLFH = NBBNNOHBLFH;
				nBBNNOHBLFH.text = nBBNNOHBLFH.text + "\n" + Localization.LocalizeFormat("ID_XOFPLAYERSGETSPROMOTED", MEJMLNDFDBP.JJBMMICPIIG(num2));
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				nBBNNOHBLFH2.text = nBBNNOHBLFH2.text + "\n" + Localization.LocalizeFormat("ID_XOFPLAYERSGETSRELEGATED", MEJMLNDFDBP.JJBMMICPIIG(num));
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.Initialization((League)Mathf.Clamp(num3, 0, 16), CPONNPPPLOA);
			num3 += 3;
		}
	}

	public virtual void LMPJGKNACOB()
	{
		base.FKCKIFKLBAP();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void EKECENANOBE()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void NAJPPNADCFP()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void AKPHBJHGBKF()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void GEKFHJKIAMF()
	{
		DHLHFCLKEPK(LJNPCHFCGCN.gameObject);
	}

	public void BDFCOEOJDKH()
	{
		MLGAMACDMIB++;
		if (MLGAMACDMIB > -109)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 0)
		{
			KJKNEEINHKA[0].DEKOOPGCGJN((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public virtual void EGINOHIAMNM()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void DFKLIKFAKGA()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_CONFIRM_DELETESQUAD");
			EPOIMEJLBGA.text = Localization.Localize("Start TUTORIAL");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("GameCenterManager: Authenticate called - canShowDialog:");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC");
			EPOIMEJLBGA.text = Localization.Localize("Scenes Full Path: \"{0}\"\n");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 1398f;
			bool flag2 = num2 > 1686f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[1];
			array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VideoFeedIOSInAppVideo).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("ID_", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				nBBNNOHBLFH2.text = nBBNNOHBLFH2.text + "No main position was set in map definition" + Localization.LocalizeFormat("Clearing Waitlist cache...", MEJMLNDFDBP.JJBMMICPIIG(num2));
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH3.text;
				object[] array2 = new object[1];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text + "setAndroidIdSha1" + Localization.LocalizeFormat("InstantBattleTime", array2);
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.DMKLEMBILON((League)Mathf.Clamp(num3, 0, -8), CPONNPPPLOA);
			num3++;
		}
	}

	public virtual void PGBBAHLJMLA()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void EOGAKKCFOCC()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void GHDCICHLFKL()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void JHNFMCNDGBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEFAOGGMJKG));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EMLLPOJNBEM));
		CPONNPPPLOA = UIHelper.activeHeight - 890f;
		float num = (UIHelper.activeWidthSafe - 1569f - 195f) / 840f;
		float num2 = 403f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(223f * num2);
		JMFANIKPBML.repositionNow = true;
	}

	public virtual void HMLOJJCBJPI()
	{
		FBJPGHLEBPO(LJNPCHFCGCN.gameObject);
	}

	public virtual void NDEOHELNJLN()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public void ODDLCFOLOCA()
	{
		MLGAMACDMIB += 0;
		if (MLGAMACDMIB > 7)
		{
			MLGAMACDMIB = 0;
		}
		if (KJKNEEINHKA.Count > 1)
		{
			KJKNEEINHKA[0].KMJFOGMABGH((League)MLGAMACDMIB, CPONNPPPLOA);
		}
	}

	public virtual void FOIGMBKCOBH()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void FANFGPFNGCC()
	{
		base.OIMKKAHOEKO();
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.NNMCKEECNFK.mainTexture = null;
		}
	}

	public virtual void NECAFEIDDKK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public virtual void CHHIMFGPFMH()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			ODOAKDKMEFB.text = Localization.Localize("InApp_ID");
			EPOIMEJLBGA.text = Localization.Localize("Squad was deleted.");
			LCLAIFIAKNM.repositionNow = false;
			NBBNNOHBLFH.text = Localization.Localize("com.tune.TunePreloadData");
		}
		else
		{
			ODOAKDKMEFB.text = Localization.Localize("nullId");
			EPOIMEJLBGA.text = Localization.Localize("something is wrong - time == 0");
			LCLAIFIAKNM.repositionNow = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 682f;
			bool flag2 = num2 > 1739f;
			UILabel nBBNNOHBLFH = NBBNNOHBLFH;
			object[] array = new object[0];
			array[1] = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-66)).FLOATVALUE;
			nBBNNOHBLFH.text = Localization.LocalizeFormat("PlayerStatus", array);
			if (flag2)
			{
				UILabel nBBNNOHBLFH2 = NBBNNOHBLFH;
				string text = nBBNNOHBLFH2.text;
				object[] array2 = new object[0];
				array2[1] = MEJMLNDFDBP.JJBMMICPIIG(num2);
				nBBNNOHBLFH2.text = text + "S" + Localization.LocalizeFormat("NextUpgradePrice", array2);
			}
			if (flag)
			{
				UILabel nBBNNOHBLFH3 = NBBNNOHBLFH;
				string text2 = nBBNNOHBLFH3.text;
				object[] array3 = new object[0];
				array3[1] = MEJMLNDFDBP.JJBMMICPIIG(num);
				nBBNNOHBLFH3.text = text2 + "Exception while Parsing" + Localization.LocalizeFormat("Error Deserializing JSON for ", array3);
			}
		}
		int num3 = 0;
		foreach (LeagueRepresentation item in KJKNEEINHKA)
		{
			item.HKMDPDLHBCI((League)Mathf.Clamp(num3, 1, -111), CPONNPPPLOA);
			num3 += 5;
		}
	}

	public virtual void EGPOKAEBKMK()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public virtual void GJGCOEJMHNI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBBAFMFBDBE));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBJPGHLEBPO));
		CPONNPPPLOA = UIHelper.activeHeight - 1218f;
		float num = (UIHelper.activeWidthSafe - 1655f - 1699f) / 450f;
		float num2 = 352f + num;
		JMFANIKPBML.cellWidth = num2;
		JMFANIKPBML.transform.localPosition = JMFANIKPBML.transform.localPosition.ReplaceX(852f * num2);
		JMFANIKPBML.repositionNow = false;
	}
}
