using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

/// <summary>Checks the recovered Chat entry points with original scene data and inactive local providers.</summary>
public static class UnityRetiredChatAudit
{
    private const BindingFlags InstanceFields = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    private const BindingFlags StaticFields = BindingFlags.Static | BindingFlags.NonPublic;

    /// <summary>Requires initialization, transition calls and stale callbacks to leave Photon Chat unavailable.</summary>
    public static void Verify()
    {
        Chat chat = FindSceneComponent<Chat>();
        BeanstalkServerManager backend = FindSceneComponent<BeanstalkServerManager>();
        GameLoginManager login = FindSceneComponent<GameLoginManager>();
        DebugSettings debug = DebugSettings.instance;
        var restore = new List<Action>();
        PreserveStatic(typeof(Singleton<Chat>), "_instance", chat, restore);
        PreserveStatic(typeof(Singleton<BeanstalkServerManager>), "_instance", backend, restore);
        PreserveStatic(typeof(GameLoginManager), "mInstance", login, restore);
        PreserveEvents(backend, new[] { "PlayerDataLoaded", "DataLoaded", "UserWasLoggetOut" }, restore);
        PreserveEvents(login, new[] { "PlayerJoinedSquad", "PlayerLeftSquad" }, restore);
        PreserveEvents(debug, new[] { "Changed" }, restore);
        ChatTab tab = GuiElementSingle<ChatGuiElement>.instance.chatContent;
        bool wasPanelActive = tab.chatPanel.gameObject.activeSelf;
        tab.chatPanel.gameObject.SetActive(false);
        try
        {
            Require(chat.badWords != null, "The source Chat filtering asset is missing.");
            typeof(Chat).GetMethod("Awake", InstanceFields).Invoke(chat, null);
            typeof(Chat).GetMethod("OnEnable", InstanceFields).Invoke(chat, null);
            typeof(Chat).GetMethod("OnEnable", InstanceFields).Invoke(chat, null);
            VerifySubscriptionCount(chat, backend, login, 1);
            int echoed = 0;
            Action<string, Chat.ChatRecordData[]> arrived = (channel, messages) => echoed += messages.Length;
            chat.newArrivedMessages += arrived;
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    chat.Connect();
                    chat.Disconnect();
                    chat.OnConnected();
                    chat.OnDisconnected();
                }
                List<Chat.ChatRecordData> history;
                chat.GetMessages(out history);
                chat.SendChatMessage("This message has no accepted self-hosted transport.");
                chat.OnGetMessages("global", new[] { "retired-sender" }, new object[] { "retired-payload" });
                Require(chat.chatClient == null && !chat.connectedToPhotonChat && !chat.connectingPhotonChat,
                    "A normal transition or stale callback created or advertised Photon Chat.");
                Require(history.Count == 0 && echoed == 0,
                    "Unavailable chat fabricated accepted history or a successful local echo.");
                Require(tab.errorLabel.gameObject.activeSelf &&
                    tab.errorLabel.text.Contains(Localization.Localize("ID_CHATCANNOTSENDMESSAGES")),
                    "The original chat UI did not report unavailable transport.");
            }
            finally
            {
                chat.newArrivedMessages -= arrived;
            }
            Debug.Log("PASS: original Chat Awake and transition/callback/send entry points create no Photon client, " +
                "report unavailable transport and fabricate no accepted messages; self-hosted chat remains unimplemented.");
        }
        finally
        {
            typeof(Chat).GetMethod("OnDisable", InstanceFields).Invoke(chat, null);
            VerifySubscriptionCount(chat, backend, login, 0);
            tab.chatPanel.gameObject.SetActive(wasPanelActive);
            for (int i = restore.Count - 1; i >= 0; i--)
            {
                restore[i]();
            }
        }
    }

    private static T FindSceneComponent<T>() where T : Component
    {
        return Resources.FindObjectsOfTypeAll<T>().Single(value => value.gameObject.scene.IsValid());
    }

    private static void VerifySubscriptionCount(
        Chat chat, BeanstalkServerManager backend, GameLoginManager login, int expected)
    {
        Require(CountSubscriptions(backend, "PlayerDataLoaded", chat) == expected &&
            CountSubscriptions(backend, "DataLoaded", chat) == expected &&
            CountSubscriptions(login, "PlayerJoinedSquad", chat) == expected &&
            CountSubscriptions(login, "PlayerLeftSquad", chat) == expected,
            "Chat enable/disable duplicated or leaked its local provider subscriptions.");
    }

    private static int CountSubscriptions(object owner, string name, Chat chat)
    {
        var handlers = owner.GetType().GetField(name, InstanceFields).GetValue(owner) as Delegate;
        return handlers == null ? 0 : handlers.GetInvocationList().Count(handler => ReferenceEquals(handler.Target, chat));
    }

    private static void PreserveStatic(Type type, string name, object replacement, List<Action> restore)
    {
        FieldInfo field = type.GetField(name, StaticFields);
        object previous = field.GetValue(null);
        restore.Add(() => field.SetValue(null, previous));
        field.SetValue(null, replacement);
    }

    private static void PreserveEvents(object owner, string[] names, List<Action> restore)
    {
        foreach (string name in names)
        {
            FieldInfo field = owner.GetType().GetField(name, InstanceFields);
            object previous = field.GetValue(owner);
            restore.Add(() => field.SetValue(owner, previous));
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
