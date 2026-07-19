using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class KillStreakBonusTurret : KillStreakBonus
{
	private sealed class ACEMMMAPHIE : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TechnologyVisualDefinition>.Enumerator KFCAECGLKKO;

		internal TechnologyVisualDefinition BJOLICIOGLK;

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

		public bool BLHOCNMMPNP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 25u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.PLNLICOAHFL());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.CBKMNCJMJIH());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public bool CIIHKFDLDKN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 87u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return false;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public bool IGOKEIDOCKB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 81u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.BCGOFHPCKAA());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return false;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		public bool JPBGJLDMOPO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967168u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.CBKMNCJMJIH());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HJLCPFDBNKP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public bool IDBCKIPOEEI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 63u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.CBKMNCJMJIH());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return false;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
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
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public bool BIGKCFMEBJE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 100u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.IDJIGNLGAKB());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void PMAJELGBBKE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public bool FNEPBDLIKOD()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 89u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.IDJIGNLGAKB());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.FFGDLJEMDNG());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		public bool EKGEDEKHBME()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967189u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.FFGDLJEMDNG());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[DebuggerHidden]
		public ACEMMMAPHIE()
		{
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void HANDHJHGLAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool HJHJCCFGJIH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967256u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.IDJIGNLGAKB());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.BCGOFHPCKAA());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void OLPILJFHMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool LMNIKLKKIDN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 72u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.GEIBNFKACDB());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.CBKMNCJMJIH());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967209u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.GEIBNFKACDB());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return false;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void AKEKFBGEJBG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 106u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.IDJIGNLGAKB());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.BCGOFHPCKAA());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public bool PMJICFJGOBE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967294u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.BCGOFHPCKAA());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void CHFJIODFNIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool OOECALAHCFK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 55u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.CBKMNCJMJIH());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void NFAMBMLLFGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void FLFOEIMCFBL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void CNEIBEACPCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public bool KBPKMAKLNPB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 4294967270u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						flag = false;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return false;
			default:
				{
					return false;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		public bool HOJKAHEGFEB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals.GetEnumerator();
				num = 122u;
				goto case 1u;
			case 1u:
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						flag = true;
						goto end_IL_004e;
					default:
						if (!KFCAECGLKKO.MoveNext())
						{
							break;
						}
						BJOLICIOGLK = KFCAECGLKKO.Current;
						PHDOCKCBJOF = Singleton<KillStreakManager>.instance.StartCoroutine(BJOLICIOGLK.CBKMNCJMJIH());
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto end_IL_004e;
					}
					goto IL_0101;
					end_IL_004e:;
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				return true;
			default:
				{
					return true;
				}
				IL_0101:
				CLPPIAGLCJJ = -1;
				goto default;
			}
		}

		public void FOBPOJPHNHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
			case 2u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}
	}

	private IEnumerator EFPABFBGGKG()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator IDBIKKCDMMJ()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void GIHIDIDOBAD()
	{
		base.OBNMBGAGMFJ();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BLEGJDCNAAJ();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual bool IENDHGPJJFE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 63f, 0);
			Vector3 position = hit.position;
			SpawningManager.LDGAKJJINEO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return false;
		}
		return true;
	}

	private IEnumerator FPGLAHNEFKJ()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator BGAFAJEILOD()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void CPKHLFLHOIA()
	{
		base.CEMADLCCFAG();
		Singleton<KillStreakManager>.instance.StartCoroutine(EGHLHJLKJNF());
	}

	private IEnumerator BJIMACOEENN()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator DBNHECIKBAK()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void CFCCEPLFKHI()
	{
		base.CEBAOMCHCOK();
		Singleton<KillStreakManager>.instance.StartCoroutine(JFCOOCHOJJO());
	}

	private IEnumerator JOEMMIMNLIN()
	{
		return new ACEMMMAPHIE();
	}

	public override void OBNMBGAGMFJ()
	{
		base.OBNMBGAGMFJ();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BLEGJDCNAAJ();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual bool DFPGPKIIHFA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 921f, 0);
			Vector3 position = hit.position;
			SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return true;
	}

	public virtual void OJKHLLIFOOO()
	{
		base.JEJBENJKMHN();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.LLGPADPJPIF();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual bool DHGFPILPDBN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.GCHILNJMFPD(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1733f, 1);
			Vector3 position = hit.position;
			SpawningManager.BMNEPICFHNO().MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return false;
	}

	private IEnumerator LOOGEFIFBOC()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator EGHLHJLKJNF()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator LBOAELOJCOE()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void GFJGJAEPDPD()
	{
		base.CEMADLCCFAG();
		Singleton<KillStreakManager>.instance.StartCoroutine(NLPDJOLCPIA());
	}

	private IEnumerator OGOGKAGPPPH()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void OJGDJMJPLOL()
	{
		base.AOBGIILGIBN();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BLEGJDCNAAJ();
			cardVisual.LLJOCAELALO();
		}
	}

	private IEnumerator FKAMIOAPEGP()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void KDEBLLCJKND()
	{
		base.CEMADLCCFAG();
		Singleton<KillStreakManager>.instance.StartCoroutine(EGMKNBLJHML());
	}

	private IEnumerator DBCMLDHFKDO()
	{
		return new ACEMMMAPHIE();
	}

	public override void JKEBCGNNDHM()
	{
		base.PHMBBFCBHLP();
		Singleton<KillStreakManager>.instance.StartCoroutine(DCOKDMAHKFJ());
	}

	public virtual bool OAHGHHFHBEI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 502f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return true;
	}

	public override void SceneFreed()
	{
		base.SceneFreed();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.LLGPADPJPIF();
			cardVisual.LPEPPPCBCDG();
		}
	}

	public virtual void HENPLCPOKMI()
	{
		base.AOKLGCNOOID();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BLEGJDCNAAJ();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual bool BCGJKNHOKBM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1073f, 1);
			Vector3 position = hit.position;
			SpawningManager.BMNEPICFHNO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return true;
		}
		return false;
	}

	public virtual void OMNACMJEPBC()
	{
		base.AOBGIILGIBN();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual void BICBPABDMPP()
	{
		base.JEJBENJKMHN();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.LLGPADPJPIF();
			cardVisual.LLJOCAELALO();
		}
	}

	private IEnumerator OICAEDDAFAA()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator JKBDIHFLDCJ()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void MMFFBIANKFG()
	{
		base.GPJFPNGANFC();
		Singleton<KillStreakManager>.instance.StartCoroutine(JFCOOCHOJJO());
	}

	private IEnumerator LDKHOAEDHLF()
	{
		return new ACEMMMAPHIE();
	}

	public virtual bool HDMPEMAGGFN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CMPIFPBJDLM(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 419f, 1);
			Vector3 position = hit.position;
			SpawningManager.LDGAKJJINEO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return false;
		}
		return false;
	}

	public virtual bool FICFAOOANCJ(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1828f, 1);
			Vector3 position = hit.position;
			SpawningManager.OKBAIGKCPKA().MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return true;
		}
		return true;
	}

	public virtual void CAAAMHDDOPH()
	{
		base.AOKLGCNOOID();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BLEGJDCNAAJ();
			cardVisual.LLJOCAELALO();
		}
	}

	private IEnumerator GALJONDMILH()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void DEFBPDGEHEL()
	{
		base.BGBNFLEKEKA();
		Singleton<KillStreakManager>.instance.StartCoroutine(JKBDIHFLDCJ());
	}

	public virtual bool FFJBHDGFIHI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CMPIFPBJDLM(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 810f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return true;
		}
		return false;
	}

	public virtual void IKKPDKGJGCD()
	{
		base.AOKLGCNOOID();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BLEGJDCNAAJ();
			cardVisual.LPEPPPCBCDG();
		}
	}

	private IEnumerator FKNAPDNAJMM()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator JFCOOCHOJJO()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void DPAJPAKPIED()
	{
		base.KDLBPIIKMCD();
		Singleton<KillStreakManager>.instance.StartCoroutine(PHDONMKBBLM());
	}

	public virtual void PBFADDFLMKJ()
	{
		base.HAIDFJOINOA();
		Singleton<KillStreakManager>.instance.StartCoroutine(GALJONDMILH());
	}

	public virtual void FAFGKLLOMLN()
	{
		base.HCEICANNFIO();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.LPEPPPCBCDG();
		}
	}

	public virtual void CLJNFMOLDLF()
	{
		base.KDLBPIIKMCD();
		Singleton<KillStreakManager>.instance.StartCoroutine(NFHPOBGLHOE());
	}

	public override void LCNFLADDNLM()
	{
		base.JKEBCGNNDHM();
		Singleton<KillStreakManager>.instance.StartCoroutine(KABAMMNCKHH());
	}

	public virtual void BBELDMLIEHC()
	{
		base.JHHBEHJGKKK();
		Singleton<KillStreakManager>.instance.StartCoroutine(LOOGEFIFBOC());
	}

	private IEnumerator NFHPOBGLHOE()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator DBEFAGPPCLK()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void MCJCACOOADL()
	{
		base.CEMADLCCFAG();
		Singleton<KillStreakManager>.instance.StartCoroutine(DCOKDMAHKFJ());
	}

	public virtual void MFHHPNIPCEA()
	{
		base.JHHBEHJGKKK();
		Singleton<KillStreakManager>.instance.StartCoroutine(DBMBELOAILO());
	}

	public virtual void JGJNMIEDLKE()
	{
		base.OBNMBGAGMFJ();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.LPEPPPCBCDG();
		}
	}

	public virtual void PMKJIEFDNPB()
	{
		base.LCNFLADDNLM();
		Singleton<KillStreakManager>.instance.StartCoroutine(LBNHGAJIDKP());
	}

	public virtual bool JEKNHBPDBJO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1638f, 1);
			Vector3 position = hit.position;
			SpawningManager.OKBAIGKCPKA().SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return true;
		}
		return true;
	}

	public override void PHMBBFCBHLP()
	{
		base.GPJFPNGANFC();
		Singleton<KillStreakManager>.instance.StartCoroutine(EGHLHJLKJNF());
	}

	public virtual bool BLGCKFBMKGF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1829f, 1);
			Vector3 position = hit.position;
			SpawningManager.OKBAIGKCPKA().EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return true;
	}

	public virtual void MDONLCHILKN()
	{
		base.KJDMBBKAGEP();
		Singleton<KillStreakManager>.instance.StartCoroutine(PHDONMKBBLM());
	}

	public virtual bool JJOOCBLMFFH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 948f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return false;
	}

	public virtual void KLOGIECABPJ()
	{
		base.HCEICANNFIO();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.LLJOCAELALO();
		}
	}

	public virtual bool BPHFNDPJHFG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 63f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return true;
		}
		return false;
	}

	public virtual void NLEHFFJBPCM()
	{
		base.HCEICANNFIO();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.LLJOCAELALO();
		}
	}

	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 20f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return true;
		}
		return false;
	}

	public virtual void MGKBDFEAAKH()
	{
		base.JKEBCGNNDHM();
		Singleton<KillStreakManager>.instance.StartCoroutine(LOOGEFIFBOC());
	}

	public virtual bool MILOFINNGIP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1574f, 1);
			Vector3 position = hit.position;
			SpawningManager.LDGAKJJINEO().EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return true;
		}
		return true;
	}

	public virtual void GDALKHININN()
	{
		base.OBNMBGAGMFJ();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.LLJOCAELALO();
		}
	}

	public virtual void CICNPDJOCLL()
	{
		base.LCNFLADDNLM();
		Singleton<KillStreakManager>.instance.StartCoroutine(IGKHHLKPGJI());
	}

	private IEnumerator DBMBELOAILO()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator EGMKNBLJHML()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void OOJIFEPGMMK()
	{
		base.CEMADLCCFAG();
		Singleton<KillStreakManager>.instance.StartCoroutine(EGMKNBLJHML());
	}

	public virtual void DFHPHJFPMOC()
	{
		base.KJDMBBKAGEP();
		Singleton<KillStreakManager>.instance.StartCoroutine(IFOLBNDOJDE());
	}

	public virtual bool KGALFBPJBKO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.FJAJKEBLFOE(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1015f, 0);
			Vector3 position = hit.position;
			SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return false;
	}

	public override void BeforeGameStarted()
	{
		base.BeforeGameStarted();
		Singleton<KillStreakManager>.instance.StartCoroutine(JHCCGIMFNGO());
	}

	private IEnumerator PHDONMKBBLM()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void EBIHJCIAGBJ()
	{
		base.SceneFreed();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.LLGPADPJPIF();
			cardVisual.LPEPPPCBCDG();
		}
	}

	private IEnumerator IGKHHLKPGJI()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator NLPDJOLCPIA()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void NMOLODIEODE()
	{
		base.JKEBCGNNDHM();
		Singleton<KillStreakManager>.instance.StartCoroutine(DNEIOABLFAF());
	}

	private IEnumerator PMIGOHAPBED()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void GOKNKNJLBGO()
	{
		base.HAIDFJOINOA();
		Singleton<KillStreakManager>.instance.StartCoroutine(GALJONDMILH());
	}

	private IEnumerator KABAMMNCKHH()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void GBAMABEFHBK()
	{
		base.HAIDFJOINOA();
		Singleton<KillStreakManager>.instance.StartCoroutine(NLPDJOLCPIA());
	}

	public virtual void HFMDJMAOHIC()
	{
		base.PHIIBHDNKDM();
		Singleton<KillStreakManager>.instance.StartCoroutine(EFPABFBGGKG());
	}

	public virtual bool NILJDLKGKCP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 720f, 0);
			Vector3 position = hit.position;
			SpawningManager.LDGAKJJINEO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return true;
		}
		return true;
	}

	private IEnumerator JENGMEENODB()
	{
		return new ACEMMMAPHIE();
	}

	private IEnumerator DCOKDMAHKFJ()
	{
		return new ACEMMMAPHIE();
	}

	public override bool LJBDCGFBAHE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CMPIFPBJDLM(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 538f, 1);
			Vector3 position = hit.position;
			SpawningManager.BMNEPICFHNO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return true;
	}

	public virtual bool MDNMJNFHAFB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1046f, 1);
			Vector3 position = hit.position;
			SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return false;
		}
		return false;
	}

	public virtual void MMGBADNKAAA()
	{
		base.PHMBBFCBHLP();
		Singleton<KillStreakManager>.instance.StartCoroutine(IGKHHLKPGJI());
	}

	public virtual bool LFDMFMPFOJJ(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 512f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return true;
	}

	public override bool CMPIFPBJDLM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1405f, 0);
			Vector3 position = hit.position;
			SpawningManager.LDGAKJJINEO().OMANPOHJAGO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return false;
		}
		return false;
	}

	public virtual bool ECCIBBNHBOF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 646f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	private IEnumerator JHCCGIMFNGO()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void EFFKFDCAMPK()
	{
		base.JEJBENJKMHN();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.MIHNPIJCIKK();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual bool AIFHKFOGBAL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1480f, 1);
			Vector3 position = hit.position;
			SpawningManager.OKBAIGKCPKA().MGIDDHIPJBC(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return true;
		}
		return false;
	}

	public virtual bool JGAEDEHMMOK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 1847f, 1);
			Vector3 position = hit.position;
			SpawningManager.OKBAIGKCPKA().GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return false;
		}
		return false;
	}

	public virtual void BOFBNJJHPBA()
	{
		base.AOKLGCNOOID();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.BHINPFEIIJG();
			cardVisual.LPEPPPCBCDG();
		}
	}

	public virtual void GEJLLCCIDKL()
	{
		base.PHIIBHDNKDM();
		Singleton<KillStreakManager>.instance.StartCoroutine(NFHPOBGLHOE());
	}

	public virtual bool ECMIOMNFOPD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 752f, 0);
			Vector3 position = hit.position;
			SpawningManager.instance.GGBPHPOPCAM(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position);
			return false;
		}
		return false;
	}

	public virtual bool IBJCOBEOPKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 255f, 1);
			Vector3 position = hit.position;
			SpawningManager.BMNEPICFHNO().JAMPFGHHAPP(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 1, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return false;
	}

	private IEnumerator DNEIOABLFAF()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void LJPEHBDIHHA()
	{
		base.GCKDDIEKKBF();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.EIFNJBHKBOM();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual bool OEJLKDJAEGD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		if (base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB))
		{
			float pAENPHMEMGC = (float)KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position);
			Ray ray = new Ray(NPNGCEJFAOP.transform.position, Vector3.down);
			Vector3 sourcePosition = NPNGCEJFAOP.transform.position;
			float enter;
			if (plane.Raycast(ray, out enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMeshHit hit;
			NavMesh.SamplePosition(sourcePosition, out hit, 327f, 0);
			Vector3 position = hit.position;
			SpawningManager.LDGAKJJINEO().EEOMJOEDAMO(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM, 0, pAENPHMEMGC, KHLGDCHJJPB.fraction, position, false);
			return false;
		}
		return false;
	}

	private IEnumerator LBNHGAJIDKP()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void HCMKFIBKEOI()
	{
		base.PFJBLLMHHHA();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.EIFNJBHKBOM();
			cardVisual.LLJOCAELALO();
		}
	}

	private IEnumerator JKPDPGCMPNP()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void GGKPJLHBCLA()
	{
		base.EIPDMDNNOCE();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.MIHNPIJCIKK();
			cardVisual.LLJOCAELALO();
		}
	}

	public virtual void LJMNGCNLBHJ()
	{
		base.JHHBEHJGKKK();
		Singleton<KillStreakManager>.instance.StartCoroutine(JENGMEENODB());
	}

	private IEnumerator IFOLBNDOJDE()
	{
		return new ACEMMMAPHIE();
	}

	public virtual void BNOEIKOLCCD()
	{
		base.GCKDDIEKKBF();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.EIFNJBHKBOM();
			cardVisual.LPEPPPCBCDG();
		}
	}

	public override void PFJBLLMHHHA()
	{
		base.PFJBLLMHHHA();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.LLGPADPJPIF();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual void LMFMBHEDCMN()
	{
		base.PHMBBFCBHLP();
		Singleton<KillStreakManager>.instance.StartCoroutine(DBNHECIKBAK());
	}

	public virtual void CNMEIDCHPNM()
	{
		base.JKEBCGNNDHM();
		Singleton<KillStreakManager>.instance.StartCoroutine(JFCOOCHOJJO());
	}

	public virtual void GLIFGDJOFNI()
	{
		base.JKEBCGNNDHM();
		Singleton<KillStreakManager>.instance.StartCoroutine(EFPABFBGGKG());
	}

	public virtual void FNNGMKPMELD()
	{
		base.AOBGIILGIBN();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM.upgradeSlots.cardVisuals)
		{
			cardVisual.MIHNPIJCIKK();
			cardVisual.BBENKKFKDJH();
		}
	}

	public virtual void HADLDEDPFLB()
	{
		base.BeforeGameStarted();
		Singleton<KillStreakManager>.instance.StartCoroutine(FKNAPDNAJMM());
	}
}
