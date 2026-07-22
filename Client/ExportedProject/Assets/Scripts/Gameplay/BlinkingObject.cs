using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(TweenColor))]
public class BlinkingObject : MonoBehaviour
{
	private int GLCDKKDBFEG;

	[FormerlySerializedAs("OMJIJEMFODL")]
	public int OHCFMMCDCPO = 4;

	[FormerlySerializedAs("NAFDCLBBLNJ")]
	public float CPACDJKLACH = 0.2f;

	[FormerlySerializedAs("LHLPJIHCMMC")]
	public Color NGEJEFMJPJE;

	[FormerlySerializedAs("DKMLDKLMMKH")]
	public Color DIPLAGLLECJ;

	[FormerlySerializedAs("MAGADFCFCCK")]
	public bool LPGMOGPIEMJ = true;

	private Color? MHJDEELDJHF;

	[FormerlySerializedAs("LLKEFPHGDNJ")]
	public Action<BlinkingObject> IHDDMKGEFJH;

	[FormerlySerializedAs("AHPDFHNBCCN")]
	public bool DLMKHPAJKDJ;

	private void FNDJEGNGIDO()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 248f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void FHAMNJFOOGI()
	{
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
			FJCBEBLHJAD();
			return;
		}
		if (GLCDKKDBFEG % 7 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
			tweenColor.method = UITweener.Method.EaseInOut;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
			tweenColor2.method = UITweener.Method.Linear;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG++;
	}

	private void FGOGGLDAKHL()
	{
	}

	private void FIGOGIMJIIN()
	{
	}

	private void DHBOLMOPGJJ()
	{
	}

	private void AKCKJEEEKCD()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void DCKJHAILENK()
	{
	}

	private void LALLEJNLNBI()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void Awake()
	{
	}

