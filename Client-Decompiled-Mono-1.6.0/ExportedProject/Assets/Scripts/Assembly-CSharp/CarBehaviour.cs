using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CarBehaviour : CarBehaviourG<CarBehaviourDefinititon>
{
	public CarBehaviourDefinititon carBehaviourDefinititon
	{
		get
		{
			return (CarBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	[SpecialName]
	public void AIMCHOOGOJO(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool GHAJCILBFAK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.JCFMEBFCGJI() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public void IGHNNJKELOD(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool MLHJFAGGCJF(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.NJCLPJKLPFN() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public CarBehaviourDefinititon ONFFBDBGLBL()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon LKMCNMHOHCL()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool IAMBOGBBDGI(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.DJFHPICBAIM() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return false;
	}

	public virtual bool FIALPJMOJCG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.fraction == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return false;
	}

	public virtual bool GKEKLCLHHNI(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.ANHBFEDCPCA() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public void LKKCMHHPHJN(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon HHDHFIPJGNP()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon OEDCHCGJOIG()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon KDKHFDENKDA()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon PNEKGALOFCJ()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool CMPLMBDGDBC(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.JCFMEBFCGJI() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public CarBehaviourDefinititon BDJAHILMEAA()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void NCEACOGHBEO(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void PNAKNIFCPII(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool FPIPBOKMNPB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.GBMACONCODL() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public CarBehaviourDefinititon AJMJGJOGBHC()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool MJMGLGKPHAE(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.LIDLAMJCPAO() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public CarBehaviourDefinititon AEHIENAJDLM()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void OPBHHFIEPCA(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon LDKAMIJCEFH()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon BCLKFMFJEMA()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool GHGHLGDHHAO(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.JCFMEBFCGJI() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public void NNMMKDHMBMC(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon JDJPHKFFGKD()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon DKCMFKLAGOF()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void IGAKPJJBDFH(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon JAEEHKOFEIH()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool HHINACEBEDG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.IMHAFCPPPIJ() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public void BHHJHIFPODM(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool KHJLBJNNBJO(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.NJCLPJKLPFN() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public void AMOOMJLGHMG(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool LPIAFFJHLEP(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.CJPHCHPDCOK() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return true;
	}

	public virtual bool DFABNKCLICE(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.ABMCHNDOMGG() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public void BJBABLACCAB(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CAGODIJMNDO(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool HCKMABBPOHB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.GBMACONCODL() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return true;
	}

	public virtual bool AMEJNHBFMEH(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.GBMACONCODL() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public CarBehaviourDefinititon JJKADFBHAFB()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void HOEHNHJMCDI(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void JPBHIHJDMKM(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon BOLKLBLLEAA()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public CarBehaviourDefinititon NAILHGJFJBH()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void DLIDCDHBEPK(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EEMKELDJLAP(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void DPFOBODDNIP(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon OLKMMBNBEOB()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool GGLAFEMIKGK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.DJFHPICBAIM() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public void BGNDNDLNIIP(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EFALCDLLCBI(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon KANLNGPNLPL()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool MBNGMFLAIFG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.OBFMCBNEBHD() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public void DFEKFHABMJA(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool BDBENOPBIBH(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.NHLDLEOIHMJ() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return false;
				}
			}
		}
		return true;
	}

	[SpecialName]
	public void JAFKOGFDADK(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool HNKBFNMAKJB(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.IPJOMHKDPKC() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return true;
	}

	public override bool CanBeSpawned(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.fraction == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual bool CGKGJEFDDGF(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN != null)
		{
			List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
			foreach (SpawnPoint item in lIAEIIFPONK)
			{
				SpawnPointCar spawnPointCar = (SpawnPointCar)item;
				if (item.IPJOMHKDPKC() == ACJIGOBMLNH && spawnPointCar.PODMFKMOJML == null)
				{
					return true;
				}
			}
		}
		return false;
	}

	[SpecialName]
	public CarBehaviourDefinititon GNHKOAEKHCL()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void LCOGICGLIAI(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GICJAKLIKMK(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void IPJAJONHFIP(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public CarBehaviourDefinititon POOBBDJPCMN()
	{
		return (CarBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void CGLEPINIINC(CarBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}
}
