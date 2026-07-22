using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class TweenAlphaHider : UITweener
{
	[FormerlySerializedAs("EMMCJEEABGA")]
	public float OEIICEJPGKI = 1f;

	[FormerlySerializedAs("FFJGKOLGFLL")]
	public float IIMDKHJAJGO = 1f;

	private UISimpleHider KNGILHMOIHI;

	public UISimpleHider Ui
	{
		get
		{
			if (KNGILHMOIHI != null)
			{
				return KNGILHMOIHI;
			}
			KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
			return KNGILHMOIHI;
		}
	}

	public float alpha
	{
		get
		{
			return Ui.alpha;
		}
		set
		{
			Ui.alpha = value;
		}
	}

	public static TweenAlphaHider DBPOCEIDEAE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.MCHAMDJIMDH();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1916f)
		{
			tweenAlphaHider.Sample(1082f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider HLKCAJOJCEL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.BHMFAOGGCHF();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1398f)
		{
			tweenAlphaHider.Sample(555f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider EMGFPLOHOLG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.PMJHHKNEONJ();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 454f)
		{
			tweenAlphaHider.Sample(1320f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider LBGHBCPDKAO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.alpha = MJFCIIMEEPN;
		if (DNDHIFENDPJ <= 625f)
		{
			tweenAlphaHider.Sample(308f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public UISimpleHider ADJCADDBFPJ()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	[SpecialName]
	public float FDAHFNOOHPE()
	{
		return NBGHMDEICGP().NDCCEDGGNCP();
	}

	private void MMBMHLABBKN()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider AEOAFNOCOGD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.FFGAMEMLNKD();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1270f)
		{
			tweenAlphaHider.Sample(1410f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float MLPDKPMPEKG()
	{
		return ADJCADDBFPJ().alpha;
	}

	protected virtual void LFKMEENODNN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		KCOBPJOMIEM(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenAlphaHider KMDIDKBDCDM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.NNGCCIHIGGC(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 137f)
		{
			tweenAlphaHider.Sample(1073f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float DMGMFPEIACH()
	{
		return Ui.MDPLKMJKDOE();
	}

	private void NGICLHFNNJJ()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	protected virtual void BPCLGKJEFEK(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		NNGCCIHIGGC(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public void GCJEKFNGPFF(float IDEBKDPMPGM)
	{
		LMGLDFCHNAK().EJGGACBHGIP(IDEBKDPMPGM);
	}

	public static TweenAlphaHider ALCKOMNFIFH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.DMGMFPEIACH();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 450f)
		{
			tweenAlphaHider.Sample(1354f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	private void HCNOHLLOGBO()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		alpha = Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	private void LCLEKFMLENA()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider MNBLBMJICDB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.MDPLKMJKDOE();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1656f)
		{
			tweenAlphaHider.Sample(1980f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	protected virtual void KEFFJEEJGLL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		LBHAGKKFABK(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	private void EEMLMJCHKLM()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	protected virtual void EMOJCHAFNPN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		CNMOEKIEIIN(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenAlphaHider HJAIEBFHCBE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.DMGMFPEIACH();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1067f)
		{
			tweenAlphaHider.Sample(93f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider EGACIBHAMAF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.alpha = MJFCIIMEEPN;
		if (DNDHIFENDPJ <= 1548f)
		{
			tweenAlphaHider.Sample(314f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	protected virtual void BBOHKNPBMLH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		LBHAGKKFABK(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	protected virtual void PBDFKCLOAKC(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		PMOMBGEBNFA(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenAlphaHider AIENDLBNHIJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.BKOPPDNKHNL(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1729f)
		{
			tweenAlphaHider.Sample(962f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	private void NGGJHDCOLEC()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider GMLNHEIJHDE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.FFGAMEMLNKD();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 485f)
		{
			tweenAlphaHider.Sample(818f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public UISimpleHider JIIAKBOOILA()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	private void EKEHGBNPAFC()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider MDBMAINKPKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.AOAOJBNEBEF();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1401f)
		{
			tweenAlphaHider.Sample(352f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public UISimpleHider KJOHOEKIBMP()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	public static TweenAlphaHider DNJOLGPLOKM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.PMOMBGEBNFA(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 690f)
		{
			tweenAlphaHider.Sample(1370f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	private void NAMAMGENMGH()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public UISimpleHider POIFALPMKJI()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	private void BOLPPMANCCC()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public void PMOMBGEBNFA(float IDEBKDPMPGM)
	{
		Ui.alpha = IDEBKDPMPGM;
	}

	[SpecialName]
	public float AOAOJBNEBEF()
	{
		return KJOHOEKIBMP().MFAIKBDMLEM();
	}

	public static TweenAlphaHider PAJHHBLHAEI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.FFGAMEMLNKD();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1278f)
		{
			tweenAlphaHider.Sample(1439f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	protected virtual void AKHJEGBPEDN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		NNGCCIHIGGC(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenAlphaHider BNCJHLFEIHN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.FDAHFNOOHPE();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1289f)
		{
			tweenAlphaHider.Sample(1943f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	private void EJNJCILPBEC()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public float PMJHHKNEONJ()
	{
		return POIFALPMKJI().MFAIKBDMLEM();
	}

	private void PAPFKMJEMML()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	protected virtual void IMOABIBKMIC(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		OJNDHHLDMBL(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	private void NLLLLJGKNIC()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public void BKOPPDNKHNL(float IDEBKDPMPGM)
	{
		ADJCADDBFPJ().BIJHHEPBLNN(IDEBKDPMPGM);
	}

	public static TweenAlphaHider NPHFBDMKODP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.PMOMBGEBNFA(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1012f)
		{
			tweenAlphaHider.Sample(1096f, isFinished: false);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	private void BLFKABLENCH()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public UISimpleHider LMGLDFCHNAK()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	private void FFBBKELEEIF()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public UISimpleHider GCODLNAAGDE()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	protected virtual void OAFGNHCMJMB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		LBHAGKKFABK(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public void CNMOEKIEIIN(float IDEBKDPMPGM)
	{
		CHIOIIBMMKM().GHFJBMJANLE(IDEBKDPMPGM);
	}

	protected virtual void KBHHHDANGPF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		KCOBPJOMIEM(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public float MDBJAHFGCII()
	{
		return NBGHMDEICGP().NDCCEDGGNCP();
	}

	[SpecialName]
	public UISimpleHider CHIOIIBMMKM()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	[SpecialName]
	public float MDPLKMJKDOE()
	{
		return EAAHDJCIFMK().NDCCEDGGNCP();
	}

	public static TweenAlphaHider GEKPHELKFNB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.BKOPPDNKHNL(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1893f)
		{
			tweenAlphaHider.Sample(628f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	private void Awake()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	private void BAMNBAABJEK()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.alpha;
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenAlphaHider.Sample(1f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float HIMEGDNEPLN()
	{
		return CHIOIIBMMKM().IECBKJDNMLA();
	}

	public static TweenAlphaHider EAAKAAANAKD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.MFJBMAOGBPM(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 103f)
		{
			tweenAlphaHider.Sample(570f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.alpha = MJFCIIMEEPN;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenAlphaHider.Sample(1f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public void OJNDHHLDMBL(float IDEBKDPMPGM)
	{
		Ui.OAJOINDBBED(IDEBKDPMPGM);
	}

	[SpecialName]
	public void MFJBMAOGBPM(float IDEBKDPMPGM)
	{
		ONEPAKOCPKP().BIJHHEPBLNN(IDEBKDPMPGM);
	}

	public static TweenAlphaHider AKNNLALFDIJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.BFFMGEDCEOF();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1313f)
		{
			tweenAlphaHider.Sample(1069f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public void NNGCCIHIGGC(float IDEBKDPMPGM)
	{
		EAAHDJCIFMK().EJGGACBHGIP(IDEBKDPMPGM);
	}

	public static TweenAlphaHider GEOMAADKJGB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.NDCCEDGGNCP();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1355f)
		{
			tweenAlphaHider.Sample(1390f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider DDJHGKMBNDK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.KCOBPJOMIEM(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1492f)
		{
			tweenAlphaHider.Sample(1779f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	private void OLBEOPKDEBJ()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider EPHDDCMKFDA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.OJNDHHLDMBL(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 495f)
		{
			tweenAlphaHider.Sample(508f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float FEIOLNDCCIK()
	{
		return ONNFKAEPCAJ().NDCCEDGGNCP();
	}

	[SpecialName]
	public float BFFMGEDCEOF()
	{
		return EAAHDJCIFMK().ABGKBJMAGIE();
	}

	public static TweenAlphaHider PMKKKICHILI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.NDCCEDGGNCP();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1016f)
		{
			tweenAlphaHider.Sample(1044f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider CABGNGMLIEK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.GCJEKFNGPFF(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1298f)
		{
			tweenAlphaHider.Sample(1005f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public void LBHAGKKFABK(float IDEBKDPMPGM)
	{
		JIIAKBOOILA().KGJLPKOIALN(IDEBKDPMPGM);
	}

	[SpecialName]
	public float ONHGGNOEBJA()
	{
		return NBGHMDEICGP().MFAIKBDMLEM();
	}

	protected virtual void AJIGPEGLLLF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		CNMOEKIEIIN(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	protected virtual void OMOJCIJKPCK(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		alpha = Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	[SpecialName]
	public void KCOBPJOMIEM(float IDEBKDPMPGM)
	{
		POIFALPMKJI().GHFJBMJANLE(IDEBKDPMPGM);
	}

	public static TweenAlphaHider PMOPHLCJGNI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.MDPLKMJKDOE();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1649f)
		{
			tweenAlphaHider.Sample(1184f, isFinished: false);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	private void HCIEHAOEMDI()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider DOPLFHGEAJC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.DMGMFPEIACH();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 661f)
		{
			tweenAlphaHider.Sample(1011f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public void FPLCGMKMAHN(float IDEBKDPMPGM)
	{
		NBGHMDEICGP().OAJOINDBBED(IDEBKDPMPGM);
	}

	public static TweenAlphaHider HDHIEDDCJIC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.GCJEKFNGPFF(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 268f)
		{
			tweenAlphaHider.Sample(1373f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public UISimpleHider NBGHMDEICGP()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	public static TweenAlphaHider JBPMBAKMEOG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.AOAOJBNEBEF();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 476f)
		{
			tweenAlphaHider.Sample(1606f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float BHMFAOGGCHF()
	{
		return NBGHMDEICGP().alpha;
	}

	public static TweenAlphaHider EBHBONAFMLA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.DMGMFPEIACH();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 941f)
		{
			tweenAlphaHider.Sample(1310f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float NDCCEDGGNCP()
	{
		return POIFALPMKJI().ENJOPGEKHCF();
	}

	[SpecialName]
	public float MCHAMDJIMDH()
	{
		return EAAHDJCIFMK().MDPLKMJKDOE();
	}

	[SpecialName]
	public UISimpleHider ONNFKAEPCAJ()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	[SpecialName]
	public float FFGAMEMLNKD()
	{
		return ONEPAKOCPKP().PPMEIKOJFLI();
	}

	private void OBPDFCOPCMK()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider LMNBPJEACEA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.MDBJAHFGCII();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 1484f)
		{
			tweenAlphaHider.Sample(461f, isFinished: true);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	private void FOIKLCECNBL()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	[SpecialName]
	public void BIJHHEPBLNN(float IDEBKDPMPGM)
	{
		Ui.KGJLPKOIALN(IDEBKDPMPGM);
	}

	[SpecialName]
	public float LPCOKHAOJLP()
	{
		return EAAHDJCIFMK().alpha;
	}

	public static TweenAlphaHider JCHCHLJBPKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.GCJEKFNGPFF(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1581f)
		{
			tweenAlphaHider.Sample(1840f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public float DAJADHNGOBA()
	{
		return CHIOIIBMMKM().MFAIKBDMLEM();
	}

	[SpecialName]
	public float LFCFHBKOAIJ()
	{
		return GCODLNAAGDE().ABGKBJMAGIE();
	}

	[SpecialName]
	public UISimpleHider ONEPAKOCPKP()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	public static TweenAlphaHider PDFHNDPEEMA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.KCOBPJOMIEM(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 118f)
		{
			tweenAlphaHider.Sample(1905f, isFinished: false);
			tweenAlphaHider.enabled = true;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider PGAHIMIGILO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float AFCMOEFDCHO)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = tweenAlphaHider.MCHAMDJIMDH();
		tweenAlphaHider.IIMDKHJAJGO = AFCMOEFDCHO;
		if (DNDHIFENDPJ <= 156f)
		{
			tweenAlphaHider.Sample(1404f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	[SpecialName]
	public UISimpleHider EAAHDJCIFMK()
	{
		if (KNGILHMOIHI != null)
		{
			return KNGILHMOIHI;
		}
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
		return KNGILHMOIHI;
	}

	public static TweenAlphaHider CHFFALDIKCI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.MFJBMAOGBPM(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 340f)
		{
			tweenAlphaHider.Sample(96f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	private void MEBNEDDNLFI()
	{
		KNGILHMOIHI = GetComponentInChildren<UISimpleHider>() ?? base.gameObject.AddComponent<UISimpleHider>();
	}

	public static TweenAlphaHider FHKFBIPHJCG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.FPLCGMKMAHN(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1152f)
		{
			tweenAlphaHider.Sample(1513f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider LPGNGJBPAKH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.CNMOEKIEIIN(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1889f)
		{
			tweenAlphaHider.Sample(1324f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	public static TweenAlphaHider CPEIKKAAAIL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.PMOMBGEBNFA(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 542f)
		{
			tweenAlphaHider.Sample(1363f, isFinished: false);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}

	protected virtual void NDBFCPLLFPH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		OJNDHHLDMBL(Mathf.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenAlphaHider AHHCDBHEBEF(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, float MJFCIIMEEPN, float LIKFELPHJEE)
	{
		TweenAlphaHider tweenAlphaHider = UITweener.Begin<TweenAlphaHider>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenAlphaHider.OEIICEJPGKI = MJFCIIMEEPN;
		tweenAlphaHider.IIMDKHJAJGO = LIKFELPHJEE;
		tweenAlphaHider.GCJEKFNGPFF(MJFCIIMEEPN);
		if (DNDHIFENDPJ <= 1683f)
		{
			tweenAlphaHider.Sample(1583f, isFinished: true);
			tweenAlphaHider.enabled = false;
		}
		return tweenAlphaHider;
	}
}