	private void FICELEOKGNG()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 1821f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	public void JDCPOHCPPKM()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(CPMLMNBJGJJ));
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 0;
		base.enabled = true;
	}

	private void EGHPECGCCMA()
	{
	}

	private void MIGEMOBNPGJ()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 944f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void FIEKOBKAHKA()
	{
	}

	public static BlinkingObject NCPOKCLHEAK(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.ECBBPMCJLKH();
		return blinkingObject;
	}

	private void OnDisable()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 0f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void JBFCELENIDM()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void OIEAENOEMHJ()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 0;
		base.enabled = true;
	}

	private void NOOLAIEENFB()
	{
	}

	private void PCFGKPGEBMA(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			IPPCJNGOKPB();
			return;
		}
		if (GLCDKKDBFEG % 0 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenColor.method = UITweener.Method.EaseOut;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(HIBIDGPFHID));
			tweenColor2.method = UITweener.Method.EaseInOut;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG += 0;
	}

	public void NOGBIGDNLPN()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
		tweenColor.method = (UITweener.Method)6;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 0;
		base.enabled = false;
	}

	public void DGGGKALIKHO()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(KDGNBDFAGMF));
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 1;
		base.enabled = false;
	}

	private void IODPOHKAKNN()
	{
	}

	private void IGLIJEMACCA()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void DGJLIHKOHHC()
	{
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
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenColor.method = UITweener.Method.EaseInOut;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenColor2.method = UITweener.Method.EaseInOut;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG++;
	}

	public void Blink()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 0;
		base.enabled = true;
	}

	private void GFNAEAEDGAG()
	{
	}

	private void GALBMDDFHGI()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void PJBMKHBPPJM()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(LAPMHPBNIKI));
		tweenColor.method = UITweener.Method.EaseIn;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 1;
		base.enabled = false;
	}

	public void ECBBPMCJLKH()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(KDGNBDFAGMF));
		tweenColor.method = UITweener.Method.BounceOut;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 1;
		base.enabled = false;
	}

	private void NOGLOKJINKN()
	{
	}

	private void IIGDKGDLEHP()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 1885f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void DOBGDCLBCBM(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			GALBMDDFHGI();
			return;
		}
		if (GLCDKKDBFEG % 0 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
			tweenColor.method = UITweener.Method.BounceIn;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(OADJLADNMEC));
			tweenColor2.method = (UITweener.Method)6;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG += 0;
	}

	private void DAPFGNMPCOK()
	{
	}

	public static BlinkingObject LCBLJBAJGED(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = false;
		blinkingObject.NOGBIGDNLPN();
		return blinkingObject;
	}

	private void BAGCDJMLCPF()
	{
	}

	public static BlinkingObject IECHDKECJAB(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.JDCPOHCPPKM();
		return blinkingObject;
	}

	private void FELKGFLOBJF()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void BMFKGMADKNI()
	{
	}

	private void DKNGGOJKAFP()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void KLDMEDFBHLG()
	{
	}

	private void CALILPEEAMB()
	{
	}

	public static BlinkingObject CEOPFCICKAK(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.OIEAENOEMHJ();
		return blinkingObject;
	}

	private void EJNJCILPBEC()
	{
	}

	private void IPPCJNGOKPB()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public static BlinkingObject IOLBDLOPJGJ(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.MOICCKINNLI();
		return blinkingObject;
	}

	private void JCNCGJPJDAC()
	{
	}

	private void KFKHKNILMKF()
	{
	}

	public static BlinkingObject Begin(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.Blink();
		return blinkingObject;
	}

	private void LIBBGANJBAJ()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void AMDAKBLOKFN()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 548f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void CPMLMNBJGJJ(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			JBFCELENIDM();
			return;
		}
		if (GLCDKKDBFEG % 4 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(KDGNBDFAGMF));
			tweenColor.method = (UITweener.Method)6;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(CPMLMNBJGJJ));
			tweenColor2.method = UITweener.Method.BounceIn;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG++;
	}

	private void LAPMHPBNIKI(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			NINEIFDFJLC();
			return;
		}
		if (GLCDKKDBFEG % 8 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(DOBGDCLBCBM));
			tweenColor.method = UITweener.Method.EaseIn;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(CPMLMNBJGJJ));
			tweenColor2.method = UITweener.Method.EaseInOut;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG += 0;
	}

	private void NGOEBPKFAJG()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void OOOBLFENKLJ()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void HFIHPHDDPLI()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(HIBIDGPFHID));
		tweenColor.method = (UITweener.Method)6;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 1;
		base.enabled = true;
	}

	private void ABMKKECEGIB()
	{
	}

	public void MOICCKINNLI()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(DOBGDCLBCBM));
		tweenColor.method = (UITweener.Method)6;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 0;
		base.enabled = true;
	}

	public static BlinkingObject KAEBPEJBJCI(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.NOGBIGDNLPN();
		return blinkingObject;
	}

	private void AMEGFGJNKEB(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			IGLIJEMACCA();
			return;
		}
		if (GLCDKKDBFEG % 7 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(KDGNBDFAGMF));
			tweenColor.method = UITweener.Method.BounceIn;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(CPMLMNBJGJJ));
			tweenColor2.method = UITweener.Method.EaseIn;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG++;
	}

	public static BlinkingObject DHKJOACDBNK(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.Blink();
		return blinkingObject;
	}

	public static BlinkingObject AJJFGBOKPOL(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = false;
		blinkingObject.HFIHPHDDPLI();
		return blinkingObject;
	}

	public static BlinkingObject NFCEEJODFMO(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.ECBBPMCJLKH();
		return blinkingObject;
	}

	private void HBCHLOANIMJ()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 1425f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	public static BlinkingObject JCLGAFGBMDC(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = false;
		blinkingObject.DGGGKALIKHO();
		return blinkingObject;
	}

	private void LDKGNEKCEJH()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 1828f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = false;
		}
	}

	private void CPHIJFCCNPK()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 1121f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = true;
		}
	}

	private void OnEnable()
	{
	}

	private void EMCILLNEFJD()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void FJCBEBLHJAD()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public static BlinkingObject EAAKAAANAKD(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.HFIHPHDDPLI();
		return blinkingObject;
	}

	private void FBJDIHCFMPG()
	{
	}

	private void BOBKPFNCNDO()
	{
	}

	private void CLNMMABFGJN()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	private void IOAEHDJGBJC()
	{
	}

	private void KDGNBDFAGMF(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			NGOEBPKFAJG();
			return;
		}
		if (GLCDKKDBFEG % 2 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
			tweenColor.method = (UITweener.Method)8;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(LLIDFPGKFJC));
			tweenColor2.method = UITweener.Method.BounceOut;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG++;
	}

	private void HIBIDGPFHID(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			NINEIFDFJLC();
			return;
		}
		if (GLCDKKDBFEG % 0 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(KDGNBDFAGMF));
			tweenColor.method = UITweener.Method.EaseOut;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(PCFGKPGEBMA));
			tweenColor2.method = UITweener.Method.Linear;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG++;
	}

	private void NINEIFDFJLC()
	{
		if (IHDDMKGEFJH != null)
		{
			IHDDMKGEFJH(this);
		}
	}

	public void LOPMNKBPJJO()
	{
		TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
		MHJDEELDJHF = tweenColor.from;
		tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(IAECBLAOPDJ));
		tweenColor.method = UITweener.Method.BounceIn;
		tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		GLCDKKDBFEG = 1;
		base.enabled = true;
	}

	private void OJCPMGNGCLC()
	{
		TweenColor component = GetComponent<TweenColor>();
		if (component != null && MHJDEELDJHF.HasValue && LPGMOGPIEMJ)
		{
			TweenColor.Begin(base.gameObject, 586f, MHJDEELDJHF.Value);
			component.onFinished = null;
			component.enabled = true;
		}
	}

	public static BlinkingObject DFNHCFNJCMC(GameObject ENCEFOOPBMK, Color DEJCDFNBLJD, Color COLGEMOBPHC, int DIJGCEFGCBA, float JPNAINOGAMM)
	{
		BlinkingObject blinkingObject = ENCEFOOPBMK.GetComponent<BlinkingObject>() ?? ENCEFOOPBMK.AddComponent<BlinkingObject>();
		blinkingObject.NGEJEFMJPJE = DEJCDFNBLJD;
		blinkingObject.DIPLAGLLECJ = COLGEMOBPHC;
		blinkingObject.OHCFMMCDCPO = DIJGCEFGCBA;
		blinkingObject.CPACDJKLACH = JPNAINOGAMM;
		blinkingObject.enabled = true;
		blinkingObject.NOGBIGDNLPN();
		return blinkingObject;
	}

	private void GBGDKNIMGMB()
	{
	}

	private void HOCCEMOAENF()
	{
	}

	private void OADJLADNMEC(UITweener MGDJMGHCAAI)
	{
		if (!base.enabled)
		{
			return;
		}
		if (GLCDKKDBFEG == OHCFMMCDCPO)
		{
			MGDJMGHCAAI.onFinished = null;
			JBFCELENIDM();
			return;
		}
		if (GLCDKKDBFEG % 3 == 0)
		{
			TweenColor tweenColor = TweenColor.Begin(base.gameObject, CPACDJKLACH, NGEJEFMJPJE);
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(OADJLADNMEC));
			tweenColor.method = UITweener.Method.BounceOut;
			tweenColor.ignoreTimeScale = DLMKHPAJKDJ;
		}
		else
		{
			TweenColor tweenColor2 = TweenColor.Begin(base.gameObject, CPACDJKLACH, DIPLAGLLECJ);
			tweenColor2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor2.onFinished, new UITweener.OnFinished(AMEGFGJNKEB));
			tweenColor2.method = (UITweener.Method)6;
			tweenColor2.ignoreTimeScale = DLMKHPAJKDJ;
		}
		GLCDKKDBFEG += 0;
	}
}
