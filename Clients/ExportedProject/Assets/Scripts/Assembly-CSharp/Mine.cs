public class Mine : PhysicalAmmoWeapon
{
	private IFraction mOwner;

	public override IFraction owner
	{
		get
		{
			return mOwner;
		}
		set
		{
			mOwner = value;
		}
	}
}
