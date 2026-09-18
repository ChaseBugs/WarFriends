using System;
using UnityEngine;

public class Mortar : PhysicalAmmoWeapon
{
	public GameObject indicator;

	public vp_MuzzleFlash muzzleFlash;

	private float offset = 0.04f;

	public override void OnInstancied()
	{
		base.OnInstancied();
		indicator.SetActive(value: false);
	}

	protected override Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		MissileSetup missileSetup = base.ammoSetup as MissileSetup;
		spawnPoint.transform.position = position + 5f * Vector3.up;
		Ammo result = base.Shoot(position, isNetworkCopy);
		if (muzzleFlash != null)
		{
			muzzleFlash.Shoot(ignoreTimeScale: false);
		}
		StartIndicatorAnimation(missileSetup, position + offset * Vector3.up);
		return result;
	}

	[PunRPC]
	public override void ShootCopyRPC(int index, Vector3 from, Vector3 to, byte playerID, bool isFakeShot)
	{
		PhysicalAmmo physicalAmmo = (PhysicalAmmo)ObjectPoolDatabase.networkPool.ReInstantiate(bulletPrefab, index, from, Quaternion.identity);
		isFake = isFakeShot;
		if (physicalAmmo != null)
		{
			PhotonNetwork.ChangeOwner(physicalAmmo.photonView, playerID);
			physicalAmmo.LoadAmmoSetup(base.ammoSetup);
			physicalAmmo.isNetworkCopy = true;
			physicalAmmo.weapon = this;
			physicalAmmo.isFake = isFakeShot;
			physicalAmmo.Fire(from, to);
			BaseShoot(to, isNetworkCopy: true);
			if (muzzleFlash != null)
			{
				muzzleFlash.Shoot(ignoreTimeScale: false);
			}
			MissileSetup missileSetup = base.ammoSetup as MissileSetup;
			StartIndicatorAnimation(missileSetup, to + offset * Vector3.up);
		}
		else
		{
			Debug.LogError("Physical ammo is null !!!");
		}
	}

	private void StartIndicatorAnimation(MissileSetup missileSetup, Vector3 position)
	{
		if (fraction == PlayerController.currentPlayer.fraction)
		{
			return;
		}
		indicator.gameObject.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		indicator.gameObject.transform.position = position;
		indicator.transform.rotation = Quaternion.LookRotation(Vector3.up);
		indicator.SetActive(value: true);
		TweenRotationSpecial tweenRotationSpecial = TweenRotationSpecial.Begin(indicator, 2f, Vector3.up, 0f, 360f);
		tweenRotationSpecial.style = UITweener.Style.Loop;
		tweenRotationSpecial.method = UITweener.Method.Linear;
		tweenRotationSpecial.baseRotation = new Vector3(90f, 0f, 0f);
		tweenRotationSpecial.ignoreTimeScale = false;
		TweenColorTk2d.Begin(indicator, 0f, new Color(1f, 1f, 1f, 0.35f)).ignoreTimeScale = false;
		TweenScale tweenScale = TweenScale.Begin(indicator, missileSetup.stopTime - 0.3f, Vector3.one * 1.5f, Vector3.one * 0.65f);
		tweenScale.ignoreTimeScale = false;
		tweenScale.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenScale.onFinished, (UITweener.OnFinished)delegate
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(indicator, 0.1f, new Color(1f, 1f, 1f, 0.35f), new Color(1f, 1f, 1f, 0f));
			tweenColorTk2d.style = UITweener.Style.PingPong;
			tweenColorTk2d.NumOfRepetitions = 5;
			tweenColorTk2d.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColorTk2d.onFinished, (UITweener.OnFinished)delegate
			{
				indicator.SetActive(value: false);
			});
			tweenColorTk2d.ignoreTimeScale = false;
		});
	}

	public override float ComputeFlyTimeToTarget(Vector3 position)
	{
		MissileSetup missileSetup = base.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			float num = Vector3.Distance(spawnPoint.transform.position, position);
			return num / missileSetup.speed + 0.1f;
		}
		return 0.1f;
	}
}
