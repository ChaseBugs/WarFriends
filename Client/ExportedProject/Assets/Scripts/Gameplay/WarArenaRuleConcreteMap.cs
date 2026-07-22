using System;
using UnityEngine;

[CreateAssetMenu(fileName = "WarArenaRuleConcreteMap", menuName = "War Arena Rules/War Arena Concrete Map", order = int.MaxValue)]
public class WarArenaRuleConcreteMap : WarArenaRuleGeneric<WarArenaRuleConcreteMap.Data>
{
	[Serializable]
	public class Data : RuleData
	{
		[Popup(new string[] { "Desert", "Snow", "California", "Jungle", "Park" })]
		public string mapName = "Desert";
	}

	public virtual bool LCLHBPOHONI()
	{
		Singleton<MapManager>.instance.COJNIMNIPEE(data.mapName);
		return base.FGHKBLLKOBL();
	}

	protected virtual OCCICIIEHEF DHPHFLPNOGC()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "War_Battle_Mode", (OBNJAIHEJOJ)4);
	}

	public virtual bool DANEHBKOOGF()
	{
		Singleton<MapManager>.instance.SelectCurrentMap(data.mapName);
		return base.AIMGMMCHEIO();
	}

	protected virtual OCCICIIEHEF CCHDCMOJNFP()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "Gold", OBNJAIHEJOJ.DoesNotMeet);
	}

	public virtual bool JIBFELAHJDE()
	{
		Singleton<MapManager>.instance.SelectCurrentMap(data.mapName);
		return base.OEAODGFDMGC();
	}

	protected override OCCICIIEHEF OHFBLDPINHI()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "WarArenaRuleConcreteMap");
	}

	public virtual bool KJBLKMDHJMC()
	{
		Singleton<MapManager>.instance.HFGBJBMGAMP(data.mapName);
		return base.NMPPLCHLCDK();
	}

	public virtual bool KOHMDOHKMIH()
	{
		Singleton<MapManager>.instance.MEBGOMOFCJF(data.mapName);
		return base.EDNAIMPLPGL();
	}

	public virtual bool DFPDACAGFPO()
	{
		Singleton<MapManager>.instance.MEBGOMOFCJF(data.mapName);
		return base.AKIJBMEBNNC();
	}

	protected virtual OCCICIIEHEF KNLNGNJEBMP()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "ID_WARNING_INCORRECTVALUESONCLIENT", (OBNJAIHEJOJ)6);
	}

	public virtual bool NAFCNBIPEKM()
	{
		Singleton<MapManager>.instance.SelectCurrentMap(data.mapName);
		return base.AIMGMMCHEIO();
	}

	public override bool EKMMLNKADIL()
	{
		Singleton<MapManager>.instance.SelectCurrentMap(data.mapName);
		return base.EKMMLNKADIL();
	}

	public virtual bool AONAAGJDHOD()
	{
		Singleton<MapManager>.instance.HFGBJBMGAMP(data.mapName);
		return base.AKIJBMEBNNC();
	}

	protected virtual OCCICIIEHEF BAKBCBLHAJA()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "-[^-]*$", OBNJAIHEJOJ.FulFill);
	}

	protected virtual OCCICIIEHEF GOAGBNMENNN()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "Player ", (OBNJAIHEJOJ)8);
	}

	public virtual bool APBOMMHMLBI()
	{
		Singleton<MapManager>.instance.MEBGOMOFCJF(data.mapName);
		return base.KFJLPGPAAAN();
	}

	protected virtual OCCICIIEHEF MPGOGPEDECJ()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "Winstreak", OBNJAIHEJOJ.FulFill);
	}

	protected virtual OCCICIIEHEF OPLHOAENDAE()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "menu-health-ico", (OBNJAIHEJOJ)6);
	}

	public virtual bool FLMDFNFPLBI()
	{
		Singleton<MapManager>.instance.SelectCurrentMap(data.mapName);
		return base.OEAODGFDMGC();
	}

	public virtual bool OELICGFDFHL()
	{
		Singleton<MapManager>.instance.SelectCurrentMap(data.mapName);
		return base.AKIJBMEBNNC();
	}

	public virtual bool AKEHNCAPIDE()
	{
		Singleton<MapManager>.instance.HFGBJBMGAMP(data.mapName);
		return base.CLPEMLCLDIJ();
	}

	protected virtual OCCICIIEHEF EGPLLIKFDNA()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "WENEEDTO", OBNJAIHEJOJ.InfoText);
	}

	protected virtual OCCICIIEHEF KAHABLJAPEF()
	{
		return new OCCICIIEHEF(Colours.stringGreenArena + "Squad", OBNJAIHEJOJ.FulFill);
	}

	public virtual bool IJPKPGPEDCO()
	{
		Singleton<MapManager>.instance.MEBGOMOFCJF(data.mapName);
		return base.FGHKBLLKOBL();
	}

	public override bool AKIJBMEBNNC()
	{
		Singleton<MapManager>.instance.HFGBJBMGAMP(data.mapName);
		return base.NMPPLCHLCDK();
	}
}
