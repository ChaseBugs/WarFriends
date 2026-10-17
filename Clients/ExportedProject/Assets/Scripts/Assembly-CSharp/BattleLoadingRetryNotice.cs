using System;

/// <summary>Uses the recovered confirmation dialog without taking another notice's callback ownership.</summary>
public sealed class BattleLoadingRetryNotice
{
    private readonly Func<bool> _isCurrentOwner;
    private readonly Action _retry;
    private readonly Action<ConfirmDialog, bool> _callback;
    private ConfirmDialog _dialog;
    private bool _isClosed;

    /// <summary>Binds one retry notice to its failed loading scope and retained match owner.</summary>
    public BattleLoadingRetryNotice(Func<bool> isCurrentOwner, Action retry)
    {
        _isCurrentOwner = isCurrentOwner ?? throw new ArgumentNullException(nameof(isCurrentOwner));
        _retry = retry ?? throw new ArgumentNullException(nameof(retry));
        _callback = OnRetryClicked;
    }

    /// <summary>Waits for other dialogs to finish before showing the original localized retry control.</summary>
    public bool TryShow()
    {
        if (_isClosed || !_isCurrentOwner())
        {
            Close();
            return false;
        }
        if (_dialog != null)
        {
            if (_dialog.dialogResult == _callback)
            {
                return true;
            }
            _dialog = null;
        }
        ConfirmDialog dialog = GuiElementSingle<ConfirmDialog>.instance;
        if (dialog == null || !dialog.isFullyHidden || dialog.readyToShowUp ||
            DialogManager.instance.isSomeDialogShowed)
        {
            return false;
        }

        _dialog = dialog;
        ConfirmDialog.ShowAlert(_callback, Localization.Localize("ID_WARNING_CONNECTIONERROR"),
            Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"));
        dialog.okButtonText = Localization.Localize("ID_RETRY");
        LoadingDialog.Hide();
        return true;
    }

    /// <summary>Releases only this notice; a replacement dialog keeps its callback and visibility.</summary>
    public void Close()
    {
        _isClosed = true;
        if (_dialog != null && _dialog.dialogResult == _callback)
        {
            _dialog.dialogResult = null;
            _dialog.HideDialog();
        }
        _dialog = null;
    }

    private void OnRetryClicked(ConfirmDialog dialog, bool isAccepted)
    {
        if (_isClosed || _dialog != dialog || dialog.dialogResult != _callback)
        {
            return;
        }
        _isClosed = true;
        if (isAccepted && _isCurrentOwner())
        {
            _retry();
        }
    }
}
