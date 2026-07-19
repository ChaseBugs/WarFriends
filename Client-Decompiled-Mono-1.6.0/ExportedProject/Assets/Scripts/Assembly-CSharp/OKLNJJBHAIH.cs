using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class OKLNJJBHAIH : HHFHFANGCEJ
{
	public int PDKIAALFDNG;

	public int MOEMPHPNBLM;

	public string DBNNKLCNDJD;

	public override bool JLCLGAKDIMG
	{
		get
		{
			return true;
		}
	}

	public OKLNJJBHAIH(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		PDKIAALFDNG = OGNGMBLDAOP["Tier"]["N"].ToObject<int>();
		DBNNKLCNDJD = OGNGMBLDAOP["SquadId"]["S"].ToObject<string>();
		MOEMPHPNBLM = OGNGMBLDAOP["Reward"]["N"].ToObject<int>();
	}

	public virtual void FAEBCMCJNNN()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	[SpecialName]
	public virtual bool PJJAHFFKBOJ()
	{
		return true;
	}

	public virtual void FNNMBGBPCGL()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	[SpecialName]
	public virtual bool EGGJHNGCCIE()
	{
		return true;
	}

	private void CCPPBMANOGC()
	{
		object[] array = new object[1];
		array[1] = "Crafted warcard ";
		array[1] = MOEMPHPNBLM;
		array[1] = ", message = ";
		array[0] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("deviceLogin", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("ID_CONFIRM_ERROR");
		CGOOGHIJOAH();
	}

	private void ADNPHLPCIJP()
	{
		object[] array = new object[3];
		array[1] = "ID_CONFIRM_FBLOGINCANCELLED";
		array[1] = MOEMPHPNBLM;
		array[2] = "#AccoutCheck# Facebook account found during account loading!!! - TODO!";
		array[1] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("ID_EXPIRED", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("MessageId");
		AKICNBAOGOL();
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private void AGEBFLBJAON()
	{
		object[] array = new object[6];
		array[1] = "menu-arena-scrap-ico";
		array[0] = MOEMPHPNBLM;
		array[7] = "Client has newer config for: {0} Saved version {1} Client version {2}";
		array[0] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("ID_TWITTER_GAIN_TITLE", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ(" GC connect: ");
		CJPBMDDGDHG();
	}

	internal virtual Action ILLFKEIJILN(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadEventTierReward(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 0, MOEMPHPNBLM);
		return IGKJJMDOBPB;
	}

	public virtual void OBCHIKLLKKO()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void AKEDBAFMHMH()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	[SpecialName]
	public virtual bool IFDECABKHKO()
	{
		return true;
	}

	[SpecialName]
	public virtual bool NLKIOKAOCIN()
	{
		return false;
	}

	public virtual void JEDGCOMDEKM()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	[SpecialName]
	public override bool IJELOOFLPCK()
	{
		return false;
	}

	public override void CJPBMDDGDHG()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action OBJIHCHMPHA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.EJLHEFIPGCD(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 1, MOEMPHPNBLM);
		return delegate
		{
			Debug.Log("Claiming reward " + MOEMPHPNBLM + " Golds for squad event - completed tier " + PDKIAALFDNG);
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", MOEMPHPNBLM);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Claim_Reward");
			CJPBMDDGDHG();
		};
	}

	public virtual void CPFHDPLCOML()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	[SpecialName]
	public virtual bool PIPEEFEHBIP()
	{
		return false;
	}

	[SpecialName]
	public virtual bool GJAFEHILAKB()
	{
		return false;
	}

	public virtual void CALBGDIEDGA()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	internal virtual Action CDNHFOFKLBM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.EJLHEFIPGCD(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 1, MOEMPHPNBLM);
		return CCPPBMANOGC;
	}

	private void FHHADMEGKKL()
	{
		object[] array = new object[0];
		array[1] = "1";
		array[1] = MOEMPHPNBLM;
		array[5] = " NOT OK!\t\t\t\t\t\t";
		array[2] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("FinishGameCoopClient", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("EventAssignmentCompleted");
		AKICNBAOGOL();
	}

	public virtual void GMKKBHBNDNG()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void IIBCLAOHFIM()
	{
		object[] array = new object[2];
		array[1] = "Password";
		array[0] = MOEMPHPNBLM;
		array[2] = ", hasError = ";
		array[7] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("100+.", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Something went wrong in updating players in league");
		CGOOGHIJOAH();
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		Debug.Log("Claiming reward " + MOEMPHPNBLM + " Golds for squad event - completed tier " + PDKIAALFDNG);
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Claim_Reward");
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool OLOHGBBGGFF()
	{
		return true;
	}

	public virtual void GBEBFIDEOHH()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	private void EDDBKHKJICI()
	{
		object[] array = new object[8];
		array[1] = "grenade";
		array[1] = MOEMPHPNBLM;
		array[3] = "DeviceToken";
		array[0] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("Level", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("doesnt exist");
		CJPBMDDGDHG();
	}

	public virtual void PEDMMNGPBGO()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	[SpecialName]
	public virtual bool AOLEAGFICBC()
	{
		return false;
	}

	private void BMGMICNKCLG()
	{
		object[] array = new object[7];
		array[0] = "\t\"TRUE\"";
		array[0] = MOEMPHPNBLM;
		array[5] = "null";
		array[2] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn(" ID_", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("registerParentalConsent");
		CJPBMDDGDHG();
	}

	internal virtual Action BKFAOJMIOGB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadEventTierReward(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 1, MOEMPHPNBLM);
		return IGKJJMDOBPB;
	}

	public OKLNJJBHAIH(int FPCCEPIAEKG, int EOHOJBOGNAO)
		: base("testingideventtierreward", NKHJBLBAAEB.SquadEventTierReward)
	{
		NHHGDIDEIMM += FPCCEPIAEKG;
		PDKIAALFDNG = FPCCEPIAEKG;
		MOEMPHPNBLM = EOHOJBOGNAO;
	}

	public virtual void NNPILDOKNJO()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	public virtual void FJILILFMPIF()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	[SpecialName]
	public virtual bool KLNBNJJIOKC()
	{
		return false;
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadEventTierReward(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 1, MOEMPHPNBLM);
		return delegate
		{
			Debug.Log("Claiming reward " + MOEMPHPNBLM + " Golds for squad event - completed tier " + PDKIAALFDNG);
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", MOEMPHPNBLM);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Claim_Reward");
			CJPBMDDGDHG();
		};
	}

	public virtual void ILFJPOOMFDO()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	private void LNLDKBGABML()
	{
		object[] array = new object[4];
		array[1] = "#AccoutCheck# missing ID from server";
		array[1] = MOEMPHPNBLM;
		array[6] = "ID_GUI_EMPTYUNITUPGRADE";
		array[0] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("com.tune.TuneLocation", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("id");
		AKICNBAOGOL();
	}

	internal virtual Action BFDIJGGPNCO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FOFICMCMEHE(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 0, MOEMPHPNBLM);
		return delegate
		{
			Debug.Log("Claiming reward " + MOEMPHPNBLM + " Golds for squad event - completed tier " + PDKIAALFDNG);
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", MOEMPHPNBLM);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Claim_Reward");
			CJPBMDDGDHG();
		};
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}

	[SpecialName]
	public virtual bool GAGPKJLKDMM()
	{
		return false;
	}

	internal virtual Action ECCIIHOIOKM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.EJLHEFIPGCD(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 0, MOEMPHPNBLM);
		return ADNPHLPCIJP;
	}

	public virtual void ENJDCLOIMFL()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void EKNDHCNIJFG()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
	}

	public virtual void JMBBLKNBELP()
	{
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action CJNKDPIAPPK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FOFICMCMEHE(HPGHHECHLAN, KJCKFGCLGLG, PDKIAALFDNG + 0, MOEMPHPNBLM);
		return LNLDKBGABML;
	}

	private void IGKJJMDOBPB()
	{
		object[] array = new object[2];
		array[0] = "ID_GUI_SQUADPROMOTETEXT";
		array[1] = MOEMPHPNBLM;
		array[5] = "Xp";
		array[8] = PDKIAALFDNG;
		Debug.Log(string.Concat(array));
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("S", MOEMPHPNBLM);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("PlayerData");
		CJPBMDDGDHG();
	}

	public virtual void KHCIMEFCJFC()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
	}
}
