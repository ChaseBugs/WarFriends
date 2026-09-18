using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
public class StarterAssignmentUpgradeWeapon : StarterAssignment
{
	protected override int numberId => 7;

	public override string textProgress => $"({Mathf.Min(mAssigmentsRow.VALUE, PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup.weaponLevel)}\u00a0/\u00a0{mAssigmentsRow.VALUE})";

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
