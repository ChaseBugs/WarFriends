public interface IOnPhotonSerializeViewSubscriber : IPhotonEventSubscriber
{
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info);
}
