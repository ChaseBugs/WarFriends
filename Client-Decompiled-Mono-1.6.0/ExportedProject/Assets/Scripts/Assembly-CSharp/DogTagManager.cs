using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using UnityEngine;

public class DogTagManager : Singleton<DogTagManager>
{
	private enum BIJGKONDLCD
	{
		regular = 0,
		offer = 1,
		subscription = 2
	}

	private sealed class FLIEKCCENMC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int MCHBOIBOIMM;

		internal float HKFOADPAEGI;

		internal DogTagManager BJGCPDNMHDH;

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

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 0;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 4)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 4;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 7)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.EKPLOIPOHCF() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.CLAOLIOKIPP();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.WaitingForResponse || GameLoginManager.instance.acountDataDownloadingInProgress || Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA() || Singleton<SessionManager>.instance.LAOFFHCIPFL()))
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)103, 128f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 0;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 8)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 8)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.HOMLGFFAIFJ() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.MJDKPGKHNKH();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA() && !Singleton<SessionManager>.instance.LAOFFHCIPFL())
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)121, 1961f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			default:
				return false;
			}
			return false;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 1;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 0)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 7;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 0)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.HOMLGFFAIFJ() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.MJDKPGKHNKH();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.currentDogtags;
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.WaitingForResponse || GameLoginManager.instance.acountDataDownloadingInProgress || Singleton<BeanstalkServerManager>.instance.loadingPlayerData || !Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate))
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)113, 322f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 1 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.currentTimestamp && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 1;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 0)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 1)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.EKPLOIPOHCF() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.CLAOLIOKIPP();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.currentDogtags;
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.WaitingForResponse || GameLoginManager.instance.acountDataDownloadingInProgress || Singleton<BeanstalkServerManager>.instance.loadingPlayerData || Singleton<SessionManager>.instance.LAOFFHCIPFL()))
					{
						SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssignmentDayCompleted, 690f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 1 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 1;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 7)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 4;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 0)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.EKPLOIPOHCF() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.MJDKPGKHNKH();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.WaitingForResponse && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && !Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate)
					{
						SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampDialogDissapear, 676f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
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
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.currentTimestamp && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 0;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 8)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 5;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 0)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.constDogtagSubscriptionSeconds + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.GOIOELEKACC();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.WaitingForResponse || GameLoginManager.instance.acountDataDownloadingInProgress || Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA() || Singleton<SessionManager>.instance.LAOFFHCIPFL()))
					{
						SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootbox, 1402f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return false;
			}
			return true;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 1 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.currentTimestamp && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 1;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 7)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 7;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 7)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.HOMLGFFAIFJ() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.CDPEBDEJNFK();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.WaitingForResponse && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && Singleton<SessionManager>.instance.CBHFNHFKHNO())
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)73, 1709f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			default:
				return false;
			}
			return true;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 1 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 1;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 4)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 2;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 3)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.constDogtagSubscriptionSeconds + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.CLAOLIOKIPP();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || GameLoginManager.instance.acountDataDownloadingInProgress || Singleton<BeanstalkServerManager>.instance.loadingPlayerData || !Singleton<SessionManager>.instance.CBHFNHFKHNO()))
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-66), 1026f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		[DebuggerHidden]
		public FLIEKCCENMC()
		{
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
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
				if (GuiElementSingle<LoadingDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.currentTimestamp && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 0;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 2)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 2;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 2)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.constDogtagSubscriptionSeconds + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.CLAOLIOKIPP();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.currentDogtags;
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && !Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate)
					{
						SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DogTagGain);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			default:
				return false;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 0;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 4)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 2)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.constDogtagSubscriptionSeconds + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.MJDKPGKHNKH();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.currentDogtags;
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate)
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-79), 1633f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 1;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 7)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 3;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 5)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 1;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.EKPLOIPOHCF() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.GOIOELEKACC();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.PHMPHFFNMPD();
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.WaitingForResponse && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.loadingPlayerData && Singleton<SessionManager>.instance.schedulingOrInProgressAnyUpdate)
					{
						SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CraftingStart, 678f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (GuiElementSingle<LoadingDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.NGMHHBABJFI > 0 && BJGCPDNMHDH.NGMHHBABJFI < Singleton<BeanstalkServerManager>.instance.currentTimestamp && BJGCPDNMHDH.ADEOGAMOGDA < BJGCPDNMHDH.NGMHHBABJFI)
				{
					int num = BJGCPDNMHDH.HNDGIJBHMOD + (BJGCPDNMHDH.NGMHHBABJFI - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD = num * BJGCPDNMHDH.FKCMOKNOFII / BJGCPDNMHDH.MNCNAELOJGA;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD;
					BJGCPDNMHDH.ADEOGAMOGDA = BJGCPDNMHDH.NGMHHBABJFI;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					BJGCPDNMHDH.NGMHHBABJFI = 0;
				}
				if (SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM != 4)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 7;
				}
				else if (!SubscriptionManager.instance.isSubscribed && BJGCPDNMHDH.EOAJOKGNEIM == 3)
				{
					BJGCPDNMHDH.EOAJOKGNEIM = 0;
					int num2 = BJGCPDNMHDH.HNDGIJBHMOD + BJGCPDNMHDH.HOMLGFFAIFJ() + (SubscriptionManager.instance.expireTime - BJGCPDNMHDH.ADEOGAMOGDA);
					if (num2 > BJGCPDNMHDH.DMEHGIDJEBD)
					{
						num2 = BJGCPDNMHDH.DMEHGIDJEBD;
					}
					int hNDGIJBHMOD2 = num2;
					BJGCPDNMHDH.HNDGIJBHMOD = hNDGIJBHMOD2;
					BJGCPDNMHDH.ADEOGAMOGDA = SubscriptionManager.instance.expireTime;
					BJGCPDNMHDH.DMEHGIDJEBD = BJGCPDNMHDH.FKCMOKNOFII * BJGCPDNMHDH.constDogtagCount;
					Singleton<BeanstalkServerManager>.instance.MJDKPGKHNKH();
				}
				MCHBOIBOIMM = BJGCPDNMHDH.currentDogtags;
				if (BJGCPDNMHDH.LELOCGKKJII != null)
				{
					BJGCPDNMHDH.LELOCGKKJII(MCHBOIBOIMM);
				}
				if (BJGCPDNMHDH.GHBKNGONMFH != -1 && BJGCPDNMHDH.GHBKNGONMFH != MCHBOIBOIMM)
				{
					if (MCHBOIBOIMM > BJGCPDNMHDH.GHBKNGONMFH && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && !GameLoginManager.instance.acountDataDownloadingInProgress && !Singleton<BeanstalkServerManager>.instance.GFFNKLKCHBA() && Singleton<SessionManager>.instance.LAOFFHCIPFL())
					{
						SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-113), 705f);
					}
					BJGCPDNMHDH.GHBKNGONMFH = MCHBOIBOIMM;
				}
				PHDOCKCBJOF = new WaitForSeconds(HKFOADPAEGI);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}
	}

	public Action KNCCBMHGCNI;

	[Header("Server setted values")]
	public int ADEOGAMOGDA;

	public int HNDGIJBHMOD;

	public int DMEHGIDJEBD;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<int> LELOCGKKJII;

	private int FKCMOKNOFII = 720;

	private const int FJCFNJADODJ = 35;

	private int GHBKNGONMFH = -1;

	private int HBGABOKGAAM;

	private int NOJCDAOEKGG;

	private int NGMHHBABJFI;

	private int MNCNAELOJGA;

	private int EOAJOKGNEIM;

	public int ELLJNHLPDNF;

	public int dogtagRefillPrice
	{
		get
		{
			return 35 - 2 * currentDogtags;
		}
	}

	public int timeToGetDogtag
	{
		get
		{
			return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? constDogtagSeconds : constDogtagSubscriptionSeconds;
		}
	}

	public int constDogtagSubscriptionSeconds
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagSubscriptionRefillTime).FLOATVALUE;
		}
	}

	public int constDogtagSeconds
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE;
		}
	}

	public int constDogtagCount
	{
		get
		{
			return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogTagCap).FLOATVALUE;
		}
	}

	private int LNLAOANGHPN
	{
		get
		{
			return HNDGIJBHMOD + (Singleton<BeanstalkServerManager>.instance.currentTimestamp - ADEOGAMOGDA);
		}
	}

	private int GOFEHOCFIMM
	{
		get
		{
			return Singleton<VipManager>.instance.numberOfVIPDogtags * (timeToGetDogtag * KDJCCDGMEJL);
		}
	}

	private int GHFBGCNLEIO
	{
		get
		{
			return (!Singleton<VipManager>.instance.NOGEIPHFNPK()) ? DMEHGIDJEBD : (DMEHGIDJEBD + GOFEHOCFIMM);
		}
	}

	private int INIHJJPBLNG
	{
		get
		{
			return (!Singleton<VipManager>.instance.NOGEIPHFNPK()) ? LNLAOANGHPN : (LNLAOANGHPN + GOFEHOCFIMM);
		}
	}

	private int GEDPOCLNMNE
	{
		get
		{
			return Mathf.Clamp(INIHJJPBLNG, 0, GHFBGCNLEIO);
		}
	}

	private int CHIPMPDAEJF
	{
		get
		{
			return GEDPOCLNMNE - HBGABOKGAAM * timeToGetDogtag;
		}
	}

	private int HLLMEABKOIJ
	{
		get
		{
			return Singleton<BeanstalkServerManager>.instance.currentTimestamp - NOJCDAOEKGG;
		}
	}

	private int KDJCCDGMEJL
	{
		get
		{
			return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? 1 : (constDogtagSeconds / constDogtagSubscriptionSeconds);
		}
	}

	public int currentDogtags
	{
		get
		{
			return CHIPMPDAEJF / (timeToGetDogtag * KDJCCDGMEJL);
		}
	}

	public int maximumDogtags
	{
		get
		{
			return GHFBGCNLEIO / (timeToGetDogtag * KDJCCDGMEJL);
		}
	}

	public bool isEmpty
	{
		get
		{
			return INIHJJPBLNG < timeToGetDogtag;
		}
	}

	public bool isFull
	{
		get
		{
			return currentDogtags >= maximumDogtags;
		}
	}

	public int remainingTimeForNextDogtag
	{
		get
		{
			if (HBGABOKGAAM > 0)
			{
				logInfo("mUsedDogtagsLocaly");
				return timeToGetDogtag - (CHIPMPDAEJF + HLLMEABKOIJ) % timeToGetDogtag;
			}
			logInfo("remainingTimeForNextDogtag");
			return (!isFull) ? (timeToGetDogtag - CHIPMPDAEJF % timeToGetDogtag) : 0;
		}
	}

	public float progressToNextDogtag
	{
		get
		{
			if (HBGABOKGAAM > 0)
			{
				return (float)((CHIPMPDAEJF + HLLMEABKOIJ) % timeToGetDogtag) / (float)timeToGetDogtag;
			}
			return (float)(CHIPMPDAEJF % timeToGetDogtag) / (float)timeToGetDogtag;
		}
	}

	public event Action<int> DogtagsChanged
	{
		add
		{
			Action<int> action = LELOCGKKJII;
			Action<int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<int> action = LELOCGKKJII;
			Action<int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void MMEKFOHGAKK()
	{
		FKCMOKNOFII = constDogtagSeconds;
		if (NGMHHBABJFI > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			DMEHGIDJEBD = constDogtagCount * MNCNAELOJGA;
			EOAJOKGNEIM = 1;
		}
		else
		{
			DMEHGIDJEBD = constDogtagCount * constDogtagSeconds;
			EOAJOKGNEIM = 0;
		}
		GDCKMCKDOAF();
		if (SubscriptionManager.instance.isSubscribed)
		{
			EOAJOKGNEIM = 2;
		}
	}

	[SpecialName]
	private int DMGGLKBAMOG()
	{
		return Singleton<VipManager>.instance.AAABGLLAANF() * (EAKLHLIMCDN() * KDJCCDGMEJL);
	}

	private IEnumerator KILPOMNEDPH(float HKFOADPAEGI)
	{
		FLIEKCCENMC fLIEKCCENMC = new FLIEKCCENMC();
		fLIEKCCENMC.HKFOADPAEGI = HKFOADPAEGI;
		fLIEKCCENMC.BJGCPDNMHDH = this;
		return fLIEKCCENMC;
	}

	private IEnumerator NGBCBBBOGEK(float HKFOADPAEGI)
	{
		FLIEKCCENMC fLIEKCCENMC = new FLIEKCCENMC();
		fLIEKCCENMC.HKFOADPAEGI = HKFOADPAEGI;
		fLIEKCCENMC.BJGCPDNMHDH = this;
		return fLIEKCCENMC;
	}

	private void OnApplicationResumed()
	{
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	public void AKAPBGEPFAF()
	{
		PushNotificationManager.instance.CancelLocalNotification("menu-twitter");
		HNDGIJBHMOD = DMEHGIDJEBD;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
		if (SubscriptionManager.instance.isSubscribed)
		{
			ELLJNHLPDNF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		}
	}

	[SpecialName]
	private int HDKOLPOGHDC()
	{
		return Mathf.Clamp(ENNCCNPBKBE(), 0, GHFBGCNLEIO);
	}

	public void NKILOPJKALI()
	{
		GuiElementSingle<HeaderDogtagButton>.instance.CPMFCJLOJPF();
		HBGABOKGAAM++;
		NOJCDAOEKGG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(PHMPHFFNMPD());
		}
	}

	[SpecialName]
	public int EAKLHLIMCDN()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? constDogtagSeconds : constDogtagSubscriptionSeconds;
	}

	[SpecialName]
	private int DFLPCNBLFFF()
	{
		return HNDGIJBHMOD + (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - ADEOGAMOGDA);
	}

	public void LMAMAMAHGOI()
	{
		HBGABOKGAAM = 1;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	[SpecialName]
	public bool HPKBIIIEGIB()
	{
		return PHMPHFFNMPD() >= NBHOLJCGOJC();
	}

	[SpecialName]
	public int IICKLIAPFNA()
	{
		if (HBGABOKGAAM > 0)
		{
			HFAGIMJJEJD("ok");
			return FMHEFMJEGGB() - (CHIPMPDAEJF + IHFFGEDKILF()) % EKIFPKJIJBA();
		}
		logInfo("ID_POSITIONXY");
		return KDKHHPFBBBB() ? 1 : (ECPDJDOLBCN() - CHIPMPDAEJF % ECPDJDOLBCN());
	}

	protected virtual void ENNKKDGFOAL()
	{
		base.Start();
		StartCoroutine(KILPOMNEDPH(869f));
	}

	public void RefillAllDogtags()
	{
		PushNotificationManager.instance.CancelLocalNotification("dogtag");
		HNDGIJBHMOD = DMEHGIDJEBD;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
		if (SubscriptionManager.instance.isSubscribed)
		{
			ELLJNHLPDNF = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	private IEnumerator BGELNNNAFBN(float HKFOADPAEGI)
	{
		FLIEKCCENMC fLIEKCCENMC = new FLIEKCCENMC();
		fLIEKCCENMC.HKFOADPAEGI = HKFOADPAEGI;
		fLIEKCCENMC.BJGCPDNMHDH = this;
		return fLIEKCCENMC;
	}

	[SpecialName]
	public void IFEOAONAHEJ(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool AKAALNKEBAF()
	{
		return PHMPHFFNMPD() >= NBHOLJCGOJC();
	}

	internal void KKLOBNHDIPG(int JJBHBKCGLGK, int BBPAMDDFNDM, int OHOCBKNLCLD, int MAPMIGLIPBA)
	{
		ADEOGAMOGDA = BBPAMDDFNDM;
		HNDGIJBHMOD = JJBHBKCGLGK;
		DMEHGIDJEBD = DMEHGIDJEBD / FKCMOKNOFII * OHOCBKNLCLD;
		NGMHHBABJFI = MAPMIGLIPBA;
		MNCNAELOJGA = OHOCBKNLCLD;
		if (KNCCBMHGCNI != null)
		{
			KNCCBMHGCNI();
		}
		PushNotificationManager.instance.ScheduleLocalDogtagNotification(DMEHGIDJEBD - HNDGIJBHMOD);
	}

	[SpecialName]
	public float DIHEMPNCPBP()
	{
		if (HBGABOKGAAM > 1)
		{
			return (float)((KOAJBAGCGCG() + EBGMMMBHFNP()) % ELPCLEGDCAL()) / (float)EKIFPKJIJBA();
		}
		return (float)(CHIPMPDAEJF % FMHEFMJEGGB()) / (float)EAKLHLIMCDN();
	}

	[SpecialName]
	public float NKJKAFCELIP()
	{
		if (HBGABOKGAAM > 1)
		{
			return (float)((KOAJBAGCGCG() + IHFFGEDKILF()) % ELPCLEGDCAL()) / (float)FMHEFMJEGGB();
		}
		return (float)(KOAJBAGCGCG() % timeToGetDogtag) / (float)MJIPCNEKIIN();
	}

	[SpecialName]
	public bool ADCGCFFDCOP()
	{
		return GHCMOLMBBDB() < OEIENPPKJAG();
	}

	[SpecialName]
	private int EBGMMMBHFNP()
	{
		return Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - NOJCDAOEKGG;
	}

	[SpecialName]
	public int EKPLOIPOHCF()
	{
		return (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-196)).FLOATVALUE;
	}

	[SpecialName]
	public int OEIENPPKJAG()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? constDogtagSeconds : HOMLGFFAIFJ();
	}

	[SpecialName]
	private int HOMHDHHAMMM()
	{
		return HNDGIJBHMOD + (Singleton<BeanstalkServerManager>.instance.currentTimestamp - ADEOGAMOGDA);
	}

	[SpecialName]
	public int ACHMONENAIH()
	{
		if (HBGABOKGAAM > 0)
		{
			MGNJNEACCML("BANDS_EMPTY");
			return EKIFPKJIJBA() - (CHIPMPDAEJF + IHFFGEDKILF()) % MJIPCNEKIIN();
		}
		MGNJNEACCML("ShotFrequencyMinCannon");
		return JFFKJKMOACB() ? 1 : (PBEKNDPFIHG() - KOAJBAGCGCG() % ELPCLEGDCAL());
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(BBIGPGIDKHB);
	}

	[SpecialName]
	private int KOAJBAGCGCG()
	{
		return GEDPOCLNMNE - HBGABOKGAAM * ECPDJDOLBCN();
	}

	[SpecialName]
	public float FFNPJNJCBGO()
	{
		if (HBGABOKGAAM > 0)
		{
			return (float)((CHIPMPDAEJF + IHFFGEDKILF()) % OEIENPPKJAG()) / (float)OEIENPPKJAG();
		}
		return (float)(KOAJBAGCGCG() % FMHEFMJEGGB()) / (float)FMHEFMJEGGB();
	}

	private void BBIGPGIDKHB()
	{
		FKCMOKNOFII = constDogtagSeconds;
		if (NGMHHBABJFI > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			DMEHGIDJEBD = constDogtagCount * MNCNAELOJGA;
			EOAJOKGNEIM = 1;
		}
		else
		{
			DMEHGIDJEBD = constDogtagCount * NDBIDBECHHF();
			EOAJOKGNEIM = 0;
		}
		GDCKMCKDOAF();
		if (SubscriptionManager.instance.isSubscribed)
		{
			EOAJOKGNEIM = 6;
		}
	}

	[SpecialName]
	public int NBHOLJCGOJC()
	{
		return GHFBGCNLEIO / (MJIPCNEKIIN() * KDJCCDGMEJL);
	}

	internal void CAHCIHHBALK(int JJBHBKCGLGK, int BBPAMDDFNDM, int OONMBBJECGA = 0)
	{
		HBGABOKGAAM = 0;
		ADEOGAMOGDA = BBPAMDDFNDM;
		HNDGIJBHMOD = JJBHBKCGLGK;
		if (OONMBBJECGA != 0)
		{
			DMEHGIDJEBD = OONMBBJECGA;
		}
		else if (BBPAMDDFNDM > NGMHHBABJFI && NGMHHBABJFI > 0)
		{
			DMEHGIDJEBD = FKCMOKNOFII * constDogtagCount;
			NGMHHBABJFI = 0;
		}
		if (KNCCBMHGCNI != null)
		{
			KNCCBMHGCNI();
		}
		PushNotificationManager.instance.ScheduleLocalDogtagNotification(DMEHGIDJEBD - HNDGIJBHMOD);
	}

	[SpecialName]
	private int KKMAOPPKKPN()
	{
		return HNDGIJBHMOD + (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - ADEOGAMOGDA);
	}

	private IEnumerator GMDPIANHKMB(float HKFOADPAEGI)
	{
		FLIEKCCENMC fLIEKCCENMC = new FLIEKCCENMC();
		fLIEKCCENMC.HKFOADPAEGI = HKFOADPAEGI;
		fLIEKCCENMC.BJGCPDNMHDH = this;
		return fLIEKCCENMC;
	}

	[SpecialName]
	public int ECPDJDOLBCN()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF()) ? constDogtagSeconds : constDogtagSubscriptionSeconds;
	}

	[SpecialName]
	public void HKNDLICMFMO(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int PHMPHFFNMPD()
	{
		return CHIPMPDAEJF / (MJIPCNEKIIN() * BBPMJIADOKL());
	}

	[SpecialName]
	private int GKEIGJKABBP()
	{
		return HNDGIJBHMOD + (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - ADEOGAMOGDA);
	}

	protected virtual void FJIDLPDMAFM()
	{
		base.Start();
		StartCoroutine(KILPOMNEDPH(823f));
	}

	[SpecialName]
	public bool JFFKJKMOACB()
	{
		return PHMPHFFNMPD() >= BEFFNGGEPBO();
	}

	public void KLDJHENMHHE()
	{
		GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		HBGABOKGAAM++;
		NOJCDAOEKGG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(PHMPHFFNMPD());
		}
	}

	[SpecialName]
	public void JIMKJGLPJGA(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int FDMCHFNPALJ()
	{
		return (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE;
	}

	private void BOFOJCLMNPN()
	{
		FKCMOKNOFII = constDogtagSeconds;
		if (NGMHHBABJFI > Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN())
		{
			DMEHGIDJEBD = constDogtagCount * MNCNAELOJGA;
			EOAJOKGNEIM = 1;
		}
		else
		{
			DMEHGIDJEBD = constDogtagCount * NDBIDBECHHF();
			EOAJOKGNEIM = 1;
		}
		DACLMKIDKGO();
		if (SubscriptionManager.instance.isSubscribed)
		{
			EOAJOKGNEIM = 8;
		}
	}

	protected virtual void CCMDIJAIPEM()
	{
		base.Start();
		StartCoroutine(KILPOMNEDPH(1977f));
	}

	[SpecialName]
	public bool LFBIKFMJEJN()
	{
		return GHCMOLMBBDB() < EAKLHLIMCDN();
	}

	public void HKIFMAKKLAN()
	{
		Singleton<BeanstalkServerManager>.instance.PayOneDogtag();
		if (HBGABOKGAAM == 0)
		{
			GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		}
		int num = GKEIGJKABBP();
		int num2 = OEIENPPKJAG();
		if (num > DMEHGIDJEBD)
		{
			num2 += num - DMEHGIDJEBD;
		}
		HNDGIJBHMOD -= num2;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	[SpecialName]
	public int MJIPCNEKIIN()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? NDBIDBECHHF() : constDogtagSubscriptionSeconds;
	}

	[SpecialName]
	public int BEFFNGGEPBO()
	{
		return GHFBGCNLEIO / (PBEKNDPFIHG() * BBPMJIADOKL());
	}

	[SpecialName]
	public int HOMLGFFAIFJ()
	{
		return (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GooglePlayLoginReward).FLOATVALUE;
	}

	[SpecialName]
	private int APEDJDNJBFB()
	{
		return Mathf.Clamp(INIHJJPBLNG, 0, GHFBGCNLEIO);
	}

	public void PayOneDogTag()
	{
		Singleton<BeanstalkServerManager>.instance.PayOneDogtag();
		if (HBGABOKGAAM == 0)
		{
			GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		}
		int num = LNLAOANGHPN;
		int num2 = timeToGetDogtag;
		if (num > DMEHGIDJEBD)
		{
			num2 += num - DMEHGIDJEBD;
		}
		HNDGIJBHMOD -= num2;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	protected virtual void JOFFHFDJMAB()
	{
		base.Start();
		StartCoroutine(DLDLDNGEJKI(1693f));
	}

	[SpecialName]
	private int JAOGHBNHLCA()
	{
		return Mathf.Clamp(INIHJJPBLNG, 1, GHFBGCNLEIO);
	}

	[SpecialName]
	private int LLDCPIBNDLG()
	{
		return Singleton<VipManager>.instance.JIDPLCILLMH() * (EAKLHLIMCDN() * BBPMJIADOKL());
	}

	public void ResetLocalDogtags()
	{
		HBGABOKGAAM = 0;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	public void OGBBHOGJJMC()
	{
		HBGABOKGAAM = 1;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	[SpecialName]
	private int EHHJLJCPGFA()
	{
		return HNDGIJBHMOD + (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - ADEOGAMOGDA);
	}

	[SpecialName]
	private int ADIDOLDNAOF()
	{
		return Mathf.Clamp(GHCMOLMBBDB(), 1, GHFBGCNLEIO);
	}

	internal void GDCKMCKDOAF()
	{
		GHBKNGONMFH = currentDogtags;
	}

	[SpecialName]
	public int DLBKEJKCIFP()
	{
		return 79 - 4 * PHMPHFFNMPD();
	}

	public void HCDLFCBGLGA()
	{
		HBGABOKGAAM = 0;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	[SpecialName]
	public void CGOCCBPJOIE(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool MHIHFAOMHKK()
	{
		return PHMPHFFNMPD() < maximumDogtags;
	}

	public void UseDogTagLocaly()
	{
		GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		HBGABOKGAAM++;
		NOJCDAOEKGG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	[SpecialName]
	public int ELPCLEGDCAL()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN()) ? FDMCHFNPALJ() : EKPLOIPOHCF();
	}

	[SpecialName]
	private int GHCMOLMBBDB()
	{
		return (!Singleton<VipManager>.instance.NOGEIPHFNPK()) ? EHHJLJCPGFA() : (GKEIGJKABBP() + LLDCPIBNDLG());
	}

	[SpecialName]
	public int FMHEFMJEGGB()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN()) ? NDBIDBECHHF() : EKPLOIPOHCF();
	}

	[SpecialName]
	private int BBPMJIADOKL()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? 1 : (FDMCHFNPALJ() / constDogtagSubscriptionSeconds);
	}

	public void AGHKAMPPOHK()
	{
		PushNotificationManager.instance.CancelLocalNotification("warbucks", false);
		HNDGIJBHMOD = DMEHGIDJEBD;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(PHMPHFFNMPD());
		}
		if (SubscriptionManager.instance.isSubscribed)
		{
			ELLJNHLPDNF = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		}
	}

	internal void KCLNCPAGAKG(int JJBHBKCGLGK, int BBPAMDDFNDM, int OHOCBKNLCLD, int MAPMIGLIPBA)
	{
		ADEOGAMOGDA = BBPAMDDFNDM;
		HNDGIJBHMOD = JJBHBKCGLGK;
		DMEHGIDJEBD = DMEHGIDJEBD / FKCMOKNOFII * OHOCBKNLCLD;
		NGMHHBABJFI = MAPMIGLIPBA;
		MNCNAELOJGA = OHOCBKNLCLD;
		if (KNCCBMHGCNI != null)
		{
			KNCCBMHGCNI();
		}
		PushNotificationManager.instance.ScheduleLocalDogtagNotification(DMEHGIDJEBD - HNDGIJBHMOD);
	}

	protected virtual void BFLIPLAIDMO()
	{
		base.Start();
		StartCoroutine(KILPOMNEDPH(1129f));
	}

	[DebuggerHidden]
	private IEnumerator PNDOEMDMBMG(float HKFOADPAEGI)
	{
		FLIEKCCENMC fLIEKCCENMC = new FLIEKCCENMC();
		fLIEKCCENMC.HKFOADPAEGI = HKFOADPAEGI;
		fLIEKCCENMC.BJGCPDNMHDH = this;
		return fLIEKCCENMC;
	}

	[SpecialName]
	private int LDOOINILKMP()
	{
		return Mathf.Clamp(INIHJJPBLNG, 0, GHFBGCNLEIO);
	}

	[SpecialName]
	public void CMNFJJGPNNC(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool CanUseDogtags(int IEALLELGOBM)
	{
		return currentDogtags >= IEALLELGOBM;
	}

	[SpecialName]
	public int EKIFPKJIJBA()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.currentTimestamp) ? NDBIDBECHHF() : EKPLOIPOHCF();
	}

	public bool OAGOEBANLHN(int IEALLELGOBM)
	{
		return PHMPHFFNMPD() >= IEALLELGOBM;
	}

	public void ABDOBCOHHBC()
	{
		GuiElementSingle<HeaderDogtagButton>.instance.CKIHHOBJIJL();
		HBGABOKGAAM += 0;
		NOJCDAOEKGG = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	protected override void Start()
	{
		base.Start();
		StartCoroutine(PNDOEMDMBMG(0.5f));
	}

	[SpecialName]
	public int PBEKNDPFIHG()
	{
		return (!SubscriptionManager.instance.isSubscribed || ELLJNHLPDNF >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN()) ? constDogtagSeconds : HOMLGFFAIFJ();
	}

	[SpecialName]
	private int ENNCCNPBKBE()
	{
		return (!Singleton<VipManager>.instance.FAKAOBDANNA()) ? LNLAOANGHPN : (HOMHDHHAMMM() + GOFEHOCFIMM);
	}

	[SpecialName]
	public bool KDKHHPFBBBB()
	{
		return currentDogtags < BEFFNGGEPBO();
	}

	internal void DACLMKIDKGO()
	{
		GHBKNGONMFH = PHMPHFFNMPD();
	}

	internal void NCDALCOIMME()
	{
		GHBKNGONMFH = PHMPHFFNMPD();
	}

	public void PILBFGCKGFB()
	{
		GuiElementSingle<HeaderDogtagButton>.instance.CKIHHOBJIJL();
		HBGABOKGAAM++;
		NOJCDAOEKGG = Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(PHMPHFFNMPD());
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MMEKFOHGAKK;
	}

	public bool HKLLODKPINP(int IEALLELGOBM)
	{
		return PHMPHFFNMPD() >= IEALLELGOBM;
	}

	public void HFAGIMJJEJD(string HOLNKOFHDNK = "")
	{
		UnityEngine.Debug.Log(HOLNKOFHDNK);
		UnityEngine.Debug.Log("ServerErrorHandler: squadCreationsCount = " + PHMPHFFNMPD());
		UnityEngine.Debug.Log("RewardMessage" + KOAJBAGCGCG());
		UnityEngine.Debug.Log("Action" + KDJCCDGMEJL);
		UnityEngine.Debug.Log("MaintenanceMessage" + EAKLHLIMCDN());
		UnityEngine.Debug.Log("Please add object to pool, before instanciing it ::: prefab name = " + EOAJOKGNEIM);
		UnityEngine.Debug.Log("DpsCoef" + ELLJNHLPDNF);
	}

	public void MGNJNEACCML(string HOLNKOFHDNK = "")
	{
		UnityEngine.Debug.Log(HOLNKOFHDNK);
		UnityEngine.Debug.Log("OK" + PHMPHFFNMPD());
		UnityEngine.Debug.Log("Started delivering army upgrade for {0} {1}. It will be ready in {2} seconds." + KOAJBAGCGCG());
		UnityEngine.Debug.Log("RoundId" + BBPMJIADOKL());
		UnityEngine.Debug.Log("Wrong_Category" + EAKLHLIMCDN());
		UnityEngine.Debug.Log("master2" + EOAJOKGNEIM);
		UnityEngine.Debug.Log("ID_SECONDWEAPONDAMAGE" + ELLJNHLPDNF);
	}

	public void logInfo(string HOLNKOFHDNK = "")
	{
		UnityEngine.Debug.Log(HOLNKOFHDNK);
		UnityEngine.Debug.Log("currentDogtags: " + currentDogtags);
		UnityEngine.Debug.Log("mCurrentLocalSeconds: " + CHIPMPDAEJF);
		UnityEngine.Debug.Log("factor: " + KDJCCDGMEJL);
		UnityEngine.Debug.Log("timeToGetDogtag: " + timeToGetDogtag);
		UnityEngine.Debug.Log("currentMode: " + EOAJOKGNEIM);
		UnityEngine.Debug.Log("dogtagTimerLockTime: " + ELLJNHLPDNF);
	}

	[SpecialName]
	public void KNIJEKDJCIF(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void FMPOMPNPLAA()
	{
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(PHMPHFFNMPD());
		}
	}

	public void KMICFDFEFEB()
	{
		Singleton<BeanstalkServerManager>.instance.PayOneDogtag();
		if (HBGABOKGAAM == 0)
		{
			GuiElementSingle<HeaderDogtagButton>.instance.CPMFCJLOJPF();
		}
		int num = LNLAOANGHPN;
		int num2 = OEIENPPKJAG();
		if (num > DMEHGIDJEBD)
		{
			num2 += num - DMEHGIDJEBD;
		}
		HNDGIJBHMOD -= num2;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(PHMPHFFNMPD());
		}
	}

	[SpecialName]
	public int NDBIDBECHHF()
	{
		return (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-79)).FLOATVALUE;
	}

	[SpecialName]
	private int IHFFGEDKILF()
	{
		return Singleton<BeanstalkServerManager>.instance.currentTimestamp - NOJCDAOEKGG;
	}

	public void KAEHGLMJAKE()
	{
		HBGABOKGAAM = 1;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	protected virtual void ECOOGJPADHI()
	{
		base.Start();
		StartCoroutine(NGBCBBBOGEK(631f));
	}

	public void MIBOJDDFMBN()
	{
		Singleton<BeanstalkServerManager>.instance.PayOneDogtag();
		if (HBGABOKGAAM == 0)
		{
			GuiElementSingle<HeaderDogtagButton>.instance.AnimateDogtagUse();
		}
		int num = KKMAOPPKKPN();
		int num2 = EAKLHLIMCDN();
		if (num > DMEHGIDJEBD)
		{
			num2 += num - DMEHGIDJEBD;
		}
		HNDGIJBHMOD -= num2;
		if (LELOCGKKJII != null)
		{
			LELOCGKKJII(currentDogtags);
		}
	}

	[SpecialName]
	public void IHPOHKAMCLF(Action<int> IDEBKDPMPGM)
	{
		Action<int> action = LELOCGKKJII;
		Action<int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LELOCGKKJII, (Action<int>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator DLDLDNGEJKI(float HKFOADPAEGI)
	{
		FLIEKCCENMC fLIEKCCENMC = new FLIEKCCENMC();
		fLIEKCCENMC.HKFOADPAEGI = HKFOADPAEGI;
		fLIEKCCENMC.BJGCPDNMHDH = this;
		return fLIEKCCENMC;
	}

	internal void MOGKLGDDEJL(int JJBHBKCGLGK, int BBPAMDDFNDM, int OHOCBKNLCLD, int MAPMIGLIPBA)
	{
		ADEOGAMOGDA = BBPAMDDFNDM;
		HNDGIJBHMOD = JJBHBKCGLGK;
		DMEHGIDJEBD = DMEHGIDJEBD / FKCMOKNOFII * OHOCBKNLCLD;
		NGMHHBABJFI = MAPMIGLIPBA;
		MNCNAELOJGA = OHOCBKNLCLD;
		if (KNCCBMHGCNI != null)
		{
			KNCCBMHGCNI();
		}
		PushNotificationManager.instance.ScheduleLocalDogtagNotification(DMEHGIDJEBD - HNDGIJBHMOD);
	}

	[SpecialName]
	private int MEMCBJFHDLH()
	{
		return Mathf.Clamp(ENNCCNPBKBE(), 0, GHFBGCNLEIO);
	}

	private void CBDFIFPNHMK()
	{
		FKCMOKNOFII = constDogtagSeconds;
		if (NGMHHBABJFI > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF())
		{
			DMEHGIDJEBD = constDogtagCount * MNCNAELOJGA;
			EOAJOKGNEIM = 0;
		}
		else
		{
			DMEHGIDJEBD = constDogtagCount * FDMCHFNPALJ();
			EOAJOKGNEIM = 1;
		}
		NCDALCOIMME();
		if (SubscriptionManager.instance.isSubscribed)
		{
			EOAJOKGNEIM = 5;
		}
	}
}
