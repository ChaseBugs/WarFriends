using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEditor;
using UnityEngine;

namespace WarFriends.Validation
{
    /// <summary>Checks Backend-owned configuration getters without activating the retired provider.</summary>
    public static class UnityFuseConfigurationAudit
    {
        private const BindingFlags Members = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static void Run()
        {
            try
            {
                if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
                {
                    throw new InvalidOperationException("Use a disposable validation project.");
                }
                VerifyCompiledConfiguration();
                var service = new FuseboxxService();
                // The recovered finalizer resolves Unity objects; this test owns no scene subscriptions.
                GC.SuppressFinalize(service);
                Require(Invoke(service, "GetConfigVariant") as string == string.Empty,
                    "Absent Backend variant must retain bundled configuration.");
                Require(Invoke(service, "GetStartingCurrency") == null,
                    "Missing remote configuration cannot invent starting currency.");
                service.DeserializeSavedConfig("{\"SheetVersionVariant\":\"local-v1\",\"StarterPackDays\":\"7\","
                    + "\"PlayerProgressRate\":\"2\",\"BattleWarbucksRewards\":{\"win\":123}}");
                Require(Invoke(service, "GetConfigVariant") as string == "local-v1",
                    "The Backend variant must be used without a provider session.");
                Require(Invoke(service, "GetStarterPackDays") as string == "7",
                    "Saved pack configuration must remain available.");
                Require(Invoke(service, "GetPlayerProgressRate") as string == "2",
                    "Saved progress configuration must remain available.");
                var rewards = (Dictionary<string, object>)Invoke(service, "GetBattleWarbucksRewards");
                Require(Convert.ToInt32(rewards["win"]) == 123,
                    "JSON configuration must preserve the supplied value without granting currency.");
                Debug.Log("PASS: 10 compiled configuration methods and 6 Backend configuration checks.");
                EditorApplication.Exit(0);
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                EditorApplication.Exit(1);
            }
        }

        private static void VerifyCompiledConfiguration()
        {
            string[] names =
            {
                "InstanceOnDataLoaded", "GetConfigVariant", "ReadSavedConfigurationValue",
                "OverrideConfigurations", "GetStarterPackDays", "GetPlayerProgressRate",
                "GetFuseboxxConfigValue", "GetJsonConfigurationValue", "GetStartingCurrency",
                "GetBattleWarbucksRewards"
            };
            MethodInfo verify = typeof(UnityOfflineLauncherAudit).GetMethod("VerifyInstructions",
                BindingFlags.NonPublic | BindingFlags.Static);
            foreach (string name in names)
            {
                MethodInfo method = typeof(FuseboxxService).GetMethod(name, Members);
                verify.Invoke(null, new object[] { method, method.GetMethodBody().GetILAsByteArray() });
            }
        }

        private static object Invoke(FuseboxxService service, string name)
        {
            return typeof(FuseboxxService).GetMethod(name, Members).Invoke(service, null);
        }

        private static void Require(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
