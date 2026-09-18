using System.Collections;
using UnityEngine;

internal class GuiRoot : Core_BaseGlobalScript
{
	public bool _startRunned;

	public static GuiRoot Instance { get; private set; }

	protected override void Awake()
	{
		Instance = this;
		base.Awake();
	}

	private void OnLevelWasLoaded(int x)
	{
		if (_startRunned)
		{
			StartCoroutine(waitAndFade());
		}
	}

	private IEnumerator waitAndFade()
	{
		yield return new WaitForSeconds(0.2f);
		Singleton<GuiManager>.instance.HideOverlay();
	}

	protected override void Start()
	{
		base.Start();
		_startRunned = true;
	}
}
