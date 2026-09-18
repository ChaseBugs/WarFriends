using System.Collections.Generic;
using UnityEngine;

public class VehicleVisuals : Core_BaseScript
{
	public ModelAttachments modelAttachments;

	public Renderer mainRenderer;

	public List<MeshRenderer> renderedParts;

	public void SetVisuals(List<TechnologyVisualDefinition> currentVisuals, bool mine)
	{
		if (currentVisuals.Count <= 0 || currentVisuals[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition = currentVisuals[0];
		mainRenderer.material.mainTexture = ((!mine) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
		mainRenderer.material.SetTexture("_MatCap", Singleton<MatCapTextures>.instance.GetMatCap());
		modelAttachments.HideAllAttachments();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
		{
			if (visualSlotMesh.part != null)
			{
				modelAttachments.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId, mainRenderer.material);
			}
		}
		foreach (MeshRenderer renderedPart in renderedParts)
		{
			renderedPart.sharedMaterial = mainRenderer.material;
		}
		if (currentVisuals.Count > 1 && currentVisuals[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition2 = currentVisuals[1];
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
			{
				if (visualSlotMesh2.part != null)
				{
					modelAttachments.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId, mainRenderer.material);
				}
			}
		}
		if (currentVisuals.Count <= 2 || currentVisuals[2] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition3 = currentVisuals[2];
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh3 in technologyVisualDefinition3.visualSlotMeshes)
		{
			if (visualSlotMesh3.part != null)
			{
				modelAttachments.AddAttachment(visualSlotMesh3.part, visualSlotMesh3.visualSlotId, mainRenderer.material);
			}
		}
	}

	public void ChangeMaterial(Material material)
	{
		mainRenderer.material = material;
		foreach (MeshRenderer renderedPart in renderedParts)
		{
			renderedPart.sharedMaterial = material;
		}
		modelAttachments.SetAttachmentsMaterial(material);
	}

	public void NullTextures()
	{
		mainRenderer.material.mainTexture = null;
		mainRenderer.material.SetTexture("_MatCap", null);
		modelAttachments.NullTextures();
	}
}
