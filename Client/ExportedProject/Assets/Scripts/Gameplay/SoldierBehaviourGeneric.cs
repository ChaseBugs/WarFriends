using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
[RequireComponent(typeof(EnemyBasicInventory))]
public class SoldierBehaviourGeneric<T> : SoldierBehaviour where T : SoldierBehaviourDefinititon
{
	[FormerlySerializedAs("PNDGJKHJEOD")]
	public T OLCJKFMGKAJ;

	public override SoldierBehaviourDefinititon soldierBaseDefinition
	{
		get
		{
			return OLCJKFMGKAJ;
		}
		set
		{
		}
	}

	protected T KKOCPACHJII => (T)base.behaviourDefinition;

	public override BehaviourDefinititon baseBehaviourDefinititon => soldierBaseDefinition;

	[SpecialName]
	public virtual SoldierBehaviourDefinititon IGIOFFFNCIE()
	{
		return OLCJKFMGKAJ;
	}

	public virtual void AFBBNOFJJCP(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		IIMDKHJAJGO.gameObject.DNLHKBBNICM(component);
	}

	[SpecialName]
	public virtual BehaviourDefinititon MOJNNEMAEKD()
	{
		return soldierBaseDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon OBGKCDHIMDI()
	{
		return soldierBaseDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon NAHJHBEHNBI()
	{
		return soldierBaseDefinition;
	}

	public override void Copy(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		IIMDKHJAJGO.gameObject.DNLHKBBNICM(component);
	}

	[SpecialName]
	public virtual void AHPMNEBJABL(SoldierBehaviourDefinititon IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public virtual BehaviourDefinititon CGAANAGLLIK()
	{
		return soldierBaseDefinition;
	}

	[SpecialName]
	public virtual SoldierBehaviourDefinititon IDLBGGCKFHJ()
	{
		return OLCJKFMGKAJ;
	}

	[SpecialName]
	public virtual SoldierBehaviourDefinititon MPECOCPBBKB()
	{
		return OLCJKFMGKAJ;
	}

	public virtual void JPDIDMEPFCM(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		IIMDKHJAJGO.gameObject.DNLHKBBNICM(component);
	}

	public virtual void CNGKOLEBEIN(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		IIMDKHJAJGO.gameObject.DNLHKBBNICM(component);
	}

	[SpecialName]
	public virtual BehaviourDefinititon CELLHPNNEPL()
	{
		return soldierBaseDefinition;
	}

	public virtual void CGPBMFGCAFC(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		IIMDKHJAJGO.gameObject.DNLHKBBNICM(component);
	}

	[SpecialName]
	public virtual SoldierBehaviourDefinititon LBPLPKOOOFM()
	{
		return OLCJKFMGKAJ;
	}

	[SpecialName]
	public virtual void NAGDFNFPOKH(SoldierBehaviourDefinititon IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public virtual BehaviourDefinititon IPEAGALJLGA()
	{
		return soldierBaseDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon CFBEMCNLEAB()
	{
		return soldierBaseDefinition;
	}

	public virtual void KOAEOBLLNEP(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		EnemyBasicInventory component = GetComponent<EnemyBasicInventory>();
		IIMDKHJAJGO.gameObject.DNLHKBBNICM(component);
	}
}
