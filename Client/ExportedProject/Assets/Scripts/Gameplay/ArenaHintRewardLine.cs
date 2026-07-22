using Google2u;
using UnityEngine;

public class ArenaHintRewardLine : Core_BaseScript
{
	public enum AEMBEAHLAKB
	{
		EliteParts,
		ArenaTickets,
		Scraps,
		Gold,
		WarBucks
	}

	[SerializeField]
	[Header("Core")]
	private UILabel textLabel;

	public bool NDIJBPIDGOF(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[5];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_AWESOME", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[2];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("Shots_Fired", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[5];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("Gold", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("getStatusMessage", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() > 0 || OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[3];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[8] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("menu-arena-scrap-ico", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(574f - (float)DFHAAIFFLOE * 343f);
		return flag;
	}

	public bool KOABMGAPCKP(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("payloadKeys", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[5];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("FuseBox Event DuplicateLootbox for {0}", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("squadsFromLeague", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN), null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX), null, null, null, null);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[0];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("FormerFullLeagueId", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.ADNHAHAKCLF() <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[5];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("BattleWarbucksRewards", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1492f - (float)DFHAAIFFLOE * 42f);
		return flag;
	}

	public bool OJJHCFFEFGI(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[1];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_READYTIME", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[5];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_READYTIME", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[3];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("SpawningManagerMultiplayer.prefab", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[0] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_CONFIRM_SQUADISALREADYFULL", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.ADNHAHAKCLF() <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[0];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("GameLauncher.LoadMainScene", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(803f - (float)DFHAAIFFLOE * 170f);
		return flag;
	}

	public bool PPLIBOAJOCA(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 1 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[8];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("League", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[6];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("Weapon_Upgrade", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[1];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("\n", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[1];
				array4[0] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("Set false", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 1 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[2];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array5[5] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("N", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(54f - (float)DFHAAIFFLOE * 519f);
		return flag;
	}

	public bool HBDEPMJNLEK(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[6];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("Medals/", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("1", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN), null, null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX), null);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[6];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("fuseData", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("Buy_Player_Customizations_Warbucks", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX), null, null, null);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 1 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[7];
				array3[0] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel3.text = Localization.LocalizeFormat("weapon", array3);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1689f - (float)DFHAAIFFLOE * 732f);
		return flag;
	}

	public bool AMFDNBJBPLB(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[5];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("country-italy", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[6];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("PhotonConnectionManager: Disconnect", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[0];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("No main position was set in map definition", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[3];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("Squad", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.OJKIFGCDPAO() > 0 || OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[0];
				array5[1] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[4] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("clearAllCustomProfileVariables", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(272f - (float)DFHAAIFFLOE * 965f);
		return flag;
	}

	public bool OAMBDKHLJKI(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_MISSION_SURVIVE_HUD", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ERROR_SQUADNAMENOTUNIQUE", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX), null, null, null, null);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[8];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("Warp - can not find random point - returning agent destination", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[4];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("HK", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[1];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OJKIFGCDPAO());
				array4[5] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("playerId", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1018f - (float)DFHAAIFFLOE * 1731f);
		return flag;
	}

	public bool OMGCKCFKDJM(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[6];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("warbucks initialized", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[8];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("FuseRewardedOptionKey_PreRollNoButtonText", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[2];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("PH", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("PromotedPlayerId", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[1];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OJKIFGCDPAO());
				array5[2] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("com/google/android/gms/games/Games", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1847f - (float)DFHAAIFFLOE * 1309f);
		return flag;
	}

	public bool HGGFDJOFNMM(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[7];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_UPGRADESMALL", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_UNIT2TRAIN_UNIT1BUY", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX), null, null, null, null);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[8];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_GUI_EQUIPPED", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[3];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("-", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.LDMPACAEGPI() <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[6];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array4[7] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel4.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANK", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(510f - (float)DFHAAIFFLOE * 1993f);
		return flag;
	}

	public bool HIHAFDPJPKC(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[2];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_SQUADEVENT", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[0];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("heatTime", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[3];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("WarFriends", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[6];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("Shots_Fired", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() > 1 || OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat(", playerGold1 = ", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC()), null, null, MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG()), null, null);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1489f - (float)DFHAAIFFLOE * 1245f);
		return flag;
	}

	public bool DPFKOFFMNPC(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ONETICKET", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN), null, null, null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX), null, null);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[6];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel.text = Localization.LocalizeFormat("menu-army-cat-explosive", array);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[2];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_VISUALCATEGORYPART0", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 1 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[2];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("否", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = OPCIFLNBJLI.OJKIFGCDPAO() > 1 || OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[8];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("Card ", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(551f - (float)DFHAAIFFLOE * 1359f);
		return flag;
	}

	public bool PALKDIAONDP(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[0];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("tc", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_ELITEPACK_VIPDESCRIPTION", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.OJKIFGCDPAO() > 0 || OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[8];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array5[4] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("StartOverTime_RPC", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(753f - (float)DFHAAIFFLOE * 1903f);
		return flag;
	}

	public bool PJICLEMEBID(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[1];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("LowLevel", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[7];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ElitePackId", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[7];
				array3[0] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("menu-squadpoint-ico", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[2];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_ZEROSECONDS", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() > 0 || OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[8];
				array5[0] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.HGIPNABHLGE());
				array5[8] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("ID_ARENARARITY", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(562f - (float)DFHAAIFFLOE * 221f);
		return flag;
	}

	public bool PEIPCPICOIK(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[7];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("#account# logged to facebook result {0}", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[7];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("Message Manager: Removing message, id = ", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("ID_READYTIME", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("AdminLevel", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = OPCIFLNBJLI.HGIPNABHLGE() <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[0];
				array5[0] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("ID_RENTAL_ASSAULTRIFLE", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(229f - (float)DFHAAIFFLOE * 875f);
		return flag;
	}

	public bool MPFPHNBAIKD(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[4];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("Different names \"{0}\" and \"{1}\"\n", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[4];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("grenadeExplosion", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[8];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("\t\"FALSE\"", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[2];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("212 MENU LEVEL UP SHOWN", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 0 && OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[3];
				array5[1] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array5[3] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("Please add object to pool, before instanciing it ::: prefab name = {0}", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(576f - (float)DFHAAIFFLOE * 1716f);
		return flag;
	}

	public bool AJEGOKKKLOL(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[1];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("-.*$", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[5];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("DOWNLOAD", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[7];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("NZ", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[4];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("SubscriptionBought", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.FOEKFNKBGAC() > 1 || OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[5];
				array5[0] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[5] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("ArmyPower", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1092f - (float)DFHAAIFFLOE * 922f);
		return flag;
	}

	public bool FPPLMOLHGFD(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[0];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("PlayerLevel", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[8];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_WARNING_BADVERSIONERROR_TEXT", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("SquadId", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[7];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_SQUADEVENT", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() <= 0 && OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[3];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.HGIPNABHLGE());
				array5[2] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。許可がないとゲームが機能できず、閉じてしまいます。再試行するか、WarFriendsをやめてください。", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1638f - (float)DFHAAIFFLOE * 897f);
		return flag;
	}

	public bool JMLMMFOCKCN(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[0];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("{0}-{1:D6}", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN), null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX));
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[6];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("data", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 1 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[0] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("unregisterConnectionFailedListener", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() > 0 || OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[7];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ADNHAHAKCLF());
				array4[4] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel4.text = Localization.LocalizeFormat("Wrong_Unit", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(101f - (float)DFHAAIFFLOE * 1895f);
		return flag;
	}

	public bool AFHMOPJGNBM(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[5];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ANDROID: MISSING PACK ", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[3];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("Os", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[0];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("ID_COMPLETEIN", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[3];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("Scenes search finished.\n", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = OPCIFLNBJLI.HGIPNABHLGE() <= 1 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[3];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array5[8] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("StartFlying", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1211f - (float)DFHAAIFFLOE * 329f);
		return flag;
	}

	public bool GGAHNKIKJKD(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 1 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("out of range", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[7];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("silver", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("menu-weaponstats-burstsize", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 1 && arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[8];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat(" ", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = OPCIFLNBJLI.OJKIFGCDPAO() > 1 || OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[1];
				array5[1] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array5[3] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("SquadId", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(34f - (float)DFHAAIFFLOE * 572f);
		return flag;
	}

	public bool DDHCMFLIABO(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[1];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_STAT_MOSTBATTLESPLAYED", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[0];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("On Accept Special Offer", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("ADDING {0} WARCARD/-S FROM CARDPOOL", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[5];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("com.google.android.gms.common.api.GoogleApiClient", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = OPCIFLNBJLI.LDMPACAEGPI() <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[8];
				array5[1] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[5] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("Player_Avoided_Grenade_On_First_Try", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(9f - (float)DFHAAIFFLOE * 45f);
		return flag;
	}

	public bool GOMJAFCDKDD(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 1 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("PlayerWeaponPower", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX));
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[2];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel.text = Localization.LocalizeFormat("Different actual league Id \"{0}\" and database message - league entered - league id \"{1}\"", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[6];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("customFloat", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[0];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("Exception when creating cards for tutorial - creating default instead, msg = ", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = OPCIFLNBJLI.FOEKFNKBGAC() <= 0 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[8];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OJKIFGCDPAO());
				array4[6] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("Buy_Weapon_Upgrade_At_Rank", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(410f - (float)DFHAAIFFLOE * 258f);
		return flag;
	}

	public bool BDMNPDBOCGN(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("{0}{1}[-] {2}/[-] 3", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[6];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("setFacebookEventLogging", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[3];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("VipReward1", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[3];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("no pack name", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[8];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[8] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("ID_PERMANENT", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(817f - (float)DFHAAIFFLOE * 1558f);
		return flag;
	}

	public bool AOAMOJHIAMN(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("Gold:     {0}\n", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN), null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX), null, null);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[4];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel.text = Localization.LocalizeFormat("DamageEventPlayer damage: {0} to {1} new HP {2}", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("menu-armypower-ico", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 1 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat(" set not in league", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("DeathEventPlayer", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI()), MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK), null, null, null);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(840f - (float)DFHAAIFFLOE * 568f);
		return flag;
	}

	public bool GJEEMJNIFFM(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("Game_type", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN), null, null, null, null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX), null);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[0];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel.text = Localization.LocalizeFormat("{0} {1}", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[7];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("id: ", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[1];
				array3[0] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("Wrong_Unit", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[5];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("ID_CONFIRM_DELETESQUAD_TEXT", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(0f - (float)DFHAAIFFLOE * 1764f);
		return flag;
	}

	public bool NEIGIFMCCAE(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[7];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("SpecialOffers", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[8];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("menu-arena-ticket", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[3];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("acceptFriend", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 1 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[5];
				array4[0] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH > 1 || OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[8];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ADNHAHAKCLF());
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("Skillshot {0}", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1441f - (float)DFHAAIFFLOE * 1512f);
		return flag;
	}

	public bool ANMJHOFBIAI(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[7];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("menu-warbucks", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[0];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_WARNING_CANTSENDINVITE", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[2];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("undefined", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[5];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("menu-assignments-bar-red", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = OPCIFLNBJLI.HGIPNABHLGE() <= 1 && OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[4];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ADNHAHAKCLF());
				array5[5] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("WALLET - initialization WB {0}", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1676f - (float)DFHAAIFFLOE * 54f);
		return flag;
	}

	public bool FKBIBACPFJE(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[4];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("Scripts Full Path: \"{0}\"\n", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[0];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("Walk", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("alwaysShittyPerformance", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("These IDs are \"false positive\" for not in dictionary XLS:\n", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN), null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX), null);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() > 1 || OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[3];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OOCAKEIIJFH);
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel4.text = Localization.LocalizeFormat("menu-sidetab-joinedsquad", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1886f - (float)DFHAAIFFLOE * 163f);
		return flag;
	}

	public bool Initialize(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION_ELITEPARTS", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX));
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION_TICKETS", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX));
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION_SCRAPS", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX));
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION_GOLD", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX));
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH > 0 || OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("ID_ARENABOXDESCRIPTION_WARBUCKS", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OOCAKEIIJFH), MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK));
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(90f - (float)DFHAAIFFLOE * 42.5f);
		return flag;
	}

	public bool KOEBOGHPHIA(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat(".e", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("Failed to join room during or after match and MatchManager.isReconnect = FALSE", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN), null, null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX), null, null);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[4];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_CONFIRM_CONNECTTOGOOGLENAMETEXT", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[8];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = OPCIFLNBJLI.OJKIFGCDPAO() > 0 || OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[6];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("The shader ", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1715f - (float)DFHAAIFFLOE * 316f);
		return flag;
	}

	public bool PONFOKHPMMO(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[8];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("CANCELED", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("BUDDY WARCARD", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[7];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("XXd YYh", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("Visual {0}, overcount {1}, duplicate wb {2}\n", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = OPCIFLNBJLI.FOEKFNKBGAC() <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[6];
				array5[1] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ADNHAHAKCLF());
				array5[3] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("VideoFeed", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1143f - (float)DFHAAIFFLOE * 916f);
		return flag;
	}

	public bool CKOIIPAGCNO(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[0];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("country-italy", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_CATEGORY_LOW_SG_EXPLOSIVE", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[5];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("GameLoginManager: Reloging...", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[1];
				array4[0] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[7] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("GUI/", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = OPCIFLNBJLI.OJKIFGCDPAO() <= 1 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[6];
				array5[0] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("FeaturedVideos", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1994f - (float)DFHAAIFFLOE * 670f);
		return flag;
	}

	public bool HEGPFIGACED(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[0];
				array[0] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat(" 1", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[2];
				array2[1] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_BRONZEPACK", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("0", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[8];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("Weapon {0} does not exists on client.", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = OPCIFLNBJLI.HGIPNABHLGE() <= 0 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[0];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ADNHAHAKCLF());
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("ID_CONFIRM_KICKPLAYER_TEXT", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1041f - (float)DFHAAIFFLOE * 1904f);
		return flag;
	}

	public bool OBHPLFFLDBI(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("212 MENU LEVEL UP SHOWN", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[2];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("mortar_up", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[6];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("DOWNLOADBTN", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("{0} {1}", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX), null);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.LDMPACAEGPI() <= 0 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[1];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.LDMPACAEGPI());
				array4[5] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel4.text = Localization.LocalizeFormat("SquadMembers", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(378f - (float)DFHAAIFFLOE * 1616f);
		return flag;
	}

	public bool BENAHCDEKCM(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GPGCNAGPFAM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[4];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_SILVER", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_TUTORIAL_SNIPERSHOOT_UP", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[0];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("SWITCH TO DEATCHMATCH", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[6];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("PARCELABLE_WRITE_RETURN_VALUE", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = OPCIFLNBJLI.ADNHAHAKCLF() > 0 || OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[0];
				array5[0] = Colours.stringGreenArena;
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.HGIPNABHLGE());
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("VIP-SALE-ALL;WEAPON-EXPLOSIVE-SALE", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(750f - (float)DFHAAIFFLOE * 344f);
		return flag;
	}

	public bool PBEFOOADBPG(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[0] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("Error in bot finding position", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("OnAgeVerificationCriteriaNotMet", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[5];
				array3[0] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("menu-event-gift", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[0];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("MineCards", array4);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = OPCIFLNBJLI.HGIPNABHLGE() <= 1 && OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[7];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ADNHAHAKCLF());
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("visuals: {0} {1} {2} {3}", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1053f - (float)DFHAAIFFLOE * 1832f);
		return flag;
	}

	public bool CFIAHPMMJOE(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 1 && arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[7];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_SELECTONEUNIT", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 1 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[8] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("OK", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Scraps)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 0 || arenaLootboxesRow.SCRAPSMAX > 0;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[4];
				array3[1] = Colours.stringGreenArena;
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("ID_CLAIMING", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 1 && arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[5];
				array4[1] = Colours.stringGreenArena;
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_NOTIFICATION_DAILYREWARD_GOLD", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)8)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[2];
				array5[0] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel5.text = Localization.LocalizeFormat("FuseSDK: Parsing error in _AdAvailabilityResponse", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1653f - (float)DFHAAIFFLOE * 1999f);
		return flag;
	}

	public bool GHFHNLNHCFC(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("newHeroicPoints", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN), MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX), null);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 0 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[3];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_INROOKIE2", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[4];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array2[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel2.text = Localization.LocalizeFormat("menu-squadpoint-ico-bw", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.WarBucks)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[4];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array3[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel3.text = Localization.LocalizeFormat("fr-FR", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.Gold)
		{
			flag = OPCIFLNBJLI.OHDDICCMIMB() > 0 || OPCIFLNBJLI.BCALEAFPMHK > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[4];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.FOEKFNKBGAC());
				array4[3] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.ILBGELEJMIG());
				uILabel4.text = Localization.LocalizeFormat("game-revenge-indicator", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1184f - (float)DFHAAIFFLOE * 1669f);
		return flag;
	}

	public bool MFFEFILOKMG(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 0 || arenaLootboxesRow.ELITEPARTSMAX > 0;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[7];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[6] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("ID_TUTORIAL_WARCARDS_STARTUP", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[1];
				array2[0] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("instantBattleAvailable", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 1 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[4];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("SyncTrajectoryRPC", array3);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.GOLDMIN > 0 || arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[3];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("country-noflag", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.OOCAKEIIJFH <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 1;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[7];
				array5[1] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OJKIFGCDPAO());
				array5[7] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1659f - (float)DFHAAIFFLOE * 1095f);
		return flag;
	}

	public bool HCEJNMJHDJN(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = true;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.GKNFEMNEEIM;
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN > 1 || arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[6];
				array[1] = Colours.stringGreenArena;
				array[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("SquadIcons/", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.ArenaTickets)
		{
			flag = arenaLootboxesRow.TICKETSMIN > 1 || arenaLootboxesRow.TICKETSMAX > 1;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[5];
				array2[0] = Colours.stringGreenArena;
				array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT", array2);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.SCRAPSMIN <= 0 && arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[3];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("SkillDifference", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.GOLDMIN <= 0 && arenaLootboxesRow.GOLDMAX > 1;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[8];
				array4[0] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN);
				array4[1] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX);
				uILabel4.text = Localization.LocalizeFormat("ID_BATTLEINARENA", array4);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = OPCIFLNBJLI.FOEKFNKBGAC() > 1 || OPCIFLNBJLI.BCALEAFPMHK > 0;
			if (flag)
			{
				UILabel uILabel5 = textLabel;
				object[] array5 = new object[7];
				array5[0] = Colours.stringGreenArena;
				array5[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.OHDDICCMIMB());
				array5[1] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel5.text = Localization.LocalizeFormat(", squadId = ", array5);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(1101f - (float)DFHAAIFFLOE * 540f);
		return flag;
	}

	public bool FANFNOPNGBL(AEMBEAHLAKB FJLBLLLEELD, IKPLPPFFDNI.MJPNFAKHHHI OPCIFLNBJLI, int DFHAAIFFLOE)
	{
		bool flag = false;
		ArenaLootboxesRow arenaLootboxesRow = OPCIFLNBJLI.FHJKAIKOLHM();
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.ELITEPARTSMIN <= 0 && arenaLootboxesRow.ELITEPARTSMAX > 1;
			if (flag)
			{
				UILabel uILabel = textLabel;
				object[] array = new object[5];
				array[1] = Colours.stringGreenArena;
				array[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMIN);
				array[4] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.ELITEPARTSMAX);
				uILabel.text = Localization.LocalizeFormat("DebugLog", array);
			}
		}
		if (FJLBLLLEELD == AEMBEAHLAKB.EliteParts)
		{
			flag = arenaLootboxesRow.TICKETSMIN <= 0 && arenaLootboxesRow.TICKETSMAX > 0;
			if (flag)
			{
				UILabel uILabel2 = textLabel;
				object[] array2 = new object[3];
				array2[1] = Colours.stringGreenArena;
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMIN);
				array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.TICKETSMAX);
				uILabel2.text = Localization.LocalizeFormat("VIPMembershipExpired", array2);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)5)
		{
			flag = arenaLootboxesRow.SCRAPSMIN > 1 || arenaLootboxesRow.SCRAPSMAX > 1;
			if (flag)
			{
				UILabel uILabel3 = textLabel;
				object[] array3 = new object[5];
				array3[1] = Colours.stringGreenArena;
				array3[0] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMIN);
				array3[2] = MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.SCRAPSMAX);
				uILabel3.text = Localization.LocalizeFormat("qbz_idle", array3);
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)7)
		{
			flag = arenaLootboxesRow.GOLDMIN > 1 || arenaLootboxesRow.GOLDMAX > 0;
			if (flag)
			{
				textLabel.text = Localization.LocalizeFormat("RweardModifierXP", Colours.stringGreenArena, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMIN), null, null, MEJMLNDFDBP.GMIPFLIEOHD(arenaLootboxesRow.GOLDMAX));
			}
		}
		if (FJLBLLLEELD == (AEMBEAHLAKB)6)
		{
			flag = OPCIFLNBJLI.LDMPACAEGPI() <= 1 && OPCIFLNBJLI.ILBGELEJMIG() > 0;
			if (flag)
			{
				UILabel uILabel4 = textLabel;
				object[] array4 = new object[1];
				array4[1] = Colours.stringGreenArena;
				array4[0] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.HGIPNABHLGE());
				array4[8] = MEJMLNDFDBP.GMIPFLIEOHD(OPCIFLNBJLI.BCALEAFPMHK);
				uILabel4.text = Localization.LocalizeFormat("Wrong_Unit", array4);
			}
		}
		base.gameObject.SetActive(flag);
		base.transform.localPosition = base.transform.localPosition.ReplaceY(548f - (float)DFHAAIFFLOE * 1534f);
		return flag;
	}
}
