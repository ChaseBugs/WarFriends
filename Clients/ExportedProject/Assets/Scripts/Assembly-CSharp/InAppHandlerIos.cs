using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InAppHandlerIos : IInAppHandler
{
	private static string mBundleId;

	private Dictionary<string, string> mTransactions = new Dictionary<string, string>();

	private string[] mProductIds;

	private bool mQueringProducts;

	private string mProductId = "null";

	public bool productsRecieved => false;

	public event Action<DatabaseAction, string, bool, List<Tuple<string, string>>> InAppBought;

	public event Action<DatabaseAction, string, InAppError> InAppFailed;

	public event Action ProductsLoaded;

	public InAppHandlerIos()
	{
		mBundleId = BundleVersionBindings.BundleID;
		Debug.Log("IA: can make payments (is logged in): " + CanMakePayments() + " BundleID: " + mBundleId);
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
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
		}
	}

	~InAppHandlerIos()
	{
	}

	private DatabaseAction GetActionForId(string id)
	{
		if (id.Contains("pack"))
		{
			return DatabaseAction.BuyPack;
		}
		return DatabaseAction.BuyInApp;
	}

	internal void ValidateInappOnServer(string transactionId, string base64Receipt, bool isRestore)
	{
		string productIdFromTransactionId = GetProductIdFromTransactionId(transactionId);
		Debug.Log("IA: Validating inapp on server... inappId = " + productIdFromTransactionId);
		if (string.IsNullOrEmpty(productIdFromTransactionId))
		{
			Debug.LogError("IA: ProductID is null, not proceding ...");
			return;
		}
		List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		list.Add(new Tuple<string, string>("IosReceipt", base64Receipt));
		list.Add(new Tuple<string, string>("IosTransactionId", transactionId));
		List<Tuple<string, string>> arg = list;
		if (this.InAppBought != null)
		{
			this.InAppBought(GetActionForId(productIdFromTransactionId), productIdFromTransactionId, isRestore, arg);
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private string GetProductIdFromTransactionId(string transactionId)
	{
		string result = string.Empty;
		if (mTransactions.ContainsKey(transactionId))
		{
			result = mTransactions[transactionId];
			string oldValue = mBundleId + ".";
			result = result.Replace(oldValue, string.Empty);
			mTransactions.Remove(transactionId);
		}
		return result;
	}

	private void OnFuseboxxVerification(int result, string transactionId, string originalTransactionId)
	{
		Debug.Log("IA: Fuseboxx Verification, transaction id = " + transactionId + ", original transaction id = " + originalTransactionId + ", result = " + result);
	}

	private void OnPlayerDataLoaded()
	{
		string text = MiscTools.Md5(GameLoginManager.instance.playerId);
		Start();
	}

	public void PurchaseProduct(string productId)
	{
		string text = mBundleId + "." + productId;
		Debug.Log("IA: purchase product, productId = " + text);
		Singleton<SessionManager>.instance.StartInapp();
		Debug.Log("IA: skipping app store purchase");
		if (this.InAppBought != null)
		{
			this.InAppBought(GetActionForId(productId), productId, arg3: false, new List<Tuple<string, string>>());
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	public void RestoreTransactions()
	{
		WaitingDialog.ShowDialog("ID_RESTORING_INAPPS");
		Debug.Log("IA: restore transactions");
		Singleton<SessionManager>.instance.StartInapp();
	}

	public void HandleRestore()
	{
	}

	private void OnRestoreFailed(string obj)
	{
		Debug.Log("IA: On restore failed! " + obj);
		WaitingDialog.Hide();
		WarningDialog.ShowError(Localization.Localize("ID_WARNING_FAILTORESTORE"), Localization.Localize("ID_WARNING_RESTOREERROR"), 0f, null, string.Empty, useDialogBackground: true);
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void OnRestoreFinished()
	{
		Debug.Log("IA: On restore finished");
		WaitingDialog.Hide();
		ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_RESTORE"), Localization.Localize("ID_CONFIRM_TRANSACTIONSRESTORED"), 0f);
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void OnPurchaseCancelled(string message)
	{
		Debug.LogError("IA: purchase was cancellled, " + message);
		if (this.InAppFailed != null)
		{
			this.InAppFailed(DatabaseAction.BuyPack, message, InAppError.Canceled);
		}
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void OnPurchaseFailed(string message)
	{
		Debug.LogError("IA: Purchase failed! " + message);
		if (this.InAppFailed != null)
		{
			this.InAppFailed(DatabaseAction.BuyPack, message, InAppError.Failed);
		}
		Singleton<EventTrackingManager>.instance.RegisterPurchaseAttempt(mProductId, isSuccess: false);
		Singleton<SessionManager>.instance.FinishInapp();
	}

	private void OnProductListFailed(string message)
	{
		Debug.LogError("IA: product list fail, message = " + message);
		mQueringProducts = false;
	}

	private bool CanMakePayments()
	{
		return false;
	}

	public void Start()
	{
		mProductIds = GetInAppNames();
		GetProducstsInfo(null);
	}

	public static string[] GetInAppNames()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		string[] array = new string[inApps.Rows.Count];
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			array[i] = mBundleId + "." + inAppsRow.NAME;
		}
		return array;
	}

	public Tuple<float, string> GetItemPrice(string id)
	{
		string text = mBundleId + "." + id;
		return new Tuple<float, string>(-1f, string.Empty);
	}

	public string GetItemCurrencyCode(string id)
	{
		string text = mBundleId + "." + id;
		return "USD";
	}

	public string GetItemCountryCode(string id)
	{
		string text = mBundleId + "." + id;
		return string.Empty;
	}
}
