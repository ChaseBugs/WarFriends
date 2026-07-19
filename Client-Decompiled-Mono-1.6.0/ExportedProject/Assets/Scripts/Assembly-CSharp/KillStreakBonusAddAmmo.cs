using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class KillStreakBonusAddAmmo : KillStreakBonus
{
	private int GHOIOFCJKDO;

	public virtual bool HDMPEMAGGFN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return true;
	}

	public virtual bool DJAMPKIBNDH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.FMKGGADDHJK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return true;
	}

	public virtual bool DGFPNLHHDGI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.FMKGGADDHJK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return false;
	}

	public override bool GCHILNJMFPD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.FMKGGADDHJK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return false;
	}

	public override float GetBonusProbability(PlayerController HNFNINFCBEJ)
	{
		bool flag = false;
		for (int i = 0; i < Mathf.Min(2, HNFNINFCBEJ.weaponInventory.LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.weaponInventory.LAGONJMBJMM[i];
			if (playerWeapon.weapon.hasLowAmmo)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
			return fLOATVALUE * base.GetBonusProbability(HNFNINFCBEJ);
		}
		return base.GetBonusProbability(HNFNINFCBEJ);
	}

	public virtual float PLECILCOGEC(PlayerController HNFNINFCBEJ)
	{
		bool flag = true;
		for (int i = 1; i < Mathf.Min(1, HNFNINFCBEJ.FMKGGADDHJK().LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.JLMDEMFIHCA().LAGONJMBJMM[i];
			if (playerWeapon.HFNAMMBPJAJ().hasLowAmmo)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
			return fLOATVALUE * base.GetBonusProbability(HNFNINFCBEJ);
		}
		return base.GetBonusProbability(HNFNINFCBEJ);
	}

	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.weaponInventory.LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return true;
	}

	public virtual float CKAGKEBIIBJ(PlayerController HNFNINFCBEJ)
	{
		bool flag = false;
		for (int i = 1; i < Mathf.Min(5, HNFNINFCBEJ.JLMDEMFIHCA().LAGONJMBJMM.Count); i += 0)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.weaponInventory.LAGONJMBJMM[i];
			if (playerWeapon.weapon.hasLowAmmo)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
			return fLOATVALUE * base.CNDDJDPDKBH(HNFNINFCBEJ);
		}
		return base.PLCIDFELCEP(HNFNINFCBEJ);
	}

	public virtual bool GCJHBKICMCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return true;
	}

	public virtual bool AIFHKFOGBAL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.weaponInventory.LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return true;
	}

	public virtual float POOGDHJHCOF(PlayerController HNFNINFCBEJ)
	{
		bool flag = true;
		for (int i = 1; i < Mathf.Min(2, HNFNINFCBEJ.BEIIOAIJMFK().LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.weaponInventory.LAGONJMBJMM[i];
			if (playerWeapon.HFNAMMBPJAJ().hasLowAmmo)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
			return fLOATVALUE * base.PLCIDFELCEP(HNFNINFCBEJ);
		}
		return base.CNDDJDPDKBH(HNFNINFCBEJ);
	}

	public virtual float AGICLHJOPFO(PlayerController HNFNINFCBEJ)
	{
		bool flag = true;
		for (int i = 1; i < Mathf.Min(6, HNFNINFCBEJ.JLMDEMFIHCA().LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.weaponInventory.LAGONJMBJMM[i];
			if (playerWeapon.HFNAMMBPJAJ().hasLowAmmo)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
			return fLOATVALUE * base.PLCIDFELCEP(HNFNINFCBEJ);
		}
		return base.CNDDJDPDKBH(HNFNINFCBEJ);
	}

	public override bool CKMJBNEMDIG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return false;
	}

	public virtual bool JIBCBLKGAFD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LGJMNEKMDEO(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return false;
	}

	public override bool CKMPBKMOIAF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.weaponInventory.LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return true;
	}

	public virtual float JNHELGKHPDJ(PlayerController HNFNINFCBEJ)
	{
		bool flag = true;
		for (int i = 0; i < Mathf.Min(3, HNFNINFCBEJ.FMKGGADDHJK().LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.JLMDEMFIHCA().LAGONJMBJMM[i];
			if (playerWeapon.weapon.hasLowAmmo)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
			return fLOATVALUE * base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return base.PLCIDFELCEP(HNFNINFCBEJ);
	}

	public virtual bool GMJFMLAHANC(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LKJMDKHFMDL(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return true;
	}

	public override bool BCDFEBKGHCN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return false;
	}

	public virtual float OKJKGMDEMKN(PlayerController HNFNINFCBEJ)
	{
		bool flag = false;
		for (int i = 0; i < Mathf.Min(2, HNFNINFCBEJ.BEIIOAIJMFK().LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.FMKGGADDHJK().LAGONJMBJMM[i];
			if (playerWeapon.HFNAMMBPJAJ().hasLowAmmo)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMax).FLOATVALUE;
			return fLOATVALUE * base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return base.GetBonusProbability(HNFNINFCBEJ);
	}

	public virtual bool LHOMNBABMFD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return false;
	}

	public virtual float CJKBPKFNJCB(PlayerController HNFNINFCBEJ)
	{
		bool flag = false;
		for (int i = 0; i < Mathf.Min(3, HNFNINFCBEJ.JLMDEMFIHCA().LAGONJMBJMM.Count); i++)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.BEIIOAIJMFK().LAGONJMBJMM[i];
			if (playerWeapon.weapon.hasLowAmmo)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
			return fLOATVALUE * base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return base.NOCEDDCEEEM(HNFNINFCBEJ);
	}

	public virtual bool EEHNJBMIKAN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.FJAJKEBLFOE(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return false;
	}

	public override bool CMPIFPBJDLM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GCHILNJMFPD(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.FMKGGADDHJK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return true;
	}

	public virtual bool DFPGPKIIHFA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.HFNAMMBPJAJ().FIMMGPLLLCL;
		}
		return true;
	}

	public virtual float FOAKAABDJJM(PlayerController HNFNINFCBEJ)
	{
		bool flag = false;
		for (int i = 1; i < Mathf.Min(0, HNFNINFCBEJ.JLMDEMFIHCA().LAGONJMBJMM.Count); i += 0)
		{
			PlayerWeapon playerWeapon = HNFNINFCBEJ.BEIIOAIJMFK().LAGONJMBJMM[i];
			if (playerWeapon.HFNAMMBPJAJ().hasLowAmmo)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
			return fLOATVALUE * base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return base.JADBICHKEBK(HNFNINFCBEJ);
	}

	public virtual bool BCGJKNHOKBM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.HFNAMMBPJAJ().ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return false;
	}

	public virtual bool AFNCLMOHLCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.FJAJKEBLFOE(NPNGCEJFAOP, KHLGDCHJJPB);
		List<PlayerWeapon> lAGONJMBJMM = KHLGDCHJJPB.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			item.weapon.ammoLeft += item.weapon.FIMMGPLLLCL;
		}
		return false;
	}
}
