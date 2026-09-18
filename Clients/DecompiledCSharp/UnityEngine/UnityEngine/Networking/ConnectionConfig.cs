using System;
using System.Collections.Generic;

namespace UnityEngine.Networking;

/// <summary>
///   <para>This class defines parameters of connection between two peers, this definition includes various timeouts and sizes as well as channel configuration.</para>
/// </summary>
[Serializable]
public class ConnectionConfig
{
	private const int g_MinPacketSize = 128;

	[SerializeField]
	private ushort m_PacketSize;

	[SerializeField]
	private ushort m_FragmentSize;

	[SerializeField]
	private uint m_ResendTimeout;

	[SerializeField]
	private uint m_DisconnectTimeout;

	[SerializeField]
	private uint m_ConnectTimeout;

	[SerializeField]
	private uint m_MinUpdateTimeout;

	[SerializeField]
	private uint m_PingTimeout;

	[SerializeField]
	private uint m_ReducedPingTimeout;

	[SerializeField]
	private uint m_AllCostTimeout;

	[SerializeField]
	private byte m_NetworkDropThreshold;

	[SerializeField]
	private byte m_OverflowDropThreshold;

	[SerializeField]
	private byte m_MaxConnectionAttempt;

	[SerializeField]
	private uint m_AckDelay;

	[SerializeField]
	private ushort m_MaxCombinedReliableMessageSize;

	[SerializeField]
	private ushort m_MaxCombinedReliableMessageCount;

	[SerializeField]
	private ushort m_MaxSentMessageQueueSize;

	[SerializeField]
	private bool m_IsAcksLong;

	[SerializeField]
	internal List<ChannelQOS> m_Channels = new List<ChannelQOS>();

	/// <summary>
	///   <para>What is a maximum packet size (in Bytes) (including payload and all header). Packet can contain multiple messages inside.</para>
	/// </summary>
	public ushort PacketSize
	{
		get
		{
			return m_PacketSize;
		}
		set
		{
			m_PacketSize = value;
		}
	}

	/// <summary>
	///   <para>What should be maximum fragment size (in Bytes) for fragmented messages.</para>
	/// </summary>
	public ushort FragmentSize
	{
		get
		{
			return m_FragmentSize;
		}
		set
		{
			m_FragmentSize = value;
		}
	}

	/// <summary>
	///   <para>Minimum timeout (in ms) which library will wait before it will resend reliable message.</para>
	/// </summary>
	public uint ResendTimeout
	{
		get
		{
			return m_ResendTimeout;
		}
		set
		{
			m_ResendTimeout = value;
		}
	}

	/// <summary>
	///   <para>How long (in ms) library will wait before it will consider connection as disconnected.</para>
	/// </summary>
	public uint DisconnectTimeout
	{
		get
		{
			return m_DisconnectTimeout;
		}
		set
		{
			m_DisconnectTimeout = value;
		}
	}

	/// <summary>
	///   <para>Timeout in ms which library will wait before it will send another connection request.</para>
	/// </summary>
	public uint ConnectTimeout
	{
		get
		{
			return m_ConnectTimeout;
		}
		set
		{
			m_ConnectTimeout = value;
		}
	}

	/// <summary>
	///   <para>Minimal send update timeout (in ms) for connection. this timeout could be increased by library if flow control will required.</para>
	/// </summary>
	public uint MinUpdateTimeout
	{
		get
		{
			return m_MinUpdateTimeout;
		}
		set
		{
			if (value == 0)
			{
				throw new ArgumentOutOfRangeException("Minimal update timeout should be > 0");
			}
			m_MinUpdateTimeout = value;
		}
	}

	/// <summary>
	///   <para>Timeout in ms between control protocol messages.</para>
	/// </summary>
	public uint PingTimeout
	{
		get
		{
			return m_PingTimeout;
		}
		set
		{
			m_PingTimeout = value;
		}
	}

