using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine.Scripting;

[Preserve]
public abstract class WeaponFeature
{
	public virtual string typeName => null;

	public ObscuredFloat value { get; private set; }

	public ObscuredFloat dpsCoef { get; protected set; }

	public ObscuredFloat attackCoef { get; protected set; }

	public int index { get; protected set; }

	public virtual float clipSizeCoef => 0f;

	public virtual float reloadCoef => 0f;

	public virtual float damageCoef => 0f;

	public virtual float criticalCoef => 0f;

	public virtual int burstAdd => 0;

	public virtual float ammoCoef => 0f;

	public virtual float rateOfFireCoef => 0f;

	public virtual float accuracyCoef => 0f;

	public virtual float shotVelocityCoef => 0f;

	public virtual bool hasAnyModification => false;

	public virtual string name => null;

	public virtual string fancyName => null;

	public virtual string icon => null;

	public virtual bool menuMainAtlas => false;

	public virtual string description => null;

	public virtual string statisticIncrease => null;

	public virtual string weaponPrefix => null;

	public virtual string Statistic(WeaponLevelsSetup weapon)
	{
		return null;
	}

	public virtual string StatisticIncrease(WeaponLevelsSetup weapon)
	{
		return null;
	}

	public virtual int CompareTwoWeapons(WeaponLevelsSetup weapon1, WeaponLevelsSetup weapon2)
	{
		return 0;
	}

	public WeaponFeature()
	{
	}

	public void Init(ObscuredFloat value, ObscuredFloat dpsCoef, ObscuredFloat dmgCoef, int index)
	{
	}
}
