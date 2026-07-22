using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.Scripting;

public class SuperChargedUnitsManager : DatabaseSerializedObjectGeneric<SuperChargedUnitsManager.SuperChargedUnitsData>
{
	public enum LCMFNLCGCKH
	{
		ExtraAbility,
		StatBoost,
		DefenseBoost,
		RewardBonus
	}

	public enum NEFLDBDJGFH
	{
		ExtraHealthAndDamage,
		MatchHighestUpgradedUnit,
		PoisonDamage,
		ShorterCooldown,
		ExtraWarbucks,
		FreezeEnemy,
		SpawnWithKevlar,
		ElitePerkBoost,
		SpecialAbilityBoost,
		FireDamage,
		Heal,
		SlowDown,
		ImmortalityChance
	}

	public enum MJJHJGCJDAF
	{
		CurrentTierMax,
		NextTierMax,
		NextNextTierMax
	}

	[Preserve]
	public class SuperChargedUnitsData
	{
		public List<SuperChargedUnit> superchargedUnits;

		public int deadline;

		public bool showDialog;

		public string PrintSuperChargedUnits()
		{
			return null;
		}
	}

	[Serializable]
	[Preserve]
	public class SuperChargedUnit
	{
		public string unitName;

		public int effectId;

		public List<float> effectParams;

		public NEFLDBDJGFH effectType
		{
			get
			{
				return default(NEFLDBDJGFH);
			}
			set
			{
			}
		}
	}

	public static readonly Dictionary<LCMFNLCGCKH, string> NKHALEGEAJD;

	public static readonly Dictionary<LCMFNLCGCKH, Color> PHEBLNCMKFL;

	private static SuperChargedUnitsManager DJDBDKFAKHN;

	private SuperchargedUnitEffects KDBFHENPAGO;

	public List<ACNGDCINJEP> PBLOMHBFPPD;

	public static SuperChargedUnitsManager instance => null;

	public int deadline => 0;

	public bool isPoolActive => false;

	public bool showDialog => false;

	public List<SuperChargedUnit> superUnits => null;

	protected override void Awake()
	{
	}

	public SuperchargedUnitEffectsRow GetEffectCategory(NEFLDBDJGFH JPJLBLFBIGE)
	{
		return null;
	}

	public string GetEffectName(LevelBehaviour NGEDOMFLLKI)
	{
		return null;
	}

	public string GetHint(LevelBehaviour NGEDOMFLLKI)
	{
		return null;
	}

	private ACNGDCINJEP NGLDDNDLLML(PlayerController GDMBMAPOKCL, SuperChargedUnit FJKJDKOIMHA)
	{
		return null;
	}

	private ACNGDCINJEP FMLCLOKBPJN(PlayerController GDMBMAPOKCL, SuperChargedUnit FJKJDKOIMHA)
	{
		return null;
	}

	private void DJIKBALBFCM()
	{
	}

	private void DOLCIIEMHLB()
	{
	}

	private void HCOCHDHHLPC(GameController.ALOAMODMHMO KIHIFIBOOIM)
	{
	}

	private void JBIABKOCKJH(PlayerController BPBMHENPDIA)
	{
	}

	public bool IsSuperChargedUnit(LevelBehaviour NGEDOMFLLKI)
	{
		return false;
	}

	public string GetCategoryNameForUnit(LevelBehaviour NGEDOMFLLKI)
	{
		return null;
	}

	public Color GetCategoryColorForEffect(NEFLDBDJGFH AHFBNJHCANA)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Color);
	}

	public Color GetCategoryColorForUnit(LevelBehaviour NGEDOMFLLKI)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Color);
	}

	public bool HasSuperChargedWbBoost()
	{
		return false;
	}
}
