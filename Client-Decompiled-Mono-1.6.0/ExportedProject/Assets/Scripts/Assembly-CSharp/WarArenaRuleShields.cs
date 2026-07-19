using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;

public class WarArenaRuleShields : WarArenaRuleGeneric<WarArenaRuleShields.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		public bool immortalShieds;

		public bool noShields;

		public bool noRespawn;

		public float respawnTime;

		public float shieldHP;
	}

	protected virtual OCCICIIEHEF EPOLOANGNOI()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("+"), (OBNJAIHEJOJ)8);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("On conencted to photon"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(")"), (OBNJAIHEJOJ)8);
		}
		if (data.respawnTime > 1014f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.LowNumberOfCards);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Test Setter Methods"));
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ACD: Phone jail braked"), (OBNJAIHEJOJ)6);
			}
		}
		else if (data.shieldHP > 287f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("-1"), (OBNJAIHEJOJ)7);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("("), (OBNJAIHEJOJ)6);
			}
		}
		return base.NNNAKBICOHM();
	}

	public override void JMLIBCJJOIA()
	{
		base.APIJFIPABAO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 1503f;
				shield.ENKDOKELOED(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 676f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual void FKPKLIABCGC()
	{
		base.JNEGPCHLGKD();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.JPHAJDIIAAI();
			if (data.noShields)
			{
				shield.MPOAIDJNDFJ();
				shield.maxHealth = 1279f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(data.noRespawn);
			if (data.respawnTime > 464f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	protected override OCCICIIEHEF LMOHCGEPLAH()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("League"), (OBNJAIHEJOJ)5);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}{2}"), (OBNJAIHEJOJ)7);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("TransactionId123"), OBNJAIHEJOJ.FulFill);
		}
		if (data.respawnTime > 707f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-51));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_BRONZE"), OBNJAIHEJOJ.InfoText);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Loading - cancel clicked, will to try call disconnect"), (OBNJAIHEJOJ)8);
			}
		}
		else if (data.shieldHP > 1287f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("S"), (OBNJAIHEJOJ)4);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("^\\D*"), (OBNJAIHEJOJ)4);
			}
		}
		return base.LOJHLDGDLIP();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_UNBREAKABLESHIELDS"));
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_NOSHIELDS"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSDONTRESPAWN"));
		}
		if (data.respawnTime > 0f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRepairTime);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSRESPAWNSLOWER"));
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSRESPAWNFASTER"));
			}
		}
		else if (data.shieldHP > 0f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSBREAKSLOWER"));
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSBREAKFASTER"));
			}
		}
		return base.OHFBLDPINHI();
	}

	protected virtual OCCICIIEHEF NACPOMOHGBJ()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Skillshot 0000"), (OBNJAIHEJOJ)5);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK"), (OBNJAIHEJOJ)4);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} \"{1}\" for {2}"), (OBNJAIHEJOJ)6);
		}
		if (data.respawnTime > 1359f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-85));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_UNLOCKEDATRANK"), (OBNJAIHEJOJ)4);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_JOINORCREATESQUADHINT"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		else if (data.shieldHP > 861f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("unregisterConnectionFailedListener"), (OBNJAIHEJOJ)6);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("pack"), (OBNJAIHEJOJ)4);
			}
		}
		return base.EPEIMHECJHK();
	}

	public virtual void DHIMKHMIANB()
	{
		base.ALJKKBMBBFM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.PNKKPNIMEPL();
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 752f;
				shield.ENKDOKELOED(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 1633f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool MBBGMOGDAAM()
	{
		base.OEAODGFDMGC();
		if (data.shieldHP > 1051f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public virtual bool AKCJIOOJHCG()
	{
		base.DDFGIDBHJIK();
		if (data.shieldHP > 1963f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	public virtual bool EBMFBLPEJBI()
	{
		base.KJDMOCMBFLJ();
		if (data.shieldHP > 1696f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	protected virtual OCCICIIEHEF GDFMGBDHEMD()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("RecieveStolen"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_JOININGSQUAD_TEXT"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Server response: "), OBNJAIHEJOJ.FulFill);
		}
		if (data.respawnTime > 649f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-8));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("com/google/android/gms/common/ConnectionResult"), OBNJAIHEJOJ.InfoText);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WENEEDTO"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		else if (data.shieldHP > 821f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("LeagueEvaluation"));
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("LevelRewards"), (OBNJAIHEJOJ)5);
			}
		}
		return base.PEAIJAFJCBA();
	}

	public virtual bool KOHMDOHKMIH()
	{
		base.AIMGMMCHEIO();
		if (data.shieldHP > 1720f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	protected virtual OCCICIIEHEF NDFDHEEOPHM()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#AccoutCheck# missing ID from server"), (OBNJAIHEJOJ)5);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENASHORTCUTEVENTEND"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Donate_Card"), (OBNJAIHEJOJ)4);
		}
		if (data.respawnTime > 217f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCardRarity);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("decal not found in sheet: "), OBNJAIHEJOJ.InfoText);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Shots_Fired"), (OBNJAIHEJOJ)6);
			}
		}
		else if (data.shieldHP > 1195f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumPing).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player profile - Show dialog for PLAYER: {0} with id: {1}"), OBNJAIHEJOJ.FulFill);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}"), (OBNJAIHEJOJ)4);
			}
		}
		return base.OOBCHHAGFIO();
	}

	protected virtual OCCICIIEHEF DMJPIAALNJK()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("grenadeExplosion"), (OBNJAIHEJOJ)8);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_TUTORIAL_TAPON"), (OBNJAIHEJOJ)4);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_SELECTEDANDDELETEDACCOUNT"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.respawnTime > 1324f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-128));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Generate army 3"), (OBNJAIHEJOJ)7);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("game-card-bronze"), OBNJAIHEJOJ.FulFill);
			}
		}
		else if (data.shieldHP > 1543f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumMasterFPS).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("registerEvent"), (OBNJAIHEJOJ)4);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("QUIT"), (OBNJAIHEJOJ)6);
			}
		}
		return base.NELJBJBMOLH();
	}

	public virtual void MPDCMCLHIPA()
	{
		base.ANCJEMCFEID();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 609f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 324f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool HFCHLFNKAAL()
	{
		base.OAELLJPGBPC();
		if (data.shieldHP > 498f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	protected virtual OCCICIIEHEF DEKPLKOFMFM()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BattleAnalytics"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("otherInfo"), (OBNJAIHEJOJ)7);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("TryRecconnect TryRecconnectToPhotonCoroutine going to reconnect"), (OBNJAIHEJOJ)6);
		}
		if (data.respawnTime > 1298f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CreateSquadUnlockLevel);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}"), (OBNJAIHEJOJ)4);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("videoAdRewardTimes"), OBNJAIHEJOJ.InfoText);
			}
		}
		else if (data.shieldHP > 1131f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("title"));
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-wftv-twitch-ico"), (OBNJAIHEJOJ)7);
			}
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void KDPPNFLMDHG()
	{
		base.JMLIBCJJOIA();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.PHANADCNBFD();
			if (data.noShields)
			{
				shield.MPOAIDJNDFJ();
				shield.maxHealth = 129f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(data.noRespawn);
			if (data.respawnTime > 1400f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool JFEDDBNNDNJ()
	{
		base.EDNAIMPLPGL();
		if (data.shieldHP > 183f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	protected virtual OCCICIIEHEF AMOCDNPPEHN()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("RETRY"), (OBNJAIHEJOJ)6);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("bazooka_idle"), OBNJAIHEJOJ.FulFill);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_DEBUG_GUIERROR"));
		}
		if (data.respawnTime > 1254f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-79));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Video {0} \"{1}\" has wrong order {2}"), OBNJAIHEJOJ.InfoText);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL_TEXT"), (OBNJAIHEJOJ)4);
			}
		}
		else if (data.shieldHP > 802f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.UnlockLevel).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("S"), (OBNJAIHEJOJ)7);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("warbucks"), (OBNJAIHEJOJ)7);
			}
		}
		return base.MFBIPMEKFAF();
	}

	public virtual bool OEIAKOCOBNH()
	{
		base.EKMMLNKADIL();
		if (data.shieldHP > 1656f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	public virtual void FJNKFNAAGGG()
	{
		base.IONJNJKPMHK();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LHHMNLJKOAO();
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 1577f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(data.noRespawn);
			if (data.respawnTime > 83f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public override void ANCJEMCFEID()
	{
		base.IBEGGCHBJGC();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 469f;
				shield.GCAKAFMDFJA(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(!data.noRespawn);
			if (data.respawnTime > 1888f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	protected virtual OCCICIIEHEF GIGFFEIMCDL()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_SERVERDIDNTRESPONDAFTER"), (OBNJAIHEJOJ)7);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Panel   z:{0}\t\"{1}\""), (OBNJAIHEJOJ)4);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("DemotedPlayer"), OBNJAIHEJOJ.FulFill);
		}
		if (data.respawnTime > 1172f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-68));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Action"));
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ObjectPool"), OBNJAIHEJOJ.FulFill);
			}
		}
		else if (data.shieldHP > 1810f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_LOADING"));
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("N"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		return base.LOJHLDGDLIP();
	}

	public override void GFJMJLMFPKO()
	{
		base.GFJMJLMFPKO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.DestroyShield();
				shield.maxHealth = 1520f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 1561f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool KJBLKMDHJMC()
	{
		base.KFJLPGPAAAN();
		if (data.shieldHP > 1147f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return false;
	}

	public virtual void EGEDKGLILBI()
	{
		base.LFFGKLJMMGF();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.PNKKPNIMEPL();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 281f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 511f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void OAMKKKAEKGE()
	{
		base.EPDLHJFDJBE();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LHHMNLJKOAO();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 924f;
				shield.GCAKAFMDFJA(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(data.noRespawn);
			if (data.respawnTime > 1948f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool PEDMFJFENBF()
	{
		base.EKMMLNKADIL();
		if (data.shieldHP > 505f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public override void HBPJJCDCPLG()
	{
		base.APIJFIPABAO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.JPHAJDIIAAI();
			if (data.noShields)
			{
				shield.KDEEBMLFABC();
				shield.maxHealth = 1229f;
				shield.GCAKAFMDFJA(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 1419f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	protected virtual OCCICIIEHEF PAJJOHEGNKJ()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("#PETER# Weapon Screen - LEFT BUTTON - weapon state: OTHER\t\tbutton type: EMPTY"), (OBNJAIHEJOJ)7);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(" NOT OK!"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("b"), (OBNJAIHEJOJ)8);
		}
		if (data.respawnTime > 867f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-14));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SquadId"), (OBNJAIHEJOJ)5);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_GAMECENTERNAMETEXT"), OBNJAIHEJOJ.FulFill);
			}
		}
		else if (data.shieldHP > 1121f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Unit"), (OBNJAIHEJOJ)4);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("OK"), (OBNJAIHEJOJ)4);
			}
		}
		return base.OMDJEDGCGOM();
	}

	protected virtual OCCICIIEHEF EJCFKMFGHND()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player or link is null"), (OBNJAIHEJOJ)7);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENAEVENTSTARTSIN"), (OBNJAIHEJOJ)7);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ROCKETLAUNCHERTUTORIALTEXT"), (OBNJAIHEJOJ)7);
		}
		if (data.respawnTime > 1048f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarityEarly);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("key= "), (OBNJAIHEJOJ)8);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ACTIVATEINSTEADOF"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		else if (data.shieldHP > 1397f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.WarArenaReminderHours).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Clear players"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("-{0}"), OBNJAIHEJOJ.InfoText);
			}
		}
		return base.LOJHLDGDLIP();
	}

	public override void APIJFIPABAO()
	{
		base.HBPJJCDCPLG();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.IGEDGCNJCAP();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 16f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(!data.noRespawn);
			if (data.respawnTime > 404f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public override void JNEGPCHLGKD()
	{
		base.JNEGPCHLGKD();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.PKBPGCGNCAD();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 273f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 255f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool DLOLNAIPFHF()
	{
		base.DDFGIDBHJIK();
		if (data.shieldHP > 381f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return false;
	}

	protected virtual OCCICIIEHEF IJIPGJEODNI()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("S"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("cn"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("[FFFFFF]{0}[-]  {1}"), (OBNJAIHEJOJ)5);
		}
		if (data.respawnTime > 912f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalWoUDelayMin);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Scraps"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("2DBigSprites/menu-membership-agent-big"), (OBNJAIHEJOJ)5);
			}
		}
		else if (data.shieldHP > 1978f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("com.tune.unityutils.TuneUnityFirstPlaylistListener"), (OBNJAIHEJOJ)7);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("fire"), (OBNJAIHEJOJ)7);
			}
		}
		return base.LMOHCGEPLAH();
	}

	public virtual bool PKKFFEAHJDG()
	{
		base.CLPEMLCLDIJ();
		if (data.shieldHP > 1378f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	public virtual void NMFIPDDECCN()
	{
		base.ANCJEMCFEID();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.KJCHIHLJMMF();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 1623f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 551f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void KMHLMLHBBAH()
	{
		base.HIHFCANHINM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.JPHAJDIIAAI();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 96f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 391f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool ECMHMGPLMGC()
	{
		base.DAHIFNEGKAD();
		if (data.shieldHP > 592f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return false;
	}

	protected override OCCICIIEHEF OMDJEDGCGOM()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_GETTOAVOIDRELEGATION1"), (OBNJAIHEJOJ)6);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("+"), (OBNJAIHEJOJ)8);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("mortar_up"), (OBNJAIHEJOJ)8);
		}
		if (data.respawnTime > 724f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-32));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(","), OBNJAIHEJOJ.FulFill);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("| time: "), (OBNJAIHEJOJ)8);
			}
		}
		else if (data.shieldHP > 15f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_WARNING_CANTSENDINVITE"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SquadCards"), OBNJAIHEJOJ.InfoText);
			}
		}
		return base.MFBIPMEKFAF();
	}

	public virtual void OELEPKHPFKE()
	{
		base.LFFGKLJMMGF();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.CGKKGILAAPG();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 35f;
				shield.GCAKAFMDFJA(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 1245f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	protected virtual OCCICIIEHEF LLKGHNIJOAN()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("T"), OBNJAIHEJOJ.FulFill);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_PLAYXRANKEDBATTLESTOENTERLEAGUE"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("D2"), (OBNJAIHEJOJ)7);
		}
		if (data.respawnTime > 955f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-12));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CLAIM"), (OBNJAIHEJOJ)5);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("creating special pack: "), (OBNJAIHEJOJ)7);
			}
		}
		else if (data.shieldHP > 974f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player_Had_To_Select_Grenade"), (OBNJAIHEJOJ)6);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Time: "), (OBNJAIHEJOJ)8);
			}
		}
		return base.NNNAKBICOHM();
	}

	public virtual void NHFPIDCJNFI()
	{
		base.ALJKKBMBBFM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.JPHAJDIIAAI();
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 588f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = data.noRespawn;
			if (data.respawnTime > 1100f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool AONAAGJDHOD()
	{
		base.OAELLJPGBPC();
		if (data.shieldHP > 849f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return false;
	}

	public override bool DAHIFNEGKAD()
	{
		base.DAHIFNEGKAD();
		if (data.shieldHP > 703f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	public virtual void BLFJKKHNMDM()
	{
		base.EPDLHJFDJBE();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.MPOAIDJNDFJ();
				shield.maxHealth = 887f;
				shield.ENKDOKELOED(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(data.noRespawn);
			if (data.respawnTime > 584f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	protected virtual OCCICIIEHEF DJHPDCMGPOO()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("thumbnailLittle"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-assignments-type-cards"), (OBNJAIHEJOJ)8);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("WarsEvaluation"), (OBNJAIHEJOJ)6);
		}
		if (data.respawnTime > 838f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowMaxShow);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("D2"), (OBNJAIHEJOJ)6);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Directory \"{0}\" does not exists"), (OBNJAIHEJOJ)7);
			}
		}
		else if (data.shieldHP > 1577f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.UnlockLevel).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("MegaReward"), OBNJAIHEJOJ.InfoText);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("()Lcom/google/android/gms/common/api/PendingResult;"), (OBNJAIHEJOJ)4);
			}
		}
		return base.NNNAKBICOHM();
	}

	public virtual bool OCOLAMMPOBP()
	{
		base.KJDMOCMBFLJ();
		if (data.shieldHP > 161f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public virtual bool CBKMENJEBDP()
	{
		base.KFJLPGPAAAN();
		if (data.shieldHP > 1019f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return false;
	}

	public virtual bool OELICGFDFHL()
	{
		base.FGHKBLLKOBL();
		if (data.shieldHP > 1654f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return true;
	}

	public override bool KFJLPGPAAAN()
	{
		base.OAELLJPGBPC();
		if (data.shieldHP > 766f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	public virtual void PCKFMBLPJDJ()
	{
		base.HIHFCANHINM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LMHDAIBCLDP();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 186f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = data.noRespawn;
			if (data.respawnTime > 1237f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool IDGDDLHNCPK()
	{
		base.LPLPANBJDAM();
		if (data.shieldHP > 1657f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	public virtual bool BINOJOIJABK()
	{
		base.LPLPANBJDAM();
		if (data.shieldHP > 1049f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return false;
	}

	public virtual bool PLHBLDABGJA()
	{
		base.MPNDBIBDOCD();
		if (data.shieldHP > 426f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	public virtual void PCIBDBANCCG()
	{
		base.JNEGPCHLGKD();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.KJCHIHLJMMF();
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 940f;
				shield.ENKDOKELOED(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = data.noRespawn;
			if (data.respawnTime > 418f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool MMCGGCFABAJ()
	{
		base.EKMMLNKADIL();
		if (data.shieldHP > 873f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	public virtual bool BLNECEIFKPL()
	{
		base.EKMMLNKADIL();
		if (data.shieldHP > 1002f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public virtual bool HDMOKMJDBHE()
	{
		base.LPLPANBJDAM();
		if (data.shieldHP > 1517f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	protected virtual OCCICIIEHEF PDLFODJHMIP()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("No"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_SQUADMEDALSBIG"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("FLOATVALUE"), (OBNJAIHEJOJ)8);
		}
		if (data.respawnTime > 333f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.LapsedPlayerInterval1);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Mission"), (OBNJAIHEJOJ)7);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("nonEliteUnits"), (OBNJAIHEJOJ)7);
			}
		}
		else if (data.shieldHP > 1481f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.UnlockLevel).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SIGN_IN_FAILED"), (OBNJAIHEJOJ)4);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("LevelExperience"), OBNJAIHEJOJ.FulFill);
			}
		}
		return base.BEDAAOOPNLB();
	}

	protected virtual OCCICIIEHEF GJLFCGNCDMI()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Animation for State: Craft"), (OBNJAIHEJOJ)7);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Gold"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("TiersCompleted"), (OBNJAIHEJOJ)6);
		}
		if (data.respawnTime > 436f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MinLevelForSquadJoinOrCreateReminder);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("506 MENU ARMY SCREEN UPGRADE ACTIVATED"), (OBNJAIHEJOJ)5);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("discount"), (OBNJAIHEJOJ)5);
			}
		}
		else if (data.shieldHP > 1749f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("playerInfo"), (OBNJAIHEJOJ)6);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Made_IAP_Spend"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		return base.IBOOCJPKFLG();
	}

	protected virtual OCCICIIEHEF HAAAHIEENMA()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("game-card-bronze"), (OBNJAIHEJOJ)7);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Squad Member record does not have DatabasePlayer"), (OBNJAIHEJOJ)8);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BS: Update Army Power"), (OBNJAIHEJOJ)4);
		}
		if (data.respawnTime > 1750f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-36));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(")"), (OBNJAIHEJOJ)4);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(","), OBNJAIHEJOJ.FulFill);
			}
		}
		else if (data.shieldHP > 897f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player with playerId {0} doesnt exists ! "), (OBNJAIHEJOJ)5);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Buy_Card_Pack"), OBNJAIHEJOJ.FulFill);
			}
		}
		return base.MFBIPMEKFAF();
	}

	public virtual void FMCCKHKGBDE()
	{
		base.APIJFIPABAO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LHHMNLJKOAO();
			if (data.noShields)
			{
				shield.FFDLJFIOLEI();
				shield.maxHealth = 324f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 504f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public override void GJFHGPMMDEM()
	{
		base.GJFHGPMMDEM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.DestroyShield();
				shield.maxHealth = 0f;
				shield.autoRepair = false;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 0f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void AGBFBBAPEHE()
	{
		base.IBEGGCHBJGC();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 1240f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = data.noRespawn;
			if (data.respawnTime > 957f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool DNOFHFKBJGM()
	{
		base.DJDCOJHOBJP();
		if (data.shieldHP > 1561f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	public virtual void HHHIFDPBLNP()
	{
		base.FBDFHHKIICO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.PHANADCNBFD();
			if (data.noShields)
			{
				shield.KDEEBMLFABC();
				shield.maxHealth = 1168f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(data.noRespawn);
			if (data.respawnTime > 1072f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public override bool EKMMLNKADIL()
	{
		base.EKMMLNKADIL();
		if (data.shieldHP > 0f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public virtual void BGFDEIFJEHF()
	{
		base.APIJFIPABAO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.IGEDGCNJCAP();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 1222f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = data.noRespawn;
			if (data.respawnTime > 1896f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool ICLPAPGALAC()
	{
		base.AKIJBMEBNNC();
		if (data.shieldHP > 1154f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	protected virtual OCCICIIEHEF NGHJABJEBMA()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}"), OBNJAIHEJOJ.InfoText);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Current Full Path: \"{0}\"\n"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_XP"), OBNJAIHEJOJ.FulFill);
		}
		if (data.respawnTime > 253f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackSilverCards);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("null"), (OBNJAIHEJOJ)6);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("player_fire_left"), (OBNJAIHEJOJ)5);
			}
		}
		else if (data.shieldHP > 93f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_OFFERTOOSHORTNAME"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-army-cat-shooter"), (OBNJAIHEJOJ)8);
			}
		}
		return base.IEKDLDACNDI();
	}

	protected virtual OCCICIIEHEF CGLNKNAPHDD()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("weapon"), (OBNJAIHEJOJ)7);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("rejectFriend"), (OBNJAIHEJOJ)8);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("\"{0}\""), (OBNJAIHEJOJ)8);
		}
		if (data.respawnTime > 1745f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MinTimeSinceLastWeaponUpgrade);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_HEROIC"), (OBNJAIHEJOJ)6);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BANDS"), (OBNJAIHEJOJ)8);
			}
		}
		else if (data.shieldHP > 1963f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("VipRewardForDay"), (OBNJAIHEJOJ)7);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Id"), (OBNJAIHEJOJ)6);
			}
		}
		return base.MNMEAAEKAMH();
	}

	public virtual void DGFFIKIFNOK()
	{
		base.ALJKKBMBBFM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LMHDAIBCLDP();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 369f;
				shield.ENKDOKELOED(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(!data.noRespawn);
			if (data.respawnTime > 419f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void FLHOPMCNCJK()
	{
		base.JMLIBCJJOIA();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LHHMNLJKOAO();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 1670f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(!data.noRespawn);
			if (data.respawnTime > 1337f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void APHAJIJDOCG()
	{
		base.ALJKKBMBBFM();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.KJCHIHLJMMF();
			if (data.noShields)
			{
				shield.MPOAIDJNDFJ();
				shield.maxHealth = 108f;
				shield.autoRepair = false;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 708f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void OFMFHAEKFPP()
	{
		base.ANCJEMCFEID();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LMHDAIBCLDP();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 1321f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(!data.noRespawn);
			if (data.respawnTime > 447f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	protected virtual OCCICIIEHEF LAOBHJMHKMO()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Not in editor"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("localPlayerLeaderboard"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Prefabs search finished."), (OBNJAIHEJOJ)5);
		}
		if (data.respawnTime > 476f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.TimeBetweenWeaponUpgradeReminderShown);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("game-elite-debuff3"), (OBNJAIHEJOJ)7);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-army-cat-explosive"), (OBNJAIHEJOJ)6);
			}
		}
		else if (data.shieldHP > 1685f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MinimumMasterFPS).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ReSyncPowerRPC"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_ARENAISOPEN"), (OBNJAIHEJOJ)5);
			}
		}
		return base.EPEIMHECJHK();
	}

	public virtual bool CLFCCEOMHNL()
	{
		base.OEAODGFDMGC();
		if (data.shieldHP > 417f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return false;
	}

	public virtual void KGKGLMPKLGC()
	{
		base.ANCJEMCFEID();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.KJCHIHLJMMF();
			if (data.noShields)
			{
				shield.DestroyShield();
				shield.maxHealth = 997f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(data.noRespawn);
			if (data.respawnTime > 404f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool JFABHCNMGDI()
	{
		base.KJDMOCMBFLJ();
		if (data.shieldHP > 470f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	protected virtual OCCICIIEHEF CCEKCBKLFAH()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Squad name success"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-weaponstats-accuracy"), (OBNJAIHEJOJ)4);
		}
		if (data.respawnTime > 457f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NotificationAllowReward);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0}%"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-sidetab-invite-game"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		else if (data.shieldHP > 1768f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxPositionDiff).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("S"), OBNJAIHEJOJ.FulFill);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CURRENTRANK"), (OBNJAIHEJOJ)5);
			}
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("damage"), (OBNJAIHEJOJ)8);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("A"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("com/google/android/gms/common/ConnectionResult"), OBNJAIHEJOJ.FulFill);
		}
		if (data.respawnTime > 433f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowWinsNeed);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Yes_Clicked"), (OBNJAIHEJOJ)5);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player_Avoided_Grenade_On_First_Try"), OBNJAIHEJOJ.InfoText);
			}
		}
		else if (data.shieldHP > 1787f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.UnlockLevel).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Player is in squad "), (OBNJAIHEJOJ)4);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("testingideventtierreward"), OBNJAIHEJOJ.InfoText);
			}
		}
		return base.LMOHCGEPLAH();
	}

	public virtual void AGOIGAJMEAO()
	{
		base.GFJMJLMFPKO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.shield;
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 129f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 1951f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual void NCKLGINLMDP()
	{
		base.APIJFIPABAO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.IGEDGCNJCAP();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 1328f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.GCAKAFMDFJA(!data.noRespawn);
			if (data.respawnTime > 1847f)
			{
				shield.refreshTime = data.respawnTime;
			}
		}
	}

	public virtual bool DHFOKAIJMDN()
	{
		base.DAHIFNEGKAD();
		if (data.shieldHP > 220f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public virtual void DLDDBLFIFMB()
	{
		base.LFFGKLJMMGF();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LMHDAIBCLDP();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 211f;
				shield.ENKDOKELOED(true);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(data.noRespawn);
			if (data.respawnTime > 1962f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public override void IONJNJKPMHK()
	{
		base.ANCJEMCFEID();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.LMHDAIBCLDP();
			if (data.noShields)
			{
				shield.DestroyShield();
				shield.maxHealth = 1494f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = data.noRespawn;
			if (data.respawnTime > 808f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual void FABNAAKKJIK()
	{
		base.GFJMJLMFPKO();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.KJCHIHLJMMF();
			if (data.noShields)
			{
				shield.IEPHIMNBBDO();
				shield.maxHealth = 1561f;
				shield.ENKDOKELOED(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.autoRepair = !data.noRespawn;
			if (data.respawnTime > 1123f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual bool APBHOHLKAAB()
	{
		base.EKMMLNKADIL();
		if (data.shieldHP > 1106f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return true;
	}

	public override bool OEAODGFDMGC()
	{
		base.FGHKBLLKOBL();
		if (data.shieldHP > 389f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OJFEBDLNGID(data.shieldHP);
		}
		return false;
	}

	public virtual bool AKEHNCAPIDE()
	{
		base.FGHKBLLKOBL();
		if (data.shieldHP > 1606f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.OANMFNMNJJO(data.shieldHP);
		}
		return false;
	}

	protected virtual OCCICIIEHEF JGADEDPFGEN()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("[.,]*"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("DogtagPrice"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE"), (OBNJAIHEJOJ)4);
		}
		if (data.respawnTime > 1277f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MinTimeSinceLastWeaponUpgrade);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("TW_Follow"), OBNJAIHEJOJ.FulFill);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Squad was deleted."), (OBNJAIHEJOJ)5);
			}
		}
		else if (data.shieldHP > 1118f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize(")"), OBNJAIHEJOJ.FulFill);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("SetGameObjectCallback"), (OBNJAIHEJOJ)8);
			}
		}
		return base.NNNAKBICOHM();
	}

	public virtual bool OBNNGDGICIK()
	{
		base.MPNDBIBDOCD();
		if (data.shieldHP > 1814f)
		{
			Singleton<GameController>.instance.MBPKLMKBJAB.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	protected virtual OCCICIIEHEF HADBACCEMBP()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("GoldCoefficient"));
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("forceSetUserInSegmentId"));
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("About to show Tutorial for "), (OBNJAIHEJOJ)5);
		}
		if (data.respawnTime > 300f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldPackMaxRarityCardsType);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("reloadTime"), OBNJAIHEJOJ.DoesNotMeet);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("stand_up_crawl"), (OBNJAIHEJOJ)6);
			}
		}
		else if (data.shieldHP > 1651f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Days_Since_Install"), (OBNJAIHEJOJ)7);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("{0} {1}"));
			}
		}
		return base.LMOHCGEPLAH();
	}

	protected virtual OCCICIIEHEF BAKBCBLHAJA()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("HELMETS"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Current squad information are not in server cache"), (OBNJAIHEJOJ)5);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Hide reconnect dialog"));
		}
		if (data.respawnTime > 758f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward7);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("RESETING SQUAD WARCARDS"), (OBNJAIHEJOJ)6);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BattleId"), OBNJAIHEJOJ.DoesNotMeet);
			}
		}
		else if (data.shieldHP > 234f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.MaxRegionsiOS).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("These IDs are not used anywhere:\n"), OBNJAIHEJOJ.FulFill);
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_READYTIME"), (OBNJAIHEJOJ)5);
			}
		}
		return base.OOBCHHAGFIO();
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		if (data.immortalShieds)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("Submited: \"{0}\" for player: \"{1}\" rank:{2} AP:{3} and my rank:{4} AP:{5}. Match duration: {6}"), OBNJAIHEJOJ.DoesNotMeet);
		}
		if (data.noShields)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("warbucks"), (OBNJAIHEJOJ)8);
		}
		if (data.noRespawn)
		{
			return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("BatchSizeMin"), OBNJAIHEJOJ.FulFill);
		}
		if (data.respawnTime > 727f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-108));
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("HP"), (OBNJAIHEJOJ)4);
			}
			if (data.respawnTime < (float)num)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED"), OBNJAIHEJOJ.FulFill);
			}
		}
		else if (data.shieldHP > 1834f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("ID_CONFIRM_LEAVESQUADLEADER_TEXT"));
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new OCCICIIEHEF(Colours.stringGreenArena + Localization.Localize("menu-weapon-benelli-starterpack"), (OBNJAIHEJOJ)5);
			}
		}
		return base.NNNAKBICOHM();
	}

	public virtual void KBHPPPIDKAP()
	{
		base.JNEGPCHLGKD();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.PKBPGCGNCAD();
			if (data.noShields)
			{
				shield.OICANEBLGBD();
				shield.maxHealth = 878f;
				shield.autoRepair = true;
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(!data.noRespawn);
			if (data.respawnTime > 1162f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}

	public virtual void IEFGEIGHFKJ()
	{
		base.LFFGKLJMMGF();
		List<MapDefinition.DefendPosition> bBJMLOCKNHD = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD;
		foreach (MapDefinition.DefendPosition item in bBJMLOCKNHD)
		{
			Shield shield = item.point.KJCHIHLJMMF();
			if (data.noShields)
			{
				shield.NNCMDDBFOAJ();
				shield.maxHealth = 1228f;
				shield.GCAKAFMDFJA(false);
				continue;
			}
			shield.isImmortal = data.immortalShieds;
			shield.ENKDOKELOED(data.noRespawn);
			if (data.respawnTime > 210f)
			{
				shield.JMIJDJAAJDH(data.respawnTime);
			}
		}
	}
}
