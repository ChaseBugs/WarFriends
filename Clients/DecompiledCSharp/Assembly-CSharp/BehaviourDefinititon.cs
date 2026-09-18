using System;
using CodeStage.AntiCheat.ObscuredTypes;

[Serializable]
public abstract class BehaviourDefinititon
{
	public ObscuredFloat health = 100f;

	public ObscuredFloat damage = 0f;

	public float speed = 0.8f;

	public float shotSpeed = 5f;

	public virtual void LoadZeros()
	{
		health = 0f;
		damage = 0f;
	}

	public BehaviourDefinititon Copy()
	{
		return (BehaviourDefinititon)MemberwiseClone();
	}

	public abstract BehaviourDefinititon Interpolate(BehaviourDefinititon d1, BehaviourDefinititon d2, float ratio);

	public virtual void ScaleDamageAndHP(float damageFactor, float hpFactor)
	{
		health = (float)health * hpFactor;
		damage = (float)damage * damageFactor;
	}

	public virtual void ScaleByPerk(Perk perk)
	{
		health = (float)health * (float)perk.hpCoef;
		shotSpeed *= perk.shotSpeedCoef;
		speed *= perk.speedCoef;
	}
}
