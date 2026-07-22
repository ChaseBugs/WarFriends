public interface IOnCustomAuthenticationFailedSubscriber : IPhotonEventSubscriber
{
	void OnCustomAuthenticationFailed(string debugMessage);
}
