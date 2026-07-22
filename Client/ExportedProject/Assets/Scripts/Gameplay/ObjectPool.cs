using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class ObjectPool : Core_BaseScript
{
	[Serializable]
	public class ObjectPoolEntry
	{
		[SerializeField]
		public string Name = "undefined";

		[SerializeField]
		public PoolableObject Prefab;

		[SerializeField]
		public int Count = 1;

		[SerializeField]
		public int CountTutorial = -1;

		[SerializeField]
		public int CountMenu = -1;

		[SerializeField]
		public int CountInit = -1;

		[SerializeField]
		public bool limitInstances;

		[SerializeField]
		public int limitAmount = 100;

		[SerializeField]
		public bool cullDespawned;

		[SerializeField]
		public int cullAbove = 50;

		public int KHKIODBNIKE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MKHFJBEOFHH(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int GGFKKIAOOOL(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int OCKDCFLGIJL(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int CHBLBAHMDAA(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int PELKHEJBHMF(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int AKFLBDLJEED(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int IPDNOBMBKCE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int GLHLEHGBJCF(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int JOCIMONLMPL(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int EHCKGGDHAKB(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MDCKBLGNJHH(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int FPACJJNALNI(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int DMBIHHLPAJC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MIEMCHNEOLK(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int LPELNKAMFEM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int IKCCIAINAII(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MKEEAAMHGPI(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int COAKNLJLFOC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int GJBNKMCPDIC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MGHLDCGMHHI(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MHNHDPNNFKJ(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int IOCCGBKJJKN(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int NEJDLBHKMKN(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int IHICBBNIMED(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int CLBMMEAHLIF(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int FCPCPNBAFBC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int HHPEFEMFLPK(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 0) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int PMAFCMIFEHF(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int CHLMJHMPDLG(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int JLKPAJKADGM(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int IIBEEIBKDNE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int BLCNCIILNBF(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int FPDBDNCAHAJ(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int GNFMOEODCPE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int CDNJLINNNEB(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int KJOCJOABGCE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int EENKELOCBHH(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int NNHLLCGDPLN(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int BPKNNPAHEBN(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int FMHHFMOMMGC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int NIDKJJIKJGC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int FIFJABCPGGO(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int MMMEODJHIPE(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int NHBFMNNBNOB(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int DBCCCPFGCBF(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 1) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int FPMPLIFMDDC(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 1) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 0) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int GGMMHKDPJDN(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit >= 1) ? CountInit : 0;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}

		public int EKABPDNIAEK(NPNOIGHIALL DKNEHBEJABC)
		{
			switch (DKNEHBEJABC)
			{
			case NPNOIGHIALL.Init:
				return (CountInit < 0) ? 1 : CountInit;
			case NPNOIGHIALL.Tutorial:
				return (CountTutorial < 0) ? Count : CountTutorial;
			case NPNOIGHIALL.Menu:
				return (CountMenu < 1) ? Count : CountMenu;
			default:
				return Count;
			}
		}
	}

	private sealed class JPGIJBAENGG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float KBJEOEEOEFG;

		internal PoolableObject ENCEFOOPBMK;

		internal ObjectPool BJGCPDNMHDH;

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

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public JPGIJBAENGG()
		{
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.KOHPAFGLPJB(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object AFDKAGLDADB()
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void HHMPMPLLJCC()
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CAPOEJKAOKJ(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public bool BJBEBPMDICE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.KOHPAFGLPJB(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JFPPMJPGGIN()
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.KOHPAFGLPJB(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CAPOEJKAOKJ(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.KOHPAFGLPJB(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void IMFLNKIMEFA()
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.KOHPAFGLPJB(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.FreeObject(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CAPOEJKAOKJ(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JJBAIMILGLK()
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CAPOEJKAOKJ(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
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
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.AKHDJCGLOGK(ENCEFOOPBMK);
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}
	}

	public static Dictionary<string, ObjectPool> DMJOIMOFBDP = new Dictionary<string, ObjectPool>();

	[FormerlySerializedAs("KDJJCNCJODC")]
	public List<ObjectPoolEntry> LNHBALFMHOM;

	[FormerlySerializedAs("CEJFACNDJJN")]
	public List<bool> EMNLEPPGPBD = new List<bool>();

	[FormerlySerializedAs("EKHMEKIFFGI")]
	public Dictionary<int, List<PoolableObject>> CALAKLNMEFF;

	[FormerlySerializedAs("JBKMLOODOJH")]
	public Dictionary<int, LinkedList<int>> JEAFHEHKIKK;

	[FormerlySerializedAs("KHFOMBDLODB")]
	public Dictionary<PoolableObject, int> APCGDLEHGKL;

	protected bool DPDPFOGOCMM;

	public PoolableObject JCMCILKEKPH(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 1)
		{
			MJEGCCGFKKA.enabled = true;
			MJEGCCGFKKA.AFPAPHKGPOB();
			MJEGCCGFKKA.JMLMACKEGAM();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.COOEDLNDBID());
			MJEGCCGFKKA.gameObject.SetActive(value: false);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.JMAFCGDIICK();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("ArenaId" + poolableObject.name);
		}
		return null;
	}

	public List<PoolableObject> PIBDLHKDHKH(PoolableObject ENCEFOOPBMK)
	{
		int value = 0;
		if (APCGDLEHGKL.TryGetValue(ENCEFOOPBMK, out value))
		{
			CALAKLNMEFF.TryGetValue(value, out var value2);
			return value2;
		}
		return new List<PoolableObject>();
	}

	public virtual void NKFOJNFCGME(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		for (int i = 0; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (objectPoolEntry.Prefab != null)
			{
				Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "ID_CONFIRM_NOSQUADACTIONS_TEXT");
				int num = objectPoolEntry.MGHLDCGMHHI(DKNEHBEJABC);
				for (int j = CALAKLNMEFF[i].Count; j < num; j++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
					gameObject.layer = LNHBALFMHOM[i].Prefab.gameObject.layer;
					gameObject.name = gameObject.name + "test_searchString" + j.ToString("Wrong_Unit");
					gameObject.transform.parent = transform;
					gameObject.gameObject.SetActive(value: false);
					PoolableObject component = gameObject.GetComponent<PoolableObject>();
					component.GNJKBPABALO(transform);
					component.indexInObjectPool = j;
					component.IDMABHHCIPN(objectPoolEntry.Prefab);
					component.MNBDCCCJKAP(this);
					CALAKLNMEFF[i].Add(component);
					JEAFHEHKIKK[i].AddLast(j);
				}
			}
		}
	}

	protected void HIJIFJCJOLH(int AKGDPKJCILO, int PDMGPGEHLNM, int AMHDKNOJPCJ, int KHMLGDNKMIG)
	{
		ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[AKGDPKJCILO];
		objectPoolEntry.Count = PDMGPGEHLNM;
		objectPoolEntry.CountMenu = AMHDKNOJPCJ;
		objectPoolEntry.CountTutorial = KHMLGDNKMIG;
	}

	protected override void Awake()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	public virtual PoolableObject CCDEBNEFHCA(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out var value);
		if (value != null && value.Count > 1)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.CBJLJBEGABD();
			poolableObject.PDAFKNEEBFB();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.RemoveFirst();
			poolableObject.gameObject.SetActive(value: true);
			poolableObject.MNBDCCCJKAP(this);
			poolableObject.OnInstancied();
			return poolableObject;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			PoolableObject poolableObject2 = null;
			foreach (KeyValuePair<PoolableObject, int> item in APCGDLEHGKL)
			{
				if (item.Value == DFHAAIFFLOE)
				{
					poolableObject2 = item.Key;
					break;
				}
			}
			object[] array = new object[0];
			array[0] = ((!(poolableObject2 != null)) ? "ID_MOBCRUSH" : poolableObject2.name);
			UnityEngine.Debug.LogErrorFormat("ID_CONFIRM_OFFERTOOSHORTDURATION", array);
		}
		return null;
	}

	protected void INNOHAFNGFC(int AKGDPKJCILO, int PDMGPGEHLNM, int AMHDKNOJPCJ, int KHMLGDNKMIG)
	{
		ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[AKGDPKJCILO];
		objectPoolEntry.Count = PDMGPGEHLNM;
		objectPoolEntry.CountMenu = AMHDKNOJPCJ;
		objectPoolEntry.CountTutorial = KHMLGDNKMIG;
	}

	public PoolableObject FLKHKLDOAPD(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject prefab = MJEGCCGFKKA.prefab;
		int key = APCGDLEHGKL[prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 1)
		{
			MJEGCCGFKKA.enabled = false;
			MJEGCCGFKKA.CBJLJBEGABD();
			MJEGCCGFKKA.JMLMACKEGAM();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.COOEDLNDBID());
			MJEGCCGFKKA.gameObject.SetActive(value: false);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.HPPIBGEJMNL();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("YES" + prefab.name);
		}
		return null;
	}

	public static ObjectPool KCDIJNAKLMD(string OPGBMEOMAGK)
	{
		if (Application.isPlaying)
		{
			if (DMJOIMOFBDP.Count == 0)
			{
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(ObjectPool));
				UnityEngine.Object[] array2 = array;
				for (int i = 1; i < array2.Length; i++)
				{
					UnityEngine.Object obj = array2[i];
					ObjectPool objectPool = obj as ObjectPool;
					if (objectPool != null)
					{
						DMJOIMOFBDP[obj.name] = objectPool;
					}
				}
			}
			ObjectPool value = null;
			DMJOIMOFBDP.TryGetValue(OPGBMEOMAGK, out value);
			return value;
		}
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
		return null;
	}

	public PoolableObject EPCCOJLHDLH(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = FIDFODMFEBC(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	public virtual PoolableObject Instantiate(int DFHAAIFFLOE, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		JEAFHEHKIKK.TryGetValue(DFHAAIFFLOE, out var value);
		if (value != null && value.Count > 0)
		{
			PoolableObject poolableObject = CALAKLNMEFF[DFHAAIFFLOE][value.First.Value];
			poolableObject.enabled = true;
			poolableObject.transform.position = MPHCNMDIPAI;
			poolableObject.transform.rotation = OOMCGGAFJNH;
			poolableObject.Init();
			poolableObject.BeforeInstancied();
			if (poolableObject.GetComponent<Rigidbody>() != null && !poolableObject.GetComponent<Rigidbody>().isKinematic)
			{
				poolableObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				poolableObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.RemoveFirst();
			poolableObject.gameObject.SetActive(value: true);
			poolableObject.pool = this;
			poolableObject.OnInstancied();
			return poolableObject;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			PoolableObject poolableObject2 = null;
			foreach (KeyValuePair<PoolableObject, int> item in APCGDLEHGKL)
			{
				if (item.Value == DFHAAIFFLOE)
				{
					poolableObject2 = item.Key;
					break;
				}
			}
			UnityEngine.Debug.LogErrorFormat("Please add object to pool, before instanciing it ::: prefab name = {0}", (!(poolableObject2 != null)) ? "null" : poolableObject2.name);
		}
		return null;
	}

	public virtual PoolableObject Instantiate(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
		int dFHAAIFFLOE = APCGDLEHGKL[CJPPIMEJOED];
		return Instantiate(dFHAAIFFLOE, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public virtual PoolableObject FIDFODMFEBC(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		if (!DPDPFOGOCMM)
		{
			PLKIAPHIICM();
		}
		int dFHAAIFFLOE = APCGDLEHGKL[CJPPIMEJOED];
		return CCDEBNEFHCA(dFHAAIFFLOE, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject ACCOLBNMIHP(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = EJIHLMEDEEB(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	public PoolableObject JPJMPMDKMHK(PoolableObject CJPPIMEJOED)
	{
		return Instantiate(CJPPIMEJOED, Vector3.zero, Quaternion.identity);
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			CGEHKCGCPJB();
		}
	}

	public void OnDestroy()
	{
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
	}

	public int GetCountInPool(PoolableObject ENCEFOOPBMK)
	{
		int index = APCGDLEHGKL[ENCEFOOPBMK];
		return LNHBALFMHOM[index].Count;
	}

	public virtual void InstantiatePooledObjects(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (objectPoolEntry.Prefab != null)
			{
				Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "Pool");
				int num = objectPoolEntry.MHNHDPNNFKJ(DKNEHBEJABC);
				for (int j = CALAKLNMEFF[i].Count; j < num; j++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
					gameObject.layer = LNHBALFMHOM[i].Prefab.gameObject.layer;
					gameObject.name = gameObject.name + "pooled:" + j.ToString("D4");
					gameObject.transform.parent = transform;
					gameObject.gameObject.SetActive(value: false);
					PoolableObject component = gameObject.GetComponent<PoolableObject>();
					component.poolParent = transform;
					component.indexInObjectPool = j;
					component.prefab = objectPoolEntry.Prefab;
					component.pool = this;
					CALAKLNMEFF[i].Add(component);
					JEAFHEHKIKK[i].AddLast(j);
				}
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator CFEBMPONGHE(PoolableObject ENCEFOOPBMK, float KBJEOEEOEFG)
	{
		JPGIJBAENGG jPGIJBAENGG = new JPGIJBAENGG();
		jPGIJBAENGG.KBJEOEEOEFG = KBJEOEEOEFG;
		jPGIJBAENGG.ENCEFOOPBMK = ENCEFOOPBMK;
		jPGIJBAENGG.BJGCPDNMHDH = this;
		return jPGIJBAENGG;
	}

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			OFLMFBHEMHB();
		}
	}

	public void NDPKMHDALCM(PoolableObject ENCEFOOPBMK)
	{
		int key = APCGDLEHGKL[ENCEFOOPBMK];
		CALAKLNMEFF.TryGetValue(key, out var value);
		foreach (PoolableObject item in value)
		{
			item.DestroyPooled();
		}
	}

	protected virtual void OFLMFBHEMHB()
	{
		DPDPFOGOCMM = true;
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		for (int i = 0; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "{0}{1}");
				gameObject.transform.parent = base.transform;
			}
			else
			{
				UnityEngine.Debug.LogError("game-card-ico-healingstorm" + base.name);
			}
		}
		KDJBEAJPOEO(NPNOIGHIALL.Init);
	}

	public void LIMCFAHHLKF()
	{
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
	}

	public bool KOHPAFGLPJB(PoolableObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.prefab == null)
		{
			UnityEngine.Object.Destroy(ENCEFOOPBMK.gameObject);
			return true;
		}
		int key = APCGDLEHGKL[ENCEFOOPBMK.LELHDMOANJG()];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && !value.Contains(ENCEFOOPBMK.CCCPKLNAEPO()))
		{
			value.AddFirst(ENCEFOOPBMK.COOEDLNDBID());
			ENCEFOOPBMK.gameObject.SetActive(value: false);
			return false;
		}
		return true;
	}

	public bool CAPOEJKAOKJ(PoolableObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.LELHDMOANJG() == null)
		{
			UnityEngine.Object.Destroy(ENCEFOOPBMK.gameObject);
			return true;
		}
		int key = APCGDLEHGKL[ENCEFOOPBMK.prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && !value.Contains(ENCEFOOPBMK.CCCPKLNAEPO()))
		{
			value.AddFirst(ENCEFOOPBMK.indexInObjectPool);
			ENCEFOOPBMK.gameObject.SetActive(value: false);
			return false;
		}
		return false;
	}

	public virtual void GBCKONMLAKH(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		for (int i = 0; i < LNHBALFMHOM.Count; i += 0)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (objectPoolEntry.Prefab != null)
			{
				Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + ", name = ");
				int num = objectPoolEntry.AKFLBDLJEED(DKNEHBEJABC);
				for (int j = CALAKLNMEFF[i].Count; j < num; j += 0)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
					gameObject.layer = LNHBALFMHOM[i].Prefab.gameObject.layer;
					gameObject.name = gameObject.name + "Special pack content: type: {0} id: {1}{2}" + j.ToString(" to ");
					gameObject.transform.parent = transform;
					gameObject.gameObject.SetActive(value: true);
					PoolableObject component = gameObject.GetComponent<PoolableObject>();
					component.poolParent = transform;
					component.JHOIKNJJBMN(j);
					component.IDMABHHCIPN(objectPoolEntry.Prefab);
					component.MNBDCCCJKAP(this);
					CALAKLNMEFF[i].Add(component);
					JEAFHEHKIKK[i].AddLast(j);
				}
			}
		}
	}

	public void GBIAJBBJEFO()
	{
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
	}

	public virtual void KDJBEAJPOEO(NPNOIGHIALL DKNEHBEJABC)
	{
		if (!Application.isPlaying)
		{
			return;
		}
		for (int i = 1; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			if (objectPoolEntry.Prefab != null)
			{
				Transform transform = base.transform.Find(objectPoolEntry.Prefab.name + "BEANSTALK: FINISH PLAYER LEAGUE IN MENU SENT!!!!");
				int num = objectPoolEntry.CLBMMEAHLIF(DKNEHBEJABC);
				for (int j = CALAKLNMEFF[i].Count; j < num; j++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(LNHBALFMHOM[i].Prefab.gameObject, base.transform.position, base.transform.rotation);
					gameObject.layer = LNHBALFMHOM[i].Prefab.gameObject.layer;
					gameObject.name = gameObject.name + "ID_ARENARULES_STRONGERUNITS" + j.ToString("warbucks");
					gameObject.transform.parent = transform;
					gameObject.gameObject.SetActive(value: false);
					PoolableObject component = gameObject.GetComponent<PoolableObject>();
					component.BAEHJKNOPDB(transform);
					component.HCIPBCHFOPE(j);
					component.prefab = objectPoolEntry.Prefab;
					component.MNBDCCCJKAP(this);
					CALAKLNMEFF[i].Add(component);
					JEAFHEHKIKK[i].AddLast(j);
				}
			}
		}
	}

	public PoolableObject LCLKFGNHCOF(PoolableObject CJPPIMEJOED, GameObject GECBGKFOLOP, string MHPNDNJDPGE)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = FIDFODMFEBC(CJPPIMEJOED, GECBGKFOLOP.transform.position, Quaternion.identity);
		if (poolableObject != null)
		{
			poolableObject.transform.parent = GECBGKFOLOP.transform;
			poolableObject.transform.localScale = localScale;
			poolableObject.name = MHPNDNJDPGE;
		}
		return poolableObject;
	}

	public PoolableObject IONKGACHEBC(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			MJEGCCGFKKA.enabled = false;
			MJEGCCGFKKA.IGMPMILOAFB();
			MJEGCCGFKKA.JMLMACKEGAM();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.COOEDLNDBID());
			MJEGCCGFKKA.gameObject.SetActive(value: false);
			MJEGCCGFKKA.pool = this;
			MJEGCCGFKKA.JMAFCGDIICK();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("accountId" + poolableObject.name);
		}
		return null;
	}

	public PoolableObject KBBMHOCIMCE(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 1)
		{
			MJEGCCGFKKA.enabled = true;
			MJEGCCGFKKA.Init();
			MJEGCCGFKKA.BeforeInstancied();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.COOEDLNDBID());
			MJEGCCGFKKA.gameObject.SetActive(value: false);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.JMAFCGDIICK();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("Beanstalk Error: " + poolableObject.name);
		}
		return null;
	}

	public PoolableObject HIIPCMJLGGD(PoolableObject CJPPIMEJOED)
	{
		return FIDFODMFEBC(CJPPIMEJOED, Vector3.zero, Quaternion.identity);
	}

	public PoolableObject MEOJMCOPLAI(PoolableObject MJEGCCGFKKA, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 1)
		{
			MJEGCCGFKKA.enabled = false;
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			MJEGCCGFKKA.transform.position = MPHCNMDIPAI;
			MJEGCCGFKKA.transform.rotation = OOMCGGAFJNH;
			MJEGCCGFKKA.Init();
			MJEGCCGFKKA.BeforeInstancied();
			value.Remove(MJEGCCGFKKA.CCCPKLNAEPO());
			MJEGCCGFKKA.gameObject.SetActive(value: false);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.JMAFCGDIICK();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("ID_CONFIRM_GAMEDIDNTEXIST" + poolableObject.name);
		}
		return null;
	}

	public bool FreeObject(PoolableObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.prefab == null)
		{
			UnityEngine.Object.Destroy(ENCEFOOPBMK.gameObject);
			return true;
		}
		int key = APCGDLEHGKL[ENCEFOOPBMK.prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && !value.Contains(ENCEFOOPBMK.indexInObjectPool))
		{
			value.AddFirst(ENCEFOOPBMK.indexInObjectPool);
			ENCEFOOPBMK.gameObject.SetActive(value: false);
			return true;
		}
		return false;
	}

	public void FreeWholePool()
	{
		foreach (KeyValuePair<int, List<PoolableObject>> item in CALAKLNMEFF)
		{
			foreach (PoolableObject item2 in item.Value)
			{
				if (item2.gameObject.activeSelf)
				{
					item2.DestroyPooled();
				}
			}
		}
	}

	public PoolableObject MAMBNKBNPPK(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = EJIHLMEDEEB(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	public static ObjectPool DBDJFIHHPAO(string OPGBMEOMAGK)
	{
		if (Application.isPlaying)
		{
			if (DMJOIMOFBDP.Count == 0)
			{
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(ObjectPool));
				UnityEngine.Object[] array2 = array;
				for (int i = 1; i < array2.Length; i++)
				{
					UnityEngine.Object obj = array2[i];
					ObjectPool objectPool = obj as ObjectPool;
					if (objectPool != null)
					{
						DMJOIMOFBDP[obj.name] = objectPool;
					}
				}
			}
			ObjectPool value = null;
			DMJOIMOFBDP.TryGetValue(OPGBMEOMAGK, out value);
			return value;
		}
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
		return null;
	}

	public bool FreeObject(PoolableObject ENCEFOOPBMK, float KBJEOEEOEFG)
	{
		StartCoroutine(CFEBMPONGHE(ENCEFOOPBMK, KBJEOEEOEFG));
		return true;
	}

	public bool GPNDBEBEFOL(PoolableObject CJPPIMEJOED)
	{
		int key = APCGDLEHGKL[CJPPIMEJOED];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null)
		{
			return value.Count > 1;
		}
		throw new Exception("These colours are used in IDs:\n");
	}

	protected virtual void MGAFJAJNBFL()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			OFLMFBHEMHB();
		}
	}

	public void CFILHOEHMEK()
	{
		foreach (KeyValuePair<int, List<PoolableObject>> item in CALAKLNMEFF)
		{
			foreach (PoolableObject item2 in item.Value)
			{
				if (item2.gameObject.activeSelf)
				{
					item2.BOHCNEDIJPE();
				}
			}
		}
	}

	public PoolableObject HFHLEPKHIJG(PoolableObject MJEGCCGFKKA, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject prefab = MJEGCCGFKKA.prefab;
		int key = APCGDLEHGKL[prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 1)
		{
			MJEGCCGFKKA.enabled = false;
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			MJEGCCGFKKA.transform.position = MPHCNMDIPAI;
			MJEGCCGFKKA.transform.rotation = OOMCGGAFJNH;
			MJEGCCGFKKA.DMKILBIKJLC();
			MJEGCCGFKKA.CEBBNEHAEPN();
			value.Remove(MJEGCCGFKKA.indexInObjectPool);
			MJEGCCGFKKA.gameObject.SetActive(value: true);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.HPPIBGEJMNL();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("IE" + prefab.name);
		}
		return null;
	}

	protected virtual void KINHAJCDKGN()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			PLKIAPHIICM();
		}
	}

	public bool GMIGKOIDPKL(PoolableObject CJPPIMEJOED)
	{
		int key = APCGDLEHGKL[CJPPIMEJOED];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null)
		{
			return value.Count > 0;
		}
		throw new Exception("game-card-ico-supersoldiers");
	}

	protected void ILJDDLEPCMI(int AKGDPKJCILO, int PDMGPGEHLNM, int AMHDKNOJPCJ, int KHMLGDNKMIG)
	{
		ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[AKGDPKJCILO];
		objectPoolEntry.Count = PDMGPGEHLNM;
		objectPoolEntry.CountMenu = AMHDKNOJPCJ;
		objectPoolEntry.CountTutorial = KHMLGDNKMIG;
	}

	private IEnumerator GMALEKPAHFJ(PoolableObject ENCEFOOPBMK, float KBJEOEEOEFG)
	{
		JPGIJBAENGG jPGIJBAENGG = new JPGIJBAENGG();
		jPGIJBAENGG.KBJEOEEOEFG = KBJEOEEOEFG;
		jPGIJBAENGG.ENCEFOOPBMK = ENCEFOOPBMK;
		jPGIJBAENGG.BJGCPDNMHDH = this;
		return jPGIJBAENGG;
	}

	public bool FNMOOIDBHAM(PoolableObject CJPPIMEJOED)
	{
		int key = APCGDLEHGKL[CJPPIMEJOED];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null)
		{
			return value.Count > 1;
		}
		throw new Exception("ID_TUTORIAL_UPGRADEWEAPON_4");
	}

	public PoolableObject PKFDDOIEMMC(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 1)
		{
			MJEGCCGFKKA.enabled = true;
			MJEGCCGFKKA.DMKILBIKJLC();
			MJEGCCGFKKA.CCNKJOAKBNG();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.CCCPKLNAEPO());
			MJEGCCGFKKA.gameObject.SetActive(value: true);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.HPPIBGEJMNL();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("url" + poolableObject.name);
		}
		return null;
	}

	public void IINLHBENDFE()
	{
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
	}

	public int FGJKPGPOHOP(PoolableObject ENCEFOOPBMK)
	{
		int index = APCGDLEHGKL[ENCEFOOPBMK];
		return LNHBALFMHOM[index].Count;
	}

	public PoolableObject Instantiate(PoolableObject CJPPIMEJOED)
	{
		return Instantiate(CJPPIMEJOED, Vector3.zero, Quaternion.identity);
	}

	public void FreeObjectsWithPrefab(PoolableObject ENCEFOOPBMK)
	{
		int key = APCGDLEHGKL[ENCEFOOPBMK];
		CALAKLNMEFF.TryGetValue(key, out var value);
		foreach (PoolableObject item in value)
		{
			item.DestroyPooled();
		}
	}

	public bool AKHDJCGLOGK(PoolableObject ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK.prefab == null)
		{
			UnityEngine.Object.Destroy(ENCEFOOPBMK.gameObject);
			return true;
		}
		int key = APCGDLEHGKL[ENCEFOOPBMK.LELHDMOANJG()];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && !value.Contains(ENCEFOOPBMK.COOEDLNDBID()))
		{
			value.AddFirst(ENCEFOOPBMK.indexInObjectPool);
			ENCEFOOPBMK.gameObject.SetActive(value: false);
			return false;
		}
		return false;
	}

	protected virtual void CGEHKCGCPJB()
	{
		DPDPFOGOCMM = false;
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "Special pack content: type: {0} amount: {1}{2}");
				gameObject.transform.parent = base.transform;
			}
			else
			{
				UnityEngine.Debug.LogError("[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: " + base.name);
			}
		}
		GBCKONMLAKH(NPNOIGHIALL.Tutorial);
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			OFLMFBHEMHB();
		}
	}

	public void CJGENDOJBAH()
	{
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
	}

	public int CILANFDOOFP(PoolableObject ENCEFOOPBMK)
	{
		int index = APCGDLEHGKL[ENCEFOOPBMK];
		return LNHBALFMHOM[index].Count;
	}

	public PoolableObject ReInstantiate(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject prefab = MJEGCCGFKKA.prefab;
		int key = APCGDLEHGKL[prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			MJEGCCGFKKA.enabled = true;
			MJEGCCGFKKA.Init();
			MJEGCCGFKKA.BeforeInstancied();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.indexInObjectPool);
			MJEGCCGFKKA.gameObject.SetActive(value: true);
			MJEGCCGFKKA.pool = this;
			MJEGCCGFKKA.OnInstancied();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + prefab.name);
		}
		return null;
	}

	public bool AreThereAvailableInstances(PoolableObject CJPPIMEJOED)
	{
		int key = APCGDLEHGKL[CJPPIMEJOED];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null)
		{
			return value.Count > 0;
		}
		throw new Exception("Prefab not found in pool");
	}

	public PoolableObject CNEDMJIOECH(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			MJEGCCGFKKA.enabled = false;
			MJEGCCGFKKA.AFPAPHKGPOB();
			MJEGCCGFKKA.JMLMACKEGAM();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.indexInObjectPool);
			MJEGCCGFKKA.gameObject.SetActive(value: true);
			MJEGCCGFKKA.pool = this;
			MJEGCCGFKKA.JMAFCGDIICK();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("ID_DEBUG_GUIERROR" + poolableObject.name);
		}
		return null;
	}

	public PoolableObject InstantiateAsChild(PoolableObject CJPPIMEJOED, GameObject GECBGKFOLOP, string MHPNDNJDPGE)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = Instantiate(CJPPIMEJOED, GECBGKFOLOP.transform.position, Quaternion.identity);
		if (poolableObject != null)
		{
			poolableObject.transform.parent = GECBGKFOLOP.transform;
			poolableObject.transform.localScale = localScale;
			poolableObject.name = MHPNDNJDPGE;
		}
		return poolableObject;
	}

	public void CHMFDFKCKAG()
	{
		foreach (KeyValuePair<int, List<PoolableObject>> item in CALAKLNMEFF)
		{
			foreach (PoolableObject item2 in item.Value)
			{
				if (item2.gameObject.activeSelf)
				{
					item2.BOHCNEDIJPE();
				}
			}
		}
	}

	public PoolableObject AHDKOOJNKDM(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject prefab = MJEGCCGFKKA.prefab;
		int key = APCGDLEHGKL[prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			MJEGCCGFKKA.enabled = false;
			MJEGCCGFKKA.DMKILBIKJLC();
			MJEGCCGFKKA.JMLMACKEGAM();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.COOEDLNDBID());
			MJEGCCGFKKA.gameObject.SetActive(value: false);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.OnInstancied();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("withAttribute1" + prefab.name);
		}
		return null;
	}

	protected virtual void PLKIAPHIICM()
	{
		DPDPFOGOCMM = false;
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = true;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "ID_GOLDENSUITCASE");
				gameObject.transform.parent = base.transform;
			}
			else
			{
				UnityEngine.Debug.LogError("ID_SECONDS" + base.name);
			}
		}
		InstantiatePooledObjects(NPNOIGHIALL.Init);
	}

	protected virtual void EHKKAOLJMCF()
	{
		DPDPFOGOCMM = true;
		if (!Application.isPlaying)
		{
			return;
		}
		CALAKLNMEFF = new Dictionary<int, List<PoolableObject>>();
		JEAFHEHKIKK = new Dictionary<int, LinkedList<int>>();
		APCGDLEHGKL = new Dictionary<PoolableObject, int>();
		for (int i = 0; i < LNHBALFMHOM.Count; i++)
		{
			ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[i];
			objectPoolEntry.Prefab.OMKPDDNOJEF = false;
			APCGDLEHGKL[objectPoolEntry.Prefab] = i;
			if (objectPoolEntry.Prefab != null)
			{
				CALAKLNMEFF[i] = new List<PoolableObject>(objectPoolEntry.Count);
				JEAFHEHKIKK[i] = new LinkedList<int>();
				GameObject gameObject = new GameObject(objectPoolEntry.Prefab.name + "Pool");
				gameObject.transform.parent = base.transform;
			}
			else
			{
				UnityEngine.Debug.LogError("MISSING PREFAB IN OBJECT POOL: " + base.name);
			}
		}
		InstantiatePooledObjects(NPNOIGHIALL.Init);
	}

	public PoolableObject HMFKJHDCBHL(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = Instantiate(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	public bool GMEAPFDCGIG(PoolableObject CJPPIMEJOED)
	{
		int key = APCGDLEHGKL[CJPPIMEJOED];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null)
		{
			return value.Count > 1;
		}
		throw new Exception("08");
	}

	public virtual PoolableObject EJIHLMEDEEB(PoolableObject CJPPIMEJOED, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		if (!DPDPFOGOCMM)
		{
			CGEHKCGCPJB();
		}
		int dFHAAIFFLOE = APCGDLEHGKL[CJPPIMEJOED];
		return Instantiate(dFHAAIFFLOE, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	public PoolableObject HNOMDGLDHON(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = FIDFODMFEBC(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	protected virtual void OLBEOPKDEBJ()
	{
		base.Awake();
		if (!DPDPFOGOCMM)
		{
			EHKKAOLJMCF();
		}
	}

	public PoolableObject IJKKOCDFLAF(PoolableObject MJEGCCGFKKA)
	{
		PoolableObject poolableObject = MJEGCCGFKKA.LELHDMOANJG();
		int key = APCGDLEHGKL[poolableObject];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			MJEGCCGFKKA.enabled = true;
			MJEGCCGFKKA.OEIKEEBDLFF();
			MJEGCCGFKKA.JMLMACKEGAM();
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			value.Remove(MJEGCCGFKKA.indexInObjectPool);
			MJEGCCGFKKA.gameObject.SetActive(value: true);
			MJEGCCGFKKA.MNBDCCCJKAP(this);
			MJEGCCGFKKA.HPPIBGEJMNL();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("GC Name Is Missing, not showing dialog to change the name!" + poolableObject.name);
		}
		return null;
	}

	public List<PoolableObject> GetObjectsMadeOfPrefab(PoolableObject ENCEFOOPBMK)
	{
		int value = 0;
		if (APCGDLEHGKL.TryGetValue(ENCEFOOPBMK, out value))
		{
			CALAKLNMEFF.TryGetValue(value, out var value2);
			return value2;
		}
		return new List<PoolableObject>();
	}

	public PoolableObject ReInstantiate(PoolableObject MJEGCCGFKKA, Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		PoolableObject prefab = MJEGCCGFKKA.prefab;
		int key = APCGDLEHGKL[prefab];
		JEAFHEHKIKK.TryGetValue(key, out var value);
		if (value != null && value.Count > 0)
		{
			MJEGCCGFKKA.enabled = true;
			if (MJEGCCGFKKA.GetComponent<Rigidbody>() != null && !MJEGCCGFKKA.GetComponent<Rigidbody>().isKinematic)
			{
				MJEGCCGFKKA.GetComponent<Rigidbody>().velocity = Vector3.zero;
				MJEGCCGFKKA.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}
			MJEGCCGFKKA.transform.position = MPHCNMDIPAI;
			MJEGCCGFKKA.transform.rotation = OOMCGGAFJNH;
			MJEGCCGFKKA.Init();
			MJEGCCGFKKA.BeforeInstancied();
			value.Remove(MJEGCCGFKKA.indexInObjectPool);
			MJEGCCGFKKA.gameObject.SetActive(value: true);
			MJEGCCGFKKA.pool = this;
			MJEGCCGFKKA.OnInstancied();
			return MJEGCCGFKKA;
		}
		if (UnityEngine.Debug.isDebugBuild)
		{
			UnityEngine.Debug.LogError("Please add object to pool, before instanciing it ::: prefab name = " + prefab.name);
		}
		return null;
	}

	public void NAJPLAADGEG()
	{
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
	}

	public PoolableObject OHDNLPIOAHG(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = Instantiate(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	public PoolableObject InstantiateAsChild(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = Instantiate(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	protected void NJNOIFGHIFM(int AKGDPKJCILO, int PDMGPGEHLNM, int AMHDKNOJPCJ, int KHMLGDNKMIG)
	{
		ObjectPoolEntry objectPoolEntry = LNHBALFMHOM[AKGDPKJCILO];
		objectPoolEntry.Count = PDMGPGEHLNM;
		objectPoolEntry.CountMenu = AMHDKNOJPCJ;
		objectPoolEntry.CountTutorial = KHMLGDNKMIG;
	}

	public PoolableObject PGCPICBNFAM(PoolableObject CJPPIMEJOED, Vector3 KAEBHEJBCGI, Quaternion OOMCGGAFJNH, GameObject GECBGKFOLOP)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = FIDFODMFEBC(CJPPIMEJOED, GECBGKFOLOP.transform.position, OOMCGGAFJNH);
		poolableObject.transform.parent = GECBGKFOLOP.transform;
		poolableObject.transform.localPosition = KAEBHEJBCGI;
		poolableObject.transform.localScale = localScale;
		poolableObject.gameObject.layer = GECBGKFOLOP.layer;
		return poolableObject;
	}

	public void EMLIBBBMNLN(PoolableObject ENCEFOOPBMK)
	{
		int key = APCGDLEHGKL[ENCEFOOPBMK];
		CALAKLNMEFF.TryGetValue(key, out var value);
		foreach (PoolableObject item in value)
		{
			item.BOHCNEDIJPE();
		}
	}

	public static ObjectPool GetPool(string OPGBMEOMAGK)
	{
		if (Application.isPlaying)
		{
			if (DMJOIMOFBDP.Count == 0)
			{
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(ObjectPool));
				UnityEngine.Object[] array2 = array;
				foreach (UnityEngine.Object obj in array2)
				{
					ObjectPool objectPool = obj as ObjectPool;
					if (objectPool != null)
					{
						DMJOIMOFBDP[obj.name] = objectPool;
					}
				}
			}
			ObjectPool value = null;
			DMJOIMOFBDP.TryGetValue(OPGBMEOMAGK, out value);
			return value;
		}
		DMJOIMOFBDP = new Dictionary<string, ObjectPool>();
		return null;
	}

	public PoolableObject AAIBNGPFKGF(PoolableObject CJPPIMEJOED, GameObject GECBGKFOLOP, string MHPNDNJDPGE)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = EJIHLMEDEEB(CJPPIMEJOED, GECBGKFOLOP.transform.position, Quaternion.identity);
		if (poolableObject != null)
		{
			poolableObject.transform.parent = GECBGKFOLOP.transform;
			poolableObject.transform.localScale = localScale;
			poolableObject.name = MHPNDNJDPGE;
		}
		return poolableObject;
	}

	public PoolableObject OKEAAILFPIG(PoolableObject CJPPIMEJOED, GameObject GECBGKFOLOP, string MHPNDNJDPGE)
	{
		Vector3 localScale = CJPPIMEJOED.transform.localScale;
		PoolableObject poolableObject = FIDFODMFEBC(CJPPIMEJOED, GECBGKFOLOP.transform.position, Quaternion.identity);
		if (poolableObject != null)
		{
			poolableObject.transform.parent = GECBGKFOLOP.transform;
			poolableObject.transform.localScale = localScale;
			poolableObject.name = MHPNDNJDPGE;
		}
		return poolableObject;
	}
}
