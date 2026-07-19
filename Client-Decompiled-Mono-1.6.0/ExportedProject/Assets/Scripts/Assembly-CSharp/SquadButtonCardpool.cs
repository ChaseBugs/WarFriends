using UnityEngine;

public class SquadButtonCardpool : SquadButton
{
	[Header("Cardpool Notification")]
	public GameObject IOEFCBCCOJM;

	public UILabel JBAAKANDCMM;

	public UIPanel POOGFPBBHNE;

	public UISprite GJIMEOLAAHJ;

	public BoxCollider ABGBIEMENCO;

	private bool MLNJPOJKKHB;

	protected float JOBAMADMOGF = 0.1f;

	public virtual TweenAlpha BBAJLLLEAID(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1620f);
		}
		return base.IGNHIAOMICH(PAPEDLBKBGM);
	}

	public virtual TweenAlpha FHJAHLLJMED(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1962f);
		}
		return base.HODJNFBKFHC(PAPEDLBKBGM);
	}

	public virtual void ADCAMKBEDLK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1393f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.FLKKHHCHHFO(PAPEDLBKBGM);
		}
	}

	public void DGGOGPJHCGA(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public void GJEEFKNLJFK(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public void LPBKHJIODEI(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			LFHDEEPHKPK(true);
		}
	}

	public virtual void GJEEMJNIFFM(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.CIPKPHAGJMP(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((AGDAOEIIDKH() + EDGHHKGCKGI) / 24f - 1945f, 376f, 32f);
	}

	public void DCOBJGDBFAK(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(false);
		}
	}

	public void EHPPOEPNODN(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			GEBGEODICAE(false);
		}
	}

	public void KLPHCLOFPNF(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			FILEBFGKKDA(false);
		}
	}

	public void ALCDMJCFKPO(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			PDLIGCJMOFA(true);
		}
	}

	public virtual void EOOOIGCCAKH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1987f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.KECAIJLLCOM(PAPEDLBKBGM);
		}
	}

	public override void InstantAnimate(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 0f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.InstantAnimate(PAPEDLBKBGM);
		}
	}

	public virtual void GBCFOFKPPJP(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.INMHFICPFAJ(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((GKGGDKDLGDA() + EDGHHKGCKGI) / 30f - 639f, 581f, 1090f);
	}

	public void SetNotifications(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public virtual void PMECKIKPLAG(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1862f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.DMMMEHACBCG(PAPEDLBKBGM);
		}
	}

	public void SetLocked(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(false);
		}
	}

	public virtual void FCNEJEOJGJN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1844f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.PDLIGCJMOFA(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha DPHNBJKFABE(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1897f);
		}
		return base.IGNHIAOMICH(PAPEDLBKBGM);
	}

	public void KCDCFKBAFAJ(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			CEHEOIPBKDF(true);
		}
	}

	public virtual TweenAlpha HOJCOFDOGOM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 855f);
		}
		return base.MMJKKOMHMMK(PAPEDLBKBGM);
	}

	public void IKDGDDMADEL(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(true);
		}
	}

	public virtual TweenAlpha INPMOKPODKG(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 37f);
		}
		return base.HNGLCCDCHGG(PAPEDLBKBGM);
	}

	public void NPAGOEEPJJJ(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(false);
		}
	}

	public void MNHKJHOHEFB(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public void PMPOCBPHBLD(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public virtual void NCCCEKKMCBC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 881f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.EJONAFHFLJN(PAPEDLBKBGM);
		}
	}

	public void DHFFAMBDKPN(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EDADMNKKOIA(false);
		}
	}

	public virtual TweenAlpha PFKNDAPDAMC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1986f);
		}
		return base.DANJCHNBGJF(PAPEDLBKBGM);
	}

	public override TweenAlpha HODJNFBKFHC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 616f);
		}
		return base.DANJCHNBGJF(PAPEDLBKBGM);
	}

	public virtual void HJFNDDKIKGK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1667f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.GEBGEODICAE(PAPEDLBKBGM);
		}
	}

	public virtual void KJLJEECPLDI(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1224f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.OPDHKOCBDHF(PAPEDLBKBGM);
		}
	}

	public void OGIANJJMBFA(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			IJJCCPEKACK(false);
		}
	}

	public virtual void GBLFAFJJANM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 580f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.PDLIGCJMOFA(PAPEDLBKBGM);
		}
	}

	public void OCEDECMPOPK(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public override TweenAlpha JLBALIEPGGC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1631f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public void OPLOHPBDLIH(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public virtual void LKEDBMDFGCH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 742f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.CPIPMFLKAPG(PAPEDLBKBGM);
		}
	}

	public virtual void HFEIDEKNAMB(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1581f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.InstantAnimate(PAPEDLBKBGM);
		}
	}

	public void CFHADMCKNHN(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			KIEMIFCHABD(true);
		}
	}

	public void OFOCOOGFCEH(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(true);
		}
	}

	public virtual void IDHMHMLFIEL(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 850f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.NOPKMLDHEGN(PAPEDLBKBGM);
		}
	}

	public void AAFCGCGFGJB(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NOPKMLDHEGN(false);
		}
	}

	public void JALLBJEAAHK(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			JCAFCBAMPOA(false);
		}
	}

	public void EFMMLAEENIE(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			DMMMEHACBCG(false);
		}
	}

	public override void Initialize(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.Initialize(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((KBLPGHGPLJC + EDGHHKGCKGI) / 2f - 10f, 44f, 0f);
	}

	public virtual TweenAlpha OGHIOCHEGGK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1825f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual TweenAlpha LFLGJGOKPND(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1617f);
		}
		return base.DANJCHNBGJF(PAPEDLBKBGM);
	}

	public void DOBEGMKANCL(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public virtual void KMKNAKNEMNN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1042f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.InstantAnimate(PAPEDLBKBGM);
		}
	}

	public void FAJKOHJMHOF(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public void DOEKCBCPMHB(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			CPIPMFLKAPG(false);
		}
	}

	public void FHMPPDEAKLF(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			DMMMEHACBCG(true);
		}
	}

	public void AECKBELMIII(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(true);
		}
	}

	public virtual void CFIAHPMMJOE(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.CIPKPHAGJMP(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((MGPKGBBBPFH() + EDGHHKGCKGI) / 224f - 215f, 1223f, 1282f);
	}

	public void BLHANNEHCHD(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			CPIPMFLKAPG(false);
		}
	}

	public override TweenAlpha MMJKKOMHMMK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 592f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual TweenAlpha FMOAHBALFGE(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1861f);
		}
		return base.CGNAGNAOEJA(PAPEDLBKBGM);
	}

	public void AGJKFECJFMP(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public virtual void NMCGGPENKAG(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1771f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.LFHDEEPHKPK(PAPEDLBKBGM);
		}
	}

	public void ILLFLOCOECI(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			BGIGLELNNED(true);
		}
	}

	public void LJCNNOACMGC(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			JCAFCBAMPOA(true);
		}
	}

	public override TweenAlpha LAHIJFMLODM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 414f);
		}
		return base.LAHIJFMLODM(PAPEDLBKBGM);
	}

	public override TweenAlpha Animate(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 0f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual void EPAHIKLPNNB(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.CKLPPPDCEHG(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((NFGNPJALBLK() + EDGHHKGCKGI) / 359f - 1375f, 1976f, 1566f);
	}

	public virtual void LOJPGLBLJDF(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.PEIPCPICOIK(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((GKGGDKDLGDA() + EDGHHKGCKGI) / 1814f - 843f, 1738f, 323f);
	}

	public void DHODFFMLFLP(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public virtual void FJCAKOJHLBJ(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 400f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.CPIPMFLKAPG(PAPEDLBKBGM);
		}
	}

	public void OIJIMLIMIJL(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			GEBGEODICAE(false);
		}
	}

	public virtual TweenAlpha HBGPCEDJMOC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 171f);
		}
		return base.IPNKGKNJOLO(PAPEDLBKBGM);
	}

	public void HFBJLOMDKDH(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			JCAFCBAMPOA(true);
		}
	}

	public void IKFGGKKEHLO(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			FHKFOIDADKD(false);
		}
	}

	public virtual void ADAGNFIBCDB(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 250f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.KIEMIFCHABD(PAPEDLBKBGM);
		}
	}

	public virtual void IGPOLIPPGBP(string MNPDLLFJOHM, float DNDHIFENDPJ, bool PAPEDLBKBGM = false)
	{
		base.CIPKPHAGJMP(MNPDLLFJOHM, DNDHIFENDPJ, PAPEDLBKBGM);
		IOEFCBCCOJM.transform.localPosition = new Vector3((PBOCPAPICCL() + EDGHHKGCKGI) / 1317f - 1412f, 790f, 199f);
	}

	public void JILDDEGPHLA(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			LNNFGHIHBCF(false);
		}
	}

	public virtual void CJLKOGBJHAL(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1615f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.PDLIGCJMOFA(PAPEDLBKBGM);
		}
	}

	public void IKFGFMMEOGA(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			KECAIJLLCOM(true);
		}
	}

	public void AHJKLKEILGM(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			FHKFOIDADKD(false);
		}
	}

	public void ILPFEIBOECB(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public override void EJONAFHFLJN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1531f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.BGIGLELNNED(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha PAKBMJBJDNI(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1915f);
		}
		return base.NGFOJMHEFKJ(PAPEDLBKBGM);
	}

	public void JPEAOLDHAGF(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public virtual TweenAlpha KPAOJEKAIDH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1345f);
		}
		return base.KIBNCDGOLJD(PAPEDLBKBGM);
	}

	public virtual void ALJNBOCAPEM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 367f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.OPDHKOCBDHF(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha EKOKMJJJMNI(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 606f);
		}
		return base.IGNHIAOMICH(PAPEDLBKBGM);
	}

	public void CLAGAGKCLKL(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 1);
	}

	public void KAHNOOPKPPH(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EDADMNKKOIA(true);
		}
	}

	public override void CPIPMFLKAPG(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 498f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == POOGFPBBHNE.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.InstantAnimate(PAPEDLBKBGM);
		}
	}

	public void IKGLOLJMBGL(int KHJBFBDODGM)
	{
		JBAAKANDCMM.text = MEJMLNDFDBP.GMIPFLIEOHD(KHJBFBDODGM);
		IOEFCBCCOJM.SetActive(KHJBFBDODGM > 0);
	}

	public void GAICOAHDJBF(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		GJIMEOLAAHJ.gameObject.SetActive(MLNJPOJKKHB);
		ABGBIEMENCO.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			FLKKHHCHHFO(false);
		}
	}
}
