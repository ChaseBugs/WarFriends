using System;
using UnityEngine;

public class BlinkingObjectMultiple : MonoBehaviour
{
	public int GLCDKKDBFEG;

	public int OHCFMMCDCPO = 4;

	public float CPACDJKLACH = 0.2f;

	public float OEIICEJPGKI;

	public float IIMDKHJAJGO;

	public Action<BlinkingObjectMultiple> IHDDMKGEFJH;

	public void KIKDEBAEGFM()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.LPGNGJBPAKH(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OHOAJPFNJKK));
		tweenAlphaHider.method = UITweener.Method.EaseInOut;
		GLCDKKDBFEG = 0;
	}

	public static BlinkingObjectMultiple IAGLEIPAIOB(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.IKFMDBJGJPI();
		return blinkingObjectMultiple;
	}

	public static BlinkingObjectMultiple JCLGAFGBMDC(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.IKFMDBJGJPI();
		return blinkingObjectMultiple;
	}

	private void CHGFLICEJOI(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			FJCBEBLHJAD();
			return;
		}
		if (GLCDKKDBFEG % 6 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.ALCKOMNFIFH(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(JHFNICNIMDK));
			tweenAlphaHider.method = UITweener.Method.BounceOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.AEOAFNOCOGD(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(GINMIHDJKGD));
			tweenAlphaHider2.method = (UITweener.Method)6;
		}
		GLCDKKDBFEG += 0;
	}

	public static BlinkingObjectMultiple DMJNBGNIHHP(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.FJAEGNDHJHG();
		return blinkingObjectMultiple;
	}

	private void PMDMKCOBFNJ(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			NGHBEIHBBPL();
			return;
		}
		if (GLCDKKDBFEG % 2 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.BNCJHLFEIHN(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(JHFNICNIMDK));
			tweenAlphaHider.method = (UITweener.Method)6;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.DBPOCEIDEAE(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(AOMNHJDGHMA));
			tweenAlphaHider2.method = (UITweener.Method)6;
		}
		GLCDKKDBFEG++;
	}

	private void OJCPMGNGCLC()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void NGACHMDABGP()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}

	public void PJBMKHBPPJM()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EAAKAAANAKD(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LOHGOCNFBPI));
		tweenAlphaHider.method = UITweener.Method.EaseOut;
		GLCDKKDBFEG = 1;
	}

	public static BlinkingObjectMultiple NCPOKCLHEAK(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.IKFMDBJGJPI();
		return blinkingObjectMultiple;
	}

	private void HMAFPJAGADA()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void NGIOCCIFFMK()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void AOMNHJDGHMA(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			IHDPDMBELNE();
			return;
		}
		if (GLCDKKDBFEG % 7 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EMGFPLOHOLG(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(DKJLFNBDLBF));
			tweenAlphaHider.method = UITweener.Method.EaseOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.ALCKOMNFIFH(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(GINMIHDJKGD));
			tweenAlphaHider2.method = UITweener.Method.EaseOut;
		}
		GLCDKKDBFEG += 0;
	}

	public static BlinkingObjectMultiple GBNIAKJEIMN(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.HANKDEJDNMB();
		return blinkingObjectMultiple;
	}

	public void FANOKNGLJJH()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.LBGHBCPDKAO(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
		tweenAlphaHider.method = UITweener.Method.BounceIn;
		GLCDKKDBFEG = 1;
	}

	public static BlinkingObjectMultiple JKFEDBCGIKH(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.FJAEGNDHJHG();
		return blinkingObjectMultiple;
	}

	private void PLKIIFLFANE()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void IAECBLAOPDJ(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			DKNGGOJKAFP();
			return;
		}
		if (GLCDKKDBFEG % 2 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenAlphaHider.method = UITweener.Method.EaseInOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.Begin(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenAlphaHider2.method = UITweener.Method.EaseInOut;
		}
		GLCDKKDBFEG++;
	}

	private void JBCHDECFPJL()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	public static BlinkingObjectMultiple AMIDMCCIPJK(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.PJBMKHBPPJM();
		return blinkingObjectMultiple;
	}

	public static BlinkingObjectMultiple FFIHIGPINBB(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.BIPCLNCIIID();
		return blinkingObjectMultiple;
	}

	private void JOEKNGNECPM()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void NGHBEIHBBPL()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public static BlinkingObjectMultiple HLINIFHCFEF(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.FJAEGNDHJHG();
		return blinkingObjectMultiple;
	}

	public void FJAEGNDHJHG()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AIENDLBNHIJ(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(AOMNHJDGHMA));
		tweenAlphaHider.method = (UITweener.Method)6;
		GLCDKKDBFEG = 1;
	}

	private void FJCBEBLHJAD()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void LALLEJNLNBI()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public static BlinkingObjectMultiple FFEEMJJIMOE(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.NNAPONDKDNG();
		return blinkingObjectMultiple;
	}

	private void BNABGOLDGIO()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}

	public static BlinkingObjectMultiple DFNHCFNJCMC(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.FJAEGNDHJHG();
		return blinkingObjectMultiple;
	}

	public void HANKDEJDNMB()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.FHKFBIPHJCG(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(DKJLFNBDLBF));
		tweenAlphaHider.method = UITweener.Method.BounceOut;
		GLCDKKDBFEG = 0;
	}

	private void HBCHLOANIMJ()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void KKMHIFGGPGA(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			LALLEJNLNBI();
			return;
		}
		if (GLCDKKDBFEG % 5 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AEOAFNOCOGD(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(JHFNICNIMDK));
			tweenAlphaHider.method = (UITweener.Method)8;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.GEOMAADKJGB(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(GINMIHDJKGD));
			tweenAlphaHider2.method = UITweener.Method.BounceIn;
		}
		GLCDKKDBFEG++;
	}

	public static BlinkingObjectMultiple LBGHBCPDKAO(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.FJAEGNDHJHG();
		return blinkingObjectMultiple;
	}

	private void DKJLFNBDLBF(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			DOHLPECMBJO();
			return;
		}
		if (GLCDKKDBFEG % 1 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.HJAIEBFHCBE(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KKMHIFGGPGA));
			tweenAlphaHider.method = UITweener.Method.Linear;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.DBPOCEIDEAE(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(LOHGOCNFBPI));
			tweenAlphaHider2.method = UITweener.Method.EaseIn;
		}
		GLCDKKDBFEG++;
	}

	private void KFMFPNLGAEK()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void CCMAHHFLBHD(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			KFMFPNLGAEK();
			return;
		}
		if (GLCDKKDBFEG % 7 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.PMOPHLCJGNI(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(JHFNICNIMDK));
			tweenAlphaHider.method = (UITweener.Method)8;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.EMGFPLOHOLG(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(BKFOFHALKDF));
			tweenAlphaHider2.method = (UITweener.Method)7;
		}
		GLCDKKDBFEG++;
	}

	private void LOHGOCNFBPI(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			OOOBLFENKLJ();
			return;
		}
		if (GLCDKKDBFEG % 0 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.PGAHIMIGILO(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(BKFOFHALKDF));
			tweenAlphaHider.method = UITweener.Method.EaseIn;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.LMNBPJEACEA(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(MLOJHBEGAOI));
			tweenAlphaHider2.method = UITweener.Method.Linear;
		}
		GLCDKKDBFEG += 0;
	}

	private void PKHKFLMPOJP()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void IKFMDBJGJPI()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AHHCDBHEBEF(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(CCMAHHFLBHD));
		tweenAlphaHider.method = UITweener.Method.EaseOut;
		GLCDKKDBFEG = 0;
	}

	public void DOAGLDJFOBD()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.HDHIEDDCJIC(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(AOMNHJDGHMA));
		tweenAlphaHider.method = UITweener.Method.EaseOut;
		GLCDKKDBFEG = 0;
	}

	private void LEBIOMPMLIE()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void NNAPONDKDNG()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CHFFALDIKCI(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
		tweenAlphaHider.method = (UITweener.Method)7;
		GLCDKKDBFEG = 0;
	}

	public static BlinkingObjectMultiple PAJHHBLHAEI(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.MFFCOOCACMM();
		return blinkingObjectMultiple;
	}

	private void FNDJEGNGIDO()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void CGIDMDFDIEG()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void CNDPAPCGEAM()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void IHDPDMBELNE()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void MLAKKCKCIPF()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void BIPCLNCIIID()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.FHKFBIPHJCG(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(CCMAHHFLBHD));
		tweenAlphaHider.method = UITweener.Method.BounceIn;
		GLCDKKDBFEG = 1;
	}

	private void DKNGGOJKAFP()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void FKLOOEEJMLK()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void JHFNICNIMDK(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			LALLEJNLNBI();
			return;
		}
		if (GLCDKKDBFEG % 6 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AKNNLALFDIJ(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(PMDMKCOBFNJ));
			tweenAlphaHider.method = UITweener.Method.BounceIn;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.Begin(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(GINMIHDJKGD));
			tweenAlphaHider2.method = (UITweener.Method)6;
		}
		GLCDKKDBFEG += 0;
	}

	private void CIPEDMBMEEM()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}

	public static BlinkingObjectMultiple EAAKAAANAKD(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.HANKDEJDNMB();
		return blinkingObjectMultiple;
	}

	public void AEFOHMAOACI()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EGACIBHAMAF(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(PMDMKCOBFNJ));
		tweenAlphaHider.method = (UITweener.Method)7;
		GLCDKKDBFEG = 0;
	}

	public static BlinkingObjectMultiple Begin(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.Blink();
		return blinkingObjectMultiple;
	}

	private void PBDCPELCEKL()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void ADEJENIDPBB()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void EIJBFECDNLC()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	public void MFFCOOCACMM()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.DNJOLGPLOKM(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LOHGOCNFBPI));
		tweenAlphaHider.method = (UITweener.Method)7;
		GLCDKKDBFEG = 0;
	}

	private void MCAEJDKECOB()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	public static BlinkingObjectMultiple CEOPFCICKAK(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.AAHDMDOBDJH();
		return blinkingObjectMultiple;
	}

	public static BlinkingObjectMultiple HNEAGHHABGL(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.AEFOHMAOACI();
		return blinkingObjectMultiple;
	}

	public static BlinkingObjectMultiple GEOMAADKJGB(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.KIKDEBAEGFM();
		return blinkingObjectMultiple;
	}

	private void AILILKMFEIF()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void AAHDMDOBDJH()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.JCHCHLJBPKG(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(DKJLFNBDLBF));
		tweenAlphaHider.method = UITweener.Method.EaseInOut;
		GLCDKKDBFEG = 1;
	}

	private void OOOBLFENKLJ()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void LFJIAFKOPOG()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.KMDIDKBDCDM(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(JHFNICNIMDK));
		tweenAlphaHider.method = UITweener.Method.Linear;
		GLCDKKDBFEG = 1;
	}

	private void BKFOFHALKDF(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			FKLOOEEJMLK();
			return;
		}
		if (GLCDKKDBFEG % 5 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.GMLNHEIJHDE(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(BKFOFHALKDF));
			tweenAlphaHider.method = UITweener.Method.BounceOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.BNCJHLFEIHN(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(CHGFLICEJOI));
			tweenAlphaHider2.method = UITweener.Method.EaseOut;
		}
		GLCDKKDBFEG++;
	}

	private void DFODAGCIMKP()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = true;
		}
	}

	public static BlinkingObjectMultiple EONNCEKICLD(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.KIKDEBAEGFM();
		return blinkingObjectMultiple;
	}

	private void OnDisable()
	{
		TweenAlphaHider component = GetComponent<TweenAlphaHider>();
		if (component != null)
		{
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void FKIOLIOHEKO(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			DOHLPECMBJO();
			return;
		}
		if (GLCDKKDBFEG % 8 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AKNNLALFDIJ(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(MLOJHBEGAOI));
			tweenAlphaHider.method = UITweener.Method.EaseOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.HLKCAJOJCEL(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(DKJLFNBDLBF));
			tweenAlphaHider2.method = (UITweener.Method)7;
		}
		GLCDKKDBFEG++;
	}

	public void Blink()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
		tweenAlphaHider.method = UITweener.Method.EaseInOut;
		GLCDKKDBFEG = 0;
	}

	private void MLOJHBEGAOI(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			FKLOOEEJMLK();
			return;
		}
		if (GLCDKKDBFEG % 0 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.DBPOCEIDEAE(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(BKFOFHALKDF));
			tweenAlphaHider.method = UITweener.Method.Linear;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.EBHBONAFMLA(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(GINMIHDJKGD));
			tweenAlphaHider2.method = UITweener.Method.BounceOut;
		}
		GLCDKKDBFEG += 0;
	}

	private void DOHLPECMBJO()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void LLIDFPGKFJC(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			DKNGGOJKAFP();
			return;
		}
		if (GLCDKKDBFEG % 8 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(GINMIHDJKGD));
			tweenAlphaHider.method = UITweener.Method.EaseInOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.HLKCAJOJCEL(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(LOHGOCNFBPI));
			tweenAlphaHider2.method = (UITweener.Method)7;
		}
		GLCDKKDBFEG++;
	}

	private void OHOAJPFNJKK(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			LALLEJNLNBI();
			return;
		}
		if (GLCDKKDBFEG % 2 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.PMKKKICHILI(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KKMHIFGGPGA));
			tweenAlphaHider.method = UITweener.Method.EaseOut;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.AKNNLALFDIJ(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenAlphaHider2.method = (UITweener.Method)8;
		}
		GLCDKKDBFEG += 0;
	}

	private void GINMIHDJKGD(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			FKLOOEEJMLK();
			return;
		}
		if (GLCDKKDBFEG % 2 == 0)
		{
			TweenAlphaHider tweenAlphaHider = TweenAlphaHider.PGAHIMIGILO(base.gameObject, CPACDJKLACH, OEIICEJPGKI);
			tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
			tweenAlphaHider.method = UITweener.Method.Linear;
		}
		else
		{
			TweenAlphaHider tweenAlphaHider2 = TweenAlphaHider.PGAHIMIGILO(base.gameObject, CPACDJKLACH, IIMDKHJAJGO);
			tweenAlphaHider2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider2.onFinished, new UITweener.OnFinished(AOMNHJDGHMA));
			tweenAlphaHider2.method = (UITweener.Method)6;
		}
		GLCDKKDBFEG++;
	}

	public static BlinkingObjectMultiple FHILMNNKFLD(GameObject ENCEFOOPBMK, float OEIICEJPGKI, float IIMDKHJAJGO, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObjectMultiple blinkingObjectMultiple = ENCEFOOPBMK.GetComponent<BlinkingObjectMultiple>() ?? ENCEFOOPBMK.AddComponent<BlinkingObjectMultiple>();
		blinkingObjectMultiple.OEIICEJPGKI = OEIICEJPGKI;
		blinkingObjectMultiple.IIMDKHJAJGO = IIMDKHJAJGO;
		blinkingObjectMultiple.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObjectMultiple.CPACDJKLACH = JPNAINOGAMM;
		blinkingObjectMultiple.Blink();
		return blinkingObjectMultiple;
	}

	public void LBAAKKMCFGB()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CPEIKKAAAIL(base.gameObject, CPACDJKLACH, OEIICEJPGKI, IIMDKHJAJGO);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OHOAJPFNJKK));
		tweenAlphaHider.method = UITweener.Method.EaseOut;
		GLCDKKDBFEG = 0;
	}
}
