using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBotTutorial : Core_BaseScript
{
	public enum GFHEEFCLGHG
	{
		Wait,
		ShootEnemies,
		ShootEnemyPlayer,
		ShootEnemyPlayerAndMoveALot
	}

	private sealed class BJCNFGGMAOD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerBotTutorial BJGCPDNMHDH;

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
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
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
				PHDOCKCBJOF = new WaitForSeconds(0.3f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.gameIsRunning && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine && BJGCPDNMHDH.ELNOOHFJBGA != GFHEEFCLGHG.Wait && BJGCPDNMHDH.playerController.currentPlayerPoint != null && UnityEngine.Random.value < BJGCPDNMHDH.FDNHLBFMLPO)
				{
					BJGCPDNMHDH.AIPKIALKOBL();
					BJGCPDNMHDH.FKNHDELHHID();
				}
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
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

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public BJCNFGGMAOD()
		{
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(316f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.KKHKIEFMENC() && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine && BJGCPDNMHDH.ELNOOHFJBGA != GFHEEFCLGHG.Wait && BJGCPDNMHDH.playerController.EMAMENNDFMB() != null && UnityEngine.Random.value < BJGCPDNMHDH.KAOJKPONEOG())
				{
					BJGCPDNMHDH.AIPKIALKOBL();
					BJGCPDNMHDH.FKNHDELHHID();
				}
				PHDOCKCBJOF = new WaitForSeconds(1926f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			default:
				return true;
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
				PHDOCKCBJOF = new WaitForSeconds(1706f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.GHKPKDPOGHF() && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine && BJGCPDNMHDH.ELNOOHFJBGA != GFHEEFCLGHG.Wait && BJGCPDNMHDH.playerController.currentPlayerPoint != null && UnityEngine.Random.value < BJGCPDNMHDH.KAOJKPONEOG())
				{
					BJGCPDNMHDH.AIPKIALKOBL();
					BJGCPDNMHDH.FKNHDELHHID();
				}
				PHDOCKCBJOF = new WaitForSeconds(221f);
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

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(156f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.gameIsRunning && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine && BJGCPDNMHDH.ELNOOHFJBGA != GFHEEFCLGHG.Wait && BJGCPDNMHDH.playerController.CMNFFACHCEE() != null && UnityEngine.Random.value < BJGCPDNMHDH.KAOJKPONEOG())
				{
					BJGCPDNMHDH.AIPKIALKOBL();
					BJGCPDNMHDH.FKNHDELHHID();
				}
				PHDOCKCBJOF = new WaitForSeconds(700f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(285f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.KKHKIEFMENC() && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine && BJGCPDNMHDH.ELNOOHFJBGA != GFHEEFCLGHG.Wait && BJGCPDNMHDH.playerController.EMAMENNDFMB() != null && UnityEngine.Random.value < BJGCPDNMHDH.FDNHLBFMLPO)
				{
					BJGCPDNMHDH.AIPKIALKOBL();
					BJGCPDNMHDH.FKNHDELHHID();
				}
				PHDOCKCBJOF = new WaitForSeconds(1560f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1297f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.gameIsRunning && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine && BJGCPDNMHDH.ELNOOHFJBGA != GFHEEFCLGHG.Wait && BJGCPDNMHDH.playerController.EMAMENNDFMB() != null && UnityEngine.Random.value < BJGCPDNMHDH.KAOJKPONEOG())
				{
					BJGCPDNMHDH.AIPKIALKOBL();
					BJGCPDNMHDH.FKNHDELHHID();
				}
				PHDOCKCBJOF = new WaitForSeconds(348f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return false;
			}
			return false;
		}
	}

	private sealed class NDMNNPLNIEB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Collider[] PEKKEOEJBIM;

		internal Collider[] KFCAECGLKKO;

		internal int GHCPBBJDIBB;

		internal List<DestroyableObject>.Enumerator CFEHCIMDPPI;

		internal PlayerBotTutorial BJGCPDNMHDH;

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
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 953f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1676f && UnityEngine.Random.value < 1430f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.weaponInventory.LPMCOFOCCAH(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(56f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 373f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1725f && UnityEngine.Random.value < 666f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.weaponInventory.LOLDJPCCFKO(BJGCPDNMHDH.ILENGKEGCJD());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1079f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1184f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1114f && UnityEngine.Random.value < 835f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().HLOKMIDGPCA(BJGCPDNMHDH.DKPPPEKMDAF());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1774f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1718f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1447f && UnityEngine.Random.value < 1647f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().LPMCOFOCCAH(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1161f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KOGGPMGMFIN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public NDMNNPLNIEB()
		{
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DOCGGPBBOAD()
		{
			return PHDOCKCBJOF;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INHIPKJFGDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		public void BGMDCMOCLBN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADALFCHPIAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OLMAFKDGMDB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 395f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 745f && UnityEngine.Random.value < 1943f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.BEIIOAIJMFK().LOLDJPCCFKO(BJGCPDNMHDH.ILENGKEGCJD());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1826f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FHOGCOKPBKL()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1386f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 861f && UnityEngine.Random.value < 1368f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.BEIIOAIJMFK().currentWeapon = BJGCPDNMHDH.BEHHGHCLNGL();
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(728f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1725f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 856f && UnityEngine.Random.value < 1475f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().HLOKMIDGPCA(BJGCPDNMHDH.GetRiffle());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(590f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLAOFCCAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void EHMOLOCPIGB()
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
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 980f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1010f && UnityEngine.Random.value < 514f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.BEIIOAIJMFK().LOLDJPCCFKO(BJGCPDNMHDH.ILENGKEGCJD());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1925f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FCBCEDKNBKC()
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
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 168f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1689f && UnityEngine.Random.value < 1217f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().LPMCOFOCCAH(BJGCPDNMHDH.DKPPPEKMDAF());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1807f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CFHJPHLFONO()
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
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1650f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1355f && UnityEngine.Random.value < 1670f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.FMKGGADDHJK().LOLDJPCCFKO(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1498f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public void LDBAMIKAGHC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FPOFCJOEAMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1937f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1987f && UnityEngine.Random.value < 440f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.weaponInventory.LPMCOFOCCAH(BJGCPDNMHDH.DKPPPEKMDAF());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(550f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 621f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 111f && UnityEngine.Random.value < 423f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().currentWeapon = BJGCPDNMHDH.DKPPPEKMDAF();
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1520f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MHDLOMFNHOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMINPCPGBBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1673f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 516f && UnityEngine.Random.value < 214f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.FMKGGADDHJK().HLOKMIDGPCA(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1757f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 311f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 953f && UnityEngine.Random.value < 1351f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().BGIFMIBBJIB(BJGCPDNMHDH.ILENGKEGCJD());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1400f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object ENJLMNBAHAF()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 9f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 99f && UnityEngine.Random.value < 1663f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.FMKGGADDHJK().HLOKMIDGPCA(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1422f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 436f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 468f && UnityEngine.Random.value < 398f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.FMKGGADDHJK().LPMCOFOCCAH(BJGCPDNMHDH.ILENGKEGCJD());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(428f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		public bool GOPKBGHMLNF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 141f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 382f && UnityEngine.Random.value < 548f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.FMKGGADDHJK().LOLDJPCCFKO(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(810f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MEKLPMCIMBH()
		{
			throw new NotSupportedException();
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KPNBIPDNGOM()
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
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 3f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 2f && UnityEngine.Random.value < 0.9f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.weaponInventory.currentWeapon = BJGCPDNMHDH.GetRiffle();
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
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
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 358f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1651f && UnityEngine.Random.value < 1421f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.BEIIOAIJMFK().LPMCOFOCCAH(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1885f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object MKEJDEGFKLC()
		{
			return PHDOCKCBJOF;
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1384f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 362f && UnityEngine.Random.value < 385f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.BEIIOAIJMFK().BGIFMIBBJIB(BJGCPDNMHDH.ILENGKEGCJD());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1281f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void JDFJKNFDDGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGDBAJJAHNO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 481f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 570f && UnityEngine.Random.value < 1737f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.weaponInventory.BGIFMIBBJIB(BJGCPDNMHDH.DKPPPEKMDAF());
								BJGCPDNMHDH.TryShootNow();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1919f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1928f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 689f && UnityEngine.Random.value < 1598f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.JLMDEMFIHCA().BGIFMIBBJIB(BJGCPDNMHDH.DKPPPEKMDAF());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1264f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1971f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							float num = Vector3.Distance(component.transform.position, BJGCPDNMHDH.transform.position);
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1312f && UnityEngine.Random.value < 1893f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.playerController.FMKGGADDHJK().BGIFMIBBJIB(BJGCPDNMHDH.BEHHGHCLNGL());
								BJGCPDNMHDH.FDDEEDKAGCI();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(899f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FNCEOCMMGKH()
		{
			return PHDOCKCBJOF;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EHNMJEPLMIC()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private GFHEEFCLGHG ELNOOHFJBGA;

	private List<DestroyableObject> KOPCGNEEHDC = new List<DestroyableObject>(5);

	private EnemyController HAJLIOMLLLD;

	private bool MOLCOKADLEE;

	private bool ILPLGCOCODB;

	private float NOFDHHLCEGM;

	private PlayerController JNFGIPOFKCF;

	private PlayerController.KKPHPLOEACG KPHGALKLGMI;

	private PlayerController BLOHDEENMIJ;

	private float JIACFAJCFBJ = 1f;

	private GameShootableEntity.ShotTarget GLNJNLEHCDC;

	private float LJFAFMFBGNB;

	private float ENKPDFCGDJD;

	private float OEGOCEBFOGN = float.MaxValue;

	[CompilerGenerated]
	private static Comparison<GameShootableEntity> LGJCBPOPCPA;

	public PlayerController playerController => BLOHDEENMIJ;

	private bool HLMELNMHHDA => playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka || playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade;

	private float FDNHLBFMLPO
	{
		get
		{
			if (playerController.currentPlayerPoint == null)
			{
				return 0f;
			}
			if (TimeManager.realTimeWithoutPauses > ENKPDFCGDJD)
			{
				return 1f;
			}
			if (playerController.currentPlayerPoint.point.shield.healthRatio < 0.01f)
			{
				if (OEGOCEBFOGN > TimeManager.realTimeWithoutPauses)
				{
					OEGOCEBFOGN = TimeManager.realTimeWithoutPauses;
					return 0f;
				}
				if (OEGOCEBFOGN + 1.5f > TimeManager.realTimeWithoutPauses)
				{
					return 0f;
				}
				if (OEGOCEBFOGN + 2.5f > TimeManager.realTimeWithoutPauses)
				{
					return 1f;
				}
			}
			if (ELNOOHFJBGA == GFHEEFCLGHG.ShootEnemyPlayerAndMoveALot)
			{
				if (ILPLGCOCODB)
				{
					return 0f;
				}
				return 0f;
			}
			float num = ENKPDFCGDJD - TimeManager.realTimeWithoutPauses;
			return (0.95f - num / 5f) * 0.1f;
		}
	}

	private bool MHIIBPNGLJM
	{
		get
		{
			if (HLMELNMHHDA)
			{
				return TimeManager.realTimeWithoutPauses > NOFDHHLCEGM + 1.2f;
			}
			return true;
		}
	}

	public GFHEEFCLGHG botState
	{
		get
		{
			return ELNOOHFJBGA;
		}
		set
		{
			ELNOOHFJBGA = value;
			AIPKIALKOBL();
		}
	}

	private bool AGKOCMAEHJH(GameShootableEntity HCOFJJCIEOD)
	{
		if (HCOFJJCIEOD.destroyableObject.HHOCGCLBHKB < 0.5f)
		{
			return HCOFJJCIEOD.velocity.magnitude < 0.3f;
		}
		return true;
	}

	private void LCCDGBJLKJP()
	{
		AECLAJOLJHH();
		ILPLGCOCODB = true;
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses;
		if (ELNOOHFJBGA == GFHEEFCLGHG.ShootEnemyPlayerAndMoveALot)
		{
			JIACFAJCFBJ = 5.5f;
		}
		else
		{
			JIACFAJCFBJ = UnityEngine.Random.Range(0.2f, 1.2f);
		}
	}

	public void TryShootNow()
	{
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses;
	}

	protected override void Start()
	{
		base.Start();
	}

	[SpecialName]
	public GFHEEFCLGHG EMFPCHMPOAH()
	{
		return ELNOOHFJBGA;
	}

	private MapDefinition.DefendPosition JLFAGLNDIDI(MapDefinition.DefendPosition EJHDOPLAKLI, bool DDNDHFGNOGB)
	{
		if (EJHDOPLAKLI == null)
		{
			return null;
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM();
		int num = 1;
		for (num = 1; num < list.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition == EJHDOPLAKLI)
			{
				break;
			}
		}
		if (DDNDHFGNOGB)
		{
			num -= 0;
			if (num < 1 || list[num].fraction != playerController.fraction)
			{
				return null;
			}
			return list[num];
		}
		num++;
		if (num >= list.Count || list[num].fraction != playerController.fraction)
		{
			return null;
		}
		return list[num];
	}

	[SpecialName]
	private float KAOJKPONEOG()
	{
		if (playerController.BBNPGJAALCJ() == null)
		{
			return 1763f;
		}
		if (TimeManager.CEAFAMFNGCC() > ENKPDFCGDJD)
		{
			return 1037f;
		}
		if (playerController.EMAMENNDFMB().point.IGEDGCNJCAP().healthRatio < 1165f)
		{
			if (OEGOCEBFOGN > TimeManager.CEAFAMFNGCC())
			{
				OEGOCEBFOGN = TimeManager.realTimeWithoutPauses;
				return 1006f;
			}
			if (OEGOCEBFOGN + 1639f > TimeManager.CEAFAMFNGCC())
			{
				return 1347f;
			}
			if (OEGOCEBFOGN + 1080f > TimeManager.CEAFAMFNGCC())
			{
				return 1732f;
			}
		}
		if (ELNOOHFJBGA == GFHEEFCLGHG.ShootEnemyPlayer)
		{
			if (ILPLGCOCODB)
			{
				return 529f;
			}
			return 1770f;
		}
		float num = ENKPDFCGDJD - TimeManager.realTimeWithoutPauses;
		return (1237f - num / 615f) * 1861f;
	}

	[SpecialName]
	private bool KHKEJMGKMOB()
	{
		return playerController.BEIIOAIJMFK().JKHKBGPKFFF().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Minigun || playerController.FMKGGADDHJK().OLHICLNCPNA().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle;
	}

	private void AIPKIALKOBL()
	{
		if (ELNOOHFJBGA == GFHEEFCLGHG.ShootEnemyPlayerAndMoveALot)
		{
			ENKPDFCGDJD = TimeManager.realTimeWithoutPauses + (float)UnityEngine.Random.Range(5, 8);
		}
		else
		{
			ENKPDFCGDJD = TimeManager.realTimeWithoutPauses + (float)UnityEngine.Random.Range(10, 20);
		}
		OEGOCEBFOGN = float.MaxValue;
	}

	private PlayerWeapon JPNEOHIEDGE()
	{
		foreach (PlayerWeapon item in playerController.FMKGGADDHJK().LAGONJMBJMM)
		{
			if (item.weapon is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("On Get Arena Leaderboards: CNT =  ");
		return null;
	}

	[DebuggerHidden]
	private IEnumerator NMHNFGEJFAO()
	{
		NDMNNPLNIEB nDMNNPLNIEB = new NDMNNPLNIEB();
		nDMNNPLNIEB.BJGCPDNMHDH = this;
		return nDMNNPLNIEB;
	}

	private Vector3 BIECFGOEOID()
	{
		if (playerController.FMKGGADDHJK().JECOEJBGKDF().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol)
		{
			return Vector3.zero;
		}
		Vector3 lhs = base.transform.position - GLNJNLEHCDC.transform.position;
		Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
		return normalized * UnityEngine.Random.Range(393f, 808f) * ((UnityEngine.Random.value > 1664f) ? (-1) : 0) + new Vector3(1096f, UnityEngine.Random.Range(1367f, 244f), 1879f);
	}

	private IEnumerator HCJAHEOGAGH()
	{
		NDMNNPLNIEB nDMNNPLNIEB = new NDMNNPLNIEB();
		nDMNNPLNIEB.BJGCPDNMHDH = this;
		return nDMNNPLNIEB;
	}

	public PlayerWeapon GetRiffle()
	{
		if (ELNOOHFJBGA == GFHEEFCLGHG.ShootEnemyPlayerAndMoveALot)
		{
			foreach (PlayerWeapon item in playerController.weaponInventory.LAGONJMBJMM)
			{
				if (item is PlayerZoomOnTouchWeapon)
				{
					(item as PlayerZoomOnTouchWeapon).SetWaitTime(4.5f);
					if (item.weapon.ammoLeft < 5)
					{
						item.weapon.ammoLeft = 20;
					}
					return item;
				}
			}
		}
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		foreach (PlayerWeapon item2 in playerController.weaponInventory.LAGONJMBJMM)
		{
			if (item2.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle && item2.weapon.ammoLeft > 0 && !(item2.weapon is Pistol) && item2.weapon.reloadingTimeLeft < 0.5f)
			{
				if (item2 is PlayerZoomOnTouchWeapon)
				{
					(item2 as PlayerZoomOnTouchWeapon).SetWaitTime(0.8f);
				}
				list.Add(item2);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return OIINLHHPKKM();
	}

	private void FKNHDELHHID()
	{
		MapDefinition.DefendPosition defendPosition = DECKDDPFPAF(playerController.currentPlayerPoint, DDNDHFGNOGB: true);
		MapDefinition.DefendPosition defendPosition2 = DECKDDPFPAF(playerController.currentPlayerPoint, DDNDHFGNOGB: false);
		MapDefinition.DefendPosition defendPosition3 = JCJGLCJADJK(defendPosition, defendPosition2);
		if ((double)defendPosition3.point.shield.healthRatio < 0.3)
		{
			defendPosition = DECKDDPFPAF(defendPosition, DDNDHFGNOGB: true);
			defendPosition2 = DECKDDPFPAF(defendPosition2, DDNDHFGNOGB: false);
			MapDefinition.DefendPosition nCMHGPNPEJM = JCJGLCJADJK(defendPosition, defendPosition2);
			defendPosition3 = JCJGLCJADJK(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.shield.healthRatio < 0.3)
		{
			defendPosition = DECKDDPFPAF(defendPosition, DDNDHFGNOGB: true);
			defendPosition2 = DECKDDPFPAF(defendPosition2, DDNDHFGNOGB: false);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = JCJGLCJADJK(defendPosition, defendPosition2);
			defendPosition3 = JCJGLCJADJK(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = JCJGLCJADJK(playerController.currentPlayerPoint, defendPosition3);
		int index = defendPosition3.index;
		int index2 = playerController.currentPlayerPoint.index;
		int num = index2 - index;
		MapDefinition.DefendPosition pLMMBKGLGAB = playerController.currentPlayerPoint;
		if (num > 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i++)
			{
				pLMMBKGLGAB = playerController.GoLeft(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 0; j < Mathf.Abs(num); j++)
			{
				pLMMBKGLGAB = playerController.GoRight(pLMMBKGLGAB);
			}
		}
	}

	private bool BIBOEDCOKAA(Vector3 OEDJOFINBMI)
	{
		Vector3 vector = base.transform.position + Vector3.up * 0.5f;
		Vector3 normalized = (OEDJOFINBMI - vector).normalized;
		vector += 0.5f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, OEDJOFINBMI) - 0.5f, 0.1f, float.MaxValue), (1 << TagsAndLayers.GIDHAMNOIHG) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
		}
		return !flag;
	}

	private MapDefinition.DefendPosition BCGJMBGDLAD(MapDefinition.DefendPosition EJHDOPLAKLI, bool DDNDHFGNOGB)
	{
		if (EJHDOPLAKLI == null)
		{
			return null;
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.ADKJKHAHCJD();
		int num = 0;
		for (num = 0; num < list.Count; num += 0)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition == EJHDOPLAKLI)
			{
				break;
			}
		}
		if (DDNDHFGNOGB)
		{
			num -= 0;
			if (num < 0 || list[num].fraction != playerController.fraction)
			{
				return null;
			}
			return list[num];
		}
		num += 0;
		if (num >= list.Count || list[num].fraction != playerController.fraction)
		{
			return null;
		}
		return list[num];
	}

	public PlayerWeapon DKPPPEKMDAF()
	{
		if (ELNOOHFJBGA == (GFHEEFCLGHG)6)
		{
			foreach (PlayerWeapon item in playerController.weaponInventory.LAGONJMBJMM)
			{
				if (item is PlayerZoomOnTouchWeapon)
				{
					(item as PlayerZoomOnTouchWeapon).SetWaitTime(803f);
					if (item.HFNAMMBPJAJ().ammoLeft < 4)
					{
						item.weapon.ammoLeft = -23;
					}
					return item;
				}
			}
		}
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		foreach (PlayerWeapon item2 in playerController.weaponInventory.LAGONJMBJMM)
		{
			if (item2.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle && item2.weapon.ammoLeft > 1 && !(item2.weapon is Pistol) && item2.weapon.reloadingTimeLeft < 546f)
			{
				if (item2 is PlayerZoomOnTouchWeapon)
				{
					(item2 as PlayerZoomOnTouchWeapon).NDLGELJAIBF(148f);
				}
				list.Add(item2);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return JPNEOHIEDGE();
	}

	private PlayerWeapon OEOMHIMNKAO(GameShootableEntity HCOFJJCIEOD)
	{
		DestroyableObject destroyableObject = HCOFJJCIEOD.GILBHOPNBPH();
		if ((bool)destroyableObject && destroyableObject.HHOCGCLBHKB < 1056f)
		{
			bool flag = true;
			foreach (PlayerWeapon item in playerController.JLMDEMFIHCA().LAGONJMBJMM)
			{
				if (item.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool || item.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
				{
					if (item.weapon.ammoLeft > 0)
					{
						flag = true;
					}
					if (item.weapon.willShoot)
					{
						return item;
					}
				}
			}
			if (!flag)
			{
				return BEHHGHCLNGL();
			}
			return null;
		}
		return ILENGKEGCJD();
	}

	private PlayerWeapon HNPHIDLOKFM(GameShootableEntity HCOFJJCIEOD)
	{
		DestroyableObject destroyableObject = HCOFJJCIEOD.NHOFLPJMKBA();
		if ((bool)destroyableObject && destroyableObject.HHOCGCLBHKB < 1894f)
		{
			bool flag = false;
			foreach (PlayerWeapon item in playerController.FMKGGADDHJK().LAGONJMBJMM)
			{
				if (item.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka || item.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
				{
					if (item.HFNAMMBPJAJ().ammoLeft > 0)
					{
						flag = true;
					}
					if (item.HFNAMMBPJAJ().willShoot)
					{
						return item;
					}
				}
			}
			if (!flag)
			{
				return ILENGKEGCJD();
			}
			return null;
		}
		return GetRiffle();
	}

	private MapDefinition.DefendPosition IPEIOAKBDPO(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null && NCMHGPNPEJM == null)
		{
			UnityEngine.Debug.LogError(" (#");
		}
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.LMHDAIBCLDP().healthRatio > NCMHGPNPEJM.point.shield.healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private GameShootableEntity JHLFEDDMLDJ()
	{
		List<GameShootableEntity> list = GameShootableEntity.FKFFINALIOP(playerController.fraction);
		list.Sort(delegate(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
		{
			AIObject aIObject2 = HPJFBKEKJHB.owner as AIObject;
			AIObject aIObject3 = NCMHGPNPEJM.owner as AIObject;
			if (aIObject3 == null && aIObject2 == null)
			{
				return 0;
			}
			if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
			{
				return 1;
			}
			if (aIObject3 == null || aIObject3.ACLDFHJKBLI == null)
			{
				return -1;
			}
			float num = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject2.destroyableObj != null)
			{
				num /= aIObject2.destroyableObj.healthRatio;
			}
			float num2 = aIObject3.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject3.destroyableObj != null)
			{
				num /= aIObject3.destroyableObj.healthRatio;
			}
			return num2.CompareTo(num);
		});
		List<GameShootableEntity> all = GameShootableEntity.GetAll<KillStreakBonusBox>();
		if (all.Count > 0)
		{
			list = all;
		}
		foreach (GameShootableEntity item in list)
		{
			PlayerWeapon playerWeapon = HNPHIDLOKFM(item);
			if (BIBOEDCOKAA(item.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)171)[0].transform.position) && playerWeapon != null && AGKOCMAEHJH(item))
			{
				AIObject aIObject = item.owner as AIObject;
				playerController.JLMDEMFIHCA().currentWeapon = playerWeapon;
				return item;
			}
		}
		return null;
	}

	public PlayerWeapon BEHHGHCLNGL()
	{
		if (ELNOOHFJBGA == (GFHEEFCLGHG)5)
		{
			foreach (PlayerWeapon item in playerController.FMKGGADDHJK().LAGONJMBJMM)
			{
				if (item is PlayerZoomOnTouchWeapon)
				{
					(item as PlayerZoomOnTouchWeapon).POEGFIAHCIL(1666f);
					if (item.weapon.ammoLeft < 2)
					{
						item.weapon.ammoLeft = 122;
					}
					return item;
				}
			}
		}
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		foreach (PlayerWeapon item2 in playerController.BEIIOAIJMFK().LAGONJMBJMM)
		{
			if (item2.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle && item2.HFNAMMBPJAJ().ammoLeft > 0 && !(item2.HFNAMMBPJAJ() is Pistol) && item2.HFNAMMBPJAJ().reloadingTimeLeft < 1544f)
			{
				if (item2 is PlayerZoomOnTouchWeapon)
				{
					(item2 as PlayerZoomOnTouchWeapon).SetWaitTime(1610f);
				}
				list.Add(item2);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return OIINLHHPKKM();
	}

	private GameShootableEntity ACHMKEFNFHG()
	{
		List<GameShootableEntity> list = GameShootableEntity.GetOpponents(playerController.fraction);
		list.Sort(delegate(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
		{
			AIObject aIObject2 = HPJFBKEKJHB.owner as AIObject;
			AIObject aIObject3 = NCMHGPNPEJM.owner as AIObject;
			if (aIObject3 == null && aIObject2 == null)
			{
				return 0;
			}
			if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
			{
				return 1;
			}
			if (aIObject3 == null || aIObject3.ACLDFHJKBLI == null)
			{
				return -1;
			}
			float num = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject2.destroyableObj != null)
			{
				num /= aIObject2.destroyableObj.healthRatio;
			}
			float num2 = aIObject3.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject3.destroyableObj != null)
			{
				num /= aIObject3.destroyableObj.healthRatio;
			}
			return num2.CompareTo(num);
		});
		List<GameShootableEntity> all = GameShootableEntity.GetAll<KillStreakBonusBox>();
		if (all.Count > 0)
		{
			list = all;
		}
		foreach (GameShootableEntity item in list)
		{
			PlayerWeapon playerWeapon = GNDKPIEIFCM(item);
			if (BIBOEDCOKAA(item.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.All)[0].transform.position) && playerWeapon != null && AGKOCMAEHJH(item))
			{
				AIObject aIObject = item.owner as AIObject;
				playerController.weaponInventory.currentWeapon = playerWeapon;
				return item;
			}
		}
		return null;
	}

	public void FDDEEDKAGCI()
	{
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC();
	}

	private void OBHDACJEOGO(float OLGHBJPAIJN = 0f)
	{
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses + UnityEngine.Random.Range(1f, 2f);
		ILPLGCOCODB = false;
	}

	public void Init()
	{
		if (base.enabled)
		{
			if (base.gameObject.activeInHierarchy && playerController.FEHCCGEGPLH.isMine)
			{
				playerController.weaponInventory.currentWeapon = playerController.weaponInventory.LAGONJMBJMM[0];
			}
			GLNJNLEHCDC = null;
			JNFGIPOFKCF = PlayerController.GetEnemyOf(playerController.fraction);
		}
	}

	private void KEEJJNOHEJB()
	{
		StopAllCoroutines();
	}

	private void AECLAJOLJHH()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(playerController.fraction);
		float num = 0.5f;
		GameShootableEntity gameShootableEntity = null;
		gameShootableEntity = ((!(UnityEngine.Random.value < num)) ? ACHMKEFNFHG() : enemyOf.gameShootableEntity);
		if (gameShootableEntity != null)
		{
			GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
			List<GameShootableEntity.ShotTarget> list = ((!(gameShootableEntityPlayer != null)) ? gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn) : ((playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG != Weapon.IGGFMJAKLGO.Bazooka) ? gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield)));
			if (list.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, list.Count);
				GLNJNLEHCDC = list[index];
			}
		}
	}

	public PlayerWeapon ILENGKEGCJD()
	{
		if (ELNOOHFJBGA == (GFHEEFCLGHG)5)
		{
			foreach (PlayerWeapon item in playerController.BEIIOAIJMFK().LAGONJMBJMM)
			{
				if (item is PlayerZoomOnTouchWeapon)
				{
					(item as PlayerZoomOnTouchWeapon).JIAHCDAAEIN(1151f);
					if (item.HFNAMMBPJAJ().ammoLeft < 1)
					{
						item.weapon.ammoLeft = 65;
					}
					return item;
				}
			}
		}
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		foreach (PlayerWeapon item2 in playerController.FMKGGADDHJK().LAGONJMBJMM)
		{
			if (item2.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle && item2.HFNAMMBPJAJ().ammoLeft > 0 && !(item2.HFNAMMBPJAJ() is Pistol) && item2.HFNAMMBPJAJ().reloadingTimeLeft < 1626f)
			{
				if (item2 is PlayerZoomOnTouchWeapon)
				{
					(item2 as PlayerZoomOnTouchWeapon).DCAGMHBGMCJ(1510f);
				}
				list.Add(item2);
			}
		}
		if (list.Count > 1)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		return OIINLHHPKKM();
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private bool HCPIJDCKEJL(Vector3 OEDJOFINBMI)
	{
		Vector3 vector = base.transform.position + Vector3.up * 942f;
		Vector3 normalized = (OEDJOFINBMI - vector).normalized;
		vector += 658f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, OEDJOFINBMI) - 1179f, 1192f, 1574f), (0 << (TagsAndLayers.GIDHAMNOIHG & -41)) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
		}
		return !flag;
	}

	private PlayerWeapon GNDKPIEIFCM(GameShootableEntity HCOFJJCIEOD)
	{
		DestroyableObject destroyableObject = HCOFJJCIEOD.destroyableObject;
		if ((bool)destroyableObject && destroyableObject.HHOCGCLBHKB < 0.5f)
		{
			bool flag = false;
			foreach (PlayerWeapon item in playerController.weaponInventory.LAGONJMBJMM)
			{
				if (item.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka || item.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
				{
					if (item.weapon.ammoLeft > 0)
					{
						flag = true;
					}
					if (item.weapon.willShoot)
					{
						return item;
					}
				}
			}
			if (!flag)
			{
				return GetRiffle();
			}
			return null;
		}
		return GetRiffle();
	}

	private MapDefinition.DefendPosition DECKDDPFPAF(MapDefinition.DefendPosition EJHDOPLAKLI, bool DDNDHFGNOGB)
	{
		if (EJHDOPLAKLI == null)
		{
			return null;
		}
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == EJHDOPLAKLI)
			{
				break;
			}
		}
		if (DDNDHFGNOGB)
		{
			num--;
			if (num < 0 || availablePoints[num].fraction != playerController.fraction)
			{
				return null;
			}
			return availablePoints[num];
		}
		num++;
		if (num >= availablePoints.Count || availablePoints[num].fraction != playerController.fraction)
		{
			return null;
		}
		return availablePoints[num];
	}

	private IEnumerator MJPOCJEPPPP()
	{
		BJCNFGGMAOD bJCNFGGMAOD = new BJCNFGGMAOD();
		bJCNFGGMAOD.BJGCPDNMHDH = this;
		return bJCNFGGMAOD;
	}

	[DebuggerHidden]
	private IEnumerator LCNJDPDGEOG()
	{
		BJCNFGGMAOD bJCNFGGMAOD = new BJCNFGGMAOD();
		bJCNFGGMAOD.BJGCPDNMHDH = this;
		return bJCNFGGMAOD;
	}

	protected override void Awake()
	{
		base.Awake();
		BLOHDEENMIJ = GetComponent<PlayerController>();
	}

	private PlayerWeapon OIINLHHPKKM()
	{
		foreach (PlayerWeapon item in playerController.weaponInventory.LAGONJMBJMM)
		{
			if (item.weapon is Pistol)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("Bot should have pistol equipped");
		return null;
	}

	[SpecialName]
	public void NBGKIJLHGCA(GFHEEFCLGHG IDEBKDPMPGM)
	{
		ELNOOHFJBGA = IDEBKDPMPGM;
		AIPKIALKOBL();
	}

	private Vector3 BNLNFKDLJDC()
	{
		if (playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
		{
			return Vector3.zero;
		}
		Vector3 lhs = base.transform.position - GLNJNLEHCDC.transform.position;
		Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
		return normalized * UnityEngine.Random.Range(0.1f, 1f) * ((!(UnityEngine.Random.value > 0.5f)) ? 1 : (-1)) + new Vector3(0f, UnityEngine.Random.Range(-0.3f, 0.3f), 0f);
	}

	private void AJFDDIFMHPN()
	{
	}

	[CompilerGenerated]
	private static int CFJKEMKLGGC(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
	{
		AIObject aIObject = HPJFBKEKJHB.owner as AIObject;
		AIObject aIObject2 = NCMHGPNPEJM.owner as AIObject;
		if (aIObject2 == null && aIObject == null)
		{
			return 0;
		}
		if (aIObject == null || aIObject.ACLDFHJKBLI == null)
		{
			return 1;
		}
		if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
		{
			return -1;
		}
		float num = aIObject.ACLDFHJKBLI.botProperties.dangerCoeficient;
		if (aIObject.destroyableObj != null)
		{
			num /= aIObject.destroyableObj.healthRatio;
		}
		float num2 = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
		if (aIObject2.destroyableObj != null)
		{
			num /= aIObject2.destroyableObj.healthRatio;
		}
		return num2.CompareTo(num);
	}

	protected void Update()
	{
		if (playerController.FEHCCGEGPLH.isMine && ELNOOHFJBGA != GFHEEFCLGHG.Wait && Singleton<GameController>.instance.gameIsRunning)
		{
			if (TimeManager.realTimeWithoutPauses > LJFAFMFBGNB && !ILPLGCOCODB && MHIIBPNGLJM)
			{
				LCCDGBJLKJP();
			}
			if (TimeManager.realTimeWithoutPauses > LJFAFMFBGNB + JIACFAJCFBJ)
			{
				OBHDACJEOGO();
			}
			if (ILPLGCOCODB && GLNJNLEHCDC != null && playerController.weaponInventory.currentWeapon.weapon.willShoot && (playerController.playerState != PlayerController.KKPHPLOEACG.Walking || !HLMELNMHHDA))
			{
				Vector3 mPHCNMDIPAI = Singleton<AimingHelper>.instance.PredictPosition(playerController.weaponInventory.currentWeapon.weapon, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.shootableEntity.velocity) + BNLNFKDLJDC();
				playerController.weaponInventory.currentWeapon.ShootForBot(mPHCNMDIPAI);
				NOFDHHLCEGM = TimeManager.realTimeWithoutPauses;
			}
		}
	}

	private GameShootableEntity KEEPFHDCGOP()
	{
		List<GameShootableEntity> list = GameShootableEntity.GetOpponents(playerController.fraction);
		list.Sort(delegate(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
		{
			AIObject aIObject2 = HPJFBKEKJHB.owner as AIObject;
			AIObject aIObject3 = NCMHGPNPEJM.owner as AIObject;
			if (aIObject3 == null && aIObject2 == null)
			{
				return 0;
			}
			if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
			{
				return 1;
			}
			if (aIObject3 == null || aIObject3.ACLDFHJKBLI == null)
			{
				return -1;
			}
			float num = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject2.destroyableObj != null)
			{
				num /= aIObject2.destroyableObj.healthRatio;
			}
			float num2 = aIObject3.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject3.destroyableObj != null)
			{
				num /= aIObject3.destroyableObj.healthRatio;
			}
			return num2.CompareTo(num);
		});
		List<GameShootableEntity> all = GameShootableEntity.GetAll<KillStreakBonusBox>();
		if (all.Count > 0)
		{
			list = all;
		}
		foreach (GameShootableEntity item in list)
		{
			PlayerWeapon playerWeapon = OEOMHIMNKAO(item);
			if (HCPIJDCKEJL(item.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)107)[0].transform.position) && playerWeapon != null && AGKOCMAEHJH(item))
			{
				AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
				playerController.FMKGGADDHJK().LOLDJPCCFKO(playerWeapon);
				return item;
			}
		}
		return null;
	}

	public void EGIDHHONMCN()
	{
		if (base.enabled)
		{
			if (base.gameObject.activeInHierarchy && playerController.FEHCCGEGPLH.isMine)
			{
				playerController.FMKGGADDHJK().LOLDJPCCFKO(playerController.BEIIOAIJMFK().LAGONJMBJMM[1]);
			}
			GLNJNLEHCDC = null;
			JNFGIPOFKCF = PlayerController.GetEnemyOf(playerController.fraction);
		}
	}

	private MapDefinition.DefendPosition JCJGLCJADJK(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null && NCMHGPNPEJM == null)
		{
			UnityEngine.Debug.LogError("Error in bot finding position");
		}
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.shield.healthRatio > NCMHGPNPEJM.point.shield.healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private void OnEnable()
	{
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(NMHNFGEJFAO());
	}
}
