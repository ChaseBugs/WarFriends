using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

/// <summary>Checks original NGUI confirmation animation, localized labels and the original OK callback.</summary>
[InitializeOnLoad]
public static class UnityAbortNoticeAudit
{
    private const string SessionKey = "WarFriends.AbortNoticeAudit";
    private const string RenderKey = SessionKey + ".Render";
    private const int TimeoutSeconds = 10;
    private const int CaptureDepthBits = 24;
    private const int MinimumCaptureWidth = 320;
    private const int MinimumCaptureHeight = 240;
    private const int MinimumDistinctCaptureColors = 16;
    private static readonly List<string> Errors = new List<string>();

    static UnityAbortNoticeAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += BeginWhenPlaying;
        }
    }

    /// <summary>Uses recovered modal objects in a disposable Play Mode scene, without account boot.</summary>
    public static void RunAsync()
    {
        UnityAbortNoticeFixture.PrepareScene();
        SessionState.SetBool(SessionKey, true);
        EditorApplication.update -= BeginWhenPlaying;
        EditorApplication.update += BeginWhenPlaying;
        EditorApplication.isPlaying = true;
    }

    /// <summary>Also captures the real modal through the original camera; requires a graphics-enabled Editor.</summary>
    public static void RunRenderedAsync()
    {
        SessionState.SetBool(RenderKey, true);
        RunAsync();
    }

    private static void BeginWhenPlaying()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        EditorApplication.update -= BeginWhenPlaying;
        RunChecksAsync();
    }

    private static async void RunChecksAsync()
    {
        Application.logMessageReceived += CaptureError;
        try
        {
            ConfirmDialog dialog = UnityAbortNoticeFixture.StartServices();
            UnityRetiredChatAudit.Verify();
            UnityOfflineRegionAudit.Verify();
            UnitySessionReadAudit.Verify();
            await UnityAbortAtlasLoadingAudit.VerifyAsync();
            await UnityCompletedAtlasAudit.VerifyIfRequestedAsync();
            await UnityBattleVisualLoadingAudit.VerifyIfRequestedAsync();
            UnityAbortOfferAudit.Verify();
            VerifyMessageRecoveryGate();
            await VerifyNoticeCycleAsync(dialog, false);
            await VerifyNoticeCycleAsync(dialog, true);
            await UnityLoadingRetryNoticeAudit.VerifyAsync(dialog);

            Require(Errors.Count == 0, "Runtime UI errors: " + string.Join(" | ", Errors.ToArray()));
            Require(UnityEngine.Object.FindObjectOfType<BeanstalkServerManager>() == null &&
                UnityEngine.Object.FindObjectOfType<Chat>() == null &&
                UnityEngine.Object.FindObjectOfType<GameLoginManager>() == null,
                "The isolated modal unexpectedly started account or retired chat services.");
            Debug.Log("PASS: recovered cancellation modal shows translated labels, completes original NGUI tweens, " +
                "acknowledges and closes twice; actual modal only, no full main menu proof.");
            SessionState.SetBool(SessionKey, false);
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            Application.logMessageReceived -= CaptureError;
        }
    }

    private static void VerifyMessageRecoveryGate()
    {
        GameController controller = Singleton<GameController>.instance;
        GuiManager gui = Singleton<GuiManager>.instance;
        MainScreen menu = Array.Find(Resources.FindObjectsOfTypeAll<MainScreen>(),
            candidate => candidate.gameObject.scene.IsValid());
        MessageManager messages = Array.Find(Resources.FindObjectsOfTypeAll<MessageManager>(),
            candidate => candidate.gameObject.scene.IsValid());
        var recovery = typeof(GameController).GetField("_isSelfHostedAbortRecovery",
            BindingFlags.Instance | BindingFlags.NonPublic);
        var queue = (Dictionary<string, DatabaseMessage>)typeof(MessageManager).GetField("mMessages",
            BindingFlags.Instance | BindingFlags.NonPublic).GetValue(messages);
        const string messageId = "AbortRecoveryGateProbe";
        var pending = new DatabaseMessage(new Newtonsoft.Json.Linq.JObject())
        {
            messageId = messageId,
            playerId = "abort-ui-probe",
            messageType = DatabaseMessage.Type.SystemMessage,
        };
        GuiScreen previousScreen = gui.currentScreen;
        bool previousDialogs = menu.showDialogs;
        bool previousRecovery = controller.IsSelfHostedAbortRecovery;
        queue.Add(messageId, pending);
        var routine = (IEnumerator)typeof(MessageManager).GetMethod("CheckForEventsRoutine",
            BindingFlags.Instance | BindingFlags.NonPublic).Invoke(messages, null);
        try
        {
            recovery.SetValue(controller, true);
            gui.currentScreen = null;
            Require(routine.MoveNext() && routine.Current == null,
                "Messages touched an unavailable menu while abort recovery still owned the UI.");
            Require(routine.MoveNext() && routine.Current == null,
                "Messages stopped waiting before abort recovery released ownership.");
            Require(queue[messageId] == pending && !pending.WasShown(),
                "Waiting for recovery consumed or replaced a queued source message.");

            menu.showDialogs = false;
            gui.currentScreen = menu;
            recovery.SetValue(controller, false);
            Require(routine.MoveNext() && routine.Current is WaitForSeconds,
                "Messages did not resume their original menu eligibility loop after recovery.");
            Require(queue[messageId] == pending && !pending.WasShown(),
                "An ineligible screen consumed the retained source message.");
            recovery.SetValue(controller, true);
            var cancelledIterator = (IEnumerator)typeof(MessageManager).GetMethod("CheckForEventsRoutine",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(messages, null);
            RadicalRoutine cancelled = RadicalRoutine.Create(cancelledIterator);
            Require(cancelled.enumerator.MoveNext() && cancelled.enumerator.Current == null,
                "The cancellable source routine did not enter its recovery wait.");
            cancelled.Cancel();
            Require(!cancelled.enumerator.MoveNext() && queue[messageId] == pending && !pending.WasShown(),
                "Stopping a recovery wait consumed a message or left the source routine running.");
            ((IDisposable)cancelledIterator).Dispose();
            Debug.Log("PASS: source message iterator waits through abort recovery, retains its queue and " +
                "resumes normal screen eligibility; no full popup or menu boot proof.");
        }
        finally
        {
            recovery.SetValue(controller, previousRecovery);
            gui.currentScreen = previousScreen;
            menu.showDialogs = previousDialogs;
            queue.Remove(messageId);
            ((IDisposable)routine).Dispose();
        }
    }

    private static async Task VerifyNoticeCycleAsync(ConfirmDialog dialog, bool acknowledgeBeforePolling)
    {
        using (var messages = new UnityAbortMessageProbe())
        {
            bool acknowledged = false;
            string title = Localization.Localize("ID_CONFIRM_INFO");
            string message = Localization.Localize("ID_BATTLECANCELED");
            Require(title != "ID_CONFIRM_INFO" && message != "ID_BATTLECANCELED",
                "The original source strings did not resolve.");
            ConfirmDialog.ShowAlert((owner, accepted) => acknowledged = true, title, message);
            messages.VerifyBlocked();
            Require(!dialog.isFullyShowed, "ShowAlert must expose its asynchronous animation before completion.");
            var wait = (IEnumerator)typeof(GameController).GetMethod("WaitForAbortedNoticeRoutine",
                BindingFlags.Static | BindingFlags.NonPublic).Invoke(null,
                new object[] { dialog, new Func<bool>(() => acknowledged) });
            Require(wait.MoveNext(), "Recovery released its owner before the original notice had appeared.");
            await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
            Require(dialog.gameObject.activeInHierarchy && dialog.okButton.gameObject.activeInHierarchy &&
                !dialog.yesButton.gameObject.activeSelf && !dialog.cancelButton.gameObject.activeSelf &&
                dialog.dialogTitle.text == title && dialog.dialogText.text == message,
                "The recovered alert did not show its original localized labels and OK-only controls.");
            Require(dialog.GetComponent<UIPanel>().alpha1 > 0.99f,
                "The recovered modal panel did not finish its actual alpha tween.");
            messages.VerifyBlocked();
            GameObject selectedButton = FindOriginalOkButton(dialog);
            if (!acknowledgeBeforePolling && SessionState.GetBool(RenderKey, false))
            {
                int frame = Time.frameCount;
                await WaitAsync(() => Time.frameCount > frame);
                CaptureModal();
            }
            var click = UIEventListener.Get(dialog.okButton.gameObject).onClick;
            Require(click != null, "The original OK listener was not wired by Awake.");
            if (!acknowledgeBeforePolling)
            {
                Require(!wait.MoveNext(), "A fully visible notice did not finish the recovery wait.");
            }

            click(selectedButton);
            Require(acknowledged, "The original OK callback did not acknowledge the notice.");
            messages.VerifyBlocked();
            if (acknowledgeBeforePolling)
            {
                Require(!wait.MoveNext(), "Immediate acknowledgement left recovery waiting for a hidden notice.");
            }
            await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);
            Require(!UIDraggablePanel.panelDisabled, "Closing the modal left NGUI dragging locked.");
            messages.VerifyDelivered();
        }
    }

    private static GameObject FindOriginalOkButton(ConfirmDialog dialog)
    {
        Require(dialog.okButton.isEnabled, "The visible OK button has no enabled source collider.");
        Physics.SyncTransforms();
        Vector3 clickPosition = Singleton<GuiManager>.instance.guiCamera
            .WorldToScreenPoint(dialog.okButton.transform.position);
        var hit = new RaycastHit();
        Require(UICamera.Raycast(clickPosition, ref hit) && hit.collider != null &&
            hit.collider.gameObject == dialog.okButton.gameObject,
            "The original NGUI raycaster cannot select the visible OK button.");
        return hit.collider.gameObject;
    }

    private static async Task WaitAsync(Func<bool> completed)
    {
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (!completed())
        {
            Require(DateTime.UtcNow < deadline, "The original modal transition did not complete.");
            await Task.Yield();
        }
    }

    private static void CaptureModal()
    {
        Require(SystemInfo.graphicsDeviceType.ToString() != "Null", "A real graphics device is required for capture.");
        Require(Screen.width >= MinimumCaptureWidth && Screen.height >= MinimumCaptureHeight,
            "The capture viewport is too small to inspect the original modal.");
        Camera camera = Singleton<GuiManager>.instance.guiCamera;
        var texture = new RenderTexture(Screen.width, Screen.height, CaptureDepthBits);
        var pixels = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        RenderTexture oldTarget = camera.targetTexture;
        RenderTexture oldActive = RenderTexture.active;
        try
        {
            camera.targetTexture = texture;
            camera.Render();
            RenderTexture.active = texture;
            pixels.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
            pixels.Apply();
            VerifyCaptureContents(pixels);
            string path = Path.GetFullPath(Path.Combine(Application.dataPath, "../../abort-notice-recovered.png"));
            File.WriteAllBytes(path, pixels.EncodeToPNG());
            Debug.Log("PASS: original modal camera capture saved: " + path);
        }
        finally
        {
            camera.targetTexture = oldTarget;
            RenderTexture.active = oldActive;
            UnityEngine.Object.Destroy(texture);
            UnityEngine.Object.Destroy(pixels);
        }
    }

    private static void VerifyCaptureContents(Texture2D pixels)
    {
        var colors = new HashSet<int>();
        foreach (Color32 pixel in pixels.GetPixels32())
        {
            int color = (pixel.r << 16) | (pixel.g << 8) | pixel.b;
            colors.Add(color);
            if (colors.Count >= MinimumDistinctCaptureColors)
            {
                return;
            }
        }

        throw new InvalidOperationException("The capture is blank or lacks inspectable modal graphics.");
    }

    private static void CaptureError(string message, string stack, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
        {
            Errors.Add(message);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
