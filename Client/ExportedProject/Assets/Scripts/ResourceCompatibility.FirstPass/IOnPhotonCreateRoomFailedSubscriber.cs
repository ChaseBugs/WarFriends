public interface IOnPhotonCreateRoomFailedSubscriber : IPhotonEventSubscriber
{
	void OnPhotonCreateRoomFailed(object[] codeAndMsg);
}
