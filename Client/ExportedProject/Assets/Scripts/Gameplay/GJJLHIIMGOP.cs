using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GJJLHIIMGOP : HHFHFANGCEJ
{
	public bool FLCAAKJAIBP;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	private static void IFCMHKAIHMN()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log(", hasError = ");
		}
	}

	private static void FOKGBDDBJFM()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log(" (#");
		}
	}

	internal virtual Action KOMJBCJLPJD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return NFMLHEDOAJO;
	}

	public virtual void DJNMPLKPENF()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	public GJJLHIIMGOP(bool MIIMAINACGE = false)
		: base("StarterPackTimeLimitedOffer", NKHJBLBAAEB.BlackMarketMessage)
	{
		FLCAAKJAIBP = MIIMAINACGE;
		if (FLCAAKJAIBP)
		{
			NHHGDIDEIMM += "RunningOut";
		}
	}

	internal virtual Action CMMFGCOEBBK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return NPDNBDMJJEJ;
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return delegate
		{
			if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
			{
				GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
			}
			else
			{
				Debug.Log("Starter Pack was already bought!");
			}
		};
	}

	internal virtual Action CCJEIKKNKMO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return NPDNBDMJJEJ;
	}

	public virtual void LCCEEAMLHDD()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
	}

	public virtual void EPHMECKBGAA()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action NMCDBKLHFOB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return LNLDKBGABML;
	}

	private static void JHKDMDCJHJJ()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("setting special offer discount add: ");
		}
	}

	private static void DJECJGEAHPM()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("BAND_REWARD_HEALTH");
		}
	}

	private static void ACDEFPOFIII()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("Load map");
		}
	}

	public virtual void IECHFELOIIO()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action IFEEEGDHCIF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return LNLDKBGABML;
	}

	private static void KINJFFMJKKM()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("{0} {1}");
		}
	}

	private static void MDCDELBOBBN()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("dailyRewardData");
		}
	}

	public virtual void CBBLGFEBJID()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	public virtual void BHGDOHCBGEC()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	public override void LEJEDFACEGP()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	private static void NCJJEBGJLEF()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("{0}{1}");
		}
	}

	private static void NLAKDMNBBDH()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("ID_GUI_CHEATINGMESSAGE");
		}
	}

	private static void OGIDMBHGDKM()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("extraWarBucks");
		}
	}

	private static void MMKGMIKHEFC()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log(" BOXES ");
		}
	}

	public virtual void GCLFBCIKNAH()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action OOHFAAHEGJN(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return MMKGMIKHEFC;
	}

	private static void ADNPHLPCIJP()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("ID_STAT_ASSAULTRIFLEKILLS");
		}
	}

	public virtual void KHCMODPGHNI()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	private static void MAJIIFJGNBG()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("QUITTER");
		}
	}

	internal virtual Action OHILMJJDDHL(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return DHNLPKNLNMP;
	}

	private static void NFMLHEDOAJO()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("master3");
		}
	}

	public virtual void BPCMBFNFMOP()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action FAOAJHFNBMP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return delegate
		{
			if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
			{
				GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
			}
			else
			{
				Debug.Log("Starter Pack was already bought!");
			}
		};
	}

	private static void OBHPOPMOCLN()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("Removing facebook from current player!!");
		}
	}

	internal virtual Action MLJIINBDCGA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return DIFOKHIDMIG;
	}

	internal virtual Action KBEKIOGPKKD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return NLAKDMNBBDH;
	}

	private static void MNBPCCNDKDC()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("country-new-zealand");
		}
	}

	internal virtual Action OFCDCJOAAEA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return INLAEAPHPAF;
	}

	public virtual void NBBAANHAAKK()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	internal virtual Action EEEIHMLHDOC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return DHNLPKNLNMP;
	}

	private static void KAHGGAACJIB()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
		else
		{
			Debug.Log("ID_VIPTIME");
		}
	}

	private static void DKCPOMHKGIE()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("v");
		}
	}

	internal virtual Action HKAPIMJJIML(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return HHBFOPPPAOO;
	}

	private static void HACFKMFNLKB()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("Weapon_Upgrade");
		}
	}

	public virtual void JEDGCOMDEKM()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	public virtual void AHHCFAIJCAE()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	private static void OJEAJFJIJMA()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("T");
		}
	}

	private static void PCJHKHELIJA()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
		else
		{
			Debug.Log("ID_CONFIRM_ERROR");
		}
	}

	public virtual void LBHAHNFALLB()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
	}

	public virtual void BFOPAOLPODG()
	{
		base.OLECKGKLHCE();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
	}

	private static void HHBFOPPPAOO()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
		else
		{
			Debug.Log("AssaultHeli could not be spawned");
		}
	}

	private static void PGEBDCOCDAN()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	private static void FILMAOHLFMP()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("Pack: Warbucks ");
		}
	}

	internal virtual Action BKLBFKCBFPP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return OJEAJFJIJMA;
	}

	internal virtual Action IHHPOBJLEGE(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return JHKDMDCJHJJ;
	}

	public virtual void HONPFADFFDP()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	internal virtual Action JCMGPABOPLE(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return MDCDELBOBBN;
	}

	public virtual void ECCAFEHCIFM()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action CEBACDKLHDG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return FOKGBDDBJFM;
	}

	private static void INLAEAPHPAF()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log(" >");
		}
	}

	public virtual void AAHJOEILKNG()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	private static void DHNLPKNLNMP()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("D");
		}
	}

	private static void IIBCLAOHFIM()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("response contain VipReward");
		}
	}

	internal virtual Action FBNPCHJPMMM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return DLANAKFHGBA;
	}

	internal virtual Action CAJNCPGAODK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return MNBPCCNDKDC;
	}

	public virtual void FFMLINMFADM()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	internal virtual Action MFPCHHLMBKK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return DJECJGEAHPM;
	}

	private static void NPDNBDMJJEJ()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("withPublisherSubCampaign");
		}
	}

	internal virtual Action JPAFAKBJNNP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return delegate
		{
			if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
			{
				GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
			}
			else
			{
				Debug.Log("Starter Pack was already bought!");
			}
		};
	}

	private static void ODDGPIBDLOA()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("BattleRewards");
		}
	}

	private static void OBLAGHMNPPA()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("DamageEventPlayerShoot");
		}
	}

	private static void LNLDKBGABML()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("offers");
		}
	}

	internal virtual Action JIJKLLFKBJD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return INLAEAPHPAF;
	}

	private static void DIFOKHIDMIG()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("S");
		}
	}

	public virtual void PFNBDPFAKBN()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
	}

	public virtual void BBOHJOFMLDI()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action BDKMGBLJKLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return MNBPCCNDKDC;
	}

	private static void LLDBPAMDLOM()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("217 MENU BATTLE SCREEN SHOWN");
		}
	}

	public virtual void DMLDBKFCACB()
	{
		base.LOFMDBHAFAO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
	}

	internal virtual Action CDNHFOFKLBM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return ADNPHLPCIJP;
	}

	private static void DCFGPFJOAFI()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("FuseSDK: Parsing error in _FriendAdded");
		}
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.OEAJBFLGJCA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK, CCIEEAECOAB: true);
		}
	}

	private static void DLANAKFHGBA()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else
		{
			Debug.Log("ID_STAT_KILLS");
		}
	}

	public virtual void GLMKGLKCDAL()
	{
		base.JPGMEFJGNNA();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	public virtual void EFBEJJEIPEG()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action CHBKLLBHIGA(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return FOKGBDDBJFM;
	}

	private static void BKNMMFDCLKN()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
		else
		{
			Debug.Log("ID_MISSION_UNITS_HUD");
		}
	}

	public virtual void PAFPBIGHJCI()
	{
		base.OBJEMJHBJFO();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	[CompilerGenerated]
	private static void JKIAEOLFEGC()
	{
		if (!PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter))
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
		else
		{
			Debug.Log("Starter Pack was already bought!");
		}
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	public virtual void MJAAGDHAHEM()
	{
		base.MGKMBCBBOHK();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
	}

	internal virtual Action PFIMIDPFAME(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return MAJIIFJGNBG;
	}

	internal virtual Action NHLNFDAOHPB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return BKNMMFDCLKN;
	}

	public virtual void OFPAGLLFPPK()
	{
		base.LEJEDFACEGP();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ILFCOPPIOME(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
	}

	public virtual void DANAMJKOPBO()
	{
		base.KPANLOMNEIG();
		GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		if (!FLCAAKJAIBP)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.IFMMDKLNLJL(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK, CCIEEAECOAB: true);
		}
	}

	internal virtual Action JFDALDDPHJI(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return NPDNBDMJJEJ;
	}

	internal virtual Action IKJNAPGLGKO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.KOCONPJOPJL(HPGHHECHLAN, KJCKFGCLGLG);
		return HACFKMFNLKB;
	}

	internal virtual Action KBNHKIHOGLD(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_StarterPackTimeLimitedOffer(HPGHHECHLAN, KJCKFGCLGLG);
		return MAJIIFJGNBG;
	}
}
