using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class InappButton : MonoBehaviour
{
	[FormerlySerializedAs("ONIHPKHLGNH")]
	[Header("Button Core")]
	public UISprite MBMIOELEAND;

	[FormerlySerializedAs("FIDILIADIEL")]
	public UISprite LCPBNBLGFIA;

	[FormerlySerializedAs("GEJJLILPJEP")]
	public UILabel KLMFIBIIALC;

	[FormerlySerializedAs("MAPMGKJCMGN")]
	public UIButtonSetter AHECKDDDOOK;

	[FormerlySerializedAs("NBMKICNMHIK")]
	public float AIMLECAMBBH;

	private bool CAOABBOEIGI;

	protected float IBECOAEMAHD = 0.2f;

	private float JOIANPILHLA = 0.7f;

	private float EDGHHKGCKGI = 60f;

	public bool pressed => LCPBNBLGFIA.alpha > 0f;

	public float width => MBMIOELEAND.transform.localScale.x;

	public float posX => 47f + base.transform.localPosition.x;

	protected virtual float KBLPGHGPLJC => Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);

	public void NKPEHAGGGJP()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1921f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 241f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1826f).onFinished = OAGMLNFOBHL;
	}

	public virtual void LEOHGKOFBGM(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1149f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 334f : 212f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	public virtual void PMKIBHEBGNI(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1318f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 878f : 1794f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public float JNJCBCPABLJ()
	{
		return 1355f + base.transform.localPosition.x;
	}

	[SpecialName]
	public float COKNEKMGIKA()
	{
		return 633f + base.transform.localPosition.x;
	}

	private void GJINPPJHJAD(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = true;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	public void ENCCFDDDJFF(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.DKHLKOFJKPL(DNEBNBCFILD() + EDGHHKGCKGI);
		}
		BKHMEINKACE(PAPEDLBKBGM);
	}

	[SpecialName]
	public bool BJLCJBHIGCA()
	{
		return LCPBNBLGFIA.alpha > 332f;
	}

	[SpecialName]
	public float HJBFFHPBFAI()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public void NDOBDNHIDGD()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1361f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 716f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1330f).onFinished = OAGMLNFOBHL;
	}

	private void DJMIJFBFBON(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	public void BKGFDGNJFMI()
	{
		CAOABBOEIGI = false;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 188f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 477f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1567f).onFinished = FNCHMEOIPMG;
	}

	[SpecialName]
	public float CEHHCPKAAOE()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float AICPKPNHIEP()
	{
		return 1034f + base.transform.localPosition.x;
	}

	public void KIEIHNEBJHH()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 112f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 850f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 20f).onFinished = FNCHMEOIPMG;
	}

	[SpecialName]
	public bool LELLAJFCHJE()
	{
		return LCPBNBLGFIA.alpha > 781f;
	}

	public void EFMKLOOBNJI()
	{
		CAOABBOEIGI = false;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 362f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 377f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 640f).onFinished = FHDJKPPDIMM;
	}

	[SpecialName]
	public float LAJLLNLPFEH()
	{
		return 1597f + base.transform.localPosition.x;
	}

	[SpecialName]
	public float DBBPMBLDMDI()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual TweenAlpha CFJICMDLGFB(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 987f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1599f : 1666f);
	}

	[SpecialName]
	protected virtual float OKFBEBPLBFH()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public void MLLKACEGPCM(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.GPNONALLJKA(AOPBBEAMANO() + EDGHHKGCKGI);
		}
		PDGEFPJAIJD(PAPEDLBKBGM);
	}

	public virtual void MKKCFFFONLP(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1125f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1315f : 1665f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public bool FGOIHLALIFE()
	{
		return LCPBNBLGFIA.alpha > 1466f;
	}

	[SpecialName]
	public bool DNGECNHEBBO()
	{
		return LCPBNBLGFIA.alpha > 103f;
	}

	public virtual void NHHCHPIIPEK(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1985f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 648f : 900f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = true;
			}
		}
	}

	[SpecialName]
	public bool EBBGGIGMIPN()
	{
		return LCPBNBLGFIA.alpha > 481f;
	}

	public void AHANBOGLGBC()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1216f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 1081f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1423f).onFinished = FNCHMEOIPMG;
	}

	public virtual void NCCCEKKMCBC(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1911f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 272f : 150f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public bool APJAILGMMBC()
	{
		return LCPBNBLGFIA.alpha > 1462f;
	}

	public void OMCNLOHKCBJ(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.GFEJEOKDACB(CACBJPKEPFP() + EDGHHKGCKGI);
		}
		KLMIICIJFIN(PAPEDLBKBGM);
	}

	private void FNCHMEOIPMG(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = false;
	}

	[CompilerGenerated]
	private void HDCAAIMINJO(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	public virtual TweenAlpha NELBGFJHPJA(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 485f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 326f : 1716f);
	}

	[SpecialName]
	public bool NOLICNPIEOB()
	{
		return LCPBNBLGFIA.alpha > 1589f;
	}

	[SpecialName]
	public float HBCGDIPFLGB()
	{
		return 141f + base.transform.localPosition.x;
	}

	[SpecialName]
	protected virtual float CACBJPKEPFP()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void GLJEOPPPJFO(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 622f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1280f : 1363f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				uITweener.onFinished = null;
				uITweener.enabled = true;
			}
		}
	}

	private void NIHDDMGODLM(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = false;
	}

	[SpecialName]
	public float HGBEBKGHEBP()
	{
		return 1077f + base.transform.localPosition.x;
	}

	private void FHDJKPPDIMM(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = true;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = false;
	}

	[SpecialName]
	protected virtual float OMPPDLIIFIB()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	protected virtual float HKLLGHKCHEO()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	private void OINLJJHOLOE(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	public virtual void DMMFJFFKFAO(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1932f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1044f : 724f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	private void JDKNDIMKNPJ(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = true;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	[SpecialName]
	public bool BGINIAGFKPA()
	{
		return LCPBNBLGFIA.alpha > 1023f;
	}

	[SpecialName]
	public bool ABADHJNNPGA()
	{
		return LCPBNBLGFIA.alpha > 1698f;
	}

	[SpecialName]
	public float MEKHIBFAPOF()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public bool EFINDCFNLEJ()
	{
		return LCPBNBLGFIA.alpha > 224f;
	}

	public virtual void BOGICNNLLAP(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 309f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1401f : 1139f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = true;
			}
		}
	}

	public virtual void GBMIIHOJKIK(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1535f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1274f : 283f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public bool IGBBLJJCELG()
	{
		return LCPBNBLGFIA.alpha > 265f;
	}

	[SpecialName]
	public float FMMJFGINNPG()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public void MFFEFILOKMG(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.KHBHCMBGJGJ(AOPBBEAMANO() + EDGHHKGCKGI);
		}
		EOOOIGCCAKH(PAPEDLBKBGM);
	}

	[SpecialName]
	public float MENLNAFHEBH()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public void KFDEOJPIFAK()
	{
		CAOABBOEIGI = false;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 631f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 1074f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1125f).onFinished = delegate
		{
			CAOABBOEIGI = false;
			base.gameObject.SetActive(value: false);
			GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
		};
	}

	public void GFMFEAALCHM()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1963f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 611f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 162f).onFinished = DJMIJFBFBON;
	}

	[SpecialName]
	public float KCICBANCEAK()
	{
		return 646f + base.transform.localPosition.x;
	}

	[SpecialName]
	public float CHEDINADJBE()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public bool FIFNEHGBAGN()
	{
		return LCPBNBLGFIA.alpha > 1300f;
	}

	[SpecialName]
	protected virtual float AOPBBEAMANO()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	private void CFAECJHLLAO(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = true;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = false;
	}

	[SpecialName]
	public bool GBOBIEBNHPA()
	{
		return LCPBNBLGFIA.alpha > 729f;
	}

	[SpecialName]
	public float BJOILEBIBHC()
	{
		return 160f + base.transform.localPosition.x;
	}

	public void Initialize(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.SetWidth(KBLPGHGPLJC + EDGHHKGCKGI);
		}
		InstantAnimate(PAPEDLBKBGM);
	}

	public virtual TweenAlpha BEFKAOJIJGL(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 388f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1066f : 19f);
	}

	public void GPPKKKJKKAP()
	{
		CAOABBOEIGI = false;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1463f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 589f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 769f).onFinished = delegate
		{
			CAOABBOEIGI = false;
			base.gameObject.SetActive(value: false);
			GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
		};
	}

	[SpecialName]
	protected virtual float PCBIHOMAKHK()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	protected virtual float KFIFKNCKCLI()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void InstantAnimate(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 0f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 0f : 1f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public float IALJHDHFAFK()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float OOMCKECNJAI()
	{
		return 1406f + base.transform.localPosition.x;
	}

	public void AnimatedHide()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 0f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 0f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 0f).onFinished = delegate
		{
			CAOABBOEIGI = false;
			base.gameObject.SetActive(value: false);
			GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
		};
	}

	public virtual void EOOOIGCCAKH(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1259f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1662f : 715f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	public void IPPACMGHKOB()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1172f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 1378f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1112f).onFinished = OAGMLNFOBHL;
	}

	private void JCGCCLFBDEB(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = true;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = false;
	}

	public virtual void JCAFCBAMPOA(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 984f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 28f : 904f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	public void MCONFEEMOLE(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.KMIFEKCEOPJ(HKLLGHKCHEO() + EDGHHKGCKGI);
		}
		NCCCEKKMCBC(PAPEDLBKBGM);
	}

	public void NBOODHLLBAA(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.KMIFEKCEOPJ(DNEBNBCFILD() + EDGHHKGCKGI);
		}
		GBMIIHOJKIK(PAPEDLBKBGM);
	}

	public void KNBHLBPPJAM()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 110f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 76f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 478f).onFinished = EMGEBBKBMLH;
	}

	[SpecialName]
	public bool CECCHHILGKB()
	{
		return LCPBNBLGFIA.alpha > 304f;
	}

	public void KFJJPGNGOCK(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.GFEJEOKDACB(DNEBNBCFILD() + EDGHHKGCKGI);
		}
		IDHMHMLFIEL(PAPEDLBKBGM);
	}

	public virtual TweenAlpha Animate(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 0f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 0f : 1f);
	}

	[SpecialName]
	public bool IPOHDONDBII()
	{
		return LCPBNBLGFIA.alpha > 1651f;
	}

	private void EMGEBBKBMLH(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	public void PPLIBOAJOCA(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = true;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.FKBLIJOHBLD(AOPBBEAMANO() + EDGHHKGCKGI);
		}
		BOGICNNLLAP(PAPEDLBKBGM);
	}

	[SpecialName]
	public float PJLPNOJDFDC()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual void EHDIJGNGJIM(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1236f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 950f : 1f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = true;
			}
		}
	}

	[SpecialName]
	public float ANMMILJCHLH()
	{
		return 463f + base.transform.localPosition.x;
	}

	private void OAGMLNFOBHL(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: true);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = false;
	}

	public virtual void BKHMEINKACE(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1459f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 798f : 243f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public bool OMKCKHKGHAB()
	{
		return LCPBNBLGFIA.alpha > 690f;
	}

	public virtual void KLMIICIJFIN(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1773f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 795f : 1432f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = true;
			}
		}
	}

	[SpecialName]
	public bool NFIOJHJEFCH()
	{
		return LCPBNBLGFIA.alpha > 1579f;
	}

	public virtual TweenAlpha JINGNPBEKJK(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1426f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 794f : 1171f);
	}

	[SpecialName]
	public bool NDBDDIJHBGJ()
	{
		return LCPBNBLGFIA.alpha > 1522f;
	}

	public virtual void IDHMHMLFIEL(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 274f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1306f : 642f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = true;
			}
		}
	}

	public virtual TweenAlpha JBFAGOHHPOM(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 232f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1771f : 529f);
	}

	public virtual void PDGEFPJAIJD(bool PAPEDLBKBGM)
	{
		if (!CAOABBOEIGI)
		{
			MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1347f);
			LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1703f : 103f);
			KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				uITweener.onFinished = null;
				uITweener.enabled = false;
			}
		}
	}

	[SpecialName]
	public float GKEGNCJHEOA()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public void PJICLEMEBID(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		CAOABBOEIGI = false;
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.KMIFEKCEOPJ(DNEBNBCFILD() + EDGHHKGCKGI);
		}
		EOOOIGCCAKH(PAPEDLBKBGM);
	}

	public virtual TweenAlpha CGNAGNAOEJA(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1101f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1988f : 591f);
	}

	public void FBABNAANDBA()
	{
		CAOABBOEIGI = true;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 1133f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 759f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 221f).onFinished = DJMIJFBFBON;
	}

	private void HFCADMGMHGI(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = true;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}

	[SpecialName]
	public float EIFGOABKDPE()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float EJIKJBKEBKO()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual TweenAlpha FLDCGMHOOGP(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1987f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 776f : 434f);
	}

	public void NFJECDIADAK()
	{
		CAOABBOEIGI = false;
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, 324f);
		TweenAlpha.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, 719f);
		TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 824f).onFinished = EMGEBBKBMLH;
	}

	public virtual TweenAlpha PNMKDDOLLMK(bool PAPEDLBKBGM)
	{
		if (CAOABBOEIGI)
		{
			return null;
		}
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1166f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 201f : 413f);
	}

	[SpecialName]
	protected virtual float DNEBNBCFILD()
	{
		return Mathf.Max(AIMLECAMBBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	private void JMIAHGLJHOG(UITweener MGDJMGHCAAI)
	{
		CAOABBOEIGI = false;
		base.gameObject.SetActive(value: false);
		GuiElementSingle<InappScreen>.instance.FFNMEOGHNPL.repositionNow = true;
	}
}
