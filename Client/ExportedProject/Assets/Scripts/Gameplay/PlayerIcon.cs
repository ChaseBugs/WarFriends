using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(UITexture))]
public class PlayerIcon : Core_BaseScript
{
	private UITexture EPHDGCLKEFO;

	[FormerlySerializedAs("CMKGOKNCLOJ")]
	public UILabel PKHHKJLGHFM;

	private Texture APEHLLHNAEL;

	private UITexture EOOCHAHGBGL
	{
		get
		{
			if (EPHDGCLKEFO == null)
			{
				EPHDGCLKEFO = GetComponent<UITexture>();
			}
			return EPHDGCLKEFO;
		}
		set
		{
			EPHDGCLKEFO = value;
		}
	}

	public Texture avatar
	{
		set
		{
			APEHLLHNAEL = value;
			if (value != null)
			{
				EIPEHFLBCPJ();
			}
		}
	}

	public Color color
	{
		set
		{
			EOOCHAHGBGL.color = value;
		}
	}

	private void PGCNKHONOEO()
	{
		KFLKGGGJHIN.KGFKJNJMBOF -= DDLNAMBNKMB;
	}

	public void MLOCBNGHCLL(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	private void CBOPNGPOHOC()
	{
		if (APEHLLHNAEL != null)
		{
			CCDLKKEOHDM().mainTexture = APEHLLHNAEL;
		}
		else
		{
			GDKNNDCFIEC().mainTexture = null;
		}
	}

	private void ONCIPBLGODL()
	{
		if (APEHLLHNAEL != null)
		{
			INPHMKEBJNH().mainTexture = APEHLLHNAEL;
		}
		else
		{
			OLDAHJPAEGA().mainTexture = null;
		}
	}

	[SpecialName]
	private UITexture OLDAHJPAEGA()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	protected virtual void GGLIMLFLJAB()
	{
		base.Start();
		CBOPNGPOHOC();
	}

	[SpecialName]
	private void KOIHFLJJIBE(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	[SpecialName]
	private void PNCLBJEHGEK(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	[SpecialName]
	public void LOCLNGEMNCC(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			AACCJOEDKJP();
		}
	}

	protected virtual void PMIDDDGGBPN()
	{
		base.Start();
		AACCJOEDKJP();
	}

	public void GPHGDAKLAJK()
	{
		CBEOJKMGBIM();
	}

	protected virtual void LFGAFALKANI()
	{
		base.Start();
		CBOPNGPOHOC();
	}

	protected virtual void PAPFKMJEMML()
	{
		base.Awake();
		OHGFOGJJJAC(GetComponent<UITexture>());
	}

	[SpecialName]
	public void KGJCNNANACM(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			ONCIPBLGODL();
		}
	}

	[SpecialName]
	public void DHDPJLAPAPO(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			CHPMAJAEBEI();
		}
	}

	protected virtual void CMDMNDCMBJO()
	{
		base.Start();
		EIPEHFLBCPJ();
	}

	protected virtual void LPKEGOIAEJC()
	{
		base.Start();
		MFNIOABOJEP();
	}

	[SpecialName]
	private void OHGFOGJJJAC(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	private void APKEABPODEB()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += FOJKNLMHCAP;
	}

