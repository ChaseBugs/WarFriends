using GooglePlayGames.OurUtils;

namespace GooglePlayGames.BasicApi.Nearby
{
public struct AdvertisingResult
{
	private readonly ResponseStatus mStatus;

	private readonly string mLocalEndpointName;

	public AdvertisingResult(ResponseStatus status, string localEndpointName)
	{
		mStatus = status;
		mLocalEndpointName = Misc.CheckNotNull(localEndpointName);
	}

	public bool Succeeded => mStatus == ResponseStatus.Success;

	public ResponseStatus Status => mStatus;

	public string LocalEndpointName => mLocalEndpointName;
}
}