	/// <summary>
	///   <para>Timeout in ms for control messages which library will use before it will accumulate statistics.</para>
	/// </summary>
	public uint ReducedPingTimeout
	{
		get
		{
			return m_ReducedPingTimeout;
		}
		set
		{
			m_ReducedPingTimeout = value;
		}
	}

	/// <summary>
	///   <para>Defines timeout in ms after that message with AllCost deliver qos will force resend without acknowledgement waiting.</para>
	/// </summary>
	public uint AllCostTimeout
	{
		get
		{
			return m_AllCostTimeout;
		}
		set
		{
			m_AllCostTimeout = value;
		}
	}

	/// <summary>
	///   <para>How many (in %) packet need to be dropped due network condition before library will throttle send rate.</para>
	/// </summary>
	public byte NetworkDropThreshold
	{
		get
		{
			return m_NetworkDropThreshold;
		}
		set
		{
			m_NetworkDropThreshold = value;
		}
	}

	/// <summary>
	///   <para>How many (in %) packet need to be dropped due lack of internal bufferes before library will throttle send rate.</para>
	/// </summary>
	public byte OverflowDropThreshold
	{
		get
		{
			return m_OverflowDropThreshold;
		}
		set
		{
			m_OverflowDropThreshold = value;
		}
	}

	/// <summary>
	///   <para>How many attempt library will get before it will consider the connection as disconnected.</para>
	/// </summary>
	public byte MaxConnectionAttempt
	{
		get
		{
			return m_MaxConnectionAttempt;
		}
		set
		{
			m_MaxConnectionAttempt = value;
		}
	}

	/// <summary>
	///   <para>How long in ms receiver will wait before it will force send acknowledgements back without waiting any payload.</para>
	/// </summary>
	public uint AckDelay
	{
		get
		{
			return m_AckDelay;
		}
		set
		{
			m_AckDelay = value;
		}
	}

	/// <summary>
	///   <para>Maximum size of reliable message which library will consider as small and will try to combine in one "array of messages" message.</para>
	/// </summary>
	public ushort MaxCombinedReliableMessageSize
	{
		get
		{
			return m_MaxCombinedReliableMessageSize;
		}
		set
		{
			m_MaxCombinedReliableMessageSize = value;
		}
	}

	/// <summary>
	///   <para>Maximum amount of small reliable messages which will combine in one "array of messages". Useful if you are going to send a lot of small reliable messages.</para>
	/// </summary>
	public ushort MaxCombinedReliableMessageCount
	{
		get
		{
			return m_MaxCombinedReliableMessageCount;
		}
		set
		{
			m_MaxCombinedReliableMessageCount = value;
		}
	}

	/// <summary>
	///   <para>Defines maximum messages which will wait for sending before user will receive error on Send() call.</para>
	/// </summary>
	public ushort MaxSentMessageQueueSize
	{
		get
		{
			return m_MaxSentMessageQueueSize;
		}
		set
		{
			m_MaxSentMessageQueueSize = value;
		}
	}

	/// <summary>
	///   <para>If it is true, connection will use 64 bit mask to acknowledge received reliable messages.</para>
	/// </summary>
	public bool IsAcksLong
	{
		get
		{
			return m_IsAcksLong;
		}
		set
		{
			m_IsAcksLong = value;
		}
	}

	/// <summary>
	///   <para>Return amount of channels for current configuration.</para>
	/// </summary>
	public int ChannelCount => m_Channels.Count;

	/// <summary>
	///   <para>Allow access to channels list.</para>
	/// </summary>
	public List<ChannelQOS> Channels => m_Channels;

	/// <summary>
	///   <para>Will create default connection config or will copy them from another.</para>
	/// </summary>
	/// <param name="config">Connection config.</param>
	public ConnectionConfig()
	{
		m_PacketSize = 1500;
		m_FragmentSize = 500;
		m_ResendTimeout = 1200u;
		m_DisconnectTimeout = 2000u;
		m_ConnectTimeout = 2000u;
		m_MinUpdateTimeout = 10u;
		m_PingTimeout = 500u;
		m_ReducedPingTimeout = 100u;
		m_AllCostTimeout = 20u;
		m_NetworkDropThreshold = 5;
		m_OverflowDropThreshold = 5;
		m_MaxConnectionAttempt = 10;
		m_AckDelay = 33u;
		m_MaxCombinedReliableMessageSize = 100;
		m_MaxCombinedReliableMessageCount = 10;
		m_MaxSentMessageQueueSize = 128;
		m_IsAcksLong = false;
	}

