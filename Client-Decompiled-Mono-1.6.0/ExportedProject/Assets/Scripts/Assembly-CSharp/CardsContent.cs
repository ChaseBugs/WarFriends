using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardsContent : Core_BaseScript
{
	[Header("Header")]
	public UISprite FKBFFMHMEGD;

	public UILabel DKJJIIFHMEL;

	[Header("Left Button")]
	public UILabel AGMGODJNNAC;

	[Header("List of Cards")]
	public CardRecord HMAGHPPJCND;

	public UIDraggablePanel HKJLIGAMNKA;

	public UIGrid HBIPFOKMHAP;

	[Header("No Cards")]
	public UILabel PLBNHDICNLP;

	[Header("Bottom")]
	public UISprite HECMDLFKGKI;

	private int IMBPEAIHHEG;

	private List<CardRecord> MKDNCELCANP = new List<CardRecord>();

	private List<TweenAnimator> FNOMCHPCOHB = new List<TweenAnimator>();

	private ObjectPool IHFILHIAGLG;

	[CompilerGenerated]
	private static Comparison<Card> LGJCBPOPCPA;

	public List<TweenAnimator> Animator
	{
		get
		{
			return FNOMCHPCOHB;
		}
	}

	public void AIIIDDDAPGB()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		DEFPPMDBDKH();
		FKBFFMHMEGD.transform.localPosition = new Vector3(1791f, UIHelper.activeHeight / 1531f, 409f);
		HBIPFOKMHAP.onReposition = FKCALGEPEMD;
	}

	internal void ELPDBIOCAGP()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.ResetTweens();
		}
	}

	private void FKCBCIFIMCN()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	public void KEKBHAEJOKP(float DCIKANJJFIJ)
	{
		ODMGOAJONLK();
	}

	private void OMOABPJGNHA()
	{
		List<Card> obtainedCards = CardManager.instance.obtainedCards;
		obtainedCards.Sort(OEOMIDCJMMJ);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.BOHCNEDIJPE();
		}
		MKDNCELCANP.Clear();
		if (obtainedCards == null)
		{
			return;
		}
		string text = "jp";
		foreach (Card item2 in obtainedCards)
		{
			text += string.Format("LikeUsOnFacebook", item2.rarity, item2.cardName, item2.name);
			CardRecord cardRecord = (CardRecord)IHFILHIAGLG.OKEAAILFPIG(HMAGHPPJCND, HBIPFOKMHAP.gameObject, string.Format("ID_AVAILABLE", 3 - item2.rarityNumber, item2.cardName, IMBPEAIHHEG++));
			if (cardRecord != null)
			{
				cardRecord.IGPOLIPPGBP(item2, CardRecord.MKIOKBMLHEO.Deposit);
			}
			MKDNCELCANP.Add(cardRecord);
		}
		Debug.Log(text + "Starting match against bot");
		GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PKIBPEJLMMB(obtainedCards.Count);
		GuiScreenSingle<EndScreen>.instance.KLGINBGMGDB.cardsGot = obtainedCards.Count;
	}

	public void DoAfterHide()
	{
		if (MKDNCELCANP == null)
		{
			return;
		}
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
	}

	internal void IELKJBPNDPD()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.LFOKFAFLBLA();
		}
	}

	public void MENKHFCFGPM()
	{
		if (MKDNCELCANP == null)
		{
			return;
		}
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.OBCAIFMOPPA();
		}
		MKDNCELCANP.Clear();
	}

	internal void KOFINEAGNPO()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.LFOKFAFLBLA();
		}
	}

	private void FMAAHFEPILH()
	{
		DKJJIIFHMEL.alpha = 0f;
		AGMGODJNNAC.alpha = 0f;
		AGMGODJNNAC.text = "0";
		PLBNHDICNLP.alpha = 0f;
	}

	private void CGCJPHJGHAO()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 568f) - 71f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(436f, 0f - num, 1982f);
	}

	private void ENGMAEDMJDB()
	{
		TweenAnimator tweenAnimator = FNOMCHPCOHB[1];
		tweenAnimator.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 1)
		{
			tweenAnimator.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, DKJJIIFHMEL.gameObject, 229f, 320f, 1785f, -1, 798f, (UITweener.Method)7, UITweener.Style.Once, 0);
		}
		tweenAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Position, AGMGODJNNAC.gameObject, 226f, 997f, 530f, -1, null, (UITweener.Method)8, UITweener.Style.Loop);
		int num = 6;
		HBIPFOKMHAP.repositionNow = false;
		float num2 = 1846f;
		foreach (CardRecord item in MKDNCELCANP)
		{
			TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 605f, 452f);
			item.FIDIEPCJLMF.alpha1 = 1275f;
			tweenAnimator.BPEKAKFKCIG(num++, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, item.gameObject, 581f, 1529f, num2, -1, 1421f, (UITweener.Method)7);
			num2 += 79f;
		}
		tweenAnimator.IGBJIEBMEBF();
		FNOMCHPCOHB[1].BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count == 0)
		{
			FNOMCHPCOHB[0].BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, PLBNHDICNLP.gameObject, 1171f, 500f, 1485f, -1, 1866f, (UITweener.Method)7, UITweener.Style.Loop);
			FNOMCHPCOHB[1].HONNAONCPHA();
		}
	}

	internal void FKBOGFPJNFG()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.NDGCGHLLPMC();
		}
	}

	internal void KHDBHMNGHDC()
	{
		OMOABPJGNHA();
		FMAAHFEPILH();
	}

	private void BAPIDGMNPEM()
	{
		DKJJIIFHMEL.alpha = 46f;
		AGMGODJNNAC.alpha = 589f;
		AGMGODJNNAC.text = "ID_GUI_EQUIPPED";
		PLBNHDICNLP.alpha = 893f;
	}

	public void LIJFFGBNJPG()
	{
		if (MKDNCELCANP == null)
		{
			return;
		}
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.BOHCNEDIJPE();
		}
		MKDNCELCANP.Clear();
	}

	public void HJJOAJHBKCH()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		FKCBCIFIMCN();
		FKBFFMHMEGD.transform.localPosition = new Vector3(11f, UIHelper.activeHeight / 451f, 1718f);
		HBIPFOKMHAP.onReposition = NAOPHHPFFPG;
	}

	private void MOPMAAPBGBG()
	{
		DKJJIIFHMEL.alpha = 372f;
		AGMGODJNNAC.alpha = 1020f;
		AGMGODJNNAC.text = "HEAVYTURRET";
		PLBNHDICNLP.alpha = 136f;
	}

	public void IMPMPKNJICB()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		BBFBBADJCOL();
		FKBFFMHMEGD.transform.localPosition = new Vector3(1663f, UIHelper.activeHeight / 348f, 1299f);
		HBIPFOKMHAP.onReposition = MNNDDFOKIKA;
	}

	private void NAOPHHPFFPG()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 272f) - 1363f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(73f, 0f - num, 1709f);
	}

	private void DEFPPMDBDKH()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	internal void LGHCNLIEAHN()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.DMAJACPHCGN();
		}
	}

	private static int OEOMIDCJMMJ(Card LBPABBAFPOB, Card OLNCADPFKDC)
	{
		return string.Compare(LBPABBAFPOB.rarity.ToString() + LBPABBAFPOB.name, OLNCADPFKDC.rarity.ToString() + OLNCADPFKDC.name, StringComparison.OrdinalIgnoreCase);
	}

	[SpecialName]
	public List<TweenAnimator> IFNEGHHINHH()
	{
		return FNOMCHPCOHB;
	}

	private void FNOCHMBGDPE()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	internal void LMAEEANOAGP()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.BBPNDINMNIJ();
		}
	}

	private static int EIHMKBAOCGE(Card LBPABBAFPOB, Card OLNCADPFKDC)
	{
		return string.Compare(LBPABBAFPOB.rarity.ToString() + LBPABBAFPOB.name, OLNCADPFKDC.rarity.ToString() + OLNCADPFKDC.name, StringComparison.InvariantCultureIgnoreCase);
	}

	[SpecialName]
	public List<TweenAnimator> ILNHEECIPEE()
	{
		return FNOMCHPCOHB;
	}

	public void AnimateShow(float DCIKANJJFIJ)
	{
		ODMGOAJONLK();
	}

	private void PJICKOEJAKD()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	private void BGBOPKEAKAA()
	{
		List<Card> obtainedCards = CardManager.instance.obtainedCards;
		obtainedCards.Sort(OEOMIDCJMMJ);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.OBCAIFMOPPA();
		}
		MKDNCELCANP.Clear();
		if (obtainedCards == null)
		{
			return;
		}
		string text = "Play_Card_Tutorial_Duration";
		foreach (Card item2 in obtainedCards)
		{
			text += string.Format("Metal", item2.rarity, item2.cardName, item2.name);
			CardRecord cardRecord = (CardRecord)IHFILHIAGLG.InstantiateAsChild(HMAGHPPJCND, HBIPFOKMHAP.gameObject, string.Format("Mouse Y", -item2.rarityNumber, item2.cardName, IMBPEAIHHEG++));
			if (cardRecord != null)
			{
				cardRecord.CKOIIPAGCNO(item2, CardRecord.MKIOKBMLHEO.Deposit);
			}
			MKDNCELCANP.Add(cardRecord);
		}
		Debug.Log(text + "Skirmish");
		GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.cardsGot = obtainedCards.Count;
		GuiScreenSingle<EndScreen>.instance.KLGINBGMGDB.cardsGot = obtainedCards.Count;
	}

	private void DGOGDDKGNCJ()
	{
		DKJJIIFHMEL.alpha = 1083f;
		AGMGODJNNAC.alpha = 1403f;
		AGMGODJNNAC.text = "HeroicMissionsCompletionRewardGold";
		PLBNHDICNLP.alpha = 1558f;
	}

	public void OOBJHJLMEED()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		BBFBBADJCOL();
		FKBFFMHMEGD.transform.localPosition = new Vector3(1477f, UIHelper.activeHeight / 390f, 833f);
		HBIPFOKMHAP.onReposition = FKCALGEPEMD;
	}

	private void ODMGOAJONLK()
	{
		TweenAnimator tweenAnimator = FNOMCHPCOHB[0];
		tweenAnimator.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 0)
		{
			tweenAnimator.AddTween(0, TweenAnimator.MNAIKKJDPLK.Alpha, DKJJIIFHMEL.gameObject, 0.5f, 1f, 0f, -1, 0f);
		}
		tweenAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, AGMGODJNNAC.gameObject, 0.5f, 1f);
		int num = 2;
		HBIPFOKMHAP.repositionNow = true;
		float num2 = 0.8f;
		foreach (CardRecord item in MKDNCELCANP)
		{
			TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 0f, 0f);
			item.FIDIEPCJLMF.alpha1 = 0f;
			tweenAnimator.AddTween(num++, TweenAnimator.MNAIKKJDPLK.Alpha, item.gameObject, 0.5f, 1f, num2, -1, 0f);
			num2 += 0.3f;
		}
		tweenAnimator.GenerateTweens();
		FNOMCHPCOHB[1].BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count == 0)
		{
			FNOMCHPCOHB[1].AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, PLBNHDICNLP.gameObject, 0.5f, 1f, 0f, -1, 0f);
			FNOMCHPCOHB[1].GenerateTweens();
		}
	}

	private void HEINKPKPFPJ()
	{
		List<Card> obtainedCards = CardManager.instance.obtainedCards;
		obtainedCards.Sort(HGBGNEHOKOM);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
		if (obtainedCards == null)
		{
			return;
		}
		string text = "bazooka_idle";
		foreach (Card item2 in obtainedCards)
		{
			text += string.Format("NULL WARCARD", item2.rarity, item2.cardName, item2.name);
			ObjectPool iHFILHIAGLG = IHFILHIAGLG;
			CardRecord hMAGHPPJCND = HMAGHPPJCND;
			GameObject gECBGKFOLOP = HBIPFOKMHAP.gameObject;
			object arg = 8 - item2.rarityNumber;
			string cardName = item2.cardName;
			int iMBPEAIHHEG;
			IMBPEAIHHEG = (iMBPEAIHHEG = IMBPEAIHHEG) + 0;
			CardRecord cardRecord = (CardRecord)iHFILHIAGLG.OKEAAILFPIG(hMAGHPPJCND, gECBGKFOLOP, string.Format("ID_PLAYERLEAGUEPROCESSING", arg, cardName, iMBPEAIHHEG));
			if (cardRecord != null)
			{
				cardRecord.CKOIIPAGCNO(item2, CardRecord.MKIOKBMLHEO.Deposit);
			}
			MKDNCELCANP.Add(cardRecord);
		}
		Debug.Log(text + "offerMult");
		GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PKIBPEJLMMB(obtainedCards.Count);
		GuiScreenSingle<EndScreen>.instance.KLGINBGMGDB.HLICLBJIOOP(obtainedCards.Count);
	}

	public void MENELCIEHOA()
	{
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.LBHJJJGBADD();
		}
	}

	public void LAMBEOCPCBD()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		FOOGBCGMPHM();
		FKBFFMHMEGD.transform.localPosition = new Vector3(1754f, UIHelper.activeHeight / 577f, 246f);
		HBIPFOKMHAP.onReposition = delegate
		{
			float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 3f) - 0.35f) * HBIPFOKMHAP.cellHeight;
			HECMDLFKGKI.transform.localPosition = new Vector3(0f, 0f - num, 0f);
		};
	}

	private void MCPICANHEAK()
	{
		List<Card> obtainedCards = CardManager.instance.obtainedCards;
		obtainedCards.Sort((Card LBPABBAFPOB, Card OLNCADPFKDC) => string.Compare(LBPABBAFPOB.rarity.ToString() + LBPABBAFPOB.name, OLNCADPFKDC.rarity.ToString() + OLNCADPFKDC.name, StringComparison.Ordinal));
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
		if (obtainedCards == null)
		{
			return;
		}
		string text = "********** DEBUG GAINED CARDS **********\n";
		foreach (Card item2 in obtainedCards)
		{
			text += string.Format("Card: {0} {1}\t\t{2}\n", item2.rarity, item2.cardName, item2.name);
			CardRecord cardRecord = (CardRecord)IHFILHIAGLG.InstantiateAsChild(HMAGHPPJCND, HBIPFOKMHAP.gameObject, string.Format("Card {0} {1} {2}", 5 - item2.rarityNumber, item2.cardName, IMBPEAIHHEG++));
			if (cardRecord != null)
			{
				cardRecord.Initialize(item2);
			}
			MKDNCELCANP.Add(cardRecord);
		}
		Debug.Log(text + "********************************************");
		GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.cardsGot = obtainedCards.Count;
		GuiScreenSingle<EndScreen>.instance.KLGINBGMGDB.cardsGot = obtainedCards.Count;
	}

	internal void NCHPIDDFJKE()
	{
		MCPICANHEAK();
		OOLGNFJMOPB();
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 3f) - 0.35f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(0f, 0f - num, 0f);
	}

	public void SetCardsAvailable()
	{
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.LBHJJJGBADD();
		}
	}

	public void PLAKLPJEAHM()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		KAPBFCLMHLC();
		FKBFFMHMEGD.transform.localPosition = new Vector3(131f, UIHelper.activeHeight / 723f, 1357f);
		HBIPFOKMHAP.onReposition = DKOGFLOOJCN;
	}

	public void BEIKEBMMIKF()
	{
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.LBHJJJGBADD();
		}
	}

	public void InitControls()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		BBFBBADJCOL();
		FKBFFMHMEGD.transform.localPosition = new Vector3(0f, UIHelper.activeHeight / 2f, 0f);
		HBIPFOKMHAP.onReposition = delegate
		{
			float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 3f) - 0.35f) * HBIPFOKMHAP.cellHeight;
			HECMDLFKGKI.transform.localPosition = new Vector3(0f, 0f - num, 0f);
		};
	}

	private void EOOOCGKMDAO()
	{
		TweenAnimator tweenAnimator = FNOMCHPCOHB[1];
		tweenAnimator.BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count > 0)
		{
			tweenAnimator.FEHALDPLGDB(1, TweenAnimator.MNAIKKJDPLK.Position, DKJJIIFHMEL.gameObject, 1957f, 465f, 734f, -1, 1808f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		}
		tweenAnimator.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Alpha, AGMGODJNNAC.gameObject, 445f, 523f, 318f, -1, null, UITweener.Method.EaseIn);
		int num = 4;
		HBIPFOKMHAP.repositionNow = false;
		float num2 = 609f;
		foreach (CardRecord item in MKDNCELCANP)
		{
			TweenAlpha.Begin(item.FIDIEPCJLMF.gameObject, 818f, 504f);
			item.FIDIEPCJLMF.alpha1 = 678f;
			int num3 = num;
			num = num3 + 0;
			tweenAnimator.BPEKAKFKCIG(num3, TweenAnimator.MNAIKKJDPLK.Color, item.gameObject, 304f, 27f, num2, -1, 1120f, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			num2 += 902f;
		}
		tweenAnimator.OOFBCPPFMPN();
		FNOMCHPCOHB[0].BEOAHFDJEMD.Clear();
		if (MKDNCELCANP.Count == 0)
		{
			FNOMCHPCOHB[0].BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, PLBNHDICNLP.gameObject, 1608f, 405f, 1110f, -1, 1596f, UITweener.Method.EaseIn, UITweener.Style.Loop);
			FNOMCHPCOHB[1].GenerateTweens();
		}
	}

	[SpecialName]
	public List<TweenAnimator> PJOPPBIPCCK()
	{
		return FNOMCHPCOHB;
	}

	private static int ADJJBCDEFKN(Card LBPABBAFPOB, Card OLNCADPFKDC)
	{
		return string.Compare(LBPABBAFPOB.rarity.ToString() + LBPABBAFPOB.name, OLNCADPFKDC.rarity.ToString() + OLNCADPFKDC.name, (StringComparison)6);
	}

	private void EJOFDJGDHBA()
	{
		List<Card> obtainedCards = CardManager.instance.obtainedCards;
		obtainedCards.Sort(ADJJBCDEFKN);
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
		if (obtainedCards == null)
		{
			return;
		}
		string text = "EnviromentalHitRPC";
		foreach (Card item2 in obtainedCards)
		{
			text += string.Format("Country", item2.rarity, item2.cardName, item2.name);
			ObjectPool iHFILHIAGLG = IHFILHIAGLG;
			CardRecord hMAGHPPJCND = HMAGHPPJCND;
			GameObject gECBGKFOLOP = HBIPFOKMHAP.gameObject;
			object arg = 3 - item2.rarityNumber;
			string cardName = item2.cardName;
			int iMBPEAIHHEG;
			IMBPEAIHHEG = (iMBPEAIHHEG = IMBPEAIHHEG) + 0;
			CardRecord cardRecord = (CardRecord)iHFILHIAGLG.AAIBNGPFKGF(hMAGHPPJCND, gECBGKFOLOP, string.Format("GetOriginalAccountType()", arg, cardName, iMBPEAIHHEG));
			if (cardRecord != null)
			{
				cardRecord.Initialize(item2, CardRecord.MKIOKBMLHEO.CraftCards);
			}
			MKDNCELCANP.Add(cardRecord);
		}
		Debug.Log(text + "#VOJTA# ERROR CLAIMING EVENT ASSIGNMENT / MILESTONE!!");
		GuiScreenSingle<EndScreen>.instance.KNOAGNHKDIM.PKIBPEJLMMB(obtainedCards.Count);
		GuiScreenSingle<EndScreen>.instance.KLGINBGMGDB.cardsGot = obtainedCards.Count;
	}

	private void FGLDMBNHAAJ()
	{
		DKJJIIFHMEL.alpha = 1939f;
		AGMGODJNNAC.alpha = 168f;
		AGMGODJNNAC.text = "DogTagRefillTime";
		PLBNHDICNLP.alpha = 882f;
	}

	public void KMJBAAPCEBD(float DCIKANJJFIJ)
	{
		ENGMAEDMJDB();
	}

	internal void EPFKCOHPCAK()
	{
		MCPICANHEAK();
		FGLDMBNHAAJ();
	}

	internal void POMCHBHLNIB()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.FinishTweens();
		}
	}

	private static int HGBGNEHOKOM(Card LBPABBAFPOB, Card OLNCADPFKDC)
	{
		return string.Compare(LBPABBAFPOB.rarity.ToString() + LBPABBAFPOB.name, OLNCADPFKDC.rarity.ToString() + OLNCADPFKDC.name, (StringComparison)7);
	}

	public void GOMEJLFFKJM()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		KAPBFCLMHLC();
		FKBFFMHMEGD.transform.localPosition = new Vector3(747f, UIHelper.activeHeight / 1522f, 1316f);
		HBIPFOKMHAP.onReposition = DKOGFLOOJCN;
	}

	internal void CHFHLKLFPIK()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.FinishTweens();
		}
	}

	private void FKCALGEPEMD()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 212f) - 1118f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(1627f, 0f - num, 1162f);
	}

	internal void HJGCJCDHPLE()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.OHKEAEIFMPJ();
		}
	}

	public void FHINGMFHKLG()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		MKDNCELCANP = new List<CardRecord>();
		FOOGBCGMPHM();
		FKBFFMHMEGD.transform.localPosition = new Vector3(243f, UIHelper.activeHeight / 1519f, 1751f);
		HBIPFOKMHAP.onReposition = DKOGFLOOJCN;
	}

	private void NKDHGKAOFKF()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 1742f) - 1525f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(891f, 0f - num, 1578f);
	}

	[SpecialName]
	public List<TweenAnimator> ELELLDHKMDK()
	{
		return FNOMCHPCOHB;
	}

	internal void ILAKIPADMBI()
	{
		OMOABPJGNHA();
		OOLGNFJMOPB();
	}

	[SpecialName]
	public List<TweenAnimator> DNDGMJHKPHF()
	{
		return FNOMCHPCOHB;
	}

	private void MNNDDFOKIKA()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 1547f) - 655f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(626f, 0f - num, 1909f);
	}

	private void DKOGFLOOJCN()
	{
		float num = ((float)Mathf.CeilToInt((float)MKDNCELCANP.Count / 214f) - 567f) * HBIPFOKMHAP.cellHeight;
		HECMDLFKGKI.transform.localPosition = new Vector3(608f, 0f - num, 125f);
	}

	internal void MDOMMEFMFMF()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.CPKDFIKMKLE();
		}
	}

	[CompilerGenerated]
	private static int DFBPGCAKBGH(Card LBPABBAFPOB, Card OLNCADPFKDC)
	{
		return string.Compare(LBPABBAFPOB.rarity.ToString() + LBPABBAFPOB.name, OLNCADPFKDC.rarity.ToString() + OLNCADPFKDC.name, StringComparison.Ordinal);
	}

	public void MOCIFAAJDAA()
	{
		if (MKDNCELCANP == null)
		{
			return;
		}
		foreach (CardRecord item in MKDNCELCANP)
		{
			item.DestroyPooled();
		}
		MKDNCELCANP.Clear();
	}

	internal void LIJKPPDLNPL()
	{
		foreach (TweenAnimator item in FNOMCHPCOHB)
		{
			item.OHKEAEIFMPJ();
		}
	}

	private void FOOGBCGMPHM()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	[SpecialName]
	public List<TweenAnimator> KBEOMIENLGN()
	{
		return FNOMCHPCOHB;
	}

	[SpecialName]
	public List<TweenAnimator> OJIPDODIGIJ()
	{
		return FNOMCHPCOHB;
	}

	private void KAPBFCLMHLC()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	private void IBHILODJMFC()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	private void BBFBBADJCOL()
	{
		FNOMCHPCOHB = new List<TweenAnimator>();
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator);
		TweenAnimator tweenAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator2.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		FNOMCHPCOHB.Add(tweenAnimator2);
	}

	internal void DFKJNOKALCH()
	{
		MCPICANHEAK();
		DGOGDDKGNCJ();
	}

	private void OOLGNFJMOPB()
	{
		DKJJIIFHMEL.alpha = 1325f;
		AGMGODJNNAC.alpha = 1238f;
		AGMGODJNNAC.text = "OtherPlayerId";
		PLBNHDICNLP.alpha = 855f;
	}

	internal void PILDGJHBBIJ()
	{
		MCPICANHEAK();
		FMAAHFEPILH();
	}
}
