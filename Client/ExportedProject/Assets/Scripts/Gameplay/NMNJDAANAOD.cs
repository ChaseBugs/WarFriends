using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class NMNJDAANAOD : HHFHFANGCEJ
{
	public DatabasePlayer KHLGDCHJJPB;

	public Card IMMLKDCGONO;

	public int GAAJLNJKDGC;

	public string ICDKHLOBKIE;

	public CardManager.BuddyCardData BCBJPGBDBAH;

	public string OHHGEFIENCF;

	public override bool OMMPKNEEJIB => true;

	public override bool JLCLGAKDIMG => true;

	public virtual void BJGDGMDOKLH()
	{
		base.KPANLOMNEIG();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("getOriginalAccountId", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 123 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			CJPBMDDGDHG();
		}
	}

	[SpecialName]
	public virtual bool HCJCLGHLHKB()
	{
		return true;
	}

	internal virtual Action NKHHAGOKJIO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FALBNFDMKEG(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return PGEBDCOCDAN;
	}

	[SpecialName]
	public virtual bool DNKGAJAJMGP()
	{
		return true;
	}

	public virtual void DLCFAJEFLHO()
	{
		base.OBJEMJHBJFO();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("evt11", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -106 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			LACLELOOKHD();
		}
	}

	[SpecialName]
	public virtual bool BLJCOALKNBK()
	{
		return false;
	}

	private void FHBMAGJHNEK()
	{
		GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
		CJPBMDDGDHG();
	}

	internal virtual Action EEEIHMLHDOC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.HKEOJMPBINB(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return NEECCDLPDCP;
	}

	[SpecialName]
	public virtual bool BLABCPKIMCH()
	{
		return true;
	}

	public virtual void GOLIFONLLPC()
	{
		base.OBJEMJHBJFO();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("-", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -116 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			CJPBMDDGDHG();
		}
	}

	public virtual void DPGKCLINBGE()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool NLLNBDCBPFC()
	{
		return true;
	}

	internal virtual Action CCJEIKKNKMO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.HKEOJMPBINB(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return DHFLAPICHPN;
	}

	public override void CJPBMDDGDHG()
	{
		OJFJOJONNJK();
	}

	public virtual void IPDIOEIPHBO()
	{
		BCIOBLLBLLC();
	}

	[SpecialName]
	public virtual bool FNPHOPEJGAA()
	{
		return true;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log($"Withdrew Warcard message - Showing for player:{OHHGEFIENCF} and current player id is:{GameLoginManager.currentPlayer.id}");
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 60 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			CJPBMDDGDHG();
		}
	}

	[SpecialName]
	public virtual bool MHAJJLAPNHL()
	{
		return true;
	}

	internal virtual Action EHFCHKOLIBP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return PGEBDCOCDAN;
	}

	public virtual void IECHFELOIIO()
	{
		base.JPGMEFJGNNA();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("ID_GETFORNUMBERONE1", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 50 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			LACLELOOKHD();
		}
	}

	public virtual void GFDIIEJPMII()
	{
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool JINMBABEKMN()
	{
		return true;
	}

	public virtual void LCCEEAMLHDD()
	{
		base.LOFMDBHAFAO();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("ExtraRewards", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -69 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			AKICNBAOGOL();
		}
	}

	internal virtual Action FBNPCHJPMMM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return INLAEAPHPAF;
	}

	[SpecialName]
	public virtual bool CLOLJHPJEOM()
	{
		return true;
	}

	internal virtual Action IDEJHCCOFIK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return DHFLAPICHPN;
	}

	private void INLAEAPHPAF()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool FCAMDODELKF()
	{
		return true;
	}

	private void HPPKEBCDLEF()
	{
		GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
		LACLELOOKHD();
	}

	private void CCPPBMANOGC()
	{
		GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool HKPFPJMPAHN()
	{
		return false;
	}

	public virtual void EFBNLJFOOOB()
	{
		IFFBCOLBDOP();
	}

	public override void KPANLOMNEIG()
	{
		base.OBJEMJHBJFO();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("Tutorial_Step_Complete", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 58 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			AKICNBAOGOL();
		}
	}

	internal virtual Action FAOAJHFNBMP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return DHFLAPICHPN;
	}

	public virtual void JEDFPKBPBNB()
	{
		base.OEAJBFLGJCA();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("There is NULL card in card manager -> cards", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -8 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			LACLELOOKHD();
		}
	}

	[SpecialName]
	public virtual bool GIJHEKBEEGP()
	{
		return true;
	}

	public virtual void NFEADFKKCOG()
	{
		base.OLECKGKLHCE();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("goldSpent", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -83 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			CGOOGHIJOAH();
		}
	}

	private void PGEBDCOCDAN()
	{
		GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool INBOJDLIMCI()
	{
		return true;
	}

	[SpecialName]
	public virtual bool LPBJLAMDLFJ()
	{
		return false;
	}

	private void HKFCPFCALBB()
	{
		GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
		CGOOGHIJOAH();
	}

	[SpecialName]
	public virtual bool DFJPNCMIHEH()
	{
		return false;
	}

	public virtual void PAFPBIGHJCI()
	{
		base.OEAJBFLGJCA();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("CoolDown", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -66 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			OIDDCBBFBHJ();
		}
	}

	public virtual void GKKFPJHEEDG()
	{
		base.OLECKGKLHCE();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("Checker", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -21 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			AKICNBAOGOL();
		}
	}

	public NMNJDAANAOD(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		KHLGDCHJJPB = new DatabasePlayer();
		if (OGNGMBLDAOP["PlayerName"] != null)
		{
			KHLGDCHJJPB.accountName = KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Level"] != null)
		{
			KHLGDCHJJPB.level = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["Level"]["N"]);
		}
		if (OGNGMBLDAOP["SquadId"] != null)
		{
			KHLGDCHJJPB.squadName = KHJJFPPACBP.BKFCLMMJNHK("SquadId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["SquadRank"] != null)
		{
			KHLGDCHJJPB.squadRank = (SquadRank)KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["SquadRank"]["N"]);
		}
		if (OGNGMBLDAOP["WithdrawerId"] != null)
		{
			KHLGDCHJJPB.id = KHJJFPPACBP.BKFCLMMJNHK("WithdrawerId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["OtherPlayerId"] != null)
		{
			OHHGEFIENCF = KHJJFPPACBP.BKFCLMMJNHK("OtherPlayerId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["CardId"] != null)
		{
			ICDKHLOBKIE = KHJJFPPACBP.BKFCLMMJNHK("CardId", "S", OGNGMBLDAOP, string.Empty);
			if (OGNGMBLDAOP["BuddyCardData"] != null)
			{
				BCBJPGBDBAH = JsonConvert.DeserializeObject<CardManager.BuddyCardData>(KHJJFPPACBP.BKFCLMMJNHK("BuddyCardData", "S", OGNGMBLDAOP, string.Empty));
				IMMLKDCGONO = CardManager.instance.GetSquadCardInstance(ICDKHLOBKIE, BCBJPGBDBAH);
			}
			else
			{
				IMMLKDCGONO = CardManager.instance.GetCardInstance(ICDKHLOBKIE);
			}
		}
		if (OGNGMBLDAOP["ReputationPointsAdded"] != null)
		{
			GAAJLNJKDGC = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["ReputationPointsAdded"]["N"]);
		}
	}

	internal virtual Action KCMBKOKAILM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return HKFCPFCALBB;
	}

	internal virtual Action DCBNLOJFFMP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return FHBMAGJHNEK;
	}

	public virtual void MEDLNDILONN()
	{
		CALACCCGMGD();
	}

	public virtual void MHCEDJBCCFH()
	{
		IFFBCOLBDOP();
	}

	[SpecialName]
	public virtual bool JBNCMEICFEO()
	{
		return true;
	}

	internal virtual Action INCNCFNCILK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FALBNFDMKEG(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return DHFLAPICHPN;
	}

	internal virtual Action IKJNAPGLGKO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.AHELJCLFLMA(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			CJPBMDDGDHG();
		};
	}

	[SpecialName]
	public virtual bool PJJAHFFKBOJ()
	{
		return true;
	}

	[SpecialName]
	public virtual bool FBPHLEIENCI()
	{
		return true;
	}

	[SpecialName]
	public virtual bool BBGBHJLNNMP()
	{
		return true;
	}

	public virtual void ONEOGHLGFDH()
	{
		IFFBCOLBDOP();
	}

	internal virtual Action CBELMAGOICD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return INLAEAPHPAF;
	}

	[SpecialName]
	public virtual bool ACNPDLHOJBK()
	{
		return false;
	}

	[SpecialName]
	public virtual bool HNMFBIJOKIO()
	{
		return false;
	}

	[SpecialName]
	public virtual bool LDMDMHBAIBG()
	{
		return false;
	}

	[SpecialName]
	public virtual bool NMKNICIHPGB()
	{
		return true;
	}

	public virtual void NLMKCDMBPPC()
	{
		base.MGKMBCBBOHK();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("Spend_Warbucks_On_Weapons", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -113 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			OIDDCBBFBHJ();
		}
	}

	public virtual void CPFHDPLCOML()
	{
		IFFBCOLBDOP();
	}

	public virtual void FFLNPLLDBDC()
	{
		BCIOBLLBLLC();
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			CJPBMDDGDHG();
		};
	}

	[SpecialName]
	public virtual bool GAPAJHFLNCE()
	{
		return false;
	}

	public virtual void AHHCFAIJCAE()
	{
		base.LEJEDFACEGP();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("ID_CONFIRM_LEAVE_SPECTATE_TEXT", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -120 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			LACLELOOKHD();
		}
	}

	[SpecialName]
	public virtual bool GNNPBJAABFH()
	{
		return true;
	}

	[SpecialName]
	public virtual bool FCKLKCLBIDD()
	{
		return false;
	}

	public virtual void JLJMIOLJPNL()
	{
		base.OLECKGKLHCE();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("ID_CONFIRM_GAMEDIDNTEXIST", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = -72 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			AKICNBAOGOL();
		}
	}

	[SpecialName]
	public virtual bool GCDLIBOCJJH()
	{
		return false;
	}

	public NMNJDAANAOD(Card CEKHIJECPNP, DatabasePlayer FDPOFCGIGEJ, int MCLFGFMFBIB)
		: base($"WithdrewWarcard-{CEKHIJECPNP.id}-{FDPOFCGIGEJ.name}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}", NKHJBLBAAEB.SquadDepositedCardsChanged)
	{
		KHLGDCHJJPB = FDPOFCGIGEJ;
		IMMLKDCGONO = CEKHIJECPNP;
		ICDKHLOBKIE = CEKHIJECPNP.id;
		if (CEKHIJECPNP.isBuddyCard)
		{
			BCBJPGBDBAH = (CEKHIJECPNP as CardBuddy).buddyCardData;
		}
		GAAJLNJKDGC = MCLFGFMFBIB;
	}

	internal virtual Action MGMOGCPKFMM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return HPPKEBCDLEF;
	}

	internal virtual Action CBBAMHELDLB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FALBNFDMKEG(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return PGEBDCOCDAN;
	}

	internal virtual Action CJNKDPIAPPK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return DHFLAPICHPN;
	}

	public virtual void DFKOHIMOOGP()
	{
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool OPKBMOKEFEH()
	{
		return true;
	}

	[SpecialName]
	public virtual bool LOHCDCBAIIC()
	{
		return true;
	}

	internal virtual Action ACEMNJAJEOM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return HPPKEBCDLEF;
	}

	public virtual void GFEJDHOKENI()
	{
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool MLOPPEECLFP()
	{
		return true;
	}

	public virtual void AAAIKGFFKIF()
	{
		JFDENNGOGJC();
	}

	internal virtual Action EOGIDAEFGNI(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.AHELJCLFLMA(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return DHFLAPICHPN;
	}

	[SpecialName]
	public virtual bool GAGPKJLKDMM()
	{
		return false;
	}

	public virtual void PCEBBHFGLLE()
	{
		IFFBCOLBDOP();
	}

	[SpecialName]
	public virtual bool EDKDFECLLAK()
	{
		return false;
	}

	private void NEECCDLPDCP()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
		LACLELOOKHD();
	}

	internal virtual Action IDBJONAFGNO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.AHELJCLFLMA(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return PGEBDCOCDAN;
	}

	public virtual void NNPMLGOPHHD()
	{
		OJFJOJONNJK();
	}

	public virtual void OEFKFGJLFOO()
	{
		CALACCCGMGD();
	}

	internal virtual Action CAJNCPGAODK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return NEECCDLPDCP;
	}

	[SpecialName]
	public virtual bool NAJOCNFGPOA()
	{
		return true;
	}

	[SpecialName]
	public virtual bool EGDENFBHOLI()
	{
		return false;
	}

	internal virtual Action BFOJMDHENMA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.AHELJCLFLMA(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return PGEBDCOCDAN;
	}

	[SpecialName]
	public virtual bool HMILIHOLIFN()
	{
		return false;
	}

	public virtual void BJFPJGILOHP()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool PECLKBNDJPG()
	{
		return false;
	}

	public virtual void AEPMLADPOAB()
	{
		BCIOBLLBLLC();
	}

	public virtual void NBGFNLOCPAD()
	{
		base.LOFMDBHAFAO();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format(" ", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 107 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			OIDDCBBFBHJ();
		}
	}

	internal virtual Action BKLBFKCBFPP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return HPPKEBCDLEF;
	}

	[SpecialName]
	public virtual bool OOJCJCJEEGP()
	{
		return false;
	}

	internal virtual Action CPMODKNOJLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.AHELJCLFLMA(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return NEECCDLPDCP;
	}

	public virtual void FJEGCLHKBKA()
	{
		CALACCCGMGD();
	}

	public virtual void IHLHFKCKJAN()
	{
		OJFJOJONNJK();
	}

	public virtual void DIKMIBLAJIH()
	{
		JFDENNGOGJC();
	}

	internal virtual Action LKKLMINBLKK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.BGGHKBDLACJ(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return INLAEAPHPAF;
	}

	[SpecialName]
	public virtual bool COKCGHJKIPN()
	{
		return false;
	}

	[SpecialName]
	public virtual bool APIGINBBFAH()
	{
		return true;
	}

	internal virtual Action KBEKIOGPKKD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.AHELJCLFLMA(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return INLAEAPHPAF;
	}

	[SpecialName]
	public virtual bool NFGEGFCCKPB()
	{
		return false;
	}

	private void DHFLAPICHPN()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
		CGOOGHIJOAH();
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
		CJPBMDDGDHG();
	}

	public virtual void FJCHMJEBCCK()
	{
		BCIOBLLBLLC();
	}

	[SpecialName]
	public virtual bool JLMFBCHHBLD()
	{
		return false;
	}

	[SpecialName]
	public virtual bool FNMABKHBPFK()
	{
		return true;
	}

	public virtual void MOOOHCCCHLC()
	{
		OJFJOJONNJK();
	}

	public virtual void BHGDOHCBGEC()
	{
		base.GEKIMGFKNHC();
		if (DebugSettings.debugEnabled)
		{
			Debug.Log(string.Format("ID_DAILYMISSIONX", OHHGEFIENCF, GameLoginManager.currentPlayer.id));
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		bool flag = OHHGEFIENCF == currentPlayer.id;
		string squadName = currentPlayer.squadName;
		bool flag2 = 15 > Mathf.Abs(Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG);
		bool flag3 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		if (!string.IsNullOrEmpty(squadName) && flag2)
		{
			Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, FHKKPEIDDJN: true);
		}
		if (flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			if (!flag3)
			{
				GameLoginManager.instance.RemoveCardFromDeposited(ICDKHLOBKIE);
				Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
			}
		}
		else
		{
			CJPBMDDGDHG();
		}
	}

	internal virtual Action IHAPMLGGJEA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_WarcardWithdrew(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return INLAEAPHPAF;
	}

	internal virtual Action KLCMAALPAKG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FALBNFDMKEG(HPGHHECHLAN, KJCKFGCLGLG, KHLGDCHJJPB, IMMLKDCGONO, GAAJLNJKDGC);
		return delegate
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			CJPBMDDGDHG();
		};
	}

	[SpecialName]
	public virtual bool LPOHIDGNIFN()
	{
		return true;
	}
}
