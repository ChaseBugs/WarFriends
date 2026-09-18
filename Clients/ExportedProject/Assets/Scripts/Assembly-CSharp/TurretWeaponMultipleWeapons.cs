public class TurretWeaponMultipleWeapons : TurretWeaponBasic
{
	public BatchedWeapon[] secondaryBatchedWeapons;

	public float delay;

	public int fakeShotEvery;

	protected override void StartShooting()
	{
		Fire(batchedWeapon, mTarget, fakeShotEvery > 0);
		for (int i = 0; i < secondaryBatchedWeapons.Length; i++)
		{
			BatchedWeapon secondaryBatchedWeapon = secondaryBatchedWeapons[i];
			bool fake = fakeShotEvery > 0 && (i + 1) % fakeShotEvery == 0;
			InvokeAfter(delegate
			{
				Fire(secondaryBatchedWeapon, mTarget, fake);
			}, delay * (float)(i + 1));
		}
	}

	protected override void Awake()
	{
		base.Awake();
		BatchedWeapon[] array = secondaryBatchedWeapons;
		foreach (BatchedWeapon batchedWeapon in array)
		{
			batchedWeapon.weapon.owner = mOwner;
		}
	}

	public override void Reset()
	{
		base.Reset();
		BatchedWeapon[] array = secondaryBatchedWeapons;
		foreach (BatchedWeapon batchedWeapon in array)
		{
			batchedWeapon.Reset();
		}
	}
}
