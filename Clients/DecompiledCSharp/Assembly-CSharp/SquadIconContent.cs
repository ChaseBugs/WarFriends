using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SquadIconContent : Core_BaseScript
{
	public enum EmblemType
	{
		Basic,
		Country
	}

	public class SquadEmblemIcon
	{
		public string iconName;

		public int unlockLevel;

		public EmblemType type;

		public SquadEmblemIcon(string ico, int level, string typ)
		{
			iconName = ico;
			unlockLevel = level;
			type = ((typ == "Country") ? EmblemType.Country : EmblemType.Basic);
		}

		public override string ToString()
		{
			return string.Format("{0} Emblem {1} LVL {2}", ((type != EmblemType.Basic) ? "Z " : string.Empty) + type, iconName, unlockLevel);
		}
	}

	[Header("Squad Emblems List")]
	public UIPanel panel;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid emblemGrid;

	public SquadEmblemRecord squadEmblemRecordPrefab;

	public int maxEmblems = 40;

	private bool mIsActive;

	private SquadEmblemRecord mSelectedEmblem;

	private List<SquadEmblemIcon> mIcons = new List<SquadEmblemIcon>();

	private string mSelectedEmblemName;

	private int mSquadDisplayLevel;

	private EmblemType SquadEmblemType(int index)
	{
		index = Mathf.Clamp(index, 0, Singleton<GameVariables>.instance.squadEmblems.Rows.Count);
		if (Singleton<GameVariables>.instance.squadEmblems.Rows[index].TYPE == "Country")
		{
			return EmblemType.Country;
		}
		return EmblemType.Basic;
	}

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		mIsActive = false;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		int num2 = UIRoot.list[0].activeHeight - 470;
		Vector4 clipRange = panel.clipRange;
		clipRange.x = activeWidth / 2f;
		clipRange.y = (float)(-num2) / 2f;
		clipRange.z = activeWidth;
		clipRange.w = num2;
		panel.clipRange = clipRange;
		draggablePanel.transform.localPosition = new Vector3(draggablePanel.transform.localPosition.x, 0f, draggablePanel.transform.localPosition.z);
		int num3 = Mathf.CeilToInt(num / 290f) + 2;
		int a = maxEmblems / num3;
		float num4 = activeWidth - 120f + 26f;
		int b = Mathf.FloorToInt(num4 / 290f);
		int num5 = Mathf.Min(a, b);
		float num6 = (num4 - (float)num5 * 290f) / (float)Mathf.Max(1, num5 - 1);
		emblemGrid.maxPerLine = num5;
		emblemGrid.cellWidth = 290f + num6;
		emblemGrid.offsetGrid = new Vector2(0f, 0f);
	}

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(panel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	public void InitGUIValues()
	{
		HideEmblems();
		CreateEmblems();
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		mSquadDisplayLevel = squad.rank;
		string icon = squad.icon;
		bool flag = false;
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.ICONNAME == icon)
			{
				flag = true;
				mSelectedEmblemName = row.ICONNAME;
				break;
			}
		}
		if (!flag)
		{
			Debug.LogError("Unknown squad icon!");
		}
		ShowEmblems();
	}

	public void DoAfterHide()
	{
		HideEmblems();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = panel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void CreateEmblems()
	{
		mIcons.Clear();
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			mIcons.Add(new SquadEmblemIcon(row.ICONNAME, row.UNLOCKLEVEL, row.TYPE));
		}
		mIcons.Sort(SortEmblems);
	}

	private int SortEmblems(SquadEmblemIcon a, SquadEmblemIcon b)
	{
		if (a.type != b.type)
		{
			return (a.type != EmblemType.Basic) ? 1 : (-1);
		}
		if (a.unlockLevel != b.unlockLevel)
		{
			return a.unlockLevel.CompareTo(b.unlockLevel);
		}
		return a.iconName.CompareTo(b.iconName);
	}

	private void HideEmblems()
	{
		emblemGrid.MakeEmpty();
	}

	public void ShowEmblems()
	{
		HideEmblems();
		emblemGrid.init(Singleton<GameVariables>.instance.squadEmblems.Rows.Count, EmblemInstantiate, EmblemFree, draggablePanel);
		draggablePanel.AlignToCenter(emblemGrid.transform.localPosition + emblemGrid.getPositionForIndex(0), instant: true);
		emblemGrid.PositionChanged();
	}

	private Transform EmblemInstantiate(int index)
	{
		if (index >= 0 && index < mIcons.Count)
		{
			SquadEmblemRecord squadEmblemRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadEmblemRecordPrefab, emblemGrid.gameObject, mIcons[index].ToString()) as SquadEmblemRecord;
			if (squadEmblemRecord != null)
			{
				squadEmblemRecord.Initialize(mIcons[index].iconName, mSquadDisplayLevel, mIcons[index].unlockLevel);
				if (mIcons[index].iconName == mSelectedEmblemName)
				{
					mSelectedEmblem = squadEmblemRecord;
					squadEmblemRecord.Highlight(highlight: true);
				}
				return squadEmblemRecord.transform;
			}
		}
		return null;
	}

	private void EmblemFree(Transform obj)
	{
		if (obj != null)
		{
			SquadEmblemRecord component = obj.GetComponent<SquadEmblemRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public void UseEmblemClick(SquadEmblemRecord record)
	{
		if (!(record == null) && !(record.squadIconName == mSelectedEmblemName))
		{
			if (mSelectedEmblem != null && mSelectedEmblem.isInstantiated && mSelectedEmblem.squadIconName == mSelectedEmblemName)
			{
				mSelectedEmblem.Highlight(highlight: false);
			}
			Debug.Log("Updating squad emblem from: " + ((!(mSelectedEmblem == null)) ? mSelectedEmblem.squadIconName : "null") + " to: " + record.squadIconName);
			Singleton<BeanstalkServerManager>.instance.UpdateEmblem(record.squadIconName);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Change_Emblem");
			mSelectedEmblem = record;
			mSelectedEmblemName = mSelectedEmblem.squadIconName;
			mSelectedEmblem.Highlight(highlight: true);
			GuiScreenSingle<SquadScreen>.instance.SetSquadIcon(mSelectedEmblemName);
		}
	}
}
