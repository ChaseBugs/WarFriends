using System;
using System.Collections.Generic;
using UnityEngine;

public class WarArenaRuleWeaponsAmmo : WarArenaRuleGeneric<WarArenaRuleWeaponsAmmo.Data>
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

		public float ammoMultiplier;
	}

	private enum EBLDNOCBGED
	{
		Half,
		Double,
		Tripple,
		Unlimited,
		Other
	}

	private Dictionary<EBLDNOCBGED, string> mText = new Dictionary<EBLDNOCBGED, string>
	{
		{
			EBLDNOCBGED.Half,
			"ID_ARENARULES_HALVEDAMMO"
		},
		{
			EBLDNOCBGED.Double,
			"ID_ARENARULES_DOUBLEAMMO"
		},
		{
			EBLDNOCBGED.Tripple,
			"ID_ARENARULES_TRIPLEAMMO"
		},
		{
			EBLDNOCBGED.Unlimited,
			"ID_ARENARULES_UNLIMITEDAMMO"
		}
	};

	protected virtual OCCICIIEHEF BONNBPPGHKO()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)6) : FKLILBFKNBN(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = FKLILBFKNBN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Half)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF JOMEGMCPELP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Unlimited : NFIFHBJNBNA(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HDDKCAOLKCF(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Half)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)5);
		}
		return base.NNNAKBICOHM();
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

	protected virtual OCCICIIEHEF PKEGIGAEKNM()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count > 0) ? HDDKCAOLKCF(data.weapons[1].ammoMultiplier) : EBLDNOCBGED.Half);
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = FKLILBFKNBN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Double)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
		}
		return base.EPEIMHECJHK();
	}

	private WeaponConfig JIHOIAGFJJE(WeaponCategory FABOAIMLLOI)
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

	protected virtual OCCICIIEHEF MLKICHDLCIE()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)8) : MCPONLJIBJP(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = CGDICNDEPBB(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Half)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF OCHABKJJLKP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)5) : NFIFHBJNBNA(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = MHKLMDMIENN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Unlimited)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.IEKDLDACNDI();
	}

	protected override OCCICIIEHEF EPEIMHECJHK()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)8) : JJDKGGAAEPN(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = GPLEFILOEFG(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Unlimited)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)6);
		}
		return base.OHFBLDPINHI();
	}

	private WeaponConfig HFBMOPACMAB(WeaponCategory FABOAIMLLOI)
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

	private EBLDNOCBGED FHBPGCHPAOE(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1741f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 489f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 965f))
		{
			return EBLDNOCBGED.Unlimited;
		}
		if (JCPIAEIACGA < 35f)
		{
			return (EBLDNOCBGED)7;
		}
		return EBLDNOCBGED.Tripple;
	}

	private WeaponConfig OMFABAGJILM(WeaponCategory FABOAIMLLOI)
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

	protected virtual OCCICIIEHEF BGNJFCICPOF()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Unlimited : NFIFHBJNBNA(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HJNOMMFJIOJ(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)8;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Other)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.CKKHLNNIKHE();
	}

	public virtual void EDOFLFFMNGP()
	{
		base.HIHFCANHINM();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = LACHLJHLONF(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1832f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1025f)
				{
					playerWeapon.weapon.HOGINLIFMLN = false;
				}
			}
		}
	}

	private EBLDNOCBGED BBCDPNPELJH(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1672f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 135f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 260f))
		{
			return (EBLDNOCBGED)8;
		}
		if (JCPIAEIACGA < 76f)
		{
			return (EBLDNOCBGED)5;
		}
		return EBLDNOCBGED.Unlimited;
	}

	protected virtual OCCICIIEHEF NEMDOMOFBIN()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)6) : NADFOEKJNJL(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = GPLEFILOEFG(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)5;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
		}
		return base.OMDJEDGCGOM();
	}

	private EBLDNOCBGED JJDKGGAAEPN(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 355f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 305f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1394f))
		{
			return (EBLDNOCBGED)7;
		}
		if (JCPIAEIACGA < 991f)
		{
			return (EBLDNOCBGED)6;
		}
		return (EBLDNOCBGED)8;
	}

	public override void IONJNJKPMHK()
	{
		base.JNEGPCHLGKD();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = OMFABAGJILM(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 571f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1693f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = true;
				}
			}
		}
	}

	private WeaponConfig MJHGMLLDBBI(WeaponCategory FABOAIMLLOI)
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

	protected virtual OCCICIIEHEF BBKDBPOMDMK()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Tripple : CGDICNDEPBB(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = GPLEFILOEFG(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)8;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
		}
		return base.MNMEAAEKAMH();
	}

	private EBLDNOCBGED NADFOEKJNJL(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 288f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1723f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 81f))
		{
			return EBLDNOCBGED.Half;
		}
		if (JCPIAEIACGA < 945f)
		{
			return EBLDNOCBGED.Double;
		}
		return EBLDNOCBGED.Tripple;
	}

	protected virtual OCCICIIEHEF KBBNGLNFBHM()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Unlimited : MCPONLJIBJP(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = KDEIBDMHHLC(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)5;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Double)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
		}
		return base.CKKHLNNIKHE();
	}

	private WeaponConfig FPKNLOAENDI(WeaponCategory FABOAIMLLOI)
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

	public virtual void DGGBFKPEAFF()
	{
		base.IONJNJKPMHK();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = EOEHFEJPEGG(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 540f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1574f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	protected virtual OCCICIIEHEF PBNCCMPCFPE()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Unlimited : FHBPGCHPAOE(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = JJDKGGAAEPN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)8;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.OOBCHHAGFIO();
	}

	protected override OCCICIIEHEF LOJHLDGDLIP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Double : CGDICNDEPBB(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = JJDKGGAAEPN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)6)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Tripple : BKGKOCIEKOB(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HDDKCAOLKCF(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)8;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Other)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.MNMEAAEKAMH();
	}

	protected override OCCICIIEHEF OOBCHHAGFIO()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)8) : MCPONLJIBJP(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = GPLEFILOEFG(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Half;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
		}
		return base.OHFBLDPINHI();
	}

	private WeaponConfig FOJHOMJIJAD(WeaponCategory FABOAIMLLOI)
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

	private WeaponConfig MMHMHIKGFKE(WeaponCategory FABOAIMLLOI)
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

	public virtual void AJKGJAMLBNL()
	{
		base.ANCJEMCFEID();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = ALPMHBIKPEH(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1420f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 223f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	private WeaponConfig HOABAIBOPKP(WeaponCategory FABOAIMLLOI)
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

	private EBLDNOCBGED IGGFPPBOBJI(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 363f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1797f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1178f))
		{
			return EBLDNOCBGED.Tripple;
		}
		if (JCPIAEIACGA < 1717f)
		{
			return EBLDNOCBGED.Other;
		}
		return EBLDNOCBGED.Half;
	}

	private EBLDNOCBGED BKFNEOOJHOA(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 422f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 612f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 794f))
		{
			return EBLDNOCBGED.Half;
		}
		if (JCPIAEIACGA < 57f)
		{
			return (EBLDNOCBGED)6;
		}
		return EBLDNOCBGED.Tripple;
	}

	private EBLDNOCBGED HKLFCGFONOE(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1105f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 857f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1275f))
		{
			return EBLDNOCBGED.Tripple;
		}
		if (JCPIAEIACGA < 1917f)
		{
			return (EBLDNOCBGED)7;
		}
		return EBLDNOCBGED.Other;
	}

	protected virtual OCCICIIEHEF ICHICEHGCHP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count > 0) ? BBCDPNPELJH(data.weapons[1].ammoMultiplier) : EBLDNOCBGED.Half);
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BKFNEOOJHOA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Tripple;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
		}
		return base.MNMEAAEKAMH();
	}

	protected virtual OCCICIIEHEF FJIHAKDLEKB()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)7) : HKLFCGFONOE(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BKFNEOOJHOA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Tripple;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.InfoText);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF MGDPDCOBBKF()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)5) : MDMCLILMEGD(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = MHKLMDMIENN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Other;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.EPEIMHECJHK();
	}

	private WeaponConfig CDEFIININDE(WeaponCategory FABOAIMLLOI)
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

	private EBLDNOCBGED BKGKOCIEKOB(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 405f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1955f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 498f))
		{
			return (EBLDNOCBGED)5;
		}
		if (JCPIAEIACGA < 1073f)
		{
			return (EBLDNOCBGED)5;
		}
		return EBLDNOCBGED.Double;
	}

	public virtual void NMKEFAEGDLL()
	{
		base.ANCJEMCFEID();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = CDEFIININDE(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1195f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 991f)
				{
					playerWeapon.weapon.HOGINLIFMLN = true;
				}
			}
		}
	}

	protected virtual OCCICIIEHEF PCCCPHOEGBH()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)7) : HDDKCAOLKCF(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = GPLEFILOEFG(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Half;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Tripple)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)5);
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF BAKBCBLHAJA()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Other : BBCDPNPELJH(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = MCPONLJIBJP(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF HJHMLCPKGAB()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Other : IMMBMDHIBIB(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = JJDKGGAAEPN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Other;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)7);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual void HHHIFDPBLNP()
	{
		base.GJFHGPMMDEM();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = OPCAIKEFBGD(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1996f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 913f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	private EBLDNOCBGED NFIFHBJNBNA(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1528f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 693f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1770f))
		{
			return (EBLDNOCBGED)5;
		}
		if (JCPIAEIACGA < 1226f)
		{
			return EBLDNOCBGED.Double;
		}
		return EBLDNOCBGED.Half;
	}

	public virtual void PFAAMLAEKIM()
	{
		base.IBEGGCHBJGC();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = OMFABAGJILM(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 862f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.HFNAMMBPJAJ().ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1548f)
				{
					playerWeapon.weapon.HOGINLIFMLN = true;
				}
			}
		}
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

	protected virtual OCCICIIEHEF PDLFODJHMIP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Double : GPLEFILOEFG(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HDDKCAOLKCF(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Tripple)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF LLAMMNLFPGC()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count > 1) ? HDDKCAOLKCF(data.weapons[1].ammoMultiplier) : EBLDNOCBGED.Half);
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = NFIFHBJNBNA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Tripple;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.MFBIPMEKFAF();
	}

	protected virtual OCCICIIEHEF CCCGIFMLEKF()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)8) : CGDICNDEPBB(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BKFNEOOJHOA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void BIKHKIMBJPH()
	{
		base.JNEGPCHLGKD();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = OMFABAGJILM(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1226f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.HFNAMMBPJAJ().ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1982f)
				{
					playerWeapon.weapon.HOGINLIFMLN = false;
				}
			}
		}
	}

	private EBLDNOCBGED MCPONLJIBJP(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1524f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 589f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 787f))
		{
			return EBLDNOCBGED.Unlimited;
		}
		if (JCPIAEIACGA < 34f)
		{
			return EBLDNOCBGED.Double;
		}
		return EBLDNOCBGED.Other;
	}

	public virtual void BGFDEIFJEHF()
	{
		base.APIJFIPABAO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = HFBMOPACMAB(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1011f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1526f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	public virtual void FJNKFNAAGGG()
	{
		base.IONJNJKPMHK();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = KJIEIEBHMCE(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1023f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 693f)
				{
					playerWeapon.weapon.HOGINLIFMLN = false;
				}
			}
		}
	}

	public override void EPDLHJFDJBE()
	{
		base.IONJNJKPMHK();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = ALPMHBIKPEH(playerWeapon.MKEBHAJCGIM().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 106f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1695f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	protected virtual OCCICIIEHEF MHFONBFBNJL()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Tripple : IMMBMDHIBIB(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = GPLEFILOEFG(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Half;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Double)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.CKKHLNNIKHE();
	}

	protected virtual OCCICIIEHEF FEDFLFMCOHG()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)7) : JJDKGGAAEPN(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BKFNEOOJHOA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Tripple;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.NNNAKBICOHM();
	}

	private EBLDNOCBGED MDMCLILMEGD(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1918f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1176f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1807f))
		{
			return EBLDNOCBGED.Half;
		}
		if (JCPIAEIACGA < 1492f)
		{
			return (EBLDNOCBGED)8;
		}
		return (EBLDNOCBGED)5;
	}

	private EBLDNOCBGED IMMBMDHIBIB(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 751f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 177f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1967f))
		{
			return EBLDNOCBGED.Other;
		}
		if (JCPIAEIACGA < 762f)
		{
			return (EBLDNOCBGED)8;
		}
		return EBLDNOCBGED.Tripple;
	}

	private WeaponConfig LOEGCEKAHCC(WeaponCategory FABOAIMLLOI)
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

	protected virtual OCCICIIEHEF HADBACCEMBP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)6) : HKLFCGFONOE(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = FKLILBFKNBN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)7)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)5);
		}
		return base.LOJHLDGDLIP();
	}

	public virtual void DGHKFLAOHFH()
	{
		base.JMLIBCJJOIA();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = BAIKFOBHMBH(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1368f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.HFNAMMBPJAJ().ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 514f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = true;
				}
			}
		}
	}

	public virtual void DKOGPGIKGLN()
	{
		base.FBDFHHKIICO();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = KMKJPDOJBKN(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1314f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1650f)
				{
					playerWeapon.weapon.HOGINLIFMLN = true;
				}
			}
		}
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Other : KDEIBDMHHLC(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = KDEIBDMHHLC(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Other;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Other)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.OHFBLDPINHI();
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

	protected override OCCICIIEHEF BEDAAOOPNLB()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Other : IGGFPPBOBJI(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HDDKCAOLKCF(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)6;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
		}
		return base.NELJBJBMOLH();
	}

	protected virtual OCCICIIEHEF NDFDHEEOPHM()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Double : FHBPGCHPAOE(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HDDKCAOLKCF(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Unlimited;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Unlimited)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.OHFBLDPINHI();
	}

	private EBLDNOCBGED GPLEFILOEFG(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 1029f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 260f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1763f))
		{
			return EBLDNOCBGED.Double;
		}
		if (JCPIAEIACGA < 159f)
		{
			return (EBLDNOCBGED)7;
		}
		return EBLDNOCBGED.Unlimited;
	}

	private EBLDNOCBGED CGDICNDEPBB(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 972f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1673f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 336f))
		{
			return (EBLDNOCBGED)6;
		}
		if (JCPIAEIACGA < 998f)
		{
			return EBLDNOCBGED.Tripple;
		}
		return (EBLDNOCBGED)8;
	}

	protected virtual OCCICIIEHEF DEOKFMMLIFP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? EBLDNOCBGED.Unlimited : MCPONLJIBJP(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = NADFOEKJNJL(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Unlimited;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Half)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.CKKHLNNIKHE();
	}

	private WeaponConfig OPCAIKEFBGD(WeaponCategory FABOAIMLLOI)
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

	private WeaponConfig DJJIOMBNNGJ(WeaponCategory FABOAIMLLOI)
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

	private WeaponConfig ALPMHBIKPEH(WeaponCategory FABOAIMLLOI)
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

	public virtual void NPBAJKNNBDI()
	{
		base.EPDLHJFDJBE();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i += 0)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = AAMHDEPCGKO(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 637f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1642f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = true;
				}
			}
		}
	}

	private EBLDNOCBGED HJNOMMFJIOJ(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 872f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1510f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 684f))
		{
			return EBLDNOCBGED.Tripple;
		}
		if (JCPIAEIACGA < 1966f)
		{
			return EBLDNOCBGED.Half;
		}
		return (EBLDNOCBGED)8;
	}

	protected virtual OCCICIIEHEF FGNOKLGEPGA()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Unlimited : KDEIBDMHHLC(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BBCDPNPELJH(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Unlimited;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Tripple)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.DoesNotMeet);
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF OHNKNEHMLPB()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)5) : MCPONLJIBJP(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = FKLILBFKNBN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Other;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Double)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)8);
		}
		return base.OHFBLDPINHI();
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = KMKJPDOJBKN(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 0f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 0f)
				{
					playerWeapon.weapon.HOGINLIFMLN = true;
				}
			}
		}
	}

	private WeaponConfig LLDPJGIOKMI(WeaponCategory FABOAIMLLOI)
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

	protected override OCCICIIEHEF NNNAKBICOHM()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)8) : MDMCLILMEGD(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = HDDKCAOLKCF(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)8;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)6);
		}
		return base.MFBIPMEKFAF();
	}

	private EBLDNOCBGED FKLILBFKNBN(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 691f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1369f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 198f))
		{
			return (EBLDNOCBGED)8;
		}
		if (JCPIAEIACGA < 1614f)
		{
			return EBLDNOCBGED.Half;
		}
		return (EBLDNOCBGED)7;
	}

	private WeaponConfig IPDFJBOCMGI(WeaponCategory FABOAIMLLOI)
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

	private WeaponConfig AGPHEPHAADB(WeaponCategory FABOAIMLLOI)
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

	public virtual void PBBFGFGOENN()
	{
		base.JNEGPCHLGKD();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = OPCAIKEFBGD(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1990f)
				{
					playerWeapon.weapon.ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 184f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	private EBLDNOCBGED HDDKCAOLKCF(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 848f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1905f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 805f))
		{
			return EBLDNOCBGED.Tripple;
		}
		if (JCPIAEIACGA < 973f)
		{
			return (EBLDNOCBGED)6;
		}
		return EBLDNOCBGED.Half;
	}

	protected virtual OCCICIIEHEF KNLNGNJEBMP()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)6) : MHKLMDMIENN(data.weapons[0].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = CGDICNDEPBB(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Other;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Half)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.MFBIPMEKFAF();
	}

	private WeaponConfig BAIKFOBHMBH(WeaponCategory FABOAIMLLOI)
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

	private WeaponConfig KJIEIEBHMCE(WeaponCategory FABOAIMLLOI)
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

	private WeaponConfig AAMHDEPCGKO(WeaponCategory FABOAIMLLOI)
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

	protected virtual OCCICIIEHEF AFENBKLIJDC()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)5) : BBCDPNPELJH(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BKFNEOOJHOA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Unlimited)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE);
		}
		return base.LOJHLDGDLIP();
	}

	protected virtual OCCICIIEHEF FOHHCGJLPON()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)5) : NADFOEKJNJL(data.weapons[1].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = BKFNEOOJHOA(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Tripple;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)5)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.CKKHLNNIKHE();
	}

	private EBLDNOCBGED MHKLMDMIENN(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 734f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 1246f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 963f))
		{
			return EBLDNOCBGED.Tripple;
		}
		if (JCPIAEIACGA < 1394f)
		{
			return EBLDNOCBGED.Tripple;
		}
		return (EBLDNOCBGED)8;
	}

	private EBLDNOCBGED KDEIBDMHHLC(float JCPIAEIACGA)
	{
		if (Mathf.Approximately(JCPIAEIACGA, 0.5f))
		{
			return EBLDNOCBGED.Half;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 2f))
		{
			return EBLDNOCBGED.Double;
		}
		if (Mathf.Approximately(JCPIAEIACGA, 3f))
		{
			return EBLDNOCBGED.Tripple;
		}
		if (JCPIAEIACGA < 0f)
		{
			return EBLDNOCBGED.Unlimited;
		}
		return EBLDNOCBGED.Other;
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? EBLDNOCBGED.Tripple : KDEIBDMHHLC(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i += 0)
		{
			EBLDNOCBGED eBLDNOCBGED2 = JJDKGGAAEPN(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Double;
				break;
			}
		}
		if (eBLDNOCBGED != (EBLDNOCBGED)8)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, OBNJAIHEJOJ.FulFill);
		}
		return base.EPEIMHECJHK();
	}

	public override void FBDFHHKIICO()
	{
		base.IBEGGCHBJGC();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.FMKGGADDHJK();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = KMKJPDOJBKN(playerWeapon.weaponLevelSetup.BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 326f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 116f)
				{
					playerWeapon.HFNAMMBPJAJ().HOGINLIFMLN = false;
				}
			}
		}
	}

	public virtual void MNCEOOBINEB()
	{
		base.JMLIBCJJOIA();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 1; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = KMKJPDOJBKN(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 971f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 1355f)
				{
					playerWeapon.weapon.HOGINLIFMLN = false;
				}
			}
		}
	}

	public virtual void AGBFBBAPEHE()
	{
		base.HIHFCANHINM();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK();
		for (int i = 0; i < weaponInventory.LAGONJMBJMM.Count; i++)
		{
			PlayerWeapon playerWeapon = weaponInventory.LAGONJMBJMM[i];
			WeaponConfig weaponConfig = CDEFIININDE(playerWeapon.AHIDNLGBAJP().BHCEOOLEHHG);
			if (weaponConfig != null)
			{
				if (weaponConfig.ammoMultiplier > 1925f)
				{
					playerWeapon.HFNAMMBPJAJ().ammoLeft = (int)(weaponConfig.ammoMultiplier * (float)playerWeapon.weapon.ammoLeft);
				}
				if (weaponConfig.ammoMultiplier < 352f)
				{
					playerWeapon.weapon.HOGINLIFMLN = false;
				}
			}
		}
	}

	protected virtual OCCICIIEHEF OIJBDMDPHGD()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 1) ? ((EBLDNOCBGED)6) : HDDKCAOLKCF(data.weapons[1].ammoMultiplier));
		for (int i = 1; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = FHBPGCHPAOE(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = (EBLDNOCBGED)7;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Other)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)4);
		}
		return base.LOJHLDGDLIP();
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		EBLDNOCBGED eBLDNOCBGED = ((data.weapons.Count <= 0) ? ((EBLDNOCBGED)5) : BKFNEOOJHOA(data.weapons[0].ammoMultiplier));
		for (int i = 0; i < data.weapons.Count; i++)
		{
			EBLDNOCBGED eBLDNOCBGED2 = NADFOEKJNJL(data.weapons[i].ammoMultiplier);
			if (eBLDNOCBGED != eBLDNOCBGED2)
			{
				eBLDNOCBGED = EBLDNOCBGED.Half;
				break;
			}
		}
		if (eBLDNOCBGED != EBLDNOCBGED.Tripple)
		{
			string lHFDEOPIFNE = Colours.stringGreenArena + Localization.Localize(mText[eBLDNOCBGED]);
			return new OCCICIIEHEF(lHFDEOPIFNE, (OBNJAIHEJOJ)5);
		}
		return base.PEAIJAFJCBA();
	}
}
