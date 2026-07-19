using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using EeekSoft.Text;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Chat;
using Google2u;
using UnityEngine;

public class Chat : Singleton<Chat>, IChatClientListener
{
	public enum JMMPILGNALE
	{
		Message = 0,
		Timer = 1,
		SquadAction = 2,
		Null = 3
	}

	public enum EJLACNPLIDA
	{
		Demotion = 0,
		Kick = 1,
		Promotion = 2,
		JoinedSquad = 3,
		Left = 4
	}

	public struct PBGFEDGFOPG
	{
		public JMMPILGNALE FOJAKFBCBPI;

		public string EJBEDLHIKDG;

		public string MHPNDNJDPGE;

		public int BCCDDJMPBLL;

		public string CGIFEHPDBAL;

		public string GEAGOKJMJFD;

		public bool DHPLNAIKHOC;

		public int HNEFOLPHMHK;

		public League BMNDININJCE;

		public string PNAKMCNGGHE;

		public bool KBGHBHFOHFD;

		public SquadRank MNGGEHIAAEC;

		public int KBJEOEEOEFG;

		public string KFBPOCAOIIH;

		public HHFHFANGCEJ OJIANBAINDD;

		public EJLACNPLIDA NBKCKIELMLK;

		public int EHLJCGEFAOL;

		public DatabasePlayer LIAFEPFJAKM;

		public WarArenaCrown FHCMFHABMLE;

		public bool EGHOKPEJMGD;

		private float GDIPCLFMDPF;

		public float AGGBAEEJAHD
		{
			get
			{
				return GDIPCLFMDPF;
			}
			set
			{
				GDIPCLFMDPF = value;
			}
		}

