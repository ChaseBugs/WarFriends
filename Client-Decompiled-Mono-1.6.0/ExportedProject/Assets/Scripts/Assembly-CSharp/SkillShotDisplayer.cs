using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkillShotDisplayer : PoolableObject
{
	private sealed class OEDCMGHNIDF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Vector3 ONGOEJMKLJC;

		internal bool PMHCHJJHNKL;

		internal List<SkillShotManager.SkillShotItemDefinition>.Enumerator KFCAECGLKKO;

		internal List<SkillShotManager.SkillShotItemDefinition>.Enumerator GHCPBBJDIBB;

		internal SkillShotManager.SkillShotItemDefinition FOAEDBKBGEE;

		internal SkillShotDisplayerItem LEAEALAHJNE;

		internal SkillShotDisplayer BJGCPDNMHDH;

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

		public bool EBLHEEKHANA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(344f, 1388f, 1457f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 878f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BKLDAAPMMDI().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967226u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 17f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.PGCPICBNFAM(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1066f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(49f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1427f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.isPlaying = false;
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(251f, 1286f, 548f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 279f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == SkillShot.SkillShotType.TrippleKill)
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967252u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1107f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.PGCPICBNFAM(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 855f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(506f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1650f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JFJEJMHDMDG(false);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void DBEMHFEBPFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object INHIPKJFGDI()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		public void LJPIDOKGNBF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public bool PMBOHHPPJAC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1999f, 1602f, 1307f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1815f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == ~(SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BLHCFKIELCA().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967237u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1534f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.OHDNLPIOAHG(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 632f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1399f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(591f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.PBNLJNBIBIO(true);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public void HJLCPFDBNKP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FCFHLDPLIDC()
		{
			return PHDOCKCBJOF;
		}

		public void AGFMDCEAJNM()
		{
			throw new NotSupportedException();
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public bool IBEPOFJDKLG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(625f, 824f, 1361f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1796f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967270u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 303f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.NJCHPFPACHC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 207f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1209f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(659f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.EAGDKIFKPDM(true);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		public void ENENMOAOOBG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		public bool KKINHOPBKLH()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1603f, 1110f, 1406f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1919f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BLHCFKIELCA().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967188u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1278f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 20f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1740f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1096f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JFCJMJOBILM(true);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return true;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public bool LPCENKMGCDJ()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1731f, 452f, 1347f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 864f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967169u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1057f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 1935f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1921f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(193f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.PBNLJNBIBIO(true);
					BJGCPDNMHDH.OBCAIFMOPPA();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public bool DDBCLDGNFBB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(499f, 1087f, 107f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1510f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967236u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1880f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.ACCOLBNMIHP(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.NJCHPFPACHC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 281f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(204f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1575f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.DOIEBBMBKCN(true);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		public void AKLMKDOIDHP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public bool AAOIPMCCPEM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(47f, 1291f, 20f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1214f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BLHCFKIELCA().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 0u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 4f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 825f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1615f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1618f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.EAGDKIFKPDM(true);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		public void CCPGGFONBKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public void HANDHJHGLAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		public bool PMCFLKAJNHO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(511f, 468f, 417f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 476f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == ~(SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == SkillShot.SkillShotType.TrippleKill)
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 63u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1978f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.PGCPICBNFAM(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 27f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1348f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(138f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JFCJMJOBILM(true);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void IDCJDJMGKFG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public void JBHOCIFIMBH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void CDIJEGGMMAK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
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
				ONGOEJMKLJC = new Vector3(1470f, 104f, 1969f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1836f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = uint.MaxValue;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 96f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.PGCPICBNFAM(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1563f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(693f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1819f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.EFMLKEOIAOC(false);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public void HCHFFFPDMDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void GOCCDFALOHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void FOODPOJODAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public bool AKHEIOMMAJL()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1325f, 1482f, 354f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 23f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BKLDAAPMMDI().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 89u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1558f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1936f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1315f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1029f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.isPlaying = true;
					BJGCPDNMHDH.OBCAIFMOPPA();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public void LPKDPNHBLGJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public void IFLGJMJCOMC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void GGLMLMFEJCD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
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
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public bool CJGDOJHLOII()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(125f, 1687f, 1755f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1228f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BLHCFKIELCA().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967193u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1518f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.HNOMDGLDHON(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.NJCHPFPACHC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1444f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(102f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1271f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JGIDFONLBAF(false);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public bool ACHIHMMCDNF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1656f, 1857f, 1123f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1636f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.TrippleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967274u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1430f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.HMFKJHDCBHL(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1589f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1540f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1485f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JFJEJMHDMDG(true);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return false;
		}

		public void EGAONBPLDAG()
		{
			throw new NotSupportedException();
		}

		public bool GMBFJOBKMMN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1470f, 1875f, 1732f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 691f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BKLDAAPMMDI().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 2u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1974f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 594f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1615f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(187f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.EAGDKIFKPDM(true);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(6f, 6.5f, 0f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 0.5f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == SkillShot.SkillShotType.Kill)
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == SkillShot.SkillShotType.ArmyKill)
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 6f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(0.15f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(3f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.isPlaying = false;
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public bool OOECALAHCFK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(321f, 1334f, 1399f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1878f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 33u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 864f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.NJCHPFPACHC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 1770f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1656f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1168f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JDFILEOFIIP(false);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		public void NCOPKHMOMMK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		public bool LMNIKLKKIDN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(634f, 1655f, 1811f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 443f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967178u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1673f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.OHDNLPIOAHG(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 820f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1103f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1761f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.EFMLKEOIAOC(false);
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return false;
		}

		public bool DMPHMFDEINI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1874f, 1259f, 1591f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 582f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967262u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 634f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.MAMBNKBNPPK(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1455f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(291f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1276f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.LFHPFNOMMGL(false);
					BJGCPDNMHDH.OBCAIFMOPPA();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public OEDCMGHNIDF()
		{
		}

		[SpecialName]
		private object KBOFICGMHNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		public void ELMJLOBAMKH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
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
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object DLBACGEOGPM()
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
				ONGOEJMKLJC = new Vector3(266f, 1233f, 1124f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 234f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BCDJJBAFLLG().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967287u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1666f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.MAMBNKBNPPK(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.MJEDLBNGCKC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 581f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(170f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(761f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.isPlaying = false;
					BJGCPDNMHDH.BOHCNEDIJPE();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return false;
		}

		public bool CMBMOAECEJG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(666f, 900f, 147f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1022f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BLHCFKIELCA().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967212u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 138f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.ACCOLBNMIHP(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.NJCHPFPACHC(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 749f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(621f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1984f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.MFBIHIAHBIB(false);
					BJGCPDNMHDH.OBCAIFMOPPA();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return false;
			}
			return true;
		}

		public bool FCPJPIDEPOF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(1442f, 19f, 1744f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1924f * Vector3.up;
				PMHCHJJHNKL = false;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == (SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = false;
						}
						if (current.skillShotType == (SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.Covered | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = false;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 0;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967233u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 729f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.HMFKJHDCBHL(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1864f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(650f, false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1177f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.JDFILEOFIIP(true);
					BJGCPDNMHDH.DestroyPooled();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		public bool GBLFIBDBMGE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				ONGOEJMKLJC = new Vector3(898f, 562f, 246f);
				BJGCPDNMHDH.MFJIBMBIJAL = new List<SkillShotDisplayerItem>();
				ONGOEJMKLJC += 1626f * Vector3.up;
				PMHCHJJHNKL = true;
				KFCAECGLKKO = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SkillShotManager.SkillShotItemDefinition current = KFCAECGLKKO.Current;
						if (current.skillShotType == ~(SkillShot.SkillShotType.HeadShot | SkillShot.SkillShotType.LongShot | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.TrippleKill))
						{
							PMHCHJJHNKL = true;
						}
						if (current.skillShotType == ~(SkillShot.SkillShotType.Runner | SkillShot.SkillShotType.OneHitKill | SkillShot.SkillShotType.DoubleKill | SkillShot.SkillShotType.MultiKill))
						{
							PMHCHJJHNKL = true;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				PMHCHJJHNKL &= BJGCPDNMHDH.IAICPGNGCJI > 1;
				if (PMHCHJJHNKL)
				{
					DeathMatchUnitsGuiElement.BLHCFKIELCA().DeployEnergyIconAnimation(BJGCPDNMHDH.transform.position, BJGCPDNMHDH.IAICPGNGCJI);
				}
				GHCPBBJDIBB = BJGCPDNMHDH.COMJEIAJHOO.GetEnumerator();
				num = 4294967212u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (GHCPBBJDIBB.MoveNext())
						{
							FOAEDBKBGEE = GHCPBBJDIBB.Current;
							ONGOEJMKLJC += 1699f * Vector3.up;
							LEAEALAHJNE = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.PGCPICBNFAM(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, ONGOEJMKLJC, Quaternion.identity, BJGCPDNMHDH.gameObject) as SkillShotDisplayerItem;
							if (LEAEALAHJNE != null)
							{
								LEAEALAHJNE.Play(FOAEDBKBGEE);
								BJGCPDNMHDH.MFJIBMBIJAL.Add(LEAEALAHJNE);
								SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1633f);
							}
							PHDOCKCBJOF = new WaitForSeconds(TimeManager.GetTimeScaledInterval(1369f, true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_02b7;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(930f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				goto IL_02b7;
			case 2u:
				{
					BJGCPDNMHDH.HGLCGMLMBNM(true);
					BJGCPDNMHDH.OBCAIFMOPPA();
					CLPPIAGLCJJ = -1;
					break;
				}
				IL_02b7:
				return true;
			}
			return true;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNACDOOHMMG()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
			case 2u:
				break;
			}
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void FILDGEMDECJ()
		{
			throw new NotSupportedException();
		}
	}

	private List<SkillShotManager.SkillShotItemDefinition> COMJEIAJHOO = new List<SkillShotManager.SkillShotItemDefinition>();

	private List<SkillShotDisplayerItem> MFJIBMBIJAL;

	private int IAICPGNGCJI;

	public bool isPlaying { get; private set; }

	public virtual void NNMGFLHFDGJ()
	{
		if (!LANJNCEFMOJ())
		{
			base.DestroyPooled();
		}
	}

	private IEnumerator MNLAIHAPJOA()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void MDACOKBDIAA(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			PBNLJNBIBIO(false);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(PCJHCBIHFNF());
		}
	}

	public void LCNPBNOKMCJ(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(342f, 1821f, 593f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 706f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.DHLMOKINJIO(AOCPNNPGECM);
		}
	}

	[SpecialName]
	public bool FBLNAAJCFMD()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void DBFGLKBMJFH(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			EAGDKIFKPDM(true);
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(GEKIMGFKNHC());
		}
	}

	[SpecialName]
	public bool IFPICLNPCNK()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void BBEMKLDJDMF(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1094f, 1596f, 1228f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 1847f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.ACCOLBNMIHP(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.GBFMCFKMBCE(AOCPNNPGECM);
		}
	}

	public void DBHKNGGFNPC(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			HGLCGMLMBNM(true);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(BIIHCAEKCOD());
		}
	}

	public void POGGLOOKLOO(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1969f, 959f, 86f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 1109f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PBDEIOIPGND(AOCPNNPGECM);
		}
	}

	public void BLNOMFPADHG(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(597f, 1304f, 1434f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 950f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.GBFMCFKMBCE(AOCPNNPGECM);
		}
	}

	public virtual void EANNHAPAAHO()
	{
		if (!PHELGNLACLA())
		{
			base.BOHCNEDIJPE();
		}
	}

	private IEnumerator GBEBFIDEOHH()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	[SpecialName]
	public bool OGLLLHGDHHD()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void CMDCJAHAHLC(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			MGLJJCMEGGJ(false);
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FAFEGBECEEM());
		}
	}

	private IEnumerator FJEEHGCABFM()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void PDOBNFCPENP(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(281f, 1249f, 391f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 1462f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.DHLMOKINJIO(AOCPNNPGECM);
		}
	}

	[SpecialName]
	private void JDFILEOFIIP(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void ACBAGGGPHIF(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			MGLJJCMEGGJ(false);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FJEEHGCABFM());
		}
	}

	[SpecialName]
	public bool LFDFCHFAHEA()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void PlayBoxStolen(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(6f, -6f, 0f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 22f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayBoxStolen(AOCPNNPGECM);
		}
	}

	[SpecialName]
	private void MGLJJCMEGGJ(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool LMKANECKKOH()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	[SpecialName]
	private void PBNLJNBIBIO(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void IHNBHPCLLAL(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			JDFILEOFIIP(true);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FFMLINMFADM());
		}
	}

	[SpecialName]
	public bool LANJNCEFMOJ()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void KIFEBDLANNF(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			isPlaying = false;
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(GEKIMGFKNHC());
		}
	}

	private IEnumerator DONHNAIKMCB()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public virtual void NPDNDDJHNNG()
	{
		base.JMAFCGDIICK();
		EFMLKEOIAOC(true);
	}

	[SpecialName]
	private void LFHPFNOMMGL(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void DCNCODEBBPP(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(415f, 1785f, 1466f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 1023f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.HNOMDGLDHON(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PBDEIOIPGND(AOCPNNPGECM);
		}
	}

	[SpecialName]
	private void JFCJMJOBILM(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		isPlaying = false;
	}

	[SpecialName]
	public bool NEGONHHKFBB()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void PlayDeath(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			isPlaying = true;
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(GEKIMGFKNHC());
		}
	}

	public void ICBJNEMFBIP(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			HGLCGMLMBNM(true);
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(GKKFPJHEEDG());
		}
	}

	private IEnumerator JLCJIIOIFOD()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void DGCOALPHLHM(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			JGIDFONLBAF(false);
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(MNLAIHAPJOA());
		}
	}

	private IEnumerator GKKFPJHEEDG()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public virtual void KBHCGIPHHPP()
	{
		base.HPPIBGEJMNL();
		PBNLJNBIBIO(true);
	}

	public void EIBJANKMHAF(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			PBNLJNBIBIO(false);
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(BIIHCAEKCOD());
		}
	}

	private IEnumerator PCJHCBIHFNF()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void MEJCBPLAJHN(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			EAGDKIFKPDM(true);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FFMLINMFADM());
		}
	}

	public void MDKGJKMGOJI()
	{
		Vector3 kAEBHEJBCGI = new Vector3(1002f, 1627f, 276f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.MAMBNKBNPPK(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.IFGPHPJLHPM();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 992f);
	}

	private IEnumerator BBOHJOFMLDI()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void DCDAPPKAMCO(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			LFHPFNOMMGL(false);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FPLCMPHNNHK());
		}
	}

	public void MKAGOKKFJGO(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1740f, 447f, 913f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 1531f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.GBFMCFKMBCE(AOCPNNPGECM);
		}
	}

	[SpecialName]
	private void DOIEBBMBKCN(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void MFBIHIAHBIB(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void BALJANNPEDC()
	{
		base.OnInstancied();
		PBNLJNBIBIO(true);
	}

	private IEnumerator FAFEGBECEEM()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	[SpecialName]
	private void OIHHIHNBECO(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void AJNIKNKHCED(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			MGLJJCMEGGJ(false);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FPLCMPHNNHK());
		}
	}

	public virtual void PGJIFBCNEFC()
	{
		base.HPPIBGEJMNL();
		JGIDFONLBAF(true);
	}

	public virtual void JCOCPAPHELC()
	{
		if (!KDAADMKCOLB())
		{
			base.OBCAIFMOPPA();
		}
	}

	private IEnumerator FPLCMPHNNHK()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void MICBBABHGFM(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1985f, 1399f, 285f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 1562f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.MAMBNKBNPPK(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PBDEIOIPGND(AOCPNNPGECM);
		}
	}

	[SpecialName]
	public bool JFHMKHJEOCD()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public virtual void ILBLPGBCEKH()
	{
		if (!OGLLLHGDHHD())
		{
			base.BOHCNEDIJPE();
		}
	}

	private IEnumerator IECHFELOIIO()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public virtual void GFGNHCMEDKE()
	{
		base.HPPIBGEJMNL();
		OIHHIHNBECO(false);
	}

	public void CGOGHGNJEHB()
	{
		Vector3 kAEBHEJBCGI = new Vector3(540f, 501f, 122f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.IFGPHPJLHPM();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 1309f);
	}

	public void BMIHHHKLCOE()
	{
		Vector3 kAEBHEJBCGI = new Vector3(1001f, 1666f, 1741f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayCritical();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 1458f);
	}

	[SpecialName]
	public bool PHELGNLACLA()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	[DebuggerHidden]
	private IEnumerator GEKIMGFKNHC()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void JKNIENJHNEP()
	{
		Vector3 kAEBHEJBCGI = new Vector3(19f, 440f, 694f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.OHDNLPIOAHG(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.IFGPHPJLHPM();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 1967f);
	}

	[SpecialName]
	public bool KDAADMKCOLB()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void AGFDKGGBJLN(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1885f, 1972f, 312f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 289f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.ACCOLBNMIHP(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayBoxStolen(AOCPNNPGECM);
		}
	}

	[SpecialName]
	private void EFMLKEOIAOC(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void KILENFLJMDH()
	{
		base.OnInstancied();
		JGIDFONLBAF(false);
	}

	public void DKJAELPHKNJ(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			JFCJMJOBILM(false);
			Singleton<SkillShotManager>.instance.GetItemDefinitions(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(BIIHCAEKCOD());
		}
	}

	[SpecialName]
	private void EAGDKIFKPDM(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	private IEnumerator DFJBBKKIPAD()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	[SpecialName]
	private void HGLCGMLMBNM(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void KFNJIFMJAPF(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1383f, 533f, 1504f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 498f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.OHDNLPIOAHG(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.DHLMOKINJIO(AOCPNNPGECM);
		}
	}

	private IEnumerator JBMCFEMBPKE()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void JDKHGMBPMOE()
	{
		Vector3 kAEBHEJBCGI = new Vector3(758f, 1621f, 1728f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.HNOMDGLDHON(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.IFGPHPJLHPM();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 40f);
	}

	private IEnumerator FFMLINMFADM()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public void NDCPFCDOOCO()
	{
		Vector3 kAEBHEJBCGI = new Vector3(1669f, 103f, 939f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.DHDLFDDIDCC();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 384f);
	}

	public virtual void AMKIFDFHOCC()
	{
		base.HPPIBGEJMNL();
		MFBIHIAHBIB(false);
	}

	private IEnumerator BIIHCAEKCOD()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	public virtual void IBGFJNHBBCL()
	{
		base.OnInstancied();
		EFMLKEOIAOC(true);
	}

	[SpecialName]
	private void JFJEJMHDMDG(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool JKPNMOBJKNI()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	[SpecialName]
	private void JGIDFONLBAF(bool IDEBKDPMPGM)
	{
		_003CNBLCNCGALCN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override void DestroyPooled()
	{
		if (!isPlaying)
		{
			base.DestroyPooled();
		}
	}

	public void AHKPMLABOLE(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			HGLCGMLMBNM(false);
			Singleton<SkillShotManager>.instance.IFAECFKOIMJ(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FAFEGBECEEM());
		}
	}

	public virtual void NFJEOLKAONC()
	{
		if (!JKPNMOBJKNI())
		{
			base.BOHCNEDIJPE();
		}
	}

	public virtual void ONHFNIJNMGE()
	{
		if (!NEGONHHKFBB())
		{
			base.DestroyPooled();
		}
	}

	[SpecialName]
	public bool LMLKOFGAFGJ()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void BDANMFHHHOB(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			EAGDKIFKPDM(true);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(GBEBFIDEOHH());
		}
	}

	[SpecialName]
	public bool BNMJHLIMCEP()
	{
		return _003CNBLCNCGALCN_003Ek__BackingField;
	}

	public void PlayCritical()
	{
		Vector3 kAEBHEJBCGI = new Vector3(6f, -3f, 0f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayCritical();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical);
	}

	public void GHBOMMEKPAF(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			EFMLKEOIAOC(true);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(FPLCMPHNNHK());
		}
	}

	public void IJDDNDNLAHG(bool AOCPNNPGECM)
	{
		Vector3 kAEBHEJBCGI = new Vector3(1901f, 1126f, 1231f);
		if (!AOCPNNPGECM)
		{
			kAEBHEJBCGI.y = 738f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.EPCCOJLHDLH(Singleton<ObjectPoolDatabase>.instance.LLADEBAFJKO, kAEBHEJBCGI, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayBoxStolen(AOCPNNPGECM);
		}
	}

	public void OPNCBIOMDEK(int APLODBKLDEG, SkillShot IFDBMJEAGND)
	{
		if (DebugSettings.instance.data.showHud)
		{
			DOIEBBMBKCN(false);
			Singleton<SkillShotManager>.instance.JJDAONGANCB(IFDBMJEAGND, ref COMJEIAJHOO);
			IAICPGNGCJI = APLODBKLDEG;
			StartCoroutine(BBOHJOFMLDI());
		}
	}

	public virtual void EGEAFDFNEAP()
	{
		if (!JFHMKHJEOCD())
		{
			base.DestroyPooled();
		}
	}
}
