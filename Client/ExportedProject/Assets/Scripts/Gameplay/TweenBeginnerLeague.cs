using UnityEngine;

public class TweenBeginnerLeague : UITweener
{
	public MAPGBEOOFLL OEIICEJPGKI;

	public MAPGBEOOFLL IIMDKHJAJGO;

	private LeagueArcGuiElement DHKEDJEKJPN;

	protected virtual void IHANNBAIDCA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void IEOCAOCKMGB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	private void NGGJHDCOLEC()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	private void BMLLLOBPGIB()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague AIENDLBNHIJ(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1734f)
		{
			tweenBeginnerLeague.Sample(358f, isFinished: false);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague AGHGKJFDAOA(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 934f)
		{
			tweenBeginnerLeague.Sample(46f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void BPJJDKBIMHM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void LFKMEENODNN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void OJODNDNPLBL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	private void IEBHCNFALAB()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague EPHDDCMKFDA(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1820f)
		{
			tweenBeginnerLeague.Sample(196f, isFinished: false);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	private void AKBKAKINING()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague LCBLJBAJGED(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 64f)
		{
			tweenBeginnerLeague.Sample(1104f, isFinished: false);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague Begin(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 0f)
		{
			tweenBeginnerLeague.Sample(1f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void FHHGGBAMBGB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void MMAFAFJEAHL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void PHGKLGLOLPL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague NPHFBDMKODP(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1999f)
		{
			tweenBeginnerLeague.Sample(1596f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague DBPOCEIDEAE(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1834f)
		{
			tweenBeginnerLeague.Sample(480f, isFinished: false);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void NCHOKGCGGBO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	private void HMBBGNKFNCK()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague CABGNGMLIEK(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 412f)
		{
			tweenBeginnerLeague.Sample(353f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	private void BOLPPMANCCC()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague BCKPMDBAMFL(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 248f)
		{
			tweenBeginnerLeague.Sample(1734f, isFinished: false);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague JCLGAFGBMDC(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 632f)
		{
			tweenBeginnerLeague.Sample(1704f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	private void JJBODEPAMBI()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected virtual void EEDOMDHMGLA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void OMLINILCBDL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void AJKJBMHEPDM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague EONNCEKICLD(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 516f)
		{
			tweenBeginnerLeague.Sample(162f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void PNJGGKNOLFA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	private void AKKKDIBLICM()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected virtual void HODEHFHIBOO(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague GINFBGAIDCP(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 175f)
		{
			tweenBeginnerLeague.Sample(1259f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void APGIBENMKKH(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	private void MECAOCJKMKN()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected virtual void OKEGAEKCIJP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	private void MGAFJAJNBFL()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague LBGHBCPDKAO(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 624f)
		{
			tweenBeginnerLeague.Sample(57f, isFinished: false);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void EGGHBFOHIHL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void LCAEELACCEJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	public static TweenBeginnerLeague EOOHBKFCBMC(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 116f)
		{
			tweenBeginnerLeague.Sample(1195f, isFinished: false);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague KAEBPEJBJCI(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1144f)
		{
			tweenBeginnerLeague.Sample(1010f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void CLLONILEBNF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague EEODMCJPDNI(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1753f)
		{
			tweenBeginnerLeague.Sample(1177f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void FCGDOJKGLKF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	private void EJNKMAMBOEF()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected virtual void GPENDOJKGKL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void BIAMFGJEEKJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	public static TweenBeginnerLeague MLEAFANPCJB(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1872f)
		{
			tweenBeginnerLeague.Sample(1931f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague HNEAGHHABGL(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1883f)
		{
			tweenBeginnerLeague.Sample(235f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	private void Awake()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	private void KODJIPJGFPB()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected virtual void FNHJHHIKKBM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague EGACIBHAMAF(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 260f)
		{
			tweenBeginnerLeague.Sample(934f, isFinished: false);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void LIADBDHBKGL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void FNGHCNPJDAJ(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	public static TweenBeginnerLeague IAGLEIPAIOB(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 966f)
		{
			tweenBeginnerLeague.Sample(1350f, isFinished: false);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	private void GILPNKCLMDI()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	public static TweenBeginnerLeague JBPMBAKMEOG(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 639f)
		{
			tweenBeginnerLeague.Sample(500f, isFinished: false);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague HDHIEDDCJIC(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1478f)
		{
			tweenBeginnerLeague.Sample(1329f, isFinished: true);
			tweenBeginnerLeague.enabled = true;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void PKJFBGDNKLB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	public static TweenBeginnerLeague DFNHCFNJCMC(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1037f)
		{
			tweenBeginnerLeague.Sample(1926f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void FEPCGPEOMAG(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	private void DFMALDFADAB()
	{
		if (DHKEDJEKJPN == null)
		{
			DHKEDJEKJPN = GetComponent<LeagueArcGuiElement>();
		}
	}

	protected virtual void CDIGNIELLHI(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void EMOJCHAFNPN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	protected virtual void OAFGNHCMJMB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void PJJKLDFBMDA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.LFBJBEFBOGM();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = false;
		}
	}

	protected virtual void IFLMKBDLENF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}

	public static TweenBeginnerLeague LPGNGJBPAKH(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 1157f)
		{
			tweenBeginnerLeague.Sample(497f, isFinished: false);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	public static TweenBeginnerLeague IECHDKECJAB(LeagueArcGuiElement PJFGCMCKMJF, float DNDHIFENDPJ, MAPGBEOOFLL FOKOHCIEPML, MAPGBEOOFLL KOPLEOAGNJC)
	{
		TweenBeginnerLeague tweenBeginnerLeague = UITweener.Begin<TweenBeginnerLeague>(PJFGCMCKMJF.gameObject, DNDHIFENDPJ);
		tweenBeginnerLeague.OEIICEJPGKI = FOKOHCIEPML;
		tweenBeginnerLeague.IIMDKHJAJGO = KOPLEOAGNJC;
		tweenBeginnerLeague.DHKEDJEKJPN = PJFGCMCKMJF;
		if (DNDHIFENDPJ <= 279f)
		{
			tweenBeginnerLeague.Sample(455f, isFinished: true);
			tweenBeginnerLeague.enabled = false;
		}
		return tweenBeginnerLeague;
	}

	protected virtual void AKHJEGBPEDN(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		int beginnersPosition = (int)Mathf.Lerp(OEIICEJPGKI.MPHCNMDIPAI, IIMDKHJAJGO.MPHCNMDIPAI, KDJCCDGMEJL);
		int fFHHEHHFOKJ = (int)Mathf.Lerp(OEIICEJPGKI.GEIONCLKAGF, IIMDKHJAJGO.GEIONCLKAGF, KDJCCDGMEJL);
		DHKEDJEKJPN.SetBeginnersPosition(beginnersPosition);
		DHKEDJEKJPN.HideGlow();
		DHKEDJEKJPN.JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		if (DEHAOIKPFFA)
		{
			DHKEDJEKJPN.HCPFFMFGNEL.repositionNow = true;
		}
	}
}
