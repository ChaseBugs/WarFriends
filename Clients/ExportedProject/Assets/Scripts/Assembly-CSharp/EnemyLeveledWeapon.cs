using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeveledWeapon : Core_BaseScript
{
	[Serializable]
	public class WeaponModelRecord
	{
		public int level;

		public Sounds3DEnum shotSound = Sounds3DEnum.SHOT_ASSAULT_1;

		public string weaponModelPath;

		public string assetBundleName;

		public Vector3 scale = Vector3.one;

		public void Generate()
		{
		}
	}

	private static Dictionary<string, GameWeaponModel> mLoadedModels = new Dictionary<string, GameWeaponModel>();

	public List<WeaponModelRecord> weaponRecords;

	public MeshRenderer weaponRenderer;

	public Weapon weapon;

	public void SetLevel(int level, bool highPoly = false)
	{
		foreach (WeaponModelRecord weaponRecord in weaponRecords)
		{
			if (level != weaponRecord.level)
			{
				continue;
			}
			if (weapon != null)
			{
				weapon.shotSound = weaponRecord.shotSound;
			}
			if (mLoadedModels.TryGetValue(weaponRecord.weaponModelPath, out var value))
			{
				weaponRenderer.sharedMaterial = value.GetComponent<Renderer>().sharedMaterial;
				weaponRenderer.GetComponent<MeshFilter>().sharedMesh = value.GetComponent<MeshFilter>().sharedMesh;
				weaponRenderer.useLightProbes = true;
				weaponRenderer.transform.localPosition = -value.pivot.transform.localPosition;
				weaponRenderer.transform.localScale = weaponRecord.scale;
				ReloadMaterials(weaponRenderer.gameObject);
			}
			else
			{
				if (!mLoadedModels.ContainsKey(weaponRecord.weaponModelPath))
				{
					break;
				}
				SetLevel(level);
			}
		}
	}

	public static void ClearModels()
	{
		mLoadedModels.Clear();
	}

	private string GetWeaponPath(int level)
	{
		foreach (WeaponModelRecord weaponRecord in weaponRecords)
		{
			if (level == weaponRecord.level)
			{
				return weaponRecord.weaponModelPath;
			}
		}
		return string.Empty;
	}

	public void UnloadModels(int weaponNumber)
	{
		string weaponPath = GetWeaponPath(weaponNumber);
		GameWeaponModel gameWeaponModel = null;
		foreach (KeyValuePair<string, GameWeaponModel> mLoadedModel in mLoadedModels)
		{
			if (weaponPath != mLoadedModel.Key)
			{
				Material sharedMaterial = mLoadedModel.Value.GetComponent<Renderer>().sharedMaterial;
				Mesh sharedMesh = mLoadedModel.Value.GetComponent<MeshFilter>().sharedMesh;
				Resources.UnloadAsset(sharedMesh);
				Resources.UnloadAsset(sharedMaterial.mainTexture);
				Resources.UnloadAsset(sharedMaterial);
			}
			else
			{
				gameWeaponModel = mLoadedModel.Value;
			}
		}
		ClearModels();
		if (gameWeaponModel != null)
		{
			mLoadedModels[weaponPath] = gameWeaponModel;
		}
	}

	private void OnDisable()
	{
		weaponRenderer.sharedMaterial = null;
		weaponRenderer.GetComponent<MeshFilter>().sharedMesh = null;
	}

	public IEnumerator PrepareAsync(int level)
	{
		foreach (WeaponModelRecord record in weaponRecords)
		{
			if (level != record.level)
			{
				continue;
			}
			if (!mLoadedModels.ContainsKey(record.weaponModelPath))
			{
				string bundle = "Weapons/" + record.assetBundleName;
				string assetname = record.weaponModelPath.Split('/')[1];
				string path = bundle + "/" + assetname;
				GameObject model = Resources.Load<GameObject>(path);
				if (model != null)
				{
					GameWeaponModel c = model.GetComponent<GameWeaponModel>();
					mLoadedModels[record.weaponModelPath] = c;
					ReloadMaterials(model.gameObject);
				}
				Singleton<SoundsManager3D>.instance.UseSound(record.shotSound);
			}
			break;
		}
		yield break;
	}

	public static void ReloadMaterials(GameObject obj)
	{
		Material sharedMaterial = obj.GetComponent<Renderer>().sharedMaterial;
		Mesh sharedMesh = obj.GetComponent<MeshFilter>().sharedMesh;
		Texture mainTexture = sharedMaterial.mainTexture;
		int width = mainTexture.width;
		sharedMaterial.mainTexture = null;
		sharedMaterial.mainTexture = mainTexture;
	}
}
