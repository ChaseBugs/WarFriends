using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : PoolableObject
{
	public enum Mode
	{
		Health,
		Ammo
	}

	public AimTarget aimTarget;

	private Mode mMode;

	public Material healthMat;

	public Material ammoMat;

	public Transform displayerPosition;

	public Mode mode
	{
		get
		{
			return mMode;
		}
		set
		{
			mMode = value;
			switch (mMode)
			{
			case Mode.Ammo:
				GetComponent<MeshRenderer>().sharedMaterial = ammoMat;
				break;
			case Mode.Health:
				GetComponent<MeshRenderer>().sharedMaterial = healthMat;
				break;
			}
		}
	}

	public float power { get; set; }

	protected override void Awake()
	{
		base.Awake();
		aimTarget.Clicked += AimTargetOnClicked;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (mode == Mode.Health)
		{
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, Sounds3DEnum.MedkitDrop);
		}
	}

	private void AimTargetOnClicked()
	{
		CustomDisplayerItem customDisplayerItem = (CustomDisplayerItem)Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.customDisplayerItem);
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position + Vector3.up * 0.7f);
		customDisplayerItem.transform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
		switch (mMode)
		{
		case Mode.Ammo:
		{
			customDisplayerItem.Play("game-box-ammo", Localization.Localize("ID_EXTRAAMMO"), Colours.blueBoxLabel, Color.black);
			List<PlayerWeapon> usedWeapons = PlayerController.currentPlayer.weaponInventory.usedWeapons;
			foreach (PlayerWeapon item in usedWeapons)
			{
				if ((int)item.weapon.clipSize > 0)
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.clipSize * power);
				}
				else
				{
					item.weapon.ammoLeft += Mathf.CeilToInt((float)(int)item.weapon.startingAmmmoCount * 0.1f * power);
				}
			}
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, Sounds3DEnum.MedkitPickup);
			break;
		}
		case Mode.Health:
		{
			customDisplayerItem.Play("game-box-health", Localization.LocalizeFormat("ID_PLUSHEALTH", MiscTools.FormatFloatNumberAsPercent(power)), Color.green, Color.black);
			PlayerController currentPlayer = PlayerController.currentPlayer;
			currentPlayer.destroyableParts.Heal(currentPlayer.destroyableParts.maxHealth * power, isNetworkCopy: false);
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, Sounds3DEnum.MedkitPickup);
			break;
		}
		}
		DestroyPooled();
	}
}
