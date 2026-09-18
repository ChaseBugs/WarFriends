using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadEventContent : Core_BaseScript
{
	public class SquadEventRecordInternal
	{
		public bool isHeader;

		public int reward;

		public int tierNumber;

		public Assignment assignment;

		public float progress;

		public float length;

		public bool active;

		public static SquadEventRecordInternal CreateHeader(int reward, int tier, float progress, float length, bool active)
		{
			SquadEventRecordInternal squadEventRecordInternal = new SquadEventRecordInternal();
			squadEventRecordInternal.isHeader = true;
			squadEventRecordInternal.reward = reward;
			squadEventRecordInternal.tierNumber = tier;
			squadEventRecordInternal.progress = progress;
			squadEventRecordInternal.length = length;
			squadEventRecordInternal.active = active;
			squadEventRecordInternal.assignment = null;
			return squadEventRecordInternal;
		}

		public static SquadEventRecordInternal CreateAssignment(int id, float progress, float length, bool active, string param, int target, float levelProgress)
		{
			SquadEventRecordInternal squadEventRecordInternal = new SquadEventRecordInternal();
			squadEventRecordInternal.isHeader = false;
			squadEventRecordInternal.assignment = Assignment.CreateAssignment(new AssignmentsManager.DatabaseAssignment(id, target), isSquadEvent: true, param, levelProgress);
			squadEventRecordInternal.progress = progress;
			squadEventRecordInternal.length = length;
			squadEventRecordInternal.active = active;
			return squadEventRecordInternal;
		}
	}

	public UIPanel panelMain;

	[Header("Joining Wait")]
	public GameObject waitPart;

	[Header("Join Event")]
	public GameObject signToEvent;

	public UIButton joinEventButton;

	public UILabel lengthLabel1;

	public UISprite spriteToSet1;

	[Header("No Event At The Moment")]
	public GameObject noEventGO;

	public UILabel lengthLabel2;

	public UISprite spriteToSet2;

	[Header("Event Progress")]
	public GameObject eventProgressPart;

	[Header("-Header")]
	public UILabel tierProgress;

	public GameObject leftPart;

	public UITable leftTopTable;

	public WinStreakCounter eventTime;

	public GameObject endSpacer;

	[Header("-List of Assignments")]
	public UIPanel panel;

	public UIDraggablePanel draggablePanel;

	public SquadEventRecord squadEventRecordPrefab;

	public UIPooledGrid grid;

	[Header("-Bottom")]
	public GameObject bottomBox;

	private bool mIsActive;

	private DatabaseSquadEventDefinition mEventDefinition;

	private DatabaseSquadEventProgress mEventProgress;

	private List<SquadEventRecordInternal> mSquadEventRecords = new List<SquadEventRecordInternal>();

	public void OnJoinedSquadEvent()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && mIsActive)
		{
			InitGUIValues();
			draggablePanel.UpdateScrollbars(recalculateBounds: true);
			draggablePanel.AlignToPos(instant: true);
		}
	}

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		mIsActive = false;
		UIEventListener uIEventListener = UIEventListener.Get(joinEventButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JoinEventClick));
		float activeWidth = UIRoot.list[0].activeWidth;
		int num = UIRoot.list[0].activeHeight - 470;
		Vector4 clipRange = panel.clipRange;
		clipRange.x = activeWidth / 2f;
		clipRange.y = (float)(-num) / 2f;
		clipRange.z = activeWidth;
		clipRange.w = num;
		panel.clipRange = clipRange;
		draggablePanel.transform.localPosition = new Vector3(draggablePanel.transform.localPosition.x, 0f, draggablePanel.transform.localPosition.z);
	}

	private void JoinEventClick(GameObject go)
	{
		if (mEventDefinition == null)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_SQUADEVENT"), Localization.Localize("ID_CONFIRM_SQUADEVENT_TEXT"), 0f);
		}
		else
		{
			GuiElementSingle<SquadEventDialog>.instance.ShowJoin();
		}
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
			TweenAlpha.Begin(panelMain.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(waitPart.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
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
		grid.MakeEmpty();
		mEventDefinition = Singleton<ServerResultsCache>.instance.squadEventDefinition;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (mEventDefinition == null || currentTimestamp < mEventDefinition.eventStart || currentTimestamp > mEventDefinition.eventEnd)
		{
			ShowNoEventAtTheMoment();
			return;
		}
		mEventProgress = Singleton<ServerResultsCache>.instance.squadEventProgress;
		if (mEventProgress == null)
		{
			ShowJoinButton();
		}
		else
		{
			ShowEventProgress();
		}
	}

	public void DoAfterHide()
	{
		grid.MakeEmpty();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = panel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenAlpha component2 = panelMain.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void ShowNoEventAtTheMoment()
	{
		waitPart.SetActive(value: false);
		noEventGO.SetActive(value: true);
		signToEvent.SetActive(value: false);
		eventProgressPart.SetActive(value: false);
		spriteToSet2.transform.localScale = spriteToSet2.transform.localScale.ReplaceX(lengthLabel2.relativeSize.x * lengthLabel2.transform.localScale.x);
	}

	public void ShowWaiting()
	{
		waitPart.SetActive(value: true);
		noEventGO.SetActive(value: false);
		signToEvent.SetActive(value: false);
		eventProgressPart.SetActive(value: false);
	}

	private void ShowJoinButton()
	{
		waitPart.SetActive(value: false);
		noEventGO.SetActive(value: false);
		signToEvent.SetActive(value: true);
		eventProgressPart.SetActive(value: false);
		spriteToSet1.transform.localScale = spriteToSet1.transform.localScale.ReplaceX(lengthLabel1.relativeSize.x * lengthLabel1.transform.localScale.x);
	}

	private void ShowEventProgress()
	{
		waitPart.SetActive(value: false);
		noEventGO.SetActive(value: false);
		signToEvent.SetActive(value: false);
		eventProgressPart.SetActive(value: true);
		float num = (UIRoot.list[0].activeWidth - 120f) / 2f;
		signToEvent.transform.localPosition = new Vector3(num, signToEvent.transform.localPosition.y, signToEvent.transform.localPosition.z);
		noEventGO.transform.localPosition = new Vector3(num, noEventGO.transform.localPosition.y, noEventGO.transform.localPosition.z);
		tierProgress.text = string.Format("{0} {1}{2} / {3}", Localization.Localize("ID_TIERSCOMPLETED"), Colours.stringBlue, mEventProgress.activeTier, mEventDefinition.tiers.Count);
		eventTime.counterLabel.text = "XXd YYh";
		eventTime.StartCountingTo(mEventDefinition.eventEnd);
		eventTime.winStreakTimer = delegate
		{
			Debug.Log("Event has ended! Download new Event");
			eventTime.counterLabel.text = Localization.Localize("ID_ENDED");
		};
		leftPart.transform.localPosition = new Vector3(num * 2f, leftPart.transform.localPosition.y, 0f);
		leftTopTable.repositionNow = true;
		leftTopTable.onReposition = delegate
		{
			leftTopTable.transform.localPosition = new Vector3(0f - endSpacer.transform.localPosition.x, leftTopTable.transform.localPosition.y, leftTopTable.transform.localPosition.z);
		};
		CreateData();
		grid.transform.localPosition = new Vector3(num, grid.transform.localPosition.y, grid.transform.localPosition.z);
		grid.init(mSquadEventRecords.Count, SquadEventRecordInstantiate, SquadEventRecordFree, draggablePanel);
		grid.offsetGrid = new Vector2(0f, 50f);
		grid.cellWidth = num * 2f;
		float num2 = 60f + Mathf.Abs(grid.helperMax.localPosition.y - grid.helperMin.localPosition.y) + 100f;
		bottomBox.transform.localPosition = new Vector3(bottomBox.transform.localPosition.x, 0f - num2, bottomBox.transform.localPosition.z);
	}

	private void CreateData()
	{
		mSquadEventRecords.Clear();
		int count = mEventDefinition.tiers.Count;
		float length = UIRoot.list[0].activeWidth - 120f;
		if (mEventProgress.tiers.Count != mEventDefinition.tiers.Count)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_SERVERDATA"), Localization.Localize("ID_SQUADEVENT"), 0f, null, string.Empty);
			return;
		}
		for (int i = 0; i < count; i++)
		{
			mSquadEventRecords.Add(SquadEventRecordInternal.CreateHeader(mEventProgress.tiers[i].reward, i + 1, mEventProgress.tiers[i].GetProgress(), length, mEventProgress.activeTier >= i));
			int count2 = mEventDefinition.tiers[i].assignmentIds.Count;
			for (int j = 0; j < count2; j++)
			{
				string param = string.Empty;
				if (mEventProgress.tiers[i].assignmentsSecondParams.ContainsKey(j))
				{
					param = mEventProgress.tiers[i].assignmentsSecondParams[j];
				}
				mSquadEventRecords.Add(SquadEventRecordInternal.CreateAssignment(mEventDefinition.tiers[i].assignmentIds[j], mEventProgress.tiers[i].assignmentsProgress[j], length, mEventProgress.activeTier >= i, param, mEventProgress.tiers[i].targets[j], mEventProgress.levelProgress));
			}
		}
	}

	private Transform SquadEventRecordInstantiate(int index)
	{
		if (index >= 0 && index < mSquadEventRecords.Count)
		{
			bool isHeader = mSquadEventRecords[index].isHeader;
			string text = ((!isHeader) ? string.Format("Assignment {0}", index.ToString("D3")) : string.Format("Header {0}", index.ToString("D3")));
			SquadEventRecord squadEventRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadEventRecordPrefab, grid.gameObject, text) as SquadEventRecord;
			if (squadEventRecord != null)
			{
				if (isHeader)
				{
					squadEventRecord.InitHeader(mSquadEventRecords[index].reward, mSquadEventRecords[index].tierNumber, mSquadEventRecords[index].progress, mSquadEventRecords[index].length, mSquadEventRecords[index].active);
				}
				else
				{
					squadEventRecord.InitAssignment(mSquadEventRecords[index].assignment, mSquadEventRecords[index].progress, mSquadEventRecords[index].length, mSquadEventRecords[index].active);
				}
				return squadEventRecord.transform;
			}
		}
		return null;
	}

	private void SquadEventRecordFree(Transform obj)
	{
		if (obj != null)
		{
			SquadEventRecord component = obj.GetComponent<SquadEventRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}
}
