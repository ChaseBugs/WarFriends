using System.Collections.Generic;
using UnityEngine;

public class UISimpleHider : MonoBehaviour
{
	private float _alpha = 1f;

	public float Alpha;

	public List<UIWidget> mWidgets;

	private List<UISimpleHider> childAlphaPanels;

	private bool wasInitialised;

	public float alpha
	{
		get
		{
			return _alpha;
		}
		set
		{
			if (_alpha != value)
			{
				_alpha = value;
				Alpha = value;
				UpdateAlpha();
			}
		}
	}

	private void Awake()
	{
		if (!wasInitialised)
		{
			Initialize();
		}
	}

	public void Initialize()
	{
		wasInitialised = true;
		mWidgets = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: true));
		if (mWidgets.Count == 0)
		{
			base.enabled = false;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget mWidget in mWidgets)
		{
			if (mWidget.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(mWidget);
			}
		}
		foreach (UIWidget item in list)
		{
			mWidgets.Remove(item);
		}
		childAlphaPanels = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: true));
		childAlphaPanels.Remove(this);
		UpdateAlpha();
	}

	private void OnEnable()
	{
		UpdateAlpha();
	}

	private void UpdateAlpha()
	{
		if (!wasInitialised)
		{
			Initialize();
		}
		int i = 0;
		for (int count = mWidgets.Count; i < count; i++)
		{
			UIWidget uIWidget = mWidgets[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = alpha;
			}
		}
	}
}
