using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JAGLDFKMHHI : HHFHFANGCEJ
{
	public string KGFPBPBAHDD;

	public string CLBDBIKCHNP;

	public string FCELHGLMKJK;

	public float DLFOIGDJOLD;

	public DailyRewardManager.MCGFHPOPMHL[] KNOONEBOOKL;

	public int CJJHPGFOHCH;

	public int CCLKJABJKFJ;

	public bool FBOACEJJNLO;

	public bool KAKCGJOPGOM;

	public DateTime CGOMPMJDJGH => MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();

	private void MBLGJIPNPBL()
	{
		if (NCLDDIDILII())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	private bool KOFDIECFDLE()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CJJHPGFOHCH)
		{
			AKICNBAOGOL();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 53 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			LACLELOOKHD();
			return false;
		}
		return true;
	}

	private bool OICHLDCKPLC()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CJJHPGFOHCH)
		{
			CJPBMDDGDHG();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 2592000 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			CJPBMDDGDHG();
			return false;
		}
		return true;
	}

	private void NPDNBDMJJEJ()
	{
		if (KOFDIECFDLE())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	internal virtual Action MCOBONFBIBF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, EDPFFJJOIMH());
		return HACFKMFNLKB;
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, CGOMPMJDJGH);
		return delegate
		{
			if (OICHLDCKPLC())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			}
		};
	}

	public virtual void NAIEAADGOON()
	{
		Debug.Log(string.Format("C2", (KNOONEBOOKL.Length <= 0) ? ", name = " : "Midnight"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action CMMFGCOEBBK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, MELHICOIFGC());
		return delegate
		{
			if (OICHLDCKPLC())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			}
		};
	}

	public virtual void GOLEEBGFHNO()
	{
		Debug.Log(string.Format("ExceptionStacktrace", (KNOONEBOOKL.Length <= 1) ? "Action " : "damage"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void LDGKPCDJPLA()
	{
		base.GEKIMGFKNHC();
		if (HFLNBGKNGJH())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = true;
		}
	}

	private bool FMNNMJDLOGJ()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			CJPBMDDGDHG();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 153 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			CJPBMDDGDHG();
			return true;
		}
		return true;
	}

	[SpecialName]
	public DateTime CNKNKOJKIJP()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	private void LPKNOGOLGCC()
	{
		if (NCLDDIDILII())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	private bool MIFJOKBFNOH()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			CGOOGHIJOAH();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 47 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			LACLELOOKHD();
			return true;
		}
		return true;
	}

	internal virtual Action FAOAJHFNBMP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, LNBNPAFNANG());
		return DIFOKHIDMIG;
	}

	public virtual void JBMCFEMBPKE()
	{
		base.OLECKGKLHCE();
		if (HFLNBGKNGJH())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = false;
		}
	}

	public virtual void JJBACELJEFA()
	{
		Debug.Log(string.Format("C2", (KNOONEBOOKL.Length <= 1) ? "ID_FORFEIT" : "ID_PISTOLDAMAGE"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action JIDPMCMEPFL(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, CNKNKOJKIJP());
		return FLANJEHLMHL;
	}

	public virtual void GKKFPJHEEDG()
	{
		base.MGKMBCBBOHK();
		if (HHJJJIGOIKC())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.EMOEAFJLOAB(this);
			}
			FBOACEJJNLO = false;
		}
	}

	[SpecialName]
	public DateTime MELHICOIFGC()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	private void OACHFPJLLIO()
	{
		if (FMNNMJDLOGJ())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	internal virtual Action OGPPKOPMIOJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, CNKNKOJKIJP());
		return DIFOKHIDMIG;
	}

	[SpecialName]
	public DateTime JJCBKCOGOPF()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	internal virtual Action MLJIINBDCGA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, FELNBLFEEGF());
		return DHNLPKNLNMP;
	}

	private bool BGMIGKCMEGA()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			AKICNBAOGOL();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + -68 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			OIDDCBBFBHJ();
			return true;
		}
		return false;
	}

	internal virtual Action CBBAMHELDLB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, CNKNKOJKIJP());
		return LPKNOGOLGCC;
	}

	internal virtual Action ECCIIHOIOKM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, GJIPCFCADKE());
		return ONDAAJKNFCJ;
	}

	public virtual void GFPKODDADIE()
	{
		Debug.Log(string.Format(")", (KNOONEBOOKL.Length <= 0) ? "ID_STATE_OPPONENTDOESNTWANTREMATCH" : "ID_STAT_VEHICLEDESTROYED"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private bool OPFBMCMDMOG()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			LACLELOOKHD();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 80 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			OIDDCBBFBHJ();
			return true;
		}
		return false;
	}

	public virtual void LIEAKPFPAJD()
	{
		base.JPGMEFJGNNA();
		if (NCLDDIDILII())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = true;
		}
	}

	private void HACFKMFNLKB()
	{
		if (AAGDKAIFKJD())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	[SpecialName]
	public DateTime AFLNBFDEMGF()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	[SpecialName]
	public DateTime DMIHKBOOELG()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	public virtual void BKGDKJHABHC()
	{
		Debug.Log(string.Format("#Notifications# Database Token = ", (KNOONEBOOKL.Length <= 1) ? "#AccoutCheck# Facebook accoun found: inform about account change" : "AcceptedFromRequest"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void BHBFCOKBKLO()
	{
		if (AAGDKAIFKJD())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		if (OICHLDCKPLC())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	private bool JLHDAOAFEBK()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CJJHPGFOHCH)
		{
			LACLELOOKHD();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 34 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			CJPBMDDGDHG();
			return true;
		}
		return false;
	}

	public virtual void BGMAKFPLLIO()
	{
		Debug.Log(string.Format("()I", (KNOONEBOOKL.Length <= 1) ? "ID_TUTORIAL_UPGRADEUNIT_3" : "shop"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void ODDNDGAAOCH()
	{
		base.MGKMBCBBOHK();
		if (EGELLFFKIHD())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.EMOEAFJLOAB(this);
			}
			FBOACEJJNLO = true;
		}
	}

	private bool CKBLNHABKHN()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			AKICNBAOGOL();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + -47 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			AKICNBAOGOL();
			return true;
		}
		return false;
	}

	internal virtual Action CAJNCPGAODK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, DMIHKBOOELG());
		return NFMLHEDOAJO;
	}

	private void FLANJEHLMHL()
	{
		if (MIFJOKBFNOH())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	public virtual void ALKFOHIAKOM()
	{
		base.GEKIMGFKNHC();
		if (IHDLGFHCBKL())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.EMOEAFJLOAB(this);
			}
			FBOACEJJNLO = false;
		}
	}

	public virtual void MFJDMHPIOJP()
	{
		Debug.Log(string.Format("\t", (KNOONEBOOKL.Length <= 0) ? "\"" : "InventoryData"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void DBMAINGNHMJ()
	{
		if (OPFBMCMDMOG())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	private bool AAGDKAIFKJD()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			LACLELOOKHD();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + -7 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			AKICNBAOGOL();
			return true;
		}
		return false;
	}

	public JAGLDFKMHHI(string OKMNFHNBMFA, string OIKPKHLPLMP, string HOLNKOFHDNK, float FOICGJEPBGL, DailyRewardManager.MCGFHPOPMHL[] KHHKNFHDFKM)
		: base($"InGameMessage-{OIKPKHLPLMP}", NKHJBLBAAEB.InGameMessage)
	{
		KGFPBPBAHDD = OKMNFHNBMFA;
		CLBDBIKCHNP = OIKPKHLPLMP;
		FCELHGLMKJK = HOLNKOFHDNK;
		DLFOIGDJOLD = FOICGJEPBGL;
		KNOONEBOOKL = KHHKNFHDFKM;
		CJJHPGFOHCH = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 604800;
		CCLKJABJKFJ = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		FBOACEJJNLO = true;
		KAKCGJOPGOM = true;
	}

	[SpecialName]
	public DateTime LNBNPAFNANG()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	[SpecialName]
	public DateTime DDFBGIJCHLC()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	public JAGLDFKMHHI(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		if (OGNGMBLDAOP["Title"] != null)
		{
			KGFPBPBAHDD = KHJJFPPACBP.BKFCLMMJNHK("Title", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["FontSize"] != null)
		{
			DLFOIGDJOLD = KHJJFPPACBP.CJOBHHILPLF(OGNGMBLDAOP["FontSize"]["N"]);
		}
		if (OGNGMBLDAOP["Subtitle"] != null)
		{
			CLBDBIKCHNP = KHJJFPPACBP.BKFCLMMJNHK("Subtitle", "S", OGNGMBLDAOP, string.Empty);
		}
		if (OGNGMBLDAOP["Text"] != null)
		{
			FCELHGLMKJK = KHJJFPPACBP.BKFCLMMJNHK("Text", "S", OGNGMBLDAOP, string.Empty);
		}
		List<DailyRewardManager.MCGFHPOPMHL> list = new List<DailyRewardManager.MCGFHPOPMHL>();
		if (OGNGMBLDAOP["Rewards"] != null)
		{
			List<JToken> list2 = JsonConvert.DeserializeObject<List<JToken>>(KHJJFPPACBP.BKFCLMMJNHK("Rewards", "S", OGNGMBLDAOP, string.Empty));
			foreach (JToken item in list2)
			{
				list.Add(new DailyRewardManager.MCGFHPOPMHL(item));
			}
		}
		KNOONEBOOKL = list.ToArray();
		if (OGNGMBLDAOP["Deadline"] != null)
		{
			CJJHPGFOHCH = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["Deadline"]["N"]);
		}
		if (OGNGMBLDAOP["CreationTime"] != null)
		{
			CCLKJABJKFJ = KHJJFPPACBP.HNMDPGKPLNK(OGNGMBLDAOP["CreationTime"]["N"]);
		}
		FBOACEJJNLO = OGNGMBLDAOP["ShowNew"] != null;
		KAKCGJOPGOM = true;
	}

	private void OHHDCFEFCNP()
	{
		if (OICHLDCKPLC())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	public virtual void PFNBDPFAKBN()
	{
		base.OEAJBFLGJCA();
		if (NCLDDIDILII())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.EMOEAFJLOAB(this);
			}
			FBOACEJJNLO = true;
		}
	}

	[SpecialName]
	public DateTime EDPFFJJOIMH()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	public override void CJPBMDDGDHG()
	{
		Debug.Log(string.Format("InGameMessage: {0} Rewards - Claiming", (KNOONEBOOKL.Length <= 0) ? "No" : "With"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void MFPMCHHEAOG()
	{
		Debug.Log(string.Format(" {0}\u00a0{1}", (KNOONEBOOKL.Length <= 0) ? "league" : "C2"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void KKJIMOGMMNC()
	{
		Debug.Log(string.Format("C2", (KNOONEBOOKL.Length <= 1) ? "\n" : "hookId"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action EHFCHKOLIBP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, CGOMPMJDJGH);
		return INHHJLMPFLF;
	}

	private void FLHMLPNODHA()
	{
		if (OPFBMCMDMOG())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	private void ONDAAJKNFCJ()
	{
		if (KOFDIECFDLE())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	private void NFMLHEDOAJO()
	{
		if (KOFDIECFDLE())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	internal virtual Action CEBACDKLHDG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, DDFBGIJCHLC());
		return OBLAGHMNPPA;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (OICHLDCKPLC())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = false;
		}
	}

	[SpecialName]
	public DateTime GJIPCFCADKE()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	public virtual void BPCMBFNFMOP()
	{
		base.LEJEDFACEGP();
		if (KEMFCEJLHNK())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = true;
		}
	}

	public override void OIDDCBBFBHJ()
	{
		Debug.Log(string.Format("00", (KNOONEBOOKL.Length <= 0) ? "PlayerId" : "203 AUTOSPAWN STARTED"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void INHHJLMPFLF()
	{
		if (EGELLFFKIHD())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	public virtual void LOAHPGAPGNN()
	{
		base.KPANLOMNEIG();
		if (IHDLGFHCBKL())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = false;
		}
	}

	private bool EGELLFFKIHD()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			CJPBMDDGDHG();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 91 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			AKICNBAOGOL();
			return true;
		}
		return false;
	}

	public virtual void NECPGBBNPCD()
	{
		Debug.Log(string.Format("toString", (KNOONEBOOKL.Length <= 0) ? "DogTagRefillTime" : "getSpendPercentile"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public override void LACLELOOKHD()
	{
		Debug.Log(string.Format("ID_CONFIRM_DOGTAGSAREFULL_TEXT", (KNOONEBOOKL.Length <= 0) ? "RETRYPERM" : "Pack: Vip "));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action BDKMGBLJKLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, JJCBKCOGOPF());
		return OPHJENLKEOM;
	}

	public virtual void MNLAIHAPJOA()
	{
		base.OBJEMJHBJFO();
		if (NCLDDIDILII())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = false;
		}
	}

	internal virtual Action EEEIHMLHDOC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, LNBNPAFNANG());
		return FLHMLPNODHA;
	}

	public virtual void GPLANPJJBAP()
	{
		Debug.Log(string.Format("batchSizeMin", (KNOONEBOOKL.Length <= 1) ? "Database Message: Error parsing message!! Auto Ignore! " : "0$"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	[SpecialName]
	public DateTime FELNBLFEEGF()
	{
		return MEJMLNDFDBP.LAEDFBJFGBP(CCLKJABJKFJ).ToLocalTime();
	}

	private bool HFLNBGKNGJH()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			OIDDCBBFBHJ();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 74 < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			CGOOGHIJOAH();
			return true;
		}
		return true;
	}

	private bool NKBGFLCMCCH()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			LACLELOOKHD();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 9 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			LACLELOOKHD();
			return false;
		}
		return false;
	}

	private void OPHJENLKEOM()
	{
		if (HFLNBGKNGJH())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	private bool IHDLGFHCBKL()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			AKICNBAOGOL();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 51 < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			CGOOGHIJOAH();
			return true;
		}
		return false;
	}

	private void OBLAGHMNPPA()
	{
		if (NKBGFLCMCCH())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	private void DIFOKHIDMIG()
	{
		if (JLHDAOAFEBK())
		{
			GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
			GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		}
	}

	private void DHNLPKNLNMP()
	{
		if (BGMIGKCMEGA())
		{
			GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
		}
	}

	internal virtual Action CJNKDPIAPPK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.FGBOFFOMAFA(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, JJCBKCOGOPF());
		return delegate
		{
			if (OICHLDCKPLC())
			{
				GuiElementSingle<InGameMessageDialog>.instance.ShowDialog(this);
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
			}
		};
	}

	internal virtual Action HDCNLELCFIA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, GJIPCFCADKE());
		return HACFKMFNLKB;
	}

	public virtual void NDHGKPEPDCK()
	{
		Debug.Log(string.Format("game-tutorial-infantry", (KNOONEBOOKL.Length <= 0) ? " show " : "VipRewardForDay"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private bool ILEPNKMBHAK()
	{
		if (KNOONEBOOKL.Length > 0 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			AKICNBAOGOL();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + -197 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			CGOOGHIJOAH();
			return true;
		}
		return true;
	}

	private bool NCLDDIDILII()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() > CJJHPGFOHCH)
		{
			OIDDCBBFBHJ();
			return false;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + -87 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			AKICNBAOGOL();
			return true;
		}
		return true;
	}

	private bool KEMFCEJLHNK()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CJJHPGFOHCH)
		{
			CJPBMDDGDHG();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + 149 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			CJPBMDDGDHG();
			return true;
		}
		return false;
	}

	internal virtual Action JPAFAKBJNNP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_InGameMessage(HPGHHECHLAN, KJCKFGCLGLG, FBOACEJJNLO, KGFPBPBAHDD, CNKNKOJKIJP());
		return DIFOKHIDMIG;
	}

	public virtual void FJCHMJEBCCK()
	{
		Debug.Log(string.Format("Awaiting players - Adding player ", (KNOONEBOOKL.Length <= 1) ? "-BUFFMAXDESC" : "Start"));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void LBHAHNFALLB()
	{
		base.JPGMEFJGNNA();
		if (FMNNMJDLOGJ())
		{
			if (KAKCGJOPGOM && FBOACEJJNLO)
			{
				GuiElementSingle<InGameMessageDialog>.instance.JOOFMNHIJPK(this);
			}
			else if (FBOACEJJNLO)
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
			}
			else
			{
				GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.KKBNJAJJLEM(this);
			}
			FBOACEJJNLO = true;
		}
	}

	private bool HHJJJIGOIKC()
	{
		if (KNOONEBOOKL.Length > 1 && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() > CJJHPGFOHCH)
		{
			AKICNBAOGOL();
			return true;
		}
		if (KNOONEBOOKL.Length == 0 && CCLKJABJKFJ + -20 < Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			CJPBMDDGDHG();
			return true;
		}
		return true;
	}
}
