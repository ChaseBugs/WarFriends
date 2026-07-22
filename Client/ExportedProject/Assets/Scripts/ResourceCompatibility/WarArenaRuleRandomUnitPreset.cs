using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WarArenaRuleRandomUnitPreset : WarArenaRuleGeneric<WarArenaRuleRandomUnitPreset.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public List<UnitPreset> unitPresets;
	}

	private List<LevelBehaviour> mUnits;

	private int mRandomUnitPresetIndex;

	public override bool UseRuntimeParameters => false;

	protected override HIBLLEGMMEM ENNBBKNEMBH()
	{
		return null;
	}

	public override bool JPBAMFLFLFA()
	{
		return false;
	}

	private void LADLCMCICEA(int HJLEPKFGCHI)
	{
	}

	public override object[] JBFIDDLDEJI()
	{
		return null;
	}

	public override void FMNGBDBPGPI(object[] OLEGNKELNEA)
	{
	}

	private static List<LevelBehaviour> AAAOAIOBGEE(List<string> EKDBNFMLLNJ)
	{
		return null;
	}
}
