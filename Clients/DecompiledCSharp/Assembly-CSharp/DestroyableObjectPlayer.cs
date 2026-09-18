using Google2u;

public class DestroyableObjectPlayer : DestroyableObjectMultipleParts
{
	protected override bool playParticles => health > 0f;

	public override bool DoDamage(DamageInfo info, DestroyableObject obj)
	{
		if ((info.type == DamageType.Shot || info.type == DamageType.Explosion || info.type == DamageType.Shiver) && !info.isNetwork && info.weapon != null)
		{
			float num = ((!Singleton<MatchManager>.instance.isOverTime) ? info.weapon.ammoSetup.damageToPlayerCoeficient : info.weapon.ammoSetup.damageToPlayerOvertimeCoeficient);
			info.damageAmount *= num;
		}
		if ((info.type == DamageType.Explosion || info.type == DamageType.Shiver) && !info.isNetwork && info.weapon == null)
		{
			float num2 = ((!Singleton<MatchManager>.instance.isOverTime) ? Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PlayerExplosiveCoef).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PlayerExplosiveOvertimeCoef).FLOATVALUE);
			info.damageAmount *= num2;
		}
		return base.DoDamage(info, obj);
	}
}
