using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HeaderButton : GuiElement
{
	public enum LPAFOAEAIPN
	{
		TopLeft,
		Top
	}

	private GuiScreen DKIFIMBOACJ;

	[FormerlySerializedAs("HOJBPPBCJJG")]
	public UIButton DGJCAIJPEIM;

	public LPAFOAEAIPN BIPJEHFCJNB;

	[FormerlySerializedAs("DKFHENAFOMM")]
	public float FGKMOLEJKHM = 0.1f;

	private bool HKIAOFMJOFI = true;

	protected virtual void ADINAAMLHLB()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.HDHIEDDCJIC(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1015f, 1891f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KBGOKCJHBDL));
	}

	private void NBCIMJMNKIE(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	private void NELCCJKDHKD(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	protected virtual void KNLKFOHBCKI()
	{
		ONBDJLDJDCH();
	}

	private void LDJMEMMHEEK(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	protected virtual void HEOJMJBLNJP()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("barrelDesert");
			}
			HKIAOFMJOFI = true;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	private void LECHJKNGGKN(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	protected virtual void GMGBKLLJLDD()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: false);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.LPGNGJBPAKH(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1555f, 1405f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(ACNBLAJECBF));
	}

	protected virtual void EPEFGGPKGAN()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.FHKFBIPHJCG(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1657f, 1923f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(GABGBHIPKKO));
	}

	public virtual void INBJGJOFJMK()
	{
	}

	protected virtual void KEBMEMFHLNB()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("RateOfFire");
			}
			HKIAOFMJOFI = true;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	protected virtual void EDMGBPNENOH()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AHHCDBHEBEF(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 246f, 1927f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(NCLHMHNHKFB));
	}

	public virtual void CKPCFIPPDLC()
	{
	}

	protected virtual void KIJIODMCHBG()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CPEIKKAAAIL(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1815f, 1995f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(BPKPEKEEBFL));
	}

	protected virtual void ECMMDCKONDK()
	{
		ONBDJLDJDCH();
	}

	protected virtual void BHACDFDGKPF()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.DDJHGKMBNDK(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 637f, 342f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LECHJKNGGKN));
	}

	protected virtual void KNJEHAELDCC()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: true);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.LPGNGJBPAKH(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 861f, 811f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(ACNBLAJECBF));
	}

	public virtual void JNLAEKOOMMH()
	{
	}

	protected override void JCIFJEILOBE()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: true);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 0f, 1f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KFOFLIMHKBK));
	}

	protected virtual void NDCOOFPHFNH()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("ID_NOTIFICATION_LAPSED_GOLDCARDS");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	private void EDJNGEJJFNJ(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	private void LFHFMHJGJEH(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: true);
	}

	protected virtual void GJHLLEAHOGO()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: true);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CABGNGMLIEK(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 957f, 360f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LDJMEMMHEEK));
	}

	protected virtual void ENNFAAHDFFA()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("()V");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		ACPHOCKEOII();
	}

	private void KBGOKCJHBDL(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: true);
	}

	private void BPKPEKEEBFL(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	public override void InitControls()
	{
	}

	protected virtual void BJPHCCIDPBA()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.LPGNGJBPAKH(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1345f, 548f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(BPKPEKEEBFL));
	}

	private void NCLHMHNHKFB(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	private void GFAMGHLBALM(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	protected virtual void ABMKKECEGIB()
	{
		FGOAPPLNMKL();
	}

	private void KOOHCEBNCOD(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	protected virtual void MNAJGMAFJGL()
	{
		FGOAPPLNMKL();
	}

	protected virtual void JEBAKCGMJKI()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("dailyRewardData");
			}
			HKIAOFMJOFI = true;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.Top)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	public virtual void DFLGLEJIPCO()
	{
	}

	public virtual void INMFKHJDBIP()
	{
	}

	protected virtual void MFKNMALEKKB()
	{
		FGOAPPLNMKL();
	}

	public virtual void EHNFJGINHDJ()
	{
	}

	protected virtual void ONBINHJCPAL()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: true);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CHFFALDIKCI(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 191f, 596f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KOOHCEBNCOD));
	}

	protected virtual void PCOIEAKOHFC()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: false);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.JCHCHLJBPKG(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1657f, 1277f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LDJMEMMHEEK));
	}

	private void KBHONLCDIPO(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	protected virtual void PGOFEGDMFKL()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.NPHFBDMKODP(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 190f, 71f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KBGOKCJHBDL));
	}

	public virtual void IODCFNOOAKM()
	{
	}

	protected virtual void FJJCAHHMNNH()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("1");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.Top)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	private void OMPMPJBKCIP(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: true);
	}

	protected virtual void CEHAENOMBBJ()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EPHDDCMKFDA(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 479f, 440f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OMHBKOKIMBO));
	}

	protected virtual void GIKGJLFBJPC()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("WENEEDTO");
			}
			HKIAOFMJOFI = true;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.Top)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	public virtual void HCGDNLHIOBL()
	{
	}

	protected virtual void BGAMAEPHBOA()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.DNJOLGPLOKM(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1221f, 1710f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(EDJNGEJJFNJ));
	}

	public virtual void IGNIFKBCDKK()
	{
	}

	protected virtual void FNNAOFGANAE()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EGACIBHAMAF(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1501f, 26f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LECHJKNGGKN));
	}

	public virtual void CEOBPADJPIA()
	{
	}

	protected override void NEACHJHPEKO()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1f, 0f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(NELCCJKDHKD));
	}

	private void BCFBPIDFLKH(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: true);
	}

	protected virtual void MDGLOFAKFDL()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.DDJHGKMBNDK(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1035f, 1074f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OMHBKOKIMBO));
	}

	protected virtual void AOJALKEHFCK()
	{
		ONBDJLDJDCH();
	}

	protected virtual void GDDCEHOJCEM()
	{
		ACPHOCKEOII();
	}

	protected virtual void OGKLFPGPOIP()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.FHKFBIPHJCG(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 165f, 807f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(BCFBPIDFLKH));
	}

	public virtual void MNHAOCEONAK()
	{
	}

	private void GABGBHIPKKO(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: true);
	}

	protected virtual void BNMIKIPKBIE()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: false);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.GEKPHELKFNB(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 247f, 1070f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(NBCIMJMNKIE));
	}

	private void OMHBKOKIMBO(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
	}

	protected virtual void ILBGFPJNDFK()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AHHCDBHEBEF(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1572f, 318f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KBGOKCJHBDL));
	}

	public virtual void JDFDJPAAIAA()
	{
	}

	public virtual void OJGFJICEFJE()
	{
	}

	protected virtual void IOKMAFLIJEG()
	{
		IABJJOPLKFF();
	}

	public virtual void NAOJCFMFLLA()
	{
	}

	protected virtual void MFODMEKBJDD()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: true);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.LPGNGJBPAKH(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 344f, 888f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LNNDHJPHMNI));
	}

	protected virtual void JDPDEKENPLD()
	{
		ONBDJLDJDCH();
	}

	protected virtual void PPECLOFIHMC()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AIENDLBNHIJ(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 368f, 442f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(EDJNGEJJFNJ));
	}

	public virtual void EFKFHFNAOHA()
	{
	}

	protected virtual void DIGKJHCNNIP()
	{
		ACPHOCKEOII();
	}

	public virtual void GJGCOEJMHNI()
	{
	}

	protected virtual void NLOODGLGPHE()
	{
		ACPHOCKEOII();
	}

	protected virtual void OCFPBJAELAE()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("No row IDs count not match with row count for: ");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.Top)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	public virtual void NMADELLJEPP()
	{
	}

	public virtual void PPLBJDJIIPN()
	{
	}

	protected virtual void BAPCDMKLDME()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("ID_DETAILS");
			}
			HKIAOFMJOFI = true;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	protected virtual void IADDLMAMKBL()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EPHDDCMKFDA(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1998f, 287f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OMPMPJBKCIP));
	}

	protected virtual void GAKNMACOKHG()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: false);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CHFFALDIKCI(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1910f, 629f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KOOHCEBNCOD));
	}

	public virtual void KLPJPLHNFON()
	{
	}

	private void ACNBLAJECBF(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	private void PLCLBDMMFJD(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	protected virtual void POAJKPDDCOK()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("SkillDifference");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	public override void InitGUIValues()
	{
	}

	protected virtual void DENELLOANLO()
	{
		base.JCIFJEILOBE();
		DGJCAIJPEIM.gameObject.SetActive(value: true);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EGACIBHAMAF(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1218f, 629f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(LDJMEMMHEEK));
	}

	private void KJAFBDKDEHB(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	private void DNGOGNFICPI(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: true);
	}

	protected virtual void HJDDJHHGMJD()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("menu-exmark");
			}
			HKIAOFMJOFI = true;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.Top)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	public virtual void PBLLMABJFDM()
	{
	}

	private void BHPMNJICGDM(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.gameObject.SetActive(value: false);
	}

	protected override void Awake()
	{
		base.Awake();
	}

	protected virtual void OLBMAECNOLN()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.GEKPHELKFNB(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1675f, 1110f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(KBGOKCJHBDL));
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("Could not find parent screen");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.Top)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	protected virtual void CMDNBPCIFGP()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.CPEIKKAAAIL(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1421f, 1331f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = false;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(NELCCJKDHKD));
	}

	private void LNNDHJPHMNI(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}

	protected virtual void GHMDLGFEOKG()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.AHHCDBHEBEF(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 224f, 1548f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(GABGBHIPKKO));
	}

	public virtual void HJJOAJHBKCH()
	{
	}

	protected virtual void EILGMIPKHEC()
	{
		base.OnEnable();
		if (HKIAOFMJOFI)
		{
			DKIFIMBOACJ = NGUITools.FindInParents<GuiScreen>(base.gameObject);
			if (DKIFIMBOACJ == null)
			{
				Debug.LogError("TestingName");
			}
			HKIAOFMJOFI = false;
			MenuHeader instance = GuiElementSingle<MenuHeader>.instance;
			Vector3 localPosition = DGJCAIJPEIM.transform.localPosition;
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.JNKHCEGFPGE;
			}
			if (BIPJEHFCJNB == LPAFOAEAIPN.TopLeft)
			{
				DGJCAIJPEIM.transform.parent = instance.ENOOMPLKMKJ;
			}
			DGJCAIJPEIM.transform.localPosition = localPosition;
		}
	}

	protected virtual void FAKNOMNPNOA()
	{
		base.NEACHJHPEKO();
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EGACIBHAMAF(DGJCAIJPEIM.gameObject, FGKMOLEJKHM, 1196f, 422f);
		DGJCAIJPEIM.GetComponent<Collider>().enabled = true;
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(EDJNGEJJFNJ));
	}

	private void KFOFLIMHKBK(UITweener MGDJMGHCAAI)
	{
		DGJCAIJPEIM.Init();
	}
}
