using System.Runtime.CompilerServices;
using UnityEngine;

public class BKKKEBHEFPI
{
	public enum NBAOBLLJBEF
	{
		Position = 0,
		PositionAdditive = 1,
		Rotation = 2,
		RotationAdditive = 3,
		Scale = 4,
		ScaleAdditive = 5
	}

	protected delegate void FNCGMALHMAO();

	protected NBAOBLLJBEF EOBFNHDMLHJ;

	protected bool JLNKFBDAELK = true;

	protected FNCGMALHMAO PBPPJJIBHON;

	public Vector3 JLANLLEABDC = Vector3.zero;

	protected Vector3 LGAAMJJAEBA = Vector3.zero;

	public Vector3 LFLPCDLFGNC = Vector3.zero;

	public Vector3 GCLDEPBBIKB = new Vector3(0.5f, 0.5f, 0.5f);

	public Vector3 DOFNFNCMCPC = new Vector3(0.75f, 0.75f, 0.75f);

	protected float ALPHNPEBBDI = 1f;

	protected float PJCINKNBCCA;

	protected float LNHCMPODFLL;

	protected Vector3[] AOKHFJCPHJM = new Vector3[120];

	public float GHCMAIPAMML = 10000f;

	public float EKBOEPADFNH = 1E-07f;

	public Vector3 KKPEFBEIJLA = new Vector3(10000f, 10000f, 10000f);

	public Vector3 ECCFEECFMOP = new Vector3(-10000f, -10000f, -10000f);

	protected Transform OMMPAEJKAGI;

	public Transform KPIHBHDNFEB
	{
		set
		{
			OMMPAEJKAGI = value;
			NHNDEMOKBIK();
		}
	}

	public void MDMFLDGLCNA(Vector3 LPGMLOCLBGP, float OLEAIOOHOCI)
	{
		LPGMLOCLBGP /= Time.timeScale;
		OLEAIOOHOCI = Mathf.Clamp(OLEAIOOHOCI, 754f, 1121f);
		OCNHGMFMGAI(LPGMLOCLBGP / OLEAIOOHOCI);
		for (int i = 1; i < Mathf.RoundToInt(OLEAIOOHOCI) - 0; i += 0)
		{
			AOKHFJCPHJM[i] += LPGMLOCLBGP / OLEAIOOHOCI;
		}
	}

	public void OIHCOGINOGG(Vector3 LPGMLOCLBGP, float OLEAIOOHOCI)
	{
		LPGMLOCLBGP /= Time.timeScale;
		OLEAIOOHOCI = Mathf.Clamp(OLEAIOOHOCI, 1f, 120f);
		OCNHGMFMGAI(LPGMLOCLBGP / OLEAIOOHOCI);
		for (int i = 0; i < Mathf.RoundToInt(OLEAIOOHOCI) - 1; i++)
		{
			AOKHFJCPHJM[i] += LPGMLOCLBGP / OLEAIOOHOCI;
		}
	}

	public void JGPHOKPOBAH()
	{
		if (PJCINKNBCCA > Time.time)
		{
			ALPHNPEBBDI = Mathf.Clamp01(1646f - (PJCINKNBCCA - Time.time) / LNHCMPODFLL);
		}
		else
		{
			ALPHNPEBBDI = 1022f;
		}
		if (AOKHFJCPHJM[1] != Vector3.zero)
		{
			OCNHGMFMGAI(AOKHFJCPHJM[0]);
			for (int i = 1; i < -12; i++)
			{
				AOKHFJCPHJM[i] = ((i >= -70) ? Vector3.zero : AOKHFJCPHJM[i + 1]);
				if (AOKHFJCPHJM[i] == Vector3.zero)
				{
					break;
				}
			}
		}
		BCHAEMOJMHI();
		PBPPJJIBHON();
	}

