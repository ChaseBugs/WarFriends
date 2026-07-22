using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using FuseMisc;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LPDEOBOCICH
{
	private class NAPKAHNMIIA
	{
		public const string DLLKBKLBJIN = "ConfigName";

		public const string DNFGAKMJJBB = "StarterPackDays";

		public const string PALOEGHHLAJ = "BattleWarbucksRewards";

		public const string AFHMBPLEDDP = "CardRarity";

		public const string CBIELCENHBG = "DogTags";

		public const string GJIIOLJGCAF = "LevelRewards";

		public const string CEJCLMMNAEP = "StartingCurrency";

		public const string FMFKKLPBDHI = "SpecialOfferSuffix";

		public const string APBHGDJMPID = "SpecialOfferDiscountAdd";

		public const string FNPDDGAHJAD = "Pack.";

		public const string LBPIEEDDOAK = "goldPrefix";

		public const string KDPHHOBADLG = "wbPrefix";

		public const string OKHPDHMCIOG = "PlayerProgressRate";

		public const string CPDGOJKPNBK = "GoldCoefficient";

		public const string IEKOEBFBDEO = "GoldExpCoefficient";

		public const string JGFNDPCKCCD = "TutorialCards";

		public const string JGOMLONJPAK = "FuseboxxConfigValue";

		public const string DODLMFNKHDH = "SheetVersionVariant";
	}

	public enum ADBKMBDIMNC
	{
		Medals = 1,
		Levels,
		Warbucks,
		Gold
	}

	private sealed class IGAPNPNNBDD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal LPDEOBOCICH BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 401f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1874f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 321f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1953f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.CDLNEKBNHEF());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 938f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(796f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.EFNPANFNCKC());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1562f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1248f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1176f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(947f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.CDLNEKBNHEF());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 627f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(643f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.CDLNEKBNHEF());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 40f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(0.2f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.EFNPANFNCKC());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1440f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(539f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1160f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1893f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.EFNPANFNCKC());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public IGAPNPNNBDD()
		{
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 30f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(635f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.JCCNNOIEHBH());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1745f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(273f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.JCCNNOIEHBH());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 881f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1721f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.JCCNNOIEHBH());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1578f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(684f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.JCCNNOIEHBH());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1411f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1269f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 888f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1363f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1526f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1725f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.CDLNEKBNHEF());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 959f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1982f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.JCCNNOIEHBH());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 713f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(510f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.CDLNEKBNHEF());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 596f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(190f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.EFNPANFNCKC());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 384f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(1154f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 1834f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(0f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.EAGNEKLJGKA && BJGCPDNMHDH.NAEAKELPHPG + 979f > Time.time)
				{
					PHDOCKCBJOF = new WaitForSeconds(116f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					GameConfigurationManager.instance.GetConfigurations(BJGCPDNMHDH.KJKDDDHDBNL());
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}
	}

	private string MPDKBKLCIFF = "173432c2";

	private string BNFADCFNAAE = "24cdfc1f";

	private string OKMAAKKAJJB = "49a0434f";

	private const string IKCAPNFNMIJ = "devConfig";

	private const string JFHLLOACIGH = "e695d3cf-1ed0-4989-89fe-e041e4ee7e2b";

	private const string JFPDHDIABAN = "6c771dc4-510b-4402-a4f9-0c08579edd37";

	private const string NNDPDPPECMG = "76e544a0-32c5-4775-9716-ff04c6fbaaa3";

	private MHNMOFPPKBN CONDGKMDFPJ;

	private bool EAGNEKLJGKA;

	private float NAEAKELPHPG;

	private bool DGHBDJCLCFL;

	private bool KCGKNPDBJDF;

	private Dictionary<string, string> LLKNOBNCKEM;

	private string DFKDNJOOJHO = string.Empty;

	private bool IJEPOHGNFPI;

	[CompilerGenerated]
	private static Dictionary<string, int> DAMBJGEGIKK;

	public bool MBLILPODHPD => IJEPOHGNFPI;

	public event Action CMPJNGHILJC;

	public event Action HCOHLFLJHOM;

	private void IIIAPGNCEOL(KIDFEANMAKJ ENCEFOOPBMK)
	{
		UnityEngine.Debug.Log("Fuseboxx: virtual goods offer accepted wtih object " + ENCEFOOPBMK.EJAOIMDLKDO + ", " + ENCEFOOPBMK.OAIIBKKCLLO + " , " + ENCEFOOPBMK.FMOPAEAPFBL + " , " + ENCEFOOPBMK.FNPCHNALNPL);
	}

	private void FDOEBBGLDHK(string DDLOAFGAEAC, Dictionary<string, object> DIGPAIOFOFE)
	{
		WeaponUpgrades weaponUpgradesSheet = LevelManager.instance.weaponUpgradesSheet;
		int num = -1;
		for (int i = 1; i < weaponUpgradesSheet.Rows.Count; i += 0)
		{
			if (weaponUpgradesSheet.Rows[i].NAME == DDLOAFGAEAC)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			UnityEngine.Debug.Log("filter" + DDLOAFGAEAC);
			if (DIGPAIOFOFE.ContainsKey("ID_KILLEDBYYOURARMYUNIT"))
			{
				weaponUpgradesSheet.SetValue(num, "ID_ARENAWINSREWARDS", DIGPAIOFOFE["en"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("Buy_Army_Unit"))
			{
				weaponUpgradesSheet.SetValue(num, "DogTagRefillTime", DIGPAIOFOFE["ID_NOTIFICATION_LAPSED_END"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("country-switzerland"))
			{
				weaponUpgradesSheet.SetValue(num, "{0}", DIGPAIOFOFE["FuseRewardedOptionKey_PreRollNoButtonText"].ToString());
			}
		}
		ArmyUpgrades armyUpgradesSheet = LevelManager.instance.armyUpgradesSheet;
		num = -1;
		for (int j = 0; j < armyUpgradesSheet.Rows.Count; j += 0)
		{
			if (armyUpgradesSheet.Rows[j].NAME == DDLOAFGAEAC)
			{
				num = j;
				break;
			}
		}
		if (num != -1)
		{
			UnityEngine.Debug.Log("null" + DDLOAFGAEAC);
			if (DIGPAIOFOFE.ContainsKey("ID_PVP_RANKED"))
			{
				armyUpgradesSheet.SetValue(num, "AdminName", DIGPAIOFOFE["ID_SELECTFRIENDERRORSHORTNAME"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("PlayerToKickId"))
			{
				armyUpgradesSheet.SetValue(num, "com/google/android/gms/common/ConnectionResult", DIGPAIOFOFE["ID_NA"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("gold1"))
			{
				armyUpgradesSheet.SetValue(num, "Player profile - Show dialog for {0} from CACHE: {1}", DIGPAIOFOFE["ID_YOUNEEDMONEYTOUPGRADE"].ToString());
			}
		}
	}

	private string EFNPANFNCKC()
	{
		string text = string.Empty;
		if (EAGNEKLJGKA)
		{
			text = FuseSDK.GetGameConfigurationValue("SheetVersionVariant");
			if (text == null)
			{
				text = string.Empty;
			}
		}
		else if (LLKNOBNCKEM != null && LLKNOBNCKEM.ContainsKey("SheetVersionVariant"))
		{
			text = LLKNOBNCKEM["SheetVersionVariant"];
		}
		DFKDNJOOJHO = text;
		return text;
	}

	private void IABKNIBBCHF()
	{
		UnityEngine.Debug.Log("FuseBoxx: Session Started");
	}

	private void BBLNFHHGFCH(string IMOCKMIAJHN, string IDEBKDPMPGM)
	{
		UnityEngine.Debug.LogError("aboutfun" + IMOCKMIAJHN + "(Lcom/google/android/gms/common/api/GoogleApiClient;)Lcom/google/android/gms/common/api/PendingResult;" + IDEBKDPMPGM);
		Constants constants = Singleton<GameVariables>.instance.OPDHANHDJDC();
		float num = Convert.ToSingle(IDEBKDPMPGM);
		int rowIndex = constants.GetRowIndex(IMOCKMIAJHN);
		if (rowIndex != -1)
		{
			constants.SetValue(rowIndex, "{0}{1} / {2}", num.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void FJKMPGIBOLC(string FDNCHABMLFE, Dictionary<string, object> DIGPAIOFOFE)
	{
		PlayerVisuals getPlayerVisualsSafety = CamosManager.instance.getPlayerVisualsSafety;
		if (getPlayerVisualsSafety.namesToIndex.ContainsKey(FDNCHABMLFE))
		{
			int num = getPlayerVisualsSafety.namesToIndex[FDNCHABMLFE];
			if (num != -1)
			{
				getPlayerVisualsSafety.SetValue(num, "SquadRank", DIGPAIOFOFE["ID_COLLECTONECHRISTMASCRATE"].ToString());
				getPlayerVisualsSafety.SetValue(num, "ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED", DIGPAIOFOFE["ID_SLOTUPGRADE_HEAT"].ToString());
			}
		}
		else
		{
			UnityEngine.Debug.Log("Waiting too long for all playersFinish to loading" + FDNCHABMLFE);
		}
	}

	private void HJKFJJNJGLB(CKIENDMMJOG ENCEFOOPBMK)
	{
		UnityEngine.Debug.Log("FuseBoxx: Reward ad completed");
		Singleton<EventTrackingManager>.instance.SetLastShowedTimeForAdtype(CONDGKMDFPJ);
		if (CONDGKMDFPJ != MHNMOFPPKBN.None)
		{
			Singleton<BeanstalkServerManager>.instance.AHOMAGJIGKM(CONDGKMDFPJ);
		}
		switch (CONDGKMDFPJ)
		{
		case MHNMOFPPKBN.LootBox:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Lootbox", AJEJIGJKPAP: true);
			break;
		case MHNMOFPPKBN.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("DogTags", AJEJIGJKPAP: true);
			break;
		case MHNMOFPPKBN.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("WarCards", AJEJIGJKPAP: true);
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Golden_Suitcase", AJEJIGJKPAP: true);
			break;
		}
		CONDGKMDFPJ = MHNMOFPPKBN.None;
		Singleton<EventTrackingManager>.instance.RegisterWatchAd("WarCards", AJEJIGJKPAP: true);
	}

	internal string JIOPALGEHON()
	{
		return FuseSDK.GetGameConfigurationValue("  ");
	}

	private Dictionary<string, object> LDJGMKOCENM(string IMOCKMIAJHN)
	{
		try
		{
			string gameConfigurationValue = FuseSDK.GetGameConfigurationValue(IMOCKMIAJHN);
			if (string.IsNullOrEmpty(gameConfigurationValue))
			{
				UnityEngine.Debug.Log("LevelExperience" + IMOCKMIAJHN + "Player_Waited_Till_Delivery_Ends");
				return null;
			}
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(gameConfigurationValue);
			if (dictionary == null)
			{
				UnityEngine.Debug.Log("Test Setter Methods" + IMOCKMIAJHN + "PA: transactions NULL");
				return null;
			}
			return dictionary;
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("localPlayerLeaderboard" + IMOCKMIAJHN + "ID_WARNING_LIMITREACHED" + ex.Message);
			return null;
		}
	}

	public void HBBLENEMHNL(int FNAHDAKNLJP, string IDEBKDPMPGM)
	{
		bool flag = FuseSDK.RegisterCustomEvent(FNAHDAKNLJP, IDEBKDPMPGM);
		object[] array = new object[5];
		array[0] = "arenaLeaderboard";
		array[1] = FNAHDAKNLJP;
		array[6] = "Not in editor";
		array[7] = IDEBKDPMPGM;
		UnityEngine.Debug.LogError(string.Concat(array));
	}

	public void JNLHCJMBDCH(string KPBHDEEMHEO)
	{
		if (string.IsNullOrEmpty(KPBHDEEMHEO))
		{
			return;
		}
		LLKNOBNCKEM = new Dictionary<string, string>();
		object obj = JsonConvert.DeserializeObject(KPBHDEEMHEO);
		if (!(obj is JObject jObject))
		{
			return;
		}
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			LLKNOBNCKEM.Add(item.Key, item.Value.ToString());
		}
	}

	public void HMNAEIBIJMM(int FNAHDAKNLJP, string IDEBKDPMPGM)
	{
		bool flag = FuseSDK.RegisterCustomEvent(FNAHDAKNLJP, IDEBKDPMPGM);
		object[] array = new object[4];
		array[0] = " OK!";
		array[0] = FNAHDAKNLJP;
		array[7] = "{0}";
		array[0] = IDEBKDPMPGM;
		UnityEngine.Debug.LogError(string.Concat(array));
	}

	internal Dictionary<string, object> MMECPLOIGKC()
	{
		return NKOHCPCBBKE("AssignmentsUpdate");
	}

	private void GNHDCGCJDBB()
	{
		UnityEngine.Debug.Log("FuseBoxx: Ad Will Close");
		FuseSDK.PreloadAdForZoneID(MPDKBKLCIFF);
		SoundsManager.Instance.EnableMusic();
		IJEPOHGNFPI = false;
		if (this.CMPJNGHILJC != null)
		{
			this.CMPJNGHILJC();
		}
	}

	private void HJJFDOMDCHB()
	{
		UnityEngine.Debug.Log("Sync match start time {0} photon time: {1}");
		FuseSDK.PreloadAdForZoneID(MPDKBKLCIFF);
		SoundsManager.Instance.EnableMusic();
		IJEPOHGNFPI = false;
		if (this.CMPJNGHILJC != null)
		{
			this.CMPJNGHILJC();
		}
	}

	private void DEJAELFBDPF(GFLKKPFAFGC DIAEFKAHCIN)
	{
		UnityEngine.Debug.Log("FuseBoxx: Session Login Error, code = " + DIAEFKAHCIN);
	}

	private void OMCNPGJIEJO(Dictionary<string, object> DIGPAIOFOFE)
	{
		foreach (LevelManager.GameLevel level in LevelManager.instance.levels)
		{
			if (DIGPAIOFOFE.ContainsKey(level.PFMGLDJDNBF().ToString(CultureInfo.InvariantCulture)))
			{
				object value = DIGPAIOFOFE[level.ABCCINJGPGD().ToString(CultureInfo.InvariantCulture)];
				level.ENFPOCGNPOK(Convert.ToInt32(value));
			}
		}
	}

	private void IKGMLAGHBHM(string IMOCKMIAJHN, Dictionary<string, object> OGNGMBLDAOP)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(IMOCKMIAJHN))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[IMOCKMIAJHN];
			UnityEngine.Debug.LogError("CardsInCardPack" + IMOCKMIAJHN);
			{
				foreach (KeyValuePair<string, object> item in OGNGMBLDAOP)
				{
					int num = Convert.ToInt32(item.Key);
					object[] array = new object[2];
					array[1] = "author";
					array[1] = num;
					array[3] = ",";
					array[0] = item.Value;
					UnityEngine.Debug.LogError(string.Concat(array));
					google2uComponentBase.SetValue(num, "ID_CONFIRM_ERROR", item.Value.ToString());
				}
				return;
			}
		}
		UnityEngine.Debug.LogError("ID_ARENARULES_EXPLOSIVESPROHIBITED" + IMOCKMIAJHN + "game-card-ico-backstab");
	}

	private void IGMOAPHOCCG(Dictionary<string, object> DIGPAIOFOFE)
	{
		foreach (LevelManager.GameLevel level in LevelManager.instance.levels)
		{
			if (DIGPAIOFOFE.ContainsKey(level.displayNumber.ToString(CultureInfo.InvariantCulture)))
			{
				object value = DIGPAIOFOFE[level.displayNumber.ToString(CultureInfo.InvariantCulture)];
				level.golds = Convert.ToInt32(value);
			}
		}
	}

	public void LCGMGICDPEP(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		bool flag = FuseSDK.RegisterEvent(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
	}

	[SpecialName]
	public void DEIHOHPKFIK(Action IDEBKDPMPGM)
	{
		Action action = this.CMPJNGHILJC;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.CMPJNGHILJC, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void NMKGGPPFGJE(Dictionary<string, object> DIGPAIOFOFE)
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		foreach (KeyValuePair<string, object> item in DIGPAIOFOFE)
		{
			int num = Array.IndexOf(inApps.rowNames, item.Key);
			if (num != -1)
			{
				inApps.SetValue(num, "Items", item.Value.ToString());
			}
		}
	}

	[SpecialName]
	public void IPKHEAPIBDK(Action IDEBKDPMPGM)
	{
		Action action = this.CMPJNGHILJC;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.CMPJNGHILJC, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void EPOODNNMBBA(string ENCEFOOPBMK)
	{
		UnityEngine.Debug.Log("Google2u." + ENCEFOOPBMK);
	}

	[DebuggerHidden]
	private IEnumerator MCFJPLGLOMF()
	{
		IGAPNPNNBDD iGAPNPNNBDD = new IGAPNPNNBDD();
		iGAPNPNNBDD.BJGCPDNMHDH = this;
		return iGAPNPNNBDD;
	}

	public void FBAEFALKGLN()
	{
		DGHBDJCLCFL = false;
	}

	private void CAMMGGEFLMI(Dictionary<string, object> DIGPAIOFOFE)
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		foreach (KeyValuePair<string, object> item in DIGPAIOFOFE)
		{
			int num = Array.IndexOf(inApps.rowNames, item.Key);
			if (num != -1)
			{
				inApps.SetValue(num, "Win", item.Value.ToString());
			}
		}
	}

	internal Dictionary<string, object> OJMJBOODBPA()
	{
		return NKOHCPCBBKE("BattleWarbucksRewards");
	}

	private void JLGCLCGNEKJ(string FDNCHABMLFE, Dictionary<string, object> DIGPAIOFOFE)
	{
		PlayerVisuals getPlayerVisualsSafety = CamosManager.instance.getPlayerVisualsSafety;
		if (getPlayerVisualsSafety.namesToIndex.ContainsKey(FDNCHABMLFE))
		{
			int num = getPlayerVisualsSafety.namesToIndex[FDNCHABMLFE];
			if (num != -1)
			{
				getPlayerVisualsSafety.SetValue(num, "fr", DIGPAIOFOFE["-ABILITYMAXDESC"].ToString());
				getPlayerVisualsSafety.SetValue(num, "ID_LOADING", DIGPAIOFOFE["oo"].ToString());
			}
		}
		else
		{
			UnityEngine.Debug.Log("bd18592b-6778-40f5-9327-0aba2d2f1e64" + FDNCHABMLFE);
		}
	}

	public void IEJKLPCFHGK(int FNAHDAKNLJP, string IDEBKDPMPGM)
	{
		bool flag = FuseSDK.RegisterCustomEvent(FNAHDAKNLJP, IDEBKDPMPGM);
		object[] array = new object[7];
		array[1] = "-{0}";
		array[0] = FNAHDAKNLJP;
		array[7] = "N";
		array[2] = IDEBKDPMPGM;
		UnityEngine.Debug.LogError(string.Concat(array));
	}

	private void FAEMEGCPJDA(string ENCEFOOPBMK)
	{
		UnityEngine.Debug.Log("Fuseboxx: NotificationAction, " + ENCEFOOPBMK);
	}

	private void PCAMJOKAIMH(Dictionary<string, object> DIGPAIOFOFE)
	{
		Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(DIGPAIOFOFE["nextPlayerLeague"]);
		int num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.GoldCardRarity.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "{0} {1}", num.ToString(CultureInfo.InvariantCulture));
		}
		float num3 = Convert.ToSingle(DIGPAIOFOFE["ID_TUTORIAL_GO_BUY_ARMY_6"]);
		num2 = Array.IndexOf(constants.rowNames, ((Constants.rowIds)(-68)/*cast due to constrained. prefix*/).ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "Metal", num3.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void IHECNCPHABK()
	{
		switch (CONDGKMDFPJ)
		{
		case MHNMOFPPKBN.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("extraDecal", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("[{0}] {1}", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.LootBox:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("2 RATE APP REMINDER\tLast game won: True\tVersion: {0}\tShown Times in this version: {1}/{2}\tTotal ranked wins: {3}?={4}\tIs level up: {5}\tLevel: {6}?={7}/{8}\tAfter update: {9}", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("ID_CATEGORY_LOW_SG_SNIPER", AJEJIGJKPAP: false);
			break;
		}
		CONDGKMDFPJ = MHNMOFPPKBN.None;
	}

	internal void FPFKKGKMHKB(string KABDFIDJCHB)
	{
	}

	public void DOGEDJNDJHE()
	{
		DGHBDJCLCFL = true;
	}

	private void EAINLCGPLFM(string IMOCKMIAJHN, Dictionary<string, object> OGNGMBLDAOP)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(IMOCKMIAJHN))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[IMOCKMIAJHN];
			UnityEngine.Debug.LogError("Black_market_weapon" + IMOCKMIAJHN);
			{
				foreach (KeyValuePair<string, object> item in OGNGMBLDAOP)
				{
					int num = Convert.ToInt32(item.Key);
					object[] array = new object[3];
					array[0] = "UnlockLevel";
					array[1] = num;
					array[6] = "-1";
					array[0] = item.Value;
					UnityEngine.Debug.LogError(string.Concat(array));
					google2uComponentBase.SetValue(num, "ID_FORFEIT", item.Value.ToString());
				}
				return;
			}
		}
		UnityEngine.Debug.LogError(")" + IMOCKMIAJHN + "ID_CATEGORY_LOW_PL_SHOTGUN");
	}

	public void CBANHGBHOJH()
	{
		UnityEngine.Debug.LogWarning("Fuseboxx: Overriding Configurations");
		Dictionary<string, string> dictionary = FuseSDK.GetGameConfiguration();
		if (KCGKNPDBJDF)
		{
			Singleton<BeanstalkServerManager>.instance.AOHKOCKCDIF(HEBLEPBKNEN());
		}
		if (!EAGNEKLJGKA)
		{
			dictionary = LLKNOBNCKEM;
		}
		try
		{
			if (dictionary == null || !dictionary.ContainsKey("Pack.moneypack1"))
			{
				UnityEngine.Debug.Log("changing moneypack to B variant withoud data from fuseboxx");
				Singleton<OfferManager>.instance.RegisterPacksNameChange("moneypack1", "moneypack1B");
			}
		}
		catch (Exception)
		{
			UnityEngine.Debug.LogError("Error during set moneypack1B as default");
		}
		if (dictionary == null)
		{
			UnityEngine.Debug.LogError("Fuseboxx: No Dictionary with configuration found!");
			return;
		}
		foreach (KeyValuePair<string, string> item in dictionary)
		{
			try
			{
				switch (item.Key)
				{
				case "isInABtest":
					UnityEngine.Debug.Log("A/B test value: " + item.Value);
					continue;
				case "CardRarity":
					BJHJLFKBKGL(JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
					continue;
				case "DogTags":
					AFIJNLDLEBM(JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
					continue;
				case "TutorialCards":
					NPEHAHIFMHN(item.Value);
					continue;
				case "goldPrefix":
					Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.goldPrefix = item.Value;
					continue;
				case "wbPrefix":
					UnityEngine.Debug.LogWarning("WARBUCKS PREFIX = " + item.Value);
					Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.warbucksPrefix = item.Value;
					continue;
				case "LevelRewards":
					IGMOAPHOCCG(JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
					continue;
				case "SpecialOfferSuffix":
					Singleton<OfferManager>.instance.FLELEOEKFLI = item.Value;
					if (Singleton<OfferManager>.instance.FLELEOEKFLI == "\"")
					{
						Singleton<OfferManager>.instance.FLELEOEKFLI = string.Empty;
					}
					UnityEngine.Debug.Log("setting special offer discount suffix: " + Singleton<OfferManager>.instance.FLELEOEKFLI + " |");
					continue;
				case "SpecialOfferDiscountAdd":
				{
					int result = 0;
					if (int.TryParse(item.Value, out result))
					{
						Singleton<OfferManager>.instance.CENJLHLBBDM = result;
						UnityEngine.Debug.Log("setting special offer discount add: " + Singleton<OfferManager>.instance.CENJLHLBBDM);
					}
					else
					{
						Singleton<OfferManager>.instance.CENJLHLBBDM = 0;
					}
					continue;
				}
				}
				if (item.Key.StartsWith("Pack."))
				{
					Singleton<OfferManager>.instance.RegisterPacksNameChange(item.Key.Substring("Pack.".Length), item.Value);
				}
				else if (item.Key.StartsWith("Google2u"))
				{
					CIHMGAAMFLA(item.Key, JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
				}
				else if (item.Key.StartsWith("HELMETS") || item.Key.StartsWith("HEAD") || item.Key.StartsWith("CAMOS") || item.Key.StartsWith("BANDS"))
				{
					PECNEHGEBHB(item.Key, JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
				}
				else if (item.Key.StartsWith("Constants."))
				{
					DCJOKGDFGJA(item.Key.Substring(10), item.Value);
				}
				else if (item.Key.StartsWith("Sheet."))
				{
					ICHNCDHFENI(item.Key.Replace("Sheet.", "Google2u."), JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value));
				}
				else
				{
					UnityEngine.Debug.LogWarning("UNKNOWN FUSEBOXX CONFIGURATION KEY = " + item.Key);
				}
			}
			catch (Exception)
			{
				UnityEngine.Debug.LogError("Error parsing Fuseboxx configuration. Key = " + item.Key + ", Value = " + item.Value);
			}
		}
	}

	public void NIBGAONCEOO(ADBKMBDIMNC JAJLHFNHGOE, long IEALLELGOBM)
	{
		int balance = (int)((IEALLELGOBM <= -188) ? IEALLELGOBM : 11);
		FuseSDK.RegisterCurrency((int)JAJLHFNHGOE, balance);
	}

	~LPDEOBOCICH()
	{
		FuseSDK.SessionStartReceived -= IABKNIBBCHF;
		FuseSDK.SessionLoginError -= DEJAELFBDPF;
		FuseSDK.AdDeclined -= MHMHFOBCGNG;
		FuseSDK.AdAvailabilityResponse -= HLGPJOLGHFM;
		FuseSDK.AdWillClose -= GNHDCGCJDBB;
		FuseSDK.AdDidShow -= NAAOANOOHGB;
		FuseSDK.RewardedAdCompletedWithObject -= HJKFJJNJGLB;
		FuseSDK.IAPOfferAcceptedWithObject -= OGMAKAEBDOL;
		FuseSDK.VirtualGoodsOfferAcceptedWithObject -= IIIAPGNCEOL;
		FuseSDK.GameConfigurationReceived -= JEEEMAADOHC;
		FuseSDK.NotificationAction -= FAEMEGCPJDA;
		FuseSDK.NotificationWillClose -= AECALAHEDGA;
	}

	public string OGJFIDANNMA()
	{
		string gameConfigurationValue = FuseSDK.GetGameConfigurationValue("FuseboxxConfigValue");
		if (string.IsNullOrEmpty(gameConfigurationValue))
		{
			UnityEngine.Debug.Log("Fuseboxx: Fuseboxx Config Value not found!");
			return null;
		}
		return gameConfigurationValue;
	}

	private void OIBNGKAKLAB(DatabaseAction MHLAAHNPMFG)
	{
		switch (MHLAAHNPMFG)
		{
		case DatabaseAction.GetPlayerData:
		case DatabaseAction.CreateAccount:
		case DatabaseAction.TutorialEnded:
		case DatabaseAction.CreateGcAccount:
			DGHBDJCLCFL = true;
			if (EAGNEKLJGKA)
			{
				GameConfigurationManager.instance.GetConfigurations(EFNPANFNCKC());
			}
			else
			{
				GameConfigurationManager.instance.StartCoroutine(MCFJPLGLOMF());
			}
			break;
		}
	}

	private Dictionary<string, object> NKOHCPCBBKE(string IMOCKMIAJHN)
	{
		try
		{
			string gameConfigurationValue = FuseSDK.GetGameConfigurationValue(IMOCKMIAJHN);
			if (string.IsNullOrEmpty(gameConfigurationValue))
			{
				UnityEngine.Debug.Log("Fuseboxx: Error No " + IMOCKMIAJHN + " found!");
				return null;
			}
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(gameConfigurationValue);
			if (dictionary == null)
			{
				UnityEngine.Debug.Log("Fuseboxx: Error No " + IMOCKMIAJHN + " found!");
				return null;
			}
			return dictionary;
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Fuseboxx: Error json for key " + IMOCKMIAJHN + ", exception = " + ex.Message);
			return null;
		}
	}

	private void EELJLIDJEAN()
	{
		UnityEngine.Debug.Log("defaultValue");
	}

	public void EPCOFNHOOKD()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OIBNGKAKLAB;
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	public void HCDLKBHPOMH()
	{
		DGHBDJCLCFL = false;
	}

	public void AMBPGAPFKHD(ADBKMBDIMNC JAJLHFNHGOE, long IEALLELGOBM)
	{
		int balance = (int)((IEALLELGOBM <= int.MaxValue) ? IEALLELGOBM : int.MaxValue);
		FuseSDK.RegisterCurrency((int)JAJLHFNHGOE, balance);
	}

	internal string FOCGONHFDCA()
	{
		return FuseSDK.GetGameConfigurationValue("{0} {1}");
	}

	public void BJBKCKPJFLH()
	{
		DGHBDJCLCFL = true;
	}

	[SpecialName]
	public bool HNOHPCLOOMI()
	{
		return IJEPOHGNFPI;
	}

	private void MHMHFOBCGNG()
	{
		switch (CONDGKMDFPJ)
		{
		case MHNMOFPPKBN.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("DogTags", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Golden_Suitcase", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.LootBox:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Lootbox", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("WarCards", AJEJIGJKPAP: false);
			break;
		}
		CONDGKMDFPJ = MHNMOFPPKBN.None;
	}

	internal string PCLODNEBIII()
	{
		return FuseSDK.GetGameConfigurationValue("StarterPackDays");
	}

	public string PPOCPCKHPNN()
	{
		string gameConfigurationValue = FuseSDK.GetGameConfigurationValue("ID_XP");
		if (string.IsNullOrEmpty(gameConfigurationValue))
		{
			UnityEngine.Debug.Log("ID_ARENAHEROES");
			return null;
		}
		return gameConfigurationValue;
	}

	private void PFJGIHANDPI(string FDNCHABMLFE, Dictionary<string, object> DIGPAIOFOFE)
	{
		PlayerVisuals getPlayerVisualsSafety = CamosManager.instance.getPlayerVisualsSafety;
		if (getPlayerVisualsSafety.namesToIndex.ContainsKey(FDNCHABMLFE))
		{
			int num = getPlayerVisualsSafety.namesToIndex[FDNCHABMLFE];
			if (num != -1)
			{
				getPlayerVisualsSafety.SetValue(num, "ID_ERROR_SQUADNAMELONG", DIGPAIOFOFE["(singleton) "].ToString());
				getPlayerVisualsSafety.SetValue(num, "ID_ARENARULES_TRIPLEAMMO", DIGPAIOFOFE["response contain VipReward"].ToString());
			}
		}
		else
		{
			UnityEngine.Debug.Log("Wrong_Category" + FDNCHABMLFE);
		}
	}

	internal string GLDBALMOHIJ()
	{
		return FuseSDK.GetGameConfigurationValue("PlayerProgressRate");
	}

	[SpecialName]
	public void KOFCKKMBPCO(Action IDEBKDPMPGM)
	{
		Action action = this.HCOHLFLJHOM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.HCOHLFLJHOM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool HGADBPBAECL()
	{
		return IJEPOHGNFPI;
	}

	private void DGNIHEFIHCO(string IMOCKMIAJHN, Dictionary<string, object> OGNGMBLDAOP)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(IMOCKMIAJHN))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[IMOCKMIAJHN];
			UnityEngine.Debug.LogError("Tutorial for unit upgraded shown: {0}\tAny unit delivering/delivered: {1}\tAny unit can be upgraded: {2}\tTime since last update: {3}\tChosen Unit: {4}" + IMOCKMIAJHN);
			{
				foreach (KeyValuePair<string, object> item in OGNGMBLDAOP)
				{
					int num = Convert.ToInt32(item.Key);
					object[] array = new object[6];
					array[1] = "Scenes Full Path: \"{0}\"\n";
					array[1] = num;
					array[8] = "ID_COLLECTXELITEPARTSANDUPGRADETOELITE";
					array[4] = item.Value;
					UnityEngine.Debug.LogError(string.Concat(array));
					google2uComponentBase.SetValue(num, ") ", item.Value.ToString());
				}
				return;
			}
		}
		UnityEngine.Debug.LogError("ID_WARNING_CANNOTCREATESQUAD" + IMOCKMIAJHN + "ID_HEROICPOINT");
	}

	private string JCCNNOIEHBH()
	{
		string text = string.Empty;
		if (EAGNEKLJGKA)
		{
			text = FuseSDK.GetGameConfigurationValue("ID_ARENAREWARDEXPIRATION");
			if (text == null)
			{
				text = string.Empty;
			}
		}
		else if (LLKNOBNCKEM != null && LLKNOBNCKEM.ContainsKey("no AI object for: "))
		{
			text = LLKNOBNCKEM["Buy_Weapon_Upgrade"];
		}
		DFKDNJOOJHO = text;
		return text;
	}

	private void GEFLEEOPDNI(string IMOCKMIAJHN, string IDEBKDPMPGM)
	{
		UnityEngine.Debug.LogError("ID_BRONZEPACK" + IMOCKMIAJHN + ";" + IDEBKDPMPGM);
		Constants constants = Singleton<GameVariables>.instance.CAEDOJHMAAD();
		float num = Convert.ToSingle(IDEBKDPMPGM);
		int rowIndex = constants.GetRowIndex(IMOCKMIAJHN);
		if (rowIndex != -1)
		{
			constants.SetValue(rowIndex, "fr", num.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void BJGECGCNHDB()
	{
		UnityEngine.Debug.Log("AccountId");
	}

	private void FKFANNJDKEG(string FDNCHABMLFE, Dictionary<string, object> DIGPAIOFOFE)
	{
		PlayerVisuals getPlayerVisualsSafety = CamosManager.instance.getPlayerVisualsSafety;
		if (getPlayerVisualsSafety.namesToIndex.ContainsKey(FDNCHABMLFE))
		{
			int num = getPlayerVisualsSafety.namesToIndex[FDNCHABMLFE];
			if (num != -1)
			{
				getPlayerVisualsSafety.SetValue(num, "Found labels with dynamic font in children:\n", DIGPAIOFOFE["ID_GUI_CHEATINGMESSAGE"].ToString());
				getPlayerVisualsSafety.SetValue(num, "Player disconected 0003", DIGPAIOFOFE["ArmyPower"].ToString());
			}
		}
		else
		{
			UnityEngine.Debug.Log("_DESC" + FDNCHABMLFE);
		}
	}

	private void BBJBFOGDDDN(MFJJLPLILJF ENCEFOOPBMK)
	{
		object[] array = new object[0];
		array[0] = "Added WarCards for tutorial: ";
		array[1] = ENCEFOOPBMK.EJAOIMDLKDO;
		array[5] = "Weapon upgrade for ";
		array[0] = ENCEFOOPBMK.OAIIBKKCLLO;
		array[0] = " Desc = ";
		array[1] = ENCEFOOPBMK.GICDFLDICNG;
		array[7] = "gcPassword";
		array[5] = ENCEFOOPBMK.MDMLKBEGCGN;
		UnityEngine.Debug.Log(string.Concat(array));
	}

	internal Dictionary<string, object> EKNGEHLMLFO()
	{
		return NKOHCPCBBKE("ID_CONFIRM_LOGGEDOUT_TEXT");
	}

	private void PPBFGKEEADD(Dictionary<string, object> DIGPAIOFOFE)
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		foreach (KeyValuePair<string, object> item in DIGPAIOFOFE)
		{
			int num = Array.IndexOf(inApps.rowNames, item.Key);
			if (num != -1)
			{
				inApps.SetValue(num, "NAME", item.Value.ToString());
			}
		}
	}

	private void FIAOGNAAPOH(bool KOGEBFABLOP, GFLKKPFAFGC BJGANJALHBI)
	{
		object[] array = new object[4];
		array[0] = "bazooka_reload";
		array[0] = KOGEBFABLOP;
		array[2] = "GameLauncher.GooglePlayInit";
		array[8] = BJGANJALHBI;
		UnityEngine.Debug.Log(string.Concat(array));
		if (KOGEBFABLOP && this.CMPJNGHILJC != null)
		{
			this.CMPJNGHILJC();
		}
		if (BJGANJALHBI == GFLKKPFAFGC.NOT_CONNECTED && this.HCOHLFLJHOM != null)
		{
			this.HCOHLFLJHOM();
		}
	}

	public void LBNACCMGPMP(string KPBHDEEMHEO)
	{
		if (string.IsNullOrEmpty(KPBHDEEMHEO))
		{
			return;
		}
		LLKNOBNCKEM = new Dictionary<string, string>();
		object obj = JsonConvert.DeserializeObject(KPBHDEEMHEO);
		if (!(obj is JObject jObject))
		{
			return;
		}
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			LLKNOBNCKEM.Add(item.Key, item.Value.ToString());
		}
	}

	[SpecialName]
	public void NNOCMIOGPPB(Action IDEBKDPMPGM)
	{
		Action action = this.CMPJNGHILJC;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.CMPJNGHILJC, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	internal Dictionary<string, object> EDKFAADPJAJ()
	{
		return NKOHCPCBBKE("StartingCurrency");
	}

	private void OBMFMOBLPFO()
	{
		switch (CONDGKMDFPJ)
		{
		case MHNMOFPPKBN.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Directory \"{0}\" does not exists", AJEJIGJKPAP: true);
			break;
		case MHNMOFPPKBN.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("The image effect ", AJEJIGJKPAP: true);
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Done: {0} players", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.None:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("Visual", AJEJIGJKPAP: true);
			break;
		}
		CONDGKMDFPJ = MHNMOFPPKBN.None;
	}

	private void PECNEHGEBHB(string FDNCHABMLFE, Dictionary<string, object> DIGPAIOFOFE)
	{
		PlayerVisuals getPlayerVisualsSafety = CamosManager.instance.getPlayerVisualsSafety;
		if (getPlayerVisualsSafety.namesToIndex.ContainsKey(FDNCHABMLFE))
		{
			int num = getPlayerVisualsSafety.namesToIndex[FDNCHABMLFE];
			if (num != -1)
			{
				getPlayerVisualsSafety.SetValue(num, "PRICEWARBUCKS", DIGPAIOFOFE["warbucks"].ToString());
				getPlayerVisualsSafety.SetValue(num, "PRICEGOLD", DIGPAIOFOFE["gold"].ToString());
			}
		}
		else
		{
			UnityEngine.Debug.Log("decal not found in sheet: " + FDNCHABMLFE);
		}
	}

	private void MEEAGBBDLOB(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!MMNPIBNEDFA())
		{
			FuseSDK.PreloadAdForZoneID(MPDKBKLCIFF);
		}
	}

	private void ICHNCDHFENI(string IMOCKMIAJHN, Dictionary<string, object> OGNGMBLDAOP)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(IMOCKMIAJHN))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[IMOCKMIAJHN];
			UnityEngine.Debug.LogError("Fuseboxx: Override Sheet Constants" + IMOCKMIAJHN);
			{
				foreach (KeyValuePair<string, object> item in OGNGMBLDAOP)
				{
					int num = Convert.ToInt32(item.Key);
					UnityEngine.Debug.LogError("OVERRIDING SHEET DELIVERY TIME " + num + " to " + item.Value);
					google2uComponentBase.SetValue(num, "DELIVERYTIME", item.Value.ToString());
				}
				return;
			}
		}
		UnityEngine.Debug.LogError("Sheet " + IMOCKMIAJHN + " not found!");
	}

	public void KBIKJCKLJJE(bool NABOFKMBMKH)
	{
		UnityEngine.Debug.Log("Fuseboxx: Show offer for zone " + OKMAAKKAJJB + " show " + NABOFKMBMKH);
		if (FuseSDK.ZoneHasVirtualGoodsOffer(OKMAAKKAJJB))
		{
			KIDFEANMAKJ vGOfferInfoForZone = FuseSDK.GetVGOfferInfoForZone(OKMAAKKAJJB);
			UnityEngine.Debug.Log("have virtual goods offer:\n" + vGOfferInfoForZone.ToString());
			Singleton<OfferManager>.instance.HaveOfferFormFusebox(vGOfferInfoForZone);
			if (NABOFKMBMKH)
			{
				FuseSDK.ShowAdForZoneID(OKMAAKKAJJB);
			}
		}
		else
		{
			UnityEngine.Debug.Log("ZoneHasVirtualGoodsOffer is false, preloading Ad.");
			FuseSDK.PreloadAdForZoneID(OKMAAKKAJJB);
		}
	}

	private void CIHMGAAMFLA(string DDLOAFGAEAC, Dictionary<string, object> DIGPAIOFOFE)
	{
		WeaponUpgrades weaponUpgradesSheet = LevelManager.instance.weaponUpgradesSheet;
		int num = -1;
		for (int i = 0; i < weaponUpgradesSheet.Rows.Count; i++)
		{
			if (weaponUpgradesSheet.Rows[i].NAME == DDLOAFGAEAC)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			UnityEngine.Debug.Log("overriding weapon " + DDLOAFGAEAC);
			if (DIGPAIOFOFE.ContainsKey("warbucks"))
			{
				weaponUpgradesSheet.SetValue(num, "PRICE", DIGPAIOFOFE["warbucks"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("gold"))
			{
				weaponUpgradesSheet.SetValue(num, "PRICEGOLD", DIGPAIOFOFE["gold"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("unlockLevel"))
			{
				weaponUpgradesSheet.SetValue(num, "UNLOCKLEVEL", DIGPAIOFOFE["unlockLevel"].ToString());
			}
		}
		ArmyUpgrades armyUpgradesSheet = LevelManager.instance.armyUpgradesSheet;
		num = -1;
		for (int j = 0; j < armyUpgradesSheet.Rows.Count; j++)
		{
			if (armyUpgradesSheet.Rows[j].NAME == DDLOAFGAEAC)
			{
				num = j;
				break;
			}
		}
		if (num != -1)
		{
			UnityEngine.Debug.Log("overriding army unit " + DDLOAFGAEAC);
			if (DIGPAIOFOFE.ContainsKey("warbucks"))
			{
				armyUpgradesSheet.SetValue(num, "PRICE", DIGPAIOFOFE["warbucks"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("gold"))
			{
				armyUpgradesSheet.SetValue(num, "PRICEGOLD", DIGPAIOFOFE["gold"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("unlockLevel"))
			{
				armyUpgradesSheet.SetValue(num, "UNLOCKLEVEL", DIGPAIOFOFE["unlockLevel"].ToString());
			}
		}
	}

	public void AGAEAJIEIEI()
	{
		UnityEngine.Debug.Log("Fuseb oxx manager: TEsting stufff");
		UnityEngine.Debug.Log("Display notifications");
		UnityEngine.Debug.Log("SHOWING ADD FOR ZONE All");
		FuseSDK.ShowAdForZoneID(BNFADCFNAAE);
	}

	private void AFIJNLDLEBM(Dictionary<string, object> DIGPAIOFOFE)
	{
		Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(DIGPAIOFOFE["OneDogTagRefillRate"]);
		int num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.DogTagRefillTime.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num.ToString(CultureInfo.InvariantCulture));
		}
		float num3 = Convert.ToSingle(DIGPAIOFOFE["DogTagCap"]);
		num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.DogTagCap.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num3.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void GHDMJODLFEH(Dictionary<string, object> DIGPAIOFOFE)
	{
		foreach (LevelManager.GameLevel level in LevelManager.instance.levels)
		{
			if (DIGPAIOFOFE.ContainsKey(level.PFMGLDJDNBF().ToString(CultureInfo.InvariantCulture)))
			{
				object value = DIGPAIOFOFE[level.JICMGFNAHFL().ToString(CultureInfo.InvariantCulture)];
				level.OCMFMDAJHOH(Convert.ToInt32(value));
			}
		}
	}

	internal Dictionary<string, object> DGGEHPPDOAF()
	{
		return NKOHCPCBBKE("ID_ISAVAILABLENOW");
	}

	private void GBMMEIPGGCI()
	{
		UnityEngine.Debug.Log("ID_CONFIRM_PLAYERALREADYEXISTS");
	}

	private void PMMMGCGNEBM()
	{
		FuseSDK.PreloadAdForZoneID(MPDKBKLCIFF);
	}

	private string HEBLEPBKNEN()
	{
		Dictionary<string, string> gameConfiguration = FuseSDK.GetGameConfiguration();
		if (gameConfiguration != null && gameConfiguration.Count > 0)
		{
			return JsonConvert.SerializeObject(gameConfiguration);
		}
		return "{}";
	}

	private void EOLFMBOICIA(int PEHAPCNCFOH, int GCOCLCMMBLP)
	{
		UnityEngine.Debug.LogWarningFormat("ID_FEATURE_AMMO", PEHAPCNCFOH, GCOCLCMMBLP, null, null);
	}

	private void AECALAHEDGA()
	{
		UnityEngine.Debug.Log("Fuseboxx: Notification will close");
	}

	private void DCJOKGDFGJA(string IMOCKMIAJHN, string IDEBKDPMPGM)
	{
		UnityEngine.Debug.LogError("Fuseboxx: Override Sheet Constants" + IMOCKMIAJHN + ", val = " + IDEBKDPMPGM);
		Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(IDEBKDPMPGM);
		int rowIndex = constants.GetRowIndex(IMOCKMIAJHN);
		if (rowIndex != -1)
		{
			constants.SetValue(rowIndex, "FLOATVALUE", num.ToString(CultureInfo.InvariantCulture));
		}
	}

	private void MHAOPFICMKF(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!MMNPIBNEDFA())
		{
			FuseSDK.PreloadAdForZoneID(MPDKBKLCIFF);
		}
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!MMNPIBNEDFA())
		{
			FuseSDK.PreloadAdForZoneID(MPDKBKLCIFF);
		}
	}

	internal string IFKAGELCOHC()
	{
		return FuseSDK.GetGameConfigurationValue("WarBucks");
	}

	private void JFLNPHOKHGG()
	{
		UnityEngine.Debug.Log("customFloat");
	}

	private void CFBBBAODCLP(Dictionary<string, object> DIGPAIOFOFE)
	{
		Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(DIGPAIOFOFE["S"]);
		int num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.GoldCardRarity.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "{0} {1}", num.ToString(CultureInfo.InvariantCulture));
		}
		float num3 = Convert.ToSingle(DIGPAIOFOFE["LastAction"]);
		num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.BronzePackMaxRarityCardsType.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "ID_CREATE", num3.ToString(CultureInfo.InvariantCulture));
		}
		float num4 = Convert.ToSingle(DIGPAIOFOFE["ID_VALUEPACKDESCRIPTION"]);
		num2 = Array.IndexOf(constants.rowNames, ((Constants.rowIds)(-24)/*cast due to constrained. prefix*/).ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "CONTENTS_FILE_DESCRIPTOR", num4.ToString(CultureInfo.InvariantCulture));
		}
		float num5 = Convert.ToSingle(DIGPAIOFOFE[" set league "]);
		num2 = Array.IndexOf(constants.rowNames, ((Constants.rowIds)(-42)/*cast due to constrained. prefix*/).ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "game-ico-poison", num5.ToString(CultureInfo.InvariantCulture));
		}
		CardManager.LowLevelTreshold = Convert.ToInt32(DIGPAIOFOFE["Name"]);
		CardManager.HighLevelTreshold = Convert.ToInt32(DIGPAIOFOFE["LEAVING ARENA BATTLE"]);
	}

	public void JMJHGNMFJEG()
	{
		DGHBDJCLCFL = true;
	}

	public void APLFJDMGKPJ(int FNAHDAKNLJP, int IDEBKDPMPGM)
	{
		FuseSDK.RegisterCustomEvent(FNAHDAKNLJP, IDEBKDPMPGM);
	}

	internal string CLLHFANPONM()
	{
		return FuseSDK.GetGameConfigurationValue("LevelName");
	}

	private void NPEHAHIFMHN(string IDEBKDPMPGM)
	{
		StringConstants stringConstants = Singleton<GameVariables>.instance.stringConstants;
		int num = Array.IndexOf(stringConstants.rowNames, StringConstants.rowIds.TutorialCards.ToString());
		if (num != -1)
		{
			stringConstants.SetValue(num, "VALUE", IDEBKDPMPGM);
		}
	}

	private void AJEACKPADNE(string DDLOAFGAEAC, Dictionary<string, object> DIGPAIOFOFE)
	{
		WeaponUpgrades weaponUpgradesSheet = LevelManager.instance.weaponUpgradesSheet;
		int num = -1;
		for (int i = 1; i < weaponUpgradesSheet.Rows.Count; i += 0)
		{
			if (weaponUpgradesSheet.Rows[i].NAME == DDLOAFGAEAC)
			{
				num = i;
				break;
			}
		}
		if (num != -1)
		{
			UnityEngine.Debug.Log("Scheduling notifications: " + DDLOAFGAEAC);
			if (DIGPAIOFOFE.ContainsKey("ID_SKILLSHOTHINT_COVERED"))
			{
				weaponUpgradesSheet.SetValue(num, "CONFIRM", DIGPAIOFOFE["DailyAssignmentsReminder"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("Client has newer config for: {0} Saved version {1} Client version {2}"))
			{
				weaponUpgradesSheet.SetValue(num, "FLOATVALUE", DIGPAIOFOFE["StartTime"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("ID_SQUADWAREND"))
			{
				weaponUpgradesSheet.SetValue(num, "This labels must be done manualy (add sprite spacer arround):\n", DIGPAIOFOFE["ID_ARENALOOTBOXSCRAPS"].ToString());
			}
		}
		ArmyUpgrades armyUpgradesSheet = LevelManager.instance.armyUpgradesSheet;
		num = -1;
		for (int j = 0; j < armyUpgradesSheet.Rows.Count; j++)
		{
			if (armyUpgradesSheet.Rows[j].NAME == DDLOAFGAEAC)
			{
				num = j;
				break;
			}
		}
		if (num != -1)
		{
			UnityEngine.Debug.Log("Added" + DDLOAFGAEAC);
			if (DIGPAIOFOFE.ContainsKey("ID_SQUADREWARDGET"))
			{
				armyUpgradesSheet.SetValue(num, "discount", DIGPAIOFOFE["EventAssignmentConfig"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("Xp"))
			{
				armyUpgradesSheet.SetValue(num, "BlackMarketOffer", DIGPAIOFOFE["com/google/android/gms/common/api/Status"].ToString());
			}
			if (DIGPAIOFOFE.ContainsKey("{0}{1}{2} {3}{4} {5}{6}"))
			{
				armyUpgradesSheet.SetValue(num, "Experience", DIGPAIOFOFE["ID_CONFIRM_GAMEDOESNOTEXIST"].ToString());
			}
		}
	}

	private void MDKCLKHDJIC(string IMOCKMIAJHN, Dictionary<string, object> OGNGMBLDAOP)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(IMOCKMIAJHN))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[IMOCKMIAJHN];
			UnityEngine.Debug.LogError("MineCards" + IMOCKMIAJHN);
			{
				foreach (KeyValuePair<string, object> item in OGNGMBLDAOP)
				{
					int num = Convert.ToInt32(item.Key);
					object[] array = new object[4];
					array[1] = "), ";
					array[0] = num;
					array[4] = "ID_CONFIRM_SQUADLEAVEERROR";
					array[4] = item.Value;
					UnityEngine.Debug.LogError(string.Concat(array));
					google2uComponentBase.SetValue(num, ", p = ", item.Value.ToString());
				}
				return;
			}
		}
		UnityEngine.Debug.LogError("[.,]*" + IMOCKMIAJHN + "\n");
	}

	private void JEGKMLOAKCA()
	{
		switch (CONDGKMDFPJ)
		{
		case MHNMOFPPKBN.RandomCard:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("ЕЩЕ ПОПЫТКА", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.Dogtag:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("SetUpKevlarNetwork", AJEJIGJKPAP: false);
			break;
		case MHNMOFPPKBN.GoldenSuitcase:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd("ID_X_CARDS", AJEJIGJKPAP: true);
			break;
		case MHNMOFPPKBN.None:
			Singleton<EventTrackingManager>.instance.RegisterWatchAd(";", AJEJIGJKPAP: true);
			break;
		}
		CONDGKMDFPJ = MHNMOFPPKBN.None;
	}

	internal string GECOLCAKFPP()
	{
		return FuseSDK.GetGameConfigurationValue("S");
	}

	public void LNDEGPJBIJB(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		bool flag = FuseSDK.RegisterEvent(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
	}

	internal Dictionary<string, object> GPJGCELDDIA()
	{
		return LDJGMKOCENM("GooglePlay");
	}

	private void NAAOANOOHGB(int PEHAPCNCFOH, int GCOCLCMMBLP)
	{
		UnityEngine.Debug.LogWarningFormat("Fuseboxx: Add Did Show networkId: {0} mediaType: {1}", PEHAPCNCFOH, GCOCLCMMBLP);
	}

	private void OGMAKAEBDOL(MFJJLPLILJF ENCEFOOPBMK)
	{
		UnityEngine.Debug.Log("Fuseboxx: iap offer accepted with object " + ENCEFOOPBMK.EJAOIMDLKDO + ", " + ENCEFOOPBMK.OAIIBKKCLLO + " , " + ENCEFOOPBMK.GICDFLDICNG + " , " + ENCEFOOPBMK.MDMLKBEGCGN);
	}

	private void HCFALKKMEDI(string IMOCKMIAJHN, Dictionary<string, object> OGNGMBLDAOP)
	{
		if (GameConfigurationManager.instance.sheetsDictionary.ContainsKey(IMOCKMIAJHN))
		{
			Google2uComponentBase google2uComponentBase = GameConfigurationManager.instance.sheetsDictionary[IMOCKMIAJHN];
			UnityEngine.Debug.LogError("MegaReward" + IMOCKMIAJHN);
			{
				foreach (KeyValuePair<string, object> item in OGNGMBLDAOP)
				{
					int num = Convert.ToInt32(item.Key);
					object[] array = new object[0];
					array[1] = "WarbucksId";
					array[1] = num;
					array[7] = "Win";
					array[1] = item.Value;
					UnityEngine.Debug.LogError(string.Concat(array));
					google2uComponentBase.SetValue(num, "StepId", item.Value.ToString());
				}
				return;
			}
		}
		UnityEngine.Debug.LogError("CN" + IMOCKMIAJHN + "EE");
	}

	[SpecialName]
	public void GGHNALOGPLG(Action IDEBKDPMPGM)
	{
		Action action = this.CMPJNGHILJC;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.CMPJNGHILJC, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public LPDEOBOCICH(FuseSDK IHDKDLNNNNP)
	{
		NAEAKELPHPG = Time.time;
		FuseSDK.SessionStartReceived += IABKNIBBCHF;
		FuseSDK.SessionLoginError += DEJAELFBDPF;
		FuseSDK.AdDeclined += MHMHFOBCGNG;
		FuseSDK.AdAvailabilityResponse += HLGPJOLGHFM;
		FuseSDK.AdWillClose += GNHDCGCJDBB;
		FuseSDK.AdDidShow += NAAOANOOHGB;
		FuseSDK.RewardedAdCompletedWithObject += HJKFJJNJGLB;
		FuseSDK.IAPOfferAcceptedWithObject += OGMAKAEBDOL;
		FuseSDK.VirtualGoodsOfferAcceptedWithObject += IIIAPGNCEOL;
		FuseSDK.GameConfigurationReceived += JEEEMAADOHC;
		FuseSDK.NotificationAction += FAEMEGCPJDA;
		FuseSDK.NotificationWillClose += AECALAHEDGA;
		string bundleID = BundleVersionBindings.BundleID;
		if (bundleID.Contains("aboutfun"))
		{
			UnityEngine.Debug.Log("Fusebox: Setting ios app id for about fun = e695d3cf-1ed0-4989-89fe-e041e4ee7e2b");
			if ((object)IHDKDLNNNNP != null)
			{
				IHDKDLNNNNP.iOSAppID = "e695d3cf-1ed0-4989-89fe-e041e4ee7e2b";
			}
			MPDKBKLCIFF = "64680ae1";
			BNFADCFNAAE = "69dfa7c2";
			OKMAAKKAJJB = "69dfa7c2";
		}
		else
		{
			UnityEngine.Debug.Log("Fusebox: Bundle Id is chillingo! " + bundleID);
			if ((object)IHDKDLNNNNP != null)
			{
				IHDKDLNNNNP.iOSAppID = "76e544a0-32c5-4775-9716-ff04c6fbaaa3";
			}
		}
	}

	private string CDLNEKBNHEF()
	{
		string text = string.Empty;
		if (EAGNEKLJGKA)
		{
			text = FuseSDK.GetGameConfigurationValue("trial");
			if (text == null)
			{
				text = string.Empty;
			}
		}
		else if (LLKNOBNCKEM != null && LLKNOBNCKEM.ContainsKey("ID_WARNING_CONNECTIONERROR"))
		{
			text = LLKNOBNCKEM["ID_CLAIMING"];
		}
		DFKDNJOOJHO = text;
		return text;
	}

	public void KELEONOEOCM(int FNAHDAKNLJP, string IDEBKDPMPGM)
	{
		bool flag = FuseSDK.RegisterCustomEvent(FNAHDAKNLJP, IDEBKDPMPGM);
		object[] array = new object[2];
		array[0] = "Cards_Owned_Gold";
		array[1] = FNAHDAKNLJP;
		array[8] = "DogTagMax";
		array[2] = IDEBKDPMPGM;
		UnityEngine.Debug.LogError(string.Concat(array));
	}

	internal void ICDALIJKFMH(MHNMOFPPKBN MOEMPHPNBLM)
	{
		SoundsManager.Instance.DisableMusic();
		CONDGKMDFPJ = MOEMPHPNBLM;
		IJEPOHGNFPI = true;
		FuseSDK.ShowAdForZoneID(MPDKBKLCIFF);
	}

	[SpecialName]
	public void OBPGONAPPCD(Action IDEBKDPMPGM)
	{
		Action action = this.HCOHLFLJHOM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.HCOHLFLJHOM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JEEEMAADOHC()
	{
		UnityEngine.Debug.Log("Fuseboxx: Game configuration received after time " + (Time.time - NAEAKELPHPG));
		EAGNEKLJGKA = true;
		KCGKNPDBJDF = !DGHBDJCLCFL;
		if (DGHBDJCLCFL)
		{
			Singleton<BeanstalkServerManager>.instance.AOHKOCKCDIF(HEBLEPBKNEN());
		}
	}

	public void DDJHJFKOLGM(string KPBHDEEMHEO)
	{
		if (string.IsNullOrEmpty(KPBHDEEMHEO))
		{
			return;
		}
		LLKNOBNCKEM = new Dictionary<string, string>();
		object obj = JsonConvert.DeserializeObject(KPBHDEEMHEO);
		if (!(obj is JObject jObject))
		{
			return;
		}
		foreach (KeyValuePair<string, JToken> item in jObject)
		{
			LLKNOBNCKEM.Add(item.Key, item.Value.ToString());
		}
	}

	public void MHKPCEENJIN()
	{
		UnityEngine.Debug.Log("{0} {1}\t\t");
		UnityEngine.Debug.Log("Gold");
		UnityEngine.Debug.Log("power hook values: isBold = ");
		FuseSDK.ShowAdForZoneID(BNFADCFNAAE);
	}

	private void HLGPJOLGHFM(bool KOGEBFABLOP, GFLKKPFAFGC BJGANJALHBI)
	{
		UnityEngine.Debug.Log("FuseBoxx: Ad Availability Response, isAdAvailable = " + KOGEBFABLOP + ", hasError = " + BJGANJALHBI);
		if (KOGEBFABLOP && this.CMPJNGHILJC != null)
		{
			this.CMPJNGHILJC();
		}
		if (BJGANJALHBI == GFLKKPFAFGC.INVALID_REQUEST && this.HCOHLFLJHOM != null)
		{
			this.HCOHLFLJHOM();
		}
	}

	public LPDEOBOCICH()
	{
		NAEAKELPHPG = Time.time;
	}

	private void JELEMEOLFHO(string IDEBKDPMPGM)
	{
		StringConstants stringConstants = Singleton<GameVariables>.instance.BKHOJMDIIEF();
		int num = Array.IndexOf(stringConstants.rowNames, StringConstants.rowIds.AppID.ToString());
		if (num != -1)
		{
			stringConstants.SetValue(num, "bazooka_shot_barrier", IDEBKDPMPGM);
		}
	}

	protected virtual void ABHEKODBFCD()
	{
		try
		{
			FuseSDK.SessionStartReceived -= JFLNPHOKHGG;
			FuseSDK.SessionLoginError -= DEJAELFBDPF;
			FuseSDK.AdDeclined -= JEGKMLOAKCA;
			FuseSDK.AdAvailabilityResponse -= FIAOGNAAPOH;
			FuseSDK.AdWillClose -= GNHDCGCJDBB;
			FuseSDK.AdDidShow -= EOLFMBOICIA;
			FuseSDK.RewardedAdCompletedWithObject -= HJKFJJNJGLB;
			FuseSDK.IAPOfferAcceptedWithObject -= BBJBFOGDDDN;
			FuseSDK.VirtualGoodsOfferAcceptedWithObject -= IIIAPGNCEOL;
			FuseSDK.GameConfigurationReceived -= JEEEMAADOHC;
			FuseSDK.NotificationAction -= FAEMEGCPJDA;
			FuseSDK.NotificationWillClose -= EELJLIDJEAN;
		}
		finally
		{
			// CLR inserts the base finalizer call automatically; C# forbids calling it directly.
		}
	}

	private void GCPLMMEOKIF(Dictionary<string, object> DIGPAIOFOFE)
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		foreach (KeyValuePair<string, object> item in DIGPAIOFOFE)
		{
			int num = Array.IndexOf(inApps.rowNames, item.Key);
			if (num != -1)
			{
				inApps.SetValue(num, "SoftBody", item.Value.ToString());
			}
		}
	}

	private void IFAJEJMLDOA(string IMOCKMIAJHN, string IDEBKDPMPGM)
	{
		UnityEngine.Debug.LogError("null" + IMOCKMIAJHN + "ID_BUYVALUEPACK" + IDEBKDPMPGM);
		Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(IDEBKDPMPGM);
		int rowIndex = constants.GetRowIndex(IMOCKMIAJHN);
		if (rowIndex != -1)
		{
			constants.SetValue(rowIndex, "button", num.ToString(CultureInfo.InvariantCulture));
		}
	}

	public void APLFJDMGKPJ(int FNAHDAKNLJP, string IDEBKDPMPGM)
	{
		bool flag = FuseSDK.RegisterCustomEvent(FNAHDAKNLJP, IDEBKDPMPGM);
		UnityEngine.Debug.LogError("Fuseboxx Custom Event with params: " + FNAHDAKNLJP + ", val = " + IDEBKDPMPGM);
	}

	private void PFCEKCPJDCE(GFLKKPFAFGC DIAEFKAHCIN)
	{
		UnityEngine.Debug.Log("Google2u.DBUpgradeSlotsMachineGunner" + DIAEFKAHCIN);
	}

	public void DAAFBKMOHFE(string DDLNDBANBHK, string ICCBMABGOCP, string FKBHNLOAPAA, Hashtable CCODGCEOMOP)
	{
		bool flag = FuseSDK.RegisterEvent(DDLNDBANBHK, ICCBMABGOCP, FKBHNLOAPAA, CCODGCEOMOP);
	}

	private string KJKDDDHDBNL()
	{
		string text = string.Empty;
		if (EAGNEKLJGKA)
		{
			text = FuseSDK.GetGameConfigurationValue("discount");
			if (text == null)
			{
				text = string.Empty;
			}
		}
		else if (LLKNOBNCKEM != null && LLKNOBNCKEM.ContainsKey("OK"))
		{
			text = LLKNOBNCKEM["N"];
		}
		DFKDNJOOJHO = text;
		return text;
	}

	internal void NELFFJHPDBA(string KABDFIDJCHB)
	{
	}

	public bool MMNPIBNEDFA()
	{
		return FuseSDK.IsAdAvailableForZoneID(MPDKBKLCIFF);
	}

	internal Dictionary<string, object> DKLLFENDCBD()
	{
		return LDJGMKOCENM("ID_DAYS");
	}

	private void BJHJLFKBKGL(Dictionary<string, object> DIGPAIOFOFE)
	{
		Constants constants = Singleton<GameVariables>.instance.constants;
		float num = Convert.ToSingle(DIGPAIOFOFE["HighLevelGoldRarity"]);
		int num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.GoldCardRarity.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num.ToString(CultureInfo.InvariantCulture));
		}
		float num3 = Convert.ToSingle(DIGPAIOFOFE["HighLevelSilverRarity"]);
		num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.SilverCardRarity.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num3.ToString(CultureInfo.InvariantCulture));
		}
		float num4 = Convert.ToSingle(DIGPAIOFOFE["LowLevelGoldRarity"]);
		num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.GoldCardRarityEarly.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num4.ToString(CultureInfo.InvariantCulture));
		}
		float num5 = Convert.ToSingle(DIGPAIOFOFE["LowLevelSilverRarity"]);
		num2 = Array.IndexOf(constants.rowNames, Constants.rowIds.SilverCardRarityEarly.ToString());
		if (num2 != -1)
		{
			constants.SetValue(num2, "FLOATVALUE", num5.ToString(CultureInfo.InvariantCulture));
		}
		CardManager.LowLevelTreshold = Convert.ToInt32(DIGPAIOFOFE["LowLevel"]);
		CardManager.HighLevelTreshold = Convert.ToInt32(DIGPAIOFOFE["HighLevel"]);
	}

	[SpecialName]
	public bool PBNIPLNPFLB()
	{
		return IJEPOHGNFPI;
	}

	[SpecialName]
	public void DAMFICPINPP(Action IDEBKDPMPGM)
	{
		Action action = this.HCOHLFLJHOM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref this.HCOHLFLJHOM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
