public interface IOnConnectionFailSubscriber : IPhotonEventSubscriber
{
	void OnConnectionFail(DisconnectCause cause);
}
