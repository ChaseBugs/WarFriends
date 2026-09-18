using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PlayerWeapon : Core_BaseScript, TimeScaleIgnorable
{
	public string assetBundleName;

	public string weaponModelPath;

	public CameraPlayerFollow.ThirdPersoncameraDefinition weaponCamera;

	public float firstShotWaitTime;

	public bool haveNextNoReload;

	protected GameObject mModel;

	private static Dictionary<string, GameObject> mModels = new Dictionary<string, GameObject>();

	private Weapon mWeapon;

	private bool mIsActiveWeapon;

	private PlayerInventory.InventorySlot mInventorySlot;

	public string iconName;

	private WeaponLevelsSetup mWeaponLevelSetup;

	public PlayerController playerController { get; set; }

	public bool isEnabled { get; set; }

	public virtual bool isActiveWeapon
	{
		get
		{
			return mIsActiveWeapon;
		}
		set
		{
			mIsActiveWeapon = value;
			if (value)
			{
				playerController.soldierAnimator.SetWeaponType(weapon.weaponType);
			}
		}
	}

	public Weapon weapon
	{
		get
		{
			if (mWeapon == null)
			{
				mWeapon = GetComponent<Weapon>();
			}
			return mWeapon;
		}
		set
		{
			mWeapon = value;
		}
	}

	public bool ignoreTimeScale
	{
		get
		{
			return weapon.ignoreTimeScale;
		}
		set
		{
			weapon.ignoreTimeScale = value;
		}
	}

	public WeaponLevelsSetup weaponLevelSetup
	{
		get
		{
			return mWeaponLevelSetup;
		}
		set
		{
			mWeaponLevelSetup = value;
			weapon.playerWeapon = this;
		}
	}

	public IEnumerator LoadWeapon()
	{
		Singleton<SoundsManager3D>.instance.UseSound(weapon.shotSound);
		if (mModel == null)
		{
			string assetname = weaponModelPath.Split('/')[1];
			string bundle = "Weapons/" + assetBundleName;
			GameObject model = null;
			if (!mModels.TryGetValue(assetname, out model))
			{
				string path = bundle + "/Player_" + assetname;
				model = Resources.Load<GameObject>(path);
				if (model != null)
				{
					mModels[assetname] = model;
				}
			}
			if (model != null)
			{
				Quaternion r = model.transform.localRotation;
				Vector3 p = model.transform.localPosition;
				Vector3 s = model.transform.localScale;
				mModel = Object.Instantiate(model);
				mModel.transform.parent = base.transform;
				mModel.transform.localRotation = r;
				mModel.transform.localScale = s;
				mModel.transform.localPosition = p;
			}
		}
		else if (mModel != null)
		{
			EnemyLeveledWeapon.ReloadMaterials(mModel);
		}
		yield break;
	}

	public void DestroyModel()
	{
		Object.Destroy(mModel);
		mModel = null;
	}

	public static void ClearModels()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, GameObject> mModel in mModels)
		{
			list.Add(mModel.Key);
		}
		foreach (string item in list)
		{
			mModels[item] = null;
		}
		mModels.Clear();
	}

	public virtual void UpdateWeapon()
	{
	}

	public virtual void MouseUpAndNoUpdate()
	{
	}

	public virtual void ShootForBot(Vector3 position)
	{
	}

	protected void ShakeCamera()
	{
		if (playerController.isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.ShootShake();
		}
	}

	protected void PlayTouchCircle(Vector3 shootPosition)
	{
		if (playerController.isCurrentPlayer && Singleton<GameController>.instance.gameIsRunning)
		{
			GuiScreenSingle<HudScreen>.instance.PlayTouchCircleSmall(shootPosition);
		}
	}

	protected bool CanShootAngle(Vector3 pos)
	{
		return Vector3.Angle(playerController.aimForward, pos - playerController.transform.position) < 95f || !playerController.isCurrentPlayer;
	}

	public bool IsLoaded()
	{
		return mModel != null;
	}
}
