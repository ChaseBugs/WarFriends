using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
[AddComponentMenu("NGUI/Interaction/Draggable Panel with paralax")]
public class UIDraggablePanelAlignToBottom : UIDraggablePanel
{
	public override bool RestrictWithinBounds(bool instant)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
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
					AlignToPos(instant: false, Alingment.BottomRight);
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
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight);
		}
		return false;
	}
}
