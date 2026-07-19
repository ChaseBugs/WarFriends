using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class MBACFNICJPL : HHFHFANGCEJ
{
	public int BOHDLNLLLEC;

	public DatabasePlayer HAOFOOOAAIF;

	public DatabasePlayer KJCJCBPKKEM;

	public bool ABPNKPJOIAM;

	public string JBKABOGKNCN;

	public List<string> BOPBDJMCDGB;

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

	public override bool OBMJDKBCOAE
	{
		get
		{
			bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
			return !flag;
		}
	}

	internal virtual Action JIDPMCMEPFL(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return BHBFCOKBKLO;
	}

	public virtual void BJGDGMDOKLH()
	{
		base.OBJEMJHBJFO();
		Debug.Log(string.Format("FinishedBeginnersLeague", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + 76 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HKGAPGAKFHA(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
			}
			if (!flag2)
			{
				AKICNBAOGOL();
			}
		}
	}

	private void MLFFCOLAMOO()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool JDBGCAGBMHE()
	{
		bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		return flag;
	}

	internal virtual Action FIKDPEAPLJK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return GBDGGLJCBOL;
	}

	private void DKCPOMHKGIE()
	{
		if (!(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1)
		{
			NGGFDKAJFGB();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
		}
	}

	private void FCJBHCMKKLD()
	{
		if (!(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1)
		{
			HGMMPFGGMNB();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
		}
	}

	public virtual void IAJFPCPBKNE(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	[SpecialName]
	public virtual bool OBFFDCLKHGA()
	{
		return false;
	}

	public virtual void GBEBFIDEOHH()
	{
		base.LEJEDFACEGP();
		Debug.Log(string.Format("ID_TUTORIAL_DELIVERED_WEAPON", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -51 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
			}
			if (!flag2)
			{
				CJPBMDDGDHG();
			}
		}
	}

	private void FPJIIPJFENG()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool JCOBHGJHEMB()
	{
		return true;
	}

	private void DPMOHDGGFKO()
	{
		OJFJOJONNJK();
	}

	private void JDDENPOLADB()
	{
		OJFJOJONNJK();
	}

	public virtual void NBBAANHAAKK()
	{
		base.KPANLOMNEIG();
		Debug.Log(string.Format("ID_PLAYXRANKEDBATTLESTOENTERLEAGUE", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -105 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HKGAPGAKFHA(this, flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
			}
			if (!flag2)
			{
				CGOOGHIJOAH();
			}
		}
	}

	[SpecialName]
	public virtual bool GJAFEHILAKB()
	{
		return false;
	}

	[SpecialName]
	public virtual bool LLDKOPGBIBF()
	{
		return true;
	}

	[SpecialName]
	public virtual bool KKPCDNBODPF()
	{
		return false;
	}

	[SpecialName]
	public virtual bool OBOFEFBDAGN()
	{
		return true;
	}

	internal virtual Action GBOCABIBGDO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return JEPNIADHMPI;
	}

	public override void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	public virtual void IJPAEHAGPFK()
	{
		base.OLECKGKLHCE();
		Debug.Log(string.Format(", [variables])", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + 104 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.BGOHKEGGHMH(this, flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
		}
		else if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GDDDOGFCHFH(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName, true);
			}
			if (!flag2)
			{
				CGOOGHIJOAH();
			}
		}
	}

	internal virtual Action OLGGKGBCHAC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return IGHFHOFLAJL;
	}

	[SpecialName]
	public virtual bool DPAGGJAHOGF()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return flag;
	}

	[SpecialName]
	public virtual bool IIPHFOBEANP()
	{
		return true;
	}

	private void CPFIKMFJAEH()
	{
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool EDKDFECLLAK()
	{
		return true;
	}

	[SpecialName]
	public virtual bool MFKOLEKIKGK()
	{
		return true;
	}

	private void HGMMPFGGMNB()
	{
		OJFJOJONNJK();
	}

	private void GPHBOGGHHPJ()
	{
		BCIOBLLBLLC();
	}

	public virtual void BMNNPNCDKFH(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	internal virtual Action HOMAJDPBHJK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return DKCPOMHKGIE;
	}

	public virtual void FJILILFMPIF()
	{
		base.GEKIMGFKNHC();
		Debug.Log(string.Format("DOWNLOADBTN", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -74 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
		}
		else if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName, true);
			}
			if (!flag2)
			{
				AKICNBAOGOL();
			}
		}
	}

	private void OLIKKBGNGGJ()
	{
		if (!(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1)
		{
			FPJIIPJFENG();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
		}
	}

	[SpecialName]
	public virtual bool HLENLJEMEKC()
	{
		return true;
	}

	internal virtual Action PFNPDDDKALB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return OLIKKBGNGGJ;
	}

	[SpecialName]
	public virtual bool GDBPAOPJNMN()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return !flag;
	}

	[SpecialName]
	public virtual bool LBJGPLIEIOF()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return !flag;
	}

	[SpecialName]
	public virtual bool KOELEIKFPEG()
	{
		bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		return flag;
	}

	internal virtual Action CDFKIOIDHAN(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadDemotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return OLIKKBGNGGJ;
	}

	[SpecialName]
	public virtual bool JGCICDHMIMJ()
	{
		bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		return flag;
	}

	public virtual void DFAJIAMJLMB()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 114 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			object[] array = new object[3];
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_INPROGRESS", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF(), "ID_YES", string.Empty, false);
			array[6] = flag;
			Debug.LogFormat("Enemy could not be spawned", array);
			OAODLJGIECM();
		}
	}

	[SpecialName]
	public virtual bool PILEOIJLHEE()
	{
		return false;
	}

	[SpecialName]
	public virtual bool PKOCAGBLHFJ()
	{
		bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		return flag;
	}

	internal virtual Action GEJJDEHLBMJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return LJLCGOJCKME;
	}

	private void OAODLJGIECM()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool ECPMPDELNLJ()
	{
		return false;
	}

	public virtual void KKKPABLHLCJ(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	[SpecialName]
	public virtual bool IMDECOOFMBH()
	{
		return false;
	}

	[SpecialName]
	public virtual bool PNGMNGMEOFM()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return flag;
	}

	[SpecialName]
	public virtual bool OLOHGBBGGFF()
	{
		return true;
	}

	public virtual void PAFPBIGHJCI()
	{
		base.JPGMEFJGNNA();
		Debug.Log(string.Format("Win", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + 96 > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.JEDKOPACCOL(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
			}
			if (!flag2)
			{
				CGOOGHIJOAH();
			}
		}
	}

	[SpecialName]
	public virtual bool ONJNHBCNCBM()
	{
		return true;
	}

	internal virtual Action INCNCFNCILK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadDemotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return FCJBHCMKKLD;
	}

	public virtual void NOKLOABMGFN(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	public MBACFNICJPL(DatabasePlayer KHLGDCHJJPB, DatabasePlayer LIAFEPFJAKM)
		: base(string.Format("DemoteOrKickPlayer {0}", Singleton<BeanstalkServerManager>.instance.currentTimestamp), NKHJBLBAAEB.SquadDemotion)
	{
		Debug.Log(string.Format("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}", (KHLGDCHJJPB != null) ? KHLGDCHJJPB.debugBasicInformation : "null"));
		ABPNKPJOIAM = true;
		HAOFOOOAAIF = KHLGDCHJJPB;
		KJCJCBPKKEM = LIAFEPFJAKM;
		JBKABOGKNCN = KJCJCBPKKEM.squadName;
		if (KHLGDCHJJPB != null)
		{
			BOHDLNLLLEC = (int)KHLGDCHJJPB.squadRank;
		}
	}

	private void AMAGBFANAOO()
	{
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool GGMFNDNKJMH()
	{
		return false;
	}

	public virtual void EKGIMBEJLFH()
	{
		base.JPGMEFJGNNA();
		Debug.Log(string.Format(" - loggin goldCost: ", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -118 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.BGOHKEGGHMH(this, flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
			}
			if (!flag2)
			{
				AKICNBAOGOL();
			}
		}
	}

	internal virtual Action NMCDBKLHFOB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LEKGKBCHBLO(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return DKCPOMHKGIE;
	}

	public virtual void EMHGOECGAFL()
	{
		base.GEKIMGFKNHC();
		Debug.Log(string.Format(">", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -102 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HKGAPGAKFHA(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HKGAPGAKFHA(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.JKJOCCOGLAI(squadName);
			}
			if (!flag2)
			{
				CGOOGHIJOAH();
			}
		}
	}

	[SpecialName]
	public virtual bool DAMHMEOPABN()
	{
		return true;
	}

	public virtual void CDPOPKKBOAI(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	public virtual void HADGABHFFJL(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadDemotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return delegate
		{
			if (HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1)
			{
				HGMMPFGGMNB();
			}
			else
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
			}
		};
	}

	public virtual void PLCBOLBMJKA()
	{
		base.KPANLOMNEIG();
		Debug.Log(string.Format("Manual_Unit_Spawn", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -112 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.ONIBJDJIAMO())
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this, flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
			}
			if (!flag2)
			{
				CGOOGHIJOAH();
			}
		}
	}

	public virtual void JJBACELJEFA()
	{
		bool flag = string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + -105 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			object[] array = new object[5];
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "Automatic_Equip", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_GETSP", string.Empty, false);
			array[7] = flag;
			Debug.LogFormat("Enable Debug Mode", array);
			OAODLJGIECM();
		}
	}

	public virtual void LBHAHNFALLB()
	{
		base.LOFMDBHAFAO();
		Debug.Log(string.Format("DamageEventShoot", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + -122 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.BGOHKEGGHMH(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
		}
		else if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.OGJDPPDGANP(squadName);
			}
			if (!flag2)
			{
				CGOOGHIJOAH();
			}
		}
	}

	[SpecialName]
	public virtual bool MALNIIDDEGO()
	{
		return true;
	}

	public virtual void EDHOCGOEJOH(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	[SpecialName]
	public virtual bool FCKLKCLBIDD()
	{
		return false;
	}

	private void BHBFCOKBKLO()
	{
		if (!(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1)
		{
			DPMOHDGGFKO();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		}
	}

	internal virtual Action CJBPOKIEGDO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadDemotion(HPGHHECHLAN, KJCKFGCLGLG, BOHDLNLLLEC, HAOFOOOAAIF, KJCJCBPKKEM);
		return FCJBHCMKKLD;
	}

	[SpecialName]
	public virtual bool MBCFENPEEFE()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return !flag;
	}

	public virtual void HBHNILCNHKO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	public MBACFNICJPL(DatabasePlayer KHLGDCHJJPB, int EEBCPJMFBDG, DatabasePlayer LIAFEPFJAKM)
		: base(string.Format("DemoteOrKickPlayer {0} {1}", EEBCPJMFBDG, Singleton<BeanstalkServerManager>.instance.currentTimestamp), NKHJBLBAAEB.SquadDemotion)
	{
		Debug.Log(string.Format("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}\t\tNewRank:{1}", KHLGDCHJJPB.debugBasicInformation, EEBCPJMFBDG));
		ABPNKPJOIAM = true;
		HAOFOOOAAIF = KHLGDCHJJPB;
		BOHDLNLLLEC = EEBCPJMFBDG;
		KJCJCBPKKEM = LIAFEPFJAKM;
		JBKABOGKNCN = KJCJCBPKKEM.squadName;
	}

	[SpecialName]
	public virtual bool DHFCDHMPEJA()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return flag;
	}

	[SpecialName]
	public virtual bool DKECEAGCNEE()
	{
		return true;
	}

	public override void IDIIHLPJLGF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	[SpecialName]
	public virtual bool PIOKJHCKPBE()
	{
		bool flag = !(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1;
		return flag;
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		if (HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1)
		{
			HGMMPFGGMNB();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		}
	}

	public virtual void BMICGPJALBH(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	public virtual void OLBFMNNKJOM(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	[SpecialName]
	public virtual bool HFGAIHBGMIK()
	{
		bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		return flag;
	}

	[SpecialName]
	public virtual bool HHJFHCMAJNK()
	{
		return false;
	}

	[SpecialName]
	public virtual bool OKNONEAGDGI()
	{
		bool flag = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		return !flag;
	}

	[SpecialName]
	public virtual bool AHOPJFNOPFP()
	{
		return true;
	}

	[SpecialName]
	public virtual bool EHBDIAFPENG()
	{
		return true;
	}

	public override void CJPBMDDGDHG()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 172800 < Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!flag || flag2)
		{
			Debug.LogFormat("#PETER# Removing squad demote/kick message - message time:{0}, server time:{1}, isInSquad:{2}", MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "ID_READYTIME", string.Empty), MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty), flag);
			HGMMPFGGMNB();
		}
	}

	public virtual void LPBAPDJONJO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (HAOFOOOAAIF.id == KHLGDCHJJPB.id)
		{
			HAOFOOOAAIF.level = KHLGDCHJJPB.level;
			HAOFOOOAAIF.squadName = KHLGDCHJJPB.squadName;
		}
	}

	public virtual void PMNCKDDLNIL()
	{
		bool flag = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		bool flag2 = KJCKFGCLGLG + 107 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (!flag || flag2)
		{
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.CJCFPDLDMEK(KJCKFGCLGLG, "Wrong_Weapon", string.Empty);
			array[0] = MEJMLNDFDBP.CJCFPDLDMEK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN(), "Warbucks", string.Empty, false);
			array[6] = flag;
			Debug.LogFormat("TotalPacketBytes: {0} TotalCommandBytes: {1} TotalPacketCount: {2} TotalCommandsInPackets: {3} UnreliableCommandCount: {4} ReliableCommandCount: {5}", array);
			OAODLJGIECM();
		}
	}

	private void NGGFDKAJFGB()
	{
		OJFJOJONNJK();
	}

	private void JEPNIADHMPI()
	{
		if (!(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1)
		{
			FPJIIPJFENG();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		}
	}

	private void LJLCGOJCKME()
	{
		if (HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1)
		{
			MLFFCOLAMOO();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		Debug.Log(string.Format("DatabaseMessage - SquadDemoteMessage:\nPlayer to be demoted/kicked: {0}\nNewRank: {1}\nBy Player: {2}", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + 60 > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
		}
		else if (Singleton<Chat>.instance.shouldChat)
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AddDatabaseMessageToSquadChat(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (!string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
			}
			if (!flag2)
			{
				CJPBMDDGDHG();
			}
		}
	}

	[SpecialName]
	public virtual bool KKHJAIBJAMG()
	{
		return true;
	}

	public virtual void LIEAKPFPAJD()
	{
		base.LEJEDFACEGP();
		Debug.Log(string.Format("menu-assignments-type-crate", HAOFOOOAAIF.debugBasicInformation, BOHDLNLLLEC, KJCJCBPKKEM.debugBasicInformation));
		bool flag = KJCJCBPKKEM.id == GameLoginManager.currentPlayer.id;
		bool flag2 = HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1;
		bool flag3 = KJCKFGCLGLG + 55 > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		bool flag4 = Singleton<BeanstalkServerManager>.instance.timestampPlayerDataLoaded > KJCKFGCLGLG;
		bool flag5 = GameLoginManager.currentPlayer.squadName == JBKABOGKNCN;
		if (BOHDLNLLLEC == -1)
		{
			if (Singleton<Chat>.instance.shouldChat)
			{
				if (flag2)
				{
					GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
				}
				else
				{
					GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.IFODCLGEEEE(this, !flag);
				}
			}
			else if (!ABPNKPJOIAM && !flag)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
		}
		else if (Singleton<Chat>.instance.ONIBJDJIAMO())
		{
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GCFGHDLENAL(this, !flag);
		}
		else if (!ABPNKPJOIAM && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
		if (!ABPNKPJOIAM)
		{
			if (flag2 && !flag4 && flag5)
			{
				GameLoginManager.instance.RemovePlayerFromSquad(BOPBDJMCDGB);
			}
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName) && flag3)
			{
				Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(squadName, true);
			}
			if (!flag2)
			{
				LACLELOOKHD();
			}
		}
	}

	private void IGHFHOFLAJL()
	{
		if (!(HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id) || BOHDLNLLLEC == -1)
		{
			MLFFCOLAMOO();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		}
	}

	public MBACFNICJPL(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		ABPNKPJOIAM = false;
		HAOFOOOAAIF = new DatabasePlayer();
		if (OGNGMBLDAOP["PlayerName"] != null)
		{
			HAOFOOOAAIF.accountName = KHJJFPPACBP.BKFCLMMJNHK("PlayerName", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Level"] != null)
		{
			HAOFOOOAAIF.level = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["Level"]["N"]);
		}
		if (OGNGMBLDAOP["SquadId"] != null)
		{
			HAOFOOOAAIF.squadName = KHJJFPPACBP.BKFCLMMJNHK("SquadId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["KickedPlayerId"] != null)
		{
			HAOFOOOAAIF.id = KHJJFPPACBP.BKFCLMMJNHK("KickedPlayerId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["DemotedPlayerId"] != null)
		{
			HAOFOOOAAIF.id = KHJJFPPACBP.BKFCLMMJNHK("DemotedPlayerId", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["SquadKickedFrom"] != null)
		{
			JBKABOGKNCN = KHJJFPPACBP.BKFCLMMJNHK("SquadKickedFrom", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["SquadRank"] != null)
		{
			HAOFOOOAAIF.squadRank = (SquadRank)KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["SquadRank"]["N"]);
			BOHDLNLLLEC = (int)HAOFOOOAAIF.squadRank;
		}
		else
		{
			BOHDLNLLLEC = -1;
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
		if (OGNGMBLDAOP["KickedPlayerDepositedCards"] != null && HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1)
		{
			Debug.Log("Got kicked player deposited WarCards => pasing them to GameLoginManager");
			BOPBDJMCDGB = JsonConvert.DeserializeObject<List<string>>(KHJJFPPACBP.BKFCLMMJNHK("KickedPlayerDepositedCards", "S", OGNGMBLDAOP, string.Empty));
		}
	}

	[SpecialName]
	public virtual bool JNDKJFKEENA()
	{
		return false;
	}

	private void GBDGGLJCBOL()
	{
		if (HAOFOOOAAIF.id == GameLoginManager.currentPlayer.id && BOHDLNLLLEC == -1)
		{
			CPFIKMFJAEH();
		}
		else
		{
			GuiScreenSingle<SquadScreen>.instance.CAGBHGLFPEB();
		}
	}
}
