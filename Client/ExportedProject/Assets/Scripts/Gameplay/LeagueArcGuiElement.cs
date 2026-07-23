using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class LeagueArcGuiElement : Core_BaseScript
{
	public enum NKHJBLBAAEB
	{
		MainScreen,
		MenuHeader,
		EndScreen,
		NoUpdate
	}

	private sealed class HAJEIGIFBOO
	{
		internal MAPGBEOOFLL KDIKHFJAJBA;

		internal MAPGBEOOFLL ILHGHKFHMFD;

		internal LeagueArcGuiElement BJGCPDNMHDH;

		internal void DHHKKBLMIHB(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 85;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.Begin(BJGCPDNMHDH, 1103f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			Debug.Log(".e" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void PKCGGMPIPDL(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -77;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.EEODMCJPDNI(BJGCPDNMHDH, 336f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			Debug.Log("{0:D2}:{1:D2}" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void MBMPBDEFNGE(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 86;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.DFNHCFNJCMC(BJGCPDNMHDH, 1925f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void AFJHEFPPKHG(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -15;
				mAPGBEOOFLL.GEIONCLKAGF = 0;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.EONNCEKICLD(BJGCPDNMHDH, 1889f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("DPS" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void CENOGMHAJNK(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -78;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.JCLGAFGBMDC(BJGCPDNMHDH, 1183f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void BLEMBJFNOGA(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void CHPGPDHOOFL(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -115;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.EGACIBHAMAF(BJGCPDNMHDH, 1630f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void CBIEBLNLGLB(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 41;
				mAPGBEOOFLL.GEIONCLKAGF = 0;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.HNEAGHHABGL(BJGCPDNMHDH, 1386f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void JEHPFGJEGPJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_CONFIRM_PLAYERALREADYEXISTS" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
		{
			Debug.Log("N0" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void BDACLBGMJLF(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 65;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.EGACIBHAMAF(BJGCPDNMHDH, 301f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void FINDAJGNBDJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void OGFHDPBMCCO(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -11;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.JCLGAFGBMDC(BJGCPDNMHDH, 171f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void HPAFKBIJMEJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
		}

		internal void KPNGMLMINJL(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void EJLGBICBIFK(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 100;
				mAPGBEOOFLL.GEIONCLKAGF = 0;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.Begin(BJGCPDNMHDH, 1f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void MMGEJAEDPOB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
		}

		internal void PCKMJMGLPDG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("Deliver_Upgrade_For_Weapon" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void JDEJHLLIONG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_LEAGUE16" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void FKIBFHGKMFJ(UITweener MGDJMGHCAAI)
		{
			Debug.Log("service" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void JEKOCFKHBKH(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -35;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.GINFBGAIDCP(BJGCPDNMHDH, 1853f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void OPPNIDPBBIM(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 104;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.JCLGAFGBMDC(BJGCPDNMHDH, 28f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void ALFPMCHHIMH(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 19;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.JBPMBAKMEOG(BJGCPDNMHDH, 230f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			Debug.Log("S" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void IDEPAHOBFCP(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 123;
				mAPGBEOOFLL.GEIONCLKAGF = 0;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.AGHGKJFDAOA(BJGCPDNMHDH, 750f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void HADFFMNIJLN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void LOPMGEDOGEP(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			Debug.Log("N" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void JNHMJLAGPDL(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void IFOPOPPMCFG(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 75;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.NPHFBDMKODP(BJGCPDNMHDH, 777f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void OGIFCPNDIKC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_GC_LOGIN_TUTORIAL_TEXT" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void BFMHIICIHKL(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -110;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL, LKMKFNIFBCF: true);
				TweenBeginnerLeague.IAGLEIPAIOB(BJGCPDNMHDH, 87f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			Debug.Log("withContentId" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void HONCMBHEKDP(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void HLBKFMJPGEK(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -57;
				mAPGBEOOFLL.GEIONCLKAGF = 0;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.EEODMCJPDNI(BJGCPDNMHDH, 1001f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void OIDEHFKFFGK(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 117;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.JCLGAFGBMDC(BJGCPDNMHDH, 1362f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void MFCNOIDCJME(UITweener MGDJMGHCAAI)
		{
			Debug.Log("WarFriends richiede l'autorizzazione alla memorizzazione multimediale per scaricare dati fondamentali per il gioco.Accetta la finestra di dialogo di autorizzazione che verrà visualizzata. Non useremo questa autorizzazione per altri scopi." + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void PAKIJEIDOBH(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = 49;
				mAPGBEOOFLL.GEIONCLKAGF = 1;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.LCBLJBAJGED(BJGCPDNMHDH, 248f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void HMLMCGLICPM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA, LKMKFNIFBCF: true);
		}

		internal void FBGCFPAGIND(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void BCGIAFBNMIE(UITweener MGDJMGHCAAI)
		{
			if (KDIKHFJAJBA.DHPLNAIKHOC)
			{
				MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(KDIKHFJAJBA);
				mAPGBEOOFLL.MPHCNMDIPAI = -7;
				mAPGBEOOFLL.GEIONCLKAGF = 0;
				BJGCPDNMHDH.InitializeTo(mAPGBEOOFLL);
				TweenBeginnerLeague.GINFBGAIDCP(BJGCPDNMHDH, 433f, mAPGBEOOFLL, KDIKHFJAJBA).onFinished = null;
			}
			else if (KDIKHFJAJBA.ALNDDBGGBNK || !KDIKHFJAJBA.GKEOILLNCHG)
			{
				BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
			}
			else
			{
				BJGCPDNMHDH.ELOGKADAOGE(ILHGHKFHMFD, KDIKHFJAJBA);
			}
		}

		internal void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_XP" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_PLAYERLEAGUE" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = true;
		}

		internal void MMIFBGAHMHD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			Debug.Log("#PETER# League Arc - stop ignore on " + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			Debug.Log("HeroicMissionsCompletionRewardCardPack" + BJGCPDNMHDH.OLGIBPOMNPJ);
			BJGCPDNMHDH.FACGNLAGCBL = false;
		}

		internal void PNINBELBDIP(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.InitializeTo(KDIKHFJAJBA);
		}
	}

	public static Dictionary<League, Color> MJNAEEHPKOP = new Dictionary<League, Color>
	{
		{
			League.NoLeague,
			Colours.whiteTransparent
		},
		{
			League.Bronze3,
			Colours.bronzeBgLeague
		},
		{
			League.Bronze2,
			Colours.bronzeBgLeague
		},
		{
			League.Bronze1,
			Colours.bronzeBgLeague
		},
		{
			League.Silver3,
			Colours.silverBgLeague
		},
		{
			League.Silver2,
			Colours.silverBgLeague
		},
		{
			League.Silver1,
			Colours.silverBgLeague
		},
		{
			League.Gold3,
			Colours.goldBgLeague
		},
		{
			League.Gold2,
			Colours.goldBgLeague
		},
		{
			League.Gold1,
			Colours.goldBgLeague
		},
		{
			League.Elite3,
			Colours.eliteBgLeague
		},
		{
			League.Elite2,
			Colours.eliteBgLeague
		},
		{
			League.Elite1,
			Colours.eliteBgLeague
		},
		{
			League.Master3,
			Colours.masterBgLeague
		},
		{
			League.Master2,
			Colours.masterBgLeague
		},
		{
			League.Master1,
			Colours.masterBgLeague
		},
		{
			League.Champion,
			Colours.championBgLeague
		}
	};

	[Header("Core")]
	public NKHJBLBAAEB OLGIBPOMNPJ;

	[FormerlySerializedAs("MHOPKAHDGMN")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("PMAEEIJCAIA")]
	public UIPanel CFFKHHJKBMJ;

	public UISprite[] CPGMGPPFKCL;

	[FormerlySerializedAs("NCCLNPDCLHF")]
	public UISprite EEFOJAJLDNO;

	[FormerlySerializedAs("CBEFEJNDFBP")]
	public UISprite ILCCDCHPCHK;

	[FormerlySerializedAs("FPCIDKIPIIL")]
	public UISprite CBFOGHLMPFE;

	[FormerlySerializedAs("FELIPIFLEOL")]
	public GameObject HIAGABJAPGH;

	[FormerlySerializedAs("BOOONFIFJKE")]
	[Header("League Icon")]
	public GameObject MOALPNOJMOL;

	[FormerlySerializedAs("KNIHAEEIFLJ")]
	public UISprite NNMCKEECNFK;

	[FormerlySerializedAs("FLPJNDHKEHC")]
	public UISprite EGKHPLONBLD;

	[Header("Promote Demote parts")]
	[FormerlySerializedAs("INDBBKFPOMN")]
	public GameObject BGAAFOAFMPN;

	[FormerlySerializedAs("APINMCKIKMP")]
	public UILabel OAEOOEPJCOG;

	public UISprite MCFJILHJJEE;

	[FormerlySerializedAs("JJEOIGKNNPF")]
	public GameObject HMAHAHCHDPO;

	[FormerlySerializedAs("BBBHPKKHBDE")]
	public UILabel HFGPOFPHFIL;

	public UISprite CAAINGOCKOL;

	[FormerlySerializedAs("HAMNADFNECL")]
	[Header("Medals part")]
	public UITable HCPFFMFGNEL;

	[FormerlySerializedAs("GOMJGLLKCPG")]
	public UISprite OPMFPPJNEGC;

	[FormerlySerializedAs("PNJJLLCBBBE")]
	public UILabel JDDDDOBAFEO;

	[FormerlySerializedAs("IACLNHHJMEP")]
	public UILabel EAHEJGCHDKM;

	[FormerlySerializedAs("LJIPMIOBDMN")]
	[Header("Processing part")]
	public GameObject FMIJAIDDJGK;

	[Header("Not In League part")]
	[FormerlySerializedAs("ILJIKPJCKAD")]
	public GameObject ACHBPKNJMPP;

	[FormerlySerializedAs("BALNNIIDCHF")]
	[Header("Locked part")]
	public GameObject MDAFFKPPCBG;

	[FormerlySerializedAs("EGJPLBMKJLN")]
	[Header("Loading part")]
	public GameObject NNKCIKBBEOM;

	private bool FACGNLAGCBL;

	private bool IKGKNLIJHPE = true;

	private void EPGDBJDEGOM(MAPGBEOOFLL NDPMDKGJAFH)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen))
		{
			if (NDPMDKGJAFH.DHPLNAIKHOC)
			{
				object[] array = new object[7];
				array[1] = "RemoveOld";
				array[0] = OLGIBPOMNPJ;
				array[3] = "ID_CONFIRM_NOSQUADACTIONS_TITLE";
				array[1] = NDPMDKGJAFH.HNEFOLPHMHK;
				Debug.Log(string.Concat(array));
				PLILKFFIFBO(NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI);
			}
			else if (NDPMDKGJAFH.ALNDDBGGBNK)
			{
				Debug.Log(string.Concat("FacebookId", OLGIBPOMNPJ, "country-malaysia"));
				DPKEEPMFJPN();
			}
			else if (NDPMDKGJAFH.GKEOILLNCHG)
			{
				object[] array2 = new object[0];
				array2[0] = "menu-dailyrewards-vip-ico";
				array2[1] = OLGIBPOMNPJ;
				array2[1] = "Warbucks";
				array2[7] = NDPMDKGJAFH.BMNDININJCE;
				Debug.Log(string.Concat(array2));
				KHKHCNNENCE(NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI, NDPMDKGJAFH.LHPLLCNGBBL, NDPMDKGJAFH.CIKCEPEFPFG, NDPMDKGJAFH.HFGPOFPHFIL, NDPMDKGJAFH.CEHILCHIDJB, NDPMDKGJAFH.OAEOOEPJCOG);
			}
			else
			{
				Debug.Log(string.Concat("set visual not borrowed", OLGIBPOMNPJ, "D2"));
				INIPLPDEHFD();
			}
		}
	}

	private void ELOGKADAOGE(MAPGBEOOFLL ILHGHKFHMFD, MAPGBEOOFLL KDIKHFJAJBA)
	{
		InitializeTo(KDIKHFJAJBA);
		Debug.LogFormat("#PETER# League Arc Animation - Error - previous: {0}     current: {1}", ILHGHKFHMFD.JLJICIKKCCO, KDIKHFJAJBA.JLJICIKKCCO);
	}

	private void KHKHCNNENCE(League BMNDININJCE, int GEIONCLKAGF, int CJLGKBLPDHI, int KNJGKAIFGLN, bool CIKCEPEFPFG, int LOBLBJNJJPJ, bool CEHILCHIDJB, int GJCECICKCJP)
	{
		bool flag = KNJGKAIFGLN > (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-144)).FLOATVALUE;
		NNKCIKBBEOM.SetActive(value: false);
		EEFOJAJLDNO.gameObject.SetActive(value: true);
		ILCCDCHPCHK.gameObject.SetActive(value: true);
		BGAAFOAFMPN.SetActive(flag && CEHILCHIDJB);
		OAEOOEPJCOG.gameObject.SetActive(!flag || CEHILCHIDJB);
		OAEOOEPJCOG.text = MEJMLNDFDBP.GMIPFLIEOHD(GJCECICKCJP);
		HMAHAHCHDPO.SetActive(!flag || CIKCEPEFPFG);
		HFGPOFPHFIL.gameObject.SetActive(!flag || CIKCEPEFPFG);
		HFGPOFPHFIL.text = MEJMLNDFDBP.GMIPFLIEOHD(LOBLBJNJJPJ);
		MOALPNOJMOL.SetActive(value: false);
		NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
		JLJIAADCPPE(MJNAEEHPKOP[BMNDININJCE]);
		EGKHPLONBLD.spriteName = NNMCKEECNFK.spriteName;
		HCPFFMFGNEL.gameObject.SetActive(value: true);
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GEIONCLKAGF);
		EAHEJGCHDKM.transform.parent.transform.gameObject.SetActive(value: true);
		HCPFFMFGNEL.repositionNow = false;
		SetArrow(CJLGKBLPDHI, KNJGKAIFGLN, BMNDININJCE);
		SetGlow(CJLGKBLPDHI, KNJGKAIFGLN, BMNDININJCE);
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: true);
	}

	private void MPOEFIODDCC()
	{
		Debug.Log("#PETER# League Arc - stop ignore on " + OLGIBPOMNPJ);
		FACGNLAGCBL = false;
	}

	private void NIMJKINAEDK(MAPGBEOOFLL NDPMDKGJAFH)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader))
		{
			if (NDPMDKGJAFH.DHPLNAIKHOC)
			{
				Debug.Log(string.Concat("#PETER# League Arc ", OLGIBPOMNPJ, " set beginners league ", NDPMDKGJAFH.HNEFOLPHMHK));
				PLILKFFIFBO(NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI);
			}
			else if (NDPMDKGJAFH.ALNDDBGGBNK)
			{
				Debug.Log(string.Concat("#PETER# League Arc ", OLGIBPOMNPJ, " set league processing"));
				DPKEEPMFJPN();
			}
			else if (NDPMDKGJAFH.GKEOILLNCHG)
			{
				Debug.Log(string.Concat("#PETER# League Arc ", OLGIBPOMNPJ, " set league ", NDPMDKGJAFH.BMNDININJCE));
				DPOKOBBDLJP(NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI, NDPMDKGJAFH.LHPLLCNGBBL, NDPMDKGJAFH.CIKCEPEFPFG, NDPMDKGJAFH.HFGPOFPHFIL, NDPMDKGJAFH.CEHILCHIDJB, NDPMDKGJAFH.OAEOOEPJCOG);
			}
			else
			{
				Debug.Log(string.Concat("#PETER# League Arc ", OLGIBPOMNPJ, " set not in league"));
				INIPLPDEHFD();
			}
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IKNBCABDPKP));
		HCPFFMFGNEL.onReposition = delegate
		{
			GameObject gameObject = ((!EAHEJGCHDKM.transform.parent.transform.gameObject.activeSelf) ? JDDDDOBAFEO.transform.parent.transform.gameObject : EAHEJGCHDKM.transform.parent.transform.gameObject);
			float val = 0f - HCPFFMFGNEL.padding.x - (gameObject.transform.localPosition.x - HCPFFMFGNEL.padding.x) / 2f;
			HCPFFMFGNEL.transform.localPosition = HCPFFMFGNEL.transform.localPosition.ReplaceX(val);
		};
	}

	public void JINGNPBEKJK(MAPGBEOOFLL ILHGHKFHMFD, MAPGBEOOFLL KDIKHFJAJBA)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.KDIKHFJAJBA = KDIKHFJAJBA;
		hAJEIGIFBOO.ILHGHKFHMFD = ILHGHKFHMFD;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		object[] array = new object[8];
		array[1] = OLGIBPOMNPJ;
		array[1] = hAJEIGIFBOO.ILHGHKFHMFD.FKIACIKMFIE();
		array[7] = hAJEIGIFBOO.KDIKHFJAJBA.JLJICIKKCCO;
		Debug.LogFormat("IsVip", array);
		if (hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC)
		{
			if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK == hAJEIGIFBOO.KDIKHFJAJBA.HNEFOLPHMHK)
			{
				TweenBeginnerLeague.CABGNGMLIEK(this, 709f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.KJIFNOJILDB;
				return;
			}
			MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(hAJEIGIFBOO.ILHGHKFHMFD);
			mAPGBEOOFLL.MPHCNMDIPAI = 0;
			mAPGBEOOFLL.GEIONCLKAGF = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK);
			TweenBeginnerLeague.LPGNGJBPAKH(this, 458f, hAJEIGIFBOO.ILHGHKFHMFD, mAPGBEOOFLL).onFinished = hAJEIGIFBOO.PKCGGMPIPDL;
			return;
		}
		bool flag = !hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC && !hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK && !hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag2 = hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC || hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK || hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag3 = hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC || hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK || hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		bool flag4 = hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC || hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK || hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else if (flag2 && flag4)
		{
			TweenLeague.IPOEOHBLGMJ(this, 76f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.HPAFKBIJMEJ;
		}
		else if (flag && flag3)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else
		{
			InitializeTo(hAJEIGIFBOO.KDIKHFJAJBA);
		}
	}

	public void KMEEGJFHJBB(int CJLGKBLPDHI, int BBBEPJKPOBE, League LFEHIJBBOGC)
	{
		bool flag = BBBEPJKPOBE > (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-15)).FLOATVALUE;
		HIAGABJAPGH.SetActive(value: true);
		float a = 157f;
		float b = 1579f;
		float num = 788f;
		float num2 = 1180f;
		if (!flag)
		{
			num = ((BBBEPJKPOBE >= 7) ? ((float)(BBBEPJKPOBE - CJLGKBLPDHI) / (float)(BBBEPJKPOBE - 1)) : 1119f);
			num2 = Mathf.Lerp(a, b, num);
			FFIJFAANDHD(num2);
			return;
		}
		CJLGKBLPDHI = Mathf.Clamp(CJLGKBLPDHI, 1, BBBEPJKPOBE);
		bool flag2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(LFEHIJBBOGC) > 1124f;
		bool flag3 = Singleton<GameVariables>.instance.LeagueGoUpPercent(LFEHIJBBOGC) > 1806f;
		int num3 = Singleton<GameVariables>.instance.AKGHLMKODBJ(BBBEPJKPOBE, LFEHIJBBOGC);
		int num4 = Singleton<GameVariables>.instance.LOAOEHEJFJA(BBBEPJKPOBE, LFEHIJBBOGC);
		if (CJLGKBLPDHI <= num3)
		{
			a = 53f;
			b = 622f;
			int num5 = CJLGKBLPDHI;
			int num6 = num3;
			num = ((num6 >= 0) ? ((float)(num6 - num5) / (float)(num6 - 1)) : 913f);
		}
		else if (CJLGKBLPDHI >= num4)
		{
			a = 704f;
			b = 1694f;
			int num7 = CJLGKBLPDHI - num4;
			int num8 = BBBEPJKPOBE - num4;
			num = ((num8 >= 8) ? ((float)(num8 - num7) / (float)num8) : 1849f);
		}
		else if (flag3 && !flag2)
		{
			a = 1315f;
			b = 1181f;
			int num9 = CJLGKBLPDHI - num3;
			int num10 = BBBEPJKPOBE - num3;
			num = (float)(num10 - num9) / (float)num10;
		}
		else if (flag2 && !flag3)
		{
			a = 893f;
			b = 398f;
			int num11 = CJLGKBLPDHI;
			int num12 = num4;
			num = (float)(num12 - num11) / (float)(num12 - 0);
		}
		else
		{
			a = 1071f;
			b = 637f;
			int num13 = CJLGKBLPDHI - num3;
			int num14 = num4 - num3;
			num = (float)(num14 - num13) / (float)(num14 - 0);
		}
		num2 = Mathf.Lerp(a, b, num);
		FHLOAJJDIEG(num2);
	}

	private void JOBHIGJOCLK(League BMNDININJCE, int GEIONCLKAGF)
	{
		NJEAMAHEMHP.enabled = true;
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(BMNDININJCE);
		float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(BMNDININJCE);
		bool active = num > 0f;
		bool active2 = num2 > 0f;
		MOALPNOJMOL.SetActive(value: true);
		NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
		JLJIAADCPPE(MJNAEEHPKOP[BMNDININJCE]);
		EGKHPLONBLD.spriteName = NNMCKEECNFK.spriteName;
		HCPFFMFGNEL.gameObject.SetActive(value: true);
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GEIONCLKAGF);
		EAHEJGCHDKM.transform.parent.transform.gameObject.SetActive(value: false);
		HCPFFMFGNEL.repositionNow = true;
		BGAAFOAFMPN.SetActive(active);
		OAEOOEPJCOG.gameObject.SetActive(active);
		OAEOOEPJCOG.text = string.Empty;
		HMAHAHCHDPO.SetActive(active2);
		HFGPOFPHFIL.gameObject.SetActive(active2);
		HFGPOFPHFIL.text = string.Empty;
		HIAGABJAPGH.SetActive(value: false);
		HideGlow();
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: true);
	}

	private void HKEGJIGGOHC(GameObject KHAHPAKDIKE)
	{
		if (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		}
		if (OLGIBPOMNPJ == NKHJBLBAAEB.EndScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			GuiScreenSingle<LeaguesScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
		}
	}

	private void FAHDOEECBKD(League BMNDININJCE, int GEIONCLKAGF)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && IKGKNLIJHPE && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen))
		{
			object[] array = new object[0];
			array[1] = "ID_READYTIME";
			array[1] = OLGIBPOMNPJ;
			array[2] = "WRONG dynamic font size: {0} for label: {1}\n";
			array[5] = BMNDININJCE;
			Debug.Log(string.Concat(array));
			JOBHIGJOCLK(BMNDININJCE, GEIONCLKAGF);
			IKGKNLIJHPE = true;
		}
	}

	private void KFNNINNOMHF()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen))
		{
			InitGuiValues();
		}
	}

	public void EAPMKACOGGI()
	{
		MAPGBEOOFLL previousData = LeagueArcManager.instance.GetPreviousData();
		JOBHIGJOCLK(previousData.BMNDININJCE, previousData.GEIONCLKAGF);
		Debug.Log("ID_WARNING_CONNECTIONERROR_TEXT" + OLGIBPOMNPJ);
		FACGNLAGCBL = false;
	}

	public void InitGuiValues()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			ABIMNIIOPMG();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			KBJNINDOKMM();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int currentPositionInBeginnersLeague = FakePlayersManager.instance.GetCurrentPositionInBeginnersLeague(100, medalsBalance, beginnersLeague);
			PLILKFFIFBO(beginnersLeague, medalsBalance, currentPositionInBeginnersLeague);
		}
		else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			DPKEEPMFJPN();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			IKGKNLIJHPE = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			int medalsBalance2 = GameLoginManager.currentPlayer.medalsBalance;
			JOBHIGJOCLK(leagueTier, medalsBalance2);
			Singleton<BeanstalkServerManager>.instance.CCPMCLFPCIF(GameLoginManager.currentPlayer.leagueId);
		}
		else
		{
			INIPLPDEHFD();
		}
	}

	public void IDDLDDBKJJK()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			ABIMNIIOPMG();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			JMCFALAGHJK();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int currentPositionInBeginnersLeague = FakePlayersManager.instance.GetCurrentPositionInBeginnersLeague(32, medalsBalance, beginnersLeague);
			PLILKFFIFBO(beginnersLeague, medalsBalance, currentPositionInBeginnersLeague);
		}
		else if (Singleton<ServerResultsCache>.instance.HLFMPGHKOFE())
		{
			DPKEEPMFJPN();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			IKGKNLIJHPE = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			int medalsBalance2 = GameLoginManager.currentPlayer.medalsBalance;
			JOBHIGJOCLK(leagueTier, medalsBalance2);
			Singleton<BeanstalkServerManager>.instance.ECEAPNOAOEK(GameLoginManager.currentPlayer.leagueId);
		}
		else
		{
			INIPLPDEHFD();
		}
	}

	private void JMCFALAGHJK()
	{
		NJEAMAHEMHP.enabled = false;
		JLJIAADCPPE(Colours.gray7e);
		MDAFFKPPCBG.SetActive(value: true);
		EEFOJAJLDNO.gameObject.SetActive(value: true);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: false);
		HCPFFMFGNEL.gameObject.SetActive(value: true);
		BGAAFOAFMPN.SetActive(value: false);
		OAEOOEPJCOG.gameObject.SetActive(value: true);
		HMAHAHCHDPO.SetActive(value: false);
		HFGPOFPHFIL.gameObject.SetActive(value: true);
		FMIJAIDDJGK.SetActive(value: true);
		ACHBPKNJMPP.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: true);
		HIAGABJAPGH.SetActive(value: true);
		LFBJBEFBOGM();
	}

	[CompilerGenerated]
	private void HLHMGOCGMFO()
	{
		GameObject gameObject = ((!EAHEJGCHDKM.transform.parent.transform.gameObject.activeSelf) ? JDDDDOBAFEO.transform.parent.transform.gameObject : EAHEJGCHDKM.transform.parent.transform.gameObject);
		float val = 0f - HCPFFMFGNEL.padding.x - (gameObject.transform.localPosition.x - HCPFFMFGNEL.padding.x) / 2f;
		HCPFFMFGNEL.transform.localPosition = HCPFFMFGNEL.transform.localPosition.ReplaceX(val);
	}

	private void FCMJLKGPDHH(float PAENPHMEMGC)
	{
		float oOMCGGAFJNH = Mathf.Lerp(54f, 1605f, PAENPHMEMGC);
		HIAGABJAPGH.SetActive(value: true);
		FFIJFAANDHD(oOMCGGAFJNH);
	}

	public void NKGLOPMGBFH(MAPGBEOOFLL ILHGHKFHMFD, MAPGBEOOFLL KDIKHFJAJBA)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.KDIKHFJAJBA = KDIKHFJAJBA;
		hAJEIGIFBOO.ILHGHKFHMFD = ILHGHKFHMFD;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		object[] array = new object[2];
		array[0] = OLGIBPOMNPJ;
		array[1] = hAJEIGIFBOO.ILHGHKFHMFD.BMHKIIMDFBF();
		array[0] = hAJEIGIFBOO.KDIKHFJAJBA.OMOEMHCFELF();
		Debug.LogFormat("ID_MEDALSTOJOINBIG", array);
		if (hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC)
		{
			if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK == hAJEIGIFBOO.KDIKHFJAJBA.HNEFOLPHMHK)
			{
				TweenBeginnerLeague.KAEBPEJBJCI(this, 60f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.NNIJEDKBPGJ;
				return;
			}
			MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(hAJEIGIFBOO.ILHGHKFHMFD);
			mAPGBEOOFLL.MPHCNMDIPAI = 1;
			mAPGBEOOFLL.GEIONCLKAGF = Singleton<GameVariables>.instance.BMIAACJFNBC(hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK);
			TweenBeginnerLeague.LPGNGJBPAKH(this, 1974f, hAJEIGIFBOO.ILHGHKFHMFD, mAPGBEOOFLL).onFinished = hAJEIGIFBOO.PAKIJEIDOBH;
			return;
		}
		bool flag = hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC || hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK || hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag2 = hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC || hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK || hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag3 = hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC || hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK || !hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		bool flag4 = hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC || hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK || hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else if (flag2 && flag4)
		{
			TweenLeague.OHHMFLKGKBP(this, 1227f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.HONCMBHEKDP;
		}
		else if (flag && flag3)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else
		{
			InitializeTo(hAJEIGIFBOO.KDIKHFJAJBA);
		}
	}

	[CompilerGenerated]
	private void HLMPLBNOMCP(UITweener MGDJMGHCAAI)
	{
		MCFJILHJJEE.gameObject.SetActive(value: false);
	}

	public void InitializeTo(MAPGBEOOFLL NDPMDKGJAFH, bool LKMKFNIFBCF = false)
	{
		if (LKMKFNIFBCF)
		{
			Debug.Log("#PETER# League Arc - start ignore on " + OLGIBPOMNPJ);
			FACGNLAGCBL = true;
		}
		if (NDPMDKGJAFH.DHPLNAIKHOC)
		{
			PLILKFFIFBO(NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI);
		}
		else if (NDPMDKGJAFH.ALNDDBGGBNK)
		{
			DPKEEPMFJPN();
		}
		else if (NDPMDKGJAFH.GKEOILLNCHG)
		{
			DPOKOBBDLJP(NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI, NDPMDKGJAFH.LHPLLCNGBBL, NDPMDKGJAFH.CIKCEPEFPFG, NDPMDKGJAFH.HFGPOFPHFIL, NDPMDKGJAFH.CEHILCHIDJB, NDPMDKGJAFH.OAEOOEPJCOG);
		}
		else
		{
			INIPLPDEHFD();
		}
	}

	private void DPKEEPMFJPN()
	{
		NJEAMAHEMHP.enabled = true;
		JLJIAADCPPE(Colours.gray7e);
		FMIJAIDDJGK.SetActive(value: true);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: false);
		HCPFFMFGNEL.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(value: false);
		OAEOOEPJCOG.gameObject.SetActive(value: false);
		HMAHAHCHDPO.SetActive(value: false);
		HFGPOFPHFIL.gameObject.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		HIAGABJAPGH.SetActive(value: false);
		HideGlow();
	}

	private void FFIJFAANDHD(float OOMCGGAFJNH)
	{
		OOMCGGAFJNH = Mathf.Clamp(OOMCGGAFJNH, -90f, 90f);
		HIAGABJAPGH.transform.localRotation = Quaternion.Euler(0f, 0f, OOMCGGAFJNH);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(0f, 0f, HPHBDEGPKNM(OOMCGGAFJNH));
	}

	public void SetBeginnersPosition(int CJLGKBLPDHI)
	{
		float num = (float)(100 - CJLGKBLPDHI) / 99f;
		GBFENCPMPOK(num);
		num *= 2f;
		EEFOJAJLDNO.fillAmount = Mathf.Clamp01(num);
		ILCCDCHPCHK.fillAmount = Mathf.Clamp01(num - 1f);
	}

	public void SetArrow(int CJLGKBLPDHI, int BBBEPJKPOBE, League LFEHIJBBOGC)
	{
		bool flag = BBBEPJKPOBE > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		HIAGABJAPGH.SetActive(value: true);
		float a = 90f;
		float b = -90f;
		float num = 1f;
		float num2 = 0f;
		if (!flag)
		{
			num = ((BBBEPJKPOBE >= 2) ? ((float)(BBBEPJKPOBE - CJLGKBLPDHI) / (float)(BBBEPJKPOBE - 1)) : 1f);
			num2 = Mathf.Lerp(a, b, num);
			FFIJFAANDHD(num2);
			return;
		}
		CJLGKBLPDHI = Mathf.Clamp(CJLGKBLPDHI, 1, BBBEPJKPOBE);
		bool flag2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(LFEHIJBBOGC) > 0f;
		bool flag3 = Singleton<GameVariables>.instance.LeagueGoUpPercent(LFEHIJBBOGC) > 0f;
		int num3 = Singleton<GameVariables>.instance.LeaguePositionPromote(BBBEPJKPOBE, LFEHIJBBOGC);
		int num4 = Singleton<GameVariables>.instance.LeaguePositionDemote(BBBEPJKPOBE, LFEHIJBBOGC);
		if (CJLGKBLPDHI <= num3)
		{
			a = -45f;
			b = -90f;
			int num5 = CJLGKBLPDHI;
			int num6 = num3;
			num = ((num6 >= 2) ? ((float)(num6 - num5) / (float)(num6 - 1)) : 1f);
		}
		else if (CJLGKBLPDHI >= num4)
		{
			a = 90f;
			b = 45f;
			int num7 = CJLGKBLPDHI - num4;
			int num8 = BBBEPJKPOBE - num4;
			num = ((num8 >= 2) ? ((float)(num8 - num7) / (float)num8) : 0f);
		}
		else if (flag3 && !flag2)
		{
			a = 90f;
			b = -45f;
			int num9 = CJLGKBLPDHI - num3;
			int num10 = BBBEPJKPOBE - num3;
			num = (float)(num10 - num9) / (float)num10;
		}
		else if (flag2 && !flag3)
		{
			a = 45f;
			b = -90f;
			int num11 = CJLGKBLPDHI;
			int num12 = num4;
			num = (float)(num12 - num11) / (float)(num12 - 1);
		}
		else
		{
			a = 45f;
			b = -45f;
			int num13 = CJLGKBLPDHI - num3;
			int num14 = num4 - num3;
			num = (float)(num14 - num13) / (float)(num14 - 1);
		}
		num2 = Mathf.Lerp(a, b, num);
		FFIJFAANDHD(num2);
	}

	private void DPOKOBBDLJP(League BMNDININJCE, int GEIONCLKAGF, int CJLGKBLPDHI, int KNJGKAIFGLN, bool CIKCEPEFPFG, int LOBLBJNJJPJ, bool CEHILCHIDJB, int GJCECICKCJP)
	{
		bool flag = KNJGKAIFGLN > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		NNKCIKBBEOM.SetActive(value: false);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(flag && CEHILCHIDJB);
		OAEOOEPJCOG.gameObject.SetActive(flag && CEHILCHIDJB);
		OAEOOEPJCOG.text = MEJMLNDFDBP.GMIPFLIEOHD(GJCECICKCJP);
		HMAHAHCHDPO.SetActive(flag && CIKCEPEFPFG);
		HFGPOFPHFIL.gameObject.SetActive(flag && CIKCEPEFPFG);
		HFGPOFPHFIL.text = MEJMLNDFDBP.GMIPFLIEOHD(LOBLBJNJJPJ);
		MOALPNOJMOL.SetActive(value: true);
		NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[BMNDININJCE].Value2;
		JLJIAADCPPE(MJNAEEHPKOP[BMNDININJCE]);
		EGKHPLONBLD.spriteName = NNMCKEECNFK.spriteName;
		HCPFFMFGNEL.gameObject.SetActive(value: true);
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GEIONCLKAGF);
		EAHEJGCHDKM.transform.parent.transform.gameObject.SetActive(value: false);
		HCPFFMFGNEL.repositionNow = true;
		SetArrow(CJLGKBLPDHI, KNJGKAIFGLN, BMNDININJCE);
		SetGlow(CJLGKBLPDHI, KNJGKAIFGLN, BMNDININJCE);
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
	}

	[CompilerGenerated]
	private void GDEMNNLBNMD(UITweener MGDJMGHCAAI)
	{
		CAAINGOCKOL.gameObject.SetActive(value: false);
	}

	private void BFJLGBHCABG(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader) && (IFGAGNBDKBE == DatabaseAction.ClaimAssignment || IFGAGNBDKBE == (DatabaseAction)(-109) || IFGAGNBDKBE == (DatabaseAction)(-35)))
		{
			EPFKCOHPCAK();
		}
	}

	public void ACLFHDDIBJH()
	{
		TweenBeginnerLeague component = base.gameObject.GetComponent<TweenBeginnerLeague>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenLeague component2 = base.gameObject.GetComponent<TweenLeague>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
	}

	private void KDGJBMIKBLB(MAPGBEOOFLL NDPMDKGJAFH)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader))
		{
			if (NDPMDKGJAFH.DHPLNAIKHOC)
			{
				object[] array = new object[4];
				array[0] = "dailyLimit";
				array[1] = OLGIBPOMNPJ;
				array[2] = ",";
				array[6] = NDPMDKGJAFH.HNEFOLPHMHK;
				Debug.Log(string.Concat(array));
				PLILKFFIFBO(NDPMDKGJAFH.HNEFOLPHMHK, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI);
			}
			else if (NDPMDKGJAFH.ALNDDBGGBNK)
			{
				Debug.Log(string.Concat("WarBucks", OLGIBPOMNPJ, "already in clan (in cache)"));
				DPKEEPMFJPN();
			}
			else if (NDPMDKGJAFH.GKEOILLNCHG)
			{
				object[] array2 = new object[8];
				array2[1] = "UnlockLevel";
				array2[0] = OLGIBPOMNPJ;
				array2[6] = "batchSizeMax";
				array2[0] = NDPMDKGJAFH.BMNDININJCE;
				Debug.Log(string.Concat(array2));
				DPOKOBBDLJP(NDPMDKGJAFH.BMNDININJCE, NDPMDKGJAFH.GEIONCLKAGF, NDPMDKGJAFH.MPHCNMDIPAI, NDPMDKGJAFH.LHPLLCNGBBL, NDPMDKGJAFH.CIKCEPEFPFG, NDPMDKGJAFH.HFGPOFPHFIL, NDPMDKGJAFH.CEHILCHIDJB, NDPMDKGJAFH.OAEOOEPJCOG);
			}
			else
			{
				Debug.Log(string.Concat("ID_GOLDPACK", OLGIBPOMNPJ, "ID_EMBLEM"));
				FANALBFLHLN();
			}
		}
	}

	private void JLJIAADCPPE(Color AINJLDDEGCD)
	{
		UISprite[] cPGMGPPFKCL = CPGMGPPFKCL;
		foreach (UISprite uISprite in cPGMGPPFKCL)
		{
			uISprite.color = AINJLDDEGCD.ReplaceA(uISprite.alpha);
		}
	}

	private void LBLPDNJHAMN(League BMNDININJCE, int GEIONCLKAGF)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && IKGKNLIJHPE && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader))
		{
			object[] array = new object[4];
			array[0] = "N0";
			array[1] = OLGIBPOMNPJ;
			array[6] = "SquadWarEndDialog - Claiming gold: {0}";
			array[6] = BMNDININJCE;
			Debug.Log(string.Concat(array));
			JOBHIGJOCLK(BMNDININJCE, GEIONCLKAGF);
			IKGKNLIJHPE = true;
		}
	}

	public void HGFBALANKEE()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += JBEGIMNADJK;
		LeagueArcManager.instance.ShowLoading += OKOGGMKBLIH;
		LeagueArcManager.instance.LeagueArcUpdate += NIMJKINAEDK;
		LeagueArcManager.instance.JIHLCJOACDL(MPOEFIODDCC);
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.BHLILOLJHMK = (Action)Delegate.Combine(instance.BHLILOLJHMK, new Action(KFNNINNOMHF));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BFJLGBHCABG);
	}

	private void FHLOAJJDIEG(float OOMCGGAFJNH)
	{
		OOMCGGAFJNH = Mathf.Clamp(OOMCGGAFJNH, 405f, 1669f);
		HIAGABJAPGH.transform.localRotation = Quaternion.Euler(144f, 858f, OOMCGGAFJNH);
		CBFOGHLMPFE.transform.localRotation = Quaternion.Euler(48f, 1569f, JADEEBNFGHK(OOMCGGAFJNH));
	}

	private void FJHGNLGNPGE()
	{
		Debug.Log("ID_ARENACROWN_DURATION" + OLGIBPOMNPJ);
		FACGNLAGCBL = true;
	}

	public void LFBJBEFBOGM()
	{
		if (CAAINGOCKOL != null)
		{
			CAAINGOCKOL.gameObject.SetActive(value: true);
		}
		if (MCFJILHJJEE != null)
		{
			MCFJILHJJEE.gameObject.SetActive(value: true);
		}
	}

	private void FCCOJNDHEIP(League BMNDININJCE, int GEIONCLKAGF)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && IKGKNLIJHPE && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen))
		{
			object[] array = new object[1];
			array[0] = "ID_CONFIRM_ERROR";
			array[1] = OLGIBPOMNPJ;
			array[7] = "*****   Bootcamp Play WarCards Started   *****";
			array[3] = BMNDININJCE;
			Debug.Log(string.Concat(array));
			JOBHIGJOCLK(BMNDININJCE, GEIONCLKAGF);
			IKGKNLIJHPE = false;
		}
	}

	public void EPFKCOHPCAK()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			ABIMNIIOPMG();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			JMCFALAGHJK();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int currentPositionInBeginnersLeague = FakePlayersManager.instance.GetCurrentPositionInBeginnersLeague(69, medalsBalance, beginnersLeague);
			PLILKFFIFBO(beginnersLeague, medalsBalance, currentPositionInBeginnersLeague);
		}
		else if (Singleton<ServerResultsCache>.instance.LKCGEKLNOHI())
		{
			DPKEEPMFJPN();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			IKGKNLIJHPE = false;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			int medalsBalance2 = GameLoginManager.currentPlayer.medalsBalance;
			JOBHIGJOCLK(leagueTier, medalsBalance2);
			Singleton<BeanstalkServerManager>.instance.ECEAPNOAOEK(GameLoginManager.currentPlayer.leagueId);
		}
		else
		{
			INIPLPDEHFD();
		}
	}

	private void GBFENCPMPOK(float PAENPHMEMGC)
	{
		float oOMCGGAFJNH = Mathf.Lerp(90f, -90f, PAENPHMEMGC);
		HIAGABJAPGH.SetActive(value: true);
		FFIJFAANDHD(oOMCGGAFJNH);
	}

	private void FANALBFLHLN()
	{
		NJEAMAHEMHP.enabled = true;
		JLJIAADCPPE(Colours.blueEnterLeague);
		ACHBPKNJMPP.SetActive(value: false);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: false);
		HCPFFMFGNEL.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(value: true);
		OAEOOEPJCOG.gameObject.SetActive(value: true);
		HMAHAHCHDPO.SetActive(value: true);
		HFGPOFPHFIL.gameObject.SetActive(value: true);
		FMIJAIDDJGK.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		HIAGABJAPGH.SetActive(value: true);
		HideGlow();
	}

	private void ABIMNIIOPMG()
	{
		NJEAMAHEMHP.enabled = false;
		JLJIAADCPPE(Colours.gray7e);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: false);
		HCPFFMFGNEL.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(value: false);
		OAEOOEPJCOG.gameObject.SetActive(value: false);
		HMAHAHCHDPO.SetActive(value: false);
		HFGPOFPHFIL.gameObject.SetActive(value: false);
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		HIAGABJAPGH.SetActive(value: false);
		HideGlow();
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		GameObject gameObject = ((!EAHEJGCHDKM.transform.parent.transform.gameObject.activeSelf) ? JDDDDOBAFEO.transform.parent.transform.gameObject : EAHEJGCHDKM.transform.parent.transform.gameObject);
		float val = 0f - HCPFFMFGNEL.padding.x - (gameObject.transform.localPosition.x - HCPFFMFGNEL.padding.x) / 2f;
		HCPFFMFGNEL.transform.localPosition = HCPFFMFGNEL.transform.localPosition.ReplaceX(val);
	}

	public void IKHPOKNAGGN()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += JBEGIMNADJK;
		LeagueArcManager.instance.ShowLoading += FCCOJNDHEIP;
		LeagueArcManager.instance.LeagueArcUpdate += EPGDBJDEGOM;
		LeagueArcManager.instance.StopIgnore += FJHGNLGNPGE;
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.BHLILOLJHMK = (Action)Delegate.Combine(instance.BHLILOLJHMK, new Action(PNOOCAPMLBK));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
	}

	private void PHEKPMBOOMP()
	{
		NJEAMAHEMHP.enabled = true;
		JLJIAADCPPE(Colours.blueEnterLeague);
		ACHBPKNJMPP.SetActive(value: false);
		EEFOJAJLDNO.gameObject.SetActive(value: true);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: true);
		HCPFFMFGNEL.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(value: true);
		OAEOOEPJCOG.gameObject.SetActive(value: true);
		HMAHAHCHDPO.SetActive(value: true);
		HFGPOFPHFIL.gameObject.SetActive(value: false);
		FMIJAIDDJGK.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		HIAGABJAPGH.SetActive(value: true);
		LFBJBEFBOGM();
	}

	public void SetGlow(int CJLGKBLPDHI, int BBBEPJKPOBE, League LFEHIJBBOGC, bool AJNINHIKAFC = false)
	{
		if (CAAINGOCKOL == null || MCFJILHJJEE == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		if (BBBEPJKPOBE > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE)
		{
			bool flag3 = Singleton<GameVariables>.instance.LeagueGoDownPercent(LFEHIJBBOGC) > 0f;
			bool flag4 = Singleton<GameVariables>.instance.LeagueGoUpPercent(LFEHIJBBOGC) > 0f;
			int num = Singleton<GameVariables>.instance.LeaguePositionPromote(BBBEPJKPOBE, LFEHIJBBOGC);
			int num2 = Singleton<GameVariables>.instance.LeaguePositionDemote(BBBEPJKPOBE, LFEHIJBBOGC);
			flag = flag4 && CJLGKBLPDHI <= num;
			flag2 = flag3 && CJLGKBLPDHI >= num2;
		}
		if (AJNINHIKAFC)
		{
			if (flag && !CAAINGOCKOL.gameObject.activeSelf)
			{
				CAAINGOCKOL.gameObject.SetActive(value: true);
				TweenAlpha.Begin(CAAINGOCKOL.gameObject, 0.2f, 0f, 1f).onFinished = null;
			}
			if (!flag && CAAINGOCKOL.gameObject.activeSelf && CAAINGOCKOL.alpha == 1f)
			{
				TweenAlpha.Begin(CAAINGOCKOL.gameObject, 0.2f, 1f, 0f).onFinished = delegate
				{
					CAAINGOCKOL.gameObject.SetActive(value: false);
				};
			}
			if (flag2 && !MCFJILHJJEE.gameObject.activeSelf)
			{
				MCFJILHJJEE.gameObject.SetActive(value: true);
				TweenAlpha.Begin(MCFJILHJJEE.gameObject, 0.2f, 0f, 1f).onFinished = null;
			}
			if (!flag2 && MCFJILHJJEE.gameObject.activeSelf && MCFJILHJJEE.alpha == 1f)
			{
				TweenAlpha.Begin(MCFJILHJJEE.gameObject, 0.2f, 1f, 0f).onFinished = delegate
				{
					MCFJILHJJEE.gameObject.SetActive(value: false);
				};
			}
		}
		else
		{
			CAAINGOCKOL.gameObject.SetActive(flag);
			MCFJILHJJEE.gameObject.SetActive(flag2);
			CAAINGOCKOL.alpha = 1f;
			MCFJILHJJEE.alpha = 1f;
			TweenAlpha component = CAAINGOCKOL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			component = MCFJILHJJEE.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private void JKJOOAAHGHP(UITweener MGDJMGHCAAI)
	{
		MCFJILHJJEE.gameObject.SetActive(value: false);
	}

	private void OKOGGMKBLIH(League BMNDININJCE, int GEIONCLKAGF)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && IKGKNLIJHPE && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader))
		{
			Debug.Log(string.Concat("#PETER# League Arc ", OLGIBPOMNPJ, " set loading for league ", BMNDININJCE));
			JOBHIGJOCLK(BMNDININJCE, GEIONCLKAGF);
			IKGKNLIJHPE = false;
		}
	}

	private void PHGFBJFFFPH()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader && LevelManager.instance.isMainScreenPartsLocked)
		{
			InitGuiValues();
		}
	}

	private void INIPLPDEHFD()
	{
		NJEAMAHEMHP.enabled = true;
		JLJIAADCPPE(Colours.blueEnterLeague);
		ACHBPKNJMPP.SetActive(value: true);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: false);
		HCPFFMFGNEL.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(value: false);
		OAEOOEPJCOG.gameObject.SetActive(value: false);
		HMAHAHCHDPO.SetActive(value: false);
		HFGPOFPHFIL.gameObject.SetActive(value: false);
		FMIJAIDDJGK.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
		HIAGABJAPGH.SetActive(value: false);
		HideGlow();
	}

	private void NGAOACPFBPC()
	{
		GameObject gameObject = ((!EAHEJGCHDKM.transform.parent.transform.gameObject.activeSelf) ? JDDDDOBAFEO.transform.parent.transform.gameObject : EAHEJGCHDKM.transform.parent.transform.gameObject);
		float val = 0f - HCPFFMFGNEL.padding.x - (gameObject.transform.localPosition.x - HCPFFMFGNEL.padding.x) / 1057f;
		HCPFFMFGNEL.transform.localPosition = HCPFFMFGNEL.transform.localPosition.ReplaceX(val);
	}

	private void KBJNINDOKMM()
	{
		NJEAMAHEMHP.enabled = false;
		JLJIAADCPPE(Colours.gray7e);
		MDAFFKPPCBG.SetActive(value: true);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		MOALPNOJMOL.SetActive(value: false);
		HCPFFMFGNEL.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(value: false);
		OAEOOEPJCOG.gameObject.SetActive(value: false);
		HMAHAHCHDPO.SetActive(value: false);
		HFGPOFPHFIL.gameObject.SetActive(value: false);
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		HIAGABJAPGH.SetActive(value: false);
		HideGlow();
	}

	public void Animate(MAPGBEOOFLL ILHGHKFHMFD, MAPGBEOOFLL KDIKHFJAJBA)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.KDIKHFJAJBA = KDIKHFJAJBA;
		hAJEIGIFBOO.ILHGHKFHMFD = ILHGHKFHMFD;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		Debug.LogFormat("#PETER# Animating league arc {0}    from:\"{1}\"  to:\"{2}\"", OLGIBPOMNPJ, hAJEIGIFBOO.ILHGHKFHMFD.JLJICIKKCCO, hAJEIGIFBOO.KDIKHFJAJBA.JLJICIKKCCO);
		if (hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC)
		{
			if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK == hAJEIGIFBOO.KDIKHFJAJBA.HNEFOLPHMHK)
			{
				TweenBeginnerLeague.Begin(this, 1f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
				return;
			}
			MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(hAJEIGIFBOO.ILHGHKFHMFD);
			mAPGBEOOFLL.MPHCNMDIPAI = 1;
			mAPGBEOOFLL.GEIONCLKAGF = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK);
			TweenBeginnerLeague.Begin(this, 1f, hAJEIGIFBOO.ILHGHKFHMFD, mAPGBEOOFLL).onFinished = hAJEIGIFBOO.EJLGBICBIFK;
			return;
		}
		bool flag = !hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC && !hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK && !hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag2 = !hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC && !hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK && hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag3 = !hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && !hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK && !hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		bool flag4 = !hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && !hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK && hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else if (flag2 && flag4)
		{
			TweenLeague.Begin(this, 1f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.HONCMBHEKDP;
		}
		else if (flag && flag3)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else
		{
			InitializeTo(hAJEIGIFBOO.KDIKHFJAJBA);
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader) && (IFGAGNBDKBE == DatabaseAction.DebugChangeMedals || IFGAGNBDKBE == DatabaseAction.DebugChangeLeague || IFGAGNBDKBE == DatabaseAction.DebugChangeDivision))
		{
			InitGuiValues();
		}
	}

	private void IKNBCABDPKP(GameObject KHAHPAKDIKE)
	{
		if (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		}
		if (OLGIBPOMNPJ == NKHJBLBAAEB.EndScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			GuiScreenSingle<LeaguesScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	public void SetTutorialLook()
	{
		NJEAMAHEMHP.enabled = false;
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
		float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
		bool active = num > 0f;
		bool active2 = num2 > 0f;
		NNKCIKBBEOM.SetActive(value: false);
		EEFOJAJLDNO.gameObject.SetActive(value: false);
		ILCCDCHPCHK.gameObject.SetActive(value: false);
		BGAAFOAFMPN.SetActive(active);
		OAEOOEPJCOG.gameObject.SetActive(active);
		OAEOOEPJCOG.text = string.Empty;
		HMAHAHCHDPO.SetActive(active2);
		HFGPOFPHFIL.gameObject.SetActive(active2);
		HFGPOFPHFIL.text = string.Empty;
		MOALPNOJMOL.SetActive(value: true);
		NNMCKEECNFK.spriteName = GameVariables.CAOGFCFGFPD[leagueTier].Value2;
		JLJIAADCPPE(MJNAEEHPKOP[leagueTier]);
		EGKHPLONBLD.spriteName = NNMCKEECNFK.spriteName;
		HCPFFMFGNEL.gameObject.SetActive(value: true);
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GameLoginManager.currentPlayer.medalsBalance);
		EAHEJGCHDKM.transform.parent.transform.gameObject.SetActive(value: false);
		HCPFFMFGNEL.onReposition = delegate
		{
			GameObject gameObject = ((!EAHEJGCHDKM.transform.parent.transform.gameObject.activeSelf) ? JDDDDOBAFEO.transform.parent.transform.gameObject : EAHEJGCHDKM.transform.parent.transform.gameObject);
			float val = 0f - HCPFFMFGNEL.padding.x - (gameObject.transform.localPosition.x - HCPFFMFGNEL.padding.x) / 2f;
			HCPFFMFGNEL.transform.localPosition = HCPFFMFGNEL.transform.localPosition.ReplaceX(val);
		};
		HCPFFMFGNEL.repositionNow = true;
		GBFENCPMPOK(0.5f);
		HideGlow();
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
	}

	public void ShowLoading()
	{
		MAPGBEOOFLL previousData = LeagueArcManager.instance.GetPreviousData();
		JOBHIGJOCLK(previousData.BMNDININJCE, previousData.GEIONCLKAGF);
		Debug.Log("#PETER# League Arc - start ignore on " + OLGIBPOMNPJ);
		FACGNLAGCBL = true;
	}

	private float JADEEBNFGHK(float ALKFOOHCHJF)
	{
		if (ALKFOOHCHJF <= 118f)
		{
			float num = Mathf.Clamp(105f - ALKFOOHCHJF, 1777f, 868f);
			return 1278f * (num / 1890f);
		}
		if (ALKFOOHCHJF >= 336f)
		{
			float num2 = Mathf.Clamp(ALKFOOHCHJF - 859f, 1168f, 577f);
			return 898f * (num2 / 578f);
		}
		return 1748f;
	}

	private void CJLBGJGJGHP()
	{
		Debug.Log("SetCanRegenerateRPC" + OLGIBPOMNPJ);
		FACGNLAGCBL = false;
	}

	public void StopAnimations()
	{
		TweenBeginnerLeague component = base.gameObject.GetComponent<TweenBeginnerLeague>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenLeague component2 = base.gameObject.GetComponent<TweenLeague>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
	}

	private void PLILKFFIFBO(int HNEFOLPHMHK, int GEIONCLKAGF, int MPHCNMDIPAI)
	{
		NJEAMAHEMHP.enabled = true;
		int fFHHEHHFOKJ = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(HNEFOLPHMHK);
		HCPFFMFGNEL.gameObject.SetActive(value: true);
		JDDDDOBAFEO.text = MEJMLNDFDBP.GMIPFLIEOHD(GEIONCLKAGF);
		EAHEJGCHDKM.transform.parent.transform.gameObject.SetActive(value: true);
		EAHEJGCHDKM.text = $"/ {Colours.stringBlue}{MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ)}";
		HCPFFMFGNEL.repositionNow = true;
		EEFOJAJLDNO.gameObject.SetActive(value: true);
		ILCCDCHPCHK.gameObject.SetActive(value: true);
		SetBeginnersPosition(MPHCNMDIPAI);
		HideGlow();
		MOALPNOJMOL.SetActive(value: true);
		NNMCKEECNFK.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(HNEFOLPHMHK);
		JLJIAADCPPE(Colours.rookieBgLeague);
		EGKHPLONBLD.spriteName = NNMCKEECNFK.spriteName;
		BGAAFOAFMPN.SetActive(value: false);
		OAEOOEPJCOG.gameObject.SetActive(value: false);
		HMAHAHCHDPO.SetActive(value: false);
		HFGPOFPHFIL.gameObject.SetActive(value: false);
		FMIJAIDDJGK.SetActive(value: false);
		ACHBPKNJMPP.SetActive(value: false);
		NNKCIKBBEOM.SetActive(value: false);
		MDAFFKPPCBG.SetActive(value: false);
	}

	public void HideGlow()
	{
		if (CAAINGOCKOL != null)
		{
			CAAINGOCKOL.gameObject.SetActive(value: false);
		}
		if (MCFJILHJJEE != null)
		{
			MCFJILHJJEE.gameObject.SetActive(value: false);
		}
	}

	public void CAHKIJAEOIK()
	{
		MAPGBEOOFLL previousData = LeagueArcManager.instance.GetPreviousData();
		JOBHIGJOCLK(previousData.BMNDININJCE, previousData.GEIONCLKAGF);
		Debug.Log("FacebookId" + OLGIBPOMNPJ);
		FACGNLAGCBL = true;
	}

	private void JBEGIMNADJK()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen && LevelManager.instance.isMainScreenPartsLocked)
		{
			InitGuiValues();
		}
	}

	private void CJKKCJFEGOG()
	{
		Debug.Log("ID_FINALHITBY" + OLGIBPOMNPJ);
		FACGNLAGCBL = true;
	}

	public void EDNPIOIBFOJ(int CJLGKBLPDHI, int BBBEPJKPOBE, League LFEHIJBBOGC, bool AJNINHIKAFC = false)
	{
		bool flag = false;
		bool flag2 = true;
		if (BBBEPJKPOBE > (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward5).FLOATVALUE)
		{
			bool flag3 = Singleton<GameVariables>.instance.LeagueGoDownPercent(LFEHIJBBOGC) > 1898f;
			bool flag4 = Singleton<GameVariables>.instance.LeagueGoUpPercent(LFEHIJBBOGC) > 1825f;
			int num = Singleton<GameVariables>.instance.PPANNMMAIPH(BBBEPJKPOBE, LFEHIJBBOGC);
			int num2 = Singleton<GameVariables>.instance.ILBMNKFEOCL(BBBEPJKPOBE, LFEHIJBBOGC);
			flag = !flag4 || CJLGKBLPDHI > num;
			flag2 = !flag3 || CJLGKBLPDHI >= num2;
		}
		if (AJNINHIKAFC)
		{
			if (flag && !CAAINGOCKOL.gameObject.activeSelf)
			{
				CAAINGOCKOL.gameObject.SetActive(value: true);
				TweenAlpha.Begin(CAAINGOCKOL.gameObject, 1843f, 638f, 918f).onFinished = null;
			}
			if (!flag && CAAINGOCKOL.gameObject.activeSelf && CAAINGOCKOL.alpha == 1196f)
			{
				TweenAlpha.Begin(CAAINGOCKOL.gameObject, 1558f, 1678f, 1771f).onFinished = delegate
				{
					CAAINGOCKOL.gameObject.SetActive(value: false);
				};
			}
			if (flag2 && !MCFJILHJJEE.gameObject.activeSelf)
			{
				MCFJILHJJEE.gameObject.SetActive(value: true);
				TweenAlpha.Begin(MCFJILHJJEE.gameObject, 1722f, 337f, 1133f).onFinished = null;
			}
			if (!flag2 && MCFJILHJJEE.gameObject.activeSelf && MCFJILHJJEE.alpha == 687f)
			{
				TweenAlpha.Begin(MCFJILHJJEE.gameObject, 1549f, 1411f, 1176f).onFinished = delegate
				{
					MCFJILHJJEE.gameObject.SetActive(value: false);
				};
			}
		}
		else
		{
			CAAINGOCKOL.gameObject.SetActive(flag);
			MCFJILHJJEE.gameObject.SetActive(flag2);
			CAAINGOCKOL.alpha = 481f;
			MCFJILHJJEE.alpha = 1117f;
			TweenAlpha component = CAAINGOCKOL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			component = MCFJILHJJEE.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
		}
	}

	private void PNOOCAPMLBK()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !FACGNLAGCBL && (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen || OLGIBPOMNPJ == NKHJBLBAAEB.MenuHeader))
		{
			InitGuiValues();
		}
	}

	private void CJDAFNEFNFI()
	{
		GameObject gameObject = ((!EAHEJGCHDKM.transform.parent.transform.gameObject.activeSelf) ? JDDDDOBAFEO.transform.parent.transform.gameObject : EAHEJGCHDKM.transform.parent.transform.gameObject);
		float val = 0f - HCPFFMFGNEL.padding.x - (gameObject.transform.localPosition.x - HCPFFMFGNEL.padding.x) / 565f;
		HCPFFMFGNEL.transform.localPosition = HCPFFMFGNEL.transform.localPosition.ReplaceX(val);
	}

	private float HPHBDEGPKNM(float ALKFOOHCHJF)
	{
		if (ALKFOOHCHJF <= -81f)
		{
			float num = Mathf.Clamp(-81f - ALKFOOHCHJF, 0f, 9f);
			return 31f * (num / 9f);
		}
		if (ALKFOOHCHJF >= 81f)
		{
			float num2 = Mathf.Clamp(ALKFOOHCHJF - 81f, 0f, 9f);
			return -31f * (num2 / 9f);
		}
		return 0f;
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		LeagueArcManager.instance.ShowLoading += OKOGGMKBLIH;
		LeagueArcManager.instance.LeagueArcUpdate += NIMJKINAEDK;
		LeagueArcManager.instance.StopIgnore += MPOEFIODDCC;
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.BHLILOLJHMK = (Action)Delegate.Combine(instance.BHLILOLJHMK, new Action(PNOOCAPMLBK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void MFJEMLINCBG(GameObject KHAHPAKDIKE)
	{
		if (OLGIBPOMNPJ == NKHJBLBAAEB.MainScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.EDDDGIGLJJL();
		}
		if (OLGIBPOMNPJ == (NKHJBLBAAEB)5)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			GuiScreenSingle<LeaguesScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
		}
	}

	public void EJIJEFHEAEF(MAPGBEOOFLL ILHGHKFHMFD, MAPGBEOOFLL KDIKHFJAJBA)
	{
		HAJEIGIFBOO hAJEIGIFBOO = new HAJEIGIFBOO();
		hAJEIGIFBOO.KDIKHFJAJBA = KDIKHFJAJBA;
		hAJEIGIFBOO.ILHGHKFHMFD = ILHGHKFHMFD;
		hAJEIGIFBOO.BJGCPDNMHDH = this;
		object[] array = new object[4];
		array[0] = OLGIBPOMNPJ;
		array[0] = hAJEIGIFBOO.ILHGHKFHMFD.IPKDJNLPMDM();
		array[4] = hAJEIGIFBOO.KDIKHFJAJBA.JLJICIKKCCO;
		Debug.LogFormat("S", array);
		if (hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC)
		{
			if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK == hAJEIGIFBOO.KDIKHFJAJBA.HNEFOLPHMHK)
			{
				TweenBeginnerLeague.HNEAGHHABGL(this, 1226f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.LJCDGJKCNEC;
				return;
			}
			MAPGBEOOFLL mAPGBEOOFLL = new MAPGBEOOFLL(hAJEIGIFBOO.ILHGHKFHMFD);
			mAPGBEOOFLL.MPHCNMDIPAI = 1;
			mAPGBEOOFLL.GEIONCLKAGF = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(hAJEIGIFBOO.ILHGHKFHMFD.HNEFOLPHMHK);
			TweenBeginnerLeague.EEODMCJPDNI(this, 1120f, hAJEIGIFBOO.ILHGHKFHMFD, mAPGBEOOFLL).onFinished = hAJEIGIFBOO.PAKIJEIDOBH;
			return;
		}
		bool flag = !hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC && !hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK && hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag2 = !hAJEIGIFBOO.ILHGHKFHMFD.DHPLNAIKHOC && !hAJEIGIFBOO.ILHGHKFHMFD.ALNDDBGGBNK && hAJEIGIFBOO.ILHGHKFHMFD.GKEOILLNCHG;
		bool flag3 = hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC || hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK || !hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		bool flag4 = !hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC && !hAJEIGIFBOO.KDIKHFJAJBA.ALNDDBGGBNK && hAJEIGIFBOO.KDIKHFJAJBA.GKEOILLNCHG;
		if (hAJEIGIFBOO.KDIKHFJAJBA.DHPLNAIKHOC)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else if (flag2 && flag4)
		{
			TweenLeague.KKIGNHJHLGD(this, 1705f, hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA).onFinished = hAJEIGIFBOO.OGIFCPNDIKC;
		}
		else if (flag && flag3)
		{
			ELOGKADAOGE(hAJEIGIFBOO.ILHGHKFHMFD, hAJEIGIFBOO.KDIKHFJAJBA);
		}
		else
		{
			InitializeTo(hAJEIGIFBOO.KDIKHFJAJBA);
		}
	}
}
