using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Scripting;

public class PiggyBankManager : DatabaseSerializedObjectGeneric<PiggyBankManager.PiggyBankData>
{
	[Preserve]
	public class PiggyBankData
	{
		public int resetTime;

		public int currentPiggyGold;

		public int currentTier;

		public int shownTimes;

		public bool animate;

		public bool hint;
	}

	[SerializeField]
	private PiggyBank mPiggyBankConfigs;

	private static PiggyBankManager mInstance;

	public static PiggyBankManager instance => null;

	public int timeUntilReset => 0;

	public bool shouldAnimate => false;

	public bool showHint => false;

	public int endTime => 0;

	public int goldPerBattle => 0;

	public bool isActive => false;

	public bool showResetTime => false;

	public int maxPiggyGold => 0;

	public int currentPiggyGold => 0;

	public string currentInappId => null;

	public bool canBuy => false;

	public float currentPrice => 0f;

	public string currentPriceWithCurrency => null;

	public bool shouldShowFull => false;

	private PiggyBankRow mCurrentRow => null;

	public event Action PiggyBankGUIUpdate
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

	public void LoadPiggyBankData(string piggyBankData)
	{
	}

	protected override void Awake()
	{
	}

	private void OnAfterPlayerDataLoaded()
	{
	}
}
