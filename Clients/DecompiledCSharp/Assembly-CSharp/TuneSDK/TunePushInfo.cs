using System.Collections.Generic;

namespace TuneSDK;

public class TunePushInfo
{
	public string campaignId;

	public string pushId;

	public Dictionary<string, string> extrasPayload;

	public TunePushInfo(string campaignId, string pushId, Dictionary<string, string> extrasPayload)
	{
		this.campaignId = campaignId;
		this.pushId = pushId;
		this.extrasPayload = extrasPayload;
	}
}
