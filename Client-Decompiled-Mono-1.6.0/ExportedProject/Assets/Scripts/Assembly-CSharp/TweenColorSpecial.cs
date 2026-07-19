using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("NGUI/Tween/Color Special")]
public class TweenColorSpecial : UITweener
{
	public Color OEIICEJPGKI = Color.white;

	public Color IIMDKHJAJGO = Color.white;

	private UIWidget LHJGNELEBCJ;

	private Material BJMEDCKHKGP;

	private Light FAKIEKAPDEP;

	public Color color
	{
		get
		{
			if (LHJGNELEBCJ != null)
			{
				return LHJGNELEBCJ.color;
			}
			if (FAKIEKAPDEP != null)
			{
				return FAKIEKAPDEP.color;
			}
			if (BJMEDCKHKGP != null)
			{
				return BJMEDCKHKGP.color;
			}
			return Color.black;
		}
		set
		{
			Color color = value.ReplaceA(this.color.a);
			if (LHJGNELEBCJ != null)
			{
				LHJGNELEBCJ.color = color;
			}
			if (BJMEDCKHKGP != null)
			{
				BJMEDCKHKGP.color = color;
			}
			if (FAKIEKAPDEP != null)
			{
				FAKIEKAPDEP.color = color;
				FAKIEKAPDEP.enabled = color.r + color.g + color.b > 0.01f;
			}
		}
	}

