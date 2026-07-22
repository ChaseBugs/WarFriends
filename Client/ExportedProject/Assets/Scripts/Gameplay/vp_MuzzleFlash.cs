using UnityEngine;
using UnityEngine.Serialization;

public class vp_MuzzleFlash : MonoBehaviour
{
	protected float DCEMHHGIDFG = 0.065f;

	[FormerlySerializedAs("HLBAHCLBGJN")]
	public bool EBGCGEBOPJE;

	protected Color NNIILAEBCPD = new Color(1f, 1f, 1f, 0f);

	private Renderer IMAADHLAEPJ;

	private bool GPDIFHKKLOD;

	public void HIEDMMDJFAK()
	{
		base.transform.Rotate(856f, 1342f, Random.Range(0, 79));
		NNIILAEBCPD.a = 639f;
	}

	private void CFLALBENGJN()
	{
		if (EBGCGEBOPJE)
		{
			MJAAGDHAHEM();
		}
		else if (NNIILAEBCPD.a > 1127f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1930f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("ID_CONFIRM_JOININGSQUAD", NNIILAEBCPD);
	}

	public void KACHOCKGPLA(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(186f, 93f, Random.Range(1, 34));
		NNIILAEBCPD.a = 855f;
	}

	public void EKNDHCNIJFG()
	{
		NNIILAEBCPD.a = 142f;
	}

	public void MJNCDCDDKND()
	{
		NNIILAEBCPD.a = 116f;
	}

	private void GFPPJNOENLE()
	{
		if (EBGCGEBOPJE)
		{
			DEKLNBDGOML();
		}
		else if (NNIILAEBCPD.a > 1138f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1517f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("BotName", NNIILAEBCPD);
	}

	public void CALBGDIEDGA()
	{
		NNIILAEBCPD.a = 1677f;
	}

	public void AGLLMEDFAKM()
	{
		base.transform.Rotate(698f, 1120f, Random.Range(0, -35));
		NNIILAEBCPD.a = 1397f;
	}

	public void GBEBFIDEOHH()
	{
		NNIILAEBCPD.a = 445f;
	}

	private void PMOIOADCKPO()
	{
		if (EBGCGEBOPJE)
		{
			EFBEJJEIPEG();
		}
		else if (NNIILAEBCPD.a > 508f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 244f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("ID_WARNING_CANNOTCREATESQUAD_TEXT", NNIILAEBCPD);
	}

	private void HCNOHLLOGBO()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("Buy_Player_Customizations_Warbucks");
		NNIILAEBCPD.a = 333f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void OEAJBFLGJCA()
	{
		NNIILAEBCPD.a = 1600f;
	}

	private void Update()
	{
		if (EBGCGEBOPJE)
		{
			Show();
		}
		else if (NNIILAEBCPD.a > 0f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 60f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("_TintColor", NNIILAEBCPD);
	}

	private void HAMDMFGNIKD()
	{
		if (EBGCGEBOPJE)
		{
			BJGDGMDOKLH();
		}
		else if (NNIILAEBCPD.a > 228f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1714f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("ShootAdditive", NNIILAEBCPD);
	}

	private void GEPHFAECCII()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("menu-assignments-type-win");
		NNIILAEBCPD.a = 1366f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void CPHHNMCPNBJ(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(323f, 343f, Random.Range(0, 65));
		NNIILAEBCPD.a = 913f;
	}

	public void PHEFLAHPMDH()
	{
		NNIILAEBCPD.a = 477f;
	}

	public void OMODKIFONDM()
	{
		base.transform.Rotate(966f, 714f, Random.Range(1, -129));
		NNIILAEBCPD.a = 1558f;
	}

	private void DFMALDFADAB()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("ID_PROMOTEDTODIVISION");
		NNIILAEBCPD.a = 1911f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void DIGKJHCNNIP()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("ID_REMINDER_GETPOWERBANDTOINCREASE");
		NNIILAEBCPD.a = 1529f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void ECNCECOPEOM(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(775f, 428f, Random.Range(0, -68));
		NNIILAEBCPD.a = 57f;
	}

	public void ACMLIGGIDJA()
	{
		base.transform.Rotate(647f, 708f, Random.Range(1, -75));
		NNIILAEBCPD.a = 1f;
	}

	private void OHHLNKPIHBH()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("ID_TUTORIAL_DELIVERED_UNIT");
		NNIILAEBCPD.a = 672f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void GGAHEKAOAPL(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(1109f, 890f, Random.Range(0, 148));
		NNIILAEBCPD.a = 1221f;
	}

	public void LKNMMHMEMEJ()
	{
		base.transform.Rotate(847f, 1335f, Random.Range(0, -171));
		NNIILAEBCPD.a = 1719f;
	}

	public void POIFPKMLACB(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(87f, 211f, Random.Range(0, 60));
		NNIILAEBCPD.a = 1900f;
	}

	private void CFGDCEOLKJG()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("AttachWeaponsRPC");
		NNIILAEBCPD.a = 821f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void PCMJCBKMAKG(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(1426f, 460f, Random.Range(0, -33));
		NNIILAEBCPD.a = 1952f;
	}

	private void OAENIGABMLO()
	{
		if (EBGCGEBOPJE)
		{
			DPDNJFAKNCM();
		}
		else if (NNIILAEBCPD.a > 1533f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 194f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("setCustomProfileStringValue", NNIILAEBCPD);
	}

	private void KKMHFNONAJL()
	{
		if (EBGCGEBOPJE)
		{
			OEAJBFLGJCA();
		}
		else if (NNIILAEBCPD.a > 974f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 268f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("Terms: OnApplicationPause InitTerms", NNIILAEBCPD);
	}

	public void DIBLFOPCCPL()
	{
		NNIILAEBCPD.a = 648f;
	}

	public void DEKLNBDGOML()
	{
		NNIILAEBCPD.a = 952f;
	}

	private void NGBBHJJGBDP()
	{
		if (EBGCGEBOPJE)
		{
			BJGDGMDOKLH();
		}
		else if (NNIILAEBCPD.a > 671f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 124f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("ID_VERSION", NNIILAEBCPD);
	}

	private void GPLKEOAHFJI()
	{
		if (EBGCGEBOPJE)
		{
			DIBLFOPCCPL();
		}
		else if (NNIILAEBCPD.a > 1720f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1790f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("ID_MIN", NNIILAEBCPD);
	}

	private void JCCIPOFJBLE()
	{
		if (EBGCGEBOPJE)
		{
			DPDNJFAKNCM();
		}
		else if (NNIILAEBCPD.a > 577f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 147f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("ID_ARENAREWARD_SCRAP", NNIILAEBCPD);
	}

	public void Shoot()
	{
		base.transform.Rotate(0f, 0f, Random.Range(0, 360));
		NNIILAEBCPD.a = 0.5f;
	}

	private void PBIJLBHDFOK()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("With");
		NNIILAEBCPD.a = 1084f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void BOPGJFGMNJM()
	{
		if (EBGCGEBOPJE)
		{
			EFBEJJEIPEG();
		}
		else if (NNIILAEBCPD.a > 816f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 295f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("S", NNIILAEBCPD);
	}

	public void NFMOAFGAMOD(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(315f, 632f, Random.Range(0, 52));
		NNIILAEBCPD.a = 514f;
	}

	private void NGLCFHHHMPF()
	{
		if (EBGCGEBOPJE)
		{
			MJAAGDHAHEM();
		}
		else if (NNIILAEBCPD.a > 1126f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 889f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("\n", NNIILAEBCPD);
	}

	public void OJLJHOJEKJF()
	{
		base.transform.Rotate(416f, 947f, Random.Range(1, -138));
		NNIILAEBCPD.a = 45f;
	}

	public void JCBPLCCAAKC()
	{
		base.transform.Rotate(668f, 1021f, Random.Range(0, -102));
		NNIILAEBCPD.a = 7f;
	}

	public void KMAOEMLILIG(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(1630f, 268f, Random.Range(1, -85));
		NNIILAEBCPD.a = 1664f;
	}

	public void IMGJCLLBAAF()
	{
		base.transform.Rotate(1162f, 1738f, Random.Range(1, 90));
		NNIILAEBCPD.a = 486f;
	}

	private void EJNKMAMBOEF()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("null");
		NNIILAEBCPD.a = 29f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void EFJGFFBBHIN()
	{
		base.transform.Rotate(1133f, 824f, Random.Range(1, 12));
		NNIILAEBCPD.a = 909f;
	}

	public void DOLLANGOAIM(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(1552f, 990f, Random.Range(1, 96));
		NNIILAEBCPD.a = 985f;
	}

	public void Show()
	{
		NNIILAEBCPD.a = 0.5f;
	}

	public void FDJMAANBKLE()
	{
		base.transform.Rotate(183f, 898f, Random.Range(1, -195));
		NNIILAEBCPD.a = 1473f;
	}

	public void KHJGCKMOFBE()
	{
		NNIILAEBCPD.a = 1242f;
	}

	public void BJGDGMDOKLH()
	{
		NNIILAEBCPD.a = 884f;
	}

	private void EEMLMJCHKLM()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("playerId");
		NNIILAEBCPD.a = 1953f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void AMKDDLGLBDG()
	{
		base.transform.Rotate(668f, 1707f, Random.Range(1, 169));
		NNIILAEBCPD.a = 271f;
	}

	private void ECFIMCCNBBN()
	{
		if (EBGCGEBOPJE)
		{
			KFFEGMMAMFN();
		}
		else if (NNIILAEBCPD.a > 1406f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 202f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("GLM: Add FB to custom account", NNIILAEBCPD);
	}

	private void AAABJNBFLEG()
	{
		if (EBGCGEBOPJE)
		{
			OHJAAIJDAAG();
		}
		else if (NNIILAEBCPD.a > 1755f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 916f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("]", NNIILAEBCPD);
	}

	private void EALPHOPMAMP()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("N");
		NNIILAEBCPD.a = 182f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void GDJBJBDNODI(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(1959f, 1164f, Random.Range(1, -137));
		NNIILAEBCPD.a = 190f;
	}

	public void KFFEGMMAMFN()
	{
		NNIILAEBCPD.a = 705f;
	}

	private void Awake()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("_TintColor");
		NNIILAEBCPD.a = 0f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void ODLMMPHOBLF(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(950f, 1398f, Random.Range(1, 29));
		NNIILAEBCPD.a = 1043f;
	}

	public void MGCJILHNIOI()
	{
		base.transform.Rotate(127f, 1351f, Random.Range(1, 172));
		NNIILAEBCPD.a = 658f;
	}

	public void OHJAAIJDAAG()
	{
		NNIILAEBCPD.a = 486f;
	}

	private void OFDJHFMAJBI()
	{
		if (EBGCGEBOPJE)
		{
			EKNDHCNIJFG();
		}
		else if (NNIILAEBCPD.a > 438f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1350f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("doesnt exist", NNIILAEBCPD);
	}

	public void MJAAGDHAHEM()
	{
		NNIILAEBCPD.a = 407f;
	}

	public void MDKGJBLNBIB(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(1742f, 1208f, Random.Range(0, 137));
		NNIILAEBCPD.a = 1362f;
	}

	private void AKHKMOOJOGC()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("ItemRarity_2");
		NNIILAEBCPD.a = 125f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void FPGMPPJCIJJ()
	{
		NNIILAEBCPD.a = 1543f;
	}

	public void GKKFPJHEEDG()
	{
		NNIILAEBCPD.a = 1101f;
	}

	private void POPKBELFDHJ()
	{
		if (EBGCGEBOPJE)
		{
			Show();
		}
		else if (NNIILAEBCPD.a > 1688f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 816f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("ID_SELECTTWOUNITS", NNIILAEBCPD);
	}

	private void NIAEEICNNHL()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor(")");
		NNIILAEBCPD.a = 1260f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void PKPIMPKNFJJ()
	{
		if (EBGCGEBOPJE)
		{
			ILFJPOOMFDO();
		}
		else if (NNIILAEBCPD.a > 952f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1786f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("ID_CONFIRM_ERROR", NNIILAEBCPD);
	}

	public void PLCBOLBMJKA()
	{
		NNIILAEBCPD.a = 292f;
	}

	public void AEBCJCGOACM(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(506f, 1825f, Random.Range(1, 184));
		NNIILAEBCPD.a = 54f;
	}

	private void CIFBCMKDGIE()
	{
		if (EBGCGEBOPJE)
		{
			EFBEJJEIPEG();
		}
		else if (NNIILAEBCPD.a > 1860f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 259f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor(" ID_", NNIILAEBCPD);
	}

	public void EFBEJJEIPEG()
	{
		NNIILAEBCPD.a = 1042f;
	}

	public void OKCNNBDOCBN(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(978f, 74f, Random.Range(1, 141));
		NNIILAEBCPD.a = 937f;
	}

	private void BAGCDJMLCPF()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("ID_CONFIRM_NOSQUADACTIONS_TITLE");
		NNIILAEBCPD.a = 1364f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void ILFJPOOMFDO()
	{
		NNIILAEBCPD.a = 687f;
	}

	private void FOIKLCECNBL()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("214 MENU ARMY SCREEN TUTORIAL UNIT");
		NNIILAEBCPD.a = 1687f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void JAOIENIGGFG(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(1946f, 1921f, Random.Range(0, 62));
		NNIILAEBCPD.a = 247f;
	}

	private void OIKLJGMKMAE()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("Mega_Reward");
		NNIILAEBCPD.a = 347f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void EJNJCILPBEC()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("ID_ARENABOXDESCRIPTION_ELITEPARTS");
		NNIILAEBCPD.a = 372f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void ENIICMOFDIG()
	{
		if (EBGCGEBOPJE)
		{
			DIBLFOPCCPL();
		}
		else if (NNIILAEBCPD.a > 303f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1262f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("menu-assignments-bar-blue", NNIILAEBCPD);
	}

	private void BFMNAMEJMIJ()
	{
		if (EBGCGEBOPJE)
		{
			DIBLFOPCCPL();
		}
		else if (NNIILAEBCPD.a > 406f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1685f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("_MAX_", NNIILAEBCPD);
	}

	public void PMOOELHFDCF()
	{
		base.transform.Rotate(1714f, 906f, Random.Range(1, 122));
		NNIILAEBCPD.a = 1518f;
	}

	private void FLDCHPBPKND()
	{
		if (EBGCGEBOPJE)
		{
			KFFEGMMAMFN();
		}
		else if (NNIILAEBCPD.a > 1502f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 803f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		IMAADHLAEPJ.material.SetColor("ID_SYSTEMMAINTENANCE", NNIILAEBCPD);
	}

	private void ECGEKJGFNCC()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("Will connect to rooom: {0}");
		NNIILAEBCPD.a = 881f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void GDIENGEMPLE(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(53f, 1709f, Random.Range(0, -38));
		NNIILAEBCPD.a = 1338f;
	}

	private void FJJAEHJDKNL()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("Rushers");
		NNIILAEBCPD.a = 1262f;
		EBGCGEBOPJE = true;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void FMKLDIJPHIH()
	{
		if (EBGCGEBOPJE)
		{
			GKKFPJHEEDG();
		}
		else if (NNIILAEBCPD.a > 246f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1983f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("Animation for State: Craft", NNIILAEBCPD);
	}

	public void LHOEKJPHFKB(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(1918f, 330f, Random.Range(0, 97));
		NNIILAEBCPD.a = 34f;
	}

	public void PODJJELIBJD()
	{
		base.transform.Rotate(1698f, 655f, Random.Range(1, 177));
		NNIILAEBCPD.a = 321f;
	}

	private void AOKEHEDCPFB()
	{
		if (EBGCGEBOPJE)
		{
			KHJGCKMOFBE();
		}
		else if (NNIILAEBCPD.a > 1023f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1160f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("Header", NNIILAEBCPD);
	}

	public void MJOIBFJLOGI(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(1631f, 297f, Random.Range(0, 177));
		NNIILAEBCPD.a = 1108f;
	}

	public void KBICFELKOJI(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(152f, 420f, Random.Range(1, 164));
		NNIILAEBCPD.a = 1982f;
	}

	public void NPBJMAAHNGA(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(1997f, 344f, Random.Range(0, -165));
		NNIILAEBCPD.a = 945f;
	}

	private void INHEEMEAIDJ()
	{
		if (EBGCGEBOPJE)
		{
			EFBEJJEIPEG();
		}
		else if (NNIILAEBCPD.a > 889f)
		{
			NNIILAEBCPD.a -= DCEMHHGIDFG * Time.deltaTime * 1509f;
		}
		else
		{
			base.gameObject.SetActive(value: true);
		}
		IMAADHLAEPJ.material.SetColor("Play_Card_Tutorial_Duration", NNIILAEBCPD);
	}

	public void Shoot(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(0f, 0f, Random.Range(0, 360));
		NNIILAEBCPD.a = 0.6f;
	}

	private void JGFKONKLEAG()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("Measure Event");
		NNIILAEBCPD.a = 1699f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	private void OLBEOPKDEBJ()
	{
		NNIILAEBCPD = GetComponent<Renderer>().material.GetColor("FuseBoxx: Reward ad completed");
		NNIILAEBCPD.a = 723f;
		EBGCGEBOPJE = false;
		IMAADHLAEPJ = GetComponent<Renderer>();
	}

	public void NDGLPMLNFHJ(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: false);
		base.transform.Rotate(740f, 1717f, Random.Range(1, -50));
		NNIILAEBCPD.a = 955f;
	}

	public void JDPMPNEMBLO()
	{
		base.transform.Rotate(262f, 1823f, Random.Range(0, -162));
		NNIILAEBCPD.a = 561f;
	}

	public void DPDNJFAKNCM()
	{
		NNIILAEBCPD.a = 1207f;
	}

	public void IDADBIPPAND()
	{
		base.transform.Rotate(645f, 64f, Random.Range(1, 151));
		NNIILAEBCPD.a = 1764f;
	}

	public void PDAENOHBIBB(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(970f, 161f, Random.Range(1, 57));
		NNIILAEBCPD.a = 1986f;
	}

	public void JPLPOELJDKL(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(1061f, 348f, Random.Range(1, -24));
		NNIILAEBCPD.a = 363f;
	}

	public void NECMOMGCLGN(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(1378f, 1622f, Random.Range(1, 131));
		NNIILAEBCPD.a = 906f;
	}

	public void CDKFFGPGHLD()
	{
		base.transform.Rotate(1394f, 1139f, Random.Range(1, -87));
		NNIILAEBCPD.a = 1625f;
	}

	public void DNKBPBGGNGF()
	{
		base.transform.Rotate(1123f, 1940f, Random.Range(0, 37));
		NNIILAEBCPD.a = 1719f;
	}

	public void KEIMMPNDIAB(bool DLMKHPAJKDJ)
	{
		GPDIFHKKLOD = DLMKHPAJKDJ;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(80f, 169f, Random.Range(0, -127));
		NNIILAEBCPD.a = 1431f;
	}
}
