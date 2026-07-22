using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

[RequireComponent(typeof(EnemyBasicInventory))]
public abstract class SoldierBehaviour : LevelBehaviour
{
	private sealed class OKGIONBNKMI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool EFBPOCHCGPB;

		internal UpgradeSlots.UnitUpgrades PFGLIAHPMCK;

		internal bool OFICDODLPCK;

		internal EnemyBasicInventory HIGICBFFOAE;

		internal List<TechnologyVisualDefinition> ELEBHMKGPPF;

		internal bool DODBHDBBKJI;

		internal SoldierBehaviour BJGCPDNMHDH;

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
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.GBOMCIHDJMM();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 0)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.NFPKGDGHEGF(ELEBHMKGPPF[2].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 2 && ELEBHMKGPPF[0] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.PrepareWeaponCoroutine(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					UnityEngine.Debug.LogError("com/google/android/gms/common/ConnectionResult" + BJGCPDNMHDH.name + "GameType");
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
		public OKGIONBNKMI()
		{
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.NOHEPOKMJGB();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 0)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.EOHHFEJIBAI(ELEBHMKGPPF[7].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 5 && ELEBHMKGPPF[2] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LDKABAPNMJB(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					UnityEngine.Debug.LogError("ID_ARENAREWARD_TICKETS" + BJGCPDNMHDH.name + "*.prefab");
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

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.GKLDEBPNHOC();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.ELALMNDFNAA(ELEBHMKGPPF[7].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 4 && ELEBHMKGPPF[4] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.JLOKHOIMDCH(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					UnityEngine.Debug.LogError("Player {0} state: {1}" + BJGCPDNMHDH.name + "DOWNLOADBTN");
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.NGIDLJPJKPM();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 0)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.ELALMNDFNAA(ELEBHMKGPPF[5].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 6 && ELEBHMKGPPF[4] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.JLOKHOIMDCH(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					UnityEngine.Debug.LogError("Result" + BJGCPDNMHDH.name + " for ");
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object AGCPJGAAODG()
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.ALOFGKDJMNG();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.EMOGGMMOGJP(ELEBHMKGPPF[6].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 7 && ELEBHMKGPPF[2] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.PrepareWeaponCoroutine(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					UnityEngine.Debug.LogError("Invite was already send, ignoring click." + BJGCPDNMHDH.name + "ID_ARENAPROMOSTARTSIN");
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
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLAPICIGNJB()
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.IJDFKHLPDAP();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.ELALMNDFNAA(ELEBHMKGPPF[3].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 7 && ELEBHMKGPPF[3] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LOPAMJHFGJJ(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					UnityEngine.Debug.LogError("Current unit is not delivered at the moment!!!" + BJGCPDNMHDH.name + "Confirmed_In_App");
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public bool CBGPIONEKLM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.LOIFPEDEHCC();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.EMOGGMMOGJP(ELEBHMKGPPF[5].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 2 && ELEBHMKGPPF[5] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LOPAMJHFGJJ(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					UnityEngine.Debug.LogError("WithdrawerId" + BJGCPDNMHDH.name + "Start TUNE SDK clicked");
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.DHNIBPDEFME();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.GAAGIICCEDE(ELEBHMKGPPF[4].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 3 && ELEBHMKGPPF[1] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LOPAMJHFGJJ(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					UnityEngine.Debug.LogError("ID_CONFIRM_ERROR" + BJGCPDNMHDH.name + "x{0}");
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
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.NOHEPOKMJGB();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.ELALMNDFNAA(ELEBHMKGPPF[3].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 4 && ELEBHMKGPPF[8] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.JLOKHOIMDCH(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					UnityEngine.Debug.LogError(", " + BJGCPDNMHDH.name + "Result");
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

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.IKCIMMAOMJC();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.EMOGGMMOGJP(ELEBHMKGPPF[3].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 0 && ELEBHMKGPPF[3] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LDKABAPNMJB(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					UnityEngine.Debug.LogError("DailyMissionsCompletionRewardGold" + BJGCPDNMHDH.name + "customFloat");
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

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.GIKPHMLCJCL();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.EMOGGMMOGJP(ELEBHMKGPPF[3].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 4 && ELEBHMKGPPF[3] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.PrepareWeaponCoroutine(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					UnityEngine.Debug.LogError("title" + BJGCPDNMHDH.name + "WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!");
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

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void OCBFBEMDMMJ()
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
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.DKGDBOKJGIP();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.EMOGGMMOGJP(ELEBHMKGPPF[3].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 4 && ELEBHMKGPPF[2] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.JLOKHOIMDCH(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					UnityEngine.Debug.LogError("N" + BJGCPDNMHDH.name + "{0} 2 / 3");
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
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.IJDFKHLPDAP();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 0)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.ELALMNDFNAA(ELEBHMKGPPF[0].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 1 && ELEBHMKGPPF[3] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LDKABAPNMJB(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: true));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					UnityEngine.Debug.LogError("Thanks you for the following. Here are those well deserved {0} gold bars." + BJGCPDNMHDH.name + "ID_CONFIRM_SUBSCRIPTION_TEXT");
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
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
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.DHNIBPDEFME();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
							if (componentsInChildren.Length > 0)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.UnloadModels(ELEBHMKGPPF[2].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 2 && ELEBHMKGPPF[2] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.PrepareWeaponCoroutine(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					UnityEngine.Debug.LogError("bad visuals for" + BJGCPDNMHDH.name + "!!!!");
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

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.ELIMIFMDKMJ();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true));
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 1)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
								enemyLeveledWeapon.UnloadModels(ELEBHMKGPPF[1].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 6 && ELEBHMKGPPF[7] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.JLOKHOIMDCH(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					UnityEngine.Debug.LogError("#Mission Rewards# Heroic was opened" + BJGCPDNMHDH.name + "MX");
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

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (EFBPOCHCGPB)
				{
					List<SoldierMeshChanger.SoldierStyle> list = BJGCPDNMHDH.CBMEKCFKKOD(PFGLIAHPMCK);
					foreach (SoldierMeshChanger.SoldierStyle item in list)
					{
						item.NOHEPOKMJGB();
					}
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (EFBPOCHCGPB)
				{
					HIGICBFFOAE = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[1];
					ELEBHMKGPPF = BJGCPDNMHDH.upgradeSlots.GetVisuals(PFGLIAHPMCK);
					if (DODBHDBBKJI)
					{
						foreach (EnemyBasicInventory.InventoryWeapon item2 in HIGICBFFOAE.GGKGGMNIDMI)
						{
							EnemyLeveledWeapon[] componentsInChildren = item2.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: false);
							if (componentsInChildren.Length > 0)
							{
								EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[1];
								enemyLeveledWeapon.DBGCJALKEFJ(ELEBHMKGPPF[3].weaponNumber);
							}
						}
					}
					if (ELEBHMKGPPF.Count > 2 && ELEBHMKGPPF[0] != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HIGICBFFOAE.LDKABAPNMJB(BJGCPDNMHDH.CIOODNFANAH(PFGLIAHPMCK), LIOCBEKIKJE: false));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					UnityEngine.Debug.LogError("VisualType" + BJGCPDNMHDH.name + "ID_CONFIRM_INAPP_VALIDATION");
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
	}

	private sealed class PNLNJGDJLPC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<SoldierMeshChanger.SoldierStyle>.Enumerator KFCAECGLKKO;

		internal EnemyBasicInventory ABBKANIGKMI;

		internal List<TechnologyVisualDefinition> NFOFBADAJJK;

		internal bool OFICDODLPCK;

		internal bool FBCLJFNNJGG;

		internal SoldierBehaviour BJGCPDNMHDH;

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

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.IOOJJAIJGFN();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 2 && NFOFBADAJJK[8] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.LDKABAPNMJB(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				UnityEngine.Debug.LogError("ID_NOTIFICATION_DAILYREWARD_WB" + BJGCPDNMHDH.name + "ID_NOW");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public PNLNJGDJLPC()
		{
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.HOMCBACAEJH();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 2 && NFOFBADAJJK[0] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.BCFKAHDPHNG(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				UnityEngine.Debug.LogError("dogTagTimerLock" + BJGCPDNMHDH.name + "Warbucks");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DOOAHBLHGFO()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.ELIMIFMDKMJ();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 6 && NFOFBADAJJK[8] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.LOPAMJHFGJJ(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				UnityEngine.Debug.LogError("EventDefinition" + BJGCPDNMHDH.name + "ID_COMPLETED");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void MENEBJLDGJD()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.ILIDKENNPLC();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[1];
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 6 && NFOFBADAJJK[8] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.BCFKAHDPHNG(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.LogError("POWER BAND = NULL" + BJGCPDNMHDH.name + "InventoryData");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.NGIDLJPJKPM();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false)[1];
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 7 && NFOFBADAJJK[3] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.LOPAMJHFGJJ(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.LogError("Directory \"{0}\" does not exists" + BJGCPDNMHDH.name + "Sniper_Tutorial_Played");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void IDCJDJMGKFG()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.FOMMKOFKLMD();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[1];
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 3 && NFOFBADAJJK[2] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.LOPAMJHFGJJ(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.LogError("ID_MYWARCARDS" + BJGCPDNMHDH.name + "Prefabs");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LDBLCPIGLOF()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.FOMMKOFKLMD();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[1];
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 4 && NFOFBADAJJK[7] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.PrepareWeaponCoroutine(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.LogError("isInLeague" + BJGCPDNMHDH.name + "menu-attack-ico");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.FOMMKOFKLMD();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true)[1];
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 0 && NFOFBADAJJK[4] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.BCFKAHDPHNG(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				UnityEngine.Debug.LogError("ID_PACKDETAILS" + BJGCPDNMHDH.name + "Chat: Disconnect");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.DHNIBPDEFME();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true));
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 2 && NFOFBADAJJK[2] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.PrepareWeaponCoroutine(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.LogError("bad card visuals for" + BJGCPDNMHDH.name + "!!!!");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.LOIFPEDEHCC();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 2 && NFOFBADAJJK[6] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.LOPAMJHFGJJ(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Debug.LogError("ID_GUI_EQUIPPED" + BJGCPDNMHDH.name + "ShotFrequencyMin");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void GFPDOCDEGPA()
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
				KFCAECGLKKO = BJGCPDNMHDH.NILIABODEBO.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SoldierMeshChanger.SoldierStyle current = KFCAECGLKKO.Current;
						current.HMKEJNKPNKN();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				ABBKANIGKMI = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])BJGCPDNMHDH.GetComponentsInChildren<EnemyBasicInventory>(includeInactive: false));
				NFOFBADAJJK = BJGCPDNMHDH.upgradeSlots.cardVisuals;
				if (NFOFBADAJJK.Count > 8 && NFOFBADAJJK[8] != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(ABBKANIGKMI.JLOKHOIMDCH(BJGCPDNMHDH.JDEDGDMMIFJ(), LIOCBEKIKJE: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				UnityEngine.Debug.LogError("55a90af8-a7bb-4152-a5e4-639d7488b0fb" + BJGCPDNMHDH.name + "Starting match against bot");
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(((LevelBehaviour)BJGCPDNMHDH).PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}
	}

	[FormerlySerializedAs("HNEJBPPKBGE")]
	public List<SoldierMeshChanger.SoldierStyle> CLNNHFGKNJO;

	[FormerlySerializedAs("NOPIHCOBGEH")]
	public List<SoldierMeshChanger.SoldierStyle> JOMLOFIIKLP;

	[FormerlySerializedAs("JEOEGCBGJDJ")]
	public List<SoldierMeshChanger.SoldierStyle> NILIABODEBO;

	[BitMask(typeof(EnemyPoint.LJGGJMAFEBN))]
	public EnemyPoint.LJGGJMAFEBN AGEBNJADJNG;

	[BitMask(typeof(SpawnPoint.PGMEFLECCPH))]
	public SpawnPoint.PGMEFLECCPH APMKFCIEBAF;

	[FormerlySerializedAs("MGKOIOIAEML")]
	public SoldierParts BMNHHCCBAAN;

	protected EnemyBasicInventory IILCGHOLDHF;

	private NavigationAgent GDABIBJBCJL;

	[FormerlySerializedAs("NBBEEENLPEA")]
	public EnemyController LMNPOINIJBD;

	[FormerlySerializedAs("PIFHJDGIBNM")]
	public Weapon KHKAAGCIJPO;

	protected Ammo.ILIOELBBLDM OKHEHHEJIOB;

	protected int MJNENAGPCGF;

	protected int OONPHPCNBJF;

	protected bool POPLFNCCLHJ;

	protected PhotonView FEHCCGEGPLH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private SoldierBehaviourDefinititon _003CDJCMADEDCNA_003Ek__BackingField;

	protected BitVector32 ECOJGJHKPNE = new BitVector32(0);

	[FormerlySerializedAs("PNOJBGAFKLA")]
	public Vector3 OEDJOFINBMI;

	protected bool EIGIBELADLF;

	protected bool NFGCPLPKAIP;

	private bool ONMMKNNPFMG;

	protected List<Weapon> EEMHAHAINNM;

	protected bool LGCNELDNFAE;

	protected GameShootableEntity.ShotTarget GLNJNLEHCDC;

	protected SoldierMeshChanger IGLLHPCDHLD => (!(LMNPOINIJBD != null)) ? null : LMNPOINIJBD.meshChanger;

	public List<Weapon> allWeapons => IILCGHOLDHF.weaponInstancies;

	public SoldierBehaviourDefinititon soldierBehaviourDefinititon
	{
		get
		{
			return (SoldierBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public virtual SoldierBehaviourDefinititon soldierBaseDefinition
	{
		[CompilerGenerated]
		get
		{
			return _003CDJCMADEDCNA_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CDJCMADEDCNA_003Ek__BackingField = value;
		}
	}

	protected bool HOHDBPODOAN => EEMHAHAINNM.Count > 1;

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (FEHCCGEGPLH != null)
		{
			FEHCCGEGPLH.RebuildCache();
		}
	}

	public virtual void UpdateVisual()
	{
		if (LMNPOINIJBD.spawnedByCard)
		{
			IGLLHPCDHLD.SetSoldierStyle(NILIABODEBO);
			List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
			foreach (TechnologyVisualDefinition cardVisual in upgradeSlots.cardVisuals)
			{
				list.Add(cardVisual);
			}
			IGLLHPCDHLD.SetSoldierVisual(list, LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction);
			if (upgradeSlots.cardVisuals.Count > 2 && upgradeSlots.cardVisuals[2] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(JDEDGDMMIFJ());
			}
		}
		else
		{
			IGLLHPCDHLD.SetSoldierStyle(CBMEKCFKKOD(LMNPOINIJBD.PFGLIAHPMCK));
			List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(LMNPOINIJBD.PFGLIAHPMCK);
			IGLLHPCDHLD.SetSoldierVisual(visuals, LMNPOINIJBD.fraction == PlayerController.OGMBJPKOPCB.fraction);
			if (visuals.Count > 2 && visuals[2] != null)
			{
				IILCGHOLDHF.SetWeaponsUpgrade(CIOODNFANAH(LMNPOINIJBD.PFGLIAHPMCK));
			}
		}
	}

	[DebuggerHidden]
	public override IEnumerator PrepareVisualsForGameCoroutine(UpgradeSlots.UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB, bool OFICDODLPCK, bool DODBHDBBKJI = false)
	{
		OKGIONBNKMI oKGIONBNKMI = new OKGIONBNKMI();
		oKGIONBNKMI.EFBPOCHCGPB = EFBPOCHCGPB;
		oKGIONBNKMI.PFGLIAHPMCK = PFGLIAHPMCK;
		oKGIONBNKMI.OFICDODLPCK = OFICDODLPCK;
		oKGIONBNKMI.DODBHDBBKJI = DODBHDBBKJI;
		oKGIONBNKMI.BJGCPDNMHDH = this;
		return oKGIONBNKMI;
	}

	protected virtual int[] CIOODNFANAH(UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> visuals = upgradeSlots.GetVisuals(PFGLIAHPMCK);
		return new int[1] { visuals[2].weaponNumber };
	}

	protected virtual int[] JDEDGDMMIFJ()
	{
		return new int[1] { upgradeSlots.cardVisuals[2].weaponNumber };
	}

	[DebuggerHidden]
	public override IEnumerator PrepareVisualsForCardCoroutine(bool OFICDODLPCK, bool FBCLJFNNJGG)
	{
		PNLNJGDJLPC pNLNJGDJLPC = new PNLNJGDJLPC();
		pNLNJGDJLPC.OFICDODLPCK = OFICDODLPCK;
		pNLNJGDJLPC.FBCLJFNNJGG = FBCLJFNNJGG;
		pNLNJGDJLPC.BJGCPDNMHDH = this;
		return pNLNJGDJLPC;
	}

	public override void Init(AIObject KLHPCPKJGOC)
	{
		base.Init(KLHPCPKJGOC);
		EnemyController lMNPOINIJBD = (EnemyController)KLHPCPKJGOC;
		LMNPOINIJBD = lMNPOINIJBD;
		IGLLHPCDHLD.SetSoldierStyle(CBMEKCFKKOD(LMNPOINIJBD.PFGLIAHPMCK));
		BMNHHCCBAAN = LMNPOINIJBD.GetComponent<SoldierParts>();
		IILCGHOLDHF = GetComponent<EnemyBasicInventory>();
	}

	public virtual bool AcceptsPoint(EnemyPoint PLMMBKGLGAB)
	{
		EnemyPoint.LJGGJMAFEBN lJGGJMAFEBN = AGEBNJADJNG;
		if (Singleton<GameController>.instance.isTutorial)
		{
			lJGGJMAFEBN &= ~EnemyPoint.LJGGJMAFEBN.Corner;
		}
		return (lJGGJMAFEBN & PLMMBKGLGAB.enemyPointType) == PLMMBKGLGAB.enemyPointType && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction;
	}

	public virtual bool AcceptSpawnPoint(SpawnPoint PLMMBKGLGAB)
	{
		return (APMKFCIEBAF & PLMMBKGLGAB.APMKFCIEBAF) == PLMMBKGLGAB.APMKFCIEBAF && LMNPOINIJBD.fraction == PLMMBKGLGAB.fraction;
	}

	public SpawnPoint PickNormalSPawn(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (item.APMKFCIEBAF == SpawnPoint.PGMEFLECCPH.Normal && item.fraction == LMNPOINIJBD.fraction)
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 0)
		{
			throw new Exception("Enemy could not be spawned");
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		return list[index];
	}

	public virtual EnemyPoint GetNewEnemyPoint(EnemyPoint EHNNGNKDPBL)
	{
		return SpawningManager.instance.GetNextFreeEnemyPoint(EHNNGNKDPBL, this);
	}

	public virtual EnemyPoint GetInitPoint()
	{
		return SpawningManager.instance.GetPoint(this);
	}

	public virtual void Shooting()
	{
		if (!KHKAAGCIJPO.willShoot)
		{
			return;
		}
		if (IILCGHOLDHF.weaponIndex == 1)
		{
			MDKABJDCKBI(OEDJOFINBMI, GGJPNLDIGGM: false);
			LMNPOINIJBD.OnShot();
			LMNPOINIJBD.EndShooting();
			InvokeAfter(delegate
			{
				SwitchWeapon(AFKKHLPPGLN: false);
			}, 0.5f);
			return;
		}
		if (ECOJGJHKPNE[1 << MJNENAGPCGF])
		{
			MDKABJDCKBI(OEDJOFINBMI, GGJPNLDIGGM: false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - OEDJOFINBMI, Vector3.up).normalized * UnityEngine.Random.Range(0.5f, 1f);
			if ((double)UnityEngine.Random.value < 0.5)
			{
				vector = -vector;
			}
			MDKABJDCKBI(OEDJOFINBMI + vector + new Vector3(0f, 0.5f, 0f), GGJPNLDIGGM: true);
		}
		LMNPOINIJBD.OnShot();
		MJNENAGPCGF++;
		if (MJNENAGPCGF >= OONPHPCNBJF)
		{
			MJNENAGPCGF = 0;
			LMNPOINIJBD.EndShooting();
		}
	}

	public virtual void PickTarget()
	{
		if (!BAGHBFNKEOP())
		{
			GOOKGAHJEHA();
		}
	}

	public void UseTurret(Weapon JMMJHCOKCGG)
	{
		KHKAAGCIJPO = JMMJHCOKCGG;
		POPLFNCCLHJ = true;
	}

	public void SwitchWeapon(bool AFKKHLPPGLN)
	{
		if (LMNPOINIJBD.LAADDLGBFIG.isMine)
		{
			LMNPOINIJBD.LAADDLGBFIG.RPC("SoldierBehaviourSwitchWeapon", PhotonTargets.Others, AFKKHLPPGLN);
		}
		KHKAAGCIJPO = IILCGHOLDHF.SwitchWeapon(AFKKHLPPGLN ? 1 : 0);
	}

	protected virtual void MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool GGJPNLDIGGM)
	{
		KHKAAGCIJPO.GGJPNLDIGGM = GGJPNLDIGGM;
		KHKAAGCIJPO.OLLIJPKAIFC = !POPLFNCCLHJ;
		KHKAAGCIJPO.EBNMDKAEJAH = OKHEHHEJIOB;
		DEFKBAMEKFI();
		if (NFGCPLPKAIP)
		{
			KHKAAGCIJPO.FireNetworkRPC(MPHCNMDIPAI, GGJPNLDIGGM, (byte)OKHEHHEJIOB);
		}
		else
		{
			KHKAAGCIJPO.Fire(MPHCNMDIPAI);
		}
	}

	protected virtual void DEFKBAMEKFI()
	{
	}

	public virtual bool StartShooting()
	{
		if (GLNJNLEHCDC == null)
		{
			return false;
		}
		OONPHPCNBJF = UnityEngine.Random.Range(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon.fireBatchSizeMax);
		OONPHPCNBJF = Mathf.Clamp(OONPHPCNBJF, 0, 14);
		MJNENAGPCGF = 0;
		OKHEHHEJIOB = PBFFNNJBANH(GLNJNLEHCDC);
		if (LGCNELDNFAE)
		{
			SwitchWeapon(AFKKHLPPGLN: true);
			OONPHPCNBJF = 1;
			LGCNELDNFAE = false;
		}
		ECOJGJHKPNE = new BitVector32(0);
		for (int i = 0; i < OONPHPCNBJF; i++)
		{
			ECOJGJHKPNE[1 << i] = UnityEngine.Random.value < soldierBehaviourDefinititon.probabilityOfRealShot;
		}
		ONMMKNNPFMG = KHKAAGCIJPO as PhysicalAmmoWeapon != null;
		NFGCPLPKAIP = false;
		PlayerController playerController = GLNJNLEHCDC.shootableEntity.owner as PlayerController;
		if (playerController != null && !playerController.FEHCCGEGPLH.isMine)
		{
			NFGCPLPKAIP = true;
		}
		NFGCPLPKAIP &= !ONMMKNNPFMG;
		return true;
	}

	public virtual void ShootJustStarted()
	{
		if (LMNPOINIJBD.LAADDLGBFIG.isMine && !ONMMKNNPFMG && !POPLFNCCLHJ)
		{
			LMNPOINIJBD.LAADDLGBFIG.RPC("SoldierBehaviourStartShootingNetwork", PhotonTargets.Others, OEDJOFINBMI, ECOJGJHKPNE.Data, !NFGCPLPKAIP, (byte)OKHEHHEJIOB, (byte)OONPHPCNBJF);
		}
	}

	public void StartShootingNetworkRPC(Vector3 MPHCNMDIPAI, int NGIPEIHHFPB, bool CAKABHIPCDF, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		MJNENAGPCGF = 0;
		ECOJGJHKPNE = new BitVector32(NGIPEIHHFPB);
		OONPHPCNBJF = COAEOPHBCOE;
		EIGIBELADLF = true;
		OEDJOFINBMI = MPHCNMDIPAI;
		NFGCPLPKAIP = CAKABHIPCDF;
		OKHEHHEJIOB = (Ammo.ILIOELBBLDM)EBNMDKAEJAH;
	}

	protected override void Update()
	{
		base.Update();
		if (!EIGIBELADLF || !KHKAAGCIJPO.willShoot || !LMNPOINIJBD.isAlive || IILCGHOLDHF.weaponIndex == 1)
		{
			return;
		}
		if (ECOJGJHKPNE[1 << MJNENAGPCGF])
		{
			MDKABJDCKBI(OEDJOFINBMI, GGJPNLDIGGM: false);
		}
		else
		{
			Vector3 vector = Vector3.Cross(base.transform.position - OEDJOFINBMI, Vector3.up).normalized * UnityEngine.Random.Range(0.3f, 0.5f);
			if ((double)UnityEngine.Random.value < 0.5)
			{
				vector = -vector;
			}
			MDKABJDCKBI(OEDJOFINBMI + vector + new Vector3(0f, 0.3f, 0f), GGJPNLDIGGM: true);
		}
		LMNPOINIJBD.OnShot();
		MJNENAGPCGF++;
		if (MJNENAGPCGF >= OONPHPCNBJF)
		{
			MJNENAGPCGF = 0;
			LMNPOINIJBD.EndShooting();
			EIGIBELADLF = false;
		}
	}

	public virtual void Restart()
	{
		if (LMNPOINIJBD.LAADDLGBFIG.isMine || LMNPOINIJBD.LCDBACDIODH)
		{
			EEMHAHAINNM = IILCGHOLDHF.AttachAllWeapons(BMNHHCCBAAN, LMNPOINIJBD.spawnedByCard, IGLLHPCDHLD, LMNPOINIJBD.PFGLIAHPMCK);
			KHKAAGCIJPO = IILCGHOLDHF.SwitchWeapon(0);
			if (LMNPOINIJBD.LCDBACDIODH && EEMHAHAINNM.Count > 1)
			{
				KHKAAGCIJPO = IILCGHOLDHF.SwitchWeapon(1);
			}
			IMPKCOOHBAG();
			KMINNAEBJAB();
		}
		MJNENAGPCGF = 0;
		StopAllCoroutines();
		EIGIBELADLF = false;
		POPLFNCCLHJ = false;
	}

	protected void IMPKCOOHBAG()
	{
		if (EEMHAHAINNM != null)
		{
			byte[] array = new byte[EEMHAHAINNM.Count];
			for (int i = 0; i < EEMHAHAINNM.Count; i++)
			{
				Weapon weapon = EEMHAHAINNM[i];
				array[i] = (byte)weapon.indexInObjectPool;
			}
			if (!LMNPOINIJBD.LCDBACDIODH)
			{
				FEHCCGEGPLH.RPC("AttachWeaponsRPC", PhotonTargets.Others, array);
			}
		}
	}

	protected virtual void KMINNAEBJAB()
	{
		IILCGHOLDHF.SetOwner(LMNPOINIJBD);
		EEMHAHAINNM[0].ammoSetup.EPDELOGPNAC = soldierBehaviourDefinititon.damage;
		EEMHAHAINNM[0].ammoSetup.NLCFDPBLBIG = upgradeSlots.playerDamageRatio;
		EEMHAHAINNM[0].ammoSetup.ADKJBFFFCEH = upgradeSlots.playerDamageOvertimeRatio;
		EEMHAHAINNM[0].JMDLKIAKOIE = 0.35f;
		Gun gun = EEMHAHAINNM[0] as Gun;
		if (gun != null)
		{
			gun.AEKBMHEFNHH = Vector3.zero;
		}
		foreach (Weapon allWeapon in allWeapons)
		{
			allWeapon.ammoSetup.Reset();
			BulletSetup bulletSetup = allWeapon.ammoSetup as BulletSetup;
			if (bulletSetup != null)
			{
				bulletSetup.JPNAINOGAMM = soldierBehaviourDefinititon.shotSpeed;
			}
		}
	}

	public override void ReSync()
	{
		base.ReSync();
		IMPKCOOHBAG();
	}

	[PunRPC]
	protected virtual void AttachWeaponsRPC(byte[] JNPECKEDLCG)
	{
		if (EEMHAHAINNM == null)
		{
			EEMHAHAINNM = IILCGHOLDHF.AttachAllWeapons(BMNHHCCBAAN, JNPECKEDLCG, LMNPOINIJBD.spawnedByCard, IGLLHPCDHLD, LMNPOINIJBD.PFGLIAHPMCK);
			KHKAAGCIJPO = IILCGHOLDHF.SwitchWeapon(0);
			KMINNAEBJAB();
		}
	}

	public void ImproveAllWeapons(float EPOJHJMEGAK)
	{
		for (int i = 0; i < EEMHAHAINNM.Count; i++)
		{
			AmmoSetup ammoSetup = EEMHAHAINNM[i].ammoSetup;
			ammoSetup.EPDELOGPNAC = (float)ammoSetup.EPDELOGPNAC * EPOJHJMEGAK;
		}
	}

	public override void DestroyBehaviour()
	{
		base.DestroyBehaviour();
		EEMHAHAINNM = null;
		if ((bool)IILCGHOLDHF)
		{
			IILCGHOLDHF.DestroyWeapons();
		}
		if ((bool)IGLLHPCDHLD)
		{
			IGLLHPCDHLD.NullTexturesAndMeshes();
		}
	}

	protected void GOOKGAHJEHA(UnitType NAKDNAEPGOF, GameShootableEntity.LAAAMBBNIJO AJJHKGBOCLK = GameShootableEntity.LAAAMBBNIJO.AllIn)
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(LMNPOINIJBD.fraction, NAKDNAEPGOF);
		GameShootableEntity gameShootableEntity;
		if (opponents.Count > 0)
		{
			gameShootableEntity = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		}
		else
		{
			opponents = GameShootableEntity.GetOpponents(LMNPOINIJBD.fraction, GameShootableEntity.ADEJMDKCFIF);
			if (opponents.Count <= 0)
			{
				IEONNICKBBH(upgradeSlots.shieldHitProbability);
				return;
			}
			gameShootableEntity = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		}
		if (!(gameShootableEntity == null))
		{
			if (IILCGHOLDHF.weaponIndex == 1)
			{
				OEDJOFINBMI = gameShootableEntity.transform.position;
			}
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(AJJHKGBOCLK);
			int index = UnityEngine.Random.Range(0, shotTargets.Count);
			if (shotTargets.Count == 0 && AJJHKGBOCLK != GameShootableEntity.LAAAMBBNIJO.AllIn)
			{
				shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn);
			}
			if (shotTargets.Count > 0)
			{
				OEDJOFINBMI = shotTargets[index].transform.position;
				GLNJNLEHCDC = shotTargets[index];
			}
		}
	}

	protected void GOOKGAHJEHA()
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.PickRandomOponentOf(LMNPOINIJBD.fraction);
		if (gameShootableEntity == null)
		{
			return;
		}
		if (gameShootableEntity.owner is PlayerController)
		{
			IEONNICKBBH();
			return;
		}
		if (IILCGHOLDHF.weaponIndex == 1)
		{
			OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		}
		List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn);
		int index = UnityEngine.Random.Range(0, shotTargets.Count);
		GLNJNLEHCDC = shotTargets[index];
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
	}

	protected bool BAGHBFNKEOP()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents<Decoy>(LMNPOINIJBD.fraction);
		if (opponents.Count == 0)
		{
			return false;
		}
		GameShootableEntity gameShootableEntity = opponents[UnityEngine.Random.Range(0, opponents.Count)];
		List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.All);
		GLNJNLEHCDC = shotTargets[UnityEngine.Random.Range(0, shotTargets.Count)];
		OEDJOFINBMI = GLNJNLEHCDC.transform.position;
		return true;
	}

	protected Ammo.ILIOELBBLDM PBFFNNJBANH(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL != null && MKIPAEDAADL.type == GameShootableEntity.LAAAMBBNIJO.Shield)
		{
			return Ammo.ILIOELBBLDM.Shield;
		}
		return Ammo.ILIOELBBLDM.Real;
	}

	protected void IEONNICKBBH(float ACANDIBFIHF = 0.5f)
	{
		if (ACANDIBFIHF < 0f)
		{
			return;
		}
		PlayerController randomEnemy = PlayerController.GetRandomEnemy(LMNPOINIJBD.fraction);
		GameShootableEntity gameShootableEntity = randomEnemy.gameShootableEntity;
		float num = Vector3.Angle(randomEnemy.aimForward, LMNPOINIJBD.NGCDDPCAGJB.position - gameShootableEntity.mTransform.position);
		if (randomEnemy.playerState == PlayerController.KKPHPLOEACG.Walking)
		{
			ACANDIBFIHF *= 0.5f;
		}
		bool flag = false;
		if (num > 50f || UnityEngine.Random.value <= ACANDIBFIHF)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield);
			if (shotTargets.Count > 0)
			{
				int index = UnityEngine.Random.Range(0, shotTargets.Count);
				GLNJNLEHCDC = shotTargets[index];
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
				flag = true;
			}
		}
		if (!flag)
		{
			if (randomEnemy.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.Moving, LMNPOINIJBD.NGCDDPCAGJB.position);
				OEDJOFINBMI = Singleton<AimingHelper>.instance.PredictPosition(KHKAAGCIJPO, GLNJNLEHCDC.transform.position, gameShootableEntity.velocity, 0.1f);
			}
			else
			{
				GLNJNLEHCDC = gameShootableEntity.GetNearestTarget(GameShootableEntity.LAAAMBBNIJO.WholeBody, LMNPOINIJBD.NGCDDPCAGJB.position);
				OEDJOFINBMI = GLNJNLEHCDC.transform.position;
			}
		}
	}

	public virtual void StartEnemyBehaviour()
	{
		if (LMNPOINIJBD.spawnPoint is SpawnPointParachute)
		{
			LMNPOINIJBD.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Parachute);
		}
		else
		{
			LMNPOINIJBD.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Walk);
		}
	}

	public virtual void OnDeath(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
	}

	public override void Unload()
	{
		base.Unload();
		foreach (SoldierMeshChanger.SoldierStyle item in CLNNHFGKNJO)
		{
			item.JLDGPBOIFJG();
		}
		foreach (SoldierMeshChanger.SoldierStyle item2 in JOMLOFIIKLP)
		{
			item2.JLDGPBOIFJG();
		}
		foreach (SoldierMeshChanger.SoldierStyle item3 in NILIABODEBO)
		{
			item3.JLDGPBOIFJG();
		}
		EnemyBasicInventory enemyBasicInventory = (EnemyBasicInventory)SingletonSupport.FirstOrDefault((UnityEngine.Object[])GetComponentsInChildren<EnemyBasicInventory>(includeInactive: true));
		if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
		{
			return;
		}
		foreach (EnemyBasicInventory.InventoryWeapon item4 in enemyBasicInventory.GGKGGMNIDMI)
		{
			EnemyLeveledWeapon[] componentsInChildren = item4.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(includeInactive: true);
			if (componentsInChildren.Length > 0)
			{
				EnemyLeveledWeapon enemyLeveledWeapon = componentsInChildren[0];
				enemyLeveledWeapon.UnloadModels(-1);
			}
		}
	}

	public virtual void StandShoot()
	{
		LMNPOINIJBD.StartStandShoot();
	}

	private List<SoldierMeshChanger.SoldierStyle> CBMEKCFKKOD(UpgradeSlots.UnitUpgrades KBBDGCLPOCJ)
	{
		if (KBBDGCLPOCJ.isElite && JOMLOFIIKLP.Count > 0)
		{
			return JOMLOFIIKLP;
		}
		if (KBBDGCLPOCJ.isVeteran && NILIABODEBO.Count > 0)
		{
			return NILIABODEBO;
		}
		return CLNNHFGKNJO;
	}

	public virtual float GetNextShotTime()
	{
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Walk)
		{
			return UnityEngine.Random.Range(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon.walkShotTimeMax);
		}
		return UnityEngine.Random.Range(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon.maxShootTime);
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerator ACJGAJNLKJB(UpgradeSlots.UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB, bool OFICDODLPCK, bool DODBHDBBKJI)
	{
		return base.PrepareVisualsForGameCoroutine(PFGLIAHPMCK, EFBPOCHCGPB, OFICDODLPCK, DODBHDBBKJI);
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerator KMMIFAKFEDL(bool OFICDODLPCK, bool FBCLJFNNJGG)
	{
		return base.PrepareVisualsForCardCoroutine(OFICDODLPCK, FBCLJFNNJGG);
	}

	[CompilerGenerated]
	private void JAAHMLLFKKD()
	{
		SwitchWeapon(AFKKHLPPGLN: false);
	}
}
