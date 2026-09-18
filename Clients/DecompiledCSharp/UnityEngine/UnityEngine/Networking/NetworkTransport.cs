using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Networking.Types;

namespace UnityEngine.Networking;

/// <summary>
///   <para>Low level (transport layer) API.</para>
/// </summary>
public sealed class NetworkTransport
{
	/// <summary>
	///   <para>Obsolete, will be removed.</para>
	/// </summary>
	public static extern bool IsStarted
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	private NetworkTransport()
	{
	}

	public static int ConnectEndPoint(int hostId, EndPoint xboxOneEndPoint, int exceptionConnectionId, out byte error)
	{
		error = 0;
		byte[] array = new byte[4] { 95, 36, 19, 246 };
		if (xboxOneEndPoint == null)
		{
			throw new NullReferenceException("Null EndPoint provided");
		}
		if (xboxOneEndPoint.GetType().FullName != "UnityEngine.XboxOne.XboxOneEndPoint")
		{
			throw new ArgumentException("Endpoint of type XboxOneEndPoint required");
		}
		if (xboxOneEndPoint.AddressFamily != AddressFamily.InterNetworkV6)
		{
			throw new ArgumentException("XboxOneEndPoint has an invalid family");
		}
		SocketAddress socketAddress = xboxOneEndPoint.Serialize();
		if (socketAddress.Size != 14)
		{
			throw new ArgumentException("XboxOneEndPoint has an invalid size");
		}
		if (socketAddress[0] != 0 || socketAddress[1] != 0)
		{
			throw new ArgumentException("XboxOneEndPoint has an invalid family signature");
		}
		if (socketAddress[2] != array[0] || socketAddress[3] != array[1] || socketAddress[4] != array[2] || socketAddress[5] != array[3])
		{
			throw new ArgumentException("XboxOneEndPoint has an invalid signature");
		}
		byte[] array2 = new byte[8];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = socketAddress[6 + i];
		}
		IntPtr intPtr = new IntPtr(BitConverter.ToInt64(array2, 0));
		if (intPtr == IntPtr.Zero)
		{
			throw new ArgumentException("XboxOneEndPoint has an invalid SOCKET_STORAGE pointer");
		}
		byte[] array3 = new byte[2];
		Marshal.Copy(intPtr, array3, 0, array3.Length);
		AddressFamily addressFamily = (AddressFamily)((array3[1] << 8) + array3[0]);
		if (addressFamily != AddressFamily.InterNetworkV6)
		{
			throw new ArgumentException("XboxOneEndPoint has corrupt or invalid SOCKET_STORAGE pointer");
		}
		return Internal_ConnectEndPoint(hostId, intPtr, 128, exceptionConnectionId, out error);
	}

	/// <summary>
	///   <para>First function which should be called before any other NetworkTransport function.</para>
	/// </summary>
	public static void Init()
	{
		InitWithNoParameters();
	}

	public static void Init(GlobalConfig config)
	{
		InitWithParameters(new GlobalConfigInternal(config));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void InitWithNoParameters();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void InitWithParameters(GlobalConfigInternal config);

	/// <summary>
	///   <para>Shutdown the transport layer, after calling this function no any other function can be called.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void Shutdown();

	/// <summary>
	///   <para>The UNet spawning system uses assetIds to identify how spawn remote objects. This function allows you to get the assetId for the prefab associated with an object.</para>
	/// </summary>
	/// <param name="go">Target game object to get asset Id for.</param>
	/// <returns>
	///   <para>The assetId of the game object's prefab.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern string GetAssetId(GameObject go);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void AddSceneId(int id);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetNextSceneId();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void ConnectAsNetworkHost(int hostId, string address, int port, NetworkID network, SourceID source, NodeID node, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void DisconnectNetworkHost(int hostId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern NetworkEventType ReceiveRelayEventFromHost(int hostId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int ConnectToNetworkPeer(int hostId, string address, int port, int exceptionConnectionId, int relaySlotId, NetworkID network, SourceID source, NodeID node, int bytesPerSec, float bucketSizeFactor, out byte error);

	public static int ConnectToNetworkPeer(int hostId, string address, int port, int exceptionConnectionId, int relaySlotId, NetworkID network, SourceID source, NodeID node, out byte error)
	{
		return ConnectToNetworkPeer(hostId, address, port, exceptionConnectionId, relaySlotId, network, source, node, 0, 0f, out error);
	}

	/// <summary>
	///   <para>Return value of messages waiting for reading.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetCurrentIncomingMessageAmount();

	/// <summary>
	///   <para>Return total message amount waiting for sending.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetCurrentOutgoingMessageAmount();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetCurrentRtt(int hostId, int connectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetNetworkLostPacketNum(int hostId, int connectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetPacketSentRate(int hostId, int connectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetPacketReceivedRate(int hostId, int connectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("GetRemotePacketReceivedRate has been made obsolete. Please do not use this function.")]
	[WrapperlessIcall]
	public static extern int GetRemotePacketReceivedRate(int hostId, int connectionId, out byte error);

	/// <summary>
	///   <para>Function returns time spent on network io operations in micro seconds.</para>
	/// </summary>
	/// <returns>
	///   <para>Time in micro seconds.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetNetIOTimeuS();

	public static void GetConnectionInfo(int hostId, int connectionId, out string address, out int port, out NetworkID network, out NodeID dstNode, out byte error)
	{
		address = GetConnectionInfo(hostId, connectionId, out port, out var network2, out var dstNode2, out error);
		network = (NetworkID)network2;
		dstNode = (NodeID)dstNode2;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern string GetConnectionInfo(int hostId, int connectionId, out int port, out ulong network, out ushort dstNode, out byte error);

	/// <summary>
	///   <para>Get UNET timestamp which can be added to message for further definitions of packet delaying.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetNetworkTimestamp();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetRemoteDelayTimeMS(int hostId, int connectionId, int remoteTime, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool StartSendMulticast(int hostId, int channelId, byte[] buffer, int size, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool SendMulticast(int hostId, int connectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool FinishSendMulticast(int hostId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int GetMaxPacketSize();

	private static void CheckTopology(HostTopology topology)
	{
		int maxPacketSize = GetMaxPacketSize();
		if (topology.DefaultConfig.PacketSize > maxPacketSize)
		{
			throw new ArgumentOutOfRangeException("Default config: packet size should be less than packet size defined in global config: " + maxPacketSize);
		}
		for (int i = 0; i < topology.SpecialConnectionConfigs.Count; i++)
		{
			if (topology.SpecialConnectionConfigs[i].PacketSize > maxPacketSize)
			{
				throw new ArgumentOutOfRangeException("Special config " + i + ": packet size should be less than packet size defined in global config: " + maxPacketSize);
			}
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int AddWsHostWrapper(HostTopologyInternal topologyInt, string ip, int port);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int AddWsHostWrapperWithoutIp(HostTopologyInternal topologyInt, int port);

	/// <summary>
	///   <para>Created web socket host. 
	/// This function is supported only for Editor (Win, Linux, Mac) and StandalonePlayers (Win, Linux, Mac) 
	/// Topology is used to define how many client can connect, and how many messages should be preallocated in send and receive pool, all other parameters are ignored.</para>
	/// </summary>
	/// <param name="port">Listening tcp port.</param>
	/// <param name="topology">Topology.</param>
	/// <returns>
	///   <para>Web socket host id.</para>
	/// </returns>
	[ExcludeFromDocs]
	public static int AddWebsocketHost(HostTopology topology, int port)
	{
		string ip = null;
		return AddWebsocketHost(topology, port, ip);
	}

	public static int AddWebsocketHost(HostTopology topology, int port, [DefaultValue("null")] string ip)
	{
		if (topology == null)
		{
			throw new NullReferenceException("topology is not defined");
		}
		if (ip == null)
		{
			return AddWsHostWrapperWithoutIp(new HostTopologyInternal(topology), port);
		}
		return AddWsHostWrapper(new HostTopologyInternal(topology), ip, port);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int AddHostWrapper(HostTopologyInternal topologyInt, string ip, int port, int minTimeout, int maxTimeout);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int AddHostWrapperWithoutIp(HostTopologyInternal topologyInt, int port, int minTimeout, int maxTimeout);

	[ExcludeFromDocs]
	public static int AddHost(HostTopology topology, int port)
	{
		string ip = null;
		return AddHost(topology, port, ip);
	}

	[ExcludeFromDocs]
	public static int AddHost(HostTopology topology)
	{
		string ip = null;
		int port = 0;
		return AddHost(topology, port, ip);
	}

	/// <summary>
	///   <para>Will create a host (open socket) with given topology and optionally port and IP.</para>
	/// </summary>
	/// <param name="topology">The host topology for this host.</param>
	/// <param name="port">Bind to specific port, if 0 is selected the port will chosen by OS.</param>
	/// <param name="ip">Bind to specific IP address.</param>
	/// <returns>
	///   <para>Returns host ID just created.</para>
	/// </returns>
	public static int AddHost(HostTopology topology, [DefaultValue("0")] int port, [DefaultValue("null")] string ip)
	{
		if (topology == null)
		{
			throw new NullReferenceException("topology is not defined");
		}
		if (ip == null)
		{
			return AddHostWrapperWithoutIp(new HostTopologyInternal(topology), port, 0, 0);
		}
		return AddHostWrapper(new HostTopologyInternal(topology), ip, port, 0, 0);
	}

	[ExcludeFromDocs]
	public static int AddHostWithSimulator(HostTopology topology, int minTimeout, int maxTimeout, int port)
	{
		string ip = null;
		return AddHostWithSimulator(topology, minTimeout, maxTimeout, port, ip);
	}

	[ExcludeFromDocs]
	public static int AddHostWithSimulator(HostTopology topology, int minTimeout, int maxTimeout)
	{
		string ip = null;
		int port = 0;
		return AddHostWithSimulator(topology, minTimeout, maxTimeout, port, ip);
	}

	/// <summary>
	///   <para>Create a host (open socket) and configure them to simulate internet latency (works on editor and development build only).</para>
	/// </summary>
	/// <param name="topology">The host topology for this host.</param>
	/// <param name="minTimeout">Minimum simulated delay.</param>
	/// <param name="maxTimeout">Maximum simulated delay.</param>
	/// <param name="port">Bind to specific port, if 0 is selected the port will chosen by OS.</param>
	/// <param name="ip">Bind to specific IP address.</param>
	/// <returns>
	///   <para>Returns host ID just created.</para>
	/// </returns>
	public static int AddHostWithSimulator(HostTopology topology, int minTimeout, int maxTimeout, [DefaultValue("0")] int port, [DefaultValue("null")] string ip)
	{
		if (topology == null)
		{
			throw new NullReferenceException("topology is not defined");
		}
		if (ip == null)
		{
			return AddHostWrapperWithoutIp(new HostTopologyInternal(topology), port, minTimeout, maxTimeout);
		}
		return AddHostWrapper(new HostTopologyInternal(topology), ip, port, minTimeout, maxTimeout);
	}

	/// <summary>
	///   <para>Close opened socket, close all connection belonging this socket.</para>
	/// </summary>
	/// <param name="hostId">If of opened udp socket.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool RemoveHost(int hostId);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int Connect(int hostId, string address, int port, int exeptionConnectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int Internal_ConnectEndPoint(int hostId, IntPtr sockAddrStorage, int sockAddrStorageLen, int exceptionConnectionId, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int ConnectWithSimulator(int hostId, string address, int port, int exeptionConnectionId, out byte error, ConnectionSimulatorConfig conf);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool Disconnect(int hostId, int connectionId, out byte error);

	public static bool Send(int hostId, int connectionId, int channelId, byte[] buffer, int size, out byte error)
	{
		if (buffer == null)
		{
			throw new NullReferenceException("send buffer is not initialized");
		}
		return SendWrapper(hostId, connectionId, channelId, buffer, size, out error);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool SendWrapper(int hostId, int connectionId, int channelId, byte[] buffer, int size, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern NetworkEventType Receive(out int hostId, out int connectionId, out int channelId, byte[] buffer, int bufferSize, out int receivedSize, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern NetworkEventType ReceiveFromHost(int hostId, out int connectionId, out int channelId, byte[] buffer, int bufferSize, out int receivedSize, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void SetPacketStat(int direction, int packetStatId, int numMsgs, int numBytes);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool StartBroadcastDiscovery(int hostId, int broadcastPort, int key, int version, int subversion, byte[] buffer, int size, int timeout, out byte error);

	/// <summary>
	///   <para>Stop sending broadcast discovery message.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void StopBroadcastDiscovery();

	/// <summary>
	///   <para>Check if broadcastdiscovery sender works.</para>
	/// </summary>
	/// <returns>
	///   <para>True if it works.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool IsBroadcastDiscoveryRunning();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void SetBroadcastCredentials(int hostId, int key, int version, int subversion, out byte error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern string GetBroadcastConnectionInfo(int hostId, out int port, out byte error);

	public static void GetBroadcastConnectionInfo(int hostId, out string address, out int port, out byte error)
	{
		address = GetBroadcastConnectionInfo(hostId, out port, out error);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void GetBroadcastConnectionMessage(int hostId, byte[] buffer, int bufferSize, out int receivedSize, out byte error);
}
