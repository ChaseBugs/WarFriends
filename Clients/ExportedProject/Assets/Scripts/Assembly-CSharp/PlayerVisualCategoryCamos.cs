using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualCategoryCamos : PlayerVisualCategoryGeneric<PlayerVisualCategoryCamos.PlayerVisualCamo>
{
	[Serializable]
	public class PlayerVisualCamo : PlayerVisual
	{
		[SerializeField]
		private string modelPath;

		[SerializeField]
		private string previewModelPath;

		[SerializeField]
		private string camoTexturePath;

		[SerializeField]
		private string camoTextureSmallPath;

		private SkinnedMeshRenderer mMeshBody;

		private SkinnedMeshRenderer mPreviewMeshBody;

		private Texture2D mCamoTexture;

		private Texture2D mCamoTextureSmall;

		private List<MeshFilter> hairMeshes;

		public override void ApplyVisual(ICharacter character, bool useHighRes = false)
		{
			base.ApplyVisual(character, useHighRes);
			character.meshChanger.ChangeCamo((!useHighRes) ? GetPreviewMeshBody() : GetMeshBody(), (!useHighRes) ? GetTextureSmall() : GetTexture());
			if (Application.isPlaying)
			{
				if (character.equippedCamo != null && character.equippedCamo != this && useHighRes)
				{
					character.equippedCamo.UnloadBigTexture();
					character.equippedCamo.UnloadMesh();
				}
				character.equippedCamo = this;
				if (character.equippedHelmet != null)
				{
					character.equippedHelmet.ApplyVisual(character);
				}
				if (character.equippedHeadAccesory != null)
				{
					character.equippedHeadAccesory.ApplyVisual(character);
				}
				if (character.equippedPowerBand != null)
				{
					character.equippedPowerBand.ApplyVisual(character);
				}
			}
		}

		private void GetHairModels(GameObject model)
		{
			MeshFilter[] componentsInChildren = model.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			hairMeshes = new List<MeshFilter>();
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				if (meshFilter.name.Contains("hair"))
				{
					hairMeshes.Add(meshFilter);
				}
			}
			hairMeshes.Sort((MeshFilter x, MeshFilter y) => x.name.CompareTo(y.name));
		}

		public SkinnedMeshRenderer GetMeshBody()
		{
			if (mMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(modelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mMeshBody = componentsInChildren[0];
						mMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError($"PlayerVisualCamo Error - SkinnedMeshRenderer count is 0 at {modelPath}!");
					}
				}
				else
				{
					Debug.LogError($"Camo load error: {modelPath}");
				}
				GetHairModels(gameObject);
			}
			return mMeshBody;
		}

		public SkinnedMeshRenderer GetPreviewMeshBody()
		{
			if (mPreviewMeshBody == null)
			{
				GameObject gameObject = Resources.Load<GameObject>(previewModelPath);
				if (gameObject != null)
				{
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
					if (componentsInChildren.Length == 1)
					{
						mPreviewMeshBody = componentsInChildren[0];
						mPreviewMeshBody.sharedMaterial.mainTexture = null;
					}
					else
					{
						Debug.LogError($"PlayerVisualCamo Error - SkinnedMeshRenderer count is 0 at {previewModelPath}!");
					}
				}
				else
				{
					Debug.LogError($"Camo load error: {previewModelPath}");
				}
				GetHairModels(gameObject);
			}
			return mPreviewMeshBody;
		}

		public override void Null()
		{
			base.Null();
			mMeshBody = null;
			mPreviewMeshBody = null;
			mCamoTextureSmall = null;
			mCamoTexture = null;
			hairMeshes = null;
		}

		public override void Load()
		{
			base.Load();
			GetPreviewMeshBody();
			GetTextureSmall();
		}

		public Texture2D GetTexture()
		{
			if (mCamoTexture == null)
			{
				mCamoTexture = Resources.Load<Texture2D>(camoTexturePath);
			}
			return mCamoTexture;
		}

		public Texture2D GetTextureSmall()
		{
			if (mCamoTextureSmall == null)
			{
				mCamoTextureSmall = Resources.Load<Texture2D>(camoTextureSmallPath);
			}
			return mCamoTextureSmall;
		}

		public Mesh GetHairMesh(int index)
		{
			if (hairMeshes != null && index < hairMeshes.Count)
			{
				return hairMeshes[index].sharedMesh;
			}
			return null;
		}

		private void UnloadBigTexture()
		{
			Resources.UnloadAsset(mCamoTexture);
		}

		private void UnloadMesh()
		{
			if (mMeshBody != null)
			{
				Resources.UnloadAsset(mMeshBody.sharedMesh);
			}
			mMeshBody = null;
		}

		public override void LoadPathsForEditor()
		{
			base.LoadPathsForEditor();
		}
	}
}
