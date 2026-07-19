using UnityEngine;

public class StarterAssignmentUpgradeWeapon : StarterAssignment
{
	protected override int numberId
	{
		get
		{
			return 7;
		}
	}

	public override string textProgress
	{
		get
		{
			return string.Format("({0}\u00a0/\u00a0{1})", Mathf.Min(mAssigmentsRow.VALUE, PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup.weaponLevel), mAssigmentsRow.VALUE);
		}
	}

	public override bool Evaluate()
	{
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup;
		if (!base.completed && weaponLevelsSetup.weaponLevel >= mAssigmentsRow.VALUE)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
