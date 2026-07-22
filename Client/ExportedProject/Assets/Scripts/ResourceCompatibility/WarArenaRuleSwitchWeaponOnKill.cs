using System;
using UnityEngine;

[CreateAssetMenu]
public class WarArenaRuleSwitchWeaponOnKill : WarArenaRuleGeneric<WarArenaRuleSwitchWeaponOnKill.Data>
{
	[Serializable]
	public class Data : RuleData
	{
	}

	private const int MinWeaponSwitchFrameDelta = 5;

	private int _lastWeaponSwitchFrameCount;

	protected override HIBLLEGMMEM ENNBBKNEMBH()
	{
		return null;
	}

	public override bool JPBAMFLFLFA()
	{
		return false;
	}

	public override void BMDEHIIDPEO()
	{
	}

	public override void EJNLCODCGBA()
	{
	}

	private void NAEAMEOHHAI(AIObject FKJGHEFHPKE, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public override void ECGLNFGFDHI(GameControllerWarArena DDEJOBGOOBF)
	{
	}

	private void JPKMINBMCOI()
	{
	}

	private static bool ICFKKLECEHK(PlayerWeapon KJHDNCCBCOO)
	{
		return false;
	}
}
