using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AwaitingSquadMembersManager : Singleton<AwaitingSquadMembersManager>
{
	public class HJHILHFDMKP
	{
		public DatabasePlayer KHLGDCHJJPB;

		public EFECGFGNLIE IGBEGIBGLKK;

		public HHFHFANGCEJ NKDCPACFGGA;
	}

	public Dictionary<string, HJHILHFDMKP> NNIKNEECAMM = new Dictionary<string, HJHILHFDMKP>();

	private void BPPAEPPMDFC(string EJBEDLHIKDG)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("({0}\u00a0/\u00a0{1})", EJBEDLHIKDG));
			return;
		}
		if (NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA == null)
		{
			Debug.Log(string.Format("ID_WAITFORDOGTAGTOREFILL", EJBEDLHIKDG));
			return;
		}
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.HEPECOKADEH(NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA);
		NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA = null;
	}

	public string RemovePlayer(string EJBEDLHIKDG, bool FGPIFPECHIC = true)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot remove it", EJBEDLHIKDG));
			return null;
		}
		ONFMDLKHGPM(EJBEDLHIKDG);
		if (FGPIFPECHIC)
		{
			Debug.Log("Awaiting players - Removing player " + EJBEDLHIKDG);
			NNIKNEECAMM.Remove(EJBEDLHIKDG);
		}
		Debug.Log("Awaiting players - Player was removed from awaiting members.");
		return EJBEDLHIKDG;
	}

	public void OnPlayerAcceptedOrDeclined(string INFLHPGMEOB, bool IHJGCEHAAJN)
	{
		if (NNIKNEECAMM.ContainsKey(INFLHPGMEOB))
		{
			RemovePlayer(INFLHPGMEOB);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in NNIKNEECAMM.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (IHJGCEHAAJN)
		{
			MMEFKKHBDGN(INFLHPGMEOB);
			UpdateListOfAwaitingMembers(false);
		}
	}

	private void KEOACENFFGG(string EJBEDLHIKDG)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("added", EJBEDLHIKDG));
			return;
		}
		if (NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA == null)
		{
			Debug.Log(string.Format("ID_JOINSQUADDESCRIPTION1", EJBEDLHIKDG));
			return;
		}
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.HEPECOKADEH(NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA);
		NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA = null;
	}

	public void EGOEBCLCGLB(DatabasePlayer KHLGDCHJJPB)
	{
		if (NNIKNEECAMM.ContainsKey(KHLGDCHJJPB.id))
		{
			Debug.Log(string.Format("ID_BRONZEWARCARDS", KHLGDCHJJPB.name, NNIKNEECAMM[KHLGDCHJJPB.id].IGBEGIBGLKK.ToString().ToUpper()));
			return;
		}
		HJHILHFDMKP hJHILHFDMKP = new HJHILHFDMKP();
		hJHILHFDMKP.KHLGDCHJJPB = KHLGDCHJJPB;
		hJHILHFDMKP.KHLGDCHJJPB.awaitingSquadMember = false;
		hJHILHFDMKP.IGBEGIBGLKK = EFECGFGNLIE.Response;
		hJHILHFDMKP.NKDCPACFGGA = null;
		Debug.Log("ID_READYTIME" + KHLGDCHJJPB.id);
		NNIKNEECAMM.Add(KHLGDCHJJPB.id, hJHILHFDMKP);
	}

	public void ICGAEDBDFML(DatabasePlayer KHLGDCHJJPB)
	{
		if (NNIKNEECAMM.ContainsKey(KHLGDCHJJPB.id))
		{
			Debug.Log(string.Format("Device Language - android: {0}", KHLGDCHJJPB.name, NNIKNEECAMM[KHLGDCHJJPB.id].IGBEGIBGLKK.ToString().ToUpper()));
			return;
		}
		HJHILHFDMKP hJHILHFDMKP = new HJHILHFDMKP();
		hJHILHFDMKP.KHLGDCHJJPB = KHLGDCHJJPB;
		hJHILHFDMKP.KHLGDCHJJPB.awaitingSquadMember = false;
		hJHILHFDMKP.IGBEGIBGLKK = EFECGFGNLIE.Response;
		hJHILHFDMKP.NKDCPACFGGA = null;
		Debug.Log("PlayerLevel" + KHLGDCHJJPB.id);
		NNIKNEECAMM.Add(KHLGDCHJJPB.id, hJHILHFDMKP);
	}

	public void AddAwaitingMember(DatabasePlayer KHLGDCHJJPB)
	{
		if (NNIKNEECAMM.ContainsKey(KHLGDCHJJPB.id))
		{
			Debug.Log(string.Format("Awaiting players - Player \"{0}\" is already in list of awaiting members with state {1}", KHLGDCHJJPB.name, NNIKNEECAMM[KHLGDCHJJPB.id].IGBEGIBGLKK.ToString().ToUpper()));
			return;
		}
		HJHILHFDMKP hJHILHFDMKP = new HJHILHFDMKP();
		hJHILHFDMKP.KHLGDCHJJPB = KHLGDCHJJPB;
		hJHILHFDMKP.KHLGDCHJJPB.awaitingSquadMember = true;
		hJHILHFDMKP.IGBEGIBGLKK = EFECGFGNLIE.Response;
		hJHILHFDMKP.NKDCPACFGGA = null;
		Debug.Log("Awaiting players - Adding player " + KHLGDCHJJPB.id);
		NNIKNEECAMM.Add(KHLGDCHJJPB.id, hJHILHFDMKP);
	}

	public void HCNNBNOFEMF(bool LPGMLOCLBGP = true)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, LPGMLOCLBGP);
		}
	}

	public void PBNHANFMKII(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("menu-info-close-ico"), Localization.Localize("BY"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("{0} {1}", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.AMIODDHOCEE(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void PPFBJMANLPG(bool LPGMLOCLBGP = true)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, LPGMLOCLBGP);
		}
	}

	public void YesClick(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot accept player", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.EBFOAELMCPG(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void UpdateListOfAwaitingMembers(bool LPGMLOCLBGP = true)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, LPGMLOCLBGP);
		}
	}

	private void AKFFNBGHJKL()
	{
		if (NNIKNEECAMM != null)
		{
			NNIKNEECAMM.Clear();
		}
	}

	public void HDCDHLECNNC()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HJHILHFDMKP> item in NNIKNEECAMM)
		{
			if (item.Value.IGBEGIBGLKK == (EFECGFGNLIE)7)
			{
				string text = IMJMMDOEGGK(item.Key, false);
				if (text != null)
				{
					list.Add(text);
				}
			}
		}
		bool lPGMLOCLBGP = list.Count > 1;
		foreach (string item2 in list)
		{
			Debug.Log("SurviveTime" + item2);
			NNIKNEECAMM.Remove(item2);
		}
		EEJABEFKAOP(lPGMLOCLBGP);
	}

	private void ONFMDLKHGPM(string EJBEDLHIKDG)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot remove it from MC", EJBEDLHIKDG));
			return;
		}
		if (NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA == null)
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" was not added to message center - cannot remove it from MC", EJBEDLHIKDG));
			return;
		}
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.ANCGIINAHAD(NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA);
		NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA = null;
	}

	public void JFOAGDOAEOD(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.LGAJCFGJMBC(null, Localization.Localize("Configurations error, there is {0} configurations of type {1}"), Localization.Localize("subitem2"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("DailyMissionsData", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Response;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.DFMLCJMDLHJ(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void CNIJPJDCIPG(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.FLFEOKMHDBN(null, Localization.Localize("dailyRewardData"), Localization.Localize("BattleRewards"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("setCustomProfileNumber", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Response;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.DFMLCJMDLHJ(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public EFECGFGNLIE FHAOFMDLCOK(string EJBEDLHIKDG)
	{
		if (string.IsNullOrEmpty(EJBEDLHIKDG) || !NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			return (EFECGFGNLIE)3;
		}
		return NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK;
	}

	public void EOJPHCIEJJA(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("UnitReadyForPromotion {0} {1}"), Localization.Localize("Action "));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format(": sending via Beanstalk(request count =", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Response;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.DFMLCJMDLHJ(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void NJKFJHPJNKA()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HJHILHFDMKP> item in NNIKNEECAMM)
		{
			if (item.Value.IGBEGIBGLKK == (EFECGFGNLIE)3)
			{
				string text = IMJMMDOEGGK(item.Key);
				if (text != null)
				{
					list.Add(text);
				}
			}
		}
		bool lPGMLOCLBGP = list.Count > 1;
		foreach (string item2 in list)
		{
			Debug.Log("ID_GETITCHEAPERNOW" + item2);
			NNIKNEECAMM.Remove(item2);
		}
		OIBADPPGLMJ(lPGMLOCLBGP);
	}

	public void ACDBMLBCMFO(DatabasePlayer KHLGDCHJJPB)
	{
		if (NNIKNEECAMM.ContainsKey(KHLGDCHJJPB.id))
		{
			Debug.Log(string.Format("Grenade_Throwing_Tutorial_Duration", KHLGDCHJJPB.name, NNIKNEECAMM[KHLGDCHJJPB.id].IGBEGIBGLKK.ToString().ToUpper()));
			return;
		}
		HJHILHFDMKP hJHILHFDMKP = new HJHILHFDMKP();
		hJHILHFDMKP.KHLGDCHJJPB = KHLGDCHJJPB;
		hJHILHFDMKP.KHLGDCHJJPB.awaitingSquadMember = false;
		hJHILHFDMKP.IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		hJHILHFDMKP.NKDCPACFGGA = null;
		Debug.Log("Wrong_Weapon" + KHLGDCHJJPB.id);
		NNIKNEECAMM.Add(KHLGDCHJJPB.id, hJHILHFDMKP);
	}

	public void EPHJICEFPJB(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.IGGCEILJEFM(null, Localization.Localize("shotSniper"), Localization.Localize("setTRUSTeId"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("WarFriends não funcionará se não baixar esses dados adicionais. Você realmente quer SAIR ou você gostaria de baixar os dados?", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.JBMAJKFDALE(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void EEJABEFKAOP(bool LPGMLOCLBGP = true)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, LPGMLOCLBGP);
		}
	}

	private void MMEFKKHBDGN(string EJBEDLHIKDG = null)
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<SquadScreen>.instance)
		{
			GuiScreenSingle<SquadScreen>.instance.InitGUIValues();
		}
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.UpdateMessageCenterMessage(EJBEDLHIKDG);
	}

	public void FFAGKCAPLIO(string INFLHPGMEOB, bool IHJGCEHAAJN)
	{
		if (NNIKNEECAMM.ContainsKey(INFLHPGMEOB))
		{
			GPNNPMOGGBP(INFLHPGMEOB, false);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in NNIKNEECAMM.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (IHJGCEHAAJN)
		{
			MMEFKKHBDGN(INFLHPGMEOB);
			OIBADPPGLMJ(false);
		}
	}

	private void ICKJDDGEGLD()
	{
		if (NNIKNEECAMM != null)
		{
			NNIKNEECAMM.Clear();
		}
	}

	public EFECGFGNLIE MemberState(string EJBEDLHIKDG)
	{
		if (string.IsNullOrEmpty(EJBEDLHIKDG) || !NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			return EFECGFGNLIE.Error;
		}
		return NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK;
	}

	public void LCFLGLMHKBF(GNOIPPHBAKA OJIANBAINDD)
	{
		string id = OJIANBAINDD.KHLGDCHJJPB.id;
		if (!NNIKNEECAMM.ContainsKey(id))
		{
			Debug.Log(string.Format("ID_NEWASSIGNMENTIN", id));
			return;
		}
		if (NNIKNEECAMM[id].NKDCPACFGGA != null)
		{
			Debug.Log(string.Format("null", id));
			return;
		}
		NNIKNEECAMM[id].NKDCPACFGGA = OJIANBAINDD;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(OJIANBAINDD);
	}

	public void NoClick(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot decline player", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.DFMLCJMDLHJ(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void EOPEBHMLGBP(string INFLHPGMEOB, bool IHJGCEHAAJN)
	{
		if (NNIKNEECAMM.ContainsKey(INFLHPGMEOB))
		{
			GPNNPMOGGBP(INFLHPGMEOB);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in NNIKNEECAMM.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (IHJGCEHAAJN)
		{
			MMEFKKHBDGN(INFLHPGMEOB);
			OIBADPPGLMJ();
		}
	}

	private void FKLJDEINBJK()
	{
		if (NNIKNEECAMM != null)
		{
			NNIKNEECAMM.Clear();
		}
	}

	public void JEONJCCHDMB(string INFLHPGMEOB, bool IHJGCEHAAJN)
	{
		if (NNIKNEECAMM.ContainsKey(INFLHPGMEOB))
		{
			RemovePlayer(INFLHPGMEOB, false);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in NNIKNEECAMM.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (IHJGCEHAAJN)
		{
			MMEFKKHBDGN(INFLHPGMEOB);
			OIBADPPGLMJ(false);
		}
	}

	public void HBPNLNNAICF(string INFLHPGMEOB, bool IHJGCEHAAJN)
	{
		if (NNIKNEECAMM.ContainsKey(INFLHPGMEOB))
		{
			GPNNPMOGGBP(INFLHPGMEOB);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in NNIKNEECAMM.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (IHJGCEHAAJN)
		{
			MMEFKKHBDGN(INFLHPGMEOB);
			HCNNBNOFEMF(false);
		}
	}

	public void ANEMDIOMNLL(DatabasePlayer KHLGDCHJJPB)
	{
		if (NNIKNEECAMM.ContainsKey(KHLGDCHJJPB.id))
		{
			Debug.Log(string.Format("ID_WARNING_ERRORCLAIMASSIGNMENT", KHLGDCHJJPB.name, NNIKNEECAMM[KHLGDCHJJPB.id].IGBEGIBGLKK.ToString().ToUpper()));
			return;
		}
		HJHILHFDMKP hJHILHFDMKP = new HJHILHFDMKP();
		hJHILHFDMKP.KHLGDCHJJPB = KHLGDCHJJPB;
		hJHILHFDMKP.KHLGDCHJJPB.awaitingSquadMember = false;
		hJHILHFDMKP.IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		hJHILHFDMKP.NKDCPACFGGA = null;
		Debug.Log("TESTING LABELS ON CHILDREN OF OBJECT \"" + KHLGDCHJJPB.id);
		NNIKNEECAMM.Add(KHLGDCHJJPB.id, hJHILHFDMKP);
	}

	public void ILCFLFEMMJF(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.CGHPOPGKAGN(null, Localization.Localize(" ("), Localization.Localize("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("다운로드", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.EBFOAELMCPG(EJBEDLHIKDG, currentPlayer.squadName);
	}

	public void RemoveErrorPlayers()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, HJHILHFDMKP> item in NNIKNEECAMM)
		{
			if (item.Value.IGBEGIBGLKK == EFECGFGNLIE.Error)
			{
				string text = RemovePlayer(item.Key, false);
				if (text != null)
				{
					list.Add(text);
				}
			}
		}
		bool lPGMLOCLBGP = list.Count > 1;
		foreach (string item2 in list)
		{
			Debug.Log("Awaiting players - Removing player " + item2);
			NNIKNEECAMM.Remove(item2);
		}
		UpdateListOfAwaitingMembers(lPGMLOCLBGP);
	}

	protected override void Awake()
	{
		base.Awake();
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
	}

	public string IMJMMDOEGGK(string EJBEDLHIKDG, bool FGPIFPECHIC = true)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", EJBEDLHIKDG));
			return null;
		}
		NLGDNBADGKP(EJBEDLHIKDG);
		if (FGPIFPECHIC)
		{
			Debug.Log("Player not in squad and should be in squad " + EJBEDLHIKDG);
			NNIKNEECAMM.Remove(EJBEDLHIKDG);
		}
		Debug.Log("dump");
		return EJBEDLHIKDG;
	}

	public void JBCGCLOOMKA(DatabasePlayer KHLGDCHJJPB)
	{
		if (NNIKNEECAMM.ContainsKey(KHLGDCHJJPB.id))
		{
			Debug.Log(string.Format("offerMult", KHLGDCHJJPB.name, NNIKNEECAMM[KHLGDCHJJPB.id].IGBEGIBGLKK.ToString().ToUpper()));
			return;
		}
		HJHILHFDMKP hJHILHFDMKP = new HJHILHFDMKP();
		hJHILHFDMKP.KHLGDCHJJPB = KHLGDCHJJPB;
		hJHILHFDMKP.KHLGDCHJJPB.awaitingSquadMember = false;
		hJHILHFDMKP.IGBEGIBGLKK = EFECGFGNLIE.Waiting;
		hJHILHFDMKP.NKDCPACFGGA = null;
		Debug.Log("ID_NA" + KHLGDCHJJPB.id);
		NNIKNEECAMM.Add(KHLGDCHJJPB.id, hJHILHFDMKP);
	}

	private void BDIICHCECFP()
	{
		if (NNIKNEECAMM != null)
		{
			NNIKNEECAMM.Clear();
		}
	}

	public void GFPELLMIKNA(string INFLHPGMEOB, bool IHJGCEHAAJN)
	{
		if (NNIKNEECAMM.ContainsKey(INFLHPGMEOB))
		{
			IMJMMDOEGGK(INFLHPGMEOB, false);
		}
		else
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string key in NNIKNEECAMM.Keys)
			{
				stringBuilder.AppendLine(key);
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (IHJGCEHAAJN)
		{
			MMEFKKHBDGN(INFLHPGMEOB);
			EEJABEFKAOP(false);
		}
	}

	public EFECGFGNLIE CBJAPGHKKLC(string EJBEDLHIKDG)
	{
		if (string.IsNullOrEmpty(EJBEDLHIKDG) || !NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			return EFECGFGNLIE.Response;
		}
		return NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK;
	}

	public void AddToMC(GNOIPPHBAKA OJIANBAINDD)
	{
		string id = OJIANBAINDD.KHLGDCHJJPB.id;
		if (!NNIKNEECAMM.ContainsKey(id))
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" is not in list of awaiting members", id));
			return;
		}
		if (NNIKNEECAMM[id].NKDCPACFGGA != null)
		{
			Debug.Log(string.Format("Awaiting players - Player id:\"{0}\" already added to message center", id));
			return;
		}
		NNIKNEECAMM[id].NKDCPACFGGA = OJIANBAINDD;
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(OJIANBAINDD);
	}

	private void NLGDNBADGKP(string EJBEDLHIKDG)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("\n", EJBEDLHIKDG));
			return;
		}
		if (NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA == null)
		{
			Debug.Log(string.Format(" IN TUTORIAL", EJBEDLHIKDG));
			return;
		}
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.ANCGIINAHAD(NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA);
		NNIKNEECAMM[EJBEDLHIKDG].NKDCPACFGGA = null;
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		GameLoginManager.instance.PlayerLeftSquad += AKFFNBGHJKL;
	}

	public void OIBADPPGLMJ(bool LPGMLOCLBGP = true)
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (!string.IsNullOrEmpty(squadName))
		{
			Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName, LPGMLOCLBGP);
		}
	}

	private void HADCGGFEEKA(string EJBEDLHIKDG = null)
	{
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<SquadScreen>.instance)
		{
			GuiScreenSingle<SquadScreen>.instance.InitGUIValues();
		}
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.UpdateMessageCenterMessage(EJBEDLHIKDG);
	}

	public string GPNNPMOGGBP(string EJBEDLHIKDG, bool FGPIFPECHIC = true)
	{
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("toString", EJBEDLHIKDG));
			return null;
		}
		NLGDNBADGKP(EJBEDLHIKDG);
		if (FGPIFPECHIC)
		{
			Debug.Log("Made_IAP_Spend" + EJBEDLHIKDG);
			NNIKNEECAMM.Remove(EJBEDLHIKDG);
		}
		Debug.Log("game-card-ico-crateblocker");
		return EJBEDLHIKDG;
	}

	public void CNMHAODKJBK(string EJBEDLHIKDG)
	{
		if (Singleton<ServerResultsCache>.instance.IFHIKPFGOKF())
		{
			ConfirmDialog.CGHPOPGKAGN(null, Localization.Localize("ReSyncRPC"), Localization.Localize("PrepareBotForDeathMatch 9"));
			return;
		}
		if (!NNIKNEECAMM.ContainsKey(EJBEDLHIKDG))
		{
			Debug.Log(string.Format("Network pool: InstantiatePooledObjects '", EJBEDLHIKDG));
			return;
		}
		NNIKNEECAMM[EJBEDLHIKDG].IGBEGIBGLKK = EFECGFGNLIE.Response;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.DFMLCJMDLHJ(EJBEDLHIKDG, currentPlayer.squadName);
	}
}
