using System.Runtime.CompilerServices;
using UnityEngine;

public class DFAMEADBDFA : HHFHFANGCEJ
{
	private PlayerVisual IIOKFKPMPPK;

	private void LPAKJLOHGHN()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void FDGDLNMICLP()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void BFOPAOLPODG()
	{
		base.KPANLOMNEIG();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("0");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.CCELLMICLOG(IIOKFKPMPPK, GJHKFCIJLIN);
		}
	}

	public virtual void OCHDOJMAGHA()
	{
		base.LOFMDBHAFAO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("ID_ATTACK");
			return;
		}
		GuiElementSingle<ReminderDialog>.instance.PCFLJMDDMGM(IIOKFKPMPPK, delegate
		{
			GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
			GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	public virtual void NLMKCDMBPPC()
	{
		base.OBJEMJHBJFO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("War_Battle_Mode");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.CCELLMICLOG(IIOKFKPMPPK, GONOMKMOOCE);
		}
	}

	private void OPKFAMHCFPM()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public virtual void PLCBOLBMJKA()
	{
		base.OBJEMJHBJFO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("Player_Level_Up");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.CCELLMICLOG(IIOKFKPMPPK, MBAKHHIIJKD);
		}
	}

	private void KIJIPNGGDCJ()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public DFAMEADBDFA(PlayerVisual CCBKHNAIBDH)
		: base("PowerBandBuyReminder", NKHJBLBAAEB.PowerBandBuyAfterLose)
	{
		IIOKFKPMPPK = CCBKHNAIBDH;
		string text = ((CCBKHNAIBDH != null) ? CCBKHNAIBDH.name : "null");
		NHHGDIDEIMM += string.Format(" {0} {1}", text, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		Debug.Log("About to show Buy Power Band Reminder: " + text);
	}

	private void IFMNKMDOOHO()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void ONBDPCMBMCH()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public override void MGKMBCBBOHK()
	{
		base.GEKIMGFKNHC();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("elite");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.PCFLJMDDMGM(IIOKFKPMPPK, LFMGIOIMNCG);
		}
	}

	public virtual void AAHJOEILKNG()
	{
		base.GEKIMGFKNHC();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("key");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, DGIAFLMOPFM);
		}
	}

	public virtual void LDGKPCDJPLA()
	{
		base.OEAJBFLGJCA();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("menu-crown-bronze");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, MBAKHHIIJKD);
		}
	}

	private void FGFMFHGGADH()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void DMLDBKFCACB()
	{
		base.OEAJBFLGJCA();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError(" NOT OK!\t\t\t\t\t\t");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, IGNPEFDJBLL);
		}
	}

	private void OMDJPELKGAL()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void MBAKHHIIJKD()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void MJGLCADCMDG()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void GONOMKMOOCE()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void GLMKGLKCDAL()
	{
		base.GEKIMGFKNHC();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("id");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, IFMNKMDOOHO);
		}
	}

	public virtual void HONPFADFFDP()
	{
		base.LOFMDBHAFAO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("Starter Assignments Reward Dialog show");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.CCELLMICLOG(IIOKFKPMPPK, DEMHFGKGCHL);
		}
	}

	private void OPJFNNNOJKF()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void KDKCHJGEBIJ()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void LGIMICBFCHD()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void FCANLIOLJNH()
	{
		base.OLECKGKLHCE();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("[-]");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, IGNPEFDJBLL);
		}
	}

	private void DGGMLOIAPHF()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void EPHMECKBGAA()
	{
		base.OEAJBFLGJCA();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError(", response: ");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, LFMGIOIMNCG);
		}
	}

	public virtual void CBBLGFEBJID()
	{
		base.GEKIMGFKNHC();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("PNManager: Scheduling Crafting Finished Notification in ");
			return;
		}
		GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, delegate
		{
			GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
			GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	private void AFDBHBCPDJH()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void FAFEGBECEEM()
	{
		base.LEJEDFACEGP();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("ID_LEAVINGSQUAD");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, LGIMICBFCHD);
		}
	}

	private void DEMHFGKGCHL()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void JCJFMHGNIOF()
	{
		base.MGKMBCBBOHK();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("didSessionStartFromTunePush");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, LGIMICBFCHD);
		}
	}

	public virtual void ILFJPOOMFDO()
	{
		base.OLECKGKLHCE();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("WarBucks");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, AFDBHBCPDJH);
		}
	}

	private void IGNPEFDJBLL()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void DLNGGGOEDLL()
	{
		base.OBJEMJHBJFO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("ID_GUI_EQUIPPED");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.CCELLMICLOG(IIOKFKPMPPK, LFMGIOIMNCG);
		}
	}

	public virtual void PHEFLAHPMDH()
	{
		base.OBJEMJHBJFO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("Overtime_Was_Already_Explained");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, LPAKJLOHGHN);
		}
	}

	public virtual void KCFDJIOMMNC()
	{
		base.LOFMDBHAFAO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("DogtagsRefillRankUp");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.PCFLJMDDMGM(IIOKFKPMPPK, LPAKJLOHGHN);
		}
	}

	public virtual void JBMCFEMBPKE()
	{
		base.JPGMEFJGNNA();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("ID_STAT_BATTLESPLAYED");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, FGFMFHGGADH);
		}
	}

	[CompilerGenerated]
	private void KIGFNOMALGA()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("No power band to show in reminder!!!");
			return;
		}
		GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, delegate
		{
			GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
			GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		});
	}

	public virtual void GKKFPJHEEDG()
	{
		base.MGKMBCBBOHK();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("clearAllCustomProfileVariables");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.PCFLJMDDMGM(IIOKFKPMPPK, GJHKFCIJLIN);
		}
	}

	private void GJHKFCIJLIN()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	private void OPBIDMFFLEE()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void NFEADFKKCOG()
	{
		base.OEAJBFLGJCA();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("game-card-ico-disarmed");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.ShowVisualDialog(IIOKFKPMPPK, DGIAFLMOPFM);
		}
	}

	private void DGIAFLMOPFM()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void LFMGIOIMNCG()
	{
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(IIOKFKPMPPK);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	public virtual void DFJBBKKIPAD()
	{
		base.MGKMBCBBOHK();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("ID_WARNING_LOGINERROR");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, OMDJPELKGAL);
		}
	}

	public virtual void BIIHCAEKCOD()
	{
		base.MGKMBCBBOHK();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, OPJFNNNOJKF);
		}
	}

	public virtual void PEBHGOMEKME()
	{
		base.LOFMDBHAFAO();
		if (IIOKFKPMPPK == null)
		{
			Debug.LogError("MadeIApp");
		}
		else
		{
			GuiElementSingle<ReminderDialog>.instance.OOIELNLIJEK(IIOKFKPMPPK, MBAKHHIIJKD);
		}
	}
}
