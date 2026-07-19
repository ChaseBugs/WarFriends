using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class HLHBMMCBHJF : HHFHFANGCEJ
{
	public AANECPGDMGM MIDDFOCJJOP;

	public DatabasePlayer KFOJIMIENHB;

	public int EDFJFGKIDNI
	{
		get
		{
			return MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.MGDCJLAENHG();
		}
	}

	public override bool LOJJMCMKECE
	{
		get
		{
			return false;
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
			return false;
		}
	}

	[SpecialName]
	public int CHMEGDNLCCL()
	{
		return MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.DLDHIJAEFHG();
	}

	public virtual void AOLPIJDBFMC(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (KFOJIMIENHB.id == KHLGDCHJJPB.id)
		{
			KFOJIMIENHB.level = KHLGDCHJJPB.level;
		}
	}

	public HLHBMMCBHJF(string CGIFEHPDBAL)
		: base("testingidsquadinvite", NKHJBLBAAEB.SquadInvitation)
	{
		NHHGDIDEIMM += CGIFEHPDBAL;
		MIDDFOCJJOP = new AANECPGDMGM
		{
			MHPNDNJDPGE = CGIFEHPDBAL,
			CJDHKJFKNAH = 1000,
			FOICGJEPBGL = 5,
			PNAKMCNGGHE = "Testing squad invite MC",
			DAANKCOLJGJ = "menu-squad-10",
			GDFOENAJEBA = 100,
			IKJHAHJHLIH = 3
		};
		KFOJIMIENHB = new DatabasePlayer
		{
			accountName = "Testing Player",
			level = 6,
			squadName = "Squad"
		};
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	[SpecialName]
	public virtual bool BCPANGMNBPE()
	{
		return true;
	}

	[SpecialName]
	public virtual bool LHGAOLCOFHB()
	{
		return false;
	}

	[SpecialName]
	public virtual bool JNGEJNFDAHO()
	{
		return true;
	}

	private void CIIHFNKBLHM()
	{
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	[SpecialName]
	public virtual bool NJBGFDDLBFD()
	{
		return true;
	}

	[SpecialName]
	public virtual bool LONNJNKEDBP()
	{
		return true;
	}

	[SpecialName]
	public int FFJLCPIGDGB()
	{
		return MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.MGDCJLAENHG();
	}

	internal virtual Action MCOBONFBIBF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return CIIHFNKBLHM;
	}

	[SpecialName]
	public int EPBIKJHFKMH()
	{
		return MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.DLDHIJAEFHG();
	}

	public virtual void AAAIKGFFKIF()
	{
		Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(MIDDFOCJJOP.MHPNDNJDPGE, NHHGDIDEIMM);
		Debug.Log("#AccoutCheck# account exist");
	}

	internal virtual Action GBOCABIBGDO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return FCJBHCMKKLD;
	}

	public virtual void PHEFLAHPMDH()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	public virtual void IEEENGDDELF()
	{
		Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(MIDDFOCJJOP.MHPNDNJDPGE, NHHGDIDEIMM);
		Debug.Log("ID_POWERBANDBOX");
	}

	internal virtual Action BKLBFKCBFPP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return FCJBHCMKKLD;
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return delegate
		{
			GuiElementSingle<FightDialog>.instance.ShowDialog(this);
		};
	}

	public virtual void LPBAPDJONJO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (KFOJIMIENHB.id == KHLGDCHJJPB.id)
		{
			KFOJIMIENHB.level = KHLGDCHJJPB.level;
		}
	}

	internal virtual Action PBHMNAPHDPG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return FCJBHCMKKLD;
	}

	[SpecialName]
	public virtual bool FPPOAPEOFCE()
	{
		return false;
	}

	[SpecialName]
	public virtual bool PABPGPHNMBJ()
	{
		return true;
	}

	[SpecialName]
	public virtual bool NJCBCOPKFNE()
	{
		return true;
	}

	[SpecialName]
	public virtual bool NBMENHJCJPL()
	{
		return false;
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	[SpecialName]
	public virtual bool PNGMNGMEOFM()
	{
		return true;
	}

	[SpecialName]
	public virtual bool IGDONKCHDHP()
	{
		return false;
	}

	[SpecialName]
	public virtual bool PIMBFGDKADJ()
	{
		return false;
	}

	internal virtual Action EEEIHMLHDOC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return FCJBHCMKKLD;
	}

	[SpecialName]
	public virtual bool GNGMHNEEEIF()
	{
		return false;
	}

	private void FCJBHCMKKLD()
	{
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	[SpecialName]
	public virtual bool DBNLGKJPINP()
	{
		return false;
	}

	public virtual void ONCKKJFAMKF()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	public virtual void NCDFHFDHCLC()
	{
		Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(MIDDFOCJJOP.MHPNDNJDPGE, NHHGDIDEIMM);
		Debug.Log("null");
	}

	[SpecialName]
	public virtual bool COKCGHJKIPN()
	{
		return false;
	}

	[SpecialName]
	public virtual bool NIONPEJLLBK()
	{
		return false;
	}

	internal virtual Action DBEMJDBHDIM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadInvitation(HPGHHECHLAN, KJCKFGCLGLG, KFOJIMIENHB);
		return GEEKIKMPIOB;
	}

	[SpecialName]
	public override bool PHFNIOBIKML()
	{
		return true;
	}

	public override void CJPBMDDGDHG()
	{
		Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(MIDDFOCJJOP.MHPNDNJDPGE, NHHGDIDEIMM);
		Debug.Log("Squad Invitation Accept!");
	}

	[SpecialName]
	public int POCOEBIKGDI()
	{
		return MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.FJFIHGNGAKD();
	}

	[SpecialName]
	public virtual bool MBFPKJKHKFF()
	{
		return false;
	}

	[SpecialName]
	public virtual bool ECKNIELGBDK()
	{
		return true;
	}

	public virtual void GGHDIAFACAH()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	[SpecialName]
	public virtual bool ANNMAOEONGA()
	{
		return true;
	}

	public override void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (KFOJIMIENHB.id == KHLGDCHJJPB.id)
		{
			KFOJIMIENHB.level = KHLGDCHJJPB.level;
		}
	}

	[SpecialName]
	public virtual bool HNJMGNICMLM()
	{
		return true;
	}

	public virtual void LLAGJKKEEFC()
	{
		Singleton<BeanstalkServerManager>.instance.LINEMJAIGMI(MIDDFOCJJOP.MHPNDNJDPGE, NHHGDIDEIMM);
		Debug.Log("bazooka_reload");
	}

	public virtual void PNKLPNGGMBA(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (KFOJIMIENHB.id == KHLGDCHJJPB.id)
		{
			KFOJIMIENHB.level = KHLGDCHJJPB.level;
		}
	}

	public HLHBMMCBHJF(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		if (OGNGMBLDAOP["Squad"] != null)
		{
			JToken lFPFCHIJLML = JsonConvert.DeserializeObject<JToken>(OGNGMBLDAOP["Squad"]["S"].ToString());
			MIDDFOCJJOP = AANECPGDMGM.MAINIENLLIL(lFPFCHIJLML);
		}
		else
		{
			MIDDFOCJJOP = new AANECPGDMGM();
		}
		if (OGNGMBLDAOP["OtherPlayer"] != null)
		{
			JToken item = JsonConvert.DeserializeObject<JToken>(OGNGMBLDAOP["OtherPlayer"]["S"].ToString());
			KFOJIMIENHB = DatabasePlayer.CreateFromDatabase(item);
		}
		else
		{
			KFOJIMIENHB = new DatabasePlayer();
		}
	}

	[SpecialName]
	public virtual bool AJJDKODBLIF()
	{
		return false;
	}

	private void GEEKIKMPIOB()
	{
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	[SpecialName]
	public virtual bool MFKOLEKIKGK()
	{
		return false;
	}

	[SpecialName]
	public virtual bool BCKAOIDIHDI()
	{
		return true;
	}

	[SpecialName]
	public virtual bool CPADMJAEPIP()
	{
		return false;
	}
}
