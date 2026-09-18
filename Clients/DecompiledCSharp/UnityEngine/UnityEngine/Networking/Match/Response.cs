using System;
using System.Collections.Generic;

namespace UnityEngine.Networking.Match;

/// <summary>
///   <para>Abstract class that contains shared accessors for any response.</para>
/// </summary>
public abstract class Response : ResponseBase, IResponse
{
	/// <summary>
	///   <para>Bool describing if the request was successful.</para>
	/// </summary>
	public bool success { get; private set; }

	/// <summary>
	///   <para>Extended string information that is returned when the server encounters an error processing a request.</para>
	/// </summary>
	public string extendedInfo { get; private set; }

	public void SetSuccess()
	{
		success = true;
		extendedInfo = string.Empty;
	}

	public void SetFailure(string info)
	{
		success = false;
		extendedInfo = info;
	}

	/// <summary>
	///   <para>Provides string description of current class data.</para>
	/// </summary>
	public override string ToString()
	{
		return UnityString.Format("[{0}]-success:{1}-extendedInfo:{2}", base.ToString(), success, extendedInfo);
	}

	public override void Parse(object obj)
	{
		if (obj is IDictionary<string, object> dictJsonObj)
		{
			success = ParseJSONBool("success", obj, dictJsonObj);
			extendedInfo = ParseJSONString("extendedInfo", obj, dictJsonObj);
			if (!success)
			{
				throw new FormatException("FAILURE Returned from server: " + extendedInfo);
			}
		}
	}
}
