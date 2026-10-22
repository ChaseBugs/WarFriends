using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Google.Protobuf;
using UnityEditor;
using War.Client;
using War.Protocol;

/// <summary>Checks retained local compatibility and retired network entry points in the real Editor.</summary>
public static class UnityOfflineTransportAudit
{
    public static void Run()
    {
        Require(!PhotonNetwork.ConnectUsingSettings("audit"), "Settings connection opened.");
        Require(!PhotonNetwork.ConnectToMaster("127.0.0.1", 5055, "audit", "audit"), "Master connection opened.");
        Require(!PhotonNetwork.ConnectToBestCloudServer("audit"), "Region selection opened.");
        Require(!PhotonNetwork.ConnectToRegion(CloudRegionCode.eu, "audit"), "Region connection opened.");
        Require(!PhotonNetwork.ConnectToNameServer("audit"), "Name server connection opened.");
        Require(!PhotonNetwork.Reconnect() && !PhotonNetwork.ReconnectAndRejoin(), "Reconnect opened.");
        Require(!PhotonNetwork.networkingPeer.ConnectToNameServer(), "Peer bypass opened.");
        Require(!PhotonNetwork.networkingPeer.ConnectToRegionMaster(CloudRegionCode.eu), "Peer region bypass opened.");
        Require(!PhotonNetwork.networkingPeer.Connect("127.0.0.1:5055", ServerConnection.MasterServer),
            "Peer master bypass opened.");
        Type handler = typeof(PhotonNetwork).Assembly.GetType("PhotonHandler", true);
        handler.GetMethod("StartFallbackSendAckThread", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
        Require(!(bool)handler.GetMethod("FallbackSendAckThread", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, null), "Retired ACK sender is running.");

        PhotonNetwork.offlineMode = true;
        Require(PhotonNetwork.CreateRoom("OfflineRoom"), "Local compatibility room no longer starts.");
        Require(PhotonNetwork.room != null && PhotonNetwork.playerList.Length == 1,
            "Local compatibility roster changed.");
        PhotonNetwork.Disconnect();

        byte[] request = BackendActionCodec.Encode(new Dictionary<string, string> { { "requestId", "157" } });
        Require(ClientActionRequest.Parser.ParseFrom(request).Fields[0].Value == "157", "Action protobuf changed.");
        var reply = new ClientActionReply
        {
            FormatVersion = 1, ContentType = "text/plain", Payload = ByteString.CopyFromUtf8("success;0;{}")
        };
        Require(BackendActionCodec.Decode(reply.ToByteArray()) == "success;0;{}", "Callback payload changed.");
        UnityBestHttpBackendAudit.Run();
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_OFFLINE_TRANSPORT_REPORT"),
            "{\"passed\":true,\"bestHttpBackendVerified\":true,\"normalGameplayVerified\":false,\"photonAssemblyRemoved\":false}\n");
        EditorApplication.Exit(0);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
