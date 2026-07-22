using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class HEOOEHGBLEN : HHFHFANGCEJ
{
	public int BOHDLNLLLEC;

	public DatabasePlayer JGFOLEGLELK;

	public DatabasePlayer KJCJCBPKKEM;

	public bool ABPNKPJOIAM;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public override bool OMMPKNEEJIB => true;

	public override bool JLCLGAKDIMG => true;

	[SpecialName]
	public virtual bool IECFJMJPBII()
	{
		return true;
	}

	internal virtual Action BDKMGBLJKLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.POLDCNHDJHL(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return IGKJJMDOBPB;
	}

	[SpecialName]
	public virtual bool DPADKHFKFFB()
	{
		return false;
	}

	public virtual void MFCDPGIJHAJ(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void FAEBCMCJNNN()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 60 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			object[] array = new object[7];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, " ", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "Pool", string.Empty, IEJMLKBCDJB: false);
			array[1] = flag;
			Debug.LogFormat("game-card-ico-shieldgenerator", array);
			OJFJOJONNJK();
		}
	}

	internal virtual Action CCJEIKKNKMO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.POLDCNHDJHL(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return DLANAKFHGBA;
	}

	private static void HHHLMPGNBFG()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	[SpecialName]
	public virtual bool MFKDGMNOEHH()
	{
		return false;
	}

	internal virtual Action NFIJMIHKNEN(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KAEAPABNBLI(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return HHHLMPGNBFG;
	}

	[SpecialName]
	public virtual bool JLKEKLKKAFI()
	{
		return true;
	}

	public virtual void LGIPLMGJDNG(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void FFMLINMFADM()
	{
		base.MGKMBCBBOHK();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[5];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "Squad Points - {0}\n");
		array[1] = JGFOLEGLELK.level;
		array[8] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "#VOJTA# Message Manager: Error previously ignored message arrived again from server! Id = ");
		array[0] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("ID_STATE_OPPONENTDOESNTWANTREMATCH", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("S");
		}
		if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -99 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
			}
			LACLELOOKHD();
		}
	}

	private static void GEIMIFFPNCC()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	public virtual void NECPGBBNPCD()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -32 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			Debug.LogFormat("trial", MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "{0} {1}", string.Empty, IEJMLKBCDJB: false), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "clientVersion", string.Empty), null, flag, null);
			BCIOBLLBLLC();
		}
	}

	public virtual void OCPIKHHMHAN(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public HEOOEHGBLEN(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		ABPNKPJOIAM = false;
		JGFOLEGLELK = new DatabasePlayer();
		if (OGNGMBLDAOP["PlayerName"] != null)
		{
			JGFOLEGLELK.accountName = KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Level"] != null)
		{
			JGFOLEGLELK.level = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["Level"]["N"]);
		}
		if (OGNGMBLDAOP["SquadId"] != null)
		{
			JGFOLEGLELK.squadName = KHJJFPPACBP.BKFCLMMJNHK("SquadId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["SquadRank"] != null)
		{
			JGFOLEGLELK.squadRank = (SquadRank)KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["SquadRank"]["N"]);
			BOHDLNLLLEC = (int)JGFOLEGLELK.squadRank;
		}
		if (OGNGMBLDAOP["PromotedPlayerId"] != null)
		{
			JGFOLEGLELK.id = KHJJFPPACBP.BKFCLMMJNHK("PromotedPlayerId", "S", OGNGMBLDAOP, string.Empty);
		}
		KJCJCBPKKEM = new DatabasePlayer();
		if (OGNGMBLDAOP["AdminName"] != null)
		{
			KJCJCBPKKEM.accountName = KHJJFPPACBP.BKFCLMMJNHK("AdminName", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["AdminId"] != null)
		{
			KJCJCBPKKEM.id = KHJJFPPACBP.BKFCLMMJNHK("AdminId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["AdminLevel"] != null)
		{
			KJCJCBPKKEM.level = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["AdminLevel"]["N"]);
		}
	}

	public virtual void LEOMLFCGIHK()
	{
		base.LEJEDFACEGP();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[4];
		array[0] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "/PC/");
		array[1] = JGFOLEGLELK.level;
		array[1] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "Wood");
		array[3] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("DatabaseMessage - No long existing database message came from server!", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("registerEvent");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HKGAPGAKFHA(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -71 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
			}
			CGOOGHIJOAH();
		}
	}

	public override void CJPBMDDGDHG()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogFormat("#PETER# Removing squad promote message - message time:{0}, server time:{1}, isInSquad:{2}", MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag);
			OJFJOJONNJK();
		}
	}

	public virtual void DANAMJKOPBO()
	{
		base.MGKMBCBBOHK();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[7];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "Gold");
		array[1] = JGFOLEGLELK.level;
		array[3] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "ID_CONFIRM_SQUADISNOTPUBLIC_TEXT");
		array[3] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("get", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("Unit");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -79 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
			}
			CJPBMDDGDHG();
		}
	}

	public virtual void IPECDMFGLNP()
	{
		base.LEJEDFACEGP();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[2];
		array[0] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : " IN TUTORIAL");
		array[0] = JGFOLEGLELK.level;
		array[6] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "ID_READYTIME");
		array[4] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("War_Battle_End_Android_Performance", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_RELOG_TO_FB_DIALOG_TEXT");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + 43 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
			}
			CGOOGHIJOAH();
		}
	}

	internal virtual Action BKLBFKCBFPP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.POLDCNHDJHL(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return DLANAKFHGBA;
	}

	public virtual void MNLAIHAPJOA()
	{
		base.OEAJBFLGJCA();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[8];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "shield_unhide");
		array[1] = JGFOLEGLELK.level;
		array[2] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "LifeCount");
		array[0] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("IsWarArenaBattle", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_WARNING_ARENADOESNTEXIST");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.BGOHKEGGHMH(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + 61 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
			}
			CJPBMDDGDHG();
		}
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadPromotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		};
	}

	private static void OGIDMBHGDKM()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	[SpecialName]
	public virtual bool PJOAAJMBKFJ()
	{
		return true;
	}

	public virtual void MMKJJKCNAMO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		Debug.Log(string.Format("Player promoted - database informations:\nName:{0} Level:{1} SquadId:{2} SquadRank:{3}", (JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "null", JGFOLEGLELK.level, (JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "null", JGFOLEGLELK.squadRank));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("Promoting to MEMBER!!!! should be JOINED MESSAGE");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
			}
			CJPBMDDGDHG();
		}
	}

	public HEOOEHGBLEN(DatabasePlayer KHLGDCHJJPB, DatabasePlayer LIAFEPFJAKM)
		: base($"SquadPromoteMessage {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", NKHJBLBAAEB.SquadPromotion)
	{
		ABPNKPJOIAM = true;
		JGFOLEGLELK = KHLGDCHJJPB;
		KJCJCBPKKEM = LIAFEPFJAKM;
		if (KHLGDCHJJPB != null)
		{
			BOHDLNLLLEC = Mathf.Clamp((int)KHLGDCHJJPB.squadRank, 0, 2);
		}
	}

	[SpecialName]
	public override bool BDDHPAHHDHM()
	{
		return true;
	}

	[SpecialName]
	public virtual bool FIFDIDJMNEP()
	{
		return true;
	}

	internal virtual Action ILLFKEIJILN(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KAEAPABNBLI(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return OGIDMBHGDKM;
	}

	[SpecialName]
	public virtual bool HEMBCIKEDGO()
	{
		return false;
	}

	[SpecialName]
	public virtual bool GEHKEJIBBDI()
	{
		return true;
	}

	[SpecialName]
	public virtual bool GIJHEKBEEGP()
	{
		return false;
	}

	internal virtual Action OGPPKOPMIOJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KAEAPABNBLI(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return GEIMIFFPNCC;
	}

	private static void FILMAOHLFMP()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	private static void FGHKOPDODOH()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	private static void DIFOKHIDMIG()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	[SpecialName]
	public virtual bool HICCPADDDLD()
	{
		return true;
	}

	[SpecialName]
	public virtual bool FCHHGECCKLO()
	{
		return true;
	}

	public virtual void FCANLIOLJNH()
	{
		base.KPANLOMNEIG();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[1];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "game-ico-speed");
		array[0] = JGFOLEGLELK.level;
		array[1] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "ID_SLOTUPGRADE_HEAT");
		array[4] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("On joined lobby", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_WARNING_CANTSENDINVITE");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -124 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
			}
			AKICNBAOGOL();
		}
	}

	public virtual void ECBMHNDPENI()
	{
		base.GEKIMGFKNHC();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[2];
		array[0] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "http://tos.ea.com/legalapp/WEBPRIVACY/US/");
		array[1] = JGFOLEGLELK.level;
		array[2] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "Player entered normal league: {0} and beginners league: {1}");
		array[5] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("Message Manager: Removing message, id = ", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_SUBSCRIPTIODETAILS_HINT3GOOGLE");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -21 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
			}
			LACLELOOKHD();
		}
	}

	public virtual void MDNNFCNEMDH()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 73 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			object[] array = new object[1];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "elitepack1", string.Empty);
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", string.Empty);
			array[6] = flag;
			Debug.LogFormat("IsPublic", array);
			IFFBCOLBDOP();
		}
	}

	public virtual void HDKCFAMJBBO()
	{
		base.JPGMEFJGNNA();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[6];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "ID_INVITEISINACTIVE");
		array[1] = JGFOLEGLELK.level;
		array[1] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "ID_TUTORIAL_GO_BUY_ARMY_2");
		array[8] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("ID_SERVER_ERROR", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_WARNING_WRONGINDEXTOACTIVATEELITE");
		}
		if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + 54 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
			}
			LACLELOOKHD();
		}
	}

	[SpecialName]
	public virtual bool CFMMDOBIIBM()
	{
		return true;
	}

	[SpecialName]
	public virtual bool CHBNLOJJDJP()
	{
		return true;
	}

	internal virtual Action AABIIFOPEFJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KAEAPABNBLI(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return FGHKOPDODOH;
	}

	public virtual void MEDLNDILONN()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -147 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogFormat("RETRYPERM", MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "shotgunner_run", string.Empty, IEJMLKBCDJB: false), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "Squad", string.Empty, IEJMLKBCDJB: false), flag, null);
			CALACCCGMGD();
		}
	}

	public override void IFLECEBGJMC(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void AHHCFAIJCAE()
	{
		base.LEJEDFACEGP();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[0];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "added");
		array[1] = JGFOLEGLELK.level;
		array[2] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "AdminId");
		array[2] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("N", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_STARTSINX");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -16 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
			}
			CGOOGHIJOAH();
		}
	}

	public override void JPEEONOIHLI(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	[SpecialName]
	public virtual bool DAMHMEOPABN()
	{
		return false;
	}

	[SpecialName]
	public virtual bool PECLKBNDJPG()
	{
		return true;
	}

	private static void DLANAKFHGBA()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	public virtual void CCCECIEOALE(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void NNPILDOKNJO()
	{
		base.OLECKGKLHCE();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[4];
		array[0] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "S");
		array[1] = JGFOLEGLELK.level;
		array[0] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "\n");
		array[2] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("Buy_InstantBattle", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("Beanstalk Error (try = ");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -57 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
			}
			OIDDCBBFBHJ();
		}
	}

	public virtual void PEBHGOMEKME()
	{
		base.OEAJBFLGJCA();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[1];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "null");
		array[1] = JGFOLEGLELK.level;
		array[0] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "null");
		array[4] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("Level", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_TUTORIAL_PROGRESS_KILLING2");
		}
		if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -128 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
			}
			LACLELOOKHD();
		}
	}

	[SpecialName]
	public virtual bool NAJOCNFGPOA()
	{
		return false;
	}

	[SpecialName]
	public override bool MAOHFICPBMI()
	{
		return false;
	}

	public virtual void EOFADGHFCAK()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -192 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[7];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "menu-warbucks", string.Empty, IEJMLKBCDJB: false);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "Warfriend{0}", string.Empty, IEJMLKBCDJB: false);
			array[0] = flag;
			Debug.LogFormat("DebugVersion", array);
			BCIOBLLBLLC();
		}
	}

	[SpecialName]
	public virtual bool CFHJDIKPNPL()
	{
		return true;
	}

	[SpecialName]
	public virtual bool FPBCMMFJCPO()
	{
		return false;
	}

	[SpecialName]
	public virtual bool OABKEJLOENL()
	{
		return true;
	}

	public virtual void AIDGKBCGLKI(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	[SpecialName]
	public virtual bool OPKBMOKEFEH()
	{
		return true;
	}

	public virtual void OBCHIKLLKKO()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 21 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[8];
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "S", string.Empty);
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "ID_FEATURE_BURSTSIZE-DESRIPTION", string.Empty, IEJMLKBCDJB: false);
			array[3] = flag;
			Debug.LogFormat("ID_FEATURE_CRITICAL-DESCRIPTION", array);
			IFFBCOLBDOP();
		}
	}

	public virtual void EHNNFJGAPIH(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void PCKBDCKHDLL(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	private static void DKDHHHCBONO()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	public virtual void PEDMMNGPBGO()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 116 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			object[] array = new object[2];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_CONFIRM_OTHERSERVERRESPONDERROR", string.Empty, IEJMLKBCDJB: false);
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "ID_ELITEPERK", string.Empty);
			array[1] = flag;
			Debug.LogFormat("fire", array);
			OJFJOJONNJK();
		}
	}

	public override void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	public virtual void PHEFLAHPMDH()
	{
		base.OLECKGKLHCE();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[7];
		array[0] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "ShootFromCover");
		array[0] = JGFOLEGLELK.level;
		array[4] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "AdminName");
		array[3] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("ID_POSITIONXY", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("{0} {1}");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.JEDKOPACCOL(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + 46 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
			}
			LACLELOOKHD();
		}
	}

	[SpecialName]
	public virtual bool FNCPPMFCDGF()
	{
		return false;
	}

	public override void OBJEMJHBJFO()
	{
		base.OEAJBFLGJCA();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[3];
		array[0] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "null");
		array[0] = JGFOLEGLELK.level;
		array[3] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "Beanstalk: New Message sent succesfully");
		array[6] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("\tTime since last show: {0}", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("ID_MISSION_KILLUNIT");
		}
		if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.JEDKOPACCOL(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + -14 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
			}
			CJPBMDDGDHG();
		}
	}

	internal virtual Action MCOBONFBIBF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadPromotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return DLANAKFHGBA;
	}

	[SpecialName]
	public virtual bool KHENIHFHBHN()
	{
		return false;
	}

	private static void IGKJJMDOBPB()
	{
		GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
	}

	public override void KPANLOMNEIG()
	{
		base.JPGMEFJGNNA();
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		object[] array = new object[3];
		array[1] = ((JGFOLEGLELK.accountName != null) ? JGFOLEGLELK.accountName : "ID_SALEPERCENT");
		array[0] = JGFOLEGLELK.level;
		array[1] = ((JGFOLEGLELK.squadName != null) ? JGFOLEGLELK.squadName : "SpecialOffers");
		array[4] = JGFOLEGLELK.squadRank;
		Debug.Log(string.Format("{0} {1}", array));
		if (JGFOLEGLELK.squadRank == SquadRank.Member)
		{
			Debug.LogError("SyncWarperRPC");
		}
		if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			bool flag2 = !string.IsNullOrEmpty(squadName);
			bool flag3 = KJCKFGCLGLG + 22 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (flag2 && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
			}
			CJPBMDDGDHG();
		}
	}

	[SpecialName]
	public virtual bool ENJMJLDKCDB()
	{
		return true;
	}

	public virtual void BHBHGLEGKNO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (JGFOLEGLELK.id == KHLGDCHJJPB.id)
		{
			JGFOLEGLELK.level = KHLGDCHJJPB.level;
		}
	}

	[SpecialName]
	public virtual bool MLOPPEECLFP()
	{
		return false;
	}

	public override void LACLELOOKHD()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -141 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (!flag || flag2)
		{
			object[] array = new object[5];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "run", string.Empty, IEJMLKBCDJB: false);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_STAT_WEAPONSUPGRADES", string.Empty);
			array[3] = flag;
			Debug.LogFormat("SquadNameStart", array);
			BCIOBLLBLLC();
		}
	}

	private static void FHBMAGJHNEK()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}

	[SpecialName]
	public virtual bool IHMHGGPECPC()
	{
		return true;
	}

	internal virtual Action JPAFAKBJNNP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadPromotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, JGFOLEGLELK);
		return FILMAOHLFMP;
	}

	[SpecialName]
	public virtual bool NGFALAMOGLA()
	{
		return false;
	}

	[CompilerGenerated]
	private static void JKIAEOLFEGC()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
	}
}
