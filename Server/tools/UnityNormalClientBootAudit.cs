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
    private const int MaximumPairedStartupSeconds = 150;
    private const int MainSceneObservationFrames = 12;
    private const int MaximumExceptionSamples = 12;
    private const int MaximumErrorSources = 32;
    private const int ProgressIntervalSeconds = 5;
    private const int MaximumProgressSamples = 48;
    private static readonly List<string> ExceptionSources = new List<string>();
    private static readonly Dictionary<string, int> ErrorSources = new Dictionary<string, int>();
    private static readonly FieldInfo CardDefinitionField = typeof(Card).GetField(
        "mCardDefinition", BindingFlags.Instance | BindingFlags.NonPublic);
    private static double _deadline;
    private static int _mainSceneFrame = -1;
    private static int _exceptions;
    private static int _editorIntegrationExceptions;
    private static int _errors;
    private static int _invalidBootstrapQueries;
    private static bool _normalQueueStarted;
    private static bool _hasObservedEditorUpdate;
    private static bool _hasObservedPlayMode;
    private static bool _uiPreparationOpened;
    private static bool _uiAssignmentsDismissed;
    private static double _normalQueueStartedAt;
    private static double _nextProgressTime;
    private static int _progressSamples;
    private static bool _dailyRewardChecked;
    private static int _kinematicCcdErrors;
    private static double _lobbyReadyAt = -1;
    private static bool _botStarted;
    private static bool _botRunning;
    private static bool _botCompleted;
    private static double _botRunningAt;
    private static object _botInitialReadiness;
    private static bool _botResultVisible;
    private static bool _dailyClaimRequested;
    private static bool _dailyReplayRequested;
    private static bool _dailyClaimVerified;
    private static int _dailyClaimResponses;
    private static long _goldBeforeDailyClaim;
    private static long _dailyGoldAmount;
    private static bool _botRenderCaptured;
    private static bool _botIntroCaptured;
    private static object _botRenderInspection;
    private static object _botShieldInspection;

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
        Debug.Log("WAR_BOOT_STAGE: execute-method");
        PlayerSettings.companyName = "WarFriendsValidation";
        string fixtureIdentity = Environment.GetEnvironmentVariable("WAR_LOBBY_BOOT_IDENTITY");
        PlayerSettings.productName = string.IsNullOrEmpty(fixtureIdentity)
            ? "NormalBoot-" + Guid.NewGuid().ToString("N")
            : fixtureIdentity;
        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity");
        Debug.Log("WAR_BOOT_STAGE: splash-opened");
        SessionState.SetBool(SessionKey, true);
        Attach();
        if (WarFriends.Validation.UnityNormalBattleEntryAudit.IsEnabled ||
            Environment.GetEnvironmentVariable("WAR_VERIFY_OFFLINE_BOT") == "1")
        {
            RequireRenderedGameView();
        }
        EditorApplication.isPlaying = true;
        Debug.Log("WAR_BOOT_STAGE: play-requested");
    }

    private static void RequireRenderedGameView()
    {
        if (Application.isBatchMode)
        {
            throw new InvalidOperationException("Normal battle loading requires a non-batch Editor Game view.");
        }

        // Original RadicalRoutine yields WaitForEndOfFrame; a batch Editor cannot resume it.
        PlayerSettings.runInBackground = true;
        Type gameViewType = typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView", true);
        EditorWindow.GetWindow(gameViewType).Show();
    }

    private static void Attach()
    {
        Debug.Log("WAR_BOOT_STAGE: observer-attached");
        _deadline = EditorApplication.timeSinceStartup +
            (WarFriends.Validation.UnityNormalBattleEntryAudit.IsEnabled
                ? MaximumPairedStartupSeconds : MaximumStartupSeconds);
        EditorApplication.update -= Observe;
        EditorApplication.update += Observe;
        Application.logMessageReceived -= ObserveLog;
        Application.logMessageReceived += ObserveLog;
    }

    private static void ObserveLog(string condition, string stackTrace, LogType type)
    {
        if (condition == "daily reward chacked") _dailyRewardChecked = true;
        if (condition == "daily reward claimed") _dailyClaimResponses++;
        if (condition.Contains("kinematic bodies with CCD enabled")) _kinematicCcdErrors++;
        WarFriends.Validation.UnityNormalBattleEntryAudit.RecordStageLog(condition);
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

        if (stackTrace.Contains("SyntaxTree.VisualStudio.Unity."))
        {
            // VSTU's Editor-only UDP discovery can hit a Windows-reserved port.
            // Record it separately; it is not a Client gameplay exception.
            _editorIntegrationExceptions++;
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
        WriteProgressIfDue();
        if (!_hasObservedEditorUpdate)
        {
            _hasObservedEditorUpdate = true;
            Debug.Log("WAR_BOOT_STAGE: editor-update");
        }
        if (!_hasObservedPlayMode && EditorApplication.isPlaying && !EditorApplication.isPaused)
        {
            _hasObservedPlayMode = true;
            Debug.Log("WAR_BOOT_STAGE: play-update");
        }
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
        string queueReport = Environment.GetEnvironmentVariable("WAR_NORMAL_QUEUE_REPORT");
        if (Environment.GetEnvironmentVariable("WAR_VERIFY_OFFLINE_BOT") == "1" &&
            ((_dailyRewardChecked && observedTarget) || _botStarted))
        {
            GameController controller = Singleton<GameController>.instance;
            if (!_botStarted && !_dailyClaimVerified)
            {
                if (!_dailyClaimRequested)
                {
                    _dailyClaimRequested = true;
                    _goldBeforeDailyClaim = Singleton<Wallet>.instance.gold;
                    _dailyGoldAmount = StatsManager.instance.dailyRewardData[1].count;
                    Singleton<BeanstalkServerManager>.instance.claimDailyReward(1);
                }
                else if (_dailyClaimResponses == 1 && !_dailyReplayRequested)
                {
                    _dailyReplayRequested = true;
                    Singleton<BeanstalkServerManager>.instance.claimDailyReward(1);
                }
                else if (_dailyClaimResponses == 2)
                {
                    _dailyClaimVerified = StatsManager.instance.dailyRewardData.lastClaimed == 1 &&
                        Singleton<Wallet>.instance.gold == _goldBeforeDailyClaim + _dailyGoldAmount;
                }
                if (EditorApplication.timeSinceStartup > _deadline) Finish();
                return;
            }
            if (!_botStarted)
            {
                _botStarted = true;
                _botInitialReadiness = WarFriends.Validation.UnityNormalMatchmakingReadinessAudit.Capture(
                    controller, LevelManager.instance);
                _deadline = EditorApplication.timeSinceStartup + 180;
                controller.SwitchToDeathMatch();
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_BOT_RENDER_CAPTURE")))
                    Singleton<MapManager>.instance.currentMap = Singleton<MapManager>.instance.mapEntries
                        .Single(map => map.levelPVPName == (Environment.GetEnvironmentVariable("WAR_BOT_RENDER_SCENE")
                            ?? "Desert_Multiplayer"));
                controller.gameControllerDeathMatch.StartRandomMatchMaking();
            }
            if (!_botRunning && controller.isDeathMatchOffline && controller.gameIsRunning)
            {
                _botRunning = true;
                _botRunningAt = EditorApplication.timeSinceStartup;
            }
            string battleCapture = Environment.GetEnvironmentVariable("WAR_BOT_RENDER_CAPTURE");
            string renderScene = Environment.GetEnvironmentVariable("WAR_BOT_RENDER_SCENE") ?? "Desert_Multiplayer";
            if (!string.IsNullOrEmpty(battleCapture) && !_botIntroCaptured && _botRunning &&
                controller.gameIsRunning && EditorApplication.timeSinceStartup > _botRunningAt + 0.5)
            {
                CaptureCameras(Path.Combine(Path.GetDirectoryName(battleCapture), "battle-intro.png"));
                _botIntroCaptured = true;
            }
            if (!string.IsNullOrEmpty(battleCapture) && !_botRenderCaptured && _botRunning &&
                controller.gameIsRunning && EditorApplication.timeSinceStartup > _botRunningAt + 5)
            {
                MeshRenderer[] geometry = Resources.FindObjectsOfTypeAll<MeshRenderer>()
                    .Where(renderer => renderer.gameObject.scene.name == renderScene &&
                        renderer.GetComponent<MeshFilter>() != null &&
                        renderer.GetComponent<MeshFilter>().sharedMesh != null &&
                        renderer.GetComponent<MeshFilter>().sharedMesh.name.StartsWith("Combined Mesh"))
                    .ToArray();
                _botRenderInspection = new {
                    scene = Application.loadedLevelName,
                    combinedRenderers = geometry.Length,
                    batchedRenderers = geometry.Count(renderer => renderer.isPartOfStaticBatch),
                    terrainRenderers = geometry.Count(renderer => renderer.name.StartsWith("terrain_desert"))
                };
                File.WriteAllText(battleCapture + ".geometry.json", JsonConvert.SerializeObject(new {
                    inspection = _botRenderInspection,
                    unbatched = geometry.Where(renderer => !renderer.isPartOfStaticBatch)
                        .Select(renderer => renderer.name).ToArray()
                }, Formatting.Indented));
                // Gameplay can remove authored destructibles. Validate the surviving geometry
                // and both terrain surfaces rather than requiring the Edit Mode object count.
                if (Application.loadedLevelName != renderScene || geometry.Length == 0 ||
                    geometry.Any(renderer => !renderer.isPartOfStaticBatch))
                {
                    Debug.LogError("Desert static geometry lost its repaired batching metadata.");
                    Finish();
                    return;
                }
                Shield shield = PlayerController.currentPlayer.currentPlayerPoint.point.shield;
                MeshRenderer shieldRenderer = shield.GetComponent<MeshRenderer>();
                Mesh shieldMesh = shield.GetComponent<MeshFilter>().sharedMesh;
                float expectedShieldHp = controller.mainController.GetShieldHP(PlayerController.currentPlayer);
                _botShieldInspection = new {
                    health = shield.health, maxHealth = shield.maxHealth, expectedMaxHealth = expectedShieldHp,
                    mesh = shieldMesh == null ? null : shieldMesh.name,
                    batched = shieldRenderer.isPartOfStaticBatch, enabled = shieldRenderer.enabled,
                    visible = shieldRenderer.isVisible, worldSize = shieldRenderer.bounds.size.ToString(),
                    fraction = shield.fraction.ToString(),
                    position = shield.transform.position.ToString(), lightmap = shieldRenderer.lightmapIndex
                    , material = shieldRenderer.sharedMaterial.name, shader = shieldRenderer.sharedMaterial.shader.name,
                    layer = shield.gameObject.layer, shadowCasting = shieldRenderer.shadowCastingMode.ToString()
                };
                if (shieldMesh == null || shieldMesh.subMeshCount == 0 || shieldRenderer.isPartOfStaticBatch ||
                    !shieldRenderer.enabled || !shield.gameObject.activeInHierarchy || shield.health <= 0 ||
                    shield.maxHealth != expectedShieldHp)
                {
                    Debug.LogError("The player's source-defined default shield is missing or invalid.");
                    Finish();
                    return;
                }
                CaptureShield(shield, Path.Combine(Path.GetDirectoryName(battleCapture), "default-shield.png"));
                CaptureCameras(battleCapture);
                _botRenderCaptured = true;
            }
            double forfeitDelay = string.IsNullOrEmpty(battleCapture) ? 3 : 8;
            if (_botRunning && controller.gameIsRunning && EditorApplication.timeSinceStartup > _botRunningAt + forfeitDelay)
                controller.gameControllerDeathMatchOffline.Forfeit();
            _botCompleted = _botRunning && !controller.gameIsRunning &&
                controller.gameEndServerResponse == GameController.ServerResponse.Success;
            _botResultVisible = _botCompleted && GuiScreenSingle<EndScreen>.instance.isShowed;
            if (_botResultVisible || EditorApplication.timeSinceStartup > _deadline) Finish();
            return;
        }
        if (_mainSceneFrame >= 0 && WarFriends.Validation.UnityNormalBattleEntryAudit.IsEnabled)
        {
            if (!WarFriends.Validation.UnityNormalBattleEntryAudit.Observe() &&
                EditorApplication.timeSinceStartup <= _deadline)
            {
                return;
            }
            Finish();
            return;
        }
        if (observedTarget && !string.IsNullOrEmpty(queueReport))
        {
            if (!_normalQueueStarted)
            {
                _normalQueueStarted = true;
                _normalQueueStartedAt = EditorApplication.timeSinceStartup;
                GameController controller = Resources.FindObjectsOfTypeAll<GameController>()
                    .First(candidate => candidate.gameObject.scene.IsValid());
                controller.SwitchToDeathMatch();
                controller.gameControllerDeathMatch.StartRandomMatchMaking();
            }
            if (!File.Exists(queueReport) && EditorApplication.timeSinceStartup <= _deadline)
            {
                return;
            }
            // This probe verifies human queue admission only. The recovered timeout
            // now deliberately cancels the queue and selects a local bot.
        }
        bool lobbyReady = !requireAccount || (_dailyRewardChecked && !HasBlockingDialog());
        if (observedTarget && lobbyReady && UnityOfflineStoreAudit.Enabled &&
            !UnityOfflineStoreAudit.Observe() && EditorApplication.timeSinceStartup <= _deadline) return;
        if (observedTarget && lobbyReady && _lobbyReadyAt < 0) _lobbyReadyAt = EditorApplication.timeSinceStartup;
        if ((_mainSceneFrame >= 0 && Time.frameCount >= _mainSceneFrame + MainSceneObservationFrames &&
             _lobbyReadyAt >= 0 && EditorApplication.timeSinceStartup >= _lobbyReadyAt + 3) ||
            EditorApplication.timeSinceStartup > _deadline)
        {
            if (observedTarget && lobbyReady && !_uiPreparationOpened &&
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_UI_LOBBY_CAPTURE")))
            {
                CaptureLobbyIfRequested();
                Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
                _uiPreparationOpened = true;
                _lobbyReadyAt = EditorApplication.timeSinceStartup;
                return;
            }
            if (_uiPreparationOpened && !_uiAssignmentsDismissed)
            {
                DailyAssignmentsDialog assignments = GuiElementSingle<DailyAssignmentsDialog>.instance;
                if (assignments != null && assignments.isFullyShowed)
                {
                    CaptureLobbyIfRequested();
                    assignments.OnBack();
                    _uiAssignmentsDismissed = true;
                    _lobbyReadyAt = EditorApplication.timeSinceStartup;
                    return;
                }
            }
            Finish();
        }
    }

    private static void WriteProgressIfDue()
    {
        double editorTime = EditorApplication.timeSinceStartup;
        if (editorTime < _nextProgressTime || _progressSamples >= MaximumProgressSamples)
        {
            return;
        }

        _nextProgressTime = editorTime + ProgressIntervalSeconds;
        _progressSamples++;
        EditorWindow focusedWindow = EditorWindow.focusedWindow;
        string progressPath = Path.Combine(Application.dataPath, "../normal-client-progress.jsonl");
        string sample = JsonConvert.SerializeObject(new
        {
            observedUtc = DateTime.UtcNow,
            editorTime,
            frame = Time.frameCount,
            scene = Application.loadedLevelName,
            isPlaying = EditorApplication.isPlaying,
            isPaused = EditorApplication.isPaused,
            isCompiling = EditorApplication.isCompiling,
            timeScale = Time.timeScale,
            focusedWindow = focusedWindow == null ? null : focusedWindow.GetType().FullName
        });
        File.AppendAllText(progressPath, sample + Environment.NewLine);
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

    private static bool HasBlockingDialog()
    {
        return Resources.FindObjectsOfTypeAll<WarningDialog>()
            .Any(dialog => dialog.gameObject.scene.IsValid() && dialog.isShowed);
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
        bool pairedEntry = WarFriends.Validation.UnityNormalBattleEntryAudit.IsEnabled;
        bool accountReady = GameLoginManager.currentPlayer != null &&
            (Application.loadedLevelName == "MainScene" || (pairedEntry || _botStarted) && _mainSceneFrame >= 0);
        bool dataLoadComplete = accountReady && (HasAccountAndUnits() || _botStarted);
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
            dailyRewardChecked = _dailyRewardChecked,
            dailyRewardClaimVerified = _dailyClaimVerified,
            offlineStoreVerified = UnityOfflineStoreAudit.Completed,
            blockingDialogVisible = HasBlockingDialog(),
            kinematicCcdErrors = _kinematicCcdErrors,
            initializedUnitRows = levels == null ? 0 : levels.unitsSortedByLevel.Count,
            initializedWeaponRows = levels == null ? 0 : levels.weaponsSortedByLevel.Count,
            cardDefinitionsReady = accountReady && (HasCardDefinitions() || _botStarted),
            normalBattle = WarFriends.Validation.UnityNormalBattleEntryAudit.IsEnabled
                ? WarFriends.Validation.UnityNormalBattleEntryAudit.Capture() : null,
            normalQueueStarted = _normalQueueStarted,
            offlineBotStarted = _botStarted,
            offlineBotRunning = _botRunning,
            offlineBotCompleted = _botCompleted,
            offlineBotResultVisible = _botResultVisible,
            battleRenderCaptured = _botRenderCaptured,
            battleRenderInspection = _botRenderInspection,
            battleShieldInspection = _botShieldInspection,
            offlinePendingBattles = OfflineBotProgress.PendingBattleCount,
            offlineAccountLoaded = OfflineBotProgress.IsDisconnected,
            normalQueueStayedServerOwned = !_normalQueueStarted || !HasLegacyBotFallback(),
            normalQueueObserved = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_NORMAL_QUEUE_REPORT")) &&
                File.Exists(Environment.GetEnvironmentVariable("WAR_NORMAL_QUEUE_REPORT")),
            matchmakingReadiness = _botStarted ? _botInitialReadiness : dataLoadComplete
                ? WarFriends.Validation.UnityNormalMatchmakingReadinessAudit.Capture(game, levels)
                : null,
            invalidBootstrapQueries = _invalidBootstrapQueries,
            exceptions = _exceptions,
            editorIntegrationExceptions = _editorIntegrationExceptions,
            errors = _errors,
            errorSources = ErrorSources,
            exceptionSources = ExceptionSources
        }, Formatting.Indented) + "\n");
        bool reachedMain = Application.loadedLevelName == "MainScene";
        Debug.Log("UNITY_NORMAL_BOOT_OBSERVED mainScene=" + reachedMain + " exceptions=" + _exceptions +
            " report=" + reportPath);
        bool reachedTarget = _botStarted ? _botResultVisible : pairedEntry
            ? WarFriends.Validation.UnityNormalBattleEntryAudit.HasCompletedEntry : reachedMain;
        bool hasRequiredData = !requireAccount || (pairedEntry ? _mainSceneFrame >= 0 : dataLoadComplete);
        bool completed = reachedTarget && game != null && _exceptions == 0 && _invalidBootstrapQueries == 0 &&
            (!_botStarted || (_botResultVisible && _errors == 0)) &&
            (!_botStarted || string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_BOT_RENDER_CAPTURE")) ||
                _botRenderCaptured) &&
            (!_normalQueueStarted || (!HasLegacyBotFallback() && _errors == 0 && !HasBlockingDialog())) &&
            hasRequiredData && _kinematicCcdErrors == 0 &&
            (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_UI_LOBBY_CAPTURE")) || _errors == 0) &&
            (!UnityOfflineStoreAudit.Enabled || (UnityOfflineStoreAudit.Completed && _errors == 0)) &&
            (!requireAccount || pairedEntry || (_dailyRewardChecked && !HasBlockingDialog()));
        if (completed && requireAccount && !pairedEntry)
        {
            try
            {
                UnityStarterLoadoutExport.WriteIfRequested();
                CaptureLobbyIfRequested();
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                completed = false;
            }
        }
        EditorApplication.Exit(completed ? 0 : 1);
    }

    private static bool HasLegacyBotFallback()
    {
        GameControllerDeathMatch controller = Singleton<GameController>.instance.gameControllerDeathMatch;
        return (bool)typeof(GameControllerDeathMatch).GetField("mFakeBatteleWithBot",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(controller);
    }

    private static void CaptureLobbyIfRequested()
    {
        string path = Environment.GetEnvironmentVariable("WAR_UI_LOBBY_CAPTURE");
        if (string.IsNullOrEmpty(path)) return;
        if (_uiPreparationOpened) path = Path.Combine(Path.GetDirectoryName(path), "battle-preparation.png");
        if (_uiPreparationOpened && !_uiAssignmentsDismissed &&
            GuiElementSingle<DailyAssignmentsDialog>.instance.isShowed)
            path = Path.Combine(Path.GetDirectoryName(path), "daily-assignments.png");
        File.WriteAllText(path + ".widgets.json", JsonConvert.SerializeObject(
            UnityEngine.Object.FindObjectsOfType<UIWidget>().Select(sprite => new {
                name = sprite.name, type = sprite.GetType().Name,
                spriteName = sprite is UISprite ? ((UISprite)sprite).spriteName : null,
                atlas = sprite is UISprite && ((UISprite)sprite).atlas != null ? ((UISprite)sprite).atlas.name : null,
                texture = sprite.mainTexture == null ? null : sprite.mainTexture.name,
                textureWidth = sprite.mainTexture == null ? 0 : sprite.mainTexture.width,
                shader = sprite.material == null ? null : sprite.material.shader.name,
                alpha = sprite.alpha,
                screen = NGUITools.FindCameraForLayer(sprite.gameObject.layer).WorldToViewportPoint(sprite.transform.position).ToString(),
                position = sprite.transform.position.ToString(),
                parent = sprite.transform.parent == null ? null : sprite.transform.parent.name
            }), Formatting.Indented));
        CaptureCameras(path);
    }

    private static void CaptureShield(Shield shield, string path)
    {
        MeshRenderer renderer = shield.GetComponent<MeshRenderer>();
        Camera camera = new GameObject("Default shield rendering audit").AddComponent<Camera>();
        camera.transform.position = renderer.bounds.center + shield.transform.up * 1.25f;
        camera.transform.LookAt(renderer.bounds.center);
        camera.orthographic = true;
        camera.orthographicSize = 0.4f;
        camera.nearClipPlane = 0.02f;
        camera.farClipPlane = 10;
        camera.cullingMask = 1 << shield.gameObject.layer;
        camera.useOcclusionCulling = false;
        var target = new RenderTexture(512, 512, 24);
        var image = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            camera.targetTexture = target;
            camera.Render();
            RenderTexture.active = target;
            image.ReadPixels(new Rect(0, 0, 512, 512), 0, 0);
            image.Apply();
            File.WriteAllBytes(path, image.EncodeToPNG());

        }
        finally
        {
            RenderTexture.active = previous;
            UnityEngine.Object.DestroyImmediate(camera.gameObject);
            UnityEngine.Object.DestroyImmediate(image);
            UnityEngine.Object.DestroyImmediate(target);
        }
    }

    private static void CaptureCameras(string path)
    {
        var target = new RenderTexture(Screen.width, Screen.height, 24);
        var image = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            foreach (Camera camera in Camera.allCameras.OrderBy(camera => camera.depth))
            {
                RenderTexture oldTarget = camera.targetTexture;
                if (oldTarget != null) continue;
                try
                {
                    camera.targetTexture = target;
                    camera.Render();
                }
                finally { camera.targetTexture = oldTarget; }
            }
            RenderTexture.active = target;
            image.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            image.Apply();
            File.WriteAllBytes(path, image.EncodeToPNG());
        }
        finally
        {
            RenderTexture.active = previous;
            UnityEngine.Object.DestroyImmediate(image);
            UnityEngine.Object.DestroyImmediate(target);
        }
    }
}
