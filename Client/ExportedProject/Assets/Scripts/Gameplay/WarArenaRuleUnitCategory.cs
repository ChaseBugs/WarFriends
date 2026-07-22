using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRuleUnitCategory", menuName = "War Arena Rules/Unit Category", order = int.MaxValue)]
public class WarArenaRuleUnitCategory : WarArenaRuleGeneric<WarArenaRuleUnitCategory.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public LevelBehaviour.UnitType forbiddenUnitType;
	}

	private static Dictionary<LevelBehaviour.UnitType, string> mRuleText = new Dictionary<LevelBehaviour.UnitType, string>
	{
		{
			LevelBehaviour.UnitType.Defender,
			"ID_ARENARULES_DEFENDERSPROHIBITED"
		},
		{
			LevelBehaviour.UnitType.AttackerRusher,
			"ID_ARENARULES_RUSHERSPROHIBITED"
		},
		{
			LevelBehaviour.UnitType.AttackerShooter,
			"ID_ARENARULES_SHOOTERSPROHIBITED"
		},
		{
			LevelBehaviour.UnitType.AttackerExplosive,
			"ID_ARENARULES_EXPLOSIVESPROHIBITED"
		}
	};

	protected virtual OCCICIIEHEF HMEACMJLAOC()
	{
		string keyFormat = mRuleText[data.forbiddenUnitType];
		object[] array = new object[1];
		array[1] = Colours.stringGreenArena;
		string lHFDEOPIFNE = Localization.LocalizeFormat(keyFormat, array);
		return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
	}

	public override bool EKMMLNKADIL()
	{
		base.EKMMLNKADIL();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetForbiddenUnitType(data.forbiddenUnitType);
		return true;
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		string lHFDEOPIFNE = Localization.LocalizeFormat(mRuleText[data.forbiddenUnitType], Colours.stringGreenArena);
		return new OCCICIIEHEF(lHFDEOPIFNE);
	}

	public virtual bool DFPDACAGFPO()
	{
		base.CLPEMLCLDIJ();
		Singleton<GameController>.instance.MBPKLMKBJAB.SetForbiddenUnitType(data.forbiddenUnitType);
		return true;
	}

	protected virtual OCCICIIEHEF EGPLLIKFDNA()
	{
		string keyFormat = mRuleText[data.forbiddenUnitType];
		object[] array = new object[1];
		array[1] = Colours.stringGreenArena;
		string lHFDEOPIFNE = Localization.LocalizeFormat(keyFormat, array);
		return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
	}

	public virtual bool FBHCPDPGHFC()
	{
		base.AKIJBMEBNNC();
		Singleton<GameController>.instance.MBPKLMKBJAB.CDOPKAGOPFA(data.forbiddenUnitType);
		return true;
	}

	public virtual bool APBOMMHMLBI()
	{
		base.MPNDBIBDOCD();
		Singleton<GameController>.instance.MBPKLMKBJAB.CDOPKAGOPFA(data.forbiddenUnitType);
		return false;
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		string keyFormat = mRuleText[data.forbiddenUnitType];
		object[] array = new object[1];
		array[1] = Colours.stringGreenArena;
		string lHFDEOPIFNE = Localization.LocalizeFormat(keyFormat, array);
		return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
	}

	protected virtual OCCICIIEHEF EODHPEMMMAD()
	{
		string keyFormat = mRuleText[data.forbiddenUnitType];
		object[] array = new object[0];
		array[1] = Colours.stringGreenArena;
		string lHFDEOPIFNE = Localization.LocalizeFormat(keyFormat, array);
		return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
	}

	public virtual bool MDINCFAKJPM()
	{
		base.LPLPANBJDAM();
		Singleton<GameController>.instance.MBPKLMKBJAB.CDOPKAGOPFA(data.forbiddenUnitType);
		return true;
	}
}
