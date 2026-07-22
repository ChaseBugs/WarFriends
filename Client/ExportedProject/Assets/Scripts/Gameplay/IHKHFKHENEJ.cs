using Google2u;
using UnityEngine;

internal class IHKHFKHENEJ : HHFHFANGCEJ
{
	private Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int> HEDMDMKICKE;

	private Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int> JLMIHDNHJOM;

	private string INJIOGNPENB;

	public override void OLECKGKLHCE()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - should not happen");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("BeginnersLeague" + row.VIPSECONDS);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("-" + row.GOLD);
					IGHDBGGFJNN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("/AssetBundles/" + row.GOLDCARDS);
					LJFMFHDGPCN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("null" + row.WARBUCKS);
					MCOODOIPCCP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.FPFEPCDFBCB(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.OEAJBFLGJCA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_OVERTIMEKILL");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("GameReward" + row.VIPSECONDS);
					CBLHOBIJAHC((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("set visual not borrowed" + row.GOLD);
					KFGDGHOCLGE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("GameDataError(" + row.GOLDCARDS);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("+{0}" + row.WARBUCKS);
					IEJEKGGBIFP(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.POPMFPMBHIP(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void DNKJNHALPFG(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void DONHNAIKMCB()
	{
		base.OLECKGKLHCE();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("set acces token: ");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("BeforeLeagueId" + row.VIPSECONDS);
					MBBBMHDIDHN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("WarCards_Screen" + row.GOLD);
					CDPFENAGADD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("ItemRarity_3" + row.GOLDCARDS);
					PLPOKKMKANH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("RETRYPERM" + row.WARBUCKS);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.OGIEPAIBEJJ(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void LONJBMJPJMD(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void IFDIKMKGDPG()
	{
		base.MGKMBCBBOHK();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("VipRewardForDay");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Server send power band reward id {0} which is null setting random {1}" + row.VIPSECONDS);
					IFOOEJBKHOC((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("Saved another leaderboard" + row.GOLD);
					CIOLKEFODOE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("{0}" + row.GOLDCARDS);
					NOFCPEOLOGL(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("FuseRewardedAdOptionKey_ShowPostRoll" + row.WARBUCKS);
					DBOCLIEEFHH((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void KGEEDMONDMK()
	{
		base.KPANLOMNEIG();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Tutorial upgrade unit running \"{0}\"\n");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("ID_WARNING_SERVERTIMEDOUT" + row.VIPSECONDS);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("ID_TONORMALLEAGUEHINT3BRONZE" + row.GOLD);
					PLPOKKMKANH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("ExtraRewards" + row.GOLDCARDS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("{0} {1}" + row.WARBUCKS);
					IGHDBGGFJNN((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.JGJCIEDEBIK(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.OEAJBFLGJCA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Automatic_Equip");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Rank" + row.VIPSECONDS);
					EKKPMNELDAB((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("Area" + row.GOLD);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("{0} {1}{2}" + row.GOLDCARDS);
					MCOODOIPCCP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("VipRewardForDay" + row.WARBUCKS);
					FILOOKAENBL(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.KNOIPLLPMMJ(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void HDKCFAMJBBO()
	{
		base.JPGMEFJGNNA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("http://localhost:8081/");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("ACD: Player prefs were hacked!" + row.VIPSECONDS);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("NULL unit" + row.GOLD);
					JDJOPOENAPP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("stopAutoManage" + row.GOLDCARDS);
					LJFMFHDGPCN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("SquadEventProgress" + row.WARBUCKS);
					LECICKAAHKD(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.IPCIJFBFLHP(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void NFEADFKKCOG()
	{
		base.OLECKGKLHCE();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("BoobyTrapSetRPC");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("ID_STAT_BESTWLRATIO" + row.VIPSECONDS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("ID_VALUEPACKINFORMATIONS" + row.GOLD);
					DCPHOFANMKH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("ID_READYTIME" + row.GOLDCARDS);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("playerVisuals" + row.WARBUCKS);
					IGHDBGGFJNN((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.FNGFBKPACAN(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void OHJAAIJDAAG()
	{
		base.OLECKGKLHCE();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("#DEBUG_50# ");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Internet off: {0} {1}" + row.VIPSECONDS);
					HIOKNJCBEGM((WelcomeBackSoldierDialog.PDPNFKKEKLO)6, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("Configarations enviromend changed, saved: {0}, current {1}" + row.GOLD);
					CBLHOBIJAHC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("Finished" + row.GOLDCARDS);
					FILOOKAENBL(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("ID_LEAGUE12" + row.WARBUCKS);
					AGNDNMFMBLA(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.FNGFBKPACAN(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void MNLAIHAPJOA()
	{
		base.OEAJBFLGJCA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("' not found!");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Rank" + row.VIPSECONDS);
					FCJHCGHMCOM((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("DeliveryTime" + row.GOLD);
					HIOKNJCBEGM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("Parachuter" + row.GOLDCARDS);
					JDJOPOENAPP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("ObjectPool" + row.WARBUCKS);
					FILOOKAENBL((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.DBHIAKAOBDL(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void EEBNPGOCKFD()
	{
		base.GEKIMGFKNHC();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("{0}{1} / {2}");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("With" + row.VIPSECONDS);
					ANFINJJCOKB((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("CardId" + row.GOLD);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("AcceptedFromRequest" + row.GOLDCARDS);
					DBOCLIEEFHH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("INTERNAL_ERROR" + row.WARBUCKS);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void GCLFBCIKNAH()
	{
		base.KPANLOMNEIG();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Map Loaded");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("gold" + row.VIPSECONDS);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("menu-army-upgradebar" + row.GOLD);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("ID_GUI_BRONZE" + row.GOLDCARDS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("Predefined_Assignment_Completed" + row.WARBUCKS);
					LECICKAAHKD((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.KNOIPLLPMMJ(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void IFOOEJBKHOC(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void KFGDGHOCLGE(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void BELBLFGCCLJ()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_CONFIRM_GAMELAREADYENDED");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("menu-weaponstats-totalammo" + row.VIPSECONDS);
					NKPKDKKPJPB((WelcomeBackSoldierDialog.PDPNFKKEKLO)8, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("bot" + row.GOLD);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("Video {0} \"{1}\" has wrong order {2}" + row.GOLDCARDS);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("Yes_Clicked" + row.WARBUCKS);
					LECICKAAHKD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.DBHIAKAOBDL(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void NKPKDKKPJPB(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void PEBHGOMEKME()
	{
		base.GEKIMGFKNHC();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Error: Could not start game ");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Spend_Warbucks_On_Army" + row.VIPSECONDS);
					HLPAFDMGBIF((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("ID_SLOTUPGRADE_POWER" + row.GOLD);
					JDJOPOENAPP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("N" + row.GOLDCARDS);
					DNKJNHALPFG(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("ID_TUTORIAL_GO_BUY_ARMY_3" + row.WARBUCKS);
					LJFMFHDGPCN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.PNAFICLOFAB(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void DCPHOFANMKH(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void MCOODOIPCCP(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void CIOLKEFODOE(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void JDJOPOENAPP(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void CDPFENAGADD(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void BPCMBFNFMOP()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("INTERRUPTED");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("BotManager: Setting bot for death match: {0}  {1} Name random: {2}, IsInSquad {3} " + row.VIPSECONDS);
					PLPOKKMKANH((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("ReportedPlayerId" + row.GOLD);
					CBLHOBIJAHC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log(" bonusIcon:" + row.GOLDCARDS);
					MBGBDNOLFKM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("Warbucks" + row.WARBUCKS);
					LECICKAAHKD(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void DEKLNBDGOML()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_FREEPERCENT");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Got " + row.VIPSECONDS);
					HIOKNJCBEGM((WelcomeBackSoldierDialog.PDPNFKKEKLO)8, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("Found starting warbucks currency = " + row.GOLD);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("JA" + row.GOLDCARDS);
					MCOODOIPCCP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("special" + row.WARBUCKS);
					EKKPMNELDAB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.KNOIPLLPMMJ(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void LJFMFHDGPCN(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void GGHDIAFACAH()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("#account# logged to gpgs result {0}");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("ID_FEATURE_RATE-FANCY" + row.VIPSECONDS);
					LJFMFHDGPCN((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("There is no definition for card {0}" + row.GOLD);
					LECICKAAHKD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("{0:D2}:{1:D2}:{2:D2}" + row.GOLDCARDS);
					NOFCPEOLOGL(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("Set active weapon" + row.WARBUCKS);
					DBOCLIEEFHH((WelcomeBackSoldierDialog.PDPNFKKEKLO)6, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.DBHIAKAOBDL(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void KHCIMEFCJFC()
	{
		base.JPGMEFJGNNA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Get full squad id = ");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("07" + row.VIPSECONDS);
					HCJFBHIIMEE(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("." + row.GOLD);
					EKKPMNELDAB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("facebook init!!! " + row.GOLDCARDS);
					HIOKNJCBEGM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("Grenade_Throwing_Tutorial_Duration" + row.WARBUCKS);
					JDJOPOENAPP((WelcomeBackSoldierDialog.PDPNFKKEKLO)6, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.POPMFPMBHIP(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void NKKBKBJDGDJ()
	{
		base.LEJEDFACEGP();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_INSTANTBATTLEHINT4");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("Accept_Rental" + row.VIPSECONDS);
					KFGDGHOCLGE(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("unregisterConnectionFailedListener" + row.GOLD);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("CONFIRM" + row.GOLDCARDS);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("ID_UPGRADESMALL" + row.WARBUCKS);
					KFGDGHOCLGE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.IPCIJFBFLHP(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void LECICKAAHKD(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void AEHBKBBILPB()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Buy_Player_Customizations_Gold");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("bad card visuals for" + row.VIPSECONDS);
					PLPOKKMKANH((WelcomeBackSoldierDialog.PDPNFKKEKLO)8, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("+" + row.GOLD);
					MBBBMHDIDHN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("  {1}x{0} ( {3} ) doubled for: {2}" + row.GOLDCARDS);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("resizing texture " + row.WARBUCKS);
					HLPAFDMGBIF((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.NFFOFBDCHMF(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public IHKHFKHENEJ(string KJBPJOMHNKB)
		: base($"WelcomeBackSoldierMessage {KJBPJOMHNKB} {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", NKHJBLBAAEB.WelcomBackSoldierMessage)
	{
		INJIOGNPENB = KJBPJOMHNKB;
		Debug.Log("ABOUT TO SHOW WELCOME BACK SOLDIER REWARDS, packId = " + KJBPJOMHNKB);
	}

	private void HLPAFDMGBIF(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void IGHDBGGFJNN(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void KCFDJIOMMNC()
	{
		base.GEKIMGFKNHC();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("Spend_Gold_On_Army" + row.VIPSECONDS);
					HIOKNJCBEGM(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("ItemsOwned_Rarity_2" + row.GOLD);
					MCOODOIPCCP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("com/google/android/gms/common/ConnectionResult" + row.GOLDCARDS);
					CBLHOBIJAHC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("YES" + row.WARBUCKS);
					KFGDGHOCLGE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.NFFOFBDCHMF(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void CBLHOBIJAHC(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void PLPOKKMKANH(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void FILOOKAENBL(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void LCCEEAMLHDD()
	{
		base.OEAJBFLGJCA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("BeanstalkServerManager.PlayerDataWasLoaded - DONE (coroutines)");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("Assignment_" + row.VIPSECONDS);
					AGNDNMFMBLA(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("Clicked buy on " + row.GOLD);
					NKPKDKKPJPB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("ID_ARENARULES_UNLIMITEDAMMO" + row.GOLDCARDS);
					MCOODOIPCCP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("menu-warbucks" + row.WARBUCKS);
					NKPKDKKPJPB((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.PNAFICLOFAB(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void EMHGOECGAFL()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Dron could not be spawned");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("PARCELABLE_WRITE_RETURN_VALUE" + row.VIPSECONDS);
					MBGBDNOLFKM((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("rotateColliderName" + row.GOLD);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("percent" + row.GOLDCARDS);
					EKKPMNELDAB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log(" (ID:" + row.WARBUCKS);
					DNKJNHALPFG((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.GONOICLIMKO(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void DEJLDNONEHN(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void IEJEKGGBIFP(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void DBOCLIEEFHH(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public override void LOFMDBHAFAO()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Different actual league Id \"{0}\" and database message - league entered - league id \"{1}\"");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("ID_GUI_EQUIPPED" + row.VIPSECONDS);
					CBLHOBIJAHC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("country-greece" + row.GOLD);
					LONJBMJPJMD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("game-card-ico-shieldgenerator" + row.GOLDCARDS);
					LONJBMJPJMD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("{0} {1}" + row.WARBUCKS);
					DBOCLIEEFHH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.CMOEFABLABI(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void PHEFLAHPMDH()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("[");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("InventoryData" + row.VIPSECONDS);
					IGHDBGGFJNN((WelcomeBackSoldierDialog.PDPNFKKEKLO)8, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("DOWNLOADBTN" + row.GOLD);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("LeagueId" + row.GOLDCARDS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("Message Manager: Removing message, id = " + row.WARBUCKS);
					DBOCLIEEFHH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.IPCIJFBFLHP(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void IJPAEHAGPFK()
	{
		base.OLECKGKLHCE();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Id");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("Checker" + row.VIPSECONDS);
					IGHDBGGFJNN((WelcomeBackSoldierDialog.PDPNFKKEKLO)6, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("weaponprice" + row.GOLD);
					MBGBDNOLFKM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("{0} {1}" + row.GOLDCARDS);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("Not sending error to database!!" + row.WARBUCKS);
					HLPAFDMGBIF(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.NFFOFBDCHMF(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void BBJADAJPJHH()
	{
		base.LEJEDFACEGP();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_WARSHOP_LOOTBOXES");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("DevelopmentSvk" + row.VIPSECONDS);
					IEJEKGGBIFP((WelcomeBackSoldierDialog.PDPNFKKEKLO)4, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("Action " + row.GOLD);
					CIOLKEFODOE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("decal not found in sheet: " + row.GOLDCARDS);
					CIOLKEFODOE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("ID_CONFIRM_ERROR" + row.WARBUCKS);
					NKPKDKKPJPB((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.DBHIAKAOBDL(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void MIGAJINCHAH()
	{
		base.KPANLOMNEIG();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("LootboxType");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("#Swipe failed, distance threshold condition" + row.VIPSECONDS);
					IGHDBGGFJNN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("elite" + row.GOLD);
					NOFCPEOLOGL(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("BeforeLeagueId" + row.GOLDCARDS);
					DBOCLIEEFHH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("ERNEUT VERSUCHEN" + row.WARBUCKS);
					IEJEKGGBIFP(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.FPFEPCDFBCB(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void MBGBDNOLFKM(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void AHHCFAIJCAE()
	{
		base.LEJEDFACEGP();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("{0}{1}[-] / {2}");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("weapons" + row.VIPSECONDS);
					CDPFENAGADD(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("Gold" + row.GOLD);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("25" + row.GOLDCARDS);
					DCPHOFANMKH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("ID_CONFIRM_ERROR" + row.WARBUCKS);
					AGNDNMFMBLA((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.POPMFPMBHIP(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void LBHAHNFALLB()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_BATTLEWINBONUSFALLSTO");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("SpawnForCardRPC" + row.VIPSECONDS);
					MCOODOIPCCP((WelcomeBackSoldierDialog.PDPNFKKEKLO)8, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("S" + row.GOLD);
					FCJHCGHMCOM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("877" + row.GOLDCARDS);
					CIOLKEFODOE(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("#VOJTA# WAR ARENA CONFIG RECEIVED! Id = " + row.WARBUCKS);
					MBBBMHDIDHN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void HIOKNJCBEGM(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void AGNDNMFMBLA(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void BHGDOHCBGEC()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("ID_BATTLEWINBONUSFALLSTO");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("ID_OVERALL" + row.VIPSECONDS);
					IFOOEJBKHOC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("War_Ranked_Battle" + row.GOLD);
					DNKJNHALPFG(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("Warfriends" + row.GOLDCARDS);
					IFOOEJBKHOC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("ID_GUI_EQUIPPED" + row.WARBUCKS);
					DNKJNHALPFG(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.DBHIAKAOBDL(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void BJGDGMDOKLH()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Special pack content: type: {0} id: {1}{2}");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("ID_CONFIRM_ERROR" + row.VIPSECONDS);
					PLPOKKMKANH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("[" + row.GOLD);
					MBGBDNOLFKM(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("country-slovakia" + row.GOLDCARDS);
					EKKPMNELDAB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("logout from FB" + row.WARBUCKS);
					IEJEKGGBIFP(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.EBELHKPCLBI(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void GLMKGLKCDAL()
	{
		base.LEJEDFACEGP();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("-");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("'veteranpack'0" + row.VIPSECONDS);
					IFOOEJBKHOC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("purchaseToken" + row.GOLD);
					NKPKDKKPJPB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("ID_SQUADMEDALS" + row.GOLDCARDS);
					PLPOKKMKANH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("Location" + row.WARBUCKS);
					MBBBMHDIDHN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.NFFOFBDCHMF(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void GKKFPJHEEDG()
	{
		base.OBJEMJHBJFO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("_N");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log(" was not found in Notification Center to remove" + row.VIPSECONDS);
					NOFCPEOLOGL((WelcomeBackSoldierDialog.PDPNFKKEKLO)8, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("ID_AVAILABLE" + row.GOLD);
					HLPAFDMGBIF(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("Warbucks" + row.GOLDCARDS);
					IGHDBGGFJNN(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("ID_SQUADREWARDGET" + row.WARBUCKS);
					PLPOKKMKANH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.DBHIAKAOBDL(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("Found Pack Id");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("Pack: Vip " + row.VIPSECONDS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 0)
				{
					Debug.Log("Pack: Gold " + row.GOLD);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("Pack: Gold Cards " + row.GOLDCARDS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("Pack: Warbucks " + row.WARBUCKS);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Warbucks, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void MBBBMHDIDHN(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public override void KPANLOMNEIG()
	{
		base.MGKMBCBBOHK();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("): ");
				if (row.VIPSECONDS > 0)
				{
					Debug.Log("ID_GETITCHEAPERNOW" + row.VIPSECONDS);
					NOFCPEOLOGL((WelcomeBackSoldierDialog.PDPNFKKEKLO)6, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("ID_READYTIME" + row.GOLD);
					ENNHBLOALFC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log("*.cs" + row.GOLDCARDS);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("ID_READYTIME" + row.WARBUCKS);
					LONJBMJPJMD((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.ShowDialog(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void EKKPMNELDAB(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	private void NOFCPEOLOGL(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}

	public virtual void KHJGCKMOFBE()
	{
		base.MGKMBCBBOHK();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log(" = ");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("ShotFrequencyMaxCannon" + row.VIPSECONDS);
					IEJEKGGBIFP(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("ROTATED!!! " + row.GOLD);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log(", databaseType= " + row.GOLDCARDS);
					EANNHHJBPID(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("ID_JOINASQUAD" + row.WARBUCKS);
					FILOOKAENBL((WelcomeBackSoldierDialog.PDPNFKKEKLO)5, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.GONOICLIMKO(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void DPDNJFAKNCM()
	{
		base.LOFMDBHAFAO();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("setFacebookEventLogging");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("ID_SALEPERCENTLINE" + row.VIPSECONDS);
					NOFCPEOLOGL(WelcomeBackSoldierDialog.PDPNFKKEKLO.VIP, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("Gold" + row.GOLD);
					CBLHOBIJAHC(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLD);
				}
				if (row.GOLDCARDS > 0)
				{
					Debug.Log("OnRestartDrawing" + row.GOLDCARDS);
					DBOCLIEEFHH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 1)
				{
					Debug.Log("country-new-zealand" + row.WARBUCKS);
					LONJBMJPJMD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.FNGFBKPACAN(HEDMDMKICKE, JLMIHDNHJOM);
	}

	public virtual void DJNMPLKPENF()
	{
		base.JPGMEFJGNNA();
		Packs packDefinition = Singleton<BeanstalkServerManager>.instance.packDefinition;
		foreach (PacksRow row in packDefinition.Rows)
		{
			if (row.NAME == INJIOGNPENB)
			{
				Debug.Log("確認");
				if (row.VIPSECONDS > 1)
				{
					Debug.Log("BUDDY WARCARD" + row.VIPSECONDS);
					LJFMFHDGPCN((WelcomeBackSoldierDialog.PDPNFKKEKLO)7, row.VIPSECONDS);
				}
				if (row.GOLD > 1)
				{
					Debug.Log("GoldenSuitcase" + row.GOLD);
					ANFINJJCOKB(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.GOLD);
				}
				if (row.GOLDCARDS > 1)
				{
					Debug.Log(" 3" + row.GOLDCARDS);
					DCPHOFANMKH(WelcomeBackSoldierDialog.PDPNFKKEKLO.Gold, row.GOLDCARDS);
				}
				if (row.WARBUCKS > 0)
				{
					Debug.Log("Device UNPAUSED at {0}" + row.WARBUCKS);
					LONJBMJPJMD(WelcomeBackSoldierDialog.PDPNFKKEKLO.Cards, row.WARBUCKS);
				}
			}
		}
		GuiElementSingle<WelcomeBackSoldierDialog>.instance.GONOICLIMKO(HEDMDMKICKE, JLMIHDNHJOM);
	}

	private void HCJFBHIIMEE(WelcomeBackSoldierDialog.PDPNFKKEKLO FJLBLLLEELD, int ICLNCDGCCJN)
	{
		if (HEDMDMKICKE == null)
		{
			HEDMDMKICKE = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
		else
		{
			JLMIHDNHJOM = new Tuple<WelcomeBackSoldierDialog.PDPNFKKEKLO, int>(FJLBLLLEELD, ICLNCDGCCJN);
		}
	}
}
