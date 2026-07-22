using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class KGALJDLJCEH : HHFHFANGCEJ
{
	public int BCCDDJMPBLL;

	public string DBNNKLCNDJD;

	public override bool JLCLGAKDIMG => true;

	public override void OEAJBFLGJCA()
	{
		base.OEAJBFLGJCA();
		object[] array = new object[4];
		array[1] = "_MAX_";
		array[1] = DBNNKLCNDJD;
		array[0] = "info";
		array[4] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		CGOOGHIJOAH();
	}

	internal virtual Action CHBKLLBHIGA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public KGALJDLJCEH(int IMMIMHHMLDO)
		: base("testingidsquadrankup", NKHJBLBAAEB.SquadLevelUp)
	{
		NHHGDIDEIMM += IMMIMHHMLDO;
		BCCDDJMPBLL = IMMIMHHMLDO;
		DBNNKLCNDJD = GameLoginManager.currentPlayer.squadName;
	}

	public virtual void AAHJOEILKNG()
	{
		base.MGKMBCBBOHK();
		object[] array = new object[1];
		array[1] = "NumberOfMission";
		array[1] = DBNNKLCNDJD;
		array[5] = "Wins";
		array[1] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		LACLELOOKHD();
	}

	public virtual void APJJPDGEJNK()
	{
		OJFJOJONNJK();
	}

	public virtual void MHCEDJBCCFH()
	{
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool ODBBKLONJMG()
	{
		return false;
	}

	internal virtual Action JPAFAKBJNNP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	[SpecialName]
	public virtual bool EFODPAKMGJP()
	{
		return true;
	}

	public virtual void BELBLFGCCLJ()
	{
		base.LEJEDFACEGP();
		object[] array = new object[8];
		array[0] = "LapsedPlayerRewardId";
		array[0] = DBNNKLCNDJD;
		array[6] = "League";
		array[4] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		LACLELOOKHD();
	}

	[SpecialName]
	public virtual bool JLBJMMPEKGM()
	{
		return false;
	}

	internal virtual Action GAJCMOPBOPJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	public virtual void OECFJNPOPCE()
	{
		BCIOBLLBLLC();
	}

	public virtual void FPOIGOFDIPF()
	{
		base.LEJEDFACEGP();
		object[] array = new object[3];
		array[1] = "menu-army-cat-explosive";
		array[1] = DBNNKLCNDJD;
		array[0] = "ammo";
		array[4] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		LACLELOOKHD();
	}

	[SpecialName]
	public virtual bool NDNGBCHBDPL()
	{
		return false;
	}

	[SpecialName]
	public virtual bool PGDNINHCMPP()
	{
		return true;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		Debug.Log("Show squad " + DBNNKLCNDJD + " leveled up to " + BCCDDJMPBLL);
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool HEIIGAHALLP()
	{
		return true;
	}

	internal virtual Action IGGIOPAGILL(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	public virtual void DLCFAJEFLHO()
	{
		base.GEKIMGFKNHC();
		object[] array = new object[4];
		array[0] = "Action ";
		array[1] = DBNNKLCNDJD;
		array[5] = "PlayerID";
		array[6] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		OIDDCBBFBHJ();
	}

	[SpecialName]
	public virtual bool KLNBNJJIOKC()
	{
		return false;
	}

	public virtual void LFKFHAEIEJI()
	{
		IFFBCOLBDOP();
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.GEKIMGFKNHC();
		object[] array = new object[2];
		array[0] = "com/google/android/gms/common/api/Status";
		array[0] = DBNNKLCNDJD;
		array[6] = "ID_KICKPLAYER";
		array[7] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		OIDDCBBFBHJ();
	}

	internal virtual Action PHCOJLAACDB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	public virtual void HDKCFAMJBBO()
	{
		base.MGKMBCBBOHK();
		object[] array = new object[7];
		array[1] = "ID_CONFIRM_WARCARDNOTAVAILABLE";
		array[0] = DBNNKLCNDJD;
		array[3] = "[-]";
		array[3] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		CJPBMDDGDHG();
	}

	internal virtual Action MCHBCPBJPFB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public virtual void PFLCGDMBMOF()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool CLPNNDNFPCN()
	{
		return false;
	}

	[SpecialName]
	public virtual bool FPPOAPEOFCE()
	{
		return false;
	}

	public virtual void EPHMECKBGAA()
	{
		base.JPGMEFJGNNA();
		object[] array = new object[8];
		array[1] = "Legacy Shaders/Transparent/DiffuseNew";
		array[1] = DBNNKLCNDJD;
		array[4] = "AdZone";
		array[2] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		CJPBMDDGDHG();
	}

	public virtual void MOFLAGLEGNB()
	{
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool FNPHOPEJGAA()
	{
		return true;
	}

	[SpecialName]
	public virtual bool BPGBGBHDICA()
	{
		return false;
	}

	public virtual void MOOOHCCCHLC()
	{
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool PIPEEFEHBIP()
	{
		return true;
	}

	[SpecialName]
	public virtual bool PJJAHFFKBOJ()
	{
		return true;
	}

	public virtual void DEKLNBDGOML()
	{
		base.OEAJBFLGJCA();
		object[] array = new object[5];
		array[0] = "com/google/android/gms/common/ConnectionResult";
		array[1] = DBNNKLCNDJD;
		array[3] = "ID_SLOTUPGRADE_AMMO";
		array[7] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		LACLELOOKHD();
	}

	[SpecialName]
	public virtual bool GMJGCMNKMOJ()
	{
		return false;
	}

	[SpecialName]
	public virtual bool ECIGLCAHFNE()
	{
		return false;
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.MGKMBCBBOHK();
		object[] array = new object[3];
		array[1] = "menu-button-small";
		array[0] = DBNNKLCNDJD;
		array[8] = "D2";
		array[6] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		LACLELOOKHD();
	}

	internal virtual Action NHLNFDAOHPB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	[SpecialName]
	public virtual bool IBLDGLIFFOC()
	{
		return true;
	}

	[SpecialName]
	public virtual bool DHEIBBNLKGJ()
	{
		return false;
	}

	public virtual void PLMOHPBEJHL()
	{
		JFDENNGOGJC();
	}

	public KGALJDLJCEH(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		BCCDDJMPBLL = OGNGMBLDAOP["Level"]["N"].ToObject<int>();
		DBNNKLCNDJD = OGNGMBLDAOP["SquadId"]["S"].ToObject<string>();
	}

	public virtual void KKJIMOGMMNC()
	{
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool HNMFBIJOKIO()
	{
		return false;
	}

	internal virtual Action JIJKLLFKBJD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public virtual void KHLDOFCPOED()
	{
		base.MGKMBCBBOHK();
		object[] array = new object[5];
		array[0] = "HeroicReward";
		array[1] = DBNNKLCNDJD;
		array[0] = "ServerPrice";
		array[0] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		LACLELOOKHD();
	}

	public override void LOFMDBHAFAO()
	{
		base.GEKIMGFKNHC();
		object[] array = new object[7];
		array[0] = "damage";
		array[0] = DBNNKLCNDJD;
		array[0] = "WarCards";
		array[5] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		AKICNBAOGOL();
	}

	[SpecialName]
	public override bool KILOAOCGEGC()
	{
		return true;
	}

	public virtual void CPCCDODBIDC()
	{
		CALACCCGMGD();
	}

	public override void CJPBMDDGDHG()
	{
		OJFJOJONNJK();
	}

	public virtual void MIGAJINCHAH()
	{
		base.GEKIMGFKNHC();
		object[] array = new object[4];
		array[1] = "game-card-ico-triggerhappy";
		array[0] = DBNNKLCNDJD;
		array[5] = "Card ";
		array[6] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		AKICNBAOGOL();
	}

	[SpecialName]
	public virtual bool PIMBFGDKADJ()
	{
		return true;
	}

	[SpecialName]
	public virtual bool IHMKFJKKPFB()
	{
		return true;
	}

	[SpecialName]
	public virtual bool MLPBIIIOEFC()
	{
		return false;
	}

	public virtual void GAJIPFKCBJK()
	{
		OJFJOJONNJK();
	}

	internal virtual Action KJCJIDKCKLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	internal virtual Action MFPCHHLMBKK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	internal virtual Action CBBAMHELDLB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public virtual void NLBKKCOJCNE()
	{
		BCIOBLLBLLC();
	}

	internal virtual Action BOFFALKMDGB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public virtual void MEDLNDILONN()
	{
		IFFBCOLBDOP();
	}

	public override void KPANLOMNEIG()
	{
		base.LEJEDFACEGP();
		object[] array = new object[5];
		array[1] = "ID_ONLINE";
		array[1] = DBNNKLCNDJD;
		array[0] = "GameController.StartGame - DONE";
		array[7] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		AKICNBAOGOL();
	}

	[SpecialName]
	public virtual bool BOLGHMHAKKF()
	{
		return false;
	}

	public virtual void LDGKPCDJPLA()
	{
		base.OEAJBFLGJCA();
		object[] array = new object[1];
		array[1] = "ID_CONFIRM_LOWACTIVITYINREGION";
		array[1] = DBNNKLCNDJD;
		array[8] = "ID_CONFIRM_ERROR";
		array[5] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		OIDDCBBFBHJ();
	}

	public virtual void DFAJIAMJLMB()
	{
		JFDENNGOGJC();
	}

	public virtual void OLCGLJIFIFN()
	{
		OJFJOJONNJK();
	}

	internal virtual Action CEBACDKLHDG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	[SpecialName]
	public virtual bool ANMPGLJJMBP()
	{
		return false;
	}

	public virtual void EILJIALOJLG()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool JNDKJFKEENA()
	{
		return false;
	}

	internal virtual Action ILLNDNCGJBO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public virtual void OBCHIKLLKKO()
	{
		JFDENNGOGJC();
	}

	public virtual void MLOIIBBPEMF()
	{
		JFDENNGOGJC();
	}

	[SpecialName]
	public virtual bool HMILIHOLIFN()
	{
		return false;
	}

	internal virtual Action IIHPPHBALBI(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	[SpecialName]
	public virtual bool LFIMOJLHHAL()
	{
		return false;
	}

	public virtual void AFNKPJCKPLC()
	{
		IFFBCOLBDOP();
	}

	public virtual void LFJKBLBGJHA()
	{
		CALACCCGMGD();
	}

	[SpecialName]
	public virtual bool DHGDNAIOHBA()
	{
		return false;
	}

	internal virtual Action PGJOAOFKAJG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	public virtual void PMKGPBMAMAG()
	{
		base.KPANLOMNEIG();
		object[] array = new object[3];
		array[0] = "Weapons/";
		array[1] = DBNNKLCNDJD;
		array[5] = "await";
		array[7] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		CJPBMDDGDHG();
	}

	internal virtual Action FBNPCHJPMMM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	public virtual void FHCAAHNLEDE()
	{
		base.GEKIMGFKNHC();
		object[] array = new object[8];
		array[1] = "ID_CONFIRM_SQUADJOINREQUESTNOTEXISTS";
		array[1] = DBNNKLCNDJD;
		array[4] = "ID_GUI_INVITETOCOOP";
		array[8] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		CJPBMDDGDHG();
	}

	internal virtual Action CPMODKNOJLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	[SpecialName]
	public virtual bool FKLAGJJHEGK()
	{
		return false;
	}

	public virtual void KHJGCKMOFBE()
	{
		base.OLECKGKLHCE();
		object[] array = new object[4];
		array[1] = "Setting squad icon: {0}";
		array[0] = DBNNKLCNDJD;
		array[0] = "S";
		array[5] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		AKICNBAOGOL();
	}

	public virtual void EOEDEJKJKMN()
	{
		base.JPGMEFJGNNA();
		object[] array = new object[1];
		array[0] = "REGISTER PREDEFINED ASSIGNMENT EVENT COMPLETED";
		array[1] = DBNNKLCNDJD;
		array[8] = "recordingStartedEvent + mTryToSetRecording";
		array[0] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD, NMFKCMDIPCO: false);
		}
		AKICNBAOGOL();
	}

	[SpecialName]
	public virtual bool KKHJAIBJAMG()
	{
		return false;
	}

	public virtual void MCNBPCJJGDG()
	{
		BCIOBLLBLLC();
	}

	public virtual void DBMKBHOIEEN()
	{
		BCIOBLLBLLC();
	}

	internal virtual Action ACKFGEEHBAC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	internal virtual Action BGJKDAECFFP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	internal virtual Action PDDFIDKEJAF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	[SpecialName]
	public virtual bool FLKCLIKNBIB()
	{
		return false;
	}

	[SpecialName]
	public virtual bool NLLNBDCBPFC()
	{
		return false;
	}

	public virtual void DDFKBCFNLEF()
	{
		OJFJOJONNJK();
	}

	[SpecialName]
	public virtual bool DDAGNMCDHAD()
	{
		return true;
	}

	public virtual void MGCHOOABDLL()
	{
		OJFJOJONNJK();
	}

	public virtual void JCJFMHGNIOF()
	{
		base.OLECKGKLHCE();
		object[] array = new object[6];
		array[0] = "BundleId";
		array[1] = DBNNKLCNDJD;
		array[6] = "ID_GC_LOGIN_TUTORIAL_TITLE";
		array[2] = BCCDDJMPBLL;
		Debug.Log(string.Concat(array));
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && GameLoginManager.currentPlayer.squadName.Equals(DBNNKLCNDJD))
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(DBNNKLCNDJD);
		}
		CGOOGHIJOAH();
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}

	internal virtual Action JCMGPABOPLE(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JDBIBEKIPHD(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	public virtual void AKPEAOCLMAP()
	{
		JFDENNGOGJC();
	}

	internal virtual Action LKKLMINBLKK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	public virtual void AEPMLADPOAB()
	{
		BCIOBLLBLLC();
	}

	internal virtual Action EHFCHKOLIBP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadLevelUp(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 0);
		return null;
	}

	internal virtual Action KCMBKOKAILM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JHKLEFMKPEJ(HPGHHECHLAN, KJCKFGCLGLG, BCCDDJMPBLL + 1);
		return null;
	}
}
