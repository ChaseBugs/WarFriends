using System;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class SettingsUserContent : Core_BaseScript
{
	[FormerlySerializedAs("EDGLDDNNLLK")]
	[Header("Guest")]
	public GameObject MNPIPHAIOID;

	[FormerlySerializedAs("GODCKIEPAID")]
	public UILabel NILDOHCILJJ;

	[FormerlySerializedAs("KPEAECNDOEI")]
	public GameObject GNCGMFFMPDA;

	[Header("- Hints")]
	[FormerlySerializedAs("mGuestSIWALoginButton")]
	public GameObject GDCAHDDJMLJ;

	[FormerlySerializedAs("MACNBKIEKON")]
	public UILabel EGCMLPHOMBM;

	[FormerlySerializedAs("BMPIACEGPKE")]
	public GameObject APMJDMFHAAN;

	[FormerlySerializedAs("HJPOPIDCGIF")]
	public GameObject FDPCKHADAIF;

	[Header("- Change Country")]
	[FormerlySerializedAs("NLGHJGJBBEF")]
	public GameObject FAJAOCKLPPL;

	[FormerlySerializedAs("ADKNMBMAHHD")]
	public UISprite KGCGOJEFFHL;

	[FormerlySerializedAs("EFIKFIIDOPL")]
	[Header("GameCenter")]
	public GameObject FLIKPPJEEJD;

	[FormerlySerializedAs("ABHNJHHOPFF")]
	public PlayerIcon NFEDCJJKEAF;

	[FormerlySerializedAs("JPFEPOJPGAB")]
	public UILabel DOCMANJHCDC;

	[FormerlySerializedAs("NMDAAOMOLAE")]
	public GameObject BDALONDAOOB;

	[FormerlySerializedAs("OBGHLNOAFGM")]
	public GameObject CBDOGBNMKHK;

	[FormerlySerializedAs("mGameCenterSIWALoginButton")]
	[Header("- Hints")]
	public GameObject ADOLCDOCNFO;

	[FormerlySerializedAs("MLEPHKOGJDM")]
	public UITable POOMGDFDHPK;

	[FormerlySerializedAs("JLNOBKDMIKG")]
	public UILabel NEFAFCNLDAG;

	[FormerlySerializedAs("HIPHGGGBAJE")]
	public UITable DBLIHHLCKEM;

	[Header("- Change Country")]
	[FormerlySerializedAs("JEDAPHPCEAN")]
	public GameObject FNCNOGEKNOC;

	[FormerlySerializedAs("KCDNOMKCILC")]
	public UISprite CPJBFOHGCGB;

	[Header("GooglePlay")]
	[FormerlySerializedAs("CEGCMFGCFCB")]
	public GameObject AGKKKILJFLF;

	[FormerlySerializedAs("CKOBIILEHBE")]
	public UILabel HKDDEICBFMF;

	[FormerlySerializedAs("LABMHFGBHBD")]
	public GameObject ELGHPMEJJGE;

	[FormerlySerializedAs("IOJLMKDPHND")]
	public GameObject BDJCKGPDPND;

	[FormerlySerializedAs("GGCFGEIGMAL")]
	public GameObject KGBHGDDGEMB;

	[Header("- Hints")]
	[FormerlySerializedAs("FJMLHLHFKPP")]
	public GameObject JFOOJDFNBLE;

	[FormerlySerializedAs("CJODPPGANGL")]
	public UITable HEIOOKDIEOL;

	[FormerlySerializedAs("OPOGIKMOMHL")]
	public UILabel JLAAOIGLCCG;

	[FormerlySerializedAs("GADHBEANCEG")]
	public UITable CHPCPNJNHPP;

	[FormerlySerializedAs("JPCLFNPEMMM")]
	[Header("- Change Country")]
	public GameObject NAKOKHIIDGC;

	[FormerlySerializedAs("EMCPBDFADCG")]
	public UISprite OEINHOPPPIG;

	[Header("Facebook")]
	[FormerlySerializedAs("CAIGDBBGKAG")]
	public GameObject EAHALOKMDNE;

	[FormerlySerializedAs("BEACKOBBFPL")]
	public PlayerIcon BJPJJMPBKLA;

	[FormerlySerializedAs("NIJAOAEFBHB")]
	public UILabel LFFALEOMBOJ;

	[FormerlySerializedAs("PCKJJJHFDBL")]
	public GameObject LKBOGIPAKCN;

	[FormerlySerializedAs("NCIBIMNIHKB")]
	public UILabel MPCPBLGGDPO;

	[FormerlySerializedAs("NNAENJMMIOA")]
	public GameObject CFBGAHDHGDC;

	[Header("- Relogin")]
	[FormerlySerializedAs("BPHCLKIEINH")]
	public UILabel IBBAHPGJLBG;

	[FormerlySerializedAs("PAHLLNEIIOL")]
	public GameObject OAHAEBGKEIP;

	[FormerlySerializedAs("NGEKDNECLJJ")]
	[Header("- Google Play Part")]
	public UISprite ALDDEPCKNGE;

	[FormerlySerializedAs("EBCHABIPMEC")]
	public GameObject GENKCIALDAA;

	[FormerlySerializedAs("OFCPNLGHGFP")]
	public UILabel CDKJMJHLKEB;

	[FormerlySerializedAs("CADLKGAMJLL")]
	public GameObject LDEBCKJDOFJ;

	[FormerlySerializedAs("mFacebookApplePart")]
	[Header("- Change Country")]
	public GameObject PKOHGLPNLBD;

	[FormerlySerializedAs("PJOFELEKCDG")]
	public UISprite ALJBPPPDPLC;

	public void CJCAGMPFPFD()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.CountryCodeSpriteName(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: true);
		EAHALOKMDNE.SetActive(value: true);
		FLIKPPJEEJD.SetActive(value: false);
		AGKKKILJFLF.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldenSuitcase_WBRewardChance);
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: true);
			NILDOHCILJJ.text = string.Format("ID_DAILYMISSIONX", Localization.Localize("S"), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(!flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: false);
			Singleton<ArmyPreviewCamera>.instance.MDCPOGFDCPC(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true);
			BJPJJMPBKLA.KHIPFLOFKMC(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: false);
			GENKCIALDAA.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: false);
			NFEDCJJKEAF.avatar = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = true;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = true;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: true);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = true;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = false;
			}
		}
	}

	private void OBOPDJJKJGO(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
	}

	private void JEGPEONIKCN(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
	}

	public void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCECBIIMEGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GGEEDGNCKFE));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AKNHFMMOCBF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NEDLMGEAIPN));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BLGOLGLHEPD));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NFBALJMGOLB));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(EJGEIBMEBMP));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(FOGKEFAIGNG));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(AHGBDEHFLGJ));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(AHGBDEHFLGJ));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(PKPICGBMPGL));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(IPAKPMNGGKP));
	}

	public void HLBIJGPEPIO()
	{
		BJPJJMPBKLA.KLIEOBHDFCG();
		NFEDCJJKEAF.NCHGDJDAHGC();
	}

	private void AHGBDEHFLGJ(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	private void BLGOLGLHEPD(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.MHAIBHBGBOO())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void PKCIHEOCAGC(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
	}

	public void FJFDJJJNCAJ()
	{
		BJPJJMPBKLA.OOOLABBEKDF();
		NFEDCJJKEAF.HJOCCDLNFLN();
	}

	private void BCDPICCINHP(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
	}

	public void DoAfterHide()
	{
		BJPJJMPBKLA.Reset();
		NFEDCJJKEAF.Reset();
	}

	public void JAIAMFJHDLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNBEHIPBMKL));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AKNHFMMOCBF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBOPDJJKJGO));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GLOGEAKDIJB));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(ODCFJEKDMEE));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(IAENJEDCFGK));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(FHOHCGEGMPB));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(GDFKHCLHKNG));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(EELGCHHHNFP));
	}

	private void BILJFEEDNGM(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.AFOFDNJOJHG())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void EBJENOFGHON(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BKIGLABDGCP() && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	private void OJNBFNCDODI(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.LHDGJFHPJNM())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	public void MPNFAPKFNHL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCECBIIMEGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKNHFMMOCBF));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AKNHFMMOCBF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EEAOOMPPLIB));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GLOGEAKDIJB));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(ODCFJEKDMEE));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(PLBCHIGDEDE));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PLBCHIGDEDE));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(BIMHDBIEOMC));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(BCDPICCINHP));
	}

	public void NEOLLOMIKPK()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.IDOFIHFGOKD(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: true);
		EAHALOKMDNE.SetActive(value: true);
		FLIKPPJEEJD.SetActive(value: true);
		AGKKKILJFLF.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldenSuitcase_PowerbandRewardDuration);
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-98)).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: false);
			NILDOHCILJJ.text = string.Format("placement", Localization.Localize("ID"), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(!flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: true);
			Singleton<ArmyPreviewCamera>.instance.DIMPHNLEKHG(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false);
			BJPJJMPBKLA.avatar = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: true);
			GENKCIALDAA.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: false);
			NFEDCJJKEAF.ECKBKNCJLOC(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(!flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = false;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = true;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: true);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = false;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = true;
			}
		}
	}

	private void EIOLOFNDFFJ(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
	}

	private void IPAKPMNGGKP(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
	}

	private void KMGKDEMKHFG(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EIOLOFNDFFJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CCDMCLHKGHA));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(FBIFAPNJLBM));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(FBIFAPNJLBM));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(BIMHDBIEOMC));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(BIMHDBIEOMC));
	}

	public void LAMBEOCPCBD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PBAIPCFDGCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNBEHIPBMKL));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PCECBIIMEGN));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JLCAGCLBDGH));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(JCOIHKJLKJG));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NFBALJMGOLB));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(IAENJEDCFGK));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(BIMHDBIEOMC));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(IPAKPMNGGKP));
	}

	private void FMMMKEKDPCM(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
	}

	public void HAHKNAIIIPC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCECBIIMEGN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNBEHIPBMKL));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JEGPEONIKCN));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FMEAHKPFODK));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NFBALJMGOLB));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(ODCFJEKDMEE));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(BMHMNBIMGNK));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(EBJENOFGHON));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(EBJENOFGHON));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(BIMHDBIEOMC));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(BCDPICCINHP));
	}

	private void BMHMNBIMGNK(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 682f);
	}

	private void GDFKHCLHKNG(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
	}

	private void KPCEJFFLFIK(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.MHAIBHBGBOO())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void JHHMHNECCNE(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 1743f);
	}

	public void InitGUIValues()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.CountryCodeSpriteName(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: false);
		EAHALOKMDNE.SetActive(value: false);
		FLIKPPJEEJD.SetActive(value: false);
		AGKKKILJFLF.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: true);
			NILDOHCILJJ.text = string.Format("{0} {1}", Localization.Localize("ID_GUESTACCOUNT"), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(!flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: true);
			Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false);
			BJPJJMPBKLA.avatar = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: true);
			GENKCIALDAA.gameObject.SetActive(!currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: true);
			NFEDCJJKEAF.avatar = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(!flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = true;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = true;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: true);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(!flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = true;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = true;
			}
		}
	}

	public void PLDBDGJLOFP()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.CountryCodeSpriteName(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: false);
		EAHALOKMDNE.SetActive(value: true);
		FLIKPPJEEJD.SetActive(value: true);
		AGKKKILJFLF.SetActive(value: true);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FriendDamageCoeficient);
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: true);
			NILDOHCILJJ.text = string.Format("menu-powerband-health-ico", Localization.Localize("player name"), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(!flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: false);
			Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true);
			BJPJJMPBKLA.avatar = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: false);
			GENKCIALDAA.gameObject.SetActive(!currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: true);
			NFEDCJJKEAF.FBGDPCPIKMI(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = true;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = false;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: true);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = true;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = true;
			}
		}
	}

	private void PCEJOBNDMOH(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance);
	}

	private void OIKGEOPGPIF(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.AFOFDNJOJHG())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void OMANOFEOIMN(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	private void IHODKFNLPHO(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance, 192f);
	}

	private void ODCFJEKDMEE(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 1131f);
	}

	public void MHIFDHGPDCK()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.IEDGPHEPJEK(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: false);
		EAHALOKMDNE.SetActive(value: true);
		FLIKPPJEEJD.SetActive(value: true);
		AGKKKILJFLF.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-32));
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-115)).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: true);
			NILDOHCILJJ.text = string.Format("S", Localization.Localize("UNKNOWN FUSEBOXX CONFIGURATION KEY = "), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: true);
			Singleton<ArmyPreviewCamera>.instance.BDHBFHGBDOK(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			BJPJJMPBKLA.DJPNDAICDPN(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: false);
			GENKCIALDAA.gameObject.SetActive(!currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: false);
			NFEDCJJKEAF.OLJPGNNKCKI(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(!flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = true;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = false;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: true);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = false;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = false;
			}
		}
	}

	private void HNBPKDIELJE(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance, 1245f);
	}

	private void IAENJEDCFGK(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance, 1548f);
	}

	public void NMHMFDOFDBC()
	{
		BJPJJMPBKLA.LFOLGBNBBAG();
		NFEDCJJKEAF.NMEJKACLHKJ();
	}

	private void FBIFAPNJLBM(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	public void NFABHLHCNGJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNBEHIPBMKL));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NAGIABLCMMM));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NEDLMGEAIPN));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BLGOLGLHEPD));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(EJGEIBMEBMP));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(IAENJEDCFGK));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(FMMMKEKDPCM));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(IPAKPMNGGKP));
	}

	private void NCABDKPNDMM(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	public void LAALCOMHIPK()
	{
		BJPJJMPBKLA.OMDFNFHKFBK();
		NFEDCJJKEAF.Reset();
	}

	private void ADPAOGEIEHI(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
	}

	private void FFBHFPGMPOM(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BKIGLABDGCP() && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	private void NFBALJMGOLB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 1992f);
	}

	private void EJGEIBMEBMP(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 1327f);
	}

	public void CEAINPCKADK()
	{
		BJPJJMPBKLA.KHMNEOBMJLN();
		NFEDCJJKEAF.HJOCCDLNFLN();
	}

	private void GGEEDGNCKFE(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.AFOFDNJOJHG())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void LAELLLEAAHD(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	public void IEHJMLIMNEP()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.CountryCodeSpriteName(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: false);
		EAHALOKMDNE.SetActive(value: false);
		FLIKPPJEEJD.SetActive(value: false);
		AGKKKILJFLF.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-125));
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-95)).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: false);
			NILDOHCILJJ.text = string.Format("173432c2", Localization.Localize(" OK!"), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(!flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: false);
			Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true);
			BJPJJMPBKLA.KHIPFLOFKMC(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: true);
			GENKCIALDAA.gameObject.SetActive(!currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: false);
			NFEDCJJKEAF.DJPNDAICDPN(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(!flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = true;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = true;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: false);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(!flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = false;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = true;
			}
		}
	}

	private void FOGKEFAIGNG(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance, 582f);
	}

	private void JCOIHKJLKJG(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BJNBLINDAED())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void PLBCHIGDEDE(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BJNBLINDAED() && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	private void JOJGIAIFNAK(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void BPNPPHJLCNB(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	private void CCDMCLHKGHA(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void FMEAHKPFODK(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BKIGLABDGCP())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void PDFKELIDFDF(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.LHDGJFHPJNM() && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	public void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GGEEDGNCKFE));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NCABDKPNDMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AKNHFMMOCBF));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JLCAGCLBDGH));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BILJFEEDNGM));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(ODCFJEKDMEE));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(IAENJEDCFGK));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(FOGKEFAIGNG));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(EBJENOFGHON));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(GDFKHCLHKNG));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(EELGCHHHNFP));
	}

	private void BIMHDBIEOMC(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
	}

	private void PMFJNJCICOF(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	public void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCABDKPNDMM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NAGIABLCMMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PNBEHIPBMKL));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MLFAJGKFJKN));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(JCOIHKJLKJG));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BMHMNBIMGNK));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(NFBALJMGOLB));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(IAENJEDCFGK));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(AHGBDEHFLGJ));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(EBJENOFGHON));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(FMMMKEKDPCM));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(BIMHDBIEOMC));
	}

	private void AKNHFMMOCBF(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.AFOFDNJOJHG())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	public void LGIPBIFJFPD()
	{
		BJPJJMPBKLA.KOKJMKHECGK();
		NFEDCJJKEAF.ABBPOMCBIIH();
	}

	private void KKJGKMFKPMB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance, 1410f);
	}

	public void EFKFHFNAOHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PBAIPCFDGCA));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OOEBMLGCNJH));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OOEBMLGCNJH));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JLCAGCLBDGH));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BLGOLGLHEPD));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NFBALJMGOLB));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(EJGEIBMEBMP));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(FOGKEFAIGNG));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(HNBPKDIELJE));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(EBJENOFGHON));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(FBIFAPNJLBM));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(NOELMOIHIPC));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(BCDPICCINHP));
	}

	public void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OOEBMLGCNJH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NAGIABLCMMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GGEEDGNCKFE));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EIOLOFNDFFJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(LAELLLEAAHD));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BMHMNBIMGNK));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(PCEJOBNDMOH));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(AHGBDEHFLGJ));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PLBCHIGDEDE));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(EELGCHHHNFP));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(NOELMOIHIPC));
	}

	private void NAGIABLCMMM(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.LHDGJFHPJNM())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void EELGCHHHNFP(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
	}

	private void GLOGEAKDIJB(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BJNBLINDAED())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void FHOHCGEGMPB(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.LHDGJFHPJNM() && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	private void PCECBIIMEGN(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BKIGLABDGCP())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void PKPICGBMPGL(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
	}

	private void HMLNMPLCADD(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance);
	}

	private void EEAOOMPPLIB(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	private void IOBBNJEMPKJ(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	private void NEDLMGEAIPN(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	public void OCACKBJDEHI()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.IDOFIHFGOKD(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: true);
		EAHALOKMDNE.SetActive(value: false);
		FLIKPPJEEJD.SetActive(value: false);
		AGKKKILJFLF.SetActive(value: true);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-92));
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackBronzeCards).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: false);
			NILDOHCILJJ.text = string.Format("added", Localization.Localize("ID_SLOTUPGRADE_POWER"), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: true);
			Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
			BJPJJMPBKLA.JIBFCGECCFI(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: true);
			GENKCIALDAA.gameObject.SetActive(!currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: true);
			NFEDCJJKEAF.KGJCNNANACM(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = false;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = true;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: false);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = true;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = true;
			}
		}
	}

	private void NOELMOIHIPC(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: true);
	}

	public void IGNIFKBCDKK()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.IDOFIHFGOKD(currentPlayer.country);
		MNPIPHAIOID.SetActive(value: true);
		EAHALOKMDNE.SetActive(value: true);
		FLIKPPJEEJD.SetActive(value: true);
		AGKKKILJFLF.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.MinLevelForCardsReminder);
		int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-42)).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			MNPIPHAIOID.SetActive(value: true);
			NILDOHCILJJ.text = string.Format("Waiting too long for all playersFinish to loading", Localization.Localize("InstantBattleEnded: LEVEL UP "), currentPlayer.name);
			GDCAHDDJMLJ.SetActive(!flag);
			APMJDMFHAAN.SetActive(flag);
			KGCGOJEFFHL.spriteName = spriteName;
			if (!flag)
			{
				EGCMLPHOMBM.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			EAHALOKMDNE.SetActive(value: true);
			Singleton<ArmyPreviewCamera>.instance.BDHBFHGBDOK(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false);
			BJPJJMPBKLA.EIKJEGHELNK(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			LFFALEOMBOJ.text = currentPlayer.name;
			ALJBPPPDPLC.spriteName = spriteName;
			MPCPBLGGDPO.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			CFBGAHDHGDC.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			IBBAHPGJLBG.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			OAHAEBGKEIP.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			ALDDEPCKNGE.gameObject.SetActive(value: true);
			GENKCIALDAA.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			CDKJMJHLKEB.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			LDEBCKJDOFJ.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			FLIKPPJEEJD.SetActive(value: false);
			NFEDCJJKEAF.OLJPGNNKCKI(Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN);
			DOCMANJHCDC.text = currentPlayer.name;
			ADOLCDOCNFO.SetActive(flag);
			CPJBFOHGCGB.spriteName = spriteName;
			if (!flag)
			{
				POOMGDFDHPK.repositionNow = false;
				NEFAFCNLDAG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				DBLIHHLCKEM.repositionNow = false;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			AGKKKILJFLF.SetActive(value: true);
			HKDDEICBFMF.text = currentPlayer.name;
			JFOOJDFNBLE.SetActive(!flag);
			OEINHOPPPIG.spriteName = spriteName;
			if (!flag)
			{
				HEIOOKDIEOL.repositionNow = false;
				JLAAOIGLCCG.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				CHPCPNJNHPP.repositionNow = true;
			}
		}
	}

	public void IMEOAPEABLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NCABDKPNDMM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PBAIPCFDGCA));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NAGIABLCMMM));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBOPDJJKJGO));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(BILJFEEDNGM));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(BMHMNBIMGNK));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(IHODKFNLPHO));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(FOGKEFAIGNG));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(FFBHFPGMPOM));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PLBCHIGDEDE));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(IPAKPMNGGKP));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(PKPICGBMPGL));
	}

	private void MLFAJGKFJKN(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: true);
	}

	private void JLCAGCLBDGH(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
	}

	public void BKNJHLKMFKE()
	{
		BJPJJMPBKLA.HJOCCDLNFLN();
		NFEDCJJKEAF.Reset();
	}

	private void PCPNJLBDGDA(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.BKIGLABDGCP())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void PBAIPCFDGCA(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.MHAIBHBGBOO())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void PNBEHIPBMKL(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.MHAIBHBGBOO())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void OOEBMLGCNJH(GameObject KHAHPAKDIKE)
	{
		if (GuiElementSingle<SettingsDialog>.instance.LHDGJFHPJNM())
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	public void HCGDNLHIOBL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(GNCGMFFMPDA);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NAGIABLCMMM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CBDOGBNMKHK);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NAGIABLCMMM));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGBHGDDGEMB);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GGEEDGNCKFE));
		UIEventListener uIEventListener4 = UIEventListener.Get(CFBGAHDHGDC);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ADPAOGEIEHI));
		UIEventListener uIEventListener5 = UIEventListener.Get(OAHAEBGKEIP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GLOGEAKDIJB));
		UIEventListener uIEventListener6 = UIEventListener.Get(LKBOGIPAKCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JHHMHNECCNE));
		UIEventListener uIEventListener7 = UIEventListener.Get(BDALONDAOOB);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(BMHMNBIMGNK));
		UIEventListener uIEventListener8 = UIEventListener.Get(ELGHPMEJJGE);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(BMHMNBIMGNK));
		UIEventListener uIEventListener9 = UIEventListener.Get(FAJAOCKLPPL);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(HMLNMPLCADD));
		UIEventListener uIEventListener10 = UIEventListener.Get(FNCNOGEKNOC);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(IAENJEDCFGK));
		UIEventListener uIEventListener11 = UIEventListener.Get(NAKOKHIIDGC);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener12 = UIEventListener.Get(PKOHGLPNLBD);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(KKJGKMFKPMB));
		UIEventListener uIEventListener13 = UIEventListener.Get(FDPCKHADAIF);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(FHOHCGEGMPB));
		UIEventListener uIEventListener14 = UIEventListener.Get(GENKCIALDAA);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(PDFKELIDFDF));
		UIEventListener uIEventListener15 = UIEventListener.Get(BDJCKGPDPND);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(PKCIHEOCAGC));
		UIEventListener uIEventListener16 = UIEventListener.Get(LDEBCKJDOFJ);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(BCDPICCINHP));
	}
}
