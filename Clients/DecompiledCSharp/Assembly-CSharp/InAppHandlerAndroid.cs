using System;
using System.Collections.Generic;
using Google2u;
using Prime31;
using UnityEngine;

public class InAppHandlerAndroid : IInAppHandler
{
	private static string mBundleId;

	private static string pK = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhOR82yQJKu6ymLcFyTQEFkgs7PfSVXPSWcLC1JtdbMTNUmNfoM0up/7/8nRGzquPkZKF0KwVzJZJepHRzRXJiZwhGgMvDNAjwilqKAWcVGbIZPbDBZCJWxqQDgs+Ma4Pr7cPV48tDSHFPzcDxGUvfjl+sOdb1GTBZLDr3XvzBwjOwrQ5wbiY7/YdZYiv0I3UfQzmxOL9a1XfzAI1M5TcAS4vE32dPRYTM72+pt+Vr2kPuY8rF9E5RcGBWLQHuyPg9vPBre2hJPAKWJUUKrLJmxwS+mS/yv/ROkpQgKslIRHzJBmuLaLwBJyU4ZR1UAYlnzafHj/CJv96Y+7TUiY/ZwIDAQAB";

	private bool mQueringProducts;

	private string[] mProductIds;

	private bool mStartConsume;

	private int mStartConsumeCount;

	private Dictionary<string, GoogleSkuInfo> mProducts = new Dictionary<string, GoogleSkuInfo>();

	private PayloadRepository mPayloadRepository = new PayloadRepository();

	private string playerString;

	private string currentPayload = string.Empty;

	private List<GooglePurchase> nonconsumableToRestore = new List<GooglePurchase>();

	private List<GooglePurchase> refundedPurchases = new List<GooglePurchase>();

	private HashSet<string> restoredNonconsumable = new HashSet<string>();

	private bool mDoHandleRestore = true;

	public bool productsRecieved => mProducts.Count > 0;

	public event Action<DatabaseAction, string, bool, List<Tuple<string, string>>> InAppBought;

	public event Action<DatabaseAction, string, InAppError> InAppFailed;

	public event Action ProductsLoaded;

	public InAppHandlerAndroid()
	{
		mBundleId = BundleVersionBindings.BundleID;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
		GameLoginManager.instance.PlayerLogOut += OnUserLoggedOut;
		mPayloadRepository.Init();
		GoogleIAB.init(pK);
		GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent += PurchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent += PurchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent += ConsumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent += ConsumePurchaseFailedEvent;
	}

	~InAppHandlerAndroid()
	{
		GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent -= PurchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent -= PurchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent -= ConsumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent -= ConsumePurchaseFailedEvent;
	}

	public void Start()
	{
		mProductIds = GetInAppNames();
		mStartConsume = true;
		GetProducstsInfo(null);
	}

