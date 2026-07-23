using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Background : GuiElementSingle<Background>
{
	public enum NKHJBLBAAEB
	{
		Classic,
		Picture,
		Overlay
	}

	private sealed class KCDAPKBNLEO
	{
		internal UISprite GMPADNOGGNL;

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void AMIJFGBOCLC(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void KNJBDOADLDO(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void PANKBNOCEAM(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void HHNEBNHCGMO(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void PCKMJMGLPDG(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: false);
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}

		internal void CHDOECNGOPM(UITweener MGDJMGHCAAI)
		{
			GMPADNOGGNL.gameObject.SetActive(value: true);
		}
	}

	[FormerlySerializedAs("EEMHNINCIIM")]
	public Camera BFJNDDGKIHH;

	[FormerlySerializedAs("KADEICNAOPG")]
	public UISprite NNJBEDJPGEH;

	[FormerlySerializedAs("KKLEDDOOALK")]
	public UISprite AKDJBKCNJHM;

	public UISprite DIGDNLFGMPA;

	public UISprite EBJMJALEKNH;

	[FormerlySerializedAs("GLGBEBGDLAF")]
	public float HPCONGLBFKE = 0.4f;

	[FormerlySerializedAs("GPPDGDMBFPO")]
	public ParticleSystem FFPLNCHHFDP;

	private NKHJBLBAAEB KNCCEDFJKBK = NKHJBLBAAEB.Picture;

	[FormerlySerializedAs("LBMHCHDKJEA")]
	public float DJCJDJGMAHO = 1f;

	[FormerlySerializedAs("FBBMPLAOMLJ")]
	public float GJLPBLDGCOP = 0.80078125f;

	[FormerlySerializedAs("DAAPCBMHALH")]
	public float PDEDFBAJOBG = 0.16015625f;

	[FormerlySerializedAs("PCFDMHLLKKD")]
	public float HLKLIHENKAF = 0.55078125f;

	[FormerlySerializedAs("JOEBHENAJIJ")]
	public GameObject IBCDMOOPLNN;

	[FormerlySerializedAs("FJJJELJMILC")]
	public UISprite GIOENEIKPCH;

	public override bool isShowed
	{
		get
		{
			return base.isShowed;
		}
		protected set
		{
			base.isShowed = value;
		}
	}

	public void DestroyParallax()
	{
		if (IBCDMOOPLNN != null)
		{
			UnityEngine.Object.Destroy(IBCDMOOPLNN);
			IBCDMOOPLNN = null;
		}
	}

	[SpecialName]
	public virtual bool EPEAMKJKPMC()
	{
		return base.isShowed;
	}

	[SpecialName]
	protected override void LBCNIBOEIFF(bool IDEBKDPMPGM)
	{
		base.LBCNIBOEIFF(IDEBKDPMPGM);
	}

	public void OEFMLFIBMGJ()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("{0:D2} Header {1}");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	public override void InitGUIValues()
	{
	}

	public virtual void JOEHMGCKEKE()
	{
		base.OIMKKAHOEKO();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: false);
	}

	private UITweener OONMBMHMAKN(UISprite GMPADNOGGNL, float AFCMOEFDCHO)
	{
		if (GMPADNOGGNL.gameObject.activeSelf)
		{
			GMPADNOGGNL.alpha = AFCMOEFDCHO;
			return TweenAlpha.Begin(GMPADNOGGNL.gameObject, 717f, AFCMOEFDCHO);
		}
		GMPADNOGGNL.gameObject.SetActive(value: true);
		GMPADNOGGNL.alpha = 179f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, HPCONGLBFKE, AFCMOEFDCHO);
		tweenAlpha.onFinished = null;
		return tweenAlpha;
	}

	private void BEOEJIIMLBL(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
	}

	private void MFABOJFBAAD(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
	}

	private UITweener BKBKDDHJFGM(UISprite GMPADNOGGNL, float AFCMOEFDCHO)
	{
		if (GMPADNOGGNL == null)
		{
			return null;
		}
		if (GMPADNOGGNL.gameObject.activeSelf)
		{
			GMPADNOGGNL.alpha = AFCMOEFDCHO;
			return TweenAlpha.Begin(GMPADNOGGNL.gameObject, 0f, AFCMOEFDCHO);
		}
		GMPADNOGGNL.gameObject.SetActive(value: true);
		GMPADNOGGNL.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, HPCONGLBFKE, AFCMOEFDCHO);
		tweenAlpha.onFinished = null;
		return tweenAlpha;
	}

	[SpecialName]
	public virtual bool PHCDNCGCHCB()
	{
		return base.NPFFMLLLDAF();
	}

	public override void InitControls()
	{
		GIOENEIKPCH.gameObject.SetActive(value: false);
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.clearFlags = CameraClearFlags.Depth;
	}

	public void AMBPEPHNPEL(NKHJBLBAAEB LGMALHPGKOK)
	{
		if (KNCCEDFJKBK != LGMALHPGKOK)
		{
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				UITweener uITweener = MNLLFNFFCIC(NNJBEDJPGEH, DJCJDJGMAHO);
				uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, new UITweener.OnFinished(CEEMIKFEJMK));
				if (FFPLNCHHFDP != null)
				{
					FFPLNCHHFDP.Stop();
					FFPLNCHHFDP.gameObject.SetActive(value: false);
				}
			}
			else
			{
				PEJKMJPLGCJ(NNJBEDJPGEH);
				if (IBCDMOOPLNN != null)
				{
					IBCDMOOPLNN.SetActive(value: true);
				}
				FFPLNCHHFDP.Stop();
				FFPLNCHHFDP.gameObject.SetActive(value: true);
			}
			if (LGMALHPGKOK == NKHJBLBAAEB.Picture)
			{
				PGJMPLLJIFK(DIGDNLFGMPA);
				HOHHDINCPLN(EBJMJALEKNH);
				PGJMPLLJIFK(AKDJBKCNJHM);
			}
			else
			{
				MNLLFNFFCIC(DIGDNLFGMPA, PDEDFBAJOBG);
				BKBKDDHJFGM(EBJMJALEKNH, HLKLIHENKAF);
				BKBKDDHJFGM(AKDJBKCNJHM, GJLPBLDGCOP);
			}
		}
		else
		{
			NNJBEDJPGEH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Classic);
			AKDJBKCNJHM.gameObject.SetActive(LGMALHPGKOK == (NKHJBLBAAEB)3);
			DIGDNLFGMPA.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			EBJMJALEKNH.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			if (IBCDMOOPLNN != null)
			{
				IBCDMOOPLNN.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			}
			if (NNJBEDJPGEH != null && NNJBEDJPGEH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(NNJBEDJPGEH.gameObject, 1739f, DJCJDJGMAHO).onFinished = null;
				NNJBEDJPGEH.alpha = DJCJDJGMAHO;
			}
			if (AKDJBKCNJHM != null && AKDJBKCNJHM.gameObject.activeSelf)
			{
				TweenAlpha.Begin(AKDJBKCNJHM.gameObject, 1956f, GJLPBLDGCOP).onFinished = null;
				AKDJBKCNJHM.alpha = GJLPBLDGCOP;
			}
			if (DIGDNLFGMPA != null && DIGDNLFGMPA.gameObject.activeSelf)
			{
				TweenAlpha.Begin(DIGDNLFGMPA.gameObject, 1433f, PDEDFBAJOBG).onFinished = null;
				DIGDNLFGMPA.alpha = PDEDFBAJOBG;
			}
			if (EBJMJALEKNH != null && EBJMJALEKNH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(EBJMJALEKNH.gameObject, 1617f, HLKLIHENKAF).onFinished = null;
				EBJMJALEKNH.alpha = HLKLIHENKAF;
			}
		}
		KNCCEDFJKBK = LGMALHPGKOK;
	}

	private void FCOIIMAJECF(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
	}

	[SpecialName]
	public virtual bool MIJGJCJCIJP()
	{
		return base.NPFFMLLLDAF();
	}

	public virtual void LAMBEOCPCBD()
	{
		GIOENEIKPCH.gameObject.SetActive(value: false);
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
		BFJNDDGKIHH.clearFlags = (CameraClearFlags)7;
	}

	private UITweener LOAGMOCMACI(UISprite GMPADNOGGNL, float AFCMOEFDCHO)
	{
		if (GMPADNOGGNL.gameObject.activeSelf)
		{
			GMPADNOGGNL.alpha = AFCMOEFDCHO;
			return TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1354f, AFCMOEFDCHO);
		}
		GMPADNOGGNL.gameObject.SetActive(value: true);
		GMPADNOGGNL.alpha = 1038f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, HPCONGLBFKE, AFCMOEFDCHO);
		tweenAlpha.onFinished = null;
		return tweenAlpha;
	}

	[SpecialName]
	public virtual bool KNGJMDHBJGA()
	{
		return base.NPFFMLLLDAF();
	}

	public virtual void JDNNJCHMFHF()
	{
		base.OIMKKAHOEKO();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: false);
	}

	public void BJEAELGNEGB(NKHJBLBAAEB LGMALHPGKOK)
	{
		if (KNCCEDFJKBK != LGMALHPGKOK)
		{
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				UITweener uITweener = LOAGMOCMACI(NNJBEDJPGEH, DJCJDJGMAHO);
				uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, (UITweener.OnFinished)delegate
				{
					if (IBCDMOOPLNN != null)
					{
						IBCDMOOPLNN.SetActive(value: false);
					}
				});
				FFPLNCHHFDP.gameObject.SetActive(value: false);
				FFPLNCHHFDP.Play();
			}
			else
			{
				LJDBAPILAFL(NNJBEDJPGEH);
				if (IBCDMOOPLNN != null)
				{
					IBCDMOOPLNN.SetActive(value: true);
				}
				FFPLNCHHFDP.Stop();
				FFPLNCHHFDP.gameObject.SetActive(value: true);
			}
			if (LGMALHPGKOK == NKHJBLBAAEB.Picture)
			{
				PEJKMJPLGCJ(DIGDNLFGMPA);
				PEJKMJPLGCJ(EBJMJALEKNH);
				PEJKMJPLGCJ(AKDJBKCNJHM);
			}
			else
			{
				BKBKDDHJFGM(DIGDNLFGMPA, PDEDFBAJOBG);
				BKBKDDHJFGM(EBJMJALEKNH, HLKLIHENKAF);
				BKBKDDHJFGM(AKDJBKCNJHM, GJLPBLDGCOP);
			}
		}
		else
		{
			NNJBEDJPGEH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Classic);
			AKDJBKCNJHM.gameObject.SetActive(LGMALHPGKOK == (NKHJBLBAAEB)4);
			DIGDNLFGMPA.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Classic);
			EBJMJALEKNH.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Classic);
			if (IBCDMOOPLNN != null)
			{
				IBCDMOOPLNN.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			}
			if (NNJBEDJPGEH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(NNJBEDJPGEH.gameObject, 165f, DJCJDJGMAHO).onFinished = null;
				NNJBEDJPGEH.alpha = DJCJDJGMAHO;
			}
			if (AKDJBKCNJHM.gameObject.activeSelf)
			{
				TweenAlpha.Begin(AKDJBKCNJHM.gameObject, 1985f, GJLPBLDGCOP).onFinished = null;
				AKDJBKCNJHM.alpha = GJLPBLDGCOP;
			}
			if (DIGDNLFGMPA.gameObject.activeSelf)
			{
				TweenAlpha.Begin(DIGDNLFGMPA.gameObject, 1125f, PDEDFBAJOBG).onFinished = null;
				DIGDNLFGMPA.alpha = PDEDFBAJOBG;
			}
			if (EBJMJALEKNH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(EBJMJALEKNH.gameObject, 814f, HLKLIHENKAF).onFinished = null;
				EBJMJALEKNH.alpha = HLKLIHENKAF;
			}
		}
		KNCCEDFJKBK = LGMALHPGKOK;
	}

	private void PGJMPLLJIFK(UISprite GMPADNOGGNL)
	{
		KCDAPKBNLEO kCDAPKBNLEO = new KCDAPKBNLEO();
		kCDAPKBNLEO.GMPADNOGGNL = GMPADNOGGNL;
		if (kCDAPKBNLEO.GMPADNOGGNL.gameObject.activeSelf)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(kCDAPKBNLEO.GMPADNOGGNL.gameObject, HPCONGLBFKE, 0f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = kCDAPKBNLEO.LJCDGJKCNEC;
		}
		else
		{
			kCDAPKBNLEO.GMPADNOGGNL.alpha = 0f;
		}
	}

	[CompilerGenerated]
	private void CDHCANGGBNL(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: false);
	}

	public void FDDDDLNKACJ()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("DeathEventPlayer");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	public void LoadParallax()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("Parallax/Parallax");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	private void GHICEIFNKMM(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
	}

	private void HOHHDINCPLN(UISprite GMPADNOGGNL)
	{
		KCDAPKBNLEO kCDAPKBNLEO = new KCDAPKBNLEO();
		kCDAPKBNLEO.GMPADNOGGNL = GMPADNOGGNL;
		if (kCDAPKBNLEO.GMPADNOGGNL.gameObject.activeSelf)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(kCDAPKBNLEO.GMPADNOGGNL.gameObject, HPCONGLBFKE, 1999f);
			tweenAlpha.method = UITweener.Method.EaseIn;
			tweenAlpha.onFinished = kCDAPKBNLEO.PCKMJMGLPDG;
		}
		else
		{
			kCDAPKBNLEO.GMPADNOGGNL.alpha = 1647f;
		}
	}

	public virtual void MNHAOCEONAK()
	{
		GIOENEIKPCH.gameObject.SetActive(value: true);
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.clearFlags = CameraClearFlags.Skybox;
	}

	private void IMHPOHNKIEA(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
	}

	[SpecialName]
	public virtual bool FNPBLMEHPAA()
	{
		return base.NPFFMLLLDAF();
	}

	private void LJDBAPILAFL(UISprite GMPADNOGGNL)
	{
		KCDAPKBNLEO kCDAPKBNLEO = new KCDAPKBNLEO();
		kCDAPKBNLEO.GMPADNOGGNL = GMPADNOGGNL;
		if (kCDAPKBNLEO.GMPADNOGGNL.gameObject.activeSelf)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(kCDAPKBNLEO.GMPADNOGGNL.gameObject, HPCONGLBFKE, 371f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = kCDAPKBNLEO.PCKMJMGLPDG;
		}
		else
		{
			kCDAPKBNLEO.GMPADNOGGNL.alpha = 1777f;
		}
	}

	public virtual void KDGJKKOONPB()
	{
		base.DoAfterHide();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: false);
	}

	public void GDBMDNEHNBO()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("Squad");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GIOENEIKPCH.gameObject.SetActive(value: false);
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: true);
	}

	public void FGABLBFJFEP()
	{
		if (IBCDMOOPLNN != null)
		{
			UnityEngine.Object.Destroy(IBCDMOOPLNN);
			IBCDMOOPLNN = null;
		}
	}

	private UITweener MNLLFNFFCIC(UISprite GMPADNOGGNL, float AFCMOEFDCHO)
	{
		if (GMPADNOGGNL.gameObject.activeSelf)
		{
			GMPADNOGGNL.alpha = AFCMOEFDCHO;
			return TweenAlpha.Begin(GMPADNOGGNL.gameObject, 513f, AFCMOEFDCHO);
		}
		GMPADNOGGNL.gameObject.SetActive(value: true);
		GMPADNOGGNL.alpha = 131f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, HPCONGLBFKE, AFCMOEFDCHO);
		tweenAlpha.onFinished = null;
		return tweenAlpha;
	}

	public void ELDBALDCJBM()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("Gold");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	private void PEJKMJPLGCJ(UISprite GMPADNOGGNL)
	{
		KCDAPKBNLEO kCDAPKBNLEO = new KCDAPKBNLEO();
		kCDAPKBNLEO.GMPADNOGGNL = GMPADNOGGNL;
		if (kCDAPKBNLEO.GMPADNOGGNL.gameObject.activeSelf)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(kCDAPKBNLEO.GMPADNOGGNL.gameObject, HPCONGLBFKE, 1509f);
			tweenAlpha.method = UITweener.Method.EaseIn;
			tweenAlpha.onFinished = kCDAPKBNLEO.KPHEPHDFCKK;
		}
		else
		{
			kCDAPKBNLEO.GMPADNOGGNL.alpha = 1333f;
		}
	}

	[SpecialName]
	public virtual bool GOELBFGAGOD()
	{
		return base.isShowed;
	}

	public virtual void EOFOMCBDBJN()
	{
	}

	public virtual void AHMBANMKGEJ()
	{
		base.OIMKKAHOEKO();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: true);
	}

	public virtual void DKOBOPADMMI()
	{
		base.DoAfterHide();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: true);
	}

	public virtual void OFCCACPEBHD()
	{
	}

	public void FABHDIEENGE()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("ID_GOLDSMALL");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	public void HPCILOFKJFF(NKHJBLBAAEB LGMALHPGKOK)
	{
		if (KNCCEDFJKBK != LGMALHPGKOK)
		{
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				UITweener uITweener = BKBKDDHJFGM(NNJBEDJPGEH, DJCJDJGMAHO);
				uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, new UITweener.OnFinished(BEOEJIIMLBL));
				// The recovered particle material renders as cyan streak noise over every
				// menu. Keep the static Classic background and suppress only that effect.
				if (FFPLNCHHFDP != null)
				{
					FFPLNCHHFDP.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
					FFPLNCHHFDP.gameObject.SetActive(value: false);
				}
			}
			else
			{
				PEJKMJPLGCJ(NNJBEDJPGEH);
				if (IBCDMOOPLNN != null)
				{
					IBCDMOOPLNN.SetActive(value: false);
				}
				FFPLNCHHFDP.Stop();
				FFPLNCHHFDP.gameObject.SetActive(value: true);
			}
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				LJDBAPILAFL(DIGDNLFGMPA);
				PEJKMJPLGCJ(EBJMJALEKNH);
				PGJMPLLJIFK(AKDJBKCNJHM);
			}
			else
			{
				OONMBMHMAKN(DIGDNLFGMPA, PDEDFBAJOBG);
				MNLLFNFFCIC(EBJMJALEKNH, HLKLIHENKAF);
				MNLLFNFFCIC(AKDJBKCNJHM, GJLPBLDGCOP);
			}
		}
		else
		{
			NNJBEDJPGEH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			AKDJBKCNJHM.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Classic);
			DIGDNLFGMPA.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Classic);
			EBJMJALEKNH.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			if (IBCDMOOPLNN != null)
			{
				IBCDMOOPLNN.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Classic);
			}
			if (NNJBEDJPGEH != null && NNJBEDJPGEH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(NNJBEDJPGEH.gameObject, 996f, DJCJDJGMAHO).onFinished = null;
				NNJBEDJPGEH.alpha = DJCJDJGMAHO;
			}
			if (AKDJBKCNJHM != null && AKDJBKCNJHM.gameObject.activeSelf)
			{
				TweenAlpha.Begin(AKDJBKCNJHM.gameObject, 344f, GJLPBLDGCOP).onFinished = null;
				AKDJBKCNJHM.alpha = GJLPBLDGCOP;
			}
			if (DIGDNLFGMPA != null && DIGDNLFGMPA.gameObject.activeSelf)
			{
				TweenAlpha.Begin(DIGDNLFGMPA.gameObject, 704f, PDEDFBAJOBG).onFinished = null;
				DIGDNLFGMPA.alpha = PDEDFBAJOBG;
			}
			if (EBJMJALEKNH != null && EBJMJALEKNH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(EBJMJALEKNH.gameObject, 379f, HLKLIHENKAF).onFinished = null;
				EBJMJALEKNH.alpha = HLKLIHENKAF;
			}
		}
		KNCCEDFJKBK = LGMALHPGKOK;
	}

	[SpecialName]
	protected virtual void MHLMEMDDAOB(bool IDEBKDPMPGM)
	{
		base.GCENJJCIEHL(IDEBKDPMPGM);
	}

	public void AAPDNDLILCM(NKHJBLBAAEB LGMALHPGKOK)
	{
		if (KNCCEDFJKBK != LGMALHPGKOK)
		{
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				UITweener uITweener = MNLLFNFFCIC(NNJBEDJPGEH, DJCJDJGMAHO);
				uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, new UITweener.OnFinished(FCOIIMAJECF));
				// The recovered particle material renders as cyan streak noise across all
				// menu screens. Preserve the Classic background without that decoration.
				if (FFPLNCHHFDP != null)
				{
					FFPLNCHHFDP.Stop();
					FFPLNCHHFDP.Clear(withChildren: true);
					FFPLNCHHFDP.gameObject.SetActive(value: false);
				}
			}
			else
			{
				PEJKMJPLGCJ(NNJBEDJPGEH);
				if (IBCDMOOPLNN != null)
				{
					IBCDMOOPLNN.SetActive(value: true);
				}
				FFPLNCHHFDP.Stop();
				FFPLNCHHFDP.gameObject.SetActive(value: true);
			}
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				HOHHDINCPLN(DIGDNLFGMPA);
				PEJKMJPLGCJ(EBJMJALEKNH);
				LJDBAPILAFL(AKDJBKCNJHM);
			}
			else
			{
				MNLLFNFFCIC(DIGDNLFGMPA, PDEDFBAJOBG);
				MNLLFNFFCIC(EBJMJALEKNH, HLKLIHENKAF);
				BKBKDDHJFGM(AKDJBKCNJHM, GJLPBLDGCOP);
			}
		}
		else
		{
			NNJBEDJPGEH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Classic);
			AKDJBKCNJHM.gameObject.SetActive(LGMALHPGKOK == (NKHJBLBAAEB)4);
			DIGDNLFGMPA.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			EBJMJALEKNH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			if (IBCDMOOPLNN != null)
			{
				IBCDMOOPLNN.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			}
			if (NNJBEDJPGEH != null && NNJBEDJPGEH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(NNJBEDJPGEH.gameObject, 438f, DJCJDJGMAHO).onFinished = null;
				NNJBEDJPGEH.alpha = DJCJDJGMAHO;
			}
			if (AKDJBKCNJHM != null && AKDJBKCNJHM.gameObject.activeSelf)
			{
				TweenAlpha.Begin(AKDJBKCNJHM.gameObject, 54f, GJLPBLDGCOP).onFinished = null;
				AKDJBKCNJHM.alpha = GJLPBLDGCOP;
			}
			if (DIGDNLFGMPA != null && DIGDNLFGMPA.gameObject.activeSelf)
			{
				TweenAlpha.Begin(DIGDNLFGMPA.gameObject, 330f, PDEDFBAJOBG).onFinished = null;
				DIGDNLFGMPA.alpha = PDEDFBAJOBG;
			}
			if (EBJMJALEKNH != null && EBJMJALEKNH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(EBJMJALEKNH.gameObject, 1437f, HLKLIHENKAF).onFinished = null;
				EBJMJALEKNH.alpha = HLKLIHENKAF;
			}
		}
		KNCCEDFJKBK = LGMALHPGKOK;
	}

	public void ShowVariant(NKHJBLBAAEB LGMALHPGKOK)
	{
		if (KNCCEDFJKBK != LGMALHPGKOK)
		{
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				UITweener uITweener = BKBKDDHJFGM(NNJBEDJPGEH, DJCJDJGMAHO);
				if (uITweener != null)
				{
					uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, (UITweener.OnFinished)delegate
					{
						if (IBCDMOOPLNN != null)
						{
							IBCDMOOPLNN.SetActive(value: false);
						}
					});
				}
				// The recovered particle material renders as cyan streak noise across all
				// menu screens. Preserve the Classic background without that decoration.
				if (FFPLNCHHFDP != null)
				{
					FFPLNCHHFDP.Stop();
					FFPLNCHHFDP.Clear(withChildren: true);
					FFPLNCHHFDP.gameObject.SetActive(value: false);
				}
			}
			else
			{
				PGJMPLLJIFK(NNJBEDJPGEH);
				if (IBCDMOOPLNN != null)
				{
					IBCDMOOPLNN.SetActive(value: true);
				}
				if (FFPLNCHHFDP != null)
				{
					FFPLNCHHFDP.Stop();
					FFPLNCHHFDP.gameObject.SetActive(value: false);
				}
			}
			if (LGMALHPGKOK == NKHJBLBAAEB.Picture)
			{
				if (DIGDNLFGMPA != null) PGJMPLLJIFK(DIGDNLFGMPA);
				if (EBJMJALEKNH != null) PGJMPLLJIFK(EBJMJALEKNH);
				if (AKDJBKCNJHM != null) PGJMPLLJIFK(AKDJBKCNJHM);
			}
			else
			{
				BKBKDDHJFGM(DIGDNLFGMPA, PDEDFBAJOBG);
				BKBKDDHJFGM(EBJMJALEKNH, HLKLIHENKAF);
				BKBKDDHJFGM(AKDJBKCNJHM, GJLPBLDGCOP);
			}
		}
		else
		{
			if (NNJBEDJPGEH != null) NNJBEDJPGEH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Classic);
			if (AKDJBKCNJHM != null) AKDJBKCNJHM.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Overlay);
			if (DIGDNLFGMPA != null) DIGDNLFGMPA.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			if (EBJMJALEKNH != null) EBJMJALEKNH.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			if (IBCDMOOPLNN != null)
			{
				IBCDMOOPLNN.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Classic);
			}
			if (NNJBEDJPGEH != null && NNJBEDJPGEH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(NNJBEDJPGEH.gameObject, 0f, DJCJDJGMAHO).onFinished = null;
				NNJBEDJPGEH.alpha = DJCJDJGMAHO;
			}
			if (AKDJBKCNJHM != null && AKDJBKCNJHM.gameObject.activeSelf)
			{
				TweenAlpha.Begin(AKDJBKCNJHM.gameObject, 0f, GJLPBLDGCOP).onFinished = null;
				AKDJBKCNJHM.alpha = GJLPBLDGCOP;
			}
			if (DIGDNLFGMPA != null && DIGDNLFGMPA.gameObject.activeSelf)
			{
				TweenAlpha.Begin(DIGDNLFGMPA.gameObject, 0f, PDEDFBAJOBG).onFinished = null;
				DIGDNLFGMPA.alpha = PDEDFBAJOBG;
			}
			if (EBJMJALEKNH != null && EBJMJALEKNH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(EBJMJALEKNH.gameObject, 0f, HLKLIHENKAF).onFinished = null;
				EBJMJALEKNH.alpha = HLKLIHENKAF;
			}
		}
		KNCCEDFJKBK = LGMALHPGKOK;
	}

	public virtual void NLBAPEADKNJ()
	{
		base.OIMKKAHOEKO();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: true);
	}

	private void CEEMIKFEJMK(UITweener MGDJMGHCAAI)
	{
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: false);
		}
	}

	public virtual void NOMBEBADCKJ()
	{
		base.DoAfterHide();
		if (IBCDMOOPLNN != null)
		{
			IBCDMOOPLNN.SetActive(value: true);
		}
		BFJNDDGKIHH.gameObject.SetActive(value: true);
	}

	public virtual void OKMMGFMKJGG()
	{
	}

	[SpecialName]
	public virtual bool EMAEFCCMNAK()
	{
		return base.NPFFMLLLDAF();
	}

	public void PFHAMOKBHFE()
	{
		if (IBCDMOOPLNN == null)
		{
			GameObject original = Resources.Load<GameObject>("menu-assignments-type-kill");
			IBCDMOOPLNN = UnityEngine.Object.Instantiate(original);
			IBCDMOOPLNN.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}

	public virtual void PNLGFNBEOLG()
	{
	}

	public void NDEIKIBPENM(NKHJBLBAAEB LGMALHPGKOK)
	{
		if (KNCCEDFJKBK != LGMALHPGKOK)
		{
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				UITweener uITweener = LOAGMOCMACI(NNJBEDJPGEH, DJCJDJGMAHO);
				uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, (UITweener.OnFinished)delegate
				{
					if (IBCDMOOPLNN != null)
					{
						IBCDMOOPLNN.SetActive(value: false);
					}
				});
				FFPLNCHHFDP.gameObject.SetActive(value: false);
				FFPLNCHHFDP.Play();
			}
			else
			{
				PGJMPLLJIFK(NNJBEDJPGEH);
				if (IBCDMOOPLNN != null)
				{
					IBCDMOOPLNN.SetActive(value: true);
				}
				FFPLNCHHFDP.Stop();
				FFPLNCHHFDP.gameObject.SetActive(value: false);
			}
			if (LGMALHPGKOK == NKHJBLBAAEB.Classic)
			{
				HOHHDINCPLN(DIGDNLFGMPA);
				PEJKMJPLGCJ(EBJMJALEKNH);
				HOHHDINCPLN(AKDJBKCNJHM);
			}
			else
			{
				MNLLFNFFCIC(DIGDNLFGMPA, PDEDFBAJOBG);
				LOAGMOCMACI(EBJMJALEKNH, HLKLIHENKAF);
				OONMBMHMAKN(AKDJBKCNJHM, GJLPBLDGCOP);
			}
		}
		else
		{
			NNJBEDJPGEH.gameObject.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			AKDJBKCNJHM.gameObject.SetActive(LGMALHPGKOK == (NKHJBLBAAEB)6);
			DIGDNLFGMPA.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Picture);
			EBJMJALEKNH.gameObject.SetActive(LGMALHPGKOK != NKHJBLBAAEB.Classic);
			if (IBCDMOOPLNN != null)
			{
				IBCDMOOPLNN.SetActive(LGMALHPGKOK == NKHJBLBAAEB.Picture);
			}
			if (NNJBEDJPGEH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(NNJBEDJPGEH.gameObject, 1125f, DJCJDJGMAHO).onFinished = null;
				NNJBEDJPGEH.alpha = DJCJDJGMAHO;
			}
			if (AKDJBKCNJHM.gameObject.activeSelf)
			{
				TweenAlpha.Begin(AKDJBKCNJHM.gameObject, 819f, GJLPBLDGCOP).onFinished = null;
				AKDJBKCNJHM.alpha = GJLPBLDGCOP;
			}
			if (DIGDNLFGMPA.gameObject.activeSelf)
			{
				TweenAlpha.Begin(DIGDNLFGMPA.gameObject, 1721f, PDEDFBAJOBG).onFinished = null;
				DIGDNLFGMPA.alpha = PDEDFBAJOBG;
			}
			if (EBJMJALEKNH.gameObject.activeSelf)
			{
				TweenAlpha.Begin(EBJMJALEKNH.gameObject, 43f, HLKLIHENKAF).onFinished = null;
				EBJMJALEKNH.alpha = HLKLIHENKAF;
			}
		}
		KNCCEDFJKBK = LGMALHPGKOK;
	}
}
