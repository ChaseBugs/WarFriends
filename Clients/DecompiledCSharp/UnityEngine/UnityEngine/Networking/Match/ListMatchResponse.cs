using System;
using System.Collections.Generic;

namespace UnityEngine.Networking.Match;

/// <summary>
///   <para>JSON response for a ListMatchRequest. It contains a list of matches that can be parsed through to describe a page of matches.</para>
/// </summary>
public class ListMatchResponse : BasicResponse
{
	/// <summary>
	///   <para>List of matches fitting the requested description.</para>
	/// </summary>
	public List<MatchDesc> matches { get; set; }

	/// <summary>
	///   <para>Constructor for response class.</para>
	/// </summary>
	/// <param name="matches">A list of matches to give to the object. Only used when generating a new response and not used by callers of a ListMatchRequest.</param>
	/// <param name="otherMatches"></param>
	public ListMatchResponse()
	{
	}

	public ListMatchResponse(List<MatchDesc> otherMatches)
	{
		matches = otherMatches;
	}

	/// <summary>
	///   <para>Provides string description of current class data.</para>
	/// </summary>
	public override string ToString()
	{
		return UnityString.Format("[{0}]-matches.Count:{1}", base.ToString(), matches.Count);
	}

	public override void Parse(object obj)
	{
		base.Parse(obj);
		if (obj is IDictionary<string, object> dictJsonObj)
		{
			matches = ParseJSONList<MatchDesc>("matches", obj, dictJsonObj);
			return;
		}
		throw new FormatException("While parsing JSON response, found obj is not of type IDictionary<string,object>:" + obj.ToString());
	}
}
