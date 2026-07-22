public interface IOnPhotonJoinRoomFailedSubscriber : IPhotonEventSubscriber
{
	void OnPhotonJoinRoomFailed(object[] codeAndMsg);
}
