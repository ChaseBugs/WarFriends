using System;
using System.Collections.Generic;
using UnityEngine.Networking.Types;

namespace UnityEngine.Networking.Match;

/// <summary>
///   <para>JSON response for a JoinMatchRequest. It contains all information necessdary to continue joining a match.</para>
/// </summary>
public class JoinMatchResponse : BasicResponse
{
	/// <summary>
	///   <para>Network address to connect to in order to join the match.</para>
	/// </summary>
	public string address { get; set; }

	/// <summary>
	///   <para>Network port to connect to in order to join the match.</para>
	/// </summary>
	public int port { get; set; }

	/// <summary>
	///   <para>NetworkID of the match.</para>
	/// </summary>
	public NetworkID networkId { get; set; }

	/// <summary>
	///   <para>JSON encoding for the binary access token this client uses to authenticate its session for future commands.</para>
	/// </summary>
	public string accessTokenString { get; set; }

	/// <summary>
	///   <para>NodeID for the requesting client in the mach that it is joining.</para>
	/// </summary>
	public NodeID nodeId { get; set; }

	/// <summary>
	///   <para>If the match is hosted by a relay server.</para>
	/// </summary>
	public bool usingRelay { get; set; }

	/// <summary>
	///   <para>Constructor for response class.</para>
	/// </summary>
	public JoinMatchResponse()
	{
	}

	/// <summary>
	///   <para>Provides string description of current class data.</para>
	/// </summary>
	public override string ToString()
	{
		return UnityString.Format("[{0}]-address:{1},port:{2},networkId:0x{3},nodeId:0x{4},usingRelay:{5}", base.ToString(), address, port, networkId.ToString("X"), nodeId.ToString("X"), usingRelay);
	}

	public override void Parse(object obj)
	{
		base.Parse(obj);
		if (obj is IDictionary<string, object> dictJsonObj)
		{
			address = ParseJSONString("address", obj, dictJsonObj);
			port = ParseJSONInt32("port", obj, dictJsonObj);
			networkId = (NetworkID)ParseJSONUInt64("networkId", obj, dictJsonObj);
			accessTokenString = ParseJSONString("accessTokenString", obj, dictJsonObj);
			nodeId = (NodeID)ParseJSONUInt16("nodeId", obj, dictJsonObj);
			usingRelay = ParseJSONBool("usingRelay", obj, dictJsonObj);
			return;
		}
		throw new FormatException("While parsing JSON response, found obj is not of type IDictionary<string,object>:" + obj.ToString());
	}
}
