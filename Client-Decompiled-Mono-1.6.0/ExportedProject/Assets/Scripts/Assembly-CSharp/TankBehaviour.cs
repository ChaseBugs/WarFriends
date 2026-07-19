using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class TankBehaviour : TankBehaviourG<TankBehaviourDefinititon>
{
	public TankBehaviourDefinititon tankBehaviourDefinititon
	{
		get
		{
			return (TankBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	[SpecialName]
	public TankBehaviourDefinititon HDBMBJIGLAN()
	{
		return (TankBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual bool BFHFIHMNKNG(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
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
	public void JPCEEHJHFPJ(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void CCAMKLHJBFD(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public TankBehaviourDefinititon BGHFNDONBHC()
	{
		return (TankBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public TankBehaviourDefinititon BDDGHLDAOFP()
	{
		return (TankBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void GLADJJBHPLD(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public TankBehaviourDefinititon ADJCPDPCEME()
	{
		return (TankBehaviourDefinititon)base.behaviourDefinition;
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

	[SpecialName]
	public void HPIKDLGEMOI(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual bool OKLCPOODICA(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
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
		return false;
	}

	public virtual bool KBHFNDOBFKK(GHPGNELIDBM ACJIGOBMLNH, int CEFIMGIDADI)
	{
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointVehicle spawnPointVehicle = (SpawnPointVehicle)item;
			if (item.OMNFCJBMMNL() == ACJIGOBMLNH && spawnPointVehicle.PODMFKMOJML == null)
			{
				return false;
			}
		}
		return false;
	}

	[SpecialName]
	public void CLBJHMCMACP(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public TankBehaviourDefinititon NCOOFGKGBEK()
	{
		return (TankBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void BGFGDMONAHH(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void LNLKDANEMME(TankBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}
}