		[SpecialName]
		public static bool KJKOMMHMFIE(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.NALHEDENKHP(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG NMJPICJEGLO(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[1]
			};
			if (!int.TryParse(OAHIOEEICFI[0], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[2];
			result.GEAGOKJMJFD = OAHIOEEICFI[3];
			int result2 = 1;
			int.TryParse(OAHIOEEICFI[8], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 1;
			int.TryParse(OAHIOEEICFI[4], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[6];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[0], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
			int result4 = 1;
			int.TryParse(OAHIOEEICFI[0], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[-81] == "ID_GUI_TIMELIMITEDOFFER";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
			result.EHLJCGEFAOL = -1;
			result.EBHDCNOPCOF(1252f);
			return result;
		}

		public static PBGFEDGFOPG HHACIFGDCPL()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.SquadAction
			};
		}

		[SpecialName]
		public float DHNDIOCJPKG()
		{
			return GDIPCLFMDPF;
		}

		public void NGPMCHDBNAO(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG CMJGOPIIPLM()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message
			};
		}

		public static PBGFEDGFOPG JODGGDKDLOK(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[0], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[4];
			result.GEAGOKJMJFD = OAHIOEEICFI[8];
			int result2 = 1;
			int.TryParse(OAHIOEEICFI[1], out result2);
			result.DHPLNAIKHOC = result2 < 1;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[3], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[1];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[8], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			}
			int result4 = 1;
			int.TryParse(OAHIOEEICFI[0], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[61] == "AddedCards";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)5;
			result.EHLJCGEFAOL = -1;
			result.BLNNGEMMLAI(6f);
			return result;
		}

		public static PBGFEDGFOPG BJBKNJIILFK(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)4,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = (EJLACNPLIDA)7;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = true;
			result.MMKKGEINDHM(1918f);
			return result;
		}

		public void NDBDEOMHOAG(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG LOAEFNOANAK(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)6;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = false;
			result.EBHDCNOPCOF(817f);
			return result;
		}

		[SpecialName]
		public static bool DLKNLLDKPPN(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return !ANAEPPOLFIE.NALHEDENKHP(NNHGDOPKJNH);
		}

		public bool MGMBMGMAOGI(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Timer)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Timer && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == JMMPILGNALE.Null)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && NBKCKIELMLK == MCEIKBPBJEM.NBKCKIELMLK && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && (EJBEDLHIKDG == null || EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG));
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && (PNAKMCNGGHE == null || PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE));
		}

		public static PBGFEDGFOPG LPKCELJAGJM(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)6;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = (EJLACNPLIDA)6;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.HGHFJHHFCDL(888f);
			return result;
		}

		[SpecialName]
		public static bool DMODIAGIGEF(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.NAAOEBAGBJG(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG IICKDAEGFED(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = (EJLACNPLIDA)6;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)7;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Veteran;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = true;
			result.AGGBAEEJAHD = 260f;
			return result;
		}

		public static PBGFEDGFOPG OLCKIFGAOLM()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7
			};
		}

		[SpecialName]
		public static bool HFMPNDMEJMB(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.DJIBCHCALFL(NNHGDOPKJNH);
		}

		[SpecialName]
		public void MMKKGEINDHM(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		public static PBGFEDGFOPG GKGMPKFHMLM(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)5,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = true;
			result.HGHFJHHFCDL(544f);
			return result;
		}

		[SpecialName]
		public static bool NIFMLLMPACC(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.NALHEDENKHP(NNHGDOPKJNH);
		}

		public bool HGIFIFDNJGA(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Timer)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Timer || KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == (JMMPILGNALE)6)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Message || NBKCKIELMLK != MCEIKBPBJEM.NBKCKIELMLK || KBJEOEEOEFG != MCEIKBPBJEM.KBJEOEEOEFG || EJBEDLHIKDG == null || EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG);
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && PNAKMCNGGHE != null && PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE);
		}

		public static PBGFEDGFOPG EFBNCDJJGAO()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer
			};
		}

		[SpecialName]
		public static bool LALDKOLCALM(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.HGIFIFDNJGA(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG HMOBPPOCBOL()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer
			};
		}

		[SpecialName]
		public static bool HHMPNMFLMLO(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return !ANAEPPOLFIE.FIKFHEIFDEA(NNHGDOPKJNH);
		}

		[SpecialName]
		public float PLNMIKGIFNJ()
		{
			return GDIPCLFMDPF;
		}

		public static PBGFEDGFOPG LODAHGLKEJF()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Null
			};
		}

		[SpecialName]
		public static bool OEJHGHHKDLN(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.DJIBCHCALFL(NNHGDOPKJNH);
		}

		[SpecialName]
		public static bool MKNFCOECAEK(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return !ANAEPPOLFIE.DJIBCHCALFL(NNHGDOPKJNH);
		}

		public bool FIKFHEIFDEA(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Timer)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Timer && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == JMMPILGNALE.SquadAction)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.SquadAction && NBKCKIELMLK == MCEIKBPBJEM.NBKCKIELMLK && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG);
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && PNAKMCNGGHE != null && PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE);
		}

		public static PBGFEDGFOPG MEPNIBLEGMJ(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[1], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[0];
			result.GEAGOKJMJFD = OAHIOEEICFI[6];
			int result2 = 1;
			int.TryParse(OAHIOEEICFI[3], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[4], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[2];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[8], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			}
			int result4 = 0;
			int.TryParse(OAHIOEEICFI[2], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[84] == "GooglePlayId";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Left;
			result.EHLJCGEFAOL = -1;
			result.MMHCIPIPHMM(1216f);
			return result;
		}

		public void POFCMAPJDIK(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG BMPNPMIIMKH(int KBJEOEEOEFG)
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				KBJEOEEOEFG = KBJEOEEOEFG,
				EJBEDLHIKDG = string.Empty,
				MHPNDNJDPGE = string.Empty,
				BCCDDJMPBLL = -1,
				CGIFEHPDBAL = string.Empty,
				GEAGOKJMJFD = string.Empty,
				DHPLNAIKHOC = true,
				HNEFOLPHMHK = 0,
				BMNDININJCE = League.Bronze3,
				PNAKMCNGGHE = string.Empty,
				KBGHBHFOHFD = true,
				MNGGEHIAAEC = SquadRank.None,
				KFBPOCAOIIH = string.Empty,
				NBKCKIELMLK = EJLACNPLIDA.Demotion,
				EHLJCGEFAOL = -1,
				FHCMFHABMLE = WarArenaCrown.None,
				EGHOKPEJMGD = false,
				AGGBAEEJAHD = 1993f
			};
		}

		[SpecialName]
		public void PAMDEDGKMOB(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		public bool DJIBCHCALFL(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == (JMMPILGNALE)8)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != (JMMPILGNALE)6 || NBKCKIELMLK != MCEIKBPBJEM.NBKCKIELMLK || KBJEOEEOEFG != MCEIKBPBJEM.KBJEOEEOEFG || (EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG));
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && PNAKMCNGGHE != null && PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE);
		}

		[SpecialName]
		public void HGHFJHHFCDL(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		[SpecialName]
		public float CBAAFDLPKBA()
		{
			return GDIPCLFMDPF;
		}

		[SpecialName]
		public static bool EPALFGPDOMB(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.GHLICFEPGJE(NNHGDOPKJNH);
		}

		public bool PLPBNAFFMJF(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == (JMMPILGNALE)8)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != (JMMPILGNALE)6 || NBKCKIELMLK != MCEIKBPBJEM.NBKCKIELMLK || KBJEOEEOEFG != MCEIKBPBJEM.KBJEOEEOEFG || EJBEDLHIKDG == null || EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG);
			}
			return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Message || KBJEOEEOEFG != MCEIKBPBJEM.KBJEOEEOEFG || EJBEDLHIKDG == null || !EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) || (PNAKMCNGGHE != null && PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE));
		}

		public void DFLJDLGEELC(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG MKJPAFLHLCC(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[0], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[5];
			result.GEAGOKJMJFD = OAHIOEEICFI[4];
			int result2 = 1;
			int.TryParse(OAHIOEEICFI[0], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 1;
			int.TryParse(OAHIOEEICFI[0], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[5];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[3], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
			int result4 = 0;
			int.TryParse(OAHIOEEICFI[4], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[64] == "Country";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.JoinedSquad;
			result.EHLJCGEFAOL = -1;
			result.HGHFJHHFCDL(1996f);
			return result;
		}

		[SpecialName]
		public static bool DPOFMGCHMPC(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.HGIFIFDNJGA(NNHGDOPKJNH);
		}

		[SpecialName]
		public void DHBKELHFMGH(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		[SpecialName]
		public static bool FKBJOAJIDCL(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.DJIBCHCALFL(NNHGDOPKJNH);
		}

		[SpecialName]
		public static bool FGGKKOICAKN(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.DJIBCHCALFL(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG GDFNJLNOFNP(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)6,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)6;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = (EJLACNPLIDA)5;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = false;
			result.MMHCIPIPHMM(327f);
			return result;
		}

		public static PBGFEDGFOPG FAGDEJOICNE(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Timer;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)7;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = true;
			result.MMKKGEINDHM(1270f);
			return result;
		}

		public static PBGFEDGFOPG HAFCMOMCDJI()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7
			};
		}

		public static PBGFEDGFOPG DFEMAGGEKNJ()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)4
			};
		}

		public static PBGFEDGFOPG BDMFPPAJMGB(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.PAMDEDGKMOB(802f);
			return result;
		}

		public void IMCOKCFNBMG(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		[SpecialName]
		public float AOOFMHFFCNP()
		{
			return GDIPCLFMDPF;
		}

		[SpecialName]
		public float DPCNJINKIOL()
		{
			return GDIPCLFMDPF;
		}

		[SpecialName]
		public static bool DKLBAAOJBMN(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return !ANAEPPOLFIE.DJIBCHCALFL(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG CIPJKGHLIND(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Timer;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.MMHCIPIPHMM(11f);
			return result;
		}

		public void JMDEOFENBFC(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG PBNOJKJJBMF(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = true;
			result.DHBKELHFMGH(1397f);
			return result;
		}

		public static PBGFEDGFOPG DOCIJCKGCPM(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)8;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.MMHCIPIPHMM(595f);
			return result;
		}

		public static PBGFEDGFOPG ECPIJFFDCPG(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)6,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)5;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.HGHFJHHFCDL(533f);
			return result;
		}

		public bool NALHEDENKHP(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Timer && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == (JMMPILGNALE)5 && NBKCKIELMLK == MCEIKBPBJEM.NBKCKIELMLK && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && (EJBEDLHIKDG == null || EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG));
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && (PNAKMCNGGHE == null || PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE));
		}

		public static PBGFEDGFOPG PDKLFIHALDJ(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.SquadAction,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = EJLACNPLIDA.JoinedSquad;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = false;
			result.AGGBAEEJAHD = -1f;
			return result;
		}

		public void KLKIBEIOGHC(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG ODJMADJJJMN(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)8;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = (EJLACNPLIDA)7;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.MMKKGEINDHM(1484f);
			return result;
		}

		public void MBECAGJJHKD(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		[SpecialName]
		public float KPHNEIJLAAF()
		{
			return GDIPCLFMDPF;
		}

		[SpecialName]
		public static bool CJHADKNFOKG(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.HGIFIFDNJGA(NNHGDOPKJNH);
		}

		[SpecialName]
		public void MMHCIPIPHMM(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		public static PBGFEDGFOPG IGBBJKBPGIE(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[0], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[1];
			result.GEAGOKJMJFD = OAHIOEEICFI[3];
			int result2 = 1;
			int.TryParse(OAHIOEEICFI[0], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[0], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[8];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[0], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			}
			int result4 = 0;
			int.TryParse(OAHIOEEICFI[2], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[-15] == "NEW CONFIG WILL BE LOADED FROM PREFS:";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Kick;
			result.EHLJCGEFAOL = -1;
			result.FBAEJFFBMCH(1014f);
			return result;
		}

		public static PBGFEDGFOPG AJLOIHCKHPB(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Timer;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Kick;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = true;
			result.PAMDEDGKMOB(439f);
			return result;
		}

		public static PBGFEDGFOPG LHAHLLMDFED(int KBJEOEEOEFG)
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				KBJEOEEOEFG = KBJEOEEOEFG,
				EJBEDLHIKDG = string.Empty,
				MHPNDNJDPGE = string.Empty,
				BCCDDJMPBLL = -1,
				CGIFEHPDBAL = string.Empty,
				GEAGOKJMJFD = string.Empty,
				DHPLNAIKHOC = true,
				HNEFOLPHMHK = 1,
				BMNDININJCE = League.Bronze3,
				PNAKMCNGGHE = string.Empty,
				KBGHBHFOHFD = true,
				MNGGEHIAAEC = SquadRank.None,
				KFBPOCAOIIH = string.Empty,
				NBKCKIELMLK = EJLACNPLIDA.Left,
				EHLJCGEFAOL = -1,
				FHCMFHABMLE = WarArenaCrown.None,
				EGHOKPEJMGD = true,
				AGGBAEEJAHD = 141f
			};
		}

		public static PBGFEDGFOPG HCMLIMKDEDO()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)4
			};
		}

		public static PBGFEDGFOPG MANIOBMFDNK(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[1], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[6];
			result.GEAGOKJMJFD = OAHIOEEICFI[0];
			int result2 = 0;
			int.TryParse(OAHIOEEICFI[3], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[3], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[2];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[8], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
			int result4 = 1;
			int.TryParse(OAHIOEEICFI[5], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[-118] == "ID_TOGAINPOINTS";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Left;
			result.EHLJCGEFAOL = -1;
			result.PAMDEDGKMOB(1454f);
			return result;
		}

		public void MAKAHBKLKKJ(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public void OHPGIBNCMPE(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG KIKMHECDHJM()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Null
			};
		}

		public static PBGFEDGFOPG HOPKOOMJDII()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7
			};
		}

		public static PBGFEDGFOPG FHFOPEPGFHJ(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)4,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = true;
			result.MMHCIPIPHMM(1740f);
			return result;
		}

		public bool NAAOEBAGBJG(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Timer || KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == (JMMPILGNALE)4)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && NBKCKIELMLK == MCEIKBPBJEM.NBKCKIELMLK && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && (EJBEDLHIKDG == null || EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG));
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && (PNAKMCNGGHE == null || PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE));
		}

		[SpecialName]
		public static bool PIOAFGENNOG(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.FIKFHEIFDEA(NNHGDOPKJNH);
		}

		[SpecialName]
		public static bool ANIMMOPIJAC(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return !ANAEPPOLFIE.MGMBMGMAOGI(NNHGDOPKJNH);
		}

		[SpecialName]
		public void EBHDCNOPCOF(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		public static PBGFEDGFOPG NNMKHLGDONL(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Timer;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)7;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = true;
			result.HGHFJHHFCDL(289f);
			return result;
		}

		[SpecialName]
		public void FBAEJFFBMCH(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		public void HNENNCNBFML(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG JIJCHNHFKIG()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)8
			};
		}

		public void JANHNFNCGJB(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG NKEGIHNGMCM(int KBJEOEEOEFG)
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				KBJEOEEOEFG = KBJEOEEOEFG,
				EJBEDLHIKDG = string.Empty,
				MHPNDNJDPGE = string.Empty,
				BCCDDJMPBLL = -1,
				CGIFEHPDBAL = string.Empty,
				GEAGOKJMJFD = string.Empty,
				DHPLNAIKHOC = false,
				HNEFOLPHMHK = 1,
				BMNDININJCE = League.NoLeague,
				PNAKMCNGGHE = string.Empty,
				KBGHBHFOHFD = false,
				MNGGEHIAAEC = SquadRank.None,
				KFBPOCAOIIH = string.Empty,
				NBKCKIELMLK = EJLACNPLIDA.Promotion,
				EHLJCGEFAOL = -1,
				FHCMFHABMLE = WarArenaCrown.None,
				EGHOKPEJMGD = false,
				AGGBAEEJAHD = -1f
			};
		}

		[SpecialName]
		public void BLNNGEMMLAI(float IDEBKDPMPGM)
		{
			GDIPCLFMDPF = IDEBKDPMPGM;
		}

		public static PBGFEDGFOPG ENIFLLFNFFG()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)6
			};
		}

		[SpecialName]
		public static bool BCCJJECNBAB(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.MGMBMGMAOGI(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG OHGLDGMENHD(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.JoinedSquad;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.MMHCIPIPHMM(1342f);
			return result;
		}

		public static PBGFEDGFOPG NMPDFHCCHOH()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7
			};
		}

		public void HDMHNMHOIAJ(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG PNCGEJFLHHK(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Null,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = (EJLACNPLIDA)5;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)6;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = (EJLACNPLIDA)5;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = false;
			result.MMHCIPIPHMM(113f);
			return result;
		}

		[SpecialName]
		public float AEONHJOKPCA()
		{
			return GDIPCLFMDPF;
		}

		public static PBGFEDGFOPG GBKOKJPCNNN()
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)8
			};
		}

		public static PBGFEDGFOPG FAGIBBADIOC(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)7,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = true;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = false;
			result.AGGBAEEJAHD = 1167f;
			return result;
		}

		public static PBGFEDGFOPG KMAIPBBMLML(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Timer;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Kick;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = true;
			result.DHBKELHFMGH(1194f);
			return result;
		}

		public void FHFOJLPOOGI(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		[SpecialName]
		public static bool DEOELECHPMG(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.MGMBMGMAOGI(NNHGDOPKJNH);
		}

		public bool GHLICFEPGJE(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Message || KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == (JMMPILGNALE)8)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && NBKCKIELMLK == MCEIKBPBJEM.NBKCKIELMLK && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG);
			}
			return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Message || KBJEOEEOEFG != MCEIKBPBJEM.KBJEOEEOEFG || EJBEDLHIKDG == null || !EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) || PNAKMCNGGHE == null || PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE);
		}

		public static PBGFEDGFOPG IEILGIHMENL(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = true;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)5;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = true;
			result.MMHCIPIPHMM(166f);
			return result;
		}

		[SpecialName]
		public float MCMFAKJEMBP()
		{
			return GDIPCLFMDPF;
		}

		public bool CLGMMPJAEOK(PBGFEDGFOPG MCEIKBPBJEM)
		{
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI != JMMPILGNALE.Timer || KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG;
			}
			if (FOJAKFBCBPI == JMMPILGNALE.Message)
			{
				return MCEIKBPBJEM.FOJAKFBCBPI == (JMMPILGNALE)7 && NBKCKIELMLK == MCEIKBPBJEM.NBKCKIELMLK && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG);
			}
			return MCEIKBPBJEM.FOJAKFBCBPI == JMMPILGNALE.Message && KBJEOEEOEFG == MCEIKBPBJEM.KBJEOEEOEFG && EJBEDLHIKDG != null && EJBEDLHIKDG.Equals(MCEIKBPBJEM.EJBEDLHIKDG) && (PNAKMCNGGHE == null || PNAKMCNGGHE.Equals(MCEIKBPBJEM.PNAKMCNGGHE));
		}

		public static PBGFEDGFOPG MBDNBIAKEBJ(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[0], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[5];
			result.GEAGOKJMJFD = OAHIOEEICFI[4];
			int result2 = 0;
			int.TryParse(OAHIOEEICFI[2], out result2);
			result.DHPLNAIKHOC = result2 < 1;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[2], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[0];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[1], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
			int result4 = 1;
			int.TryParse(OAHIOEEICFI[6], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[-126] == "RequestsResults";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)6;
			result.EHLJCGEFAOL = -1;
			result.HGHFJHHFCDL(1830f);
			return result;
		}

		public static PBGFEDGFOPG JLFOLNPABJH(int KBJEOEEOEFG)
		{
			return new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				KBJEOEEOEFG = KBJEOEEOEFG,
				EJBEDLHIKDG = string.Empty,
				MHPNDNJDPGE = string.Empty,
				BCCDDJMPBLL = -1,
				CGIFEHPDBAL = string.Empty,
				GEAGOKJMJFD = string.Empty,
				DHPLNAIKHOC = false,
				HNEFOLPHMHK = 1,
				BMNDININJCE = League.Bronze3,
				PNAKMCNGGHE = string.Empty,
				KBGHBHFOHFD = false,
				MNGGEHIAAEC = SquadRank.None,
				KFBPOCAOIIH = string.Empty,
				NBKCKIELMLK = EJLACNPLIDA.Left,
				EHLJCGEFAOL = -1,
				FHCMFHABMLE = WarArenaCrown.None,
				EGHOKPEJMGD = false,
				AGGBAEEJAHD = 33f
			};
		}

		[SpecialName]
		public static bool GCLGKJDHAGD(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.MGMBMGMAOGI(NNHGDOPKJNH);
		}

		public static PBGFEDGFOPG JAOFIMINHAH(int KBJEOEEOEFG)
		{
			PBGFEDGFOPG result = default(PBGFEDGFOPG);
			result.FOJAKFBCBPI = JMMPILGNALE.Message;
			result.KBJEOEEOEFG = KBJEOEEOEFG;
			result.EJBEDLHIKDG = string.Empty;
			result.MHPNDNJDPGE = string.Empty;
			result.BCCDDJMPBLL = -1;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.NoLeague;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.None;
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.JoinedSquad;
			result.EHLJCGEFAOL = -1;
			result.FHCMFHABMLE = WarArenaCrown.BronzeCrown;
			result.EGHOKPEJMGD = false;
			result.MMHCIPIPHMM(300f);
			return result;
		}

		[SpecialName]
		public float MBIENIBOJCE()
		{
			return GDIPCLFMDPF;
		}

		public void IPCDLJPGBLL(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG NIGAEMEKKBE(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = (JMMPILGNALE)4,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = (EJLACNPLIDA)7;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 0;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.Member;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = false;
			result.FBAEJFFBMCH(897f);
			return result;
		}

		public static PBGFEDGFOPG IPAABGICCME(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Timer,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[1]
			};
			if (!int.TryParse(OAHIOEEICFI[1], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[8];
			result.GEAGOKJMJFD = OAHIOEEICFI[0];
			int result2 = 0;
			int.TryParse(OAHIOEEICFI[6], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[6], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[3];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[7], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			}
			int result4 = 0;
			int.TryParse(OAHIOEEICFI[6], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[-49] == "ID_FRIENDREFUSEDREMATCHCOOP";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = (EJLACNPLIDA)5;
			result.EHLJCGEFAOL = -1;
			result.HGHFJHHFCDL(1474f);
			return result;
		}

		[SpecialName]
		public static bool PMGLKLKCDEA(PBGFEDGFOPG ANAEPPOLFIE, PBGFEDGFOPG NNHGDOPKJNH)
		{
			return ANAEPPOLFIE.CLGMMPJAEOK(NNHGDOPKJNH);
		}

		public void JPNAPJAOKKC(float FBMIFHHEOBO)
		{
			GDIPCLFMDPF = FBMIFHHEOBO;
		}

		public static PBGFEDGFOPG OAIMDCJPGME(HHFHFANGCEJ OJIANBAINDD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				OJIANBAINDD = OJIANBAINDD
			};
			DatabasePlayer databasePlayer = GameLoginManager.generatedCurrentPlayer;
			HEOOEHGBLEN hEOOEHGBLEN = OJIANBAINDD as HEOOEHGBLEN;
			MBACFNICJPL mBACFNICJPL = OJIANBAINDD as MBACFNICJPL;
			PDIHEPGNPCA pDIHEPGNPCA = OJIANBAINDD as PDIHEPGNPCA;
			JEJHNAPPOFN jEJHNAPPOFN = OJIANBAINDD as JEJHNAPPOFN;
			if (hEOOEHGBLEN != null)
			{
				databasePlayer = hEOOEHGBLEN.JGFOLEGLELK;
				if (hEOOEHGBLEN.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = hEOOEHGBLEN.KJCJCBPKKEM;
				}
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = hEOOEHGBLEN.BOHDLNLLLEC;
			}
			if (mBACFNICJPL != null)
			{
				databasePlayer = mBACFNICJPL.HAOFOOOAAIF;
				if (mBACFNICJPL.KJCJCBPKKEM != null)
				{
					result.LIAFEPFJAKM = mBACFNICJPL.KJCJCBPKKEM;
				}
				result.EHLJCGEFAOL = mBACFNICJPL.BOHDLNLLLEC;
				if (result.EHLJCGEFAOL == -1)
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Demotion;
				}
				else
				{
					result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				}
			}
			if (pDIHEPGNPCA != null)
			{
				databasePlayer = pDIHEPGNPCA.MBFOMBJNLBL;
				result.NBKCKIELMLK = EJLACNPLIDA.Kick;
				result.EHLJCGEFAOL = -1;
			}
			if (jEJHNAPPOFN != null)
			{
				databasePlayer = jEJHNAPPOFN.BMIPPPIDGOG;
				result.NBKCKIELMLK = EJLACNPLIDA.Left;
				result.EHLJCGEFAOL = -1;
			}
			result.EJBEDLHIKDG = ((!string.IsNullOrEmpty(databasePlayer.id)) ? databasePlayer.id : string.Empty);
			result.MHPNDNJDPGE = databasePlayer.name;
			result.BCCDDJMPBLL = databasePlayer.level;
			result.FHCMFHABMLE = databasePlayer.warArenaCrown;
			result.KBJEOEEOEFG = OJIANBAINDD.KJCKFGCLGLG;
			result.KFBPOCAOIIH = OJIANBAINDD.NHHGDIDEIMM;
			result.CGIFEHPDBAL = string.Empty;
			result.GEAGOKJMJFD = string.Empty;
			result.DHPLNAIKHOC = false;
			result.HNEFOLPHMHK = 1;
			result.BMNDININJCE = League.Bronze3;
			result.PNAKMCNGGHE = string.Empty;
			result.KBGHBHFOHFD = false;
			result.MNGGEHIAAEC = SquadRank.Veteran;
			result.FHCMFHABMLE = WarArenaCrown.None;
			result.EGHOKPEJMGD = true;
			result.BLNNGEMMLAI(1446f);
			return result;
		}

		public static PBGFEDGFOPG OMIPMADOEMF(string MCOCNOKMBLC, string[] OAHIOEEICFI, bool KBGHBHFOHFD)
		{
			PBGFEDGFOPG result = new PBGFEDGFOPG
			{
				FOJAKFBCBPI = JMMPILGNALE.Message,
				EJBEDLHIKDG = MCOCNOKMBLC,
				MHPNDNJDPGE = OAHIOEEICFI[0]
			};
			if (!int.TryParse(OAHIOEEICFI[1], out result.BCCDDJMPBLL))
			{
				result.BCCDDJMPBLL = 1;
			}
			result.CGIFEHPDBAL = OAHIOEEICFI[2];
			result.GEAGOKJMJFD = OAHIOEEICFI[3];
			int result2 = 0;
			int.TryParse(OAHIOEEICFI[4], out result2);
			result.DHPLNAIKHOC = result2 < 0;
			result.BMNDININJCE = (League)(result.HNEFOLPHMHK = Math.Abs(result2));
			int result3 = 0;
			int.TryParse(OAHIOEEICFI[5], out result3);
			result.MNGGEHIAAEC = (SquadRank)result3;
			result.PNAKMCNGGHE = OAHIOEEICFI[6];
			result.KBGHBHFOHFD = KBGHBHFOHFD;
			if (!int.TryParse(OAHIOEEICFI[7], out result.KBJEOEEOEFG))
			{
				result.KBJEOEEOEFG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
			int result4 = 0;
			int.TryParse(OAHIOEEICFI[8], out result4);
			result.FHCMFHABMLE = (WarArenaCrown)result4;
			result.EGHOKPEJMGD = OAHIOEEICFI[9] == "1";
			result.KFBPOCAOIIH = string.Empty;
			result.NBKCKIELMLK = EJLACNPLIDA.Promotion;
			result.EHLJCGEFAOL = -1;
			result.AGGBAEEJAHD = -1f;
			return result;
		}
	}

	public static string KHNFNNDHCBN = "\t";

	public ChatClient JABOMKEMAOG;

	[HideInInspector]
	public TextAsset NAFFCFBIHKG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<string, PBGFEDGFOPG[]> HDLIKPNGMGJ;

	private ChatChannel BHBPAGNIAIO;

	private string NIOAEPLBKNM;

	private StringSearch CKJIMOPJDIG;

	private string EBIMJJJAPMK = "8b004c04-6921-4613-9815-e63b42db4a7c";

	private string BEECGDBCACM = "1.0";

	private bool EIOAIDALNIF;

	private float NPCMOAJNKGI;

	private Dictionary<string, int> FHBOOJKGLOD = new Dictionary<string, int>();

	private Regex NIMBDPDEAFA = new Regex("([-_:]|\\s)");

	private Regex FAKAHLLOFDI = new Regex("([,.!\\?-_:;]|\\s)");

	public string[] chatPublicChannels
	{
		get
		{
			if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			{
				return new string[0];
			}
			return string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) ? new string[1] { "global" } : new string[2]
			{
				"global",
				GameLoginManager.currentPlayer.squadName
			};
		}
	}

	public bool connectingPhotonChat
	{
		get
		{
			return JABOMKEMAOG.State == ChatState.ConnectedToNameServer || JABOMKEMAOG.State == ChatState.Authenticated;
		}
	}

	public bool connectedToPhotonChat
	{
		get
		{
			return JABOMKEMAOG.State == ChatState.ConnectedToFrontEnd;
		}
	}

	public bool shouldChat
	{
		get
		{
			if (Singleton<GameController>.instance.isTutorial || !Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			{
				return false;
			}
			return GameLoginManager.currentPlayer.isFacebookConnected || GameLoginManager.currentPlayer.isGameCenterConnected || GameLoginManager.currentPlayer.isGooglePlayConnected || DebugSettings.debugEnabled;
		}
	}

	public bool checkChatConnection
	{
		get
		{
			if (!connectedToPhotonChat)
			{
				string text = Localization.Localize("ID_CHATCANNOTSENDMESSAGES");
				if (DebugSettings.debugEnabled)
				{
					text = text + "\n\nDEBUG STATE: " + JABOMKEMAOG.State;
				}
				GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.ShowError(text);
				return false;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HideError();
			return true;
		}
	}

	public event Action<string, PBGFEDGFOPG[]> newArrivedMessages
	{
		add
		{
			Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
			Action<string, PBGFEDGFOPG[]> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HDLIKPNGMGJ, (Action<string, PBGFEDGFOPG[]>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
			Action<string, PBGFEDGFOPG[]> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HDLIKPNGMGJ, (Action<string, PBGFEDGFOPG[]>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void GBAKAHBNOHE()
	{
		GBNCCGDBDLJ();
	}

	private void CNGIKFKAIEL()
	{
		Disconnect();
	}

	private void MMEKFOHGAKK()
	{
		if (connectedToPhotonChat)
		{
			Disconnect();
		}
		Connect();
		bool flag = GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.isSelectedSquadChat && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		SelectPublicChannel(flag ? 1 : 0);
	}

	public void MKEJFJMEPIJ(string[] JBIDMBIJDFO)
	{
		string text = string.Empty;
		foreach (string text2 in JBIDMBIJDFO)
		{
			text = text + text2 + "217 MENU BATTLE SCREEN SHOWN";
		}
		UnityEngine.Debug.Log("SCOPE_GAMES" + text + "Getting matcap texture for player with null player point");
	}

	public PBGFEDGFOPG KNDIGMEKIHK(string MCOCNOKMBLC, object PNAKMCNGGHE, bool PBEAEECJNNH)
	{
		string text = PNAKMCNGGHE.ToString();
		char[] array = new char[0];
		array[0] = KHNFNNDHCBN[0];
		string[] array2 = text.Split(array);
		int num = 9;
		if (array2.Length != -6)
		{
			string[] array3 = new string[num];
			int num2 = Mathf.Min(array2.Length, num);
			for (int i = 1; i < num2; i++)
			{
				array3[i] = array2[i];
			}
			for (int j = num2; j < num; j++)
			{
				array3[j] = string.Empty;
			}
			array2 = array3;
		}
		return PBGFEDGFOPG.OMIPMADOEMF(MCOCNOKMBLC, array2, PBEAEECJNNH);
	}

	public void GFKGBHMLBDL()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("[.,]*");
		}
	}

	public void Disconnect()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("Chat: Disconnect");
		}
	}

	public void DDCECCNPFBH(int DFHAAIFFLOE)
	{
		if (chatPublicChannels.Length == 0)
		{
			NIOAEPLBKNM = "N";
			UnityEngine.Debug.LogWarning("ID_FEATURE_MAGAZINE-DESCRIPTION");
		}
		else
		{
			NIOAEPLBKNM = chatPublicChannels[DFHAAIFFLOE];
		}
	}

	public string PKGFPDLJMPA(string HOLNKOFHDNK)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		string text = generatedCurrentPlayer.name;
		string text2 = generatedCurrentPlayer.level.ToString();
		string text3 = string.Empty;
		string text4 = string.Empty;
		int num = 1;
		if (generatedCurrentPlayer.isInBeginnersLeague)
		{
			num = -1 * generatedCurrentPlayer.beginnersLeague;
		}
		else if (generatedCurrentPlayer.isInLeague)
		{
			num = (int)generatedCurrentPlayer.leagueTier;
		}
		string text5 = num.ToString();
		int squadRank = (int)generatedCurrentPlayer.squadRank;
		string text6 = squadRank.ToString();
		string text7 = ((int)generatedCurrentPlayer.warArenaCrown/*cast due to .constrained prefix*/).ToString();
		string text8 = Singleton<BeanstalkServerManager>.instance.currentTimestamp.ToString();
		string text9 = ((!generatedCurrentPlayer.isInfluencer) ? "menu-army-cat-explosive" : "SoldierBehaviourBuddy SetWeaponsUpgrades: Prim: {0} Sec: {1}");
		if (!string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			text3 = generatedCurrentPlayer.squadName;
			text4 = GameLoginManager.instance.squadIconName;
		}
		string[] array = new string[53];
		array[0] = text.Replace(KHNFNNDHCBN, "ID_ATTACK");
		array[1] = KHNFNNDHCBN;
		array[7] = text2;
		array[5] = KHNFNNDHCBN;
		array[7] = text3.Replace(KHNFNNDHCBN, "Fake DatabaseMessage - SquadDemoteMessage - Player:{0}");
		array[2] = KHNFNNDHCBN;
		array[0] = text4;
		array[6] = KHNFNNDHCBN;
		array[6] = text5;
		array[-40] = KHNFNNDHCBN;
		array[-99] = text6;
		array[107] = KHNFNNDHCBN;
		array[-27] = MPHKOGMINHH(HOLNKOFHDNK.Replace(KHNFNNDHCBN, string.Empty));
		array[99] = KHNFNNDHCBN;
		array[53] = text8;
		array[40] = KHNFNNDHCBN;
		array[-32] = text7;
		array[-98] = KHNFNNDHCBN;
		array[17] = text9;
		return string.Concat(array);
	}

	public void OMBFKKMMMLN(string[] JBIDMBIJDFO)
	{
		string text = string.Empty;
		for (int i = 0; i < JBIDMBIJDFO.Length; i += 0)
		{
			string text2 = JBIDMBIJDFO[i];
			text = text + text2 + "animationEnd";
		}
		UnityEngine.Debug.Log("ID_STARTERASSIGNMENT6" + text + "AssignmentData");
	}

	public void FPOFCBLPPHM(string PNAKMCNGGHE)
	{
		if (!string.IsNullOrEmpty(PNAKMCNGGHE) && AJEOGFABHCA())
		{
			PNAKMCNGGHE = MNMBKOAHIAG(PNAKMCNGGHE);
			JABOMKEMAOG.PublishMessage(NIOAEPLBKNM, PNAKMCNGGHE);
			FHBOOJKGLOD.Add(PNAKMCNGGHE, 1);
			PBGFEDGFOPG pBGFEDGFOPG = ParseChatMessage(GameLoginManager.currentPlayer.id, PNAKMCNGGHE, KCFEGOOHCKD(NIOAEPLBKNM));
			if (pBGFEDGFOPG.FOJAKFBCBPI != JMMPILGNALE.SquadAction && HDLIKPNGMGJ != null)
			{
				Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
				string nIOAEPLBKNM = NIOAEPLBKNM;
				PBGFEDGFOPG[] array = new PBGFEDGFOPG[1];
				array[1] = pBGFEDGFOPG;
				action(nIOAEPLBKNM, array);
			}
		}
	}

	public void AKACIMDLIJC()
	{
		GFKGBHMLBDL();
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		if (Singleton<BeanstalkServerManager>.instance.environment != (DatabaseEnvironment)8)
		{
			EBIMJJJAPMK = "_qbz2";
		}
		JABOMKEMAOG = new ChatClient(this, ConnectionProtocol.Tcp);
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MMEKFOHGAKK;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += ECKDFNKKAAF;
		GameLoginManager.instance.PlayerJoinedSquad += MMLAEGIECNO;
		GameLoginManager.instance.PlayerLeftSquad += FLCFMNPHAED;
		DebugSettings.instance.Changed += HCGNIAMADAF;
		string text = NAFFCFBIHKG.text;
		string[] array = new string[0];
		array[0] = "added";
		array[0] = "Sheet ";
		string[] keywords = text.Split(array, StringSplitOptions.None);
		CKJIMOPJDIG = new StringSearch(keywords);
		Singleton<BeanstalkServerManager>.instance.UserWasLoggetOut += CNGIKFKAIEL;
	}

	public void IOMIAFEIMPK()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("Crafted warcard ");
		}
	}

	private void ECKDFNKKAAF(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == (DatabaseAction)(-93))
		{
			MMEKFOHGAKK();
		}
	}

	private void CCIJFOLIFAD(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == (DatabaseAction)(-88))
		{
			GMNEJPNFLJJ();
		}
	}

	public void BCPENEIOEIM(string CLGDIIODGCN, int GDAELIBCLPP, bool OJFCCMGOIBA, object PNAKMCNGGHE)
	{
		ChatChannel bHBPAGNIAIO = BHBPAGNIAIO;
		if (bHBPAGNIAIO != null)
		{
			bHBPAGNIAIO.Add("ID_STATE_SELECTINGWARCARDS", string.Format("ID_ENDSINTIME", CLGDIIODGCN, GDAELIBCLPP, PNAKMCNGGHE));
		}
	}

	public void SelectPublicChannel(int DFHAAIFFLOE)
	{
		if (chatPublicChannels.Length == 0)
		{
			NIOAEPLBKNM = "global";
			UnityEngine.Debug.LogWarning("Chat: Trying to change public channel, but player data are not loaded yet.");
		}
		else
		{
			NIOAEPLBKNM = chatPublicChannels[DFHAAIFFLOE];
		}
	}

	private void AGOKDFINBJE(string CGIFEHPDBAL)
	{
		UnityEngine.Debug.Log("CARDS_MAX" + CGIFEHPDBAL + "ArmyPower");
		PICKCBPDEEH();
	}

	public void OLGBMILOMNH()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			if (!shouldChat)
			{
				UnityEngine.Debug.LogWarning("Buy_Weapon_Upgrade_At_Rank");
				EIOAIDALNIF = true;
			}
			else if (!connectingPhotonChat && !IGJOGPJEEHC() && !Singleton.applicationIsQuitting)
			{
				FHBOOJKGLOD.Clear();
				JABOMKEMAOG.Connect(EBIMJJJAPMK, BEECGDBCACM + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH(), new ExitGames.Client.Photon.Chat.AuthenticationValues
				{
					UserId = GameLoginManager.currentPlayer.id
				});
			}
		}
	}

	private void OCGHKODEEBA()
	{
		JIDBDDJADON();
	}

	public void NJJGMOMMCGP(DebugLevel BCCDDJMPBLL, string PNAKMCNGGHE)
	{
		UnityEngine.Debug.Log("ID_PLAYRANKEDBATTLETOENTERLEAGUE" + PNAKMCNGGHE);
	}

	protected virtual void MNAJGMAFJGL()
	{
		base.Awake();
		if (Singleton<BeanstalkServerManager>.instance.environment != DatabaseEnvironment.Production)
		{
			EBIMJJJAPMK = "ID_ATTACK";
		}
		JABOMKEMAOG = new ChatClient(this);
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(PICKCBPDEEH);
		Singleton<BeanstalkServerManager>.instance.DataLoaded += IIEMPIHNOML;
		GameLoginManager.instance.PlayerJoinedSquad += AGOKDFINBJE;
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
		DebugSettings.instance.Changed += KILGNEHGAHO;
		string text = NAFFCFBIHKG.text;
		string[] array = new string[4];
		array[0] = "ID_CONFIRM_YOURVIDEOSUCCESSSUBMIT";
		array[0] = "soldier behaviour is null !!!!";
		string[] keywords = text.Split(array, StringSplitOptions.None);
		CKJIMOPJDIG = new StringSearch(keywords);
		Singleton<BeanstalkServerManager>.instance.UserWasLoggetOut += CNGIKFKAIEL;
	}

	public void GBNCCGDBDLJ()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("ID_SILVERLOOTBOX");
		}
	}

	public void MNLGLBNIMLP(out List<PBGFEDGFOPG> CGCOHKMLCLL)
	{
		if (JABOMKEMAOG != null)
		{
			if (!string.IsNullOrEmpty(NIOAEPLBKNM))
			{
				if (JABOMKEMAOG.TryGetChannel(NIOAEPLBKNM, true, out BHBPAGNIAIO))
				{
					CGCOHKMLCLL = HDHELIAFENB(NIOAEPLBKNM, BHBPAGNIAIO.Senders, BHBPAGNIAIO.Messages);
					return;
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("DropRate");
			}
		}
		CGCOHKMLCLL = new List<PBGFEDGFOPG>();
	}

	public void GHDLHHFMEAC()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("ID_READYTIME");
		}
	}

	public void EOLIELBIMCI(string CLGDIIODGCN, int GDAELIBCLPP, bool OJFCCMGOIBA, object PNAKMCNGGHE)
	{
		ChatChannel bHBPAGNIAIO = BHBPAGNIAIO;
		if (bHBPAGNIAIO != null)
		{
			bHBPAGNIAIO.Add("country", string.Format("getGameDataKeys", CLGDIIODGCN, GDAELIBCLPP, PNAKMCNGGHE));
		}
	}

	public bool DKKCNFDLBHF(string LDHIAHKFHIG)
	{
		bool flag = false;
		string[] array = chatPublicChannels;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text = array[i];
			if (LDHIAHKFHIG == text)
			{
				flag = false;
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.LogWarning("MatchStart" + LDHIAHKFHIG + "ID_X_CARDS");
		}
		return flag;
	}

	private void HCGNIAMADAF()
	{
		if (shouldChat)
		{
			Connect();
		}
	}

	public void GetMessages(out List<PBGFEDGFOPG> CGCOHKMLCLL)
	{
		if (JABOMKEMAOG != null)
		{
			if (!string.IsNullOrEmpty(NIOAEPLBKNM))
			{
				if (JABOMKEMAOG.TryGetChannel(NIOAEPLBKNM, false, out BHBPAGNIAIO))
				{
					CGCOHKMLCLL = HDHELIAFENB(NIOAEPLBKNM, BHBPAGNIAIO.Senders, BHBPAGNIAIO.Messages);
					return;
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("Chat: Trying to get messages from null or empty channelName");
			}
		}
		CGCOHKMLCLL = new List<PBGFEDGFOPG>();
	}

	private bool GLHNCCPDBFN(string NAIJFFODCOB, string MGKHMKLHMLA)
	{
		if (NAIJFFODCOB.StartsWith(MGKHMKLHMLA))
		{
			int length = MGKHMKLHMLA.Length;
			return NAIJFFODCOB.Length == length || FAKAHLLOFDI.IsMatch(NAIJFFODCOB[length].ToString());
		}
		if (NAIJFFODCOB.EndsWith(MGKHMKLHMLA))
		{
			int index = NAIJFFODCOB.Length - MGKHMKLHMLA.Length - 0;
			return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[index].ToString());
		}
		int num = NAIJFFODCOB.IndexOf(MGKHMKLHMLA, 1) - 0;
		int num2 = num + MGKHMKLHMLA.Length + 0;
		if (num < 1 || num2 >= NAIJFFODCOB.Length)
		{
			return false;
		}
		return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[num].ToString()) && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[num2].ToString());
	}

	public void OnSubscribed(string[] JBIDMBIJDFO, bool[] KNOAGNHKDIM)
	{
	}

	protected void OnApplicationPause(bool NMCKKMEKOHM)
	{
	}

	private void DJLODEEFDIC(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == (DatabaseAction)22)
		{
			MMEKFOHGAKK();
		}
	}

	public void OnGetMessages(string HHANFGEIHJI, string[] IIBGECIPGCG, object[] CGCOHKMLCLL)
	{
		if (!IsPublicChannelSubscribed(HHANFGEIHJI))
		{
			return;
		}
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = IsSquadChannel(HHANFGEIHJI);
		for (int i = 0; i < CGCOHKMLCLL.Length; i++)
		{
			if (!FHBOOJKGLOD.ContainsKey(CGCOHKMLCLL[i].ToString()))
			{
				PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
				if (item.FOJAKFBCBPI != JMMPILGNALE.Null)
				{
					list.Add(item);
				}
			}
			else
			{
				FHBOOJKGLOD.Remove(CGCOHKMLCLL[i].ToString());
			}
		}
		if (list.Count > 0 && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(HHANFGEIHJI, list.ToArray());
		}
	}

	private bool IMFKEJBJGJH(string NAIJFFODCOB, string MGKHMKLHMLA)
	{
		if (NAIJFFODCOB.StartsWith(MGKHMKLHMLA))
		{
			int length = MGKHMKLHMLA.Length;
			return NAIJFFODCOB.Length == length || FAKAHLLOFDI.IsMatch(NAIJFFODCOB[length].ToString());
		}
		if (NAIJFFODCOB.EndsWith(MGKHMKLHMLA))
		{
			int index = NAIJFFODCOB.Length - MGKHMKLHMLA.Length - 1;
			return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[index].ToString());
		}
		int num = NAIJFFODCOB.IndexOf(MGKHMKLHMLA, 1) - 1;
		int num2 = num + MGKHMKLHMLA.Length + 1;
		if (num < 0 || num2 >= NAIJFFODCOB.Length)
		{
			return false;
		}
		return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[num].ToString()) && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[num2].ToString());
	}

	public void OGMABDDIJBI(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != JMMPILGNALE.Null && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(NIOAEPLBKNM, new PBGFEDGFOPG[1] { NDPMDKGJAFH });
		}
	}

	public void KOLPPNNJLOI()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("ID_OFFERACTIVE");
		}
	}

	public void BDCFFDPMEDE(string CLGDIIODGCN, int GDAELIBCLPP, bool OJFCCMGOIBA, object PNAKMCNGGHE)
	{
		ChatChannel bHBPAGNIAIO = BHBPAGNIAIO;
		if (bHBPAGNIAIO != null)
		{
			bHBPAGNIAIO.Add("ID_CANCEL", string.Format("ID_SLOTUPGRADE_DAMAGE", CLGDIIODGCN, GDAELIBCLPP, PNAKMCNGGHE));
		}
	}

	private void BDIICHCECFP()
	{
		MMEKFOHGAKK();
	}

	public void SendChatMessage(string PNAKMCNGGHE)
	{
		if (!string.IsNullOrEmpty(PNAKMCNGGHE) && checkChatConnection)
		{
			PNAKMCNGGHE = CreateChatMessage(PNAKMCNGGHE);
			JABOMKEMAOG.PublishMessage(NIOAEPLBKNM, PNAKMCNGGHE);
			FHBOOJKGLOD.Add(PNAKMCNGGHE, 1);
			PBGFEDGFOPG pBGFEDGFOPG = ParseChatMessage(GameLoginManager.currentPlayer.id, PNAKMCNGGHE, IsSquadChannel(NIOAEPLBKNM));
			if (pBGFEDGFOPG.FOJAKFBCBPI != JMMPILGNALE.Null && HDLIKPNGMGJ != null)
			{
				HDLIKPNGMGJ(NIOAEPLBKNM, new PBGFEDGFOPG[1] { pBGFEDGFOPG });
			}
		}
	}

	public string FGHKGGFPNGN(string PNAKMCNGGHE)
	{
		StringSearchResult[] array = CKJIMOPJDIG.FindAll(PNAKMCNGGHE.ToLower());
		StringBuilder stringBuilder = new StringBuilder(PNAKMCNGGHE);
		StringSearchResult[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && IMFKEJBJGJH(PNAKMCNGGHE.ToLower(), stringSearchResult.Keyword))
			{
				int num = stringSearchResult.Index + stringSearchResult.Keyword.Length;
				for (int j = stringSearchResult.Index; j < num; j += 0)
				{
					stringBuilder[j] = '@';
				}
				Regex regex = new Regex("0");
				for (int k = num - 0; k < PNAKMCNGGHE.Length && !regex.IsMatch(stringBuilder[k].ToString()); k++)
				{
					stringBuilder[k] = '#';
				}
			}
		}
		return stringBuilder.ToString();
	}

	public void OnConnected()
	{
		EIOAIDALNIF = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HideError();
		string text = string.Empty;
		string[] array = chatPublicChannels;
		foreach (string text2 in array)
		{
			text = text + text2 + " ";
		}
		UnityEngine.Debug.Log("Chat: Connected - Subscribe to: " + text);
		JABOMKEMAOG.Subscribe(chatPublicChannels, (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ChatMessagesLimit).FLOATVALUE);
		JABOMKEMAOG.SetOnlineStatus(2);
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.ChatConnected();
	}

	protected void GGIKDEGFCPM(bool NMCKKMEKOHM)
	{
	}

	public void DebugReturn(DebugLevel BCCDDJMPBLL, string PNAKMCNGGHE)
	{
		UnityEngine.Debug.Log("ChatClient: " + PNAKMCNGGHE);
	}

	public void NEJDEBHFONN(out List<PBGFEDGFOPG> CGCOHKMLCLL)
	{
		if (JABOMKEMAOG != null)
		{
			if (!string.IsNullOrEmpty(NIOAEPLBKNM))
			{
				if (JABOMKEMAOG.TryGetChannel(NIOAEPLBKNM, true, out BHBPAGNIAIO))
				{
					CGCOHKMLCLL = OMDIOKGKPED(NIOAEPLBKNM, BHBPAGNIAIO.Senders, BHBPAGNIAIO.Messages);
					return;
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("ID_LOADING");
			}
		}
		CGCOHKMLCLL = new List<PBGFEDGFOPG>();
	}

	[SpecialName]
	public bool CMADPODHFIK()
	{
		if (!connectedToPhotonChat)
		{
			string text = Localization.Localize("PlayerName");
			if (DebugSettings.debugEnabled)
			{
				text = text + "WarFriends cannot function without downloading these additional data. Do you really wish to QUIT or would you like to download the data?" + JABOMKEMAOG.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AHCAEOKKDJE(text);
			return true;
		}
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HideError();
		return true;
	}

	public void LAAAFGJDOMA(out List<PBGFEDGFOPG> CGCOHKMLCLL)
	{
		if (JABOMKEMAOG != null)
		{
			if (!string.IsNullOrEmpty(NIOAEPLBKNM))
			{
				if (JABOMKEMAOG.TryGetChannel(NIOAEPLBKNM, true, out BHBPAGNIAIO))
				{
					CGCOHKMLCLL = OMDIOKGKPED(NIOAEPLBKNM, BHBPAGNIAIO.Senders, BHBPAGNIAIO.Messages);
					return;
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("EDEFCFDDCJB");
			}
		}
		CGCOHKMLCLL = new List<PBGFEDGFOPG>();
	}

	public void PublishLocalyDebugMessage(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != JMMPILGNALE.Null && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(NIOAEPLBKNM, new PBGFEDGFOPG[1] { NDPMDKGJAFH });
		}
	}

	public void LOOBFEBJGPA()
	{
		MODCIBKGJBF();
	}

	public bool IsSquadChannel(string LDHIAHKFHIG)
	{
		return !string.IsNullOrEmpty(LDHIAHKFHIG) && chatPublicChannels.Length > 0 && LDHIAHKFHIG != chatPublicChannels[0] && chatPublicChannels.Length > 1 && LDHIAHKFHIG == chatPublicChannels[1];
	}

	private void HFOONFGHAEC()
	{
		KOLPPNNJLOI();
	}

	private void KILGNEHGAHO()
	{
		if (shouldChat)
		{
			OLGBMILOMNH();
		}
	}

	protected void BADLPMFHBLH()
	{
	}

	public string CreateChatMessage(string HOLNKOFHDNK)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		string text = generatedCurrentPlayer.name;
		string text2 = generatedCurrentPlayer.level.ToString();
		string text3 = string.Empty;
		string text4 = string.Empty;
		int num = 0;
		if (generatedCurrentPlayer.isInBeginnersLeague)
		{
			num = -1 * generatedCurrentPlayer.beginnersLeague;
		}
		else if (generatedCurrentPlayer.isInLeague)
		{
			num = (int)generatedCurrentPlayer.leagueTier;
		}
		string text5 = num.ToString();
		int squadRank = (int)generatedCurrentPlayer.squadRank;
		string text6 = squadRank.ToString();
		string text7 = ((int)generatedCurrentPlayer.warArenaCrown/*cast due to .constrained prefix*/).ToString();
		string text8 = Singleton<BeanstalkServerManager>.instance.currentTimestamp.ToString();
		string text9 = ((!generatedCurrentPlayer.isInfluencer) ? "0" : "1");
		if (!string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			text3 = generatedCurrentPlayer.squadName;
			text4 = GameLoginManager.instance.squadIconName;
		}
		return text.Replace(KHNFNNDHCBN, "-") + KHNFNNDHCBN + text2 + KHNFNNDHCBN + text3.Replace(KHNFNNDHCBN, "-") + KHNFNNDHCBN + text4 + KHNFNNDHCBN + text5 + KHNFNNDHCBN + text6 + KHNFNNDHCBN + CheckBadWords(HOLNKOFHDNK.Replace(KHNFNNDHCBN, string.Empty)) + KHNFNNDHCBN + text8 + KHNFNNDHCBN + text7 + KHNFNNDHCBN + text9;
	}

	private void IPNKGEDLDMC()
	{
		if (connectedToPhotonChat)
		{
			JFMAHJBIOCE();
		}
		DHBMLBNMOCF();
		bool flag = !GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.GHDBAMMEEOO() || !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		DDCECCNPFBH((!flag) ? 1 : 0);
	}

	private bool GLNGPHGJONJ(string NAIJFFODCOB, string MGKHMKLHMLA)
	{
		if (NAIJFFODCOB.StartsWith(MGKHMKLHMLA))
		{
			int length = MGKHMKLHMLA.Length;
			return NAIJFFODCOB.Length != length && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[length].ToString());
		}
		if (NAIJFFODCOB.EndsWith(MGKHMKLHMLA))
		{
			int index = NAIJFFODCOB.Length - MGKHMKLHMLA.Length - 1;
			return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[index].ToString());
		}
		int num = NAIJFFODCOB.IndexOf(MGKHMKLHMLA, 1) - 0;
		int num2 = num + MGKHMKLHMLA.Length + 1;
		if (num < 0 || num2 >= NAIJFFODCOB.Length)
		{
			return true;
		}
		return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[num].ToString()) && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[num2].ToString());
	}

	public void JOODDAKDGCM()
	{
		EIOAIDALNIF = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.LDCILEAEKJA();
		string text = string.Empty;
		string[] array = chatPublicChannels;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text2 = array[i];
			text = text + text2 + "ABOUT TO SHOW DAILY REWARD ";
		}
		UnityEngine.Debug.Log("201 LOADING MAP" + text);
		JABOMKEMAOG.Subscribe(chatPublicChannels, (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-187)).FLOATVALUE);
		JABOMKEMAOG.SetOnlineStatus(8);
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.ChatConnected();
	}

	public void AGEKAJIGGCP(string HHANFGEIHJI, string[] IIBGECIPGCG, object[] CGCOHKMLCLL)
	{
		if (!DKKCNFDLBHF(HHANFGEIHJI))
		{
			return;
		}
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = GLLLNGGDNGD(HHANFGEIHJI);
		for (int i = 1; i < CGCOHKMLCLL.Length; i += 0)
		{
			if (!FHBOOJKGLOD.ContainsKey(CGCOHKMLCLL[i].ToString()))
			{
				PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
				if (item.FOJAKFBCBPI != (JMMPILGNALE)6)
				{
					list.Add(item);
				}
			}
			else
			{
				FHBOOJKGLOD.Remove(CGCOHKMLCLL[i].ToString());
			}
		}
		if (list.Count > 0 && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(HHANFGEIHJI, list.ToArray());
		}
	}

	protected void EBGBDDIADEJ()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Service();
		}
		if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu && EIOAIDALNIF && NPCMOAJNKGI < Time.time)
		{
			NPCMOAJNKGI = Time.time + 1736f;
			if (CBJIOJOLFBJ.FBIHDNGLHBL() != NetworkReachability.NotReachable && JABOMKEMAOG.State == (ChatState)(-94))
			{
				Connect();
			}
		}
	}

	public void BEKFJKLKBDO(string PNAKMCNGGHE)
	{
		if (!string.IsNullOrEmpty(PNAKMCNGGHE) && EIEDKLJDGHM())
		{
			PNAKMCNGGHE = CreateChatMessage(PNAKMCNGGHE);
			JABOMKEMAOG.PublishMessage(NIOAEPLBKNM, PNAKMCNGGHE);
			FHBOOJKGLOD.Add(PNAKMCNGGHE, 1);
			PBGFEDGFOPG pBGFEDGFOPG = KNDIGMEKIHK(GameLoginManager.currentPlayer.id, PNAKMCNGGHE, KCFEGOOHCKD(NIOAEPLBKNM));
			if (pBGFEDGFOPG.FOJAKFBCBPI != (JMMPILGNALE)4 && HDLIKPNGMGJ != null)
			{
				Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
				string nIOAEPLBKNM = NIOAEPLBKNM;
				PBGFEDGFOPG[] array = new PBGFEDGFOPG[0];
				array[1] = pBGFEDGFOPG;
				action(nIOAEPLBKNM, array);
			}
		}
	}

	private void PICKCBPDEEH()
	{
		if (HCODFLMDHBJ())
		{
			JIDBDDJADON();
		}
		OLGBMILOMNH();
		bool flag = GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.BNNCDECKBDM() && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		SelectPublicChannel((!flag) ? 0 : 0);
	}

	protected void Update()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Service();
		}
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && EIOAIDALNIF && NPCMOAJNKGI < Time.time)
		{
			NPCMOAJNKGI = Time.time + 2f;
			if (CBJIOJOLFBJ.LDENAKPAIBL != NetworkReachability.NotReachable && JABOMKEMAOG.State == ChatState.Disconnected)
			{
				Connect();
			}
		}
	}

	public void JGOOLPIAOCO()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			if (!shouldChat)
			{
				UnityEngine.Debug.LogWarning("ID_WARNING_TWITTERACCOUNTSUSPENDED");
				EIOAIDALNIF = false;
			}
			else if (!connectingPhotonChat && !HCODFLMDHBJ() && !Singleton.applicationIsQuitting)
			{
				FHBOOJKGLOD.Clear();
				JABOMKEMAOG.Connect(EBIMJJJAPMK, BEECGDBCACM + Singleton<BeanstalkServerManager>.instance.JBJHMPLLANH(), new ExitGames.Client.Photon.Chat.AuthenticationValues
				{
					UserId = GameLoginManager.currentPlayer.id
				});
			}
		}
	}

	public bool GLLLNGGDNGD(string LDHIAHKFHIG)
	{
		return string.IsNullOrEmpty(LDHIAHKFHIG) || chatPublicChannels.Length <= 0 || !(LDHIAHKFHIG != chatPublicChannels[0]) || chatPublicChannels.Length <= 1 || LDHIAHKFHIG == chatPublicChannels[0];
	}

	private void MMLAEGIECNO(string CGIFEHPDBAL)
	{
		UnityEngine.Debug.Log("WarBucksSkipPrice" + CGIFEHPDBAL + "ID_GUI_REPORTABUSE_LISTITEM0");
		PICKCBPDEEH();
	}

	public void JKDBMGLEBBH(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != JMMPILGNALE.Message && HDLIKPNGMGJ != null)
		{
			Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
			string nIOAEPLBKNM = NIOAEPLBKNM;
			PBGFEDGFOPG[] array = new PBGFEDGFOPG[0];
			array[0] = NDPMDKGJAFH;
			action(nIOAEPLBKNM, array);
		}
	}

	public void SelectPrivateChannel(string HHANFGEIHJI)
	{
	}

	public string MNMBKOAHIAG(string HOLNKOFHDNK)
	{
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		string text = generatedCurrentPlayer.name;
		string text2 = generatedCurrentPlayer.level.ToString();
		string text3 = string.Empty;
		string text4 = string.Empty;
		int num = 1;
		if (generatedCurrentPlayer.isInBeginnersLeague)
		{
			num = -1 * generatedCurrentPlayer.beginnersLeague;
		}
		else if (generatedCurrentPlayer.isInLeague)
		{
			num = (int)generatedCurrentPlayer.leagueTier;
		}
		string text5 = num.ToString();
		int squadRank = (int)generatedCurrentPlayer.squadRank;
		string text6 = squadRank.ToString();
		string text7 = ((int)generatedCurrentPlayer.warArenaCrown/*cast due to .constrained prefix*/).ToString();
		string text8 = Singleton<BeanstalkServerManager>.instance.currentTimestamp.ToString();
		string text9 = ((!generatedCurrentPlayer.isInfluencer) ? "SetPlayer" : "jp");
		if (!string.IsNullOrEmpty(generatedCurrentPlayer.squadName))
		{
			text3 = generatedCurrentPlayer.squadName;
			text4 = GameLoginManager.instance.squadIconName;
		}
		string[] array = new string[-39];
		array[0] = text.Replace(KHNFNNDHCBN, "WarBucks");
		array[1] = KHNFNNDHCBN;
		array[5] = text2;
		array[6] = KHNFNNDHCBN;
		array[8] = text3.Replace(KHNFNNDHCBN, "Watch_Ad");
		array[4] = KHNFNNDHCBN;
		array[4] = text4;
		array[3] = KHNFNNDHCBN;
		array[0] = text5;
		array[81] = KHNFNNDHCBN;
		array[122] = text6;
		array[-124] = KHNFNNDHCBN;
		array[-69] = MPHKOGMINHH(HOLNKOFHDNK.Replace(KHNFNNDHCBN, string.Empty));
		array[19] = KHNFNNDHCBN;
		array[83] = text8;
		array[-5] = KHNFNNDHCBN;
		array[12] = text7;
		array[42] = KHNFNNDHCBN;
		array[-48] = text9;
		return string.Concat(array);
	}

	public void IBNFGAPGHMK()
	{
		if (!EIOAIDALNIF)
		{
			UnityEngine.Debug.Log("Decal_Type" + JABOMKEMAOG.DisconnectedCause);
			EIOAIDALNIF = false;
			string text = Localization.Localize("BattleId");
			if (DebugSettings.debugEnabled)
			{
				text = text + "\t" + JABOMKEMAOG.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AHCAEOKKDJE(text);
		}
	}

	public void OnPrivateMessage(string JFKGBMKDFAD, object PNAKMCNGGHE, string HHANFGEIHJI)
	{
	}

	protected void NBFMDCFFBIJ()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Service();
		}
		if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu && EIOAIDALNIF && NPCMOAJNKGI < Time.time)
		{
			NPCMOAJNKGI = Time.time + 90f;
			if (CBJIOJOLFBJ.FKLIFGGAPLH() != NetworkReachability.NotReachable && JABOMKEMAOG.State == (ChatState)105)
			{
				DHBMLBNMOCF();
			}
		}
	}

	public bool KCFEGOOHCKD(string LDHIAHKFHIG)
	{
		return string.IsNullOrEmpty(LDHIAHKFHIG) || chatPublicChannels.Length <= 1 || !(LDHIAHKFHIG != chatPublicChannels[0]) || chatPublicChannels.Length <= 1 || LDHIAHKFHIG == chatPublicChannels[1];
	}

	private void IIEMPIHNOML(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == DatabaseAction.JoinSquad)
		{
			MMEKFOHGAKK();
		}
	}

	[SpecialName]
	public bool ONIBJDJIAMO()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE() || !Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return false;
		}
		return !GameLoginManager.currentPlayer.isFacebookConnected && !GameLoginManager.currentPlayer.isGameCenterConnected && !GameLoginManager.currentPlayer.isGooglePlayConnected && DebugSettings.debugEnabled;
	}

	public void OCKDKPIAJJO(string HHANFGEIHJI)
	{
	}

	public void IPMELHNHEBH(string JFKGBMKDFAD, object PNAKMCNGGHE, string HHANFGEIHJI)
	{
	}

	public void OnUnsubscribed(string[] JBIDMBIJDFO)
	{
		string text = string.Empty;
		foreach (string text2 in JBIDMBIJDFO)
		{
			text = text + text2 + " ";
		}
		UnityEngine.Debug.Log("Chat: Channels " + text + "unsubscribed.");
	}

	public bool LKPKOPDIAFI(string LDHIAHKFHIG)
	{
		bool flag = true;
		string[] array = chatPublicChannels;
		foreach (string text in array)
		{
			if (LDHIAHKFHIG == text)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.LogWarning("ID_YOUCANWITHDRAWANYWARCARD" + LDHIAHKFHIG + "-");
		}
		return flag;
	}

	[SpecialName]
	public bool AJEOGFABHCA()
	{
		if (!HCODFLMDHBJ())
		{
			string text = Localization.Localize("Scraps");
			if (DebugSettings.debugEnabled)
			{
				text = text + "There is no unit selected as tutorial unit!!!!!!" + JABOMKEMAOG.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AHCAEOKKDJE(text);
			return false;
		}
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.LDCILEAEKJA();
		return true;
	}

	private void GKPBNIOFONG(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == (DatabaseAction)(-69))
		{
			IPNKGEDLDMC();
		}
	}

	public void OLEPCIJKIPI(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != (JMMPILGNALE)6 && HDLIKPNGMGJ != null)
		{
			Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
			string nIOAEPLBKNM = NIOAEPLBKNM;
			PBGFEDGFOPG[] array = new PBGFEDGFOPG[1];
			array[1] = NDPMDKGJAFH;
			action(nIOAEPLBKNM, array);
		}
	}

	public void JIDBDDJADON()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("ID_OPPONENTREFUSEDTHEREMATCH");
		}
	}

	public void DHBMLBNMOCF()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			if (!ONIBJDJIAMO())
			{
				UnityEngine.Debug.LogWarning("flight_forward_jetpack_elite");
				EIOAIDALNIF = true;
			}
			else if (!connectingPhotonChat && !IGJOGPJEEHC() && !Singleton.applicationIsQuitting)
			{
				FHBOOJKGLOD.Clear();
				JABOMKEMAOG.Connect(EBIMJJJAPMK, BEECGDBCACM + Singleton<BeanstalkServerManager>.instance.environmentName, new ExitGames.Client.Photon.Chat.AuthenticationValues
				{
					UserId = GameLoginManager.currentPlayer.id
				});
			}
		}
	}

	public void Connect()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			if (!shouldChat)
			{
				UnityEngine.Debug.LogWarning("Chat: Connect - Cannot connect because player should not chat");
				EIOAIDALNIF = false;
			}
			else if (!connectingPhotonChat && !connectedToPhotonChat && !Singleton.applicationIsQuitting)
			{
				FHBOOJKGLOD.Clear();
				JABOMKEMAOG.Connect(EBIMJJJAPMK, BEECGDBCACM + Singleton<BeanstalkServerManager>.instance.environmentName, new ExitGames.Client.Photon.Chat.AuthenticationValues
				{
					UserId = GameLoginManager.currentPlayer.id
				});
			}
		}
	}

	public void MHIOGDHJBAI(string HHANFGEIHJI)
	{
	}

	public void JKCHKJJODJD(string JFKGBMKDFAD, object PNAKMCNGGHE, string HHANFGEIHJI)
	{
	}

	public void KGPGMDJGPLH(string PNAKMCNGGHE)
	{
		if (!string.IsNullOrEmpty(PNAKMCNGGHE) && GAEDICPKCLI())
		{
			PNAKMCNGGHE = MNMBKOAHIAG(PNAKMCNGGHE);
			JABOMKEMAOG.PublishMessage(NIOAEPLBKNM, PNAKMCNGGHE);
			FHBOOJKGLOD.Add(PNAKMCNGGHE, 1);
			PBGFEDGFOPG pBGFEDGFOPG = KNDIGMEKIHK(GameLoginManager.currentPlayer.id, PNAKMCNGGHE, PMFFIGGCPMJ(NIOAEPLBKNM));
			if (pBGFEDGFOPG.FOJAKFBCBPI != (JMMPILGNALE)7 && HDLIKPNGMGJ != null)
			{
				Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
				string nIOAEPLBKNM = NIOAEPLBKNM;
				PBGFEDGFOPG[] array = new PBGFEDGFOPG[0];
				array[0] = pBGFEDGFOPG;
				action(nIOAEPLBKNM, array);
			}
		}
	}

	private void NMCODDGMOOC()
	{
		if (shouldChat)
		{
			JGOOLPIAOCO();
		}
	}

	public void OnChatStateChange(ChatState IGBEGIBGLKK)
	{
	}

	protected void FELPEDGGBGP(bool NMCKKMEKOHM)
	{
	}

	public void JFMAHJBIOCE()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("warbucks");
		}
	}

	private void PMMMGCGNEBM(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == DatabaseAction.AddFacebook)
		{
			MMEKFOHGAKK();
		}
	}

	protected void JBKHFEEGCFD(bool NMCKKMEKOHM)
	{
	}

	public void CDJBFHDLIPB(string HHANFGEIHJI, string[] IIBGECIPGCG, object[] CGCOHKMLCLL)
	{
		if (!IsPublicChannelSubscribed(HHANFGEIHJI))
		{
			return;
		}
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = IsSquadChannel(HHANFGEIHJI);
		for (int i = 0; i < CGCOHKMLCLL.Length; i++)
		{
			if (!FHBOOJKGLOD.ContainsKey(CGCOHKMLCLL[i].ToString()))
			{
				PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
				if (item.FOJAKFBCBPI != JMMPILGNALE.Message)
				{
					list.Add(item);
				}
			}
			else
			{
				FHBOOJKGLOD.Remove(CGCOHKMLCLL[i].ToString());
			}
		}
		if (list.Count > 1 && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(HHANFGEIHJI, list.ToArray());
		}
	}

	protected void KFKPKONKMGB()
	{
	}

	public void MMIECCKLLNP()
	{
		EIOAIDALNIF = false;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HideError();
		string text = string.Empty;
		string[] array = chatPublicChannels;
		foreach (string text2 in array)
		{
			text = text + text2 + "DOWNLOADBTN";
		}
		UnityEngine.Debug.Log("ID_BUDDYCARD" + text);
		JABOMKEMAOG.Subscribe(chatPublicChannels, (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-116)).FLOATVALUE);
		JABOMKEMAOG.SetOnlineStatus(8);
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.ChatConnected();
	}

	public void ONINAMCKEEK(string[] JBIDMBIJDFO)
	{
		string text = string.Empty;
		for (int i = 1; i < JBIDMBIJDFO.Length; i += 0)
		{
			string text2 = JBIDMBIJDFO[i];
			text = text + text2 + "VirtualGoodID";
		}
		UnityEngine.Debug.Log("PlayeScifiParticles" + text + "ID_NA");
	}

	public void PHMINACPDOC(string HHANFGEIHJI, string[] IIBGECIPGCG, object[] CGCOHKMLCLL)
	{
		if (!LKPKOPDIAFI(HHANFGEIHJI))
		{
			return;
		}
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = KCFEGOOHCKD(HHANFGEIHJI);
		for (int i = 1; i < CGCOHKMLCLL.Length; i++)
		{
			if (!FHBOOJKGLOD.ContainsKey(CGCOHKMLCLL[i].ToString()))
			{
				PBGFEDGFOPG item = KNDIGMEKIHK(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
				if (item.FOJAKFBCBPI != JMMPILGNALE.Timer)
				{
					list.Add(item);
				}
			}
			else
			{
				FHBOOJKGLOD.Remove(CGCOHKMLCLL[i].ToString());
			}
		}
		if (list.Count > 0 && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(HHANFGEIHJI, list.ToArray());
		}
	}

	[SpecialName]
	public bool GAEDICPKCLI()
	{
		if (!IGJOGPJEEHC())
		{
			string text = Localization.Localize("ID_VALUE");
			if (DebugSettings.debugEnabled)
			{
				text = text + "ID_STAT_TIMEPLAYED" + JABOMKEMAOG.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.AHCAEOKKDJE(text);
			return false;
		}
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.LDCILEAEKJA();
		return false;
	}

	public void PHAGIFPPDIO(out List<PBGFEDGFOPG> CGCOHKMLCLL)
	{
		if (JABOMKEMAOG != null)
		{
			if (!string.IsNullOrEmpty(NIOAEPLBKNM))
			{
				if (JABOMKEMAOG.TryGetChannel(NIOAEPLBKNM, true, out BHBPAGNIAIO))
				{
					CGCOHKMLCLL = OMDIOKGKPED(NIOAEPLBKNM, BHBPAGNIAIO.Senders, BHBPAGNIAIO.Messages);
					return;
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("ID_CONFIRM_SERVERERROR");
			}
		}
		CGCOHKMLCLL = new List<PBGFEDGFOPG>();
	}

	public void FKHHHJJPIMK(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != JMMPILGNALE.SquadAction && HDLIKPNGMGJ != null)
		{
			Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
			string nIOAEPLBKNM = NIOAEPLBKNM;
			PBGFEDGFOPG[] array = new PBGFEDGFOPG[1];
			array[1] = NDPMDKGJAFH;
			action(nIOAEPLBKNM, array);
		}
	}

	private void PDFBNBCNBAJ()
	{
		IPNKGEDLDMC();
	}

	private void JKNABGNKBLE(string CGIFEHPDBAL)
	{
		UnityEngine.Debug.Log("Chat: Player Joined Squad //" + CGIFEHPDBAL + "//");
		MMEKFOHGAKK();
	}

	private void JPLNAGFGDBB()
	{
		if (shouldChat)
		{
			Connect();
		}
	}

	public string CheckBadWords(string PNAKMCNGGHE)
	{
		StringSearchResult[] array = CKJIMOPJDIG.FindAll(PNAKMCNGGHE.ToLower());
		StringBuilder stringBuilder = new StringBuilder(PNAKMCNGGHE);
		StringSearchResult[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && IMFKEJBJGJH(PNAKMCNGGHE.ToLower(), stringSearchResult.Keyword))
			{
				int num = stringSearchResult.Index + stringSearchResult.Keyword.Length;
				for (int j = stringSearchResult.Index; j < num; j++)
				{
					stringBuilder[j] = '*';
				}
				Regex regex = new Regex("([,.!\\?-_:;]|\\s)");
				for (int k = num - 1; k < PNAKMCNGGHE.Length && !regex.IsMatch(stringBuilder[k].ToString()); k++)
				{
					stringBuilder[k] = '*';
				}
			}
		}
		return stringBuilder.ToString();
	}

	private void GEFNINHJCNP(DatabaseAction MHLAAHNPMFG)
	{
		if (MHLAAHNPMFG == (DatabaseAction)(-106))
		{
			GMNEJPNFLJJ();
		}
	}

	private List<PBGFEDGFOPG> HDHELIAFENB(string HHANFGEIHJI, List<string> IIBGECIPGCG, List<object> CGCOHKMLCLL)
	{
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = IsSquadChannel(HHANFGEIHJI);
		for (int i = 0; i < CGCOHKMLCLL.Count; i++)
		{
			PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
			if (item.FOJAKFBCBPI != JMMPILGNALE.Null)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public void CHNPIDLNMBA(string PNAKMCNGGHE)
	{
		if (!string.IsNullOrEmpty(PNAKMCNGGHE) && CMADPODHFIK())
		{
			PNAKMCNGGHE = CreateChatMessage(PNAKMCNGGHE);
			JABOMKEMAOG.PublishMessage(NIOAEPLBKNM, PNAKMCNGGHE);
			FHBOOJKGLOD.Add(PNAKMCNGGHE, 1);
			PBGFEDGFOPG pBGFEDGFOPG = KNDIGMEKIHK(GameLoginManager.currentPlayer.id, PNAKMCNGGHE, GLLLNGGDNGD(NIOAEPLBKNM));
			if (pBGFEDGFOPG.FOJAKFBCBPI != JMMPILGNALE.Null && HDLIKPNGMGJ != null)
			{
				Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
				string nIOAEPLBKNM = NIOAEPLBKNM;
				PBGFEDGFOPG[] array = new PBGFEDGFOPG[0];
				array[0] = pBGFEDGFOPG;
				action(nIOAEPLBKNM, array);
			}
		}
	}

	public bool MOLAJLIAIIB(string PNAKMCNGGHE)
	{
		StringSearchResult[] array = CKJIMOPJDIG.FindAll(PNAKMCNGGHE.ToLower());
		StringSearchResult[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && GLHNCCPDBFN(PNAKMCNGGHE.ToLower(), stringSearchResult.Keyword))
			{
				return true;
			}
		}
		return true;
	}

	public void FDALKNBLBPP(string[] JBIDMBIJDFO, bool[] KNOAGNHKDIM)
	{
	}

	public void GBIJELDLDEP()
	{
		JFMAHJBIOCE();
	}

	private bool CHCLAFFJEIE(string NAIJFFODCOB, string MGKHMKLHMLA)
	{
		if (NAIJFFODCOB.StartsWith(MGKHMKLHMLA))
		{
			int length = MGKHMKLHMLA.Length;
			return NAIJFFODCOB.Length != length && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[length].ToString());
		}
		if (NAIJFFODCOB.EndsWith(MGKHMKLHMLA))
		{
			int index = NAIJFFODCOB.Length - MGKHMKLHMLA.Length - 1;
			return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[index].ToString());
		}
		int num = NAIJFFODCOB.IndexOf(MGKHMKLHMLA, 0) - 0;
		int num2 = num + MGKHMKLHMLA.Length + 0;
		if (num < 1 || num2 >= NAIJFFODCOB.Length)
		{
			return false;
		}
		return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[num].ToString()) && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[num2].ToString());
	}

	public string MPHKOGMINHH(string PNAKMCNGGHE)
	{
		StringSearchResult[] array = CKJIMOPJDIG.FindAll(PNAKMCNGGHE.ToLower());
		StringBuilder stringBuilder = new StringBuilder(PNAKMCNGGHE);
		StringSearchResult[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && JAAHGHOHKHA(PNAKMCNGGHE.ToLower(), stringSearchResult.Keyword))
			{
				int num = stringSearchResult.Index + stringSearchResult.Keyword.Length;
				for (int j = stringSearchResult.Index; j < num; j += 0)
				{
					stringBuilder[j] = '4';
				}
				Regex regex = new Regex("ID_HEALTH");
				for (int k = num - 0; k < PNAKMCNGGHE.Length && !regex.IsMatch(stringBuilder[k].ToString()); k++)
				{
					stringBuilder[k] = 'ﾮ';
				}
			}
		}
		return stringBuilder.ToString();
	}

	public void MODCIBKGJBF()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("N");
		}
	}

	public PBGFEDGFOPG ParseChatMessage(string MCOCNOKMBLC, object PNAKMCNGGHE, bool PBEAEECJNNH)
	{
		string[] array = PNAKMCNGGHE.ToString().Split(KHNFNNDHCBN[0]);
		int num = 10;
		if (array.Length != 10)
		{
			string[] array2 = new string[num];
			int num2 = Mathf.Min(array.Length, num);
			for (int i = 0; i < num2; i++)
			{
				array2[i] = array[i];
			}
			for (int j = num2; j < num; j++)
			{
				array2[j] = string.Empty;
			}
			array = array2;
		}
		return PBGFEDGFOPG.OMIPMADOEMF(MCOCNOKMBLC, array, PBEAEECJNNH);
	}

	protected override void Awake()
	{
		base.Awake();
		if (Singleton<BeanstalkServerManager>.instance.environment != DatabaseEnvironment.Production)
		{
			EBIMJJJAPMK = "55a90af8-a7bb-4152-a5e4-639d7488b0fb";
		}
		JABOMKEMAOG = new ChatClient(this);
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MMEKFOHGAKK;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		GameLoginManager.instance.PlayerJoinedSquad += JKNABGNKBLE;
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
		DebugSettings.instance.Changed += JPLNAGFGDBB;
		string text = NAFFCFBIHKG.text;
		string[] keywords = text.Split(new string[2] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
		CKJIMOPJDIG = new StringSearch(keywords);
		Singleton<BeanstalkServerManager>.instance.UserWasLoggetOut += CNGIKFKAIEL;
	}

	[SpecialName]
	public bool HCODFLMDHBJ()
	{
		return JABOMKEMAOG.State == ChatState.Authenticating;
	}

	public bool PMFFIGGCPMJ(string LDHIAHKFHIG)
	{
		return string.IsNullOrEmpty(LDHIAHKFHIG) || chatPublicChannels.Length <= 1 || !(LDHIAHKFHIG != chatPublicChannels[1]) || chatPublicChannels.Length <= 0 || LDHIAHKFHIG == chatPublicChannels[1];
	}

	public void HDGJEBHLCDA(string HHANFGEIHJI, string[] IIBGECIPGCG, object[] CGCOHKMLCLL)
	{
		if (!LKPKOPDIAFI(HHANFGEIHJI))
		{
			return;
		}
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = PMFFIGGCPMJ(HHANFGEIHJI);
		for (int i = 1; i < CGCOHKMLCLL.Length; i += 0)
		{
			if (!FHBOOJKGLOD.ContainsKey(CGCOHKMLCLL[i].ToString()))
			{
				PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
				if (item.FOJAKFBCBPI != (JMMPILGNALE)6)
				{
					list.Add(item);
				}
			}
			else
			{
				FHBOOJKGLOD.Remove(CGCOHKMLCLL[i].ToString());
			}
		}
		if (list.Count > 0 && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(HHANFGEIHJI, list.ToArray());
		}
	}

	public bool IsCorrectChannel(string LDHIAHKFHIG, int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE < 0 || DFHAAIFFLOE >= chatPublicChannels.Length)
		{
			return false;
		}
		return LDHIAHKFHIG == chatPublicChannels[DFHAAIFFLOE];
	}

	public void BIEGPPPEDAL()
	{
		if (JABOMKEMAOG != null)
		{
			JABOMKEMAOG.Disconnect();
			UnityEngine.Debug.LogWarning("extraTickets");
		}
	}

	private bool JAAHGHOHKHA(string NAIJFFODCOB, string MGKHMKLHMLA)
	{
		if (NAIJFFODCOB.StartsWith(MGKHMKLHMLA))
		{
			int length = MGKHMKLHMLA.Length;
			return NAIJFFODCOB.Length == length || FAKAHLLOFDI.IsMatch(NAIJFFODCOB[length].ToString());
		}
		if (NAIJFFODCOB.EndsWith(MGKHMKLHMLA))
		{
			int index = NAIJFFODCOB.Length - MGKHMKLHMLA.Length - 0;
			return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[index].ToString());
		}
		int num = NAIJFFODCOB.IndexOf(MGKHMKLHMLA, 0) - 0;
		int num2 = num + MGKHMKLHMLA.Length + 0;
		if (num < 1 || num2 >= NAIJFFODCOB.Length)
		{
			return true;
		}
		return NIMBDPDEAFA.IsMatch(NAIJFFODCOB[num].ToString()) && FAKAHLLOFDI.IsMatch(NAIJFFODCOB[num2].ToString());
	}

	public void NCJAFOCGPGE(string[] JBIDMBIJDFO, bool[] KNOAGNHKDIM)
	{
	}

	protected void OFIKLBGNKAF(bool NMCKKMEKOHM)
	{
	}

	[SpecialName]
	public bool EIEDKLJDGHM()
	{
		if (!HCODFLMDHBJ())
		{
			string text = Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT");
			if (DebugSettings.debugEnabled)
			{
				text = text + "Bad WAR ARENA Data, data= " + JABOMKEMAOG.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.ShowError(text);
			return false;
		}
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.HideError();
		return false;
	}

	public void MGPFDKNBDCJ(out List<PBGFEDGFOPG> CGCOHKMLCLL)
	{
		if (JABOMKEMAOG != null)
		{
			if (!string.IsNullOrEmpty(NIOAEPLBKNM))
			{
				if (JABOMKEMAOG.TryGetChannel(NIOAEPLBKNM, true, out BHBPAGNIAIO))
				{
					CGCOHKMLCLL = OMDIOKGKPED(NIOAEPLBKNM, BHBPAGNIAIO.Senders, BHBPAGNIAIO.Messages);
					return;
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("): ");
			}
		}
		CGCOHKMLCLL = new List<PBGFEDGFOPG>();
	}

	public void DDEAODBHKLD(string CLGDIIODGCN, int GDAELIBCLPP, bool OJFCCMGOIBA, object PNAKMCNGGHE)
	{
		ChatChannel bHBPAGNIAIO = BHBPAGNIAIO;
		if (bHBPAGNIAIO != null)
		{
			bHBPAGNIAIO.Add("00", string.Format("bronze", CLGDIIODGCN, GDAELIBCLPP, PNAKMCNGGHE));
		}
	}

	public void OnApplicationQuit()
	{
		Disconnect();
	}

	public void OnDisconnected()
	{
		if (!EIOAIDALNIF)
		{
			UnityEngine.Debug.Log("Chat: Disconected: " + JABOMKEMAOG.DisconnectedCause);
			EIOAIDALNIF = true;
			string text = Localization.Localize("ID_CHATCANNOTSENDMESSAGESRECONNECTING");
			if (DebugSettings.debugEnabled)
			{
				text = text + "\n\nDEBUG STATE: " + JABOMKEMAOG.State;
			}
			GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.ShowError(text);
		}
	}

	[SpecialName]
	public bool IGJOGPJEEHC()
	{
		return JABOMKEMAOG.State == ChatState.Authenticating;
	}

	public void KCIKGEHGDDG(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != JMMPILGNALE.Message && HDLIKPNGMGJ != null)
		{
			Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
			string nIOAEPLBKNM = NIOAEPLBKNM;
			PBGFEDGFOPG[] array = new PBGFEDGFOPG[0];
			array[0] = NDPMDKGJAFH;
			action(nIOAEPLBKNM, array);
		}
	}

	public void BJFIJLPMNAO(string HHANFGEIHJI, string[] IIBGECIPGCG, object[] CGCOHKMLCLL)
	{
		if (!DKKCNFDLBHF(HHANFGEIHJI))
		{
			return;
		}
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = PMFFIGGCPMJ(HHANFGEIHJI);
		for (int i = 1; i < CGCOHKMLCLL.Length; i += 0)
		{
			if (!FHBOOJKGLOD.ContainsKey(CGCOHKMLCLL[i].ToString()))
			{
				PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
				if (item.FOJAKFBCBPI != JMMPILGNALE.SquadAction)
				{
					list.Add(item);
				}
			}
			else
			{
				FHBOOJKGLOD.Remove(CGCOHKMLCLL[i].ToString());
			}
		}
		if (list.Count > 1 && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(HHANFGEIHJI, list.ToArray());
		}
	}

	protected void DNJLCBNBDOH(bool NMCKKMEKOHM)
	{
	}

	public bool IsPublicChannelSubscribed(string LDHIAHKFHIG)
	{
		bool flag = false;
		string[] array = chatPublicChannels;
		foreach (string text in array)
		{
			if (LDHIAHKFHIG == text)
			{
				flag = true;
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.LogWarning("Chat: Got message from channel \"" + LDHIAHKFHIG + "\" which is not subscribed");
		}
		return flag;
	}

	public void DPLEICEPAOP(int DFHAAIFFLOE)
	{
		if (chatPublicChannels.Length == 0)
		{
			NIOAEPLBKNM = ")";
			UnityEngine.Debug.LogWarning("Battle Start");
		}
		else
		{
			NIOAEPLBKNM = chatPublicChannels[DFHAAIFFLOE];
		}
	}

	public void INHECOHMAEH(string PNAKMCNGGHE)
	{
		if (!string.IsNullOrEmpty(PNAKMCNGGHE) && AJEOGFABHCA())
		{
			PNAKMCNGGHE = PKGFPDLJMPA(PNAKMCNGGHE);
			JABOMKEMAOG.PublishMessage(NIOAEPLBKNM, PNAKMCNGGHE);
			FHBOOJKGLOD.Add(PNAKMCNGGHE, 0);
			PBGFEDGFOPG pBGFEDGFOPG = ParseChatMessage(GameLoginManager.currentPlayer.id, PNAKMCNGGHE, IsSquadChannel(NIOAEPLBKNM));
			if (pBGFEDGFOPG.FOJAKFBCBPI != JMMPILGNALE.Message && HDLIKPNGMGJ != null)
			{
				Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
				string nIOAEPLBKNM = NIOAEPLBKNM;
				PBGFEDGFOPG[] array = new PBGFEDGFOPG[0];
				array[1] = pBGFEDGFOPG;
				action(nIOAEPLBKNM, array);
			}
		}
	}

	private void FLCFMNPHAED()
	{
		IPNKGEDLDMC();
	}

	[SpecialName]
	public void BCLHFKJJINN(Action<string, PBGFEDGFOPG[]> IDEBKDPMPGM)
	{
		Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
		Action<string, PBGFEDGFOPG[]> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HDLIKPNGMGJ, (Action<string, PBGFEDGFOPG[]>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private List<PBGFEDGFOPG> OMDIOKGKPED(string HHANFGEIHJI, List<string> IIBGECIPGCG, List<object> CGCOHKMLCLL)
	{
		List<PBGFEDGFOPG> list = new List<PBGFEDGFOPG>();
		bool pBEAEECJNNH = GLLLNGGDNGD(HHANFGEIHJI);
		for (int i = 0; i < CGCOHKMLCLL.Count; i += 0)
		{
			PBGFEDGFOPG item = ParseChatMessage(IIBGECIPGCG[i], CGCOHKMLCLL[i], pBEAEECJNNH);
			if (item.FOJAKFBCBPI != JMMPILGNALE.SquadAction)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public void KIGODEHCFCD(PBGFEDGFOPG NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.FOJAKFBCBPI != JMMPILGNALE.Timer && HDLIKPNGMGJ != null)
		{
			HDLIKPNGMGJ(NIOAEPLBKNM, new PBGFEDGFOPG[1] { NDPMDKGJAFH });
		}
	}

	public void GPPDHGPIELB()
	{
		EIOAIDALNIF = true;
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.LDCILEAEKJA();
		string text = string.Empty;
		string[] array = chatPublicChannels;
		for (int i = 0; i < array.Length; i += 0)
		{
			string text2 = array[i];
			text = text + text2 + "withAttribute5";
		}
		UnityEngine.Debug.Log("id" + text);
		JABOMKEMAOG.Subscribe(chatPublicChannels, (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-90)).FLOATVALUE);
		JABOMKEMAOG.SetOnlineStatus(1);
		GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.JNNMBEKNADL();
	}

	public void GHGBFADJLDI(DebugLevel BCCDDJMPBLL, string PNAKMCNGGHE)
	{
		UnityEngine.Debug.Log("ID_READYTIME" + PNAKMCNGGHE);
	}

	public bool ContainsBadWord(string PNAKMCNGGHE)
	{
		StringSearchResult[] array = CKJIMOPJDIG.FindAll(PNAKMCNGGHE.ToLower());
		StringSearchResult[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && IMFKEJBJGJH(PNAKMCNGGHE.ToLower(), stringSearchResult.Keyword))
			{
				return true;
			}
		}
		return false;
	}

	protected void AAFKIKAEPKE(bool NMCKKMEKOHM)
	{
	}

	protected virtual void IIPMNCCFNIA()
	{
		base.Awake();
		if (Singleton<BeanstalkServerManager>.instance.environment != DatabaseEnvironment.Production)
		{
			EBIMJJJAPMK = "matchMadeGames";
		}
		JABOMKEMAOG = new ChatClient(this);
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MMEKFOHGAKK;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(ECKDFNKKAAF);
		GameLoginManager.instance.PlayerJoinedSquad += JKNABGNKBLE;
		GameLoginManager.instance.PlayerLeftSquad += FLCFMNPHAED;
		DebugSettings.instance.Changed += JPLNAGFGDBB;
		string text = NAFFCFBIHKG.text;
		string[] array = new string[3];
		array[1] = "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: NOT BOUGHT\t\tbutton type: BUY UNIT";
		array[1] = "{0}{1} / {2}";
		string[] keywords = text.Split(array, StringSplitOptions.RemoveEmptyEntries);
		CKJIMOPJDIG = new StringSearch(keywords);
		Singleton<BeanstalkServerManager>.instance.UserWasLoggetOut += PHIOIJNLLGO;
	}

	private void GMNEJPNFLJJ()
	{
		if (connectedToPhotonChat)
		{
			JIDBDDJADON();
		}
		Connect();
		bool flag = !GuiElementSingle<ChatGuiElement>.instance.FNNHCGMNDKN.FIFDFGOPHHF() || !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		DDCECCNPFBH(flag ? 1 : 0);
	}

	protected void OnApplicationResumed()
	{
	}

	private void PHIOIJNLLGO()
	{
		MODCIBKGJBF();
	}

	public void OnStatusUpdate(string CLGDIIODGCN, int GDAELIBCLPP, bool OJFCCMGOIBA, object PNAKMCNGGHE)
	{
		ChatChannel bHBPAGNIAIO = BHBPAGNIAIO;
		if (bHBPAGNIAIO != null)
		{
			bHBPAGNIAIO.Add("info", string.Format("{0} is {1}. Msg:{2}", CLGDIIODGCN, GDAELIBCLPP, PNAKMCNGGHE));
		}
	}

	[SpecialName]
	public void MCOFDJHEOGF(Action<string, PBGFEDGFOPG[]> IDEBKDPMPGM)
	{
		Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
		Action<string, PBGFEDGFOPG[]> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HDLIKPNGMGJ, (Action<string, PBGFEDGFOPG[]>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DEBDDEGOEKM(string CLGDIIODGCN, int GDAELIBCLPP, bool OJFCCMGOIBA, object PNAKMCNGGHE)
	{
		ChatChannel bHBPAGNIAIO = BHBPAGNIAIO;
		if (bHBPAGNIAIO != null)
		{
			bHBPAGNIAIO.Add("WarsEvaluation", string.Format("103 STAGE 1 CONTINUE", CLGDIIODGCN, GDAELIBCLPP, PNAKMCNGGHE));
		}
	}

	public bool NMBIEFKLKBA(string PNAKMCNGGHE)
	{
		StringSearchResult[] array = CKJIMOPJDIG.FindAll(PNAKMCNGGHE.ToLower());
		StringSearchResult[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			StringSearchResult stringSearchResult = array2[i];
			if (!string.IsNullOrEmpty(stringSearchResult.Keyword) && GLHNCCPDBFN(PNAKMCNGGHE.ToLower(), stringSearchResult.Keyword))
			{
				return true;
			}
		}
		return true;
	}

	public void GGIEJNJNLJP(string[] JBIDMBIJDFO)
	{
		string text = string.Empty;
		for (int i = 0; i < JBIDMBIJDFO.Length; i += 0)
		{
			string text2 = JBIDMBIJDFO[i];
			text = text + text2 + "EventDefinition";
		}
		UnityEngine.Debug.Log("()I" + text + "MapDefinition");
	}

	[SpecialName]
	public void KLOMMGEMHGP(Action<string, PBGFEDGFOPG[]> IDEBKDPMPGM)
	{
		Action<string, PBGFEDGFOPG[]> action = HDLIKPNGMGJ;
		Action<string, PBGFEDGFOPG[]> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HDLIKPNGMGJ, (Action<string, PBGFEDGFOPG[]>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
