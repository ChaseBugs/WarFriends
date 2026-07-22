using System;

public abstract class Achievement
{
	[Flags]
	public enum NOLHKBIFMLB
	{
		None = 0,
		AfterGame = 1,
		AfterGameOnServerResponse = 2,
		AfterUnitUpgrade = 4,
		AfterWeaponUpgrade = 8,
		AfterUnitBought = 0x10,
		AfterWeaponBought = 0x20
	}

	public enum NHMEEMEJLOK
	{
		Zero,
		InvertedEvaluate
	}

	public abstract NOLHKBIFMLB EOFAANLBNDA { get; }

	public virtual NHMEEMEJLOK HGOBPPGCPMI => NHMEEMEJLOK.InvertedEvaluate;

	public virtual bool CDONJDOBFCM => false;

	public abstract int GOPJOOHKCNB();

	public int NGBBMKPCECD()
	{
		switch (HGOBPPGCPMI)
		{
		case NHMEEMEJLOK.Zero:
			return 0;
		case NHMEEMEJLOK.InvertedEvaluate:
			return -GOPJOOHKCNB();
		default:
			throw new ArgumentOutOfRangeException("offsetEvaluationType");
		}
	}

	public virtual string IJIFKCPIBFE(int MKIPAEDAADL)
	{
		return MEJMLNDFDBP.GMIPFLIEOHD(MKIPAEDAADL);
	}

	public virtual string DAHPGICCLID(int JGBFNKBFCKM, int NGPMJNJPNMB)
	{
		return $"{MEJMLNDFDBP.GMIPFLIEOHD(JGBFNKBFCKM)} [616577]/[-] {MEJMLNDFDBP.GMIPFLIEOHD(NGPMJNJPNMB)}";
	}

	public virtual float DDPHGMIKKFP(float PAENPHMEMGC)
	{
		return PAENPHMEMGC;
	}
}
