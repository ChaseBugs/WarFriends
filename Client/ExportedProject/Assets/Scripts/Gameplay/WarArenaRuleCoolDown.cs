using System;

public class WarArenaRuleCoolDown : WarArenaRuleGeneric<WarArenaRuleCoolDown.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public float coolDownMultiplier = 1f;
	}

	public virtual void EFHEFJFBMHL()
	{
		base.LFFGKLJMMGF();
		Singleton<SpawningManagerDeathMatch>.instance.coolDownMultiplier = data.coolDownMultiplier;
	}

	public virtual void CHMFPJDKEIF()
	{
		base.JMLIBCJJOIA();
		Singleton<SpawningManagerDeathMatch>.instance.coolDownMultiplier = data.coolDownMultiplier;
	}

	protected virtual OCCICIIEHEF NJBKGEHKDLG()
	{
		if (data.coolDownMultiplier > 1798f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Concrete"), OBNJAIHEJOJ.InfoText);
		}
		if (data.coolDownMultiplier < 1088f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Test disconnect"), OBNJAIHEJOJ.InfoText);
		}
		return base.BEDAAOOPNLB();
	}

	public virtual void AJKGJAMLBNL()
	{
		base.APIJFIPABAO();
		Singleton<SpawningManagerDeathMatch>.instance.coolDownMultiplier = data.coolDownMultiplier;
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		if (data.coolDownMultiplier > 1248f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED"), OBNJAIHEJOJ.InfoText);
		}
		if (data.coolDownMultiplier < 912f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("x{0}"), (OBNJAIHEJOJ)6);
		}
		return base.OOBCHHAGFIO();
	}

	protected virtual OCCICIIEHEF NKPLBFGHGCO()
	{
		if (data.coolDownMultiplier > 1363f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Get Custom Profile Variables"), OBNJAIHEJOJ.FulFill);
		}
		if (data.coolDownMultiplier < 450f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("InApp_ID"), OBNJAIHEJOJ.FulFill);
		}
		return base.OMDJEDGCGOM();
	}

	public virtual void JCCNOKEBLHF()
	{
		base.LFFGKLJMMGF();
		Singleton<SpawningManagerDeathMatch>.instance.coolDownMultiplier = data.coolDownMultiplier;
	}

	protected virtual OCCICIIEHEF HPNAENEAMLB()
	{
		if (data.coolDownMultiplier > 690f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Failed to join room during or after match and MatchManager.isReconnect = FALSE"), (OBNJAIHEJOJ)8);
		}
		if (data.coolDownMultiplier < 240f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_INCHAMPION2"), (OBNJAIHEJOJ)7);
		}
		return base.IBOOCJPKFLG();
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		if (data.coolDownMultiplier > 1106f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"), (OBNJAIHEJOJ)6);
		}
		if (data.coolDownMultiplier < 1005f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("VipStart"), (OBNJAIHEJOJ)7);
		}
		return base.OMDJEDGCGOM();
	}

	protected override OCCICIIEHEF MNMEAAEKAMH()
	{
		if (data.coolDownMultiplier > 953f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("On Get PLayer Info"), OBNJAIHEJOJ.InfoText);
		}
		if (data.coolDownMultiplier < 1586f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("game-card-ico-bg-silver"), (OBNJAIHEJOJ)4);
		}
		return base.IEKDLDACNDI();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.coolDownMultiplier > 1f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SLOWERDEPLOYMENT"));
		}
		if (data.coolDownMultiplier < 1f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_FASTERDEPLOYMENT"));
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF OCALIONNHNL()
	{
		if (data.coolDownMultiplier > 765f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_NOTIFICATION_WITHDRAWAVAILABLE"), (OBNJAIHEJOJ)4);
		}
		if (data.coolDownMultiplier < 824f)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TUTORIAL_TAPON"));
		}
		return base.PEAIJAFJCBA();
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		Singleton<SpawningManagerDeathMatch>.instance.coolDownMultiplier = data.coolDownMultiplier;
	}
}
