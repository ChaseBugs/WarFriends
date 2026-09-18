public abstract class PhysicalAmmo : Ammo
{
	public PhotonView photonView;

	protected override void Awake()
	{
		base.Awake();
		photonView = GetComponent<PhotonView>();
	}
}
