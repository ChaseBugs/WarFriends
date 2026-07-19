using CodeStage.AntiCheat.ObscuredTypes;

public abstract class WeaponFeature
{
	public ObscuredFloat value { get; private set; }

	public ObscuredFloat dpsCoef { get; protected set; }

	public ObscuredFloat attackCoef { get; protected set; }

	public int index { get; protected set; }

	public virtual float clipSizeCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual float reloadCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual float damageCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual float criticalCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual int burstAdd
	{
		get
		{
			return 0;
		}
	}

	public virtual float ammoCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual float rateOfFireCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual float accuracyCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual float shotVelocityCoef
	{
		get
		{
			return 1f;
		}
	}

	public virtual bool hasAnyModification
	{
		get
		{
			return true;
		}
	}

	public virtual string name
	{
		get
		{
			return string.Empty;
		}
	}

	public virtual string fancyName
	{
		get
		{
			return string.Empty;
		}
	}

	public virtual string icon
	{
		get
		{
			return "whiteRectangle";
		}
	}

	public virtual bool menuMainAtlas
	{
		get
		{
			return true;
		}
	}

	public virtual string description
	{
		get
		{
			return string.Empty;
		}
	}

	public virtual string statisticIncrease
	{
		get
		{
			return string.Empty;
		}
	}

	public virtual string weaponPrefix
	{
		get
		{
			return string.Empty;
		}
	}

	public WeaponFeature()
	{
		value = 0f;
	}

	public virtual string Statistic(WeaponLevelsSetup weapon)
	{
		return "0%";
	}

	public virtual string StatisticIncrease(WeaponLevelsSetup weapon)
	{
		return statisticIncrease;
	}

	public virtual int CompareTwoWeapons(WeaponLevelsSetup weapon1, WeaponLevelsSetup weapon2)
	{
		return 0;
	}

	public void Init(ObscuredFloat value, ObscuredFloat dpsCoef, ObscuredFloat dmgCoef, int index)
	{
		this.value = value;
		this.dpsCoef = dpsCoef;
		attackCoef = dmgCoef;
		this.index = index;
	}
}
