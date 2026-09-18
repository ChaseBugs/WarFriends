using System;
using System.Collections.Generic;
using UnityEngine.Networking.Types;

namespace UnityEngine.Networking.Match;

/// <summary>
///   <para>Class describing a client in a network match.</para>
/// </summary>
public class MatchDirectConnectInfo : ResponseBase
{
	/// <summary>
	///   <para>NodeID of the client described in this direct connect info.</para>
	/// </summary>
	public NodeID nodeId { get; set; }

	/// <summary>
	///   <para>Public address the client described by this class provided.</para>
	/// </summary>
	public string publicAddress { get; set; }

	/// <summary>
	///   <para>Private address the client described by this class provided.</para>
	/// </summary>
	public string privateAddress { get; set; }

	public override string ToString()
	{
		return UnityString.Format("[{0}]-nodeId:{1},publicAddress:{2},privateAddress:{3}", base.ToString(), nodeId, publicAddress, privateAddress);
	}

	public override void Parse(object obj)
	{
		if (obj is IDictionary<string, object> dictJsonObj)
		{
			nodeId = (NodeID)ParseJSONUInt16("nodeId", obj, dictJsonObj);
			publicAddress = ParseJSONString("publicAddress", obj, dictJsonObj);
			privateAddress = ParseJSONString("privateAddress", obj, dictJsonObj);
			return;
		}
		throw new FormatException("While parsing JSON response, found obj is not of type IDictionary<string,object>:" + obj.ToString());
	}
}
