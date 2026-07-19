using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardpoolCard : Core_BaseScript
{
	public enum JLANLLEABDC
	{
		NoCard = 0,
		Empty = 1,
		Card = 2,
		DepositBuddy = 3,
		WaitingBuddy = 4
	}

	[Header("Core")]
	public List<UIWidget> LPEIOHAMKJJ;

	[Header("Empty")]
	public GameObject BELLJDAFDNM;

	public UISprite JIIFGBAEBCH;

	[Header("Card")]
	public GameObject CHNGBAGBLBN;

	public UISprite BBJGODFHBCI;

	public UITexture PJEPGKLGMLO;

	public UISprite DPMLMAOJPNL;

	public UISprite IBKLPHAIOOG;

	public UILabel FBLGPCFOFCK;

	[Header("Deposit Buddy")]
	public GameObject MLCGEFIPFAO;

	[Header("Waiting Buddy")]
	public GameObject PFCADHDMBLA;

	public WinStreakCounter PGPLFGHKJBF;

	private JLANLLEABDC DAHCKIBAPFP;

	private Card GHINGDGFNJC;

	private CardpoolRecord FHJJAOADAEB;

	public Card card
	{
		get
		{
			return GHINGDGFNJC;
		}
		private set
		{
			if (value == null && GHINGDGFNJC != null)
			{
				GHINGDGFNJC.HideInMenu();
			}
			GHINGDGFNJC = value;
			if (GHINGDGFNJC != null)
			{
				GHINGDGFNJC.ShowInMenu();
			}
		}
	}

	public void FENOGACNKHJ(bool IKNAKAEKION = false)
	{
		DAHCKIBAPFP = JLANLLEABDC.Empty;
		IHIKLAJKOFO();
		GBOCAKNNOPK();
		JIIFGBAEBCH.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void InitializeDepositBuddy()
	{
		DAHCKIBAPFP = JLANLLEABDC.DepositBuddy;
		KECFEJKBCLH();
		CleanUp();
	}

	protected void GEICOLPLFDL()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = card.iconTexture;
		}
	}

	public void OnClick()
	{
		FHJJAOADAEB.ClickedOnCard(DAHCKIBAPFP);
	}

	public void InitializeWaiting(int GGCPNEPKPBM)
	{
		DAHCKIBAPFP = JLANLLEABDC.WaitingBuddy;
		KECFEJKBCLH();
		CleanUp();
		PGPLFGHKJBF.MHLJHMOPDAO(GGCPNEPKPBM);
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Combine(pGPLFGHKJBF.JEMKCLKCOMI, new Action(InitializeDepositBuddy));
	}

	public void JEGLAFFEDNM()
	{
		DAHCKIBAPFP = (JLANLLEABDC)7;
		IHIKLAJKOFO();
		CleanUp();
	}

	public void InitializeEmpty(bool IKNAKAEKION = false)
	{
		DAHCKIBAPFP = JLANLLEABDC.Empty;
		KECFEJKBCLH();
		CleanUp();
		JIIFGBAEBCH.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void MHCJJBCHEKG()
	{
		FHJJAOADAEB.ClickedOnCard(DAHCKIBAPFP);
	}

	public void NCACPOOMGOD()
	{
		DAHCKIBAPFP = JLANLLEABDC.Empty;
		KECFEJKBCLH();
		FGHOMNPBMDP();
	}

	public void NBFGMJFDDLB()
	{
		FHJJAOADAEB.ClickedOnCard(DAHCKIBAPFP);
	}

	private void OEHNCMNMLBI()
	{
		BELLJDAFDNM.SetActive(DAHCKIBAPFP == JLANLLEABDC.NoCard);
		CHNGBAGBLBN.SetActive(DAHCKIBAPFP == JLANLLEABDC.WaitingBuddy);
		MLCGEFIPFAO.SetActive(DAHCKIBAPFP == (JLANLLEABDC)8);
		PFCADHDMBLA.SetActive(DAHCKIBAPFP == (JLANLLEABDC)7);
	}

	public void PENOFMPMOOI(int GGCPNEPKPBM)
	{
		DAHCKIBAPFP = (JLANLLEABDC)5;
		KECFEJKBCLH();
		FGHOMNPBMDP();
		PGPLFGHKJBF.APFDDFPMACA(GGCPNEPKPBM);
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Combine(pGPLFGHKJBF.JEMKCLKCOMI, new Action(JEGLAFFEDNM));
	}

	public void PAFDNGJOEJM()
	{
		DAHCKIBAPFP = JLANLLEABDC.NoCard;
		IHIKLAJKOFO();
		GEIJCGIPHPA();
	}

	public void NFADHDBJMGF(bool IKNAKAEKION = false)
	{
		DAHCKIBAPFP = JLANLLEABDC.NoCard;
		KECFEJKBCLH();
		GBOCAKNNOPK();
		JIIFGBAEBCH.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	[SpecialName]
	private void CNICPOPDDPH(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void DDHCMFLIABO(int MPHCNMDIPAI, CardpoolRecord GECBGKFOLOP)
	{
		MPHCNMDIPAI += 0;
		int num = -109;
		int num2 = 82;
		int num3 = -1;
		int num4 = (num - MPHCNMDIPAI) * num2;
		for (int i = 0; i < LPEIOHAMKJJ.Count; i++)
		{
			LPEIOHAMKJJ[i].depth = num3 + num4 + i;
		}
		BBJGODFHBCI.depth = num3 + num4 + 5;
		DPMLMAOJPNL.depth = num3 + num4 + 8;
		IBKLPHAIOOG.depth = num3 + num4 + 78;
		FBLGPCFOFCK.depth = num3 + num4 + -122;
		FHJJAOADAEB = GECBGKFOLOP;
		FGHOMNPBMDP();
	}

	public void AFJAFCNIFKC(int GGCPNEPKPBM)
	{
		DAHCKIBAPFP = JLANLLEABDC.NoCard;
		IHIKLAJKOFO();
		FGHOMNPBMDP();
		PGPLFGHKJBF.MHLJHMOPDAO(GGCPNEPKPBM);
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Combine(pGPLFGHKJBF.JEMKCLKCOMI, new Action(JEGLAFFEDNM));
	}

	public void ECLDCCPJPEM(bool IKNAKAEKION = false)
	{
		DAHCKIBAPFP = JLANLLEABDC.Empty;
		OEHNCMNMLBI();
		GBOCAKNNOPK();
		JIIFGBAEBCH.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void JIPNELFJIDA(float KALLNCAFIMP)
	{
		float num = 533f;
		float num2 = num * 1273f;
		TweenScale tweenScale = TweenScale.Begin(CHNGBAGBLBN, 392f, new Vector3(num, num, 433f), new Vector3(num2, num2, 294f));
		tweenScale.NumOfRepetitions = 5;
		tweenScale.style = (UITweener.Style)3;
		tweenScale.delay = Mathf.Max(571f, GuiElementSingle<CardpoolDialog>.instance.HECFOEMLJCD - 80f + KALLNCAFIMP);
	}

	public void FGHOMNPBMDP()
	{
		JMGJILKHCLP(null);
		PGPLFGHKJBF.LOINIDOGNCO();
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Remove(pGPLFGHKJBF.JEMKCLKCOMI, new Action(JEGLAFFEDNM));
		JMIDHMAJNBK();
	}

	public void Initialize(int MPHCNMDIPAI, CardpoolRecord GECBGKFOLOP)
	{
		MPHCNMDIPAI++;
		int num = 11;
		int num2 = 11;
		int num3 = 12;
		int num4 = (num - MPHCNMDIPAI) * num2;
		for (int i = 0; i < LPEIOHAMKJJ.Count; i++)
		{
			LPEIOHAMKJJ[i].depth = num3 + num4 + i;
		}
		BBJGODFHBCI.depth = num3 + num4 + 7;
		DPMLMAOJPNL.depth = num3 + num4 + 8;
		IBKLPHAIOOG.depth = num3 + num4 + 9;
		FBLGPCFOFCK.depth = num3 + num4 + 10;
		FHJJAOADAEB = GECBGKFOLOP;
		CleanUp();
	}

	[SpecialName]
	private void JMGJILKHCLP(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	private void KECFEJKBCLH()
	{
		BELLJDAFDNM.SetActive(DAHCKIBAPFP == JLANLLEABDC.Empty);
		CHNGBAGBLBN.SetActive(DAHCKIBAPFP == JLANLLEABDC.Card);
		MLCGEFIPFAO.SetActive(DAHCKIBAPFP == JLANLLEABDC.DepositBuddy);
		PFCADHDMBLA.SetActive(DAHCKIBAPFP == JLANLLEABDC.WaitingBuddy);
	}

	public void InitializeNoCard()
	{
		DAHCKIBAPFP = JLANLLEABDC.NoCard;
		KECFEJKBCLH();
		CleanUp();
	}

	private void JMIDHMAJNBK()
	{
		float num = 0.583f;
		TweenScale component = CHNGBAGBLBN.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localScale = new Vector3(num, num, 1f);
	}

	public void LNLCKDLNLBG(bool IKNAKAEKION = false)
	{
		DAHCKIBAPFP = JLANLLEABDC.Empty;
		KECFEJKBCLH();
		GEIJCGIPHPA();
		JIIFGBAEBCH.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void GEIJCGIPHPA()
	{
		CNICPOPDDPH(null);
		PGPLFGHKJBF.LOINIDOGNCO();
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Remove(pGPLFGHKJBF.JEMKCLKCOMI, new Action(JEGLAFFEDNM));
		JMIDHMAJNBK();
	}

	public void Animate(float KALLNCAFIMP)
	{
		float num = 0.583f;
		float num2 = num * 1.1f;
		TweenScale tweenScale = TweenScale.Begin(CHNGBAGBLBN, 0.25f, new Vector3(num, num, 1f), new Vector3(num2, num2, 1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.delay = Mathf.Max(0f, GuiElementSingle<CardpoolDialog>.instance.HECFOEMLJCD - 0.1f + KALLNCAFIMP);
	}

	protected void Update()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = card.iconTexture;
		}
	}

	public void GBOCAKNNOPK()
	{
		HEIFLBOCMEG(null);
		PGPLFGHKJBF.JCMHGOGNMFO();
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Remove(pGPLFGHKJBF.JEMKCLKCOMI, new Action(InitializeDepositBuddy));
		JMIDHMAJNBK();
	}

	public void FFCCONBHHJG(Card DFFBEFJNDLG)
	{
		DAHCKIBAPFP = JLANLLEABDC.Empty;
		OEHNCMNMLBI();
		CleanUp();
		CNICPOPDDPH(DFFBEFJNDLG);
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
	}

	public void MKENDIKJPLJ(int MPHCNMDIPAI, CardpoolRecord GECBGKFOLOP)
	{
		MPHCNMDIPAI++;
		int num = 79;
		int num2 = 20;
		int num3 = -73;
		int num4 = (num - MPHCNMDIPAI) * num2;
		for (int i = 0; i < LPEIOHAMKJJ.Count; i += 0)
		{
			LPEIOHAMKJJ[i].depth = num3 + num4 + i;
		}
		BBJGODFHBCI.depth = num3 + num4 + 5;
		DPMLMAOJPNL.depth = num3 + num4 + 8;
		IBKLPHAIOOG.depth = num3 + num4 + -65;
		FBLGPCFOFCK.depth = num3 + num4 + -37;
		FHJJAOADAEB = GECBGKFOLOP;
		GBOCAKNNOPK();
	}

	protected void IODGCIIDJEK()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(true);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = card.iconTexture;
		}
	}

	public void PAKBMJBJDNI(float KALLNCAFIMP)
	{
		float num = 1154f;
		float num2 = num * 678f;
		TweenScale tweenScale = TweenScale.Begin(CHNGBAGBLBN, 1993f, new Vector3(num, num, 1762f), new Vector3(num2, num2, 715f));
		tweenScale.NumOfRepetitions = 8;
		tweenScale.style = (UITweener.Style)8;
		tweenScale.delay = Mathf.Max(1485f, GuiElementSingle<CardpoolDialog>.instance.HECFOEMLJCD - 1090f + KALLNCAFIMP);
	}

	private void IHIKLAJKOFO()
	{
		BELLJDAFDNM.SetActive(DAHCKIBAPFP == JLANLLEABDC.NoCard);
		CHNGBAGBLBN.SetActive(DAHCKIBAPFP == JLANLLEABDC.Card);
		MLCGEFIPFAO.SetActive(DAHCKIBAPFP == (JLANLLEABDC)6);
		PFCADHDMBLA.SetActive(DAHCKIBAPFP == JLANLLEABDC.WaitingBuddy);
	}

	public void EFDHALAGJMP(Card DFFBEFJNDLG)
	{
		DAHCKIBAPFP = (JLANLLEABDC)7;
		KECFEJKBCLH();
		GEIJCGIPHPA();
		CNICPOPDDPH(DFFBEFJNDLG);
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
	}

	public void CleanUp()
	{
		card = null;
		PGPLFGHKJBF.JCMHGOGNMFO();
		WinStreakCounter pGPLFGHKJBF = PGPLFGHKJBF;
		pGPLFGHKJBF.JEMKCLKCOMI = (Action)Delegate.Remove(pGPLFGHKJBF.JEMKCLKCOMI, new Action(InitializeDepositBuddy));
		JMIDHMAJNBK();
	}

	public void InitializeCard(Card DFFBEFJNDLG)
	{
		DAHCKIBAPFP = JLANLLEABDC.Card;
		KECFEJKBCLH();
		CleanUp();
		card = DFFBEFJNDLG;
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
	}

	public void KOABMGAPCKP(int MPHCNMDIPAI, CardpoolRecord GECBGKFOLOP)
	{
		MPHCNMDIPAI++;
		int num = 39;
		int num2 = -29;
		int num3 = 126;
		int num4 = (num - MPHCNMDIPAI) * num2;
		for (int i = 0; i < LPEIOHAMKJJ.Count; i++)
		{
			LPEIOHAMKJJ[i].depth = num3 + num4 + i;
		}
		BBJGODFHBCI.depth = num3 + num4 + 3;
		DPMLMAOJPNL.depth = num3 + num4 + 6;
		IBKLPHAIOOG.depth = num3 + num4 + 97;
		FBLGPCFOFCK.depth = num3 + num4 + 48;
		FHJJAOADAEB = GECBGKFOLOP;
		FGHOMNPBMDP();
	}

	[SpecialName]
	private void HEIFLBOCMEG(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}
}
