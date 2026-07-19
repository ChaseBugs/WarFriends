using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LDDEMALIBBK : HHFHFANGCEJ
{
	public int MPHCNMDIPAI;

	public string CGIFEHPDBAL;

	public string GEAGOKJMJFD;

	public int EOHOJBOGNAO;

	public int BCCFGAGJGHM;

	public int MIOOKNECPDL;

	public int PPIHFKGJGHA;

	public List<DatabasePlayer> FHBAEAOCCDE;

	public bool PPNMHPBMIJE;

	public virtual void AJGFDEPLHOJ()
	{
		Debug.Log(string.Format(", password = ", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void EEBNPGOCKFD()
	{
		base.JPGMEFJGNNA();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.AHJFFMAFCEG(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public LDDEMALIBBK(int PEECOJOFACH, int OGJOPNCMJDC, int HGIOPOBDFKE, int FOCMIAIAHDE, int JAKNOMLICHG, List<DatabasePlayer> MEAINBCKLGE)
		: base("testingidsquadwarsend", NKHJBLBAAEB.SquadWarEnd)
	{
		NHHGDIDEIMM += PEECOJOFACH;
		MPHCNMDIPAI = PEECOJOFACH;
		CGIFEHPDBAL = GameLoginManager.currentPlayer.squadName;
		GEAGOKJMJFD = "menu-squad-8";
		EOHOJBOGNAO = OGJOPNCMJDC;
		BCCFGAGJGHM = HGIOPOBDFKE;
		MIOOKNECPDL = FOCMIAIAHDE;
		PPIHFKGJGHA = JAKNOMLICHG;
		FHBAEAOCCDE = MEAINBCKLGE;
		PPNMHPBMIJE = true;
	}

	public virtual void EFBNLJFOOOB()
	{
		Debug.Log(string.Format("IAPOfferAccepted(", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void JNOLMHHLGDE()
	{
		Debug.Log(string.Format("N", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void IFDIKMKGDPG()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.IFMMDKLNLJL(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	internal virtual Action MBMLDFPGLIP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadWarsEnded((NKHJBLBAAEB)93, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return FOHHKEKAOGE;
	}

	internal virtual Action DBEMJDBHDIM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI(NKHJBLBAAEB.SquadDepositedCardsChanged, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return IPABLIHBGOM;
	}

	public virtual void MFJDMHPIOJP()
	{
		Debug.Log(string.Format("S", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void HEGPLCMENHK()
	{
		OIDDCBBFBHJ();
	}

	public virtual void JBMCFEMBPKE()
	{
		base.LOFMDBHAFAO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.EBELHKPCLBI(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual void HICIBNHGEHD()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.OMPAJBHHOLG(this);
	}

	public virtual void ODDNDGAAOCH()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.MEHCHHCOJFM(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	internal virtual Action HOEPDCDGJKK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JPJPBFOAKJN((NKHJBLBAAEB)2, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return LJAGGANKNLE;
	}

	private void NBGDLCMDBKA()
	{
		CGOOGHIJOAH();
	}

	internal virtual Action IDBJONAFGNO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JPJPBFOAKJN(NKHJBLBAAEB.SquadWarEnd, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return KKDECKPLFID;
	}

	public virtual void DLCFAJEFLHO()
	{
		base.KPANLOMNEIG();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.KPDJABMGPDM(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	private void OJEAJFJIJMA()
	{
		CGOOGHIJOAH();
	}

	public override void LEJEDFACEGP()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.KPDJABMGPDM(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	internal virtual Action CCJEIKKNKMO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JNIFNJNGDBB((NKHJBLBAAEB)97, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return IPABLIHBGOM;
	}

	internal virtual Action KCMBKOKAILM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.ADPGKHKOKCB((NKHJBLBAAEB)(-36), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return NBGDLCMDBKA;
	}

	public virtual void PMKGPBMAMAG()
	{
		base.LOFMDBHAFAO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.MEHCHHCOJFM(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void BBDADLAHNJP()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.OMPAJBHHOLG(this);
	}

	internal virtual Action OIKDPGCNOLM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JNIFNJNGDBB(NKHJBLBAAEB.ArenaOpenedMessage, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return GBDGGLJCBOL;
	}

	public virtual void LMMLFNJJDNE()
	{
		if (Singleton<MessageManager>.instance.IIOFKKDDANO() != null)
		{
			Singleton<MessageManager>.instance.lastRewardMessage.PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.KOIEDPJMNCO(this);
	}

	public virtual void MEHDGLOGGJI()
	{
		Debug.Log(string.Format("(Landroid/app/Activity;I)V", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void FJOIGOPFJFF()
	{
		if (Singleton<MessageManager>.instance.HIGKMGAOMJO() != null)
		{
			Singleton<MessageManager>.instance.IIOFKKDDANO().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.OMPAJBHHOLG(this);
	}

	public virtual void BKGDKJHABHC()
	{
		Debug.Log(string.Format("Arena Lost - Scraps received = ", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void JOCFHKJPEPO()
	{
		Debug.Log(string.Format("Sprite  z:{0}\t\"{1}\"    with depth:{2} and atlas:{3}", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action NHLNFDAOHPB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadWarsEnded((NKHJBLBAAEB)(-122), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return delegate
		{
			CJPBMDDGDHG();
		};
	}

	public virtual void KLPCNFBFEAD()
	{
		Debug.Log(string.Format("_MatCap", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void DDOHAFJMGMB()
	{
		if (Singleton<MessageManager>.instance.IIOFKKDDANO() != null)
		{
			Singleton<MessageManager>.instance.DCIJFCCBPFE().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.KOIEDPJMNCO(this);
	}

	public virtual void MLDJKOKIFFM()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.OMPAJBHHOLG(this);
	}

	public virtual void AFFHCKLKMKF()
	{
		if (Singleton<MessageManager>.instance.IIOFKKDDANO() != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.LLMMEBDHCGL(this);
	}

	internal virtual Action BLKKNMBFDBL(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)(-84), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return IBBLDLOIMNL;
	}

	private void KKDECKPLFID()
	{
		CGOOGHIJOAH();
	}

	public virtual void NBBAANHAAKK()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.KJAGDCNDDOG(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public override void IMDBPLNFIKD()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.lastRewardMessage.PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.lastRewardMessage = this;
	}

	internal virtual Action KJHJDIICLCG(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)(-64), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return IBBLDLOIMNL;
	}

	public virtual void DFJBBKKIPAD()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.AHJFFMAFCEG(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void DIBLFOPCCPL()
	{
		base.LOFMDBHAFAO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.BJEAOMIBLFI(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	private void IBBLDLOIMNL()
	{
		CJPBMDDGDHG();
	}

	public virtual void EEOKJCKNEAL()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.IFMMDKLNLJL(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void FNKBNEMEKAC()
	{
		Debug.Log(string.Format("en-US", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action OHILMJJDDHL(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JPJPBFOAKJN(NKHJBLBAAEB.SquadDepositedCardsChanged, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return GBDGGLJCBOL;
	}

	internal virtual Action FBNPCHJPMMM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JNIFNJNGDBB((NKHJBLBAAEB)(-88), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return OACHFPJLLIO;
	}

	public virtual void MOFLAGLEGNB()
	{
		Debug.Log(string.Format("PhotonNetwork.room == null!", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void GOLEEBGFHNO()
	{
		Debug.Log(string.Format("0", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void CFNILANPGBC()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.KPDJABMGPDM(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void KAPGOBHBAPH()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.lastRewardMessage.PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.lastRewardMessage = this;
	}

	public virtual void BIIHCAEKCOD()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.EBELHKPCLBI(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	internal virtual Action CBBAMHELDLB(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JPJPBFOAKJN(NKHJBLBAAEB.UnitReadyForPromotion, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return HEGPLCMENHK;
	}

	public virtual void GLMKGLKCDAL()
	{
		base.JPGMEFJGNNA();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.IFMMDKLNLJL(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	[CompilerGenerated]
	private void JKIAEOLFEGC()
	{
		CJPBMDDGDHG();
	}

	public virtual void HLAFPPJNOOH()
	{
		if (Singleton<MessageManager>.instance.lastRewardMessage != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.OMPAJBHHOLG(this);
	}

	public virtual void DDFKBCFNLEF()
	{
		Debug.Log(string.Format("GameLoginManager - Player Entered Beginners League - ", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void ABHOIBKKBNM()
	{
		Debug.Log(string.Format("D2", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void KELCIJOFGCG()
	{
		if (Singleton<MessageManager>.instance.DCIJFCCBPFE() != null)
		{
			Singleton<MessageManager>.instance.DCIJFCCBPFE().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.KOIEDPJMNCO(this);
	}

	internal virtual Action FAOAJHFNBMP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)(-8), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return OACHFPJLLIO;
	}

	internal virtual Action MAGGBLIILMK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JNIFNJNGDBB((NKHJBLBAAEB)(-87), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return OACHFPJLLIO;
	}

	private void LJAGGANKNLE()
	{
		AKICNBAOGOL();
	}

	internal virtual Action NIDFACCPPFK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadWarsEnded(NKHJBLBAAEB.ArenaLostMessage, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return HACFKMFNLKB;
	}

	public virtual void ONEOGHLGFDH()
	{
		Debug.Log(string.Format("experiment type is ", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void CDDOHOJJGKF()
	{
		AKICNBAOGOL();
	}

	public virtual void LMOKCBCILHH()
	{
		if (Singleton<MessageManager>.instance.HIGKMGAOMJO() != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.KOIEDPJMNCO(this);
	}

	public virtual void GFKHOLGMMKE()
	{
		if (Singleton<MessageManager>.instance.DCIJFCCBPFE() != null)
		{
			Singleton<MessageManager>.instance.IIOFKKDDANO().PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.LLMMEBDHCGL(this);
	}

	public LDDEMALIBBK(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		if (OGNGMBLDAOP["Position"] != null)
		{
			MPHCNMDIPAI = OGNGMBLDAOP["Position"]["N"].ToObject<int>();
		}
		if (OGNGMBLDAOP["SquadId"] != null)
		{
			CGIFEHPDBAL = OGNGMBLDAOP["SquadId"]["S"].ToObject<string>();
		}
		if (OGNGMBLDAOP["SquadIcon"] != null)
		{
			GEAGOKJMJFD = OGNGMBLDAOP["SquadIcon"]["S"].ToObject<string>();
		}
		if (OGNGMBLDAOP["RewardGold"] != null)
		{
			float num = OGNGMBLDAOP["RewardGold"]["N"].ToObject<float>();
			if (num != Mathf.Round(num))
			{
				Debug.LogError("Squad Wars reward gold is FLOAT not INT!!! : " + num);
				EOHOJBOGNAO = Mathf.FloorToInt(num);
			}
			else
			{
				EOHOJBOGNAO = OGNGMBLDAOP["RewardGold"]["N"].ToObject<int>();
			}
		}
		if (OGNGMBLDAOP["PrevLevelId"] != null)
		{
			BCCFGAGJGHM = OGNGMBLDAOP["PrevLevelId"]["N"].ToObject<int>();
		}
		if (OGNGMBLDAOP["NewLevelId"] != null)
		{
			MIOOKNECPDL = OGNGMBLDAOP["NewLevelId"]["N"].ToObject<int>();
		}
		FHBAEAOCCDE = new List<DatabasePlayer>();
		if (OGNGMBLDAOP["SquadMembers"] != null)
		{
			JArray jArray = JsonConvert.DeserializeObject<JArray>(OGNGMBLDAOP["SquadMembers"]["S"].ToObject<string>());
			foreach (JToken item2 in jArray)
			{
				DatabasePlayer item = DatabasePlayer.CreateFromDatabase(item2);
				FHBAEAOCCDE.Add(item);
			}
		}
		PPIHFKGJGHA = 50;
		PPNMHPBMIJE = true;
	}

	internal virtual Action CDNHFOFKLBM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JPJPBFOAKJN((NKHJBLBAAEB)(-34), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return NBGDLCMDBKA;
	}

	internal virtual Action MDCHALEHFEH(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JNIFNJNGDBB((NKHJBLBAAEB)123, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return FOHHKEKAOGE;
	}

	public virtual void ILALOEJJMJC()
	{
		Debug.Log(string.Format(",", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void HCDPPODICBA()
	{
		Debug.Log(string.Format("0", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void BHGDOHCBGEC()
	{
		base.OBJEMJHBJFO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.MEHCHHCOJFM(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual void GKPBJKLOJDO()
	{
		if (Singleton<MessageManager>.instance.DCIJFCCBPFE() != null)
		{
			Singleton<MessageManager>.instance.DCIJFCCBPFE().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.LLMMEBDHCGL(this);
	}

	private void IPABLIHBGOM()
	{
		LACLELOOKHD();
	}

	public virtual void HLEFHIIGFAO()
	{
		if (Singleton<MessageManager>.instance.HIGKMGAOMJO() != null)
		{
			Singleton<MessageManager>.instance.lastRewardMessage.PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.KOIEDPJMNCO(this);
	}

	public virtual void BJGDGMDOKLH()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.ShowDialog(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	internal virtual Action AABIIFOPEFJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.ADPGKHKOKCB((NKHJBLBAAEB)120, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return GBDGGLJCBOL;
	}

	public virtual void KHLDOFCPOED()
	{
		base.OBJEMJHBJFO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.GILDIKINMFE(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	private void FOHHKEKAOGE()
	{
		LACLELOOKHD();
	}

	public virtual void IKDCEHMPNOH()
	{
		base.LEJEDFACEGP();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.PGNOMEFCKMO(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadWarsEnded(NKHJBLBAAEB.SquadWarEnd, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return delegate
		{
			CJPBMDDGDHG();
		};
	}

	internal virtual Action CAKIIIINBLO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JNIFNJNGDBB((NKHJBLBAAEB)69, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return GBDGGLJCBOL;
	}

	public virtual void APJJPDGEJNK()
	{
		Debug.Log(string.Format("ID_WINSTREAK", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action OEHOHHODGLE(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.ADPGKHKOKCB((NKHJBLBAAEB)58, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return delegate
		{
			CJPBMDDGDHG();
		};
	}

	public virtual void CKOAOEMJAKI()
	{
		if (Singleton<MessageManager>.instance.HIGKMGAOMJO() != null)
		{
			Singleton<MessageManager>.instance.IIOFKKDDANO().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.lastRewardMessage = this;
	}

	public virtual void MNOANMDLAMC()
	{
		Debug.Log(string.Format("Sniper_Tutorial_Duration", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void EFBEJJEIPEG()
	{
		base.OLECKGKLHCE();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.NGBCDPEPOOB(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	internal virtual Action JOKJMBHIDGM(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.ADPGKHKOKCB(NKHJBLBAAEB.NonExistingSquadWarsEnd, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return CDDOHOJJGKF;
	}

	public virtual void BKKCFCNOKDI()
	{
		if (Singleton<MessageManager>.instance.IIOFKKDDANO() != null)
		{
			Singleton<MessageManager>.instance.HIGKMGAOMJO().PPNMHPBMIJE = true;
		}
		Singleton<MessageManager>.instance.OMPAJBHHOLG(this);
	}

	public virtual void BBJADAJPJHH()
	{
		base.OEAJBFLGJCA();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.ShowDialog(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	private void GBDGGLJCBOL()
	{
		CJPBMDDGDHG();
	}

	internal virtual Action CPMODKNOJLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.ADPGKHKOKCB((NKHJBLBAAEB)(-102), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return IBBLDLOIMNL;
	}

	public virtual void DCJICMIMPJE()
	{
		base.MGKMBCBBOHK();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.IFMMDKLNLJL(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public override void CJPBMDDGDHG()
	{
		Debug.Log(string.Format("SquadWarsFinishedMessage: Claiming gold: {0}", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void FHMAHODAJAH()
	{
		base.OBJEMJHBJFO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.IFMMDKLNLJL(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	internal virtual Action GEJJDEHLBMJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)(-18), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return KKDECKPLFID;
	}

	public override void OIDDCBBFBHJ()
	{
		Debug.Log(string.Format("shield_shot", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	internal virtual Action IDEJHCCOFIK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadWarsEnded((NKHJBLBAAEB)(-109), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return JHKDMDCJHJJ;
	}

	private void MDCDELBOBBN()
	{
		OIDDCBBFBHJ();
	}

	public virtual void OLCGLJIFIFN()
	{
		Debug.Log(string.Format("ID_SALEPERCENTLINE", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.ShowDialog(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual void CFMIHDNNNFL()
	{
		Debug.Log(string.Format("Password", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	private void HNOOBDCMFHE()
	{
		OIDDCBBFBHJ();
	}

	internal virtual Action MBHBEDIGDHJ(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.JPJPBFOAKJN((NKHJBLBAAEB)96, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return HEGPLCMENHK;
	}

	public virtual void MBFAKFHMHLH()
	{
		Debug.Log(string.Format("No", EOHOJBOGNAO));
		Singleton<BeanstalkServerManager>.instance.FGIPNMHPLME(this);
	}

	public virtual void EIOOBNMOOCJ()
	{
		if (Singleton<MessageManager>.instance.IIOFKKDDANO() != null)
		{
			Singleton<MessageManager>.instance.DCIJFCCBPFE().PPNMHPBMIJE = false;
		}
		Singleton<MessageManager>.instance.LLMMEBDHCGL(this);
	}

	public virtual void KGEEDMONDMK()
	{
		base.OBJEMJHBJFO();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.CBPJNPHOAFN(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	internal virtual Action FIKDPEAPLJK(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)(-85), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return OACHFPJLLIO;
	}

	internal virtual Action DJOHJFOHPAF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)99, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return HEGPLCMENHK;
	}

	internal virtual Action GCDJEALIMEC(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.LCHDEIJOMMI((NKHJBLBAAEB)(-32), KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return GBDGGLJCBOL;
	}

	internal virtual Action BAOJLOEKBIH(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_SquadWarsEnded((NKHJBLBAAEB)110, KJCKFGCLGLG, MPHCNMDIPAI, EOHOJBOGNAO, CGIFEHPDBAL);
		return LJAGGANKNLE;
	}

	private void JHKDMDCJHJJ()
	{
		CJPBMDDGDHG();
	}

	private void HACFKMFNLKB()
	{
		OIDDCBBFBHJ();
	}

	public virtual void FJILILFMPIF()
	{
		base.OEAJBFLGJCA();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.FACFLKKLGEB(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = false;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	private void OACHFPJLLIO()
	{
		CJPBMDDGDHG();
	}

	public virtual void EOEDEJKJKMN()
	{
		base.KPANLOMNEIG();
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(CGIFEHPDBAL, false);
		if (PPNMHPBMIJE)
		{
			GuiElementSingle<SquadWarEndDialog>.instance.KJAGDCNDDOG(CGIFEHPDBAL, GEAGOKJMJFD, MPHCNMDIPAI, PPIHFKGJGHA, EOHOJBOGNAO, BCCFGAGJGHM, MIOOKNECPDL, FHBAEAOCCDE, this);
			Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = true;
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}
}
