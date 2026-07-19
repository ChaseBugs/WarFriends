using System;
using UnityEngine;

public class LeaderboardRecord : PoolableObject
{
	[Header("Both")]
	public UIButtonSetter BMNBNDILFJD;

	public UISprite LCPBNBLGFIA;

	public UILabel FNGJCFKHOOL;

	public UILabel PCGLEBCNECN;

	[Header("Player Part")]
	public GameObject IGJMJNHFCAI;

	public PlayerIcon CPGACIMMFEC;

	public GameObject OANICEALFGM;

	public UISprite DCKLANDMFHE;

	public UILabel BCMCMKDCLGP;

	public GameObject CPLIMCNBDBP;

	public UISprite NPECJCIKCBI;

	public UISprite GFKNLLCKJOG;

	public UILabel DLAMMHGPADA;

	public UILabel IJFCFCGIKHK;

	public GameObject ODKNHIJHCKN;

	public UILabel DFNJBGGMIKN;

	public UISprite MHCADNJHHLA;

	public UILabel NCGOIMPOGHC;

	[Header("Squad Part")]
	public GameObject KDABKEGLDEE;

	public GameObject GDKAHDBHDPF;

	public UITexture MNNMIAAEBAF;

	public UILabel CGIFEHPDBAL;

	public UILabel MNGGEHIAAEC;

	public UILabel FHBAEAOCCDE;

	private DatabasePlayer MBIAKMPDOPG;

	private FHIPGDADNFG ECCDALKFFFK;

