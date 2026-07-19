using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntroductionDealsArenaPromo : IntroductionDealsItem
{
	private sealed class ALALGMLIHDF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int PFEALMFFKCD;

		internal int ANFHGBKIAFJ;

		internal int KNNDOOAHBEL;

		internal float NEGCOHHNOMG;

		internal IntroductionDealsArenaPromo BJGCPDNMHDH;

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

		public void FMINPCPGBBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONLMGMBKGHI()
		{
			return PHDOCKCBJOF;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("StartFlying", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "realShotProbability", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("ID_WARNING_FAILDOWNLOADINGASSET", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 765f + 1010f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1486f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_SALEPERCENT", string.Empty);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("\t\"TRUE\"", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "Bought VIP - ", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 338f + 274f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.LEGGHEEMAHI();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1496f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EBAGFJMHLCB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("TEXTURE SIZE IS: ", MEJMLNDFDBP.CJCFPDLDMEK(num, "vipExpire", string.Empty, false));
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_STAT_HANDGUNKILLS", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("Play_Card_Tutorial_Duration", array);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 714f + 1027f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(134f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "(Landroid/app/Activity;I)V", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("{ \"S\": \"", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "helicopter_jump_pose", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("Total_Battles", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 870f + 1381f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.MKHMKIKNAKP();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1146f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object OJMKDIBHMND()
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
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("WALLET - bought GOLD {0}", MEJMLNDFDBP.CJCFPDLDMEK(num, "Cancel - Disconnect, clicked in dialog !!!", string.Empty));
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "Gold", string.Empty);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", array);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 1423f + 1271f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(246f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public bool ACHIHMMCDNF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CONFIRM_SQUADISNOTPUBLIC_TEXT", string.Empty);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_LOCAL", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "BestSkill", string.Empty, false);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("Wrong_Unit", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 1097f + 463f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.LEGGHEEMAHI();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1033f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "BS: Update Army Power", string.Empty);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("SquadRank", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("damage", MEJMLNDFDBP.CJCFPDLDMEK(num2, "' already destroyed on application quit. Won't create again - returning null.", string.Empty));
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 575f + 1120f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.MKHMKIKNAKP();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(142f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "BAND_TYPE_HEALTH", string.Empty);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_CONFIRM_LOGINFAILURE_TEXT", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "BlackMarketOffer", string.Empty, false);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("Id", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 1547f + 917f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1754f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void HMFGNEKJDKH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NEPEDBPDMGL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("ID_SECONDS", MEJMLNDFDBP.CJCFPDLDMEK(num, "getIAPOfferInfoForZoneID", string.Empty, false));
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("DebugLog", MEJMLNDFDBP.CJCFPDLDMEK(num2, "guestPassword", string.Empty));
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 1850f + 1508f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(827f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void GHILCKCFAFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("ID_ARENAPROMOSTARTSIN", MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty));
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("ID_ARENAPROMOENDSIN", MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_READYTIME", string.Empty));
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 2f + 18f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void GPJGKJCDFOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "Init cards : ", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_TUTORIAL_PROGRESS_KILLING2", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "WALLET - initialization GOLD {0}", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("game-card-ico-belovedenemy", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 582f + 1860f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1732f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FHOGCOKPBKL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ArenaOpenedMessage", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_REGULARPRIZE", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("r", MEJMLNDFDBP.CJCFPDLDMEK(num2, "loadPlayerStats", string.Empty));
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 418f + 289f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1068f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("CONFIRM", MEJMLNDFDBP.CJCFPDLDMEK(num, "BUDDY WARCARD", string.Empty, false));
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "Problem for max! in army/weapon stats", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_UNIT2UPGRADEABILITY_UNIT1ABILITYUPGRADE", array);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 530f + 1425f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.NHLEKBIHDAL())
				{
					WarArena.instance.MKHMKIKNAKP();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(334f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FNCEOCMMGKH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMGAHAGANGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					BJGCPDNMHDH.GAJKKHFAOMM.text = Localization.LocalizeFormat("_N", MEJMLNDFDBP.CJCFPDLDMEK(num, "PromotedPlayer", string.Empty, false));
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, " (", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("Your Best", array);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 639f + 1393f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.NHLEKBIHDAL())
				{
					WarArena.instance.LEGGHEEMAHI();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1617f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_CONTINUETOBOOTCAMP2", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("Directory \"{0}\" does not exists", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[0] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_COOPCANCELED", string.Empty, false);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("ID_STARTERASSIGNMENT", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 623f + 1472f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.NHLEKBIHDAL())
				{
					WarArena.instance.LEGGHEEMAHI();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1493f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HNBFJFDLABI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[0] = MEJMLNDFDBP.CJCFPDLDMEK(num, "RETRY", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_CARD_DESC_BUDDYCREATE", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "RealMoney", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("'Offer '0", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 1115f + 1640f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.BALABLIGAHK())
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(769f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "Start TUTORIAL", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("Enemy could not be spawned", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[1];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "ID_ERROR_SQUADNAMENOTUNIQUE", string.Empty, false);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("LastAction", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 101f + 1623f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.LEGGHEEMAHI();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1596f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		public void FAOLFOHEEGF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ADALFCHPIAH()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OGHGAAFEEMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public ALALGMLIHDF()
		{
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM : 0);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[0];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "LeagueId", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("SystemMessage", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "GC Name Is Missing, not showing dialog to change the name!", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("getOriginalAccountType", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 428f + 1638f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.TryGetNewArena();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1938f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				PFEALMFFKCD = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
				ANFHGBKIAFJ = ((WarArena.instance.FPLIPHCJGFO == null) ? 1 : WarArena.instance.FPLIPHCJGFO.JGBFNKBFCKM);
				KNNDOOAHBEL = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NGPMJNJPNMB : 0);
				if (PFEALMFFKCD < ANFHGBKIAFJ)
				{
					int num = ANFHGBKIAFJ - PFEALMFFKCD;
					UILabel gAJKKHFAOMM = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array = new object[1];
					array[1] = MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_FEATURE_DAMAGE-DESCRIPTION", string.Empty, false);
					gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_CONFIRM_OFFERTOOSHORTDURATION", array);
				}
				else if (PFEALMFFKCD < KNNDOOAHBEL)
				{
					int num2 = KNNDOOAHBEL - PFEALMFFKCD;
					UILabel gAJKKHFAOMM2 = BJGCPDNMHDH.GAJKKHFAOMM;
					object[] array2 = new object[0];
					array2[1] = MEJMLNDFDBP.CJCFPDLDMEK(num2, "S", string.Empty);
					gAJKKHFAOMM2.text = Localization.LocalizeFormat("ID_VISUALCATEGORY0", array2);
				}
				else
				{
					BJGCPDNMHDH.GAJKKHFAOMM.text = string.Empty;
				}
				NEGCOHHNOMG = BJGCPDNMHDH.GAJKKHFAOMM.relativeSize.x * BJGCPDNMHDH.GAJKKHFAOMM.transform.localScale.x / 95f + 1817f;
				BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition = BJGCPDNMHDH.MHKEBMNCCEO.transform.localPosition.ReplaceX(0f - NEGCOHHNOMG);
				BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition = BJGCPDNMHDH.MNGKIFNOOAF.transform.localPosition.ReplaceX(NEGCOHHNOMG);
				if (WarArena.instance.isExpired)
				{
					WarArena.instance.MKHMKIKNAKP();
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1349f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	[Header("Arena promo")]
	public Collider PMAOBDMEKFD;

	public UISprite NACGOGCPIAH;

	public UILabel GAJKKHFAOMM;

	public GameObject MHKEBMNCCEO;

	public GameObject MNGKIFNOOAF;

	private bool POAMPPJOGEG;

	private bool FMFKLFMGFAO;

	private RadicalRoutine CEJADCIHCAA;

	public virtual IEnumerator FPOIGOFDIPF(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA = RadicalRoutine.Create(EAOBLKFJKGK());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.ONCKKJFAMKF(KBJEOEEOEFG);
	}

	public virtual IEnumerator LCCEEAMLHDD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			CEJADCIHCAA = RadicalRoutine.Create(MMLFHIBFDNC());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.LOFMDBHAFAO(KBJEOEEOEFG);
	}

	private IEnumerator MMLFHIBFDNC()
	{
		ALALGMLIHDF aLALGMLIHDF = new ALALGMLIHDF();
		aLALGMLIHDF.BJGCPDNMHDH = this;
		return aLALGMLIHDF;
	}

	private void AKGEHCOMPID(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((!WarArena.instance.DANDNHJBJKB() || !WarArena.instance.PBGAHILNNAH()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		KEMGNNCHGDA(1292f);
	}

	public virtual void PLDAPLOGJPA()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOOCOOEELOG));
		WarArena.instance.WarArenaDataChanged += PHHEMAIAHJP;
	}

	public virtual IEnumerator BHGDOHCBGEC(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA = RadicalRoutine.Create(MJFPDFAAOFO());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	public virtual IEnumerator NNPILDOKNJO(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA = RadicalRoutine.Create(HAFHOMGBCOF());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	public virtual IEnumerator NOGIKDILBLG(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			CEJADCIHCAA.Cancel();
		}
		return base.Hide(KBJEOEEOEFG);
	}

	[DebuggerHidden]
	private IEnumerator LLEFNDKGOEK()
	{
		ALALGMLIHDF aLALGMLIHDF = new ALALGMLIHDF();
		aLALGMLIHDF.BJGCPDNMHDH = this;
		return aLALGMLIHDF;
	}

	private void EEKILNLDANN()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			NIONDNKMBBE();
		}
	}

	public virtual bool BBKCNKAIGKA()
	{
		return LevelManager.instance.isWarArenaLocked || WarArena.instance.isOpened || WarArena.instance.HBIJKMFFLEB();
	}

	public virtual void IKHPOKNAGGN()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AADMKIJPNJB));
		WarArena.instance.WarArenaDataChanged += EEKILNLDANN;
	}

	public virtual IEnumerator OHJAAIJDAAG(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			CEJADCIHCAA = RadicalRoutine.Create(MJFPDFAAOFO());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	public override IEnumerator Hide(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			CEJADCIHCAA.Cancel();
		}
		return base.Hide(KBJEOEEOEFG);
	}

	public virtual void ILAKIPADMBI()
	{
		base.KBALFNMGIOA();
		NIONDNKMBBE();
		LevelBehaviour levelBehaviour = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.NEANBBHLPNB() : null);
		bool flag = levelBehaviour != null;
		NACGOGCPIAH.gameObject.SetActive(flag);
		if (flag)
		{
			NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconNameElite;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(104f / NACGOGCPIAH.transform.localScale.x, 1424f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private void NDFGJICIBBJ(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((!WarArena.instance.DANDNHJBJKB() || !WarArena.instance.PBGAHILNNAH()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		HBDJGAKINJN(1504f);
	}

	private IEnumerator AAOAJADLFCA()
	{
		ALALGMLIHDF aLALGMLIHDF = new ALALGMLIHDF();
		aLALGMLIHDF.BJGCPDNMHDH = this;
		return aLALGMLIHDF;
	}

	private void AADMKIJPNJB(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.NEOPPEENNFN((WarArena.instance.DANDNHJBJKB() && WarArena.instance.PBGAHILNNAH()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		KEMGNNCHGDA(1806f);
	}

	public override void FCIANKCBLKM()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HNCDPMIDJNJ));
		WarArena.instance.WarArenaDataChanged += EEKILNLDANN;
	}

	public virtual IEnumerator DIBLFOPCCPL(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA = RadicalRoutine.Create(LLEFNDKGOEK());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.Show(KBJEOEEOEFG);
	}

	public virtual bool JCBOBBGNEHC()
	{
		return !LevelManager.instance.isWarArenaLocked && (WarArena.instance.PBGAHILNNAH() || WarArena.instance.HBIJKMFFLEB());
	}

	public virtual bool OGLLHJLBLCE()
	{
		return !LevelManager.instance.isWarArenaLocked && (WarArena.instance.PBGAHILNNAH() || WarArena.instance.isReminderTime);
	}

	public virtual IEnumerator BNMBJJLAMIE(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA.Cancel();
		}
		return base.NDODOLKAABG(KBJEOEEOEFG);
	}

	public override bool IsAvailable()
	{
		return !LevelManager.instance.isWarArenaLocked && (WarArena.instance.isOpened || WarArena.instance.isReminderTime);
	}

	private void LIPFAOEKFJD(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.FIIIKMNODJA((!WarArena.instance.isArenaTicketBought || !WarArena.instance.isOpened) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		LDNOPACODIP(616f);
	}

	public virtual bool AMAIBGKCGJE()
	{
		return !LevelManager.instance.isWarArenaLocked && !WarArena.instance.PBGAHILNNAH() && WarArena.instance.HBIJKMFFLEB();
	}

	private void HNCDPMIDJNJ(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.NEOPPEENNFN((!WarArena.instance.isArenaTicketBought || !WarArena.instance.isOpened) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		KEMGNNCHGDA(1848f);
	}

	public virtual IEnumerator DCGAEALINHD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA.Cancel();
		}
		return base.EPCEHACNCNH(KBJEOEEOEFG);
	}

	public virtual bool DCPHNLOFHDL()
	{
		return LevelManager.instance.isWarArenaLocked || (!WarArena.instance.isOpened && WarArena.instance.HBIJKMFFLEB());
	}

	private void KJMPFFLMAML()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			BJPABDDHCHP(0.5f);
			PMAOBDMEKFD.enabled = false;
		}
	}

	public virtual IEnumerator JIMPCGDILNF(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA.Cancel();
		}
		return base.GDLOAPIHMOB(KBJEOEEOEFG);
	}

	public virtual bool FNKPEPINEIL()
	{
		return !LevelManager.instance.isWarArenaLocked && (WarArena.instance.PBGAHILNNAH() || WarArena.instance.HBIJKMFFLEB());
	}

	private void PHHEMAIAHJP()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			NIONDNKMBBE();
		}
	}

	public virtual IEnumerator DFJBBKKIPAD(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			CEJADCIHCAA = RadicalRoutine.Create(AAOAJADLFCA());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.LOFMDBHAFAO(KBJEOEEOEFG);
	}

	private void NIONDNKMBBE()
	{
		POAMPPJOGEG = IsAvailable();
		if (!POAMPPJOGEG)
		{
			BJPABDDHCHP(1092f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	private IEnumerator EAOBLKFJKGK()
	{
		ALALGMLIHDF aLALGMLIHDF = new ALALGMLIHDF();
		aLALGMLIHDF.BJGCPDNMHDH = this;
		return aLALGMLIHDF;
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		KJMPFFLMAML();
		LevelBehaviour levelBehaviour = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.EJPOKHDDJBO : null);
		bool flag = levelBehaviour != null;
		NACGOGCPIAH.gameObject.SetActive(flag);
		if (flag)
		{
			NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconNameElite;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(140f / NACGOGCPIAH.transform.localScale.x, 120f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		}
	}

	public override IEnumerator Show(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA = RadicalRoutine.Create(LLEFNDKGOEK());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.Show(KBJEOEEOEFG);
	}

	private void DALAEBGGCPE(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.OCDINHEFBDG((WarArena.instance.DANDNHJBJKB() && WarArena.instance.isOpened) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		BJPABDDHCHP(891f);
	}

	private void JOLLGAIILKF(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.ShowWarArena((WarArena.instance.isArenaTicketBought && WarArena.instance.isOpened) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		BJPABDDHCHP(0.5f);
	}

	private void KELDCNBCIKF(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.FIIIKMNODJA((!WarArena.instance.isArenaTicketBought || !WarArena.instance.PBGAHILNNAH()) ? ArenaScreen.BGMNNKDJBEK.EnterArena : ArenaScreen.BGMNNKDJBEK.EnterArena);
		KEMGNNCHGDA(1735f);
	}

	public virtual void PBKJDKFPILH()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DALAEBGGCPE));
		WarArena.instance.WarArenaDataChanged += GLACDMMMMFF;
	}

	private void FKGBGPJKIEI(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.FIIIKMNODJA((!WarArena.instance.DANDNHJBJKB() || !WarArena.instance.PBGAHILNNAH()) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		BJPABDDHCHP(1743f);
	}

	private IEnumerator HAFHOMGBCOF()
	{
		ALALGMLIHDF aLALGMLIHDF = new ALALGMLIHDF();
		aLALGMLIHDF.BJGCPDNMHDH = this;
		return aLALGMLIHDF;
	}

	public virtual bool GCFHMHOJOBG()
	{
		return LevelManager.instance.isWarArenaLocked || WarArena.instance.isOpened || WarArena.instance.HBIJKMFFLEB();
	}

	public virtual bool DJKMCHDCPAE()
	{
		return LevelManager.instance.isWarArenaLocked || (!WarArena.instance.isOpened && WarArena.instance.isReminderTime);
	}

	private void GLACDMMMMFF()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			KJMPFFLMAML();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOLLGAIILKF));
		WarArena.instance.WarArenaDataChanged += GLACDMMMMFF;
	}

	public virtual void LKFKKLKCALK()
	{
		base.InitEvents();
		PMAOBDMEKFD.enabled = true;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AADMKIJPNJB));
		WarArena.instance.WarArenaDataChanged += GLACDMMMMFF;
	}

	public override void KBALFNMGIOA()
	{
		base.AAEDAJEEGDD();
		INMLEHMCFIC();
		LevelBehaviour levelBehaviour = ((WarArena.instance.FPLIPHCJGFO != null) ? WarArena.instance.FPLIPHCJGFO.MHHGOMNOBPB() : null);
		bool flag = levelBehaviour != null;
		NACGOGCPIAH.gameObject.SetActive(flag);
		if (flag)
		{
			NACGOGCPIAH.spriteName = levelBehaviour.upgradeSlots.iconNameElite;
			NACGOGCPIAH.MakePixelPerfect();
			float multiplier = Mathf.Min(1838f / NACGOGCPIAH.transform.localScale.x, 847f / NACGOGCPIAH.transform.localScale.y);
			NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		}
	}

	private IEnumerator MJFPDFAAOFO()
	{
		ALALGMLIHDF aLALGMLIHDF = new ALALGMLIHDF();
		aLALGMLIHDF.BJGCPDNMHDH = this;
		return aLALGMLIHDF;
	}

	public virtual IEnumerator HONPFADFFDP(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = false;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			CEJADCIHCAA = RadicalRoutine.Create(EAOBLKFJKGK());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.DMLDBKFCACB(KBJEOEEOEFG);
	}

	private void JOOCOOEELOG(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<ArenaScreen>.instance.NEOPPEENNFN((!WarArena.instance.DANDNHJBJKB() || !WarArena.instance.isOpened) ? ArenaScreen.BGMNNKDJBEK.MainArena : ArenaScreen.BGMNNKDJBEK.MainArena);
		KEMGNNCHGDA(1198f);
	}

	private void ABEIKFJAFND()
	{
		POAMPPJOGEG = EOJDPCMGMBP();
		if (!POAMPPJOGEG)
		{
			LDNOPACODIP(1462f);
			PMAOBDMEKFD.enabled = true;
		}
	}

	public virtual void GEIMJABJIBF()
	{
		base.FCIANKCBLKM();
		PMAOBDMEKFD.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(PMAOBDMEKFD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JOOCOOEELOG));
		WarArena.instance.WarArenaDataChanged += EEKILNLDANN;
	}

	public virtual IEnumerator JIILFGDJFPP(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA.Cancel();
		}
		return base.EPCEHACNCNH(KBJEOEEOEFG);
	}

	private void INMLEHMCFIC()
	{
		POAMPPJOGEG = LHFOMPDODJC();
		if (!POAMPPJOGEG)
		{
			LDNOPACODIP(1487f);
			PMAOBDMEKFD.enabled = false;
		}
	}

	public virtual IEnumerator JOGFDHFOOBC(float KBJEOEEOEFG)
	{
		PMAOBDMEKFD.enabled = true;
		if (!FMFKLFMGFAO)
		{
			FMFKLFMGFAO = true;
			CEJADCIHCAA = RadicalRoutine.Create(LLEFNDKGOEK());
			StartCoroutine(RadicalRoutine.Run(CEJADCIHCAA.enumerator));
		}
		return base.ONCKKJFAMKF(KBJEOEEOEFG);
	}
}
