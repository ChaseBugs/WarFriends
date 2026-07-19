using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoldierBehaviourWarper : SoldierBehaviourRusher<SoldierBehaviourDefinititonFlamethrower>
{
	private sealed class PMCFMCKPFLG
	{
		internal PlayerController DKAMPJKILHK;

		internal int KJIFNOJILDB(SpawnPoint HPJFBKEKJHB, SpawnPoint NCMHGPNPEJM)
		{
			float sqrMagnitude = (DKAMPJKILHK.transform.position - HPJFBKEKJHB.transform.position).sqrMagnitude;
			return (DKAMPJKILHK.transform.position - NCMHGPNPEJM.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		}

		internal int MMEEJDGGAID(SpawnPoint HPJFBKEKJHB, SpawnPoint NCMHGPNPEJM)
		{
			float sqrMagnitude = (DKAMPJKILHK.transform.position - HPJFBKEKJHB.transform.position).sqrMagnitude;
			return (DKAMPJKILHK.transform.position - NCMHGPNPEJM.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		}

		internal int LGJCNCHBFDA(SpawnPoint HPJFBKEKJHB, SpawnPoint NCMHGPNPEJM)
		{
			float sqrMagnitude = (DKAMPJKILHK.transform.position - HPJFBKEKJHB.transform.position).sqrMagnitude;
			return (DKAMPJKILHK.transform.position - NCMHGPNPEJM.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		}

		internal int LJCDGJKCNEC(SpawnPoint HPJFBKEKJHB, SpawnPoint NCMHGPNPEJM)
		{
			float sqrMagnitude = (DKAMPJKILHK.transform.position - HPJFBKEKJHB.transform.position).sqrMagnitude;
			return (DKAMPJKILHK.transform.position - NCMHGPNPEJM.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		}

		internal int ECPMEMNKMCB(SpawnPoint HPJFBKEKJHB, SpawnPoint NCMHGPNPEJM)
		{
			float sqrMagnitude = (DKAMPJKILHK.transform.position - HPJFBKEKJHB.transform.position).sqrMagnitude;
			return (DKAMPJKILHK.transform.position - NCMHGPNPEJM.transform.position).sqrMagnitude.CompareTo(sqrMagnitude);
		}
	}

	public float JKPMGFPHOIO = 2f;

	public Material PIECBNLPFOO;

	private WarpTrails LCJJDKHALGI;

	private Material MIOJCHHHELM;

	public override SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.LJCDGJKCNEC);
		return list[0];
	}

	public virtual void IKNEKMDFLAN()
	{
		LMNPOINIJBD.StartEnemyBehaviour((EnemyController.AJGFGCHCAPA)(-89));
	}

	private void GDLEENNHPJA()
	{
		LMNPOINIJBD.WarpAgain();
	}

	public virtual void OEFOKKLIDIH(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		base.OnDeath(OHJPPHFEAFI);
		ChangeToNormalMat();
	}

	private void BGBCCIENINO()
	{
		LMNPOINIJBD.BNGAJMFGEOG();
	}

	public virtual void FIFJEKMIIPO()
	{
		LMNPOINIJBD.FIFJEKMIIPO((EnemyController.AJGFGCHCAPA)(-87));
	}

	public override void StartEnemyBehaviour()
	{
		LMNPOINIJBD.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Warp);
	}

	public override void Copy(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		WarpTrails component = GetComponent<WarpTrails>();
		WarpTrails warpTrails = IIMDKHJAJGO.gameObject.AddComponent<WarpTrails>();
		warpTrails.ODGFIDEAMAD = UnityEngine.Object.Instantiate(component.ODGFIDEAMAD);
		warpTrails.CDGCLLJKCBO = UnityEngine.Object.Instantiate(component.CDGCLLJKCBO);
		warpTrails.ODGFIDEAMAD.gameObject.transform.parent = IIMDKHJAJGO.gameObject.transform;
		warpTrails.ODGFIDEAMAD.gameObject.transform.localPosition = component.ODGFIDEAMAD.transform.localPosition;
		warpTrails.CDGCLLJKCBO.gameObject.transform.parent = IIMDKHJAJGO.gameObject.transform;
		warpTrails.CDGCLLJKCBO.gameObject.transform.localPosition = component.CDGCLLJKCBO.transform.localPosition;
	}

	public virtual void HCJHAHEJJCH()
	{
		LMNPOINIJBD.FIFJEKMIIPO((EnemyController.AJGFGCHCAPA)(-30));
	}

	[CompilerGenerated]
	private void PNAAAGIKBBJ()
	{
		LMNPOINIJBD.WarpAgain();
	}

	public override void UpdateVisual()
	{
		if (MIOJCHHHELM == null)
		{
			MIOJCHHHELM = base.IGLLHPCDHLD.material;
		}
		if (LCJJDKHALGI == null)
		{
			LCJJDKHALGI = LMNPOINIJBD.GetComponent<WarpTrails>();
		}
		if (MIOJCHHHELM != null)
		{
			base.IGLLHPCDHLD.ChangeMaterial(MIOJCHHHELM);
		}
		base.UpdateVisual();
	}

	public virtual SpawnPoint HAGEINLDFOB(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
		List<SpawnPoint> list = new List<SpawnPoint>();
		foreach (SpawnPoint item in AJNOOHNJMDN)
		{
			if (AcceptSpawnPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count <= 1)
		{
			throw new Exception("RewardValue");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.LGJCNCHBFDA);
		return list[0];
	}

	private void ODPNGPHKMMN()
	{
		LMNPOINIJBD.WarpAgain();
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[0].JMDLKIAKOIE = 0.2f;
		ShotGunBulletSetup shotGunBulletSetup = (ShotGunBulletSetup)EEMHAHAINNM[0].ammoSetup;
		shotGunBulletSetup.GJFCKILFOAE = base.soldierBehaviourDefinititon.damage;
		shotGunBulletSetup.NNNCAFEGNNC = (float)base.soldierBehaviourDefinititon.damage * 0.1f;
		shotGunBulletSetup.KLGJDBCMCAA = "shotReal";
	}

	public override void DestroyBehaviour()
	{
		base.DestroyBehaviour();
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(false);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(false);
		}
		if (LMNPOINIJBD != null)
		{
			LMNPOINIJBD.HJFHCPBADLD.speed = 0.8f;
		}
	}

	protected override void DEFKBAMEKFI()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.position);
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public override void ShootJustStarted()
	{
		base.ShootJustStarted();
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Rusher)
		{
			InvokeAfter(delegate
			{
				LMNPOINIJBD.WarpAgain();
			}, 1f);
		}
	}

	public virtual SpawnPoint BPBIGCEMLKJ(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
			throw new Exception("ID_CONFIRM_ERROR");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.LGJCNCHBFDA);
		return list[0];
	}

	public virtual void GODEFCHEEJG()
	{
		base.DestroyBehaviour();
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(true);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(true);
		}
		if (LMNPOINIJBD != null)
		{
			LMNPOINIJBD.HJFHCPBADLD.speed = 792f;
		}
	}

	public virtual SpawnPoint FPJOEELDIKD(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
			throw new Exception(" BOXES ");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.LGJCNCHBFDA);
		return list[1];
	}

	public virtual SpawnPoint PIKKPMIDFLI(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
			throw new Exception("ID_ENEMYWILLBESELECTEDRANDOMLY");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.LJCDGJKCNEC);
		return list[0];
	}

	public virtual void HOFAIBIDALB()
	{
		base.DestroyBehaviour();
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(false);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(false);
		}
		if (LMNPOINIJBD != null)
		{
			LMNPOINIJBD.HJFHCPBADLD.speed = 823f;
		}
	}

	protected virtual void EFPGIJHLHBB()
	{
		base.KMINNAEBJAB();
		EEMHAHAINNM[1].JMDLKIAKOIE = 892f;
		ShotGunBulletSetup shotGunBulletSetup = (ShotGunBulletSetup)EEMHAHAINNM[0].ammoSetup;
		shotGunBulletSetup.GJFCKILFOAE = base.soldierBehaviourDefinititon.damage;
		shotGunBulletSetup.NNNCAFEGNNC = (float)base.soldierBehaviourDefinititon.damage * 1821f;
		shotGunBulletSetup.KLGJDBCMCAA = "ok";
	}

	public virtual void JNCEOGEJPFH(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		base.OnDeath(OHJPPHFEAFI);
		ChangeToNormalMat();
	}

	public virtual SpawnPoint IKDANHNIEKO(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
			throw new Exception("Shotgunner spawned");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.MMEEJDGGAID);
		return list[0];
	}

	protected virtual void MGGFFCHGIAJ()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.OBBPNKCOJNO());
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public virtual SpawnPoint PKOLHIKNLHN(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
			throw new Exception("LikeUsOnFacebook");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.MMEEJDGGAID);
		return list[0];
	}

	public virtual void LJCDAOHIPKA()
	{
		base.DestroyBehaviour();
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(true);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(true);
		}
		if (LMNPOINIJBD != null)
		{
			LMNPOINIJBD.HJFHCPBADLD.speed = 1835f;
		}
	}

	public override void KOAEOBLLNEP(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		WarpTrails component = GetComponent<WarpTrails>();
		WarpTrails warpTrails = IIMDKHJAJGO.gameObject.AddComponent<WarpTrails>();
		warpTrails.ODGFIDEAMAD = UnityEngine.Object.Instantiate(component.ODGFIDEAMAD);
		warpTrails.CDGCLLJKCBO = UnityEngine.Object.Instantiate(component.CDGCLLJKCBO);
		warpTrails.ODGFIDEAMAD.gameObject.transform.parent = IIMDKHJAJGO.gameObject.transform;
		warpTrails.ODGFIDEAMAD.gameObject.transform.localPosition = component.ODGFIDEAMAD.transform.localPosition;
		warpTrails.CDGCLLJKCBO.gameObject.transform.parent = IIMDKHJAJGO.gameObject.transform;
		warpTrails.CDGCLLJKCBO.gameObject.transform.localPosition = component.CDGCLLJKCBO.transform.localPosition;
	}

	public virtual void NLJAPLANCDP(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		base.OnDeath(OHJPPHFEAFI);
		ChangeToNormalMat();
	}

	public virtual void PJAGHHOFBHK(AIObject IIMDKHJAJGO)
	{
		base.Copy(IIMDKHJAJGO);
		WarpTrails component = GetComponent<WarpTrails>();
		WarpTrails warpTrails = IIMDKHJAJGO.gameObject.AddComponent<WarpTrails>();
		warpTrails.ODGFIDEAMAD = UnityEngine.Object.Instantiate(component.ODGFIDEAMAD);
		warpTrails.CDGCLLJKCBO = UnityEngine.Object.Instantiate(component.CDGCLLJKCBO);
		warpTrails.ODGFIDEAMAD.gameObject.transform.parent = IIMDKHJAJGO.gameObject.transform;
		warpTrails.ODGFIDEAMAD.gameObject.transform.localPosition = component.ODGFIDEAMAD.transform.localPosition;
		warpTrails.CDGCLLJKCBO.gameObject.transform.parent = IIMDKHJAJGO.gameObject.transform;
		warpTrails.CDGCLLJKCBO.gameObject.transform.localPosition = component.CDGCLLJKCBO.transform.localPosition;
	}

	public virtual void OMDIHCJFFAL()
	{
		if (MIOJCHHHELM == null)
		{
			MIOJCHHHELM = base.IGLLHPCDHLD.IMMKJIEONDL();
		}
		if (LCJJDKHALGI == null)
		{
			LCJJDKHALGI = LMNPOINIJBD.GetComponent<WarpTrails>();
		}
		if (MIOJCHHHELM != null)
		{
			base.IGLLHPCDHLD.OCMOLNNBFOO(MIOJCHHHELM);
		}
		base.UpdateVisual();
	}

	public virtual SpawnPoint MOHKOMNGKFG(IEnumerable<SpawnPoint> AJNOOHNJMDN)
	{
		PMCFMCKPFLG pMCFMCKPFLG = new PMCFMCKPFLG();
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
			throw new Exception("ID_ISALREADYMEMBEROFANOTHERSQUAD");
		}
		pMCFMCKPFLG.DKAMPJKILHK = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
		list.Sort(pMCFMCKPFLG.KJIFNOJILDB);
		return list[0];
	}

	private void HNCLNGNKPGG()
	{
		LMNPOINIJBD.BNGAJMFGEOG();
	}

	public virtual void IBIEBAJHCED()
	{
		base.ShootJustStarted();
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Rusher)
		{
			InvokeAfter(BGBCCIENINO, 1251f);
		}
	}

	public virtual void KOPCHDDACLE()
	{
		base.DestroyBehaviour();
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(true);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(true);
		}
		if (LMNPOINIJBD != null)
		{
			LMNPOINIJBD.HJFHCPBADLD.FKPINHAHNNG(1582f);
		}
	}

	public override void OnDeath(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		base.OnDeath(OHJPPHFEAFI);
		ChangeToNormalMat();
	}

	public void ChangeToNormalMat()
	{
		base.IGLLHPCDHLD.ChangeMaterial(MIOJCHHHELM);
		base.IGLLHPCDHLD.AKHGKGCOGEN.SetAttachmentsMaterial(MIOJCHHHELM);
		base.IGLLHPCDHLD.AKPKJMNGFIE.SetAttachmentsMaterial(MIOJCHHHELM);
		KHKAAGCIJPO.gameObject.SetActive(true);
		IILCGHOLDHF.SwitchWeapon(0);
	}

	public virtual void KCFGMJLCEJL()
	{
		base.DestroyBehaviour();
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(false);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(true);
		}
		if (LMNPOINIJBD != null)
		{
			LMNPOINIJBD.HJFHCPBADLD.FKPINHAHNNG(1023f);
		}
	}

	private void FMLLGOPJDIB()
	{
		LMNPOINIJBD.WarpAgain();
	}

	protected virtual void JMHENEFGAEL()
	{
		base.DEFKBAMEKFI();
		BulletSetup bulletSetup = KHKAAGCIJPO.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction);
			float num = LMNPOINIJBD.transform.position.PlanarDistance(enemyOf.position);
			bulletSetup.OFGIEEDGBPB = num < JKPMGFPHOIO;
		}
	}

	public virtual void NFOLCDELIFJ()
	{
		LMNPOINIJBD.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.RusherSpare);
	}

	public virtual void IAEKGFEGPCH()
	{
		base.ShootJustStarted();
		if (LMNPOINIJBD.IPIKDCMLOID == EnemyController.AJGFGCHCAPA.Idle)
		{
			InvokeAfter(JDDLNJCDADI, 1779f);
		}
	}

	public void ChangeToTransparent()
	{
		base.IGLLHPCDHLD.ChangeMaterial(PIECBNLPFOO);
		base.IGLLHPCDHLD.AKHGKGCOGEN.SetAttachmentsMaterial(PIECBNLPFOO);
		base.IGLLHPCDHLD.AKPKJMNGFIE.SetAttachmentsMaterial(PIECBNLPFOO);
		KHKAAGCIJPO.gameObject.SetActive(false);
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(true);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(true);
		}
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, HINJJOAJAOA.WarpSound);
	}

	private void JDDLNJCDADI()
	{
		LMNPOINIJBD.WarpAgain();
	}

	public void PJLNIKKMHGN()
	{
		base.IGLLHPCDHLD.FKANJHJKPDO(PIECBNLPFOO);
		base.IGLLHPCDHLD.AKHGKGCOGEN.SetAttachmentsMaterial(PIECBNLPFOO);
		base.IGLLHPCDHLD.AKPKJMNGFIE.AJAFDBLABMA(PIECBNLPFOO);
		KHKAAGCIJPO.gameObject.SetActive(true);
		if (LCJJDKHALGI != null)
		{
			LCJJDKHALGI.ODGFIDEAMAD.gameObject.SetActive(false);
			LCJJDKHALGI.CDGCLLJKCBO.gameObject.SetActive(false);
		}
		Singleton<SoundsManager3D>.instance.PHGHNHAAPOK(base.gameObject, (HINJJOAJAOA)(-65), 1814f);
	}
}
