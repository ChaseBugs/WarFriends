using UnityEngine;
using UnityEngine.Serialization;

public class SkillShotControllerBonusBox : SkillShotController
{
	[FormerlySerializedAs("EPJEKFCINIC")]
	public AudioClip MLPHPPMFNFD;

	[PunRPC]
	protected void RecieveStolen(byte CIOPAKLHFIL)
	{
		OKBPJCBIBFK((GHPGNELIDBM)CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
	}

	protected void CFODHKCIHBC(byte CIOPAKLHFIL)
	{
		GOMFNJMOKDN((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
	}

	protected void LKGAIPKGPEN(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.DMFGNABOGEB(base.transform.position, MLPHPPMFNFD, 627f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DCNCODEBBPP(AOCPNNPGECM);
		}
	}

	protected void NBEAOHNPCGC(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.DMFGNABOGEB(base.transform.position, MLPHPPMFNFD, 1616f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayBoxStolen(AOCPNNPGECM);
		}
	}

	public void JBJEOEHMGOH(GHPGNELIDBM CIOPAKLHFIL)
	{
		HLBBHHPFBJK(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC(")", PhotonTargets.All, array);
	}

	public void Play(GHPGNELIDBM CIOPAKLHFIL)
	{
		OKBPJCBIBFK(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		FEHCCGEGPLH.RPC("RecieveStolen", PhotonTargets.Others, (byte)CIOPAKLHFIL);
	}

	public void HKLFDBHLNGO(GHPGNELIDBM CIOPAKLHFIL)
	{
		KJBFEKLKGHB(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("Started delivering army upgrade for {0} {1}. It will be ready in {2} seconds.", PhotonTargets.All, array);
	}

	protected void KFBIAFCEFOP(byte CIOPAKLHFIL)
	{
		BEOONCDICGF((GHPGNELIDBM)CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
	}

	protected void EJFCOGNCCOH(byte CIOPAKLHFIL)
	{
		BEOONCDICGF((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
	}

	protected void JMFHIANKLHJ(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.DMFGNABOGEB(base.transform.position, MLPHPPMFNFD, 598f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.MICBBABHGFM(AOCPNNPGECM);
		}
	}

	protected void HLBBHHPFBJK(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.DMFGNABOGEB(base.transform.position, MLPHPPMFNFD, 1335f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.BCDJJBAFLLG().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.MKAGOKKFJGO(AOCPNNPGECM);
		}
	}

	protected void AEAADDIEKAN(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.CEDACKOHHNA(base.transform.position, MLPHPPMFNFD, 999f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen += 0;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.BBEMKLDJDMF(AOCPNNPGECM);
		}
	}

	public void KNBJJPIFIPE(GHPGNELIDBM CIOPAKLHFIL)
	{
		GAAHJIJCOHM(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("NO", PhotonTargets.All, array);
	}

	protected virtual void AOKFOFFGIBC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void GOMFNJMOKDN(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.DMFGNABOGEB(base.transform.position, MLPHPPMFNFD, 502f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen += 0;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.GAFFKDOELMI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.MKAGOKKFJGO(AOCPNNPGECM);
		}
	}

	protected void OCCJBOGPECI(byte CIOPAKLHFIL)
	{
		LAGFGFNIDLJ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
	}

	protected void KJBFEKLKGHB(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.CEDACKOHHNA(base.transform.position, MLPHPPMFNFD, 673f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.IJDDNDNLAHG(AOCPNNPGECM);
		}
	}

	protected void NDJDBHFFJMA(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.CEDACKOHHNA(base.transform.position, MLPHPPMFNFD, 326f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen += 0;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.BNDNFHKPDLM().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.LCNPBNOKMCJ(AOCPNNPGECM);
		}
	}

	protected void FABLGLIOIEC(byte CIOPAKLHFIL)
	{
		LAGFGFNIDLJ((GHPGNELIDBM)CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
	}

	protected virtual void JMJNOJNJPMJ(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void AODFOOEDJFJ(byte CIOPAKLHFIL)
	{
		BEOONCDICGF((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
	}

	protected virtual void KJFAHHJFFME(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void EADMENKHKGI(byte CIOPAKLHFIL)
	{
		OKBPJCBIBFK((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
	}

	protected void DNBDKEOGHJK(byte CIOPAKLHFIL)
	{
		KJBFEKLKGHB((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
	}

	public void DMFGNABOGEB(GHPGNELIDBM CIOPAKLHFIL)
	{
		NDJDBHFFJMA(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("ID_GUI_REPORTABUSE_LISTITEM3", PhotonTargets.Others, array);
	}

	protected void KMBOFFJPIDK(byte CIOPAKLHFIL)
	{
		BEOONCDICGF((GHPGNELIDBM)CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
	}

	protected virtual void GLDACLAAPOF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void FBFMJOFKJCL(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.CEDACKOHHNA(base.transform.position, MLPHPPMFNFD, 1597f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.IJDDNDNLAHG(AOCPNNPGECM);
		}
	}

	protected virtual void DIHCMLHHDFA(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void NMLLLOBHIBF(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.EHDDJLHJBIL(base.transform.position, MLPHPPMFNFD, 1594f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen += 0;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.MKAGOKKFJGO(AOCPNNPGECM);
		}
	}

	protected void DIOPOKPIAKA(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.EHDDJLHJBIL(base.transform.position, MLPHPPMFNFD, 1759f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.OGBIHEFNJGO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.DCNCODEBBPP(AOCPNNPGECM);
		}
	}

	public void NJCHPFPACHC(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKGAIPKGPEN(CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("BEGINNERS {0}   {1}.   {2}", PhotonTargets.All, array);
	}

	public void GEFHHIKPDGE(GHPGNELIDBM CIOPAKLHFIL)
	{
		LAGFGFNIDLJ(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[1] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("extraScraps", PhotonTargets.All, array);
	}

	public void HAMAEFIDGIM(GHPGNELIDBM CIOPAKLHFIL)
	{
		LKGAIPKGPEN(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("ArenaUnlockedMessage", PhotonTargets.All, array);
	}

	protected void LAGFGFNIDLJ(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.EHDDJLHJBIL(base.transform.position, MLPHPPMFNFD, 1281f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen += 0;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayBoxStolen(AOCPNNPGECM);
		}
	}

	public void DNCEHHODMHB(GHPGNELIDBM CIOPAKLHFIL)
	{
		AEAADDIEKAN(CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction);
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = (byte)CIOPAKLHFIL;
		fEHCCGEGPLH.RPC("DogTagRefillTime", PhotonTargets.Others, array);
	}

	protected void OKBPJCBIBFK(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, MLPHPPMFNFD);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.PlayBoxStolen(AOCPNNPGECM);
		}
	}

	protected virtual void BNLAOGKHKDF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void BEOONCDICGF(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, MLPHPPMFNFD, 207f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen += 0;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.KPCLHHDMNDD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.BLNOMFPADHG(AOCPNNPGECM);
		}
	}

	protected virtual void DFIEFMEHKMF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected override void CHBCMIDNBBM(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected override void ILIBPDHNEJE(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}

	protected void GAAHJIJCOHM(bool AOCPNNPGECM)
	{
		if (AOCPNNPGECM)
		{
			Singleton<SoundsManager3D>.instance.PCMPCDKKKIB(base.transform.position, MLPHPPMFNFD, 1231f);
		}
		if (!AOCPNNPGECM)
		{
			StatsManager.instance.matchStats.cratesStolen++;
		}
		SkillShotDisplayer skillShotDisplayer = (SkillShotDisplayer)Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.NBKAACNKJEM);
		if (skillShotDisplayer != null)
		{
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(JEGEBJNNHME.transform.position);
			skillShotDisplayer.transform.position = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			skillShotDisplayer.AGFDKGGBJLN(AOCPNNPGECM);
		}
	}

	protected virtual void DMCDNOILKID(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
	}
}
