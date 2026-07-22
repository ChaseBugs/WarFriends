using UnityEngine;
using UnityEngine.Serialization;

public class Grenade : PhysicalAmmoWeapon
{
	private MeshRenderer ILMIFFPMLLB;

	public GrenadeAmmoBase.LNOCLBOKLBN CPBDKPFPAND;

	[FormerlySerializedAs("NODJLOPHBJF")]
	public bool AOIDFKHMLHO;

	private Mesh KKMICBOHPFJ;

	protected virtual Ammo DPJBABCHFBK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.ADBOHNCGKHA().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[3] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_HEROIC", PhotonTargets.All, array);
				}
				HAHLNNKLNKG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo KOHIJFCIAIA(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[5] = MPHCNMDIPAI;
					array[6] = (byte)PhotonNetwork.player.ID;
					array[6] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("squad member name", PhotonTargets.Others, array);
				}
				OBBKNNGGNFL(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void IKNLCEIDGNJ(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.COJFMKNGPBP().JHMIEOOPEAB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			EIBNCMCOAPI(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("RealTimeMultiplayer");
		}
	}

	protected virtual Ammo AEBCJCGOACM(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.DKNHCGGKNMF().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[7];
					array[0] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[1] = MPHCNMDIPAI;
					array[1] = (byte)PhotonNetwork.player.ID;
					array[3] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Prefabs", PhotonTargets.Others, array);
				}
				BaseShoot(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo MKMHOIIJHEO(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.MFKPDKCLDBI().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[6] = (byte)PhotonNetwork.player.ID;
					array[0] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("{0}\u00a0{1}", PhotonTargets.Others, array);
				}
				GBHDHLIHHAB(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void DHBOLMOPGJJ()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void CHGOKMLPNDK()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void HJDDJHHGMJD()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	[PunRPC]
	public override void ShootCopyRPC(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.ReInstantiate(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("Physical ammo is null !!!");
		}
	}

	private void GMCLPBMEONN()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void DFMGLOMJCAJ()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void PHFBPCOOOOB()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo EMLMKNDPLPD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[5];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[8] = (byte)PhotonNetwork.player.ID;
					array[2] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("registerLevel", PhotonTargets.All, array);
				}
				GPCJOCPOAML(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void PIJJJADJEAF(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.MFKPDKCLDBI().NBFJJKEHPOO(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GPCJOCPOAML(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("PhotonConnectionManager: Disconnect");
		}
	}

	protected virtual Ammo ACMLIGGIDJA(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.DKNHCGGKNMF().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[3];
					array[0] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[7] = MPHCNMDIPAI;
					array[5] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Action ", PhotonTargets.Others, array);
				}
				HAHLNNKLNKG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo GNHJJHILIKB(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.MFKPDKCLDBI().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[6];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[2] = MPHCNMDIPAI;
					array[3] = (byte)PhotonNetwork.player.ID;
					array[0] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_GUI_EQUIPPED", PhotonTargets.All, array);
				}
				GBHDHLIHHAB(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo KPDBBAHJJOP(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.EHFPBDJMGNC().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.COOEDLNDBID();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[2] = MPHCNMDIPAI;
					array[3] = (byte)PhotonNetwork.player.ID;
					array[4] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("{0}{1}[-] / {2}", PhotonTargets.All, array);
				}
				BaseShoot(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo OJKEHEBBNGK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.DKNHCGGKNMF().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[7];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[8] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[4] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_TUTORIAL_PROGRESS_KILLING", PhotonTargets.All, array);
				}
				PDJKJMGOHFO(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void FCFMMHLOOGB(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.FDHBHPHCNHB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			EIBNCMCOAPI(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("GameGold");
		}
	}

	private void OCFPBJAELAE()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void AGFBIBKOKJP(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KJEANKAJELG().ReInstantiate(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GPCJOCPOAML(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("Awaiting players - Removing player ");
		}
	}

	public virtual void NGFOIOEJGCP(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().ReInstantiate(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGANPBAPDJK(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("'ID_MONTH_'0");
		}
	}

	private void FCHGHCPFOFC()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void EKMGFCBEPID()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void KFKLLAGCDIF()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void DHAFKCABNEE(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.ADBOHNCGKHA().HIDBCFCHJHD(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GNGBOHLENBG(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("menu-gold");
		}
	}

	protected virtual Ammo JPBFBBMCFPI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KJEANKAJELG().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[5] = MPHCNMDIPAI;
					array[2] = (byte)PhotonNetwork.player.ID;
					array[6] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC(", ", PhotonTargets.All, array);
				}
				GNGBOHLENBG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void KBNHICKADJD()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void FOIMNMOOEHJ()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void LHAJGCDPHBK()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void KGGHMDGIFGE()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo JIAMHAMPHJI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[3] = MPHCNMDIPAI;
					array[6] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("SK", PhotonTargets.Others, array);
				}
				EIBNCMCOAPI(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void JLKMAJCOKDN()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo MJOIBFJLOGI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.MFKPDKCLDBI().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[6];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[5] = MPHCNMDIPAI;
					array[5] = (byte)PhotonNetwork.player.ID;
					array[1] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("These colours are used in IDs:\n", PhotonTargets.Others, array);
				}
				OBBKNNGGNFL(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void MDKEBBDHKCE(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.MFKPDKCLDBI().EOHIMCFOLEC(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GBHDHLIHHAB(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("App not installed");
		}
	}

	protected virtual Ammo CDOENIPGBBP(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[4];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[6] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[0] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("menu-info-ico", PhotonTargets.Others, array);
				}
				PDJKJMGOHFO(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo KHAHLKNPNPI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.INOJHPIKICM().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[8] = MPHCNMDIPAI;
					array[6] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("throw_grenade_up", PhotonTargets.All, array);
				}
				GNGBOHLENBG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected override Ammo OFAKPAJJJEH(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[0] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[6] = MPHCNMDIPAI;
					array[2] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("menu-army-cat-rusher", PhotonTargets.All, array);
				}
				GGEILKAEMJJ(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void FBIPGGBJCJD()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void AECOBEABBKF()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void JHOCLHNEEJN(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().EOHIMCFOLEC(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGEILKAEMJJ(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("ID_TUTORIAL_TAPON");
		}
	}

	protected virtual Ammo CCGOBMELFJP(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KJEANKAJELG().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[0] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("216 MENU ARMY SCREEN TUTORIAL UNIT ACTIVATED", PhotonTargets.Others, array);
				}
				HAHLNNKLNKG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void GKDFANEIGJI()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected override Ammo EMOMBOIMKCJ(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.EHFPBDJMGNC().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[3];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[6] = MPHCNMDIPAI;
					array[6] = (byte)PhotonNetwork.player.ID;
					array[7] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Min", PhotonTargets.All, array);
				}
				PDJKJMGOHFO(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void FPBJABOEPIM(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.COJFMKNGPBP().HIDBCFCHJHD(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			DNLFNFCJNJM(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("{");
		}
	}

	protected virtual Ammo CLEFGKAJLFI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.CHHLLIAHECC().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[3];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[1] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Awaiting players - Player was removed from awaiting members.", PhotonTargets.All, array);
				}
				HAHLNNKLNKG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void FEHHCFNBLII(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.CHHLLIAHECC().FDHBHPHCNHB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("-1");
		}
	}

	protected override Ammo MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					FEHCCGEGPLH.RPC("ShootCopyRPC", PhotonTargets.Others, num, GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI, (byte)PhotonNetwork.player.ID, GGJPNLDIGGM);
				}
				BaseShoot(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void JDIGCKCIOEA()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void IJFAAGLMIMA()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void ODHFHLBKFLJ(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.CHHLLIAHECC().OCMGKBOAALJ(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGANPBAPDJK(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("ID_TUTORIAL_GO_BUY_ARMY_6");
		}
	}

	protected virtual Ammo EALHJACGOJD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KJEANKAJELG().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[4];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[0] = MPHCNMDIPAI;
					array[4] = (byte)PhotonNetwork.player.ID;
					array[7] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_CONFIRM_NOSQUADACTIONS_TITLE", PhotonTargets.All, array);
				}
				HAHLNNKLNKG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo GGAHEKAOAPL(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.INOJHPIKICM().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[7];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("[FF0000]BLACKMARKET[-]", PhotonTargets.All, array);
				}
				GBHDHLIHHAB(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo EIMPPPKNJIA(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.CHHLLIAHECC().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.COOEDLNDBID();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[0];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[2] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[2] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Skill", PhotonTargets.Others, array);
				}
				PDJKJMGOHFO(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void LMHFEIDFDFB()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo DBCDDNOILJD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.GLHPLCEFHGD().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[3];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[8] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[7] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("JSON = ", PhotonTargets.All, array);
				}
				EIBNCMCOAPI(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void FGPFFAHLANG(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.EHFPBDJMGNC().HIDBCFCHJHD(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGEILKAEMJJ(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("DOWNLOAD");
		}
	}

	private void OnEnable()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void PFFHPLNNAFL(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.GLHPLCEFHGD().INPABPJCOCE(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			DNLFNFCJNJM(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("menu-assignments-type-score");
		}
	}

	protected virtual Ammo AGLLMEDFAKM(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.ADBOHNCGKHA().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[3] = MPHCNMDIPAI;
					array[1] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("IsVip", PhotonTargets.All, array);
				}
				PDJKJMGOHFO(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public override void ECBFNFIPOLK(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KJEANKAJELG().INPABPJCOCE(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			PDJKJMGOHFO(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("Win");
		}
	}

	public virtual void HFNDAHMCBDC(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.INOJHPIKICM().KBPAHFJHOIH(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			HAHLNNKLNKG(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("ID_GUI_POWERBANDON");
		}
	}

	private void EAOEPEMNBKH()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo APFEPFDKCKK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.COJFMKNGPBP().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[4] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("squad", PhotonTargets.All, array);
				}
				GGEILKAEMJJ(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void LCONIJCHKCO(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().FDHBHPHCNHB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			OBBKNNGGNFL(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("veteranpack5");
		}
	}

	protected virtual Ammo ODLMMPHOBLF(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.CHHLLIAHECC().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[8] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_LOADING", PhotonTargets.All, array);
				}
				GNGBOHLENBG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public override void LMMFGDHGIHI(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.GLHPLCEFHGD().HIDBCFCHJHD(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("Seconds");
		}
	}

	protected virtual Ammo HLHBMAHHKLI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.INOJHPIKICM().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[0] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[7] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("IsVip", PhotonTargets.Others, array);
				}
				OBBKNNGGNFL(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo IACPNCFKAFH(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.COJFMKNGPBP().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[4];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[4] = MPHCNMDIPAI;
					array[4] = (byte)PhotonNetwork.player.ID;
					array[6] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC(" BOUGHT AND PRESENT IN ACCOUNT", PhotonTargets.Others, array);
				}
				BaseShoot(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void BMFKGMADKNI()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void BPIBGCCLCPJ()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo FLLLJLJPNCK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.MFKPDKCLDBI().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[4];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[1] = MPHCNMDIPAI;
					array[2] = (byte)PhotonNetwork.player.ID;
					array[6] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("withAdvertiserSubAdgroup", PhotonTargets.All, array);
				}
				GGANPBAPDJK(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void ADGENMCFHOM()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo DOLLANGOAIM(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.ADBOHNCGKHA().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[6] = MPHCNMDIPAI;
					array[3] = (byte)PhotonNetwork.player.ID;
					array[4] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Windows", PhotonTargets.Others, array);
				}
				DNLFNFCJNJM(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void AAJNEIGKOAG()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void KOJDGOBMEOO()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo CAFGOLKOGJK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.KJEANKAJELG().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[0];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[1] = MPHCNMDIPAI;
					array[1] = (byte)PhotonNetwork.player.ID;
					array[0] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_STARTERASSIGNMENT", PhotonTargets.Others, array);
				}
				GNGBOHLENBG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void CIGMMLKAICG()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void BFDGIIHNHAI()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void ABFLEBDLBPO(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.EHFPBDJMGNC().INPABPJCOCE(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			EIBNCMCOAPI(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("UNLOCKLEVEL");
		}
	}

	public virtual void EOMAAKNPJKO(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.COJFMKNGPBP().OCMGKBOAALJ(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			DNLFNFCJNJM(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("Starter_Assignment_Completed");
		}
	}

	protected virtual Ammo HMPDNBABBGN(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.CHHLLIAHECC().FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[0];
					array[1] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[2] = MPHCNMDIPAI;
					array[4] = (byte)PhotonNetwork.player.ID;
					array[1] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ADDING WEAPON ON CLIENT", PhotonTargets.Others, array);
				}
				EIBNCMCOAPI(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void FHAMNJFOOGI()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	protected virtual Ammo DAMHDCFCALK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[0] = num;
					array[0] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[3] = MPHCNMDIPAI;
					array[7] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("ID_CONFIRM_ERROR", PhotonTargets.Others, array);
				}
				DNLFNFCJNJM(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	protected virtual Ammo LKNMMHMEMEJ(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.ADBOHNCGKHA().EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[6];
					array[1] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[6] = MPHCNMDIPAI;
					array[7] = (byte)PhotonNetwork.player.ID;
					array[5] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V", PhotonTargets.Others, array);
				}
				BaseShoot(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void NJMCOMLCIFK(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().EOHIMCFOLEC(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			HAHLNNKLNKG(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("Multiplayer Record {0:D2}");
		}
	}

	private void HPOKCLIDBLN()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void OJLNNJGNNGP(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.INOJHPIKICM().JHMIEOOPEAB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("ID_TUTORIAL_OBJECTIVE");
		}
	}

	protected virtual Ammo NICDLJBDANI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.GLHPLCEFHGD().Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.COOEDLNDBID();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[4];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[8] = MPHCNMDIPAI;
					array[7] = (byte)PhotonNetwork.player.ID;
					array[6] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("WarFriends", PhotonTargets.Others, array);
				}
				GNGBOHLENBG(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void PHDGEMCHNBP(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().ReInstantiate(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GBHDHLIHHAB(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("Snapshots");
		}
	}

	private void GFNAEAEDGAG()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void KJMKPCDCBBC()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void HDFOAGHEBAP(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.INOJHPIKICM().GDPKBCHABBP(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			OBBKNNGGNFL(IIMDKHJAJGO, CAKABHIPCDF: false);
		}
		else
		{
			Debug.LogError("\t\"FALSE\"");
		}
	}

	private void JEBAKCGMJKI()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void BOBKPFNCNDO()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void FELEPFCBBPC()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void FEGIGGADBLA(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.KBPAHFJHOIH(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.ChangeGrenade(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = false;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GPCJOCPOAML(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("RETRY");
		}
	}

	public override void PMGGCOKKCEH(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.ADBOHNCGKHA().KBPAHFJHOIH(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GNGBOHLENBG(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("Total_Gold_Spent");
		}
	}

	private void BKDHHFNHLJB()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void FBEJEIPJIBN()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	public virtual void AMHMHOCKIBA(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte LBGNKGJEBAE, bool PPEECHPNBKF)
	{
		GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)ObjectPoolDatabase.KKCMCNCCIMB().GDPKBCHABBP(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (grenadeAmmoBase != null)
		{
			PhotonNetwork.ChangeOwner(grenadeAmmoBase.LAADDLGBFIG, LBGNKGJEBAE);
			grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
			grenadeAmmoBase.LoadAmmoSetup(base.ammoSetup);
			grenadeAmmoBase.CAKABHIPCDF = true;
			grenadeAmmoBase.JMMJHCOKCGG = this;
			grenadeAmmoBase.GGJPNLDIGGM = PPEECHPNBKF;
			grenadeAmmoBase.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			DNLFNFCJNJM(IIMDKHJAJGO, CAKABHIPCDF: true);
		}
		else
		{
			Debug.LogError("country");
		}
	}

	protected virtual Ammo PCAGDLKNNMN(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			OIFOAKPDCCI = (GrenadeAmmoBase)ObjectPoolDatabase.networkPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + CLPNFCANJLP, Quaternion.identity);
			GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)OIFOAKPDCCI;
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				grenadeAmmoBase.NAHDEHLLFOE(CPBDKPFPAND, ILMIFFPMLLB, KKMICBOHPFJ);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				OIFOAKPDCCI.Fire(GHPBMCAKMMB.transform.position + CLPNFCANJLP, MPHCNMDIPAI);
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[0] = num;
					array[1] = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
					array[3] = MPHCNMDIPAI;
					array[2] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("FuseboxxConfigValue", PhotonTargets.All, array);
				}
				GPCJOCPOAML(MPHCNMDIPAI, CAKABHIPCDF);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	private void KHIAEBIGAOC()
	{
		if (AOIDFKHMLHO)
		{
			if (ILMIFFPMLLB == null)
			{
				ILMIFFPMLLB = GetComponentInChildren<MeshRenderer>();
			}
			if (ILMIFFPMLLB != null)
			{
				KKMICBOHPFJ = ILMIFFPMLLB.GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}
}
