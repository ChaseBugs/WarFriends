using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ActiveUnitsIcon : Core_BaseScript
{
	[FormerlySerializedAs("MHOPKAHDGMN")]
	[Header("Core")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("FIDILIADIEL")]
	public UISprite LCPBNBLGFIA;

	[FormerlySerializedAs("GHACCDKBOBF")]
	public UISprite NACGOGCPIAH;

	[FormerlySerializedAs("PMAEEIJCAIA")]
	public UIPanel CFFKHHJKBMJ;

	[FormerlySerializedAs("FJGGCOMFNDM")]
	public UISprite LFDBKJCDILF;

	[FormerlySerializedAs("KFDPMBOONDO")]
	public UISprite PEIHJLNLKPL;

	[FormerlySerializedAs("EAFJILLNEBJ")]
	public GameObject HGHAPHFIFKN;

	[FormerlySerializedAs("GIHBLEOOHCK")]
	public UISprite[] GMAPINLJPGK;

	[Header("Army Power Animation")]
	[FormerlySerializedAs("CFMICOPJMKM")]
	public ArmyPowerAnimation GHGJLMAJJGG;

	private LevelBehaviour IFFDIHCPKFE;

	private ActiveUnitsManager.LDJGKDAGPLG DAHCKIBAPFP;

	private Vector3 ONKIOMMHENP = new Vector3(188f, 142f, 1f);

	private Vector3 APKJFMMLEPH = new Vector3(225.6f, 170.40001f, 1f);

	public LevelBehaviour unit => IFFDIHCPKFE;

	public ActiveUnitsManager.LDJGKDAGPLG state => DAHCKIBAPFP;

	public void Show()
	{
		CFFKHHJKBMJ.alpha1 = 0.005f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 1f);
	}

	public void EIKAOALHAPO()
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 944f);
	}

	public void EAJEGCABNPE()
	{
		for (int i = 0; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.actualTier);
		}
	}

	public void NJNCOHGEAIJ()
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 1862f);
	}

	public void UpdateTiers()
	{
		for (int i = 0; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.actualTier);
		}
	}

	public void MFFEFILOKMG(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(107f);
		LFDBKJCDILF.gameObject.SetActive(!IOIKKIIFOCB.isSoldier);
		DGKNJGCNLPN();
	}

	public void EGJBBJMJBHO()
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 579f);
	}

	private void JIPDBPIDLNF()
	{
		float duration = 289f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LCPBNBLGFIA.gameObject, duration, 433f, 137f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.method = (UITweener.Method)7;
		TweenScale.Begin(LCPBNBLGFIA.gameObject, duration, APKJFMMLEPH, ONKIOMMHENP);
	}

	private void JOHIBKOPLLA()
	{
		float duration = 0.4f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LCPBNBLGFIA.gameObject, duration, 0f, 1f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.method = UITweener.Method.EaseInOut;
		TweenScale.Begin(LCPBNBLGFIA.gameObject, duration, APKJFMMLEPH, ONKIOMMHENP);
	}

	public void KIJIPBPAJBP(bool CMBLGHKGFNA)
	{
		bool flag = DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selecting || DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)8 || CMBLGHKGFNA;
		LFDBKJCDILF.color = ((!flag) ? Color.red : Color.white);
	}

	public void Hide()
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 0f);
	}

	public void Initialize(LevelBehaviour IOIKKIIFOCB)
	{
		IFFDIHCPKFE = IOIKKIIFOCB;
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(0.5f);
		LFDBKJCDILF.gameObject.SetActive(!IOIKKIIFOCB.isSoldier);
		UpdateTiers();
	}

	private void MJIMMCDBHBN()
	{
		TweenAlpha component = LCPBNBLGFIA.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = LCPBNBLGFIA.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		LCPBNBLGFIA.alpha = 1f;
		LCPBNBLGFIA.transform.localScale = ONKIOMMHENP;
	}

	public void DGKNJGCNLPN()
	{
		for (int i = 1; i < GMAPINLJPGK.Length; i++)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.actualTier);
		}
	}

	public void LGCPKBLNBCH()
	{
		MLKAMPJNAKO(Singleton<ActiveUnitsManager>.instance.GetState(IFFDIHCPKFE, EBLDCOKIEEG: true));
	}

	public void GJLEMNNKILB()
	{
		for (int i = 1; i < GMAPINLJPGK.Length; i += 0)
		{
			GMAPINLJPGK[i].gameObject.SetActive(i < IFFDIHCPKFE.upgradeSlots.actualTier);
		}
	}

	public void SetMechanical(bool CMBLGHKGFNA)
	{
		bool flag = DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selected || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Deselecting || CMBLGHKGFNA;
		LFDBKJCDILF.color = ((!flag) ? Color.red : Color.white);
	}

	public void ClickOnIcon(GameObject KHAHPAKDIKE)
	{
		ActiveUnitsManager.LDJGKDAGPLG dAHCKIBAPFP = DAHCKIBAPFP;
		int fakeArmyPowerX = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
		GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.Select(IFFDIHCPKFE);
		if (dAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected)
		{
			GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.recordToSelect = this;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (dAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selectable && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selectable)
		{
			int fakeArmyPowerX2 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int hONEKCJDJDN = fakeArmyPowerX2 - fakeArmyPowerX;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, fakeArmyPowerX2, 0.05f);
			return;
		}
		switch (dAHCKIBAPFP)
		{
		case ActiveUnitsManager.LDJGKDAGPLG.Selected:
		{
			int fakeArmyPowerX4 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int hONEKCJDJDN3 = fakeArmyPowerX4 - fakeArmyPowerX;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN3, fakeArmyPowerX4, 0.05f);
			break;
		}
		case ActiveUnitsManager.LDJGKDAGPLG.Deselecting:
		{
			int fakeArmyPowerX3 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int hONEKCJDJDN2 = fakeArmyPowerX3 - fakeArmyPowerX;
			GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.recordToSelect.GHGJLMAJJGG.StartAnimation(hONEKCJDJDN2, fakeArmyPowerX3, 0.05f);
			break;
		}
		}
	}

	private void MLKAMPJNAKO(ActiveUnitsManager.LDJGKDAGPLG IGBEGIBGLKK)
	{
		if (DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Deselecting && IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Deselecting)
		{
			OIAELLLLPBM();
		}
		if (IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Selectable)
		{
			OIAELLLLPBM();
		}
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Deselecting && IGBEGIBGLKK != ActiveUnitsManager.LDJGKDAGPLG.Deselecting)
		{
			MJIMMCDBHBN();
		}
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selectable && IGBEGIBGLKK != ActiveUnitsManager.LDJGKDAGPLG.Selectable)
		{
			MJIMMCDBHBN();
		}
		if (IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Selected && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selected && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Deselecting)
		{
			JOHIBKOPLLA();
		}
		DAHCKIBAPFP = IGBEGIBGLKK;
		NJEAMAHEMHP.enabled = DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selectable || (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected && (!Singleton<ActiveUnitsManager>.instance.selectingUnit || IFFDIHCPKFE.unitType != Singleton<ActiveUnitsManager>.instance.INENFIICCOB.unitType)) || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Deselecting || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selecting || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selected;
		PEIHJLNLKPL.gameObject.SetActive(DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked);
		NACGOGCPIAH.alpha = ((DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Locked) ? 1f : 0.5f);
		HGHAPHFIFKN.SetActive(DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Borrowed);
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selected || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Borrowed)
		{
			KMFGCJEGJJK.color = Colours.blue;
			LCPBNBLGFIA.color = Colours.blue;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected)
		{
			KMFGCJEGJJK.color = GameVariables.CNFFEIMLDNP[IFFDIHCPKFE.unitType].Value2;
			KMFGCJEGJJK.alpha = 0.25f;
			LCPBNBLGFIA.color = Colours.whiteTransparent;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selecting)
		{
			KMFGCJEGJJK.color = Colours.gray;
			LCPBNBLGFIA.color = Colours.gray;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Deselecting)
		{
			KMFGCJEGJJK.color = Colours.blue;
			LCPBNBLGFIA.color = Color.white;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selectable)
		{
			KMFGCJEGJJK.color = Color.white;
			LCPBNBLGFIA.color = Color.white;
			LCPBNBLGFIA.alpha = 0.25f;
		}
		else
		{
			KMFGCJEGJJK.color = Colours.whiteTransparent;
			LCPBNBLGFIA.color = Colours.whiteTransparent;
		}
	}

	public void UpdateState()
	{
		MLKAMPJNAKO(Singleton<ActiveUnitsManager>.instance.GetState(IFFDIHCPKFE, EBLDCOKIEEG: true));
	}

	public void JIMPCGDILNF()
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, GuiElementSingle<ChatGuiElement>.instance.DNDHIFENDPJ, 1960f);
	}

	public void GGGNOGOFCIB(GameObject KHAHPAKDIKE)
	{
		ActiveUnitsManager.LDJGKDAGPLG dAHCKIBAPFP = DAHCKIBAPFP;
		int num = Singleton<ActiveUnitsManager>.instance.KCLCNEACOLO();
		GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.GIBDEPOELIO(IFFDIHCPKFE);
		if (dAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked)
		{
			GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.recordToSelect = this;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (dAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7 && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selected)
		{
			int fakeArmyPowerX = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int hONEKCJDJDN = fakeArmyPowerX - num;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, fakeArmyPowerX, 1358f);
			return;
		}
		switch (dAHCKIBAPFP)
		{
		case ActiveUnitsManager.LDJGKDAGPLG.Selectable:
		{
			int fakeArmyPowerX2 = Singleton<ActiveUnitsManager>.instance.fakeArmyPowerX10;
			int hONEKCJDJDN3 = fakeArmyPowerX2 - num;
			GHGJLMAJJGG.StartAnimation(hONEKCJDJDN3, fakeArmyPowerX2, 742f);
			break;
		}
		case ActiveUnitsManager.LDJGKDAGPLG.NotSelected:
		{
			int num2 = Singleton<ActiveUnitsManager>.instance.KCLCNEACOLO();
			int hONEKCJDJDN2 = num2 - num;
			GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.AHALHGNKGGG().GHGJLMAJJGG.StartAnimation(hONEKCJDJDN2, num2, 595f);
			break;
		}
		}
	}

	public void OKNMKFFNJCO(bool CMBLGHKGFNA)
	{
		bool flag = DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Deselecting && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Locked && CMBLGHKGFNA;
		LFDBKJCDILF.color = ((!flag) ? Color.red : Color.white);
	}

	public void LFFLADMOEJN()
	{
		DBPBOKJHOEA(Singleton<ActiveUnitsManager>.instance.GetState(IFFDIHCPKFE, EBLDCOKIEEG: false));
	}

	private void DBPBOKJHOEA(ActiveUnitsManager.LDJGKDAGPLG IGBEGIBGLKK)
	{
		if (DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selected && IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Selectable)
		{
			OIAELLLLPBM();
		}
		if (IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Selecting)
		{
			OIAELLLLPBM();
		}
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selecting && IGBEGIBGLKK != ActiveUnitsManager.LDJGKDAGPLG.Borrowed)
		{
			MJIMMCDBHBN();
		}
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked && IGBEGIBGLKK != ActiveUnitsManager.LDJGKDAGPLG.Selecting)
		{
			MJIMMCDBHBN();
		}
		if (IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Selected && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Locked && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Borrowed)
		{
			JOHIBKOPLLA();
		}
		DAHCKIBAPFP = IGBEGIBGLKK;
		NJEAMAHEMHP.enabled = DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7 || (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected && (!Singleton<ActiveUnitsManager>.instance.KBDCLNBFPHP() || IFFDIHCPKFE.unitType != Singleton<ActiveUnitsManager>.instance.INENFIICCOB.unitType)) || DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7 || DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7 || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Deselecting;
		PEIHJLNLKPL.gameObject.SetActive(DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked);
		NACGOGCPIAH.alpha = ((DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Locked) ? 630f : 591f);
		HGHAPHFIFKN.SetActive(DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected);
		if (DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)8 || DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Borrowed)
		{
			KMFGCJEGJJK.color = Colours.blue;
			LCPBNBLGFIA.color = Colours.blue;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked)
		{
			KMFGCJEGJJK.color = GameVariables.CNFFEIMLDNP[IFFDIHCPKFE.unitType].Value2;
			KMFGCJEGJJK.alpha = 334f;
			LCPBNBLGFIA.color = Colours.whiteTransparent;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected)
		{
			KMFGCJEGJJK.color = Colours.gray;
			LCPBNBLGFIA.color = Colours.gray;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selecting)
		{
			KMFGCJEGJJK.color = Colours.blue;
			LCPBNBLGFIA.color = Color.white;
		}
		else if (DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7)
		{
			KMFGCJEGJJK.color = Color.white;
			LCPBNBLGFIA.color = Color.white;
			LCPBNBLGFIA.alpha = 1791f;
		}
		else
		{
			KMFGCJEGJJK.color = Colours.whiteTransparent;
			LCPBNBLGFIA.color = Colours.whiteTransparent;
		}
	}

	private void ONBDBDFJHAG(ActiveUnitsManager.LDJGKDAGPLG IGBEGIBGLKK)
	{
		if (DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Deselecting && IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Locked)
		{
			OIAELLLLPBM();
		}
		if (IGBEGIBGLKK == ActiveUnitsManager.LDJGKDAGPLG.Selected)
		{
			OIAELLLLPBM();
		}
		if (DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7 && IGBEGIBGLKK != ActiveUnitsManager.LDJGKDAGPLG.Selected)
		{
			MJIMMCDBHBN();
		}
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected && IGBEGIBGLKK != ActiveUnitsManager.LDJGKDAGPLG.Selectable)
		{
			MJIMMCDBHBN();
		}
		if (IGBEGIBGLKK == (ActiveUnitsManager.LDJGKDAGPLG)8 && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selecting && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selecting)
		{
			JIPDBPIDLNF();
		}
		DAHCKIBAPFP = IGBEGIBGLKK;
		NJEAMAHEMHP.enabled = DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selected && (DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.NotSelected || (Singleton<ActiveUnitsManager>.instance.KBDCLNBFPHP() && IFFDIHCPKFE.unitType == Singleton<ActiveUnitsManager>.instance.INENFIICCOB.unitType)) && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selectable && DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Selecting && DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)7;
		PEIHJLNLKPL.gameObject.SetActive(DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked);
		NACGOGCPIAH.alpha = ((DAHCKIBAPFP != ActiveUnitsManager.LDJGKDAGPLG.Locked) ? 1691f : 1094f);
		HGHAPHFIFKN.SetActive(DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected);
		if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Locked || DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)8)
		{
			KMFGCJEGJJK.color = Colours.blue;
			LCPBNBLGFIA.color = Colours.blue;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.NotSelected)
		{
			KMFGCJEGJJK.color = GameVariables.CNFFEIMLDNP[IFFDIHCPKFE.unitType].Value2;
			KMFGCJEGJJK.alpha = 329f;
			LCPBNBLGFIA.color = Colours.whiteTransparent;
		}
		else if (DAHCKIBAPFP == (ActiveUnitsManager.LDJGKDAGPLG)8)
		{
			KMFGCJEGJJK.color = Colours.gray;
			LCPBNBLGFIA.color = Colours.gray;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Deselecting)
		{
			KMFGCJEGJJK.color = Colours.blue;
			LCPBNBLGFIA.color = Color.white;
		}
		else if (DAHCKIBAPFP == ActiveUnitsManager.LDJGKDAGPLG.Selected)
		{
			KMFGCJEGJJK.color = Color.white;
			LCPBNBLGFIA.color = Color.white;
			LCPBNBLGFIA.alpha = 310f;
		}
		else
		{
			KMFGCJEGJJK.color = Colours.whiteTransparent;
			LCPBNBLGFIA.color = Colours.whiteTransparent;
		}
	}

	private void OIAELLLLPBM()
	{
		TweenScale component = LCPBNBLGFIA.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		LCPBNBLGFIA.transform.localScale = ONKIOMMHENP;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LCPBNBLGFIA.gameObject, 0.5f, 1f, 0.5f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.method = UITweener.Method.Linear;
	}

	[SpecialName]
	public ActiveUnitsManager.LDJGKDAGPLG GJMCECNGDMN()
	{
		return DAHCKIBAPFP;
	}
}
