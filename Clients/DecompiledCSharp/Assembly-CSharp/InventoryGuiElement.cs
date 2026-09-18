using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGuiElement : GuiElementSingle<InventoryGuiElement>
{
	[Header("Tutorial Hint")]
	public InventoryItem prefab;

	[HideInInspector]
	public List<InventoryItem> invItems = new List<InventoryItem>();

	[Header("Reloading")]
	public UISprite progress;

	public GameObject reloading;

	public UILabel realoadingText;

	[Header("Out of Ammo")]
	public GameObject autOfAmmo;

	public UILabel autOfAmmoText;

	[Header("Tutorial Hint")]
	public InventoryHintText hintText;

	private bool mWeaponIsReloading;

	private bool mWeaponOutOfAmmo;

	private bool mPlayNextShotProgres;

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		HideReloadAnimation();
		HideWeaponOutofAmmo();
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += InstanceOnAfterGameStarted;
	}

	private void InstanceOnAfterGameStarted()
	{
		WeaponsChanged();
		mWeaponIsReloading = false;
		mWeaponOutOfAmmo = false;
		HideReloadAnimation();
		HideWeaponOutofAmmo();
		hintText.Activate(shownContent: false);
	}

	private void StartReloadingAnimation()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(reloading, 0.3f, 1f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(realoadingText.gameObject, 0.2f, 1f, 0f);
			tweenAlpha.style = UITweener.Style.PingPong;
		});
	}

	private void StartAoutOfAmmoAnimation()
	{
		autOfAmmo.gameObject.SetActive(value: true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(autOfAmmo, 0.3f, 1f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(autOfAmmoText.gameObject, 0.2f, 1f, 0f);
			tweenAlpha2.style = UITweener.Style.PingPong;
		});
	}

	public void PlayWeaponReloading(PlayerWeapon weapon)
	{
		if (!weapon.weapon.outOfAmmo)
		{
			mPlayNextShotProgres = true;
		}
	}

	protected override void Update()
	{
		base.Update();
		Weapon weapon = PlayerController.currentPlayer.weaponInventory.currentWeapon.weapon;
		bool flag = weapon.isReloading && weapon.reloadableWeapon;
		if (mPlayNextShotProgres)
		{
			flag = weapon.nextShootProgress < 0.99f;
		}
		if (flag != mWeaponIsReloading)
		{
			if (flag)
			{
				StartReloadingAnimation();
			}
			else
			{
				HideReloadAnimation();
			}
			mWeaponIsReloading = flag;
		}
		bool outOfAmmo = weapon.outOfAmmo;
		if (mWeaponOutOfAmmo != outOfAmmo)
		{
			if (outOfAmmo)
			{
				StartAoutOfAmmoAnimation();
			}
			else
			{
				HideWeaponOutofAmmo();
			}
			mWeaponOutOfAmmo = outOfAmmo;
		}
		progress.fillAmount = ((!mPlayNextShotProgres) ? weapon.reloadProgress : weapon.nextShootProgress);
	}

	private void HideReloadAnimation()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(reloading, 0.2f, 0f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha.Begin(realoadingText.gameObject, 0f, 0f, 0f);
		});
		mPlayNextShotProgres = false;
	}

	private void HideWeaponOutofAmmo()
	{
		autOfAmmo.gameObject.SetActive(value: false);
	}

	public void WeaponsChanged()
	{
		invItems = new List<InventoryItem>();
		WeaponInventory weaponInventory = PlayerController.currentPlayer.weaponInventory;
		Singleton<GuiManager>.instance.objectPool.FreeObjectsWithPrefab(prefab);
		for (int num = weaponInventory.usedWeapons.Count - 1; num >= 0; num--)
		{
			PlayerWeapon weapon = weaponInventory.usedWeapons[num];
			Vector3 vector = (weaponInventory.usedWeapons.Count - 1 - num) * Vector3.left * 188f;
			InventoryItem inventoryItem = (InventoryItem)Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(prefab, prefab.transform.localPosition + vector, Quaternion.identity, base.gameObject);
			invItems.Add(inventoryItem);
			inventoryItem.CreateFromWeapon(weapon, weaponInventory);
		}
	}

	public void ShowHintText()
	{
		hintText.Activate(shownContent: true);
	}

	public void HideHintText()
	{
		hintText.Activate(shownContent: false);
	}

	public void SetWeaponsShowed(int mask)
	{
		for (int i = 0; i < invItems.Count; i++)
		{
			invItems[i].SetShowed((mask & (1 << i)) > 0);
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}
}
