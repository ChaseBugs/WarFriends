using System;
using UnityEngine;

public class PlayerVisualCategoryHeadAccesories : PlayerVisualCategoryGeneric<PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory>
{
	[Serializable]
	public class PlayerVisualHeadAccesory : PlayerVisualHead
	{
		public int visualSlotId;

		public override void ApplyVisual(ICharacter character, bool useHighRes = false)
		{
			base.ApplyVisual(character, useHighRes);
			character.meshChanger.ChangeHelmetAttachment(this);
			if (!Application.isPlaying)
			{
				return;
			}
			character.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = character.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment modelAttachment in character.meshChanger.helmetAttachments.modelAttachments)
			{
				if (modelAttachment.mPrefab == base.mesh)
				{
					CamoTransform.SetTransform(modelAttachment.mInstance.gameObject, value);
				}
			}
		}
	}
}
