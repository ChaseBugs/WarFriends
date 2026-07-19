using System;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class PDIHEPGNPCA : HHFHFANGCEJ
{
	public string DBNNKLCNDJD;

	public DatabasePlayer MBFOMBJNLBL;

	public bool IDOHDGPNCEM;

	public bool NKFDEFHCAHK;

	public long EOHOJBOGNAO;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public override bool OMMPKNEEJIB
	{
		get
		{
			return true;
		}
	}

	public override bool JLCLGAKDIMG
	{
		get
		{
			return true;
		}
	}

	public virtual void DLCFAJEFLHO()
	{
		base.GEKIMGFKNHC();
		Debug.Log("Exception when adding warcards reward for tutorial - adding default instead, msg = " + MBFOMBJNLBL.name + "ID_PURCHASED" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("Awaiting players - Player id:\"{0}\" is not in list of awaiting members");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + 39 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag3 = flag && IDOHDGPNCEM && NKFDEFHCAHK;
		bool flag4 = Singleton<Chat>.instance.ONIBJDJIAMO();
		bool flag5 = GameLoginManager.currentPlayer.squadRank == (SquadRank)8;
		bool flag6 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag6)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Veteran);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-37)).DBKEY;
			if (EOHOJBOGNAO > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EOHOJBOGNAO));
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (flag4)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, flag);
		}
		if ((flag3 || (!flag4 && flag5)) && !COBJHFOGCEG())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		OIDDCBBFBHJ();
	}

	public override void CJPBMDDGDHG()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogFormat("#PETER# Removing squad joined message - message time:{0}, server time:{1}, isInSquad:{2}", MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag);
			OJFJOJONNJK();
		}
	}

	public virtual void DIHHMNFOMPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (MBFOMBJNLBL.id == KHLGDCHJJPB.id)
		{
			MBFOMBJNLBL.level = KHLGDCHJJPB.level;
		}
	}

	public PDIHEPGNPCA(bool BNDMANCJEKH)
		: base("testingidsquadjoined", NKHJBLBAAEB.SquadJoined)
	{
		if (BNDMANCJEKH)
		{
			MBFOMBJNLBL = GameLoginManager.currentPlayer;
			NKFDEFHCAHK = true;
			IDOHDGPNCEM = true;
			NHHGDIDEIMM += MBFOMBJNLBL.id;
		}
		else
		{
			MBFOMBJNLBL = new DatabasePlayer();
			MBFOMBJNLBL.accountName = "Testing Player";
			MBFOMBJNLBL.level = 6;
			MBFOMBJNLBL.squadName = "Squad";
			MBFOMBJNLBL.id = "newMember";
			NHHGDIDEIMM += MBFOMBJNLBL.id;
		}
	}

	private static void EDDBKHKJICI()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	[SpecialName]
	public virtual bool AGACHPLOPJE()
	{
		return false;
	}

	internal virtual Action LMFFMPKCPJI(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BJPKEALLOJE(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return HHHLMPGNBFG;
	}

	internal virtual Action MAGGBLIILMK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadJoined(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return LKADJOEKOEN;
	}

	public virtual void BDBGBONBGIO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (MBFOMBJNLBL.id == KHLGDCHJJPB.id)
		{
			MBFOMBJNLBL.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void PEBHGOMEKME()
	{
		base.JPGMEFJGNNA();
		Debug.Log("PNManager: Scheduling Crafting Finished Notification in " + MBFOMBJNLBL.name + "," + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("SquadWarsId");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + -52 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		bool flag3 = !flag || !IDOHDGPNCEM || NKFDEFHCAHK;
		bool shouldChat = Singleton<Chat>.instance.shouldChat;
		bool flag4 = GameLoginManager.currentPlayer.squadRank == (SquadRank)8;
		bool flag5 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag5)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Member);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FacebookLoginReminder2After).DBKEY;
			if (EOHOJBOGNAO > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag, EOHOJBOGNAO), true);
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
		}
		if ((flag3 || (!shouldChat && flag4)) && !COBJHFOGCEG())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool NAJOCNFGPOA()
	{
		return true;
	}

	public virtual void EOFADGHFCAK()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -140 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			object[] array = new object[7];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "PRICEGOLD", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_CONFIRM_EXIT", string.Empty);
			array[0] = flag;
			Debug.LogFormat("silver1", array);
			BCIOBLLBLLC();
		}
	}

	[SpecialName]
	public virtual bool ILPOGFMNKGH()
	{
		return false;
	}

	[SpecialName]
	public virtual bool NCBFPDMCIAG()
	{
		return true;
	}

	public virtual void FJILILFMPIF()
	{
		base.OBJEMJHBJFO();
		Debug.Log("Network pool: InstantiatePooledObjects '" + MBFOMBJNLBL.name + "Army_Unit_ID" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("ID_CONFIRM_ERROR");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + 25 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag3 = flag && IDOHDGPNCEM && NKFDEFHCAHK;
		bool flag4 = Singleton<Chat>.instance.ONIBJDJIAMO();
		bool flag5 = GameLoginManager.currentPlayer.squadRank == (SquadRank)7;
		bool flag6 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag6)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Member);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-36)).DBKEY;
			if (EOHOJBOGNAO > 1 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO, false);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EOHOJBOGNAO), true);
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (flag4)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
		}
		if ((flag3 || (!flag4 && flag5)) && !base.PFCJDAHIIIC)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		AKICNBAOGOL();
	}

	internal virtual Action MDCHALEHFEH(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadJoined(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return EDDBKHKJICI;
	}

	public virtual void AAAIKGFFKIF()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -126 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[7];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, ", ", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "\n", string.Empty, false);
			array[0] = flag;
			Debug.LogFormat("AdminName", array);
			CALACCCGMGD();
		}
	}

	public virtual void ILFJPOOMFDO()
	{
		base.OLECKGKLHCE();
		Debug.Log("HELMETS_CROWNBRONZE" + MBFOMBJNLBL.name + "ID_PLAYERCANTJOINSQUAD" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("ID_GUI_CHAT_BANNED_DESCBOX_TEMP");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + -99 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag3 = flag && IDOHDGPNCEM && NKFDEFHCAHK;
		bool shouldChat = Singleton<Chat>.instance.shouldChat;
		bool flag4 = GameLoginManager.currentPlayer.squadRank == (SquadRank)8;
		bool flag5 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag5)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Member);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName, true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-29)).DBKEY;
			if (EOHOJBOGNAO > 1 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag, EOHOJBOGNAO));
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.JEDKOPACCOL(this, flag);
		}
		if ((flag3 || (!shouldChat && flag4)) && !HJJHBEABPJB())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		OIDDCBBFBHJ();
	}

	[CompilerGenerated]
	private static void JKIAEOLFEGC()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	[SpecialName]
	public virtual bool NDNGBCHBDPL()
	{
		return false;
	}

	private static void LKADJOEKOEN()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	public virtual void DMLDBKFCACB()
	{
		base.KPANLOMNEIG();
		Debug.Log("Regions" + MBFOMBJNLBL.name + " {0}{1}" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("rankDiff");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + -16 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag3 = flag && IDOHDGPNCEM && NKFDEFHCAHK;
		bool shouldChat = Singleton<Chat>.instance.shouldChat;
		bool flag4 = GameLoginManager.currentPlayer.squadRank == (SquadRank)8;
		bool flag5 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag5)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Veteran);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalPowerbandDelayMax).DBKEY;
			if (EOHOJBOGNAO > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EOHOJBOGNAO), true);
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this, flag);
		}
		if ((flag3 || (!shouldChat && flag4)) && !JCLPLMEMGKA())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		LACLELOOKHD();
	}

	public PDIHEPGNPCA(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		MBFOMBJNLBL = new DatabasePlayer();
		if (OGNGMBLDAOP["PlayerName"] != null)
		{
			MBFOMBJNLBL.accountName = KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Level"] != null)
		{
			MBFOMBJNLBL.level = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["Level"]["N"]);
		}
		if (OGNGMBLDAOP["SquadId"] != null)
		{
			MBFOMBJNLBL.squadName = KHJJFPPACBP.BKFCLMMJNHK("SquadId", "S", OGNGMBLDAOP, string.Empty);
		}
		DBNNKLCNDJD = MBFOMBJNLBL.squadName;
		if (OGNGMBLDAOP["NewPlayerMemberId"] != null)
		{
			MBFOMBJNLBL.id = KHJJFPPACBP.BKFCLMMJNHK("NewPlayerMemberId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["SquadRank"] != null)
		{
			MBFOMBJNLBL.squadRank = (SquadRank)KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["SquadRank"]["N"]);
		}
		if (OGNGMBLDAOP["Gold"] != null)
		{
			EOHOJBOGNAO = KHJJFPPACBP.GKKLOFAGGLI(OGNGMBLDAOP["Gold"]["N"], 0L);
		}
		if (OGNGMBLDAOP["SquadIsPrivate"] != null)
		{
			IDOHDGPNCEM = true;
		}
		if (OGNGMBLDAOP["AcceptedFromRequest"] != null)
		{
			NKFDEFHCAHK = true;
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		Debug.Log("Player " + MBFOMBJNLBL.name + " succesfully joined squad " + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("Player was accepted to squad via Squad Join Request!");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag3 = flag && IDOHDGPNCEM && NKFDEFHCAHK;
		bool shouldChat = Singleton<Chat>.instance.shouldChat;
		bool flag4 = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		bool flag5 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag5)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Member);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).DBKEY;
			if (EOHOJBOGNAO > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EOHOJBOGNAO));
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this, !flag);
		}
		if ((flag3 || (!shouldChat && flag4)) && !base.PFCJDAHIIIC)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		CJPBMDDGDHG();
	}

	internal virtual Action CCJEIKKNKMO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.CCJDPNPIHLM(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return AGEBFLBJAON;
	}

	[SpecialName]
	public virtual bool GAPAJHFLNCE()
	{
		return true;
	}

	internal virtual Action OBJIHCHMPHA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadJoined(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return HHHLMPGNBFG;
	}

	public virtual void CCGAHAHKEKF()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 188 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			object[] array = new object[1];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "{0} {1}", string.Empty);
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "Changed country to {0} from {1}.", string.Empty, false);
			array[0] = flag;
			Debug.LogFormat("EligibleLeagueId", array);
			JFDENNGOGJC();
		}
	}

	public virtual void EKGIMBEJLFH()
	{
		base.JPGMEFJGNNA();
		Debug.Log("WENEEDTO" + MBFOMBJNLBL.name + "file://" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("ID_ARENABOXDESCRIPTION_WARBUCKS");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + -34 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag3 = !flag || !IDOHDGPNCEM || NKFDEFHCAHK;
		bool shouldChat = Singleton<Chat>.instance.shouldChat;
		bool flag4 = GameLoginManager.currentPlayer.squadRank == SquadRank.Coleader;
		bool flag5 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag5)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Member);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-70)).DBKEY;
			if (EOHOJBOGNAO > 1 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.COLJGNLBEII(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EOHOJBOGNAO), true);
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, !flag);
		}
		if ((flag3 || (!shouldChat && flag4)) && !KKENHDCOLKB())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		OIDDCBBFBHJ();
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadJoined(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		};
	}

	private static void AGEBFLBJAON()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	public virtual void EPNDHJLAKEB(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (MBFOMBJNLBL.id == KHLGDCHJJPB.id)
		{
			MBFOMBJNLBL.level = KHLGDCHJJPB.level;
		}
	}

	[SpecialName]
	public virtual bool MFKDGMNOEHH()
	{
		return false;
	}

	[SpecialName]
	public override bool IAEOGOBPIAM()
	{
		return false;
	}

	[SpecialName]
	public override bool IJELOOFLPCK()
	{
		return true;
	}

	public virtual void CPFHDPLCOML()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 75 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, ")", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "BattleRewards", string.Empty);
			array[5] = flag;
			Debug.LogFormat("111-222-3333", array);
			JFDENNGOGJC();
		}
	}

	[SpecialName]
	public virtual bool JLMFBCHHBLD()
	{
		return false;
	}

	internal virtual Action MFPCHHLMBKK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.DLPIAGHFGJF(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return LKADJOEKOEN;
	}

	public virtual void ALKFOHIAKOM()
	{
		base.LEJEDFACEGP();
		Debug.Log("GameEnded: Money Pack Deadline = " + MBFOMBJNLBL.name + "SystemMessage" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("offerMult");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + -15 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		bool flag3 = !flag || !IDOHDGPNCEM || NKFDEFHCAHK;
		bool flag4 = Singleton<Chat>.instance.ONIBJDJIAMO();
		bool flag5 = GameLoginManager.currentPlayer.squadRank == (SquadRank)5;
		bool flag6 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag6)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Veteran);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward3).DBKEY;
			if (EOHOJBOGNAO > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.BKFOPCDLPCJ(EOHOJBOGNAO, false);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, EOHOJBOGNAO), true);
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (flag4)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, flag);
		}
		if ((flag3 || (!flag4 && flag5)) && !KKENHDCOLKB())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		CGOOGHIJOAH();
	}

	[SpecialName]
	public virtual bool DPADKHFKFFB()
	{
		return true;
	}

	public override void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (MBFOMBJNLBL.id == KHLGDCHJJPB.id)
		{
			MBFOMBJNLBL.level = KHLGDCHJJPB.level;
		}
	}

	private static void CIIDDHONPAD()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	internal virtual Action CDFKIOIDHAN(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.HOJLELCLPEA(HPGHHECHLAN, KJCKFGCLGLG, MBFOMBJNLBL);
		return LKADJOEKOEN;
	}

	public virtual void PEDMMNGPBGO()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 99 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			object[] array = new object[3];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "不", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "#PETER# League Arc ", string.Empty, false);
			array[2] = flag;
			Debug.LogFormat("WarFriends cannot function without downloading these additional data. Do you really wish to QUIT or would you like to download the data?", array);
			OJFJOJONNJK();
		}
	}

	private static void HHHLMPGNBFG()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	public virtual void JOCFHKJPEPO()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -149 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			object[] array = new object[6];
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_RANDOMWARCARDS", string.Empty, false);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "offerMult", string.Empty);
			array[3] = flag;
			Debug.LogFormat("getOriginalAccountAlias", array);
			IFFBCOLBDOP();
		}
	}

	public virtual void OCHDOJMAGHA()
	{
		base.OBJEMJHBJFO();
		Debug.Log("ID_SQUADEVENT" + MBFOMBJNLBL.name + "game-card-ico-shieldsup" + DBNNKLCNDJD);
		if (NKFDEFHCAHK)
		{
			Debug.Log("{0}{1}{2} {3}");
		}
		bool flag = MBFOMBJNLBL.id == GameLoginManager.currentPlayer.id;
		bool flag2 = KJCKFGCLGLG + -87 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag3 = flag && IDOHDGPNCEM && NKFDEFHCAHK;
		bool flag4 = Singleton<Chat>.instance.ONIBJDJIAMO();
		bool flag5 = GameLoginManager.currentPlayer.squadRank == (SquadRank)7;
		bool flag6 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (flag && !string.IsNullOrEmpty(DBNNKLCNDJD) && !flag6)
		{
			GameLoginManager.instance.AddPlayerToSquad(DBNNKLCNDJD, SquadRank.Veteran);
		}
		else if (flag2)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
		}
		if (flag)
		{
			string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ArmyPowerWeaponConstant).DBKEY;
			if (EOHOJBOGNAO > 0 && !PlayerAnalytics.instance.WasOneTimeRewardAdded(dBKEY))
			{
				Singleton<Wallet>.instance.BKFOPCDLPCJ(EOHOJBOGNAO);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag, EOHOJBOGNAO), true);
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
		}
		if (flag4)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, !flag);
		}
		if ((flag3 || (!flag4 && flag5)) && !JCLPLMEMGKA())
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		LACLELOOKHD();
	}

	public virtual void OHLBMCDAPHK(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (MBFOMBJNLBL.id == KHLGDCHJJPB.id)
		{
			MBFOMBJNLBL.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void HDLKDKMHOGG(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (MBFOMBJNLBL.id == KHLGDCHJJPB.id)
		{
			MBFOMBJNLBL.level = KHLGDCHJJPB.level;
		}
	}

	[SpecialName]
	public virtual bool HMILIHOLIFN()
	{
		return true;
	}
}
