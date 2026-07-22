using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Drag Panel Contents")]
[ExecuteInEditMode]
public class UIDragPanelContents : MonoBehaviour
{
	public UIDraggablePanel draggablePanel;

	[HideInInspector]
	[SerializeField]
	private UIPanel panel;

	private void Awake()
	{
		if (!(panel != null))
		{
			return;
		}
		if (draggablePanel == null)
		{
			draggablePanel = panel.GetComponent<UIDraggablePanel>();
			if (draggablePanel == null)
			{
				draggablePanel = panel.gameObject.AddComponent<UIDraggablePanel>();
			}
		}
		panel = null;
	}

	private void Start()
	{
		if (draggablePanel == null)
		{
			draggablePanel = NGUITools.FindInParents<UIDraggablePanel>(base.gameObject);
		}
	}

	private void OnPress(bool pressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && !(draggablePanel != null))
		{
		}
	}

	private void OnDrag(Vector2 delta)
	{
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
	}

	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && draggablePanel != null)
		{
			draggablePanel.Scroll(delta);
		}
	}
}
