public struct PhotonMessageInfo
{
	private readonly int timeInt;

	public readonly PhotonPlayer sender;

	public readonly PhotonView photonView;

	public PhotonMessageInfo(PhotonPlayer player, int timestamp, PhotonView view)
	{
		timeInt = timestamp;
		sender = player;
		photonView = view;
	}

	public double timestamp
	{
		get
		{
			uint num = (uint)timeInt;
			double num2 = num;
			return num2 / 1000.0;
		}
	}

	public override string ToString()
	{
		return string.Format("[PhotonMessageInfo: Sender='{1}' Senttime={0}]", timestamp, sender);
	}
}
