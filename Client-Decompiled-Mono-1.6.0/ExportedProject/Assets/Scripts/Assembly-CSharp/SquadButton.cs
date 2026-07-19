using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadButton : Core_BaseScript
{
	[Header("Button Settings")]
	public UISprite MBMIOELEAND;

	public UISprite LCPBNBLGFIA;

	public UILabel KLMFIBIIALC;

	public UIButtonSetter AHECKDDDOOK;

	public float PDGCOBOCPBH;

	protected float IBECOAEMAHD = 0.2f;

	protected float JOIANPILHLA = 0.7f;

	protected float EDGHHKGCKGI = 76f;

	public bool pressed
	{
		get
		{
			return LCPBNBLGFIA.alpha > 0f;
		}
	}

	public float width
	{
		get
		{
			return MBMIOELEAND.transform.localScale.x;
		}
	}

	public float posX
	{
		get
		{
			return 47f + base.transform.localPosition.x;
		}
	}

	protected virtual float KBLPGHGPLJC
	{
		get
		{
			return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
		}
	}

	[SpecialName]
	public bool OPHBAFKHFMI()
	{
		return LCPBNBLGFIA.alpha > 649f;
	}

	public virtual void CKLPPPDCEHG(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.DKHLKOFJKPL(GKGGDKDLGDA() + EDGHHKGCKGI);
		}
		JCAFCBAMPOA(PAPEDLBKBGM);
	}

	[SpecialName]
	protected virtual float DNEBNBCFILD()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	protected virtual float GEONEPGNFBJ()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public bool CKPCPIIGBGL()
	{
		return LCPBNBLGFIA.alpha > 1505f;
	}

	[SpecialName]
	public float DJKLLDKHAEH()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual void JCAFCBAMPOA(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1720f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1394f : 149f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	public virtual TweenAlpha CEACEHMMBEI(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 433f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 571f : 333f);
	}

	[SpecialName]
	protected virtual float DNGHBHEIFEI()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public float MEKHIBFAPOF()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	protected virtual float FHLEOOPJLFM()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public float LECKFPLBLKG()
	{
		return 506f + base.transform.localPosition.x;
	}

	[SpecialName]
	public bool HOICIFAHBDA()
	{
		return LCPBNBLGFIA.alpha > 1961f;
	}

	[SpecialName]
	public float AOAMKOOINKG()
	{
		return 1285f + base.transform.localPosition.x;
	}

	public virtual TweenAlpha DANJCHNBGJF(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 277f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 344f : 595f);
	}

	[SpecialName]
	public bool PPICNBHNPIM()
	{
		return LCPBNBLGFIA.alpha > 864f;
	}

	public virtual TweenAlpha ANEFFNMMALL(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 388f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 33f : 461f);
	}

	[SpecialName]
	protected virtual float DDBHCEKLDKM()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual TweenAlpha MEMHLENAOMB(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1390f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1730f : 132f);
	}

	public virtual void DDJIMJHDAMI(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.FKBLIJOHBLD(GEONEPGNFBJ() + EDGHHKGCKGI);
		}
		BGIGLELNNED(PAPEDLBKBGM);
	}

	[SpecialName]
	protected virtual float NFGNPJALBLK()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	protected virtual float MHMLAMHIIFN()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	protected virtual float BENONKFKPFD()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public bool LHCHDNOLLKJ()
	{
		return LCPBNBLGFIA.alpha > 1821f;
	}

	public virtual TweenAlpha HNGLCCDCHGG(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1569f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1488f : 1639f);
	}

	public virtual void LFHDEEPHKPK(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1805f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 776f : 1493f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	[SpecialName]
	public float KLOJKPEHLFE()
	{
		return 147f + base.transform.localPosition.x;
	}

	[SpecialName]
	public float DMFHJGHHEFJ()
	{
		return 337f + base.transform.localPosition.x;
	}

	[SpecialName]
	public bool EANKLILFNML()
	{
		return LCPBNBLGFIA.alpha > 671f;
	}

	public virtual TweenAlpha IIHMBOEGCOH(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1388f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 538f : 1578f);
	}

	[SpecialName]
	public bool EBBGGIGMIPN()
	{
		return LCPBNBLGFIA.alpha > 331f;
	}

	[SpecialName]
	public float NLOEGHEPLHN()
	{
		return 1282f + base.transform.localPosition.x;
	}

	[SpecialName]
	protected virtual float PBOCPAPICCL()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void JFAFBPDPBJO(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1572f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 368f : 220f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	public virtual void CPIPMFLKAPG(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 343f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 552f : 860f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	[SpecialName]
	public float GECKNIPNMIM()
	{
		return 1007f + base.transform.localPosition.x;
	}

	[SpecialName]
	public float CHPFAOAFCIG()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float EGELFHNCBLM()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	protected virtual float LIFCCLCJFDB()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public float NPKCLEMAPDE()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual void PDHBFNDEKNN(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.EGNOJHEGNCC(CLLJBNCFGCD() + EDGHHKGCKGI);
		}
		IJJCCPEKACK(PAPEDLBKBGM);
	}

	public virtual void CEHEOIPBKDF(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1097f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 90f : 344f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	public virtual void Initialize(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.SetWidth(KBLPGHGPLJC + EDGHHKGCKGI);
		}
		InstantAnimate(PAPEDLBKBGM);
	}

	[SpecialName]
	public float DMBHNBLAPFM()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual void INMHFICPFAJ(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.FKBLIJOHBLD(MHMLAMHIIFN() + EDGHHKGCKGI);
		}
		CPIPMFLKAPG(PAPEDLBKBGM);
	}

	public virtual TweenAlpha NGFOJMHEFKJ(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 982f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 577f : 1133f);
	}

	[SpecialName]
	protected virtual float GKGGDKDLGDA()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void IJJCCPEKACK(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 292f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1055f : 498f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	[SpecialName]
	protected virtual float IHMKLLMAJAI()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public float LDGGHNKBECD()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public bool FNOEGAHKCPD()
	{
		return LCPBNBLGFIA.alpha > 136f;
	}

	public virtual void FLKKHHCHHFO(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 23f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1716f : 159f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	[SpecialName]
	public bool CHCGIPDLGNL()
	{
		return LCPBNBLGFIA.alpha > 1787f;
	}

	[SpecialName]
	protected virtual float ABLODEEDOKE()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void EDADMNKKOIA(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1903f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 215f : 1821f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	[SpecialName]
	public float GJKJECCBMLC()
	{
		return 611f + base.transform.localPosition.x;
	}

	public virtual TweenAlpha BOFICLOIGDJ(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1976f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 411f : 1698f);
	}

	[SpecialName]
	protected virtual float MGPKGBBBPFH()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	protected virtual float DBPCOLHBEDG()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void GEBGEODICAE(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1291f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1943f : 116f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	public virtual void AAEHFKHPPDF(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1437f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 328f : 699f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	public virtual TweenAlpha MMJKKOMHMMK(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1745f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 375f : 533f);
	}

	[SpecialName]
	public float IDDBBPPOOKF()
	{
		return 671f + base.transform.localPosition.x;
	}

	public virtual void LOJIKJPPBIO(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1423f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 789f : 386f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	public virtual void MKENDIKJPLJ(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.MGDCNGGBJLA(DBPCOLHBEDG() + EDGHHKGCKGI);
		}
		GEBGEODICAE(PAPEDLBKBGM);
	}

	public virtual void FILEBFGKKDA(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 947f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1898f : 1148f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	[SpecialName]
	public bool JMDNODAEKMO()
	{
		return LCPBNBLGFIA.alpha > 1261f;
	}

	public virtual void HHFELCAFANH(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.KMIFEKCEOPJ(AGDAOEIIDKH() + EDGHHKGCKGI);
		}
		GEBGEODICAE(PAPEDLBKBGM);
	}

	public virtual void InstantAnimate(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 0f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 0f : 1f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	public virtual TweenAlpha LAHIJFMLODM(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1141f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 403f : 1990f);
	}

	public virtual TweenAlpha CGNAGNAOEJA(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1920f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 984f : 1653f);
	}

	public virtual void KECAIJLLCOM(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 399f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1017f : 1524f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	[SpecialName]
	public float OIMILOHDCCG()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	protected virtual float DDIBJKHPOKB()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void DMMMEHACBCG(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 891f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 820f : 325f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	public virtual TweenAlpha IPNKGKNJOLO(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1436f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 470f : 1523f);
	}

	[SpecialName]
	public float ABHKKIJJBPO()
	{
		return 178f + base.transform.localPosition.x;
	}

	public virtual TweenAlpha HODJNFBKFHC(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1698f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1997f : 315f);
	}

	public virtual void OMCNLOHKCBJ(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.GPNONALLJKA(INIOMECPABI() + EDGHHKGCKGI);
		}
		IJJCCPEKACK(PAPEDLBKBGM);
	}

	public virtual void ONGAIEOAHMA(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.BHEBNFNJMJA(PCBIHOMAKHK() + EDGHHKGCKGI);
		}
		InstantAnimate(PAPEDLBKBGM);
	}

	[SpecialName]
	public float KNPPDOJFHGP()
	{
		return 1466f + base.transform.localPosition.x;
	}

	[SpecialName]
	public float MLNFNIOPKPM()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float FPKKEMAMAOI()
	{
		return 1225f + base.transform.localPosition.x;
	}

	public virtual void PEIPCPICOIK(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.DKHLKOFJKPL(JLBPMFHJMIK() + EDGHHKGCKGI);
		}
		EJONAFHFLJN(PAPEDLBKBGM);
	}

	public virtual void JIMBEDOMAFD(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.MGDCNGGBJLA(GEONEPGNFBJ() + EDGHHKGCKGI);
		}
		FLKKHHCHHFO(PAPEDLBKBGM);
	}

	public virtual void KIEMIFCHABD(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1454f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 642f : 1817f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	public virtual void CIPKPHAGJMP(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.EGNOJHEGNCC(GEONEPGNFBJ() + EDGHHKGCKGI);
		}
		EJONAFHFLJN(PAPEDLBKBGM);
	}

	public virtual void PDLIGCJMOFA(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1276f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 448f : 1150f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	public virtual TweenAlpha Animate(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 0f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 0f : 1f);
	}

	[SpecialName]
	protected virtual float JLBPMFHJMIK()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public float IIKAEPLABJH()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float MPBOCGHALPO()
	{
		return 1777f + base.transform.localPosition.x;
	}

	public virtual void GJOIGNMPBCH(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.SetWidth(DDIBJKHPOKB() + EDGHHKGCKGI);
		}
		JCAFCBAMPOA(PAPEDLBKBGM);
	}

	public virtual TweenAlpha HEBAICIOOOJ(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 777f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 239f : 196f);
	}

	[SpecialName]
	public float JPKHCPMFNCJ()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual TweenAlpha JLBALIEPGGC(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 646f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 377f : 1266f);
	}

	[SpecialName]
	public float CCDMGEJMOAD()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	public virtual void OPDHKOCBDHF(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 613f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1097f : 341f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	public virtual void EJONAFHFLJN(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1051f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 845f : 659f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	[SpecialName]
	protected virtual float INIOMECPABI()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public bool GBGMJPILIJG()
	{
		return LCPBNBLGFIA.alpha > 1502f;
	}

	public virtual TweenAlpha KIBNCDGOLJD(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 69f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1061f : 1240f);
	}

	public virtual void FHKFOIDADKD(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 546f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 840f : 484f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	[SpecialName]
	public bool EFINDCFNLEJ()
	{
		return LCPBNBLGFIA.alpha > 948f;
	}

	[SpecialName]
	protected virtual float AGDAOEIIDKH()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void BGIGLELNNED(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 121f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 1047f : 454f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	[SpecialName]
	protected virtual float CLLJBNCFGCD()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	[SpecialName]
	public float LPKPEKCNBHO()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public float OMLNDGOKPDH()
	{
		return MBMIOELEAND.transform.localScale.x;
	}

	[SpecialName]
	public bool BGINIAGFKPA()
	{
		return LCPBNBLGFIA.alpha > 1311f;
	}

	[SpecialName]
	protected virtual float PCBIHOMAKHK()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual void PNCJCHPOMOJ(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.EGNOJHEGNCC(ABLODEEDOKE() + EDGHHKGCKGI);
		}
		DMMMEHACBCG(PAPEDLBKBGM);
	}

	[SpecialName]
	protected virtual float BGMBAGKLLNM()
	{
		return Mathf.Max(PDGCOBOCPBH, KLMFIBIIALC.relativeSize.x * KLMFIBIIALC.transform.localScale.x);
	}

	public virtual TweenAlpha IGNHIAOMICH(bool PAPEDLBKBGM)
	{
		TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? JOIANPILHLA : 1291f);
		return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, (!PAPEDLBKBGM) ? 1793f : 75f);
	}

	public virtual void NOPKMLDHEGN(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1933f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 102f : 750f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.onFinished = null;
			uITweener.enabled = true;
		}
	}

	public virtual void FIDIINBHKDG(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		IBECOAEMAHD = DNDHIFENDPJ;
		KLMFIBIIALC.text = MNPDLLFJOHM;
		if (AHECKDDDOOK != null)
		{
			AHECKDDDOOK.KHBHCMBGJGJ(BGMBAGKLLNM() + EDGHHKGCKGI);
		}
		CEHEOIPBKDF(PAPEDLBKBGM);
	}

	public virtual void LNNFGHIHBCF(bool PAPEDLBKBGM)
	{
		MBMIOELEAND.alpha = ((!PAPEDLBKBGM) ? JOIANPILHLA : 1337f);
		LCPBNBLGFIA.alpha = ((!PAPEDLBKBGM) ? 798f : 805f);
		KLMFIBIIALC.color = ((!PAPEDLBKBGM) ? Color.grey : Colours.blue);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UITweener uITweener = componentsInChildren[i];
			uITweener.onFinished = null;
			uITweener.enabled = false;
		}
	}

	[SpecialName]
	public bool CJGBNHACIFC()
	{
		return LCPBNBLGFIA.alpha > 1755f;
	}
}
