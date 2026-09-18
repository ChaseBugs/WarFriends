using ExitGames.Client.Photon;

public static class CustomTypes
{
	private const int upgradesLength = 24;

	public static readonly byte[] weaponUpgrades = new byte[10];

	public static readonly byte[] memUpgrades = new byte[24];

	public static void Register()
	{
		PhotonPeer.RegisterType(typeof(UpgradeSlots.UnitUpgrades), 90, SerializeUpgrades, DeserializeUpgrades);
		PhotonPeer.RegisterType(typeof(PlayerInventory.EquippedWeapon), 88, SerializeEqippedWaepon, DeserializeEquippedWeapon);
	}

	private static object DeserializeEquippedWeapon(StreamBuffer inStream, short length)
	{
		PlayerInventory.EquippedWeapon equippedWeapon = new PlayerInventory.EquippedWeapon();
		lock (weaponUpgrades)
		{
			inStream.Read(weaponUpgrades, 0, 10);
			int offset = 0;
			Protocol.Deserialize(out equippedWeapon.weaponId, weaponUpgrades, ref offset);
			Protocol.Deserialize(out equippedWeapon.weaponUpgrade, weaponUpgrades, ref offset);
			Protocol.Deserialize(out short value, weaponUpgrades, ref offset);
			equippedWeapon.enabled = value > 0;
			return equippedWeapon;
		}
	}

	private static short SerializeEqippedWaepon(StreamBuffer outStream, object customobject)
	{
		PlayerInventory.EquippedWeapon equippedWeapon = (PlayerInventory.EquippedWeapon)customobject;
		lock (weaponUpgrades)
		{
			byte[] array = weaponUpgrades;
			int targetOffset = 0;
			short value = (short)(equippedWeapon.enabled ? 1 : 0);
			Protocol.Serialize(equippedWeapon.weaponId, array, ref targetOffset);
			Protocol.Serialize(equippedWeapon.weaponUpgrade, array, ref targetOffset);
			Protocol.Serialize(value, array, ref targetOffset);
			outStream.Write(array, 0, 10);
		}
		return 10;
	}

	private static short SerializeUpgrades(StreamBuffer outStream, object customobject)
	{
		UpgradeSlots.UnitUpgrades unitUpgrades = (UpgradeSlots.UnitUpgrades)customobject;
		lock (memUpgrades)
		{
			byte[] array = memUpgrades;
			int targetOffset = 0;
			short value = (short)(unitUpgrades.isSpecial ? 1 : 0);
			short value2 = (short)(unitUpgrades.isElite ? 1 : 0);
			Protocol.Serialize(unitUpgrades.slotUpgradeindex, array, ref targetOffset);
			Protocol.Serialize(unitUpgrades.slotUpgradeIndexSpecial, array, ref targetOffset);
			Protocol.Serialize(unitUpgrades.scaleHp, array, ref targetOffset);
			Protocol.Serialize(unitUpgrades.scaleDamage, array, ref targetOffset);
			Protocol.Serialize(unitUpgrades.slotUpgradeIndexElite, array, ref targetOffset);
			Protocol.Serialize(value, array, ref targetOffset);
			Protocol.Serialize(value2, array, ref targetOffset);
			outStream.Write(array, 0, 24);
		}
		return 24;
	}

	private static object DeserializeUpgrades(StreamBuffer inStream, short length)
	{
		UpgradeSlots.UnitUpgrades unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);
		lock (memUpgrades)
		{
			inStream.Read(memUpgrades, 0, 24);
			int offset = 0;
			Protocol.Deserialize(out unitUpgrades.slotUpgradeindex, memUpgrades, ref offset);
			Protocol.Deserialize(out unitUpgrades.slotUpgradeIndexSpecial, memUpgrades, ref offset);
			Protocol.Deserialize(out unitUpgrades.scaleHp, memUpgrades, ref offset);
			Protocol.Deserialize(out unitUpgrades.scaleDamage, memUpgrades, ref offset);
			Protocol.Deserialize(out unitUpgrades.slotUpgradeIndexElite, memUpgrades, ref offset);
			Protocol.Deserialize(out short value, memUpgrades, ref offset);
			Protocol.Deserialize(out short value2, memUpgrades, ref offset);
			unitUpgrades.isSpecial = value > 0;
			unitUpgrades.isElite = value2 > 0;
		}
		return unitUpgrades;
	}
}
