using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

public class DecalSystem : GeneratedObjectManager
{
	private static DecalSystem MKELPFGCKKG;

	[FormerlySerializedAs("PAAJOFDJINP")]
	public Decal LOPMDCPCCDL;

	private int NHEHMGKCFDG;

	public static DecalSystem Instance
	{
		get
		{
			MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
			return MKELPFGCKKG;
		}
	}

	public void BBDMAMKGFAE()
	{
		MKELPFGCKKG = null;
	}

	public void BNGAPLNMGBL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1476f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1154f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.ENGIABMLKKB();
	}

	public void GFMKLFFCKNJ(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 231f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1045f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.HHCGLHLAPOP();
	}

	[SpecialName]
	public static DecalSystem NMGBPNIHJCH()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	public void GCOAPLJCEPD()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void BNNEIKBBIJF()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	[SpecialName]
	public static DecalSystem DJEABOHALGB()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	public void OBADIEBDNBD()
	{
		MKELPFGCKKG = null;
	}

	public void AAICKJELDAL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1475f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 820f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.ENGIABMLKKB();
	}

	public void JJKEKIODLMF()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void PDJMNFGLIGO()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	public void FIMLNMFAEKF(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1467f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 25f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.ALCFPBLFOIF();
	}

	protected virtual void IGBCCGDMCDE()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void NLPFAKKGONC()
	{
		MKELPFGCKKG = null;
	}

	public void GIEHNCKABOF()
	{
		MKELPFGCKKG = null;
	}

	public void APEMJIDMDKF()
	{
		MKELPFGCKKG = null;
	}

	[SpecialName]
	public static DecalSystem GLJHPPBFHIM()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	public void NDGBPMPNDCL()
	{
		MKELPFGCKKG = null;
	}

	protected override void Start()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void EBIILJGECPO(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 626f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1871f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.IJCCCDDONPF();
	}

	public void FMIDEIGFBHL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 800f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 606f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.OOPCOPCGODN();
	}

	[SpecialName]
	public static DecalSystem CILCHBNKDGE()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	public void GJPOMBEPHEP(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1301f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 786f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.LEHPHNHCLIL();
	}

	protected virtual void ODIBABNNECL()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	protected virtual void GECNMIJPLFE()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void DCLHMLOJEIJ()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void CCCPIJMLMFI()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void CJMCOCIIAEB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 568f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 358f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.InitDecal();
	}

	protected virtual void CFFHIADNNGA()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void MJHOAAEEAPH(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 673f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 674f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.IJCCCDDONPF();
	}

	public void IINLHBENDFE()
	{
		MKELPFGCKKG = null;
	}

	public void CPNAJAIPPEC(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 578f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1149f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.LEHPHNHCLIL();
	}

	protected virtual void BEJCAOCFGPH()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.FGJKPGPOHOP(LOPMDCPCCDL);
	}

	protected virtual void FCIDPPGMHMM()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.FGJKPGPOHOP(LOPMDCPCCDL);
	}

	[SpecialName]
	public static DecalSystem BEICHOKNMGJ()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	[SpecialName]
	public static DecalSystem BPBLFCMOBBE()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	[SpecialName]
	public static DecalSystem EFNANFHIHJN()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	protected virtual void OECHMKNNEHL()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void OnDestroy()
	{
		MKELPFGCKKG = null;
	}

	[SpecialName]
	public static DecalSystem JPJLBDOKDGB()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	public void JJADEFDGKNI()
	{
		MKELPFGCKKG = null;
	}

	public void ANEGICCOKFO(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1876f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1493f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.IJCCCDDONPF();
	}

	public void CAONPJLBODB()
	{
		MKELPFGCKKG = null;
	}

	public void DOJPAHGFBPN(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1783f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1352f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.PCNJGMMCDEL();
	}

	public void EAFAKALHKLM()
	{
		MKELPFGCKKG = null;
	}

	[SpecialName]
	public static DecalSystem LJECDKMBKBN()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	[SpecialName]
	public static DecalSystem HPLGCEABDDL()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	public void LBMOEBPGKGH(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1885f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1371f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.JAAMMPHODKL();
	}

	protected virtual void IDBHIEPOHHP()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	protected virtual void NBDOFMHBKFG()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	public void KPIGODNANLK()
	{
		MKELPFGCKKG = null;
	}

	public void INGOEDCPFII(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1482f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1552f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.BIAOOKLHMFL();
	}

	public void IMFDFBMDOBM()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void FMGDJJDEIML()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	protected virtual void KCCGPMHIHNG()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	[SpecialName]
	public static DecalSystem GDKJOJNBNNB()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	[SpecialName]
	public static DecalSystem JMHKALDBHLL()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	public void BLBJGEFHGDO()
	{
		MKELPFGCKKG = null;
	}

	[SpecialName]
	public static DecalSystem MLENAJOKJJP()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	[SpecialName]
	public static DecalSystem GNNECOIBNIA()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	public void FMCOPICKLEE(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1791f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1741f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.HCDIKBHONLO();
	}

	protected virtual void PONMLKPPAPG()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	[SpecialName]
	public static DecalSystem IGHANGHAEHG()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	public void PODLHNHBPGJ(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1308f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1583f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.HCDIKBHONLO();
	}

	public void BOJCENOBFHF(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1185f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1532f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.HHCGLHLAPOP();
	}

	public void IAMFHBPBEJB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1633f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1352f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.InitDecal();
	}

	public void GPPPLKJCLBN()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void NMBDIEBEFIG()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	public void GJLFBMOIBCE(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1807f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1262f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.InitDecal();
	}

	[SpecialName]
	public static DecalSystem NDHIOMJEMCL()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	protected virtual void LCCLOEDCGOP()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	public void NODJKLOHICN(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 604f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 612f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.LEHPHNHCLIL();
	}

	public void ADMBEFHCDDK(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 336f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1237f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.PCNJGMMCDEL();
	}

	protected virtual void JOKICBJJIOA()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.FGJKPGPOHOP(LOPMDCPCCDL);
	}

	public void PBBPHGLIIMG(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 337f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 822f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.JNFDPOLHLMA();
	}

	public void DOMNPGAGIPI(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1930f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1610f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.JAAMMPHODKL();
	}

	public void JDGAENDKCJO()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void GLNNBICCGPG()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.GetCountInPool(LOPMDCPCCDL);
	}

	[SpecialName]
	public static DecalSystem EEIOLHIBDJA()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	public void FLCJILGDBMO()
	{
		MKELPFGCKKG = null;
	}

	[SpecialName]
	public static DecalSystem LGNCCGPHABK()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)Object.FindObjectsOfType(typeof(DecalSystem))[1]);
		return MKELPFGCKKG;
	}

	public void OCPCLNEHCJA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1826f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 955f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.PCNJGMMCDEL();
	}

	protected virtual void BKPJIIBCOPF()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.FGJKPGPOHOP(LOPMDCPCCDL);
	}

	public void GJBKBJCGHLF()
	{
		MKELPFGCKKG = null;
	}

	public void PLFDMIILPDH(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 13f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 269f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.ENGIABMLKKB();
	}

	public void NMNMFOKKEGK()
	{
		MKELPFGCKKG = null;
	}

	public void HJKAHOBLBOH()
	{
		MKELPFGCKKG = null;
	}

	public void GMKGFAJCEDG(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1691f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 503f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.PCNJGMMCDEL();
	}

	public void HHFLCLPBBHJ(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1907f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1150f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.LEHPHNHCLIL();
	}

	public void KGHBMPBMCHA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 77f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1404f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.MLMEMHIIKMO();
	}

	public void AMANJJLDHCC()
	{
		MKELPFGCKKG = null;
	}

	protected virtual void AAEMHGDAGGM()
	{
		base.Start();
		NHEHMGKCFDG = DBDMKGIBKJC.CILANFDOOFP(LOPMDCPCCDL);
	}

	public void GDJJEKJLOFK(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 364f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1653f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.HCDIKBHONLO();
	}

	public void AFAOKMDAHHL()
	{
		MKELPFGCKKG = null;
	}

	public void PlayDecal(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 0.01f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 0.01f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.InitDecal();
	}

	public void IOEEBMJHNCB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (CFNHDBCKBGN.Count < NHEHMGKCFDG)
		{
			Decal decal = (Decal)Generate(LOPMDCPCCDL, MPHCNMDIPAI + 1562f * KDDGMMCPGLO, Quaternion.LookRotation(KDDGMMCPGLO));
			return;
		}
		Decal decal2 = (Decal)CFNHDBCKBGN.First.Value;
		decal2.transform.position = MPHCNMDIPAI + 1748f * KDDGMMCPGLO;
		decal2.transform.rotation = Quaternion.LookRotation(KDDGMMCPGLO);
		decal2.HHCGLHLAPOP();
	}

	public void AJLNLJCFOHL()
	{
		MKELPFGCKKG = null;
	}

	[SpecialName]
	public static DecalSystem JGHIIBJHDJO()
	{
		MKELPFGCKKG = MKELPFGCKKG ?? ((DecalSystem)SingletonSupport.FindOrCreate(typeof(DecalSystem)));
		return MKELPFGCKKG;
	}

	public void BJOIAFDNMNG()
	{
		MKELPFGCKKG = null;
	}

	public void PKKAKLGIEBA()
	{
		MKELPFGCKKG = null;
	}
}
