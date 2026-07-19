using System;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Button Sound")]
public class UIButtonSound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick = 0,
		OnMouseOver = 1,
		OnMouseOut = 2,
		OnPress = 3,
		OnRelease = 4
	}

	public AudioClip audioClip;

	public Trigger trigger;

	public float volume = 1f;

	public float pitch = 1f;

	[Header("Conditions")]
	public UIButton uiButton;

	public GameObject lockedPart;

	public GameObject enabledPart;

	public static Action onClicked;

	private void OnHover(bool isOver)
	{
		if (base.enabled && (!isOver || trigger != Trigger.OnMouseOver) && !isOver && trigger != Trigger.OnMouseOut)
		{
		}
	}

	private void OnPress(bool isPressed)
	{
		if (base.enabled && (!isPressed || trigger != Trigger.OnPress) && !isPressed && trigger != Trigger.OnRelease)
		{
		}
	}

	private void OnClick()
	{
		if (base.enabled && trigger == Trigger.OnClick && onClicked != null && (uiButton == null || uiButton.isEnabled) && (lockedPart == null || !lockedPart.activeInHierarchy) && (enabledPart == null || enabledPart.activeInHierarchy))
		{
			onClicked();
		}
	}
}