	public string[] GetInAppNames()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = GetInAppId(inAppsRow.NAME);
		}
		return array;
	}

	public Tuple<float, string> GetItemPrice(string id)
	{
		string inAppId = GetInAppId(id);
		if (mProducts.ContainsKey(inAppId))
		{
			GoogleSkuInfo googleSkuInfo = mProducts[inAppId];
			return new Tuple<float, string>((float)googleSkuInfo.priceAmountMicros / 1000000f, googleSkuInfo.price);
		}
		GetProducstsInfo(inAppId);
		Debug.LogError("can't find price for: " + id);
		return new Tuple<float, string>(-1f, string.Empty);
	}

	public string GetItemCurrencyCode(string id)
	{
		string inAppId = GetInAppId(id);
		if (mProducts.ContainsKey(inAppId))
		{
			GoogleSkuInfo googleSkuInfo = mProducts[inAppId];
			return googleSkuInfo.priceCurrencyCode;
		}
		GetProducstsInfo(inAppId);
		Debug.LogError("can not find currency for: " + id);
		return "USD";
	}

	public string GetItemCountryCode(string id)
	{
		return string.Empty;
	}

	private void GetProducstsInfo(string newBundleId)
	{
		if (newBundleId != null)
		{
			Debug.Log("Re checking product IDs");
			mProductIds = GetInAppNames();
			bool flag = true;
			for (int i = 0; i < mProductIds.Length; i++)
			{
				if (!flag)
				{
					break;
				}
				if (mProductIds[i] == newBundleId)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Debug.Log("Need add new bundle");
				string[] array = new string[mProductIds.Length + 1];
				Array.Copy(mProductIds, array, mProductIds.Length);
				array[array.Length - 1] = newBundleId;
				mProductIds = array;
			}
		}
		if (!mQueringProducts)
		{
			mQueringProducts = true;
			GoogleIAB.queryInventory(mProductIds);
		}
	}

	private DatabaseAction GetActionForId(string id)
	{
		if (id.Contains("pack"))
		{
			return DatabaseAction.BuyPack;
		}
		return DatabaseAction.BuyInApp;
	}

	private string GetInAppId(string id)
	{
		return mBundleId + "." + id.ToLower();
	}

	private InAppsRow GetInAppRow(string fullId)
	{
		string text = fullId.Replace(mBundleId + ".", string.Empty);
		foreach (InAppsRow row in Singleton<GameVariables>.instance.inApps.Rows)
		{
			if (string.Compare(row.NAME, text, ignoreCase: true) == 0)
			{
				return row;
			}
		}
		Debug.LogError("InAppRow '" + text + "' not found!");
		return null;
	}

	private void billingSupportedEvent()
	{
		Debug.Log("billingSupportedEvent");
	}

	private void billingNotSupportedEvent(string error)
	{
		Debug.Log("billingNotSupportedEvent: " + error);
	}

	private void queryInventorySucceededEvent(List<GooglePurchase> purchases, List<GoogleSkuInfo> skus)
	{
		Debug.Log($"queryInventorySucceededEvent. total purchases: {purchases.Count}, total skus: {skus.Count}");
		mQueringProducts = false;
		foreach (GoogleSkuInfo sku in skus)
		{
			mProducts[sku.productId] = sku;
		}
		nonconsumableToRestore.Clear();
		refundedPurchases.Clear();
		foreach (GooglePurchase purchase in purchases)
		{
			if (IsConsumable(purchase.productId))
			{
				if (purchase.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					if (mStartConsume)
					{
						mStartConsumeCount++;
					}
					GoogleIAB.consumeProduct(purchase.productId);
				}
				else if (purchase.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
				{
					refundedPurchases.Add(purchase);
				}
			}
			else
			{
				Debug.LogWarning("NONCONSUMABLE INAPP: " + purchase.productId);
				if (purchase.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
				{
					nonconsumableToRestore.Add(purchase);
				}
				else if (purchase.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
				{
					refundedPurchases.Add(purchase);
				}
			}
		}
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && mDoHandleRestore && !Singleton<GameController>.instance.isTutorial)
		{
			mDoHandleRestore = false;
			HandleRestore();
		}
		mStartConsume = false;
	}

	private void queryInventoryFailedEvent(string error)
	{
		Debug.Log("queryInventoryFailedEvent: " + error);
		mQueringProducts = false;
		mStartConsume = false;
	}

	private void purchaseCompleteAwaitingVerificationEvent(string purchaseData, string signature)
	{
		Debug.Log("purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature);
	}

	private bool IsConsumable(string productId)
	{
		InAppsRow inAppRow = GetInAppRow(productId);
		return inAppRow.CONSUMABLE;
	}

	private void ReallyBuy(string productId, bool isRestore, string purchaseToken, string packageName, string orderId)
	{
		InAppsRow inAppRow = GetInAppRow(productId);
		string nAME = inAppRow.NAME;
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("ProductId", nAME));
		list.Add(new Tuple<string, string>("PurchaseToken", purchaseToken));
		list.Add(new Tuple<string, string>("PackageName", packageName));
		list.Add(new Tuple<string, string>("OrderId", orderId));
		List<Tuple<string, string>> arg = list;
		this.InAppBought(GetActionForId(nAME), nAME, isRestore, arg);
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void PurchaseSucceededEvent(GooglePurchase purchase)
	{
		Debug.Log("purchaseSucceededEvent: " + purchase);
		if (purchase.purchaseState == GooglePurchase.GooglePurchaseState.Purchased)
		{
			if (IsConsumable(purchase.productId))
			{
				return;
			}
			if (purchase.developerPayload == playerString)
			{
				ReallyBuy(purchase.productId, isRestore: false, purchase.purchaseToken, purchase.packageName, purchase.orderId);
				return;
			}
			if (this.InAppFailed != null)
			{
				this.InAppFailed(DatabaseAction.BuyPack, string.Empty, InAppError.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		else if (purchase.purchaseState == GooglePurchase.GooglePurchaseState.Canceled || purchase.purchaseState == GooglePurchase.GooglePurchaseState.Refunded)
		{
			if (this.InAppFailed != null)
			{
				this.InAppFailed(DatabaseAction.BuyPack, string.Empty, InAppError.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
	}

	private void PurchaseFailedEvent(string error, int response)
	{
		if (this.InAppFailed != null)
		{
			this.InAppFailed(DatabaseAction.BuyPack, error, InAppError.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("purchaseFailedEvent: " + error + ", response: " + response);
	}

	private void ConsumePurchaseSucceededEvent(GooglePurchase purchase)
	{
		if (mPayloadRepository.IsValid(purchase.developerPayload) || mStartConsumeCount > 0)
		{
			mPayloadRepository.RemovePayload(purchase.developerPayload);
			ReallyBuy(purchase.productId, isRestore: false, purchase.purchaseToken, purchase.packageName, purchase.orderId);
			Debug.Log("consumePurchaseSucceededEvent: " + purchase);
		}
		else
		{
			if (this.InAppFailed != null)
			{
				this.InAppFailed(DatabaseAction.BuyPack, string.Empty, InAppError.Failed);
			}
			Singleton<SessionManager>.instance.FinishInapp();
		}
		if (mStartConsumeCount > 0)
		{
			mStartConsumeCount--;
		}
	}

	private void ConsumePurchaseFailedEvent(string error)
	{
		if (this.InAppFailed != null)
		{
			this.InAppFailed(DatabaseAction.BuyPack, error, InAppError.Failed);
		}
		Singleton<SessionManager>.instance.FinishInapp();
		Debug.Log("consumePurchaseFailedEvent: " + error);
		if (mStartConsumeCount > 0)
		{
			mStartConsumeCount--;
		}
	}

	public void PurchaseProduct(string productId)
	{
		string inAppId = GetInAppId(productId);
		Debug.Log("IA: purchase product, productId = " + inAppId);
		Singleton<SessionManager>.instance.StartInapp();
		if (productsRecieved)
		{
			if (IsConsumable(inAppId))
			{
				string newPayload = mPayloadRepository.GetNewPayload();
				GoogleIAB.purchaseProduct(inAppId, newPayload);
			}
			else
			{
				GoogleIAB.purchaseProduct(inAppId, playerString);
			}
			Debug.Log("IA: Debug is not enabled, contacting inapp servers");
			return;
		}
		GuiElementSingle<WaitingDialog>.instance.HideDialog();
		WarningDialog.ShowError(Localization.Localize("ID_WARNING_PURCHASEERROR_TEXT"), Localization.Localize("ID_WARNING_PURCHASEERROR"), 0f, delegate
		{
			GuiElementSingle<InappScreen>.instance.HideDialog();
			GuiElementSingle<SettingsDialog>.instance.ShowUser();
		}, string.Empty);
		Singleton<SessionManager>.instance.FinishInapp();
		GetProducstsInfo(inAppId);
	}

	public void RestoreTransactions()
	{
	}

	private void OnPlayerDataLoaded()
	{
		playerString = MiscTools.Md5(GameLoginManager.instance.playerId);
		Start();
	}

	private void OnUserLoggedOut()
	{
		mDoHandleRestore = true;
	}

	public void HandleRestore()
	{
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		Debug.LogWarning("ANDROID HANDLER: ON PLAYERDATA LOADED");
		foreach (GooglePurchase item3 in nonconsumableToRestore)
		{
			InAppsRow inAppRow = GetInAppRow(item3.productId);
			if (inAppRow == null)
			{
				continue;
			}
			if (!PlayerAnalytics.instance.IsPackBought(inAppRow.NAME))
			{
				if (restoredNonconsumable.Contains(inAppRow.NAME))
				{
					Debug.LogError("ANDROID: PACK " + inAppRow.NAME + " WAS ALREADY TRIED. POSSIBLE ERROR!!!!!");
					continue;
				}
				Debug.LogError("ANDROID: MISSING PACK " + inAppRow.NAME + " THAT WAS ALREADY BOUGHT. ADDING PACK TO RESTORE");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("Value1", inAppRow.NAME);
				dictionary.Add("Value2", item3.purchaseToken);
				dictionary.Add("Value3", item3.packageName);
				dictionary.Add("Value4", item3.orderId);
				Dictionary<string, string> item = dictionary;
				list.Add(item);
				restoredNonconsumable.Add(inAppRow.NAME);
			}
			else
			{
				Debug.LogError("ANDROID: PACK " + inAppRow.NAME + " BOUGHT AND PRESENT IN ACCOUNT");
			}
		}
		if (list.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.RestorePacks(list);
		}
		foreach (GooglePurchase refundedPurchase in refundedPurchases)
		{
			InAppsRow inAppRow2 = GetInAppRow(refundedPurchase.productId);
			if (inAppRow2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("inappId", inAppRow2.NAME);
				dictionary.Add("purchaseToken", refundedPurchase.purchaseToken);
				dictionary.Add("packageName", refundedPurchase.packageName);
				dictionary.Add("orderId", refundedPurchase.orderId);
				Dictionary<string, string> item2 = dictionary;
				list2.Add(item2);
			}
		}
		if (list2.Count > 0)
		{
			Singleton<BeanstalkServerManager>.instance.RefundedInapps(list2);
		}
	}
}
