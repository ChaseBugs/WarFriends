using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EOLJBBIEJHL : HHFHFANGCEJ
{
	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	private static void CLCGGDJAFKG()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private static void EAICNDGNLKC()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private static void MBAKHHIIJKD()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public EOLJBBIEJHL()
		: base($"BuyCardsReminder {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", NKHJBLBAAEB.BuyCardsReminder)
	{
		Debug.Log("About to show Buy Cards Reminder");
	}

	[CompilerGenerated]
	private static void KIGFNOMALGA()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void EEOKJCKNEAL()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ReminderDialog>.instance.ShowDialog(ReminderDialog.NCPDIPMLMJO.WeaponUpgrade, MGHMGLKMAJF);
	}

	private static void OMDJPELKGAL()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void IFDIKMKGDPG()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.HLJFCGLFGOA(ReminderDialog.NCPDIPMLMJO.CardslotViaValuePack, ONBDPCMBMCH);
	}

	public virtual void JBMCFEMBPKE()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.PJLBBBOLGMG(ReminderDialog.NCPDIPMLMJO.UnitUpgrade, MGHMGLKMAJF);
	}

	private static void GADPAPKEJHJ()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private static void HGAMMMNIINF()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private static void MGHMGLKMAJF()
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public override void MGKMBCBBOHK()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ReminderDialog>.instance.CHMIPBJLKIJ(ReminderDialog.NCPDIPMLMJO.Customizations, GADPAPKEJHJ);
	}

	private static void JPFLGMJFFGE()
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void GGHDIAFACAH()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ReminderDialog>.instance.OHJEIGCJCLL(ReminderDialog.NCPDIPMLMJO.TryPowerBand, delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
			GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ReminderDialog>.instance.ShowDialog(ReminderDialog.NCPDIPMLMJO.OfferingCards, delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
			GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	public virtual void ILFJPOOMFDO()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ReminderDialog>.instance.KNOIPLLPMMJ(ReminderDialog.NCPDIPMLMJO.WeaponUpgrade, ONBDPCMBMCH);
	}

	private static void ONBDPCMBMCH()
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void PEBHGOMEKME()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ReminderDialog>.instance.IKJNNOFBFGL(ReminderDialog.NCPDIPMLMJO.UnitUpgrade, ONBDPCMBMCH);
	}
}
