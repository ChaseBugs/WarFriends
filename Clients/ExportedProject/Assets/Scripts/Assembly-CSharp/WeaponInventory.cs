using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WeaponInventory : Core_BaseScript
{
	public List<PlayerWeapon> allWeapons;

	public Mine landMine;

	public int startGameWithIndex;

	public List<PlayerWeapon> usedWeapons;

	private PhotonView mPhotonView;

	private PlayerController mPlayerController;

	public bool cannotChange;

	public float canNotChangeFract;

	public int weaponIndex { get; private set; }

	public PlayerWeapon pistol
	{
		get
		{
			foreach (PlayerWeapon usedWeapon in usedWeapons)
			{
				if (usedWeapon.weapon is Pistol)
				{
					return usedWeapon;
				}
			}
			Debug.LogError("Player should have at least one pistol");
			return null;
		}
	}

	public PlayerWeapon currentWeapon
	{
		get
		{
			return usedWeapons[weaponIndex];
		}
		set
		{
			if (cannotChange)
			{
				return;
			}
			SelfHostedBattleClient selfHosted = UnityEngine.Object.FindObjectOfType<SelfHostedBattleClient>();
			if (selfHosted != null && selfHosted.IsConnected)
			{
				for (int i = 0; i < usedWeapons.Count; i++)
					if (usedWeapons[i] == value) { selfHosted.RequestWeaponSwitch(i); return; }
				return;
			}
			currentWeapon.gameObject.SetActive(value: false);
			for (int i = 0; i < usedWeapons.Count; i++)
			{
				PlayerWeapon playerWeapon = usedWeapons[i];
				if (playerWeapon == value)
				{
					weaponIndex = i;
					mPhotonView.RPC("ChangeWeapon", PhotonTargets.Others, (byte)i);
				}
				else
				{
					playerWeapon.isActiveWeapon = false;
				}
			}
			if (this.SelectedWeaponChanged != null)
			{
				this.SelectedWeaponChanged(currentWeapon);
			}
			currentWeapon.gameObject.SetActive(value: true);
			currentWeapon.isActiveWeapon = true;
		}
	}

	public event Action<PlayerWeapon> SelectedWeaponChanged;

	public void ApplySelfHostedSelection(int index)
	{
		if (usedWeapons == null || index < 0 || index >= usedWeapons.Count)
			throw new InvalidOperationException("Invalid authoritative weapon selection.");
		if (weaponIndex == index) return;
		currentWeapon.gameObject.SetActive(value: false);
		currentWeapon.isActiveWeapon = false;
		weaponIndex = index;
		currentWeapon.gameObject.SetActive(value: true);
		currentWeapon.isActiveWeapon = true;
		if (SelectedWeaponChanged != null) SelectedWeaponChanged(currentWeapon);
	}

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		usedWeapons.Add(allWeapons[0]);
		mPhotonView = GetComponent<PhotonView>();
		Singleton<GameController>.instance.SceneFreed += OnSceneFreed;
		mPlayerController = GetComponent<PlayerController>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = allWeapons[item.indexInWeaponInventory];
			playerWeapon.weaponLevelSetup = item;
		}
	}

	private void OnSceneFreed()
	{
		foreach (PlayerWeapon usedWeapon in usedWeapons)
		{
			usedWeapon.DestroyModel();
		}
	}

	private void InitWeapons()
	{
		PlayerInventory.EquippedWeapon[] weapons = mPlayerController.playerProperties.weapons;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		usedWeapons = new List<PlayerWeapon>();
		weaponIndex = startGameWithIndex;
		foreach (WeaponLevelsSetup item in weaponLevelsSetups)
		{
			PlayerWeapon playerWeapon = allWeapons[item.indexInWeaponInventory];
			playerWeapon.weaponLevelSetup = item;
		}
		for (int i = 0; i < weapons.Length; i++)
		{
			PlayerInventory.EquippedWeapon equippedWeapon = weapons[i];
			WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[equippedWeapon.weaponId];
			weaponLevelsSetup.weaponInventory = this;
			weaponLevelsSetup.LoadDefinition((byte)weapons[i].weaponUpgrade, mPlayerController.playerProperties.level);
			weaponLevelsSetup.weaponInventory = PlayerController.currentPlayer.weaponInventory;
			PlayerWeapon playerWeapon2 = allWeapons[weaponLevelsSetup.indexInWeaponInventory];
			playerWeapon2.isEnabled = equippedWeapon.enabled;
			usedWeapons.Add(playerWeapon2);
		}
		foreach (PlayerWeapon allWeapon in allWeapons)
		{
			allWeapon.gameObject.SetActive(value: false);
			allWeapon.isActiveWeapon = false;
			allWeapon.weapon.infiniteAmmo = false;
		}
		currentWeapon.gameObject.SetActive(value: true);
		Debug.Log("Set active weapon");
		currentWeapon.isActiveWeapon = true;
		foreach (PlayerWeapon usedWeapon in usedWeapons)
		{
			AmmoSetup ammoSetup = usedWeapon.weapon.ammoSetup;
			usedWeapon.weapon.friendKill = true;
			if (usedWeapon is PlayerZoomOnTouchWeapon)
			{
				(usedWeapon as PlayerZoomOnTouchWeapon).SetWaitTime(0.8f);
			}
			string text = string.Concat("#VAVRO# affect weapon:", usedWeapon.name, "before: critical: ", ammoSetup.criticalProbability, "damage:", ammoSetup.damageAmount);
			ammoSetup.ScaleDamage(mPlayerController.weaponDamageCoef);
			Weapon weapon = usedWeapon.weapon;
			if (mPlayerController.weaponReloadCoef > 0f)
			{
				if (weapon.reloadableWeapon)
				{
					weapon.reloadTime = (float)weapon.reloadTime * mPlayerController.weaponReloadCoef;
				}
				else
				{
					weapon.cadence = (float)weapon.cadence * mPlayerController.weaponReloadCoef;
				}
			}
			string text2 = text;
			text = string.Concat(text2, " AFTER: critical: ", ammoSetup.criticalProbability, "damage:", ammoSetup.damageAmount);
		}
	}

	private void SetWeapons(byte[] indices)
	{
		usedWeapons = new List<PlayerWeapon>();
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		weaponIndex = 0;
		foreach (byte index in indices)
		{
			PlayerWeapon item = allWeapons[weaponLevelsSetups[index].indexInWeaponInventory];
			usedWeapons.Add(item);
		}
		foreach (PlayerWeapon allWeapon in allWeapons)
		{
			allWeapon.gameObject.SetActive(value: false);
			allWeapon.isActiveWeapon = false;
		}
		currentWeapon.gameObject.SetActive(value: true);
		currentWeapon.isActiveWeapon = true;
	}

	public void SetWeapons(PlayerInventory.EquippedWeapon[] equippedWeapons)
	{
		if (equippedWeapons != null)
		{
			byte[] array = new byte[equippedWeapons.Length];
			for (int i = 0; i < equippedWeapons.Length; i++)
			{
				PlayerInventory.EquippedWeapon equippedWeapon = equippedWeapons[i];
				array[i] = (byte)equippedWeapon.weaponId;
			}
			SetWeapons(array);
		}
	}

	[PunRPC]
	private void ChangeWeapon(byte weaponIndex)
	{
		currentWeapon.gameObject.SetActive(value: false);
		currentWeapon.isActiveWeapon = false;
		this.weaponIndex = weaponIndex;
		currentWeapon.gameObject.SetActive(value: true);
		currentWeapon.isActiveWeapon = true;
		if (this.SelectedWeaponChanged != null)
		{
			this.SelectedWeaponChanged(currentWeapon);
		}
	}

	public IEnumerator LoadWeapons()
	{
		InitWeapons();
		foreach (PlayerWeapon playerWeapon in usedWeapons)
		{
			yield return Singleton<AssetBundleManager>.instance.StartCoroutine(playerWeapon.LoadWeapon());
		}
	}

	public void SetUpPlayer(PlayerController playerController)
	{
		landMine.owner = playerController;
		foreach (PlayerWeapon allWeapon in allWeapons)
		{
			allWeapon.weapon.owner = playerController;
			allWeapon.playerController = playerController;
		}
	}
}
