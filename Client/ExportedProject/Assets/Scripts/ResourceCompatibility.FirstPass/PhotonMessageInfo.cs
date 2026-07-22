public struct PhotonMessageInfo
{
	private readonly int timeInt;

	public readonly PhotonPlayer sender;

	public readonly PhotonView photonView;

	public double timestamp => 0.0;

	public PhotonMessageInfo(PhotonPlayer player, int timestamp, PhotonView view)
	{
		timeInt = 0;
		sender = null;
		photonView = null;
	}

	public override string ToString()
	{
		return null;
	}
}
