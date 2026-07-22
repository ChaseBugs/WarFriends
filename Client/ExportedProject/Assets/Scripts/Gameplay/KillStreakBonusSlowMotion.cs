using UnityEngine;

public class KillStreakBonusSlowMotion : KillStreakBonus
{
	public virtual bool AFBFEIPAEOG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.LMFPECEAOAE(1436f);
			return true;
		}
		return true;
	}

	public virtual bool AFNCLMOHLCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.HKIHILCILDO(1460f);
			return true;
		}
		return true;
	}

	public override bool LGJMNEKMDEO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.FDPIHKPDEEH(71f);
			return true;
		}
		return true;
	}

	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.SlowMotionFor(4f);
			return true;
		}
		return false;
	}

	public virtual bool DGFPNLHHDGI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.FJAJKEBLFOE(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.LMFPECEAOAE(808f);
			return false;
		}
		return true;
	}

	public virtual bool HDMPEMAGGFN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.JGMNMIOKJIP(1945f);
			return false;
		}
		return false;
	}

	public virtual bool MILOFINNGIP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.JGMNMIOKJIP(1875f);
			return false;
		}
		return true;
	}

	public virtual bool NFCPEKJEDCG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			Singleton<SlowMotionManager>.instance.HKIHILCILDO(1856f);
			return false;
		}
		return true;
	}
}
