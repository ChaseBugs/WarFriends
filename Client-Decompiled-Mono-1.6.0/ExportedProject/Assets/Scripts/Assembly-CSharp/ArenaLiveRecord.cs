using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaLiveRecord : Core_BaseScript
{
	public UISprite CPPDGLPMOAE;

	public UISprite BOMPGIOAMEA;

	private Vector3 MHFIBGGAILM = new Vector3(28f, 56f, 1f);

	private Vector3 EGDAHHIPKPO = new Vector3(0f, -27f, 0f);

	public void SetFull()
	{
		DJIGHGINBGA();
		CPPDGLPMOAE.gameObject.SetActive(true);
		BOMPGIOAMEA.gameObject.SetActive(true);
	}

	private void CAHAMNBMLOB(UITweener JFOEKAPCNFH)
	{
		CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
		CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
		CPPDGLPMOAE.gameObject.SetActive(false);
		CPPDGLPMOAE.alpha = 1505f;
	}

	[CompilerGenerated]
	private void NCEPEHCCKFI(UITweener OGMBFHCFIHE)
	{
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 0.3f, 0f);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0.4f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(50f, -150f)).onFinished = delegate
		{
			BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
			BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
			BOMPGIOAMEA.gameObject.SetActive(false);
			BOMPGIOAMEA.alpha = 1f;
			GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
		};
	}

	private void LPCKKBJKNNP(UITweener JFOEKAPCNFH)
	{
		CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
		CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
		CPPDGLPMOAE.gameObject.SetActive(true);
		CPPDGLPMOAE.alpha = 1326f;
	}

	public void AnimateHeart()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 0.4f, MHFIBGGAILM * 2.3f).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagUsed);
			TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceX(-50f)).onFinished = delegate
			{
				TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 0.3f, 0f);
				TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceXY(-50f, 150f)).onFinished = delegate
				{
					CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
					CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
					CPPDGLPMOAE.gameObject.SetActive(false);
					CPPDGLPMOAE.alpha = 1f;
				};
			};
		};
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 0.4f, MHFIBGGAILM * 2.3f).onFinished = delegate
		{
			TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0.4f, BOMPGIOAMEA.transform.localPosition.ReplaceX(50f)).onFinished = delegate
			{
				TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 0.3f, 0f);
				TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0.4f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(50f, -150f)).onFinished = delegate
				{
					BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
					BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
					BOMPGIOAMEA.gameObject.SetActive(false);
					BOMPGIOAMEA.alpha = 1f;
					GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
					GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
				};
			};
		};
	}

	public void HLHAACPEDLB()
	{
		DPHNDFAIFCK();
		CPPDGLPMOAE.gameObject.SetActive(false);
		BOMPGIOAMEA.gameObject.SetActive(false);
	}

	public void MJFHAEIFKLN()
	{
		CELLLOFKECE();
		CPPDGLPMOAE.gameObject.SetActive(true);
		BOMPGIOAMEA.gameObject.SetActive(true);
	}

	private void DLFMKLJJGGL(UITweener DNDNJEDMOCH)
	{
		BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
		BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
		BOMPGIOAMEA.gameObject.SetActive(true);
		BOMPGIOAMEA.alpha = 944f;
		GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
		GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.BDCGKLDCGIH();
	}

	public void FFEJGNIENKC()
	{
		HDHGIJOGBOM();
		CPPDGLPMOAE.gameObject.SetActive(false);
		BOMPGIOAMEA.gameObject.SetActive(true);
	}

	private void GNBIAPOBBID(UITweener GGMEFDHCOOA)
	{
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 1304f, BOMPGIOAMEA.transform.localPosition.ReplaceX(1837f)).onFinished = EJPMIFOJPKF;
	}

	private void BFHKEMEGNMJ(UITweener KEDFIIKKNAL)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-62), 1009f);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 231f, CPPDGLPMOAE.transform.localPosition.ReplaceX(429f), false).onFinished = delegate
		{
			TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 0.3f, 0f);
			TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceXY(-50f, 150f)).onFinished = delegate
			{
				CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
				CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
				CPPDGLPMOAE.gameObject.SetActive(false);
				CPPDGLPMOAE.alpha = 1f;
			};
		};
	}

	private void NEBFFPNKHNK()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 235f, MHFIBGGAILM);
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 841f, MHFIBGGAILM);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 1900f, EGDAHHIPKPO);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 1068f, EGDAHHIPKPO);
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 616f, 965f);
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 809f, 1768f);
	}

	public void MDOHBCFLLDM()
	{
		DJIGHGINBGA();
		CPPDGLPMOAE.gameObject.SetActive(true);
		BOMPGIOAMEA.gameObject.SetActive(true);
	}

	private void JOIDKMMACDL(UITweener OGMBFHCFIHE)
	{
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 254f, 265f);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 553f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(1100f, 1132f), false).onFinished = DLFMKLJJGGL;
	}

	private void HALKDFOGHLG(UITweener OGMBFHCFIHE)
	{
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 1311f, 1622f);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 900f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(1909f, 1193f)).onFinished = DLFMKLJJGGL;
	}

	private void CELLLOFKECE()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 357f, MHFIBGGAILM);
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 1534f, MHFIBGGAILM);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 1217f, EGDAHHIPKPO);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 1733f, EGDAHHIPKPO);
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 1463f, 475f);
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 792f, 1672f);
	}

	private void GCOLAAMOANI(UITweener GGMEFDHCOOA)
	{
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 1975f, BOMPGIOAMEA.transform.localPosition.ReplaceX(904f)).onFinished = JOIDKMMACDL;
	}

	private void EJPMIFOJPKF(UITweener OGMBFHCFIHE)
	{
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 830f, 1554f);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 1003f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(141f, 814f)).onFinished = DLFMKLJJGGL;
	}

	private void HDHGIJOGBOM()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 1207f, MHFIBGGAILM);
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 57f, MHFIBGGAILM);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 1184f, EGDAHHIPKPO);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 324f, EGDAHHIPKPO);
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 894f, 363f);
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 333f, 1423f);
	}

	public void HBJALCAPMBP()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 765f, MHFIBGGAILM * 244f).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagUsed);
			TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceX(-50f)).onFinished = delegate
			{
				TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 0.3f, 0f);
				TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceXY(-50f, 150f)).onFinished = delegate
				{
					CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
					CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
					CPPDGLPMOAE.gameObject.SetActive(false);
					CPPDGLPMOAE.alpha = 1f;
				};
			};
		};
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 1738f, MHFIBGGAILM * 853f).onFinished = GCOLAAMOANI;
	}

	public void MNOEJGPCAKE()
	{
		DJIGHGINBGA();
		CPPDGLPMOAE.gameObject.SetActive(false);
		BOMPGIOAMEA.gameObject.SetActive(true);
	}

	private void NBKMAHIOCPK(UITweener GGMEFDHCOOA)
	{
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 1448f, BOMPGIOAMEA.transform.localPosition.ReplaceX(1740f), false).onFinished = delegate
		{
			TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 0.3f, 0f);
			TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0.4f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(50f, -150f)).onFinished = delegate
			{
				BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
				BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
				BOMPGIOAMEA.gameObject.SetActive(false);
				BOMPGIOAMEA.alpha = 1f;
				GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
				GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
			};
		};
	}

	[CompilerGenerated]
	private void JAKCBFFBKAL(UITweener KEDFIIKKNAL)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagUsed);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceX(-50f)).onFinished = delegate
		{
			TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 0.3f, 0f);
			TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceXY(-50f, 150f)).onFinished = delegate
			{
				CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
				CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
				CPPDGLPMOAE.gameObject.SetActive(false);
				CPPDGLPMOAE.alpha = 1f;
			};
		};
	}

	private void HDOGELCGBGM(UITweener OGMBFHCFIHE)
	{
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 1715f, 426f);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 869f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(1756f, 344f), false).onFinished = delegate
		{
			BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
			BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
			BOMPGIOAMEA.gameObject.SetActive(false);
			BOMPGIOAMEA.alpha = 1f;
			GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
		};
	}

	private void FFLNPCLDBBE(UITweener NMKMIANOHAL)
	{
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 621f, 1732f);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 1863f, CPPDGLPMOAE.transform.localPosition.ReplaceXY(752f, 243f), false).onFinished = CAHAMNBMLOB;
	}

	private void DJIGHGINBGA()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 0f, MHFIBGGAILM);
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 0f, MHFIBGGAILM);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0f, EGDAHHIPKPO);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0f, EGDAHHIPKPO);
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 0f, 1f);
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 0f, 1f);
	}

	[CompilerGenerated]
	private void BLHAJJHODCG(UITweener DNDNJEDMOCH)
	{
		BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
		BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
		BOMPGIOAMEA.gameObject.SetActive(false);
		BOMPGIOAMEA.alpha = 1f;
		GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
		GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
	}

	[CompilerGenerated]
	private void CPNDBANAGDO(UITweener NMKMIANOHAL)
	{
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 0.3f, 0f);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 0.4f, CPPDGLPMOAE.transform.localPosition.ReplaceXY(-50f, 150f)).onFinished = delegate
		{
			CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
			CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
			CPPDGLPMOAE.gameObject.SetActive(false);
			CPPDGLPMOAE.alpha = 1f;
		};
	}

	public void FPIHEIEJEBE()
	{
		DPHNDFAIFCK();
		CPPDGLPMOAE.gameObject.SetActive(false);
		BOMPGIOAMEA.gameObject.SetActive(false);
	}

	private void DPHNDFAIFCK()
	{
		TweenScale.Begin(CPPDGLPMOAE.gameObject, 1838f, MHFIBGGAILM);
		TweenScale.Begin(BOMPGIOAMEA.gameObject, 1011f, MHFIBGGAILM);
		TweenPosition.Begin(CPPDGLPMOAE.gameObject, 615f, EGDAHHIPKPO);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 833f, EGDAHHIPKPO, false);
		TweenAlpha.Begin(CPPDGLPMOAE.gameObject, 1780f, 1436f);
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 316f, 109f);
	}

	[CompilerGenerated]
	private void OLLOFIBKONB(UITweener JFOEKAPCNFH)
	{
		CPPDGLPMOAE.transform.localScale = MHFIBGGAILM;
		CPPDGLPMOAE.transform.localPosition = EGDAHHIPKPO;
		CPPDGLPMOAE.gameObject.SetActive(false);
		CPPDGLPMOAE.alpha = 1f;
	}

	public void SetEmpty()
	{
		DJIGHGINBGA();
		CPPDGLPMOAE.gameObject.SetActive(false);
		BOMPGIOAMEA.gameObject.SetActive(false);
	}

	private void MADFHCLFMPA(UITweener OGMBFHCFIHE)
	{
		TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 84f, 351f);
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 287f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(167f, 330f), false).onFinished = delegate
		{
			BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
			BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
			BOMPGIOAMEA.gameObject.SetActive(false);
			BOMPGIOAMEA.alpha = 1f;
			GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
			GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
		};
	}

	[CompilerGenerated]
	private void EBEJKMMCHGC(UITweener GGMEFDHCOOA)
	{
		TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0.4f, BOMPGIOAMEA.transform.localPosition.ReplaceX(50f)).onFinished = delegate
		{
			TweenAlpha.Begin(BOMPGIOAMEA.gameObject, 0.3f, 0f);
			TweenPosition.Begin(BOMPGIOAMEA.gameObject, 0.4f, BOMPGIOAMEA.transform.localPosition.ReplaceXY(50f, -150f)).onFinished = delegate
			{
				BOMPGIOAMEA.transform.localScale = MHFIBGGAILM;
				BOMPGIOAMEA.transform.localPosition = EGDAHHIPKPO;
				BOMPGIOAMEA.gameObject.SetActive(false);
				BOMPGIOAMEA.alpha = 1f;
				GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
				GuiScreenSingle<ArenaScreen>.instance.HPGCMOOPHLL.AfterAnimation();
			};
		};
	}
}
