using System;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMeshChanger : Core_BaseScript
{
	[Serializable]
	public class SoldierStyle
	{
		[SerializeField]
		public Mesh helmetMesh;

		public List<Material> helmetMaterials;

		[SerializeField]
		private string mModelPath;

		public Material transparentMaterial;

		public SkinnedMeshRenderer modelMeshRenderer { get; private set; }

		public void LoadPaths()
		{
		}

		public void LoadModel()
		{
			if (!(modelMeshRenderer == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					modelMeshRenderer = componentsInChildren[0];
				}
			}
		}

		public void UnloadModel()
		{
			if (modelMeshRenderer != null)
			{
				Resources.UnloadAsset(modelMeshRenderer.sharedMesh);
			}
			modelMeshRenderer = null;
		}
	}

	public SkinnedMeshRenderer skinnedMeshRenderer;

	public FakeRigidBodySwapper helmet;

	public ModelAttachments helmetAttachments;

	public ModelAttachments bodyAttachemnts;

	public MeshRenderer powerband;

	public MeshFilter hair;

	private List<SoldierStyle> mSoldierStyles;

	private int mIndex;

	private bool mIsInvisible;

	public Material material => skinnedMeshRenderer.materials[0];

	public void SetSoldierStyle(List<SoldierStyle> soldierStyles)
	{
		mIndex = UnityEngine.Random.Range(0, soldierStyles.Count);
		mSoldierStyles = soldierStyles;
		SoldierStyle soldierStyle = soldierStyles[mIndex];
		SkinnedMeshTools.ChangeSkins(soldierStyle.modelMeshRenderer, skinnedMeshRenderer);
		if (soldierStyle.helmetMaterials != null && soldierStyle.helmetMaterials.Count > 0)
		{
			helmet.SetMesh(soldierStyle.helmetMesh, soldierStyle.helmetMaterials);
		}
		else
		{
			helmet.SetMesh(soldierStyle.helmetMesh);
		}
	}

	private void OnEnable()
	{
		skinnedMeshRenderer.quality = ((Singleton<GameController>.instance.gameState == GameController.GameState.Playing) ? SkinQuality.Bone1 : SkinQuality.Bone2);
	}

	public void SetSoldierVisual(List<TechnologyVisualDefinition> currentVisuals, bool mine)
	{
		powerband.gameObject.SetActive(value: false);
		if (currentVisuals.Count > 0 && currentVisuals[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition = currentVisuals[0];
			skinnedMeshRenderer.materials[0].mainTexture = ((!mine) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
			skinnedMeshRenderer.materials[0].SetTexture("_MatCap", Singleton<MatCapTextures>.instance.GetMatCap());
			bodyAttachemnts.HideAllAttachments();
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
			{
				if (visualSlotMesh.partRed != null && !mine)
				{
					bodyAttachemnts.AddAttachment(visualSlotMesh.partRed, visualSlotMesh.visualSlotId);
				}
				else if (visualSlotMesh.part != null)
				{
					bodyAttachemnts.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId);
				}
			}
		}
		if (currentVisuals.Count <= 1 || currentVisuals[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition2 = currentVisuals[1];
		helmet.SetTexture((!mine) ? technologyVisualDefinition2.materialTetxureRed : technologyVisualDefinition2.materialTetxureBlue);
		helmet.SetMatCapTexture(Singleton<MatCapTextures>.instance.GetMatCap());
		helmetAttachments.HideAllAttachments();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
		{
			if (visualSlotMesh2.partRed != null && !mine)
			{
				helmetAttachments.AddAttachment(visualSlotMesh2.partRed, visualSlotMesh2.visualSlotId);
			}
			else if (visualSlotMesh2.part != null)
			{
				helmetAttachments.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId);
			}
		}
	}

	public void NullTexturesAndMeshes()
	{
		skinnedMeshRenderer.materials[0].mainTexture = null;
		skinnedMeshRenderer.materials[0].SetTexture("_MatCap", null);
		helmet.SetTexture(null);
		helmet.SetMatCapTexture(null);
		skinnedMeshRenderer.sharedMesh = null;
		helmet.SetMesh(null);
	}

	public void ChangeCamo(SkinnedMeshRenderer rendererFrom, Texture2D texture)
	{
		SkinnedMeshTools.ChangeSkins(rendererFrom, skinnedMeshRenderer);
		skinnedMeshRenderer.materials[0].mainTexture = texture;
		skinnedMeshRenderer.materials[0].SetTexture("_MatCap", Singleton<MatCapTextures>.instance.GetMatCap());
		hair.GetComponent<MeshRenderer>().materials[0].mainTexture = texture;
	}

	public void ChangeHelmet(PlayerVisualCategoryHelmets.PlayerVisualHelmet playerVisualHelmet)
	{
		MeshFilter component = playerVisualHelmet.GetMesh().GetComponent<MeshFilter>();
		helmet.SetMesh(component.sharedMesh);
		helmet.SetMaterials(playerVisualHelmet.GetMesh().sharedMaterials);
	}

	public void ChangeHelmetAttachment(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory playerVisualHeadAccesory)
	{
		helmetAttachments.HideAllAttachments();
		helmetAttachments.AddAttachment(playerVisualHeadAccesory.GetMesh(), playerVisualHeadAccesory.visualSlotId);
	}

	public void ChangeHair(PlayerVisualCategoryCamos.PlayerVisualCamo camo, int index)
	{
		Mesh hairMesh = camo.GetHairMesh(index);
		if (hairMesh != null)
		{
			hair.sharedMesh = hairMesh;
			hair.gameObject.SetActive(value: true);
		}
		else
		{
			hair.gameObject.SetActive(value: false);
		}
	}

	public void ChangePowerBand(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand playerVisualPowerBand)
	{
		powerband.gameObject.SetActive(playerVisualPowerBand.texture != null);
		powerband.material.mainTexture = playerVisualPowerBand.texture;
	}

	public void ChangeMaterial(Material m)
	{
		skinnedMeshRenderer.sharedMaterial = m;
	}
}
