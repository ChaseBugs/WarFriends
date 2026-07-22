using System;
using System.Runtime.CompilerServices;
using BestHTTP.SocketIO;
using BestHTTP.SocketIO.Events;
using PlatformSupport.Collections.ObjectModel;
using UnityEngine;

internal class DBGMGHGNNOH
{
	private SocketManager HKJMPIGDCAG;

	[CompilerGenerated]
	private static SocketIOCallback LGJCBPOPCPA;

	private static void GMOIIKBDLIA(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("value", HPMFCEDMMJO[1].ToString()));
	}

	private void FAIHGPEJLAG(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ID_ARENASHORTCUTPHASEEND" + HPMFCEDMMJO[1]);
	}

	private void JNDCHDPLMIP(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("special" + HPMFCEDMMJO[1]);
	}

	private static void DOHOLJDDFJC(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_WARNING_ACCOUNTALREADYCREATED", HPMFCEDMMJO[0].ToString()));
	}

	private static void ABGCOGBPKPH(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("PlacementMatchesRequired", HPMFCEDMMJO[1].ToString()));
	}

	private static void JAHGKGANEGO(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_SHOTDAMAGE", HPMFCEDMMJO[0].ToString()));
	}

	private void HFLEDJHANEI(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ID_DAY" + HPMFCEDMMJO[0]);
	}

	public DBGMGHGNNOH(string EJBEDLHIKDG)
	{
		Debug.Log("SH: Init");
		SocketOptions options = new SocketOptions
		{
			AutoConnect = false,
			AdditionalQueryParams = new ObservableDictionary<string, string>
			{
				{ "key", "value" },
				{ "id", EJBEDLHIKDG }
			}
		};
		HKJMPIGDCAG = new SocketManager(new Uri("http://localhost:3000/socket.io/"), options);
		HKJMPIGDCAG.Socket.On("chatmessage", EKOCCGKDFIN);
		HKJMPIGDCAG.Socket.On(SocketIOEventTypes.Error, delegate(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
		{
			Debug.LogError($"Error: {HPMFCEDMMJO[0].ToString()}");
		});
		HKJMPIGDCAG.Open();
	}

	private static void BDEPGDCFPGM(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_NOTIFICATION_WEAPONUPGRADEDELIVERED", HPMFCEDMMJO[1].ToString()));
	}

	public void GGFNMNNLCPL()
	{
		HKJMPIGDCAG.Close();
	}

	public void AENEGPLDBAD()
	{
		HKJMPIGDCAG.Close();
	}

	public void OILDJGBFGJK()
	{
		HKJMPIGDCAG.Close();
	}

	public void HCCFKNAMHHB()
	{
		HKJMPIGDCAG.Close();
	}

	private static void PFLLAOKPHPI(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("Card_2_Played", HPMFCEDMMJO[0].ToString()));
	}

	private static void FMLOFKBDEEN(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("VipReward1", HPMFCEDMMJO[1].ToString()));
	}

	private void ACBHIOCHKLC(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ticketsSpent" + HPMFCEDMMJO[0]);
	}

	public void IGFENCHJFPA()
	{
		HKJMPIGDCAG.Close();
	}

	public void EAHCDHIHIPH()
	{
		HKJMPIGDCAG.Close();
	}

	private static void KPLEGMJAAAJ(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("dogTagTimerLock", HPMFCEDMMJO[1].ToString()));
	}

	public void MCDOLAKMDDB()
	{
		HKJMPIGDCAG.Close();
	}

	private static void GKGKCJMNIHL(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("T", HPMFCEDMMJO[0].ToString()));
	}

	public void MBIHMJMECEE()
	{
		HKJMPIGDCAG.Close();
	}

	private void APNNGFDFKPD(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("PlayerToKickId" + HPMFCEDMMJO[0]);
	}

	private static void ICCKBCPOPEH(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("RematchRPC", HPMFCEDMMJO[1].ToString()));
	}

	public void GEMJBHCLNBC()
	{
		HKJMPIGDCAG.Close();
	}

	public void PBJIDNPDKOD()
	{
		HKJMPIGDCAG.Close();
	}

	public void LCNIAOIDPME()
	{
		HKJMPIGDCAG.Close();
	}

	private static void DGANGDMJMNA(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("VIP bought", HPMFCEDMMJO[1].ToString()));
	}

	private static void KGPKPNABKBC(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("Tier", HPMFCEDMMJO[0].ToString()));
	}

	private static void PJLLGKGHNED(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("D2", HPMFCEDMMJO[1].ToString()));
	}

	public void DDLJFPGHHBE()
	{
		HKJMPIGDCAG.Close();
	}

	private void EKOCCGKDFIN(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, params object[] HPMFCEDMMJO)
	{
		Debug.Log("SH: New message = " + HPMFCEDMMJO[0]);
	}

	public void GFGJNPKNIJC()
	{
		HKJMPIGDCAG.Close();
	}

	private void DHAMGKDANDA(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("604 GAME END" + HPMFCEDMMJO[1]);
	}

	public void ADMBHEHPIMA()
	{
		HKJMPIGDCAG.Close();
	}

	private void CBJODOFINII(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("Emblem updated!" + HPMFCEDMMJO[1]);
	}

	public void JKHPDAOCGIF()
	{
		HKJMPIGDCAG.Close();
	}

	public void DJAAEEIJAEI()
	{
		HKJMPIGDCAG.Close();
	}

	public void KAJAJNHJBOD()
	{
		HKJMPIGDCAG.Close();
	}

	public void OBNJONGEOCE()
	{
		HKJMPIGDCAG.Close();
	}

	public void IEEDKJLBOCD()
	{
		HKJMPIGDCAG.Close();
	}

	public void JLGAGCOPJJN()
	{
		HKJMPIGDCAG.Close();
	}

	private void JNCFHJLMICG(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("\t\"TRUE\"" + HPMFCEDMMJO[1]);
	}

	private void BPJAHMILNIH(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("undefined" + HPMFCEDMMJO[0]);
	}

	public void HGHFKNDPPPH()
	{
		HKJMPIGDCAG.Close();
	}

	private static void AMPFHPFJBJJ(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("start", HPMFCEDMMJO[0].ToString()));
	}

	public void CHKAGJADLDH()
	{
		HKJMPIGDCAG.Close();
	}

	private void CBAMEECMIOF(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("{0} 1 / 3" + HPMFCEDMMJO[1]);
	}

	private void ENPABKAAIHA(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("color=\"#FFD700\"" + HPMFCEDMMJO[0]);
	}

	public void HKJCKKLMHEC()
	{
		HKJMPIGDCAG.Close();
	}

	public void IBMEFFLFMDD()
	{
		HKJMPIGDCAG.Close();
	}

	private void OOHFILLFGML(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ReconnectDialog Hide" + HPMFCEDMMJO[0]);
	}

	public void MPEELGDIALB()
	{
		HKJMPIGDCAG.Close();
	}

	private static void DJELHMHJGHO(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("GLM: RegisterOrLogin - NOT GameCenterProvider.instance.hasResponse!!!, use saved!", HPMFCEDMMJO[0].ToString()));
	}

	public void BKLIJHLADPC()
	{
		HKJMPIGDCAG.Close();
	}

	private static void KDEBENCCGED(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("Database Message: Error parsing message!! Auto Ignore! ", HPMFCEDMMJO[0].ToString()));
	}

	[CompilerGenerated]
	private static void BCHIHHIFFDK(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError($"Error: {HPMFCEDMMJO[0].ToString()}");
	}

	private static void AGDBIHIKFAL(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("response contain VipReward", HPMFCEDMMJO[1].ToString()));
	}

	private static void APFKKBEENKL(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("#DANIEL# Assignment Claimed: ", HPMFCEDMMJO[0].ToString()));
	}

	private void OIMJEHLJHNI(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("Vertical" + HPMFCEDMMJO[1]);
	}

	private static void BGJBGHKKADB(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("HighLevelGoldRarity", HPMFCEDMMJO[0].ToString()));
	}

	private void DGILIDPMGMA(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("open" + HPMFCEDMMJO[1]);
	}

	private static void KDPKJBHCHCH(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("hide", HPMFCEDMMJO[0].ToString()));
	}

	public void DNBKOHKONLN()
	{
		HKJMPIGDCAG.Close();
	}

	private static void AFJGMAKPBLP(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("Battle_End_Dialog", HPMFCEDMMJO[1].ToString()));
	}

	private static void FOPGGAAOIED(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_STAT_MISSIONSCOOP", HPMFCEDMMJO[0].ToString()));
	}

	public void CEKEGIAMCGO()
	{
		HKJMPIGDCAG.Close();
	}

	public void LEABCGCACBJ()
	{
		HKJMPIGDCAG.Close();
	}

	private static void GKGNNHKGPHD(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ShotFrequencyMin", HPMFCEDMMJO[1].ToString()));
	}

	private static void FFNOGAJMILF(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("armyPower", HPMFCEDMMJO[0].ToString()));
	}

	private static void OBHHOLMMIEG(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ChatTutorialMessage", HPMFCEDMMJO[0].ToString()));
	}

	private static void MKKJPICDHPO(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format(", type ", HPMFCEDMMJO[0].ToString()));
	}

	private void PLJLPEHMFFK(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ID_AGAINSTTHESAMEOPPONENT" + HPMFCEDMMJO[0]);
	}

	private static void MAECAFLGDDK(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("Subscription", HPMFCEDMMJO[0].ToString()));
	}

	private void LMLDLDJIOOO(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("Enemy could not be spawned" + HPMFCEDMMJO[0]);
	}

	private static void EMNPPLEKMFM(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_WAITINGFOROPPONENTCARDS", HPMFCEDMMJO[0].ToString()));
	}

	public void MCDOJIJEDFG()
	{
		HKJMPIGDCAG.Close();
	}

	private static void KIFLCGGGDGD(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_GUI_EQUIPPED", HPMFCEDMMJO[1].ToString()));
	}

	private void NHNLAODBEOG(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log(" " + HPMFCEDMMJO[0]);
	}

	private void EMPOMJHJMDP(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("playerId" + HPMFCEDMMJO[0]);
	}

	public void IDLGGMGFKEH()
	{
		HKJMPIGDCAG.Close();
	}

	private void BKLEOOFGKFJ(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("Chillingo: On Pause Drawing " + HPMFCEDMMJO[1]);
	}

	private static void ICOHPLBJFEE(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("{0} {1}", HPMFCEDMMJO[0].ToString()));
	}

	public void HDGHALILACC()
	{
		HKJMPIGDCAG.Close();
	}

	public void GMCJPBNACLD()
	{
		HKJMPIGDCAG.Close();
	}

	private void IOJFDGKIHMO(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ID_SQUADEVENT" + HPMFCEDMMJO[1]);
	}

	private void IJECEMIGLBE(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("source_id" + HPMFCEDMMJO[1]);
	}

	private void FALIMJGIDDJ(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("GameController.LoadAndStartNewMap - DONE" + HPMFCEDMMJO[0]);
	}

	public void KNNGFJOLJAC()
	{
		HKJMPIGDCAG.Close();
	}

	public void EBJJLNAPJON()
	{
		HKJMPIGDCAG.Close();
	}

	private static void PBFDDPGAMMI(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("GUI/2Dtoolkit/", HPMFCEDMMJO[0].ToString()));
	}

	public void OCDLHHLNHPK()
	{
		HKJMPIGDCAG.Close();
	}

	private void HBKPFJPCHNG(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("GLM: RegisterOrLogin -  9" + HPMFCEDMMJO[1]);
	}

	private void OBFGGNIFEPF(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ID_ACTIVATEINSTEADOF" + HPMFCEDMMJO[1]);
	}

	private void MBBJMLOGPBB(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.Log("ID_CATEGORY_ASSAULTRIFLE" + HPMFCEDMMJO[0]);
	}

	public void PFKPEEIBCFL()
	{
		HKJMPIGDCAG.Close();
	}

	public void ILPOHGFBBAE()
	{
		HKJMPIGDCAG.Close();
	}

	private static void ELFBCGNCNPF(Socket PKJFHJALIBK, Packet BKDCLBPFAIF, object[] HPMFCEDMMJO)
	{
		Debug.LogError(string.Format("ID_STARTERASSIGNMENT", HPMFCEDMMJO[0].ToString()));
	}
}
