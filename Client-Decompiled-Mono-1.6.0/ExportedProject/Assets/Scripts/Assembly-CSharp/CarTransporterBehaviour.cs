using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CarTransporterBehaviour : CarTransporterBehaviourG<CarTransporterBehaviourDefinititon>
{
	public CarTransporterBehaviourDefinititon carTransporterBehaviourDefinititon
	{
		get
		{
			return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public virtual bool LHKHJLHDEPP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.PPMHBMNCMCA() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return true;
			}
		}
		return true;
	}

	public virtual bool HCKMABBPOHB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.ANHBFEDCPCA() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	public virtual bool HMOLFAFKPCG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.fraction == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon LDKLEMNGKMF()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon NBMLJHLGKME()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool DOMCLNKKHEB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.LIDLAMJCPAO() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	public virtual bool KGJJFCIFLLB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.JLLFKJHLLHM() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	[SpecialName]
	public void CMJIGEADJAO(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon MMHDGGLKHCA()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool HLMNEBBPJFG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.LIDLAMJCPAO() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	public virtual bool OIOIGOBAOMN(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.OBFMCBNEBHD() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public void PBEMENEODOG(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool MJMGLGKPHAE(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.PPMHBMNCMCA() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public void AKGDBFCOIGN(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon LGPOHLDIKNK()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool BONLOGDNNBP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.DJFHPICBAIM() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return true;
			}
		}
		return true;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon AMFOFKBJLBC()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void FADFDEPGOIH(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon NEEKJLMMJOE()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon IHHOHMCAFLO()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon IECIICHOIKJ()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void IFOEJFAHLCH(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BGKCDMDDBPO(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void LKEJKKJNHMH(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon HKMBOBGCMCB()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool GGLAFEMIKGK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.IMHAFCPPPIJ() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon KDILGMAOLLF()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void LDCMMABGPLN(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BECMEECKBNM(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon KNJDACBPFOC()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon GACPAFNOAPF()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void HJDCOEFJIHH(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon NEGCBJPLIAB()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void PBKCLAJEICD(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CHMNLEINCDC(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EJEBGLNKAKH(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon BCHOCFPLPGL()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon MFFCGMIBLBK()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void FDJLBCOAPLC(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JCIDCDLEHKF(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BEOGLGMDELB(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool GBCDICCLBKJ(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.DJFHPICBAIM() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	[SpecialName]
	public void AKAHHOLKIIE(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void DMPHKOLIJMK(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon EAHNAILAILC()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void JLJAKGALCHH(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool FIALPJMOJCG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.fraction == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	public virtual bool FPNHKPIFJCP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.CJPHCHPDCOK() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon EKNEADCFDJM()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void AJNJHKGKCNA(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool OKLCPOODICA(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.NHLDLEOIHMJ() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return true;
			}
		}
		return false;
	}

	[SpecialName]
	public void PCEBCILEFCD(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon JMJLBDCCBGL()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon KEDLNEOHLAK()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void KCFNDEPGBHI(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon KJKAECKLDLB()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool MHOJBIDLOGD(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.ABMCHNDOMGG() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon EILJBMDGGBB()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public override bool CanBeSpawned(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.fraction == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool CBJAEAGOGMD(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.IMHAFCPPPIJ() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	[SpecialName]
	public void FJBMDFMMMDG(CarTransporterBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon PDFDHPAIJOG()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool EADNCAFHCHC(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.AHFOPAOPBDF() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return true;
			}
		}
		return true;
	}

	public virtual bool PBCODEPBCLN(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.DJEPLLFFBEC() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return true;
			}
		}
		return false;
	}

	public virtual bool IAFBMIIIJKG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.NHLDLEOIHMJ() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon KMFALEIINPH()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon APCAPJFEPDO()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon KKMOFHIDBMO()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool CDPLCGKLMLO(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.NHLDLEOIHMJ() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	[SpecialName]
	public CarTransporterBehaviourDefinititon LDCBCMECIBL()
	{
		return (CarTransporterBehaviourDefinititon)base.behaviourDefinition;
	}
}
