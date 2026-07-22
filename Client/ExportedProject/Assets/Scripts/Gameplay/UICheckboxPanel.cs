using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class UICheckboxPanel : MonoBehaviour
{
	private bool KBIAJMBBGJG;

	[FormerlySerializedAs("AEJILHEIDHP")]
	public Action<bool> PBFFPFBDEBM;

	[FormerlySerializedAs("DMFOHLEABDK")]
	public GameObject CKIPHOLOHLK;

	[FormerlySerializedAs("EAINCIGGBGJ")]
	public Vector3 NNGMEGGKPPL;

	private Vector3 ACMGFFCGAEE = new Vector3(0f, 0f, 0f);

	[FormerlySerializedAs("BIPMDAILIMH")]
	public float PNAICLCIHKB = 0.3f;

	[FormerlySerializedAs("JHPPEFDAAKM")]
	public Color EKKJCIBIOII;

	[FormerlySerializedAs("DEHDHKHEANF")]
	public Color BFOEJFCLOAG;

	[FormerlySerializedAs("GFOKCEANKDG")]
	public GameObject OIHDDKGHAMD;

	[FormerlySerializedAs("HELHCOGEEPD")]
	public GameObject PGIBDMBINKI;

	public bool IsOn
	{
		get
		{
			return KBIAJMBBGJG;
		}
		set
		{
			if (KBIAJMBBGJG != value)
			{
				KBIAJMBBGJG = value;
				CKIPHOLOHLK.transform.localPosition = ((!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
				TweenPosition.Begin(CKIPHOLOHLK.gameObject, 0f, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
				if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
				{
					TweenColor.Begin(OIHDDKGHAMD, 0f, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
					TweenColor.Begin(PGIBDMBINKI, 0f, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
				}
			}
		}
	}

	private void LMHHNOKFHKP()
	{
		CKIPHOLOHLK.transform.localPosition = ((!HEPOKPKOFNF()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1138f, (!FJCJIOJGELH()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1292f, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void IKGFFMLLNJH()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!NGECHGNDLMJ()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = (UITweener.Method)6;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(EKMGFNIMKND());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!JGONOFABIKL()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, JLAKJOKAKHK() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool NGECHGNDLMJ()
	{
		return KBIAJMBBGJG;
	}

	[SpecialName]
	public bool JGONOFABIKL()
	{
		return KBIAJMBBGJG;
	}

	[SpecialName]
	public void MCOPEIPICDH(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!NMNJOPFIBCO()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 329f, (!JGONOFABIKL()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 746f, (!JGONOFABIKL()) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 173f, JLAKJOKAKHK() ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}

	private void BDCKIKFECEH()
	{
		CKIPHOLOHLK.transform.localPosition = ((!DDENGJAGFEP()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 99f, (!NGECHGNDLMJ()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1956f, EKMGFNIMKND() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void APHACDKGNBA()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!NMNJOPFIBCO()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(IsOn);
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!NGECHGNDLMJ()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, DDENGJAGFEP() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool JLAKJOKAKHK()
	{
		return KBIAJMBBGJG;
	}

	private void KBFDJCEIHIB()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = (UITweener.Method)7;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(NMNJOPFIBCO());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!EKMGFNIMKND()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, NGECHGNDLMJ() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void EPDMKNCAFMM()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!JGONOFABIKL()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		tweenPosition.method = UITweener.Method.EaseInOut;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(FJCJIOJGELH());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!FJCJIOJGELH()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, CJFOLFNNDBH() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool NMNJOPFIBCO()
	{
		return KBIAJMBBGJG;
	}

	[SpecialName]
	public bool CJFOLFNNDBH()
	{
		return KBIAJMBBGJG;
	}

	private void ODAKCFDIDBM()
	{
		CKIPHOLOHLK.transform.localPosition = ((!EKMGFNIMKND()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 158f, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 411f, FJCJIOJGELH() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public void KOBOBOPIAEO(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!FJCJIOJGELH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 1055f, (!NGECHGNDLMJ()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 775f, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 1058f, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}

	private void JIJKJCHMKAM()
	{
		CKIPHOLOHLK.transform.localPosition = ((!CJFOLFNNDBH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1306f, (!CJFOLFNNDBH()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1836f, CJFOLFNNDBH() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool FJCJIOJGELH()
	{
		return KBIAJMBBGJG;
	}

	private void IMHMNDMOFMH()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!FJCJIOJGELH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		tweenPosition.method = (UITweener.Method)6;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(NMNJOPFIBCO());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!JLAKJOKAKHK()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void DIMBEKPBCND()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!JGONOFABIKL()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = UITweener.Method.EaseInOut;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(IsOn);
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, NGECHGNDLMJ() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void OnClick()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
		tweenPosition.method = UITweener.Method.EaseInOut;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(IsOn);
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool EKMGFNIMKND()
	{
		return KBIAJMBBGJG;
	}

	[SpecialName]
	public void BMJFFFHPAJE(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!HEPOKPKOFNF()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 1697f, (!EKMGFNIMKND()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 84f, (!CJFOLFNNDBH()) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 798f, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}

	private void EKGPLBEGCJI()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!FJCJIOJGELH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		tweenPosition.method = UITweener.Method.BounceIn;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(EKMGFNIMKND());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!HEPOKPKOFNF()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, JLAKJOKAKHK() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void DAPFGNMPCOK()
	{
		CKIPHOLOHLK.transform.localPosition = ((!NMNJOPFIBCO()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1411f, (!NMNJOPFIBCO()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1580f, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void DCMNJKEPDJO()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = (UITweener.Method)7;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(HEPOKPKOFNF());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!CJFOLFNNDBH()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, NMNJOPFIBCO() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void FJMLAMGABPE()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!NGECHGNDLMJ()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = UITweener.Method.BounceOut;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(EKMGFNIMKND());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void EFADFEJNAEE()
	{
		CKIPHOLOHLK.transform.localPosition = ((!NGECHGNDLMJ()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1798f, (!JGONOFABIKL()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1562f, NMNJOPFIBCO() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public void ELKHMEGEGII(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!JGONOFABIKL()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 1378f, (!NGECHGNDLMJ()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 490f, (!NMNJOPFIBCO()) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 810f, NMNJOPFIBCO() ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}

	[SpecialName]
	public void IONFPMLIAJM(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!CJFOLFNNDBH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 720f, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 1925f, (!CJFOLFNNDBH()) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 995f, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}

	private void PPEPFMPOELJ()
	{
		CKIPHOLOHLK.transform.localPosition = ((!FJCJIOJGELH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1058f, (!HEPOKPKOFNF()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 164f, JGONOFABIKL() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void JACKKLFHDME()
	{
		CKIPHOLOHLK.transform.localPosition = ((!JLAKJOKAKHK()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1127f, (!NGECHGNDLMJ()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1908f, NGECHGNDLMJ() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool DDENGJAGFEP()
	{
		return KBIAJMBBGJG;
	}

	private void MMDBGFLAPDH()
	{
		CKIPHOLOHLK.transform.localPosition = ((!CJFOLFNNDBH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 652f, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 790f, EKMGFNIMKND() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void ADALENIJNHD()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!NGECHGNDLMJ()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = (UITweener.Method)7;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(NGECHGNDLMJ());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!JLAKJOKAKHK()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, JLAKJOKAKHK() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void ONOJEGPPJOI()
	{
		KBIAJMBBGJG = KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!DDENGJAGFEP()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = (UITweener.Method)7;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(JGONOFABIKL());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!NGECHGNDLMJ()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, JGONOFABIKL() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void OnEnable()
	{
		CKIPHOLOHLK.transform.localPosition = ((!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 0f, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 0f, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void OJPECELKONI()
	{
		CKIPHOLOHLK.transform.localPosition = ((!JLAKJOKAKHK()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1644f, (!NMNJOPFIBCO()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 793f, JGONOFABIKL() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void JPKFJPGFKCC()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
		tweenPosition.method = (UITweener.Method)6;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(DDENGJAGFEP());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!NMNJOPFIBCO()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, JLAKJOKAKHK() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void OAHBEJNNNAB()
	{
		CKIPHOLOHLK.transform.localPosition = ((!JLAKJOKAKHK()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 939f, (!JLAKJOKAKHK()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 584f, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void MIAJBBEHEJL()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(IsOn);
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!JLAKJOKAKHK()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public bool HEPOKPKOFNF()
	{
		return KBIAJMBBGJG;
	}

	private void FJJCAHHMNNH()
	{
		CKIPHOLOHLK.transform.localPosition = ((!JLAKJOKAKHK()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 842f, (!HEPOKPKOFNF()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 873f, EKMGFNIMKND() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void PFCJAOHOAME()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!JLAKJOKAKHK()) ? ACMGFFCGAEE : NNGMEGGKPPL);
		tweenPosition.method = (UITweener.Method)7;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(FJCJIOJGELH());
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!FJCJIOJGELH()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, DDENGJAGFEP() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void IBMEDEPBOAK()
	{
		CKIPHOLOHLK.transform.localPosition = ((!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, 1148f, (!NMNJOPFIBCO()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, 1395f, FJCJIOJGELH() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	private void NMJJKMIOFHJ()
	{
		KBIAJMBBGJG = !KBIAJMBBGJG;
		TweenPosition tweenPosition = TweenPosition.Begin(CKIPHOLOHLK.gameObject, PNAICLCIHKB, (!NMNJOPFIBCO()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		if (PBFFPFBDEBM != null)
		{
			PBFFPFBDEBM(IsOn);
		}
		if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
		{
			TweenColor.Begin(OIHDDKGHAMD, PNAICLCIHKB, (!DDENGJAGFEP()) ? BFOEJFCLOAG : EKKJCIBIOII);
			TweenColor.Begin(PGIBDMBINKI, PNAICLCIHKB, CJFOLFNNDBH() ? BFOEJFCLOAG : EKKJCIBIOII);
		}
	}

	[SpecialName]
	public void OIMAKMLJAKN(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!FJCJIOJGELH()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 872f, (!DDENGJAGFEP()) ? ACMGFFCGAEE : NNGMEGGKPPL);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 1120f, (!JGONOFABIKL()) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 1191f, HEPOKPKOFNF() ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}

	[SpecialName]
	public void EHIELIGLIEM(bool IDEBKDPMPGM)
	{
		if (KBIAJMBBGJG != IDEBKDPMPGM)
		{
			KBIAJMBBGJG = IDEBKDPMPGM;
			CKIPHOLOHLK.transform.localPosition = ((!IsOn) ? ACMGFFCGAEE : NNGMEGGKPPL);
			TweenPosition.Begin(CKIPHOLOHLK.gameObject, 1928f, (!EKMGFNIMKND()) ? ACMGFFCGAEE : NNGMEGGKPPL, useLocal: false);
			if (OIHDDKGHAMD != null && PGIBDMBINKI != null)
			{
				TweenColor.Begin(OIHDDKGHAMD, 1587f, (!IsOn) ? BFOEJFCLOAG : EKKJCIBIOII);
				TweenColor.Begin(PGIBDMBINKI, 1446f, IsOn ? BFOEJFCLOAG : EKKJCIBIOII);
			}
		}
	}
}
