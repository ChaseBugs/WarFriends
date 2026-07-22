using UnityEngine;

public class PhysicalAmmoWeapon : Weapon
{
	public Vector3 PJGDKJDFEDF;

	protected PhysicalAmmo HMLIANFMHPF;

	public override bool willShoot => false;

	public override float nextShootProgress => 0f;

	protected override Ammo KLLJKOEGIIG(Vector3 MPHCJEIMBEB, bool KMKNPEHKLMI)
	{
		return null;
	}

	public bool BaseShoot(Vector3 OIMMJIGPNDK, bool KMKNPEHKLMI)
	{
		return false;
	}

	[PunRPC]
	public virtual void ShootCopyRPC(int EPNGMAHENPA, Vector3 EMMCJEEABGA, Vector3 FFJGKOLGFLL, byte MIFHPHNIMPF, bool JGLBNNDGLIO)
	{
	}

	[PunRPC]
	public override void FireNetworkRPC(Vector3 FFJGKOLGFLL, bool MFLHJEBNBNE, byte JFACCKJNHHC)
	{
	}

	protected override void ECLHPEOCOMP(Vector3 FFJGKOLGFLL)
	{
	}
}
