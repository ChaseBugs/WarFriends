using System;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class KEGHCEANIDJ : HHFHFANGCEJ
{
	public int LJGAGHAJLLO;

	public int LOKOIPMDFHJ;

	public override bool JLCLGAKDIMG => true;

	[SpecialName]
	public virtual bool NLLNBDCBPFC()
	{
		return true;
	}

	public virtual void BHGDOHCBGEC()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		CJPBMDDGDHG();
	}

	[SpecialName]
	public virtual bool KBPELCOEFKI()
	{
		return true;
	}

	public KEGHCEANIDJ(int FPCCEPIAEKG, int ACEKCACFHJL)
		: base("testingideventended", NKHJBLBAAEB.WelcomBackSoldierMessage)
	{
		NHHGDIDEIMM += FPCCEPIAEKG;
		LJGAGHAJLLO = FPCCEPIAEKG;
		LOKOIPMDFHJ = ACEKCACFHJL;
	}

	[SpecialName]
	public virtual bool IBAGJNDBDBF()
	{
		return true;
	}

	public virtual void LCCEEAMLHDD()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		LACLELOOKHD();
	}

	public virtual void FJILILFMPIF()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		LACLELOOKHD();
	}

	[SpecialName]
	public virtual bool PJJAHFFKBOJ()
	{
		return true;
	}

	[SpecialName]
	public virtual bool GMJGCMNKMOJ()
	{
		return true;
	}

	public KEGHCEANIDJ(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		LJGAGHAJLLO = OGNGMBLDAOP["CurrentTier"]["N"].ToObject<int>();
		LOKOIPMDFHJ = OGNGMBLDAOP["MaxTiers"]["N"].ToObject<int>();
		Debug.Log("Squad Event Ended. Squad completed " + LJGAGHAJLLO + " / " + LOKOIPMDFHJ);
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadEventEnded(HPGHHECHLAN, KJCKFGCLGLG, LJGAGHAJLLO, LOKOIPMDFHJ);
		return null;
	}

	internal override Action ENNLMIGMBKJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.NOEPAODCGIE(HPGHHECHLAN, KJCKFGCLGLG, LJGAGHAJLLO, LOKOIPMDFHJ);
		return null;
	}

	public virtual void JEDGCOMDEKM()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		LACLELOOKHD();
	}

	public override void CJPBMDDGDHG()
	{
		OJFJOJONNJK();
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		CJPBMDDGDHG();
	}
}
