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

	protected override WarArenaRuleGui GetGenericRule()
	{
		if (data.immortalShieds)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_UNBREAKABLESHIELDS"));
		}
		if (data.noShields)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_NOSHIELDS"));
		}
		if (data.noRespawn)
		{
			return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSDONTRESPAWN"));
		}
		if (data.respawnTime > 0f)
		{
			ConstantsRow row = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldRepairTime);
			int num = (int)(float)row.FLOATVALUE;
			if (data.respawnTime > (float)num)
			{
				return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSRESPAWNSLOWER"));
			}
			if (data.respawnTime < (float)num)
			{
				return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSRESPAWNFASTER"));
			}
		}
		else if (data.shieldHP > 0f)
		{
			ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
			if (data.shieldHP > (float)fLOATVALUE)
			{
				return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSBREAKSLOWER"));
			}
			if (data.shieldHP < (float)fLOATVALUE)
			{
				return new WarArenaRuleGui(Colours.stringGreenArena + Localization.Localize("ID_ARENARULES_SHIELDSBREAKFASTER"));
			}
		}
		return base.GetGenericRule();
	}

	public override bool SetupRule()
	{
		base.SetupRule();
		if (data.shieldHP > 0f)
		{
			Singleton<GameController>.instance.gameControllerWarArena.SetShieldHP(data.shieldHP);
		}
		return true;
	}

	public override void ApplyRule()
	{
		base.ApplyRule();
		List<MapDefinition.DefendPosition> playersPositions = Singleton<MapManager>.instance.currentMapDef.playersPositions;
		foreach (MapDefinition.DefendPosition item in playersPositions)
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
}
