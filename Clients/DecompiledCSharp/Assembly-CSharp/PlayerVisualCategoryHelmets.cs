using System;
using UnityEngine;

public class PlayerVisualCategoryHelmets : PlayerVisualCategoryGeneric<PlayerVisualCategoryHelmets.PlayerVisualHelmet>
{
	[Serializable]
	public class PlayerVisualHelmet : PlayerVisualHead
	{
		public int hairIndex;

		public override void ApplyVisual(ICharacter player, bool useHighRes = false)
		{
			base.ApplyVisual(player, useHighRes);
			player.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				player.equippedHelmet = this;
				CamoTransform value = null;
				string text = player.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.SetTransform(player.meshChanger.helmet.rigidBody.meshFilter.gameObject, value);
				CamoTransform.SetTransform(player.meshChanger.helmet.noRigidBody.meshFilter.gameObject, value);
			}
		}
	}
}
