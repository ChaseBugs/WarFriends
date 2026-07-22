using System;
using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
	public enum Trigger
	{
		OnClick,
		OnMouseOver,
		OnMouseOut,
		OnPress,
		OnRelease
	}

	public AudioClip audioClip;

	public Trigger trigger;

	public float volume;

	public float pitch;

	public UIButton uiButton;

	public GameObject lockedPart;

	public GameObject enabledPart;

	public static Action onClicked;

	private void OnHover(bool isOver)
	{
	}

	private void OnPress(bool isPressed)
	{
	}

	private void OnClick()
	{
	}

	public void PlaySound()
	{
	}
}