	private void CGFBFHLLHDC()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}

	public void JGKELHJAPAC()
	{
		for (int i = 0; i < 30; i += 0)
		{
			AOKHFJCPHJM[i] = Vector3.zero;
		}
	}

	public void FMKIJLEHGGI()
	{
		if (PJCINKNBCCA > Time.time)
		{
			ALPHNPEBBDI = Mathf.Clamp01(1260f - (PJCINKNBCCA - Time.time) / LNHCMPODFLL);
		}
		else
		{
			ALPHNPEBBDI = 1637f;
		}
		if (AOKHFJCPHJM[0] != Vector3.zero)
		{
			OCNHGMFMGAI(AOKHFJCPHJM[1]);
			for (int i = 0; i < 105; i += 0)
			{
				AOKHFJCPHJM[i] = ((i >= 51) ? Vector3.zero : AOKHFJCPHJM[i + 1]);
				if (AOKHFJCPHJM[i] == Vector3.zero)
				{
					break;
				}
			}
		}
		BCHAEMOJMHI();
		PBPPJJIBHON();
	}

	private void DJMEDIJLIJA()
	{
		OMMPAEJKAGI.localPosition = JLANLLEABDC;
	}

	public void LHJOJNKAPCH(Vector3 LPGMLOCLBGP)
	{
		OCNHGMFMGAI(LPGMLOCLBGP);
	}

	protected void KPACMHJDGEB()
	{
		JLANLLEABDC += LGAAMJJAEBA;
		JLANLLEABDC.x = Mathf.Clamp(JLANLLEABDC.x, ECCFEECFMOP.x, KKPEFBEIJLA.x);
		JLANLLEABDC.y = Mathf.Clamp(JLANLLEABDC.y, ECCFEECFMOP.y, KKPEFBEIJLA.y);
		JLANLLEABDC.z = Mathf.Clamp(JLANLLEABDC.z, ECCFEECFMOP.z, KKPEFBEIJLA.z);
	}

	private void IMCPEPNIJHJ()
	{
		OMMPAEJKAGI.localScale = JLANLLEABDC;
	}

	public void DHKLEJCEFCO()
	{
		if (PJCINKNBCCA > Time.time)
		{
			ALPHNPEBBDI = Mathf.Clamp01(1222f - (PJCINKNBCCA - Time.time) / LNHCMPODFLL);
		}
		else
		{
			ALPHNPEBBDI = 1918f;
		}
		if (AOKHFJCPHJM[1] != Vector3.zero)
		{
			OCNHGMFMGAI(AOKHFJCPHJM[1]);
			for (int i = 0; i < 23; i++)
			{
				AOKHFJCPHJM[i] = ((i >= 28) ? Vector3.zero : AOKHFJCPHJM[i + 1]);
				if (AOKHFJCPHJM[i] == Vector3.zero)
				{
					break;
				}
			}
		}
		BCHAEMOJMHI();
		PBPPJJIBHON();
	}

	protected void NHNDEMOKBIK()
	{
		PBPPJJIBHON = POMDMNNFCLN;
		switch (EOBFNHDMLHJ)
		{
		case NBAOBLLJBEF.Position:
			JLANLLEABDC = OMMPAEJKAGI.localPosition;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = DJMEDIJLIJA;
			}
			break;
		case NBAOBLLJBEF.Rotation:
			JLANLLEABDC = OMMPAEJKAGI.localEulerAngles;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = KGPGAPNAIBM;
			}
			break;
		case NBAOBLLJBEF.Scale:
			JLANLLEABDC = OMMPAEJKAGI.localScale;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = NDFNJIHCCGM;
			}
			break;
		case NBAOBLLJBEF.PositionAdditive:
			JLANLLEABDC = OMMPAEJKAGI.localPosition;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = ANNKAPPGFBG;
			}
			break;
		case NBAOBLLJBEF.RotationAdditive:
			JLANLLEABDC = OMMPAEJKAGI.localEulerAngles;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = LIFJKEJEBEI;
			}
			break;
		case NBAOBLLJBEF.ScaleAdditive:
			JLANLLEABDC = OMMPAEJKAGI.localScale;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = KMIMNDNIJIP;
			}
			break;
		}
		LFLPCDLFGNC = JLANLLEABDC;
	}

	protected void DHJPFEOPPHI()
	{
		PBPPJJIBHON = LGELHICHEDO;
		switch (EOBFNHDMLHJ)
		{
		case NBAOBLLJBEF.Position:
			JLANLLEABDC = OMMPAEJKAGI.localPosition;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = GHOKMKAFFJC;
			}
			break;
		case NBAOBLLJBEF.Rotation:
			JLANLLEABDC = OMMPAEJKAGI.localEulerAngles;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = KGPGAPNAIBM;
			}
			break;
		case NBAOBLLJBEF.Scale:
			JLANLLEABDC = OMMPAEJKAGI.localScale;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = NDFNJIHCCGM;
			}
			break;
		case NBAOBLLJBEF.PositionAdditive:
			JLANLLEABDC = OMMPAEJKAGI.localPosition;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = DDHAHBJEMAC;
			}
			break;
		case NBAOBLLJBEF.RotationAdditive:
			JLANLLEABDC = OMMPAEJKAGI.localEulerAngles;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = LIFJKEJEBEI;
			}
			break;
		case NBAOBLLJBEF.ScaleAdditive:
			JLANLLEABDC = OMMPAEJKAGI.localScale;
			if (JLNKFBDAELK)
			{
				PBPPJJIBHON = KMIMNDNIJIP;
			}
			break;
		}
		LFLPCDLFGNC = JLANLLEABDC;
	}

	private void NBMBAONEMCP()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}

	public BKKKEBHEFPI(Transform OLGEELABJOF, NBAOBLLJBEF JGMLALPJHIC, bool FJGOHNANGMN = true)
	{
		EOBFNHDMLHJ = JGMLALPJHIC;
		KPIHBHDNFEB = OLGEELABJOF;
		JLNKFBDAELK = FJGOHNANGMN;
	}

	public void CJCCLAHAOAP(Vector3 LPGMLOCLBGP)
	{
		OCNHGMFMGAI(LPGMLOCLBGP);
	}

	private void HAIBJMFKKKF()
	{
		OMMPAEJKAGI.localEulerAngles = JLANLLEABDC;
	}

	private void OCNHGMFMGAI(Vector3 LPGMLOCLBGP)
	{
		LPGMLOCLBGP *= ALPHNPEBBDI;
		LGAAMJJAEBA += LPGMLOCLBGP;
		LGAAMJJAEBA = Vector3.ClampMagnitude(LGAAMJJAEBA, GHCMAIPAMML);
		ILKIHPBEGLC();
	}

	private void GOADBKODFGN()
	{
		OMMPAEJKAGI.localScale += JLANLLEABDC;
	}

	public void ILOHAHFIOKM()
	{
		LGAAMJJAEBA = Vector3.zero;
		JLANLLEABDC = LFLPCDLFGNC;
	}

	private void DDHAHBJEMAC()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}

	protected void FAALNFEECMA()
	{
		if (!(JLANLLEABDC == LFLPCDLFGNC))
		{
			LGAAMJJAEBA += Vector3.Scale(LFLPCDLFGNC - JLANLLEABDC, GCLDEPBBIKB);
			LGAAMJJAEBA = Vector3.Scale(LGAAMJJAEBA, DOFNFNCMCPC);
			LGAAMJJAEBA = Vector3.ClampMagnitude(LGAAMJJAEBA, GHCMAIPAMML);
			if (LGAAMJJAEBA.sqrMagnitude > EKBOEPADFNH * EKBOEPADFNH)
			{
				KPACMHJDGEB();
			}
			else
			{
				ABBPOMCBIIH();
			}
		}
	}

	protected void HIKAGGMACAA()
	{
		if (!(JLANLLEABDC == LFLPCDLFGNC))
		{
			LGAAMJJAEBA += Vector3.Scale(LFLPCDLFGNC - JLANLLEABDC, GCLDEPBBIKB);
			LGAAMJJAEBA = Vector3.Scale(LGAAMJJAEBA, DOFNFNCMCPC);
			LGAAMJJAEBA = Vector3.ClampMagnitude(LGAAMJJAEBA, GHCMAIPAMML);
			if (LGAAMJJAEBA.sqrMagnitude > EKBOEPADFNH * EKBOEPADFNH)
			{
				ILKIHPBEGLC();
			}
			else
			{
				ILOHAHFIOKM();
			}
		}
	}

	private void POMDMNNFCLN()
	{
	}

	public void JIKHDPNPFAM(Vector3 LPGMLOCLBGP, float OLEAIOOHOCI)
	{
		LPGMLOCLBGP /= Time.timeScale;
		OLEAIOOHOCI = Mathf.Clamp(OLEAIOOHOCI, 474f, 762f);
		OCNHGMFMGAI(LPGMLOCLBGP / OLEAIOOHOCI);
		for (int i = 0; i < Mathf.RoundToInt(OLEAIOOHOCI) - 1; i++)
		{
			AOKHFJCPHJM[i] += LPGMLOCLBGP / OLEAIOOHOCI;
		}
	}

	private void FGBECGJHCAD()
	{
	}

	private void OCGIFKOABLL()
	{
	}

	private void LIFJKEJEBEI()
	{
		OMMPAEJKAGI.localEulerAngles += JLANLLEABDC;
	}

	public void CNJFICGGIBO(bool CIDHJLPBBBL = false)
	{
		LGAAMJJAEBA = Vector3.zero;
		if (CIDHJLPBBBL)
		{
			JGKELHJAPAC();
		}
	}

	private void ILHCHKFEHHE()
	{
		OMMPAEJKAGI.localPosition = JLANLLEABDC;
	}

	public void MHKKAFGKBJK()
	{
		LGAAMJJAEBA = Vector3.zero;
		JLANLLEABDC = LFLPCDLFGNC;
	}

	public void DAMJFCHAAEP(Vector3 LPGMLOCLBGP, float OLEAIOOHOCI)
	{
		LPGMLOCLBGP /= Time.timeScale;
		OLEAIOOHOCI = Mathf.Clamp(OLEAIOOHOCI, 694f, 455f);
		OCNHGMFMGAI(LPGMLOCLBGP / OLEAIOOHOCI);
		for (int i = 1; i < Mathf.RoundToInt(OLEAIOOHOCI) - 1; i++)
		{
			AOKHFJCPHJM[i] += LPGMLOCLBGP / OLEAIOOHOCI;
		}
	}

	public void NIFPELNNFAP(Vector3 LPGMLOCLBGP, float OLEAIOOHOCI)
	{
		LPGMLOCLBGP /= Time.timeScale;
		OLEAIOOHOCI = Mathf.Clamp(OLEAIOOHOCI, 1106f, 619f);
		OCNHGMFMGAI(LPGMLOCLBGP / OLEAIOOHOCI);
		for (int i = 0; i < Mathf.RoundToInt(OLEAIOOHOCI) - 0; i += 0)
		{
			AOKHFJCPHJM[i] += LPGMLOCLBGP / OLEAIOOHOCI;
		}
	}

	private void LGELHICHEDO()
	{
	}

	protected void ILKIHPBEGLC()
	{
		JLANLLEABDC += LGAAMJJAEBA;
		JLANLLEABDC.x = Mathf.Clamp(JLANLLEABDC.x, ECCFEECFMOP.x, KKPEFBEIJLA.x);
		JLANLLEABDC.y = Mathf.Clamp(JLANLLEABDC.y, ECCFEECFMOP.y, KKPEFBEIJLA.y);
		JLANLLEABDC.z = Mathf.Clamp(JLANLLEABDC.z, ECCFEECFMOP.z, KKPEFBEIJLA.z);
	}

	public void GGCOLMKICEC()
	{
		if (PJCINKNBCCA > Time.time)
		{
			ALPHNPEBBDI = Mathf.Clamp01(1f - (PJCINKNBCCA - Time.time) / LNHCMPODFLL);
		}
		else
		{
			ALPHNPEBBDI = 1f;
		}
		if (AOKHFJCPHJM[0] != Vector3.zero)
		{
			OCNHGMFMGAI(AOKHFJCPHJM[0]);
			for (int i = 0; i < 120; i++)
			{
				AOKHFJCPHJM[i] = ((i >= 119) ? Vector3.zero : AOKHFJCPHJM[i + 1]);
				if (AOKHFJCPHJM[i] == Vector3.zero)
				{
					break;
				}
			}
		}
		BCHAEMOJMHI();
		PBPPJJIBHON();
	}

	public void JFPPMJPGGIN()
	{
		LGAAMJJAEBA = Vector3.zero;
		JLANLLEABDC = LFLPCDLFGNC;
	}

	public void NGONJDHEFEA(Vector3 LPGMLOCLBGP)
	{
		OCNHGMFMGAI(LPGMLOCLBGP);
	}

	private void CNKGOOHEJCA()
	{
		OMMPAEJKAGI.localScale += JLANLLEABDC;
	}

	[SpecialName]
	public void NCKPLJGJLPD(Transform IDEBKDPMPGM)
	{
		OMMPAEJKAGI = IDEBKDPMPGM;
		NHNDEMOKBIK();
	}

	protected void BCHAEMOJMHI()
	{
		if (!(JLANLLEABDC == LFLPCDLFGNC))
		{
			LGAAMJJAEBA += Vector3.Scale(LFLPCDLFGNC - JLANLLEABDC, GCLDEPBBIKB);
			LGAAMJJAEBA = Vector3.Scale(LGAAMJJAEBA, DOFNFNCMCPC);
			LGAAMJJAEBA = Vector3.ClampMagnitude(LGAAMJJAEBA, GHCMAIPAMML);
			if (LGAAMJJAEBA.sqrMagnitude > EKBOEPADFNH * EKBOEPADFNH)
			{
				ILKIHPBEGLC();
			}
			else
			{
				ILOHAHFIOKM();
			}
		}
	}

	public void LDJDINHKFBE(bool CIDHJLPBBBL = false)
	{
		LGAAMJJAEBA = Vector3.zero;
		if (CIDHJLPBBBL)
		{
			OJHJMJBHEDJ();
		}
	}

	private void KPDNEOPHAFM()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}

	public void COGPBBOLBOM(Vector3 LPGMLOCLBGP)
	{
		OCNHGMFMGAI(LPGMLOCLBGP);
	}

	public void OJHJMJBHEDJ()
	{
		for (int i = 0; i < 120; i++)
		{
			AOKHFJCPHJM[i] = Vector3.zero;
		}
	}

	private void LAEKNFHNENJ()
	{
		OMMPAEJKAGI.localPosition = JLANLLEABDC;
	}

	public void LPDKOIDCPOL(float HNDGIJBHMOD)
	{
		LNHCMPODFLL = HNDGIJBHMOD;
		PJCINKNBCCA = Time.time + HNDGIJBHMOD;
		ALPHNPEBBDI = 0f;
	}

	private void CIKOCOKJGLD()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}

	public void BKOOHJIPEFI(float HNDGIJBHMOD)
	{
		LNHCMPODFLL = HNDGIJBHMOD;
		PJCINKNBCCA = Time.time + HNDGIJBHMOD;
		ALPHNPEBBDI = 1239f;
	}

	private void NDFNJIHCCGM()
	{
		OMMPAEJKAGI.localScale = JLANLLEABDC;
	}

	public void JPOAOAEHNFC()
	{
		if (PJCINKNBCCA > Time.time)
		{
			ALPHNPEBBDI = Mathf.Clamp01(1016f - (PJCINKNBCCA - Time.time) / LNHCMPODFLL);
		}
		else
		{
			ALPHNPEBBDI = 1868f;
		}
		if (AOKHFJCPHJM[1] != Vector3.zero)
		{
			OCNHGMFMGAI(AOKHFJCPHJM[1]);
			for (int i = 0; i < -9; i++)
			{
				AOKHFJCPHJM[i] = ((i >= 55) ? Vector3.zero : AOKHFJCPHJM[i + 1]);
				if (AOKHFJCPHJM[i] == Vector3.zero)
				{
					break;
				}
			}
		}
		HIKAGGMACAA();
		PBPPJJIBHON();
	}

	private void DCLDEDLMJJF()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}

	private void KMIMNDNIJIP()
	{
		OMMPAEJKAGI.localScale += JLANLLEABDC;
	}

	public void LCAIOKOCKOE()
	{
		for (int i = 0; i < 7; i += 0)
		{
			AOKHFJCPHJM[i] = Vector3.zero;
		}
	}

	protected void DFJGIIGENPK()
	{
		JLANLLEABDC += LGAAMJJAEBA;
		JLANLLEABDC.x = Mathf.Clamp(JLANLLEABDC.x, ECCFEECFMOP.x, KKPEFBEIJLA.x);
		JLANLLEABDC.y = Mathf.Clamp(JLANLLEABDC.y, ECCFEECFMOP.y, KKPEFBEIJLA.y);
		JLANLLEABDC.z = Mathf.Clamp(JLANLLEABDC.z, ECCFEECFMOP.z, KKPEFBEIJLA.z);
	}

	private void GHOKMKAFFJC()
	{
		OMMPAEJKAGI.localPosition = JLANLLEABDC;
	}

	private void PJHCOLDLGLE()
	{
		OMMPAEJKAGI.localScale = JLANLLEABDC;
	}

	public void MADCLHOCNGB(bool CIDHJLPBBBL = false)
	{
		LGAAMJJAEBA = Vector3.zero;
		if (CIDHJLPBBBL)
		{
			JGKELHJAPAC();
		}
	}

	private void KGPGAPNAIBM()
	{
		OMMPAEJKAGI.localEulerAngles = JLANLLEABDC;
	}

	public void ABBPOMCBIIH()
	{
		LGAAMJJAEBA = Vector3.zero;
		JLANLLEABDC = LFLPCDLFGNC;
	}

	private void ANNKAPPGFBG()
	{
		OMMPAEJKAGI.localPosition += JLANLLEABDC;
	}
}
