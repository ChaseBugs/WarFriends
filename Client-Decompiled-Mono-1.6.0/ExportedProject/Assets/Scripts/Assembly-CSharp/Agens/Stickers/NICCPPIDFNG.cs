using System;
using UnityEngine;

namespace Agens.Stickers
{
	public class NICCPPIDFNG
	{
		public enum BOAFCAGKOJG
		{
			Iphone = 0,
			Ipad = 1,
			Universal = 2,
			IosMarketing = 3
		}

		public enum NDFNJIHCCGM
		{
			Original = 1,
			Double = 2,
			Triple = 3
		}

		public Vector2 FOICGJEPBGL;

		public BOAFCAGKOJG GGPGNNBBKPB;

		public string AJINMGHIFPI;

		public NDFNJIHCCGM IAJAILAGAKC;

		public string CBAHAFGKCAA;

		public NICCPPIDFNG(Texture2D EBFDAICCJAK, int CEHFMMJHCKC, int FBMIFHHEOBO, BOAFCAGKOJG GGPGNNBBKPB, NDFNJIHCCGM IAJAILAGAKC = NDFNJIHCCGM.Double, string CBAHAFGKCAA = null)
		{
			FOICGJEPBGL = new Vector2(CEHFMMJHCKC, FBMIFHHEOBO);
			AJINMGHIFPI = EBFDAICCJAK.name + ".png";
			this.GGPGNNBBKPB = GGPGNNBBKPB;
			this.IAJAILAGAKC = IAJAILAGAKC;
			this.CBAHAFGKCAA = CBAHAFGKCAA;
		}

		public string NDGMKGPCFKG()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)6)
			{
				return "401 START";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string LCJEPPAICAF()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == BOAFCAGKOJG.Ipad)
			{
				return "IsWarPath";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string HLNIFALCDEF()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == BOAFCAGKOJG.IosMarketing)
			{
				return "BotWeaponPower";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string KMIEDEBBJIC()
		{
			return (int)IAJAILAGAKC + "Vip";
		}

		public string FLBLJAEJKJP()
		{
			return (int)IAJAILAGAKC + "x";
		}

		public string ELLCDDJEOMF()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)6)
			{
				return "Scraps";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string PGPOEPJOAKM()
		{
			return (int)IAJAILAGAKC + "_MainTex";
		}

		public string HPOLLOILHAO()
		{
			return (int)IAJAILAGAKC + "DESTROYED REFERENCE";
		}

		public string KBAFKMMEOIN()
		{
			return (int)IAJAILAGAKC + "SET HP: ";
		}

		public string GHHINLLJALD()
		{
			return (int)IAJAILAGAKC + "ID_CONFIRM_NOSQUADACTIONS_TITLE";
		}

		public string MBNKNJDGDFN()
		{
			return (int)IAJAILAGAKC + "BeginnersLeague";
		}

		public string LAHCJNGKHII()
		{
			return (int)IAJAILAGAKC + "ID_SUGGESTEDGLOBALSQUADS";
		}

		public string NEFCFNDFFHG()
		{
			return (int)IAJAILAGAKC + "ID_TUTORIAL_PROGRESS_KILLING2";
		}

		public string JDEBHFMAOLH()
		{
			return (int)IAJAILAGAKC + "idle";
		}

		public string IFDKACOAKDF()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)6)
			{
				return "ArenaWins";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string OHIGPAJOKDJ()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)5)
			{
				return "GetOriginalAccountType()";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string GIPMFLJHPEG()
		{
			return (int)IAJAILAGAKC + "setUserId";
		}

		public string IENPFMKOPBO()
		{
			return (int)IAJAILAGAKC + "ID_UNITTYPE2";
		}

		public string HDFPMJPADII()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == BOAFCAGKOJG.IosMarketing)
			{
				return "ios-marketing";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string FMEACFHPCJH()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)5)
			{
				return "claim reward failed: {0}";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string KPHAOKMLODP()
		{
			return (int)IAJAILAGAKC + "ID_VISUALCATEGORYPART2";
		}

		public string JDELBCCCPJN()
		{
			return (int)IAJAILAGAKC + "FuseSDK_Prime31_IAB: GoogleIAB.queryInventory failed with message: ";
		}

		public string LGIGBJBAPCM()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)7)
			{
				return "throw_grenade_left";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string CBNEFIOMFDA()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == BOAFCAGKOJG.Universal)
			{
				return "_MAX_";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string KHHBDHJLIDM()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == BOAFCAGKOJG.Ipad)
			{
				return "ID_SAVEPERCENT";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string NPHAHAKBCCO()
		{
			BOAFCAGKOJG gGPGNNBBKPB = GGPGNNBBKPB;
			if (gGPGNNBBKPB == (BOAFCAGKOJG)6)
			{
				return "globalPlayerLeaderboard";
			}
			return Enum.GetName(typeof(BOAFCAGKOJG), GGPGNNBBKPB).ToLower();
		}

		public string KLPHADLFNAA()
		{
			return (int)IAJAILAGAKC + "ID_CONFIRM_NOSQUADACTIONS_TEXT";
		}
	}
}
