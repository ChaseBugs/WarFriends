using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class KillStreakBonus : Core_BaseScript
{
	public static List<KillStreakBonus> EEPKLMJMJAI = new List<KillStreakBonus>();

	public string BAIKKJKGAAB;

	[Multiline]
	[SerializeField]
	protected string bonusName = "Bonus Name";

	public string FPFCCDCGEHC;

	public string CONCDNAJKHN = string.Empty;

	public virtual string fullName
	{
		get
		{
			return bonusName;
		}
		set
		{
			bonusName = value;
		}
	}

	public virtual float AHNHOKHPBOA(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.JJEJLPJBHLG().GetRow(base.name);
		if (row == null)
		{
			return 610f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public virtual void EIPDMDNNOCE()
	{
	}

	public virtual bool GONLNEJFBKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public virtual bool CKMJBNEMDIG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public void FIMOBBBJKLL()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool LGJMNEKMDEO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	[SpecialName]
	public virtual string KNFGJNKNFIH()
	{
		return bonusName;
	}

	public virtual bool GCHILNJMFPD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	[SpecialName]
	public virtual void LFJMKNCHMMA(string IDEBKDPMPGM)
	{
		bonusName = IDEBKDPMPGM;
	}

	public virtual void KDLBPIIKMCD()
	{
	}

	public virtual void PFJBLLMHHHA()
	{
	}

	[SpecialName]
	public virtual string MDCIOFEBIPJ()
	{
		return bonusName;
	}

	public virtual void CEMADLCCFAG()
	{
	}

	public virtual void GPJFPNGANFC()
	{
	}

	public void LGHCHIFNCCJ()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public void DMKILBIKJLC()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	[SpecialName]
	public virtual void MMAMNDKGNIK(string IDEBKDPMPGM)
	{
		bonusName = IDEBKDPMPGM;
	}

	public virtual void JEJBENJKMHN()
	{
	}

	public virtual void OPDMAFAJHNA()
	{
	}

	public virtual void HAIDFJOINOA()
	{
	}

	public virtual bool HHOBEJGPLMO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	public virtual void AOKLGCNOOID()
	{
	}

	public virtual void PHIIBHDNKDM()
	{
	}

	public virtual bool OHHOJEJKLBB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public virtual bool FJAJKEBLFOE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public virtual bool MONJHGMOJAO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	public virtual void JHHBEHJGKKK()
	{
	}

	public virtual float JADBICHKEBK(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.AOIKJPJGCNO().GetRow(base.name);
		if (row == null)
		{
			return 730f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public virtual float CNDDJDPDKBH(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.ECOODKDALLG().GetRow(base.name);
		if (row == null)
		{
			return 1331f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public void MDMDKMGCNGE()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual void OBNMBGAGMFJ()
	{
	}

	[SpecialName]
	public virtual string BBDCKJOIHPM()
	{
		return bonusName;
	}

	public virtual float PLCIDFELCEP(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.IBMMIHANIJJ().GetRow(base.name);
		if (row == null)
		{
			return 1230f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public virtual bool BCDFEBKGHCN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public void FKIICOCBNHN()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool LJBDCGFBAHE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	[SpecialName]
	public virtual string GMLHDKFEIOH()
	{
		return bonusName;
	}

	[SpecialName]
	public virtual string BEHIACANIGG()
	{
		return bonusName;
	}

	public void Init()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool MCDFGACAGCG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	public virtual void AOBGIILGIBN()
	{
	}

	public virtual void SceneFreed()
	{
	}

	public virtual void JKEBCGNNDHM()
	{
	}

	public virtual bool CKMPBKMOIAF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public virtual void BGBNFLEKEKA()
	{
	}

	[SpecialName]
	public virtual string MLPCGNBFFCO()
	{
		return bonusName;
	}

	public virtual float GetBonusProbability(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.crates.GetRow(base.name);
		if (row == null)
		{
			return 0f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public virtual void HCEICANNFIO()
	{
	}

	public void AJAKDLHHFFO()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float NOCEDDCEEEM(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.JJEJLPJBHLG().GetRow(base.name);
		if (row == null)
		{
			return 1470f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public virtual bool LKJMDKHFMDL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	public virtual bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return true;
	}

	public virtual void KJDMBBKAGEP()
	{
	}

	public void GICCCHOJDLB()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool DAECMMEPAHL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	public virtual void BeforeGameStarted()
	{
	}

	public virtual void LCNFLADDNLM()
	{
	}

	[SpecialName]
	public virtual string BCGCNDMJEPN()
	{
		return bonusName;
	}

	public virtual void PHMBBFCBHLP()
	{
	}

	public virtual bool CMPIFPBJDLM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		return false;
	}

	public virtual void GCKDDIEKKBF()
	{
	}

	public virtual float IDHDFOPEEFO(PlayerController HNFNINFCBEJ)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.AOIKJPJGCNO().GetRow(base.name);
		if (row == null)
		{
			return 162f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public virtual void CEBAOMCHCOK()
	{
	}

	public void EGIDHHONMCN()
	{
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}
}
