using UnityEngine;

public class InappButtonSpecial : InappButton
{
	[Header("Locked")]
	public UIPanel PDPMBDAJJIO;

	public UISprite PEIHJLNLKPL;

	public BoxCollider PMAOBDMEKFD;

	private bool MLNJPOJKKHB;

	private float JOBAMADMOGF = 0.1f;

	public virtual void LOJIKJPPBIO(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1901f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.PDGEFPJAIJD(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha DCFMKJPEADF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 558f);
		}
		return base.PNMKDDOLLMK(PAPEDLBKBGM);
	}

	public virtual TweenAlpha FANOOIFPJCL(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1113f);
		}
		return base.NELBGFJHPJA(PAPEDLBKBGM);
	}

	public void DOCHNKPFLME(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(false);
		}
	}

	public virtual TweenAlpha OHBCMKBPALL(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 269f);
		}
		return base.BEFKAOJIJGL(PAPEDLBKBGM);
	}

	public virtual void KIEMIFCHABD(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1162f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.PMKIBHEBGNI(PAPEDLBKBGM);
		}
	}

	public void SetLocked(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			InstantAnimate(false);
		}
	}

	public void ENIJDFKEPFB(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EHDIJGNGJIM(false);
		}
	}

	public virtual void PFOPHBDHFHP(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1774f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.GBMIIHOJKIK(PAPEDLBKBGM);
		}
	}

	public void FEDKHKFHIIG(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			GBMIIHOJKIK(true);
		}
	}

	public virtual TweenAlpha KIMGICDHGMO(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 312f);
		}
		return base.PNMKDDOLLMK(PAPEDLBKBGM);
	}

	public void NPAGOEEPJJJ(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NHHCHPIIPEK(false);
		}
	}

	public virtual void HJFNDDKIKGK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1594f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.GLJEOPPPJFO(PAPEDLBKBGM);
		}
	}

	public void PDJJLHJBHDE(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NCCCEKKMCBC(false);
		}
	}

	public virtual void FKMGIHKCFDM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 939f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.NCCCEKKMCBC(PAPEDLBKBGM);
		}
	}

	public void ILAHFGHBLED(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			MKKCFFFONLP(true);
		}
	}

	public void HPKMIGPBMFA(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EHDIJGNGJIM(true);
		}
	}

	public virtual void GKGCMGGGAKB(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1290f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.NHHCHPIIPEK(PAPEDLBKBGM);
		}
	}

	public virtual void NFHIKFMOOJD(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1107f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.GLJEOPPPJFO(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha LINAOJHOFDN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1176f);
		}
		return base.JBFAGOHHPOM(PAPEDLBKBGM);
	}

	public virtual TweenAlpha FMOAHBALFGE(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 144f);
		}
		return base.CGNAGNAOEJA(PAPEDLBKBGM);
	}

	public virtual void PFBCGFCCENN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1939f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.EHDIJGNGJIM(PAPEDLBKBGM);
		}
	}

	public virtual void IIJPMGLDOCI(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 491f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.GBMIIHOJKIK(PAPEDLBKBGM);
		}
	}

	public virtual void FAKDNGOFHLP(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 812f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.IDHMHMLFIEL(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha EAIHHHMDLBM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 326f);
		}
		return base.CFJICMDLGFB(PAPEDLBKBGM);
	}

	public virtual TweenAlpha FHJAHLLJMED(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1598f);
		}
		return base.JINGNPBEKJK(PAPEDLBKBGM);
	}

	public virtual void HCONFOBAOPB(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 533f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.PDGEFPJAIJD(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha PLKHAONLAIE(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1530f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual TweenAlpha POFFDPGKKII(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1309f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public void LKENELMICOA(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			GBMIIHOJKIK(false);
		}
	}

	public virtual TweenAlpha OGHIOCHEGGK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1220f);
		}
		return base.FLDCGMHOOGP(PAPEDLBKBGM);
	}

	public virtual void EJONAFHFLJN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 510f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.NHHCHPIIPEK(PAPEDLBKBGM);
		}
	}

	public virtual void PPDPLPBAIAK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1826f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.KLMIICIJFIN(PAPEDLBKBGM);
		}
	}

	public void DDPCICBIFKB(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			PMKIBHEBGNI(false);
		}
	}

	public void INIFBPILPCG(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NCCCEKKMCBC(true);
		}
	}

	public virtual TweenAlpha IHIPFIKFBEI(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 857f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual TweenAlpha KNFDPFIPHKF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 527f);
		}
		return base.CFJICMDLGFB(PAPEDLBKBGM);
	}

	public void FOCNACLONBB(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EOOOIGCCAKH(true);
		}
	}

	public virtual void LNNFGHIHBCF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 721f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.BOGICNNLLAP(PAPEDLBKBGM);
		}
	}

	public override TweenAlpha NELBGFJHPJA(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1206f);
		}
		return base.BEFKAOJIJGL(PAPEDLBKBGM);
	}

	public virtual TweenAlpha HIEEEHMPOLP(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1673f);
		}
		return base.JBFAGOHHPOM(PAPEDLBKBGM);
	}

	public void JMAIFLDGFEF(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NCCCEKKMCBC(true);
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
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
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

	public virtual TweenAlpha PDBGNFKGFJO(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1089f);
		}
		return base.CGNAGNAOEJA(PAPEDLBKBGM);
	}

	public void HFBJLOMDKDH(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NCCCEKKMCBC(true);
		}
	}

	public void NPEJIBNMNIE(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EHDIJGNGJIM(true);
		}
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

	public virtual void CEHEOIPBKDF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 198f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.BOGICNNLLAP(PAPEDLBKBGM);
		}
	}

	public void KONLDDDPFHB(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			IDHMHMLFIEL(false);
		}
	}

	public virtual TweenAlpha DNEPEIOCILB(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1204f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual TweenAlpha KPAOJEKAIDH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1447f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public void EMPMKMDJFBN(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			BOGICNNLLAP(false);
		}
	}

	public virtual TweenAlpha BKCIPFFABPH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 943f);
		}
		return base.JINGNPBEKJK(PAPEDLBKBGM);
	}

	public virtual void KKAAEDNCIGE(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 903f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.NHHCHPIIPEK(PAPEDLBKBGM);
		}
	}

	public void LHGEJMHJDLI(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			IDHMHMLFIEL(true);
		}
	}

	public void GPCLEBJLHMC(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			PMKIBHEBGNI(true);
		}
	}

	public override void MKKCFFFONLP(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 842f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.BOGICNNLLAP(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha GAFJFOKHAOB(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1361f);
		}
		return base.NELBGFJHPJA(PAPEDLBKBGM);
	}

	public void DHFFAMBDKPN(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			JCAFCBAMPOA(false);
		}
	}

	public virtual void GMPMKCEFIMN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1279f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.LEOHGKOFBGM(PAPEDLBKBGM);
		}
	}

	public virtual void DFJBACKFDFC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1954f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.InstantAnimate(PAPEDLBKBGM);
		}
	}

	public virtual void AKEKMBHJFCE(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1328f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.NCCCEKKMCBC(PAPEDLBKBGM);
		}
	}

	public virtual void JBCJJHGKADG(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1469f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.LEOHGKOFBGM(PAPEDLBKBGM);
		}
	}

	public virtual void IJJCCPEKACK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1526f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.BKHMEINKACE(PAPEDLBKBGM);
		}
	}

	public virtual void LKEDBMDFGCH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1156f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.PMKIBHEBGNI(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha HEBAICIOOOJ(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1397f);
		}
		return base.JINGNPBEKJK(PAPEDLBKBGM);
	}

	public virtual void MNHCGMIIILC(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 303f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.KLMIICIJFIN(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha AKMPMBKGBEA(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1995f);
		}
		return base.Animate(PAPEDLBKBGM);
	}

	public virtual void DHJBPGEPHNH(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1033f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.LEOHGKOFBGM(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha DGADPGOCFJF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 567f);
		}
		return base.CFJICMDLGFB(PAPEDLBKBGM);
	}

	public virtual void GNAEBEDPIGF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1363f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.PDGEFPJAIJD(PAPEDLBKBGM);
		}
	}

	public void HNEKNPBHAAC(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			BKHMEINKACE(false);
		}
	}

	public void GFHAAEBHMEF(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			MKKCFFFONLP(true);
		}
	}

	public virtual void EJNHCIJDACO(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1790f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.BKHMEINKACE(PAPEDLBKBGM);
		}
	}

	public virtual TweenAlpha JIPNELFJIDA(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 425f);
		}
		return base.JBFAGOHHPOM(PAPEDLBKBGM);
	}

	public void BGKPMFDNGDP(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			KLMIICIJFIN(false);
		}
	}

	public virtual TweenAlpha EAPOJEOILIN(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1038f);
		}
		return base.CGNAGNAOEJA(PAPEDLBKBGM);
	}

	public void CEMLEABHEAM(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			PDGEFPJAIJD(true);
		}
	}

	public void LKKPKBHIIEO(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			EOOOIGCCAKH(true);
		}
	}

	public virtual TweenAlpha GLDLDACFEIM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 823f);
		}
		return base.PNMKDDOLLMK(PAPEDLBKBGM);
	}

	public void PCCELPPJAMG(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NCCCEKKMCBC(false);
		}
	}

	public virtual TweenAlpha IPNKGKNJOLO(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 253f);
		}
		return base.JINGNPBEKJK(PAPEDLBKBGM);
	}

	public virtual TweenAlpha ANEFFNMMALL(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 600f);
		}
		return base.PNMKDDOLLMK(PAPEDLBKBGM);
	}

	public override void JCAFCBAMPOA(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1945f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.PDGEFPJAIJD(PAPEDLBKBGM);
		}
	}

	public override TweenAlpha CGNAGNAOEJA(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1553f);
		}
		return base.PNMKDDOLLMK(PAPEDLBKBGM);
	}

	public virtual void JBAIIANMNML(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1503f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.JCAFCBAMPOA(PAPEDLBKBGM);
		}
	}

	public void AOOPEGOPOGN(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			DMMFJFFKFAO(false);
		}
	}

	public void HLPCIABFPGI(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			BKHMEINKACE(true);
		}
	}

	public virtual void PNJHMMEAJBJ(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1093f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.NHHCHPIIPEK(PAPEDLBKBGM);
		}
	}

	public virtual void LDADNBLBLJI(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 1782f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.JCAFCBAMPOA(PAPEDLBKBGM);
		}
	}

	public void OGIANJJMBFA(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = !MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			NCCCEKKMCBC(true);
		}
	}

	public virtual TweenAlpha JJNPIFDBHAG(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 550f);
		}
		return base.JBFAGOHHPOM(PAPEDLBKBGM);
	}

	public void CDCDOKJNNIJ(bool HMMDCOMIDMI)
	{
		MLNJPOJKKHB = HMMDCOMIDMI;
		PEIHJLNLKPL.gameObject.SetActive(MLNJPOJKKHB);
		PMAOBDMEKFD.enabled = MLNJPOJKKHB;
		if (MLNJPOJKKHB)
		{
			MKKCFFFONLP(true);
		}
	}

	public virtual TweenAlpha PPLPLCAEHLF(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			TweenColor.Begin(KLMFIBIIALC.gameObject, IBECOAEMAHD, Colours.grayLockedCards);
			TweenAlpha.Begin(MBMIOELEAND.gameObject, IBECOAEMAHD, JOBAMADMOGF);
			return TweenAlpha.Begin(LCPBNBLGFIA.gameObject, IBECOAEMAHD, 1003f);
		}
		return base.FLDCGMHOOGP(PAPEDLBKBGM);
	}

	public virtual void LHGCDCOMOGM(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 530f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.LEOHGKOFBGM(PAPEDLBKBGM);
		}
	}

	public override void NHHCHPIIPEK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 869f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.GBMIIHOJKIK(PAPEDLBKBGM);
		}
	}

	public virtual void ADCAMKBEDLK(bool PAPEDLBKBGM)
	{
		if (MLNJPOJKKHB)
		{
			MBMIOELEAND.alpha = JOBAMADMOGF;
			LCPBNBLGFIA.alpha = 397f;
			KLMFIBIIALC.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				UITweener uITweener = componentsInChildren[i];
				if (!(uITweener.gameObject == PDPMBDAJJIO.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = true;
				}
			}
		}
		else
		{
			base.KLMIICIJFIN(PAPEDLBKBGM);
		}
	}
}
