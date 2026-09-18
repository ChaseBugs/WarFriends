using UnityEngine;

[ExecuteInEditMode]
public class PhotonLevelIDChanger : Core_BaseScript
{
	public PhotonView[] views;

	public bool assignIds;

	protected override void Awake()
	{
		base.Awake();
		int num = 850;
		if (!Application.isPlaying)
		{
			return;
		}
		PhotonView[] array = views;
		foreach (PhotonView photonView in array)
		{
			if (photonView != null)
			{
				photonView.viewID = num++;
			}
			else
			{
				Debug.LogError("Null photon view in PhotonLevelIDChanger");
			}
		}
	}
}
