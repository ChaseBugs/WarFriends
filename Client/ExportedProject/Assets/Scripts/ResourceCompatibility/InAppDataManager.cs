using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine.Scripting;

public class InAppDataManager : DatabaseSerializedObjectGeneric<InAppDataManager.InAppData>
{
	[Preserve]
	public class InAppData
	{
		public Dictionary<string, InAppInfo> inapps;
	}

	[Preserve]
	public class InAppInfo
	{
		public int allDays;

		public int left;

		public Dictionary<string, string> days;

		public int currentDay => 0;

		public bool isActive => false;
	}

	[Serializable]
	public class InappDefinition
	{
		public string id;

		public int amount;

		public int sale;

		public float price { get; set; }

		public string formatedPrice { get; set; }

		public int goldPrice { get; set; }

		public int warbucksAmount => 0;

		public override string ToString()
		{
			return null;
		}

		public static InappDefinition CreateInappDefinition(string inappName, int amount)
		{
			return null;
		}

		public static InappDefinition CreateLootboxDefinition(string lootboxId, int amount, int price)
		{
			return null;
		}
	}

	private static InAppDataManager mInstance;

	private Tuple<string, string> waitingAnalytics;

	public static InAppDataManager instance => null;

	public string goldPrefix => null;

	public string warbucksPrefix => null;

	public List<InappDefinition> goldInAppDefinitions { get; private set; }

	public List<InappDefinition> warbucksInAppDefinitions { get; private set; }

	public List<InappDefinition> lootboxesDefinitions { get; private set; }

	public bool isWarbucksForGold { get; private set; }

	public bool isProductsLoaded { get; private set; }

	private bool mIsGoldBVariant => false;

	public event Action ProductLoadedAndComputed
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

	public string GetDailyInAppId(string id)
	{
		return null;
	}

	private string GetOtherInAppFromABTest(string id)
	{
		return null;
	}

	public InAppInfo GetDailyInApp(string id)
	{
		return null;
	}

	public void AddDailyGoldBooster()
	{
	}

	protected override void Awake()
	{
	}

	public void InitializeAfterStart()
	{
	}

	public void SendSubscriptionRenewAnalytics(string packId, string transactionId)
	{
	}

	private void CreateWarshopDefinitions()
	{
	}

	private void OnProductsLoaded()
	{
	}

	private void OnLevelUp()
	{
	}

	private void CreateGoldInappDefinitions()
	{
	}

	private void ComputeGoldSalesAndSaves()
	{
	}

	private void OnGoldProductsLoaded()
	{
	}

	private void CreateWarbucksInappDefinitions()
	{
	}

	private void ComputeWarbucksForGoldSaves()
	{
	}

	private void ComputeWarbucksSaves()
	{
	}

	private void OnWarbucksProductsLoaded()
	{
	}

	private void CreateLootboxesDefinitions()
	{
	}

	private InApps.rowIds GetDailyGoldInAppRowId()
	{
		return default(InApps.rowIds);
	}

	public string GetDailyGoldInAppId()
	{
		return null;
	}

	public InappDefinition GetDailyGoldInAppDefinition()
	{
		return null;
	}

	public int GetDaysFromDailyGoldInApp(string inappName)
	{
		return 0;
	}

	private bool ComputeIsWarbucksForGold()
	{
		return false;
	}

	private int GetWarbucksForGoldAmount(string warbucksId)
	{
		return 0;
	}

	private int GetWarbucksForGoldPrice(string warbucksId)
	{
		return 0;
	}

	public InappDefinition GetWarbucksDefinitionClosestTo(int warbucksAmount)
	{
		return null;
	}
}
