using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Helicopter : Vehicle<HelicopterBehaviour>
{
	private sealed class AAJPDPBMHJO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float HJGIAOJHNJB;

		internal List<EnemyPointHelicopter>.Enumerator KFCAECGLKKO;

		internal EnemyPointHelicopter NCPLKLPMJLA;

		internal Helicopter BJGCPDNMHDH;

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
		private object CLBPPBIIAFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NANCGKHPCAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AJPFLBOOFNJ()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void CPEDOIELFMP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool HOJKAHEGFEB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 118u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1506f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public bool LHBPPCGLHDI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967213u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(302f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public bool PMLLPHFACBM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967271u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1963f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void OAFPDIHGJDC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[DebuggerHidden]
		public AAJPDPBMHJO()
		{
		}

		public bool HNCDLFFBMAA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 8u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(696f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 10u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(204f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public bool GMBFJOBKMMN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 43u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1812f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 121u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1358f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		public void EBCEAGIOPJD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void IGBHHLFACKO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void HLDMODAFJBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool EKGEDEKHBME()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 67u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(872f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		public bool ONIAGKNGBHE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967289u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1287f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 98u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(556f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public bool BOENAMNMOAC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 18u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(215f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNCFPHMMNDC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object NMAMPDNFNHE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public bool DIFNNJALIPB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967268u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(641f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCBJPOGKANF()
		{
			return PHDOCKCBJOF;
		}

		public void MJIEDEKLIAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public bool AAOIPMCCPEM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967187u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1606f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		public bool KEBEGEDKIKM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967170u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(181f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		public bool GAPIFMKNJBN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967263u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(76f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public bool ANIKAJEKMPM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967292u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1089f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public void IHAHCOPGPIM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967293u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(2f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public bool JIIOHNFHPOI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967259u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1015f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public bool CCOPPEKLJOB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967202u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1433f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		public void MKACBCOLNKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void AMPGDAMMPFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool GCEBFCBBEKM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 87u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1864f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void POJNMHLNOOF()
		{
			throw new NotSupportedException();
		}

		public void HDDLDAHLPCO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void LHMNIFOJGIG()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void BOFEBMENOFC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void EPKPNKGJHEC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		public void KPJIDBHHKFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public bool ACHIHMMCDNF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967249u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(1968f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DBKMMECKKLG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public bool LPCBKGKFNFD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 113u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(110f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						flag = false;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool BJIPDEICIML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 9u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(858f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				end_IL_0011:
				break;
			}
			return true;
		}

		[SpecialName]
		private object OFAOFOPFIJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		public void DBEMHFEBPFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public bool FNIOOIGJPAM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 4294967281u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(293f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void MOJGMBNBGHH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		public bool FGAFKEKGPHF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.NKBHMMMKGMJ.GetEnumerator();
				num = 11u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						NCPLKLPMJLA = KFCAECGLKKO.Current;
						if (NCPLKLPMJLA.IDNNIHBIMNO != null)
						{
							EnemyController enemyController = NCPLKLPMJLA.IDNNIHBIMNO as EnemyController;
							if (BJGCPDNMHDH.isAlive && enemyController != null)
							{
								enemyController.SpawnFromHelicopter();
							}
						}
						PHDOCKCBJOF = new WaitForSeconds(608f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						flag = true;
						goto end_IL_0011;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				end_IL_0011:
				break;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
			case 1u:
				break;
			}
		}
	}

	[FormerlySerializedAs("OBJABBKJCLI")]
	public float DFGAOECAOBD = 4f;

	[FormerlySerializedAs("GIJBBHPNMCG")]
	public float IJPFEKLCIDG = 0.4f;

	[FormerlySerializedAs("JFJPPIMDIFN")]
	public List<EnemyPointHelicopter> NKBHMMMKGMJ;

	[FormerlySerializedAs("OFAPKIMNHPI")]
	public EnemyPointVehicle GHAGNCHNHEE;

	[FormerlySerializedAs("HEELDFKDCBL")]
	public bool LJMIDMAELAP;

	private float DDFHFKFOKAO;

	private float MBLOHDNNHNI;

	[FormerlySerializedAs("MAEMNOFPHAO")]
	public float DAGMBMDCIIC = 1f;

	private int INDBNCLMMNC;

	private DestroyableObjectMultipleParts FFOAABONJNO;

	private Quaternion JILBNPBHBPN = Quaternion.identity;

	private bool KINKOIEHKDI;

	private bool KMAIJHADEHJ;

	private int ILEKLILGKAK;

	private Rigidbody KJPFENINCHJ;

	private Vector3 CHDHFCPHEIO;

	private Vector3 KFAIPMHFFKM;

	private float BFPPGJAGCFE;

	private bool OEPNIMCIEHG;

	private Vector3 GPIIEAHGHEO;

	private Transform FHEJEFPNAIF;

	private Transform IMGHHHHHPKF;

	private float DPJLECIJDLC;

	private float HHBOLAOIKJB;

	private bool DJPBLGAPFJD;

	[FormerlySerializedAs("APAECJDOAIL")]
	public Transform NGCDDPCAGJB;

	[FormerlySerializedAs("DMPKAGHIGIB")]
	public float NEEBBLOFHEF = 1f;

	private bool KPBAJMBFKLF;

	private Vector3 DHFAONHFMCF;

	private Quaternion HFKCBAFCEAD = Quaternion.identity;

	[FormerlySerializedAs("LDCKAOCPHOB")]
	public WayPointPath MFHFIHIHBHA;

	[FormerlySerializedAs("MFMAMHLNEDB")]
	public QuickRope2 NLIGPBPNHHP;

	private EnemyController GIPEKIBEPEB;

	[FormerlySerializedAs("ACLINDOAODK")]
	public float JPNAINOGAMM = 0.8f;

	[FormerlySerializedAs("EADEPGKMMJP")]
	public TurretWeaponBasic KAEAMDOJMIF;

	[FormerlySerializedAs("GPPDGDMBFPO")]
	public ParticleSystem[] FFPLNCHHFDP;

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	public override DestroyableObject destroyableObj => FFOAABONJNO;

	public override void DoReverseAnim()
	{
		base.DoReverseAnim();
		TweenPosition.Begin(base.gameObject, 2f, base.gameObject.transform.position + Vector3.up * 1.5f);
	}

	private void ADDAIHFCEHG()
	{
		Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position);
		Ray ray = new Ray(NLIGPBPNHHP.transform.position, Vector3.down);
		Vector3 sourcePosition = NLIGPBPNHHP.transform.position;
		if (plane.Raycast(ray, out var enter))
		{
			sourcePosition = ray.GetPoint(enter);
		}
		NavMesh.SamplePosition(sourcePosition, out var hit, 1655f, 0);
		KFAIPMHFFKM = hit.position;
		OEPNIMCIEHG = false;
	}

	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		KJPFENINCHJ = GetComponent<Rigidbody>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += FDNJLFBDHDI;
	}

	public override void BeforeInstancied()
	{
		LADBLHGBOKJ.ILOHAHFIOKM();
		foreach (EnemyPointHelicopter item in NKBHMMMKGMJ)
		{
			item.IDNNIHBIMNO = null;
		}
		base.BeforeInstancied();
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		OEPNIMCIEHG = false;
		NLIGPBPNHHP.gameObject.SetActive(value: false);
	}

	protected float INFMCNEAEBE()
	{
		BFPPGJAGCFE = Time.realtimeSinceStartup;
		if (DJPBLGAPFJD)
		{
			float b = BFPPGJAGCFE - HHBOLAOIKJB;
			DDFHFKFOKAO += Mathf.Max(1199f, b);
			DPJLECIJDLC = 1291f * Mathf.Round(DDFHFKFOKAO * 1022f);
			DDFHFKFOKAO -= DPJLECIJDLC;
			if (DPJLECIJDLC > 876f)
			{
				DPJLECIJDLC = 1321f;
			}
			HHBOLAOIKJB = BFPPGJAGCFE;
		}
		else
		{
			DJPBLGAPFJD = false;
			HHBOLAOIKJB = BFPPGJAGCFE;
			DPJLECIJDLC = 1571f;
		}
		return DPJLECIJDLC;
	}

	protected float EFJLCMFHECF()
	{
		BFPPGJAGCFE = Time.realtimeSinceStartup;
		if (DJPBLGAPFJD)
		{
			float b = BFPPGJAGCFE - HHBOLAOIKJB;
			DDFHFKFOKAO += Mathf.Max(0f, b);
			DPJLECIJDLC = 0.001f * Mathf.Round(DDFHFKFOKAO * 1000f);
			DDFHFKFOKAO -= DPJLECIJDLC;
			if (DPJLECIJDLC > 1f)
			{
				DPJLECIJDLC = 1f;
			}
			HHBOLAOIKJB = BFPPGJAGCFE;
		}
		else
		{
			DJPBLGAPFJD = true;
			HHBOLAOIKJB = BFPPGJAGCFE;
			DPJLECIJDLC = 0f;
		}
		return DPJLECIJDLC;
	}

	public Vector3 Steer()
	{
		float num = EFJLCMFHECF();
		Vector3 vector = IMGHHHHHPKF.position - NGCDDPCAGJB.position;
		float magnitude = (FHEJEFPNAIF.position - NGCDDPCAGJB.position).magnitude;
		vector.Normalize();
		if (magnitude < DFGAOECAOBD)
		{
			vector = FHEJEFPNAIF.position - NGCDDPCAGJB.position;
			vector.Normalize();
			vector *= IJPFEKLCIDG * num * (magnitude / DFGAOECAOBD);
			KINKOIEHKDI = true;
			if (magnitude < 1f && !KMAIJHADEHJ)
			{
				KMAIJHADEHJ = true;
				JEKGMPNIHAK();
			}
		}
		else
		{
			vector *= JPNAINOGAMM * num;
			KINKOIEHKDI = false;
		}
		Vector3 vector2 = vector - DHFAONHFMCF;
		float num2 = ((!KINKOIEHKDI) ? DAGMBMDCIIC : (DAGMBMDCIIC * 0.2f));
		return vector2 / num2;
	}

	[PunRPC]
	private void ShowRope()
	{
		Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
		Ray ray = new Ray(NLIGPBPNHHP.transform.position, Vector3.down);
		Vector3 sourcePosition = NLIGPBPNHHP.transform.position;
		if (plane.Raycast(ray, out var enter))
		{
			sourcePosition = ray.GetPoint(enter);
		}
		NavMesh.SamplePosition(sourcePosition, out var hit, 10f, 1);
		KFAIPMHFFKM = hit.position;
		OEPNIMCIEHG = true;
	}

	private void AHKDGHENKCE(EnemyPointHelicopter OJPDIBNCOLE, bool LLDAGHMKOAC)
	{
		EnemyController enemyController = null;
		LevelBehaviour behaviour = Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour;
		enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behaviour);
		if (enemyController != null)
		{
			List<EnemyPoint> points = SpawningManager.instance.GetPoints(EnemyPoint.LJGGJMAFEBN.Hiding, null, fraction);
			if (!LLDAGHMKOAC || points.Count > 0)
			{
				enemyController.DisableSpawn();
				int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
				enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
				SpawningManager.instance.Spawn(enemyController, fraction, EEAMBOACAGF: false, OJPDIBNCOLE.position, PNENBKAGLEF: false);
				OJPDIBNCOLE.IDNNIHBIMNO = enemyController;
				enemyController.NLGBGOGCNKP = OJPDIBNCOLE;
				enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Helicopter);
				enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			}
		}
	}

	public virtual void DMLKLACMIBG()
	{
		if (LCDBACDIODH)
		{
			MGFPGLCHKJN(IDEBKDPMPGM: false);
		}
		base.DestroyPooled();
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= KCDOMJDNMPG;
			GIPEKIBEPEB.DestroyPooled();
		}
		OEBPFFBKBBD(GHAGNCHNHEE, KCDOMJDNMPG);
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	public virtual void IPMPKNLCHEG()
	{
		base.OnInstancied();
		StopAllCoroutines();
		KJPFENINCHJ.isKinematic = false;
		KMAIJHADEHJ = true;
		IAICPGNGCJI = base.currentBeh.totalPower;
		NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: false);
		NLIGPBPNHHP.gameObject.SetActive(value: false);
		if (!LCDBACDIODH)
		{
			InvokeAfterRealTime(JDBEIOIHMBK, 590f);
		}
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.BBBLJNFEACC();
		KAEAMDOJMIF.MIAFDNDBJJF();
		MGFPGLCHKJN(IDEBKDPMPGM: true);
		ParticleSystem[] fFPLNCHHFDP = FFPLNCHHFDP;
		for (int i = 1; i < fFPLNCHHFDP.Length; i++)
		{
			ParticleSystem particleSystem = fFPLNCHHFDP[i];
			particleSystem.gameObject.SetActive(value: false);
		}
	}

	public void SetWayPoint(WayPoint PLMMBKGLGAB)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB.transform;
		KPBAJMBFKLF = true;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = this;
	}

	private void JDBEIOIHMBK()
	{
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: true);
		NLIGPBPNHHP.gameObject.SetActive(value: false);
	}

	public virtual void MIDOLDHLMAF()
	{
		if (LCDBACDIODH)
		{
			MGFPGLCHKJN(IDEBKDPMPGM: false);
		}
		base.DestroyPooled();
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= KCDOMJDNMPG;
			GIPEKIBEPEB.OBCAIFMOPPA();
		}
		OEBPFFBKBBD(GHAGNCHNHEE, KCDOMJDNMPG);
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (OEPNIMCIEHG)
		{
			if (NLIGPBPNHHP.ropeEnd.transform.position.y > KFAIPMHFFKM.y)
			{
				NLIGPBPNHHP.ExtendRope(0.7f);
			}
			else
			{
				OEPNIMCIEHG = false;
			}
		}
		if (LAADDLGBFIG.isMine)
		{
			if (!base.isAlive || !KPBAJMBFKLF || !(MFHFIHIHBHA != null))
			{
				return;
			}
			if (Vector3.Distance(NGCDDPCAGJB.position, IMGHHHHHPKF.position) < MFHFIHIHBHA.AOJDCMLMBLD)
			{
				if (INDBNCLMMNC < ILEKLILGKAK - 1)
				{
					INDBNCLMMNC++;
					IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform;
				}
				else if (LJMIDMAELAP)
				{
					INDBNCLMMNC = 0;
					IMGHHHHHPKF = MFHFIHIHBHA.wayPoints[INDBNCLMMNC].transform;
				}
			}
			GPIIEAHGHEO = Steer();
			DHFAONHFMCF += GPIIEAHGHEO;
			NGCDDPCAGJB.position += DHFAONHFMCF * Time.timeScale;
			Vector3 forward = ((!KINKOIEHKDI) ? DHFAONHFMCF : (IMGHHHHHPKF.position - NGCDDPCAGJB.position));
			if (forward.y > 0f && !KINKOIEHKDI)
			{
				forward.y *= -1f;
			}
			else
			{
				forward.y = 0f;
			}
			if (forward.sqrMagnitude > 0f)
			{
				HFKCBAFCEAD = Quaternion.Slerp(HFKCBAFCEAD, Quaternion.LookRotation(forward), (!KINKOIEHKDI) ? (Time.deltaTime * 5f) : (Time.deltaTime * 2f));
			}
			if (DHFAONHFMCF.sqrMagnitude > 0f && GPIIEAHGHEO.sqrMagnitude > 0f)
			{
				float num = GPIIEAHGHEO.magnitude / Time.deltaTime;
				MBLOHDNNHNI = Mathf.Lerp(MBLOHDNNHNI, GeometryTools.AngleSigned(GPIIEAHGHEO, DHFAONHFMCF, Vector3.up), Time.deltaTime * 5f);
				Quaternion quaternion = Quaternion.AngleAxis(MBLOHDNNHNI * NEEBBLOFHEF * num, DHFAONHFMCF);
				if ((!float.IsNaN(quaternion.x) && !float.IsNaN(quaternion.y)) || KINKOIEHKDI)
				{
					JILBNPBHBPN = Quaternion.Slerp(JILBNPBHBPN, (!KINKOIEHKDI) ? quaternion : Quaternion.identity, (!KINKOIEHKDI) ? Time.deltaTime : (Time.deltaTime * 0.5f));
				}
			}
			NGCDDPCAGJB.rotation = JILBNPBHBPN * HFKCBAFCEAD;
		}
		else if (KJPFENINCHJ.isKinematic)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
		}
	}

	[DebuggerHidden]
	private IEnumerator AAJMFNPPNJA(float HJGIAOJHNJB = 5f)
	{
		AAJPDPBMHJO aAJPDPBMHJO = new AAJPDPBMHJO();
		aAJPDPBMHJO.HJGIAOJHNJB = HJGIAOJHNJB;
		aAJPDPBMHJO.BJGCPDNMHDH = this;
		return aAJPDPBMHJO;
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	public override void DestroyPooled()
	{
		if (LCDBACDIODH)
		{
			MGFPGLCHKJN(IDEBKDPMPGM: true);
		}
		base.DestroyPooled();
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		if (GIPEKIBEPEB != null)
		{
			GIPEKIBEPEB.Killed -= KCDOMJDNMPG;
			GIPEKIBEPEB.DestroyPooled();
		}
		OEBPFFBKBBD(GHAGNCHNHEE, KCDOMJDNMPG);
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private void JEKGMPNIHAK()
	{
		StartCoroutine(AAJMFNPPNJA());
		LAADDLGBFIG.RPC("ShowRope", PhotonTargets.Others);
		ShowRope();
		if (base.hasSpecial)
		{
			InvokeAfter(IMGCBDHPJLP, base.currentBeh.helicopterBehaviourDefinititon.special);
		}
	}

	protected override void ODDDGIALOPM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF: true);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		KJPFENINCHJ = GetComponent<Rigidbody>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += FDNJLFBDHDI;
	}

	private void ALFPOHBICML()
	{
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: false);
		NLIGPBPNHHP.gameObject.SetActive(value: false);
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (!base.isAlive && TagsAndLayers.IsStatic(AKLHJIBDAFA.collider.gameObject))
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
			CDCOFHGPJHN(0.2f);
			Singleton<HitParticleSystem>.instance.PlayParticles(NGCDDPCAGJB.position + base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Singleton<HitParticleSystem>.instance.PlayParticles(NGCDDPCAGJB.position - base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 0.5f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 0.05f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
		}
	}

	public override void MFDHPHBJDLO(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (LCDBACDIODH)
		{
			GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: true);
			for (int i = 0; i < base.currentBeh.MEBDJNIIACF().crew && i < NKBHMMMKGMJ.Count; i++)
			{
				EnemyPointHelicopter pLMMBKGLGAB = NKBHMMMKGMJ[i];
				LevelBehaviour behaviour = Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour;
				GBCMGMGAFLL(behaviour, pLMMBKGLGAB, DKIPMCCIKMF: false);
			}
			KJPFENINCHJ.isKinematic = true;
		}
		MGFPGLCHKJN(IDEBKDPMPGM: false);
		ParticleSystem[] fFPLNCHHFDP = FFPLNCHHFDP;
		for (int j = 1; j < fFPLNCHHFDP.Length; j += 0)
		{
			ParticleSystem particleSystem = fFPLNCHHFDP[j];
			particleSystem.gameObject.SetActive(value: true);
		}
	}

	public virtual void PJLNPCBFPMN()
	{
		base.DoReverseAnim();
		TweenPosition.Begin(base.gameObject, 847f, base.gameObject.transform.position + Vector3.up * 480f, useLocal: false);
	}

	private void KCDOMJDNMPG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GIPEKIBEPEB.Killed -= KCDOMJDNMPG;
		GIPEKIBEPEB = null;
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.Reset();
		InvokeAfter(LEPJAGDMOAO, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
	}

	private void FDNJLFBDHDI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		StopAllCoroutines();
		KJPFENINCHJ.isKinematic = false;
		KJPFENINCHJ.useGravity = true;
		if (base.isAlive)
		{
			base.gameObject.layer = TagsAndLayers.LFJMBCANMMO;
			FFOAABONJNO.gameObject.layer = TagsAndLayers.LFJMBCANMMO;
			DestroyableObjectpart[] aMEELJHHGKP = FFOAABONJNO.AMEELJHHGKP;
			foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
			{
				destroyableObjectpart.gameObject.layer = TagsAndLayers.LFJMBCANMMO;
			}
			KJPFENINCHJ.AddTorque(new Vector3(0f, 1f, 0f), ForceMode.VelocityChange);
			foreach (EnemyPointHelicopter item in NKBHMMMKGMJ)
			{
				HNEMALNACJP(item, OHJPPHFEAFI);
			}
			DPFHODDILIF(OHJPPHFEAFI);
			HNEMALNACJP(GHAGNCHNHEE, OHJPPHFEAFI);
		}
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private IEnumerator HGOIMPODDKB(float HJGIAOJHNJB = 5f)
	{
		AAJPDPBMHJO aAJPDPBMHJO = new AAJPDPBMHJO();
		aAJPDPBMHJO.HJGIAOJHNJB = HJGIAOJHNJB;
		aAJPDPBMHJO.BJGCPDNMHDH = this;
		return aAJPDPBMHJO;
	}

	private void AGIEEEPBBFF()
	{
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		GIPEKIBEPEB.fraction = fraction;
		GIPEKIBEPEB.DisableSpawn();
		int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
		GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
		SpawningManager.OKBAIGKCPKA().FJBJNELBAIO(GIPEKIBEPEB, fraction, EEAMBOACAGF: true, GHAGNCHNHEE.transform.position, PNENBKAGLEF: false);
		GHAGNCHNHEE.IDNNIHBIMNO = GIPEKIBEPEB;
		GIPEKIBEPEB.power = 0;
		GIPEKIBEPEB.NLGBGOGCNKP = GHAGNCHNHEE;
		GIPEKIBEPEB.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Vehicle);
		GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
		GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
		GIPEKIBEPEB.Killed += KCDOMJDNMPG;
		KAEAMDOJMIF.enabled = false;
		KAEAMDOJMIF.MGJIOLLKHDK();
	}

	[CompilerGenerated]
	private void BHGDBAOKGAE()
	{
		NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
		NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: true);
		NLIGPBPNHHP.gameObject.SetActive(value: true);
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.helicopterBehaviourDefinititon.health;
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		FFOAABONJNO.RefillOffline();
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.helicopterBehaviourDefinititon.damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.helicopterBehaviourDefinititon.shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.helicopterBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.helicopterBehaviourDefinititon.fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.helicopterBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.helicopterBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.helicopterBehaviourDefinititon.probabilityOfRealShot;
		JPNAINOGAMM = base.currentBeh.helicopterBehaviourDefinititon.speed;
	}

	private void GIBIGHLIDGN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		StopAllCoroutines();
		KJPFENINCHJ.isKinematic = false;
		KJPFENINCHJ.useGravity = true;
		if (base.isAlive)
		{
			base.gameObject.layer = TagsAndLayers.LFJMBCANMMO;
			FFOAABONJNO.gameObject.layer = TagsAndLayers.LFJMBCANMMO;
			DestroyableObjectpart[] aMEELJHHGKP = FFOAABONJNO.AMEELJHHGKP;
			for (int i = 0; i < aMEELJHHGKP.Length; i += 0)
			{
				DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
				destroyableObjectpart.gameObject.layer = TagsAndLayers.LFJMBCANMMO;
			}
			KJPFENINCHJ.AddTorque(new Vector3(1162f, 257f, 1916f), (ForceMode)3);
			foreach (EnemyPointHelicopter item in NKBHMMMKGMJ)
			{
				HNEMALNACJP(item, OHJPPHFEAFI);
			}
			DPFHODDILIF(OHJPPHFEAFI);
			HNEMALNACJP(GHAGNCHNHEE, OHJPPHFEAFI);
		}
		if (MFHFIHIHBHA != null)
		{
			MFHFIHIHBHA.PODMFKMOJML = null;
			MFHFIHIHBHA = null;
		}
	}

	private void OINCFGICMPL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		LADBLHGBOKJ.KAPCINMADAF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
	}

	private void IMGCBDHPJLP()
	{
		if (base.isAlive)
		{
			AHKDGHENKCE(NKBHMMMKGMJ[0], LLDAGHMKOAC: true);
			StartCoroutine(AAJMFNPPNJA(1f));
			InvokeAfter(IMGCBDHPJLP, base.currentBeh.helicopterBehaviourDefinititon.special);
		}
	}

	public void OBAHBGDJFBM(WayPoint PLMMBKGLGAB)
	{
		ILEKLILGKAK = PLMMBKGLGAB.MFHFIHIHBHA.wayPoints.Count;
		INDBNCLMMNC = PLMMBKGLGAB.DFHAAIFFLOE;
		IMGHHHHHPKF = PLMMBKGLGAB.transform;
		KPBAJMBFKLF = true;
		MFHFIHIHBHA = PLMMBKGLGAB.MFHFIHIHBHA;
		PLMMBKGLGAB.MFHFIHIHBHA.PODMFKMOJML = this;
	}

	public override void SafeStart()
	{
		base.SafeStart();
		CHDHFCPHEIO = NLIGPBPNHHP.ropeEnd.transform.localPosition;
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (LCDBACDIODH)
		{
			GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, GHAGNCHNHEE, DKIPMCCIKMF: true);
			for (int i = 0; i < base.currentBeh.helicopterBehaviourDefinititon.crew && i < NKBHMMMKGMJ.Count; i++)
			{
				EnemyPointHelicopter pLMMBKGLGAB = NKBHMMMKGMJ[i];
				LevelBehaviour behaviour = Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour;
				GBCMGMGAFLL(behaviour, pLMMBKGLGAB, DKIPMCCIKMF: false);
			}
			KJPFENINCHJ.isKinematic = true;
		}
		MGFPGLCHKJN(IDEBKDPMPGM: false);
		ParticleSystem[] fFPLNCHHFDP = FFPLNCHHFDP;
		foreach (ParticleSystem particleSystem in fFPLNCHHFDP)
		{
			particleSystem.gameObject.SetActive(value: false);
		}
	}

	public virtual void HMIGDPBGEIG()
	{
		base.OnInstancied();
		StopAllCoroutines();
		KJPFENINCHJ.isKinematic = false;
		KMAIJHADEHJ = false;
		IAICPGNGCJI = base.currentBeh.totalPower;
		NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: false);
		NLIGPBPNHHP.gameObject.SetActive(value: false);
		if (!LCDBACDIODH)
		{
			InvokeAfterRealTime(JDBEIOIHMBK, 1892f);
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.MGJIOLLKHDK();
		KAEAMDOJMIF.MLIIJGJENIE();
		MGFPGLCHKJN(IDEBKDPMPGM: false);
		ParticleSystem[] fFPLNCHHFDP = FFPLNCHHFDP;
		for (int i = 1; i < fFPLNCHHFDP.Length; i++)
		{
			ParticleSystem particleSystem = fFPLNCHHFDP[i];
			particleSystem.gameObject.SetActive(value: false);
		}
	}

	private void LEPJAGDMOAO()
	{
		GIPEKIBEPEB = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		GIPEKIBEPEB.fraction = fraction;
		GIPEKIBEPEB.DisableSpawn();
		int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
		GIPEKIBEPEB.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
		SpawningManager.instance.Spawn(GIPEKIBEPEB, fraction, EEAMBOACAGF: false, GHAGNCHNHEE.transform.position, PNENBKAGLEF: false);
		GHAGNCHNHEE.IDNNIHBIMNO = GIPEKIBEPEB;
		GIPEKIBEPEB.power = 0;
		GIPEKIBEPEB.NLGBGOGCNKP = GHAGNCHNHEE;
		GIPEKIBEPEB.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Vehicle);
		GIPEKIBEPEB.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
		GIPEKIBEPEB.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
		GIPEKIBEPEB.Killed += KCDOMJDNMPG;
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.Reset();
	}

	[SpecialName]
	public virtual DestroyableObject PAIMDBEIDIM()
	{
		return FFOAABONJNO;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		StopAllCoroutines();
		KJPFENINCHJ.isKinematic = true;
		KMAIJHADEHJ = false;
		IAICPGNGCJI = base.currentBeh.totalPower;
		NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: false);
		NLIGPBPNHHP.gameObject.SetActive(value: false);
		if (!LCDBACDIODH)
		{
			InvokeAfterRealTime(delegate
			{
				NLIGPBPNHHP.ropeEnd.transform.localPosition = CHDHFCPHEIO;
				NLIGPBPNHHP.ropeEnd.gameObject.SetActive(value: true);
				NLIGPBPNHHP.gameObject.SetActive(value: true);
			}, 2f);
		}
		KAEAMDOJMIF.enabled = true;
		KAEAMDOJMIF.Reset();
		KAEAMDOJMIF.ResetAiming();
		MGFPGLCHKJN(IDEBKDPMPGM: true);
		ParticleSystem[] fFPLNCHHFDP = FFPLNCHHFDP;
		foreach (ParticleSystem particleSystem in fFPLNCHHFDP)
		{
			particleSystem.gameObject.SetActive(value: true);
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.LJNGPLLBOHO.LIAEIIFPONK;
		List<SpawnPointHelicopter> list = new List<SpawnPointHelicopter>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointHelicopter spawnPointHelicopter = (SpawnPointHelicopter)item;
			if (spawnPointHelicopter.HGMMBPGFHGD.MFHFIHIHBHA.PODMFKMOJML == null && fraction == spawnPointHelicopter.fraction)
			{
				list.Add(spawnPointHelicopter);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			SpawnPointHelicopter spawnPointHelicopter2 = list[index];
			base.transform.position = spawnPointHelicopter2.transform.position;
			base.transform.rotation = spawnPointHelicopter2.transform.rotation;
			SetWayPoint(spawnPointHelicopter2.HGMMBPGFHGD);
			FHEJEFPNAIF = spawnPointHelicopter2.KPNKNCPEMOI.transform;
		}
		else
		{
			UnityEngine.Debug.LogError("Helicopter could not be spawned");
		}
		if (LAADDLGBFIG.isMine)
		{
			for (int i = 0; i < base.currentBeh.helicopterBehaviourDefinititon.crew && i < NKBHMMMKGMJ.Count; i++)
			{
				EnemyPointHelicopter oJPDIBNCOLE = NKBHMMMKGMJ[i];
				AHKDGHENKCE(oJPDIBNCOLE, LLDAGHMKOAC: false);
			}
			LEPJAGDMOAO();
		}
	}
}
