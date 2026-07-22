using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class InstantBattleAnimation : Core_BaseScript
{
	[Serializable]
	private class EnemyDefinition
	{
		public Transform position;

		public Transform shootPosition;

		public LevelBehaviour unitBehavior;

		internal EnemyController mInstance;

		internal int mHits;
	}

	private sealed class GBBLMONGGIK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal InstantBattleAnimation BJGCPDNMHDH;

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
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				PhotonConnectionManager.JoinOfflineGame();
				BJGCPDNMHDH.CMECCANLHID();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				AtlasPreparer.NIDHBANDNGD(BJGCPDNMHDH.ELACEBHNONC);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NMPEHBBNNJI());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				BJGCPDNMHDH.camera.gameObject.SetActive(value: false);
				PHDOCKCBJOF = new WaitForSeconds(1142f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				if (BJGCPDNMHDH.JCCMJHJBJCM != null)
				{
					BJGCPDNMHDH.JCCMJHJBJCM();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public GBBLMONGGIK()
		{
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
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
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				PhotonConnectionManager.JoinOfflineGame();
				BJGCPDNMHDH.FGOBFIPGJID();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				AtlasPreparer.AHMFKCKJMCI(BJGCPDNMHDH.ELACEBHNONC);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.AGEIMIBOCIN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				BJGCPDNMHDH.camera.gameObject.SetActive(value: false);
				PHDOCKCBJOF = new WaitForSeconds(448f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				if (BJGCPDNMHDH.JCCMJHJBJCM != null)
				{
					BJGCPDNMHDH.JCCMJHJBJCM();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.DKOBPLBBBEG = false;
				PhotonConnectionManager.JoinOfflineGame();
				BJGCPDNMHDH.HCMHFHABJHL();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				AtlasPreparer.NIDHBANDNGD(BJGCPDNMHDH.ELACEBHNONC);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FJKKFDIAFAB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				BJGCPDNMHDH.camera.gameObject.SetActive(value: false);
				PHDOCKCBJOF = new WaitForSeconds(1690f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				if (BJGCPDNMHDH.JCCMJHJBJCM != null)
				{
					BJGCPDNMHDH.JCCMJHJBJCM();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				PhotonConnectionManager.JoinOfflineGame();
				BJGCPDNMHDH.JMMLEIGCPOK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				AtlasPreparer.Load2DToolkitTexture(BJGCPDNMHDH.ELACEBHNONC);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMCMKIGMEHA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				BJGCPDNMHDH.camera.gameObject.SetActive(value: true);
				PHDOCKCBJOF = new WaitForSeconds(0.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				if (BJGCPDNMHDH.JCCMJHJBJCM != null)
				{
					BJGCPDNMHDH.JCCMJHJBJCM();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GJMNLPAEIDA()
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
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
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
				BJGCPDNMHDH.DKOBPLBBBEG = false;
				PhotonConnectionManager.JoinOfflineGame();
				BJGCPDNMHDH.JMMLEIGCPOK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				AtlasPreparer.NAFKNNCEEFO(BJGCPDNMHDH.ELACEBHNONC);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMCMKIGMEHA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				BJGCPDNMHDH.camera.gameObject.SetActive(value: false);
				PHDOCKCBJOF = new WaitForSeconds(392f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				if (BJGCPDNMHDH.JCCMJHJBJCM != null)
				{
					BJGCPDNMHDH.JCCMJHJBJCM();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class COODLABPHEE : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<EnemyDefinition>.Enumerator KFCAECGLKKO;

		internal EnemyDefinition BMFHDLEHANM;

		internal LevelBehaviour DCIAJLJEHEN;

		internal AIObject NEMLKKBGIKJ;

		internal InstantBattleAnimation BJGCPDNMHDH;

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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[DebuggerHidden]
		public COODLABPHEE()
		{
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public bool BJIPDEICIML()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 59u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.INOJHPIKICM().ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 410f), bought: true, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DAKMHLEGICB()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 44u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.ADBOHNCGKHA().FLKHKLDOAPD(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 514f), bought: true, mine: true, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		public void FOODPOJODAA()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool DEEBEBGBMKK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 54u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.GLHPLCEFHGD().CNEDMJIOECH(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 582f), bought: true, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01e9;
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
				IL_01e9:
				return false;
			}
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void HHCBBENDENJ()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void OEMOMDILPEE()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void MPKODAJAPFD()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void IBLNBELFKNF()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		public bool ONFBKOEOIOC()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 127u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().IJKKOCDFLAF(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1052f), bought: true, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		public bool GCEBFCBBEKM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 1u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.COJFMKNGPBP().FLKHKLDOAPD(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							enemyController.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: true);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1124f), bought: false, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public bool HEHJAEIGHDN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967266u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.CHHLLIAHECC().IONKGACHEBC(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: true);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1749f), bought: false, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		public void LFIGPJBHPBH()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
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

		[SpecialName]
		private object COEKBAFPBLD()
		{
			return PHDOCKCBJOF;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public void PCNOHGFPMOE()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
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
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void HNBFJFDLABI()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void GGDBAJJAHNO()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MFNFCFAJKCM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
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
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 43u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.MFKPDKCLDBI().ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1760f), bought: true, mine: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGKHIPOBGP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967278u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.GLHPLCEFHGD().FLKHKLDOAPD(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							enemyController.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: true);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1247f), bought: true, mine: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool LHBPPCGLHDI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967247u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.KKCMCNCCIMB().PKFDDOIEMMC(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1954f), bought: false, mine: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		public void ODCIKOOGNFG()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool LLOCENNFFFJ()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 103u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.INOJHPIKICM().ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							enemyController.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 970f), bought: true, mine: true, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return false;
			}
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		public bool PMCFLKAJNHO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967180u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 0u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.EHFPBDJMGNC().PKFDDOIEMMC(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 1;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 614f), bought: false, mine: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return false;
			}
		}

		public bool NAMPBIHOFGI()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 105u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.networkPool.FLKHKLDOAPD(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 980f), bought: false, mine: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return false;
			}
		}

		public void HHCIHDMICFP()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void CNMNAHEINED()
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
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: true);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN), bought: true, mine: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public bool EJKHEELJJFM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967254u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().CNEDMJIOECH(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1873f), bought: false, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
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
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public bool BIGKCFMEBJE()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 72u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().IONKGACHEBC(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							enemyController.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1453f), bought: true, mine: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return false;
			}
		}

		public bool DFMKKFMEBON()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 52u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = true;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.DKNHCGGKNMF().KBBMHOCIMCE(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: true);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 1952f), bought: true, mine: false, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return true;
			}
		}

		public bool IEDGDDDADFM()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.enemies.GetEnumerator();
				num = 4294967241u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					case 1u:
						NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(DCIAJLJEHEN);
						if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
						{
							NEMLKKBGIKJ.LCDBACDIODH = false;
							NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
							EnemyController enemyController = (EnemyController)ObjectPoolDatabase.GLHPLCEFHGD().ReInstantiate(NEMLKKBGIKJ);
							enemyController.transform.parent = BJGCPDNMHDH.transform;
							enemyController.transform.position = BMFHDLEHANM.position.position;
							enemyController.transform.rotation = Quaternion.LookRotation(BJGCPDNMHDH.mPlayerPoint.transform.position - BMFHDLEHANM.position.position);
							enemyController.UpdatePreview(OPGMAEDPFML: false);
							enemyController.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
							BMFHDLEHANM.mInstance = enemyController;
							BMFHDLEHANM.mHits = 0;
						}
						break;
					}
					if (KFCAECGLKKO.MoveNext())
					{
						BMFHDLEHANM = KFCAECGLKKO.Current;
						DCIAJLJEHEN = BMFHDLEHANM.unitBehavior;
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DCIAJLJEHEN.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(DCIAJLJEHEN, 733f), bought: false, mine: true, unloadWeapon: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = false;
						goto IL_01e9;
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
				IL_01e9:
				return false;
			}
		}

		[SpecialName]
		private object IJBDKMGNEPK()
		{
			return PHDOCKCBJOF;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class LNLNIBKBKOK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerController GFHGBIGFMBM;

		internal PlayerWeapon GDKNGDHLNDH;

		internal int FDCGIINEHPB;

		internal EnemyDefinition OHMIBOHDGEN;

		internal int KOHFPOKABAE;

		internal int BILONKHLPEE;

		internal float CAAJBIBJDNN;

		internal InstantBattleAnimation BJGCPDNMHDH;

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

		public void PHKDHCJBMII()
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
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				TimeManager.EEODMCJPDNI(1403f, 1694f, 828f);
				PHDOCKCBJOF = new WaitForSeconds(422f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GFHGBIGFMBM = CamosManager.instance.mainPlayer;
				GDKNGDHLNDH = GFHGBIGFMBM.weaponInventory.OLHICLNCPNA();
				FDCGIINEHPB = 1;
				goto IL_0244;
			case 2u:
				if (!GDKNGDHLNDH.weapon.willShoot)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateMedium);
				GDKNGDHLNDH.ANCEHNGCFHI(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[0].transform.position);
				PHDOCKCBJOF = new WaitForSeconds(1594f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				if (KOHFPOKABAE == 0)
				{
					GuiScreenSingle<InstantBattleResultsScreen>.instance.DNILOFDIEKO(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[0].transform.position, FDCGIINEHPB);
				}
				CAAJBIBJDNN = ((FDCGIINEHPB != 0 || KOHFPOKABAE != 0) ? 94f : 1034f);
				PHDOCKCBJOF = new WaitForSeconds(CAAJBIBJDNN);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				KOHFPOKABAE += 0;
				goto IL_0206;
			case 5u:
				FDCGIINEHPB++;
				goto IL_0244;
			default:
				{
					return false;
				}
				IL_0206:
				if (KOHFPOKABAE < 4)
				{
					BILONKHLPEE = OHMIBOHDGEN.mHits;
					goto case 2u;
				}
				PHDOCKCBJOF = new WaitForSeconds(952f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
				IL_0244:
				if (FDCGIINEHPB < BJGCPDNMHDH.enemies.Count)
				{
					OHMIBOHDGEN = BJGCPDNMHDH.enemies[FDCGIINEHPB];
					KOHFPOKABAE = 0;
					goto IL_0206;
				}
				if (BJGCPDNMHDH.DEMPDFONJIF != null)
				{
					BJGCPDNMHDH.DEMPDFONJIF();
				}
				CLPPIAGLCJJ = -1;
				goto default;
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
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				TimeManager.Begin(0f, 1f, 1f);
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GFHGBIGFMBM = CamosManager.instance.mainPlayer;
				GDKNGDHLNDH = GFHGBIGFMBM.weaponInventory.currentWeapon;
				FDCGIINEHPB = 0;
				goto IL_0244;
			case 2u:
				if (!GDKNGDHLNDH.weapon.willShoot)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateLight);
				GDKNGDHLNDH.ShootForBot(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[1].transform.position);
				PHDOCKCBJOF = new WaitForSeconds(0.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				if (KOHFPOKABAE == 0)
				{
					GuiScreenSingle<InstantBattleResultsScreen>.instance.ShowLabels(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[1].transform.position, FDCGIINEHPB);
				}
				CAAJBIBJDNN = ((FDCGIINEHPB != 0 || KOHFPOKABAE != 0) ? 0.1f : 0.2f);
				PHDOCKCBJOF = new WaitForSeconds(CAAJBIBJDNN);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				KOHFPOKABAE++;
				goto IL_0206;
			case 5u:
				FDCGIINEHPB++;
				goto IL_0244;
			default:
				{
					return false;
				}
				IL_0206:
				if (KOHFPOKABAE < 3)
				{
					BILONKHLPEE = OHMIBOHDGEN.mHits;
					goto case 2u;
				}
				PHDOCKCBJOF = new WaitForSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
				IL_0244:
				if (FDCGIINEHPB < BJGCPDNMHDH.enemies.Count)
				{
					OHMIBOHDGEN = BJGCPDNMHDH.enemies[FDCGIINEHPB];
					KOHFPOKABAE = 0;
					goto IL_0206;
				}
				if (BJGCPDNMHDH.DEMPDFONJIF != null)
				{
					BJGCPDNMHDH.DEMPDFONJIF();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				TimeManager.EEODMCJPDNI(634f, 1624f, 506f);
				PHDOCKCBJOF = new WaitForSeconds(1298f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GFHGBIGFMBM = CamosManager.instance.mainPlayer;
				GDKNGDHLNDH = GFHGBIGFMBM.FMKGGADDHJK().MFHBEJOLGLC();
				FDCGIINEHPB = 1;
				goto IL_0244;
			case 2u:
				if (!GDKNGDHLNDH.weapon.willShoot)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateLight);
				GDKNGDHLNDH.ShootForBot(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[1].transform.position);
				PHDOCKCBJOF = new WaitForSeconds(1642f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				if (KOHFPOKABAE == 0)
				{
					GuiScreenSingle<InstantBattleResultsScreen>.instance.PFKJKDJBBAL(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[0].transform.position, FDCGIINEHPB);
				}
				CAAJBIBJDNN = ((FDCGIINEHPB != 0 || KOHFPOKABAE != 0) ? 1969f : 1901f);
				PHDOCKCBJOF = new WaitForSeconds(CAAJBIBJDNN);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				KOHFPOKABAE += 0;
				goto IL_0206;
			case 5u:
				FDCGIINEHPB += 0;
				goto IL_0244;
			default:
				{
					return true;
				}
				IL_0206:
				if (KOHFPOKABAE < 7)
				{
					BILONKHLPEE = OHMIBOHDGEN.mHits;
					goto case 2u;
				}
				PHDOCKCBJOF = new WaitForSeconds(186f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0244:
				if (FDCGIINEHPB < BJGCPDNMHDH.enemies.Count)
				{
					OHMIBOHDGEN = BJGCPDNMHDH.enemies[FDCGIINEHPB];
					KOHFPOKABAE = 1;
					goto IL_0206;
				}
				if (BJGCPDNMHDH.DEMPDFONJIF != null)
				{
					BJGCPDNMHDH.DEMPDFONJIF();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.DKOBPLBBBEG = true;
				TimeManager.HLPIDFMBIEG(0f, 387f, 470f);
				PHDOCKCBJOF = new WaitForSeconds(852f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GFHGBIGFMBM = CamosManager.instance.mainPlayer;
				GDKNGDHLNDH = GFHGBIGFMBM.FMKGGADDHJK().currentWeapon;
				FDCGIINEHPB = 1;
				goto IL_0244;
			case 2u:
				if (!GDKNGDHLNDH.weapon.willShoot)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateLight);
				GDKNGDHLNDH.MFGIHHMKGLA(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[0].transform.position);
				PHDOCKCBJOF = new WaitForSeconds(340f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				if (KOHFPOKABAE == 0)
				{
					GuiScreenSingle<InstantBattleResultsScreen>.instance.AJHJLBIEOLJ(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[1].transform.position, FDCGIINEHPB);
				}
				CAAJBIBJDNN = ((FDCGIINEHPB != 0 || KOHFPOKABAE != 0) ? 1050f : 247f);
				PHDOCKCBJOF = new WaitForSeconds(CAAJBIBJDNN);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				KOHFPOKABAE += 0;
				goto IL_0206;
			case 5u:
				FDCGIINEHPB += 0;
				goto IL_0244;
			default:
				{
					return false;
				}
				IL_0206:
				if (KOHFPOKABAE < 5)
				{
					BILONKHLPEE = OHMIBOHDGEN.mHits;
					goto case 2u;
				}
				PHDOCKCBJOF = new WaitForSeconds(1965f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
				IL_0244:
				if (FDCGIINEHPB < BJGCPDNMHDH.enemies.Count)
				{
					OHMIBOHDGEN = BJGCPDNMHDH.enemies[FDCGIINEHPB];
					KOHFPOKABAE = 0;
					goto IL_0206;
				}
				if (BJGCPDNMHDH.DEMPDFONJIF != null)
				{
					BJGCPDNMHDH.DEMPDFONJIF();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public LNLNIBKBKOK()
		{
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.DKOBPLBBBEG = false;
				TimeManager.Begin(1716f, 1827f, 578f);
				PHDOCKCBJOF = new WaitForSeconds(477f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GFHGBIGFMBM = CamosManager.instance.mainPlayer;
				GDKNGDHLNDH = GFHGBIGFMBM.BEIIOAIJMFK().CILCMCDCKKE();
				FDCGIINEHPB = 1;
				goto IL_0244;
			case 2u:
				if (!GDKNGDHLNDH.weapon.willShoot)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateMedium);
				GDKNGDHLNDH.MNIJGBAKEKA(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[0].transform.position);
				PHDOCKCBJOF = new WaitForSeconds(104f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				if (KOHFPOKABAE == 0)
				{
					GuiScreenSingle<InstantBattleResultsScreen>.instance.ENKAOBJGDCH(OHMIBOHDGEN.mInstance.OJIHGNJFPFM.AMEELJHHGKP[1].transform.position, FDCGIINEHPB);
				}
				CAAJBIBJDNN = ((FDCGIINEHPB != 0 || KOHFPOKABAE != 0) ? 955f : 355f);
				PHDOCKCBJOF = new WaitForSeconds(CAAJBIBJDNN);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				KOHFPOKABAE += 0;
				goto IL_0206;
			case 5u:
				FDCGIINEHPB += 0;
				goto IL_0244;
			default:
				{
					return false;
				}
				IL_0206:
				if (KOHFPOKABAE < 7)
				{
					BILONKHLPEE = OHMIBOHDGEN.mHits;
					goto case 2u;
				}
				PHDOCKCBJOF = new WaitForSeconds(1078f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
				IL_0244:
				if (FDCGIINEHPB < BJGCPDNMHDH.enemies.Count)
				{
					OHMIBOHDGEN = BJGCPDNMHDH.enemies[FDCGIINEHPB];
					KOHFPOKABAE = 0;
					goto IL_0206;
				}
				if (BJGCPDNMHDH.DEMPDFONJIF != null)
				{
					BJGCPDNMHDH.DEMPDFONJIF();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action JCCMJHJBJCM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action DEMPDFONJIF;

	[SerializeField]
	private PlayerPoint mPlayerPoint;

	[SerializeField]
	private List<EnemyDefinition> enemies;

	[SerializeField]
	private new Camera camera;

	private bool DKOBPLBBBEG;

	private string ELACEBHNONC = "spriteCollectionTextureCompressed";

	public event Action Showed
	{
		add
		{
			Action action = JCCMJHJBJCM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = JCCMJHJBJCM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action Finished
	{
		add
		{
			Action action = DEMPDFONJIF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DEMPDFONJIF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void AJPBBLOKBFC()
	{
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance != null)
			{
				enemy.mInstance.DestroyPooled(DCDEEADIGEH: false);
			}
			if (enemy.unitBehavior != null)
			{
				enemy.unitBehavior.Unload();
			}
		}
	}

	public void Show()
	{
		StopAllCoroutines();
		StartCoroutine(OOHABIKPOIH());
	}

	private IEnumerator MHKIDBEGCEE()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	[SpecialName]
	public void CGJKDPCDOEK(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IFNNJIIJOHI(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FMKLDIJPHIH()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon currentWeapon = mainPlayer.weaponInventory.currentWeapon;
			currentWeapon.GFPIFCCPLIP();
		}
	}

	[SpecialName]
	public void KBJLMICLPAO(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void Hide()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = false;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		DestroyEnemies();
		AtlasPreparer.UnLoad2DToolkitTexture(ELACEBHNONC);
	}

	[SpecialName]
	public void GFOOCOFHODP(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void HHJPPKCGPBO(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void BGIHCBGLPDF()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = (GHPGNELIDBM)4;
		mainPlayer.OCMDJMNFNKF(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.FMKGGADDHJK().NANJBGIGNCG();
		playerWeapon.weapon.ammoLeftInClip = 98;
		playerWeapon.HFNAMMBPJAJ().FIMMGPLLLCL = 13;
		playerWeapon.weapon.JMDLKIAKOIE = 237f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1489f;
		}
		Singleton<SoundsManager3D>.instance.LFAJDEMMCEJ(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 816f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.weapon.BEACDIILBEG, IAFJJMFIPCG: true);
	}

	public void NFFMGBDNDLG()
	{
		StopAllCoroutines();
		StartCoroutine(JDFKIMJGGBI());
	}

	private IEnumerator FJKKFDIAFAB()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private void PHHECPLFHLL(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 1)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 148f
					});
				}
			}
		}
	}

	private void JDJOELGIBOJ(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 3)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 5f
					});
				}
			}
		}
	}

	private void GAGMBMKPGGI()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = GHPGNELIDBM.None;
		mainPlayer.currentPlayerPoint = new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		};
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: true);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.GFCDMMGDFJK().ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().JNFHKEJCIIA();
		playerWeapon.weapon.ammoLeftInClip = -27;
		playerWeapon.weapon.FIMMGPLLLCL = 96;
		playerWeapon.weapon.JMDLKIAKOIE = 1328f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1237f;
		}
		Singleton<SoundsManager3D>.instance.DAABKJOGCHB(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1198f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.GFCDMMGDFJK().Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG);
	}

	private void HDCLMJFIEGI()
	{
		camera.gameObject.SetActive(value: true);
		Weapon.OnShotHit += MBPFAOKADPN;
	}

	private void IKELMACGPNN()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = GHPGNELIDBM.Allies;
		mainPlayer.currentPlayerPoint = new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		};
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.weaponInventory.LJELEJEJIEB();
		playerWeapon.HFNAMMBPJAJ().ammoLeftInClip = 42;
		playerWeapon.HFNAMMBPJAJ().FIMMGPLLLCL = 84;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 865f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1140f;
		}
		Singleton<SoundsManager3D>.instance.LFAJDEMMCEJ(playerWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1609f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.GFCDMMGDFJK().Idle(playerWeapon.weapon.BEACDIILBEG, IAFJJMFIPCG: true);
	}

	public void EAPELDOEDIN()
	{
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance != null)
			{
				enemy.mInstance.CADILLCGODA(DCDEEADIGEH: false);
			}
			if (enemy.unitBehavior != null)
			{
				enemy.unitBehavior.Unload();
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator MEDHJHCCKOL()
	{
		LNLNIBKBKOK lNLNIBKBKOK = new LNLNIBKBKOK();
		lNLNIBKBKOK.BJGCPDNMHDH = this;
		return lNLNIBKBKOK;
	}

	private void LHGMJBJECBJ()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = GHPGNELIDBM.Allies;
		mainPlayer.HCOKNKCCPEK(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.weaponInventory.PDLFJEDGLAO();
		playerWeapon.HFNAMMBPJAJ().ammoLeftInClip = -79;
		playerWeapon.weapon.FIMMGPLLLCL = -104;
		playerWeapon.weapon.JMDLKIAKOIE = 1489f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1839f;
		}
		Singleton<SoundsManager3D>.instance.DAABKJOGCHB(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 109f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.GFCDMMGDFJK().Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG, IAFJJMFIPCG: true);
	}

	public Camera IMNAMKCOOHD()
	{
		return camera;
	}

	public void DBECAIDOHAM()
	{
		StartCoroutine(MEDHJHCCKOL());
	}

	[SpecialName]
	public void HEFBMNMKCOF(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void BJGDGMDOKLH()
	{
		StopAllCoroutines();
		StartCoroutine(OOHABIKPOIH());
	}

	[SpecialName]
	public void JPOCAIDPFEJ(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator JFOECCDMDAN()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private void FIGOGIMJIIN()
	{
		camera.gameObject.SetActive(value: false);
		Weapon.OnShotHit += PIKLDAABPJP;
	}

	private void JMMLEIGCPOK()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.InitPlayerForCamera();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = GHPGNELIDBM.Allies;
		mainPlayer.currentPlayerPoint = new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		};
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: true);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon currentWeapon = mainPlayer.weaponInventory.currentWeapon;
		currentWeapon.weapon.ammoLeftInClip = 20;
		currentWeapon.weapon.FIMMGPLLLCL = 20;
		currentWeapon.weapon.JMDLKIAKOIE = 0.12f;
		LightMachinegun lightMachinegun = currentWeapon.weapon as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 0f;
		}
		Singleton<SoundsManager3D>.instance.LoadNow(currentWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 2f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(currentWeapon.weapon.BEACDIILBEG);
	}

	public void PGMBLCHLMBL()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().NANJBGIGNCG();
			playerWeapon.CPIOHBLIMLH();
		}
	}

	public void FLPMCCFHKJN()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon currentWeapon = mainPlayer.BEIIOAIJMFK().currentWeapon;
			currentWeapon.UpdateWeapon();
		}
	}

	public void MLKFDFHPJNI()
	{
		StartCoroutine(HBPBJDAJLKG());
	}

	private IEnumerator IELGJAAKNFL()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private IEnumerator MICHBNOOJFJ()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	[DebuggerHidden]
	private IEnumerator OOHABIKPOIH()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	public Camera KPHAOGCIMCE()
	{
		return camera;
	}

	private void EDMCHBIJAID(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits += 0;
				if (enemy.mHits == 8)
				{
					enemy.mInstance.KGJNBKNHNDB(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 1644f
					});
				}
			}
		}
	}

	public void HNOBCHFHPNF()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon currentWeapon = mainPlayer.FMKGGADDHJK().currentWeapon;
			currentWeapon.MJNGGEJFMNF();
		}
	}

	public Camera GetCamera()
	{
		return camera;
	}

	private void KODJIPJGFPB()
	{
		camera.gameObject.SetActive(value: true);
		Weapon.OnShotHit += PHHECPLFHLL;
	}

	public void APPLKHHGLAM()
	{
		StartCoroutine(MEDHJHCCKOL());
	}

	[SpecialName]
	public void ENCKGCIAMGL(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator PAMAIECBPDF()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	public void KNIAAECLFFK()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.BEIIOAIJMFK().OLHICLNCPNA();
			playerWeapon.OPEICEBMFLF();
		}
	}

	public void NKKBKBJDGDJ()
	{
		StopAllCoroutines();
		StartCoroutine(LJGIJBCGMPB());
	}

	[SpecialName]
	public void DBAOPLGKIFD(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void Update()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon currentWeapon = mainPlayer.weaponInventory.currentWeapon;
			currentWeapon.UpdateWeapon();
		}
	}

	public void DestroyEnemies()
	{
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance != null)
			{
				enemy.mInstance.DestroyPooled(DCDEEADIGEH: true);
			}
			if (enemy.unitBehavior != null)
			{
				enemy.unitBehavior.Unload();
			}
		}
	}

	public void BJGOJDGMIBI()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.BEIIOAIJMFK().JNFHKEJCIIA();
			playerWeapon.UpdateWeapon();
		}
	}

	private IEnumerator LJGIJBCGMPB()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	private IEnumerator IHBAHCPJHDB()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	private void MEBKCEOPGAD()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = (GHPGNELIDBM)7;
		mainPlayer.HCOKNKCCPEK(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.GFCDMMGDFJK().ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.FMKGGADDHJK().LJELEJEJIEB();
		playerWeapon.weapon.ammoLeftInClip = -70;
		playerWeapon.weapon.FIMMGPLLLCL = 117;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1826f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1702f;
		}
		Singleton<SoundsManager3D>.instance.LoadNow(playerWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 892f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.weapon.BEACDIILBEG, IAFJJMFIPCG: true);
	}

	private void GILPNKCLMDI()
	{
		camera.gameObject.SetActive(value: true);
		Weapon.OnShotHit += MHHEGHNGPME;
	}

	private IEnumerator JHJNAJPIPBF()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	private void DPPGEAHBEOD(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits += 0;
				if (enemy.mHits == 1)
				{
					enemy.mInstance.KGJNBKNHNDB(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 309f
					});
				}
			}
		}
	}

	private void IOFFBEIKMON()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.InitPlayerForCamera();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = (GHPGNELIDBM)7;
		mainPlayer.currentPlayerPoint = new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		};
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: true);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.BEIIOAIJMFK().JECOEJBGKDF();
		playerWeapon.weapon.ammoLeftInClip = -66;
		playerWeapon.weapon.FIMMGPLLLCL = 57;
		playerWeapon.weapon.JMDLKIAKOIE = 361f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 413f;
		}
		Singleton<SoundsManager3D>.instance.IEOECINDBLK(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1993f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG, IAFJJMFIPCG: true);
	}

	private IEnumerator FEFKNBEHENL()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private IEnumerator IOJGKBKKDMF()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	public void NMBHFCGOKMK()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = false;
		camera.gameObject.SetActive(value: true);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		EAPELDOEDIN();
		AtlasPreparer.IJEHLOFHGPJ(ELACEBHNONC);
	}

	public void LDGKPCDJPLA()
	{
		StopAllCoroutines();
		StartCoroutine(JDFKIMJGGBI());
	}

	public void CKOKMAAFHMO()
	{
		StartCoroutine(HBPBJDAJLKG());
	}

	private void HCMHFHABJHL()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.InitPlayerForCamera();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = (GHPGNELIDBM)3;
		mainPlayer.CMKNJFHHOHA(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.GFCDMMGDFJK().ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().PDLFJEDGLAO();
		playerWeapon.weapon.ammoLeftInClip = 29;
		playerWeapon.weapon.FIMMGPLLLCL = 4;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1572f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1511f;
		}
		Singleton<SoundsManager3D>.instance.DAABKJOGCHB(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 551f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG);
	}

	[SpecialName]
	public void PAOAIAGBJDI(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator AOFPIOICOJE()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	[SpecialName]
	public void HDIACIDCDED(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void ODCHMDEHCLB(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator GLNBJBKNDIA()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	private IEnumerator JDFKIMJGGBI()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	public Camera AAKOCEAAMEP()
	{
		return camera;
	}

	public void CJBJGDCNLOG()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().APLKMLDHMDL();
			playerWeapon.ELDLIOIOMEK();
		}
	}

	private void GBGDKNIMGMB()
	{
		camera.gameObject.SetActive(value: true);
		Weapon.OnShotHit += PHHECPLFHLL;
	}

	public void CPDMEMIJCMN()
	{
		StartCoroutine(HBPBJDAJLKG());
	}

	[SpecialName]
	public void MMBANPAJAMC(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MPDCCJGMOHB(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator HBPBJDAJLKG()
	{
		LNLNIBKBKOK lNLNIBKBKOK = new LNLNIBKBKOK();
		lNLNIBKBKOK.BJGCPDNMHDH = this;
		return lNLNIBKBKOK;
	}

	[SpecialName]
	public void NGJNCICGJGA(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public Camera JMFBPOGMPDA()
	{
		return camera;
	}

	public void ALKFOHIAKOM()
	{
		StopAllCoroutines();
		StartCoroutine(GLNBJBKNDIA());
	}

	[SpecialName]
	public void LIJFADLOGJA(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void OJHFLGHOJPI(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void AOKEGBCHEGM()
	{
		StartCoroutine(MEDHJHCCKOL());
	}

	private void MHHEGHNGPME(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 2)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 936f
					});
				}
			}
		}
	}

	private void MBPFAOKADPN(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits += 0;
				if (enemy.mHits == 6)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 1822f
					});
				}
			}
		}
	}

	private new void Awake()
	{
		camera.gameObject.SetActive(value: false);
		Weapon.OnShotHit += JDJOELGIBOJ;
	}

	public void LHJAGNOOBAF()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().LJELEJEJIEB();
			playerWeapon.OPEICEBMFLF();
		}
	}

	private void IEDPAAMNBDN()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.InitPlayerForCamera();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = GHPGNELIDBM.Enemies;
		mainPlayer.currentPlayerPoint = new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		};
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: true);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.GFCDMMGDFJK().ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.FMKGGADDHJK().JNFHKEJCIIA();
		playerWeapon.weapon.ammoLeftInClip = -51;
		playerWeapon.HFNAMMBPJAJ().FIMMGPLLLCL = -71;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 729f;
		LightMachinegun lightMachinegun = playerWeapon.weapon as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1584f;
		}
		Singleton<SoundsManager3D>.instance.LBHHEPFBKAP(playerWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1519f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.GFCDMMGDFJK().Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG);
	}

	private void AMGECNFKJNA(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 1)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 1424f
					});
				}
			}
		}
	}

	private void IEPNHLLGDOF(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 4)
				{
					enemy.mInstance.KGJNBKNHNDB(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 1544f
					});
				}
			}
		}
	}

	private IEnumerator PLIMPCLMOIC()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	[SpecialName]
	public void OKHJDAFOHFL(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KBNEKMPFIHL(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void GIHJKCGLGEB()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.BEIIOAIJMFK().JNFHKEJCIIA();
			playerWeapon.BNAEGDKLBBJ();
		}
	}

	[SpecialName]
	public void MOMABGHGLEL(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void OFLIPLBGEGO()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = false;
		camera.gameObject.SetActive(value: true);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		DNKNIDMKPMH();
		AtlasPreparer.BPJKENEMBFI(ELACEBHNONC);
	}

	private IEnumerator DMKBEOCAEOJ()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private void FGOBFIPGJID()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = (GHPGNELIDBM)3;
		mainPlayer.OCMDJMNFNKF(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().MFHBEJOLGLC();
		playerWeapon.HFNAMMBPJAJ().ammoLeftInClip = -43;
		playerWeapon.HFNAMMBPJAJ().FIMMGPLLLCL = 81;
		playerWeapon.weapon.JMDLKIAKOIE = 404f;
		LightMachinegun lightMachinegun = playerWeapon.weapon as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1764f;
		}
		Singleton<SoundsManager3D>.instance.ILPFLHMDNBD(playerWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1448f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG);
	}

	[SpecialName]
	public void LJMOLOCEMFA(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void IKAIKLAJLEE()
	{
		StopAllCoroutines();
		StartCoroutine(MICHBNOOJFJ());
	}

	public void MNFDMKFLAKO()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.FMKGGADDHJK().JKHKBGPKFFF();
			playerWeapon.UpdateWeapon();
		}
	}

	private void GKCIBGNEEPE()
	{
		camera.gameObject.SetActive(value: false);
		Weapon.OnShotHit += JDJOELGIBOJ;
	}

	private void BLGFJHJJFPL(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits += 0;
				if (enemy.mHits == 0)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 1777f
					});
				}
			}
		}
	}

	public void DIOAOBFDPMH()
	{
		if (DKOBPLBBBEG)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().PDLFJEDGLAO();
			playerWeapon.UpdateWeapon();
		}
	}

	public void MPLOCJMIAOG()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = true;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		EAPELDOEDIN();
		AtlasPreparer.FAAEAAPHHCB(ELACEBHNONC);
	}

	[SpecialName]
	public void ELDPFCOCBBJ(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void NGNOALDFNAJ()
	{
		StartCoroutine(HBPBJDAJLKG());
	}

	public void APONLMFKLOD()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = true;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		EAPELDOEDIN();
		AtlasPreparer.BPJKENEMBFI(ELACEBHNONC);
	}

	[SpecialName]
	public void DMOIPOBEBAN(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[DebuggerHidden]
	private IEnumerator DMCMKIGMEHA()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private void NNNFOOJBDGA(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits += 0;
				if (enemy.mHits == 2)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 393f
					});
				}
			}
		}
	}

	public Camera AHFLKBNABJI()
	{
		return camera;
	}

	private void LCLEKFMLENA()
	{
		camera.gameObject.SetActive(value: false);
		Weapon.OnShotHit += IEPNHLLGDOF;
	}

	[SpecialName]
	public void PGPNFIFNJFB(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void EEMLMJCHKLM()
	{
		camera.gameObject.SetActive(value: true);
		Weapon.OnShotHit += EDMCHBIJAID;
	}

	private void DIPCEKBIPIM()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = GHPGNELIDBM.Allies;
		mainPlayer.OCMDJMNFNKF(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.FMKGGADDHJK().NANJBGIGNCG();
		playerWeapon.weapon.ammoLeftInClip = 73;
		playerWeapon.weapon.FIMMGPLLLCL = -37;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 864f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 492f;
		}
		Singleton<SoundsManager3D>.instance.LoadNow(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1598f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG, IAFJJMFIPCG: true);
	}

	public void DNKNIDMKPMH()
	{
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance != null)
			{
				enemy.mInstance.DestroyPooled(DCDEEADIGEH: false);
			}
			if (enemy.unitBehavior != null)
			{
				enemy.unitBehavior.Unload();
			}
		}
	}

	private IEnumerator MNEFMIBCKHH()
	{
		LNLNIBKBKOK lNLNIBKBKOK = new LNLNIBKBKOK();
		lNLNIBKBKOK.BJGCPDNMHDH = this;
		return lNLNIBKBKOK;
	}

	public void StartAnimation()
	{
		StartCoroutine(MEDHJHCCKOL());
	}

	private void PIKLDAABPJP(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 LLAOOPMGBAG, bool KLOJNPBGFIG, DestroyableObject MGECAKNCNBD)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(MGECAKNCNBD != null) || !DKOBPLBBBEG || JMMJHCOKCGG.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == MGECAKNCNBD.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 1)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.CJLNCMMNPBM
					{
						LPGMLOCLBGP = (MGECAKNCNBD.transform.position - mainPlayer.transform.position).normalized * 1807f
					});
				}
			}
		}
	}

	public void BEECKKABNFH()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = true;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		EAPELDOEDIN();
		AtlasPreparer.CGILPACEEFB(ELACEBHNONC);
	}

	[SpecialName]
	public void LHEIEIOPEOL(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void ANFCGKOMNIL()
	{
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance != null)
			{
				enemy.mInstance.DestroyPooled(DCDEEADIGEH: true);
			}
			if (enemy.unitBehavior != null)
			{
				enemy.unitBehavior.Unload();
			}
		}
	}

	[SpecialName]
	public void FHNGCHHICLD(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void EBMEGKAICPP(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator AGEIMIBOCIN()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	[SpecialName]
	public void CKMAFGIJAGK(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void CMECCANLHID()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.InitPlayerForCamera();
		mainPlayer.Preview(HDBKFKKAJLF: true);
		mainPlayer.fraction = (GHPGNELIDBM)3;
		mainPlayer.CMKNJFHHOHA(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.FMKGGADDHJK().CILCMCDCKKE();
		playerWeapon.weapon.ammoLeftInClip = 103;
		playerWeapon.weapon.FIMMGPLLLCL = -81;
		playerWeapon.weapon.JMDLKIAKOIE = 1267f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 1539f;
		}
		Singleton<SoundsManager3D>.instance.LBHHEPFBKAP(playerWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1879f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.weapon.BEACDIILBEG, IAFJJMFIPCG: true);
	}

	[SpecialName]
	public void KOHGJNMCPGG(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void FNJKBLNNCCC(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DDLLFCKHJJO()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = true;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		AJPBBLOKBFC();
		AtlasPreparer.FAAEAAPHHCB(ELACEBHNONC);
	}

	private void ADAKCGGBDLK()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = (GHPGNELIDBM)4;
		mainPlayer.HCOKNKCCPEK(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.ShadowSetActive(EIPHAAGCHCP: false);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.JLMDEMFIHCA().NANJBGIGNCG();
		playerWeapon.weapon.ammoLeftInClip = -84;
		playerWeapon.HFNAMMBPJAJ().FIMMGPLLLCL = -14;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 1694f;
		LightMachinegun lightMachinegun = playerWeapon.HFNAMMBPJAJ() as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 318f;
		}
		Singleton<SoundsManager3D>.instance.ILPFLHMDNBD(playerWeapon.HFNAMMBPJAJ().EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 0f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.GFCDMMGDFJK().Idle(playerWeapon.weapon.BEACDIILBEG, IAFJJMFIPCG: true);
	}

	[SpecialName]
	public void IAEIFGOMICH(Action IDEBKDPMPGM)
	{
		Action action = DEMPDFONJIF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DEMPDFONJIF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void GNCFLLFBLLO()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = false;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		EAPELDOEDIN();
		AtlasPreparer.CGILPACEEFB(ELACEBHNONC);
	}

	[SpecialName]
	public void FDMEEMPFIMO(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DICKLKHIMFJ()
	{
		StartCoroutine(HBPBJDAJLKG());
	}

	private void EJNJCILPBEC()
	{
		camera.gameObject.SetActive(value: true);
		Weapon.OnShotHit += AMGECNFKJNA;
	}

	public void IFGMJHLIPJL()
	{
		StopAllCoroutines();
		DKOBPLBBBEG = true;
		camera.gameObject.SetActive(value: true);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		AJPBBLOKBFC();
		AtlasPreparer.UnLoad2DToolkitTexture(ELACEBHNONC);
	}

	private IEnumerator NMPEHBBNNJI()
	{
		COODLABPHEE cOODLABPHEE = new COODLABPHEE();
		cOODLABPHEE.BJGCPDNMHDH = this;
		return cOODLABPHEE;
	}

	private void LMHNACFEFBE()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.KLFFMPINIPB();
		mainPlayer.Preview(HDBKFKKAJLF: false);
		mainPlayer.fraction = (GHPGNELIDBM)6;
		mainPlayer.OCMDJMNFNKF(new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		});
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.EFFIOHJHFHI.EFGIPEIGGDK(EIPHAAGCHCP: true);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.GFCDMMGDFJK().ForceInScreen();
		PlayerWeapon playerWeapon = mainPlayer.BEIIOAIJMFK().MFHBEJOLGLC();
		playerWeapon.HFNAMMBPJAJ().ammoLeftInClip = 21;
		playerWeapon.weapon.FIMMGPLLLCL = 23;
		playerWeapon.HFNAMMBPJAJ().JMDLKIAKOIE = 763f;
		LightMachinegun lightMachinegun = playerWeapon.weapon as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.LCAGPBBDKKN = 439f;
		}
		Singleton<SoundsManager3D>.instance.LFAJDEMMCEJ(playerWeapon.weapon.EGNEIDMAEKA);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 1751f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(playerWeapon.HFNAMMBPJAJ().BEACDIILBEG);
	}

	private void DFMALDFADAB()
	{
		camera.gameObject.SetActive(value: false);
		Weapon.OnShotHit += EDMCHBIJAID;
	}

	private IEnumerator OEOIPDHCILM()
	{
		GBBLMONGGIK gBBLMONGGIK = new GBBLMONGGIK();
		gBBLMONGGIK.BJGCPDNMHDH = this;
		return gBBLMONGGIK;
	}

	public void EHPIMALJLPB()
	{
		StopAllCoroutines();
		StartCoroutine(IHBAHCPJHDB());
	}

	public void OEAJBFLGJCA()
	{
		StopAllCoroutines();
		StartCoroutine(OOHABIKPOIH());
	}

	public void DMLDBKFCACB()
	{
		StopAllCoroutines();
		StartCoroutine(AOFPIOICOJE());
	}

	[SpecialName]
	public void HIBBEFLICOH(Action IDEBKDPMPGM)
	{
		Action action = JCCMJHJBJCM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JCCMJHJBJCM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
