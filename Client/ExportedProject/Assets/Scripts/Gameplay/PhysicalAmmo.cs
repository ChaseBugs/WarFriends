using UnityEngine.Serialization;

public abstract class PhysicalAmmo : Ammo
{
	[FormerlySerializedAs("LOAGAOKNAPI")]
	public PhotonView LAADDLGBFIG;

	protected override void Awake()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
	}
}
