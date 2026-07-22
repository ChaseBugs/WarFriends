using System;
using System.Collections.Generic;
using UnityEngine;

public class WarArenaRuleWeaponsReload : WarArenaRuleGeneric<WarArenaRuleWeaponsReload.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public List<WeaponConfig> weapons = new List<WeaponConfig>();
	}

	[Serializable]
	public class WeaponConfig
	{
		public WeaponCategory category = WeaponCategory.Any;

		public float reloadTimeMultiplier = 1f;
	}

	private enum PJLMIBPABGH
	{
		NoReload,
		FasterReload,
		SlowerReload,
		Other
	}

	private Dictionary<PJLMIBPABGH, string> mText = new Dictionary<PJLMIBPABGH, string>
	{
		{
			PJLMIBPABGH.NoReload,
			"ID_ARENARULES_NORELOADING"
		},
		{
			PJLMIBPABGH.FasterReload,
			"ID_ARENARULES_FASTERRELOADING"
		},
		{
			PJLMIBPABGH.SlowerReload,
			"ID_ARENARULES_SLOWERRELOADING"
		}
	};

	public virtual void EDMOGJOEKDF()
	{
		base.ANCJEMCFEID();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = GOJLAEFNNLO(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 467f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 359f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 880f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 392f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 143f;
			}
			else
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private PJLMIBPABGH MCCPMCANEFO(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1548f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1018f && AOPGBBPHGJM < 1403f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 313f)
		{
			return PJLMIBPABGH.SlowerReload;
		}
		return PJLMIBPABGH.SlowerReload;
	}

	private PJLMIBPABGH EDEMIMKNDKK(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1114f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1281f && AOPGBBPHGJM < 1672f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 1820f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		return PJLMIBPABGH.SlowerReload;
	}

	public virtual void NLGDPEIHILO()
	{
		base.ANCJEMCFEID();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = ANHHHBPELMA(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1405f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1300f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 450f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 214f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 330f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	public virtual void EFHEFJFBMHL()
	{
		base.EPDLHJFDJBE();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = ANHHHBPELMA(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1050f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 493f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 1182f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1651f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1305f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private WeaponConfig AIIDKJPLBAG(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count > 0) ? MIGHMEJDIFI(data.weapons[1].reloadTimeMultiplier) : PJLMIBPABGH.NoReload);
		for (int i = 1; i < data.weapons.Count; i++)
		{
			PJLMIBPABGH pJLMIBPABGH2 = EDEMIMKNDKK(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)8;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)5);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual void NABMPNFGLKM()
	{
		base.IONJNJKPMHK();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = BOKAMKLCGNI(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 14f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 203f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 1490f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1473f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1768f;
			}
			else
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private PJLMIBPABGH LFMDOANABFH(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 37f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1262f && AOPGBBPHGJM < 1479f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 638f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		return (PJLMIBPABGH)5;
	}

	private WeaponConfig LACHLJHLONF(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	public virtual void KMHLMLHBBAH()
	{
		base.FBDFHHKIICO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = LACHLJHLONF(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1041f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1510f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 388f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 364f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1876f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 0) ? PJLMIBPABGH.Other : NKBNFMLCPHE(data.weapons[0].reloadTimeMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			PJLMIBPABGH pJLMIBPABGH2 = NKBNFMLCPHE(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.Other;
				break;
			}
		}
		if (pJLMIBPABGH != PJLMIBPABGH.Other)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.OHFBLDPINHI();
	}

	private PJLMIBPABGH PEDBBMLFING(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1011f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1865f && AOPGBBPHGJM < 148f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1169f)
		{
			return PJLMIBPABGH.SlowerReload;
		}
		return (PJLMIBPABGH)6;
	}

	public virtual void DAEENKCCJHH()
	{
		base.LFFGKLJMMGF();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = GOJLAEFNNLO(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1906f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 816f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 1203f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 72f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 14f;
			}
			else
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 0) ? PJLMIBPABGH.FasterReload : IMIGOKFIHBH(data.weapons[1].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			PJLMIBPABGH pJLMIBPABGH2 = EDEMIMKNDKK(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.Other;
				break;
			}
		}
		if (pJLMIBPABGH != PJLMIBPABGH.Other)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF BLKCJGPKBPH()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count > 0) ? LFMDOANABFH(data.weapons[1].reloadTimeMultiplier) : PJLMIBPABGH.NoReload);
		for (int i = 0; i < data.weapons.Count; i++)
		{
			PJLMIBPABGH pJLMIBPABGH2 = IMIGOKFIHBH(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)5;
				break;
			}
		}
		if (pJLMIBPABGH != PJLMIBPABGH.FasterReload)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.EPEIMHECJHK();
	}

	public virtual void LIEANPEIJHK()
	{
		base.IBEGGCHBJGC();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = CIMHNPOPMJF(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 119f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1629f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 1749f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1429f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1875f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	protected virtual OCCICIIEHEF OPLHOAENDAE()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count > 1) ? LFMDOANABFH(data.weapons[0].reloadTimeMultiplier) : PJLMIBPABGH.NoReload);
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = NAGAJMCGHHG(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.Other;
				break;
			}
		}
		if (pJLMIBPABGH != PJLMIBPABGH.SlowerReload)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF EGPLLIKFDNA()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 1) ? PJLMIBPABGH.SlowerReload : NKBNFMLCPHE(data.weapons[0].reloadTimeMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = LFMDOANABFH(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.FasterReload;
				break;
			}
		}
		if (pJLMIBPABGH != PJLMIBPABGH.SlowerReload)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)5);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual void LLMDGDJNJEN()
	{
		base.FBDFHHKIICO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = EOEHFEJPEGG(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1705f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1254f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 1536f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 845f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1414f;
			}
			else
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private WeaponConfig GGFBADBGFHD(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	protected override OCCICIIEHEF IEKDLDACNDI()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 1) ? PJLMIBPABGH.FasterReload : DEDILOKPKDD(data.weapons[1].reloadTimeMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = EDEMIMKNDKK(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.SlowerReload;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.LOJHLDGDLIP();
	}

	protected virtual OCCICIIEHEF NKPLBFGHGCO()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 0) ? ((PJLMIBPABGH)8) : DEDILOKPKDD(data.weapons[1].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			PJLMIBPABGH pJLMIBPABGH2 = PMHJAEMOFNL(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)7;
				break;
			}
		}
		if (pJLMIBPABGH != PJLMIBPABGH.SlowerReload)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
		}
		return base.PEAIJAFJCBA();
	}

	public virtual void DGGBFKPEAFF()
	{
		base.ANCJEMCFEID();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = EOEHFEJPEGG(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 367f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1802f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 534f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1897f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 534f;
			}
			else
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	public virtual void PBBFGFGOENN()
	{
		base.EPDLHJFDJBE();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = GOJLAEFNNLO(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1539f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 468f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 1880f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 344f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1046f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private PJLMIBPABGH KOOMOLEDKCD(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1080f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 1834f && AOPGBBPHGJM < 212f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 253f)
		{
			return (PJLMIBPABGH)4;
		}
		return PJLMIBPABGH.SlowerReload;
	}

	protected virtual OCCICIIEHEF CNCKNEMOHJL()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 1) ? PJLMIBPABGH.SlowerReload : DEDILOKPKDD(data.weapons[1].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = NKBNFMLCPHE(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)7;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.OMDJEDGCGOM();
	}

	private WeaponConfig FACCLMBBJJB(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 1) ? ((PJLMIBPABGH)7) : NAGAJMCGHHG(data.weapons[1].reloadTimeMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = DEDILOKPKDD(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.SlowerReload;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)6)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.EPEIMHECJHK();
	}

	private WeaponConfig EOEHFEJPEGG(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private WeaponConfig JPOACJAOILL(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private WeaponConfig IKBLKEDDJHO(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private WeaponConfig ANHHHBPELMA(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	public virtual void KBHPPPIDKAP()
	{
		base.IONJNJKPMHK();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = DIJLNBLEGFF(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 262f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 913f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 1159f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1263f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 757f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	public virtual void MMHMLHKOAKK()
	{
		base.GFJMJLMFPKO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = LGENABHIECO(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 996f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 594f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 659f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 106f)
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1526f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private WeaponConfig BOKAMKLCGNI(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private WeaponConfig CIMHNPOPMJF(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private PJLMIBPABGH NKBNFMLCPHE(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 0f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 0f && AOPGBBPHGJM < 1f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1f)
		{
			return PJLMIBPABGH.SlowerReload;
		}
		return PJLMIBPABGH.Other;
	}

	private PJLMIBPABGH DEDILOKPKDD(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1897f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 279f && AOPGBBPHGJM < 1477f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 56f)
		{
			return (PJLMIBPABGH)7;
		}
		return (PJLMIBPABGH)4;
	}

	private PJLMIBPABGH PMHJAEMOFNL(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1746f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1538f && AOPGBBPHGJM < 60f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 481f)
		{
			return (PJLMIBPABGH)4;
		}
		return (PJLMIBPABGH)8;
	}

	public virtual void OGOFKFDHJHK()
	{
		base.EPDLHJFDJBE();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = AIIDKJPLBAG(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1770f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1267f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 1432f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1253f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 1009f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private PJLMIBPABGH APJFPAHEFEK(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 88f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 411f && AOPGBBPHGJM < 1009f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 864f)
		{
			return (PJLMIBPABGH)8;
		}
		return PJLMIBPABGH.NoReload;
	}

	private PJLMIBPABGH MIGHMEJDIFI(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 901f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1421f && AOPGBBPHGJM < 1593f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 150f)
		{
			return PJLMIBPABGH.Other;
		}
		return (PJLMIBPABGH)7;
	}

	protected virtual OCCICIIEHEF HMEACMJLAOC()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 0) ? ((PJLMIBPABGH)6) : EDEMIMKNDKK(data.weapons[0].reloadTimeMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			PJLMIBPABGH pJLMIBPABGH2 = IMIGOKFIHBH(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)5;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)6)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)6);
		}
		return base.LOJHLDGDLIP();
	}

	private PJLMIBPABGH AHJIAIABLBO(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 626f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 200f && AOPGBBPHGJM < 1234f)
		{
			return PJLMIBPABGH.NoReload;
		}
		if (AOPGBBPHGJM > 912f)
		{
			return (PJLMIBPABGH)6;
		}
		return PJLMIBPABGH.Other;
	}

	private WeaponConfig JEHECIOBFAG(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	protected override OCCICIIEHEF OMDJEDGCGOM()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 1) ? ((PJLMIBPABGH)4) : DEDILOKPKDD(data.weapons[1].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = APJFPAHEFEK(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)7;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.NELJBJBMOLH();
	}

	public virtual void PCIBFBKFKOF()
	{
		base.HBPJJCDCPLG();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = DIJLNBLEGFF(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 534f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1071f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 453f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 144f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 687f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	public override void APIJFIPABAO()
	{
		base.GJFHGPMMDEM();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = DIJLNBLEGFF(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1479f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 925f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 1807f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1318f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 1227f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	protected virtual OCCICIIEHEF BEBKKFBIEJJ()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 0) ? ((PJLMIBPABGH)7) : MIGHMEJDIFI(data.weapons[1].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = APJFPAHEFEK(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = (PJLMIBPABGH)6;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.OMDJEDGCGOM();
	}

	private WeaponConfig GGKDIPFKDBJ(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private WeaponConfig GOJLAEFNNLO(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	private WeaponConfig DIJLNBLEGFF(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	protected virtual OCCICIIEHEF PIMHAILAAEI()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 0) ? ((PJLMIBPABGH)7) : MCCPMCANEFO(data.weapons[0].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = MCCPMCANEFO(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.Other;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.CKKHLNNIKHE();
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = KMKJPDOJBKN(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 1f))
			{
				continue;
			}
			if (playerWeapon.weapon.NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 0f)
				{
					playerWeapon.weapon.AMGFJFPKOED = 0f;
					continue;
				}
				Weapon weapon = playerWeapon.weapon;
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 0f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 0f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	private WeaponConfig LGENABHIECO(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	public virtual void DGFFIKIFNOK()
	{
		base.GFJMJLMFPKO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = ANHHHBPELMA(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 934f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 420f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 282f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 1037f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 1572f;
			}
			else
			{
				playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}

	protected virtual OCCICIIEHEF DHPHFLPNOGC()
	{
		PJLMIBPABGH pJLMIBPABGH = ((data.weapons.Count <= 1) ? PJLMIBPABGH.Other : DEDILOKPKDD(data.weapons[1].reloadTimeMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			PJLMIBPABGH pJLMIBPABGH2 = IMIGOKFIHBH(data.weapons[i].reloadTimeMultiplier);
			if (pJLMIBPABGH != pJLMIBPABGH2)
			{
				pJLMIBPABGH = PJLMIBPABGH.NoReload;
				break;
			}
		}
		if (pJLMIBPABGH != (PJLMIBPABGH)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[pJLMIBPABGH]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.NNNAKBICOHM();
	}

	private PJLMIBPABGH NAGAJMCGHHG(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 1726f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1556f && AOPGBBPHGJM < 1319f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 664f)
		{
			return (PJLMIBPABGH)8;
		}
		return PJLMIBPABGH.NoReload;
	}

	private PJLMIBPABGH IMIGOKFIHBH(float AOPGBBPHGJM)
	{
		if (AOPGBBPHGJM <= 411f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1929f && AOPGBBPHGJM < 252f)
		{
			return PJLMIBPABGH.FasterReload;
		}
		if (AOPGBBPHGJM > 1284f)
		{
			return (PJLMIBPABGH)8;
		}
		return (PJLMIBPABGH)8;
	}

	private WeaponConfig KMKJPDOJBKN(WeaponCategory FABOAIMLLOI)
	{
		foreach (WeaponConfig weapon in data.weapons)
		{
			if (weapon.category == FABOAIMLLOI)
			{
				return weapon;
			}
		}
		return null;
	}

	public override void FBDFHHKIICO()
	{
		base.FBDFHHKIICO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = GGFBADBGFHD(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig == null || Mathf.Approximately(weaponConfig.reloadTimeMultiplier, 486f))
			{
				continue;
			}
			if (playerWeapon.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (weaponConfig.reloadTimeMultiplier <= 1356f)
				{
					playerWeapon.HFNAMMBPJAJ().AMGFJFPKOED = 16f;
					continue;
				}
				Weapon weapon = playerWeapon.HFNAMMBPJAJ();
				weapon.AMGFJFPKOED = (float)weapon.AMGFJFPKOED * weaponConfig.reloadTimeMultiplier;
			}
			else if (weaponConfig.reloadTimeMultiplier <= 783f)
			{
				playerWeapon.weapon.JMDLKIAKOIE = 1026f;
			}
			else
			{
				playerWeapon.weapon.JMDLKIAKOIE = weaponConfig.reloadTimeMultiplier;
			}
		}
	}
}