	private void OnEnable()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += FDICFDNHEAP;
	}

	[SpecialName]
	public void OLJPGNNKCKI(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			EIPEHFLBCPJ();
		}
	}

	[SpecialName]
	public void ECKBKNCJLOC(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			DAGICINHNIO();
		}
	}

	private void INLCCADNCJG()
	{
		KFLKGGGJHIN.DMDKEBLJALF(LEPPLLEGDOC);
	}

	private void FOJKNLMHCAP(KFLKGGGJHIN.EBDBJAKJNLD MFGOOHMBMLM)
	{
	}

	private void KGGHMDGIFGE()
	{
		KFLKGGGJHIN.IEAGEGFHNKC(FOJKNLMHCAP);
	}

	[SpecialName]
	private UITexture NDFKMHEAFNL()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	private void PPIOPDGHGDK()
	{
		KFLKGGGJHIN.IEAGEGFHNKC(LEPPLLEGDOC);
	}

	public void ECAFLDEFKKB()
	{
		EIPEHFLBCPJ();
	}

	private void BKDHHFNHLJB()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += DDLNAMBNKMB;
	}

	[SpecialName]
	public void JIBFCGECCFI(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			ONCIPBLGODL();
		}
	}

	public void SetName(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	[SpecialName]
	public void ILHGEFJNFPC(Color IDEBKDPMPGM)
	{
		NAIMFBBFOGC().color = IDEBKDPMPGM;
	}

	private void CHDFIFAJICB()
	{
		if (APEHLLHNAEL != null)
		{
			CCDLKKEOHDM().mainTexture = APEHLLHNAEL;
		}
		else
		{
			EOOCHAHGBGL.mainTexture = null;
		}
	}

	protected virtual void IGBCCGDMCDE()
	{
		base.Start();
		CBOPNGPOHOC();
	}

	[SpecialName]
	private UITexture ALFKBLJAOGK()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	protected virtual void OIHNFPDILBF()
	{
		base.Start();
		AACCJOEDKJP();
	}

	private void HLGLKNKEPCP()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += OMHLGNIEDLC;
	}

	[SpecialName]
	public void LEPNEKBJECJ(Color IDEBKDPMPGM)
	{
		EOOCHAHGBGL.color = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JFNDCBLKGJI(Color IDEBKDPMPGM)
	{
		NDFKMHEAFNL().color = IDEBKDPMPGM;
	}

	[SpecialName]
	public void ELPJJFPDJCN(Color IDEBKDPMPGM)
	{
		FKBDHHNMMMN().color = IDEBKDPMPGM;
	}

	public void Reset()
	{
		EOOCHAHGBGL.mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	private void DKLJIMFOOBC()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += FDICFDNHEAP;
	}

	[SpecialName]
	private void OJJKAKPCEBI(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	private void IDLBCAOIPEC()
	{
		KFLKGGGJHIN.KGFKJNJMBOF -= DDLNAMBNKMB;
	}

	public void AMLMMLAIHCD(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	private void KFKLLAGCDIF()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += FDICFDNHEAP;
	}

	private void CHPMAJAEBEI()
	{
		if (APEHLLHNAEL != null)
		{
			INPHMKEBJNH().mainTexture = APEHLLHNAEL;
		}
		else
		{
			FKBDHHNMMMN().mainTexture = null;
		}
	}

	private void LKDHKBCADPP()
	{
		KFLKGGGJHIN.DMDKEBLJALF(LEPPLLEGDOC);
	}

	protected virtual void JDMBJJIDIMC()
	{
		base.Awake();
		PNCLBJEHGEK(GetComponent<UITexture>());
	}

	private void LDBLOMHCGCP()
	{
		KFLKGGGJHIN.KGFKJNJMBOF -= FDICFDNHEAP;
	}

	[SpecialName]
	public void EIKJEGHELNK(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			CHPMAJAEBEI();
		}
	}

	public void AEEHINLDEJC(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	[SpecialName]
	public void BIEIDBBDNIF(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			CBEOJKMGBIM();
		}
	}

	[SpecialName]
	public void PIJCAFIHIHM(Color IDEBKDPMPGM)
	{
		NDFKMHEAFNL().color = IDEBKDPMPGM;
	}

	protected virtual void JCKCDCFJAHP()
	{
		base.Start();
		EIPEHFLBCPJ();
	}

	public void DGPJIJBHBJC()
	{
		ONCIPBLGODL();
	}

	protected virtual void LLKBLBNEBPA()
	{
		base.Awake();
		PNCLBJEHGEK(GetComponent<UITexture>());
	}

	[SpecialName]
	private UITexture GDKNNDCFIEC()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	[SpecialName]
	public void FBGDPCPIKMI(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			MFNIOABOJEP();
		}
	}

	[SpecialName]
	public void NOCFFOCLDJO(Color IDEBKDPMPGM)
	{
		NAIMFBBFOGC().color = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GDHNNOBNCAN(Color IDEBKDPMPGM)
	{
		EOOCHAHGBGL.color = IDEBKDPMPGM;
	}

	protected virtual void HEIGPPJIACO()
	{
		base.Start();
		AACCJOEDKJP();
	}

	protected virtual void JNOEBMABKIB()
	{
		base.Start();
		EIPEHFLBCPJ();
	}

	public void MPOJAMOIBBF(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	private void LEPPLLEGDOC(KFLKGGGJHIN.EBDBJAKJNLD MFGOOHMBMLM)
	{
	}

	public void GEPDJCOHDNH()
	{
		ONCIPBLGODL();
	}

	[SpecialName]
	private void GKHJBLAGNOH(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	public void EAFNPDOOGBE(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	[SpecialName]
	public void MGFAIHPMGNA(Color IDEBKDPMPGM)
	{
		FKBDHHNMMMN().color = IDEBKDPMPGM;
	}

	private void KJCPMNEPMLA()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += FDICFDNHEAP;
	}

	[SpecialName]
	public void GJHFCKMAMIE(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			CBEOJKMGBIM();
		}
	}

	protected virtual void AKKKDIBLICM()
	{
		base.Awake();
		OJJKAKPCEBI(GetComponent<UITexture>());
	}

	public void PDKPELBIAON()
	{
		ALFKBLJAOGK().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	public void HJOCCDLNFLN()
	{
		GDKNNDCFIEC().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	private void OMHLGNIEDLC(KFLKGGGJHIN.EBDBJAKJNLD MFGOOHMBMLM)
	{
	}

	public void ABBPOMCBIIH()
	{
		EOOCHAHGBGL.mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	[SpecialName]
	public void MOEEGMIDFJK(Color IDEBKDPMPGM)
	{
		OLDAHJPAEGA().color = IDEBKDPMPGM;
	}

	public void AILNJNAGPGO()
	{
		DAGICINHNIO();
	}

	[SpecialName]
	public void KHIPFLOFKMC(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			ONCIPBLGODL();
		}
	}

	public void OMDFNFHKFBK()
	{
		CCDLKKEOHDM().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		EOOCHAHGBGL = GetComponent<UITexture>();
	}

	private void DAGICINHNIO()
	{
		if (APEHLLHNAEL != null)
		{
			NDFKMHEAFNL().mainTexture = APEHLLHNAEL;
		}
		else
		{
			NAIMFBBFOGC().mainTexture = null;
		}
	}

	public void OKHFOOHNBDF()
	{
		EIPEHFLBCPJ();
	}

	protected virtual void ILFMPFCEPNN()
	{
		base.Start();
		CHDFIFAJICB();
	}

	private void AACCJOEDKJP()
	{
		if (APEHLLHNAEL != null)
		{
			ALFKBLJAOGK().mainTexture = APEHLLHNAEL;
		}
		else
		{
			NDFKMHEAFNL().mainTexture = null;
		}
	}

	public void EGAONBPLDAG()
	{
		NDFKMHEAFNL().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	protected override void Start()
	{
		base.Start();
		EIPEHFLBCPJ();
	}

	[SpecialName]
	public void DJPNDAICDPN(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			MFNIOABOJEP();
		}
	}

	[SpecialName]
	public void EDBDOOCDNJF(Color IDEBKDPMPGM)
	{
		OLDAHJPAEGA().color = IDEBKDPMPGM;
	}

	protected virtual void CJAPKAIJAAH()
	{
		base.Start();
		MFNIOABOJEP();
	}

	[SpecialName]
	private UITexture NAIMFBBFOGC()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	public void UpdateIcon()
	{
		EIPEHFLBCPJ();
	}

	private void IPIAJBBBAMJ()
	{
		KFLKGGGJHIN.FNFIIDJNGMK(DDLNAMBNKMB);
	}

	private void MFNIOABOJEP()
	{
		if (APEHLLHNAEL != null)
		{
			CCDLKKEOHDM().mainTexture = APEHLLHNAEL;
		}
		else
		{
			GDKNNDCFIEC().mainTexture = null;
		}
	}

	private void OnDisable()
	{
		KFLKGGGJHIN.KGFKJNJMBOF -= FDICFDNHEAP;
	}

	public void IFPLAMJKIKH()
	{
		CBOPNGPOHOC();
	}

	public void KOKJMKHECGK()
	{
		NDFKMHEAFNL().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	[SpecialName]
	public void DBBHGJENGEK(Color IDEBKDPMPGM)
	{
		NDFKMHEAFNL().color = IDEBKDPMPGM;
	}

	private void GLMOJIBOION()
	{
		KFLKGGGJHIN.DMDKEBLJALF(FDICFDNHEAP);
	}

	protected virtual void HFFEELCNDOE()
	{
		base.Start();
		AACCJOEDKJP();
	}

	private void NBOFOMCLHDB()
	{
		KFLKGGGJHIN.DMDKEBLJALF(FOJKNLMHCAP);
	}

	public void AJLMACKOEPF(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	public void GFEIGLKOPJK(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	public void HJHOBLMEJEH()
	{
		MFNIOABOJEP();
	}

	private void DDLNAMBNKMB(KFLKGGGJHIN.EBDBJAKJNLD MFGOOHMBMLM)
	{
	}

	protected virtual void PGFLFHIKFDJ()
	{
		base.Awake();
		FEKOJBFFGPN(GetComponent<UITexture>());
	}

	protected virtual void JNPKJNEAKMO()
	{
		base.Start();
		DAGICINHNIO();
	}

	[SpecialName]
	private void MOBJFHFJNGG(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JJGFMKCHIPE(Texture IDEBKDPMPGM)
	{
		APEHLLHNAEL = IDEBKDPMPGM;
		if (IDEBKDPMPGM != null)
		{
			AACCJOEDKJP();
		}
	}

	[SpecialName]
	private UITexture INPHMKEBJNH()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	public void LFOLGBNBBAG()
	{
		NAIMFBBFOGC().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	[SpecialName]
	private void KNPPJPEMJFK(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	[SpecialName]
	private UITexture FKBDHHNMMMN()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	private void EIPEHFLBCPJ()
	{
		if (APEHLLHNAEL != null)
		{
			EOOCHAHGBGL.mainTexture = APEHLLHNAEL;
		}
		else
		{
			EOOCHAHGBGL.mainTexture = null;
		}
	}

	[SpecialName]
	private UITexture CCDLKKEOHDM()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	private void IEFKFINDGOL()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += DDLNAMBNKMB;
	}

	public void NCHGDJDAHGC()
	{
		GDKNNDCFIEC().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	protected virtual void MMEEBPGHGMM()
	{
		base.Start();
		EIPEHFLBCPJ();
	}

	[SpecialName]
	public void ODMCEDLJKMI(Color IDEBKDPMPGM)
	{
		ALFKBLJAOGK().color = IDEBKDPMPGM;
	}

	public void KHMNEOBMJLN()
	{
		GDKNNDCFIEC().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	public void MIGLNAHMBGO(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	[SpecialName]
	public void BLIDGCOANLG(Color IDEBKDPMPGM)
	{
		NAIMFBBFOGC().color = IDEBKDPMPGM;
	}

	[SpecialName]
	private UITexture MDPNDDHGJKI()
	{
		if (EPHDGCLKEFO == null)
		{
			EPHDGCLKEFO = GetComponent<UITexture>();
		}
		return EPHDGCLKEFO;
	}

	protected virtual void ECMMDCKONDK()
	{
		base.Awake();
		EOOCHAHGBGL = GetComponent<UITexture>();
	}

	[SpecialName]
	private void FEKOJBFFGPN(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	public void OOOLABBEKDF()
	{
		NDFKMHEAFNL().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	private void MNLFDPJFIOL()
	{
		KFLKGGGJHIN.KGFKJNJMBOF += FDICFDNHEAP;
	}

	public void BMOMBHEJACH(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	private void JOEKNGNECPM()
	{
		KFLKGGGJHIN.DMDKEBLJALF(FDICFDNHEAP);
	}

	public void BFKPPMIKNAA()
	{
		DNMODKKLHMG();
	}

	public void HCACKHAKDNC()
	{
		ONCIPBLGODL();
	}

	[SpecialName]
	private void ODDOAKGMIPC(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		KOIHFLJJIBE(GetComponent<UITexture>());
	}

	[SpecialName]
	private void NHEDENMMCJJ(UITexture IDEBKDPMPGM)
	{
		EPHDGCLKEFO = IDEBKDPMPGM;
	}

	public void CFKALDIFENK()
	{
		CBOPNGPOHOC();
	}

	protected virtual void CDPAGKOKDOP()
	{
		base.Awake();
		OJJKAKPCEBI(GetComponent<UITexture>());
	}

	private void DNMODKKLHMG()
	{
		if (APEHLLHNAEL != null)
		{
			GDKNNDCFIEC().mainTexture = APEHLLHNAEL;
		}
		else
		{
			FKBDHHNMMMN().mainTexture = null;
		}
	}

	public void NMEJKACLHKJ()
	{
		CCDLKKEOHDM().mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	protected virtual void FPPLLLKNCIE()
	{
		base.Start();
		DNMODKKLHMG();
	}

	protected virtual void CCLFDLJIFKL()
	{
		base.Awake();
		KOIHFLJJIBE(GetComponent<UITexture>());
	}

	public void HEOPOOMLPJF()
	{
		EOOCHAHGBGL.mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	public void GKIHHKCAEOG(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		MOBJFHFJNGG(GetComponent<UITexture>());
	}

	public void GGLBLHKGCAO()
	{
		MFNIOABOJEP();
	}

	[SpecialName]
	public void FDAICPACGAB(Color IDEBKDPMPGM)
	{
		NAIMFBBFOGC().color = IDEBKDPMPGM;
	}

	protected virtual void BPKLLAIPEGF()
	{
		base.Start();
		CBEOJKMGBIM();
	}

	public void FHKFNKOJOAM(string MHPNDNJDPGE)
	{
		PKHHKJLGHFM.text = MHPNDNJDPGE;
	}

	public void KLIEOBHDFCG()
	{
		EOOCHAHGBGL.mainTexture = null;
		if (PKHHKJLGHFM != null)
		{
			PKHHKJLGHFM.text = string.Empty;
		}
	}

	private void HMHABBGGOFI()
	{
		KFLKGGGJHIN.FNFIIDJNGMK(DDLNAMBNKMB);
	}

	protected virtual void AJHIIBAEKMB()
	{
		base.Start();
		MFNIOABOJEP();
	}

	private void CBEOJKMGBIM()
	{
		if (APEHLLHNAEL != null)
		{
			NAIMFBBFOGC().mainTexture = APEHLLHNAEL;
		}
		else
		{
			INPHMKEBJNH().mainTexture = null;
		}
	}

	private void FDICFDNHEAP(KFLKGGGJHIN.EBDBJAKJNLD MFGOOHMBMLM)
	{
	}
}
