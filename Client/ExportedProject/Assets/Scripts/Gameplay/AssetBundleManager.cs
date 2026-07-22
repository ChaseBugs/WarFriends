using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

[ExecuteInEditMode]
public class AssetBundleManager : Singleton<AssetBundleManager>
{
	private sealed class DFJBCNOHECK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string ILKMPLEFGCH;

		internal string ELFDIOGKADL;

		internal string JBKGALDDPCH;

		internal MNEHKEKBLMF EGGPABBJKBJ;

		internal AssetBundleManager BJGCPDNMHDH;

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

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.DCBFHDPONAO();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.LDLDMKBAFLJ().Replace('\b', 't');
				JBKGALDDPCH = BJGCPDNMHDH.HMKHECIIBKO();
				BJGCPDNMHDH.PCOBKNBFJNI(JBKGALDDPCH + "Days_Since_Install" + ILKMPLEFGCH + "EnableData()");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[7];
				array[1] = "ID_ASSIGNMENTHINTCRATES";
				array[0] = ELFDIOGKADL;
				array[4] = "GoldExpCoefficient";
				array[8] = ILKMPLEFGCH;
				array[5] = "TicketsGained";
				bJGCPDNMHDH.CDHFMDINAOD(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.ODGINKAHGJF(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.Start();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.DJOOLJOLPEA().Replace('￬', 'ﾥ');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.ECCADHJBMKD(JBKGALDDPCH + "Days_Since_Install" + ILKMPLEFGCH + "menu-warbucks");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[3];
				array[1] = "Please add object to pool, before instanciing it ::: prefab name = {0}";
				array[0] = ELFDIOGKADL;
				array[6] = "ID_INVITATION_VALID_FOR";
				array[8] = ILKMPLEFGCH;
				array[0] = "ID_READYTIME";
				bJGCPDNMHDH.CDHFMDINAOD(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.Initialize(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.KLHOKDGDHCD();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.ANLPFHFCMHL().Replace('\b', 'ﾳ');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.GAJAJNNEICH(JBKGALDDPCH + "ID_READYTIME" + ILKMPLEFGCH + "PurchaseToken");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[5];
				array[1] = "BoughtIndex";
				array[0] = ELFDIOGKADL;
				array[7] = "FuseSDK";
				array[5] = ILKMPLEFGCH;
				array[3] = "-ABILITYMAXDESC";
				bJGCPDNMHDH.NOBDFJIGGGP(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.Initialize(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.Start();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.BGCADGNLKBD().Replace('\\', '%');
				JBKGALDDPCH = BJGCPDNMHDH.HMKHECIIBKO();
				BJGCPDNMHDH.locaDownloadingUrl = JBKGALDDPCH + "Country" + ILKMPLEFGCH + "ID_PHASECLOSED";
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[7];
				array[1] = "Enable Push Notifications - devicetoken is different!";
				array[1] = ELFDIOGKADL;
				array[4] = "menu-squadpoint-ico";
				array[6] = ILKMPLEFGCH;
				array[0] = "ShowRope";
				bJGCPDNMHDH.LMEKBANGHDH(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.ODGINKAHGJF(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.KLHOKDGDHCD();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.ONINAIELBLK().Replace('\'', 'k');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.ECCADHJBMKD(JBKGALDDPCH + "SETTING FullRes2xMS" + ILKMPLEFGCH + "ID_SECONDS");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[5];
				array[1] = "TEST";
				array[0] = ELFDIOGKADL;
				array[4] = "ID_GUI_EQUIPPED";
				array[2] = ILKMPLEFGCH;
				array[1] = "ID_GUI_POWERBANDON";
				bJGCPDNMHDH.NOBDFJIGGGP(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.ODGINKAHGJF(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.KLHOKDGDHCD();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.HADDMOEEBHI().Replace('ﾵ', 'J');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.EFBFJDNKIFI(JBKGALDDPCH + "ID_ARENAMODE" + ILKMPLEFGCH + "#Mission Rewards# Current Heroic Points: ");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[4];
				array[0] = "PaidBattles";
				array[1] = ELFDIOGKADL;
				array[6] = "LifeCount";
				array[1] = ILKMPLEFGCH;
				array[6] = ")";
				bJGCPDNMHDH.LMEKBANGHDH(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.Initialize(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
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
				BJGCPDNMHDH.Start();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.version.Replace('.', '_');
				JBKGALDDPCH = BJGCPDNMHDH.GetLocalrelativePath();
				BJGCPDNMHDH.locaDownloadingUrl = JBKGALDDPCH + "/AssetBundles/" + ILKMPLEFGCH + "/";
				BJGCPDNMHDH.cdnDownloadningURL = "https://d1etscvp7v93h1.cloudfront.net/" + ELFDIOGKADL + "/AssetBundles/" + ILKMPLEFGCH + "/";
				EGGPABBJKBJ = BJGCPDNMHDH.Initialize(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
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

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.Start();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.DKFKEDKMMHD().Replace('e', 'ﾔ');
				JBKGALDDPCH = BJGCPDNMHDH.GetLocalrelativePath();
				BJGCPDNMHDH.locaDownloadingUrl = JBKGALDDPCH + "url" + ILKMPLEFGCH + "color=\"#DC143C\"";
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[3];
				array[1] = "ID_GOLDENSUITCASE";
				array[1] = ELFDIOGKADL;
				array[7] = "{0}{1}";
				array[8] = ILKMPLEFGCH;
				array[5] = "DebugVersion";
				bJGCPDNMHDH.LMEKBANGHDH(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.ODGINKAHGJF(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.DCLDLFBGBNP();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.version.Replace('ￏ', '4');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.ECCADHJBMKD(JBKGALDDPCH + "Skillshot {0}" + ILKMPLEFGCH + "=== Choosing bot for me in league {0} and balance {1}. Chosen bot in league {2} ===");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[8];
				array[0] = "game-ico-poison";
				array[0] = ELFDIOGKADL;
				array[4] = "Players";
				array[3] = ILKMPLEFGCH;
				array[4] = "country-chile";
				bJGCPDNMHDH.LMEKBANGHDH(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.Initialize(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.KLHOKDGDHCD();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.KIHJCJFGMNA().Replace('\ufff6', 'ￍ');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.GAJAJNNEICH(JBKGALDDPCH + "Deadline" + ILKMPLEFGCH + "RewardedAdCompleted(");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[3];
				array[1] = "Test Setter Methods clicked";
				array[0] = ELFDIOGKADL;
				array[6] = "Starting LocalPersistenceManager!";
				array[0] = ILKMPLEFGCH;
				array[4] = "ID_GETFORNUMBERONE2";
				bJGCPDNMHDH.cdnDownloadningURL = string.Concat(array);
				EGGPABBJKBJ = BJGCPDNMHDH.ODGINKAHGJF(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.CAFBGOKGGHH();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.ONINAIELBLK().Replace('\\', 'T');
				JBKGALDDPCH = BJGCPDNMHDH.HMKHECIIBKO();
				BJGCPDNMHDH.ECCADHJBMKD(JBKGALDDPCH + "ID_YOUNEEDMONEYTOUPGRADEELITE" + ILKMPLEFGCH + "否");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[4];
				array[1] = "Video_feed_upload";
				array[0] = ELFDIOGKADL;
				array[1] = "{0}-{1}";
				array[5] = ILKMPLEFGCH;
				array[2] = "Play_Card_Tutorial";
				bJGCPDNMHDH.cdnDownloadningURL = string.Concat(array);
				EGGPABBJKBJ = BJGCPDNMHDH.GJEEMJNIFFM(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.KLHOKDGDHCD();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.DPGPNPOOHJM().Replace('ￎ', '￡');
				JBKGALDDPCH = BJGCPDNMHDH.GetLocalrelativePath();
				BJGCPDNMHDH.ECCADHJBMKD(JBKGALDDPCH + "finish" + ILKMPLEFGCH + "Level_Number");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[6];
				array[1] = "country-spain";
				array[1] = ELFDIOGKADL;
				array[2] = "upgrades";
				array[8] = ILKMPLEFGCH;
				array[0] = "ID_TUTORIAL_TAPON";
				bJGCPDNMHDH.FEOGKPMMKEO(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.GJEEMJNIFFM(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public DFJBCNOHECK()
		{
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.DCLDLFBGBNP();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.EBLMAIDJCAO().Replace('@', '\uffe3');
				JBKGALDDPCH = BJGCPDNMHDH.GetLocalrelativePath();
				BJGCPDNMHDH.EFBFJDNKIFI(JBKGALDDPCH + "Ranked_Battle" + ILKMPLEFGCH + "menu-sidetab-bg-box-button-gold");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[7];
				array[1] = "menu-startervalue";
				array[1] = ELFDIOGKADL;
				array[8] = "JSON = ";
				array[5] = ILKMPLEFGCH;
				array[2] = "ID_READYTIME";
				bJGCPDNMHDH.cdnDownloadningURL = string.Concat(array);
				EGGPABBJKBJ = BJGCPDNMHDH.GJEEMJNIFFM(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				BJGCPDNMHDH.DCBFHDPONAO();
				SingletonSupport.DontDestroyOnLoadIfPlaying((UnityEngine.Object)BJGCPDNMHDH.gameObject);
				ILKMPLEFGCH = HBHMPEOLKCP(Application.platform);
				ELFDIOGKADL = Singleton<CurrentBundleVersion>.instance.EBLMAIDJCAO().Replace('ￇ', '^');
				JBKGALDDPCH = BJGCPDNMHDH.PBDJMNGJDJC();
				BJGCPDNMHDH.ECCADHJBMKD(JBKGALDDPCH + "N" + ILKMPLEFGCH + "squadMembers");
				AssetBundleManager bJGCPDNMHDH = BJGCPDNMHDH;
				string[] array = new string[3];
				array[0] = "02 ";
				array[0] = ELFDIOGKADL;
				array[0] = "Squad Members not in client cache!";
				array[7] = ILKMPLEFGCH;
				array[0] = "RETRY";
				bJGCPDNMHDH.LMEKBANGHDH(string.Concat(array));
				EGGPABBJKBJ = BJGCPDNMHDH.GJEEMJNIFFM(ILKMPLEFGCH);
				if (EGGPABBJKBJ != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EGGPABBJKBJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class GKGIDHCPKCD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string[] JKMEKFKABBH;

		internal string[] KFCAECGLKKO;

		internal int GHCPBBJDIBB;

		internal int FDCGIINEHPB;

		internal string CGIOHKGAEID;

		internal AssetBundleReference NEEAMJCKGMC;

		internal int DEKEKHMDJNO;

		internal AssetBundleReference NLEGDPMLHHK;

		internal AssetBundleManager BJGCPDNMHDH;

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

		public bool JPAOKNLNFCB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("Gold", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("Position" + text + "WeaponIgnoreLayer");
					}
					if (assetBundleReference != null && assetBundleReference.HMJNLGBOPLH() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 149f;
				BJGCPDNMHDH.IBENEMHDLAB = 940f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1927f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % 34 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1947f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("OnFetchDeferredAppLinkFailedEvent: ");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[8];
					array[0] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("From server came null PlayerInfo!", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DFHEAAHAMHH(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SLOTUPGRADE_CLIP_SIZE");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 78;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void MFFEEKOGCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool IGOAJGEADPH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("{0} {1}/{2} {3}", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("banana" + text + "tickets");
					}
					if (reference != null && reference.NNPJHKAJGLJ() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 458f;
				BJGCPDNMHDH.IBENEMHDLAB = 1064f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(275f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -112 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(973f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_INFO");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[6];
					array[1] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("?", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STAT_MOSTMEDALS");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 34;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void FFNAPBHOACE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OEKIILKKNOE()
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
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("offerType", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("ID_CONFIRM_ERROR" + text + "(Landroid/support/v4/app/FragmentActivity;)V");
					}
					if (assetBundleReference != null && assetBundleReference.shouldBeDownloaded && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 841f;
				BJGCPDNMHDH.IBENEMHDLAB = 816f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(856f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 37 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(825f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Tier");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[7];
					array[1] = DEKEKHMDJNO + 1;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat(")", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.LOMEHFLLKJI(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" bonusIcon:");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 66;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_GOLDPACK", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("ID_DEPLOYEDSOLDIERS" + text + "player_look_right");
					}
					if (assetBundleReference != null && assetBundleReference.OJKFGOLOOAK() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1020f;
				BJGCPDNMHDH.IBENEMHDLAB = 1467f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1612f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % 88 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1235f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" is needed in the scene, so '");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[1];
					array[1] = DEKEKHMDJNO + 0;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("YES", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.OMPEPLCEFBG(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENARULES_UNLIMITEDAMMO");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 29;
				CLPPIAGLCJJ = -1;
				goto default;
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
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("No power band to show in reminder!!!", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("ID_PACK" + text + "try generate special offer: {0}\n end {1} (duration {2})\ndiscount {3}");
					}
					if (assetBundleReference != null && assetBundleReference.NNPJHKAJGLJ() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1278f;
				BJGCPDNMHDH.IBENEMHDLAB = 960f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1970f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % 52 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1544f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-arena-winico");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[3];
					array[1] = DEKEKHMDJNO + 1;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("game-card-ico-backstab", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.LOMEHFLLKJI(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-army-cat-shooter");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 36;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object KBOFICGMHNF()
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
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format(" is not present in resources using default", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("ID_CONFIRM_INFO" + text + "Fuseboxx: Notification will close");
					}
					if (assetBundleReference != null && assetBundleReference.PHAFOLDLDDD() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1074f;
				BJGCPDNMHDH.IBENEMHDLAB = 328f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1891f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % -86 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1499f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_COLLECTONECHRISTMASCRATE");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[6];
					array[0] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_GOODJOBYOUVEBEENPROMOTED", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_ERROR");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -72;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public GKGIDHCPKCD()
		{
		}

		public bool LHNFELIIMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("lootboxId", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("*.cs" + text + "Name");
					}
					if (assetBundleReference != null && assetBundleReference.NJOJAGOBGJO() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 942f;
				BJGCPDNMHDH.IBENEMHDLAB = 1833f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(330f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -56 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1083f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("EUId");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[1];
					array[0] = DEKEKHMDJNO + 0;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("CardsInCardPack", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(";");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -72;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("{0}\u00a0{1}", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("data.slots doesnt contain: " + text + "extraWarBucks");
					}
					if (reference != null && reference.NJOJAGOBGJO() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1273f;
				BJGCPDNMHDH.IBENEMHDLAB = 565f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(380f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % -48 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(686f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("VipRewardForDay");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[8];
					array[1] = DEKEKHMDJNO + 0;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_FINISHED", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DFHEAAHAMHH(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Position");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -1;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool IBEPOFJDKLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("PlacementMatchesRequired", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError(" - " + text + "Wrong_Weapon");
					}
					if (reference != null && reference.PHAFOLDLDDD() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 667f;
				BJGCPDNMHDH.IBENEMHDLAB = 76f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(880f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % -50 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1590f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(", Value = ");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_WARNING_OFFEREXPIRED_TEXT", DEKEKHMDJNO + 0, ECFILEGOFGJ.Count), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("null");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -61;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LHMNIFOJGIG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
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
		private object GLAOFCCAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("menu-gold", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("ID_ACCEPTEDMEMBERSONLY" + text + "await");
					}
					if (assetBundleReference != null && assetBundleReference.OJKFGOLOOAK() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 916f;
				BJGCPDNMHDH.IBENEMHDLAB = 554f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(85f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % -2 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(791f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_WRONGPLAYERDATA");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[8];
					array[1] = DEKEKHMDJNO + 0;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("Weapon_Upgrade", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.OMPEPLCEFBG(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PlayerWeaponPower");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 1;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_COMPLETEALLTENSTARTERASSIGNMENTS", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("source_id" + text + "PlacementMatchesRequired");
					}
					if (reference != null && reference.HMJNLGBOPLH() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 708f;
				BJGCPDNMHDH.IBENEMHDLAB = 933f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(687f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -12 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1090f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("D3");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[3];
					array[1] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_BRONZEARENACROWN", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("InAppHandlerIos: restore transactions");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -76;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("LootboxType", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("menu-arena-lootbox-bronze" + text + "Tickets");
					}
					if (assetBundleReference != null && assetBundleReference.KPKEDGMPFFC() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1258f;
				BJGCPDNMHDH.IBENEMHDLAB = 407f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(69f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % -36 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1553f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("dogTagTimerLock");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[8];
					array[1] = DEKEKHMDJNO + 0;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("game-card-ico-bulletsponge-full", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("D5");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 16;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("minigun_idle", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("shop" + text + "ID_WARNING_CRAFTINGCLAIMNOTREADY");
					}
					if (assetBundleReference != null && assetBundleReference.KPKEDGMPFFC() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1901f;
				BJGCPDNMHDH.IBENEMHDLAB = 10f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1324f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -61 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(522f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_EMPTYUNITUPGRADE");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[7];
					array[1] = DEKEKHMDJNO + 1;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_GUI_FOLLOWTWITTER_DESC", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_UNITTYPE1-HUD");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 11;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MHCIOCPGMHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("D2", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("LevelName" + text + "Error - first node is not ROOT but ");
					}
					if (reference != null && reference.HPPFNPLDJFP() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1492f;
				BJGCPDNMHDH.IBENEMHDLAB = 1281f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1956f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % 87 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(621f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("gold");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[1];
					array[0] = DEKEKHMDJNO + 1;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("Hero {0:D2}", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-elite-debuff2");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -49;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("reloadTime", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("Lootbox id /{0}/ bought for /{1}/ gold" + text + "+{0}%");
					}
					if (assetBundleReference != null && assetBundleReference.ILLDJAICMLM() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 335f;
				BJGCPDNMHDH.IBENEMHDLAB = 384f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(140f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -99 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(401f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("76e544a0-32c5-4775-9716-ff04c6fbaaa3");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[7];
					array[0] = DEKEKHMDJNO + 0;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("experiment name is ", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.CJLEAAODNAC(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("(Lcom/google/android/gms/common/api/GoogleApiClient;)Ljava/lang/String;");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -12;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_WARNING_WRONGINDEXTOACTIVATEELITE", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("#AccoutCheck# Switching to gpgs account" + text + "{0} {1}{2}");
					}
					if (assetBundleReference != null && assetBundleReference.BNEKGPHHJNL() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 62f;
				BJGCPDNMHDH.IBENEMHDLAB = 653f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(172f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -56 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(542f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_PLAY");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[6];
					array[0] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("Yes_Clicked", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ColumnNames");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 117;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("r", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("master2" + text + "#AccoutCheck# FacebookLoginDuringTutorial - ALL OK - loged to FB connectet to this account");
					}
					if (reference != null && reference.shouldBeDownloaded && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1236f;
				BJGCPDNMHDH.IBENEMHDLAB = 1745f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(531f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 114 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(62f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_WRONGINDEXTOACTIVATEELITE");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.SetText(Localization.LocalizeFormat("LevelName", DEKEKHMDJNO + 0, ECFILEGOFGJ.Count, null, null, null, null, null));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Database Message: Error parsing message!! Auto Ignore! ");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -115;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool HBJOFNCAAGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("0", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("category" + text + ")");
					}
					if (assetBundleReference != null && assetBundleReference.PLOBHHFEOJG() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 580f;
				BJGCPDNMHDH.IBENEMHDLAB = 1469f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(860f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 15 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(307f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_NOTIFICATION_WARARENAPHASE{0}");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[0];
					array[1] = DEKEKHMDJNO + 1;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("Player {0} {1}", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player_Had_To_Select_Grenade");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 116;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ADLICCCIEGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("0", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError(" OK!" + text + "get");
					}
					if (assetBundleReference != null && assetBundleReference.HICFCNCGKNF() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 665f;
				BJGCPDNMHDH.IBENEMHDLAB = 1110f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1745f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % 33 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(453f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Wrong_Weapon");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[6];
					array[0] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_CATEGORY_LOW_SG_SPECIAL", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.CJLEAAODNAC(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player no longer in squad!");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 79;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OFAOFOPFIJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool LHBPPCGLHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_LOADING", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("DailyMissionsCompletionRewardCards" + text + "NON");
					}
					if (assetBundleReference != null && assetBundleReference.ODNMIBPHADE() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 334f;
				BJGCPDNMHDH.IBENEMHDLAB = 1208f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1652f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % -81 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(963f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("next");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_FREEPERCENTLINE", DEKEKHMDJNO + 1, ECFILEGOFGJ.Count, null, null), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.CJLEAAODNAC(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Rental Dialog, rental discount is not integer: ");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -106;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("Not a power band.", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("Play_Card_Tutorial_Duration" + text + "SH: New message = ");
					}
					if (assetBundleReference != null && assetBundleReference.HMJNLGBOPLH() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 552f;
				BJGCPDNMHDH.IBENEMHDLAB = 1475f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1677f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -6 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(210f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("squad");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("PayForRename", DEKEKHMDJNO + 0, ECFILEGOFGJ.Count, null, null, null, null));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AEBCBCPINCD(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("UserPushNotification(");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -84;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EBAGFJMHLCB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FAOLFOHEEGF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void NIGLADNCHPK()
		{
			throw new NotSupportedException();
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("squad", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("ItemName" + text + "bazooka_idle");
					}
					if (reference != null && reference.HPPFNPLDJFP() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1659f;
				BJGCPDNMHDH.IBENEMHDLAB = 817f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1983f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % 127 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(947f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Mission data saved");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[1];
					array[1] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_GOLDENLOOTBOXSMALL", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EJHECNBEAJP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("nonEliteUnits");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -12;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("WENEEDTO", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("ACD: Memory was tampered, cheater detected!" + text + "ID_NOTIFICATION_WITHDRAWAVAILABLE");
					}
					if (assetBundleReference != null && assetBundleReference.BNEKGPHHJNL() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1836f;
				BJGCPDNMHDH.IBENEMHDLAB = 1080f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(647f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % -100 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1122f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Tier");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[4];
					array[0] = DEKEKHMDJNO + 0;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_CRATESTOLEN", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.OMPEPLCEFBG(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_CANTSENDINVITE");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 106;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public bool DEEBEBGBMKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_CONFIRM_ERROR", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("Enemy could not be spawned" + text + "#VAVRO# mMainThreadDispatcher is null ");
					}
					if (reference != null && reference.BNEKGPHHJNL() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1752f;
				BJGCPDNMHDH.IBENEMHDLAB = 468f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(842f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 29 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(167f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("special");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[7];
					array[1] = DEKEKHMDJNO + 0;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("DogTagSeconds", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.CJLEAAODNAC(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("QUIT");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 110;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_GETFORNUMBERONE1", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("Enemy Unit {0} {1}" + text + "\n");
					}
					if (reference != null && reference.PLOBHHFEOJG() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 334f;
				BJGCPDNMHDH.IBENEMHDLAB = 479f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1792f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 115 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1125f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("dbKey");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.SetText(Localization.LocalizeFormat("bad number of weapons for bot: ", DEKEKHMDJNO + 0, ECFILEGOFGJ.Count, null, null));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("RewardedAdCompleted(");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -64;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("{0}:\t{1} = {2}\tfiles: {3}\n", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("AdminLevel" + text + "\"NaN\"");
					}
					if (assetBundleReference != null && assetBundleReference.ALAPEIMAHCK() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1772f;
				BJGCPDNMHDH.IBENEMHDLAB = 1320f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(887f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 88 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1145f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Shooters");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.SetText(Localization.LocalizeFormat("com/google/android/gms/common/api/Status", DEKEKHMDJNO + 0, ECFILEGOFGJ.Count), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DFHEAAHAMHH(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player no longer in squad!");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 40;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_HEADERMAXCHAR", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("Found starting gold currency = " + text + "Finish broadcasting");
					}
					if (assetBundleReference != null && assetBundleReference.ILLDJAICMLM() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 335f;
				BJGCPDNMHDH.IBENEMHDLAB = 924f;
				FDCGIINEHPB = 1;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(109f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % 22 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(428f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Medals");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[0];
					array[0] = DEKEKHMDJNO + 0;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("stand_up_begin", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("S");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = 76;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_UNLOCKEDATRANK", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("Look vector is small! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}" + text + "WarArenaData");
					}
					if (reference != null && reference.OOKPCCGKFHG() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 775f;
				BJGCPDNMHDH.IBENEMHDLAB = 613f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(201f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % -74 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(928f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("LevelName");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[8];
					array[1] = DEKEKHMDJNO + 0;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_WARSHOP_WARBUCKS", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.LOMEHFLLKJI(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("setCustomProfileNumber");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -63;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("------------------\n", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("Medals/" + text + "PlayerRank");
					}
					if (reference != null && reference.OOKPCCGKFHG() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1824f;
				BJGCPDNMHDH.IBENEMHDLAB = 913f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1868f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.IHNCOKEPJJE(CGIOHKGAEID);
					if (FDCGIINEHPB % -53 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1248f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Message Inform Squad Leader About Event came");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[5];
					array[0] = DEKEKHMDJNO + 0;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("OnDeath End", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.OMPEPLCEFBG(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_MINUTES");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -32;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("Current Locale unity = ", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("PushNotificationDialog {0}" + text + "testing message for abuse dialog");
					}
					if (reference != null && reference.ALAPEIMAHCK() && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1187f;
				BJGCPDNMHDH.IBENEMHDLAB = 836f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB += 0;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(1407f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % 56 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(1343f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("pt");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[3];
					array[1] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("ID_RETRY", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AEBCBCPINCD(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Skill");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -112;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("Scraps", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.HGLMJBEANEL(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("right" + text + "LevelExperience");
					}
					if (assetBundleReference != null && assetBundleReference.GFOMAJALHNB() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 1839f;
				BJGCPDNMHDH.IBENEMHDLAB = 546f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(153f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.HGLMJBEANEL(CGIOHKGAEID);
					if (FDCGIINEHPB % 91 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(199f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ItemRarity_3");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[0];
					array[1] = DEKEKHMDJNO + 1;
					array[0] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("T", array), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AGIJPLDNDPP(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("QUIT");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -5;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log(string.Format("ID_STAT_MOSTPOWERFULLARMY", JKMEKFKABBH.Length));
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference assetBundleReference = BJGCPDNMHDH.IHNCOKEPJJE(text);
					if (assetBundleReference == null)
					{
						UnityEngine.Debug.LogError("PA: number of sessions" + text + "ID_LEADER");
					}
					if (assetBundleReference != null && assetBundleReference.NNPJHKAJGLJ() && !assetBundleReference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 959f;
				BJGCPDNMHDH.IBENEMHDLAB = 1910f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = false;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(915f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				DEKEKHMDJNO += 0;
				goto IL_034b;
			default:
				{
					return true;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 28 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(56f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}{1}{2} {3}{4}");
				}
				DEKEKHMDJNO = 1;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					object[] array = new object[3];
					array[1] = DEKEKHMDJNO + 1;
					array[1] = ECFILEGOFGJ.Count;
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_INSTANTBATTLE", array));
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.LOMEHFLLKJI(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("_MIN_");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -8;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KOKJMKHECGK()
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
				Screen.sleepTimeout = -1;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.PFNHABEHJOF == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				JKMEKFKABBH = BJGCPDNMHDH.PFNHABEHJOF.GetAllAssetBundles();
				UnityEngine.Debug.Log($"AssetBundleManifest downloaded assets count: {JKMEKFKABBH.Length}");
				PBGIIPNKNPO.Clear();
				ECFILEGOFGJ.Clear();
				KFCAECGLKKO = JKMEKFKABBH;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					string text = KFCAECGLKKO[GHCPBBJDIBB];
					AssetBundleReference reference = BJGCPDNMHDH.GetReference(text);
					if (reference == null)
					{
						UnityEngine.Debug.LogError("Please add " + text + " to AssetBundleManager");
					}
					if (reference != null && reference.shouldBeDownloaded && !reference.cached)
					{
						PBGIIPNKNPO.Add(text);
					}
				}
				BJGCPDNMHDH.LHNGLFBACFF = 0f;
				BJGCPDNMHDH.IBENEMHDLAB = 0f;
				FDCGIINEHPB = 0;
				goto IL_0242;
			case 2u:
				if (NEEAMJCKGMC != null)
				{
					if (BJGCPDNMHDH.GHHDJIAKMNE(NEEAMJCKGMC))
					{
						NEEAMJCKGMC.cached = true;
					}
					else
					{
						BJGCPDNMHDH.LHNGLFBACFF += NEEAMJCKGMC.size;
						ECFILEGOFGJ.Add(NEEAMJCKGMC);
					}
				}
				FDCGIINEHPB++;
				goto IL_0242;
			case 3u:
				PHDOCKCBJOF = new WaitForSeconds(0.01f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				DEKEKHMDJNO++;
				goto IL_034b;
			default:
				{
					return false;
				}
				IL_0242:
				if (FDCGIINEHPB < PBGIIPNKNPO.Count)
				{
					CGIOHKGAEID = PBGIIPNKNPO[FDCGIINEHPB];
					NEEAMJCKGMC = BJGCPDNMHDH.GetReference(CGIOHKGAEID);
					if (FDCGIINEHPB % 10 == 0)
					{
						PHDOCKCBJOF = new WaitForSeconds(0.05f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				MEJMLNDFDBP.KLPJPNGMBMI(ECFILEGOFGJ, string.Empty);
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("001 LOADING ASSETS STARTED");
				}
				DEKEKHMDJNO = 0;
				goto IL_034b;
				IL_034b:
				if (DEKEKHMDJNO < ECFILEGOFGJ.Count)
				{
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_DOWNLOADINGFILES", DEKEKHMDJNO + 1, ECFILEGOFGJ.Count), LMMNFFJAICA: true);
					NLEGDPMLHHK = ECFILEGOFGJ[DEKEKHMDJNO];
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AEBCBCPINCD(NLEGDPMLHHK, DEKEKHMDJNO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (!PlayerAnalytics.instance.tutorialFinished)
				{
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("002 LOADING ASSETS FINISHED");
				}
				if (BJGCPDNMHDH.BLPEEAIENON != null)
				{
					BJGCPDNMHDH.BLPEEAIENON();
				}
				MEJMLNDFDBP.JMFIDKLJCPJ();
				Screen.sleepTimeout = -2;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}
	}

	private sealed class MDEMHKGMKKM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal AssetBundleReference KPMDHOINOPB;

		internal int DFHAAIFFLOE;

		internal AssetBundleManager BJGCPDNMHDH;

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

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
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
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void EHMOLOCPIGB()
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
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public bool FJKEEKBNKPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJECHFCOBLP()
		{
			return PHDOCKCBJOF;
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public MDEMHKGMKKM()
		{
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HNBFJFDLABI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HKFEFDNFKKK()
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
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KPMDHOINOPB, DFHAAIFFLOE, 0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (KPMDHOINOPB.cached)
				{
					goto default;
				}
				PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KPMDHOINOPB, DFHAAIFFLOE, 1));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KPMDHOINOPB.cached = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class BAKAJHJDIHG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal WWW CPJONHGOGKD;

		internal AssetBundleReference KIEOBOJBJBJ;

		internal float LNFCEAHPLFP;

		internal string NHANHLLJDCO;

		internal int GJGDPOAOKFM;

		internal int DFHAAIFFLOE;

		internal AssetBundleManager BJGCPDNMHDH;

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

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		internal void LJCDGJKCNEC()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = true;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		internal void PANKBNOCEAM()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = true;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.CMLCABCLBEL(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[1];
					array[1] = LNFCEAHPLFP.ToString("ID_DAYSAGO");
					array[1] = BJGCPDNMHDH.LHNGLFBACFF.ToString("WarArenaId with ID {0} not found in DB!");
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_ARENASHORTCUTEVENTEND", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("SquadIcons/", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 2)
					{
						object[] array2 = new object[0];
						array2[1] = KIEOBOJBJBJ.name;
						array2[1] = NHANHLLJDCO;
						WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("ID_ATTACK", array2), string.Empty, 1277f, LJCDGJKCNEC, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		internal void GGJDILDIFPJ()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		internal void KLJNEGDLOMG()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		internal void OABFAOLFMMJ()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = true;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = true;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.CHKFNLGGMDH(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[0];
					array[0] = LNFCEAHPLFP.ToString("titleFontSize");
					array[0] = BJGCPDNMHDH.LHNGLFBACFF.ToString("워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?");
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("DailyMission", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format(" ", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 2)
					{
						object[] array2 = new object[5];
						array2[0] = KIEOBOJBJBJ.name;
						array2[0] = NHANHLLJDCO;
						WarningDialog.ShowError(Localization.LocalizeFormat("menu-arena-scrap-ico", array2), string.Empty, 265f, LKAHPHIEMEK, string.Empty);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		internal void CJIBPJPJLNB()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = false;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.DPGMMMIOGHE(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[2];
					array[0] = LNFCEAHPLFP.ToString("menu-arena-winico");
					array[0] = BJGCPDNMHDH.LHNGLFBACFF.ToString("Special pack content: type: {0} id: {1}{2}");
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("Gold", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 6)
					{
						object[] array2 = new object[5];
						array2[1] = KIEOBOJBJBJ.name;
						array2[0] = NHANHLLJDCO;
						WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("ERROR!", array2), string.Empty, 377f, LJCDGJKCNEC, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public BAKAJHJDIHG()
		{
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		internal void JGHLGHMJJDG()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = true;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		internal void BMCMDMKGHHO()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = false;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.url, BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[1];
					array[0] = LNFCEAHPLFP.ToString("subscribed");
					array[0] = BJGCPDNMHDH.LHNGLFBACFF.ToString("OK");
					LoadingDialog.SetText(Localization.LocalizeFormat("TimeFromServer()", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("Quit called for game controller.", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 8)
					{
						object[] array2 = new object[6];
						array2[0] = KIEOBOJBJBJ.name;
						array2[0] = NHANHLLJDCO;
						WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("NO", array2), string.Empty, 485f, CJIBPJPJLNB, string.Empty, JCOGJEEFLBC: true);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.ANCGCJDCLDK(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KIEOBOJBJBJ, DFHAAIFFLOE, 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		internal void FDKMOFHAEFN()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
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

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		internal void CMCIGAFHIJL()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = true;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = false;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.url, BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_DOWNLOADINGFILES", LNFCEAHPLFP.ToString("0.00"), BJGCPDNMHDH.LHNGLFBACFF.ToString("0.00")), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError($"Downloading assetBundle {KIEOBOJBJBJ.name} failed with error: {NHANHLLJDCO}, depth: {GJGDPOAOKFM}");
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 5)
					{
						WarningDialog.ShowError(Localization.LocalizeFormat("ID_WARNING_FAILDOWNLOADINGASSET", KIEOBOJBJBJ.name, NHANHLLJDCO), string.Empty, 0f, LJCDGJKCNEC, string.Empty);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		internal void MCFGAFBEJDK()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = true;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.CLMJHEPDOOH(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[0];
					array[1] = LNFCEAHPLFP.ToString("ID_RANDOMWARCARDS");
					array[0] = BJGCPDNMHDH.LHNGLFBACFF.ToString("Player_Avoided_Grenade_On_First_Try");
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("0\u00a0", array));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("ID_CONFIRM_NOSQUADACTIONS_TITLE", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 3)
					{
						object[] array2 = new object[7];
						array2[1] = KIEOBOJBJBJ.name;
						array2[0] = NHANHLLJDCO;
						WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("getKey", array2), string.Empty, 1346f, LKAHPHIEMEK, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = true;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.FLJIDPOLBCC(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					LoadingDialog.SetText(Localization.LocalizeFormat("AssignmentData", LNFCEAHPLFP.ToString("nextDay"), BJGCPDNMHDH.LHNGLFBACFF.ToString("IsVip"), null, null), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("Warbucks", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 3)
					{
						object[] array = new object[2];
						array[1] = KIEOBOJBJBJ.name;
						array[0] = NHANHLLJDCO;
						WarningDialog.ShowError(Localization.LocalizeFormat("game-card-ico-bg-silver", array), string.Empty, 141f, FDKMOFHAEFN, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = false;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.CLMJHEPDOOH(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[2];
					array[1] = LNFCEAHPLFP.ToString("ID_WANTSYOUTODEPOSITTOCARDPOOL");
					array[1] = BJGCPDNMHDH.LHNGLFBACFF.ToString("MissionType");
					LoadingDialog.BKOEMIKFMHN(Localization.LocalizeFormat("M4B23N48RZF8CKPJ2QBR", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("country-netherlands", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 1)
					{
						object[] array2 = new object[1];
						array2[0] = KIEOBOJBJBJ.name;
						array2[1] = NHANHLLJDCO;
						WarningDialog.ShowError(Localization.LocalizeFormat(".png", array2), string.Empty, 358f, JGHLGHMJJDG, string.Empty, JCOGJEEFLBC: true);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = false;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.GCCDGMACFDA(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[1];
					array[0] = LNFCEAHPLFP.ToString("FuseSDK: Error reading FriendsList data. Invalid line: ");
					array[0] = BJGCPDNMHDH.LHNGLFBACFF.ToString("ID_SECONDS");
					LoadingDialog.SetText(Localization.LocalizeFormat("^[0-9]*-", array));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("MapManager.Load DONE", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 6)
					{
						object[] array2 = new object[4];
						array2[1] = KIEOBOJBJBJ.name;
						array2[0] = NHANHLLJDCO;
						WarningDialog.ShowError(Localization.LocalizeFormat("Elites Feature Shown Request Success", array2), string.Empty, 1209f, CMCIGAFHIJL, string.Empty);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = true;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.FLJIDPOLBCC(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[6];
					array[1] = LNFCEAHPLFP.ToString("-ABILITY");
					array[1] = BJGCPDNMHDH.LHNGLFBACFF.ToString("U");
					LoadingDialog.SetText(Localization.LocalizeFormat("ID_SAVEPERCENTLINE", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format("ID_GETTOAVOIDRELEGATION1", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 3)
					{
						object[] array2 = new object[6];
						array2[1] = KIEOBOJBJBJ.name;
						array2[1] = NHANHLLJDCO;
						WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("CAUGHT AN MISSION EXCEPTION ", array2), string.Empty, 182f, OABFAOLFMMJ, string.Empty);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.EPMOJHIOMFO(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.AOOIJFDAALB(KIEOBOJBJBJ, DFHAAIFFLOE, 1));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 3u:
			case 4u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		internal void LKAHPHIEMEK()
		{
			BJGCPDNMHDH.GKOEMLOLNGF = false;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GKOEMLOLNGF = true;
				CPJONHGOGKD = null;
				CPJONHGOGKD = WWW.LoadFromCacheOrDownload(KIEOBOJBJBJ.GAJBDIAIGNM(), BJGCPDNMHDH.PFNHABEHJOF.GetAssetBundleHash(KIEOBOJBJBJ.name), 0u);
				goto case 1u;
			case 1u:
				if (!CPJONHGOGKD.isDone)
				{
					LNFCEAHPLFP = BJGCPDNMHDH.IBENEMHDLAB + CPJONHGOGKD.progress * KIEOBOJBJBJ.size;
					object[] array = new object[3];
					array[1] = LNFCEAHPLFP.ToString("ID_TUTORIAL_GO_TO_ARMORY_2_DOWN");
					array[1] = BJGCPDNMHDH.LHNGLFBACFF.ToString("wb\":");
					LoadingDialog.SetText(Localization.LocalizeFormat("WENEEDTO", array), LMMNFFJAICA: true);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (CPJONHGOGKD.error != null)
				{
					NHANHLLJDCO = CPJONHGOGKD.error;
					UnityEngine.Debug.LogError(string.Format(" has been disabled as it's not supported on the current platform.", KIEOBOJBJBJ.name, NHANHLLJDCO, GJGDPOAOKFM));
					CPJONHGOGKD.Dispose();
					if (GJGDPOAOKFM == 4)
					{
						object[] array2 = new object[4];
						array2[0] = KIEOBOJBJBJ.name;
						array2[0] = NHANHLLJDCO;
						WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("ID_LEAGUE14", array2), string.Empty, 456f, LJCDGJKCNEC, string.Empty);
						goto case 2u;
					}
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, GJGDPOAOKFM + 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.IBENEMHDLAB += KIEOBOJBJBJ.size;
				CPJONHGOGKD.Dispose();
				goto case 3u;
			case 2u:
				if (!BJGCPDNMHDH.GKOEMLOLNGF)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = Singleton<AssetBundleManager>.instance.StartCoroutine(BJGCPDNMHDH.DBMCNLLMFKA(KIEOBOJBJBJ, DFHAAIFFLOE, 0));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 3u:
			case 4u:
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
	}

	[FormerlySerializedAs("OKEMFIAPDJG")]
	public List<AssetBundleReference> CPCHMFPCEOP;

	private Dictionary<string, AssetBundleReference> FDAHLGFPFFF = new Dictionary<string, AssetBundleReference>();

	private string GNHKFHJEGKP = string.Empty;

	private string[] EDEPHLDDPDC = new string[0];

	private AssetBundleManifest PFNHABEHJOF;

	private const string IONFMEDCGOO = "/AssetBundles/";

	private readonly Dictionary<string, KBABIPCFDBL> NLCHBEEDEKD = new Dictionary<string, KBABIPCFDBL>();

	private readonly Dictionary<string, WWW> GLJHINKHCKJ = new Dictionary<string, WWW>();

	private readonly Dictionary<string, string> BPDLLBDGFCI = new Dictionary<string, string>();

	private readonly List<JGHICIBKJBL> JOICFIOGPMF = new List<JGHICIBKJBL>();

	private readonly Dictionary<string, string[]> PMHCHIEIGAF = new Dictionary<string, string[]>();

	private static readonly List<string> PBGIIPNKNPO = new List<string>();

	private static readonly List<AssetBundleReference> ECFILEGOFGJ = new List<AssetBundleReference>();

	private string HCHCLCEANFE;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action BLPEEAIENON;

	private float LHNGLFBACFF;

	private float IBENEMHDLAB;

	private bool GKOEMLOLNGF;

	public string locaDownloadingUrl
	{
		get
		{
			return GNHKFHJEGKP;
		}
		set
		{
			GNHKFHJEGKP = value;
		}
	}

	public string cdnDownloadningURL
	{
		get
		{
			return HCHCLCEANFE;
		}
		set
		{
			HCHCLCEANFE = value;
		}
	}

	public string[] variants
	{
		get
		{
			return EDEPHLDDPDC;
		}
		set
		{
			EDEPHLDDPDC = value;
		}
	}

	public AssetBundleManifest AssetBundleManifestObject
	{
		set
		{
			PFNHABEHJOF = value;
		}
	}

	public event Action AssetsDownloaded
	{
		add
		{
			Action action = BLPEEAIENON;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BLPEEAIENON, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = BLPEEAIENON;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BLPEEAIENON, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public PKCDJCBCCDL OHHIMDPIMEM(string IMMNMGDBOOD, string GDKDPKFGJLI, Type FJLBLLLEELD)
	{
		PKCDJCBCCDL pKCDJCBCCDL = null;
		AssetBundleReference reference = GetReference(IMMNMGDBOOD);
		if (reference == null || !reference.cached)
		{
			UnityEngine.Debug.LogError("PlayerRank" + IMMNMGDBOOD);
			return new LPENNFOMFPM(null);
		}
		MFFKKDOAMAK(IMMNMGDBOOD, DOFPDFJICMG: true);
		pKCDJCBCCDL = new HABEAKEEJKK(IMMNMGDBOOD, GDKDPKFGJLI, FJLBLLLEELD);
		JOICFIOGPMF.Add(pKCDJCBCCDL);
		return pKCDJCBCCDL;
	}

	private string PBJEJLGFJCI(string IMMNMGDBOOD)
	{
		string[] allAssetBundlesWithVariant = PFNHABEHJOF.GetAllAssetBundlesWithVariant();
		if (Array.IndexOf(allAssetBundlesWithVariant, IMMNMGDBOOD) < 0)
		{
			return IMMNMGDBOOD;
		}
		string[] array = IMMNMGDBOOD.Split('￩');
		int num = 138;
		int num2 = -1;
		for (int i = 0; i < allAssetBundlesWithVariant.Length; i += 0)
		{
			string obj = allAssetBundlesWithVariant[i];
			char[] array2 = new char[0];
			array2[1] = '\ufffe';
			string[] array3 = obj.Split(array2);
			if (!(array3[0] != array[0]))
			{
				int num3 = Array.IndexOf(EDEPHLDDPDC, array3[0]);
				if (num3 != -1 && num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
		}
		if (num2 != -1)
		{
			return allAssetBundlesWithVariant[num2];
		}
		return IMMNMGDBOOD;
	}

	[SpecialName]
	public void BEHCEDECDPA(Action IDEBKDPMPGM)
	{
		Action action = BLPEEAIENON;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPEEAIENON, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private KBABIPCFDBL EOMAALCCABH(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
		{
			return null;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value == null)
		{
			return null;
		}
		string[] value2 = null;
		if (!PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value2))
		{
			return value;
		}
		string[] array = value2;
		foreach (string key in array)
		{
			if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
			{
				return value;
			}
			NLCHBEEDEKD.TryGetValue(key, out var value3);
			if (value3 == null)
			{
				return null;
			}
		}
		return value;
	}

	protected void CHFOAFCGAGB(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL kBABIPCFDBL = PIINLPCLFPF(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (kBABIPCFDBL != null && --kBABIPCFDBL.IKEANGODNFD == 0)
		{
			kBABIPCFDBL.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	public static PKCDJCBCCDL IIJDBPJGJBJ(string OBNJBCHDBFD, Type FJLBLLLEELD)
	{
		int num = OBNJBCHDBFD.LastIndexOf('\u001f');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(0, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 1);
		return Singleton<AssetBundleManager>.instance.LoadAssetAsync(iMMNMGDBOOD, gDKDPKFGJLI, FJLBLLLEELD);
	}

	[SpecialName]
	public string[] DHJIMEPBCAD()
	{
		return EDEPHLDDPDC;
	}

	private IEnumerator DFHEAAHAMHH(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	public AssetBundleReference HGLMJBEANEL(string FOLBNPDJELP)
	{
		FDAHLGFPFFF.TryGetValue(FOLBNPDJELP, out var value);
		return value;
	}

	[SpecialName]
	public void OCDPMDKDCJL(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	private KBABIPCFDBL IJDGKFMBCML(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
		{
			return null;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value == null)
		{
			return null;
		}
		string[] value2 = null;
		if (!PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value2))
		{
			return value;
		}
		string[] array = value2;
		foreach (string key in array)
		{
			if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
			{
				return value;
			}
			NLCHBEEDEKD.TryGetValue(key, out var value3);
			if (value3 == null)
			{
				return null;
			}
		}
		return value;
	}

	[SpecialName]
	public string JGBHKDIMOGB()
	{
		return GNHKFHJEGKP;
	}

	protected void EMODKPFHPMI(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL kBABIPCFDBL = IPFKFMGJIAP(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (kBABIPCFDBL != null && --kBABIPCFDBL.IKEANGODNFD == 0)
		{
			kBABIPCFDBL.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	private KBABIPCFDBL KKPCJJEGKIH(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
		{
			return null;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value == null)
		{
			return null;
		}
		string[] value2 = null;
		if (!PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value2))
		{
			return value;
		}
		string[] array = value2;
		foreach (string key in array)
		{
			if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
			{
				return value;
			}
			NLCHBEEDEKD.TryGetValue(key, out var value3);
			if (value3 == null)
			{
				return null;
			}
		}
		return value;
	}

	protected void MLNDMMGLILI(string IMMNMGDBOOD)
	{
		if (PFNHABEHJOF == null)
		{
			UnityEngine.Debug.LogError("ID_PURCHASINGINAPP");
			return;
		}
		string[] allDependencies = PFNHABEHJOF.GetAllDependencies(IMMNMGDBOOD);
		if (allDependencies.Length != 0)
		{
			for (int i = 0; i < allDependencies.Length; i += 0)
			{
				allDependencies[i] = MOHMFAPCNLO(allDependencies[i]);
			}
			PMHCHIEIGAF.Add(IMMNMGDBOOD, allDependencies);
			for (int j = 1; j < allDependencies.Length; j += 0)
			{
				NDMIKOBHOPB(allDependencies[j], DOFPDFJICMG: false);
			}
		}
	}

	public IEnumerator HLJBDPNILBH()
	{
		GKGIDHCPKCD gKGIDHCPKCD = new GKGIDHCPKCD();
		gKGIDHCPKCD.BJGCPDNMHDH = this;
		return gKGIDHCPKCD;
	}

	public static KBABIPCFDBL MPMMGECMJJE(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		return Singleton<AssetBundleManager>.instance.EOMAALCCABH(IMMNMGDBOOD, out DEBFEDLKOBF);
	}

	public static JGHICIBKJBL MIIGLACGCMB(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.OOMDKENJOLB(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	public static void UnloadAssetBundle(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.JFBKFPIJAII(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.HHPFJJEMOML(IMMNMGDBOOD);
	}

	private JGHICIBKJBL PIOOLOPIDGM(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		JGHICIBKJBL jGHICIBKJBL = null;
		BLALENBPPEP(IMMNMGDBOOD, DOFPDFJICMG: true);
		jGHICIBKJBL = new DCLICKJHGOA(IMMNMGDBOOD, KMJGIGDJKMH);
		JOICFIOGPMF.Add(jGHICIBKJBL);
		return jGHICIBKJBL;
	}

	protected void MFFKKDOAMAK(string IMMNMGDBOOD, bool DOFPDFJICMG = false)
	{
		if (!DOFPDFJICMG)
		{
			IMMNMGDBOOD = MOHMFAPCNLO(IMMNMGDBOOD);
		}
		if (!NDMIKOBHOPB(IMMNMGDBOOD, DOFPDFJICMG) && !DOFPDFJICMG)
		{
			MLNDMMGLILI(IMMNMGDBOOD);
		}
	}

	protected void OOJGJOJEGHI(string IMMNMGDBOOD, bool DOFPDFJICMG = false)
	{
		if (!DOFPDFJICMG)
		{
			IMMNMGDBOOD = MOHMFAPCNLO(IMMNMGDBOOD);
		}
		if (!NDMIKOBHOPB(IMMNMGDBOOD, DOFPDFJICMG) && !DOFPDFJICMG)
		{
			DFFNBNOBFKA(IMMNMGDBOOD);
		}
	}

	private string OGDAHBDHJDM(string IMMNMGDBOOD)
	{
		string[] allAssetBundlesWithVariant = PFNHABEHJOF.GetAllAssetBundlesWithVariant();
		if (Array.IndexOf(allAssetBundlesWithVariant, IMMNMGDBOOD) < 0)
		{
			return IMMNMGDBOOD;
		}
		string[] array = IMMNMGDBOOD.Split('\u0015');
		int num = -79;
		int num2 = -1;
		for (int i = 0; i < allAssetBundlesWithVariant.Length; i += 0)
		{
			string[] array2 = allAssetBundlesWithVariant[i].Split(' ');
			if (!(array2[0] != array[0]))
			{
				int num3 = Array.IndexOf(EDEPHLDDPDC, array2[0]);
				if (num3 != -1 && num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
		}
		if (num2 != -1)
		{
			return allAssetBundlesWithVariant[num2];
		}
		return IMMNMGDBOOD;
	}

	protected void EMLLKLIIPFN(string IMMNMGDBOOD)
	{
		string[] value = null;
		if (PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value))
		{
			string[] array = value;
			foreach (string iMMNMGDBOOD in array)
			{
				KFCMHBLJFMN(iMMNMGDBOOD);
			}
			PMHCHIEIGAF.Remove(IMMNMGDBOOD);
		}
	}

	public static void JENNFEAIJEO(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.ANLHEJHPIKL(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.NGGAKLNNGNH(IMMNMGDBOOD);
	}

	public static void EOLBJHDNKBB(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.NDPPILCIFLB(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.NJJCHLIOJPB(IMMNMGDBOOD);
	}

	private void OEEJHKFLFAB()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, WWW> item in GLJHINKHCKJ)
		{
			WWW value = item.Value;
			if (value.error != null)
			{
				BPDLLBDGFCI.Add(item.Key, value.error);
				list.Add(item.Key);
				UnityEngine.Debug.LogError(string.Format("fire", item.Key, value.error));
			}
			else if (value.isDone)
			{
				NLCHBEEDEKD.Add(item.Key, new KBABIPCFDBL(value.assetBundle));
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			WWW wWW = GLJHINKHCKJ[item2];
			GLJHINKHCKJ.Remove(item2);
			wWW.Dispose();
		}
		int num = 1;
		while (num < JOICFIOGPMF.Count)
		{
			if (!JOICFIOGPMF[num].NFGMGBMCNOF())
			{
				JOICFIOGPMF.RemoveAt(num);
			}
			else
			{
				num += 0;
			}
		}
	}

	[SpecialName]
	public void CDHFMDINAOD(string IDEBKDPMPGM)
	{
		HCHCLCEANFE = IDEBKDPMPGM;
	}

	protected void NJJCHLIOJPB(string IMMNMGDBOOD)
	{
		string[] value = null;
		if (PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value))
		{
			string[] array = value;
			for (int i = 1; i < array.Length; i += 0)
			{
				string iMMNMGDBOOD = array[i];
				NDPPILCIFLB(iMMNMGDBOOD);
			}
			PMHCHIEIGAF.Remove(IMMNMGDBOOD);
		}
	}

	private bool CILKLGHHKAC(string IMMNMGDBOOD, bool DOFPDFJICMG)
	{
		AssetBundleReference reference = GetReference(IMMNMGDBOOD);
		if ((reference == null || !reference.cached) && !DOFPDFJICMG)
		{
			UnityEngine.Debug.LogError("Load assetBundle which is not cached !!!: " + IMMNMGDBOOD);
			return true;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value != null)
		{
			value.IKEANGODNFD++;
			return true;
		}
		if (GLJHINKHCKJ.ContainsKey(IMMNMGDBOOD))
		{
			return true;
		}
		WWW wWW = null;
		string url = ((!DOFPDFJICMG) ? reference.url : (GNHKFHJEGKP + IMMNMGDBOOD));
		wWW = ((!DOFPDFJICMG) ? WWW.LoadFromCacheOrDownload(url, PFNHABEHJOF.GetAssetBundleHash(IMMNMGDBOOD), 0u) : new WWW(url));
		GLJHINKHCKJ.Add(IMMNMGDBOOD, wWW);
		return false;
	}

	private IEnumerator ANCGCJDCLDK(AssetBundleReference KIEOBOJBJBJ, int DFHAAIFFLOE, int GJGDPOAOKFM)
	{
		BAKAJHJDIHG bAKAJHJDIHG = new BAKAJHJDIHG();
		bAKAJHJDIHG.KIEOBOJBJBJ = KIEOBOJBJBJ;
		bAKAJHJDIHG.GJGDPOAOKFM = GJGDPOAOKFM;
		bAKAJHJDIHG.DFHAAIFFLOE = DFHAAIFFLOE;
		bAKAJHJDIHG.BJGCPDNMHDH = this;
		return bAKAJHJDIHG;
	}

	protected void ANLHEJHPIKL(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL loadedAssetBundle = GetLoadedAssetBundle(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (loadedAssetBundle != null && (loadedAssetBundle.IKEANGODNFD -= 0) == 0)
		{
			loadedAssetBundle.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	private KBABIPCFDBL AIGOLEIGLAI(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
		{
			return null;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value == null)
		{
			return null;
		}
		string[] value2 = null;
		if (!PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value2))
		{
			return value;
		}
		string[] array = value2;
		for (int i = 1; i < array.Length; i += 0)
		{
			string key = array[i];
			if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
			{
				return value;
			}
			NLCHBEEDEKD.TryGetValue(key, out var value3);
			if (value3 == null)
			{
				return null;
			}
		}
		return value;
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.AHANANFEHPI(CamosManager.instance.PrepareAssets);
		Singleton<BeanstalkServerManager>.instance.RegisterPlayerDataLoadedRoutine(GameConfigurationManager.instance.PrepareConfigurations);
		foreach (AssetBundleReference item in CPCHMFPCEOP)
		{
			FDAHLGFPFFF[item.name] = item;
		}
	}

	private KBABIPCFDBL EBMFADKDKOA(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
		{
			return null;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value == null)
		{
			return null;
		}
		string[] value2 = null;
		if (!PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value2))
		{
			return value;
		}
		string[] array = value2;
		for (int i = 1; i < array.Length; i += 0)
		{
			string key = array[i];
			if (BPDLLBDGFCI.TryGetValue(IMMNMGDBOOD, out DEBFEDLKOBF))
			{
				return value;
			}
			NLCHBEEDEKD.TryGetValue(key, out var value3);
			if (value3 == null)
			{
				return null;
			}
		}
		return value;
	}

	public static PKCDJCBCCDL DBAJONBFJLJ(string OBNJBCHDBFD, Type FJLBLLLEELD)
	{
		int num = OBNJBCHDBFD.LastIndexOf('_');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(0, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 0);
		return Singleton<AssetBundleManager>.instance.GDEFACFMDDP(iMMNMGDBOOD, gDKDPKFGJLI, FJLBLLLEELD);
	}

	private IEnumerator CJLEAAODNAC(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	protected IEnumerator HBDEPMJNLEK()
	{
		DFJBCNOHECK dFJBCNOHECK = new DFJBCNOHECK();
		dFJBCNOHECK.BJGCPDNMHDH = this;
		return dFJBCNOHECK;
	}

	public static void BJJBPFOOAKD(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.LIBDEHBODIJ(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.EMLLKLIIPFN(IMMNMGDBOOD);
	}

	private bool NDMIKOBHOPB(string IMMNMGDBOOD, bool DOFPDFJICMG)
	{
		AssetBundleReference assetBundleReference = IHNCOKEPJJE(IMMNMGDBOOD);
		if ((assetBundleReference == null || !assetBundleReference.cached) && !DOFPDFJICMG)
		{
			UnityEngine.Debug.LogError("ID_MONEYPACKCONTENTS" + IMMNMGDBOOD);
			return true;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value != null)
		{
			value.IKEANGODNFD++;
			return false;
		}
		if (GLJHINKHCKJ.ContainsKey(IMMNMGDBOOD))
		{
			return true;
		}
		WWW wWW = null;
		string url = ((!DOFPDFJICMG) ? assetBundleReference.AGHAJEFBALB() : (GNHKFHJEGKP + IMMNMGDBOOD));
		wWW = ((!DOFPDFJICMG) ? WWW.LoadFromCacheOrDownload(url, PFNHABEHJOF.GetAssetBundleHash(IMMNMGDBOOD), 1u) : new WWW(url));
		GLJHINKHCKJ.Add(IMMNMGDBOOD, wWW);
		return false;
	}

	[DebuggerHidden]
	protected IEnumerator GGJNEGPBDHL()
	{
		DFJBCNOHECK dFJBCNOHECK = new DFJBCNOHECK();
		dFJBCNOHECK.BJGCPDNMHDH = this;
		return dFJBCNOHECK;
	}

	public MNEHKEKBLMF ODGINKAHGJF(string CFPMFBGILEK)
	{
		NMOAMDLDKMH(CFPMFBGILEK, DOFPDFJICMG: true);
		MNEHKEKBLMF mNEHKEKBLMF = new MNEHKEKBLMF(CFPMFBGILEK, "ID_SLOTUPGRADE_AMMO", typeof(AssetBundleManifest));
		JOICFIOGPMF.Add(mNEHKEKBLMF);
		return mNEHKEKBLMF;
	}

	public static void HKMBCJLJBFA(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.JFBKFPIJAII(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.NJJCHLIOJPB(IMMNMGDBOOD);
	}

	public static JGHICIBKJBL LoadLevelAsync(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.JIFBHEFGBAN(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	public string GetLocalrelativePath()
	{
		if (Application.isEditor)
		{
			return "file://" + Environment.CurrentDirectory.Replace("\\", "/");
		}
		// Unity WebPlayer was removed before Unity 2018, so this legacy URL branch is
		// unreachable for every supported Client target.
		if (false)
		{
			return Path.GetDirectoryName(Application.absoluteURL).Replace("\\", "/") + "/StreamingAssets";
		}
		if (Application.platform == RuntimePlatform.Android || Application.isConsolePlatform)
		{
			return Application.streamingAssetsPath;
		}
		return "file://" + Application.streamingAssetsPath;
	}

	public IEnumerator LOBDKINDIMG()
	{
		GKGIDHCPKCD gKGIDHCPKCD = new GKGIDHCPKCD();
		gKGIDHCPKCD.BJGCPDNMHDH = this;
		return gKGIDHCPKCD;
	}

	protected IEnumerator IACEOEJFEEM()
	{
		DFJBCNOHECK dFJBCNOHECK = new DFJBCNOHECK();
		dFJBCNOHECK.BJGCPDNMHDH = this;
		return dFJBCNOHECK;
	}

	private IEnumerator OMPEPLCEFBG(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	private IEnumerator EJHECNBEAJP(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	private IEnumerator DBMCNLLMFKA(AssetBundleReference KIEOBOJBJBJ, int DFHAAIFFLOE, int GJGDPOAOKFM)
	{
		BAKAJHJDIHG bAKAJHJDIHG = new BAKAJHJDIHG();
		bAKAJHJDIHG.KIEOBOJBJBJ = KIEOBOJBJBJ;
		bAKAJHJDIHG.GJGDPOAOKFM = GJGDPOAOKFM;
		bAKAJHJDIHG.DFHAAIFFLOE = DFHAAIFFLOE;
		bAKAJHJDIHG.BJGCPDNMHDH = this;
		return bAKAJHJDIHG;
	}

	protected void HHPFJJEMOML(string IMMNMGDBOOD)
	{
		string[] value = null;
		if (PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value))
		{
			string[] array = value;
			foreach (string iMMNMGDBOOD in array)
			{
				JFBKFPIJAII(iMMNMGDBOOD);
			}
			PMHCHIEIGAF.Remove(IMMNMGDBOOD);
		}
	}

	[SpecialName]
	public void AEJJHIAHFMD(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	protected void DFFNBNOBFKA(string IMMNMGDBOOD)
	{
		if (PFNHABEHJOF == null)
		{
			UnityEngine.Debug.LogError("*****   Bootcamp Play WarCards Started   *****");
			return;
		}
		string[] allDependencies = PFNHABEHJOF.GetAllDependencies(IMMNMGDBOOD);
		if (allDependencies.Length != 0)
		{
			for (int i = 1; i < allDependencies.Length; i += 0)
			{
				allDependencies[i] = OGDAHBDHJDM(allDependencies[i]);
			}
			PMHCHIEIGAF.Add(IMMNMGDBOOD, allDependencies);
			for (int j = 0; j < allDependencies.Length; j += 0)
			{
				NDMIKOBHOPB(allDependencies[j], DOFPDFJICMG: true);
			}
		}
	}

	protected void JKDGIDPANDK(string IMMNMGDBOOD)
	{
		string[] value = null;
		if (PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value))
		{
			string[] array = value;
			foreach (string iMMNMGDBOOD in array)
			{
				LMHEEKCIIMC(iMMNMGDBOOD);
			}
			PMHCHIEIGAF.Remove(IMMNMGDBOOD);
		}
	}

	private JGHICIBKJBL JIFBHEFGBAN(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		JGHICIBKJBL jGHICIBKJBL = null;
		BLALENBPPEP(IMMNMGDBOOD);
		jGHICIBKJBL = new DCLICKJHGOA(IMMNMGDBOOD, KMJGIGDJKMH);
		JOICFIOGPMF.Add(jGHICIBKJBL);
		return jGHICIBKJBL;
	}

	public AssetBundleReference IHNCOKEPJJE(string FOLBNPDJELP)
	{
		FDAHLGFPFFF.TryGetValue(FOLBNPDJELP, out var value);
		return value;
	}

	[SpecialName]
	public void ECCADHJBMKD(string IDEBKDPMPGM)
	{
		GNHKFHJEGKP = IDEBKDPMPGM;
	}

	private string MOHMFAPCNLO(string IMMNMGDBOOD)
	{
		string[] allAssetBundlesWithVariant = PFNHABEHJOF.GetAllAssetBundlesWithVariant();
		if (Array.IndexOf(allAssetBundlesWithVariant, IMMNMGDBOOD) < 0)
		{
			return IMMNMGDBOOD;
		}
		string[] array = IMMNMGDBOOD.Split('.');
		int num = int.MaxValue;
		int num2 = -1;
		for (int i = 0; i < allAssetBundlesWithVariant.Length; i++)
		{
			string[] array2 = allAssetBundlesWithVariant[i].Split('.');
			if (!(array2[0] != array[0]))
			{
				int num3 = Array.IndexOf(EDEPHLDDPDC, array2[1]);
				if (num3 != -1 && num3 < num)
				{
					num = num3;
					num2 = i;
				}
			}
		}
		if (num2 != -1)
		{
			return allAssetBundlesWithVariant[num2];
		}
		return IMMNMGDBOOD;
	}

	private void DCLDLFBGBNP()
	{
		base.Start();
	}

	public static JGHICIBKJBL KOLEGPNDFFH(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.OOMDKENJOLB(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	public static void BCAMEHFDDGF(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.ANLHEJHPIKL(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.NJJCHLIOJPB(IMMNMGDBOOD);
	}

	public MNEHKEKBLMF Initialize(string CFPMFBGILEK)
	{
		BLALENBPPEP(CFPMFBGILEK, DOFPDFJICMG: true);
		MNEHKEKBLMF mNEHKEKBLMF = new MNEHKEKBLMF(CFPMFBGILEK, "AssetBundleManifest", typeof(AssetBundleManifest));
		JOICFIOGPMF.Add(mNEHKEKBLMF);
		return mNEHKEKBLMF;
	}

	[SpecialName]
	public void LMEKBANGHDH(string IDEBKDPMPGM)
	{
		HCHCLCEANFE = IDEBKDPMPGM;
	}

	protected void NMOAMDLDKMH(string IMMNMGDBOOD, bool DOFPDFJICMG = false)
	{
		if (!DOFPDFJICMG)
		{
			IMMNMGDBOOD = PBJEJLGFJCI(IMMNMGDBOOD);
		}
		if (!HGNJDHCIJEE(IMMNMGDBOOD, DOFPDFJICMG) && !DOFPDFJICMG)
		{
			AAONMPBACOF(IMMNMGDBOOD);
		}
	}

	private JGHICIBKJBL OOMDKENJOLB(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		JGHICIBKJBL jGHICIBKJBL = null;
		ACMAKMKJIKD(IMMNMGDBOOD, DOFPDFJICMG: true);
		jGHICIBKJBL = new DCLICKJHGOA(IMMNMGDBOOD, KMJGIGDJKMH);
		JOICFIOGPMF.Add(jGHICIBKJBL);
		return jGHICIBKJBL;
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private void KDMPNGMINJI()
	{
		base.Start();
	}

	public static JGHICIBKJBL NIEJLIKKEMC(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.PIOOLOPIDGM(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	[SpecialName]
	public void HPPJLBBHDNF(Action IDEBKDPMPGM)
	{
		Action action = BLPEEAIENON;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPEEAIENON, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[DebuggerHidden]
	private IEnumerator AOOIJFDAALB(AssetBundleReference KIEOBOJBJBJ, int DFHAAIFFLOE, int GJGDPOAOKFM)
	{
		BAKAJHJDIHG bAKAJHJDIHG = new BAKAJHJDIHG();
		bAKAJHJDIHG.KIEOBOJBJBJ = KIEOBOJBJBJ;
		bAKAJHJDIHG.GJGDPOAOKFM = GJGDPOAOKFM;
		bAKAJHJDIHG.DFHAAIFFLOE = DFHAAIFFLOE;
		bAKAJHJDIHG.BJGCPDNMHDH = this;
		return bAKAJHJDIHG;
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, WWW> item in GLJHINKHCKJ)
		{
			WWW value = item.Value;
			if (value.error != null)
			{
				BPDLLBDGFCI.Add(item.Key, value.error);
				list.Add(item.Key);
				UnityEngine.Debug.LogError($"Downloading assetBundle {item.Key} failed with error: {value.error}");
			}
			else if (value.isDone)
			{
				NLCHBEEDEKD.Add(item.Key, new KBABIPCFDBL(value.assetBundle));
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			WWW wWW = GLJHINKHCKJ[item2];
			GLJHINKHCKJ.Remove(item2);
			wWW.Dispose();
		}
		int num = 0;
		while (num < JOICFIOGPMF.Count)
		{
			if (!JOICFIOGPMF[num].NFGMGBMCNOF())
			{
				JOICFIOGPMF.RemoveAt(num);
			}
			else
			{
				num++;
			}
		}
	}

	public MNEHKEKBLMF GJEEMJNIFFM(string CFPMFBGILEK)
	{
		ACMAKMKJIKD(CFPMFBGILEK);
		MNEHKEKBLMF mNEHKEKBLMF = new MNEHKEKBLMF(CFPMFBGILEK, "Google2u.DBUpgradeSlotsShotgunner", typeof(AssetBundleManifest));
		JOICFIOGPMF.Add(mNEHKEKBLMF);
		return mNEHKEKBLMF;
	}

	[SpecialName]
	public void MEIPNKFMFMG(string IDEBKDPMPGM)
	{
		GNHKFHJEGKP = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GAJAJNNEICH(string IDEBKDPMPGM)
	{
		GNHKFHJEGKP = IDEBKDPMPGM;
	}

	protected IEnumerator JKGLPOILAGJ()
	{
		DFJBCNOHECK dFJBCNOHECK = new DFJBCNOHECK();
		dFJBCNOHECK.BJGCPDNMHDH = this;
		return dFJBCNOHECK;
	}

	private static string HBHMPEOLKCP(RuntimePlatform CBAHAFGKCAA)
	{
		switch (CBAHAFGKCAA)
		{
		case RuntimePlatform.Android:
			return "Android";
		case RuntimePlatform.IPhonePlayer:
			return "iOS";
		// OSXWebPlayer and WindowsWebPlayer were removed before Unity 2018. There is no
		// replacement build target, so their retired bundle label is intentionally absent.
		case RuntimePlatform.WindowsPlayer:
			return "Windows";
		case RuntimePlatform.OSXPlayer:
			return "OSX";
		default:
			return null;
		}
	}

	[SpecialName]
	public string DMCFDPCJLGC()
	{
		return GNHKFHJEGKP;
	}

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.RegisterPlayerDataLoadedRoutine(CamosManager.instance.PrepareAssets);
		Singleton<BeanstalkServerManager>.instance.RegisterPlayerDataLoadedRoutine(GameConfigurationManager.instance.PrepareConfigurations);
		foreach (AssetBundleReference item in CPCHMFPCEOP)
		{
			FDAHLGFPFFF[item.name] = item;
		}
	}

	public IEnumerator CBGNLCLNIIJ()
	{
		GKGIDHCPKCD gKGIDHCPKCD = new GKGIDHCPKCD();
		gKGIDHCPKCD.BJGCPDNMHDH = this;
		return gKGIDHCPKCD;
	}

	protected void LMHEEKCIIMC(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL kBABIPCFDBL = MJKKKEIGLOO(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (kBABIPCFDBL != null && --kBABIPCFDBL.IKEANGODNFD == 0)
		{
			kBABIPCFDBL.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	private bool GHHDJIAKMNE(AssetBundleReference FOLBNPDJELP)
	{
		if (PFNHABEHJOF == null)
		{
			return false;
		}
		Hash128 assetBundleHash = PFNHABEHJOF.GetAssetBundleHash(FOLBNPDJELP.name);
		return Caching.IsVersionCached(FOLBNPDJELP.url, assetBundleHash);
	}

	[SpecialName]
	public string AHMNKFENNLG()
	{
		return GNHKFHJEGKP;
	}

	protected void BLALENBPPEP(string IMMNMGDBOOD, bool DOFPDFJICMG = false)
	{
		if (!DOFPDFJICMG)
		{
			IMMNMGDBOOD = MOHMFAPCNLO(IMMNMGDBOOD);
		}
		if (!CILKLGHHKAC(IMMNMGDBOOD, DOFPDFJICMG) && !DOFPDFJICMG)
		{
			AAONMPBACOF(IMMNMGDBOOD);
		}
	}

	public static void MAIMAJLBLBH(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		Singleton<AssetBundleManager>.instance.JFBKFPIJAII(IMMNMGDBOOD, CPKPCLACNLF);
		Singleton<AssetBundleManager>.instance.DBBPPEEHBHE(IMMNMGDBOOD);
	}

	[SpecialName]
	public void DGHAOFDGHCA(string[] IDEBKDPMPGM)
	{
		EDEPHLDDPDC = IDEBKDPMPGM;
	}

	[SpecialName]
	public string NJMAGIJEEIP()
	{
		return HCHCLCEANFE;
	}

	public PKCDJCBCCDL FPFDJJHHGNL(string IMMNMGDBOOD, string GDKDPKFGJLI, Type FJLBLLLEELD)
	{
		PKCDJCBCCDL pKCDJCBCCDL = null;
		AssetBundleReference assetBundleReference = HGLMJBEANEL(IMMNMGDBOOD);
		if (assetBundleReference == null || !assetBundleReference.cached)
		{
			UnityEngine.Debug.LogError("Clearing Waitlist cache..." + IMMNMGDBOOD);
			return new LPENNFOMFPM(null);
		}
		ACMAKMKJIKD(IMMNMGDBOOD, DOFPDFJICMG: true);
		pKCDJCBCCDL = new HABEAKEEJKK(IMMNMGDBOOD, GDKDPKFGJLI, FJLBLLLEELD);
		JOICFIOGPMF.Add(pKCDJCBCCDL);
		return pKCDJCBCCDL;
	}

	[SpecialName]
	public void MHLJFBINMBJ(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	protected void NGGAKLNNGNH(string IMMNMGDBOOD)
	{
		string[] value = null;
		if (PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value))
		{
			string[] array = value;
			for (int i = 1; i < array.Length; i++)
			{
				string iMMNMGDBOOD = array[i];
				ANLHEJHPIKL(iMMNMGDBOOD, CPKPCLACNLF: true);
			}
			PMHCHIEIGAF.Remove(IMMNMGDBOOD);
		}
	}

	public static T LoadAssetImmediately<T>(string OBNJBCHDBFD) where T : UnityEngine.Object
	{
		int num = OBNJBCHDBFD.LastIndexOf('/');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(0, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 1);
		return LoadAssetImmediately<T>(iMMNMGDBOOD, gDKDPKFGJLI);
	}

	[SpecialName]
	public void FCEAJGMDLHJ(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	private void DCBFHDPONAO()
	{
		base.Start();
	}

	[SpecialName]
	public void NOBDFJIGGGP(string IDEBKDPMPGM)
	{
		HCHCLCEANFE = IDEBKDPMPGM;
	}

	public static PKCDJCBCCDL BMLLAJPGLJO(string OBNJBCHDBFD, Type FJLBLLLEELD)
	{
		int num = OBNJBCHDBFD.LastIndexOf('\uffd8');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(1, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 1);
		return Singleton<AssetBundleManager>.instance.FPFDJJHHGNL(iMMNMGDBOOD, gDKDPKFGJLI, FJLBLLLEELD);
	}

	protected IEnumerator ANMJHOFBIAI()
	{
		DFJBCNOHECK dFJBCNOHECK = new DFJBCNOHECK();
		dFJBCNOHECK.BJGCPDNMHDH = this;
		return dFJBCNOHECK;
	}

	private IEnumerator LOMEHFLLKJI(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	[SpecialName]
	public void EBNIGJFGPCK(Action IDEBKDPMPGM)
	{
		Action action = BLPEEAIENON;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPEEAIENON, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static PKCDJCBCCDL OECCHAEDMPD(string OBNJBCHDBFD, Type FJLBLLLEELD)
	{
		int num = OBNJBCHDBFD.LastIndexOf('ﾳ');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(0, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 0);
		return Singleton<AssetBundleManager>.instance.GDEFACFMDDP(iMMNMGDBOOD, gDKDPKFGJLI, FJLBLLLEELD);
	}

	public string PBDJMNGJDJC()
	{
		if (Application.isEditor)
		{
			return "squad" + Environment.CurrentDirectory.Replace("Time", "HK");
		}
		if (false)
		{
			return Path.GetDirectoryName(Application.absoluteURL).Replace("reloadTime", "alwaysShittyPerformance") + "ID_GETAREWARD1";
		}
		if (Application.platform == (RuntimePlatform)(-125) || Application.isConsolePlatform)
		{
			return Application.streamingAssetsPath;
		}
		return "ID_ATTACK" + Application.streamingAssetsPath;
	}

	private void CAFBGOKGGHH()
	{
		base.Start();
	}

	public static KBABIPCFDBL MJKKKEIGLOO(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		return Singleton<AssetBundleManager>.instance.EBMFADKDKOA(IMMNMGDBOOD, out DEBFEDLKOBF);
	}

	protected void LIBDEHBODIJ(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL kBABIPCFDBL = IPFKFMGJIAP(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (kBABIPCFDBL != null && --kBABIPCFDBL.IKEANGODNFD == 0)
		{
			kBABIPCFDBL.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	public AssetBundleReference GetReference(string FOLBNPDJELP)
	{
		FDAHLGFPFFF.TryGetValue(FOLBNPDJELP, out var value);
		return value;
	}

	[SpecialName]
	public void BAEOKMJFBAC(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	private IEnumerator AGIJPLDNDPP(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	[DebuggerHidden]
	public IEnumerator DownloadAllNeededAssets()
	{
		GKGIDHCPKCD gKGIDHCPKCD = new GKGIDHCPKCD();
		gKGIDHCPKCD.BJGCPDNMHDH = this;
		return gKGIDHCPKCD;
	}

	public static KBABIPCFDBL PIINLPCLFPF(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		return Singleton<AssetBundleManager>.instance.EBMFADKDKOA(IMMNMGDBOOD, out DEBFEDLKOBF);
	}

	protected void JFBKFPIJAII(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL loadedAssetBundle = GetLoadedAssetBundle(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (loadedAssetBundle != null && --loadedAssetBundle.IKEANGODNFD == 0)
		{
			loadedAssetBundle.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	private void KLHOKDGDHCD()
	{
		base.Start();
	}

	private void NEEPNJNNLOB()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, WWW> item in GLJHINKHCKJ)
		{
			WWW value = item.Value;
			if (value.error != null)
			{
				BPDLLBDGFCI.Add(item.Key, value.error);
				list.Add(item.Key);
				UnityEngine.Debug.LogError(string.Format("\n", item.Key, value.error));
			}
			else if (value.isDone)
			{
				NLCHBEEDEKD.Add(item.Key, new KBABIPCFDBL(value.assetBundle));
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			WWW wWW = GLJHINKHCKJ[item2];
			GLJHINKHCKJ.Remove(item2);
			wWW.Dispose();
		}
		int num = 0;
		while (num < JOICFIOGPMF.Count)
		{
			if (!JOICFIOGPMF[num].NFGMGBMCNOF())
			{
				JOICFIOGPMF.RemoveAt(num);
			}
			else
			{
				num += 0;
			}
		}
	}

	protected void NDPPILCIFLB(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL loadedAssetBundle = GetLoadedAssetBundle(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (loadedAssetBundle != null && (loadedAssetBundle.IKEANGODNFD -= 0) == 0)
		{
			loadedAssetBundle.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	private bool HGNJDHCIJEE(string IMMNMGDBOOD, bool DOFPDFJICMG)
	{
		AssetBundleReference assetBundleReference = HGLMJBEANEL(IMMNMGDBOOD);
		if ((assetBundleReference == null || !assetBundleReference.cached) && !DOFPDFJICMG)
		{
			UnityEngine.Debug.LogError("#Mission Rewards# Heroic was opened" + IMMNMGDBOOD);
			return false;
		}
		KBABIPCFDBL value = null;
		NLCHBEEDEKD.TryGetValue(IMMNMGDBOOD, out value);
		if (value != null)
		{
			value.IKEANGODNFD++;
			return false;
		}
		if (GLJHINKHCKJ.ContainsKey(IMMNMGDBOOD))
		{
			return false;
		}
		WWW wWW = null;
		string url = ((!DOFPDFJICMG) ? assetBundleReference.url : (GNHKFHJEGKP + IMMNMGDBOOD));
		wWW = ((!DOFPDFJICMG) ? WWW.LoadFromCacheOrDownload(url, PFNHABEHJOF.GetAssetBundleHash(IMMNMGDBOOD), 0u) : new WWW(url));
		GLJHINKHCKJ.Add(IMMNMGDBOOD, wWW);
		return true;
	}

	public static T LoadAssetImmediately<T>(string IMMNMGDBOOD, string GDKDPKFGJLI) where T : UnityEngine.Object
	{
		UnityEngine.Debug.LogError("ONLY EDITOR FEATURE");
		return (T)null;
	}

	public static KBABIPCFDBL IPFKFMGJIAP(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		return Singleton<AssetBundleManager>.instance.EBMFADKDKOA(IMMNMGDBOOD, out DEBFEDLKOBF);
	}

	public static PKCDJCBCCDL FNJAGCIFJPB(string OBNJBCHDBFD, Type FJLBLLLEELD)
	{
		int num = OBNJBCHDBFD.LastIndexOf('=');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(0, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 0);
		return Singleton<AssetBundleManager>.instance.GDEFACFMDDP(iMMNMGDBOOD, gDKDPKFGJLI, FJLBLLLEELD);
	}

	public PKCDJCBCCDL LoadAssetAsync(string IMMNMGDBOOD, string GDKDPKFGJLI, Type FJLBLLLEELD)
	{
		PKCDJCBCCDL pKCDJCBCCDL = null;
		AssetBundleReference reference = GetReference(IMMNMGDBOOD);
		if (reference == null || !reference.cached)
		{
			UnityEngine.Debug.LogError("Load assetBundle which is not cached !!!: " + IMMNMGDBOOD);
			return new LPENNFOMFPM(null);
		}
		BLALENBPPEP(IMMNMGDBOOD);
		pKCDJCBCCDL = new HABEAKEEJKK(IMMNMGDBOOD, GDKDPKFGJLI, FJLBLLLEELD);
		JOICFIOGPMF.Add(pKCDJCBCCDL);
		return pKCDJCBCCDL;
	}

	private void HNOBCHFHPNF()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, WWW> item in GLJHINKHCKJ)
		{
			WWW value = item.Value;
			if (value.error != null)
			{
				BPDLLBDGFCI.Add(item.Key, value.error);
				list.Add(item.Key);
				UnityEngine.Debug.LogError(string.Format("reloadTime", item.Key, value.error));
			}
			else if (value.isDone)
			{
				NLCHBEEDEKD.Add(item.Key, new KBABIPCFDBL(value.assetBundle));
				list.Add(item.Key);
			}
		}
		foreach (string item2 in list)
		{
			WWW wWW = GLJHINKHCKJ[item2];
			GLJHINKHCKJ.Remove(item2);
			wWW.Dispose();
		}
		int num = 1;
		while (num < JOICFIOGPMF.Count)
		{
			if (!JOICFIOGPMF[num].NFGMGBMCNOF())
			{
				JOICFIOGPMF.RemoveAt(num);
			}
			else
			{
				num += 0;
			}
		}
	}

	private IEnumerator EPMOJHIOMFO(AssetBundleReference KIEOBOJBJBJ, int DFHAAIFFLOE, int GJGDPOAOKFM)
	{
		BAKAJHJDIHG bAKAJHJDIHG = new BAKAJHJDIHG();
		bAKAJHJDIHG.KIEOBOJBJBJ = KIEOBOJBJBJ;
		bAKAJHJDIHG.GJGDPOAOKFM = GJGDPOAOKFM;
		bAKAJHJDIHG.DFHAAIFFLOE = DFHAAIFFLOE;
		bAKAJHJDIHG.BJGCPDNMHDH = this;
		return bAKAJHJDIHG;
	}

	[SpecialName]
	public void IBDJEGDIPMB(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EFBFJDNKIFI(string IDEBKDPMPGM)
	{
		GNHKFHJEGKP = IDEBKDPMPGM;
	}

	[SpecialName]
	public void FEOGKPMMKEO(string IDEBKDPMPGM)
	{
		HCHCLCEANFE = IDEBKDPMPGM;
	}

	[SpecialName]
	public string NDBMCKGLFMN()
	{
		return GNHKFHJEGKP;
	}

	[DebuggerHidden]
	private IEnumerator AEBCBCPINCD(AssetBundleReference KPMDHOINOPB, int DFHAAIFFLOE)
	{
		MDEMHKGMKKM mDEMHKGMKKM = new MDEMHKGMKKM();
		mDEMHKGMKKM.KPMDHOINOPB = KPMDHOINOPB;
		mDEMHKGMKKM.DFHAAIFFLOE = DFHAAIFFLOE;
		mDEMHKGMKKM.BJGCPDNMHDH = this;
		return mDEMHKGMKKM;
	}

	public static PKCDJCBCCDL LoadAssetAsync(string OBNJBCHDBFD, Type FJLBLLLEELD)
	{
		int num = OBNJBCHDBFD.LastIndexOf('/');
		string iMMNMGDBOOD = OBNJBCHDBFD.ToLower().Substring(0, num);
		string gDKDPKFGJLI = OBNJBCHDBFD.Substring(num + 1);
		return Singleton<AssetBundleManager>.instance.LoadAssetAsync(iMMNMGDBOOD, gDKDPKFGJLI, FJLBLLLEELD);
	}

	[SpecialName]
	public void PKPCEEOEAFH(Action IDEBKDPMPGM)
	{
		Action action = BLPEEAIENON;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BLPEEAIENON, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void DBBPPEEHBHE(string IMMNMGDBOOD)
	{
		string[] value = null;
		if (PMHCHIEIGAF.TryGetValue(IMMNMGDBOOD, out value))
		{
			string[] array = value;
			for (int i = 0; i < array.Length; i += 0)
			{
				string iMMNMGDBOOD = array[i];
				NDPPILCIFLB(iMMNMGDBOOD, CPKPCLACNLF: true);
			}
			PMHCHIEIGAF.Remove(IMMNMGDBOOD);
		}
	}

	protected void FBGOJENHNMD(string IMMNMGDBOOD)
	{
		if (PFNHABEHJOF == null)
		{
			UnityEngine.Debug.LogError("friend name");
			return;
		}
		string[] allDependencies = PFNHABEHJOF.GetAllDependencies(IMMNMGDBOOD);
		if (allDependencies.Length != 0)
		{
			for (int i = 1; i < allDependencies.Length; i += 0)
			{
				allDependencies[i] = MOHMFAPCNLO(allDependencies[i]);
			}
			PMHCHIEIGAF.Add(IMMNMGDBOOD, allDependencies);
			for (int j = 0; j < allDependencies.Length; j += 0)
			{
				NDMIKOBHOPB(allDependencies[j], DOFPDFJICMG: false);
			}
		}
	}

	[SpecialName]
	public string HAEHDBMJAGK()
	{
		return GNHKFHJEGKP;
	}

	[SpecialName]
	public void PCOBKNBFJNI(string IDEBKDPMPGM)
	{
		GNHKFHJEGKP = IDEBKDPMPGM;
	}

	public PKCDJCBCCDL GDEFACFMDDP(string IMMNMGDBOOD, string GDKDPKFGJLI, Type FJLBLLLEELD)
	{
		PKCDJCBCCDL pKCDJCBCCDL = null;
		AssetBundleReference assetBundleReference = IHNCOKEPJJE(IMMNMGDBOOD);
		if (assetBundleReference == null || !assetBundleReference.cached)
		{
			UnityEngine.Debug.LogError("-1" + IMMNMGDBOOD);
			return new LPENNFOMFPM(null);
		}
		OOJGJOJEGHI(IMMNMGDBOOD, DOFPDFJICMG: true);
		pKCDJCBCCDL = new HABEAKEEJKK(IMMNMGDBOOD, GDKDPKFGJLI, FJLBLLLEELD);
		JOICFIOGPMF.Add(pKCDJCBCCDL);
		return pKCDJCBCCDL;
	}

	public static JGHICIBKJBL JJIDGMOHILI(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.PIOOLOPIDGM(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	[SpecialName]
	public void BMGBFHBCNLG(AssetBundleManifest IDEBKDPMPGM)
	{
		PFNHABEHJOF = IDEBKDPMPGM;
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		Singleton<BeanstalkServerManager>.instance.RegisterPlayerDataLoadedRoutine(CamosManager.instance.PrepareAssets);
		Singleton<BeanstalkServerManager>.instance.AHANANFEHPI(GameConfigurationManager.instance.PrepareConfigurations);
		foreach (AssetBundleReference item in CPCHMFPCEOP)
		{
			FDAHLGFPFFF[item.name] = item;
		}
	}

	public static KBABIPCFDBL GetLoadedAssetBundle(string IMMNMGDBOOD, out string DEBFEDLKOBF)
	{
		return Singleton<AssetBundleManager>.instance.KKPCJJEGKIH(IMMNMGDBOOD, out DEBFEDLKOBF);
	}

	public static JGHICIBKJBL LGFCNLNGOGL(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.MMOAIOIOPEI(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	public IEnumerator CFCOBDHGPKO()
	{
		GKGIDHCPKCD gKGIDHCPKCD = new GKGIDHCPKCD();
		gKGIDHCPKCD.BJGCPDNMHDH = this;
		return gKGIDHCPKCD;
	}

	public static JGHICIBKJBL DLEPKKGLIBK(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.JIFBHEFGBAN(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	protected void AAONMPBACOF(string IMMNMGDBOOD)
	{
		if (PFNHABEHJOF == null)
		{
			UnityEngine.Debug.LogError("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
			return;
		}
		string[] allDependencies = PFNHABEHJOF.GetAllDependencies(IMMNMGDBOOD);
		if (allDependencies.Length != 0)
		{
			for (int i = 0; i < allDependencies.Length; i++)
			{
				allDependencies[i] = MOHMFAPCNLO(allDependencies[i]);
			}
			PMHCHIEIGAF.Add(IMMNMGDBOOD, allDependencies);
			for (int j = 0; j < allDependencies.Length; j++)
			{
				CILKLGHHKAC(allDependencies[j], DOFPDFJICMG: false);
			}
		}
	}

	protected void KFCMHBLJFMN(string IMMNMGDBOOD, bool CPKPCLACNLF = false)
	{
		string DEBFEDLKOBF;
		KBABIPCFDBL kBABIPCFDBL = IPFKFMGJIAP(IMMNMGDBOOD, out DEBFEDLKOBF);
		if (kBABIPCFDBL != null && --kBABIPCFDBL.IKEANGODNFD == 0)
		{
			kBABIPCFDBL.EDNDKEOJJFH.Unload(CPKPCLACNLF);
			NLCHBEEDEKD.Remove(IMMNMGDBOOD);
		}
	}

	public static JGHICIBKJBL LMHJKJMFHOA(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		return Singleton<AssetBundleManager>.instance.OOMDKENJOLB(IMMNMGDBOOD, KMJGIGDJKMH);
	}

	protected void ACMAKMKJIKD(string IMMNMGDBOOD, bool DOFPDFJICMG = false)
	{
		if (!DOFPDFJICMG)
		{
			IMMNMGDBOOD = PBJEJLGFJCI(IMMNMGDBOOD);
		}
		if (!NDMIKOBHOPB(IMMNMGDBOOD, DOFPDFJICMG) && !DOFPDFJICMG)
		{
			FBGOJENHNMD(IMMNMGDBOOD);
		}
	}

	[SpecialName]
	public string OKBBPMDBLED()
	{
		return GNHKFHJEGKP;
	}

	private JGHICIBKJBL MMOAIOIOPEI(string IMMNMGDBOOD, string KMJGIGDJKMH)
	{
		JGHICIBKJBL jGHICIBKJBL = null;
		OOJGJOJEGHI(IMMNMGDBOOD, DOFPDFJICMG: true);
		jGHICIBKJBL = new DCLICKJHGOA(IMMNMGDBOOD, KMJGIGDJKMH);
		JOICFIOGPMF.Add(jGHICIBKJBL);
		return jGHICIBKJBL;
	}

	public string HMKHECIIBKO()
	{
		if (Application.isEditor)
		{
			return "menu-powerband-health-ico" + Environment.CurrentDirectory.Replace("Error Deserializing JSON for ", "Time-limited Offers");
		}
		if (false)
		{
			return Path.GetDirectoryName(Application.absoluteURL).Replace("Dialog_Displayed", "com/google/android/gms/games/Games") + "WarBucksBoxes";
		}
		if (Application.platform == (RuntimePlatform)(-6) || Application.isConsolePlatform)
		{
			return Application.streamingAssetsPath;
		}
		return "DailyRewardMessage-{0}" + Application.streamingAssetsPath;
	}
}
