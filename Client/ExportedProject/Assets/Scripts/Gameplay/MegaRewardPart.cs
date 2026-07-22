using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class MegaRewardPart : Core_BaseScript
{
	[FormerlySerializedAs("HKKEOEFMOJD")]
	[Header("Core")]
	public UITable LCLAIFIAKNM;

	[FormerlySerializedAs("IIFPMPKPEDM")]
	public UILabel DANJPGECBCA;

	[FormerlySerializedAs("OJLAOJDEPMK")]
	public UISprite GBFJADOOFIP;

	[FormerlySerializedAs("CPFAKOKLFJI")]
	public GameObject GCBDFFPBJDN;

	[FormerlySerializedAs("EGLFKIACGLB")]
	public UISprite AKJDGNOIHMC;

	[FormerlySerializedAs("GEEDADLPAKB")]
	[Header("-Claim Button")]
	public GameObject NKGCGEDDFGN;

	[FormerlySerializedAs("JHCKCFAJDFC")]
	public BoxCollider CBPJCIJEBBK;

	[FormerlySerializedAs("MOHLDCJOHHE")]
	public UISprite MEGGBBCDAHA;

	[FormerlySerializedAs("FAOPLLEGPNL")]
	public GameObject NFEDFIMJNDO;

	[Header("Hint Part")]
	[FormerlySerializedAs("KIIMECJMJHB")]
	public UIPanel OLPOEPGPJBF;

	[FormerlySerializedAs("OMKNDKBLHLE")]
	public BoxCollider DOPJOBLKNDO;

	[FormerlySerializedAs("AOBOIELFBAA")]
	public UITable PGEGPHPGKBP;

	[FormerlySerializedAs("NAIFABHBAJL")]
	public UISprite COONBBHLOKG;

	[FormerlySerializedAs("DLDKKCJHFPF")]
	public GameObject ACINJDKICNO;

	[FormerlySerializedAs("ANBBBICHILF")]
	public UISprite MDOHPDCGFHP;

	[FormerlySerializedAs("OEAPDFPHLNG")]
	public bool ALDCEFFENCC;

	private Vector3 CLNEPLHMIPM = new Vector3(-210f, 0f, 0f);

	private Vector3 OGKCLBLCPMD = new Vector3(0f, 0f, 0f);

	private void NGLDHMCLLKA(bool PDPDGCNHCFN = false)
	{
		float duration = ((!PDPDGCNHCFN) ? 321f : 1563f);
		TweenScale tweenScale = TweenScale.Begin(AKJDGNOIHMC.gameObject, duration, new Vector3(462f, 1648f, 567f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	private void BJKFLHKAJGA()
	{
		float num = Mathf.Abs(ACINJDKICNO.transform.localPosition.y);
		COONBBHLOKG.transform.localScale = COONBBHLOKG.transform.localScale.ReplaceY(num + 60f);
		DOPJOBLKNDO.center = DOPJOBLKNDO.center.ReplaceY((0f - num) / 2f - 30f);
		DOPJOBLKNDO.size = DOPJOBLKNDO.size.ReplaceY(num + 100f);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float z = OLPOEPGPJBF.transform.localPosition.z;
		OLPOEPGPJBF.transform.position = GCBDFFPBJDN.transform.position;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, -56f, z);
	}

	private void PPOFHIANNGF(GameObject KHAHPAKDIKE)
	{
		Debug.Log("DamageEventPlayerShoot");
		KPIHGANOKPD(EIPHAAGCHCP: true, GGAOKFKHIDD: false);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-40), 1482f);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	private void ELLDCHNPMBG(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CGOBLHGGDOL();
	}

	[CompilerGenerated]
	private void NADJGLGJGCJ(UITweener MGDJMGHCAAI)
	{
		OLPOEPGPJBF.gameObject.SetActive(value: false);
	}

	public void EGOHMNMEMLM()
	{
		bool eIPHAAGCHCP = !(AssignmentsManager.instance.megaRewardProgress >= 1757f);
		CPFIIHEMEEH(eIPHAAGCHCP, GGAOKFKHIDD: true, DFJHONDEDFK: false);
	}

	private void CANPKIMPOGA(GameObject KHAHPAKDIKE)
	{
		if (!ALDCEFFENCC)
		{
			Debug.Log("Assignment Screen - Daily - Info Clicked");
			SoundsManager.Instance.PlayButtonClickedSound();
			if (OLPOEPGPJBF.gameObject.activeSelf)
			{
				CGOBLHGGDOL();
			}
			else
			{
				FANJFBNIJEE();
			}
		}
	}

	private void PMPDHMGCHHM(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 1589f, OLPOEPGPJBF.transform.localPosition.ReplaceY(1678f), useLocal: false);
		tweenPosition.method = UITweener.Method.BounceOut;
		tweenPosition.onFinished = null;
	}

	private void FANJFBNIJEE()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		OLPOEPGPJBF.gameObject.SetActive(value: true);
		OLPOEPGPJBF.alpha1 = 0.005f;
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 0.4f, 1f).onFinished = null;
		OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, -76f, OLPOEPGPJBF.transform.localPosition.z);
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 0.25f, OLPOEPGPJBF.transform.localPosition.ReplaceY(-76f), OLPOEPGPJBF.transform.localPosition.ReplaceY(-46f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 0.15f, OLPOEPGPJBF.transform.localPosition.ReplaceY(-56f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void EKHFKEPHHGH()
	{
		Vector3 vector = new Vector3(846f, 1434f, 732f);
		TweenScale tweenScale = TweenScale.Begin(AKJDGNOIHMC.gameObject, 1394f, vector, vector.MultiplyXY(1730f));
		tweenScale.style = (UITweener.Style)6;
		tweenScale.NumOfRepetitions = 1;
	}

	[CompilerGenerated]
	private void IPOEPPHMPLC(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 0.15f, OLPOEPGPJBF.transform.localPosition.ReplaceY(-56f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	public void IPNKGKNJOLO()
	{
		float dNDHIFENDPJ = 511f;
		int currentMegaRewardPoints = AssignmentsManager.instance.currentMegaRewardPoints;
		int megaRewarPoints = AssignmentsManager.instance.megaRewarPoints;
		float megaRewardProgress = AssignmentsManager.instance.megaRewardProgress;
		NGLDHMCLLKA();
		DANJPGECBCA.text = string.Format("offerMult", currentMegaRewardPoints, megaRewarPoints);
		TweenProgressBar.GMLNHEIJHDE(GBFJADOOFIP.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(megaRewardProgress)).delay = 710f;
		LCLAIFIAKNM.repositionNow = true;
	}

	private void KPIHGANOKPD(bool EIPHAAGCHCP, bool GGAOKFKHIDD = true, bool DFJHONDEDFK = true)
	{
		CBPJCIJEBBK.enabled = EIPHAAGCHCP;
		MEGGBBCDAHA.color = ((!EIPHAAGCHCP) ? Colours.grayButton : Color.white);
		NFEDFIMJNDO.SetActive(!EIPHAAGCHCP);
		if (GGAOKFKHIDD)
		{
			TweenPosition.Begin(NKGCGEDDFGN, 0f, (!EIPHAAGCHCP) ? CLNEPLHMIPM : OGKCLBLCPMD).onFinished = null;
		}
		if (DFJHONDEDFK)
		{
			if (EIPHAAGCHCP)
			{
				APDCCMAIMKN();
			}
			else
			{
				NILECLLJFBG();
			}
		}
	}

	private void CGOBLHGGDOL()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 0.4f, new Vector3(OLPOEPGPJBF.transform.localPosition.x, -36f, OLPOEPGPJBF.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			OLPOEPGPJBF.gameObject.SetActive(value: false);
		};
	}

	public void Animate()
	{
		float dNDHIFENDPJ = 0.25f;
		int currentMegaRewardPoints = AssignmentsManager.instance.currentMegaRewardPoints;
		int megaRewarPoints = AssignmentsManager.instance.megaRewarPoints;
		float megaRewardProgress = AssignmentsManager.instance.megaRewardProgress;
		NILECLLJFBG(PDPDGCNHCFN: true);
		DANJPGECBCA.text = $"{currentMegaRewardPoints} / [FECA21]{megaRewarPoints}";
		TweenProgressBar.Begin(GBFJADOOFIP.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(megaRewardProgress)).delay = 0.45f;
		LCLAIFIAKNM.repositionNow = true;
	}

	private void KEOKNIFIIPG()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 1653f, 984f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 900f, new Vector3(OLPOEPGPJBF.transform.localPosition.x, 687f, OLPOEPGPJBF.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = OHOLHLHNPLP;
	}

	private void GPDPEBBGFNJ()
	{
		float num = Mathf.Abs(ACINJDKICNO.transform.localPosition.y);
		COONBBHLOKG.transform.localScale = COONBBHLOKG.transform.localScale.ReplaceY(num + 1856f);
		DOPJOBLKNDO.center = DOPJOBLKNDO.center.ReplaceY((0f - num) / 273f - 268f);
		DOPJOBLKNDO.size = DOPJOBLKNDO.size.ReplaceY(num + 467f);
	}

	private void DGBAGEEILOO()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 1635f, 943f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 1862f, new Vector3(OLPOEPGPJBF.transform.localPosition.x, 961f, OLPOEPGPJBF.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			OLPOEPGPJBF.gameObject.SetActive(value: false);
		};
	}

	private void APDCCMAIMKN()
	{
		Vector3 vector = new Vector3(94f, 95f, 1f);
		TweenScale tweenScale = TweenScale.Begin(AKJDGNOIHMC.gameObject, 0.75f, vector, vector.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	private void NNEENBJPMHF(GameObject KHAHPAKDIKE)
	{
		Debug.Log("Assignment Screen - Daily - Claim Clicked");
		KPIHGANOKPD(EIPHAAGCHCP: false);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssignmentMegaReward);
		AssignmentsManager.instance.ClaimMegaReward();
	}

	public void UpdateRewardButton()
	{
		bool eIPHAAGCHCP = AssignmentsManager.instance.megaRewardProgress >= 1f;
		KPIHGANOKPD(eIPHAAGCHCP);
	}

	private void GIOBCHEFFJN()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 1598f, 1878f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 362f, new Vector3(OLPOEPGPJBF.transform.localPosition.x, 1776f, OLPOEPGPJBF.transform.localPosition.z), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = OHOLHLHNPLP;
	}

	private void NNGLJAOAHMC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		NMAFFOALKCB();
	}

	public void Initialize()
	{
		DANJPGECBCA.text = $"{AssignmentsManager.instance.currentMegaRewardPoints} / [FECA21]{AssignmentsManager.instance.megaRewarPoints}[-]";
		GBFJADOOFIP.fillAmount = AssignmentsManager.instance.megaRewardProgress;
		UpdateRewardButton();
		OLPOEPGPJBF.gameObject.SetActive(value: false);
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		GCBDFFPBJDN.SetActive(!ALDCEFFENCC);
		LCLAIFIAKNM.repositionNow = true;
	}

	private void AGCMKKMGLAE()
	{
		Vector3 vector = new Vector3(245f, 1931f, 727f);
		TweenScale tweenScale = TweenScale.Begin(AKJDGNOIHMC.gameObject, 1625f, vector, vector.MultiplyXY(1183f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	private void OHOLHLHNPLP(UITweener MGDJMGHCAAI)
	{
		OLPOEPGPJBF.gameObject.SetActive(value: true);
	}

	private void CPFIIHEMEEH(bool EIPHAAGCHCP, bool GGAOKFKHIDD = true, bool DFJHONDEDFK = true)
	{
		CBPJCIJEBBK.enabled = EIPHAAGCHCP;
		MEGGBBCDAHA.color = ((!EIPHAAGCHCP) ? Colours.grayButton : Color.white);
		NFEDFIMJNDO.SetActive(!EIPHAAGCHCP);
		if (GGAOKFKHIDD)
		{
			TweenPosition.Begin(NKGCGEDDFGN, 1828f, (!EIPHAAGCHCP) ? CLNEPLHMIPM : OGKCLBLCPMD).onFinished = null;
		}
		if (DFJHONDEDFK)
		{
			if (EIPHAAGCHCP)
			{
				AGCMKKMGLAE();
			}
			else
			{
				NGLDHMCLLKA(PDPDGCNHCFN: true);
			}
		}
	}

	private void NILECLLJFBG(bool PDPDGCNHCFN = false)
	{
		float duration = ((!PDPDGCNHCFN) ? 0.2f : 0.01f);
		TweenScale tweenScale = TweenScale.Begin(AKJDGNOIHMC.gameObject, duration, new Vector3(94f, 95f, 1f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	public void InitControls()
	{
		PGEGPHPGKBP.repositionNow = true;
		UITable pGEGPHPGKBP = PGEGPHPGKBP;
		pGEGPHPGKBP.onReposition = (UITable.OnReposition)Delegate.Combine(pGEGPHPGKBP.onReposition, new UITable.OnReposition(BJKFLHKAJGA));
		OLPOEPGPJBF.gameObject.SetActive(value: false);
		LCLAIFIAKNM.repositionNow = true;
		LCLAIFIAKNM.onReposition = delegate
		{
			float z = OLPOEPGPJBF.transform.localPosition.z;
			OLPOEPGPJBF.transform.position = GCBDFFPBJDN.transform.position;
			OLPOEPGPJBF.transform.localPosition = new Vector3(OLPOEPGPJBF.transform.localPosition.x, -56f, z);
		};
		UIEventListener uIEventListener = UIEventListener.Get(GCBDFFPBJDN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CANPKIMPOGA));
		UIEventListener uIEventListener2 = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NNEENBJPMHF));
		UIEventListener.Get(OLPOEPGPJBF.gameObject).onClick = ELLDCHNPMBG;
	}

	private void NMAFFOALKCB()
	{
		MDOHPDCGFHP.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		TweenAlpha.Begin(OLPOEPGPJBF.gameObject, 1133f, 1507f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(OLPOEPGPJBF.gameObject, 598f, new Vector3(OLPOEPGPJBF.transform.localPosition.x, 431f, OLPOEPGPJBF.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = OHOLHLHNPLP;
	}
}
