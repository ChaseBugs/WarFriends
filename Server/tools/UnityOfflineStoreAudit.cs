using System;
using UnityEditor;

/// <summary>Exercises the real shop tabs repeatedly after normal account boot.</summary>
public static class UnityOfflineStoreAudit
{
    private static int _stage;
    private static double _nextStep;
    public static bool Enabled { get { return Environment.GetEnvironmentVariable("WAR_VERIFY_OFFLINE_STORE") == "1"; } }
    public static bool Completed { get; private set; }

    public static bool Observe()
    {
        if (!Enabled || Completed) return true;
        if (EditorApplication.timeSinceStartup < _nextStep) return false;
        var shop = GuiElementSingle<InappScreen>.instance;
        if (_stage == 0)
        {
            if (!(Singleton<BeanstalkServerManager>.instance.inAppHandler is OfflineInAppHandler))
                throw new InvalidOperationException("Offline Client selected a payment provider.");
            var handler = new OfflineInAppHandler();
            int failures = 0;
            int grants = 0;
            handler.InAppFailed += (action, reason, error) => { if (error == InAppError.Unavailable) failures++; };
            handler.InAppBought += (action, body, restored, fields) => grants++;
            handler.PurchaseProduct("valuepack");
            handler.RestoreTransactions();
            if (failures != 2 || grants != 0 || handler.GetItemPrice("gold1").Value1 >= 0)
                throw new InvalidOperationException("Offline store accepted an unverified purchase.");
        }
        if (_stage == 12)
        {
            int leased = Singleton<GuiManager>.instance.objectPool.GetNumberOfInstancies(shop.packsPart.specialPackRecordPrefab);
            if (leased != 0) throw new InvalidOperationException("Special-pack records leaked after tab changes.");
            Completed = true;
            return true;
        }
        // Finish on Gold so the final assertion observes all special records returned.
        switch (_stage % 3)
        {
            case 0: shop.ShowWarshopWarbucks(); break;
            case 1: shop.ShowPacks(); break;
            case 2: shop.ShowWarshopGold(); break;
        }
        _stage++;
        _nextStep = EditorApplication.timeSinceStartup + 1.5;
        return false;
    }
}
