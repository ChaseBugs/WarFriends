using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;

public static class LOFGBPBFLPG
{
	private const int BGLNMGMFFBI = 14;

	public static readonly byte[] IKDDHGOEOBF = new byte[14];

	private const int PGALHMCIJCD = 24;

	public static readonly byte[] BJIKLIEMBOJ = new byte[24];

	[CompilerGenerated]
	private static SerializeStreamMethod IONHPHFCBGH;

	[CompilerGenerated]
	private static DeserializeStreamMethod KBGCLEMGDHO;

	[CompilerGenerated]
	private static SerializeStreamMethod JNFIADMBDDB;

	[CompilerGenerated]
	private static DeserializeStreamMethod JFOKBOPKMOP;

	public static void NOMIPLDDPJE()
	{
		PhotonPeer.RegisterType(typeof(UpgradeSlots.UnitUpgrades), 90, IHEEAKJHJID, OCDDHGGHCFM);
		PhotonPeer.RegisterType(typeof(PlayerInventory.JIMOKIIJHNA), 88, MNNPGMJJHCO, OICHLHHGAOK);
	}

	private static object OICHLHHGAOK(StreamBuffer OFMCDEGFIGM, short IOIPJCICLFH)
	{
		PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = new PlayerInventory.JIMOKIIJHNA();
		lock (IKDDHGOEOBF)
		{
			OFMCDEGFIGM.Read(IKDDHGOEOBF, 0, 14);
			int offset = 0;
			Protocol.Deserialize(out jIMOKIIJHNA.EPNKPKHCKNG, IKDDHGOEOBF, ref offset);
			Protocol.Deserialize(out jIMOKIIJHNA.DGPAEJJENDP, IKDDHGOEOBF, ref offset);
			Protocol.Deserialize(out jIMOKIIJHNA.FIPONKNHIAL, IKDDHGOEOBF, ref offset);
			Protocol.Deserialize(out short value, IKDDHGOEOBF, ref offset);
			jIMOKIIJHNA.GJNGLPOBFJI = value > 0;
			return jIMOKIIJHNA;
		}
	}

	private static short MNNPGMJJHCO(StreamBuffer LOMKJHNMPLK, object LCMPELPOOHN)
	{
		PlayerInventory.JIMOKIIJHNA jIMOKIIJHNA = (PlayerInventory.JIMOKIIJHNA)LCMPELPOOHN;
		lock (IKDDHGOEOBF)
		{
			byte[] iKDDHGOEOBF = IKDDHGOEOBF;
			int targetOffset = 0;
			short value = (short)(jIMOKIIJHNA.GJNGLPOBFJI ? 1 : 0);
			Protocol.Serialize(jIMOKIIJHNA.EPNKPKHCKNG, iKDDHGOEOBF, ref targetOffset);
			Protocol.Serialize(jIMOKIIJHNA.DGPAEJJENDP, iKDDHGOEOBF, ref targetOffset);
			Protocol.Serialize(jIMOKIIJHNA.FIPONKNHIAL, iKDDHGOEOBF, ref targetOffset);
			Protocol.Serialize(value, iKDDHGOEOBF, ref targetOffset);
			LOMKJHNMPLK.Write(iKDDHGOEOBF, 0, 14);
		}
		return 14;
	}

	private static short IHEEAKJHJID(StreamBuffer LOMKJHNMPLK, object LCMPELPOOHN)
	{
		UpgradeSlots.UnitUpgrades unitUpgrades = (UpgradeSlots.UnitUpgrades)LCMPELPOOHN;
		lock (BJIKLIEMBOJ)
		{
			byte[] bJIKLIEMBOJ = BJIKLIEMBOJ;
			int targetOffset = 0;
			short value = (short)(unitUpgrades.isSpecial ? 1 : 0);
			short value2 = (short)(unitUpgrades.isElite ? 1 : 0);
			Protocol.Serialize(unitUpgrades.slotUpgradeindex, bJIKLIEMBOJ, ref targetOffset);
			Protocol.Serialize(unitUpgrades.slotUpgradeIndexSpecial, bJIKLIEMBOJ, ref targetOffset);
			Protocol.Serialize(unitUpgrades.scaleHp, bJIKLIEMBOJ, ref targetOffset);
			Protocol.Serialize(unitUpgrades.scaleDamage, bJIKLIEMBOJ, ref targetOffset);
			Protocol.Serialize(unitUpgrades.slotUpgradeIndexElite, bJIKLIEMBOJ, ref targetOffset);
			Protocol.Serialize(value, bJIKLIEMBOJ, ref targetOffset);
			Protocol.Serialize(value2, bJIKLIEMBOJ, ref targetOffset);
			LOMKJHNMPLK.Write(bJIKLIEMBOJ, 0, 24);
		}
		return 24;
	}

	private static object OCDDHGGHCFM(StreamBuffer OFMCDEGFIGM, short IOIPJCICLFH)
	{
		UpgradeSlots.UnitUpgrades unitUpgrades = new UpgradeSlots.UnitUpgrades(1f);
		lock (BJIKLIEMBOJ)
		{
			OFMCDEGFIGM.Read(BJIKLIEMBOJ, 0, 24);
			int offset = 0;
			Protocol.Deserialize(out unitUpgrades.slotUpgradeindex, BJIKLIEMBOJ, ref offset);
			Protocol.Deserialize(out unitUpgrades.slotUpgradeIndexSpecial, BJIKLIEMBOJ, ref offset);
			Protocol.Deserialize(out unitUpgrades.scaleHp, BJIKLIEMBOJ, ref offset);
			Protocol.Deserialize(out unitUpgrades.scaleDamage, BJIKLIEMBOJ, ref offset);
			Protocol.Deserialize(out unitUpgrades.slotUpgradeIndexElite, BJIKLIEMBOJ, ref offset);
			Protocol.Deserialize(out short value, BJIKLIEMBOJ, ref offset);
			Protocol.Deserialize(out short value2, BJIKLIEMBOJ, ref offset);
			unitUpgrades.isSpecial = value > 0;
			unitUpgrades.isElite = value2 > 0;
		}
		return unitUpgrades;
	}
}
