using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class IMKNKBHECOD : HHFHFANGCEJ
{
	public bool LOJEAOPLOPO;

	public bool IKBOGJPAKOB;

	public bool FKFHIBLPGON;

	public League AFCECJDFHGD;

	public int JPADOCPGGJL;

	public bool GHFOEKMLDPI;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	public override bool OMMPKNEEJIB => true;

	internal virtual Action BHHBELPPEGI(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.HGDLPLJHPDK(HPGHHECHLAN, KJCKFGCLGLG, AFCECJDFHGD);
		return BMGMICNKCLG;
	}

	internal virtual Action BKLBFKCBFPP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.HGDLPLJHPDK(HPGHHECHLAN, KJCKFGCLGLG, AFCECJDFHGD);
		return BMGMICNKCLG;
	}

	[SpecialName]
	public virtual bool BCIABCJLJEM()
	{
		return true;
	}

	public virtual void FPOIGOFDIPF()
	{
		base.MGKMBCBBOHK();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.MFPDIGEDLJG(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.PLFFCCMOCEC(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.MPMIGJOEPFG(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			JFDENNGOGJC();
		}
	}

	internal virtual Action FAKMLJMJCKF(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_LeagueEntered(HPGHHECHLAN, KJCKFGCLGLG, AFCECJDFHGD);
		return delegate
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		};
	}

	public virtual void IECHFELOIIO()
	{
		base.KPANLOMNEIG();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.ShowFinishedBeginnersLeague(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.NAPDNCPIKNB(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.AILFNJPKNCN(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			BCIOBLLBLLC();
		}
	}

	public override void LOFMDBHAFAO()
	{
		base.JPGMEFJGNNA();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.HNCOMPDEEFL(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.KKKOBJMJLCA(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.FEPMIHIAGNE(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			IFFBCOLBDOP();
		}
	}

	private static void EDDBKHKJICI()
	{
		GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
	}

	internal virtual Action BFDIJGGPNCO(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.HGDLPLJHPDK(HPGHHECHLAN, KJCKFGCLGLG, AFCECJDFHGD);
		return CCPPBMANOGC;
	}

	[SpecialName]
	public virtual bool NGFALAMOGLA()
	{
		return true;
	}

	public virtual void DMLDBKFCACB()
	{
		base.OEAJBFLGJCA();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.CMMABNMFOFM(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.JKCLDFNOKLO(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.KEBOKGAFBDB(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			CALACCCGMGD();
		}
	}

	private static void CKAEFBDMIID()
	{
		GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
	}

	private static void CCPPBMANOGC()
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
	}

	public virtual void LIEAKPFPAJD()
	{
		base.LOFMDBHAFAO();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.EMDNHHKDAED(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.NAPDNCPIKNB(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.GPOEJMHKIJK(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			CALACCCGMGD();
		}
	}

	public IMKNKBHECOD(League BMNDININJCE, bool INKLAPHGBHI)
		: base("LeagueEntered", NKHJBLBAAEB.LeagueEntered)
	{
		LOJEAOPLOPO = true;
		FKFHIBLPGON = true;
		if (INKLAPHGBHI)
		{
			NHHGDIDEIMM += $"{BMNDININJCE}-firstTime-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		}
		else
		{
			NHHGDIDEIMM += $"{BMNDININJCE}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		}
		AFCECJDFHGD = BMNDININJCE;
		GHFOEKMLDPI = INKLAPHGBHI;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.ShowFinishedBeginnersLeague(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.ShowEnterToNormalLeague(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.ShowEnterToBeginnersLeague(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			OJFJOJONNJK();
		}
	}

	public IMKNKBHECOD(League BMNDININJCE)
		: base("FinishedBeginnersLeague", NKHJBLBAAEB.LeagueEntered)
	{
		LOJEAOPLOPO = true;
		IKBOGJPAKOB = true;
		NHHGDIDEIMM = NHHGDIDEIMM + "-" + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		AFCECJDFHGD = BMNDININJCE;
	}

	public IMKNKBHECOD(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		LOJEAOPLOPO = false;
		FKFHIBLPGON = true;
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string text = OGNGMBLDAOP["LeagueId"]["S"].ToObject<string>();
		int num = Convert.ToInt32(Regex.Replace(text, "-[0-9]*$", string.Empty));
		int num2 = Convert.ToInt32(Regex.Replace(text, "^[0-9]*-", string.Empty));
		Debug.LogFormat("Player Entered League:{0}  tier:{1}  division:{2}", text, num, num2);
		if (currentPlayer.leagueId != text)
		{
			Debug.LogFormat("Different actual league Id \"{0}\" and database message - league entered - league id \"{1}\"", currentPlayer.leagueId, text);
			GameLoginManager.instance.UpdatePlayerLeagueAndMedals(currentPlayer.beginnersLeague, text, currentPlayer.skill, currentPlayer.medalsBalance, currentPlayer.remainingMatches);
		}
		AFCECJDFHGD = (League)num;
	}

	[SpecialName]
	public virtual bool LLDKOPGBIBF()
	{
		return false;
	}

	[CompilerGenerated]
	private static void JKIAEOLFEGC()
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
	}

	public IMKNKBHECOD(int HNEFOLPHMHK)
		: base("BeginnersLeagueEntered", NKHJBLBAAEB.LeagueEntered)
	{
		LOJEAOPLOPO = true;
		NHHGDIDEIMM += $"{HNEFOLPHMHK}-{Singleton<BeanstalkServerManager>.instance.currentTimestamp}";
		JPADOCPGGJL = HNEFOLPHMHK;
	}

	private static void IGHFHOFLAJL()
	{
		GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
	}

	private static void LJAGGANKNLE()
	{
		GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
	}

	private static void BMGMICNKCLG()
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
	}

	public virtual void OFPAGLLFPPK()
	{
		base.GEKIMGFKNHC();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.EHHPMHILOBL(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.NNDJNNGIIAA(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.ABMIJIINFBH(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			BCIOBLLBLLC();
		}
	}

	public virtual void GLMKGLKCDAL()
	{
		base.OLECKGKLHCE();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.HHENJNDKAMG(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.KBONHDFEOED(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.ShowEnterToBeginnersLeague(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			CALACCCGMGD();
		}
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		HDEGOGFCNAC.SetAppearance_LeagueEntered(HPGHHECHLAN, KJCKFGCLGLG, AFCECJDFHGD);
		return delegate
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		};
	}

	[SpecialName]
	public virtual bool AAHIEECMFLD()
	{
		return true;
	}

	public virtual void GBEBFIDEOHH()
	{
		base.OBJEMJHBJFO();
		if (IKBOGJPAKOB)
		{
			GuiElementSingle<LeagueDialog>.instance.CMMABNMFOFM(AFCECJDFHGD);
		}
		else if (FKFHIBLPGON)
		{
			GuiElementSingle<LeagueDialog>.instance.HKGMGDCMOLI(AFCECJDFHGD, GHFOEKMLDPI);
		}
		else
		{
			GuiElementSingle<LeagueDialog>.instance.BPEKJGNEEOA(JPADOCPGGJL);
		}
		if (!LOJEAOPLOPO)
		{
			BCIOBLLBLLC();
		}
	}
}
