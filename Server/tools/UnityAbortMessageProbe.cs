using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>Checks source queue delivery against the recovered modal registry without account boot.</summary>
public sealed class UnityAbortMessageProbe : IDisposable
{
    private const string MessageId = "AbortNoticePendingMessage";
    private const string PlayerId = "abort-notice-probe";
    private readonly MessageManager _manager;
    private readonly DatabaseMessage _message;
    private readonly Dictionary<string, DatabaseMessage> _pending;
    private readonly Dictionary<string, DatabaseMessage> _shown;
    private readonly MethodInfo _dispatch;

    /// <summary>Enqueues one base source message without a concrete reward or account side effect.</summary>
    public UnityAbortMessageProbe()
    {
        _manager = Array.Find(Resources.FindObjectsOfTypeAll<MessageManager>(),
            candidate => candidate.gameObject.scene.IsValid());
        _pending = ReadMessages("mMessages");
        _shown = ReadMessages("mShownMessages");
        Require(_pending.Count == 0 && !_shown.ContainsKey(MessageId + "-" + PlayerId),
            "The isolated source queue is not empty before the delivery probe.");
        _message = new DatabaseMessage(new JObject())
        {
            messageId = MessageId,
            playerId = PlayerId,
            messageType = DatabaseMessage.Type.SystemMessage,
        };
        _dispatch = typeof(MessageManager).GetMethod("ShowEvent", BindingFlags.Instance | BindingFlags.NonPublic);
        _manager.AddMessage(_message);
        Require(_message.CanShow(), "The original dialog registry already blocks a clean notice cycle.");
    }

    /// <summary>Requires the real registry and dispatcher to retain the message while a modal is active.</summary>
    public void VerifyBlocked()
    {
        Require(DialogManager.instance.isSomeDialogShowed && !_message.CanShow(),
            "The original registry did not block messages during the cancellation modal.");
        _dispatch.Invoke(_manager, null);
        Require(_pending.ContainsKey(MessageId) && _pending[MessageId] == _message && !_message.WasShown(),
            "Source dispatch consumed the waiting message before the cancellation modal finished hiding.");
    }

    /// <summary>Requires normal source delivery and shown-history migration after the modal is inactive.</summary>
    public void VerifyDelivered()
    {
        Require(!DialogManager.instance.isSomeDialogShowed && _message.CanShow(),
            "The source queue stayed blocked after the cancellation modal became inactive.");
        _dispatch.Invoke(_manager, null);
        Require(_message.WasShown() && _pending.ContainsKey(MessageId),
            "Eligible source dispatch did not mark the retained message as shown.");
        _dispatch.Invoke(_manager, null);
        Require(!_pending.ContainsKey(MessageId) && _shown[MessageId + "-" + PlayerId] == _message,
            "Source dispatch did not move the shown message to its original replay history.");
        Debug.Log("PASS: original dialog registry blocks source queue delivery through opening, visible and " +
            "hiding states; dispatch resumes and records the message after the modal is inactive.");
    }

    /// <summary>Removes only this probe's queue and history identities.</summary>
    public void Dispose()
    {
        _pending.Remove(MessageId);
        _shown.Remove(MessageId + "-" + PlayerId);
    }

    private Dictionary<string, DatabaseMessage> ReadMessages(string fieldName)
    {
        return (Dictionary<string, DatabaseMessage>)typeof(MessageManager)
            .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_manager);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
