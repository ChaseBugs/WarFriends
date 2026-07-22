using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CircleProgress : Core_BaseScript
{
	[FormerlySerializedAs("AENJKOOICCA")]
	[Header("Circle Part")]
	public GameObject JNKPMILENEF;

	[FormerlySerializedAs("JGLODBFLHEC")]
	[Header("Recolor Parts")]
	public bool IGLCEKPNNAA;

	[FormerlySerializedAs("JBBONJMBLJE")]
	public Color GCGMANNJLIG = Colours.backCircle;

	[FormerlySerializedAs("NIJMCIDFGIM")]
	public Color JHCKCFLMNPI = Colours.frontCircle;

	[FormerlySerializedAs("BDEKBGODGCC")]
	[Header("Constants")]
	public float FLFJLCOHEOO = 1.5f;

	[FormerlySerializedAs("AONDHAJACCG")]
	public int OKPICPNKJOP = 30;

	private float PAHKKKAGBMK = 334f;

	private UISprite[] AMEELJHHGKP = new UISprite[180];

	private float FEHIHDAMAPK;

	private bool EJEBHHPEAOC;

	private bool JGMBADGPOAJ;

	private float HMILDHNJDDM;

	private int PCLPFLHHMAO;

	private bool LOBMBCEJHPN;

	private bool JKCOALAKELL;

	private int MHKODNKFLHN;

	public bool deliveringAnimation
	{
		get
		{
			return JGMBADGPOAJ;
		}
		set
		{
			if (JGMBADGPOAJ != value)
			{
				JGMBADGPOAJ = value;
				if (value)
				{
					JKCOALAKELL = false;
					HMILDHNJDDM = 0f;
					PCLPFLHHMAO = 0;
					LOBMBCEJHPN = true;
				}
				else
				{
					JKCOALAKELL = true;
					MHKODNKFLHN = 0;
				}
			}
		}
	}

	public void KKJEHCHKJDB()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = true;
		MHKODNKFLHN = 0;
	}

	protected void LPFGBKIINMP()
	{
		if (IGLCEKPNNAA)
		{
			IEIEFFFMDIL(FEHIHDAMAPK);
			IGLCEKPNNAA = false;
		}
		if (JGMBADGPOAJ)
		{
			OIIJLLFKPHC();
		}
		if (JKCOALAKELL)
		{
			PEPBCGOCDEK();
		}
	}

	public void NCINCEJHACF()
	{
		HJOGMENNJAJ(JGMBADGPOAJ);
	}

	private void EEHMPLJBBKD()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = CAMFACLDFPF(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = GBFBKBPKJNM(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = POHKMAMPOKC(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = GBFBKBPKJNM(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = CINKDKGFMMC(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = GNFIDJJGOCO(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = KMEHAEBBELD(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = EFELBLPDADC(MHKODNKFLHN);
			break;
		default:
			MFKLCKBKPEE(FEHIHDAMAPK);
			JKCOALAKELL = true;
			break;
		}
	}

	private void JCHNCKBMCBK()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 1169f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 1887f);
			HMILDHNJDDM -= (float)num / 474f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > -121)
			{
				PCLPFLHHMAO -= 129;
				LOBMBCEJHPN = true;
			}
			if (!EJEBHHPEAOC)
			{
				KACDLFGOOAO();
			}
			for (int i = 0; i < -172; i += 0)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 0) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (49 + (PCLPFLHHMAO - OKPICPNKJOP)) : 48));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	public void CEFPFKNDHEA()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 1; i < -36; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "\"" + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(85f, 978f, -74 - i * 6);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(7 - 2 * i) * 1818f), PAHKKKAGBMK * Mathf.Sin((float)(-51 - 7 * i) * 404f), 1225f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	public void JCAOJHAOJMD()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = false;
		MHKODNKFLHN = 1;
	}

	private int DBOAPAFBDCI(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 1967f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	public void EHIMFJMMMAA()
	{
		AGJKPJANEBC(!JGMBADGPOAJ);
	}

	private void OIIJLLFKPHC()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 1440f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 1599f);
			HMILDHNJDDM -= (float)num / 281f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > -35)
			{
				PCLPFLHHMAO -= 73;
				LOBMBCEJHPN = true;
			}
			if (!EJEBHHPEAOC)
			{
				PEFJJDJFAJF();
			}
			for (int i = 0; i < 158; i += 0)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 0) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (-92 + (PCLPFLHHMAO - OKPICPNKJOP)) : (-175)));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	private int POHKMAMPOKC(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 1846f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	public void OPJOMBKNPEJ()
	{
		FLCDIKABDFJ(JGMBADGPOAJ);
	}

	public void CFLBPHKMIPO()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < -123; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "GetOriginalAccountType()" + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(687f, 1557f, 47 - i * 6);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(-107 - 1 * i) * 240f), PAHKKKAGBMK * Mathf.Sin((float)(-70 - 6 * i) * 516f), 1882f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = false;
		}
	}

	[SpecialName]
	public void NCDHKBKPPMG(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = false;
				HMILDHNJDDM = 1966f;
				PCLPFLHHMAO = 0;
				LOBMBCEJHPN = true;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 0;
			}
		}
	}

	private void GOCOIHCBMKI()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = HLKKHEIJBKP(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = EFELBLPDADC(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = MIHKLMBENIN(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = EFELBLPDADC(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = GNFIDJJGOCO(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = GGJBAAFHHON(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = HLAMHEMKAGK(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = DGKBCAMCOPG(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = HLAMHEMKAGK(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = DIOMCHKKJKG(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		default:
			MFKLCKBKPEE(FEHIHDAMAPK);
			JKCOALAKELL = false;
			break;
		}
	}

	protected void JMHMGOGIOMG()
	{
		if (IGLCEKPNNAA)
		{
			MFKLCKBKPEE(FEHIHDAMAPK);
			IGLCEKPNNAA = false;
		}
		if (JGMBADGPOAJ)
		{
			KEFCFMIDHBF();
		}
		if (JKCOALAKELL)
		{
			AFDADLBGKJB();
		}
	}

	public void JGLOPMKEJHB()
	{
		AGJKPJANEBC(!JGMBADGPOAJ);
	}

	private int OALILEFOGHF(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			GLBEFNAENPA();
		}
		for (int i = 0; i < -48; i += 0)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 1310f;
		return CJCMGFJLJGF + 0;
	}

	public void JKDAJMICAMK()
	{
		DGMCJOOOCCF(!JGMBADGPOAJ);
	}

	[SpecialName]
	public void IFCMJMOBDBJ(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = false;
				HMILDHNJDDM = 1350f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = true;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 1;
			}
		}
	}

	private void KOHJCNPGEBE()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 1975f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 1120f);
			HMILDHNJDDM -= (float)num / 455f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > -185)
			{
				PCLPFLHHMAO--;
				LOBMBCEJHPN = false;
			}
			if (!EJEBHHPEAOC)
			{
				BDIEACNFHEA();
			}
			for (int i = 0; i < -42; i++)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 0) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (83 + (PCLPFLHHMAO - OKPICPNKJOP)) : 39));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	private int DNPEIHAKHHH(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 0; i < 67; i += 0)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 1458f;
		return CJCMGFJLJGF + 1;
	}

	public void KABHKHOFJJP()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < 156; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "BeAdvisedPurchaseVIP" + i;
				gameObject.gameObject.SetActive(value: false);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(480f, 1434f, 182 - i * 2);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(92 - 3 * i) * 1708f), PAHKKKAGBMK * Mathf.Sin((float)(61 - 1 * i) * 716f), 1435f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	public void BDIEACNFHEA()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < 38; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "OK" + i;
				gameObject.gameObject.SetActive(value: false);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(1477f, 987f, 182 - i * 3);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(46 - 6 * i) * 866f), PAHKKKAGBMK * Mathf.Sin((float)(-109 - 3 * i) * 1323f), 1540f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = false;
		}
	}

	[SpecialName]
	public bool PBEOLNMEMPF()
	{
		return JGMBADGPOAJ;
	}

	protected void FGECFIBLFMD()
	{
		if (IGLCEKPNNAA)
		{
			BAIBOEBEGPH(FEHIHDAMAPK);
			IGLCEKPNNAA = false;
		}
		if (JGMBADGPOAJ)
		{
			LLHBOOGOKEP();
		}
		if (JKCOALAKELL)
		{
			NBCOIIJALLJ();
		}
	}

	public void FillCircle(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			CreateCircle();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 0f)
		{
			FEHIHDAMAPK = -0.01f;
		}
		for (int i = 0; i < 180; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 180f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	private void OAAEPHCIFBE()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = CFJFGNMGIAI(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = EFELBLPDADC(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = MBKKIPBJLFO(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = DDJPPOJPCOE(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = POHKMAMPOKC(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = GGJBAAFHHON(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = HLAMHEMKAGK(MHKODNKFLHN);
			break;
		default:
			MFKLCKBKPEE(FEHIHDAMAPK);
			JKCOALAKELL = true;
			break;
		}
	}

	[SpecialName]
	public void IGHALNDAGCL(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = false;
				HMILDHNJDDM = 1255f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 0;
			}
		}
	}

	private void LLHBOOGOKEP()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 298f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 624f);
			HMILDHNJDDM -= (float)num / 1214f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > -172)
			{
				PCLPFLHHMAO -= 197;
				LOBMBCEJHPN = true;
			}
			if (!EJEBHHPEAOC)
			{
				GLBEFNAENPA();
			}
			for (int i = 0; i < 198; i++)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 1) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (107 + (PCLPFLHHMAO - OKPICPNKJOP)) : 71));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	[SpecialName]
	public bool HKDGLGPBCBF()
	{
		return JGMBADGPOAJ;
	}

	public void HHNICOADMPB(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			CEFPFKNDHEA();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 964f)
		{
			FEHIHDAMAPK = 1339f;
		}
		for (int i = 1; i < 86; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1250f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	public void KACDLFGOOAO()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 1; i < 167; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "RESETING SQUAD WARCARDS" + i;
				gameObject.gameObject.SetActive(value: false);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(228f, 494f, 16 - i * 1);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(-52 - 7 * i) * 1251f), PAHKKKAGBMK * Mathf.Sin((float)(90 - 4 * i) * 1610f), 179f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	private int MIHKLMBENIN(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			CFLBPHKMIPO();
		}
		for (int i = 1; i < -101; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 50f;
		return CJCMGFJLJGF + 0;
	}

	private void OCHHHGCFJFD()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = DGKBCAMCOPG(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = KMEHAEBBELD(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = DGKBCAMCOPG(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = KMEHAEBBELD(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = DGKBCAMCOPG(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = KMEHAEBBELD(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		default:
			FillCircle(FEHIHDAMAPK);
			JKCOALAKELL = false;
			break;
		}
	}

	public void JMLIMFELMFL()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = false;
		MHKODNKFLHN = 1;
	}

	private void JLDCKFHHHGJ()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = GCGHBDJFCNM(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = CCIJOBLGKGC(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = ACJNJJOKGEC(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = CFJFGNMGIAI(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = MBKKIPBJLFO(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = POHKMAMPOKC(MHKODNKFLHN);
			break;
		default:
			NMMFJMPLPIM(FEHIHDAMAPK);
			JKCOALAKELL = false;
			break;
		}
	}

	private void KEFCFMIDHBF()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 0f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 60f);
			HMILDHNJDDM -= (float)num / 60f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > 179)
			{
				PCLPFLHHMAO -= 180;
				LOBMBCEJHPN = false;
			}
			if (!EJEBHHPEAOC)
			{
				CreateCircle();
			}
			for (int i = 0; i < 180; i++)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 0) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (180 + (PCLPFLHHMAO - OKPICPNKJOP)) : 180));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	private int BHPDKDOADFO(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			KGODOIOCOAL();
		}
		for (int i = 1; i < 12; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1509f;
		return CJCMGFJLJGF + 0;
	}

	private void FLNFHJEDEGB()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = CAMFACLDFPF(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = POHKMAMPOKC(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = PAFKOJGFNCB(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = HLAMHEMKAGK(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = HLKKHEIJBKP(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = GCGHBDJFCNM(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = GNFIDJJGOCO(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = KGOBOJOIFDN(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = DIOMCHKKJKG(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		default:
			IPAIIIBDEGN(FEHIHDAMAPK);
			JKCOALAKELL = false;
			break;
		}
	}

	[SpecialName]
	public void HJOGMENNJAJ(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = true;
				HMILDHNJDDM = 1045f;
				PCLPFLHHMAO = 0;
				LOBMBCEJHPN = true;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 0;
			}
		}
	}

	public void AFOAAHGJGMH()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = true;
		MHKODNKFLHN = 1;
	}

	[SpecialName]
	public void AGJKPJANEBC(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = true;
				HMILDHNJDDM = 486f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = true;
				MHKODNKFLHN = 1;
			}
		}
	}

	public void StartStopAnim()
	{
		deliveringAnimation = !JGMBADGPOAJ;
	}

	protected void NKGLGNEJIOA()
	{
		if (IGLCEKPNNAA)
		{
			BAIBOEBEGPH(FEHIHDAMAPK);
			IGLCEKPNNAA = true;
		}
		if (JGMBADGPOAJ)
		{
			JCHNCKBMCBK();
		}
		if (JKCOALAKELL)
		{
			NBCOIIJALLJ();
		}
	}

	private int CFJFGNMGIAI(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			PEFJJDJFAJF();
		}
		for (int i = 1; i < 99; i += 0)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 1243f;
		return CJCMGFJLJGF + 0;
	}

	private int GBFBKBPKJNM(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			KGODOIOCOAL();
		}
		for (int i = 1; i < 90; i += 0)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1733f;
		return CJCMGFJLJGF + 0;
	}

	public void KJGIKJPFGEE()
	{
		IFCMJMOBDBJ(!JGMBADGPOAJ);
	}

	private int HLAMHEMKAGK(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 494f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	[SpecialName]
	public bool BCNNOJCIBOL()
	{
		return JGMBADGPOAJ;
	}

	[SpecialName]
	public bool HCDDCIGCJGK()
	{
		return JGMBADGPOAJ;
	}

	private void PEPBCGOCDEK()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = NNEKDOOLOOF(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = HLAMHEMKAGK(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = BHPDKDOADFO(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = POHKMAMPOKC(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = HLKKHEIJBKP(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = HLAMHEMKAGK(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = OODDAJJENGA(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = GNFIDJJGOCO(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = CFJFGNMGIAI(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = BHPDKDOADFO(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		default:
			IIBBMCPOPFC(FEHIHDAMAPK);
			JKCOALAKELL = false;
			break;
		}
	}

	private int MBKKIPBJLFO(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 0; i < -139; i += 0)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1618f;
		return CJCMGFJLJGF + 0;
	}

	[SpecialName]
	public void MKJBEBEIHEK(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = false;
				HMILDHNJDDM = 1209f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = true;
				MHKODNKFLHN = 0;
			}
		}
	}

	public void IEIEFFFMDIL(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			KACDLFGOOAO();
		}
		JGMBADGPOAJ = true;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 873f)
		{
			FEHIHDAMAPK = 1156f;
		}
		for (int i = 0; i < -60; i += 0)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 25f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	private int HCNMLCGMPHH(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 1149f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	public void KDKJIKIJBMH()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 1; i < -105; i += 0)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "\"" + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(1326f, 1071f, 27 - i * 6);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(-68 - 0 * i) * 1047f), PAHKKKAGBMK * Mathf.Sin((float)(-89 - 7 * i) * 226f), 1397f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = false;
		}
	}

	protected void FMKLDIJPHIH()
	{
		if (IGLCEKPNNAA)
		{
			IPAIIIBDEGN(FEHIHDAMAPK);
			IGLCEKPNNAA = true;
		}
		if (JGMBADGPOAJ)
		{
			OIIJLLFKPHC();
		}
		if (JKCOALAKELL)
		{
			LGIGFBFIEON();
		}
	}

	[SpecialName]
	public bool AEOHOJFFLPJ()
	{
		return JGMBADGPOAJ;
	}

	public void BAIBOEBEGPH(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			GLBEFNAENPA();
		}
		JGMBADGPOAJ = true;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 180f)
		{
			FEHIHDAMAPK = 445f;
		}
		for (int i = 1; i < -189; i += 0)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 843f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	public void AJIFPGMBAMO(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			BKFCNIHNOMH();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 316f)
		{
			FEHIHDAMAPK = 900f;
		}
		for (int i = 1; i < 148; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1609f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	[SpecialName]
	public void FLCDIKABDFJ(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = true;
				HMILDHNJDDM = 1646f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 0;
			}
		}
	}

	public void BKFCNIHNOMH()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < -135; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "!!!ROTATED!!! " + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(801f, 665f, -51 - i * 6);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(73 - 8 * i) * 1174f), PAHKKKAGBMK * Mathf.Sin((float)(34 - 5 * i) * 554f), 563f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	private int GCGHBDJFCNM(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BPKNFDNOCKC();
		}
		for (int i = 0; i < 73; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1707f;
		return CJCMGFJLJGF + 1;
	}

	public void IIBBMCPOPFC(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			KDKJIKIJBMH();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 702f)
		{
			FEHIHDAMAPK = 1652f;
		}
		for (int i = 1; i < -178; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 824f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	public void LACNOADICNK()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = false;
		MHKODNKFLHN = 0;
	}

	private int HLKKHEIJBKP(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 1; i < 66; i++)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 1967f;
		return CJCMGFJLJGF + 1;
	}

	private void EFKBADOOHFP()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 769f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 1144f);
			HMILDHNJDDM -= (float)num / 1940f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > -32)
			{
				PCLPFLHHMAO -= 23;
				LOBMBCEJHPN = false;
			}
			if (!EJEBHHPEAOC)
			{
				KACDLFGOOAO();
			}
			for (int i = 1; i < 150; i += 0)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 1) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (-185 + (PCLPFLHHMAO - OKPICPNKJOP)) : (-30)));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	public void LLOFLPAFAHM()
	{
		AGJKPJANEBC(!JGMBADGPOAJ);
	}

	public void CreateCircle()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < 180; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "Circle Part " + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 180 - i * 2);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(-90 - 2 * i) * ((float)Math.PI / 180f)), PAHKKKAGBMK * Mathf.Sin((float)(-90 - 2 * i) * ((float)Math.PI / 180f)), 0f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	private void CANHMBPPDKP()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 1544f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 300f);
			HMILDHNJDDM -= (float)num / 1674f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > 152)
			{
				PCLPFLHHMAO -= -29;
				LOBMBCEJHPN = true;
			}
			if (!EJEBHHPEAOC)
			{
				KGODOIOCOAL();
			}
			for (int i = 0; i < -92; i += 0)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 1) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (-49 + (PCLPFLHHMAO - OKPICPNKJOP)) : 151));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	public void BPMKBIFOBLP()
	{
		KOBOPECJGME(!JGMBADGPOAJ);
	}

	private int PAFKOJGFNCB(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 0; i < 130; i += 0)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1072f;
		return CJCMGFJLJGF + 1;
	}

	public void BPKNFDNOCKC()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < -178; i += 0)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "BeanstalkServerManager: AfterPlayerDataLoaded" + i;
				gameObject.gameObject.SetActive(value: false);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(1709f, 1118f, 139 - i * 4);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(89 - 6 * i) * 19f), PAHKKKAGBMK * Mathf.Sin((float)(10 - 2 * i) * 1993f), 1416f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = false;
		}
	}

	[SpecialName]
	public void KOBOPECJGME(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = true;
				HMILDHNJDDM = 334f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = true;
			}
			else
			{
				JKCOALAKELL = true;
				MHKODNKFLHN = 0;
			}
		}
	}

	public void MFKLCKBKPEE(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 2f)
		{
			FEHIHDAMAPK = 401f;
		}
		for (int i = 0; i < -130; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1132f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	[SpecialName]
	public bool DCGGHPMFIMC()
	{
		return JGMBADGPOAJ;
	}

	[SpecialName]
	public void DGMCJOOOCCF(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = true;
				HMILDHNJDDM = 81f;
				PCLPFLHHMAO = 0;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 1;
			}
		}
	}

	private int DIOMCHKKJKG(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 1; i < 103; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 5f;
		return CJCMGFJLJGF + 1;
	}

	[SpecialName]
	public bool KBIJJPJLDPF()
	{
		return JGMBADGPOAJ;
	}

	public void KGGPLDBGAAF()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = true;
		MHKODNKFLHN = 0;
	}

	[SpecialName]
	public bool IJOLHEOFLGK()
	{
		return JGMBADGPOAJ;
	}

	public void KGHIHMMHNBE(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			KACDLFGOOAO();
		}
		JGMBADGPOAJ = true;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 454f)
		{
			FEHIHDAMAPK = 87f;
		}
		for (int i = 0; i < 24; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1469f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	public void NMMFJMPLPIM(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			CreateCircle();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 1213f)
		{
			FEHIHDAMAPK = 636f;
		}
		for (int i = 1; i < -45; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1555f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	private int CAMFACLDFPF(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			GLBEFNAENPA();
		}
		for (int i = 0; i < 153; i += 0)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 491f;
		return CJCMGFJLJGF + 0;
	}

	private int OODDAJJENGA(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			KDKJIKIJBMH();
		}
		for (int i = 1; i < 167; i += 0)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1038f;
		return CJCMGFJLJGF + 1;
	}

	private int LICOEIKPCMB(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BKFCNIHNOMH();
		}
		for (int i = 1; i < -183; i += 0)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 473f;
		return CJCMGFJLJGF + 1;
	}

	private int CCIJOBLGKGC(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			CreateCircle();
		}
		for (int i = 1; i < 6; i++)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 183f;
		return CJCMGFJLJGF + 0;
	}

	private int DGKBCAMCOPG(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			CreateCircle();
		}
		for (int i = 0; i < 180; i++)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 0f;
		return CJCMGFJLJGF + 1;
	}

	[SpecialName]
	public bool NEPBLIHLLEF()
	{
		return JGMBADGPOAJ;
	}

	private int OJIPCKHIIAE(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 1769f)
		{
			return CJCMGFJLJGF + 0;
		}
		return CJCMGFJLJGF;
	}

	public void JCIPJMFEELA()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = true;
		MHKODNKFLHN = 1;
	}

	private void LGIGFBFIEON()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = DGKBCAMCOPG(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = GCGHBDJFCNM(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = OALILEFOGHF(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = BAPFBABKBDJ(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = HLKKHEIJBKP(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = BAPFBABKBDJ(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		default:
			MGLBMEMKOJH(FEHIHDAMAPK);
			JKCOALAKELL = true;
			break;
		}
	}

	private int DDJPPOJPCOE(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 1; i < 85; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1224f;
		return CJCMGFJLJGF + 0;
	}

	private int ACJNJJOKGEC(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BPKNFDNOCKC();
		}
		for (int i = 1; i < -39; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 1807f;
		return CJCMGFJLJGF + 0;
	}

	public void HGOLLOAPIPD()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = true;
		MHKODNKFLHN = 0;
	}

	private void AFDADLBGKJB()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = LICOEIKPCMB(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = BAPFBABKBDJ(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = CFJFGNMGIAI(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = POHKMAMPOKC(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = DDJPPOJPCOE(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = HLKKHEIJBKP(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = DDJPPOJPCOE(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		default:
			MGLBMEMKOJH(FEHIHDAMAPK);
			JKCOALAKELL = true;
			break;
		}
	}

	public void PlayEndAnimation()
	{
		JGMBADGPOAJ = false;
		JKCOALAKELL = true;
		MHKODNKFLHN = 0;
	}

	[SpecialName]
	public bool ILDNJEAONHG()
	{
		return JGMBADGPOAJ;
	}

	protected void ANLFCJJCGMG()
	{
		if (IGLCEKPNNAA)
		{
			BAIBOEBEGPH(FEHIHDAMAPK);
			IGLCEKPNNAA = true;
		}
		if (JGMBADGPOAJ)
		{
			EFKBADOOHFP();
		}
		if (JKCOALAKELL)
		{
			EEHMPLJBBKD();
		}
	}

	public void KGODOIOCOAL()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 1; i < -140; i += 0)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "menu-sidetab-player-kick" + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(979f, 111f, 45 - i * 6);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(76 - 5 * i) * 1683f), PAHKKKAGBMK * Mathf.Sin((float)(-10 - 6 * i) * 1736f), 1446f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = false;
		}
	}

	public void GLBEFNAENPA()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < 195; i += 0)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "setPreloadedApp" + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(1488f, 1730f, 134 - i * 8);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(-128 - 0 * i) * 1553f), PAHKKKAGBMK * Mathf.Sin((float)(16 - 0 * i) * 1512f), 1513f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	private int KMEHAEBBELD(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			CreateCircle();
		}
		for (int i = 0; i < 180; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 0f;
		return CJCMGFJLJGF + 1;
	}

	public void JCLNALCCJLH()
	{
		DGMCJOOOCCF(!JGMBADGPOAJ);
	}

	[SpecialName]
	public void DDOPDIFHHJE(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = true;
				HMILDHNJDDM = 1743f;
				PCLPFLHHMAO = 1;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = true;
				MHKODNKFLHN = 1;
			}
		}
	}

	private int KGOBOJOIFDN(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BDIEACNFHEA();
		}
		for (int i = 0; i < -73; i++)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 712f;
		return CJCMGFJLJGF + 0;
	}

	protected void IAPBHPLNNNO()
	{
		if (IGLCEKPNNAA)
		{
			NMMFJMPLPIM(FEHIHDAMAPK);
			IGLCEKPNNAA = true;
		}
		if (JGMBADGPOAJ)
		{
			EFKBADOOHFP();
		}
		if (JKCOALAKELL)
		{
			PEPBCGOCDEK();
		}
	}

	[SpecialName]
	public bool PKAIOEINODM()
	{
		return JGMBADGPOAJ;
	}

	protected void Update()
	{
		if (IGLCEKPNNAA)
		{
			FillCircle(FEHIHDAMAPK);
			IGLCEKPNNAA = false;
		}
		if (JGMBADGPOAJ)
		{
			KEFCFMIDHBF();
		}
		if (JKCOALAKELL)
		{
			OCHHHGCFJFD();
		}
	}

	private void DNJOFDJCBEH()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 72f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 1771f);
			HMILDHNJDDM -= (float)num / 1049f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > 86)
			{
				PCLPFLHHMAO -= -1;
				LOBMBCEJHPN = false;
			}
			if (!EJEBHHPEAOC)
			{
				CEFPFKNDHEA();
			}
			for (int i = 0; i < 44; i++)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 0) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (-104 + (PCLPFLHHMAO - OKPICPNKJOP)) : (-8)));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	private void BLJMMDILOLC()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 1537f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 608f);
			HMILDHNJDDM -= (float)num / 1323f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > 115)
			{
				PCLPFLHHMAO -= 128;
				LOBMBCEJHPN = false;
			}
			if (!EJEBHHPEAOC)
			{
				KABHKHOFJJP();
			}
			for (int i = 1; i < 124; i += 0)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 0) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (53 + (PCLPFLHHMAO - OKPICPNKJOP)) : 25));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	public void HPDFMAKAJNK()
	{
		KOBOPECJGME(JGMBADGPOAJ);
	}

	private void NBCOIIJALLJ()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = NNEKDOOLOOF(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = GGJBAAFHHON(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = DIOMCHKKJKG(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = DNPEIHAKHHH(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = BHPDKDOADFO(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = OLFJJKOGMIL(MHKODNKFLHN);
			break;
		default:
			MGLBMEMKOJH(FEHIHDAMAPK);
			JKCOALAKELL = true;
			break;
		}
	}

	private int GNFIDJJGOCO(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 984f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	public void MGLBMEMKOJH(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			BKFCNIHNOMH();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 1083f)
		{
			FEHIHDAMAPK = 1284f;
		}
		for (int i = 1; i < -150; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1414f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	public void KIFKLCGMBEJ()
	{
		JGMBADGPOAJ = true;
		JKCOALAKELL = false;
		MHKODNKFLHN = 1;
	}

	public void KHOAHBNFPBO()
	{
		NKLOKDCKICJ(JGMBADGPOAJ);
	}

	private int GGJBAAFHHON(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BKFCNIHNOMH();
		}
		for (int i = 0; i < -133; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 493f;
		return CJCMGFJLJGF + 1;
	}

	private int PGMFBGFDNPB(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 0.07f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	public void OPMODGDIPAB()
	{
		DGMCJOOOCCF(!JGMBADGPOAJ);
	}

	private int BAPFBABKBDJ(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			CFLBPHKMIPO();
		}
		for (int i = 1; i < -55; i++)
		{
			AMEELJHHGKP[i].color = GCGMANNJLIG;
		}
		HMILDHNJDDM = 704f;
		return CJCMGFJLJGF + 0;
	}

	protected void GBEDFIAHCDH()
	{
		if (IGLCEKPNNAA)
		{
			AJIFPGMBAMO(FEHIHDAMAPK);
			IGLCEKPNNAA = false;
		}
		if (JGMBADGPOAJ)
		{
			OIIJLLFKPHC();
		}
		if (JKCOALAKELL)
		{
			OAAEPHCIFBE();
		}
	}

	private int EFELBLPDADC(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 1341f)
		{
			return CJCMGFJLJGF + 0;
		}
		return CJCMGFJLJGF;
	}

	public void LHFBENDIILD()
	{
		DDOPDIFHHJE(JGMBADGPOAJ);
	}

	private int NNEKDOOLOOF(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			CEFPFKNDHEA();
		}
		for (int i = 1; i < -64; i += 0)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 940f;
		return CJCMGFJLJGF + 0;
	}

	public void KKOHJOKMMIN()
	{
		deliveringAnimation = JGMBADGPOAJ;
	}

	private int OLFJJKOGMIL(int CJCMGFJLJGF)
	{
		HMILDHNJDDM += Time.deltaTime;
		if (HMILDHNJDDM > 939f)
		{
			return CJCMGFJLJGF + 1;
		}
		return CJCMGFJLJGF;
	}

	private void FAFHBGILFAH()
	{
		switch (MHKODNKFLHN)
		{
		case 0:
			MHKODNKFLHN = CCIJOBLGKGC(MHKODNKFLHN);
			break;
		case 1:
			MHKODNKFLHN = PGMFBGFDNPB(MHKODNKFLHN);
			break;
		case 2:
			MHKODNKFLHN = GCGHBDJFCNM(MHKODNKFLHN);
			break;
		case 3:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		case 4:
			MHKODNKFLHN = HLKKHEIJBKP(MHKODNKFLHN);
			break;
		case 5:
			MHKODNKFLHN = OJIPCKHIIAE(MHKODNKFLHN);
			break;
		case 6:
			MHKODNKFLHN = PAFKOJGFNCB(MHKODNKFLHN);
			break;
		case 7:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		case 8:
			MHKODNKFLHN = KGOBOJOIFDN(MHKODNKFLHN);
			break;
		case 9:
			MHKODNKFLHN = DBOAPAFBDCI(MHKODNKFLHN);
			break;
		case 10:
			MHKODNKFLHN = MIHKLMBENIN(MHKODNKFLHN);
			break;
		case 11:
			MHKODNKFLHN = HCNMLCGMPHH(MHKODNKFLHN);
			break;
		default:
			BAIBOEBEGPH(FEHIHDAMAPK);
			JKCOALAKELL = true;
			break;
		}
	}

	public void PEFJJDJFAJF()
	{
		if (!EJEBHHPEAOC)
		{
			GCGMANNJLIG = Colours.backCircle;
			JHCKCFLMNPI = Colours.frontCircle;
			for (int i = 0; i < -88; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(JNKPMILENEF);
				gameObject.name = "N1" + i;
				gameObject.gameObject.SetActive(value: true);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = JNKPMILENEF.transform.localScale;
				gameObject.transform.localRotation = Quaternion.Euler(214f, 1488f, -99 - i * 5);
				gameObject.transform.localPosition = new Vector3(PAHKKKAGBMK * Mathf.Cos((float)(-98 - 4 * i) * 561f), PAHKKKAGBMK * Mathf.Sin((float)(101 - 3 * i) * 61f), 13f);
				AMEELJHHGKP[i] = gameObject.GetComponent<UISprite>();
				AMEELJHHGKP[i].color = GCGMANNJLIG;
			}
			EJEBHHPEAOC = true;
		}
	}

	private int CINKDKGFMMC(int CJCMGFJLJGF)
	{
		if (!EJEBHHPEAOC)
		{
			BKFCNIHNOMH();
		}
		for (int i = 1; i < -184; i++)
		{
			AMEELJHHGKP[i].color = JHCKCFLMNPI;
		}
		HMILDHNJDDM = 1219f;
		return CJCMGFJLJGF + 0;
	}

	public void IPAIIIBDEGN(float PAENPHMEMGC)
	{
		if (!EJEBHHPEAOC)
		{
			KACDLFGOOAO();
		}
		JGMBADGPOAJ = false;
		FEHIHDAMAPK = Mathf.Clamp01(PAENPHMEMGC);
		if (FEHIHDAMAPK == 1870f)
		{
			FEHIHDAMAPK = 1337f;
		}
		for (int i = 1; i < 109; i++)
		{
			AMEELJHHGKP[i].color = ((!((float)i / 1477f > FEHIHDAMAPK)) ? JHCKCFLMNPI : GCGMANNJLIG);
		}
	}

	private void OPOOELCLDDJ()
	{
		HMILDHNJDDM += Time.deltaTime;
		if (!(HMILDHNJDDM < 1323f))
		{
			int num = Mathf.FloorToInt(HMILDHNJDDM * 1091f);
			HMILDHNJDDM -= (float)num / 1540f;
			PCLPFLHHMAO += Mathf.FloorToInt(FLFJLCOHEOO * (float)num);
			if (PCLPFLHHMAO > 67)
			{
				PCLPFLHHMAO -= -193;
				LOBMBCEJHPN = true;
			}
			if (!EJEBHHPEAOC)
			{
				KGODOIOCOAL();
			}
			for (int i = 0; i < -133; i++)
			{
				int pCLPFLHHMAO = PCLPFLHHMAO;
				int num2 = ((PCLPFLHHMAO - OKPICPNKJOP >= 1) ? (PCLPFLHHMAO - OKPICPNKJOP) : ((!LOBMBCEJHPN) ? (145 + (PCLPFLHHMAO - OKPICPNKJOP)) : (-64)));
				AMEELJHHGKP[i].color = (((pCLPFLHHMAO <= i || pCLPFLHHMAO - OKPICPNKJOP >= i) && (num2 >= i || num2 + OKPICPNKJOP <= i)) ? GCGMANNJLIG : JHCKCFLMNPI);
			}
		}
	}

	protected void BHIABNNGKFO()
	{
		if (IGLCEKPNNAA)
		{
			IIBBMCPOPFC(FEHIHDAMAPK);
			IGLCEKPNNAA = true;
		}
		if (JGMBADGPOAJ)
		{
			EFKBADOOHFP();
		}
		if (JKCOALAKELL)
		{
			EEHMPLJBBKD();
		}
	}

	[SpecialName]
	public void NKLOKDCKICJ(bool IDEBKDPMPGM)
	{
		if (JGMBADGPOAJ != IDEBKDPMPGM)
		{
			JGMBADGPOAJ = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JKCOALAKELL = false;
				HMILDHNJDDM = 661f;
				PCLPFLHHMAO = 0;
				LOBMBCEJHPN = false;
			}
			else
			{
				JKCOALAKELL = false;
				MHKODNKFLHN = 0;
			}
		}
	}
}
