using System;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>Checks retry ownership using the recovered modal, its actual NGUI tweens and button listener.</summary>
public static class UnityLoadingRetryNoticeAudit
{
    private const int TimeoutSeconds = 10;

    /// <summary>Requires a single original Retry action and preserves unrelated or replacement notices.</summary>
    public static async Task VerifyAsync(ConfirmDialog dialog)
    {
        int retries = 0;
        bool isCurrentOwner = true;
        var notice = new BattleLoadingRetryNotice(() => isCurrentOwner, () => retries++);
        Require(notice.TryShow(), "An idle original modal did not accept the retry notice.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        Require(dialog.okLabel.text == Localization.Localize("ID_RETRY") &&
            dialog.dialogText.text == Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"),
            "Retry notice lost its original localized label or connection failure message.");
        Action<ConfirmDialog, bool> captured = dialog.dialogResult;
        Require(notice.TryShow() && dialog.dialogResult == captured, "Repeated polling replaced the retry callback.");
        Click(dialog);
        captured(dialog, true);
        Require(retries == 1, "A repeated or delayed click retried the same notice twice.");
        await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);

        int foreignClicks = 0;
        Action<ConfirmDialog, bool> foreign = (owner, accepted) => foreignClicks++;
        ConfirmDialog.ShowAlert(foreign, "Existing notice", "Preserve this notice.");
        var waiting = new BattleLoadingRetryNotice(() => true, () => retries++);
        Require(!waiting.TryShow() && dialog.dialogResult == foreign,
            "The retry notice overwrote an existing popup.");
        waiting.Close();
        Require(dialog.dialogResult == foreign, "Closing a waiting retry notice cleared another popup's callback.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        Click(dialog);
        await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);
        Require(foreignClicks == 1, "The existing popup lost its original callback.");

        var stale = new BattleLoadingRetryNotice(() => isCurrentOwner, () => retries++);
        Require(stale.TryShow(), "A fresh owner could not show after the previous notice closed.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        captured = dialog.dialogResult;
        isCurrentOwner = false;
        Require(!stale.TryShow(), "A stale owner's retry notice remained active.");
        captured(dialog, true);
        await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);
        Require(retries == 1, "A stale callback retried a released or replaced match.");

        await VerifyReplacementAsync(dialog, foreign);
        await VerifyResumedNoticeAsync(dialog, foreign);
        Debug.Log("PASS: original localized Retry modal handles one click, waits for another popup, " +
            "rejects a stale owner and preserves a replacement callback; no full account/menu proof.");
    }

    private static async Task VerifyReplacementAsync(ConfirmDialog dialog, Action<ConfirmDialog, bool> foreign)
    {
        int retries = 0;
        var notice = new BattleLoadingRetryNotice(() => true, () => retries++);
        Require(notice.TryShow(), "The replacement control could not show its owned notice.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        Action<ConfirmDialog, bool> captured = dialog.dialogResult;
        ConfirmDialog.ShowAlert(foreign, "Replacement", "A different owner now owns this popup.");
        captured(dialog, true);
        Require(retries == 0, "A superseded modal callback retried behind another popup.");
        notice.Close();
        Require(dialog.dialogResult == foreign && dialog.isShowed,
            "Closing a superseded retry notice hid or cleared the replacement popup.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        Click(dialog);
        await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);
    }

    private static void Click(ConfirmDialog dialog)
    {
        var click = UIEventListener.Get(dialog.okButton.gameObject).onClick;
        Require(click != null && dialog.okButton.isEnabled, "The original Retry button is not wired or enabled.");
        click(dialog.okButton.gameObject);
    }

    private static async Task VerifyResumedNoticeAsync(ConfirmDialog dialog, Action<ConfirmDialog, bool> foreign)
    {
        var notice = new BattleLoadingRetryNotice(() => true, () => { });
        Require(notice.TryShow(), "The resumed notice control could not show.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        ConfirmDialog.ShowAlert(foreign, "Temporary notice", "Finish this notice first.");
        Require(!notice.TryShow() && dialog.dialogResult == foreign,
            "A superseded retry notice did not defer to the temporary popup.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        Click(dialog);
        await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);
        Require(notice.TryShow(), "The pending retry notice did not resume after the temporary popup closed.");
        await WaitAsync(() => dialog.isFullyShowed && !dialog.readyToShowUp);
        notice.Close();
        await WaitAsync(() => dialog.isFullyHidden && !dialog.gameObject.activeSelf);
    }

    private static async Task WaitAsync(Func<bool> completed)
    {
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (!completed())
        {
            Require(DateTime.UtcNow < deadline, "The original retry modal did not finish its transition.");
            await Task.Yield();
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
