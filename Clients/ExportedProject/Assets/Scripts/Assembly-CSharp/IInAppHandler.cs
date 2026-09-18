using System;
using System.Collections.Generic;

public interface IInAppHandler
{
	event Action<DatabaseAction, string, bool, List<Tuple<string, string>>> InAppBought;

	event Action<DatabaseAction, string, InAppError> InAppFailed;

	event Action ProductsLoaded;

	void Start();

	Tuple<float, string> GetItemPrice(string id);

	string GetItemCurrencyCode(string id);

	string GetItemCountryCode(string id);

	void PurchaseProduct(string inAppId);

	void RestoreTransactions();

	void HandleRestore();
}
