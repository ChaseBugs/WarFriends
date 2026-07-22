using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WarArenaRuleRandomWeaponPreset : WarArenaRuleGeneric<WarArenaRuleRandomWeaponPreset.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public List<WeaponPreset> weaponPresets;
	}

	private List<WeaponLevelsSetup> mWeapons;

	private int mRandomWeaponPresetIndex;

	public override bool UseRuntimeParameters => false;

	protected override HIBLLEGMMEM ENNBBKNEMBH()
	{
		return null;
	}

	public override bool JPBAMFLFLFA()
	{
		return false;
	}

	private void LADLCMCICEA(int FPDOADLEHBI)
	{
	}

	public override object[] JBFIDDLDEJI()
	{
		return null;
	}

	public override void FMNGBDBPGPI(object[] OLEGNKELNEA)
	{
	}

	private static List<WeaponLevelsSetup> JGMELGJAJHE(List<string> FADAJLFDGFN)
	{
		return null;
	}
}
