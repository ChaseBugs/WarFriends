using System;
using System.Collections.Generic;

/// <summary>Completes store requests locally when no payment provider is available.</summary>
public sealed class OfflineInAppHandler : IInAppHandler
{
    // This adapter can never issue a receipt or a successful purchase callback.
    public event Action<DatabaseAction, string, bool, List<Tuple<string, string>>> InAppBought
    {
        add { }
        remove { }
    }

    public event Action<DatabaseAction, string, InAppError> InAppFailed;
    public event Action ProductsLoaded;

    public void Start()
    {
        if (ProductsLoaded != null) ProductsLoaded();
    }

    public Tuple<float, string> GetItemPrice(string id)
    {
        return new Tuple<float, string>(-1f, Localization.Localize("ID_OFFLINE"));
    }

    public string GetItemCurrencyCode(string id) { return string.Empty; }
    public string GetItemCountryCode(string id) { return string.Empty; }

    public void PurchaseProduct(string inAppId)
    {
        DatabaseAction action = !string.IsNullOrEmpty(inAppId) && inAppId.Contains("pack")
            ? DatabaseAction.BuyPack : DatabaseAction.BuyInApp;
        if (InAppFailed != null) InAppFailed(action, "Offline store unavailable.", InAppError.Unavailable);
    }

    public void RestoreTransactions()
    {
        if (InAppFailed != null)
            InAppFailed(DatabaseAction.BuyInApp, "Offline restore unavailable.", InAppError.Unavailable);
    }

    public void HandleRestore() { }
}
