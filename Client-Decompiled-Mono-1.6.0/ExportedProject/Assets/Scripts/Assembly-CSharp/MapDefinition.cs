using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapDefinition : MonoBehaviour
{
	[Serializable]
	public class DefendPosition
	{
		public PlayerPoint point;

		public GHPGNELIDBM fraction;

		public CameraPathAnimator cameraPath;

		public bool mainPosition;

		public int index;
	}

	public Texture2D CEDJDLLEPLL;

	public Texture2D FHELOHFCHDO;

	public SpawnPointsCollection DMCDJGLDICM;

	public EnemyPointsCollection EJEEMOCCGPH;

	public string KMJGIGDJKMH;

	public SpawnPointsCollection NOKEEDNGHJC;

	public SpawnPointsCollection NELLCLDMJNE;

	public SpawnPointsCollection GOFHHIBNPEN;

	public SpawnPointsCollection LJNGPLLBOHO;

	public Transform NOKCDKMHLJG;

	public List<DefendPosition> BBJMLOCKNHD;

	public List<BoxCollider> NHGHLADBCAN;

	public BoxCollider CMJBHHBKKAF;

	public bool DEOEJNHNING;

	public Plane DPPAFFPMKCG;

	public bool JBCHDHOOBCO;

	public List<DefendPosition> availablePoints
	{
		get
		{
			return BBJMLOCKNHD;
		}
	}

	[SpecialName]
	public List<DefendPosition> GDNIEHIBOFG()
	{
		return BBJMLOCKNHD;
	}

	public void InitShields()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.shield.Init();
		}
	}

	public void KHECNEENABH()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PKBPGCGNCAD().MAHAHDCEJFH();
		}
	}

	public void PNDOGAPCHMJ()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.LHHMNLJKOAO().GPKEFODONHK(defendPosition.fraction);
		}
	}

	public void KPLNLMHLBII()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.shield.JMILGBBIGCF();
		}
	}

	public void AJAKDLHHFFO()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.shield.GPKEFODONHK(defendPosition.fraction);
		}
	}

	private void JLHNGHEOIGL()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void JNKCJFIPAED()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PKBPGCGNCAD().JMILGBBIGCF();
		}
	}

	private void HEJKGFPPIDC()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	[SpecialName]
	public List<DefendPosition> ADKJKHAHCJD()
	{
		return BBJMLOCKNHD;
	}

	private void IGOMLJOMFGA()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void OPPKNICNNHF()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PKBPGCGNCAD().fraction = defendPosition.fraction;
		}
	}

	private void GIMOILKEFEO()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	[SpecialName]
	public List<DefendPosition> PBOGDIJIHGP()
	{
		return BBJMLOCKNHD;
	}

	private void KIADANJAIOB()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void IBLPGJOHIAE()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	[SpecialName]
	public List<DefendPosition> OKDMKFBACGD()
	{
		return BBJMLOCKNHD;
	}

	private void DKMHPLCCLKI()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void HNLOEOJMMJM()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void CIDFCJJMFHO()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.CGKKGILAAPG().Init();
		}
	}

	public void ABPDKPKJDIA()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.JPHAJDIIAAI().GPKEFODONHK(defendPosition.fraction);
		}
	}

	public void PFAJIIKAJDM()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PKBPGCGNCAD().JMILGBBIGCF();
		}
	}

	public void DMFBLJDLOBH()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.CGKKGILAAPG().Init();
		}
	}

	public void DLBNDBMLEIC()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.JPHAJDIIAAI().Init();
		}
	}

	public void EDPLJGHIHAP()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.KJCHIHLJMMF().GPKEFODONHK(defendPosition.fraction);
		}
	}

	private void IKCLJIAJAIL()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void JGFKONKLEAG()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void MFKNMALEKKB()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void NBENLPACMEA()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.LMHDAIBCLDP().Init();
		}
	}

	private void KALEMFKOGLE()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	[SpecialName]
	public List<DefendPosition> JCAHHLHKIBN()
	{
		return BBJMLOCKNHD;
	}

	[SpecialName]
	public List<DefendPosition> DGHFCDMHBIM()
	{
		return BBJMLOCKNHD;
	}

	public void MBGMOJIENFI()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.IGEDGCNJCAP().Init();
		}
	}

	[SpecialName]
	public List<DefendPosition> BPFHGFFNMND()
	{
		return BBJMLOCKNHD;
	}

	public void PLEFHIGAKOD()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PNKKPNIMEPL().fraction = defendPosition.fraction;
		}
	}

	public void CIFFCNPEOOD()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PKBPGCGNCAD().fraction = defendPosition.fraction;
		}
	}

	public void EKKILJDOHBJ()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.KJCHIHLJMMF().fraction = defendPosition.fraction;
		}
	}

	public void COPNHHBDBAE()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.shield.MAHAHDCEJFH();
		}
	}

	public void OMADJCKIAMD()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PNKKPNIMEPL().fraction = defendPosition.fraction;
		}
	}

	public void NIBDIENPOJI()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.LHHMNLJKOAO().GPKEFODONHK(defendPosition.fraction);
		}
	}

	[SpecialName]
	public List<DefendPosition> OKBGNPFGPCD()
	{
		return BBJMLOCKNHD;
	}

	private void PIIFEPFCOJF()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void LGHCHIFNCCJ()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PKBPGCGNCAD().fraction = defendPosition.fraction;
		}
	}

	public void DOPDENIGNIL()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.CGKKGILAAPG().JMILGBBIGCF();
		}
	}

	public void OEIKEEBDLFF()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.CGKKGILAAPG().GPKEFODONHK(defendPosition.fraction);
		}
	}

	private void MNAJGMAFJGL()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void MNGEJBAKJED()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PKBPGCGNCAD().MAHAHDCEJFH();
		}
	}

	[SpecialName]
	public List<DefendPosition> FOKIJHBHGJH()
	{
		return BBJMLOCKNHD;
	}

	public void HIHAPFGDIGP()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.LHHMNLJKOAO().fraction = defendPosition.fraction;
		}
	}

	public void GGNHEDKHONC()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.KJCHIHLJMMF().fraction = defendPosition.fraction;
		}
	}

	public void LOEMAHMHKBM()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.LMHDAIBCLDP().Init();
		}
	}

	public void NAAKAGMMCDG()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PHANADCNBFD().Init();
		}
	}

	[SpecialName]
	public List<DefendPosition> BMPBPOGCGGF()
	{
		return BBJMLOCKNHD;
	}

	public void JAMGMMLNGKD()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PKBPGCGNCAD().GPKEFODONHK(defendPosition.fraction);
		}
	}

	public void JGAHDJCJBMO()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PHANADCNBFD().GPKEFODONHK(defendPosition.fraction);
		}
	}

	[SpecialName]
	public List<DefendPosition> DFFPKLEEKKK()
	{
		return BBJMLOCKNHD;
	}

	public void NMBGIOAFPIM()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.IGEDGCNJCAP().JMILGBBIGCF();
		}
	}

	private void JFDOGLFMHAE()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void OBPDFCOPCMK()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void PGFLFHIKFDJ()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void GLABAFIAJBC()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PNKKPNIMEPL().JMILGBBIGCF();
		}
	}

	[SpecialName]
	public List<DefendPosition> JCPPFKEIAFM()
	{
		return BBJMLOCKNHD;
	}

	public void CDDDGIHAEMA()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.shield.GPKEFODONHK(defendPosition.fraction);
		}
	}

	[SpecialName]
	public List<DefendPosition> MNKKJJADINL()
	{
		return BBJMLOCKNHD;
	}

	private void OBPMHHGJFEL()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void FGBMOLONAOC()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.JPHAJDIIAAI().GPKEFODONHK(defendPosition.fraction);
		}
	}

	public void BLFGPPBCAGG()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.CGKKGILAAPG().Init();
		}
	}

	[SpecialName]
	public List<DefendPosition> GLOJOGJIEBE()
	{
		return BBJMLOCKNHD;
	}

	public void HGICKKMBFEM()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PNKKPNIMEPL().GPKEFODONHK(defendPosition.fraction);
		}
	}

	private void FGOGGLDAKHL()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void ABMKKECEGIB()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void PLKIAPHIICM()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.LMHDAIBCLDP().GPKEFODONHK(defendPosition.fraction);
		}
	}

	[SpecialName]
	public List<DefendPosition> PMKDPIHBOBN()
	{
		return BBJMLOCKNHD;
	}

	public void FIMOBBBJKLL()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.JPHAJDIIAAI().fraction = defendPosition.fraction;
		}
	}

	private void EDFDLKAFBBI()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void Init()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.shield.fraction = defendPosition.fraction;
		}
	}

	[SpecialName]
	public List<DefendPosition> DLPPKPNJFIK()
	{
		return BBJMLOCKNHD;
	}

	private void CIGLDDGDAPM()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void ICDDIOINMKC()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.shield.MAHAHDCEJFH();
		}
	}

	public void HHPNJEEHNEA()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PNKKPNIMEPL().JMILGBBIGCF();
		}
	}

	public void FDFHOFACMGH()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.LHHMNLJKOAO().JMILGBBIGCF();
		}
	}

	[SpecialName]
	public List<DefendPosition> CJKAPGGJLLK()
	{
		return BBJMLOCKNHD;
	}

	public void NCHJOPBEHAK()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.KJCHIHLJMMF().IKGGPCBEJIA();
		}
	}

	public void LDMHFLANOGJ()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.shield.MAHAHDCEJFH();
		}
	}

	public void HNHJLLMGEIJ()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PNKKPNIMEPL().fraction = defendPosition.fraction;
		}
	}

	public void AGENDJAEALE()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.shield.MAHAHDCEJFH();
		}
	}

	private void JJBODEPAMBI()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void FBAJEOKGBLM()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.CGKKGILAAPG().Init();
		}
	}

	private void EALPHOPMAMP()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	[SpecialName]
	public List<DefendPosition> MIIAMFDOKIP()
	{
		return BBJMLOCKNHD;
	}

	public void BLAPACPOJBF()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.JPHAJDIIAAI().IKGGPCBEJIA();
		}
	}

	private void EKEHGBNPAFC()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void IEBHCNFALAB()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void HCDNNGFBJOE()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void MDMDKMGCNGE()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.LMHDAIBCLDP().GPKEFODONHK(defendPosition.fraction);
		}
	}

	public void CECKOMHKHEB()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.PNKKPNIMEPL().JMILGBBIGCF();
		}
	}

	[SpecialName]
	public List<DefendPosition> MEELGBBFEFH()
	{
		return BBJMLOCKNHD;
	}

	private void HLBLKFLJEIG()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void HMBBGNKFNCK()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	[SpecialName]
	public List<DefendPosition> HNPHEEHLNDB()
	{
		return BBJMLOCKNHD;
	}

	private void FFBBKELEEIF()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void NGKAAMGLFKC()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.PKBPGCGNCAD().GPKEFODONHK(defendPosition.fraction);
		}
	}

	private void KINHAJCDKGN()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void MPBNEKHIGFF()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.point.IGEDGCNJCAP().JMILGBBIGCF();
		}
	}

	[SpecialName]
	public List<DefendPosition> KLIMIPLCAIB()
	{
		return BBJMLOCKNHD;
	}

	private void Awake()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	private void DIGKJHCNNIP()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void GIDHOLEBGAE()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.JPHAJDIIAAI().GPKEFODONHK(defendPosition.fraction);
		}
	}

	[SpecialName]
	public List<DefendPosition> DINMFFDBPBG()
	{
		return BBJMLOCKNHD;
	}

	[SpecialName]
	public List<DefendPosition> IJDLIIBLLJO()
	{
		return BBJMLOCKNHD;
	}

	[SpecialName]
	public List<DefendPosition> DJGINOBOEPA()
	{
		return BBJMLOCKNHD;
	}

	private void FANDCCNILLD()
	{
		base.gameObject.tag = TagsAndLayers.BCOCLOGHEBA;
		DPPAFFPMKCG = new Plane(Vector3.up, NOKCDKMHLJG.position);
	}

	public void FEMBKPGEHEB()
	{
		for (int i = 1; i < BBJMLOCKNHD.Count; i++)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.CGKKGILAAPG().fraction = defendPosition.fraction;
		}
	}

	public void HNKOCDDPLEN()
	{
		for (int i = 0; i < BBJMLOCKNHD.Count; i += 0)
		{
			DefendPosition defendPosition = BBJMLOCKNHD[i];
			defendPosition.index = i;
			defendPosition.point.shield.fraction = defendPosition.fraction;
		}
	}
}
