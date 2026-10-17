using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>Checks the real menu message entry point without starting retired offer services.</summary>
public static class UnityAbortOfferAudit
{
    private const int ExpiredOfferEnd = -1;
    private const int PreviousOfferCheck = -301;

    /// <summary>Runs source message startup with an eligible offer and no initialized Fuse service.</summary>
    public static void Verify()
    {
        GameController controller = Singleton<GameController>.instance;
        MessageManager messages = BindOriginal<MessageManager>();
        OfferManager offers = BindOriginal<OfferManager>();
        BindOriginal<BeanstalkServerManager>();
        EventTrackingManager tracking = BindOriginal<EventTrackingManager>();
        Require(tracking.fuseboxxService == null, "The isolated offer probe unexpectedly has a Fuse service.");
        var recovery = typeof(GameController).GetField("_isSelfHostedAbortRecovery",
            BindingFlags.Instance | BindingFlags.NonPublic);
        bool previousRecovery = controller.IsSelfHostedAbortRecovery;
        Transform previousParent = messages.transform.parent;
        bool previousActive = messages.gameObject.activeSelf;
        FieldInfo enabled = OfferField("canCheckOffer");
        FieldInfo lastCheck = OfferField("lastCheckTime");
        FieldInfo end = OfferField("mEndTime");
        object previousEnabled = enabled.GetValue(offers);
        object previousCheck = lastCheck.GetValue(offers);
        object previousEnd = end.GetValue(offers);
        try
        {
            recovery.SetValue(controller, true);
            enabled.SetValue(offers, true);
            lastCheck.SetValue(offers, PreviousOfferCheck);
            end.SetValue(offers, ExpiredOfferEnd);
            messages.gameObject.SetActive(false);
            messages.transform.SetParent(null, true);
            messages.gameObject.SetActive(true);
            messages.StartMessageCoroutine();
            Require(typeof(MessageManager).GetField("mRoutine", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(messages) != null, "Source message startup did not retain its cancellable routine.");
            Require((int)lastCheck.GetValue(offers) == PreviousOfferCheck,
                "Abort recovery consumed the legacy offer-check timestamp.");
            messages.StopMessageCoroutine();
            Debug.Log("PASS: real message startup retains its recovery wait without requiring Fuse or " +
                "consuming the legacy offer check; no account/menu boot proof.");
        }
        finally
        {
            messages.StopMessageCoroutine();
            messages.StopAllCoroutines();
            messages.gameObject.SetActive(false);
            messages.transform.SetParent(previousParent, true);
            messages.gameObject.SetActive(previousActive);
            enabled.SetValue(offers, previousEnabled);
            lastCheck.SetValue(offers, previousCheck);
            end.SetValue(offers, previousEnd);
            recovery.SetValue(controller, previousRecovery);
        }
    }

    private static T BindOriginal<T>() where T : Core_BaseScript
    {
        T provider = Resources.FindObjectsOfTypeAll<T>().Single(value => value.gameObject.scene.IsValid());
        typeof(Singleton<T>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, provider);
        return provider;
    }

    private static FieldInfo OfferField(string name)
    {
        return typeof(OfferManager).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
