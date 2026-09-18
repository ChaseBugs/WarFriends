using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantBattleAnimation : Core_BaseScript
{
	[Serializable]
	private class EnemyDefinition
	{
		public Transform position;

		public Transform shootPosition;

		public LevelBehaviour unitBehavior;

		internal EnemyController mInstance;

		internal int mHits;
	}

	[SerializeField]
	private PlayerPoint mPlayerPoint;

	[SerializeField]
	private List<EnemyDefinition> enemies;

	[SerializeField]
	private Camera camera;

	private bool mIsPlaying;

	private string toolkitAtlasName = "spriteCollectionTextureCompressed";

	public event Action Showed;

	public event Action FInished;

	public void Update()
	{
		if (mIsPlaying)
		{
			PlayerController mainPlayer = CamosManager.instance.mainPlayer;
			PlayerWeapon currentWeapon = mainPlayer.weaponInventory.currentWeapon;
			currentWeapon.UpdateWeapon();
		}
	}

	private new void Awake()
	{
		camera.gameObject.SetActive(value: false);
		Weapon.OnShotHit += WeaponOnOnShotHit;
	}

	public Camera GetCamera()
	{
		return camera;
	}

	private void WeaponOnOnShotHit(Weapon weapon, Ammo ammo, Vector3 arg3, bool isNetwork, DestroyableObject hit)
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		if (!(hit != null) || !mIsPlaying || weapon.owner != mainPlayer)
		{
			return;
		}
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance.destroyableObj == hit.mainDestroyableObject)
			{
				enemy.mHits++;
				if (enemy.mHits == 3)
				{
					enemy.mInstance.PlayShotRagdoll(new DestroyableObject.DamageInfo
					{
						force = (hit.transform.position - mainPlayer.transform.position).normalized * 5f
					});
				}
			}
		}
	}

	public void StartAnimation()
	{
		StartCoroutine(PlayAnimation());
	}

	public void Show()
	{
		StopAllCoroutines();
		StartCoroutine(ShowCoroutine());
	}

	private IEnumerator ShowCoroutine()
	{
		mIsPlaying = true;
		PhotonConnectionManager.JoinOfflineGame();
		InitPlayer();
		yield return null;
		AtlasPreparer.Load2DToolkitTexture(toolkitAtlasName);
		yield return null;
		yield return StartCoroutine(InitOpponents());
		camera.gameObject.SetActive(value: true);
		yield return new WaitForSeconds(0.1f);
		if (this.Showed != null)
		{
			this.Showed();
		}
	}

	private IEnumerator InitOpponents()
	{
		foreach (EnemyDefinition enemyDefinition in enemies)
		{
			LevelBehaviour behavior = enemyDefinition.unitBehavior;
			yield return StartCoroutine(behavior.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(behavior, 1f), bought: true, mine: false));
			AIObject enemy = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behavior);
			if (enemy != null && enemy.prefab != null)
			{
				enemy.isPrewiev = true;
				enemy.fraction = Fractions.Enemies;
				EnemyController instance = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(enemy);
				instance.transform.parent = base.transform;
				instance.transform.position = enemyDefinition.position.position;
				instance.transform.rotation = Quaternion.LookRotation(mPlayerPoint.transform.position - enemyDefinition.position.position);
				instance.UpdatePreview(inGame: false);
				instance.soldierParts.ShadowSetActive(active: true);
				enemyDefinition.mInstance = instance;
				enemyDefinition.mHits = 0;
			}
		}
	}

	private void InitPlayer()
	{
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: true);
		mainPlayer.InitPlayerForCamera();
		mainPlayer.Preview(idle: false);
		mainPlayer.fraction = Fractions.Allies;
		mainPlayer.currentPlayerPoint = new MapDefinition.DefendPosition
		{
			point = mPlayerPoint
		};
		CamosManager.instance.UpdateVisuals(mainPlayer);
		mainPlayer.soldierParts.ShadowSetActive(active: true);
		mainPlayer.transform.parent = base.transform;
		mainPlayer.transform.rotation = mPlayerPoint.transform.rotation;
		mainPlayer.transform.position = mPlayerPoint.transform.position;
		mainPlayer.transform.localScale = Vector3.one;
		mainPlayer.soldierAnimator.ForceInScreen();
		PlayerWeapon currentWeapon = mainPlayer.weaponInventory.currentWeapon;
		currentWeapon.weapon.ammoLeftInClip = 20;
		currentWeapon.weapon.clipSize = 20;
		currentWeapon.weapon.cadence = 0.12f;
		LightMachinegun lightMachinegun = currentWeapon.weapon as LightMachinegun;
		if (lightMachinegun != null)
		{
			lightMachinegun.missProbability = 0f;
		}
		Singleton<SoundsManager3D>.instance.LoadNow(currentWeapon.weapon.shotSound);
		Singleton<GameCamera>.instance.transform.position = mainPlayer.transform.position + 2f * Vector3.up;
		Singleton<GameCamera>.instance.transform.rotation = mainPlayer.transform.rotation;
		mainPlayer.soldierAnimator.Idle(currentWeapon.weapon.weaponType);
	}

	private IEnumerator PlayAnimation()
	{
		mIsPlaying = true;
		TimeManager.Begin(0f, 1f, 1f);
		yield return new WaitForSeconds(1f);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		PlayerWeapon playerWeapon = mainPlayer.weaponInventory.currentWeapon;
		for (int index = 0; index < enemies.Count; index++)
		{
			EnemyDefinition enemyDefinition = enemies[index];
			for (int i = 0; i < 3; i++)
			{
				int h = enemyDefinition.mHits;
				while (!playerWeapon.weapon.willShoot)
				{
					yield return null;
				}
				Vibration.iPhoneVibrate(Vibration.iPhoneVibrateType.VibrateLight);
				playerWeapon.ShootForBot(enemyDefinition.mInstance.destroyableObject.parts[1].transform.position);
				yield return new WaitForSeconds(0.1f);
				if (i == 0)
				{
					GuiScreenSingle<InstantBattleResultsScreen>.instance.ShowLabels(enemyDefinition.mInstance.destroyableObject.parts[1].transform.position, index);
				}
				float s = ((index != 0 || i != 0) ? 0.1f : 0.2f);
				yield return new WaitForSeconds(s);
			}
			yield return new WaitForSeconds(0.2f);
		}
		if (this.FInished != null)
		{
			this.FInished();
		}
	}

	public void Hide()
	{
		StopAllCoroutines();
		mIsPlaying = false;
		camera.gameObject.SetActive(value: false);
		PlayerController mainPlayer = CamosManager.instance.mainPlayer;
		mainPlayer.gameObject.SetActive(value: false);
		mainPlayer.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		mainPlayer.transform.localScale = Vector3.one;
		DestroyEnemies();
		AtlasPreparer.UnLoad2DToolkitTexture(toolkitAtlasName);
	}

	public void DestroyEnemies()
	{
		foreach (EnemyDefinition enemy in enemies)
		{
			if (enemy.mInstance != null)
			{
				enemy.mInstance.DestroyPooled(changeParentBack: true);
			}
			if (enemy.unitBehavior != null)
			{
				enemy.unitBehavior.Unload();
			}
		}
	}
}
