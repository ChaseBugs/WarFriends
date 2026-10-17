namespace War.Client
{
    /// <summary>Names the recovered local solo lifecycle callbacks without coupling them to Photon types.</summary>
    public enum LocalRoomCallback
    {
        ConnectedToMaster = 0,
        LeftRoom = 1,
        CreatedRoom = 2,
        JoinedRoom = 3,
        Disconnected = 4
    }
}
