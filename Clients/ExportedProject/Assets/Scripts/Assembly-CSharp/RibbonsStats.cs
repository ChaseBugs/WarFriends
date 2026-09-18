using System.Collections.Generic;
using UnityEngine;

public class RibbonsStats : Core_BaseScript
{
	[Header("Empty")]
	public UIPanel emptyPanel;

	public UILabel emptyLabel;

	[Header("Core")]
	public RibbonGuiRecord ribbonGuiRecordPrefab;

	public int maxRibbons = 18;

	public UIDraggablePanel ribbonDraggablePanel;

	public UIPooledGrid ribbonsGrid;

	private List<Tuple<RibbonManager.RibbonItemDefinition, int>> mRibbons = new List<Tuple<RibbonManager.RibbonItemDefinition, int>>();

	public void Animate(bool showTab, bool instant)
	{
		if (showTab && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(emptyPanel.gameObject, (!instant) ? (GuiScreenSingle<PlayerStatsScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f);
			TweenAlpha.Begin(ribbonDraggablePanel.gameObject, (!instant) ? (GuiScreenSingle<PlayerStatsScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!showTab)
		{
			InstantHideTab();
		}
	}

	public void InitControls()
	{
		SetSizes();
	}

	public void InitGUIValues()
	{
		CreateDataRibbons();
		emptyLabel.gameObject.SetActive(mRibbons.Count == 0);
		ShowRibbons();
	}

	public void DoAfterHide()
	{
		ribbonsGrid.MakeEmpty();
		mRibbons.Clear();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = ribbonDraggablePanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void CreateDataRibbons()
	{
		mRibbons.Clear();
		foreach (KeyValuePair<RibbonManager.RibbonItemDefinition, int> allTimeRibbon in StatsManager.instance.GetAllTimeRibbons())
		{
			int value = allTimeRibbon.Value;
			if (value > 0)
			{
				mRibbons.Add(new Tuple<RibbonManager.RibbonItemDefinition, int>(allTimeRibbon.Key, value));
			}
		}
	}

	private void ShowRibbons()
	{
		if (GuiScreenSingle<PlayerStatsScreen>.instance.isShowed && base.gameObject.activeSelf)
		{
			ribbonsGrid.MakeEmpty();
			ribbonsGrid.init(mRibbons.Count, RibbonInstantiate, RibbonFree, ribbonDraggablePanel);
			ribbonDraggablePanel.UpdateScrollbars(recalculateBounds: true);
			ribbonDraggablePanel.AlignToPos(instant: true);
		}
	}

	private Transform RibbonInstantiate(int index)
	{
		if (index >= 0 && index < mRibbons.Count)
		{
			RibbonGuiRecord ribbonGuiRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(ribbonGuiRecordPrefab, ribbonsGrid.gameObject, "Ribbon Record " + (index + 1).ToString("D2")) as RibbonGuiRecord;
			if (ribbonGuiRecord != null)
			{
				ribbonGuiRecord.Initialize(mRibbons[index].Value1, mRibbons[index].Value2, showMoney: false);
				return ribbonGuiRecord.transform;
			}
		}
		return null;
	}

	private void RibbonFree(Transform obj)
	{
		if (!(obj == null))
		{
			RibbonGuiRecord component = obj.GetComponent<RibbonGuiRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void SetSizes()
	{
		float num = UIRoot.list[0].activeHeight;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num2 = activeWidth - 120f;
		float num3 = num2 / 2f;
		float num4 = num - GuiScreenSingle<PlayerStatsScreen>.instance.headerHeight;
		float y = num / 2f - GuiScreenSingle<PlayerStatsScreen>.instance.headerHeight - num4 / 2f;
		float num5 = 570f;
		int num6 = Mathf.CeilToInt(num / 410f) + 2;
		int a = maxRibbons / num6;
		int b = Mathf.FloorToInt(num2 / num5);
		int num7 = Mathf.Min(a, b);
		float num8 = (num2 - (float)num7 * num5) / (float)Mathf.Max(1, num7 - 1);
		UIPanel component = ribbonDraggablePanel.gameObject.GetComponent<UIPanel>();
		if (component != null)
		{
			component.clipRange = new Vector4(component.clipRange.x, y, component.clipRange.z, num4);
		}
		BoxCollider component2 = ribbonDraggablePanel.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.center = new Vector3(component2.center.x, y, component2.center.z);
			component2.size = new Vector3(component2.size.x, num4, component2.size.z);
		}
		ribbonDraggablePanel.transform.localPosition = Vector3.zero;
		ribbonsGrid.maxPerLine = num7;
		ribbonsGrid.cellWidth = num5 + num8;
		ribbonsGrid.transform.localPosition = new Vector3(0f - num3 + num5 / 2f, ribbonsGrid.transform.localPosition.y, 0f);
	}
}
