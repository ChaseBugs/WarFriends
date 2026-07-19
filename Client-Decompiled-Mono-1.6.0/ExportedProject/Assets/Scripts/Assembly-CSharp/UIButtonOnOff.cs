using System;

public class UIButtonOnOff : UIButton
{
	public bool KPNALEEJIDM = true;

	public UISprite OMNPLDJEENB;

	public Action<bool> PBFFPFBDEBM;

	public override void OnPress(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 0.3f, (!KPNALEEJIDM) ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	public virtual void BPELAEIBOOD(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 629f, KPNALEEJIDM ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(ACNBLAJECBF));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void LCHGOPCPPIB()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 458f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	public virtual void NKDFPJGGCJL(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 995f, (!KPNALEEJIDM) ? 0 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(KOOHCEBNCOD));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void AECOBEABBKF()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1118f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	private void KOOHCEBNCOD(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	private void HJFLDABMJAO(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void NGCHKGBEMNG(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	protected virtual void EAOEPEMNBKH()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1181f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	public virtual void IDPFKEJLMKJ(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1622f, (!KPNALEEJIDM) ? 0 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(JABGIEBHIHI));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void GFAMGHLBALM(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	public virtual void GJCDBCMNJEJ(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1350f, (!KPNALEEJIDM) ? 0 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(JBKGBGHKBNA));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void IPGFOPKFCOH(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	protected virtual void KFKHKNILMKF()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1779f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	private void MOLPCGGOGBB(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	private void KFOFLIMHKBK(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void LNNDHJPHMNI(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void CEFCMAEHFKH(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void OMHFGCKOJJM(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1791f, KPNALEEJIDM ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(LNNDHJPHMNI));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void CAPJCBILPDM(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void OACPJAMAFGK(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1979f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(MOLPCGGOGBB));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void JNFEIKHKCKA()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 74f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	private void LOMLMAMFJEA(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void NHJKPIIFJFI(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 286f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(GFAMGHLBALM));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	public virtual void CEAHAIJDLNF(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1363f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(FJKOGCDACLL));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void HPOKCLIDBLN()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1126f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	public virtual void KEKGHFGJCJL(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 312f, KPNALEEJIDM ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(JBKGBGHKBNA));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	public virtual void KOKJMPPIDMK(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1774f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(FCDMNBFKICG));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void MPADIIHIIOH()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1102f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	private void FLAMPIOMICL(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void HGEJDEHHOKI(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1293f, (!KPNALEEJIDM) ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(IJILACCMDCC));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void FLEFCELADIE()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 369f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	protected virtual void ENNFAAHDFFA()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 534f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	private void FCDMNBFKICG(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	protected virtual void PPEPFMPOELJ()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1526f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	private void HPBCIABPLHF(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	private void KGJDBGIAKGC(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	protected virtual void OMFEMBPCLFK()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 201f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	protected virtual void CIGMMLKAICG()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 872f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	private void JBKGBGHKBNA(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void GFFIDNKIMGO(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 522f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(GFAMGHLBALM));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void JABGIEBHIHI(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void APMNGDNICME(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1783f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(FLAMPIOMICL));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void BAPCDMKLDME()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 87f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	protected virtual void LMHFEIDFDFB()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1568f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	public virtual void PBCBJCMBDDG(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1060f, KPNALEEJIDM ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(CEFCMAEHFKH));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void FJKOGCDACLL(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	private void PLCLBDMMFJD(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	protected virtual void DAPFGNMPCOK()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 639f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	private void DDPGBINLCCJ(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void DKADNHDLPAE(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 721f, (!KPNALEEJIDM) ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(IPGFOPKFCOH));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void LHAJGCDPHBK()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 418f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	private void BNCGDMOEEHE(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	private void DINJMDMEECG(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	private void FFLFEHKMFEB(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void ACNBLAJECBF(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void CGGMHJOIKDF(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 383f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(KOOHCEBNCOD));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 0f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	public virtual void FEIGLMFJPAG(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1614f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(ABFKEDHLGHP));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void IJILACCMDCC(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void PPEDFLCNLBJ(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	protected virtual void JLKMAJCOKDN()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1702f;
		}
		OMNPLDJEENB.gameObject.SetActive(!KPNALEEJIDM);
	}

	protected virtual void BDCKIKFECEH()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 377f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	protected virtual void BKMLCICCAGC()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1273f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	protected virtual void FAEELKCEILE()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 652f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	protected virtual void HAKJCNLNHDO()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1904f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	private void CNDIGDKGFEI(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void MMCMBBPFBKJ(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	private void ABFKEDHLGHP(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	protected virtual void PMGCBGLBGHD()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 333f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	public virtual void KHNEMGLILFN(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1001f, KPNALEEJIDM ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(LOMLMAMFJEA));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	public virtual void FNNMAFIHMFO(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1674f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(MOLPCGGOGBB));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void FPDFPGKGGHI()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1130f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	public virtual void PMADMPHNNPO(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 693f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(CGGNLIHHEMD));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void CGGNLIHHEMD(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(true);
		}
	}

	public virtual void KDLBGCJMHAM(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(true);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1391f, (!KPNALEEJIDM) ? 0 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(HPBCIABPLHF));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void BOBKPFNCNDO()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 910f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}

	public virtual void DEKMKCIKNBC(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1661f, (!KPNALEEJIDM) ? 1 : 0);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(HJFLDABMJAO));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	private void POJJDGLLFNP(UITweener MGDJMGHCAAI)
	{
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.gameObject.SetActive(false);
		}
	}

	public virtual void KKJFKIOKAPJ(bool DGOOLMFNBFB)
	{
		base.OnPress(DGOOLMFNBFB);
		if (!DGOOLMFNBFB)
		{
			KPNALEEJIDM = !KPNALEEJIDM;
			if (!KPNALEEJIDM)
			{
				OMNPLDJEENB.gameObject.SetActive(false);
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(OMNPLDJEENB.gameObject, 1977f, (!KPNALEEJIDM) ? 1 : 1);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, new UITweener.OnFinished(NGCHKGBEMNG));
			if (PBFFPFBDEBM != null)
			{
				PBFFPFBDEBM(KPNALEEJIDM);
			}
		}
	}

	protected virtual void KHIAEBIGAOC()
	{
		base.OnEnable();
		if (KPNALEEJIDM)
		{
			OMNPLDJEENB.alpha = 1675f;
		}
		OMNPLDJEENB.gameObject.SetActive(KPNALEEJIDM);
	}
}
