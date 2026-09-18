using UnityEngine;

[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Draggable Panel restrict top left")]
[ExecuteInEditMode]
public class UIDraggablePanelRestrictTopLeft : UIDraggablePanel
{
	private bool smallContent
	{
		get
		{
			if (base.panel == null)
			{
				base.panel = GetComponent<UIPanel>();
			}
			Vector4 clipRange = base.panel.clipRange;
			Bounds bounds = base.bounds;
			float x = ((clipRange.z != 0f) ? clipRange.z : ((float)Screen.width));
			float y = ((clipRange.w != 0f) ? clipRange.w : ((float)Screen.height));
			Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
			vector.Scale(scale);
			Vector3 vector2 = new Vector3(x, y, 0f);
			vector2.Scale(scale);
			return vector.x < vector2.x || vector.y < vector2.y;
		}
	}

	public override bool RestrictWithinBounds(bool instant)
	{
		if (smallContent)
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 0.001f)
			{
				if (!instant && dragEffect == DragEffect.MomentumAndSpring)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 13f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(instant: false);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 13f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 0f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(instant: false);
			}
			return false;
		}
		return base.RestrictWithinBounds(instant);
	}
}
