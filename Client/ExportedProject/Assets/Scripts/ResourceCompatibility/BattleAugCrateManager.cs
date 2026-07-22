using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

public class BattleAugCrateManager : DatabaseSerializedObjectGeneric<BattleAugCrateManager.BattleAugCrateData>
{
	public enum IIDDAPKDLDE
	{
		ReceivingPoints,
		ReadyToClaim,
		InCooldown
	}

	[Preserve]
	public class BattleAugCrateData
	{
		public int points;

		public int time;
	}

	[CompilerGenerated]
	private Action LBNEGENHCPD;

	private static BattleAugCrateManager DJDBDKFAKHN;

	public static BattleAugCrateManager instance => null;

	public int points
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int endTime => 0;

	public IIDDAPKDLDE currentState => default(IIDDAPKDLDE);

	private bool BPEGJFEAMCO => false;

	private bool KIKJMFGMNKP => false;

	public event Action UpdateGui
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnDestroy()
	{
	}

	protected override void Awake()
	{
	}

	public void Claim()
	{
	}
}
