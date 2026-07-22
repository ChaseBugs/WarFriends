using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class LootBoxCameraArena : Singleton<LootBoxCameraArena>
{
	private sealed class ANMLHPBIDOL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal ArmyUnit3DModel HMEFCHGLFIF;

		internal LevelBehaviour EFHPOHNNGGH;

		internal AIObject DOGHDHGLCDF;

		internal LootBoxCameraArena BJGCPDNMHDH;

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

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)7;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CFLJMCBNBNE(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1017f), bought: false, mine: true, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KKCMCNCCIMB().IONKGACHEBC(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GPJGKJCDFOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
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
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)3;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1681f), bought: true, mine: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.COJFMKNGPBP().IJKKOCDFLAF(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)8;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 74f), bought: false, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void CALPCMFJHMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NGODHNFDPCG()
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
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)3;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 933f), bought: false, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)8;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.CHHLLIAHECC().IJKKOCDFLAF(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)6;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 491f), bought: true, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)5;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().CNEDMJIOECH(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Enemies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 158f), bought: false, mine: true, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.COJFMKNGPBP().FLKHKLDOAPD(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MEKLPMCIMBH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)5;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1301f), bought: true, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GALNCAONHGF(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.EHFPBDJMGNC().CNEDMJIOECH(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GHILCKCFAFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MKMMKLOPKPD()
		{
			throw new NotSupportedException();
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)3;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1230f), bought: false, mine: true, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.ALFLHPIEADC(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)5;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KKCMCNCCIMB().KBBMHOCIMCE(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.PNNDDKOCFNE(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 901f), bought: false, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.PNNDDKOCFNE(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)6;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.GLHPLCEFHGD().CNEDMJIOECH(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object HLFLANGJJHM()
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
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1242f), bought: false, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)5;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.ADBOHNCGKHA().JCMCILKEKPH(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool APJNFAOFAFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)5;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.ALFLHPIEADC(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 893f), bought: true, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CFLJMCBNBNE(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().IJKKOCDFLAF(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void ODINNCBLBOF()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public ANMLHPBIDOL()
		{
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LNAPDCBIFIJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.Allies;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1585f), bought: false, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)6;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.GLHPLCEFHGD().IJKKOCDFLAF(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EOLNOFMPMHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1762f), bought: false, mine: true, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FAMDCPGBOFJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.COJFMKNGPBP().FLKHKLDOAPD(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public void LEAAOAKKLAJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OGBOHCPHGMK()
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
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH), bought: true, mine: true, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.Allies;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
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

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OFAOFOPFIJJ()
		{
			return PHDOCKCBJOF;
		}

		public void GHODNCIDCMG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOOABACIPKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKIMCCGAMJA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)5;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1072f), bought: true, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)8;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.MFKPDKCLDBI().JCMCILKEKPH(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LGCKODOHHIA()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CFLJMCBNBNE(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1350f), bought: false, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.CHHLLIAHECC().PKFDDOIEMMC(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)6;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1602f), bought: false, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.DKNHCGGKNMF().FLKHKLDOAPD(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)3;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.IFMFDOKEMHF(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 679f), bought: true, mine: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.PNNDDKOCFNE(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = true;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)6;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KJEANKAJELG().IONKGACHEBC(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DBKMMECKKLG()
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
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CFLJMCBNBNE(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1260f), bought: false, mine: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.ALFLHPIEADC(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.Enemies;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.GLHPLCEFHGD().IJKKOCDFLAF(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HNBOIMNNPOH()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public bool AELAICNOAPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)6;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.PNNDDKOCFNE(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1237f), bought: false, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.DFCOIAFKJNF(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.EHFPBDJMGNC().PKFDDOIEMMC(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public bool LHNFELIIMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)4;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.ALFLHPIEADC(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1644f), bought: false, mine: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.IMNCHFHIJDJ(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.MFKPDKCLDBI().IONKGACHEBC(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNCFPHMMNDC()
		{
			return PHDOCKCBJOF;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ANBCMDOAJCM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGDOJHLOII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)8;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.FHGPDJBGFIB(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1068f), bought: false, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: false);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.prefab != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.GLHPLCEFHGD().IONKGACHEBC(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool LGOHLNFJKNL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 281f), bought: true, mine: false, unloadWeapon: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CFLJMCBNBNE(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.DKNHCGGKNMF().KBBMHOCIMCE(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: true);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void FAOLFOHEEGF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = (GHPGNELIDBM)7;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CIKIBEDFCNB(NOBOBPMMHCE: false);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1249f), bought: true, mine: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.CNEADELKALM(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.KKCMCNCCIMB().KBBMHOCIMCE(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = false;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void JDFJKNFDDGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PlayerController.OGMBJPKOPCB.fraction = GHPGNELIDBM.None;
				HMEFCHGLFIF = null;
				BJGCPDNMHDH.CFLJMCBNBNE(NOBOBPMMHCE: true);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(EFHPOHNNGGH.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(EFHPOHNNGGH, 1857f), bought: true, mine: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.ALFLHPIEADC(NOBOBPMMHCE: true);
				DOGHDHGLCDF = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(EFHPOHNNGGH);
				if (DOGHDHGLCDF != null && DOGHDHGLCDF.LELHDMOANJG() != null)
				{
					DOGHDHGLCDF.LCDBACDIODH = false;
					DOGHDHGLCDF.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BJHPKLAEFCI = (AIObject)ObjectPoolDatabase.CHHLLIAHECC().IJKKOCDFLAF(DOGHDHGLCDF);
					BJGCPDNMHDH.BJHPKLAEFCI.transform.parent = BJGCPDNMHDH.mCharacterParent;
					BJGCPDNMHDH.BJHPKLAEFCI.transform.localRotation = Quaternion.identity;
				}
				HMEFCHGLFIF = BJGCPDNMHDH.BJHPKLAEFCI.GetComponent<ArmyUnit3DModel>();
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localPosition = -HMEFCHGLFIF.IIHJFLPFIEF.localPosition;
				BJGCPDNMHDH.BJHPKLAEFCI.transform.localScale = Vector3.one;
				BJGCPDNMHDH.mCharacterParent.localScale = HMEFCHGLFIF.IAJAILAGAKC * Vector3.one;
				BJGCPDNMHDH.BJHPKLAEFCI.LCDBACDIODH = true;
				BJGCPDNMHDH.BJHPKLAEFCI.UpdatePreview(OPGMAEDPFML: false);
				BJGCPDNMHDH.mCharacterParent.localPosition = EFHPOHNNGGH.modelPosition;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	[SerializeField]
	private GameObject mBackground;

	[SerializeField]
	private Transform mCharacterParent;

	[SerializeField]
	private Camera mDialogCamera;

	[SerializeField]
	private Camera mLootboxCamera;

	[SerializeField]
	private Animation mLootBoxOpenAnimation;

	[SerializeField]
	private Animation mLootBoxShowUpAnimation;

	[SerializeField]
	private RotateCamera mRotateCamera;

	[SerializeField]
	private ParticleSystem mScreenShowParticles;

	[SerializeField]
	private ParticleSystem mLootBoxOpenParticles;

	[SerializeField]
	private List<Material> mLootBoxMaterials;

	[SerializeField]
	private GameObject mLootBox;

	private LevelBehaviour IFCKEAIELNL;

	private Transform GNILIFKCBKB;

	private AIObject BJHPKLAEFCI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action DPCINPKNEFK;

	public event Action LootBoxShowedUp
	{
		add
		{
			Action action = DPCINPKNEFK;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DPCINPKNEFK;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void BLFPMDILGOB()
	{
		mScreenShowParticles.Play();
	}

	private void KIHHCHKIKEO(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "boxOpen")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "animationEnd" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	private IEnumerator HAEDELOHLKB(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	protected virtual void JFDOGLFMHAE()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(MFEBMIJGJIN));
		}
		mDialogCamera.gameObject.SetActive(value: true);
	}

	private IEnumerator FKIGHOKMFJC(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	[SpecialName]
	public void HFFDKKDBNMM(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void FPPBBDBOHNB(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "open")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "button" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	private IEnumerator OOFFNBKANKP(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	[SpecialName]
	public void PFAFCDAACGO(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void FEBBFBOCKMC()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(NFDNCKIOJDI));
		}
		mDialogCamera.gameObject.SetActive(value: true);
	}

	public void BKIMPLHMLII()
	{
		UpgradeSlots.showElite = true;
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		mBackground.gameObject.SetActive(value: false);
		CFLJMCBNBNE(NOBOBPMMHCE: true);
	}

	[SpecialName]
	public void GHCEPGKCAAC(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void JLMBDNMMLMG()
	{
		UpgradeSlots.showElite = false;
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = true;
		mBackground.gameObject.SetActive(value: false);
		CNEADELKALM(NOBOBPMMHCE: false);
	}

	protected virtual void ECMMDCKONDK()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: true);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KIHHCHKIKEO));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	public void BOPCGMEACDJ()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	private IEnumerator MFPLLJGHFEO(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	private void CIMHOFHPKNJ(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: false);
		}
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void BEEFKBFEMIB(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = false;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 1954f) : (Vector3.one * 621f));
		mBackground.SetActive(LBCMGKGLFPI);
		DLCFAJEFLHO(MBINJMOJOBG: true);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(OPIFKCKELKL(IFCKEAIELNL));
	}

	[SpecialName]
	public void HMJFFNJKEMH(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void NEALOFNNFAA(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JDPEFBICAKC(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "ID_WARNING_NOTENOUGHGOLDHEARTH")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "Grenade_Throwing_Tutorial_Duration" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	[SpecialName]
	public void OGHCJHNKALD(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Awake()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KIHHCHKIKEO));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	private IEnumerator JEPMIKPMEND(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	private void HOGNBJILPLK()
	{
		mLootBoxOpenAnimation.Play("WarFriends doit télécharger environ 190 Mo de données supplémentaires pour fonctionner.\nLa durée du téléchargement peut varier selon votre réseau et votre emplacement.\n\nVoulez-vous continuer ?");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)84, 1615f);
	}

	private IEnumerator JOGMIBIHLGB(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	private void FMJFACPIDPB()
	{
		mLootBoxOpenAnimation.Play("PlayerID");
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGamePhotoSound, 363f);
	}

	[SpecialName]
	public void FFMAABHHBLF(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void GKIKAMCEJMH(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void IDBEFAHBMGE(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 808f;
		ODFFMMOFCFF(MBINJMOJOBG: false);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["ID_CONFIRM_PLAYERALREADYEXISTS"];
		animationState.normalizedTime = 175f;
		animationState.weight = 1500f;
		animationState.enabled = true;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("ID_DOGTAGSREFILLINGFASTERSUBSCRIPTION");
		mLootBoxShowUpAnimation.PlayQueued("Country");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(GHKIKBICLNC, 133f);
	}

	public void DDDPICNCLIC()
	{
		UpgradeSlots.showElite = false;
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = false;
		mBackground.gameObject.SetActive(value: false);
		FHGPDJBGFIB(NOBOBPMMHCE: true);
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: true);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(FPPBBDBOHNB));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	public void Hide()
	{
		UpgradeSlots.showElite = false;
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		mBackground.gameObject.SetActive(value: false);
		CNEADELKALM(NOBOBPMMHCE: true);
	}

	protected virtual void DCKJHAILENK()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(DHDLAHLJHHL));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	private void JBCPBLCHJKF()
	{
		mLootBoxOpenAnimation.Play("ID_CONGRATULATIONSROOKIE");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-8), 227f);
	}

	private void CNEADELKALM(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.DestroyPooled(DCDEEADIGEH: true);
			BJHPKLAEFCI = null;
		}
	}

	public void PEPEFFINIMM(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 928f) : (Vector3.one * 1429f));
		mBackground.SetActive(LBCMGKGLFPI);
		ODFFMMOFCFF(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: false);
		StartCoroutine(KLJNHMCHJIM(IFCKEAIELNL));
	}

	[SpecialName]
	public void NBDJFCHHAOI(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator PCFJMLKKCPO(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	private void FJFNDPBENKJ(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Buy_Weapon_Upgrade")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "ID_GPGS_LOGIN_TUTORIAL_TITLE" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	private void NFDNCKIOJDI(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "WarFriends nécessite la permission d’accéder à ton espace de stockage afin de télécharger des données de jeu critiques.Accepte la permission suivante, nous n’utiliserons jamais cette permission pour autre chose.")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "_New_User" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	protected virtual void OBPDFCOPCMK()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(MFEBMIJGJIN));
		}
		mDialogCamera.gameObject.SetActive(value: true);
	}

	protected virtual void OBEHLLBBEIL()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(JDPEFBICAKC));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	public void DPCCAKPNFKM()
	{
		mScreenShowParticles.Play();
	}

	public void HLDJJPKBDJH(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 209f;
		LCCEEAMLHDD(MBINJMOJOBG: true);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["-ABILITY"];
		animationState.normalizedTime = 526f;
		animationState.weight = 648f;
		animationState.enabled = true;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("FLOATVALUE");
		mLootBoxShowUpAnimation.PlayQueued("01 ");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(JJCAILGDFJN, 1745f);
	}

	[SpecialName]
	public void GDMGGPBEPJD(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MAPKMCFDDJE(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = false;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 792f) : (Vector3.one * 1576f));
		mBackground.SetActive(LBCMGKGLFPI);
		LCCEEAMLHDD(MBINJMOJOBG: true);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.JJOAHIOBOPO();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: false);
		StartCoroutine(IBEEMANHNNP(IFCKEAIELNL));
	}

	private void DLCFAJEFLHO(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: true);
	}

	private IEnumerator CEIDPDNOIFC(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	private void NPBEOCAKAFA(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "HH:mm")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "PlayerLevel" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	public void LHCEMAFLKIG(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 1660f;
		DLCFAJEFLHO(MBINJMOJOBG: false);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["ID_TUTORIAL_OVERTIME"];
		animationState.normalizedTime = 702f;
		animationState.weight = 541f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = true;
		mLootBoxShowUpAnimation.Play("Beanstalk: ");
		mLootBoxShowUpAnimation.PlayQueued("N");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(JBCPBLCHJKF, 1314f);
	}

	public void JNKKDCCEJPG(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 1645f;
		EFBEJJEIPEG(MBINJMOJOBG: false);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["subscribed"];
		animationState.normalizedTime = 1272f;
		animationState.weight = 1077f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = true;
		mLootBoxShowUpAnimation.Play("Beanstalk: Test");
		mLootBoxShowUpAnimation.PlayQueued("+");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(FMJFACPIDPB, 140f);
	}

	private void IFMFDOKEMHF(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.JLHMFBILMCF(DCDEEADIGEH: true);
			BJHPKLAEFCI = null;
		}
	}

	private void DHDLAHLJHHL(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Error in bot finding position")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "MapName" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	public void FMLIOLMDNIF(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 1317f) : (Vector3.one * 1777f));
		mBackground.SetActive(LBCMGKGLFPI);
		LEOMLFCGIHK(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(HAEDELOHLKB(IFCKEAIELNL));
	}

	private IEnumerator OPIFKCKELKL(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	private IEnumerator KLJNHMCHJIM(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	public void MJEOLNEDOFF()
	{
		mScreenShowParticles.Play();
	}

	public void FEJBLGHFJNP()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void GCCFDMPILOC()
	{
		mScreenShowParticles.Play();
	}

	public void CIPIGEDBFPO()
	{
		mScreenShowParticles.Play();
	}

	public void ShowUpLootBox(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 2.85f;
		GEKIMGFKNHC(MBINJMOJOBG: true);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["open"];
		animationState.normalizedTime = 0f;
		animationState.weight = 1f;
		animationState.enabled = true;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("LootBoxShowUp");
		mLootBoxShowUpAnimation.PlayQueued("LootBoxRotation");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(JJCAILGDFJN, 0.5f);
	}

	private void PGDCNLAMIFE()
	{
		mLootBoxOpenAnimation.Play("com.google.android.gms.common.api.PendingResult");
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CounterSoundExperience, 429f);
	}

	[SpecialName]
	public void FFBBJDNNMDM(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void FHGPDJBGFIB(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.CADILLCGODA(DCDEEADIGEH: false);
			BJHPKLAEFCI = null;
		}
	}

	public void HNBBGMKNAIJ()
	{
		mCharacterParent.gameObject.SetActive(value: true);
	}

	public void IILJGLHFKII()
	{
		mScreenShowParticles.Play();
	}

	[SpecialName]
	public void MGDCGBMMLHN(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void LLKBLBNEBPA()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(MFEBMIJGJIN));
		}
		mDialogCamera.gameObject.SetActive(value: true);
	}

	private void PLCBOLBMJKA(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
	}

	private void ALFLHPIEADC(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.CADILLCGODA(DCDEEADIGEH: true);
			BJHPKLAEFCI = null;
		}
	}

	private void LEOMLFCGIHK(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
	}

	public void NIAIHNDJGGF()
	{
		mScreenShowParticles.Play();
	}

	public void JAOICIMPFEG(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 1756f;
		PLCBOLBMJKA(MBINJMOJOBG: true);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["Gold"];
		animationState.normalizedTime = 1224f;
		animationState.weight = 732f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("N");
		mLootBoxShowUpAnimation.PlayQueued("Player: ");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(DAEOKHOEDKE, 1813f);
	}

	public void JGGPFELCBBO()
	{
		mCharacterParent.gameObject.SetActive(value: true);
	}

	public void ODLNDPIKGDC()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	private void GEKIMGFKNHC(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = true;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void DisplayModel(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 2.3f) : (Vector3.one * 2.85f));
		mBackground.SetActive(LBCMGKGLFPI);
		GEKIMGFKNHC(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(IBEEMANHNNP(IFCKEAIELNL));
	}

	public void HideModel()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	private void EKLHMMKLJOK()
	{
		mLootBoxOpenAnimation.Play("ID_DAILYWINTERASSIGNMENT");
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Explosive, 685f);
	}

	public void JFICPJELINH(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 525f) : (Vector3.one * 45f));
		mBackground.SetActive(LBCMGKGLFPI);
		PLCBOLBMJKA(MBINJMOJOBG: true);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.PDKPELBIAON();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(PFKBDLKIHII(IFCKEAIELNL));
	}

	public void FFCADMHANMO()
	{
		mScreenShowParticles.Play();
	}

	public void ABPEDKHJNMJ(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 1075f) : (Vector3.one * 889f));
		mBackground.SetActive(LBCMGKGLFPI);
		MIGAJINCHAH(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(IBEEMANHNNP(IFCKEAIELNL));
	}

	private void LCCEEAMLHDD(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = true;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void BABCABMGBJC()
	{
		mCharacterParent.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public void DAMPBDPGPDJ(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MHKFLHFGOEC()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	private void FOPGGDJKGIC(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "ID_ARENARULES_MATCHCARDSETS")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "Walk" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	public void LDOBLPOCAAF()
	{
		mScreenShowParticles.Play();
	}

	public void PNOBHBKJGBD()
	{
		mScreenShowParticles.Play();
	}

	[SpecialName]
	public void MNAEFFKGGPE(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void CMNIJPAHAIC(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = false;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 585f) : (Vector3.one * 895f));
		mBackground.SetActive(LBCMGKGLFPI);
		LCCEEAMLHDD(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(JEPMIKPMEND(IFCKEAIELNL));
	}

	[SpecialName]
	public void HNIPCLOBLOD(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IMCAEFHLDMM(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void MECAOCJKMKN()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: true);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(NPBEOCAKAFA));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	public void IEMGAEAOPJL()
	{
		mScreenShowParticles.Play();
	}

	private void MFEBMIJGJIN(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "ID_SQUADWAREND")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "LoadingFinishedRPC" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	private void MIGAJINCHAH(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = true;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: false);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void ECMLKFHJBOM()
	{
		UpgradeSlots.showElite = true;
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = true;
		mBackground.gameObject.SetActive(value: false);
		CNEADELKALM(NOBOBPMMHCE: true);
	}

	protected virtual void ECCECGGCMHG()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(FJFNDPBENKJ));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	public void JBJDKHPEAAK(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 1000f;
		DLCFAJEFLHO(MBINJMOJOBG: false);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["Prefabs to go through: {0} + {1}"];
		animationState.normalizedTime = 383f;
		animationState.weight = 793f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = true;
		mLootBoxShowUpAnimation.Play("ID_CONFIRM_NOSKIRMISHAVAILABLE");
		mLootBoxShowUpAnimation.PlayQueued(", dictionary= ");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(HOGNBJILPLK, 1654f);
	}

	private void GNHECGGMCJL()
	{
		mLootBoxOpenAnimation.Play("currentAchievementProgress");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-11), 638f);
	}

	private void ODFFMMOFCFF(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = true;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: false);
		}
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void FPFCOPFNOBA()
	{
		mScreenShowParticles.Play();
	}

	public void DEAJHLMFFHL()
	{
		UpgradeSlots.showElite = false;
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = false;
		mBackground.gameObject.SetActive(value: false);
		CIKIBEDFCNB(NOBOBPMMHCE: true);
	}

	public void OMJBJKKHPIA(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 909f;
		DANAMJKOPBO(MBINJMOJOBG: false);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["getExperimentType"];
		animationState.normalizedTime = 1777f;
		animationState.weight = 167f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("C4");
		mLootBoxShowUpAnimation.PlayQueued("http://www.about-fun.com/warfriends-wiki");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(HOGNBJILPLK, 579f);
	}

	private void DAEOKHOEDKE()
	{
		mLootBoxOpenAnimation.Play("EG");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-7), 155f);
	}

	private void NBGFNLOCPAD(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public void KCONLMLPOBL(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void CFLJMCBNBNE(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.JLHMFBILMCF(DCDEEADIGEH: false);
			BJHPKLAEFCI = null;
		}
	}

	private void JJCAILGDFJN()
	{
		mLootBoxOpenAnimation.Play("open");
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootbox);
	}

	private void PNNDDKOCFNE(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.JLHMFBILMCF(DCDEEADIGEH: true);
			BJHPKLAEFCI = null;
		}
	}

	[DebuggerHidden]
	private IEnumerator IBEEMANHNNP(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	public void MCJFOJJDAFC(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = false;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 385f) : (Vector3.one * 1709f));
		mBackground.SetActive(LBCMGKGLFPI);
		PLCBOLBMJKA(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.PDKPELBIAON();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(KLJNHMCHJIM(IFCKEAIELNL));
	}

	public void OCJHLBFIPGP(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 496f;
		MJAAGDHAHEM(MBINJMOJOBG: true);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["com.tune.unityutils.TuneUnityFirstPlaylistListener"];
		animationState.normalizedTime = 1451f;
		animationState.weight = 775f;
		animationState.enabled = true;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("ID_HOURS");
		mLootBoxShowUpAnimation.PlayQueued("special");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(GNHECGGMCJL, 1183f);
	}

	[SpecialName]
	public void EKEBCEBJAPF(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void MMPMEOJOJDK(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DANAMJKOPBO(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: false);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public void BJCAEMMEMBO(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void HDGMAPOPDCB(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void IEAFLGPLPKI()
	{
		mScreenShowParticles.Play();
	}

	private void EFBEJJEIPEG(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: false);
		}
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: true);
	}

	public void GFKJCMBACFA()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	private IEnumerator IMOBKJFIHAN(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	public void PlayParticles()
	{
		mScreenShowParticles.Play();
	}

	public void BODBNPLBDAG(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 1745f;
		PLCBOLBMJKA(MBINJMOJOBG: false);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["RATE APP - counter set to max: "];
		animationState.normalizedTime = 1f;
		animationState.weight = 564f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("ID_TUTORIAL_UPGRADEWEAPON_4");
		mLootBoxShowUpAnimation.PlayQueued("Beanstalk: Get Squad Details");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(GNHECGGMCJL, 1498f);
	}

	protected virtual void HLBLKFLJEIG()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KPPINDCKMHE));
		}
		mDialogCamera.gameObject.SetActive(value: true);
	}

	public void KBLNANMHGJL()
	{
		mScreenShowParticles.Play();
	}

	public void GPIHLDEBOLF(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 256f) : (Vector3.one * 170f));
		mBackground.SetActive(LBCMGKGLFPI);
		LCCEEAMLHDD(MBINJMOJOBG: true);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
		StartCoroutine(IBEEMANHNNP(IFCKEAIELNL));
	}

	public void OJDJFLIOPKP(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = false;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 1118f) : (Vector3.one * 574f));
		mBackground.SetActive(LBCMGKGLFPI);
		DLCFAJEFLHO(MBINJMOJOBG: true);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(CEIDPDNOIFC(IFCKEAIELNL));
	}

	public void ADNLIPDCNJN(LevelBehaviour ACLDFHJKBLI, bool LBCMGKGLFPI)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!LBCMGKGLFPI) ? (Vector3.one * 409f) : (Vector3.one * 729f));
		mBackground.SetActive(LBCMGKGLFPI);
		PLCBOLBMJKA(MBINJMOJOBG: false);
		IFCKEAIELNL = ACLDFHJKBLI;
		mRotateCamera.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
		StartCoroutine(FKIGHOKMFJC(IFCKEAIELNL));
	}

	public void NLOLMOCHPIP()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(NFDNCKIOJDI));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	private void GHKIKBICLNC()
	{
		mLootBoxOpenAnimation.Play("_Wind");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-11), 1086f);
	}

	private void CIKIBEDFCNB(bool NOBOBPMMHCE)
	{
		if (BJHPKLAEFCI != null)
		{
			BJHPKLAEFCI.transform.localPosition = default(Vector3);
			BJHPKLAEFCI.transform.localScale = Vector3.one;
			if (NOBOBPMMHCE)
			{
				BJHPKLAEFCI.IAJJBAJOGDM.Unload();
			}
			BJHPKLAEFCI.CADILLCGODA(DCDEEADIGEH: true);
			BJHPKLAEFCI = null;
		}
	}

	public void IBNGIOIPOHA(IKPLPPFFDNI.CACDIELEJHK OFMKJMAPHBM)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 792f;
		MIGAJINCHAH(MBINJMOJOBG: true);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["1"];
		animationState.normalizedTime = 1498f;
		animationState.weight = 1522f;
		animationState.enabled = false;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = true;
		mLootBoxShowUpAnimation.Play("Yes_Clicked");
		mLootBoxShowUpAnimation.PlayQueued("ID_STATE_SELECTINGWARCARDS");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)OFMKJMAPHBM];
		InvokeAfter(JBCPBLCHJKF, 1683f);
	}

	private IEnumerator PFKBDLKIHII(LevelBehaviour EFHPOHNNGGH)
	{
		ANMLHPBIDOL aNMLHPBIDOL = new ANMLHPBIDOL();
		aNMLHPBIDOL.EFHPOHNNGGH = EFHPOHNNGGH;
		aNMLHPBIDOL.BJGCPDNMHDH = this;
		return aNMLHPBIDOL;
	}

	[SpecialName]
	public void KJNFLJCCNIK(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: true);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KPPINDCKMHE));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	private void PAABFJFLHBC()
	{
		mLootBoxOpenAnimation.Play("ID_NA");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-98), 67f);
	}

	private void JCILOELPIJJ()
	{
		mLootBoxOpenAnimation.Play("#PETER# End of lootbox coroutine - no rewards for game from server!");
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-89), 93f);
	}

	[SpecialName]
	public void PLLELHLDPGK(Action IDEBKDPMPGM)
	{
		Action action = DPCINPKNEFK;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DPCINPKNEFK, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void EPMJKMAMOJL()
	{
		UpgradeSlots.showElite = false;
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = false;
		mBackground.gameObject.SetActive(value: true);
		CFLJMCBNBNE(NOBOBPMMHCE: false);
	}

	private void KPPINDCKMHE(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopenning the scene might fix it.")
		{
			mLootBoxOpenParticles.Play();
		}
		if (MGDGFBCJINH == "ID_CONFIRM_ERROR" && DPCINPKNEFK != null)
		{
			DPCINPKNEFK();
		}
	}

	private void MJAAGDHAHEM(bool MBINJMOJOBG)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = true;
		if (MBINJMOJOBG)
		{
			mBackground.SetActive(value: true);
		}
		GNILIFKCBKB.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void KFKEHJHBKLP()
	{
		UpgradeSlots.showElite = true;
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = true;
		mBackground.gameObject.SetActive(value: false);
		IFMFDOKEMHF(NOBOBPMMHCE: false);
	}

	protected virtual void LCLEKFMLENA()
	{
		base.Awake();
		GNILIFKCBKB = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(NPBEOCAKAFA));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}
}
