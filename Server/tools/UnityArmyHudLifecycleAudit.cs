using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace WarFriends.Validation
{
    /// <summary>Exercises card-list replacement and shutdown against recovered components.</summary>
    public static class UnityArmyHudLifecycleAudit
    {
        private const BindingFlags PrivateInstance = BindingFlags.NonPublic | BindingFlags.Instance;
        private static int _checks;

        public static void Run()
        {
            try
            {
                if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
                {
                    throw new InvalidOperationException("Use a disposable validation project.");
                }
                EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
                VerifyCards();
                VerifyShutdown();
                Debug.Log("PASS: " + _checks + " army HUD lifecycle checks.");
                EditorApplication.Exit(0);
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                EditorApplication.Exit(1);
            }
        }

        private static void VerifyCards()
        {
            DeathMatchUnitsGuiElement hud = Resources.FindObjectsOfTypeAll<DeathMatchUnitsGuiElement>().First();
            var units = (List<SpawningManagerDeathMatch.ArmyUnitDefinition>)Field("mUnits").GetValue(hud);
            var savedUnits = units.ToArray();
            var savedCards = hud.guiCards;
            var host = new GameObject("Lifecycle audit card");
            host.SetActive(false);
            var card = host.AddComponent<LifecycleAuditCard>();
            try
            {
                hud.guiCards = new List<DeathMatchGuiCard> { card, card, card };
                units.Clear();
                units.Add(null);
                units.Add(null);
                units.Add(null);
                Field("mShowingCardIndex").SetValue(hud, -1);
                Field("mIsShowingCards").SetValue(hud, true);
                Advance(hud);
                Require(card.ShownCount == 1 && IsShowing(hud), "First card retains the animation.");
                Advance(hud);
                Advance(hud);
                Require(card.ShownCount == 3 && !IsShowing(hud), "Three cards finish once.");
                Advance(hud);
                Require(card.ShownCount == 3, "Completed animation cannot overrun the list.");
                Field("mShowingCardIndex").SetValue(hud, 0);
                Field("mIsShowingCards").SetValue(hud, true);
                units.Clear();
                Advance(hud);
                Require(!IsShowing(hud), "Clearing offers cancels an in-flight animation.");
                units.Add(null);
                Field("mShowingCardIndex").SetValue(hud, -1);
                hud.guiCards.Clear();
                Advance(hud);
                Require(!IsShowing(hud), "No card slots cannot index an offer.");
            }
            finally
            {
                units.Clear();
                units.AddRange(savedUnits);
                hud.guiCards = savedCards;
                UnityEngine.Object.DestroyImmediate(host);
            }
        }

        private static void VerifyShutdown()
        {
            bool wasQuitting = Singleton.applicationIsQuitting;
            try
            {
                Singleton.applicationIsQuitting = true;
                foreach (DeathMatchUnitsGuiElement hud in Resources.FindObjectsOfTypeAll<DeathMatchUnitsGuiElement>())
                {
                    PropertyInfo active = hud.GetType().GetProperty("isActive", PrivateInstance);
                    Require(!(bool)active.GetValue(hud, null), "Shutdown must make either HUD inactive.");
                }
                EditorSceneManager.OpenScene("Assets/Scenes/City_Multiplayer.unity", OpenSceneMode.Additive);
                Crane[] cranes = Resources.FindObjectsOfTypeAll<Crane>();
                Require(cranes.Length > 0, "The map must supply a real Crane teardown target.");
                foreach (Crane crane in cranes)
                {
                    typeof(Crane).GetMethod("OnDestroy", PrivateInstance).Invoke(crane, null);
                    Require(true, "Crane teardown does not resolve a retired singleton.");
                }
            }
            finally
            {
                Singleton.applicationIsQuitting = wasQuitting;
            }
        }

        private static FieldInfo Field(string name)
        {
            return typeof(DeathMatchUnitsGuiElement).GetField(name, PrivateInstance);
        }

        private static void Advance(DeathMatchUnitsGuiElement hud)
        {
            typeof(DeathMatchUnitsGuiElement).GetMethod("ShowNextCard", PrivateInstance).Invoke(hud, null);
        }

        private static bool IsShowing(DeathMatchUnitsGuiElement hud)
        {
            return (bool)Field("mIsShowingCards").GetValue(hud);
        }

        private static void Require(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }
            _checks++;
        }
    }

    public sealed class LifecycleAuditCard : DeathMatchGuiCard
    {
        public int ShownCount { get; private set; }

        public override void Show(SpawningManagerDeathMatch.ArmyUnitDefinition definition, bool instant = false)
        {
            ShownCount++;
        }
    }
}