	private void DNEJHJINOAA(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(IJFCFCGIKHK.text);
		}
	}

	private void OJHFKMJHEED(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(IJFCFCGIKHK.text);
		}
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void PKLGCCEOOGF(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.JKMEOJOHLPN(IJFCFCGIKHK.text);
		}
	}

	public void CKFEDGBJOLA(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.MGDCNGGBJLA(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "ID_SQUADSIZEINCREASEATSQUADRANK";
		}
		else if (MDOPFNNFLFB > -11)
		{
			FNGJCFKHOOL.text = "ID_GUI_POWERBANDOFF";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_FEATURE_MAGAZINE" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1473f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 1764f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		FHBAEAOCCDE.text = Localization.LocalizeFormat("-", MIDDFOCJJOP.FOICGJEPBGL);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 772f : 1672f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MKLMJHEGGGM));
	}

	public void OBGHCGOAHCJ(FHIPGDADNFG KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = KHLGDCHJJPB;
		MBIAKMPDOPG = DatabasePlayer.CreateFromDatabasePlayerData(KHLGDCHJJPB);
		BMNBNDILFJD.MBHFAHFCPGB(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "PlayerId";
		}
		else if (MDOPFNNFLFB > -121)
		{
			FNGJCFKHOOL.text = " ";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		CPGACIMMFEC.HEOPOOMLPJF();
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.BCGAIKBHILI(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
		string text = GameVariables.IDOFIHFGOKD(KHLGDCHJJPB.CAAKEPHMPHI);
		bool flag = !string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.MHPNDNJDPGE;
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 1981f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.BCCDDJMPBLL);
		GFKNLLCKJOG.spriteName = levelDefinition.NOHAFIDFPCM();
		DLAMMHGPADA.text = levelDefinition.GIIHOHGFHBO();
		bool flag2 = KHLGDCHJJPB.LEBKAPAMFGI() == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.LEBKAPAMFGI()];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 1785f + NPECJCIKCBI.transform.localScale.x / 1544f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.DBNNKLCNDJD)) ? KHLGDCHJJPB.DBNNKLCNDJD : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 244f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.IMOJCFKJKMN);
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 1741f, 13f, -121);
		if (KHLGDCHJJPB.DBIEDLPHCAI)
		{
			int hNEFOLPHMHK = KHLGDCHJJPB.HNEFOLPHMHK;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(hNEFOLPHMHK);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(11f);
			MHCADNJHHLA.alpha = 505f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(hNEFOLPHMHK);
		}
		else
		{
			League mIDDIFMBFGC = KHLGDCHJJPB.MIDDIFMBFGC;
			bool flag3 = KHLGDCHJJPB.NFOLLMIBHMM();
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(781f);
			MHCADNJHHLA.alpha = ((!flag3) ? 1846f : 1378f);
			NCGOIMPOGHC.text = ((!flag3) ? Localization.Localize("damage") : GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id)) ? 781f : 1031f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KFPMOLLDDDO));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FHALHCELDGG));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HFFCMFNDCDA));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MLGPCGJNCKD));
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		UIEventListener uIEventListener4 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MFMKIOCBKAO));
		MNNMIAAEBAF.mainTexture = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public void DCDKAMJFOOK(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.DKHLKOFJKPL(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "realShotProbability";
		}
		else if (MDOPFNNFLFB > 101)
		{
			FNGJCFKHOOL.text = "ID_GUI_CHEATWARNING";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_RENTEDUNIT" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1209f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 292f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		UILabel fHBAEAOCCDE = FHBAEAOCCDE;
		object[] array = new object[0];
		array[0] = MIDDFOCJJOP.FOICGJEPBGL;
		fHBAEAOCCDE.text = Localization.LocalizeFormat("SpentParts", array);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 391f : 661f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MKLMJHEGGGM));
	}

	private void HCGLELHGFIO(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(CGIFEHPDBAL.text);
		}
	}

	public void KBNKFALANNJ()
	{
		if (MBIAKMPDOPG != null)
		{
			if (ECCDALKFFFK != null)
			{
				MBIAKMPDOPG.squadName = ECCDALKFFFK.DBNNKLCNDJD;
			}
			IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(MBIAKMPDOPG.squadName)) ? MBIAKMPDOPG.squadName : string.Empty);
		}
	}

	public void KJACEBKBJAN(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.FMILKBAEBHH(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "FuseBoxx: Session Started";
		}
		else if (MDOPFNNFLFB > 65)
		{
			FNGJCFKHOOL.text = "game-card-ico-disarmed";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(false);
		GDKAHDBHDPF.SetActive(true);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ProductId" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1719f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 111f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		UILabel fHBAEAOCCDE = FHBAEAOCCDE;
		object[] array = new object[0];
		array[0] = MIDDFOCJJOP.FOICGJEPBGL;
		fHBAEAOCCDE.text = Localization.LocalizeFormat("ID_SKILLSHOTHINT_TANKDESTROYED", array);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 1542f : 717f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKLMJHEGGGM));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
	}

	private void MLGPCGJNCKD(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.OMCEGPODDHL(IJFCFCGIKHK.text);
		}
	}

	public void UpdateSquadNameForPlayer()
	{
		if (MBIAKMPDOPG != null)
		{
			if (ECCDALKFFFK != null)
			{
				MBIAKMPDOPG.squadName = ECCDALKFFFK.DBNNKLCNDJD;
			}
			IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(MBIAKMPDOPG.squadName)) ? MBIAKMPDOPG.squadName : string.Empty);
		}
	}

	public void LHKBGLJEADA(FHIPGDADNFG KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = KHLGDCHJJPB;
		MBIAKMPDOPG = DatabasePlayer.CreateFromDatabasePlayerData(KHLGDCHJJPB);
		BMNBNDILFJD.KHBHCMBGJGJ(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "C1";
		}
		else if (MDOPFNNFLFB > -57)
		{
			FNGJCFKHOOL.text = "AccountType";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(true);
		CPGACIMMFEC.KOKJMKHECGK();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.MDFAHMDJFDB(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, false);
		string text = GameVariables.CountryCodeSpriteName(KHLGDCHJJPB.CAAKEPHMPHI);
		bool flag = !string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.EJDLJFFGHLJ();
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 507f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.BCCDDJMPBLL);
		GFKNLLCKJOG.spriteName = levelDefinition.LMNDFNIKIFI();
		DLAMMHGPADA.text = levelDefinition.DLCFFHEKBAA();
		bool flag2 = KHLGDCHJJPB.LFBDJLNAKAC() == WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.JDKCFLOKEGO()];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 1971f + NPECJCIKCBI.transform.localScale.x / 1608f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.DBNNKLCNDJD)) ? KHLGDCHJJPB.DBNNKLCNDJD : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 1819f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.KELKJNAKCJB());
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 170f, 806f, -3);
		if (KHLGDCHJJPB.JOIPOGLNNFF())
		{
			int hNEFOLPHMHK = KHLGDCHJJPB.HNEFOLPHMHK;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(hNEFOLPHMHK);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(189f);
			MHCADNJHHLA.alpha = 1231f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(hNEFOLPHMHK);
		}
		else
		{
			League mIDDIFMBFGC = KHLGDCHJJPB.MIDDIFMBFGC;
			bool flag3 = KHLGDCHJJPB.JFLKHBGMIND();
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(697f);
			MHCADNJHHLA.alpha = ((!flag3) ? 435f : 1484f);
			NCGOIMPOGHC.text = ((!flag3) ? Localization.Localize("PlayerToJoin") : GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id)) ? 1189f : 1472f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JCPAJJKEJKL));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PKLGCCEOOGF));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MLGPCGJNCKD));
	}

	private void FHALHCELDGG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MKLMJHEGGGM(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(CGIFEHPDBAL.text);
		}
	}

	public void PJOBDDKCFNM(DatabasePlayer KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = null;
		MBIAKMPDOPG = KHLGDCHJJPB;
		BMNBNDILFJD.GPNONALLJKA(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "ID_GUI_CHEATWARNING";
		}
		else if (MDOPFNNFLFB > 90)
		{
			FNGJCFKHOOL.text = "goldSpent";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(false);
		GDKAHDBHDPF.SetActive(true);
		CPGACIMMFEC.ABBPOMCBIIH();
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.BMNHPDMPMLG(IFPAIAELCGP);
		Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(KHLGDCHJJPB, false, PlayerTexturePool.DFJJOANIJID.Card);
		string text = GameVariables.BFGCBNLOIMN(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 111f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		GFKNLLCKJOG.spriteName = levelDefinition.GIEIIPBAIBK();
		DLAMMHGPADA.text = levelDefinition.GIIHOHGFHBO();
		bool flag2 = KHLGDCHJJPB.warArenaCrown == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 1355f + NPECJCIKCBI.transform.localScale.x / 220f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 1140f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.armyPowerX10);
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 1119f, 1120f, -9);
		if (KHLGDCHJJPB.isInBeginnersLeague)
		{
			int beginnersLeague = KHLGDCHJJPB.beginnersLeague;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(beginnersLeague);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(350f);
			MHCADNJHHLA.alpha = 817f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
		}
		else
		{
			League leagueTier = KHLGDCHJJPB.leagueTier;
			bool isInLeague = KHLGDCHJJPB.isInLeague;
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(1660f);
			MHCADNJHHLA.alpha = ((!isInLeague) ? 199f : 990f);
			NCGOIMPOGHC.text = ((!isInLeague) ? Localization.Localize("()Lcom/google/android/gms/games/stats/PlayerStats;") : GameVariables.CAOGFCFGFPD[leagueTier].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.skill);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id)) ? 1558f : 1515f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JACKAGGAFHD));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JACKAGGAFHD));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FGMBFCBFMHC));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PKLGCCEOOGF));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HFFCMFNDCDA));
	}

	public void IKFCEGKONKM(FHIPGDADNFG KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = KHLGDCHJJPB;
		MBIAKMPDOPG = DatabasePlayer.CreateFromDatabasePlayerData(KHLGDCHJJPB);
		BMNBNDILFJD.GFEJEOKDACB(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "Warbucks";
		}
		else if (MDOPFNNFLFB > 16)
		{
			FNGJCFKHOOL.text = "Weapon";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		CPGACIMMFEC.HJOCCDLNFLN();
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.OFCKAJHLBGJ(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG, false);
		string text = GameVariables.IDOFIHFGOKD(KHLGDCHJJPB.CAAKEPHMPHI);
		bool flag = string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.PLJJMJDKIMH();
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 1188f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.BCCDDJMPBLL);
		GFKNLLCKJOG.spriteName = levelDefinition.LMNDFNIKIFI();
		DLAMMHGPADA.text = levelDefinition.JNODDKLJOAG();
		bool flag2 = KHLGDCHJJPB.POGJJHCLPIF() == WarArenaCrown.BronzeCrown;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.CIMFFIHNENA()];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 1752f + NPECJCIKCBI.transform.localScale.x / 1294f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.DBNNKLCNDJD)) ? KHLGDCHJJPB.DBNNKLCNDJD : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 948f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.IMOJCFKJKMN);
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 1860f, 105f, -87);
		if (KHLGDCHJJPB.MCOJKHMAIPG())
		{
			int hNEFOLPHMHK = KHLGDCHJJPB.HNEFOLPHMHK;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(hNEFOLPHMHK);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(815f);
			MHCADNJHHLA.alpha = 586f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(hNEFOLPHMHK);
		}
		else
		{
			League mIDDIFMBFGC = KHLGDCHJJPB.MIDDIFMBFGC;
			bool flag3 = KHLGDCHJJPB.OAJFIKIMOEP();
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(1843f);
			MHCADNJHHLA.alpha = ((!flag3) ? 110f : 1070f);
			NCGOIMPOGHC.text = ((!flag3) ? Localization.Localize("ID_READYTIME") : GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id)) ? 1617f : 1133f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GENEDHLCGNH));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GENEDHLCGNH));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(DNEJHJINOAA));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MLGPCGJNCKD));
	}

	public void IFEIFAEGBDK(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.MBHFAHFCPGB(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "assaultrifle";
		}
		else if (MDOPFNNFLFB > 21)
		{
			FNGJCFKHOOL.text = "Dialog_Clicked";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(false);
		GDKAHDBHDPF.SetActive(true);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("was:{0} is:{1} removed:{2}" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(653f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 850f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		UILabel fHBAEAOCCDE = FHBAEAOCCDE;
		object[] array = new object[1];
		array[1] = MIDDFOCJJOP.FOICGJEPBGL;
		fHBAEAOCCDE.text = Localization.LocalizeFormat("currentActivity", array);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 1366f : 996f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MKLMJHEGGGM));
	}

	public void PFPNBDHJOPC(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.FMILKBAEBHH(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "ID_ARENAENDEDDESCRIPTION0WINS";
		}
		else if (MDOPFNNFLFB > 30)
		{
			FNGJCFKHOOL.text = "ID_ARENARULES_DEFENDERSPROHIBITED";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_BRONZEWARCARDS" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(741f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 872f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		UILabel fHBAEAOCCDE = FHBAEAOCCDE;
		object[] array = new object[0];
		array[1] = MIDDFOCJJOP.FOICGJEPBGL;
		fHBAEAOCCDE.text = Localization.LocalizeFormat("clientVersion", array);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 204f : 1574f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
	}

	public virtual void PONDIDGALJM()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ANKJLHLECKE));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		UIEventListener uIEventListener4 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IBONDILEDGH));
		MNNMIAAEBAF.mainTexture = null;
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(IFPAIAELCGP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void JNLOEBEHDMK(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(CGIFEHPDBAL.text);
		}
	}

	public void HNNEILOHNND(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.DKHLKOFJKPL(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "LeagueEntered";
		}
		else if (MDOPFNNFLFB > -106)
		{
			FNGJCFKHOOL.text = "Note:";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(false);
		GDKAHDBHDPF.SetActive(true);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("JP" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(224f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 300f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		FHBAEAOCCDE.text = Localization.LocalizeFormat("menu-button-oneside", MIDDFOCJJOP.FOICGJEPBGL);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 999f : 1055f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.UpdateIcon();
		}
	}

	private void MALBODMPGAD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void InitializePlayer(DatabasePlayer KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = null;
		MBIAKMPDOPG = KHLGDCHJJPB;
		BMNBNDILFJD.SetWidth(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "?";
		}
		else if (MDOPFNNFLFB > 100)
		{
			FNGJCFKHOOL.text = "100+.";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		CPGACIMMFEC.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(KHLGDCHJJPB);
		string text = GameVariables.CountryCodeSpriteName(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		DLAMMHGPADA.text = levelDefinition.displayString;
		bool flag2 = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 10f + NPECJCIKCBI.transform.localScale.x / 2f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 0f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.armyPowerX10);
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 37f, 28f, 100);
		if (KHLGDCHJJPB.isInBeginnersLeague)
		{
			int beginnersLeague = KHLGDCHJJPB.beginnersLeague;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(0.8f);
			MHCADNJHHLA.alpha = 1f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
		}
		else
		{
			League leagueTier = KHLGDCHJJPB.leagueTier;
			bool isInLeague = KHLGDCHJJPB.isInLeague;
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(0.8f);
			MHCADNJHHLA.alpha = ((!isInLeague) ? 0.5f : 1f);
			NCGOIMPOGHC.text = ((!isInLeague) ? Localization.Localize("ID_NA") : GameVariables.CAOGFCFGFPD[leagueTier].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.skill);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id)) ? 0f : 1f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MFMKIOCBKAO));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MFMKIOCBKAO));
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void BHCOCCKLNLO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void KJDEDOAOHHF()
	{
		if (MBIAKMPDOPG != null)
		{
			if (ECCDALKFFFK != null)
			{
				MBIAKMPDOPG.squadName = ECCDALKFFFK.DBNNKLCNDJD;
			}
			IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(MBIAKMPDOPG.squadName)) ? MBIAKMPDOPG.squadName : string.Empty);
		}
	}

	private void IFPAIAELCGP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.OLJPGNNKCKI(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	private void IBONDILEDGH(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.GFBDMPINFFP(IJFCFCGIKHK.text);
		}
	}

	public void GHNCOODHLHM(DatabasePlayer KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = null;
		MBIAKMPDOPG = KHLGDCHJJPB;
		BMNBNDILFJD.EGNOJHEGNCC(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "{0} / {1}";
		}
		else if (MDOPFNNFLFB > 51)
		{
			FNGJCFKHOOL.text = "Request Aborted!";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(false);
		GDKAHDBHDPF.SetActive(true);
		CPGACIMMFEC.NMEJKACLHKJ();
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(FCNKIEPEAAG);
		Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(KHLGDCHJJPB, true, PlayerTexturePool.DFJJOANIJID.Card);
		string text = GameVariables.BFGCBNLOIMN(KHLGDCHJJPB.country);
		bool flag = !string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.name;
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 250f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.level);
		GFKNLLCKJOG.spriteName = levelDefinition.GIEIIPBAIBK();
		DLAMMHGPADA.text = levelDefinition.JNODDKLJOAG();
		bool flag2 = KHLGDCHJJPB.warArenaCrown != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.warArenaCrown];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 177f + NPECJCIKCBI.transform.localScale.x / 1903f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.squadName)) ? KHLGDCHJJPB.squadName : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 1139f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.armyPowerX10);
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 1375f, 621f, 101);
		if (KHLGDCHJJPB.isInBeginnersLeague)
		{
			int beginnersLeague = KHLGDCHJJPB.beginnersLeague;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.CHOAELALEIC(beginnersLeague);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(1111f);
			MHCADNJHHLA.alpha = 1292f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
		}
		else
		{
			League leagueTier = KHLGDCHJJPB.leagueTier;
			bool isInLeague = KHLGDCHJJPB.isInLeague;
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(1116f);
			MHCADNJHHLA.alpha = ((!isInLeague) ? 893f : 1896f);
			NCGOIMPOGHC.text = ((!isInLeague) ? Localization.Localize("ID_SALEPERCENT") : GameVariables.CAOGFCFGFPD[leagueTier].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.skill);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.id == GameLoginManager.currentPlayer.id)) ? 1039f : 1165f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OGGLONHKDIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BHCOCCKLNLO));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MLGPCGJNCKD));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NKNLMBANNND));
	}

	public void MNFMPCBNOKH()
	{
		if (MBIAKMPDOPG != null)
		{
			if (ECCDALKFFFK != null)
			{
				MBIAKMPDOPG.squadName = ECCDALKFFFK.DBNNKLCNDJD;
			}
			IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(MBIAKMPDOPG.squadName)) ? MBIAKMPDOPG.squadName : string.Empty);
		}
	}

	private void HFFCMFNDCDA(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(IJFCFCGIKHK.text);
		}
	}

	private void FGMBFCBFMHC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void ANKJLHLECKE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void InitializeSquad(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.SetWidth(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "?";
		}
		else if (MDOPFNNFLFB > 100)
		{
			FNGJCFKHOOL.text = "100+.";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(false);
		GDKAHDBHDPF.SetActive(true);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("SquadIcons/" + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(0.5f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		FHBAEAOCCDE.text = Localization.LocalizeFormat("ID_NUMMEMBERS", MIDDFOCJJOP.FOICGJEPBGL);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 0f : 1f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
	}

	private void NKNLMBANNND(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.IFMMDKLNLJL(IJFCFCGIKHK.text);
		}
	}

	public virtual void DJDFKKJLHIC()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FHALHCELDGG));
		UIEventListener uIEventListener3 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
		UIEventListener uIEventListener4 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MFMKIOCBKAO));
		MNNMIAAEBAF.mainTexture = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public void MGKDFGEIABF(AANECPGDMGM MIDDFOCJJOP, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		MBIAKMPDOPG = null;
		ECCDALKFFFK = null;
		BMNBNDILFJD.FKBLIJOHBLD(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 0)
		{
			FNGJCFKHOOL.text = "java.util.Date";
		}
		else if (MDOPFNNFLFB > -57)
		{
			FNGJCFKHOOL.text = "CONFIRM";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(true);
		MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("Found starting warbucks currency = " + MIDDFOCJJOP.DAANKCOLJGJ);
		MNNMIAAEBAF.MakePixelPerfect();
		MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(1808f);
		CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
		TweenColor.Begin(CGIFEHPDBAL.gameObject, 1251f, Color.white);
		MNGGEHIAAEC.text = MIDDFOCJJOP.IKJHAHJHLIH.ToString();
		FHBAEAOCCDE.text = Localization.LocalizeFormat("country-england", MIDDFOCJJOP.FOICGJEPBGL);
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(MIDDFOCJJOP.MHPNDNJDPGE == GameLoginManager.currentPlayer.squadName)) ? 1959f : 727f);
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCGLELHGFIO));
		UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
	}

	private void AILFAMAFHFJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void KFPMOLLDDDO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MFMKIOCBKAO(GameObject KHAHPAKDIKE)
	{
		if (IGJMJNHFCAI.activeSelf && !string.IsNullOrEmpty(IJFCFCGIKHK.text))
		{
			TweenColor tweenColor = TweenColor.Begin(IJFCFCGIKHK.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(IJFCFCGIKHK.text);
		}
	}

	public void InitializePlayer(FHIPGDADNFG KHLGDCHJJPB, int MDOPFNNFLFB, float CEHFMMJHCKC)
	{
		ECCDALKFFFK = KHLGDCHJJPB;
		MBIAKMPDOPG = DatabasePlayer.CreateFromDatabasePlayerData(KHLGDCHJJPB);
		BMNBNDILFJD.SetWidth(CEHFMMJHCKC);
		if (MDOPFNNFLFB < 1)
		{
			FNGJCFKHOOL.text = "?";
		}
		else if (MDOPFNNFLFB > 100)
		{
			FNGJCFKHOOL.text = "100+.";
		}
		else
		{
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(MDOPFNNFLFB);
		}
		IGJMJNHFCAI.SetActive(true);
		GDKAHDBHDPF.SetActive(false);
		CPGACIMMFEC.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
		string text = GameVariables.CountryCodeSpriteName(KHLGDCHJJPB.CAAKEPHMPHI);
		bool flag = !string.IsNullOrEmpty(text);
		DCKLANDMFHE.gameObject.SetActive(flag);
		if (flag)
		{
			DCKLANDMFHE.spriteName = text;
		}
		BCMCMKDCLGP.text = KHLGDCHJJPB.MHPNDNJDPGE;
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(KHLGDCHJJPB.BCCDDJMPBLL);
		GFKNLLCKJOG.spriteName = levelDefinition.iconName;
		DLAMMHGPADA.text = levelDefinition.displayString;
		bool flag2 = KHLGDCHJJPB.FHCMFHABMLE != WarArenaCrown.None;
		NPECJCIKCBI.gameObject.SetActive(flag2);
		if (flag2)
		{
			NPECJCIKCBI.spriteName = GameVariables.CMIKIDJKHID[KHLGDCHJJPB.FHCMFHABMLE];
			NPECJCIKCBI.MakePixelPerfect();
			float x = BCMCMKDCLGP.transform.localPosition.x;
			x += BCMCMKDCLGP.relativeSize.x * BCMCMKDCLGP.transform.localScale.x;
			x += 10f + NPECJCIKCBI.transform.localScale.x / 2f;
			NPECJCIKCBI.transform.localPosition = NPECJCIKCBI.transform.localPosition.ReplaceX(x);
		}
		IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(KHLGDCHJJPB.DBNNKLCNDJD)) ? KHLGDCHJJPB.DBNNKLCNDJD : string.Empty);
		TweenColor.Begin(IJFCFCGIKHK.gameObject, 0f, Color.white);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.IMOJCFKJKMN);
		MEJMLNDFDBP.COCBCFKJOJE(DFNJBGGMIKN, 37f, 28f, 100);
		if (KHLGDCHJJPB.DBIEDLPHCAI)
		{
			int hNEFOLPHMHK = KHLGDCHJJPB.HNEFOLPHMHK;
			MHCADNJHHLA.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(hNEFOLPHMHK);
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(0.8f);
			MHCADNJHHLA.alpha = 1f;
			NCGOIMPOGHC.text = Singleton<GameVariables>.instance.BeginnersLeagueName(hNEFOLPHMHK);
		}
		else
		{
			League mIDDIFMBFGC = KHLGDCHJJPB.MIDDIFMBFGC;
			bool flag3 = KHLGDCHJJPB.GKEOILLNCHG;
			MHCADNJHHLA.spriteName = GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value2;
			MHCADNJHHLA.MakePixelPerfect();
			MHCADNJHHLA.transform.localScale = MHCADNJHHLA.transform.localScale.MultiplyXY(0.8f);
			MHCADNJHHLA.alpha = ((!flag3) ? 0.5f : 1f);
			NCGOIMPOGHC.text = ((!flag3) ? Localization.Localize("ID_NA") : GameVariables.CAOGFCFGFPD[mIDDIFMBFGC].Value1);
		}
		PCGLEBCNECN.text = MEJMLNDFDBP.GMIPFLIEOHD(KHLGDCHJJPB.CJDHKJFKNAH);
		LCPBNBLGFIA.alpha = ((!(KHLGDCHJJPB.INFLHPGMEOB == GameLoginManager.currentPlayer.id)) ? 0f : 1f);
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MFMKIOCBKAO));
		UIEventListener uIEventListener6 = UIEventListener.Get(ODKNHIJHCKN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MFMKIOCBKAO));
	}

	private void JCPAJJKEJKL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void JACKAGGAFHD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void DDKKMELJCHH()
	{
		if (MBIAKMPDOPG != null)
		{
			if (ECCDALKFFFK != null)
			{
				MBIAKMPDOPG.squadName = ECCDALKFFFK.DBNNKLCNDJD;
			}
			IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(MBIAKMPDOPG.squadName)) ? MBIAKMPDOPG.squadName : string.Empty);
		}
	}

	private void FIFBGKNPMNM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void OGGLONHKDIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void GENEDHLCGNH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void HHEJONOILHC()
	{
		if (MBIAKMPDOPG != null)
		{
			if (ECCDALKFFFK != null)
			{
				MBIAKMPDOPG.squadName = ECCDALKFFFK.DBNNKLCNDJD;
			}
			IJFCFCGIKHK.text = ((!string.IsNullOrEmpty(MBIAKMPDOPG.squadName)) ? MBIAKMPDOPG.squadName : string.Empty);
		}
	}
}
