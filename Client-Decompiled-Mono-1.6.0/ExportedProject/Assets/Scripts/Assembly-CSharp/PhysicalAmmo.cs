public abstract class PhysicalAmmo : Ammo
{
	public PhotonView LAADDLGBFIG;

	protected override void Awake()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
	}
}
