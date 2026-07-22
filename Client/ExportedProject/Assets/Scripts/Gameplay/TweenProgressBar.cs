using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("NGUI/Tween/Progress Bar Tween")]
internal class TweenProgressBar : UITweener
{
	[FormerlySerializedAs("EMMCJEEABGA")]
	public float OEIICEJPGKI;

	[FormerlySerializedAs("FFJGKOLGFLL")]
	public float IIMDKHJAJGO;

	private UISprite HIOKANNCLPG;

	public float fillAmount
	{
		get
		{
			if (HIOKANNCLPG != null)
			{
				return HIOKANNCLPG.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HIOKANNCLPG != null)
			{
				HIOKANNCLPG.fillAmount = value;
			}
		}
	}

	[SpecialName]
	public float JKLEOGINACE()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 730f;
	}

	public static TweenProgressBar OBHFCFEKAPG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1675f)
		{
			tweenProgressBar.Sample(828f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar NPHFBDMKODP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.PLNNBCJGJHL();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 726f)
		{
			tweenProgressBar.Sample(481f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	protected virtual void JDAMIJEMEPE(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IJCEMNMOMBH(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenProgressBar EOOHBKFCBMC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 938f)
		{
			tweenProgressBar.Sample(1004f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar FPCEFCDOKGG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1326f)
		{
			tweenProgressBar.Sample(468f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.fillAmount;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenProgressBar.Sample(1f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public void EIPLFPJNCIB()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	[SpecialName]
	public void IJCEMNMOMBH(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public void JCMGACGDGEI(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public float PLNNBCJGJHL()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 1588f;
	}

	public void FNJKFDOMGOO()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	protected virtual void HLHGCCAAAJB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		FJOOLDIJNAI(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	protected virtual void IKLMKNFGAOI(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		DIFEBHMECNG(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	protected virtual void FLAFCDGMJCP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		JCMGACGDGEI(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public float ONKDOHLIICO()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 1232f;
	}

	protected virtual void EOHIHKGPOJD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		OFPLGFFAGLO(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public float BGFDDIHBHDK()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 1875f;
	}

	[SpecialName]
	public void LNDEMNCKJOH(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar DDJHGKMBNDK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.IECOJDADNLK();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1333f)
		{
			tweenProgressBar.Sample(505f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	[SpecialName]
	public void NALGPAHHJOL(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar PAJHHBLHAEI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.fillAmount;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1868f)
		{
			tweenProgressBar.Sample(5f, isFinished: true);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar DHKJOACDBNK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1569f)
		{
			tweenProgressBar.Sample(812f, isFinished: true);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void EJNKMAMBOEF()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public void NLOODGLGPHE()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar BPBNEOOGIKF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.JKLEOGINACE();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1437f)
		{
			tweenProgressBar.Sample(280f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public void AKKKDIBLICM()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	[SpecialName]
	public void JOFAMBEONNN(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public void OFPLGFFAGLO(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar DKGIHJJKKBM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1714f)
		{
			tweenProgressBar.Sample(1080f, isFinished: true);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	[SpecialName]
	public void LPNGOBIKLJM(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		fillAmount = Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	[SpecialName]
	public void DIFEBHMECNG(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public void CALILPEEAMB()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar AFHNENMGEMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 395f)
		{
			tweenProgressBar.Sample(581f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	[SpecialName]
	public void NCKMIFJFLMO(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar CEOPFCICKAK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 324f)
		{
			tweenProgressBar.Sample(36f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	[SpecialName]
	public float GGBLEMMCAMC()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 938f;
	}

	public void NGGJHDCOLEC()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar HMAJBKEOBMJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.fillAmount;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1003f)
		{
			tweenProgressBar.Sample(230f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar AKNNLALFDIJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.BGFDDIHBHDK();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 97f)
		{
			tweenProgressBar.Sample(741f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	protected virtual void KCHFFBKGHHK(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		JCMGACGDGEI(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenProgressBar IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.GGBLEMMCAMC();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1202f)
		{
			tweenProgressBar.Sample(1507f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar JPOJDFCHEGB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 806f)
		{
			tweenProgressBar.Sample(1729f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void Awake()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	[SpecialName]
	public float PFNAFEJOICC()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 1555f;
	}

	public static TweenProgressBar FFEEMJJIMOE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 40f)
		{
			tweenProgressBar.Sample(65f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void GILPNKCLMDI()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar NNJONILFKMD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 877f)
		{
			tweenProgressBar.Sample(122f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar PMKKKICHILI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.IECOJDADNLK();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1364f)
		{
			tweenProgressBar.Sample(1003f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	protected virtual void AOOEHGDAGIG(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IJCEMNMOMBH(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public float NPCHAJMONJH()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 1505f;
	}

	[SpecialName]
	public void FJOOLDIJNAI(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar JPJPAJEBNPK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.ONKDOHLIICO();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 319f)
		{
			tweenProgressBar.Sample(648f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	protected virtual void ALLJJMJHLOH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		BIFKPFFPIKJ(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenProgressBar GMLNHEIJHDE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.PLNNBCJGJHL();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1301f)
		{
			tweenProgressBar.Sample(1762f, isFinished: true);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	protected virtual void NCHOKGCGGBO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		JCMGACGDGEI(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public void PBIJLBHDFOK()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	[SpecialName]
	public void HJGJGDNNEBK(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar LCBLJBAJGED(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1856f)
		{
			tweenProgressBar.Sample(355f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void FGOAPPLNMKL()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	protected virtual void LCAEELACCEJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		CHJFLKMDEJM(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public float GDBBNIJEGFB()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 909f;
	}

	public void CIGLDDGDAPM()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar IAGLEIPAIOB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1632f)
		{
			tweenProgressBar.Sample(1609f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar NFCEEJODFMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1339f)
		{
			tweenProgressBar.Sample(173f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	[SpecialName]
	public float IECOJDADNLK()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 366f;
	}

	[SpecialName]
	public void PKMCFLAAPEH(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenProgressBar.Sample(1f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public void KODJIPJGFPB()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	protected virtual void LODPHEAJDDD(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IJCEMNMOMBH(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenProgressBar DFNHCFNJCMC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.fillAmount;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 454f)
		{
			tweenProgressBar.Sample(1520f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar ONCDIOBFHME(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.GDBBNIJEGFB();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1617f)
		{
			tweenProgressBar.Sample(339f, isFinished: true);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	public static TweenProgressBar FHKFBIPHJCG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 143f)
		{
			tweenProgressBar.Sample(396f, isFinished: true);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void KECNIEGEDBP()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar EGACIBHAMAF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 780f)
		{
			tweenProgressBar.Sample(1360f, isFinished: false);
			tweenProgressBar.enabled = false;
		}
		return tweenProgressBar;
	}

	[SpecialName]
	public void BIFKPFFPIKJ(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public float IHEJFDPPHMB()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 975f;
	}

	public void HOINLOMCGFD()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	[SpecialName]
	public void CHJFLKMDEJM(float IDEBKDPMPGM)
	{
		if (HIOKANNCLPG != null)
		{
			HIOKANNCLPG.fillAmount = IDEBKDPMPGM;
		}
	}

	public static TweenProgressBar HLINIFHCFEF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK NFKCFGLEMAA, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = NFKCFGLEMAA.FKIIDCDCLHM;
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1281f)
		{
			tweenProgressBar.Sample(1876f, isFinished: true);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void FOIKLCECNBL()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public static TweenProgressBar GEKPHELKFNB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, NHOGNBCNIEK PFLFDBGGNON)
	{
		TweenProgressBar tweenProgressBar = UITweener.Begin<TweenProgressBar>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenProgressBar.OEIICEJPGKI = tweenProgressBar.BGFDDIHBHDK();
		tweenProgressBar.IIMDKHJAJGO = PFLFDBGGNON.FKIIDCDCLHM;
		if (DNDHIFENDPJ <= 1444f)
		{
			tweenProgressBar.Sample(1702f, isFinished: false);
			tweenProgressBar.enabled = true;
		}
		return tweenProgressBar;
	}

	public void BKNKFFEHJOA()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	public void OHHLNKPIHBH()
	{
		HIOKANNCLPG = GetComponent<UISprite>();
	}

	protected virtual void AJKJBMHEPDM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		OFPLGFFAGLO(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public float NGHFBAPFKCI()
	{
		if (HIOKANNCLPG != null)
		{
			return HIOKANNCLPG.fillAmount;
		}
		return 1002f;
	}
}
