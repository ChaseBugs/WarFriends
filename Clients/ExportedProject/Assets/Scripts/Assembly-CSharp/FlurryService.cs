using System.Collections.Generic;
using Prime31;

public class FlurryService
{
	public string iosKey = "M4B23N48RZF8CKPJ2QBR";

	public string androidKey = "Y7R5XKWF2WY9DWGG7DVW";

	public void Init()
	{
		FlurryAnalytics.startSession(androidKey);
	}

	public void RegisterEvent(string eventName, string parameterName, string parameterValue)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add(parameterName, parameterValue);
		Dictionary<string, string> parameters = dictionary;
		FlurryAnalytics.logEvent(eventName, parameters, isTimed: false);
	}
}
