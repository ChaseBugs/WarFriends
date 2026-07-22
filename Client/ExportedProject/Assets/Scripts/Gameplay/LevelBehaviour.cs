using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public abstract class LevelBehaviour : Core_BaseScript
{
	public enum UnitType
	{
		Defender,
		AttackerExplosive,
		AttackerShooter,
		AttackerRusher
	}

	[Serializable]
	public class BotProperties
	{
		public int dangerCoeficient;

		public bool useExplosive;
	}

	private sealed class OKGIONBNKMI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool EFBPOCHCGPB;

		internal bool OFICDODLPCK;

		internal UpgradeSlots.UnitUpgrades PFGLIAHPMCK;

		internal LevelBehaviour BJGCPDNMHDH;

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

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return false;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return false;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public OKGIONBNKMI()
		{
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OAFPDIHGJDC()
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

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return false;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
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
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return false;
			case 1u:
			case 2u:
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
				if (EFBPOCHCGPB)
				{
					BJGCPDNMHDH.LoadSounds();
					BJGCPDNMHDH.LoadModel();
				}
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 1u:
			case 2u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}
	}

	private sealed class PNLNJGDJLPC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool OFICDODLPCK;

		internal bool FBCLJFNNJGG;

		internal LevelBehaviour BJGCPDNMHDH;

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
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void EKPOLGNAAOI()
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
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
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
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
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
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public PNLNJGDJLPC()
		{
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
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
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
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

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void IDCJDJMGKFG()
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
				BJGCPDNMHDH.LoadSounds();
				if (OFICDODLPCK)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadMineVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (FBCLJFNNJGG)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.upgradeSlots.LoadOpponentVisualsCoroutineCards());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}
	}

	[Header("Bot")]
	public BotProperties botProperties;

	[Header("Spawning")]
	public int maxGeneratedCount = 1;

	[Header("Name + Description")]
	public string unitDictionaryId;

	[Header("Type")]
	public UnitType unitType;

	[Header("Special Icon")]
	public string abilityIcon;

	[Header("Elite Icon")]
	public string eliteIcon;

	[Header("Army Screen Model Settings")]
	public Vector3 modelPosition;

	public Vector2 modelStartRotation;

	[Header("Card ID reference")]
	public string cardId;

	[Header("Slots")]
	public UpgradeSlots upgradeSlots;

	[Header("Settings")]
	public int guiOrder;

	public bool isSoldier = true;

	public bool isAir;

	public float prepareForBattleIconPositionY = 80f;

	[Header("Perks")]
	public PDNPBLFEPJG perkType;

	public PerkAffects perkAffects;

	public int indexInLevelsManager;

	public int indexInLevelBehaviourManager;

	[SerializeField]
	private string modelPath;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GameObject _003CunitModel_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BehaviourDefinititon _003CbehaviourDefinition_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CunitName_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CunitDescription_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CunitAbilityName_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private string _003CunitBuffName_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _003CunitElitePartsName_003Ek__BackingField;

	public GameObject unitModel
	{
		[CompilerGenerated]
		get
		{
			return _003CunitModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CunitModel_003Ek__BackingField = value;
		}
	}

	public string unitTypeName => GameVariables.NAKDNAEPGOF[unitType].Value1;

	public string unitTypeNameHUD => Localization.Localize(GameVariables.NAKDNAEPGOF[unitType].Value4);

	public string unitTypeIcon => GameVariables.NAKDNAEPGOF[unitType].Value2;

	public string unitTypeDescription => GameVariables.NAKDNAEPGOF[unitType].Value3;

	public int dangerCoef
	{
		get
		{
			if (upgradeSlots != null && upgradeSlots.armyUpgradesRow != null && upgradeSlots.armyUpgradesRow.DANGERCOEFICIENT > 0)
			{
				return upgradeSlots.armyUpgradesRow.DANGERCOEFICIENT;
			}
			return botProperties.dangerCoeficient;
		}
	}

	public int totalPower => Singleton<GameController>.instance.mainController.GetUnitPower(this);

	public float coolDown
	{
		get
		{
			if (upgradeSlots != null && upgradeSlots.armyUpgradesRow != null)
			{
				return upgradeSlots.coolDown;
			}
			return 0f;
		}
	}

	public BehaviourDefinititon behaviourDefinition
	{
		[CompilerGenerated]
		get
		{
			return _003CbehaviourDefinition_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CbehaviourDefinition_003Ek__BackingField = value;
		}
	}

	public bool hasCardVariant => upgradeSlots.excel.GetRowIndex("CARDS_MIN") > 0 && !string.IsNullOrEmpty(cardId);

	public string unitName
	{
		[CompilerGenerated]
		get
		{
			return _003CunitName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CunitName_003Ek__BackingField = value;
		}
	}

	public string unitDescription
	{
		[CompilerGenerated]
		get
		{
			return _003CunitDescription_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CunitDescription_003Ek__BackingField = value;
		}
	}

	public string unitAbilityName
	{
		[CompilerGenerated]
		get
		{
			return _003CunitAbilityName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CunitAbilityName_003Ek__BackingField = value;
		}
	}

	public string unitBuffName
	{
		[CompilerGenerated]
		get
		{
			return _003CunitBuffName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CunitBuffName_003Ek__BackingField = value;
		}
	}

	public string unitElitePartsName
	{
		[CompilerGenerated]
		get
		{
			return _003CunitElitePartsName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CunitElitePartsName_003Ek__BackingField = value;
		}
	}

	public LevelBehaviour unitNeededForPromotion
	{
		get
		{
			int num = upgradeSlots.actualTier + 1;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.unitType == unitType && behaviour.upgradeSlots.startTier == num)
				{
					return behaviour;
				}
			}
			return null;
		}
	}

	public abstract BehaviourDefinititon baseBehaviourDefinititon { get; }

	public string GetAbilityDescriptionWithColours(string startingColour)
	{
		string text = Colours.stringWhite + upgradeSlots.upgradeSlotSpecial.abilityValue + startingColour;
		return Localization.LocalizeFormat(unitDictionaryId + "-ABILITYMAXDESC", text, upgradeSlots.upgradeSlotSpecial.abilityMaxValue, upgradeSlots.upgradeSlotSpecial.abilityStartValue);
	}

	public string GetBuffDescriptionWithColours(string startingColour)
	{
		string text = Colours.stringWhite + upgradeSlots.upgradeSlotElite.buffValue + startingColour;
		return Localization.LocalizeFormat(unitDictionaryId + "-BUFFMAXDESC", text, upgradeSlots.upgradeSlotElite.buffMaxValue, upgradeSlots.upgradeSlotElite.buffStartValue);
	}

	public virtual bool CanBeSpawned(GHPGNELIDBM f, int numberOfEnemies)
	{
		return true;
	}

	public virtual void Init(AIObject aiObject)
	{
	}

	public virtual void PresetOnStart()
	{
		upgradeSlots.owner = this;
	}

	protected virtual void Update()
	{
	}

	private void LoadModel()
	{
		if (unitModel == null && !string.IsNullOrEmpty(modelPath))
		{
			unitModel = Resources.Load<GameObject>(modelPath);
		}
	}

	[DebuggerHidden]
	public virtual IEnumerator PrepareVisualsForGameCoroutine(UpgradeSlots.UnitUpgrades unitUpgrades, bool bought, bool mine, bool unloadWeapon = false)
	{
		OKGIONBNKMI oKGIONBNKMI = new OKGIONBNKMI();
		oKGIONBNKMI.EFBPOCHCGPB = bought;
		oKGIONBNKMI.OFICDODLPCK = mine;
		oKGIONBNKMI.PFGLIAHPMCK = unitUpgrades;
		oKGIONBNKMI.BJGCPDNMHDH = this;
		return oKGIONBNKMI;
	}

	[DebuggerHidden]
	public virtual IEnumerator PrepareVisualsForCardCoroutine(bool mine, bool opponent)
	{
		PNLNJGDJLPC pNLNJGDJLPC = new PNLNJGDJLPC();
		pNLNJGDJLPC.OFICDODLPCK = mine;
		pNLNJGDJLPC.FBCLJFNNJGG = opponent;
		pNLNJGDJLPC.BJGCPDNMHDH = this;
		return pNLNJGDJLPC;
	}

	public void Clear()
	{
		unitModel = null;
	}

	private void LoadSounds()
	{
		foreach (HINJJOAJAOA unitSound in upgradeSlots.unitSounds)
		{
			Singleton<SoundsManager3D>.instance.UseSound(unitSound);
		}
	}

	public virtual void Copy(AIObject to)
	{
		to.ACLDFHJKBLI = to.gameObject.LLCJIIJJAFP(this);
	}

	public virtual void ReSync()
	{
	}

	public virtual void Unload()
	{
		if (unitModel != null)
		{
			MeshFilter[] componentsInChildren = unitModel.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				Resources.UnloadAsset(meshFilter.sharedMesh);
			}
		}
		upgradeSlots.UnloadVisuals();
		unitModel = null;
	}

	public virtual void DestroyBehaviour()
	{
	}

	public FCLADBGKCIA MultipleCurrentPerkForUnit(LevelBehaviour behaviour, UnitUpgradeDefinition def, FCLADBGKCIA currentPerk, PDNPBLFEPJG type)
	{
		if (def.isEquipped && def.unitUpgrades.isElite && PerkAffectBehaviour(behaviour) && type == perkType)
		{
			return upgradeSlots.PerkImplementation(def, currentPerk);
		}
		return currentPerk;
	}

	private bool PerkAffectBehaviour(Behaviour behaviour)
	{
		return GKPNDPLOIJC.NBKENFKJIBP(perkAffects).Contains(behaviour.GetType());
	}

	public void SetUpEliteIcon(UISprite eliteSprite, UISprite buffSprite, float multiplier = 0f)
	{
		eliteSprite.spriteName = eliteIcon;
		buffSprite.spriteName = ((perkType != PDNPBLFEPJG.Buff) ? "game-elite-debuff1" : "game-elite-buff1");
		if (multiplier > 0f)
		{
			eliteSprite.MakePixelPerfect();
			eliteSprite.transform.localScale = eliteSprite.transform.localScale.MultiplyXY(multiplier);
			buffSprite.MakePixelPerfect();
			buffSprite.transform.localScale = buffSprite.transform.localScale.MultiplyXY(multiplier);
			float y = eliteSprite.transform.localPosition.y;
			buffSprite.transform.localPosition = buffSprite.transform.localPosition.ReplaceY(y - multiplier * 25f);
		}
	}
}