	private void HOINLOMCGFD()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor FHKFBIPHJCG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(262f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(710f);
		if (DNDHIFENDPJ <= 1304f)
		{
			tweenColor.Sample(1579f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color GLJIBGLEHEJ()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	public static TweenColor AIENDLBNHIJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1914f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1222f);
		if (DNDHIFENDPJ <= 77f)
		{
			tweenColor.Sample(369f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	private void OBPMHHGJFEL()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	[SpecialName]
	public void EGDEIDELJEJ(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(HFNDMMNEFJG().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 490f;
		}
	}

	[SpecialName]
	public Color OGKKFLEOCBP()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	private void OLBEOPKDEBJ()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	private void ECMMDCKONDK()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor IJIDNJACAMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(665f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1571f);
		if (DNDHIFENDPJ <= 919f)
		{
			tweenColor.Sample(199f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	[SpecialName]
	public void KINPOMBGKAP(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(LHBANFDAMIO().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 948f;
		}
	}

	private void BMLLLOBPGIB()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor JAFKKOIHIAA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(356f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(364f);
		if (DNDHIFENDPJ <= 929f)
		{
			tweenColor.Sample(512f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public void CCHMDOAMGLF(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(CGKKMJJFDAA().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 1856f;
		}
	}

	[SpecialName]
	public Color CIPAFHBGGMI()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	[SpecialName]
	public void ANJPBOAPEOO(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(APJCLFMLJLP().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 994f;
		}
	}

	[SpecialName]
	public Color FGJFDEKAHPF()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	[SpecialName]
	public void IMFOGBKNINF(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(CGKKMJJFDAA().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 746f;
		}
	}

	private void EIPLFPJNCIB()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	[SpecialName]
	public void HHJPKLDEKLB(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(LOJGDIALJLE().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 796f;
		}
	}

	private void NGGJHDCOLEC()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	protected virtual void EKPNJODKDOF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		HHJPKLDEKLB(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1f);
		if (DNDHIFENDPJ <= 0f)
		{
			tweenColor.Sample(1f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor NCPOKCLHEAK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(87f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(250f);
		if (DNDHIFENDPJ <= 1565f)
		{
			tweenColor.Sample(679f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor IHPAHOHIOPC(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1020f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1823f);
		if (DNDHIFENDPJ <= 740f)
		{
			tweenColor.Sample(1337f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor OLIIHGDGKKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1168f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1071f);
		if (DNDHIFENDPJ <= 1070f)
		{
			tweenColor.Sample(1976f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor CAOHCEAPHEN(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(407f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(719f);
		if (DNDHIFENDPJ <= 1384f)
		{
			tweenColor.Sample(1504f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public void MMGEEDPMOGB(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(OGKKFLEOCBP().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 892f;
		}
	}

	protected virtual void FLAFCDGMJCP(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		JNECDFCNCID(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor BCKPMDBAMFL(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1467f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(405f);
		if (DNDHIFENDPJ <= 1416f)
		{
			tweenColor.Sample(1707f, true);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	protected virtual void BPJJDKBIMHM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		KNIBLFNPLJI(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor PDFHNDPEEMA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(13f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(64f);
		if (DNDHIFENDPJ <= 309f)
		{
			tweenColor.Sample(1611f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	protected virtual void MLPFKOBCMMB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IPENNPBPAPG(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor Begin(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1f);
		if (DNDHIFENDPJ <= 0f)
		{
			tweenColor.Sample(1f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor FLGFKMHMDFP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1378f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1691f);
		if (DNDHIFENDPJ <= 791f)
		{
			tweenColor.Sample(1008f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	private void Awake()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	protected virtual void MIKACHBFCGF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IMFOGBKNINF(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public Color LOJGDIALJLE()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	public static TweenColor LEMANGJFIPE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1993f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(392f);
		if (DNDHIFENDPJ <= 1352f)
		{
			tweenColor.Sample(1398f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor KMDIDKBDCDM(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1288f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(344f);
		if (DNDHIFENDPJ <= 998f)
		{
			tweenColor.Sample(868f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor FOPAOKJDKJP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1550f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1084f);
		if (DNDHIFENDPJ <= 133f)
		{
			tweenColor.Sample(352f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor IECHDKECJAB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(860f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1936f);
		if (DNDHIFENDPJ <= 1057f)
		{
			tweenColor.Sample(638f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public void LBMAKEPKOHB(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(this.color.a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 1888f;
		}
	}

	public static TweenColor FFIHIGPINBB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1951f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(303f);
		if (DNDHIFENDPJ <= 368f)
		{
			tweenColor.Sample(138f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor FMGPCIGJIBP(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(208f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(432f);
		if (DNDHIFENDPJ <= 606f)
		{
			tweenColor.Sample(1113f, true);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	private void KNLKFOHBCKI()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor CABGNGMLIEK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(298f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(99f);
		if (DNDHIFENDPJ <= 249f)
		{
			tweenColor.Sample(624f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	[SpecialName]
	public void NENPMOKDCGK(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(HFABNGBOBLC().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 1937f;
		}
	}

	private void FJJAEHJDKNL()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	private void IOAEHDJGBJC()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	private void CPFDALHPFJI()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	[SpecialName]
	public Color CGKKMJJFDAA()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	protected virtual void NMHFGMNKLPG(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IPENNPBPAPG(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	protected override void OnUpdate(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		color = Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL);
	}

	public static TweenColor MDBMAINKPKG(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1902f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1544f);
		if (DNDHIFENDPJ <= 176f)
		{
			tweenColor.Sample(255f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	private void FGOGGLDAKHL()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	private void MEBEHLLPMPK()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	protected virtual void FHHGGBAMBGB(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		CCHMDOAMGLF(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	[SpecialName]
	public void IPENNPBPAPG(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(CGKKMJJFDAA().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 183f;
		}
	}

	private void MNAJGMAFJGL()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	[SpecialName]
	public void KNIBLFNPLJI(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(APJCLFMLJLP().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 1430f;
		}
	}

	protected virtual void FNHJHHIKKBM(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IPENNPBPAPG(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	private void PBCDDNOCJOI()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor PAJHHBLHAEI(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1793f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(995f);
		if (DNDHIFENDPJ <= 1704f)
		{
			tweenColor.Sample(9f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color MOCKNFMHFMF()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	public static TweenColor AHFIPGHPDHH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1903f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1056f);
		if (DNDHIFENDPJ <= 744f)
		{
			tweenColor.Sample(266f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color HFNDMMNEFJG()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	protected virtual void CDOIOHAAPAC(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		MMGEEDPMOGB(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor HMAJBKEOBMJ(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1248f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(354f);
		if (DNDHIFENDPJ <= 77f)
		{
			tweenColor.Sample(1322f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color IFCFMLAJOPK()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	protected virtual void NLHDACKEPGA(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		MBIHGNCLBOL(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor AFHNENMGEMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(425f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1903f);
		if (DNDHIFENDPJ <= 1265f)
		{
			tweenColor.Sample(1865f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor LBGHBCPDKAO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(959f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1488f);
		if (DNDHIFENDPJ <= 1407f)
		{
			tweenColor.Sample(539f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public void JNECDFCNCID(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(HFNDMMNEFJG().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 264f;
		}
	}

	protected virtual void IFLMKBDLENF(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		IPENNPBPAPG(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	private void CJOLAJGALCD()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	[SpecialName]
	public Color LHBANFDAMIO()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	public static TweenColor DBPOCEIDEAE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1951f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1942f);
		if (DNDHIFENDPJ <= 1913f)
		{
			tweenColor.Sample(1674f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color APJCLFMLJLP()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	public static TweenColor KKIGNHJHLGD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1999f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(660f);
		if (DNDHIFENDPJ <= 170f)
		{
			tweenColor.Sample(1585f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color MHMNJMDEFDB()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	protected virtual void EFBLGIHDKCL(float KDJCCDGMEJL, bool DEHAOIKPFFA)
	{
		MIPBAOKCGBF(Color.Lerp(OEIICEJPGKI, IIMDKHJAJGO, KDJCCDGMEJL));
	}

	public static TweenColor JPJPAJEBNPK(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1772f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(1468f);
		if (DNDHIFENDPJ <= 663f)
		{
			tweenColor.Sample(14f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	private void PBIJLBHDFOK()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	[SpecialName]
	public void MIPBAOKCGBF(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(CIPAFHBGGMI().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 243f;
		}
	}

	[SpecialName]
	public Color BJAAOENGFOG()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	private void LBMFKIDPCBL()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	private void FIEKOBKAHKA()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor ONCDIOBFHME(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(431f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(673f);
		if (DNDHIFENDPJ <= 280f)
		{
			tweenColor.Sample(993f, true);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor AGHGKJFDAOA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1593f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(312f);
		if (DNDHIFENDPJ <= 1297f)
		{
			tweenColor.Sample(1513f, true);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor JKFEDBCGIKH(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color OEIICEJPGKI, Color IIMDKHJAJGO)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = OEIICEJPGKI.ReplaceA(1467f);
		tweenColor.to = IIMDKHJAJGO.ReplaceA(224f);
		if (DNDHIFENDPJ <= 1060f)
		{
			tweenColor.Sample(557f, true);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor GMLNHEIJHDE(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1387f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1430f);
		if (DNDHIFENDPJ <= 370f)
		{
			tweenColor.Sample(222f, false);
			tweenColor.enabled = true;
		}
		return tweenColor;
	}

	public static TweenColor NFCEEJODFMO(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1036f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(783f);
		if (DNDHIFENDPJ <= 1175f)
		{
			tweenColor.Sample(939f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color HFABNGBOBLC()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	public static TweenColor EAAKAAANAKD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1369f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(852f);
		if (DNDHIFENDPJ <= 1778f)
		{
			tweenColor.Sample(1526f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	public static TweenColor JPOJDFCHEGB(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1006f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1274f);
		if (DNDHIFENDPJ <= 870f)
		{
			tweenColor.Sample(1248f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	[SpecialName]
	public Color AGFKLFFOAOJ()
	{
		if (LHJGNELEBCJ != null)
		{
			return LHJGNELEBCJ.color;
		}
		if (FAKIEKAPDEP != null)
		{
			return FAKIEKAPDEP.color;
		}
		if (BJMEDCKHKGP != null)
		{
			return BJMEDCKHKGP.color;
		}
		return Color.black;
	}

	[SpecialName]
	public void MBIHGNCLBOL(Color IDEBKDPMPGM)
	{
		Color color = IDEBKDPMPGM.ReplaceA(GLJIBGLEHEJ().a);
		if (LHJGNELEBCJ != null)
		{
			LHJGNELEBCJ.color = color;
		}
		if (BJMEDCKHKGP != null)
		{
			BJMEDCKHKGP.color = color;
		}
		if (FAKIEKAPDEP != null)
		{
			FAKIEKAPDEP.color = color;
			FAKIEKAPDEP.enabled = color.r + color.g + color.b > 721f;
		}
	}

	public static TweenColor EHLGFPMLLOD(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(1893f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1111f);
		if (DNDHIFENDPJ <= 1964f)
		{
			tweenColor.Sample(1802f, false);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}

	private void IOKMAFLIJEG()
	{
		LHJGNELEBCJ = GetComponentInChildren<UIWidget>();
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			BJMEDCKHKGP = component.material;
		}
		FAKIEKAPDEP = GetComponent<Light>();
	}

	public static TweenColor LMNBPJEACEA(GameObject KHAHPAKDIKE, float DNDHIFENDPJ, Color FDGBJAMNIEM)
	{
		TweenColor tweenColor = UITweener.Begin<TweenColor>(KHAHPAKDIKE, DNDHIFENDPJ);
		tweenColor.from = tweenColor.color.ReplaceA(562f);
		tweenColor.to = FDGBJAMNIEM.ReplaceA(1097f);
		if (DNDHIFENDPJ <= 896f)
		{
			tweenColor.Sample(565f, true);
			tweenColor.enabled = false;
		}
		return tweenColor;
	}
}
