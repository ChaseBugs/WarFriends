using ExitGames.Client.Photon;

public interface IOnPhotonCustomRoomPropertiesChangedSubscriber : IPhotonEventSubscriber
{
	void OnPhotonCustomRoomPropertiesChanged(Hashtable propertiesThatChanged);
}
