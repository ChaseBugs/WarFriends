using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitsHeadTest : Core_BaseScript
{
	private sealed class OEDCMGHNIDF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int ALEFMCLGCAP;

		internal List<LevelBehaviour>.Enumerator KFCAECGLKKO;

		internal LevelBehaviour NBFFMCFEKOP;

		internal AIObject NEMLKKBGIKJ;

		internal UnitsHeadTest BJGCPDNMHDH;

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
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public bool IEDGDDDADFM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1647f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967191u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 3u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KKCMCNCCIMB().PKFDDOIEMMC(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1512f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 1170f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 948f), bought: false, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public bool FPMHODJKAKK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1692f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 60u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KJEANKAJELG().FLKHKLDOAPD(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1868f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 792f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1521f), bought: true, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 8;
							}
							flag = false;
							goto end_IL_0011;
						}
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
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public bool JMCPAKBLPML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(134f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967188u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.EHFPBDJMGNC().CNEDMJIOECH(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 117f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 20f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 191f), bought: false, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = false;
							goto end_IL_0011;
						}
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
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		public void FLFOEIMCFBL()
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
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public bool AIFKBHCOIKG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1132f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 22u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KJEANKAJELG().AHDKOOJNKDM(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 54f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1982f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 749f), bought: true, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public bool BKJCILLNJLG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1140f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967218u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 4u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KJEANKAJELG().KBBMHOCIMCE(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1190f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1259f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1180f), bought: true, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
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
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
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

		public bool HDGDKCMIOGK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1859f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967212u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().KBBMHOCIMCE(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 425f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 614f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 361f), bought: false, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public void LGCKODOHHIA()
		{
			throw new NotSupportedException();
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(387f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 42u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 7u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.INOJHPIKICM().IJKKOCDFLAF(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 61f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 612f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1129f), bought: true, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBPOAPCEPBN()
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

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
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
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		public bool FCJCLBMPBFK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(660f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 79u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.EHFPBDJMGNC().PKFDDOIEMMC(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 614f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 1782f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 761f), bought: true, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = true;
							goto end_IL_0011;
						}
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
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public OEDCMGHNIDF()
		{
		}

		public void CPEEDIDEKLA()
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

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public bool GBHCODKDPBO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(955f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967274u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 5u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.CHHLLIAHECC().AHDKOOJNKDM(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1502f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1872f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 325f), bought: false, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public bool IGOKEIDOCKB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1831f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967240u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 8u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KKCMCNCCIMB().KBBMHOCIMCE(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 531f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 970f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 765f), bought: false, mine: false, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 7;
							}
							flag = true;
							goto end_IL_0011;
						}
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
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void ELMJLOBAMKH()
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

		public void HANDHJHGLAP()
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

		public void HHCBBENDENJ()
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
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(600f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967270u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 5u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().FLKHKLDOAPD(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1352f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 759f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1864f), bought: false, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public void NIEPBMPJEAE()
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
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		public bool DEEBEBGBMKK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(912f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 57u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 3u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1316f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1569f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 152f), bought: false, mine: false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public void HKHANLKODIB()
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

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void MIEFKIEABBN()
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

		public void HNFEJKPKEHK()
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
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public bool KCEAGNMILMA()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(580f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967294u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 6u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.MFKPDKCLDBI().AHDKOOJNKDM(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 476f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 627f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1684f), bought: true, mine: false, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 4;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public void JHLKDONBGDK()
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
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		public bool ICKNHCBNOMG()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(730f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967288u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 2u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.CHHLLIAHECC().IJKKOCDFLAF(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1448f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1797f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 273f), bought: false, mine: false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 5;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
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
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public bool BJBEBPMDICE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(776f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 40u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 5u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.GLHPLCEFHGD().ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 121f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1283f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1463f), bought: false, mine: false, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public bool BGOEENAEBNO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1937f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967168u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.EHFPBDJMGNC().IONKGACHEBC(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1041f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 770f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 602f), bought: true, mine: false, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
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

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void KMIHPBNFGFH()
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

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void NIGLADNCHPK()
		{
			throw new NotSupportedException();
		}

		public void BDPFKFGBNOH()
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

		public bool BJIPDEICIML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(848f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 75u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.CHHLLIAHECC().CNEDMJIOECH(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1254f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1626f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1096f), bought: false, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967293u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 2u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 0.5f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP), bought: true, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 2;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public void KINGACOICNF()
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

		public bool MKLIDMNLNPN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(421f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 20u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 5u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KKCMCNCCIMB().AHDKOOJNKDM(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1909f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP += 0;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 1494f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1391f), bought: false, mine: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 3;
							}
							flag = false;
							goto end_IL_0011;
						}
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

		public void HNOPIDGLMPA()
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

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		public bool JFPOOBJNEPF()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(626f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 4294967208u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.COJFMKNGPBP().CNEDMJIOECH(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 541f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Grenade, 1718f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1836f), bought: false, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto end_IL_0011;
						}
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
		private object JEKHOAFAIBP()
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
				PHDOCKCBJOF = new WaitForSeconds(1081f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 121u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 3u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.GLHPLCEFHGD().IJKKOCDFLAF(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 14f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = false;
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 1999f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 819f), bought: false, mine: true, unloadWeapon: true));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto end_IL_0011;
						}
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
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void LHMNIFOJGIG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCFHLDPLIDC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LNAPDCBIFIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void NFAMBMLLFGP()
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
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public bool HBJOFNCAAGI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1518f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				ALEFMCLGCAP = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				num = 21u;
				goto case 2u;
			case 2u:
				try
				{
					switch (num)
					{
					case 7u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(NBFFMCFEKOP);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().CNEDMJIOECH(NEMLKKBGIKJ);
							enemyController.transform.position = Vector3.right * ALEFMCLGCAP * 1708f;
							enemyController.transform.localRotation = Quaternion.identity;
							enemyController.LCDBACDIODH = true;
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							ALEFMCLGCAP++;
							HeadSizeSetter componentInChildren = enemyController.GetComponentInChildren<HeadSizeSetter>();
							BJGCPDNMHDH.CPJEMPNEJMF.Add(componentInChildren);
							enemyController.mSoldierAnimationController.SampleIdle(Weapon.IGGFMJAKLGO.Riffle, 187f);
						}
						break;
					}
					while (KFCAECGLKKO.MoveNext())
					{
						NBFFMCFEKOP = KFCAECGLKKO.Current;
						if (NBFFMCFEKOP is SoldierBehaviour)
						{
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(NBFFMCFEKOP.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(NBFFMCFEKOP, 1958f), bought: true, mine: false));
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 6;
							}
							flag = true;
							goto end_IL_0011;
						}
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

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}
	}

	private List<HeadSizeSetter> CPJEMPNEJMF = new List<HeadSizeSetter>();

	[FormerlySerializedAs("OAJJJNKGJKL")]
	public float IAJAILAGAKC = 1f;

	private void MNFDMKFLAKO()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.KPPEACOEGEG(IAJAILAGAKC);
		}
	}

	private void CDJBEAIDHKH()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.OMGHDPKGBHJ(IAJAILAGAKC);
		}
	}

	private void GCOJHEDPIKL()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.LBIBKLMGOCF(IAJAILAGAKC);
		}
	}

	private IEnumerator OLECKGKLHCE()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void FDPOJHLHGJO()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.OAOBEICKMOM(IAJAILAGAKC);
		}
	}

	private IEnumerator BHGDOHCBGEC()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator JEDFPKBPBNB()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void ABMKKECEGIB()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(BDDIAOBBOPA);
	}

	private IEnumerator EFBEJJEIPEG()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void FGECFIBLFMD()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.EHHBHPKJJNJ(IAJAILAGAKC);
		}
	}

	private void NNJNIMCOLBC()
	{
		StartCoroutine(JLCJIIOIFOD());
	}

	private void BINACLIFPNC()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.BKBIHBKHBFB(IAJAILAGAKC);
		}
	}

	private void BOLPPMANCCC()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MKDDAEADIDO;
	}

	private void NBFMDCFFBIJ()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.KPPEACOEGEG(IAJAILAGAKC);
		}
	}

	private void MDOGOLCLDIB()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(KDCHJGNMCOL);
	}

	private void OBEHLLBBEIL()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(FAGACKDHBKC);
	}

	private void HLKOPCJHLJB()
	{
		StartCoroutine(DONHNAIKMCB());
	}

	private IEnumerator EHPIMALJLPB()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void IIFBKHDMIAD()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.KPPEACOEGEG(IAJAILAGAKC);
		}
	}

	private void NKGBAGPCLOC()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.EHHBHPKJJNJ(IAJAILAGAKC);
		}
	}

	private void KDCHJGNMCOL()
	{
		StartCoroutine(OHJAAIJDAAG());
	}

	private void AEPBKPJLCKA()
	{
		StartCoroutine(GLMKGLKCDAL());
	}

	private IEnumerator ECBMHNDPENI()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void NGBPFAOBCAD()
	{
		StartCoroutine(EKNDHCNIJFG());
	}

	private IEnumerator NBGFNLOCPAD()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void NEFDFOGOJGL()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.GIHFOHBBHPM(IAJAILAGAKC);
		}
	}

	private void JMPDHKPOHEA()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.CONNCKLPNBI(IAJAILAGAKC);
		}
	}

	private void JNDLGOABMKC()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.LBIBKLMGOCF(IAJAILAGAKC);
		}
	}

	private IEnumerator DANAMJKOPBO()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator KHLDOFCPOED()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void FPGFBDPLLON()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += LBKNBJELJEM;
	}

	private void DNMGKFDLLBJ()
	{
		StartCoroutine(GEKIMGFKNHC());
	}

	private void EMPDDFBNJLP()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.BKBIHBKHBFB(IAJAILAGAKC);
		}
	}

	private void OFGAKKAFOCD()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.HPPCDILHIFL(IAJAILAGAKC);
		}
	}

	private void BOPGJFGMNJM()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.LBIBKLMGOCF(IAJAILAGAKC);
		}
	}

	private void JDMBJJIDIMC()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OLOFFBIKCGP;
	}

	private IEnumerator EOEDEJKJKMN()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator GGHDIAFACAH()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void BAMNBAABJEK()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(OLOFFBIKCGP);
	}

	[DebuggerHidden]
	private IEnumerator GEKIMGFKNHC()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void Update()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.scaleF = IAJAILAGAKC;
		}
	}

	private void FJJAEHJDKNL()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += NGBPFAOBCAD;
	}

	private void HDKJEPMNCNL()
	{
		StartCoroutine(ECBMHNDPENI());
	}

	private void KAIPGKOGAIL()
	{
		StartCoroutine(HDKCFAMJBBO());
	}

	private IEnumerator DJNMPLKPENF()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void EBGBDDIADEJ()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.FFDHGMDDPEO(IAJAILAGAKC);
		}
	}

	private void NLLLLJGKNIC()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MBNKEABOAGP;
	}

	private void OHHLNKPIHBH()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += BDDIAOBBOPA;
	}

	private void KGMANMDFKHO()
	{
		StartCoroutine(MIGAJINCHAH());
	}

	private IEnumerator DEKLNBDGOML()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void LBKNBJELJEM()
	{
		StartCoroutine(DONHNAIKMCB());
	}

	private IEnumerator EKNDHCNIJFG()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void NOGLOKJINKN()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += EKKMHDJLFHJ;
	}

	private void FAHGDKLEKMN()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.CGEOFIPLINP(IAJAILAGAKC);
		}
	}

	private void JIDGKCFLFMF()
	{
		StartCoroutine(KHLDOFCPOED());
	}

	private IEnumerator OHJAAIJDAAG()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator FAFEGBECEEM()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator PAEPBCBHFEF()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator MIGAJINCHAH()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void LBMFKIDPCBL()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MBNKEABOAGP;
	}

	private void JLHNGHEOIGL()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += MKDDAEADIDO;
	}

	private IEnumerator HDKCFAMJBBO()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void JBGAPPEFEPH()
	{
		StartCoroutine(PFNBDPFAKBN());
	}

	private IEnumerator DLCFAJEFLHO()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void OLOFFBIKCGP()
	{
		StartCoroutine(DJNMPLKPENF());
	}

	private void NIGOADNHHFC()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.NMLFEAEIHCM(IAJAILAGAKC);
		}
	}

	private IEnumerator IFDIKMKGDPG()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator BBJADAJPJHH()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void OMDILMPFKII()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(KGMANMDFKHO);
	}

	private void CADJAJCEFCF()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(OLOFFBIKCGP);
	}

	private void PNEKCEHBGPD()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.KNBNJDOECDN(IAJAILAGAKC);
		}
	}

	private IEnumerator LJLDJOHAAMC()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator GNKIMPLPOPA()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator MCGOCBKCLJP()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator JOGFDHFOOBC()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void NCLHOHNKMOJ()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.KPPEACOEGEG(IAJAILAGAKC);
		}
	}

	private void PMOIOADCKPO()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.FFDHGMDDPEO(IAJAILAGAKC);
		}
	}

	private void BDDIAOBBOPA()
	{
		StartCoroutine(BHGDOHCBGEC());
	}

	private IEnumerator BJGDGMDOKLH()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator MJAAGDHAHEM()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void MBNKEABOAGP()
	{
		StartCoroutine(PFNBDPFAKBN());
	}

	private IEnumerator DONHNAIKMCB()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator GOLIFONLLPC()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void EIPLFPJNCIB()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(HDKJEPMNCNL);
	}

	private new void Awake()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += DNMGKFDLLBJ;
	}

	private void JJNMKIAJPNA()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.AMMDOBIMILE(IAJAILAGAKC);
		}
	}

	private void NAMPFPOLLDA()
	{
		StartCoroutine(HDKCFAMJBBO());
	}

	private void MMILIILOCIB()
	{
		StartCoroutine(DEKLNBDGOML());
	}

	private void ECMMDCKONDK()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(HLKOPCJHLJB);
	}

	private void CLAKINKPCHA()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.KNBNJDOECDN(IAJAILAGAKC);
		}
	}

	private void EKKMHDJLFHJ()
	{
		StartCoroutine(KHLDOFCPOED());
	}

	private void OFGNCBEDPPJ()
	{
		StartCoroutine(ECBMHNDPENI());
	}

	private void EJFMJDFPGFE()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OFGNCBEDPPJ;
	}

	private IEnumerator NBBAANHAAKK()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void BAGCDJMLCPF()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(AEPBKPJLCKA);
	}

	private IEnumerator PMKGPBMAMAG()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private IEnumerator MGKMBCBBOHK()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void HKPIHGBKAHO()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.GIHFOHBBHPM(IAJAILAGAKC);
		}
	}

	private void FADMNOLLJFG()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.GIHFOHBBHPM(IAJAILAGAKC);
		}
	}

	private void GEPHFAECCII()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += FLINBPKBKAO;
	}

	private void PAPFKMJEMML()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += FLINBPKBKAO;
	}

	private IEnumerator LJJFPIDAFJP()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void ANLFCJJCGMG()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.CONNCKLPNBI(IAJAILAGAKC);
		}
	}

	private IEnumerator FJILILFMPIF()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void MECAOCJKMKN()
	{
		Singleton<BeanstalkServerManager>.instance.CDLHKFMEJHL(NAMPFPOLLDA);
	}

	private void FAGACKDHBKC()
	{
		StartCoroutine(LJJFPIDAFJP());
	}

	private void LCBBILLHHPI()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.GIHFOHBBHPM(IAJAILAGAKC);
		}
	}

	private void CPFDALHPFJI()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += FLINBPKBKAO;
	}

	private IEnumerator PFNBDPFAKBN()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void ACLBKBJEJIB()
	{
		StartCoroutine(GOLIFONLLPC());
	}

	private IEnumerator GLMKGLKCDAL()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void MKDDAEADIDO()
	{
		StartCoroutine(DONHNAIKMCB());
	}

	private void CJPFLJAAODD()
	{
		foreach (HeadSizeSetter item in CPJEMPNEJMF)
		{
			item.scaleF = IAJAILAGAKC;
		}
	}

	private IEnumerator JLCJIIOIFOD()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}

	private void FOHEGBBHFJH()
	{
		StartCoroutine(DJNMPLKPENF());
	}

	private void FLINBPKBKAO()
	{
		StartCoroutine(IFDIKMKGDPG());
	}

	private void OLBEOPKDEBJ()
	{
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += KGMANMDFKHO;
	}

	private void APKMLOOGOFK()
	{
		StartCoroutine(GNKIMPLPOPA());
	}

	private IEnumerator EMHGOECGAFL()
	{
		OEDCMGHNIDF oEDCMGHNIDF = new OEDCMGHNIDF();
		oEDCMGHNIDF.BJGCPDNMHDH = this;
		return oEDCMGHNIDF;
	}
}
