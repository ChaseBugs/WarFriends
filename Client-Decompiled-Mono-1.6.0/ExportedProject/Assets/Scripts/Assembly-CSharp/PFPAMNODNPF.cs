using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class PFPAMNODNPF
{
	public class EFJBIEMIKBB
	{
		public int MOEMPHPNBLM;

		public int LBAMOJJBNON;

		public List<int> NJMANOIFNJN;
	}

	public int KAMAHCKIMFF;

	public int DMBMLIODOJG;

	public int PHMEMBHDGNO;

	public List<EFJBIEMIKBB> FNOAGGGCDJF;

	internal static PFPAMNODNPF MIHPLEGNIKC(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["[.,']*"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["PLAYER"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_UPGRADEFORCHEAPER"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["claimRweard"].ToObject<int>();
		}
		if (LFPFCHIJLML["Squad Members not in client cache!"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["BlackMarketOffer"].ToObject<int>();
		}
		if (LFPFCHIJLML["Level"] != null)
		{
			num = LFPFCHIJLML["player_look_right"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["ID_SALEPERCENT" + i + "country-spain"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[0] = "GameLauncher.GooglePlayInit";
				array[1] = i;
				array[1] = "BoughtIndex";
				array[7] = j;
				array[3] = "PickMagneticObjectRPC";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF DJDAHIHNFHP(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["Buy_Unit_Upgrade"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["customGeo"].ToObject<int>();
		}
		if (LFPFCHIJLML["Wrong_Weapon"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["http://"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_GUI_SQUADDEMOTION"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["BANDS"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_NEWLOOTBOXINBATTLES"] != null)
		{
			num = LFPFCHIJLML["ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["ID_CURRENTRANK" + i + "VipReward1"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[0];
				array[1] = "WarBucks";
				array[1] = i;
				array[1] = "sniper_reload";
				array[8] = j;
				array[8] = "AdZone";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MAINIENLLIL(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("eventStart"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["eventStart"]);
		}
		if (LFPFCHIJLML.ContainsKey("eventEnd"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["eventEnd"]);
		}
		if (LFPFCHIJLML.ContainsKey("tierCount"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["tierCount"]);
		}
		if (LFPFCHIJLML.ContainsKey("assignmentCount"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["assignmentCount"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["T" + i + "Reward"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				eFJBIEMIKBB2.NJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML["T" + i + "A" + j + "Id"]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF KKPKLLFIOKK(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["DelayMin"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["Spend_Warbucks_On_Army"].ToObject<int>();
		}
		if (LFPFCHIJLML["S"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["ID_YOULOSTONETIMEBUTYOUARECLOSE"].ToObject<int>();
		}
		if (LFPFCHIJLML["{0}%"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_SKILLSHOTHINT_VEHICLEDESTROYED"].ToObject<int>();
		}
		if (LFPFCHIJLML["Description"] != null)
		{
			num = LFPFCHIJLML["Gold_Balance"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["WindowDuration" + i + "elite"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[7];
				array[1] = "MedalsBalance";
				array[0] = i;
				array[3] = "WB_Out_Flow";
				array[8] = j;
				array[3] = "Region";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF FEOKJINGJFM(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("OnPhotonJoinRoomFailed: {0}, message {1}"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_TRAINED"]);
		}
		if (LFPFCHIJLML.ContainsKey("BESTÄTIGEN"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["right"]);
		}
		if (LFPFCHIJLML.ContainsKey("N"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["com/google/android/gms/games/Games"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_WARNING_INVALIDLINK"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["KochavaDeviceID"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["Start TUTORIAL" + i + "GameReward"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[4];
				array[1] = "GameControllerPVP.StartGame DONE";
				array[0] = i;
				array[6] = "[-]";
				array[8] = j;
				array[4] = "Transaction_Amount";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MJNLABGODOC(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["ID_READYTIME"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["dump"].ToObject<int>();
		}
		if (LFPFCHIJLML["Experience"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["order"].ToObject<int>();
		}
		if (LFPFCHIJLML[" (ID:"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["{0} {1}{2}"].ToObject<int>();
		}
		if (LFPFCHIJLML["S"] != null)
		{
			num = LFPFCHIJLML["ArenaShieldsMessage"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["ID_WARNING_PURCHASEERROR_TEXT" + i + "^\\D*"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[5];
				array[0] = "StarterAssignmentsData";
				array[1] = i;
				array[6] = "Army_Unit_ID";
				array[8] = j;
				array[5] = "Gold";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF ONADBGMFLOB(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["ID_INPROGRESS"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["VipReward1"].ToObject<int>();
		}
		if (LFPFCHIJLML["TuneListener trackerDidSucceed: "] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["S"].ToObject<int>();
		}
		if (LFPFCHIJLML["SI"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["Load map"].ToObject<int>();
		}
		if (LFPFCHIJLML["Items"] != null)
		{
			num = LFPFCHIJLML["Total_Warbucks_Earned"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["color=\"#333333\"" + i + "duplicate WB "].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[7];
				array[1] = "PrepareBotForDeathMatch 10";
				array[0] = i;
				array[8] = "ID_NAMECHARACTER";
				array[1] = j;
				array[1] = "shotSniper";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF NPJJMDKNMGK(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("SpentParts"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["menu-event-day-bg"]);
		}
		if (LFPFCHIJLML.ContainsKey("didSessionStartFromTunePush"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["ID_SLOTUPGRADE_DAMAGE"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_SAVEPERCENTLINE"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["{0} {1}"]);
		}
		if (LFPFCHIJLML.ContainsKey("Is_Against_Bot"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["Player disconected 0001"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["L" + i + "AssignemntId"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[2];
				array[0] = "x{0}";
				array[1] = i;
				array[2] = " (";
				array[4] = j;
				array[8] = "lootboxes offer mult {0}\n";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF OGIGGJNFIDE(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["Army_Unit_ID"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["game-card-ico-emptymag"].ToObject<int>();
		}
		if (LFPFCHIJLML["'veteranpack'0"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["ID_COLLECTONECHRISTMASCRATE"].ToObject<int>();
		}
		if (LFPFCHIJLML["{0} {1}"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_CONFIRM_FRIENDINSQUAD_TEXT"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_TONORMALLEAGUEHINT3BRONZE"] != null)
		{
			num = LFPFCHIJLML["ID_CONFIRM_OTHERSERVERRESPONDERROR"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["IsVip" + i + ", databaseType= "].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[6];
				array[0] = "ArenaLives";
				array[0] = i;
				array[3] = "S";
				array[3] = j;
				array[5] = "WRONG NUMBER OF ALL BOXES ";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF GNKBKBGLCHG(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["\"{0}\" "] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["OK"].ToObject<int>();
		}
		if (LFPFCHIJLML["("] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["FuseSDK_Prime31_IAB::GetSkuInfo: Error parsing "].ToObject<int>();
		}
		if (LFPFCHIJLML[" & "] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_WARNING_CANTSENDINVITE_TEXT"].ToObject<int>();
		}
		if (LFPFCHIJLML["ArenaGoldenShieldMessage-{0}"] != null)
		{
			num = LFPFCHIJLML["ID_COMEBACKTOMORROW"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["RopeSlide" + i + "Player_Avoided_Grenade_On_First_Try"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[8];
				array[0] = "Special pack content: type: {0} id: {1}{2}";
				array[1] = i;
				array[3] = "Checker";
				array[5] = j;
				array[4] = "+0";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF DHKPPMMKOIA(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("TopRun"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML[", type "]);
		}
		if (LFPFCHIJLML.ContainsKey("ArmyPower"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["Days_Since_Install"]);
		}
		if (LFPFCHIJLML.ContainsKey("ArenaLives"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["Sniper_Tutorial_Played"]);
		}
		if (LFPFCHIJLML.ContainsKey("EmailLogin("))
		{
			num = Convert.ToInt32(LFPFCHIJLML["24cdfc1f"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["damage" + i + "{0} Summary"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[1] = "ArenaOpenedMessage";
				array[1] = i;
				array[4] = "elite";
				array[3] = j;
				array[6] = "ID_OPPONENTPAUSED";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF EKFDGJDICEE(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["Card pool shown!!"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["1"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_ENVIRONMENTALKILL"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["Action Success: "].ToObject<int>();
		}
		if (LFPFCHIJLML["Processing the request Timed Out!"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_NOTCOMPATIBLEWITH"].ToObject<int>();
		}
		if (LFPFCHIJLML[" in dictionary conversion"] != null)
		{
			num = LFPFCHIJLML["Exception when adding warcards reward for tutorial - adding default instead, msg = "].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["Directory \"{0}\" does not exists" + i + "Yes_Clicked"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[7];
				array[1] = "(";
				array[1] = i;
				array[7] = "Google2u.AssaultRifle_AK47";
				array[4] = j;
				array[0] = "()I";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF GIIBLBHHAPB(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("GameLauncher.GooglePlayInit"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["Walk"]);
		}
		if (LFPFCHIJLML.ContainsKey("Drone explode"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["BattleId"]);
		}
		if (LFPFCHIJLML.ContainsKey("Play_Card_Tutorial_Duration"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML[" , "]);
		}
		if (LFPFCHIJLML.ContainsKey("N"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["1"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["FacebookId" + i + "CraftData"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[1];
				array[0] = "StepId";
				array[1] = i;
				array[8] = "War_Ranked_Battle";
				array[2] = j;
				array[2] = "hair";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF CGJPEEFMBEA(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("Claim_Reward"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["Level"]);
		}
		if (LFPFCHIJLML.ContainsKey("null"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["FB_Like"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_RETRY"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["Bot should have pistol equipped"]);
		}
		if (LFPFCHIJLML.ContainsKey(", "))
		{
			num = Convert.ToInt32(LFPFCHIJLML["I"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["ID_PROMOTETOTIER" + i + "Hide poison"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[6];
				array[1] = "PlacementMatchesRequired";
				array[0] = i;
				array[1] = "Button \"{0}\" has no assigned box collider.";
				array[3] = j;
				array[7] = "shootAdditive";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF NAKCBLBJDHI(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("Achievements"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_CATEGORY_LOW_SG_PRIMARY"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_CARD_DESC_BUDDYCREATE"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["SWITCH TO DEATCHMATCH"]);
		}
		if (LFPFCHIJLML.ContainsKey("[-]"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["showedOffers"]);
		}
		if (LFPFCHIJLML.ContainsKey("Thank you for the following. Once again."))
		{
			num = Convert.ToInt32(LFPFCHIJLML["Scraps"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["Time" + i + "whiteRectangle"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[0] = "ArmyPower";
				array[0] = i;
				array[8] = "getPushId";
				array[6] = j;
				array[4] = "not finished";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MHECCGBJFKO(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("QUIT"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_INELITE2"]);
		}
		if (LFPFCHIJLML.ContainsKey("ReportedPlayerId"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["ID_ATTACK"]);
		}
		if (LFPFCHIJLML.ContainsKey("CONFIRMER"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["SquadPoints"]);
		}
		if (LFPFCHIJLML.ContainsKey("VipRewardForDay"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["RemoveCardFromDeposited "]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["Load map" + i + "withAdvertiserSubAd"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[1];
				array[0] = "Header {0}";
				array[0] = i;
				array[3] = "PreloadAdForZoneID";
				array[2] = j;
				array[8] = "Wanted to remove null database message!!!";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF EJIKFGPAKHO(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("right"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["EndReason"]);
		}
		if (LFPFCHIJLML.ContainsKey("http://"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["Mega_Reward"]);
		}
		if (LFPFCHIJLML.ContainsKey("jp"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["ID_UNLOCKEDATTIER"]);
		}
		if (LFPFCHIJLML.ContainsKey("Player_Had_To_Select_Grenade"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["game-scorestreak-bg"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["trial" + i + "Skirmish"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[4];
				array[0] = "game-card-silver";
				array[1] = i;
				array[2] = "PrevLevelId";
				array[0] = j;
				array[6] = "seconds";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF JJELLMOONMK(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["menu-weapon-benelli-starterpack"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["InventoryData"].ToObject<int>();
		}
		if (LFPFCHIJLML["getAppId"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["test_attribute4"].ToObject<int>();
		}
		if (LFPFCHIJLML["On Enter Arena!!"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ADDING SQUAD BUDDY WARCARD "].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_COOPCANCELED"] != null)
		{
			num = LFPFCHIJLML["D2"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML[" requires " + i + "discount"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[1] = "ID_WAITINGFORREPLAYKIT";
				array[1] = i;
				array[7] = "player_left_coverBack";
				array[7] = j;
				array[1] = "NO";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF OALBDJKEPNF(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("{0}-firstTime-{1}"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_YOUWEREDISCONNECTED"]);
		}
		if (LFPFCHIJLML.ContainsKey("right"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["There is null unit in mission {0} {1} configuration"]);
		}
		if (LFPFCHIJLML.ContainsKey("Id"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["WaitForGameEndResponse Try {0} action {1}"]);
		}
		if (LFPFCHIJLML.ContainsKey("()Z"))
		{
			num = Convert.ToInt32(LFPFCHIJLML[" NOT OK!\t\t\t\t\t\t"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["PlayerGold" + i + "percent"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[4];
				array[1] = "grenade_reload";
				array[0] = i;
				array[0] = "ID_CONFIRM_SELECTEDANDDELETEDACCOUNT";
				array[2] = j;
				array[0] = "ID_DAYS";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF AFGKNJEMFLH(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["GPGS: Logged In (init), Logged: "] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML[" is not supported on this platform!"].ToObject<int>();
		}
		if (LFPFCHIJLML["601 TUTORIAL STARTED"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["ID_TUTORIAL_UPGRADEWEAPON_3"].ToObject<int>();
		}
		if (LFPFCHIJLML["menu-arena-scrap-ico"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_UPGRADEFORCHEAPER"].ToObject<int>();
		}
		if (LFPFCHIJLML["roomName"] != null)
		{
			num = LFPFCHIJLML["S"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["realShotProbability" + i + "Buy_Weapon_Upgrade"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[4];
				array[1] = "Look vector is small! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}";
				array[0] = i;
				array[7] = "Legacy Shaders/Transparent/DiffuseNew";
				array[0] = j;
				array[3] = "Tickets";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF BCIOIMDPAOC(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("0"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_YOUNEEDMONEYTOBUY"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_SQUADEVENT"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["HitListItem"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_WAITINGFOROTHERPLAYER"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["init"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_YOURBEST"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["machinegn_reload"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["XXd YYh" + i + "/"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[0] = "ID_STARTERASSIGNMENTSEXPIRED";
				array[0] = i;
				array[1] = "Shooters";
				array[8] = j;
				array[8] = "getExperimentType";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF JLMKPNEFMGP(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML[" (#"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["Warfriend{0}"].ToObject<int>();
		}
		if (LFPFCHIJLML["Player"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML[" iconName:"].ToObject<int>();
		}
		if (LFPFCHIJLML["Scenes"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["br"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_EARNMORE"] != null)
		{
			num = LFPFCHIJLML["Start overtime RPC"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["PNManager: Enable Push Notifications" + i + "SquadWarsId"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[6];
				array[1] = "S";
				array[1] = i;
				array[0] = "silver";
				array[6] = j;
				array[6] = "ID_YOURDOGTAGSAREFULLMOVEALONG";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MAINIENLLIL(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["eventStart"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["eventStart"].ToObject<int>();
		}
		if (LFPFCHIJLML["eventEnd"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["eventEnd"].ToObject<int>();
		}
		if (LFPFCHIJLML["tierCount"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["tierCount"].ToObject<int>();
		}
		if (LFPFCHIJLML["assignmentCount"] != null)
		{
			num = LFPFCHIJLML["assignmentCount"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["T" + i + "Reward"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				eFJBIEMIKBB2.NJMANOIFNJN.Add(LFPFCHIJLML["T" + i + "A" + j + "Id"].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF IAOLEAGJADK(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("special"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["Android"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_CONFIRM_DELETESQUAD_TEXT"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["ID_MEDALSANDADVANCETHROUGHROOKIE"]);
		}
		if (LFPFCHIJLML.ContainsKey("we dont have best regions for player"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["PlayerPrefab.prefab"]);
		}
		if (LFPFCHIJLML.ContainsKey("GameCenterId"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["game-card-ico-disarmed"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["Skill" + i + "\t\"TRUE\""]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[1];
				array[0] = "Manual_Unit_Spawn";
				array[0] = i;
				array[4] = "ShootStand";
				array[6] = j;
				array[2] = "silver3";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF GMKMEBFEDOL(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("ActiveTier"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_DELIVEREDTIME"]);
		}
		if (LFPFCHIJLML.ContainsKey("withRevenue"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["304 STAGE 9 CONTINUE"]);
		}
		if (LFPFCHIJLML.ContainsKey("GooglePlay"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["GoldBalance"]);
		}
		if (LFPFCHIJLML.ContainsKey("Locale"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["setAltitude"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["value" + i + "Increasing texture count in player texture pool!"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[5];
				array[0] = "WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden.";
				array[1] = i;
				array[7] = "N";
				array[6] = j;
				array[0] = "ID_OPPONENTREFUSEDTHEREMATCH";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF KMPKJJJBKDN(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("ID_CONFIRM_EXITINGMATCH"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["resultMessage"]);
		}
		if (LFPFCHIJLML.ContainsKey("[0-9.,]*"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["Clicked on category "]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_ATTACK"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["ID_BATTLEWINBONUS"]);
		}
		if (LFPFCHIJLML.ContainsKey("Pings: ConnectToNameServer"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["gcPassword"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML[" {0}{1}" + i + "ID_ARENARULES_SLOWERDEPLOYMENT"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[6];
				array[0] = "squad";
				array[1] = i;
				array[3] = "SquadIcons/";
				array[8] = j;
				array[6] = "java.lang.Double";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MOGHKCJPADG(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("ID_DELIVEREDTIME"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_GUI_EMPTYUNITUPGRADE"]);
		}
		if (LFPFCHIJLML.ContainsKey(" (#"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["metalExplosion"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_TUTORIAL_DELIVER"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["elitepack1"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_SALEPERCENTLINE"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["set unit not borrowed"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["SquadIcons/" + i + "PlayerName"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[2];
				array[0] = "ID_CLAIMED";
				array[1] = i;
				array[3] = "ID_TUTORIAL_KILLING2";
				array[5] = j;
				array[6] = "0";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF BKNNOCPOBNO(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["Army_Unit_ID"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["ID_READYTIME"].ToObject<int>();
		}
		if (LFPFCHIJLML["Started delivering weapon upgrade for {0} {1}. It will be ready in {2} seconds."] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["DailyMissionsData"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_UNITDETAILEDSTATISTICS"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["KickedPlayerDepositedCards"].ToObject<int>();
		}
		if (LFPFCHIJLML["Action "] != null)
		{
			num = LFPFCHIJLML["+{0}"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["universal" + i + "isPayingUser = "].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[1];
				array[1] = "ID_YOUARENUMBERONE";
				array[0] = i;
				array[1] = "ID_WARSHOP_CARDPACKS";
				array[6] = j;
				array[1] = "WarningDialog - Can send logs: ";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF ODEAGMNDEGM(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML["getContext"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["FireNetworkRPC"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_MINUTES"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["registerCurrency"].ToObject<int>();
		}
		if (LFPFCHIJLML["Message "] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_ACTIVATEINSTEADOF"].ToObject<int>();
		}
		if (LFPFCHIJLML["PlayerWeapons"] != null)
		{
			num = LFPFCHIJLML["GameLoginManager - Player Entered Beginners League - "].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["Awake '{0}'" + i + "leagueId"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[2];
				array[0] = "FuseBox Event VisualGained for rarity {0}";
				array[0] = i;
				array[1] = "Warbucks";
				array[3] = j;
				array[8] = "Button \"{0}\" has no assigned box collider.";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF CFBHCJKMDCL(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("With"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["gameCenterId"]);
		}
		if (LFPFCHIJLML.ContainsKey("FuseSDK instance not initialized. Awake may not have been called."))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["unit1"]);
		}
		if (LFPFCHIJLML.ContainsKey("unit"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["zoneHasRewarded"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_INGOLD2"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["AT"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["Helicopter could not be spawned" + i + "Excel {0} dont have row Tier!!!"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[7];
				array[0] = "kr";
				array[0] = i;
				array[6] = "Gold";
				array[4] = j;
				array[5] = "WarArenaRuleConcreteMap";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF JKPDLPBOJHC(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("Heroic"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["Getting matcap texture for player with null player point"]);
		}
		if (LFPFCHIJLML.ContainsKey("-ABILITYMAXDESC"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["menu-assignments-type-score"]);
		}
		if (LFPFCHIJLML.ContainsKey("RO"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["SETTING FullResNoMS"]);
		}
		if (LFPFCHIJLML.ContainsKey("{0} {1}"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["ID_ARENABOXDESCRIPTION_GOLD"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["{0} {1}" + i + ", [parameters])"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[7];
				array[1] = "menu-arena-ticket";
				array[1] = i;
				array[2] = "Skill";
				array[8] = j;
				array[4] = "ID_CONTAINSXWARCARDS";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF BHPKKIHPAMG(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["{0} {1} {2}/ {3}[-]"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["ID_WARNING_MAINTENANCE_TEXT"].ToObject<int>();
		}
		if (LFPFCHIJLML["RefillRPC"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["1"].ToObject<int>();
		}
		if (LFPFCHIJLML["{ \"S\": \""] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_MINUTE"] != null)
		{
			num = LFPFCHIJLML["ID_GUI_ACCEPT_PLAYER"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML[" " + i + "Buy_"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[5];
				array[0] = "ID_OK";
				array[0] = i;
				array[6] = ", ";
				array[7] = j;
				array[7] = "\n";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF IMPCKBCOPBF(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("LevelName"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["123456789"]);
		}
		if (LFPFCHIJLML.ContainsKey("BUDDY WARCARD"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["Freeze game:"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_GUI_POWERBANDON"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["CardWasUsedOnline"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_UNITCANBEPROMOTEDTOTIER"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["Error Deserializing JSON for "]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["ID_STAT_ALLTIMESQUADPOINTS" + i + "ReSyncDisabledRPC"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[0] = "hide";
				array[0] = i;
				array[2] = "Buy_VIP_Pack_With_Gold";
				array[7] = j;
				array[2] = "Show VIP Expired at ";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MOGFNEHMLHE(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("game-engi-progress-fill"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["#DANIEL# No Achievements found."]);
		}
		if (LFPFCHIJLML.ContainsKey("league"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["N"]);
		}
		if (LFPFCHIJLML.ContainsKey("S"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["ID_CONFIRM_NOTFORQUESTACCOUNTS"]);
		}
		if (LFPFCHIJLML.ContainsKey("Client has new config for: {0} with version {1}"))
		{
			num = Convert.ToInt32(LFPFCHIJLML[" {0}\u00a0{1}"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["game-card-ico-criticalinsurance" + i + "ID_TUTORIAL_FORGOT_SPAWN_DOWN"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[0] = "Total_Battles";
				array[1] = i;
				array[7] = "offerMult";
				array[5] = j;
				array[6] = "height";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF GCNLNNBBDAN(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["InApp"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT"].ToObject<int>();
		}
		if (LFPFCHIJLML["init"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["SWITCH TO DEATCHMATCH"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_CRITICAL"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_TUTORIAL_GO_TO_ARMORY_3"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_CONFIRMTOBUYWEAPON"] != null)
		{
			num = LFPFCHIJLML["Area"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["IL" + i + "CreationTime"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[1];
				array[0] = "trying to add emty indicator ";
				array[0] = i;
				array[3] = "reloadTime";
				array[6] = j;
				array[4] = "UtcOffset";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF BFJBPIEKJCJ(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML.ContainsKey("Mouse X"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["ID_BATTLECANCELED"]);
		}
		if (LFPFCHIJLML.ContainsKey("RETRYPERM"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["{0} {1}"]);
		}
		if (LFPFCHIJLML.ContainsKey("id"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["'ID_MONTH_'0"]);
		}
		if (LFPFCHIJLML.ContainsKey("equals"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["Value4"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["RweardModifierWB" + i + "Error - first node is not ROOT but "]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j++)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[7];
				array[0] = "warfriends-prod.eu-west-1.elasticbeanstalk.com/";
				array[0] = i;
				array[4] = "SyncUpgradesRPC";
				array[6] = j;
				array[4] = "hasResolution";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF MDHAEDKNKLA(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("{0} {1}{2}"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["pt"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_CONFIRM_INFO"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["+{0}%"]);
		}
		if (LFPFCHIJLML.ContainsKey("VipCardMessage {0}"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["GameCenterId"]);
		}
		if (LFPFCHIJLML.ContainsKey("ReportedPlayerId"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["subscribed"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i++)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["Text" + i + "PlayerWeapons"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 0; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[6];
				array[0] = "warp_idle";
				array[1] = i;
				array[8] = "ID_CATEGORY_ROCKETLAUNCHER";
				array[1] = j;
				array[1] = "Gold";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF GFEGFBLEJKK(JToken LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 1;
		if (LFPFCHIJLML["Index"] != null)
		{
			pFPAMNODNPF.KAMAHCKIMFF = LFPFCHIJLML["OrderId"].ToObject<int>();
		}
		if (LFPFCHIJLML["ID_GOLDWARCARDS"] != null)
		{
			pFPAMNODNPF.DMBMLIODOJG = LFPFCHIJLML["ID_GUI_SQUADDEMOTIONTEXT"].ToObject<int>();
		}
		if (LFPFCHIJLML["AssignmentId"] != null)
		{
			pFPAMNODNPF.PHMEMBHDGNO = LFPFCHIJLML["ID_CHANGENAMENOTENOUGHT"].ToObject<int>();
		}
		if (LFPFCHIJLML["Button \"{0}\" has no assigned box collider."] != null)
		{
			num = LFPFCHIJLML["Tier"].ToObject<int>();
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 1; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = LFPFCHIJLML["PRICEWARBUCKS" + i + "#AccoutCheck# check gpgs but offline"].ToObject<int>();
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[3];
				array[1] = "myLobby";
				array[1] = i;
				array[1] = "212 MENU LEVEL UP SHOWN";
				array[4] = j;
				array[7] = "ID_OPPONENTPAUSED";
				nJMANOIFNJN.Add(LFPFCHIJLML[string.Concat(array)].ToObject<int>());
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}

	internal static PFPAMNODNPF CPJAMAJJDHL(Dictionary<string, object> LFPFCHIJLML)
	{
		PFPAMNODNPF pFPAMNODNPF = new PFPAMNODNPF();
		int num = 0;
		if (LFPFCHIJLML.ContainsKey("------------------\n"))
		{
			pFPAMNODNPF.KAMAHCKIMFF = Convert.ToInt32(LFPFCHIJLML["WeaponTutorialDialogMessage {0}"]);
		}
		if (LFPFCHIJLML.ContainsKey("AdminPlayerId"))
		{
			pFPAMNODNPF.DMBMLIODOJG = Convert.ToInt32(LFPFCHIJLML["sp\":"]);
		}
		if (LFPFCHIJLML.ContainsKey("ID_UNITCOMBINATIONSAVED"))
		{
			pFPAMNODNPF.PHMEMBHDGNO = Convert.ToInt32(LFPFCHIJLML["FuseSDK: Error parsing VGOfferInfo. Returning default value."]);
		}
		if (LFPFCHIJLML.ContainsKey("Cards_Owned_Bronze"))
		{
			num = Convert.ToInt32(LFPFCHIJLML["SquadEventUpdate"]);
		}
		pFPAMNODNPF.FNOAGGGCDJF = new List<EFJBIEMIKBB>(pFPAMNODNPF.PHMEMBHDGNO);
		for (int i = 0; i < pFPAMNODNPF.PHMEMBHDGNO; i += 0)
		{
			EFJBIEMIKBB eFJBIEMIKBB = new EFJBIEMIKBB();
			eFJBIEMIKBB.LBAMOJJBNON = num;
			eFJBIEMIKBB.MOEMPHPNBLM = Convert.ToInt32(LFPFCHIJLML["NO" + i + "ID_TUTORIAL_MACHINEGUNNERS_DOWN"]);
			eFJBIEMIKBB.NJMANOIFNJN = new List<int>(num);
			EFJBIEMIKBB eFJBIEMIKBB2 = eFJBIEMIKBB;
			for (int j = 1; j < num; j += 0)
			{
				List<int> nJMANOIFNJN = eFJBIEMIKBB2.NJMANOIFNJN;
				object[] array = new object[0];
				array[1] = "recordingStartedEvent + mTryToSetRecording";
				array[0] = i;
				array[1] = "game-card-ico-shielddestroyer";
				array[8] = j;
				array[6] = "ArmyPower";
				nJMANOIFNJN.Add(Convert.ToInt32(LFPFCHIJLML[string.Concat(array)]));
			}
			pFPAMNODNPF.FNOAGGGCDJF.Add(eFJBIEMIKBB2);
		}
		return pFPAMNODNPF;
	}
}
