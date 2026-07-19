using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class ArmyPreviewCamera : Singleton<ArmyPreviewCamera>
{
	private sealed class IFDPBDPGLGG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal ArmyUnit3DModel HMEFCHGLFIF;

		internal LevelBehaviour EFHPOHNNGGH;

		internal AIObject DOGHDHGLCDF;

		internal ArmyPreviewCamera BJGCPDNMHDH;

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

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
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
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)5;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.JIPKECFGPOP(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 171f), false, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.PJKKMBBPILB(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.CHHLLIAHECC().PKFDDOIEMMC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)7;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.JOJLCHMOKMG(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 267f), false, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.PJKKMBBPILB(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().ReInstantiate(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
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
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)3;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.IAMMOGENHAD(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 647f), true, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Enemies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.CNEADELKALM(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1293f), true, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IBNEIKFHJML(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)3;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.MFKPDKCLDBI().CNEDMJIOECH(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.DNEFJHHMGIL(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1826f), false, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.DNEFJHHMGIL(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)8;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().IJKKOCDFLAF(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.JOJLCHMOKMG(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1009f), true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IBNEIKFHJML(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.DFCOIAFKJNF(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.MFKPDKCLDBI().IJKKOCDFLAF(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.CNEADELKALM(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1589f), true, false, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IAMMOGENHAD(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)8;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.JOJLCHMOKMG(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 413f), false, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.JOJLCHMOKMG(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)5;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().FLKHKLDOAPD(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
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
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)7;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.DNEFJHHMGIL(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 91f), true, false, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.DNEFJHHMGIL(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().PKFDDOIEMMC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
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
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)4;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.JOJLCHMOKMG(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1286f), false, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)3;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.networkPool.PKFDDOIEMMC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)3;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.CNEADELKALM(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 511f), true, false, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IAMMOGENHAD(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)4;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)4;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.PJKKMBBPILB(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1269f), false, false, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)4;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().ReInstantiate(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)7;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.PJKKMBBPILB(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1802f), true, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.CHHLLIAHECC().CNEDMJIOECH(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void NIGDCBDKKMJ()
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
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.CNEADELKALM(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH), true, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.Allies;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)6;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.CNEADELKALM(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1088f), true, false, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IAMMOGENHAD(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.DKNHCGGKNMF().PKFDDOIEMMC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.PJKKMBBPILB(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1992f), true, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)4;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.EHFPBDJMGNC().KBBMHOCIMCE(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public IFDPBDPGLGG()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.CNEADELKALM(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 704f), false, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.PJKKMBBPILB(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)5;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KKCMCNCCIMB().IJKKOCDFLAF(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)4;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.IBNEIKFHJML(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 74f), false, true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.CNEADELKALM(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.DFCOIAFKJNF(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)4;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.CHHLLIAHECC().ReInstantiate(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.JOJLCHMOKMG(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 693f), false, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.PJKKMBBPILB(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.Allies;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.INOJHPIKICM().IONKGACHEBC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)6;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.JIPKECFGPOP(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 368f), true, false, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.DNEFJHHMGIL(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = false;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)5;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().KBBMHOCIMCE(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)4;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.DNEFJHHMGIL(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 576f), true, true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IBNEIKFHJML(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().IONKGACHEBC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)4;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				BJGCPDNMHDH.JOJLCHMOKMG(true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 315f), true, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.IAMMOGENHAD(false);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JABOGKJNMPD(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.None;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().FLKHKLDOAPD(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return false;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Enemies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				BJGCPDNMHDH.JIPKECFGPOP(false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 896f), true, false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				if (BJGCPDNMHDH.GNICEGBOGOL.enabled)
				{
					BJGCPDNMHDH.PJKKMBBPILB(true);
					DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(EFHPOHNNGGH);
					if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
					{
						DOGHDHGLCDF.LCDBACDIODH = true;
						DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
						BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.DKNHCGGKNMF().PKFDDOIEMMC(DOGHDHGLCDF);
						BJGCPDNMHDH.ECHHMOPLOHK = BJGCPDNMHDH.BJHPKLAEFCI.transform.parent;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.IGMMGPKPHFF;
						BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
					}
					HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
					BJGCPDNMHDH.IGMMGPKPHFF.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
					BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
					BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					BJGCPDNMHDH.JDEMAFGJGLD = EFHPOHNNGGH.modelStartRotation.x;
					BJGCPDNMHDH.NOJFJANOHEB = EFHPOHNNGGH.modelStartRotation.y;
					BJGCPDNMHDH.IGMMGPKPHFF.localPosition = EFHPOHNNGGH.modelPosition;
					BJGCPDNMHDH.LPCNFLHNBJM();
					CLPPIAGLCJJ = -1;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class JPPOIIGPOKN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float MCAKMECBJNA;

		internal float KJLAOLGJKON;

		internal float DAGJEENMJHN;

		internal float ILLLINCHMPD;

		internal float IOIPJCICLFH;

		internal float DOLIFOGBPKB;

		internal ArmyPreviewCamera BJGCPDNMHDH;

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

		public bool NHLBGCIDHDE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1044f;
				KJLAOLGJKON = BJGCPDNMHDH.ALOOKAGDCMF(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.JFDBKNODOOM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.CFGGHLOCEAC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void FMINPCPGBBG()
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
				MCAKMECBJNA = 1767f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ACLELKCLKDM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.DCHIHGIJHMC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 995f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.HEOHMAPEABO(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OMIHGPNFCEG();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OMIHGPNFCEG();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NFAMBMLLFGP()
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
				MCAKMECBJNA = 206f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.CFGGHLOCEAC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.DCHIHGIJHMC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
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
				MCAKMECBJNA = 66f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.JDANLACEGGJ(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ACLELKCLKDM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1511f;
				KJLAOLGJKON = BJGCPDNMHDH.JDANLACEGGJ(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.HEOHMAPEABO(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.DCHIHGIJHMC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 766f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.DCHIHGIJHMC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1839f;
				KJLAOLGJKON = BJGCPDNMHDH.NDMEPFKOCFG(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.ALOOKAGDCMF(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OMIHGPNFCEG();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 496f;
				KJLAOLGJKON = BJGCPDNMHDH.NDMEPFKOCFG(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.JFDBKNODOOM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ACLELKCLKDM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INHIPKJFGDI()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1208f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.HEOHMAPEABO(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.GHKDEDKCLGB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OMIHGPNFCEG();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool FJKEEKBNKPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 801f;
				KJLAOLGJKON = BJGCPDNMHDH.JDANLACEGGJ(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.GHKDEDKCLGB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.DCHIHGIJHMC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1592f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.FCPCLOFOAFM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OMIHGPNFCEG();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 429f;
				KJLAOLGJKON = BJGCPDNMHDH.JDANLACEGGJ(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ACLELKCLKDM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.JFDBKNODOOM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 805f;
				KJLAOLGJKON = BJGCPDNMHDH.ALOOKAGDCMF(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.JDANLACEGGJ(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OMIHGPNFCEG();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OMIHGPNFCEG();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
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
				MCAKMECBJNA = 0f;
				KJLAOLGJKON = BJGCPDNMHDH.NIPCCIMMKJM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NHFMKLGIKPM()
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
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KPNBIPDNGOM()
		{
			return PHDOCKCBJOF;
		}

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		public void CPEEDIDEKLA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public bool EOLNOFMPMHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1747f;
				KJLAOLGJKON = BJGCPDNMHDH.JDANLACEGGJ(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.CFGGHLOCEAC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.CFGGHLOCEAC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 560f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.FCPCLOFOAFM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.GHKDEDKCLGB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.CFGGHLOCEAC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		public void LDBLCPIGLOF()
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
				MCAKMECBJNA = 990f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OMIHGPNFCEG();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OMIHGPNFCEG();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool BJBEBPMDICE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1345f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.ALOOKAGDCMF(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.CFGGHLOCEAC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.GHKDEDKCLGB();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public JPPOIIGPOKN()
		{
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1421f;
				KJLAOLGJKON = BJGCPDNMHDH.ALOOKAGDCMF(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OMIHGPNFCEG();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.CFGGHLOCEAC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1542f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.ALOOKAGDCMF(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.CFGGHLOCEAC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1901f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.CFGGHLOCEAC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ACLELKCLKDM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 1332f;
				KJLAOLGJKON = BJGCPDNMHDH.JDANLACEGGJ(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.ACLELKCLKDM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ACLELKCLKDM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void AGFMDCEAJNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 560f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NIPCCIMMKJM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OMIHGPNFCEG();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.GHKDEDKCLGB();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FLJNAIIJAFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public bool PKOMECFNPIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 368f;
				KJLAOLGJKON = BJGCPDNMHDH.ALOOKAGDCMF(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.JDANLACEGGJ(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.JFDBKNODOOM();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.OFIOGEFPPKO();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 221f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.FCPCLOFOAFM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.CFGGHLOCEAC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.CFGGHLOCEAC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OLMAFKDGMDB()
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
				MCAKMECBJNA = 1623f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.FCPCLOFOAFM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.DCHIHGIJHMC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.JFDBKNODOOM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool LHBPPCGLHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 335f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.ALOOKAGDCMF(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.OFIOGEFPPKO();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.DCHIHGIJHMC();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void GILIKCEGIIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DBHJAIKDJCG()
		{
			return PHDOCKCBJOF;
		}

		public bool AKHEIOMMAJL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 863f;
				KJLAOLGJKON = BJGCPDNMHDH.FCPCLOFOAFM(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.FCPCLOFOAFM(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.CFGGHLOCEAC();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.JFDBKNODOOM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public bool LGOHLNFJKNL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				MCAKMECBJNA = 982f;
				KJLAOLGJKON = BJGCPDNMHDH.HEOHMAPEABO(BJGCPDNMHDH.JDEMAFGJGLD);
				DAGJEENMJHN = BJGCPDNMHDH.NOJFJANOHEB;
				ILLLINCHMPD = BJGCPDNMHDH.NDMEPFKOCFG(ILLLINCHMPD);
				goto case 1u;
			case 1u:
				if (MCAKMECBJNA < IOIPJCICLFH)
				{
					BJGCPDNMHDH.JDEMAFGJGLD = Mathf.Lerp(KJLAOLGJKON, ILLLINCHMPD, MCAKMECBJNA / IOIPJCICLFH);
					BJGCPDNMHDH.NOJFJANOHEB = Mathf.Lerp(DAGJEENMJHN, DOLIFOGBPKB, MCAKMECBJNA / IOIPJCICLFH);
					MCAKMECBJNA += Time.deltaTime;
					BJGCPDNMHDH.GHKDEDKCLGB();
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.JDEMAFGJGLD = ILLLINCHMPD;
				BJGCPDNMHDH.NOJFJANOHEB = DOLIFOGBPKB;
				BJGCPDNMHDH.ACLELKCLKDM();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void IFBOOBLACGK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class NLCCAKIBMON : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerTexturePool.DFJJOANIJID FJLBLLLEELD;

		internal DatabasePlayer FHPICFHABBJ;

		internal bool PNDNEMDPFHC;

		internal RenderTexture PIPEPCHFCDF;

		internal Texture2D EBFDAICCJAK;

		internal ArmyPreviewCamera BJGCPDNMHDH;

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

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(814f, 67f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(382f, 277f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(76f, 1471f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public bool NAOFKEEIFCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(675f, 887f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void CALPCMFJHMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KOKJMKHECGK()
		{
			throw new NotSupportedException();
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(270f, 1695f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool AIFKBHCOIKG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(823f, 930f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object KBOFICGMHNF()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void GOGEDHILBIA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1808f, 717f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(628f, 345f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool ANIKAJEKMPM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(962f, 1435f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(453f, 1605f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object IDBEGKHBNBC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(33f, 578f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJONKJIBHGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKEJDEGFKLC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NANCGKHPCAN()
		{
			return PHDOCKCBJOF;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(408f, 720f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1545f, 1378f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(100f, 1410f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(786f, 1224f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(33f, 1942f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool AAOIPMCCPEM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1354f, 134f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(506f, 1241f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(121f, 412f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void GILIKCEGIIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJEDLKAFEIN()
		{
			return PHDOCKCBJOF;
		}

		public bool LAICPPPPIKL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1557f, 1657f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(934f, 683f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ABGFJLAPNNM()
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
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(0f, 0f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GHILCKCFAFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void EPIIDCKHCIN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1303f, 1207f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NNACGJNFEGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(893f, 1423f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object MJKLPCMKADD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OGHGAAFEEMH()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public NLCCAKIBMON()
		{
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1634f, 476f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
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

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLBPPBIIAFP()
		{
			return PHDOCKCBJOF;
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(514f, 1655f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class MMGLHELMAGI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerTexturePool.DFJJOANIJID FJLBLLLEELD;

		internal string[] AMPMNLIKMIF;

		internal bool PNDNEMDPFHC;

		internal RenderTexture PIPEPCHFCDF;

		internal Texture2D EBFDAICCJAK;

		internal ArmyPreviewCamera BJGCPDNMHDH;

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
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		public void BPFAJJGHCCD()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1603f, 319f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1228f, 575f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BIGMAMMHKFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		public bool FCPJPIDEPOF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(873f, 122f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCELHKMHCOB()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(736f, 1184f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public MMGLHELMAGI()
		{
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1822f, 1128f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void HHPHMIJOAPL()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(0f, 0f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NNACGJNFEGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void KOKJMKHECGK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1650f, 415f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object DOCGGPBBOAD()
		{
			return PHDOCKCBJOF;
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(324f, 1961f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1181f, 1125f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1009f, 528f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1263f, 1331f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1605f, 780f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(560f, 1352f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OIIFFJADGJG()
		{
			throw new NotSupportedException();
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1784f, 1172f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1975f, 998f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1469f, 1565f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1572f, 1454f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void FILDGEMDECJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1471f, 868f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public bool NHLBGCIDHDE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(337f, 403f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1583f, 807f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, AMPMNLIKMIF, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.FCEIGDLFOMH;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1917f, 726f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}
	}

	private sealed class JAIAGHOBDGK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal RenderTexture KFGOELIKDAA;

		internal bool DNCMDLDABHK;

		internal PlayerController KHLGDCHJJPB;

		internal PlayerTexturePool.DFJJOANIJID FJLBLLLEELD;

		internal float CFOGPKNIADI;

		internal bool PNDNEMDPFHC;

		internal RenderTexture PIPEPCHFCDF;

		internal Texture2D EBFDAICCJAK;

		internal ArmyPreviewCamera BJGCPDNMHDH;

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

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public JAIAGHOBDGK()
		{
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Card);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GGKGGMNIDMI = KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM();
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().LJELEJEJIEB().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 88f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().JNFHKEJCIIA().IsLoaded())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					UnityEngine.Debug.LogError("Card_2_Played");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(630f, 731f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)8);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.LPGACOBNHOH(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.JLMDEMFIHCA().JKHKBGPKFFF().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 177f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().PDLFJEDGLAO().ECBIINCONOI())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					UnityEngine.Debug.LogError("players");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1600f, 872f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void HNOPIDGLMPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IDCJDJMGKFG()
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
		private object MNAKOOGPNOH()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)4);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GNGLDJHHIHM(KHLGDCHJJPB.EHHHBEMKGOE.GGKGGMNIDMI);
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().JKHKBGPKFFF().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 767f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.OLHICLNCPNA().IsLoaded())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					UnityEngine.Debug.LogError("LastAction");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1728f, 596f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)3);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GGKGGMNIDMI = KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM();
				BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.JKHKBGPKFFF().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 48f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.JECOEJBGKDF().IsLoaded())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					UnityEngine.Debug.LogError(" found!");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(921f, 1221f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)5);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.LPGACOBNHOH(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().currentWeapon.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 1488f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.MFHBEJOLGLC().IsLoaded())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					UnityEngine.Debug.LogError("IsVip");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(392f, 636f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)8);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.LPGACOBNHOH(KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM());
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().MFHBEJOLGLC().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 1374f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.JLMDEMFIHCA().APLKMLDHMDL().IsLoaded())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					UnityEngine.Debug.LogError("S");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1157f, 1590f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void EFDJMHAPDLB()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)6);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GGKGGMNIDMI = KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI();
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().JECOEJBGKDF().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 1113f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.PDLFJEDGLAO().PLBOBFDIBBJ())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					UnityEngine.Debug.LogError("ExtraWarBucks");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(406f, 1923f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Classic);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GGKGGMNIDMI = KHLGDCHJJPB.EHHHBEMKGOE.GGKGGMNIDMI;
				BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.currentWeapon.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 5f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.currentWeapon.IsLoaded())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					UnityEngine.Debug.LogError("Render player texture ERROR: Weapon load failed! (timeouted - 5 sec)");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(0f, 0f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Card);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.LPGACOBNHOH(KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM());
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().OLHICLNCPNA().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 141f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.JKHKBGPKFFF().PLBOBFDIBBJ())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					UnityEngine.Debug.LogError("AttakUnits");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(942f, 1615f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Classic);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.LPGACOBNHOH(KHLGDCHJJPB.EHHHBEMKGOE.GGKGGMNIDMI);
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().CILCMCDCKKE().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 284f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.JLMDEMFIHCA().PDLFJEDGLAO().IsLoaded())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					UnityEngine.Debug.LogError("nonEliteUnits");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(919f, 1643f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public bool ECPGMIIEFDP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)4);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.INLLAMGKOMM(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.JNFHKEJCIIA().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 1150f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.MFHBEJOLGLC().IsLoaded())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					UnityEngine.Debug.LogError("#VAVRO# SETTING BOT DIFICULTY TO: ");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1363f, 1860f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Card);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GNGLDJHHIHM(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.APLKMLDHMDL().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 987f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().APLKMLDHMDL().PLBOBFDIBBJ())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					UnityEngine.Debug.LogError("08");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(739f, 555f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Card);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GGKGGMNIDMI = KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM();
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().JKHKBGPKFFF().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 962f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().CILCMCDCKKE().ECBIINCONOI())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					UnityEngine.Debug.LogError("ID_HOUR_SMALL");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(815f, 181f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)4);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.LPGACOBNHOH(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().APLKMLDHMDL().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 1366f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().PDLFJEDGLAO().PLBOBFDIBBJ())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					UnityEngine.Debug.LogError("Level");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1500f, 950f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public void KOEEOJGJNAO()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Classic);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GNGLDJHHIHM(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().currentWeapon.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 179f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().JKHKBGPKFFF().ECBIINCONOI())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					UnityEngine.Debug.LogError("ID_PACKEXCLUSIVE");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(373f, 1642f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FIDLDFGJLFK()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)3);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GNGLDJHHIHM(KHLGDCHJJPB.EHHHBEMKGOE.GGKGGMNIDMI);
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().JNFHKEJCIIA().gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 196f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().CILCMCDCKKE().PLBOBFDIBBJ())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					UnityEngine.Debug.LogError("game-card-ico-paralyzethese");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(198f, 1860f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)4);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.INLLAMGKOMM(KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM());
				BJGCPDNMHDH.MBHKGFFKGPC.JLMDEMFIHCA().LJELEJEJIEB().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 445f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.JLMDEMFIHCA().currentWeapon.ECBIINCONOI())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					UnityEngine.Debug.LogError("ID_INELITE2");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1414f, 181f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)6);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GGKGGMNIDMI = KHLGDCHJJPB.EHHHBEMKGOE.OGFGBNNKCDM();
				BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().CILCMCDCKKE().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 1910f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().MFHBEJOLGLC().PLBOBFDIBBJ())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					UnityEngine.Debug.LogError("Map_device_levelGroup");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(355f, 1545f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)5);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.ECFKOCPKODJ(KHLGDCHJJPB.EHHHBEMKGOE.GGKGGMNIDMI);
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().CILCMCDCKKE().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 410f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().APLKMLDHMDL().ECBIINCONOI())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					UnityEngine.Debug.LogError("Medals/");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(152f, 1826f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void CDDFJOEEFID()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Small);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.INLLAMGKOMM(KHLGDCHJJPB.EHHHBEMKGOE.GGKGGMNIDMI);
				BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.PDLFJEDGLAO().gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.CEAFAMFNGCC() + 1953f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.LJELEJEJIEB().PLBOBFDIBBJ())
				{
					if (!(TimeManager.realTimeWithoutPauses >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					UnityEngine.Debug.LogError("Bad object with NavigationHelperCapsule LAYER");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1267f, 830f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 0);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == (PlayerTexturePool.DFJJOANIJID)5);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GNGLDJHHIHM(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.weaponInventory.currentWeapon.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 1218f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.FMKGGADDHJK().PDLFJEDGLAO().ECBIINCONOI())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					UnityEngine.Debug.LogError("ElitePackDeadline");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1898f, 268f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 0, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
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
				KFGOELIKDAA = null;
				if (DNCMDLDABHK)
				{
					KFGOELIKDAA = (KHLGDCHJJPB.isCurrentPlayer ? BJGCPDNMHDH.FBLDAEEOAEN : ((KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction) ? BJGCPDNMHDH.HICMLKAOEJL : BJGCPDNMHDH.ABCBEIIKBPP));
				}
				else
				{
					KFGOELIKDAA = BJGCPDNMHDH.FCEIGDLFOMH;
				}
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
				CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, KHLGDCHJJPB.EHHHBEMKGOE.CBBDICBLHMM, FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Small);
				BJGCPDNMHDH.MBHKGFFKGPC.EHHHBEMKGOE.GNGLDJHHIHM(KHLGDCHJJPB.EHHHBEMKGOE.PCOLKKBLBOI());
				BJGCPDNMHDH.MBHKGFFKGPC.BEIIOAIJMFK().currentWeapon.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.SelectPrimary();
				BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
				CFOGPKNIADI = TimeManager.realTimeWithoutPauses + 1187f;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.MBHKGFFKGPC.JLMDEMFIHCA().CILCMCDCKKE().IsLoaded())
				{
					if (!(TimeManager.CEAFAMFNGCC() >= CFOGPKNIADI))
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					UnityEngine.Debug.LogError("menu-crown-bronze");
				}
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = KFGOELIKDAA;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				if (EBFDAICCJAK != null)
				{
					EBFDAICCJAK.ReadPixels(new Rect(1293f, 1883f, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.width, BJGCPDNMHDH.MGMBKDJJLLG.targetTexture.height), 1, 1);
					EBFDAICCJAK.Apply();
				}
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
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
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class HECCGOKNBIK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerTexturePool.DFJJOANIJID FJLBLLLEELD;

		internal DatabasePlayer FHPICFHABBJ;

		internal bool PNDNEMDPFHC;

		internal RenderTexture PIPEPCHFCDF;

		internal ArmyPreviewCamera BJGCPDNMHDH;

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
		private object MOMPOEEALPJ()
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
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
					BJGCPDNMHDH.MAILDHFJFBD(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NDPDPLMNAJK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(false);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public HECCGOKNBIK()
		{
		}

		[SpecialName]
		private object GCJFGIKENJA()
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
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.FFENGOLNHEK(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object EBPKDAHAELB()
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
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = false;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.NENEAEBLAAP(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals, true);
					BJGCPDNMHDH.MBHKGFFKGPC.BBLBLLCMBJG();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return false;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(false);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = false;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(true);
				BJGCPDNMHDH.BEKPEIKCJNM = true;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.BEKPEIKCJNM)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					BJGCPDNMHDH.BEKPEIKCJNM = true;
					BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
					BJGCPDNMHDH.GIHEJGJOPBI(FJLBLLLEELD);
					CamosManager.instance.ApplyVisuals(BJGCPDNMHDH.MBHKGFFKGPC, FHPICFHABBJ.playerVisuals);
					BJGCPDNMHDH.MBHKGFFKGPC.HideWeapon();
					BJGCPDNMHDH.MBHKGFFKGPC.Preview(true);
					BJGCPDNMHDH.MGMBKDJJLLG.enabled = true;
					BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = BJGCPDNMHDH.HICMLKAOEJL;
					BJGCPDNMHDH.DHCMAFEPGMP.SetActive(false);
					BJGCPDNMHDH.KMFGCJEGJJK.SetActive(PNDNEMDPFHC);
					PHDOCKCBJOF = new WaitForEndOfFrame();
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				PIPEPCHFCDF = RenderTexture.active;
				RenderTexture.active = BJGCPDNMHDH.MGMBKDJJLLG.targetTexture;
				BJGCPDNMHDH.MGMBKDJJLLG.Render();
				RenderTexture.active = PIPEPCHFCDF;
				BJGCPDNMHDH.MGMBKDJJLLG.targetTexture = null;
				BJGCPDNMHDH.MBHKGFFKGPC.gameObject.SetActive(true);
				BJGCPDNMHDH.MBHKGFFKGPC.KPIGIEPMLLC = true;
				BJGCPDNMHDH.DHCMAFEPGMP.SetActive(true);
				BJGCPDNMHDH.KMFGCJEGJJK.SetActive(false);
				BJGCPDNMHDH.BEKPEIKCJNM = false;
				BJGCPDNMHDH.MGMBKDJJLLG.enabled = false;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class EKBDAFJLEKI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal ArmyPreviewCamera BJGCPDNMHDH;

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

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 257f), true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 656f), false, true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1099f), false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1157f), true, false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void NDPOBCODJAI()
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
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 109f), true, false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
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

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1595f), false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void HMBLLDJFIJG()
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
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM), true, true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public EKBDAFJLEKI()
		{
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
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

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 268f), false, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
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
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 547f), true, true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 790f), false, true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 980f), true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1282f), true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
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
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1299f), false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = true;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 765f), false, false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(false);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
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
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1083f), false, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return true;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				if (BJGCPDNMHDH.BJHPKLAEFCI != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(BJGCPDNMHDH.BJHPKLAEFCI.IAJJBAJOGDM, 1880f), true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto IL_012c;
			case 3u:
				BJGCPDNMHDH.HPKCPHNLLNI = false;
				try
				{
					if (BJGCPDNMHDH.BJHPKLAEFCI != null)
					{
						BJGCPDNMHDH.BJHPKLAEFCI.PickUpgrades();
						BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(true);
					}
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
				goto IL_012c;
			default:
				{
					return false;
				}
				IL_012c:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}
	}

	public Camera MGMBKDJJLLG;

	public PlayerController MBHKGFFKGPC;

	public Vector3 OCMNOCJIKGG;

	public Vector3 JOJNCNBHIAE;

	public Vector3 MKAEPADDALH;

	public Vector3 BLGBKFBPLNE;

	public Vector3 JHCDIGAHHHM;

	public Vector3 HNJJIODPLHF;

	public GameObject DHCMAFEPGMP;

	public GameObject KMFGCJEGJJK;

	public RenderTexture FBLDAEEOAEN;

	public RenderTexture ABCBEIIKBPP;

	public RenderTexture HICMLKAOEJL;

	public RenderTexture FCEIGDLFOMH;

	public Transform IGMMGPKPHFF;

	public float GDPBMDGECEJ = -17f;

	public Transform MKIPAEDAADL;

	public float OPHGMIGGJBD = 5f;

	public float CPFPDNMMHDE = 120f;

	public float AHPEDEMHLKN = 120f;

	public float KCHPAOEFBMJ = -20f;

	public float LGKAPHLINKD = 80f;

	public float BIIDCODIKDC = 2f;

	public float KPHNBLPPNJJ = 5f;

	public static bool LNFFCOMNHDE = true;

	private float JDEMAFGJGLD;

	private float NOJFJANOHEB;

	private AIObject BJHPKLAEFCI;

	private Transform ECHHMOPLOHK;

	private bool BEKPEIKCJNM;

	private bool HEOAKILNIBA;

	private float MBLMPGLELFF;

	private float ADAKCEBFAFJ;

	private bool LILBNAFBNKJ = true;

	private Camera GNICEGBOGOL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<bool> EDPINEAGFBD;

	private bool HPKCPHNLLNI;

	public bool isLoadingPreview
	{
		get
		{
			return HPKCPHNLLNI;
		}
	}

	public event Action<bool> OnRotate
	{
		add
		{
			Action<bool> action = EDPINEAGFBD;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<bool> action = EDPINEAGFBD;
			Action<bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public bool CHNPEDLBGHI()
	{
		return HPKCPHNLLNI;
	}

	public void Pause()
	{
		GNICEGBOGOL.enabled = false;
	}

	private void DCHIHGIJHMC()
	{
		NOJFJANOHEB = GDHNNGCHOFF(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 1601f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	private void FFENGOLNHEK(PlayerTexturePool.DFJJOANIJID FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case PlayerTexturePool.DFJJOANIJID.Card:
			MBHKGFFKGPC.transform.localPosition = MKAEPADDALH;
			MBHKGFFKGPC.transform.localScale = BLGBKFBPLNE;
			break;
		case PlayerTexturePool.DFJJOANIJID.Classic:
			MBHKGFFKGPC.transform.localPosition = OCMNOCJIKGG;
			MBHKGFFKGPC.transform.localScale = JOJNCNBHIAE;
			break;
		default:
			MBHKGFFKGPC.transform.localPosition = JHCDIGAHHHM;
			MBHKGFFKGPC.transform.localScale = HNJJIODPLHF;
			break;
		}
	}

	public void LCIFJLNADFP(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(false);
		StartCoroutine(RadicalRoutine.Run(IIODOPODKLA(KHLGDCHJJPB, null, false, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	public void IJJLNAKHKIM()
	{
		GNICEGBOGOL.enabled = false;
	}

	public static float OBMIKNCPOGM(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 892f)
		{
			NIMFNNMAKPA += 1228f;
		}
		if (NIMFNNMAKPA > 701f)
		{
			NIMFNNMAKPA -= 6f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public void AIPKEHKDJCL(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(true);
		NCMHGPNPEJM.KLFFMPINIPB();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(true);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 1422f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 1932f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 1715f;
		NOJFJANOHEB = 1397f;
		CFGGHLOCEAC();
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(true);
	}

	public IEnumerator BOKMFOEFHAP(DatabasePlayer FHPICFHABBJ, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		HECCGOKNBIK hECCGOKNBIK = new HECCGOKNBIK();
		hECCGOKNBIK.FJLBLLLEELD = FJLBLLLEELD;
		hECCGOKNBIK.FHPICFHABBJ = FHPICFHABBJ;
		hECCGOKNBIK.PNDNEMDPFHC = PNDNEMDPFHC;
		hECCGOKNBIK.BJGCPDNMHDH = this;
		return hECCGOKNBIK;
	}

	private void CFGGHLOCEAC()
	{
		NOJFJANOHEB = HKOJEANLCEO(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 1871f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	public void HKNDJOANCAL()
	{
		MBHKGFFKGPC.gameObject.SetActive(false);
		MBHKGFFKGPC.EHHHBEMKGOE = CHEIFOOIMEH.FEFKJNHEEMG();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE = CHEIFOOIMEH.NLCGDAFBFNE();
		MBHKGFFKGPC.KLFFMPINIPB();
		MBHKGFFKGPC.gameObject.SetActive(true);
	}

	public void KIONJHBCIBE(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(false);
		StartCoroutine(RadicalRoutine.Run(IIODOPODKLA(KHLGDCHJJPB, null, true, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	protected override void Start()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		OPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
	}

	private IEnumerator DMDIKBAELPJ(LevelBehaviour EFHPOHNNGGH)
	{
		IFDPBDPGLGG iFDPBDPGLGG = new IFDPBDPGLGG();
		iFDPBDPGLGG.EFHPOHNNGGH = EFHPOHNNGGH;
		iFDPBDPGLGG.BJGCPDNMHDH = this;
		return iFDPBDPGLGG;
	}

	public void AGJBLMLFHAK(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.InitPlayerForCamera();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(true);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 239f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 237f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 1631f;
		NOJFJANOHEB = 894f;
		ACLELKCLKDM();
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(true);
	}

	public void ABNMKGJDMLG(float ILLLINCHMPD, float DOLIFOGBPKB, float KBJEOEEOEFG)
	{
		StartCoroutine(RadicalRoutine.Run(KGAHHFGEPCC(ILLLINCHMPD, DOLIFOGBPKB, KBJEOEEOEFG)));
	}

	public void FBHGHIDDDJO()
	{
		if (GNICEGBOGOL.enabled)
		{
			StartCoroutine(PJALBAKLABD());
		}
	}

	[SpecialName]
	public bool AEBHDPEOPCD()
	{
		return HPKCPHNLLNI;
	}

	public void JHKICLBBOCO(PlayerController NCMHGPNPEJM)
	{
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(false);
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
	}

	public void BGKCOAAFJPM()
	{
		GDPBMDGECEJ = 144f;
	}

	private void OFIOGEFPPKO()
	{
		NOJFJANOHEB = ClampAngle(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 0f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	private void AAJDOMLPINP()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			FEKFNLIEDLE();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 1919f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == "squad name")
				{
					HEOAKILNIBA = false;
					LILBNAFBNKJ = true;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(true);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			OMIHGPNFCEG();
		}
		if (Input.GetMouseButtonUp(1))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = false;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(false);
			}
		}
	}

	public void MDCPOGFDCPC(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(true);
		StartCoroutine(RadicalRoutine.Run(GHDHBPDGONH(KHLGDCHJJPB, null, true, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	private void FEKFNLIEDLE()
	{
		MBLMPGLELFF = Input.GetAxis("\n") * CPFPDNMMHDE * OPHGMIGGJBD * 1360f;
		ADAKCEBFAFJ = Input.GetAxis("NULL") * AHPEDEMHLKN * 1792f;
		JDEMAFGJGLD += MBLMPGLELFF;
		NOJFJANOHEB -= ADAKCEBFAFJ;
		OFIOGEFPPKO();
	}

	public void LKLFOMNIPOF()
	{
		GDPBMDGECEJ = 814f;
	}

	public void FAPKNHMIJOP(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.KLFFMPINIPB();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(false);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 156f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 555f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 1781f;
		NOJFJANOHEB = 393f;
		OMIHGPNFCEG();
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(true);
	}

	public void DisplayPlayer(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(true);
		NCMHGPNPEJM.InitPlayerForCamera();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(false);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = -0.21f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 1.2f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 150f;
		NOJFJANOHEB = 15f;
		OFIOGEFPPKO();
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(true);
	}

	private IEnumerator BKNKGGFCJEG(LevelBehaviour EFHPOHNNGGH)
	{
		IFDPBDPGLGG iFDPBDPGLGG = new IFDPBDPGLGG();
		iFDPBDPGLGG.EFHPOHNNGGH = EFHPOHNNGGH;
		iFDPBDPGLGG.BJGCPDNMHDH = this;
		return iFDPBDPGLGG;
	}

	private IEnumerator PDEJFMNCNLC(PlayerController KHLGDCHJJPB, Texture2D EBFDAICCJAK, bool DNCMDLDABHK = false, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		JAIAGHOBDGK jAIAGHOBDGK = new JAIAGHOBDGK();
		jAIAGHOBDGK.DNCMDLDABHK = DNCMDLDABHK;
		jAIAGHOBDGK.KHLGDCHJJPB = KHLGDCHJJPB;
		jAIAGHOBDGK.FJLBLLLEELD = FJLBLLLEELD;
		jAIAGHOBDGK.PNDNEMDPFHC = PNDNEMDPFHC;
		jAIAGHOBDGK.EBFDAICCJAK = EBFDAICCJAK;
		jAIAGHOBDGK.BJGCPDNMHDH = this;
		return jAIAGHOBDGK;
	}

	public void HKDNKJOBIND()
	{
		if (GNICEGBOGOL.enabled)
		{
			StartCoroutine(OFOCMDEPJGM());
		}
	}

	[DebuggerHidden]
	private IEnumerator FJLLEFMDDIA()
	{
		EKBDAFJLEKI eKBDAFJLEKI = new EKBDAFJLEKI();
		eKBDAFJLEKI.BJGCPDNMHDH = this;
		return eKBDAFJLEKI;
	}

	public void BDHBFHGBDOK(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(true);
		StartCoroutine(RadicalRoutine.Run(IIODOPODKLA(KHLGDCHJJPB, null, true, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	public IEnumerator HOLLAADDPAH(DatabasePlayer FHPICFHABBJ, Texture2D EBFDAICCJAK, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		NLCCAKIBMON nLCCAKIBMON = new NLCCAKIBMON();
		nLCCAKIBMON.FJLBLLLEELD = FJLBLLLEELD;
		nLCCAKIBMON.FHPICFHABBJ = FHPICFHABBJ;
		nLCCAKIBMON.PNDNEMDPFHC = PNDNEMDPFHC;
		nLCCAKIBMON.EBFDAICCJAK = EBFDAICCJAK;
		nLCCAKIBMON.BJGCPDNMHDH = this;
		return nLCCAKIBMON;
	}

	public void MJBIJOKEEHO()
	{
		GDPBMDGECEJ = 1182f;
	}

	[SpecialName]
	public void CFEFLMDFHFH(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool ANAIHFHOPEK()
	{
		return HPKCPHNLLNI;
	}

	public void JOENJIPGGEK()
	{
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
		IAMMOGENHAD(true);
	}

	private void OMIHGPNFCEG()
	{
		NOJFJANOHEB = HKOJEANLCEO(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 744f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	public void DHPMCFFBGGG()
	{
		if (GNICEGBOGOL.enabled)
		{
			StartCoroutine(PJALBAKLABD());
		}
	}

	public void EMIJBCNCIHM()
	{
		GNICEGBOGOL.enabled = false;
	}

	private void IAMMOGENHAD(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.DestroyPooled();
			BJHPKLAEFCI = null;
		}
	}

	[DebuggerHidden]
	public IEnumerator CreatePlayerTexture(string[] AMPMNLIKMIF, Texture2D EBFDAICCJAK, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		MMGLHELMAGI mMGLHELMAGI = new MMGLHELMAGI();
		mMGLHELMAGI.FJLBLLLEELD = FJLBLLLEELD;
		mMGLHELMAGI.AMPMNLIKMIF = AMPMNLIKMIF;
		mMGLHELMAGI.PNDNEMDPFHC = PNDNEMDPFHC;
		mMGLHELMAGI.EBFDAICCJAK = EBFDAICCJAK;
		mMGLHELMAGI.BJGCPDNMHDH = this;
		return mMGLHELMAGI;
	}

	private float NDMEPFKOCFG(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 1514f) * 1109f;
	}

	public void RenderToTexture(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(true);
		StartCoroutine(RadicalRoutine.Run(GHDHBPDGONH(KHLGDCHJJPB, null, true, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	public static float GDHNNGCHOFF(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 349f)
		{
			NIMFNNMAKPA += 1596f;
		}
		if (NIMFNNMAKPA > 1085f)
		{
			NIMFNNMAKPA -= 1813f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public void FEMBJCJLIDP(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.KLFFMPINIPB();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(true);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 1569f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 1493f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 1360f;
		NOJFJANOHEB = 1592f;
		JFDBKNODOOM();
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
	}

	public void DIMPHNLEKHG(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(true);
		StartCoroutine(RadicalRoutine.Run(PDEJFMNCNLC(KHLGDCHJJPB, null, false, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	private void ACLELKCLKDM()
	{
		NOJFJANOHEB = ClampAngle(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 351f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	public void DGNOFMEEAIA()
	{
		GDPBMDGECEJ = 1294f;
	}

	public Texture LPNCCMCJJEK()
	{
		return HICMLKAOEJL;
	}

	public void PLMPDABIKIP()
	{
		GNICEGBOGOL.enabled = true;
	}

	private void PLAKFADDELO()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			MMPKIBJAALB();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = true;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 1546f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == "game-engi-progress-fill")
				{
					HEOAKILNIBA = true;
					LILBNAFBNKJ = true;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(false);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			DCHIHGIJHMC();
		}
		if (Input.GetMouseButtonUp(1))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = true;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(true);
			}
		}
	}

	public void GADONFFCCKF()
	{
		GNICEGBOGOL.enabled = false;
	}

	public Texture NNHNDJLBFMH()
	{
		return HICMLKAOEJL;
	}

	public void FAANPLNEGEB(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.KLFFMPINIPB();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(false);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 1896f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 636f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 837f;
		NOJFJANOHEB = 1831f;
		JFDBKNODOOM();
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
	}

	public void Hide()
	{
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
		CNEADELKALM(true);
	}

	private void LateUpdate()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			ONLFIMAKMCF();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == "armyPreviewCollider")
				{
					HEOAKILNIBA = true;
					LILBNAFBNKJ = false;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(true);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			OFIOGEFPPKO();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = false;
			LILBNAFBNKJ = true;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(false);
			}
		}
	}

	public void PNIIDBHNMPF(PlayerController NCMHGPNPEJM)
	{
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(true);
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
	}

	public void KHPPCEHONHE(LevelBehaviour NCMHGPNPEJM)
	{
		CLAFENLOGOB();
		if (BJHPKLAEFCI != null && BJHPKLAEFCI.ACLDFHJKBLI.GetType() == NCMHGPNPEJM.GetType())
		{
			LNEHNFCFBPN(PlayerController.OGMBJPKOPCB);
			BJHPKLAEFCI.gameObject.SetActive(true);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			HKDNKJOBIND();
		}
		else
		{
			Hide();
			HidePlayer(PlayerController.OGMBJPKOPCB);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			StartCoroutine(DIAJBLLIDEL(NCMHGPNPEJM));
		}
	}

	public void HidePlayer(PlayerController NCMHGPNPEJM)
	{
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
	}

	private void GGKBJMHHNBL()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			MMPKIBJAALB();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 612f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == "Medals")
				{
					HEOAKILNIBA = true;
					LILBNAFBNKJ = true;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(true);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			OFIOGEFPPKO();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = false;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(false);
			}
		}
	}

	private float NIPCCIMMKJM(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 360f) * 360f;
	}

	protected virtual void NHAEGCBBJNP()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		OPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
	}

	public static float ClampAngle(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < -360f)
		{
			NIMFNNMAKPA += 360f;
		}
		if (NIMFNNMAKPA > 360f)
		{
			NIMFNNMAKPA -= 360f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	private void MPLBDOPIILJ()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			ONLFIMAKMCF();
		}
		if (Input.GetMouseButtonDown(1) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 523f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == "Switching to minigunner when shooting !!!")
				{
					HEOAKILNIBA = false;
					LILBNAFBNKJ = false;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(false);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			GHKDEDKCLGB();
		}
		if (Input.GetMouseButtonUp(1))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = true;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(true);
			}
		}
	}

	public IEnumerator KOKIKOCLOME(string[] AMPMNLIKMIF, Texture2D EBFDAICCJAK, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		MMGLHELMAGI mMGLHELMAGI = new MMGLHELMAGI();
		mMGLHELMAGI.FJLBLLLEELD = FJLBLLLEELD;
		mMGLHELMAGI.AMPMNLIKMIF = AMPMNLIKMIF;
		mMGLHELMAGI.PNDNEMDPFHC = PNDNEMDPFHC;
		mMGLHELMAGI.EBFDAICCJAK = EBFDAICCJAK;
		mMGLHELMAGI.BJGCPDNMHDH = this;
		return mMGLHELMAGI;
	}

	[SpecialName]
	public bool OFIFEEDDLAJ()
	{
		return HPKCPHNLLNI;
	}

	private IEnumerator IIODOPODKLA(PlayerController KHLGDCHJJPB, Texture2D EBFDAICCJAK, bool DNCMDLDABHK = false, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		JAIAGHOBDGK jAIAGHOBDGK = new JAIAGHOBDGK();
		jAIAGHOBDGK.DNCMDLDABHK = DNCMDLDABHK;
		jAIAGHOBDGK.KHLGDCHJJPB = KHLGDCHJJPB;
		jAIAGHOBDGK.FJLBLLLEELD = FJLBLLLEELD;
		jAIAGHOBDGK.PNDNEMDPFHC = PNDNEMDPFHC;
		jAIAGHOBDGK.EBFDAICCJAK = EBFDAICCJAK;
		jAIAGHOBDGK.BJGCPDNMHDH = this;
		return jAIAGHOBDGK;
	}

	public void Resume()
	{
		GNICEGBOGOL.enabled = true;
	}

	private void KDEHBKCOHHG()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			MMPKIBJAALB();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = true;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 1719f, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == "#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} gold")
				{
					HEOAKILNIBA = true;
					LILBNAFBNKJ = true;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(false);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			ACLELKCLKDM();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = true;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(false);
			}
		}
	}

	public void PFOHJOJOKLP()
	{
		GNICEGBOGOL.enabled = false;
	}

	private void JOJLCHMOKMG(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.BOHCNEDIJPE();
			BJHPKLAEFCI = null;
		}
	}

	public static float MELOMNKCFGH(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 746f)
		{
			NIMFNNMAKPA += 1385f;
		}
		if (NIMFNNMAKPA > 343f)
		{
			NIMFNNMAKPA -= 1109f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	[DebuggerHidden]
	private IEnumerator ICCEFEOGGAG(LevelBehaviour EFHPOHNNGGH)
	{
		IFDPBDPGLGG iFDPBDPGLGG = new IFDPBDPGLGG();
		iFDPBDPGLGG.EFHPOHNNGGH = EFHPOHNNGGH;
		iFDPBDPGLGG.BJGCPDNMHDH = this;
		return iFDPBDPGLGG;
	}

	private IEnumerator DIAJBLLIDEL(LevelBehaviour EFHPOHNNGGH)
	{
		IFDPBDPGLGG iFDPBDPGLGG = new IFDPBDPGLGG();
		iFDPBDPGLGG.EFHPOHNNGGH = EFHPOHNNGGH;
		iFDPBDPGLGG.BJGCPDNMHDH = this;
		return iFDPBDPGLGG;
	}

	[SpecialName]
	public void JKNHGOBIDGJ(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void NMCAOMOBEGH(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void IBNEIKFHJML(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.OBCAIFMOPPA();
			BJHPKLAEFCI = null;
		}
	}

	public void UpdateRotation(float ILLLINCHMPD, float DOLIFOGBPKB, float KBJEOEEOEFG)
	{
		StartCoroutine(RadicalRoutine.Run(KGAHHFGEPCC(ILLLINCHMPD, DOLIFOGBPKB, KBJEOEEOEFG)));
	}

	private void GHKDEDKCLGB()
	{
		NOJFJANOHEB = GDHNNGCHOFF(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 1267f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	private void GIHEJGJOPBI(PlayerTexturePool.DFJJOANIJID FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case PlayerTexturePool.DFJJOANIJID.Small:
			MBHKGFFKGPC.transform.localPosition = MKAEPADDALH;
			MBHKGFFKGPC.transform.localScale = BLGBKFBPLNE;
			break;
		case PlayerTexturePool.DFJJOANIJID.Card:
			MBHKGFFKGPC.transform.localPosition = OCMNOCJIKGG;
			MBHKGFFKGPC.transform.localScale = JOJNCNBHIAE;
			break;
		default:
			MBHKGFFKGPC.transform.localPosition = JHCDIGAHHHM;
			MBHKGFFKGPC.transform.localScale = HNJJIODPLHF;
			break;
		}
	}

	public IEnumerator NNDKLFKGDEK(DatabasePlayer FHPICFHABBJ, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		HECCGOKNBIK hECCGOKNBIK = new HECCGOKNBIK();
		hECCGOKNBIK.FJLBLLLEELD = FJLBLLLEELD;
		hECCGOKNBIK.FHPICFHABBJ = FHPICFHABBJ;
		hECCGOKNBIK.PNDNEMDPFHC = PNDNEMDPFHC;
		hECCGOKNBIK.BJGCPDNMHDH = this;
		return hECCGOKNBIK;
	}

	public void StartFastRotation()
	{
		GDPBMDGECEJ = -720f;
	}

	private IEnumerator EIGOENHBKCM(PlayerController KHLGDCHJJPB, Texture2D EBFDAICCJAK, bool DNCMDLDABHK = false, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		JAIAGHOBDGK jAIAGHOBDGK = new JAIAGHOBDGK();
		jAIAGHOBDGK.DNCMDLDABHK = DNCMDLDABHK;
		jAIAGHOBDGK.KHLGDCHJJPB = KHLGDCHJJPB;
		jAIAGHOBDGK.FJLBLLLEELD = FJLBLLLEELD;
		jAIAGHOBDGK.PNDNEMDPFHC = PNDNEMDPFHC;
		jAIAGHOBDGK.EBFDAICCJAK = EBFDAICCJAK;
		jAIAGHOBDGK.BJGCPDNMHDH = this;
		return jAIAGHOBDGK;
	}

	public void PGOMJNKOEOL(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.KLFFMPINIPB();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(true);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 1260f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 1370f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 355f;
		NOJFJANOHEB = 1620f;
		GHKDEDKCLGB();
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(false);
	}

	protected virtual void KAOOPGJDPOG()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		OPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
	}

	[SpecialName]
	public void FJFAKGBCGON(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void NDPDPLMNAJK(PlayerTexturePool.DFJJOANIJID FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case PlayerTexturePool.DFJJOANIJID.Small:
			MBHKGFFKGPC.transform.localPosition = MKAEPADDALH;
			MBHKGFFKGPC.transform.localScale = BLGBKFBPLNE;
			break;
		case (PlayerTexturePool.DFJJOANIJID)6:
			MBHKGFFKGPC.transform.localPosition = OCMNOCJIKGG;
			MBHKGFFKGPC.transform.localScale = JOJNCNBHIAE;
			break;
		default:
			MBHKGFFKGPC.transform.localPosition = JHCDIGAHHHM;
			MBHKGFFKGPC.transform.localScale = HNJJIODPLHF;
			break;
		}
	}

	[SpecialName]
	public void LFODGENMENO(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JIPKECFGPOP(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.OBCAIFMOPPA();
			BJHPKLAEFCI = null;
		}
	}

	public void MANAHDDIFIO(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(false);
		StartCoroutine(RadicalRoutine.Run(IIODOPODKLA(KHLGDCHJJPB, null, true, PNDNEMDPFHC, AEEELCCAMBH)));
	}

	[SpecialName]
	public bool GBHGKHAFLLI()
	{
		return HPKCPHNLLNI;
	}

	public void DefaultRotation()
	{
		GDPBMDGECEJ = -17f;
	}

	[SpecialName]
	public void PEMEOEPLLHF(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void ECKHPLGLOFP()
	{
		MBHKGFFKGPC.gameObject.SetActive(true);
		MBHKGFFKGPC.EHHHBEMKGOE = CHEIFOOIMEH.LLOHKIKGGLF();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE = CHEIFOOIMEH.PNPIGMOACFK();
		MBHKGFFKGPC.KLFFMPINIPB();
		MBHKGFFKGPC.gameObject.SetActive(true);
	}

	public void BLMDIFPMDBG()
	{
		GNICEGBOGOL.enabled = true;
	}

	private void ONLFIMAKMCF()
	{
		MBLMPGLELFF = Input.GetAxis("Mouse X") * CPFPDNMMHDE * OPHGMIGGJBD * 0.02f;
		ADAKCEBFAFJ = Input.GetAxis("Mouse Y") * AHPEDEMHLKN * 0.02f;
		JDEMAFGJGLD += MBLMPGLELFF;
		NOJFJANOHEB -= ADAKCEBFAFJ;
		OFIOGEFPPKO();
	}

	private float HEOHMAPEABO(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 1002f) * 0f;
	}

	public void CLAFENLOGOB()
	{
		GDPBMDGECEJ = 140f;
	}

	private IEnumerator PJALBAKLABD()
	{
		EKBDAFJLEKI eKBDAFJLEKI = new EKBDAFJLEKI();
		eKBDAFJLEKI.BJGCPDNMHDH = this;
		return eKBDAFJLEKI;
	}

	public void LHENLMHIOGJ(LevelBehaviour NCMHGPNPEJM)
	{
		DGNOFMEEAIA();
		if (BJHPKLAEFCI != null && BJHPKLAEFCI.ACLDFHJKBLI.GetType() == NCMHGPNPEJM.GetType())
		{
			HidePlayer(PlayerController.OGMBJPKOPCB);
			BJHPKLAEFCI.gameObject.SetActive(true);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			FFFLIFHGBGJ();
		}
		else
		{
			JOENJIPGGEK();
			HidePlayer(PlayerController.OGMBJPKOPCB);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			StartCoroutine(PECGFJFDNMP(NCMHGPNPEJM));
		}
	}

	private void PJKKMBBPILB(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.BOHCNEDIJPE();
			BJHPKLAEFCI = null;
		}
	}

	public void FFFLIFHGBGJ()
	{
		if (GNICEGBOGOL.enabled)
		{
			StartCoroutine(FJLLEFMDDIA());
		}
	}

	private float ALOOKAGDCMF(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 699f) * 730f;
	}

	public void DJFMADMABIB()
	{
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
		IAMMOGENHAD(true);
	}

	private void CNEADELKALM(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.DestroyPooled();
			BJHPKLAEFCI = null;
		}
	}

	public IEnumerator CAEHLCHOPMO(DatabasePlayer FHPICFHABBJ, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		HECCGOKNBIK hECCGOKNBIK = new HECCGOKNBIK();
		hECCGOKNBIK.FJLBLLLEELD = FJLBLLLEELD;
		hECCGOKNBIK.FHPICFHABBJ = FHPICFHABBJ;
		hECCGOKNBIK.PNDNEMDPFHC = PNDNEMDPFHC;
		hECCGOKNBIK.BJGCPDNMHDH = this;
		return hECCGOKNBIK;
	}

	public IEnumerator MBLJBAEIPDI(DatabasePlayer FHPICFHABBJ, Texture2D EBFDAICCJAK, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		NLCCAKIBMON nLCCAKIBMON = new NLCCAKIBMON();
		nLCCAKIBMON.FJLBLLLEELD = FJLBLLLEELD;
		nLCCAKIBMON.FHPICFHABBJ = FHPICFHABBJ;
		nLCCAKIBMON.PNDNEMDPFHC = PNDNEMDPFHC;
		nLCCAKIBMON.EBFDAICCJAK = EBFDAICCJAK;
		nLCCAKIBMON.BJGCPDNMHDH = this;
		return nLCCAKIBMON;
	}

	public Texture GetHiresPlayerTexture()
	{
		return HICMLKAOEJL;
	}

	[SpecialName]
	public bool MCDAHCJPBIM()
	{
		return HPKCPHNLLNI;
	}

	public void HOMGMNFOGDK(LevelBehaviour NCMHGPNPEJM)
	{
		DefaultRotation();
		if (BJHPKLAEFCI != null && BJHPKLAEFCI.ACLDFHJKBLI.GetType() == NCMHGPNPEJM.GetType())
		{
			JHKICLBBOCO(PlayerController.OGMBJPKOPCB);
			BJHPKLAEFCI.gameObject.SetActive(false);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			HKDNKJOBIND();
		}
		else
		{
			DJFMADMABIB();
			KINNPLNELHE(PlayerController.OGMBJPKOPCB);
			GNICEGBOGOL.enabled = false;
			DHCMAFEPGMP.SetActive(false);
			StartCoroutine(ICCEFEOGGAG(NCMHGPNPEJM));
		}
	}

	public void LNEHNFCFBPN(PlayerController NCMHGPNPEJM)
	{
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
		NCMHGPNPEJM.gameObject.SetActive(true);
		NCMHGPNPEJM.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
	}

	[DebuggerHidden]
	public IEnumerator CreatePlayerTexture(DatabasePlayer FHPICFHABBJ, Texture2D EBFDAICCJAK, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		NLCCAKIBMON nLCCAKIBMON = new NLCCAKIBMON();
		nLCCAKIBMON.FJLBLLLEELD = FJLBLLLEELD;
		nLCCAKIBMON.FHPICFHABBJ = FHPICFHABBJ;
		nLCCAKIBMON.PNDNEMDPFHC = PNDNEMDPFHC;
		nLCCAKIBMON.EBFDAICCJAK = EBFDAICCJAK;
		nLCCAKIBMON.BJGCPDNMHDH = this;
		return nLCCAKIBMON;
	}

	public void NGHOPJAFGFD()
	{
		if (GNICEGBOGOL.enabled)
		{
			StartCoroutine(PJALBAKLABD());
		}
	}

	private IEnumerator OFOCMDEPJGM()
	{
		EKBDAFJLEKI eKBDAFJLEKI = new EKBDAFJLEKI();
		eKBDAFJLEKI.BJGCPDNMHDH = this;
		return eKBDAFJLEKI;
	}

	private void MMPKIBJAALB()
	{
		MBLMPGLELFF = Input.GetAxis("ID_GETFORNUMBERONE1") * CPFPDNMMHDE * OPHGMIGGJBD * 407f;
		ADAKCEBFAFJ = Input.GetAxis("{0} {1}({2})[-]") * AHPEDEMHLKN * 1324f;
		JDEMAFGJGLD += MBLMPGLELFF;
		NOJFJANOHEB -= ADAKCEBFAFJ;
		OFIOGEFPPKO();
	}

	private void NENEAEBLAAP(PlayerTexturePool.DFJJOANIJID FJLBLLLEELD)
	{
		if (FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Small)
		{
			MBHKGFFKGPC.transform.localPosition = MKAEPADDALH;
			MBHKGFFKGPC.transform.localScale = BLGBKFBPLNE;
		}
		else if (FJLBLLLEELD == PlayerTexturePool.DFJJOANIJID.Small)
		{
			MBHKGFFKGPC.transform.localPosition = OCMNOCJIKGG;
			MBHKGFFKGPC.transform.localScale = JOJNCNBHIAE;
		}
		else
		{
			MBHKGFFKGPC.transform.localPosition = JHCDIGAHHHM;
			MBHKGFFKGPC.transform.localScale = HNJJIODPLHF;
		}
	}

	protected virtual void JKIJMEFIFON()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		OPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
	}

	public void PlayerDataLoaded()
	{
		MBHKGFFKGPC.gameObject.SetActive(true);
		MBHKGFFKGPC.EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
		MBHKGFFKGPC.InitPlayerForCamera();
		MBHKGFFKGPC.gameObject.SetActive(false);
	}

	public void JDIIHIAHOCP(PlayerController NCMHGPNPEJM)
	{
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(false);
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
	}

	public void EJNMPAMPDOE()
	{
		MBHKGFFKGPC.gameObject.SetActive(false);
		MBHKGFFKGPC.EHHHBEMKGOE = CHEIFOOIMEH.PNPIGMOACFK();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE = CHEIFOOIMEH.LLOHKIKGGLF();
		MBHKGFFKGPC.InitPlayerForCamera();
		MBHKGFFKGPC.gameObject.SetActive(false);
	}

	public void DAFKIMIGKEA(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(true);
		NCMHGPNPEJM.KLFFMPINIPB();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(false);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 964f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 830f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 864f;
		NOJFJANOHEB = 1715f;
		OFIOGEFPPKO();
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(false);
	}

	private IEnumerator PECGFJFDNMP(LevelBehaviour EFHPOHNNGGH)
	{
		IFDPBDPGLGG iFDPBDPGLGG = new IFDPBDPGLGG();
		iFDPBDPGLGG.EFHPOHNNGGH = EFHPOHNNGGH;
		iFDPBDPGLGG.BJGCPDNMHDH = this;
		return iFDPBDPGLGG;
	}

	public void Display(LevelBehaviour NCMHGPNPEJM)
	{
		DefaultRotation();
		if (BJHPKLAEFCI != null && BJHPKLAEFCI.ACLDFHJKBLI.GetType() == NCMHGPNPEJM.GetType())
		{
			HidePlayer(PlayerController.OGMBJPKOPCB);
			BJHPKLAEFCI.gameObject.SetActive(true);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(true);
			Refresh();
		}
		else
		{
			Hide();
			HidePlayer(PlayerController.OGMBJPKOPCB);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(true);
			StartCoroutine(ICCEFEOGGAG(NCMHGPNPEJM));
		}
	}

	public void DICDPLMPKAH()
	{
		GDPBMDGECEJ = 1184f;
	}

	[SpecialName]
	public bool HOCDNFFINAJ()
	{
		return HPKCPHNLLNI;
	}

	protected override void Awake()
	{
		base.Awake();
		GNICEGBOGOL = GetComponent<Camera>();
		GNICEGBOGOL.enabled = false;
		GNICEGBOGOL.clearFlags = CameraClearFlags.Nothing;
	}

	public Texture GFLEFLJCFBA()
	{
		return HICMLKAOEJL;
	}

	public void KKFLKPKDANB(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(true);
		NCMHGPNPEJM.InitPlayerForCamera();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(true);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 1884f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 972f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 1866f;
		NOJFJANOHEB = 482f;
		OMIHGPNFCEG();
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(true);
	}

	public void Refresh()
	{
		if (GNICEGBOGOL.enabled)
		{
			StartCoroutine(FJLLEFMDDIA());
		}
	}

	[SpecialName]
	public void ILEGOMDHCEI(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void IOAMNODKPKD()
	{
		if (!GNICEGBOGOL.enabled)
		{
			return;
		}
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if ((bool)MKIPAEDAADL && HEOAKILNIBA)
		{
			MMPKIBJAALB();
		}
		if (Input.GetMouseButtonDown(0) && LNFFCOMNHDE)
		{
			HEOAKILNIBA = true;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 1064f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i++)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == "ID_CONFIRM_EXITINGMATCHWARARENA_TEXT")
				{
					HEOAKILNIBA = false;
					LILBNAFBNKJ = false;
					if (EDPINEAGFBD != null)
					{
						EDPINEAGFBD(true);
					}
				}
			}
		}
		if (LNFFCOMNHDE && LILBNAFBNKJ)
		{
			JDEMAFGJGLD += Time.deltaTime * GDPBMDGECEJ;
			CFGGHLOCEAC();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = false;
			if (EDPINEAGFBD != null)
			{
				EDPINEAGFBD(true);
			}
		}
	}

	private float FCPCLOFOAFM(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 521f) * 823f;
	}

	public IEnumerator PJKKHGPNFLA(DatabasePlayer FHPICFHABBJ, Texture2D EBFDAICCJAK, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		NLCCAKIBMON nLCCAKIBMON = new NLCCAKIBMON();
		nLCCAKIBMON.FJLBLLLEELD = FJLBLLLEELD;
		nLCCAKIBMON.FHPICFHABBJ = FHPICFHABBJ;
		nLCCAKIBMON.PNDNEMDPFHC = PNDNEMDPFHC;
		nLCCAKIBMON.EBFDAICCJAK = EBFDAICCJAK;
		nLCCAKIBMON.BJGCPDNMHDH = this;
		return nLCCAKIBMON;
	}

	public void KNHFPKFILIG()
	{
		GDPBMDGECEJ = 1202f;
	}

	private void LPCNFLHNBJM()
	{
		MBLMPGLELFF = Mathf.Lerp(MBLMPGLELFF, 0f, Time.deltaTime * KPHNBLPPNJJ);
		ADAKCEBFAFJ = Mathf.Lerp(ADAKCEBFAFJ, 0f, Time.deltaTime * KPHNBLPPNJJ);
		JDEMAFGJGLD += MBLMPGLELFF;
		NOJFJANOHEB -= ADAKCEBFAFJ;
		OFIOGEFPPKO();
	}

	[SpecialName]
	public void FAECIKOAGPK(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DNEFJHHMGIL(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.parent = ECHHMOPLOHK;
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.OBCAIFMOPPA();
			BJHPKLAEFCI = null;
		}
	}

	public void AJLHMFLNFHH()
	{
		GNICEGBOGOL.enabled = true;
	}

	[DebuggerHidden]
	private IEnumerator KGAHHFGEPCC(float ILLLINCHMPD, float DOLIFOGBPKB, float IOIPJCICLFH)
	{
		JPPOIIGPOKN jPPOIIGPOKN = new JPPOIIGPOKN();
		jPPOIIGPOKN.ILLLINCHMPD = ILLLINCHMPD;
		jPPOIIGPOKN.IOIPJCICLFH = IOIPJCICLFH;
		jPPOIIGPOKN.DOLIFOGBPKB = DOLIFOGBPKB;
		jPPOIIGPOKN.BJGCPDNMHDH = this;
		return jPPOIIGPOKN;
	}

	private void MAILDHFJFBD(PlayerTexturePool.DFJJOANIJID FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case PlayerTexturePool.DFJJOANIJID.Small:
			MBHKGFFKGPC.transform.localPosition = MKAEPADDALH;
			MBHKGFFKGPC.transform.localScale = BLGBKFBPLNE;
			break;
		case (PlayerTexturePool.DFJJOANIJID)5:
			MBHKGFFKGPC.transform.localPosition = OCMNOCJIKGG;
			MBHKGFFKGPC.transform.localScale = JOJNCNBHIAE;
			break;
		default:
			MBHKGFFKGPC.transform.localPosition = JHCDIGAHHHM;
			MBHKGFFKGPC.transform.localScale = HNJJIODPLHF;
			break;
		}
	}

	[DebuggerHidden]
	public IEnumerator CreateHiresPlayerTexture(DatabasePlayer FHPICFHABBJ, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		HECCGOKNBIK hECCGOKNBIK = new HECCGOKNBIK();
		hECCGOKNBIK.FJLBLLLEELD = FJLBLLLEELD;
		hECCGOKNBIK.FHPICFHABBJ = FHPICFHABBJ;
		hECCGOKNBIK.PNDNEMDPFHC = PNDNEMDPFHC;
		hECCGOKNBIK.BJGCPDNMHDH = this;
		return hECCGOKNBIK;
	}

	public void AMLGPFMCJLM(LevelBehaviour NCMHGPNPEJM)
	{
		DefaultRotation();
		if (BJHPKLAEFCI != null && BJHPKLAEFCI.ACLDFHJKBLI.GetType() == NCMHGPNPEJM.GetType())
		{
			JDIIHIAHOCP(PlayerController.OGMBJPKOPCB);
			BJHPKLAEFCI.gameObject.SetActive(false);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			FFFLIFHGBGJ();
		}
		else
		{
			JOENJIPGGEK();
			LNEHNFCFBPN(PlayerController.OGMBJPKOPCB);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(false);
			StartCoroutine(PECGFJFDNMP(NCMHGPNPEJM));
		}
	}

	private void JFDBKNODOOM()
	{
		NOJFJANOHEB = HKOJEANLCEO(NOJFJANOHEB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(NOJFJANOHEB, JDEMAFGJGLD, 1217f);
		MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
	}

	private IEnumerator HKBFAGDKEEC(LevelBehaviour EFHPOHNNGGH)
	{
		IFDPBDPGLGG iFDPBDPGLGG = new IFDPBDPGLGG();
		iFDPBDPGLGG.EFHPOHNNGGH = EFHPOHNNGGH;
		iFDPBDPGLGG.BJGCPDNMHDH = this;
		return iFDPBDPGLGG;
	}

	[SpecialName]
	public void CFCIEPPMHID(Action<bool> IDEBKDPMPGM)
	{
		Action<bool> action = EDPINEAGFBD;
		Action<bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EDPINEAGFBD, (Action<bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private float JDANLACEGGJ(float NIMFNNMAKPA)
	{
		return NIMFNNMAKPA - Mathf.Floor(NIMFNNMAKPA / 318f) * 555f;
	}

	[DebuggerHidden]
	private IEnumerator GHDHBPDGONH(PlayerController KHLGDCHJJPB, Texture2D EBFDAICCJAK, bool DNCMDLDABHK = false, bool PNDNEMDPFHC = true, PlayerTexturePool.DFJJOANIJID FJLBLLLEELD = PlayerTexturePool.DFJJOANIJID.Small)
	{
		JAIAGHOBDGK jAIAGHOBDGK = new JAIAGHOBDGK();
		jAIAGHOBDGK.DNCMDLDABHK = DNCMDLDABHK;
		jAIAGHOBDGK.KHLGDCHJJPB = KHLGDCHJJPB;
		jAIAGHOBDGK.FJLBLLLEELD = FJLBLLLEELD;
		jAIAGHOBDGK.PNDNEMDPFHC = PNDNEMDPFHC;
		jAIAGHOBDGK.EBFDAICCJAK = EBFDAICCJAK;
		jAIAGHOBDGK.BJGCPDNMHDH = this;
		return jAIAGHOBDGK;
	}

	public void DHANJABMCIO(PlayerController NCMHGPNPEJM)
	{
		NCMHGPNPEJM.gameObject.SetActive(true);
		NCMHGPNPEJM.InitPlayerForCamera();
		NCMHGPNPEJM.SelectPrimary();
		NCMHGPNPEJM.Preview(true);
		NCMHGPNPEJM.transform.parent = IGMMGPKPHFF;
		NCMHGPNPEJM.transform.localRotation = Quaternion.identity;
		NCMHGPNPEJM.transform.localPosition = 1152f * Vector3.up;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
		IGMMGPKPHFF.localScale = 1322f * Vector3.one;
		IGMMGPKPHFF.localPosition = default(Vector3);
		JDEMAFGJGLD = 1979f;
		NOJFJANOHEB = 571f;
		CFGGHLOCEAC();
		GNICEGBOGOL.enabled = false;
		DHCMAFEPGMP.SetActive(false);
	}

	public static float HKOJEANLCEO(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 223f)
		{
			NIMFNNMAKPA += 292f;
		}
		if (NIMFNNMAKPA > 882f)
		{
			NIMFNNMAKPA -= 1535f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public static float MFJNEECFOOC(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 288f)
		{
			NIMFNNMAKPA += 1671f;
		}
		if (NIMFNNMAKPA > 405f)
		{
			NIMFNNMAKPA -= 571f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public void KINNPLNELHE(PlayerController NCMHGPNPEJM)
	{
		GNICEGBOGOL.enabled = true;
		DHCMAFEPGMP.SetActive(false);
		NCMHGPNPEJM.gameObject.SetActive(false);
		NCMHGPNPEJM.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		NCMHGPNPEJM.transform.localScale = Vector3.one;
	}

	public void JEOPDEIJJHN(LevelBehaviour NCMHGPNPEJM)
	{
		BGKCOAAFJPM();
		if (BJHPKLAEFCI != null && BJHPKLAEFCI.ACLDFHJKBLI.GetType() == NCMHGPNPEJM.GetType())
		{
			PNIIDBHNMPF(PlayerController.OGMBJPKOPCB);
			BJHPKLAEFCI.gameObject.SetActive(true);
			GNICEGBOGOL.enabled = false;
			DHCMAFEPGMP.SetActive(true);
			Refresh();
		}
		else
		{
			DJFMADMABIB();
			JHKICLBBOCO(PlayerController.OGMBJPKOPCB);
			GNICEGBOGOL.enabled = true;
			DHCMAFEPGMP.SetActive(true);
			StartCoroutine(HKBFAGDKEEC(NCMHGPNPEJM));
		}
	}

	public void BCPDNHEDBGO(PlayerController KHLGDCHJJPB, bool PNDNEMDPFHC, PlayerTexturePool.DFJJOANIJID AEEELCCAMBH = PlayerTexturePool.DFJJOANIJID.Small)
	{
		base.gameObject.SetActive(false);
		StartCoroutine(RadicalRoutine.Run(IIODOPODKLA(KHLGDCHJJPB, null, false, PNDNEMDPFHC, AEEELCCAMBH)));
	}
}
