using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BattlePreparationWeaponButton : Core_BaseScript
{
	private sealed class OMCPKICPEMF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal BattlePreparationWeaponButton BJGCPDNMHDH;

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

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 139.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FKPOIINIBOA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(1690f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1103f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered) ? "ABOUT TO SHOW VIP CARDS" : "playerId");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 413f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 417f, 725f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 971.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.LFCDNEILLMA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(1737f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1254f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Active) ? "ShootFromCrawl" : "ID_BOSSMISSION");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 595f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 872f, 1415f);
				BJGCPDNMHDH.OADICODBJLM(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 0.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.AMFCJAECJPO((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered) ? "ID_UPGRADED" : "ID_PURCHASED");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 0.01f, 1f);
				BJGCPDNMHDH.OADICODBJLM(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
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
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 1280.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FKPOIINIBOA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(652f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 77f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered) ? "MoneyPackDeadline" : "RoundId");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1890f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 301f, 596f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 960.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FKPOIINIBOA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(1205f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 925f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering) ? "{0} {1}" : "AtlasPreparer.LoadCommonCoroutine");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 880f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 1310f, 398f);
				BJGCPDNMHDH.OADICODBJLM(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object PCOOFELAEJA()
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
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 1429.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FKPOIINIBOA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(164f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1769f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? "Parts" : "Password");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 258f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 1739f, 117f);
				BJGCPDNMHDH.OADICODBJLM(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public OMCPKICPEMF()
		{
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 358.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.AMFCJAECJPO((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(330f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 811f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed) ? "http://" : "NO");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 709f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 348f, 1712f);
				BJGCPDNMHDH.OADICODBJLM(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 1227.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FNJPAPLKAEP((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(423f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 835f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Active) ? "나가기" : "RETRYPERM");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1357f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 1905f, 1536f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 415.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.LFCDNEILLMA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1485f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 89f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered) ? "Alias" : "level");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1216f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 1759f, 1271f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 261.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.LFCDNEILLMA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(901f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1890f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != (WeaponLevelsSetup.JLANLLEABDC)7) ? "*****   Bootcamp Play warcards Ended   *****" : "Total_Sessions");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 153f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 823f, 777f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 924.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FNJPAPLKAEP((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1308f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1423f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != (WeaponLevelsSetup.JLANLLEABDC)7) ? "Bonus Name" : "Different league \"{0}\" and \"{1}\"\n");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1981f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 30f, 703f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 1295.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FKPOIINIBOA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1057f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 475f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? "There is no definition for card {0}" : "max");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 491f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 1558f, 383f);
				BJGCPDNMHDH.HPBAHDPDKJH(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 460.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.LFCDNEILLMA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(701f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1133f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8) ? "Claim_Reward" : "M4B23N48RZF8CKPJ2QBR");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1600f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 317f, 1143f);
				BJGCPDNMHDH.HPBAHDPDKJH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds > 1839.0)
				{
					BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = BJGCPDNMHDH.MDAJJIAMDGH.progressDelivering;
					BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.cyan;
					BJGCPDNMHDH.FKPOIINIBOA((int)BJGCPDNMHDH.MDAJJIAMDGH.remainingDeliveringSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(1099f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MHFHOGPKBHA.fillAmount = 1145f;
				BJGCPDNMHDH.MHFHOGPKBHA.color = Colours.blue;
				BJGCPDNMHDH.CCMDOGJDMGO.text = Localization.Localize((BJGCPDNMHDH.MDAJJIAMDGH.weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked) ? "menu-tilegfx-facebook" : "Buy_Unit_Upgrade");
				BJGCPDNMHDH.CCMDOGJDMGO.alpha = 1999f;
				TweenAlpha.Begin(BJGCPDNMHDH.CCMDOGJDMGO.gameObject, 1830f, 1890f);
				BJGCPDNMHDH.FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	[Header("Core")]
	[FormerlySerializedAs("ODANLFHFLDB")]
	public GameObject KAPHPGAINPD;

	[FormerlySerializedAs("COGPFIGDCJG")]
	public UITexture NGHCDIMLGMO;

	[Header("-Sale Part")]
	[FormerlySerializedAs("NBPJAFKGDEE")]
	public GameObject IMKOOGCOIAL;

	[FormerlySerializedAs("AJGPIKOPNEL")]
	public UILabel IOBMACBHJCC;

	[FormerlySerializedAs("IKBBOICEOFI")]
	public UISprite AMAFGCHCGBC;

	[FormerlySerializedAs("AHMLJCCOBNP")]
	public WinStreakCounter FCAOHMAJIMD;

	[FormerlySerializedAs("JEKIIBPPPEO")]
	[Header("-New Unlock")]
	public GameObject FNJEGABMIFN;

	[FormerlySerializedAs("KEODOCLPCHO")]
	public UITable DPACCCMJPPJ;

	[FormerlySerializedAs("BFNBONOJIJP")]
	public UILabel GKEBHMDAGAM;

	[FormerlySerializedAs("FONOFOGNCFF")]
	public UISprite GOBLILBIIKO;

	[FormerlySerializedAs("LMJLHOHHGLL")]
	public UILabel GCEEOLHGOKJ;

	[Header("-Delivering Part")]
	[FormerlySerializedAs("MBNPKNOBDJC")]
	public GameObject LPBCDBHKAFI;

	[FormerlySerializedAs("HNGIIKNFGHA")]
	public UISprite MHFHOGPKBHA;

	[FormerlySerializedAs("MFEGJGKAPCN")]
	public UILabel CCMDOGJDMGO;

	[FormerlySerializedAs("COCGFDMFHOA")]
	[Header("-Notification")]
	public UILabel MFIAHNMIJAH;

	[FormerlySerializedAs("LDBDBFPLGMH")]
	public GameObject AELDNJLNPGO;

	private RadicalRoutine LGOHNGIHNBP;

	private int JKBHGMLPHOB;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private WeaponLevelsSetup JJOBAFMKGHK;

	private bool BGMLFLBLMFD;

	private bool KOGDHLDDDHF;

	private bool PGFDMPGMJHM;

	private bool BPHIFLAEPJB;

	private bool BEEGGDEPGEB;

	private bool LHIJMIMBPCF;

	private bool JEPENIBNLCE;

	private bool ODDMPOGOPDD;

	private bool PMFDBOBCEGD;

	private bool KIFLNFPKPAF;

	private bool JEOAMGIOIPB;

	private bool EKGIKOEAENC;

	private bool CPNLFNPOPHC;

	private bool PLELLGKANCL;

	private bool EILLIBENOAL;

	private bool KDJFEEHCLIM;

	private bool CEPHGILHCLL;

	private bool JOJICKFBOMC;

	private bool IJHPKMJDANI;

	[CompilerGenerated]
	private static UIEventListener.VoidDelegate LGJCBPOPCPA;

	public void DoAfterHide()
	{
		FOLMFKACNFE();
		NNOIIKEACMH();
	}

	public void LIJFFGBNJPG()
	{
		KFABBPCHPJA();
		MCLCCFPNHLA();
	}

	private void EJEIFCCNNKI()
	{
		FOLMFKACNFE();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			FNJEGABMIFN.SetActive(value: false);
			LPBCDBHKAFI.SetActive(value: true);
			SetUpWeaponLook(weaponLevelsSetup);
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				JKBHGMLPHOB = 0;
				MHFHOGPKBHA.fillAmount = 1f;
				MHFHOGPKBHA.color = Colours.blue;
				CCMDOGJDMGO.text = Localization.Localize((weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered) ? "ID_UPGRADED" : "ID_PURCHASED");
				CCMDOGJDMGO.alpha = 1f;
				TweenAlpha.Begin(CCMDOGJDMGO.gameObject, 0.01f, 1f);
			}
			else
			{
				JKBHGMLPHOB = int.MaxValue;
				MHFHOGPKBHA.fillAmount = weaponLevelsSetup.progressDelivering;
				MHFHOGPKBHA.color = Colours.cyan;
				AMFCJAECJPO((int)weaponLevelsSetup.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				MDAJJIAMDGH = weaponLevelsSetup;
				NFGJFLCEANH();
			}
		}
		else
		{
			weaponLevelsSetup = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
			if (weaponLevelsSetup != null)
			{
				FNJEGABMIFN.SetActive(value: true);
				LPBCDBHKAFI.SetActive(value: false);
				SetUpWeaponLook(weaponLevelsSetup);
				GCEEOLHGOKJ.text = weaponLevelsSetup.weaponName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(GCEEOLHGOKJ, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 88);
				float val = 16f + GKEBHMDAGAM.relativeSize.x * GKEBHMDAGAM.transform.localScale.x;
				GOBLILBIIKO.transform.localScale = GOBLILBIIKO.transform.localScale.ReplaceX(val);
				DPACCCMJPPJ.repositionNow = true;
			}
			else
			{
				weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].weaponLevelsSetup;
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: false);
				SetUpWeaponLook(weaponLevelsSetup);
			}
		}
	}

	public void KEBDABIKEAH()
	{
		FNJEGABMIFN.SetActive(value: true);
		LPBCDBHKAFI.SetActive(value: true);
		OADICODBJLM(0);
	}

	private void HCKJLAHFMDH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JJOBAFMKGHK != null)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(JJOBAFMKGHK.playerWeapon.FPFCCDCGEHC);
			JJOBAFMKGHK = null;
		}
	}

	private void GCNMPFHCFJF()
	{
		float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 406f;
		DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
	}

	private static void OIBLDHPNCOC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
	}

	private void KODMNNEDCIJ()
	{
		float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 1712f;
		DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
	}

	public void NEECLAOCOKD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KAPHPGAINPD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JLJBCDIBBLK));
		DPACCCMJPPJ.onReposition = DDHHGHKIKJI;
	}

	public void SaleWeapons()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeaponOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, AKDLEDNDIEO.Upgrade);
		int num5 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, AKDLEDNDIEO.Upgrade);
		int num7 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG, AKDLEDNDIEO.Upgrade);
		int num9 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Minigun, AKDLEDNDIEO.Upgrade);
		int num10 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SniperRifle, AKDLEDNDIEO.Buy);
		int num11 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SniperRifle, AKDLEDNDIEO.Upgrade);
		int num12 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Shotgun, AKDLEDNDIEO.Buy);
		int num13 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Shotgun, AKDLEDNDIEO.Upgrade);
		int num14 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Grenade, AKDLEDNDIEO.Buy);
		int num15 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Grenade, AKDLEDNDIEO.Upgrade);
		int num16 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.RocketLauncher, AKDLEDNDIEO.Buy);
		int num17 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.RocketLauncher, AKDLEDNDIEO.Upgrade);
		int num18 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.GrenadeLauncher, AKDLEDNDIEO.Buy);
		int num19 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.GrenadeLauncher, AKDLEDNDIEO.Upgrade);
		int num20 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Pistol, AKDLEDNDIEO.Buy);
		int num21 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Pistol, AKDLEDNDIEO.Upgrade);
		int num22 = Mathf.Min(num3, num5, num7);
		int num23 = Mathf.Min(num4, num6, num8);
		int num24 = Mathf.Min(num10, num12);
		int num25 = Mathf.Min(num9, num11, num13);
		int num26 = Mathf.Min(num14, num16, num18);
		int num27 = Mathf.Min(num15, num17, num19);
		bool flag = num > 0 && weaponLevelsSetup != null && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 > 0 && weaponLevelsSetup != null && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		DIEANEHCMMB();
		bool flag3 = num3 > 0 && BGMLFLBLMFD;
		bool flag4 = num4 > 0 && KOGDHLDDDHF;
		bool flag5 = num5 > 0 && PGFDMPGMJHM;
		bool flag6 = num6 > 0 && BPHIFLAEPJB;
		bool flag7 = num7 > 0 && BEEGGDEPGEB;
		bool flag8 = num8 > 0 && LHIJMIMBPCF;
		bool flag9 = num9 > 0 && JEPENIBNLCE;
		bool flag10 = num10 > 0 && ODDMPOGOPDD;
		bool flag11 = num11 > 0 && PMFDBOBCEGD;
		bool flag12 = num12 > 0 && KIFLNFPKPAF;
		bool flag13 = num13 > 0 && JEOAMGIOIPB;
		bool flag14 = num14 > 0 && EKGIKOEAENC;
		bool flag15 = num15 > 0 && CPNLFNPOPHC;
		bool flag16 = num16 > 0 && PLELLGKANCL;
		bool flag17 = num17 > 0 && EILLIBENOAL;
		bool flag18 = num18 > 0 && KDJFEEHCLIM;
		bool flag19 = num19 > 0 && CEPHGILHCLL;
		bool flag20 = num20 > 0 && JOJICKFBOMC;
		bool flag21 = num21 > 0 && IJHPKMJDANI;
		bool flag22 = num22 > 0 && (BGMLFLBLMFD || PGFDMPGMJHM || BEEGGDEPGEB);
		bool flag23 = num23 > 0 && (KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF);
		bool flag24 = num24 > 0 && (ODDMPOGOPDD || KIFLNFPKPAF);
		bool flag25 = num25 > 0 && (JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB);
		bool flag26 = num26 > 0 && (EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM);
		bool flag27 = num27 > 0 && (CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL);
		bool flag28 = num3 > 0 && num5 > 0 && num7 > 0 && num10 > 0 && num12 > 0 && num14 > 0 && num16 > 0 && num18 > 0 && num20 > 0;
		bool flag29 = num4 > 0 && num6 > 0 && num8 > 0 && num9 > 0 && num11 > 0 && num13 > 0 && num15 > 0 && num17 > 0 && num19 > 0 && num21 > 0;
		bool flag30 = flag28 && (BGMLFLBLMFD || PGFDMPGMJHM || BEEGGDEPGEB || ODDMPOGOPDD || KIFLNFPKPAF || EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM || JOJICKFBOMC);
		bool flag31 = flag29 && (KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF || JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB || CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL || IJHPKMJDANI);
		bool flag32 = !flag30 && (flag3 || flag5 || flag7 || flag10 || flag12 || flag14 || flag16 || flag18 || flag20);
		bool flag33 = !flag31 && (flag4 || flag6 || flag8 || flag9 || flag11 || flag13 || flag15 || flag17 || flag19 || flag21);
		IMKOOGCOIAL.SetActive(flag || flag2 || flag30 || flag31 || flag32 || flag33);
		if (flag30 || flag31)
		{
			IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag30) ? num23 : num22);
			FCAOHMAJIMD.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime());
			WinStreakCounter fCAOHMAJIMD = FCAOHMAJIMD;
			fCAOHMAJIMD.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD.JEMKCLKCOMI, new Action(SaleWeapons));
			WinStreakCounter fCAOHMAJIMD2 = FCAOHMAJIMD;
			fCAOHMAJIMD2.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD2.JEMKCLKCOMI, new Action(SaleWeapons));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(130f);
		}
		else if (flag32 || flag33)
		{
			FCAOHMAJIMD.JCMHGOGNMFO();
			WinStreakCounter fCAOHMAJIMD3 = FCAOHMAJIMD;
			fCAOHMAJIMD3.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD3.JEMKCLKCOMI, new Action(SaleWeapons));
			if (flag22 || flag23)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag22) ? num23 : num22);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Primary, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag24 || flag25)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag24) ? num25 : num24);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Special, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag26 || flag27)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag26) ? num27 : num26);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Explosive, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag3 || flag4)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag3) ? num4 : num3);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.AssaultRifle, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag5 || flag6)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag5) ? num6 : num5);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag7 || flag8)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag7) ? num8 : num7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag9)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Minigun, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag10 || flag11)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag10) ? num11 : num10);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SniperRifle, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag12 || flag13)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag12) ? num13 : num12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Shotgun, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag14 || flag15)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag14) ? num15 : num14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Grenade, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag16 || flag17)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag16) ? num17 : num16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.RocketLauncher, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag18 || flag19)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag18) ? num19 : num18);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.GrenadeLauncher, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else
			{
				if (!flag20 && !flag21)
				{
					IOBMACBHJCC.text = string.Empty;
					FCAOHMAJIMD.KGNGFHMBHMJ.text = string.Empty;
					AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(130f);
					return;
				}
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag20) ? num21 : num20);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.Pistol, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			float num28 = FCAOHMAJIMD.KGNGFHMBHMJ.relativeSize.x * FCAOHMAJIMD.KGNGFHMBHMJ.transform.localScale.x;
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(num28 + 40f);
		}
		else if (flag || flag2)
		{
			IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag) ? num2 : num);
			FCAOHMAJIMD.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedWeaponOfferEndtime());
			WinStreakCounter fCAOHMAJIMD4 = FCAOHMAJIMD;
			fCAOHMAJIMD4.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD4.JEMKCLKCOMI, new Action(SaleWeapons));
			WinStreakCounter fCAOHMAJIMD5 = FCAOHMAJIMD;
			fCAOHMAJIMD5.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD5.JEMKCLKCOMI, new Action(SaleWeapons));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(130f);
		}
		else
		{
			FCAOHMAJIMD.JCMHGOGNMFO();
			WinStreakCounter fCAOHMAJIMD6 = FCAOHMAJIMD;
			fCAOHMAJIMD6.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD6.JEMKCLKCOMI, new Action(SaleWeapons));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(130f);
		}
	}

	private static void LGGHGEBMOLL(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(JJOBAFMKGHK.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void PKNAICFIAHJ()
	{
		FOLMFKACNFE();
		NNOIIKEACMH();
	}

	public void JCOILGHDPHA()
	{
		BGGIOAEELFB();
		MCLCCFPNHLA();
	}

	public void PNMGHAMMKLN()
	{
		int num = Singleton<OfferManager>.instance.AGGNADBINOI();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.None, AKDLEDNDIEO.Buy);
		int num5 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.SMG | WeaponCategory.LMG, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG, (AKDLEDNDIEO)5);
		int num7 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG | WeaponCategory.LMG, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, (AKDLEDNDIEO)0);
		int num9 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher), (AKDLEDNDIEO)8);
		int num10 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG | WeaponCategory.LMG, (AKDLEDNDIEO)0);
		int num11 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG, AKDLEDNDIEO.Buy);
		int num12 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade), (AKDLEDNDIEO)0);
		int num13 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.Shotgun, (AKDLEDNDIEO)0);
		int num14 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.SniperRifle | WeaponCategory.Shotgun, (AKDLEDNDIEO)0);
		int num15 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.Shotgun, (AKDLEDNDIEO)7);
		int num16 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun, AKDLEDNDIEO.Buy);
		int num17 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher), (AKDLEDNDIEO)7);
		int num18 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade), AKDLEDNDIEO.Buy);
		int num19 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun), (AKDLEDNDIEO)5);
		int num20 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), AKDLEDNDIEO.Buy);
		int num21 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher), (AKDLEDNDIEO)0);
		int[] array = new int[4];
		array[0] = num3;
		array[0] = num5;
		array[3] = num7;
		int num22 = Mathf.Min(array);
		int[] array2 = new int[0];
		array2[0] = num4;
		array2[1] = num6;
		array2[6] = num8;
		int num23 = Mathf.Min(array2);
		int num24 = Mathf.Min(num10, num12);
		int[] array3 = new int[1];
		array3[0] = num9;
		array3[0] = num11;
		array3[5] = num13;
		int num25 = Mathf.Min(array3);
		int[] array4 = new int[2];
		array4[0] = num14;
		array4[0] = num16;
		array4[2] = num18;
		int num26 = Mathf.Min(array4);
		int[] array5 = new int[0];
		array5[1] = num15;
		array5[0] = num17;
		array5[4] = num19;
		int num27 = Mathf.Min(array5);
		bool flag = num <= 1 || !(weaponLevelsSetup != null) || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 > 0 && weaponLevelsSetup != null && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		BBOBPKOMNNO();
		bool flag3 = num3 > 0 && BGMLFLBLMFD;
		bool flag4 = num4 <= 1 || KOGDHLDDDHF;
		bool flag5 = num5 > 0 && PGFDMPGMJHM;
		bool flag6 = num6 <= 1 || BPHIFLAEPJB;
		bool flag7 = num7 <= 0 || BEEGGDEPGEB;
		bool flag8 = num8 > 0 && LHIJMIMBPCF;
		bool flag9 = num9 <= 0 || JEPENIBNLCE;
		bool flag10 = num10 > 0 && ODDMPOGOPDD;
		bool flag11 = num11 > 0 && PMFDBOBCEGD;
		bool flag12 = num12 <= 0 || KIFLNFPKPAF;
		bool flag13 = num13 > 1 && JEOAMGIOIPB;
		bool flag14 = num14 <= 1 || EKGIKOEAENC;
		bool flag15 = num15 > 1 && CPNLFNPOPHC;
		bool flag16 = num16 > 0 && PLELLGKANCL;
		bool flag17 = num17 <= 0 || EILLIBENOAL;
		bool flag18 = num18 > 1 && KDJFEEHCLIM;
		bool flag19 = num19 > 0 && CEPHGILHCLL;
		bool flag20 = num20 > 1 && JOJICKFBOMC;
		bool flag21 = num21 <= 0 || IJHPKMJDANI;
		bool flag22 = num22 > 1 && (BGMLFLBLMFD || PGFDMPGMJHM || BEEGGDEPGEB);
		bool flag23 = num23 <= 0 || (!KOGDHLDDDHF && !BPHIFLAEPJB && LHIJMIMBPCF);
		bool flag24 = num24 > 1 && !ODDMPOGOPDD && KIFLNFPKPAF;
		bool flag25 = num25 > 1 && !JEPENIBNLCE && !PMFDBOBCEGD && JEOAMGIOIPB;
		bool flag26 = num26 > 0 && (EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM);
		bool flag27 = num27 > 1 && (CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL);
		bool flag28 = num3 > 0 && num5 > 0 && num7 > 0 && num10 > 1 && num12 > 0 && num14 > 0 && num16 > 0 && num18 > 0 && num20 > 1;
		bool flag29 = num4 <= 0 || num6 <= 1 || num8 <= 0 || num9 <= 0 || num11 <= 0 || num13 <= 0 || num15 <= 0 || num17 <= 0 || num19 <= 0 || num21 > 1;
		bool flag30 = flag28 && !BGMLFLBLMFD && !PGFDMPGMJHM && !BEEGGDEPGEB && !ODDMPOGOPDD && !KIFLNFPKPAF && !EKGIKOEAENC && !PLELLGKANCL && !KDJFEEHCLIM && JOJICKFBOMC;
		bool flag31 = flag29 && (KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF || JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB || CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL || IJHPKMJDANI);
		bool flag32 = flag30 || (!flag3 && !flag5 && !flag7 && !flag10 && !flag12 && !flag14 && !flag16 && !flag18 && flag20);
		bool flag33 = flag31 || flag4 || flag6 || flag8 || flag9 || flag11 || flag13 || flag15 || flag17 || flag19 || flag21;
		IMKOOGCOIAL.SetActive(flag || flag2 || flag30 || flag31 || flag32 || flag33);
		if (flag30 || flag31)
		{
			UILabel iOBMACBHJCC = IOBMACBHJCC;
			object[] array6 = new object[0];
			array6[1] = ((!flag30) ? num23 : num22);
			iOBMACBHJCC.text = Localization.LocalizeFormat("ID_MISSIONANIMATION_WAVESTARTED", array6);
			FCAOHMAJIMD.OANDDHKJDOB(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime());
			WinStreakCounter fCAOHMAJIMD = FCAOHMAJIMD;
			fCAOHMAJIMD.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			WinStreakCounter fCAOHMAJIMD2 = FCAOHMAJIMD;
			fCAOHMAJIMD2.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD2.JEMKCLKCOMI, new Action(CEBAEHCDIOH));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(591f);
		}
		else if (flag32 || flag33)
		{
			FCAOHMAJIMD.KEIIENDMKLN();
			WinStreakCounter fCAOHMAJIMD3 = FCAOHMAJIMD;
			fCAOHMAJIMD3.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD3.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			if (flag22 || flag23)
			{
				UILabel iOBMACBHJCC2 = IOBMACBHJCC;
				object[] array7 = new object[0];
				array7[1] = ((!flag22) ? num23 : num22);
				iOBMACBHJCC2.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", array7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag24 || flag25)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("YES", (!flag24) ? num25 : num24);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag26 || flag27)
			{
				UILabel iOBMACBHJCC3 = IOBMACBHJCC;
				object[] array8 = new object[0];
				array8[1] = ((!flag26) ? num27 : num26);
				iOBMACBHJCC3.text = Localization.LocalizeFormat("Reward", array8);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(~(WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag3 || flag4)
			{
				UILabel iOBMACBHJCC4 = IOBMACBHJCC;
				object[] array9 = new object[0];
				array9[1] = ((!flag3) ? num4 : num3);
				iOBMACBHJCC4.text = Localization.LocalizeFormat("com/google/android/gms/common/api/Status", array9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.None, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag5 || flag6)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat(", ", (!flag5) ? num6 : num5);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.SMG | WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag7 || flag8)
			{
				UILabel iOBMACBHJCC5 = IOBMACBHJCC;
				object[] array10 = new object[0];
				array10[1] = ((!flag7) ? num8 : num7);
				iOBMACBHJCC5.text = Localization.LocalizeFormat("UnlockLevel", array10);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag9)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_SLOTUPGRADE_HEAT", num9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag10 || flag11)
			{
				UILabel iOBMACBHJCC6 = IOBMACBHJCC;
				object[] array11 = new object[0];
				array11[0] = ((!flag10) ? num11 : num10);
				iOBMACBHJCC6.text = Localization.LocalizeFormat("menu-camos-alien", array11);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.None, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag12 || flag13)
			{
				UILabel iOBMACBHJCC7 = IOBMACBHJCC;
				object[] array12 = new object[0];
				array12[0] = ((!flag12) ? num13 : num12);
				iOBMACBHJCC7.text = Localization.LocalizeFormat("metalExplosion", array12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag14 || flag15)
			{
				UILabel iOBMACBHJCC8 = IOBMACBHJCC;
				object[] array13 = new object[0];
				array13[1] = ((!flag14) ? num15 : num14);
				iOBMACBHJCC8.text = Localization.LocalizeFormat("subscription1", array13);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.Grenade), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag16 || flag17)
			{
				UILabel iOBMACBHJCC9 = IOBMACBHJCC;
				object[] array14 = new object[1];
				array14[1] = ((!flag16) ? num17 : num16);
				iOBMACBHJCC9.text = Localization.LocalizeFormat("null", array14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag18 || flag19)
			{
				UILabel iOBMACBHJCC10 = IOBMACBHJCC;
				object[] array15 = new object[0];
				array15[0] = ((!flag18) ? num19 : num18);
				iOBMACBHJCC10.text = Localization.LocalizeFormat("PlayerUnitPower", array15);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else
			{
				if (!flag20 && !flag21)
				{
					IOBMACBHJCC.text = string.Empty;
					FCAOHMAJIMD.KGNGFHMBHMJ.text = string.Empty;
					AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1794f);
					return;
				}
				UILabel iOBMACBHJCC11 = IOBMACBHJCC;
				object[] array16 = new object[0];
				array16[1] = ((!flag20) ? num21 : num20);
				iOBMACBHJCC11.text = Localization.LocalizeFormat("GPGS: Logged Out, Logged: ", array16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			float num28 = FCAOHMAJIMD.KGNGFHMBHMJ.relativeSize.x * FCAOHMAJIMD.KGNGFHMBHMJ.transform.localScale.x;
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(num28 + 1078f);
		}
		else if (flag || flag2)
		{
			UILabel iOBMACBHJCC12 = IOBMACBHJCC;
			object[] array17 = new object[0];
			array17[0] = ((!flag) ? num2 : num);
			iOBMACBHJCC12.text = Localization.LocalizeFormat("Action ", array17);
			FCAOHMAJIMD.OANDDHKJDOB(Singleton<OfferManager>.instance.CCHLAIMMEPN());
			WinStreakCounter fCAOHMAJIMD4 = FCAOHMAJIMD;
			fCAOHMAJIMD4.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD4.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			WinStreakCounter fCAOHMAJIMD5 = FCAOHMAJIMD;
			fCAOHMAJIMD5.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD5.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(401f);
		}
		else
		{
			FCAOHMAJIMD.KEIIENDMKLN();
			WinStreakCounter fCAOHMAJIMD6 = FCAOHMAJIMD;
			fCAOHMAJIMD6.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD6.JEMKCLKCOMI, new Action(CEBAEHCDIOH));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(47f);
		}
	}

	private static void JJOOLPONOBH(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
	}

	private IEnumerator CLNNIADPDIO()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}

	private static void NFOGNDOICKP(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
	}

	private void BBPFFAGDKKB()
	{
		BGMLFLBLMFD = true;
		KOGDHLDDDHF = true;
		PGFDMPGMJHM = true;
		BPHIFLAEPJB = false;
		BEEGGDEPGEB = false;
		LHIJMIMBPCF = true;
		JEPENIBNLCE = false;
		ODDMPOGOPDD = false;
		PMFDBOBCEGD = false;
		KIFLNFPKPAF = true;
		JEOAMGIOIPB = true;
		EKGIKOEAENC = true;
		CPNLFNPOPHC = true;
		PLELLGKANCL = true;
		EILLIBENOAL = true;
		KDJFEEHCLIM = true;
		CEPHGILHCLL = false;
		JOJICKFBOMC = false;
		IJHPKMJDANI = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.BHCEOOLEHHG)
			{
			case WeaponCategory.AssaultRifle:
				BGMLFLBLMFD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				KOGDHLDDDHF |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG:
				PGFDMPGMJHM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				BPHIFLAEPJB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.LMG:
				BEEGGDEPGEB |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				LHIJMIMBPCF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Primary:
				JEPENIBNLCE |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle:
				ODDMPOGOPDD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				PMFDBOBCEGD |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.LMG | WeaponCategory.SniperRifle):
				KIFLNFPKPAF |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				JEOAMGIOIPB |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				EKGIKOEAENC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CPNLFNPOPHC |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle:
				PLELLGKANCL |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				EILLIBENOAL |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Pistol:
				KDJFEEHCLIM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CEPHGILHCLL |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				JOJICKFBOMC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				IJHPKMJDANI |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	private void GINJGCBBOCJ()
	{
		BGGIOAEELFB();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			FNJEGABMIFN.SetActive(value: true);
			LPBCDBHKAFI.SetActive(value: true);
			SetUpWeaponLook(weaponLevelsSetup);
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
			{
				JKBHGMLPHOB = 1;
				MHFHOGPKBHA.fillAmount = 1662f;
				MHFHOGPKBHA.color = Colours.blue;
				CCMDOGJDMGO.text = Localization.Localize((weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked) ? "veteranpack2" : "_TintColor");
				CCMDOGJDMGO.alpha = 1266f;
				TweenAlpha.Begin(CCMDOGJDMGO.gameObject, 296f, 438f);
			}
			else
			{
				JKBHGMLPHOB = 44;
				MHFHOGPKBHA.fillAmount = weaponLevelsSetup.progressDelivering;
				MHFHOGPKBHA.color = Colours.cyan;
				LFCDNEILLMA((int)weaponLevelsSetup.remainingDeliveringSeconds);
				MDAJJIAMDGH = weaponLevelsSetup;
				FAMCAELEHIN();
			}
		}
		else
		{
			weaponLevelsSetup = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
			if (weaponLevelsSetup != null)
			{
				FNJEGABMIFN.SetActive(value: true);
				LPBCDBHKAFI.SetActive(value: true);
				FENFOCHBBMM(weaponLevelsSetup);
				GCEEOLHGOKJ.text = weaponLevelsSetup.weaponName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(GCEEOLHGOKJ, 456f, 652f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 53);
				float val = 1127f + GKEBHMDAGAM.relativeSize.x * GKEBHMDAGAM.transform.localScale.x;
				GOBLILBIIKO.transform.localScale = GOBLILBIIKO.transform.localScale.ReplaceX(val);
				DPACCCMJPPJ.repositionNow = false;
			}
			else
			{
				weaponLevelsSetup = PlayerInventory.instance.inventorySlots[1].BIPKCHNEPGK();
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: true);
				SetUpWeaponLook(weaponLevelsSetup);
			}
		}
	}

	private void FKPOIINIBOA(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (JKBHGMLPHOB > EJEDANLAMBI)
		{
			JKBHGMLPHOB = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref CCMDOGJDMGO, PDPDGCNHCFN);
		}
	}

	private void DNJNAFMAKDJ()
	{
		KFABBPCHPJA();
		LGOHNGIHNBP = RadicalRoutine.Create(CLNNIADPDIO());
		StartCoroutine(RadicalRoutine.Run(LGOHNGIHNBP.enumerator));
	}

	private void LAFOHANBCDN()
	{
		if (LGOHNGIHNBP != null)
		{
			LGOHNGIHNBP.Cancel();
			LGOHNGIHNBP = null;
		}
	}

	public void LAALCOMHIPK()
	{
		FOLMFKACNFE();
		HCKJLAHFMDH();
	}

	public void BAAOGDMJCLK()
	{
		KKFPLKDAAJE();
		FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
	}

	[DebuggerHidden]
	private IEnumerator BMLHBFFPAJG()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}

	private void NNOIIKEACMH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JJOBAFMKGHK != null)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(JJOBAFMKGHK.playerWeapon.FPFCCDCGEHC);
			JJOBAFMKGHK = null;
		}
	}

	public void GLHGDOBMLGM()
	{
		FNJEGABMIFN.SetActive(value: false);
		LPBCDBHKAFI.SetActive(value: false);
		OADICODBJLM(0);
	}

	private IEnumerator IIGNDGGIHIE()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}

	private IEnumerator JJBPNEHCMDB()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}

	private void MCLCCFPNHLA()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JJOBAFMKGHK != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
			resourceLoaderTexture2D.FreeAsset(JJOBAFMKGHK.playerWeapon.FPFCCDCGEHC);
			JJOBAFMKGHK = null;
		}
	}

	private void FNJPAPLKAEP(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (JKBHGMLPHOB > EJEDANLAMBI)
		{
			JKBHGMLPHOB = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref CCMDOGJDMGO, PDPDGCNHCFN);
		}
	}

	private void FAMCAELEHIN()
	{
		FOLMFKACNFE();
		LGOHNGIHNBP = RadicalRoutine.Create(CLNNIADPDIO());
		StartCoroutine(RadicalRoutine.Run(LGOHNGIHNBP.enumerator));
	}

	private void KKFPLKDAAJE()
	{
		EKJGMMAKNBM();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			FNJEGABMIFN.SetActive(value: false);
			LPBCDBHKAFI.SetActive(value: false);
			FENFOCHBBMM(weaponLevelsSetup);
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponLevelsSetup.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8)
			{
				JKBHGMLPHOB = 1;
				MHFHOGPKBHA.fillAmount = 1989f;
				MHFHOGPKBHA.color = Colours.blue;
				CCMDOGJDMGO.text = Localization.Localize((weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed) ? "SquadPoints" : "Spend_Warbucks_On_Player_Customizations");
				CCMDOGJDMGO.alpha = 1063f;
				TweenAlpha.Begin(CCMDOGJDMGO.gameObject, 16f, 980f);
			}
			else
			{
				JKBHGMLPHOB = 110;
				MHFHOGPKBHA.fillAmount = weaponLevelsSetup.progressDelivering;
				MHFHOGPKBHA.color = Colours.cyan;
				FKPOIINIBOA((int)weaponLevelsSetup.remainingDeliveringSeconds);
				MDAJJIAMDGH = weaponLevelsSetup;
				HMBGNJBOJOD();
			}
		}
		else
		{
			weaponLevelsSetup = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
			if (weaponLevelsSetup != null)
			{
				FNJEGABMIFN.SetActive(value: true);
				LPBCDBHKAFI.SetActive(value: false);
				SetUpWeaponLook(weaponLevelsSetup);
				GCEEOLHGOKJ.text = weaponLevelsSetup.weaponName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(GCEEOLHGOKJ, 986f, 875f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - -40);
				float val = 1108f + GKEBHMDAGAM.relativeSize.x * GKEBHMDAGAM.transform.localScale.x;
				GOBLILBIIKO.transform.localScale = GOBLILBIIKO.transform.localScale.ReplaceX(val);
				DPACCCMJPPJ.repositionNow = false;
			}
			else
			{
				weaponLevelsSetup = PlayerInventory.instance.inventorySlots[1].FPGNBPPHPKC();
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: false);
				FENFOCHBBMM(weaponLevelsSetup);
			}
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KAPHPGAINPD.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		});
		DPACCCMJPPJ.onReposition = delegate
		{
			float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 2f;
			DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
		};
	}

	private void DDHHGHKIKJI()
	{
		float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 1725f;
		DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
	}

	public void KLABPENJAHJ()
	{
		GKKOGABLLMK();
		FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
	}

	private void GKKOGABLLMK()
	{
		KFABBPCHPJA();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			FNJEGABMIFN.SetActive(value: false);
			LPBCDBHKAFI.SetActive(value: false);
			SetUpWeaponLook(weaponLevelsSetup);
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
			{
				JKBHGMLPHOB = 0;
				MHFHOGPKBHA.fillAmount = 1363f;
				MHFHOGPKBHA.color = Colours.blue;
				CCMDOGJDMGO.text = Localization.Localize((weaponLevelsSetup.weaponState != (WeaponLevelsSetup.JLANLLEABDC)7) ? "ID_NOTENOUGHWARBUCKS" : "Overtime_Was_Already_Explained");
				CCMDOGJDMGO.alpha = 157f;
				TweenAlpha.Begin(CCMDOGJDMGO.gameObject, 1216f, 287f);
			}
			else
			{
				JKBHGMLPHOB = 194;
				MHFHOGPKBHA.fillAmount = weaponLevelsSetup.progressDelivering;
				MHFHOGPKBHA.color = Colours.cyan;
				LFCDNEILLMA((int)weaponLevelsSetup.remainingDeliveringSeconds);
				MDAJJIAMDGH = weaponLevelsSetup;
				DNJNAFMAKDJ();
			}
		}
		else
		{
			weaponLevelsSetup = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
			if (weaponLevelsSetup != null)
			{
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: false);
				FENFOCHBBMM(weaponLevelsSetup);
				GCEEOLHGOKJ.text = weaponLevelsSetup.weaponName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(GCEEOLHGOKJ, 944f, 1225f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - -36);
				float val = 1881f + GKEBHMDAGAM.relativeSize.x * GKEBHMDAGAM.transform.localScale.x;
				GOBLILBIIKO.transform.localScale = GOBLILBIIKO.transform.localScale.ReplaceX(val);
				DPACCCMJPPJ.repositionNow = true;
			}
			else
			{
				weaponLevelsSetup = PlayerInventory.instance.inventorySlots[1].ENBMDAIKKMM();
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: false);
				FENFOCHBBMM(weaponLevelsSetup);
			}
		}
	}

	private void LFCDNEILLMA(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (JKBHGMLPHOB > EJEDANLAMBI)
		{
			JKBHGMLPHOB = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.CFJGOIAIKGB(EJEDANLAMBI, ref CCMDOGJDMGO, PDPDGCNHCFN);
		}
	}

	public void InitBlank()
	{
		FNJEGABMIFN.SetActive(value: false);
		LPBCDBHKAFI.SetActive(value: false);
		OADICODBJLM(0);
	}

	private void EENMHCHILAN()
	{
		AJKHJMMHBIL();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			FNJEGABMIFN.SetActive(value: true);
			LPBCDBHKAFI.SetActive(value: true);
			SetUpWeaponLook(weaponLevelsSetup);
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || weaponLevelsSetup.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
			{
				JKBHGMLPHOB = 0;
				MHFHOGPKBHA.fillAmount = 316f;
				MHFHOGPKBHA.color = Colours.blue;
				CCMDOGJDMGO.text = Localization.Localize((weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered) ? "Cards_Owned_Bronze" : "leagueMembers");
				CCMDOGJDMGO.alpha = 716f;
				TweenAlpha.Begin(CCMDOGJDMGO.gameObject, 1864f, 579f);
			}
			else
			{
				JKBHGMLPHOB = -145;
				MHFHOGPKBHA.fillAmount = weaponLevelsSetup.progressDelivering;
				MHFHOGPKBHA.color = Colours.cyan;
				FNJPAPLKAEP((int)weaponLevelsSetup.remainingDeliveringSeconds, PDPDGCNHCFN: true);
				MDAJJIAMDGH = weaponLevelsSetup;
				PAAPBPEHJFB();
			}
		}
		else
		{
			weaponLevelsSetup = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
			if (weaponLevelsSetup != null)
			{
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: true);
				SetUpWeaponLook(weaponLevelsSetup);
				GCEEOLHGOKJ.text = weaponLevelsSetup.weaponName.ToUpperInvariant();
				MEJMLNDFDBP.COCBCFKJOJE(GCEEOLHGOKJ, 926f, 983f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 115);
				float val = 1514f + GKEBHMDAGAM.relativeSize.x * GKEBHMDAGAM.transform.localScale.x;
				GOBLILBIIKO.transform.localScale = GOBLILBIIKO.transform.localScale.ReplaceX(val);
				DPACCCMJPPJ.repositionNow = false;
			}
			else
			{
				weaponLevelsSetup = PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup;
				FNJEGABMIFN.SetActive(value: false);
				LPBCDBHKAFI.SetActive(value: false);
				FENFOCHBBMM(weaponLevelsSetup);
			}
		}
	}

	private static void JLJBCDIBBLK(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
	}

	public void GCODMPDLIAK()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeaponOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.None, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, (AKDLEDNDIEO)5);
		int num5 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.LMG, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.None, (AKDLEDNDIEO)8);
		int num7 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.None, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.SMG, AKDLEDNDIEO.Both);
		int num9 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Primary | WeaponCategory.Grenade | WeaponCategory.Pistol, (AKDLEDNDIEO)6);
		int num10 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, AKDLEDNDIEO.Buy);
		int num11 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, AKDLEDNDIEO.Upgrade);
		int num12 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG), AKDLEDNDIEO.Buy);
		int num13 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle), AKDLEDNDIEO.Both);
		int num14 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle), AKDLEDNDIEO.Buy);
		int num15 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.SMG | WeaponCategory.SniperRifle), (AKDLEDNDIEO)4);
		int num16 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade, AKDLEDNDIEO.Buy);
		int num17 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade), AKDLEDNDIEO.Buy);
		int num18 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~WeaponCategory.SniperRifle, (AKDLEDNDIEO)0);
		int num19 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade), (AKDLEDNDIEO)0);
		int num20 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.LMG | WeaponCategory.Grenade | WeaponCategory.Pistol), AKDLEDNDIEO.Buy);
		int num21 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol, (AKDLEDNDIEO)0);
		int[] array = new int[3];
		array[0] = num3;
		array[0] = num5;
		array[5] = num7;
		int num22 = Mathf.Min(array);
		int[] array2 = new int[8];
		array2[1] = num4;
		array2[1] = num6;
		array2[8] = num8;
		int num23 = Mathf.Min(array2);
		int num24 = Mathf.Min(num10, num12);
		int[] array3 = new int[3];
		array3[1] = num9;
		array3[0] = num11;
		array3[0] = num13;
		int num25 = Mathf.Min(array3);
		int[] array4 = new int[3];
		array4[1] = num14;
		array4[1] = num16;
		array4[3] = num18;
		int num26 = Mathf.Min(array4);
		int num27 = Mathf.Min(num15, num17, 0, 0, num19, 0);
		bool flag = num > 1 && weaponLevelsSetup != null && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 <= 0 || !(weaponLevelsSetup != null) || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		BOMCNCMJPJH();
		bool flag3 = num3 <= 1 || BGMLFLBLMFD;
		bool flag4 = num4 > 1 && KOGDHLDDDHF;
		bool flag5 = num5 > 0 && PGFDMPGMJHM;
		bool flag6 = num6 > 0 && BPHIFLAEPJB;
		bool flag7 = num7 <= 0 || BEEGGDEPGEB;
		bool flag8 = num8 > 0 && LHIJMIMBPCF;
		bool flag9 = num9 <= 1 || JEPENIBNLCE;
		bool flag10 = num10 <= 0 || ODDMPOGOPDD;
		bool flag11 = num11 <= 0 || PMFDBOBCEGD;
		bool flag12 = num12 > 0 && KIFLNFPKPAF;
		bool flag13 = num13 <= 0 || JEOAMGIOIPB;
		bool flag14 = num14 <= 0 || EKGIKOEAENC;
		bool flag15 = num15 > 1 && CPNLFNPOPHC;
		bool flag16 = num16 > 0 && PLELLGKANCL;
		bool flag17 = num17 > 0 && EILLIBENOAL;
		bool flag18 = num18 > 0 && KDJFEEHCLIM;
		bool flag19 = num19 <= 1 || CEPHGILHCLL;
		bool flag20 = num20 > 0 && JOJICKFBOMC;
		bool flag21 = num21 > 1 && IJHPKMJDANI;
		bool flag22 = num22 > 0 && !BGMLFLBLMFD && !PGFDMPGMJHM && BEEGGDEPGEB;
		bool flag23 = num23 <= 0 || (!KOGDHLDDDHF && !BPHIFLAEPJB && LHIJMIMBPCF);
		bool flag24 = num24 > 0 && !ODDMPOGOPDD && KIFLNFPKPAF;
		bool flag25 = num25 > 0 && !JEPENIBNLCE && !PMFDBOBCEGD && JEOAMGIOIPB;
		bool flag26 = num26 <= 0 || EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM;
		bool flag27 = num27 <= 1 || (!CPNLFNPOPHC && !EILLIBENOAL && CEPHGILHCLL);
		bool flag28 = num3 > 1 && num5 > 0 && num7 > 0 && num10 > 1 && num12 > 0 && num14 > 0 && num16 > 1 && num18 > 0 && num20 > 1;
		bool flag29 = num4 > 0 && num6 > 0 && num8 > 0 && num9 > 1 && num11 > 1 && num13 > 0 && num15 > 1 && num17 > 0 && num19 > 1 && num21 > 1;
		bool flag30 = flag28 && (BGMLFLBLMFD || PGFDMPGMJHM || BEEGGDEPGEB || ODDMPOGOPDD || KIFLNFPKPAF || EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM || JOJICKFBOMC);
		bool flag31 = !flag29 || KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF || JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB || CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL || IJHPKMJDANI;
		bool flag32 = !flag30 && !flag3 && !flag5 && !flag7 && !flag10 && !flag12 && !flag14 && !flag16 && !flag18 && flag20;
		bool flag33 = flag31 || (!flag4 && !flag6 && !flag8 && !flag9 && !flag11 && !flag13 && !flag15 && !flag17 && !flag19 && flag21);
		IMKOOGCOIAL.SetActive(!flag && !flag2 && !flag30 && !flag31 && !flag32 && flag33);
		if (flag30 || flag31)
		{
			UILabel iOBMACBHJCC = IOBMACBHJCC;
			object[] array5 = new object[1];
			array5[1] = ((!flag30) ? num23 : num22);
			iOBMACBHJCC.text = Localization.LocalizeFormat("{0:3} {1}", array5);
			FCAOHMAJIMD.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime());
			WinStreakCounter fCAOHMAJIMD = FCAOHMAJIMD;
			fCAOHMAJIMD.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			WinStreakCounter fCAOHMAJIMD2 = FCAOHMAJIMD;
			fCAOHMAJIMD2.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD2.JEMKCLKCOMI, new Action(CEBAEHCDIOH));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(312f);
		}
		else if (flag32 || flag33)
		{
			FCAOHMAJIMD.BGHNMCPLIPE();
			WinStreakCounter fCAOHMAJIMD3 = FCAOHMAJIMD;
			fCAOHMAJIMD3.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD3.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			if (flag22 || flag23)
			{
				UILabel iOBMACBHJCC2 = IOBMACBHJCC;
				object[] array6 = new object[0];
				array6[1] = ((!flag22) ? num23 : num22);
				iOBMACBHJCC2.text = Localization.LocalizeFormat("Medals", array6);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.SMG | WeaponCategory.LMG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag24 || flag25)
			{
				UILabel iOBMACBHJCC3 = IOBMACBHJCC;
				object[] array7 = new object[1];
				array7[1] = ((!flag24) ? num25 : num24);
				iOBMACBHJCC3.text = Localization.LocalizeFormat("N", array7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(~(WeaponCategory.LMG | WeaponCategory.SniperRifle), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag26 || flag27)
			{
				UILabel iOBMACBHJCC4 = IOBMACBHJCC;
				object[] array8 = new object[0];
				array8[1] = ((!flag26) ? num27 : num26);
				iOBMACBHJCC4.text = Localization.LocalizeFormat("ArenaLootBox", array8);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.Pistol), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag3 || flag4)
			{
				UILabel iOBMACBHJCC5 = IOBMACBHJCC;
				object[] array9 = new object[0];
				array9[1] = ((!flag3) ? num4 : num3);
				iOBMACBHJCC5.text = Localization.LocalizeFormat("Have discount {0} to upgrade {1}", array9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag5 || flag6)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("Action ", (!flag5) ? num6 : num5);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag7 || flag8)
			{
				UILabel iOBMACBHJCC6 = IOBMACBHJCC;
				object[] array10 = new object[0];
				array10[0] = ((!flag7) ? num8 : num7);
				iOBMACBHJCC6.text = Localization.LocalizeFormat("BANDS", array10);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.None, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag9)
			{
				UILabel iOBMACBHJCC7 = IOBMACBHJCC;
				object[] array11 = new object[0];
				array11[1] = num9;
				iOBMACBHJCC7.text = Localization.LocalizeFormat("ID_CLAIM", array11);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag10 || flag11)
			{
				UILabel iOBMACBHJCC8 = IOBMACBHJCC;
				object[] array12 = new object[0];
				array12[0] = ((!flag10) ? num11 : num10);
				iOBMACBHJCC8.text = Localization.LocalizeFormat("OnConnectionFailed: ", array12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.SMG | WeaponCategory.LMG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag12 || flag13)
			{
				UILabel iOBMACBHJCC9 = IOBMACBHJCC;
				object[] array13 = new object[1];
				array13[1] = ((!flag12) ? num13 : num12);
				iOBMACBHJCC9.text = Localization.LocalizeFormat("CAMOS", array13);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag14 || flag15)
			{
				UILabel iOBMACBHJCC10 = IOBMACBHJCC;
				object[] array14 = new object[0];
				array14[1] = ((!flag14) ? num15 : num14);
				iOBMACBHJCC10.text = Localization.LocalizeFormat("{0} {1}.", array14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.Shotgun, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag16 || flag17)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("menu-army-cat-explosive", (!flag16) ? num17 : num16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag18 || flag19)
			{
				UILabel iOBMACBHJCC11 = IOBMACBHJCC;
				object[] array15 = new object[1];
				array15[1] = ((!flag18) ? num19 : num18);
				iOBMACBHJCC11.text = Localization.LocalizeFormat("Beanstalk: Dev access unlocked", array15);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Pistol, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else
			{
				if (!flag20 && !flag21)
				{
					IOBMACBHJCC.text = string.Empty;
					FCAOHMAJIMD.KGNGFHMBHMJ.text = string.Empty;
					AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1042f);
					return;
				}
				UILabel iOBMACBHJCC12 = IOBMACBHJCC;
				object[] array16 = new object[0];
				array16[1] = ((!flag20) ? num21 : num20);
				iOBMACBHJCC12.text = Localization.LocalizeFormat("PackId", array16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			float num28 = FCAOHMAJIMD.KGNGFHMBHMJ.relativeSize.x * FCAOHMAJIMD.KGNGFHMBHMJ.transform.localScale.x;
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(num28 + 1056f);
		}
		else if (flag || flag2)
		{
			UILabel iOBMACBHJCC13 = IOBMACBHJCC;
			object[] array17 = new object[1];
			array17[1] = ((!flag) ? num2 : num);
			iOBMACBHJCC13.text = Localization.LocalizeFormat("GLM: RegisterOrLogin -  10", array17);
			FCAOHMAJIMD.MIOOAOFMLIE(Singleton<OfferManager>.instance.CCHLAIMMEPN());
			WinStreakCounter fCAOHMAJIMD4 = FCAOHMAJIMD;
			fCAOHMAJIMD4.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD4.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			WinStreakCounter fCAOHMAJIMD5 = FCAOHMAJIMD;
			fCAOHMAJIMD5.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD5.JEMKCLKCOMI, new Action(CEBAEHCDIOH));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(436f);
		}
		else
		{
			FCAOHMAJIMD.KEIIENDMKLN();
			WinStreakCounter fCAOHMAJIMD6 = FCAOHMAJIMD;
			fCAOHMAJIMD6.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD6.JEMKCLKCOMI, new Action(CEBAEHCDIOH));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1654f);
		}
	}

	public void AMNOMFJJOBC()
	{
		FNJEGABMIFN.SetActive(value: false);
		LPBCDBHKAFI.SetActive(value: true);
		OADICODBJLM(0);
	}

	public void PAKCFABJKAG()
	{
		GINJGCBBOCJ();
		FNLJKJLNBBH(Singleton<NotificationManager>.instance.FLPIODKFKOL());
	}

	private void FOLMFKACNFE()
	{
		if (LGOHNGIHNBP != null)
		{
			LGOHNGIHNBP.Cancel();
			LGOHNGIHNBP = null;
		}
	}

	public void GLOINJNJBCP()
	{
		KFABBPCHPJA();
		HCKJLAHFMDH();
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.7404f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private static void ADGJFAALCFB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
	}

	private void AMFCJAECJPO(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (JKBHGMLPHOB > EJEDANLAMBI)
		{
			JKBHGMLPHOB = EJEDANLAMBI;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(EJEDANLAMBI, ref CCMDOGJDMGO, PDPDGCNHCFN);
		}
	}

	private void PAAPBPEHJFB()
	{
		AJKHJMMHBIL();
		LGOHNGIHNBP = RadicalRoutine.Create(HLAMDLNCDED());
		StartCoroutine(RadicalRoutine.Run(LGOHNGIHNBP.enumerator));
	}

	public void FENFOCHBBMM(WeaponLevelsSetup JMMJHCOKCGG)
	{
		if (JJOBAFMKGHK != null)
		{
			MCLCCFPNHLA();
		}
		JJOBAFMKGHK = JMMJHCOKCGG;
		BLKPDBBMICL();
	}

	private void EKJGMMAKNBM()
	{
		if (LGOHNGIHNBP != null)
		{
			LGOHNGIHNBP.Cancel();
			LGOHNGIHNBP = null;
		}
	}

	public void EGBPOAIPKCF()
	{
		FNJEGABMIFN.SetActive(value: true);
		LPBCDBHKAFI.SetActive(value: false);
		FNLJKJLNBBH(0);
	}

	private void JCLKNNHFIIE(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1953f * Singleton<GuiTexureAssets>.instance.DLBBEAPEPHD());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private IEnumerator LKNJIBFNICF()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}

	private void AOMLIEFIFKK()
	{
		BGMLFLBLMFD = false;
		KOGDHLDDDHF = true;
		PGFDMPGMJHM = true;
		BPHIFLAEPJB = true;
		BEEGGDEPGEB = true;
		LHIJMIMBPCF = false;
		JEPENIBNLCE = true;
		ODDMPOGOPDD = false;
		PMFDBOBCEGD = true;
		KIFLNFPKPAF = false;
		JEOAMGIOIPB = true;
		EKGIKOEAENC = true;
		CPNLFNPOPHC = false;
		PLELLGKANCL = true;
		EILLIBENOAL = false;
		KDJFEEHCLIM = false;
		CEPHGILHCLL = true;
		JOJICKFBOMC = false;
		IJHPKMJDANI = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.BHCEOOLEHHG)
			{
			case WeaponCategory.None:
				BGMLFLBLMFD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				KOGDHLDDDHF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle:
				PGFDMPGMJHM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				BPHIFLAEPJB |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.SMG:
				BEEGGDEPGEB |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				LHIJMIMBPCF |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Pistol):
				JEPENIBNLCE |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Primary:
				ODDMPOGOPDD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				PMFDBOBCEGD |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				KIFLNFPKPAF |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				JEOAMGIOIPB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle):
				EKGIKOEAENC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				CPNLFNPOPHC |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade):
				PLELLGKANCL |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				EILLIBENOAL |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.Grenade | WeaponCategory.Pistol):
				KDJFEEHCLIM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				CEPHGILHCLL |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol):
				JOJICKFBOMC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				IJHPKMJDANI |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	private void BBOBPKOMNNO()
	{
		BGMLFLBLMFD = false;
		KOGDHLDDDHF = true;
		PGFDMPGMJHM = false;
		BPHIFLAEPJB = false;
		BEEGGDEPGEB = true;
		LHIJMIMBPCF = false;
		JEPENIBNLCE = true;
		ODDMPOGOPDD = false;
		PMFDBOBCEGD = false;
		KIFLNFPKPAF = true;
		JEOAMGIOIPB = false;
		EKGIKOEAENC = false;
		CPNLFNPOPHC = true;
		PLELLGKANCL = true;
		EILLIBENOAL = false;
		KDJFEEHCLIM = false;
		CEPHGILHCLL = true;
		JOJICKFBOMC = false;
		IJHPKMJDANI = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.BHCEOOLEHHG)
			{
			case WeaponCategory.None:
				BGMLFLBLMFD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				KOGDHLDDDHF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle:
				PGFDMPGMJHM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				BPHIFLAEPJB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.SMG:
				BEEGGDEPGEB |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				LHIJMIMBPCF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun:
				JEPENIBNLCE |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Primary:
				ODDMPOGOPDD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				PMFDBOBCEGD |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade):
				KIFLNFPKPAF |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				JEOAMGIOIPB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				EKGIKOEAENC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CPNLFNPOPHC |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				PLELLGKANCL |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				EILLIBENOAL |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.SMG | WeaponCategory.Pistol):
				KDJFEEHCLIM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CEPHGILHCLL |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol:
				JOJICKFBOMC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				IJHPKMJDANI |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	private void FNLJKJLNBBH(int IDLMJLCFMJG)
	{
		AELDNJLNPGO.SetActive(IDLMJLCFMJG > 0);
		MFIAHNMIJAH.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void OADICODBJLM(int IDLMJLCFMJG)
	{
		AELDNJLNPGO.SetActive(IDLMJLCFMJG > 0);
		MFIAHNMIJAH.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void DIEANEHCMMB()
	{
		BGMLFLBLMFD = false;
		KOGDHLDDDHF = false;
		PGFDMPGMJHM = false;
		BPHIFLAEPJB = false;
		BEEGGDEPGEB = false;
		LHIJMIMBPCF = false;
		JEPENIBNLCE = false;
		ODDMPOGOPDD = false;
		PMFDBOBCEGD = false;
		KIFLNFPKPAF = false;
		JEOAMGIOIPB = false;
		EKGIKOEAENC = false;
		CPNLFNPOPHC = false;
		PLELLGKANCL = false;
		EILLIBENOAL = false;
		KDJFEEHCLIM = false;
		CEPHGILHCLL = false;
		JOJICKFBOMC = false;
		IJHPKMJDANI = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.BHCEOOLEHHG)
			{
			case WeaponCategory.AssaultRifle:
				BGMLFLBLMFD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				KOGDHLDDDHF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG:
				PGFDMPGMJHM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				BPHIFLAEPJB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.LMG:
				BEEGGDEPGEB |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				LHIJMIMBPCF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Minigun:
				JEPENIBNLCE |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle:
				ODDMPOGOPDD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				PMFDBOBCEGD |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Shotgun:
				KIFLNFPKPAF |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				JEOAMGIOIPB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Grenade:
				EKGIKOEAENC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CPNLFNPOPHC |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.RocketLauncher:
				PLELLGKANCL |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				EILLIBENOAL |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.GrenadeLauncher:
				KDJFEEHCLIM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CEPHGILHCLL |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Pistol:
				JOJICKFBOMC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				IJHPKMJDANI |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	private void AJKHJMMHBIL()
	{
		if (LGOHNGIHNBP != null)
		{
			LGOHNGIHNBP.Cancel();
			LGOHNGIHNBP = null;
		}
	}

	private void KFABBPCHPJA()
	{
		if (LGOHNGIHNBP != null)
		{
			LGOHNGIHNBP.Cancel();
			LGOHNGIHNBP = null;
		}
	}

	private void HMBGNJBOJOD()
	{
		BGGIOAEELFB();
		LGOHNGIHNBP = RadicalRoutine.Create(JJBPNEHCMDB());
		StartCoroutine(RadicalRoutine.Run(LGOHNGIHNBP.enumerator));
	}

	private static void HECLHGPCBHJ(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
	}

	public void CEBAEHCDIOH()
	{
		int num = Singleton<OfferManager>.instance.AGGNADBINOI();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.None, (AKDLEDNDIEO)4);
		int num5 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, (AKDLEDNDIEO)0);
		int num6 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, (AKDLEDNDIEO)5);
		int num7 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.LMG, (AKDLEDNDIEO)8);
		int num9 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), (AKDLEDNDIEO)5);
		int num10 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.Primary, (AKDLEDNDIEO)0);
		int num11 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.SMG, AKDLEDNDIEO.Buy);
		int num12 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.Shotgun), (AKDLEDNDIEO)0);
		int num13 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.SMG, (AKDLEDNDIEO)4);
		int num14 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun, AKDLEDNDIEO.Buy);
		int num15 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher, (AKDLEDNDIEO)8);
		int num16 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade), AKDLEDNDIEO.Buy);
		int num17 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.SMG | WeaponCategory.Grenade), (AKDLEDNDIEO)4);
		int num18 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol), (AKDLEDNDIEO)0);
		int num19 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Pistol), (AKDLEDNDIEO)7);
		int num20 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade, (AKDLEDNDIEO)0);
		int num21 = Singleton<OfferManager>.instance.FOILGIALCLF(~WeaponCategory.AssaultRifle, AKDLEDNDIEO.Buy);
		int[] array = new int[4];
		array[0] = num3;
		array[1] = num5;
		array[6] = num7;
		int num22 = Mathf.Min(array);
		int[] array2 = new int[8];
		array2[0] = num4;
		array2[0] = num6;
		array2[3] = num8;
		int num23 = Mathf.Min(array2);
		int num24 = Mathf.Min(num10, num12);
		int[] array3 = new int[7];
		array3[1] = num9;
		array3[1] = num11;
		array3[2] = num13;
		int num25 = Mathf.Min(array3);
		int[] array4 = new int[1];
		array4[0] = num14;
		array4[0] = num16;
		array4[7] = num18;
		int num26 = Mathf.Min(array4);
		int[] array5 = new int[0];
		array5[0] = num15;
		array5[0] = num17;
		array5[3] = num19;
		int num27 = Mathf.Min(array5);
		bool flag = num <= 1 || !(weaponLevelsSetup != null) || weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 > 1 && weaponLevelsSetup != null && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		COFMJJGEMED();
		bool flag3 = num3 > 1 && BGMLFLBLMFD;
		bool flag4 = num4 <= 1 || KOGDHLDDDHF;
		bool flag5 = num5 > 1 && PGFDMPGMJHM;
		bool flag6 = num6 <= 0 || BPHIFLAEPJB;
		bool flag7 = num7 <= 1 || BEEGGDEPGEB;
		bool flag8 = num8 > 0 && LHIJMIMBPCF;
		bool flag9 = num9 > 0 && JEPENIBNLCE;
		bool flag10 = num10 <= 1 || ODDMPOGOPDD;
		bool flag11 = num11 > 0 && PMFDBOBCEGD;
		bool flag12 = num12 > 1 && KIFLNFPKPAF;
		bool flag13 = num13 <= 0 || JEOAMGIOIPB;
		bool flag14 = num14 > 0 && EKGIKOEAENC;
		bool flag15 = num15 > 0 && CPNLFNPOPHC;
		bool flag16 = num16 > 1 && PLELLGKANCL;
		bool flag17 = num17 <= 1 || EILLIBENOAL;
		bool flag18 = num18 <= 0 || KDJFEEHCLIM;
		bool flag19 = num19 > 0 && CEPHGILHCLL;
		bool flag20 = num20 > 1 && JOJICKFBOMC;
		bool flag21 = num21 > 0 && IJHPKMJDANI;
		bool flag22 = num22 > 1 && !BGMLFLBLMFD && !PGFDMPGMJHM && BEEGGDEPGEB;
		bool flag23 = num23 <= 1 || (!KOGDHLDDDHF && !BPHIFLAEPJB && LHIJMIMBPCF);
		bool flag24 = num24 <= 0 || (!ODDMPOGOPDD && KIFLNFPKPAF);
		bool flag25 = num25 > 0 && !JEPENIBNLCE && !PMFDBOBCEGD && JEOAMGIOIPB;
		bool flag26 = num26 > 1 && (EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM);
		bool flag27 = num27 <= 0 || CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL;
		bool flag28 = num3 > 0 && num5 > 1 && num7 > 0 && num10 > 1 && num12 > 0 && num14 > 0 && num16 > 1 && num18 > 0 && num20 > 0;
		bool flag29 = num4 > 1 && num6 > 1 && num8 > 0 && num9 > 1 && num11 > 1 && num13 > 0 && num15 > 0 && num17 > 1 && num19 > 1 && num21 > 1;
		bool flag30 = flag28 && !BGMLFLBLMFD && !PGFDMPGMJHM && !BEEGGDEPGEB && !ODDMPOGOPDD && !KIFLNFPKPAF && !EKGIKOEAENC && !PLELLGKANCL && !KDJFEEHCLIM && JOJICKFBOMC;
		bool flag31 = !flag29 || KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF || JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB || CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL || IJHPKMJDANI;
		bool flag32 = !flag30 && !flag3 && !flag5 && !flag7 && !flag10 && !flag12 && !flag14 && !flag16 && !flag18 && flag20;
		bool flag33 = flag31 || (!flag4 && !flag6 && !flag8 && !flag9 && !flag11 && !flag13 && !flag15 && !flag17 && !flag19 && flag21);
		IMKOOGCOIAL.SetActive(flag || flag2 || flag30 || flag31 || flag32 || flag33);
		if (flag30 || flag31)
		{
			UILabel iOBMACBHJCC = IOBMACBHJCC;
			object[] array6 = new object[1];
			array6[1] = ((!flag30) ? num23 : num22);
			iOBMACBHJCC.text = Localization.LocalizeFormat("RETRYPERM", array6);
			FCAOHMAJIMD.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime());
			WinStreakCounter fCAOHMAJIMD = FCAOHMAJIMD;
			fCAOHMAJIMD.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			WinStreakCounter fCAOHMAJIMD2 = FCAOHMAJIMD;
			fCAOHMAJIMD2.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD2.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1282f);
		}
		else if (flag32 || flag33)
		{
			FCAOHMAJIMD.FCGPLOBEHDL();
			WinStreakCounter fCAOHMAJIMD3 = FCAOHMAJIMD;
			fCAOHMAJIMD3.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD3.JEMKCLKCOMI, new Action(SaleWeapons));
			if (flag22 || flag23)
			{
				UILabel iOBMACBHJCC2 = IOBMACBHJCC;
				object[] array7 = new object[0];
				array7[0] = ((!flag22) ? num23 : num22);
				iOBMACBHJCC2.text = Localization.LocalizeFormat("country-netherlands", array7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.AssaultRifle, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag24 || flag25)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("DailyRentalMessage{0}{1}{2}", (!flag24) ? num25 : num24);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.LMG | WeaponCategory.Shotgun), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag26 || flag27)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("TuneListener trackerDidReceiveDeeplink: ", (!flag26) ? num27 : num26);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag3 || flag4)
			{
				UILabel iOBMACBHJCC3 = IOBMACBHJCC;
				object[] array8 = new object[0];
				array8[1] = ((!flag3) ? num4 : num3);
				iOBMACBHJCC3.text = Localization.LocalizeFormat("Cancel clicked, will to try call disconnect ", array8);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.AssaultRifle, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag5 || flag6)
			{
				UILabel iOBMACBHJCC4 = IOBMACBHJCC;
				object[] array9 = new object[1];
				array9[1] = ((!flag5) ? num6 : num5);
				iOBMACBHJCC4.text = Localization.LocalizeFormat("#AccoutCheck# GoogleLoggedIn tutorial - Check current gpgs on server : {0}", array9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag7 || flag8)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ItemsOwned_Rarity_4", (!flag7) ? num8 : num7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle | WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag9)
			{
				UILabel iOBMACBHJCC5 = IOBMACBHJCC;
				object[] array10 = new object[1];
				array10[1] = num9;
				iOBMACBHJCC5.text = Localization.LocalizeFormat("EmailLogin(", array10);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(~(WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag10 || flag11)
			{
				UILabel iOBMACBHJCC6 = IOBMACBHJCC;
				object[] array11 = new object[0];
				array11[1] = ((!flag10) ? num11 : num10);
				iOBMACBHJCC6.text = Localization.LocalizeFormat("Start", array11);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.LMG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag12 || flag13)
			{
				UILabel iOBMACBHJCC7 = IOBMACBHJCC;
				object[] array12 = new object[1];
				array12[1] = ((!flag12) ? num13 : num12);
				iOBMACBHJCC7.text = Localization.LocalizeFormat("menu-arena-ticket", array12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag14 || flag15)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("604 GAME END", (!flag14) ? num15 : num14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.SMG | WeaponCategory.RocketLauncher, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag16 || flag17)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("ID_", (!flag16) ? num17 : num16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.Shotgun), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag18 || flag19)
			{
				UILabel iOBMACBHJCC8 = IOBMACBHJCC;
				object[] array13 = new object[1];
				array13[1] = ((!flag18) ? num19 : num18);
				iOBMACBHJCC8.text = Localization.LocalizeFormat("kr", array13);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else
			{
				if (!flag20 && !flag21)
				{
					IOBMACBHJCC.text = string.Empty;
					FCAOHMAJIMD.KGNGFHMBHMJ.text = string.Empty;
					AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1210f);
					return;
				}
				UILabel iOBMACBHJCC9 = IOBMACBHJCC;
				object[] array14 = new object[0];
				array14[0] = ((!flag20) ? num21 : num20);
				iOBMACBHJCC9.text = Localization.LocalizeFormat("unlock level for: ", array14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(~(WeaponCategory.Primary | WeaponCategory.Shotgun | WeaponCategory.Pistol), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			float num28 = FCAOHMAJIMD.KGNGFHMBHMJ.relativeSize.x * FCAOHMAJIMD.KGNGFHMBHMJ.transform.localScale.x;
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(num28 + 1804f);
		}
		else if (flag || flag2)
		{
			UILabel iOBMACBHJCC10 = IOBMACBHJCC;
			object[] array15 = new object[0];
			array15[0] = ((!flag) ? num2 : num);
			iOBMACBHJCC10.text = Localization.LocalizeFormat("S", array15);
			FCAOHMAJIMD.MHLJHMOPDAO(Singleton<OfferManager>.instance.CCHLAIMMEPN());
			WinStreakCounter fCAOHMAJIMD4 = FCAOHMAJIMD;
			fCAOHMAJIMD4.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD4.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			WinStreakCounter fCAOHMAJIMD5 = FCAOHMAJIMD;
			fCAOHMAJIMD5.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD5.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1629f);
		}
		else
		{
			FCAOHMAJIMD.KEIIENDMKLN();
			WinStreakCounter fCAOHMAJIMD6 = FCAOHMAJIMD;
			fCAOHMAJIMD6.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD6.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1102f);
		}
	}

	private void NGPMJOHAMFP()
	{
		float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 68f;
		DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
	}

	public void BJKDLCCFMHK()
	{
		int num = Singleton<OfferManager>.instance.AGGNADBINOI();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.None, AKDLEDNDIEO.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.None, (AKDLEDNDIEO)6);
		int num5 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.None, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.SniperRifle, AKDLEDNDIEO.Both);
		int num7 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.Primary, AKDLEDNDIEO.Buy);
		int num8 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.SMG, AKDLEDNDIEO.Both);
		int num9 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade), AKDLEDNDIEO.Both);
		int num10 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, AKDLEDNDIEO.Buy);
		int num11 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.SniperRifle, AKDLEDNDIEO.Upgrade);
		int num12 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Grenade), (AKDLEDNDIEO)0);
		int num13 = Singleton<OfferManager>.instance.FOILGIALCLF(~WeaponCategory.Shotgun, (AKDLEDNDIEO)0);
		int num14 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.Shotgun), AKDLEDNDIEO.Buy);
		int num15 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.SniperRifle | WeaponCategory.Grenade), AKDLEDNDIEO.Both);
		int num16 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade), AKDLEDNDIEO.Buy);
		int num17 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.SMG | WeaponCategory.LMG), AKDLEDNDIEO.Both);
		int num18 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.Shotgun | WeaponCategory.Pistol), AKDLEDNDIEO.Buy);
		int num19 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol, AKDLEDNDIEO.Buy);
		int num20 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade, AKDLEDNDIEO.Buy);
		int num21 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), (AKDLEDNDIEO)7);
		int[] array = new int[4];
		array[1] = num3;
		array[1] = num5;
		array[8] = num7;
		int num22 = Mathf.Min(array);
		int[] array2 = new int[8];
		array2[1] = num4;
		array2[1] = num6;
		array2[5] = num8;
		int num23 = Mathf.Min(array2);
		int num24 = Mathf.Min(num10, num12);
		int[] array3 = new int[6];
		array3[1] = num9;
		array3[0] = num11;
		array3[5] = num13;
		int num25 = Mathf.Min(array3);
		int[] array4 = new int[7];
		array4[0] = num14;
		array4[0] = num16;
		array4[0] = num18;
		int num26 = Mathf.Min(array4);
		int[] array5 = new int[1];
		array5[1] = num15;
		array5[1] = num17;
		array5[8] = num19;
		int num27 = Mathf.Min(array5);
		bool flag = num > 1 && weaponLevelsSetup != null && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
		bool flag2 = num2 <= 0 || !(weaponLevelsSetup != null) || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		DIEANEHCMMB();
		bool flag3 = num3 <= 0 || BGMLFLBLMFD;
		bool flag4 = num4 > 0 && KOGDHLDDDHF;
		bool flag5 = num5 > 0 && PGFDMPGMJHM;
		bool flag6 = num6 <= 1 || BPHIFLAEPJB;
		bool flag7 = num7 > 0 && BEEGGDEPGEB;
		bool flag8 = num8 > 0 && LHIJMIMBPCF;
		bool flag9 = num9 <= 0 || JEPENIBNLCE;
		bool flag10 = num10 > 0 && ODDMPOGOPDD;
		bool flag11 = num11 <= 1 || PMFDBOBCEGD;
		bool flag12 = num12 <= 0 || KIFLNFPKPAF;
		bool flag13 = num13 <= 1 || JEOAMGIOIPB;
		bool flag14 = num14 <= 1 || EKGIKOEAENC;
		bool flag15 = num15 > 1 && CPNLFNPOPHC;
		bool flag16 = num16 > 0 && PLELLGKANCL;
		bool flag17 = num17 > 0 && EILLIBENOAL;
		bool flag18 = num18 <= 1 || KDJFEEHCLIM;
		bool flag19 = num19 <= 1 || CEPHGILHCLL;
		bool flag20 = num20 <= 0 || JOJICKFBOMC;
		bool flag21 = num21 <= 1 || IJHPKMJDANI;
		bool flag22 = num22 <= 0 || (!BGMLFLBLMFD && !PGFDMPGMJHM && BEEGGDEPGEB);
		bool flag23 = num23 > 1 && (KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF);
		bool flag24 = num24 > 0 && !ODDMPOGOPDD && KIFLNFPKPAF;
		bool flag25 = num25 <= 0 || JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB;
		bool flag26 = num26 > 0 && !EKGIKOEAENC && !PLELLGKANCL && KDJFEEHCLIM;
		bool flag27 = num27 > 1 && !CPNLFNPOPHC && !EILLIBENOAL && CEPHGILHCLL;
		bool flag28 = num3 <= 1 || num5 <= 1 || num7 <= 0 || num10 <= 1 || num12 <= 1 || num14 <= 1 || num16 <= 0 || num18 <= 1 || num20 > 1;
		bool flag29 = num4 > 0 && num6 > 0 && num8 > 1 && num9 > 0 && num11 > 0 && num13 > 1 && num15 > 0 && num17 > 1 && num19 > 0 && num21 > 1;
		bool flag30 = !flag28 || (!BGMLFLBLMFD && !PGFDMPGMJHM && !BEEGGDEPGEB && !ODDMPOGOPDD && !KIFLNFPKPAF && !EKGIKOEAENC && !PLELLGKANCL && !KDJFEEHCLIM && JOJICKFBOMC);
		bool flag31 = flag29 && !KOGDHLDDDHF && !BPHIFLAEPJB && !LHIJMIMBPCF && !JEPENIBNLCE && !PMFDBOBCEGD && !JEOAMGIOIPB && !CPNLFNPOPHC && !EILLIBENOAL && !CEPHGILHCLL && IJHPKMJDANI;
		bool flag32 = !flag30 && (flag3 || flag5 || flag7 || flag10 || flag12 || flag14 || flag16 || flag18 || flag20);
		bool flag33 = flag31 || flag4 || flag6 || flag8 || flag9 || flag11 || flag13 || flag15 || flag17 || flag19 || flag21;
		IMKOOGCOIAL.SetActive(!flag && !flag2 && !flag30 && !flag31 && !flag32 && flag33);
		if (flag30 || flag31)
		{
			IOBMACBHJCC.text = Localization.LocalizeFormat("Squad", (!flag30) ? num23 : num22);
			FCAOHMAJIMD.FPNEIICLJFG(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime());
			WinStreakCounter fCAOHMAJIMD = FCAOHMAJIMD;
			fCAOHMAJIMD.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			WinStreakCounter fCAOHMAJIMD2 = FCAOHMAJIMD;
			fCAOHMAJIMD2.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD2.JEMKCLKCOMI, new Action(CEBAEHCDIOH));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1488f);
		}
		else if (flag32 || flag33)
		{
			FCAOHMAJIMD.LOINIDOGNCO();
			WinStreakCounter fCAOHMAJIMD3 = FCAOHMAJIMD;
			fCAOHMAJIMD3.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD3.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			if (flag22 || flag23)
			{
				UILabel iOBMACBHJCC = IOBMACBHJCC;
				object[] array6 = new object[1];
				array6[1] = ((!flag22) ? num23 : num22);
				iOBMACBHJCC.text = Localization.LocalizeFormat("ID_WARNING_OPPONENTDISCONNECTED", array6);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle | WeaponCategory.SMG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag24 || flag25)
			{
				UILabel iOBMACBHJCC2 = IOBMACBHJCC;
				object[] array7 = new object[0];
				array7[1] = ((!flag24) ? num25 : num24);
				iOBMACBHJCC2.text = Localization.LocalizeFormat("10 Unit Categories\tWas shown {0}\tGames {1}/{2}", array7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag26 || flag27)
			{
				UILabel iOBMACBHJCC3 = IOBMACBHJCC;
				object[] array8 = new object[0];
				array8[0] = ((!flag26) ? num27 : num26);
				iOBMACBHJCC3.text = Localization.LocalizeFormat("InfluencerLink", array8);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.SniperRifle | WeaponCategory.Shotgun, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag3 || flag4)
			{
				UILabel iOBMACBHJCC4 = IOBMACBHJCC;
				object[] array9 = new object[1];
				array9[1] = ((!flag3) ? num4 : num3);
				iOBMACBHJCC4.text = Localization.LocalizeFormat(" ", array9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.None, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag5 || flag6)
			{
				UILabel iOBMACBHJCC5 = IOBMACBHJCC;
				object[] array10 = new object[0];
				array10[0] = ((!flag5) ? num6 : num5);
				iOBMACBHJCC5.text = Localization.LocalizeFormat("menu-gold", array10);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SniperRifle, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag7 || flag8)
			{
				UILabel iOBMACBHJCC6 = IOBMACBHJCC;
				object[] array11 = new object[0];
				array11[1] = ((!flag7) ? num8 : num7);
				iOBMACBHJCC6.text = Localization.LocalizeFormat("/Player_", array11);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.SMG, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag9)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("\"", num9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag10 || flag11)
			{
				UILabel iOBMACBHJCC7 = IOBMACBHJCC;
				object[] array12 = new object[1];
				array12[1] = ((!flag10) ? num11 : num10);
				iOBMACBHJCC7.text = Localization.LocalizeFormat("Caught Exception at startup ", array12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.SMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag12 || flag13)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat(", ", (!flag12) ? num13 : num12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag14 || flag15)
			{
				UILabel iOBMACBHJCC8 = IOBMACBHJCC;
				object[] array13 = new object[0];
				array13[1] = ((!flag14) ? num15 : num14);
				iOBMACBHJCC8.text = Localization.LocalizeFormat("FLOATVALUE", array13);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag16 || flag17)
			{
				UILabel iOBMACBHJCC9 = IOBMACBHJCC;
				object[] array14 = new object[1];
				array14[1] = ((!flag16) ? num17 : num16);
				iOBMACBHJCC9.text = Localization.LocalizeFormat("ID_CONFIRM_SQUADFULL", array14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.Grenade, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag18 || flag19)
			{
				UILabel iOBMACBHJCC10 = IOBMACBHJCC;
				object[] array15 = new object[1];
				array15[1] = ((!flag18) ? num19 : num18);
				iOBMACBHJCC10.text = Localization.LocalizeFormat("ID_CONFIRM_ACCOUNTBANNED", array15);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else
			{
				if (!flag20 && !flag21)
				{
					IOBMACBHJCC.text = string.Empty;
					FCAOHMAJIMD.KGNGFHMBHMJ.text = string.Empty;
					AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(961f);
					return;
				}
				UILabel iOBMACBHJCC11 = IOBMACBHJCC;
				object[] array16 = new object[0];
				array16[1] = ((!flag20) ? num21 : num20);
				iOBMACBHJCC11.text = Localization.LocalizeFormat("description", array16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			float num28 = FCAOHMAJIMD.KGNGFHMBHMJ.relativeSize.x * FCAOHMAJIMD.KGNGFHMBHMJ.transform.localScale.x;
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(num28 + 1843f);
		}
		else if (flag || flag2)
		{
			UILabel iOBMACBHJCC12 = IOBMACBHJCC;
			object[] array17 = new object[0];
			array17[0] = ((!flag) ? num2 : num);
			iOBMACBHJCC12.text = Localization.LocalizeFormat("ID_CONVERTSCRAPSTOELITEPARTS", array17);
			FCAOHMAJIMD.APFDDFPMACA(Singleton<OfferManager>.instance.DiscountedWeaponOfferEndtime());
			WinStreakCounter fCAOHMAJIMD4 = FCAOHMAJIMD;
			fCAOHMAJIMD4.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD4.JEMKCLKCOMI, new Action(GCODMPDLIAK));
			WinStreakCounter fCAOHMAJIMD5 = FCAOHMAJIMD;
			fCAOHMAJIMD5.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD5.JEMKCLKCOMI, new Action(SaleWeapons));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1913f);
		}
		else
		{
			FCAOHMAJIMD.BGHNMCPLIPE();
			WinStreakCounter fCAOHMAJIMD6 = FCAOHMAJIMD;
			fCAOHMAJIMD6.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD6.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(605f);
		}
	}

	private void OAKNNNMDLAH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (JJOBAFMKGHK != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			resourceLoaderTexture2D.FreeAsset(JJOBAFMKGHK.playerWeapon.FPFCCDCGEHC);
			JJOBAFMKGHK = null;
		}
	}

	public void SetUpWeaponLook(WeaponLevelsSetup JMMJHCOKCGG)
	{
		if (JJOBAFMKGHK != null)
		{
			NNOIIKEACMH();
		}
		JJOBAFMKGHK = JMMJHCOKCGG;
		BLKPDBBMICL();
	}

	private void COFMJJGEMED()
	{
		BGMLFLBLMFD = true;
		KOGDHLDDDHF = false;
		PGFDMPGMJHM = true;
		BPHIFLAEPJB = false;
		BEEGGDEPGEB = true;
		LHIJMIMBPCF = false;
		JEPENIBNLCE = false;
		ODDMPOGOPDD = true;
		PMFDBOBCEGD = true;
		KIFLNFPKPAF = false;
		JEOAMGIOIPB = false;
		EKGIKOEAENC = true;
		CPNLFNPOPHC = true;
		PLELLGKANCL = false;
		EILLIBENOAL = false;
		KDJFEEHCLIM = false;
		CEPHGILHCLL = true;
		JOJICKFBOMC = false;
		IJHPKMJDANI = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.BHCEOOLEHHG)
			{
			case WeaponCategory.AssaultRifle:
				BGMLFLBLMFD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				KOGDHLDDDHF |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG:
				PGFDMPGMJHM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				BPHIFLAEPJB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.LMG:
				BEEGGDEPGEB |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				LHIJMIMBPCF |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher):
				JEPENIBNLCE |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle:
				ODDMPOGOPDD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				PMFDBOBCEGD |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.Shotgun:
				KIFLNFPKPAF |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				JEOAMGIOIPB |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~WeaponCategory.Primary:
				EKGIKOEAENC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				CPNLFNPOPHC |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade):
				PLELLGKANCL |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				EILLIBENOAL |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Pistol):
				KDJFEEHCLIM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				CEPHGILHCLL |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol:
				JOJICKFBOMC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				IJHPKMJDANI |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	[CompilerGenerated]
	private static void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
	}

	public void PHGOFPAEENN()
	{
		int num = Singleton<OfferManager>.instance.AGGNADBINOI();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.None, (AKDLEDNDIEO)0);
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.None, AKDLEDNDIEO.Upgrade);
		int num5 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, AKDLEDNDIEO.Buy);
		int num6 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.SMG | WeaponCategory.LMG, (AKDLEDNDIEO)6);
		int num7 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, (AKDLEDNDIEO)0);
		int num8 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG | WeaponCategory.LMG, (AKDLEDNDIEO)8);
		int num9 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Grenade | WeaponCategory.Pistol, AKDLEDNDIEO.Buy);
		int num10 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.LMG, AKDLEDNDIEO.Buy);
		int num11 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle | WeaponCategory.LMG, (AKDLEDNDIEO)0);
		int num12 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.Grenade, AKDLEDNDIEO.Buy);
		int num13 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), (AKDLEDNDIEO)0);
		int num14 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade), (AKDLEDNDIEO)0);
		int num15 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun, (AKDLEDNDIEO)6);
		int num16 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.Primary | WeaponCategory.Shotgun | WeaponCategory.Grenade), (AKDLEDNDIEO)0);
		int num17 = Singleton<OfferManager>.instance.FOILGIALCLF(~(WeaponCategory.AssaultRifle | WeaponCategory.Grenade), AKDLEDNDIEO.Both);
		int num18 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.LMG | WeaponCategory.Shotgun | WeaponCategory.Grenade, (AKDLEDNDIEO)0);
		int num19 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol, (AKDLEDNDIEO)4);
		int num20 = Singleton<OfferManager>.instance.FOILGIALCLF(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade, AKDLEDNDIEO.Buy);
		int num21 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(~(WeaponCategory.LMG | WeaponCategory.RocketLauncher), AKDLEDNDIEO.Buy);
		int[] array = new int[8];
		array[0] = num3;
		array[0] = num5;
		array[0] = num7;
		int num22 = Mathf.Min(array);
		int[] array2 = new int[4];
		array2[0] = num4;
		array2[0] = num6;
		array2[1] = num8;
		int num23 = Mathf.Min(array2);
		int num24 = Mathf.Min(num10, num12);
		int[] array3 = new int[0];
		array3[1] = num9;
		array3[0] = num11;
		array3[2] = num13;
		int num25 = Mathf.Min(array3);
		int[] array4 = new int[2];
		array4[1] = num14;
		array4[0] = num16;
		array4[4] = num18;
		int num26 = Mathf.Min(array4);
		int[] array5 = new int[4];
		array5[0] = num15;
		array5[1] = num17;
		array5[8] = num19;
		int num27 = Mathf.Min(array5);
		bool flag = num > 1 && weaponLevelsSetup != null && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool flag2 = num2 <= 1 || !(weaponLevelsSetup != null) || !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
		BOMCNCMJPJH();
		bool flag3 = num3 <= 1 || BGMLFLBLMFD;
		bool flag4 = num4 > 1 && KOGDHLDDDHF;
		bool flag5 = num5 > 1 && PGFDMPGMJHM;
		bool flag6 = num6 <= 1 || BPHIFLAEPJB;
		bool flag7 = num7 <= 1 || BEEGGDEPGEB;
		bool flag8 = num8 <= 1 || LHIJMIMBPCF;
		bool flag9 = num9 <= 0 || JEPENIBNLCE;
		bool flag10 = num10 <= 1 || ODDMPOGOPDD;
		bool flag11 = num11 > 0 && PMFDBOBCEGD;
		bool flag12 = num12 <= 0 || KIFLNFPKPAF;
		bool flag13 = num13 > 1 && JEOAMGIOIPB;
		bool flag14 = num14 > 0 && EKGIKOEAENC;
		bool flag15 = num15 <= 1 || CPNLFNPOPHC;
		bool flag16 = num16 > 0 && PLELLGKANCL;
		bool flag17 = num17 > 1 && EILLIBENOAL;
		bool flag18 = num18 > 0 && KDJFEEHCLIM;
		bool flag19 = num19 > 1 && CEPHGILHCLL;
		bool flag20 = num20 <= 1 || JOJICKFBOMC;
		bool flag21 = num21 > 1 && IJHPKMJDANI;
		bool flag22 = num22 <= 1 || BGMLFLBLMFD || PGFDMPGMJHM || BEEGGDEPGEB;
		bool flag23 = num23 > 0 && !KOGDHLDDDHF && !BPHIFLAEPJB && LHIJMIMBPCF;
		bool flag24 = num24 > 1 && !ODDMPOGOPDD && KIFLNFPKPAF;
		bool flag25 = num25 > 0 && (JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB);
		bool flag26 = num26 <= 0 || EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM;
		bool flag27 = num27 > 1 && !CPNLFNPOPHC && !EILLIBENOAL && CEPHGILHCLL;
		bool flag28 = num3 > 0 && num5 > 0 && num7 > 0 && num10 > 0 && num12 > 0 && num14 > 0 && num16 > 0 && num18 > 1 && num20 > 1;
		bool flag29 = num4 <= 0 || num6 <= 0 || num8 <= 0 || num9 <= 0 || num11 <= 1 || num13 <= 0 || num15 <= 0 || num17 <= 1 || num19 <= 0 || num21 > 1;
		bool flag30 = !flag28 || BGMLFLBLMFD || PGFDMPGMJHM || BEEGGDEPGEB || ODDMPOGOPDD || KIFLNFPKPAF || EKGIKOEAENC || PLELLGKANCL || KDJFEEHCLIM || JOJICKFBOMC;
		bool flag31 = flag29 && (KOGDHLDDDHF || BPHIFLAEPJB || LHIJMIMBPCF || JEPENIBNLCE || PMFDBOBCEGD || JEOAMGIOIPB || CPNLFNPOPHC || EILLIBENOAL || CEPHGILHCLL || IJHPKMJDANI);
		bool flag32 = flag30 || (!flag3 && !flag5 && !flag7 && !flag10 && !flag12 && !flag14 && !flag16 && !flag18 && flag20);
		bool flag33 = flag31 || (!flag4 && !flag6 && !flag8 && !flag9 && !flag11 && !flag13 && !flag15 && !flag17 && !flag19 && flag21);
		IMKOOGCOIAL.SetActive(!flag && !flag2 && !flag30 && !flag31 && !flag32 && flag33);
		if (flag30 || flag31)
		{
			UILabel iOBMACBHJCC = IOBMACBHJCC;
			object[] array6 = new object[1];
			array6[1] = ((!flag30) ? num23 : num22);
			iOBMACBHJCC.text = Localization.LocalizeFormat("ID_GOLDSMALL", array6);
			FCAOHMAJIMD.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime());
			WinStreakCounter fCAOHMAJIMD = FCAOHMAJIMD;
			fCAOHMAJIMD.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			WinStreakCounter fCAOHMAJIMD2 = FCAOHMAJIMD;
			fCAOHMAJIMD2.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD2.JEMKCLKCOMI, new Action(PHGOFPAEENN));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1086f);
		}
		else if (flag32 || flag33)
		{
			FCAOHMAJIMD.LOINIDOGNCO();
			WinStreakCounter fCAOHMAJIMD3 = FCAOHMAJIMD;
			fCAOHMAJIMD3.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD3.JEMKCLKCOMI, new Action(SaleWeapons));
			if (flag22 || flag23)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("game-missions-blue-mission-ico", (!flag22) ? num23 : num22);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.AssaultRifle, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag24 || flag25)
			{
				UILabel iOBMACBHJCC2 = IOBMACBHJCC;
				object[] array7 = new object[0];
				array7[1] = ((!flag24) ? num25 : num24);
				iOBMACBHJCC2.text = Localization.LocalizeFormat("Enemy could not be spawned", array7);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag26 || flag27)
			{
				UILabel iOBMACBHJCC3 = IOBMACBHJCC;
				object[] array8 = new object[0];
				array8[1] = ((!flag26) ? num27 : num26);
				iOBMACBHJCC3.text = Localization.LocalizeFormat("game-card-bronze-big", array8);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Grenade), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else if (flag3 || flag4)
			{
				UILabel iOBMACBHJCC4 = IOBMACBHJCC;
				object[] array9 = new object[0];
				array9[0] = ((!flag3) ? num4 : num3);
				iOBMACBHJCC4.text = Localization.LocalizeFormat(")", array9);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag5 || flag6)
			{
				UILabel iOBMACBHJCC5 = IOBMACBHJCC;
				object[] array10 = new object[1];
				array10[1] = ((!flag5) ? num6 : num5);
				iOBMACBHJCC5.text = Localization.LocalizeFormat("ID_CONFIRM_AREYOUSURE", array10);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.AssaultRifle, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Singular);
			}
			else if (flag7 || flag8)
			{
				UILabel iOBMACBHJCC6 = IOBMACBHJCC;
				object[] array11 = new object[0];
				array11[0] = ((!flag7) ? num8 : num7);
				iOBMACBHJCC6.text = Localization.LocalizeFormat("SI", array11);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.JHHGEHCBEGK(WeaponCategory.SMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag9)
			{
				UILabel iOBMACBHJCC7 = IOBMACBHJCC;
				object[] array12 = new object[0];
				array12[0] = num9;
				iOBMACBHJCC7.text = Localization.LocalizeFormat(",", array12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.EIIPJBGJEMM(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag10 || flag11)
			{
				UILabel iOBMACBHJCC8 = IOBMACBHJCC;
				object[] array13 = new object[0];
				array13[0] = ((!flag10) ? num11 : num10);
				iOBMACBHJCC8.text = Localization.LocalizeFormat("Buy_Lootboxes", array13);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SMG | WeaponCategory.LMG, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag12 || flag13)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("{0} {1}", (!flag12) ? num13 : num12);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag14 || flag15)
			{
				IOBMACBHJCC.text = Localization.LocalizeFormat("============SHEETS RECIEVED===========\n", (!flag14) ? num15 : num14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade, JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			else if (flag16 || flag17)
			{
				UILabel iOBMACBHJCC9 = IOBMACBHJCC;
				object[] array14 = new object[0];
				array14[0] = ((!flag16) ? num17 : num16);
				iOBMACBHJCC9.text = Localization.LocalizeFormat("ID_WARNING_MAINTENANCE", array14);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade, JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Plural);
			}
			else if (flag18 || flag19)
			{
				UILabel iOBMACBHJCC10 = IOBMACBHJCC;
				object[] array15 = new object[1];
				array15[1] = ((!flag18) ? num19 : num18);
				iOBMACBHJCC10.text = Localization.LocalizeFormat("it", array15);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Pistol), JHNPNPKOJMO.UpperCase, FBBIHBFHNEG.Singular);
			}
			else
			{
				if (!flag20 && !flag21)
				{
					IOBMACBHJCC.text = string.Empty;
					FCAOHMAJIMD.KGNGFHMBHMJ.text = string.Empty;
					AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(230f);
					return;
				}
				UILabel iOBMACBHJCC11 = IOBMACBHJCC;
				object[] array16 = new object[0];
				array16[0] = ((!flag20) ? num21 : num20);
				iOBMACBHJCC11.text = Localization.LocalizeFormat("audio/menu", array16);
				FCAOHMAJIMD.KGNGFHMBHMJ.text = Singleton<GameVariables>.instance.GetWeaponCategory(~(WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Pistol), JHNPNPKOJMO.LowerCase, FBBIHBFHNEG.Plural);
			}
			float num28 = FCAOHMAJIMD.KGNGFHMBHMJ.relativeSize.x * FCAOHMAJIMD.KGNGFHMBHMJ.transform.localScale.x;
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(num28 + 572f);
		}
		else if (flag || flag2)
		{
			UILabel iOBMACBHJCC12 = IOBMACBHJCC;
			object[] array17 = new object[0];
			array17[1] = ((!flag) ? num2 : num);
			iOBMACBHJCC12.text = Localization.LocalizeFormat("OldSquadRank", array17);
			FCAOHMAJIMD.OANDDHKJDOB(Singleton<OfferManager>.instance.CCHLAIMMEPN());
			WinStreakCounter fCAOHMAJIMD4 = FCAOHMAJIMD;
			fCAOHMAJIMD4.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD4.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			WinStreakCounter fCAOHMAJIMD5 = FCAOHMAJIMD;
			fCAOHMAJIMD5.JEMKCLKCOMI = (Action)Delegate.Combine(fCAOHMAJIMD5.JEMKCLKCOMI, new Action(PNMGHAMMKLN));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1778f);
		}
		else
		{
			FCAOHMAJIMD.GGKCMHOGFPF();
			WinStreakCounter fCAOHMAJIMD6 = FCAOHMAJIMD;
			fCAOHMAJIMD6.JEMKCLKCOMI = (Action)Delegate.Remove(fCAOHMAJIMD6.JEMKCLKCOMI, new Action(BJKDLCCFMHK));
			AMAFGCHCGBC.transform.localScale = AMAFGCHCGBC.transform.localScale.ReplaceX(1190f);
		}
	}

	public void JGICEFCDNLI()
	{
		FNJEGABMIFN.SetActive(value: false);
		LPBCDBHKAFI.SetActive(value: true);
		OADICODBJLM(1);
	}

	private void EIGHAKHHGEI()
	{
		float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 1168f;
		DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
	}

	private void BOMCNCMJPJH()
	{
		BGMLFLBLMFD = true;
		KOGDHLDDDHF = true;
		PGFDMPGMJHM = true;
		BPHIFLAEPJB = false;
		BEEGGDEPGEB = true;
		LHIJMIMBPCF = false;
		JEPENIBNLCE = false;
		ODDMPOGOPDD = false;
		PMFDBOBCEGD = false;
		KIFLNFPKPAF = false;
		JEOAMGIOIPB = false;
		EKGIKOEAENC = true;
		CPNLFNPOPHC = false;
		PLELLGKANCL = false;
		EILLIBENOAL = true;
		KDJFEEHCLIM = true;
		CEPHGILHCLL = false;
		JOJICKFBOMC = true;
		IJHPKMJDANI = true;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.BHCEOOLEHHG)
			{
			case WeaponCategory.AssaultRifle:
				BGMLFLBLMFD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				KOGDHLDDDHF |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG:
				PGFDMPGMJHM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				BPHIFLAEPJB |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.LMG:
				BEEGGDEPGEB |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				LHIJMIMBPCF |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				JEPENIBNLCE |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle:
				ODDMPOGOPDD |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				PMFDBOBCEGD |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade):
				KIFLNFPKPAF |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				JEOAMGIOIPB |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade:
				EKGIKOEAENC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				CPNLFNPOPHC |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Shotgun:
				PLELLGKANCL |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				EILLIBENOAL |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade:
				KDJFEEHCLIM |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
				CEPHGILHCLL |= !weaponLevelsSetup.bought || weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Pistol:
				JOJICKFBOMC |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
				IJHPKMJDANI |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	private void BGGIOAEELFB()
	{
		if (LGOHNGIHNBP != null)
		{
			LGOHNGIHNBP.Cancel();
			LGOHNGIHNBP = null;
		}
	}

	public void HCMELDFOBCP()
	{
		KKFPLKDAAJE();
		OADICODBJLM(Singleton<NotificationManager>.instance.FLPIODKFKOL());
	}

	public void InitGUIValues()
	{
		EJEIFCCNNKI();
		OADICODBJLM(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
	}

	public void CAALKACDJEK()
	{
		GKKOGABLLMK();
		HPBAHDPDKJH(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
	}

	private void MMJJJBJKHFL(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(171f * Singleton<GuiTexureAssets>.instance.DLBBEAPEPHD());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void HPBAHDPDKJH(int IDLMJLCFMJG)
	{
		AELDNJLNPGO.SetActive(IDLMJLCFMJG > 0);
		MFIAHNMIJAH.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void NFGJFLCEANH()
	{
		FOLMFKACNFE();
		LGOHNGIHNBP = RadicalRoutine.Create(BMLHBFFPAJG());
		StartCoroutine(RadicalRoutine.Run(LGOHNGIHNBP.enumerator));
	}

	private IEnumerator HLAMDLNCDED()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}

	public void DKOBOPADMMI()
	{
		LAFOHANBCDN();
		HCKJLAHFMDH();
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float val = 0f - DPACCCMJPPJ.padding.x - (GCEEOLHGOKJ.transform.parent.localPosition.x - DPACCCMJPPJ.padding.x) / 2f;
		DPACCCMJPPJ.transform.localPosition = DPACCCMJPPJ.transform.localPosition.ReplaceX(val);
	}

	private IEnumerator OJDNHLNGKKG()
	{
		OMCPKICPEMF oMCPKICPEMF = new OMCPKICPEMF();
		oMCPKICPEMF.BJGCPDNMHDH = this;
		return oMCPKICPEMF;
	}
}
