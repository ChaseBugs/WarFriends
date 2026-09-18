using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Draggable Panel with paralax")]
[RequireComponent(typeof(UIPanel))]
public class UIDraggablePanelWithScale : UIDraggablePanel
{
	public Transform additionalTransform;

	public float additionalTransformSpeed = 0.01f;

	public override void MoveRelative(Vector3 relative)
	{
		if (additionalTransform == null)
		{
			base.MoveRelative(relative);
			return;
		}
		mTrans.localPosition += relative;
		additionalTransform.localPosition += relative * additionalTransformSpeed;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= relative.x;
		clipRange.y -= relative.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}
}
