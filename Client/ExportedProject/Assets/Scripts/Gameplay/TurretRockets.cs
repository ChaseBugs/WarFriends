using UnityEngine;

[RequireComponent(typeof(DestroyableObjectMultipleParts))]
public class TurretRockets : TurretBase<TurretRocketsBehaviour, TurretRocketsBehaviourDefinititon>, NKMKCCDCHCL, KMHCMCBGFFC
{
	private void DDLJNEJCHJB(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 259f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 307f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void LIIJPDILGIL(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1311f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 292f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void DHPHBFIHKBL(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1929f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1476f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void OHOJCGNDNBP(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1631f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 51f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void PJCCNGMOLEI(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1806f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 461f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void LPENCDMECLB()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		BJLABHBHMLA(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			GGIJGAEJLHM(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void GEPKGEMCDED(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 911f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 762f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void PBAIAPDJBIB(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1758f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1031f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void JLEIMCNCLKM(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1854f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 744f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void MCKOIGDFDCP(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1637f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 355f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void HDDKCOKKDJJ()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		KMKOIBAPGCO(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			INPPMIOFCMF(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		ILJDEJFEMEI(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			ILJDEJFEMEI(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void LGGFNCOBGDB(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1881f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1567f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void ILHPDNAGNGH(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 363f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1511f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void DNGHOIEKILO()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		JHEODJKLCEH(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			EAOLHFIBIGG(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void EAPFHKJLHHD()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		OCPDADKFOCN(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			OHOJCGNDNBP(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void GLEAKGKGPCB()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		EAOLHFIBIGG(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			IDOMMJJOLMF(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void MBIANLDEBPG()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		INPPMIOFCMF(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			MALIDEKFGDK(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void ANHLFCOCMNA(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 543f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 757f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void PLIPCJLLLDC()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		PBAIAPDJBIB(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			DDLJNEJCHJB(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void LEAHIMHLAOE()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		OJOPKLLCMEH(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			LGGFNCOBGDB(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void BPPFGPEBAEN(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1273f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 687f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void OJOPKLLCMEH(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 552f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1487f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void MPAMMIPNIGM()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		CIAFJINPOPK(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			KGIKDDKLOAP(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void OCPDADKFOCN(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1816f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 932f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public override void COFHBAOEBLL()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		OJOPKLLCMEH(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			LIIJPDILGIL(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void LGBKJFLFJLG(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1929f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 334f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void COLPPJEBNJC(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1461f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1555f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public override void FKKCHKEBFGD()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		PJCCNGMOLEI(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			BPPFGPEBAEN(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void MMJBLFBLKHI()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		COLPPJEBNJC(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			BJLABHBHMLA(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void DDDMDBDFGLD()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		ANHLFCOCMNA(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			BIBLHIFKLIC(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void KMKOIBAPGCO(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1120f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1476f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void IAEFFJLDHBO(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 300f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 767f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void PDBOCONOFED()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		DHPHBFIHKBL(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			DDLJNEJCHJB(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void HPFNCGKMKBH()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		FIIFHAGIOJD(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			FIIFHAGIOJD(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void AOMGKMNEFMC(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1044f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1025f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void EPAPMPJBNHB(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1282f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1024f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void GKDEFNLPDIK(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 501f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1028f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void OEGCPOKHPFN(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1194f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 365f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void BNEIIHILDNC()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		MALIDEKFGDK(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			OJOPKLLCMEH(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void BJLABHBHMLA(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1480f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 855f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void ACOBDBEAFMF()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		KMKOIBAPGCO(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			EHIIKNDJHCP(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void LOHKHMJPHAF()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		COLPPJEBNJC(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			ILJDEJFEMEI(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void JLFDKPCPDAG()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		OEGCPOKHPFN(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			ANHLFCOCMNA(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void CIAFJINPOPK(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1198f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 882f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public override void LLBKJDLGGBK()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		KMKOIBAPGCO(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			DHPHBFIHKBL(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void GPBKOEGJIIM()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		OJOPKLLCMEH(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			CIAFJINPOPK(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void OFOCBAPJHLN()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		JHEODJKLCEH(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		foreach (BatchedWeapon batchedWeapon in kBGEINIEKHI)
		{
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			HJICBPAODLN(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public override void FFMJJOALPLI()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		BPPFGPEBAEN(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			GGIJGAEJLHM(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void IDOMMJJOLMF(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 940f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 417f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void MALIDEKFGDK(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 84f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 710f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void HLAHJLMMKBF()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		CIAFJINPOPK(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			MFDBEPCIHDA(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void ILJDEJFEMEI(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 0.5f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 0.1f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void HJICBPAODLN(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 524f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1880f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void JHEODJKLCEH(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1688f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 222f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void CBNJLPABNGE()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		IDOMMJJOLMF(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			CIAFJINPOPK(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void INPPMIOFCMF(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 840f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1096f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void GGIJGAEJLHM(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 969f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1614f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void DFDLGBELMGH()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		MFDBEPCIHDA(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			MFDBEPCIHDA(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void FIIFHAGIOJD(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1809f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 808f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	private void EAOLHFIBIGG(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1882f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 414f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void KHLJPAOJOKJ()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		MCKOIGDFDCP(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			ILJDEJFEMEI(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void KGIKDDKLOAP(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1631f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 79f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void PKJJJGPIFEI()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		BPPFGPEBAEN(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			OEGCPOKHPFN(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void MLAABJMCCLH(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1292f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 199f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void DLGLMKGLHCJ()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		ILJDEJFEMEI(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			MLAABJMCCLH(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void BIBLHIFKLIC(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 890f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1487f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void IGDALFFNNJP()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		IDOMMJJOLMF(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			MLAABJMCCLH(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void BDIHKKANCAH(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1061f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 1424f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void MHPPOAOJMJA()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		IAEFFJLDHBO(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			AOMGKMNEFMC(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	public virtual void JMHIKJNMEFE()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		PBAIAPDJBIB(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 0; i < kBGEINIEKHI.Length; i += 0)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			DDLJNEJCHJB(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void EHIIKNDJHCP(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 1296f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 795f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}

	public virtual void KEOCEEHJKCG()
	{
		base.UpgradesLoaded();
		MissileSetup mBNLFKHLDBH = (MissileSetup)KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		ILHPDNAGNGH(mBNLFKHLDBH);
		TurretWeaponMultipleWeapons turretWeaponMultipleWeapons = (TurretWeaponMultipleWeapons)KAIGJFPMEKL;
		BatchedWeapon[] kBGEINIEKHI = turretWeaponMultipleWeapons.KBGEINIEKHI;
		for (int i = 1; i < kBGEINIEKHI.Length; i++)
		{
			BatchedWeapon batchedWeapon = kBGEINIEKHI[i];
			mBNLFKHLDBH = (MissileSetup)batchedWeapon.JMMJHCOKCGG.ammoSetup;
			EPAPMPJBNHB(mBNLFKHLDBH);
		}
		KAIGJFPMEKL.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
	}

	private void MFDBEPCIHDA(MissileSetup MBNLFKHLDBH)
	{
		MBNLFKHLDBH.ABFGHBDEBAN = (float)base.currentBeh.turretBehaviour.damage * 340f;
		MBNLFKHLDBH.EPDELOGPNAC = (float)base.currentBeh.turretBehaviour.damage * 608f;
		MBNLFKHLDBH.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		MBNLFKHLDBH.JPNAINOGAMM = base.currentBeh.turretBehaviour.shotSpeed;
		MBNLFKHLDBH.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		MBNLFKHLDBH.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
	}
}
