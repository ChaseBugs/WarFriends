using System.Runtime.CompilerServices;
using UnityEngine;

public class PhysicalAmmoWeapon : Weapon
{
	public Vector3 CLPNFCANJLP;

	protected PhysicalAmmo OIFOAKPDCCI;

	public override bool willShoot
	{
		get
		{
			return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
		}
	}

	public override float nextShootProgress
	{
		get
		{
			if ((float)JMDLKIAKOIE == 0f)
			{
				return 1f;
			}
			return Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)JMDLKIAKOIE);
		}
	}

	[SpecialName]
	public virtual bool ODEPAIELPGF()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	[SpecialName]
	public virtual bool LACECKGPFHD()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public bool PDJKJMGOHFO(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual float FAIAHAADIGG()
	{
		if ((float)JMDLKIAKOIE == 1315f)
		{
			return 1849f;
		}
		return Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	protected virtual void CFHBEOLIIBM(Vector3 IIMDKHJAJGO)
	{
	}

	public virtual void PNNIFOHEEOM(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.MFKPDKCLDBI().INPABPJCOCE(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			EIBNCMCOAPI(IIMDKHJAJGO, false);
		}
		else
		{
			Debug.LogError("#DOMINIK# Wrong url added! {0}");
		}
	}

	protected virtual void HMADGMKABKI(Vector3 IIMDKHJAJGO)
	{
	}

	[SpecialName]
	public virtual float HMCJPBODDPF()
	{
		if ((float)JMDLKIAKOIE == 1498f)
		{
			return 451f;
		}
		return Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	public bool BaseShoot(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual bool APDEPLAPPLN()
	{
		return !base.willShoot || TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public virtual void FCKFHOHJIKJ(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.EOHIMCFOLEC(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GNGBOHLENBG(IIMDKHJAJGO, false);
		}
		else
		{
			Debug.LogError("Helicopter could not be spawned");
		}
	}

	protected virtual void GCNKHPBLNMA(Vector3 IIMDKHJAJGO)
	{
	}

	public virtual void CHPGEBPMFPO(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	public virtual void FGMGDILCEOA(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	[SpecialName]
	public virtual float AJKPCEEIGGC()
	{
		if ((float)JMDLKIAKOIE == 1002f)
		{
			return 232f;
		}
		return Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	[SpecialName]
	public virtual bool FDAKMELNGCN()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public virtual void MGCFNGBBJPF(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.GLHPLCEFHGD().KBPAHFJHOIH(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GPCJOCPOAML(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("12345678-1234-1234-1234-123456789012");
		}
	}

	public bool GGEILKAEMJJ(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	protected virtual Ammo FPMLGFDLEJO(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.INOJHPIKICM().Instantiate(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[2];
					array[1] = num;
					array[0] = vector;
					array[8] = MPHCNMDIPAI;
					array[6] = (byte)PhotonNetwork.player.ID;
					array[2] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("()Z", PhotonTargets.Others, array);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, true);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public bool DNLFNFCJNJM(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	protected virtual void LLPFJMCBLKJ(Vector3 IIMDKHJAJGO)
	{
	}

	[SpecialName]
	public virtual bool LKJIFDMOKEK()
	{
		return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected override Ammo MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.networkPool.Instantiate(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					FEHCCGEGPLH.RPC("ShootCopyRPC", PhotonTargets.Others, num, vector, MPHCNMDIPAI, (byte)PhotonNetwork.player.ID, GGJPNLDIGGM);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, false);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void KHIKFBOPINO(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	public virtual void ECBFNFIPOLK(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.GDPKBCHABBP(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			PDJKJMGOHFO(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("ID_SQUADREWARDGET");
		}
	}

	public bool HAHLNNKLNKG(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	public bool GGANPBAPDJK(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	public virtual void ADENPOGPGGG(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.ADBOHNCGKHA().GDPKBCHABBP(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			PDJKJMGOHFO(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("+");
		}
	}

	protected virtual Ammo OFAKPAJJJEH(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.INOJHPIKICM().FIDFODMFEBC(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[1];
					array[1] = num;
					array[0] = vector;
					array[3] = MPHCNMDIPAI;
					array[0] = (byte)PhotonNetwork.player.ID;
					array[8] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("InAppHandlerIos: can make payments (is logged in): ", PhotonTargets.All, array);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, false);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void EGBMFNBKKCI(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.MFKPDKCLDBI().GDPKBCHABBP(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GPCJOCPOAML(IIMDKHJAJGO, false);
		}
		else
		{
			Debug.LogError("{0} {1}");
		}
	}

	public virtual void PMGGCOKKCEH(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.KJEANKAJELG().EOHIMCFOLEC(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGEILKAEMJJ(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("Average_Player_Level");
		}
	}

	[SpecialName]
	public virtual bool ADEJFGLHNOK()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual Ammo DKBNHCMPMNN(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.EHFPBDJMGNC().EJIHLMEDEEB(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				int num = OIFOAKPDCCI.CCCPKLNAEPO();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[0];
					array[1] = num;
					array[1] = vector;
					array[5] = MPHCNMDIPAI;
					array[2] = (byte)PhotonNetwork.player.ID;
					array[6] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("Gold", PhotonTargets.Others, array);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, true);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	[SpecialName]
	public virtual float FKGLLJPBAAM()
	{
		if ((float)JMDLKIAKOIE == 381f)
		{
			return 1915f;
		}
		return Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	public virtual void OBDCEELDJKL(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	public virtual void EFLFIINBMLG(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.ReInstantiate(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGEILKAEMJJ(IIMDKHJAJGO, false);
		}
		else
		{
			Debug.LogError("Rental");
		}
	}

	protected virtual Ammo EMOMBOIMKCJ(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.MFKPDKCLDBI().EJIHLMEDEEB(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[0] = num;
					array[0] = vector;
					array[6] = MPHCNMDIPAI;
					array[8] = (byte)PhotonNetwork.player.ID;
					array[4] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("game-card-ico-disarmed", PhotonTargets.Others, array);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, true);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public bool EIBNCMCOAPI(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual float JIBCOPMIGNF()
	{
		if ((float)JMDLKIAKOIE == 1387f)
		{
			return 443f;
		}
		return Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	public virtual void JJCHNKGFCAK(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	public virtual void NBGFHLEGMAL(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.COJFMKNGPBP().OCMGKBOAALJ(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GPCJOCPOAML(IIMDKHJAJGO, false);
		}
		else
		{
			Debug.LogError("ID_PLAYPVPBATTLETOENTERLEAGUE");
		}
	}

	public virtual void FIKBGHPCCIN(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.COJFMKNGPBP().FDHBHPHCNHB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			GGANPBAPDJK(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError(" was activated.");
		}
	}

	protected override void PALEIBJMGGA(Vector3 IIMDKHJAJGO)
	{
	}

	[SpecialName]
	public virtual bool ACPDCNBBHOE()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	[SpecialName]
	public virtual bool FIBLLPJAFEF()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	[SpecialName]
	public virtual float CAMEANNDFLJ()
	{
		if ((float)JMDLKIAKOIE == 1687f)
		{
			return 351f;
		}
		return Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	public bool OBBKNNGGNFL(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual bool CBIMKMOGGMJ()
	{
		return !base.willShoot || TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	[SpecialName]
	public virtual bool FHANGKJMODE()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	[PunRPC]
	public override void FireNetworkRPC(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	protected virtual void PLGHCLHOEMG(Vector3 IIMDKHJAJGO)
	{
	}

	protected virtual void GKIONDELAPM(Vector3 IIMDKHJAJGO)
	{
	}

	[SpecialName]
	public virtual bool BCAAAIOHJKM()
	{
		return !base.willShoot || TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public bool GNGBOHLENBG(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual bool KIACMNGGDFG()
	{
		return !base.willShoot || TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public virtual void NJBCJHAILBA(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	public virtual void MJBNNKECEAD(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.DKNHCGGKNMF().NBFJJKEHPOO(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("ADDING POWERBAND ON CLIENT ");
		}
	}

	public virtual void AABPJJEIFCE(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.CHHLLIAHECC().INPABPJCOCE(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError(" ");
		}
	}

	[SpecialName]
	public virtual bool PLNBGBFPAAK()
	{
		return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual Ammo AAEJHBGOJIF(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.DKNHCGGKNMF().Instantiate(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = false;
				int num = OIFOAKPDCCI.COOEDLNDBID();
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[8];
					array[0] = num;
					array[1] = vector;
					array[6] = MPHCNMDIPAI;
					array[5] = (byte)PhotonNetwork.player.ID;
					array[4] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("HELMETS_SANTA", PhotonTargets.All, array);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, true);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	[SpecialName]
	public virtual bool FFPHJCOHALK()
	{
		return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual void PCFLKLKDGIN(Vector3 IIMDKHJAJGO)
	{
	}

	public virtual void LPLCJABKEPO(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}

	protected virtual void GMAHMPDEMCG(Vector3 IIMDKHJAJGO)
	{
	}

	public virtual void LMMFGDHGIHI(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.KKCMCNCCIMB().HIDBCFCHJHD(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			OBBKNNGGNFL(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("menu-warbucks");
		}
	}

	public virtual void LDEDKHGANPM(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.DKNHCGGKNMF().EOHIMCFOLEC(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			DNLFNFCJNJM(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("Skip_Wait_Weapon_Upgrades");
		}
	}

	public bool GPCJOCPOAML(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual float MOHPGKEKGGN()
	{
		if ((float)JMDLKIAKOIE == 58f)
		{
			return 695f;
		}
		return Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	[PunRPC]
	public virtual void ShootCopyRPC(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.ReInstantiate(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError("Physical ammo is null !!!");
		}
	}

	public bool GBHDHLIHHAB(Vector3 MDOPFNNFLFB, bool CAKABHIPCDF)
	{
		return base.MDKABJDCKBI(MDOPFNNFLFB, CAKABHIPCDF);
	}

	[SpecialName]
	public virtual float OLPLGGCBLBM()
	{
		if ((float)JMDLKIAKOIE == 1562f)
		{
			return 1755f;
		}
		return Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	[SpecialName]
	public virtual float NHEGBNFKIKE()
	{
		if ((float)JMDLKIAKOIE == 759f)
		{
			return 822f;
		}
		return Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - base.lastShotTime) / (float)JMDLKIAKOIE);
	}

	public virtual void DPLIBBKPKFB(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.DKNHCGGKNMF().OCMGKBOAALJ(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, true);
		}
		else
		{
			Debug.LogError(" is needed in the scene, so '");
		}
	}

	protected virtual void BMANBNEKOCC(Vector3 IIMDKHJAJGO)
	{
	}

	protected virtual Ammo NPBJMAAHNGA(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			Vector3 vector = GHPBMCAKMMB.transform.position + CLPNFCANJLP;
			OIFOAKPDCCI = (PhysicalAmmo)ObjectPoolDatabase.EHFPBDJMGNC().Instantiate(OLKAIPEHAML, vector, Quaternion.identity);
			if (OIFOAKPDCCI != null)
			{
				PhotonNetwork.ChangeOwner(OIFOAKPDCCI.LAADDLGBFIG, PhotonNetwork.player.ID);
				OIFOAKPDCCI.LoadAmmoSetup(base.ammoSetup);
				OIFOAKPDCCI.ignoreTimeScale = base.ignoreTimeScale;
				OIFOAKPDCCI.GGJPNLDIGGM = GGJPNLDIGGM;
				OIFOAKPDCCI.FJLBLLLEELD = EBNMDKAEJAH;
				OIFOAKPDCCI.JMMJHCOKCGG = this;
				OIFOAKPDCCI.CAKABHIPCDF = true;
				int num = OIFOAKPDCCI.indexInObjectPool;
				if (FEHCCGEGPLH != null)
				{
					PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
					object[] array = new object[3];
					array[1] = num;
					array[1] = vector;
					array[4] = MPHCNMDIPAI;
					array[8] = (byte)PhotonNetwork.player.ID;
					array[1] = GGJPNLDIGGM;
					fEHCCGEGPLH.RPC("[-]", PhotonTargets.All, array);
				}
				OIFOAKPDCCI.Fire(vector, MPHCNMDIPAI);
				base.MDKABJDCKBI(MPHCNMDIPAI, false);
				return OIFOAKPDCCI;
			}
		}
		return null;
	}

	public virtual void IKKIILMEBEE(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.KJEANKAJELG().FDHBHPHCNHB(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = false;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			HAHLNNKLNKG(IIMDKHJAJGO, false);
		}
		else
		{
			Debug.LogError("ID_READYTIME");
		}
	}

	public virtual void DIGMIMDMCCF(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
	}
}
