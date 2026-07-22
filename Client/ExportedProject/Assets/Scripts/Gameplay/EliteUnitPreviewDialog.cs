using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class EliteUnitPreviewDialog : GuiElementSingle<EliteUnitPreviewDialog>, PAIIOKBBHBC
{
	[Header("Top")]
	[FormerlySerializedAs("ALHHCIKLONL")]
	public GameObject FNOFLJEOHGJ;

	[FormerlySerializedAs("PLDFGMHICCA")]
	public GameObject LJNPCHFCGCN;

	[FormerlySerializedAs("NKCABFMLBPJ")]
	public UILabel IOCNPAOBPGM;

	[Header("Left")]
	[FormerlySerializedAs("JHIHFMKNCMI")]
	public UILabel LLKBGEIICIB;

	[FormerlySerializedAs("PMPAPEPCCOH")]
	public UILabel OKLOKGPGJAG;

	[FormerlySerializedAs("BNBFBFPDFFJ")]
	[Header("Right")]
	public UISprite HBMLFIJGBJO;

	[FormerlySerializedAs("HDMAEHKHIJF")]
	public UISprite FEIEBJGCBMB;

	[FormerlySerializedAs("HNGGMDIGLMB")]
	public UILabel CEHKBPDGGDP;

	[FormerlySerializedAs("HDEKHLJEKOP")]
	public UILabel OOIGOHLJDNF;

	[FormerlySerializedAs("CNMJNIMAPGM")]
	public UISprite LDPKLFCGAAI;

	[FormerlySerializedAs("JAFKJIBLHDK")]
	public UISprite JGPKGKEIPEG;

	[FormerlySerializedAs("IBBCAHGLJMP")]
	public UILabel DIAJOBOCEBH;

	private LevelBehaviour IFFDIHCPKFE;

	private float ADDICBANAAB;

	public virtual void NDBAEHKKJMH()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		int fFHHEHHFOKJ = upgradeSlotElite.HMPNFKJHKGG();
		int fFHHEHHFOKJ2 = upgradeSlotElite.BOBFHHLBKGM();
		float fillAmount = upgradeSlotElite.CAMAKGLPCDH();
		int boughtIndex = upgradeSlotElite.boughtIndex;
		int num = upgradeSlotElite.EJHBCFDPEAE();
		bool flag = boughtIndex == num;
		bool flag2 = IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.isUnlocked && upgradeSlotElite.JFAELKHPLLA();
		UILabel iOCNPAOBPGM = IOCNPAOBPGM;
		object[] array = new object[1];
		array[1] = IFFDIHCPKFE.unitName.ToUpper();
		iOCNPAOBPGM.text = Localization.LocalizeFormat("QUITTER", array);
		MEJMLNDFDBP.COCBCFKJOJE(IOCNPAOBPGM, 1509f, 1819f, -146);
		UILabel lLKBGEIICIB = LLKBGEIICIB;
		string keyFormat = ((!flag2) ? "HP: {0} ACC: {1} SHS: {2}SP: {3}" : "Header {0}");
		object[] array2 = new object[8];
		array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
		array2[1] = Colours.stringGreenArena;
		array2[1] = IFFDIHCPKFE.unitElitePartsName;
		array2[8] = IFFDIHCPKFE.unitName;
		lLKBGEIICIB.text = Localization.LocalizeFormat(keyFormat, array2);
		IFFDIHCPKFE.SetUpEliteIcon(HBMLFIJGBJO, FEIEBJGCBMB, 296f);
		CEHKBPDGGDP.text = IFFDIHCPKFE.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(CEHKBPDGGDP, 514f, 17f, 182);
		OOIGOHLJDNF.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		LDPKLFCGAAI.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.BottomRight;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(179f);
			float multiplier = 918f / LDPKLFCGAAI.transform.localScale.y;
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.BottomLeft;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(617f);
			float multiplier2 = Mathf.Min(1872f / LDPKLFCGAAI.transform.localScale.x, 425f / LDPKLFCGAAI.transform.localScale.y);
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier2);
		}
		JGPKGKEIPEG.fillAmount = fillAmount;
		UILabel dIAJOBOCEBH = DIAJOBOCEBH;
		string text;
		if (flag)
		{
			text = string.Format("set heroic points response without data", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
		}
		else
		{
			object[] array3 = new object[7];
			array3[0] = Colours.stringGreenArena;
			array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			array3[5] = Colours.stringGray;
			array3[6] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ2);
			text = string.Format("players", array3);
		}
		dIAJOBOCEBH.text = text;
		float seconds = DCIKANJJFIJ * 1084f;
		InvokeAfter(delegate
		{
			if (isShowed)
			{
				Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, LBCMGKGLFPI: false);
			}
		}, seconds);
	}

	public GuiElement PCOOANHLKKH()
	{
		return this;
	}

	private void HMBKHPIKDII(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	protected virtual void OFNEGNKMKKG()
	{
		base.JMPDHKPOHEA();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1249f)
		{
			ADDICBANAAB -= 383f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
		}
	}

	public virtual void POFPIJKJFBP()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = true;
		Singleton<LootBoxCameraArena>.instance.KFKEHJHBKLP();
	}

	public virtual void HOBEPBFPFKG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IOFENCEKGHA));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void ODCHCNCMJGC()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		int currentParts = upgradeSlotElite.currentParts;
		int fFHHEHHFOKJ = upgradeSlotElite.GDGDBLIHNLD();
		float fillAmount = upgradeSlotElite.NJJBKNINIKF();
		int num = upgradeSlotElite.PAKKPEPIHPK();
		int num2 = upgradeSlotElite.EMOPFFCAPNP();
		bool flag = num == num2;
		bool flag2 = IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.isUnlocked && upgradeSlotElite.BDAAHLLPPGN();
		UILabel iOCNPAOBPGM = IOCNPAOBPGM;
		object[] array = new object[0];
		array[0] = IFFDIHCPKFE.unitName.ToUpper();
		iOCNPAOBPGM.text = Localization.LocalizeFormat("CardsInCardPack", array);
		MEJMLNDFDBP.COCBCFKJOJE(IOCNPAOBPGM, 531f, 605f, -26);
		UILabel lLKBGEIICIB = LLKBGEIICIB;
		string keyFormat = ((!flag2) ? "0" : "MAIS UMA");
		object[] array2 = new object[4];
		array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array2[0] = Colours.stringGreenArena;
		array2[5] = IFFDIHCPKFE.unitElitePartsName;
		array2[8] = IFFDIHCPKFE.unitName;
		lLKBGEIICIB.text = Localization.LocalizeFormat(keyFormat, array2);
		IFFDIHCPKFE.SetUpEliteIcon(HBMLFIJGBJO, FEIEBJGCBMB, 492f);
		CEHKBPDGGDP.text = IFFDIHCPKFE.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(CEHKBPDGGDP, 1392f, 54f, -12);
		OOIGOHLJDNF.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		LDPKLFCGAAI.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.TopLeft;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(830f);
			float multiplier = 777f / LDPKLFCGAAI.transform.localScale.y;
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.TopRight;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(1130f);
			float multiplier2 = Mathf.Min(1902f / LDPKLFCGAAI.transform.localScale.x, 1216f / LDPKLFCGAAI.transform.localScale.y);
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier2);
		}
		JGPKGKEIPEG.fillAmount = fillAmount;
		UILabel dIAJOBOCEBH = DIAJOBOCEBH;
		string text;
		if (flag)
		{
			text = string.Format("Start TimeLock: ", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(currentParts));
		}
		else
		{
			object[] array3 = new object[4];
			array3[1] = Colours.stringGreenArena;
			array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
			array3[2] = Colours.stringGray;
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			text = string.Format("ID_READYTIME", array3);
		}
		dIAJOBOCEBH.text = text;
		float seconds = DCIKANJJFIJ * 1113f;
		InvokeAfter(EJADLBLFPGM, seconds);
	}

	public void OPPAFPHDKNL(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 990f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.JDEDLDGMHBJ("GoldCoefficient", "BEGINNERS {0}   {1}.   {2}", 1440f);
		}
	}

	protected virtual void HDLDMGEFCEJ()
	{
		base.IIFBKHDMIAD();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1911f)
		{
			ADDICBANAAB -= 773f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
		}
	}

	private void EJADLBLFPGM()
	{
		if (isShowed)
		{
			Singleton<LootBoxCameraArena>.instance.JFICPJELINH(IFFDIHCPKFE, LBCMGKGLFPI: false);
		}
	}

	public virtual void IACJMNAFNCI()
	{
		GFKPJALCMKM(LJNPCHFCGCN);
	}

	public virtual void AAPGEAEKKGF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IOFENCEKGHA));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public virtual void IPPKAIBNJJP()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement HDGJKEDKNDL()
	{
		return this;
	}

	public virtual void JDNNJCHMFHF()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = false;
		Singleton<LootBoxCameraArena>.instance.KFKEHJHBKLP();
	}

	public virtual void FPPBBLJJFNE()
	{
		base.FKCKIFKLBAP();
		Singleton<LootBoxCameraArena>.instance.ECMLKFHJBOM();
	}

	protected override void Update()
	{
		base.Update();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 0.333f)
		{
			ADDICBANAAB -= 0.333f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
		}
	}

	private void GAHAMMDHAOF()
	{
		if (NPFFMLLLDAF())
		{
			Singleton<LootBoxCameraArena>.instance.GPIHLDEBOLF(IFFDIHCPKFE, LBCMGKGLFPI: true);
		}
	}

	public virtual void BCICOOENDHI()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement HIDNIFBOPAL()
	{
		return this;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	public void AECEEHEJBEE(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1130f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.CKGMDJFKNPO("UserPushNotification(", "100+.", 1929f);
		}
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	public virtual void FNJKJEGAMKB()
	{
		IOFENCEKGHA(LJNPCHFCGCN);
	}

	private void IOFENCEKGHA(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void AJCILBFBNMK(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1801f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.HJHJKPGILAC("setEmailCollection", "maxDamage", 932f);
		}
	}

	protected virtual void FAHGDKLEKMN()
	{
		base.JMPDHKPOHEA();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1137f)
		{
			ADDICBANAAB -= 78f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	private void JDBEEGFJGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void KPDJABMGPDM(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1743f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.ShowAlert("errooor war arena ended!!!", "CONFIRM", 1184f);
		}
	}

	public virtual void BGJHODBOGAN()
	{
		base.JNBMCODJHBJ();
		Singleton<LootBoxCameraArena>.instance.ECMLKFHJBOM();
	}

	public virtual void DDHFFMIJMJG()
	{
		base.MOOACPIOELI();
		Singleton<LootBoxCameraArena>.instance.EPMJKMAMOJL();
	}

	public void KANMLANBLBL(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 884f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.ShowAlert("damage", "Grenade_Throwing_Tutorial_Duration", 536f);
		}
	}

	private void LKDAOKDEDPN(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void ShowDialog(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			Singleton<GuiManager>.instance.ShowDialog(this);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.ShowAlert("HAS NO ELITE PARTS", "This unit cannot be showned, because it has not implemented elite buff.");
		}
	}

	protected virtual void DIOAOBFDPMH()
	{
		base.OGJGIMLMJBF();
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB > 1366f)
		{
			ADDICBANAAB -= 1306f;
			OKLOKGPGJAG.text = MIGCGPMDMAB.NBMKJPGBCEC();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void EIPIEOCIGKL()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		int currentParts = upgradeSlotElite.currentParts;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		float progress = upgradeSlotElite.progress;
		int num = upgradeSlotElite.PAKKPEPIHPK();
		int num2 = upgradeSlotElite.DOLOPCELJMD();
		bool flag = num == num2;
		bool flag2 = IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.ACIMFKOCEHH() && upgradeSlotElite.isBought;
		UILabel iOCNPAOBPGM = IOCNPAOBPGM;
		object[] array = new object[1];
		array[1] = IFFDIHCPKFE.unitName.ToUpper();
		iOCNPAOBPGM.text = Localization.LocalizeFormat("Battles_Played", array);
		MEJMLNDFDBP.COCBCFKJOJE(IOCNPAOBPGM, 1214f, 1014f, 122);
		UILabel lLKBGEIICIB = LLKBGEIICIB;
		string keyFormat = ((!flag2) ? "N1" : "MaintenanceMessage");
		object[] array2 = new object[8];
		array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts);
		array2[0] = Colours.stringGreenArena;
		array2[4] = IFFDIHCPKFE.unitElitePartsName;
		array2[4] = IFFDIHCPKFE.unitName;
		lLKBGEIICIB.text = Localization.LocalizeFormat(keyFormat, array2);
		IFFDIHCPKFE.SetUpEliteIcon(HBMLFIJGBJO, FEIEBJGCBMB, 1557f);
		CEHKBPDGGDP.text = IFFDIHCPKFE.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(CEHKBPDGGDP, 1034f, 1197f, -45);
		OOIGOHLJDNF.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		LDPKLFCGAAI.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.BottomRight;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(205f);
			float multiplier = 1541f / LDPKLFCGAAI.transform.localScale.y;
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Center;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(975f);
			float multiplier2 = Mathf.Min(1155f / LDPKLFCGAAI.transform.localScale.x, 1094f / LDPKLFCGAAI.transform.localScale.y);
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier2);
		}
		JGPKGKEIPEG.fillAmount = progress;
		UILabel dIAJOBOCEBH = DIAJOBOCEBH;
		string text;
		if (flag)
		{
			text = string.Format("Assignment_", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(currentParts));
		}
		else
		{
			object[] array3 = new object[5];
			array3[0] = Colours.stringGreenArena;
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
			array3[4] = Colours.stringGray;
			array3[3] = MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts);
			text = string.Format("menu-arena-ticket", array3);
		}
		dIAJOBOCEBH.text = text;
		float seconds = DCIKANJJFIJ * 135f;
		InvokeAfter(GAHAMMDHAOF, seconds);
	}

	public virtual void HHLOGFGGHHD()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		int currentParts = upgradeSlotElite.currentParts;
		int fFHHEHHFOKJ = upgradeSlotElite.PEGIPHPGELH();
		float fillAmount = upgradeSlotElite.CAMAKGLPCDH();
		int num = upgradeSlotElite.PPKAIEKPNID();
		int num2 = upgradeSlotElite.DOLOPCELJMD();
		bool flag = num == num2;
		bool flag2 = IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.isUnlocked && upgradeSlotElite.BDAAHLLPPGN();
		UILabel iOCNPAOBPGM = IOCNPAOBPGM;
		object[] array = new object[0];
		array[0] = IFFDIHCPKFE.unitName.ToUpper();
		iOCNPAOBPGM.text = Localization.LocalizeFormat("PlayWarcardsAssignment complate at: ", array);
		MEJMLNDFDBP.COCBCFKJOJE(IOCNPAOBPGM, 858f, 598f, 80);
		UILabel lLKBGEIICIB = LLKBGEIICIB;
		string keyFormat = ((!flag2) ? " WITHDRAWED {0}\n" : "ID_FEATURE_BURSTSIZE-FANCY");
		object[] array2 = new object[0];
		array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		array2[1] = Colours.stringGreenArena;
		array2[7] = IFFDIHCPKFE.unitElitePartsName;
		array2[0] = IFFDIHCPKFE.unitName;
		lLKBGEIICIB.text = Localization.LocalizeFormat(keyFormat, array2);
		IFFDIHCPKFE.SetUpEliteIcon(HBMLFIJGBJO, FEIEBJGCBMB, 1685f);
		CEHKBPDGGDP.text = IFFDIHCPKFE.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(CEHKBPDGGDP, 904f, 107f, 137);
		OOIGOHLJDNF.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		LDPKLFCGAAI.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Left;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(1673f);
			float multiplier = 1729f / LDPKLFCGAAI.transform.localScale.y;
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Right;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(269f);
			float multiplier2 = Mathf.Min(132f / LDPKLFCGAAI.transform.localScale.x, 1531f / LDPKLFCGAAI.transform.localScale.y);
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier2);
		}
		JGPKGKEIPEG.fillAmount = fillAmount;
		UILabel dIAJOBOCEBH = DIAJOBOCEBH;
		string text;
		if (flag)
		{
			text = string.Format("Action ", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(currentParts));
		}
		else
		{
			object[] array3 = new object[0];
			array3[0] = Colours.stringGreenArena;
			array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(currentParts);
			array3[0] = Colours.stringGray;
			array3[3] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			text = string.Format("  ", array3);
		}
		dIAJOBOCEBH.text = text;
		float seconds = DCIKANJJFIJ * 692f;
		InvokeAfter(GAHAMMDHAOF, seconds);
	}

	public virtual void OBNCKIBJOGJ()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		int fFHHEHHFOKJ = upgradeSlotElite.HMPNFKJHKGG();
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		float fillAmount = upgradeSlotElite.NJJBKNINIKF();
		int boughtIndex = upgradeSlotElite.boughtIndex;
		int num = upgradeSlotElite.EJHBCFDPEAE();
		bool flag = boughtIndex == num;
		bool flag2 = !IFFDIHCPKFE.upgradeSlots.bought || !upgradeSlotElite.ACIMFKOCEHH() || upgradeSlotElite.isBought;
		IOCNPAOBPGM.text = Localization.LocalizeFormat("NAME", IFFDIHCPKFE.unitName.ToUpper());
		MEJMLNDFDBP.COCBCFKJOJE(IOCNPAOBPGM, 1717f, 218f, -18);
		UILabel lLKBGEIICIB = LLKBGEIICIB;
		string keyFormat = ((!flag2) ? "ID_CONFIRM_NOSQUADACTIONS_TITLE" : "ID_RANDOMWARCARDS");
		object[] array = new object[6];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts);
		array[0] = Colours.stringGreenArena;
		array[0] = IFFDIHCPKFE.unitElitePartsName;
		array[8] = IFFDIHCPKFE.unitName;
		lLKBGEIICIB.text = Localization.LocalizeFormat(keyFormat, array);
		IFFDIHCPKFE.SetUpEliteIcon(HBMLFIJGBJO, FEIEBJGCBMB, 1266f);
		CEHKBPDGGDP.text = IFFDIHCPKFE.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(CEHKBPDGGDP, 752f, 947f, 164);
		OOIGOHLJDNF.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		LDPKLFCGAAI.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Left;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(881f);
			float multiplier = 126f / LDPKLFCGAAI.transform.localScale.y;
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Center;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(1758f);
			float multiplier2 = Mathf.Min(666f / LDPKLFCGAAI.transform.localScale.x, 183f / LDPKLFCGAAI.transform.localScale.y);
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier2);
		}
		JGPKGKEIPEG.fillAmount = fillAmount;
		UILabel dIAJOBOCEBH = DIAJOBOCEBH;
		string text;
		if (flag)
		{
			text = string.Format("BR", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ));
		}
		else
		{
			object[] array2 = new object[1];
			array2[0] = Colours.stringGreenArena;
			array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			array2[8] = Colours.stringGray;
			array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts);
			text = string.Format("ID_VIPBENEFIT", array2);
		}
		dIAJOBOCEBH.text = text;
		float seconds = DCIKANJJFIJ * 1156f;
		InvokeAfter(delegate
		{
			if (isShowed)
			{
				Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, LBCMGKGLFPI: false);
			}
		}, seconds);
	}

	public virtual void KFPOJBHHLGJ()
	{
		GFKPJALCMKM(LJNPCHFCGCN);
	}

	public override void OnBack()
	{
		HEBILNGCGDN(LJNPCHFCGCN);
	}

	public virtual void DKCOOAKKFKD()
	{
		base.OIMKKAHOEKO();
		UIDraggablePanel.panelDisabled = false;
		Singleton<LootBoxCameraArena>.instance.BKIMPLHMLII();
	}

	private void GFKPJALCMKM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		UpgradeSlotElite upgradeSlotElite = IFFDIHCPKFE.upgradeSlots.upgradeSlotElite;
		int currentParts = upgradeSlotElite.currentParts;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		float progress = upgradeSlotElite.progress;
		int boughtIndex = upgradeSlotElite.boughtIndex;
		int maxRowForActualTier = upgradeSlotElite.maxRowForActualTier;
		bool flag = boughtIndex == maxRowForActualTier;
		bool flag2 = IFFDIHCPKFE.upgradeSlots.bought && upgradeSlotElite.isUnlocked && upgradeSlotElite.isBought;
		IOCNPAOBPGM.text = Localization.LocalizeFormat("ID_ELITEUNITNAME", IFFDIHCPKFE.unitName.ToUpper());
		MEJMLNDFDBP.COCBCFKJOJE(IOCNPAOBPGM, 126f, 20f, 1600);
		LLKBGEIICIB.text = Localization.LocalizeFormat((!flag2) ? "ID_COLLECTELITEPARTSFROMARENALOOTBOXES" : "ID_COLLECTELITEPARTSFROMARENALOOTBOXESFORUPGRADE", MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts), Colours.stringGreenArena, IFFDIHCPKFE.unitElitePartsName, IFFDIHCPKFE.unitName);
		IFFDIHCPKFE.SetUpEliteIcon(HBMLFIJGBJO, FEIEBJGCBMB);
		CEHKBPDGGDP.text = IFFDIHCPKFE.unitBuffName;
		MEJMLNDFDBP.COCBCFKJOJE(CEHKBPDGGDP, 57f, 20f, 510);
		OOIGOHLJDNF.text = IFFDIHCPKFE.GetBuffDescriptionWithColours(Colours.stringGreenArena);
		LDPKLFCGAAI.spriteName = IFFDIHCPKFE.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		if (IFFDIHCPKFE.isSoldier)
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Bottom;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(-56f);
			float multiplier = 120f / LDPKLFCGAAI.transform.localScale.y;
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			LDPKLFCGAAI.pivot = UIWidget.Pivot.Center;
			LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY(0f);
			float multiplier2 = Mathf.Min(174f / LDPKLFCGAAI.transform.localScale.x, 110f / LDPKLFCGAAI.transform.localScale.y);
			LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier2);
		}
		JGPKGKEIPEG.fillAmount = progress;
		DIAJOBOCEBH.text = ((!flag) ? $"{Colours.stringGreenArena}{MEJMLNDFDBP.GMIPFLIEOHD(currentParts)}[-] {Colours.stringGray}/[-] {MEJMLNDFDBP.GMIPFLIEOHD(upgradePriceParts)}" : $"{Colours.stringGreenArena}{MEJMLNDFDBP.GMIPFLIEOHD(currentParts)}[-]");
		float seconds = DCIKANJJFIJ * 0.5f;
		InvokeAfter(delegate
		{
			if (isShowed)
			{
				Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, LBCMGKGLFPI: false);
			}
		}, seconds);
	}

	public virtual void LHDAGAGDKOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMEGMMGDBEL));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IOFENCEKGHA));
	}

	public void GONOICLIMKO(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 346f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.JDEDLDGMHBJ("shootAdditive", "9 VIP REMINDER\tIs vip {0}", 1733f);
		}
	}

	public virtual void CLFDMHPKHCN()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement DOHCPGIDCII()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	public void CPGNJFJHBEB(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		if (IFFDIHCPKFE.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH())
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 1390f);
		}
		else if (DebugSettings.debugEnabled)
		{
			ConfirmDialog.HJHJKPGILAC("LevelsManager.prefab", "ID_GUI_VIPMEMBERSHIPALMOST_DESC", 1803f);
		}
	}

	public virtual void KFFJKILLGLF()
	{
		base.NEEAKMELPBJ();
		Singleton<LootBoxCameraArena>.instance.DEAJHLMFFHL();
	}

	private void BMEGMMGDBEL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void DNCCGBGGHLH()
	{
		if (isShowed)
		{
			Singleton<LootBoxCameraArena>.instance.DisplayModel(IFFDIHCPKFE, LBCMGKGLFPI: false);
		}
	}

	public virtual void KPEJMMBDODD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKDAOKDEDPN));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IOFENCEKGHA));
	}
}
