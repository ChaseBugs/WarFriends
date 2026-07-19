using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Mortar : PhysicalAmmoWeapon
{
	public GameObject JPDFMABBKDI;

	public vp_MuzzleFlash FPJEKKMDJCG;

	private float MKOGHDKDFIN = 0.04f;

	[CompilerGenerated]
	private void NHIHDOFEFHB(UITweener NGADLHBIHGL)
	{
		JPDFMABBKDI.SetActive(false);
	}

	public virtual void HMIGDPBGEIG()
	{
		base.OnInstancied();
		JPDFMABBKDI.SetActive(false);
	}

	private void KFCKOMFNHJM(UITweener MGDJMGHCAAI)
	{
		TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(JPDFMABBKDI, 401f, new Color(1369f, 1817f, 720f, 1752f), new Color(975f, 249f, 1685f, 937f));
		tweenColorTk2d.style = (UITweener.Style)3;
		tweenColorTk2d.NumOfRepetitions = 8;
		tweenColorTk2d.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColorTk2d.onFinished, (UITweener.OnFinished)delegate
		{
			JPDFMABBKDI.SetActive(false);
		});
		tweenColorTk2d.ignoreTimeScale = true;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		JPDFMABBKDI.SetActive(false);
	}

	[CompilerGenerated]
	private void GMPDBBAHGOF(UITweener MGDJMGHCAAI)
	{
		TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(JPDFMABBKDI, 0.1f, new Color(1f, 1f, 1f, 0.35f), new Color(1f, 1f, 1f, 0f));
		tweenColorTk2d.style = UITweener.Style.PingPong;
		tweenColorTk2d.NumOfRepetitions = 5;
		tweenColorTk2d.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColorTk2d.onFinished, (UITweener.OnFinished)delegate
		{
			JPDFMABBKDI.SetActive(false);
		});
		tweenColorTk2d.ignoreTimeScale = false;
	}

	protected override Ammo MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		MissileSetup fGANLCJCOCA = base.ammoSetup as MissileSetup;
		GHPBMCAKMMB.transform.position = MPHCNMDIPAI + 5f * Vector3.up;
		Ammo result = base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		if (FPJEKKMDJCG != null)
		{
			FPJEKKMDJCG.Shoot(false);
		}
		CACPIIINDND(fGANLCJCOCA, MPHCNMDIPAI + MKOGHDKDFIN * Vector3.up);
		return result;
	}

	public virtual void HFBCEMKNEJM()
	{
		base.OnInstancied();
		JPDFMABBKDI.SetActive(false);
	}

	public virtual void IPEAHJBMBGI()
	{
		base.OnInstancied();
		JPDFMABBKDI.SetActive(true);
	}

	public override float ComputeFlyTimeToTarget(Vector3 MPHCNMDIPAI)
	{
		MissileSetup missileSetup = base.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / missileSetup.JPNAINOGAMM + 0.1f;
		}
		return 0.1f;
	}

	[PunRPC]
	public override void ShootCopyRPC(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
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
			if (FPJEKKMDJCG != null)
			{
				FPJEKKMDJCG.Shoot(false);
			}
			MissileSetup fGANLCJCOCA = base.ammoSetup as MissileSetup;
			CACPIIINDND(fGANLCJCOCA, IIMDKHJAJGO + MKOGHDKDFIN * Vector3.up);
		}
		else
		{
			Debug.LogError("Physical ammo is null !!!");
		}
	}

	private void CACPIIINDND(MissileSetup FGANLCJCOCA, Vector3 MPHCNMDIPAI)
	{
		if (base.fraction == PlayerController.OGMBJPKOPCB.fraction)
		{
			return;
		}
		JPDFMABBKDI.gameObject.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		JPDFMABBKDI.gameObject.transform.position = MPHCNMDIPAI;
		JPDFMABBKDI.transform.rotation = Quaternion.LookRotation(Vector3.up);
		JPDFMABBKDI.SetActive(true);
		TweenRotationSpecial tweenRotationSpecial = TweenRotationSpecial.Begin(JPDFMABBKDI, 2f, Vector3.up, 0f, 360f);
		tweenRotationSpecial.style = UITweener.Style.Loop;
		tweenRotationSpecial.method = UITweener.Method.Linear;
		tweenRotationSpecial.CFPMPNBEJFK = new Vector3(90f, 0f, 0f);
		tweenRotationSpecial.ignoreTimeScale = false;
		TweenColorTk2d.Begin(JPDFMABBKDI, 0f, new Color(1f, 1f, 1f, 0.35f)).ignoreTimeScale = false;
		TweenScale tweenScale = TweenScale.Begin(JPDFMABBKDI, FGANLCJCOCA.PHAJLOIIAGN - 0.3f, Vector3.one * 1.5f, Vector3.one * 0.65f);
		tweenScale.ignoreTimeScale = false;
		tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, (UITweener.OnFinished)delegate
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(JPDFMABBKDI, 0.1f, new Color(1f, 1f, 1f, 0.35f), new Color(1f, 1f, 1f, 0f));
			tweenColorTk2d.style = UITweener.Style.PingPong;
			tweenColorTk2d.NumOfRepetitions = 5;
			tweenColorTk2d.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColorTk2d.onFinished, (UITweener.OnFinished)delegate
			{
				JPDFMABBKDI.SetActive(false);
			});
			tweenColorTk2d.ignoreTimeScale = false;
		});
	}

	protected virtual Ammo KACHOCKGPLA(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		MissileSetup fGANLCJCOCA = base.ammoSetup as MissileSetup;
		GHPBMCAKMMB.transform.position = MPHCNMDIPAI + 896f * Vector3.up;
		Ammo result = DKBNHCMPMNN(MPHCNMDIPAI, CAKABHIPCDF);
		if (FPJEKKMDJCG != null)
		{
			FPJEKKMDJCG.MDKGJBLNBIB(true);
		}
		CACPIIINDND(fGANLCJCOCA, MPHCNMDIPAI + MKOGHDKDFIN * Vector3.up);
		return result;
	}

	public virtual float CPOMALBJLNG(Vector3 MPHCNMDIPAI)
	{
		MissileSetup missileSetup = base.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / missileSetup.JPNAINOGAMM + 1320f;
		}
		return 540f;
	}

	private void AOAOLNPDLLI(UITweener MGDJMGHCAAI)
	{
		TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(JPDFMABBKDI, 1442f, new Color(1319f, 940f, 1013f, 248f), new Color(1845f, 1306f, 784f, 440f));
		tweenColorTk2d.style = (UITweener.Style)8;
		tweenColorTk2d.NumOfRepetitions = 4;
		tweenColorTk2d.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColorTk2d.onFinished, (UITweener.OnFinished)delegate
		{
			JPDFMABBKDI.SetActive(false);
		});
		tweenColorTk2d.ignoreTimeScale = false;
	}

	public virtual void LFKHODFEBLH()
	{
		base.OnInstancied();
		JPDFMABBKDI.SetActive(false);
	}

	public virtual void FEHHCFNBLII(int DFHAAIFFLOE, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, byte ALIIBMLMNKA, bool PPEECHPNBKF)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.MFKPDKCLDBI().NBFJJKEHPOO(OLKAIPEHAML, DFHAAIFFLOE, OEIICEJPGKI, Quaternion.identity);
		GGJPNLDIGGM = PPEECHPNBKF;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.LAADDLGBFIG, ALIIBMLMNKA);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.CAKABHIPCDF = true;
			physicalAmmo.JMMJHCOKCGG = this;
			physicalAmmo.GGJPNLDIGGM = PPEECHPNBKF;
			physicalAmmo.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			BaseShoot(IIMDKHJAJGO, false);
			if (FPJEKKMDJCG != null)
			{
				FPJEKKMDJCG.PCMJCBKMAKG(false);
			}
			MissileSetup fGANLCJCOCA = base.ammoSetup as MissileSetup;
			KBEOGKHEIHD(fGANLCJCOCA, IIMDKHJAJGO + MKOGHDKDFIN * Vector3.up);
		}
		else
		{
			Debug.LogError("weapon");
		}
	}

	private void KBEOGKHEIHD(MissileSetup FGANLCJCOCA, Vector3 MPHCNMDIPAI)
	{
		if (base.fraction != PlayerController.OGMBJPKOPCB.fraction)
		{
			JPDFMABBKDI.gameObject.transform.parent = Singleton<MainSceneRoot>.instance.transform;
			JPDFMABBKDI.gameObject.transform.position = MPHCNMDIPAI;
			JPDFMABBKDI.transform.rotation = Quaternion.LookRotation(Vector3.up);
			JPDFMABBKDI.SetActive(false);
			TweenRotationSpecial tweenRotationSpecial = TweenRotationSpecial.OKCMGMMLEJP(JPDFMABBKDI, 635f, Vector3.up, 924f, 1833f);
			tweenRotationSpecial.style = UITweener.Style.Once;
			tweenRotationSpecial.method = UITweener.Method.Linear;
			tweenRotationSpecial.CFPMPNBEJFK = new Vector3(966f, 1060f, 1559f);
			tweenRotationSpecial.ignoreTimeScale = false;
			TweenColorTk2d.Begin(JPDFMABBKDI, 1906f, new Color(1170f, 1287f, 92f, 210f)).ignoreTimeScale = false;
			TweenScale tweenScale = TweenScale.Begin(JPDFMABBKDI, FGANLCJCOCA.PHAJLOIIAGN - 1764f, Vector3.one * 1772f, Vector3.one * 382f);
			tweenScale.ignoreTimeScale = true;
			tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, new UITweener.OnFinished(KFCKOMFNHJM));
		}
	}
}
