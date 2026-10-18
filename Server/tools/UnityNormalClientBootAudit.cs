using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes the original Splash-to-MainScene startup without replacing its managers or player data.</summary>
[InitializeOnLoad]
public static class UnityNormalClientBootAudit
{
    private const string SessionKey = "WarFriends.NormalClientBootAudit";
    private const int MaximumStartupSeconds = 75;
    private const int MainSceneObservationFrames = 12;
    private const int MaximumExceptionSamples = 12;
    private const int MaximumErrorSources = 32;
    private static readonly List<string> ExceptionSources = new List<string>();
    private static readonly Dictionary<string, int> ErrorSources = new Dictionary<string, int>();
    private static readonly FieldInfo CardDefinitionField = typeof(Card).GetField(
        "mCardDefinition", BindingFlags.Instance | BindingFlags.NonPublic);
    private static double _deadline;
    private static int _mainSceneFrame = -1;
    private static int _exceptions;
    private static int _errors;
    private static int _invalidBootstrapQueries;

    static UnityNormalClientBootAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            Attach();
        }
    }

    /// <summary>Runs only in a disposable project with isolated Unity persistent-data identity.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local for this audit.");
        }
        PlayerSettings.companyName = "WarFriendsValidation";
        PlayerSettings.productName = "NormalBoot-" + Guid.NewGuid().ToString("N");
        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity");
        SessionState.SetBool(SessionKey, true);
        Attach();
        EditorApplication.isPlaying = true;
    }

    private static void Attach()
    {
        _deadline = EditorApplication.timeSinceStartup + MaximumStartupSeconds;
        EditorApplication.update -= Observe;
        EditorApplication.update += Observe;
        Application.logMessageReceived -= ObserveLog;
        Application.logMessageReceived += ObserveLog;
    }

    private static void ObserveLog(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error || type == LogType.Assert)
        {
            _errors++;
            string source = stackTrace.Split('\n').FirstOrDefault(frame => frame.Contains("Assets")) ?? "native/no-source";
            if (ErrorSources.ContainsKey(source))
            {
                ErrorSources[source]++;
            }
            else if (ErrorSources.Count < MaximumErrorSources)
            {
                ErrorSources.Add(source, 1);
            }
            if (condition == "BUDDY is not stored in translate dictionary." ||
                condition.StartsWith("Row index 0 out of range for sheet ", StringComparison.Ordinal) &&
                condition.EndsWith(" Google2u.Squads", StringComparison.Ordinal))
            {
                _invalidBootstrapQueries++;
            }
        }
        if (type != LogType.Exception)
        {
            return;
        }

        _exceptions++;
        if (ExceptionSources.Count < MaximumExceptionSamples)
        {
            int separator = condition.IndexOf(':');
            string kind = separator < 0 ? "Exception" : condition.Substring(0, separator);
            string[] frames = stackTrace.Split('\n');
            string source = frames.FirstOrDefault(frame => frame.Contains("Assets")) ?? frames.FirstOrDefault();
            ExceptionSources.Add(kind + " | " + source);
        }
    }

    private static void Observe()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            if (EditorApplication.timeSinceStartup > _deadline)
            {
                Finish();
            }
            return;
        }

        bool mainLoaded = Application.loadedLevelName == "MainScene";
        bool requireAccount = Environment.GetEnvironmentVariable("WAR_LOBBY_BOOT_REQUIRE_ACCOUNT") == "1";
        bool observedTarget = mainLoaded && (!requireAccount || HasAccountAndUnits());
        if (observedTarget && _mainSceneFrame < 0)
        {
            _mainSceneFrame = Time.frameCount;
        }
        if ((_mainSceneFrame >= 0 && Time.frameCount >= _mainSceneFrame + MainSceneObservationFrames) ||
            EditorApplication.timeSinceStartup > _deadline)
        {
            Finish();
        }
    }

    private static bool HasAccountAndUnits()
    {
        LevelManager levels = Resources.FindObjectsOfTypeAll<LevelManager>()
            .FirstOrDefault(manager => manager.gameObject.scene.IsValid());
        BeanstalkServerManager server = Resources.FindObjectsOfTypeAll<BeanstalkServerManager>()
            .FirstOrDefault(manager => manager.gameObject.scene.IsValid());
        return GameLoginManager.currentPlayer != null && levels != null &&
            levels.behaviours != null && levels.behaviours.Count > 0 &&
            levels.weaponLevelsSetups != null && levels.weaponLevelsSetups.Count > 0 &&
            levels.unitsSortedByLevel.Count == levels.behaviours.Count &&
            levels.weaponsSortedByLevel.Count == levels.weaponLevelsSetups.Count &&
            server != null && !server.loadingPlayerData && HasCardDefinitions();
    }

    private static bool HasCardDefinitions()
    {
        CardManager cards = Resources.FindObjectsOfTypeAll<CardManager>()
            .FirstOrDefault(manager => manager.gameObject.scene.IsValid());
        CardManagerDeathmatchOffline bots = Resources.FindObjectsOfTypeAll<CardManagerDeathmatchOffline>()
            .FirstOrDefault(manager => manager.gameObject.scene.IsValid());
        return cards != null && cards.cards != null && cards.cards.Count > 0 &&
            bots != null && bots.botCards.Count > 0 &&
            cards.cards.All(card => card != null && CardDefinitionField.GetValue(card) != null) &&
            bots.botCards.Values.All(card => card != null &&
                (card.isBuddyCard || CardDefinitionField.GetValue(card) != null));
    }

    private static void Finish()
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Observe;
        Application.logMessageReceived -= ObserveLog;
        GameController game = Resources.FindObjectsOfTypeAll<GameController>()
            .FirstOrDefault(controller => controller.gameObject.scene.IsValid());
        LevelManager levels = Resources.FindObjectsOfTypeAll<LevelManager>()
            .FirstOrDefault(manager => manager.gameObject.scene.IsValid());
        string reportPath = Path.Combine(Application.dataPath, "../normal-client-boot.json");
        bool requireAccount = Environment.GetEnvironmentVariable("WAR_LOBBY_BOOT_REQUIRE_ACCOUNT") == "1";
        bool accountReady = Application.loadedLevelName == "MainScene" && GameLoginManager.currentPlayer != null;
        bool dataLoadComplete = accountReady && HasAccountAndUnits();
        File.WriteAllText(reportPath, JsonConvert.SerializeObject(new
        {
            schemaVersion = 1,
            scope = requireAccount ? "original startup with real Backend and isolated persistence" :
                "original startup with unavailable loopback Backend and isolated persistence",
            unityVersion = Application.unityVersion,
            mainSceneLoaded = Application.loadedLevelName == "MainScene",
            activeSceneName = Application.loadedLevelName,
            mainPlayerAssigned = game != null && game.mainPlayerController != null,
            playerNetworkReady = game != null && game.mainPlayerController != null &&
                game.mainPlayerController.networkStatus != null,
            recoveredUnitRows = levels == null || levels.behaviours == null ? 0 : levels.behaviours.Count,
            recoveredWeaponRows = levels == null || levels.weaponLevelsSetups == null
                ? 0 : levels.weaponLevelsSetups.Count,
            accountDataReady = accountReady,
            playerDataLoadComplete = dataLoadComplete,
            initializedUnitRows = levels == null ? 0 : levels.unitsSortedByLevel.Count,
            initializedWeaponRows = levels == null ? 0 : levels.weaponsSortedByLevel.Count,
            cardDefinitionsReady = accountReady && HasCardDefinitions(),
            invalidBootstrapQueries = _invalidBootstrapQueries,
            exceptions = _exceptions,
            errors = _errors,
            errorSources = ErrorSources,
            exceptionSources = ExceptionSources
        }, Formatting.Indented) + "\n");
        bool reachedMain = Application.loadedLevelName == "MainScene";
        Debug.Log("UNITY_NORMAL_BOOT_OBSERVED mainScene=" + reachedMain + " exceptions=" + _exceptions +
            " report=" + reportPath);
        bool completed = reachedMain && game != null && _exceptions == 0 && _invalidBootstrapQueries == 0 &&
            (!requireAccount || dataLoadComplete);
        if (completed && requireAccount)
        {
            try
            {
                UnityStarterLoadoutExport.WriteIfRequested();
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                completed = false;
            }
        }
        EditorApplication.Exit(completed ? 0 : 1);
    }
}
