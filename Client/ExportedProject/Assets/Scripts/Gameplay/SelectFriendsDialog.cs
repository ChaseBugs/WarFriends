using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

public class SelectFriendsDialog : GuiElementSingle<SelectFriendsDialog>, PAIIOKBBHBC
{
	public enum NKHJBLBAAEB
	{
		COOP,
		INVITE,
		FIGHT
	}

	private enum MPJAFCCIOEO
	{
		Facebook,
		Squad,
		Search
	}

	private sealed class PNGBGNMOIPO
	{
		internal Action<DatabasePlayer, bool> LDBILIHIJBI;

		internal SelectFriendsDialog JAGBOPMGIAA;

		internal UIDraggablePanel NFLPPGKCOBL;

		internal void CHOIECFFEMH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("Gold");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 915f, 1957f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 182f);
		}

		internal void MPHECHCFCAN()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ID_WARSHOP_LOOTBOXES");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1104f, 1685f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 414f);
		}

		internal void CHDOECNGOPM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize(" ");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1211f, 2f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1389f);
		}

		internal void KPHEPHDFCKK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("WarBucks");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1641f, 1260f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1455f);
		}

		internal void HHNEBNHCGMO()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ID_ARENARULES_NOOVERTIME");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1276f, 1629f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1905f);
		}

		internal void OKNCFDMEFGJ()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("isCanceled");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1111f, 1536f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 225f);
		}

		internal void MMEEJDGGAID()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ID_CONFIRM_PURCHASEFAILED");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1412f, 1627f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1040f);
		}

		internal void HHLMDAKDHFK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ID_SEARCHFORSQUAD");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 522f, 659f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1930f);
		}

		internal void LKKLABBEOAG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("Notification_DailyRewards");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1417f, 1108f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1386f);
		}

		internal void LGJCNCHBFDA()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("Processing the request Timed Out!");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1996f, 1163f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 835f);
		}

		internal void PHGDBIEENCB()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("), ");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 328f, 1701f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 978f);
		}

		internal void BBPKDMPNEDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("stand_up_crawl");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1492f, 1543f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1282f);
		}

		internal void LJCDGJKCNEC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ID_INVITETOSQUAD");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 87f, 50f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA);
		}

		internal void AMIJFGBOCLC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("colt_shooting_start");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1714f, 387f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1328f);
		}

		internal void PANKBNOCEAM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("withAttribute4");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1485f, 1619f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 473f);
		}

		internal void GMFJFMHNDMC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("/");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1032f, 282f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1883f);
		}

		internal void CIFEDFPPPOK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("REWARDGOLD");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 332f, 377f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 928f);
		}

		internal void NDJOJHNIBFC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("menu-sidetab-player-promote");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 589f, 885f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 862f);
		}

		internal void MCFGAFBEJDK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ID_LEAGUENAME");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1282f, 237f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 149f);
		}

		internal void PCKMJMGLPDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize(", password = ");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 871f, 1223f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1408f);
		}

		internal void JGHLGHMJJDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 182f, 478f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 923f);
		}

		internal void OABFAOLFMMJ()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("AssetBundleManifest");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1653f, 936f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 559f);
		}

		internal void KNJBDOADLDO()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("Lcom/google/android/gms/games/event/Events;");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1623f, 677f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1734f);
		}

		internal void FHDOHCJJEMM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize(",");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1115f, 373f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1108f);
		}

		internal void AGFEDJAKLAC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("elitepack1");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1884f, 212f);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1824f);
		}

		internal void HOMIPBFODIC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.Localize("D");
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 868f, 191f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = NFLPPGKCOBL;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 429f);
		}
	}

	private sealed class JIMPKFPPDJB
	{
		internal Action<DatabasePlayer, bool> LDBILIHIJBI;

		internal SelectFriendsDialog JAGBOPMGIAA;

		internal string ANJMPBCDEBF;

		internal void CHOIECFFEMH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[2];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("gold", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 42f, 459f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1115f);
		}

		internal void KNJBDOADLDO()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_INBRONZE2", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1499f, 1191f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 284f);
		}

		internal void MAKLHLCDIKD()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("_DistanceParams", ANJMPBCDEBF, Colours.stringBlue);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 109f, 1650f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 651f);
		}

		internal void ANAGFGHGPJA()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ClearEntries", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 569f, 750f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1285f);
		}

		internal void MMEEJDGGAID()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("Daily_mission_start", ANJMPBCDEBF, Colours.stringBlue, null, null, null, null, null, null);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1660f, 535f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 4f);
		}

		internal void BEIGOGFHJIB()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_SALEPERCENT", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1959f, 1352f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 346f);
		}

		internal void BDCAFHOHEGM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[8];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ShotFrequencyMax", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1608f, 355f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 321f);
		}

		internal void HHNEBNHCGMO()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[0] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_LOADING", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1799f, 1853f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 856f);
		}

		internal void CMDLGJKIBLL()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("0", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1626f, 1416f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 293f);
		}

		internal void DGELDDJAEEF()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("game-label-eliminated", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1602f, 1237f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 553f);
		}

		internal void LJCDGJKCNEC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("ID_MISSIONCOOPPARTNER", ANJMPBCDEBF, Colours.stringBlue);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 87f, 50f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA);
		}

		internal void JEDCBCPMJGI()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("{0} {1}", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1474f, 1254f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1179f);
		}

		internal void OABFAOLFMMJ()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("elite", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1893f, 431f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1709f);
		}

		internal void KPHEPHDFCKK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[2];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_SLOTUPGRADE_ROF", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 721f, 781f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1789f);
		}

		internal void JDEJHLLIONG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("GUI/", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1286f, 1005f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 212f);
		}

		internal void NCLMPCCHDAM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[8];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("PlayerName", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1459f, 974f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1561f);
		}

		internal void JGEMIBIJMJC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("#PETER# Weapon Screen - RIGHT BUTTON - should not happen", ANJMPBCDEBF, Colours.stringBlue, null, null, null, null, null);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1683f, 732f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 575f);
		}

		internal void JMEBCMMIPAF()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[8];
			array[1] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Ban Chat Message received", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 943f, 1742f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 224f);
		}

		internal void NNIJEDKBPGJ()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("ID_GUI_CHEATINGMESSAGE", ANJMPBCDEBF, Colours.stringBlue);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1221f, 490f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1345f);
		}

		internal void MPHECHCFCAN()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[6];
			array[1] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("damage", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 136f, 1615f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 772f);
		}

		internal void HOMIPBFODIC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[4];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("WRONG dynamic font size: {0} for label: {1}\n", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1325f, 499f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 514f);
		}

		internal void OPHINHIOCFD()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Password", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 667f, 122f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 263f);
		}

		internal void NNFHNIMCBLH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[4];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("N0", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 486f, 1697f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1838f);
		}

		internal void CFDNMILGDLG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Days_Since_Install", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1499f, 1549f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1933f);
		}

		internal void ABNGKEJNLJO()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[8];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("OnOffersReleased", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1018f, 1095f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 293f);
		}

		internal void JGHLGHMJJDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Load map", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 362f, 997f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 305f);
		}

		internal void CJIBPJPJLNB()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[6];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Buy_Army_Unit_At_Rank", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 499f, 1201f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 340f);
		}

		internal void OHLGKFGIPCC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[6];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_CONFIRM_GAMEDOESNOTEXIST", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1543f, 772f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1399f);
		}

		internal void POGLHCIAAGH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[3];
			array[1] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_DOWNLOADINGDATA", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1828f, 158f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 487f);
		}

		internal void DDHOKNIEACI()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[8];
			array[1] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Prefabs to go through: {0} + {1}", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1248f, 925f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1774f);
		}

		internal void KLJNEGDLOMG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Locale", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1286f, 1969f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1128f);
		}

		internal void ILNPANOCHIH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = ANJMPBCDEBF;
			array[1] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ArmyPower", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1590f, 1175f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 426f);
		}

		internal void LKAHPHIEMEK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[1] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Assignment_Skipped", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1617f, 1330f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 363f);
		}

		internal void PCKMJMGLPDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("GetOriginalAccountType()", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 245f, 45f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1321f);
		}

		internal void CHDOECNGOPM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[7];
			array[1] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Bad War Arena Data", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 298f, 242f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 673f);
		}

		internal void ILOFOILFGMA()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[8];
			array[0] = ANJMPBCDEBF;
			array[0] = Colours.stringBlue;
			eJGJELPOHAP.text = Localization.LocalizeFormat("{0} {1}", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 611f, 1835f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1282f);
		}
	}

	private sealed class BFOMOCEANBF
	{
		internal Action<DatabasePlayer, bool> LDBILIHIJBI;

		internal SelectFriendsDialog JAGBOPMGIAA;

		internal void MFCNOIDCJME()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("There is no unit selected as tutorial unit!!!!!!", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 592f, 378f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)6;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1639f);
		}

		internal void CHDOECNGOPM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("TopRun", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1104f, 555f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)6;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1968f);
		}

		internal void AGFEDJAKLAC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat(" & ", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 586f, 408f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 974f);
		}

		internal void KNJBDOADLDO()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("DecalExpiresOn", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1533f, 672f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 633f);
		}

		internal void ILOFOILFGMA()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Buy_Army_Unit_At_Rank", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 621f, 759f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)4;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1626f);
		}

		internal void LJCDGJKCNEC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("ID_CHALLENGEYOURFRIEND", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 87f, 50f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.FIGHT;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA);
		}

		internal void NNFHNIMCBLH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("TicketsGained", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 550f, 565f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 403f);
		}

		internal void DDHOKNIEACI()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("LevelExperience", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 128f, 1505f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1531f);
		}

		internal void PPKGMGNKNAE()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("Input turned OFF completely: ", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 346f, 133f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.INVITE;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1064f);
		}

		internal void ECPMEMNKMCB()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Manual_Unit_Spawn", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 237f, 1126f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)3;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 471f);
		}

		internal void LGJCNCHBFDA()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("NAME", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 850f, 126f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)5;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 186f);
		}

		internal void KPHEPHDFCKK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_ARENASHORTCUTPHASEEND", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 956f, 609f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)7;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 527f);
		}

		internal void NCLMPCCHDAM()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Squad Emblem ", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1560f, 529f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)3;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 394f);
		}

		internal void BBPKDMPNEDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_SQUADMEDALSBIG", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1225f, 750f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 691f);
		}

		internal void FIBGJHCGHJH()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_CONFIRM_RESTART_TEXT", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1011f, 1455f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)5;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1441f);
		}

		internal void MCFGAFBEJDK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ArenaGoldenShieldMessage-{0}", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 641f, 1934f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.FIGHT;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 901f);
		}

		internal void HHLMDAKDHFK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("#AccoutCheck# start waiting to be in menu or in game", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 131f, 283f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)8;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1318f);
		}

		internal void PCKMJMGLPDG()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("setIsPayingUser", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 141f, 371f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)5;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1914f);
		}

		internal void ANAGFGHGPJA()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("), ", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 118f, 218f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)8;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1298f);
		}

		internal void MPHECHCFCAN()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("Card ID \"{0}\" is not pressent in card dictionary.", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 44f, 1894f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)3;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1584f);
		}

		internal void DJLGPGPAHCD()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_RETRY", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1110f, 1139f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)5;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 292f);
		}

		internal void HOMIPBFODIC()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[1];
			array[1] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ID_ARENAWIN", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1599f, 883f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.FIGHT;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 23f);
		}

		internal void INFLOOLPOBK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("YES", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 155f, 617f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)4;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 546f);
		}

		internal void CIFEDFPPPOK()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			UILabel eJGJELPOHAP = JAGBOPMGIAA.EJGJELPOHAP;
			object[] array = new object[0];
			array[0] = Colours.stringRedEnemy;
			eJGJELPOHAP.text = Localization.LocalizeFormat("ResyncTimeRPC", array);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 1457f, 1788f, 1);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = (NKHJBLBAAEB)8;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 968f);
		}

		internal void OABFAOLFMMJ()
		{
			SelectFriendsDialog jAGBOPMGIAA = JAGBOPMGIAA;
			jAGBOPMGIAA.OHGAFIFOGNG = (Action<DatabasePlayer, bool>)Delegate.Combine(jAGBOPMGIAA.OHGAFIFOGNG, LDBILIHIJBI);
			JAGBOPMGIAA.EJGJELPOHAP.text = Localization.LocalizeFormat("Creating warcard ", Colours.stringRedEnemy);
			MEJMLNDFDBP.COCBCFKJOJE(JAGBOPMGIAA.EJGJELPOHAP, 19f, 276f);
			JAGBOPMGIAA.AKGGNKLEEGK = null;
			JAGBOPMGIAA.GPABKIOEGKM = NKHJBLBAAEB.COOP;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 10f);
		}
	}

	private sealed class GEOEAKHBELJ
	{
		internal UIButton DGJCAIJPEIM;

		internal bool MCFGAFBEJDK(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool AMIJFGBOCLC(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool PHGDBIEENCB(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool CMCIGAFHIJL(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool ABNGKEJNLJO(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool JDEJHLLIONG(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool OABFAOLFMMJ(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool AGFEDJAKLAC(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool GGJDILDIFPJ(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool EOHOLKEGGLH(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool BMCMDMKGHHO(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool LJCDGJKCNEC(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool OPHINHIOCFD(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool ECPMEMNKMCB(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool CIFEDFPPPOK(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool DGELDDJAEEF(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool BEIGOGFHJIB(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool MFCNOIDCJME(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool KJIFNOJILDB(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool LKAHPHIEMEK(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool NNIJEDKBPGJ(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool FDKMOFHAEFN(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool FIBGJHCGHJH(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool MAKLHLCDIKD(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool HOMIPBFODIC(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool CFDNMILGDLG(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool POGLHCIAAGH(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool OKNCFDMEFGJ(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool PPKGMGNKNAE(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool HHNEBNHCGMO(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool GMFJFMHNDMC(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool FKIBFHGKMFJ(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool FHDOHCJJEMM(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool FDKEAJLEMCM(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool MPHECHCFCAN(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool NDJOJHNIBFC(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool ILNPANOCHIH(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool ADEFLNOHDAK(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool PANKBNOCEAM(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool BBPKDMPNEDG(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool EMKPBGFBPFI(UIButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}
	}

	private sealed class ABNBBOGDMIG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1826f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(20f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public ABNBBOGDMIG()
		{
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(593f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1196f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(514f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return true;
			}
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1521f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1331f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(618f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1290f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return true;
			}
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1115f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(898f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				if (GameLoginManager.instance.IsLoggedToFacebook)
				{
					GameLoginManager.instance.RefreshFriends();
				}
				else
				{
					Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
				}
				goto case 0u;
			default:
				return false;
			}
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class EEMLIKOKFHJ
	{
		internal DatabasePlayer KHLGDCHJJPB;

		internal bool DJLGPGPAHCD(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool PCKMJMGLPDG(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool NNFHNIMCBLH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool NNIJEDKBPGJ(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool EMKPBGFBPFI(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool ECPMEMNKMCB(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool NCLMPCCHDAM(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool LGJCNCHBFDA(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool FHDOHCJJEMM(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool LJCDGJKCNEC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool INFLOOLPOBK(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool KPHEPHDFCKK(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool BMCMDMKGHHO(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool KNJBDOADLDO(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool BDCAFHOHEGM(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool CHDOECNGOPM(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool PPKGMGNKNAE(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool POGLHCIAAGH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool OHLGKFGIPCC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool AMIJFGBOCLC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool MPHECHCFCAN(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool OABFAOLFMMJ(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool CHOIECFFEMH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool ILOFOILFGMA(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}
	}

	private sealed class PLCAHHFOHML
	{
		internal DatabasePlayer KHLGDCHJJPB;

		internal bool DJLGPGPAHCD(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool MAKLHLCDIKD(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool FHDOHCJJEMM(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool LKAHPHIEMEK(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool NCLMPCCHDAM(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool FDKMOFHAEFN(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool BDCAFHOHEGM(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool OFJDLANHAMD(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool LIMGPKFEALB(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool KPHEPHDFCKK(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool GFBPCKDLGMM(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool OPHINHIOCFD(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool BBPKDMPNEDG(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool EFNJFNKJOMB(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool LJCDGJKCNEC(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool AMIJFGBOCLC(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool ILOFOILFGMA(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool KLJNEGDLOMG(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool JEDCBCPMJGI(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool PPKGMGNKNAE(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool OABFAOLFMMJ(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool ADEFLNOHDAK(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool OHLGKFGIPCC(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool KJIFNOJILDB(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool FKIBFHGKMFJ(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool HHLMDAKDHFK(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool PANKBNOCEAM(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool DGELDDJAEEF(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool CFJHDIHLIML(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool NNFHNIMCBLH(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool POGDLLFCOKO(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool CMCIGAFHIJL(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool CHDOECNGOPM(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool CHOIECFFEMH(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool DDHOKNIEACI(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool CMDLGJKIBLL(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool HHNEBNHCGMO(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool KNJBDOADLDO(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool EGJBKFPHCNF(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return !NGKBOFPJNAG.Value1 && NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}

		internal bool ABNGKEJNLJO(Tuple<bool, DatabasePlayer> NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.Value1 || NGKBOFPJNAG.Value2.id == KHLGDCHJJPB.id;
		}
	}

	private sealed class IEAIENELLMK
	{
		internal DatabasePlayer KHLGDCHJJPB;

		internal bool POGLHCIAAGH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool FHDOHCJJEMM(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool KJIFNOJILDB(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool BBPKDMPNEDG(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool HHLMDAKDHFK(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool LJCDGJKCNEC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool AMIJFGBOCLC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool EMKPBGFBPFI(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool GMFJFMHNDMC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool MPHECHCFCAN(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool KNJBDOADLDO(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool HOMIPBFODIC(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool DDHOKNIEACI(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool NAJNECOMDDN(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool LKKLABBEOAG(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool NNFHNIMCBLH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool HHNEBNHCGMO(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool LKAHPHIEMEK(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool ANAGFGHGPJA(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool OKNCFDMEFGJ(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool PANKBNOCEAM(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool PHGDBIEENCB(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool NNIJEDKBPGJ(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool ILOFOILFGMA(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool FIBGJHCGHJH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}

		internal bool CHOIECFFEMH(DatabasePlayer NGKBOFPJNAG)
		{
			return NGKBOFPJNAG.id == KHLGDCHJJPB.id;
		}
	}

	[Header("Close Button")]
	public UIButton LJNPCHFCGCN;

	[Header("Header")]
	public UILabel EJGJELPOHAP;

	public GameObject JOKEIPPNCMF;

	public GameObject PELBABMOKBO;

	public GameObject IAFALCAHGFA;

	public List<UIButton> EIGENHGGBEB;

	[Header("List")]
	public FriendGuiRecord NKJGGACFDEE;

	public UIDraggablePanel PFDFPFMOEDF;

	public UIPanel FLGMFLGAABB;

	public GameObject EKOCDFGMLKG;

	[Header("-Search Input")]
	public UIInputChat FIAPALMLLKD;

	public UIButton JHAHPFJPDEJ;

	public UILabel IIJCDFHDAGO;

	public UILabel CNCFOPONEFK;

	[Header("-Connect To Facebook")]
	[FormerlySerializedAs("mCloseButton")]
	public GameObject ADOICKINGIM;

	public UIButton NOHDFMODCEG;

	public UITable HBPLKDJGDAA;

	[FormerlySerializedAs("mTitleLabel")]
	public UILabel DNKCBNAKFCE;

	public UILabel MMJLALBBOLC;

	public UILabel KKEHJPIHNPC;

	[Header("-Empty Facebook Friends")]
	[FormerlySerializedAs("mCoopIcon")]
	public GameObject FOPDLAOBLKI;

	public UIButton PALJKEPBEEP;

	public UILabel PEOCAMFJPAO;

	[FormerlySerializedAs("mInviteIcon")]
	[Header("-Join Or Create Squad")]
	public GameObject GDKAHDBHDPF;

	[FormerlySerializedAs("mFightIcon")]
	public GameObject KHFOHBMDEBJ;

	public BoxCollider ODPDOBOHOHF;

	[FormerlySerializedAs("mSettingsPart")]
	public GameObject MEMKHHLCIDH;

	[FormerlySerializedAs("mButtonPart")]
	public GameObject PNBKGHMDKBJ;

	[FormerlySerializedAs("mLeftLabel")]
	public UILabel NPNIDIGGPGI;

	[FormerlySerializedAs("mRightLabel")]
	public UILabel CKDIMHJAKNF;

	public GameObject DAOIMLLOIAN;

	public UILabel FEOCGMDHAEA;

	[FormerlySerializedAs("mHintButton")]
	public GameObject DGBFJNCGAFG;

	public BoxCollider KAJBPHNEJDB;

	[FormerlySerializedAs("mHintButtonSprite")]
	public UISprite LMFGLDGDNEO;

	public GameObject DEBNKFCDENN;

	public UILabel GDDFNCHCFKN;

	public UILabel MAECEAGKNFK;

	public GameObject GFMAPDAEHJB;

	public UILabel HGJALMNIEAD;

	[Header("-Empty Squad Friends")]
	[FormerlySerializedAs("mHeaderButtonsPart")]
	public GameObject GNBBKBJHIKD;

	public UIButton IIFECPMJEBP;

	public UILabel CBJAKCIKNEH;

	[Header("-Facebook And Squad Results")]
	public UIPooledGrid ACHPJBMGCOG;

	[Header("-Search Results")]
	public UIPooledGrid JGNJCGCAIDC;

	public Action<DatabasePlayer, bool> OHGAFIFOGNG;

	private RadicalRoutine EOEHKOPOCNK;

	private List<DatabasePlayer> POPOCPNAAFB = new List<DatabasePlayer>();

	private List<Tuple<bool, DatabasePlayer>> MGBAIEMOCDN = new List<Tuple<bool, DatabasePlayer>>();

	private List<DatabasePlayer> JNMIEFBOPNH = new List<DatabasePlayer>();

	private bool CDCFCEIMAFE;

	private bool IPJDEPNBPCO;

	private string AFPAMILPNAJ;

	private UIDraggablePanel AKGGNKLEEGK;

	private MPJAFCCIOEO IOFOBBGDJLL = MPJAFCCIOEO.Search;

	private NKHJBLBAAEB GPABKIOEGKM = NKHJBLBAAEB.FIGHT;

	public List<string> NIOPKGNIFBL = new List<string>();

	[CompilerGenerated]
	private static Action<DatabasePlayer, bool> LGJCBPOPCPA;

	public NKHJBLBAAEB currentType => GPABKIOEGKM;

	public bool isSquadInviteDialog => GPABKIOEGKM == NKHJBLBAAEB.INVITE;

	private void MMFEBPACOLF(List<DatabasePlayer> BPAFBNCNLDA)
	{
		using (List<DatabasePlayer>.Enumerator enumerator = BPAFBNCNLDA.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				EEMLIKOKFHJ eEMLIKOKFHJ = new EEMLIKOKFHJ();
				eEMLIKOKFHJ.KHLGDCHJJPB = enumerator.Current;
				int num = JNMIEFBOPNH.FindIndex(eEMLIKOKFHJ.LJCDGJKCNEC);
				if (num > -1)
				{
					JNMIEFBOPNH[num] = eEMLIKOKFHJ.KHLGDCHJJPB;
				}
			}
		}
		JNMIEFBOPNH.Sort(DAEPJMMGCGM);
		for (int i = 0; i < JGNJCGCAIDC.containItems; i++)
		{
			Transform itemOnIndex = JGNJCGCAIDC.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.Initialize(JNMIEFBOPNH[i]);
				}
			}
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case DatabaseAction.GetFriendsInfo:
				PLAEGJIAGNB();
				break;
			case DatabaseAction.SearchPlayers:
				CAFJCFCBBJH();
				break;
			}
		}
	}

	private Transform NIJNJOIDDNN(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JNMIEFBOPNH.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(NKJGGACFDEE, JGNJCGCAIDC.gameObject, DFHAAIFFLOE.ToString("'search'0")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				friendGuiRecord.Initialize(JNMIEFBOPNH[DFHAAIFFLOE]);
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	[DebuggerHidden]
	private IEnumerator CKJOOOLBNDD()
	{
		return new ABNBBOGDMIG();
	}

	public bool WasPlayerInvited(DatabasePlayer KHLGDCHJJPB)
	{
		return KHLGDCHJJPB != null && !string.IsNullOrEmpty(KHLGDCHJJPB.id) && NIOPKGNIFBL.Contains(KHLGDCHJJPB.id);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		JGNJCGCAIDC.MakeEmpty();
		JGNJCGCAIDC.SetHelpersToTheSamePosition();
		ACHPJBMGCOG.MakeEmpty();
		ACHPJBMGCOG.SetHelpersToTheSamePosition();
		POPOCPNAAFB.Clear();
		MGBAIEMOCDN.Clear();
		JNMIEFBOPNH.Clear();
		OHGAFIFOGNG = null;
	}

	private void BGEHEBEFEJF()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.NPOEMAMPNEP() < joinSquadUnlockLevel;
		bool flag2 = LevelManager.instance.currentLevel.MHAOKJCDIOL() < createSquadUnlockLevel;
		bool flag3 = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-20));
		MEMKHHLCIDH.transform.localPosition = MEMKHHLCIDH.transform.localPosition.ReplaceX((!flag3) ? 1054f : 1152f);
		PNBKGHMDKBJ.SetActive(!flag3);
		LMFGLDGDNEO.transform.localPosition = LMFGLDGDNEO.transform.localPosition.ReplaceX((!flag3) ? 1567f : 331f);
		DEBNKFCDENN.SetActive(flag3);
		if (!flag3)
		{
			NPNIDIGGPGI.text = Localization.Localize("BEANSTALK: FINISH PLAYER LEAGUE IN MENU SENT!!!!");
			MEJMLNDFDBP.COCBCFKJOJE(NPNIDIGGPGI, 1385f, 1064f, 30);
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE;
			CKDIMHJAKNF.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			GDDFNCHCFKN.text = Localization.Localize("ItemRarity_4");
			MEJMLNDFDBP.COCBCFKJOJE(GDDFNCHCFKN, 688f, 390f, 176);
			MAECEAGKNFK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
		bool flag4 = !flag;
		bool flag5 = !flag2;
		ODPDOBOHOHF.enabled = flag4;
		KAJBPHNEJDB.enabled = flag5;
		FEOCGMDHAEA.text = string.Format("ID_RENTED", Localization.Localize("special"), joinSquadUnlockLevel);
		HGJALMNIEAD.text = string.Format("ID_MISSION_UNITS_HUD", Localization.Localize("ID_UNITDETAILEDSTATISTICS"), createSquadUnlockLevel);
		DAOIMLLOIAN.SetActive(flag);
		GFMAPDAEHJB.SetActive(flag2);
	}

	private void HDELOMGEDAH(string EJBEDLHIKDG)
	{
		if (!string.IsNullOrEmpty(EJBEDLHIKDG) && !NIOPKGNIFBL.Contains(EJBEDLHIKDG))
		{
			NIOPKGNIFBL.Add(EJBEDLHIKDG);
		}
	}

	private Transform COHFDKJNGEB(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < JNMIEFBOPNH.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(NKJGGACFDEE, JGNJCGCAIDC.gameObject, DFHAAIFFLOE.ToString("ID_ACCEPTEDMEMBERSONLY")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				friendGuiRecord.Initialize(JNMIEFBOPNH[DFHAAIFFLOE]);
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	public override void InitGUIValues()
	{
		NIOPKGNIFBL.Clear();
		JPIEAAHFAGE(GPABKIOEGKM);
		KHEEMLNHPGA();
		GIFODEKMPME();
		POPOCPNAAFB.Clear();
		MGBAIEMOCDN.Clear();
		LHDFGBMHLJN();
		bool flag = true;
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			flag = Singleton<ServerResultsCache>.instance.BHLAGCKGOPC() != null;
		}
		bool flag2 = true;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			flag2 = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName) != null;
		}
		IPJDEPNBPCO = !flag || !flag2;
		Singleton<BeanstalkServerManager>.instance.GetFriendsInfo();
		EKOFHHFAPCI(EIGENHGGBEB[0].gameObject);
	}

	private IEnumerator EHBDIHJOODN()
	{
		return new ABNBBOGDMIG();
	}

	private void BGCBLBAOEFP(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			FriendGuiRecord component = ENCEFOOPBMK.GetComponent<FriendGuiRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void LIAKPKPKGPN(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length < 4)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				LLEBFAKNBPM();
				CNCFOPONEFK.gameObject.SetActive(value: false);
				HEKJIEEOJIJ(Localization.Localize("ID_SELECTFRIENDERRORSHORTNAME"));
				PFDFPFMOEDF.UpdateScrollbars(recalculateBounds: true);
				PFDFPFMOEDF.AlignToPos(instant: true);
			}
		}
		else
		{
			CNCFOPONEFK.gameObject.SetActive(value: false);
			JNMIEFBOPNH.Clear();
			JGNJCGCAIDC.MakeEmpty();
			JGNJCGCAIDC.SetHelpersToTheSamePosition();
			IIJCDFHDAGO.gameObject.SetActive(value: false);
			CDCFCEIMAFE = true;
			EKOCDFGMLKG.SetActive(CDCFCEIMAFE);
			AFPAMILPNAJ = EFHMCBKOAEO;
			Singleton<BeanstalkServerManager>.instance.OBKPFHKMELH(EFHMCBKOAEO);
		}
	}

	private void OFCHEEFNKMB()
	{
		POPOCPNAAFB.Clear();
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
		if (list != null)
		{
			foreach (DatabasePlayer item in list)
			{
				if (!(item.id == GameLoginManager.currentPlayer.id) && !string.IsNullOrEmpty(item.name))
				{
					POPOCPNAAFB.Add(item);
				}
			}
		}
		POPOCPNAAFB.Sort(DAEPJMMGCGM);
	}

	public static void ShowSquadInviteDialog(Action<DatabasePlayer, bool> LDBILIHIJBI, UIDraggablePanel NFLPPGKCOBL, float KALLNCAFIMP)
	{
		PNGBGNMOIPO pNGBGNMOIPO = new PNGBGNMOIPO();
		pNGBGNMOIPO.LDBILIHIJBI = LDBILIHIJBI;
		pNGBGNMOIPO.NFLPPGKCOBL = NFLPPGKCOBL;
		pNGBGNMOIPO.JAGBOPMGIAA = GuiElementSingle<SelectFriendsDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(pNGBGNMOIPO.LJCDGJKCNEC, KALLNCAFIMP);
	}

	private int DAEPJMMGCGM(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		PlayerStatus realStatus = HPJFBKEKJHB.GetRealStatus();
		PlayerStatus realStatus2 = NCMHGPNPEJM.GetRealStatus();
		if (realStatus == realStatus2)
		{
			if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
			{
				return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? 1 : 0;
			}
			return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
		}
		if (realStatus == PlayerStatus.Online)
		{
			return -1;
		}
		if (realStatus2 == PlayerStatus.Online)
		{
			return 1;
		}
		if (realStatus == PlayerStatus.Offline)
		{
			return 1;
		}
		return -1;
	}

	private void KJFHCIHDDNO()
	{
		float activeHeight = UIHelper.activeHeight;
		Transform parent = PFDFPFMOEDF.transform.parent;
		Transform parent2 = parent.parent;
		activeHeight += parent.localPosition.y + parent2.localPosition.y;
		if (IOFOBBGDJLL == MPJAFCCIOEO.Search)
		{
			activeHeight -= 174f;
		}
		float num = 0f;
		if (IOFOBBGDJLL == MPJAFCCIOEO.Search)
		{
			num -= 174f;
		}
		PFDFPFMOEDF.transform.localPosition = new Vector3(0f, num, -2f);
		FLGMFLGAABB.clipRange = new Vector4(FLGMFLGAABB.clipRange.x, 0f - activeHeight / 2f, FLGMFLGAABB.clipRange.z, activeHeight);
	}

	private int GHCPAACJPHA(Tuple<bool, DatabasePlayer> MLLJLIHIGKE, Tuple<bool, DatabasePlayer> ENMAEEEEAJO)
	{
		if (MLLJLIHIGKE.Value1)
		{
			return 1;
		}
		if (ENMAEEEEAJO.Value1)
		{
			return -1;
		}
		if (MLLJLIHIGKE.Value1 && ENMAEEEEAJO.Value1)
		{
			return 0;
		}
		return DAEPJMMGCGM(MLLJLIHIGKE.Value2, ENMAEEEEAJO.Value2);
	}

	private void PMFJNJCICOF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void BNEIMAIPFCL(NKHJBLBAAEB FJLBLLLEELD)
	{
		GPABKIOEGKM = FJLBLLLEELD;
		JOKEIPPNCMF.SetActive(FJLBLLLEELD == NKHJBLBAAEB.COOP);
		PELBABMOKBO.SetActive(FJLBLLLEELD == NKHJBLBAAEB.COOP);
		IAFALCAHGFA.SetActive(FJLBLLLEELD == (NKHJBLBAAEB)7);
		bool flag = FJLBLLLEELD == NKHJBLBAAEB.INVITE;
		EIGENHGGBEB[1].GetComponent<SelectFriendsButton>().IHOOKOIBFGG(flag);
		EIGENHGGBEB[0].gameObject.SetActive(!flag);
		EIGENHGGBEB[0].GetComponent<SelectFriendsButton>().AOCKANKFIBO(flag);
		EIGENHGGBEB[4].GetComponent<SelectFriendsButton>().MCEIGNHNCML(flag);
		switch (FJLBLLLEELD)
		{
		case NKHJBLBAAEB.COOP:
			KKEHJPIHNPC.text = Localization.Localize("ID_GUI_REPORTABUSE_LISTITEM6");
			PEOCAMFJPAO.text = Localization.Localize("ios");
			CBJAKCIKNEH.text = Localization.Localize("ID_NOREWARD");
			break;
		case (NKHJBLBAAEB)8:
			KKEHJPIHNPC.text = Localization.Localize("ID_TUTORIAL_TAPON");
			PEOCAMFJPAO.text = Localization.Localize("dogTagTimerLock");
			CBJAKCIKNEH.text = Localization.Localize("ID_ARENARULES_NO");
			break;
		case NKHJBLBAAEB.INVITE:
			KKEHJPIHNPC.text = Localization.Localize("FuseSDK_Prime31_IAB: GoogleIAB.queryInventory failed with message: ");
			PEOCAMFJPAO.text = Localization.Localize("DEV SVK");
			break;
		}
		NBCHEABFGHM();
	}

	private IEnumerator MDADCDLPJKD()
	{
		return new ABNBBOGDMIG();
	}

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(LJNPCHFCGCN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJBCLKMGCDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHAHPFJPDEJ.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EFECKBPEIHH));
		UIInputChat fIAPALMLLKD = FIAPALMLLKD;
		fIAPALMLLKD.onSubmit = (UIInput.OnSubmit)Delegate.Combine(fIAPALMLLKD.onSubmit, new UIInput.OnSubmit(LIAKPKPKGPN));
		UIEventListener uIEventListener3 = UIEventListener.Get(NOHDFMODCEG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PMFJNJCICOF));
		UIEventListener uIEventListener4 = UIEventListener.Get(PALJKEPBEEP.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LEOIEBHKMPH));
		UIEventListener uIEventListener5 = UIEventListener.Get(IIFECPMJEBP.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EFMDKOGDNCA));
		UIEventListener uIEventListener6 = UIEventListener.Get(KHFOHBMDEBJ);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(BHPHFADPDDO));
		UIEventListener uIEventListener7 = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(HEMPGCPOEBL));
		foreach (UIButton item in EIGENHGGBEB)
		{
			UIEventListener uIEventListener8 = UIEventListener.Get(item.gameObject);
			uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(EKOFHHFAPCI));
		}
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void PLAEGJIAGNB()
	{
		if (MGBAIEMOCDN.Count > 0 && IOFOBBGDJLL == MPJAFCCIOEO.Facebook)
		{
			EJNFOMLDABC(Singleton<ServerResultsCache>.instance.BHLAGCKGOPC());
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
			if (list != null && POPOCPNAAFB.Count > 0 && IOFOBBGDJLL == MPJAFCCIOEO.Squad)
			{
				FCFEJKEJHDI(list);
				return;
			}
		}
		IPJDEPNBPCO = false;
		COGFCKDOLAF();
		OFCHEEFNKMB();
		if (IOFOBBGDJLL == MPJAFCCIOEO.Facebook || IOFOBBGDJLL == MPJAFCCIOEO.Squad)
		{
			FODOPIPGHOA();
		}
	}

	private void HEMPGCPOEBL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed && (DebugSettings.debugEnabled || !GFMAPDAEHJB.activeSelf))
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	private int PIOMLFNDJIM(DatabasePlayer HPJFBKEKJHB, DatabasePlayer NCMHGPNPEJM)
	{
		PlayerStatus realStatus = HPJFBKEKJHB.GetRealStatus();
		PlayerStatus realStatus2 = NCMHGPNPEJM.GetRealStatus();
		if (realStatus == realStatus2)
		{
			if (string.IsNullOrEmpty(HPJFBKEKJHB.name))
			{
				return (!string.IsNullOrEmpty(NCMHGPNPEJM.name)) ? 1 : 0;
			}
			return HPJFBKEKJHB.name.CompareTo(NCMHGPNPEJM.name);
		}
		if (realStatus == PlayerStatus.Online)
		{
			return -1;
		}
		if (realStatus2 == PlayerStatus.Online)
		{
			return 1;
		}
		if (realStatus == PlayerStatus.Offline)
		{
			return 1;
		}
		return -1;
	}

	private void EKOFHHFAPCI(GameObject KHAHPAKDIKE)
	{
		GEOEAKHBELJ gEOEAKHBELJ = new GEOEAKHBELJ();
		gEOEAKHBELJ.DGJCAIJPEIM = (UIButton)SingletonSupport.FirstOrDefault((UnityEngine.Object[])KHAHPAKDIKE.GetComponentsInChildren<UIButton>(includeInactive: true));
		int iOFOBBGDJLL = EIGENHGGBEB.FindIndex(gEOEAKHBELJ.LJCDGJKCNEC);
		IOFOBBGDJLL = (MPJAFCCIOEO)iOFOBBGDJLL;
		for (int i = 0; i < EIGENHGGBEB.Count; i++)
		{
			SelectFriendsButton component = EIGENHGGBEB[i].gameObject.GetComponent<SelectFriendsButton>();
			component.JCPNPOLKBHJ(i == (int)IOFOBBGDJLL);
		}
		FODOPIPGHOA();
	}

	private void COGFCKDOLAF()
	{
		MGBAIEMOCDN.Clear();
		foreach (DatabasePlayer item in Singleton<ServerResultsCache>.instance.BHLAGCKGOPC())
		{
			MGBAIEMOCDN.Add(new Tuple<bool, DatabasePlayer>(val1: false, item));
		}
		if (MGBAIEMOCDN.Count > 0 && MGBAIEMOCDN.Count <= GameVariables.lowFacebookFriends)
		{
			MGBAIEMOCDN.Add(new Tuple<bool, DatabasePlayer>(val1: true, null));
		}
		MGBAIEMOCDN.Sort(GHCPAACJPHA);
	}

	private void BHPHFADPDDO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed && (DebugSettings.debugEnabled || !DAOIMLLOIAN.activeSelf))
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void KJBCLKMGCDL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (OHGAFIFOGNG != null)
			{
				OHGAFIFOGNG(null, arg2: false);
				OHGAFIFOGNG = null;
			}
		}
	}

	public override void InitControls()
	{
		FIAPALMLLKD.maxChars = DatabasePlayer.maxPlayerName;
		FIAPALMLLKD.defaultText = Localization.Localize("ID_EMPTYSEARCHPLAYER");
		HBPLKDJGDAA.onReposition = delegate
		{
			float val = 0f - HBPLKDJGDAA.padding.x - (DNKCBNAKFCE.transform.parent.transform.localPosition.x - HBPLKDJGDAA.padding.x) / 2f + 60f;
			HBPLKDJGDAA.transform.localPosition = HBPLKDJGDAA.transform.localPosition.ReplaceX(val);
		};
	}

	private void HEKJIEEOJIJ(string IGKOKJFCCCI)
	{
		IIJCDFHDAGO.gameObject.SetActive(value: true);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
	}

	private void IABIKIMHION(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED() && (DebugSettings.debugEnabled || !DAOIMLLOIAN.activeSelf))
		{
			HideDialog();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	[SpecialName]
	public NKHJBLBAAEB BMONAKDOFKJ()
	{
		return GPABKIOEGKM;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (AKGGNKLEEGK != null)
		{
			AKGGNKLEEGK.onePanelDisabled = false;
			AKGGNKLEEGK = null;
		}
		UIDraggablePanel.panelDisabled = false;
	}

	private void EFECKBPEIHH(GameObject KHAHPAKDIKE)
	{
		LIAKPKPKGPN(FIAPALMLLKD.text);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - HBPLKDJGDAA.padding.x - (DNKCBNAKFCE.transform.parent.transform.localPosition.x - HBPLKDJGDAA.padding.x) / 2f + 60f;
		HBPLKDJGDAA.transform.localPosition = HBPLKDJGDAA.transform.localPosition.ReplaceX(val);
	}

	private void HJAFOEHMNPD(NKHJBLBAAEB FJLBLLLEELD)
	{
		GPABKIOEGKM = FJLBLLLEELD;
		JOKEIPPNCMF.SetActive(FJLBLLLEELD == NKHJBLBAAEB.INVITE);
		PELBABMOKBO.SetActive(FJLBLLLEELD == NKHJBLBAAEB.COOP);
		IAFALCAHGFA.SetActive(FJLBLLLEELD == (NKHJBLBAAEB)3);
		bool flag = FJLBLLLEELD == NKHJBLBAAEB.INVITE;
		EIGENHGGBEB[1].GetComponent<SelectFriendsButton>().IHOOKOIBFGG(flag);
		EIGENHGGBEB[1].gameObject.SetActive(!flag);
		EIGENHGGBEB[1].GetComponent<SelectFriendsButton>().AOCKANKFIBO(flag);
		EIGENHGGBEB[1].GetComponent<SelectFriendsButton>().BGJBNMIHBIP(flag);
		switch (FJLBLLLEELD)
		{
		default:
			if (FJLBLLLEELD == NKHJBLBAAEB.INVITE)
			{
				KKEHJPIHNPC.text = Localization.Localize("VipReward1");
				PEOCAMFJPAO.text = Localization.Localize("Beanstalk: Invalid Token - ");
			}
			break;
		case NKHJBLBAAEB.COOP:
			KKEHJPIHNPC.text = Localization.Localize("Vip");
			PEOCAMFJPAO.text = Localization.Localize("StarterPackDeadline");
			CBJAKCIKNEH.text = Localization.Localize("ID_ARENARULES_STRONGERUNITS");
			break;
		case NKHJBLBAAEB.INVITE:
			KKEHJPIHNPC.text = Localization.Localize("PlayerUnits");
			PEOCAMFJPAO.text = Localization.Localize("battlesLostInRow");
			CBJAKCIKNEH.text = Localization.Localize("Player disconected 0001");
			break;
		}
		NBCHEABFGHM();
	}

	private void KHEEMLNHPGA()
	{
		JGNJCGCAIDC.MakeEmpty();
		JGNJCGCAIDC.SetHelpersToTheSamePosition();
		ACHPJBMGCOG.MakeEmpty();
		ACHPJBMGCOG.SetHelpersToTheSamePosition();
		EKOCDFGMLKG.SetActive(value: false);
		ADOICKINGIM.SetActive(value: false);
		FOPDLAOBLKI.SetActive(value: false);
		GDKAHDBHDPF.SetActive(value: false);
		GNBBKBJHIKD.SetActive(value: false);
		FIAPALMLLKD.gameObject.SetActive(value: false);
		JCDGKKHPJKP();
		LLEBFAKNBPM();
		if (IOFOBBGDJLL != MPJAFCCIOEO.Search)
		{
			GIFODEKMPME();
		}
	}

	private void JCDGKKHPJKP()
	{
		IIJCDFHDAGO.gameObject.SetActive(value: false);
	}

	public static void ShowFightFriendsDialog(Action<DatabasePlayer, bool> LDBILIHIJBI, float KALLNCAFIMP)
	{
		BFOMOCEANBF bFOMOCEANBF = new BFOMOCEANBF();
		bFOMOCEANBF.LDBILIHIJBI = LDBILIHIJBI;
		bFOMOCEANBF.JAGBOPMGIAA = GuiElementSingle<SelectFriendsDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(bFOMOCEANBF.LJCDGJKCNEC, KALLNCAFIMP);
	}

	private void FODOPIPGHOA()
	{
		KHEEMLNHPGA();
		KJFHCIHDDNO();
		if (IOFOBBGDJLL == MPJAFCCIOEO.Search)
		{
			FIAPALMLLKD.gameObject.SetActive(value: true);
			if (CDCFCEIMAFE)
			{
				EKOCDFGMLKG.SetActive(value: true);
			}
			else if (!string.IsNullOrEmpty(AFPAMILPNAJ))
			{
				if (JNMIEFBOPNH.Count == 0)
				{
					HEKJIEEOJIJ(string.Format("{0} {1}", Localization.Localize("ID_SELECTFRIENDERRORNORESULT"), AFPAMILPNAJ));
				}
				else
				{
					JGNJCGCAIDC.init(JNMIEFBOPNH.Count, NIJNJOIDDNN, BGCBLBAOEFP, PFDFPFMOEDF);
					KFFNHLMLHEE();
				}
			}
		}
		else if (IOFOBBGDJLL == MPJAFCCIOEO.Facebook)
		{
			if (!GameLoginManager.currentPlayer.isFacebookConnected)
			{
				ADOICKINGIM.SetActive(value: true);
				bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
				HBPLKDJGDAA.gameObject.SetActive(!flag);
				MMJLALBBOLC.gameObject.SetActive(flag);
				if (!flag)
				{
					HBPLKDJGDAA.repositionNow = true;
					int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
					DNKCBNAKFCE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				}
			}
			else if (IPJDEPNBPCO)
			{
				EKOCDFGMLKG.SetActive(value: true);
			}
			else if (MGBAIEMOCDN.Count == 0)
			{
				FOPDLAOBLKI.SetActive(value: true);
			}
			else
			{
				ACHPJBMGCOG.init(MGBAIEMOCDN.Count, KGFOAKGKJAH, BGCBLBAOEFP, PFDFPFMOEDF);
				KFFNHLMLHEE();
			}
		}
		else if (IOFOBBGDJLL == MPJAFCCIOEO.Squad)
		{
			if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
			{
				GDKAHDBHDPF.SetActive(value: true);
			}
			else if (IPJDEPNBPCO)
			{
				EKOCDFGMLKG.SetActive(value: true);
			}
			else if (POPOCPNAAFB.Count == 0)
			{
				GNBBKBJHIKD.SetActive(value: true);
			}
			else
			{
				ACHPJBMGCOG.init(POPOCPNAAFB.Count, EFOFAEIFOMP, BGCBLBAOEFP, PFDFPFMOEDF);
				KFFNHLMLHEE();
			}
		}
		PFDFPFMOEDF.UpdateScrollbars(recalculateBounds: true);
		PFDFPFMOEDF.AlignToPos(instant: true);
	}

	private void FCFEJKEJHDI(List<DatabasePlayer> BPAFBNCNLDA)
	{
		int num = POPOCPNAAFB.Count + 1;
		if (BPAFBNCNLDA.Count != num)
		{
			OFCHEEFNKMB();
			FODOPIPGHOA();
			return;
		}
		using (List<DatabasePlayer>.Enumerator enumerator = BPAFBNCNLDA.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				IEAIENELLMK iEAIENELLMK = new IEAIENELLMK();
				iEAIENELLMK.KHLGDCHJJPB = enumerator.Current;
				int num2 = POPOCPNAAFB.FindIndex(iEAIENELLMK.LJCDGJKCNEC);
				if (num2 > -1)
				{
					POPOCPNAAFB[num2] = iEAIENELLMK.KHLGDCHJJPB;
				}
			}
		}
		POPOCPNAAFB.Sort(DAEPJMMGCGM);
		for (int i = 0; i < ACHPJBMGCOG.containItems; i++)
		{
			Transform itemOnIndex = ACHPJBMGCOG.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
				if (component != null)
				{
					component.FreeTexture();
					component.Initialize(POPOCPNAAFB[i]);
				}
			}
		}
	}

	private void KFFNHLMLHEE()
	{
		LLEBFAKNBPM();
		EOEHKOPOCNK = RadicalRoutine.Create(CKJOOOLBNDD());
		StartCoroutine(EOEHKOPOCNK.enumerator);
	}

	private void JPIEAAHFAGE(NKHJBLBAAEB FJLBLLLEELD)
	{
		GPABKIOEGKM = FJLBLLLEELD;
		JOKEIPPNCMF.SetActive(FJLBLLLEELD == NKHJBLBAAEB.COOP);
		PELBABMOKBO.SetActive(FJLBLLLEELD == NKHJBLBAAEB.INVITE);
		IAFALCAHGFA.SetActive(FJLBLLLEELD == NKHJBLBAAEB.FIGHT);
		bool flag = FJLBLLLEELD == NKHJBLBAAEB.INVITE;
		EIGENHGGBEB[0].GetComponent<SelectFriendsButton>().HFOFJLLPMOO(flag);
		EIGENHGGBEB[1].gameObject.SetActive(!flag);
		EIGENHGGBEB[1].GetComponent<SelectFriendsButton>().PAMFOABINII(flag);
		EIGENHGGBEB[2].GetComponent<SelectFriendsButton>().HFOFJLLPMOO(flag);
		switch (FJLBLLLEELD)
		{
		case NKHJBLBAAEB.COOP:
			KKEHJPIHNPC.text = Localization.Localize("ID_FACEBOOKHINT-COOP");
			PEOCAMFJPAO.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-COOP");
			CBJAKCIKNEH.text = Localization.Localize("ID_SQUADEMPTYTEXT-COOP");
			break;
		case NKHJBLBAAEB.FIGHT:
			KKEHJPIHNPC.text = Localization.Localize("ID_FACEBOOKHINT-FIGHT");
			PEOCAMFJPAO.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-FIGHT");
			CBJAKCIKNEH.text = Localization.Localize("ID_SQUADEMPTYTEXT-FIGHT");
			break;
		case NKHJBLBAAEB.INVITE:
			KKEHJPIHNPC.text = Localization.Localize("ID_FACEBOOKHINT-SQUADINVITE");
			PEOCAMFJPAO.text = Localization.Localize("ID_FACEBOOKINVITEFRIENDSTEXT-SQUADINVITE");
			break;
		}
		NBCHEABFGHM();
	}

	private void ILPAMAJKDGE()
	{
		if (!CDCFCEIMAFE && JNMIEFBOPNH.Count > 0 && IOFOBBGDJLL == (MPJAFCCIOEO)8)
		{
			MMFEBPACOLF(Singleton<ServerResultsCache>.instance.playerSearchResult);
			return;
		}
		CDCFCEIMAFE = true;
		JNMIEFBOPNH.Clear();
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.playerSearchResult;
		if (list == null)
		{
			list = new List<DatabasePlayer>();
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (!(list[i].id == GameLoginManager.currentPlayer.id) && !string.IsNullOrEmpty(list[i].name))
			{
				JNMIEFBOPNH.Add(list[i]);
			}
		}
		JNMIEFBOPNH.Sort(PIOMLFNDJIM);
		if (IOFOBBGDJLL == (MPJAFCCIOEO)7)
		{
			FODOPIPGHOA();
		}
	}

	public void OMPPOBCIHGL(DatabasePlayer KHLGDCHJJPB)
	{
		bool flag = GPABKIOEGKM == NKHJBLBAAEB.INVITE;
		if (OHGAFIFOGNG != null)
		{
			UnityEngine.Debug.Log("ID_NA" + KHLGDCHJJPB.name);
			OHGAFIFOGNG(KHLGDCHJJPB, arg2: false);
			SoundsManager.Instance.PlayButtonClickedSound();
			if (!flag)
			{
				OHGAFIFOGNG = null;
			}
		}
		if (flag)
		{
			HDELOMGEDAH(KHLGDCHJJPB.id);
		}
		else
		{
			HideDialog();
		}
	}

	private void EJNFOMLDABC(List<DatabasePlayer> BPAFBNCNLDA)
	{
		int num = MGBAIEMOCDN.Count;
		foreach (Tuple<bool, DatabasePlayer> item in MGBAIEMOCDN)
		{
			if (item.Value1)
			{
				num--;
			}
		}
		if (BPAFBNCNLDA.Count != num)
		{
			COGFCKDOLAF();
			FODOPIPGHOA();
			return;
		}
		using (List<DatabasePlayer>.Enumerator enumerator2 = BPAFBNCNLDA.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				PLCAHHFOHML pLCAHHFOHML = new PLCAHHFOHML();
				pLCAHHFOHML.KHLGDCHJJPB = enumerator2.Current;
				int num2 = MGBAIEMOCDN.FindIndex(pLCAHHFOHML.LJCDGJKCNEC);
				if (num2 > -1)
				{
					MGBAIEMOCDN[num2].Value2 = pLCAHHFOHML.KHLGDCHJJPB;
				}
			}
		}
		MGBAIEMOCDN.Sort(GHCPAACJPHA);
		for (int i = 0; i < ACHPJBMGCOG.containItems; i++)
		{
			Transform itemOnIndex = ACHPJBMGCOG.GetItemOnIndex(i);
			if (!(itemOnIndex != null))
			{
				continue;
			}
			FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
			if (component != null)
			{
				component.FreeTexture();
				if (MGBAIEMOCDN[i].Value1)
				{
					component.InitializeInvite();
				}
				else
				{
					component.Initialize(MGBAIEMOCDN[i].Value2);
				}
			}
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		PFDFPFMOEDF.UpdateScrollbars(recalculateBounds: true);
		PFDFPFMOEDF.AlignToPos(instant: true);
		PFDFPFMOEDF.forceDrag = true;
		if (AKGGNKLEEGK != null)
		{
			AKGGNKLEEGK.onePanelDisabled = true;
		}
		UIDraggablePanel.panelDisabled = true;
		TweenAlpha.Begin(GDKAHDBHDPF, 0.1f, 1f, 1f);
	}

	[CompilerGenerated]
	private static void MIPKOLGCLAB(DatabasePlayer KKHKAJPNDEC, bool NCMHGPNPEJM)
	{
		if (KKHKAJPNDEC == null)
		{
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (KKHKAJPNDEC.squadName == currentPlayer.squadName)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", KKHKAJPNDEC.name));
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		bool flag = currentPlayer.squadRank == SquadRank.Member;
		if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
		}
		else if (aANECPGDMGM.MGDCJLAENHG() <= 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance);
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.CLGKGOHGLGG(KKHKAJPNDEC);
		}
	}

	private void LLEBFAKNBPM()
	{
		if (EOEHKOPOCNK != null)
		{
			EOEHKOPOCNK.Cancel();
			EOEHKOPOCNK = null;
		}
	}

	private void KBGGIBBHOHL()
	{
		KHEEMLNHPGA();
		KJFHCIHDDNO();
		if (IOFOBBGDJLL == MPJAFCCIOEO.Facebook)
		{
			FIAPALMLLKD.gameObject.SetActive(value: false);
			if (CDCFCEIMAFE)
			{
				EKOCDFGMLKG.SetActive(value: true);
			}
			else if (!string.IsNullOrEmpty(AFPAMILPNAJ))
			{
				if (JNMIEFBOPNH.Count == 0)
				{
					HEKJIEEOJIJ(string.Format("ID_STAT_BESTACCURACY", Localization.Localize("Overtime_Was_Already_Explained"), AFPAMILPNAJ));
				}
				else
				{
					JGNJCGCAIDC.init(JNMIEFBOPNH.Count, COHFDKJNGEB, BGCBLBAOEFP, PFDFPFMOEDF);
					KFFNHLMLHEE();
				}
			}
		}
		else if (IOFOBBGDJLL == MPJAFCCIOEO.Facebook)
		{
			if (!GameLoginManager.currentPlayer.isFacebookConnected)
			{
				ADOICKINGIM.SetActive(value: false);
				bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalPowerbandDelayMin);
				HBPLKDJGDAA.gameObject.SetActive(flag);
				MMJLALBBOLC.gameObject.SetActive(flag);
				if (!flag)
				{
					HBPLKDJGDAA.repositionNow = false;
					int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
					DNKCBNAKFCE.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
				}
			}
			else if (IPJDEPNBPCO)
			{
				EKOCDFGMLKG.SetActive(value: false);
			}
			else if (MGBAIEMOCDN.Count == 0)
			{
				FOPDLAOBLKI.SetActive(value: false);
			}
			else
			{
				ACHPJBMGCOG.init(MGBAIEMOCDN.Count, KGFOAKGKJAH, BGCBLBAOEFP, PFDFPFMOEDF);
				KFFNHLMLHEE();
			}
		}
		else if (IOFOBBGDJLL == MPJAFCCIOEO.Squad)
		{
			if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
			{
				GDKAHDBHDPF.SetActive(value: true);
			}
			else if (IPJDEPNBPCO)
			{
				EKOCDFGMLKG.SetActive(value: false);
			}
			else if (POPOCPNAAFB.Count == 0)
			{
				GNBBKBJHIKD.SetActive(value: false);
			}
			else
			{
				ACHPJBMGCOG.init(POPOCPNAAFB.Count, EFOFAEIFOMP, BGCBLBAOEFP, PFDFPFMOEDF);
				KFFNHLMLHEE();
			}
		}
		PFDFPFMOEDF.UpdateScrollbars(recalculateBounds: true);
		PFDFPFMOEDF.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	private void BNGMKJFPNDG(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			if (OHGAFIFOGNG != null)
			{
				OHGAFIFOGNG(null, arg2: false);
				OHGAFIFOGNG = null;
			}
		}
	}

	private void NBCHEABFGHM()
	{
		for (int i = 0; i < ACHPJBMGCOG.containItems; i++)
		{
			Transform itemOnIndex = ACHPJBMGCOG.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				FriendGuiRecord component = itemOnIndex.GetComponent<FriendGuiRecord>();
				if (component != null)
				{
					component.ChangeLook(GPABKIOEGKM);
				}
			}
		}
		for (int j = 0; j < JGNJCGCAIDC.containItems; j++)
		{
			Transform itemOnIndex2 = JGNJCGCAIDC.GetItemOnIndex(j);
			if (itemOnIndex2 != null)
			{
				FriendGuiRecord component2 = itemOnIndex2.GetComponent<FriendGuiRecord>();
				if (component2 != null)
				{
					component2.ChangeLook(GPABKIOEGKM);
				}
			}
		}
	}

	private Transform EFOFAEIFOMP(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < POPOCPNAAFB.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(NKJGGACFDEE, ACHPJBMGCOG.gameObject, DFHAAIFFLOE.ToString("'friend'0")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				friendGuiRecord.Initialize(POPOCPNAAFB[DFHAAIFFLOE]);
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	private void BPBEECOFCKD()
	{
		float activeHeight = UIHelper.activeHeight;
		Transform parent = PFDFPFMOEDF.transform.parent;
		Transform parent2 = parent.parent;
		activeHeight += parent.localPosition.y + parent2.localPosition.y;
		if (IOFOBBGDJLL == (MPJAFCCIOEO)8)
		{
			activeHeight -= 385f;
		}
		float num = 1954f;
		if (IOFOBBGDJLL == (MPJAFCCIOEO)3)
		{
			num -= 272f;
		}
		PFDFPFMOEDF.transform.localPosition = new Vector3(1510f, num, 735f);
		FLGMFLGAABB.clipRange = new Vector4(FLGMFLGAABB.clipRange.x, 0f - activeHeight / 1162f, FLGMFLGAABB.clipRange.z, activeHeight);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		EJGJELPOHAP.alpha = 0.9f;
		JGNJCGCAIDC.gameObject.SetActive(value: true);
		ACHPJBMGCOG.gameObject.SetActive(value: true);
	}

	public void Select(DatabasePlayer KHLGDCHJJPB)
	{
		bool flag = GPABKIOEGKM == NKHJBLBAAEB.INVITE;
		if (OHGAFIFOGNG != null)
		{
			UnityEngine.Debug.Log("Selected " + KHLGDCHJJPB.name);
			OHGAFIFOGNG(KHLGDCHJJPB, arg2: true);
			SoundsManager.Instance.PlayButtonClickedSound();
			if (!flag)
			{
				OHGAFIFOGNG = null;
			}
		}
		if (flag)
		{
			HDELOMGEDAH(KHLGDCHJJPB.id);
		}
		else
		{
			HideDialog();
		}
	}

	private void LEOIEBHKMPH(GameObject KHAHPAKDIKE)
	{
		GameLoginManager.instance.InviteFacebookFriends();
	}

	private void GIFODEKMPME()
	{
		JNMIEFBOPNH.Clear();
		FIAPALMLLKD.text = string.Empty;
		AFPAMILPNAJ = string.Empty;
		CDCFCEIMAFE = false;
		CNCFOPONEFK.gameObject.SetActive(value: true);
	}

	public static void ShowCoopDialog(Action<DatabasePlayer, bool> LDBILIHIJBI, float KALLNCAFIMP, string ANJMPBCDEBF)
	{
		JIMPKFPPDJB jIMPKFPPDJB = new JIMPKFPPDJB();
		jIMPKFPPDJB.LDBILIHIJBI = LDBILIHIJBI;
		jIMPKFPPDJB.ANJMPBCDEBF = ANJMPBCDEBF;
		jIMPKFPPDJB.JAGBOPMGIAA = GuiElementSingle<SelectFriendsDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(jIMPKFPPDJB.LJCDGJKCNEC, KALLNCAFIMP);
	}

	public override void OnBack()
	{
		KJBCLKMGCDL(LJNPCHFCGCN.gameObject);
	}

	private Transform KGFOAKGKJAH(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < MGBAIEMOCDN.Count)
		{
			FriendGuiRecord friendGuiRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(NKJGGACFDEE, ACHPJBMGCOG.gameObject, DFHAAIFFLOE.ToString("'friend'0")) as FriendGuiRecord;
			if (friendGuiRecord != null)
			{
				if (MGBAIEMOCDN[DFHAAIFFLOE].Value1)
				{
					friendGuiRecord.InitializeInvite();
				}
				else
				{
					friendGuiRecord.Initialize(MGBAIEMOCDN[DFHAAIFFLOE].Value2);
				}
				return friendGuiRecord.transform;
			}
		}
		return null;
	}

	public virtual void LHAGLPJNLFB()
	{
		base.DoBeforeShowUp();
		EJGJELPOHAP.alpha = 602f;
		JGNJCGCAIDC.gameObject.SetActive(value: true);
		ACHPJBMGCOG.gameObject.SetActive(value: true);
	}

	private void PFLJKJCHCIF()
	{
		float val = 0f - HBPLKDJGDAA.padding.x - (DNKCBNAKFCE.transform.parent.transform.localPosition.x - HBPLKDJGDAA.padding.x) / 489f + 596f;
		HBPLKDJGDAA.transform.localPosition = HBPLKDJGDAA.transform.localPosition.ReplaceX(val);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void LHDFGBMHLJN()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool flag2 = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		bool flag3 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldRewardFirstTimeSquad);
		MEMKHHLCIDH.transform.localPosition = MEMKHHLCIDH.transform.localPosition.ReplaceX((!flag3) ? (-100f) : 0f);
		PNBKGHMDKBJ.SetActive(!flag3);
		LMFGLDGDNEO.transform.localPosition = LMFGLDGDNEO.transform.localPosition.ReplaceX((!flag3) ? 50f : 0f);
		DEBNKFCDENN.SetActive(!flag3);
		if (!flag3)
		{
			NPNIDIGGPGI.text = Localization.Localize("ID_SQUADREWARDGET");
			MEJMLNDFDBP.COCBCFKJOJE(NPNIDIGGPGI, 89f, 30f, 280);
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
			CKDIMHJAKNF.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			GDDFNCHCFKN.text = Localization.Localize("ID_SQUADREWARDGET");
			MEJMLNDFDBP.COCBCFKJOJE(GDDFNCHCFKN, 89f, 30f, 280);
			MAECEAGKNFK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
		bool flag4 = !flag;
		bool flag5 = !flag2;
		ODPDOBOHOHF.enabled = flag4;
		KAJBPHNEJDB.enabled = flag5;
		FEOCGMDHAEA.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), joinSquadUnlockLevel);
		HGJALMNIEAD.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		DAOIMLLOIAN.SetActive(flag);
		GFMAPDAEHJB.SetActive(flag2);
	}

	private void EFMDKOGDNCA(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		ShowSquadInviteDialog(delegate(DatabasePlayer KKHKAJPNDEC, bool NCMHGPNPEJM)
		{
			if (KKHKAJPNDEC != null)
			{
				DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
				if (KKHKAJPNDEC.squadName == currentPlayer.squadName)
				{
					ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", KKHKAJPNDEC.name));
				}
				else
				{
					AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
					bool flag = currentPlayer.squadRank == SquadRank.Member;
					if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
					{
						WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
					}
					else if (aANECPGDMGM.MGDCJLAENHG() <= 0)
					{
						Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance);
					}
					else
					{
						Singleton<BeanstalkServerManager>.instance.CLGKGOHGLGG(KKHKAJPNDEC);
					}
				}
			}
		}, AKGGNKLEEGK, HECFOEMLJCD + 0.1f);
	}

	private void CAFJCFCBBJH()
	{
		if (!CDCFCEIMAFE && JNMIEFBOPNH.Count > 0 && IOFOBBGDJLL == MPJAFCCIOEO.Search)
		{
			MMFEBPACOLF(Singleton<ServerResultsCache>.instance.playerSearchResult);
			return;
		}
		CDCFCEIMAFE = false;
		JNMIEFBOPNH.Clear();
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.playerSearchResult;
		if (list == null)
		{
			list = new List<DatabasePlayer>();
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (!(list[i].id == GameLoginManager.currentPlayer.id) && !string.IsNullOrEmpty(list[i].name))
			{
				JNMIEFBOPNH.Add(list[i]);
			}
		}
		JNMIEFBOPNH.Sort(DAEPJMMGCGM);
		if (IOFOBBGDJLL == MPJAFCCIOEO.Search)
		{
			FODOPIPGHOA();
		}
	}
}
