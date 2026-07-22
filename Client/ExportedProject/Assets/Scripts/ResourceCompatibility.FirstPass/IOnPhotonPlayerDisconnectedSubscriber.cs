public interface IOnPhotonPlayerDisconnectedSubscriber : IPhotonEventSubscriber
{
	void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer);
}
