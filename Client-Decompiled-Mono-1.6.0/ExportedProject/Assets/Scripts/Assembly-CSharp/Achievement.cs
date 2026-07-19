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
		Zero = 0,
		InvertedEvaluate = 1
	}

	public abstract NOLHKBIFMLB EOFAANLBNDA { get; }

	public virtual NHMEEMEJLOK HGOBPPGCPMI
	{
		get
		{
			return NHMEEMEJLOK.InvertedEvaluate;
		}
	}

	public virtual bool CDONJDOBFCM
	{
		get
		{
			return false;
		}
	}

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
		return string.Format("{0} [616577]/[-] {1}", MEJMLNDFDBP.GMIPFLIEOHD(JGBFNKBFCKM), MEJMLNDFDBP.GMIPFLIEOHD(NGPMJNJPNMB));
	}

	public virtual float DDPHGMIKKFP(float PAENPHMEMGC)
	{
		return PAENPHMEMGC;
	}
}
