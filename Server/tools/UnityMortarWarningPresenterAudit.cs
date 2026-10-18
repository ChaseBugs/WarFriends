using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks original warning sprites driven by an actual UDP checkpoint, plus isolated camera rendering.</summary>
[InitializeOnLoad]
public static class UnityMortarWarningPresenterAudit
{
    private const string PlaySessionKey = "WarFriends.MortarWarningPlayAudit";
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const float Tolerance = 0.00001f;
    private const string MatchId = "mortar-presenter-audit";
    private static readonly string ManifestHash = new string('a', 64);
    private static int _checks;

    static UnityMortarWarningPresenterAudit()
    {
        if (SessionState.GetBool(PlaySessionKey, false))
        {
            EditorApplication.update += BeginPlayChecks;
        }
    }

    /// <summary>Checks automatic Unity lifecycle callbacks in an isolated Play Mode scene.</summary>
    public static void RunPlay()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        SessionState.SetBool(PlaySessionKey, true);
        EditorApplication.update -= BeginPlayChecks;
        EditorApplication.update += BeginPlayChecks;
        EditorApplication.isPlaying = true;
    }

    private static void BeginPlayChecks()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        EditorApplication.update -= BeginPlayChecks;
        CheckAutomaticLifecycleAsync();
    }

    private static async void CheckAutomaticLifecycleAsync()
    {
        try
        {
            string fixture = Environment.GetEnvironmentVariable("WAR_MORTAR_WARNING_FIXTURE");
            var row = BattleMortarWarningState.Parser.ParseFrom(File.ReadAllBytes(
                Path.Combine(fixture, "mortar-warning.pb")));
            var clientRoot = new GameObject("InactiveWarningClient");
            clientRoot.SetActive(false);
            SelfHostedBattleClient client = clientRoot.AddComponent<SelfHostedBattleClient>();
            ConfigureClient(client, row);
            var world = new GameObject("WarningWorld");
            var owner = new GameObject("WarningPresenter");
            SelfHostedMortarWarningPresenter presenter = owner.AddComponent<SelfHostedMortarWarningPresenter>();
            presenter.enabled = false;
            Mortar source = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/MortarEnemy.prefab")
                .GetComponent<Mortar>();
            presenter.Configure(client, source, world.transform);
            Require(!(bool)Field(presenter, "_isSubscribed"), "Disabled configuration subscribed callbacks.");
            presenter.enabled = true;
            Require((bool)Field(presenter, "_isSubscribed"), "Automatic OnEnable did not subscribe.");
            presenter.ApplyScan(Batch(row, row.ObservedTick));
            var visuals = (SelfHostedMortarWarningVisual[])Field(presenter, "_visuals");
            Require(visuals[row.WeaponSlot].Root.gameObject.activeSelf, "Play Mode warning was not shown.");
            owner.SetActive(false);
            Require(!(bool)Field(presenter, "_isSubscribed") &&
                !visuals[row.WeaponSlot].Root.gameObject.activeSelf, "Automatic OnDisable failed to clear ownership.");
            owner.SetActive(true);
            Require((bool)Field(presenter, "_isSubscribed"), "Reactivation did not restore one subscription boundary.");
            UnityEngine.Object.Destroy(owner);
            await System.Threading.Tasks.Task.Delay(200);
            Require(world.transform.childCount == 0, "Automatic OnDestroy leaked warning roots.");
            Debug.Log("PASS: " + _checks + " automatic Mortar warning Play Mode lifecycle checks.");
            SessionState.SetBool(PlaySessionKey, false);
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            SessionState.SetBool(PlaySessionKey, false);
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var clientRoot = new GameObject("InactiveWarningClient");
        clientRoot.SetActive(false);
        var presenterRoot = new GameObject("MortarWarningPresenterAudit");
        var world = new GameObject("MortarWarningWorld");
        try
        {
            string fixture = Environment.GetEnvironmentVariable("WAR_MORTAR_WARNING_FIXTURE");
            var row = BattleMortarWarningState.Parser.ParseFrom(File.ReadAllBytes(
                Path.Combine(fixture, "mortar-warning.pb")));
            SelfHostedBattleClient client = clientRoot.AddComponent<SelfHostedBattleClient>();
            MatchSnapshot state = ConfigureClient(client, row);
            Mortar source = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/MortarEnemy.prefab")
                .GetComponent<Mortar>();
            SelfHostedMortarWarningPresenter presenter = presenterRoot.AddComponent<SelfHostedMortarWarningPresenter>();
            presenter.Configure(client, source, world.transform);
            presenter.ApplyScan(Batch(row, row.ObservedTick));
            var visuals = (SelfHostedMortarWarningVisual[])Field(presenter, "_visuals");
            Transform root = visuals[row.WeaponSlot].Root;
            VerifySourceVisual(root, source, row);
            RenderImage(root);
            VerifyClockAndScans(presenter, state, row, root);
            VerifyInvalidAndTerminal(presenter, state, row, root);
            presenter.enabled = false;
            // This Edit Mode harness invokes lifecycle methods; it does not enter Play Mode.
            Invoke(presenter, "OnDisable");
            Require(!(bool)Field(presenter, "_isSubscribed"), "Disabled presenter retained network callbacks.");
            presenter.ApplyScan(Batch(row, row.ObservedTick));
            Require(!root.gameObject.activeSelf, "A delayed callback revived a disabled warning presenter.");
            Invoke(presenter, "OnDestroy");
            Require(world.transform.childCount == 0, "Presenter teardown leaked world warning roots.");
            File.WriteAllText(Path.Combine(Application.dataPath, "../mortar-warning-presenter-audit.json"),
                "{\"checks\":" + _checks + ",\"scope\":\"isolated source sprite rendering and checkpoint presenter lifecycle\"}\n");
            Debug.Log("PASS: " + _checks + " Mortar warning presenter/render checks; no normal two-client match proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(presenterRoot);
            UnityEngine.Object.DestroyImmediate(clientRoot);
            UnityEngine.Object.DestroyImmediate(world);
        }
    }

    private static MatchSnapshot ConfigureClient(SelfHostedBattleClient client, BattleMortarWarningState row)
    {
        string localId = new string('b', 32);
        var state = new MatchSnapshot
        {
            MatchId = MatchId, ManifestHash = ManifestHash, Phase = BattlePhase.Running, ServerTick = row.ObservedTick
        };
        SetProperty(client, "IsConnected", true);
        SetProperty(client, "State", state);
        SetProperty(client, "LocalPlayerId", localId);
        SetProperty(client, "PlayerViews", new List<BattlePlayerView>
        {
            new BattlePlayerView { PlayerId = localId, Fraction = row.ObserverFraction },
            new BattlePlayerView { PlayerId = row.OwnerPlayerId, Fraction = row.OwnerFraction }
        });
        return state;
    }

    private static void VerifySourceVisual(Transform root, Mortar source, BattleMortarWarningState row)
    {
        Require(root.gameObject.activeSelf && Vector3.Distance(root.position, new Vector3(row.X, row.Y, row.Z)) < Tolerance,
            "Warning did not retain its authoritative world position.");
        Quaternion rotation = Quaternion.AngleAxis(row.RotationFactor * 360f, Vector3.up) * Quaternion.Euler(90f, 0f, 0f);
        Require(Mathf.Abs(Quaternion.Dot(root.localRotation, rotation)) > 1f - Tolerance &&
            Vector3.Distance(root.localScale, Vector3.one * row.Scale) < Tolerance, "Source warning pose is incorrect.");
        tk2dSprite[] copies = root.GetComponentsInChildren<tk2dSprite>(true);
        tk2dSprite[] originals = source.indicator.GetComponentsInChildren<tk2dSprite>(true);
        Require(copies.Length == originals.Length && copies.Length > 0, "Recovered warning sprites were not copied.");
        for (int index = 0; index < copies.Length; index++)
        {
            Material material = copies[index].GetComponent<Renderer>().sharedMaterial;
            Require(material != null && material.mainTexture != null,
                "Warning material has no atlas texture; a solid quad is not valid source rendering.");
            Require(copies[index].Collection == originals[index].Collection && copies[index].spriteId == originals[index].spriteId &&
                Math.Abs(copies[index].color.a - row.Alpha) < Tolerance &&
                copies[index].GetComponent<MeshFilter>().sharedMesh.vertexCount > 0,
                "Warning lost its original collection, sprite, mesh or authoritative alpha.");
        }
        foreach (MonoBehaviour component in root.GetComponentsInChildren<MonoBehaviour>(true))
        {
            Require(component is tk2dSprite, "Warning copy activated a gameplay or legacy tween component.");
        }
    }

    private static void VerifyClockAndScans(SelfHostedMortarWarningPresenter presenter, MatchSnapshot state,
        BattleMortarWarningState source, Transform root)
    {
        state.ServerTick += 5;
        Invoke(presenter, "Update");
        BattleMortarWarningState expected = MortarWarningReconstruction.AtTick(source, state.ServerTick);
        Require(Math.Abs(root.localScale.x - expected.Scale) < Tolerance, "Presenter did not advance source game ticks.");
        state.PauseHostTick = 1;
        float scale = root.localScale.x;
        Invoke(presenter, "Update");
        Require(root.localScale.x == scale, "Paused authoritative time changed the warning.");
        state.PauseHostTick = 0;
        BattleMortarWarningState future = MortarWarningReconstruction.AtTick(source, state.ServerTick + 1);
        presenter.ApplyScan(Batch(future, future.ObservedTick));
        Require(root.localScale.x == scale, "A newer-than-state scan rendered before its authoritative tick.");
        state.ServerTick++;
        Invoke(presenter, "ApplyState", state);
        Require(Math.Abs(root.localScale.x - future.Scale) < Tolerance, "Deferred scan did not apply at its state tick.");
        state.ServerTick++;
        presenter.ApplyScan(Batch(null, state.ServerTick));
        Require(!root.gameObject.activeSelf, "An empty authoritative warning scan retained a stale visual.");
        presenter.ApplyScan(Batch(source, source.ObservedTick));
        Require(!root.gameObject.activeSelf, "An older scan resurrected a retired warning.");
    }

    private static MatchProjectileBatch Batch(BattleMortarWarningState row, ulong tick)
    {
        var result = new MatchProjectileBatch
        {
            MatchId = MatchId, ManifestHash = ManifestHash, Code = "projectiles", ScanId = 1, SnapshotTick = tick
        };
        if (row != null)
        {
            result.MortarWarnings.Add(row.Clone());
        }
        return result;
    }

    private static void VerifyInvalidAndTerminal(SelfHostedMortarWarningPresenter presenter, MatchSnapshot state,
        BattleMortarWarningState source, Transform root)
    {
        presenter.Clear();
        state.ServerTick = source.ObservedTick;
        presenter.ApplyScan(Batch(source, source.ObservedTick));
        float scale = root.localScale.x;
        MatchProjectileBatch malformed = Batch(source, source.ObservedTick);
        malformed.MortarWarnings[0].Clock = null;
        bool wasRejected = false;
        try
        {
            presenter.ApplyScan(malformed);
        }
        catch (InvalidOperationException)
        {
            wasRejected = true;
        }
        Require(wasRejected && root.gameObject.activeSelf && root.localScale.x == scale,
            "An invalid checkpoint changed the previously accepted warning.");

        state.Phase = BattlePhase.Ended;
        Invoke(presenter, "ApplyState", state);
        Require(!root.gameObject.activeSelf, "A terminal match retained a warning.");
        state.Phase = BattlePhase.Running;
    }

    private static void RenderImage(Transform root)
    {
        var cameraRoot = new GameObject("MortarWarningAuditCamera");
        var target = new RenderTexture(256, 256, 24);
        var image = new Texture2D(256, 256, TextureFormat.RGB24, false);
        RenderTexture previous = RenderTexture.active;
        try
        {
            Bounds bounds = root.GetComponentInChildren<Renderer>().bounds;
            Camera camera = cameraRoot.AddComponent<Camera>();
            camera.orthographic = true;
            camera.orthographicSize = Mathf.Max(0.5f, Mathf.Max(bounds.extents.x, bounds.extents.z) * 1.25f);
            camera.transform.position = bounds.center + Vector3.up * 10f;
            camera.transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = Color.black;
            camera.targetTexture = target;
            camera.Render();
            RenderTexture.active = target;
            image.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
            image.Apply();
            int visible = 0;
            foreach (Color pixel in image.GetPixels())
            {
                if (pixel.maxColorComponent > 0.02f)
                {
                    visible++;
                }
            }
            Require(visible > 25, "Original warning sprites produced a blank camera render.");
            File.WriteAllBytes(Path.Combine(Application.dataPath, "../mortar-warning-presenter.png"), image.EncodeToPNG());
        }
        finally
        {
            RenderTexture.active = previous;
            UnityEngine.Object.DestroyImmediate(cameraRoot);
            UnityEngine.Object.DestroyImmediate(target);
            UnityEngine.Object.DestroyImmediate(image);
        }
    }

    private static object Field(object owner, string name) { return owner.GetType().GetField(name, PrivateInstance).GetValue(owner); }
    private static void SetProperty(object owner, string name, object value) { owner.GetType().GetProperty(name).SetValue(owner, value, null); }
    private static void Invoke(object owner, string method, params object[] arguments)
    {
        owner.GetType().GetMethod(method, PrivateInstance).Invoke(owner, arguments);
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