	/// <summary>
	///   <para>Will create default connection config or will copy them from another.</para>
	/// </summary>
	/// <param name="config">Connection config.</param>
	public ConnectionConfig(ConnectionConfig config)
	{
		if (config == null)
		{
			throw new NullReferenceException("config is not defined");
		}
		m_PacketSize = config.m_PacketSize;
		m_FragmentSize = config.m_FragmentSize;
		m_ResendTimeout = config.m_ResendTimeout;
		m_DisconnectTimeout = config.m_DisconnectTimeout;
		m_ConnectTimeout = config.m_ConnectTimeout;
		m_MinUpdateTimeout = config.m_MinUpdateTimeout;
		m_PingTimeout = config.m_PingTimeout;
		m_ReducedPingTimeout = config.m_ReducedPingTimeout;
		m_AllCostTimeout = config.m_AllCostTimeout;
		m_NetworkDropThreshold = config.m_NetworkDropThreshold;
		m_OverflowDropThreshold = config.m_OverflowDropThreshold;
		m_MaxConnectionAttempt = config.m_MaxConnectionAttempt;
		m_AckDelay = config.m_AckDelay;
		m_MaxCombinedReliableMessageSize = config.MaxCombinedReliableMessageSize;
		m_MaxCombinedReliableMessageCount = config.m_MaxCombinedReliableMessageCount;
		m_MaxSentMessageQueueSize = config.m_MaxSentMessageQueueSize;
		m_IsAcksLong = config.m_IsAcksLong;
		foreach (ChannelQOS channel in config.m_Channels)
		{
			m_Channels.Add(new ChannelQOS(channel));
		}
	}

	/// <summary>
	///   <para>Validate parameters of connection config. Will throw exceptions if parameters are incorrect.</para>
	/// </summary>
	/// <param name="config"></param>
	public static void Validate(ConnectionConfig config)
	{
		if (config.m_PacketSize < 128)
		{
			throw new ArgumentOutOfRangeException("PacketSize should be > " + 128);
		}
		if (config.m_FragmentSize >= config.m_PacketSize - 128)
		{
			throw new ArgumentOutOfRangeException("FragmentSize should be < PacketSize - " + 128);
		}
		if (config.m_Channels.Count > 255)
		{
			throw new ArgumentOutOfRangeException("Channels number should be less than 256");
		}
	}

	/// <summary>
	///   <para></para>
	/// </summary>
	/// <param name="value">Add new channel to configuration.</param>
	/// <returns>
	///   <para>Channel id, user can use this id to send message via this channel.</para>
	/// </returns>
	public byte AddChannel(QosType value)
	{
		if (m_Channels.Count > 255)
		{
			throw new ArgumentOutOfRangeException("Channels Count should be less than 256");
		}
		if (!Enum.IsDefined(typeof(QosType), value))
		{
			throw new ArgumentOutOfRangeException("requested qos type doesn't exist: " + (int)value);
		}
		ChannelQOS item = new ChannelQOS(value);
		m_Channels.Add(item);
		return (byte)(m_Channels.Count - 1);
	}

	/// <summary>
	///   <para>Return the QoS set for the given channel or throw an out of range exception.</para>
	/// </summary>
	/// <param name="idx">Index in array.</param>
	/// <returns>
	///   <para>Channel QoS.</para>
	/// </returns>
	public QosType GetChannel(byte idx)
	{
		if (idx >= m_Channels.Count)
		{
			throw new ArgumentOutOfRangeException("requested index greater than maximum channels count");
		}
		return m_Channels[idx].QOS;
	}
}
