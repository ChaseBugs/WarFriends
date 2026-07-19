using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class InAppDataManager : DatabaseSerializedObjectGeneric<InAppDataManager.InAppData>
{
	public class InAppData
	{
		public Dictionary<string, InAppInfo> inapps;
	}

	public class InAppInfo
	{
		public int allDays;

		public int left;

		public Dictionary<string, string> days;

		public int currentDay
		{
			get
			{
				return allDays - left;
			}
		}

		public bool isActive
		{
			get
			{
				return left > 0;
			}
		}
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

		public int warbucksAmount
		{
			get
			{
				return (!Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.isWarbucksForGold) ? amount : (amount * LevelManager.instance.currentLevel.convertGoldToWarbucks);
			}
		}

		public override string ToString()
		{
			return string.Format("{0} \"{1}\" for {2}", amount, id, formatedPrice);
		}

		[SpecialName]
		public string IKALHPLMNDD()
		{
			return formatedPrice;
		}

		public virtual string FOOMIBECINC()
		{
			return string.Format("Buy_Weapons", amount, id, OAJCGMBBFFF());
		}

		[SpecialName]
		public float FFHEHHMDGBN()
		{
			return price;
		}

		public static InappDefinition GAJAKNHLAKO(string OENKDPMFEGI, int IEALLELGOBM, int OPEICELHNLI)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = OENKDPMFEGI;
			inappDefinition.amount = IEALLELGOBM;
			inappDefinition.price = OPEICELHNLI;
			return inappDefinition;
		}

		[SpecialName]
		public string OAJCGMBBFFF()
		{
			return formatedPrice;
		}

		[SpecialName]
		public int EBIHNPDKAJD()
		{
			return goldPrice;
		}

		public static InappDefinition OEJAHIFDJJP(string OENKDPMFEGI, int IEALLELGOBM, int OPEICELHNLI)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = OENKDPMFEGI;
			inappDefinition.amount = IEALLELGOBM;
			inappDefinition.price = OPEICELHNLI;
			return inappDefinition;
		}

		public static InappDefinition DJFKKLHNAAM(string GGBKBJFDLGO, int IEALLELGOBM)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = GGBKBJFDLGO;
			inappDefinition.amount = IEALLELGOBM;
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(GGBKBJFDLGO);
			inappDefinition.price = tuple.Value1;
			inappDefinition.formatedPrice = tuple.Value2;
			return inappDefinition;
		}

		public static InappDefinition AKMBGKFPBDF(string OENKDPMFEGI, int IEALLELGOBM, int OPEICELHNLI)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = OENKDPMFEGI;
			inappDefinition.amount = IEALLELGOBM;
			inappDefinition.price = OPEICELHNLI;
			return inappDefinition;
		}

		public static InappDefinition JOKEBNJDLFO(string GGBKBJFDLGO, int IEALLELGOBM)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = GGBKBJFDLGO;
			inappDefinition.amount = IEALLELGOBM;
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(GGBKBJFDLGO);
			inappDefinition.price = tuple.Value1;
			inappDefinition.formatedPrice = tuple.Value2;
			return inappDefinition;
		}

		[SpecialName]
		public int PEKNLCLFIME()
		{
			return goldPrice;
		}

		[SpecialName]
		public void MFCFKNCEIHF(int IDEBKDPMPGM)
		{
			goldPrice = IDEBKDPMPGM;
		}

		public virtual string BICEOOCDGBD()
		{
			return string.Format("country-russia", amount, id, MHBLNNEOGFN());
		}

		public static InappDefinition FBDBGALAEML(string GGBKBJFDLGO, int IEALLELGOBM)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = GGBKBJFDLGO;
			inappDefinition.amount = IEALLELGOBM;
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(GGBKBJFDLGO);
			inappDefinition.price = tuple.Value1;
			inappDefinition.formatedPrice = tuple.Value2;
			return inappDefinition;
		}

		[SpecialName]
		public string MHBLNNEOGFN()
		{
			return formatedPrice;
		}
	}

	private sealed class ELPEFLLBGMG
	{
		internal string OBBIELMONIG;

		internal bool ALIBBKEHCFC(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool NDJOJHNIBFC(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool LJCDGJKCNEC(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool HHLMDAKDHFK(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool GGJDILDIFPJ(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool HHNEBNHCGMO(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool BEIGOGFHJIB(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool JEDCBCPMJGI(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool ILOFOILFGMA(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool DJLGPGPAHCD(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool JGHLGHMJJDG(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool ECPMEMNKMCB(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool KPHEPHDFCKK(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool JEGPCHMCABF(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool KNJBDOADLDO(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool NNIJEDKBPGJ(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool FDKMOFHAEFN(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool PANKBNOCEAM(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool POGLHCIAAGH(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool CIFEDFPPPOK(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool HOMIPBFODIC(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool MAKLHLCDIKD(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool EMKPBGFBPFI(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool LKAHPHIEMEK(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool LHPPLGOOLEC(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool ABNGKEJNLJO(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool CHDOECNGOPM(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool LGJCNCHBFDA(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool MMEEJDGGAID(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool FKIBFHGKMFJ(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool NCLMPCCHDAM(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}

		internal bool NAJNECOMDDN(InappDefinition KBJJJEDDPMA)
		{
			return KBJJJEDDPMA.id == OBBIELMONIG;
		}
	}

	private string mGoldPrefix = "gold";

	private string mWarbucksPrefix = "warbucks";

	public string goldPrefix
	{
		get
		{
			return mGoldPrefix;
		}
		set
		{
			mGoldPrefix = value;
		}
	}

	public string warbucksPrefix
	{
		get
		{
			return mWarbucksPrefix;
		}
		set
		{
			mWarbucksPrefix = value;
		}
	}

	public List<InappDefinition> goldInAppDefinitions { get; private set; }

	public List<InappDefinition> warbucksInAppDefinitions { get; private set; }

	public List<InappDefinition> lootboxesDefinitions { get; private set; }

	public bool isWarbucksForGold { get; private set; }

	private bool mIsGoldBVariant
	{
		get
		{
			return goldPrefix.ToLower().StartsWith("b");
		}
	}

	public event Action ProductLoadedAndComputed;

	public string GetDailyInAppId(string id)
	{
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return id;
		}
		id = GetOtherInAppFromABTest(id);
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return id;
		}
		return null;
	}

	private string GetOtherInAppFromABTest(string id)
	{
		if (id.StartsWith("b"))
		{
			return id.Substring(1);
		}
		return "b" + id;
	}

	public InAppInfo GetDailyInApp(string id)
	{
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return data.inapps[id];
		}
		id = GetOtherInAppFromABTest(id);
		if (data.inapps != null && data.inapps.ContainsKey(id))
		{
			return data.inapps[id];
		}
		return null;
	}

	public void AddDailyGoldBooster()
	{
		if (data.inapps == null)
		{
			data.inapps = new Dictionary<string, InAppInfo>();
		}
		int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
		string dailyGoldInAppId = GetDailyGoldInAppId();
		InAppInfo inAppInfo = new InAppInfo();
		inAppInfo.days = new Dictionary<string, string>();
		inAppInfo.allDays = getDailyGoldInAppDays;
		inAppInfo.left = getDailyGoldInAppDays;
		data.inapps.Add(dailyGoldInAppId, inAppInfo);
	}

	public void InitializeAfterStart()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += CreateWarshopDefinitions;
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += OnProductsLoaded;
		LevelManager.LevelUp += OnLevelUp;
	}

	private void CreateWarshopDefinitions()
	{
		CreateGoldInappDefinitions();
		CreateWarbucksInappDefinitions();
		CreateLootboxesDefinitions();
	}

	private void OnProductsLoaded()
	{
		if (goldInAppDefinitions != null && warbucksInAppDefinitions != null)
		{
			OnGoldProductsLoaded();
			OnWarbucksProductsLoaded();
		}
		if (this.ProductLoadedAndComputed != null)
		{
			this.ProductLoadedAndComputed();
		}
	}

	private void OnLevelUp()
	{
		if (this.ProductLoadedAndComputed != null)
		{
			this.ProductLoadedAndComputed();
		}
	}

	private void CreateGoldInappDefinitions()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		if (goldInAppDefinitions == null)
		{
			goldInAppDefinitions = new List<InappDefinition>();
		}
		else
		{
			goldInAppDefinitions.Clear();
		}
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			if (inAppsRow.NAME.StartsWith(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.goldPrefix))
			{
				InappDefinition item = InappDefinition.DJFKKLHNAAM(inAppsRow.NAME, inAppsRow.AMOUNT);
				goldInAppDefinitions.Add(item);
			}
		}
		ComputeGoldSalesAndSaves();
	}

	private void ComputeGoldSalesAndSaves()
	{
		float num = float.MaxValue;
		for (int i = 0; i < goldInAppDefinitions.Count; i++)
		{
			float num2 = (float)goldInAppDefinitions[i].amount / goldInAppDefinitions[i].price;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int j = 0; j < goldInAppDefinitions.Count; j++)
		{
			float num3 = (float)goldInAppDefinitions[j].amount / goldInAppDefinitions[j].price;
			if (goldInAppDefinitions[j].id.Contains("daily"))
			{
				float num4 = 1f - num / num3;
				goldInAppDefinitions[j].sale = MEJMLNDFDBP.LJDADOKBBNA(100f * num4);
			}
			else
			{
				float num5 = Mathf.Max(0f, num3 - num);
				goldInAppDefinitions[j].sale = MEJMLNDFDBP.LJDADOKBBNA(20f * num5 / num) * 5;
			}
		}
	}

	private void OnGoldProductsLoaded()
	{
		foreach (InappDefinition goldInAppDefinition in goldInAppDefinitions)
		{
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(goldInAppDefinition.id);
			goldInAppDefinition.price = tuple.Value1;
			goldInAppDefinition.formatedPrice = tuple.Value2;
		}
		ComputeGoldSalesAndSaves();
	}

	private void CreateWarbucksInappDefinitions()
	{
		isWarbucksForGold = ComputeIsWarbucksForGold();
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		if (warbucksInAppDefinitions == null)
		{
			warbucksInAppDefinitions = new List<InappDefinition>();
		}
		else
		{
			warbucksInAppDefinitions.Clear();
		}
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			if (inAppsRow.NAME.StartsWith(Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksPrefix))
			{
				string nAME = inAppsRow.NAME;
				int iEALLELGOBM = ((!isWarbucksForGold) ? inAppsRow.AMOUNT : GetWarbucksForGoldAmount(nAME));
				InappDefinition inappDefinition = InappDefinition.DJFKKLHNAAM(nAME, iEALLELGOBM);
				if (isWarbucksForGold)
				{
					inappDefinition.goldPrice = GetWarbucksForGoldPrice(nAME);
				}
				warbucksInAppDefinitions.Add(inappDefinition);
			}
		}
		if (isWarbucksForGold)
		{
			ComputeWarbucksForGoldSaves();
		}
		else
		{
			ComputeWarbucksSaves();
		}
	}

	private void ComputeWarbucksForGoldSaves()
	{
		float num = float.MaxValue;
		for (int i = 0; i < warbucksInAppDefinitions.Count; i++)
		{
			float num2 = (float)warbucksInAppDefinitions[i].amount / (float)warbucksInAppDefinitions[i].goldPrice;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int j = 0; j < warbucksInAppDefinitions.Count; j++)
		{
			float num3 = (float)warbucksInAppDefinitions[j].amount / (float)warbucksInAppDefinitions[j].goldPrice;
			float num4 = Mathf.Max(0f, num3 - num);
			warbucksInAppDefinitions[j].sale = MEJMLNDFDBP.LJDADOKBBNA(20f * num4 / num) * 5;
		}
	}

	private void ComputeWarbucksSaves()
	{
		float num = float.MaxValue;
		for (int i = 0; i < warbucksInAppDefinitions.Count; i++)
		{
			float num2 = (float)warbucksInAppDefinitions[i].amount / warbucksInAppDefinitions[i].price;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int j = 0; j < warbucksInAppDefinitions.Count; j++)
		{
			float num3 = (float)warbucksInAppDefinitions[j].amount / warbucksInAppDefinitions[j].price;
			float num4 = Mathf.Max(0f, num3 - num);
			warbucksInAppDefinitions[j].sale = MEJMLNDFDBP.LJDADOKBBNA(20f * num4 / num) * 5;
		}
	}

	private void OnWarbucksProductsLoaded()
	{
		foreach (InappDefinition warbucksInAppDefinition in warbucksInAppDefinitions)
		{
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(warbucksInAppDefinition.id);
			warbucksInAppDefinition.price = tuple.Value1;
			warbucksInAppDefinition.formatedPrice = tuple.Value2;
		}
		if (!isWarbucksForGold)
		{
			ComputeWarbucksSaves();
		}
	}

	private void CreateLootboxesDefinitions()
	{
		Lootboxes lootboxes = Singleton<GameVariables>.instance.lootboxes;
		if (lootboxesDefinitions == null)
		{
			lootboxesDefinitions = new List<InappDefinition>();
		}
		else
		{
			lootboxesDefinitions.Clear();
		}
		for (int i = 0; i < lootboxes.Rows.Count; i++)
		{
			LootboxesRow lootboxesRow = lootboxes.Rows[i];
			lootboxesDefinitions.Add(InappDefinition.AKMBGKFPBDF(lootboxesRow.NAME, lootboxesRow.COUNT, lootboxesRow.GOLD));
		}
		float num = float.MaxValue;
		for (int j = 0; j < lootboxesDefinitions.Count; j++)
		{
			float num2 = (float)lootboxesDefinitions[j].amount / lootboxesDefinitions[j].price;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int k = 0; k < lootboxesDefinitions.Count; k++)
		{
			float num3 = (float)lootboxesDefinitions[k].amount / lootboxesDefinitions[k].price;
			float num4 = Mathf.Max(0f, num3 - num);
			lootboxesDefinitions[k].sale = MEJMLNDFDBP.LJDADOKBBNA(20f * num4 / num) * 5;
		}
	}

	private InApps.rowIds GetDailyGoldInAppRowId()
	{
		switch (PlayerAnalytics.instance.data.getDailyGoldInAppDays)
		{
		case 30:
			return (!mIsGoldBVariant) ? InApps.rowIds.gold30daily1 : InApps.rowIds.bgold30daily1;
		case 21:
			return (!mIsGoldBVariant) ? InApps.rowIds.gold21daily1 : InApps.rowIds.bgold21daily1;
		case 14:
			return (!mIsGoldBVariant) ? InApps.rowIds.gold14daily1 : InApps.rowIds.bgold14daily1;
		default:
			return (!mIsGoldBVariant) ? InApps.rowIds.gold7daily1 : InApps.rowIds.bgold7daily1;
		}
	}

	public string GetDailyGoldInAppId()
	{
		InApps.rowIds dailyGoldInAppRowId = GetDailyGoldInAppRowId();
		return Singleton<GameVariables>.instance.inApps.GetRow(dailyGoldInAppRowId).NAME;
	}

	public InappDefinition GetDailyGoldInAppDefinition()
	{
		ELPEFLLBGMG eLPEFLLBGMG = new ELPEFLLBGMG();
		eLPEFLLBGMG.OBBIELMONIG = GetDailyGoldInAppId();
		int num = goldInAppDefinitions.FindIndex(eLPEFLLBGMG.LJCDGJKCNEC);
		return (num <= -1) ? null : goldInAppDefinitions[num];
	}

	public int GetDaysFromDailyGoldInApp(string inappName)
	{
		string nAME = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold30daily1).NAME;
		string nAME2 = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.bgold30daily1).NAME;
		if (inappName == nAME || inappName == nAME2)
		{
			return 30;
		}
		nAME = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold21daily1).NAME;
		nAME2 = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.bgold21daily1).NAME;
		if (inappName == nAME || inappName == nAME2)
		{
			return 21;
		}
		nAME = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold14daily1).NAME;
		nAME2 = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.bgold14daily1).NAME;
		if (inappName == nAME || inappName == nAME2)
		{
			return 14;
		}
		nAME = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold7daily1).NAME;
		nAME2 = Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.bgold7daily1).NAME;
		if (inappName == nAME || inappName == nAME2)
		{
			return 7;
		}
		return 1;
	}

	private bool ComputeIsWarbucksForGold()
	{
		Warbucks warbucksForGold = Singleton<GameVariables>.instance.warbucksForGold;
		for (int i = 0; i < warbucksForGold.Rows.Count; i++)
		{
			WarbucksRow warbucksRow = warbucksForGold.Rows[i];
			if (warbucksRow.GOLDAMOUNT == 0)
			{
				return false;
			}
		}
		return true;
	}

	private int GetWarbucksForGoldAmount(string warbucksId)
	{
		Warbucks warbucksForGold = Singleton<GameVariables>.instance.warbucksForGold;
		for (int i = 0; i < warbucksForGold.Rows.Count; i++)
		{
			WarbucksRow warbucksRow = warbucksForGold.Rows[i];
			if (warbucksRow.NAME == warbucksId)
			{
				return warbucksRow.GOLDAMOUNT;
			}
		}
		return 0;
	}

	private int GetWarbucksForGoldPrice(string warbucksId)
	{
		Warbucks warbucksForGold = Singleton<GameVariables>.instance.warbucksForGold;
		for (int i = 0; i < warbucksForGold.Rows.Count; i++)
		{
			WarbucksRow warbucksRow = warbucksForGold.Rows[i];
			if (warbucksRow.NAME == warbucksId)
			{
				return warbucksRow.GOLDPRICE;
			}
		}
		return 0;
	}
}
