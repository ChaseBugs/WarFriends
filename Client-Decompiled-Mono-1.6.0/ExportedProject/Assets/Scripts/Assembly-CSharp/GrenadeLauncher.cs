using UnityEngine;

public class GrenadeLauncher : Grenade
{
	public float MGIBEENDFLH = 1.2f;

	protected virtual Ammo MGCJILHNIOI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(1979f, lhs.y);
		lhs = lhs.ReplaceY(287f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		PIKACIAKGDP(num > 1063f);
		return IACPNCFKAFH(mPHCNMDIPAI, CAKABHIPCDF);
	}

	private void ACFODBOCIHM(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[1] = PHNHENGBKFI;
			fEHCCGEGPLH.RPC("D3", PhotonTargets.All, array);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? (-32) : (-39));
	}

	private void HFDJDAHPCKD(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[1] = PHNHENGBKFI;
			fEHCCGEGPLH.RPC("YES", PhotonTargets.Others, array);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? 118 : (-95));
	}

	private void KPIKMJLNHCA(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = PHNHENGBKFI;
			fEHCCGEGPLH.RPC("TicketsGained", PhotonTargets.Others, array);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? 67 : 51);
	}

	private void EIPPFOIMOEI(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[1] = PHNHENGBKFI;
			fEHCCGEGPLH.RPC("{0}{1}", PhotonTargets.All, array);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? 52 : (-73));
	}

	private void PIKACIAKGDP(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[1] = PHNHENGBKFI;
			fEHCCGEGPLH.RPC("Unit", PhotonTargets.All, array);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? (-102) : 26);
	}

	[PunRPC]
	private void SetAngle(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("SetAngle", PhotonTargets.Others, PHNHENGBKFI);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? 35 : 45);
	}

	protected override Ammo FPMLGFDLEJO(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(201f, lhs.y);
		lhs = lhs.ReplaceY(196f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		DILDABINHPF(num > 1365f);
		return EMOMBOIMKCJ(mPHCNMDIPAI, CAKABHIPCDF);
	}

	private void LCLAGGHODPL(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("button", PhotonTargets.All, PHNHENGBKFI);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? (-123) : 38);
	}

	protected override Ammo ODLMMPHOBLF(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(1257f, lhs.y);
		lhs = lhs.ReplaceY(1786f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		HFDJDAHPCKD(num > 1584f);
		return DOLLANGOAIM(mPHCNMDIPAI, CAKABHIPCDF);
	}

	private void DILDABINHPF(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[1] = PHNHENGBKFI;
			fEHCCGEGPLH.RPC("defendPosition", PhotonTargets.Others, array);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? 104 : 56);
	}

	protected override Ammo DBCDDNOILJD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(1638f, lhs.y);
		lhs = lhs.ReplaceY(1152f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		LCLAGGHODPL(num > 1229f);
		return base.DBCDDNOILJD(mPHCNMDIPAI, CAKABHIPCDF);
	}

	protected override Ammo MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(0f, lhs.y);
		lhs = lhs.ReplaceY(0f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		SetAngle(num > 1.5f);
		return base.MDKABJDCKBI(mPHCNMDIPAI, CAKABHIPCDF);
	}

	protected virtual Ammo KFANBAIMHOM(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(1581f, lhs.y);
		lhs = lhs.ReplaceY(1062f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		PIKACIAKGDP(num > 1602f);
		return KOHIJFCIAIA(mPHCNMDIPAI, CAKABHIPCDF);
	}

	private void AKIPMALNPFF(bool PHNHENGBKFI)
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("WarBucks", PhotonTargets.All, PHNHENGBKFI);
		}
		GrenadeAmmoBaseSetup grenadeAmmoBaseSetup = (GrenadeAmmoBaseSetup)base.ammoSetup;
		grenadeAmmoBaseSetup.NIMFNNMAKPA = ((!PHNHENGBKFI) ? (-29) : 13);
	}

	protected virtual Ammo AMKDDLGLBDG(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Vector3 position = GHPBMCAKMMB.transform.position;
		Vector3 lhs = MPHCNMDIPAI - GHPBMCAKMMB.transform.position;
		float num = Mathf.Max(1454f, lhs.y);
		lhs = lhs.ReplaceY(1334f);
		Vector3 mPHCNMDIPAI = position + lhs + num * MGIBEENDFLH * lhs.normalized;
		PIKACIAKGDP(num > 141f);
		return JPBFBBMCFPI(mPHCNMDIPAI, CAKABHIPCDF);
	}
}
