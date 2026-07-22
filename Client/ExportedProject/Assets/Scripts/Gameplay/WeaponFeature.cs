using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;

public abstract class WeaponFeature
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObscuredFloat _003Cvalue_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObscuredFloat _003CdpsCoef_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ObscuredFloat _003CattackCoef_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003Cindex_003Ek__BackingField;

	public ObscuredFloat value
	{
		[CompilerGenerated]
		get
		{
			return _003Cvalue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003Cvalue_003Ek__BackingField = value;
		}
	}

	public ObscuredFloat dpsCoef
	{
		[CompilerGenerated]
		get
		{
			return _003CdpsCoef_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CdpsCoef_003Ek__BackingField = value;
		}
	}

	public ObscuredFloat attackCoef
	{
		[CompilerGenerated]
		get
		{
			return _003CattackCoef_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CattackCoef_003Ek__BackingField = value;
		}
	}

	public int index
	{
		[CompilerGenerated]
		get
		{
			return _003Cindex_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003Cindex_003Ek__BackingField = value;
		}
	}

	public virtual float clipSizeCoef => 1f;

	public virtual float reloadCoef => 1f;

	public virtual float damageCoef => 1f;

	public virtual float criticalCoef => 1f;

	public virtual int burstAdd => 0;

	public virtual float ammoCoef => 1f;

	public virtual float rateOfFireCoef => 1f;

	public virtual float accuracyCoef => 1f;

	public virtual float shotVelocityCoef => 1f;

	public virtual bool hasAnyModification => true;

	public virtual string name => string.Empty;

	public virtual string fancyName => string.Empty;

	public virtual string icon => "whiteRectangle";

	public virtual bool menuMainAtlas => true;

	public virtual string description => string.Empty;

	public virtual string statisticIncrease => string.Empty;

	public virtual string weaponPrefix => string.Empty;

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
