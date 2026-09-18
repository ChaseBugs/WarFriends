public interface ICardManager
{
	PlayerWeapon grenadeSaved { get; set; }

	PlayerWeapon savedWeapon { get; set; }

	float timeLockWeaponSwitch { get; set; }

	void CardWasUsed(Card card, Fractions fraction);
}
