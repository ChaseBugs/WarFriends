using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class Perk
{
	public ObscuredFloat hpCoef = 1f;

	public ObscuredFloat accuracyCoef = 1f;

	public ObscuredFloat shotSpeedCoef = 1f;

	public ObscuredFloat speedCoef = 1f;

	public int buffCount;

	public int debuffCount;

	private Perk MultipleBy(Perk multiplier)
	{
		Perk perk = new Perk();
		perk.hpCoef = (float)hpCoef * (float)multiplier.hpCoef;
		perk.accuracyCoef = (float)accuracyCoef * (float)multiplier.accuracyCoef;
		perk.shotSpeedCoef = (float)shotSpeedCoef * (float)multiplier.shotSpeedCoef;
		perk.speedCoef = (float)speedCoef * (float)multiplier.speedCoef;
		perk.buffCount = buffCount + multiplier.buffCount;
		perk.debuffCount = debuffCount + multiplier.debuffCount;
		return perk;
	}

	public override string ToString()
	{
		return $"HP: {hpCoef} ACC: {accuracyCoef} SHS: {shotSpeedCoef}SP: {speedCoef}";
	}

	public int GetBuffCount(PerkType perkType)
	{
		return Mathf.Clamp((perkType != PerkType.Buff) ? debuffCount : buffCount, 0, 4);
	}

	public static Perk operator *(Perk one, Perk two)
	{
		return one.MultipleBy(two);
	}
}
